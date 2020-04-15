using System;
using System.Collections; //Para poder usar os ArryLists.
using System.Windows.Forms;

namespace ProjetoSeriesDeTv
{
    public partial class frmGerenciamentoDasCategorias : Form
    {
        //ArrayLists Categorias
        public ArrayList codigoCategoria = new ArrayList();
        public ArrayList nomeCategoria = new ArrayList();

        //ArrayListas Séries (vão servir para quando eu for ler o arquivo txt de séries para ver se existe série cadastrada com aquela categoria.
        public ArrayList codigoSerie = new ArrayList();
        public ArrayList nomeSerie = new ArrayList();
        public ArrayList temporadaAtual = new ArrayList();
        public ArrayList ultimoEpisodioAssistido = new ArrayList();
        public ArrayList totalDeTemporadas = new ArrayList();
        public ArrayList categoriaDaSerie = new ArrayList();

        public frmGerenciamentoDasCategorias()
        {
            InitializeComponent();
        }
    
        private void FrmGerenciamentoDasCategorias_Load(object sender, EventArgs e)
        {
            btnSalvarCategoria.Enabled = false;
            btnExcluirCategoria.Enabled = false;
        }

        private void BtnAdicionarCategoria_Click(object sender, EventArgs e)
        {       //Limpa todos os ArrayLists antes de começar.
            codigoCategoria.Clear(); nomeCategoria.Clear();

                //Carrega as informações do arquivo txt.
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);

                //Crítica não pode ter campo em branco.
            if (txtNomeCategoria.Text == "")
            {
                MessageBox.Show("Digite um nome para sua categoria.");
                return;
            }

                //Crítica para aceitar somente letras.
            if (BibliotecaDeSubRotinas.CríticaApenasLetras(txtNomeCategoria.Text) == true)
            {
                MessageBox.Show("Por favor, digite apenas letras.");
                txtCodigoCategoria.Focus();
                return;
            }
             
                //Consulta se já existe o cadastro dessa categoria.
            int contador = 1;
            bool jaExiste = false;
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                if (txtNomeCategoria.Text.ToUpper() == Convert.ToString(nomeCategoria[i]).ToUpper())
                {
                    jaExiste = true;
                    MessageBox.Show("Essa categoria já existe.");
                    txtNomeCategoria.Clear();
                    return;
                }
                contador = contador + 1;
            }
            
                //Se for confirmado que a categoria não existe.
            if (jaExiste == false)
            {
                //Adiciona no ArrayList a nova categoria.
                nomeCategoria.Add(txtNomeCategoria.Text);

                //Adiciona no ArrayList um código para a nova categoria e os zeros na frente, se necessário.
                if (contador >= 1 && contador < 10)
                {
                codigoCategoria.Add("00" + contador);
                }
                else if (contador >= 10 && contador < 100)
                {
                codigoCategoria.Add("0" + contador);
                }
                else
                {
                codigoCategoria.Add(contador);
                }

                //Adiciona a nova categoria no arquivo texto.
                BibliotecaDeSubRotinas.EscreverCategoriasNoTxt(codigoCategoria, nomeCategoria);
 
                MessageBox.Show("Categoria adicionada com sucesso.");
                
            }

               //Apaga o formulário
            txtCodigoParaEditarCategoria.Clear();
            txtCodigoCategoria.Clear();
            txtNomeCategoria.Clear();
        }

        private void BtnMostrarCategoriaParaEditar_Click(object sender, EventArgs e)
        {
            btnSalvarCategoria.Enabled = true;
            btnExcluirCategoria.Enabled = true;
            btnAdicionarCategoria.Enabled = false;

                //Limpa todos os ArrayLists antes de começar.
            codigoCategoria.Clear(); nomeCategoria.Clear();

                //Carrega as informações do arquivo txt.
            BibliotecaDeSubRotinas.LerCategoriasNoTxt(codigoCategoria, nomeCategoria);

                //Crítica não pode ter campo em branco.
            if (txtCodigoParaEditarCategoria.Text == "")
            {
                MessageBox.Show("Campo Vazio. Digite o código desejado.");
                txtCodigoParaEditarCategoria.Focus();
                return;
            }

                //Crítica para aceitar somente números.
            if (BibliotecaDeSubRotinas.CríticaApenasNumeros(txtCodigoParaEditarCategoria.Text) == true)
            {
                MessageBox.Show("O código contém apenas números.");
                txtCodigoParaEditarCategoria.Focus();
                return;
            }

                // Procura se o código digitado existe no ArrayList e mostra o código e o nome da categoria na área para edição ou exclusão.
            bool existeCodigo = false;
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                if (txtCodigoParaEditarCategoria.Text == Convert.ToString(codigoCategoria[i]))
                {
                    string codigocategoriaSelecionada = Convert.ToString(codigoCategoria[i]);
                    txtCodigoCategoria.Text = codigocategoriaSelecionada;

                    string categoriaSelecionada = Convert.ToString(nomeCategoria[i]);
                    txtNomeCategoria.Text = categoriaSelecionada;

                    existeCodigo = true;
                }
            }
                // Mostra mensagem de erro caso não exista o código informado.
            if (existeCodigo == false)
            {
                MessageBox.Show("Código informado não existe.");
            }
        }

        private void BtnSalvarCategoria_Click(object sender, EventArgs e)
        {
                //Crítica não pode ter campo em branco.
            if (txtNomeCategoria.Text == "")
            {
                MessageBox.Show("Campo Vazio. Por favor, digite o novo nome de sua categoria.");
                return;
            }

                //Crítica para aceitar somente letras.
            if (BibliotecaDeSubRotinas.CríticaApenasLetras(txtNomeCategoria.Text) == true)
            {
                MessageBox.Show("Por favor, digite apenas letras.");
                txtCodigoCategoria.Focus();
                return;
            }

                //Remove o nome da categoria do ArrayList e adiciona o nome editado em seu lugar.
            bool existeCategoriaEditada = false;
            string categoriaSelecionada = "";
            string categoriaEditada = txtNomeCategoria.Text;
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                if (txtCodigoParaEditarCategoria.Text == Convert.ToString(codigoCategoria[i]))
                {
                    categoriaSelecionada = Convert.ToString(nomeCategoria[i]);

                        //Não vai poder mudar o código, apenas o nome.
                    nomeCategoria.RemoveAt(i);
                    nomeCategoria.Insert(i, categoriaEditada);

                    existeCategoriaEditada = true;
                }
            }

                // Mostra mensagem de erro caso não tenha sido possível a edição.
            if (existeCategoriaEditada == false)
            {
                MessageBox.Show("Não foi possível editar essa categoria.");
            }

               //Grava no arquivo txt com a edição.
            BibliotecaDeSubRotinas.EscreverCategoriasNoTxt(codigoCategoria, nomeCategoria);

                //Faz a alteração da edição da categoria no arquivo texto das séries cadastradas com essa categoria.
                //Precisa ler antes o arquivo texto para carregar o ArrayList das categorias das séries e depois escrever no arquivo texto, pra salvar a alteração.
            BibliotecaDeSubRotinas.LerSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);
            for (int i=0; i < categoriaDaSerie.Count; i++)
            {
                if(Convert.ToString(categoriaDaSerie[i]) == categoriaSelecionada)
                {
                    categoriaDaSerie.RemoveAt(i);
                    categoriaDaSerie.Insert(i, categoriaEditada);
                }
            }
            BibliotecaDeSubRotinas.EscreverSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);

            if (existeCategoriaEditada == true)
            {
                MessageBox.Show("Categoria editada com sucesso.");
            }

                //Apaga o formulário
            txtCodigoParaEditarCategoria.Clear();
            txtCodigoCategoria.Clear();
            txtNomeCategoria.Clear();
        }

         private void BtnExcluirCategoria_Click(object sender, EventArgs e)
        {
                //Procura se aquela categoria que você deseja excluir possui série cadastrada. Se possuir, não pode excluir.
                //Precisa ler antes o arquivo texto para carregar o ArrayList das categorias das séries.
            BibliotecaDeSubRotinas.LerSeriesNoTxt(codigoSerie, nomeSerie, temporadaAtual, ultimoEpisodioAssistido, totalDeTemporadas, categoriaDaSerie);
            for (int i=0; i < categoriaDaSerie.Count; i++)
            { 
                if( txtNomeCategoria.Text == Convert.ToString(categoriaDaSerie[i]))
                {
                    MessageBox.Show("Essa categoria possui séries cadastradas e não pode ser excluída.");
                    txtCodigoParaEditarCategoria.Clear();
                    txtCodigoCategoria.Clear();
                    txtNomeCategoria.Clear();
                    return;
                }
            }

                //Remove a categoria do ArrayList.
            bool existeCategoriaExcluida = false;
            for (int i = 0; i < nomeCategoria.Count; i++)
            {
                if (txtCodigoCategoria.Text == Convert.ToString(codigoCategoria[i]))
                {
                    codigoCategoria.RemoveAt(i);
                    nomeCategoria.RemoveAt(i);

                    existeCategoriaExcluida = true;
                }
            }
                //Mostra mensagem de erro caso não tenha sido possível a exclusão.
            if (existeCategoriaExcluida == false)
            {
                MessageBox.Show("Não foi possível excluir essa categoria.");
            }

            /* Caso quisesse renumerar todos os códigos.
               Código para remover todos os códigos, linha por linha, e os renumera um a um:
            int contador = 1;
            for (int i = 0; i < codigoCategoria.Count; i++)
            {
                codigoCategoria.RemoveAt(i);
                if (contador >= 1 && contador < 10)
                {
                    codigoCategoria.Insert(i,"00" + contador);
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

               //Grava no arquivo txt com a exclusão da categoria.
            BibliotecaDeSubRotinas.EscreverCategoriasNoTxt(codigoCategoria, nomeCategoria);

            if (existeCategoriaExcluida == true)
            {
                MessageBox.Show("Categoria excluída com sucesso.");
            }

                //Apaga o formulário
            txtCodigoParaEditarCategoria.Clear();
            txtCodigoCategoria.Clear();
            txtNomeCategoria.Clear();

        }

        private void BtnLimparMostrarCategoria_Click(object sender, EventArgs e)
        {
            txtCodigoParaEditarCategoria.Clear();
            txtCodigoCategoria.Clear();
            txtNomeCategoria.Clear();
        }
    }  
}

