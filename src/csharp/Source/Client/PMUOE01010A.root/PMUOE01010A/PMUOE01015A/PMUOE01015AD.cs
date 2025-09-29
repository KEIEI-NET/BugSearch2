//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0402Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j
		/// <summary>
		/// �t�n�d���M�ҏW���݌Ɂ��i�V�}�c�_�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0402(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc0402 telegramEditAlloc0402 = new TelegramEditAlloc0402();
                telegramEditAlloc0402.uOESupplier = uOESupplier;
				telegramEditAlloc0402.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//���J�Ǔd���쐬��
				TelegramEditOpenClose0402 telegramEditOpenClose0402 = new TelegramEditOpenClose0402();
                telegramEditOpenClose0402.uOESupplier = uOESupplier;

				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0402.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0402.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditAlloc0402.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0402.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0402.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditAlloc0402.Clear();

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
					telegramEditAlloc0402.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0402.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0402.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//���Ǔd���쐬��
				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0402.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0402.SndTelegramLen;

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

		# region �t�n�d���M�d���쐬���݌Ɂ��i�V�}�c�_�j
		/// <summary>
		/// �t�n�d���M�d���쐬���݌Ɂ��i�V�}�c�_�j
		/// </summary>
		public class TelegramEditAlloc0402
		{
			# region �o�l�V�\�[�X
			//									//-- �d���̈�...ײ�...�݊m ---
			//struct	LN_Z {					// 24�޲�                     
			//	char	hb[24];					// ײ�      ���i�ԍ�          
			//};
			//									//-- �d���̈�...�{��...�݊m --
			//struct	DN_Z {					// 65 + 120+1863 = 2048�޲�   
			//	char	jh;						// ͯ�� TTC  ���敪         
			//	char	ts[2];					//           ÷�ļ��ݽ        
			//	char	lg[2];					//           ÷�Ē�           
			//	char	dbkb;					//           �d���敪         
			//	char	res;					//           ��������         
			//	char	toikb;					//           �⍇�������敪   
			//	char	gyoid[12];				//           �Ɩ�ID           
			//	char	pass[6];				//           �߽ܰ��          
			//	char	vers[3];				//           �ް�ޮݔԍ�      
			//	char	keikb;					//           �p���敪         
			//	char	hikid[3];				//           ���ID           
			//	char	exten[15];				//           �g���ر          
			//	char	kekka;					//     ͯ��1 �Ɩ���������     
			//	char	keiflg;					//           �p���t���O       
			//	char	seqno[3];				//           ���ݽNO          
			//	char	inpymd[4];				//           ���͓��t����     
			//	char	ukeymd[8];				//           ��t���t����     
			//	struct	LN_Z	ln_z[5];		// ײ�       24*5=120�޲�     
			//	char	dummy[1863];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[24];				// ײ�      ���i�ԍ�          

				public LN_Z()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ײ�      ���i�ԍ�          
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
				public byte[] jh = new byte[1];					// ͯ�� TTC  ���敪         
				public byte[] ts = new byte[2];					//           ÷�ļ��ݽ        
				public byte[] lg = new byte[2];					//           ÷�Ē�           
				public byte[] dbkb = new byte[1];				//           �d���敪         
				public byte[] res = new byte[1];				//           ��������         
				public byte[] toikb = new byte[1];				//           �⍇�������敪   
				public byte[] gyoid = new byte[12];				//           �Ɩ�ID           
				public byte[] pass = new byte[6];				//           �߽ܰ��          
				public byte[] vers = new byte[3];				//           �ް�ޮݔԍ�      
				public byte[] keikb = new byte[1];				//           �p���敪         
				public byte[] hikid = new byte[3];				//           ���ID           
				public byte[] exten = new byte[15];				//           �g���ر          
				public byte[] kekka = new byte[1];				//     ͯ��1 �Ɩ���������     
				public byte[] keiflg = new byte[1];				//           �p���t���O       
				public byte[] seqno = new byte[3];				//           ���ݽNO          
				public byte[] inpymd = new byte[4];				//           ���͓��t����     
				public byte[] ukeymd = new byte[8];				//           ��t���t����     
				public LN_Z[] ln_z = new LN_Z[ctBufLen];		// ײ�       24*5=120�޲�     
				public byte[] dummy = new byte[1863];			// ײ�       dummy            
	
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
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);				// ͯ�� TTC  ���敪         
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);				//           ÷�ļ��ݽ        
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);				//           ÷�Ē�           
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);			//           �d���敪         
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);				//           ��������         
					UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);			//           �⍇�������敪   
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);			//           �Ɩ�ID           
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			//           �߽ܰ��          
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);			//           �ް�ޮݔԍ�      
					UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);			//           �p���敪         
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);			//           ���ID           
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);			//           �g���ر          
					UoeCommonFnc.MemSet(ref kekka, 0x20, kekka.Length);			//     ͯ��1 �Ɩ���������     
					UoeCommonFnc.MemSet(ref keiflg, 0x20, keiflg.Length);		//           �p���t���O       
					UoeCommonFnc.MemSet(ref seqno, 0x20, seqno.Length);			//           ���ݽNO          
					UoeCommonFnc.MemSet(ref inpymd, 0x20, inpymd.Length);		//           ���͓��t����     
					UoeCommonFnc.MemSet(ref ukeymd, 0x20, ukeymd.Length);		//           ��t���t����     

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
            private const Int32 ctSndTelegramLen = 185; //���M�d���T�C�Y
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
			public TelegramEditAlloc0402()
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

					# region ���s�s�b��
					//�s�s�b
					// TTC   ���敪
					dn_z.jh[0] = 0x11;

					//÷�ļ��ݽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					dn_z.ts[0] = bBuf[2];
					dn_z.ts[1] = bBuf[3];

					//÷�Ē�
					dn_z.lg[0] = 0x00;
					dn_z.lg[1] = 0xb9;
					# endregion

					# region ���Ɩ��w�b�_�[����
					//���Ɩ��w�b�_�[����
					//ͯ��  �d���敪
					dn_z.dbkb[0] = 0x60;

					//��������
					dn_z.res[0] = 0x00;

					//�₢���킹�E�����敪
					UoeCommonFnc.MemCopy(ref dn_z.toikb, "1", dn_z.toikb.Length);

					//�Ɩ�ID
					UoeCommonFnc.MemSet(ref dn_z.gyoid, 0x20, dn_z.gyoid.Length);
					UoeCommonFnc.MemCopy(ref dn_z.gyoid, "UOE3", 4);

					//�߽ܰ��
					UoeCommonFnc.MemSet(ref dn_z.pass, 0x20, dn_z.pass.Length);

					//�ް�ޮݔԍ�
					UoeCommonFnc.MemSet(ref dn_z.vers, 0x20, dn_z.vers.Length);

					//�p���敪
					UoeCommonFnc.MemCopy(ref dn_z.keikb, "N", 1);

					//����ID
					UoeCommonFnc.MemSet(ref dn_z.hikid, 0x20, dn_z.hikid.Length);

					//�g���ر
					UoeCommonFnc.MemSet(ref dn_z.exten, 0x00, dn_z.exten.Length);

					//��������
					dn_z.kekka[0] = 0x00;

					//�p���׸�
					UoeCommonFnc.MemCopy(ref dn_z.keiflg, "0", 1);

					//���ݽNO
                    UoeCommonFnc.MemCopy(ref dn_z.seqno, String.Format("{0:D3}", _seq), dn_z.seqno.Length);

					//���͓��t
					dn_z.inpymd[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//��
					dn_z.inpymd[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//��
					dn_z.inpymd[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);//��
					dn_z.inpymd[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);//�b

					//��t���t
					UoeCommonFnc.MemSet(ref dn_z.ukeymd, 0x20, dn_z.ukeymd.Length);
					# endregion
				}

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
			public byte[] ToByteArray()
			{
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_z.jh, 0, dn_z.jh.Length);			// ͯ�� TTC  ���敪         
				ms.Write(dn_z.ts, 0, dn_z.ts.Length);			//           ÷�ļ��ݽ        
				ms.Write(dn_z.lg, 0, dn_z.lg.Length);			//           ÷�Ē�           
				ms.Write(dn_z.dbkb, 0, dn_z.dbkb.Length);		//           �d���敪         
				ms.Write(dn_z.res, 0, dn_z.res.Length);			//           ��������         
				ms.Write(dn_z.toikb, 0, dn_z.toikb.Length);		//           �⍇�������敪   
				ms.Write(dn_z.gyoid, 0, dn_z.gyoid.Length);		//           �Ɩ�ID           
				ms.Write(dn_z.pass, 0, dn_z.pass.Length);		//           �߽ܰ��          
				ms.Write(dn_z.vers, 0, dn_z.vers.Length);		//           �ް�ޮݔԍ�      
				ms.Write(dn_z.keikb, 0, dn_z.keikb.Length);		//           �p���敪         
				ms.Write(dn_z.hikid, 0, dn_z.hikid.Length);		//           ���ID           
				ms.Write(dn_z.exten, 0, dn_z.exten.Length);		//           �g���ر          
				ms.Write(dn_z.kekka, 0, dn_z.kekka.Length);		//     ͯ��1 �Ɩ���������     
				ms.Write(dn_z.keiflg, 0, dn_z.keiflg.Length);	//           �p���t���O       
				ms.Write(dn_z.seqno, 0, dn_z.seqno.Length);		//           ���ݽNO          
				ms.Write(dn_z.inpymd, 0, dn_z.inpymd.Length);	//           ���͓��t����     
				ms.Write(dn_z.ukeymd, 0, dn_z.ukeymd.Length);	//           ��t���t����     

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);	// ײ�      ���i�ԍ�          
				}

				//dummy
				ms.Write(dn_z.dummy, 0, dn_z.dummy.Length);		// ײ�       dummy            

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
