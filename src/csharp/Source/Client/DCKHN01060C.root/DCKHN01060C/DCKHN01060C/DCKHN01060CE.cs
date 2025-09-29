using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library;
using Broadleaf.Application.UIData;
using System.Data;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ������z�v�Z�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����Ɋւ�����z�̌v�Z���s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.06.19</br>
	/// </remarks>
	public class SalesPriceCalculate
	{
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //		
        #region ��Private Member

		private List<SalesProcMoney> _salesProcMoneyList;

		#endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //		
        #region ��Constructor

		/// <summary>
        /// �R���X�g���N�^
		/// </summary>
		public SalesPriceCalculate()
		{
		}

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="salesProcMoneyList">������z�����敪�ݒ�}�X�^���X�g</param>
        public SalesPriceCalculate( List<SalesProcMoney> salesProcMoneyList )
        {
            this.CacheSalesProcMoneyList(salesProcMoneyList);
        }

		#endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //		
        #region ��Public Method

		/// <summary>
		/// ������z�[�������敪�ݒ�}�X�^�L���b�V��
		/// </summary>
		/// <param name="salesProcMoneyList">������z�����敪�ݒ�}�X�^���X�g</param>
		public void CacheSalesProcMoneyList( List<SalesProcMoney> salesProcMoneyList )
		{
			this._salesProcMoneyList = salesProcMoneyList;

            this._salesProcMoneyList.Sort(new DCKHN01060CF.SalesProcMoneyComparer());
        }

		#region �������z�Z��p���\�b�h
#if false
		/// <summary>
		/// �������z�ō��݉��i�Z��i���ʁA�P���i�Ŕ����j�A���z�i�ō��j��艿�i�Z��j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public void CalcCostTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxIncFromTaxExc(taxationCode, 
									  count, 
									  ref unitPriceExc, 
									  out unitPriceInc, 
									  out unitPriceTax, 
									  ref priceExc, 
									  out priceInc, 
									  out priceTax, 
									  DCKHN01060CF.ctFracProcMoneyDiv_CostPrice, 
									  fractionProcCode, 
									  taxRate, 
									  taxFracProcUnit, 
									  taxFracProcCd);
        }
#endif

#if false
		/// <summary>
		/// �����Ŕ������i�Z�菈���i����,�P��(�ō�),���z(�ō�)��艿�i�Z��j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public void CalcCostTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxExcFromTaxInc(taxationCode,
									  count,
									  out unitPriceExc,
									  ref unitPriceInc,
									  out unitPriceTax,
									  out priceExc,
									  ref priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_CostPrice,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}
#endif
        #endregion

        /// <summary>
        /// �Ŕ������z�A�ō����z���Z�肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        /// <param name="priceConsTax">����ŋ��z</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalculatePrice( int taxationCode, double targetPrice, double taxRate, int salesCnsTaxFrcProcCd, out double priceTaxExc, out double priceTaxInc, out double priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }

        /// <summary>
        /// �Ŕ������z�A�ō����z���Z�肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        /// <param name="priceConsTax">����ŋ��z</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalculatePrice( int taxationCode, long targetPrice, double taxRate, int salesCnsTaxFrcProcCd, out long priceTaxExc, out long priceTaxInc, out long priceConsTax, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, targetPrice, out taxFracProcUnit, out taxFracProcCd);

            CalculateTax.CalculatePrice(taxationCode, targetPrice, taxRate, taxFracProcUnit, taxFracProcCd, out priceTaxExc, out priceTaxInc, out priceConsTax);
        }

        #region ������z�p���\�b�h

        /// <summary>
        /// ����ō��݉��i�Z��i���ʁA�P���i�Ŕ����j�A���z�i�ō��j��艿�i�Z��j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
        /// <param name="count">����</param>
        /// <param name="unitPriceExc">�P���i�Ŕ����j</param>
        /// <param name="unitPriceInc">�P���i�ō��݁j</param>
        /// <param name="unitPriceTax">�P���i����Łj</param>
        /// <param name="priceExc">���i�i�Ŕ����j</param>
        /// <param name="priceInc">���i�i�ō��݁j</param>
        /// <param name="priceTax">���i�i����Łj</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
            ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, int salesCnsTaxFrcProcCd, double taxRate, out double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxIncFromTaxExc(taxationCode,
                                      count,
                                      ref unitPriceExc,
                                      out unitPriceInc,
                                      out unitPriceTax,
                                      ref priceExc,
                                      out priceInc,
                                      out priceTax,
                                      DCKHN01060CF.ctFracProcMoneyDiv_Price,
                                      fractionProcCode,
                                      taxRate,
                                      taxFracProcUnit,
                                      taxFracProcCd);
        }

        /// <summary>
        /// ����ō��݉��i�Z��i���ʁA�P���i�Ŕ����j�A���z�i�ō��j��艿�i�Z��j�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxIncFromTaxExc(taxationCode,
									  count,
									  ref unitPriceExc,
									  out unitPriceInc,
									  out unitPriceTax,
									  ref priceExc,
									  out priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_Price,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}

        /// <summary>
        /// ����Ŕ������i�Z�菈���i����,�P��(�ō�),���z(�ō�)��艿�i�Z��j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
        /// <param name="count">����</param>
        /// <param name="unitPriceExc">�P���i�Ŕ����j</param>
        /// <param name="unitPriceInc">�P���i�ō��݁j</param>
        /// <param name="unitPriceTax">�P���i����Łj</param>
        /// <param name="priceExc">���i�i�Ŕ����j</param>
        /// <param name="priceInc">���i�i�ō��݁j</param>
        /// <param name="priceTax">���i�i����Łj</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
            out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, int salesCnsTaxFrcProcCd, double taxRate, out  double taxFracProcUnit, out int taxFracProcCd )
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalcTaxExcFromTaxInc(taxationCode,
                                      count,
                                      out unitPriceExc,
                                      ref unitPriceInc,
                                      out unitPriceTax,
                                      out priceExc,
                                      ref priceInc,
                                      out priceTax,
                                      DCKHN01060CF.ctFracProcMoneyDiv_Price,
                                      fractionProcCode,
                                      taxRate,
                                      taxFracProcUnit,
                                      taxFracProcCd);
        }

		/// <summary>
        /// ����Ŕ������i�Z�菈���i����,�P��(�ō�),���z(�ō�)��艿�i�Z��j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
        public void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			this.CalcTaxExcFromTaxInc(taxationCode,
									  count,
									  out unitPriceExc,
									  ref unitPriceInc,
									  out unitPriceTax,
									  out priceExc,
									  ref priceInc,
									  out priceTax,
									  DCKHN01060CF.ctFracProcMoneyDiv_Price,
									  fractionProcCode,
									  taxRate,
									  taxFracProcUnit,
									  taxFracProcCd);
		}

        /// <summary>
        /// ������z�̊ۂߏ������s���܂��B
        /// </summary>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="salesMoney">������z</param>
        /// <returns>�܂�߂�������z</returns>
        public long RoundSalesMoney(int fractionProcCode, long salesMoney)
        {
            double fractionProcUnit;
            int fractionProcCd;

            return this.RoundSalesMoneyProc(salesMoney, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

        /// <summary>
        /// ������z�̊ۂߏ������s���܂��B
        /// </summary>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="salesMoney">������z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <returns>�܂�߂�������z</returns>
        public long RoundSalesMoney(int fractionProcCode, long salesMoney, out double fractionProcUnit, out int fractionProcCd)
        {
            return this.RoundSalesMoneyProc(salesMoney, fractionProcCode, out fractionProcUnit, out fractionProcCd);
        }

		#endregion

		#region ���z�v�Z
		/// <summary>
		/// �ō��݉��i�Z��i����,�P��(�Ŕ�),���z(�Ŕ�)��艿�i�Z��j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fracProcMoneyDiv">�[���������z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		private void CalcTaxIncFromTaxExc( int taxationCode, double count, ref double unitPriceExc, out double unitPriceInc, out double unitPriceTax,
			ref long priceExc, out long priceInc, out long priceTax, int fracProcMoneyDiv, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// �Ŕ����P�����O�~�̏ꍇ
			if (unitPriceExc == 0)
			{
				CalculateTax.CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);

				// �ō��ݒP�����O�~
				unitPriceInc = 0;

				// ����Ŋz(�P��)���O�~
				unitPriceTax = 0;
			}
			else
			{
				// ��ېł̏ꍇ�͐ŗ����O�ɂ���
				if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
				{
					taxRate = 0;
				}

				// �@ ����Ŋz(�P��)���Z�肷��        (����Ŋz(�P��)��(�Ŕ����P���~����ŗ�))
				unitPriceTax = CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceExc);

				// �A �ō��ݒP�����Z�肷��            (�ō��ݒP�����Ŕ����P���{����Ŋz(�P��))
				unitPriceInc = unitPriceExc + unitPriceTax;

				// �B �ō��݉��i���Z�肷��
				if (( taxationCode == (int)CalculateTax.TaxationCode.TaxExc ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
				{
					// �O�ŁA��ېł̏ꍇ

					// �B�|�P �Ŕ������i���Z�肷��    (�Ŕ������i�����ʁ~�Ŕ����P��)
					priceExc = this.CalcPrice(count, unitPriceExc, fracProcMoneyDiv, fractionProcCode);

					// �B�|�Q ����Ŋz(���i)���Z�肷��(����Ŋz(���i)���Ŕ������i�~����ŗ�)
					priceTax = CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, priceExc);

					// �B�|�R �ō��݉��i���Z�肷��    (�ō��݉��i���Ŕ������i�{����Ŋz(���i))
					priceInc = priceExc + priceTax;
				}
				else
				{
					// ���ł̏ꍇ

					// �B�|�S �ō��݉��i���Z�o        (�ō��݉��i�����ʁ~�ō��ݒP��)
					priceInc = this.CalcPrice(count, unitPriceInc, fracProcMoneyDiv, fractionProcCode);

					// �ō��݂���Ŕ������Z�肵�Ȃ���
					CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcMoneyDiv, fractionProcCode, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}

		/// <summary>
		/// �Ŕ������i�Z�菈���i����,�P��(�ō�),���z(�ō�)��艿�i�Z��j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="count">����</param>
		/// <param name="unitPriceExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceInc">�P���i�ō��݁j</param>
		/// <param name="unitPriceTax">�P���i����Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
        private void CalcTaxExcFromTaxInc( int taxationCode, double count, out double unitPriceExc, ref double unitPriceInc, out double unitPriceTax,
			out long priceExc, ref long priceInc, out long priceTax, int fracProcMoneyDiv, int fractionProcCode, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// �ō��ݒP�����O�~�̏ꍇ
			if (unitPriceInc == 0)
			{
				CalculateTax.CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);

				// �Ŕ����P�����O�~
				unitPriceExc = 0;

				// ����Ŋz(�P��)���O�~
				unitPriceTax = 0;
			}
			else
			{
				// ��ېł̏ꍇ�͏���ŗ����O�ɂ���
				if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
				{
					taxRate = 0;
				}

				// �@ ����Ŋz(�P��)���Z�肷��        (����Ŋz(�P��)��(�ō��ݒP���~����ŗ�)��(�P�D�O�{����ŗ�))
				unitPriceTax = CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceInc);

				// �A �Ŕ����P�����Z�肷��            (�Ŕ����P�����ō��ݒP���|����Ŋz(�P��))
				unitPriceExc = unitPriceInc - unitPriceTax;

				if (( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) || ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
				{
					// ���ł̏ꍇ
					// �B�|�P �ō��݉��i���Z�o        (�ō��݉��i�����ʁ~�ō��ݒP��)
					priceInc = this.CalcPrice(count, unitPriceInc, fracProcMoneyDiv, fractionProcCode);

					// �B�|�Q ����Ŋz(���i)���Z�肷��(����Ŋz(���i)��(�ō��݉��i�~����ŗ�)��(�P�D�O�{����ŗ�))
					priceTax = CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);

					// �B�|�R �Ŕ������i���Z�肷��    (�Ŕ������i���ō��݉��i�|����Ŋz(���i)
					priceExc = priceInc - priceTax;
				}
				else
				{
					// �O�ł̏ꍇ
					// �B�|�S   �Ŕ������i���Z�肷��  (�Ŕ������i�����ʁ~�Ŕ����P��)
					priceExc = this.CalcPrice(count, unitPriceExc, fracProcMoneyDiv, fractionProcCode);
					// �Ŕ�������ō��݂��Z�肵����
					CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcMoneyDiv, fractionProcCode, taxRate, taxFracProcUnit, taxFracProcCd);
				}
			}
		}
		#endregion

		#region �e���֌W

		/// <summary>
		/// �e�����Z��i�[�������P��:0.001�~�A�[�������敪:�l�̌ܓ�)�Œ�
		/// </summary>
		/// <param name="unitCost">����</param>
		/// <param name="salesPrice">������z</param>
		/// <returns></returns>
		public double CalculateMarginRate( double unitCost, double salesPrice )
		{
			// �[�������Œ�ďo
			return this.CalcRateFrac(unitCost, salesPrice);
		}

		#endregion

		#endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //		
        #region ��Private Method

		/// <summary>
		/// ���z�v�Z
		/// </summary>
		/// <param name="count">����</param>	
		/// <param name="unitPrice">�P��</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>	
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <returns>�[�������������z</returns>
		private long CalcPrice( double count, double unitPrice, int fracProcMoneyDiv, int fractionProcCode )
		{
			// ���̂܂܌v�Z�i���ʁ~�P���j
			double retPrice = unitPrice * count;

			// �[���������@���擾
			double fracProcUnit;
			int fracProcCd;
			this.GetSalesFractionProcInfo(fracProcMoneyDiv, fractionProcCode, retPrice, out fracProcUnit, out fracProcCd);

			//�@�[������
			FractionCalculate.FracCalcMoney(retPrice, fracProcUnit, fracProcCd, out retPrice);

			return (long)retPrice;
		}

        /// <summary>
        /// ���z�܂�ߏ���
        /// </summary>
        /// <param name="salesMoney">������z</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="fracProcUnit">�[�������P��</param>
        /// <param name="fracProcCd">�[�������敪</param>
        /// <returns>�܂�߂�������z</returns>
        private long RoundSalesMoneyProc(long salesMoney, int fractionProcCode, out double fracProcUnit, out int fracProcCd)
        {
            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Price, fractionProcCode, salesMoney, out fracProcUnit, out fracProcCd);

            //�@�[������
            long retPrice;
            FractionCalculate.FracCalcMoney(salesMoney, fracProcUnit, fracProcCd, out retPrice);

            return retPrice;
        }

		/// <summary>
		/// �P���܂�ߏ���
		/// </summary>
		/// <param name="unitPrice">�P��</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns>�܂�߂��P��</returns>
		private double RountSalesUnitPrice( double unitPrice, int fractionProcCode, out double fracProcUnit, out int fracProcCd )
		{
			this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, unitPrice, out fracProcUnit, out fracProcCd);

			//�@�[������
			double retPrice;
			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out retPrice);

			return retPrice;
		}

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
		/// </summary>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="price">�Ώۋ��z</param>
		/// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		private void GetSalesFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
			fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
			fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoney> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoney salesProcMoney)
                                        {
                                            if (( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( salesProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( salesProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
		}

		/// <summary>
		/// ���[������
		/// </summary>
		/// <param name="numerator">���l(���q)</param>
		/// <param name="denominator">���l(����)</param>
		/// <returns></returns>
		private double CalcRateFrac( double numerator, double denominator )
		{
			double fracProcUnit = 0.0001; // �����_�ȉ���R��
			int fracProcCd = 2; // �l�̌ܓ�

			//�@�[������
			double retRate;
			FractionCalculate.FracCalcRate(numerator, denominator, fracProcUnit, fracProcCd, out retRate);

			return retRate;
		}

		#endregion
	}
}
