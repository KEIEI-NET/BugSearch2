//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X���s��
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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0102Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d���M�ҏW���݌Ɂ��i�g���^�o�c�S�j
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0102(out List<UoeSndDtl> list, out string message)
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
                _stockView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock, uOESupplier.UOESupplierCd);
				maxCount = _stockView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//���ʊi�[����
				TelegramEditAlloc0102 telegramEditAlloc0102 = new TelegramEditAlloc0102();
                telegramEditAlloc0102.uOESupplier = uOESupplier;
				telegramEditAlloc0102.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//�w�b�_�[���ݒ�t���O 0:�ݒ肷�� 1:�ݒ肵�Ȃ�
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//�d�������̈�Ƀf�[�^������
					//�����ԍ����ύX���ꂽ
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc0102.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0102.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0102.Seq += 1;
					}
					//���w�b�_�[���ݒ菈����
					if (headerSet == 0)
					{
						headerSet = 1;

						//�d�����׃N���X�̃N���A
						telegramEditAlloc0102.Clear();

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
					telegramEditAlloc0102.Telegram(dr);
				}
				//�d�������̈�Ƀf�[�^������
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0102.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0102.SndTelegramLen;
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

		# region �t�n�d���M�d���쐬���݌Ɂ��i�g���^�o�c�S�j
		/// <summary>
		/// �t�n�d���M�d���쐬���݌Ɂ��i�g���^�o�c�S�j
		/// </summary>
		public class TelegramEditAlloc0102
		{
			# region �o�l�V�\�[�X
			//						/*-- �d���̈�...ײ�...�݊m --*/
			//struct	LN_Z {						/* 12�޲�                     */
			//	char	hb[12];					/* ײ�      �i��              */
			//};

			//						/*-- �d���̈�...�{��...�݊m --*/
			//struct	DN_Z {						/* 39 + 240 + 1769 = 2048�޲�   */
			//	char	jh;						/* ͯ�� TTC  ���敪         */
			//	char	ts[2];					/*           ÷�ļ��ݽ        */
			//	char	lg[2];					/*           ÷�Ē�           */
			//	char	tr[3];					/*      ID   ��ݻ޸��ݺ���    */
			//	char	res;					/*           ��������         */
			//	char	seq[3];					/*           seq�ԍ�          */
			//	char	acd[7];					/*           ����溰��       */
			//	char	tcd[7];					/*           ��������         */
			//	char	dttm[6];				/*           ���t�����        */
			//	char	pass[6];				/*           �߽ܰ��          */
			//	char	kflg;					/*           �p���׸�         */
			//	char	rem3[12];		 		/*           �ϰ�3            */
			//	struct	LN_Z	ln_z[20];		/* ײ�       12 * 20= 240�޲� */
			//	char	dummy[1757];			/* ײ�       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 20;		//���׃o�b�t�@�T�C�Y
			private const Int32 ctDetailLen = 6;	//���׍s��
            private const Int32 ctSndTelegramLen = 123; //���M�d���T�C�Y
            # endregion

			# region Private Members
			//�݌ɓd��

			private byte[] jh = new byte[1];		/* ͯ�� TTC  ���敪         */
			private byte[] ts = new byte[2];		/*           ÷�ļ��ݽ        */
			private byte[] lg = new byte[2];		/*           ÷�Ē�           */

			private byte[] tr = new byte[3];		/*      ID   ��ݻ޸��ݺ���    */
			private byte[] res = new byte[1];		/*           ��������         */
			private byte[] seq = new byte[3];		/*           seq�ԍ�          */
			private byte[] acd = new byte[7];		/*           ����溰��       */
			private byte[] tcd = new byte[7];		/*           ��������         */
			private byte[] dttm = new byte[6];		/*           ���� 		      */
			private byte[] pass = new byte[6];		/*           �߽ܰ��          */
			private byte[] kflg = new byte[1];		/*           �p���׸�         */

			private byte[] rem3 = new byte[12];		/*      ͯ�� �ϰ�3            */

			private byte[][] hb = new byte[ctBufLen][];	/* ײ�      �i��              */

			private byte[] dummy = new byte[1757];	/* ײ�       dummy            */

			//�ϐ�
			private Int32 _seq = 1;
			private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditAlloc0102()
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			//���敪
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			//�e�L�X�g�V�[�P���X
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			//�e�L�X�g��

				//�Ɩ��w�b�_�[��
				UoeCommonFnc.MemSet(ref tr, 0x20, tr.Length);			//�g�����U�N�V�����R�[�h
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			//��������
				UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);			//SEQ�ԍ�
				UoeCommonFnc.MemSet(ref acd, 0x20, acd.Length);			//�����R�[�h
				UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);			//�����R�[�h
				UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);		//����
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		//�p�X���[�h
				UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);		//�p���t���O

				//�w�b�_�[��
				UoeCommonFnc.MemSet(ref rem3, 0x20, rem3.Length);		//���}�[�N�R

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//�i��
				}
				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);		//dummy
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
					//���s�s�b��
					//���敪
					jh[0] = 0x31;

					//�e�L�X�g�V�[�P���X
					UoeCommonFnc.MemSet(ref ts, 0x00, ts.Length);

					//�e�L�X�g��
					lg[0] = 0x00;
					lg[1] = 0x7b;
					# endregion

					# region ���Ɩ��w�b�_�[����
					//���Ɩ��w�b�_�[����
					//�g�����U�N�V�����R�[�h
					UoeCommonFnc.MemCopy(ref tr, "I78", tr.Length);

					//��������
					res[0] = 0x00;

					//SEQ�ԍ�
                    UoeCommonFnc.MemCopy(ref seq, String.Format("{0:D3}", _seq), seq.Length);

					//�����R�[�h
					UoeCommonFnc.MemSet(ref acd, 0x30, acd.Length);

					//�����R�[�h
                    UoeCommonFnc.MemCopy(ref tcd, uOESupplier.UOETerminalCd, tcd.Length);

					//���t�����
					UoeCommonFnc.MemSet(ref dttm, 0x00, dttm.Length);

					//�p�X���[�h
					UoeCommonFnc.MemCopy(ref pass, uOESupplier.UOEConnectPassword, pass.Length);

					//�p���t���O
					kflg[0] = 0x30;
					# endregion

					# region ���w�b�_�[����
					//���w�b�_�[����
					//�ϰ�3
					UoeCommonFnc.MemSet(ref rem3, 0x00, rem3.Length);
					rem3[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);		//��
                    rem3[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	    //��
                    rem3[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//��
                    rem3[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//�b
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
			public byte[] ToByteArray(int cd)
			{
				//�p���Ȃ�
				if (cd == 1)
				{
					kflg[0] = 0x31;
				}
				//�p������
				else
				{
					kflg[0] = 0x30;
				}

				MemoryStream ms = new MemoryStream();
				//�s�s�b
				ms.Write(jh, 0, jh.Length);				//���敪
				ms.Write(ts, 0, ts.Length);				//�e�L�X�g�V�[�P���X
				ms.Write(lg, 0, lg.Length);				//�e�L�X�g��

				//�Ɩ��w�b�_�[��
				ms.Write(tr, 0, tr.Length);				//�g�����U�N�V�����R�[�h
				ms.Write(res, 0, res.Length);			//��������
				ms.Write(seq, 0, seq.Length);			//SEQ�ԍ�
				ms.Write(acd, 0, acd.Length);			//�����R�[�h
				ms.Write(tcd, 0, tcd.Length);			//�����R�[�h
				ms.Write(dttm, 0, dttm.Length);			//����
				ms.Write(pass, 0, pass.Length);			//�p�X���[�h
				ms.Write(kflg, 0, kflg.Length);			//�p���t���O

				//�w�b�_�[��
				ms.Write(rem3, 0, rem3.Length);			//���}�[�N�R

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);	//�i��
				}

				//dummy
				ms.Write(dummy, 0, dummy.Length);		//dummy

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
