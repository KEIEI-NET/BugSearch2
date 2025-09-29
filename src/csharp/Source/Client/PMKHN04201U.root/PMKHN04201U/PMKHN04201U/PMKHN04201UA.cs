//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ� 
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : Redmine#17394
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/24  �C�����e : Redmine#17451,#17511,#17517,#17522
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/25  �C�����e : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/11/19

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Е��i���������Ɖ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���Е��i���������Ɖ�UI�t�H�[���N���X</br>
    /// <br>Programmer  : �� ��</br>
    /// <br>Date        : 2010/11/11</br>
    /// </remarks>
    public partial class PMKHN04201UA : Form
    {
        #region �� Private Members ��
        // SCM�⍇�����O�f�[�^�e�[�u��
        private ScmInqLogInquiryDataSet.ScmInqLogInquiryDataTable _scmInqLogDataTable;
        // SCM�⍇�����O�A�N�Z�X�N���X
        private ScmInqLogAcs _scmInqLogAcs;
        //���t�擾���i
        private DateGetAcs _dateGet;
        /// <summary>��\����ԃR���N�V�����N���X</summary>
        private ScmInqLogColDisplayStatusCollection _colDisplayStatusCollection = null;
        private ControlScreenSkin _controlScreenSkin;
        private DateTime _preDateTimeStart;
        private DateTime _preDateTimeEnd;
        private int _preYear; // ADD 2010/11/19
        private int _preMonth; // ADD 2010/11/19
        private int _preDay; // ADD 2010/11/19
        // �G���[����
        private Control _errCtrol = null;

        // �I��
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // �N���A			
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // ����			
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        // ���O�C���S���҃^�C�g��
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";
        // ���O�C���S���Җ���			
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     
        // �A�Z���u��ID
        private const string CT_PGID = "PMKHN04201U";
        // ��\����ԃZ�b�e�B���O�t�@�C����
        private const string CT_FILENAME_COLDISPLAYSTATUS = "PMKHN04201U_ColSetting.DAT";
        //�G���[�������b�Z�[�W
        private const string ct_InputError = "�̓��͂��s���ł�";
        private const string ct_NoInput = "����͂��ĉ�����";
        #region < �O���b�h��p >
        /// <summary>SCM�⍇�����O�e�[�u��</summary>
        private const string CT_TBL_TITLE = "ScmInqLogInquiry";

        /// <summary>RowNo</summary>
        public const string CT_RowNo = "RowNo";
        // ---UPD 2010/11/19 -------------------------->>>
        ///// <summary>�쐬����</summary>
        //public const string CT_CreateDateTime = "CreateDateTime";
        /// <summary>�쐬���t</summary>
        public const string CT_CreateDate = "CreateDate";
        /// <summary>�쐬����</summary>
        public const string CT_CreateTime = "CreateTime";
        // ---UPD 2010/11/19 --------------------------<<<
        /// <summary>�A������Ɩ���</summary>
        public const string CT_CnectOriginalEpNm = "CnectOriginalEpNm";
        /// <summary>���̓V�X�e��</summary>
        public const string CT_UseSystem = "UseSystem";
        /// <summary>�⍇�����e</summary>
        public const string CT_ScmInqContents = "ScmInqContents";
        #endregion
        // ��ƃR�[�h
        private string _enterpriseCode;
        #endregion �� Private Members ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Е��i���������Ɖ�̓��̓t�H�[���N���X�ł��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public PMKHN04201UA()
        {
            InitializeComponent();

            //---------------------------------
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            //---------------------------------
            this._controlScreenSkin = new ControlScreenSkin();
            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.ultraExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �ϐ�������
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._scmInqLogAcs = ScmInqLogAcs.GetInstance();
            this._scmInqLogDataTable = this._scmInqLogAcs.ScmInqLogDataTable;
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();

        }
        # endregion �� �R���X�g���N�^ ��

        #region �� �C�x���g ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void PMKHN04201UA_Load(object sender, EventArgs e)
        {
            // �A�C�R���ݒ�
            SetIcon();

            this.tDateEdit_Start.SetDateTime(DateTime.Now);
            // ---UPD 2010/11/19 -------------------------->>>
            //this.tDateEdit_End.SetDateTime(DateTime.Now);
            this.StartHour_tNedit.Text = "00";
            this.StartMinute_tNedit.Text = "00";
            this.StartSecond_tNedit.Text = "00";
            this.EndHour_tNedit.Text = "23";
            this.EndMinute_tNedit.Text = "59";
            this.EndSecond_tNedit.Text = "59";
            // ---UPD 2010/11/19 --------------------------<<<
            //this.tDateEdit_Start.Focus(); // DEL 2010/11/19
            this.ultraGrid_ScmInqLog.DataSource = this._scmInqLogDataTable;

            // �O���b�h����͉ېݒ�
            SetGrid();

            //-------------------------------------------------------------
            // �O��\�����ݒ�
            //-------------------------------------------------------------
            // ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
            List<ColDisplayStatus> colDisplayStatusList = ScmInqLogColDisplayStatusCollection.Deserialize(CT_FILENAME_COLDISPLAYSTATUS);

            // ��\����ԃR���N�V�����N���X���C���X�^���X��
            this._colDisplayStatusCollection = new ScmInqLogColDisplayStatusCollection(colDisplayStatusList);

            ColumnsCollection columns = this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns;

            foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusCollection.GetColDisplayStatusList())
            {
                if (columns.Exists(colDisplayStatus.Key) == true)
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �c�[���o�[��̃c�[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    this.Close();
                    break;
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    this.ScreenClear();
                    break;
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    // ---UPD 2010/11/19 -------------------------->>>
                    //if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                    //{
                    //    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    //    {
                    //        this.Search(ref this._errCtrol);
                    //    }
                    //}
                    //else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                    //{
                    //    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                    //    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                    //}

                    //if (this._errCtrol != null)
                    //{
                    //    this._errCtrol.Focus();
                    //    this._errCtrol = null;
                    //}

                    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    {
                        // ---DEL 2010/11/24 -------------------------->>>
                        //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text));
                        //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text));
                        //if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                        //{
                        //    this.Search(ref this._errCtrol);
                        //}
                        //else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                        //{
                        //    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                        //    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                        //}
                        // ---DEL 2010/11/24 --------------------------<<<
                        this.Search(ref this._errCtrol); // ADD 2010/11/24
                    }

                    if (this._errCtrol != null)
                    {
                        this._errCtrol.Focus();
                        this._errCtrol = null;
                    }
                    // ---UPD 2010/11/19 --------------------------<<<
                    break;

            }
        }

        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ChangeFocus���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ---UPD 2010/11/19 -------------------------->>>
            //// �������i�I���j
            //if (e.PrevCtrl == this.tDateEdit_End)
            //{
            //    if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
            //    {
            //        if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
            //        {
            //            // ����
            //            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
            //            {
            //                this.Search(ref this._errCtrol);
            //            }

            //            if (this._errCtrol != null)
            //            {
            //                this._errCtrol.Focus();
            //                this._errCtrol = null;
            //                e.NextCtrl = null;
            //            }
            //        }
            //        else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
            //        {
            //            this.ultraGrid_ScmInqLog.Rows[0].Activate();
            //            this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
            //        }
            //    }
            //}
            //// �������i�J�n�j
            //else if (e.PrevCtrl == this.tDateEdit_Start)
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if ((this._preDateTimeStart != null && this._preDateTimeStart != this.tDateEdit_Start.GetDateTime().Date) || (this._preDateTimeEnd != null && this._preDateTimeEnd != this.tDateEdit_End.GetDateTime().Date) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
            //        {
            //            // ����
            //            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
            //            {
            //                this.Search(ref this._errCtrol);
            //            }

            //            if (this._errCtrol != null)
            //            {
            //                this._errCtrol.Focus();
            //                this._errCtrol = null;
            //                e.NextCtrl = null;
            //            }
            //        }
            //        else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
            //        {
            //            this.ultraGrid_ScmInqLog.Rows[0].Activate();
            //            this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
            //        }
            //    }
            //}
            //// �O���b�h
            //else if (e.PrevCtrl == this.ultraGrid_ScmInqLog)
            //{
            //    if (this.ultraGrid_ScmInqLog.ActiveRow != null)
            //    {
            //        if (e.Key == Keys.Up && this.ultraGrid_ScmInqLog.ActiveRow != null)
            //        {
            //            if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0)
            //            {
            //                this.ultraGrid_ScmInqLog.ActiveRow.Selected = false;
            //                this.ultraGrid_ScmInqLog.ActiveRow = null;
            //                this.tDateEdit_Start.Focus();
            //            }
            //        }
            //        else if (e.Key == Keys.Down && this.ultraGrid_ScmInqLog.ActiveRow.Index == this.ultraGrid_ScmInqLog.Rows.Count - 1)
            //        {
            //            e.NextCtrl = null;
            //        }
            //        else if (e.Key == Keys.Return || e.Key == Keys.Tab)
            //        {
            //            e.NextCtrl = null;
            //        }
            //    }
            //}

            #region ����������
            if (e.PrevCtrl != null && !e.ShiftKey)
            {
                switch (e.PrevCtrl.Name)
                {
                    // ���������i�I���b�ȊO�j
                    case "StartHour_tNedit":
                    case "StartMinute_tNedit":
                    case "StartSecond_tNedit":
                    case "EndHour_tNedit":
                    case "EndMinute_tNedit":
                        if (e.Key == Keys.Down)
                        {
                            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                            {
                                //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                                //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                                DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                                DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                                if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                                {
                                    // ����
                                    this.Search(ref this._errCtrol);
                                }
                                else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                                {
                                    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                                    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                                    this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                                }
                            }
                            if (this._errCtrol != null)
                            {
                                this._errCtrol.Focus();
                                this._errCtrol = null;
                                e.NextCtrl = null;
                            }
                        }
                        break;
                    // ���������i�I���b�j
                    case "EndSecond_tNedit":
                        if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Down)
                        {
                            if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                            {
                                //DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                                //DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                                DateTime tmpStartDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                                DateTime tmpEndDt = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                                if ((this._preDateTimeStart != null && this._preDateTimeStart != tmpStartDt) || (this._preDateTimeEnd != null && this._preDateTimeEnd != tmpEndDt) || this.ultraGrid_ScmInqLog.Rows.Count == 0)
                                {
                                    // ����
                                    this.Search(ref this._errCtrol);
                                }
                                else if (this.ultraGrid_ScmInqLog.Rows.Count != 0)
                                {
                                    this.ultraGrid_ScmInqLog.Rows[0].Activate();
                                    this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                                    this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                                }
                            }
                            if (this._errCtrol != null)
                            {
                                this._errCtrol.Focus();
                                this._errCtrol = null;
                                e.NextCtrl = null;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (e.PrevCtrl != null && e.PrevCtrl == this.tDateEdit_Start)
                {
                    e.NextCtrl = null;
                }
            }
            #endregion ����������

            #region ���t�H�[�J�X�ݒ菈��
            if (e.PrevCtrl != null)
            {
                // ������
                if (e.PrevCtrl == this.tDateEdit_Start)
                {
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = null;
                    }
                }
                // �O���b�h
                if (e.PrevCtrl == this.ultraGrid_ScmInqLog)
                {
                    if (this.ultraGrid_ScmInqLog.ActiveRow != null)
                    {
                        if (e.Key == Keys.Up && this.ultraGrid_ScmInqLog.ActiveRow != null)
                        {
                            //if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0) // DEL 2010/11/25
                            if (this.ultraGrid_ScmInqLog.ActiveRow.Index == 0 && this.ultraExpandableGroupBox_Condition.Expanded) // ADD 2010/11/25
                            {
                                this.ultraGrid_ScmInqLog.ActiveRow.Selected = false;
                                this.ultraGrid_ScmInqLog.ActiveRow = null;
                                this.StartHour_tNedit.Focus();
                            }
                        }
                        else if (e.Key == Keys.Down && this.ultraGrid_ScmInqLog.ActiveRow.Index == this.ultraGrid_ScmInqLog.Rows.Count - 1)
                        {
                            e.NextCtrl = null;
                        }
                        else if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            e.NextCtrl = null;
                        }
                    }
                }

                // ---ADD 2010/11/24 -------------------------->>>
                if (e.ShiftKey)
                {
                    if ((e.Key == Keys.Return || e.Key == Keys.Tab) && e.PrevCtrl == this.ultraGrid_ScmInqLog)
                    {
                        this.EndSecond_tNedit.Focus();
                    }
                }
                // ---ADD 2010/11/24 --------------------------<<<
            }
            #endregion ���t�H�[�J�X�ݒ菈��
            // ---UPD 2010/11/19 --------------------------<<<
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����������ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void PMKHN04201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �I���O����
            this.BeforeClosing();
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �O���b�h���L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void ultraGrid_ScmInqLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Up, this.ultraGrid_ScmInqLog, this.tDateEdit_Start);
                this.tArrowKeyControl1_ChangeFocus(this, evt);
            }
            else if (e.KeyCode == Keys.Down)
            {
                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.ultraGrid_ScmInqLog, this.ultraGrid_ScmInqLog);
                this.tArrowKeyControl1_ChangeFocus(this, evt);
            }
            else if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            else if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�������ɃX�N���[��
                this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_ScmInqLog.DisplayLayout.ColScrollRegions[0].Position - 40;
            }
        }

        // ---ADD 2010/11/19 -------------------------->>>
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �{���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void uButton_Today_Click(object sender, EventArgs e)
        {
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            this.tDateEdit_Start.SetDateTime(DateTime.Now);

            if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
            {
                this.StartHour_tNedit.Text = "00";
                this.StartMinute_tNedit.Text = "00";
                this.StartSecond_tNedit.Text = "00";
                this.EndHour_tNedit.Text = "23";
                this.EndMinute_tNedit.Text = "59";
                this.EndSecond_tNedit.Text = "59";
            }
            this.StartHour_tNedit.Focus();
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �O���{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void ultraButton_Yesterday_Click(object sender, EventArgs e)
        {
            // ---UPD 2010/11/24 -------------------------->>>
            //DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            //DateTime tmpDateTime = this.tDateEdit_Start.GetDateTime().AddDays(-1);
            //this.tDateEdit_Start.SetDateTime(tmpDateTime);

            //if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
            //{
            //    this.StartHour_tNedit.Text = "00";
            //    this.StartMinute_tNedit.Text = "00";
            //    this.StartSecond_tNedit.Text = "00";
            //    this.EndHour_tNedit.Text = "23";
            //    this.EndMinute_tNedit.Text = "59";
            //    this.EndSecond_tNedit.Text = "59";
            //}
            //this.StartHour_tNedit.Focus();
            try
            {
                DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
                DateTime tmpDateTime = this.tDateEdit_Start.GetDateTime().AddDays(-1);
                this.tDateEdit_Start.SetDateTime(tmpDateTime);

                if (this._preYear != tmpDt.Year || this._preMonth != tmpDt.Month || this._preDay != tmpDt.Day)
                {
                    this.StartHour_tNedit.Text = "00";
                    this.StartMinute_tNedit.Text = "00";
                    this.StartSecond_tNedit.Text = "00";
                    this.EndHour_tNedit.Text = "23";
                    this.EndMinute_tNedit.Text = "59";
                    this.EndSecond_tNedit.Text = "59";
                }
                this.StartHour_tNedit.Focus();
            }
            catch
            {
                this.tDateEdit_Start.Focus();
            }
            // ---UPD 2010/11/24 --------------------------<<<
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���t���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        private void tDateEdit_Start_ValueChanged(object sender, EventArgs e)
        {
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();

            this._preYear = tmpDt.Year;
            this._preMonth = tmpDt.Month;
            this._preDay = tmpDt.Day;
        }
        // ---ADD 2010/11/19 --------------------------<<<
        #endregion �� �C�x���g ��

        #region �� Private method ��
        /// <summary>
        /// search
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Е��i���������Ɖ���s���B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void Search(ref Control errCtrl)
        {
            // ---UPD 2010/11/19 -------------------------->>>
            //DateTime beginDt = this.tDateEdit_Start.GetDateTime();
            //DateTime endDt = this.tDateEdit_End.GetDateTime();
            //DateTime beginDt2 = new DateTime(beginDt.Year, beginDt.Month, beginDt.Day, 0, 0, 0, 0);
            //DateTime endDt2 = new DateTime(endDt.Year, endDt.Month, endDt.Day, 23, 59, 59, 999);
            //long beginDateTime = beginDt2.Ticks;
            //long endDateTime = endDt2.Ticks;

            // ���������I�u�W�F�N�g
            ScmInqLogInquirySearchPara scmInqLogInquirySearchPara = new ScmInqLogInquirySearchPara();
            
            DateTime tmpDt = this.tDateEdit_Start.GetDateTime();
            //DateTime beginDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text), 0); // DEL 2010/11/25
            //DateTime endDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text), 999); // DEL 2010/11/25
            DateTime beginDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt(), 0); // ADD 2010/11/25
            DateTime endDt = new DateTime(tmpDt.Year, tmpDt.Month, tmpDt.Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt(), 999); // ADD 2010/11/25
            scmInqLogInquirySearchPara.BeginDateTime = beginDt.Ticks;
            scmInqLogInquirySearchPara.EndDateTime = endDt.Ticks;
            scmInqLogInquirySearchPara.CnectOtherEpCd = this._enterpriseCode;
            scmInqLogInquirySearchPara.LogicalDeleteCode = 0;
            //scmInqLogInquirySearchPara.MaxSearchCt = 5000; // DEL 2010/11/24
            scmInqLogInquirySearchPara.MaxSearchCt = 5000 + 1; // ADD 2010/11/24
            object objPara = scmInqLogInquirySearchPara as object;
            // ---UPD 2010/11/19 --------------------------<<<

            //int status = this._scmInqLogAcs.search(scmInqLogInquirySearchPara, 0); // DEL 2010/11/19
            //int status = this._scmInqLogAcs.search(ref objPara, 0); // ADD 2010/11/19
            // ---ADD 2010/11/24 -------------------------->>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SFCMN00299CA processingDialog = new SFCMN00299CA();

            try
            {
                processingDialog.Title = "���o����";

                processingDialog.Message = "���݁A�f�[�^���o���ł��B";

                processingDialog.DispCancelButton = false;

                processingDialog.Show((Form)this.Parent);

                status = this._scmInqLogAcs.search(ref objPara, 0);
            }
            finally
            {
                processingDialog.Dispose();
            }
            // ---ADD 2010/11/24 --------------------------<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraGrid_ScmInqLog.Refresh();
                // ---ADD 2010/11/19 -------------------------->>>
                if (((ScmInqLogInquirySearchPara)objPara).SearchOverFlg)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        CT_PGID,
                        "�f�[�^������5000���𒴂��܂����B",
                        0,
                        MessageBoxButtons.OK);
                }
                // ---ADD 2010/11/19 --------------------------<<<
                this.ultraGrid_ScmInqLog.Focus(); // ADD 2010/11/19
                this.ultraGrid_ScmInqLog.Rows[0].Activate();
                this.ultraGrid_ScmInqLog.ActiveRow.Selected = true;
                this.ultraGrid_ScmInqLog.PerformAction(UltraGridAction.FirstRowInGrid); // ADD 2010/11/25
                //this._preDateTimeStart = this.tDateEdit_Start.GetDateTime().Date; // DEL 2010/11/19
                //this._preDateTimeEnd = this.tDateEdit_End.GetDateTime().Date; // DEL 2010/11/19
                // ---ADD 2010/11/19 -------------------------->>>
                //this._preDateTimeStart = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.StartHour_tNedit.Text), int.Parse(this.StartMinute_tNedit.Text), int.Parse(this.StartSecond_tNedit.Text)); // DEL 2010/11/25
                //this._preDateTimeEnd = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, int.Parse(this.EndHour_tNedit.Text), int.Parse(this.EndMinute_tNedit.Text), int.Parse(this.EndSecond_tNedit.Text)); // DEL 2010/11/25
                this._preDateTimeStart = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.StartHour_tNedit.GetInt(), this.StartMinute_tNedit.GetInt(), this.StartSecond_tNedit.GetInt()); // ADD 2010/11/25
                this._preDateTimeEnd = new DateTime(this.tDateEdit_Start.GetDateTime().Year, this.tDateEdit_Start.GetDateTime().Month, this.tDateEdit_Start.GetDateTime().Day, this.EndHour_tNedit.GetInt(), this.EndMinute_tNedit.GetInt(), this.EndSecond_tNedit.GetInt()); // ADD 2010/11/25
                // ---ADD 2010/11/19 --------------------------<<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    CT_PGID,
                    "���������ɊY������f�[�^�����݂��܂���B",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tDateEdit_Start;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    CT_PGID,
                    "���������ŃG���[���������܂����B",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tDateEdit_Start;
            }
        }

        /// <summary>
        /// CheckBeforeSearch
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͉�ʃ`�F�b�N���s���B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private int CheckBeforeSearch(ref Control errCtrl)
        {
            // ���͓��t�i�J�n�`�I���j
            DateGetAcs.CheckDateRangeResult cdrResult;
            string errMessage = null;
            // ---UPD 2010/11/19 -------------------------->>>
            //if (CallCheckDateRange(out cdrResult, ref this.tDateEdit_Start, ref this.tDateEdit_End) == false)
            //{
            //    switch (cdrResult)
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format("�J�n��{0}", ct_NoInput);
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format("�J�n��{0}", ct_InputError);
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format("�I����{0}", ct_NoInput);
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format("�I����{0}", ct_InputError);
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = "�J�n�����I����������ɂ��邱�Ƃ͂ł��܂���B";
            //                errCtrl = this.tDateEdit_Start;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = "���t�͂P�����͈͓̔��œ��͂��Ă��������B";
            //                errCtrl = this.tDateEdit_End;
            //            }
            //            break;
            //    }
            //}
            //if (this.tDateEdit_Start.LongDate == 0 && this.tDateEdit_End.LongDate == 0)
            //{
            //    errMessage = string.Format("�J�n��{0}", ct_NoInput);
            //    errCtrl = this.tDateEdit_Start;
            //}

            if (CallCheckDateRange(out cdrResult, ref this.tDateEdit_Start, ref this.tDateEdit_Start) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("������{0}", ct_NoInput);
                            errCtrl = this.tDateEdit_Start;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("������{0}", ct_InputError);
                            errCtrl = this.tDateEdit_Start;
                        }
                        break;
                }
                if (errMessage != null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        CT_PGID,
                        errMessage,
                        0,
                        MessageBoxButtons.OK);
                    return -1;
                }
            }
            if (this.tDateEdit_Start.LongDate == 0)
            {
                errMessage = string.Format("������{0}", ct_NoInput);
                errCtrl = this.tDateEdit_Start;
            }
            // ---DEL 2010/11/25 --------------------------------->>>
            //else if (this.StartHour_tNedit.Text == "" || this.StartMinute_tNedit.Text == "" || this.StartSecond_tNedit.Text == "")
            //{
            //    errMessage = string.Format("�J�n����{0}", ct_NoInput);
            //    errCtrl = this.StartHour_tNedit;
            //}
            //else if (this.EndHour_tNedit.Text == "" || this.EndMinute_tNedit.Text == "" || this.EndSecond_tNedit.Text == "")
            //{
            //    errMessage = string.Format("�I������{0}", ct_NoInput);
            //    errCtrl = this.EndHour_tNedit;
            //}
            // ---DEL 2010/11/25 ---------------------------------<<<
            //else if (int.Parse(this.StartHour_tNedit.Text) < 0 || int.Parse(this.StartHour_tNedit.Text) > 23) // DEL 2010/11/25
            else if (this.StartHour_tNedit.GetInt() < 0 || this.StartHour_tNedit.GetInt() > 23) // ADD 2010/11/25
            {
                errMessage = string.Format("�J�n����{0}", ct_InputError);
                errCtrl = this.StartHour_tNedit;
            }
            //else if (int.Parse(this.StartMinute_tNedit.Text) < 0 || int.Parse(this.StartMinute_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.StartMinute_tNedit.GetInt() < 0 || this.StartMinute_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("�J�n����{0}", ct_InputError);
                errCtrl = this.StartMinute_tNedit;
            }
            //else if (int.Parse(this.StartSecond_tNedit.Text) < 0 || int.Parse(this.StartSecond_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.StartSecond_tNedit.GetInt() < 0 || this.StartSecond_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("�J�n����{0}", ct_InputError);
                errCtrl = this.StartSecond_tNedit;
            }
            //else if (int.Parse(this.EndHour_tNedit.Text) < 0 || int.Parse(this.EndHour_tNedit.Text) > 23) // DEL 2010/11/25
            else if (this.EndHour_tNedit.GetInt() < 0 || this.EndHour_tNedit.GetInt() > 23) // ADD 2010/11/25
            {
                errMessage = string.Format("�I������{0}", ct_InputError);
                errCtrl = this.EndHour_tNedit;
            }
            //else if (int.Parse(this.EndMinute_tNedit.Text) < 0 || int.Parse(this.EndMinute_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.EndMinute_tNedit.GetInt() < 0 || this.EndMinute_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("�I������{0}", ct_InputError);
                errCtrl = this.EndMinute_tNedit;
            }
            //else if (int.Parse(this.EndSecond_tNedit.Text) < 0 || int.Parse(this.EndSecond_tNedit.Text) > 59) // DEL 2010/11/25
            else if (this.EndSecond_tNedit.GetInt() < 0 || this.EndSecond_tNedit.GetInt() > 59) // ADD 2010/11/25
            {
                errMessage = string.Format("�I������{0}", ct_InputError);
                errCtrl = this.EndSecond_tNedit;
            }
            //else if (int.Parse(this.StartHour_tNedit.Text) > int.Parse(this.EndHour_tNedit.Text) // DEL 2010/11/25
            //    || int.Parse(this.StartHour_tNedit.Text) == int.Parse(this.EndHour_tNedit.Text) && int.Parse(this.StartMinute_tNedit.Text) > int.Parse(this.EndMinute_tNedit.Text) // DEL 2010/11/25
            //    || int.Parse(this.StartHour_tNedit.Text) == int.Parse(this.EndHour_tNedit.Text) && int.Parse(this.StartMinute_tNedit.Text) == int.Parse(this.EndMinute_tNedit.Text) && int.Parse(this.StartSecond_tNedit.Text) > int.Parse(this.EndSecond_tNedit.Text)) // DEL 2010/11/25
            else if (this.StartHour_tNedit.GetInt() > this.EndHour_tNedit.GetInt() // ADD 2010/11/25
                || this.StartHour_tNedit.GetInt() == this.EndHour_tNedit.GetInt() && this.StartMinute_tNedit.GetInt() > this.EndMinute_tNedit.GetInt() // ADD 2010/11/25
                || this.StartHour_tNedit.GetInt() == this.EndHour_tNedit.GetInt() && this.StartMinute_tNedit.GetInt() == this.EndMinute_tNedit.GetInt() && this.StartSecond_tNedit.GetInt() > this.EndSecond_tNedit.GetInt()) // ADD 2010/11/25
            {
                errMessage = "�J�n�������I������������ɂ��邱�Ƃ͂ł��܂���B";
                errCtrl = this.StartHour_tNedit;
            }
            // ---UPD 2010/11/19 --------------------------<<<

            if (errMessage != null)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    CT_PGID,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// �A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// <br>Update Note : 2010/11/11 �� ��</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;
            // -----------------------------
            // �c�[���o�[�A�C�R���ݒ�
            // -----------------------------
            // �C���[�W���X�g�ݒ�
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            // �I��
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �N���A
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
        }

        /// <summary>
        /// �O���b�h����͉ېݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h����͉ۂ�ݒ肵�܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// <br>Update Note : 2010/11/11 �� ��</br>
        /// </remarks>
        private void SetGrid()
        {
            // ����͉ۂƋl�ߕ��ݒ�
            // RowNo
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_RowNo].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ---UPD 2010/11/19 -------------------------->>>
            //// �쐬����
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].CellActivation = Activation.NoEdit;
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDateTime].Format = "yyyy/MM/dd HH:mm:ss";

            // ���t
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateDate].Format = "yyyy/MM/dd";

            // ����
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].CellActivation = Activation.NoEdit;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CreateTime].Format = "HH:mm:ss";
            // ---UPD 2010/11/19 --------------------------<<<

            // �A������Ɩ���
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_CnectOriginalEpNm].CellActivation = Activation.NoEdit;

            // ���̓V�X�e��
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_UseSystem].CellActivation = Activation.NoEdit;

            // �⍇�����e
            this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_ScmInqContents].CellActivation = Activation.NoEdit;
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void ScreenClear()
        {
            this._scmInqLogDataTable.Rows.Clear();
            this.tDateEdit_Start.SetDateTime(DateTime.Now);
            //this.tDateEdit_End.SetDateTime(DateTime.Now); // DEL 2010/11/19

            // ---ADD 2010/11/19 -------------------------->>>
            this.StartHour_tNedit.DataText = "00";
            this.StartMinute_tNedit.DataText = "00";
            this.StartSecond_tNedit.DataText = "00";
            this.EndHour_tNedit.DataText = "23";
            this.EndMinute_tNedit.DataText = "59";
            this.EndSecond_tNedit.DataText = "59";
            // ---ADD 2010/11/19 --------------------------<<<

            // �t�H�[�J�X�ݒ�
            this.tDateEdit_Start.Focus();
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// �I���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���O�������s���B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.ultraGrid_ScmInqLog.DisplayLayout.Bands[CT_TBL_TITLE].Columns);
            this._colDisplayStatusCollection.SetColDisplayStatusList(colDisplayStatusList);

            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            ScmInqLogColDisplayStatusCollection.Serialize(this._colDisplayStatusCollection.GetColDisplayStatusList(), CT_FILENAME_COLDISPLAYSTATUS);
        }

        /// <summary>
        /// �I���O����CALL
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���O����CALL���s���B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        public void CallBeforeClosing()
        {
            this.BeforeClosing();
        }

        /// <summary>
        /// �����t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����t�H�[�J�X�ݒ���s���B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/19</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tDateEdit_Start.Focus();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�\�z����
        /// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃J�����R���N�V���������ɁA��\����ԃN���X���X�g���\�z���܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/11/11</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

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

        #endregion �� Private method ��
    }
}