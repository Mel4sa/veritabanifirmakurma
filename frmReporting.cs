using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class frmReporting : Form
    {
        public frmReporting()
        {
            InitializeComponent();
            var loginPage = new frmLogin();
            loginPage.ShowDialog();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            var query = txtQuery.Text;
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Herhangi bir komut girilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await FillDataGrid(query);
        }

        private async Task FillDataGrid(string query)
        {
            //griddeki mevcut datanın silinmesi için datasource null olarak set edildi
            grdData.DataSource = null;

            //sql bağlantıları ayarlandı
            using var sqlConnection = SQLHelper.GetSqlConnection();
            using var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = query;

            await sqlConnection.OpenAsync();
            try
            {
                using var reader = await sqlCommand.ExecuteReaderAsync();

                //gride vermek için datatable oluşturuldu
                DataTable dataTable = new DataTable();
                //sorguyu çalıştırdıktan sonra reader içerisindeki satırlarda döngü başlatılıyor
                while (await reader.ReadAsync())
                {
                    //datatable'a yeni bir row eklendi
                    DataRow row = dataTable.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //datatable içerisinde olmayıp reader'da olan bir kolon varsa eklemek için kontrol edildi
                        var columnName = reader.GetName(i);
                        if (!dataTable.Columns.Contains(columnName))
                        {
                            dataTable.Columns.Add(columnName);
                        }

                        //datatable'ın ilgili kolonuna reader'dan gelen veri basıldı
                        row[columnName] = reader[i];
                    }
                    dataTable.Rows.Add(row);
                }

                //oluşturmuş olduğumuz datatable gride datasource olarak atandı
                grdData.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        private async void lblUserList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await FillDataGrid("select * from vw_UserList");
        }

        private async void lblUserLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await FillDataGrid("exec sp_GetUserLogsBetweenDates");
        }

        private async void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            await FillDataGrid("select * from Fatura");
        }
    }
}
