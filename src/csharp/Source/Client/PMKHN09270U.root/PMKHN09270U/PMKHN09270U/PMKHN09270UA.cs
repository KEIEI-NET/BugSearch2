//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ꊇ���A���X�V
// �v���O�����T�v   : �ꊇ���A���X�V�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ꊇ���A���X�V
    /// </summary>
    /// <remarks>
    /// Note       : �ꊇ���A���X�V�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009/12/24<br />
    /// </remarks>
    public partial class PMKHN09270UA : Form
    {
        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMKHN09270U";
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �R���X�g���N�^�̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public PMKHN09270UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._mainOfficeFunc = false;
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            this._allRealUpdToolAcs = AllRealUpdToolAcs.GetInstance();
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
        private ObjAutoSetAcs _objAutoSetAcs;
        //���t�擾���i
        private DateGetAcs _dateGet;
        private AllRealUpdToolAcs _allRealUpdToolAcs;
        #endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void PMKHN09270UA_Load(object sender, EventArgs e)
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

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.uButton_SectionGuideStr.ImageList = this._imageList16;
            this.uButton_SectionGuideStr.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuideEnd.ImageList = this._imageList16;
            this.uButton_SectionGuideEnd.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion

        #region �� ��ʃf�[�^�̏��������� ��
        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̂��s��</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���_
            this.tComboEditor_ProcDiv.SelectedIndex = 0;

            // �����N�����擾
            this.TargetDateSt_tDateEdit.DateFormat = emDateFormat.df4Y2M;
            this.TargetDateEd_tDateEdit.DateFormat = emDateFormat.df4Y2M;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                // ���㍡�񌎎��X�V����ݒ�
                this.TargetDateSt_tDateEdit.SetDateTime(currentTotalMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(currentTotalMonth);
            }
            else
            {
                // ������ݒ�
                DateTime nowYearMonth;
                this._dateGet.GetThisYearMonth(out nowYearMonth);

                this.TargetDateSt_tDateEdit.SetDateTime(nowYearMonth);
                this.TargetDateEd_tDateEdit.SetDateTime(nowYearMonth);
            }
        }
        #endregion

        #region �� ���_�K�C�h���� ��
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void uButton_SectionGuideStr_Click(object sender, EventArgs e)
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
                this.tNedit_SectionCodeStr.Text = secInfoSet.SectionCode.Trim();
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void uButton_SectionGuideEnd_Click(object sender, EventArgs e)
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
                this.tNedit_SectionCodeEnd.Text = secInfoSet.SectionCode.Trim();
            }
        }
        #endregion
        #endregion

        #region �� �ꊇ���A���X�V�������b�\�h�֘A ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
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
                case "ButtonTool_Run":
                    {
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "���������s���܂����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // ���s����
                                this.ExecuteProcess();
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ���_�R�[�h
                case "tNedit_SectionCodeStr":
                    {
                        if ("00".Equals(this.tNedit_SectionCodeStr.Text)
                            || "0".Equals(this.tNedit_SectionCodeStr.Text))
                        {
                            this.tNedit_SectionCodeStr.Text = string.Empty;
                        }
                        break;
                    }
                case "tNedit_SectionCodeEnd":
                    {
                        if ("00".Equals(this.tNedit_SectionCodeEnd.Text)
                            || "0".Equals(this.tNedit_SectionCodeEnd.Text))
                        {
                            this.tNedit_SectionCodeEnd.Text = string.Empty;
                        }
                        break;
                    }
            }
        }

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// �ꊇ���A���X�V�O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �ꊇ���A���X�V�O�`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/24</br>
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
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
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
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="errControl">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            const string ct_NoInput = "���w�肵�Ă��������B";
            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // ���_�J�n
            string sectionCodeStr = this.tNedit_SectionCodeStr.Text;
            int resultStr = 0;
            if (!string.IsNullOrEmpty(sectionCodeStr) && !int.TryParse(sectionCodeStr, out resultStr))
            {
                message = string.Format("���_{0}", ct_InputError);
                errControl = this.tNedit_SectionCodeStr;
                result = false;
                return result;
            }

            // ���_�I��
            string sectionCodeEnd = this.tNedit_SectionCodeEnd.Text;
            int resultEnd = 0;
            if (!string.IsNullOrEmpty(sectionCodeEnd) && !int.TryParse(sectionCodeEnd, out resultEnd))
            {
                message = string.Format("���_{0}", ct_InputError);
                errControl = this.tNedit_SectionCodeEnd;
                result = false;
                return result;
            }

            // ���_�召�`�F�b�N
            if (!string.IsNullOrEmpty(sectionCodeStr) && !string.IsNullOrEmpty(sectionCodeEnd) && resultStr > resultEnd)
            {
                message = string.Format("���_{0}", ct_RangeError);
                errControl = this.tNedit_SectionCodeStr;
                result = false;
                return result;
            }

            DateGetAcs.CheckDateRangeResult cdrResult;
            // �Ώ۔N��
            if (CallCheckDateRange(out cdrResult, ref TargetDateSt_tDateEdit, ref TargetDateEd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            message = string.Format("�J�n�Ώ۔N��{0}", ct_NoInput);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n�Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            message = string.Format("�I���Ώ۔N��{0}", ct_NoInput);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I���Ώ۔N��{0}", ct_InputError);
                            errControl = this.TargetDateEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("�Ώ۔N��{0}", ct_RangeError);
                            errControl = this.TargetDateSt_tDateEdit;
                        }
                        break;
                }
                return result;
            }
            return true;
        }

        /// <summary>
        /// ���t(YYYYMMDD)�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="TargetDateSt_tDateEdit"></param>
        /// <param name="TargetDateEd_tDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t(YYYYMMDD)�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit TargetDateSt_tDateEdit, ref TDateEdit TargetDateEd_tDateEdit)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref TargetDateSt_tDateEdit, ref TargetDateEd_tDateEdit, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion
        #endregion

        #region �� �ꊇ���A���X�V ��
        /// <summary>
        /// �ꊇ���A���X�V����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �ꊇ���A���X�V�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            // �����敪
            int procDiv = this.tComboEditor_ProcDiv.SelectedIndex;
            // �����敪���u����v�̏ꍇ
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork = new MTtlSalesUpdParaWork();
            mTtlSalesUpdParaWork.EnterpriseCode = this._enterpriseCode;
            mTtlSalesUpdParaWork.AddUpSecCodeSt = this.tNedit_SectionCodeStr.Text.Trim();
            mTtlSalesUpdParaWork.AddUpSecCodeEd = this.tNedit_SectionCodeEnd.Text.Trim();
            mTtlSalesUpdParaWork.AddUpYearMonthSt = (this.TargetDateSt_tDateEdit.GetLongDate() / 100);
            mTtlSalesUpdParaWork.AddUpYearMonthEd = (this.TargetDateEd_tDateEdit.GetLongDate() / 100);
            mTtlSalesUpdParaWork.SlipRegDiv = 1;
            mTtlSalesUpdParaWork.MTtlSalesPrcFlg = 1;
            mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg = 1;
            // �����敪���u�d���v�̏ꍇ
            MTtlStockUpdParaWork mTtlStockUpdParaWork = new MTtlStockUpdParaWork();
            mTtlStockUpdParaWork.EnterpriseCode = this._enterpriseCode;
            mTtlStockUpdParaWork.StockSectionCdSt = this.tNedit_SectionCodeStr.Text.Trim();
            mTtlStockUpdParaWork.StockSectionCdEd = this.tNedit_SectionCodeEnd.Text.Trim();
            mTtlStockUpdParaWork.StockDateYmSt = (this.TargetDateSt_tDateEdit.GetLongDate() / 100);
            mTtlStockUpdParaWork.StockDateYmEd = (this.TargetDateEd_tDateEdit.GetLongDate() / 100);
            mTtlStockUpdParaWork.SlipRegDiv = 1;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�ꊇ���A���X�V";
            form.Message = "���݁A�������ł��B";

            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show();

            int status = _allRealUpdToolAcs.AllRealUpdToolProc(mTtlSalesUpdParaWork, mTtlStockUpdParaWork, procDiv);

            // �_�C�A���O�����
            form.Close();
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�������������܂����B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�Y���f�[�^������܂���B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�������ɃG���[���������܂����B�i" + status.ToString() + "�j",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion
    }
}