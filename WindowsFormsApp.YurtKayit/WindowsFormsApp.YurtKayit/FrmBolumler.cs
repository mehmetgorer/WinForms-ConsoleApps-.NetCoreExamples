﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace WindowsFormsApp.YurtKayit
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try 
            { 
            
            SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtBolumAd.Text);
            komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
            }
            catch 
            {
                MessageBox.Show("Hata! Tekrar deneyin!");
            }

        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try 
            { 
            
            SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtBolumId.Text);
            komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti!");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch(Exception)
            {
                MessageBox.Show("Hata! İşlem gerçekleşmedi");
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            txtBolumId.Text = id;
            txtBolumAd.Text = bolumad;
        }

        private void pcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut2 = new SqlCommand("update Bolumler Set Bolumad =@p1 where Bolumid=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p2", txtBolumId.Text);
                komut2.Parameters.AddWithValue("@p1", txtBolumAd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch 
            {
                MessageBox.Show("Hata");
            }


        }
    }
}
