//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i�z���_�j���s��
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
	/// �t�n�d��M�ҏW���������i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i�z���_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���������i�z���_�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i�z���_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlOrder0501(out string message)
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
                    TelegramJnlOrder0501 telegramJnlOrder0501 = new TelegramJnlOrder0501();
                    telegramJnlOrder0501.Telegram(_uoeRecHed);
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

		# region �t�n�d��M�d���쐬���������i�z���_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���������i�z���_�j
		/// </summary>
		public class TelegramJnlOrder0501 : UoeRecEdit0501Acs
		{
			# region �o�l�V�\�[�X
            // /************************************************************/
            // /********            ����  �S�̃w�b�_�[��            ********/
            // /************************************************************/
            // struct HHD_1 {				/* ����  ���d��  	65byte	*/
            // 	char	sei[8];				/* ���䕔					*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	kak_era[10];		/* �g���G���A				*/
            // 	char	date[8];			/* ���t						*/
            // 	char	time[8];			/* ����						*/
            // 	char	msg[2];				/* �S�̃��b�Z�[�W			*/
            // 	char	seq[3];				/* �r�d�p					*/
            // 	char	ymdtime[6];			/* �N���������b				*/
            // 	char	kei_flg[1];			/* �p���t���O				*/
            // 	char	item[5];			/* �A�C�e��					*/
            // 	char	deno[6];			/* �`�[�m��					*/
            // 	char	dai_cd[5];			/* �㗝�X�R�[�h				*/
            // 	char	kensu[2];			/* �S�̌���					*/
            // };
            // 
            // struct HHD_5 {					// ���d���w�b�_�[�G���[
            // 	char	head[47];
            // 	char	msg[40];
            // };
            // /************************************************************/
            // /********            ����  �f�[�^��                  ********/
            // /************************************************************/
            // struct	HDT_1_R {			/* ����  ���ʂP				*/
            // 	char	on_no[2];			/* �I�����C���m��			*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	hb[15];				/* �o�וi��					*/
            // 	char	sijisu[3];			/* �w����					*/
            // 	char	hky[5];				/* �o�׌�					*/
            // 	char	k_kk[7];			/* ��]���i					*/
            // 	char	h_kk[7];			/* �̔����i					*/
            // 	char	nm[17];				/* �i��						*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // 	char	mark[1];			/* �}�[�N					*/
            // };
            // 
            // struct	HDT_21_R {			/* ����  ���ʂQ�[�P			*/
            // 	char	on_no[2];			/* �I�����C���m��			*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	spc[13];			/* ��						*/
            // 	char	nkim[1];			/* �[���l					*/
            // 	char	daim[1];			/* ��ւl					*/
            // 	char	orosi[3];			/* ��						*/
            // 	char	ta[3];				/* ��						*/
            // 	char	hm[2];				/* �g�l						*/
            // 	char	k_kk[7];			/* ��]���i					*/
            // 	char	h_kk[7];			/* �̔����i					*/
            // 	char	nm[17];				/* �i��						*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // 	char	mark[1];			/* �}�[�N					*/
            // };
            // 
            // struct	HDT_22_R {				/* ����  ���ʂQ�[�Q			*/
            // 	char	on_no[2];			/* �I�����C���m��			*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	msg[10];			/* ���b�Z�[�W				*/
            // 	char	bo[3];				/* �a�^�n��					*/
            // 	char	spc[24];			/* ��						*/
            // 	char	nm[17];				/* �i��						*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // 	char	mark[1];			/* �}�[�N					*/
            // };
            // 
            // struct	HDT_3_R {				/* ����  ���ʂR				*/
            // 	char	on_no[2];			/* �I�����C���m��			*/
            // 	char	skb_flg[1];			/* ���ʃt���O				*/
            // 	char	spc[37];			/* ��						*/
            // 	char	msg[17];			/* ���b�Z�[�W				*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // 	char	mark[1];			/* �}�[�N					*/
            // };
            // 
            # endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//�ő�d����
            private const Int32 ctBufLen = 6;		//���׃o�b�t�@�T�C�Y
            private const Int32 ctDt_hLen = 73;     //�f�[�^�����R�[�h�T�C�Y
			# endregion

			# region �d���̈�N���X

            # region ������M�f�[�^
            /// <summary>
            /// ������M�f�[�^
            /// </summary>
            private class HRV_BUFF
            {
                //�����w�b�_�[��
                public int _uOESalesOrderNo = 0;                    // UOE�����ԍ�
                public List<int> _uOESalesOrderRowNoList = null;    //UOE�����ԍ��s�ԍ�

                public int _dataSendCode = 0;                       // �f�[�^���M�敪
                public int _dataRecoverDiv = 0;                     // �f�[�^�����敪

                public int divHRV = 0;              // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                public HHD_1 hhd_1 = null;          // ���d��
                public HHD_ERR hhd_err = null;          // ���d���w�b�_�[�G���[


                // �����f�[�^��
                public List<DT_H> dt_h_List = null;

                public HRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;

                    if(_uOESalesOrderRowNoList == null)
                    {
                        _uOESalesOrderRowNoList = new List<int>();
                    }
                    else
                    {
                        _uOESalesOrderRowNoList.Clear();
                    }

                    divHRV = 0;
                    hhd_1 = null;
                    hhd_err = null;

                    if (dt_h_List == null)
                    {
                        dt_h_List = new List<DT_H>();
                    }
                    else
                    {
                        dt_h_List.Clear();
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
                    divHRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // �G���[���䕔
                    if ((divHRV >= 1) && divHRV <= 3)
                    {
                        hhd_err = new HHD_ERR();
                        hhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;
                    }
                    //���d���w�b�_�[�i�[����
                    else
                    {
                        hhd_1 = new HHD_1();
                        hhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
			        # endregion

                    # region �f�[�^���X�V
                    // �f�[�^���@�X�V
                    if (divHRV == 0)
                    {
                        int start = 65;                                 //���d���ʒu�̐ݒ�
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
                                DT_H dt_h = new DT_H();
                                dt_h.Setting(uoeRecDtl.RecTelegram, idx);
                                dt_h_List.Add(dt_h);
                            }
                            start = 8;                    // ���d���ʒu�̐ݒ�
                        }
                    }
        			# endregion
                }
            }
			# endregion

            # region �d���w�b�_�[
            /// <summary>
            /// �d���w�b�_�[
            /// </summary>
            private class HHD_1
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
                public byte[] item = new byte[5];			// �A�C�e��					
                public byte[] deno = new byte[6];			// �`�[�m��					
                public byte[] dai_cd = new byte[5];			// �㗝�X�R�[�h				
                public byte[] kensu = new byte[2];			// �S�̌���					

                public HHD_1()
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
                    UoeCommonFnc.MemSet(ref item, cd, item.Length);			// �A�C�e��					
                    UoeCommonFnc.MemSet(ref deno, cd, deno.Length);			// �`�[�m��					
                    UoeCommonFnc.MemSet(ref dai_cd, cd, dai_cd.Length);		// �㗝�X�R�[�h				
                    UoeCommonFnc.MemSet(ref kensu, cd, kensu.Length);		// �S�̌���		

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
                    ms.Read(item, 0, item.Length);			// �A�C�e��					
                    ms.Read(deno, 0, deno.Length);			// �`�[�m��					
                    ms.Read(dai_cd, 0, dai_cd.Length);		// �㗝�X�R�[�h				
                    ms.Read(kensu, 0, kensu.Length);		// �S�̌���					

                    ms.Close();
                }
            }
			# endregion

            # region �d���w�b�_�[�G���[
            /// <summary>
            /// �d���w�b�_�[�G���[
            /// </summary>
            private class HHD_ERR
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

                public HHD_ERR()
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
            # region �����f�[�^�����C��
            /// <summary>
            /// �����f�[�^�����C��
            /// </summary>
            private class DT_H
            {
                public int divHDT = 0;              // ���ʃt���O 1:����1 21:����2-1 22:����2-2 3:����3
                public int _uOESalesOrderRowNo = 0; // UOE�����s�ԍ�

                public HDT_1_R hdt_1 = null;	    // �����@�f�[�^���i����1�j
                public HDT_21_R hdt_21 = null;	    // �����@�f�[�^���i����2-1�j
                public HDT_22_R hdt_22 = null;	    // �����@�f�[�^���i����2-2�j
                public HDT_3_R hdt_3 = null;	    // �����@�f�[�^���i����3�j

                public DT_H()
                {
                    Clear();
                }

                public void Clear()
                {
                    divHDT = 0;
                    _uOESalesOrderRowNo = 0;
                    hdt_1 = null;
                    hdt_21 = null;
                    hdt_22 = null;
                    hdt_3 = null;
                }

                public void Setting(byte[] line, int start)
                {
                    try
                    {
                        if(line == null)    return;

                        Clear();

                        //���� 1 or 3 ����
                        divHDT = UoeCommonFnc.atobs(line, start + 2, 1);

                        //���� 2-1 or 2-2 ����
                        if(divHDT == 2)
                        {
                            if ((UoeCommonFnc.MemCmp(line, start+3, 0x20, 13) == 0)
                            && (UoeCommonFnc.MemCmp(line, start+16, 0x20, 24) != 0))
                            {
                                divHDT = 21;
                            }
                            else
                            {
                                divHDT = 22;
                            }
                        }

                        switch(divHDT)
                        {
                            case 1:
                                hdt_1 = new HDT_1_R();
                                hdt_1.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_1.on_no, hdt_1.on_no.Length);
                                break;
                            case 21:
                                hdt_21 = new HDT_21_R();
                                hdt_21.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_21.on_no, hdt_21.on_no.Length);
                                break;
                            case 22:
                                hdt_22 = new HDT_22_R();
                                hdt_22.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_22.on_no, hdt_22.on_no.Length);
                                break;
                            case 3:
                                hdt_3 = new HDT_3_R();
                                hdt_3.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_3.on_no, hdt_3.on_no.Length);
                                break;
                            default:
                                divHDT = 0;
                                _uOESalesOrderRowNo = 0;
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

            # region �����f�[�^��(���ʂP)
            /// <summary>
            /// �����f�[�^��(���ʂP)
            /// </summary>
            private class HDT_1_R
            {
                public byte[] on_no = new byte[2];			// �I�����C���m��			
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] hb = new byte[15];			// �o�וi��					
                public byte[] sijisu = new byte[3];			// �w����					
                public byte[] hky = new byte[5];			// �o�׌�					
                public byte[] k_kk = new byte[7];			// ��]���i					
                public byte[] h_kk = new byte[7];			// �̔����i					
                public byte[] nm = new byte[17];			// �i��						
                public byte[] dsp_hb = new byte[15];		// �\���p���i				
                public byte[] mark = new byte[1];			// �}�[�N					

                public HDT_1_R()
				{
					Clear(0x00);
				}

                public HDT_1_R(byte[] line, int start)
                {
                    Clear(0x00);
                }
				

				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// �I�����C���m��			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
                    UoeCommonFnc.MemSet(ref hb, cd, hb.Length);				// �o�וi��					
                    UoeCommonFnc.MemSet(ref sijisu, cd, sijisu.Length);		// �w����					
                    UoeCommonFnc.MemSet(ref hky, cd, hky.Length);			// �o�׌�					
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// ��]���i					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// �̔����i					
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// �i��						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// �}�[�N					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// �I�����C���m��			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(hb, 0, hb.Length);				// �o�וi��					
                    ms.Read(sijisu, 0, sijisu.Length);		// �w����					
                    ms.Read(hky, 0, hky.Length);			// �o�׌�					
                    ms.Read(k_kk, 0, k_kk.Length);			// ��]���i					
                    ms.Read(h_kk, 0, h_kk.Length);			// �̔����i					
                    ms.Read(nm, 0, nm.Length);				// �i��						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// �\���p���i				
                    ms.Read(mark, 0, mark.Length);			// �}�[�N					

                    ms.Close();
                }
            }
			# endregion

            # region �����f�[�^��(���ʂQ�[�P)
            /// <summary>
            /// �����f�[�^��(���ʂQ�[�P)
            /// </summary>
            private class HDT_21_R
            {
                public byte[] on_no = new byte[2];			// �I�����C���m��			
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] spc = new byte[13];			// ��						
                public byte[] nkim = new byte[1];			// �[���l					
                public byte[] daim = new byte[1];			// ��ւl					
                public byte[] orosi = new byte[3];			// ��						
                public byte[] ta = new byte[3];				// ��						
                public byte[] hm = new byte[2];				// �g�l						
                public byte[] k_kk = new byte[7];			// ��]���i					
                public byte[] h_kk = new byte[7];			// �̔����i					
                public byte[] nm = new byte[17];			// �i��						
                public byte[] dsp_hb = new byte[15];		// �\���p���i				
                public byte[] mark = new byte[1];			// �}�[�N					

                public HDT_21_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// �I�����C���m��			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// ��						
                    UoeCommonFnc.MemSet(ref nkim, cd, nkim.Length);			// �[���l					
                    UoeCommonFnc.MemSet(ref daim, cd, daim.Length);			// ��ւl					
                    UoeCommonFnc.MemSet(ref orosi, cd, orosi.Length);		// ��						
                    UoeCommonFnc.MemSet(ref ta, cd, ta.Length);				// ��						
                    UoeCommonFnc.MemSet(ref hm, cd, hm.Length);				// �g�l						
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// ��]���i					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// �̔����i					
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// �i��						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// �}�[�N					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// �I�����C���m��			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(spc, 0, spc.Length);			// ��						
                    ms.Read(nkim, 0, nkim.Length);		// �[���l					
                    ms.Read(daim, 0, daim.Length);		// ��ւl					
                    ms.Read(orosi, 0, orosi.Length);		// ��						
                    ms.Read(ta, 0, ta.Length);			// ��						
                    ms.Read(hm, 0, hm.Length);			// �g�l						
                    ms.Read(k_kk, 0, k_kk.Length);		// ��]���i					
                    ms.Read(h_kk, 0, h_kk.Length);		// �̔����i					
                    ms.Read(nm, 0, nm.Length);			// �i��						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);	// �\���p���i				
                    ms.Read(mark, 0, mark.Length);		// �}�[�N					

                    ms.Close();
                }
            }
			# endregion

            # region �����f�[�^��(���ʂQ�[�Q)
            /// <summary>
            /// �����f�[�^��(���ʂQ�[�Q)
            /// </summary>
            private class HDT_22_R
            {
                public byte[] on_no = new byte[2];			// �I�����C���m��			
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] msg = new byte[10];			// ���b�Z�[�W				
                public byte[] bo = new byte[3];				// �a�^�n��					
                public byte[] spc = new byte[24];			// ��						
                public byte[] nm = new byte[17];			// �i��						
                public byte[] dsp_hb = new byte[15];		// �\���p���i				
                public byte[] mark = new byte[1];			// �}�[�N					

                public HDT_22_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// �I�����C���m��			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// ���b�Z�[�W				
                    UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// �a�^�n��					
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// ��						
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// �i��						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// �}�[�N					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// �I�����C���m��			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(msg, 0, msg.Length);			// ���b�Z�[�W				
                    ms.Read(bo, 0, bo.Length);			// �a�^�n��					
                    ms.Read(spc, 0, spc.Length);			// ��						
                    ms.Read(nm, 0, nm.Length);			// �i��						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);	// �\���p���i				
                    ms.Read(mark, 0, mark.Length);		// �}�[�N					

                    ms.Close();
                }
            }
			# endregion

            # region �����f�[�^��(���ʂR)
            /// <summary>
            /// �����f�[�^��(���ʂR)
            /// </summary>
            private class HDT_3_R
            {
                public byte[] on_no = new byte[2];			// �I�����C���m��			
                public byte[] skb_flg = new byte[1];		// ���ʃt���O				
                public byte[] spc = new byte[37];			// ��						
                public byte[] msg = new byte[17];			// ���b�Z�[�W				
                public byte[] dsp_hb = new byte[15];		// �\���p���i				
                public byte[] mark = new byte[1];			// �}�[�N					

                public HDT_3_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// �I�����C���m��			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// ���ʃt���O				
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// ��						
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// ���b�Z�[�W				
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// �}�[�N					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// �I�����C���m��			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// ���ʃt���O				
                    ms.Read(spc, 0, spc.Length);			// ��						
                    ms.Read(msg, 0, msg.Length);			// ���b�Z�[�W				
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// �\���p���i				
                    ms.Read(mark, 0, mark.Length);			// �}�[�N					

                    ms.Close();
                }
            }
        	# endregion
			# endregion

            # endregion

			# region Private Members
			//�ϐ�
            private UOESupplier _uOESupplier = null;

            private Int32 _detailMax = 0;

            private List<HRV_BUFF> hrv_list = null; 
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder0501()
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
                if(hrv_list == null)
                {
                    hrv_list = new List<HRV_BUFF>();
                }
                else
                {
                    hrv_list.Clear();
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
                HRV_BUFF hrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // ���񎞏���
                    if (hrv_buff == null)
                    {
                        hrv_buff = new HRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        hrv_buff._dataSendCode = dtl.DataSendCode;
                        hrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE�����ԍ��̃`�F�b�N
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // ���X�g�ւƕۑ�
                        hrv_list.Add(hrv_buff);

                        // �N���A����
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        hrv_buff = new HRV_BUFF();
                    }

                    //��M�f�[�^�i�[����
                    hrv_buff.Setting(dtl);
                }

                // �ҏW���̎�M�f�[�^�i�[����
                if (hrv_buff != null)
                {
                    hrv_list.Add(hrv_buff);
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
                // UOE������̎擾
                int uOESupplierCd = uoeRecHed.UOESupplierCd;
                _uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);

                //-----------------------------------------------------------
                // ����M�G���[�̐ݒ菈��
                //-----------------------------------------------------------
                # region ����M�G���[�̐ݒ菈��
                foreach (UoeRecDtl dtl in uoeRecHed.UoeRecDtlList)
                {
                    foreach (int uOESalesOrderRowNo in dtl.UOESalesOrderRowNo)
                    {

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                        uOESupplierCd,
                                                        dtl.UOESalesOrderNo,
                                                        uOESalesOrderRowNo);

                        if (dataRow == null)
                        {
                            continue;
                        }

                        //�f�[�^���M�敪
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

                        //�f�[�^�����敪
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
                    }
                }
                # endregion

                //�o�C�g�^�z��ɕϊ�
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //�d���ϐ�����
                foreach (HRV_BUFF hrv_buff in hrv_list)
                {
                    # region �G���[���䕔 �X�V
                    // �G���[���䕔 �X�V
                    // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                    if (hrv_buff.divHRV >= 1 && hrv_buff.divHRV <= 3)
                    {
                        ToDataRowFromHdt_5(hrv_buff, _uOESupplier.UOESupplierCd);
                        continue;
                    }
        			# endregion

                    # region �w�b�_�[�E�f�[�^�� �X�V
                    // �w�b�_�[�E�f�[�^�� �X�V
                    foreach(DT_H dt_h in hrv_buff.dt_h_List)
                    {
                        //�擾������MJNL-DATATABLE������MJNL-CLASS��
                        int uOESalesOrderNo = hrv_buff._uOESalesOrderNo;
                        int uOESalesOrderRowNo = dt_h._uOESalesOrderRowNo;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //�f�[�^���M�敪
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = hrv_buff._dataSendCode;

                        //�f�[�^�����敪
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = hrv_buff._dataRecoverDiv;

                        //��M���t(YYYYMMDD)
                        dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(hrv_buff.hhd_1.date);

                        //��M����(HHMM)
                        dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(hrv_buff.hhd_1.time);

                        // ���ʃt���O 1:����1 21:����2-1 22:����2-2 3:����3
                        switch(dt_h.divHDT)
                        {
                            //����1
                            case 1:
                                ToDataRowFromHdt_1(ref dataRow, hrv_buff.hhd_1, dt_h.hdt_1);
                                break;
                            //����2-1
                            case 21:
                                ToDataRowFromHdt_21(ref dataRow, dt_h.hdt_21);
                                break;
                            //����2-2
                            case 22:
                                ToDataRowFromHdt_22(ref dataRow, dt_h.hdt_22);
                                break;
                            //����3
                            case 3:
                                ToDataRowFromHdt_3(ref dataRow, dt_h.hdt_3);
                                break;
                        }
                    }
        			# endregion
                }
            }
            # endregion

            # region �f�[�^�G���[�X�V
            /// <summary>
            /// �f�[�^�G���[�X�V
            /// </summary>
            /// <param name="hrv_buff">������M�f�[�^</param>
            /// <param name="uOESupplierCd">������R�[�h</param>
            private void ToDataRowFromHdt_5(HRV_BUFF hrv_buff, int uOESupplierCd)
            {
                HHD_ERR hhd_err = hrv_buff.hhd_err;

                int uOESalesOrderNo = hrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in hrv_buff._uOESalesOrderRowNoList)
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
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(hhd_err.date);

                    //��M����(HHMM)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(hhd_err.time);

                    // �w�b�_�[�G���[�Z�b�g
                    if (hhd_err.skb_flg[0] == '2')
                    {
                        string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hhd_err.errmsg);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }
                    // �G���[���䕔�@�Z�b�g
                    else if((hhd_err.skb_flg[0] == '1') || (hhd_err.skb_flg[0] == '3') )
                    {
                        string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hhd_err.sei);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }
                }
            }
            # endregion

            # region �f�[�^���X�V(����1)
            /// <summary>
            /// �f�[�^���X�V(����1)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="hrv_buff">������M�f�[�^</param>
            private void ToDataRowFromHdt_1(ref DataRow dataRow, HHD_1 hhd_1, HDT_1_R hdt_1)
            {
                string hb1 = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hb);
                string hb2 = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.dsp_hb);

                // ��֕i��������
                if(hb1.Trim() != hb2.Trim())
	            {
                    // �񓚕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = hb2;

                    // �񓚕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.nm);

                    // ��֕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = hb1;
                }
                // ��֕i�����Ȃ�
                else									
                {
                    // �񓚕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = hb1;

                    // �񓚕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.nm);

                    // ��֕i��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = "";
                }
				
                // �K�p�艿
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_1.k_kk);
				
                // �d�ؒP��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_1.h_kk);

                // �}�[�N
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.mark);

                // �o�׌��N���A
                dataRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = "";

                // �w���������ޗp���_�@��r
                string hondaSectionCode = _uOESupplier.HondaSectionCode.Trim(); // �z���_�S�����_
                string hkySstring =  UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hky);
                
                if(hondaSectionCode.Trim() == hkySstring.Trim())
                {
                    // ���_�o�ɐ��@���Z
                    int cnt = (int)dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.atobs(hdt_1.sijisu, hdt_1.sijisu.Length) + cnt;
					
                    // ���_�`�[�m���Z�b�g
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(hhd_1.deno);
                }
                else
                {
                    // �o�׌��i�{���e�p�j
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hky);
					
                    // �{���e���@���Z
                    int cnt = (int)dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];
                    dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.atobs(hdt_1.sijisu, hdt_1.sijisu.Length) + cnt;
					
                    // �{���e�`�[�m���Z�b�g
                    dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(hhd_1.deno);
                }
            }
            # endregion

            # region �f�[�^���X�V(����21)
            /// <summary>
            /// �f�[�^���X�V(����21)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="hrv_buff">������M�f�[�^</param>
            private void ToDataRowFromHdt_21(ref DataRow dataRow, HDT_21_R hdt_21)
            {

                // �񓚕i��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.dsp_hb);

                // �i��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.nm);

                // �}�[�N
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.mark);

                // ��֖���
                if (hdt_21.daim[0] == '0' || hdt_21.daim[0] == ' ' || hdt_21.daim[0] == 0x00)
	            {
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "";
	            }
                // ��֗L��
                else
                {
                    // ��փ}�[�N
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.daim);
	            }

                // ��
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.orosi);

                // ��
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.ta);
				
                // �g�l
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEHMCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.hm);

				
                // �K�p�艿
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_21.k_kk);
				
                // �d�ؒP��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_21.h_kk);
            }
            # endregion

            # region �f�[�^���X�V(����22)
            /// <summary>
            /// �f�[�^���X�V(����22)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="hrv_buff">������M�f�[�^</param>
            private void ToDataRowFromHdt_22(ref DataRow dataRow, HDT_22_R hdt_22)
            {
                // �񓚕i��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.dsp_hb);

				// �i��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.nm);
                
                // �}�[�N
				dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.mark);

                // ���b�Z�[�W
                string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.msg);
                dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

                // �a�n��
	            dataRow[OrderSndRcvJnlSchema.ct_Col_BOCount] = UoeCommonFnc.atobs( hdt_22.bo, hdt_22.bo.Length );
            }
            # endregion

            # region �f�[�^���X�V(����3)
            /// <summary>
            /// �f�[�^���X�V(����3)
            /// </summary>
            /// <param name="dataRow">�f�[�^�e�[�u�����f�[�^</param>
            /// <param name="hrv_buff">������M�f�[�^</param>
            private void ToDataRowFromHdt_3(ref DataRow dataRow, HDT_3_R hdt_3)
            {
                // �񓚕i��
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.dsp_hb);

				//���C���G���[���b�Z�[�W
                string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.msg);
                dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

				//�i��
				dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

                //�}�[�N
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.mark);
            }
            # endregion

            # endregion

			# region private Methods



            # endregion
        }
		# endregion

		# endregion


	}
}
