//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC-UOE���[�����b�Z�[�W�V�K�쐬
// �v���O�����T�v   : PCC-UOE���[�����b�Z�[�W�V�K�쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �� �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PCC-UOE���[�����b�Z�[�W�V�K�쐬�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC-UOE���[�����b�Z�[�W�V�K�쐬�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.08</br>
    /// <br></br>
    /// </remarks>
    public partial class PMPCC01001UB : Form
    {
        # region ��Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMPCC01001UB()
        {
            InitializeComponent();
            //��ƃR�[�h
            _erterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._sendButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Send"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ���O�C���S����
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._pccMailDtAcs = new PccMailDtAcs();
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        # region ��Private Members
        private PccMailDtAcs _pccMailDtAcs;
       
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // �L�����Z���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _sendButton;            // ���M�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ���O�C���S���Җ���
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        private string _erterpriseCode = null;
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        private string _sectionCode = null;
        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�Z�b�g
        /// </summary>
        private DataSet _customerDateSet = null;
        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�A�N�Z�X�N���X
        /// </summary>
        private PccCmpnyStAcs _pccCmpnyStAcs = null;
        /// <summary>
        /// ���Ӑ�f�[�^�̔ԍ�
        /// </summary>
        private int _customerDataIndex;
        // ���Ӑ�e�[�v��
        private Hashtable _customerHTable;
        /// <summary>
        /// �������̃��X�g
        /// </summary>
        private List<PccMailDt> _pccMailDtListOld;
        #endregion

        #region ��Const Members
        private const string ASSEMBLY_ID = "PMPCC01001U";

        private const string BLSELECT_TITLE = "SELECT";
        private const string BLSELECT_NAME = "";
        private const string PCCCUSTOMERCODE_TITLE = "PCC���Ӑ�R�[�h";
        private const string PCCCUSTOMERNAME_TITLE = "PCC���Ӑ�";
        //�⍇������B
        private const string INQCONDITION_TITLEB = "GUID";
        private const string CUSTOMER_TABLE = "CUSTOMER_TABLE";
        private const string INF_NOT_FOUND = "�Y������f�[�^������܂���B";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        #endregion

        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : PCC-UOE���[�����b�Z�[�W�ݒ�����������܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void PMPCC01001UB_Load(object sender, EventArgs e)
        {
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();
            //���Ӑ�O���b�h�̏�����
            InitCustomerDateSet();
            InitCustomerGrid();
            InitCustomerDate();
            // �������t�H�[�J�X�ݒ�
            this.uCheckEditor_SelectAll.Focus();
            this.tEdit_PccMailDocCnts.Value = string.Empty;
            this.tEdit_PccMailTitle.Value = string.Empty;
            DispToPccMailDt(out this._pccMailDtListOld);
            uCheckEditor_SelectAll.Focus();
        }

        /// <summary>���C���c�[���o�[�}�l�[�W���[ToolClick</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// Note       : ���C���c�[���o�[�}�l�[�W���[��ToolClick�����ł��B<br />
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //�A�N�e�B�u��ԂɂȂ��Ă���c�[���̃t�H�[�J�X���N���A����
            e.Tool.IsActiveTool = false;
            switch (e.Tool.Key)
            {
                // ����{�^��
                case "ButtonTool_Cancel":
                    {
                        this.CloseProc();
                        break;
                    }
                //�����Ӑ�{�^��
                case "ButtonTool_Send":
                    {
                        this.SendProc();
                        break;
                    }
            }
        }

        /// <summary>
        ///�S�ĂɃ`�F�b�N �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �S�ĂɃ`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08/</br>
        /// </remarks>
        private void uCheckEditor_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uGrid_Customer == null || this.uGrid_Customer.Rows.Count == 0)
            {
                return;
            }
            int gridCount = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count;
            for (int i = 0; i < gridCount; i++)
            {
                DataRow dataRow = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i];
                dataRow[BLSELECT_TITLE] = uCheckEditor_SelectAll.Checked;
            }
        }

        #endregion

        #region ��Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^���̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._sendButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// ���Ӑ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDateSet()
        {
            _customerDateSet = new DataSet();

            // �e�[�u���̒�`
            DataTable customerDt = new DataTable(CUSTOMER_TABLE);
            customerDt.Columns.Add(BLSELECT_TITLE, typeof(bool));
            customerDt.Columns.Add(PCCCUSTOMERCODE_TITLE, typeof(int));
            customerDt.Columns.Add(PCCCUSTOMERNAME_TITLE, typeof(string));
            customerDt.Columns.Add(INQCONDITION_TITLEB, typeof(string));
            this._customerDateSet.Tables.Add(customerDt);

        }

        /// <summary>
        /// ���Ӑ�O���b�h�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void InitCustomerGrid()
        {
            if (_customerDateSet.Tables[CUSTOMER_TABLE] != null)
            {
                this.uGrid_Customer.DataSource = _customerDateSet.Tables[CUSTOMER_TABLE].DefaultView;
                UltraGridBand editBand = this.uGrid_Customer.DisplayLayout.Bands[CUSTOMER_TABLE];
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
                this.uGrid_Customer.DisplayLayout.Override.EditCellAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
                //��̕\��Style�ݒ�
                editBand.Columns[BLSELECT_TITLE].Header.Caption = BLSELECT_NAME;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Header.Caption = PCCCUSTOMERCODE_TITLE;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Header.Caption = PCCCUSTOMERNAME_TITLE;
                editBand.Columns[INQCONDITION_TITLEB].Header.Caption = INQCONDITION_TITLEB;

                //�O���b�h�^�C�v
                editBand.Columns[BLSELECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                editBand.Columns[BLSELECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                editBand.Columns[PCCCUSTOMERCODE_TITLE].Hidden = true;
                editBand.Columns[INQCONDITION_TITLEB].Hidden = true;

                //�������l�̐ݒ�
                editBand.Columns[BLSELECT_TITLE].DefaultCellValue = false;
                editBand.Columns[BLSELECT_TITLE].Width = 10;
                editBand.Columns[PCCCUSTOMERNAME_TITLE].Width = 125;
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�̏�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�f�[�^�̏��������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void InitCustomerDate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
            parsePccCmpnySt.InqOtherEpCd = this._erterpriseCode;
            parsePccCmpnySt.InqOtherSecCd = this._sectionCode;
            List<PccCmpnySt> pccCmpnyStList = null;
            int index = 0;
            if (this._pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }
            status = this._pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._customerHTable == null)
                {
                    this._customerHTable = new Hashtable();
                }
                else
                {
                    this._customerHTable.Clear();
                }
                string inqCondition = string.Empty;
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    //�x�[�X�ݒ�ΏۊO
                    if (string.IsNullOrEmpty(pccCmpnySt.InqOriginalEpCd.Trim()) || string.IsNullOrEmpty(pccCmpnySt.InqOriginalSecCd.TrimEnd())) //@@@@20230303
                    {
                        continue;
                    }
                    inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                        + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
                    if (!this._customerHTable.ContainsKey(inqCondition))
                    {
                        PccCmpnyStToDataSet(pccCmpnySt.Clone(), index);
                        index++;
                    }
                    // �N���X�f�[�^�Z�b�g�W�J����
                }
                this._customerDataIndex = 0;
                this.uGrid_Customer.Rows[this._customerDataIndex].Activate();
                this.uGrid_Customer.Rows[this._customerDataIndex].Selected = true;
            }
        }

        /// <summary>
        /// ���Ӑ�O���b�h�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="pccCmpnySt">PCC���Аݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�O���b�h�f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PccCmpnyStToDataSet(PccCmpnySt pccCmpnySt, int index)
        {
            string inqCondition = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                       + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();
            if ((index < 0) || (this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this._customerDateSet.Tables[CUSTOMER_TABLE].NewRow();
                this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this._customerDateSet.Tables[CUSTOMER_TABLE].Rows.Count - 1;
            }
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][BLSELECT_TITLE] = false;
            
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERCODE_TITLE] = pccCmpnySt.PccCompanyCode;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][PCCCUSTOMERNAME_TITLE] = pccCmpnySt.PccCompanyName;
            this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[index][INQCONDITION_TITLEB] = inqCondition;

            if (this._customerHTable.ContainsKey(inqCondition))
            {
                this._customerHTable.Remove(inqCondition);
            }
            this._customerHTable.Add(inqCondition, pccCmpnySt);

        }

        /// <summary>
        ///�L�����Z���{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        public void CloseProc()
        {
            List<PccMailDt> pccMailDtList = null;
            //��ʏ�񃁁[�����b�Z�[�W�i�[����
            DispToPccMailDt(out pccMailDtList);
            if (pccMailDtList != null && this._pccMailDtListOld != null)
            {
                bool isEquals = ListCompare(pccMailDtList);
                 if (!isEquals)
               {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_QUESTION,	// �G���[���x��
                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "�ҏW���̃f�[�^������܂��B" + "\r\n" + 
                        "�p�����Ă���낵���ł����H",	// �\�����郁�b�Z�[�W 
                        0,									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2);		// �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {   
                                break;
                            }
                        case DialogResult.No:
                            {                               
                                return;
                            }
                        default:
                            {
                                uCheckEditor_SelectAll.Focus();                                
                                return;
                            }
                    }
                }

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// ���PCC�i�ڃO���[�v�N���X��r
        /// </summary>
        /// <param name="pccMailDtList">��ʃ��[�����b�Z�[�W���X�g</param>
        /// <remarks>
        /// <br>Note       : ���PCC�i�ڃO���[�v�N���X���r���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ListCompare(List<PccMailDt> pccMailDtList)
        {
            bool isEqualsValue = true;
            if (pccMailDtList.Count != this._pccMailDtListOld.Count)
            {
                isEqualsValue = false;
                return isEqualsValue;
            }
            for(int i = 0; i < pccMailDtList.Count; i++)
            {
                if(!pccMailDtList[i].Equals(this._pccMailDtListOld[i]))
                {
                    isEqualsValue = false;
                    return isEqualsValue;
                }
            }
            if (!string.IsNullOrEmpty(this.tEdit_PccMailTitle.DataText) || !string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.DataText))
            {
                 isEqualsValue = false;
                    return isEqualsValue;
            }
            return isEqualsValue;
        }

        /// <summary>
        /// ��ʏ�񃁁[�����b�Z�[�W�i�[����
        /// </summary>
        /// <param name="pccMailDtList">���[�����b�Z�[�W�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�����b�Z�[�W�i�[�����Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08 </br>
        /// </remarks>
        private void DispToPccMailDt(out List<PccMailDt> pccMailDtList)
        {
            int gridCount = this.uGrid_Customer.Rows.Count;
            PccCmpnySt pccCmpnySt = null;            
            pccMailDtList = null;
            if (gridCount > 0)
            {
               pccMailDtList = new List<PccMailDt>();
               for (int i = 0; i < gridCount; i++)
               {
                   UltraGridRow dataRow = this.uGrid_Customer.Rows[i];
                   bool checkedFlag = (bool)dataRow.Cells[BLSELECT_TITLE].Value;
                   bool dataChecked = (bool)dataRow.Cells[BLSELECT_TITLE].DataChanged;

                   if (!checkedFlag && !dataChecked)
                   {
                       continue;
                   }
                   else
                   {
                       SetPccMailDt(pccCmpnySt, pccMailDtList, i);
                   }
               }
            }
        }

        /// <summary>
        ///��ʏ�񃁁[�����b�Z�[�W�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�����b�Z�[�W�i�[�����Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void SetPccMailDt(PccCmpnySt pccCmpnySt, List<PccMailDt> pccMailDtList,int i)
        {           
            string inqConditionCus = string.Empty;
            string guid = (string)this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i][INQCONDITION_TITLEB];
            pccCmpnySt = ((PccCmpnySt)this._customerHTable[guid]).Clone();
            inqConditionCus = pccCmpnySt.InqOriginalEpCd.Trim() + pccCmpnySt.InqOriginalSecCd.TrimEnd() //@@@@20230303
                   + pccCmpnySt.InqOtherEpCd.TrimEnd() + pccCmpnySt.InqOtherSecCd.TrimEnd();

            PccMailDt pccMailDt = new PccMailDt();
            pccMailDt.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDt.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
            pccMailDt.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
            pccMailDt.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
            pccMailDt.UpdateDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            pccMailDt.UpdateTime = Convert.ToInt32(DateTime.Now.ToString("HHmmssfff"));
            pccMailDt.PccMailTitle = tEdit_PccMailTitle.Text.TrimEnd();
            pccMailDt.PccMailDocCnts = tEdit_PccMailDocCnts.Text.TrimEnd();
            pccMailDtList.Add(pccMailDt);
        }

        /// <summary>
        ///���M�{�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M�{�^�����s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        public void SendProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //���̓`�F�b�N���s���B
            string message = string.Empty;
            Control control = null;
            uCheckEditor_SelectAll.Focus();
            
            
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return ;
            }
            List<PccMailDt> pccMailDtList = null;
            DispToPccMailDt(out pccMailDtList);
            if (pccMailDtList != null && pccMailDtList.Count > 0)
            {
                status = this._pccMailDtAcs.Write(ref pccMailDtList);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.DialogResult = DialogResult.OK;
                            //WebSync�̋@�\�ɂ��T�[�o�[�Ƀ��b�Z�[�W�𑗐M����B
                            WebSyncProc(pccMailDtList);
                            this.Close();
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                        {
                            TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                                status,								// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��
                            this.uCheckEditor_SelectAll.Focus();
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._pccMailDtAcs);
                            break;
                            
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							// �v���O��������
                                "SendProc",							// ��������
                                TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                                ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                                status,								// �X�e�[�^�X�l
                                this._pccMailDtAcs,					// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// WebSync�̋@�\�ɂ��T�[�o�[�Ƀ��b�Z�[�W���M�B
        /// </summary>
        /// <param name="pccMailDtList">���[�����b�Z�[�W�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : WebSync�̋@�\�ɂ��T�[�o�[�Ƀ��b�Z�[�W�𑗐M����B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private void WebSyncProc(List<PccMailDt> pccMailDtList)
        {
            if (pccMailDtList != null && pccMailDtList.Count > 0)
            {
                foreach (PccMailDt pccMailDt in pccMailDtList)
                {
                    SCMChecker.NotifyOtherSidePCCUOEMessage(pccMailDt.InqOriginalEpCd.Trim(), pccMailDt.InqOriginalSecCd, pccMailDt.InqOtherEpCd, pccMailDt.InqOtherSecCd, pccMailDt.UpdateDate, pccMailDt.UpdateTime, pccMailDt.PccMailTitle, pccMailDt.PccMailDocCnts);//@@@@20230303
                }
            }
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool exsitTrue = false;
            //�O���b�h�̃`�F�b�N�{�b�N�X���S��OFF�̏ꍇ�G���[�Ƃ���B
            int gridCount = this.uGrid_Customer.Rows.Count;
            for (int i = 0; i < gridCount; i++)
            {
                UltraGridRow dataRow = this.uGrid_Customer.Rows[i];
                bool selected = (bool)this._customerDateSet.Tables[CUSTOMER_TABLE].Rows[i][BLSELECT_TITLE];
                if (selected)
                {
                    exsitTrue = true;
                    break;
                }
            }
            if (!exsitTrue)
            {
                // ���Ӑ�R�[�h
                control = this.uGrid_Customer;
                message = "���悪�I������Ă��܂���B";
                return (false);
            }
            if (string.IsNullOrEmpty(this.tEdit_PccMailTitle.Text.TrimEnd()) && string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.Text.TrimEnd()))
            {
                // ����
                control = this.tEdit_PccMailTitle;
                message = "�����A�{���������͂ł��B";
                return (false);
            }
            else if (string.IsNullOrEmpty(this.tEdit_PccMailTitle.Text.TrimEnd()))
            {
                // ����
                control = this.tEdit_PccMailTitle;
                message = "�����������͂ł��B";
                return (false);
            }
            else if (string.IsNullOrEmpty(this.tEdit_PccMailDocCnts.Text.TrimEnd()))
            {
                // ���{��
                control = this.tEdit_PccMailDocCnts;
                message = "�{���������͂ł��B";
                return (false);
            }
            string pccMailDocCnts = this.tEdit_PccMailDocCnts.Text.TrimEnd();
            string[] pccMailDocCntsArr = pccMailDocCnts.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (pccMailDocCntsArr.Length > 10)
            {
                // ���Ӑ�R�[�h
                control = this.tEdit_PccMailDocCnts;
                message = "�{����10�s�ȓ��œ��͂��ĉ������B";
                return (false);
            }
            return true;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="operation">�I�y���[�V����</param>
        /// <param name="erObject">�G���[�I�u�W�F�N�g</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, string operation, object erObject)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_800_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExclusiveTransaction",				// ��������
                            operation,							// �I�y���[�V����
                            ERR_801_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            erObject,							// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }
        #endregion

    }
}