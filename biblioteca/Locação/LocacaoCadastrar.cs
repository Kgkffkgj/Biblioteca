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

namespace biblioteca.Locação
{
    public partial class LocacaoCadastrar : Form
    {
        public LocacaoCadastrar()
        {
            InitializeComponent();
            textBox8.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Algum campo está vazio!!");
                textBox1.Text = "";
                textBox2.Text = "";



            }
            else
            {

                string idlivro = textBox1.Text;
                string idcliente = textBox2.Text;



                MySqlConnection conexao = new MySqlConnection();

                conexao.ConnectionString = ("SERVER = 127.0.0.1; DATABASE = bibliotecapedro; UID = root; PASSWORD = ;");

                conexao.Open();
                string inserir = "INSERT INTO locacao VALUES (null, '" + idlivro + "','" + idcliente + "');";

                MySqlCommand comandos = new MySqlCommand(inserir, conexao);

                comandos.ExecuteNonQuery();

                conexao.Close();
                MessageBox.Show("Locação cadastrada com sucesso");

                textBox1.Text = "";
                textBox2.Text = "";

            }
        }
    }
}
