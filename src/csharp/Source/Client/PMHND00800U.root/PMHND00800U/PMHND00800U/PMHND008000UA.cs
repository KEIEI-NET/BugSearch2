//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : HT�v���O������������
// �v���O�����T�v   : HT�v���O�������������t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �X�R�@�_
// �� �� ��  2017/12/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Threading;

using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HT�v���O�������������t�h�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : HT�v���O�������������t�h�N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : �X�R�@�_</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public partial class PMHND008000UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region�@�R���X�g Memebers

        /// <summary>�v���O����ID</summary>
        private const string AssemblyId = "PMHND0800U";

        /// <summary>�v���O��������</summary>
        private const string AssemblyName = "HT�v���O������������";

        /// <summary>XML�ݒ�t�@�C���̃t�H���_��</summary>
        private static string ctXMLDir = "UISettings";

        /// <summary>XML�ݒ�t�@�C������</summary>
        private static string ctXmlFileName = "PMHND00800U_UserSetting.xml";

        /// <summary>�f�t�H���g�l�F�n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ</summary>
        private static string ctDefaultVersionFileDir = "2:HttPg\\";

        /// <summary>�f�t�H���g�l�F�N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ</summary>
        private static string ctDefaiultRecvFileTempDir = "Temp\\";

        /// <summary>�f�t�H���g�l�F�N���C�A���g���̑��M�t�@�C���ۑ��ꏊ</summary>
        private static string ctDeaultSendFileDir = "Temp\\HttPg\\";

        /// <summary>�f�t�H���g�l�F�N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ</summary>
        private static string ctDeaultSendSettingFileDir = "Setting\\";

        /// <summary>�f�t�H���g�l�F�N���C�A���g���̐ݒ�t�@�C���̃t�@�C����</summary>
        private static string ctDeaultSettingFileName = "Init_System.ini";

        /// <summary>�f�t�H���g�l�F�o�[�W�������̃t�@�C����</summary>
        private static string ctDefaultVersionFileName = "HTTVER.TXT";

        /// <summary>�f�t�H���g�l�F�n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ</summary>
        private static string ctDefaultHtSettingDir = "2:HttPg\\Setting\\";

        /// <summary>�f�t�H���g�l�F�ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ</summary>
        private static string ctDefaultSettingBackupDir = "Temp\\HttBakup\\";

        /// <summary>�f�t�H���g�l�F��M���̃^�C���A�E�g���ԁi�b�j</summary>
        private static int ctDefaultRecvTimeoutVal = 10;

        /// <summary>�f�t�H���g�l�F���M���̃^�C���A�E�g���ԁi�b�j</summary>
        private static int ctDefaultSendTimeoutVal = 10;

        /// <summary>���@�[�W�������t�@�C���̍��ڋ�؂�i�J���}�j</summary>
        private static char Delimiter = ',';

        /// <summary>�t�H���_��؂��؂�i�~�}�[�N�j</summary>
        private static string ctYen = "\\";

        /// <summary>�ݒ�t�@�C���̊g���q</summary>
        private static string IniFileExtension = ".ini";

        /// <summary>���t�����i�o�b�N�A�b�v�t�H���_�p�j</summary>
        private static string DateFormat = "yyyyMMddHHmmss";

        //  �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ
        private const string ctElement_HtVersionFileDir = "HtVersionFileDir";

        // �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ
        private const string ctElement_RecvFileTempDir = "RecvFileTempDir";

        // �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ
        private const string ctElement_SendFileDir = "SendFileDir";

        // �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ
        private const string ctElement_SendSettingFileDir = "SendSettingFileDir";

        // �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ
        private const string ctElement_SettingFileName = "SettingFileName";

        // �o�[�W�������̃t�@�C����
        private const string ctElement_VersionFileName = "VersionFileName";

        // �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ
        private const string ctElement_HtSettingDir = "HtSettingDir";

        // �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ
        private const string ctElement_SettingBackupDir = "SettingBackupDir";

        // ��M���̃^�C���A�E�g���ԁi�b�j
        private const string ctElement_RecvTimeoutVal = "RecvTimeoutVal";

        // ���M���̃^�C���A�E�g���ԁi�b�j
        private const string ctElement_SendTimeoutVal = "SendTimeoutVal";

        public enum SendMode : int
        {
            MODE_NORMAL = 0,    // �ʏ�
            MODE_NOT_ALL = 1,   // �ݒ�t�@�C���ȊO
            MODE_ALL = 2,       // �S��
        } ;
        #endregion

        // ===================================================================================== //
        // �o�̓��b�Z�[�W
        // ===================================================================================== //
        #region �o�̓��b�Z�[�W

        private static string NewVersionFileMsg = "�ŐV�o�[�W�����̃t�@�C��������܂��B";

        private static string AllreadyNewVerMsg = "�ŐV�̃v���O��������������Ă��܂��B";

        private static string ProgChangeMsg = "�v���O�����̓��ւ��s���܂��B";

        private static string CompProgChgMsg = "�v���O�����̓��ւ��������܂����B";

        private static string EndButtonMsg = "�n���f�B�V�X�e���́u�I���v�{�^���������ăv���O�������I�����Ă��������B";

        private static string SendBottunMsg = "�ʐM���j�b�g�ɐڑ����āu���M�v�{�^���������Ă��������B";

        private static string ContinuedMsg = "�����đ��̃n���f�B�^�[�~�i���@��փv���O�����̓��ւ��s���܂��B";

        private static string HttProgChgMsg = "�n���f�B�^�[�~�i���@��փv���O�����̓��ւ��s���܂��B";

        #endregion

        #region �G���[���b�Z�[�W
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members

        /// <summary>
        /// ���[�h�i�ʏ탁�j���[���[�h��0�A�T�|�[�g���j���[���[�h��1�j
        /// </summary>
        private int Mode;

        /// <summary>
        /// �J�����g�f�B���N�g��
        /// </summary>
        private string CurrentDir;

        /// <summary>
        /// �ݒ�t�@�C�����
        /// </summary>
        private PMHND00802AB SettingInfo;

        /// <summary>
        ///  HT�v���O������������ �A�N�Z�X�N���X
        /// </summary>
        private PMHND00802AA pmhnd00802aa;

        /// <summary>
        /// ���K�[
        /// </summary>
        PMHND00804AE logger = null;

        /// <summary>
        /// ���M�t�@�C�����X�g
        /// </summary>
        private List<string> SendFileList = new List<string>();

        /// <summary>
        /// �N���C�A���g���o�[�W�������
        /// </summary>
        List<PMHND00803AD> clVerInfoList = new List<PMHND00803AD>();

        /// <summary>
        /// ���M�ς݃`�F�b�N�p
        /// </summary>
        private bool isSending = false;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public PMHND008000UA(int mode)
        {
            InitializeComponent();
            this.Mode = mode;

            // PM.NS�C���X�g�[���f�B���N�g��
            string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            if (key.GetValue("InstallDirectory") != null)
            {
                CurrentDir = (string)key.GetValue("InstallDirectory");
            }
            key.Close();

            // �ݒ�t�@�C���Ǎ�
            ReadSettingFile();

            // HT�v���O�������������A�N�Z�X�N���X
            pmhnd00802aa = new PMHND00802AA(this.SettingInfo);

            logger = PMHND00804AE.getInstance();


            // ��ʏ����\������
            InitialDisplay(this.Mode);

        }
        #endregion

        // ===================================================================================== //
        // ��ʑ��쏈��
        // ===================================================================================== //
        #region Control Event Methods

        #region �t�H�[�����[�h�C�x���g
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMHND00800UA_Load(object sender, EventArgs e)
        {
            bool status;
            string errMsg = string.Empty;

            // ---------------------------------------
            // ���d�N���̖h�~
            // ---------------------------------------
            Mutex mutex = new Mutex(false, "PMHND00800U");

            // �~���[�e�b�N�X�̏��L����v��
            if (!mutex.WaitOne(0, false))
            {
                if (this.Mode != PMHND00802AC.VersionCheckMode)
                {
                    //���łɋN�����Ă���Ɣ��f���ďI��
                    System.Windows.Forms.MessageBox.Show(
                        "�o�[�W�����`�F�b�N�܂��͓����������N�����Ă��܂��B\n���d�N���͂ł��܂���B",
                        "���� - <HT�v���O������������>",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation
                    );
                }
                this.Close();
                return;
            }

            if (this.Mode == PMHND00802AC.VersionCheckMode)
            {
                // HT�V�X�e���t�@�C���`�F�b�N
                // HT�V�X�e���t�@�C�������݂��Ȃ��ꍇ�A�������I��
                status = HtSystemFileCheck();
                if (!status)
                {
                    this.Close();
                    return;
                }

                // �o�[�W�����`�F�b�N
                // �ŐV�̃o�[�W�����łȂ��ꍇ�A�t�H�[���A���b�Z�[�W��\�������ɏI������
                status = VersionCheck(out errMsg);
                if (status)
                {
                    // �ŐV�o�[�W�����̃t�@�C��������܂��B
                    this.messageLabel.Text = NewVersionFileMsg;

                    // �n���f�B�^�[�~�i���@��փv���O�����̓��ւ��s���܂��B
                    this.notificateLabel.Text = HttProgChgMsg + Environment.NewLine;
                    // �n���f�B�V�X�e���́u�I���v�{�^���������ăv���O�������I�����Ă��������B
                    this.notificateLabel.Text += EndButtonMsg + Environment.NewLine;
                    // �ʐM���j�b�g�ɐڑ����āu���M�v�{�^���������Ă��������B
                    this.notificateLabel.Text += SendBottunMsg;
                }
                else
                {
                    // �ŐV�̃o�[�W�����łȂ��ꍇ�A�t�H�[���A���b�Z�[�W��\�������ɏI������
                    this.Close();
                    return;
                }
            }

            if (this.Mode == PMHND00802AC.SupportMenuMode)
            {
                this.Text += "�i�T�|�[�g�j";
            }
            this.ActiveControl = this.sendButton;
            
        }
        #endregion

        #region ���M�{�^���N���b�N�C�x���g
        /// <summary>
        /// ���M�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            int status;
            
            string errMsg = string.Empty;

            // HT�V�X�e���t�@�C���`�F�b�N
            // HT�V�X�e���t�@�C�������݂��Ȃ��ꍇ�A�������I��
            if (!HtSystemFileCheck())
            {
                errMsg = "�ŐV�o�[�W�����̃t�@�C��������܂���B\n�n���f�B�^�[�~�i���@��փv���O�����̓��ւ͍s���܂���B";
                // �G���[���b�Z�[�W�o��
                this.messageLabel.Text = errMsg;
                this.messageLabel.ForeColor = Color.Red;
                this.notificateLabel.Text = string.Empty;

                logger.WriteLog(errMsg);
                return;
            }

            // �t�@�C�����֕��@�𖳌���
            this.uos_SendDiv.Enabled = false;
            // ���M�{�^���𖳌���
            this.sendButton.Enabled = false;
            // �L�����Z���{�^���𖳌���
            this.cancelButton.Enabled = false;

            // �v���O�����̓��ւ��s���܂��B
            this.messageLabel.Text = ProgChangeMsg;
            this.messageLabel.ForeColor = Color.Black;

            this.notificateLabel.Text = string.Empty;
            this.notificateLabel.ForeColor = Color.Black;

            if (Mode != PMHND00802AC.VersionCheckMode)
            {
                isSending = true;
            }

            // �ʏ탁�j���[���[�h�̏ꍇ�A�ʏ탁�j���[���[�h�œ��삷��
            if (Mode != PMHND00802AC.SupportMenuMode)
            {
                status = FileChange(SendMode.MODE_NORMAL, out errMsg);
            }
            // 
            else
            {
                status = SupportModeModeProc(out errMsg);
            }

            if (status == 0)
            {
                // �����đ��̃n���f�B�^�[�~�i���@��փv���O�����̓��ւ��s���܂��B
                this.notificateLabel.Text = ContinuedMsg + Environment.NewLine;
                // �n���f�B�V�X�e���́u�I���v�{�^���������ăv���O�������I�����Ă��������B
                this.notificateLabel.Text += EndButtonMsg + Environment.NewLine;
                // �ʐM���j�b�g�ɐڑ����āu���M�v�{�^���������Ă��������B
                this.notificateLabel.Text += SendBottunMsg;
            }
            else
            {
                // �G���[���b�Z�[�W�o��
                this.messageLabel.Text = errMsg;
                this.messageLabel.ForeColor = Color.Red;
                logger.WriteLog(errMsg);

                if (errMsg.IndexOf("�u���M�v�{�^��") <= 0)
                {
                    this.notificateLabel.Text = "�ēx�u���M�v�{�^���������Ă��������B";
                    this.notificateLabel.ForeColor = Color.Red;
                }
            }

            isSending = true;

            // �t�@�C�����֕��@��L����
            this.uos_SendDiv.Enabled = true;
            // ���M�{�^����L����
            this.sendButton.Enabled = true;
            // �L�����Z���{�^����L����
            this.cancelButton.Enabled = true;

            this.sendButton.Focus();

        }
        #endregion

        #region �L�����Z���{�^���N���b�N�C�x���g
        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region private

        #region ��ʏ����\������
        /// <summary>
        /// ��ʏ����\������
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       :��ʂ̏����\���������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void InitialDisplay(int mode)
        {
            // �v���O�����̓���ւ����s���܂��B
            this.messageLabel.Text = ProgChangeMsg;

            // �n���f�B�V�X�e���́u�I���v�{�^���������ăv���O�������I�����Ă��������B
            this.notificateLabel.Text = EndButtonMsg + Environment.NewLine;

            // �ʐM���j�b�g�ɐڑ����āu���M�v�{�^���������Ă��������B
            this.notificateLabel.Text += SendBottunMsg;

            // �ʏ탁�j���[�N���̏ꍇ�A�I�����W�I�{�^����\�����Ȃ�
            if (mode != PMHND00802AC.SupportMenuMode)
            {
                this.radioPanel.Hide();
                this.radioPanelLabel.Hide();
                this.uos_SendDiv.Hide();
            }

        }
        #endregion

        #region HT�V�X�e���t�@�C���`�F�b�N����
        /// <summary>
        /// HT�V�X�e���t�@�C���`�F�b�N����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : HT�V�X�e���t�@�C���`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool HtSystemFileCheck()
        {
            // �V�X�e���t�@�C�����M�ꏊ
            string systemFileDir = Path.Combine(CurrentDir, SettingInfo.SendFileDir);

            // �t�H���_�`�F�b�N
            if (Directory.Exists(systemFileDir))
            {
                // �V�X�e���t�@�C���L���`�F�b�N
                string[] files = Directory.GetFiles(systemFileDir, "*", SearchOption.AllDirectories);

                if (files != null && files.Length > 0)
                {
                    return true;
                }
            }

            return false;

        }
        #endregion

        #region XML�ݒ�t�@�C���Ǎ�����
        /// <summary>
        /// XML�ݒ�t�@�C���Ǎ�����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : XML�ݒ�t�@�C������A�ݒ����ǂݍ��ޏ������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void ReadSettingFile()
        {
            XmlDocument xmlDoc = null;

            // XML�t�@�C���ݒ���
            SettingInfo = new PMHND00802AB();

            // XML�ݒ�t�@�C���t���p�X���쐬
            string pmXmlPath = Path.Combine(CurrentDir, ctXMLDir);
            pmXmlPath = Path.Combine(pmXmlPath, ctXmlFileName);

            if (!(File.Exists(pmXmlPath)))
            {
                // �ݒ�t�@�C�������݂��Ȃ��ꍇ�A�ݒ�t�@�C����V�K�쐬����
                MakeSettingFile(pmXmlPath);
            }

            string errMsg = string.Empty;

            try
            {
                // XML�t�@�C���ǂݍ���
                xmlDoc = new XmlDocument();
                xmlDoc.Load(pmXmlPath);
                XmlNodeList infoList = xmlDoc.SelectNodes("UserSettingInfo");

                // node�����݂��Ȃ��ꍇ�A����foreach�ŗ�O�𔭐������āAdefault�l��K�p������

                // �m�[�h�iUserSettingInfo�j�̐������[�v
                foreach (XmlNode infoNode in infoList)
                {
                    XmlNodeList childNodeList = infoNode.ChildNodes;

                    // UserSettingInfo�̎q�m�[�h�̐������[�v
                    foreach (XmlNode childNode in childNodeList)
                    {
                        // UserSettingInfo�̎q�m�[�h�̃^�O������̏ꍇ�A���m�[�h����������
                        if (string.IsNullOrEmpty(childNode.Name))
                        {
                            continue;
                        }
                        switch (childNode.Name)
                        {

                            case ctElement_HtVersionFileDir:         // �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ
                                {
                                    SettingInfo.HtVersionFileDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.HtVersionFileDir.EndsWith(ctYen))
                                    {
                                        SettingInfo.HtVersionFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_RecvFileTempDir:        // �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ
                                {
                                    SettingInfo.RecvFileTempDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.RecvFileTempDir.EndsWith(ctYen))
                                    {
                                        SettingInfo.RecvFileTempDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SendFileDir:            // �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ
                                {
                                    SettingInfo.SendFileDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.SendFileDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SendFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SendSettingFileDir:            // �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ
                                {
                                    SettingInfo.SendSettingFileDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.SendSettingFileDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SendSettingFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SettingFileName:            // �N���C�A���g���̐ݒ�t�@�C���̃t�@�C����
                                {
                                    SettingInfo.SettingFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case ctElement_VersionFileName:        // �o�[�W�������̃t�@�C����
                                {
                                    SettingInfo.VersionFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case ctElement_HtSettingDir:           // �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ
                                {
                                    SettingInfo.HtSettingDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.HtSettingDir.EndsWith("\\"))
                                    {
                                        SettingInfo.HtSettingDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SettingBackupDir:       // �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ
                                {
                                    SettingInfo.SettingBackupDir = childNode.InnerText ?? string.Empty;
                                    // �t�H���_���̍Ō��"\"���Ȃ��ꍇ�A�Ō��"\"��⊮����
                                    if (!SettingInfo.SettingBackupDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SettingBackupDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_RecvTimeoutVal:         // ��M���̃^�C���A�E�g���ԁi�b�j
                                {
                                    try
                                    {
                                        SettingInfo.RecvTimeoutVal = int.Parse(childNode.InnerText);
                                    }
                                    catch
                                    {
                                        // ���ݒ�̏ꍇ�̓f�t�H���g�l���g�p����̂ŁA�����ł͉������Ȃ�
                                    }
                                    break;
                                }
                            case ctElement_SendTimeoutVal:         // ���M���̃^�C���A�E�g���ԁi�b�j
                                {
                                    try
                                    {
                                        SettingInfo.SendTimeoutVal = int.Parse(childNode.InnerText);
                                    }
                                    catch
                                    {
                                        // ���ݒ�̏ꍇ�̓f�t�H���g�l���g�p����̂ŁA�����ł͉������Ȃ�
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }

            }
            catch
            {
                // �ݒ�t�@�C�������݂��Ȃ��ꍇ�̓f�t�H���g�l���g�p����̂ŁA�����ł͉������Ȃ�
            }
            finally
            {
                if (xmlDoc != null)
                {
                    xmlDoc = null;
                }
            }

            // ���ݒ�̏ꍇ�A�f�t�H���g�l��ݒ肷��
            //  �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ
            if (String.IsNullOrEmpty(SettingInfo.HtVersionFileDir))
            {
                SettingInfo.HtVersionFileDir = ctDefaultVersionFileDir;
            }
            // �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ
            if (String.IsNullOrEmpty(SettingInfo.RecvFileTempDir))
            {
                SettingInfo.RecvFileTempDir = Path.Combine(CurrentDir, ctDefaiultRecvFileTempDir);
            }
            // �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ
            if (String.IsNullOrEmpty(SettingInfo.SendFileDir))
            {
                SettingInfo.SendFileDir = Path.Combine(CurrentDir, ctDeaultSendFileDir);
            }
            // �N���C�A���g���̐ݒ�t�@�C���̃t�@�C����
            if (String.IsNullOrEmpty(SettingInfo.SettingFileName))
            {
                SettingInfo.SettingFileName = ctDeaultSettingFileName;
            }
            // �o�[�W�������̃t�@�C����
            if (String.IsNullOrEmpty(SettingInfo.VersionFileName))
            {
                SettingInfo.VersionFileName = ctDefaultVersionFileName;
            }
            // �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ
            if (String.IsNullOrEmpty(SettingInfo.HtSettingDir))
            {
                SettingInfo.HtSettingDir = ctDefaultHtSettingDir;
            }
            // �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ
            if (String.IsNullOrEmpty(SettingInfo.SettingBackupDir))
            {
                SettingInfo.SettingBackupDir = Path.Combine(CurrentDir, ctDefaultSettingBackupDir);
            }
            // ��M���̃^�C���A�E�g���ԁi�b�j
            if (SettingInfo.RecvTimeoutVal == -1)
            {
                SettingInfo.RecvTimeoutVal = ctDefaultRecvTimeoutVal;
            }
            // ���M���̃^�C���A�E�g���ԁi�b�j
            if (SettingInfo.SendTimeoutVal == -1)
            {
                SettingInfo.SendTimeoutVal = ctDefaultSendTimeoutVal;
            }
            
            return;

        }
        #endregion


        #region XML�ݒ�t�@�C���쐬����
        /// <summary>
        /// XML�ݒ�t�@�C���쐬����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : XML�ݒ�t�@�C������A�ݒ�����������ޏ������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void MakeSettingFile(string pmXmlPath)
        {
            XmlElement root = null;
            XmlDocument xmldoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", null, null);
            XmlNode xmlNode = xmldoc.CreateNode(XmlNodeType.Element, "UserSettingInfo", "");
            xmldoc.AppendChild(xmlNode);
            xmldoc.InsertBefore(xmlDeclaration, xmlNode);
            root = xmldoc.DocumentElement;

            root.SetAttribute("xmlns:xsi", @"http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", @"http://www.w3.org/2001/XMLSchema");

            XmlElement element = null;

            //  �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_HtVersionFileDir);
            element.InnerText = ctDefaultVersionFileDir;
            root.AppendChild(element);

            // �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_RecvFileTempDir);
            element.InnerText = Path.Combine(CurrentDir, ctDefaiultRecvFileTempDir);
            root.AppendChild(element);

            // �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_SendFileDir);
            element.InnerText = Path.Combine(CurrentDir, ctDeaultSendFileDir);
            root.AppendChild(element);

            // �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_SendSettingFileDir);
            element.InnerText = ctDeaultSendSettingFileDir;
            root.AppendChild(element);

            // �N���C�A���g���̐ݒ�t�@�C���̃t�@�C����
            element = xmldoc.CreateElement(ctElement_SettingFileName);
            element.InnerText = ctDeaultSettingFileName;
            root.AppendChild(element);

            // �o�[�W�������̃t�@�C����
            element = xmldoc.CreateElement(ctElement_VersionFileName);
            element.InnerText = ctDefaultVersionFileName;
            root.AppendChild(element);

            // �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_HtSettingDir);
            element.InnerText = ctDefaultHtSettingDir;
            root.AppendChild(element);

            // �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ
            element = xmldoc.CreateElement(ctElement_SettingBackupDir);
            element.InnerText = Path.Combine(CurrentDir, ctDefaultSettingBackupDir);
            root.AppendChild(element);

            // ��M���̃^�C���A�E�g���ԁi�b�j
            element = xmldoc.CreateElement(ctElement_RecvTimeoutVal);
            element.InnerText = ctDefaultRecvTimeoutVal.ToString();
            root.AppendChild(element);

            // ���M���̃^�C���A�E�g���ԁi�b�j
            element = xmldoc.CreateElement(ctElement_SendTimeoutVal);
            element.InnerText = ctDefaultSendTimeoutVal.ToString();
            root.AppendChild(element);

            // �t�@�C���ɕۑ�����
            xmldoc.Save(pmXmlPath);
        }
        #endregion

        #region �o�[�W�����`�F�b�N����
        /// <summary>
        /// �o�[�W�����`�F�b�N����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �ʏ탁�j���[���[�h�̏������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // �N���C�A���g���̎�M�t�H���_
            string recvPath = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);

            // �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ�Ƀo�[�W�������t�@�C��������΍폜����B
            if (File.Exists(recvPath + SettingInfo.VersionFileName))
            {
                File.Delete(recvPath + SettingInfo.VersionFileName);
            }

            // ��r����
            bool compareResult;
            string[] FileNames = new string[1];
            FileNames[0] = SettingInfo.VersionFileName;
            string[] remotePaths = new string[1];
            remotePaths[0] = SettingInfo.HtVersionFileDir;

            // �o�[�W�������t�@�C����M
            BTCOMM_RESULT result;
            result = pmhnd00802aa.RecvFile(recvPath,
                                    remotePaths,
                                    FileNames,
                                    out errMsg);
            if (result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // �o�[�W�����t�@�C����r����
                compareResult = VersionFileCompare(out errMsg);
            }
            else if (result.Equals(BTCOMM_RESULT.BTCOMM_FILENOTFOUND))
            {
                clVerInfoList.Clear();
                // �o�[�W�������t�@�C�������݂��Ȃ��ꍇ�A�N���C�A���g���ŐV
                // �N���C�A���g���o�[�W�������擾
                bool status = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
                if (!status)
                {
                    if (Mode != PMHND00802AC.VersionCheckMode)
                    {
                        // �G���[���b�Z�[�W���o��
                        errMsg = String.Format("�o�[�W�������̎擾�Ɏ��s���܂����B", result);
                    }
                    return false;
                }

                // �[�����o�[�W�������
                List<PMHND00803AD> htVerInfoList = new List<PMHND00803AD>();

                // �o�[�W������r����
                status = VerInfoCompare(clVerInfoList, htVerInfoList);

                return status;
            }
            else
            {
                if (Mode != PMHND00802AC.VersionCheckMode)
                {
                    // �G���[���b�Z�[�W���o��
                    errMsg = String.Format(errMsg, result);
                }
                return false;
            }

            return compareResult;
        }
        #endregion

        #region �o�[�W�������t�@�C����r����
        /// <summary>
        /// �o�[�W�������t�@�C����r����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �o�[�W�������t�@�C����r�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionFileCompare(out string errMsg)
        {
            // ��r����
            bool status = false;

            errMsg = string.Empty;
            
            // �[�����o�[�W�������t�@�C����
            string htVerFName = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);
            htVerFName = Path.Combine(htVerFName, SettingInfo.VersionFileName);

            // �[�����o�[�W�������
            List<PMHND00803AD> htVerInfoList = new List<PMHND00803AD>();

            // �[�����o�[�W�������t�@�C���Ǎ�����
            bool readStatus = ReadHtVersionFile(htVerFName, ref htVerInfoList);
            if (!readStatus)
            {
                errMsg = "�[�����o�[�W�������t�@�C���Ǎ����s";
                return false;
            }

            // �N���C�A���g���o�[�W�������t�@�C��������΍폜����B
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            // �N���C�A���g���o�[�W�������擾
            clVerInfoList.Clear();
            readStatus = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
            if (!readStatus)
            {
                errMsg = "�N���C�A���g���o�[�W�������擾���s";
                return false;
            }

            // �o�[�W��������r����
            status = VerInfoCompare(clVerInfoList, htVerInfoList);

            return status;
        }
        #endregion

        #region �o�[�W�������t�@�C���Ǎ�����
        /// <summary>
        /// �o�[�W�������t�@�C���Ǎ�����
        /// </summary>
        /// <param name="fileName">�o�[�W�������t�@�C����</param>
        /// <param name="htVerInfoList">�o�[�W������񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �o�[�W�������t�@�C���Ǎ��������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool ReadHtVersionFile(string fileName, ref List<PMHND00803AD> htVerInfoList)
        {
            string errMsg = string.Empty;
            try
            {
                string strBuffer;
                using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("Shift_JIS")))
                {
                    // 1�s�Ǎ�
                    strBuffer = sr.ReadLine();

                    while (strBuffer != null)
                    {
                        // �J���}��؂�ŕ���
                        char[] delimiters = new char[1];
                        delimiters[0] = Delimiter;
                        string[] temp = strBuffer.Split(delimiters);

                        // �o�[�W�������ɒl��ݒ�
                        PMHND00803AD htVerInfo = new PMHND00803AD();
                        htVerInfo.FileName = temp[0].Trim();
                        htVerInfo.ChangeDateTime = DateTime.Parse(temp[1].Trim());
                        htVerInfoList.Add(htVerInfo);

                        // 1�s�Ǎ�
                        strBuffer = sr.ReadLine();
                    }
                }
            }
            catch (Exception exc)
            {
                // �G���[���b�Z�[�W���o��
                errMsg = "�o�[�W�������t�@�C���̓Ǎ��Ɏ��s���܂����B(" + fileName + ")" + exc.Message;
                logger.WriteLog(errMsg);
            }

            return true;
        }
        #endregion

        #region �o�[�W��������r����
        /// <summary>
        /// �o�[�W��������r����
        /// </summary>
        /// <param name="verInfoList1">�o�[�W�������1</param>
        /// <param name="verInfoList2">�o�[�W�������2</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �o�[�W��������r�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VerInfoCompare(List<PMHND00803AD> verInfoList1, List<PMHND00803AD> verInfoList2)
        {
            bool status = false;

            // ���M�t�@�C�����X�g���N���A
            SendFileList.Clear();

            // �N���C�A���g���o�[�W������񃊃X�g�����[�v
            foreach (PMHND00803AD clVerInfo in verInfoList1)
            {
                // �ݒ�t�@�C��������
                if (clVerInfo.fileName.ToLower() == SettingInfo.SettingFileName.ToLower())
                {
                    continue;
                }

                // �t�@�C���L��
                bool isExist = false;
                // �[�����o�[�W�����������[�v
                foreach (PMHND00803AD htVerInfo in verInfoList2)
                {
                    if (clVerInfo.FileName.ToLower() != htVerInfo.FileName.ToLower())
                    {
                        continue;
                    }

                    // �t�@�C���Ȃ�������ɂ���
                    isExist = true;

                    // �N���C�A���g���̍X�V���Ԃ��V�����ꍇ
                    if (clVerInfo.ChangeDateTime.ToString(DateFormat).CompareTo(htVerInfo.ChangeDateTime.ToString(DateFormat)) > 0)
                    {
                        status = true;

                        // ���M�t�@�C�����X�g�ɁA�t�@�C������ǉ�
                        SendFileList.Add(clVerInfo.FileName);
                    }
                    break;
                }
                // �N���C�A���g�ɂ����āAHT�ɂȂ���Α��M�t�@�C�����X�g�ɒǉ�
                if (!isExist)
                {
                    status = true;
                    SendFileList.Add(clVerInfo.FileName);
                }
            }
            return status;
        }
        #endregion

        #region �t�@�C���o�[�W�������擾����
        /// <summary>
        /// �t�@�C���o�[�W�������擾����
        /// </summary>
        /// <param name="path">�o�[�W���������擾����t�@�C�����i�[����Ă���p�X</param>
        /// <param name="verInfoList">�o�[�W������񃊃X�g</param>
        /// <returns>��������</returns>
        /// <remarks>�w�肳�ꂽ�p�X�̃t�@�C���o�[�W�������擾�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool  GetVersionInfo(string path, ref List<PMHND00803AD> verInfoList)
        {
            // �N���C�A���g�����M�t�H���_
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            if (files == null || files.Length == 0)
            {
                return false;
            }
            // �t�@�C�����X�g�Ń��[�v
            foreach (string fileName in files)
            {
                // �t�@�C�����݂̂��擾
                string fName = Path.GetFileName(fileName);

                // �ŏI�X�V���t���擾
                DateTime dateTime = File.GetLastWriteTime(fileName);
                dateTime.AddMilliseconds( -1 * dateTime.Millisecond);

                PMHND00803AD versionInfo = new PMHND00803AD();
                versionInfo.FileName = fName;
                versionInfo.ChangeDateTime = dateTime;
                verInfoList.Add(versionInfo);
            }

            return true;
        }
        #endregion

        #region �T�|�[�g���j���[���[�h����
        /// <summary>
        /// �T�|�[�g���j���[���[�h����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �T�|�[�g���j���[���[�h�̏������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private int SupportModeModeProc(out string errMsg)
        {
            int status = -1;
            errMsg = string.Empty;

            // �u�t�@�C�����t���قȂ�t�@�C���̂ݓ���ւ�����v�Ƀ`�F�b�N���ꂽ�ꍇ�̓���
            if (this.uos_SendDiv.CheckedIndex == 0)
            {
                // �ʏ탁�j���[���[�h�Ɠ�������
                status = FileChange(SendMode.MODE_NORMAL, out errMsg);
            }
            // �u�ݒ�t�@�C���������A�S�Ẵt�@�C������ւ���B�v�Ƀ`�F�b�N���ꂽ�ꍇ�̓���
            if (this.uos_SendDiv.CheckedIndex == 1)
            {
                // �ݒ�t�@�C���������āA�S�Ẵt�@�C�������ւ���
                status = FileChange(SendMode.MODE_NOT_ALL, out errMsg);
            }
            // �u�S�Ẵt�@�C������ւ���B�i���֌�Ƀn���f�B�@��̍Đݒ肪�K�v�j�v�Ƀ`�F�b�N���ꂽ�ꍇ�̓���
            if (this.uos_SendDiv.CheckedIndex == 2)
            {
                // �S�Ẵt�@�C�������ւ���
                status = FileChange(SendMode.MODE_ALL, out errMsg);
            }
            return status;
        }
        #endregion

        #region �t�@�C������ւ�����
        /// <summary>
        /// �t�@�C������ւ�����
        /// </summary>
        /// <param name="mode">�������[�h</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �t�@�C������ւ��̏������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private int FileChange(SendMode mode,out string errMsg)
        {
            int status = -1;
            errMsg = string.Empty;

            // �S�t�@�C���̃t�@�C�����̃��X�g���쐬
            string[] files;
            string[] fNames;
            string[] remotePath;

            // �N���C�A���g���o�[�W�������t�@�C��������΍폜����B
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            if (mode == SendMode.MODE_NORMAL)
            {
                // ������������̑J�ڂłȂ��ꍇ�A�o�[�W�����`�F�b�N���s��
                if (this.isSending)
                {
                    // �o�[�W�����`�F�b�N
                    // �ŐV�̃o�[�W�����łȂ��ꍇ�A�u�ŐV�̃t�@�C�����K�p�ς݂ł��B�v�̃��b�Z�[�W��\��
                    bool isNewVersion = VersionCheck(out errMsg);
                    if (!isNewVersion)
                    {
                        if (errMsg != string.Empty) return status;

                        this.messageLabel.Text = AllreadyNewVerMsg;
                        status = 0;
                        return status;
                    }
                }

                // ���M�t�@�C���̃��X�g�Ń��[�v����
                List<string> newSendFileList = new List<string>();
                foreach (string filename in SendFileList)
                {
                    // �ݒ�t�@�C��������
                    if (filename.ToLower() == SettingInfo.SettingFileName.ToLower())
                    {
                        continue;
                    }

                    // �g���q�擾
                    string ext = Path.GetExtension(filename);

                    if (ext.ToLower() == IniFileExtension)
                    {
                        newSendFileList.Add(SettingInfo.SendSettingFileDir + filename);
                    }
                    else
                    {
                        newSendFileList.Add(filename);
                    }
                }

                // �o�[�W�������t�@�C����ǉ�
                newSendFileList.Add(SettingInfo.VersionFileName);

                fNames = newSendFileList.ToArray();

                remotePath = new string[newSendFileList.Count];
                for (int ii = 0; ii < fNames.Length; ii++)
                {
                    remotePath[ii] = SettingInfo.HtVersionFileDir;
                }
            }
            else
            {
                // ���M�t�@�C�����X�g���N���A
                SendFileList.Clear();

                // �S�t�@�C���̃t�@�C�����̃��X�g���쐬
                files = Directory.GetFiles(SettingInfo.SendFileDir, "*", SearchOption.AllDirectories);
                fNames = new string[files.Length + 1];
                remotePath = new string[files.Length + 1];

                int ii = 0;
                foreach (string fName in files)
                {
                    if (mode == SendMode.MODE_NOT_ALL)
                    {
                        // �ݒ�t�@�C��������
                        if (Path.GetFileName(fName).ToLower() == SettingInfo.SettingFileName.ToLower())
                        {
                            continue;
                        }
                    }
                    // �g���q�擾
                    string ext = Path.GetExtension(fName);

                    if (ext.ToLower() == IniFileExtension)
                    {
                        fNames[ii] = SettingInfo.SendSettingFileDir + Path.GetFileName(fName);
                    }
                    else
                    {
                        fNames[ii] = Path.GetFileName(fName);
                    }
                    remotePath[ii] = SettingInfo.HtVersionFileDir;
                    // ���M�t�@�C�����X�g�ɒǉ�
                    SendFileList.Add(fNames[ii]);

                    ii++;
                }

                // �o�[�W�������t�@�C��
                fNames[ii] = SettingInfo.VersionFileName;
                remotePath[ii] = SettingInfo.HtVersionFileDir;

                if (mode == SendMode.MODE_NOT_ALL)
                {
                    // �ݒ�t�@�C���̗̈�폜
                    ii++;

                    Array.Resize(ref fNames, ii);
                    Array.Resize(ref remotePath, ii);
                }
                else if (mode == SendMode.MODE_ALL)
                {
                    // �ݒ�t�@�C���̃o�b�N�A�b�v
                    bool sfbStatus = SettingFileBackup(out errMsg);
                }
            }

            // �o�[�W�������t�@�C���쐬
            bool creStatus = VersionFileCreate();
            if (!creStatus)
            {
                errMsg = "�o�[�W�������t�@�C���̍쐬�Ɏ��s���܂����B";
                return status;
            }

            // �t�@�C���𑗐M
            BTCOMM_RESULT result = pmhnd00802aa.SendFile(SettingInfo.SendFileDir, SettingInfo.SendSettingFileDir, remotePath, fNames, out errMsg);
            if (!result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // �G���[���b�Z�[�W��\��
                return status;
            }

            // ���M�t�@�C�����X�g���N���A
            SendFileList.Clear();

            // �N���C�A���g���o�[�W�������t�@�C��������΍폜����B
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            status = 0;

            // �v���O�����̓��ւ��������܂����B
            this.messageLabel.Text = CompProgChgMsg;

            return status;
        }
        #endregion

        #region �ݒ�t�@�C���o�b�N�A�b�v����
        /// <summary>
        /// �ݒ�t�@�C���o�b�N�A�b�v����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �ݒ�t�@�C���o�b�N�A�b�v�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool SettingFileBackup(out string errMsg)
        {
            // �N���C�A���g���̎�M�t�H���_
            string recvPath = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);

            // �ݒ�t�@�C�����X�g
            List<string> iniFileList = new List<string>();

            // ���M�t�@�C�����X�g����A�ݒ�t�@�C���𒊏o
            foreach (string filename in SendFileList)
            {
                string extension = Path.GetExtension(filename);
                if (extension.ToLower() == IniFileExtension)
                {
                    iniFileList.Add(Path.GetFileName(filename));
                }
            }

            string[] remotePaths = new string[iniFileList.Count];
            for (int ii = 0; ii < remotePaths.Length; ii++ )
            {
                remotePaths[ii] = SettingInfo.HtSettingDir;
            }

            string[] fileNames = iniFileList.ToArray();

            // �t�@�C����M
            BTCOMM_RESULT result;
            result = pmhnd00802aa.RecvFile(recvPath,
                                    remotePaths,
                                    fileNames,
                                    out errMsg);
            if (result.Equals(BTCOMM_RESULT.BTCOMM_OK) )
            {
                // ����I���̏ꍇ
                // �o�b�N�A�b�v�t�H���_�փR�s�[
                // �o�b�N�A�b�v�t�H���_�쐬
                DateTime now = DateTime.Now;
                // �o�b�N�A�b�v��t�H���_�̉��ɓ��t�t�H���_���쐬
                string bkupdir = Path.Combine(SettingInfo.SettingBackupDir, now.ToString(DateFormat));
                Directory.CreateDirectory(bkupdir);

                for (int ii = 0; ii < fileNames.Length; ii++)
                {
                    string sourceFile = SettingInfo.RecvFileTempDir + fileNames[ii];
                    string destFile = Path.Combine(bkupdir, fileNames[ii]);
                    File.Move(sourceFile, destFile);
                }

                return true;
            }
            else if (result.Equals(BTCOMM_RESULT.BTCOMM_FILENOTFOUND))
            {
                // �t�@�C�������̏ꍇ�A�R�s�[�����ɐ���I������
                return true;
            }

            return false;
        }
        #endregion

        #region �o�[�W�������t�@�C���쐬����
        /// <summary>
        /// �o�[�W�������t�@�C���쐬����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �o�[�W�������t�@�C���쐬�������s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionFileCreate()
        {
            // �N���C�A���g���o�[�W�������擾
            clVerInfoList.Clear();
            bool readStatus = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
            if (!readStatus)
            {
                //errMsg = "�N���C�A���g���o�[�W�������擾���s";
                return readStatus;
            }

            // �o�[�W�������t�@�C����
            string verFName = Path.Combine(SettingInfo.SendFileDir, SettingInfo.VersionFileName);

            // �o�[�W�������t�@�C���쐬
            using (StreamWriter sw = new StreamWriter(verFName, false, Encoding.GetEncoding("Shift_jis")))
            {
                foreach (PMHND00803AD verInfo in clVerInfoList)
                {
                    string lineBuffer = string.Empty;
                    lineBuffer += verInfo.FileName + Delimiter;
                    lineBuffer += verInfo.ChangeDateTime.ToString();
                    sw.WriteLine(lineBuffer);
                }
            };

            return true;
        }
        #endregion
        #endregion

    }
}