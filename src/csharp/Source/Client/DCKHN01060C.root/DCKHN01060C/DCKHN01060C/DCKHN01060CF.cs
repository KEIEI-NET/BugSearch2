using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	internal static class DCKHN01060CF
	{
        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //		
        #region ��Public Members

		/// <summary>�[�������Ώۋ��z�敪�i���z�j</summary>
		public const int ctFracProcMoneyDiv_Price = 0;
		/// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
		public const int ctFracProcMoneyDiv_Tax = 1;
		/// <summary>�[�������Ώۋ��z�敪�i�P���j</summary>
		public const int ctFracProcMoneyDiv_UnitPrice = 2;
        ///// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        //public const int ctFracProcMoneyDiv_CostUnitPrice = 3;
        ///// <summary>�[�������Ώۋ��z�敪�i�����j</summary>
        //public const int ctFracProcMoneyDiv_CostPrice = 4;

		#endregion

        // ===================================================================================== //
        // �p�u���b�N �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //		
        #region ��Public Static Methods

		/// <summary>
		/// �[�������Ώۋ��z�ݒ�敪�ɏ]�����[�������P�ʂ̃f�t�H���g�l���擾���܂��B
		/// </summary>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <returns>�[�������P��</returns>
		public static double GetDefaultFractionProcUnit( int fracProcMoneyDiv )
		{
			switch (fracProcMoneyDiv)
			{
				// ���z�A�����A����ł�1�~�P��
				case ctFracProcMoneyDiv_Price:
				//case ctFracProcMoneyDiv_CostPrice:
				case ctFracProcMoneyDiv_Tax:
					{
						return 1;
					}
				default:
					{
						return 0.01;
					}
			}
		}

		/// <summary>
		/// �[�������敪�����l�擾
		/// </summary>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <returns>�[�������敪</returns>
		public static int GetDefaultFractionProcCd( int fracProcMoneyDiv )
		{
			// 1:�؎̂�
			return 1;
		}

        /// <summary>
        /// �d�����z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        internal class StockProcMoneyComparer : Comparer<StockProcMoney>
        {

            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        internal class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {

            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// �|���D��Ǘ��f�[�^��r�N���X(���_�R�[�h(����)�A�P�����(����)�A�|���D�揇��(����))
        /// </summary>
        /// <remarks></remarks>
        internal class RateProtyMngComparer : Comparer<RateProtyMng>
        {

            public override int Compare(RateProtyMng x, RateProtyMng y)
            {
                int result = x.SectionCode.CompareTo(y.SectionCode);
                if (result != 0) return result;

                result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                if (result != 0) return result;

                result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
                return result;
            }
        }

        /// <summary>
        /// �|���f�[�^��r�N���X(���b�g(����))
        /// </summary>
        /// <remarks></remarks>
        internal class RateComparer : Comparer<Rate>
        {
            public override int Compare(Rate x, Rate y)
            {
                int result = x.LotCount.CompareTo(y.LotCount);
                return result;
            }
        }

        // 2011/07/20 add wangf start
        /// <summary>
        /// �|���D��Ǘ��f�[�^��r�N���X(�P�����(����)�A�|���D�揇��(����)�A���_�R�[�h(�~��))
        /// </summary>
        /// <remarks></remarks>
        internal class RateProtyMngComparerUnitPriceKind : Comparer<RateProtyMng>
        {
            public override int Compare(RateProtyMng x, RateProtyMng y)
            {
                int result = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                if (result != 0) return result;

                result = x.RatePriorityOrder.CompareTo(y.RatePriorityOrder);
                if (result != 0) return result;

                result = y.SectionCode.CompareTo(x.SectionCode);
                return result;
            }
        }
        // 2011/07/20 add wangf end

		#endregion
	}
}
