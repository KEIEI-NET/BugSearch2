//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X���s��
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
	/// �t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0402Acs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit0402Acs()
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

		//�V�X�e���敪 0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[
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
		private const string MESSAGE_ERROR02 = "����M�i�m�k���������i�V�}�c�_�j��������܂���B";
		private const string MESSAGE_ERROR03 = "����M�i�m�k�����ρ��i�V�}�c�_�j��������܂���B";
		private const string MESSAGE_ERROR04 = "����M�i�m�k���݌Ɂ��i�V�}�c�_�j��������܂���B";

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

		# region �t�n�d���M�ҏW�i�V�}�c�_�j
		/// <summary>
		/// �t�n�d���M�ҏW�i�V�}�c�_�j
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit0402(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
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
							status = writeUOESNDEditOrder0402(out _uoeSndDtlList, out message);
							break;
						}
					//����
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							status = writeUOESNDEditEstm0402(out _uoeSndDtlList, out message);
							break;
						}
					//�݌�
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc0402(out _uoeSndDtlList, out message);
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

		# region �t�n�d���M�d���쐬���J��/�ǁ��i�V�}�c�_�j
		/// <summary>
		/// �t�n�d���M�d���쐬���J��/�ǁ��i�V�}�c�_�j
		/// </summary>
		public class TelegramEditOpenClose0402
		{
			# region �o�l�V�\�[�X
												//-- �d���̈�...�J�� �Ǘv�� --
			//struct	DN_KAI {				// 69 + 1924 = 2048�޲�       
			//	char	jh;						// ͯ�� TTC  ���敪         
			//	char	ts[2];					//           ÷�ļ��ݽ        
			//	char	lg[2];					//           ÷�Ē�           
			//	char	dbkb;					//           �d���敪         
			//	char	res;					//           ��������         
			//	char	aite[7];				//           ��������m�F���� 
			//	char	toho[7];				//           ���������m�F���� 
			//	char	ymdhms[6];				//           �ʐM�N���������b 
			//	char	pass[6];				//           �߽ܰ��          
			//	char	apid;					//           ���ع����ID      
			//	char	mode;					//           ���[�h           
			//	char	exten[34];				//           �g���ر          
			//	char	dummy[1979];			// ײ�       dummy            
			//};
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �J�ǁE�Ǔd���̈�
			/// </summary>
			private class DN_KAI
			{
				public byte[] jh = new byte[1];			// ͯ�� TTC  ���敪          
				public byte[] ts = new byte[2];			//           ÷�ļ��ݽ         
				public byte[] lg = new byte[2];			//           ÷�Ē�            
				public byte[] dbkb = new byte[1];		//           �d���敪          
				public byte[] res = new byte[1];		//           ��������          
				public byte[] aite = new byte[7];		//           ��������m�F����  
				public byte[] toho = new byte[7];		//           ���������m�F����  
				public byte[] ymdhms = new byte[6];		//           �ʐM�N���������b  
				public byte[] pass = new byte[6];		//           �߽ܰ��           
				public byte[] apid = new byte[1];		//           ���ع����ID       
				public byte[] mode = new byte[1];		//           ���[�h            
				public byte[] exten = new byte[34];		//           �g���ر           
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
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);		// ͯ�� TTC  ���敪          
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);		//           ÷�ļ��ݽ         
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);		//           ÷�Ē�            
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);	//           �d���敪          
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);		//           ��������          
					UoeCommonFnc.MemSet(ref aite, 0x20, aite.Length);	//           ��������m�F����  
					UoeCommonFnc.MemSet(ref toho, 0x20, toho.Length);	//           ���������m�F����  
					UoeCommonFnc.MemSet(ref ymdhms, 0x20, ymdhms.Length);//           �ʐM�N���������b  
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);	//           �߽ܰ��           
					UoeCommonFnc.MemSet(ref apid, 0x20, apid.Length);	//           ���ع����ID       
					UoeCommonFnc.MemSet(ref mode, 0x20, mode.Length);	//           ���[�h            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//           �g���ر           
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);	// ײ�       dummy             
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
			public TelegramEditOpenClose0402()
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
			public byte[] Telegram(int openMode)
			{
				//�N���A����
				Clear();

				//�f�[�^�ҏW����
				// ͯ�� TTC  ���敪
				dn_kai.jh[0] = 0x10;

				//�e�L�X�g�V�[�P���X
				UoeCommonFnc.MemSet(ref dn_kai.ts, 0x00, dn_kai.ts.Length);

				//÷�Ē�
				dn_kai.lg[0] = 0x00;
				dn_kai.lg[1] = 0x45;

				//�d���敪
				//�J��
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					dn_kai.dbkb[0] = 0x00;
				}
				//��
				else
				{
					dn_kai.dbkb[0] = 0x02;
				}

				//��������
				dn_kai.res[0] = 0x00;

				//��������m�F����
				UoeCommonFnc.MemCopy(ref dn_kai.aite, "UOE2   ", dn_kai.aite.Length);

				//���������m�F����
                UoeCommonFnc.MemCopy(ref dn_kai.toho, uOESupplier.UOETerminalCd, dn_kai.toho.Length);

				//�ʐM�N���������b
                dn_kai.ymdhms[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);   //�N
                dn_kai.ymdhms[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //��
                dn_kai.ymdhms[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //��
                dn_kai.ymdhms[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //��
                dn_kai.ymdhms[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);       //��
                dn_kai.ymdhms[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);       //�b

				//�߽ܰ��
				UoeCommonFnc.MemCopy(ref dn_kai.pass, uOESupplier.UOEConnectPassword, 3);

				//���ع����ID
				UoeCommonFnc.MemCopy(ref dn_kai.apid, "C", dn_kai.apid.Length);

				//���[�h
				UoeCommonFnc.MemCopy(ref dn_kai.mode, "C", dn_kai.mode.Length);

				//�g���ر
				UoeCommonFnc.MemSet(ref dn_kai.exten, 0x00, dn_kai.exten.Length);

				//�f�[�^�쐬����
				return (ToByteArray());
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

				ms.Write(dn_kai.jh, 0, dn_kai.jh.Length);			/* ͯ�� TTC  ���敪          */
				ms.Write(dn_kai.ts, 0, dn_kai.ts.Length);			/*           ÷�ļ��ݽ         */
				ms.Write(dn_kai.lg, 0, dn_kai.lg.Length);			/*           ÷�Ē�            */
				ms.Write(dn_kai.dbkb, 0, dn_kai.dbkb.Length);		/*           �d���敪          */
				ms.Write(dn_kai.res, 0, dn_kai.res.Length);			/*           ��������          */
				ms.Write(dn_kai.aite, 0, dn_kai.aite.Length);		/*           ��������m�F����  */
				ms.Write(dn_kai.toho, 0, dn_kai.toho.Length);		/*           ���������m�F����  */
				ms.Write(dn_kai.ymdhms, 0, dn_kai.ymdhms.Length);	/*           �ʐM�N���������b  */
				ms.Write(dn_kai.pass, 0, dn_kai.pass.Length);		/*           �߽ܰ��           */
				ms.Write(dn_kai.apid, 0, dn_kai.apid.Length);		/*           ���ع����ID       */
				ms.Write(dn_kai.mode, 0, dn_kai.mode.Length);		/*           ���[�h            */
				ms.Write(dn_kai.exten, 0, dn_kai.exten.Length);		/*           �g���ر           */
				ms.Write(dn_kai.dummy, 0, dn_kai.dummy.Length);		/* ײ�       dummy             */

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
