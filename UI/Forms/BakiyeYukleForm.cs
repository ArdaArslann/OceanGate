using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using oceangate_r.Core;
using oceangate_r.DAL;

namespace oceangate_r.UI.Forms
{
    public partial class BakiyeYukleForm : Form
    {
        public BakiyeYukleForm()
        {
            InitializeComponent();
            
            // Allow only digits for card number (max 16)
            _txtKartNo.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
            
            // Allow only digits and slash for SKT (e.g., 12/2026)
            _txtSKT.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/') e.Handled = true;
            };
            
            // Allow only digits for CVC (max 3)
            _txtCVC.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
            
            // Allow only digits for Amount
            _txtMiktar.KeyPress += (s, e) => {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };
        }

        private void btnYatir_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(_txtAdSoyad.Text) || 
                string.IsNullOrWhiteSpace(_txtKartNo.Text) || 
                string.IsNullOrWhiteSpace(_txtSKT.Text) || 
                string.IsNullOrWhiteSpace(_txtCVC.Text) || 
                string.IsNullOrWhiteSpace(_txtMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_txtKartNo.Text.Length != 16)
            {
                MessageBox.Show("Kredi kartı numarası 16 haneli olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(_txtSKT.Text, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                MessageBox.Show("Son Kullanma Tarihi AA/YY formatında olmalıdır (örn: 12/26).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_txtCVC.Text.Length != 3)
            {
                MessageBox.Show("CVC kodu 3 haneli olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(_txtMiktar.Text, out double miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir bakiye miktarı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Miktarı yükle
            try
            {
                KullaniciDAL.BakiyeYukle(SessionManager.AktifKullanici.Id, miktar);
                MessageBox.Show($"İşlem onaylandı. Hesabınıza {miktar:N0} TL yatırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bakiye yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _txtCVC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

