using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Contatos
{
    public partial class CadastroContatoDialog : Form
    {
        private Contato _contato;

        public Contato Contato
        {
            get { return _contato; }
            set
            {
                _contato = value;

                textBoxId.Text = _contato.Id.ToString();
                textBoxNome.Text = _contato.Nome;
                textBoxEmail.Text = _contato.Email;
                textBoxDepartamento.Text = _contato.Departamento;
                textBoxEndereco.Text = _contato.Endereco;
                textBoxTelefone.Text = _contato.Telefone;
            }
        }

        public CadastroContatoDialog()
        {
            InitializeComponent();
        }

        public CadastroContatoDialog(Contato contatoSelecionado)
        {
            InitializeComponent();

            Contato = contatoSelecionado;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {

            if (_contato == null)
            {
                _contato = new Contato();
            }

            _contato.Nome = textBoxNome.Text;


            _contato.Nome = textBoxNome.Text;
            _contato.Email = textBoxEmail.Text;
            _contato.Departamento = textBoxDepartamento.Text;
            _contato.Endereco = textBoxEndereco.Text;
            _contato.Telefone = textBoxTelefone.Text;

            try
            {
                _contato.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }

        }
    }
}
