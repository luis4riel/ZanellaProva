using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System.Collections.Generic;

namespace LuisZanellaProva.Aplicacao
{
    public class ContatoService
    {
        private IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Adiciona(Contato contato)
        {
            contato.Valida();
            _contatoRepository.Adicionar(contato);
        }

        public void Edita(Contato contato)
        {
            contato.Valida();
            _contatoRepository.Editar(contato);
        }

        public void Deleta(Contato contato)
        {
            _contatoRepository.Deletar(contato.Id);
        }

        public Contato SelecionaPorId(int id)
        {
            return _contatoRepository.SelecionaPorId(id);
        }

        public IList<Contato> SelecionaTudo()
        {
            return _contatoRepository.SelecionaTudo();
        }
    }
}
