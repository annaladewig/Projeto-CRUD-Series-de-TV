using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; //Para poder usar os ArryLists.

namespace ProjetoSeriesDeTv
{
    public partial class frmMinhasSeriesFavoritas : Form
    {
        //ArrayLists Séries
        public ArrayList codigoSerie = new ArrayList();
        public ArrayList nomeSerie = new ArrayList();
        public ArrayList temporadaAtual = new ArrayList();
        public ArrayList ultimoEpisodioAssistido = new ArrayList();
        public ArrayList totalDeTemporadas = new ArrayList();
        public ArrayList categoriaDaSerie = new ArrayList();

        //ArrayLists Categorias (vão servir para quando for ler o arquivo txt de categorias e preencher o combobox.)
        public ArrayList codigoCategoria = new ArrayList();
        public ArrayList nomeCategoria = new ArrayList();

        public frmMinhasSeriesFavoritas()
        {
            InitializeComponent();
        }

        private void FrmGerenciamentoSeries_Load(object sender, EventArgs e)
        {
            //Limpa o ListView.
            listViewSeries.Items.Clear();

            //Para ler o arquivo txt e carregar nos ArrayLists.
            BibliotecaDeSubRotinas.LerSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido,totalDeTemporadas,categoriaDaSerie);

            for (int i=0; i < codigoSerie.Count; i++)
            {
                //Atribui uma nova linha ao ListView e coloca o valor na primeira célula. Tem que converter para string, pois no ArrayList se guarda como objeto.
                ListViewItem linha = listViewSeries.Items.Add(Convert.ToString(codigoSerie[i]));

                //O SubItems.Add coloca um valor na próxima célula da linha. Tem que converter para string, pois no ArrayList se guarda como objeto.
                linha.SubItems.Add(Convert.ToString(nomeSerie[i]));
                linha.SubItems.Add(Convert.ToString(temporadaAtual[i]));
                linha.SubItems.Add(Convert.ToString(ultimoEpisodioAssistido[i]));
                linha.SubItems.Add(Convert.ToString(totalDeTemporadas[i]));
                linha.SubItems.Add(Convert.ToString(categoriaDaSerie[i]));
            }

            //Preenchendo o ComboBox
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                comboBoxSeriesPorCategoria.Items.Add(nomeCategoria[i]);
            }

            //Adiciona no final a opção listar tudo.
            comboBoxSeriesPorCategoria.Items.Add("Listar Tudo");
        }

        private void BtnListarSeriesDaquelaCategoria_Click(object sender, EventArgs e)
        {
            //Limpa o ListView
            listViewSeries.Items.Clear();

            //Procura qual foi a categoria selecionada no combobox e adiciona na variável "categoriaselecionada".
            //O SelectedIndex mostra o índice do item que foi selecionado no combobox, que começa em zero. O que vai coincidir com o indice do ArrayList da categoria selecionada.
            string categoriaSelecionada;
            for(int i=0; i< nomeCategoria.Count; i++)
            {
                if (comboBoxSeriesPorCategoria.SelectedIndex == i)
                {
                    categoriaSelecionada = Convert.ToString(nomeCategoria[i]);

                    //Procura, dentro do ArrayList categoriaDaSerie, quais pertencem à categoria selecionada para mostrar apenas essas.
                    for (int j = 0; j < nomeSerie.Count; j++)
                    {
                        if(Convert.ToString(categoriaDaSerie[j]).ToUpper() == categoriaSelecionada.ToUpper())
                        {
                            //Atribui uma nova linha ao ListView e coloca o valor na primeira célula. Vai mostrar apenas as da categoria selecionada.
                            ListViewItem linha = listViewSeries.Items.Add(Convert.ToString(codigoSerie[j]));

                            //O SubItems.Add coloca um valor na próxima célula da linha. Vai mostrar apenas as da categoria selecionada.
                            linha.SubItems.Add(Convert.ToString(nomeSerie[j]));
                            linha.SubItems.Add(Convert.ToString(temporadaAtual[j]));
                            linha.SubItems.Add(Convert.ToString(ultimoEpisodioAssistido[j]));
                            linha.SubItems.Add(Convert.ToString(totalDeTemporadas[j]));
                            linha.SubItems.Add(Convert.ToString(categoriaDaSerie[j]));

                        }
                    }
                }
            }

            //Listar tudo novamente, caso seja selecionado o Listar Tudo no Combo Box.
            if (Convert.ToString(comboBoxSeriesPorCategoria.SelectedItem) == "Listar Tudo")
            {
                for (int i = 0; i < codigoSerie.Count; i++)
                {
                    //Atribui uma nova linha ao ListView e coloca o valor na primeira célula. Tem que converter para string, pois no ArrayList se guarda como objeto.
                    ListViewItem linha = listViewSeries.Items.Add(Convert.ToString(codigoSerie[i]));

                    //O SubItems.Add coloca um valor na próxima célula da linha. Tem que converter para string, pois no ArrayList se guarda como objeto.
                    linha.SubItems.Add(Convert.ToString(nomeSerie[i]));
                    linha.SubItems.Add(Convert.ToString(temporadaAtual[i]));
                    linha.SubItems.Add(Convert.ToString(ultimoEpisodioAssistido[i]));
                    linha.SubItems.Add(Convert.ToString(totalDeTemporadas[i]));
                    linha.SubItems.Add(Convert.ToString(categoriaDaSerie[i]));

                }

            }
        }

    }
}
