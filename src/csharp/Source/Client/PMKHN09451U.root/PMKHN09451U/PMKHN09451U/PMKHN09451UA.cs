//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڕW�����ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2009/07/07  �C�����e : PVCS#262 �Ώۊ��̕\�����e�s��
//           2009/07/13
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ڕW�����ݒ�
    /// </summary>
    /// <remarks>
    /// Note       : �ڕW�����ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.04.02<br />
    /// </remarks>
    public partial class PMKHN09451UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_ClassID = "PMKHN09451UA";
        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "�S��";
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKHN09451UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execution"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._mainOfficeFunc = false;
            this._secInfoAcs = new SecInfoAcs(1);
            startMonthDt = new DateTime();
            nowDateTime = new DateTime();
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
        }
        # endregion

        # region �� private field ��
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode;                         // ��ƃR�[�h
        private bool _mainOfficeFunc;                           // �{��/���_���
        private SecInfoAcs _secInfoAcs;                         // ���_�}�X�^�A�N�Z�X�N���X
        private ObjAutoSetAcs _objAutoSetAcs;
        List<DateTime> yearMonth;
        DateTime startMonthDt;
        DateTime nowDateTime;
        Int32 appMonth = 0;
        string baseCodeTemp = "00";
        # endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void PMKHN09451UA_Load(object sender, EventArgs e)
        {
            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ��ʃf�[�^�̏������ݒ�
            this.InitializeScreen();
        }
        /// <summary>
        /// ��ʂ̃t�H�[�J�X����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̃t�H�[�J�X�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.tce_CustomerDiv.Focus();
        }
        # endregion

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        #region �� ��ʃf�[�^�̏��������� ��
        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̂��s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���_
            this.tce_SectionDiv.SelectedIndex = 0;
            // ���Ӑ�
            this.tce_CustomerDiv.SelectedIndex = 0;
            // �S����
            this.tce_TantowusyaDiv.SelectedIndex = 0;
            // �󒍎�
            this.tce_ReceiveOrderDiv.SelectedIndex = 0;
            // ���s��
            this.tce_PublisherDiv.SelectedIndex = 0;
            // �n��
            this.tce_DistrictDiv.SelectedIndex = 0;
            // �Ǝ�
            this.tce_TypeBusinessDiv.SelectedIndex = 0;
            // �̔��敪
            this.tce_SalesDivisionDiv.SelectedIndex = 0;
            // �Ώۋ��z
            this.tce_ObjMoneyDiv.SelectedIndex = 0;
            // �Ώۊ�
            this.tce_ObjectPeriodDiv.SelectedIndex = 0;
            // �䗦
            this.tce_RatioDiv.SelectedIndex = 0;
            // �P��
            this.tce_UnitDiv.SelectedIndex = 0;
            // �[������
            this.tce_FractionProDiv.SelectedIndex = 0;
            // ���_�R�[�h
            this.tNedit_SectionCode.Text = "00";
            // ���_����
            this.uLabel_SectionName.Text = ALL_SECTIONNAME;
        }
        #endregion �� ��ʃf�[�^�̏��������� ��

        #region �� ���_�K�C�h���� ��
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            if (!_objAutoSetAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                "���_�K�C�h��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this.tce_ObjMoneyDiv.Focus();
            }
        }
        #endregion �� ���_�K�C�h���� ��

        #region �� �c�[���o�[�{�^���N���b�N�C�x���g���� ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Execution":
                    {

                        // �ڕW�����ݒ�
                        bool inputCheck = this.ExecutBeforeCheck();
                        if (inputCheck)
                        {
                            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1 && 0 >= this.tNedit_Past.GetInt())
                            {
                                // ADD 2009/07/13 --->>>
                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Text,
                                "�K�p���̎w��Ɍ�肪����܂��B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                this.tNedit_Past.Focus();
                                // ADD 2009/07/13 ---<<<
                                break;
                            }

                            bool isExecution = this.Execution();

                            if (!isExecution)
                            {
                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Text,
                                this.Text + "�ڕW�����ݒ肪���s���܂����B",
                                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                // �o�^����
                                SaveCompletionDialog dialog = new SaveCompletionDialog();
                                dialog.ShowDialog(2);
                                this.tce_CustomerDiv.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �Ώۊ��敪�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ώۊ��敪���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.26</br>
        /// </remarks>
        private void tce_ObjectPeriodDiv_ValueChanged(object sender, EventArgs e)
        {
            // ��ʁD�Ώۊ����u�O���v�̏ꍇ�A�K�p������͂ł��Ȃ��B
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 0)
            {
                this.tNedit_Past.Text = string.Empty;
                this.tNedit_Past.Enabled = false;
                if (this.tce_RatioDiv.Enabled == false)
                {
                    this.tce_RatioDiv.Enabled = true;
                }
            }
            else
            // ��ʁD�Ώۊ����u�����v�̏ꍇ�A�䗦���u���ρv�݂̂�I���ł���
            {
                // ���ݏ����N���擾
                this._objAutoSetAcs.GetThisYearMonth(out nowDateTime);

                // ��v�N�x�擾 ���N �� 0
                this._objAutoSetAcs.GetCompanyInf(out yearMonth);

                if (null != yearMonth && yearMonth.Count > 0)
                {
                    startMonthDt = yearMonth[0];
                    Int32 startMonthInt = startMonthDt.Month;
                    Int32 nowDtMonthInt = nowDateTime.Month;
                    Int32 startYearInt = startMonthDt.Year;
                    Int32 nowDtYearInt = nowDateTime.Year;

                    if (nowDtYearInt != startYearInt)
                    {
                        appMonth = nowDtMonthInt - startMonthInt + 12;
                    }
                    else
                    {
                        appMonth = nowDtMonthInt - startMonthInt;
                    }
                }

                this.tNedit_Past.Enabled = true;
                this.tNedit_Past.Text = Convert.ToString(appMonth);
                this.tce_RatioDiv.SelectedIndex = 0;
                this.tce_RatioDiv.Enabled = false;
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.26</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = ALL_SECTIONNAME;
                return sectionName;
            }

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.05.20</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                case "tNedit_SectionCode":
                    {
                        string sectionCode = string.Empty;
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                        {
                            this.tNedit_SectionCode.Text = string.Empty;
                            this.uLabel_SectionName.Text = string.Empty;

                            baseCodeTemp = string.Empty;

                            break;
                        }
                        else
                        {
                            sectionCode = this.tNedit_SectionCode.Text;
                        }
                        
                        if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                        {
                            // ���ʂ���ʂɐݒ�
                            string baseName = GetSectionName(sectionCode);
                            this.uLabel_SectionName.Text = baseName;
                            baseCodeTemp = sectionCode;
                            if (e.ShiftKey)
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = tce_SalesDivisionDiv;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = tce_ObjMoneyDiv;
                                }
                            }

                        }
                        else
                        {
                            DialogResult dialogResult = TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            ct_ClassID,							// �A�Z���u��ID
                            "�Ώۋ��_���}�X�^�ɑ��݂��܂���B",	// �\�����郁�b�Z�[�W
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                            this.tNedit_SectionCode.Text = baseCodeTemp;

                            // �� 2009.07.07 ���m modify PVCS NO.307
                            // e.NextCtrl = this.uButton_SectionGuide;
                            e.NextCtrl = e.PrevCtrl;
                            // �� 2009.07.07 ���m�@

                            return;
                        }
                        break;
                    }
                // ADD 杍^ 2009/07/07 --->>> 
                // �K�p��
                case "tNedit_Past":
                    {
                        // ���͖���
                        if (string.IsNullOrEmpty(this.tNedit_Past.Text.Trim()))
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ct_ClassID,
                            "",
                            "",
                            "",
                            "�K�p�����w�肵�Ă��������B",
                            0,
                            null,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.OK)
                            {
                                e.NextCtrl = this.tNedit_Past;
                            }
                        }
                        break;
                    }
                // ADD 杍^ 2009/07/07 ---<<<
            }
        }

        #endregion

        #region �� �ڕW�����ݒ菈�� ��
        /// <summary>
        /// �o�׎������
        /// </summary>
        /// <returns>true:�o�׎������ false:�o�׎��������</returns>
        /// <remarks>
        /// <br>Note		: ���t���͂̃`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private bool Execution()
        {
            bool isExecution = false;

            // �I�t���C����ԃ`�F�b�N						
            if (!_objAutoSetAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "��ʏ����������Ɏ��s���܂����B",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            ObjAutoSetWork objAutoSetWork = new ObjAutoSetWork();
            // ��ƃR�[�h
            objAutoSetWork.EnterpriseCode = _enterpriseCode;
            // ���_�R�[�h
            objAutoSetWork.SecCode = this.tNedit_SectionCode.Text;
            // ���_DRP
            objAutoSetWork.SecDrp = this.tce_SectionDiv.SelectedIndex;
            // ���Ӑ�DRP
            objAutoSetWork.CustomerDrp = this.tce_CustomerDiv.SelectedIndex;
            // �S����DRP
            objAutoSetWork.TantosyaDrp = this.tce_TantowusyaDiv.SelectedIndex;
            // �󒍎�DRP
            objAutoSetWork.ReceOrdDrp = this.tce_ReceiveOrderDiv.SelectedIndex;
            // ���s��DRP
            objAutoSetWork.PublisherDrp = this.tce_PublisherDiv.SelectedIndex;
            // �n��DRP
            objAutoSetWork.DistrictDrp = this.tce_DistrictDiv.SelectedIndex;
            // �Ǝ�DRP
            objAutoSetWork.TypeBusinessDrp = this.tce_TypeBusinessDiv.SelectedIndex;
            // �̔��敪DRP
            objAutoSetWork.SalesDivisionDrp = this.tce_SalesDivisionDiv.SelectedIndex;
            // �Ώۋ��zDRP
            objAutoSetWork.ObjMoneyDrp = this.tce_ObjMoneyDiv.SelectedIndex;
            // �Ώۊ�DRP
            objAutoSetWork.ObjPeriodDrp = this.tce_ObjectPeriodDiv.SelectedIndex;
            // �䗦DRP
            objAutoSetWork.RatioDrp = this.tce_RatioDiv.SelectedIndex;
            // �P��DRP
            objAutoSetWork.UnitDrp = this.tce_UnitDiv.SelectedIndex;
            // �[������DRP
            objAutoSetWork.FractionProcDrp = this.tce_FractionProDiv.SelectedIndex;
            // ����ڕW
            objAutoSetWork.SalesTarget = this.tNedit_SalesTargetObj.GetInt();
            // �e���ڕW
            objAutoSetWork.GroMarginTarget = this.tNedit_GrossMarginObj.GetInt();
            // ���ʖڕW
            objAutoSetWork.AmountTarget = this.tNedit_AmountObj.GetInt();
            // �ߋ�
            objAutoSetWork.Past = this.tNedit_Past.GetInt();

            string baseCode = this.tNedit_SectionCode.Text.Trim();

            this.Cursor = Cursors.WaitCursor;

            int status = _objAutoSetAcs.ObjAutoSetProc(_enterpriseCode, baseCode, objAutoSetWork, yearMonth);

            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isExecution = true;
            }

            return isExecution;
        }
        #endregion �� �ڕW�����ݒ菈�� ��

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// �ڕW�����ݒ�O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �ڕW�����ݒ�O�`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                ct_ClassID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2008.12.01</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_NoInput = "���w�肵�Ă��������B";
            const string ct_InputError = "�̎w��Ɍ�肪����܂��B";

            // ���_
            if (string.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
            {
                errMessage = string.Format("���_{0}", ct_NoInput);
                errComponent = this.tNedit_SectionCode;
                status = false;

                return status;
            }
            // ����ڕW
            if (this.tNedit_SalesTargetObj.GetInt() == 0)
            {
                errMessage = string.Format("����ڕW{0}", ct_NoInput);
                errComponent = this.tNedit_SalesTargetObj;
                status = false;

                return status;
            }
            // �e���ڕW
            if (this.tNedit_GrossMarginObj.GetInt() == 0)
            {
                errMessage = string.Format("�e���ڕW{0}", ct_NoInput);
                errComponent = this.tNedit_GrossMarginObj;
                status = false;

                return status;
            }
            // ���ʖڕW
            if (this.tNedit_AmountObj.GetInt() == 0)
            {
                errMessage = string.Format("���ʖڕW{0}", ct_NoInput);
                errComponent = this.tNedit_AmountObj;
                status = false;

                return status;
            }
            // �K�p���`�F�b�N
            // ��ʁD�Ώۊ����u�����v�̏ꍇ�A�P�`�����\�����ꂽ�l�B
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1)
            {
                if (this.tNedit_Past.GetInt() > appMonth)
                {
                    errMessage = string.Format("�K�p��{0}", ct_InputError);
                    errComponent = this.tNedit_Past;
                    status = false;

                    return status;
                }
            }
            // ��ʍ��ڂ̎��s�O�`�F�b�N

            // �Ώۃ}�X�^�ݒ荀�ڂ��S�āu�s��Ȃ��v�̏ꍇ�A�G���[�Ƃ���B
            if (this.tce_SectionDiv.SelectedIndex == 0
                && this.tce_CustomerDiv.SelectedIndex == 0
                && this.tce_TantowusyaDiv.SelectedIndex == 0
                && this.tce_ReceiveOrderDiv.SelectedIndex == 0
                && this.tce_PublisherDiv.SelectedIndex == 0
                && this.tce_DistrictDiv.SelectedIndex == 0
                && this.tce_TypeBusinessDiv.SelectedIndex == 0
                && this.tce_SalesDivisionDiv.SelectedIndex == 0)
            {
                errMessage = "�Ώۃ}�X�^��ݒ肵�Ă��������B";
                errComponent = this.tce_CustomerDiv;
                status = false;

                return status;
            }

            // ���Ӑ�̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu���Ӑ�̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_CustomerDiv.SelectedIndex == 1
                && (this.tce_SectionDiv.SelectedIndex == 2
                || this.tce_TantowusyaDiv.SelectedIndex == 2
                || this.tce_DistrictDiv.SelectedIndex == 2
                || this.tce_TypeBusinessDiv.SelectedIndex == 2))
            {
                errMessage = string.Format("���Ӑ�{0}", ct_InputError);
                errComponent = this.tce_CustomerDiv;
                status = false;

                return status;
            }
            // �S���҂̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu�S���҂̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_TantowusyaDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 3)
            {
                errMessage = string.Format("�S����{0}", ct_InputError);
                errComponent = this.tce_TantowusyaDiv;
                status = false;

                return status;
            }
            // ���s�҂̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu���s�҂̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_PublisherDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 5)
            {
                errMessage = string.Format("���s��{0}", ct_InputError);
                errComponent = this.tce_PublisherDiv;
                status = false;

                return status;
            }
            // �󒍎҂̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu�󒍎҂̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_ReceiveOrderDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 4)
            {
                errMessage = string.Format("�󒍎�{0}", ct_InputError);
                errComponent = this.tce_ReceiveOrderDiv;
                status = false;

                return status;
            }
            // �n��̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu�n��̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_DistrictDiv.SelectedIndex == 1
                 && this.tce_SectionDiv.SelectedIndex == 6)
            {
                errMessage = string.Format("�n��{0}", ct_InputError);
                errComponent = this.tce_DistrictDiv;
                status = false;

                return status;
            }
            // �Ǝ�̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu�Ǝ�̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_TypeBusinessDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 7)
            {
                errMessage = string.Format("�Ǝ�{0}", ct_InputError);
                errComponent = this.tce_TypeBusinessDiv;
                status = false;

                return status;
            }
            // �̔��敪�̖ڕW�ݒ肪�u�s���v�̏ꍇ�ŁA���̐ݒ荀�ڂɁu�̔��敪�̖ڕW����Đݒ�v�����݂����ꍇ�̓G���[�Ƃ���B
            if (this.tce_SalesDivisionDiv.SelectedIndex == 1
                && this.tce_SectionDiv.SelectedIndex == 8)
            {
                errMessage = string.Format("�̔��敪{0}", ct_InputError);
                errComponent = this.tce_SalesDivisionDiv;
                status = false;

                return status;
            }
            // �Ώۊ����u�����v�̏ꍇ�A�K�p������͂��Ȃ��A�G���[�Ƃ���B
            if (this.tce_ObjectPeriodDiv.SelectedIndex == 1
                && string.IsNullOrEmpty(this.tNedit_Past.Text.Trim()))
            {
                errMessage = string.Format("�K�p��{0}", ct_NoInput); ;
                errComponent = this.tNedit_Past;
                status = false;

                return status;
            }

            // �K�p�� > ���񌎎��X�V�N���A�G���[�Ƃ���B
            if (this.tNedit_Past.GetInt() > appMonth)
            {
                errMessage = string.Format("�K�p��{0}", ct_NoInput); ;
                errComponent = this.tNedit_Past;
                status = false;

                return status;
            }

            return status;
        }
        #endregion �� ���̓`�F�b�N���� ��

        #region �� Control Event ��
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: 杍^</br>
        /// <br>Date		: 2009.05.07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ObjMstSetGroup") ||
                (e.Group.Key == "DetailSetGroup"))
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.05.07</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ObjMstSetGroup") ||
                (e.Group.Key == "DetailSetGroup"))
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}