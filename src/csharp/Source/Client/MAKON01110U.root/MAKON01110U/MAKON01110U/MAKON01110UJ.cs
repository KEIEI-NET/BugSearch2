using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using Broadleaf.Library.Resources;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �d���f�[�^�捞�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2020/06/22 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 ���M�ԗ��T�[�r�X(�d���f�[�^�e�L�X�g����)</br>
    /// <br></br>
    /// </remarks>
    public partial class MAKON01110UJ : Form
    {
        // �A�N�Z�X�N���X
        private StockSlipInputAcs StockSlipInputDataAcs;
        // �N���XID
        private const string CtClassID = "MAKON01110UJA";
        // �N���X��
        private string CtPrintName = "�f�[�^�捞";
        // �C���[�W���X�g
        private ImageList ImageList16 = null;
        // �t�@�C�����̐��m���`�F�b�N
        private char[] FileCharArr = new char[10] { '\\', '/', ':', ';', '*', '?', '"', '<', '>', '|' };

        #region �G���[���b�Z�[�W
        private const string CtFileNotInput = "�捞���t�@�C�����w�肵�Ă��������B";
        private const string CtFilePathError = "�w�肳�ꂽ�t�H���_�����݂��܂���B";
        private const string CtFileAccessError = "�捞���t�@�C���ւ̃A�N�Z�X�����ۂ���܂����B";
        private const string CtFileAlrdyError = "�w�肳�ꂽ�t�@�C�������Ŏg�p���ł��B";
        private const string CtFileExpendError = "�t�@�C�������s���ł��B";
        private const string CtFileNameError = "�w�肳�ꂽ�t�@�C�������݂��܂���B";
        private const string CtErrMsg = "�捞�Ɏ��s���܂����B";
        private const string CtCaptureFail = "�捞�Ɏ��s�����f�[�^������܂��B" + "\n" + "\n" + "�G���[�t�@�C�����m�F���Ă��������B";
        private const string CtCaptureSuccess = "�捞���������܂����B";
        #endregion

        #region ���񋓑�
        /// <summary>
        /// �t�@�C���͎g�p�t���O
        /// </summary>
        private enum FileLocked_Status
        {
            //�t�@�C���͎g�p�ł���
            FileLocked_NORMAL = 0,
            //�t�@�C�������Ŏg�p���ł�
            FileLocked_LOCKED = 1,
            // �t�@�C�����A�N�Z�X�ł��Ȃ��B
            FileLocked_CANNOTACCESS = 2,
            // ���̑��G���[
            FileLocked_EOF = 3,
        }
        #endregion
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="fileName">�捞�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        public MAKON01110UJ()
        {
            InitializeComponent();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();
            this.ImageList16 = IconResourceManagement.ImageList16;
            this.ButtonInitialSetting();

            // �A�N�Z�X�N���X����
            this.StockSlipInputDataAcs = StockSlipInputAcs.GetInstance();

            // �����t�H�[�J�X�ݒ�
            this.tEdit_FolderName.Select(0, 0);

            // ����������
            this.CountClear();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// �{�^������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.ultraButton_FolderName.ImageList = this.ImageList16;
            this.ultraButton_FolderName.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �m��{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            string exErrMsg = string.Empty;
            // �G���[�f�[�^�t�@�C���p�X
            string errListPath = string.Empty;
            // �Ǎ�����
            int readNum = 0;
            // �G���[����
            int errorNum = 0;
            // �捞�t�@�C����
            string stockFileName = this.tEdit_FolderName.Text.Trim();

            // �t�@�C���`�F�b�N
            string fileCheckError = FileCheck(stockFileName);

            // �t�@�C���`�F�b�NNG�̏ꍇ
            if (fileCheckError != string.Empty)
            {
                TMsgDisp.Show(
                 this,
                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                 this.Name,
                 fileCheckError,
                 status,
                 MessageBoxButtons.OK);
                this.tEdit_FolderName.Focus();

                // ��ʌ����N���A
                CountClear();
            }
            // �t�@�C���`�F�b�NOK�̏ꍇ
            else
            {
                // ��ʌ����N���A
                CountClear();

                // �捞�ݏ���
                status = this.StockSlipInputDataAcs.SearchStockData(stockFileName, out errorNum, out readNum, out errListPath, out errMsg, out exErrMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    this.tEdit_FolderName.Focus();
                    // ��ʌ����N���A
                    CountClear();

                    // ��O����������ꍇ
                    if (!string.IsNullOrEmpty(exErrMsg))
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, CtErrMsg, 0);
                    }
                    // �`�F�b�N�G���[����������ꍇ
                    else
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                    }
                }
                else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {
                    this.tEdit_FolderName.Focus();
                    // ��ʌ����N���A
                    CountClear();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    this.tEdit_FolderName.Focus();
                    // ��ʌ����N���A
                    CountClear();
                    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);
                }
                else
                {
                    // �捞����
                    this.readCount.Text = string.Format("{0:###,##0}", readNum) + " ��";
                    // �G���[����
                    this.errorCount.Text = string.Format("{0:###,##0}", errorNum) + " ��";
                    // �`�F�b�NNG�̃f�[�^�����邪�A�d����ʂɓW�J�ł���f�[�^������ꍇ
                    if (errorNum != 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(CtCaptureFail + "\n" + "{0}", errListPath), 0);
                    }
                    // �`�F�b�NNG�̃f�[�^���Ȃ��ŁA�d����ʂɓW�J�ł���f�[�^������ꍇ
                    else if (readNum != 0 && errorNum == 0)
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, CtCaptureSuccess, 0);
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }

            this.uiMemInput1.WriteMemInput();
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,                             // �G���[���x��
                CtClassID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                CtPrintName,                       // �v���O��������
                "",                                 // ��������
                "",                                 // �I�y���[�V����
                message,                            // �\�����郁�b�Z�[�W
                status,                             // �X�e�[�^�X�l
                null,                               // �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK,               // �\������{�^��
                MessageBoxDefaultButton.Button1);   // �����\���{�^��
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �G���^�[�܂��̓^�u�L�[����������ꍇ
            if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
            {
                switch (e.PrevCtrl.Name)
                {
                    // �捞�t�@�C�����w��̏ꍇ�A�f�[�^�捞�{�^���Ƀt�H�[�J�X�ړ�����
                    case "tEdit_FolderName":
                        {
                            if (!string.IsNullOrEmpty(this.tEdit_FolderName.Text))
                            {
                                e.NextCtrl = this.uButton_Save;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ��ʌ����N���A
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʌ����N���A</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void CountClear()
        {
            // �Ǎ�����
            this.readCount.Text = " 0 ��";
            // �G���[����
            this.errorCount.Text = " 0 ��";
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : ���̓t�@�C�����{�^�����N���b�N�������ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2020/06/22</br>
        /// <br></br>
        /// </remarks>
        private void ultraButton_FolderName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �t�@�C���I���_�C�A���O
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;

                // �g���q
                dialog.Filter = "�e�L�X�g�t�@�C��|*.txt;*.csv";

                // �m��̏ꍇ
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.tEdit_FolderName.Text = dialog.FileName;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �t�@�C���`�F�b�N
        /// </summary>
        /// <param name="folderName">�t�H���_����</param>
        /// <returns>error���b�Z�[�W</returns>
        /// <remarks>
        /// <br>Note       : �w��t�H���_�ɑΏۃt�@�C�������݃`�F�b�N</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private string FileCheck(string stockFileName)
        {
            string errorMsg = string.Empty;

            int stockFileNameStatus = 0;
            // �捞���t�@�C�����w��`�F�b�N
            if (string.IsNullOrEmpty(stockFileName)) return CtFileNotInput;

            // �t�@�C�����������͂̏ꍇ
            // �o�X���݃`�F�b�N_�t�@�C�����݃`�F�b�N
            if (stockFileName.EndsWith("\\"))
            {
                return CtFileExpendError;
            }

            // �t�@�C�����Ɏg�p�֎~�������݂̏ꍇ
            bool fileNameErrFlg = true;
            string str = stockFileName.Substring(stockFileName.LastIndexOf("\\") + 1);
            int suffixIndex = str.LastIndexOf(".");
            if (suffixIndex > 0 && !str.Substring(0, 1).Equals(" "))
            {
                if (CheckFileStr(str))
                {
                    fileNameErrFlg = false;
                }
            }
            else
            {
                fileNameErrFlg = false;
            }
            if (!fileNameErrFlg)
            {
                return CtFileExpendError;
            }

            // �w�肳�ꂽ�t�H���_�����݃`�F�b�N
            string folderName = System.IO.Path.GetDirectoryName(stockFileName);
            if (!Directory.Exists(folderName)) return CtFilePathError;

            // �w�肳�ꂽ�t�@�C�������݃`�F�b�N
            if (!File.Exists(stockFileName)) return CtFileNameError;

            // �t�@�C���r���`�F�b�N
            stockFileNameStatus = IsFileLocked(stockFileName);
            if (stockFileNameStatus == 2 || stockFileNameStatus == 3)
            {
                return CtFileAccessError;
            }
            else if (stockFileNameStatus == 1)
            {
                return CtFileAlrdyError;
            }
            return errorMsg;
        }


        /// �t�@�C�����̐��m���`�F�b�N
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �t�@�C�����̐��m���`�F�b�N�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private bool CheckFileStr(string fileName)
        {
            bool errFlg = false;
            List<char> fileCharList = new List<char>(FileCharArr);

            foreach (char c in fileName)
            {
                if (fileCharList.Contains(c))
                {
                    errFlg = true;
                    break;
                }
            }

            return errFlg;
        }

        /// <summary>
        /// �w�肵���t�@�C���͎g�p���邩�ǂ������`�F�b�N���Ă���
        /// </summary>
        /// <param name="fileNm">�t�@�C����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���t�@�C���͎g�p���邩�ǂ������`�F�b�N���Ă���</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
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
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();
            // �捞�t�@�C����
            saveCtrAry.Add(this.tEdit_FolderName);

            this.uiMemInput1.TargetControls = saveCtrAry;
        }

        /// <summary>
        /// MAKON01110UJ_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/06/22</br>
        /// </remarks>
        private void MAKON01110UJ_Load(object sender, EventArgs e)
        {
            this.uiMemInput1.ReadMemInput();
        }
        #endregion

    }
}