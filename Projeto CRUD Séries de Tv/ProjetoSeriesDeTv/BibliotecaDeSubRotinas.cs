using System;
using System.Collections; //Biblioteca referente aos métodos ArrayList
using System.IO; //Biblioteca para Ler e Escrever em Arquivos Txt.
using System.Windows.Forms;

namespace ProjetoSeriesDeTv
{
    class BibliotecaDeSubRotinas
    {
        public static void LerCategoriasNoTxt(ArrayList identificador, ArrayList nome)
        {
           if (File.Exists(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\categorias.txt"))
            {
                Stream entrada = File.Open(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\categorias.txt", FileMode.Open);
                //string entrada = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\categorias.txt";
                 
             StreamReader leitor = new StreamReader(entrada);
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    string[] parteDaLinha = new string[2];
                    parteDaLinha = linha.Split(';');
                    identificador.Add(parteDaLinha[0]);
                    nome.Add(parteDaLinha[1]);

                    linha = leitor.ReadLine();
                }
                leitor.Close();
                entrada.Close();
            }
        }
        public static void LerSeriesNoTxt(ArrayList identificador, ArrayList nome, ArrayList ultimaTemp, ArrayList ultimoEpisodio, ArrayList totTemp, ArrayList classificacao)
        {
            
            if (File.Exists(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\series.txt"))
            {
                Stream entrada = File.Open(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\series.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    string[] parteDaLinha = new string[6];
                    parteDaLinha = linha.Split(';');
 
                    identificador.Add(parteDaLinha[0]);
                    nome.Add(parteDaLinha[1]);
                    ultimaTemp.Add(parteDaLinha[2]);
                    ultimoEpisodio.Add(parteDaLinha[3]);
                    totTemp.Add(parteDaLinha[4]);
                    classificacao.Add(parteDaLinha[5]);
       
                    linha = leitor.ReadLine();

                }
                leitor.Close();
                entrada.Close();
            }
        }

        public static void EscreverCategoriasNoTxt(ArrayList identificador, ArrayList nome)
        {
            Stream saida = File.Open(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\categorias.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);
            for (int i = 0; i < identificador.Count; i++)
            {
                escritor.WriteLine(identificador[i] + ";" + nome[i]);
            }
            escritor.Close();
            saida.Close();

        }

        public static void EscreverSeriesNoTxt(ArrayList identificador, ArrayList nome, ArrayList ultimaTemp, ArrayList ultimoEpisodio, ArrayList totTemp, ArrayList classificacao)
        {
            Stream saida = File.Open(@"C:\Users\DELL\OneDrive\Anninha\Análise e Desenvolvimento de Sistemas\IBRATEC\1º Período\Lógica de Programação\Visual Studio\2ºUnidade\Projeto\ProjetoSeriesDeTv\series.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(saida);
            for (int i = 0; i < identificador.Count; i++)
            {
                escritor.WriteLine(identificador[i] + ";" + nome[i] + ";" + ultimaTemp[i] + ";" + ultimoEpisodio[i] + ";" + totTemp[i] + ";" + classificacao[i]);
            }
            escritor.Close();
            saida.Close();
        }

        public static bool CríticaApenasLetras(string campoAnalisado)
        {
            string nomeMaiusculo = campoAnalisado.ToUpper();
            bool vaiTerMsgDeErro = false;
            for (int i = 0; i < campoAnalisado.Length; i++)
            {
                if (String.Compare(nomeMaiusculo.Substring(i, 1), "A") == -1 || String.Compare(nomeMaiusculo
                    .Substring(i, 1), "Z") > 0)
                {
                    vaiTerMsgDeErro = true;
                    break;
                }
                else
                {
                    vaiTerMsgDeErro = false;   
                }
            }
            return vaiTerMsgDeErro;
        }

        public static bool CríticaApenasNumeros(string campoAnalisado)
        {
            bool vaiTerMsgDeErro = false;
            for (int i = 0; i < campoAnalisado.Length; i++)
            {
                if (String.Compare(campoAnalisado.Substring(i, 1), "0") == -1 || String.Compare(campoAnalisado.Substring(i, 1), "9") == 1)
                {
                    vaiTerMsgDeErro = true;
                    break;
                }
                else
                {
                    vaiTerMsgDeErro = false;
                }
            }
            return vaiTerMsgDeErro;
        }

    }
}
