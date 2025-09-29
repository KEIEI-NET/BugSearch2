//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�����ρ��i���}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�����ρ��i���}�c�_�j���s��
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
	/// �t�n�d��M�ҏW�����ρ��i���}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�����ρ��i���}�c�_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW�����ρ��i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ��i���}�c�_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlEstmt0401(out string message)
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
                    TelegramJnlEstmt0401 telegramJnlEstmt0401 = new TelegramJnlEstmt0401();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlEstmt0401.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬�����ρ��i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�d���쐬�����ρ��i���}�c�_�j
		/// </summary>
		public class TelegramJnlEstmt0401 : UoeRecEdit0401Acs
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
			///************************ ���ω񓚎�M�d���\���� ************************/
			//typedef struct	{
			//	char	khb[24] ;					/* ���i�ԍ�						*/
			//	char	msu[5] ;					/* ����							*/
			//	char	knm[20] ;					/* �i���^�V����					*/
			//	char	mtan[7] ;					/* ���ϒP��						*/
			//	char	hzumu[1] ;					/* �{�ɍ݌ɕ\��					*/
			//	char	szumu[1] ;					/* �x�X�݌ɕ\��					*/
			//	char	mkzsu[2] ;					/* ���_�݌ɕ\��					*/
			//	char	tkbn[1] ;					/* �艿���敪					*/
			//	char	gokan[2] ;					/* �݊����R�[�h					*/
			//	char	sktan[7] ;					/* �d�ؒP��						*/
			//	char	ermsg[8];					/* �R�����g						*/
			//} MDATA ;
			//
			//typedef struct	{
			//	HEAD	head ;
			//	char	retok[1] ;					/* ���[�g�敪					*/
			//	char	reto[4] ;					/* ���[�g�R�[�h					*/
			//	char	senc[1] ;					/* �I���R�[�h					*/
			//	char	remk[10] ;					/* ���}�[�N						*/
			//	char	mimny[9] ;					/* ���ϋ��z���v					*/
			//	char	simny[9] ;					/* �d�؋��z���v					*/
			//	MDATA	mdata[10] ;					/* ���C�����ڂP�`�P�O			*/
			//} MITU ;
			//
			///********************** ���σw�b�h�G���[�d���\���� **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	retok[1] ;					/* ���[�g�敪					*/
			//	char	reto[4] ;					/* ���[�g�R�[�h					*/
			//	char	senc[1] ;					/* �I���R�[�h					*/
			//	char	remk[10] ;					/* ���}�[�N						*/
			//	char	ermsg[20] ;					/* �G���[���b�Z�[�W				*/
			//	char	khb[24] ;					/* ����							*/
			//	char	msu[5] ;					/* ����							*/
			//} MERR ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_M dn_m = new DN_M(); 
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �G���[�d���̈�
			/// </summary>
			private class ER_M
			{
				public byte[] ermsg = new byte[20];		// �G���[���b�Z�[�W				
				public byte[] khb = new byte[24];		// ����							
				public byte[] hasu = new byte[5];		// ������						
				public byte[] bo = new byte[1];			// �a�n�敪						

				public ER_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// �G���[���b�Z�[�W				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// ����							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);		// ������						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);			// �a�n�敪						
				}
			}

			/// <summary>
			/// ���ϓd���̈恃���C���Q��
			/// </summary>
			private class LN2_M
			{
				public byte[] khb = new byte[24];		// ���i�ԍ�						
				public byte[] msu = new byte[5];			// ����							
				public byte[] knm = new byte[20];		// �i���^�V����					
				public byte[] mtan = new byte[7];		// ���ϒP��						
				public byte[] hzumu = new byte[1];		// �{�ɍ݌ɕ\��					
				public byte[] szumu = new byte[1];		// �x�X�݌ɕ\��					
				public byte[] mkzsu = new byte[2];		// ���_�݌ɕ\��					
				public byte[] tkbn = new byte[1];		// �艿���敪					
				public byte[] gokan = new byte[2];		// �݊����R�[�h					
				public byte[] sktan = new byte[7];		// �d�ؒP��						
				public byte[] ermsg = new byte[8];		// �R�����g						

				public LN2_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// ���i�ԍ�						
					UoeCommonFnc.MemSet(ref msu, cd, msu.Length);		// ����							
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);		// �i���^�V����					
					UoeCommonFnc.MemSet(ref mtan, cd, mtan.Length);		// ���ϒP��						
					UoeCommonFnc.MemSet(ref hzumu, cd, hzumu.Length);	// �{�ɍ݌ɕ\��					
					UoeCommonFnc.MemSet(ref szumu, cd, szumu.Length);	// �x�X�݌ɕ\��					
					UoeCommonFnc.MemSet(ref mkzsu, cd, mkzsu.Length);	// ���_�݌ɕ\��					
					UoeCommonFnc.MemSet(ref tkbn, cd, tkbn.Length);		// �艿���敪					
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);	// �݊����R�[�h					
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);	// �d�ؒP��						
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// �R�����g						
				}
			}


			/// <summary>
			/// ���ϓd���̈恃���C����
			/// </summary>
			private class LN_M
			{
				public byte[] mimny = new byte[9];		// ���ϋ��z���v					
				public byte[] simny = new byte[9];		// �d�؋��z���v					
				public LN2_M[] ln2_m = new LN2_M[10];		// ���C�����ڂP�`�P�O			

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref mimny, cd, mimny.Length);	// ���ϋ��z���v					
					UoeCommonFnc.MemSet(ref simny, cd, simny.Length);	// �d�؋��z���v					

					for (int i = 0; i < ln2_m.Length; i++)
					{
                        if (ln2_m[i] == null)
                        {
                            ln2_m[i] = new LN2_M();
                        }
                        else
                        {
                            ln2_m[i].Clear(0x00);
                        }
                    }
				}
			}

			/// <summary>
			/// ���ϓd���̈恃�{�́�
			/// </summary>
			private class DN_M
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

				public byte[] retok = new byte[1];		// ���[�g�敪					
				public byte[] reto = new byte[4];		// ���[�g�R�[�h					
				public byte[] senc = new byte[1];		// �I���R�[�h					
				public byte[] remk = new byte[10];		// ���}�[�N						

				public LN_M ln_m = new LN_M();			// ���ו�
				public ER_M er_m = new ER_M();			// �G���[��

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_M()
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

					UoeCommonFnc.MemSet(ref retok, cd, retok.Length);		// ���[�g�敪					
					UoeCommonFnc.MemSet(ref reto, cd, reto.Length);			// ���[�g�R�[�h					
					UoeCommonFnc.MemSet(ref senc, cd, senc.Length);			// �I���R�[�h					
					UoeCommonFnc.MemSet(ref remk, cd, remk.Length);			// ���}�[�N						

					//���ו�
					ln_m.Clear(0x00);

					//�G���[��
					er_m.Clear(0x00);
				}
			}
			# endregion



			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlEstmt0401()
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

			# region �G���[��
			/// <summary>
			/// �G���[��
			/// </summary>
			private ER_M Er_m
			{
				get
				{
					return dn_m.er_m;
				}
				set
				{
					this.dn_m.er_m = value;
				}
			}
			# endregion

			# region ���ו�
			/// <summary>
			/// ���ו�
			/// </summary>
			private LN_M Ln_m
			{
				get
				{
					return dn_m.ln_m;
				}
				set
				{
					this.dn_m.ln_m = value;
				}
			}
			# endregion

			# region ���ו��Q
			/// <summary>
			/// ���ו��Q
			/// </summary>
			private LN2_M[] Ln2_m
			{
				get
				{
					return dn_m.ln_m.ln2_m;
				}
				set
				{
					this.dn_m.ln_m.ln2_m = value;
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
				dn_m.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlEstmtTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//�f�[�^���M�敪
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
	
					//��M���t(YYYYMMDD)
					int int32Yymmdd = UoeCommonFnc.atobs(dn_m.ymdhms, 0, 4) * 100;

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
						dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//��M����(HHMM)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_m.ymdhms, 4, 4) * 100;

										/* �񓚓d���G���[�`�F�b�N	*/
					if ( (dn_m.kekka[0] != 0x00)
					||	 (dn_m.gsk[0] != 0x00) )
					{
						string errMessage = "";

						if (dn_m.kekka[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(dn_m.er_m.ermsg);

						}
						else
						{
							errMessage = GetHeadErrorMassage(dn_m.kekka[0]);
						}

						//�w�b�h�G���[���b�Z�[�W
						dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					//���σ��[�g
					dataRow[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.reto);

					// �I���R�[�h
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.senc);

					// �݊����R�[�h
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].gokan);

					
					//UOE���i�R�[�h(���i���敪)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].tkbn);
					
					// ����
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].msu);

					//��֕i��
					if ((dn_m.ln_m.ln2_m[i].gokan[0] != 0x00)
					&& (dn_m.ln_m.ln2_m[i].gokan[0] != 0x20)
					&& (dn_m.ln_m.ln2_m[i].gokan[0] != 0x30))
					{
						dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].knm);
					}

					//�񓚕i��
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].khb); 

					//�񓚕i��
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].knm);

                    //�񓚌����P��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].sktan);

					// �E�v�i�艿�j
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].mtan);

					//��փ}�[�N
					//uoejlb.PM1599[0] = 'N' ;
					//if ( recv_str.den.mitu.mdata[ii].hzumu[0] == 'Y' )
					//	uoejlb.PM1599[0] = 'Y' ;
					//if ( recv_str.den.mitu.mdata[ii].szumu[0] == 'Y' )
					//	uoejlb.PM1599[0] = 'Y' ;

					// �{�Ѝ݌ɕ\��
					dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].hzumu);

					// �x�X�݌ɕ\��
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].szumu);

					// ���_�݌ɕ\��
					dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].mkzsu);

					// �R�����g
					dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].ermsg);
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

				ms.Read(dn_m.jkbn, 0, dn_m.jkbn.Length); // ���敪						
				ms.Read(dn_m.seq_no, 0, dn_m.seq_no.Length); // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(dn_m.text_len, 0, dn_m.text_len.Length); // �e�L�X�g��					
				ms.Read(dn_m.dkbn, 0, dn_m.dkbn.Length); // �d���敪						
				ms.Read(dn_m.kekka, 0, dn_m.kekka.Length); // ��������						
				ms.Read(dn_m.tokbn, 0, dn_m.tokbn.Length); // �⍇���^�����敪				
				ms.Read(dn_m.g_id, 0, dn_m.g_id.Length); // �Ɩ��h�c						
				ms.Read(dn_m.g_pass, 0, dn_m.g_pass.Length); // �Ɩ��p�X���[�h				
				ms.Read(dn_m.prog_ver, 0, dn_m.prog_ver.Length); // �[���v���O�����o�[�W�����ԍ�	
				ms.Read(dn_m.kkbn, 0, dn_m.kkbn.Length); // �p���敪						
				ms.Read(dn_m.h_id, 0, dn_m.h_id.Length); // ����h�c						
				ms.Read(dn_m.ext, 0, dn_m.ext.Length); // �g���G���A					
				ms.Read(dn_m.gsk, 0, dn_m.gsk.Length); // �Ɩ���������					
				ms.Read(dn_m.gsf, 0, dn_m.gsf.Length); // �Ɩ��p���t���O				
				ms.Read(dn_m.seq, 0, dn_m.seq.Length); // �V�[�P���X�m�n				
				ms.Read(dn_m.bymd, 0, dn_m.bymd.Length); // �[�����͓��t�E����			
				ms.Read(dn_m.ymdhms, 0, dn_m.ymdhms.Length); // �z�X�g���t�E����				

				ms.Read(dn_m.retok, 0, dn_m.retok.Length); // ���[�g�敪					
				ms.Read(dn_m.reto, 0, dn_m.reto.Length); // ���[�g�R�[�h					
				ms.Read(dn_m.senc, 0, dn_m.senc.Length); // �I���R�[�h					
				ms.Read(dn_m.remk, 0, dn_m.remk.Length); // ���}�[�N						

				//�G���[��
				if ((dn_m.kekka[0] != 0x00)
				|| (dn_m.gsk[0] != 0x00))
				{
					ms.Read(Er_m.ermsg, 0, Er_m.ermsg.Length); // �G���[���b�Z�[�W				
					ms.Read(Er_m.khb, 0, Er_m.khb.Length); // ����							
					ms.Read(Er_m.hasu, 0, Er_m.hasu.Length); // ������						
					ms.Read(Er_m.bo, 0, Er_m.bo.Length); // �a�n�敪						
				}
				//���ו�
				else
				{
					ms.Read(Ln_m.mimny, 0, Ln_m.mimny.Length); // ���ϋ��z���v					
					ms.Read(Ln_m.simny, 0, Ln_m.simny.Length); // �d�؋��z���v					

					for (int i = 0; i < ctBufLen; i++)
					{
						ms.Read(Ln2_m[i].khb, 0, Ln2_m[i].khb.Length); 		// ���i�ԍ�						
						ms.Read(Ln2_m[i].msu, 0, Ln2_m[i].msu.Length); 		// ����							
						ms.Read(Ln2_m[i].knm, 0, Ln2_m[i].knm.Length); 	// �i���^�V����					
						ms.Read(Ln2_m[i].mtan, 0, Ln2_m[i].mtan.Length); 	// ���ϒP��						
						ms.Read(Ln2_m[i].hzumu, 0, Ln2_m[i].hzumu.Length); // �{�ɍ݌ɕ\��					
						ms.Read(Ln2_m[i].szumu, 0, Ln2_m[i].szumu.Length); // �x�X�݌ɕ\��					
						ms.Read(Ln2_m[i].mkzsu, 0, Ln2_m[i].mkzsu.Length); // ���_�݌ɕ\��					
						ms.Read(Ln2_m[i].tkbn, 0, Ln2_m[i].tkbn.Length); 		// �艿���敪					
						ms.Read(Ln2_m[i].gokan, 0, Ln2_m[i].gokan.Length); // �݊����R�[�h					
						ms.Read(Ln2_m[i].sktan, 0, Ln2_m[i].sktan.Length); // �d�ؒP��						
						ms.Read(Ln2_m[i].ermsg, 0, Ln2_m[i].ermsg.Length); // �R�����g						
					}
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
