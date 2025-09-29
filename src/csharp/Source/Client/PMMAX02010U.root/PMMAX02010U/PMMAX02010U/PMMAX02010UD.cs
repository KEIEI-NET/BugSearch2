//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O�����T�v   : �o�i�ꊇ�X�V �ݒ���
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/01/22   �C�����e : �V�K�쐬
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
    public partial class PMMAX02010UD : Form
    {
        #region private Member
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;

        // ���ʃN���X
        PMMAX02000UC _pMMAX02000UC;
        PMMAX02010UC _pMMAX02010UC;
        // ���[�U�[ID�ƃp�[�X���[�h�ۑ��p
        private DataSet menuDataSet = null;
        // �K�C�h��Icon
        private ImageList _imageList16 = null;
        // �`�F�b�N���X�g�o�͐�p�[�X
        private string _outPutPath = string.Empty;
        // �ۑ����邩�ǂ����t���O
        private bool _didSave = false;

        private string _changeBefOutpuPath = "";// �ύX�O�`�F�b�N���X�g�o�͐� // Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
        #endregion

        #region CONST
        // �N���X��
        private const string ct_PRINTNAME = "�o�i�ꊇ�X�V";
        private const string CT_PGID = "PMMAX02010UD";
        /// <summary>
        /// �`�F�b�N���X�g�o�͐�
        /// </summary>
        public const string CHECKL_FILE_PATH = @"CSV\";
        #endregion

        #region Public Property
        /// <summary>
        /// �`�F�b�N���X�g�o�͐�p�[�X
        /// </summary>
        public string OutPutPath
        {
            get { return this._outPutPath; }
        }
        #endregion Public Property

        #region �R���X�g���N�^
        /// <summary>
        /// �ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UD()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            // ���ʃN���X
            _pMMAX02000UC = new PMMAX02000UC();
            _pMMAX02010UC = new PMMAX02010UC();

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
        /// <br>Note       : �o�i�E�݌Ɉꊇ�X�V�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public PMMAX02010UD(string param)
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

        #region Public Method
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������s���B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void InitialScreenData()
        {
            this.tEdit_ChecklistOutpuPath.Focus();

            // �`�F�b�N���X�g�o�͐�̕\������
            this.CheckFilePathShow();
            // ���[�U�[���̕\������
            this.UserInfoShow();
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
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
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
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.uButton_FileSelect.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1]; // �`�F�b�N���X�g�o�͐�K�C�h
        }
        
        /// <summary>
        /// �`�F�b�N���X�g�o�͐�̕\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g�o�͐�̕\������</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private void CheckFilePathShow()
        {
            // �ۑ��{�^���[���������ꍇ�A�������[�ɂ̃`�F�b�N���X�g�o�͐�Əo�ד��t�͈͂��g�p���A��ʂɕ\������
            if (_didSave)
            {
                // �`�F�b�N���X�g�o�͐�
                this.tEdit_ChecklistOutpuPath.Text = this._outPutPath;
                _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
                return;
            }
            // XML�t�@�C����ǂݍ���
            _pMMAX02010UC.Deserialize();
            ExportSalesData exportSalesDataList = _pMMAX02010UC.ExportSalesDataList;
            // �`�F�b�N���X�g�o�͐�
            string checkFilePath = string.Empty;
            foreach (ExportSalesFormSaveItems saveItems in exportSalesDataList.ExportSalesDataList)
            {
                if (saveItems.EnterPriseCode == this._enterpriseCode && saveItems.LoginSectionCode == this._loginSectionCode)
                {
                    // �`�F�b�N���X�g�o�͐�̐ݒ�
                    checkFilePath = saveItems.CheckFilePath;
                    break;
                }
            }
            // XML�t�@�C���Ƀ��[�U�[��񂪂���ꍇ
            if (!string.IsNullOrEmpty(checkFilePath))
            {
                this.tEdit_ChecklistOutpuPath.Text = checkFilePath;
            }
            // XML�t�@�C���Ƀ��[�U�[��񂪂Ȃ��ꍇ
            else
            {
                this.tEdit_ChecklistOutpuPath.Text = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.PRTOUT, CHECKL_FILE_PATH));
            }

            _changeBefOutpuPath = this.tEdit_ChecklistOutpuPath.Text; // ADD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�
        }

        /// <summary>
        /// ���[�U�[���̕\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[���̕\������</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
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
        /// �ݒ��ʂ̕ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̕ۑ�����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            // ��ʍ��ڂ̃`�F�b�N
            bool checkFlag = MuneItemsCheck(this.tEdit_ChecklistOutpuPath.Text.Trim());
            // �`�F�b�N���X�g�ۑ���͑��݂��Ȃ����A�����݌������Ȃ��ꍇ
            if (!checkFlag)
            {
                // DAT�t�@�C���̕ۑ�(���O�C��ID�ƃp�X���[�h)
                this.DatFileSave();

                // �`�F�b�N���X�g�o�͐�p�[�X
                this._outPutPath = this.tEdit_ChecklistOutpuPath.Text.Trim();
                _didSave = true;

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
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̃`�F�b�N����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>UpdateNote : �v�� 2016/02/16</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή�</br>
        /// </remarks>
        private bool MuneItemsCheck(string filePath)
        {
            bool errorFlag = false;

            try
            {
                // �p�[�X�����݂��Ȃ��ꍇ
                // UPD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ---->>>>>
                // if (!Directory.Exists(filePath)) 
                if (!Directory.Exists(filePath) || !PMMAX02010UD.CheckDirectoryAccess(filePath))
                // UPD BY �v�� 2016/02/16 FOR Redmine#48629�̏�Q�ꗗNo.16�@�`�F�b�N���X�g�o�͐�ɏ������ݕs��Q�Ή� ----<<<<<
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", PMMAX02010UE.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    errorFlag = true;
                }
            }
            catch
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", PMMAX02010UE.M_007, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
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
            _pMMAX02000UC.SetDateToDat(this.menuDataSet);
        }

        /// <summary>
        /// �ݒ��ʂ̃L�����Z������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �ݒ��ʂ̃L�����Z������</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
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
                                        e.NextCtrl = uButton_Cancel;
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
                                        e.NextCtrl = tEdit_ChecklistOutpuPath;
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