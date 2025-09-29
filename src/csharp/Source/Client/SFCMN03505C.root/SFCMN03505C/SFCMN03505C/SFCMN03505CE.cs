using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �t�F���J�����̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �t�F���J���ݒ���s���܂��B</br>
    /// <br>Programmer	: 22011 �����@���l</br>
    /// <br>Date		: 2008.11.06</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 ��� ���b</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br>           : �@�ENetAdvantage�o�[�W�����A�b�v�Ή�</br>
    /// <br>           : �@�E�A�C�R���ύX(SF��NS)</br>
    /// </remarks>
    public partial class SFCMN03505CE : Form
    {
        #region constructer
        /// <summary>
        /// �t�F���J�����̓t�H�[���R���X�g���N�^
        /// </summary>
        public SFCMN03505CE()
        {
            InitializeComponent();
            // ���C�u����������
            _felicaAcs.InitializeLibrary();
        }
        #endregion

        #region Private Membar
        private FelicaAcs _felicaAcs = new FelicaAcs();        // �t�F���J�A�N�Z�X���C�u����
        private UInt64 _feliCaIDm = 0;                         // �t�F���JID��
        private Int32 _pollingInterval = 400;                  // �|�[�����O�̊Ԋu(ms)
        private Int32 _pollingRetryCnt = 0;                    // �A���|�[�����O�̉� 0(�[��)�ŉ񐔎w��Ȃ��B
        private bool _showErrMsg = true;                      // �|�[�����O�ŃG���[�������̃��b�Z�[�W�\���敪
        /// <summary>�ŏI�G���[�^�C�v(Felica.dll)</summary>
        private FeliCaErrorType _felicaLastErrType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
        /// <summary>�ŏI�G���[�^�C�v(rw.dll)</summary>
        private RwErrorType _rwLastErrType = RwErrorType.RW_ERROR_NOT_OCCURRED;
        #endregion

        #region Propaty
        /// <summary>
        /// �A���|�[�����O�̊Ԋu���w�肵�܂�(ms)�@ �����l�y400ms�z
        /// </summary>
        public int PollingInterval
        {
            get
            {
                return this._pollingInterval;
            }
            set
            {
                this._pollingInterval = value;
            }
        }

        /// <summary>
        /// �A���|�[�����O�̃|�[�����O�񐔂��w�肵�܂��B 0(�[��)�ŉ񐔎w��Ȃ��B
        /// </summary>
        public int PollingRetryCnt
        {
            get
            {
                return this._pollingRetryCnt;
            }
            set
            {
                this._pollingRetryCnt = value;
            }
        }

        /// <summary>
        /// �G���[�������̃��b�Z�[�W�\���L���@true:�\�� false:��\���@(�����l:true)�@RW_CARD_NOT_FOUND�͕\�����܂���B
        /// </summary>
        public bool ShowErrMsg
        {
            get
            {
                return this._showErrMsg;
            }
            set
            {
                this._showErrMsg = value;
            }
        }

        /// <summary>�ŏI�G���[�^�C�v(Felica.dll)</summary>
        public FeliCaErrorType FelicaLastErrType
        {
            get
            {
                return this._felicaLastErrType;
            }
        }

        /// <summary>�ŏI�G���[�^�C�v(rw.dll)</summary>
        public RwErrorType RwLastErrType
        {
            get
            {
                return this._rwLastErrType;
            }
        }
        #endregion

        #region delegate
        // ���b�Z�[�W�\���p
        delegate void MsgDispDelegate(emErrorLevel errLvl, string msg);
        #endregion

        #region Public Method
        /// <summary>
        /// �t�F���J�����̓t�H�[����\�����܂�
        /// </summary>
        /// <param name="feliCaIDm">�t�F���JID��</param>
        /// <param name="ownerForm">�I�[�i�[�t�H�[��</param>
        /// <returns>DialogResult �ǂݎ�萬�� :OK, �ǂݎ�莸�s :Abort, �L�����Z�� �FCansel</returns>
        public DialogResult ShowFeliCaReadForm(ref UInt64 feliCaIDm, Form ownerForm)
        {
            if (_felicaAcs == null)            
            {
                _felicaAcs = new FelicaAcs();
                _felicaAcs.InitializeLibrary();
            }
            // ���[�_�[�^���C�^�[�I�[�v��
            if (!_felicaAcs.OpenReaderWriterAuto())
            {
                //�I�[�v���Ɏ��s
                PollingCallBack(0, 0, false);
                return DialogResult.Abort;
            }

            // �R�[���o�b�N�f���Q�[�g�ɓo�^
            _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingCallBack);
            // �A���|�[�����O�J�n
            _felicaAcs.StartPolling(_pollingInterval, _pollingRetryCnt);
            // �_�C�A���O�\��
            this.Owner = ownerForm;
            DialogResult ret = this.ShowDialog();
            feliCaIDm = _feliCaIDm;
            return ret;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// �|�[�����O�R�[���o�b�N�֐�
        /// </summary>
        /// <param name="idm">�t�F���JIDM</param>
        /// <param name="pmm"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool PollingCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            if (result)
            {
                // --- ADD m.suzuki 2010/02/18 ---------->>>>>
                if ( idm == 0 )
                {
                    // ��x�|�[�����O�����ƔF�����Ă�idm=0�Ȃ�΃L�����Z������B
                    // �i�����ڑ��̎��A��F�����Ă��܂��ׁj
                    return false;
                }
                // --- ADD m.suzuki 2010/02/18 ----------<<<<<

                // �|�[�����O����
                _feliCaIDm = idm;
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else
            {
                // �ŏI�G���[�^�C�v�擾
                _felicaAcs.GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);

                if (ShowErrMsg)
                {
                    if ((_felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_OPEN_AUTO_ERROR) ||
                        (_felicaAcs.RwLastErrType == RwErrorType.RW_DEVICE_PLUGIN_NOT_FOUND) ||
                        (_felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_FILE_NOT_FOUND))
                    {
                        // �h���C�o�������܂��̓��[�_�[���ڑ�
                        StringBuilder msg = new StringBuilder();
                        msg.AppendLine("�J�[�h���[�_�[�����o�ł��܂���ł����B");
                        msg.AppendLine(string.Empty);
                        msg.AppendLine("���̂��Ƃ��m�F���čēx�������������B");
                        msg.AppendLine("�@�E�t�F���J�J�[�h�̃��[�_�[�͐ڑ�����Ă��܂���");
                        msg.AppendLine("�@�E���[�_�[�̍ŐV�h���C�o���C���X�g�[������n�[�h�E�F�A���F������Ă��܂���");
                        msg.AppendLine("�@�E���̃v���O�����Ń��[�_�[���g�p���ł͂Ȃ��ł���");
                        MsgDispInvokeRequired(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg.ToString());
                    }
                    else if((_felicaAcs.RwLastErrType != RwErrorType.RW_CARD_NOT_FOUND) &&
                        (_felicaAcs.RwLastErrType != RwErrorType.RW_ERROR_NOT_OCCURRED))
                    {
                        // �J�[�h��������Ȃ��ӊO�ŃG���[�����������烁�b�Z�[�W�\��
                        // �|�[�����O���s
                        MsgDispInvokeRequired(emErrorLevel.ERR_LEVEL_EXCLAMATION, _felicaAcs.LastErrMsg);
                        _felicaAcs.Dispose();
                        _felicaAcs = null;
                    }
                }
                this.DialogResult = DialogResult.Abort;
            }
            return result;
        }

        /// <summary>
        /// �X���b�h�Z�[�t�ȕ��@�Ń��b�Z�[�W���_�C�A���O�\�����܂�
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="errLvl">�G���[���x��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        private void MsgDispInvokeRequired(emErrorLevel errLvl, string msg)
        {
            if (this.InvokeRequired)
            {
                object[] parm = new object[]{(object)errLvl, (object)msg};
                Invoke(new MsgDispDelegate(MsgDispInvokeRequired), parm);
                return;
            }
            TMsgDisp.Show(
               this.Owner,					          // �e�E�B���h�E�t�H�[��
               errLvl,	                              // �G���[���x��
               "SFCMN03505CE",						  // �A�Z���u���h�c�܂��̓N���X�h�c
               this.Text,							  // �v���O��������
               "PollingCallBack",			          // ��������
               TMsgDisp.OPE_GET,					  // �I�y���[�V����
               msg.ToString(),				          // �\�����郁�b�Z�[�W 
               -1,								      // �X�e�[�^�X�l
               this._felicaAcs,					      // �G���[�����������I�u�W�F�N�g
               MessageBoxButtons.OK,				  // �\������{�^��
               MessageBoxDefaultButton.Button1);	  // �����\���{�^��
        }
        #endregion

        #region Control Event
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN03505CE_Load(object sender, EventArgs e)
        {
            // �{�^���̃A�C�R���ݒ�
            this.Cancel_Button.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
        }

        /// <summary>
        /// �u�߂�v�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // �A���|�[�����O���~
            _felicaAcs.StopPolling();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}