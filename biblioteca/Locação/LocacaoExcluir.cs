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
    public partial class LocacaoExcluir : Form
    {
        public LocacaoExcluir(int cod)
        {
            InitializeComponent();
            textBox8.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT * FROM locacao where idlocacao = " + cod + ";";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    textBox8.Text = Resultado["idlocacao"].ToString();
                    textBox1.Text = Resultado["idlivro"].ToString();
                    textBox2.Text = Resultado["idcliente"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }

        private void LocacaoExcluir_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(textBox8.Text);
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "Delete FROM locacao WHERE idlocacao = '" + cod + "';";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {

                    textBox1.Text = Resultado["idlivro"].ToString();
                    textBox2.Text = Resultado["idcliente"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Deletado");
            }
            conectar.Close();
        }
    }
}
