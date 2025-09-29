//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   :�M�z�����ԏ���ʊJ���e�L�X�g���o                       //
// �v���O�����T�v   :�M�z�����ԏ���ʊJ���e�L�X�g���o�m�F�t�h�N���X         //
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11000606-00  �쐬�S�� : licb                                     //
// �� �� ��  K2014/03/10  �C�����e : �V�K�쐬                                 //
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;     
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;

using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �e�L�X�g�o�͊m�F�t�h�N���X
    /// </summary>
    /// <br>Note       : �e�L�X�g�o�͎��Ƀt�@�C�����E�o�̓^�C�v��I������ׂ̂t�h�ł��B</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    /// <br></br>
    public partial class MAZAI02110UB : Form
    {
        
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAZAI02110UB()
        {
            InitializeComponent();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        #endregion

        #region Public Member

        /// <summary>
        /// �o�̓t�@�C���p�X
        /// </summary>
        public string _outPutFileName = string.Empty;

        #endregion 

        #region  Private Member

        // �N���XID
        private const string ct_ClassID = "MAZAI02110UB";
        // �v���O��������
        private const string ct_PGNAME = "�e�L�X�g�o��";
        // ���b�Z�[�W���e
        private const string ct_NOINPUT = "�������͂ł��B";
        private const string ct_FileAlrdyError = "�o�͐�t�@�C�������Ŏg�p���ł��B";
        private const string ct_FilePathError = "�w�肳�ꂽ�t�H���_�����݂��܂���B";
        private const string ct_FileExpendError = "�w�肳�ꂽ�t�@�C�����͕s���ł��B";
        private const string ct_INPUT_ERROR = "�̓��͂��s���ł��B";
        private const string CT_FileNameError = "�w�肳�ꂽ�t�@�C�����͕s���ł��B";
        private const string ct_FILEACCESSERROR = "�o�͐�t�@�C���ւ̃A�N�Z�X�����ۂ���܂����B";
        // �t�@�C���h��
        private const string ct_TxtFilter = "CSV(*.CSV)|*.CSV|�e�L�X�g(*.TXT)|*.TXT|���̑�(*.*)|*.*";

        #endregion

        #region �C�x���g

        /// <summary>
        /// ��ʋN��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UB_Load( object sender, EventArgs e )
        {  
            // �{�^���ݒ�
            this.uButton_FileSelect.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uButton_FileSelect.Appearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;
        }
   
        /// <summary>
        /// �ݒ�t�h�����\���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU04004UA_Show( object sender, EventArgs e )
        {  
            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.OptionCode = "3";
            this.uiMemInput1.ReadMemInput();

            tEdit_SettingFileName.Focus();
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�J�X�𐧌�</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            if (!e.ShiftKey)
            {
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    if (e.NextCtrl == uButton_FileSelect)
                    {
                        e.NextCtrl = uButton_OK;
                    }
                }
            }
            else
            {
                if (e.PrevCtrl == uButton_OK)
                {
                    if (e.NextCtrl == uButton_FileSelect)
                    {
                        e.NextCtrl = tEdit_SettingFileName;
                    }
                }
            }
        }
        /// <summary>
        /// �t�h���͕ۑ��R���|�[�l���g�̕ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �t�h���͕ۑ��R���|�[�l���g�̕ۑ��������s���B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        public void WriteMemInput()
        {
            this.uiMemInput1.WriteMemInput();
        }
        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();
            saveCtrAry.Add(this.tEdit_SettingFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
            this.uiMemInput1.WriteOnClose = false;
        }
        #endregion

       
        #endregion 

        #region �{�^��

        /// <summary>
        /// �L�����Z���{�^��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note	   : �L�����Z���{�^��</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
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
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : OK�{�^��</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            string errMessage = "";
            Control errComponent = null;
            //�o�͑O�Ƀ`�F�b�N�������s��
            if (this.ExportCheck(ref errMessage, ref errComponent))
            {

                //�t�@�C�����݃`�F�b�N
                if (File.Exists(this.tEdit_SettingFileName.Text.Trim()))
                {
                    string strMessage = "���݂̃t�@�C���͔j������܂��B��낵���ł����H";

                    DialogResult dialogResult;
                    // ���b�Z�[�W��\��
                    dialogResult = TMsgDisp.Show(
                     emErrorLevel.ERR_LEVEL_QUESTION, 	// �G���[���x��
                     ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                     ct_PGNAME,					    // �v���O��������
                     "", 								// ��������
                     "",									// �I�y���[�V����
                     strMessage,							// �\�����郁�b�Z�[�W
                     0, 							// �X�e�[�^�X�l
                     null, 								// �G���[�����������I�u�W�F�N�g
                     MessageBoxButtons.OKCancel, 				// �\������{�^��
                     MessageBoxDefaultButton.Button1);	// �����\���{�^��  

                    if (dialogResult == DialogResult.Cancel)
                    {
                        this.tEdit_SettingFileName.Focus();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;

                        _outPutFileName = this.tEdit_SettingFileName.Text.ToString();

                        // �I��
                        this.Close();
                    }

                }
                else
                {

                    this.DialogResult = DialogResult.OK;

                    _outPutFileName = this.tEdit_SettingFileName.Text.ToString();

                    // �I��
                    this.Close();
                }
            }
            else
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }
            }
 
        }

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // �����t�H�[�J�X�Z�b�g
            this.tEdit_SettingFileName.Focus();

        }
        #endregion �� ��ʏ���������

        /// <summary>
        /// �O��̕\����ԗp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �O��̕\����ԗp</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MAZAI02110UB_VisibleChanged(object sender, EventArgs e)
        {
            // �R���g���[��������
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
        }
        /// <summary>
        /// �t�@�C���_�C�A���O�\��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : ���̓t�@�C�����{�^�����N���b�N�������ɔ������܂�</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    UltraButton btn = sender as UltraButton;
                    // �^�C�g���o�[�̕�����
                    openFileDialog.RestoreDirectory = true;
                    string fileNm = string.Empty;

                    openFileDialog.Title = "�o�̓t�@�C�����J��";
                    openFileDialog.CheckFileExists = false;
                    // ÷��̧�ٖ�
                    fileNm = this.tEdit_SettingFileName.Text.Trim();
                    //�u�t�@�C���̎�ށv���w��
                    openFileDialog.Filter = ct_TxtFilter;
                    try
                    {
                        if (string.IsNullOrEmpty(fileNm))
                        {
                            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                            openFileDialog.FileName = System.IO.Path.GetFileName(fileNm);
                        }
                        else
                        {
                            openFileDialog.FileName = System.IO.Path.GetFileName(fileNm);
                            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(fileNm);
                        }

                        // �I�������t�@�C��������ʂɐݒ肵�Ă���
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                         this.tEdit_SettingFileName.Text = openFileDialog.FileName;

                         _outPutFileName = this.tEdit_SettingFileName.Text;

                        }
                    }
                    catch
                    {
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            this.tEdit_SettingFileName.Text = openFileDialog.FileName;

                            _outPutFileName = this.tEdit_SettingFileName.Text;
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion // �{�^��

        #region �o�͑O�Ƀ`�F�b�N���s��
        /// <summary>
        /// ���o�O�m�F����
        /// </summary>
        /// <param name="errComponent">�G���[���b�Z�[�W</param>
        /// <param name="errMessage">�G���[�����R���|�[�l���g</param>
        /// <returns>0:�G���[�Ȃ�</returns>
        /// <remarks>
        /// <br>Note	   : ���o�O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private bool ExportCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // �o�̓t�@�C���� 
            if (string.IsNullOrEmpty(tEdit_SettingFileName.Text.Trim()))
            {
                errMessage = "�o�̓t�@�C����" + ct_NOINPUT;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // �o�̓t�@�C�����Ɏg�p�֎~�������݂̏ꍇ
            if (this.tEdit_SettingFileName.DataText.Trim().Length > 3)
            {
                if (!FileNameCheck(this.tEdit_SettingFileName.DataText.Trim().Substring(3)))
                {
                    errMessage = string.Format("{0}", CT_FileNameError);
                    errComponent = this.tEdit_SettingFileName;
                    status = false;
                    return status;
                }
            }

            // �p�X���݃`�F�b�N
            try
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(this.tEdit_SettingFileName.Text.Trim())))
                {
                    errMessage = ct_FilePathError;
                    errComponent = this.tEdit_SettingFileName;
                    status = false;
                    return status;
                }
            }
            catch
            {
                errMessage = string.Format("{0}", ct_FilePathError);
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // �o�̓t�@�C���� ̧�ّ��݃`�F�b�N
            if (this.tEdit_SettingFileName.DataText.ToString().Trim().EndsWith("\\") || (!IsFileNameRight(this.tEdit_SettingFileName.DataText.ToString().Trim())))
            {
                errMessage = string.Format("{0}", ct_FileExpendError);
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            // �t�@�C���r���`�F�b�N ÷��̧�ٖ�
            if (IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 1)
            {
                errMessage = ct_FileAlrdyError;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }
            else if (IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 2 || IsFileLocked(this.tEdit_SettingFileName.Text.Trim()) == 3)
            {
                errMessage = ct_FILEACCESSERROR;
                errComponent = this.tEdit_SettingFileName;
                status = false;
                return status;
            }

            return status;

        }

        /// <summary>
        /// �g���q���ݒ���`�F�b�N���Ă���
        /// </summary>
        /// <param name="fileName">�t�@�C������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �g���q���ݒ���`�F�b�N���Ă���</br>
        /// <br>Programmer : licb</br>
        /// <br>Date	   : K2014/03/10</br>
        /// </remarks>
        private bool IsFileNameRight(string fileName)
        {
            if (fileName.Length > 0)
            {
                int index = fileName.LastIndexOf("\\");
                string strName = fileName.Substring(index, fileName.Length - index);
                int pointIndex = -1;
                if (strName.Length > 0)
                {
                    pointIndex = strName.IndexOf(".");
                }
                if (pointIndex != -1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
 
        }

        /// <summary>
        /// �w�肵���t�@�C���͎g�p���邩�ǂ������`�F�b�N���Ă���
        /// </summary>
        /// <param name="fileNm">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �w��t�@�C���͎g�p�����Ă��邩�ǂ������`�F�b�N���Ă���</br>
        /// <br>Programmer : licb</br>
        /// <br>Date	   : K2014/03/10</br>
        /// </remarks>
        private int IsFileLocked(string fileNm)
        {
            FileStream stream = null;

            // ̧�ق����݂��Ȃ��ꍇ�A÷�ďo�͎��ɍ쐬���Ă���
            if (!File.Exists(fileNm))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                stream = File.Open(fileNm, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;

        }
        /// <summary>
        /// �t�@�C���͎g�p�t���O
        /// </summary>
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

        /// <summary>
        /// �p�X�ɖ����ȕ����`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �p�X�ɖ����ȕ����`�F�b�N</br>                  
        /// <br>Programmer  : licb</br>                                    
        /// <br>Date        : K2014/03/10</br> 
        /// </remarks>
        private bool FileNameCheck(string str)
        {
            int temp = str.LastIndexOf("\\");
            if (temp == str.Length)
            {
                return true;
            }
            string strtemp = str.Substring(temp + 1);
            if (strtemp.LastIndexOf(".") != strtemp.IndexOf("."))
            {
                return false;
            }
            if (str.Contains("/") || str.Contains(":") || str.Contains("*") || str.Contains("?") || str.Contains("\"") || str.Contains("<") || str.Contains(">") || str.Contains("|")
                || str.Contains(";"))
            {
                return false;
            }
            int tempNo = 0;
            // �g���q
            string extension = System.IO.Path.GetExtension(str).ToLower();
            // �g���q�́utxt�v�ꍇ
            if (string.IsNullOrEmpty(extension))
            {
                tempNo = str.LastIndexOf("\\");
                str = str.Substring(tempNo + 1);
                if (str.Equals(".") || str.Equals(".."))
                {
                    return false;
                }

            }
            return true;
        }


        #endregion

        #region  �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
                TMsgDisp.Show(
                      iLevel, 							// �G���[���x��
                      ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                      ct_PGNAME,					    // �v���O��������
                      "", 								// ��������
                      "",									// �I�y���[�V����
                      message,							// �\�����郁�b�Z�[�W
                      status, 							// �X�e�[�^�X�l
                      null, 								// �G���[�����������I�u�W�F�N�g
                      MessageBoxButtons.OK, 				// �\������{�^��
                      MessageBoxDefaultButton.Button1);	// �����\���{�^��  
        }
        #endregion  �G���[���b�Z�[�W�\������

    }
}