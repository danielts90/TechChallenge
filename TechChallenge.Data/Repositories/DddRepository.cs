using Dapper;
using System.Data;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class DddRepository : BaseRepository<Ddd>, IDddRepository
    {
        public DddRepository(IDbConnection connection) : base(connection)
        {
        }

        private const string OBTER_DDD_COM_CONTATOS =
           @"Select  d.id as Id,
                     d.codigo as Codigo, 
                     c.id as Id,
                     c.nome as Nome,
                     c.email as Email, 
                     c.telefone as Telefone
               From ddd d
               left join contato c on d.id = c.ddd_id
               where d.id = @dddId";

        public async Task<DddComContatosDto> ObterDddComContatos(long dddId)
        {
            var dddLookup = new Dictionary<long, DddComContatosDto>();

            var dddContatos = await _db.QueryAsync<DddDto, ContatoDto, DddComContatosDto>(OBTER_DDD_COM_CONTATOS,
                (ddd, contato) =>
                {
                    if (!dddLookup.TryGetValue(ddd.Id, out var dddlkp))
                    {
                        dddlkp = new DddComContatosDto();
                        dddlkp.Ddd = ddd;
                        dddLookup.Add(ddd.Id, dddlkp);
                    }

                    if (contato is ContatoDto) dddlkp.Contatos.Add(contato);
                    return dddlkp;
                },
                param: new { dddId },
                splitOn: "Id");

            return dddLookup.Values.FirstOrDefault();
        }

        


    }
}
