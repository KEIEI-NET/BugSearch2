//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�����ρ��i�z���_�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�����ρ��i�z���_�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d���M�ҏW�����ρ��i�z���_�j
		/// <summary>
		/// �t�n�d���M�ҏW�����ρ��i�z���_�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditEstm0501(out List<UoeSndDtl> list, out string message)
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
				_estmtView = new DataView();
				_estmtView.Table = EstmtTable;
				_estmtView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Estmt);
                _estmtView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Estmt,uOESupplier.UOESupplierCd);
				maxCount = _estmtView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//���ʊi�[����
				TelegramEditEstm0501 telegramEditEstm0501 = new TelegramEditEstm0501();
                telegramEditEstm0501.uOESupplier = uOESupplier;
				telegramEditEstm0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//�����ϓd���쐬��
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = EstmtView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditEstm0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditEstm0501.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditEstm0501.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditEstm0501.Clear();

						//�t�n�d���M�ҏW���ʃN���X�̏�����
						uoeSndDtl = new UoeSndDtl();

						//�����ԍ�
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//�s�ԍ�
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//���M�d��(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//�����ו��ݒ菈����
					//�s�ԍ�
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//���M�d��(JIS)
					telegramEditEstm0501.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditEstm0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditEstm0501.SndTelegramLen;
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

		# region �t�n�d���M�d���쐬�����ρ��i�z���_�j
		/// <summary>
		/// �t�n�d���M�d���쐬�����ρ��i�z���_�j
		/// </summary>
		public class TelegramEditEstm0501
		{
			# region �o�l�V�\�[�X
			//									//-- �d���̈�...ײ�...���� --
			//struct	LN_M {						// 13�޲�                     
			//	char	hb[13];					// ײ�      �i��              
			//};
			//									//-- �d���̈�...�{��...���� --
			//struct	DN_M {						// 57 +260 +1731 = 2048�޲�   
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
			//	struct	LN_M	ln_m[20];		// ײ�       13*20=260�޲�    
			//	char	dummy[1730];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// ���ϓd���̈恃���C����
			/// </summary>
			private class LN_M
			{
				public byte[] hb = new byte[13];				// ײ�      �i��              

				public LN_M()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ײ�      �i��              
				}
			}

			/// <summary>
			/// ���ϓd���̈恃�{�́�
			/// </summary>
			private class DN_M
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
				public LN_M[] ln_m = new LN_M[ctBufLen];		// ײ�       13*20=260�޲�    
				public byte[] dummy = new byte[1730];			// ײ�       dummy            

				/// <summary>
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_M()
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
                        if (ln_m[i] == null)
                        {
                            ln_m[i] = new LN_M();
                        }
                        else
                        {
                            ln_m[i].Clear();
                        }
                    }
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ײ�       dummy            
				}
			}
			# endregion


			# region Const Members
			private const Int32 ctBufLen = 20;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 20;	//���׍s��
            private const Int32 ctSndTelegramLen = 187; //���M�d���T�C�Y
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;
			private DN_M dn_m = new DN_M();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditEstm0501()
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
				dn_m.Clear();
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
						UoeCommonFnc.MemCopy(ref  dn_m.id, "PT8D", dn_m.id.Length );
					}
					else
					{
						UoeCommonFnc.MemCopy(ref  dn_m.id, "PL8D", dn_m.id.Length );
					}

					//��
					UoeCommonFnc.MemSet(ref dn_m.sp1, 0x20, dn_m.sp1.Length );

					//���䕔
					UoeCommonFnc.MemSet(ref dn_m.ctl, 0x20, dn_m.ctl.Length );
					UoeCommonFnc.MemCopy(ref  dn_m.ctl, "HT11", 4 );

					//���S�敪
					dn_m.fkb[0] = 0x30 ;
					dn_m.fkb[1] = 0x32 ;

					/* �̔��X����    */
					UoeCommonFnc.MemCopy(ref dn_m.hbcd, uOESupplier.UOEConnectUserId, dn_m.hbcd.Length );

					//���@
					UoeCommonFnc.MemCopy(ref dn_m.goki, uOESupplier.instrumentNo, 1);

					//�p�X���[�h
					UoeCommonFnc.MemCopy(ref dn_m.pass, uOESupplier.UOEConnectPassword,  dn_m.pass.Length );

					//�����[�X�m���D
					dn_m.rsno[0] = 0x31 ;

					//�g���G���A
					UoeCommonFnc.MemSet(ref dn_m.kera, 0x20, dn_m.kera.Length );
				
					//�r�d�p�m���D
					dn_m.seqn[0] = 0x30 ;
					dn_m.seqn[1] = 0x31 ;

					//�r�d�p
                    UoeCommonFnc.MemCopy(ref dn_m.seq, String.Format("{0:D3}", _seq), dn_m.seq.Length);

					//�N���E�����E���b
					dn_m.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);   //�N
					dn_m.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //��
					dn_m.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //��
					dn_m.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //��
					dn_m.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	    //��
					dn_m.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	    //�b

					//�p���t���O
					dn_m.kflg[0] = 0x30;						/* �p���׸�    */
				}

				//�L������
                UoeCommonFnc.MemCopy(ref dn_m.yksu, String.Format("{0:D2}", _ln + 1), dn_m.yksu.Length);

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_m.ln_m[_ln].hb, (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_m.ln_m[_ln].hb.Length);

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
					dn_m.kflg[0] = 0x31;
				}
				//�p������
				else
				{
					dn_m.kflg[0] = 0x30;
				}
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_m.id, 0, dn_m.id.Length);				// ͯ�� TTC  TRN ID	          
				ms.Write(dn_m.sp1, 0, dn_m.sp1.Length);				//           ��	          
				ms.Write(dn_m.ctl, 0, dn_m.ctl.Length);				//           ���䕔           
				ms.Write(dn_m.fkb, 0, dn_m.fkb.Length);				//           ���S�敪	      
				ms.Write(dn_m.hbcd, 0, dn_m.hbcd.Length);			//           �̔��X����       
				ms.Write(dn_m.goki, 0, dn_m.goki.Length);			//           ���@	          
				ms.Write(dn_m.pass, 0, dn_m.pass.Length);			//           �߽ܰ��          
				ms.Write(dn_m.rsno, 0, dn_m.rsno.Length);			//           �ذ�NO       	  
				ms.Write(dn_m.kera, 0, dn_m.kera.Length);			//           �g���ر  	      
				ms.Write(dn_m.seqn, 0, dn_m.seqn.Length);			//           seq�ԍ�          
				ms.Write(dn_m.yksu, 0, dn_m.yksu.Length);			//           �L������       
				ms.Write(dn_m.seq, 0, dn_m.seq.Length);				//           seq�ԍ�          
				ms.Write(dn_m.dttm, 0, dn_m.dttm.Length);			//           ���t�����        
				ms.Write(dn_m.kflg, 0, dn_m.kflg.Length);			//           �p���׸�         

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_m.ln_m[i].hb, 0, dn_m.ln_m[i].hb.Length);				// ײ�      �i��              
				}

				ms.Write(dn_m.dummy, 0, dn_m.dummy.Length);			// ײ�       dummy            

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
