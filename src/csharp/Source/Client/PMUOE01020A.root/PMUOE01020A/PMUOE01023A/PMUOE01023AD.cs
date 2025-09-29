//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i�O�H�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i�O�H�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
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
	/// �t�n�d��M�ҏW���݌Ɂ��i�O�H�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i�O�H�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0301Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i�O�H�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�O�H�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0301(out string message)
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
                    TelegramJnlStock0301 telegramJnlStock0301 = new TelegramJnlStock0301();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0301.Telegram(_uoeRecHed.UOESupplierCd, dtl);
                    }
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

		# region �t�n�d��M�d���쐬���݌Ɂ��i�O�H�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i�O�H�j
		/// </summary>
		public class TelegramJnlStock0301 : UoeRecEdit0301Acs
		{
			# region �o�l�V�\�[�X
			//�w�b�_�[��
			//struct	HEAD{
			//	char	jkbn[1] ;					/* ���敪						*/
			//	short	seq_no ;					/* �e�L�X�g�V�[�P���X�ԍ�		*/
			//	short	text_len ;					/* �e�L�X�g��					*/
			//	char	dkbn[1] ;					/* �d���敪						*/
			//	char	kekka[1] ;					/* ��������						*/
			//	char	tokbn[1] ;					/* �⍇���^�����敪				*/
			//	char	g_id[12] ;					/* �Ɩ��h�c						*/
			//	char	g_pass[6] ;					/* �Ɩ��p�X���[�h				*/
			//	char	prog_ver[3] ;				/* �[���v���O�����o�[�W�����ԍ�	*/
			//	char	kkbn[1] ;					/* �p���敪						*/
			//	char	h_id[3] ;					/* ����h�c						*/
			//	char	ext[15] ;					/* �g���G���A					*/
			//	char	gsk[1] ;					/* �Ɩ���������					*/
			//	char	gsf[1] ;					/* �Ɩ��p���t���O				*/
			//	char	seq[3] ;					/* �V�[�P���X�m�n				*/
			//	char	bymd[4] ;					/* �[�����͓��t�E����			*/
			//	char	ymdhms[8] ;					/* �z�X�g���t�E����				*/
			//};
			//
			//struct	ZAIKO{
			//	struct	HEAD	head ;
			//	char	syamei[20] ;				/* ��Ж�						*/
			//	struct	ZKYO	zkyo[31] ;			/* ���_��						*/
			//	struct	ZDATA	zdata[6] ;			/* ���C�����ڂP�`�U				*/
			//};
			//
			//struct	ZKYO{
			//	char	kyo[6] ;					/* ���_��						*/
			//};
			
			//���ו�
			//struct	ZDATA{
			//	char	khb[10] ;					/* ���i�ԍ�						*/
			//	char	knm[20] ;					/* �i��							*/
			//	char	lp[7] ;						/* �k�^�o						*/
			//	char	zsu00[5] ;					/* �{�ɍ݌ɐ�					*/
			//	char	gokan1[1] ;					/* ��֋敪						*/
			//	char	newhb[10] ;					/* �V���i�ԍ�					*/
			//	struct	ZKSU	zksu[31] ;			/* ���_�݌ɐ�					*/
			//	char	lemsg[10] ;					/* �G���[���b�Z�[�W				*/
			//};
			//
			//struct	ZKSU{
			//	char	zsu[3] ;					/* ���_�݌ɐ�					*/
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//���׃o�b�t�@�T�C�Y
			private DN_Z dn_z = new DN_Z();
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_Z dn_m = new DN_Z(); 
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
				public byte[]	khb = new byte[10] ;					// ���i�ԍ�						
				public byte[]	knm = new byte[20] ;					// �i��							
				public byte[]	lp = new byte[7] ;						// �k�^�o						
				public byte[]	zsu00 = new byte[5] ;					// �{�ɍ݌ɐ�					
				public byte[]	gokan1 = new byte[1] ;					// ��֋敪						
				public byte[]	newhb = new byte[10] ;					// �V���i�ԍ�					
				public byte[][]	zsu = new byte[31][] ;					// ���_�݌ɐ�					
				public byte[]	lemsg = new byte[10] ;					// �G���[���b�Z�[�W				

				public LN_Z()
				{
					for (int j = 0; j < 31; j++)
					{
						zsu[j] = new byte[3];					//          ���_�݌ɐ�02-32   
					}
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);				// ���i�ԍ�						
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);				// �i��							
					UoeCommonFnc.MemSet(ref lp, cd, lp.Length);					// �k�^�o						
					UoeCommonFnc.MemSet(ref zsu00, cd, zsu00.Length);			// �{�ɍ݌ɐ�					
					UoeCommonFnc.MemSet(ref gokan1, cd, gokan1.Length);			// ��֋敪						
					UoeCommonFnc.MemSet(ref newhb, cd, newhb.Length);			// �V���i�ԍ�					
					UoeCommonFnc.MemSet(ref lemsg, cd, lemsg.Length);			// �G���[���b�Z�[�W				

					for (int j = 0; j < 31; j++)
					{
						UoeCommonFnc.MemSet(ref zsu[j], cd, zsu[j].Length);	//���_�݌ɐ�   
					}
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[]	jkbn = new byte[1] ;					// ���敪						
				public byte[]	seq_no = new byte[2] ;					// �e�L�X�g�V�[�P���X�ԍ�		
				public byte[]	text_len = new byte[2] ;				// �e�L�X�g��					
				public byte[]	dkbn = new byte[1] ;					// �d���敪						
				public byte[]	kekka = new byte[1] ;					// ��������						
				public byte[]	tokbn = new byte[1] ;					// �⍇���^�����敪				
				public byte[]	g_id = new byte[12] ;					// �Ɩ��h�c						
				public byte[]	g_pass = new byte[6] ;					// �Ɩ��p�X���[�h				
				public byte[]	prog_ver = new byte[3] ;				// �[���v���O�����o�[�W�����ԍ�	
				public byte[]	kkbn = new byte[1] ;					// �p���敪						
				public byte[]	h_id = new byte[3] ;					// ����h�c						
				public byte[]	ext = new byte[15] ;					// �g���G���A					
				public byte[]	gsk = new byte[1] ;						// �Ɩ���������					
				public byte[]	gsf = new byte[1] ;						// �Ɩ��p���t���O				
				public byte[]	seq = new byte[3] ;						// �V�[�P���X�m�n				
				public byte[]	bymd = new byte[4] ;					// �[�����͓��t�E����			
				public byte[]	ymdhms = new byte[8] ;					// �z�X�g���t�E����				
				public byte[]	syamei = new byte[20] ;					// ��Ж�						
				public byte[][]	kyo = new byte[31][];					// ���_��

				public LN_Z[] ln_z = new LN_Z[ctBufLen];// ײ�

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
				{
					for (int j = 0; j < 31; j++)
					{
						kyo[j] = new byte[6];							// ���_��   
					}
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);				// ���敪						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);			// �e�L�X�g�V�[�P���X�ԍ�		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);		// �e�L�X�g��					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);				// �d���敪						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);			// ��������						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);			// �⍇���^�����敪				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);				// �Ɩ��h�c						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);			// �Ɩ��p�X���[�h				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);		// �[���v���O�����o�[�W�����ԍ�	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);				// �p���敪						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);				// ����h�c						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);				// �g���G���A					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);				// �Ɩ���������					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);				// �Ɩ��p���t���O				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);				// �V�[�P���X�m�n				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);				// �[�����͓��t�E����			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);			// �z�X�g���t�E����				
					UoeCommonFnc.MemSet(ref syamei, cd, syamei.Length);			// ��Ж�						

					for (int j = 0; j < 31; j++)
					{
						UoeCommonFnc.MemSet(ref kyo[j], cd, kyo[j].Length);		// ���_��  
					}

					//���ו�
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_z[i] == null)
                        {
                            ln_z[i] = new LN_Z();
                        }
                        else
                        {
                            ln_z[i].Clear(0x00);
                        }
                    }
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock0301()
			{
				Clear(0x00);
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
			public void Clear(byte cd)
			{
				_detailMax = 0;
				dn_z.Clear(0x00);
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(Int32 uOESupplierCd, UoeRecDtl dtl)
			{
                //�J�ǁE�Ǔd���̃X�L�b�v����
                if ((dtl.UOESalesOrderNo == 0) && (dtl.UOESalesOrderRowNo.Count == 0)) return;

                //�o�C�g�^�z��ɕϊ�
				FromByteArray(dtl.RecTelegram);

				//�d���̍s���擾
				_detailMax = dtl.UOESalesOrderRowNo.Count;

				for (int i = 0; i < _detailMax; i++)
				{
					//�擾������MJNL-DATATABLE������MJNL-CLASS��
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlStockTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//�f�[�^���M�敪
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;


					//��M���t(YYYYMMDD)
					int int32Yymmdd = UoeCommonFnc.atobs(dn_z.ymdhms, 0, 4) * 100;

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//��M����(HHMM)
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_z.ymdhms, 4, 4) * 100;

					//�񓚓d���G���[����
					if (dn_z.kekka[0] == 0x99)
					{
						string errMessage = GetHeadErrorMassage(dn_z.kekka[0]);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					//��֗L���`�F�b�N���Z�b�g
					int sw = 0;	//0:��ւȂ� 1:��ւ���

					//���ϰ�
					//��ւ���
					if ((dn_z.ln_z[i].gokan1[0] != 0x00)
					&& (dn_z.ln_z[i].gokan1[0] != 0x20)
					&& (dn_z.ln_z[i].gokan1[0] != 0x30))
					{
                        dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].gokan1);
						sw = 1;
					}
					else
					{
						string goodsNoString = (string)dataRow[StockSndRcvJnlSchema.ct_Col_GoodsNo];
						string khbString = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//��ւ���
                        if (goodsNoString.Trim() != khbString.Trim())
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "01";
							sw = 1;
						}
						//��ւȂ�
						else
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "";
							sw = 0;
						}
					}

					//��ւȂ�
					if (sw == 0)
					{
						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].knm);
					}
					//��ւ���
					else
					{
						//��֕i��
                        dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].newhb);

						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].knm);
					}

					// �艿(�k�^�o)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].lp);

					// UOE���_�݌ɐ��P(�{�ɍ݌ɐ�)
                    dataRow[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu00);

					// ���_�݌ɐ�(1�`31)
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[0]);
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[1]);

					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[2]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[3]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[4]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[5]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[6]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[7]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[8]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[9]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[10]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[11]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[12]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[13]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[14]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[15]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[16]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[17]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[18]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[19]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[20]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[21]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[22]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[23]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[24]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[25]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[26]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[27]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[28]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[29]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[30]);

					// �G���[���b�Z�[�W
					dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].lemsg);
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region �o�C�g�^�z��ɕϊ�
			/// <summary>
			/// �o�C�g�^�z��ɕϊ�
			/// </summary>
			/// <returns></returns>
			private void FromByteArray(byte[] line)
			{
				_detailMax = 0;
				MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

				ms.Read(dn_z.jkbn, 0, dn_z.jkbn.Length);        // ���敪						
				ms.Read(dn_z.seq_no, 0, dn_z.seq_no.Length);    // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(dn_z.text_len, 0, dn_z.text_len.Length);// �e�L�X�g��					
				ms.Read(dn_z.dkbn, 0, dn_z.dkbn.Length);        // �d���敪						
				ms.Read(dn_z.kekka, 0, dn_z.kekka.Length);      // ��������						
				ms.Read(dn_z.tokbn, 0, dn_z.tokbn.Length);      // �⍇���^�����敪				
				ms.Read(dn_z.g_id, 0, dn_z.g_id.Length);        // �Ɩ��h�c						
				ms.Read(dn_z.g_pass, 0, dn_z.g_pass.Length);    // �Ɩ��p�X���[�h				
				ms.Read(dn_z.prog_ver, 0, dn_z.prog_ver.Length);// �[���v���O�����o�[�W�����ԍ�	
				ms.Read(dn_z.kkbn, 0, dn_z.kkbn.Length);        // �p���敪						
				ms.Read(dn_z.h_id, 0, dn_z.h_id.Length);        // ����h�c						
				ms.Read(dn_z.ext, 0, dn_z.ext.Length);          // �g���G���A					
				ms.Read(dn_z.gsk, 0, dn_z.gsk.Length);          // �Ɩ���������					
				ms.Read(dn_z.gsf, 0, dn_z.gsf.Length);          // �Ɩ��p���t���O				
				ms.Read(dn_z.seq, 0, dn_z.seq.Length);          // �V�[�P���X�m�n				
				ms.Read(dn_z.bymd, 0, dn_z.bymd.Length);        // �[�����͓��t�E����			
				ms.Read(dn_z.ymdhms, 0, dn_z.ymdhms.Length);    // �z�X�g���t�E����				
				ms.Read(dn_z.syamei, 0, dn_z.syamei.Length);    // ��Ж�						

				for (int i = 0; i < dn_z.kyo.Length; i++)
				{
					ms.Read(dn_z.kyo[i], 0, dn_z.kyo[i].Length);// ���_��
				}

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_z.ln_z[i].khb, 0, dn_z.ln_z[i].khb.Length);      // ���i�ԍ�						
					ms.Read(dn_z.ln_z[i].knm, 0, dn_z.ln_z[i].knm.Length);      // �i��							
					ms.Read(dn_z.ln_z[i].lp, 0, dn_z.ln_z[i].lp.Length);        // �k�^�o						
					ms.Read(dn_z.ln_z[i].zsu00, 0, dn_z.ln_z[i].zsu00.Length);  // �{�ɍ݌ɐ�					
					ms.Read(dn_z.ln_z[i].gokan1, 0, dn_z.ln_z[i].gokan1.Length);// ��֋敪						
					ms.Read(dn_z.ln_z[i].newhb, 0, dn_z.ln_z[i].newhb.Length);  // �V���i�ԍ�					

					for (int j = 0; j < 31; j++)
					{
						ms.Read(dn_z.ln_z[i].zsu[j], 0, dn_z.ln_z[i].zsu[j].Length); // ���_�݌ɐ�   
					}
                    ms.Read(dn_z.ln_z[i].lemsg, 0, dn_z.ln_z[i].lemsg.Length);  // �G���[���b�Z�[�W				
                }

				ms.Close();
			}
			# endregion

			# region �w�b�h�G���[���b�Z�[�W�̎擾
			/// <summary>
			/// �w�b�h�G���[���b�Z�[�W�̎擾
			/// </summary>
			/// <param name="cd"></param>
			/// <returns></returns>
			private string GetHeadErrorMassage(byte cd)
			{
				string str = "";

				switch (cd)
				{
					case 0x99:						//-- "����װ" --
					default:
						str = MSG_ELS;
						break;
				}
				return (str);
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}
