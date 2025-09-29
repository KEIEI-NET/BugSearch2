using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���`�[���z�v�Z�N���X
    /// </summary>
    public class StockSlipPriceCalculator
    {
        /// <summary>
        /// �d�����v���z�ݒ菈��
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^���[�N</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        public static void TotalPriceSetting(ref StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWorkList, double taxFracProcUnit, int taxFracProcCd)
        {
            TotalPriceSettingProc(ref stockSlipWork, stockDetailWorkList, taxFracProcUnit, taxFracProcCd);
        }

        /// <summary>
        /// �d�����v���z�ݒ菈��
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^���[�N</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        private static void TotalPriceSettingProc(ref StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWork, double taxFracProcUnit, int taxFracProcCd)
        {
            long stockTtlPricTaxInc = 0;	// �d�����z�v�i�ō��݁j
            long stockTtlPricTaxExc = 0;	// �d�����z�v�i�Ŕ����j
            long stockPriceConsTax = 0;		// �d�����z����Ŋz
            long ttlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
            long ttlItdedStcInTax = 0;		// �d�����őΏۊz���v
            long ttlItdedStcTaxFree = 0;	// �d����ېőΏۊz���v
            long stockOutTax = 0;			// �d�����z����Ŋz�i�O�Łj
            long stckPrcConsTaxInclu = 0;	// �d�����z����Ŋz�i���Łj
            long stckDisTtlTaxExc = 0;		// �d���l�����z�v�i�Ŕ����j
            long itdedStockDisOutTax = 0;	// �d���l���O�őΏۊz���v
            long itdedStockDisInTax = 0;	// �d���l�����őΏۊz���v
            long itdedStockDisTaxFre = 0;	// �d���l����ېőΏۊz���v
            long stockDisOutTax = 0;		// �d���l������Ŋz�i�O�Łj
            long stckDisTtlTaxInclu = 0;	// �d���l������Ŋz�i���Łj
            long balanceAdjust = 0;			// �c�������z
            long taxAdjust = 0;				// ����Œ����z

            CalculateStockTotalPrice(stockDetailWork, stockSlipWork.StockGoodsCd, stockSlipWork.SupplierConsTaxRate, stockSlipWork.SuppTtlAmntDspWayCd, stockSlipWork.SuppCTaxLayCd, taxFracProcUnit, taxFracProcCd, out stockTtlPricTaxInc, out stockTtlPricTaxExc, out stockPriceConsTax, out ttlItdedStcOutTax, out ttlItdedStcInTax, out ttlItdedStcTaxFree, out stockOutTax, out stckPrcConsTaxInclu, out stckDisTtlTaxExc, out itdedStockDisOutTax, out itdedStockDisInTax, out itdedStockDisTaxFre, out stockDisOutTax, out stckDisTtlTaxInclu, out balanceAdjust, out taxAdjust);

            switch (stockSlipWork.StockGoodsCd)
            {
                case 2:	// ����Œ���
                case 4: // ���|�p����Œ���
                    {
                        stockSlipWork.StockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
                        stockSlipWork.StockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
                        stockSlipWork.StockPriceConsTax = taxAdjust;// �d�����z����Ŋz
                        stockSlipWork.TtlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
                        stockSlipWork.TtlItdedStcInTax = 0;			// �d�����őΏۊz���v
                        stockSlipWork.TtlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
                        stockSlipWork.StockOutTax = 0;				// �d�����z����Ŋz�i�O�Łj
                        stockSlipWork.StckPrcConsTaxInclu = 0;		// �d�����z����Ŋz�i���Łj
                        stockSlipWork.StckDisTtlTaxExc = 0;			// �d���l�����z�v�i�Ŕ����j
                        stockSlipWork.ItdedStockDisOutTax = 0;		// �d���l���O�őΏۊz���v
                        stockSlipWork.ItdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
                        stockSlipWork.ItdedStockDisTaxFre = 0;		// �d���l����ېőΏۊz���v
                        stockSlipWork.StockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
                        stockSlipWork.StckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
                        stockSlipWork.StockNetPrice = 0;			// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
                        stockSlipWork.StockTotalPrice = 0;			// �d�����z���v
                        stockSlipWork.StockSubttlPrice = 0;			// �d�����z���v
                        stockSlipWork.AccPayConsTax = taxAdjust;	// ���|�����
                        break;
                    }
                case 3: // �c������
                case 5: // ���|�p�c������
                    {
                        stockSlipWork.StockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
                        stockSlipWork.StockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
                        stockSlipWork.StockPriceConsTax = 0;        // �d�����z����Ŋz
                        stockSlipWork.TtlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
                        stockSlipWork.TtlItdedStcInTax = 0;			// �d�����őΏۊz���v
                        stockSlipWork.TtlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
                        stockSlipWork.StockOutTax = 0;				// �d�����z����Ŋz�i�O�Łj
                        stockSlipWork.StckPrcConsTaxInclu = 0;		// �d�����z����Ŋz�i���Łj
                        stockSlipWork.StckDisTtlTaxExc = 0;			// �d���l�����z�v�i�Ŕ����j
                        stockSlipWork.ItdedStockDisOutTax = 0;		// �d���l���O�őΏۊz���v
                        stockSlipWork.ItdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
                        stockSlipWork.ItdedStockDisTaxFre = 0;		// �d���l����ېőΏۊz���v
                        stockSlipWork.StockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
                        stockSlipWork.StckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
                        stockSlipWork.StockNetPrice = 0;			// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
                        stockSlipWork.StockTotalPrice = balanceAdjust;	// �d�����z���v
                        stockSlipWork.StockSubttlPrice = 0;			// �d�����z���v
                        stockSlipWork.AccPayConsTax = 0;			// ���|�����
                        break;
                    }
                default:
                    {
                        stockSlipWork.StockTtlPricTaxInc = stockTtlPricTaxInc;		// �d�����z�v�i�ō��݁j
                        stockSlipWork.StockTtlPricTaxExc = stockTtlPricTaxExc;		// �d�����z�v�i�Ŕ����j
                        stockSlipWork.StockPriceConsTax = stockPriceConsTax + stockSlipWork.TaxAdjust;		// �d�����z����Ŋz + ����Œ����z
                        stockSlipWork.TtlItdedStcOutTax = ttlItdedStcOutTax;		// �d���O�őΏۊz���v
                        stockSlipWork.TtlItdedStcInTax = ttlItdedStcInTax;			// �d�����őΏۊz���v
                        stockSlipWork.TtlItdedStcTaxFree = ttlItdedStcTaxFree;		// �d����ېőΏۊz���v
                        stockSlipWork.StockOutTax = stockOutTax;					// �d�����z����Ŋz�i�O�Łj
                        stockSlipWork.StckPrcConsTaxInclu = stckPrcConsTaxInclu;	// �d�����z����Ŋz�i���Łj
                        stockSlipWork.StckDisTtlTaxExc = stckDisTtlTaxExc;			// �d���l�����z�v�i�Ŕ����j
                        stockSlipWork.ItdedStockDisOutTax = itdedStockDisOutTax;	// �d���l���O�őΏۊz���v
                        stockSlipWork.ItdedStockDisInTax = itdedStockDisInTax;		// �d���l�����őΏۊz���v
                        stockSlipWork.ItdedStockDisTaxFre = itdedStockDisTaxFre;	// �d���l����ېőΏۊz���v
                        stockSlipWork.StockDisOutTax = stockDisOutTax;				// �d���l������Ŋz�i�O�Łj
                        stockSlipWork.StckDisTtlTaxInclu = stckDisTtlTaxInclu;		// �d���l������Ŋz�i���Łj
                        stockSlipWork.StockNetPrice = ttlItdedStcOutTax + ttlItdedStcInTax + ttlItdedStcTaxFree;	// �d���������z = �O�őΏۋ��z + ���őΏۋ��z + ��ېőΏۋ��z
                        stockSlipWork.StockTotalPrice = stockTtlPricTaxInc + ttlItdedStcTaxFree + itdedStockDisTaxFre + stockSlipWork.TaxAdjust + stockSlipWork.BalanceAdjust;		// �d�����z���v = �d�����z�v�i�ō��݁j+ �d����ېőΏۊz���v + �d����ېőΏۊz���v + ����Œ����z + �c�������z
                        stockSlipWork.StockSubttlPrice = stockTtlPricTaxExc + ttlItdedStcTaxFree + itdedStockDisTaxFre;					// �d�����z���v = �d�����z�v�i�Ŕ����j+ �d����ېőΏۊz���v + �d����ېőΏۊz���v
                        stockSlipWork.AccPayConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu + stockSlipWork.TaxAdjust;// ���|����� = �d�����z����Ŋz�i�O�Łj+ �d�����z����Ŋz�i���Łj+ �d���l������Ŋz�i�O�Łj+ �d���l������Ŋz�i���Łj+ ����Œ����z
                        break;
                    }
            }
        }


        /// <summary>
        /// �d�����z�̍��v���v�Z���܂��B
        /// </summary>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="stockGoodsCd">���i�敪</param>
        /// <param name="supplierConsTaxRate">�d�������Őŗ�</param>
        /// <param name="suppTtlAmntDspWayCd">�d���摍�z�\�����@�敪</param>
        /// <param name="suppCTaxLayCd">����œ]�ŕ���</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        /// <param name="stockTtlPricTaxInc">�d�����z�v�i�ō��݁j</param>
        /// <param name="stockTtlPricTaxExc">�d�����z�v�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�����z����Ŋz</param>
        /// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v</param>
        /// <param name="ttlItdedStcInTax">�d�����őΏۊz���v</param>
        /// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v</param>
        /// <param name="stockOutTax">�d�����z����Ŋz�i�O�Łj</param>
        /// <param name="stckPrcConsTaxInclu">�d�����z����Ŋz�i���Łj</param>
        /// <param name="stckDisTtlTaxExc">�d���l�����z�v�i�Ŕ����j</param>
        /// <param name="itdedStockDisOutTax">�d���l���O�őΏۊz���v</param>
        /// <param name="itdedStockDisInTax">�d���l�����őΏۊz���v</param>
        /// <param name="itdedStockDisTaxFre">�d���l����ېőΏۊz���v</param>
        /// <param name="stockDisOutTax">�d���l������Ŋz�i�O�Łj</param>
        /// <param name="stckDisTtlTaxInclu">�d���l������Ŋz�i���Łj</param>
        /// <param name="balanceAdjust">�c���������v�z</param>
        /// <param name="taxAdjust">����ō��v�z</param>
        private static void CalculateStockTotalPrice(List<StockDetailWork> stockDetailWorkList, int stockGoodsCd, double supplierConsTaxRate, int suppTtlAmntDspWayCd, int suppCTaxLayCd, double taxFracProcUnit, int taxFracProcCd, out long stockTtlPricTaxInc, out long stockTtlPricTaxExc, out long stockPriceConsTax, out long ttlItdedStcOutTax, out long ttlItdedStcInTax, out long ttlItdedStcTaxFree, out long stockOutTax, out long stckPrcConsTaxInclu, out long stckDisTtlTaxExc, out long itdedStockDisOutTax, out long itdedStockDisInTax, out long itdedStockDisTaxFre, out long stockDisOutTax, out long stckDisTtlTaxInclu, out long balanceAdjust, out long taxAdjust)
        {
            stockTtlPricTaxInc = 0;		// �d�����z�v�i�ō��݁j
            stockTtlPricTaxExc = 0;		// �d�����z�v�i�Ŕ����j
            stockPriceConsTax = 0;		// �d�����z����Ŋz
            ttlItdedStcOutTax = 0;		// �d���O�őΏۊz���v
            ttlItdedStcInTax = 0;		// �d�����őΏۊz���v
            ttlItdedStcTaxFree = 0;		// �d����ېőΏۊz���v
            stockOutTax = 0;			// �d�����z����Ŋz�i�O�Łj
            stckPrcConsTaxInclu = 0;	// �d�����z����Ŋz�i���Łj
            stckDisTtlTaxExc = 0;		// �d���l�����z�v�i�Ŕ����j
            itdedStockDisOutTax = 0;	// �d���l���O�őΏۊz���v
            itdedStockDisInTax = 0;		// �d���l�����őΏۊz���v
            itdedStockDisTaxFre = 0;	// �d���l����ېőΏۊz���v
            stockDisOutTax = 0;			// �d���l������Ŋz�i�O�Łj
            stckDisTtlTaxInclu = 0;		// �d���l������Ŋz�i���Łj
            balanceAdjust = 0;			// �c�������z
            taxAdjust = 0;				// ����Œ����z

            long ttlItdedStcInTax_TaxInc = 0;       // �d�����őΏۊz���v�i�ō��j

            long itdedStockDisInTax_TaxInc = 0;     // �l�����őΏۋ��z���v(�ō���)

            //--------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //--------------------------------------------------
            #region �v�Z�ɕK�v�ȋ��z�̌v�Z
            foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
            {
                // �d���O�őΏۊz���v
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcOutTax += stockDetailWork.StockPriceTaxExc;
                }

                // �d�����z����Ŋz�i�O�Łj
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    stockOutTax += stockDetailWork.StockPriceConsTax;
                }

                // �d�����őΏۊz���v
                if (( stockDetailWork.TaxationCode ==  (int)CalculateTax.TaxationCode.TaxInc) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcInTax += stockDetailWork.StockPriceTaxExc;
                }

                // �d�����őΏۊz���v�i�ō��j
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcInTax_TaxInc += stockDetailWork.StockPriceTaxInc;
                }

                // �d�����z����Ŋz�i���Łj
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    stckPrcConsTaxInclu += stockDetailWork.StockPriceConsTax;
                }

                // �d����ېőΏۊz���v
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) &&
                    ( stockDetailWork.StockSlipCdDtl != 2 ))
                {
                    ttlItdedStcTaxFree += stockDetailWork.StockPriceTaxInc;
                }

                // �d���l���O�őΏۊz���v
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisOutTax += stockDetailWork.StockPriceTaxExc;
                }

                // �d���l������Ŋz�i�O�Łj
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    stockDisOutTax += stockDetailWork.StockPriceConsTax;
                }

                // �d���l�����őΏۊz���v
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisInTax += stockDetailWork.StockPriceTaxExc;
                }

                // �l�����őΏۋ��z���v(�ō���)
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisInTax_TaxInc += stockDetailWork.StockPriceTaxInc;
                }

                // �d���l������Ŋz�i���Łj
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    stckDisTtlTaxInclu += stockDetailWork.StockPriceConsTax;
                }

                // �d���l����ېőΏۊz���v
                if (( stockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone ) &&
                    ( stockDetailWork.StockSlipCdDtl == 2 ))
                {
                    itdedStockDisTaxFre += stockDetailWork.StockPriceTaxInc;
                }

                // �c�������z
                if (( stockDetailWork.StockGoodsCd == 3 ) ||
                    ( stockDetailWork.StockGoodsCd == 5 ))
                {
                    balanceAdjust += stockDetailWork.StockPriceTaxInc;
                }

                // ����Œ����z
                if (( stockDetailWork.StockGoodsCd == 2 ) ||
                    ( stockDetailWork.StockGoodsCd == 4 ))
                {
                    taxAdjust += stockDetailWork.StockPriceConsTax;
                }
            }

            // �d���l�����z�v�i�Ŕ����j = �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v + �d���l����ېőΏۊz���v
            stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;

            #endregion

            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            if (suppCTaxLayCd == 9)
            {
                // �d�����z����Ŋz�i�O�Łj
                stockOutTax = 0;

                // �d�����z����Ŋz�i���Łj
                stckPrcConsTaxInclu = 0;

                // �d����ېőΏۊz���v = �d����ېőΏۊz���v + �d���O�őΏۊz���v + �d�����őΏۊz���v
                ttlItdedStcTaxFree += ttlItdedStcOutTax + ttlItdedStcInTax;

                // �d���O�őΏۊz���v
                ttlItdedStcOutTax = 0;

                // �d�����őΏۊz���v
                ttlItdedStcInTax = 0;

                // �d�����őΏۊz���v�i�ō��j
                ttlItdedStcInTax_TaxInc = 0;

                // �d���l������Ŋz�i�O�Łj
                stockDisOutTax = 0;

                // �d���l������Ŋz�i���Łj
                stckDisTtlTaxInclu = 0;

                // �d���l����ېőΏۊz���v = �d���l����ېőΏۊz���v + �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v
                itdedStockDisTaxFre += itdedStockDisOutTax + itdedStockDisInTax;

                // �d���l���O�őΏۊz���v
                itdedStockDisOutTax = 0;

                // �d���l�����őΏۊz���v
                itdedStockDisInTax = 0;

                // �d���l�����őΏۊz���v�i�ō�)
                itdedStockDisInTax_TaxInc = 0;

                // �d���l�����z�v�i�Ŕ����j = �d���l���O�őΏۊz���v + �d���l�����őΏۊz���v + �d���l����ېőΏۊz���v
                stckDisTtlTaxExc = itdedStockDisOutTax + itdedStockDisInTax + itdedStockDisTaxFre;
            }

            if (stockGoodsCd == 6)
            {
                // ���z�\��
                if (suppTtlAmntDspWayCd == 1)
                {
                    //--------------------------------------------------
                    // �@ �d�����z�v�i�ō��݁j�F�d���O�őΏۊz���v + �d�����z����Ŋz�i�O�Łj+ �d���l���O�őΏۊz���v + �d���l������Ŋz�i�O�Łj + �d�����őΏۊz���v�i�ō��j +  �l�����őΏۋ��z���v(�ō���)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcOutTax + stockOutTax + itdedStockDisOutTax + stockDisOutTax + ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc;

                    //--------------------------------------------------
                    // �A �d�����z����Ŋz�F�����(����) + �����(�O��)
                    //--------------------------------------------------
                    stockPriceConsTax = stckPrcConsTaxInclu + stockOutTax;

                    //--------------------------------------------------
                    // �B �d�����z�v�i�Ŕ����j�F�@ - �A
                    //--------------------------------------------------
                    stockTtlPricTaxExc = stockTtlPricTaxInc - stockPriceConsTax;
                }
                else
                {
                    //--------------------------------------------------
                    // �@ �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // �A �d�����z����Ŋz�F�����(����) + �����(�O��)
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu;

                    //--------------------------------------------------
                    // �B �d�����z�v�i�ō��j�F�@ + �A
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
                }
            }
            else
            {
                // ���ד]�ňȊO
                if (suppCTaxLayCd != 1)
                {
                    //--------------------------------------------------
                    // �@ �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v 
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // �A �d�����z�v(�ō���)�F�d�����őΏۊz���v(�ō���) + �l�����őΏۊz���v(�ō���) + �d���O�őΏۊz���v + �l���O�őΏۋ��z���v �{ (�d���O�őΏۊz���v + �l���O�őΏۋ��z���v)�~�ŗ�)
                    //--------------------------------------------------
                    stockTtlPricTaxInc = ttlItdedStcInTax_TaxInc + itdedStockDisInTax_TaxInc + ttlItdedStcOutTax + itdedStockDisOutTax + CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // �B ����ō��v�F�A - �@
                    //--------------------------------------------------
                    stockPriceConsTax = stockTtlPricTaxInc - stockTtlPricTaxExc;

                    //--------------------------------------------------
                    // �C �d�����z����Ŋz�i�O�Łj�F�d���O�őΏۊz���v �~ �ŗ�
                    //--------------------------------------------------
                    stockOutTax = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax);

                    //--------------------------------------------------
                    // �D �O�őΏۏ����(�Ŕ����A�l�����܂�) �F(�d���O�őΏۊz���v + �d���l���O�őΏۊz���v) �~ �ŗ�
                    //--------------------------------------------------
                    long stockOutTax_All = CalculateTax.GetTaxFromPriceExc(supplierConsTaxRate, taxFracProcUnit, taxFracProcCd, ttlItdedStcOutTax + itdedStockDisOutTax);

                    //--------------------------------------------------
                    // �E �l���O�ŏ���ō��v�F�C - �D
                    //--------------------------------------------------
                    stockDisOutTax = stockOutTax_All - stockOutTax;
                }
                // ���ד]��
                else
                {
                    //--------------------------------------------------
                    // �@ �d�����z����Ŋz�F�d�����z����Ŋz�i�O�Łj + �d�����z����Ŋz�i���Łj +  �d���l������Ŋz�i�O�Łj + �d���l������Ŋz�i���Łj
                    //--------------------------------------------------
                    stockPriceConsTax = stockOutTax + stckPrcConsTaxInclu + stockDisOutTax + stckDisTtlTaxInclu;

                    //--------------------------------------------------
                    // �A �d�����z�v(�Ŕ���)�F�d���O�őΏۊz���v + �d�����őΏۊz���v + �l���O�őΏۋ��z���v + �l�����őΏۋ��z���v
                    //--------------------------------------------------
                    stockTtlPricTaxExc = ttlItdedStcOutTax + ttlItdedStcInTax + itdedStockDisOutTax + itdedStockDisInTax;

                    //--------------------------------------------------
                    // �B �d�����z�v(�ō���)�F�@ + �A
                    //--------------------------------------------------
                    stockTtlPricTaxInc = stockTtlPricTaxExc + stockPriceConsTax;
                }
            }
        }
    }
}
