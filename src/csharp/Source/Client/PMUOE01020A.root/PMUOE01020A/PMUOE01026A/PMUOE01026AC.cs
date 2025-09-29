//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�����ρ��i�z���_�j���s��
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
	/// �t�n�d��M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW�����ρ��i�z���_�j
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ��i�z���_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlEstmt0501(out string message)
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
                    TelegramJnlEstmt0501 telegramJnlEstmt0501 = new TelegramJnlEstmt0501();
                    telegramJnlEstmt0501.Telegram(_uoeRecHed);
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

		# region �t�n�d��M�d���쐬�����ρ��i�z���_�j
		/// <summary>
		/// �t�n�d��M�d���쐬�����ρ��i�z���_�j
		/// </summary>
		public class TelegramJnlEstmt0501 : UoeRecEdit0501Acs
		{
			# region �o�l�V�\�[�X
            // /************************************************************/
            // /********            ����  �S�̃w�b�_�[��            ********/
            // /************************************************************/
            // struct MHD_1 {					/* ����  ���d��  			*/
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
            // /********            ����  �f�[�^��                  ********/
            // /************************************************************/
            // struct	MDT_R {					/* ���σf�[�^��				*/
            // 	char	nm[17];				/* �i��						*/
            // 	char	k_kk[7];			/* ��]���i					*/
            // 	char	h_kk[7];			/* �̔����i					*/
            // 	char	zaim[1];			/* �݌ɗL�l					*/
            // 	char	or_zai[2];			/* ���X�݌ɂl				*/
            // 	char	nkim[1];			/* �[���l					*/
            // 	char	daim[1];			/* ��ւl					*/
            // 	char	dsp_hb[15];			/* �\���p���i				*/
            // 	char	lmsg[9];			/* �R�����g�iײ�ү���ށj	*/
            // };
            # endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//�ő�d����
			private const Int32 ctBufLen = 7;		//���׃o�b�t�@�T�C�Y
            private const Int32 ctDt_hLen = 60;     //�f�[�^�����R�[�h�T�C�Y
            # endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
            private List<MRV_BUFF> mrv_list = null;
            # endregion

			# region �d���̈�N���X
            # region ���ώ�M�f�[�^
            /// <summary>
            /// ���ώ�M�f�[�^
            /// </summary>
            private class MRV_BUFF
            {
                //���σw�b�_�[��
                public int _uOESalesOrderNo = 0;                    // UOE�����ԍ�
                public List<int> _uOESalesOrderRowNoList = null;    //UOE�����ԍ��s�ԍ�

                public int _dataSendCode = 0;                       // �f�[�^���M�敪
                public int _dataRecoverDiv = 0;                     // �f�[�^�����敪

                public int divHRV = 0;              // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                public MHD_1 mhd_1 = null;          // ���d��
                public MHD_ERR mhd_err = null;      // ���d���w�b�_�[�G���[


                // �����f�[�^��
                public List<MDT_R> mdt_List = null;

                public MRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;
                    _uOESalesOrderRowNoList = new List<int>();

                    divHRV = 0;
                    mhd_1 = null;
                    mhd_err = null;

                    if (mdt_List == null)
                    {
                        mdt_List = new List<MDT_R>();
                    }
                    else
                    {
                        mdt_List.Clear();
                    }
                }

                public void Setting(UoeRecDtl uoeRecDtl)
                {
                    # region �w�b�_�[���X�V
                    //��P�d�� �w�b�_�[���X�V
                    //UOE�����ԍ� UOE�����s�ԍ��̕ۑ�
                    _uOESalesOrderNo = uoeRecDtl.UOESalesOrderNo;
                    _uOESalesOrderRowNoList = new List<int>();
                    _uOESalesOrderRowNoList.AddRange(uoeRecDtl.UOESalesOrderRowNo);

                    //���ʃt���O
                    divHRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // �G���[���䕔
                    if ((divHRV >= 1) && divHRV <= 3)
                    {
                        mhd_err = new MHD_ERR();
                        mhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;

                    }
                    //���d���w�b�_�[�i�[����
                    else
                    {
                        mhd_1 = new MHD_1();
                        mhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
                    # endregion

                    # region �f�[�^���X�V
                    // �f�[�^���@�X�V
                    if (divHRV == 0)
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
                                MDT_R mdt = new MDT_R();
                                mdt.Setting(uoeRecDtl.RecTelegram, idx);
                                mdt_List.Add(mdt);
                            }
                            start = 8;                    // ���d���ʒu�̐ݒ�
                        }
                    }
                    # endregion
                }
            }
            # endregion

			# region ����  ���d��
            /// <summary>
            /// ����  ���d��
            /// </summary>
            private class MHD_1
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

                public MHD_1()
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
            private class MHD_ERR
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

                public MHD_ERR()
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

            # region ���σf�[�^��
            /// <summary>
            /// ���σf�[�^��
            /// </summary>
            private class MDT_R
            {
                public byte[] nm = new byte[17];			// �i��						
                public byte[] k_kk = new byte[7];			// ��]���i					
                public byte[] h_kk = new byte[7];			// �̔����i					
                public byte[] zaim = new byte[1];			// �݌ɗL�l					
                public byte[] or_zai = new byte[2];			// ���X�݌ɂl				
                public byte[] nkim = new byte[1];			// �[���l					
                public byte[] daim = new byte[1];			// ��ւl					
                public byte[] dsp_hb = new byte[15];		// �\���p���i				
                public byte[] lmsg = new byte[9];			// �R�����g�iײ�ү���ށj	

                public MDT_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// �i��						
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// ��]���i					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// �̔����i					
                    UoeCommonFnc.MemSet(ref zaim, cd, zaim.Length);			// �݌ɗL�l					
                    UoeCommonFnc.MemSet(ref or_zai, cd, or_zai.Length);		// ���X�݌ɂl				
                    UoeCommonFnc.MemSet(ref nkim, cd, nkim.Length);			// �[���l					
                    UoeCommonFnc.MemSet(ref daim, cd, daim.Length);			// ��ւl					
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// �\���p���i				
                    UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// �R�����g�iײ�ү���ށj	
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    // ���σf�[�^��
                    ms.Read(nm, 0, nm.Length);					// �i��						
                    ms.Read(k_kk, 0, k_kk.Length);				// ��]���i					
                    ms.Read(h_kk, 0, h_kk.Length);				// �̔����i					
                    ms.Read(zaim, 0, zaim.Length);				// �݌ɗL�l					
                    ms.Read(or_zai, 0, or_zai.Length);			// ���X�݌ɂl				
                    ms.Read(nkim, 0, nkim.Length);				// �[���l					
                    ms.Read(daim, 0, daim.Length);				// ��ւl					
                    ms.Read(dsp_hb, 0, dsp_hb.Length);			// �\���p���i				
                    ms.Read(lmsg, 0, lmsg.Length);				// 

                    ms.Close();
                }

            }
            # endregion
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlEstmt0501()
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
                if (mrv_list == null)
                {
                    mrv_list = new List<MRV_BUFF>();
                }
                else
                {
                    mrv_list.Clear();
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
                MRV_BUFF mrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // ���񎞏���
                    if (mrv_buff == null)
                    {
                        mrv_buff = new MRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        mrv_buff._dataSendCode = dtl.DataSendCode;
                        mrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE�����ԍ��̃`�F�b�N
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // ���X�g�ւƕۑ�
                        mrv_list.Add(mrv_buff);

                        // �N���A����
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        mrv_buff = new MRV_BUFF();
                    }

                    //��M�f�[�^�i�[����
                    mrv_buff.Setting(dtl);
                }

                // �ҏW���̎�M�f�[�^�i�[����
                if (mrv_buff != null)
                {
                    mrv_list.Add(mrv_buff);
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
                int uOESupplierCd = uoeRecHed.UOESupplierCd;

                //�o�C�g�^�z��ɕϊ�
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //�d���ϐ�����
                foreach (MRV_BUFF mrv_buff in mrv_list)
                {
                    # region �G���[���䕔 �X�V
                    // �G���[���䕔 �X�V
                    // ���ʃt���O 0:�f�[�^���X�V 1,3:�G���[���䕔�Z�b�g 2:�w�b�_�[�G���[�Z�b�g
                    if (mrv_buff.divHRV >= 1 && mrv_buff.divHRV <= 3)
                    {
                        ToDataRowFromHdt_err(mrv_buff, uOESupplierCd);
                        continue;
                    }
                    # endregion

                    # region �w�b�_�[�E�f�[�^�� �X�V
                    // �w�b�_�[�E�f�[�^�� �X�V
                    int uOESalesOrderRowNo = 0;
                    foreach (MDT_R mdt in mrv_buff.mdt_List)
                    {
                        //�擾������MJNL-DATATABLE������MJNL-CLASS��
                        int uOESalesOrderNo = mrv_buff._uOESalesOrderNo;
                        uOESalesOrderRowNo++;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlEstmtTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //�f�[�^���M�敪
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = mrv_buff._dataRecoverDiv;

                        //�f�[�^�����敪
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = mrv_buff._dataRecoverDiv;

                        //��M���t(YYYYMMDD)
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(mrv_buff.mhd_1.date);

                        //��M����(HHMM)
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(mrv_buff.mhd_1.time);

                        // �i��
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(mdt.dsp_hb);
	                    
                        // �i��
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(mdt.nm);
						
                        // �K�p���i
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.k_kk);
						
                        // �d�ؒP��
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.h_kk);
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.h_kk);

                        // �\�����_�݌ɐ�
                        int branchStock = UoeCommonFnc.ToInt32FromByteStrAry(mdt.or_zai);
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = branchStock.ToString();

                        // �[��ϰ�
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(mdt.nkim);
						
                        // �݌�ϰ�
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(mdt.zaim);

                        // �݊�����
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(mdt.daim);
						
                        // �װү����
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(mdt.lmsg);
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
            /// <param name="mrv_buff">������M�f�[�^</param>
            /// <param name="uOESupplierCd">������R�[�h</param>
            private void ToDataRowFromHdt_err(MRV_BUFF mrv_buff, int uOESupplierCd)
            {
                MHD_ERR mhd_err = mrv_buff.mhd_err;

                int uOESalesOrderNo = mrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in mrv_buff._uOESalesOrderRowNoList)
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
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(mhd_err.date);

                    //��M����(HHMM)
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(mhd_err.time);

                    // �G���[���䕔�@�Z�b�g
                    string errMessage = UoeCommonFnc.ToStringFromByteStrAry(mhd_err.sei);

                    //�w�b�h�G���[���b�Z�[�W
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;
                }
            }
            # endregion

			# endregion
		}
		# endregion

		# endregion
	}
}
