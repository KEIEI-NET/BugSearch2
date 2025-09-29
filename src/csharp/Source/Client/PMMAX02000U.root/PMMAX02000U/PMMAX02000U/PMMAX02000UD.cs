//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� �ݒ���
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/16   �C�����e : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ݒ��ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ݒ��ʃN���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public partial class PMMAX02000UD : Form
    {
        #region private
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;
        // �`�F�b�N���X�g�o�͐�
        private const string CHECKL_FILE_PATH = @"CSV";
        // ���ʃN���X
        PMMAX02000UC _pMMAX02000UC;
        // ���[�U�[ID�ƃp�[�X���[�h�ۑ��p
        private DataSet menuDataSet = null;
        // �K�C�h��Icon
        private ImageList _imageList16 = null;
        // �o�ד��t�͈�
        private int _shipDateRange;
        // �`�F�b�N���X�g�o�͐�p�[�X
        private string _outPutPath = string.Empty;
        // �ۑ����邩�ǂ����t���O
        private bool _didSave = false;
        // ���iMAX���O�C��ID
        private string _userID;
        // ���iMAX�p�X���[�h
        private string _userPassWord;

        private string _changeBefOutpuPath = "";// �ύX�O�`�F�b�N���X�g�o�͐� // Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
        // �N���X��
        private const string ct_PRINTNAME = "�o�i�E���ח\��";
        private const string ct_PGID = "PMMAX02000UD";
        #endregion

        #region public
        /// <summary>
        /// �o�ד��t�͈�
        /// </summary>
        public int ShipDateRange
        {
            get { return this._shipDateRange; }
        }

        /// <summary>
        /// ���iMAX���O�C��ID
        /// </summary>
        public string UserID
        {
            get { return _userID; }
        }

        /// <summary>
        /// ���iMAX�p�X���[�h
        /// </summary>
        public string UserPassWord
        {
            get { return _userPassWord; }
        }

        /// <summary>
        /// �`�F�b�N���X�g�o�͐�p�[�X
        /// </summary>
        public string OutPutPath
        {
            get { return this._outPutPath; }
        }
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �ݒ��ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ݒ��ʃN���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UD()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            // ���ʃN���X
            _pMMAX02000UC = new PMMAX02000UC();

            // ��ƃR�[�h
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;
            // ���O�C�����_�R�[�h
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;

            // �{�^���A�C�R���ݒ�
            this.SetGuidButtonIcon();
        }

        /// <summary>
        /// �R���X�g���N�^�@Nunit�p
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UD(string param)
        {
            if (("NUnit").Equals(param))
            {
                // ������
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion

        #region
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void InitialScreenData()
        {
            // �`�F�b�N���X�g�o�͐�Əo�ד��t�͈͂̕\��
            this.CheckFilePathAndShipDateShow();

            // ���[�U�[���̕\��
            this.UserInfoShow();
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UD_Shown(object sender, EventArgs e)
        {
            // ����Focus�̐ݒ�
            this.TtlType_ultraOptionSet.Focus();
        }

        /// <summary>
        /// �`�F�b�N���X�g�o�͐�K�C�h�N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        :�`�F�b�N���X�g�o�͐�K�C�h�N���b�N</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void uButton_FileSelect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.tEdit_ChecklistOutpuPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // �`�F�b�N���X�g�o�͐�K�C�h
            this.uButton_FileSelect.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// ���[�U�[���̕\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[���̕\������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void UserInfoShow()
        {
            // ���[�U�[���
            string userID;
            string userPassWord;
            bool userExistFlag = false;
            // DAT�t�@�C������A���[�U�[�����擾����
            _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            // �Y�����郆�[�U�[��ݒ肵���ꍇ
            if (userExistFlag)
            {
                // DAT�t�@�C���ɂ�ID�ƃp�[�X���[�h���g�p���A�\������
                this.tEdit_LoginID.Text = userID.Trim();
                this.tEdit_Password.Text = userPassWord.Trim();
            }
            // �Y�����郆�[�U�[��ݒ肵�Ȃ��ꍇ
            else
            {
                this.tEdit_LoginID.Text = string.Empty;
                this.tEdit_Password.Text = string.Empty;
            }
        }

        /// <summary>
        /// �`�F�b�N���X�g�o�͐�Əo�ד��t�͈͂̕\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g�o�͐�Əo�ד��t�͈͂̕\������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private void CheckFilePathAndShipDateShow()
        {
            // �ۑ��{�^���[���������ꍇ�A�������[�ɂ̃`�F�b�N���X�g�o�͐���g�p���A��ʂɕ\������
            if (_didSave)
            {
                // �`�F�b�N���X�g�o�͐�
                this.tEdit_ChecklistOutpuPath.Text = this._outPutPath;
                _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
                // �o�ד��t�͈�
                if (this._shipDateRange > 0)
                {
                    this.TtlType_ultraOptionSet.CheckedIndex = this._shipDateRange - 1;
                }
                else
                {
                    this.TtlType_ultraOptionSet.CheckedIndex = 0;
                }
                return;
            }

            // XML�t�@�C����ǂݍ���
            _pMMAX02000UC.Deserialize();
            OutAndInPutUserData exportSalesDataList = _pMMAX02000UC.ExportSalesDataList;
            // �`�F�b�N���X�g�o�͐�
            string checkFilePath = string.Empty;
            int shipDateIndex = 0;
            foreach (OutAndInPutUserSaveItems saveItems in exportSalesDataList.ExportSalesDataList)
            {
                if (saveItems.EnterpriseCode == this._enterpriseCode && saveItems.SectionCode == this._loginSectionCode)
                {
                    // �`�F�b�N���X�g�o�͐�̐ݒ�
                    checkFilePath = saveItems.MoveFileName;
                    shipDateIndex = saveItems.ShipDateInit;
                    break;
                }
            }
            // XML�t�@�C���Ƀ`�F�b�N���X�g�o�͐悪����ꍇ
            if (!string.IsNullOrEmpty(checkFilePath))
            {
                this.tEdit_ChecklistOutpuPath.Text = checkFilePath;
            }
            // XML�t�@�C���Ƀ`�F�b�N���X�g�o�͐悪�Ȃ��ꍇ
            else
            {
                this.tEdit_ChecklistOutpuPath.Text = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.PRTOUT, CHECKL_FILE_PATH));
            }
            _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
            // XML�t�@�C���ɏo�ד��t�͈͂�����ꍇ
            if (!string.IsNullOrEmpty(checkFilePath))
            {
                if (shipDateIndex > 0)
                {
                    this.TtlType_ultraOptionSet.CheckedIndex = shipDateIndex - 1;
                }
                else
                {
                    this.TtlType_ultraOptionSet.CheckedIndex = 0;
                }
            }
            // XML�t�@�C���ɏo�ד��t�͈͂��Ȃ��ꍇ
            else
            {
                this.TtlType_ultraOptionSet.CheckedIndex = 1;
            }
        }

        /// <summary>
        /// �ݒ��ʂ̕ۑ�����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̕ۑ�����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            // ��ʍ��ڂ̃`�F�b�N
            bool checkFlag = MuneItemsCheck(this.tEdit_ChecklistOutpuPath.Text.Trim());
            if (!checkFlag)
            {
                // DAT�t�@�C���̕ۑ�
                this.DatFileSave();
                // �o�ד��t�͈�
                this._shipDateRange = (int)this.TtlType_ultraOptionSet.CheckedItem.DataValue;
                // �`�F�b�N���X�g�o�͐�p�[�X
                this._outPutPath = this.tEdit_ChecklistOutpuPath.Text.Trim();
                _didSave = true;
                // ���iMAX���O�C��ID
                this._userID = this.tEdit_LoginID.Text.Trim();
                // ���iMAX�p�X���[�h
                this._userPassWord = this.tEdit_Password.Text.Trim();
                this.DialogResult = DialogResult.OK;
                // ��ʂ�߂�
                this.Close();
            }
            else
            {
                this.tEdit_ChecklistOutpuPath.Text = _changeBefOutpuPath; // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
                this.tEdit_ChecklistOutpuPath.Focus();
                return;
            }
        }

        /// <summary>
        /// �ݒ��ʂ̃`�F�b�N����
        /// </summary>
        /// <param name="filePath">�`�F�b�N���X�g�o�͐�</param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̃`�F�b�N����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private bool MuneItemsCheck(string filePath)
        {
            // �G���[�t���O
            bool errorFlag = false;

            try
            {
                // �p�[�X�����݂��Ȃ��ꍇ
                // UPD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ---->>>>>
                // if (!Directory.Exists(filePath))
                if (!Directory.Exists(filePath) || !PMMAX02000UD.CheckDirectoryAccess(filePath))
                // UPD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ----<<<<<
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID, ct_PRINTNAME, "", "", MessageInfo.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    errorFlag = true;
                }
            }
            catch
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ct_PGID, ct_PRINTNAME, "", "", MessageInfo.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errorFlag = true;
            }

            return errorFlag;
        }

        // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ---->>>>>
        /// <summary>
        /// �`�F�b�N���X�g�o�͐�ɏ������ތ����`�F�b�N
        /// </summary>
        /// <param name="directory">�`�F�b�N���X�g�o�͐�p�X</param>
        /// <returns>�t���O: true: �������ތ�������   false:�������ތ����Ȃ�</returns>
        /// <remarks>
        /// <br>Note       :  �`�F�b�N���X�g�o�͐�ɏ������ތ����`�F�b�N����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/02/16</br>
        /// </remarks>
        public static bool CheckDirectoryAccess(string directory)
        {
            string tempFile = "\\" + DateTime.Now.Ticks.ToString() + ".tmp";
            bool success = false;
            string fullPath = directory + tempFile;

            if (Directory.Exists(directory))
            {
                try
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.WriteByte(0xff);
                    }

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                        success = true;
                    }
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }
        // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ----<<<<<

        /// <summary>
        /// ���[�U�[���̕ۑ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[���̕ۑ��̕ۑ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void DatFileSave()
        {
            // ���[�U�[���
            string userID;
            string userPassWord;
            bool userExistFlag = false;
            // DAT�t�@�C������A���[�U�[�����擾����
            this.menuDataSet = _pMMAX02000UC.ReadDatFile(PMMAX02000UC.ct_Tbl_Users, this._enterpriseCode, this._loginSectionCode, out userID, out userPassWord, out userExistFlag);
            // ���[�U�[����V�K�o�^����
            if (!userExistFlag)
            {
                // ���[�U�[���ۑ��pDateTable�̍쐬
                _pMMAX02000UC.CreatUserDateTable(ref this.menuDataSet, this.tEdit_LoginID.Text.Trim(), this.tEdit_Password.Text.Trim());
            }
            // ���[�U�[���X�V
            else
            {
                _pMMAX02000UC.ReSetDateTable(ref this.menuDataSet, this.tEdit_LoginID.Text.Trim(), this.tEdit_Password.Text.Trim());
            }
            // ���[�U�[����DAT�t�@�C���ɃZ�b�g����
            _pMMAX02000UC.SetDateToDat(this.menuDataSet);
        }

        /// <summary>
        /// �ݒ��ʂ̃L�����Z������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̃L�����Z������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            // ��ʂ�߂�
            this.Close();
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
                return;

            switch (e.PrevCtrl.Name)
            {
                #region [�o�ד��t�͈�]

                case "TtlType_ultraOptionSet":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // �K�C�h
                                        e.NextCtrl = uButton_Cancel;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [�`�F�b�N���X�g�o�͐�]
                case "tEdit_ChecklistOutpuPath":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // �L�����Z���{�^��
                                        e.NextCtrl = TtlType_ultraOptionSet;
                                    }
                                    break;
                            }
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_ChecklistOutpuPath.Text.Trim()))
                                        {
                                            // �`�F�b�N���X�g�o�͐�K�C�h
                                            e.NextCtrl = uButton_FileSelect;
                                        }
                                        else
                                        {
                                            // ���O�C��ID
                                            e.NextCtrl = tEdit_LoginID;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                case "uButton_FileSelect":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Down:
                                    {
                                        // ���O�C��ID
                                        e.NextCtrl = tEdit_LoginID;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [���O�C��ID]
                case "tEdit_LoginID":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // �K�C�h
                                        e.NextCtrl = uButton_FileSelect;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [�p�X���[�h]
                case "tEdit_Password":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Down:
                                    {
                                        // �ۑ��{�^��
                                        e.NextCtrl = uButton_Save;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [�ۑ��{�^��]
                case "uButton_Save":
                    {
                        if (e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // �p�X���[�h
                                        e.NextCtrl = tEdit_Password;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                #region [�L�����Z���{�^��]
                case "uButton_Cancel":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        // �p�X���[�h
                                        e.NextCtrl = TtlType_ultraOptionSet;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }
        #endregion
    }
}