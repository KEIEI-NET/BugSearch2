//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���������i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���������i�z���_�j�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10501071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d���M�ҏW���������i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���������i�z���_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0501Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���������i�z���_�j
		/// <summary>
		/// �t�n�d���M�ҏW���������i�z���_�j
		/// </summary>
		/// <param name="uoeSndDtl">���M�ҏW�N���X</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0501(out List<UoeSndDtl> list, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			int maxCount = 0;
			message = "";
			list = new List<UoeSndDtl>();
			List<UoeSndDtl> _list = new List<UoeSndDtl>();

			try
			{
				//�f�[�^�e�[�u������
				_orderView = new DataView();
				_orderView.Table = OrderTable;
				_orderView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Order);
                _orderView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Order,uOESupplier.UOESupplierCd);
				maxCount = _orderView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//���ʊi�[����
				TelegramEditOrder0501 telegramEditOrder0501 = new TelegramEditOrder0501();
                telegramEditOrder0501.uOESupplier = uOESupplier;
				telegramEditOrder0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//�������d���쐬��
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = OrderView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditOrder0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0501.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0501.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditOrder0501.Clear();

						//�t�n�d���M�ҏW���ʃN���X�̏�����
						uoeSndDtl = new UoeSndDtl();

						//�����ԍ�
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//�s�ԍ�
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//���M�d��(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//�����ו��ݒ菈����
					//�s�ԍ�
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//���M�d��(JIS)
					telegramEditOrder0501.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0501.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				if ((status == (int)EnumUoeConst.Status.ct_NORMAL)
				&& (_list.Count > 0))
				{
					list = _list;
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
				status = (int)EnumUoeConst.Status.ct_ERROR;
			}

			return status;
		}
		# endregion

		# region �t�n�d���M�d���쐬���������i�z���_�j
		/// <summary>
		/// �t�n�d���M�d���쐬���������i�z���_�j
		/// </summary>
		public class TelegramEditOrder0501
		{
			# region �o�l�V�\�[�X
			//struct	LN_H {						// 17�޲�                     
			//	char	hb[13];					//          �i��              
			//	char	hsu[3];					//          ����              
			//	char	bo[1];					//          ����ϰ�           
			//};
			//									//-- �d���̈�...�{��...���� --
			//struct	DN_H {						// 84 +340 +1624 = 2048       
			//	char	id[4];					// ͯ�� TTC  TRN ID	          
			//	char	sp1[5];					//           ��	          
			//	char	ctl[8];					//           ���䕔           
			//	char	fkb[2];					//           ���S�敪	      
			//	char	hbcd[9];				//           �̔��X����       
			//	char	goki[1];				//           ���@	          
			//	char	pass[6];				//           �߽ܰ��          
			//	char	rsno[1];				//           �ذ�NO       	  
			//	char	sfg[1];					//           �đ��׸�         
			//	char	kera[7];				//           �g���ر  	      
			//	char	seqn[2];				//           seq�ԍ�          
			//	char	yksu[2];				//           �L�������@       
			//	char	seq[3];					//           seq�ԍ�          
			//	char	dttm[6];				//           ���t�����        
			//	char	kflg[1];				//           �p���׸�         
			//	char	item[5];				//           ����	          
			//	char	sp2[3];					//           ��	          
			//	char	nhkb[1];				//           �[�i�敪         
			//	char	rem[15];				//           �ϰ�             
			//	char	hkb[2];					//           �����敪	      
			//	struct	LN_H	ln_h[20];		// ײ�       17*20=340�޲�    
			//	char	dummy[1624];			// ײ�       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 20;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 20;	//���׍s��
			private const Int32 ctSndTelegramLen = 254; //���M�d���T�C�Y
            # endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[13];				//          �i��              
				public byte[] hsu = new byte[3];				//          ����              
				public byte[] bo = new byte[1];					//          ����ϰ�           

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				//          �i��              
					UoeCommonFnc.MemSet(ref hsu, 0x20, hsu.Length);				//          ����              
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);				//          ����ϰ�           
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
				public byte[] id = new byte[4];					// ͯ�� TTC  TRN ID	          
				public byte[] sp1 = new byte[5];				//           ��	          
				public byte[] ctl = new byte[8];				//           ���䕔           
				public byte[] fkb = new byte[2];				//           ���S�敪	      
				public byte[] hbcd = new byte[9];				//           �̔��X����       
				public byte[] goki = new byte[1];				//           ���@	          
				public byte[] pass = new byte[6];				//           �߽ܰ��          
				public byte[] rsno = new byte[1];				//           �ذ�NO       	  
				public byte[] sfg = new byte[1];				//           �đ��׸�         
				public byte[] kera = new byte[7];				//           �g���ر  	      
				public byte[] seqn = new byte[2];				//           seq�ԍ�          
				public byte[] yksu = new byte[2];				//           �L������       
				public byte[] seq = new byte[3];				//           seq�ԍ�          
				public byte[] dttm = new byte[6];				//           ���t�����        
				public byte[] kflg = new byte[1];				//           �p���׸�         
				public byte[] item = new byte[5];				//           ����	          
				public byte[] sp2 = new byte[3];				//           ��	          
				public byte[] nhkb = new byte[1];				//           �[�i�敪         
				public byte[] rem = new byte[15];				//           �ϰ�             
				public byte[] hkb = new byte[2];				//           �����敪	      
				public LN_H[] ln_h = new LN_H[ctBufLen];		// ײ�       17*20=340�޲�    
				public byte[] dummy = new byte[1624];			// ײ�       dummy	      

				/// <summary>
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_H()
				{
					Clear();
				}

				/// <summary>
				/// ������
				/// </summary>
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref id, 0x20, id.Length);				// ͯ�� TTC  TRN ID	          
					UoeCommonFnc.MemSet(ref sp1, 0x20, sp1.Length);				//           ��	          
					UoeCommonFnc.MemSet(ref ctl, 0x20, ctl.Length);				//           ���䕔           
					UoeCommonFnc.MemSet(ref fkb, 0x20, fkb.Length);				//           ���S�敪	      
					UoeCommonFnc.MemSet(ref hbcd, 0x20, hbcd.Length);			//           �̔��X����       
					UoeCommonFnc.MemSet(ref goki, 0x20, goki.Length);			//           ���@	          
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			//           �߽ܰ��          
					UoeCommonFnc.MemSet(ref rsno, 0x20, rsno.Length);			//           �ذ�NO       	  
					UoeCommonFnc.MemSet(ref sfg, 0x20, sfg.Length);				//           �đ��׸�         
					UoeCommonFnc.MemSet(ref kera, 0x20, kera.Length);			//           �g���ر  	      
					UoeCommonFnc.MemSet(ref seqn, 0x20, seqn.Length);			//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref yksu, 0x20, yksu.Length);			//           �L������       
					UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);				//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);			//           ���t�����        
					UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);			//           �p���׸�         
					UoeCommonFnc.MemSet(ref item, 0x20, item.Length);			//           ����	          
					UoeCommonFnc.MemSet(ref sp2, 0x20, sp2.Length);				//           ��	          
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);			//           �[�i�敪         
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);				//           �ϰ�             
					UoeCommonFnc.MemSet(ref hkb, 0x20, hkb.Length);				//           �����敪	      

					//���ו�
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_h[i] == null)
                        {
                            ln_h[i] = new LN_H();
                        }
                        else
                        {
                            ln_h[i].Clear();
                        }
                    }
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ײ�       dummy            
				}
			}
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;

			private DN_H dn_h = new DN_H();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditOrder0501()
			{
				_seq = 1;
				Clear();
			}
			# endregion

			# region Properties
			# region SEQ�ԍ�
			public Int32 Seq
			{
				get
				{
					return this._seq;
				}
				set
				{
					this._seq = value;
				}
			}
			# endregion

            # region UOE������N���X
            /// <summary>
            /// UOE������N���X
            /// </summary>
            public UOESupplier uOESupplier
            {
                get
                {
                    return this._uOESupplier;
                }
                set
                {
                    this._uOESupplier = value;
                }
            }
            # endregion

            # region ���M�T�C�Y
            /// <summary>
            /// ���M�T�C�Y
            /// </summary>
            public Int32 SndTelegramLen
            {
                get
                {
                    return ctSndTelegramLen;
                }
            }
            # endregion
            # endregion

			# region Public Methods
			# region �f�[�^����������
			/// <summary>
			/// �f�[�^����������
			/// </summary>
			public void Clear()
			{
				_ln = 0;
				dn_h.Clear();
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dr">DataRow</param>
			public void Telegram(DataRow dr)
			{
				//�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
				if (_ln == 0)
				{
					//�g�����U�N�V�����h�c �e�X�g���[�h�̔���
					if(uOESupplier.UOETestMode.Trim() == "9")
					{
						UoeCommonFnc.MemCopy(ref dn_h.id, "PT3A", dn_h.id.Length );//TR����
					}
					else
					{
						UoeCommonFnc.MemCopy(ref dn_h.id, "PL3A", dn_h.id.Length );//TR����
					}

					//��
					UoeCommonFnc.MemSet(ref dn_h.sp1, 0x20, dn_h.sp1.Length );

					//���䕔
					UoeCommonFnc.MemSet(ref dn_h.ctl, 0x20, dn_h.ctl.Length );

					//���䕔
					UoeCommonFnc.MemCopy(ref dn_h.ctl, "HT11", 4 );

					//���S�敪
					dn_h.fkb[0] = 0x30 ;						
					dn_h.fkb[1] = 0x32 ;

					//�̔��X����
					UoeCommonFnc.MemCopy(ref dn_h.hbcd, uOESupplier.UOEConnectUserId, dn_h.hbcd.Length );

					//���@
					UoeCommonFnc.MemCopy(ref dn_h.goki, uOESupplier.instrumentNo, 1);
				
					//�p�X���[�h
					UoeCommonFnc.MemCopy(ref dn_h.pass, uOESupplier.UOEConnectPassword,  dn_h.pass.Length );

					//�����[�X�m���D
					dn_h.rsno[0] = 0x31 ;

					//�đ��t���O
					dn_h.sfg[0] = 0x30 ;

					//�g���G���A
					UoeCommonFnc.MemSet(ref dn_h.kera, 0x20, dn_h.kera.Length );
				
					//�r�d�p�m���D
					dn_h.seqn[0] = 0x30 ;
					dn_h.seqn[1] = 0x31 ;

					//�r�d�p
                    UoeCommonFnc.MemCopy(ref dn_h.seq, String.Format("{0:D3}", _seq), dn_h.seq.Length);

					//�N���E�����E���b
					dn_h.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);	//�N
					dn_h.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //��
					dn_h.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //��
					dn_h.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //��
					dn_h.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	    //��
					dn_h.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	    //�b

					//�p���t���O
					dn_h.kflg[0] = 0x30;
	
					//�A�C�e��
                    String uOEItemCd = uOESupplier.UOEItemCd.Trim();
                    UoeCommonFnc.MemCopy(ref dn_h.item, uOEItemCd, uOEItemCd.Length);

					//��
					UoeCommonFnc.MemSet(ref dn_h.sp2, 0x20, dn_h.sp2.Length );
				
					//�[�i�敪
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);				

                    //�ϰ�
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//�����敪
					//dn_h.hkb[0] = (char)uoejla.PM1521;
					UoeCommonFnc.MemSet(ref dn_h.hkb, 0x20, dn_h.hkb.Length);
				}


				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//���i�ԍ�
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_h.ln_h[_ln].hb.Length);

					//����
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_h.ln_h[_ln].hsu.Length);
					
					//�����}�[�N
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//���א��C���N�������g
					_ln++;
         
				}

                //�L������
                UoeCommonFnc.MemCopy(ref dn_h.yksu, String.Format("{0:D2}", _ln), dn_h.yksu.Length);

                # endregion
			}
			# endregion
			# endregion

			# region private Methods
			# region �o�C�g�^�z��ɕϊ�
			/// <summary>
			/// �o�C�g�^�z��ɕϊ�
			/// </summary>
			/// <returns>�o�C�g�^�z��</returns>
			public byte[] ToByteArray(int kflg)
			{
				//�p���Ȃ�
				if(kflg == 1)
				{
					dn_h.kflg[0] = 0x31;
				}
				//�p������
				else
				{
					dn_h.kflg[0] = 0x30;
				}

				MemoryStream ms = new MemoryStream();

				ms.Write(dn_h.id, 0, dn_h.id.Length);				// ͯ�� TTC  TRN ID	          
				ms.Write(dn_h.sp1, 0, dn_h.sp1.Length);				//           ��	          
				ms.Write(dn_h.ctl, 0, dn_h.ctl.Length);				//           ���䕔           
				ms.Write(dn_h.fkb, 0, dn_h.fkb.Length);				//           ���S�敪	      
				ms.Write(dn_h.hbcd, 0, dn_h.hbcd.Length);			//           �̔��X����       
				ms.Write(dn_h.goki, 0, dn_h.goki.Length);			//           ���@	          
				ms.Write(dn_h.pass, 0, dn_h.pass.Length);			//           �߽ܰ��          
				ms.Write(dn_h.rsno, 0, dn_h.rsno.Length);			//           �ذ�NO       	  
				ms.Write(dn_h.sfg, 0, dn_h.sfg.Length);				//           �đ��׸�         
				ms.Write(dn_h.kera, 0, dn_h.kera.Length);			//           �g���ر  	      
				ms.Write(dn_h.seqn, 0, dn_h.seqn.Length);			//           seq�ԍ�          
				ms.Write(dn_h.yksu, 0, dn_h.yksu.Length);			//           �L������       
				ms.Write(dn_h.seq, 0, dn_h.seq.Length);				//           seq�ԍ�          
				ms.Write(dn_h.dttm, 0, dn_h.dttm.Length);			//           ���t�����        
				ms.Write(dn_h.kflg, 0, dn_h.kflg.Length);			//           �p���׸�         
				ms.Write(dn_h.item, 0, dn_h.item.Length);			//           ����	          
				ms.Write(dn_h.sp2, 0, dn_h.sp2.Length);				//           ��	          
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);			//           �[�i�敪         
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);				//           �ϰ�             
				ms.Write(dn_h.hkb, 0, dn_h.hkb.Length);				//           �����敪	      

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);				//          �i��              
					ms.Write(dn_h.ln_h[i].hsu, 0, dn_h.ln_h[i].hsu.Length);				//          ����              
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);				//          ����ϰ�           
				}

				//dummy
				ms.Write(dn_h.dummy, 0, dn_h.dummy.Length);			// ײ�       dummy            

				byte[] toByteArray = ms.ToArray();
				ms.Close();
				return (toByteArray);
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}
