# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �P�����m�F��ʃA�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �P�����m�F��ʃf�[�^���������s���܂��B</br>
	/// <br>Programmer	: 21024�@���X�� ��</br>
	/// <br>Date		: 2008.06.24</br>
    /// <br>            : 10801804-00 2013/5/15�z�M���ً̋}�Ή�</br>
    /// <br>UpdateNote  : 2013/04/12 xujx�@Redmine#35342 �Ή��F���i�K�C�h�̏C��</br>
	/// </remarks>
	public class DCKHN01051A
	{
		# region ��Private Members
		
		private string _enterpriseCode;						// ��ƃR�[�h

		private UnPrcInfoConf _unPrcInfoConf;				// �P�����m�F��ʃf�[�^�N���X
		private UnPrcInfoConfRet _unPrcInfoConfRet;			// �P�����m�F��ʌ��ʃN���X

		private UnPrcInfoConfDataSet _dataSet;				// �f�[�^�Z�b�g
		private GoodsAcs _goodsAcs;							// ���i�A�N�Z�X�N���X
		private GoodsUnitData _goodsUnitData;				// ���i�A���f�[�^
		private int _unitPriceKindCode;						// �P�����
        private RateMngGoodsCust _rateMngGoodsCust;         // �|���ݒ�Ǘ��}�X�^�A�N�Z�X�N���X
        private static DataTable _rateMngTable = new DataTable();

        /// <summary>���[�U�[�K�C�h�敪�R�[�h�i���i�j</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_PriceDiv = 47;
		/// <summary>���[�U�[�K�C�h�敪�R�[�h�i�����敪�j</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_Bargain = 42;

		# endregion

		# region ��Constructor
		/// <summary>
		/// �P�����m�F��ʃA�N�Z�X�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �P�����m�F��ʃA�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2008.06.20</br>
		/// </remarks>
		public DCKHN01051A()
		{
			// ��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			this._dataSet = new UnPrcInfoConfDataSet();

			this._unPrcInfoConf = new UnPrcInfoConf();
			this._unPrcInfoConfRet = new UnPrcInfoConfRet();

			this._goodsAcs = new GoodsAcs();

            this._rateMngGoodsCust = new RateMngGoodsCust();
		}
		# endregion

		#region��Properties
		/// <summary>���b�g�e�[�u���v���p�e�B</summary>
		public UnPrcInfoConfDataSet.LotInfoDataTable LotInfoTable
		{
			get { return this._dataSet.LotInfo; }
		}

		/// <summary>���i���e�[�u���v���p�e�B</summary>
		public UnPrcInfoConfDataSet.PriceInfoDataTable PriceInfoTable
		{
			get { return this._dataSet.PriceInfo; }
		}

		/// <summary>�P�����</summary>
		public UnPrcInfoConf UnitPriceInfoConf
		{
			set 
			{ 	this._unPrcInfoConf = value;
				this._unPrcInfoConfRet = this.GetUnPrcInfoConfRet(this._unPrcInfoConf);
			}
			get { return this._unPrcInfoConf; }
		}

		/// <summary>�P�����m�F����</summary>
		public UnPrcInfoConfRet UnPrcInfoConfRet
		{
			get { return this._unPrcInfoConfRet; }
		}

		/// <summary>�P�����</summary>
		public int UnitPriceKindCode
		{
			set { this._unitPriceKindCode = value; }
		}
		#endregion

		#region��Public Methods

		/// <summary>
		/// ������񌟍�����
		/// </summary>
		public void InitialSearch()
		{
			this.SearchGoods();
			this.SearchRate();
            this.SearchRateMngGoodsCust();
		}

		/// <summary>
		/// �P���̌v�Z���s���܂��B
		/// </summary>
		public void CalclationUnitPrice()
		{
			//switch (this._unPrcInfoConf.UnitPrcCalcDiv)
			//{
			//    case 1:	// ����i�~�|��
			//    case 2:	// �����~����UP��
			//    case 4:	// ���͒艿�~�|��
			//        {
			//            this._unPrcInfoConf.UnitPriceFl = this.CalclateUnitPriceByRate(this._unPrcInfoConf.StdUnitPrice, this._unPrcInfoConf.RateVal, this._unPrcInfoConf.UnPrcFracProcUnit, this._unPrcInfoConf.UnPrcFracProcDiv);
			//            break;
			//        }
			//    case 3:	// �������i�P�|�e�����j
			//        {
			//            this._unPrcInfoConf.UnitPriceFl = this.CalclateUnitPriceByMarginRate(this._unPrcInfoConf.StdUnitPrice, this._unPrcInfoConf.RateVal, this._unPrcInfoConf.UnPrcFracProcUnit, this._unPrcInfoConf.UnPrcFracProcDiv);
			//            break;
			//        }
			//}
		}

		/// <summary>
		/// �P�����ڐݒ菈��
		/// </summary>
		/// <param name="unitPrice"></param>
		public void UnitPriceDirectSetting( double unitPrice )
		{
			double unitPriceTaxInc = 0;
			double unitPriceTaxExc = 0;

			if (( this._unPrcInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) || ( this._unPrcInfoConf.TotalAmountDispWayCd == 1 ))
			{
				// �@�ō��ݒP�� = ��P������|���v�Z��������
				unitPriceTaxInc = unitPrice;

				// �A�Ŕ����P�� = �ō��ݒP�� - �ō��ݒP���̏����
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._unPrcInfoConf.TaxRate, this._unPrcInfoConf.TaxFractionProcUnit, this._unPrcInfoConf.TaxFractionProcCd, unitPriceTaxInc);
			}
			else if (this._unPrcInfoConf.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// �@�Ŕ����P�� = ��P������|���v�Z��������
				unitPriceTaxExc = unitPrice;

				// �A�ō��ݒP�� = �Ŕ����P�� + �Ŕ����P���̏����
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._unPrcInfoConf.TaxRate, this._unPrcInfoConf.TaxFractionProcUnit, this._unPrcInfoConf.TaxFractionProcCd, unitPriceTaxExc);
			}
			this._unPrcInfoConf.UnitPriceTaxExcFl = unitPriceTaxExc;	// �P��(�Ŕ�)
			this._unPrcInfoConf.UnitPriceTaxIncFl = unitPriceTaxInc;	// �P��(�ō�)
			this._unPrcInfoConf.StdUnitPrice = 0;			// ����i
			this._unPrcInfoConf.RateVal = 0;				// ��
			this._unPrcInfoConf.UnPrcFracProcUnit = 0;		// �[�������P��
			this._unPrcInfoConf.UnPrcFracProcDiv = 0;		// �[������
			this._unPrcInfoConf.UnitPrcCalcDiv = 0;			// �P���Z�o�敪
		}

		/// <summary>
		/// �P���v�Z���@�ݒ菈��
		/// </summary>
		/// <param name="unitPrcCalcDiv"></param>
		public void unitPrcCalcDivSetting( int unitPrcCalcDiv )
		{
			this._unPrcInfoConf.UnitPrcCalcDiv = unitPrcCalcDiv;
			//switch (unitPrcCalcDiv)
			//{
			//    case 0:	// �[���͖���
			//        {
			//            break;
			//        }
			//    case 2:	// �����~����UP��
			//    case 3:	// �������i�P�|�e�����j
			//        {
			//            // ��P���敪���[���ɂ���
			//            this._unPrcInfoConf.PriceDiv = 0;
			//            // ��P���Ɍ����P�����Z�b�g
			//            this._unPrcInfoConf.StdUnitPrice = this._unPrcInfoConf.SalesUnitCost;
			//            break;
			//        }
			//    case 4:	// ���͒艿�~�|��
			//        {
			//            // ��P���敪���[���ɂ���
			//            this._unPrcInfoConf.PriceDiv = 0;
			//            // ��P���Ɍ����P�����Z�b�g
			//            this._unPrcInfoConf.StdUnitPrice = this._unPrcInfoConf.ListPriceFl;
			//            break;
			//        }
			//    default:
			//        {
			//            this.PriceCdSetting(this._unPrcInfoConf.PriceDiv);
			//            break;
			//        }
			//}
		}

		/// <summary>
		/// ����i�敪�ݒ菈��
		/// </summary>
		/// <param name="priceDiv"></param>
		public void PriceCdSetting( int priceDiv )
		{
			//this._unPrcInfoConf.PriceDiv = priceDiv;

			//if (this._itemsPriceDivList.ContainsKey(priceDiv))
			//{
			//    this._unPrcInfoConf.StdUnitPrice = this.GetPriceFromPriceInfoTable(priceDiv);
			//}
			//this.CalclationUnitPrice();
		}

		/// <summary>
		/// ����ݒ菈��
		/// </summary>
		/// <param name="stdUnPrc"></param>
		public void StdUnPrcSetting( double stdUnPrc )
		{
			this._unPrcInfoConf.StdUnitPrice = stdUnPrc;
			//this._unPrcInfoConf.PriceDiv = 0;
			this.ReCalcUnitPrice();
		}

		/// <summary>
		/// ���ݒ菈��
		/// </summary>
		/// <param name="rate"></param>
		public void RateSetting( double rate )
		{
			this._unPrcInfoConf.RateVal = rate;

			this.ReCalcUnitPrice();
		}

		/// <summary>
		/// �P���Čv�Z����
		/// </summary>
		public void ReCalcUnitPrice()
		{
			if (this._unPrcInfoConf.StdUnitPrice == 0) return;
			this.CalclationUnitPrice();
		}

		/// <summary>
		/// ���i���e�[�u�����A����i���擾���܂��B
		/// </summary>
		/// <returns>����i</returns>
		public double GetPriceFromPriceInfoTable()
		{
			//return this.GetPriceFromPriceInfoTable(this._unPrcInfoConf.PriceDiv);
			return 0;
		}

		/// <summary>
		/// �L���b�V������Ă���P������ʃI�u�W�F�N�g����P�����m�F���ʃI�u�W�F�N�g��ݒ肵�܂��B
		/// </summary>
		public void UnPrcInfoConfRetSetting()
		{
			this._unPrcInfoConfRet = this.GetUnPrcInfoConfRet(this._unPrcInfoConf);
		}
		#endregion

		#region ��Private Methods

		/// <summary>
		/// ���i��������
		/// </summary>
		/// <returns></returns>
		private int SearchGoods()
		{
            GoodsUnitData goodsUnitData = null;
            this._dataSet.PriceInfo.Rows.Clear();

            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = this._unPrcInfoConf.GoodsNo;
            goodsCndtn.GoodsMakerCd = this._unPrcInfoConf.GoodsMakerCd;

            List<GoodsUnitData> goodsUnitDataList;
            string msg;
            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, out goodsUnitDataList, out msg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (GoodsUnitData retGoodsUnitData in goodsUnitDataList)
                {
                    if (( retGoodsUnitData.GoodsNo == this._unPrcInfoConf.GoodsNo ) &&
                        ( retGoodsUnitData.GoodsMakerCd == this._unPrcInfoConf.GoodsMakerCd ))
                    {
                        goodsUnitData = retGoodsUnitData;
                    }
                }
                if (goodsUnitData != null)
                {
                    this._goodsUnitData = goodsUnitData.Clone();

                    this._dataSet.PriceInfo.Rows.Clear();

                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

                    foreach (GoodsPrice goodsPrice in goodsPriceList)
                    {
                        UnPrcInfoConfDataSet.PriceInfoRow row = this._dataSet.PriceInfo.NewPriceInfoRow();
                        row.PriceStartDate = goodsPrice.PriceStartDate;
                        row.ListPrice = goodsPrice.ListPrice;
                        row.SalesUnitCost = goodsPrice.SalesUnitCost;
                        row.StockRate = goodsPrice.StockRate;

                        this._dataSet.PriceInfo.AddPriceInfoRow(row);
                    }
                }
                else
                {
                    this._goodsUnitData = new GoodsUnitData();
                }
            }

			return status;
		}

		/// <summary>
		/// �|���}�X�^���������A���b�g�����擾���܂��B
		/// </summary>
		private void SearchRate()
		{
			this._dataSet.LotInfo.Rows.Clear();

			RateAcs rateAcs = new RateAcs();

			DataTable dataTable = new DataTable();
			string msg;

			Rate rate = CreateRateFromUnitPriceInfoConf(this._unPrcInfoConf);
			rate.EnterpriseCode = this._enterpriseCode;
			rate.UnitPriceKind = this._unitPriceKindCode.ToString();

            rateAcs.Search(out dataTable, ref rate, out msg);

            if (( dataTable != null ) && ( dataTable.Rows.Count > 0 ))
            {
                // �Ώېݒ�̃��b�g���X�g���擾(���b�g���Ń\�[�g)
                DataRow[] rows = dataTable.Select(string.Format("{0}={1} AND {2}<>0", RateAcs.LOGICALDELETECODE, 0, RateAcs.LOTCOUNT), string.Format("{0}", RateAcs.LOTCOUNT));
                if (( rows != null ) && ( rows.Length > 0 ))
                {
                    foreach (DataRow row in rows)
                    {
                        UnPrcInfoConfDataSet.LotInfoRow lotInfoRow = this._dataSet.LotInfo.NewLotInfoRow();
                        lotInfoRow.LotCount = (double)row[RateAcs.LOTCOUNT];
                        lotInfoRow.CountRange = string.Format("{0:#.00}�ȉ�", (double)row[RateAcs.LOTCOUNT]);
                        lotInfoRow.PriceFl = (double)row[RateAcs.PRICEFL];
                        lotInfoRow.RateVal = (double)row[RateAcs.RATEVAL];
                        lotInfoRow.UpRate = (double)row[RateAcs.UPRATE];
                        lotInfoRow.GrsProfitSecureRate = (double)row[RateAcs.GRSPROFITSECURERATE];
                        lotInfoRow.UnPrcFracProcUnit = (double)row[RateAcs.UNPRCFRACPROCUNIT];
                        lotInfoRow.UnPrcFracProcDiv = (int)row[RateAcs.UNPRCFRACPROCDIV];
                        lotInfoRow.UnPrcFracProcDivName = GetFracProcDivName(lotInfoRow.UnPrcFracProcDiv);
                        this._dataSet.LotInfo.AddLotInfoRow(lotInfoRow);
                    }
                }
            }
		}

        /// <summary>
        /// �|���ݒ�Ǘ��}�X�^��������
        /// </summary>
        private void SearchRateMngGoodsCust()
        {
            int totalCnt;
            bool nextData;
            string msg;
            int st = this._rateMngGoodsCust.SearchAll(out _rateMngTable, out totalCnt, out nextData, this._enterpriseCode, "", out msg);
        }

		/// <summary>
		/// �|�����g�p���ĒP�����v�Z���܂��B
		/// </summary>
		/// <param name="stdPrice">����i</param>
		/// <param name="rate">�|��</param>
		/// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( double stdPrice, double rate, double fracProcUnit, int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 ) || ( fracProcCd == 0 ) || ( fracProcUnit == 0)) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// �e�������g�p���ĒP�����v�Z���܂��B
		/// </summary>
		/// <param name="costPrice">�����P��</param>
		/// <param name="marginRate">�e����</param>
		/// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns>�P��</returns>
		private double CalclateUnitPriceByMarginRate( double costPrice, double marginRate, double fracProcUnit, int fracProcCd )
		{
			if (( marginRate == 0 ) || ( costPrice == 0 ) || ( fracProcUnit == 0 ) || ( fracProcCd == 0 )) return 0;

			double unitPrice = costPrice / ( 1 - marginRate * 0.01 );

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// �P�����m�F���ʃI�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="unPrcInfoConf">�P�����m�F�I�u�W�F�N�g</param>
		/// <returns>�P�����m�F���ʃI�u�W�F�N�g</returns>
		private UnPrcInfoConfRet GetUnPrcInfoConfRet( UnPrcInfoConf unPrcInfoConf )
		{
			UnPrcInfoConfRet unPrcInfoConfRet = new UnPrcInfoConfRet();

            unPrcInfoConfRet.UnitPrcCalcDiv = unPrcInfoConf.UnitPrcCalcDiv;
            unPrcInfoConfRet.RateVal = unPrcInfoConf.RateVal;
            unPrcInfoConfRet.UnPrcFracProcUnit = unPrcInfoConf.UnPrcFracProcUnit;
            unPrcInfoConfRet.UnPrcFracProcDiv = unPrcInfoConf.UnPrcFracProcDiv;
            unPrcInfoConfRet.StdUnitPrice = unPrcInfoConf.StdUnitPrice;
            unPrcInfoConfRet.UnitPriceTaxExcFl = unPrcInfoConf.UnitPriceTaxExcFl;
            unPrcInfoConfRet.UnitPriceTaxIncFl= unPrcInfoConf.UnitPriceTaxIncFl;

			return unPrcInfoConfRet;
		}


		#endregion

		#region ��Static Methods
		/// <summary>
		/// ���t��������擾���܂��B
		/// </summary>
		/// <param name="date">���t</param>
		/// <param name="format">�t�H�[�}�b�g������</param>
		/// <returns>���t������</returns>
		private static string GetDateTimeString( DateTime date, string format )
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}
		/// <summary>
		/// �[�������敪���̂��擾���܂��B
		/// </summary>
		/// <param name="fracProcDiv">�[�������敪</param>
		/// <returns>�[�������敪����</returns>
		private static string GetFracProcDivName( int fracProcDiv )
		{
			switch (fracProcDiv)
			{
				case 1:
					return "�؎̂�";
				case 2:
					return "�l�̌ܓ�";
				case 3:
					return "�؏�";
				default:
					return "";
			}
		}

		#region �|���ݒ�敪����̊e���ڐݒ�擾
		/// <summary>
		/// �|���ݒ�敪���|���ݒ�敪(���i)���擾���܂��B
		/// </summary>
		/// <param name="rateDiv">�|���ݒ�敪</param>
		/// <returns>�|���ݒ�敪(���i)</returns>
		private static string GetRateMngGoodsCd( string rateDiv )
		{
			return ( rateDiv.Length > 0 ) ? rateDiv.Substring(0, 1) : "";
		}

		/// <summary>
		/// �|���ݒ�敪���|���ݒ�敪(���Ӑ�)���擾���܂��B
		/// </summary>
		/// <param name="rateDiv">�|���ݒ�敪</param>
		/// <returns>�|���ݒ�敪(���Ӑ�)</returns>
		private static string GetRateMngCustCd( string rateDiv )
		{
			return ( rateDiv.Length > 1 ) ? rateDiv.Substring(1, 1) : "";
		}

		/// <summary>
		/// �|���ݒ�敪���̎擾
		/// </summary>
		/// <param name="rateDiv">�|���ݒ�敪</param>
		/// <returns>�|���ݒ�敪����</returns>
		public static string GetRateDivName( string rateDiv )
		{
            string retString = "";

            DataRow[] dr = _rateMngTable.Select(string.Format("{0}='{1}'", RateMngGoodsCust.RATESETTINGDIVIDE, rateDiv));

            if (( dr != null ) && ( dr.Length > 0 ))
            {
                //retString = string.Format("{0}�{{1}", dr[0][RateMngGoodsCust.RATEMNGGOODSNM], dr[0][RateMngGoodsCust.RATEMNGCUSTNM]);//DEL 2013/04/12 xujx ���i�K�C�h�̏C��
                retString = string.Format("{0}�{{1}", dr[0][RateMngGoodsCust.RATEMNGCUSTNM], dr[0][RateMngGoodsCust.RATEMNGGOODSNM]);//ADD 2013/04/12 xujx ���i�K�C�h�̏C��
            }

			return retString;
		}

		/// <summary>
		/// �Ώە����񒆂ɁA��r�Ώۃ��X�g�Ɋ܂܂�镶���񂪑��݂��邩���擾���܂��B
		/// </summary>
		/// <param name="target">�Ώە�����</param>
		/// <param name="startIndex">�����񒆂̔�r�����J�n�ʒu</param>
		/// <param name="length">��r������̒���</param>
		/// <param name="judgmentList">��r�Ώۃ��X�g</param>
		/// <returns>true:���݂���</returns>
		private static bool IsSetting( string target, int startIndex, int length, List<string> judgmentList )
		{
			bool ret = false;
			if (target.Length >= ( startIndex + length ))
			{
				if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
			}
			return ret;
		}


		/// <summary>
		/// �P�����m�F�I�u�W�F�N�g���|���}�X�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="unitPriceInfoConf"></param>
		/// <returns></returns>
		private static Rate CreateRateFromUnitPriceInfoConf( UnPrcInfoConf unitPriceInfoConf )
		{
			Rate rate = new Rate();

			rate.RateSettingDivide = unitPriceInfoConf.RateSettingDivide;
			rate.SectionCode = unitPriceInfoConf.SectionCode;
			rate.RateMngGoodsCd = GetRateMngGoodsCd(unitPriceInfoConf.RateSettingDivide);
			rate.RateMngCustCd = GetRateMngCustCd(unitPriceInfoConf.RateSettingDivide);
            rate.GoodsNo = RateAcs.IsGoodsNoSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsNo : "";
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsMakerCd : 0;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsRateRank : "";
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(unitPriceInfoConf.RateSettingDivide) ? unitPriceInfoConf.SupplierCd : 0;

			return rate;

		}
		#endregion

		#endregion
	}
}
