using CheckMate_API.Models;
using CheckMate_API.Tools;
using CheckMate_BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        //[Authorize("Auth")]
        public IActionResult GetAll()
        {
            return Ok(_service.ReadAll().Select(x => x));
        }

        [Authorize("Auth")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.Read(id));
        }
        
        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(TournamentForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
       // [Authorize("Admin")]

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
