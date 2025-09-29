//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���������i�~�c�r�V�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���������i�~�c�r�V�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW���������i�~�c�r�V�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���������i�~�c�r�V�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0301Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���������i�~�c�r�V�j
		/// <summary>
		/// �t�n�d���M�ҏW���������i�~�c�r�V�j
		/// </summary>
		/// <param name="uoeSndDtl"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0301(out List<UoeSndDtl> list, out string message)
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
				TelegramEditOrder0301 telegramEditOrder0301 = new TelegramEditOrder0301();
                telegramEditOrder0301.uOESupplier = uOESupplier;	
				telegramEditOrder0301.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//���J�Ǔd���쐬��
				TelegramEditOpenClose0301 telegramEditOpenClose0301 = new TelegramEditOpenClose0301();
                telegramEditOpenClose0301.uOESupplier = uOESupplier;

				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0301.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0301.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditOrder0301.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0301.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0301.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditOrder0301.Clear();

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
					telegramEditOrder0301.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0301.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0301.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//���Ǔd���쐬��
				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0301.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0301.SndTelegramLen;

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

		# region �t�n�d���M�d���쐬���������i�~�c�r�V�j
		/// <summary>
		/// �t�n�d���M�d���쐬���������i�~�c�r�V�j
		/// </summary>
		public class TelegramEditOrder0301
		{
			# region �o�l�V�\�[�X
			///*-- �d���̈�...�{��...���� -------------------------------------------*/
			//									//-- �d���̈�...ײ�...���� --
			//struct	LN_H {					// 18�޲�                     
			//	char	hb[10];					// ײ�      ���i�ԍ�          
			//	char	hasu[4];				//          ����              
			//	char	bo;						//          B/O�敪           
			//	char	exten[3];				//          �g���ر           
			//};

												//-- �d���̈�...�{��...���� --
			//struct	DN_H {						// 97 + 54 +1897 = 2048       
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
			//
			//	char	errcd;					//     ͯ��1 �G���[�R�[�h     
			//	char	keiflg;					//           �p���t���O       
			//	char	seqno[3];				//           ���ݽNO          
			//	char	inpymd[4];				//           ���͓��t����     
			//	char	ukeymd[8];				//           ��t���t����     
			//	char	nhkb;					//     ͯ��2 �[�i�敪		  
			//	char	rem[8];					//           �ϰ�             
			//	char	sitkyo[2];				//           �w�苒�_         
			//	char	kinkb;					//           �ً}�敪         
			//	char	hdexten[20];			//           �g���ر          
			//	struct	LN_H	ln_h[3];		// ײ�       18*3=54�޲�      
			//	char	dummy[1897];			// ײ�       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 3;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 3;	//���׍s��
            private const Int32 ctSndTelegramLen = 151; //���M�d���T�C�Y
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{									// 18�޲�                     
				public byte[] hb = new byte[10];	// ײ�      ���i�ԍ�
				public byte[] hasu = new byte[4];	//          ����
				public byte[] bo = new byte[1];		//          B/O�敪
				public byte[] exten = new byte[3];	//          �g���ر

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);		// ײ�      ���i�ԍ�           
					UoeCommonFnc.MemSet(ref hasu, 0x20, hasu.Length);	//          ����               
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);		//          B/O�敪            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//          �g���ر
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
				public byte[] jh = new byte[1];			// ͯ�� TTC  ���敪          
				public byte[] ts = new byte[2];			//           ÷�ļ��ݽ         
				public byte[] lg = new byte[2];			//           ÷�Ē�            
				public byte[] dbkb = new byte[1];		//           �d���敪          
				public byte[] res = new byte[1];		//           ��������          
				public byte[] toikb = new byte[1];		//           �⍇�������敪    
				public byte[] gyoid = new byte[12];		//           �Ɩ�ID            
				public byte[] pass = new byte[6];		//           �߽ܰ��           
				public byte[] vers = new byte[3];		//           �ް�ޮݔԍ�       
				public byte[] keikb = new byte[1];		//           �p���敪          
				public byte[] hikid = new byte[3];		//           ����ID            
				public byte[] exten = new byte[15];		//           �g���ر           

				public byte[] errcd = new byte[1];		//     ͯ��1 �G���[�R�[�h     
				public byte[] keiflg = new byte[1];		//           �p���t���O       
				public byte[] seqno = new byte[3];		//           ���ݽNO          
				public byte[] inpymd = new byte[4];		//           ���͓��t����     
				public byte[] ukeymd = new byte[8];		//           ��t���t����     
				public byte[] nhkb = new byte[1];		//     ͯ��2 �[�i�敪		  
				public byte[] rem = new byte[8];		//           �ϰ�             
				public byte[] sitkyo = new byte[2];		//           �w�苒�_         
				public byte[] kinkb = new byte[1];		//           �ً}�敪         
				public byte[] hdexten = new byte[20];	//           �g���ر          
				public LN_H[] ln_h = new LN_H[ctBufLen];// ײ�       14*10=140�޲�
				public byte[] dummy = new byte[1897];	// ײ�       dummy             

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
					//�s�s�b
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			// ͯ�� TTC  ���敪          
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			//           ÷�ļ��ݽ         
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			//           ÷�Ē�            
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);		//           �d���敪          
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			//           ��������          
					UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);		//           �⍇�������敪    
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);		//           �Ɩ�ID            
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		//           �߽ܰ��           
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);		//           �ް�ޮݔԍ�       
					UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);		//           �p���敪          
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);		//           ����ID            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);		//           �g���ر           

					//�w�b�_�[��
					UoeCommonFnc.MemSet(ref errcd, 0x20, errcd.Length);		//     ͯ��1 �G���[�R�[�h     
					UoeCommonFnc.MemSet(ref keiflg, 0x20, keiflg.Length);	//           �p���t���O       
					UoeCommonFnc.MemSet(ref seqno, 0x20, seqno.Length);		//           ���ݽNO          
					UoeCommonFnc.MemSet(ref inpymd, 0x20, inpymd.Length);	//           ���͓��t����     
					UoeCommonFnc.MemSet(ref ukeymd, 0x20, ukeymd.Length);	//           ��t���t����     
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		//     ͯ��2 �[�i�敪		  
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);			//           �ϰ�             
					UoeCommonFnc.MemSet(ref sitkyo, 0x20, sitkyo.Length);	//           �w�苒�_         
					UoeCommonFnc.MemSet(ref kinkb, 0x20, kinkb.Length);		//           �ً}�敪         
					UoeCommonFnc.MemSet(ref hdexten, 0x20, hdexten.Length);	//           �g���ر          

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
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);
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
			public TelegramEditOrder0301()
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
			/// <param name="sec"></param>
			/// <param name="ln"></param>
			/// <param name="dr"></param>
			public void Telegram(DataRow dr)
			{
				//�s�s�b�� �Ɩ��w�b�_�[�� �w�b�_�[���쐬
				if (_ln == 0)
				{
					# region ���s�s�b����
					//�s�s�b��
					// ͯ�� TTC  ���敪
					dn_h.jh[0] = 0x11;

					//÷�ļ��ݽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					dn_h.ts[0] = bBuf[2];
					dn_h.ts[1] = bBuf[3];

					//÷�Ē�
					dn_h.lg[0] = 0x00;
					dn_h.lg[1] = 0x97;

					//�d���敪
					dn_h.dbkb[0] = 0x60;

					//��������
					dn_h.res[0] = 0x00;

					//�⍇�������敪
					UoeCommonFnc.MemCopy(ref dn_h.toikb, "1", dn_h.toikb.Length);

					//�Ɩ�ID
					UoeCommonFnc.MemSet(ref dn_h.gyoid, 0x20, dn_h.gyoid.Length);
					UoeCommonFnc.MemCopy(ref dn_h.gyoid, "UOE1", 4);

					//�߽ܰ��
					UoeCommonFnc.MemSet(ref dn_h.pass, 0x20, dn_h.pass.Length);

					//�ް�ޮݔԍ�
					UoeCommonFnc.MemSet(ref dn_h.vers, 0x20, dn_h.vers.Length);

					//�p���敪
					UoeCommonFnc.MemCopy(ref dn_h.keikb, "N", 1);

					//����ID
					UoeCommonFnc.MemSet(ref dn_h.hikid, 0x20, dn_h.hikid.Length);

					//�g���ر
					UoeCommonFnc.MemSet(ref dn_h.exten, 0x00, dn_h.exten.Length);
					# endregion

					# region ���w�b�_�[����
					//�w�b�_�[��

					
					//�װ����
					dn_h.errcd[0] = 0x00;

					//�p���׸�
					UoeCommonFnc.MemCopy(ref dn_h.keiflg, "1", 1);

					//���ݽNO
                    UoeCommonFnc.MemCopy(ref dn_h.seqno, String.Format("{0:D3}", _seq), 3);

					//���͓��t
					dn_h.inpymd[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//��
                    dn_h.inpymd[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//��
                    dn_h.inpymd[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);//��
                    dn_h.inpymd[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);//�b

					//��t���t
					UoeCommonFnc.MemSet(ref dn_h.ukeymd, 0x20, dn_h.ukeymd.Length);

					//�[�i�敪
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);

					//�ϰ�1
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//�w�苒�_
					UoeCommonFnc.MemCopy(ref dn_h.sitkyo, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], 1, dn_h.sitkyo.Length);

					//�ً}�敪
					UoeCommonFnc.MemCopy(ref dn_h.kinkb, uOESupplier.EmergencyDiv, dn_h.kinkb.Length);

					//�g���ر
					UoeCommonFnc.MemSet(ref dn_h.hdexten, 0x20, dn_h.hdexten.Length);
					# endregion
				}

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_h.ln_h[_ln].hb.Length);

					//����
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hasu, String.Format("{0:D4}", (int)hsuDouble), dn_h.ln_h[_ln].hasu.Length);

					//B/O�敪
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//�g���ر
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].exten, 0x20, dn_h.ln_h[_ln].exten.Length);

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

				//�s�s�b
				ms.Write(dn_h.jh, 0, dn_h.jh.Length);			// ͯ�� TTC  ���敪          
				ms.Write(dn_h.ts, 0, dn_h.ts.Length);			//           ÷�ļ��ݽ         
				ms.Write(dn_h.lg, 0, dn_h.lg.Length);			//           ÷�Ē�            
				ms.Write(dn_h.dbkb, 0, dn_h.dbkb.Length);		//           �d���敪          
				ms.Write(dn_h.res, 0, dn_h.res.Length);		//           ��������          
				ms.Write(dn_h.toikb, 0, dn_h.toikb.Length);	//           �⍇�������敪    
				ms.Write(dn_h.gyoid, 0, dn_h.gyoid.Length);	//           �Ɩ�ID            
				ms.Write(dn_h.pass, 0, dn_h.pass.Length);		//           �߽ܰ��           
				ms.Write(dn_h.vers, 0, dn_h.vers.Length);		//           �ް�ޮݔԍ�       
				ms.Write(dn_h.keikb, 0, dn_h.keikb.Length);	//           �p���敪          
				ms.Write(dn_h.hikid, 0, dn_h.hikid.Length);	//           ����ID            
				ms.Write(dn_h.exten, 0, dn_h.exten.Length);	//           �g���ر           

				//�w�b�_�[��
				ms.Write(dn_h.errcd, 0, dn_h.errcd.Length);	//     ͯ��1 �G���[�R�[�h     
				ms.Write(dn_h.keiflg, 0, dn_h.keiflg.Length);	//           �p���t���O       
				ms.Write(dn_h.seqno, 0, dn_h.seqno.Length);	//           ���ݽNO          
				ms.Write(dn_h.inpymd, 0, dn_h.inpymd.Length);	//           ���͓��t����     
				ms.Write(dn_h.ukeymd, 0, dn_h.ukeymd.Length);	//           ��t���t����     
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);		//     ͯ��2 �[�i�敪		  
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);		//           �ϰ�             
				ms.Write(dn_h.sitkyo, 0, dn_h.sitkyo.Length);	//           �w�苒�_         
				ms.Write(dn_h.kinkb, 0, dn_h.kinkb.Length);	//           �ً}�敪         
				ms.Write(dn_h.hdexten, 0, dn_h.hdexten.Length);//           �g���ر          

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);		// ײ�      ���i�ԍ�           */
					ms.Write(dn_h.ln_h[i].hasu, 0, dn_h.ln_h[i].hasu.Length);	//          ����               */
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);		//          B/O�敪            */
					ms.Write(dn_h.ln_h[i].exten, 0, dn_h.ln_h[i].exten.Length);//          �g���ر
				}

				//dummy
				ms.Write(dn_h.dummy, 0, dn_h.dummy.Length);	/* ײ�       dummy             */

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
