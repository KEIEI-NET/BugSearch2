//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j���s��
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
	/// �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0102Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ��i�g���^�o�c�S�j
		/// </summary>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		private int GetJnlEstmt0102(out string message)
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
				    TelegramJnlEstmt0102 telegramJnlEstmt0102 = new TelegramJnlEstmt0102();

				    foreach(UoeRecDtl dtl in uoeRecDtlList)
				    {
					    telegramJnlEstmt0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬�����ρ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�d���쐬�����ρ��i�g���^�o�c�S�j
		/// </summary>
		public class TelegramJnlEstmt0102 : UoeRecEdit0102Acs
		{
			# region �o�l�V�\�[�X
			//									/*-- �d���̈�...ײ�...���� --*/
			//struct	LN_M {					/* 74�޲�                     */
			//	char	hb[12];					/* ײ�      �i��              */
			//	char	su[5];					/*          ����              */
			//	char	hn[30];					/*          �i��              */
			//	char	tnk[7];					/*          �P��              */
			//	char	hozai[1];				/*          �{���݌�          */
			//	char	kyzsu[2];				/*          ���_�݌ɐ�        */
			//	char	nkicd[1];				/*          �[��CD            */
			//	char	daim[1];				/*          ���ϰ�           */
			//	char	sktan[7];				/*          �d�؉��i          */
			//	char	lerr[8];				/*          ײݴװ            */
			//};

			/*-- �d���̈�...�{��...���� --*/
			//struct	DN_M {						/* 83 +740 +1225 = 2048�޲�   */
			//	char	jh;						/* ͯ�� TTC  ���敪         */
			//	char	ts[2];					/*           ÷�ļ��ݽ        */
			//	char	lg[2];					/*           ÷�Ē�           */
			//	char	tr[3];					/*      ID   ��ݻ޸��ݺ���    */
			//	char	res;					/*           ��������         */
			//	char	seq[3];					/*           seq�ԍ�          */
			//	char	acd[7];					/*           ����溰��       */
			//	char	tcd[7];					/*           ��������         */
			//	char	dttm[6];				/*           ���t�����        */
			//	char	pass[6];				/*           �߽ܰ��          */
			//	char	kflg;					/*           �p���׸�         */
			//	char	rem3[12];				/*      ͯ�� �ϰ�3            */
			//	char	reto[5];				/*           ڰ�              */
			//	char	senc;					/*           �I����         */
			//	char	remk[8];				/*           �ϰ�             */
			//	char	mitkei[9];				/*           ���ϋ��z�v       */
			//	char	shkkei[9];				/*           �d�؋��z�v       */
			//	struct	LN_M	m[10];			/* ײ�       74*10=740�޲�    */
			//	char	dummy[1225];			/* ײ�       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 10;	//���׍s��
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_M dn_m = new DN_M();
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// ���ϓd���̈恃���C����
			/// </summary>
			private class LN_M
			{
				public byte[] hb = new byte[12];	// ײ�      �i��              
				public byte[] su = new byte[5];		//          ����              
				public byte[] hn = new byte[30];	//          �i��              
				public byte[] tnk = new byte[7];	//          �P��              
				public byte[] hozai = new byte[1];	//          �{���݌�          
				public byte[] kyzsu = new byte[2];	//          ���_�݌ɐ�        
				public byte[] nkicd = new byte[1];	//          �[��CD            
				public byte[] daim = new byte[1];	//          ���ϰ�           
				public byte[] sktan = new byte[7];	//          �d�؉��i          
				public byte[] lerr = new byte[8];	//          ײݴװ            

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		// ײ�      �i��              
					UoeCommonFnc.MemSet(ref su, cd, su.Length);		//          ����              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		//          �i��              
					UoeCommonFnc.MemSet(ref tnk, cd, tnk.Length);		//          �P��              
					UoeCommonFnc.MemSet(ref hozai, cd, hozai.Length);	//          �{���݌�          
					UoeCommonFnc.MemSet(ref kyzsu, cd, kyzsu.Length);	//          ���_�݌ɐ�        
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          �[��CD            
					UoeCommonFnc.MemSet(ref daim, cd, daim.Length);	//          ���ϰ�           
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);	//          �d�؉��i          
					UoeCommonFnc.MemSet(ref lerr, cd, lerr.Length);	//          ײݴװ            
				}
			}

			/// <summary>
			/// ���ϓd���̈恃�{�́�
			/// </summary>
			private class DN_M
			{
				public byte[] jh = new byte[1];				// ͯ�� TTC  ���敪         
				public byte[] ts = new byte[2];				//           ÷�ļ��ݽ        
				public byte[] lg = new byte[2];				//           ÷�Ē�           
				public byte[] tr = new byte[3];				//      ID   ��ݻ޸��ݺ���    
				public byte[] res = new byte[1];			//           ��������         
				public byte[] seq = new byte[3];			//           seq�ԍ�          
				public byte[] acd = new byte[7];			//           ����溰��       
				public byte[] tcd = new byte[7];			//           ��������         
				public byte[] dttm = new byte[6];			//           ���t�����        
				public byte[] pass = new byte[6];			//           �߽ܰ��          
				public byte[] kflg = new byte[1];			//           �p���׸�         
				public byte[] rem3 = new byte[12];			//      ͯ�� �ϰ�3            
				public byte[] reto = new byte[5];			//           ڰ�              
				public byte[] senc = new byte[1];			//           �I����         
				public byte[] remk = new byte[8];			//           �ϰ�             
				public byte[] mitkei = new byte[9];			//           ���ϋ��z�v       
				public byte[] shkkei = new byte[9];			//           �d�؋��z�v       

				public LN_M[] ln_m = new LN_M[ctBufLen];// ײ�       14*10=140�޲�

				public byte[] dummy = new byte[1225];			// ײ�       dummy            

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_M()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jh, cd, jh.Length);					// ͯ�� TTC  ���敪         
					UoeCommonFnc.MemSet(ref ts, cd, ts.Length);					//           ÷�ļ��ݽ        
					UoeCommonFnc.MemSet(ref lg, cd, lg.Length);					//           ÷�Ē�           
					UoeCommonFnc.MemSet(ref tr, cd, tr.Length);					//      ID   ��ݻ޸��ݺ���    
					UoeCommonFnc.MemSet(ref res, cd, res.Length);				//           ��������         
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);				//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref acd, cd, acd.Length);				//           ����溰��       
					UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);				//           ��������         
					UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);				//           ���t�����        
					UoeCommonFnc.MemSet(ref pass, cd, pass.Length);				//           �߽ܰ��          
					UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);				//           �p���׸�         
					UoeCommonFnc.MemSet(ref rem3, cd, rem3.Length);				//      ͯ�� �ϰ�3            
					UoeCommonFnc.MemSet(ref reto, cd, reto.Length);				//           ڰ�              
					UoeCommonFnc.MemSet(ref senc, cd, senc.Length);				//           �I����         
					UoeCommonFnc.MemSet(ref remk, cd, remk.Length);				//           �ϰ�             
					UoeCommonFnc.MemSet(ref mitkei, cd, mitkei.Length);			//           ���ϋ��z�v       
					UoeCommonFnc.MemSet(ref shkkei, cd, shkkei.Length);			//           �d�؋��z�v       

					//���ו�
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_m[i] == null)
                        {
                            ln_m[i] = new LN_M();
                        }
                        else
                        {
                            ln_m[i].Clear(0x00);
                        }
					}

					//dummy
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ײ�       dummy            
				}

			}
			# endregion



			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlEstmt0102()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
				}
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];
 
					for(int ix=0; ix<byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_m.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd > 0)
					{
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
                    }
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
                    }

					//��M����(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//�w�b�h�G���[����
					if (dn_m.res[0] == 0x00)
					{
						//���C���G���[���b�Z�[�W
						//dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].lerrM);
					}
					//�w�b�h�G���[�Ȃ�
					else
					{
						string errMessage = GetHeadErrorMassage(dn_m.res[0]);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//���C���G���[���b�Z�[�W
						dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//�i��
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//��ւȂ�
					if ((dn_m.ln_m[i].daim[0] == 0x00)
					|| (dn_m.ln_m[i].daim[0] == 0x20)
					|| (dn_m.ln_m[i].daim[0] == 0x30))
					{
						//���ϰ�
						dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = "";
						
						//�񓚕i��
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

						//�񓚕i��
						if (dn_m.res[0] == 0x00)
						{
							dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);
						}
					}
					//��ւ���
					else
					{
						//���ϰ�
						dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].daim);
							
						//��֕i��
						dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

						//�񓚕i��
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);

						//�񓚕i��
						if (dn_m.res[0] == 0x00)
						{
							dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);
						}
					}

					//���ϒP��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tnk);

					//�񓚌����P��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);

					//�񓚒艿
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tnk);

					//�{���݌�
					dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hozai);

					//���_�݌ɐ�
					dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].kyzsu);

					//�[������
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].nkicd);
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

				ms.Read(dn_m.jh, 0, dn_m.jh.Length);                            // ͯ�� TTC  ���敪         
				ms.Read(dn_m.ts, 0, dn_m.ts.Length);                            //           ÷�ļ��ݽ        
				ms.Read(dn_m.lg, 0, dn_m.lg.Length);                            //           ÷�Ē�           
				ms.Read(dn_m.tr, 0, dn_m.tr.Length);                            //      ID   ��ݻ޸��ݺ���    
				ms.Read(dn_m.res, 0, dn_m.res.Length);                          //           ��������         
				ms.Read(dn_m.seq, 0, dn_m.seq.Length);                          //           seq�ԍ�          
				ms.Read(dn_m.acd, 0, dn_m.acd.Length);                          //           ����溰��       
				ms.Read(dn_m.tcd, 0, dn_m.tcd.Length);                          //           ��������         
				ms.Read(dn_m.dttm, 0, dn_m.dttm.Length);                        //           ���t�����        
				ms.Read(dn_m.pass, 0, dn_m.pass.Length);                        //           �߽ܰ��          
				ms.Read(dn_m.kflg, 0, dn_m.kflg.Length);                        //           �p���׸�         
				ms.Read(dn_m.rem3, 0, dn_m.rem3.Length);                        //      ͯ�� �ϰ�3            
				ms.Read(dn_m.reto, 0, dn_m.reto.Length);                        //           ڰ�              
				ms.Read(dn_m.senc, 0, dn_m.senc.Length);                        //           �I����         
				ms.Read(dn_m.remk, 0, dn_m.remk.Length);                        //           �ϰ�             
				ms.Read(dn_m.mitkei, 0, dn_m.mitkei.Length);                    //           ���ϋ��z�v       
				ms.Read(dn_m.shkkei, 0, dn_m.shkkei.Length);                    //           �d�؋��z�v       

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_m.ln_m[i].hb, 0, dn_m.ln_m[i].hb.Length);        // ײ�      �i��              
					ms.Read(dn_m.ln_m[i].su, 0, dn_m.ln_m[i].su.Length);        //          ����              
					ms.Read(dn_m.ln_m[i].hn, 0, dn_m.ln_m[i].hn.Length);        //          �i��              
					ms.Read(dn_m.ln_m[i].tnk, 0, dn_m.ln_m[i].tnk.Length);      //          �P��              
					ms.Read(dn_m.ln_m[i].hozai, 0, dn_m.ln_m[i].hozai.Length);  //          �{���݌�          
					ms.Read(dn_m.ln_m[i].kyzsu, 0, dn_m.ln_m[i].kyzsu.Length);  //          ���_�݌ɐ�        
					ms.Read(dn_m.ln_m[i].nkicd, 0, dn_m.ln_m[i].nkicd.Length);  //          �[��CD            
					ms.Read(dn_m.ln_m[i].daim, 0, dn_m.ln_m[i].daim.Length);    //          ���ϰ�           
					ms.Read(dn_m.ln_m[i].sktan, 0, dn_m.ln_m[i].sktan.Length);  //          �d�؉��i          
					ms.Read(dn_m.ln_m[i].lerr, 0, dn_m.ln_m[i].lerr.Length);    //          ײݴװ            
				}
				
				//dummy
				ms.Read(dn_m.dummy, 0, dn_m.dummy.Length);                      // ײ�       dummy            

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
					case 0x11:						//-- "��ݻ޸��ݴװ" --
					case 0xF1:						//-- "��ݻ޸��ݴװ" --
						str = MSG_TRA;
						break;
					case 0x12:						//-- "�����Ϻ��޴װ" --
					case 0xF7:						//-- "�����Ϻ��޴װ" --
						str = MSG_UCD;
						break;
					case 0x14:						//-- "�߽ܰ�޴װ" --
						str = MSG_PAS;
						break;
					case 0x88:						//-- "ٽ��ݴװ" --
						str = MSG_RUS;
						break;
					case 0xF4:						//-- "�ް�ż" --
						str = MSG_DAT;
						break;
					case 0xC1:						//-- "ڰĴװ" --
						str = MSG_RTE;
						break;
					case 0xC2:						//-- "�������޴װ" --
						str = MSG_SCD;
						break;
					case 0xC3:						//-- "���ݷ��ݴװ" --
						str = MSG_SKK;
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
