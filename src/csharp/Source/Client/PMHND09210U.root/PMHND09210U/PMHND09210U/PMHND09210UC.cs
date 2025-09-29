//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�o�[�R�[�h�ꊇ�o�^                                  //
// �v���O�����T�v   : ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�o�͊m�FUI�N���X         //
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�o�͊m�FUI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�o�[�R�[�h�ꊇ�o�^ �e�L�X�g�o�͊m�FUI�N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/06/12</br>
    /// </remarks>
    public partial class PMHND09210UC : Form
    {
        # region private field
        /// <summary>���[�U�[�ݒ�</summary>
        private GoodsBarCodeRevnExtractTextUserConst _userSetting;
        #endregion

        #region Const Memebers
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string ct_XML_FILE_NAME = "PMHND09210UC_Construction.XML";
        #endregion

        #region ���[�U�[�ݒ��񕡐�����
        /// <summary>
        /// �e�L�X�g�o�̓��[�U�[�ݒ���N���X��������
        /// </summary>
        /// <returns>�e�L�X�g�o�̓��[�U�[�ݒ���N���X</returns>
        public GoodsBarCodeRevnExtractTextUserConst UserSetting
        {
            get { return this._userSetting; }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UC()
        {
            InitializeComponent();
            // �e�L�X�g�o�̓��[�U�[�ݒ���
            this._userSetting = new GoodsBarCodeRevnExtractTextUserConst();
        }
        #endregion

        #region ���[�U�[�ݒ�̕ۑ��E�ǂݍ���
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
                    this._userSetting = UserSettingController.DeserializeUserSetting<GoodsBarCodeRevnExtractTextUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new GoodsBarCodeRevnExtractTextUserConst();
                }
            }
        }
        #endregion

        #region ��ʃC�x���g
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
        private void PMHND09210UC_Load(object sender, EventArgs e)
        {
            // ���i�o�[�R�[�h�ꊇ�o�^�p���[�U�[�ݒ�f�V���A���C�Y����
            this.Deserialize();
            // ���[�U�[�ݒ��� �� ���
            SetUserSettingToScreen();
        }

        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ�t�h�����\���C�x���g�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UC_Shown(object sender, EventArgs e)
        {
            tEdit_TextFileName.Focus();
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �e�L�X�g
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // �e�L�X�g��  �L�����Z��
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // �L�����Z����  ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �L�����Z��
                        e.NextCtrl = this.uButton_Cancel;
                    }
                    else if (e.PrevCtrl == this.uButton_Cancel)
                    {
                        // �L�����Z����  �e�L�X�g
                        e.NextCtrl = this.uButton_OK;
                    }
                    else if (e.PrevCtrl == this.uButton_OK)
                    {
                        // �e�L�X�g��  ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
        }

        /// <summary>
        /// �t�@�C�����ύX���ꂽ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�@�C�����ύX���ꂽ���������܂��B</br> 
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            // �t�@�C���p�X+�t�@�C����
            this.uLabel_FileFullName.Text = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + this.tEdit_TextFileName.Text.Trim();
        }

        #endregion

        #region �{�^���C�x���g
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// OK�{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : OK�{�^���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            // �`�F�b�N
            if (!TextFileNameCheck())
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            // ��� �� ���[�U�[�ݒ���
            GetUserSettingFromScreen();
            // _userSetting�͏����ς���Ă���̂Őݒ�XML�X�V
            this.Serialize();
            // �I��
            this.Close();
        }
        #endregion // �{�^��

        #region ��ʃC�x���g

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
            // �t�@�C����
            this.tEdit_TextFileName.Text = this._userSetting.OutputFileName;
            // �t�@�C���p�X+�t�@�C����
            this.uLabel_FileFullName.Text = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + this._userSetting.OutputFileName;
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
            // �t�@�C����
            this._userSetting.OutputFileName = this.tEdit_TextFileName.Text.Trim();
            // �t�@�C���p�X
            this._userSetting.OutputFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\");
        }

        /// <summary>
        /// �t�@�C�������͒l�`�F�b�N
        /// </summary>
        /// <returns>true:�`�F�b�NOK false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�������͒l�`�F�b�N�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool TextFileNameCheck()
        {
            string textFileName = this.tEdit_TextFileName.Text.Trim();
            // �t�@�C�������w��
            if (String.IsNullOrEmpty(textFileName))
            {
                // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�o�̓t�@�C�������w�肳��Ă��܂���B", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // �t�@�C��������
            if (textFileName.Contains("/") || textFileName.Contains(":") || textFileName.Contains("*") || textFileName.Contains("?") ||
                textFileName.Contains(@"\") || textFileName.Contains("<") || textFileName.Contains(">") || textFileName.Contains("|")
                || textFileName.Contains(";"))
            {
                // �t�@�C�������w�肳��Ă��Ȃ��ƃG���[
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�o�̓t�@�C�����ɖ����ȕ������܂܂�Ă��܂��B", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // �t���t�@�C����
            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\TEXT\\") + textFileName;

            // �t�@�C�����g�p���`�F�b�N
            if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_LOCKED)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�o�̓t�@�C�������Ŏg�p���ł��B", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            // �t�@�C���̃A�N�Z�X�`�F�b�N
            if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_CANNOTACCESS ||
                IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_EOF)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�o�̓t�@�C���ւ̃A�N�Z�X�����ۂ���܂����B", -1, MessageBoxButtons.OK);
                this.tEdit_TextFileName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// �w�肵���t���t�@�C���͎g�p���邩�ǂ������`�F�b�N���Ă���
        /// </summary>
        /// <param name="fullFileName">�t���t�@�C����</param>
        /// <returns>0:�g�p�ł��� 1:���Ŏg�p�� 2:�A�N�Z�X�ł��Ȃ� 3���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���t���t�@�C���͎g�p���邩�ǂ������`�F�b�N���Ă���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int IsFileLocked(string fullFileName)
        {
            FileStream stream = null;

            // �t�@�C�������݂��Ȃ��ꍇ�A�e�L�X�g�o�͎��ɍ쐬���Ă���
            if (!File.Exists(fullFileName))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                // �t�@�C����Open
                stream = File.Open(fullFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // �t�@�C�������Ŏg�p���ł�
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                // �t�@�C�����A�N�Z�X�ł��Ȃ��B
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                // ���̑��G���[
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;
        }

        #endregion

        #region ���񋓑�
        /// <summary>
        /// �t�@�C���͎g�p�t���O
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�@�C���͎g�p�t���O</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private enum FileLocked_Status
        {
            //�t�@�C���͎g�p�ł���
            FileLocked_NORMAL = 0,
            //�t�@�C�������Ŏg�p���ł�
            FileLocked_LOCKED = 1,
            //�t�@�C�����A�N�Z�X�ł��Ȃ��B
            FileLocked_CANNOTACCESS = 2,
            //���̑��G���[
            FileLocked_EOF = 3,
        }
        #endregion

    }

    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^�p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�ꊇ�o�^�̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnExtractTextUserConst
    {
        #region �v���C�x�[�g�ϐ�
        // �o�̓p�X
        private string _outputFilePath;
        // �o�̓t�@�C����
        private string _outputFileName;
        #endregion

        #region �v���p�e�B
        /// <summary>�o�̓p�X</summary>
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        /// <summary>�o�̓t�@�C����</summary>
        public string OutputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }
        #endregion
    }
}