//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i�V�}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i�V�}�c�_�j���s��
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
	/// �t�n�d��M�ҏW���������i�V�}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���������i�V�}�c�_�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i�V�}�c�_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlOrder0402(out string message)
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
                    _uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(_uoeRecHed.UOESupplierCd);

                    TelegramJnlOrder0402 telegramJnlOrder0402 = new TelegramJnlOrder0402();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0402.Telegram(_uOESupplier, dtl);
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

		# region �t�n�d��M�d���쐬���������i�V�}�c�_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���������i�V�}�c�_�j
		/// </summary>
		public class TelegramJnlOrder0402 : UoeRecEdit0402Acs
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
			//typedef struct	{
			//	char	khb[24] ;					/* �i��							*/
			//	char	hasu[5] ;					/* ������						*/
			//	char	syk_max[5] ;				/* �o�א����v					*/
			//	char	mksu[5] ;					/* �a�n��						*/
			//	char	bo[1] ;						/* �a�n�敪						*/
			//	char	knm[20] ;					/* ���i��						*/
			//	char	bhb[24] ;					/* ���i�ԍ��i�����j				*/
			//	char	gokan[2] ;					/* �݊����R�[�h					*/
			//	char	sktan[7] ;					/* �d�؂�P��					*/
			//	char	teika[7] ;					/* ��]�������i					*/
			//	SYK		syk[3] ;					/* �o�׏��	�@�\����			*/
			//	ZAI1	zai1[7] ;					/* �݌ɏ��	�@�\����			*/
			//	char	ermsg[15] ;					/* �R�����g						*/
			//	char	l_ext[3] ;					/* ���C���g���G���A				*/
			//} HDATA ;
			//
			//typedef struct	{						/* �����񓚓d��					*/
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* �[�i�敪						*/
			//	char	rem1[20] ;					/* ���}�[�N						*/
			//	char	kyoten[2] ;					/* �w�苒�_						*/
			//	char	head_ext[10] ;				/* �w�b�h�g���G���A				*/
			//	HDATA	hdata[6] ;					/* ���C�����ڂP�`�U				*/
			//} HATYU ;
			//
			///********************** �����w�b�h�G���[�d���\���� **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* �[�i�敪						*/
			//	char	rem1[20] ;					/* ���}�[�N						*/
			//	char	kyoten[2] ;					/* �w�苒�_						*/
			//	char	head_ext[10] ;				/* �w�b�h�g���G���A				*/
			//	char	ermsg[20] ;					/* �G���[���b�Z�[�W				*/
			//	char	khb[24] ;					/* ����							*/
			//	char	hasu[5] ;					/* ������						*/
			//	char	bo[1] ;						/* �a�n�敪						*/
			//} HERR ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����G���[�d��
			/// </summary>
			private class HERR
			{
				public byte[]	ermsg = new byte[20] ;					// �G���[���b�Z�[�W				
				public byte[]	khb = new byte[24] ;					// ����							
				public byte[]	hasu = new byte[5] ;					// ������						
				public byte[]	bo = new byte[1] ;						// �a�n�敪		
				
				public HERR()
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
			/// �o�׏�� �P�`�R
			/// </summary>
			private class SYK
			{
				public byte[]	kcd = new byte[2];						// ���_�R�[�h					
				public byte[]	dno = new byte[7];						// �`�[�m���D					
				public byte[]	ssu = new byte[5];						// �o�א�						
				public byte[]	zsu = new byte[2];						// �݌ɐ�						
				
				public SYK()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref kcd, cd, kcd.Length);		// ���_�R�[�h					
					UoeCommonFnc.MemSet(ref dno, cd, dno.Length);		// �`�[�m���D					
					UoeCommonFnc.MemSet(ref ssu, cd, ssu.Length);		// �o�א�						
					UoeCommonFnc.MemSet(ref zsu, cd, zsu.Length);		// �݌ɐ�						
				}
			}

			/// <summary>
			/// �݌ɏ��
			/// </summary>
			private class ZAIH
			{
				public byte[]	kcd = new byte[2];						// ���_�R�[�h					
				public byte[]	zsu = new byte[2];						// �݌ɐ�						
				
				public ZAIH()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref kcd, cd, kcd.Length);		// ���_�R�[�h					
					UoeCommonFnc.MemSet(ref zsu, cd, zsu.Length);		// �݌ɐ�						
				}
			}

			/// <summary>
			/// ��������
			/// </summary>
			private class HDATA
			{
				public byte[]	khb = new byte[24] ;				// �i��							
				public byte[]	hasu = new byte[5] ;				// ������						
				public byte[]	syk_max = new byte[5] ;				// �o�א����v					
				public byte[]	mksu = new byte[5] ;				// �a�n��						
				public byte[]	bo = new byte[1] ;					// �a�n�敪						
				public byte[]	knm = new byte[20] ;				// ���i��						
				public byte[]	bhb = new byte[24] ;				// ���i�ԍ��i�����j				
				public byte[]	gokan = new byte[2] ;				// �݊����R�[�h					
				public byte[]	sktan = new byte[7] ;				// �d�؂�P��					
				public byte[]	teika = new byte[7] ;				// ��]�������i					
				public SYK[]	syk = new SYK[3] ;					// �o�׏��	�\����			
				public ZAIH[]	zaih = new ZAIH[7] ;				// �݌ɏ��	�\����			
				public byte[]	ermsg = new byte[15] ;				// �R�����g						
				public byte[]	l_ext = new byte[3] ;				// ���C���g���G���A				
				
				public HDATA()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// �i��							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// ������						
					UoeCommonFnc.MemSet(ref syk_max, cd, syk_max.Length);	// �o�א����v					
					UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// �a�n��						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// �a�n�敪						
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// ���i��						
					UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// ���i�ԍ��i�����j				
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);		// �݊����R�[�h					
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// �d�؂�P��					
					UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// ��]�������i					

					for(int i=0;i<syk.Length; i++)
					{
                        if (syk[i] == null)
                        {
                            syk[i] = new SYK();
                        }
                        else
                        {
                            syk[i].Clear(0x00);
                        }
                    }
					for(int i=0;i<zaih.Length; i++)
					{
                        if (zaih[i] == null)
                        {
                            zaih[i] = new ZAIH();
                        }
                        else
                        {
                            zaih[i].Clear(0x00);
                        }
					}

					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// �R�����g						
					UoeCommonFnc.MemSet(ref l_ext, cd, l_ext.Length);		// ���C���g���G���A				
				}
			}

			/// <summary>
			/// �����w�b�_�[
			/// </summary>
			private class HATYU
			{
				public byte[]	jkbn = new byte[1] ;			// ���敪						
				public byte[]	seq_no = new byte[2] ;			// �e�L�X�g�V�[�P���X�ԍ�		
				public byte[]	text_len = new byte[2] ;		// �e�L�X�g��					
				public byte[]	dkbn = new byte[1] ;			// �d���敪						
				public byte[]	kekka = new byte[1] ;			// ��������						
				public byte[]	tokbn = new byte[1] ;			// �⍇���^�����敪				
				public byte[]	g_id = new byte[12] ;			// �Ɩ��h�c						
				public byte[]	g_pass = new byte[6] ;			// �Ɩ��p�X���[�h				
				public byte[]	prog_ver = new byte[3] ;		// �[���v���O�����o�[�W�����ԍ�	
				public byte[]	kkbn = new byte[1] ;			// �p���敪						
				public byte[]	h_id = new byte[3] ;			// ����h�c						
				public byte[]	ext = new byte[15] ;			// �g���G���A					
				public byte[]	gsk = new byte[1] ;				// �Ɩ���������					
				public byte[]	gsf = new byte[1] ;				// �Ɩ��p���t���O				
				public byte[]	seq = new byte[3] ;				// �V�[�P���X�m�n				
				public byte[]	bymd = new byte[4] ;			// �[�����͓��t�E����			
				public byte[]	ymdhms = new byte[8] ;			// �z�X�g���t�E����				

				public byte[]	nhkb = new byte[1] ;			// �[�i�敪						
				public byte[]	rem1 = new byte[20] ;			// ���}�[�N						
				public byte[]	kyoten = new byte[2] ;			// �w�苒�_						
				public byte[]	head_ext = new byte[10] ;		// �w�b�h�g���G���A				

				public HDATA[]	hdata = new HDATA[6] ;			// �������C�����ڂP�`�U				
				public HERR herr = new HERR();					// �����G���[
				
				public HATYU()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);					// ���敪						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);				// �e�L�X�g�V�[�P���X�ԍ�		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);			// �e�L�X�g��					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);					// �d���敪						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);				// ��������						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);				// �⍇���^�����敪				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);					// �Ɩ��h�c						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);				// �Ɩ��p�X���[�h				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);			// �[���v���O�����o�[�W�����ԍ�	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);					// �p���敪						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);					// ����h�c						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);					// �g���G���A					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);					// �Ɩ���������					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);					// �Ɩ��p���t���O				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);					// �V�[�P���X�m�n				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);					// �[�����͓��t�E����			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);				// �z�X�g���t�E����				

					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);					// �[�i�敪						
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);					// ���}�[�N						
					UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);				// �w�苒�_						
					UoeCommonFnc.MemSet(ref head_ext, cd, head_ext.Length);			// �w�b�h�g���G���A				

					for(int i=0;i<hdata.Length; i++)
					{
                        if (hdata[i] == null)
                        {
                            hdata[i] = new HDATA();
                        }
                        else
                        {
                            hdata[i].Clear(0x00);
                        }
					}

					herr.Clear(0x00);
				}
			}
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private HATYU hatyu = new HATYU(); 
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder0402()
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

				hatyu.Clear(0x00);
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(UOESupplier uOESupplier, UoeRecDtl dtl)
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                    uOESupplier.UOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//�f�[�^���M�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;


					//��M���t(YYYYMMDD)
    				dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

					//��M����(HHMM)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

					/* �񓚓d���G���[�`�F�b�N	*/
					if ( ( hatyu.kekka[0] != 0x00 )
					||	 ( hatyu.gsk[0] != 0x00 ) )
					{
						string errMessage = "";

						if (hatyu.gsk[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(hatyu.herr.ermsg);
						}
						else
						{
							errMessage = GetHeadErrorMassage(hatyu.kekka[0]);
						}
						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}

					// �[�i�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.nhkb);

					// ���}�[�N
					dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.rem1);

					// �w�苒�_
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.kyoten);

					//��֗L���`�F�b�N���Z�b�g
					//��ւȂ�
					if ((hatyu.hdata[i].gokan[0] == 0x00)
					|| (hatyu.hdata[i].gokan[0] == 0x20)
					|| (hatyu.hdata[i].gokan[0] == 0x30))
					{
						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].khb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].knm);
					}
					//��ւ���
					else
					{
						//��֋敪
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].gokan);

						//��֕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].khb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].bhb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].knm);
					}
					
					//����(������)
					dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].hasu);

					//BO�敪
					dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].bo);

					//�����P���i�d�؂�P���j
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].sktan);

					// �K�p�i�艿�j �k�^�o
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].teika);

					// ���[�J�[�t�H���[��
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].mksu);

					// �o�׏��(�`�[�A�o�א��A�݌ɐ�)
					//vhatsu_kyo( ii );	/* �`�[�A�o�א��A�݌ɐ����	*/

					int hFlg = 0;	// �{��     0:���ݒ� 1:�ݒ��
					int sFlg = 0;	// �T�u�{�� 0:���ݒ� 1:�ݒ��

					for (int ix=0; ix < hatyu.hdata[i].syk.Length; ix++ )
					{
						string kcd = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].syk[ix].kcd);	//���_�R�[�h
						string dno = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].syk[ix].dno);	//�`�[�m���D
						int ssu = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].syk[ix].ssu);		//�o�א�
						int zsu = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].syk[ix].zsu);		//�݌ɐ�

						if( kcd.Trim() == "" ) 
						{
							continue;
						}

						//kcd = "0" + kcd;

						//������}�X�^�̒S�����_�Ɠ���̏ꍇ
                        if (uOESupplier.MazdaSectionCode.Trim() == kcd.Trim())
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1] = kcd;	//���_�R�[�h
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = dno;	//�`�[�m���D
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = ssu;	//�o�א�
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt] = zsu;		//�݌ɐ�
						}

						// �T�u�{��
						else if ( sFlg == 0 )
						{
							sFlg = 1;	// �T�u�{���Z�b�g�ς�

							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2] = kcd;	//���_�R�[�h
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = dno;			//�`�[�m���D
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = ssu;		//�o�א�
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = zsu;		//�݌ɐ�
						}

						// �{��
						else if ( hFlg == 0 )
						{
							hFlg = 1;	// �{���Z�b�g�ς�

							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3] = kcd;	//���_�R�[�h
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = dno;			//�`�[�m���D
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = ssu;		//�o�א�
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = zsu;		//�݌ɐ�
						}
					}

					// �݌Ɂi���_���ށj	�P�|�V�Z�b�g
					for (int j=0; j < 7; j++)
					{
						string kcd = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].zaih[j].kcd);
						if(kcd == "  ")
						{
							continue;
						}

						switch(j)
						{
							case 0:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1] = kcd;
								break;
							case 1:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2] = kcd;
								break;
							case 2:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3] = kcd;
								break;
							case 3:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4] = kcd;
								break;
							case 4:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5] = kcd;
								break;
							case 5:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6] = kcd;
								break;
							case 6:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7] = kcd;
								break;
						}
					}
					
					// �݌Ɂi�݌ɐ��j	�P�|�V�Z�b�g
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[0].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[1].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[2].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[3].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[4].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[5].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[6].zsu);
					
					//�R�����g(���C���G���[���b�Z�[�W)
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].ermsg);
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

				//�w�b�_�[��
				ms.Read(hatyu.jkbn, 0, hatyu.jkbn.Length); // ���敪						
				ms.Read(hatyu.seq_no, 0, hatyu.seq_no.Length); // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(hatyu.text_len, 0, hatyu.text_len.Length); // �e�L�X�g��					
				ms.Read(hatyu.dkbn, 0, hatyu.dkbn.Length); // �d���敪						
				ms.Read(hatyu.kekka, 0, hatyu.kekka.Length); // ��������						
				ms.Read(hatyu.tokbn, 0, hatyu.tokbn.Length); // �⍇���^�����敪				
				ms.Read(hatyu.g_id, 0, hatyu.g_id.Length); // �Ɩ��h�c						
				ms.Read(hatyu.g_pass, 0, hatyu.g_pass.Length); // �Ɩ��p�X���[�h				
				ms.Read(hatyu.prog_ver, 0, hatyu.prog_ver.Length); // �[���v���O�����o�[�W�����ԍ�	
				ms.Read(hatyu.kkbn, 0, hatyu.kkbn.Length); // �p���敪						
				ms.Read(hatyu.h_id, 0, hatyu.h_id.Length); // ����h�c						
				ms.Read(hatyu.ext, 0, hatyu.ext.Length); // �g���G���A					
				ms.Read(hatyu.gsk, 0, hatyu.gsk.Length); // �Ɩ���������					
				ms.Read(hatyu.gsf, 0, hatyu.gsf.Length); // �Ɩ��p���t���O				
				ms.Read(hatyu.seq, 0, hatyu.seq.Length); // �V�[�P���X�m�n				
				ms.Read(hatyu.bymd, 0, hatyu.bymd.Length); // �[�����͓��t�E����			
				ms.Read(hatyu.ymdhms, 0, hatyu.ymdhms.Length); // �z�X�g���t�E����				

				ms.Read(hatyu.nhkb, 0, hatyu.nhkb.Length); // �[�i�敪						
				ms.Read(hatyu.rem1, 0, hatyu.rem1.Length); // ���}�[�N						
				ms.Read(hatyu.kyoten, 0, hatyu.kyoten.Length); // �w�苒�_						
				ms.Read(hatyu.head_ext, 0, hatyu.head_ext.Length); // �w�b�h�g���G���A				

				//�G���[��
                if ((hatyu.kekka[0] != 0x00)
                || (hatyu.gsk[0] != 0x00))
                {
                    HERR Herr = hatyu.herr;

                    ms.Read(Herr.ermsg, 0, Herr.ermsg.Length); // �G���[���b�Z�[�W				
                    ms.Read(Herr.khb, 0, Herr.khb.Length); // ����							
                    ms.Read(Herr.hasu, 0, Herr.hasu.Length); // ������						
                    ms.Read(Herr.bo, 0, Herr.bo.Length); // �a�n�敪						
                }
                //���ו�
                else
                {
                    for (int i = 0; i < hatyu.hdata.Length; i++)
                    {
                        HDATA Hdata = hatyu.hdata[i];

                        ms.Read(Hdata.khb, 0, Hdata.khb.Length); // �i��							
                        ms.Read(Hdata.hasu, 0, Hdata.hasu.Length); // ������						
                        ms.Read(Hdata.syk_max, 0, Hdata.syk_max.Length); // �o�א����v					
                        ms.Read(Hdata.mksu, 0, Hdata.mksu.Length); // �a�n��						
                        ms.Read(Hdata.bo, 0, Hdata.bo.Length); // �a�n�敪						
                        ms.Read(Hdata.knm, 0, Hdata.knm.Length); // ���i��						
                        ms.Read(Hdata.bhb, 0, Hdata.bhb.Length); // ���i�ԍ��i�����j				
                        ms.Read(Hdata.gokan, 0, Hdata.gokan.Length); // �݊����R�[�h					
                        ms.Read(Hdata.sktan, 0, Hdata.sktan.Length); // �d�؂�P��					
                        ms.Read(Hdata.teika, 0, Hdata.teika.Length); // ��]�������i					

                        // �o�׏��	�\����
                        for (int j = 0; j < Hdata.syk.Length; j++)
                        {
                            SYK Syk = hatyu.hdata[i].syk[j];

                            ms.Read(Syk.kcd, 0, Syk.kcd.Length); // ���_�R�[�h					
                            ms.Read(Syk.dno, 0, Syk.dno.Length); // �`�[�m���D					
                            ms.Read(Syk.ssu, 0, Syk.ssu.Length); // �o�א�						
                            ms.Read(Syk.zsu, 0, Syk.zsu.Length); // �݌ɐ�						
                        }

                        // �݌ɏ��	�\����
                        for (int j = 0; j < Hdata.zaih.Length; j++)
                        {
                            ZAIH Zaih = hatyu.hdata[i].zaih[j];

                            ms.Read(Zaih.kcd, 0, Zaih.kcd.Length); // ���_�R�[�h					
                            ms.Read(Zaih.zsu, 0, Zaih.zsu.Length); // �݌ɐ�						
                        }

                        ms.Read(Hdata.ermsg, 0, Hdata.ermsg.Length); // �R�����g						
                        ms.Read(Hdata.l_ext, 0, Hdata.l_ext.Length);// ���C���g���G���A
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
