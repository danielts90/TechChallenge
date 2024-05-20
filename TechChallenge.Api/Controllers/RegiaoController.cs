using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.CustomResponse;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class RegiaoController : BaseController<RegiaoDto, Regiao>
    {
        private readonly IRegiaoService _regiaoService;
        public RegiaoController(IRegiaoService service) : base(service)
        {
            _regiaoService = service;
        }

        [HttpGet]
        [Route("regiao-com-ddds/{regiaoId}")]
        public async Task<IActionResult> ObterRegiaoComDddAsync(long regiaoId)
        {
            try
            {
                var reigaoComDdd = await _regiaoService.ObterRegiaoComDdd(regiaoId);
                return Ok(new CustomResponse<RegiaoComDddDto>(true, "sucess", reigaoComDdd));

            }
            catch (Exception ex)
            {
                return BadRequest(new CustomResponse<string>(false, $"Erro ao consultar os registros da regiao {regiaoId}, {ex.Message}", null));

            }

        }

    }
}
