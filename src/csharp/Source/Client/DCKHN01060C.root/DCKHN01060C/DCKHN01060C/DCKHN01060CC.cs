using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ����Ōv�Z�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����ł̌v�Z���s���܂��B</br>
	/// <br>Programmer : 21024�@���X�� ��</br>
	/// <br>Date       : 2008.06.19</br>
	/// </remarks>
	public static class CalculateTax
	{
        // ===================================================================================== //
        // �񋓌^
        // ===================================================================================== //		
        #region ��Enums
		/// <summary>
		/// �ېŋ敪
		/// </summary>
		public enum TaxationCode : int
		{
			/// <summary>�O��</summary>
			TaxExc = 0,
			/// <summary>��ې�</summary>
			TaxNone = 1,
			/// <summary>����</summary>
			TaxInc = 2,
		}
		#endregion

        // ===================================================================================== //
        // �p�u���b�N �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //		
        #region ��Public Static Methods

        /// <summary>
        /// �Ŕ������z�A�ō����z���Z�肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxfracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        /// <param name="priceConsTax">����ŋ��z</param>
        public static void CalculatePrice( int taxationCode, double targetPrice, double taxRate, double taxfracProcUnit, int taxFracProcCd, out double priceTaxExc, out double priceTaxInc, out double priceConsTax )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceConsTax = 0;
            switch (taxationCode)
            {
                // �O��
                case (int)CalculateTax.TaxationCode.TaxExc:
                    {
                        priceTaxExc = targetPrice;
                        CalcTaxIncFromTaxExc(taxationCode, ref priceTaxExc, out priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // ����
                case (int)CalculateTax.TaxationCode.TaxInc:
                    {
                        priceTaxInc = targetPrice;
                        CalcTaxExcFromTaxInc(taxationCode, out priceTaxExc, ref priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // ��ې�
                case (int)CalculateTax.TaxationCode.TaxNone:
                    {
                        priceTaxInc = targetPrice;
                        priceTaxExc = targetPrice;
                        priceConsTax = 0;
                        break;
                    }
            }
        }

        /// <summary>
        /// �Ŕ������z�A�ō����z���Z�肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxfracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        /// <param name="priceConsTax">����ŋ��z</param>
        public static void CalculatePrice( int taxationCode, long targetPrice, double taxRate, double taxfracProcUnit, int taxFracProcCd, out long priceTaxExc, out long priceTaxInc, out long priceConsTax )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            priceConsTax = 0;
            switch (taxationCode)
            {
                // �O��
                case (int)CalculateTax.TaxationCode.TaxExc:
                    {
                        priceTaxExc = targetPrice;
                        CalcTaxIncFromTaxExc(taxationCode, ref priceTaxExc, out priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // ����
                case (int)CalculateTax.TaxationCode.TaxInc:
                    {
                        priceTaxInc = targetPrice;
                        CalcTaxExcFromTaxInc(taxationCode, out priceTaxExc, ref priceTaxInc, out priceConsTax, taxRate, taxfracProcUnit, taxFracProcCd);
                        break;
                    }
                // ��ې�
                case (int)CalculateTax.TaxationCode.TaxNone:
                    {
                        priceTaxInc = targetPrice;
                        priceTaxExc = targetPrice;
                        priceConsTax = 0;
                        break;
                    }
            }
        }

		/// <summary>
		/// �ō��݉��i�Z��i���z(�Ŕ�)��艿�i�Z��j�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public static void CalcTaxIncFromTaxExc( int taxationCode, ref double priceExc, out double priceInc, out double priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// ����Ŋz���擾
			priceTax = (long)CalculateTax.Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);

			priceInc = priceExc + priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// ���ł̏ꍇ
				CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// �ō��݉��i�Z��i���z(�Ŕ�)��艿�i�Z��j�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public static void CalcTaxIncFromTaxExc( int taxationCode, ref long priceExc, out long priceInc, out long priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// ����Ŋz���擾
			priceTax = (long)CalculateTax.Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);

			priceInc = priceExc + priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// ���ł̏ꍇ
				CalcTaxExcFromTaxInc(taxationCode, out priceExc, ref priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// �Ŕ������i�Z��i�P��(�ō�),�ŗ���艿�i�Z��j�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public static void CalcTaxExcFromTaxInc( int taxationCode, out double priceExc, ref double priceInc, out double priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// ����Ŋz���Z�� ��� �i���z(�ō�) �~ ����ŗ��j���i�P�D�O �{ ����ŗ��j
			priceTax = GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);
			priceExc = priceInc - priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// �O�Ł����Ōv�Z���s���I
				CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// �Ŕ������i�Z��i�P��(�ō�),�ŗ���艿�i�Z��j�i�I�[�o�[���[�h�j
		/// </summary>
		/// <param name="taxationCode">�ېŋ敪�F0:�ې�,1:��ې�,2:�ېŁi���Łj</param>
		/// <param name="priceExc">���i�i�Ŕ����j</param>
		/// <param name="priceInc">���i�i�ō��݁j</param>
		/// <param name="priceTax">���i�i����Łj</param>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		public static void CalcTaxExcFromTaxInc( int taxationCode, out long priceExc, ref long priceInc, out long priceTax, double taxRate, double taxFracProcUnit, int taxFracProcCd )
		{
			// ����Ŋz���Z�� ��� �i���z(�ō�) �~ ����ŗ��j���i�P�D�O �{ ����ŗ��j
			priceTax = GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, priceInc);
			priceExc = priceInc - priceTax;

			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// �O�Ł����Ōv�Z���s���I
				CalcTaxIncFromTaxExc(taxationCode, ref priceExc, out priceInc, out priceTax, taxRate, taxFracProcUnit, taxFracProcCd);
			}
		}

		/// <summary>
		/// �ō��݋��z�������ŋ��z���Z��
		/// </summary>
		/// <param name="taxRate">����ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="priceInc">�ō��ݒP��</param>
		/// <returns>����ŋ��z</returns>
		public static long GetTaxFromPriceInc( double taxRate, double taxFracProcUnit, int taxFracProcCd, double priceInc )
		{
			double base_double_rate = CalculateConsTax.Round(taxRate * 1000);
			int base_int32_rate = (int)base_double_rate;

			long priceIncInteger = (Int64)priceInc;
			double priceIncDecimal = (double)( (decimal)priceInc % 1 );

			priceIncDecimal = CalculateConsTax.Round(priceIncDecimal * 10);
			long base_int64_priceinc = ( priceIncInteger * 10 ) + (long)priceIncDecimal;

			long base_int64_tax = base_int64_priceinc * base_int32_rate;
			double base_double_tax = base_int64_tax / ( 1000 + base_int32_rate );
			base_double_tax /= 10;
			base_double_tax = Fraction(base_double_tax, taxFracProcUnit, taxFracProcCd);
			return (long)base_double_tax;
		}

		/// <summary>
		/// �Ŕ������z�������ŋ��z���Z��
		/// </summary>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������敪</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="priceExc">�P��</param>
		/// <returns>�����</returns>
		public static long GetTaxFromPriceExc( double taxRate, double taxFracProcUnit, int taxFracProcCd, double priceExc )
		{
			return (long)Fraction(priceExc * taxRate, taxFracProcUnit, taxFracProcCd);
		}

		/// <summary>
		/// �[������
		/// </summary>
		/// <param name="targetPrice">�����</param>
		/// <param name="fracProcUnit">����Œ[�������P��</param>
		/// <param name="fracProcCd">����Œ[�������敪</param>
		/// <returns>�[���������������</returns>
		private static double Fraction( double targetPrice, double fracProcUnit, int fracProcCd )
		{
			double retValue;
			FractionCalculate.FracCalcMoney(targetPrice, fracProcUnit, fracProcCd, out retValue);

			return retValue;
		}

		#endregion
	}
}
