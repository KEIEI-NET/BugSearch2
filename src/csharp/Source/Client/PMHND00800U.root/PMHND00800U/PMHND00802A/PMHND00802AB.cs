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
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HT�v���O���������ݒ�t�@�C�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : HT�v���O���������ݒ�t�@�C�����N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : �X�R�@�_</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00802AB
    {

        #region << private�ϐ� >>

        /// <summary>
        /// �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ
        /// </summary>
        public static string versionFileDir;

        /// <summary>
        /// �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ
        /// </summary>
        public static string recvFileTempDir;

        /// <summary>
        /// �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ
        /// </summary>
        /// 
        public static string sendFileDir;
        /// <summary>
        /// �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ
        /// </summary>
        public static string sendSettingFileDir;

        /// <summary>
        /// �N���C�A���g���̐ݒ�t�@�C���̃t�@�C����
        /// </summary>
        public static string settingFileName;

        /// <summary>
        /// �o�[�W�������̃t�@�C����
        /// </summary>
        public static string versionFileName;

        /// <summary>
        /// �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ
        /// </summary>
        public static string htSettingDir;

        /// <summary>
        /// �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ
        /// </summary>
        public static string settingBackupDir;

        /// <summary>
        /// ��M���̃^�C���A�E�g���ԁi�b�j
        /// </summary>
        public static int recvTimeoutVal = -1;

        /// <summary>
        /// ���M���̃^�C���A�E�g���ԁi�b�j
        /// </summary>
        public static int sendTimeoutVal = -1;

        #endregion

        /// public propaty name  :  HtVersionFileDir
        /// <summary>�n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���f�B�^�[�~�i�����̃o�[�W�����t�@�C���ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HtVersionFileDir
        {
            get { return versionFileDir; }
            set { versionFileDir = value; }
        }

        /// public propaty name  :  RecvFileTempDir
        /// <summary>�N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���C�A���g���̎�M�t�@�C���ꎞ�ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RecvFileTempDir
        {
            get { return recvFileTempDir; }
            set { recvFileTempDir = value; }
        }

        /// public propaty name  :  SendFileDir
        /// <summary>�N���C�A���g���̑��M�t�@�C���ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���C�A���g���̑��M�t�@�C���ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendFileDir
        {
            get { return sendFileDir; }
            set { sendFileDir = value; }
        }

        /// public propaty name  :  SendSettingFileDir
        /// <summary>�N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���C�A���g���̐ݒ�t�@�C���ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendSettingFileDir
        {
            get { return sendSettingFileDir; }
            set { sendSettingFileDir = value; }
        }

        /// public propaty name  :  SettingFileName
        /// <summary>�N���C�A���g���̐ݒ�t�@�C���̃t�@�C����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���C�A���g���̐ݒ�t�@�C���̃t�@�C����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SettingFileName
        {
            get { return settingFileName; }
            set { settingFileName = value; }
        }

        /// public propaty name  :  VersionFileName
        /// <summary>�o�[�W�������̃t�@�C����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�[�W�������̃t�@�C����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string VersionFileName
        {
            get { return versionFileName; }
            set { versionFileName = value; }
        }

        /// public propaty name  :  HtSettingDir
        /// <summary>�n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���f�B�^�[�~�i�����̐ݒ�t�@�C���ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HtSettingDir
        {
            get { return htSettingDir; }
            set { htSettingDir = value; }
        }
        /// public propaty name  :  SettingBackupDir
        /// <summary>�ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݒ�t�@�C���̃o�b�N�A�b�v�ۑ��ꏊ</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SettingBackupDir
        {
            get { return settingBackupDir; }
            set { settingBackupDir = value; }
        }
        /// public propaty name  :  RecvTimeoutVal
        /// <summary>��M���̃^�C���A�E�g���ԁi�b�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M���̃^�C���A�E�g���ԁi�b�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int RecvTimeoutVal
        {
            get { return recvTimeoutVal; }
            set { recvTimeoutVal = value; }
        }
        /// public propaty name  :  SendTimeoutVal
        /// <summary>���M���̃^�C���A�E�g���ԁi�b�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M���̃^�C���A�E�g���ԁi�b�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int SendTimeoutVal
        {
            get { return sendTimeoutVal; }
            set { sendTimeoutVal = value; }
        }

    }
}
