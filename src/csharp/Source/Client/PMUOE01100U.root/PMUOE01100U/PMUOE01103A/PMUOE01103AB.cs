    //****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����͔��� �����l�擾�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����͔������s��
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

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d����͔����p�@�����l�擾�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d����͔����̏����l�擾�f�[�^������s���܂��B</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2007.04.17</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// </remarks>
	public class StockInputInitDataAcs
	{
        //�A�N�Z�X�N���X
		private static StockInputInitDataAcs _stockInputInitDataAcs;
        private StockInputInitialDataSet _dataSet;
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		private IEmployeeDB _iEmployeeDB;			// �]�ƈ���� �A�N�Z�X�N���X
		private UOEGuideNameAcs _uOEGuideNameAcs;	// UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X
		private SecInfoAcs _secInfoAcs;				// ���_ �A�N�Z�X�N���X
		private SecInfoSetAcs _secInfoSetAcs;		// ���_�ݒ� �A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs; 			// �]�ƈ���� �A�N�Z�X�N���X
        //private CustomerInfoAcs _customerInfoAcs;
        private UOEOrderDtlAcs _uOEOrderDtlAcs;     //�t�n�d�����f�[�^�A�N�Z�X�N���X

		//���_�ݒ�}�X�^
		private SecInfoSet _secInfoSet = null;

		//��ƃR�[�h
        public string _enterpriseCode = "";
		public string _sectionCode = "";

		//public�萔
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ���O�C�����_�R�[�h
        private string _ownSectionCode = "";

        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
        internal const string SECTIONCODE_ALL = "000000";
        private const string SECTIONNAME_ALL = "�S��";

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
        # region UOE������}�X�^�A�N�Z�X�N���X
        /// <summary>
        /// UOE������}�X�^�A�N�Z�X�N���X
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _uoeSndRcvJnlAcs.uOESupplierAcs; }
        }
		# endregion

        # region ����M�i�m�k�A�N�Z�X�N���X
        /// <summary>
        /// ����M�i�m�k�A�N�Z�X�N���X
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _uoeSndRcvJnlAcs; }
        }
		# endregion

		# region UOE���Аݒ�}�X�^
		/// <summary>
		/// UOE���Аݒ�}�X�^
		/// </summary>
		public UOESetting uOESetting
		{
			get { return this._uoeSndRcvJnlAcs.uOESetting; }
			set { this._uoeSndRcvJnlAcs.uOESetting = value; }
		}
		# endregion

		# region ���[���R�[�h
		/// <summary>
		/// ���[���R�[�h
		/// </summary>
		public int cashRegisterNo
		{
			get { return this._uoeSndRcvJnlAcs.cashRegisterNo; }
			set { this._uoeSndRcvJnlAcs.cashRegisterNo = value; }
		}
		# endregion

		# region ���i�}�X�^ �A�N�Z�X�N���X
		/// <summary>
		/// ���i�}�X�^ �A�N�Z�X�N���X
		/// </summary>
		public GoodsAcs _goodsAcs
		{
			get { return _uoeSndRcvJnlAcs.goodsAcs; }
			set { _uoeSndRcvJnlAcs.goodsAcs = value; }
		}
		# endregion

		# region UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X
		/// <summary>
		/// UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X
		/// </summary>
		public UOEGuideNameAcs uOEGuideNameAcs
		{
			get { return _uOEGuideNameAcs; }
			set { _uOEGuideNameAcs = value; }
		}
		# endregion

		# endregion

		#region �R���X�g���N�^
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private StockInputInitDataAcs()
		{
			// �ϐ�������
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
			
			this._dataSet = new StockInputInitialDataSet();
			this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
			this._uOEGuideNameAcs = new UOEGuideNameAcs();
			this._secInfoSetAcs = new SecInfoSetAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._employeeAcs = new EmployeeAcs();
            //this._customerInfoAcs = new CustomerInfoAcs();
        	this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();
		}

		/// <summary>
		/// �����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>�d�����͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X</returns>
		public static StockInputInitDataAcs GetInstance()
		{
			if (_stockInputInitDataAcs == null)
			{
				_stockInputInitDataAcs = new StockInputInitDataAcs();
			}

			return _stockInputInitDataAcs;
		}
        #endregion

		#region �����f�[�^�擾����
		/// <summary>
		/// �����f�[�^�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode,string sectionCode)
		{
            try
			{
                //�eDataSet�ɏ����lSet
				this._dataSet.Employee.BeginLoadData();
				this._dataSet.UOEGuideName.BeginLoadData();

                //-----------------------------------------------------------
                //�S�]�ƈ������擾
                //-----------------------------------------------------------
                object returnEmployee;
				EmployeeWork paraEmployee = new EmployeeWork();
				paraEmployee.EnterpriseCode = enterpriseCode;

				int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (returnEmployee is ArrayList)
					{
						foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
						{
							this.CacheEmployee(employeeWork);
						}
					}
				}

                //-----------------------------------------------------------
                //���_���擾
                //-----------------------------------------------------------
                SecInfoSet returnSecInfoSet = new SecInfoSet();
				status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_secInfoSet = returnSecInfoSet;
				}

                //-----------------------------------------------------------
                //UOE�K�C�h���̏����擾
                //-----------------------------------------------------------
                ArrayList rturnUOEGuideName;
				UOEGuideName uOEGuideName = new UOEGuideName();
				uOEGuideName.EnterpriseCode = _enterpriseCode;
                uOEGuideName.SectionCode = _sectionCode;

				status = this._uOEGuideNameAcs.SearchAll(out rturnUOEGuideName, uOEGuideName);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (rturnUOEGuideName is ArrayList)
					{
						foreach (UOEGuideName guideName in rturnUOEGuideName)
						{
							if (guideName.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
							{
								continue;
							}

							this.CacheUOEGuideName(guideName);
						}
					}
				}
			}
			finally
			{
				this._dataSet.Employee.EndLoadData();
				this._dataSet.UOEGuideName.EndLoadData();
			}

			return 0;
		}
        #endregion

        # region �d���ō����z�̎擾(double)
        /// <summary>
        /// �d���ō����z�̎擾(double)
        /// </summary>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            return (_uOEOrderDtlAcs.GetStockPriceTaxInc(targetPrice, taxationCode, stockCnsTaxFrcProcCd));
        }

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockCount">�d����</param>
        /// <param name="stockUnitPrice">�d���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
        /// <param name="taxFracProcCode">����Œ[�������敪</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�������</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            return(_uOEOrderDtlAcs.CalculationStockPrice(stockCount, stockUnitPrice, taxationCode, stockMoneyFrcProcCd, taxFracProcCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax));
        }

        #endregion

        # region �]�ƈ��}�X�^�N���X�̎擾
        /// <summary>
        /// �]�ƈ��}�X�^�N���X�̎擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            Employee employee = null;
            EmployeeDtl employeeDtl = null;

            try
            {
                int status = _employeeAcs.Read(out employee, out employeeDtl, enterpriseCode, employeeCode);
                if (status != 0)
                {
                    employeeDtl = null;
                }
            }
            catch (ConstraintException)
            {
                employeeDtl = null;
            }
            return (employeeDtl);
        }
        #endregion

        # region ���i�}�X�^ �A�N�Z�X�N���X���䏈��
        /// <summary>
		/// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
		/// </summary>
		/// <param name="goodsNo">�i��</param>
		/// <param name="makerCdList">�����Ώۂ̃��[�J�[�R�[�h���X�g</param>
		/// <param name="list">�������ʃN���X</param>
		/// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
		public int SearchPartsFromGoodsNoForMstInf(string goodsNo, List<Int32> makerCdList, out List<GoodsUnitData> list)
		{
           return(SearchPartsFromGoodsNoForMstInf(goodsNo, 0, makerCdList, out list));
		}

        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="makerCdList">�����Ώۂ̃��[�J�[�R�[�h���X�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int goodsMakerCd, List<Int32> makerCdList, out List<GoodsUnitData> list)
        {
			string msg = "";
			int status = 0;
			list = null;

			try
			{
				GoodsCndtn cndtn = new GoodsCndtn();

				cndtn.EnterpriseCode = _enterpriseCode;
				cndtn.SectionCode = _sectionCode;
				cndtn.GoodsNo = goodsNo;
                cndtn.GoodsMakerCd = goodsMakerCd;

                // �D��q�ɐݒ�
                List<string> SectWarehouseCd = new List<string>();
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd1);
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd2);
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd3);

                cndtn.ListPriorWarehouse = SectWarehouseCd;

                // �i�Ԍ���
                int serchMode = 0;
                if (makerCdList != null)
                {
                    if (makerCdList.Count != 0)
                    {
                        serchMode = 1;
                    }
                }

                if (serchMode == 0)
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, out list, out msg);
                }
                else
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, makerCdList, out list, out msg);
                }
            }
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
        }

		/// <summary>
		/// ���[�J�[���擾
		/// </summary>
		/// <param name="makerCode">���[�J�[�R�[�h</param>
		/// <param name="makerUMnt">���[�J�[���N���X</param>
		/// <returns></returns>
		public int GetMakerInf(int makerCode, out MakerUMnt makerUMnt)
		{
			int status = 0;
			makerUMnt = null;

			try
			{
				status = _goodsAcs.GetMaker(_enterpriseCode, makerCode, out makerUMnt);
			}
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
		}

		/// <summary>
		/// ���[�J�[���擾
		/// </summary>
		/// <param name="makerCode"></param>
		/// <returns></returns>
		public string GetName_FromMakerCode(int makerCode)
		{
			string makerName = "";
			MakerUMnt makerUMnt = null;
			try
			{
				int status = GetMakerInf(makerCode, out makerUMnt);
				if((status == 0) && (makerUMnt != null))
				{
					makerName = makerUMnt.MakerName;
				}
				else
				{
					makerName = "";
				}
			}
			catch (ConstraintException)
			{
				makerName = "";
			}
			return (makerName);
		}

		/// <summary>
		/// �a�k���擾
		/// </summary>
		/// <param name="makerCode">���[�J�[�R�[�h</param>
		/// <param name="makerUMnt">���[�J�[���N���X</param>
		/// <returns></returns>
		public int GetBLGoodsCdInf(int blGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			int status = 0;
			bLGoodsCdUMnt = null;

			try
			{
				status = _goodsAcs.GetBLGoodsCd(blGoodsCode, out bLGoodsCdUMnt);
			}
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
		}

		/// <summary>
		/// �a�k�R�[�h���擾
		/// </summary>
		/// <param name="makerCode"></param>
		/// <returns></returns>
		public string GetName_FromBLGoodsCd(int blGoodsCode)
		{
			string blGoodsName = "";
			BLGoodsCdUMnt bLGoodsCdUMnt = null;
			try
			{
				int status = GetBLGoodsCdInf(blGoodsCode, out bLGoodsCdUMnt);
				if ((status == 0) && (bLGoodsCdUMnt != null))
				{
					blGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
				}
				else
				{
					blGoodsName = "";
				}
			}
			catch (ConstraintException)
			{
				blGoodsName = "";
			}
			return (blGoodsName);
		}

        /// <summary>
        /// ���i�}�X�^�̌���
        /// </summary>
        /// <param name="list">���i�}�X�^���X�g</param>
        /// <returns>���i�}�X�^</returns>
        public GoodsPrice GetGoodsPrice_FromGoodsPriceList(List<GoodsPrice> list)
        {
            return(_goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, list));
        }

		/// <summary>
		/// ���C���q�ɂ̍݌ɏ��擾
		/// </summary>
		/// <param name="list">�݌ɏ�񃊃X�g</param>
        /// <param name="selectedWarehouseCode">�I��q�ɃR�[�h</param>
        /// <returns>�݌ɏ��</returns>
        public Stock GetStock_FromSecInfoSet(List<Stock> list, string selectedWarehouseCode)
		{
			string sectWarehouseCd = "";
			Stock returnStock = null;

			try
			{
                if (list == null)
                {
                    returnStock = new Stock();
                    return (returnStock);
                }

				for (int i = 0; (i < 4) && (returnStock == null); i++)
				{
					switch(i)
					{
                        //�I��q�ɂ̌���
                        case 0:
                            sectWarehouseCd = selectedWarehouseCode;
                            break;
                        //�D��q�ɇ@�̌���
                        case 1:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd1;
							break;
                        //�D��q�ɇA�̌���
                        case 2:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd2;
							break;
                        //�D��q�ɇB�̌���
                        case 3:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd3;
							break;
					}

                    if (sectWarehouseCd == null) continue;
					if (sectWarehouseCd.Trim() == "") continue;

					foreach (Stock stock in list)
					{
						if (stock.WarehouseCode.Trim() == sectWarehouseCd.Trim())
						{
							returnStock = stock;
							break;
						}
					}
				}
			}
			catch (ConstraintException)
			{
				returnStock = null;
			}
			if (returnStock == null)
			{
				returnStock = new Stock();
			}
			return (returnStock);
		}

		#endregion

		# region �]�ƈ��}�X�^�L���b�V�����䏈��
		/// <summary>
		/// �]�ƈ��}�X�^�L���b�V������
		/// </summary>
		/// <param name="employeeWork">�]�ƈ��}�X�^���[�N�N���X</param>
		internal void CacheEmployee(EmployeeWork employeeWork)
		{
			try
			{                
				_dataSet.Employee.AddEmployeeRow(this.RowFromUIData(employeeWork));
			}
			catch (ConstraintException)
			{
				StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeWork.EmployeeCode.Trim());
				this.SetRowFromUIData(ref row, employeeWork);
			}
		}

		/// <summary>
		/// �]�ƈ����̎擾����
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�]�ƈ�����</returns>
		public string GetName_FromEmployee(string employeeCode)
		{
			StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeCode.Trim());

			if (row == null)
			{
				return "";
			}
			else
			{
				return row.Name;
			}
		}

		/// <summary>
		/// �]�ƈ��}�X�^���[�N���]�ƈ��}�X�^�s�N���X�ݒ菈��
		/// </summary>
		/// <param name="row">�]�ƈ��}�X�^�s�N���X</param>
		/// <param name="employeeWork">�]�ƈ��}�X�^���[�N�N���X</param>
		internal void SetRowFromUIData(ref StockInputInitialDataSet.EmployeeRow row, EmployeeWork employeeWork)
		{
			// �]�ƈ��R�[�h
			row.EmployeeCode = employeeWork.EmployeeCode.Trim();

			// �]�ƈ�����
			row.Name = employeeWork.Name;
		}

		/// <summary>
		/// �]�ƈ��}�X�^���[�N�N���X���]�ƈ��}�X�^�s�N���X�ϊ�����
		/// </summary>
		/// <param name="employeeWork">�]�ƈ��}�X�^�s�N���X</param>
		/// <returns>�]�ƈ��}�X�^���[�N�^�N���X</returns>
		internal StockInputInitialDataSet.EmployeeRow RowFromUIData(EmployeeWork employeeWork)
		{
			StockInputInitialDataSet.EmployeeRow row = _dataSet.Employee.NewEmployeeRow();

			this.SetRowFromUIData(ref row, employeeWork);
			return row;
		}

		/// <summary>
		/// �]�ƈ����݃`�F�b�N
		/// </summary>
		/// <param name="sectionCode"></param>
		/// <param name="warehouseCode"></param>
		/// <returns></returns>
		public bool EmployeeExists(string employeeCode)
		{
			StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeCode.Trim());
			return (row != null);
		}

		# endregion

		# region UOE��������L���b�V�����䏈��
		/// <summary>
		/// UOE�����於�̎擾
		/// </summary>
		/// <param name="UOESupplierCd">UOE������R�[�h</param>
		/// <returns>UOE�����於��</returns>
		public string GetName_FromUOESupplier(int uOESupplierCd)
		{
			UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);

			if (uOESupplier == null)
			{
				return "";
			}
			else
			{
				return uOESupplier.UOESupplierName;
			}
		}

		/// <summary>
		/// UOE������N���X�擾
		/// </summary>
		/// <param name="uOESupplierCd">UOE������R�[�h</param>
		/// <returns>UOE������N���X</returns>
		public UOESupplier GetUOESupplier(int uOESupplierCd)
		{
			UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
			return (uOESupplier);
		}

		/// <summary>
		/// UOE�����摶�݃`�F�b�N
		/// </summary>
		/// <param name="uOESupplierCd">UOE������R�[�h</param>
		/// <returns></returns>
		public bool UOESupplierExists(int uOESupplierCd)
		{
			UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);
			return (uOESupplier != null);
		}
		# endregion

		# region UOE�K�C�h���̏��L���b�V�����䏈��
		/// <summary>
		/// UOE�K�C�h���̃L���b�V������
		/// </summary>
		/// <param name="uOEGuideName">UOE�K�C�h���̃N���X</param>
		internal void CacheUOEGuideName(UOEGuideName uOEGuideName)
		{
			try
			{
				_dataSet.UOEGuideName.AddUOEGuideNameRow(this.RowFromUIData(uOEGuideName));
			}
			catch (ConstraintException)
			{
				StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				uOEGuideName.UOEGuideDivCd, uOEGuideName.UOESupplierCd, uOEGuideName.UOEGuideCode.Trim()
				);
				this.SetRowFromUIData(ref row, uOEGuideName);
			}
		}

        /// <summary>
        /// UOE�K�C�h���̂̑��݃`�F�b�N���K�C�h�敪�E������E�K�C�h�R�[�h�w�聄
        /// </summary>
        /// <param name="UOEGuideDivCd">UOE�K�C�h�敪</param>
        /// <param name="UOESupplierCd">UOE������R�[�h</param>
        /// <param name="UOEGuideCode">UOE�K�C�h�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public bool UOEGuideExists(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
        {
            bool returnBool = false;

            try
            {
			    StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				    UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
			    );

                if (row == null)
                {
                    returnBool = false;
                }
                else
                {
                    returnBool = true;
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return(returnBool);
        }

		/// <summary>
		/// UOE�K�C�h���̎擾���K�C�h�敪�E������E�K�C�h�R�[�h�w�聄
		/// </summary>
		/// <param name="UOEGuideDivCd">UOE�K�C�h�敪</param>
		/// <param name="UOESupplierCd">UOE������R�[�h</param>
		/// <param name="UOEGuideCode">UOE�K�C�h�R�[�h</param>
		/// <returns>UOE�K�C�h����</returns>
		public string GetName_FromUOEGuideName(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
			);

			if (row == null)
			{
				return "";
			}
			else
			{
				return row.UOEGuideNm;
			}
		}

        /// <summary>
        /// UOE�K�C�h���̈ꗗ�擾���Ɩ��敪��
        /// </summary>
        /// <param name="UOEGuideDivCd"></param>
        /// <param name="uOESupplier"></param>
        /// <returns>UOE�K�C�h���̃N���X</returns>
        public List<UOEGuideName> GetBusinessCodeList_FromUOEGuideName(int UOEGuideDivCd, UOESupplier uOESupplier)
        {
            List<UOEGuideName> list = new List<UOEGuideName>();

            string[] nm = new string[] {"����", "����","�݌Ɋm�F"};

            try
			{
                string commAssemblyId = "";
                if (uOESupplier != null)
                {
                    commAssemblyId = uOESupplier.CommAssemblyId.Trim();
                }

                for (int i = 0; i < 3; i++)
                {
                    if ((commAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_1001)
                    && (i == 1))
                    {
                    }
                    else
                    {
                        UOEGuideName uOEGuideName = new UOEGuideName();
                        uOEGuideName.UOEGuideCode = String.Format("{0}", i+1);
                        uOEGuideName.UOEGuideNm = nm[i];
                        list.Add(uOEGuideName);
                    }
                }
            }
            catch (Exception)
            {
                list = new List<UOEGuideName>();
            }
            return (list);
        }

		/// <summary>
		/// UOE�K�C�h���̈ꗗ�擾���K�C�h�敪�E������E�K�C�h�R�[�h�w�聄
		/// </summary>
		/// <param name="UOEGuideDivCd"></param>
		/// <param name="UOESupplierCd"></param>
		/// <returns>UOE�K�C�h���̃N���X</returns>
		public List<UOEGuideName> GetList_FromUOEGuideName(int UOEGuideDivCd, int UOESupplierCd)
		{
			List<UOEGuideName> list = new List<UOEGuideName>();

			try
			{
				DataView dv = new DataView(this._dataSet.UOEGuideName);
				string filinf = "{0} = " + UOEGuideDivCd
						 + " AND {1} = " + UOESupplierCd;

				
				dv.RowFilter = String.Format(filinf,
								"UOEGuideDivCd",
								"UOESupplierCd");
				dv.Sort = "UOEGuideCode";

				//��DataRow �� �N���X���i�[����
				if (dv.Count > 0)
				{
					for (int i = 0; i < dv.Count; i++)
					{
						DataRow dr = dv[i].Row;
						UOEGuideName uOEGuideName = ToUOEGuideNameFromRow(ref dr);
						list.Add(uOEGuideName);
					}
				}
			}
			catch(Exception)
			{
				list = new List<UOEGuideName>();
			}
			return (list);
		}

		/// <summary>
		/// UOE�K�C�h���̃R�[�h�̏����\���l�擾
		/// </summary>
		/// <param name="list">UOE�K�C�h���̃��X�g</param>
		/// <param name="uOEGuideCode">UOE�K�C�h���̃R�[�h</param>
		/// <returns>UOE�K�C�h���̃R�[�h</returns>
		public string GetDefaultUOEGuideCode(List<UOEGuideName> list, string uOEGuideCode)
		{
			string defaultUOEGuideCode = "";

			if (list == null) return (defaultUOEGuideCode);
			if (list.Count == 0) return (defaultUOEGuideCode);

			defaultUOEGuideCode = list[0].UOEGuideCode.Trim();
			if (uOEGuideCode.Trim() != "")
			{
				foreach (UOEGuideName dtl in list)
				{
					if (dtl.UOEGuideCode.Trim() == uOEGuideCode.Trim())
					{
                        defaultUOEGuideCode = uOEGuideCode.Trim();
						break;
					}
				}
			}
			return (defaultUOEGuideCode);
		}

		/// <summary>
		/// ���[�U�[�K�C�h�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		public void SetUOEGuideNameComboEditor(out Infragistics.Win.ValueList sender, int UOEGuideDivCd, int UOESupplierCd)
		{
			sender = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem sec = new Infragistics.Win.ValueListItem();
			sec.Tag = 0;
			sec.DataValue = 0;
			sec.DisplayText = "";
			sender.ValueListItems.Add(sec);

			DataRow[] rows = this._dataSet.UOEGuideName.Select(string.Format("UOEGuideDivCd = {0} AND UOESupplierCd = {1}", UOEGuideDivCd, UOESupplierCd), "UOEGuideCode ASC");

			foreach (StockInputInitialDataSet.UOEGuideNameRow row in rows)
			{
				Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
				secInfoItem.Tag = row.UOEGuideCode;
				secInfoItem.DataValue = row.UOEGuideCode;
				secInfoItem.DisplayText = row.UOEGuideNm;
				sender.ValueListItems.Add(secInfoItem);
			}
		}

		/// <summary>
		/// ���[�J�[�K�C�h�R���{�G�f�B�^���X�g�ݒ菈��
		/// </summary>
		/// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		public void SetEnableOdrMakerCdComboEditor(out Infragistics.Win.ValueList sender, List<int> enableOdrMakerCd)
		{
			sender = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem sec = new Infragistics.Win.ValueListItem();
			sec.Tag = 0;
			sec.DataValue = 0;
			sec.DisplayText = "";
			sender.ValueListItems.Add(sec);

			foreach (int makerCode in enableOdrMakerCd)
			{
				Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
				secInfoItem.Tag = makerCode;
				secInfoItem.DataValue = makerCode;
				secInfoItem.DisplayText = GetName_FromMakerCode(makerCode);
				sender.ValueListItems.Add(secInfoItem);
			}
		}

		/// <summary>
		/// UOE�K�C�h���̃��[�N��UOE�K�C�h���̍s�N���X�ݒ菈��
		/// </summary>
		/// <param name="row">UOE������s�N���X</param>
		/// <returns>UOE�K�C�h���̃N���X</returns>
		internal UOEGuideName ToUOEGuideNameFromRow(ref DataRow row)
		{
			UOEGuideName uOEGuideName = new UOEGuideName();

			StockInputInitialDataSet.UOEGuideNameDataTable uOEGuideNameDataTable = this._dataSet.UOEGuideName;

			uOEGuideName.UOEGuideDivCd = (int)row[uOEGuideNameDataTable.UOEGuideDivCdColumn.ColumnName];	// UOE�K�C�h�敪
			uOEGuideName.UOESupplierCd = (int)row[uOEGuideNameDataTable.UOESupplierCdColumn.ColumnName];	// UOE������R�[�h
			uOEGuideName.UOEGuideCode = (string)row[uOEGuideNameDataTable.UOEGuideCodeColumn.ColumnName];	// UOE�K�C�h�R�[�h
			uOEGuideName.UOEGuideNm = (string)row[uOEGuideNameDataTable.UOEGuideNmColumn.ColumnName];		// UOE�K�C�h����

			return (uOEGuideName);
		}

		/// <summary>
		/// UOE�K�C�h���̃��[�N��UOE�K�C�h���̍s�N���X�ݒ菈��
		/// </summary>
		/// <param name="row">UOE�K�C�h���̍s�N���X</param>
		/// <param name="uOESupplier">UOE�K�C�h���̃N���X</param>
		internal void SetRowFromUIData(ref StockInputInitialDataSet.UOEGuideNameRow row, UOEGuideName uOEGuideName)
		{
			row.UOEGuideDivCd = uOEGuideName.UOEGuideDivCd; // UOE�K�C�h�敪
			row.UOESupplierCd = uOEGuideName.UOESupplierCd; // UOE������R�[�h
			row.UOEGuideCode = uOEGuideName.UOEGuideCode; // UOE�K�C�h�R�[�h
			row.UOEGuideNm = uOEGuideName.UOEGuideNm; // UOE�K�C�h����
		}

		/// <summary>
		/// UOE�K�C�h���̃��[�N��UOE�K�C�h���̍s�N���X�ݒ菈��
		/// </summary>
		/// <param name="row">UOE�K�C�h����</param>
		/// <returns>UOE�K�C�h���̍s�N���X</returns>
		internal StockInputInitialDataSet.UOEGuideNameRow RowFromUIData(UOEGuideName uOEGuideName)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = _dataSet.UOEGuideName.NewUOEGuideNameRow();
			this.SetRowFromUIData(ref row, uOEGuideName);
			return row;
		}

		/// <summary>
		/// UOE�K�C�h���̑��݃`�F�b�N
		/// </summary>
		/// <param name="UOEGuideDivCd">UOE�K�C�h�敪</param>
		/// <param name="UOESupplierCd">UOE������R�[�h</param>
		/// <param name="UOEGuideCode">UOE�K�C�h�R�[�h</param>
		/// <returns></returns>
		public bool UOEGuideNameExists(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
				);
			return (row != null);
		}
		# endregion

        #region ���_����֘A
        /// <summary>
        /// ���_�I�v�V���������`�F�b�N�v���p�e�B
        /// </summary>
        /// <returns>true:���� false:������</returns>
        public static bool IsSectionOptionIntroduce
        {
            get
            {
                // ���_�I�v�V�����`�F�b�N
                if ( ( int ) LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0 ) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs ( ArrayList secInfoSetWorkArrayList, ArrayList secCtrlSetWorkArrayList, ArrayList companyNmWorkArrayList )
        {
            if ( ( secInfoSetWorkArrayList == null ) || ( secCtrlSetWorkArrayList == null ) || ( companyNmWorkArrayList == null ) ) {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            SecInfoAcs.SetSecInfo(secInfoSetWorkArrayList, secCtrlSetWorkArrayList, companyNmWorkArrayList);

            this.CreateSecInfoAcs();
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs ()
        {
            if ( _secInfoAcs == null ) {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if ( _secInfoAcs.SecInfoSet == null ) {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// ���_�ݒ�}�X�^�z��v���p�e�B
        /// </summary>
        internal SecInfoSet[] SecInfoSetArray
        {
            get
            {
                // ���_����A�N�Z�X�N���X�C���X�^���X������
                this.CreateSecInfoAcs();

                return _secInfoAcs.SecInfoSetList;
            }
        }

        /// <summary>
        /// �����_�R�[�h�v���p�e�B
        /// </summary>
        public string OwnSectionCode
        {
            get
            {
                if ( this._ownSectionCode == "" ) {
                    return this.GetOwnSectionCode();
                }
                else {
                    return this._ownSectionCode;
                }
            }
        }

        /// <summary>
        /// �����_�R�[�h�擾����
        /// </summary>
        /// <returns>�����_�R�[�h</returns>
        private string GetOwnSectionCode ()
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �����_�̎擾
            SecInfoSet secInfoSet;
            //_secInfoAcs.GetSecInfo(this._loginSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

			if (secInfoSet != null)
			{
                // �����_�R�[�h�̕ۑ�
                this._ownSectionCode = secInfoSet.SectionCode;
            }

            return this._ownSectionCode;
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool IsMainOfficeFunc ()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if ( secInfoSet != null ) {
                // �{�Ћ@�\���H
                if ( secInfoSet.MainOfficeFuncFlag == 1 ) {
                    isMainOfficeFunc = true;
                }
            }
            else {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="isAllSection">�S�Аݒ�t���O</param>
        public void SetSectionComboEditor ( ref TComboEditor sender, bool isAllSection )
        {
            Infragistics.Win.ValueList valueList;
            this.SetSectionComboEditor(out valueList, isAllSection);

            if ( valueList != null ) {
                for ( int i = 0; i < valueList.ValueListItems.Count; i++ ) {
                    sender.Items.Add(valueList.ValueListItems[i]);
                }

                sender.MaxDropDownItems = valueList.ValueListItems.Count;

                if ( this.IsMainOfficeFunc() ) {
                    sender.ReadOnly = false;
                }
                else {
                    sender.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�{�b�N�X�c�[��</param>
        /// <param name="isAllSection">�S�Аݒ�t���O</param>
        public void SetSectionComboEditor ( ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool isAllSection )
        {
            Infragistics.Win.ValueList valueList;
            this.SetSectionComboEditor(out valueList, isAllSection);

            if ( valueList != null ) {
                sender.ValueList = valueList;
                sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

                if ( this.IsMainOfficeFunc() ) {
                    sender.SharedProps.Enabled = true;
                }
                else {
                    sender.SharedProps.Enabled = false;
                }
            }
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^���X�g�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�{�b�N�X�o�����[���X�g</param>
        /// <param name="isAllSection">�S�Аݒ�t���O</param>
        public void SetSectionComboEditor ( out Infragistics.Win.ValueList sender, bool isAllSection )
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            sender = new Infragistics.Win.ValueList();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if ( secInfoSet != null ) {
                if ( isAllSection ) {
                    Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                    secInfoItem.DataValue = SECTIONCODE_ALL;
                    secInfoItem.DisplayText = SECTIONNAME_ALL;
                    sender.ValueListItems.Add(secInfoItem);
                }

                // ���_��񃊃X�g�̎擾
                if ( ( _secInfoAcs.SecInfoSetList != null ) && ( _secInfoAcs.SecInfoSetList.Length > 0 ) ) {
                    foreach ( SecInfoSet setSecInfoSet in _secInfoAcs.SecInfoSetList ) {
                        Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                        secInfoItem.DataValue = setSecInfoSet.SectionCode;
                        secInfoItem.DisplayText = setSecInfoSet.SectionGuideNm;
                        sender.ValueListItems.Add(secInfoItem);
                    }
                }
            }
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        public bool SetSectionComboEditorValue ( TComboEditor sender, string sectionCode )
        {
            bool isSetting = false;

            if ( sender.Items.Count > 0 ) {
                // 1�̋��_�����Ȃ��ꍇ�͐擪��I��
                if ( sender.Items.Count == 1 ) {
                    sender.SelectedIndex = 0;
                    isSetting = true;
                }
                else {
                    for ( int i = 0; i < sender.Items.Count; i++ ) {
                        if ( sender.Items[i].DataValue.ToString().Trim() == sectionCode.Trim() ) {
                            sender.SelectedIndex = i;
                            isSetting = true;
                            break;
                        }
                    }
                }

                if ( !isSetting ) {
                    for ( int i = 0; i < sender.Items.Count; i++ ) {
                        if ( sender.Items[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim() ) {
                            sender.SelectedIndex = i;
                            isSetting = true;
                            break;
                        }
                    }
                }
            }

            return isSetting;
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        /// <br>�EOwnSecSetting = �����_�ݒ�</br>
        /// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        /// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        /// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        /// <br>�EBalanceDispSecCd = �c���\�����_</br>
        /// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        /// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        /// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        /// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        public bool SetSectionComboEditorValue ( TComboEditor sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode )
        {
            if ( sectionCode.Trim() == SECTIONCODE_ALL ) {
                return this.SetSectionComboEditorValue(sender, sectionCode);
            }
            else {
                string ctrlSectionCode;
                string ctrlSectionName;
                int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

                if ( status == 0 ) {
                    return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۃR���{�{�b�N�X</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        public bool SetSectionComboEditorValue ( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode )
        {
            bool isSetting = false;

            if ( sender.ValueList.ValueListItems.Count > 0 ) {
                sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

                // 1�̋��_�����Ȃ��ꍇ�͐擪��I��
                if ( sender.ValueList.ValueListItems.Count == 1 ) {
                    sender.SelectedIndex = 0;
                    isSetting = true;
                }
                else {
                    for ( int i = 0; i < sender.ValueList.ValueListItems.Count; i++ ) {
                        if ( sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == sectionCode.Trim() ) {
                            sender.Value = sectionCode;
                            isSetting = true;
                            break;
                        }
                    }
                }

                if ( !isSetting ) {
                    for ( int i = 0; i < sender.ValueList.ValueListItems.Count; i++ ) {
                        if ( sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim() ) {
                            sender.Value = this._loginSectionCode;
                            isSetting = true;
                            break;
                        }
                    }
                }
            }

            return isSetting;
        }

        /// <summary>
        /// ���_�R���{�G�f�B�^�I��l�ݒ菈��
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        /// <br>�EOwnSecSetting = �����_�ݒ�</br>
        /// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        /// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        /// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        /// <br>�EBalanceDispSecCd = �c���\�����_</br>
        /// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        /// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        /// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        /// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <returns>true:�ݒ萬�� false:�ݒ莸�s</returns>
        public bool SetSectionComboEditorValue ( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode )
        {
            if ( sectionCode.Trim() == SECTIONCODE_ALL ) {
                return this.SetSectionComboEditorValue(sender, sectionCode);
            }
            else {
                string ctrlSectionCode;
                string ctrlSectionName;
                int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

                if ( status == 0 ) {
                    return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// ����@�\���_�擾����
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)�̏ڍׂ͈ȉ��̒ʂ�B</br>
        /// <br>�EOwnSecSetting = �����_�ݒ�</br>
        /// <br>�EDemandAddUpSecCd = �����v�㋒�_</br>
        /// <br>�EResultsAddUpSecCd = ���ьv�㋒�_</br>
        /// <br>�EBillSettingSecCd = �����ݒ苒�_</br>
        /// <br>�EBalanceDispSecCd = �c���\�����_</br>
        /// <br>�EPayAddUpSecCd = �x���v�㋒�_</br>
        /// <br>�EPayAddUpSetSecCd = �x���ݒ苒�_</br>
        /// <br>�EPayBlcDispSecCd = �x���c���\�����_</br>
        /// <br>�EStockUpdateSecCd = �݌ɍX�V���_</br>
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        /// <param name="ctrlSectionName">�Ώې��䋒�_����</param>
        public int GetOwnSeCtrlCode ( string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName )
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �Ώې��䋒�_�̏����l�̓��O�C���S�����_
            ctrlSectionCode = sectionCode.TrimEnd();
            ctrlSectionName = "";

            SecInfoSet secInfoSet;
            //int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);
			int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_NORMAL: {
                        if ( secInfoSet != null ) {
                            ctrlSectionCode = secInfoSet.SectionCode.Trim();
                            ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
                        }
                        else {
                            // ���_����ݒ肪����Ă��Ȃ�
                            status = ( int ) ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        break;
                    }
                default: {
                        break;
                    }
            }

            return status;
        }
        #endregion
	}
}
