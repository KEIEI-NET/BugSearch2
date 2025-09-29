//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit1001Acs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit1001Acs()
		{
			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		//�t�n�d���M�ҏW����
		private List<UoeSndDtl> _uoeSndDtlList = new List<UoeSndDtl>();

		//��������N���X
		private UOESupplier	_uOESupplier;

		//�V�X�e���敪 0:����� 1:�`�� 2:���� 3:�ꊇ
		private int _systemDivCd;

		//�t�n�d����M�i�m�k�i�����j�u�h�d�v
		private DataView _orderView = new DataView();

		//�t�n�d����M�i�m�k�i���ρj�u�h�d�v
		private DataView _estmtView = new DataView();

		//�t�n�d����M�i�m�k�i�݊m�j�u�h�d�v
		private DataView _stockView = new DataView();

		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		//Sort
		public const string ctSortUpper = " ASC";   // �����o��
		public const string ctSortDownO = " DESC";  // �~���o��

		//��ƃR�[�h ������R�[�h �����ԍ� �����s�ԍ�
		public const string ctSortOrder = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortEstmt = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortStock = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";

		//�G���[���b�Z�[�W
		private const string MESSAGE_ERROR01 = "�Ɩ��敪�̃p�����[�^���Ⴂ�܂��B";
		private const string MESSAGE_ERROR02 = "����M�i�m�k���������i�D�ǁj��������܂���B";
		private const string MESSAGE_ERROR03 = "����M�i�m�k�����ρ��i�D�ǁj��������܂���B";
		private const string MESSAGE_ERROR04 = "����M�i�m�k���݌Ɂ��i�D�ǁj��������܂���B";

		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# region �t�n�d��������N���X
		/// <summary>
		/// �t�n�d��������N���X
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

		# region ��DataSet��
		/// <summary>
		/// �t�n�d����M�i�m�k�f�[�^�Z�b�g
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get
			{
				return this._uoeSndRcvJnlAcs.UoeJnlDataSet;
			}
		}
		# endregion

		# region ��DataTable��
		# region ������DataTable��
		/// <summary>
		/// ������DataTable��
		/// </summary>
		public DataTable OrderTable
		{
			get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
		}
		# endregion

		# region ���ρ�DataTable��
		/// <summary>
		/// ���ρ�DataTable��
		/// </summary>
		public DataTable EstmtTable
		{
			get { return UoeJnlDataSet.Tables[EstmtSndRcvJnlSchema.CT_EstmtSndRcvJnlDataTable]; }
		}
		# endregion

		# region �݌Ɂ�DataTable��
		/// <summary>
		/// �݌Ɂ�DataTable��
		/// </summary>
		public DataTable StockTable
		{
			get { return UoeJnlDataSet.Tables[StockSndRcvJnlSchema.CT_StockSndRcvJnlDataTable]; }
		}
		# endregion
		# endregion

		# region ��DataView��
		# region ������DataView��
		/// <summary>
		/// ������DataTable��
		/// </summary>
		public DataView OrderView
		{
			get { return this._orderView; }
		}
		# endregion

		# region ���ρ�DataView��
		/// <summary>
		/// ���ρ�DataTable��
		/// </summary>
		public DataView EstmtView
		{
			get { return this._estmtView; }
		}
		# endregion

		# region �݌Ɂ�DataView��
		/// <summary>
		/// �݌Ɂ�DataTable��
		/// </summary>
		public DataView StockView
		{
			get { return this._stockView; }
		}
		# endregion
		# endregion
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods

		# region �t�n�d���M�ҏW�i�D�ǁj
		/// <summary>
		/// �t�n�d���M�ҏW�i�D�ǁj
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit1001(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			//�t�n�d���M�ҏW���ʃN���X�̏�����
			list = new List<UoeSndDtl>();
			_uoeSndDtlList = new List<UoeSndDtl>();

			try
			{
				//��������̕ۑ�
				_uOESupplier = uOESupplier;

				//�V�X�e���敪�̕ۑ�
				_systemDivCd = systemDivCd;

				//�����[�g�����̌Ăяo���A�f�[�^�[�e�[�u���ւ̊i�[
				switch (businessCode)
				{
					//����
					case (int)EnumUoeConst.TerminalDiv.ct_Order:
						{
							status = writeUOESNDEditOrder1001(out _uoeSndDtlList, out message);
							break;
						}
					//����
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							break;
						}
					//�݌�
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc1001(out _uoeSndDtlList, out message);
							break;
						}
					//���̑�
					default:
						{
							message = MESSAGE_ERROR01;
							break;
						}
				}
				if ((status == (int)EnumUoeConst.Status.ct_NORMAL)
				&& (_uoeSndDtlList.Count > 0))
				{
					list = _uoeSndDtlList;
				}
			}
			catch (Exception ex)
			{
				status = (int)EnumUoeConst.Status.ct_ERROR;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d���M�d���쐬���J��/�ǁ��i�D�ǁj
		/// <summary>
		/// �t�n�d���M�d���쐬���J��/�ǁ��i�D�ǁj
		/// </summary>
		public class TelegramEditOpenClose1001
		{
			# region �d���̈�N���X
			/// <summary>
			/// �J�ǁE�Ǔd���̈�
			/// </summary>
			private class DN_KAI
			{
				public byte[] dbkb = new byte[2];		//�����敪
				public byte[] tcd = new byte[7];		//�[�����R�[�h
				public byte[] hcd = new byte[7];		//�z�X�g�R�[�h
				public byte[] pass = new byte[6];		//�p�X���[�h
				public byte[] ymd = new byte[6];		//���M���t
				public byte[] hms = new byte[6];		//���M����
				public byte[] res = new byte[2];		//����
				public byte[] hkb = new byte[1];		//�����敪
				public byte[] exten = new byte[32];		//���b�Z�[�W
				public byte[] dummy = new byte[1979];	// ײ�       dummy             

				/// <summary>
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_KAI()
				{
					Clear();
				}

				/// <summary>
				/// ������
				/// </summary>
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);	//�����敪
					UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);		//�[�����R�[�h
					UoeCommonFnc.MemSet(ref hcd, 0x20, hcd.Length);		//�z�X�g�R�[�h
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);	//�p�X���[�h
					UoeCommonFnc.MemSet(ref ymd, 0x20, ymd.Length);		//���M���t
					UoeCommonFnc.MemSet(ref hms, 0x20, hms.Length);		//���M����
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);		//����
					UoeCommonFnc.MemSet(ref hkb, 0x20, hkb.Length);		//�����敪
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//���b�Z�[�W
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);	//dummy
				}
			}
			# endregion

			# region Const Members
            private const Int32 ctSndTelegramLen = 69; //���M�d���T�C�Y
            # endregion

			# region Private Members
			private DN_KAI dn_kai = new DN_KAI();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramEditOpenClose1001()
			{
				Clear();
			}
			# endregion

			# region Properties
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
				dn_kai.Clear();
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dr"></param>
			/// <param name="mode"></param>
            public byte[] Telegram(int systemDivCd, int openMode)
			{
				//�N���A����
				Clear();

				//�����敪
				//�J��
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					dn_kai.dbkb[0] = 0x30;
					dn_kai.dbkb[1] = 0x31;
				}
				//��
				else
				{
					dn_kai.dbkb[0] = 0x39;
					dn_kai.dbkb[1] = 0x30;
				}

				//�[�����R�[�h
				UoeCommonFnc.MemCopy(ref dn_kai.tcd, uOESupplier.UOETerminalCd, dn_kai.tcd.Length);
				
				//�z�X�g�R�[�h
				UoeCommonFnc.MemCopy(ref dn_kai.hcd, uOESupplier.UOEHostCode, dn_kai.hcd.Length);
				
				//�p�X���[�h
				UoeCommonFnc.MemCopy(ref dn_kai.pass, uOESupplier.UOEConnectPassword, dn_kai.pass.Length);
				
				//���M���t
                

				UoeCommonFnc.MemCopy(ref dn_kai.ymd,
                                    String.Format("{0:D2}{1:D2}{2:D2}",
										(DateTime.Now.Year % 100),
                                        DateTime.Now.Month,
                                        DateTime.Now.Day),
									dn_kai.ymd.Length);
				
				//���M����
				UoeCommonFnc.MemCopy(ref dn_kai.hms,
                                    String.Format("{0:D2}{1:D2}{2:D2}",
                                        DateTime.Now.Hour,
                                        DateTime.Now.Minute,
                                        DateTime.Now.Second),
									dn_kai.hms.Length);
				
				//����
				//�J��
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					UoeCommonFnc.MemSet(ref dn_kai.res, 0x30, dn_kai.res.Length);
				}
				//��
				else
				{
					UoeCommonFnc.MemSet(ref dn_kai.res, 0x20, dn_kai.res.Length);
				}

				//�����敪
				//�J��
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					//1:����́A���� 3:�݌Ɉꊇ�A9:�`��
					switch(systemDivCd)
					{
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Input://�����
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Search://����
							dn_kai.hkb[0] = 0x31;
							break;
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Slip://�`��
							dn_kai.hkb[0] = 0x39;
							break;
						default://�ꊇ
							dn_kai.hkb[0] = 0x33;
							break;
					}
				}
				//��
				else
				{
					dn_kai.hkb[0] = 0x20;
				}

				//���b�Z�[�W
				UoeCommonFnc.MemSet(ref dn_kai.exten, 0x20, dn_kai.exten.Length);

				//�f�[�^�쐬����
				return (ToByteArray());
			}

            // HACK:�������d����M����
            /// <summary>
            /// �f�[�^�ҏW�����i�����d����M�����̎d���v���j
            /// </summary>
            /// <remarks>
            /// �d���̍\���͊J��/�ǂƓ����ł��B
            /// </remarks>
            /// <param name="receivingUOESupplier">�����d����M������UOE��������</param>
            /// <returns>���M�d��(JIS)</returns>
            public byte[] Telegram(EnumUoeConst.ReceivingUOESupplier receivingUOESupplier)
            {
                const string SPACE = " ";
                const byte SPACE_CODE = 0x20;

                // �N���A����
                Clear();

                // �d���敪/�����敪
                dn_kai.dbkb[0] = 0x36;
                dn_kai.dbkb[1] = 0x30;

                // �[�����R�[�h
                UoeCommonFnc.MemCopy(ref dn_kai.tcd, uOESupplier.UOETerminalCd, dn_kai.tcd.Length);

                // �z�X�g�R�[�h
                string hostCode = uOESupplier.UOEHostCode;
                if (receivingUOESupplier.Equals(EnumUoeConst.ReceivingUOESupplier.Meiji))
                {
                    hostCode = SPACE;   // �������̓X�y�[�X
                }
                UoeCommonFnc.MemCopy(ref dn_kai.hcd, hostCode, dn_kai.hcd.Length);

                // �p�X���[�h
                string password = uOESupplier.UOEConnectPassword;
                if (receivingUOESupplier.Equals(EnumUoeConst.ReceivingUOESupplier.Meiji))
                {
                    password = SPACE;   // �������̓X�y�[�X
                }
                UoeCommonFnc.MemCopy(ref dn_kai.pass, password, dn_kai.pass.Length);

                // ���M���t
                UoeCommonFnc.MemCopy(ref dn_kai.ymd, SPACE, dn_kai.ymd.Length);

                // ���M����
                UoeCommonFnc.MemCopy(ref dn_kai.hms, SPACE, dn_kai.hms.Length);

                // ����
                UoeCommonFnc.MemSet(ref dn_kai.res, SPACE_CODE, dn_kai.res.Length);

                // �����敪
                dn_kai.hkb[0] = SPACE_CODE;

                // ���b�Z�[�W
                UoeCommonFnc.MemSet(ref dn_kai.exten, SPACE_CODE, dn_kai.exten.Length);

                // �f�[�^�쐬����
                return ToByteArray();
            }
            // HACK:��

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

				ms.Write(dn_kai.dbkb, 0, dn_kai.dbkb.Length);	//�����敪
				ms.Write(dn_kai.tcd, 0, dn_kai.tcd.Length);		//�[�����R�[�h
				ms.Write(dn_kai.hcd, 0, dn_kai.hcd.Length);		//�z�X�g�R�[�h
				ms.Write(dn_kai.pass, 0, dn_kai.pass.Length);	//�p�X���[�h
				ms.Write(dn_kai.ymd, 0, dn_kai.ymd.Length);		//���M���t
				ms.Write(dn_kai.hms, 0, dn_kai.hms.Length);		//���M����
				ms.Write(dn_kai.res, 0, dn_kai.res.Length);		//����
				ms.Write(dn_kai.hkb, 0, dn_kai.hkb.Length);		//�����敪
				ms.Write(dn_kai.exten, 0, dn_kai.exten.Length);	//���b�Z�[�W
				ms.Write(dn_kai.dummy, 0, dn_kai.dummy.Length);	//dummy

				byte[] toByteArray = ms.ToArray();
				ms.Close();
				return (toByteArray);
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		# region �\�[�g�N�G���쐬����
		/// <summary>
		/// �\�[�g�N�G���쐬����
		/// </summary>
		/// <param name="para"></param>
		/// <returns></returns>
		private string GetSortQuerry(int businessCode)
		{
			string sortQuerry = "";

			switch (businessCode)
			{
				//����
				case (int)EnumUoeConst.TerminalDiv.ct_Order:
					{
						sortQuerry = ctSortOrder;
						break;
					}
				//����
				case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
					{
						sortQuerry = ctSortEstmt;
						break;
					}
				//�݌�
				case (int)EnumUoeConst.TerminalDiv.ct_Stock:
					{
						sortQuerry = ctSortStock;
						break;
					}
			}
			sortQuerry += ctSortUpper;
			return (sortQuerry);
		}
		# endregion

		# region �t�B���^�[�N�G���쐬����
        /// <summary>
        /// �t�B���^�[�N�G���쐬����
        /// </summary>
        /// <param name="businessCode">�Ɩ��敪</param>
        /// <param name="cd">������R�[�h</param>
        /// <returns>�t�B���^�[�N�G��</returns>
        private string GetRowFilterQuerry(int businessCode, Int32 cd)
        {
            string rowFilterQuerry = "";

            switch (businessCode)
            {
                //����
                case (int)EnumUoeConst.TerminalDiv.ct_Order:
                    {
                        rowFilterQuerry = string.Format("{0} = {1} AND {2} = {3}",
                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, cd,
                            OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process);
                        break;
                    }
                //����
                case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
                //�݌�
                case (int)EnumUoeConst.TerminalDiv.ct_Stock:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
            }
            return (rowFilterQuerry);
        }
        # endregion
		# endregion

	}
}
