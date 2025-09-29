using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
#if false
	/// <summary>
	/// �d������������A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d������������͂̐���S�ʂ��s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men �V�K�쐬</br>
	/// </remarks>
	public class SalesTempInputAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
		/// </summary>
		private SalesTempInputAcs()
		{
			//this. = StockSlipInputAcs.GetInstance();
			this._customerInfoAcs = new CustomerInfoAcs();
			this._customerInfoAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._supplierAcs = new SupplierAcs();
			this._supplierAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._unitPriceCalculation = new UnitPriceCalculation();
			this._salesPriceCalclate = new SalesPriceCalclate();
			this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
			//this._stockSlipInputInitDataAcs.CacheSalesProcMoneyList += new StockSlipInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._unitPriceCalculation.CacheSalesProcMoneyList);
			//this._stockSlipInputInitDataAcs.CacheSalesProcMoneyList += new StockSlipInputInitDataAcs.CacheSalesProcMoneyListEventHandler(this._salesPriceCalclate.CacheSalesProcMoneyList);
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		}

		/// <summary>
		/// �d����������̓A�N�Z�X�N���X �C���X�^���X�擾����
		/// </summary>
		/// <returns>�d�����̓A�N�Z�X�N���X �C���X�^���X</returns>
		public static SalesTempInputAcs GetInstance()
		{
			if (_stockSlipSalesInfoInputAcs == null)
			{
				_stockSlipSalesInfoInputAcs = new SalesTempInputAcs();
			}

			return _stockSlipSalesInfoInputAcs;
		}

		#endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		#region ��Delegete

		/// <summary>�������ʃZ�b�g�C�x���g</summary>
		public delegate void SetDisplaySalesInfoEventHandler( SalesTemp salesTemp );

		/// <summary>������L���b�V���C�x���g</summary>
		public delegate void CacheSalesTempEventHandler( int stockRowNo, SalesTemp salesTemp );

		#endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		#region ��Events
		/// <summary>��ŐV���ݒ�C�x���g</summary>
		public event SetDisplaySalesInfoEventHandler SetDisplay;
		/// <summary>��ŐV���ݒ�C�x���g</summary>
		public event CacheSalesTempEventHandler CacheSalesTemp;

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private static SalesTempInputAcs _stockSlipSalesInfoInputAcs;
		private SalesTemp _salesTemp;
		private CustomerInfoAcs _customerInfoAcs;
		private SupplierAcs _supplierAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		private SalesPriceCalclate _salesPriceCalclate;
		private int _stockRowNo = 0;
		private string _enterpriseCode;
		private UnitPriceCalculation _unitPriceCalculation;
		private StockInputDataSet.StockDetailRow _stockDetailRow;

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties
		/// <summary>������v���p�e�B</summary>
		public SalesTemp SalesTemp
		{
			get { return this._salesTemp; }
			set { this._salesTemp = value; }
		}

		/// <summary>�d�����׃f�[�^�s�I�u�W�F�N�g</summary>
		public StockInputDataSet.StockDetailRow StockDetailRow
		{
			get { return _stockDetailRow; }
			set { _stockDetailRow = value; }
		}
		#endregion

		// ===================================================================================== //
		// �񋓑�
		// ===================================================================================== //
		#region �� Enums
		/// <summary>
		/// �P�����
		/// </summary>
		public enum UnitPriceKind
		{
			/// <summary>����P��</summary>
			SalesUnitPrice = 1,
			/// <summary>���㌴��</summary>
			SalesUnitCost = 2,
			/// <summary>�d���P��</summary>
			StockUnitPrice = 3,
			/// <summary>�艿</summary>
			ListPrice = 4,
		}
		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// ��������I�u�W�F�N�g����ʂɐݒ肵�܂��B
		/// </summary>
		/// <param name="stockRowNo">�s�ԍ�</param>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <param name="stockDetailRow">�d�����׃f�[�^�s�I�u�W�F�N�g</param>
		public void SettingSalesTemp( int stockRowNo, SalesTemp salesTemp, StockInputDataSet.StockDetailRow stockDetailRow )
		{
			this._salesTemp = salesTemp;
			this._stockRowNo = stockRowNo;
			this._stockDetailRow = stockDetailRow;

			this.SetDisplayCall();
		}

		/// <summary>
		/// ����������L���b�V�������i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		public void Cache( SalesTemp salesTemp )
		{
			this._salesTemp = salesTemp.Clone();

			this.CacheCall(this._stockRowNo, salesTemp);
		}

		/// <summary>
		/// ����������L���b�V�������i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="stockRowNo">�d���s�ԍ�</param>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		public void Cache( int stockRowNo, SalesTemp salesTemp )
		{
			this.CacheCall(stockRowNo, salesTemp);
		}

		/// <summary>
		/// ��������f�[�^�ݒ菈��
		/// </summary>
		/// <param name="salesTemp">��������f�[�^�I�u�W�F�N�g</param>
		/// <param name="customerInfo">���Ӑ�I�u�W�F�N�g</param>
		public void DataSettingSalesTempFromCustomerInfo( ref SalesTemp salesTemp, CustomerInfo customerInfo )
		{
			if (( customerInfo == null ))
			{
				salesTemp.CustomerCode = 0;			// ���Ӑ�R�[�h
				salesTemp.CustomerName = "";		// ���Ӑ於�̂P
				salesTemp.CustomerName2 = "";		// ���Ӑ於�̂Q
				salesTemp.CustomerSnm = "";			// ����
				salesTemp.HonorificTitle = "";		// �h��
				salesTemp.OutputNameCode = 0;		// �����R�[�h
				salesTemp.BusinessTypeCode = 0;		// �Ǝ�R�[�h
				salesTemp.BusinessTypeName = "";	// �Ǝ햼��
				salesTemp.SalesAreaCode = 0;		// �̔��G���A�R�[�h
				salesTemp.SalesAreaName = "";		// �̔��G���A����
				salesTemp.ClaimType = 0;			// ������敪
				salesTemp.CustRateGrpCode = 0;		// ���Ӑ�|���O���[�v�R�[�h
				salesTemp.FractionProcCd = 0;		// �[�������敪
				salesTemp.TotalAmountDispWayCd = 0;	// ���z�\�����@�Q�Ƌ敪
				salesTemp.TtlAmntDispRateApy = 0;	// ���z�\���|���K�p�敪
				salesTemp.ConsTaxLayMethod = 0;		// ����œ]�ŕ���
				salesTemp.ClaimCode = 0;			// ������R�[�h
				salesTemp.ClaimSnm = "";			// ����
				salesTemp.TotalDay = 0;				// ����
				salesTemp.NTimeCalcStDate = 0;		// ���񊨒�J�n��
				salesTemp.DemandAddUpSecCd = "";	// �����v�㋒�_�R�[�h
				salesTemp.SlipAddressDiv = 0;		// �`�[�Z���敪
				salesTemp.AddresseeCode = 0;		// �[�i��R�[�h
				salesTemp.AddresseeName = "";		// �[�i�於��
				salesTemp.AddresseeName2 = "";		// �[�i�於��2
				salesTemp.AddresseePostNo = "";		// �[�i��X�֔ԍ�
				salesTemp.AddresseeAddr1 = "";		// �[�i��Z��1
				salesTemp.AddresseeAddr2 = 0;		// �[�i��Z��2
				salesTemp.AddresseeAddr3 = "";		// �[�i��Z��3
				salesTemp.AddresseeAddr4 = "";		// �[�i��Z��4
				salesTemp.AddresseeTelNo = "";		// �[�i��d�b�ԍ�
				salesTemp.AddresseeFaxNo = "";		// �[�i��FAX�ԍ�

			}
			else
			{
				if (customerInfo == null) customerInfo = new CustomerInfo();

				//-----------------------------------------------------
				// ���Ӑ���
				//-----------------------------------------------------
				salesTemp.CustomerCode = customerInfo.CustomerCode;				// ���Ӑ�R�[�h
				salesTemp.CustomerName = customerInfo.Name;						// ���Ӑ於�̂P
				salesTemp.CustomerName2 = customerInfo.Name2;					// ���Ӑ於�̂Q
				salesTemp.CustomerSnm = customerInfo.CustomerSnm;				// ����
				salesTemp.HonorificTitle = customerInfo.HonorificTitle;			// �h��
				salesTemp.OutputNameCode = customerInfo.OutputNameCode;			// �����R�[�h
				salesTemp.BusinessTypeCode = customerInfo.BusinessTypeCode;		// �Ǝ�R�[�h
				salesTemp.BusinessTypeName = customerInfo.BusinessTypeName;		// �Ǝ햼��
				salesTemp.SalesAreaCode = customerInfo.SalesAreaCode;			// �̔��G���A�R�[�h
				salesTemp.SalesAreaName = customerInfo.SalesAreaName;			// �̔��G���A����
				//salesTemp.ClaimType = customerInfo.ClaimType;					// ������敪
				//salesTemp.CustRateGrpCode = customerInfo.CustRateGrpCode;		// ���Ӑ�|���O���[�v�R�[�h
				salesTemp.ClaimCode = customerInfo.ClaimCode;					// ������R�[�h

				salesTemp.SlipAddressDiv = 1;									// �`�[�Z���敪
				salesTemp.AddresseeCode = customerInfo.CustomerCode;			// �[�i��R�[�h
				salesTemp.AddresseeName = customerInfo.Name;					// �[�i�於��
				salesTemp.AddresseeName2 = customerInfo.Name2;					// �[�i�於��2
				salesTemp.AddresseePostNo = customerInfo.PostNo;				// �[�i��X�֔ԍ�
				salesTemp.AddresseeAddr1 = customerInfo.Address1;				// �[�i��Z��1
				//salesTemp.AddresseeAddr2 = customerInfo.Address2;				// �[�i��Z��2
				salesTemp.AddresseeAddr3 = customerInfo.Address3;				// �[�i��Z��3
				salesTemp.AddresseeAddr4 = customerInfo.Address4;				// �[�i��Z��4
				salesTemp.AddresseeTelNo = customerInfo.OfficeTelNo;			// �[�i��d�b�ԍ�
				salesTemp.AddresseeFaxNo = customerInfo.OfficeFaxNo;			// �[�i��FAX�ԍ�

				if (( customerInfo.CustomerAgentCd != "" ) && ( this._stockSlipInputInitDataAcs.CodeExist_Employee(customerInfo.CustomerAgentCd) ))
				{
					salesTemp.SalesEmployeeCd = customerInfo.CustomerAgentCd; // �S���҃R�[�h
					salesTemp.SalesEmployeeNm = customerInfo.CustomerAgentNm; // �S���Җ���
				}

				// ����Œ[�������P�ʁA�敪�擾
				int taxFracProcCd = 0;
				double taxFracProcUnit = 0;
				this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, customerInfo.SalesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
				salesTemp.FractionProcCd = taxFracProcCd;

				// ���z�\���|���K�p�敪
				salesTemp.TtlAmntDispRateApy = this._stockSlipInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;

				this.DataSettingClaimInfo(ref salesTemp);
			}
		}

		/// <summary>
		/// ����f�[�^(�d�������v��)�I�u�W�F�N�g�ɐ�����Ɋւ������ݒ肵�܂��B
		/// </summary>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		public void DataSettingClaimInfo( ref SalesTemp salesTemp )
		{
			if (salesTemp.ClaimCode == 0)
			{
				salesTemp.ClaimCode = 0;				// ������R�[�h
				salesTemp.ClaimSnm = "";				// ����
				salesTemp.TotalDay = 0;					// ����
				salesTemp.NTimeCalcStDate = 0;			// ���񊨒�J�n��
				salesTemp.TotalAmountDispWayCd = 0;
				salesTemp.ConsTaxLayMethod = 0;
				salesTemp.ClaimSnm = "";				// ����
				salesTemp.TotalDay = 0;					// ����
				salesTemp.NTimeCalcStDate = 0;			// ���񊨒�J�n��
				salesTemp.DemandAddUpSecCd = "";
			}
			else
			{
				//-----------------------------------------------------
				// ��������擾
				//-----------------------------------------------------
				CustomerInfo claim;
				int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesTemp.ClaimCode, true, out claim);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					claim = new CustomerInfo();
				}

				//-----------------------------------------------------
				// ��������
				//-----------------------------------------------------
				// ���Ӑ�}�X�^�̑��z�\�����@�Q�Ƌ敪��
				// �1:���Ӑ�Q�Ɓv�̏ꍇ�͓��Ӑ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
				// �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
				if (claim.TotalAmntDspWayRef == 0)
				{
					// 0:�S�̐ݒ�}�X�^�Q��
					salesTemp.TotalAmountDispWayCd = this._stockSlipInputInitDataAcs.GetAllDefSet().TotalAmountDispWayCd;
				}
				else
				{
					// 1:���Ӑ�}�X�^�Q��
					salesTemp.TotalAmountDispWayCd = claim.TotalAmountDispWayCd; // ��������
				}

				// ����œ]�ŕ���
				if (claim.CustCTaXLayRefCd == 0)
				{
					// 0:�ŗ��ݒ�}�X�^�Q��
					salesTemp.ConsTaxLayMethod = this._stockSlipInputInitDataAcs.GetTaxRateSet().ConsTaxLayMethod;
				}
				else
				{
					// 1:���Ӑ�}�X�^�Q��
					salesTemp.ConsTaxLayMethod = claim.ConsTaxLayMethod;
				}

				salesTemp.ClaimSnm = claim.CustomerSnm;				// ����
				salesTemp.TotalDay = claim.TotalDay;				// ����
				salesTemp.NTimeCalcStDate = claim.NTimeCalcStDate;	// ���񊨒�J�n��

				string sectionCode;
				string sectionName;
				this._stockSlipInputInitDataAcs.GetOwnSeCtrlCode(claim.MngSectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out sectionCode, out sectionName);
				salesTemp.DemandAddUpSecCd = sectionCode; // �����v�㋒�_�R�[�h
			}
		}

		/// <summary>
		/// �������ݒ菈��
		/// </summary>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		public void SalesEmployeeBelongInfoSetting( ref SalesTemp salesTemp )
		{
			string belongSecCd;
			int belongSubSecCd, belongMinSecCd;
			this._stockSlipInputInitDataAcs.GetBelongInfo_FromEmployee(salesTemp.SalesEmployeeCd, out belongSecCd, out belongSubSecCd, out belongMinSecCd);

			salesTemp.ResultsAddUpSecCd = belongSecCd;
			salesTemp.SubSectionCode = belongSubSecCd;
			salesTemp.MinSectionCode = belongMinSecCd;
		}


		/// <summary>
		/// �v�����ݒ肵�܂��B
		/// </summary>
		/// <param name="salesTemp"></param>
		public void SettingAddUpDate( ref SalesTemp salesTemp )
		{
			DateTime addUpDate;
			int delayPaymentDiv;
			StockSlipInputAcs.CalcAddUpDate(salesTemp.SalesDate, salesTemp.TotalDay, salesTemp.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

			salesTemp.AddUpADate = addUpDate;
			salesTemp.DelayPaymentDiv = delayPaymentDiv;
		}

		/// <summary>
		/// �\�����Ă��锄��P���̒l���擾���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <returns>�\���P��</returns>
		public double GetUnitPriceDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.SalesUnPrcTaxIncFl : salesTemp.SalesUnPrcTaxExcFl;
		}

		/// <summary>
		/// �\�����Ă���艿�̒l���擾���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <returns>�\���艿</returns>
		public double GetListPriceDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;
		}

		/// <summary>
		/// �\�����Ă��锄��P���̒l���擾���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <returns>�\���P��</returns>
		public long GetSalesMoneyDisplay( SalesTemp salesTemp )
		{
			return ( ( salesTemp.TotalAmountDispWayCd == 1 ) || ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ) ? salesTemp.SalesMoneyTaxInc : salesTemp.SalesMoneyTaxExc;
		}

		/// <summary>
		/// ���͂�������P���𓯎�����I�u�W�F�N�g�ɃZ�b�g���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <param name="salesUnitPriceDisplay">���͂�������P��</param>
		public void UnitPriceSetting( ref SalesTemp salesTemp, double salesUnitPriceDisplay )
		{
			double salesUnPrcTaxExcFl;
			double salesUnPrcTaxIncFl;

			// �\�����i���Ŕ����A�ō��݉��i���Z�o����
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, salesUnitPriceDisplay, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl);

			salesTemp.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcChngCd = 1;
		}

		/// <summary>
		/// ���͂������㌴���P���𓯎�����I�u�W�F�N�g�ɃZ�b�g���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <param name="salesUnitCostDisplay">���͂�������P��</param>
		public void salesUnitCostSetting( ref SalesTemp salesTemp, double salesUnitCostDisplay )
		{
			salesTemp.SalesUnitCost = salesUnitCostDisplay;

			if (salesTemp.BfUnitCost != salesTemp.SalesUnitCost)
			{
				salesTemp.SalesUnitCostChngDiv = 1;
			}
			else
			{
				salesTemp.SalesUnitCostChngDiv = 0;
			}
		}

		/// <summary>
		/// ���͂���������z�𓯎�����I�u�W�F�N�g�ɃZ�b�g���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <param name="salesMoneyDisplay">���͂���������z</param>
		public void SalesMoneyDirectSetting( ref SalesTemp salesTemp, long salesMoneyDisplay )
		{
			double salesUnPrcTaxExcFl;
			double salesUnPrcTaxIncFl;
			// �\�����i���Ŕ����A�ō��݉��i���Z�o����
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, salesMoneyDisplay, out salesUnPrcTaxExcFl, out salesUnPrcTaxIncFl);

			salesTemp.SalesMoneyTaxExc = (long)salesUnPrcTaxExcFl;
			salesTemp.SalesMoneyTaxInc = (long)salesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = 0;
			salesTemp.SalesUnPrcTaxIncFl = 0;
			if (salesTemp.BfSalesUnitPrice != salesTemp.SalesMoneyTaxExc)
			{
				salesTemp.SalesUnPrcChngCd = 1;
			}
			else
			{
				salesTemp.SalesUnPrcChngCd = 0;
			}
		}

		/// <summary>
		/// ���͂����艿�𓯎�����I�u�W�F�N�g�ɃZ�b�g���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <param name="listPriceDisplay">���͂����艿</param>
		public void ListPriceSetting( ref SalesTemp salesTemp, double listPriceDisplay )
		{
			double listPriceTaxExcFl;
			double listPriceTaxIncFl;
			// �\�����i���Ŕ����A�ō��݉��i���Z�o����
			this.CalcTaxExcAndTaxInc(salesTemp.TaxationDivCd, salesTemp.CustomerCode, salesTemp.ConsTaxRate, salesTemp.TotalAmountDispWayCd, listPriceDisplay, out listPriceTaxExcFl, out listPriceTaxIncFl);

			salesTemp.ListPriceTaxExcFl = listPriceTaxExcFl;
			salesTemp.ListPriceTaxIncFl = listPriceTaxIncFl;
			if (salesTemp.BfListPrice != salesTemp.ListPriceTaxExcFl)
			{
				salesTemp.ListPriceChngCd = 1;
			}
			else
			{
				salesTemp.ListPriceChngCd = 0;
			}
		}

		/// <summary>
		/// �e���`�F�b�N�敪�ݒ菈��
		/// </summary>
		/// <param name="salesTemp"></param>
		public void GrsProfitChkDivSetting( ref SalesTemp salesTemp )
		{
			salesTemp.GrsProfitChkDiv = this.MarginCheck(salesTemp);
		}

		/// <summary>
		/// ����P���Čv�Z�`�F�b�N
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <returns></returns>
		public bool SalesUnitPriceReCalcCheck( SalesTemp salesTemp )
		{
			bool ret = false;

#if false
			switch (salesTemp.UnPrcCalcCdSalUnPrc)
			{
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.BasePrice:				// ��P���~�|��
					{
						break;
					}

				case (int)UnitPriceCalculation.UnitPrcCalcDiv.CostUpRate:				// �����~����UP��
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrossProfitSecureRate:	// ������(1-�e����)
					{
						// �����P���Ɗ�P�����Ⴄ�ꍇ�͍Čv�Z
						if (salesTemp.SalesUnitCost != salesTemp.StdUnPrcSalUnPrc)
						{
							ret = true;
						}
						break;
					}
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice:			// ���͒艿�~�|��
					{
						double targetPrice = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;
						// ��P�����Ⴄ�ꍇ�͍Čv�Z
						if (targetPrice != salesTemp.StdUnPrcSalUnPrc)
						{
							ret = true;
						}
						break;
					}
			}
#endif

			return ret;
		}

		/// <summary>
		/// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
		/// </summary>
		/// <param name="salesTemp">��������I�u�W�F�N�g���X�g</param>
		public void CalclationUnitPrice( ref SalesTemp salesTemp )
		{
			if (salesTemp.ShipmentCnt == 0)
			{
				// ����P�����
				salesTemp.RateDivSalUnPrc = "";			// �|���ݒ�敪
				salesTemp.RateSectSalUnPrc = "";		// �|���ݒ苒�_
				salesTemp.UnPrcCalcCdSalUnPrc = 0;		// �P���Z�o�敪
				salesTemp.PriceCdSalUnPrc = 0;			// ���i�敪
				salesTemp.StdUnPrcSalUnPrc = 0;			// ��P��
				salesTemp.SalesUnPrcTaxExcFl = 0;		// ���P��(�Ŕ�)
				salesTemp.SalesUnPrcTaxIncFl = 0;		// ���P��(�ō�)
				salesTemp.SalesRate = 0;				// ������
				salesTemp.FracProcUnitSalUnPrc = 0;		// �[�������P��
				salesTemp.FracProcSalUnPrc = 0;			// �[�������敪
				salesTemp.BfSalesUnitPrice = 0;			// �ύX�O����
				salesTemp.SalesUnPrcChngCd = 0;			// �P���ύX�敪
				salesTemp.BargainCd = 0;				// �����敪
				salesTemp.BargainNm = "";				// �����敪����


				// ���㌴�����
				salesTemp.RateDivUnCst = "";			// �|���ݒ�敪
				salesTemp.RateSectCstUnPrc = "";		// �|���ݒ苒�_
				salesTemp.UnPrcCalcCdUnCst = 0;			// �P���Z�o�敪
				salesTemp.PriceCdUnCst = 0;				// ���i�敪
				salesTemp.StdUnPrcUnCst = 0;			// ��P��
				salesTemp.SalesUnitCost = 0;			// ���P��(�ō�)
				salesTemp.CostRate = 0;					// ������
				salesTemp.FracProcUnitUnCst = 0;		// �[�������P��
				salesTemp.FracProcUnCst = 0;			// �[�������敪
				salesTemp.BfUnitCost = 0;				// �ύX�O����
				salesTemp.SalesUnitCostChngDiv = 0;		// �����P���ύX�敪

				// �艿���
				salesTemp.RateDivLPrice = "";			// �|���ݒ�敪
				salesTemp.UnPrcCalcCdLPrice = 0;		// �P���Z�o�敪
				salesTemp.RateSectPriceUnPrc = "";		// �|���ݒ苒�_
				salesTemp.PriceCdLPrice = 0;			// ���i�敪
				salesTemp.StdUnPrcLPrice = 0;			// ��P��
				salesTemp.ListPriceTaxExcFl = 0;		// �艿(�Ŕ�)
				salesTemp.ListPriceTaxIncFl = 0;		// �艿(�ō�)
				salesTemp.ListPriceRate = 0;			// �艿��
				salesTemp.FracProcUnitLPrice = 0;		// �[�������P��
				salesTemp.FracProcLPrice = 0;			// �[�������敪
				salesTemp.BfListPrice = 0;				// �ύX�O�艿
				salesTemp.ListPriceChngCd = 0;			// �艿�ύX�敪

			}
			else
			{
				int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(salesTemp.EnterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
				int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(salesTemp.EnterpriseCode, salesTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

				int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
				double fracProcUnit;
				int fracProcCd;
				this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

				List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
				UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
				this.SalesTempRateInfoClear(ref salesTemp);
				unitPriceCalcParam.BLGoodsCode = salesTemp.RateBLGoodsCode;							// BL�R�[�h
				unitPriceCalcParam.SectionCode = salesTemp.SectionCode;								// ���_�R�[�h
				unitPriceCalcParam.CountFl = salesTemp.ShipmentCnt;									// ����
				unitPriceCalcParam.CustomerCode = salesTemp.CustomerCode;							// ���Ӑ�R�[�h
				unitPriceCalcParam.CustRateGrpCode = salesTemp.CustRateGrpCode;						// ���Ӑ�|���O���[�v�R�[�h
				unitPriceCalcParam.SupplierCd = salesTemp.SupplierCd;								// �d����R�[�h
				//unitPriceCalcParam.SuppRateGrpCode = salesTemp.SuppRateGrpCode;						// �d����|���O���[�v�R�[�h
				//unitPriceCalcParam.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;			// ���i�敪�ڍ׃R�[�h
				//unitPriceCalcParam.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;				// ���Е��ރR�[�h
				unitPriceCalcParam.GoodsMakerCd = salesTemp.GoodsMakerCd;							// ���[�J�[�R�[�h
				unitPriceCalcParam.GoodsNo = salesTemp.GoodsNo;										// ���i�ԍ�
				unitPriceCalcParam.GoodsRateRank = salesTemp.GoodsRateRank;							// ���i�|�������N
				//unitPriceCalcParam.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;				// ���i�敪�O���[�v�R�[�h
				//unitPriceCalcParam.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;					// �艿�ō�
				//unitPriceCalcParam.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;					// �艿��
				//unitPriceCalcParam.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;			// ���i�敪�R�[�h
				//unitPriceCalcParam.PriceApplyDate = salesTemp.SalesDate;							// �K�p��
				unitPriceCalcParam.PriceApplyDate = ( salesTemp.AcptAnOdrStatus == 30 ) ? salesTemp.SalesDate : salesTemp.ShipmentDay; // �K�p��
				unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;						// ����P���[�������R�[�h
				unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;						// �d���P���[�������R�[�h
				unitPriceCalcParam.SectionCode = salesTemp.SectionCode;								// ���_�R�[�h
				unitPriceCalcParam.TaxationDivCd = salesTemp.TaxationDivCd;							// �ېŋ敪
				//unitPriceCalcParam.TaxFractionProcCd = fracProcCd;									// ����Œ[�������敪
				//unitPriceCalcParam.TaxFractionProcUnit = fracProcUnit;								// ����Œ[�������P��
				unitPriceCalcParam.TaxRate = salesTemp.ConsTaxRate;									// �ŗ�
				unitPriceCalcParam.TotalAmountDispWayCd = salesTemp.TotalAmountDispWayCd;			// ���z�\�����@�敪
				unitPriceCalcParam.TtlAmntDspRateDivCd = salesTemp.TtlAmntDispRateApy;				// ���z�\���|���K�p�敪

				//this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, out unitPriceCalcRetList);

				bool calcListPrice = false;
				bool calcUnitPrice = false;
				bool calcUnitCost = false;

				if (unitPriceCalcRetList != null)
				{
					foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
					{
						switch (unitPriceCalcRet.UnitPriceKind)
						{
							//--------------------------------------------
							// ���P��
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice:
								salesTemp.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;			// �|���ݒ�敪
								salesTemp.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;				// �|���ݒ苒�_
								salesTemp.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;		// �P���Z�o�敪
								salesTemp.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;					// ���i�敪
								salesTemp.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;				// ��P��
								salesTemp.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// ���P��(�Ŕ�)
								salesTemp.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;		// ���P��(�ō�)
								salesTemp.SalesRate = unitPriceCalcRet.RateVal;							// ������
								salesTemp.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;	// �[�������P��
								salesTemp.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;			// �[�������敪
								salesTemp.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;		// �ύX�O����
								salesTemp.SalesUnPrcChngCd = 0;											// �P���ύX�敪
								calcUnitPrice = true;
								break;
							//--------------------------------------------
							// ���P��
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_UnitCost:
								salesTemp.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;			// �|���ݒ�敪
								salesTemp.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;				// �|���ݒ苒�_
								salesTemp.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;			// �P���Z�o�敪
								salesTemp.PriceCdUnCst = unitPriceCalcRet.PriceDiv;						// ���i�敪
								salesTemp.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;				// ��P��
								// ���ŕi�̏ꍇ�͐ō��݋��z
								if (salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
								{
									salesTemp.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxIncFl;		// ���P��(�ō�)
								}
								else
								{
									salesTemp.SalesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;		// ���P��(�Ŕ�)
								}
								salesTemp.CostRate = unitPriceCalcRet.RateVal;							// ������
								salesTemp.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;		// �[�������P��
								salesTemp.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;			// �[�������敪
								salesTemp.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;				// �ύX�O����
								salesTemp.SalesUnitCostChngDiv = 0;										// �����P���ύX�敪
								calcUnitCost = true;
								break;
							//--------------------------------------------
							// �艿
							//--------------------------------------------
							case UnitPriceCalculation.ctUnitPriceKind_ListPrice:
								salesTemp.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;			// �|���ݒ�敪
								salesTemp.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;			// �P���Z�o�敪
								salesTemp.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;			// �|���ݒ苒�_
								salesTemp.PriceCdLPrice = unitPriceCalcRet.PriceDiv;					// ���i�敪
								salesTemp.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;				// ��P��
								salesTemp.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;		// �艿(�Ŕ�)
								salesTemp.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;		// �艿(�ō�)
								salesTemp.ListPriceRate = unitPriceCalcRet.RateVal;						// �艿��
								salesTemp.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;		// �[�������P��
								salesTemp.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;			// �[�������敪
								salesTemp.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;				// �ύX�O�艿
								salesTemp.ListPriceChngCd = 0;											// �艿�ύX�敪
								calcListPrice = true;
								break;
							default:
								break;
						}
					}
				}
				// �艿�Z�o���Ĕ��P���Z�o�Ɏ��s�����ꍇ
				if (( calcListPrice ) && ( !calcUnitPrice ))
				{
					// �������ݒ莞�u�艿��\���v�̏ꍇ�ɒ艿�𔄉��ɐݒ肷��
					if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1)
					{
						salesTemp.SalesUnPrcTaxExcFl = salesTemp.ListPriceTaxExcFl;		// ���P��(�Ŕ�)
						salesTemp.SalesUnPrcTaxIncFl = salesTemp.ListPriceTaxIncFl;		// ���P��(�ō�)
					}
				}
			}
		}



		/// <summary>
		/// ������z���v�Z���܂��B
		/// </summary>
		/// <param name="salesTemp">��������f�[�^�I�u�W�F�N�g</param>
		public void CalculationSalesMoney( ref SalesTemp salesTemp )
		{
			if (salesTemp.GoodsName == "") return;
			//if (salesTemp.CustomerCode == 0) return;

			// ������z���Z��
			long salesMoneyTaxInc;
			long salesMoneyTaxExc;
			double taxRate = salesTemp.ConsTaxRate;

			// ���Ӑ�}�X�^�������Œ[�����������擾
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			int salesMoneyFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd); // �d�����z�[�������R�[�h

			// ������z�[�������P�ʁA�敪�擾
			int salesMoneyFracProcCd = 0;
			double salesmoneyFracProcUnit = 0;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Price, salesMoneyFrcProcCd, 0, out salesmoneyFracProcUnit, out salesMoneyFracProcCd);
			salesTemp.SalesPriceFracProcCd = salesMoneyFracProcCd;

			int taxationCode = salesTemp.TaxationDivCd;

			double salesUnitPrice = 0;
			if (( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( salesTemp.TotalAmountDispWayCd == 1 ))
			{
				salesUnitPrice = salesTemp.SalesUnPrcTaxIncFl;
			}
			else
			{
				salesUnitPrice = salesTemp.SalesUnPrcTaxExcFl;
			}

			// ���z�\�����͓��łŌv�Z����
			if (( salesTemp.TaxationDivCd != (int)CalculateTax.TaxationCode.TaxInc ) && ( salesTemp.TotalAmountDispWayCd == 1 )) taxationCode = 2;

			if (this.CalculationSalesMoney(
				salesTemp.ShipmentCnt,
				salesUnitPrice,
				taxationCode,
				taxRate,
				fracProcUnit,
				fracProcCd,
				salesMoneyFrcProcCd,
				out salesMoneyTaxInc,
				out salesMoneyTaxExc))
			{
				salesTemp.SalesMoneyTaxExc = salesMoneyTaxExc;
				salesTemp.SalesMoneyTaxInc = salesMoneyTaxInc;
				salesTemp.SalsePriceConsTax = (long)( (decimal)salesTemp.SalesMoneyTaxInc - (decimal)salesTemp.SalesMoneyTaxExc );
			}
		}

		/// <summary>
		/// ���㌴�����v�Z���܂��B
		/// </summary>
		/// <param name="salesTemp">��������f�[�^�I�u�W�F�N�g</param>
		public void CalculationCost( ref SalesTemp salesTemp )
		{
			if (salesTemp.GoodsName == "") return;
			if (salesTemp.CustomerCode == 0) return;

			// ������z���Z��
			long salesMoneyTaxInc;
			long salesMoneyTaxExc;
			double taxRate = salesTemp.ConsTaxRate;

			// ���Ӑ�}�X�^�������Œ[�����������擾
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			int costFrcProcCd = 0; // ���㌴���[�������R�[�h(0�Œ�)
			int taxationCode = salesTemp.TaxationDivCd;

			double salesUnitPrice = salesTemp.SalesUnitCost;

			if (this.CalculationSalesCost(
				salesTemp.ShipmentCnt,
				salesUnitPrice,
				taxationCode,
				taxRate,
				fracProcUnit,
				fracProcCd,
				costFrcProcCd,
				out salesMoneyTaxInc,
				out salesMoneyTaxExc))
			{
				if (salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
				{
					salesTemp.Cost = salesMoneyTaxInc;
				}
				else
				{
					salesTemp.Cost = salesMoneyTaxExc;
				}
			}
		}

		/// <summary>
		/// ����łɏ]���ĒP�����Čv�Z���܂��B
		/// </summary>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		public void SalesTempTaxRateChanged( ref SalesTemp salesTemp )
		{
			// �d�����z�[�������R�[�h
			int salesMoneyFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

			// ����Œ[�������敪
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			// �ېŕ����ɏ]���Ĕ���P���̐Ŕ����A�ō��P�����Čv�Z
			switch (salesTemp.TaxationDivCd)
			{
				case (int)CalculateTax.TaxationCode.TaxExc:
					salesTemp.SalesUnPrcTaxIncFl = (double)( (decimal)salesTemp.SalesUnPrcTaxExcFl + (decimal)CalculateTax.GetTaxFromPriceExc(salesTemp.ConsTaxRate, fracProcUnit, fracProcCd, salesTemp.SalesUnPrcTaxExcFl) );
					break;
				case (int)CalculateTax.TaxationCode.TaxInc:
					salesTemp.SalesUnPrcTaxExcFl = (double)( (decimal)salesTemp.SalesUnPrcTaxIncFl - (decimal)CalculateTax.GetTaxFromPriceInc(salesTemp.ConsTaxRate, fracProcUnit, fracProcCd, salesTemp.SalesUnPrcTaxIncFl) );
					break;
			}
		}

		/// <summary>
		/// ��������I�u�W�F�N�g�P���Čv�Z
		/// </summary>
		/// <param name="salesTemp"></param>
		public void SalesTempSalesUnitPriceReSetting( ref SalesTemp salesTemp )
		{
			// ����P���[�������R�[�h�擾
			int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(salesTemp.EnterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

			// ���Ӑ�}�X�^�������Œ[�����������擾
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesTemp.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
			double taxFracProcUnit;
			int taxFracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

			// �[�������P�ʁA�[�������敪���擾
			double fracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;
			int fracProcSalUnPrc = salesTemp.FracProcSalUnPrc;

			double unitPriceTaxExc = salesTemp.SalesUnPrcTaxExcFl;
			double unitPriceTaxInc = salesTemp.SalesUnPrcTaxIncFl;

			int taxationCode = salesTemp.TaxationDivCd;

			switch (salesTemp.UnPrcCalcCdSalUnPrc)
			{
				//// ���͒艿�~�|��
				//case (int)UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice:
				//    {
				//        salesTemp.StdUnPrcSalUnPrc = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.ListPriceTaxIncFl : salesTemp.ListPriceTaxExcFl;

				//        this._unitPriceCalculation.CalculateUnitPriceByRate(
				//            UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
				//            UnitPriceCalculation.UnitPrcCalcDiv.InputListPrice,
				//            salesTemp.TotalAmountDispWayCd,
				//            salesTemp.TtlAmntDispRateApy,
				//            salesUnPrcFrcProcCd,
				//            salesTemp.TaxationDivCd,
				//            salesTemp.StdUnPrcSalUnPrc,
				//            salesTemp.ConsTaxRate,
				//            taxFracProcUnit,
				//            taxFracProcCd,
				//            salesTemp.SalesRate,
				//            ref fracProcUnitSalUnPrc,
				//            ref fracProcSalUnPrc,
				//            out unitPriceTaxExc,
				//            out unitPriceTaxInc);

				//        salesTemp.SalesUnPrcChngCd = 0;
				//        break;
				//    }
				// �����~����UP��
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
					{
						salesTemp.StdUnPrcSalUnPrc = salesTemp.SalesUnitCost;
						this._unitPriceCalculation.CalculateUnitPriceByRate(
							UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
							UnitPriceCalculation.UnitPrcCalcDiv.UpRate,
							salesTemp.TotalAmountDispWayCd,
							salesTemp.TtlAmntDispRateApy,
							salesUnPrcFrcProcCd,
							salesTemp.TaxationDivCd,
							salesTemp.StdUnPrcSalUnPrc,
							salesTemp.ConsTaxRate,
							taxFracProcUnit,
							taxFracProcCd,
							salesTemp.SalesRate,
							ref fracProcUnitSalUnPrc,
							ref fracProcSalUnPrc,
							out unitPriceTaxExc,
							out unitPriceTaxInc);
						salesTemp.SalesUnPrcChngCd = 0;
						break;
					}

				// �����~(1-�e����)
				case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
					{
						salesTemp.StdUnPrcSalUnPrc = salesTemp.SalesUnitCost;
						this._unitPriceCalculation.CalculateUnitPriceByMarginRate(
							UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
							salesTemp.TotalAmountDispWayCd,
							salesTemp.TtlAmntDispRateApy,
							salesUnPrcFrcProcCd,
							salesTemp.TaxationDivCd,
							salesTemp.StdUnPrcSalUnPrc,
							salesTemp.ConsTaxRate,
							taxFracProcUnit,
							taxFracProcCd,
							salesTemp.SalesRate,
							ref fracProcUnitSalUnPrc,
							ref fracProcSalUnPrc,
							out unitPriceTaxExc,
							out unitPriceTaxInc);
						salesTemp.SalesUnPrcChngCd = 0;
						break;
					}
			}

			salesTemp.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;	// �[�������P��
			salesTemp.FracProcSalUnPrc = fracProcSalUnPrc;			// �[�������敪
			salesTemp.SalesUnPrcTaxExcFl = unitPriceTaxExc;			// �P���i�Ŕ��j
			salesTemp.SalesUnPrcTaxIncFl = unitPriceTaxInc;			// �P���i�ō��j
		}


		/// <summary>
		/// �P�����m�F�p�I�u�W�F�N�g�擾
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="salesTemp">��������I�u�W�F�N�g</param>
		/// <returns>�P�����m�F�p�I�u�W�F�N�g</returns>
		public UnPrcInfoConf GetUnitPriceInfoConf( UnitPriceKind unitPriceKind, SalesTemp salesTemp )
		{
			UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

			if (salesTemp != null)
			{
				unPrcInfoConf.CustomerCode = salesTemp.CustomerCode;  					// ���Ӑ�R�[�h
				unPrcInfoConf.CustomerSnm = salesTemp.CustomerSnm;						// ���Ӑ旪��
				unPrcInfoConf.SupplierCd = salesTemp.SupplierCd;						// �d����R�[�h
				unPrcInfoConf.SupplierSnm = salesTemp.SupplierSnm;						// �d���旪��
				unPrcInfoConf.CustRateGrpCode = salesTemp.CustRateGrpCode;				// ���Ӑ�|���O���[�v�R�[�h
				//unPrcInfoConf.SuppRateGrpCode = salesTemp.SuppRateGrpCode;				// �d����|���O���[�v�R�[�h
				unPrcInfoConf.GoodsNo = salesTemp.GoodsNo;								// ���i�ԍ�
				unPrcInfoConf.GoodsName = salesTemp.GoodsName;							// ���i����
				unPrcInfoConf.GoodsMakerCd = salesTemp.GoodsMakerCd;					// ���i���[�J�[�R�[�h
				unPrcInfoConf.MakerName = salesTemp.MakerName;							// ���[�J�[����
				//unPrcInfoConf.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;		// ���i�敪�O���[�v�R�[�h
				//unPrcInfoConf.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;		// ���i�敪�O���[�v����
				//unPrcInfoConf.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;	// ���i�敪�R�[�h
				//unPrcInfoConf.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;	// ���i�敪����
				//unPrcInfoConf.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
				//unPrcInfoConf.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;	// ���i�敪�ڍז���
				unPrcInfoConf.BLGoodsCode = salesTemp.RateBLGoodsCode;					// BL���i�R�[�h
				unPrcInfoConf.BLGoodsFullName = salesTemp.RateBLGoodsName;				// BL���i�R�[�h���́i�S�p�j
				//unPrcInfoConf.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;		// ���Е��ރR�[�h
				//unPrcInfoConf.EnterpriseGanreName = salesTemp.EnterpriseGanreName;		// ���Е��ޖ���
				unPrcInfoConf.GoodsRateRank = salesTemp.GoodsRateRank;					// ���i�|�������N
				unPrcInfoConf.PriceApplyDate = ( salesTemp.AcptAnOdrStatus == 30 ) ? salesTemp.AddUpADate : salesTemp.ShipmentDay;	// ���i�K�p��
				unPrcInfoConf.CountFl = salesTemp.ShipmentCnt;    						// ����
				//unPrcInfoConf.BargainCd = salesTemp.BargainCd;							// �����敪�R�[�h

				switch (unitPriceKind)
				{
					// ����P��
					case UnitPriceKind.SalesUnitPrice:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivSalUnPrc;		// �|���ݒ�敪
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdSalUnPrc;		// �P���Z�o�敪
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdSalUnPrc;					// ���i�敪
						unPrcInfoConf.RateVal = salesTemp.SalesRate;						// �|��
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitSalUnPrc;	// �P���[�������P��
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcSalUnPrc;		// �P���[�������敪
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcSalUnPrc;			// ��P��
						unPrcInfoConf.SectionCode = salesTemp.RateSectSalUnPrc;				// �|���ݒ苒�_

						//unPrcInfoConf.UnitPriceFl = this.GetUnitPriceDisplay(salesTemp);	// �P���i�����j
						//unPrcInfoConf.ListPriceFl = this.GetListPriceDisplay(salesTemp);	// �艿�i�����j
						//unPrcInfoConf.SalesUnitCost = salesTemp.SalesUnitCost;				// �����P��
						break;
					// �����P��
					case UnitPriceKind.SalesUnitCost:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivUnCst;		   	// �|���ݒ�敪
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdUnCst;			// �P���Z�o�敪
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdUnCst;				    // ���i�敪
						unPrcInfoConf.RateVal = salesTemp.CostRate;						    // �|��
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitUnCst;    	// �P���[�������P��
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcUnCst; 			// �P���[�������敪
						unPrcInfoConf.SectionCode = salesTemp.RateSectCstUnPrc;				// �|���ݒ苒�_
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcUnCst; 				// ��P��
						//unPrcInfoConf.UnitPriceFl = salesTemp.SalesUnitCost;      			// �P���i�����j
						break;
					// �艿
					case UnitPriceKind.ListPrice:
						unPrcInfoConf.RateSettingDivide = salesTemp.RateDivLPrice;			// �|���ݒ�敪
						unPrcInfoConf.UnitPrcCalcDiv = salesTemp.UnPrcCalcCdLPrice;			// �P���Z�o�敪
						//unPrcInfoConf.PriceDiv = salesTemp.PriceCdLPrice;	    			// ���i�敪
						unPrcInfoConf.RateVal = salesTemp.ListPriceRate;					// �|��
						unPrcInfoConf.UnPrcFracProcUnit = salesTemp.FracProcUnitLPrice;		// �P���[�������P��
						unPrcInfoConf.UnPrcFracProcDiv = salesTemp.FracProcLPrice;			// �P���[�������敪
						unPrcInfoConf.StdUnitPrice = salesTemp.StdUnPrcLPrice;				// ��P��
						unPrcInfoConf.SectionCode = salesTemp.RateSectPriceUnPrc;			// �|���ݒ苒�_
						//unPrcInfoConf.UnitPriceFl = this.GetListPriceDisplay(salesTemp);	// �P���i�����j
						break;
					default:
						break;
				}
			}

			return unPrcInfoConf;
		}

		/// <summary>
		/// �P���m�F��ʌ��ʃN���X���A�P�����ݒ��ݒ肵�܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="unPrcInfoConfRet">�P���m�F��ʌ��ʃI�u�W�F�N�g</param>
		/// <param name="salesTemp">�������肠g���I�u�W�F�N�g</param>
		public void UnPrcInfoSetting( SalesTempInputAcs.UnitPriceKind unitPriceKind, UnPrcInfoConfRet unPrcInfoConfRet, ref SalesTemp salesTemp )
		{
			if (salesTemp == null) return;
			switch (unitPriceKind)
			{
				// ����P��
				case UnitPriceKind.SalesUnitPrice:
					salesTemp.UnPrcCalcCdSalUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// �P���Z�o�敪
					//salesTemp.PriceCdSalUnPrc = unPrcInfoConfRet.PriceDiv;					// ���i�敪
					salesTemp.SalesRate = unPrcInfoConfRet.RateVal;							// �|��
					salesTemp.StdUnPrcSalUnPrc = unPrcInfoConfRet.StdUnitPrice;				// ��P��
					//1this.UnitPriceSetting(ref salesTemp, unPrcInfoConfRet.UnitPriceFl);		// �P���ݒ�
					salesTemp.FracProcUnitSalUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// �[�������P��
					salesTemp.FracProcSalUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;			// �[�������敪
					break;
				// �����P��
				case UnitPriceKind.SalesUnitCost:
					salesTemp.UnPrcCalcCdUnCst = unPrcInfoConfRet.UnitPrcCalcDiv;			// �P���Z�o�敪
					//salesTemp.PriceCdUnCst = unPrcInfoConfRet.PriceDiv;						// ���i�敪
					salesTemp.CostRate = unPrcInfoConfRet.RateVal;							// �|��
					salesTemp.StdUnPrcUnCst = unPrcInfoConfRet.StdUnitPrice;				// ��P��
					//salesTemp.SalesUnitCost = unPrcInfoConfRet.UnitPriceFl;					// �P���i�����j
					salesTemp.FracProcUnitUnCst = unPrcInfoConfRet.UnPrcFracProcUnit;		// �[�������P��
					salesTemp.FracProcUnCst = unPrcInfoConfRet.UnPrcFracProcDiv;			// �[�������敪
					break;
				// �艿
				case UnitPriceKind.ListPrice:
					salesTemp.UnPrcCalcCdLPrice = unPrcInfoConfRet.UnitPrcCalcDiv;			// �P���Z�o�敪
					//salesTemp.PriceCdLPrice = unPrcInfoConfRet.PriceDiv;					// ���i�敪
					salesTemp.ListPriceRate = unPrcInfoConfRet.RateVal;						// �|��
					salesTemp.StdUnPrcLPrice = unPrcInfoConfRet.StdUnitPrice;				// ��P��
					//this.ListPriceSetting(ref salesTemp, unPrcInfoConfRet.UnitPriceFl);		// �艿�ݒ�
					salesTemp.FracProcUnitLPrice = unPrcInfoConfRet.UnPrcFracProcUnit;		// �[�������P��
					salesTemp.FracProcLPrice = unPrcInfoConfRet.UnPrcFracProcDiv;			// �[�������敪
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// �e���`�F�b�N
		/// </summary>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		/// <returns>0:�K��,1:�����l����,2:����l�ȏ�</returns>
		public int MarginCheck( SalesTemp salesTemp )
		{

			// ���Ӑ悪�ݒ肳��Ă��Ȃ��ꍇ
			if (( salesTemp == null ) || ( salesTemp.CustomerCode == 0 ))
			{
				return 0;
			}

			double targetPrice = ( salesTemp.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesTemp.SalesMoneyTaxInc : salesTemp.SalesMoneyTaxExc;

			// �e�����̌v�Z
			double marginRate = this._salesPriceCalclate.CalculateMarginRate(targetPrice - salesTemp.Cost, targetPrice);

			// �����l�ݒ�L��
			if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckLower != 0)
			{
				if (marginRate < this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckLower)
				{
					return 1;
				}
			}

			// ����l�ݒ�L��
			if (this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckUpper != 0)
			{
				if (marginRate >= this._stockSlipInputInitDataAcs.GetSalesTtlSt().GrsProfitCheckUpper)
				{
					return 2;
				}
			}
			return 0;
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region ��Private Methods

		/// <summary>
		/// ��ʕ\���C�x���g���s
		/// </summary>
		private void SetDisplayCall()
		{
			if (this.SetDisplay != null)
			{
				this.SetDisplay(this._salesTemp);
			}
		}

		/// <summary>
		/// �L���b�V���C�x���g�R�[������
		/// </summary>
		/// <param name="stockRowNo">�d�����׍s�ԍ�</param>
		/// <param name="salesTemp">����f�[�^(�d�������v��)�I�u�W�F�N�g</param>
		private void CacheCall( int stockRowNo, SalesTemp salesTemp )
		{
			if (this.CacheSalesTemp != null)
			{
				this.CacheSalesTemp(stockRowNo, salesTemp);
			}
		}


		/// <summary>
		/// ������z���v�Z���܂��B
		/// </summary>
		/// <param name="count">����</param>
		/// <param name="unitPrice">�P��</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="fracProcCode">�[�������R�[�h</param>
		/// <param name="salesMoneyTaxInc">���z�i�ō��݁j</param>
		/// <param name="salesMoneyTaxExc">�d�����z�i�Ŕ����j</param>
		/// <returns></returns>
		private bool CalculationSalesMoney( double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int taxFracProcCd, int fracProcCode, out long salesMoneyTaxInc, out long salesMoneyTaxExc )
		{
			salesMoneyTaxInc = 0;
			salesMoneyTaxExc = 0;

			// �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
			if (( count == 0 ) || ( unitPrice == 0 )) return true;

			// �O�ł̏ꍇ
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
				double unitPriceInc;				// �P���i�ō��݁j
				double unitPriceTax;				// �P���i����Łj
				long priceExc = 0;					// ���i�i�Ŕ����j
				long priceInc;						// ���i�i�ō��݁j
				long priceTax;						// ���i�i����Łj

				this._salesPriceCalclate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceInc;		// �d�����z�i�ō��݁j
				salesMoneyTaxExc = priceExc;		// �d�����z�i�Ŕ����j		
			}
			// ���ł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				double unitPriceExc;				// �P���i�Ŕ����j
				double unitPriceInc = unitPrice;	// �P���i�ō��݁j
				double unitPriceTax;				// �P���i����Łj
				long priceExc;						// ���i�i�Ŕ����j
				long priceInc = 0;					// ���i�i�ō��݁j
				long priceTax;						// ���i�i����Łj

				this._salesPriceCalclate.CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceInc;		// �d�����z�i�ō��݁j
				salesMoneyTaxExc = priceExc;		// �d�����z�i�Ŕ����j
			}
			// ��ېł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
				double unitPriceInc;				// �P���i�ō��݁j
				double unitPriceTax;				// �P���i����Łj
				long priceExc = 0;					// ���i�i�Ŕ����j
				long priceInc;						// ���i�i�ō��݁j
				long priceTax;						// ���i�i����Łj

				this._salesPriceCalclate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

				salesMoneyTaxInc = priceExc;		// �d�����z�i�ō��݁j
				salesMoneyTaxExc = priceExc;		// �d�����z�i�ō��݁j
			}

			return true;
		}

		/// <summary>
		/// ������z���v�Z���܂��B
		/// </summary>
		/// <param name="count">����</param>
		/// <param name="unitPrice">�P��</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="fracProcCode">�[�������R�[�h</param>
		/// <param name="salesMoneyTaxInc">���z�i�ō��݁j</param>
		/// <param name="salesMoneyTaxExc">�d�����z�i�Ŕ����j</param>
		/// <returns></returns>
		private bool CalculationSalesCost( double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int fracProcCode, int taxFracProcCd, out long salesMoneyTaxInc, out long salesMoneyTaxExc )
		{
            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            //// �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            //if (( count == 0 ) || ( unitPrice == 0 )) return true;

            //// �O�ł̏ꍇ
            //if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            //{
            //    double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
            //    double unitPriceInc;				// �P���i�ō��݁j
            //    double unitPriceTax;				// �P���i����Łj
            //    long priceExc = 0;					// ���i�i�Ŕ����j
            //    long priceInc;						// ���i�i�ō��݁j
            //    long priceTax;						// ���i�i����Łj

            //    this._salesPriceCalclate.CalcCostTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceInc;		// �d�����z�i�ō��݁j
            //    salesMoneyTaxExc = priceExc;		// �d�����z�i�Ŕ����j		
            //}
            //// ���ł̏ꍇ
            //else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            //{
            //    double unitPriceExc;				// �P���i�Ŕ����j
            //    double unitPriceInc = unitPrice;	// �P���i�ō��݁j
            //    double unitPriceTax;				// �P���i����Łj
            //    long priceExc;						// ���i�i�Ŕ����j
            //    long priceInc = 0;					// ���i�i�ō��݁j
            //    long priceTax;						// ���i�i����Łj

            //    this._salesPriceCalclate.CalcCostTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceInc;		// �d�����z�i�ō��݁j
            //    salesMoneyTaxExc = priceExc;		// �d�����z�i�Ŕ����j
            //}
            //// ��ېł̏ꍇ
            //else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            //{
            //    double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
            //    double unitPriceInc;				// �P���i�ō��݁j
            //    double unitPriceTax;				// �P���i����Łj
            //    long priceExc = 0;					// ���i�i�Ŕ����j
            //    long priceInc;						// ���i�i�ō��݁j
            //    long priceTax;						// ���i�i����Łj

            //    this._salesPriceCalclate.CalcCostTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

            //    salesMoneyTaxInc = priceExc;		// �d�����z�i�ō��݁j
            //    salesMoneyTaxExc = priceExc;		// �d�����z�i�ō��݁j
            //}

			return true;
		}

		/// <summary>
		/// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="totalAmountDispWayCd">���z�\���敪</param>
		/// <param name="displayPrice">�Ώۋ��z</param>
		/// <param name="priceTaxExc">�Ŕ������z</param>
		/// <param name="priceTaxInc">�ō��݋��z</param>
		private void CalcTaxExcAndTaxInc( int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc )
		{
			priceTaxExc = 0;
			priceTaxInc = 0;
			// ���Ӑ�}�X�^�������Œ[�����������擾
			int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
			double fracProcUnit;
			int fracProcCd;
			this._stockSlipInputInitDataAcs.GetSalesFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

			// ���ŕi
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				priceTaxInc = displayPrice;
				priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
			}
			// �O�ŕi
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// ���z�\�����Ă���ꍇ�͐ō��݉��i
				if (totalAmountDispWayCd == 1)
				{
					priceTaxInc = displayPrice;
					priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
				}
				else
				{
					priceTaxExc = displayPrice;
					priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
				}
			}
			// ��ېŕi
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
			{
				priceTaxExc = displayPrice;
				priceTaxInc = displayPrice;
			}
			else
			{
				priceTaxExc = 0;
				priceTaxInc = 0;
			}
		}

		/// <summary>
		/// ��������I�u�W�F�N�g�̊|���֌W�̏����N���A���܂��B
		/// </summary>
		/// <param name="salesTemp"></param>
		private void SalesTempRateInfoClear( ref SalesTemp salesTemp )
		{
			salesTemp.RateDivSalUnPrc = "";		// �|���ݒ�敪
			salesTemp.UnPrcCalcCdSalUnPrc = 0;	// �P���Z�o�敪
			salesTemp.PriceCdSalUnPrc = 0;		// ���i�敪
			salesTemp.StdUnPrcSalUnPrc = 0;		// ��P��
			salesTemp.SalesUnPrcTaxExcFl = 0;	// ���P��(�Ŕ�)
			salesTemp.SalesUnPrcTaxIncFl = 0;	// ���P��(�ō�)
			salesTemp.SalesRate = 0;			// ������
			salesTemp.FracProcUnitSalUnPrc = 0;	// �[�������P��
			salesTemp.FracProcSalUnPrc = 0;		// �[�������敪
			salesTemp.SalesUnPrcChngCd = 0;		// �P���ύX�敪
			//--------------------------------------------
			// ���P��
			//--------------------------------------------
			salesTemp.RateDivUnCst = "";		// �|���ݒ�敪
			salesTemp.UnPrcCalcCdUnCst = 0;		// �P���Z�o�敪
			salesTemp.PriceCdUnCst = 0;			// ���i�敪
			salesTemp.StdUnPrcUnCst = 0;		// ��P��
			salesTemp.SalesUnitCost = 0;		// ���P��(�ō�)
			salesTemp.CostRate = 0;				// ������
			salesTemp.FracProcUnitUnCst = 0;	// �[�������P��
			salesTemp.FracProcUnCst = 0;		// �[�������敪
			salesTemp.SalesUnitCostChngDiv = 0;	// �����P���ύX�敪
			//--------------------------------------------
			// �艿
			//--------------------------------------------
			salesTemp.RateDivLPrice = "";		// �|���ݒ�敪
			salesTemp.UnPrcCalcCdLPrice = 0;	// �P���Z�o�敪
			salesTemp.PriceCdLPrice = 0;		// ���i�敪
			salesTemp.StdUnPrcLPrice = 0;		// ��P��
			salesTemp.ListPriceTaxExcFl = 0;	// �艿(�Ŕ�)
			salesTemp.ListPriceTaxIncFl = 0;	// �艿(�ō�)
			salesTemp.ListPriceRate = 0;		// �艿��
			salesTemp.FracProcUnitLPrice = 0;	// �[�������P��
			salesTemp.FracProcLPrice = 0;		// �[�������敪
			salesTemp.ListPriceChngCd = 0;		// �艿�ύX�敪
		}


		#endregion

		// ===================================================================================== //
		// �X�^�e�B�b�N���\�b�h
		// ===================================================================================== //
		#region ��Static Methods

		/// <summary>
		/// �\���p����`�[�敪���A�`�[�敪�A���|�敪��ݒ肵�܂��B
		/// </summary>
		/// <param name="salesSlipCdDisplay">����`�[�敪�i�\���p�j</param>
		/// <param name="salesTemp">����������</param>
		static public void SetSlipCdAndAccPayDivCdByDisplay( int salesSlipCdDisplay, ref SalesTemp salesTemp )
		{
			int salesSlipCd, accPayDivCd;
			GetSlipCdAndAccPayDivCdFromSalesSlipCdDisplay(salesSlipCdDisplay, out salesSlipCd, out accPayDivCd);

			salesTemp.SalesSlipCd = salesSlipCd;
			salesTemp.AccRecDivCd = accPayDivCd;
		}

		/// <summary>
		/// �\���p�d���`�[�敪���A�d���`�[�敪�A���|�敪���擾���܂��B
		/// </summary>
		/// <param name="salesSlipCdDisplay">�\���p����`�[�敪</param>
		/// <param name="salesSlipCd">����`�[�敪</param>
		/// <param name="accPayDivCd">���|�敪</param>
		static public void GetSlipCdAndAccPayDivCdFromSalesSlipCdDisplay( int salesSlipCdDisplay, out int salesSlipCd, out int accPayDivCd )
		{
			// �����l�͊|����
			salesSlipCd = 10;
			accPayDivCd = 1;
			switch (salesSlipCdDisplay)
			{
				// �|����
				case 10:
					{
						salesSlipCd = 0;
						accPayDivCd = 1;
						break;
					}
				// �|�ԕi
				case 20:
					{
						salesSlipCd = 1;
						accPayDivCd = 1;
						break;
					}
				// ��������
				case 30:
					{
						salesSlipCd = 0;
						accPayDivCd = 0;
						break;
					}
				// �����ԕi
				case 40:
					{
						salesSlipCd = 1;
						accPayDivCd = 0;
						break;
					}
			}
		}

		/// <summary>
		/// �d���`�[�敪�A���|�敪���A�\���p�d���`�[�敪���܂��B
		/// </summary>
		/// <param name="salesSlipCd">�`�[�敪</param>
		/// <param name="accPayDivCd">���|�敪</param>
		/// <returns>�\���p�d���`�[�敪</returns>
		static public int GetSalesSlipCdDisplayFromSlipCdAndAccPayDivCd( int salesSlipCd, int accPayDivCd )
		{
			int value = 0;
			// �`�[�敪
			switch (salesSlipCd)
			{
				// ����
				case 0:
					{
						value = 10;
						break;
					}
				// �ԕi
				case 1:
					{
						value = 20;
						break;
					}
			}

			// ���|�敪
			switch (accPayDivCd)
			{
				case 0:
					{
						value += 20;
						break;
					}
				default:
					{
						break;
					}
			}
			return value;
		}

		#endregion
	}

#endif
}
