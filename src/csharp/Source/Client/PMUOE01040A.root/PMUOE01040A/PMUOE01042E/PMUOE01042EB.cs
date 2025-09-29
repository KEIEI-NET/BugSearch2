//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���ʏ����N���X
// �v���O�����T�v   : �t�n�d���ʏ����̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e : �y�v��No.2�z
//                                  ������Ƀg���^���w�莞�ɂ́A���}�[�N�Q�̓��͕͂s�Ƃ���i�A�g���A�ϰ�2�ɘA�g�ԍ��Ƃ��Ďg�p����ׁj																																							
// 	                                �d�����ׁi�����f�[�^�j�̍쐬���s���ʐM�͍s��Ȃ��l�ɂ���			
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e : �y�v��No.3�z
//                                  ������̓��͐���i�g���^�͓��͕s�Ƃ���j���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �k���r
// �� �� ��  2010/03/08  �C�����e : PM1006 
//                                  UOE�����悪�u���Y�v�̏ꍇ�AUOE�����f�[�^�݂̂��쐬���A�ʐM�͍s��Ȃ��悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : gaoyh
// �� �� ��  2010/04/26  �C�����e : PM1007C �O�HUOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : liyp
// �� �� ��  2011/01/06  �C�����e : PM1008 Web-UOE�p�̒ʐM�A�Z���u��ID�萔��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10607734-00  �쐬�S�� : �� ��
// �� �� ��  2011/01/30  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp
// �� �� ��  2011/03/01  �C�����e : �Ɩ��敪�́u�����v�i�Œ�j�ɐ��䂷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �{�z��
// �� �� ��  2011/05/10  �C�����e : �}�c�_WebUOE�p�̒ʐM�A�Z���u��ID�萔��ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	# region �t�n�d���ʏ���
	/// <summary>
	/// �t�n�d���ʏ���
	/// </summary>
	public class UoeCommonFnc
	{
		# region Constructors
		UoeCommonFnc()
		{
		}
		# endregion

        # region Private Methods
        # region �ŏ��l�擾
        /// <summary>
        /// �ŏ��l�擾
        /// </summary>
        /// <param name="len1">�J�E���g�P</param>
        /// <param name="len2">�J�E���g�Q</param>
        /// <param name="len3">�J�E���g�R</param>
        /// <returns>�J�E���g</returns>
        private static int GetMinLength(int len1, int len2, int len3)
        {
            int len = GetMinLength(len1, len2);
            return (GetMinLength(len, len3));
        }
        /// <summary>
        /// �ŏ��l�擾
        /// </summary>
        /// <param name="len1">�J�E���g�P</param>
        /// <param name="len2">�J�E���g�Q</param>
        /// <returns>�J�E���g</returns>
        private static int GetMinLength(int len1, int len2)
        {
            return (len1 < len2 ? len1 : len2);
        }

        # endregion
		# endregion

        # region Public Methods
        # region ������������
        /// <summary>
		/// ������������
		/// </summary>
		/// <param name="dst">��������o�b�t�@</param>
		/// <param name="src">�������L�����N�^</param>
		/// <param name="count">�J�E���^�l</param>
		public static void MemSet(ref byte[] dst, byte src, int count)
		{
            MemSet(ref dst, 0, src, count);
		}

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="dst">��������o�b�t�@</param>
        /// <param name="dstSt">�������o�b�t�@�̊J�n�C���f�B�b�N�X</param>
        /// <param name="src">�������L�����N�^</param>
        /// <param name="count">�J�E���^�l</param>
        public static void MemSet(ref byte[] dst, int dstSt, byte src, int count)
        {
            for (int i = 0; i < GetMinLength(count, dst.Length); i++)
            {
                dst[dstSt+i] = src;
            }
        }
        # endregion

		# region ��������r
        /// <summary>
        /// ��������r(Byte�String)
        /// </summary>
        /// <param name="src">Byte��r�o�b�t�@</param>
        /// <param name="dst">String��r�o�b�t�@</param>
        /// <param name="len">�J�E���^�l</param>
        /// <returns>�X�e�[�^�X</returns>
		public static int MemCmp(byte[] src, string dst, int len)
		{
			return (MemCmp(src, 0, dst, len));
		}
        /// <summary>
        /// ��������r(Byte�String)
        /// </summary>
        /// <param name="src">Byte��r�o�b�t�@</param>
        /// <param name="srcSt">Byte��r�o�b�t�@ �C���f�B�b�N�X</param>
        /// <param name="dst">String��r�o�b�t�@</param>
        /// <param name="len">�J�E���^�l</param>
        /// <returns>�X�e�[�^�X</returns>
		public static int MemCmp(byte[] src, int srcSt, string dst, int len)
		{
			byte[] dstByte = System.Text.Encoding.GetEncoding(932).GetBytes(dst);
			return (MemCmp(src, srcSt, dstByte, 0, len));
		}
        /// <summary>
        /// ��������r(Byte�Byte)
        /// </summary>
        /// <param name="src">Byte��r�o�b�t�@</param>
        /// <param name="dst">Byte��r�o�b�t�@</param>
        /// <param name="len">�J�E���^�l</param>
        /// <returns>�X�e�[�^�X</returns>
		public static int MemCmp(byte[] src, byte[] dst, int len)
		{
			return (MemCmp(src, 0, dst, 0, len));
		}
        /// <summary>
        /// ��������r(Byte[]�Byte[])
        /// </summary>
        /// <param name="src">Byte��r�o�b�t�@</param>
        /// <param name="srcSt">Byte��r�o�b�t�@ �C���f�B�b�N�X</param>
        /// <param name="dst">Byte��r�o�b�t�@</param>
        /// <param name="dstSt">Byte��r�o�b�t�@ �C���f�B�b�N�X</param>
        /// <param name="len">�J�E���^�l</param>
        /// <returns>�X�e�[�^�X</returns>
		public static int MemCmp(byte[] src, int srcSt, byte[] dst, int dstSt, int len)
		{
			int status = 0;
			try
			{
				for (int i=0; i <len; i++)
				{
					if (src[srcSt + i] != dst[dstSt + i])
					{
						status = -1;
						break;
					}
				}
			}
			catch (Exception)
			{
				status = -1;
			}

			return (status);
		}

        /// <summary>
        /// ��������r(Byte[]�Byte)
        /// </summary>
        /// <param name="src">Byte��r�o�b�t�@</param>
        /// <param name="srcSt">Byte��r�o�b�t�@ �C���f�B�b�N�X</param>
        /// <param name="dst">Byte��r</param>
        /// <param name="len">�J�E���^�l</param>
        /// <returns>�X�e�[�^�X</returns>
        public static int MemCmp(byte[] src, int srcSt, byte dst, int len)
        {
            int status = 0;
            try
            {
                for (int i = 0; i < len; i++)
                {
                    if (src[srcSt + i] != dst)
                    {
                        status = -1;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return (status);
        }
		# endregion

		# region ����������
		/// <summary>
        /// ����������(Byte��Byte)
		/// </summary>
		/// <param name="dst">�]����Byte</param>
        /// <param name="src">�]����Byte</param>
		/// <param name="count">�J�E���^�l</param>
		public static void MemCopy(ref byte[] dst, ref byte[] src, int count)
		{
			MemCopy(ref dst, 0, ref src, 0, count);
		}
        /// <summary>
        /// ����������(Byte��Byte)
        /// </summary>
        /// <param name="dst">�]����Byte</param>
        /// <param name="dstSt">�]����Byte �C���f�B�b�N�X</param>
        /// <param name="src">�]����Byte</param>
        /// <param name="srcSt">�]����Byte �C���f�B�b�N�X</param>
        /// <param name="count">�J�E���^�l</param>
		public static void MemCopy(ref byte[] dst, int dstSt, ref byte[] src, int srcSt, int count)
		{
            try
            {
                count = GetMinLength(dst.Length - dstSt, src.Length - srcSt, count);
			    Buffer.BlockCopy(src, srcSt, dst, dstSt, count);
			}
			catch (Exception)
			{
			}
		}
        /// <summary>
        /// ����������(String��Byte)
        /// </summary>
        /// <param name="dst">�]����Byte</param>
        /// <param name="src">�]����String</param>
        /// <param name="count">�J�E���^�l</param>
		public static void MemCopy(ref byte[] dst, string src, int count)
		{
			MemCopy(ref dst, src, 0, count);
		}
        /// <summary>
        /// ����������(String��Byte)
        /// </summary>
        /// <param name="dst">�]����Byte</param>
        /// <param name="src">�]����String</param>
        /// <param name="srcSt">�]����String �C���f�B�b�N�X</param>
        /// <param name="count">�J�E���^�l</param>
        public static void MemCopy(ref byte[] dst, string src, int srcSt, int count)
		{
			byte[] srcByte = System.Text.Encoding.GetEncoding(932).GetBytes(src);
			MemCopy(ref dst, 0, ref srcByte, srcSt, count);
		}
        /// <summary>
        /// ����������(Byte��String)
        /// </summary>
        /// <param name="dst">�]����String</param>
        /// <param name="src">�]����Byte</param>
        /// <param name="count">�J�E���^�l</param>
        public static void MemCopy(ref string dst, ref byte[] src, int count)
		{
			MemCopy(ref dst, ref src, 0, count);
		}
        /// <summary>
        /// ����������(Byte��String)
        /// </summary>
        /// <param name="dst">�]����String</param>
        /// <param name="src">�]����Byte</param>
        /// <param name="srcSt">�]����Byte �C���f�B�b�N�X</param>
        /// <param name="count">�J�E���^�l</param>
        public static void MemCopy(ref string dst, ref byte[] src, int srcSt, int count)
		{
			try
			{
				byte[] srcByte = new byte[count];
				MemCopy(ref srcByte, 0, ref src, srcSt, count);
				dst = ToStringFromByteStrAry(srcByte);
			}
			catch (Exception)
			{
				dst = "";
			}
		}
		# endregion

		# region ���l�����lByte�ϊ��iInt32��byte[]�j
		/// <summary>
		/// ���l�����lByte�ϊ��iInt32��byte[]�j
		/// [1]��[0x00,0x01]
		/// </summary>
		/// <param name="cd"></param>
		/// <returns></returns>
		public static byte[] ToByteAryFromInt32(Int32 cd)
		{
			byte[] retByte = new byte[4];
			byte[] cdByte = BitConverter.GetBytes(cd);

			retByte[0] = cdByte[3];
			retByte[1] = cdByte[2];
			retByte[2] = cdByte[1];
			retByte[3] = cdByte[0];
			return (retByte);
		}
		# endregion

		# region ���l�����lByte�ϊ��iInt32��byte�j
		/// <summary>
		/// ���l�����lByte�ϊ��iInt32��byte�j
		/// [1]��[0x00,0x01]
		/// </summary>
		/// <param name="cd"></param>
		/// <returns></returns>
		public static byte ToByteFromInt32(Int32 cd)
		{
			byte[] retByte = ToByteAryFromInt32(cd);
			return (retByte[3]);
		}
		# endregion

		# region �w�艺�ʌ��̕����񒊏o
		/// <summary>
		/// �w�艺�ʌ��̕����񒊏o
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GetUnderString(string str, int count)
		{
			string underString = "";

			if (str.Length > count)
			{
                underString = GetRemove(str, 0, str.Length - count);
			}
			else
			{
				underString = str;
			}
			return (underString);
		}
		# endregion

		# region ������̍폜
        /// <summary>
        /// ������̍폜
        /// </summary>
        /// <param name="str">�Ώە�����</param>
        /// <param name="start">�폜����J�n�ʒu</param>
        /// <param name="len">�폜���镶����</param>
        /// <returns>�폜�㕶����</returns>
        public static string GetRemove(string str, int start, int len)
        {
            string returnStr = "";

            try
            {
                returnStr = str.Remove(start, len);
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
   		# endregion

		# region ������̒��o
        /// <summary>
        /// ������̒��o
        /// </summary>
        /// <param name="str">�Ώە�����</param>
        /// <param name="start">���o����J�n�ʒu</param>
        /// <param name="len">���o���镶����</param>
        /// <returns>���o�㕶����</returns>
        public static string GetSubstring(string str, int start, int len) 
        {
            string returnStr = "";

            try
            {
                len = GetMinLength(len, str.Length - start);
                if (len > 0)
                {
                    returnStr = str.Substring(start, len);
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
		# endregion

        # region ������̒��o
        /// <summary>
        /// ������̒��o
        /// </summary>
        /// <param name="str">�Ώە�����</param>
        /// <param name="start">���o����J�n�ʒu</param>
        /// <returns>���o�㕶����</returns>
        public static string GetSubstring(string str, int start)
        {
            string returnStr = "";

            try
            {
                if (str.Length - start > 0)
                {
                    returnStr = str.Substring(start);
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
        # endregion


        # region �n�C�t���Ȃ�������̎擾
        /// <summary>
        /// �n�C�t���Ȃ�������̎擾
        /// </summary>
        /// <param name="src">�n�C�t�����蕶����</param>
        /// <returns>�n�C�t���Ȃ�������</returns>
        public static string GetNoNoneHyphenString(string src)
        {
            string returnStr = "";

            try
            {
                for (int i = 0; i < src.Length; i++)
                {

                    if (src[i] == '-') continue;
                    returnStr = returnStr + src[i];
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
        # endregion

		# region �w���ʌ��̕����񒊏o
		/// <summary>
		/// �w���ʌ��̕����񒊏o
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GetUpperString(string str, int count)
		{
			string upperString = "";

			if (str.Length > count)
			{
				upperString = str.Substring(0, count);
			}
			else
			{
				upperString = str;
			}
			return (upperString);
		}
		# endregion

		# region ���t�擾������Binary�Ł�
		/// <summary>
		/// ���t�擾������DDHHMMSS Binary�Ł�
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static byte[] GetByteAryDateTime()
		{
			byte[] retByte = new byte[8];

			byte[] srcDD = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Day));
			retByte[0] = srcDD[0];
			retByte[1] = srcDD[1];

			//��
			byte[] srcHH = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Hour));
			retByte[2] = srcHH[0];
			retByte[3] = srcHH[1];

			//��
			byte[] srcMM = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Minute));
			retByte[4] = srcMM[0];
			retByte[5] = srcMM[1];

			//�b
			byte[] srcSS = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Second));
			retByte[6] = srcSS[0];
			retByte[7] = srcSS[1];

			return (retByte);
		}
		# endregion

		# region Byte[]��string�ϊ��ibyte[]��string�j
		/// <summary>
		/// Byte[]��string�ϊ��ibyte[]��string�j
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static string ToStringFromByteStrAry(byte[] src)
		{
			string retString = "";

			try
			{
                int len = GetByteSize(src);
                byte[] dst = new byte[len];
                MemCopy(ref dst, ref src, len);

				retString = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(dst);
			}
			catch (Exception)
			{
				retString = "";
			}
			return (retString);
		}
		# endregion

        # region Byte�z��̃T�C�Y���擾
        /// <summary>
        /// Byte�z��̃T�C�Y���擾
        /// </summary>
        /// <param name="src">Byte�z��</param>
        /// <returns>�T�C�Y</returns>
        public static int GetByteSize(byte[] src)
        {
            int len = 0;
			try
			{
                for (int i = 0; i < src.Length; i++)
                {
                    if (src[i] == 0x00)
                    {
                        break;
                    }
                    len++;
                }
            }
            catch (Exception)
            {
                len = 0;
            }
            return (len);
        }
        # endregion

        # region ���lByte[]�����l�ϊ��ibyte[]��Int32�j
        /// <summary>
        /// ����Byte[]�����l�ϊ��ibyte[]��Int32�j
        /// [0x31,0x32]��[01]
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static Int32 atobs(byte[] src, int len)
		{
			return(atobs(src, 0, len));
		}
		
		/// <summary>
		/// ����Byte[]�����l�ϊ��ibyte[]��Int32�j
		/// [0x31,0x32]��[01]
		/// </summary>
		/// <param name="src"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public static Int32 atobs(byte[] src, int start, int len)
		{
            int idx = 0;
			Int32 cd = 0;
			try
			{
				if (len > 20)
				{
					return (0);
				}

                byte[] dst = new byte[len];
                for (int i = 0; i < dst.Length; i++)
                {
                    if (src[start + i] >= '0' && src[start + i] <= '9')
                    {
                        dst[idx] = src[start+i];
                        idx++;
                    }
                }
				cd = ToInt32FromByteStrAry(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		
		/// <summary>
		/// ����Byte[]�����l�ϊ��ibyte[]��Int32�j
		/// [0x31,0x32]��[12]
		/// </summary>
		/// <param name="src"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static Int32 ToInt32FromByteStrAry(byte[] src)
		{
			Int32 cd = 0;
			try
			{
				string dst = ToStringFromByteStrAry(src);
				cd = Int32.Parse(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

		# region ���lByte[]�����l�ϊ��ibyte[]��double�j
		/// <summary>
		/// ���lByte[]�����l�ϊ��ibyte[]��double�j
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static double ToDoubleFromByteStrAry(byte[] src)
		{
			double cd = 0;
			try
			{
				string dst = ToStringFromByteStrAry(src);
				cd = double.Parse(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

		# region ���lByte[]�����l�ϊ��ibyte[]��Int32�j
		/// <summary>
		/// ���lByte[]�����l�ϊ��ibyte[]��Int32�j
		/// [0x01,0x00,0x00,0x00]��[1]
		/// </summary>
		/// <param name="src">�ϊ��O�l</param>
		/// <returns>�ϊ���l</returns>
		public static Int32 ToInt32FromByteNumAry(byte[] src)
		{
			Int32 cd = 0;

			try
			{
                //�ϊ�����BYTE����4�޲Ė����̑Ή�
                byte[] dst = new byte[4];
                MemSet(ref dst, 0x00, dst.Length);
                MemCopy(ref dst, ref src, src.Length);

                //�ϊ�����
                cd = BitConverter.ToInt32(dst, 0);
			}
			catch (Exception)   
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

        # region ���lByte[]�����l�ϊ��ibyte��Int32�j
        /// <summary>
        /// ���lByte[]�����l�ϊ��ibyte��Int32�j
        /// [0x01]��[1]
        /// </summary>
        /// <param name="src">�ϊ��O�l</param>
        /// <returns>�ϊ���l</returns>
        public static Int32 ToInt32FromByteNum(byte src)
        {
			Int32 cd = 0;
			try
			{
                byte[] dst = new byte[4];
                MemSet(ref dst, 0x00, dst.Length);
                dst[0] = src;
                cd = ToInt32FromByteNumAry(dst);
            }
            catch (Exception)
            {
                cd = 0;
            }
            return (cd);


        }
   		# endregion


        # region ���l(string)�����l�ϊ��istring��Int32�j
        /// <summary>
        /// ���l(string)�����l�ϊ��istring��Int32�j
        /// </summary>
        /// <param name="src">�ϊ����������l</param>
        /// <returns>���l</returns>
        public static Int32 ToInt32FromString(string src)
        {
            Int32 cd = 0;

            try
            {
                cd = Int32.Parse(src);
            }
            catch (Exception)
            {
                cd = 0;
            }
            return (cd);
        }
        # endregion

        # region ���l(string)�����l�ϊ��istring��Int32�j
		/// <summary>
		/// ���l(string)�����l�ϊ��istring��Int32�j
		/// </summary>
		/// <param name="src">�ϊ����������l</param>
		/// <param name="cd">���l</param>
		/// <returns>true:���� false:�G���[</returns>
		public static bool ToInt32FromString(string src, out Int32 cd)
		{
			bool returnBool = true;

			cd = 0;
			try
			{
				cd = Int32.Parse(src);
			}
			catch (Exception)
			{
				returnBool = false;
			}
			return (returnBool);
		}
		# endregion

		# region ���l(string)�����l�ϊ��istring��Int32�j
		/// <summary>
		/// ���l(string)�����l�ϊ��istring��Int32�j
		/// </summary>
		/// <param name="src">�ϊ����������l</param>
		/// <param name="cd">���l</param>
		/// <returns>true:���� false:�G���[</returns>
		public static bool ToDoubleFromString(string src, out double cd)
		{
			bool returnBool = true;

			cd = 0;
			try
			{
				cd = double.Parse(src);
			}
			catch (Exception)
			{
				returnBool = false;
			}
			return (returnBool);
		}
		# endregion

        # region ���t�Z�o(byte[8]��DateTime)
        /// <summary>
        /// ���t�Z�o(byte[8]��DateTime)
        /// </summary>
        /// <param name="dateByte"></param>
        /// <returns></returns>
        public static DateTime ToDateFromByte(Byte[] dateByte)
        {
            DateTime dateTime = DateTime.Now;

            try
            {
                int int32Yymmdd = atobs(dateByte, dateByte.Length);

                //�d�����̂ɂɓ��t���Z�b�g����Ă���
                if (int32Yymmdd != 0)
                {
                    if (int32Yymmdd < 1000000)
                    {
                        int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
                        lwk /= 1000000;	// yy
                        lwk *= 1000000;	// yy000000

                        int32Yymmdd += lwk;
                    }
                    dateTime = TDateTime.LongDateToDateTime(int32Yymmdd);
                }
                //�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
                else
                {
                    dateTime = DateTime.Now;
                }
            }
            catch (Exception)
            {
                dateTime = DateTime.Now;
            }
            return (dateTime);
        }
        # endregion

        # region ���ԎZ�o(byte[8]��int)
        /// <summary>
        /// ���ԎZ�o(byte[8]��int)
        /// </summary>
        /// <param name="timeByte"></param>
        /// <returns></returns>
        public static int ToTimeIntFromByte(Byte[] timeByte)
        {
            int timeInt = 0;
            try
            {
                timeInt = atobs(timeByte, timeByte.Length);
                if (timeInt == 0)
                {
                    timeInt = DateTime.Now.Hour * 10000
                            + DateTime.Now.Minute * 100
                            + DateTime.Now.Second;
                }
            }
            catch (Exception)
            {
                timeInt = DateTime.Now.Hour * 10000
                        + DateTime.Now.Minute * 100
                        + DateTime.Now.Second;
            }
            return (timeInt);
        }
        # endregion

		# endregion
	}
	# endregion

	# region �t�n�d�W��`�N���X
	/// <summary>
	/// �t�n�d��`�N���X
	/// </summary>
    /// <remarks>
    /// <br>Update Note : 2010/03/08 �k���r</br>
    /// <br>              PM1006 UOE�����悪�u���Y�v�̏ꍇ�AUOE�����f�[�^�݂̂��쐬���A�ʐM�͍s��Ȃ��悤�ɏC��</br>
    /// <br>Update Note : 2010/04/26 gaoyh</br>
    /// <br>              PM1007C �O�HUOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>Update Note : 2010/05/07 ����</br>
    /// <br>              PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpdateNote : 2011/01/06 liyp </br>
    /// <br>            Web-UOE�p�̒ʐM�A�Z���u��ID�萔��ǉ�</br>
    /// <br>UpdateNote : 2011/01/30 �� �� </br>
    /// <br>            UOE����������</br>
    /// <br>Update Note: 2011/03/01 liyp</br>
    /// <br>             �Ɩ��敪�́u�����v�i�Œ�j�ɐ��䂷��</br>
    /// <br>Update Note: 2011/05/10 �{�z��</br>
    /// <br>             �}�c�_WebUOE�p�̒ʐM�A�Z���u��ID�萔��ǉ�</br>
    /// </remarks>
	public class EnumUoeConst
	{
		# region Const Members
		//�Ɩ��敪
		public enum TerminalDiv
		{
            ct_None = 0,    //�����Ȃ�
            ct_Order = 1,	//����
			ct_Estmt = 2,	//����
			ct_Stock = 3,	//�݌Ɋm�F
			ct_Cancel = 4,	//�������
		}

		//�V�X�e���敪
		public enum ctSystemDivCd
		{
            ct_Input = 0,	//�����
            ct_Slip = 1,	//�`��
			ct_Search = 2,	//����
			ct_Lump = 3,	//�݌Ɉꊇ
		}

        //�����敪
        public enum ctProcessDiv
        {
            ct_NORMAL = 0,	//�ʏ�
            ct_RECOVER = 1,	//����
        }

		//�ʐM�v���O�����h�c
		public const string ctCommAssemblyId_0102 = "0102";	//�g���^
        public const string ctCommAssemblyId_0103 = "0103";	//�g���^�d�q�J�^���O  // ADD 2009/12/29 xuxh
		public const string ctCommAssemblyId_0202 = "0202";	//�j�b�T��
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        public const string ctCommAssemblyId_0203 = "0203";	//���Yweb-UOE
        public const string ctCommAssemblyId_0204 = "0204";	// ADD 2011/01/06
        // ---ADD 2010/03/08 ----------------------------------------<<<<<
        public const string ctCommAssemblyId_0301 = "0301";	//�~�c�r�V
        // ---ADD 2010/04/26 gaoyh ---------------------------------------->>>>>
        public const string ctCommAssemblyId_0302 = "0302";	//�O�Hweb-UOE
        public const string ctCommAssemblyId_0303 = "0303";	//ADD 2011/01/06
        // ---ADD 2010/04/26 gaoyh ----------------------------------------<<<<<
		public const string ctCommAssemblyId_0401 = "0401";	//���}�c�_
		public const string ctCommAssemblyId_0402 = "0402";	//�V�}�c�_
		public const string ctCommAssemblyId_0501 = "0501";	//�z���_
		public const string ctCommAssemblyId_0801 = "0801";	//�X�o��
		public const string ctCommAssemblyId_1001 = "1001";	//�D�ǃ��[�J�[
        public const string ctCommAssemblyId_0502 = "0502";	//e-Parts
        // ---ADD 2010/05/07 ------------------>>>>>
        public const string ctCommAssemblyId_1003 = "1003";	//�D�ǃ��[�J�[(SPK��)
        public const string ctCommAssemblyId_1004 = "1004";	//�D�ǃ��[�J�[(�����Y��)
        // ---ADD 2010/05/07 ------------------<<<<<
        public const string ctCommAssemblyId_0104 = "0104";	// �g���^�������� // ADD 2011/01/30 �� ��
        // ---ADD 2011/03/01 liyp ----------------------------------------->>>>>
        public const string ctCommAssemblyId_0205 = "0205";
        public const string ctCommAssemblyId_0206 = "0206";
        // ---ADD 2011/03/01 liyp -----------------------------------------<<<<<
        // ---ADD 2011/05/10  ----------------------------------------->>>>>
        public const string ctCommAssemblyId_0403 = "0403";
        // ---ADD 2011/05/10  -----------------------------------------<<<<<
		//�G���[�R�[�h
		public enum Status
		{
			ct_NORMAL = 0,
			ct_NOT_FOUND = 4,
			ct_EOF = 9,
			ct_WARNING = 999,
			ct_ERROR = 1000,
		}

		//�J�� �ǃ��[�h
		public enum OpenMode
		{
			ct_OPEN = 0,
			ct_CLOSE = 1,
		}

        // HACK:�������d����M�����p
        /// <summary>
        /// �����d����M������UOE��������
        /// </summary>
        public enum ReceivingUOESupplier
        {
            /// <summary>SPK(���̑�)</summary>
            SPK,
            /// <summary>�����Y��</summary>
            Meiji
        }
        // HACK:��

		//�t�n�d�i�m�k�X�V���[�h
		public enum UoeJnlWriteMode
		{
			ct_INSERT = 0,
			ct_UPDATE = 1,
		}

		//���O�f�[�^��ʋ敪�R�[�h
		//0:�L�^,1:�G���[,9:�V�X�e��,10:UOE(DSP) 11:UOE(�ʐM)
		public enum ctLogDataKindCd
		{
			ct_RECORD = 0,
			ct_ERROR = 1,
			ct_SYSTEM = 9,
			ct_DSP = 10,
			ct_TERM = 11,
		}

		//������e�R�[�h(0:�N��,1:���O�C��,2:�f�[�^�Ǎ�,3:�f�[�^�}��,4:�f�[�^�X�V,5:�f�[�^�_���폜,
		//6:�f�[�^�폜,7:���,8:�e�L�X�g�o��,9:�ʐM,10:�ďo,11:���M,12:��M,13:�^�C���A�E�g,14:�I��)
		public enum ctLogDataOperationCd
		{
			ct_START = 0,
			ct_LOGIN = 1,
			ct_READ = 2,
			ct_INSERT = 3,
			ct_UPDT = 4,
			ct_LOGDEL = 5,
			ct_DEL = 6,
			ct_PRN = 7,
			ct_TEXTOUT = 8,
			ct_TERM = 9,
			ct_SUMMONS = 10,
			ct_SND = 11,
			ct_REC = 12,
			ct_TIMEOUT = 13,
			ct_END = 14,
		}

		//���엚�����O�f�[�^�̃t���b�V���L��
		public enum ctOprtnHisLogFlush
		{
			ct_ON = 1,
			ct_OFF = 0,
		}

		//���M�t���O
		public enum ctDataSendCode
		{
			ct_NonProcess = 0, //������
			ct_Process = 1, //������
			ct_SndNG = 2, //���M�G���[
			ct_RcvNG = 3, //��M�G���[
			ct_Insert = 5, //�񓚖��ߍ���
			ct_OK = 9, //����I��
		}

		//�����t���O
		public enum ctDataRecoverDiv
		{
			ct_NonProcess = 0, //������
			ct_YES = 1,	//�����Ώ�
			ct_NO = 9,	//�����s�v
		}

		//���[�J�[�t�H���[�v��敪
		public enum ctMakerFollowAddUpDiv
		{
			ct_Sales = 0,	//����
			ct_Order = 1,	//��
		}

		//�t�H���[�`�[�o�͋敪
		public enum ctFollowSlipOutputDiv
		{
			ct_Add = 0,	//���Z
			ct_Separate = 1,	//�ʁX
		}

		//��M��(��M�L���敪)
		public enum ctReceiveCondition
		{
			ct_SndRcv = 0,	//����M�\
			ct_Snd = 1,		//���M�̂�
		}

		//�d���f�[�^��M�敪
		public enum ctStockSlipDtRecvDiv
		{
			ct_Unavailable = 0,	//�Ȃ�
			ct_Available = 1,	//����
		}

		//����d���敪
		//0:���Ȃ��@1:����@2:�K�{����
		public enum ctSalesStockDiv
		{
			ct_No= 0,			//���Ȃ�
			ct_Yes = 1,			//����
			ct_Essential = 2,	//�K�{����
		}

		//���������敪
		//0:���Ȃ��@1:����
        public enum ctAutoDepositCd
		{
			ct_No = 0,			//���Ȃ�
			ct_Yes = 1,			//����
		}

        //�v����t�敪
        //0:�V�X�e�����t 1:������t
        public enum ctAddUpADateDiv
        {
            ct_System = 0,      //0:�V�X�e�����t
            ct_Sales = 1,       //1:������t
        }

        //�艿�g�p�敪
        //0:������ 1:���͗D�� 2:�I�����C���D��
        public enum ctListPriceUseDiv
        {
            ct_Hight = 0,   //0:������
            ct_Input = 1,   //1:���͗D��
            ct_Online = 2,  //2:�I�����C���D��
        }

        //��֕i�ԋ敪
        public enum ctSubstPartsNoDiv
        {
            ct_SubstParts = 0,  //��֕i�ԍ̗p
            ct_OrderParts = 1,  //�����i�ԍ̗p
        }

        # endregion


		# region Constructors
		/// <summary>
		/// Constructors
		/// </summary>
		public EnumUoeConst()
		{
		}
		# endregion
	}
	# endregion

}
