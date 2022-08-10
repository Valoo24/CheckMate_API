using CheckMate_API.Infrastructure;
using CheckMate_API.Models;
using CheckMate_API.Tools;
using CheckMate_BLL.Services;
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
        [HttpPost]
        public IActionResult Create(MemberRegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_service.Create(form.FromRegisterFormToModel().FromModelToBLL()));
        }
        #endregion

        #region Méthodes Custom
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
                    Member currentUser = _service.Login(login.Credentials,login.Password).FromBLLToModel();

                    currentUser.Token = _tokenManager.GenerateToken(currentUser);
                    return Ok(currentUser.Token);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
        #endregion
    }
}