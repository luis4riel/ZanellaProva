using MF6.API.Controllers.Common;
using MF6.Application.Features.Impressoras;
using MF6.Domain.Features.Impressoras;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Features.Impressoras;
using System.Web.Http;

namespace MF6.API.Controllers.Impressoras
{
    [RoutePrefix("api/impressora")]
    public class ImpressoraController : ApiControllerBase
    {
        public IImpressoraServico _impressoraServico;

        public ImpressoraController() : base()
        {
            var contexto = new MF6Context();
            var repositorio = new ImpressoraRepositorio(contexto);
            _impressoraServico = new ImpressoraServico(repositorio);
        }

        #region HttpGet

        [HttpGet]
        public IHttpActionResult Get()
        {
            var query = _impressoraServico.PegarTodos();
            return HandleQueryable<Impressora>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _impressoraServico.PegarPorId(id));
        }

        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(Impressora impressora)
        {
            return HandleCallback(() => _impressoraServico.Inserir(impressora));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(Impressora impressora)
        {
            return HandleCallback(() => _impressoraServico.Atualizar(impressora));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(Impressora impressora)
        {
            return HandleCallback(() => _impressoraServico.Deletar(impressora));
        }

        #endregion HttpDelete

        #region HttpPatch
        [HttpPatch]
        [Route("tonerPreto/{id:int}")]
        public IHttpActionResult UpdateLevelBlack(int id, [FromBody] int nivel)
        {
            return HandleCallback(() => _impressoraServico.AtualizarTonerPreto(id, nivel));
        }

        [HttpPatch]
        [Route("tonerColorido/{id:int}")]
        public IHttpActionResult UpdateLevelColor(int id, [FromBody] int nivel)
        {
            return HandleCallback(() => _impressoraServico.AtualizarTonerColorido(id, nivel));
        }
        #endregion
    }
}
