//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�p�^�[�����������Ɖ�
// �v���O�����T�v   : ���[�J�[�p�^�[�����������Ɖ�̌������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ���O
// �� �� ��  2020/03/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ��
// �� �� ��  2020/04/28  �C�����e : �O���b�h�ɔ������ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�J�[�p�^�[�����������Ɖ�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ�C���t���[���̒�`�Ǝ������s���N���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
    public partial class PMKHN09783UB :Form
    {
        #region ��Private Const
        /// <summary>�I���{�^��</summary>
        private const string ButtonToolClose = "ButtonTool_Close";
        /// <summary>�����{�^��</summary>
        private const string ButtonToolSearch = "ButtonTool_Search";
        /// <summary>�N���A�{�^��</summary>
        private const string ButtonToolClear = "ButtonTool_Clear";
        /// <summary>���O�C���S���҃^�C�g��</summary>
        private const string LabelToolLoginTitle = "LabelTool_LoginTitle";
        /// <summary>���O�C���S���Җ���</summary>
        private const string LabelToolLoginName = "LabelTool_LoginName";

        /// <summary>�J�n�������t�����N�����̃��b�Z�[�W</summary>
        private const string SearchDateBeginInvalidDate = "�J�n�������t�̓��͂��s���ł��B";
        /// <summary>�I���������t�����N�����̃��b�Z�[�W</summary>
        private const string SearchDateEndInvalidDate = "�I���������t�̓��͂��s���ł��B";
        /// <summary>�������t�J�n���I���̃��b�Z�[�W</summary>
        private const string SearchDateStartEndError = "�������t�͈͎̔w��Ɍ�肪����܂��B";
        /// <summary>���[�J�[���擾�G���[�̃��b�Z�[�W</summary>
        private const string GoodsMakerInfoSearchError = "���[�J�[���擾�Ɏ��s���܂����B";
        /// <summary>���[�J�[���擾�ł��Ȃ��̃��b�Z�[�W</summary>
        private const string GoodsMakerInfoEmptyError = "���[�J�[�R�[�h�����݂��܂���B";
        /// <summary>�f�[�^���擾�ł��Ȃ��̃��b�Z�[�W</summary>
        private const string DataInfoEmptyError = "�Y������f�[�^������܂���B";
        /// <summary>�������擾�G���[�̃��b�Z�[�W</summary>
        private const string HisInfoSearchError = "���������Ɏ��s���܂����B";
        /// <summary>�O���b�h��\����ԕۑ������G���[�̃��b�Z�[�W</summary>
        private const string ColDisplayStatusSaveError = "�O���b�h��\����ԕۑ������Ɏ��s���܂����B";
        /// <summary>��\����ԃZ�b�e�B���OXML�t�@�C����</summary>
        private const string FileNameColDisplayStatus = "PMKHN09783U_ColSetting.DAT";
        /// <summary>���o����ʂ̃^�C�g��</summary>
        private const string SearchFormTitle = "���o��";
        /// <summary>���o����ʂ̃��b�Z�[�W</summary>
        private const string SearchFormMessage = "�f�[�^���o���ł��B";
        /// <summary>�v���O����ID</summary>
        private const string AssemblyId = "PMKHN09783U";
        /// <summary>�v���O�������O</summary>
        private const string AssemblyName = "���[�J�[�p�^�[�����������Ɖ�";
        /// <summary>��ʃ��j���[</summary>
        private const string Toolbars = "Toolbars";

        /// <summary>0������</summary>
        private const string StringZero = "0";
        /// <summary>00������</summary>
        private const string StringZZ = "00";
        /// <summary>0000������</summary>
        private const string StringZZZZ = "0000";
        /// <summary>000000������</summary>
        private const string StringZZZZZZ = "000000";
        /// <summary>/������</summary>
        private const string StringSlash = "/";
        /// <summary>���o�^</summary>
        private const string Status0 = "���o�^";
        /// <summary>����o�^</summary>
        private const string Status1 = "����o�^";
        /// <summary>�o�^�G���[</summary>
        private const string Status2 = "�o�^�G���[";
        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>����</summary>
        private const string KinDUoeOrderExists = "�L";
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<
        /// <summary>-1�X�e�[�^�X</summary>
        private const int StatusError = -1;
        /// <summary>0�X�e�[�^�X</summary>
        private const int StatusNormal = 0;

        /// <summary>�O���b�h�̃A�N�e�B�u�s�̃C���f�b�N�X�u0�v�F�O���b�h�̍ŏ�s</summary>
        private const int ActiveRowIndexZero = 0;
        /// <summary>���t�u0�v�F���t������</summary>
        private const int LongDateZero = 0;
        /// <summary>�O���b�h�f�[�^�����u0�v�F�O���b�h�f�[�^����0��</summary>
        private const int SearchHisGridRowsCountZero = 0;
        /// <summary>���[�J�[�R�[�h�u0�v�F���[�J�[�R�[�h������</summary>
        private const int GoodsMakerCdZero = 0;
        /// <summary>������̈ꕔ���擾(Substring�p:0)</summary>
        private const int SubstringIndexZero = 0;
        /// <summary>������̈ꕔ���擾(Substring�p:2)</summary>
        private const int SubstringIndexTwo = 2;
        /// <summary>������̈ꕔ���擾(Substring�p:4)</summary>
        private const int SubstringIndexFour = 4;
        /// <summary>������̈ꕔ���擾(Substring�p:6)</summary>
        private const int SubstringIndexSix = 6;
        /// <summary>������̒��x(Length:8)</summary>
        private const int StringLengthEight = 8;

        /// <summary>���[�J�[�R�[�h</summary>
        private const string GoodsMakerCdCaption = "���[�J�[";
        /// <summary>���[�J�[</summary>
        private const string GoodsMakerNameCaption = "���[�J�[��";
        /// <summary>�ŏI���t</summary>
        private const string SearchDateCaption = "�ŏI���t";
        /// <summary>�o�[�R�[�h</summary>
        private const string BarCodeDataCaption = "�o�[�R�[�h";
        /// <summary>�p�^�[����</summary>
        private const string MakerGoodsPtrnNoCaption = "�p�^�[����";
        /// <summary>�����i��</summary>
        private const string SearchGoodsNoCaption = "�����i��";
        /// <summary>�m��i��</summary>
        private const string EntryGoodsNoCaption = "�m��i��";
        /// <summary>��</summary>
        private const string UseCountCaption = "��";
        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>����</summary>
        private const string UoeOrderDtlKindCaption = "����";
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<
        /// <summary>����</summary>
        private const string EntryStatusCaption = "����";
        
        #endregion �� Private Const

        # region ��Private Members

        /// <summary>�R���g���[�����i�X�L��</summary>
        private ControlScreenSkin ControlScreenSkinAccessor = null;
        /// <summary>��ʃC���[�W</summary>
        private ImageList ImageList16 = null;
        /// <summary>��ƃR�[�h</summary>
        private string EnterpriseCode = string.Empty;
        /// <summary>���[�J�[�i�ԃp�^�[���A�N�Z�X�N���X</summary>
        private HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAccessor = null;
        /// <summary>���t�A�N�Z�X�N���X</summary>
        private DateGetAcs DateGetAccessor = null;
        /// <summary>���[�J�[�A�N�Z�X�N���X</summary>
        private MakerAcs MakerAccessor = null;
        /// <summary>�O����̓��[�J�[�R�[�h</summary>
        private string PrevGoodsMakerCode = string.Empty;
        /// <summary>�O����̓��[�J�[��</summary>
        private string PrevGoodsMakerName = string.Empty;
        /// <summary>���׃f�[�^�i�[�f�[�^�r���[</summary>
        private DataView DataViewHis = null;
        /// <summary>���׃f�[�^�i�[�f�[�^�Z�b�g</summary>
        private MakerGoodsPtrnHisDataSet MakerGoodsPtrnHisDs = null;
        /// <summary>���[�J�[�f�B�N�V���i���[</summary>
        private Dictionary<int, string> GoodsMakerDic = null;
        /// <summary>�uenter�A�}�E�X�AF2�Ȃǁv�A���������f�p�t���O</summary>
        private bool IsSaveFlg = false;
        # endregion

        #region ��Constractor

        /// <summary>
        /// ���[�J�[�p�^�[�����������Ɖ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�p�^�[�����������Ɖ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public PMKHN09783UB()
        {
            InitializeComponent();

            // �R���g���[�����i�X�L����ݒ肵�܂��B
            this.ControlScreenSkinAccessor = new ControlScreenSkin();
            // �R���g���[�����i�C���[�W��ݒ肵�܂��B
            this.ImageList16 = IconResourceManagement.ImageList16;
            // ��ƃR�[�h���擾���܂��B
            this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���[�J�[�i�ԃp�^�[���A�N�Z�X�N���X�����������܂��B
            this.HandyMakerGoodsPtrnAccessor = new HandyMakerGoodsPtrnAcs();

            // ���t�A�N�Z�X�N���X�����������܂��B
            this.DateGetAccessor = DateGetAcs.GetInstance();

            // ���[�J�[�A�N�Z�X�N���X�����������܂��B
            this.MakerAccessor = new MakerAcs();
            // ���[�J�[�}�X�^�f�[�^�L���b�V���[���܂��B
            int status = this.GetGoodsMakerInfo();
            // ���[�J�[�����擾�ł��Ȃ��ꍇ
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(GoodsMakerInfoSearchError, status);
                this.Close();
            }
        }
        #endregion

        #region ��ControlEvent

        /// <summary>
        /// Form.Load �C�x���g (PMKHN09783UB)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����\�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UB_Load(object sender, EventArgs e)
        {
            // ��ʂ��\�z
            this.ScreenInitialSetting();
            this.ScreenClear();
        }

        /// <summary>
        ///	Control.ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control NextControl = null;

            switch (e.PrevCtrl.Name)
            {
                #region ���O���b�h���t�H�[�J�X�ړ�
                case "SearchHis_Grid":
                    {
                        NextControl = this.GetSearchHisFormFocus(e);
                        if (this.SearchHis_Grid.ActiveRow != null && e.NextCtrl != null && e.NextCtrl.Name.IndexOf(Toolbars) < 0)
                        {
                            this.SearchHis_Grid.ActiveRow.Selected = false;
                            this.SearchHis_Grid.ActiveRow = null;
                        }
                        break;
                    }
                #endregion

                #region �����[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    {
                        #region < �ҏW�`�F�b�N >
                        // �ϐ��ێ�
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt().ToString();

                        if (this.PrevGoodsMakerCode == goodsMakerCd)
                        {
                            if (goodsMakerCd == StringZero)
                            {
                                this.tNedit_GoodsMakerCd.Clear();
                                this.lb_GoodsMakerName.Text = string.Empty;
                            }
                            // �ҏW�O�Ɠ����Ȃ珈�����s�Ȃ�Ȃ�
                            // �J�[�\������
                            NextControl = this.GetSearchHisFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < ���[�J�[���� >
                        if (goodsMakerCd != StringZero)
                        {
                            string goodsMakerName = this.GetGoodsMakerName(goodsMakerCd);

                            if (string.IsNullOrEmpty(goodsMakerName))
                            {
                                #region -- �擾���s --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    GoodsMakerInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                if (!string.IsNullOrEmpty(this.PrevGoodsMakerCode))
                                {
                                    this.tNedit_GoodsMakerCd.SetInt(int.Parse(this.PrevGoodsMakerCode));
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Clear();
                                }

                                this.tNedit_GoodsMakerCd.SelectAll();
                                // �J�[�\������
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.SetInt(int.Parse(goodsMakerCd));
                                this.lb_GoodsMakerName.Text = goodsMakerName;
                                // �J�[�\������
                                NextControl = this.GetSearchHisFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.lb_GoodsMakerName.Text = string.Empty;
                            // �J�[�\������
                            NextControl = this.GetSearchHisFormFocus(e);
                        }
                        #endregion

                        #region < �ҏW�O�f�[�^�ێ� >
                        // �ҏW���ꂽ�e���i����ҏW�O�f�[�^�Ƃ��ĕێ�
                        this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                        this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ���������t�J�n
                case "tDate_SearchDateBegin":

                    // �����ȊO����͂���ꍇ�A�N���A����
                    if (this.tDate_SearchDateBegin.GetDateYear() == 0 || this.tDate_SearchDateBegin.GetDateMonth() == 0 || this.tDate_SearchDateBegin.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateBegin.Clear();
                    }
                    break;
                #endregion

                #region ���������t�I��
                case "tDate_SearchDateEnd":

                    // �����ȊO����͂���ꍇ�A�N���A����
                    if (this.tDate_SearchDateEnd.GetDateYear() == 0 || this.tDate_SearchDateEnd.GetDateMonth() == 0 || this.tDate_SearchDateEnd.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateEnd.Clear();
                    }
                    NextControl = this.GetSearchHisFormFocus(e);

                    break;
                #endregion

                #region ���̃t�H�[�J�X�␳����
                case "tEdit_SeachStr":
                case "CheckEditor_Insert":
                    NextControl = this.GetSearchHisFormFocus(e);

                    if (NextControl == this.SearchHis_Grid)
                    {
                        this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                        this.SearchHis_Grid.ActiveRow.Selected = true;
                    }

                    break;
                case "ub_GoodsMakerCd":
                case "tEdit_BarCode":
                    NextControl = this.GetSearchHisFormFocus(e);
                    break;
                #endregion
            }

            // �t�H�[�J�X�␳�R���g���[��������ꍇ
            if (NextControl != null)
            {
                e.NextCtrl = NextControl;
            }
        }

        /// <summary>
        /// �\���i�������l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �\���i�������l�ύX�C�x���g���ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tEdit_SeachStr_TextChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;

            //�\���i�荞�ޏ���
            string searchStr = this.tEdit_SeachStr.Text.Trim();

            // ���o�^�`�F�b�N�I�t�̏ꍇ
            if (this.CheckEditor_Insert.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetCheckedRowFilter();
                }
                else
                {
                    filter = this.GetAllRowFilter(searchStr);
                }
                this.DataViewHis.RowFilter = filter;
            }
            else
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    this.DataViewHis.RowFilter = string.Empty;
                }
                else
                {
                    filter = this.GetSearchStrRowFilter(searchStr);
                    this.DataViewHis.RowFilter = filter;
                }
            }

        }

        /// <summary>
        /// ���C�����j���[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���C�����j���[���N���b�N�����ۂɔ�������C�x���g�n���h��</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // �������A�ď����s��
            // IsSaveFlg��True�̏ꍇ�A�����s�BIsSaveFlg��False�̏ꍇ�A������
            if (this.IsSaveFlg)
            {
                return;
            }
            this.IsSaveFlg = true;

            #region �e�����O�A�t�H�[�J�X�A�E�g�␳����
            Control ActiveControl = this.GetActiveControl();
            if (ActiveControl != null)
            {
                if (ActiveControl != this.SearchHis_Grid)
                {
                    ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Right, this.GetActiveControl(), this.uGroupBox_ExtractInfo);
                    this.tArrowKeyControl1_ChangeFocus(sender, ex);
                }
                else
                {
                    this.uGroupBox_ExtractInfo.Focus();
                    this.SearchHis_Grid.Focus();
                }
            }
            #endregion

            try
            {
                switch (e.Tool.Key)
                {
                    #region �I��(F1)
                    case "ButtonTool_Close":
                        {
                            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                            if (this.SearchHis_Grid.ActiveCell != null)
                            {
                                this.SearchHis_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // �I������
                            this.Close();

                            break;
                        }
                    #endregion

                    #region ����(F2)
                    case "ButtonTool_Search":
                        {
                            // ���͍��ڃ`�F�b�N����
                            if (!this.CheckInputPara())
                            {
                                return;
                            }

                            // ��������
                            this.SearchProc();

                            break;
                        }
                    #endregion

                    #region �N���A(F9)
                    case "ButtonTool_Clear":
                        {
                            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
                            if (this.SearchHis_Grid.ActiveCell != null)
                            {
                                this.SearchHis_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // ��ʕύX�m�F����
                            // �I������
                            this.ScreenClear();

                            break;
                        }
                    #endregion
                }
            }
            finally
            {
                this.IsSaveFlg = false;
            }
        }


        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ub_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt MakerUMntWork;

                int Status = this.MakerAccessor.ExecuteGuid(this.EnterpriseCode, out MakerUMntWork);
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���ʃZ�b�g
                    this.tNedit_GoodsMakerCd.SetInt(MakerUMntWork.GoodsMakerCd);
                    this.lb_GoodsMakerName.Text = MakerUMntWork.MakerName;

                    #region < �ҏW�O�f�[�^�ێ� >
                    // �ҏW���ꂽ�e���i����ҏW�O�f�[�^�Ƃ��ĕێ�
                    this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                    this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                    #endregion

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �O���b�h�@�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�@�L�[�_�E���C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SearchHis_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SearchHis_Grid.ActiveRow == null) return;

            int RowIndex = this.SearchHis_Grid.ActiveRow.Index;

            if ((this.SearchHis_Grid.ActiveRow.Index == ActiveRowIndexZero && e.KeyCode == Keys.Up))
            {
                this.tEdit_SeachStr.Focus();
                this.SearchHis_Grid.ActiveRow.Selected = false;
                this.SearchHis_Grid.ActiveRow = null;

            }
        }

        /// <summary>
        /// �O���b�h�@�Z���A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�@�Z���A�N�e�B�u�O�C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SearchHis_Grid_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (this.SearchHis_Grid.ActiveRow == null) return;
            this.SearchHis_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// ���o�^�`�F�b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���o�^�`�F�b�N�C�x���g�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CheckEditor_SearchHis_CheckedChanged(object sender, EventArgs e)
        {
            string Filter = string.Empty;
            string SearchStr = this.tEdit_SeachStr.Text.Trim();

            if (this.CheckEditor_Insert.Checked)
            {
                // �\���i�����������͖����̏ꍇ
                if (string.IsNullOrEmpty(SearchStr))
                {
                    Filter = this.GetCheckedRowFilter();
                }
                else
                {

                    Filter = GetAllRowFilter(SearchStr);
                }
                this.DataViewHis.RowFilter = Filter;
            }
            else
            {
                if (string.IsNullOrEmpty(SearchStr))
                {
                    this.DataViewHis.RowFilter = string.Empty;
                }
                else
                {
                    Filter = this.GetSearchStrRowFilter(SearchStr);
                    this.DataViewHis.RowFilter = Filter;
                }
            }
        }

        /// <summary>
        /// �t�H���g�T�C�Y�l�ύX
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H���g�T�C�Y�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �t�H���g�T�C�Y��ύX
            this.SearchHis_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }

        /// <summary>
        /// ��T�C�Y�̎��������`�F�b�N�ύX
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��T�C�Y�̎��������̃`�F�b�N���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // ��T�C�Y�̎�������
            if (this.AutoFitCol_ultraCheckEditor.Checked)
                this.SearchHis_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            else
                this.SearchHis_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn wkColumn in this.SearchHis_Grid.DisplayLayout.Bands[0].Columns)
            {
                wkColumn.PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        /// <summary>
        /// �t�H�[�����鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.BeforeClosing();
            }
            catch
            {
                // �G���[���b�Z�[�W�\��
                this.ErrMsgDispProc(ColDisplayStatusSaveError, StatusError);

            }
        }

        /// <summary>
        /// �t�H�[�J�X�␳����
        /// </summary>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��̕␳�������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�t�H�[�J�X�␳�R���g���[��</returns>
        private Control GetSearchHisFormFocus(ChangeFocusEventArgs e)
        {
            Control NextControl = null;
            if (e == null || e.PrevCtrl == null) return null;

            switch (e.PrevCtrl.Name)
            {

                #region ���[�J�[�R�[�h
                case "tNedit_GoodsMakerCd":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        if (this.tNedit_GoodsMakerCd.GetInt() != GoodsMakerCdZero)
                        {
                            // �p�[�R�[�h
                            NextControl = this.tEdit_BarCode;
                        }
                        else
                        {
                            // ���[�J�[�K�C�h
                            NextControl = this.ub_GoodsMakerCd;
                        }
                    }
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // �O���b�h
                            NextControl = this.SearchHis_Grid;
                            this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                            this.SearchHis_Grid.ActiveRow.Selected = true;
                        }
                        else
                        {
                            // ���o�^�`�F�b�N
                            NextControl = this.CheckEditor_Insert;
                        }
                    }
                    break;
                #endregion
                
                #region ���[�J�[�K�C�h�{�^��
                case "ub_GoodsMakerCd":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        // �p�[�R�[�h
                        NextControl = this.tEdit_BarCode;
                    }
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        // ���[�J�[�R�[�h
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        // ���o�^�`�F�b�N
                        NextControl = this.CheckEditor_Insert;
                    }
                    break;
                #endregion

                #region �p�[�R�[�h
                case "tEdit_BarCode":
                    if (e.Key == Keys.Up)
                    {
                        // ���[�J�[�R�[�h
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // �p�[�R�[�h
                        NextControl = this.tDate_SearchDateBegin;
                    }
                    break;
                #endregion

                #region �������t�I��
                case "tDate_SearchDateEnd":
                    if (e.Key == Keys.Down)
                    {
                        // �\���i������
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        // �\���i������
                        NextControl = this.tEdit_SeachStr;
                    }
                    break;
                #endregion

                #region ���o�^�`�F�b�N
                case "CheckEditor_Insert":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // �O���b�h
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            if (this.uGroupBox_ExtractInfo.Expanded)
                            {
                                // ���[�J�[
                                NextControl = this.tNedit_GoodsMakerCd;
                            }
                            else
                            {
                                // �\���i������
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // ����������
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // �O���b�h
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            // �ړ����Ȃ�
                            NextControl = this.CheckEditor_Insert;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // �������t�I���̔N
                        NextControl = this.tDate_SearchDateEnd.Controls[5];
                    }
                    break;
                #endregion

                #region �\���i������
                case "tEdit_SeachStr":
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.uGroupBox_ExtractInfo.Expanded)
                        {
                            // �������t�I��
                            NextControl = this.tDate_SearchDateEnd;
                        }
                        else
                        {
                            if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                            {
                                // �O���b�h
                                NextControl = this.SearchHis_Grid;
                            }
                            else
                            {
                                // ���o�^�`�F�b�N
                                NextControl = this.CheckEditor_Insert;
                            }
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            // �O���b�h
                            NextControl = this.SearchHis_Grid;
                        }
                        else
                        {
                            // �ړ����Ȃ�
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // �������t�J�n�̔N
                        NextControl = this.tDate_SearchDateBegin.Controls[5];
                    }
                    break;
                #endregion

                #region �O���b�h
                case "SearchHis_Grid":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        NextControl = this.CheckEditor_Insert;
                    }
                    else if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        if (this.uGroupBox_ExtractInfo.Expanded)
                        {
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                        else
                        {
                            NextControl = this.tEdit_SeachStr;
                        }
                    }

                    break;
                #endregion

                default:
                    break;
            }
            return NextControl;
        }

        #endregion

        #region ��Private Method

        /// <summary>
        ///	��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �X�L���ݒ�
            this.ControlScreenSkinAccessor.LoadSkin();
            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this.ControlScreenSkinAccessor.SetExceptionCtrl(excCtrlNm);
            this.ControlScreenSkinAccessor.SettingScreenSkin(this);

            // �A�C�R���ݒ�
            this.ImageList16 = IconResourceManagement.ImageList16;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.ub_GoodsMakerCd.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];

            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // �c�[���A�C�R���ݒ�
            //----------------------------
            // �I��
            this.tToolsManager_MainMenu.Tools[ButtonToolClose].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ����
            this.tToolsManager_MainMenu.Tools[ButtonToolSearch].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // �N���A
            this.tToolsManager_MainMenu.Tools[ButtonToolClear].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[LabelToolLoginTitle].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[LabelToolLoginName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            this.MakerGoodsPtrnHisDs = new MakerGoodsPtrnHisDataSet();

            this.DataViewHis = new DataView(this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList);

            this.SearchHis_Grid.DataSource = this.DataViewHis;

            // �O���b�h�񏉊��ݒ菈��
            InitializeGridColumns(this.SearchHis_Grid.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        ///	��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        ///</remarks>
        private void ScreenClear()
        {
            // ��ʓ��e���N���A
            this.tDate_SearchDateBegin.Clear();
            this.tDate_SearchDateEnd.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.lb_GoodsMakerName.Text = string.Empty;
            this.PrevGoodsMakerCode = string.Empty;
            this.PrevGoodsMakerName = string.Empty;

            this.tEdit_BarCode.Text = string.Empty;
            this.tEdit_SeachStr.Text = string.Empty;
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Clear();

            // �������t�˃V�X�e�����t�Z�b�g
            DateTime dateTime = DateTime.Now;
            this.tDate_SearchDateBegin.SetDateTime(dateTime);
            this.tDate_SearchDateEnd.SetDateTime(dateTime);

            this.CheckEditor_Insert.Checked = false;

            this.tNedit_GoodsMakerCd.Focus();

        }

        /// <summary>
        /// ���͍��ڃ`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͍��ڂ��`�F�b�N���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�`�F�b�N����[true: �`�F�b�NOK, false: �`�F�b�N�G���[]</returns>
        private bool CheckInputPara()
        {
            DateGetAcs.CheckDateResult Cdr;

            // �������t�J�n
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero)
            {
                // �����N�����̏ꍇ
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_SearchDateBegin, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_SearchDateBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateBeginInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // �������t�I��
            if (this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                // �����N�����̏ꍇ
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_SearchDateEnd, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_SearchDateEnd.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateEndInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // �������t�J�n�A�I��
            // �J�n�A�I���̑召��r
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero && this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                if (this.tDate_SearchDateBegin.GetLongDate() > this.tDate_SearchDateEnd.GetLongDate())
                {
                    this.tDate_SearchDateBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        SearchDateStartEndError,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            return true;
        }

        #region �O���b�h���C�A�E�g�ݒ菈��
        /// <summary>
        /// �O���b�h���C�A�E�g�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h���C�A�E�g��ݒ肵�܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            int visiblePosition = 0;

            // �Z���I�����͍s�I����
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.SearchHis_Grid.DisplayLayout.Bands[0];
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            }

            // ���i���[�J�[�R�[�h
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.Caption = GoodsMakerCdCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Width = 70;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���i���[�J�[��
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.Caption = GoodsMakerNameCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Width = 180;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �ŏI���t
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.Caption = SearchDateCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �o�[�R�[�h
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.Caption = BarCodeDataCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �p�^�[����
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Header.Caption = MakerGoodsPtrnNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �����i��
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Header.Caption = SearchGoodsNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �m��i��
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Header.Caption = EntryGoodsNoCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Width = 120;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ��(�O���b�h�\���p)
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Header.Caption = UseCountCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // --- UPD 2020/04/28 M.KISHI ---------->>>>>
            //columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Width = 60;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Width = 30;
            // --- UPD 2020/04/28 M.KISHI ----------<<<<<
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2020/04/28 M.KISHI ---------->>>>>

            // ��(�t�B���^�p)
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Hidden = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Header.Caption = UseCountCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Width = 30;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ����
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Header.Caption = UoeOrderDtlKindCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Width = 30;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2020/04/28 M.KISHI ----------<<<<<

            // ����
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Hidden = false;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.Caption = EntryStatusCaption;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Width = 100;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �p�^�[����������ʔ�
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Hidden = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Width = 50;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Header.Fixed = true;
            columns[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsSerchHisNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //-------------------------------------------------------------
            // �O��\�����ݒ�
            //-------------------------------------------------------------
            // ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
            List<ColDisplayStatus> colDisplayStatusList = this.Deserialize(FileNameColDisplayStatus);

            foreach (ColDisplayStatus colDisplayStatus in colDisplayStatusList)
            {
                if (colDisplayStatus.Key == this.FontSize_tComboEditor.Name)
                {
                    this.FontSize_tComboEditor.Value = colDisplayStatus.Width;
                }
                else if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[�������������̌����������s�Ȃ��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>[0: ����, 4: ��������0��,0�A4�ȊO: �ُ�]</returns>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �p�����[�^��ݒ�
            HandyMakerGoodsPtrnHisCondWork condWork = new HandyMakerGoodsPtrnHisCondWork();
            // ��ƃR�[�h
            condWork.EnterpriseCode = this.EnterpriseCode;
            // ���[�J�[�R�[�h
            condWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // �������t�J�n
            condWork.SearchDateSt = GetLongDate(this.tDate_SearchDateBegin.GetDateTime());
            // �������t�I��
            condWork.SearchDateEd = GetLongDate(this.tDate_SearchDateEnd.GetDateTime());
            // �p�[�R�[�h
            condWork.BarCodeData = this.tEdit_BarCode.Text.Trim();

            // ���o����ʃC���X�^���X�쐬
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SearchFormTitle;
            sfcmn00299ca.Message = SearchFormMessage;

            ArrayList makerGoodsPtrnHisList = new ArrayList();
            object condObj = condWork as object;
            object retObj = null;

            try
            {
                // ���o����ʂ�\�����܂��B
                sfcmn00299ca.Show();
                status = this.HandyMakerGoodsPtrnAccessor.SearchHis(condObj, out retObj);
                makerGoodsPtrnHisList = (ArrayList)retObj;
            }
            finally
            {
                // ���o����ʂ���܂��B
                sfcmn00299ca.Close();
                // �O���b�h���N���A���܂��B
                this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Clear();
           }

            #region < �����㏈�� >
            switch (status)
            {
                #region -- ����I�� --
                // �S���擾���\�b�h�̌��ʂ�"����I��"�̂Ƃ�
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �������ʂ̓O���b�h�ɐݒ肵�܂��B
                        this.HisGridSetting(makerGoodsPtrnHisList);
                        // �O���b�h�I���s��ݒ肵�܂��B
                        if (this.SearchHis_Grid.Rows.Count > SearchHisGridRowsCountZero)
                        {
                            this.SearchHis_Grid.Focus();
                            this.SearchHis_Grid.ActiveRow = this.SearchHis_Grid.Rows[0];
                            this.SearchHis_Grid.ActiveRow.Selected = true;
                        }
                        // ������A�t�B�[���h���܂��B
                        this.CheckEditor_SearchHis_CheckedChanged(null, null);

                        break;
                    }
                #endregion

                #region -- �f�[�^���� --
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.InfoMsgDispProc(DataInfoEmptyError, status);
                        break;
                    }
                #endregion

                #region -- �������s --
                default:
                    {
                        this.ErrMsgDispProc(HisInfoSearchError, status);
                        break;
                    }
                #endregion
            }
            #endregion

            return status;

        }

        /// <summary>
        /// �A�N�e�B�u�R���g���[���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private Control GetActiveControl()
        {
            Control Ctrl = this.ActiveControl;

            if (Ctrl != null)
            {
                Ctrl = this.GetParentControl(Ctrl);
            }

            return Ctrl;
        }

        /// <summary>
        /// �e�R���g���[���擾����
        /// </summary>
        /// <param name="ctrl">�q�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : �e�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�e�R���g���[��</returns>
        private Control GetParentControl(Control ctrl)
        {
            Control RetCtrl = ctrl;
            if (RetCtrl.Parent != null)
            {
                if ((RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    RetCtrl = GetParentControl(RetCtrl.Parent);
                }
            }

            return RetCtrl;
        }

        /// <summary>
        /// �O���b�h�ɏ��ݒ菈��
        /// </summary>
        /// <param name="searchHisList">���[�J�[�i�ԃp�[�^������������񃊃X�g</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀ��[�J�[�i�ԃp�[�^��������������ݒ肵�܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void HisGridSetting(ArrayList searchHisList)
        {
            if (searchHisList == null || searchHisList.Count == SearchHisGridRowsCountZero)
            {
                return;
            }

            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BeginLoadData();
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Rows.Clear();

            DataRow Row = null;
            foreach (HandyMakerGoodsPtrnHisResultWork dataWork in searchHisList)
            {
                
                Row = this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.NewRow();

                // ���i���[�J�[�R�[�h
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn] = dataWork.GoodsMakerCd.ToString(StringZZZZ);

                // ���i���[�J�[����
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn] = dataWork.MakerName;

                // �ŏI���t
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn] = this.GetStringDateTimeForInt(dataWork.SearchDate);

                // �p�[�R�[�h
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn] = dataWork.BarCodeData;

                // �p�^�[����
                if (dataWork.MakerGoodsPtrnNo != 0)
                {
                    Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn] = dataWork.MakerGoodsPtrnNo.ToString(StringZZZZZZ);
                }

                // �����i��
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn] = dataWork.SearchGoodsNo;

                // �m��i��
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn] = dataWork.EntryGoodsNo;

                // ��
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountColumn] = dataWork.UseCount;
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn] = dataWork.UseCount;

                // --- ADD 2020/04/28 M.KISHI ---------->>>>>
                // ����
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn] =�@this.GetUoeOrderDtlKind(dataWork.UOEOrderTdlKind);
                // --- ADD 2020/04/28 M.KISHI ----------<<<<<

                // ����
                Row[this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn] = this.GetEntryStatus(dataWork.EntryStatus);

                this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.Rows.Add(Row);
            }
            this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EndLoadData();
        }

        /// <summary>
        /// �o�^�X�e�[�^�X���ʎ擾�@���R�[�h�˖���
        /// </summary>
        /// <param name="entryStatus">�o�^�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �o�^�X�e�[�^�X���ʂ��擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�o�^�X�e�[�^�X����</returns>
        private string GetEntryStatus(int entryStatus)
        {
            string statusNm = string.Empty;
            switch (entryStatus)
            {
                // 0:���o�^
                case 0:
                    statusNm = Status0;
                    break;
                // 1:����o�^
                case 1:
                    statusNm = Status1;
                    break;
                // -1:�o�^�G���[
                case -1:
                    statusNm = Status2;
                    break;
            }
            return statusNm;
        }

        // --- ADD 2020/04/28 M.KISHI ---------->>>>>
        /// <summary>
        /// UOE�����f�[�^�敪�擾�@���R�[�h�˖���
        /// </summary>
        /// <param name="uoeOrderDtlKind">�o�^�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^�敪���擾���܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2020/04/28</br>
        /// </remarks>
        /// <returns>UOE�����f�[�^�敪��</returns>
        private string GetUoeOrderDtlKind(int uoeOrderDtlKind)
        {
            string statusNm = string.Empty;
            switch (uoeOrderDtlKind)
            {
                // 0:���o�^
                case 0:
                    statusNm = string.Empty;
                    break;
                // 1:�����f�[�^����
                case 1:
                    statusNm = KinDUoeOrderExists;
                    break;
                // �ȊO
                default:
                    statusNm = string.Empty;
                    break;
            }
            return statusNm;
        }
        // --- ADD 2020/04/28 M.KISHI ----------<<<<<


        /// <summary>
        /// int�^�l����yyyy/MM/dd������̕ϊ�����
        /// </summary>
        /// <param name="paraDate">���Ԑ���</param>
        /// <remarks>
        /// <br>Note       : int�^�l����yyyy/MM/dd�������ϊ����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�ϊ���yyyy/MM/dd������</returns>
        private string GetStringDateTimeForInt(int paraDate)
        {
            string ResultDate = string.Empty;
            string dateStr = paraDate.ToString();
            if (dateStr.Length != StringLengthEight)
            {
                return ResultDate;
            }
            // �N
            int Year = int.Parse(dateStr.Substring(SubstringIndexZero, SubstringIndexFour));
            // ��
            int Month = int.Parse(dateStr.Substring(SubstringIndexFour, SubstringIndexTwo));
            // ��
            int Day = int.Parse(dateStr.Substring(SubstringIndexSix, SubstringIndexTwo));
            // yyyy/MM/dd
            ResultDate = Year.ToString(StringZZZZ) + StringSlash + Month.ToString(StringZZ) + StringSlash + Day.ToString(StringZZ);
            return ResultDate;
        }

        /// <summary>
        /// ���[�J�[���̃L���b�V�������B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�����L���b�V�����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�擾����[0: �擾OK, 0�ȊO: �擾�G���[]</returns>
        private int GetGoodsMakerInfo()
        {
            ArrayList MakerList = new ArrayList();
            int Status = this.MakerAccessor.SearchAll(out MakerList, this.EnterpriseCode);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.GoodsMakerDic = new Dictionary<int, string>();
                foreach (MakerUMnt MakerUMntWork in MakerList)
                {
                    if (MakerUMntWork.LogicalDeleteCode == 0 && !this.GoodsMakerDic.ContainsKey(MakerUMntWork.GoodsMakerCd))
                    {
                        this.GoodsMakerDic.Add(MakerUMntWork.GoodsMakerCd, MakerUMntWork.MakerName.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// ���[�J�[���̎擾�����B
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>���[�J�[��</returns>
        private string GetGoodsMakerName(string goodsMakerCode)
        {
            string GoodsMakerName = string.Empty;
            if (string.IsNullOrEmpty(goodsMakerCode)) return GoodsMakerName;
            int goodsMakerCodeInt = int.Parse(goodsMakerCode.Trim());

            if (this.GoodsMakerDic.ContainsKey(goodsMakerCodeInt))
            {
                GoodsMakerName = this.GoodsMakerDic[goodsMakerCodeInt];
            }

            return GoodsMakerName;
        }

        /// <summary>
        /// ���o�^�`�F�b�N�s�t�B���^������̎擾�����B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�^�`�F�b�N�s�t�B���^��������擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>���o�^�`�F�b�N�s�t�B���^������</returns>
        private string GetCheckedRowFilter()
        {
            return string.Format(" {0} = '{1}' ",
                                   this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName, string.Empty);
        }

        /// <summary>
        /// �s�����t�B���^������̎擾�����B
        /// </summary>
        /// <param name="searchStr">����������</param>
        /// <remarks>
        /// <br>Note       : �s�����t�B���^��������擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>�s�����t�B���^������</returns>
        private string GetSearchStrRowFilter(string searchStr)
        {
            return string.Format("{0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%' OR {18} like '%{19}%' ",
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn, searchStr);
        }

        /// <summary>
        /// ���o�^�s�����t�B���^������̎擾�����B
        /// </summary>
        /// <param name="searchStr">����������</param>
        /// <remarks>
        /// <br>Note       : ���o�^�s�����t�B���^��������擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>���o�^�s�����t�B���^������</returns>
        private string GetAllRowFilter(string searchStr)
        {
            return string.Format(" ({0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                 + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                 + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%') "
                                 + " AND {18} = '{19}' ",
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerCdColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.GoodsMakerNameColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchDateColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.BarCodeDataColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.MakerGoodsPtrnNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.SearchGoodsNoColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UseCountFilterColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryStatusColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.UoeOrderDtlKindColumn, searchStr,
                                    this.MakerGoodsPtrnHisDs.MakerGoodsPtrnHisList.EntryGoodsNoColumn.ColumnName, string.Empty);
        }

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ErrMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP, 							// �G���[���x��
                AssemblyId,						// �A�Z���u���h�c�܂��̓N���X�h�c
                AssemblyName,						// �v���O��������
                MethodBase.GetCurrentMethod().Name, // ��������
                string.Empty,						// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                string.Empty, 						// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        /// <summary>
        /// �C���t�H���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �C���t�H���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void InfoMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(this,											// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,					// �G���[���x��
                          AssemblyId,									// �A�Z���u���h�c
                          message, 										// �\�����郁�b�Z�[�W
                          status,										// �X�e�[�^�X�l
                          MessageBoxButtons.OK);						// �\������{�^��
        }

        /// <summary>
        /// �m�F�i�͂��A�������j�_�C�A���O�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �m�F�i�͂��A�������j�_�C�A���O�̕\�����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: �m��, OK�ȊO: �L�����Z��]</returns>
        private DialogResult QuestionYesNoProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }

        /// <summary>
        /// �m�F�i�͂��A�������A�L�����Z���j�_�C�A���O�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �m�F�i�͂��A�������A�L�����Z���j�_�C�A���O�̕\�����s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: �m��, No:�m��Ȃ� , Cancel: �L�����Z��]</returns>
        private DialogResult QuestionYesNoCancelProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }
        #endregion

        #region ��\����ԍ\�z�ƕۑ�����
        /// <summary>
        /// ��\����ԃN���X���X�g�\�z����
        /// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃J�����R���N�V���������ɁA��\����ԃN���X���X�g���\�z���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // �t�H���g�T�C�Y���i�[
            ColDisplayStatus fontStatus = new ColDisplayStatus();
            fontStatus.Key = this.FontSize_tComboEditor.Name;
            fontStatus.VisiblePosition = -1;
            fontStatus.Width = (int)this.FontSize_tComboEditor.Value;
            colDisplayStatusList.Add(fontStatus);

            // �O���b�h�����\����ԃN���X���X�g���\�z
            // �O���[�v���̊e�J����
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

        /// <summary>
        /// �I���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���O�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.SearchHis_Grid.DisplayLayout.Bands[0].Columns);
            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            this.Serialize(colDisplayStatusList, FileNameColDisplayStatus);
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�V���A���C�Y����
        /// </summary>
        /// <param name="colDisplayStatusList">��\����ԃN���X���X�g</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̃V���A���C�Y�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : ��\����ԃN���X���X�g�̃f�V���A���C�Y�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region ���t���l�擾����
        /// <summary>
        /// ���t���l�擾����
        /// </summary>
        /// <param name="date">DateTime�^���t</param>
        /// <returns>���l���t(YYYYMMDD)</returns>
        /// <remarks
        /// <br>Note       : ���t���l�擾�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }
        #endregion

        #endregion
    }
}
