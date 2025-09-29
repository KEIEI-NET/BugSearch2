//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j
		/// <summary>
		/// �t�n�d���M�ҏW�����ρ��i�~�c�r�V�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditEstm0301(out List<UoeSndDtl> list, out string message)
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
				TelegramEditEstm0301 telegramEditEstm0301 = new TelegramEditEstm0301();
                telegramEditEstm0301.uOESupplier = uOESupplier;	
				telegramEditEstm0301.Seq = 1;

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

				//�����ϓd���쐬��
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = EstmtView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditEstm0301.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditEstm0301.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditEstm0301.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditEstm0301.Clear();

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
					telegramEditEstm0301.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditEstm0301.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditEstm0301.SndTelegramLen;
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
			}


			return status;
		}
		# endregion

		# region �t�n�d���M�d���쐬�����ρ��i�~�c�r�V�j
		/// <summary>
		/// �t�n�d���M�d���쐬�����ρ��i�~�c�r�V�j
		/// </summary>
		public class TelegramEditEstm0301
		{
			# region �o�l�V�\�[�X
			///*-- �d���̈�...�{��...���� -------------------------------------------
			//									//-- �d���̈�...ײ�...���� ---
			//struct	LN_M {					// 14�޲�                     
			//	char	hb[10];					// ײ�      ���i�ԍ�          
			//	char	msu[4];					//          ���ϐ�            
			//};
			//-- �d���̈�...�{��...���� --
			//struct	DN_M {					// 79+140+1829 = 2048�޲�     
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
			//	char	errcd;					//     ͯ��1 �G���[�R�[�h     
			//	char	keiflg;					//           �p���t���O       
			//	char	seqno[3];				//           ���ݽNO          
			//	char	inpymd[4];				//           ���͓��t����     
			//	char	ukeymd[8];				//           ��t���t����     
			//	char	reto[5];				//     ͯ��2 ���[�g�R�[�h     
			//	char	senc;					//           �I���R�[�h       
			//	char	rem[8];					//           �ϰ�	          
			//	struct	LN_M	ln_m[10];		// ײ�       14*10=140�޲�    
			//	char	dummy[1829];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// ���ϓd���̈恃���C����
			/// </summary>
			private class LN_M
			{
				public byte[] hb = new byte[10];	// ײ�      �i��
				public byte[] msu = new byte[4];	//          ����
				public LN_M()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);	// ײ�      �i��               
					UoeCommonFnc.MemSet(ref msu, 0x20, msu.Length);	//          ����               
				}
			}

			/// <summary>
			/// ���ϓd���̈恃�{�́�
			/// </summary>
			private class DN_M
			{
				public byte[] jh = new byte[1];				// ͯ�� TTC  ���敪         
				public byte[] ts = new byte[2];				//           ÷�ļ��ݽ        
				public byte[] lg = new byte[2];				//           ÷�Ē�           
				public byte[] dbkb = new byte[1];			//           �d���敪         
				public byte[] res = new byte[1];			//           ��������         
				public byte[] toikb = new byte[1];			//           �⍇�������敪   
				public byte[] gyoid = new byte[12];			//           �Ɩ�ID           
				public byte[] pass = new byte[6];			//           �߽ܰ��          
				public byte[] vers = new byte[3];			//           �ް�ޮݔԍ�      
				public byte[] keikb = new byte[1];			//           �p���敪         
				public byte[] hikid = new byte[3];			//           ���ID           
				public byte[] exten = new byte[15];			//           �g���ر          
				public byte[] errcd = new byte[1];			//     ͯ��1 �G���[�R�[�h     
				public byte[] keiflg = new byte[1];			//           �p���t���O       
				public byte[] seqno = new byte[3];			//           ���ݽNO          
				public byte[] inpymd = new byte[4];			//           ���͓��t����     
				public byte[] ukeymd = new byte[8];			//           ��t���t����     
				public byte[] reto = new byte[5];			//     ͯ��2 ���[�g�R�[�h     
				public byte[] senc = new byte[1];			//           �I���R�[�h       
				public byte[] rem = new byte[8];			//           �ϰ�	          
				public LN_M[] ln_m = new LN_M[ctBufLen];
				public byte[] dummy = new byte[1829];		// ײ�       dummy            

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
					UoeCommonFnc.MemSet(ref errcd, 0x20, errcd.Length);			//     ͯ��1 �G���[�R�[�h     
					UoeCommonFnc.MemSet(ref keiflg, 0x20, keiflg.Length);		//           �p���t���O       
					UoeCommonFnc.MemSet(ref seqno, 0x20, seqno.Length);			//           ���ݽNO          
					UoeCommonFnc.MemSet(ref inpymd, 0x20, inpymd.Length);		//           ���͓��t����     
					UoeCommonFnc.MemSet(ref ukeymd, 0x20, ukeymd.Length);		//           ��t���t����     
					UoeCommonFnc.MemSet(ref reto, 0x20, reto.Length);			//     ͯ��2 ���[�g�R�[�h     
					UoeCommonFnc.MemSet(ref senc, 0x20, senc.Length);			//           �I���R�[�h       
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);				//           �ϰ�	          

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
			private const Int32 ctBufLen = 10;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 10;	//���׍s��
            private const Int32 ctSndTelegramLen = 219; //���M�d���T�C�Y
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
			public TelegramEditEstm0301()
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
					# region ���s�s�b����
					//�s�s�b
					dn_m.jh[0] = 0x11;

					//÷�ļ��ݽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					dn_m.ts[0] = bBuf[2];
					dn_m.ts[1] = bBuf[3];
					
					//÷�Ē�
					dn_m.lg[0] = 0x00;
					dn_m.lg[1] = 0xdb;
					# endregion

					# region ���Ɩ��w�b�_�[����
					//�Ɩ��w�b�_�[��
					// ͯ��  �d���敪
					dn_m.dbkb[0] = 0x60;

					//��������
					dn_m.res[0] = 0x00;

					//�₢���킹�E�����敪
					UoeCommonFnc.MemCopy(ref dn_m.toikb, "1", dn_m.toikb.Length);

					//�Ɩ�ID
					UoeCommonFnc.MemSet(ref dn_m.gyoid, 0x20, dn_m.gyoid.Length);
					UoeCommonFnc.MemCopy(ref dn_m.gyoid, "UOE2", 4);

					//�Ɩ��߽ܰ��
					UoeCommonFnc.MemSet(ref dn_m.pass, 0x20, dn_m.pass.Length);

					//�[��PG�ް�ޮ�
					UoeCommonFnc.MemSet(ref dn_m.vers, 0x20, dn_m.vers.Length);

					//�p���敪
					UoeCommonFnc.MemCopy(ref dn_m.keikb, "N", dn_m.keikb.Length);

					//���ID
					UoeCommonFnc.MemSet(ref dn_m.hikid, 0x20, dn_m.hikid.Length);

					//�g���G���A
					UoeCommonFnc.MemSet(ref dn_m.exten, 0x00, dn_m.exten.Length);
					# endregion

					# region ���w�b�_�[����
					//�w�b�_�[��
					//�װ����
					dn_m.errcd[0] = 0x00;

					//�p���׸�
					UoeCommonFnc.MemCopy(ref dn_m.keiflg, "1", 1);

					//���ݽNO
                    UoeCommonFnc.MemCopy(ref dn_m.seqno, String.Format("{0:D3}", _seq), dn_m.seqno.Length);

					//���͓��t
					dn_m.inpymd[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//��
                    dn_m.inpymd[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//��
                    dn_m.inpymd[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);//��
                    dn_m.inpymd[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);//�b

					//��t���t
					UoeCommonFnc.MemSet(ref dn_m.ukeymd, 0x20, dn_m.ukeymd.Length);

					//���[�g
                    UoeCommonFnc.MemCopy(ref dn_m.reto, uOESupplier.UOEOrderRate, dn_m.reto.Length);

					//�I����
					//UoeCommonFnc.MemCopy(ref dn_m.senc, (string)dr[EstmtSndRcvJnlSchema.ct_Col_SelectCode], dn_m.senc.Length);
                    dn_m.senc[0] = 0x31;

					//���}�[�N
					UoeCommonFnc.MemCopy(ref dn_m.rem, (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1], dn_m.rem.Length);
					# endregion
				}

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref dn_m.ln_m[_ln].hb, (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_m.ln_m[_ln].hb.Length);

					//����
					double hsuDouble = (double)dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_m.ln_m[_ln].msu, String.Format("{0:D4}", (int)hsuDouble), dn_m.ln_m[_ln].msu.Length);

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

				ms.Write(dn_m.jh, 0, dn_m.jh.Length);				// ͯ�� TTC  ���敪         
				ms.Write(dn_m.ts, 0, dn_m.ts.Length);				//           ÷�ļ��ݽ        
				ms.Write(dn_m.lg, 0, dn_m.lg.Length);				//           ÷�Ē�           
				ms.Write(dn_m.dbkb, 0, dn_m.dbkb.Length);			//           �d���敪         
				ms.Write(dn_m.res, 0, dn_m.res.Length);			//           ��������         
				ms.Write(dn_m.toikb, 0, dn_m.toikb.Length);		//           �⍇�������敪   
				ms.Write(dn_m.gyoid, 0, dn_m.gyoid.Length);		//           �Ɩ�ID           
				ms.Write(dn_m.pass, 0, dn_m.pass.Length);			//           �߽ܰ��          
				ms.Write(dn_m.vers, 0, dn_m.vers.Length);			//           �ް�ޮݔԍ�      
				ms.Write(dn_m.keikb, 0, dn_m.keikb.Length);		//           �p���敪         
				ms.Write(dn_m.hikid, 0, dn_m.hikid.Length);		//           ���ID           
				ms.Write(dn_m.exten, 0, dn_m.exten.Length);		//           �g���ر          
				ms.Write(dn_m.errcd, 0, dn_m.errcd.Length);		//     ͯ��1 �G���[�R�[�h     
				ms.Write(dn_m.keiflg, 0, dn_m.keiflg.Length);		//           �p���t���O       
				ms.Write(dn_m.seqno, 0, dn_m.seqno.Length);		//           ���ݽNO          
				ms.Write(dn_m.inpymd, 0, dn_m.inpymd.Length);		//           ���͓��t����     
				ms.Write(dn_m.ukeymd, 0, dn_m.ukeymd.Length);		//           ��t���t����     
				ms.Write(dn_m.reto, 0, dn_m.reto.Length);			//     ͯ��2 ���[�g�R�[�h     
				ms.Write(dn_m.senc, 0, dn_m.senc.Length);			//           �I���R�[�h       
				ms.Write(dn_m.rem, 0, dn_m.rem.Length);			//           �ϰ�	          

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_m.ln_m[i].hb, 0, dn_m.ln_m[i].hb.Length);	// ײ�      �i��               
					ms.Write(dn_m.ln_m[i].msu, 0, dn_m.ln_m[i].msu.Length);	//          ����               
				}

				ms.Write(dn_m.dummy, 0, dn_m.dummy.Length);		// ײ�       dummy            

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
