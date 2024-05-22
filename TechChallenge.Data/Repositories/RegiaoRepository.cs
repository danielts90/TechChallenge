using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class RegiaoRepository : BaseRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(IDbConnection connection) : base(connection)
        {
        }

        private const string OBTER_REGIAO_COM_DDDs =
            @"Select r.id as Id,
                     r.nome as Nome, 
                     d.id as Id,
                     d.codigo as Codigo
               From regiao r 
               left join ddd d on d.regiao_id = r.id
               where r.id = @regiaoId";

        public async Task<RegiaoComDddDto> ObterRegiaoComDdds(long regiaoId)
        {
            var regiaoLookup = new Dictionary<long, RegiaoComDddDto>();

            await _db.QueryAsync<RegiaoDto, DddDto, RegiaoComDddDto>(OBTER_REGIAO_COM_DDDs,
                (regiao, ddd) =>
                {
                   if(!regiaoLookup.TryGetValue(regiao.Id, out var regiaolkp))
                    {
                        regiaolkp = new RegiaoComDddDto();
                        regiaolkp.Regiao = regiao;
                        regiaoLookup.Add(regiao.Id, regiaolkp);
                    }

                    if(ddd is DddDto) regiaolkp.DddsRegiao.Add(ddd);
                    return regiaolkp;
                },
                param: new {regiaoId},
                splitOn: "Id");

            return regiaoLookup.Values.FirstOrDefault() ?? new RegiaoComDddDto
            {
                Regiao = new(), 
                DddsRegiao = new()
            };

        }
    }
}
