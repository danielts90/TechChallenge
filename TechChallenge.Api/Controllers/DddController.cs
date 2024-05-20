using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.CustomResponse;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class DddController : BaseController<DddDto, Ddd>
    {
        private readonly IDddService _dddservice;
        public DddController(IDddService service) : base(service)
        {
            _dddservice = service;
        }

        [HttpGet]
        [Route("ddd-com-contato/{dddId}")]
        public async Task<IActionResult> GetDddComContato(long dddId)
        {
            try
            {
                var dddContato = await _dddservice.ObterDddsComContato(dddId);
                return Ok(new CustomResponse<DddComContatosDto>(true, "sucess", dddContato));

            }
            catch (Exception ex)
            {
                return BadRequest(new CustomResponse<string>(false, $"Erro ao consultar os registros do ddd {dddId}, {ex.Message}", null));
            }
        }
    }
}
