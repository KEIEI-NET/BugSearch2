//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : ���ώ�`���������t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���ώ�`��������
    /// </summary>
    /// <remarks>
    /// Note       : ���ώ�`�����̏������s���B<br />
    /// Programmer : ���`<br />
    /// Date       : 2010/04/22<br />
    /// </remarks>
    public partial class PMTEG05101UA : Form
    {
        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMTEG05101U";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���㌎�������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAYREC_INITIALIE_FAILED = "���㌎�������擾�̏��������ŃG���[���������܂����B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u�d�����������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAYPAY_INITIALIE_FAILED = "�d�����������擾�̏��������ŃG���[���������܂����B";
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �R���X�g���N�^�̏��������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public PMTEG05101UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // ��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            this._settlementBillDelAcs = SettlementBillDelAcs.GetInstance();
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
        // ��ƃR�[�h
        private string _enterpriseCode;
        // �O���������
        private DateTime _prevTotalMonth;
        private ObjAutoSetAcs _objAutoSetAcs;
        //���t�擾���i
        private DateGetAcs _dateGet;
        //���ώ�`���������A�N�Z�X�N���X
        private SettlementBillDelAcs _settlementBillDelAcs;
        #endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void PMTEG05101UA_Load(object sender, EventArgs e)
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
        /// <br>Note       : �{�^�������ݒ菈�����s��</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.Main_UTabControl.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];

        }
        # endregion

        #region �� ��ʃf�[�^�̏��������� ��
        /// <summary>
        /// ��ʃf�[�^�̏���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʃf�[�^�̏������������s��</br>
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ��`�敪
            this.BillDiv_tComboEditor.SelectedIndex = 0;

            // �����N�����擾
            this.ProcessDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;

            //�d���x���Ǘ��I�v�V����
            PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            //���|�L�̏ꍇ�A�����t�H�[�J�X�͎�`�敪�Ƃ���
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.BillDiv_tComboEditor.Focus();
            }
            else
            {
                this.BillDiv_tComboEditor.Enabled = false;
                this.BillDiv_tComboEditor.Appearance.BackColor = Color.Gray;
                this.ProcessDate_tDateEdit.Focus();
            }
            //�O�񌎎��X�V��
            GetHisTotalDayProc();
        }
        #endregion

        #endregion

        #region �� �O�񌎎��X�V���擾�������� ��
        /// <summary>
        /// �O�񌎎��X�V���擾��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O�񌎎��X�V���擾���������ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            // �O�񌎎��X�V���擾�O��������
            //�O�񌎎��X�V��
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            status = totalDayCalculator.InitializeHisMonthlyAccRec();

            int billDivIndex = this.BillDiv_tComboEditor.SelectedIndex;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̒��ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                //����`
                if (billDivIndex == 0)
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                else
                {
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                }
                if (prevTotalDay == DateTime.MinValue)
                {
                    // ������ݒ�
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.ProcessDate_tDateEdit.SetDateTime(nowYearMonth);
                }
                else
                {
                    // ����O�񌎎��X�V����ݒ�
                    this.ProcessDate_tDateEdit.SetDateTime(prevTotalDay);
                }
                this._prevTotalMonth = this.ProcessDate_tDateEdit.GetDateTime();
            }
            else
            {
                // �����������s
                //����`
                if (billDivIndex == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYREC_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        MSG_TOTALDAYPAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
                }
            }
        }
        #endregion

        #region �� ���ώ�`�����������b�\�h�֘A ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
        }

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// ���ώ�`���������O�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ���ώ�`���������O�`�F�b�N�������s���B</br>
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string message, ref Control errControl)
        {
            message = "";
            bool result = true;
            errControl = null;

            DateGetAcs.CheckDateResult cdrResult;
            // �Ώ۔N��
            if (!CallCheckDateRange(out cdrResult, ref ProcessDate_tDateEdit))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = "���������w�肵�Ă��������B";
                            result = false;
                            errControl = this.ProcessDate_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = "�������̓��͂��s���ł��B";
                            result = false;
                            errControl = this.ProcessDate_tDateEdit;
                        }
                        break;
                }
                return result;
            }
            //���͓��t���O�񌎎��X�V���̏ꍇ�̓G���[�Ƃ��čē��͂Ƃ���
            if (this.ProcessDate_tDateEdit.GetDateTime().CompareTo(this._prevTotalMonth) > 0)
            {
                message = "�������͑O�񌎎��X�V���ȑO�i�������܂ށj�ł��B";
                result = false;
                errControl = this.ProcessDate_tDateEdit;
                this.ProcessDate_tDateEdit.SetDateTime(this._prevTotalMonth);
                return result;
            }

            return result;
        }

        /// <summary>
        /// ���t(YYYYMMDD)�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="TargetDate_tDateEdit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���t(YYYYMMDD)�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit TargetDate_tDateEdit)
        {
            cdrResult = _dateGet.CheckDate(ref TargetDate_tDateEdit);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }
        #endregion
        #endregion

        #region �� ���ώ�`�������� ��
        /// <summary>
        /// ���ώ�`��������
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ���ώ�`�����������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            // �����敪
            int procDiv = this.BillDiv_tComboEditor.SelectedIndex;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���ώ�`��������";
            form.Message = "���݁A���ώ�`�̏����������ł��B\r\n���΂炭���҂���������";

            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show();
            int pieceDelete;
            int totalpiece;
            int status = this._settlementBillDelAcs.SettlementBillDelProc(this._enterpriseCode, this.ProcessDate_tDateEdit.GetLongDate(), 
                            TDateTime.DateTimeToLongDate(this._prevTotalMonth), this.BillDiv_tComboEditor.SelectedIndex, out pieceDelete, out totalpiece);

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
                string totalpieceStr = string.Format("{0:N}", totalpiece);
                string pieceDeleteStr = string.Format("{0:N}", pieceDelete);
                this.PieceDelete_TextEditor.Text = pieceDeleteStr.Substring(0, pieceDeleteStr.Length - 3);
                this.PieceTotal_TextEditor.Text = totalpieceStr.Substring(0, totalpieceStr.Length - 3);
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

        #region �� ��`�敪�R���{�{�b�N�X�ύX ��
        /// <summary>
        /// ��`�敪�R���{�{�b�N�X�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ��`�敪�R���{�{�b�N�X�ύX�������s���B</br>
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void BillDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //�O�񌎎��X�V���擾��������
            GetHisTotalDayProc();
            this.PieceDelete_TextEditor.Clear();
            this.PieceTotal_TextEditor.Clear();
        }
        #endregion

        #region �� �������ύX ��
        /// <summary>
        /// �������ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �������ύX�������s���B</br>
        /// <br>Programmer	: ���`</br>
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void ProcessDate_tDateEdit_ValueChanged(object sender, EventArgs e)
        {
            this.PieceDelete_TextEditor.Clear();
            this.PieceTotal_TextEditor.Clear();
        }
        #endregion
    }
}