using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �^�M�z�ݒ菈��
    /// </summary>
    ///<remarks>
    /// <br>Note        : �^�M�z�ݒ菈��UI�t�H�[���N���X</br>
    /// <br>Programmer  : 30418 ���i</br>
    /// <br>Date        : 2008/12/02</br>
    /// <br>Update Note : 2009/03/12 30414 �E ��QID:12310�Ή�</br>
    /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
    /// <br>            : 2013/06/18�z�M��</br>
    /// <br>            : Redmine #35501 �^�M�z�ݒ�ҋ@�d�l�̒ǉ�</br>
    /// <br>UpDate Note : ���N 2013/05/28</br>
    /// <br>            : Redmine#35501 #10�̑Ή�</br>
    /// <br>UpDate Note : ���N 2013/06/24</br>
    /// <br>            : Redmine#35501 #14�̑Ή�</br>
    /// <br>UpDate Note : gezh 2013/08/20</br>
    /// <br>            : Redmine#35501 #18�̑Ή�</br>
    /// </remarks>
    public partial class PMKHN09261UA : Form
    {

        #region �v���C�x�[�g�ϐ�

        #region �N���X

        /// <summary>�^�M�z�ݒ菈�� ���o�����N���X</summary>
        private CustCreditCndtn _custCreditCndtn = null;

        /// <summary>�^�M�z�ݒ菈�� �A�N�Z�X�N���X</summary>
        private CustomerCreditAcs _customerCreditAcs = null;

        /// <summary>���Ӑ挟���A�N�Z�X�N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>���Ӑ���f�[�^�N���X</summary>
        private CustomerInfo _customerInfo;

        /// <summary>MACMN00001C)UI�X�L���ݒ�R���g���[��</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #region �f�[�^�Z�b�g

        /// <summary>�^�M�z�ݒ菈�� ���ʃf�[�^�Z�b�g</summary>
        private CustomerChangeDataSet _dataSet = null;

        #endregion // �f�[�^�Z�b�g

        #endregion // �N���X

        /// <summary>�{�^���p�C���[�W���X�g</summary>
        private ImageList _imageList16 = null;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>�����_�R�[�h</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>���O�C�����[�U�[�R�[�h</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>���O�C�����[�U�[��</summary>
        private string _loginUserName = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCode = 0;

        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
        /// <summary>�J�E���^�[</summary>
        private int counter = 0;
        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<

        // ----- ADD ���N 2013/06/24 for Redmine#35501 ----->>>>>
        private bool _waitFlag;
        // ----- ADD ���N 2013/06/24 for Redmine#35501 -----<<<<<
        #endregion // �v���C�x�[�g�ϐ�

        #region ���b�Z�[�W�萔

        /// <summary>�G���[���b�Z�[�W�F�u���Ӑ悪�I������Ă��܂���B�v</summary>
        private const string CT_EMPTY_CUSTOMER_CODE = "���Ӑ悪�I������Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u���Ӑ�i�J�n�j�͓��Ӑ�i�I���j���������ȃR�[�h���w�肵�Ă��������B�v</summary>
        private const string CT_INVALID_CUSTOMER_CODE = "���Ӑ�i�J�n�j�͓��Ӑ�i�I���j���������ȃR�[�h���w�肵�Ă��������B";

        /// <summary>�G���[���b�Z�[�W�F�u�^�M�z�N���A�̑Ώۍ��ڂ��I������Ă��܂���B�v</summary>
        private const string CT_MISSING_CLEAR_TARGET = "�^�M�z�N���A�̑Ώۍ��ڂ��I������Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�J�n���Ӑ�R�[�h���I������Ă��܂���B�v</summary>
        private const string CT_CUSTOMER_RANGE_START_MISSING = "�J�n���Ӑ�R�[�h���I������Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�I�����Ӑ�R�[�h���I������Ă��܂���B�v</summary>
        private const string CT_CUSTOMER_RANGE_END_MISSING = "�I�����Ӑ�R�[�h���I������Ă��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�w�肳�ꂽ���Ӑ�R�[�h�͑��݂��܂���B�v</summary>
        private const string CT_CUSTOMER_NOT_FOUND = "�w�肳�ꂽ���Ӑ�R�[�h�͑��݂��܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u�X�V�Ώۂ̃f�[�^������܂���B�v</summary>
        private const string CT_RESULT_NOT_FOUND = "�X�V�Ώۂ̃f�[�^������܂���B";

        /// <summary>�G���[���b�Z�[�W�F�u ���̃f�[�^���������܂����B�v</summary>
        private const string CT_RESULT_PROCESSED_COUNT = " ���̃f�[�^���������܂����B";

        /// <summary>���b�Z�[�W�F�u�X�V���Ă��X�����ł����H�v</summary>
        private const string CT_READY_TO_PROCESS = "�X�V���Ă��X�����ł����H";

        // --- ADD 2009/01/15 ��QID:10087�Ή�------------------------------------------------------>>>>>
        /// <summary>�G���[���b�Z�[�W�F�u���Ӑ�����̒l���s���ł��B�v</summary>
        private const string CT_TOTALDAY_ERROR = "���Ӑ�����̒l���s���ł��B";
        // --- ADD 2009/01/15 ��QID:10087�Ή�------------------------------------------------------<<<<<

        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
        /// <summary>���b�Z�[�W�F�u�ҋ@�������J�n���Ă�낵���ł����H�v</summary>
        private const string CT_READY_TO_WAITNOW = "�ҋ@�������J�n���Ă�낵���ł����H";

        /// <summary>���b�Z�[�W�F�u�ҋ@�������J�n���Ă�낵���ł���(�����J�n���Ԃ͗����ł�)�H�v</summary>
        private const string CT_READY_TO_WAITTOMORROW = "�ҋ@�������J�n���Ă�낵���ł����H\r\n(�����J�n���Ԃ͗����ł�)";
        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
        #endregion // ���b�Z�[�W�萔

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09261UA()
        {
            InitializeComponent();
            
            // �����ݒ�
            InitializeVariable();
        }

        /// <summary>
        /// �t�H�[���\����C�x���g�i�����t�H�[�J�X�֘A�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN09261UA_Shown(object sender, System.EventArgs e)
        {
            // �����t�H�[�J�X�i���Ӑ�J�n�j
            this.tNedit_CustomerCd_St.Focus();
        }

        // ----- ADD ���N�@2013/06/24�@Redmine#35501 ----->>>>>
        /// <summary>
        /// �ҋ@Flag
        /// </summary>
        public bool WaitFlag
        {
            get { return this._waitFlag; }
        }
        // ----- ADD ���N�@2013/06/24�@Redmine#35501 -----<<<<<
        #endregion // �R���X�g���N�^

        #region �����z�u

        /// <summary>
        /// �R���g���[���ޏ����z�u
        /// </summary>
        private void InitializeVariable()
        {

            #region �N���X������

            // �A�N�Z�X�N���X�����������A�f�[�^�Z�b�g���擾
            this._customerCreditAcs = new CustomerCreditAcs();
            this._dataSet = this._customerCreditAcs.DataSet;

            // ���������N���X�쐬
            this._custCreditCndtn = new CustCreditCndtn();

            // �A�N�Z�X�N���X������
            this._customerInfoAcs = new CustomerInfoAcs();

            this._waitFlag = false; // ADD ���N 2013/06/24 Redmine#35501
            #endregion // �N���X������

            #region �{�^���C���[�W�ݒ�

            // �C���[�W���X�g���w��(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // �{�^���C���[�W��ݒ�
            this.uButton_CustomerCdSingleGuide.ImageList = this._imageList16;
            this.uButton_CustomerCdSingleGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerStGuide.ImageList = this._imageList16;
            this.uButton_CustomerStGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerEdGuide.ImageList = this._imageList16;
            this.uButton_CustomerEdGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // �c�[���o�[�A�C�R��
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 ��QID:12310�Ή�------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SAVE;
            // --- CHG 2009/03/12 ��QID:12310�Ή�------------------------------------------------------<<<<<

            #endregion // �{�^���C���[�W�ݒ�

            #region ���O�C�����擾

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // ��ƃR�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // �����_�R�[�h
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ���O�C�����[�U�[�R�[�h
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ���O�C�����[�U�[��

            #endregion // ���O�C�����擾

            #region �R���g���[���X�L���Ή�

            // UI�X�L���ݒ�R���g���[��������
            this._controlScreenSkin = new ControlScreenSkin();

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExplorerBar_Main.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // �R���g���[���X�L���Ή�

            // ��ʃN���A
            InitializeScreen();

        }

        #endregion // �����z�u

        #region ��ʂ̏�����

        /// <summary>
        /// ��ʂ̏�����
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
        /// <br>            : 2013/06/18�z�M��</br>
        /// <br>            : Redmine #35501 �^�M�z�ݒ�ҋ@�d�l�̒ǉ�</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // �S�Ă̍��ڂ��N���A
            this.tNedit_CustomerCd_St.Clear();
            this.tNedit_CustomerCd_Ed.Clear();
            this.tNedit_CustomerCd01.Clear();
            this.tNedit_CustomerCd02.Clear();
            this.tNedit_CustomerCd03.Clear();
            this.tNedit_CustomerCd04.Clear();
            this.tNedit_CustomerCd05.Clear();
            this.tNedit_CustomerCd06.Clear();
            this.tNedit_TotalDay.Clear();
            this.uCheckEditor_TargetItem1.Checked = false;
            this.uCheckEditor_TargetItem2.Checked = false;
            this.uCheckEditor_TargetItem3.Checked = false;

            // �������x�����N���A
            this.uLabel_ProcessCount.Text = "0";

            // �f�[�^�Z�b�g���N���A
            this._dataSet.CustomerChange.Clear();

            // �R���{�{�b�N�X�������l�ɖ߂�
            this.tComboEditor_CustomerSelectDiv.SelectedIndex = 0;
            this.tComboEditor_ProcessDiv.SelectedIndex = 0;

            // �t�B�[���h�̗L����
            this.tComboEditor_CustomerSelectDiv_ValueChanged(null, null);

            // ���O�C�����[�U�[���\��
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
            this.ultraButton_Prepare.Visible = true;
            this.ultraButton_StopPrepare.Visible = false;
            this.ultraLabel_Message.Visible = false;
            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
        }

        #endregion // ��ʂ̏�����

        #region ��ʁ��p�����[�^�쐬

        /// <summary>
        /// ��ʁ��p�����[�^�쐬
        /// </summary>
        private void GetParameters()
        {
            // �p�����[�^���N���A
            this._custCreditCndtn.EnterpriseCode = string.Empty;
            this._custCreditCndtn.St_CustomerCode = 0;
            this._custCreditCndtn.Ed_CustomerCode = 0;
            this._custCreditCndtn.CustomerCodes = null;
            this._custCreditCndtn.ProcDiv = 0;
            this._custCreditCndtn.TotalDay = 0;
            this._custCreditCndtn.WarningCrdMnyFrg = false;
            this._custCreditCndtn.AccRecDiv = false;
            this._custCreditCndtn.CreditMoneyFlg = false;

            // ��ƃR�[�h
            this._custCreditCndtn.EnterpriseCode = this._enterpriseCode;

            // ���Ӑ�敪����擾����p�����[�^�𔻒f
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0) // �͈�
            {
                // �͈�
                this._custCreditCndtn.St_CustomerCode = this.tNedit_CustomerCd_St.GetInt();
                this._custCreditCndtn.Ed_CustomerCode = this.tNedit_CustomerCd_Ed.GetInt();
            }
            else
            {
                // �P��(�U�܂�)
                ArrayList array = new ArrayList();
                int custCd;

                custCd = this.tNedit_CustomerCd01.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd02.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd03.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd04.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd05.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }
                custCd = this.tNedit_CustomerCd06.GetInt();
                if (custCd > 0)
                {
                    if (!array.Contains(custCd)) array.Add(custCd);
                }

                // �z��ɕϊ�
                int[] custCodes = new int[array.Count];
                for (int count = 0; count < array.Count; count++)
                {
                    custCodes[count] = (int)array[count];
                }
                this._custCreditCndtn.CustomerCodes = custCodes;
            }

            // ����
            if (this.tNedit_TotalDay.GetInt() > 0)
            {
                this._custCreditCndtn.TotalDay = this.tNedit_TotalDay.GetInt();
            }

            // �����敪
            this._custCreditCndtn.ProcDiv = (int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue;

            // �^�M�z�t���O
            this._custCreditCndtn.CreditMoneyFlg = this.uCheckEditor_TargetItem1.Checked;

            // �x���^�M�z�t���O
            this._custCreditCndtn.WarningCrdMnyFrg = this.uCheckEditor_TargetItem2.Checked;

            // ���ݔ��|�c���t���O
            this._custCreditCndtn.AccRecDiv = this.uCheckEditor_TargetItem3.Checked;

        }

        #endregion // ��ʁ��p�����[�^�쐬

        #region �p�����[�^�`�F�b�N

        /// <summary>
        /// �p�����[�^�`�F�b�N�֐�
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // �p�����[�^���K�{�̂��̂��`�F�b�N

            // ���Ӑ悪�Ȃ� [9180]
            //if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
            //{
            //    if (this._custCreditCndtn.St_CustomerCode == 0
            //    && this._custCreditCndtn.Ed_CustomerCode == 0)
            //    {
            //        errorMsg = CT_EMPTY_CUSTOMER_CODE;
            //        return this.tNedit_CustomerCd_St;
            //    }
            //}
            //else
            //{
            //    if (this._custCreditCndtn.CustomerCodes.Length == 0)
            //    {
            //        errorMsg = CT_EMPTY_CUSTOMER_CODE;
            //        return this.tNedit_CustomerCd01;
            //    }
            //}

            // �P�ƂȂ̂ɂЂƂ��Ȃ�
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 1
                && this._custCreditCndtn.CustomerCodes.Length == 0)
            {
                errorMsg = CT_EMPTY_CUSTOMER_CODE;
                return this.tNedit_CustomerCd01;
            }

            // �^�M�z�N���A�Ȃ̂Ƀ`�F�b�N����Ă��Ȃ�
            if (this._custCreditCndtn.ProcDiv == 1
                && !this._custCreditCndtn.CreditMoneyFlg
                && !this._custCreditCndtn.WarningCrdMnyFrg
                && !this._custCreditCndtn.AccRecDiv)
            {
                errorMsg = CT_MISSING_CLEAR_TARGET;
                return this.uCheckEditor_TargetItem1;
            }

            // ���Ӑ�͈̔̓`�F�b�N
            if (this._custCreditCndtn.St_CustomerCode > this._custCreditCndtn.Ed_CustomerCode)
            {
                errorMsg = CT_INVALID_CUSTOMER_CODE;
                return this.tNedit_CustomerCd_St;
            }

            // --- ADD 2009/01/15 ��QID:10087�Ή�------------------------------------------------------>>>>>
            // ���Ӑ�����`�F�b�N
            if (this.tNedit_TotalDay.GetInt() > 31)
            {
                errorMsg = CT_TOTALDAY_ERROR;
                return this.tNedit_TotalDay;
            }
            // --- ADD 2009/01/15 ��QID:10087�Ή�------------------------------------------------------<<<<<

            return null;
        }

        #endregion // �p�����[�^�`�F�b�N

        #region ���Ӑ摶�݃`�F�b�N

        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private bool CustomerExistCheck(int customerCode)
        {
            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        #endregion // ���Ӑ摶�݃`�F�b�N

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        private void Search()
        {
            // ���b�Z�[�W����
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            // ��ʂ��猟�������N���X���쐬
            GetParameters();

            // �p�����[�^�`�F�b�N
            string errorMsg = string.Empty;
            Control errorControl = CheckParameter(out errorMsg);
            if (errorControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                errorControl.Focus();
                return;
            }
            else
            {
                // �m�F���b�Z�[�W��\�� [9183] ���Ԃ�ύX[9401]
                DialogResult result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                CT_READY_TO_PROCESS, 0, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;

                int recordCount = 0;

                // �f�[�^�Z�b�g���N���A
                this._dataSet.CustomerChange.Clear();

                // �������s
                int status = this._customerCreditAcs.Search(this._custCreditCndtn, out recordCount);

                if (status == ((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    if (recordCount == 0)
                    {
                        // ����������0�̎��́A�Y���f�[�^�Ȃ��̃��b�Z�[�W��\��
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                        this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                    }
                    else
                    {
                        // ����������\������ꍇ�́A���̃R�����g���O��
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_RESULT_PROCESSED_COUNT;
                        this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0");

                        // �X�V�����_�C�A���O��\�� [9184]
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                    }
                }
                else if (status == ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))         
                {
                    // ����������0�̎��́A�Y���f�[�^�Ȃ��̃��b�Z�[�W��\�� [9185]
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                }
                else
                {
                    // �G���[���̓��b�Z�[�W�H
                }
            }
        }

        #endregion // ����

        # region �O���[�v���k�E�W�J

        /// <summary>
        /// �O���[�v���k�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uExplorerBar_Main_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        /// <summary>
        /// �O���[�v�W�J�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uExplorerBar_Main_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }

        # endregion �O���[�v���k�E�W�J

        #region ���Ӑ�K�C�h�{�^��

        /// <summary>
        /// ���Ӑ�K�C�h�i�J�n�j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerStGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ���Ӑ�R�[�h�󂯎��
                this.tNedit_CustomerCd_St.SetInt(this._customerCode);
                this._customerCode = 0; //���Z�b�g
                this.tNedit_CustomerCd_Ed.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�i�I���j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerEdGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ���Ӑ�R�[�h�󂯎��
                this.tNedit_CustomerCd_Ed.SetInt(this._customerCode);
                this._customerCode = 0; //���Z�b�g
                this.tNedit_TotalDay.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h(�P��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCdSingleGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult result = customerSearchForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ���Ӑ�R�[�h�󂯎��
                if (this._customerCode > 0)
                {
                    if (this.tNedit_CustomerCd01.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd01.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_CustomerCd02.Focus();
                    }
                    else if (this.tNedit_CustomerCd02.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd02.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_CustomerCd03.Focus();
                    }
                    else if (this.tNedit_CustomerCd03.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd03.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_CustomerCd04.Focus();
                    }
                    else if (this.tNedit_CustomerCd04.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd04.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_CustomerCd05.Focus();
                    }
                    else if (this.tNedit_CustomerCd05.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd05.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_CustomerCd06.Focus();
                    }
                    else if (this.tNedit_CustomerCd06.GetInt() == 0)
                    {
                        this.tNedit_CustomerCd06.SetInt(this._customerCode);
                        this._customerCode = 0; //���Z�b�g
                        this.tNedit_TotalDay.Focus();
                    }
                    else
                    {
                        // 6�Ƃ����܂��Ă����ꍇ�̓X���[
                    }
                }
            }
        }

        #endregion // ���Ӑ�K�C�h�{�^��

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out this._customerInfo);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (_customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }

            // ���Ӑ����ϐ��ɐݒ�
            this._customerCode = _customerInfo.CustomerCode;
        }

        #endregion // ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        #region ���Ӑ�I���敪�ؑ�

        /// <summary>
        /// ���Ӑ�I���敪�ؑ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_CustomerSelectDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
            {
                // �͈�
                this.tNedit_CustomerCd01.Enabled = false;
                this.tNedit_CustomerCd02.Enabled = false;
                this.tNedit_CustomerCd03.Enabled = false;
                this.tNedit_CustomerCd04.Enabled = false;
                this.tNedit_CustomerCd05.Enabled = false;
                this.tNedit_CustomerCd06.Enabled = false;
                this.uButton_CustomerCdSingleGuide.Enabled = false;

                this.tNedit_CustomerCd_St.Enabled = true;
                this.tNedit_CustomerCd_Ed.Enabled = true;
                this.uButton_CustomerStGuide.Enabled = true;
                this.uButton_CustomerEdGuide.Enabled = true;
            }
            else
            {
                // �P��
                this.tNedit_CustomerCd_St.Enabled = false;
                this.tNedit_CustomerCd_Ed.Enabled = false;
                this.uButton_CustomerStGuide.Enabled = false;
                this.uButton_CustomerEdGuide.Enabled = false;

                this.tNedit_CustomerCd01.Enabled = true;
                this.tNedit_CustomerCd02.Enabled = true;
                this.tNedit_CustomerCd03.Enabled = true;
                this.tNedit_CustomerCd04.Enabled = true;
                this.tNedit_CustomerCd05.Enabled = true;
                this.tNedit_CustomerCd06.Enabled = true;
                this.uButton_CustomerCdSingleGuide.Enabled = true;
            }
        }

        #endregion // ���Ӑ�I���敪�ؑ�

        #region �����敪�ؑ�

        /// <summary>
        /// �����敪�ؑ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_ProcessDiv_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
            {
                // ���ݔ��|�c���ݒ�
                if (this.uCheckEditor_TargetItem1.Checked) this.uCheckEditor_TargetItem1.Checked = false;
                if (this.uCheckEditor_TargetItem2.Checked) this.uCheckEditor_TargetItem2.Checked = false;
                if (this.uCheckEditor_TargetItem3.Checked) this.uCheckEditor_TargetItem3.Checked = false;
                this.uCheckEditor_TargetItem1.Enabled = false;
                this.uCheckEditor_TargetItem2.Enabled = false;
                this.uCheckEditor_TargetItem3.Enabled = false;
            }
            else
            {
                // �^�M�z�N���A
                this.uCheckEditor_TargetItem1.Enabled = true;
                this.uCheckEditor_TargetItem2.Enabled = true;
                this.uCheckEditor_TargetItem3.Enabled = true;
            }
        }

        #endregion  // �����敪�ؑ�

        #region �c�[���o�[

        /// <summary>
        /// �c�[���o�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region �I���{�^��
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // �I���{�^��

                #region �m��{�^��
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // �m��{�^��

                default: break;
            }
        }

        #endregion // �c�[���o�[

        #region �A���[�L�[�R���g���[��

        /// <summary>
        /// �A���[�L�[�R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>UpdateNote  : 2013/05/13 zhuhh</br>
        /// <br>            : 2013/06/18�z�M��</br>
        /// <br>            : Redmine #35501 �^�M�z�ݒ�ҋ@�d�l�̒ǉ�</br>
        /// <br>UpdateNote  : ���N 2013/05/28</br>
        /// <br>            : Redmine#35501 #10�̑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���O�ɂ�蕪��
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------

                #region ���Ӑ�i�J�n�j
                case "tNedit_CustomerCd_St":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        if (this.tNedit_CustomerCd_St.GetInt() > 0)
                                        {
                                            //if (CustomerExistCheck(this.tNedit_CustomerCd_St.GetInt()))
                                            //{
                                            e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                            //}
                                            //else
                                            //{
                                            //    // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                            //        CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                            //    // ���͂��ꂽ�l���N���A
                                            //    this.tNedit_CustomerCd_St.Clear();

                                            //    // �K�C�h�֑J��
                                            //    e.NextCtrl = this.uButton_CustomerStGuide;
                                            //}
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerStGuide;
                                        }
                                        break;
                                    }
                            }
                            // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else
                        {
                            // -----ADD�@���N 2013/05/28  Redmine#35501 ----->>>>>
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.ultraButton_Prepare;
                                        break;
                                    }
                            }
                            // -----ADD ���N 2013/05/28 for Redmine#35501 -----<<<<<
                            // e.NextCtrl = null; // DEL ���N 2013/05/28 for Redmine#35501
                        }
                         // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�i�J�n�j

                #region ���Ӑ�i�J�n�j�K�C�h
                case "uButton_CustomerStGuide":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd_St;
                                        break;
                                    }
                            }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�i�J�n�j�K�C�h

                #region ���Ӑ�i�I���j
                case "tNedit_CustomerCd_Ed":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (this.tNedit_CustomerCd_Ed.GetInt() > 0)
                                    {
                                        //if (CustomerExistCheck(this.tNedit_CustomerCd_Ed.GetInt()))
                                        //{
                                            e.NextCtrl = this.tNedit_TotalDay;
                                        //}
                                        //else
                                        //{
                                        //    // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                        //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                        //        CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                        //    // ���͂��ꂽ�l���N���A
                                        //    this.tNedit_CustomerCd_Ed.Clear();

                                        //    // �K�C�h�֑J��
                                        //    e.NextCtrl = this.uButton_CustomerEdGuide;

                                            //// ���݂��Ȃ���΃K�C�h���J��
                                            //this.tNedit_CustomerCd_Ed.Clear();
                                            //this.uButton_CustomerStGuide_Click(null, null);
                                            //if (this.tNedit_CustomerCd_Ed.GetInt() > 0)
                                            //{
                                            //    e.NextCtrl = this.tNedit_TotalDay;
                                            //}
                                            //else
                                            //{
                                            //    e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                            //}
                                        //}
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uButton_CustomerEdGuide;
                                    }
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uButton_CustomerStGuide;
                                        break;
                                    }
                            }                            
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�i�I���j

                #region ���Ӑ�i�I���j�K�C�h
                case "uButton_CustomerEdGuide":
                    {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                    break;
                                }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:

                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd_Ed;
                                        break;
                                    }
                            }
                        }
                        // -----ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�i�I���j�K�C�h

                #region ���Ӑ�i�P�Ɓj1
                case "tNedit_CustomerCd01":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd01.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd01.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd02;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd01.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd02;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj1

                #region ���Ӑ�i�P�Ɓj2
                case "tNedit_CustomerCd02":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd02.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd02.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd03;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd02.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd03;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd01;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj2

                #region ���Ӑ�i�P�Ɓj3
                case "tNedit_CustomerCd03":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd03.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd03.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd04;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd03.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd04;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd02;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj3

                #region ���Ӑ�i�P�Ɓj4
                case "tNedit_CustomerCd04":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd04.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd04.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd05;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd04.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd05;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd03;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj4

                #region ���Ӑ�i�P�Ɓj5
                case "tNedit_CustomerCd05":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd05.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd05.GetInt()))
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCd06;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd05.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd06;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd04;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj5

                #region ���Ӑ�i�P�Ɓj6
                case "tNedit_CustomerCd06":
                    {
                        // Shift + Tab/Enter�ŋt�i�s
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.tNedit_CustomerCd06.GetInt() > 0)
                                        {
                                            if (CustomerExistCheck(this.tNedit_CustomerCd06.GetInt()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                            else
                                            {
                                                // ���݂��Ȃ���΃G���[���b�Z�[�W��\��
                                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                                                    CT_CUSTOMER_NOT_FOUND, 0, MessageBoxButtons.OK);

                                                // ���͂��ꂽ�l���N���A
                                                this.tNedit_CustomerCd06.Clear();

                                                // �K�C�h�֑J��
                                                e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = this.tNedit_CustomerCd06;// DEL zhuhh 2013/05/13 for Redmine#35501
                                        e.NextCtrl = this.tNedit_CustomerCd05;// ADD zhuhh 2013/05/13 for Redmine#35501
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj6

                #region ���Ӑ�i�P�Ɓj�K�C�h
                case "uButton_CustomerCdSingleGuide":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_TotalDay;
                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCd06;
                                        break;
                                    }
                            } 
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�i�P�Ɓj�K�C�h

                #region ���Ӑ�I���敪
                case "tComboEditor_CustomerSelectDiv":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            // �͈͂̎��͒P�ƍ��ڂ͈ړ��s��
                                            e.NextCtrl = this.tNedit_TotalDay;
                                        }
                                        else
                                        {
                                            // �P�Ƃ̎��͂������
                                            e.NextCtrl = this.tNedit_CustomerCd01;
                                        }
                                        break;
                                    }
                            }
                            // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.uButton_CustomerEdGuide;
                                        }
                                        else
                                        {
                                            //e.NextCtrl = null;// DEL ���N 2013/05/28 Redmine#35501
                                            e.NextCtrl = this.ultraButton_Prepare;// ADD ���N 2013/05/28 Redmine#35501
                                        }
                                        break;
                                    }
                            }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���Ӑ�I���敪

                #region ����
                case "tNedit_TotalDay":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tComboEditor_ProcessDiv;
                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_CustomerSelectDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_CustomerCdSingleGuide;
                                        }
                                        break;
                                    }
                            }    
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ����

                #region �����敪
                case "tComboEditor_ProcessDiv":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                case Keys.Down: // ADD zhuhh 2013/05/13 for Redmine#35501
                                {
                                    // �^�M�z�N���A���ȊO�̓`�F�b�N�ɍs���Ȃ�
                                    if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
                                    {
                                            //e.NextCtrl = null;//DEL zhuhh 2013/05/13 for Redmine#35501
                                            e.NextCtrl = this.tEdit_Hour;// ADD zhuhh 2013/05/13 for Redmine#35501
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem1;
                                    }

                                    break;
                                }
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_TotalDay;
                                        break;
                                    }
                            }     
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // �����敪

                #region �^�M�z�N���A
                case "uCheckEditor_TargetItem1":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uCheckEditor_TargetItem2;
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // �`�F�b�N�{�b�N�X�𔽓]���Ď���
                                    this.uCheckEditor_TargetItem1.Checked = !this.uCheckEditor_TargetItem1.Checked;
                                    e.NextCtrl = this.uCheckEditor_TargetItem2;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tComboEditor_ProcessDiv;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // �^�M�z�N���A

                #region �x���^�M�z
                case "uCheckEditor_TargetItem2":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.uCheckEditor_TargetItem3;
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // �`�F�b�N�{�b�N�X�𔽓]���Ď���
                                    this.uCheckEditor_TargetItem2.Checked = !this.uCheckEditor_TargetItem2.Checked;
                                    e.NextCtrl = this.uCheckEditor_TargetItem3;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem1;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // �x���^�M�z

                #region ���ݔ��|�c��
                case "uCheckEditor_TargetItem3":
                    {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        if (!e.ShiftKey)
                        {
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                        //e.NextCtrl = null;// DEL zhuhh 2013/05/13 for Redmine#35501
                                        e.NextCtrl = this.tEdit_Hour;// ADD zhuhh 2013/05/13 for Redmine#35501
                                    break;
                                }
                            case Keys.Space:
                                {
                                    // �`�F�b�N�{�b�N�X�𔽓]���Ď���
                                    this.uCheckEditor_TargetItem3.Checked = !this.uCheckEditor_TargetItem3.Checked;
                                    e.NextCtrl = null;
                                    break;
                                }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                            }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.uCheckEditor_TargetItem2;
                                        break;
                                    }
                            }   
                        }
                        // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                        break;
                    }
                #endregion // ���ݔ��|�c��

                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 ----->>>>>
                #region �����J�n���Ԏ�
                case "tEdit_Hour":
                    {
                        // ----- ADD ���N 2013/05/28 Redmine#35501 ---->>>>>
                        string hour = this.tEdit_Hour.Text.Trim();
                        if (hour.Length == 1)
                        {
                            hour = hour.PadLeft(2, '0');
                            this.tEdit_Hour.Text = hour;
                        }
                        // ----- ADD ���N 2013/05/28 Redmine#35501 ----<<<<<
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Minute;
                                        break;
                                    }
                            }
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if ((int)this.tComboEditor_ProcessDiv.SelectedItem.DataValue == 0)
                                        {
                                            e.NextCtrl = this.tComboEditor_ProcessDiv;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uCheckEditor_TargetItem3;
                                        }
                                        break;
                                    }
                            }                            
                        }
                        break;
                    }
                #endregion

                #region �����J�n���ԕ�
                case "tEdit_Minute":
                    {
                        // ----- ADD ���N 2013/05/28 Redmine#35501 ---->>>>>
                        string mimute = this.tEdit_Minute.Text.Trim();
                        if (mimute.Length == 1)
                        {
                            mimute = mimute.PadLeft(2, '0');
                            this.tEdit_Minute.Text = mimute;
                        }
                        // ----- ADD ���N 2013/05/28 Redmine#35501 ----<<<<<
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        if (this.ultraButton_Prepare.Visible)
                                        {
                                            e.NextCtrl = this.ultraButton_Prepare;
                                        }
                                        else if (this.ultraButton_StopPrepare.Visible)
                                        {
                                            e.NextCtrl = this.ultraButton_StopPrepare;
                                        }
                                        break;
                                    }
                            }
                        }
                        else 
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Hour;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region �ҋ@
                case "ultraButton_Prepare":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        //e.NextCtrl = null; // DEL ���N 2013/05/28 Redmine#35501
                                        // ----- ADD ���N 2013/05/28 Redmine#35501 ----->>>>>
                                        if (this.tNedit_CustomerCd_St.Enabled)
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCd_St;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tComboEditor_CustomerSelectDiv;
                                        }
                                             // ----- ADD ���N 2013/05/28 Redmine#35501 -----<<<<<
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_Minute;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���~
                case "ultraButton_StopPrepare":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion
                // ----- ADD zhuhh 2013/05/13 for Redmine#35501 -----<<<<<
                default: break;
            }
        }

        #endregion // �A���[�L�[�R���g���[��
          
        #region [�ҋ@]
        /// <summary>
        /// Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �^�M�z�ݒ�ҋ@�������s���܂��B</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: ���N 2013/05/28</br>
        /// <br>           : Redmine#35501 #10�̑Ή�</br>
        /// <br>UpDate Note: ���N 2013/06/24</br>
        /// <br>           : Redmine#35501 #14�̑Ή�</br>
        /// </remarks>
        private void ultraButton_Prepare_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //ToolbarsSetting(false); DEL ���N 2013/05/28 Redmine#35501
            // ��ʂ��猟�������N���X���쐬
            GetParameters();
            // �p�����[�^�`�F�b�N
            string errorMsg = string.Empty;
            Control errorControl = CheckParameter(out errorMsg);
            if (errorControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMKHN09261U",
                               errorMsg, 0, MessageBoxButtons.OK);
                errorControl.Focus();
                ToolbarsSetting(true);
                return;
            }
            else 
            {
                if (checkStartTime(this.tEdit_Hour.Text, this.tEdit_Minute.Text))
                {
                    if ((Int32.Parse(this.tEdit_Hour.Text) > System.DateTime.Now.Hour) || (Int32.Parse(this.tEdit_Hour.Text) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.Text) >= System.DateTime.Now.Minute))
                    {
                        result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                    CT_READY_TO_WAITNOW, 0, MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        result = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "PMKHN09261U",
                                                    CT_READY_TO_WAITTOMORROW, 0, MessageBoxButtons.YesNo);
                    }
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        ToolbarsSetting(false); // ADD ���N 2013/05/28 Redmine#35501
                        // ���Ӑ�͈�
                        this.tNedit_CustomerCd_St.Enabled = false;
                        this.uButton_CustomerStGuide.Enabled = false;
                        this.tNedit_CustomerCd_Ed.Enabled = false;
                        this.uButton_CustomerEdGuide.Enabled = false;

                        //���Ӑ�P��
                        this.tComboEditor_CustomerSelectDiv.Enabled = false;
                        this.tNedit_CustomerCd01.Enabled = false;
                        this.tNedit_CustomerCd02.Enabled = false;
                        this.tNedit_CustomerCd03.Enabled = false;
                        this.tNedit_CustomerCd04.Enabled = false;
                        this.tNedit_CustomerCd05.Enabled = false;
                        this.tNedit_CustomerCd06.Enabled = false;
                        this.uButton_CustomerCdSingleGuide.Enabled = false;

                        //���Ӑ����
                        this.tNedit_TotalDay.Enabled = false;
                        //�����敪
                        this.tComboEditor_ProcessDiv.Enabled = false;
                        //�Ώۍ���
                        this.uCheckEditor_TargetItem1.Enabled = false;
                        this.uCheckEditor_TargetItem2.Enabled = false;
                        this.uCheckEditor_TargetItem3.Enabled = false;
                        //�����J�n����
                        this.tEdit_Hour.Enabled = false;
                        this.tEdit_Minute.Enabled = false;

                        this.ultraButton_Prepare.Visible = false;
                        this.ultraButton_StopPrepare.Visible = true;
                        this.ultraLabel_Message.Visible = true;
                        this.ultraButton_StopPrepare.Focus(); // ADD ���N 2013/05/28 Redmine#35501

                        this._waitFlag = true; // ADD ���N 2013/06/24 Redmine#35501

                        this.timer_ShowOrNot.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : Tick �C�x���g</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: gezh 2013/08/20</br>
        /// <br>           : Redmine#35501 #18�̑Ή�</br>
        /// </remarks>
        private void timer_ShowOrNot_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            if (Int32.Parse(this.tEdit_Hour.DataText.Trim()) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.DataText.Trim()) == System.DateTime.Now.Minute)
            {
                counter = 0;
                this.timer_ShowOrNot.Stop();
                if (this.tComboEditor_CustomerSelectDiv.SelectedIndex == 0)
                {
                    // ���Ӑ�͈�
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd_St.Enabled = true;
                    this.uButton_CustomerStGuide.Enabled = true;
                    this.tNedit_CustomerCd_Ed.Enabled = true;
                    this.uButton_CustomerEdGuide.Enabled = true;
                }
                else
                {
                    //���Ӑ�P��
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd01.Enabled = true;
                    this.tNedit_CustomerCd02.Enabled = true;
                    this.tNedit_CustomerCd03.Enabled = true;
                    this.tNedit_CustomerCd04.Enabled = true;
                    this.tNedit_CustomerCd05.Enabled = true;
                    this.tNedit_CustomerCd06.Enabled = true;
                    this.uButton_CustomerCdSingleGuide.Enabled = true;
                }
                if (this.tComboEditor_ProcessDiv.SelectedIndex == 0)
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                }
                else
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                    this.uCheckEditor_TargetItem1.Enabled = true;
                    this.uCheckEditor_TargetItem2.Enabled = true;
                    this.uCheckEditor_TargetItem3.Enabled = true;
                }
                //���Ӑ����
                this.tNedit_TotalDay.Enabled = true;
                //�����J�n����
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;

                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;
                ToolbarsSetting(true);
                SearchAuto();
                this.tEdit_Hour.Focus();
                this._waitFlag = false; // ADD gezh 2013/08/20 Redmine#35501
            }
            else 
            {
                if (counter % 4 == 0)
                {
                    this.ultraLabel_Message.Visible = false;
                }
                else
                {
                    this.ultraLabel_Message.Visible = true;
                }
            }
        }

        /// <summary>
        /// Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���^�M�z�ݒ菈���ҋ@��Ԃ̉������s���܂��B</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: ���N 2013/06/24</br>
        /// <br>           : Redmine#35501 #14�̑Ή�</br>
        /// </remarks>
        private void ultraButton_StopPrepare_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // �G���[���x��
                                 "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 "�ҋ@�����𒆎~���Ă�낵���ł����H",     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // �\������{�^��
            if (result == DialogResult.No)
            {
                return;
            }
            else 
            {
                counter = 0;
                this.timer_ShowOrNot.Stop();
                this._waitFlag = false;// ADD ���N�@2013/06/24 Redmine#35501
                if (this.tComboEditor_CustomerSelectDiv.SelectedIndex == 0)
                {
                    // ���Ӑ�͈�
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd_St.Enabled = true;
                    this.uButton_CustomerStGuide.Enabled = true;
                    this.tNedit_CustomerCd_Ed.Enabled = true;
                    this.uButton_CustomerEdGuide.Enabled = true;
                }
                else
                {
                    //���Ӑ�P��
                    this.tComboEditor_CustomerSelectDiv.Enabled = true;
                    this.tNedit_CustomerCd01.Enabled = true;
                    this.tNedit_CustomerCd02.Enabled = true;
                    this.tNedit_CustomerCd03.Enabled = true;
                    this.tNedit_CustomerCd04.Enabled = true;
                    this.tNedit_CustomerCd05.Enabled = true;
                    this.tNedit_CustomerCd06.Enabled = true;
                    this.uButton_CustomerCdSingleGuide.Enabled = true;
                }
                if (this.tComboEditor_ProcessDiv.SelectedIndex == 0)
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                }
                else
                {
                    this.tComboEditor_ProcessDiv.Enabled = true;
                    this.uCheckEditor_TargetItem1.Enabled = true;
                    this.uCheckEditor_TargetItem2.Enabled = true;
                    this.uCheckEditor_TargetItem3.Enabled = true;
                }
                //���Ӑ����
                this.tNedit_TotalDay.Enabled = true;
                //�����J�n����
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;

                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;

                ToolbarsSetting(true);

                this.tEdit_Hour.Focus();
            }
        }

        /// <summary>
        /// �^�C�}�[���̓`�F�b�N
        /// </summary>
        /// <br>Programer   : zhuhh</br>
        /// <br>Date	    : 2013/05/13</br>
        /// <returns>�X�e�[�^�X</returns>
        private bool checkStartTime(string hour, string minute)
        {
            bool checkFlg = true;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^\\d{2}$");
            if (!string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour) || !regex.IsMatch(minute))
                {
                    TMsgDisp.Show(
                                   this, 								            // �e�E�B���h�E�t�H�[��
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                   "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                   "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                   0, 									            // �X�e�[�^�X�l
                                   MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(minute) < 0 || Int32.Parse(minute) > 59)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Minute.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(hour) <= 5 || Int32.Parse(hour) >= 23 || (Int32.Parse(hour) == 6 && Int32.Parse(minute) == 0))
                {
                    TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                 "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 "23��00���`06��00���̓����e�i���X���Ԃׁ̈A�ݒ�o���܂���B",     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
            }
            else if (string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                    this, 								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                    "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                    0, 									            // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (!string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour))
                {
                    TMsgDisp.Show(
                                   this, 								            // �e�E�B���h�E�t�H�[��
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                   "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                   "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                   0, 									            // �X�e�[�^�X�l
                                   MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                TMsgDisp.Show(
                                    this, 								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                    "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                    0, 									            // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Minute.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                        this, 								            // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                        "PMKHN09261U", 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        "�����J�n���Ԃ���͂��Ă��������B",     // �\�����郁�b�Z�[�W
                                        0, 									            // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }

            return checkFlg;
        }

        /// <summary>
        /// �c�[���o�[�̕\���E�L���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̗L���E�����ݒ���s���܂��B</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// </remarks>
        private void ToolbarsSetting(bool flag)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonDecisionTool;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonCloseTool;

            buttonDecisionTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            buttonCloseTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];

            buttonDecisionTool.SharedProps.Enabled = flag;
            buttonCloseTool.SharedProps.Enabled = flag;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������s���܂��B</br>
        /// <br>Programer  : zhuhh</br>
        /// <br>Date       : 2013/05/13</br>
        /// <br>UpDate Note: ���N 2013/05/28</br>
        /// <br>           : Redmine#35501 #10�̑Ή�</br>
        /// </remarks>
        private void SearchAuto()
        {
            // ���b�Z�[�W����
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;
          
            int recordCount = 0;

            // �f�[�^�Z�b�g���N���A
            this._dataSet.CustomerChange.Clear();

            // �������s
            int status = this._customerCreditAcs.Search(this._custCreditCndtn, out recordCount);

            if (status == ((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                if (recordCount == 0)
                {
                    // ����������0�̎��́A�Y���f�[�^�Ȃ��̃��b�Z�[�W��\��
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
                }
                else
                {
                    // ����������\������ꍇ�́A���̃R�����g���O��
                    this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_RESULT_PROCESSED_COUNT;
                    this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0");

                    // �X�V�����_�C�A���O��\�� [9184]
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                }
            }
            else if (status == ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                // ����������0�̎��́A�Y���f�[�^�Ȃ��̃��b�Z�[�W��\�� [9185]
                this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_RESULT_NOT_FOUND;
                this.uLabel_ProcessCount.Text = recordCount.ToString("#,##0"); // [9185]
            }
            else
            {
                // �G���[���̓��b�Z�[�W�H
            }
            // ----- ADD ���N 2013/05/28 Redmine#35501 ----->>>>>
            this.tEdit_Hour.Clear();
            this.tEdit_Minute.Clear();
            // ----- ADD ���N 2013/05/28 Redmine#35501 -----<<<<<
        }
        #endregion
    }
}