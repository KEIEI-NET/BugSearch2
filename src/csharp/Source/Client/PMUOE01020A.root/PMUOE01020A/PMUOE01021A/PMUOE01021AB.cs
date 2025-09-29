//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i�g���^�o�c�S�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i�g���^�o�c�S�j���s��
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
	/// �t�n�d��M�ҏW���������i�g���^�o�c�S�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i�g���^�o�c�S�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���������i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i�g���^�o�c�S�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlOrder0102(out string message)
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
                    TelegramJnlOrder0102 telegramJnlOrder0102 = new TelegramJnlOrder0102();
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���������i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d��M�d���쐬���������i�g���^�o�c�S�j
		/// </summary>
		public class TelegramJnlOrder0102 : UoeRecEdit0102Acs
		{
			# region �o�l�V�\�[�X
												/*-- �d���̈�...�{��...���� --*/
			//struct	DN_H {					/* 82 +684 +1282 = 2048       */
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
			//	char	nhkb;					/*           �[�i�敪         */
			//	char	fnkb;					/*           ̫۰�[�i�敪     */
			//	char	rem1[8];				/*           �ϰ�1            */
			//	char	rem2[10];				/*           �ϰ�2            */
			//	char	kyo[2];					/*           �w�苒�_         */
			//	char	tan[2];					/*           �S���Һ���       */
			//	char	skbn;					/*           �����敪         */
			//	char	ndate[6];				/*           �[���w���       */
			//	struct	LN_H	h[3];			/* ײ�       3*228=684�޲�    */
			//	char	dummy[1282];			/* ײ�       dummy            */
			//};
												/*-- �d���̈�...ײ�...���� --*/
			//struct	LN_H {					/* 228�޲�                    */
			//	char	hb[12];					/* ײ�      �i��              */
			//	char	hn[30];					/*          �i��              */
			//	char	l_p[7];					/*          L_P               */
			//	char	d_n[7];					/*          D_N               */
			//	char	jsu[5];					/*          �󒍐�            */
			//	char	su[5];					/*          �o�ɐ�            */
			//	char	sbfsu[5];				/*          ��ޖ{��̫۰��     */
			//	char	hofsu[5];				/*          �{��̫۰��        */
			//	char	rgfsu[5];				/*          ٰĊO̫۰��       */
			//	char	mkfsu[5];				/*          Ұ��̫۰��        */
			//	char	nonsu[5];				/*          ���o�ɐ�          */
			//	char	sbzsu[5];				/*          ��ޖ{���݌�       */
			//	char	hozsu[5];				/*          �{���݌�          */
			//	char	rgzai[5];				/*          ٰĊO�݌ɐ�       */
			//	char	kyden[6];				/*          ��ǋ��_�`��      */
			//	char	sbden[6];				/*          ��ޖ{���`��       */
			//	char	hofde[6];				/*          �{��̫۰�`��      */
			//	char	rgfde[6];				/*          ٰĊO̫۰�`��     */
			//	char	daita[1];				/*          ��֗L��          */
			//	char	hbkbn[1];				/*          �i�ԋ敪          */
			//	char	syocd[1];				/*          ���iCD            */
			//	char	hincd[4];				/*          �i��CD            */
			//	char	nkicd[1];				/*          �[��CD            */
			//	char	hozcd[1];				/*          �{���݌�CD        */
			//	char	lerrC[1];				/*          ײݴװC           */
			//	char	lerrM[6];				/*          ײݴװM           */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 3;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 3;	//���׍s��
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;

			# endregion

			private DN_H dn_h = new DN_H();


			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[12];	// ײ�      �i��              
				public byte[] hn = new byte[30];	//	        �i��              
				public byte[] l_p = new byte[7];	//          L_P               
				public byte[] d_n = new byte[7];	//          D_N               
				public byte[] jsu = new byte[5];	//          �󒍐�            
				public byte[] su = new byte[5];		//          �o�ɐ�            
				public byte[] sbfsu = new byte[5];	//          ��ޖ{��̫۰��     
				public byte[] hofsu = new byte[5];	//          �{��̫۰��        
				public byte[] rgfsu = new byte[5];	//          ٰĊO̫۰��       
				public byte[] mkfsu = new byte[5];	//          Ұ��̫۰��        
				public byte[] nonsu = new byte[5];	//          ���o�ɐ�          
				public byte[] sbzsu = new byte[5];	//          ��ޖ{���݌�       
				public byte[] hozsu = new byte[5];	//          �{���݌�          
				public byte[] rgzai = new byte[5];	//          ٰĊO�݌ɐ�       
				public byte[] kyden = new byte[6];	//          ��ǋ��_�`��      
				public byte[] sbden = new byte[6];	//          ��ޖ{���`��       
				public byte[] hofde = new byte[6];	//          �{��̫۰�`��      
				public byte[] rgfde = new byte[6];	//          ٰĊO̫۰�`��     
				public byte[] daita = new byte[1];	//          ��֗L��          
				public byte[] hbkbn = new byte[1];	//          �i�ԋ敪          
				public byte[] syocd = new byte[1];	//          ���iCD            
				public byte[] hincd = new byte[4];	//          �i��CD            
				public byte[] nkicd = new byte[1];	//          �[��CD            
				public byte[] hozcd = new byte[1];	//          �{���݌�CD        
				public byte[] lerrC = new byte[1];	//          ײݴװC           
				public byte[] lerrM = new byte[6];	//          ײݴװM           

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		    // ײ�      �i��              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		    //          �i��              
					UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
					UoeCommonFnc.MemSet(ref d_n, cd, d_n.Length);		//          D_N               
					UoeCommonFnc.MemSet(ref jsu, cd, jsu.Length);		//          �󒍐�            
					UoeCommonFnc.MemSet(ref su, cd, su.Length);		    //          �o�ɐ�            
					UoeCommonFnc.MemSet(ref sbfsu, cd, sbfsu.Length);	//          ��ޖ{��̫۰��     
					UoeCommonFnc.MemSet(ref hofsu, cd, hofsu.Length);	//          �{��̫۰��        
					UoeCommonFnc.MemSet(ref rgfsu, cd, rgfsu.Length);	//          ٰĊO̫۰��       
					UoeCommonFnc.MemSet(ref mkfsu, cd, mkfsu.Length);	//          Ұ��̫۰��        
					UoeCommonFnc.MemSet(ref nonsu, cd, nonsu.Length);	//          ���o�ɐ�          
					UoeCommonFnc.MemSet(ref sbzsu, cd, sbzsu.Length);	//          ��ޖ{���݌�       
					UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          �{���݌�          
					UoeCommonFnc.MemSet(ref rgzai, cd, rgzai.Length);	//          ٰĊO�݌ɐ�       
					UoeCommonFnc.MemSet(ref kyden, cd, kyden.Length);	//          ��ǋ��_�`��      
					UoeCommonFnc.MemSet(ref sbden, cd, sbden.Length);	//          ��ޖ{���`��       
					UoeCommonFnc.MemSet(ref hofde, cd, hofde.Length);	//          �{��̫۰�`��      
					UoeCommonFnc.MemSet(ref rgfde, cd, rgfde.Length);	//          ٰĊO̫۰�`��     
					UoeCommonFnc.MemSet(ref daita, cd, daita.Length);	//          ��֗L��          
					UoeCommonFnc.MemSet(ref hbkbn, cd, hbkbn.Length);	//          �i�ԋ敪          
					UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);	//          ���iCD            
					UoeCommonFnc.MemSet(ref hincd, cd, hincd.Length);	//          �i��CD            
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          �[��CD            
					UoeCommonFnc.MemSet(ref hozcd, cd, hozcd.Length);	//          �{���݌�CD        
					UoeCommonFnc.MemSet(ref lerrC, cd, lerrC.Length);	//          ײݴװC           
					UoeCommonFnc.MemSet(ref lerrM, cd, lerrM.Length);	//          ײݴװM           
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
				public byte[] jh = new byte[1];		    // ͯ�� TTC  ���敪         
				public byte[] ts = new byte[2];		    //           ÷�ļ��ݽ        
				public byte[] lg = new byte[2];		    //           ÷�Ē�           
				public byte[] tr = new byte[3];		    //      ID   ��ݻ޸��ݺ���    
				public byte[] res = new byte[1];		//           ��������         
				public byte[] seq = new byte[3];		//           seq�ԍ�          
				public byte[] acd = new byte[7];		//           ����溰��       
				public byte[] tcd = new byte[7];		//           ��������         
				public byte[] dttm = new byte[6];		//           ���t�����        
				public byte[] pass = new byte[6];		//           �߽ܰ��          
				public byte[] kflg = new byte[1];		//           �p���׸�         
				public byte[] rem3 = new byte[12];	    //      ͯ�� �ϰ�3            
				public byte[] nhkb = new byte[1];		//           �[�i�敪         
				public byte[] fnkb = new byte[1];		//           ̫۰�[�i�敪     
				public byte[] rem1 = new byte[8];		//           �ϰ�1            
				public byte[] rem2 = new byte[10];	    //           �ϰ�2            
				public byte[] kyo = new byte[2];		//           �w�苒�_         
				public byte[] tan = new byte[2];		//           �S���Һ���       
				public byte[] skbn = new byte[1];		//           �����敪         
				public byte[] ndate = new byte[6];	    //           �[���w���       
				public LN_H[] ln_h = new LN_H[ctBufLen];// ײ�       14*10=140�޲�

				public byte[] dummy = new byte[1282];	// ײ�       dummy            

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_H()
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
					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		//           �[�i�敪         
					UoeCommonFnc.MemSet(ref fnkb, cd, fnkb.Length);		//           ̫۰�[�i�敪     
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);		//           �ϰ�1            
					UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);		//           �ϰ�2            
					UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		//           �w�苒�_         
					UoeCommonFnc.MemSet(ref tan, cd, tan.Length);		//           �S���Һ���       
					UoeCommonFnc.MemSet(ref skbn, cd, skbn.Length);		//           �����敪         
					UoeCommonFnc.MemSet(ref ndate, cd, ndate.Length);	//           �[���w���       

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

					//dummy
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ײ�       dummy            
				}
			}
			# endregion




			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder0102()
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];
 
					for(int ix=0; ix<byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_h.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//�d�����̂ɂɓ��t���Z�b�g����Ă���
					if (int32Yymmdd > 0)
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//�d�����̂ɂɓ��t���Z�b�g����Ă��Ȃ�
					else
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//��M����(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//�w�b�h�G���[����
					if (dn_h.res[0] == 0x00)
					{
						//���C���G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lerrM);
					}
					//�w�b�h�G���[�Ȃ�
					else
					{
						string errMessage = GetHeadErrorMassage(dn_h.res[0]);
						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//���C���G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//��ւȂ�
					if ((dn_h.ln_h[i].daita[0] == 0x00)
					|| (dn_h.ln_h[i].daita[0] == 0x20)
					|| (dn_h.ln_h[i].daita[0] == 0x30))
					{
						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

						//�񓚕i��
						if (dn_h.res[0] == 0x00)
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);
						}
					}
					//��ւ���
					else
					{
						//���ϰ�
                        dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].daita);

						//��֕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

						//�񓚕i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);

						//�񓚕i��
						if (dn_h.res[0] == 0x00)
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);
						}
					}

					//���_�o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].su);

					//BO�o�ɐ�1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbfsu);

					//BO�o�ɐ�2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hofsu);

					//BO�o�ɐ�3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgfsu);

					//���[�J�[�t�H���[��
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mkfsu);

					//���o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].nonsu);

					//BO�݌ɐ�1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbzsu);

					//BO�o�ɐ�2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hozsu);

					//BO�o�ɐ�3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgzai);

					//���_�`�[��
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kyden);

					//BO�`�[��1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sbden);

					//BO�`�[��2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hofde);

					//BO�`�[��3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].rgfde);

					//�K�p�i�艿�j
					dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].l_p);

					//�����P���i�d�؂�P���j
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].d_n);
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

				ms.Read(dn_h.jh, 0, dn_h.jh.Length);        // ͯ�� TTC  ���敪         
                ms.Read(dn_h.ts, 0, dn_h.ts.Length);        //           ÷�ļ��ݽ        
				ms.Read(dn_h.lg, 0, dn_h.lg.Length);        //           ÷�Ē�           
				ms.Read(dn_h.tr, 0, dn_h.tr.Length);        //      ID   ��ݻ޸��ݺ���    
				ms.Read(dn_h.res, 0, dn_h.res.Length);      //           ��������         
				ms.Read(dn_h.seq, 0, dn_h.seq.Length);      //           seq�ԍ�          
				ms.Read(dn_h.acd, 0, dn_h.acd.Length);      //           ����溰��       
				ms.Read(dn_h.tcd, 0, dn_h.tcd.Length);      //           ��������         
				ms.Read(dn_h.dttm, 0, dn_h.dttm.Length);    //           ���t�����        
				ms.Read(dn_h.pass, 0, dn_h.pass.Length);    //           �߽ܰ��          
				ms.Read(dn_h.kflg, 0, dn_h.kflg.Length);    //           �p���׸�         
				ms.Read(dn_h.rem3, 0, dn_h.rem3.Length);    //      ͯ�� �ϰ�3            
				ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);    //           �[�i�敪         
				ms.Read(dn_h.fnkb, 0, dn_h.fnkb.Length);    //           ̫۰�[�i�敪     
				ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);    //           �ϰ�1            
				ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);    //           �ϰ�2            
				ms.Read(dn_h.kyo, 0, dn_h.kyo.Length);      //           �w�苒�_         
				ms.Read(dn_h.tan, 0, dn_h.tan.Length);      //           �S���Һ���       
				ms.Read(dn_h.skbn, 0, dn_h.skbn.Length);    //           �����敪         
				ms.Read(dn_h.ndate, 0, dn_h.ndate.Length);  //           �[���w���       

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);        // ײ�      �i��              
					ms.Read(dn_h.ln_h[i].hn, 0, dn_h.ln_h[i].hn.Length);        //          �i��              
					ms.Read(dn_h.ln_h[i].l_p, 0, dn_h.ln_h[i].l_p.Length);      //          L_P               
					ms.Read(dn_h.ln_h[i].d_n, 0, dn_h.ln_h[i].d_n.Length);      //          D_N               
					ms.Read(dn_h.ln_h[i].jsu, 0, dn_h.ln_h[i].jsu.Length);      //          �󒍐�            
					ms.Read(dn_h.ln_h[i].su, 0, dn_h.ln_h[i].su.Length);        //          �o�ɐ�            
					ms.Read(dn_h.ln_h[i].sbfsu, 0, dn_h.ln_h[i].sbfsu.Length);  //          ��ޖ{��̫۰��     
					ms.Read(dn_h.ln_h[i].hofsu, 0, dn_h.ln_h[i].hofsu.Length);  //          �{��̫۰��        
					ms.Read(dn_h.ln_h[i].rgfsu, 0, dn_h.ln_h[i].rgfsu.Length);  //          ٰĊO̫۰��       
					ms.Read(dn_h.ln_h[i].mkfsu, 0, dn_h.ln_h[i].mkfsu.Length);  //          Ұ��̫۰��        
					ms.Read(dn_h.ln_h[i].nonsu, 0, dn_h.ln_h[i].nonsu.Length);  //          ���o�ɐ�          
					ms.Read(dn_h.ln_h[i].sbzsu, 0, dn_h.ln_h[i].sbzsu.Length);  //          ��ޖ{���݌�       
					ms.Read(dn_h.ln_h[i].hozsu, 0, dn_h.ln_h[i].hozsu.Length);  //          �{���݌�          
					ms.Read(dn_h.ln_h[i].rgzai, 0, dn_h.ln_h[i].rgzai.Length);  //          ٰĊO�݌ɐ�       
					ms.Read(dn_h.ln_h[i].kyden, 0, dn_h.ln_h[i].kyden.Length);  //          ��ǋ��_�`��      
					ms.Read(dn_h.ln_h[i].sbden, 0, dn_h.ln_h[i].sbden.Length);  //          ��ޖ{���`��       
					ms.Read(dn_h.ln_h[i].hofde, 0, dn_h.ln_h[i].hofde.Length);  //          �{��̫۰�`��      
					ms.Read(dn_h.ln_h[i].rgfde, 0, dn_h.ln_h[i].rgfde.Length);  //          ٰĊO̫۰�`��     
					ms.Read(dn_h.ln_h[i].daita, 0, dn_h.ln_h[i].daita.Length);  //          ��֗L��          
					ms.Read(dn_h.ln_h[i].hbkbn, 0, dn_h.ln_h[i].hbkbn.Length);  //          �i�ԋ敪          
					ms.Read(dn_h.ln_h[i].syocd, 0, dn_h.ln_h[i].syocd.Length);  //          ���iCD            
					ms.Read(dn_h.ln_h[i].hincd, 0, dn_h.ln_h[i].hincd.Length);  //          �i��CD            
					ms.Read(dn_h.ln_h[i].nkicd, 0, dn_h.ln_h[i].nkicd.Length);  //          �[��CD            
					ms.Read(dn_h.ln_h[i].hozcd, 0, dn_h.ln_h[i].hozcd.Length);  //          �{���݌�CD        
					ms.Read(dn_h.ln_h[i].lerrC, 0, dn_h.ln_h[i].lerrC.Length);  //          ײݴװC           
					ms.Read(dn_h.ln_h[i].lerrM, 0, dn_h.ln_h[i].lerrM.Length);  //          ײݴװM           
				}
				
				//dummy
				ms.Read(dn_h.dummy, 0, dn_h.dummy.Length);                      // ײ�       dummy            

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
					case 0xF2:						//-- "�ݼ��ް�ż" --
						str = MSG_HEN;
						break;
					case 0xF3:						//-- "ɳ�ݺ���ż" --
						str = MSG_NOU;
						break;
					case 0xF4:						//-- "�ް�ż" --
						str = MSG_DAT;
						break;
					case 0xF5:						//-- "�ò���ݴװ" --
						str = MSG_STK;
						break;
					case 0xC3:						//-- "�����ر��̶" --
						str = MSG_KUF;
						break;
					case 0xC4:						//-- "ʯ�����ĳ���װ" --
						str = MSG_HTA;
						break;
					case 0xC5:						//-- "̫۰ɰ�ݺ���ż" --
						str = MSG_FNC;
						break;
					case 0xC6:						//-- "���������Ϻ��޴װ" --
						str = MSG_KOC;
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
