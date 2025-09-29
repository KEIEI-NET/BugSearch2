//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇��CTI�\�� �t�H�[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/06  �C�����e : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 20056 ���n ���
// �C �� �� 2010/04/30   �C�����e : ���`�C���X�^���X�������̃p�����[�^�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/06/17  �C�����e : Delphi���`���N������悤�ɕύX
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    using GridSettingsType = SlipGridSettings;

    /// <summary>
    /// �ȒP�⍇��CTI�\�� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬(IAAE����ύX)</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00101UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member
        private SimpleInqCTIAcs _salesSlipSearchAcs;
        private SalesSlipSearch _para;
        private SimpleInqCTIDataSet _dataSet;                       // �f�[�^�Z�b�g
        private TotalDayCalculator _totalDayCalculator;             // �����Z�o���W���[��
        private ColDisplayStatusList _colDisplayStatusList = null;	// ��\����ԃR���N�V�����N���X
        //private MAHNB01010UA _cmtSalesSlipInputForm;                // ����`�[���̓t�H�[�� // 2010/06/17
        
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        private string _allSectionCode = string.Empty;

        private Thread _constructorThread;
        private Thread _loadThread;
        
        // ���[�h�����ς݃t���O
        private bool _loaded;

        private bool _showEstimateInput = true;
        private int _currentCustomerCode;
        private CustomerInfo _currentCustomerInfo;

        private AlItmDspNm _alItmDspNm;
        private SalesTtlSt _salesTtlSt;
        private CompanyInf _companyInf;

        /// <summary>�O���b�h�̐ݒ���</summary>
        private GridSettingsType _gridSettings;

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region �� Private Const

        private const string ctFILENAME_COLDISPLAYSTATUS = "PMSCM00100U_ColSetting.DAT";	// ��\����ԃZ�b�e�B���OXML�t�@�C����
        private const string XML_FILE_NAME = "PMSCM00100U_Construction.XML";                // �O���b�h���XML�t�@�C����
        private const int ct_DefaultAcptAnOdrStatus = 30;	                                // �󒍃X�e�[�^�X�����l
        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe"; // 2010/06/17

        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �� Constructor
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public PMSCM00101UA(int customerCode)
        {
            this._currentCustomerCode = customerCode;
            this._constructorThread = new Thread(this.ConstructorSearch);

            this._constructorThread.Start();

            InitializeComponent();

            this._loadThread = new Thread(this.LoadSearch);
            this._loadThread.Start();

            
            // �ϐ�������
            this._salesSlipSearchAcs = new SimpleInqCTIAcs();
            this._para = new SalesSlipSearch();
            this._dataSet = this._salesSlipSearchAcs.DataSet;

            UiSet uiset;
            uiSetControl1.ReadUISet(out uiset, "tEdit_SectionCodeAllowZero");
            _allSectionCode = new string('0', uiset.Column);

            // �R���X�g���N�^�p�����X���b�h�̏I���҂�
            while (this._constructorThread.ThreadState == System.Threading.ThreadState.Running)
            {
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMSCM00101UA():this(0)
        {
        }
        # endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region �� Delegate

        /// <summary>
        /// Visible�ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        public delegate void SettingVisibleEventHandler(bool visible);

        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region �� Event

        /// <summary>Visible�ݒ�C�x���g</summary>
        public event SettingVisibleEventHandler SettingVisible;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property
        /// <summary>
        /// �J�n�ł��邩�`�F�b�N
        /// </summary>
        public bool CanStart
        {
            get { return ( this._currentCustomerInfo != null ); }
        }

        /// <summary>�O���b�h�̐ݒ�����擾���܂��B</summary>
        public GridSettingsType GridSettings
        {
            get
            {
                if (_gridSettings == null)
                {
                    _gridSettings = SlipGridUtil.ReadGridSettings(XML_FILE_NAME);
                }
                return _gridSettings;
            }
        }

        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region �� Public Method

        # endregion // Public Method

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region �� Private Method

        /// <summary>
        /// �R���X�g���N�^�p��������
        /// </summary>
        private void ConstructorSearch()
        {
            if (this._currentCustomerCode != 0)
            {
                CustomerInfoAcs acs = new CustomerInfoAcs();
                acs.ReadDBData(ConstantManagement.LogicalMode.GetData0, LoginInfoAcquisition.EnterpriseCode, this._currentCustomerCode, false, false, out this._currentCustomerInfo);
            }
        }

        /// <summary>
        /// ��ʃ��[�h�p��������
        /// </summary>
        private void LoadSearch()
        {
            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
            int status = alItmDspNmAcs.Read(out this._alItmDspNm, this._enterpriseCode);

            // ����S�̐ݒ�}�X�^�̌���
            this.SearchSalesTtlSt(LoginInfoAcquisition.Employee.BelongSectionCode);
            if (this._salesTtlSt == null) this._salesTtlSt = new SalesTtlSt();

            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out this._companyInf,LoginInfoAcquisition.EnterpriseCode);
            if (this._companyInf == null ) this._companyInf = new CompanyInf();
        }

        /// <summary>
        /// ���o�����̊e��R���g���[���ɒl��ݒ肵�܂��B
        /// </summary>
        /// <param name="para">����f�[�^���������p�����[�^�I�u�W�F�N�g</param>
        private void SetDisplayConditionInfoforScm(CustomerInfo custRet)
        {
            this.ulabel_CustomerCode.Text = string.Format("{0:00000000}", custRet.CustomerCode);    // ���Ӑ�R�[�h
            this.ulabel_CustomerSnm.Text = custRet.Name + custRet.Name2;                            // ���Ӑ於��
            this.ulabel_PostNo.Text = custRet.PostNo;                                               // �X�֔ԍ�
            this.ulabel_Address1.Text = custRet.Address1;                                           // �Z���P
            this.ulabel_Address3.Text = custRet.Address3;                                           // �Z���R
            this.ulabel_Address4.Text = custRet.Address4;                                           // �Z���S
            this.ulabel_HomeTelNo.Text = custRet.HomeTelNo;                                         // �d�b�ԍ��P
            this.ulabel_OfficeTelNo.Text = custRet.OfficeTelNo;                                     // �d�b�ԍ��Q
            this.ulabel_OfficeFaxNo.Text = custRet.OfficeFaxNo;                                     // FAX
            this.ulabel_Note1.Text = custRet.Note1;                                                 // ���l�P
            this.ulabel_Note2.Text = custRet.Note2;                                                 // ���l�Q
            this.ulabel_Note3.Text = custRet.Note3;                                                 // ���l�R
            this.ulabel_Note4.Text = custRet.Note4;                                                 // ���l�S
            this.ulabel_TotalDay.Text = custRet.TotalDay.ToString() + "��";                         // ����
            this.ulabel_CollectMoneyDay.Text = custRet.CollectMoneyDay.ToString() + "��";           // �W����

            this.ulabel_MoneyKindName.Text = string.Empty;                                          // �������
            Dictionary<int, MoneyKind> _moneyKindDic;
            this._salesSlipSearchAcs.ReadMoneyKind(custRet.EnterpriseCode, out _moneyKindDic);
            if (_moneyKindDic.ContainsKey(custRet.CollectCond)) this.ulabel_MoneyKindName.Text = _moneyKindDic[custRet.CollectCond].MoneyKindName;
            
            Employee data = null;
            this.ulabel_CollectMoneyEmployee.Text = string.Empty;                                   // �W���S����
            this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, custRet.BillCollecterCd, out data);
            if (data != null) this.ulabel_CollectMoneyEmployee.Text = data.Name;

            this.ulabel_CustomerAgent.Text = custRet.CustomerAgent;
        }
        

        /// <summary>
        /// ����f�[�^�̌������s���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        private int Search(SalesSlipSearch para)
        {
            int status = this._salesSlipSearchAcs.Search(para, (int)SimpleInqCTIAcs.ExtractSlipCdType.All, this._showEstimateInput);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //�Z�����̐ݒ�
                this.uGrid_Result_InitializeLayout(this, null);
                // ����f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���܂��B
                this.SettingGridRow();

                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveRow.Selected = true;
                }

                string sSort;
                sSort = "RowNo Asc";
                DataView dv = (DataView)this.uGrid_Result.DataSource;
                dv.Sort = sSort;
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "����f�[�^�̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// ��ʂ����������܂��B
        /// </summary>
        private void Clear()
        {
            // ���Ӑ���̕\��
            if (_currentCustomerInfo != null)
            {
                this.SetDisplayConditionInfoforScm(_currentCustomerInfo);
            }

            this._salesSlipSearchAcs.Clear();
        }

        /// <summary>
        /// �O�񌎎����������擾
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
        {
            DateTime prevTotalDay;

            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec( sectionCode.Trim(), out prevTotalDay );

            // �擾�����s���ȏꍇ�͂R�����O���Z�b�g
            if ( status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today )
            {
                prevTotalDay = DateTime.Today.AddMonths( -3 );
            }
            // �����擾
            prevTotalDay = prevTotalDay.AddDays( 1 );

            return prevTotalDay;
        }

        /// <summary>
        /// ����f�[�^�O���b�h�̍s�A�Z�����̐ݒ���s���܂��B
        /// </summary>
        private void SettingGridRow()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Result.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this.uGrid_Result.Rows.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Result.EndUpdate();
            }
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �ԓ`�敪���擾
            int debitNoteDiv = Convert.ToInt32(this._salesSlipSearchAcs.DataView[rowIndex][this._dataSet.SalesSlip.DebitNoteDivColumn.ColumnName]);

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                switch (debitNoteDiv)
                {
                    case 0:			// ���`
                        cell.Appearance.ForeColor = Color.Black;
                        break;
                    case 1:			// �ԓ`
                        cell.Appearance.ForeColor = Color.Red;
                        break;
                    case 2:			// ����
                        cell.Appearance.ForeColor = Color.Gray;
                        break;
                }
            }
        }

        /// <summary>
        /// �I���ς݃f�[�^���擾���܂��B
        /// </summary>
        /// <returns>�I���ς݃f�[�^</returns>
        private SalesSlipSearchResult GetSelectedData()
        {
            // �I���s�̃C���f�b�N�X���擾
            CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Result.DataSource];
            int index = cm.Position;

            DataView dataView = (DataView)this.uGrid_Result.DataSource;

            if (index >= 0)
            {
                SalesSlipSearchResult data = SimpleInqCTIAcs.CreateUIDataFromParamData(
                    (SalesSlipSearchResultWork)dataView[index][this._dataSet.SalesSlip.SalesSlipSearchResultWorkColumn.ColumnName]);

                return data;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// ���[�U�[�ݒ�l�ύX�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void SalesSearchConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// ��\����ԃN���X���X�g���\�z���܂��B
        /// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // �O���b�h�����\����ԃN���X���X�g���\�z
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        #region ����S�̐ݒ�}�X�^����
        /// <summary>
        /// ����S�̐ݒ�}�X�^�̌���
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void SearchSalesTtlSt(string sectionCode)
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return;
            }

            #endregion  // <Guard Phrase/>

            SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();
            ArrayList al;
            int status = salesTtlStAcs.Search(out al, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                List<SalesTtlSt> list = new List<SalesTtlSt>((SalesTtlSt[])al.ToArray(typeof(SalesTtlSt)));
                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if (( salesttl.SectionCode.Trim() == sectionCode.Trim() ) &&
                            ( salesttl.EnterpriseCode.Trim() == this._enterpriseCode.Trim() ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                if (this._salesTtlSt != null) return;

                this._salesTtlSt = list.Find(
                    delegate(SalesTtlSt salesttl)
                    {
                        if (( salesttl.SectionCode.Trim() == this._allSectionCode.Trim() ) &&
                            ( salesttl.EnterpriseCode.Trim() == this._enterpriseCode.Trim() ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            }
        }
        #endregion

        /// <summary>
        /// ���[�h����
        /// </summary>
        private void Loading()
        {
            if (_loaded) return;

            while (this._loadThread.ThreadState == System.Threading.ThreadState.Running)
            {
                System.Threading.Thread.Sleep(100);
            }

            this._salesSlipSearchAcs.DataView.Sort = "EnterpriseCode, SearchSlipNum DESC";
            this.uGrid_Result.DataSource = this._salesSlipSearchAcs.DataView;   // �O���b�h�Ƀo�C���h

            // �O���b�h�ݒ�
            this.uGrid_Result_InitializeLayout(this, null);

            _loaded = true;

        }

        /// <summary>
        /// �t�h�ݒ�w�l�k����̃R�[�h�t�H�[�}�b�g�擾(00,000,0000�c etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat(string editName)
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet(out uiset, editName);
            if (status == 0)
            {
                return string.Format("{0};-{0};''", new string('0', uiset.Column));
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// ���Ӑ�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat("tNedit_CustomerCode");
        }
        /// <summary>
        /// �a�k�R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat("tNedit_BLGoodsCode");
        }


        /// <summary>
        /// �N�����������s�p������������
        /// </summary>
        private void SearchDataForInitialSearch()
        {
            Clear();

            // �p�����[�^����
            CreateSearchParameterForInitialSearch(ref _para);

            // �������s
            Search(_para);
        }

        /// <summary>
        /// �p�����[�^����
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private void CreateSearchParameterForInitialSearch(ref SalesSlipSearch para)
        {
            if (para == null)
            {
                para = new SalesSlipSearch();
            }
            para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            para.CustomerCode = this._currentCustomerCode;
            para.AcptAnOdrStatus = ct_DefaultAcptAnOdrStatus; // 30:����

            UiSet uiset;
            uiSetControl1.ReadUISet(out uiset, "tEdit_SectionCodeAllowZero");
            para.SectionCode = new string('0', uiset.Column);
            para.SalesDateSt = GetPrevTotalDayNextDay(LoginInfoAcquisition.Employee.BelongSectionCode);
            para.SalesDateEd = DateTime.Today;
        }

        #region �O���b�h�̐ݒ���

        /// <summary>
        /// ���׏��O���b�h�ɃO���b�h�ݒ����W�J���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void LoadDetailGridSettings(
            object sender,
            EventArgs e
        )
        {
            PMSCM00101UB detailForm = sender as PMSCM00101UB;
            if (detailForm == null) return;

            // ��ړ��Ɨ�Œ���\�Ƃ���
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(detailForm.DetailGrid);
            // �O���b�h��̐ݒ���捞
            SlipGridUtil.LoadColumnInfo(detailForm.DetailGrid, GridSettings.DetailColumnsList);
        }

        /// <summary>
        /// ���׏��O���b�h�̃O���b�h�ݒ����ݒ肵�܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SetDetailGridSettings(
            object sender,
            FormClosingEventArgs e
        )
        {
            PMSCM00101UB detailForm = sender as PMSCM00101UB;
            if (detailForm == null) return;

            // ���׏���ʂ̃O���b�h����𐶐�
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(detailForm.DetailGrid);
        }

        #endregion // �O���b�h�̐ݒ���

        #region ����`�[���̓t�H�[��

        #region ���쐧��

        /// <summary>����`�[���̓t�H�[���̕\���\�C���[�W���擾���܂��B</summary>
        private static Image EnabledShowSalesSlipInputFormImage
        {
            get { return Properties.Resources.uriden; }
        }

        /// <summary>����`�[���̓t�H�[���̕\���s�C���[�W���擾���܂��B</summary>
        private static Image DisabledShowSalesSlipInputFormImage
        {
            get { return Properties.Resources.uriden_end; }
        }

        /// <summary>
        /// ����`�[���̓t�H�[���̕\�����\�ł��邩�ݒ肵�܂��B
        /// </summary>
        /// <param name="enabled">�\���\�t���O</param>
        private void SetEnabledShowSalesSlipInputForm(bool enabled)
        {
            this.btnShowSalesSlipInputForm.Enabled = enabled;
            if (enabled)
            {
                this.btnShowSalesSlipInputForm.Image = EnabledShowSalesSlipInputFormImage;
            }
            else
            {
                this.btnShowSalesSlipInputForm.Image = DisabledShowSalesSlipInputFormImage;
            }
        }

        #endregion // ���쐧��

        #region �R�}���h���C������

        /// <summary>�R�}���h���C������</summary>
        private string[] _commandLineArgs;
        /// <summary>�R�}���h���C���������擾�܂��͐ݒ肵�܂��B</summary>
        public string[] CommandLineArgs
        {
            get { return _commandLineArgs; }
            set { _commandLineArgs = value; }
        }

        /// <summary>
        /// �R�}���h���C����������̃p�����[�^���擾���܂��B
        /// </summary>
        /// <returns>
        /// �R�}���h���C������(�z��)���X�y�[�X�ŘA������������
        /// </returns>
        private string GetCommandLineParameter()
        {
            if (CommandLineArgs == null) return string.Empty;

            StringBuilder commandLineParameter = new StringBuilder();
            {
                foreach (string commandLineToken in CommandLineArgs)
                {
                    // 2010/04/30 Add >>>
                    // ���Ӑ���͓���Ȃ�
                    if (commandLineToken.Contains("/Customer")) continue;
                    // 2010/04/30 Add <<<

                    commandLineParameter.Append(commandLineToken).Append(" ");
                }
            }

            return commandLineParameter.ToString().Trim();
        }

        #endregion // �R�}���h���C������

        #region �{�c

        ///// <summary>����`�[���̓t�H�[��</summary>
        //private CMTSalesSlipInputForm _cmtSalesSlipInputForm;
        ///// <summary>����`�[���̓t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        //private CMTSalesSlipInputForm CMTSalesSlipInputForm
        //{
        //    get
        //    {
        //        if (_cmtSalesSlipInputForm == null)
        //        {
        //            _cmtSalesSlipInputForm = new CMTSalesSlipInputForm(
        //                GetCommandLineParameter(),
        //                CurrentCustomerCode
        //            );
        //            _cmtSalesSlipInputForm.FormClosing += new FormClosingEventHandler(this.HideMe);
        //        }
        //        return _cmtSalesSlipInputForm;
        //    }
        //    set { _cmtSalesSlipInputForm = value; }
        //}

        #endregion // �{�c

        //>>>2010/06/17
        ///// <summary>����`�[���̓t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        //private MAHNB01010UA CMTSalesSlipInputForm
        //{
        //    get
        //    {
        //        if (_cmtSalesSlipInputForm == null)
        //        {
        //            _cmtSalesSlipInputForm = new MAHNB01010UA(
        //                GetCommandLineParameter(),
        //                0,
        //                0,
        //                "000000000",
        //                string.Empty,
        //                string.Empty,
        //                0,
        //                this._currentCustomerCode
        //                ,0 // 2010/04/30
        //            );
        //            _cmtSalesSlipInputForm.FormClosing += new FormClosingEventHandler(this.HideMe);
        //        }
        //        return _cmtSalesSlipInputForm;
        //    }
        //    set { _cmtSalesSlipInputForm = value; }
        //}
        //<<<2010/06/17

        /// <summary>
        /// ����`�[���̓t�H�[����\�����܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����`�[���̓t�H�[���ɓ��Ӑ����W�J��<br/>
        /// <c>false</c>:����`�[���̓t�H�[���ɓ��Ӑ���𖢓W�J
        /// </returns>
        private bool ShowSalesSlipInputFormIf()
        {
            //>>>2010/06/17
            //bool isConfirm = true;
            //try
            //{
            //    if (!CMTSalesSlipInputForm.CustomerCode.Equals(this._currentCustomerCode))
            //    {
            //        CMTSalesSlipInputForm.CustomerCode = this._currentCustomerCode;
            //        isConfirm = CMTSalesSlipInputForm.LinkCommunicationTool();
            //    }
            //    CMTSalesSlipInputForm.Show();
            //    if (CMTSalesSlipInputForm.WindowState.Equals(FormWindowState.Minimized))
            //    {
            //        CMTSalesSlipInputForm.WindowState = FormWindowState.Normal;
            //    }
            //    CMTSalesSlipInputForm.Activate();
            //}
            //catch (ObjectDisposedException ex)
            //{
            //    Debug.WriteLine(ex);

            //    // ���ɏI�����삵�Ă���̂ŁA�C���X�^���X�����Z�b�g���čĕ\��
            //    CMTSalesSlipInputForm = null;
            //    isConfirm = ShowSalesSlipInputFormIf();
            //}
            //return isConfirm;

            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return false;

            // ���O�C���p�����[�^����ݒ�
            StringBuilder param = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        if (argument.Trim().Contains("/Customer")) break;
                        param.Append(argument + " ");
                    }
                }
            }

            param.Append("/CTI ");
            param.Append(this._currentCustomerCode.ToString()); // ���Ӑ�R�[�h
            Process.Start(programPath, param.ToString());

            return true;
            //<<<2010/06/17

        }

        /// <summary>
        /// ���g���B���܂��B
        /// </summary>
        /// <remarks>
        /// ����`�[���̓t�H�[���̏I������ƘA�����邽�߂Ɏg�p���Ă��܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void HideMe(object sender, FormClosingEventArgs e)
        {
            btn_Close_Click(sender, e);
        }

        /// <summary>
        /// �����̏ꍇ�A�ŏ����̏�Ԃ�ʏ�̏�Ԃɐݒ肵�܂��B
        /// </summary>
        /// <param name="visible">�����t���O</param>
        private void SetWindowStateNormalIf(bool visible)
        {
            if (visible)
            {
                if (this.ParentForm != null)
                {
                    if (this.ParentForm.WindowState.Equals(FormWindowState.Minimized))
                    {
                        this.ParentForm.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    if (this.WindowState.Equals(FormWindowState.Minimized))
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                }
            }
        }

        #endregion // ����`�[���̓t�H�[��

        /// <summary>
        /// ���אݒ�ۑ�
        /// </summary>
        public void SaveDetailSetting()
        {
            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // MEMO:�O���b�h��̕\���ݒ��ۑ�
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }

        /// <summary>
        /// Visible�ݒ�C�x���g�R�[������
        /// </summary>
        private void SettingVisibleEventCall(bool visible)
        {
            // ����`�[���̓t�H�[����\���\�Ƃ���
            SetEnabledShowSalesSlipInputForm(true); // ����`�[���̓t�H�[����\�������ۂɖ����ɂȂ�
            // �ŏ�������Ă���ꍇ�A�ʏ�̏�Ԃ�
            SetWindowStateNormalIf(visible);

            if (this.SettingVisible != null)
            {
                this.SettingVisible(visible);
            }
        }

        # endregion // Private Method

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        # region �e��R���g���[���C�x���g����
        /// <summary>
        /// ��� ���[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMSCM00101UA_Load(object sender, EventArgs e)
        {
            Loading();

            // ���Ӑ���̕\��
            if (_currentCustomerInfo != null)
            {
                this.SetDisplayConditionInfoforScm(_currentCustomerInfo);
            }

            // �S�̍��ږ��̂̐ݒ�
            if (_alItmDspNm != null)
            {
                this.ulabel_OfficeTelNoTitle.Text = _alItmDspNm.OfficeTelNoDspName;
                this.ulabel_HomeTelNoTitle.Text = _alItmDspNm.HomeTelNoDspName;
                this.ulabel_OfficeFaxNoTitle.Text = _alItmDspNm.OfficeFaxNoDspName;
            }

            this.SettingVisibleEventCall(true);
        }

        /// <summary>
        /// �t�H�[���\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM00101UA_Shown(object sender, EventArgs e)
        {
            this.timer_Search.Enabled = true;
        }

        #region �O���b�h�֘A
        /// <summary>
        /// �������ʃO���b�h���C�A�E�g�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string codeFormat = "#0;-#0;''";
            string moneyFormat = "#,##0;-#,##0;''";
            string dateFormat = "yyyy/MM/dd";

            int visiblePosition = 1;
            string acptAnOdrStatusTiTle = "";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            switch (_para.AcptAnOdrStatus)
            {
                case 10:
                case 15:
                case 16:
                    acptAnOdrStatusTiTle = "����";
                    break;
                case 20: acptAnOdrStatusTiTle = "��"; break;
                case 30: acptAnOdrStatusTiTle = "����"; break;
                case 40: acptAnOdrStatusTiTle = "�ݏo"; break;
                default: acptAnOdrStatusTiTle = "����"; break;
            }

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            #region 
            // ��
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Caption = "No";
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Width = 60;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 2008.11.07 add end [7071]

            // �����
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "��";
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �`�[�ԍ�
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�";
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Format = codeFormat;

            // �`�[���
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "�`�[���";
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�`�[�敪
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Caption = "�`�[�敪";
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //���Ӑ�R�[�h
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�R�[�h";
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = GetCustomerCodeFormat();

            //���Ӑ於
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於";
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �S���Җ�
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "�S����";
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���s��
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Caption = "���s��";
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �󒍎Җ�
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "�󒍎�";
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //������z�i�Ŕ��j
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "���z";
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;

            //�����
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "�����";
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Format = moneyFormat;

            //�Ǘ��ԍ�
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Caption = "�Ǘ��ԍ�";
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�ޕʌ^��
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "�ޕʌ^��";
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�Ԏ�
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Caption = "�Ԏ�";
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �^��
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Caption = "�^��";
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�ԍ�
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption = "�ԍ�";
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            //���͓�
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Caption = "���͓�";
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Format = dateFormat;

            //�v���
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Caption = "�v���";
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //�`�[���l
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Caption = "�`�[���l";
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //���}�[�N1
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Caption = "���}�[�N�P";
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //���_��
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Caption = "���_";
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;


            //���喼
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Caption = "���喼";
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Caption = "������R�[�h";
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Format = GetCustomerCodeFormat();

            //�����於
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Caption = "�����於";
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            #endregion
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
            else
            {
                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveCell = this.uGrid_Result.ActiveRow.Cells[0];
                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                    this.uGrid_Result.ActiveRow.Selected = true;
                }
            }
        }

        /// <summary>
        /// �O���b�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement != null)
            {
                objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                    ( typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement) ));

                // �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
                if (objRowCellAreaUIElement == null)
                {
                    return;
                }
            }

            if (this.uGrid_Result.ActiveRow != null)
            {
                this.uButton_ShowDetail_Click(null, new EventArgs());
            }
        }

        #endregion // �O���b�h  

        /// <summary>
        /// �t�H�[���I���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMSCM00101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_disposed) return;

            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // �O���b�h��̕\���ݒ��ۑ�
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }

      

        /// <summary>
        /// �����^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_Search_Tick(object sender, EventArgs e)
        {
            timer_Search.Enabled = false;

            SearchDataForInitialSearch();

            // ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

            // ��\����ԃR���N�V�����N���X���C���X�^���X��
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.SalesSlip);

            // �`�[����і��׃O���b�h��̗�ݒ�̕ύX
            // ��ړ��Ɨ�Œ���\�Ƃ���
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this.uGrid_Result);
            // �O���b�h��̐ݒ���捞
            SlipGridUtil.LoadColumnInfo(this.uGrid_Result, GridSettings.SlipColumnsList);

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = ( this._salesTtlSt.InpAgentDispDiv == 1 );
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = ( this._salesTtlSt.AcpOdrAgentDispDiv == 1 );
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = !( this._companyInf.SecMngDiv == 1 );
        }

        /// <summary>
        /// ���׃{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ShowDetail_Click(object sender, EventArgs e)  // MEMO:���׃{�^���N���b�N
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            // ���ݑI���s�̔���`�[���擾
            SalesSlipSearchResult salesSlipSearchResult = this.GetSelectedData();

            // ���׎Q�Ɖ�ʂ��N��
            PMSCM00101UB searchDetail = new PMSCM00101UB(_salesSlipSearchAcs, salesSlipSearchResult);

            // ���ו\����ʂ̃O���b�h��������[�h���ɐݒ�
            searchDetail.Load += new EventHandler(this.LoadDetailGridSettings);
            // ���ו\����ʂ̃O���b�h������N���[�Y���Ɏ擾
            searchDetail.FormClosing += new FormClosingEventHandler(this.SetDetailGridSettings);

            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
            }
        }

        /// <summary>
        /// ����`�[���̓{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnShowSalesSlipInputForm_Click(object sender, EventArgs e)
        {
            if (this._currentCustomerCode == 0) return;    // ���Ӑ�R�[�h�̐ݒ肪������Ή������Ȃ�

            Cursor cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���`�t�H�[����\��
                bool isConfirm = ShowSalesSlipInputFormIf();
            }
            finally
            {
                this.Cursor = cursor;
            }

            // �{�^���ݒ�𑀍�s�̏�ԂɕύX
            SetEnabledShowSalesSlipInputForm(false);
        }

        /// <summary>
        /// �I���{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.SaveDetailSetting();
            this.Close();
        }

        # endregion // �e��R���g���[���C�x���g����
    }

    #region �`�[�O���b�h

    /// <summary>
    /// �`�[�O���b�h���[�e�B���e�B
    /// </summary>
    /// <remarks>
    /// �ȉ��̋@�\�ŎQ�Ƃ��Ă��܂��B<br/>
    /// �E���㗚���Ɖ�<br/>
    /// �E�d���`�[�Ɖ�<br/>
    /// �E�d�������Ɖ�
    /// </remarks>
    public static class SlipGridUtil
    {
        #region ���ݒ�

        /// <summary>
        /// ������Ɨ�Œ���\�Ƃ��܂��B
        /// </summary>
        /// <param name="grid">�ΏۃO���b�h</param>
        public static void EnableAllowColSwappingAndFixedHeaderIndicator(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return;

            #endregion // Guard Phrase

            // ��������\�ɂ���
            grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // ��Œ���\�ɂ���
            grid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
        }

        #endregion // ���ݒ�

        #region �ݒ�̓W�J

        /// <summary>
        /// �O���b�h�̕\���ݒ��ǂݍ��݂܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04004UA.Deserialize()
        /// </remarks>
        /// <param name="xmlFileName">�ݒ�XML�t�@�C����</param>
        public static GridSettingsType ReadGridSettings(string xmlFileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);
            if (!UserSettingController.ExistUserSetting(filePath)) return new GridSettingsType();

            GridSettingsType gridSettings = null;
            try
            {
                gridSettings = UserSettingController.DeserializeUserSetting<GridSettingsType>(filePath);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                return new GridSettingsType();
            }
            return gridSettings;
        }

        /// <summary>
        /// �������荞�݂܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04001UA.LoadGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">�ΏۃO���b�h</param>
        /// <param name="columnInfoList">����</param>
        public static void LoadColumnInfo(
            UltraGrid grid,
            List<ColumnInfo> columnInfoList
        )
        {
            #region Guard Phrase

            if (columnInfoList == null || columnInfoList.Count.Equals(0)) return;

            #endregion // Guard Phrase

            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in columnInfoList)
            {
                try
                {
                    UltraGridColumn ultraGridColumn = grid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    {
                        ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                        // �\���E��\���͉�ʂŐݒ�ł��Ȃ��̂ň����p���Ȃ�
                        //ultraGridColumn.Hidden = columnInfo.Hidden;
                        ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                        ultraGridColumn.Width = columnInfo.Width;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                }
            }
        }

        #endregion // �ݒ�̓W�J

        #region �ݒ�̕ۑ�

        /// <summary>
        /// �O���b�h�̕\���ݒ��ۑ����܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04004UA.Serialize()
        /// </remarks>
        /// <param name="gridSettings">�O���b�h�̐ݒ���</param>
        /// <param name="xmlFileName">�ݒ�XML�t�@�C����</param>
        public static void StoreGridSettings(
            GridSettingsType gridSettings,
            string xmlFileName
        )
        {
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);

                UserSettingController.SerializeUserSetting(gridSettings, fileName);

                #region �����R�[�h
                //CustPtrSalesUserConst test = new CustPtrSalesUserConst();
                //test.OutputPattern = new string[0];
                //test.SlipColumnsList = new List<ColumnInfo>();
                //test.DetailColumnsList = columnInfoList; 
                //test.RedSlipColumnsList = new List<ColumnInfo>();
                //test.EnabledConditionList = new List<string>();
                //UserSettingController.SerializeUserSetting(test, fileName);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// ���񃊃X�g�𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// �y�Q�l�z���Ӑ�d�q�����FPMKAU04001UA.SaveGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">�ΏۃO���b�h</param>
        /// <returns>�ΏۃO���b�h������𒊏o���A���X�g�ŕԂ��܂��B</returns>
        public static List<ColumnInfo> CreateColumnInfoList(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return new List<ColumnInfo>();

            #endregion // Guard Phrase

            List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
            {
                foreach (UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].Columns)
                {
                    columnInfoList.Add(new ColumnInfo(
                        ultraGridColumn.Key,
                        ultraGridColumn.Header.VisiblePosition,
                        ultraGridColumn.Hidden,
                        ultraGridColumn.Width,
                        ultraGridColumn.Header.Fixed
                    ));
                }
            }
            return columnInfoList;
        }

        #endregion // �ݒ�̕ۑ�
    }

    #region �`�[�O���b�h�ݒ���

    /// <summary>
    /// �`�[�O���b�h�ݒ���N���X
    /// </summary>
    [Serializable]
    public class SlipGridSettings : CustPtrSalesUserConst
    {
        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SlipGridSettings() : base()
        {
            base.OutputPattern          = new string[0];
            base.SlipColumnsList        = new List<ColumnInfo>();
            base.DetailColumnsList      = new List<ColumnInfo>();
            base.RedSlipColumnsList     = new List<ColumnInfo>();
            base.EnabledConditionList   = new List<string>();
        }

        #endregion // Constructor
    }

    #endregion // �`�[�O���b�h�ݒ���

    #endregion // �`�[�O���b�h
}