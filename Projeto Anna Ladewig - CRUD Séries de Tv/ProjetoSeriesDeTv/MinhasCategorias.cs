using System;
using System.Collections; //Para poder usar os ArrayLists.
using System.Windows.Forms;

namespace ProjetoSeriesDeTv
{
    public partial class frmMinhasCategorias : Form
    {
        public ArrayList codigoCategoria = new ArrayList();
        public ArrayList nomeCategoria = new ArrayList();
        public frmMinhasCategorias()
        {
            InitializeComponent();
        }

        private void FrmMinhasCategorias_Load(object sender, EventArgs e)
        {
            listViewCategorias.Items.Clear();
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);

            for (int i = 0; i < codigoCategoria.Count; i++)
            {
                    //Atribui uma nova linha ao ListView e coloca o valor na primeira célula. Tem que converter para string, pois no ArrayList se guarda como objeto.
                ListViewItem linha = listViewCategorias.Items.Add(Convert.ToString(codigoCategoria[i]));

                    //O SubItems.Add coloca um valor na próxima célula da linha. Tem que converter para string, pois no ArrayList se guarda como objeto.
                linha.SubItems.Add(Convert.ToString(nomeCategoria[i]));
            }

        }

    }
}
