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
    public partial class fInformationAccount : Form
    {
        private DTO.AccountDTO loginAccount;

        public DTO.AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }

        public fInformationAccount(AccountDTO loginAccount, int Id)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
            Show_Infro_A(Id);
        }

        // Hien thi thong tin tai khoang dang nhap
        void Show_Infro_A(int id)
        {
            DTO.InformationAccountDTO info = InformationAccountDAO.Instance.GetAccountById(id);
            txb_Ma_NQL.Text = info.Ma_nql_Info_A;
            txb_Ten_NQL.Text = info.Ten_Info_A;
            dtp_Ngay_sinh_NQL.Value = info.Ngay_sinh_Info_A;
            txb_Gioi_TInh_NQL.Text = info.Gioi_tinh_Info_A;
            txb_Chuc_vu_NQL.Text = info.Chuc_vu_Info_A;
            txb_Email_NQL.Text = info.Email_Info_A;
            txb_Sdt_NQL.Text = info.SDT_Info_A;
            txb_Phong_ct_NQL.Text = info.Phong_cong_tac_Info_A;
            txb_Dia_chi_NQL.Text = info.Dia_chi_Info_A;
        }

        // Mo From Quan ly
        private void btnOpenTableManage_Click(object sender, EventArgs e)
        {
            fTableManage f = new fTableManage(loginAccount);
            f.ShowDialog();
        }

        // Dang xuat khoi phan mem
        private void btnLoginOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInformationAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất!", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        // Mo From cap nhat tai khoan
        private void btnAccountProfile_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.ShowDialog();
        }
    }
}
