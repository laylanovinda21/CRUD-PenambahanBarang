using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CRUDBarang
{
    public partial class Form1 : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\source\repos\CRUDBarang\CRUDBarang\BetaMart.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        void ShowData()
        {
            koneksi.Open();
            string query = "select * from Barang";
            OleDbDataAdapter data = new OleDbDataAdapter(query, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "DELETE FROM Barang WHERE ID = " + ID.Text;
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Terhapus");
            ShowData();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betaMartDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter1.Fill(this.betaMartDataSet.Barang);
            // TODO: This line of code loads data into the 'mydbDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.mydbDataSet.Barang);

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        void ClearText()
        {
            ID.Clear();
            Kode.Clear();
            Nama.Clear();
            Harga.Clear();
            Stok.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            OleDbCommand cmd = new OleDbCommand("UPDATE Barang SET nama = '" + Kode.Text + "', kode = '" + Nama.Text + "', harga = '" + Harga.Text + "', stok = '" + Stok.Text + "' where ID=" + ID.Text + " ", koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Diupdate");

            ShowData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "Insert into Barang (Kode, Nama, Harga, Stok) values ('" + Kode.Text + "', '" + Nama.Text + "', '" + Harga.Text + "', '" + Stok.Text + "')";
            OleDbCommand cmd = new OleDbCommand(perintah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Tersimpan");

            ShowData();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string perintah = "select * from Barang where Nama='" + Search.Text + "'";
            OleDbDataAdapter data = new OleDbDataAdapter(perintah, koneksi);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
