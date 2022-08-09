﻿using CheckMate_API.Models;
using CheckMate_API.Tools;
using CheckMate_BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckMate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _service;

        public MemberController(IMemberService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(MemberRegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_service.Create(form.FromRegisterFormToModel().FromModelToBLL()));
        }
    }
}
