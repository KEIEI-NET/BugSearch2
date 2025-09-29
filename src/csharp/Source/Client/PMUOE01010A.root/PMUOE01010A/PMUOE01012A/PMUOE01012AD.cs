//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0202Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d���M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0202(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc0202 telegramEditAlloc0202 = new TelegramEditAlloc0202();
                telegramEditAlloc0202.uOESupplier = uOESupplier;
                telegramEditAlloc0202.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�

				//���J�Ǔd���쐬��
				TelegramEditOpenClose0202 telegramEditOpenClose0202 = new TelegramEditOpenClose0202();
                telegramEditOpenClose0202.uOESupplier = uOESupplier;
                
                //�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0202.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0202.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditAlloc0202.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0202.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0202.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditAlloc0202.Clear();

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
					telegramEditAlloc0202.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0202.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0202.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//���Ǔd���쐬��
				//�t�n�d���M�ҏW���ʃN���X�̏�����
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//���M�d��(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0202.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0202.SndTelegramLen;

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

		# region �t�n�d���M�d���쐬���݌Ɂ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d���M�d���쐬���݌Ɂ��i���Y�m�p�[�c�j
		/// </summary>
		public class TelegramEditAlloc0202
		{
			# region �o�l�V�\�[�X
			///*-- �d���̈�...�{��...�݊m -------------------------------------------*/
			//										/*-- �d���̈�...ײ�...�݊m ----*/
			//struct	LN_Z {						/* 15�޲�                      */
			//	char	hb[12];						/* ײ�      �i��               */
			//};

			//struct	DN_ZAI {					/* 64 + 60 +1924 = 2048�޲�   */
			//	char	jh         ;				/* TTC   ���敪			  */
			//	char	ts     [ 2];		        /*       ÷�ļ��ݽ		  	  */
			//	char	lg     [ 2];	   	    	/* 		 ÷�Ē�				  */
			//	char	dbkb       ;				/* ͯ��  �d���敪			  */
			//	char	res        ;				/*       ��������			  */
			//	char	toikb      ;				/*       �₢���킹�E�����敪 */
			//	char	gyoid  [12];				/*       �Ɩ�ID			      */
			//	char	pass   [ 6];				/*       �Ɩ��߽ܰ��		  */
			//	char	vers   [ 3];				/*       �[��PG�ް�ޮ�		  */
			//	char	keikb      ;				/*       �p���敪			  */
			//	char	trid   [ 3];				/*       ���ID			      */
			//	char	exten  [15];				/*       �g���G���A			  */
			//	char	syocd  [ 2];				/* �����R�[�h				  */
			//	char	wsuser [ 6];				/* �[���Ή�հ�ް����		  */
			//	char	urikyo [ 3];				/* ���㋒�_					  */
			//	struct	LN_Z  z[ 5];				/* ײ�       15 * 4 =  75�޲� */
			//	char	dummy[1929];			/* DUMMY			          */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 5;	//���׍s��
            private const Int32 ctSndTelegramLen = 123; //���M�d���T�C�Y
			# endregion

			# region Private Members
			//�݌ɓd��
			private byte[] jh = new byte[1];				/* TTC   ���敪			  */
			private byte[] ts = new byte[2];		        /*       ÷�ļ��ݽ		  	  */
			private byte[] lg = new byte[2];	   	    	/* 		 ÷�Ē�				  */

			private byte[] dbkb = new byte[1];				/* ͯ��  �d���敪			  */
			private byte[] res = new byte[1];				/*       ��������			  */
			private byte[] toikb = new byte[1];				/*       �₢���킹�E�����敪 */
			private byte[] gyoid = new byte[12];			/*       �Ɩ�ID			      */
			private byte[] pass = new byte[6];				/*       �Ɩ��߽ܰ��		  */
			private byte[] vers = new byte[3];				/*       �[��PG�ް�ޮ�		  */
			private byte[] keikb = new byte[1];				/*       �p���敪			  */
			private byte[] trid = new byte[3];				/*       ���ID			      */
			private byte[] exten = new byte[15];			/*       �g���G���A			  */
			private byte[] syocd = new byte[2];				/* �����R�[�h				  */
			private byte[] wsuser = new byte[6];			/* �[���Ή�հ�ް����		  */
			private byte[] urikyo = new byte[3];			/* ���㋒�_					  */

			private byte[][] hb = new byte[ctBufLen][];		/* ײ�      �i��              */

			private byte[] dummy = new byte[1929];			/* DUMMY			          */

			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;
            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditAlloc0202()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//�i��
				}
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

				//�s�s�b
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);				/* TTC   ���敪			  */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);		        /*       ÷�ļ��ݽ		  	  */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);	   	    	/* 		 ÷�Ē�				  */
				
				UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);			/* ͯ��  �d���敪			  */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);				/*       ��������			  */
				UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);			/*       �₢���킹�E�����敪 */
				UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);			/*       �Ɩ�ID			      */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			/*       �Ɩ��߽ܰ��		  */
				UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);			/*       �[��PG�ް�ޮ�		  */
				UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);			/*       �p���敪			  */
				UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);			/*       ���ID			      */
				UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);			/*       �g���G���A			  */
				UoeCommonFnc.MemSet(ref syocd, 0x20, syocd.Length);			/* �����R�[�h				  */
				UoeCommonFnc.MemSet(ref wsuser, 0x20, wsuser.Length);		/* �[���Ή�հ�ް����		  */
				UoeCommonFnc.MemSet(ref urikyo, 0x20, urikyo.Length);		/* ���㋒�_					  */

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		/* ײ�      �i��               */
				}

				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			/* DUMMY			          */
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
					/* TTC   ���敪			  */
					jh[0] = 0x11;

					/*       ÷�ļ��ݽ		  	  */
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					ts[0] = bBuf[2];
					ts[1] = bBuf[3];

					/* 		 ÷�Ē�				  */
					lg[0] = 0x00;
					lg[1] = 0x7b;
					# endregion

					# region ���Ɩ��w�b�_�[����
					//���Ɩ��w�b�_�[����
					/* ͯ��  �d���敪			  */
					dbkb[0] = 0x60;

					/*       ��������			  */
					res[0] = 0x00;

					/*       �₢���킹�E�����敪 */
					UoeCommonFnc.MemCopy(ref toikb, "1", toikb.Length);

					/*       �Ɩ�ID			      */
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);

					/*       �Ɩ��߽ܰ��		  */
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);

					/*       �[��PG�ް�ޮ�		  */
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);

					/*       �p���敪			  */
					UoeCommonFnc.MemCopy(ref keikb, "N", keikb.Length);

					/*       ���ID			      */
					UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);

					/*       �g���G���A			  */
					UoeCommonFnc.MemSet(ref exten, 0x00, exten.Length);

					/* �����R�[�h				  */
					UoeCommonFnc.MemCopy(ref syocd, "Z2", syocd.Length);

					/* �[���Ή�հ�ް����		  */
					UoeCommonFnc.MemCopy(ref wsuser, (string)uOESupplier.UOEConnectUserId, wsuser.Length);

					/* ���㋒�_					  */
					UoeCommonFnc.MemCopy(ref urikyo, uOESupplier.UOESalSectCd, urikyo.Length);
					# endregion
				}

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref hb[_ln], (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], hb[_ln].Length);

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
				ms.Write(jh, 0, jh.Length);				/* TTC   ���敪			  */
				ms.Write(ts, 0, ts.Length);		        /*       ÷�ļ��ݽ		  	  */
				ms.Write(lg, 0, lg.Length);	   	    	/* 		 ÷�Ē�				  */

				ms.Write(dbkb, 0, dbkb.Length);			/* ͯ��  �d���敪			  */
				ms.Write(res, 0, res.Length);			/*       ��������			  */
				ms.Write(toikb, 0, toikb.Length);		/*       �₢���킹�E�����敪 */
				ms.Write(gyoid, 0, gyoid.Length);		/*       �Ɩ�ID			      */
				ms.Write(pass, 0, pass.Length);			/*       �Ɩ��߽ܰ��		  */
				ms.Write(vers, 0, vers.Length);			/*       �[��PG�ް�ޮ�		  */
				ms.Write(keikb, 0, keikb.Length);		/*       �p���敪			  */
				ms.Write(trid, 0, trid.Length);			/*       ���ID			      */
				ms.Write(exten, 0, exten.Length);		/*       �g���G���A			  */
				ms.Write(syocd, 0, syocd.Length);		/* �����R�[�h				  */
				ms.Write(wsuser, 0, wsuser.Length);		/* �[���Ή�հ�ް����		  */
				ms.Write(urikyo, 0, urikyo.Length);		/* ���㋒�_					  */

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);/* ײ�      �i��              */
				}

				//dummy
				ms.Write(dummy, 0, dummy.Length);	/* DUMMY			          */

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
