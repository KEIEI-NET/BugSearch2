//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\���ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���[�����M����\��
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//


using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Net.NetworkInformation;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�����M����\�� ���̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����M����\�����̓t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class PMKHN04151UA : Form
    {

        #region �� private member
        /// <summary>�C���[�W���X�g</summary>
        /// <remarks></remarks>
        private ImageList _imageList16 = null;

        /// <summary>PMKHN04151UB�I�u�W�F�N�g</summary>
        /// <remarks></remarks>
        private PMKHN04151UB _inputDetails;

        /// <summary>�����_</summary>
        /// <remarks></remarks>
        private string _loginSectionCode;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks></remarks>
        private string _enterpriseCode;

        /// <summary>���[�����M����\�� �����f�[�^</summary>
        /// <remarks></remarks>
        private QrMailHistSearchCond _qrMailHistSearchCond;

        /// <summary>���[�����M����\�� �e�[�u���A�N�Z�X�N���X</summary>
        /// <remarks></remarks> 
        private MailHistAcs _mailHistAcs = null;

        //���t�擾���i
        private DateGetAcs _dateGet;

        //�G���[�������b�Z�[�W
        const string ct_InputError = "�̓��͂��s���ł��B";
        const string ct_NoInput = "����͂��ĉ������B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";
        #endregion

        #region �� Constroctors
        /// <summary>
        /// ���[�����M����\�� ���̓t�H�[���N���X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�����M����\�� ���̓t�H�[���N���X�N���X�̃R���X�g���N�^�ł�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04151UA()
        {
            InitializeComponent();

            _qrMailHistSearchCond = new QrMailHistSearchCond();
            this._mailHistAcs = MailHistAcs.GetInstance();

            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

            this._inputDetails = new PMKHN04151UB();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._inputDetails.GridKeyDownTopRow += new EventHandler(this.uGrid_Details_GridKeyDownTopRow);
        }
        #endregion

        #region �� private mothod
        /// <summary>
        /// �A�C�R���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A�C�R����ݒ肷��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            Infragistics.Win.UltraWinToolbars.LabelTool loginLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];

            closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            loginLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
        /// ���͍��ڃ`�F�b�N����
        /// </summary>
        /// <returns>Control</returns>
        /// <remarks>
        /// <br>Note       : ���͍��ڃ`�F�b�N�������s���B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private Control CheckInputPara()
        {
            string errMessage = null;

            # region �K�{���̓`�F�b�N

            //���t
            DateGetAcs.CheckDateRangeResult cdrResult;

           // ���ԁi�J�n�`�I���j
            if (CallCheckDateForYearMonthDayRange(out cdrResult, ref tDateEdit_St_During, ref tDateEdit_Ed_During) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_NoInput);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_St_During.Focus();
                            return tDateEdit_St_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n��{0}", ct_InputError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_St_During.Focus();
                            return tDateEdit_St_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I����{0}", ct_NoInput);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I����{0}", ct_InputError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۓ�{0}", ct_RangeError);
                            TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        errMessage,
                                        0,
                                        MessageBoxButtons.OK);
                            tDateEdit_Ed_During.Focus();
                            return tDateEdit_Ed_During;
                        }
                }
            }

            # endregion �K�{���̓`�F�b�N

            return null;
           }

        /// <summary>
       /// ���t(YYYYMMDD)�`�F�b�N�����Ăяo��
       /// </summary>
       /// <param name="cdrResult"></param>
       /// <param name="tde_St_OrderDataCreateDate"></param>
       /// <param name="tde_Ed_OrderDataCreateDate"></param>
       /// <returns>���̓`�F�b�N����</returns>
       /// <remarks>
       /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
       /// <br>Programmer : ������</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CallCheckDateForYearMonthDayRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
       {
           cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, false, false, true);
           return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
       }

        /// <summary>
       /// ���O�I�����I�����C����ԃ`�F�b�N����
       /// </summary>
       /// <returns>�`�F�b�N��������</returns>
       /// <remarks>
       /// <br>Note       : ���O�I�����I�����C����ԃ`�F�b�N�������s���B </br>
       /// <br>Programmer : ������</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CheckOnline()
       {
           if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
           {
               return false;
           }
           else
           {
               // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
               if (CheckRemoteOn() == false)
               {
                   return false;
               }
           }

           return true;
       }

        /// <summary>
       /// �����[�g�ڑ��\����
       /// </summary>
       /// <returns>���茋��</returns>
       /// <remarks>
       /// <br>Note       : �����[�g�ڑ��\���菈�����s���B </br>
       /// <br>Programmer : ������</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private bool CheckRemoteOn()
       {
           bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

           if (isLocalAreaConnected == false)
           {
               // �C���^�[�l�b�g�ڑ��s�\���
               return false;
           }
           else
           {
               return true;
           }
       }

        /// <summary>
       /// ��ʃw�b�_�N���A����
       /// </summary>
       /// <returns></returns>
       /// <remarks>
       /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
       /// <br>Programmer : ������</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
        private void Clear()
       {
           this.tDateEdit_St_During.SetDateTime(DateTime.Today);
           this.tDateEdit_Ed_During.SetDateTime(DateTime.Today);

           this._mailHistAcs.ClearMailHisResultDataTable();
       }

       /// <summary>
       /// �O���b�h�ŏ�ʍs�L�[�_�E���C�x���g
       /// </summary>
       /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
       /// <param name="e">�C�x���g�p�����[�^�N���X</param>
       /// <remarks>
       /// <br>Note       : ��ʃw�b�_�N���A�������s���B </br>
       /// <br>Programmer : ������</br>
       /// <br>Date       : 2010/05/25</br>
       /// </remarks>
       private void uGrid_Details_GridKeyDownTopRow(object sender, EventArgs e)
       {
           this.tDateEdit_Ed_During.Focus();
       }

        # region [����]
        /// <summary>
        /// ���[�����M�����������s����
        /// </summary>
        /// <returns>Control</returns>
        /// <remarks>
        /// <br>Note       : ���[�����M�����������s���B </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private Control SearchMailHisResults()
        {
            // ���͍��ڃ`�F�b�N����
            Control control = this.CheckInputPara();

            if (control != null)
            {
                return control;
            }

            this._mailHistAcs.ClearMailHisResultDataTable();

            // �Ǎ������p�����[�^�N���X�ݒ菈��
            this.SetReadPara(ref _qrMailHistSearchCond);

            // �I�t���C����ԃ`�F�b�N	
            if (!CheckOnline())
            {
                // �I�t���C����ԃ`�F�b�N	
                if (!CheckOnline())
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,
                        "���[�����M����",
                        "���[�����M����" + "�f�[�^�ǂݍ��݂Ɏ��s���܂����B",
                        (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                return control;
            }

            string errMess = string.Empty;
            int status = this._mailHistAcs.SearchQRMailHist(_qrMailHistSearchCond, out errMess);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�Y���f�[�^�����݂��܂���B",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            this.Name,
                            errMess,
                            0,
                            MessageBoxButtons.OK);
            }
            return null;
        }

        /// <summary>
        /// �Ǎ������p�����[�^�ݒ菈��
        /// </summary>
        /// <param name="qrMailHistSearchCond">��������</param>
        /// <remarks>
        /// <br>Note        : �Ǎ������p�����[�^�ݒ���s��</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        public void SetReadPara(ref QrMailHistSearchCond qrMailHistSearchCond)
        {
            // �����������i�[����p�����[�^�N���X�̃C���X�^���X���쐬
            qrMailHistSearchCond = new QrMailHistSearchCond();
            qrMailHistSearchCond.TransmitDateSt = this.tDateEdit_St_During.GetDateTime();
            qrMailHistSearchCond.TransmitDateEd = this.tDateEdit_Ed_During.GetDateTime();
        }
        # endregion

        #endregion

        #region �� event
        /// <summary>�t�H�[�����[�h</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�����[�h�������s��</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void PMKHN04151UA_Load(object sender, EventArgs e)
        {
            this.panel_Detail.Controls.Add(this._inputDetails);
            this._inputDetails.Dock = DockStyle.Fill;
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �����_�R�[�h���擾����
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();

            this.ButtonInitialSetting();

            // ���ɖ߂�����
            this.Clear();

            this.timer_InitialSetFocus.Enabled = true;

        }

        /// <summary>
        /// �t�H�[���I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKHN04151UA_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���L�[�ł̃t�H�[�J�X�ړ��C�x���g���s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // ���M���i�J�n�j
                //-----------------------------------------------------
                case "tDateEdit_St_During":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this._inputDetails.uGrid_Details;
                                        if ((this._inputDetails.uGrid_Details.ActiveRow == null) && (this._inputDetails.uGrid_Details.Rows.Count != 0))
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        else if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                        {
                                            this.SearchMailHisResults();
                                            if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                        else
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        } 
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // ���M���i�I���j
                //-----------------------------------------------------
                case "tDateEdit_Ed_During":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        // �ړ����Ȃ�
                                        e.NextCtrl = this._inputDetails.uGrid_Details;
                                        if ((this._inputDetails.uGrid_Details.ActiveRow == null) && (this._inputDetails.uGrid_Details.Rows.Count != 0))
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        else if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                        {
                                            this.SearchMailHisResults();
                                            if (this._inputDetails.uGrid_Details.Rows.Count == 0)
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                        else
                                        {
                                            this._inputDetails.uGrid_Details.ActiveRow.Selected = true;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
                //-----------------------------------------------------
                // ����
                //-----------------------------------------------------
                case "uGrid_Details":
                    {
                        # region [�t�H�[�J�X����]
                        // �t�H�[�J�X����
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this._inputDetails.uGrid_Details.ActiveRow != null)
                                        {
                                            // ���[�����e�\����ʂ̕\��
                                            this._inputDetails.ShowMailContent();
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                            }
                        }
                        #endregion
                        break;
                    }
            }

            if (e.Key == Keys.Up && _inputDetails.uGrid_Details.ActiveRow != null)
            {
                // �ŏ�s�ł́��L�[
                if (this._inputDetails.uGrid_Details.ActiveRow.Index == 0)
                {
                    e.NextCtrl = tDateEdit_St_During;
                }
            }

        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        :�c�[���o�[�{�^���N���b�N�C�x���g���s���B </br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ��������
                        SearchMailHisResults();
                        break;

                    }
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        // �����t�H�[�J�X
                        this.tDateEdit_St_During.Focus();
                        break;
                    }
            }

        }

        /// <summary>
        /// timer_InitialSetFocus_Tick�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        :timer_InitialSetFocus_Tick�C�x���g���s���B </br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2010/05/25</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            // �������t�H�[�J�X
            this.timer_InitialSetFocus.Enabled = false;
            this.tDateEdit_St_During.Focus();
        }
        #endregion

    }

}