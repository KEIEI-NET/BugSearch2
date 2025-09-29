//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i���}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i���}�c�_�j���s��
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
	/// �t�n�d��M�ҏW���������i���}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i���}�c�_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���������i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i���}�c�_�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlOrder0401(out string message)
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
                    TelegramJnlOrder0401 telegramJnlOrder0401 = new TelegramJnlOrder0401();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0401.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���������i���}�c�_�j
		/// <summary>
		/// �t�n�d��M�d���쐬���������i���}�c�_�j
		/// </summary>
		public class TelegramJnlOrder0401 : UoeRecEdit0401Acs
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
			///************************ �����񓚎�M�d���\���� ************************/
			//typedef struct	{
			//	char	khb[24] ;					/* �i��							*/
			//	char	hasu[5] ;					/* ������						*/
			//	char	bo[1] ;						/* �a�n�敪						*/
			//	char	sktan[7] ;					/* �d�؂�P��					*/
			//	char	teika[7] ;					/* ��]�������i					*/
			//	char	knm[20] ;					/* ���i��						*/
			//	char	mksu[5] ;					/* �a�n��						*/
			//	char	kydno[7] ;					/* ���_�`�[�m�n					*/
			//	char	shdno[7] ;					/* �x�X�`�[�m�n					*/
			//	char	hodno[7] ;					/* �{�Г`�[�m�n					*/
			//	char	kysu[5] ;					/* ���_�o�א�					*/
			//	char	shsu[5] ;					/* �x�X�o�א�					*/
			//	char	hosu[5] ;					/* �{�Џo�א�					*/
			//	char	bhb[24] ;					/* ���i�ԍ��i�����j				*/
			//	char	gokan[2] ;					/* �݊����R�[�h					*/
			//	char	ermsg[15] ;					/* �R�����g						*/
			//	char	l_ext[3] ;					/* ���C���g���G���A				*/
			//} HDATA ;
			//
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* �[�i�敪						*/
			//	char	rem1[10] ;					/* ���}�[�N						*/
			//	char	kyoten[2] ;					/* �w�苒�_						*/
			//	char	head_ext[20] ;				/* �w�b�h�g���G���A				*/
			//	HDATA	hdata[6] ;					/* ���C�����ڂP�`�U				*/
			//} HATYU ;
			//
			///********************** �����w�b�h�G���[�d���\���� **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* �[�i�敪						*/
			//	char	rem1[10] ;					/* ���}�[�N						*/
			//	char	kyoten[2] ;					/* �w�苒�_						*/
			//	char	head_ext[20] ;				/* �w�b�h�g���G���A				*/
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
			/// �G���[�d���̈恃���C����
			/// </summary>
			private class ER_H
			{
				public byte[] ermsg = new byte[20];		// �G���[���b�Z�[�W				
				public byte[] khb = new byte[24];		// ����							
				public byte[] hasu = new byte[5];		// ������						
				public byte[] bo = new byte[1];			// �a�n�敪						
	
				public ER_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// �G���[���b�Z�[�W				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// ����							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// ������						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// �a�n�敪						
				}
			}
	
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{
				public byte[] khb = new byte[24];		// �i��							
				public byte[] hasu = new byte[5];		// ������						
				public byte[] bo = new byte[1];			// �a�n�敪						
				public byte[] sktan = new byte[7];		// �d�؂�P��					
				public byte[] teika = new byte[7];		// ��]�������i					
				public byte[] knm = new byte[20];		// ���i��						
				public byte[] mksu = new byte[5];		// �a�n��						
				public byte[] kydno = new byte[7];		// ���_�`�[�m�n					
				public byte[] shdno = new byte[7];		// �x�X�`�[�m�n					
				public byte[] hodno = new byte[7];		// �{�Г`�[�m�n					
				public byte[] kysu = new byte[5];		// ���_�o�א�					
				public byte[] shsu = new byte[5];		// �x�X�o�א�					
				public byte[] hosu = new byte[5];		// �{�Џo�א�					
				public byte[] bhb = new byte[24];		// ���i�ԍ��i�����j				
				public byte[] gokan = new byte[2];		// �݊����R�[�h					
				public byte[] ermsg = new byte[15];		// �R�����g						
				public byte[] l_ext = new byte[3];		// ���C���g���G���A				

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// �i��							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// ������						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// �a�n�敪						
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// �d�؂�P��					
					UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// ��]�������i					
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// ���i��						
					UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// �a�n��						
					UoeCommonFnc.MemSet(ref kydno, cd, kydno.Length);		// ���_�`�[�m�n					
					UoeCommonFnc.MemSet(ref shdno, cd, shdno.Length);		// �x�X�`�[�m�n					
					UoeCommonFnc.MemSet(ref hodno, cd, hodno.Length);		// �{�Г`�[�m�n					
					UoeCommonFnc.MemSet(ref kysu, cd, kysu.Length);			// ���_�o�א�					
					UoeCommonFnc.MemSet(ref shsu, cd, shsu.Length);			// �x�X�o�א�					
					UoeCommonFnc.MemSet(ref hosu, cd, hosu.Length);			// �{�Џo�א�					
					UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// ���i�ԍ��i�����j				
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);		// �݊����R�[�h					
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// �R�����g						
					UoeCommonFnc.MemSet(ref l_ext, cd, l_ext.Length);		// ���C���g���G���A				
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
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

				public byte[] nhkb = new byte[1];		// �[�i�敪						
				public byte[] rem1 = new byte[10];		// ���}�[�N						
				public byte[] kyoten = new byte[2];		// �w�苒�_						
				public byte[] head_ext = new byte[20];	// �w�b�h�g���G���A				

				public LN_H[] ln_h = new LN_H[ctBufLen];// ����

				public ER_H er_h = new ER_H();			// �G���[

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_H()
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

					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);			// �[�i�敪						
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);			// ���}�[�N						
					UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);		// �w�苒�_						
					UoeCommonFnc.MemSet(ref head_ext, cd, head_ext.Length);	// �w�b�h�g���G���A				

					//���ו�
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_h[i] == null)
                        {
                            ln_h[i] = new LN_H();
                        }
                        else
                        {
                            ln_h[i].Clear(0x00);
                        }
                    }

					//�G���[��
					er_h.Clear(0x00);
				}
			}

			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_H dn_h = new DN_H(); 
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder0401()
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
			private ER_H Er_h
			{
				get
				{
					return dn_h.er_h;
				}
				set
				{
					this.dn_h.er_h = value;
				}
			}
			# endregion

			# region ���ו�
			/// <summary>
			/// ���ו�
			/// </summary>
			private LN_H[] Ln_h
			{
				get
				{
					return dn_h.ln_h;
				}
				set
				{
					this.dn_h.ln_h = value;
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

				dn_h.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
													uOESupplierCd,
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
					int int32Yymmdd = UoeCommonFnc.atobs(dn_h.ymdhms, 0, 4) * 100;

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//��M����(HHMM)
					dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_h.ymdhms, 4, 4) * 100;

					/* �񓚓d���G���[�`�F�b�N	*/
					if ( ( dn_h.kekka[0] != 0x00 )
					||	 ( dn_h.gsk[0] != 0x00 ) )
					{
						string errMessage = "";

						if (dn_h.gsk[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(dn_h.er_h.ermsg);
						}
						else
						{
							errMessage = GetHeadErrorMassage(dn_h.kekka[0]);
						}
						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}
					
					// �[�i�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.nhkb);
					
					// ���}�[�N
					dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rem1);

					// �w�苒�_
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.kyoten);

					//��֗L���`�F�b�N���Z�b�g
					//��ւȂ�
					if ((dn_h.ln_h[i].gokan[0] == 0x00)
					|| (dn_h.ln_h[i].gokan[0] == 0x20)
					|| (dn_h.ln_h[i].gokan[0] == 0x30))
					{
						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}
					//��ւ���
					else
					{
						//��֋敪
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].gokan);

						//��֕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].bhb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}

					//����(������)
					dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].hasu);

					//BO�敪
					dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].bo);

					//�����P���i�d�؂�P���j
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].sktan);

					//�K�p�i�艿�j �k�^�o
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].teika);

					//���[�J�[�t�H���[��
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mksu);

					//UOE���_�`�[�ԍ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kydno);

					//BO�`�[�ԍ��P(�T�u�{���t�H���[�`�[�m�n)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].shdno);

					//BO�`�[�ԍ��Q(�{���t�H���[�`�[�m�n)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hodno);

					//UOE���_�o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].kysu);

					//BO�o�ɐ�1(�T�u�{���t�H���[��)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] =  UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].shsu);
					
					//BO�o�ɐ�1(�{���t�H���[��)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hosu);

					//�R�����g(���C���G���[���b�Z�[�W)
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].ermsg);
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
				ms.Read(dn_h.jkbn, 0, dn_h.jkbn.Length);            // ���敪						
				ms.Read(dn_h.seq_no, 0, dn_h.seq_no.Length);        // �e�L�X�g�V�[�P���X�ԍ�		
				ms.Read(dn_h.text_len, 0, dn_h.text_len.Length);    // �e�L�X�g��					
				ms.Read(dn_h.dkbn, 0, dn_h.dkbn.Length);            // �d���敪						
				ms.Read(dn_h.kekka, 0, dn_h.kekka.Length);          // ��������						
				ms.Read(dn_h.tokbn, 0, dn_h.tokbn.Length);          // �⍇���^�����敪				
				ms.Read(dn_h.g_id, 0, dn_h.g_id.Length);            // �Ɩ��h�c						
				ms.Read(dn_h.g_pass, 0, dn_h.g_pass.Length);        // �Ɩ��p�X���[�h				
				ms.Read(dn_h.prog_ver, 0, dn_h.prog_ver.Length);    // �[���v���O�����o�[�W�����ԍ�	
				ms.Read(dn_h.kkbn, 0, dn_h.kkbn.Length);            // �p���敪						
				ms.Read(dn_h.h_id, 0, dn_h.h_id.Length);            // ����h�c						
				ms.Read(dn_h.ext, 0, dn_h.ext.Length);              // �g���G���A					
				ms.Read(dn_h.gsk, 0, dn_h.gsk.Length);              // �Ɩ���������					
				ms.Read(dn_h.gsf, 0, dn_h.gsf.Length);              // �Ɩ��p���t���O				
				ms.Read(dn_h.seq, 0, dn_h.seq.Length);              // �V�[�P���X�m�n				
				ms.Read(dn_h.bymd, 0, dn_h.bymd.Length);            // �[�����͓��t�E����			
				ms.Read(dn_h.ymdhms, 0, dn_h.ymdhms.Length);        // �z�X�g���t�E����				

				ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);            // �[�i�敪						
				ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);            // ���}�[�N						
				ms.Read(dn_h.kyoten, 0, dn_h.kyoten.Length);        // �w�苒�_						
				ms.Read(dn_h.head_ext, 0, dn_h.head_ext.Length);    // �w�b�h�g���G���A				

				//�G���[��
				if((dn_h.kekka[0] != 0x00)
				|| (dn_h.gsk[0] != 0x00))
				{
					ms.Read(Er_h.ermsg, 0, Er_h.ermsg.Length);      // �G���[���b�Z�[�W				
					ms.Read(Er_h.khb, 0, Er_h.khb.Length);          // ����							
					ms.Read(Er_h.hasu, 0, Er_h.hasu.Length);        // ������						
					ms.Read(Er_h.bo, 0, Er_h.bo.Length);            // �a�n�敪						
				}
				//���ו�
				else
				{
					for (int i = 0; i < ctBufLen; i++)
					{
						ms.Read(Ln_h[i].khb, 0, Ln_h[i].khb.Length); // �i��							
						ms.Read(Ln_h[i].hasu, 0, Ln_h[i].hasu.Length); // ������						
						ms.Read(Ln_h[i].bo, 0, Ln_h[i].bo.Length); // �a�n�敪						
						ms.Read(Ln_h[i].sktan, 0, Ln_h[i].sktan.Length); // �d�؂�P��					
						ms.Read(Ln_h[i].teika, 0, Ln_h[i].teika.Length); // ��]�������i					
						ms.Read(Ln_h[i].knm, 0, Ln_h[i].knm.Length); // ���i��						
						ms.Read(Ln_h[i].mksu, 0, Ln_h[i].mksu.Length); // �a�n��						
						ms.Read(Ln_h[i].kydno, 0, Ln_h[i].kydno.Length); // ���_�`�[�m�n					
						ms.Read(Ln_h[i].shdno, 0, Ln_h[i].shdno.Length); // �x�X�`�[�m�n					
						ms.Read(Ln_h[i].hodno, 0, Ln_h[i].hodno.Length); // �{�Г`�[�m�n					
						ms.Read(Ln_h[i].kysu, 0, Ln_h[i].kysu.Length); // ���_�o�א�					
						ms.Read(Ln_h[i].shsu, 0, Ln_h[i].shsu.Length); // �x�X�o�א�					
						ms.Read(Ln_h[i].hosu, 0, Ln_h[i].hosu.Length); // �{�Џo�א�					
						ms.Read(Ln_h[i].bhb, 0, Ln_h[i].bhb.Length); // ���i�ԍ��i�����j				
						ms.Read(Ln_h[i].gokan, 0, Ln_h[i].gokan.Length); // �݊����R�[�h					
						ms.Read(Ln_h[i].ermsg, 0, Ln_h[i].ermsg.Length); // �R�����g						
						ms.Read(Ln_h[i].l_ext, 0, Ln_h[i].l_ext.Length); 
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
