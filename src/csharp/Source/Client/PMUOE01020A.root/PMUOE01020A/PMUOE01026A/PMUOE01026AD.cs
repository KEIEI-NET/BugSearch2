//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i�z���_�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10501071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d��M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0501Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i�z���_�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�z���_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0501(out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �i�m�k�X�V����
                //-----------------------------------------------------------
                if (uoeRecHed != null)
                {
                    TelegramJnlStock0501 telegramJnlStock0501 = new TelegramJnlStock0501();
                    telegramJnlStock0501.Telegram(_uoeRecHed);
                }

                //-----------------------------------------------------------
                // ����M�i�m�k�����M�t���O�E�����t���O���̍X�V
                //   ���M�t���O (�X�V�O)1:������ �� (�X�V��)2:���M�G���[
                //   �����t���O (�X�V�O)0:������ �� (�X�V��)1:�����Ώ�
                //-----------------------------------------------------------
                _uoeSndRcvJnlAcs.JnlOrderTblFlgUpdt(_uoeSndHed.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_Process,		//1:������
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess,	//0:������
                    (int)EnumUoeConst.ctDataSendCode.ct_SndNG,			//2:���M�G���[
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_YES);			//9:�����Ώ�
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�d���쐬���݌Ɂ��i�z���_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i�z���_�j
		/// </summary>
		public class TelegramJnlStock0501 : UoeRecEdit0501Acs
		{
			# region �o�l�V�\�[�X
            // /************************************************************/
            // /********            �݌�  �w�b�_�[��                ********/
            // /************************************************************/
            // struct ZHD_1 {					/* ����  ���d��  			*/
            // 	char	sei[8];				/* ���䕔					*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	kak_era[10];		/* �g���G���A				*/
            // 	char	date[8];			/* ���t						*/
            // 	char	time[8];			/* ����						*/
            // 	char	msg[2];				/* �S�̃��b�Z�[�W			*/
            // 	char	seq[3];				/* �r�d�p					*/
            // 	char	ymdtime[6];			/* �N���������b				*/
            // 	char	kei_flg[1];			/* �p���t���O				*/
            // 	char	kensu[2];			/* �S�̌���					*/
            // };
            // 
            // /************************************************************/
            // /********            �݌�  �f�[�^��                  ********/
            // /************************************************************/
            // 
            // struct	ZZAI_R {				/* �݌Ƀf�[�^���i�݌Ɂj		*/
            // 	char	dai_cd[5];			/* �㗝�X�R�[�h				*/
            // 	char	su[3];				/* ��						*/
            // };
            // 
            // struct	ZDT_1_R {				/* �݌Ƀf�[�^��	�i���ʂP�j	*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	nm_hb[17];			/* �i������������			*/
            // 	char	k_kk[7];			/* ��]���i					*/
            // 	char	h_kk[7];			/* �̔����i					*/
            // 	char	h_zai[2];			/* �{���݌�					*/
            // 	struct	ZZAI_R	zzai[5];	/* �݌Ƀf�[�^���i�݌Ɂj		*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // };
            // 
            // struct	ZDT_2_R {				/* �݌Ƀf�[�^��	�i���ʂQ�j	*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	lmsg[17];			/* ���C�����b�Z�[�W			*/
            // 	char	spc[56];			/* ��						*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // };
			# endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//�ő�d����
            private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
            private const Int32 ctDt_hLen = 89;     //�f�[�^�����R�[�h�T�C�Y
            # endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
            private List<ZRV_BUFF> zrv_list = null;
			# endregion

			# region �d���̈�N���X
            # region ���ώ�M�f�[�^
            /// <summary>
            /// ���ώ�M�f�[�^
            /// </summary>
            private class ZRV_BUFF
            {
                //���σw�b�_�[��
                public int _uOESalesOrderNo = 0;                    // UOE�����ԍ�
                public List<int> _uOESalesOrderRowNoList = null;    //UOE�����ԍ��s�ԍ�

                public int _dataSendCode = 0;                       // �f�[�^���M�敪
                public int _dataRecoverDiv = 0;                     // �f�[�^�����敪

                public int divZRV = 0;              // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                public ZHD_1 zhd_1 = null;          // ���d��
                public ZHD_ERR zhd_err = null;      // ���d���w�b�_�[�G���[

                // �݌Ƀf�[�^��
                public List<DT_Z> dt_z_List = null;

                public ZRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;
                    _uOESalesOrderRowNoList = new List<int>();

                    divZRV = 0;
                    zhd_1 = null;
                    zhd_err = null;

                    if (dt_z_List == null)
                    {
                        dt_z_List = new List<DT_Z>();
                    }
                    else
                    {
                        dt_z_List.Clear();
                    }
                }

                public void Setting(UoeRecDtl uoeRecDtl)
                {
                    # region �w�b�_�[���X�V
                    //�w�b�_�[���X�V
                    //��P�d������
                    //UOE�����ԍ� UOE�����s�ԍ��̕ۑ�
                    _uOESalesOrderNo = uoeRecDtl.UOESalesOrderNo;
                    _uOESalesOrderRowNoList = new List<int>();
                    _uOESalesOrderRowNoList.AddRange(uoeRecDtl.UOESalesOrderRowNo);

                    //���ʃt���O
                    divZRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // �G���[���䕔
                    if ((divZRV >= 1) && divZRV <= 3)
                    {
                        zhd_err = new ZHD_ERR();
                        zhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;
                    }
                    //���d���w�b�_�[�i�[����
                    else
                    {
                        zhd_1 = new ZHD_1();
                        zhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
                    # endregion

                    # region �f�[�^���X�V
                    // �f�[�^���@�X�V
                    if (divZRV == 0)
                    {
                        int start = 49;                                 //���d���ʒu�̐ݒ�
                        int maxSize = uoeRecDtl.RecTelegramLen;         //���T�C�Y
                        int blkSize = maxSize / ctTelegramMax;          //�d����
                        if ((maxSize % ctTelegramMax) != 0) blkSize++;

                        for (int blkCnt = 0; blkCnt < blkSize; blkCnt++)
                        {
                            for (int i = 0; i < ctBufLen; i++)
                            {
                                //(�d���J�n�I�t�Z�b�g) + (����f�[�^���I�t�Z�b�g) +(�f�[�^���J�n�I�t�Z�b�g)
                                int idx = (ctTelegramMax * blkCnt) + start + (i * ctDt_hLen);

                                //�f�[�^�Ȃ�����
                                if ((idx + ctDt_hLen) > uoeRecDtl.RecTelegramLen) break;
                                if (UoeCommonFnc.MemCmp(uoeRecDtl.RecTelegram, idx, 0x20, ctDt_hLen) == 0) break;
                                if (UoeCommonFnc.MemCmp(uoeRecDtl.RecTelegram, idx, 0x00, ctDt_hLen) == 0) break;

                                //�f�[�^���i�[����
                                DT_Z dt_z = new DT_Z();
                                dt_z.Setting(uoeRecDtl.RecTelegram, idx);
                                dt_z_List.Add(dt_z);
                            }
                            start = 8;                    // ���d���ʒu�̐ݒ�
                        }
                    }
                    # endregion
                }
            }
            # endregion

            # region �݌Ƀw�b�_�[��
            /// <summary>
            /// �݌Ƀw�b�_�[��
            /// </summary>
            public class ZHD_1
            {
                public byte[] sei = new byte[8];			// ���䕔					
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] kak_era = new byte[10];		// �g���G���A				
                public byte[] date = new byte[8];			// ���t						
                public byte[] time = new byte[8];			// ����						
                public byte[] msg = new byte[2];			// �S�̃��b�Z�[�W			
                public byte[] seq = new byte[3];			// �r�d�p					
                public byte[] ymdtime = new byte[6];		// �N���������b				
                public byte[] kei_flg = new byte[1];		// �p���t���O				
                public byte[] kensu = new byte[2];			// �S�̌���					

                public ZHD_1()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref sei, cd, sei.Length);			// ���䕔					
	                UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
	                UoeCommonFnc.MemSet(ref kak_era, cd, kak_era.Length);	// �g���G���A				
	                UoeCommonFnc.MemSet(ref date, cd, date.Length);			// ���t						
	                UoeCommonFnc.MemSet(ref time, cd, time.Length);			// ����						
	                UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// �S�̃��b�Z�[�W			
	                UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// �r�d�p					
	                UoeCommonFnc.MemSet(ref ymdtime, cd, ymdtime.Length);	// �N���������b				
	                UoeCommonFnc.MemSet(ref kei_flg, cd, kei_flg.Length);	// �p���t���O				
	                UoeCommonFnc.MemSet(ref kensu, cd, kensu.Length);		// �S�̌���					
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    // ����  ���d��  		
                    ms.Read(sei, 0, sei.Length);			// ���䕔					
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(kak_era, 0, kak_era.Length);	// �g���G���A				
                    ms.Read(date, 0, date.Length);			// ���t						
                    ms.Read(time, 0, time.Length);			// ����						
                    ms.Read(msg, 0, msg.Length);			// �S�̃��b�Z�[�W			
                    ms.Read(seq, 0, seq.Length);			// �r�d�p					
                    ms.Read(ymdtime, 0, ymdtime.Length);	// �N���������b				
                    ms.Read(kei_flg, 0, kei_flg.Length);	// �p���t���O				
                    ms.Read(kensu, 0, kensu.Length);		// �S�̌���					

                    ms.Close();
                }
            }
            # endregion

            # region �d���w�b�_�[�G���[
            /// <summary>
            /// �d���w�b�_�[�G���[
            /// </summary>
            public class ZHD_ERR
            {
                public byte[] sei = new byte[8];			// ���䕔					
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] kak_era = new byte[10];		// �g���G���A				
                public byte[] date = new byte[8];			// ���t						
                public byte[] time = new byte[8];			// ����						
                public byte[] msg = new byte[2];			// �S�̃��b�Z�[�W			
                public byte[] seq = new byte[3];			// �r�d�p					
                public byte[] ymdtime = new byte[6];		// �N���������b				
                public byte[] kei_flg = new byte[1];		// �p���t���O				
                public byte[] errmsg = new byte[40];

                public ZHD_ERR()
                {
                    Clear(0x00);
                }

                public void Clear(byte cd)
                {
                    UoeCommonFnc.MemSet(ref sei, cd, sei.Length);			// ���䕔					
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
                    UoeCommonFnc.MemSet(ref kak_era, cd, kak_era.Length);	// �g���G���A				
                    UoeCommonFnc.MemSet(ref date, cd, date.Length);			// ���t						
                    UoeCommonFnc.MemSet(ref time, cd, time.Length);			// ����						
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// �S�̃��b�Z�[�W			
                    UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// �r�d�p					
                    UoeCommonFnc.MemSet(ref ymdtime, cd, ymdtime.Length);	// �N���������b				
                    UoeCommonFnc.MemSet(ref kei_flg, cd, kei_flg.Length);	// �p���t���O				
                    UoeCommonFnc.MemSet(ref errmsg, cd, msg.Length);
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(sei, 0, sei.Length);			// ���䕔					
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(kak_era, 0, kak_era.Length);	// �g���G���A				
                    ms.Read(date, 0, date.Length);			// ���t						
                    ms.Read(time, 0, time.Length);			// ����						
                    ms.Read(msg, 0, msg.Length);			// �S�̃��b�Z�[�W			
                    ms.Read(seq, 0, seq.Length);			// �r�d�p					
                    ms.Read(ymdtime, 0, ymdtime.Length);	// �N���������b				
                    ms.Read(kei_flg, 0, kei_flg.Length);	// �p���t���O				
                    ms.Read(errmsg, 0, errmsg.Length);

                    ms.Close();
                }
            }
            # endregion

            # region �f�[�^��
            # region �݌Ƀf�[�^�����C��
            /// <summary>
            /// �݌Ƀf�[�^�����C��
            /// </summary>
            public class DT_Z
            {
                public int divZDT = 0;              // ���ʃt���O 1:����1 21:����2-1 22:����2-2 3:����3
                public int _uOESalesOrderRowNo = 0; // UOE�����s�ԍ�

                public ZDT_1_R zdt_1 = null;        //�݌Ƀf�[�^���i���ʂP�j
                public ZDT_2_R zdt_2 = null;        //�݌Ƀf�[�^���i���ʂQ�j

                public DT_Z()
                {
                    Clear();
                }

                public void Clear()
                {
                    divZDT = 0;
                    _uOESalesOrderRowNo = 0;
                    zdt_1 = null;
                    zdt_2 = null;
                }

                public void Setting(byte[] line, int start)
                {
                    try
                    {
                        if (line == null) return;

                        Clear();

                        //���� 1 or 2 ����
                        divZDT = UoeCommonFnc.atobs(line, start, 1);

                        switch (divZDT)
                        {
                            case 1:
                                zdt_1 = new ZDT_1_R();
                                zdt_1.Setting(line, start);
                                break;
                            default:
                                zdt_2 = new ZDT_2_R();
                                zdt_2.Setting(line, start);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Clear();
                    }
                }
            }
            # endregion

			# region �݌Ƀf�[�^���i�݌Ɂj
            /// <summary>
            /// �݌Ƀf�[�^���i�݌Ɂj
            /// </summary>
            public class ZZAI_R
            {
                public byte[] dai_cd = new byte[5];			// �㗝�X�R�[�h				
                public byte[] su = new byte[3];				// ��						

                public ZZAI_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref dai_cd, cd, dai_cd.Length);		// �㗝�X�R�[�h				
	                UoeCommonFnc.MemSet(ref su, cd, su.Length);				// ��						
				}
            }
            # endregion

			# region �݌Ƀf�[�^���i���ʂP�j
            /// <summary>
            /// �݌Ƀf�[�^���i���ʂP�j
            /// </summary>
            public class ZDT_1_R
            {
	            public byte[] skb_flg = new byte[1];		// ���ʃt���O				
	            public byte[] nm_hb = new byte[17];			// �i������������			
	            public byte[] k_kk = new byte[7];			// ��]���i					
	            public byte[] h_kk = new byte[7];			// �̔����i					
	            public byte[] h_zai = new byte[2];			// �{���݌�					
                public ZZAI_R[] zzai = new ZZAI_R[5];		// �݌Ƀf�[�^���i�݌Ɂj		
	            public byte[] dsp_hb = new byte[15];		// �\���p���i				

                public ZDT_1_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
	                UoeCommonFnc.MemSet(ref nm_hb, cd, nm_hb.Length);		// �i������������			
	                UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// ��]���i					
	                UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// �̔����i					
	                UoeCommonFnc.MemSet(ref h_zai, cd, h_zai.Length);		// �{���݌�					

                    // �݌Ƀf�[�^���i�݌Ɂj		
					for(int i=0;i<zzai.Length; i++)
					{
                        if (zzai[i] == null)
                        {
                            zzai[i] = new ZZAI_R();
                        }
                        else
                        {
                            zzai[i].Clear(0x00);
                        }
					}

	                UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(nm_hb, 0, nm_hb.Length);		// �i������������			
                    ms.Read(k_kk, 0, k_kk.Length);			// ��]���i					
                    ms.Read(h_kk, 0, h_kk.Length);			// �̔����i					
                    ms.Read(h_zai, 0, h_zai.Length);		// �{���݌�					

                    // �݌Ƀf�[�^���i�݌Ɂj
                    for (int j = 0; j < zzai.Length; j++)
                    {
                        ms.Read(zzai[j].dai_cd, 0, zzai[j].dai_cd.Length);		// �㗝�X�R�[�h				
                        ms.Read(zzai[j].su, 0, zzai[j].su.Length);				// ��						
                    }

                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// �\���p���i				

                    ms.Close();
                }
            }
            # endregion

			# region �݌Ƀf�[�^���i���ʂQ�j
            /// <summary>
            /// �݌Ƀf�[�^���i���ʂQ�j
            /// </summary>
            public class ZDT_2_R
            {
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] lmsg = new byte[17];			// ���C�����b�Z�[�W			
                public byte[] spc = new byte[56];			// ��						
                public byte[] dsp_hb = new byte[15];		// �\���p���i				

                public ZDT_2_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
	                UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// ���C�����b�Z�[�W			
	                UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// ��						
	                UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(lmsg, 0, lmsg.Length);			// ���C�����b�Z�[�W			
                    ms.Read(spc, 0, spc.Length);			// ��						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// �\���p���i				

                    ms.Close();
                }
            }
            # endregion
			# endregion
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock0501()
			{
				Clear();
			}
			# endregion

			# region Properties
			# region ���׍s��
			public Int32 detailMax
			{
				get
				{
					return this._detailMax;
				}
				set
				{
					this._detailMax = value;
				}
			}
			# endregion
			# endregion

			# region Public Methods
			# region �f�[�^����������
			/// <summary>
			/// �f�[�^����������
			/// </summary>
			public void Clear()
			{
				_detailMax = 0;
                if (zrv_list == null)
                {
                    zrv_list = new List<ZRV_BUFF>();
                }
                else
                {
                    zrv_list.Clear();
                }
            }
			# endregion

            # region �o�C�g�^�z��ɕϊ�
            /// <summary>
            /// �o�C�g�^�z��ɕϊ�
            /// </summary>
            /// <param name="list">�W�J�����X�g</param>
            private void FromByteArray(List<UoeRecDtl> list)
            {
                //�d���N���X�̍쐬
                Clear();
                ZRV_BUFF zrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // ���񎞏���
                    if (zrv_buff == null)
                    {
                        zrv_buff = new ZRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        zrv_buff._dataSendCode = dtl.DataSendCode;
                        zrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE�����ԍ��̃`�F�b�N
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // ���X�g�ւƕۑ�
                        zrv_list.Add(zrv_buff);

                        // �N���A����
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        zrv_buff = new ZRV_BUFF();
                    }

                    //��M�f�[�^�i�[����
                    zrv_buff.Setting(dtl);
                }

                // �ҏW���̎�M�f�[�^�i�[����
                if (zrv_buff != null)
                {
                    zrv_list.Add(zrv_buff);
                }
            }
            # endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
            public void Telegram(UoeRecHed uoeRecHed)
			{
                int uOESupplierCd = uoeRecHed.UOESupplierCd;                 // UOE������R�[�h

                //�o�C�g�^�z��ɕϊ�
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //�d���ϐ�����
                foreach (ZRV_BUFF zrv_buff in zrv_list)
                {
                    # region �G���[���䕔 �X�V
                    // �G���[���䕔 �X�V
                    // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                    if (zrv_buff.divZRV >= 1 && zrv_buff.divZRV <= 3)
                    {
                        ToDataRowFromZdt_err(zrv_buff, uOESupplierCd);
                        continue;
                    }
                    # endregion

                    # region �w�b�_�[�E�f�[�^�� �X�V
                    // �w�b�_�[�E�f�[�^�� �X�V
                    int uOESalesOrderRowNo = 0;
                    foreach (DT_Z dt_z in zrv_buff.dt_z_List)
                    {
                        //�擾������MJNL-DATATABLE������MJNL-CLASS��
                        int uOESalesOrderNo = zrv_buff._uOESalesOrderNo;
                        uOESalesOrderRowNo++;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlStockTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //�f�[�^���M�敪
                        dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = zrv_buff._dataRecoverDiv;

                        //�f�[�^�����敪
                        dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = zrv_buff._dataRecoverDiv;

                        //��M���t(YYYYMMDD)
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(zrv_buff.zhd_1.date);

                        //��M����(HHMM)
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(zrv_buff.zhd_1.time);

                        // ���ʃt���O 1:����1 2:����2
                        switch (dt_z.divZDT)
                        {
                            //����1
                            case 1:
                                ToDataRowFromZdt_1(ref dataRow, dt_z.zdt_1);
                                break;
                            //����2
                            default:
                                ToDataRowFromZdt_2(ref dataRow, dt_z.zdt_2);
                                break;
                        }
                    }
                    # endregion
                }
			}
			# endregion

			# endregion

			# region private Methods
            # region �f�[�^�G���[�X�V
            /// <summary>
            /// �f�[�^�G���[�X�V
            /// </summary>
            /// <param name="zrv_buff">������M�f�[�^</param>
            /// <param name="uOESupplierCd">������R�[�h</param>
            private void ToDataRowFromZdt_err(ZRV_BUFF zrv_buff, int uOESupplierCd)
            {
                ZHD_ERR zhd_err = zrv_buff.zhd_err;

                int uOESalesOrderNo = zrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in zrv_buff._uOESalesOrderRowNoList)
                {
                    //�擾������MJNL-DATATABLE������MJNL-CLASS��
                    DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                    uOESupplierCd,
                                                    uOESalesOrderNo,
                                                    uOESalesOrderRowNo);
                    if (dataRow == null)
                    {
                        continue;
                    }

                    //��M���t(YYYYMMDD)
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(zhd_err.date);

                    //��M����(HHMM)
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(zhd_err.time);

                    // �G���[���䕔�@�Z�b�g
                    string errMessage = UoeCommonFnc.ToStringFromByteStrAry(zhd_err.sei);

                    //�w�b�h�G���[���b�Z�[�W
                    dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;
                }
            }
            # endregion

            # region �f�[�^���X�V(����1)
            /// <summary>
            /// �f�[�^���X�V(����1)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="zdt_1">�݌Ɏ�M�f�[�^</param>
            private void ToDataRowFromZdt_1(ref DataRow dataRow, ZDT_1_R zdt_1)
            {
			
                // �i��
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.dsp_hb);
				
                // �i��
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.nm_hb);
				
                // �K�p(L/P)
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(zdt_1.k_kk);
           
				// �̔��X�d���P��
                double shopStUnitPrice = UoeCommonFnc.ToDoubleFromByteStrAry(zdt_1.h_kk);
                dataRow[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice] = shopStUnitPrice;
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = shopStUnitPrice;

                // �i�{���݌Ɂj�݌ɐ��O�O
                string headQtrsStock = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.h_zai);
                dataRow[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = headQtrsStock;

                // UOE���_�R�[�h�P
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode1] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[0].dai_cd);
				
                // UOE���_�݌ɐ��P
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.atobs(zdt_1.zzai[0].su, zdt_1.zzai[0].su.Length); 
				
                // UOE���_�R�[�h�Q
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode2] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[1].dai_cd);
				
                // UOE���_�݌ɐ��Q
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.atobs(zdt_1.zzai[1].su, zdt_1.zzai[0].su.Length); 
				
                // UOE���_�R�[�h�R
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode3] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[2].dai_cd);
				
                // UOE���_�݌ɐ��R
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.atobs(zdt_1.zzai[2].su, zdt_1.zzai[0].su.Length); 
				
                // UOE���_�R�[�h�S
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode4] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[3].dai_cd);
				
                // UOE���_�݌ɐ��S
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.atobs(zdt_1.zzai[3].su, zdt_1.zzai[0].su.Length); 
				
                // UOE���_�R�[�h�T
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode5] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[4].dai_cd);
				
                // UOE���_�݌ɐ��T
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.atobs(zdt_1.zzai[4].su, zdt_1.zzai[0].su.Length); 
            }
			# endregion

            # region �f�[�^���X�V(����2)
            /// <summary>
            /// �f�[�^���X�V(����2)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="zdt_1">�݌Ɏ�M�f�[�^</param>
            private void ToDataRowFromZdt_2(ref DataRow dataRow, ZDT_2_R zdt_2)
            {
                //�i��
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.dsp_hb);

                //�i��
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
                dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
                dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
            }
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}
