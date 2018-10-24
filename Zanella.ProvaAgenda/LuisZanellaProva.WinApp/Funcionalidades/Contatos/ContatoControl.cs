using LuisZanellaProva.Aplicacao;
using LuisZanellaProva.Dominio.Funcionalidades.Contatos;
using LuisZanellaProva.Infra.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Contatos
{
    public partial class ContatoControl : UserControl
    {
        private IContatoRepository _contatoRepository;
        private ContatoService _contatoService;

        public ContatoControl()
        {
            InitializeComponent();


            _contatoRepository = new ContatoRepository();
            _contatoService = new ContatoService(_contatoRepository);

        }

        public void PopularListagemContatos(IList<Contato> contatos)
        {
            listBoxContatos.Items.Clear();

            foreach (Contato item in contatos)
            {
                listBoxContatos.Items.Add(item);
            }
        }

        public Contato ObtemContatoSelecionado()
        {
            return (Contato)listBoxContatos.SelectedItem;
        }
    }
}
