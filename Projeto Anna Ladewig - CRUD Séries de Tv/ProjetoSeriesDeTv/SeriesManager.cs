using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoSeriesDeTv
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RemoverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void NovaSérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasSeries frmGerenciamentoDasSeries = new frmGerenciamentoDasSeries();
            frmGerenciamentoDasSeries.ShowDialog();
        }

        private void SérieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasSeries frmGerenciamentoDasSeries = new frmGerenciamentoDasSeries();
            frmGerenciamentoDasSeries.ShowDialog();
        }

        private void SériesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMinhasSeriesFavoritas frmMinhasSeriesFavoritas = new frmMinhasSeriesFavoritas();
            frmMinhasSeriesFavoritas.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
    
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasCategorias frmGerenciamentoDasCategorias = new frmGerenciamentoDasCategorias();
            frmGerenciamentoDasCategorias.ShowDialog();
        }

        private void SérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasSeries frmGerenciamentoDasSeries = new frmGerenciamentoDasSeries();
            frmGerenciamentoDasSeries.ShowDialog();
        }

        private void CategoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasCategorias frmGerenciamentoDasCategorias = new frmGerenciamentoDasCategorias();
            frmGerenciamentoDasCategorias.ShowDialog();
        }

        private void NovaCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerenciamentoDasCategorias frmGerenciamentoDasCategorias = new frmGerenciamentoDasCategorias();
            frmGerenciamentoDasCategorias.ShowDialog();
        }

        private void CategoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMinhasCategorias frmMinhasCategorias = new frmMinhasCategorias();
            frmMinhasCategorias.ShowDialog(); 

            
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
