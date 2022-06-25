using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace emlak_kayıt_programı
{
    public partial class GAYRİMENKUL_KAYIT : Form
    {
        public GAYRİMENKUL_KAYIT()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=zelal-cennet21;Initial Catalog=stajproje;Integrated Security=True");

        private void grntle()
        {//kendi yordamımızı yaptık//
            listView1.Items.Clear();//tablo da veri tekrarının olmaması icin siler//
            bagla.Open();
            //hangi tabloya bağlayacağımızı sağlayan kod//
            //kitap tablo adı//
            SqlCommand komut = new SqlCommand("select*from emlak", bagla);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                listView1.Items.Add(ekle);
            }
            bagla.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "papatya sitesi")
            {
                buttonzambak.BackColor = Color.Gray;
                buttongül.BackColor = Color.Gray;
                buttonmenekşe.BackColor = Color.Gray;
                buttonpapatya.BackColor = Color.Yellow;
            }
            if (comboBox1.Text == "zambak sitesi")
            {
                buttonzambak.BackColor = Color.Yellow;
                buttongül.BackColor = Color.Gray;
                buttonmenekşe.BackColor = Color.Gray;
                buttonpapatya.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "gül sitesi")
            {
                buttonzambak.BackColor = Color.Gray;
                buttongül.BackColor = Color.Yellow;
                buttonmenekşe.BackColor = Color.Gray;
                buttonpapatya.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "menekşe sitesi")
            {
                buttonzambak.BackColor = Color.Gray;
                buttongül.BackColor = Color.Gray;
                buttonmenekşe.BackColor = Color.Yellow;
                buttonpapatya.BackColor = Color.Gray;
            }
        }

        private void buttongrntle_Click(object sender, EventArgs e)
        {
            grntle();
            
        }

        private void buttonkydet_Click(object sender, EventArgs e)
        {
           
            bagla.Open();
            
            SqlCommand komut = new SqlCommand("Insert into emlak (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira)VALUES('"+ textBox7.Text.ToString()+"','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','"+textBox2.Text.ToString()+"','"+comboBox4.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+textBox6.Text.ToString()+"','"+comboBox2.Text.ToString()+"')", bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void buttondzelt_Click(object sender, EventArgs e)
        {
            //günçelememizi yani kayitli olan veriler üzerinde değişiklik yapmamızı sağlar//
            bagla.Open();
             SqlCommand komut = new SqlCommand("Update emlak set id='" + textBox7.Text.ToString() + "',site='" + comboBox1.Text.ToString() + "',oda='" + comboBox3.Text.ToString() + "', metre= '" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',no='" + textBox3.Text.ToString() + "',adsoyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() + "',notlar='" + textBox6.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "'where id=" + id + "", bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();
        }
        int id = 0;
        private void buttonsil_Click(object sender, EventArgs e)
        {
            bagla.Open();
            SqlCommand komut = new SqlCommand("Delete from emlak where id=(" + id+ ")", bagla);
            komut.ExecuteNonQuery();
            bagla.Close();
            grntle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
           
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GAYRİMENKUL_KAYIT fr = new GAYRİMENKUL_KAYIT();
            fr.Show();
            this.Hide();
            
        }
    }
}
