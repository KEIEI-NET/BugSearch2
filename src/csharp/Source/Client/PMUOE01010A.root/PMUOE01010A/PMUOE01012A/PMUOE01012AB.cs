//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d���M�ҏW���������i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d���M�ҏW���������i���Y�m�p�[�c�j
		/// </summary>
		/// <param name="uoeSndDtl"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0202(out List<UoeSndDtl> list, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			int maxCount = 0;
			message = "";
			list = new List<UoeSndDtl>();
			List<UoeSndDtl>  _list = new List<UoeSndDtl>();

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
				TelegramEditOrder0202 telegramEditOrder0202 = new TelegramEditOrder0202();
                telegramEditOrder0202.uOESupplier = uOESupplier;
				telegramEditOrder0202.Seq = 1;

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

				//�������d���쐬��
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = OrderView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditOrder0202.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0202.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0202.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditOrder0202.Clear();

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
					telegramEditOrder0202.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0202.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0202.SndTelegramLen;
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
				status = (int)EnumUoeConst.Status.ct_ERROR;
			}

			return status;
		}
		# endregion

		# region �t�n�d���M�d���쐬���������i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d���M�d���쐬���������i���Y�m�p�[�c�j
		/// </summary>
		public class TelegramEditOrder0202
		{
			# region �o�l�V�\�[�X
			///*-- �d���̈�...�{��...���� -------------------------------------------*/
			//										/*-- �d���̈�...ײ�...���� ----*/
			//struct	LN_H {							/* 18�޲�                      */
			//	char	hb[12];						/* ײ�      ���i�ԍ�           */
			//	char	hasu[5];					/*          ����               */
			//	char	bo;							/*          B/O�敪            */
			//};

			//struct	DN_HAC 							/*                             */
			//	{
			//	char	jh;							/* ͯ�� TTC  ���敪          */
			//	char	ts    [ 2];					/*           ÷�ļ��ݽ         */
			//	char	lg    [ 2];					/*           ÷�Ē�            */
			//	char	dbkb;						/*           �d���敪          */
			//	char	res;						/*           ��������          */
			//	char	toikb;						/*           �⍇�������敪    */
			//	char	gyoid [12];					/*           �Ɩ�ID            */
			//	char	pass  [ 6];					/*           �߽ܰ��           */
			//	char	vers  [ 3];					/*           �ް�ޮݔԍ�       */
			//	char	keikb;						/*           �p���敪          */
			//	char	hikid [ 3];					/*           ����ID            */
			//	char	exten [15];					/*           �g���ر           */
			//	char	syocd [ 2];					/*           ��������          */
			//	char	wsuser[ 6];					/*           �[���Ή�հ�ް���� */
			//	char	wsseq [ 2];					/*           �[��SEQ�          */
			//	char	dhms  [ 8];					/*           ���M���� DDHHMMSS */
			//	char	saikb [ 6];					/*           �đ��敪          */
			//	char	urikyo[ 3];					/*           ���㋒�_          */
			//	char	usercd[ 6];					/*      ͯ�� հ�ް����         */
			//	char	toricd[ 6];					/*           ����溰��        */
			//	char	nhkb;						/*           �[�i�敪          */
			//	char	irai  [ 2];					/*           �˗��҃R�[�h      */
			//	char	sitkyo[ 3];					/*           �w�苒�_          */
			//	char	bin   [ 1];					/*           ��                */
			//	char	rem1   [10];				/*           �ϰ�1             */
			//	char	rem2   [10];				/*           �ϰ�2             */
			//	struct	LN_H	ln_h[4];			/* ײ�                         */
			//	char	lstkb;						/* �ŏI�d���敪                */
			//	char	dummy[1861];				/* ײ�       dummy             */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 4;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 4;	//���׍s��
            private const Int32 ctSndTelegramLen = 191; //���M�d���T�C�Y
			# endregion

			# region Private Members
			//�����d��
			private byte[] jh = new byte[1];				/* ͯ�� TTC  ���敪          */
			private byte[] ts = new byte[2];				/*           ÷�ļ��ݽ         */
			private byte[] lg = new byte[2];				/*           ÷�Ē�            */
			private byte[] dbkb = new byte[1];				/*           �d���敪          */
			private byte[] res = new byte[1];				/*           ��������          */
			private byte[] toikb = new byte[1];				/*           �⍇�������敪    */
			private byte[] gyoid = new byte[12];			/*           �Ɩ�ID            */
			private byte[] pass = new byte[6];				/*           �߽ܰ��           */
			private byte[] vers = new byte[3];				/*           �ް�ޮݔԍ�       */
			private byte[] keikb = new byte[1];				/*           �p���敪          */
			private byte[] hikid = new byte[3];				/*           ����ID            */
			private byte[] exten = new byte[15];			/*           �g���ر           */

			private byte[] syocd = new byte[2];				/*           ��������          */
			private byte[] wsuser = new byte[6];			/*           �[���Ή�հ�ް���� */
			private byte[] wsseq = new byte[2];				/*           �[��SEQ�          */
			private byte[] dhms = new byte[8];				/*           ���M���� DDHHMMSS */
			private byte[] saikb = new byte[6];				/*           �đ��敪          */
			private byte[] urikyo = new byte[3];			/*           ���㋒�_          */

			private byte[] usercd = new byte[6];			/*      ͯ�� հ�ް����         */
			private byte[] toricd = new byte[6];			/*           ����溰��        */
			private byte[] nhkb = new byte[1];				/*           �[�i�敪          */
			private byte[] irai = new byte[2];				/*           �˗��҃R�[�h      */
			private byte[] sitkyo = new byte[3];			/*           �w�苒�_          */
			private byte[] bin = new byte[1];				/*           ��                */
			private byte[] rem1 = new byte[10];				/*           �ϰ�1             */
			private byte[] rem2 = new byte[10];				/*           �ϰ�2             */

			private byte[][] hb = new byte[ctBufLen][];		/* ײ�      ���i�ԍ�           */
			private byte[][] hasu = new byte[ctBufLen][];	/*          ����               */
			private byte[][] bo = new byte[ctBufLen][];		/*          B/O�敪            */

			private byte[] lstkb = new byte[1];				/* �ŏI�d���敪                */
			private byte[] dummy = new byte[1861];			/* ײ�       dummy             */

			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditOrder0202()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//�i��
					hasu[i] = new byte[5];	//����
					bo[i] = new byte[1];	//̫۰����
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			/* ͯ�� TTC  ���敪          */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			/*           ÷�ļ��ݽ         */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			/*           ÷�Ē�            */
				UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);		/*           �d���敪          */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			/*           ��������          */
				UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);		/*           �⍇�������敪    */
				UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);		/*           �Ɩ�ID            */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		/*           �߽ܰ��           */
				UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);		/*           �ް�ޮݔԍ�       */
				UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);		/*           �p���敪          */
				UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);		/*           ����ID            */
				UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);		/*           �g���ر           */

				//�Ɩ��w�b�_�[��
				UoeCommonFnc.MemSet(ref syocd, 0x20, syocd.Length);		/*           ��������          */
				UoeCommonFnc.MemSet(ref wsuser, 0x20, wsuser.Length);	/*           �[���Ή�հ�ް���� */
				UoeCommonFnc.MemSet(ref wsseq, 0x20, wsseq.Length);		/*           �[��SEQ�          */
				UoeCommonFnc.MemSet(ref dhms, 0x20, dhms.Length);		/*           ���M���� DDHHMMSS */
				UoeCommonFnc.MemSet(ref saikb, 0x20, saikb.Length);		/*           �đ��敪          */
				UoeCommonFnc.MemSet(ref urikyo, 0x20, urikyo.Length);	/*           ���㋒�_          */

				//�w�b�_�[��
				UoeCommonFnc.MemSet(ref usercd, 0x20, usercd.Length);	/*      ͯ�� հ�ް����         */
				UoeCommonFnc.MemSet(ref toricd, 0x20, toricd.Length);	/*           ����溰��        */
				UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		/*           �[�i�敪          */
				UoeCommonFnc.MemSet(ref irai, 0x20, irai.Length);		/*           �˗��҃R�[�h      */
				UoeCommonFnc.MemSet(ref sitkyo, 0x20, sitkyo.Length);	/*           �w�苒�_          */
				UoeCommonFnc.MemSet(ref bin, 0x20, bin.Length);			/*           ��                */
				UoeCommonFnc.MemSet(ref rem1, 0x20, rem1.Length);		/*           �ϰ�1             */
				UoeCommonFnc.MemSet(ref rem2, 0x20, rem2.Length);		/*           �ϰ�2             */

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		/* ײ�      ���i�ԍ�           */
					UoeCommonFnc.MemSet(ref hasu[i], 0x20, hasu[i].Length);	/*          ����               */
					UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);		/*          B/O�敪            */
				}
				UoeCommonFnc.MemSet(ref lstkb, 0x20, lstkb.Length);		/* �ŏI�d���敪                */

				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);		/* ײ�       dummy             */
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
					jh[0] = 0x11;

					// ÷�ļ��ݽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					ts[0] = bBuf[2];
					ts[1] = bBuf[3];

					// ÷�Ē�
					lg[0] = 0x00;
					lg[1] = 0xbf;

					// �d���敪
					dbkb[0] = 0x60;

					// ��������
					res[0] = 0x00;

					// �⍇�������敪
					UoeCommonFnc.MemCopy(ref toikb, "1", toikb.Length);

					// �Ɩ�ID
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);

					// �߽ܰ��
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);

					// �ް�ޮݔԍ�
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);

					// �p���敪
					UoeCommonFnc.MemCopy(ref keikb, "N", keikb.Length);

					// ����ID
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);

					// �g���ر
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);
					# endregion

					# region ���Ɩ��w�b�_�[����
					//�Ɩ��w�b�_�[��
					// ��������
					UoeCommonFnc.MemCopy(ref syocd, "Z1", syocd.Length);

					// �[���Ή�հ�ް����
                    UoeCommonFnc.MemCopy(ref wsuser, uOESupplier.UOETerminalCd, wsuser.Length);
					
					// �[��SEQ
					UoeCommonFnc.MemCopy(ref wsseq, "01", wsseq.Length);

					// ���M���� DDHHMMSS
					byte[] dhmsByte = UoeCommonFnc.GetByteAryDateTime();
					UoeCommonFnc.MemCopy(ref dhms, ref dhmsByte, dhms.Length);

					// �đ��敪
					UoeCommonFnc.MemSet(ref saikb, 0x20, saikb.Length);

					// ���㋒�_
					UoeCommonFnc.MemCopy(ref urikyo, uOESupplier.UOESalSectCd, urikyo.Length);
					# endregion

					# region ���w�b�_�[����
					// �w�b�_�[��
					// ͯ�� հ�ް����
                    UoeCommonFnc.MemCopy(ref usercd, uOESupplier.UOETerminalCd, usercd.Length);

					// ����溰��
                    UoeCommonFnc.MemCopy(ref toricd, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode], toricd.Length);

					// �[�i�敪
                    UoeCommonFnc.MemCopy(ref nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], nhkb.Length);

					// �˗��҃R�[�h
                    UoeCommonFnc.MemCopy(ref irai, UoeCommonFnc.GetUnderString((string)dr[OrderSndRcvJnlSchema.ct_Col_EmployeeCode], irai.Length), irai.Length);

					// �w�苒�_
					UoeCommonFnc.MemCopy(ref sitkyo, UoeCommonFnc.GetUpperString((string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], sitkyo.Length), sitkyo.Length);

					// ��
					UoeCommonFnc.MemSet(ref bin, 0x20, bin.Length);

					// �ϰ�1
					UoeCommonFnc.MemCopy(ref rem1, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], rem1.Length);

					// �ϰ�2
					UoeCommonFnc.MemCopy(ref rem2, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark2], rem2.Length);

					// �ŏI�d���敪
					UoeCommonFnc.MemSet(ref lstkb, 0x20, lstkb.Length);
					# endregion
				}

				# region �����ו���
				//�����ו���
				if (_ln < ctDetailLen)
				{
					//�i��
					UoeCommonFnc.MemCopy(ref hb[_ln], (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], hb[_ln].Length);

					//����
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref hasu[_ln], String.Format("{0:D5}", (int)hsuDouble), hasu[_ln].Length);

					//�t�H���[�R�[�h
					UoeCommonFnc.MemCopy(ref bo[_ln], (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], bo[_ln].Length);

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
				ms.Write(jh, 0, jh.Length);			/* ͯ�� TTC  ���敪          */
				ms.Write(ts, 0, ts.Length);			/*           ÷�ļ��ݽ         */
				ms.Write(lg, 0, lg.Length);			/*           ÷�Ē�            */
				ms.Write(dbkb, 0, dbkb.Length);		/*           �d���敪          */
				ms.Write(res, 0, res.Length);		/*           ��������          */
				ms.Write(toikb, 0, toikb.Length);	/*           �⍇�������敪    */
				ms.Write(gyoid, 0, gyoid.Length);	/*           �Ɩ�ID            */
				ms.Write(pass, 0, pass.Length);		/*           �߽ܰ��           */
				ms.Write(vers, 0, vers.Length);		/*           �ް�ޮݔԍ�       */
				ms.Write(keikb, 0, keikb.Length);	/*           �p���敪          */
				ms.Write(hikid, 0, hikid.Length);	/*           ����ID            */
				ms.Write(exten, 0, exten.Length);	/*           �g���ر           */

				//�Ɩ��w�b�_�[��
				ms.Write(syocd, 0, syocd.Length);	/*           ��������          */
				ms.Write(wsuser, 0, wsuser.Length);	/*           �[���Ή�հ�ް���� */
				ms.Write(wsseq, 0, wsseq.Length);	/*           �[��SEQ�          */
				ms.Write(dhms, 0, dhms.Length);		/*           ���M���� DDHHMMSS */
				ms.Write(saikb, 0, saikb.Length);	/*           �đ��敪          */
				ms.Write(urikyo, 0, urikyo.Length);	/*           ���㋒�_          */

				//�w�b�_�[��
				ms.Write(usercd, 0, usercd.Length);	/*      ͯ�� հ�ް����         */
				ms.Write(toricd, 0, toricd.Length);	/*           ����溰��        */
				ms.Write(nhkb, 0, nhkb.Length);		/*           �[�i�敪          */
				ms.Write(irai, 0, irai.Length);		/*           �˗��҃R�[�h      */
				ms.Write(sitkyo, 0, sitkyo.Length);	/*           �w�苒�_          */
				ms.Write(bin, 0, bin.Length);		/*           ��                */
				ms.Write(rem1, 0, rem1.Length);		/*           �ϰ�1             */
				ms.Write(rem2, 0, rem2.Length);		/*           �ϰ�2             */

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);		/* ײ�      ���i�ԍ�           */
					ms.Write(hasu[i], 0, hasu[i].Length);	/*          ����               */
					ms.Write(bo[i], 0, bo[i].Length);		/*          B/O�敪            */
				}
				ms.Write(lstkb, 0, lstkb.Length);	/* �ŏI�d���敪                */

				//dummy
				ms.Write(dummy, 0, dummy.Length);	/* ײ�       dummy             */

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
