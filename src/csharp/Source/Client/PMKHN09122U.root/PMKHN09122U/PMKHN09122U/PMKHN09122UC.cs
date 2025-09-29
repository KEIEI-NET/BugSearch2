//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �e�L�X�g�o�͊m�F���
// �v���O�����T�v   : �e�L�X�g�o�͊m�F���
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11202046-00   �쐬�S�� : ���V��
// �� �� �� : K2016/10/28   �C�����e : �_�P�Y�Ƈ� �e�L�X�g�o�͋@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �e�L�X�g�o�͊m�F��ʂ̃t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �e�L�X�g�o�͊m�F��ʂ̃t�H�[���N���X</br>
    /// <br>Programmer   : ���V��</br>
    /// <br>Date         : K2016/10/28</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN09122UC : Form
    {
        #region �퐔
        // �N���X��
        private const string CT_PRINTNAME = "�e�L�X�g�o�͊m�F";
        private const string CT_PGID = "PMKHN09122UC";

        //�G���[�������b�Z�[�W
        private const string CT_NOINPUT = "����͂��ĉ������B";
        private const string CT_FILEALRDYERROR = "�o�͐�t�@�C�������Ŏg�p���ł��B";
        private const string CT_FILEPATHERROR = "�w�肳�ꂽ�t�H���_�����݂��܂���B";
        private const string CT_FILEEXPENDERROR = "�w�肳�ꂽ�t�@�C�����͕s���ł��B";
        private const string CT_FILEACCESSERROR = "�o�͐�t�@�C���ւ̃A�N�Z�X�����ۂ���܂����B";
        private const string CT_FILENAMEERROR = "�p�X�ɖ����ȕ������܂܂�Ă��܂��B";
        private const string CT_TXTFILTER_CSV = "CSV(*.CSV)|*.CSV|TXT(*.TXT)|*.TXT|���̑�(*.*)|*.*";
        private const string CT_TXTFILTER_TXT = "TXT(*.TXT)|*.TXT|CSV(*.CSV)|*.CSV|���̑�(*.*)|*.*";

        private const string TXTSTR = ".txt";
        private const string CSVSTR = ".csv";
        #endregion

        #region �q�t�H�[��
        // �q�t�H�[���Ώ�
        ISecurityManagementForm SubForm;

        /// <summary>
        /// �q�t�H�[��
        /// </summary>
        public ISecurityManagementForm GetSubForm
        {
            set { this.SubForm = value; }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �e�L�X�g�o�͊m�F��ʃt�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͊m�F��ʃt�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public PMKHN09122UC()
        {
            InitializeComponent();

            // ��ʂɍ��ڒl���o����
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.tEdit_TextOutpuPath);
            ctrlList.Add(this.tComboEditor_FileFormat);
            this.uiMemInput1.TargetControls = ctrlList;

            // �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();

            // �t�@�C���`��
            this.tComboEditor_FileFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// �R���X�g���N�^�@Nunit�p
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͊m�F��ʃt�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        public PMKHN09122UC(string param)
        {
            try
            {
                if (("NUnit").Equals(param))
                {
                    // ������
                    InitializeComponent();
                }
            }
            catch
            {

            }
        }
        #endregion

        #region ������
        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_FileSelect.ImageList = IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = Size16_Index.STAR1; // �`�F�b�N���X�g�o�͐�K�C�h
        }
        #endregion

        #region Private Method
        /// <summary>
        /// �`�F�b�N���X�g�o�͐�K�C�h�N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        :�`�F�b�N���X�g�o�͐�K�C�h�N���b�N</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = "�o�̓t�@�C���I��";
                saveFileDialog.RestoreDirectory = true;

                try
                {
                    if (string.IsNullOrEmpty(this.tEdit_TextOutpuPath.Text.Trim()))
                    {
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                    else
                    {
                        saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextOutpuPath.Text);
                        saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextOutpuPath.Text);
                    }
                }
                catch
                {
                    // �����Ȃ�
                }
                finally
                {
                    if (string.IsNullOrEmpty(saveFileDialog.InitialDirectory))
                    {
                        saveFileDialog.FileName = string.Empty;
                        saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    }
                }

                //�u�t�@�C���̎�ށv���w��
                if ((Int32)this.tComboEditor_FileFormat.Value == 0)
                {
                    saveFileDialog.Filter = CT_TXTFILTER_CSV;
                }
                else
                {
                    saveFileDialog.Filter = CT_TXTFILTER_TXT;
                }
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextOutpuPath.DataText = saveFileDialog.FileName;
                }
                else
                {
                    // �Ȃ�
                }
            }
            this.uButton_FileSelect.Focus();
        }
        
        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏���</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void uButton_TextOut_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            Control errComponent = null;

            // �t�@�C���`�F�b�N����
            if (!this.FileCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return;
            }

            //�@�g���q�擾
            if (this.tEdit_TextOutpuPath.DataText.Trim().Length > 3)
            {
                // �g���q
                string extension = System.IO.Path.GetExtension(this.tEdit_TextOutpuPath.DataText.Trim().Substring(3)).ToLower();

                // �t�@�C���`���́ucsv�v�ꍇ
                if (this.tComboEditor_FileFormat.SelectedIndex == 0)
                {
                    // �g���q�́ucsv�v�ȊO�̏ꍇ
                    if (!CSVSTR.Equals(extension.ToLower()))
                    {
                        this.tEdit_TextOutpuPath.DataText = this.tEdit_TextOutpuPath.DataText.Trim() + CSVSTR;
                    }
                }
                // �t�@�C���`���́utxt�v�ꍇ
                else
                {
                    // �g���q�́utxt�v�ȊO�̏ꍇ
                    if (!TXTSTR.Equals(extension.ToLower()))
                    {
                        this.tEdit_TextOutpuPath.DataText = this.tEdit_TextOutpuPath.DataText.Trim() + TXTSTR;
                    }
                }
            }

            bool fileCheckFlag;

            int status = (this.SubForm as IDoTextOutForm).DoTextOut(this.tEdit_TextOutpuPath.Text, this.tComboEditor_FileFormat.SelectedIndex, out fileCheckFlag, out errMessage);

            // �t�@�C���r���`�F�b�N
            if (fileCheckFlag)
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                return;
            }

            emErrorLevel errLevel = emErrorLevel.ERR_LEVEL_INFO;
            switch (status)
            {
                // ��������
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    errMessage = "�e�L�X�g�o�͏������I�����܂����B";
                    break;
                // �o�͑Ώۃf�[�^���Ȃ��ꍇ
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    errMessage = "�Y���f�[�^�����݂��܂���B";
                    break;
                // �ُ킪��������ꍇ
                default:
                    errLevel = emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
            }

            // �G���[����������ꍇ
            if (!string.IsNullOrEmpty(errMessage))
            {
                MsgDispProc(errLevel
                            , errMessage
                            , status
                            , MessageBoxButtons.OK
                            , MessageBoxDefaultButton.Button1);
            }

            this.Close();
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�\���������s��</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string message, int status, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel
                                , this.Name
                                , message
                                , status
                                , iButton
                                , iDefButton);
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�\���������s��</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,                             // �G���[���x��
                CT_PGID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                CT_PRINTNAME,                       // �v���O��������
                "",                                 // ��������
                "",                                 // �I�y���[�V����
                message,                            // �\�����郁�b�Z�[�W
                status,                             // �X�e�[�^�X�l
                null,                               // �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK,               // �\������{�^��
                MessageBoxDefaultButton.Button1);   // �����\���{�^��
        }

        /// <summary>
        /// �t�@�C���`�F�b�N�������s��
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�R���g���[��</param>
        /// <remarks>
        /// <br>Note       : �t�@�C���`�F�b�N�������s��</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool FileCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // �K�{���̓`�F�b�N
            // message: �e�L�X�g�t�@�C��������͂��ĉ������B
            if (string.IsNullOrEmpty(this.tEdit_TextOutpuPath.Text.Trim()))
            {
                errMessage = string.Format("�t�@�C����" + "{0}", CT_NOINPUT);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // �o�X���݃`�F�b�N___̧�ّ��݃`�F�b�N
            // message: �w�肳�ꂽ�t�@�C�����͕s���ł��B
            if (this.tEdit_TextOutpuPath.DataText.ToString().Trim().EndsWith("\\"))
            {
                errMessage = string.Format("{0}", CT_FILEEXPENDERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // �t�@�C�����Ɏg�p�֎~�������݃`�F�b�N
            // message: �p�X�ɖ����ȕ������܂܂�Ă��܂��B
            if (this.tEdit_TextOutpuPath.DataText.Trim().Length > 3)
            {
                if (!FileNameCheck(this.tEdit_TextOutpuPath.DataText.Trim().Substring(3)))
                {
                    errMessage = string.Format("{0}", CT_FILENAMEERROR);
                    errComponent = this.tEdit_TextOutpuPath;
                    status = false;
                    return status;
                }
            }

            // �o�X���݃`�F�b�N
            try
            {
                // message: �w�肳�ꂽ�t�H���_�����݂��܂���B
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(this.tEdit_TextOutpuPath.Text.Trim())))
                {
                    errMessage = string.Format("{0}", CT_FILEPATHERROR);
                    errComponent = this.tEdit_TextOutpuPath;
                    status = false;
                    return status;
                }
            }
            catch
            {
                // �w�肳�ꂽ�t�H���_�����݂��܂���B
                errMessage = string.Format("{0}", CT_FILEPATHERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // �t�@�C���r���`�F�b�N
            // message: �w�肳�ꂽ�t�@�C�������Ŏg�p���ł��B
            if (PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 1)
            {
                errMessage = string.Format("{0}", CT_FILEALRDYERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            // message: �o�͐�t�@�C���ւ̃A�N�Z�X�����ۂ���܂����B
            else if (PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 2 || PMKHN09140UA.IsFileLocked(this.tEdit_TextOutpuPath.Text.Trim()) == 3)
            {
                errMessage = string.Format("{0}", CT_FILEACCESSERROR);
                errComponent = this.tEdit_TextOutpuPath;
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// �p�X�ɖ����ȕ����`�F�b�N����                                              
        /// </summary>
        /// <param name="str">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �p�X�ɖ����ȕ����`�F�b�N</br>                  
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private bool FileNameCheck(string str)
        {
            try
            {
                int temp = str.LastIndexOf("\\");
                if (temp == str.Length)
                {
                    return true;
                }

                if (str.Contains("/") || str.Contains(":") || str.Contains("*") || str.Contains("?") ||
                    str.Contains("\"") || str.Contains("<") || str.Contains(">") || str.Contains("|")
                    || str.Contains(";"))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// �ݒ��ʂ̃L�����Z������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̃L�����Z������</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : K2016/10/28</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            // ��ʂ�߂�
            this.Close();
        }
        #endregion
    }
}