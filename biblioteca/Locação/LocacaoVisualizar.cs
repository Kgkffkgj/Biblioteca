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
    public partial class LocacaoVisualizar_ : Form
    {
        public LocacaoVisualizar_()
        {
            InitializeComponent();
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();

            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT locacao.idlocacao AS 'locacao',livros.nome AS 'nomelivro', clientes.nomecliente AS 'nomecliente' FROM locacao INNER JOIN livros ON locacao.idlivro = livros.idlivro INNER JOIN clientes ON locacao.idcliente = clientes.idclientes;";




            dataGridView1.Rows.Clear();
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    dataGridView1.Rows.Add(Resultado["locacao"].ToString(),
                                            Resultado["nomelivro"].ToString(),
                                            Resultado["nomecliente"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        private void button1_Click(object sender, EventArgs e)
        {
            string campo = comboBox1.Text;

            if (campo == "clientes")
            {
                MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=bibliotecapedro; UID=root; PASSWORD=; ");
                conectar.Open();
                MySqlCommand Consulta = new MySqlCommand();
                Consulta.Connection = conectar;

                Consulta.CommandText = " SELECT livros.nome as 'livros', clientes.nomecliente as 'cliente', locacao.idlocacao as 'locacao' FROM locacao INNER JOIN clientes ON clientes.idclientes = locacao.idcliente INNER JOIN livros ON locacao.idlivro = livros.idlivro  WHERE  clientes.nomecliente LIKE '%" + textBox1.Text + "%';";
                dataGridView1.Rows.Clear();


                MySqlDataReader Resultado = Consulta.ExecuteReader();
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        dataGridView1.Rows.Add(Resultado["locacao"].ToString(),
                                  Resultado["livros"].ToString(),
                                   Resultado["cliente"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum registro foi encontrado");
                }
                conectar.Close();
            }
            else if (campo == "livro")
            {
                MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=bibliotecapedro; UID=root; PASSWORD=; ");
                conectar.Open();
                MySqlCommand Consulta = new MySqlCommand();
                Consulta.Connection = conectar;

                Consulta.CommandText = " SELECT livros.nome as 'livro', clientes.nomecliente as 'clientes', locacao.idlocacao as 'locacao' FROM locacao INNER JOIN clientes ON clientes.idclientes = locacao.idcliente INNER JOIN livros ON locacao.idlivro = livros.idlivro  WHERE  livros.nome LIKE '%" + textBox1.Text + "%';";
                dataGridView1.Rows.Clear();


                MySqlDataReader Resultado = Consulta.ExecuteReader();
                if (Resultado.HasRows)
                {
                    while (Resultado.Read())
                    {
                        dataGridView1.Rows.Add(Resultado["locacao"].ToString(),
                                  Resultado["livro"].ToString(),
                                   Resultado["clientes"].ToString());
                    }
                }
                     else
                    {
                        MessageBox.Show("Nenhum registro foi encontrado");
                    }
                    conectar.Close();
            }
                else if (campo == "idlocacao")
                {
                    MySqlConnection conectar = new MySqlConnection("SERVER=localhost; DATABASE=bibliotecapedro; UID=root; PASSWORD=; ");
                    conectar.Open();
                    MySqlCommand Consulta = new MySqlCommand();
                    Consulta.Connection = conectar;

                    Consulta.CommandText = " SELECT livros.nome as 'livros', clientes.nomecliente as 'clientes', locacao.idlocacao as 'locacao' FROM locacao INNER JOIN clientes ON clientes.idclientes = locacao.idcliente INNER JOIN livros ON locacao.idlivro = livros.idlivro  WHERE  locacao.idlocacao LIKE '%" + textBox1.Text + "%';";
                    dataGridView1.Rows.Clear();


                    MySqlDataReader Resultado = Consulta.ExecuteReader();
                    if (Resultado.HasRows)
                    {
                        while (Resultado.Read())
                        {
                            dataGridView1.Rows.Add(Resultado["locacao"].ToString(),
                                      Resultado["livros"].ToString(),
                                       Resultado["clientes"].ToString());
                        }
                    }
                }
                    else
                    {
                        MessageBox.Show("Nenhum registro foi encontrado");
                    }

                  
             textBox1.Text = "";
                comboBox1.Text = "";

        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                //
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //
                XcelApp.Columns.AutoFit();
                //
                XcelApp.Visible = true;
            }
        }
    }
}
