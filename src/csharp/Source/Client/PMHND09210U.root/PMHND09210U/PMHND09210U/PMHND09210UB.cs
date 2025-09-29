//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�o�[�R�[�h�ꊇ�o�^                                  //
// �v���O�����T�v   : ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�捞UI�N���X     �@�@    //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������                                 //
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�捞UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�捞UI�N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
    public partial class PMHND09210UB : Form
    {
        # region private field
        /// <summary>�e�L�X�g�捞���[�U�[�ݒ�</summary>
        private GoodsBarCodeRevnImportTextUserConst _userSetting;
        /// <summary>�e�L�X�g�捞�A�N�Z�X</summary>
        private GoodsBarCodeRevnImportAcs _goodsBarCodeRevnImportAcs;
        #endregion

        #region Const Memebers
        /// <summary>�N���XID</summary>
        private const string ct_ClassID = "PMHND09210UB";
        /// <summary>�N���X����</summary>
        private const string ct_ClassName = "���i�o�[�R�[�h�ꊇ�o�^�i�e�L�X�g�捞�j";
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string ct_XML_FILE_NAME = "PMHND09210UB_Construction.XML";
        // �G���[���O���o�͂��鎞�A�m�F���b�Z�[�W
        private const string ERRORLOG_EXPORT_MSG = "�C���|�[�g�Ɏ��s�����s������܂��B\r\n{0}���Q�Ƃ��ĉ������B";

        #region �����敪
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "�ǉ��X�V";
        private const string ct_AddNm = "�ǉ�";
        private const string ct_UpdNm = "�X�V";
        #endregion

        #region �`�F�b�N�敪
        private const int ct_DataCheckOn = 0;
        private const int ct_DataCheckOff = 1;
        private const string ct_DataCheckOnNm = "����";
        private const string ct_DataCheckOffNm = "�Ȃ�";
        #endregion

        #endregion

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	    : �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UB()
        {
            InitializeComponent();
            // �R���{�{�b�N�X������
            InitializeComboEditor();
            // �e�L�X�g�捞�A�N�Z�X
            this._goodsBarCodeRevnImportAcs = new GoodsBarCodeRevnImportAcs();
            // �e�L�X�g�捞���[�U�[�ݒ�
            this._userSetting = new GoodsBarCodeRevnImportTextUserConst();
        }

        #region �� ��ʏ���������
        /// <summary>
        /// �R���{�{�b�N�X������
        /// </summary>
        /// <remarks>
        /// <br>Note	    : �R���{�{�b�N�X���������s��</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private void InitializeComboEditor()
        {
            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();

                Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
                // �ǉ��X�V
                listItem0.DataValue = ct_AddUpdCd;
                listItem0.DisplayText = ct_AddUpdNm;

                // �ǉ�
                Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
                listItem1.DataValue = ct_AddCd;
                listItem1.DisplayText = ct_AddNm;

                // �X�V
                Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
                listItem2.DataValue = ct_UpdCd;
                listItem2.DisplayText = ct_UpdNm;

                this.tComboEditor_ProcessKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem0, listItem1, listItem2 });

                // �u�ǉ��X�V�v��I������Ă��܂�
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                this.tComboEditor_DataCheckKbn.BeginUpdate();
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                // ����
                listItem3.DataValue = ct_DataCheckOn;
                listItem3.DisplayText = ct_DataCheckOnNm;
                // �Ȃ�
                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_DataCheckOff;
                listItem4.DisplayText = ct_DataCheckOffNm;
                this.tComboEditor_DataCheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });
                // �u����v��I������Ă��܂�
                this.tComboEditor_DataCheckKbn.SelectedIndex = 0;

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                // �G���[���O�t�@�C����
                this.uButton_ErrorLogFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ÷��̧�ٖ�
                this.uButton_ErrorLogFileGuide.Appearance.Image = Size16_Index.STAR1;

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_DataCheckKbn.EndUpdate();

            }
            catch
            {
            }
        }
        #endregion �� ��ʏ���������

        #region �� ��ʃC�x���g
        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʋN���������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UB_Load(object sender, EventArgs e)
        {
            // �{�^���ݒ�
            this.uButton_TextFileGuide.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_TextFileGuide.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            this.uButton_ErrorLogFileGuide.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_ErrorLogFileGuide.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
            // ���i�o�[�R�[�h�ꊇ�o�^�p���[�U�[�ݒ�f�V���A���C�Y����
            this.Deserialize();
            // ���[�U�[�ݒ��� �� ���
            SetUserSettingToScreen();
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�@�C���_�C�A���O�\���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_TextFileGuide_Click(object sender, EventArgs e)
        {
            // �^�C�g���o�[�̕�����
            this.openFileDialog.Title = "�捞�t�@�C���I��";
            this.openFileDialog.RestoreDirectory = true;
            if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
            {
                this.openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
            else
            {
                this.openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
            }
            //�u�t�@�C���̎�ށv���w��
            this.openFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // �e�L�X�g�t�@�C����
                this.tEdit_TextFileName.DataText = this.openFileDialog.FileName;
                // �e�L�X�g�t�@�C�����ύX���ꂽ�������C�x���g
                tEdit_TextFileName_ValueChanged(null, null);
            }
        }

        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�@�C���_�C�A���O�\���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_ErrorLogFileGuide_Click(object sender, EventArgs e)
        {
            // �^�C�g���o�[�̕�����
            this.saveFileDialog1.Title = "�G���[���O�t�@�C���I��";
            this.saveFileDialog1.RestoreDirectory = true;
            if (this.tEdit_ErrorLogFileName.Text.Trim() == string.Empty)
            {
                this.saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
            else
            {
                this.saveFileDialog1.FileName = System.IO.Path.GetFileName(this.tEdit_ErrorLogFileName.Text);
                this.saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_ErrorLogFileName.Text);
            }
            //�u�t�@�C���̎�ށv���w��
            this.saveFileDialog1.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tEdit_ErrorLogFileName.DataText = this.saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// �e�L�X�g�t�@�C�����ύX���ꂽ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�t�@�C�����ύX���ꂽ���������܂��B</br> 
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            // �e�L�X�g�t�@�C����
            string textFileName = this.tEdit_TextFileName.DataText.Trim();
            if (!string.IsNullOrEmpty(textFileName))
            {
                try
                {
                    // �e�L�X�g�t�@�C���p�X
                    string textFilePath = textFileName.Substring(0, textFileName.LastIndexOf('\\'));
                    // �e�L�X�g�t�@�C����(�p�X�Ȃ�)
                    string fileName = textFileName.Substring(textFileName.LastIndexOf('\\') + 1, textFileName.Length - 5 - textFileName.LastIndexOf('\\'));
                    // �G���[���O�t�@�C�������Z�b�g
                    this.tEdit_ErrorLogFileName.DataText = textFilePath + "\\" + fileName + "_Error.CSV";
                }
                catch
                {
                    // �����Ȃ�
                }
            }
        }

        /// <summary>
        /// �e�L�X�g�捞����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�捞�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            string errMessage = string.Empty;
            string errorLogFileName = string.Empty;
            // ���̓`�F�b�N����
            if (!ScreenInputCheck(ref errMessage, out errorLogFileName))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                return;
            }
            // ��� �� ���[�U�[�ݒ���
            GetUserSettingFromScreen();
            // _userSetting�͏����ς���Ă���̂Őݒ�XML�X�V
            this.Serialize();

            // �e�L�X�g�捞����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA form = new SFCMN00299CA();
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // �\��������ݒ�
                form.Title = "�e�L�X�g�捞��";
                form.Message = "���݁A�f�[�^���e�L�X�g�捞���ł��D�D�D";
                // �_�C�A���O�\��
                form.Show();

                this.uLabel_ReadCnt.Text = "0";
                this.uLabel_AddCnt.Text = "0";
                this.uLabel_UpdCnt.Text = "0";
                this.uLabel_ErrorCnt.Text = "0";

                // �捞����
                int readCnt = 0;
                // �ǉ�����
                int addCnt = 0;
                // �X�V����
                int updCnt = 0;
                // �G���[����
                int errCnt = 0;
                // �t�@�C���f�[�^
                List<GoodsBarCodeRevnFileWork> fileWorkList = new List<GoodsBarCodeRevnFileWork>();
                // �t�@�C���f�[�^�擾����
                if (!GetTextFileData(this.tEdit_TextFileName.Text.Trim(), out fileWorkList, out errMessage))
                {
                    // �_�C�A���O�����
                    if (form != null) form.Close();
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                    return;
                }

                //�C���|�[�g����
                status = _goodsBarCodeRevnImportAcs.Import(fileWorkList, errorLogFileName, this._userSetting.ProcessKbn, this._userSetting.DataCheckKbn, out readCnt, out addCnt, out updCnt, out errCnt, out errMessage);

                // �_�C�A���O�����
                if (form != null) form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // �Ǎ�����
                        this.uLabel_ReadCnt.Text = NumberFormat(readCnt);
                        if (addCnt > 0 || updCnt > 0)
                        {
                            // �ǉ�����
                            this.uLabel_AddCnt.Text = NumberFormat(addCnt);
                            // �X�V����
                            this.uLabel_UpdCnt.Text = NumberFormat(updCnt);
                            // �G���[����
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, errorLogFileName), status);
                            }
                        }
                        else
                        {
                            // �G���[����
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, errorLogFileName), status);
                            }
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y���f�[�^����", status);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�e�L�X�g�捞�Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
                        break;
                }
            }
            catch
            {
                // �_�C�A���O�����
                if (form != null) form.Close();
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "�e�L�X�g�捞�Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }

        }

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            // �I��
            this.Close();
        }

        #region �t�H�[�J�X�ړ��C�x���g
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // �����敪���`�F�b�N�敪
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                    }
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // �`�F�b�N�敪��÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O��  �G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // �G���[���O�t�@�C������  �G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O��  �捞
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // �捞��  �L�����Z��
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // �L�����Z����  �����敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
                else if (e.Key == Keys.Right)
                {
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn || e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                }
                else if (e.Key == Keys.Left)
                {
                    if (e.PrevCtrl == this.uButton_OK)
                    {
                        // �捞
                        e.NextCtrl = this.uButton_OK;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // �����敪�� �L�����Z��
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // �L�����Z����  �捞
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // �捞��  �G���[���O�t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }

                    else if (e.PrevCtrl == this.uButton_ErrorLogFileGuide)
                    {
                        // �G���[���O�t�@�C���_�C�A���O���G���[���O�t�@�C����
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // �G���[���O�t�@�C�������t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // �t�@�C���_�C�A���O���e�L�X�g�t�@�C����
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // �e�L�X�g�t�@�C������ �`�F�b�N�敪
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                    }
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // �`�F�b�N�敪�������敪
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region �� ���̓t�@�C�����`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errorLogFileName">�G���[���O�t�@�C���o�X</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, out string errorLogFileName)
        {
            // �e�L�X�g�t�@�C����
            string textFileName = tEdit_TextFileName.DataText.Trim();
            // �G���[���O�t�@�C����
            errorLogFileName = tEdit_ErrorLogFileName.DataText.Trim();
            // �p�X���͂��Ȃ��ꍇ
            if (string.IsNullOrEmpty(textFileName))
            {
                errMessage = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                this.tEdit_TextFileName.Focus();
                return false;
            }
            // �p�X���͕s���ꍇ
            if (!File.Exists(textFileName))
            {
                errMessage = "�e�L�X�g�t�@�C���p�X���s���ł��B";
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // �p�X���͂��Ȃ��ꍇ
            if (string.IsNullOrEmpty(errorLogFileName))
            {
                errMessage = "�G���[���O�t�@�C��������͂��Ă��������B";
                this.tEdit_ErrorLogFileName.Focus();
                return false;
            }

            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            //�f�B���N�g�����݂��Ȃ��ꍇ
            if (!Directory.Exists(errorLogFileName))
            {
                if (dir_index > 0 && file_index > 0)
                {
                    string errorLogFileDir = string.Empty;
                    if (file_index > dir_index)
                    {
                        errorLogFileDir = errorLogFileName.Substring(0, dir_index);
                    }
                    else
                    {
                        errorLogFileDir = errorLogFileName;
                    }
                    if (!Directory.Exists(errorLogFileDir))
                    {
                        errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";
                        this.tEdit_ErrorLogFileName.Focus();
                        return false;
                    }
                }
                else
                {
                    errMessage = "�G���[���O�t�@�C���p�X���s���ł��B";
                    this.tEdit_ErrorLogFileName.Focus();
                    return false;
                }
            }
            else
            {
                if (dir_index + 1 == errorLogFileName.Length)
                {
                    errorLogFileName = errorLogFileName + "ErrLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";
                }
                else
                {
                    errorLogFileName = errorLogFileName + "\\" + "ErrLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".CSV";
                }
            }
            //�����p�X�̏ꍇ
            if (textFileName.ToUpper().Equals(errorLogFileName.ToUpper()))
            {
                errMessage = "�e�L�X�g�t�@�C�����ƃG���[���O�t�@�C�����͓���̎w��͏o���܂���B";
                this.tEdit_ErrorLogFileName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region �� �e�L�X�g�f�[�^��ǂ�
        /// <summary>
        /// �e�L�X�g�t�@�C���f�[�^�擾����
        /// </summary>
        /// <param name="textFileName">�t�@�C�����O</param>
        /// <param name="fileWorkList">�e�L�X�g�t�@�C���f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>True:�擾����OK, False:�擾����NG</returns>
        /// <remarks>
        /// <br>Note	   : �e�L�X�g�t�@�C���f�[�^�擾�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool GetTextFileData(string textFileName, out List<GoodsBarCodeRevnFileWork> fileWorkList, out string errMsg)
        {
            errMsg = string.Empty;
            fileWorkList = new List<GoodsBarCodeRevnFileWork>();
            TextFieldParser parser = new TextFieldParser(textFileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    // ��؂蕶���̓R���}
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        // 1�s�ǂݍ���
                        string[] row = parser.ReadFields();
                        GoodsBarCodeRevnFileWork work = new GoodsBarCodeRevnFileWork();
                        // ���i���[�J�[�R�[�h
                        work.GoodsMakerCd = ConvertToString(row, 0);
                        // �i��
                        work.GoodsNo = ConvertToString(row, 1);
                        // �o�[�R�[�h
                        work.GoodsBarCode = ConvertToString(row, 2);
                        // �o�[�R�[�h���
                        work.GoodsBarCodeKind = ConvertToString(row, 3);
                        fileWorkList.Add(work);
                    }
                }
            }
            catch
            {
                errMsg = "�e�L�X�g�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B" + parser.ErrorLineNumber + "�s�ڂ̓��e���m�F���Ă��������B";
                return false;
            }
            // �^�C�g���s
            if (fileWorkList.Count > 1)
            {
                fileWorkList.RemoveAt(0);
            }
            else
            {
                // ���R�[�h���Ȃ��ꍇ
                errMsg = "�Y������f�[�^������܂���B";
                return false;
            }
            return true;
        }
        #endregion

        #region �� �������ڂ֕ϊ�����
        /// <summary>
        /// �������ڂ֕ϊ�����
        /// </summary>
        /// <param name="dataArr">txt���ڔz��</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>�������ڂ֕ϊ�����</returns>
        /// <remarks>
        /// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string ConvertToString(string[] dataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < dataArr.Length)
            {
                retContent = dataArr[index];
            }

            return retContent;
        }
        #endregion

        #region �� �����̃t�H�[�}�b�g
        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <returns>�����̃t�H�[�}�b�g����</returns>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(int number)
        {
            string ret;
            if (number > 999)
            {
                // �����̃t�H�[�}�b�g
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }

            return ret;
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_ClassName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� ���[�U�[�ݒ�̕ۑ��E�ǂݍ���
        /// <summary>
        /// ���i�o�[�R�[�h�ꊇ�o�^���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�ꊇ�o�^���[�U�[�ݒ�V���A���C�Y�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // ���[�U�[�ݒ�̕ۑ�
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// ���i�o�[�R�[�h�ꊇ�o�^�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�ꊇ�o�^�p���[�U�[�ݒ�f�V���A���C�Y�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME)))
            {
                try
                {
                    // ���[�U�[�ݒ�̓ǂݍ���
                    this._userSetting = UserSettingController.DeserializeUserSetting<GoodsBarCodeRevnImportTextUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new GoodsBarCodeRevnImportTextUserConst();
                }
            }
        }

        /// <summary>
        /// ���[�U�[�ݒ��� �� ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�ݒ������ʂɃZ�b�g�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetUserSettingToScreen()
        {
            // �����敪
            if (this.tComboEditor_ProcessKbn.Items.Count > this._userSetting.ProcessKbn && this._userSetting.ProcessKbn >= 0)
            {
                this.tComboEditor_ProcessKbn.SelectedIndex = this._userSetting.ProcessKbn;
            }
            // �`�F�b�N�敪
            if (this.tComboEditor_DataCheckKbn.Items.Count > this._userSetting.DataCheckKbn && this._userSetting.DataCheckKbn >= 0)
            {
                this.tComboEditor_DataCheckKbn.SelectedIndex = this._userSetting.DataCheckKbn;
            }
            // �e�L�X�g�t�@�C��
            this.tEdit_TextFileName.Text = this._userSetting.TextFileName;
            // �G���[���O�t�@�C��
            this.tEdit_ErrorLogFileName.Text = this._userSetting.LogFileName;
        }

        /// <summary>
        /// ��� �� ���[�U�[�ݒ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂŃ��[�U�[�ݒ�������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetUserSettingFromScreen()
        {
            // �����敪
            this._userSetting.ProcessKbn = this.tComboEditor_ProcessKbn.SelectedIndex;
            // �`�F�b�N�敪
            this._userSetting.DataCheckKbn = this.tComboEditor_DataCheckKbn.SelectedIndex;
            // �e�L�X�g�t�@�C��
            this._userSetting.TextFileName = this.tEdit_TextFileName.Text;
            // �G���[���O�t�@�C��
            this._userSetting.LogFileName = this.tEdit_ErrorLogFileName.Text;

        }
        #endregion
    }
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^�p�e�L�X�g�捞���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�ꊇ�o�^�̃e�L�X�g�捞���[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnImportTextUserConst
    {
        #region �v���C�x�[�g�ϐ�

        // �����敪
        private int _processKbn;

        // �`�F�b�N�敪
        private int _dataCheckKbn;

        // �e�L�X�g�t�@�C��
        private string _textFileName;

        // �G���[���O�t�@�C��
        private string _logFileName;

        #endregion

        #region �v���p�e�B
        /// <summary>�����敪</summary>
        public int ProcessKbn
        {
            get { return _processKbn; }
            set { _processKbn = value; }
        }

        /// <summary>�`�F�b�N�敪</summary>
        public int DataCheckKbn
        {
            get { return _dataCheckKbn; }
            set { _dataCheckKbn = value; }
        }

        /// <summary>�e�L�X�g�t�@�C��</summary>
        public string TextFileName
        {
            get { return _textFileName; }
            set { _textFileName = value; }
        }

        /// <summary>�G���[���O�t�@�C��</summary>
        public string LogFileName
        {
            get { return _logFileName; }
            set { _logFileName = value; }
        }
        #endregion
    }
}