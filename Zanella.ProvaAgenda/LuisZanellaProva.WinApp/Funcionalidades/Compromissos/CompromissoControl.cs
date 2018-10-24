using LuisZanellaProva.Aplicacao;
using LuisZanellaProva.Dominio.Funcionalidades.Compromissos;
using LuisZanellaProva.Infra.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LuisZanellaProva.WinApp.Funcionalidades.Compromissos
{
    public partial class CompromissoControl : UserControl
    {
        private ICompromissoRepository _compromissoRepository;
        private CompromissoService _compromissoService;

        public CompromissoControl()
        {
            InitializeComponent();

            _compromissoRepository = new CompromissoRepository();
            _compromissoService = new CompromissoService(_compromissoRepository);
        }

        public void PopularListagemCompromisso(IList<Compromisso> compromisso)
        {
            listBoxCompromisso.Items.Clear();

            foreach (Compromisso item in compromisso)
            {
                listBoxCompromisso.Items.Add(item);
            }
        }

        public Compromisso ObtemCompromissoSelecionado()
        {
            return (Compromisso)listBoxCompromisso.SelectedItem;
        }
    }
}
