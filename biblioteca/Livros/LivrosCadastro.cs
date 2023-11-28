using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace biblioteca
{
    public partial class LivrosCadastro : Form
    {
        public LivrosCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Algum campo está vazio!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                

            }
            else
            {

                string nome = textBox1.Text;
                string editora = textBox2.Text;
                string autor = textBox3.Text;
                string anoPublic = textBox4.Text;
              


                MySqlConnection conexao = new MySqlConnection();

                conexao.ConnectionString = ("SERVER = 127.0.0.1; DATABASE = bibliotecapedro; UID = root; PASSWORD = ;");

                conexao.Open();
                string inserir = "INSERT INTO livros VALUES (null, '" + nome + "','" + editora + "' ,'" + autor + "' ,'" + anoPublic + "');";

                MySqlCommand comandos = new MySqlCommand(inserir, conexao);

                comandos.ExecuteNonQuery();

                conexao.Close();
                MessageBox.Show("Livro cadastrado com sucesso");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
              
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
