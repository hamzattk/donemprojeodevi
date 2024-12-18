using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace donemprojeodevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



  // OpenFileDialog nesnesi oluştur
    OpenFileDialog openFileDialog = new OpenFileDialog();

    // Yalnızca resim dosyalarını göster
    openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

    // Kullanıcının bir dosya seçmesini bekle
    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        // Seçilen dosyayı PictureBox'a yükle
        pictureBox1.ImageLocation = openFileDialog.FileName;
    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen önce bir resim seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // OpenFileDialog ile resim kaydetme yeri sor
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // ComboBox'tan seçilen formatı al
            string selectedFormat = comboBox1.SelectedItem.ToString();

            // Dosya filtrelerini ayarla
            switch (selectedFormat)
            {
                case "JPG":
                case "JPEG":
                    saveFileDialog.Filter = "JPEG Dosyaları|*.jpg;*.jpeg";
                    break;
                case "PNG":
                    saveFileDialog.Filter = "PNG Dosyaları|*.png";
                    break;
                case "BMP":
                    saveFileDialog.Filter = "BMP Dosyaları|*.bmp";
                    break;
                case "GIF":
                    saveFileDialog.Filter = "GIF Dosyaları|*.gif";
                    break;
                case "TIFF":
                    saveFileDialog.Filter = "TIFF Dosyaları|*.tiff";
                    break;
                default:
                    MessageBox.Show("Geçersiz format seçildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Kullanıcı kaydetme yeri seçerse
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat format = null;

                // Seçilen formata uygun ImageFormat belirle
                switch (selectedFormat)
                {
                    case "JPG":
                    case "JPEG":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case "PNG":
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case "BMP":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case "GIF":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case "TIFF":
                        format = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                }

                // Resmi seçilen formata dönüştürüp kaydet
                pictureBox1.Image.Save(saveFileDialog.FileName, format);
                MessageBox.Show("Resim başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ComboBox'a formatları ekle
            comboBox1.Items.Add("JPG");
            comboBox1.Items.Add("JPEG");
            comboBox1.Items.Add("PNG");
            comboBox1.Items.Add("BMP");
            comboBox1.Items.Add("GIF");
            comboBox1.Items.Add("TIFF");
            comboBox1.SelectedIndex = 0; // Va
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}
