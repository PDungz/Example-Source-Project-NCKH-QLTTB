using QLTTB_TDH.DAO;
using QLTTB_TDH.DTO;
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
    public partial class fAccountProfile : Form
    {
        private DTO.AccountDTO loginAccount;

        public DTO.AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount); }
        }

        public fAccountProfile(AccountDTO loginAccount)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
        }

        void changeAccount(DTO.AccountDTO loginAccount)
        {
            txb_Ten_dang_nhap.Text = LoginAccount.Ten_dang_nhap_A;
        }

        // Cap nhat thong tin tai khoan
        private void btn_Cap_nhat_Click(object sender, EventArgs e)
        {
            string UserName = txb_Ten_dang_nhap.Text;
            string PassWord = txb_Mat_khau.Text;
            string NewPassWord = txb_Mat_khau_moi.Text;
            string ReenterPass = txb_Nhap_lai_mat_khau.Text;

            if (UserName.Equals(loginAccount.Ten_dang_nhap_A))
            {
                if (!NewPassWord.Equals(ReenterPass))
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
                }
                else
                {
                    if (AccountDAO.Instance.UpdateAccount(UserName, PassWord, NewPassWord))
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng tên đăng nhập");
            }
        }

        // Thoat From cap nhat tai khoan
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Hãy xác nhận các thông tin đã được thay đổi sau khi thoát?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
