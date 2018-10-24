using LuisZanellaProva.Aplicacao;
using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Compromissos
{
    public class GerenciadorCompromissoFormulario : GerenciadorFormulario
    {
        private readonly CompromissoService _compromissoService;
        private readonly ContatoService _contatoService;

        private CompromissoControl _compromissoControl;

        private IList<Contato> contatos;

        public GerenciadorCompromissoFormulario(CompromissoService compromissoService, ContatoService contatoService)
        {
            _compromissoService = compromissoService;
            _contatoService = contatoService;
            contatos = contatoService.SelecionaTudo();
        }

        public override void Adicionar()
        {
            CadastroCompromissoDialog dialog = new CadastroCompromissoDialog(contatos);

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _compromissoService.Adiciona(dialog.Compromisso);
                ListarCompromisso();
            }
        }

        private void ListarCompromisso()
        {
            IList<Compromisso> compromissos = _compromissoService.SelecionaTudo();
            _compromissoControl.PopularListagemCompromisso(compromissos);
        }

        public override void AtualizarLista()
        {
            ListarCompromisso();
        }

        public override UserControl CarregarListagem()
        {
            if (_compromissoControl == null)
                _compromissoControl = new CompromissoControl();

            return _compromissoControl;
        }

        public override void Editar()
        {
            Compromisso compromissoSelecionado = _compromissoControl.ObtemCompromissoSelecionado();

            if (compromissoSelecionado != null)
            {
                CadastroCompromissoDialog dialog = new CadastroCompromissoDialog(compromissoSelecionado);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _compromissoService.Edita(compromissoSelecionado);
                }

                ListarCompromisso();
            }
            else
            {
                MessageBox.Show("Selecione um compromisso!");
            }
        }

        public override void Excluir()
        {
            Compromisso compromissoSelecionado = _compromissoControl.ObtemCompromissoSelecionado();

            if (compromissoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o compromisso "
                    + compromissoSelecionado.Assunto, "Excluir Contato",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _compromissoService.Deleta(compromissoSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarCompromisso();
                }
            }
            else
            {
                MessageBox.Show("Selecione um Contato!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Compromissos";
        }
    }
}
