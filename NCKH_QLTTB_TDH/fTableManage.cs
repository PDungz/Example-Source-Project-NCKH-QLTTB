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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLTTB_TDH
{
    public partial class fTableManage : Form
    {
        BindingSource EquipmentList = new BindingSource();
        BindingSource CompanyList = new BindingSource();
        BindingSource EquipmentTypeList = new BindingSource();
        BindingSource ManagerList = new BindingSource();
        BindingSource RoomManageList = new BindingSource();
        BindingSource StatisticalList = new BindingSource();
        BindingSource StatisticalList_TK = new BindingSource();

        private AccountDTO accountDTO;
        private string Ma_phong;
        private bool search_Eq = true;
        private bool search_Ltb = true;
        private bool search_Rql = true;

        public AccountDTO AccountDTO
        {
            get => accountDTO;
            set { accountDTO = value;  
            LoadAccessRights(AccountDTO.Quyen_truy_cap_A);
            }
            // Load ham pham quyen tai khoan
        }

        public string Ma_phong1 { get => Ma_phong; set => Ma_phong = value; }

        public fTableManage(AccountDTO ac)
        {
            InitializeComponent();
            this.AccountDTO = ac;
            Load();
        }


        #region Method
        void Load()
        {
            // Load thong ke
            LoadListStatistical();
            dtgv_Ngay_da_TK.DataSource = StatisticalList;
            dtgv_Ngay_TK.DataSource = StatisticalList_TK;
            LoadRoomManageIntoCombobox_Name(cmb_phong_PQL_TK);
            LoadEquipment_Name_Count(cmb_danh_sach_TB_PQL);


            // Load thiet bi
            dtgv_TB.DataSource = EquipmentList;
            LoadListEquipment();
            LoadEquipmentTypeIntoCombobox(cmb_Ma_loai_TB);
            LoadRoomManageIntoCombobox(cmb_Ma_Phong_QL);

            // Load hang thiet bi
            dtgv_HTB.DataSource = CompanyList;
            LoadListCompany();
            LoadCompanyIntoCombobox(cmb_Ma_hang_LTB);

            // Load loai thiet bi
            dtgv_LTB.DataSource = EquipmentTypeList;
            LoadListEquipmentType();

            // Load Nguoi quan ly
            dtgv_CB.DataSource = ManagerList;
            LoadListManager();

            // Load phong quan ly 
            dtgv_PQL.DataSource = RoomManageList;
            LoadListRoomManage();
            LoadManagerIntoCombobox(cmb_Ma_NQL_PQL);

            // Load thong tin nguoi dang nhap
            LoadInformationAccount();

            // Binding 
            LoadBinding();
        }

        #region Quyen truy cap
        // Pham quyen truy cap trong From quan ly
        void LoadAccessRights(int type)
        {
            // Tab thiet bi
            btnInsert_TB.Enabled = type == 1;
            btnDelete_TB.Enabled = type == 1;
            btnEdit_TB.Enabled = type == 1;
            
            // Tab Hang
            btnInsert_HTB.Enabled = type == 1;
            btnDelete_HTB.Enabled = type == 1;
            btnEdit_HTB.Enabled = type == 1;

            // Tab Loai thiet bi
            btnInsert_LTB.Enabled = type == 1;
            btnDelete_LTB.Enabled = type == 1;
            btnEdit_HTB.Enabled = type == 1;

            // Tab Nguoi quan ly
            btnInsert_CB.Enabled = type == 1;
            btnDelete_CB.Enabled = type == 1;
            btnEdit_CB.Enabled = type == 1; 

            // Tab Phong quan ly
            btnInsert_PQL.Enabled = type == 1;
            btnDelete_PQL.Enabled = type == 1;
            btnEdit_PQL.Enabled = type == 1;

            // Tab Thong ke
            btn_Xuat_tk_TK.Enabled = type == 1;

        }
        #endregion

        #region Tab Thong ke
        // Lay ra danh sach thong ke
        void LoadListStatistical()
        {
            StatisticalList.DataSource = DAO.StatisticalDAO.Instance.GetListStatistical();
        }

        // Lay ra danh sach thong ke theo ten phong va ngay da thong ke
        void LoadListStatistical_NameRoom_Time()
        { 
            DateTime Ngay_TK = DateTime.Parse(dtp_Ngay_da_TK.Text);
            StatisticalList.DataSource = DAO.StatisticalDAO.Instance.GetListStatistical_CodeRoom_Time(Ma_phong, Ngay_TK);
        }

        // Lay ra danh sach thong ke theo phong va ngay dang thong ke
        void LoadListStatistical_Time_TK()
        {
            DateTime Ngay_tk = DateTime.Parse(dtp_Ngay_bd_TK.Text);
            StatisticalList_TK.DataSource = DAO.StatisticalDAO.Instance.GetListStatistical_CodeRoom_Time(Ma_phong, Ngay_tk);
        }

        // Lay ra danh sach thong ke theo ten phong
        void LoadListStatistical_NameRoom()
        {
            string Ten_phong = (cmb_phong_PQL_TK.SelectedItem as RoomManageDTO).Ten_phong_Rm;
            DTO.RoomManageDTO rm = DAO.RoomManageDAO.Instance.GetRoomManageByNameRoom(Ten_phong);
            string Ma_phong = rm.Ma_phong_Rm;
            StatisticalList.DataSource = DAO.StatisticalDAO.Instance.GetListStatistical_CodeRoom(Ma_phong);

        }

        // Dua ra so luong thiet bi co trong cmb_danh_sach_TB_PQL
        void LoadEquipment_Count()
        {
            txb_so_luong_TB_PQL.Text = (EquipmentDAO.Instance.GetListEquipment_Count(Ma_phong)).ToString(); 
        }

        // Dua danh sach cac phong ban vao cmb_phong_PQL_TK
        void LoadRoomManageIntoCombobox_Name(ComboBox cb)
        {
            cb.DataSource = RoomManageDAO.Instance.GetListRoomManage();
            cb.DisplayMember = "Ten_phong_Rm";

        }

        // Dua danh sach thiet bi vao cmb_danh_sach_TB_PQL
        void LoadEquipmentIntoCombox(ComboBox cb)
        {
            cb.DataSource = EquipmentDAO.Instance.GetListEquipment_Room(Ma_phong);
            cb.DisplayMember = "Ten_tb_Eq";
        }

        // Dua toan bo danh sach va so luong thiet bi TK
        void LoadEquipment_Name_Count(ComboBox cb)
        {
            cb.DataSource = EquipmentDAO.Instance.GetListEquipment_Room(" ");
            cb.DisplayMember = "Ten_tb_Eq";
            txb_so_luong_TB_PQL.Text = (EquipmentDAO.Instance.GetListEquipment_Count(" ")).ToString();
        }

        #endregion

        #region Tab Thiet bi
        // Lay du thong tin danh sach cac thiet bi
        void LoadListEquipment()
        {
            EquipmentList.DataSource = DAO.EquipmentDAO.Instance.GetListEquipment();
        }

        // Dua danh sach cac phong ban vao cmb_Ma_phong_PQL
        void LoadRoomManageIntoCombobox(ComboBox cb)
        {
            cb.DataSource = RoomManageDAO.Instance.GetListRoomManage();
            cb.DisplayMember = "Ma_phong_Rm";
        }

        // Dua danh sach ten Loai thiet bi vao cmb_Ma_loai_TB
        void LoadEquipmentTypeIntoCombobox(ComboBox cb)
        {
            cb.DataSource = EquipmentTypeDAO.Instance.GetListEquipmentType();
            cb.DisplayMember = "Ma_loai_Et";
        }

        //Lay danh sach thiet bi theo ten Tim kiem thiet bi
        List<EquipmentDTO> SearchEquipment(string Ten_TB)
        {
            List<EquipmentDTO> list = DAO.EquipmentDAO.Instance.Search_Equipment(Ten_TB);
            return list;
        }

        #endregion
     
        #region Tab Hang thiet bi
        // Lay ra thong tin Hang thiet bi
        void LoadListCompany()
        {
            CompanyList.DataSource = DAO.CompanyDAO.Instance.GetListCompany();
        }

        //Lay danh sach hang thiet bi theo ten Tim kiem  hang
        List<CompanyDTO> SearchCompany(string Ten_hang)
        {
            List<CompanyDTO> list = DAO.CompanyDAO.Instance.Search_Equipment(Ten_hang);
            return list;
        }

        #endregion

        #region Tab Loai thiet bi
        // Lay ra danh sach thong tin Loai thiet bi 
        void LoadListEquipmentType()
        {
            EquipmentTypeList.DataSource = DAO.EquipmentTypeDAO.Instance.GetListEquipmentType();
        }

        // Dua danh sach ten Hang thiet bi vao cmb_Ma_hang_LTB
        void LoadCompanyIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CompanyDAO.Instance.GetListCompany();
            cb.DisplayMember = "Ma_hang_Cp";
        }

        //Lay danh sach loai thiet bi theo ten Tim kiem  loai thiet bi
        List<EquipmentTypeDTO> SearchEquipmentType(string Ten_loai)
        {
            List<EquipmentTypeDTO> list = DAO.EquipmentTypeDAO.Instance.Search_EquipmentType(Ten_loai);
            return list;
        }

        #endregion

        #region Tab Nguoi quan ly
        // Lay ra danh sach nguoi quan ly
        void LoadListManager() 
        {
            ManagerList.DataSource = DAO.ManagerDAO.Instance.GetListManager();
        }

        //Lay danh sach nguoi quan lý theo ten Tim kiem  hang
        List<ManagerDTO> SearchManager(string Ten)
        {
            List<ManagerDTO> list = DAO.ManagerDAO.Instance.Search_Equipment(Ten);
            return list;
        }
        #endregion

        #region Tab Phong quan ly

        // Lay ra danh sach phong quan ly
        void LoadListRoomManage()
        {
            RoomManageList.DataSource = DAO.RoomManageDAO.Instance.GetListRoomManage();
        }

        // Dua danh sach cac nguoi quan ly vao cmb_Ma_NQL_PQL
        void LoadManagerIntoCombobox(ComboBox cb) 
        {
            cb.DataSource= ManagerDAO.Instance.GetListManager();
            cb.DisplayMember = "Ma_cbql_Mr";
        }

        //Lay danh sach phong quan ly theo ten Tim kiem  phong quan ly
        List<RoomManageDTO> SearchRoomManage(string Ten_phong)
        {
            List<RoomManageDTO> list = DAO.RoomManageDAO.Instance.Search_RoomManage(Ten_phong);
            return list;
        }

        #endregion


        void LoadBinding()
        {
            // Binding Tab Thong ke
            txb_Ma_thiet_bi_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "Ma_tb_TK", true, DataSourceUpdateMode.Never));
            txb_Ten_thiet_bi_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "Ten_tb_TK", true, DataSourceUpdateMode.Never));
            txb_So_luong_TB_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "So_luong_TK", true, DataSourceUpdateMode.Never));
            txb_Trang_thai_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "Trang_thai_TK", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_TB_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "Ghi_chu_TK", true, DataSourceUpdateMode.Never));
            dtp_Ngay_thong_ke_TK.DataBindings.Add(new Binding("Value", dtgv_Ngay_da_TK.DataSource, "Ngay_cap_nhat_TK", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_TK.DataBindings.Add(new Binding("Text", dtgv_Ngay_da_TK.DataSource, "Ghi_chu_ng_cn_TK", true, DataSourceUpdateMode.Never));


            // Binding Tab Thiet Bi
            txb_Id_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "Id_Eq", true, DataSourceUpdateMode.Never));
            txb_Ma_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "Ma_tb_Eq", true, DataSourceUpdateMode.Never));
            txb_Ten_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "Ten_tb_Eq", true, DataSourceUpdateMode.Never));
            txb_So_luong_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "So_luong_Eq", true, DataSourceUpdateMode.Never));
            dtp_Ngay_nhap_TB.DataBindings.Add(new Binding("Value", dtgv_TB.DataSource, "Ngay_nhap_Eq", true, DataSourceUpdateMode.Never));
            txb_Trang_Thai_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "Trang_thai_Eq", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_TB.DataBindings.Add(new Binding("Text", dtgv_TB.DataSource, "Ghi_chu_Eq", true, DataSourceUpdateMode.Never));

            // Binding Tab Hang thiet bi
            txb_Id_HTB.DataBindings.Add(new Binding("Text", dtgv_HTB.DataSource, "Id_Cp", true, DataSourceUpdateMode.Never));
            txb_Ma_HTB.DataBindings.Add(new Binding("Text", dtgv_HTB.DataSource, "Ma_hang_Cp", true, DataSourceUpdateMode.Never));
            txb_Ten_HTB.DataBindings.Add(new Binding("Text", dtgv_HTB.DataSource, "Ten_hang_CP", true, DataSourceUpdateMode.Never));
            txb_SDT_HTB.DataBindings.Add(new Binding("Text", dtgv_HTB.DataSource, "Lien_He_tong_dai_Cp", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_HTB.DataBindings.Add(new Binding("Text", dtgv_HTB.DataSource, "Ghi_chu_Cp", true, DataSourceUpdateMode.Never));

            // Binding Tab Loai thiet bi
            txb_Id_LTB.DataBindings.Add(new Binding("Text", dtgv_LTB.DataSource, "Id_Et", true, DataSourceUpdateMode.Never));
            txb_Ma_LTB.DataBindings.Add(new Binding("Text", dtgv_LTB.DataSource, "Ma_loai_Et", true, DataSourceUpdateMode.Never));
            txb_Ten_LTB.DataBindings.Add(new Binding("Text", dtgv_LTB.DataSource, "Ten_loai_Et", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_LTB.DataBindings.Add(new Binding("Text", dtgv_LTB.DataSource, "Ghi_chu_Et", true, DataSourceUpdateMode.Never));

            // Binding Tab Nguoi quan ly
            txb_Id_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Id_Mr", true, DataSourceUpdateMode.Never));
            txb_Ma_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Ma_cbql_Mr", true, DataSourceUpdateMode.Never));
            txb_Ten_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Ten_Mr", true, DataSourceUpdateMode.Never));
            dtp_Ngay_sinh_CB.DataBindings.Add(new Binding("Value", dtgv_CB.DataSource, "Ngay_sinh_Mr", true, DataSourceUpdateMode.Never));
            txb_Gioi_tinh_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Gioi_tinh_Mr", true, DataSourceUpdateMode.Never));
            txb_SDT_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "SDT_Mr", true, DataSourceUpdateMode.Never));
            txb_Email_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Email_Mr", true, DataSourceUpdateMode.Never));
            txb_Chuc_vu_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Chuc_vu_Mr", true, DataSourceUpdateMode.Never));
            txb_Dia_chi_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Dia_chi_Mr", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_CB.DataBindings.Add(new Binding("Text", dtgv_CB.DataSource, "Ghi_chu_Mr", true, DataSourceUpdateMode.Never));

            // Binding Tab Phong quan ly
            txb_Id_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Id_Rm", true, DataSourceUpdateMode.Never));
            txb_Ma_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Ma_phong_Rm", true, DataSourceUpdateMode.Never));
            txb_Ten_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Ten_phong_Rm", true, DataSourceUpdateMode.Never));
            txb_Dia_chi_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Dia_chi_Rm", true, DataSourceUpdateMode.Never));
            txb_SDT_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "So_dien_thoai_Rm", true, DataSourceUpdateMode.Never));
            txb_Email_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Email_Rm", true, DataSourceUpdateMode.Never));
            txb_Ghi_chu_PQL.DataBindings.Add(new Binding("Text", dtgv_PQL.DataSource, "Ghi_chu_Rm", true, DataSourceUpdateMode.Never));

        }


        #endregion


        #region Events Tab Thong ke 

        // Hien thi danh sach thong ke theo ten phong va ngay
        private void btn_Thong_ke_TK_Click(object sender, EventArgs e)
        {
            LoadListStatistical_NameRoom_Time();
        }
        
        // Hien thi danh sach thong ke theo ten phong
        private void btn_Tim_phong_PQL_TK_Click(object sender, EventArgs e)
        {
            string Ten_phong = (cmb_phong_PQL_TK.SelectedItem as RoomManageDTO).Ten_phong_Rm;
            DTO.RoomManageDTO rm = DAO.RoomManageDAO.Instance.GetRoomManageByNameRoom(Ten_phong);
            string Mp = rm.Ma_phong_Rm;
            this.Ma_phong = Mp;
            LoadListStatistical_NameRoom();
            LoadEquipmentIntoCombox(cmb_danh_sach_TB_PQL);
            LoadEquipment_Count();
        }

        // Xuat thong tin thong ke 
        private void btn_Xuat_tk_TK_Click(object sender, EventArgs e)
        {
            string Ma_tb = txb_Ma_thiet_bi_TK.Text; 

            if (DAO.StatisticalDAO.Instance.Check_Statistical_Code_Et(Ma_tb) == true)
            {
                DTO.StatisticalDTO Inf_TB = DAO.StatisticalDAO.Instance.GetStatistical_Code_Et(Ma_tb);
                string Ten_tb = Inf_TB.Ten_tb_TK;
                int So_luong = Convert.ToInt32(txb_So_luong_TB_TK.Text);
                DateTime Ngay_nhap = Inf_TB.Ngay_nhap_TK;
                string Trang_thai = txb_Trang_thai_TK.Text;
                string Ma_loai = Inf_TB.Ma_loai_TK;
                string Ma_Phong_Ban = Inf_TB.Ma_Phong_Ban_TK;
                string Ghi_chu = txb_Ghi_chu_TB_TK.Text;
                DateTime Ngay_cap_nhat = DateTime.Parse(dtp_Ngay_thong_ke_TK.Text);
                string Ghi_chu_ng_cn = txb_Ghi_chu_TK.Text;

                if (DAO.StatisticalDAO.Instance.InsertStatistical(Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_cap_nhat, Ghi_chu_ng_cn))
                {
                    MessageBox.Show("Thống kê thành công");
                    LoadListStatistical_Time_TK();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }
        }

        #endregion

        #region Events Tab Thiet bi

        ///////////////////////Tab Thiet bi/////////////////////
        // Hien thi danh Ma Loai thiet bi va Ma Phong QL
        private void txb_Id_TB_TextChanged_1(object sender, EventArgs e)
        {
            if (this.search_Eq == true)
            {
                if (dtgv_TB.SelectedCells.Count > 0)
                {
                    // Ma Loai TB
                    string strMl = dtgv_TB.SelectedCells[0].OwningRow.Cells["Ma_loai_Eq"].Value.ToString();
                    DTO.EquipmentTypeDTO eqt = EquipmentTypeDAO.Instance.GetEquipmentTypeByCodeType(strMl);
                    cmb_Ma_loai_TB.SelectedItem = eqt;

                    // Ma phong Ql
                    string strMp = dtgv_TB.SelectedCells[0].OwningRow.Cells["Ma_Phong_Ban_Eq"].Value.ToString();
                    DTO.RoomManageDTO rm = RoomManageDAO.Instance.GetRoomManageByCodeRoom(strMp);
                    cmb_Ma_Phong_QL.SelectedItem = rm;

                    int indexMl = -1;
                    int i = 0;
                    foreach (DTO.EquipmentTypeDTO item in cmb_Ma_loai_TB.Items)
                    {
                        if (item.Id_Et == eqt.Id_Et)
                        {
                            indexMl = i;
                            break;
                        }
                        i++;
                    }

                    int indexMp = -1;
                    int j = 0;
                    foreach (DTO.RoomManageDTO item in cmb_Ma_Phong_QL.Items)
                    {
                        if (item.Id_Rm == rm.Id_Rm)
                        {
                            indexMp = j;
                            break;
                        }
                        j++;
                    }

                    cmb_Ma_loai_TB.SelectedIndex = indexMl;
                    cmb_Ma_Phong_QL.SelectedIndex = indexMp;
                }
            }
        }

        // Tim kiem thiet bi
        private void btn_Tim_TB_Click(object sender, EventArgs e)
        {
            if (DAO.EquipmentDAO.Instance.Check_Equipment_Name(txb_Tim_TB.Text) != true)
            {
                this.search_Eq = false;
            }
            EquipmentList.DataSource = SearchEquipment(txb_Tim_TB.Text);
        }

        // Them thiet bi
        private void btnInsert_TB_Click(object sender, EventArgs e)
        {
            string Ma_tb = txb_Ma_TB.Text;
            string Ten_tb = txb_Ten_TB.Text;
            int So_luong = int.Parse(txb_So_luong_TB.Text);
            DateTime Ngay_nhap = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Trang_thai = txb_Trang_Thai_TB.Text;
            string Ma_loai = (cmb_Ma_loai_TB.SelectedItem as EquipmentTypeDTO).Ma_loai_Et;
            string Ma_Phong_Ban = (cmb_Ma_Phong_QL.SelectedItem as RoomManageDTO).Ma_phong_Rm;
            string Ghi_chu = txb_Ghi_chu_TB.Text;
            DateTime Ngay_cap_nhat = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Ghi_chu_ng_cn = txb_Ghi_chu_TB.Text;

            if (DAO.EquipmentDAO.Instance.Check_Equipment(Ma_tb) != true)
            {
                if (DAO.EquipmentDAO.Instance.InsertEquipment(Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu))
                {
                    DAO.StatisticalDAO.Instance.InsertStatistical(Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_cap_nhat, Ghi_chu_ng_cn);
                    MessageBox.Show("Thêm thiêt bị thành công");
                    LoadListEquipment();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }
        }

        // Xoa thiet bi
        private void btnDelete_TB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_TB.Text);
            string Ma_tb = txb_Ma_TB.Text;
            string Ten_tb = txb_Ten_TB.Text;
            int So_luong = 0;
            DateTime Ngay_nhap = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Trang_thai = "không tồn tại";
            string Ma_loai = (cmb_Ma_loai_TB.SelectedItem as EquipmentTypeDTO).Ma_loai_Et;
            string Ma_Phong_Ban = (cmb_Ma_Phong_QL.SelectedItem as RoomManageDTO).Ma_phong_Rm;
            string Ghi_chu = txb_Ghi_chu_TB.Text;
            DateTime Ngay_cap_nhat = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Ghi_chu_ng_cn = "Không có";

            if (DAO.EquipmentDAO.Instance.DeleteEquipment(Id))
            {
                DAO.StatisticalDAO.Instance.InsertStatistical(Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_cap_nhat, Ghi_chu_ng_cn);
                MessageBox.Show("Xóa thiêt bị thành công");
                LoadListEquipment();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Sua thiet bi
        private void btnEdit_TB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_TB.Text);
            string Ma_tb = txb_Ma_TB.Text;
            string Ten_tb = txb_Ten_TB.Text;
            int So_luong = int.Parse(txb_So_luong_TB.Text);
            DateTime Ngay_nhap = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Trang_thai = txb_Trang_Thai_TB.Text;
            string Ma_loai = (cmb_Ma_loai_TB.SelectedItem as EquipmentTypeDTO).Ma_loai_Et;
            string Ma_Phong_Ban = (cmb_Ma_Phong_QL.SelectedItem as RoomManageDTO).Ma_phong_Rm;
            string Ghi_chu = txb_Ghi_chu_TB.Text;
            DateTime Ngay_cap_nhat = DateTime.Parse(dtp_Ngay_nhap_TB.Text);
            string Ghi_chu_ng_cn = txb_Ghi_chu_TB.Text;

            if (DAO.EquipmentDAO.Instance.UpdateEquipment(Id, Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu))
            {
                DAO.StatisticalDAO.Instance.InsertStatistical(Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_cap_nhat, Ghi_chu_ng_cn);
                MessageBox.Show("Sửa thông tin thiêt bị thành công");
                LoadListEquipment();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Xem thong tin thiet bi
        private void btnShow_TB_Click(object sender, EventArgs e)
        {
            this.search_Eq = true;
            LoadListEquipment();
            LoadEquipmentTypeIntoCombobox(cmb_Ma_loai_TB);
            LoadRoomManageIntoCombobox(cmb_Ma_Phong_QL);
        }

        #endregion
     
        #region Events Tab Hang thiet bi

        ///////////////////////Tab Hang/////////////////////

        // Them Hang thiet bi
        private void btnInsert_HTB_Click(object sender, EventArgs e)
        {
            string Ma_hang = txb_Ma_HTB.Text;
            string Ten_hang = txb_Ten_HTB.Text;
            string Lien_He_tong_dai = txb_SDT_HTB.Text;
            string Ghi_chu = txb_Ghi_chu_HTB.Text;

            if (DAO.CompanyDAO.Instance.Check_Company(Ma_hang) != true)
            {
                if (DAO.CompanyDAO.Instance.InsertCompany(Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu))
                {
                    MessageBox.Show("Thêm Hang thành công");
                    LoadListCompany();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }

        }

        // Xoa thong tin Hang thiet bi
        private void btnDelete_HTB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_HTB.Text);
            string Ma_hang = txb_Ma_HTB.Text;
            if(DAO.EquipmentTypeDAO.Instance.Check_EquipmentType_CP(Ma_hang) != true)
            {
                if (DAO.CompanyDAO.Instance.DeleteCompany(Id))
                {
                    MessageBox.Show("Xóa Hang thiêt bị thành công");
                    LoadListCompany();
                }

                else
                {
                    MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");

                }
            }

            else
            {
                MessageBox.Show("Cảnh báo!\nHãy xem lại thông tin loại thiết bị trước khi xóa thông tin hãng sẽ bị mất dữ liệu");
            }
        }

        // Sua Hang thiet bi
        private void btnEdit_HTB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_HTB.Text);
            string Ma_hang = txb_Ma_HTB.Text;
            string Ten_hang = txb_Ten_HTB.Text;
            string Lien_He_tong_dai = txb_SDT_HTB.Text;
            string Ghi_chu = txb_Ghi_chu_HTB.Text;

            if (DAO.CompanyDAO.Instance.UpdateCompany(Id, Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu))
            {
                MessageBox.Show("Sửa thông tin Hang thiêt bị thành công");
                LoadListCompany();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Hien thi danh sach hang thiet bi
        private void btnShow_HTB_Click(object sender, EventArgs e)
        {
            LoadListCompany();
        }

        // Tim kiem hang
        private void btn_Tim_HTB_Click(object sender, EventArgs e)
        {
            CompanyList.DataSource = SearchCompany(txb_Tim_HTB.Text);
        }

        #endregion

        #region Events Tab Loai thiet bi
        ///////////////////////Tab Loai thiet bi/////////////////////

        // Hien thi danh sach loai thiet bi
        private void txb_Id_LTB_TextChanged_1(object sender, EventArgs e)
        {
            if (this.search_Ltb == true) {
                if (dtgv_LTB.SelectedCells.Count > 0)
                {
                    // Ma Hang thiet bi
                    string strCp = dtgv_LTB.SelectedCells[0].OwningRow.Cells["Ma_hang_Et"].Value.ToString();
                    DTO.CompanyDTO mh = CompanyDAO.Instance.GetCompanyByCodeCp(strCp);
                    cmb_Ma_hang_LTB.SelectedItem = mh;

                    int index = -1;
                    int i = 0;
                    foreach (DTO.CompanyDTO item in cmb_Ma_hang_LTB.Items)
                    {
                        if (item.Id_Cp == mh.Id_Cp)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cmb_Ma_hang_LTB.SelectedIndex = index;
                }
            }
        }
        
        // Tim kiem loai thiet bi
        private void btn_Tim_LTB_Click(object sender, EventArgs e)
        {
            if(DAO.EquipmentTypeDAO.Instance.Check_EquipmentType_Name(txb_Tim_LTB.Text) != true)
            {
                this.search_Ltb = false;
            }
            EquipmentTypeList.DataSource = SearchEquipmentType(txb_Tim_LTB.Text);
        }

        // Them loai thiet bi
        private void btnInsert_LTB_Click(object sender, EventArgs e)
        {
            string Ma_loai = txb_Ma_LTB.Text;
            string Ten_loai = txb_Ten_LTB.Text;
            string Ma_hang = (cmb_Ma_hang_LTB.SelectedItem as CompanyDTO).Ma_hang_Cp;
            string Ghi_chu = txb_Ghi_chu_LTB.Text;

            if (DAO.EquipmentTypeDAO.Instance.Check_EquipmentType(Ma_loai) != true)
            {
                if (DAO.EquipmentTypeDAO.Instance.InsertEquipmentType(Ma_loai, Ten_loai, Ma_hang, Ghi_chu))
                {
                    MessageBox.Show("Thêm Loại thiêt bị thành công");
                    LoadListEquipmentType();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }
        }

        // Xoa loai thiet bi
        private void btnDelete_LTB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_LTB.Text);
            string Ma_loai = txb_Ma_LTB.Text;

            if (DAO.EquipmentDAO.Instance.Check_Equipment_Code_EquipmentType(Ma_loai) != true)
            {
                if (DAO.EquipmentTypeDAO.Instance.DeleteEquipmentType(Id))
                {
                    MessageBox.Show("Xóa Loại thiêt bị thành công");
                    LoadListEquipmentType();
                }

                else
                {
                    MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
                }
            }
            else
            {
                MessageBox.Show("Cảnh báo!\nHãy xem lại thông tin thiết bị trước khi xóa thông tin loại sẽ bị mất dữ liệu");
            }
        }

        // Sua thong tin loai thiet bi
        private void btnEdit_LTB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_LTB.Text);
            string Ma_loai = txb_Ma_LTB.Text;
            string Ten_loai = txb_Ten_LTB.Text;
            string Ma_hang = (cmb_Ma_hang_LTB.SelectedItem as CompanyDTO).Ma_hang_Cp;
            string Ghi_chu = txb_Ghi_chu_LTB.Text;

            if (DAO.EquipmentTypeDAO.Instance.UpdateEquipmentType(Id, Ma_loai, Ten_loai, Ma_hang, Ghi_chu))
            {
                MessageBox.Show("Sửa thông tin Loại thiêt bị thành công");
                LoadListEquipmentType();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Xem thong tin loai thiet bi
        private void btnShow_LTB_Click(object sender, EventArgs e)
        {
            this.search_Ltb = true;
            LoadListEquipmentType();
            LoadCompanyIntoCombobox(cmb_Ma_hang_LTB);
        }

        #endregion

        #region Events Tab Nguoi quan ly
        // Tim kiem nguoi quan ly
        private void btn_Tim_CB_Click(object sender, EventArgs e)
        {
            ManagerList.DataSource = SearchManager(txb_Tim_CB.Text);
        }

        // Them Thong tin nguoi quan ly
        private void btnInsert_CB_Click(object sender, EventArgs e)
        {
            string Ma_cbql = txb_Ma_CB.Text;
            string Ten = txb_Ten_CB.Text;
            DateTime Ngay_sinh = DateTime.Parse(dtp_Ngay_sinh_CB.Text);
            string Gioi_tinh = txb_Gioi_tinh_CB.Text;
            string Dia_chi = txb_Dia_chi_CB.Text;
            string SDT = txb_SDT_CB.Text;   
            string Email = txb_Email_CB.Text;
            string Chuc_vu = txb_Chuc_vu_CB.Text;
            string Ghi_chu = txb_Ghi_chu_CB.Text;

            if (DAO.ManagerDAO.Instance.Check_Manager(Ma_cbql) != true)
            {
                if (DAO.ManagerDAO.Instance.InsertManager(Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu))
                {
                    MessageBox.Show("Thêm Nguoi quan ly thành công");
                    LoadListManager();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }

        }

        // Xoa thong tin nguoi quan ly
        private void btnDelete_CB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_CB.Text);
            string Ma_cbql = txb_Ma_CB.Text;

            if(DAO.RoomManageDAO.Instance.Check_RoomManage_Code_Manager(Ma_cbql) != true)
            {
                if (DAO.ManagerDAO.Instance.DeleteManager(Id))
                {
                    MessageBox.Show("Xóa Thong tin nguoi quan ly thành công");
                    LoadListManager();
                }

                else
                {
                    MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
                }
            }

            else
            {
                MessageBox.Show("Cảnh báo!\nHãy xem lại thông tin phòng quản lý trước khi xóa thông tin người quản lý sẽ bị mất dữ liệu");
            }
        }

        // Sua thong tin nguoi quan ly
        private void btnEdit_CB_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_CB.Text);
            string Ma_cbql = txb_Ma_CB.Text;
            string Ten = txb_Ten_CB.Text;
            DateTime Ngay_sinh = DateTime.Parse(dtp_Ngay_sinh_CB.Text);
            string Gioi_tinh = txb_Gioi_tinh_CB.Text;
            string Dia_chi = txb_Dia_chi_CB.Text;
            string SDT = txb_SDT_CB.Text;
            string Email = txb_Email_CB.Text;
            string Chuc_vu = txb_Chuc_vu_CB.Text;
            string Ghi_chu = txb_Ghi_chu_CB.Text;

            if (DAO.ManagerDAO.Instance.UpdateManager(Id, Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu))
            {
                MessageBox.Show("Sửa thông tin nguoi quan ly thành công");
                LoadListManager();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Hien thi danh sach nguoi quan ly
        private void btnShow_CB_Click(object sender, EventArgs e)
        {
            LoadListManager();
        }

        #endregion

        #region Events Tab Phong quan ly
        // Hien thi danh sach nguoi quan ly
        private void txb_Id_PQL_TextChanged(object sender, EventArgs e)
        {
            if (this.search_Rql == true) {
                if (dtgv_PQL.SelectedCells.Count > 0)
                {
                    // Ma Hang thiet bi
                    string strMr = dtgv_PQL.SelectedCells[0].OwningRow.Cells["Ma_cbql_Rm"].Value.ToString();
                    DTO.ManagerDTO mr = ManagerDAO.Instance.GetManagerByCode(strMr);
                    cmb_Ma_NQL_PQL.SelectedItem = mr;

                    int index = -1;
                    int i = 0;
                    foreach (DTO.ManagerDTO item in cmb_Ma_NQL_PQL.Items)
                    {
                        if (item.Id_Mr == mr.Id_Mr)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cmb_Ma_NQL_PQL.SelectedIndex = index;
                }
            }
        }
        
        // Tim kiem phong quan ly
        private void btn_Tim_PQL_Click(object sender, EventArgs e)
        {
            if(DAO.RoomManageDAO.Instance.Check_RoomManage_Name(txb_Tim_PQL.Text) != true)
            {
                this.search_Rql = false;
            }
            RoomManageList.DataSource = SearchRoomManage(txb_Tim_PQL.Text);
        }

        // Them thong tin phong quan ly
        private void btnInsert_PQL_Click(object sender, EventArgs e)
        {
            string Ma_phong = txb_Ma_PQL.Text;
            string Ten_phong = txb_Ten_PQL.Text;
            string Dia_chi = txb_Dia_chi_PQL.Text;
            string Email = txb_Email_PQL.Text;
            string So_dien_thoai = txb_SDT_PQL.Text;
            string Ma_cbql = (cmb_Ma_NQL_PQL.SelectedItem as ManagerDTO).Ma_cbql_Mr;
            string Ghi_chu = txb_Ghi_chu_PQL.Text;

            if (DAO.RoomManageDAO.Instance.Check_RoomManage(Ma_phong) != true)
            {
                if (DAO.RoomManageDAO.Instance.InsertRoomManage(Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu))
                {
                    MessageBox.Show("Thêm thong tin phong ban thành công");
                    LoadListRoomManage();
                }
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng kiểm tra lại thông tin đã nhập nhập lại!");
            }
        }
        
        // Xoa thong tin phong quan ly
        private void btnDelete_PQL_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_PQL.Text);
            string Ma_phong = txb_Ma_PQL.Text;
            
            if(DAO.EquipmentDAO.Instance.Check_Equipment_Code_RoomManage(Ma_phong) != true)
            {
                if (DAO.RoomManageDAO.Instance.DeleteRoomManage(Id))
                {
                    MessageBox.Show("Xóa thong tin phong quan ly thành công");
                    LoadListRoomManage();
                }

                else
                {
                    MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
                }
            }
            else
            {
                MessageBox.Show("Cảnh báo!\nHãy xem lại thông tin thiết bị trước khi xóa thông tin phòng quản lý sẽ bị mất dữ liệu");

            }
        }
        
        // Sua thong tin phong quan ly
        private void btnEdit_PQL_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txb_Id_PQL.Text);
            string Ma_phong = txb_Ma_PQL.Text;
            string Ten_phong = txb_Ten_PQL.Text;
            string Dia_chi = txb_Dia_chi_PQL.Text;
            string Email = txb_Email_PQL.Text;
            string So_dien_thoai = txb_SDT_PQL.Text;
            string Ma_cbql = (cmb_Ma_NQL_PQL.SelectedItem as ManagerDTO).Ma_cbql_Mr;
            string Ghi_chu = txb_Ghi_chu_PQL.Text;

            if (DAO.RoomManageDAO.Instance.UpdateRoomManage(Id, Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu))
            {
                MessageBox.Show("Sửa thông tin phong quan ly thành công");
                LoadListRoomManage();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }
        }

        // Hien thi danh sach phong quan ly
        private void btnShow_PQL_Click(object sender, EventArgs e)
        {
            this.search_Rql = true;
            LoadListRoomManage();
            LoadManagerIntoCombobox(cmb_Ma_NQL_PQL);
        }
        #endregion

        #region Events Tab Thong tin nguoi dang nhap
        void LoadInformationAccount()
        {
            DTO.InformationAccountDTO info = InformationAccountDAO.Instance.GetAccountById(accountDTO.Id_A);
            txb_Ma_NQL.Text = info.Ma_nql_Info_A;
            txb_Ten_NQL.Text = info.Ten_Info_A;
            dtp_Ngay_sinh_NQL.Value = info.Ngay_sinh_Info_A;
            txb_Gioi_tinh_NQL.Text = info.Gioi_tinh_Info_A;
            txb_Chuc_vu_NQL.Text = info.Chuc_vu_Info_A;
            txb_Email_NQL.Text = info.Email_Info_A;
            txb_Sdt_NQL.Text = info.SDT_Info_A;
            txb_Phong_ct_NQL.Text = info.Phong_cong_tac_Info_A;
            txb_Dia_chi_NQL.Text = info.Dia_chi_Info_A;
        }

        // Cap nhat thong tin nguoi dang nhap
        private void btnUpdateProfile_NQL_Click(object sender, EventArgs e)
        {
            string Ma_nql = txb_Ma_NQL.Text;
            string Ten = txb_Ten_NQL.Text;
            DateTime Ngay_sinh = DateTime.Parse(dtp_Ngay_sinh_NQL.Text);
            string Gioi_tinh = txb_Gioi_tinh_NQL.Text;
            string Chuc_vu = txb_Chuc_vu_NQL.Text;
            string Email = txb_Email_NQL.Text;
            string SDT = txb_Sdt_NQL.Text;
            string Dia_chi = txb_Dia_chi_NQL.Text;
            string Phong_cong_tac = txb_Phong_ct_NQL.Text;

            if (DAO.InformationAccountDAO.Instance.UpdateInformationAccount(Ma_nql, Ten, Ngay_sinh, Gioi_tinh, Chuc_vu, Email, SDT, Dia_chi, Phong_cong_tac))
            {
                MessageBox.Show("Cập nhật thông tin người đăng nhập thành công");
                LoadInformationAccount();
            }

            else
            {
                MessageBox.Show("Đã xẩy ra lỗi khi nhập!\nVui lòng nhập lại!");
            }

        }

        #endregion


    }
}