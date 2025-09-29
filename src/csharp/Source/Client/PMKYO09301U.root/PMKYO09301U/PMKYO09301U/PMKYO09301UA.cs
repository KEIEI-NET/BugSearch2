//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�̃t�@�C�����X�V����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��  2010/05/21             �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2014/10/02  �C�����e : �c�[���`�F�b�N�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��M�f�[�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public partial class PMKYO09301UA : Form
    {

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// �f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public PMKYO09301UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ���O�C���S����
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._controlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members


        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;             // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;            // �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;             // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;          // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;          // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;			// ���O�C���S���Җ���
        private ServiceFilesInputAcs _serviceFilesInputAcs = ServiceFilesInputAcs.GetInstance();
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private ControlScreenSkin _controlScreenSkin;
        private bool isSaveFlg = true;
        private bool closeFlg = true;
        private int delNum = 0;

        private Dictionary<string, string> _commdt = new Dictionary<string, string>();  // ADD 杍^ 2014/10/02

        // 2010/05/19 >>>
        private const int ctInterval_Minvalue = 5;
        private const string ctPGID_OfferDataUpdate = "PMKHN09210U.EXE";
        // 2010/05/19 <<<
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            this.uButton_Delete.ImageList = this._imageList16;
            this.uButton_Delete.Appearance.Image = (int)Size16_Index.DELETE;
            // ���_����
            this._sectionNameLabel.SharedProps.Caption = this._serviceFilesInputAcs.GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private int Clear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �s�폜�s��ۑ�����
            this.delNum = 0;

            // ��ʃN���A
            this._serviceFilesInputAcs.Conf.Conf.Clear();
            this._serviceFilesInputAcs.CommConf.Conf.Clear();  // ADD 杍^ 2014/10/02

            // ����������
            string msg = "";
            int fileFlg = 0;
            //status = this._serviceFilesInputAcs.Search(ref msg, ref fileFlg);  // DEL 杍^ 2014/10/02
            status = this._serviceFilesInputAcs.SearchAll(ref msg, ref fileFlg); // ADD 杍^ 2014/10/02

            // ���b�Z�[�W���Ăяo��
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���b�Z�[�W���Ăяo��
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   msg,
                   -1,
                   MessageBoxButtons.OK);
            }

            // ��ʃG�f�B�^���f
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (fileFlg == 2)
                {
                    this.SettingGridRow();
                    delNum = this._serviceFilesInputAcs.Conf.Conf.Count;
                }
            }

            // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
            // �󔒍s��ǉ�����
            this._commdt.Clear();

            foreach (conf.ConfRow commRow in this._serviceFilesInputAcs.CommConf.Conf)
            {
                if (!this._commdt.ContainsKey(commRow.PgId.Trim().ToUpper()))
                {
                    this._commdt.Add(commRow.PgId.Trim().ToUpper(), string.Empty);
                }
            }
            // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<

            // �󔒍s��ǉ�����
            conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
            this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);

            return status;
        }

        /// <summary>
        /// ��ʕۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            this._serviceFilesInputAcs.Conf.Conf.AcceptChanges();

            // �t���O
            isSaveFlg = true;

            // �Z���ҏW��ɒ��ڃ{�^���N���b�N���s�Ȃ��ƃZ���̕ҏW���������Ȃ�����
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            if (!isSaveFlg)
            {
                return;
            }

            // �ۑ��O����
            SaveDataAdjust();

            // �ۑ��`�F�b�N
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            // �ۑ�����
            status = this._serviceFilesInputAcs.SaveData();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
                this.Clear();
            }
            else
            {
                // ���b�Z�[�W���Ăяo��
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_STOPDISP,
                   this.Name,
                   "�t�@�C���ւ̏������݂����s���܂��B",
                   -1,
                   MessageBoxButtons.OK);
                // �󔒍s��ǉ�����
                conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
            }

            // ��񒲐�
            this.AfterDataAdjust();
            // �t�H�[�J�X�ݒ�
            this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N
        /// </summary>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            // ���݃t���O
            bool isExistFlg = false;

            int i = 0;
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {       
                // �O���b�h���g����̏ꍇ
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !string.IsNullOrEmpty(row.RunParam)
                    || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                {
                    isExistFlg = true;
                }

                // ���̓`�F�b�N
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                {
                    // �`�F�b�N�J�n����
                    if (string.IsNullOrEmpty(row.ChkStTime))
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // �`�F�b�N�I������
                    if (string.IsNullOrEmpty(row.ChkEdTime))
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[1].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // ���s�v���O������
                    if (string.IsNullOrEmpty(row.PgId))
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[2].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    // �`�F�b�N�Ԋu����
                    if (this.uGrid_Result.Rows[i].Cells[4].Value is DBNull)
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[4].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                    else if (row.ChkInterval == 0)
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[4].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }

                // ���̓`�F�b�N
                if (string.IsNullOrEmpty(row.ChkStTime) && string.IsNullOrEmpty(row.ChkEdTime)
                    && string.IsNullOrEmpty(row.PgId) && this.uGrid_Result.Rows[i].Cells[4].Value is DBNull)
                {
                    if (!string.IsNullOrEmpty(row.RunParam))
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "���͕s���ł��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(row.PgId) && row.PgId.Length > 30)
                {
                    // ��񒲐�
                    this.AfterDataAdjust();
                    // ���b�Z�[�W���Ăяo��
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "���͕s���ł��B",
                       -1,
                       MessageBoxButtons.OK);
                    this.uGrid_Result.Rows[i].Cells[2].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }

                if (!string.IsNullOrEmpty(row.RunParam) && row.RunParam.Length > 1)
                {
                    // ��񒲐�
                    this.AfterDataAdjust();
                    // ���b�Z�[�W���Ăяo��
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "���͕s���ł��B",
                       -1,
                       MessageBoxButtons.OK);
                    this.uGrid_Result.Rows[i].Cells[3].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }

                // �J�n�`�F�b�N�����ƏI���`�F�b�N����
                if (!string.IsNullOrEmpty(row.ChkStTime) && !string.IsNullOrEmpty(row.ChkEdTime))
                {
                    int start = Convert.ToInt32(row.ChkStTime);
                    int end = Convert.ToInt32(row.ChkEdTime);
                    if (start > end)
                    {
                        // ��񒲐�
                        this.AfterDataAdjust();
                        // ���b�Z�[�W���Ăяo��
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�����͈͎̔w��Ɍ�肪����܂��B",
                           -1,
                           MessageBoxButtons.OK);
                        this.uGrid_Result.Rows[i].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }

                    // �`�F�b�N�Ԋu����
                    // 2010/05/19 >>>
                    //if (!(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                    //{
                    //    int time = (end / 100 - start / 100) * 60 + (end % 100 - start % 100);
                    //    if (row.ChkInterval > time)
                    //    {
                    //        // ��񒲐�
                    //        this.AfterDataAdjust();
                    //        // ���b�Z�[�W���Ăяo��
                    //        TMsgDisp.Show(
                    //         this,
                    //         emErrorLevel.ERR_LEVEL_INFO,
                    //         this.Name,
                    //         "�Ԋu���Ԃ͈͎̔w��Ɍ�肪����܂��B",
                    //         -1,
                    //         MessageBoxButtons.OK);
                    //        this.uGrid_Result.Rows[i].Cells[4].Activate();
                    //        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                    //        return false;
                    //    }
                    //}

                    if (!( this.uGrid_Result.Rows[i].Cells[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Value is DBNull ))
                    {
                        bool check = true;
                        string msg = string.Empty;
                        int time = ( end / 100 - start / 100 ) * 60 + ( end % 100 - start % 100 );
                        if (row.ChkInterval > time)
                        {
                            check = false;
                            msg = "�Ԋu���Ԃ͈͎̔w��Ɍ�肪����܂��B";

                            return false;
                        }
                        else if (row.ChkInterval < ctInterval_Minvalue)
                        {
                            check = false;
                            msg = string.Format("���s�Ԋu��{0}���ȏ�ɂ��ĉ������B", ctInterval_Minvalue);
                        }

                        if (!check)
                        {
                            // ��񒲐�
                            this.AfterDataAdjust();

                            // ���b�Z�[�W���Ăяo��
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             msg,
                             -1,
                             MessageBoxButtons.OK);
                            this.uGrid_Result.Rows[i].Cells[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }

                    // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
                    if (this._commdt.ContainsKey(row.PgId.Trim().ToUpper()) && !row.PgId.Trim().ToUpper().Equals(ctPGID_OfferDataUpdate))
                    {
                        i++;
                        continue;
                    }
                    // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<

                    #region �������Ԃ̌���

                    int startTime = Convert.ToInt32(row.ChkStTime);
                    int endTime = Convert.ToInt32(row.ChkEdTime);

                    // �񋟃f�[�^�X�V�����́A0:00�`3:00�͎��s�s��
                    if (row.PgId.Trim().ToUpper().Equals(ctPGID_OfferDataUpdate))                       
                    {
                        if (startTime < 300 || endTime < 300)
                        {
                            // ��񒲐�
                            this.AfterDataAdjust();

                            // ���b�Z�[�W���Ăяo��
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             "�񋟃f�[�^�X�V������"+
                             Environment.NewLine +
                             "���L���Ԃ͐ݒ�ł��܂���B"+
                             Environment.NewLine+
                             Environment.NewLine +
                             "�@0:00 �` 3:00",
                             -1,
                             MessageBoxButtons.OK);

                            this.uGrid_Result.Rows[i].Cells[( startTime < 300 ) ? this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName : this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }
                    // �񋟃f�[�^�X�V�łȂ��ꍇ�́A0:00�`6:00�͎��s�s��
                    else
                    {
                        if (startTime < 600 || endTime < 600)
                        {
                            // ��񒲐�
                            this.AfterDataAdjust();

                            // ���b�Z�[�W���Ăяo��
                            TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_INFO,
                             this.Name,
                             "���L���Ԃ͐ݒ�ł��܂���B" +
                             Environment.NewLine +
                             Environment.NewLine +
                             "�@0:00 �` 6:00",
                             -1,
                             MessageBoxButtons.OK);
                            this.uGrid_Result.Rows[i].Cells[( startTime < 600 ) ? this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName : this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Activate();
                            this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            return false;
                        }
                    }
                    #endregion
                    // 2010/05/19 <<<
                }

                i++;
            }

            if (!isExistFlg)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�L���Ȗ��ׂ����͂���Ă��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                // �t�H�[�J�X�ݒ�
                this.uGrid_Result.Rows[0].Cells[0].Activate();
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                return false;
            }

            return true;
        }

        /// <summary>
        /// �ۑ��O����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public void SaveDataAdjust()
        {
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                // �`�F�b�N�J�n����
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    if (row.ChkStTime.Length == 5)
                    {
                        // ��񒲐�
                        row.ChkStTime = row.ChkStTime.Substring(0, 2) + row.ChkStTime.Substring(3);
                    }
                    else if (row.ChkStTime.Length == 18)
                    {
                        // ��񒲐�
                        row.ChkStTime = "0" + row.ChkStTime.Substring(11, 1) + row.ChkStTime.Substring(13, 2);
                    }
                    else if (row.ChkStTime.Length == 19)
                    {
                        // ��񒲐�
                        row.ChkStTime = row.ChkStTime.Substring(11, 2) + row.ChkStTime.Substring(14, 2);
                    }
                }
                // �`�F�b�N�I������
                if (!string.IsNullOrEmpty(row.ChkEdTime))
                {
                    if (row.ChkEdTime.Length == 5)
                    {
                        // ��񒲐�
                        row.ChkEdTime = row.ChkEdTime.Substring(0, 2) + row.ChkEdTime.Substring(3);
                    }
                    else if (row.ChkEdTime.Length == 18)
                    {
                        // ��񒲐�
                        row.ChkEdTime = "0" + row.ChkEdTime.Substring(11, 1) + row.ChkEdTime.Substring(13, 2);
                    }
                    else if (row.ChkEdTime.Length == 19)
                    {
                        // ��񒲐�
                        row.ChkEdTime = row.ChkEdTime.Substring(11, 2) + row.ChkEdTime.Substring(14, 2);
                    }
                }
            }
        }

        /// <summary>
        /// ��񒲐�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void AfterDataAdjust()
        {
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                // �`�F�b�N�J�n����
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    if (row.ChkStTime.Length == 4)
                    {
                        row.ChkStTime = row.ChkStTime.Substring(0, 2) + ":" + row.ChkStTime.Substring(2);
                    }
                }
                // �`�F�b�N�I������
                if (!string.IsNullOrEmpty(row.ChkEdTime))
                {
                    if (row.ChkEdTime.Length == 4)
                    {
                        row.ChkEdTime = row.ChkEdTime.Substring(0, 2) + ":" + row.ChkEdTime.Substring(2);
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�G�f�B�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void SettingGridRow()
        {
            // ��ʏ��
            int i = 0;
            foreach (conf.ConfRow row in this._serviceFilesInputAcs.Conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    this.uGrid_Result.Rows[i].Cells[2].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    this.uGrid_Result.Rows[i].Cells[3].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                i++;
            }
        }
        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void PMKYO09301UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this.uGrid_Result);


            this.uGrid_Result.DataSource = _serviceFilesInputAcs.Conf.Conf;
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ����������
            closeFlg = true;
            int status = this.Clear();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.closeFlg = false;
                return;
            }

            this.timer_setFocus.Enabled = true;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            int iIndex = 1;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;

                // 2010/05/19 Del >>>
                col.Hidden = true;
                //if (iIndex > 5)
                //{
                //    col.Hidden = true;
                //}
                //iIndex++;
                // 2010/05/19 Del <<<
            }
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Header.VisiblePosition = iIndex++;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Hidden = false;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Header.VisiblePosition = iIndex++;
            // 2010/05/19 Add <<<

            // �O���b�h
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add <<<

            // CellAppearance�ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 2010/05/19 Add <<<


            // �\�����ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Width = 165;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Width = 165;
            // 2010/05/19 >>>
            //this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Width = 340;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Width = 200;
            // 2010/05/19 <<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName].Width = 164;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Width = 140;
            // 2010/05/19 Add <<<
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Width = 160;

            // �t�H�[�}�b�g
            string format = "###";
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName].Format = format;

            // CharacterCasing 
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // style
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Time;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Time;
            // 2010/05/19 Add >>>
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            Infragistics.Win.ValueList valueList;
            this.SetExecuteDivComboEditor(out valueList);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._serviceFilesInputAcs.Conf.Conf.ProcessExecuteDivColumn.ColumnName].ValueList = valueList;
            // 2010/05/19 Add <<<
        }

        // 2010/05/19 Add >>>
        /// <summary>
        /// �������s�敪�̃Z�b�g
        /// </summary>
        /// <param name="valueList"></param>
        private void SetExecuteDivComboEditor(out Infragistics.Win.ValueList valueList)
        {
            valueList = new Infragistics.Win.ValueList();
            valueList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;

            Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
            item1.Tag = 0;
            item1.DataValue = 0;
            item1.DisplayText = "����";

            valueList.ValueListItems.Add(item1);

            Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
            item2.Tag = 1;
            item2.DataValue = 1;
            item2.DisplayText = "�Ȃ�";
            valueList.ValueListItems.Add(item2);
        }
        // 2010/05/19 Add <<<

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uButton_Delete_Click(object sender, EventArgs e)
        {


            // �A�N�e�B�u�s�`�F�b�N
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            this._serviceFilesInputAcs.Conf.Conf.AcceptChanges();

            // �A�N�e�B�u�s�擾
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
            }

            // �Ō�s���폜�ł��Ȃ�
            if (this._serviceFilesInputAcs.Conf.Conf.Count == 1)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_INFO,
                     this.Name,
                     "�폜�Ώۍs�����݂��܂���B",
                     -1,
                     MessageBoxButtons.OK);
                return;
            }
            if (activeRowIndex + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�폜�Ώۍs�����݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);
                return;
            }

            DialogResult result = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "�I�������s���폜���܂����H",
                -1,
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // �A�N�e�B�u�s�폜
                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[activeRowIndex];

                this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(row);

                // this._serviceFilesInputAcs.Conf.Conf.Rows[activeRowIndex].Delete();
                // this.uGrid_Result.Rows[activeRowIndex].Delete(true);
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                        {
                            isSaveFlg = true;

                            if (this.ReturnKeyDown())
                            {
                                e.NextCtrl = null;
                            }
                            else
                            {
                                if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                {
                                    this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                    e.NextCtrl = this.uButton_Delete;
                                }
                                else if (isSaveFlg)
                                {
                                    // �G���[���Ȃ��A�폜�{�^�����ړ�����
                                    e.NextCtrl = uButton_Delete;
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }
                        break;
                    }
                case "uButton_Delete":
                    {
                        if (this._serviceFilesInputAcs.Conf.Conf.Count != 0)
                        {
                            this.uGrid_Result.Focus();
                            if (e.Key == Keys.Return || e.Key == Keys.Tab)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Result.Rows[0].Cells[0].Activate();
                                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_Result":
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                if (e.NextCtrl == this.uGrid_Result)
                                {
                                    //e.NextCtrl = this.uButton_Delete;
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            // �폜�{�^����Ԑݒ�
           this.DelButtonSetting();
        }

        /// <summary>
        /// �폜�{�^����Ԑݒ�
        /// </summary>
        private void DelButtonSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            // �A�N�e�B�u�s�擾
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                if (this.uGrid_Result.ActiveCell != null)
                {
                    activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                }
                else
                {
                    return;
                }
            }

            if (activeRowIndex + 1 > delNum)
            {
                this.uButton_Delete.Enabled = true;
            }
            else
            {
                this.uButton_Delete.Enabled = false;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void timer_setFocus_Tick(object sender, EventArgs e)
        {
            if (closeFlg)
            {
                // �t�H�[�J�X�ݒ�
                this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_setFocus.Enabled = false;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // ��ʂ����
                        this.Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // ��ʃN���A
                        this.Clear();
                        // �t�H�[�J�X�ݒ�
                        this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[0].Activate();
                        this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);

                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // �󔒂�ǉ�����
            if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
            {
                if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkStTimeColumn.ColumnName
                    || cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkEdTimeColumn.ColumnName)
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
                else if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
                {
                    if (Char.IsDigit(e.KeyChar) && !e.KeyChar.ToString().Equals("0"))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
                else
                {
                    if (!Char.IsControl(e.KeyChar))
                    {
                        conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                    }
                }
            }

            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.RunParamColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressStringCheck(30, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool KeyPressStringCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = ServiceFilesInputAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {

            this.uGrid_Result.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Result.ActiveCell != null))
            {
                if ((!this.uGrid_Result.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Result.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // �[������͂���Ƃ�
            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.ChkIntervalColumn.ColumnName)
            {
                string value = cell.Value.ToString();

                if (value.Equals("0"))
                {
                    cell.Value = DBNull.Value;
                }
            }

            // �󔒍s���폜����
            if (cell.Row.Index >= 0)
            {

                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[cell.Row.Index];

                // �Ō�󔒍s���폜����
                if (string.IsNullOrEmpty(row.ChkStTime) && string.IsNullOrEmpty(row.ChkEdTime)
                    && string.IsNullOrEmpty(row.PgId) && string.IsNullOrEmpty(row.RunParam)
                    && cell.Row.Cells[4].Value is DBNull)
                {
                    if (cell.Row.Index + 2 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    {
                        ArrayList delRow = new ArrayList();

                        int i = 0;
                        for (i = this._serviceFilesInputAcs.Conf.Conf.Count - 1; i >= 0; i--)
                        {
                            // �󔒍s���v�Z����
                            conf.ConfRow rowValue = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[i];
                            if (!string.IsNullOrEmpty(rowValue.ChkStTime)
                                || !string.IsNullOrEmpty(rowValue.ChkEdTime) || !string.IsNullOrEmpty(rowValue.PgId)
                                || !string.IsNullOrEmpty(rowValue.RunParam) || !(this.uGrid_Result.Rows[i].Cells[4].Value is DBNull))
                            {
                                break;
                            }
                            else
                            {
                                if (i != this._serviceFilesInputAcs.Conf.Conf.Count - 1)
                                {
                                    delRow.Add(this._serviceFilesInputAcs.Conf.Conf.Rows[i + 1]);
                                }
                            }
                        }

                        // �󔒍s���폜����
                        foreach (conf.ConfRow selRow in delRow)
                        {
                            this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(selRow);
                        }
                    }
                    //if (cell.Row.Index + 2 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    //{
                    //    conf.ConfRow delrow = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1];
                    //    this._serviceFilesInputAcs.Conf.Conf.RemoveConfRow(delrow);
                    //}
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void CellDataError(object sender, CellDataErrorEventArgs e)
        {
            // �ۑ����Ȃ�
            isSaveFlg = false;

            if (this.uGrid_Result.ActiveCell != null)
            {
                if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(Int32)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "���͕s���ł��B",
                       -1,
                       MessageBoxButtons.OK);

                    editorBase.Value = 0;
                    this.uGrid_Result.ActiveCell.Value = 0;

                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(string)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "���͕s���ł��B",
                       -1,
                       MessageBoxButtons.OK);

                    this.uGrid_Result.Focus();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }

                e.RaiseErrorEvent = false;	
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void PMKYO09301UA_Shown(object sender, EventArgs e)
        {
            if (!this.closeFlg)
            {
                this.Close();
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
                // Shift�L�[�̏ꍇ
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Result.ActiveCell = null;
                                this.uGrid_Result.ActiveRow = cell.Row;
                                this.uGrid_Result.Selected.Rows.Clear();
                                this.uGrid_Result.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Result.ActiveCell = null;
                                this.uGrid_Result.ActiveRow = cell.Row;
                                this.uGrid_Result.Selected.Rows.Clear();
                                this.uGrid_Result.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                // EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Alt�L�[�̏ꍇ
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
                                break;
                            }
                    }
                }
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_Result.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_Result.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_Result.ActiveCell.SelStart >= this.uGrid_Result.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                }
                                break;
                            // 2009.05.06 ���m add
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Time:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        case Keys.Up:
                                            {
                                                if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                                                {
                                                    conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                                                    this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                                                }
                                            }
                                            break;
                                        case Keys.Down:
                                            {
                                                if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                                                {
                                                    conf.ConfRow row = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                                                    this._serviceFilesInputAcs.Conf.Conf.AddConfRow(row);
                                                }
                                            }
                                            break;

                                    }
                                    break;
                                }
                            // ��L�ȊO�̃X�^�C��
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.uGrid_Result.ActiveCell != null) && (this.uGrid_Result.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                isSaveFlg = true;

                                if (this.ReturnKeyDown())
                                {
                                    // e.NextCtrl = null;
                                }
                                else
                                {
                                    if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                    {
                                        this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uButton_Delete.Focus();
                                    }
                                    else if (isSaveFlg)
                                    {
                                        // �G���[���Ȃ��A�폜�{�^�����ړ�����
                                        uButton_Delete.Focus();
                                    }
                                    else
                                    {
                                        // e.NextCtrl = e.PrevCtrl;
                                    }
                                }

                                // �폜�{�^����Ԑݒ�
                                this.DelButtonSetting();
                                break;
                            }
                        case Keys.Tab:
                            {
                                isSaveFlg = true;

                                if (this.uGrid_Result.Rows[this._serviceFilesInputAcs.Conf.Conf.Count - 1].Cells[4].Activated)
                                {
                                    this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);
                                    this.uButton_Delete.Focus();
                                }

                                // �폜�{�^����Ԑݒ�
                                this.DelButtonSetting();
                                break;
                            }
                    }
                }
            }

            else if (this.uGrid_Result.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Del�L�[�̑���
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uButton_Delete_EnabledChanged(object sender, EventArgs e)
        {
            if (this.uButton_Delete.Enabled)
            {
                this.tArrowKeyControl1.OwnerForm = this.panel_Detail;
                this.tRetKeyControl1.OwnerForm = this.panel_Detail;
            }
            else
            {
                this.tArrowKeyControl1.OwnerForm = this.uGrid_Result;
                this.tRetKeyControl1.OwnerForm = this.uGrid_Result;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            // �{�^����Ԑݒ�
            this.DelButtonSetting();
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private void uGrid_Result_MouseClick(object sender, MouseEventArgs e)
        {
            // �{�^����Ԑݒ�
            this.DelButtonSetting();
        }

        private void uGrid_Result_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // �󔒍s��ǉ�����
            if (cell.Row.Index >= 0)
            {
                conf.ConfRow row = (conf.ConfRow)this._serviceFilesInputAcs.Conf.Conf.Rows[cell.Row.Index];

                // �Ō�󔒍s���폜����
                if (!string.IsNullOrEmpty(row.ChkStTime) || !string.IsNullOrEmpty(row.ChkEdTime)
                    || !string.IsNullOrEmpty(row.PgId) || !string.IsNullOrEmpty(row.RunParam)
                    || !(cell.Row.Cells[4].Value is DBNull))
                {
                    if (cell.Row.Index + 1 == this._serviceFilesInputAcs.Conf.Conf.Count)
                    {
                        conf.ConfRow addRow = this._serviceFilesInputAcs.Conf.Conf.NewConfRow();
                        this._serviceFilesInputAcs.Conf.Conf.AddConfRow(addRow);
                    }
                }
            }

            if (cell.Column.Key == this._serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName)
            {
                string value = cell.Value.ToString();

                // �S�p�𔻒f����
                bool isHalfKana = true;
                for (int i = 0; i < value.Length; i++)
                {
                    String cutStr = value.Substring(i, 1);
                    if (ASCIIEncoding.Default.GetByteCount(cutStr) == 2)
                    {
                        isHalfKana = false;
                        break;
                    }
                }

                // �S�p������̏ꍇ�A�N���A����
                if (!isHalfKana)
                {
                    cell.Value = string.Empty;
                }
            }
        }
        #endregion

        private void uGrid_Result_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IME���Ђ炪�ȃ��[�h�ɂ���
            this.uGrid_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            //// �Z���P�ʂł�IME����	
            //if ((e.Cell.Column.Key == _serviceFilesInputAcs.Conf.Conf.PgIdColumn.ColumnName))
            //{
            //    // IME���Ђ炪�ȃ��[�h�ɂ���
            //    this.uGrid_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            //}
            //else
            //{
            //    //// IME���N�����Ȃ�
            //    //this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
            //}
        }
    }
}