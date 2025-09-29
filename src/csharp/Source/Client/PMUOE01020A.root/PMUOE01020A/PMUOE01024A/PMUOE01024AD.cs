//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j���s��
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
	/// �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0401Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i���}�c�_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0401(out string message)
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
                    TelegramJnlStock0401 telegramJnlStock0401 = new TelegramJnlStock0401();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0401.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���݌Ɂ��i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i���}�c�_�j
		/// </summary>
		public class TelegramJnlStock0401 : UoeRecEdit0401Acs
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
			//typedef struct	{
			//	char	khb[24] ;					/* ���i�ԍ�						*/
			//	char	tkhb[24] ;					/* �⍇�����i�ԍ�				*/
			//	char	knm[20] ;					/* ���i��						*/
			//	char	akk[7] ;					/* �d��							*/
			//	char	lp[7] ;						/* ��]�����艿�i				*/
			//	char	gokan1[2] ;					/* �݊����R�[�h					*/
			//	char	zsu02[5] ;					/* ���_�݌ɐ�					*/
			//	char	zsu01[5] ;					/* �x�X�݌ɐ�					*/
			//	char	zsu00[5] ;					/* �{�Ѝ݌ɐ�					*/
			//	char	lemsg[15] ;					/* �R�����g						*/
			//} ZDATA ;
			//
			//typedef struct	{
			//	HEAD	head ;
			//	ZDATA	zdata[15] ;					/* ���C�����ڂP�`�P�T			*/
			//} ZAIKO ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 15;		//���׃o�b�t�@�T�C�Y
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
				public byte[] khb = new byte[24];		// ���i�ԍ�						
				public byte[] tkhb = new byte[24];		// �⍇�����i�ԍ�				
				public byte[] knm = new byte[20];		// ���i��						
				public byte[] akk = new byte[7];			// �d��							
				public byte[] lp = new byte[7];			// ��]�����艿�i				
				public byte[] gokan1 = new byte[2];		// �݊����R�[�h					
				public byte[] zsu02 = new byte[5];		// ���_�݌ɐ�					
				public byte[] zsu01 = new byte[5];		// �x�X�݌ɐ�					
				public byte[] zsu00 = new byte[5];		// �{�Ѝ݌ɐ�					
				public byte[] lemsg = new byte[15];		// �R�����g						

				public LN_Z()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// ���i�ԍ�						
					UoeCommonFnc.MemSet(ref tkhb, cd, tkhb.Length);			// �⍇�����i�ԍ�				
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// ���i��						
					UoeCommonFnc.MemSet(ref akk, cd, akk.Length);			// �d��							
					UoeCommonFnc.MemSet(ref lp, cd, lp.Length);				// ��]�����艿�i				
					UoeCommonFnc.MemSet(ref gokan1, cd, gokan1.Length);		// �݊����R�[�h					
					UoeCommonFnc.MemSet(ref zsu02, cd, zsu02.Length);		// ���_�݌ɐ�					
					UoeCommonFnc.MemSet(ref zsu01, cd, zsu01.Length);		// �x�X�݌ɐ�					
					UoeCommonFnc.MemSet(ref zsu00, cd, zsu00.Length);		// �{�Ѝ݌ɐ�					
					UoeCommonFnc.MemSet(ref lemsg, cd, lemsg.Length);		// �R�����g						
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[] jkbn = new byte[1];		// ���敪						
				public byte[] seq_no = new byte[2];		// �e�L�X�g�V�[�P���X�ԍ�		
				public byte[] text_len = new byte[2];	// �e�L�X�g��					
				public byte[] dkbn = new byte[1];		// �d���敪						
				public byte[] kekka = new byte[1];		// ��������						
				public byte[] tokbn = new byte[1];		// �⍇���^�����敪				
				public byte[] g_id = new byte[12];		// �Ɩ��h�c						
				public byte[] g_pass = new byte[6];		// �Ɩ��p�X���[�h				
				public byte[] prog_ver = new byte[3];	// �[���v���O�����o�[�W�����ԍ�	
				public byte[] kkbn = new byte[1];		// �p���敪						
				public byte[] h_id = new byte[3];		// ����h�c						
				public byte[] ext = new byte[15];		// �g���G���A					
				public byte[] gsk = new byte[1];		// �Ɩ���������					
				public byte[] gsf = new byte[1];		// �Ɩ��p���t���O				
				public byte[] seq = new byte[3];		// �V�[�P���X�m�n				
				public byte[] bymd = new byte[4];		// �[�����͓��t�E����			
				public byte[] ymdhms = new byte[8];		// �z�X�g���t�E����				

				public LN_Z[] ln_z = new LN_Z[ctBufLen];// ײ�

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);			// ���敪						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);		// �e�L�X�g�V�[�P���X�ԍ�		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);	// �e�L�X�g��					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);			// �d���敪						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);		// ��������						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);		// �⍇���^�����敪				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);			// �Ɩ��h�c						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);		// �Ɩ��p�X���[�h				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);	// �[���v���O�����o�[�W�����ԍ�	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);			// �p���敪						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);			// ����h�c						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);			// �g���G���A					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);			// �Ɩ���������					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);			// �Ɩ��p���t���O				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// �V�[�P���X�m�n				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);			// �[�����͓��t�E����			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);		// �z�X�g���t�E����				

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
			public TelegramJnlStock0401()
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

			# region ���ו�
			/// <summary>
			/// ���ו�
			/// </summary>
			private LN_Z[] Ln_z
			{
				get
				{
					return dn_z.ln_z;
				}
				set
				{
					this.dn_z.ln_z = value;
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
					if ( (dn_z.kekka[0] != 0x00)
					||	 (dn_z.gsk[0] != 0x00) )
					{
						string errMessage = GetHeadErrorMassage(dn_z.kekka[0]);
						
						//�w�b�h�G���[���b�Z�[�W
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}

					// ��֗L���`�F�b�N
					// UOE��փR�[�h
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].gokan1);

					// ��֖���
					if ((dn_z.ln_z[i].gokan1[0] == 0x00) ||
						 ( dn_z.ln_z[i].gokan1[0] == 0x20 ) ||
						 ( dn_z.ln_z[i].gokan1[0] == 0x30 ) )
					{
						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);
					}
					// ��֗L��
					else
					{
						//��֕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//�񓚕i��( �⍇���i�ԍ�)
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].tkhb);
					}
					
					//�i��
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].knm);

					// ���i�`���i(�d�ؒP��)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].akk);
                    dataRow[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].akk);
                    dataRow[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].akk);

					// �艿(�k�^�o)(��]�����艿�i)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].lp);

					// UOE���_�݌ɐ��P(���_�݌ɐ�)
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].zsu02);
					
					// UOE���_�݌ɐ��Q(�x�X�݌ɐ�)
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].zsu01);

					// UOE���_�݌ɐ��R(�{�ɍ݌ɐ�)
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].zsu00);

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

				ms.Read(dn_z.jkbn, 0, dn_z.jkbn.Length); // ���敪						
				ms.Read(dn_z.seq_no, 0, dn_z.seq_no.Length); // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(dn_z.text_len, 0, dn_z.text_len.Length); // �e�L�X�g��					
				ms.Read(dn_z.dkbn, 0, dn_z.dkbn.Length); // �d���敪						
				ms.Read(dn_z.kekka, 0, dn_z.kekka.Length); // ��������						
				ms.Read(dn_z.tokbn, 0, dn_z.tokbn.Length); // �⍇���^�����敪				
				ms.Read(dn_z.g_id, 0, dn_z.g_id.Length); // �Ɩ��h�c						
				ms.Read(dn_z.g_pass, 0, dn_z.g_pass.Length); // �Ɩ��p�X���[�h				
				ms.Read(dn_z.prog_ver, 0, dn_z.prog_ver.Length); // �[���v���O�����o�[�W�����ԍ�	
				ms.Read(dn_z.kkbn, 0, dn_z.kkbn.Length); // �p���敪						
				ms.Read(dn_z.h_id, 0, dn_z.h_id.Length); // ����h�c						
				ms.Read(dn_z.ext, 0, dn_z.ext.Length); // �g���G���A					
				ms.Read(dn_z.gsk, 0, dn_z.gsk.Length); // �Ɩ���������					
				ms.Read(dn_z.gsf, 0, dn_z.gsf.Length); // �Ɩ��p���t���O				
				ms.Read(dn_z.seq, 0, dn_z.seq.Length); // �V�[�P���X�m�n				
				ms.Read(dn_z.bymd, 0, dn_z.bymd.Length); // �[�����͓��t�E����			
				ms.Read(dn_z.ymdhms, 0, dn_z.ymdhms.Length); // �z�X�g���t�E����				


				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(Ln_z[i].khb, 0, Ln_z[i].khb.Length); 			// ���i�ԍ�						
					ms.Read(Ln_z[i].tkhb, 0, Ln_z[i].tkhb.Length); 			// �⍇�����i�ԍ�				
					ms.Read(Ln_z[i].knm, 0, Ln_z[i].knm.Length); // ���i��						
					ms.Read(Ln_z[i].akk, 0, Ln_z[i].akk.Length); 		// �d��							
					ms.Read(Ln_z[i].lp, 0, Ln_z[i].lp.Length); 			// ��]�����艿�i				
					ms.Read(Ln_z[i].gokan1, 0, Ln_z[i].gokan1.Length); 	// �݊����R�[�h					
					ms.Read(Ln_z[i].zsu02, 0, Ln_z[i].zsu02.Length); // ���_�݌ɐ�					
					ms.Read(Ln_z[i].zsu01, 0, Ln_z[i].zsu01.Length); // �x�X�݌ɐ�					
					ms.Read(Ln_z[i].zsu00, 0, Ln_z[i].zsu00.Length); // �{�Ѝ݌ɐ�					
					ms.Read(Ln_z[i].lemsg, 0, Ln_z[i].lemsg.Length); // �R�����g						
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
