//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj�A�N�Z�X�N���X</br>
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

		# region �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj
		/// <summary>
		/// �t�n�d���M�ҏW���݌Ɂ��i�D�ǁj
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc1001(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc1001 telegramEditAlloc1001 = new TelegramEditAlloc1001();
                telegramEditAlloc1001.uOESupplier = uOESupplier;
				telegramEditAlloc1001.Seq = 1;

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

				//���݌ɓd���쐬��
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc1001.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc1001.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc1001.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditAlloc1001.Clear();

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
					telegramEditAlloc1001.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc1001.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc1001.SndTelegramLen;
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
			}


			return status;
		}
		# endregion

		# region �t�n�d���M�d���쐬���݌Ɂ��i�D�ǁj
		/// <summary>
		/// �t�n�d���M�d���쐬���݌Ɂ��i�D�ǁj
		/// </summary>
		public class TelegramEditAlloc1001
		{
			# region �o�l�V�\�[�X
			//									//-- �d���̈�...ײ�...�݊m --
			//struct	LN_Z {						// 43�޲�                     
			//	char	hb[20];					// ײ�      �i��              
			//	char	mkcd[4];				//          Ұ������          
			//	char	bncd[4];				//          ���޺���          
			//	char	hsu[3];					//          ����              
			//	char	bo[1];					//          B/O����           
			//	char	ybc[1];					//          �\������          
			//	char	chkcd[10];				//          ��������          
			//};
			//
			//									//-- �d���̈�...�{��...�݊m --
			//struct	DN_Z {						// 43 +860 +1156 = 2048�޲�   
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
			//	struct	LN_Z	ln_z[20];		// ײ�       43*20=860�޲�    
			//	char	dummy[1156];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[20];		// ײ�      �i��              
				public byte[] mkcd = new byte[4];		//          Ұ������          
				public byte[] bncd = new byte[4];		//          ���޺���          
				public byte[] hsu = new byte[3];		//          ����              
				public byte[] bo = new byte[1];			//          B/O����           
				public byte[] ybc = new byte[1];		//          �\������          
				public byte[] chkcd = new byte[10];		//          ��������          

				public LN_Z()
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
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
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
				public LN_Z[] ln_z = new LN_Z[20];		// ײ�       43*20=860�޲�    
				public byte[] dummy = new byte[1156];	// ײ�       dummy            
	
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
			private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 5;	//���׍s��
            //private const Int32 ctSndTelegramLen = 247; //���M�d���T�C�Y
            private const Int32 ctSndTelegramLen = 256; //���M�d���T�C�Y
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
			public TelegramEditAlloc1001()
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
					//�d���敪
					dn_z.dkb[0] = 0x34;

					//�����敪
					dn_z.sykb[0] = 0x30;

					//�[�����R�[�h
					UoeCommonFnc.MemCopy(ref dn_z.tcd, uOESupplier.UOETerminalCd, dn_z.tcd.Length);

					//�d���⍇���ԍ�
                    UoeCommonFnc.MemCopy(ref dn_z.dtno, String.Format("{0:D6}", (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]), dn_z.dtno.Length);

					//���}�[�N
					UoeCommonFnc.MemCopy(ref dn_z.rem, (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1], dn_z.rem.Length);

					//�[�i�敪
					dn_z.nhkb[0] = 0x20;

					//�w�苒�_					
					UoeCommonFnc.MemSet(ref dn_z.kyo, 0x20, dn_z.kyo.Length);

					//�\���敪�P
					dn_z.ybkb1[0] = 0x20;

					//�\���敪�Q
					dn_z.ybkb2[0] = 0x20;
				}

				//���M���i��
                UoeCommonFnc.MemCopy(ref dn_z.sbsu, String.Format("{0:D1}", _ln + 1), 1);

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hb, (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNo], dn_z.ln_z[_ln].hb.Length);

					//���[�J�[�R�[�h
                    UoeCommonFnc.MemCopy(ref  dn_z.ln_z[_ln].mkcd, String.Format("{0:D4}", (int)dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd]), 4);

					//���ރR�[�h
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].bncd, 0x20, dn_z.ln_z[_ln].bncd.Length);

					//����
					double hsuDouble = (double)dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_z.ln_z[_ln].hsu.Length);

					//�a�^�n�R�[�h
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].bo, 0x20, dn_z.ln_z[_ln].bo.Length);

					//�\���R�[�h
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].ybc, 0x20, dn_z.ln_z[_ln].ybc.Length);

					//�`�F�b�N�R�[�h
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].chkcd, 0x20, dn_z.ln_z[_ln].chkcd.Length);

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
			public byte[] ToByteArray()
			{
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_z.dkb, 0, dn_z.dkb.Length);				// ͯ��      �d���敪         
				ms.Write(dn_z.sykb, 0, dn_z.sykb.Length);			//           �����敪         
				ms.Write(dn_z.tcd, 0, dn_z.tcd.Length);				//           �[�����R�[�h     
				ms.Write(dn_z.dtno, 0, dn_z.dtno.Length);			//           �d���⍇���ԍ�   
				ms.Write(dn_z.sbsu, 0, dn_z.sbsu.Length);			//           ���M���i��       
				ms.Write(dn_z.rem, 0, dn_z.rem.Length);				//           �ϰ�	          
				ms.Write(dn_z.nhkb, 0, dn_z.nhkb.Length);			//           �[�i�敪         
				ms.Write(dn_z.kyo, 0, dn_z.kyo.Length);				//           �w�苒�_         
				ms.Write(dn_z.ybkb1, 0, dn_z.ybkb1.Length);			//           �\���敪�P       
				ms.Write(dn_z.ybkb2, 0, dn_z.ybkb2.Length);			//           �\���敪�Q       

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);				// ײ�      �i��              
					ms.Write(dn_z.ln_z[i].mkcd, 0, dn_z.ln_z[i].mkcd.Length);			//          Ұ������          
					ms.Write(dn_z.ln_z[i].bncd, 0, dn_z.ln_z[i].bncd.Length);			//          ���޺���          
					ms.Write(dn_z.ln_z[i].hsu, 0, dn_z.ln_z[i].hsu.Length);				//          ����              
					ms.Write(dn_z.ln_z[i].bo, 0, dn_z.ln_z[i].bo.Length);				//          B/O����           
					ms.Write(dn_z.ln_z[i].ybc, 0, dn_z.ln_z[i].ybc.Length);				//          �\������          
					ms.Write(dn_z.ln_z[i].chkcd, 0, dn_z.ln_z[i].chkcd.Length);			//          ��������          
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
