using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
            toolStripTextBox2.Text = "";
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LivrosCadastro cadlivro = new LivrosCadastro();
            cadlivro.Show();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox1.Text);
            Livros.LivrosAlterar alterlivros = new Livros.LivrosAlterar(cod);
            alterlivros.Show();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Livros.LivrosVisualizar visulivros = new Livros.LivrosVisualizar();
            visulivros.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox2.Text);
            Livros.LivrosExcluir exclulivros = new Livros.LivrosExcluir(cod);
            exclulivros.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CLientes.ClientesCadastrar cadcliente = new CLientes.ClientesCadastrar();
            cadcliente.Show();
        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox3.Text);
            CLientes.ClientesAlterar alteracliente = new CLientes.ClientesAlterar(cod);
            alteracliente.Show();
        }

        private void vizualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLientes.ClientesVisualizar visucliente = new CLientes.ClientesVisualizar();
            visucliente.Show();
        }

        private void excluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox4.Text);
            CLientes.ClientesExcluir exclucliente = new CLientes.ClientesExcluir(cod);
            exclucliente.Show();
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Locação.LocacaoCadastrar cadloca = new Locação.LocacaoCadastrar();
            cadloca.Show();
        }

        private void alterarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox5.Text);
            Locação.LocacaoAlterar alteraloca = new Locação.LocacaoAlterar(cod);
            alteraloca.Show();
        }

        private void vizualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Locação.LocacaoVisualizar_ visuloca = new Locação.LocacaoVisualizar_();
            visuloca.Show();
        }

        private void excluirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(toolStripTextBox6.Text);
            Locação.LocacaoExcluir excluloca = new Locação.LocacaoExcluir(cod);
            excluloca.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox3.Text = "";
            toolStripTextBox4.Text = "";
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox5.Text = "";
            toolStripTextBox6.Text = "";
        }
    }
}
