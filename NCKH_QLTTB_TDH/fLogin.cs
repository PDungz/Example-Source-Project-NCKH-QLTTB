using QLTTB_TDH.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTB_TDH
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        // Dang nhap phan mem
        private void btn_Dang_nhap_Click(object sender, EventArgs e)
        {
            string userName = txb_Ten_dang_nhap.Text;
            string passWord = txb_Mat_khau.Text;
            if (Login(userName, passWord))
            {
                DTO.AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fInformationAccount f = new fInformationAccount(loginAccount, loginAccount.Id_A);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
            }
        }

        // Kiem tra tai khoan
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        // Thoat phan mem
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
