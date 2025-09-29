//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���������i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���������i�D�ǁj�A�N�Z�X���s��
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
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d���M�ҏW���������i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���������i�D�ǁj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit1001Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���������i�D�ǁj
		/// <summary>
		/// �t�n�d���M�ҏW���������i�D�ǁj
		/// </summary>
		/// <param name="uoeSndDtl">���M�ҏW�N���X</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns></returns>
		private int writeUOESNDEditOrder1001(out List<UoeSndDtl> list, out string message)
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
				TelegramEditOrder1001 telegramEditOrder1001 = new TelegramEditOrder1001();
                telegramEditOrder1001.uOESupplier = uOESupplier;
				telegramEditOrder1001.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//���J�Ǔd���쐬��
				TelegramEditOpenClose1001 telegramEditOpenClose1001 = new TelegramEditOpenClose1001();
                telegramEditOpenClose1001.uOESupplier = uOESupplier;

				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose1001.Telegram(_systemDivCd, (int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose1001.SndTelegramLen;

				//�����ԍ�
				uoeSndDtl.UOESalesOrderNo = 0;
                _list.Add(uoeSndDtl);

				//�������d���쐬��
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = OrderView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditOrder1001.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder1001.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder1001.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditOrder1001.Clear();

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
					telegramEditOrder1001.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder1001.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder1001.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//���Ǔd���쐬��
				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose1001.Telegram(_systemDivCd, (int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose1001.SndTelegramLen;

				//�����ԍ�
				uoeSndDtl.UOESalesOrderNo = 0;
                _list.Add(uoeSndDtl);

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

		# region �t�n�d���M�d���쐬���������i�D�ǁj
		/// <summary>
		/// �t�n�d���M�d���쐬���������i�D�ǁj
		/// </summary>
		public class TelegramEditOrder1001
		{
			# region �o�l�V�\�[�X
			//									//-- �d���̈�...ײ�...���� ---
			//struct	LN_H {						// 43�޲�                     
			//	char	hb[20];					// ײ�      �i��              
			//	char	mkcd[4];				//          Ұ������          
			//	char	bncd[4];				//          ���޺���          
			//	char	hsu[3];					//          ����              
			//	char	bo[1];					//          B/O����           
			//	char	ybc[1];					//          �\������          
			//	char	chkcd[10];				//          ��������          
			//};
			//
			//									//-- �d���̈�...�{��...���� --
			//struct	DN_H {						// 32 +860 +1156 = 2048       
			//	char	dkb[1];					// ͯ��      �d���敪         
			//	char	sykb[1];				//           �����敪         
			//	char	tcd[7];					//           �[�����R�[�h     
			//	char	dtno[6];				//           �d���⍇���ԍ�   
			//	char	sbsu[1];				//           ���M���i��       
			//	char	rem[10];				//           �ϰ�	          
			//	char	nhkb[1];				//           �[�i�敪         
			//	char	kyo[3];					//           �w�苒�_         
			//	char	ybkb1[1];			 	//           �\���敪�P       
			//	char	ybkb2[1];			 	//           �\���敪�Q       
			//	struct	LN_H	ln_h[20];		// ײ�       43*20=860�޲�    
			//	char	dummy[1156];			// ײ�       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 6;	//���׍s��
            //private const Int32 ctSndTelegramLen = 247; //���M�d���T�C�Y
            private const Int32 ctSndTelegramLen = 256; //���M�d���T�C�Y
            # endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[20];		// ײ�      �i��              
				public byte[] mkcd = new byte[4];		//          Ұ������          
				public byte[] bncd = new byte[4];		//          ���޺���          
				public byte[] hsu = new byte[3];		//          ����              
				public byte[] bo = new byte[1];			//          B/O����           
				public byte[] ybc = new byte[1];		//          �\������          
				public byte[] chkcd = new byte[10];		//          ��������          

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ײ�      �i��              
					UoeCommonFnc.MemSet(ref mkcd, 0x20, mkcd.Length);			//          Ұ������          
					UoeCommonFnc.MemSet(ref bncd, 0x20, bncd.Length);			//          ���޺���          
					UoeCommonFnc.MemSet(ref hsu, 0x20, hsu.Length);				//          ����              
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);				//          B/O����           
					UoeCommonFnc.MemSet(ref ybc, 0x20, ybc.Length);				//          �\������          
					UoeCommonFnc.MemSet(ref chkcd, 0x20, chkcd.Length);			//          ��������          
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
				public byte[] dkb = new byte[1];		// ͯ��      �d���敪         
				public byte[] sykb = new byte[1];		//           �����敪         
				public byte[] tcd = new byte[7];		//           �[�����R�[�h     
				public byte[] dtno = new byte[6];		//           �d���⍇���ԍ�   
				public byte[] sbsu = new byte[1];		//           ���M���i��       
				public byte[] rem = new byte[10];		//           �ϰ�	          
				public byte[] nhkb = new byte[1];		//           �[�i�敪         
				public byte[] kyo = new byte[3];		//           �w�苒�_         
				public byte[] ybkb1 = new byte[1];		//           �\���敪�P       
				public byte[] ybkb2 = new byte[1];		//           �\���敪�Q       
				public LN_H[] ln_h = new LN_H[20];		// ײ�       43*20=860�޲�    
				public byte[] dummy = new byte[1156];	// ײ�       dummy            

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
					UoeCommonFnc.MemSet(ref dkb, 0x20, dkb.Length);				// ͯ��      �d���敪         
					UoeCommonFnc.MemSet(ref sykb, 0x20, sykb.Length);			//           �����敪         
					UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);				//           �[�����R�[�h     
					UoeCommonFnc.MemSet(ref dtno, 0x20, dtno.Length);			//           �d���⍇���ԍ�   
					UoeCommonFnc.MemSet(ref sbsu, 0x20, sbsu.Length);			//           ���M���i��       
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);				//           �ϰ�	          
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);			//           �[�i�敪         
					UoeCommonFnc.MemSet(ref kyo, 0x20, kyo.Length);				//           �w�苒�_         
					UoeCommonFnc.MemSet(ref ybkb1, 0x20, ybkb1.Length);			//           �\���敪�P       
					UoeCommonFnc.MemSet(ref ybkb2, 0x20, ybkb2.Length);			//           �\���敪�Q       

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
			public TelegramEditOrder1001()
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
					//�d���敪
					dn_h.dkb[0] = 0x31;
					
					//�����敪
					dn_h.sykb[0] = 0x30;

					//�[�����R�[�h
					UoeCommonFnc.MemCopy(ref dn_h.tcd, uOESupplier.UOETerminalCd, dn_h.tcd.Length);

					//�d���⍇���ԍ�
                    UoeCommonFnc.MemCopy(ref dn_h.dtno, String.Format("{0:D6}", (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]), dn_h.dtno.Length);
					
					//���}�[�N
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//�[�i�敪
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);

					//�w�苒�_					
					UoeCommonFnc.MemCopy(ref dn_h.kyo, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], dn_h.kyo.Length);

					//�\���敪�P
					dn_h.ybkb1[0] = 0x20;

					//�\���敪�Q
					dn_h.ybkb2[0] = 0x20;
				}

				//���M���i��
                UoeCommonFnc.MemCopy(ref dn_h.sbsu, String.Format("{0,1}", _ln + 1), 1);

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNo], dn_h.ln_h[_ln].hb.Length);

					//���[�J�[�R�[�h
                    UoeCommonFnc.MemCopy(ref  dn_h.ln_h[_ln].mkcd, String.Format("{0:D4}", (int)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd]), 4);
			
					//���ރR�[�h
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].bncd, 0x20, dn_h.ln_h[_ln].bncd.Length);
					
					//����
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_h.ln_h[_ln].hsu.Length);
					
					//�a�^�n�R�[�h
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//�\���R�[�h
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].ybc, 0x20, dn_h.ln_h[_ln].ybc.Length);

					//�`�F�b�N�R�[�h
                    string warehouseCode = (string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode];       //�q��
                    string warehouseShelfNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; //�I��
                    string chkcdString = "";

                    switch( uOESupplier.CheckCodeDiv )
					{
                        // 0:�q��(4)+�I��(6)
                        case 0:
                            chkcdString = UoeCommonFnc.GetSubstring(warehouseCode, 0, 4)
                                        + UoeCommonFnc.GetSubstring(warehouseShelfNo, 0, 6);
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 10);
							 break;
                        // 1:�q��(2)+�I��(8)
                        case 1:
                            chkcdString = UoeCommonFnc.GetSubstring(warehouseCode, 0, 2)
                                        + UoeCommonFnc.GetSubstring(warehouseShelfNo, 0, 6);
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 10);
						    break;
					    // 2:�I�Ԃ̂�
						case 2:
                            chkcdString = warehouseShelfNo;
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 8);
							break;
					}

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
			/// <returns>�o�C�g�^�z��</returns>
			public byte[] ToByteArray()
			{
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_h.dkb, 0, dn_h.dkb.Length);				// ͯ��      �d���敪         
				ms.Write(dn_h.sykb, 0, dn_h.sykb.Length);			//           �����敪         
				ms.Write(dn_h.tcd, 0, dn_h.tcd.Length);				//           �[�����R�[�h     
				ms.Write(dn_h.dtno, 0, dn_h.dtno.Length);			//           �d���⍇���ԍ�   
				ms.Write(dn_h.sbsu, 0, dn_h.sbsu.Length);			//           ���M���i��       
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);				//           �ϰ�	          
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);			//           �[�i�敪         
				ms.Write(dn_h.kyo, 0, dn_h.kyo.Length);				//           �w�苒�_         
				ms.Write(dn_h.ybkb1, 0, dn_h.ybkb1.Length);			//           �\���敪�P       
				ms.Write(dn_h.ybkb2, 0, dn_h.ybkb2.Length);			//           �\���敪�Q       

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);				// ײ�      �i��              
					ms.Write(dn_h.ln_h[i].mkcd, 0, dn_h.ln_h[i].mkcd.Length);			//          Ұ������          
					ms.Write(dn_h.ln_h[i].bncd, 0, dn_h.ln_h[i].bncd.Length);			//          ���޺���          
					ms.Write(dn_h.ln_h[i].hsu, 0, dn_h.ln_h[i].hsu.Length);				//          ����              
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);				//          B/O����           
					ms.Write(dn_h.ln_h[i].ybc, 0, dn_h.ln_h[i].ybc.Length);				//          �\������          
					ms.Write(dn_h.ln_h[i].chkcd, 0, dn_h.ln_h[i].chkcd.Length);			//          ��������          
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
