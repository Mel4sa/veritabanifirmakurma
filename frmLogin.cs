using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            //ekrandan gelen password değerini alıyoruz
            var password = txtPassword.Text;
            //şifre girilmediyse uyarı atıyor
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Şifre giriniz", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //ekrandan gelen username değerini alıyoruz
            var username = txtUsername.Text;
            //kullanıcı adı girilmediyse uyarı atıyor
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Kullanıcı adı giriniz", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //database bağlantısı oluşturuluyor
            using var sqlConnection = SQLHelper.GetSqlConnection();
            using var sqlCommand = sqlConnection.CreateCommand();

            //sql komutu ve parametreleri belirleniyor
            sqlCommand.CommandText = "SELECT * FROM Login WHERE Username = @Username";
            sqlCommand.Parameters.AddWithValue("@Username", username);

            //database bağlantısı açıldı
            await sqlConnection.OpenAsync();

            //komut çalıştırıldı, reader nesnesine sonuç dolduruldu
            using var reader = await sqlCommand.ExecuteReaderAsync();
            try
            {
                while (await reader.ReadAsync())
                {
                    //ekrandan girilen şifre ve reader içerisindeki şifre datası kontrol edildi
                    if (!string.IsNullOrEmpty(reader["Password"].ToString()) && reader["Password"].ToString() == password)
                    {
                        //şifre doğruysa giriş başarılı mesajıyle birlikte login ekranı kapatıldı
                        MessageBox.Show("Giriş başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        //şifre hatalıysa hata mesajı verildi
                        MessageBox.Show("Giriş başarısız", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                //işlemlerin sonucunda sql bağlantısı kapatıldı
                await sqlConnection.CloseAsync();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
