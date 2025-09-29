//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\�� 
// �v���O�����T�v   : ���M���O�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhaimm
// �� �� ��  2013/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���M���O�\��UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���M���O�\��UI�t�H�[���N���X</br>
    /// <br>Programmer  : zhaimm</br>
    /// <br>Date        : 2013/06/26</br>
    /// </remarks>
    public partial class PMSAE04001UA : Form
    {
        #region �� Private Members ��
        // ���M���O�f�[�^�e�[�u��
        private SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable _sAndESalSndLogListResultDataTable;
        // ���M���O�A�N�Z�X�N���X
        private SAndESalSndLogListResultAcs _sAndESalSndLogListResultAcs;
        /// <summary>SFKTN09002A)���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        //���t�擾���i
        private DateGetAcs _dateGet;
        /// <summary>��\����ԃR���N�V�����N���X</summary>
        private SAndESalSndLogListResultColDisplayStatusCollection _colDisplayStatusCollection = null;
        private ControlScreenSkin _controlScreenSkin;
        // �G���[����
        private Control _errCtrol = null;
        // �I��
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        // ����			
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        // ���O������			
        private const string TOOLBAR_LOGRESETBUTTON_KEY = "ButtonTool_LogReset";
        // �N���A			
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        // ���O�C���S���҃^�C�g��
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";
        // ���O�C���S���Җ���			
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     
        // �A�Z���u��ID
        private const string CT_PGID = "PMSAE04001U";
        // ��\����ԃZ�b�e�B���O�t�@�C����
        private const string CT_FILENAME_COLDISPLAYSTATUS = "PMSAE04001U_ColSetting.DAT";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���M��(�J�n)�̓��͂��s���ł��B�v</summary>
        private const string MSG_ST_SENDDATETIME_ERROR = "���M��(�J�n)�̓��͂��s���ł��B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���M��(�I��)�̓��͂��s���ł��B�v</summary>
        private const string MSG_ED_SENDDATETIME_ERROR = "���M��(�I��)�̓��͂��s���ł��B";
        /// <summary>�`�F�b�N�����b�Z�[�W�u���M���͈̔͂����s���ł��v</summary>
        private const string MSG_REVERSE_SENDDATETIME_ERROR = "���M���̓��͔͈͂��s���ł��B";
        private const string CT_SANDEAUTOSENDDIV0AND1 = "�S��";
        private const string CT_SANDEAUTOSENDDIV0 = "�蓮";
        private const string CT_SANDEAUTOSENDDIV1 = "����";
        private const int CT_MAXSEARCHCT = 5000; //���o�ő匏���ݒ�(�u0�v�͐������Ȃ�)
        #region < �O���b�h��p >
        /// <summary>����f�[�^���M���O�e�[�u��</summary>
        private const string CT_TBL_TITLE = "SAndESalSndLogListResult";
        /// <summary>���_�R�[�h</summary>
        public const string CT_SECTIONCODE = "SectionCode";
        /// <summary>���_����</summary>
        public const string CT_SECTIONNAME = "SectionName";
        /// <summary>�������M�敪�R�[�h</summary>
        public const string CT_SANDEAUTOSENDDIV = "SAndEAutoSendDiv";
        /// <summary>�������M�敪����</summary>
        public const string CT_SANDEAUTOSENDDIVNAME = "SAndEAutoSendDivName";
        /// <summary>���M�����i�J�n�j</summary>
        public const string CT_SENDDATETIMESTART = "SendDateTimeStart";
        /// <summary>���M�����i�I���j</summary>
        public const string CT_SENDDATETIMEEND = "SendDateTimeEnd";
        /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
        public const string CT_SENDOBJDATESTART = "SendObjDateStart";
        /// <summary>���M�Ώۓ��t�i�I���j</summary>
        public const string CT_SENDOBJDATEEND = "SendObjDateEnd";
        /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
        public const string CT_SENDOBJCUSTSTART = "SendObjCustStart";
        /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
        public const string CT_SENDOBJCUSTEND = "SendObjCustEnd";
        /// <summary>���M�Ώۋ敪</summary>
        public const string CT_SENDOBJDIV = "SendObjDiv";
        /// <summary>���M�Ώۋ敪����</summary>
        public const string CT_SENDOBJDIVNAME = "SendObjDivName";
        /// <summary>���M���ʃR�[�h</summary>
        public const string CT_SENDRESULTS = "SendResults";
        /// <summary>���M���ʖ���</summary>
        public const string CT_SENDRESULTSNAME = "SendResultsName";
        /// <summary>���M�`�[����</summary>
        public const string CT_SendSlipCount = "SendSlipCount";
        /// <summary>���M�`�[���א�</summary>
        public const string CT_SendSlipDtlCnt = "SendSlipDtlCnt";
        /// <summary>���M�`�[���v���z</summary>
        public const string CT_SendSlipTotalMny = "SendSlipTotalMny";
        /// <summary>���M�G���[���e</summary>
        public const string CT_SendErrorContents = "SendErrorContents";
        #endregion
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���_�R�[�h
        private string _sectionCode;
        // ���_����
        private string _sectionName;
        // �O�񋒓_�R�[�h
        private string _prevSectionCode;
        // ���_�R�[�h�G���[�t���O
        private bool _sectionCodeErrorFlg;
        #endregion �� Private Members ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���O�\���̓��̓t�H�[���N���X�ł��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public PMSAE04001UA()
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

            // �A�N�Z�X�N���X��������
            this._sAndESalSndLogListResultAcs = SAndESalSndLogListResultAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._sAndESalSndLogListResultDataTable = this._sAndESalSndLogListResultAcs.SAndESalSndLogListResultDataTable;
            this._dateGet = DateGetAcs.GetInstance(); // ���t�擾���i

            // �ϐ�������
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // ���O�C�����_�����擾
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
            {
                this._sectionName = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                this._sectionName = string.Empty;
            }

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
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void PMSAE04001UA_Load(object sender, EventArgs e)
        {
            // �A�C�R���ݒ�
            SetIcon();

            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(-1, CT_SANDEAUTOSENDDIV0AND1));
            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(0, CT_SANDEAUTOSENDDIV0));
            this.SAndEAutoSendDiv_tComboEditor.Items.Add(new Infragistics.Win.ValueListItem(1, CT_SANDEAUTOSENDDIV1));

            this.ScreenClear();

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput(); 

            this.ultraGrid_SAndESalSndLogListResult.DataSource = this._sAndESalSndLogListResultDataTable;

            // �O���b�h����͉ېݒ�
            SetGrid();

            //-------------------------------------------------------------
            // �O��\�����ݒ�
            //-------------------------------------------------------------
            // ��\����ԃN���X���X�gXML�t�@�C�����f�V���A���C�Y
            List<ColDisplayStatus> colDisplayStatusList = SAndESalSndLogListResultColDisplayStatusCollection.Deserialize(CT_FILENAME_COLDISPLAYSTATUS);

            // ��\����ԃR���N�V�����N���X���C���X�^���X��
            this._colDisplayStatusCollection = new SAndESalSndLogListResultColDisplayStatusCollection(colDisplayStatusList);

            ColumnsCollection columns = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns;

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
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    this.Close();
                    break;
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    if (this.CheckBeforeSearch(ref this._errCtrol) == 0)
                    {
                        this.Search(ref this._errCtrol);
                    }

                    if (this._errCtrol != null)
                    {
                        this._errCtrol.Focus();
                        this._errCtrol = null;
                    }
                    break;
                // ���O������
                case TOOLBAR_LOGRESETBUTTON_KEY:
                    // �m�F���b�Z�[�W
                    if (DialogResult.Yes ==
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, CT_PGID,
                                      "���O�f�[�^�����������܂����H",
                                      0,
                                      MessageBoxButtons.YesNo))
                    {
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        string errMessage = string.Empty;
                        SFCMN00299CA processingDialog = new SFCMN00299CA();

                        try
                        {
                            processingDialog.Title = "��������";
                            processingDialog.Message = "S&&E����f�[�^���M���O�̏��������ł��B";
                            processingDialog.DispCancelButton = false;
                            processingDialog.Show((Form)this.Parent);
                            status = this._sAndESalSndLogListResultAcs.ResetSAndESalSndLog(out errMessage, this._enterpriseCode);
                        }
                        finally
                        {
                            processingDialog.Dispose();
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.ultraGrid_SAndESalSndLogListResult.Refresh();
                            this.ScreenClear();
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                CT_PGID,
                                "���O�f�[�^������܂���B",
                                0,
                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                CT_PGID,
                                "�����������ŃG���[���������܂����B",
                                0,
                                MessageBoxButtons.OK);
                        }
                    }
                    break;
                // �N���A
                case TOOLBAR_CLEARBUTTON_KEY:
                    this.ScreenClear();
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
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // ���_�R�[�h
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                this._sectionCodeErrorFlg = false;
                // ���͒l���擾
                string inputValue = this.tEdit_SectionCodeAllowZero.Text;
                string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
                bool validFlg = false;
                if (_prevSectionCode == sectionCode)
                {
                    this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                    validFlg = true;
                }
                else
                {
                    // 00:�S��
                    if (sectionCode == "00")
                    {
                        this.tEdit_SectionCodeAllowZero.Text = "00";
                        this.SectionName_uLabel.Text = "�S��";
                        _prevSectionCode = "00";
                        validFlg = true;
                    }
                    else if (!String.IsNullOrEmpty(sectionCode.Trim()))
                    {
                        // ���_�����擾
                        SecInfoSet sectionInfo;
                        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                        // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0');
                            this.SectionName_uLabel.Text = sectionInfo.SectionGuideNm.TrimEnd();
                            _prevSectionCode = sectionInfo.SectionCode.TrimEnd().PadLeft(2, '0');
                            validFlg = true;
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Text = uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", _prevSectionCode);
                            validFlg = false;
                        }
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero.Text = string.Empty;
                        this.SectionName_uLabel.Text = string.Empty;
                        _prevSectionCode = string.Empty;
                        validFlg = true;
                    }
                }

                if (validFlg)
                {
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Left:
                            case Keys.Up:
                                {
                                    e.NextCtrl = null;
                                }
                                break;
                            case Keys.Tab:
                            case Keys.Return:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.SectionGuide_uButton;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.SAndEAutoSendDiv_tComboEditor;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (e.Key)
                        {
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    // �G���[��
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        CT_PGID,
                        "�}�X�^�ɑ��݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_SectionCodeAllowZero.SelectAll();
                    e.NextCtrl = e.PrevCtrl;
                    this._sectionCodeErrorFlg = true;
                }
            }

            #region ���t�H�[�J�X�ݒ菈��
            // ������
            if (e.PrevCtrl == SendDateTimeStart_tDateEdit)
            {
                if (e.Key == Keys.Down)
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                    }
                    else
                    {
                        e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
                    }
                }
            }
            if (e.PrevCtrl == SendDateTimeEnd_tDateEdit)
            {
                if (e.Key == Keys.Right)
                {
                    e.NextCtrl = null;
                }
                else if (e.Key == Keys.Down)
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count == 0)
                    {
                        e.NextCtrl = null;
                    }
                    else
                    {
                        e.NextCtrl = this.ultraGrid_SAndESalSndLogListResult;
                    }
                }
            }

            // �O���b�h
            if (e.PrevCtrl == this.ultraGrid_SAndESalSndLogListResult)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                        {
                            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;
                                if (rowIndex != this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1)
                                {
                                    e.NextCtrl = null;
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Activate();
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Activate();
                                this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;
                                if (rowIndex != 0)
                                {
                                    e.NextCtrl = null;
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Activate();
                                    this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.SendDateTimeEnd_tDateEdit;
                                }
                            }
                        }
                        return;
                    }
                }
            }

            // �O���b�h
            if (e.NextCtrl == this.ultraGrid_SAndESalSndLogListResult)
            {
                if (this.ultraGrid_SAndESalSndLogListResult.Rows.Count != 0)
                {
                    if (e.ShiftKey == false)
                    {
                        this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                        this.ultraGrid_SAndESalSndLogListResult.Rows[0].Selected = true;
                        return;
                    }
                    else
                    {
                        this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Activate();
                        this.ultraGrid_SAndESalSndLogListResult.Rows[this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1].Selected = true;
                    }
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    }
                    else
                    {
                        e.NextCtrl = this.SendDateTimeEnd_tDateEdit;
                    }
                }
            }
            #endregion ���t�H�[�J�X�ݒ菈��
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����������ɔ������܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void PMSAE04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �I���O����
            this.BeforeClosing();
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �O���b�h���L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraGrid_SAndESalSndLogListResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ultraGrid_SAndESalSndLogListResult.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.SendDateTimeStart_tDateEdit.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Activate();
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.ultraGrid_SAndESalSndLogListResult.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Activate();
                            this.ultraGrid_SAndESalSndLogListResult.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;
                        // �O���b�h�\�����E�ɃX�N���[��
                        this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;
                        if (this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // �O���b�h�\�������ɃX�N���[��
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;

                        // ���L�[�Ƃ̑g���������̏ꍇ
                        if (e.Modifiers == Keys.None)
                        {
                            // �O���b�h�\�������擪�ɃX�N���[��
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Control�L�[�Ƃ̑g�����̏ꍇ
                        if (e.Modifiers == Keys.Control)
                        {
                            // �擪�s�Ɉړ�
                            this.ultraGrid_SAndESalSndLogListResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                        e.Handled = true;

                        // ���L�[�Ƃ̑g���������̏ꍇ
                        if (e.Modifiers == Keys.None)
                        {
                            // �O���b�h�\�������擪�ɃX�N���[��
                            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Position = this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Control�L�[�Ƃ̑g�����̏ꍇ
                        if (e.Modifiers == Keys.Control)
                        {
                            // �ŏI�s�Ɉړ�
                            this.ultraGrid_SAndESalSndLogListResult.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }
        #endregion �� �C�x���g ��

        #region �� Private method ��
        /// <summary>
        /// search
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���M���O�\�����s���B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void Search(ref Control errCtrl)
        {
            // ���������I�u�W�F�N�g
            SAndESalSndLogListCndtnWork sAndESalSndLogListCndtnWork = new SAndESalSndLogListCndtnWork();
            sAndESalSndLogListCndtnWork.EnterpriseCode = _enterpriseCode;
            string inputSecCode = this.tEdit_SectionCodeAllowZero.Text;
            if ((!string.IsNullOrEmpty(inputSecCode)) && (!string.IsNullOrEmpty(inputSecCode.Trim())) && (inputSecCode.TrimEnd().PadLeft(2, '0') != "00"))
            {
                sAndESalSndLogListCndtnWork.SectionCodes = new string[] { this.tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0') };
            }
            else
            {
                sAndESalSndLogListCndtnWork.SectionCodes = null;
            }
            if (this.SAndEAutoSendDiv_tComboEditor.SelectedIndex >= 0)
            {
                sAndESalSndLogListCndtnWork.SAndEAutoSendDiv = int.Parse(this.SAndEAutoSendDiv_tComboEditor.SelectedItem.DataValue.ToString());
            }
            long stSendDateTimeLong = this.SendDateTimeStart_tDateEdit.GetLongDate();
            long edSendDateTimeLong = this.SendDateTimeEnd_tDateEdit.GetLongDate();
            if (stSendDateTimeLong != 0)
            {
                sAndESalSndLogListCndtnWork.SendDateTimeStart = stSendDateTimeLong * 1000000;
            }
            else
            {
                sAndESalSndLogListCndtnWork.SendDateTimeStart = 0;
            }
            if (edSendDateTimeLong != 0)
            {
                sAndESalSndLogListCndtnWork.SendDateTimeEnd = edSendDateTimeLong * 1000000 + 235959;
            }
            else
            {
                sAndESalSndLogListCndtnWork.SendDateTimeEnd = 0;
            }

            sAndESalSndLogListCndtnWork.MaxSearchCt = CT_MAXSEARCHCT; //���o�ő匏���ݒ�(�u0�v�͐������Ȃ�)
            sAndESalSndLogListCndtnWork.SearchOverFlg = false; // ���o�������߃t���O

            object objPara = sAndESalSndLogListCndtnWork as object;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SFCMN00299CA processingDialog = new SFCMN00299CA();

            try
            {
                processingDialog.Title = "���o����";

                processingDialog.Message = "S&&E����f�[�^���M���O�̒��o���ł��B";

                processingDialog.DispCancelButton = false;

                processingDialog.Show((Form)this.Parent);

                status = this._sAndESalSndLogListResultAcs.SearchSAndESalSndLog(ref objPara, ConstantManagement.LogicalMode.GetData0);
            }
            finally
            {
                processingDialog.Dispose();
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ultraGrid_SAndESalSndLogListResult.Refresh();
                if (((SAndESalSndLogListCndtnWork)objPara).SearchOverFlg)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        CT_PGID,
                        string.Format("�f�[�^������{0}���𒴂��܂����B", ((SAndESalSndLogListCndtnWork)objPara).MaxSearchCt),
                        0,
                        MessageBoxButtons.OK);
                }
                this.ultraGrid_SAndESalSndLogListResult.Focus();
                this.ultraGrid_SAndESalSndLogListResult.Rows[0].Activate();
                this.ultraGrid_SAndESalSndLogListResult.ActiveRow.Selected = true;
                this.ultraGrid_SAndESalSndLogListResult.PerformAction(UltraGridAction.FirstRowInGrid);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    CT_PGID,
                    "���O�f�[�^������܂���B",
                    0,
                    MessageBoxButtons.OK);
                errCtrl = this.tEdit_SectionCodeAllowZero;
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
                errCtrl = this.tEdit_SectionCodeAllowZero;
            }
        }

        /// <summary>
        /// CheckBeforeSearch
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͉�ʃ`�F�b�N���s���B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private int CheckBeforeSearch(ref Control errCtrl)
        {
            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.None, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
            this.tArrowKeyControl1_ChangeFocus(this, eArgs);
            if (this._sectionCodeErrorFlg)
            {
                this._sectionCodeErrorFlg = false;
                return -1;;
            }

            // ���͓��t�i�J�n�`�I���j
            DateGetAcs.CheckDateRangeResult cdrResult;
            string errMessage = null;

            if (CallCheckDateRange(out cdrResult, ref this.SendDateTimeStart_tDateEdit, ref this.SendDateTimeEnd_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("{0}", MSG_ST_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeStart_tDateEdit;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("{0}", MSG_ED_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeEnd_tDateEdit;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("{0}", MSG_REVERSE_SENDDATETIME_ERROR);
                            errCtrl = this.SendDateTimeStart_tDateEdit;
                            break;
                        }
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

            return 0;
        }

        /// <summary>
        /// �A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
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
            // ����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // ���O������			
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGRESETBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // �N���A
            this.tToolsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // ���O�C���S����
            this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �S���ҕ\��
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            this.SectionGuide_uButton.ImageList = IconResourceManagement.ImageList16;
            this.SectionGuide_uButton.Appearance.Image = Size16_Index.STAR1;
        }

        /// <summary>
        /// �O���b�h����͉ېݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���b�h����͉ۂ�ݒ肵�܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>Update Note : 2013/06/26 zhaimm</br>
        /// </remarks>
        private void SetGrid()
        {
            // ����͉ۂƋl�ߕ��ݒ�
            /// <summary>���_�R�[�h</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONCODE].Hidden = true;
            /// <summary>���_����</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SECTIONNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>�������M�敪�R�[�h</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIV].Hidden = true;
            /// <summary>�������M�敪����</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIVNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SANDEAUTOSENDDIVNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�����i�J�n�j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMESTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMESTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�����i�I���j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMEEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDDATETIMEEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATESTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATESTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�Ώۓ��t�i�I���j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATEEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDATEEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTSTART].Format = "#########";
            /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJCUSTEND].Format = "#########";
            /// <summary>���M�Ώۋ敪�R�[�h</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIV].Hidden = true;
            /// <summary>���M�Ώۋ敪����</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIVNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDOBJDIVNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M���ʃR�[�h</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTS].Hidden = true;
            /// <summary>���M���ʖ���</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTSNAME].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SENDRESULTSNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
            /// <summary>���M�`�[����</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipCount].Format = "###,###";
            /// <summary>���M�`�[���א�</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipDtlCnt].Format = "###,###";
            /// <summary>���M�`�[���v���z</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendSlipTotalMny].Format = "###,###,###,###";
            /// <summary>���M�G���[���e</summary>
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendErrorContents].CellActivation = Activation.NoEdit;
            this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns[CT_SendErrorContents].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Default;
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ScreenClear()
        {
            // ��ʃN���A
            this.tEdit_SectionCodeAllowZero.Text = this._sectionCode.TrimEnd().PadLeft(2, '0');
            _prevSectionCode = this._sectionCode.TrimEnd().PadLeft(2, '0');
            this.SectionName_uLabel.Text = this._sectionName;
            this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 0;
            this.SendDateTimeStart_tDateEdit.Clear();
            this.SendDateTimeEnd_tDateEdit.SetDateTime(DateTime.Now);
            this._sAndESalSndLogListResultDataTable.Rows.Clear();

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <remarks>
        /// <br>Note        : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonthDay, 1, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, true);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// �I���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���O�������s���B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // �\����Ԃ�ۑ�����
            this.uiMemInput1.WriteMemInput();

            // ��\����ԃN���X���X�g�\�z����
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.ultraGrid_SAndESalSndLogListResult.DisplayLayout.Bands[CT_TBL_TITLE].Columns);
            this._colDisplayStatusCollection.SetColDisplayStatusList(colDisplayStatusList);

            // ��\����ԃN���X���X�g��XML�ɃV���A���C�Y����
            SAndESalSndLogListResultColDisplayStatusCollection.Serialize(this._colDisplayStatusCollection.GetColDisplayStatusList(), CT_FILENAME_COLDISPLAYSTATUS);
        }

        /// <summary>
        /// �I���O����CALL
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I���O����CALL���s���B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
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
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        public void SetInitFocus()
        {
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// ��\����ԃN���X���X�g�\�z����
        /// </summary>
        /// <param name="columns">�O���b�h�̃J�����R���N�V����</param>
        /// <returns>��\����ԃN���X���X�g</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃J�����R���N�V���������ɁA��\����ԃN���X���X�g���\�z���܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
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

        /// <summary>
        /// ���_�K�C�h�u�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionGuide_uButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.SectionName_uLabel.Text = sectionInfo.SectionGuideNm.Trim();
                _prevSectionCode = sectionInfo.SectionCode.Trim();
                // ���t�H�[�J�X
                this.SAndEAutoSendDiv_tComboEditor.Focus();
            }
        }

        /// <summary>
        /// ���_�R�[�hEnter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionCode_tEdit_Enter(object sender, EventArgs e)
        {
            // �[���l�߉���
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text.TrimEnd());
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g
        /// </summary>
        /// <param name="targetControls">�ΏۃR���|�[�l���g</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g���s��</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            if ((customizeData != null) && (customizeData.Length == 1))
            {
                // �������M�敪
                if (customizeData[0] == "-1")
                {
                    // �S��
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 0;
                }
                else if (customizeData[0] == "0")
                {
                    // �蓮
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 1;
                }
                else if (customizeData[0] == "1")
                {
                    // ����
                    this.SAndEAutoSendDiv_tComboEditor.SelectedIndex = 2;
                }
            }
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g
        /// </summary>
        /// <param name="targetControls">�ΏۃR���|�[�l���g</param>
        /// <param name="customizeData">customizeData</param>
        /// <remarks>
        /// <br>Note	�@ : UI�ۑ��R���|�[�l���g�����݃C�x���g���s��</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[1];
            // �������M�敪
            customizeData[0] = this.SAndEAutoSendDiv_tComboEditor.SelectedItem.DataValue.ToString(); 
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �O���b�h�𗣂��Ɣ������܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraGrid_SAndESalSndLogListResult_Leave(object sender, EventArgs e)
        {
            this.ultraGrid_SAndESalSndLogListResult.ActiveCell = null;
            this.ultraGrid_SAndESalSndLogListResult.ActiveRow = null;

            for (int index = 0; index < this.ultraGrid_SAndESalSndLogListResult.Rows.Count; index++)
            {
                this.ultraGrid_SAndESalSndLogListResult.Rows[index].Selected = false;
            }
        }

        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �R���g���[�����W�J�܂��͏k��������ɔ������܂��B</br>
        /// <br>Programmer	: zhaimm</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private void ultraExpandableGroupBox_Condition_ExpandedStateChanged(object sender, EventArgs e)
        {
            this.ultraExpandableGroupBox_Condition.TabStop = !this.ultraExpandableGroupBox_Condition.Expanded;
        }
        #endregion �� Private method ��
    }
}