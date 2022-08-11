using CheckMate_API.Models;
using CheckMate_API.Tools;
using CheckMate_BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CheckMate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private TournamentService _service;

        public TournamentController(TournamentService service)
        {
            _service = service;
        }



        [HttpGet("AllTournament")]
        [Authorize("Auth")]
        public IActionResult GetAll()
        {
           
            return Ok(_service.ReadAll().Select(x => x));
        }

        [HttpGet("Top10ByUpdate")]
        public IActionResult GetTop10ByUpdateTime()
        {
            IList<Tournament> tournaments = new List<Tournament>();
            foreach(CheckMate_BLL.BLL_Entities.Tournament tournament in _service.GetTop10ByUpdateTime())
            {
                

                tournaments.Add(new Tournament 
                { 
                    TournamentId = tournament.Id,
                    Name = tournament.Name,
                    Place = tournament.Place,
                    MemberRegisteredForTournament = tournament.MemberRegisteredForTournament,
                    MinPlayer = tournament.MinPlayer,
                    MaxPlayer = tournament.MaxPlayer,
                    Category = tournament.Category,
                    MinElo = tournament.MinElo,
                    MaxElo = tournament.MaxElo,
                    TournamentStatus = tournament.TournamentStatus,
                    SavedEndDate = tournament.EndDate,
                    TournamentRound = tournament.TournamentRound,
                });
            }
            return Ok(_service.GetTop10ByUpdateTime());
        }

        [Authorize("Auth")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.Read(id));
        }

        [Authorize("Admin")]
        [HttpPost("CreateTournament")]
        public IActionResult Create(TournamentForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Le formulaire de création de tournoi n'a pas été rempli correctement.");
            }

            if(form.MinPlayer > form.MaxPlayer)
            {
                return BadRequest("Impossible de créer un tournoi avec un nombre minimum de joueur supérieur au nombre maximum de joueurs.");
            }

            if(form.MinElo > form.MaxElo)
            {
                return BadRequest("Impossible de créer un tournoi où l'Elo minimum requis est supérieur à l'Elo maximum autorisé.");
            }

            try
            {
                _service.Create(form.FromTournamentFormToModel().FromAPIToBLL());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Auth")]
        [Authorize("Admin")]

        [HttpDelete("DeleteTournament")]
        public IActionResult Delete(int id)
        {
             if (_service.Read(id).EndDate < DateTime.Now)
            {
                return BadRequest("Impossible de supprimer un tournoi qui a déjà commencé.");
            }

            else
            {
                if (_service.Delete(id))
                {
                    return Ok($"Le Tournament n°{id} a bien été supprimé.");
                }
                else
                {
                    return BadRequest($"Le Tournament n°{id} n'existe pas dans la base de donnée.");
                }
            }
        }
        [Authorize("Auth")]
        [HttpPost("Inscription/{id}")]
        public IActionResult Inscription(int id)
        {
            string idJoueur = User.FindFirst(ClaimTypes.Sid).Value;
            if (_service.CheckInscription(id, int.Parse(idJoueur)) == false)
            {
                _service.Inscription(id, int.Parse(idJoueur));
                return Ok();
            }
            return BadRequest($"Vous etes deja inscrit au tournoi n°{id}");
            
        }
        /*[HttpPut]
        public IActionResult Update([FromBody] GameForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                if (_service.Update(form.ToModel())) return Ok();
                return Forbid();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/
        //[Authorize("Auth")]

    }
}
