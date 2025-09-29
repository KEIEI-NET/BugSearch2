//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j���s��
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
	/// �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0402Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�V�}�c�_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0402(out string message)
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
                    TelegramJnlStock0402 telegramJnlStock0402 = new TelegramJnlStock0402();

                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0402.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���݌Ɂ��i�V�}�c�_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i�V�}�c�_�j
		/// </summary>
		public class TelegramJnlStock0402 : UoeRecEdit0402Acs
		{
			# region �o�l�V�\�[�X
			///********************** �񓚎�M�d�� ���ʕ� �\���� **********************/
			//typedef struct	{
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
			//} HEAD ;
			//
			///************************ �݌ɉ񓚎�M�d���\���� ************************/
			//typedef struct	{						/* ���_���						*/
			//	char	kcd[2] ;					/* ���_�R�[�h					*/
			//	char	zsu[5] ;					/* �݌ɐ�						*/
			//} ZAI3 ;
			//
			//typedef struct	{
			//	char	khb[24] ;					/* ���i�ԍ�						*/
			//	char	knm[20] ;					/* ���i��						*/
			//	char	tkhb[24] ;					/* �⍇�����i�ԍ�				*/
			//	char	gokan1[2] ;					/* �݊����R�[�h					*/
			//	char	akk[7] ;					/* �d��							*/
			//	char	lp[7] ;						/* ��]�����艿�i				*/
			//	ZAI3	zai3[8] ;					/* ���_���	(1)�`(8)			*/
			//	char	lemsg[15] ;					/* �R�����g						*/
			//} ZDATA ;
			//
			//typedef struct	{						/* �݌ɉ񓚓d��					*/
			//	HEAD	head ;
			//	ZDATA	zdata[5] ;					/* ���C�����ڂP�`�T				*/
			//} ZAIKO ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private ZAIKO zaiko = new ZAIKO(); 
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// ���_���
			/// </summary>
			private class ZAIZ
			{
				public byte[] kcd = new byte[2];					// ���_�R�[�h					
				public byte[] zsu = new byte[5];					// �݌ɐ�						

				public ZAIZ()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref kcd, cd, kcd.Length);	// ���_�R�[�h					
					UoeCommonFnc.MemSet(ref zsu, cd, zsu.Length);	// �݌ɐ�						
				}
			}

			/// <summary>
			/// �݌ɖ���
			/// </summary>
			private class ZDATA
			{
				public byte[] khb = new byte[24];					// ���i�ԍ�						
				public byte[] knm = new byte[20];					// ���i��						
				public byte[] tkhb = new byte[24];					// �⍇�����i�ԍ�				
				public byte[] gokan1 = new byte[2];					// �݊����R�[�h					
				public byte[] akk = new byte[7];					// �d��							
				public byte[] lp = new byte[7];						// ��]�����艿�i				
				public ZAIZ[] zaiz = new ZAIZ[8];					// ���_���	(1)�`(8)			
				public byte[] lemsg = new byte[15];					// �R�����g						

				public ZDATA()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// ���i�ԍ�						
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// ���i��						
					UoeCommonFnc.MemSet(ref tkhb, cd, tkhb.Length);			// �⍇�����i�ԍ�				
					UoeCommonFnc.MemSet(ref gokan1, cd, gokan1.Length);		// �݊����R�[�h					
					UoeCommonFnc.MemSet(ref akk, cd, akk.Length);			// �d��							
					UoeCommonFnc.MemSet(ref lp, cd, lp.Length);				// ��]�����艿�i				

					for(int i=0;i<zaiz.Length; i++)
					{
                        if (zaiz[i] == null)
                        {
                            zaiz[i] = new ZAIZ();
                        }
                        else
                        {
                            zaiz[i].Clear(0x00);
                        }
					}
					
					UoeCommonFnc.MemSet(ref lemsg, cd, lemsg.Length);		// �R�����g						
				}
			}

			/// <summary>
			/// �݌Ƀw�b�_�[
			/// </summary>
			private class ZAIKO
			{
				public byte[] jkbn = new byte[1];					// ���敪						
				public byte[] seq_no = new byte[2];					// �e�L�X�g�V�[�P���X�ԍ�		
				public byte[] text_len = new byte[2];				// �e�L�X�g��					
				public byte[] dkbn = new byte[1];					// �d���敪						
				public byte[] kekka = new byte[1];					// ��������						
				public byte[] tokbn = new byte[1];					// �⍇���^�����敪				
				public byte[] g_id = new byte[12];					// �Ɩ��h�c						
				public byte[] g_pass = new byte[6];					// �Ɩ��p�X���[�h				
				public byte[] prog_ver = new byte[3];				// �[���v���O�����o�[�W�����ԍ�	
				public byte[] kkbn = new byte[1];					// �p���敪						
				public byte[] h_id = new byte[3];					// ����h�c						
				public byte[] ext = new byte[15];					// �g���G���A					
				public byte[] gsk = new byte[1];					// �Ɩ���������					
				public byte[] gsf = new byte[1];					// �Ɩ��p���t���O				
				public byte[] seq = new byte[3];					// �V�[�P���X�m�n				
				public byte[] bymd = new byte[4];					// �[�����͓��t�E����			
				public byte[] ymdhms = new byte[8];					// �z�X�g���t�E����				

				public ZDATA[] zdata = new ZDATA[5];				// ���C�����ڂP�`�T				

				public ZAIKO()
				{
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
					
					for(int i=0;i<zdata.Length; i++)
					{
                        if (zdata[i] == null)
                        {
                            zdata[i] = new ZDATA();
                        }
                        else
                        {
                            zdata[i].Clear(0x00);
                        }
					}
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock0402()
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
				zaiko.Clear(0x00);
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
					int int32Yymmdd = UoeCommonFnc.atobs(zaiko.ymdhms, 0, 4) * 100;

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
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(zaiko.ymdhms, 4, 4) * 100;

					//�񓚓d���G���[����
					if ( (zaiko.kekka[0] != 0x00)
					||	 (zaiko.gsk[0] != 0x00) )
					{
						string errMessage = GetHeadErrorMassage(zaiko.kekka[0]);
						
						//�w�b�h�G���[���b�Z�[�W
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}

					// ��֗L���`�F�b�N
					// UOE��փR�[�h
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].gokan1);

					// ��֖���
					if ((zaiko.zdata[i].gokan1[0] == 0x00) ||
						 ( zaiko.zdata[i].gokan1[0] == 0x20 ) ||
						 ( zaiko.zdata[i].gokan1[0] == 0x30 ) )
					{
						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].khb);
					}
					// ��֗L��
					else
					{
						//��֕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].khb);

						//�񓚕i��( �⍇���i�ԍ�)
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].tkhb);
					}
					
					//�i��
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].knm);

					// ���i�`���i(�d�ؒP��)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(zaiko.zdata[i].akk);
                    dataRow[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(zaiko.zdata[i].akk);

					// �艿(�k�^�o)(��]�����艿�i)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(zaiko.zdata[i].lp);

					//�݌ɏ��Z�b�g
					for (int ix =0; ix < 8; ix++)
					{
						//UOE���_�R�[�h
						string kcd = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].zaiz[ix].kcd);

						//UOE���_�݌ɐ�
						int zsu = UoeCommonFnc.ToInt32FromByteStrAry(zaiko.zdata[i].zaiz[ix].zsu);

						switch(ix)
						{
							case 0:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode1] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = zsu;
								break;
							case 1:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode2] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = zsu;
								break;
							case 2:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode3] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = zsu;
								break;
							case 3:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode4] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = zsu;
								break;
							case 4:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode5] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = zsu;
								break;
							case 5:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode6] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = zsu;
								break;
							case 6:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode7] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = zsu;
								break;
							case 7:
								//UOE���_�R�[�h
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode8] = kcd;
							
								//UOE���_�݌ɐ�
								dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = zsu;
								break;

						}
					}

					// �G���[���b�Z�[�W
					dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(zaiko.zdata[i].lemsg);
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

				ms.Read(zaiko.jkbn, 0, zaiko.jkbn.Length); // ���敪						
				ms.Read(zaiko.seq_no, 0, zaiko.seq_no.Length); // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(zaiko.text_len, 0, zaiko.text_len.Length); // �e�L�X�g��					
				ms.Read(zaiko.dkbn, 0, zaiko.dkbn.Length); // �d���敪						
				ms.Read(zaiko.kekka, 0, zaiko.kekka.Length); // ��������						
				ms.Read(zaiko.tokbn, 0, zaiko.tokbn.Length); // �⍇���^�����敪				
				ms.Read(zaiko.g_id, 0, zaiko.g_id.Length); // �Ɩ��h�c						
				ms.Read(zaiko.g_pass, 0, zaiko.g_pass.Length); // �Ɩ��p�X���[�h				
				ms.Read(zaiko.prog_ver, 0, zaiko.prog_ver.Length); // �[���v���O�����o�[�W�����ԍ�	
				ms.Read(zaiko.kkbn, 0, zaiko.kkbn.Length); // �p���敪						
				ms.Read(zaiko.h_id, 0, zaiko.h_id.Length); // ����h�c						
				ms.Read(zaiko.ext, 0, zaiko.ext.Length); // �g���G���A					
				ms.Read(zaiko.gsk, 0, zaiko.gsk.Length); // �Ɩ���������					
				ms.Read(zaiko.gsf, 0, zaiko.gsf.Length); // �Ɩ��p���t���O				
				ms.Read(zaiko.seq, 0, zaiko.seq.Length); // �V�[�P���X�m�n				
				ms.Read(zaiko.bymd, 0, zaiko.bymd.Length); // �[�����͓��t�E����			
				ms.Read(zaiko.ymdhms, 0, zaiko.ymdhms.Length); // �z�X�g���t�E����				
				

				for(int i=0; i < zaiko.zdata.Length; i++)
				{
					ZDATA Zdata = zaiko.zdata[i];
				
					ms.Read(Zdata.khb, 0, Zdata.khb.Length); // ���i�ԍ�						
					ms.Read(Zdata.knm, 0, Zdata.knm.Length); // ���i��						
					ms.Read(Zdata.tkhb, 0, Zdata.tkhb.Length); // �⍇�����i�ԍ�				
					ms.Read(Zdata.gokan1, 0, Zdata.gokan1.Length); // �݊����R�[�h					
					ms.Read(Zdata.akk, 0, Zdata.akk.Length); // �d��							
					ms.Read(Zdata.lp, 0, Zdata.lp.Length); // ��]�����艿�i				

					// ���_���	(1)�`(8)
					for(int j=0; j < Zdata.zaiz.Length; j++)
					{
						ZAIZ Zaiz = zaiko.zdata[i].zaiz[j];

						ms.Read(Zaiz.kcd, 0, Zaiz.kcd.Length); // ���_�R�[�h					
						ms.Read(Zaiz.zsu, 0, Zaiz.zsu.Length); // �݌ɐ�						
					}

					ms.Read(Zdata.lemsg, 0,  Zdata.lemsg.Length);// �R�����g
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
					case 0x88:						//-- "�޶ݶ޲�װ" --
						str = MSG_RUS;
						break;
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
