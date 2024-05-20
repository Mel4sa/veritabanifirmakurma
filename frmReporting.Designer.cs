namespace WinFormsApp1
{
    partial class frmReporting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtQuery = new TextBox();
            btnRun = new Button();
            grdData = new DataGridView();
            lblUserList = new LinkLabel();
            lblUserLog = new LinkLabel();
            linkLabel3 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)grdData).BeginInit();
            SuspendLayout();
            // 
            // txtQuery
            // 
            txtQuery.Location = new Point(17, 20);
            txtQuery.Margin = new Padding(4, 5, 4, 5);
            txtQuery.Name = "txtQuery";
            txtQuery.PlaceholderText = "Buraya herhangi bir sorgu yazarak çalıştırabilirsiniz.";
            txtQuery.Size = new Size(734, 31);
            txtQuery.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(761, 20);
            btnRun.Margin = new Padding(4, 5, 4, 5);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(179, 38);
            btnRun.TabIndex = 1;
            btnRun.Text = "Çalıştır";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // grdData
            // 
            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToDeleteRows = false;
            grdData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdData.Location = new Point(17, 125);
            grdData.Margin = new Padding(4, 5, 4, 5);
            grdData.Name = "grdData";
            grdData.ReadOnly = true;
            grdData.RowHeadersWidth = 62;
            grdData.Size = new Size(923, 403);
            grdData.TabIndex = 2;
            // 
            // lblUserList
            // 
            lblUserList.AutoSize = true;
            lblUserList.Location = new Point(17, 80);
            lblUserList.Margin = new Padding(4, 0, 4, 0);
            lblUserList.Name = "lblUserList";
            lblUserList.Size = new Size(127, 25);
            lblUserList.TabIndex = 3;
            lblUserList.TabStop = true;
            lblUserList.Text = "Kullanıcı Listesi";
            lblUserList.LinkClicked += lblUserList_LinkClicked;
            // 
            // lblUserLog
            // 
            lblUserLog.AutoSize = true;
            lblUserLog.Location = new Point(341, 80);
            lblUserLog.Margin = new Padding(4, 0, 4, 0);
            lblUserLog.Name = "lblUserLog";
            lblUserLog.Size = new Size(197, 25);
            lblUserLog.TabIndex = 4;
            lblUserLog.TabStop = true;
            lblUserLog.Text = "Kullanıcı Logunu Göster";
            lblUserLog.LinkClicked += lblUserLog_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(666, 80);
            linkLabel3.Margin = new Padding(4, 0, 4, 0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(65, 25);
            linkLabel3.TabIndex = 5;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Fatura ";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // frmReporting
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 548);
            Controls.Add(linkLabel3);
            Controls.Add(lblUserLog);
            Controls.Add(lblUserList);
            Controls.Add(grdData);
            Controls.Add(btnRun);
            Controls.Add(txtQuery);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmReporting";
            Text = "frmReporting";
            ((System.ComponentModel.ISupportInitialize)grdData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuery;
        private Button btnRun;
        private DataGridView grdData;
        private LinkLabel lblUserList;
        private LinkLabel lblUserLog;
        private LinkLabel linkLabel3;
    }
}