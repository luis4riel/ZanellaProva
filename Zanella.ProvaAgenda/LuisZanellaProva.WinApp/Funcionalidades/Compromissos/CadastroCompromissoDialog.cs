using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Compromissos
{
    public partial class CadastroCompromissoDialog : Form
    {
        private Compromisso _compromisso;
        private IList<Contato> _contatos;

        public Compromisso Compromisso
        {
            get { return _compromisso; }
            set
            {
                _compromisso = value;

                textBoxId.Text = _compromisso.Id.ToString();
                textBoxAssunto.Text = _compromisso.Assunto;
                textBoxLocal.Text = _compromisso.Local;
                dateTimePickerDataInicial.Value = _compromisso.DataInicial;
                dateTimePickerDataInicial.Value = _compromisso.DataFinal;
                checkBoxDiaTodo.Checked = _compromisso.DiaTodo;

            }
        }

        public CadastroCompromissoDialog(IList<Contato> contatos)
        {
            InitializeComponent();
            _contatos = contatos;
            listBoxContatos.Items.Clear();
            foreach (var item in contatos)
            {
                listBoxContatos.Items.Add(item);
            }
        }

        public CadastroCompromissoDialog(Compromisso compromissoSelecionado)
        {
            InitializeComponent();

            Compromisso = compromissoSelecionado;
        }

        private void buttonCadastrar_Click_1(object sender, EventArgs e)
        {
            if (_compromisso == null)
            {
                _compromisso = new Compromisso();
            }

            _compromisso.Assunto = textBoxAssunto.Text;
            _compromisso.Local = textBoxLocal.Text;
            _compromisso.DataInicial = dateTimePickerDataInicial.Value;
            _compromisso.DataFinal = dateTimePickerDataFinal.Value;
            _compromisso.DiaTodo = checkBoxDiaTodo.Checked;

            try
            {
                _compromisso.Valida();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {

            _compromisso.Contatos.Add(listBoxContatos.SelectedItem as Contato);

        }
    }
}
