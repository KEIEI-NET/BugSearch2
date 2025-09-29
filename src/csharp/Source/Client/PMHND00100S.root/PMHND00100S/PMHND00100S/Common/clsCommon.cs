//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PMNS-HTT�ʐM�T�[�r�X
// �v���O�����T�v   : PMNS-HTT�Ԃ̒ʐM���s���T�[�r�X�v���O�����ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : �����@�q�V
// �� �� ��  2017/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11575094-00 �쐬�S�� : �݁@��
// �� �� ��  2019/06/13  �C�����e : �单����i��Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00 �쐬�S�� : ���X  �Ė�
// �C �� ��  2019/10/16  �C�����e : �U���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ���X  �Ė�
// �C �� ��  2020/04/01  �C�����e : �n���f�B�d���ꎞ�݌ɓo�^�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using log4net;

namespace PMHND00100S.Common
{
    /// public class name:   clsCommon
    /// <summary>
    ///                      ���ʎg�p����ϐ���`�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �v���W�F�N�g���ŋ��ʎg�p����O���[�o���ϐ����`����</br>
    /// <br>Programmer       :   �����@�q�V</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    class clsCommon
    {

#region "�萔"

#endregion

#region "�ϐ�"

        /// <summary>����</summary>
        public static string gArgs = string.Empty;

        /// <summary>�ݒ�t�@�C���@�n���f�B�Ƃ̃\�P�b�g�ʐM�@�h�o�A�h���X</summary>
        public static string gIpAddress = "192.168.0.0";

        /// <summary>�ݒ�t�@�C���@�n���f�B�Ƃ̃\�P�b�g�ʐM�@�|�[�g</summary>
        public static Int32 gSocketPort = 20024;

        /// <summary>�ݒ�t�@�C���@���O�̏o�͔���</summary>
        public static String gDebugDetailLog = "on";

        /// <summary>�h�o�b�A�h���X</summary>
        public static string gIpcAddress = "ipc://PmHandyChannel/PmHandyService";

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>���g���C��</summary>
        public static string gRetryTimes = "3";
        /// <summary>���g���C�Ԋu</summary>
        public static string gRetryInterval = "100";
        // --- ADD 2019/06/13 ----------<<<<<

        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�̃o�b�t�@�T�C�Y</summary>
        public static Int32 gSocketBufferSiz = 500000;
        // -- ADD 2019/10/16 ------------------------------<<<
#endregion

#region "�֐�"
        /// <summary>
        /// �����񂩂�o�C�g�����w�肵�ĕ�����������擾����B
        /// </summary>
        /// <param name="value">�Ώە�����B</param>
        /// <param name="startIndex">�J�n�ʒu�B0�`�i�o�C�g���j</param>
        /// <param name="length">�����B�i�o�C�g���j</param>
        /// <returns>����������B</returns>
        /// <remarks>������� <c>Shift_JIS</c> �ŃG���R�[�f�B���O���ď������s���܂��B</remarks>
        public static string MidB(string value, Int32 startIndex, Int32 length)
        {

            System.Text.Encoding sjisEnc = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] byteArray = sjisEnc.GetBytes(value);

            if (byteArray.Length < startIndex + 1)
            {
                return "";
            }

            if (byteArray.Length < startIndex + length)
            {
                length = byteArray.Length - startIndex;
            }

            string cut = sjisEnc.GetString(byteArray, startIndex, length);

            // �ŏ��̕������S�p�̓r���Ő؂�Ă����ꍇ�͂P�����؂�グ��
            string left = sjisEnc.GetString(byteArray, 0, startIndex + 1);
            char first = value[left.Length - 1];
            if (0 < cut.Length && !(first == cut[0]))
            {
                //cut = cut.Substring(1)   '�ŏ��̕������S�p�̓r���Ő؂�Ă����ꍇ�̓J�b�g
                cut = sjisEnc.GetString(byteArray, startIndex - 1, length);
            }

            // �Ō�̕������S�p�̓r���Ő؂�Ă����ꍇ�̓J�b�g
            left = sjisEnc.GetString(byteArray, 0, startIndex + length);

            char last = value[left.Length - 1];
            if (0 < cut.Length && !(last == cut[cut.Length - 1]))
            {
                cut = cut.Substring(0, cut.Length - 1);
            }

            return cut;

        }

        /// <summary>
        /// �����񂩂�o�C�g�����w�肵�ČŒ蒷�������Ԃ��B
        /// </summary>
        /// <param name="value">�Ώە�����B</param>
        /// <param name="length">�����B�i�o�C�g���j</param>
        /// <returns>�Œ蒷������B</returns>
        /// <remarks>������� <c>Shift_JIS</c> �ŃG���R�[�f�B���O���ď������s���܂��B</remarks>
        public static string FixB(string value, Int32 length)
        {
            System.Text.Encoding sjisEnc = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] byteArray = sjisEnc.GetBytes(value);

            Int32 sublength = length;

            if (byteArray.Length < length)
            {
                sublength = byteArray.Length;
            }

            string fixSt = sjisEnc.GetString(byteArray, 0, sublength);

            if (sublength != 0)
            {
                // �ŏ��̕������S�p�̓r���Ő؂�Ă����ꍇ�͂P�����؂�グ��
                string left = sjisEnc.GetString(byteArray, 0, 1);
                char first = value[left.Length - 1];
                if (0 < fixSt.Length && !(first == fixSt[0]))
                {
                    //fixSt = fixSt.Substring(1)   '�ŏ��̕������S�p�̓r���Ő؂�Ă����ꍇ�̓J�b�g
                    fixSt = sjisEnc.GetString(byteArray, -1, sublength);
                }

                // �Ō�̕������S�p�̓r���Ő؂�Ă����ꍇ�̓J�b�g
                left = sjisEnc.GetString(byteArray, 0, 0 + sublength);

                char last = value[left.Length - 1];
                if (0 < fixSt.Length && !(last == fixSt[fixSt.Length - 1]))
                {
                    fixSt = fixSt.Substring(0, fixSt.Length - 1);
                }
            }

            byteArray = sjisEnc.GetBytes(fixSt);

            if (byteArray.Length < length)
            {
                string stLen = (-1 * length).ToString();
                fixSt = String.Format("{0, " + stLen + "}", fixSt);
            }

            return fixSt;

        }

        /// <summary>
        /// log4net�ł̃��O�o�͏���
        /// </summary>
        /// <param name="LOGGER"></param>
        /// <param name="logKbn">���O�o�̓��x��</param>
        /// <param name="message">���O�o�͓��e</param>
        public static void writeLog4(ILog LOGGER, clsBtConst.enumLOG4_KBN logKbn, string message)
        {
            //log4���W�b�N�̎��s���f
            if (clsCommon.gDebugDetailLog == clsBtConst.DEBUG_DETAIL_LOG_ON)
            {
                //���O�o�̓��x���ŏo�͓��e�̐؂�ւ�
                switch (logKbn) 
                { 
                    case clsBtConst.enumLOG4_KBN.FATAL:
                        LOGGER.Fatal(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.ERROR:
                        LOGGER.Error(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.WARN:
                        LOGGER.Warn(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.INFO:
                        LOGGER.Info(message);
                        break;

                    case clsBtConst.enumLOG4_KBN.DEBUG:
                        LOGGER.Debug(message);
                        break;
                }
            }
        }

        /// <summary>
        /// ���t�t�H�[�}�b�g�iDateTime�^ �� yyyyMMdd�j
        /// </summary>
        /// <param name="strTarget">�����Ώە�����</param>
        /// <returns>yyyy/MM/dd�̕������ԋp����</returns>
        /// <remarks></remarks>
        public static string datFormat(DateTime dtmTarget)
        {
            try
            {
                string strBuf = "";

                //�����l
                if ((dtmTarget == new DateTime()) || (dtmTarget == new DateTime(0)))
                {
                    strBuf = setMaeSpace(" ", 8);
                    return strBuf;
                }

                strBuf = dtmTarget.ToString("yyyyMMdd");

                return strBuf;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                //�V�X�e���G���[
                //frmMsgBoxMulti.showMsgBox(clsMsgConst.MSG_ALL_SYS_ERR + ex.Message);
                return dtmTarget.ToString();
            }
        }

        /// <summary>
        /// �O�X�y�[�X����
        /// </summary>
        /// <param name="target"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string setMaeSpace(string target, Int32 len)
        {
            string strTarget = target;
            //������菭�Ȃ��ꍇ
            if (target.Length < len)
            {
                Int32 iCnt = 0;
                //0���ߏ���
                for (iCnt = 0; iCnt <= len - target.Length - 1; iCnt++)
                {
                    strTarget = " " + strTarget;
                }
            }
            return strTarget;
        }

        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="target"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string setMaeZero(Int32 target, Int32 len)
        {
            string RetVal = target.ToString("00;-#");

            return RetVal;
        }

        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>
        /// NULL or �󕶎���̔���
        /// </summary>
        /// <param name="varBuf">�����Ώۂ̒l</param>
        /// <returns>True:Null or �󕶎���AFalse:Not Null or Not �󕶎���</returns>
        /// <remarks></remarks>
        public static bool gIsNull(object varBuf)
        {
            bool functionReturnValue = false;
            functionReturnValue = false;
            if (varBuf == null)
            {
                functionReturnValue = true;
            }
            else if (varBuf.ToString().Trim().Length == 0)
            {
                functionReturnValue = true;
            }
            return functionReturnValue;
        }

        /// <summary>
        /// NULL Value ���󕶎���("")�ɕϊ�
        /// </summary>
        /// <param name="varBuf">�����Ώۂ̒l</param>
        /// <returns>String</returns>
        /// <remarks>�����̕����� Null Value �̏ꍇ�󕶎����Ԃ�(��L�ȊO�͈����̒l�����ݸނ��ĕԂ�)</remarks>
        public static string gNullToStr(object varBuf)
        {
            string functionReturnValue = null;
            if (gIsNull(varBuf) == true)
            {
                functionReturnValue = "";
            }
            else
            {
                functionReturnValue = varBuf.ToString().Trim();
            }
            return functionReturnValue;
        }
        // -- ADD 2020/04/01 ------------------------------<<<

#endregion

    }
}
