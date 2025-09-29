//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� ���iMAX�F�ؓ��͉��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/22   �C�����e : Redmine#48629�̏�Q�ꗗNo.242�@�F�؎��s���͑O����͒l���\��������Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���iMAX�F�ؓ��͉�ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���iMAX�F�ؓ��͉�ʃN���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br>UpdateNote : �v�� 2016/02/22</br>
    /// <br>           : Redmine#48629�̏�Q�ꗗNo.242�@�F�؎��s���͑O����͒l���\��������Q�Ή�</br>
    /// </remarks>
    public partial class PMMAX02000UE : Form
    {
        # region
        private PMMAX02000UC _pMMAX02000UC;
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;
        // ���iMAX���O�C��ID
        private string _userID;
        // ���iMAX�p�X���[�h
        private string _userPassWord;
        // �\������
        private string _displayMessage;

        // ���[�U�[ID�ƃp�[�X���[�h�ۑ��p
        private DataSet menuDataSet = null;
        // �N���X��
        private const string ct_PRINTNAME = "���iMAX�F�ؓ��͉��";
        private const string CT_PGID = "PMMAX02000UE";

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
        /// �\������
        /// </summary>
        public string DisplayMessage
        {
            get { return _displayMessage; }
            set { _displayMessage = value; }
        }

        /// <summary>
        /// ���iMAX�F�ؓ��͉�ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���iMAX�F�ؓ��͉�ʃN���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UE()
        {
            InitializeComponent();

            _pMMAX02000UC = new PMMAX02000UC();
            // ��ƃR�[�h
            this._enterpriseCode = _pMMAX02000UC.EnterpriseCode;
            // ���O�C�����_�R�[�h
            this._loginSectionCode = _pMMAX02000UC.LoginSectionCode;
        }

        /// <summary>
        /// �R���X�g���N�^�@Nunit�p
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���iMAX�F�ؓ��͉�ʃN���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UE(string param)
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


        /// <summary>
        /// Form.Load �C�x���g(PMMAX02000UE)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// <br>UpdateNote : �v�� 2016/02/22</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.242�@�F�؎��s���͑O����͒l���\��������Q�Ή�</br>
        /// </remarks>
        private void PMMAX02000UE_Load(object sender, EventArgs e)
        {
            this.ultraLabel_Message.Text = this._displayMessage;
            this.ultraLabel_Message.Appearance.TextVAlignAsString = "Middle";
            // ADD BY �v�� 2016/02/22 FOR Redmine#48629�̏�Q�ꗗNo.242�@�F�؎��s���͑O����͒l���\��������Q�Ή� ---->>>>>
            this.tEdit_LoginId.Text = string.Empty;
            this.tEdit_Password.Text = string.Empty;
            // ADD BY �v�� 2016/02/22 FOR Redmine#48629�̏�Q�ꗗNo.242�@�F�؎��s���͑O����͒l���\��������Q�Ή� ----<<<<<
            this.tEdit_LoginId.Focus();
        }

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
            // ���[�U�[���̕\��
            this.UserInfoShow();
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
                this.tEdit_LoginId.Text = userID.Trim();
                this.tEdit_Password.Text = userPassWord.Trim();
            }
            // �Y�����郆�[�U�[��ݒ肵�Ȃ��ꍇ
            else
            {
                this.tEdit_LoginId.Text = string.Empty;
                this.tEdit_Password.Text = string.Empty;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^��Click �C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            // �ۑ��O�`�F�b�N
            string message = string.Empty;
            Control errControl = null;
            bool canExport = this.BeforeSaveCheck(out message, out errControl);

            if (!canExport)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, ct_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
            }
            else
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
                    _pMMAX02000UC.CreatUserDateTable(ref this.menuDataSet, this.tEdit_LoginId.Text.Trim(), this.tEdit_Password.Text.Trim());

                }
                // ���[�U�[���X�V
                else
                {
                    _pMMAX02000UC.ReSetDateTable(ref this.menuDataSet, this.tEdit_LoginId.Text.Trim(), this.tEdit_Password.Text.Trim());
                }
                // ���[�U�[����DAT�t�@�C���ɃZ�b�g����
                _pMMAX02000UC.SetDateToDat(this.menuDataSet);

                // ���iMAX���O�C��ID
                this._userID = this.tEdit_LoginId.Text.Trim();
                // ���iMAX�p�X���[�h
                this._userPassWord = this.tEdit_Password.Text.Trim();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        /// <summary>
        /// �ۑ��O�Ƀ`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errControl">�G���[�R���g���[��</param>
        /// <returns>�G���[�L���t���O</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�Ƀ`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private bool BeforeSaveCheck(out string errMessage, out Control errControl)
        {
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            if (this.tEdit_LoginId.Text.Trim() == "")
            {
                // ���O�C���h�c
                errMessage = MessageInfo.M_008;
                errControl = this.tEdit_LoginId;
                result = false;
                return result;
            }

            if (this.tEdit_Password.Text.Trim() == "")
            {
                // ���O�C���p�X���[�h
                errMessage = MessageInfo.M_009;
                errControl = this.tEdit_Password;
                result = false;
                return result;
            }
            return result;
        }

        /// <summary>
        /// Cancel_Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���~�{�^��Click �C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ��C�x���g����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                #region [�p�X���[�h]
                case "tEdit_Password":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
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
        # endregion
                default:
                    break;
            }
        }
        # endregion
    }
}