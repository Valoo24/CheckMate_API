using CheckMate_API.Exceptions;
using CheckMate_API.Infrastructure;
using CheckMate_API.Models;
using CheckMate_API.Tools;
using CheckMate_BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckMate_API.Controllers
{
    /// <summary>
    /// Controller pour le Model Member.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        #region Propriétés et Constructeurs
        private MemberService _service;
        private TokenManager _tokenManager;
        public MemberController(MemberService service, TokenManager manager)
        {
            _tokenManager = manager;
            _service = service;
        }
        #endregion

        #region Méthodes du CRUD
        /// <summary>
        /// Méthode de l'API qui permet de créer un Member dans la base de donnée.
        /// </summary>
        /// <param name="form">Formulaire de création du Member.</param>
        /// <returns>Une réponse HTTP avec l'ID du Member crée.</returns>
        [HttpPost("Register")]
        public IActionResult Create(MemberRegisterForm form)
        {
            string MemberCreatedMail = @$"
Félicitations !

Votre compte a bien été crée sur le serveur des services CheckMate !

Voici les informations de votre compte. Nous vous invitons à noter ces informtions en lieu sûr et à supprimer ce mail dès que possible.

Pseudo = {form.Pseudo}
Adresse mail = {form.Mail}
Mot de Passe = {form.Password}

Bien à vous,

l'équipe de développement du service CheckMate.";
            int CreatedMemberId;

            if (!ModelState.IsValid)
            {
                return BadRequest("Le formulaire d'inscription n'a pas été rempli correctement.");
            }

            if (form.Gender.Length > 1)
            {
                return BadRequest("Le champ \"Gender\" ne peut pas contenir plus d'une lettre");
            }

            if (form.Gender == "X" || form.Gender == "M" || form.Gender == "F")
            {
                try
                {
                    CreatedMemberId = _service.Create(form.FromRegisterFormToModel().FromModelToBLL());
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

                try
                {
                    MailManager.SendFromKhunly(form.Mail, MemberCreatedMail, "Votre inscription aux services CheckMate.");
                }
                catch (MailNotSentExceptions e)
                {
                    return Ok($"Le Member a bien été crée (ID = {CreatedMemberId}), mais le mail ne s'est pas envoyé correctement. Message d'erreur:\n{e.Message}");
                }

                return Ok($"Le Member a bien été crée. ID = {CreatedMemberId}");

            }
            else
            {
                return BadRequest("Le champ \"Gender\" n'accepte que les lettres suivantes: M pour Male, F pour Female et X pour Autre");
            }
        }
        /// <summary>
        /// Méthode de l'API qui permet de Supprimer un Member selon une ID.
        /// </summary>
        /// <param name="id">ID du Member à supprimée dans la base de donnée.</param>
        /// <returns>Une réponse HTTP avec l'ID du Member supprimée.</returns>
        [Authorize("Auth")]
        [HttpDelete("DeleteMember")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(_service.Delete(id) == false)
                {
                    return BadRequest($"Aucun Member avec l'ID n°{id} n'a pu être supprimé.");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok($"Le Member n°{id} a bien été supprimé correctement.");
        }
        #endregion

        #region Méthodes Custom
        /// <summary>
        /// Méthode de l'API permettant de se connecter en tant que Member.
        /// </summary>
        /// <param name="login">Formulaire de connexion rempli par l'utilisateur.</param>
        /// <returns>Une réponse HTTP avec le Token du Member si la connexion a réussi. Un message d'erreur si la connexion a échouée.</returns>
        [HttpPost("login")]
        public IActionResult Login(MemberLoginForm login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    Member currentUser = _service.Login(login.Credentials, login.Password).FromBLLToModel();
                    currentUser.Token = _tokenManager.GenerateToken(currentUser);
                    return Ok(currentUser.Token);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
        #endregion
    }
}