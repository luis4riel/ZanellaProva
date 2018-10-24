using LuisZanellaProva.Aplicacao;
using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using LuisZanellaProva.WinApp.Funcionalidades.Contatos;
using LuisZanellaProva.Infra.Data;
using LuisZanellaProva.WinApp.Funcionalidades;
using System;
using System.Windows.Forms;
using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using LuisZanellaProva.WinApp.Funcionalidades.Compromissos;

namespace LuisZanellaProva.WinApp
{
    public partial class Form1 : Form
    {
        private static IContatoRepository _contatoRepository = new ContatoRepository();
        private static ICompromissoRepository _compromissoRepository = new CompromissoRepository();

        private ContatoService _contatoService = new ContatoService(_contatoRepository);
        private CompromissoService _compromissoService = new CompromissoService(_compromissoRepository);

        private GerenciadorFormulario _gerenciador;
        private ContatoGerenciadorFormulario _contatoGerenciador;
        private GerenciadorCompromissoFormulario _compromissoGerenciador;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Adicionar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Adicionar();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Editar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Excluir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");

                _gerenciador.Editar();
            }
        }

        private void contatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_contatoGerenciador == null)
                _contatoGerenciador = new ContatoGerenciadorFormulario(_contatoService);

            CarregarCadastro(_contatoGerenciador);
        }
        private void compromissosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_compromissoGerenciador == null)
                _compromissoGerenciador = new GerenciadorCompromissoFormulario(_compromissoService, _contatoService);

            CarregarCadastro(_compromissoGerenciador);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;

            labelTipoCadastro.Text = _gerenciador.ObtemTipoCadastro();

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(listagem);

            _gerenciador.AtualizarLista();

            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;

        }

       
    }
}
