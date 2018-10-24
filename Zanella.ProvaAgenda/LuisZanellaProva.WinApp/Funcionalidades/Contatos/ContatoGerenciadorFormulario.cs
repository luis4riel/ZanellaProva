using LuisZanellaProva.Aplicacao;
using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Contatos
{
    public class ContatoGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly ContatoService _contatoService;

        private ContatoControl _contatoControl;

        public ContatoGerenciadorFormulario(ContatoService disciplinaService)
        {
            _contatoService = disciplinaService;
        }

        public override void Adicionar()
        {
            CadastroContatoDialog dialog = new CadastroContatoDialog();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _contatoService.Adiciona(dialog.Contato);
                ListarContatos();
            }
        }

        private void ListarContatos()
        {
            IList<Contato> contatos = _contatoService.SelecionaTudo();
            _contatoControl.PopularListagemContatos(contatos);
        }

        public override void AtualizarLista()
        {
            ListarContatos();
        }

        public override UserControl CarregarListagem()
        {
            if (_contatoControl == null)
                _contatoControl = new ContatoControl();

            return _contatoControl;
        }

        public override void Editar()
        {
            Contato contatoSelecionado = _contatoControl.ObtemContatoSelecionado();

            if (contatoSelecionado != null)
            {
                CadastroContatoDialog dialog = new CadastroContatoDialog(contatoSelecionado);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _contatoService.Edita(contatoSelecionado);
                }

                ListarContatos();
            }
            else
            {
                MessageBox.Show("Selecione um contato!");
            }
        }

        public override void Excluir()
        {
            Contato contatoSelecionado = _contatoControl.ObtemContatoSelecionado();

            if (contatoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o contato "
                    + contatoSelecionado.Nome, "Excluir Contato",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _contatoService.Deleta(contatoSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarContatos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um Contato!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Contatos";
        }
    }
}
