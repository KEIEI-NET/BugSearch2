//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : HT�v���O������������
// �v���O�����T�v   : HT�v���O������������ �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �X�R�@�_
// �� �� ��  2017/12/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    using BTCOMM_HHT = System.Int32;

    /// <summary>
    /// HT�v���O�������������A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : HT�v���O�������������A�N�Z�X�N���X</br>
    /// <br>Programmer : �X�R�_</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00802AA
    {

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region �R���X�g Memebers

        /// <summary>
        /// MAX_PATH
        /// </summary>
        private static int MAX_PATH = 260;

        #endregion

        // ===================================================================================== //
        // ���O�o�̓��b�Z�[�W
        // ===================================================================================== //
        #region �o�̓��b�Z�[�W
        private static string LogMsgSrchTtErr = "�n���f�B�^�[�~�i���̌����Ɏ��s���܂����B�i�G���[�R�[�h�F{0}�j";

        private static string LogMsgNoHt = "�n���f�B�^�[�~�i�����ڑ�����Ă��܂���B\n�d���I�t�ɂ��ĒʐM���j�b�g�ɐڑ����A�u���M�v�{�^���������Ă��������B";

        private static string LogMsgSrchHtInfoErr = "�n���f�B�^�[�~�i���̌����i���擾�j�Ɏ��s���܂����B";

        private static string LogMsgCreHtHandleErr = "�g�s�n���h�������Ɏ��s���܂����B";

        private static string LogMsgConHtErr = "�n���f�B�^�[�~�i���Ƃ̐ڑ��Ɏ��s���܂����B�i�G���[�R�[�h�F{0}�j";

        private static string LogMsgGetVerFileErr = "�o�[�W�����t�@�C���̎擾�Ɏ��s���܂����B�i�G���[�R�[�h�F{0}�j";

        private static string LogMsgDisconnectErr = "�n���f�B�^�[�~�i���Ƃ̐ڑ������Ɏ��s���܂����B�i�G���[�R�[�h�F{0}�j";

        private static string LogMsgCloseHtHandleErr = "�g�s�n���h���̊J���Ɏ��s���܂����B";

        private static string LogMsgSendFileErr = "�t�@�C���̑��M�Ɏ��s���܂����B�i�G���[�R�[�h�F{0}�j";

        private static string LogMsgSendInCompleteErr = "�t�@�C���̑��M�Ɏ��s���܂����B\n�n���f�B�^�[�~�i���̃��O�C����ʂ��I�����A�u���M�v�{�^���������Ă��������B";

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �v���C�x�[�g Members

        /// <summary>
        /// ���K�[
        /// </summary>
        PMHND00804AE logger = null;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �v���p�e�B Members

        /// <summary>XML�ݒ�t�@�C�����</summary>
        public PMHND00802AB settingInfo;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="settingInfo">�ݒ�t�@�C�����</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public PMHND00802AA(PMHND00802AB settingInfo)
        {
            this.settingInfo = settingInfo;
            logger = PMHND00804AE.getInstance();
        }
        #endregion

        #region Public Method

        #region �t�@�C�����M����
        /// <summary>
        ///	�t�@�C�����M����
        /// </summary>
        /// <param name="sendPath">�N���C�A���g���̑��M�p�t�@�C���̃t�H���_��</param>
        /// <param name="remotePath">�[�����̃p�X</param>
        /// <param name="fileNames">���M����t�@�C�����̃��X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note	   : �t�@�C���̃n���f�B�[���ւ̑��M���s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public unsafe BTCOMM_RESULT SendFile(string sendPath, string sendSettingPath, string[] remotePath, string[] fileNames, out string errMsg)
        {
            int ht_num;
            bool status;

            errMsg = string.Empty;

            // �n���f�B�^�[�~�i����������
            BTCOMM_RESULT result = SearchHT(out ht_num, out errMsg);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                return result;
            }

            // ���������䐔�������[�������擾���A�t�@�C����]������
            for (int i = 0; i < ht_num; i++)
            {
                BTCOMM_HHT hHT = 0;

                // �����Ƀq�b�g�����[���̒[�������擾���AHT�n���h�����쐬���A�ڑ�����
                result = CreateHT(true, sendPath, ".\\", settingInfo.SendTimeoutVal, ref hHT, out errMsg);
                if (result == BTCOMM_RESULT.BTCOMM_OK)
                {
                    for (int ii = 0; ii < fileNames.Length; ii++)
                    {
                        string localfile = fileNames[ii];
                        string remotefile = remotePath[ii] + fileNames[ii];

                        // �t�@�C�����M
                        result = btcommclass.btcommPutFile(hHT, localfile, remotefile, settingInfo.SendTimeoutVal);
                        if (result != BTCOMM_RESULT.BTCOMM_OK)
                        {
                            // �t�@�C�����M�Ɏ��s������G���[���b�Z�[�W���o��
                            errMsg = String.Format(LogMsgSendFileErr, result);
                            if (result == BTCOMM_RESULT.BTCOMM_INCOMPLETE)
                            {
                                // �t�@�C�����M�Ɏ��s������G���[���b�Z�[�W���o��
                                errMsg = String.Format(LogMsgSendInCompleteErr, result);
                            }
                            break;
                        }
                    }

                    // �ڑ���ؒf���AHT�n���h�����������
                    status = CloseHT(hHT, settingInfo.SendTimeoutVal, ref errMsg);
                    if (!(status))
                    {
                        result = BTCOMM_RESULT.BTCOMM_OTHER;
                        break;
                    }
                }
            }

            return result;

        }
        #endregion

        #region �t�@�C����M����
        /// <summary>
        ///	�t�@�C����M����
        /// </summary>
        /// <param name="recvPath">��M�t�H���_��</param>
        /// <param name="remotePath">�[�����p�X</param>
        /// <param name="fileNames">�t�@�C�������X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note	   : �t�@�C���̃n���f�B�[������̎�M���s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public unsafe BTCOMM_RESULT RecvFile(string recvPath, string[] remotePaths, string[] fileNames, out string errMsg)
        {
            int ht_num;

            string[] localfiles = fileNames;
            string[] remotefiles = new string[fileNames.Length];

            errMsg = string.Empty;

            for (int ii = 0; ii < fileNames.Length; ii++)
            {
                remotefiles[ii] = remotePaths[ii] + fileNames[ii];
            }
            
            // �n���f�B�^�[�~�i����������
            BTCOMM_RESULT result = SearchHT(out ht_num, out errMsg);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                return result;
            }

            // ���������䐔�������[�������擾���A�t�@�C����]������
            for (int i = 0; i < ht_num; i++)
            {
                bool status = false;
                BTCOMM_HHT hHT = 0;

                // �����Ƀq�b�g�����[���̒[�������擾���AHT�n���h�����쐬���A�ڑ�����
                result = CreateHT(false, ".\\", recvPath, settingInfo.RecvTimeoutVal, ref hHT, out errMsg);
                if (result == BTCOMM_RESULT.BTCOMM_OK)
                {
                    for (int jj = 0; jj < fileNames.Length; jj++)
                    {
                        result = btcommclass.btcommGetFile(hHT, remotefiles[jj], localfiles[jj], settingInfo.RecvTimeoutVal);
                        if (result != BTCOMM_RESULT.BTCOMM_OK && result != BTCOMM_RESULT.BTCOMM_FILENOTFOUND)
                        {
                            // �G���[�ł����̃t�@�C����M�ł��邩������Ȃ��̂ŁA�������s
                            errMsg = string.Format(LogMsgGetVerFileErr, result);
                            break;
                        }
                    }

                    // �ڑ���ؒf���AHT�n���h�����������
                    status = CloseHT(hHT, settingInfo.RecvTimeoutVal, ref errMsg);
                    if (!(status))
                    {
                        result = BTCOMM_RESULT.BTCOMM_OTHER;
                        break;
                    }
                }
            }

            return result;

        }
        #endregion

        #region �n���f�B�[�����ʏ���
        /// <summary>
        /// �n���f�B�[����������
        /// </summary>
        /// <param name="_ht_num"></param>
        /// <param name="_errMsg"></param>
        /// <remarks>
        /// <br>Note	   : �|�[�g����n���f�B�[������������</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private unsafe BTCOMM_RESULT SearchHT(out int _ht_num, out string _errMsg)
        {
            int ht_num;
            _ht_num = 0;
            _errMsg = string.Empty;

            // COM�|�[�g����[������������B
            // (USB�|�[�g����[������������Ƃ���BTCOMM_CRADLE_USBALL�A
            //  LAN�u���䂩��[������������Ƃ���BTCOMM_CRADLE_LANALL(�u_IPADRS.TXT�v���K�v)�A
            //  �����[�����猟������Ƃ���BTCOMM_TERM_WLANALL��_���a�Őݒ肷��)
            BTCOMM_RESULT result = btcommclass.btcommSearchHT(IntPtr.Zero, 0, btcommclass.BTCOMM_CRADLE_USBALL, &ht_num);
            if (result == BTCOMM_RESULT.BTCOMM_OK)
            {
                if (ht_num == 0)
                {
                    _errMsg = LogMsgNoHt;
                    result = BTCOMM_RESULT.BTCOMM_OTHER;
                }
                _ht_num = ht_num;
            }
            else
            {
                _errMsg = string.Format(LogMsgSrchTtErr, result);
            }

            return result;
        }

        /// <summary>
        /// �n���f�B�[���ڑ�����
        /// </summary>
        /// <param name="dispFlg">1�F��M�A2�F���M</param>
        /// <param name="sendPath"></param>
        /// <param name="recvPath"></param>
        /// <param name="timeoutVal"></param>
        /// <param name="hHT"></param>
        /// <remarks>
        /// <br>Note	   : ���������n���f�B�[����ڑ�����</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private BTCOMM_RESULT CreateHT(bool dispFlg, string sendPath, string recvPath, int timeoutVal, ref BTCOMM_HHT hHT, out string errMsg)
        {
            errMsg = string.Empty;
            bool status;
            BTCOMM_RESULT result;
            BTCOMM_HTInfo info;

            // �����Ƀq�b�g�����[���̒[�������擾���AHT�n���h�����쐬���A�ڑ�����
            status = btcommclass.btcommGetHTNext(out info);
            if (!status)
            {
                errMsg = LogMsgSrchHtInfoErr;
                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            BTCOMM_Param param = new BTCOMM_Param();
            param.hWnd = IntPtr.Zero;	// �C�x���g�z�M��͓����^�Ȃ̂�NULL
            param.dwMsgID = 0;	        // �C�x���gID�͓����^�Ȃ̂�NULL
            param.strSendPath = StringToCharArray(sendPath, MAX_PATH);	// �t�@�C�����M���̃J�����g�t�H���_�̓J�����g�t�H���_
            param.strRecvPath = StringToCharArray(recvPath, MAX_PATH);	// �t�@�C����M���̃J�����g�t�H���_�̓J�����g�t�H���_
            param.bDispDialog = dispFlg;    // �ʐM���̃_�C�A���O��\������
            param.bSetTime = true;	        // �[���̎�����PC�ɍ��킹��

            hHT = btcommclass.btcommCreateHTHandle(ref info, ref param);
            if (hHT == 0)
            {
                errMsg = LogMsgCreHtHandleErr;
                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            result = btcommclass.btcommConnect(hHT, timeoutVal);
            if (!result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // �ڑ���Ԃɖ���������G���[���b�Z�[�W���o��
                errMsg = String.Format(LogMsgConHtErr, result);

                return BTCOMM_RESULT.BTCOMM_OTHER;
            }

            return BTCOMM_RESULT.BTCOMM_OK;
        }

        /// <summary>
        /// �n���f�B�[���ڑ��ؒf/�������
        /// </summary>
        /// <param name="hHT"></param>
        /// <param name="timeoutVal"></param>
        /// <remarks>
        /// <br>Note	   : �n���f�B�[������ڑ���ؒf���AHT�n���h�����������</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool CloseHT(BTCOMM_HHT hHT, int timeoutVal, ref string errMsg)
        {
            bool status = false;

            // �ڑ���ؒf���AHT�n���h�����������
            BTCOMM_RESULT result = btcommclass.btcommDisconnect(hHT, timeoutVal);
            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                if (errMsg != string.Empty) errMsg += "\n";
                errMsg += string.Format(LogMsgDisconnectErr, result);
            }

            status = btcommclass.btcommCloseHTHandle(hHT);
            if (!status)
            {
                if (errMsg != string.Empty) errMsg += "\n";
                errMsg += LogMsgCloseHtHandleErr;
            }

            if (result != BTCOMM_RESULT.BTCOMM_OK)
            {
                status = false;
            }

            return status;
        }

        #endregion

        #region ������char�z��ϊ�����
        /// <summary>
        ///	������char�z��ϊ�����
        /// </summary>
        /// <param name="str">�ϊ��O������</param>
        /// <param name="size">�ϊ���z��̃T�C�Y</param>
        /// <returns>�ϊ����char�z��</returns>
        /// <remarks>
        /// <br>Note	   : �������char�̔z��ɕϊ����鏈�����s���܂��B</br>
        /// <br>Programmer : �X�R�@�_</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private char[] StringToCharArray(string str, int size)
        {
            char[] dstCharArray = new char[size];
            char[] srcCharArray = str.ToCharArray();
            for (int ii = 0; ii < size; ii++)
            {
                char cc = (Char)0x00;
                if (ii < srcCharArray.Length)
                {
                    cc = srcCharArray[ii];
                }
                dstCharArray[ii] = cc;
            }
            return dstCharArray;
        }
        #endregion

        #endregion
    
    }
}
