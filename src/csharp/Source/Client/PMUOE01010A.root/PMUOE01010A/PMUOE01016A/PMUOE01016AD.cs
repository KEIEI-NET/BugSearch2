//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���݌Ɂ��i�z���_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d���M�ҏW���݌Ɂ��i�z���_�j
		/// <summary>
		/// �t�n�d���M�ҏW���݌Ɂ��i�z���_�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0501(out List<UoeSndDtl> list, out string message)
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
				_stockView = new DataView();
				_stockView.Table = StockTable;
				_stockView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock);
                _stockView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock,uOESupplier.UOESupplierCd);
				maxCount = _stockView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//���ʊi�[����
				TelegramEditAlloc0501 telegramEditAlloc0501 = new TelegramEditAlloc0501();
                telegramEditAlloc0501.uOESupplier = uOESupplier;
				telegramEditAlloc0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//���݌ɓd���쐬��
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0501.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0501.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditAlloc0501.Clear();

						//�t�n�d���M�ҏW���ʃN���X�̏�����
						uoeSndDtl = new UoeSndDtl();

						//�����ԍ�
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//�s�ԍ�
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//���M�d��(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//�����ו��ݒ菈����
					//�s�ԍ�
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//���M�d��(JIS)
					telegramEditAlloc0501.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0501.SndTelegramLen;
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
			}


			return status;
		}
		# endregion

		# region �t�n�d���M�d���쐬���݌Ɂ��i�z���_�j
		/// <summary>
		/// �t�n�d���M�d���쐬���݌Ɂ��i�z���_�j
		/// </summary>
		public class TelegramEditAlloc0501
		{
			# region �o�l�V�\�[�X
			//									//-- �d���̈�...ײ�...�݊m --
			//struct	LN_Z {						// 13�޲�                     
			//	char	hb[13];					// ײ�      �i��              
			//};
			//									//-- �d���̈�...�{��...�݊m --
			//struct	DN_Z {						// 57 +260 +1731 = 2048�޲�   
			//	char	id[4];					// ͯ�� TTC  TRN ID	          
			//	char	sp1[5];					//           ��	          
			//	char	ctl[8];					//           ���䕔           
			//	char	fkb[2];					//           ���S�敪	      
			//	char	hbcd[9];				//           �̔��X����       
			//	char	goki[1];				//           ���@	          
			//	char	pass[6];				//           �߽ܰ��          
			//	char	rsno[1];				//           �ذ�NO       	  
			//	char	kera[8];				//           �g���ر  	      
			//	char	seqn[2];				//           seq�ԍ�          
			//	char	yksu[2];				//           �L�������@       
			//	char	seq[3];					//           seq�ԍ�          
			//	char	dttm[6];				//           ���t�����        
			//	char	kflg[1];				//           �p���׸�         
			//	struct	LN_Z	ln_z[20];		// ײ�       15*20=300�޲�    
			//	char	dummy[1730];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[13];				// ײ�      �i��              

				public LN_Z()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ײ�      �i��              
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[] id = new byte[4];					// ͯ�� TTC  TRN ID	          
				public byte[] sp1 = new byte[5];				//           ��	          
				public byte[] ctl = new byte[8];				//           ���䕔           
				public byte[] fkb = new byte[2];				//           ���S�敪	      
				public byte[] hbcd = new byte[9];				//           �̔��X����       
				public byte[] goki = new byte[1];				//           ���@	          
				public byte[] pass = new byte[6];				//           �߽ܰ��          
				public byte[] rsno = new byte[1];				//           �ذ�NO       	  
				public byte[] kera = new byte[8];				//           �g���ر  	      
				public byte[] seqn = new byte[2];				//           seq�ԍ�          
				public byte[] yksu = new byte[2];				//           �L������       
				public byte[] seq = new byte[3];				//           seq�ԍ�          
				public byte[] dttm = new byte[6];				//           ���t�����        
				public byte[] kflg = new byte[1];				//           �p���׸�         
				public LN_Z[] ln_z = new LN_Z[ctBufLen];		// ײ�       15*20=300�޲�    
				public byte[] dummy = new byte[1730];			// ײ�       dummy            
	
				/// <summary>
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
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
					UoeCommonFnc.MemSet(ref kera, 0x20, kera.Length);			//           �g���ر  	      
					UoeCommonFnc.MemSet(ref seqn, 0x20, seqn.Length);			//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref yksu, 0x20, yksu.Length);			//           �L������       
					UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);				//           seq�ԍ�          
					UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);			//           ���t�����        
					UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);			//           �p���׸�         

					//���ו�
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_z[i] == null)
                        {
                            ln_z[i] = new LN_Z();
                        }
                        else
                        {
                            ln_z[i].Clear();
                        }
                    }
					//dummy
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ײ�       dummy            
				}
			}
			# endregion


			# region Const Members
			private const Int32 ctBufLen = 20;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 20;	//���׍s��
            private const Int32 ctSndTelegramLen = 252; //���M�d���T�C�Y
			# endregion

			# region Private Members
			//�݌ɓd��

			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;
			private DN_Z dn_z = new DN_Z();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditAlloc0501()
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
				dn_z.Clear();
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="sec"></param>
			/// <param name="ln"></param>
			/// <param name="dr"></param>
			public void Telegram(DataRow dr)
			{
				//�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
				if (_ln == 0)
				{
					//�g�����U�N�V�����h�c �e�X�g���[�h�̔���
					if(uOESupplier.UOETestMode.Trim() == "9")
					{
						UoeCommonFnc.MemCopy(ref  dn_z.id, "PT81", dn_z.id.Length );
					}
					else
					{
						UoeCommonFnc.MemCopy(ref  dn_z.id, "PL81", dn_z.id.Length );
					}

					//��
					UoeCommonFnc.MemSet(ref dn_z.sp1, 0x20, dn_z.sp1.Length );

					//���䕔
					UoeCommonFnc.MemSet(ref dn_z.ctl, 0x20, dn_z.ctl.Length );
					UoeCommonFnc.MemCopy(ref  dn_z.ctl, "HT11", 4 );

					//���S�敪
					dn_z.fkb[0] = 0x30 ;
					dn_z.fkb[1] = 0x32 ;

					/* �̔��X����    */
					UoeCommonFnc.MemCopy(ref dn_z.hbcd, uOESupplier.UOEConnectUserId, dn_z.hbcd.Length );

					//���@
					UoeCommonFnc.MemCopy(ref dn_z.goki, uOESupplier.instrumentNo, 1);

					//�p�X���[�h
					UoeCommonFnc.MemCopy(ref dn_z.pass, uOESupplier.UOEConnectPassword,  dn_z.pass.Length );

					//�����[�X�m���D
					dn_z.rsno[0] = 0x31 ;

					//�g���G���A
					UoeCommonFnc.MemSet(ref dn_z.kera, 0x20, dn_z.kera.Length );
				
					//�r�d�p�m���D
					dn_z.seqn[0] = 0x30 ;
					dn_z.seqn[1] = 0x31 ;

					//�r�d�p
                    UoeCommonFnc.MemCopy(ref dn_z.seq, String.Format("{0:D3}", _seq), dn_z.seq.Length);

					//�N���E�����E���b
					dn_z.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);	//�N
					dn_z.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	//��
					dn_z.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//��
					dn_z.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//��
					dn_z.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//��
					dn_z.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//�b

					//�p���t���O
					dn_z.kflg[0] = 0x30;						/* �p���׸�    */
				}

				//�L������
                UoeCommonFnc.MemCopy(ref dn_z.yksu, String.Format("{0:D2}", _ln + 1), dn_z.yksu.Length);

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hb, (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_z.ln_z[_ln].hb.Length);

					//���א��C���N�������g
					_ln++;
				}
				# endregion
			}
			# endregion
			# endregion

			# region private Methods
			# region �o�C�g�^�z��ɕϊ�
			/// <summary>
			/// �o�C�g�^�z��ɕϊ�
			/// </summary>
			/// <returns></returns>
			public byte[] ToByteArray(int kflg)
			{
				//�p���Ȃ�
				if (kflg == 1)
				{
					//dn_z.kflg[0] = 0x31;
                    dn_z.kflg[0] = 0x30;
                }
				//�p������
				else
				{
					dn_z.kflg[0] = 0x30;
				}
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_z.id, 0, dn_z.id.Length);				// ͯ�� TTC  TRN ID	          
				ms.Write(dn_z.sp1, 0, dn_z.sp1.Length);				//           ��	          
				ms.Write(dn_z.ctl, 0, dn_z.ctl.Length);				//           ���䕔           
				ms.Write(dn_z.fkb, 0, dn_z.fkb.Length);				//           ���S�敪	      
				ms.Write(dn_z.hbcd, 0, dn_z.hbcd.Length);			//           �̔��X����       
				ms.Write(dn_z.goki, 0, dn_z.goki.Length);			//           ���@	          
				ms.Write(dn_z.pass, 0, dn_z.pass.Length);			//           �߽ܰ��          
				ms.Write(dn_z.rsno, 0, dn_z.rsno.Length);			//           �ذ�NO       	  
				ms.Write(dn_z.kera, 0, dn_z.kera.Length);			//           �g���ر  	      
				ms.Write(dn_z.seqn, 0, dn_z.seqn.Length);			//           seq�ԍ�          
				ms.Write(dn_z.yksu, 0, dn_z.yksu.Length);			//           �L������       
				ms.Write(dn_z.seq, 0, dn_z.seq.Length);				//           seq�ԍ�          
				ms.Write(dn_z.dttm, 0, dn_z.dttm.Length);			//           ���t�����        
				ms.Write(dn_z.kflg, 0, dn_z.kflg.Length);			//           �p���׸�         

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);				// ײ�      �i��              
				}

				//dummy
				ms.Write(dn_z.dummy, 0, dn_z.dummy.Length);			// ײ�       dummy            

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
