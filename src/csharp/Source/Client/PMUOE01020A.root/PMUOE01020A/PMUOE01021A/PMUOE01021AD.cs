//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j���s��
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
	/// �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�g���^�o�c�S�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0102(out string message)
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
    				TelegramJnlStock0102 telegramJnlStock0102 = new TelegramJnlStock0102();

				    foreach (UoeRecDtl dtl in uoeRecDtlList)
				    {
					    telegramJnlStock0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���݌Ɂ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i�g���^�o�c�S�j
		/// </summary>
		public class TelegramJnlStock0102 : UoeRecEdit0102Acs
		{
			# region �o�l�V�\�[�X
			//									/*-- �d���̈�...ײ�...�݊m ---*/
			//struct	LN_Z {					/* 228�޲�                    */
			//	char	hb[12];					/* ײ�      �i��              */
			//	char	hn[30];					/*          �i��              */
			//	char	l_p[7];					/*          L_P               */
			//	char	chscd[1];				/*          ���~CD            */
			//	char	daicd[1];				/*          ���CD            */
			//	char	Akakk[7];				/*          A���i             */
			//	char	hozsu[7];				/*          �{���݌�          */
			//	char	idosu[7];				/*          �ړ�����          */
			//	char	nkicd[1];				/*          �[��CD            */
			//	char	kyzsu[31][5];			/*          ���_�݌ɐ�02-32   */
			//};

			//									/*-- �d���̈�...�{��...�݊m --*/
			//struct	DN_Z {					/* 51 +1368 +629 = 2048�޲�   */
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
			//	struct	LN_Z	z[6];			/* ײ�       6*228=1368�޲�   */
			//	char	dummy[629];				/* ײ�       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 6;	//���׍s��
            private const Int32 ctKyzsuLen = 31;    //���_�݌ɐ��s�J�E���^
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_Z dn_z = new DN_Z();
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[12];				// ײ�      �i��              
				public byte[] hn = new byte[30];				//          �i��              
				public byte[] l_p = new byte[7];				//          L_P               
				public byte[] chscd = new byte[1];				//          ���~CD            
				public byte[] daicd = new byte[1];				//          ���CD            
				public byte[] Akakk = new byte[7];				//          A���i             
				public byte[] hozsu = new byte[7];				//          �{���݌�          
				public byte[] idosu = new byte[7];				//          �ړ�����          
				public byte[] nkicd = new byte[1];				//          �[��CD            
                public byte[][] kyzsu = new byte[ctKyzsuLen][];			//          ���_�݌ɐ�02-32   

				public LN_Z()
				{
                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						kyzsu[j] = new byte[5];			//          ���_�݌ɐ�02-32   
					}

					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);			// ײ�      �i��              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);			//          �i��              
					UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
					UoeCommonFnc.MemSet(ref chscd, cd, chscd.Length);	//          ���~CD            
					UoeCommonFnc.MemSet(ref daicd, cd, daicd.Length);	//          ���CD            
					UoeCommonFnc.MemSet(ref Akakk, cd, Akakk.Length);	//          A���i             
					UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          �{���݌�          
					UoeCommonFnc.MemSet(ref idosu, cd, idosu.Length);	//          �ړ�����          
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          �[��CD            

                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						UoeCommonFnc.MemSet(ref kyzsu[j], cd, kyzsu[j].Length);	//          ���_�݌ɐ�02-32   
					}
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[] jh = new byte[1];			// ͯ�� TTC  ���敪         
				public byte[] ts = new byte[2];			//           ÷�ļ��ݽ        
				public byte[] lg = new byte[2];			//           ÷�Ē�           
				public byte[] tr = new byte[3];			//      ID   ��ݻ޸��ݺ���    
				public byte[] res = new byte[1];		//           ��������         
				public byte[] seq = new byte[3];		//           seq�ԍ�          
				public byte[] acd = new byte[7];		//           ����溰��       
				public byte[] tcd = new byte[7];		//           ��������         
				public byte[] dttm = new byte[6];		//           ���t�����        
				public byte[] pass = new byte[6];		//           �߽ܰ��          
				public byte[] kflg = new byte[1];		//           �p���׸�         
				public byte[] rem3 = new byte[12];		//      ͯ�� �ϰ�3            

				public LN_Z[] ln_z = new LN_Z[ctBufLen];// ײ�       14*10=140�޲�

				public byte[]	dummy = new byte[629];	// ײ�       dummy            

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jh, cd, jh.Length);			// ͯ�� TTC  ���敪         
					UoeCommonFnc.MemSet(ref ts, cd, ts.Length);			//           ÷�ļ��ݽ        
					UoeCommonFnc.MemSet(ref lg, cd, lg.Length);			//           ÷�Ē�           
					UoeCommonFnc.MemSet(ref tr, cd, tr.Length);			//      ID   ��ݻ޸��ݺ���    
					UoeCommonFnc.MemSet(ref res, cd, res.Length);		//           ��������         
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);		//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref acd, cd, acd.Length);		//           ����溰��       
					UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);		//           ��������         
					UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);		//           ���t�����        
					UoeCommonFnc.MemSet(ref pass, cd, pass.Length);		//           �߽ܰ��          
					UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);		//           �p���׸�         
					UoeCommonFnc.MemSet(ref rem3, cd, rem3.Length);		//      ͯ�� �ϰ�3            

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

					//dummy
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ײ�       dummy            
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock0102()
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];

					for (int ix = 0; ix < byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_z.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd > 0)
					{
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
                    }
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

                    //��M����(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//�w�b�h�G���[����
					if (dn_z.res[0] == 0x00)
					{
					}
					//�w�b�h�G���[�Ȃ�
					else
					{
						string errMessage = GetHeadErrorMassage(dn_z.res[0]);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//���C���G���[���b�Z�[�W
						dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//�i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//��ւȂ�
					if ((dn_z.ln_z[i].daicd[0] == 0x00)
					|| (dn_z.ln_z[i].daicd[0] == 0x20)
					|| (dn_z.ln_z[i].daicd[0] == 0x30))
					{
						//���ϰ�
						//dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "0";

						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);

						//�񓚕i��
						if (dn_z.res[0] == 0x00)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hn);
						}
					}
					//��ւ���
					else
					{
						//���ϰ�
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].daicd);

						//��֕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);

						//�񓚕i��
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hn);

						//�񓚕i��
						if (dn_z.res[0] == 0x00)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);
						}
					}

					//�E�vL_P
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].l_p);

					//���~����
					dataRow[StockSndRcvJnlSchema.ct_Col_UOEStopCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].chscd);

					//A���i Double
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].Akakk);
                    dataRow[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].Akakk);

					//�[������
					dataRow[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].nkicd);

					//�݌ɐ�00�{��
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].hozsu);

					//�݌ɐ�01�ړ�
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].idosu);

					//�݌ɐ�02-32
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[0]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[1]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[2]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[3]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[4]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[5]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[6]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[7]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[8]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[9]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[10]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[11]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[12]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[13]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[14]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[15]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[16]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[17]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[18]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[19]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[20]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[21]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[22]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[23]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[24]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[25]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[26]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[27]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[28]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock32] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[29]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock33] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[30]);
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

				ms.Read(dn_z.jh, 0, dn_z.jh.Length);        // ͯ�� TTC  ���敪         
				ms.Read(dn_z.ts, 0, dn_z.ts.Length);        //           ÷�ļ��ݽ        
				ms.Read(dn_z.lg, 0, dn_z.lg.Length);        //           ÷�Ē�           
				ms.Read(dn_z.tr, 0, dn_z.tr.Length);        //      ID   ��ݻ޸��ݺ���    
				ms.Read(dn_z.res, 0, dn_z.res.Length);      //           ��������         
				ms.Read(dn_z.seq, 0, dn_z.seq.Length);      //           seq�ԍ�          
				ms.Read(dn_z.acd, 0, dn_z.acd.Length);      //           ����溰��       
				ms.Read(dn_z.tcd, 0, dn_z.tcd.Length);      //           ��������         
				ms.Read(dn_z.dttm, 0, dn_z.dttm.Length);    //           ���t�����        
				ms.Read(dn_z.pass, 0, dn_z.pass.Length);    //           �߽ܰ��          
				ms.Read(dn_z.kflg, 0, dn_z.kflg.Length);    //           �p���׸�         
				ms.Read(dn_z.rem3, 0, dn_z.rem3.Length);    //      ͯ�� �ϰ�3            


				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);        // ײ�      �i��              
					ms.Read(dn_z.ln_z[i].hn, 0, dn_z.ln_z[i].hn.Length);        //          �i��              
					ms.Read(dn_z.ln_z[i].l_p, 0, dn_z.ln_z[i].l_p.Length);      //          L_P               
					ms.Read(dn_z.ln_z[i].chscd, 0, dn_z.ln_z[i].chscd.Length);  //          ���~CD            
					ms.Read(dn_z.ln_z[i].daicd, 0, dn_z.ln_z[i].daicd.Length);  //          ���CD            
					ms.Read(dn_z.ln_z[i].Akakk, 0, dn_z.ln_z[i].Akakk.Length);  //          A���i             
					ms.Read(dn_z.ln_z[i].hozsu, 0, dn_z.ln_z[i].hozsu.Length);  //          �{���݌�          
					ms.Read(dn_z.ln_z[i].idosu, 0, dn_z.ln_z[i].idosu.Length);  //          �ړ�����          
					ms.Read(dn_z.ln_z[i].nkicd, 0, dn_z.ln_z[i].nkicd.Length);  //          �[��CD            

                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						ms.Read(dn_z.ln_z[i].kyzsu[j], 0, dn_z.ln_z[i].kyzsu[j].Length); //          ���_�݌ɐ�02-32   
					}
				}

				//dummy
				ms.Read(dn_z.dummy, 0, dn_z.dummy.Length); // ײ�       dummy            

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
