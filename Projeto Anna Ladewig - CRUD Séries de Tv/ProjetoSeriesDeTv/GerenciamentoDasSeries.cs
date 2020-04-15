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
    public partial class frmGerenciamentoDasSeries : Form
    {
        //ArrayListas Séries 
        public ArrayList codigoSerie = new ArrayList();
        public ArrayList nomeSerie = new ArrayList();
        public ArrayList temporadaAtual = new ArrayList();
        public ArrayList ultimoEpisodioAssistido = new ArrayList();
        public ArrayList totalDeTemporadas = new ArrayList();
        public ArrayList categoriaDaSerie = new ArrayList();

        //ArrayLists Categorias (vão servir para quando eu for ler o arquivo txt de categorias para ver se existe aquela categoria no cadastro.
        public ArrayList codigoCategoria = new ArrayList();
        public ArrayList nomeCategoria = new ArrayList();

        public frmGerenciamentoDasSeries()
        {
            InitializeComponent();
        }

        private void FrmAdicionarSerie_Load(object sender, EventArgs e)
        {
            btnExcluirSerie.Enabled = false;
            btnSalvarSerie.Enabled = false;
        }
  
        private void BtnAdicionarSerie_Click(object sender, EventArgs e)
        {       
                //Limpa todos os ArrayLists antes de começar.
            codigoSerie.Clear(); nomeSerie.Clear(); temporadaAtual.Clear(); ultimoEpisodioAssistido.Clear(); totalDeTemporadas.Clear(); categoriaDaSerie.Clear();
                
                //Carrega as informações do arquivo txt.
            BibliotecaDeSubRotinas.LerSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);

                //Crítica não pode ter campo em branco.
            if (txtNomeSerie.Text == "" || txtTemporadaAtual.Text == "" || txtUltimoEpisodioAssistido.Text == "" || txtTotalDeTemporadas.Text == "" || txtCategoriaDaSerie.Text == "")
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

                //Crítica para aceitar somente números. (Campo Temporada Atual)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtTemporadaAtual.Text) == true)
            {
                MessageBox.Show("O campo TEMPORADA ATUAL aceita apenas NÚMEROS.");
                txtTemporadaAtual.Focus();
                return;
            }
                //Crítica para aceitar somente números. (Campo Último Episódio Assistido)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtUltimoEpisodioAssistido.Text) == true)
            {
                MessageBox.Show("O campo ÚLTIMO EPISÓDIO ASSISTIDO aceita apenas NÚMEROS.");
                txtUltimoEpisodioAssistido.Focus();
                return;
            }
            
                //Crítica para aceitar somente números. (Campo Total de Temporadas)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtTotalDeTemporadas.Text) == true)
            {
                MessageBox.Show("O campo TOTAL DE TEMPORADAS aceita apenas NÚMEROS.");
                txtTotalDeTemporadas.Focus();
                return;
            }

               //Crítica para aceitar somente letras. (Campo Categoria)
            if (BibliotecaDeSubRotinas.CríticaApenasLetras(txtCategoriaDaSerie.Text) == true)
            {
                MessageBox.Show("O campo CATEGORIA deve possuir apenas LETRAS.");
                txtCategoriaDaSerie.Focus();
                return;
            }
                //Consulta se a categoria existe no cadastro de categorias.
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);
            int naoExisteCategoria = 0;
            for (int i=0; i < nomeCategoria.Count; i++)
            {
                if (txtCategoriaDaSerie.Text.ToUpper() != Convert.ToString(nomeCategoria[i]).ToUpper())
                {
                    naoExisteCategoria++;
                }
                if (naoExisteCategoria == nomeCategoria.Count)
                {
                    MessageBox.Show("Categoria informada não existe no cadastro.");
                    naoExisteCategoria = 0;
                    return;
                }

            }
                //Consulta se já existe o cadastro dessa série.
            int contador = 1;
            bool jaExiste = false;
            for (int i = 0; i < nomeSerie.Count; i++)
            {
                if (txtNomeSerie.Text.ToUpper() == Convert.ToString(nomeSerie[i]).ToUpper())
                {
                    jaExiste = true;
                    MessageBox.Show("Essa série já existe no cadastro.");
                    return;
                }
                contador = contador + 1;
            }

                //Se for confirmado que a série não existe.
            if (jaExiste == false)
            {
                    //Adiciona no ArrayList a nova série e todas as suas especificações.
                nomeSerie.Add(txtNomeSerie.Text);
                temporadaAtual.Add(txtTemporadaAtual.Text);
                ultimoEpisodioAssistido.Add(txtUltimoEpisodioAssistido.Text);
                totalDeTemporadas.Add(txtTotalDeTemporadas.Text);
                categoriaDaSerie.Add(txtCategoriaDaSerie.Text);

                    //Adiciona no ArrayList um código para a nova série e os zeros na frente, se necessário.
                if (contador >= 1 && contador < 10)
                {
                    codigoSerie.Add("00" + contador);
                }
                else if (contador >= 10 && contador < 100)
                {
                    codigoSerie.Add("0" + contador);
                }
                else
                {
                    codigoSerie.Add(contador);
                }

                    //Adiciona a nova serie no arquivo texto.
                BibliotecaDeSubRotinas.EscreverSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);
                
                MessageBox.Show("Série adicionada com sucesso.");
                
                    //Limpa todos os campos
                txtCodigoMostrarSerieParaEditar.Clear();
                txtNomeSerie.Clear();
                txtTemporadaAtual.Clear();
                txtUltimoEpisodioAssistido.Clear();
                txtTotalDeTemporadas.Clear();
                txtCategoriaDaSerie.Clear();

                    //Ajusta os botões.
                btnSalvarSerie.Enabled = false;
                btnExcluirSerie.Enabled = false;
                btnAdicionarSerie.Enabled = true;
                btnMostrarSerieParaEditar.Enabled = true;
            }
        }

        private void BtnMostrarSerieParaEditar_Click(object sender, EventArgs e)

        {
            btnSalvarSerie.Enabled = true;
            btnExcluirSerie.Enabled = true;
            btnAdicionarSerie.Enabled = false;
            btnMostrarSerieParaEditar.Enabled = false;

                //Limpa todos os ArrayLists antes de começar.
            codigoSerie.Clear(); nomeSerie.Clear(); temporadaAtual.Clear(); ultimoEpisodioAssistido.Clear(); totalDeTemporadas.Clear(); categoriaDaSerie.Clear();

                //Carrega as informações do arquivo txt.
            BibliotecaDeSubRotinas.LerSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);

                 //Crítica não pode ter campo em branco.
            if (txtCodigoMostrarSerieParaEditar.Text == "")
            {
                MessageBox.Show("Campo Vazio. Digite o código desejado.");
                //Ajusta os botões.
                btnSalvarSerie.Enabled = false;
                btnExcluirSerie.Enabled = false;
                btnAdicionarSerie.Enabled = true;
                btnMostrarSerieParaEditar.Enabled = true;
                return;
            }

                //Crítica para aceitar somente números.
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtCodigoMostrarSerieParaEditar.Text) == true)
            {
                MessageBox.Show("O código contém apenas números.");
                txtCodigoMostrarSerieParaEditar.Focus();
                //Ajusta os botões.
                btnSalvarSerie.Enabled = false;
                btnExcluirSerie.Enabled = false;
                btnAdicionarSerie.Enabled = true;
                btnMostrarSerieParaEditar.Enabled = true;
                return;

            }
                 // Procura se o código digitado existe no ArrayList e mostra todos os dados da série na área para edição ou exclusão.
            bool existeCodigo = false;
            for (int i = 0; i < codigoSerie.Count; i++)
            {
                if (txtCodigoMostrarSerieParaEditar.Text == Convert.ToString(codigoSerie[i]))
                {
                    string serieSelecionada = Convert.ToString(nomeSerie[i]);
                    txtNomeSerie.Text = serieSelecionada;

                    string temporadaAtualSelecionada = Convert.ToString(temporadaAtual[i]);
                    txtTemporadaAtual.Text = temporadaAtualSelecionada;

                    string ultimoEpisodioAssistidoSelecionado = Convert.ToString(ultimoEpisodioAssistido[i]);
                    txtUltimoEpisodioAssistido.Text = ultimoEpisodioAssistidoSelecionado;

                    string totalTmporadasSelecionado = Convert.ToString(totalDeTemporadas[i]);
                    txtTotalDeTemporadas.Text = totalTmporadasSelecionado;

                    string categoriaDaSerieSelecionada = Convert.ToString(categoriaDaSerie[i]);
                    txtCategoriaDaSerie.Text = categoriaDaSerieSelecionada;

                    existeCodigo = true;
                }
            }
                // Mostra mensagem de erro caso não exista o código informado.
            if (existeCodigo == false)
            {
                MessageBox.Show("Código informado não existe.");
                txtCodigoMostrarSerieParaEditar.Focus();

                //Ajusta os botões.
                btnSalvarSerie.Enabled = false;
                btnExcluirSerie.Enabled = false;
                btnAdicionarSerie.Enabled = true;
                btnMostrarSerieParaEditar.Enabled = true;

            }
        }

        private void BtnSalvarSerie_Click(object sender, EventArgs e)
        {
                //Crítica não pode ter campo em branco.
            if (txtNomeSerie.Text == "" || txtTemporadaAtual.Text == "" || txtUltimoEpisodioAssistido.Text == "" || txtTotalDeTemporadas.Text == "" || txtCategoriaDaSerie.Text == "")
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }
                //Crítica para aceitar somente letras. (Campo Categoria)
            if (BibliotecaDeSubRotinas.CríticaApenasLetras(txtCategoriaDaSerie.Text) == true)
            {
                MessageBox.Show("O campo CATEGORIA possui apenas LETRAS.");
                txtCategoriaDaSerie.Focus();
                return;
            }
                //Crítica para aceitar somente números. (Campo Temporada Atual)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtTemporadaAtual.Text) == true)
            {
                MessageBox.Show("O campo TEMPORADA ATUAL aceita apenas NÚMEROS.");
                txtTemporadaAtual.Focus();
                return;
            }
                //Crítica para aceitar somente números. (Campo Último Episódio Assistido)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtUltimoEpisodioAssistido.Text) == true)
            {
                MessageBox.Show("O campo ÚLTIMO EPISÓDIO ASSISTIDO aceita apenas NÚMEROS.");
                txtUltimoEpisodioAssistido.Focus();
                return;
            }
                //Crítica para aceitar somente números. (Campo Total de Temporadas)
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtTotalDeTemporadas.Text) == true)
            {
                MessageBox.Show("O campo TOTAL DE TEMPORADAS aceita apenas NÚMEROS.");
                txtTotalDeTemporadas.Focus();
                return;
            }

                //Consulta se a categoria informada existe no cadastro de categorias.
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);
            int naoExisteCategoria = 0;
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                if (txtCategoriaDaSerie.Text.ToUpper() != Convert.ToString(nomeCategoria[i]).ToUpper())
                {
                    naoExisteCategoria++;
                }
                if (naoExisteCategoria == nomeCategoria.Count)
                {
                    MessageBox.Show("Categoria informada não existe no cadastro.");
                    naoExisteCategoria = 0;
                    return;
                }

            }

                //Remove os dados da série do ArrayList e adiciona os dados editados em seu lugar.
            bool existeSerieEditada = false;
            string nomeSerieEditado = txtNomeSerie.Text;
            string temporadaAtualEditada = txtTemporadaAtual.Text;
            string ultimoEpisodioAssistidoEditado = txtUltimoEpisodioAssistido.Text;
            string totalDeTemporadasEditado = txtTotalDeTemporadas.Text;
            string categoriaDaSerieEditada = txtCategoriaDaSerie.Text;

            for (int i = 0; i < nomeSerie.Count; i++)
            {
                if (txtCodigoMostrarSerieParaEditar.Text == Convert.ToString(codigoSerie[i]))
                {
                    nomeSerie.RemoveAt(i);
                    nomeSerie.Insert(i, nomeSerieEditado);

                    temporadaAtual.RemoveAt(i);
                    temporadaAtual.Insert(i, temporadaAtualEditada);
                
                    ultimoEpisodioAssistido.RemoveAt(i);
                    ultimoEpisodioAssistido.Insert(i, ultimoEpisodioAssistidoEditado);

                    totalDeTemporadas.RemoveAt(i);
                    totalDeTemporadas.Insert(i, totalDeTemporadasEditado);

                    categoriaDaSerie.RemoveAt(i);
                    categoriaDaSerie.Insert(i, categoriaDaSerieEditada);

                    existeSerieEditada = true;
                }
               
            }
                // Mostra mensagem de erro caso não tenha sido possível a edição.
            if (existeSerieEditada == false)
            {
                MessageBox.Show("Não foi possível editar essa série.");
            }
                //Grava no arquivo txt com a edição.
            BibliotecaDeSubRotinas.EscreverSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);

            if (existeSerieEditada == true)
            {
                MessageBox.Show("Série editada com sucesso.");
            }

                //Limpa todos os campos.
            txtCodigoMostrarSerieParaEditar.Clear();
            txtNomeSerie.Clear();
            txtTemporadaAtual.Clear();
            txtUltimoEpisodioAssistido.Clear();
            txtTotalDeTemporadas.Clear();
            txtCategoriaDaSerie.Clear();

                //Ajusta os botões.
            btnSalvarSerie.Enabled = false;
            btnExcluirSerie.Enabled = false;
            btnAdicionarSerie.Enabled = true;
            btnMostrarSerieParaEditar.Enabled = true;

        }

        private void BtnExcluirSerie_Click(object sender, EventArgs e)
        {

            //Remove a categoria do ArrayList.
            bool existeSerieExcluida = false;
            for (int i = 0; i < nomeSerie.Count; i++)
            {
                if (txtCodigoMostrarSerieParaEditar.Text == Convert.ToString(codigoSerie[i]))
                {
                    codigoSerie.RemoveAt(i);
                    nomeSerie.RemoveAt(i);
                    temporadaAtual.RemoveAt(i);
                    ultimoEpisodioAssistido.RemoveAt(i);
                    totalDeTemporadas.RemoveAt(i);
                    categoriaDaSerie.RemoveAt(i);

                    existeSerieExcluida = true;
                }
            }
            //Mostra mensagem de erro caso não tenha sido possível a exclusão.
            if (existeSerieExcluida == false)
            {
                MessageBox.Show("Não foi possível excluir essa série.");
                return;
            }

            /*Remove todos os códigos, linha por linha, e os renumera um a um.
            int contador = 1;
            for (int i = 0; i < codigoCategoria.Count; i++)
            {
                codigoCategoria.RemoveAt(i);
                if (contador >= 1 && contador < 10)
                {
                    codigoCategoria.Insert(i, "00" + contador);
                }
                else if (contador >= 10 && contador < 100)
                {
                    codigoCategoria.Insert(i, "0" + contador);
                }
                else
                {
                    codigoCategoria.Insert(i, contador);
                }

                contador++;
            } */

                //Grava no arquivo txt com a exclusão da série.
            BibliotecaDeSubRotinas.EscreverSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);

            if (existeSerieExcluida == true)
            {
                MessageBox.Show("Série excluída com sucesso.");
            }

            //Limpa todos os campos.
            txtCodigoMostrarSerieParaEditar.Clear();
            txtNomeSerie.Clear();
            txtTemporadaAtual.Clear();
            txtUltimoEpisodioAssistido.Clear();
            txtTotalDeTemporadas.Clear();
            txtCategoriaDaSerie.Clear();

            //Ajusta os botões.
            btnSalvarSerie.Enabled = false;
            btnExcluirSerie.Enabled = false;
            btnAdicionarSerie.Enabled = true;
            btnMostrarSerieParaEditar.Enabled = true;

        }

        private void BtnLimparCamposSerie_Click(object sender, EventArgs e)
        {
            txtNomeSerie.Text = "";
            txtTemporadaAtual.Text = "";
            txtUltimoEpisodioAssistido.Text = "";
            txtTotalDeTemporadas.Text = "";
            txtCategoriaDaSerie.Text = "";

        }

        private void BtnLimparCodigoMostrarSerie_Click(object sender, EventArgs e)
        {
            //Limpa todos os campos.
            txtCodigoMostrarSerieParaEditar.Clear();
            txtNomeSerie.Clear();
            txtTemporadaAtual.Clear();
            txtUltimoEpisodioAssistido.Clear();
            txtTotalDeTemporadas.Clear();
            txtCategoriaDaSerie.Clear();

            //Ajusta os botões.
            btnSalvarSerie.Enabled = false;
            btnExcluirSerie.Enabled = false;
            btnAdicionarSerie.Enabled = true;
            btnMostrarSerieParaEditar.Enabled = true;
        }

    }
}



