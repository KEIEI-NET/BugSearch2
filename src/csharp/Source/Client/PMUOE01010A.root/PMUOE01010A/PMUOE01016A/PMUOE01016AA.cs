//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�i�z���_�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�i�z���_�j�A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10501071-00 �쐬�S�� : ���� �T��
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
	/// �t�n�d���M�ҏW�i�z���_�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�i�z���_�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndEdit0501Acs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit0501Acs()
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
		private const string MESSAGE_ERROR02 = "����M�i�m�k���������i�z���_�j��������܂���B";
		private const string MESSAGE_ERROR03 = "����M�i�m�k�����ρ��i�z���_�j��������܂���B";
		private const string MESSAGE_ERROR04 = "����M�i�m�k���݌Ɂ��i�z���_�j��������܂���B";

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

		# region �t�n�d���M�ҏW�i�z���_�j
		/// <summary>
		/// �t�n�d���M�ҏW�i�z���_�j
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit0501(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
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
							status = writeUOESNDEditOrder0501(out _uoeSndDtlList, out message);
							break;
						}
					//����
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							status = writeUOESNDEditEstm0501(out _uoeSndDtlList, out message);
							break;
						}
					//�݌�
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc0501(out _uoeSndDtlList, out message);
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
