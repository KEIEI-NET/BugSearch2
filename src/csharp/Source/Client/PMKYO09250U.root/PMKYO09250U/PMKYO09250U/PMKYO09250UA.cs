//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ڑ���ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ڑ���ݒ�}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>���_�Ǘ��ڑ���ݒ�t�H�[���N���X</summary>
    /// <remarks> 
    /// <br>note			:	���_�Ǘ��ڑ���ݒ�t�H�[���N���X�ł��B
    ///							IMasterMaintenanceSingleType���������Ă��܂��B</br>              
    /// <br>Programer		:	�����</br>                            
    /// <br>Date			:	2009.04.21</br>
    /// <br></br>
    /// <br>UpdateNote      :   2009.04.21  ����� �V�K</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKYO09250UA : Form, IMasterMaintenanceSingleType
    {
        # region Constructor
        /// <summary>PMKYO09250UA�R���X�g���N�^</summary>
        /// <remarks> 
        /// <br>note        :	�ڑ���ݒ�A�N�Z�X�N���X�𐶐����܂��B
        ///						�t���[����ʂ̈���{�^����\���ݒ���s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>                              
        /// </remarks>
        public PMKYO09250UA()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secMngConnectStAcs = new SecMngConnectStAcs();

            // ����\�t���O��ݒ肵�܂��B
            // Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
            _canPrint = false;
        }
        # endregion

        # region Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>
        /// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
        /// </remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #region Private Members
        private string _enterpriseCode;
        private SecMngConnectSt _secMngConnectSt;
        private SecMngConnectStAcs _secMngConnectStAcs;

        //��r�pclone
        private SecMngConnectSt _secMngConnectStClone;

        // �v���p�e�B�p
        private bool _canPrint;
        /// <summary>�I���v���p�e�B</summary>
        /// <remarks>
        /// �A�Z���u�����I�����邩�A���Ȃ������擾���̓Z�b�g���܂��B
        /// </remarks>
        private bool _canClose;

        // ���C���t���[���O���b�h�p�\�����ڃ^�C�g��
        private const string HTML_HEADER_TITLE = "�ݒ荀��";
        private const string HTML_HEADER_VALUE = "�ݒ�l";
        private const string HTML_UNREGISTER = "���ݒ�";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        private const string CONNECTPOINTDIV_1 = "�f�[�^�Z���^�[";
        private const string CONNECTPOINTDIV_2 = "�W�v�@";

        private const string MARK_DOT = ".";
        # endregion

        # region Properties
        /// <summary>����v���p�e�B</summary>
        /// <remarks>
        /// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>��ʃN���[�Y�v���p�e�B</summary>
        /// <remarks>
        /// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
        /// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        # endregion

        # region Public Methods
        /// <summary>�������</summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		:	�i�������j</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }

        /// <summary>HTML�R�[�h�擾����</summary>
        /// <returns>HTML�R�[�h</returns>
        /// <remarks>
        /// <br>Note		:	�r���[�p�̂g�s�l�k�R�[�h���擾���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        public string GetHtmlCode()
        {
            string outCode = "";

            // tHtmlGenerate���i�̈����𐶐�����
            string[,] array = new string[4, 2];

            this.tHtmlGenerate1.Coltypes = new int[2];

            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            array[0, 0] = HTML_HEADER_TITLE; //�u�ݒ荀�ځv
            array[0, 1] = HTML_HEADER_VALUE; //�u�ݒ�l�v

            array[1, 0] = this.uLable_ConnectPointDivTitle.Text;    //�ڑ���
            array[2, 0] = this.uLable_ApServerIpAddressTitle.Text;    //�A�v���P�[�V�����T�[�o�[
            array[3, 0] = this.uLabel_DbServerIpAddressTitle.Text;    //�f�[�^�x�[�X

            // ���W�ԍ��擾
            int status = this._secMngConnectStAcs.Search(out this._secMngConnectSt, this._enterpriseCode);

            // ����ꍇ
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �ڑ���
                if (this._secMngConnectSt.ConnectPointDiv == 0)
                {
                    array[1, 1] = CONNECTPOINTDIV_1;
                }
                else
                {
                    array[1, 1] = CONNECTPOINTDIV_2;
                }

                if (this._secMngConnectSt.ApServerIpAddress == string.Empty)
                {
                    array[2, 1] = HTML_UNREGISTER;
                }
                else
                {
                    // �A�v���P�[�V�����T�[�o�[
                    array[2, 1] = this._secMngConnectSt.ApServerIpAddress;
                }

                if (this._secMngConnectSt.DbServerIpAddress == string.Empty)
                {
                    array[3, 1] = HTML_UNREGISTER;
                }
                else
                {
                    // �f�[�^�x�[�X
                    array[3, 1] = this._secMngConnectSt.DbServerIpAddress;
                }
            }
            else
            {
                array[1, 1] = CONNECTPOINTDIV_1;
                array[2, 1] = HTML_UNREGISTER;
                array[3, 1] = HTML_UNREGISTER;
            }
            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);
            return outCode;
        }

        # endregion

        # region Control Events
        /// <summary>Form.Load �C�x���g(PMKYO09250UA)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        private void PMKYO09250UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ菈��
            ScreenInitialSetting();

            this.tComboEditor_ConnectPointDiv.Focus();
        }

        /// <summary>Control.Click �C�x���g(Save_Button)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	�ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
        ///							�������܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // �I�t���C����ԃ`�F�b�N
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "��ʕۑ������Ɏ��s���܂����B",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            SaveProc();
        }

        /// <summary>Control.Click �C�x���g(Cancel_Button)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
        ///							�������܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //�ۑ��m�F
            SecMngConnectSt compareSecMngConnectSt = new SecMngConnectSt();
            compareSecMngConnectSt = this._secMngConnectSt.Clone();
            //���݂̉�ʏ����擾����
            ScreenToSecMngConnectSt(ref compareSecMngConnectSt);

            //�ŏ��Ɏ擾������ʏ��Ɣ�r 
            if (!(this._secMngConnectStClone.Equals(compareSecMngConnectSt)))
            {
                //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������ 
                // �ۑ��m�F
                DialogResult res = TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                    "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    null, 								// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);	// �\������{�^��
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            SaveProc();
                            return;
                        }
                    case DialogResult.No:
                        {
                            this._secMngConnectSt = this._secMngConnectStClone.Clone();
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }

            DialogResult dialogResult = DialogResult.Cancel;
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            this._secMngConnectStClone = null;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>tComboEditor��ValueChanged�C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	ValueChanged�Ƃ��ɔ������܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void tComboEditor_ConnectPointDiv_ValueChanged(object sender, EventArgs e)
        {
            this.ScreenClear(false);

            this.SetIPAddEnabled(this.tComboEditor_ConnectPointDiv.SelectedIndex);
        }

        /// <summary>Form.Closing �C�x���g(MAPOS09150UA)</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note			:	�t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///							�悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void PMKYO09250UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._secMngConnectStClone = null;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>���VisibleChange�C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	VisibleChanged�Ƃ��ɔ������܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void PMKYO09250UA_VisibleChanged(object sender, EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            // �f�[�^���Z�b�g����Ă����甲����
            if (this._secMngConnectStClone != null)
            {
                return;
            }

            Initial_Timer.Enabled = true;

            this.ScreenClear(true);
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>  
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʍč\�z����
            ScreenReconstruction();

            // �ڑ���`�F�b�N����
            this.CheckConnectInfo();
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_ApServerIpAddress1)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress1_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress1.DataText.Length == tNedit_ApServerIpAddress1.MaxLength)
            {
                tNedit_ApServerIpAddress2.Focus();
            }
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_ApServerIpAddress2)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress2_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress2.DataText.Length == tNedit_ApServerIpAddress2.MaxLength)
            {
                tNedit_ApServerIpAddress3.Focus();
            }
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_ApServerIpAddress3)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress3_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress3.DataText.Length == tNedit_ApServerIpAddress3.MaxLength)
            {
                tNedit_ApServerIpAddress4.Focus();
            }
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_DbServerIpAddress1)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress1_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress1.DataText.Length == tNedit_DbServerIpAddress1.MaxLength)
            {
                tNedit_DbServerIpAddress2.Focus();
            }
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_DbServerIpAddress2)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress2_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress2.DataText.Length == tNedit_DbServerIpAddress2.MaxLength)
            {
                tNedit_DbServerIpAddress3.Focus();
            }
        }

        /// <summary>
        ///	ValueChanged�C�x���g(tNedit_DbServerIpAddress3)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: KeyUp�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress3_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress3.DataText.Length == tNedit_DbServerIpAddress3.MaxLength)
            {
                tNedit_DbServerIpAddress4.Focus();
            }
        }
        # endregion

        # region private Methods
        /// <summary>��ʏ����ݒ菈��</summary>
        /// <remarks>
        /// <br>Note		:	��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // �ڑ���
            this.tComboEditor_ConnectPointDiv.Items.Clear();
            this.tComboEditor_ConnectPointDiv.Items.Add(0, CONNECTPOINTDIV_1);
            this.tComboEditor_ConnectPointDiv.Items.Add(1, CONNECTPOINTDIV_2);

            // �A�v���P�[�V�����T�[�o�[
            this.tNedit_ApServerIpAddress1.Clear();
            this.tNedit_ApServerIpAddress2.Clear();
            this.tNedit_ApServerIpAddress3.Clear();
            this.tNedit_ApServerIpAddress4.Clear();

            // �f�[�^�x�[�X
            this.tNedit_DbServerIpAddress1.Clear();
            this.tNedit_DbServerIpAddress2.Clear();
            this.tNedit_DbServerIpAddress3.Clear();
            this.tNedit_DbServerIpAddress4.Clear();
        }

        /// <summary>��ʍč\�z����</summary>
        /// <remarks>
        /// <br>Note        : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenReconstruction()
        {
            Mode_Label.Text = UPDATE_MODE;

            // ��ʓW�J����
            this.SecMngConnectStToScreen();

            if (this._secMngConnectSt == null)
            {
                this._secMngConnectSt = new SecMngConnectSt();
            }

            //�N���[���쐬
            this._secMngConnectStClone = this._secMngConnectSt.Clone();
            //��ʏ����r�p�N���[���ɃR�s�[����@
            ScreenToSecMngConnectSt(ref this._secMngConnectStClone);

            this.tComboEditor_ConnectPointDiv.Focus();
        }

        /// <summary>��ʃN���A����</summary>
        /// <param name="flag">True:�ڑ���N���A. False:�ڑ���N���A���Ȃ�</param>
        /// <remarks>
        /// <br>Note		:	��ʃN���A�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenClear(bool flag)
        {
            if (flag)
            {
                this.tComboEditor_ConnectPointDiv.SelectedIndex = 0;
            }

            this.tNedit_ApServerIpAddress1.Clear();
            this.tNedit_ApServerIpAddress2.Clear();
            this.tNedit_ApServerIpAddress3.Clear();
            this.tNedit_ApServerIpAddress4.Clear();
            this.tNedit_DbServerIpAddress1.Clear();
            this.tNedit_DbServerIpAddress2.Clear();
            this.tNedit_DbServerIpAddress3.Clear();
            this.tNedit_DbServerIpAddress4.Clear();
        }

        /// <summary>��ʓW�J����</summary>
        /// <remarks>
        /// <br>Note		:	�ڑ���ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>   
        /// </remarks>
        private void SecMngConnectStToScreen()
        {
            if (this._secMngConnectSt != null)
            {
                this.tComboEditor_ConnectPointDiv.SelectedIndex = this._secMngConnectSt.ConnectPointDiv;

                if (this._secMngConnectSt.ConnectPointDiv == 1)
                {
                    string[] apServerIpAddress = this._secMngConnectSt.ApServerIpAddress.Split('.');
                    this.tNedit_ApServerIpAddress1.SetInt(int.Parse(apServerIpAddress[0]));
                    this.tNedit_ApServerIpAddress2.SetInt(int.Parse(apServerIpAddress[1]));
                    this.tNedit_ApServerIpAddress3.SetInt(int.Parse(apServerIpAddress[2]));
                    this.tNedit_ApServerIpAddress4.SetInt(int.Parse(apServerIpAddress[3]));

                    string[] dbServerIpAddress = this._secMngConnectSt.DbServerIpAddress.Split('.');
                    this.tNedit_DbServerIpAddress1.SetInt(int.Parse(dbServerIpAddress[0]));
                    this.tNedit_DbServerIpAddress2.SetInt(int.Parse(dbServerIpAddress[1]));
                    this.tNedit_DbServerIpAddress3.SetInt(int.Parse(dbServerIpAddress[2]));
                    this.tNedit_DbServerIpAddress4.SetInt(int.Parse(dbServerIpAddress[3]));
                }
            }
        }

        /// <summary>��ʏ��|�ڑ���ݒ�N���X�i�[����(�ۑ��m�F���b�Z�[�W�p)</summary>
        /// <param name="secMngConnectSt">�ڑ���ݒ�N���X</param>
        /// <remarks>
        /// <br>Note			:	��ʏ�񂩂�ڑ���ݒ�N���X�Ƀf�[�^��
        ///							�i�[���܂��B</br>
        /// <br>Programer       :	�����</br>                            
        /// <br>Date            :	2009.04.21</br>   
        /// </remarks>
        private void ScreenToSecMngConnectSt(ref SecMngConnectSt secMngConnectSt)
        {
            if (secMngConnectSt == null)
            {
                // �V�K�̏ꍇ
                secMngConnectSt = new SecMngConnectSt();
            }
            //�w�b�_��
            secMngConnectSt.EnterpriseCode = this._enterpriseCode;
            secMngConnectSt.SectionCode = "0";

            secMngConnectSt.ConnectPointDiv = this.tComboEditor_ConnectPointDiv.SelectedIndex;

            secMngConnectSt.ApServerIpAddress = GetIPAddress(1);

            secMngConnectSt.DbServerIpAddress = GetIPAddress(2);
        }

        /// <summary>�ۑ�����(SaveProc())</summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string checkMessage = "";
            bool ret = true;

            //��ʃf�[�^���̓`�F�b�N����
            ret = CheckInputData(ref control, ref checkMessage);
            if (ret == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    checkMessage, 						// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                control.Focus();
                return false;
            }

            // ��ʂ���N���X�Ƀf�[�^���Z�b�g���܂��B
            ScreenToSecMngConnectSt(ref this._secMngConnectSt);

            // ���_�Ǘ��ڑ���ݒ�}�X�^�o�^
            int status = this._secMngConnectStAcs.Write(ref _secMngConnectSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this._secMngConnectSt = this._secMngConnectStClone.Clone();
                        ExclusiveTransaction(status);
                        return false;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���_�Ǘ��ڑ���ݒ�", 					// �v���O��������
                            "SavePosTerminalMg", 					// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._secMngConnectStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return false;
                    }
            }

            DialogResult dialogResult = DialogResult.OK;

            Mode_Label.Text = UPDATE_MODE;

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this._secMngConnectStClone = null;

            this.DialogResult = dialogResult;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return true;
        }
        /// <summary>��ʃ`�F�b�N����</summary>
        /// <param name="control">�R���g���[��</param>
        /// <param name="checkMessage">���b�Z�[�W</param>
        /// <returns>true:����@false:�ُ�</returns>
        /// <remarks>
        /// <br>Note		:	��ʓ��̓f�[�^�̃`�F�b�N���ʂ�ԋp���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool CheckInputData(ref Control control, ref string checkMessage)
        {
            // �ڑ��悪�u�W�v�@�v�ꍇ
            if (this.tComboEditor_ConnectPointDiv.SelectedIndex == 1)
            {
                // �f�[�^�x�[�X��IP�A�h���X�����͂���Ă��Ȃ��i�S�ċ󔒁j�ꍇ
                if (this.tNedit_ApServerIpAddress1.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress2.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress3.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress4.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress1.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress2.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress3.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress4.DataText == string.Empty)
                {
                    control = this.tNedit_ApServerIpAddress1;
                    checkMessage = "�A�v���P�[�V�����T�[�o�[�A�f�[�^�x�[�X��IP�A�h���X����͂��Ă��������B";
                    return false;
                }

                // �ڑ��悪�u�W�v�@�v�ꍇ�A�f�[�^�x�[�X����͂��āA�A�v���P�[�V�����T�[�o�[�����͂��Ȃ��̏ꍇ
                if (this.tNedit_ApServerIpAddress1.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress1.DataText))
                {
                    control = this.tNedit_ApServerIpAddress1;
                    checkMessage = "�A�v���P�[�V�����T�[�o�[��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress2.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress2.DataText))
                {
                    control = this.tNedit_ApServerIpAddress2;
                    checkMessage = "�A�v���P�[�V�����T�[�o�[��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress3.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress3.DataText))
                {
                    control = this.tNedit_ApServerIpAddress3;
                    checkMessage = "�A�v���P�[�V�����T�[�o�[��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress4.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress4.DataText))
                {
                    control = this.tNedit_ApServerIpAddress4;
                    checkMessage = "�A�v���P�[�V�����T�[�o�[��IP�A�h���X���s���ł��B";
                    return false;
                }

                // �ڑ��悪�u�W�v�@�v�ꍇ�A�A�v���P�[�V�����T�[�o�[����͂��āA�f�[�^�x�[�X�����͂��Ȃ��̏ꍇ
                if (this.tNedit_DbServerIpAddress1.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress1.DataText))
                {
                    control = this.tNedit_DbServerIpAddress1;
                    checkMessage = "�f�[�^�x�[�X��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress2.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress2.DataText))
                {
                    control = this.tNedit_DbServerIpAddress2;
                    checkMessage = "�f�[�^�x�[�X��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress3.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress3.DataText))
                {
                    control = this.tNedit_DbServerIpAddress3;
                    checkMessage = "�f�[�^�x�[�X��IP�A�h���X���s���ł��B";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress4.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress4.DataText))
                {
                    control = this.tNedit_DbServerIpAddress4;
                    checkMessage = "�f�[�^�x�[�X��IP�A�h���X���s���ł��B";
                    return false;
                }
            }

            return true;
        }

        /// <summary>IP�A�h���X�`�F�b�N����</summary>
        /// <param name="iPAddress">IP�A�h���X</param>
        /// <remarks>
        /// <br>Note		:	IP�A�h���X�`�F�b�N�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool CheckIPAddress(string iPAddress)
        {
            try
            {
                int inIPAddress = Convert.ToInt32(iPAddress);
                // IP�A�h���X
                if (inIPAddress > 255 || inIPAddress < 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>�ڑ���`�F�b�N����</summary>
        /// <remarks>
        /// <br>Note		:	�ڑ���`�F�b�N�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.27</br>    
        /// </remarks>
        private void CheckConnectInfo()
        {
            // ���_�Ǘ��ڑ���ݒ�}�X�^�̐ڑ��悪�u�W�v�@�v�̏ꍇ
            if (this._secMngConnectSt.ConnectPointDiv == 1)
            {
                bool checkFlag = true;
                SecMngConnectSt registrySecMngConnectSt;
                // ���̎擾(���W�X�g��)
                int status = this._secMngConnectStAcs.GetRegistryKey(out registrySecMngConnectSt);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // �ڑ���`�F�b�N����
                    checkFlag = this.CheckRegistAndDB(this._secMngConnectStClone, registrySecMngConnectSt);
                }
                else
                {
                    checkFlag = false;
                }

                if (!checkFlag)
                {
                    // ���̓`�F�b�N
                    TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                        "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "�ڑ����񂪐ݒ肳��Ă��܂���B\r\n" +
                        "�ۑ������s���ĉ������B", 	        // �\�����郁�b�Z�[�W
                        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                }
            }
        }

        /// <summary>�ڑ���`�F�b�N����</summary>
        /// <param name="dBSecMngConnectSt">DB�ڑ���</param>
        /// <param name="registSecMngConnectSt">���W�X�g���ڑ���</param>
        /// <remarks>
        /// <br>Note		:	�ڑ���`�F�b�N�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.27</br>    
        /// </remarks>
        private bool CheckRegistAndDB(SecMngConnectSt dBSecMngConnectSt, SecMngConnectSt registSecMngConnectSt)
        {
            // ���W�X�g����DB��r
            if (!(dBSecMngConnectSt.ApServerIpAddress.Equals(registSecMngConnectSt.ApServerIpAddress)
                && dBSecMngConnectSt.DbServerIpAddress.Equals(registSecMngConnectSt.DbServerIpAddress)))
            {
                // �s��v
                return false;
            }
            return true;
        }

        /// <summary>IP�A�h���X�擾����</summary>
        /// <param name="ipFlag">1:�A�v���P�[�V�����T�[�o�[; 2:�f�[�^�x�[�X</param>
        /// <remarks>
        /// <br>Note		:	IP�A�h���X�擾�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private string GetIPAddress(int ipFlag)
        {
            StringBuilder ipAddress = new StringBuilder();
            switch (ipFlag)
            {
                // �A�v���P�[�V�����T�[�o�[
                case 1:
                    {
                        if (!(tNedit_ApServerIpAddress1.DataText == string.Empty
                            && tNedit_ApServerIpAddress2.DataText == string.Empty
                            && tNedit_ApServerIpAddress3.DataText == string.Empty
                            && tNedit_ApServerIpAddress4.DataText == string.Empty))
                        {
                            ipAddress.Append(tNedit_ApServerIpAddress1.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress2.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress3.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress4.GetInt().ToString());
                        }

                        break;
                    }
                // �f�[�^�x�[�X
                case 2:
                    {
                        if (!(tNedit_DbServerIpAddress1.DataText == string.Empty
                            && tNedit_DbServerIpAddress2.DataText == string.Empty
                            && tNedit_DbServerIpAddress3.DataText == string.Empty
                            && tNedit_DbServerIpAddress4.DataText == string.Empty))
                        {
                            ipAddress.Append(tNedit_DbServerIpAddress1.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress2.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress3.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress4.GetInt().ToString());
                        }

                        break;
                    }
            }
            return ipAddress.ToString();
        }

        /// <summary>IP�A�h���X����Enabled����</summary>
        /// <param name="selectIndex">0:�A�v���P�[�V�����T�[�o�[; 1:�f�[�^�x�[�X:</param>
        /// <remarks>
        /// <br>Note		:	IP�A�h���X����Enabled�������s���܂��B</br>
        /// <br>Programer   :	�����</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void SetIPAddEnabled(int selectIndex)
        {
            // �ڑ��悪�u�f�[�^�Z���^�[�v�ꍇ
            if (selectIndex == 0)
            {
                this.tNedit_ApServerIpAddress1.Enabled = false;
                this.tNedit_ApServerIpAddress2.Enabled = false;
                this.tNedit_ApServerIpAddress3.Enabled = false;
                this.tNedit_ApServerIpAddress4.Enabled = false;

                this.tNedit_DbServerIpAddress1.Enabled = false;
                this.tNedit_DbServerIpAddress2.Enabled = false;
                this.tNedit_DbServerIpAddress3.Enabled = false;
                this.tNedit_DbServerIpAddress4.Enabled = false;
            }
            else
            {
                this.tNedit_ApServerIpAddress1.Enabled = true;
                this.tNedit_ApServerIpAddress2.Enabled = true;
                this.tNedit_ApServerIpAddress3.Enabled = true;
                this.tNedit_ApServerIpAddress4.Enabled = true;

                this.tNedit_DbServerIpAddress1.Enabled = true;
                this.tNedit_DbServerIpAddress2.Enabled = true;
                this.tNedit_DbServerIpAddress3.Enabled = true;
                this.tNedit_DbServerIpAddress4.Enabled = true;
            }
        }

        /// <summary>�r������</summary>
        /// <param name="status">�`�F�b�N����</param>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        this.Hide();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            "PMKYO09250U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        this.Hide();
                        break;
                    }
            }
            this._secMngConnectStClone = null;
        }
        # endregion

        #region �� �I�t���C����ԃ`�F�b�N����
        /// <summary>				
        /// ���O�I�����I�����C����ԃ`�F�b�N����				
        /// </summary>				
        /// <returns>�`�F�b�N��������</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// �����[�g�ڑ��\����				
        /// </summary>				
        /// <returns>���茋��</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}