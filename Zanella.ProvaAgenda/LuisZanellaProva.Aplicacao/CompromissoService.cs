using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisZanellaProva.Aplicacao
{
    public class CompromissoService
    {
        private ICompromissoRepository _compromissoRepository;

        public CompromissoService(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }

        public void Adiciona(Compromisso compromisso)
        {
            compromisso.Valida();
            _compromissoRepository.Adicionar(compromisso);
        }

        public void Edita(Compromisso compromisso)
        {
            compromisso.Valida();
            _compromissoRepository.Editar(compromisso);
        }

        public void Deleta(Compromisso compromisso)
        {
            _compromissoRepository.Deletar(compromisso.Id);
        }

        public Compromisso SelecionaPorId(int id)
        {
            return _compromissoRepository.SelecionaPorId(id);
        }

        public IList<Compromisso> SelecionaTudo()
        {
            return _compromissoRepository.SelecionaTudo();
        }
    }
}
