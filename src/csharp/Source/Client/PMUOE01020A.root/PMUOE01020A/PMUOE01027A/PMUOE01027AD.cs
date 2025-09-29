//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj���s��
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
	/// �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit1001Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i�D�ǁj
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock1001(out string message)
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
                    TelegramJnlStock1001 telegramJnlStock1001 = new TelegramJnlStock1001();

                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock1001.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���݌Ɂ��i�D�ǁj
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i�D�ǁj
		/// </summary>
		public class TelegramJnlStock1001 : UoeRecEdit1001Acs
		{
			# region �o�l�V�\�[�X
			//struct	DN_Z {					// 155 + 1893 = 2048          
			//	char	dn[1];					// ͯ�� TTC  �d���敪         
			//	char	sykb[1];				//           �����敪         
			//	char	res[2];					//           ��������         
			//	char	dnbn[6];				//           �d���⍇���ԍ�   
			//	char	dngy[1];				//           �񓚓d���Ή��s   
			//	char	rim[10];				//           �ϰ�	          
			//	char	nhkb[1];				//           �[�i�敪         
			//	char	kyo[3];					//           �w�苒�_         
			//	char	g_hb[20];				//           �󒍕��i�ԍ�     
			//	char	s_hb[20];				//           �o�ו��i�ԍ�     
			//	char	mkcd[4];				//           Ұ������         
			//	char	bncd[4];				//           ���޺���         
			//	char	hinm[20];				//           �i��		      
			//	char	tk[7];					//           �艿	          
			//	char	sktk[7];				//           �d�؂�P��	      
			//	char	jysu[3];				//           �󒍐�           
			//	char	sksu[3];				//           �o�א�           
			//	char	bo[1];					//           B/O�敪          
			//	char	yobi[1];				//           �\������         
			//	char	bosu[3];				//           B/O��	          
			//	char	syno[6];				//           �o�ד`�[�ԍ�     
			//	char	bono[6];				//           B/O�`�[�ԍ�      
			//	char	lner[15];				//           ײݴװ		      
			//	char	ckcd[10];				//           ��������	      
			//	char	dummy[1893];			// ײ�       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;	//���׃o�b�t�@�T�C�Y

            private List<DN_Z> dn_z_List = new List<DN_Z>();
            # endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[] dn = new byte[1];		    // ͯ�� TTC  �d���敪         
				public byte[] sykb = new byte[1];		//           �����敪         
				public byte[] res = new byte[2];		//           ��������         
				public byte[] dnbn = new byte[6];		//           �d���⍇���ԍ�   
				public byte[] dngy = new byte[1];		//           �񓚓d���Ή��s   
				public byte[] rim = new byte[10];		//           �ϰ�	          
				public byte[] nhkb = new byte[1];		//           �[�i�敪         
				public byte[] kyo = new byte[3];		//           �w�苒�_         
				public byte[] g_hb = new byte[20];	    //           �󒍕��i�ԍ�     
				public byte[] s_hb = new byte[20];	    //           �o�ו��i�ԍ�     
				public byte[] mkcd = new byte[4];		//           Ұ������         
				public byte[] bncd = new byte[4];		//           ���޺���         
				public byte[] hinm = new byte[20];	    //           �i��		      
				public byte[] tk = new byte[7];		    //           �艿	          
				public byte[] sktk = new byte[7];		//           �d�؂�P��	      
				public byte[] jysu = new byte[3];		//           �󒍐�           
				public byte[] sksu = new byte[3];		//           �o�א�           
				public byte[] bo = new byte[1];		    //           B/O�敪          
				public byte[] yobi = new byte[1];		//           �\������         
				public byte[] bosu = new byte[3];		//           B/O��	          
				public byte[] syno = new byte[6];		//           �o�ד`�[�ԍ�     
				public byte[] bono = new byte[6];		//           B/O�`�[�ԍ�      
				public byte[] lner = new byte[15];	    //           ײݴװ		      
				public byte[] ckcd = new byte[10];	    //           ��������	      
				public byte[] dummy = new byte[101];	// ײ�       dummy            

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref dn, cd, dn.Length);			// ͯ�� TTC  �d���敪         
					UoeCommonFnc.MemSet(ref sykb, cd, sykb.Length);		//           �����敪         
					UoeCommonFnc.MemSet(ref res, cd, res.Length);		//           ��������         
					UoeCommonFnc.MemSet(ref dnbn, cd, dnbn.Length);		//           �d���⍇���ԍ�   
					UoeCommonFnc.MemSet(ref dngy, cd, dngy.Length);		//           �񓚓d���Ή��s   
					UoeCommonFnc.MemSet(ref rim, cd, rim.Length);		//           �ϰ�	          
					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		//           �[�i�敪         
					UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		//           �w�苒�_         
					UoeCommonFnc.MemSet(ref g_hb, cd, g_hb.Length);		//           �󒍕��i�ԍ�     
					UoeCommonFnc.MemSet(ref s_hb, cd, s_hb.Length);		//           �o�ו��i�ԍ�     
					UoeCommonFnc.MemSet(ref mkcd, cd, mkcd.Length);		//           Ұ������         
					UoeCommonFnc.MemSet(ref bncd, cd, bncd.Length);		//           ���޺���         
					UoeCommonFnc.MemSet(ref hinm, cd, hinm.Length);		//           �i��		      
					UoeCommonFnc.MemSet(ref tk, cd, tk.Length);			//           �艿	          
					UoeCommonFnc.MemSet(ref sktk, cd, sktk.Length);		//           �d�؂�P��	      
					UoeCommonFnc.MemSet(ref jysu, cd, jysu.Length);		//           �󒍐�           
					UoeCommonFnc.MemSet(ref sksu, cd, sksu.Length);		//           �o�א�           
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);			//           B/O�敪          
					UoeCommonFnc.MemSet(ref yobi, cd, yobi.Length);		//           �\������         
					UoeCommonFnc.MemSet(ref bosu, cd, bosu.Length);		//           B/O��	          
					UoeCommonFnc.MemSet(ref syno, cd, syno.Length);		//           �o�ד`�[�ԍ�     
					UoeCommonFnc.MemSet(ref bono, cd, bono.Length);		//           B/O�`�[�ԍ�      
					UoeCommonFnc.MemSet(ref lner, cd, lner.Length);		//           ײݴװ		      
					UoeCommonFnc.MemSet(ref ckcd, cd, ckcd.Length);		//           ��������	      
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ײ�       dummy            
				}

			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock1001()
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
                
				//�d���̍s���擾
				_detailMax = dtl.UOESalesOrderRowNo.Count;

                //�o�C�g�^�z��ɕϊ�
                FromByteArray(dtl.RecTelegram, _detailMax);

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

                    DN_Z dn_z = dn_z_List[i];

					//�f�[�^���M�敪
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;

					//��M���t
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

					//��M����
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

					// �t�n�d���}�[�N�P
					dataRow[StockSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.rim);

					// �񓚕i��
					string g_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_z.g_hb);
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = g_hb;

					// ��֕i��(�o�ו��i�ԍ�)
					string s_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_z.s_hb);
					if(s_hb.Trim() != g_hb.Trim())
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = s_hb;
					}

					// �񓚕i��
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.hinm);

					// �E�v�艿(�艿 ����)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.tk);

					//�����P��(�d�ؒP��)
                    double sktk = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.sktk);
                    if (_uoeSndRcvJnlAcs.ChkMeiji(uOESupplierCd) == true)
                    {
                        sktk = sktk / 10;
                    }
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = sktk;

					// �񓚃��[�J�[�R�[�h�𔭒����[�J�[�ɃZ�b�g
					if((s_hb.Trim() != "") || (s_hb.Trim() != g_hb.Trim()))	//�i������
					{
						//���i���[�J�[�R�[�h
						if((int)dataRow[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] == 0)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.mkcd);
						}

						//�`�[����p�i��
						//if (memcmp(uoejla.D3010H, uoejla.D3010P, 15) == 0 && uoejla.D3018P == 0)
						//{
						//	// ������[�J�[�R�[�h
						//	dataRow[StockSndRcvJnlSchema.] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.mkcd);
						//}
					
						// UOE��փR�[�h
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "  ";
					}
					else
					{
						// UOE��փR�[�h
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "01";
					}

					// UOE���_�o�ɐ�
					int sksu = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.sksu);
					if(sksu > 999)
					{
						sksu = 999;
					}
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = sksu;

					// BO�o�ɐ�1(�{��̫۰��)
					int bosu = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.bosu);
					if(bosu > 999)
					{
						sksu = 999;
					}
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = bosu;

					// ���C���G���[���b�Z�[�W
					dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.lner);
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region �o�C�g�^�z��ɕϊ�
            /// <summary>
            /// �o�C�g�^�z��ɕϊ�
            /// </summary>
            /// <param name="line">�ϊ����o�b�t�@</param>
            /// <param name="maxLen"></param>
            private void FromByteArray(byte[] line, int maxCnt)
            {
                dn_z_List.Clear();

                MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < maxCnt; i++)
                {
                    DN_Z dn_z = new DN_Z();
                    ms.Read(dn_z.dn, 0, dn_z.dn.Length);        // ͯ�� TTC  �d���敪         
                    ms.Read(dn_z.sykb, 0, dn_z.sykb.Length);    //           �����敪         
                    ms.Read(dn_z.res, 0, dn_z.res.Length);      //           ��������         
                    ms.Read(dn_z.dnbn, 0, dn_z.dnbn.Length);    //           �d���⍇���ԍ�   
                    ms.Read(dn_z.dngy, 0, dn_z.dngy.Length);    //           �񓚓d���Ή��s   
                    ms.Read(dn_z.rim, 0, dn_z.rim.Length);      //           �ϰ�	          
                    ms.Read(dn_z.nhkb, 0, dn_z.nhkb.Length);    //           �[�i�敪         
                    ms.Read(dn_z.kyo, 0, dn_z.kyo.Length);      //           �w�苒�_         
                    ms.Read(dn_z.g_hb, 0, dn_z.g_hb.Length);    //           �󒍕��i�ԍ�     
                    ms.Read(dn_z.s_hb, 0, dn_z.s_hb.Length);    //           �o�ו��i�ԍ�     
                    ms.Read(dn_z.mkcd, 0, dn_z.mkcd.Length);    //           Ұ������         
                    ms.Read(dn_z.bncd, 0, dn_z.bncd.Length);    //           ���޺���         
                    ms.Read(dn_z.hinm, 0, dn_z.hinm.Length);    //           �i��		      
                    ms.Read(dn_z.tk, 0, dn_z.tk.Length);        //           �艿	          
                    ms.Read(dn_z.sktk, 0, dn_z.sktk.Length);    //           �d�؂�P��	      
                    ms.Read(dn_z.jysu, 0, dn_z.jysu.Length);    //           �󒍐�           
                    ms.Read(dn_z.sksu, 0, dn_z.sksu.Length);    //           �o�א�           
                    ms.Read(dn_z.bo, 0, dn_z.bo.Length);        //           B/O�敪          
                    ms.Read(dn_z.yobi, 0, dn_z.yobi.Length);    //           �\������         
                    ms.Read(dn_z.bosu, 0, dn_z.bosu.Length);    //           B/O��	          
                    ms.Read(dn_z.syno, 0, dn_z.syno.Length);    //           �o�ד`�[�ԍ�     
                    ms.Read(dn_z.bono, 0, dn_z.bono.Length);    //           B/O�`�[�ԍ�      
                    ms.Read(dn_z.lner, 0, dn_z.lner.Length);    //           ײݴװ		      
                    ms.Read(dn_z.ckcd, 0, dn_z.ckcd.Length);    //           ��������	      
                    ms.Read(dn_z.dummy, 0, dn_z.dummy.Length);   // ײ�       dummy   

                    dn_z_List.Add(dn_z);
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
