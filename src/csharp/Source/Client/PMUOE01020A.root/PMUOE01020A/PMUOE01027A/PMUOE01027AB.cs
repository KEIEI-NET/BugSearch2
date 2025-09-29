//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i�D�ǁj���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���X�� �M�p
// �� �� ��  2012/10/03  �C�����e : �d���悪�D�ǂ̏ꍇ�̎�M�G���[��
//                                  ���M�G���[�Ƃ��ď��������s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : ���N�n��
// �� �� ��  2013/10/09  �C�����e : Redmine 40628��No36�_�A���P���̑Ή�
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
using Broadleaf.Application.Resources;
using System.Threading;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d��M�ҏW���������i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br></br>
    /// <br>Update Note : 2012/10/03 FSI���X�� �M�p</br>
    /// <br>             �E�d���悪�D�ǂ̏ꍇ�̎�M�G���[��</br>
    /// <br>               ���M�G���[�Ƃ��ď��������s��Ή�</br>
    /// <br>Update Note : 2013/10/09 ���N�n��</br>
    /// <br>              Redmine 40628��No36�_�A���P���̑Ή�</br>
    /// </remarks>
	public partial class UoeRecEdit1001Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���������i�D�ǁj
		/// <summary>
		/// �t�n�d��M�ҏW���������i�D�ǁj
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �t�n�d����M�f�[�^�̑��M�t���O�E�����t���O�̍X�V�����C��</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : 2012/10/03</br>
        /// </remarks>
        private int GetJnlOrder1001(out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
            // --- ADD 2012/10/03 ----------->>>>>
            int dataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_SndNG;// ���M�t���O
            int dataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;// �����t���O
            // --- ADD 2012/10/03 -----------<<<<<
            message = "";

			try
			{
                //-----------------------------------------------------------
                // �i�m�k�X�V����
                //-----------------------------------------------------------
                if (uoeRecHed != null)
                {
                    _uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(_uoeRecHed.UOESupplierCd);

                    List<OrderSndRcvJnl> _list = new List<OrderSndRcvJnl>();

                    TelegramJnlOrder1001 telegramJnlOrder1001 = new TelegramJnlOrder1001();

                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder1001.Telegram(_uOESupplier, dtl);
                        // --- ADD 2012/10/03 ----------->>>>>
                        // ���M�t���O�A�����t���O���ꎞ�I�ɕێ�����
                        dataSendCode = dtl.DataSendCode;
                        dataRecoverDiv = dtl.DataRecoverDiv;
                        // --- ADD 2012/10/03 -----------<<<<<
                    }
                }

                // --- ADD 2012/10/03 ----------->>>>>
                // �ꎞ�ێ��������M�t���O��2:���M�G���[�łȂ��A�܂��͕����t���O��0:�������łȂ��ꍇ
                // ���M�t���O�y�ѕ����t���O�̍X�V�������s��
                if (((int)EnumUoeConst.ctDataSendCode.ct_SndNG != dataSendCode) || ((int)EnumUoeConst.ctDataRecoverDiv.ct_YES != dataRecoverDiv))
                {
                    //-----------------------------------------------------------
                    // ����M�i�m�k�����M�t���O�E�����t���O���̍X�V
                    //   ���M�t���O (�X�V�O)1:������ �� (�X�V��)2:�ꎞ�ێ��������M�t���O
                    //   �����t���O (�X�V�O)0:������ �� (�X�V��)1:�ꎞ�ێ����������t���O
                    //-----------------------------------------------------------
                    _uoeSndRcvJnlAcs.JnlOrderTblFlgUpdt1001(_uoeSndHed.UOESupplierCd,
                        (int)EnumUoeConst.ctDataSendCode.ct_Process,        //1:������
                        (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess,   //0:������
                        dataSendCode,                                       //�ꎞ�ێ��������M�t���O
                        dataRecoverDiv);			                        //�ꎞ�ێ����������t���O
                }
                // --- ADD 2012/10/03 -----------<<<<<

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

		# region �t�n�d��M�d���쐬���������i�D�ǁj
		/// <summary>
		/// �t�n�d��M�d���쐬���������i�D�ǁj
		/// </summary>
		public class TelegramJnlOrder1001 : UoeRecEdit1001Acs
		{
			# region �o�l�V�\�[�X
			//struct	DN_H {					// 155 + 1893 = 2048          
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
			private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
				public byte[] dn = new byte[1];		// ͯ�� TTC  �d���敪         
				public byte[] sykb = new byte[1];		//           �����敪         
				public byte[] res = new byte[2];		//           ��������         
				public byte[] dnbn = new byte[6];		//           �d���⍇���ԍ�   
				public byte[] dngy = new byte[1];		//           �񓚓d���Ή��s   
				public byte[] rim = new byte[10];		//           �ϰ�	          
				public byte[] nhkb = new byte[1];		//           �[�i�敪         
				public byte[] kyo = new byte[3];		//           �w�苒�_         
				public byte[] g_hb = new byte[20];	//           �󒍕��i�ԍ�     
				public byte[] s_hb = new byte[20];	//           �o�ו��i�ԍ�     
				public byte[] mkcd = new byte[4];		//           Ұ������         
				public byte[] bncd = new byte[4];		//           ���޺���         
				public byte[] hinm = new byte[20];	//           �i��		      
				public byte[] tk = new byte[7];		//           �艿	          
				public byte[] sktk = new byte[7];		//           �d�؂�P��	      
				public byte[] jysu = new byte[3];		//           �󒍐�           
				public byte[] sksu = new byte[3];		//           �o�א�           
				public byte[] bo = new byte[1];		//           B/O�敪          
				public byte[] yobi = new byte[1];		//           �\������         
				public byte[] bosu = new byte[3];		//           B/O��	          
				public byte[] syno = new byte[6];		//           �o�ד`�[�ԍ�     
				public byte[] bono = new byte[6];		//           B/O�`�[�ԍ�      
				public byte[] lner = new byte[15];	//           ײݴװ		      
				public byte[] ckcd = new byte[10];	//           ��������	      
				public byte[] dummy = new byte[101];	// ײ�       dummy            

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_H()
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

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_H dn_h = new DN_H();

            private List<DN_H> dn_h_List = new List<DN_H>();

            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
            //Thread���A���b�Z�[�W�֌W
            private const string MSGSHOWSOLT = "MSGSHOWSOLT";
            private LocalDataStoreSlot msgShowSolt = null;

            #region ���񋓑�
            /// <summary>
            /// �I�v�V�����L���L��
            /// </summary>
            public enum Option : int
            {
                /// <summary>�������[�U</summary>
                OFF = 0,
                /// <summary>�L�����[�U</summary>
                ON = 1,
            }
            #endregion

            /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
            private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

            //��pUSB�p
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
            // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<

			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder1001()
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
            public void Telegram(UOESupplier uOESupplier, UoeRecDtl dtl)
			{
                // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
                //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
                fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);

                if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    this._opt_FuTaBa = (int)Option.ON;
                }
                else
                {
                    this._opt_FuTaBa = (int)Option.OFF;
                }
                // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<

                //�J�ǁE�Ǔd���̃X�L�b�v����
                if ((dtl.UOESalesOrderNo == 0) && (dtl.UOESalesOrderRowNo.Count == 0)) return;
                
				//�d���̍s���擾
				_detailMax = dtl.UOESalesOrderRowNo.Count;

                //�o�C�g�^�z��ɕϊ�
                FromByteArray(dtl.RecTelegram, _detailMax);

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

                    DN_H dn_h = dn_h_List[i];

					//�f�[�^���M�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;

					//��M���t
					dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

					//��M����
					dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

					//�񓚃��[�J�[�R�[�h�Z�b�g
					dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerMakerCd] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.mkcd);

					// �[�i�敪
                    //dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.nhkb);

					// UOE�w�苒�_
					//dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.kyo);

					// �t�n�d���}�[�N�P
					//dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rim);

					// �񓚕i��
					string g_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_h.g_hb);
					dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = g_hb;

					// ��֕i��(�o�ו��i�ԍ�)
					string s_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_h.s_hb);
					if(s_hb.Trim() != g_hb.Trim())
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = s_hb;
					}
					
					// �񓚕i��
					dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.hinm);

					// BO�敪
					//dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.bo);

					// �񓚃��[�J�[�R�[�h�𔭒����[�J�[�ɃZ�b�g
					if((s_hb.Trim() != "") || (s_hb.Trim() != g_hb.Trim()))	//�i������
					{
						//���i���[�J�[�R�[�h
						if((int)dataRow[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd] == 0)
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.mkcd);
						}

						//�`�[����p�i��
						//if (memcmp(uoejla.D3010H, uoejla.D3010P, 15) == 0 && uoejla.D3018P == 0)
						//{
						//	// ������[�J�[�R�[�h
						//	dataRow[OrderSndRcvJnlSchema.] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.mkcd);
						//}
					
						// UOE��փ}�[�N
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "  ";
					}
					else
					{
						// UOE��փ}�[�N
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "01";
					}

					// �󒍐���
					//double jysu = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.jysu);
					//if(jysu > 999)
					//{
					//	jysu = 999;
					//}
					//dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = jysu;

					// UOE���_�o�ɐ�
					int sksu = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.sksu);
					if(sksu > 999)
					{
						sksu = 999;
					}
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = sksu;

					// BO�o�ɐ�1(�{��̫۰��)
					int bosu = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.bosu);
					if(bosu > 999)
					{
						sksu = 999;
					}
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = bosu;

					// UOE���_�`�[�ԍ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.syno);

					// BO�`�[�ԍ��P
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.bono);

					// �E�v�艿(�艿 ����)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.tk);

					//�����P��(�d�ؒP��)
					double sktk = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.sktk);
                    if (_uoeSndRcvJnlAcs.ChkMeiji(uOESupplier.UOESupplierCd) == true)
                    {
                        // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- >>>>>
                        //�t�^�oUSB��p
                        if (this._opt_FuTaBa == (int)Option.ON)
                        {
                            msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);

                            //������M����(�蓮)�ł���ꍇ
                            if (!(Thread.GetData(msgShowSolt) != null
                                && ((Int32)Thread.GetData(msgShowSolt) == 1 
                                || (Int32)Thread.GetData(msgShowSolt) == 2
                                || (Int32)Thread.GetData(msgShowSolt) == 3
                                || (Int32)Thread.GetData(msgShowSolt) == 4)))
                            {
                                sktk = sktk / 10;
                            }
                           
                        }
                        else
                        {
                            sktk = sktk / 10;
                        }
                        // ---- ADD  2013/10/09 ���N�n�� Redmine40628---- <<<<<

                        //sktk = sktk/10;//DEL  2013/10/09 ���N�n�� Redmine40628
                    }

                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = sktk;

					// UOE�}�[�N�R�[�h
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.yobi);

					// ���C���G���[���b�Z�[�W
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.lner);

					// �`�F�b�N�R�[�h�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOECheckCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ckcd);
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
                dn_h_List.Clear();

				MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < maxCnt; i++)
                {
                    DN_H dn_h = new DN_H();
                    ms.Read(dn_h.dn, 0, dn_h.dn.Length); // ͯ�� TTC  �d���敪         
                    ms.Read(dn_h.sykb, 0, dn_h.sykb.Length); //           �����敪         
                    ms.Read(dn_h.res, 0, dn_h.res.Length); //           ��������         
                    ms.Read(dn_h.dnbn, 0, dn_h.dnbn.Length); //           �d���⍇���ԍ�   
                    ms.Read(dn_h.dngy, 0, dn_h.dngy.Length); //           �񓚓d���Ή��s   
                    ms.Read(dn_h.rim, 0, dn_h.rim.Length); //           �ϰ�	          
                    ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length); //           �[�i�敪         
                    ms.Read(dn_h.kyo, 0, dn_h.kyo.Length); //           �w�苒�_         
                    ms.Read(dn_h.g_hb, 0, dn_h.g_hb.Length); //           �󒍕��i�ԍ�     
                    ms.Read(dn_h.s_hb, 0, dn_h.s_hb.Length); //           �o�ו��i�ԍ�     
                    ms.Read(dn_h.mkcd, 0, dn_h.mkcd.Length); //           Ұ������         
                    ms.Read(dn_h.bncd, 0, dn_h.bncd.Length); //           ���޺���         
                    ms.Read(dn_h.hinm, 0, dn_h.hinm.Length); //           �i��		      
                    ms.Read(dn_h.tk, 0, dn_h.tk.Length); //           �艿	          
                    ms.Read(dn_h.sktk, 0, dn_h.sktk.Length); //           �d�؂�P��	      
                    ms.Read(dn_h.jysu, 0, dn_h.jysu.Length); //           �󒍐�           
                    ms.Read(dn_h.sksu, 0, dn_h.sksu.Length); //           �o�א�           
                    ms.Read(dn_h.bo, 0, dn_h.bo.Length); //           B/O�敪          
                    ms.Read(dn_h.yobi, 0, dn_h.yobi.Length); //           �\������         
                    ms.Read(dn_h.bosu, 0, dn_h.bosu.Length); //           B/O��	          
                    ms.Read(dn_h.syno, 0, dn_h.syno.Length); //           �o�ד`�[�ԍ�     
                    ms.Read(dn_h.bono, 0, dn_h.bono.Length); //           B/O�`�[�ԍ�      
                    ms.Read(dn_h.lner, 0, dn_h.lner.Length); //           ײݴװ		      
                    ms.Read(dn_h.ckcd, 0, dn_h.ckcd.Length); //           ��������	      
                    ms.Read(dn_h.dummy, 0, dn_h.dummy.Length); // ײ�       dummy   

                    dn_h_List.Add(dn_h);
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
