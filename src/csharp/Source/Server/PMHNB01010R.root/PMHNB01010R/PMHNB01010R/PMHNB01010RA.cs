using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �P���Z�o�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �|���ɏ]���Ďd���P���̎Z�o���s���܂��B�i���p��:UI���P���Z�o���W���[���j</br>
	/// <br>Programmer	: 22008�@���� ���n</br>
    /// <br>Date		: 2009.04.13</br>
    /// <br></br>
    /// <br>Note		: �I����������_��Q�Ή� �Y������P���ݒ肪�����ꍇ�A��f�[�^��ǉ�����悤�ύX</br>
    /// <br>Programmer	: 30365�@�{�� �⎟�Y</br>
    /// <br>Date		: 2012/05/21</br>
    /// <br></br>
    /// <br>Note		: �|���}�X�^�̊Y��������0�ł��A��̌��ʂ�Ԃ��悤�ύX</br>
    /// <br>Programmer	: 30365�@�{�� �⎟�Y</br>
    /// <br>Date		: 2012/06/08</br>
    /// <br>Note		: Redmine#31103�I�����������̑��x���ǂ̑Ή�</br>
    /// <br>Programmer	: ������</br>
    /// <br>Date		: 2012/07/10</br>
    /// <br>Update Note: 2013/05/06 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 PM1301E(���x�����j</br>
    /// <br>           : Redmine#35493 �@�I�����������ŁA�|���}�X�^�̌������������ɁA�������Ԃ������A���T�[�o�[���ׂ������Ȃ�(#1902)</br>
    /// <br>Update Note: 2013/06/07 wangl2</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 </br>
    /// <br>           : Redmine#35788 �@�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
    /// <br>                              �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
    /// <br>Update Note: 2014/05/13 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11070071-00 </br>
    /// <br>           : Redmine#36564 �I���\�����x���P�̑Ή�</br>
    /// <br>Update Note: 2015/01/27 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11100008-00 </br>
    /// <br>           : Redmine#44581 �|�V�����i/�I�������\�ɂĎd�������ڂ�ǉ�����悤�ύX</br>
    /// <br>Update Note: 2015/03/02 30940 �͌��� �ꐶ</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : Redmine#44581 �|�V�����i/�I�������\ �d�������󎚂���Ȃ����̏C��</br>
    /// <br>Update Note: 2015/03/06 caohh</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00 </br>
    /// <br>           : Redmine#44951�u�|���ݒ�敪�v���|���D��Ǘ����\�[�g�̏�����ǉ�</br>
    /// <br>Update Note: 2015/03/23 xuyb</br>
    /// <br>�Ǘ��ԍ�   : 11070253-00 </br>
    /// <br>           : Redmine#44492��#99 ���㌎���X�V�̎d���P���E�d�����Z�o�s��̏C���i#44951��#50��No.2�j�Ή�</br>
    /// <br>Update Note: 2015/06/18 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11101427-00 </br>
    /// <br>           : ���C�S ���X�l���ꗗ�\�p���X���i�������j�̎Z�o</br>
    /// <br>Update Note: 2020/07/23 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
    /// <br>Update Note: 2020/10/20 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11675035-00</br>
    /// <br>             PMKOBETSU-3551�F�I���\�������s����Ə����Ɏ��s���錻�ۂ̉���</br>
    /// <br>Update Note: 2021/03/16 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 �I�����������ƒI���\���̏�Q�Ή�</br> 
    /// <br>           : �@GoodsUnitData�̊�ƃR�[�h����̌�</br>
    /// <br>           : �A�|���D��Ǘ��}�X�^�̋��_�w�肪�y�S�Ћ��ʁz�̏ꍇ�A���_���̊|���f�[�^���g�p����Ă��܂���</br>
    /// <br>           : �B���_���̒P�i�ݒ�̊|���f�[�^������A�|���D��Ǘ��}�X�^��[6A]�����݂��Ȃ��ꍇ�A���_���̒P�i�ݒ�̊|���f�[�^���g�p����Ă��܂���</br>
    /// </remarks>
	public class UnitPriceCalculation
	{
        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        #region ��Public Members

		/// <summary>�P����ށi����P���j</summary>
		public const string ctUnitPriceKind_SalesUnitPrice = "1";
		/// <summary>�P����ށi�����ݒ�j</summary>
		public const string ctUnitPriceKind_UnitCost = "2";
		/// <summary>�P����ށi���i�ݒ�j</summary>
		public const string ctUnitPriceKind_ListPrice = "3";
		///// <summary>�P����ށi��ƌ����j</summary>
		//public const string ctUnitPriceKind_WorkCost = "4";
		///// <summary>�P����ށi��Ɣ����j</summary>
		//public const string ctUnitPriceKind_WorkSalesUnitPrice = "5";
		#endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members

        /// <summary>�|���ݒ�敪�i���[�J�[�\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_Maker = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "K" });
        /// <summary>�|���ݒ�敪�i���i�R�[�h,���i���\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_Goods = new List<string>(new string[] { "A" });
        /// <summary>�|���ݒ�敪�i�w�ʕ\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_GoodsRateRank = new List<string>(new string[] { "B", "C", "G" });
        /// <summary>�|���ݒ�敪�i���i�|���O���[�v�\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_GoodsRateGrpCode = new List<string>(new string[] { "F", "J" });
        /// <summary>�|���ݒ�敪�iBL�O���[�v�R�[�h�j</summary>
        private readonly List<string> ctRATEDIVVALUE_BLGroupCode = new List<string>(new string[] { "C", "E", "I" });
        /// <summary>�|���ݒ�敪�iBL���i�\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_BLGoods = new List<string>(new string[] { "B", "D", "H" });
        /// <summary>�|���ݒ�敪�i���Ӑ�\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_Customer = new List<string>(new string[] { "1", "2" });
        /// <summary>�|���ݒ�敪�i���Ӑ�|��GR�\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_CustRateGrp = new List<string>(new string[] { "3", "4" });
        /// <summary>�|���ݒ�敪�i�d����\���敪�l�j</summary>
        private readonly List<string> ctRATEDIVVALUE_SupplierCd = new List<string>(new string[] { "1", "3", "5" });
        //private int _ratePriorityDiv = 0; // ���_�D�� // ADD caohh 2015/03/06 for Redmine#44951  // DEL xuyb 2015/03/23 for Redmine#44492
        private Dictionary<string, int> _ratePriorityDivDic = null;  // ��ƕʋ��_�D��敪  // ADD xuyb 2015/03/23 for Redmine#44492
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>�P�i�|��</summary>
        private const string ctRateSettingDivByGoodsNo = "6A";
        /// <summary>DIC�L�[�t�H�[�}�b�g</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        // --- ADD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
        # endregion

        // ===  ================================================================================== //
        // �񋓌^
        // ===================================================================================== //
        #region ��Enums

		/// <summary>
		/// �P����ޗ񋓌^
		/// </summary>
		public enum UnitPriceKind : int
		{
			/// <summary>����P��</summary>
			SalesUnitPrice = 1,
			/// <summary>�����P��</summary>
			UnitCost = 2,
			/// <summary>�艿</summary>
			ListPrice = 3
			///// <summary>��ƌ���</summary>
			//WorkCost = 4,
			///// <summary>��Ɣ���</summary>
			//WorkSalesUnitPrice = 5    
		}

		/// <summary>
		/// �P���Z�o���@
		/// </summary>
		public enum UnitPrcCalcDiv
		{
			/// <summary>�P�����ڎw��</summary>
			Price = 0,
			/// <summary>�|��</summary>
			RateVal = 1,
			/// <summary>UP��</summary>
			UpRate = 2,
			/// <summary>�e����</summary>
			GrsProfitSecureRate = 3,
		}
		#endregion

        // ===================================================================================== //
        // �\����
        // ===================================================================================== //
        #region ��Struct

        # region [�|���}�X�^�̌�������]
        /// <summary>
        /// �|���}�X�^�̌�������
        /// </summary>
        private struct RateSeachConf
        {
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>�P���|���ݒ�敪</summary>
            private string _unitRateSetDivCd;
            /// <summary>���i���[�J�[�R�[�h</summary>
            private int _goodsMakerCd;
            /// <summary>���i�ԍ�</summary>
            private string _goodsNo;
            /// <summary>���i�|�������N</summary>
            private string _goodsRateRank;
            /// <summary>���i�|���O���[�v�R�[�h</summary>
            private int _goodsRateGrpCode;
            /// <summary>BL�O���[�v�R�[�h</summary>
            private int _bLGroupCode;
            /// <summary>BL���i�R�[�h</summary>
            private int _bLGoodsCode;
            /// <summary>���Ӑ�R�[�h</summary>
            private int _customerCode;
            /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
            private int _custRateGrpCode;
            /// <summary>�d����R�[�h</summary>
            private int _supplierCd;
            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// �P���|���ݒ�敪
            /// </summary>
            public string UnitRateSetDivCd
            {
                get { return _unitRateSetDivCd; }
                set { _unitRateSetDivCd = value; }
            }
            /// <summary>
            /// ���i���[�J�[�R�[�h
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// ���i�ԍ�
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// ���i�|�������N
            /// </summary>
            public string GoodsRateRank
            {
                get { return _goodsRateRank; }
                set { _goodsRateRank = value; }
            }
            /// <summary>
            /// ���i�|���O���[�v�R�[�h
            /// </summary>
            public int GoodsRateGrpCode
            {
                get { return _goodsRateGrpCode; }
                set { _goodsRateGrpCode = value; }
            }
            /// <summary>
            /// BL�O���[�v�R�[�h
            /// </summary>
            public int BLGroupCode
            {
                get { return _bLGroupCode; }
                set { _bLGroupCode = value; }
            }
            /// <summary>
            /// BL���i�R�[�h
            /// </summary>
            public int BLGoodsCode
            {
                get { return _bLGoodsCode; }
                set { _bLGoodsCode = value; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// ���Ӑ�|���O���[�v�R�[�h
            /// </summary>
            public int CustRateGrpCode
            {
                get { return _custRateGrpCode; }
                set { _custRateGrpCode = value; }
            }
            /// <summary>
            /// �d����R�[�h
            /// </summary>
            public int SupplierCd
            {
                get { return _supplierCd; }
                set { _supplierCd = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="sectionCode">���_�R�[�h</param>
            /// <param name="unitRateSetDivCd">�P���|���ݒ�敪</param>
            /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
            /// <param name="goodsNo">���i�ԍ�</param>
            /// <param name="goodsRateRank">���i�|�������N</param>
            /// <param name="goodsRateGrpCode">���i�|���O���[�v�R�[�h</param>
            /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
            /// <param name="bLGoodsCode">BL���i�R�[�h</param>
            /// <param name="customerCode">���Ӑ�R�[�h</param>
            /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
            /// <param name="supplierCd">�d����R�[�h</param>
            public RateSeachConf(string sectionCode, string unitRateSetDivCd, int goodsMakerCd, string goodsNo, string goodsRateRank, int goodsRateGrpCode, int bLGroupCode, int bLGoodsCode, int customerCode, int custRateGrpCode, int supplierCd)
            {
                _sectionCode = sectionCode;
                _unitRateSetDivCd = unitRateSetDivCd;
                _goodsMakerCd = goodsMakerCd;
                _goodsNo = goodsNo;
                _goodsRateRank = goodsRateRank;
                _goodsRateGrpCode = goodsRateGrpCode;
                _bLGroupCode = bLGroupCode;
                _bLGoodsCode = bLGoodsCode;
                _customerCode = customerCode;
                _custRateGrpCode = custRateGrpCode;
                _supplierCd = supplierCd;
            }
        }
        # endregion

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constracter

		/// <summary>
		/// �P���Z�o�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2007.11.12</br>
		/// </remarks>
		public UnitPriceCalculation()
		{

        }

		# endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region��Public Methods

		#region �����P���v�Z����
		/// <summary>
		/// �|�����g�p���Č����P�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		public void CalculateUnitCost( UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, out List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        public void CalculateUnitCost( List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

		#endregion

		#region ���A�e�����ɂ��P���v�Z

		/// <summary>
		/// ��P������|�����g�p���ĒP�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="unitPrcCalcDiv">�v�Z���@</param>
		/// <param name="totalAmountDispWayCd">���z�\���敪</param>
		/// <param name="ttlAmntDspRateDivCd">�|���K�p�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="stdPrice">��P���i�O�ŕi�F�Ŕ����P���A���ŕi�F�ō��ݒP���j</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
        /// <param name="rate">�|��</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fracProcUnit">�[�������P�ʁi���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="fracProcCd">�[�������敪�i���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="unitPriceTaxExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceTaxInc">�P���i�ō��݁j</param>
		public void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, UnitPrcCalcDiv unitPrcCalcDiv, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, List<StockProcMoneyWork> stockProcMoneyList,  ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			double stdPriceWk = stdPrice;
			int taxationCodeWk = taxationCode;

			// ��P���~�|���̏ꍇ�́A��P����␳����
			if (( unitPrcCalcDiv == UnitPrcCalcDiv.RateVal ))
			{
				if (( totalAmountDispWayCd == 1 ) &&		// ���z�\������
					( ttlAmntDspRateDivCd == 0 ) &&			// �|���K�p�敪�u0�F�ō��P���v
					( taxationCode == 0 ))					// �O�ŕi
				{
					// �ō��P������Ƃ��A���łƓ����v�Z���s��
					stdPriceWk += CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, stdPrice);
					taxationCodeWk = 2;
				}
			}

            this.CalculateUnitPriceByRate(unitPriceKind, fractionProcCode, taxationCodeWk, stdPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd, out unitPriceTaxExc, out unitPriceTaxInc);
		}

		#endregion

		#endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// �P���v�Z����
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
        }

		/// <summary>
        /// �P���v�Z����
		/// </summary>
		/// <param name="unitPriceKindList">�P����ރ��X�g</param>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
			// ���i���X�g�������ꍇ�͏������Ȃ�
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo ) || ( goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd ))
			{
				return;
			}
			List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
			unitPriceCalcParamList.Add(unitPriceCalcParam);
			List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

			goodsUnitDataList.Add(goodsUnitData);
			this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// �P���v�Z����
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

		/// <summary>
        /// �P���v�Z����
		/// </summary>
		/// <param name="unitPriceKindList">�P����ރ��X�g</param>
		/// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
		/// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList )
		{
            LogWrite(string.Format("�P���Z�o �J�n {0}��:", unitPriceCalcParamList.Count));

            // �p�����[�^���X�g�A���i�A���f�[�^�I�u�W�F�N�g���X�g��������Ώ������Ȃ�
			if (( unitPriceCalcParamList == null ) || ( unitPriceCalcParamList.Count == 0 ) || ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ))
			{
				return;

            }
            //��ƃR�[�h�擾
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("�d�����z�����敪�ǂݍ���");


            //�d�����z�����敪�}�X�^�ǂݍ���
            List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(enterpriseCode);


            LogWrite("�|���ǂݍ���");
            //�D��Ǘ��ǂݍ���
            List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(enterpriseCode);//ADD on 2012/07/10 for Redmine#31103
            // �|���}�X�^�̓ǂݍ���
            List<RateWork> rateList;
            //int status = this.SearchRate(enterpriseCode, unitPriceKindList, unitPriceCalcParamList, out rateList);//DEL on 2012/07/10 for Redmine#31103
            int status = this.SearchRate(enterpriseCode, unitPriceKindList, unitPriceCalcParamList, out rateList, rateProtyMngAllList);//ADD on 2012/07/10 for Redmine#31103

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rateList = null;
            }
            else
            {
                LogWrite(string.Format("�|�� {0}���擾", rateList.Count));
            }

            LogWrite("�����v�Z");

            // �����v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.UnitCost))
            {
                //this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList);/DEL on 2012/07/10 for Redmine#31103
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//ADD on 2012/07/10 for Redmine#31103
            }

            LogWrite("�P���Z�o �I��");
        }

		/// <summary>
		/// �����P���v�Z����
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
		/// <param name="goodsUnitDataList">���i�\���f�[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <param name="rateProtyMngAllList">�|���D��Ǘ����X�g</param>
        /// <br>UpdateNote : Redmine#31103�I�����������̑��x���ǂ̑Ή�</br>
        /// <br>Programer  : ������</br>
        /// <br>Date       : 2012/07/10</br>
        //private void CalculateUnitCostPriceProc(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList,ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)//DEL on 2012/07/10 for Redmine#31103
        private void CalculateUnitCostPriceProc(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)//ADD on 2012/07/10 for Redmine#31103
		{
            List<RateProtyMngWork> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
			{
                // ����ł̒[�������P�ʁA�[�������敪���擾
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList,out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

				GoodsUnitDataWork goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				GoodsPriceUWork goodsPrice;
				bool calcPrice = false;
				this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

                if (goodsPrice != null)
                {
                    double unitPriceTaxExc = 0;
                    double unitPriceTaxInc = 0;
                    int fractionProcCode = 0;
                    double unPrcFracProcUnit = 0;
                    int unPrcFracProcDiv = 0;
                    double stdPrice = 0;
                    int taxationCode = 0;
                    double stockRate = 0;

                    // ���P�������ڃZ�b�g����Ă���ꍇ
                    if (goodsPrice.SalesUnitCost != 0)
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // ���i�̉ېŕ����ɏ]���ĕ���
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                break;
                        }
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // �d�������Z�b�g����Ă��āA�艿���[���ȊO
                    else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        stockRate = goodsPrice.StockRate;

                        stdPrice = goodsPrice.ListPrice;
                        double stdPriceWk = goodsPrice.ListPrice;
                        taxationCode = unitPriceCalcParam.TaxationDivCd;

                        //--------------------------------------------------
                        // �v�Z�p�艿�̎Z��
                        //--------------------------------------------------
                        // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h

                        this.CalculateUnitPriceByRate(UnitPriceKind.UnitCost,
                            fractionProcCode,
                            taxationCode,
                            stdPriceWk,
                            unitPriceCalcParam.TaxRate,
                            taxFractionProcUnit,
                            taxFractionProcCd,
                            goodsPrice.StockRate,
                            stockProcMoneyList,
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

                    // �����܂łŌ����v�Z���ꂽ�ꍇ�͌��ʂ��Z�b�g
                    if (calcPrice)
                    {
                        UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                        unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
                        unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;
                        unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
                        unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
                        unitPriceCalcRet.RateVal = stockRate;
                        unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
                        unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
                        unitPriceCalcRet.StdUnitPrice = stdPrice;
                        unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
                        unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                        unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                        unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;

                        unitPriceCalcRetList.Add(unitPriceCalcRet);
                    }
                    else
                    {
                        // �|���D��Ǘ������擾����
                        //rateProtyMngList = this.GetRateProtyMngList(goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//DEL on 2012/07/10 for Redmine#31103
                        rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103

                        // -- UPD 2012/06/08 ------------------------------------->>>>
                        //if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                        if (rateProtyMngList != null)
                        // -- UPD 2012/06/08 -------------------------------------<<<<
                        {
                            this.CalculateUnitPriceByRateList(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        }

                    }
                }
                // -- ADD 2012/05/21 ------------------------------>>>>
                else
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // �P�����
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                    unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                // -- ADD 2012/05/21 ------------------------------<<<<
			}
		}

		/// <summary>
		/// �|���D�揇�ʁA�|���}�X�^�ɂ��P���v�Z
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
		/// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceByRateList(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList,GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            //if (rateList == null || rateList.Count == 0) return; // DEL 2012/06/08
            bool breakFlg = false; // ADD 2012/05/21

            // �|���D�揇�ʏ��ɒP���v�Z����
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.CalculateUnitPrice(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList ,goodsUnitData, ref unitPriceCalcRetList))
                    {
                        breakFlg = true; // ADD 2012/05/21
                        break;
                    }
                }
            }
            finally
            {
                // -- ADD 2012/05/21 ------------------------------------>>>>
                if (breakFlg == false)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // �P�����
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                    unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                // -- ADD 2012/05/21 ------------------------------------<<<<
            }
        }

        /// <summary>
        /// �|���ݒ�敪�ɏ]���ĒP�����Z�o���܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃI�u�W�F�N�g���X�g</param>
        /// <returns>True:�P���Z�o�����AFalse:�P���Z�o���s</returns>
        private bool CalculateUnitPrice(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            #region [ �Ώۂ̊|���}�X�^�𒊏o ]
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            if (rateList == null || rateList.Count == 0) return false; //ADD 2012/06/08
            List<RateWork> findList = rateList.FindAll(delegate(RateWork rate2)
                                        {
                                            if ((rate2.UnitPriceKind.Trim() == rateCndtn.UnitPriceKind.Trim()) &&
                                                (rate2.RateSettingDivide.Trim() == rateCndtn.RateSettingDivide.Trim()) &&
                                                (rate2.GoodsNo == rateCndtn.GoodsNo) &&
                                                (rate2.SectionCode.Trim() == rateCndtn.SectionCode.Trim()) &&
                                                (rate2.GoodsMakerCd == rateCndtn.GoodsMakerCd) &&
                                                (rate2.GoodsRateRank.Trim() == rateCndtn.GoodsRateRank.Trim()) &&
                                                (rate2.GoodsRateGrpCode == rateCndtn.GoodsRateGrpCode) &&
                                                (rate2.BLGroupCode == rateCndtn.BLGroupCode) &&
                                                (rate2.BLGoodsCode == rateCndtn.BLGoodsCode) &&
                                                (rate2.CustomerCode == rateCndtn.CustomerCode) &&
                                                (rate2.CustRateGrpCode == rateCndtn.CustRateGrpCode) &&
                                                (rate2.SupplierCd == rateCndtn.SupplierCd) &&
                                                (rate2.LotCount >= rateCndtn.LotCount))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());

            #endregion

            double stdPrice = 0;			// ����i
            double stdPriceWk = stdPrice;	// ����i�i���ۂ̌v�Z�p�̒l�j
            double unitPriceTaxExc = 0;		// �Ŕ����P��
            double unitPriceTaxInc = 0;		// �ō��ݒP��
            int fractionProcCode = 0;		// �[�������R�[�h(0:�S��)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// �ېŕ���
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = (unitPriceCalcParam.CountFl == 0) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// ����(0�̏ꍇ��1�Ōv�Z�A0�ȊO�͐�Βl)

            //--------------------------------------------------
            // �[�������R�[�h�̌���
            //--------------------------------------------------
            // �艿�A����P��
            if ((unitPriceKind == UnitPriceKind.ListPrice) || (unitPriceKind == UnitPriceKind.SalesUnitPrice))
            {
                fractionProcCode = unitPriceCalcParam.SalesUnPrcFrcProcCd;	// ����P���[�������R�[�h
            }
            // �d���P��
            else if (unitPriceKind == UnitPriceKind.UnitCost)
            {
                fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h
            }

            //--------------------------------------------------
            // �ېŕ����̌���
            //--------------------------------------------------

            if ((unitPriceCalcParam.ConsTaxLayMethod != 9) &&                                 // �]�ŕ����u��ېŁv������
                (unitPriceKind == UnitPriceKind.SalesUnitPrice) &&                            // ����P��
                (unitPriceCalcParam.TotalAmountDispWayCd == 1) &&								// ���z�\������
                (unitPriceCalcParam.TtlAmntDspRateDivCd == 0) &&								// �|���K�p�敪�u0�F�ō��P���v
                (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc))	// �O��
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// ���łƓ����v�Z������
            }

            // �擪�s�̃f�[�^���Ώۃf�[�^
            RateWork rate = findList[0];

            // �|���}�X�^�̒[�������P�ʁA�[�������敪�͒艿�v�Z���̂ݎg�p����i0�ɂ���ƁA���z�����敪�ݒ肩��擾�j
            double unPrcFracProcUnit = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcDiv : 0;

            // ����ł̒[�������P�ʁA�[�������敪
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // �|��

            // ���i���̎擾
            GoodsPriceUWork goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPriceUWork();

            // �P����ނɂ�菈������i�P����ޖ��̗D�揇�ʂɏ]���Čv�Z�j
            // ���v�Z���@�͓���ł����A�d�l�ύX��ǉ����ꂽ�ꍇ���l�����ĒP����ޖ��ɕ����Ă����܂�
            switch (unitPriceKind)
            {
                #region ������
                case UnitPriceKind.UnitCost:

                    // �d������ł̒[�������P�ʁA�[�������敪���擾
                    this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

                    // ���i�w��
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // �d����
                    else if (rate.RateVal != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        // �|���Ɏd�������Z�b�g
                        rateVal = rate.RateVal;

                        // �I�[�v�����i�敪�A��P���̃Z�b�g
                        openPriceDiv = goodsPrice.OpenPriceDiv;
                        stdPrice = goodsPrice.ListPrice;

                        // �I�[�v�����i�ŁA���i���[���̏ꍇ�͎擾���s����(���̊|������������)
                        if ((openPriceDiv == 1) && (stdPrice == 0)) return false;

                        stdPriceWk = stdPrice;

                        //--------------------------------------------------
                        // �v�Z�p�艿�̎Z��
                        //--------------------------------------------------
                        // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                     fractionProcCode,
                                                     taxationCode,
                                                     stdPriceWk,
                                                     unitPriceCalcParam.TaxRate,
                                                     taxFractionProcUnit,
                                                     taxFractionProcCd,
                                                     rateVal,
                                                     stockProcMoneyList,
                                                     ref unPrcFracProcUnit,
                                                     ref unPrcFracProcDiv,
                                                     out unitPriceTaxExc,
                                                     out unitPriceTaxInc);
                    }
                    break;
                #endregion

                default:
                    break;
            }

            #region �P���v�Z���ʃN���X����

            UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

            unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();				// �P�����
            unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;							// ���i�R�[�h
            unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;				// ���[�J�[�R�[�h
            unitPriceCalcRet.RatePriorityOrder = rateProtyMng.RatePriorityOrder;			// �|���D�揇��
            unitPriceCalcRet.RateSettingDivide = rate.RateSettingDivide;	                // �|���ݒ�敪
            unitPriceCalcRet.RateMngGoodsCd = rate.RateMngGoodsCd;                          // �|���ݒ�敪�i���i�j
            unitPriceCalcRet.RateMngCustCd = rate.RateMngCustCd;                            // �|���ݒ�敪�i���Ӑ�j

            if (rateProtyMng.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim())
            {
                unitPriceCalcRet.RateMngGoodsNm = rateProtyMng.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                unitPriceCalcRet.RateMngCustNm = rateProtyMng.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
            }

            unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;							// �P���Z�o�敪
            unitPriceCalcRet.SectionCode = rate.SectionCode;                                // ���_�R�[�h
            unitPriceCalcRet.RateVal = rateVal;					                            // �|��
            unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;                         // �P���[�������P��
            unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;                           // �P���[�������敪
            unitPriceCalcRet.StdUnitPrice = stdPrice;										// ��P��
            unitPriceCalcRet.OpenPriceDiv = openPriceDiv;									// �I�[�v�����i�敪
            unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;							// �P���i�Ŕ��C�����j
            unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;							// �P���i�ō��C�����j
            unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;                    // ���i�J�n��
            unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;                    // �d����R�[�h

            #endregion

            unitPriceCalcRetList.Add(unitPriceCalcRet);

            return true;
        }

        /// <summary>
        /// �|�����g�p���ĒP�����v�Z���܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="taxationCode">�ېŕ���</param>
        /// <param name="stdPrice">����i</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������R�[�h</param>
        /// <param name="rate">�|��</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fracProcUnit">�P���[�������P��</param>
        /// <param name="fracProcCd">�P���[�������敪</param>
        /// <param name="unitPriceTaxExc">�Ŕ����P��</param>
        /// <param name="unitPriceTaxInc">�ō��ݒP��</param>
        private void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, List<StockProcMoneyWork> stockProcMoneyList, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // �@�Ŕ����P�� = ��P������|���v�Z��������
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

                // �A�ō��ݒP�� = �Ŕ����P�� + �Ŕ����P���̏����
                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                // �@�ō��ݒP�� = ��P������|���v�Z��������
                unitPriceTaxInc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

                // �A�Ŕ����P�� = �ō��ݒP�� - �ō��ݒP���̏����
                unitPriceTaxExc = (double)( (decimal)unitPriceTaxInc - (decimal)CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc) );
            }
            // ��ې�
            else
            {
                // �@�Ŕ����P�� = ��P������|���v�Z��������
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, stockProcMoneyList, ref fracProcUnit, ref fracProcCd);

                // �A�ō��ݒP�� = �Ŕ����P��
                unitPriceTaxInc = unitPriceTaxExc;
            }
        }

		/// <summary>
		/// �|�����g�p���ĒP�����v�Z���܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="stdPrice">����i</param>
		/// <param name="rate">�|��</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, List<StockProcMoneyWork> stockProcMoneyList, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 )) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, stockProcMoneyList ,ref fracProcUnit, ref fracProcCd);

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// �ΏےP�����A�Ŕ����A�ō��ݒP�����Z�o���܂��B
		/// </summary>
		/// <param name="taxationCode">�ېŕ���</param>
		/// <param name="targetPrice">�Ώۉ��i</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������R�[�h</param>
		/// <param name="rate">�|��</param>
		/// <param name="unitPriceTaxExc">�Ŕ����P��</param>
		/// <param name="unitPriceTaxInc">�ō��ݒP��</param>
		private void CalclateUnitPrice( int taxationCode, double targetPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			unitPriceTaxExc = 0;
			unitPriceTaxInc = 0;

			// �O�ł̏ꍇ
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// �@�Ŕ����P�� = ��P������|���v�Z��������
				unitPriceTaxExc = targetPrice;

				// �A�ō��ݒP�� = �Ŕ����P�� + �Ŕ����P���̏����
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
			}
			// ���ł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// �@�ō��ݒP�� = ��P������|���v�Z��������
				unitPriceTaxInc = targetPrice;

				// �A�Ŕ����P�� = �ō��ݒP�� - �ō��ݒP���̏����
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc);
			}
			// ��ې�
			else
			{
				// �@�Ŕ����P�� = ��P������|���v�Z��������
				unitPriceTaxExc = targetPrice;

				// �A�ō��ݒP�� = �Ŕ����P��
				unitPriceTaxInc = unitPriceTaxExc;
			}
		}

		/// <summary>
		/// ���i�A���I�u�W�F�N�g���A�Ώۓ��̉��i�����擾���܂��B
		/// </summary>
		/// <param name="targetDay">�Ώۓ�</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
		private void GetPrice( DateTime targetDay, GoodsUnitDataWork goodsUnitData, out GoodsPriceUWork goodsPrice )
		{
			goodsPrice = null;

            if (goodsUnitData == null) return;

            List<GoodsPriceUWork> retList = null;

            if (goodsUnitData.PriceList == null)
            {
                int status = SearchGoodsPrice(goodsUnitData, out retList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;
            }
            else
            {
                //���i���X�g��GoodsUnitDataWork�ɂ��łɃZ�b�g����Ă����ꍇ�́A�ēǂݍ��݂��s��Ȃ��B
                retList = new List<GoodsPriceUWork>();
                retList.AddRange((GoodsPriceUWork[])goodsUnitData.PriceList.ToArray(typeof(GoodsPriceUWork)));
            }

			List<GoodsPriceUWork> goodsPriceList = retList;

			DateTime dateWk = DateTime.MinValue;
			foreach (GoodsPriceUWork goodsPriceWk in goodsPriceList)
			{
				if (( goodsPriceWk.PriceStartDate <= targetDay ) && ( goodsPriceWk.PriceStartDate > dateWk ))
				{
					dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = new GoodsPriceUWork();
                    goodsPrice.CreateDateTime = goodsPriceWk.CreateDateTime;
                    goodsPrice.UpdateDateTime = goodsPriceWk.UpdateDateTime;
                    goodsPrice.EnterpriseCode = goodsPriceWk.EnterpriseCode;
                    goodsPrice.FileHeaderGuid = goodsPriceWk.FileHeaderGuid;
                    goodsPrice.UpdEmployeeCode = goodsPriceWk.UpdEmployeeCode;
                    goodsPrice.UpdAssemblyId1 = goodsPriceWk.UpdAssemblyId1;
                    goodsPrice.UpdAssemblyId2 = goodsPriceWk.UpdAssemblyId2;
                    goodsPrice.LogicalDeleteCode = goodsPriceWk.LogicalDeleteCode;
                    goodsPrice.GoodsMakerCd = goodsPriceWk.GoodsMakerCd;
                    goodsPrice.GoodsNo = goodsPriceWk.GoodsNo;
                    goodsPrice.PriceStartDate = goodsPriceWk.PriceStartDate;
                    goodsPrice.ListPrice = goodsPriceWk.ListPrice;
                    goodsPrice.SalesUnitCost = goodsPriceWk.SalesUnitCost;
                    goodsPrice.StockRate = goodsPriceWk.StockRate;
                    goodsPrice.OpenPriceDiv = goodsPriceWk.OpenPriceDiv;
                    goodsPrice.OfferDate = goodsPriceWk.OfferDate;
                    goodsPrice.UpdateDate = goodsPriceWk.UpdateDate;
				}   
			}
		}

        /// <summary>
        /// ���i���i�}�X�^����
        /// </summary>
        /// <param name="goodsUnitData">���i���X�g</param>
        /// <param name="goodsPriceList">���i���X�g</param>
        private int SearchGoodsPrice(GoodsUnitDataWork goodsUnitData, out List<GoodsPriceUWork> goodsPriceList)
        {
            int status = 0;
            goodsPriceList = new List<GoodsPriceUWork>();

            GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();

            object retobj = null;
            GoodsPriceUWork paraWork = new GoodsPriceUWork();
            paraWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            paraWork.GoodsNo = goodsUnitData.GoodsNo;
            paraWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            status = goodsPriceUDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;
                goodsPriceList.AddRange((GoodsPriceUWork[])list.ToArray(typeof(GoodsPriceUWork)));

                //���i���X�g��GoodsUnitData�ɑޔ�
                goodsUnitData.PriceList = list;
            }

            return status;

        }

        /// <summary>
        /// �d�����z�[�������敪�ݒ茟��
        /// </summary>
        private List<StockProcMoneyWork> SearchStockProcMoney(string _enterpriseCode)
        {
            List<StockProcMoneyWork> _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0 ,0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return _stockProcMoneyList;
        }

        /// <summary>
        /// �|���D��Ǘ�����
        /// </summary>
        private List<RateProtyMngWork> SearchRateProtyMng(string _enterpriseCode)
        {
            List<RateProtyMngWork> _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            ReadComCompanyInf(_enterpriseCode);// ADD caohh 2015/03/06 for Redmine#44951

            object rateProtyMngWorkList = null;

            //�|���D��Ǘ��̓ǂݍ���
            rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0 , 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // ���_�A�P����ށA�D�揇�ʂŃ\�[�g
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return _rateProtyMngAllList;
        }

        /// <summary>
        /// �|���D��Ǘ����̃��X�g���擾���܂��B
        /// <br>UpdateNote : Redmine#31103�I�����������̑��x���ǂ̑Ή�</br>
        /// <br>Programer  : ������</br>
        /// <br>Date       : 2012/07/10</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>�Ǘ��ԍ�   : 11070253-00 </br>
        /// <br>           : Redmine#44492��#99 ���㌎���X�V�̎d���P���E�d�����Z�o�s��̏C���i#44951��#50��No.2�j�Ή�</br>
        /// </summary>
        /// <returns></returns>
        //private List<RateProtyMngWork> GetRateProtyMngList(string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//DEL on 2012/07/10 for Redmine#31103
        private List<RateProtyMngWork> GetRateProtyMngList(List<RateProtyMngWork> _rateProtyMngAllList, string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//ADD  on 2012/07/10 for Redmine#31103
        {
            //----DEL on 2012/07/10 for Redmine#31103 ------->>>>>>
            ////�D��Ǘ��ǂݍ���
            //List<RateProtyMngWork> _rateProtyMngAllList =  SearchRateProtyMng(_enterpriseCode);
            //----DEL on 2012/07/10 for Redmine#31103 -------<<<<<<

            if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

            // �Ώۋ��_���̗D��Ǘ����擾
            List<RateProtyMngWork> _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
                                                                    delegate(RateProtyMngWork rateProtyMng)
                                                                    {
                                                                        if (( rateProtyMng.SectionCode.Trim() == sectionCode.Trim() ) &&
                                                                            ( rateProtyMng.UnitPriceKind == (int)unitPriceKind ))
                                                                        {
                                                                            return true;
                                                                        }
                                                                        else
                                                                        {
                                                                            return false;
                                                                        }
                                                                    });
            if (sectionCode.Trim() != "00")
            {
                // �S�Аݒ蕪��ǉ�
                _lastRateProtyMngList.AddRange(_rateProtyMngAllList.FindAll(
                    delegate(RateProtyMngWork rateProtyMng)
                    {
                        if (( rateProtyMng.SectionCode.Trim() == "00" ) &&
                            ( rateProtyMng.UnitPriceKind == (int)unitPriceKind ))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }));
            }

            // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 --------------->>>>>
            // �|�����D��敪�͖��ݒ�ꍇ
            if (this._ratePriorityDivDic == null ||
                (this._ratePriorityDivDic != null && !this._ratePriorityDivDic.ContainsKey(_enterpriseCode)))
            {
                ReadComCompanyInf(_enterpriseCode);
            }
            // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 ---------------<<<<<
            // --- ADD caohh 2015/03/06 for Redmine#44951 ----->>>>>
            //if (this._ratePriorityDiv == 1)  // DEL xuyb 2015/03/23 for Redmine#44492
            if (this._ratePriorityDivDic[_enterpriseCode] == 1)  // ���_�D�� //ADD xuyb 2015/03/23 for Redmine#44492
            {
                _lastRateProtyMngList.Sort(new FractionProcMoney.RateProtyMngComparerUnitPriceKind());
            }
            // --- ADD caohh 2015/03/06 for Redmine#44951 -----<<<<<

            return _lastRateProtyMngList;

        }

        /// <summary>
        /// �|���}�X�^���������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="rateProtyMngAllList">�|���D��Ǘ����X�g</param>
        /// <br>UpdateNote : Redmine#31103�I�����������̑��x���ǂ̑Ή�</br>
        /// <br>Programer  : ������</br>
        /// <br>Date       : 2012/07/10</br>
        /// <returns>�|�������X�e�[�^�X</returns>
        //private int SearchRate(string enterpriseCode ,List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, out List<RateWork> rateList)//DEL on 2012/07/10 for Redmine#31103
        private int SearchRate(string enterpriseCode, List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, out List<RateWork> rateList, List<RateProtyMngWork> rateProtyMngAllList)//ADD on 2012/07/10 for Redmine#31103
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;

            LogWrite("�|�� �����p�����[�^�쐬");

            ArrayList paraList = new ArrayList();
            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<RateWork> kindRateList = new List<RateWork>();
                foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
                {
                    //rateProtyMngList = this.GetRateProtyMngList(enterpriseCode, unitPriceCalcParam.SectionCode, unitPriceKind); //DEL on 2012/07/10 for Redmine#31103
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParam.SectionCode, unitPriceKind); //ADD on 2012/07/10 for Redmine#31103

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParam(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                paraList.AddRange((RateWork[])kindRateList.ToArray());
            }

            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            if (paraList.Count > 0)
            {
                object rateWorkList = null;

                status = rateDB.Search(out rateWorkList, paraList,0, 0);

                if (rateWorkList != null)
                {
                    ArrayList list = rateWorkList as ArrayList;

                    rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
                }
            }

            LogWrite("�|���擾�I��");
            return status;
        }

		/// <summary>
		/// �|���}�X�^�̓ǂݍ��݃p�����[�^�𐶐����܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        private void MakeRateReadParam(UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateList)
		{
            foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
            {
                // �|���}�X�^��ǂݍ��ޏ������S�ē��͂���Ă���ꍇ�̂݌������X�g�ɒǉ�
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    RateWork rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    RateWork findRate = rateList.Find(
                                        delegate(RateWork rate2)
                                        {
                                            if (( rate2.GoodsNo == rate.GoodsNo ) &&
                                                ( rate2.UnitPriceKind == rate.UnitPriceKind ) &&
                                                ( rate2.RateSettingDivide == rate.RateSettingDivide ) &&
                                                ( rate2.SectionCode == rate.SectionCode ) &&
                                                ( rate2.GoodsMakerCd == rate.GoodsMakerCd ) &&
                                                ( rate2.GoodsRateRank == rate.GoodsRateRank ) &&
                                                ( rate2.GoodsRateGrpCode == rate.GoodsRateGrpCode ) &&
                                                ( rate2.BLGroupCode == rate.BLGroupCode ) &&
                                                ( rate2.BLGoodsCode == rate.BLGoodsCode ) &&
                                                ( rate2.CustomerCode == rate.CustomerCode ) &&
                                                ( rate2.CustRateGrpCode == rate.CustRateGrpCode ) &&
                                                ( rate2.SupplierCd == rate.SupplierCd ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
                    if (findRate != null)
                    {
                        continue;
                    }

                    rate.EnterpriseCode = rateProtyMng.EnterpriseCode;
                    rate.LotCount = -1;  // ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j
                    rateList.Add(rate);
                }
            }
		}

		#region ���z������}�X�^�֘A

		/// <summary>
		/// �P����ށA���z�ɏ]���Ē[�������P�ʁA�[�������敪��ݒ肵�܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="price">�Ώۋ��z</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		private void SettingFracProcInfo( UnitPriceKind unitPriceKind, int fractionProcCode, double price, List<StockProcMoneyWork> stockProcMoneyList, ref double fractionProcUnit, ref int fractionProcCd )
		{
			if (fractionProcUnit == 0)
			{
				switch (unitPriceKind)
				{
					// �d���P��
					case UnitPriceKind.UnitCost:
						{
							this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, stockProcMoneyList, out fractionProcUnit, out fractionProcCd);
							break;
						}
				}
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
		/// </summary>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="price">�Ώۋ��z</param>
        /// <param name="_stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd )
		{
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if (( stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( stockProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( stockProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
		}


        /// <summary>
        /// �P����ށA�|���ݒ�敪�A�P���v�Z�p�����[�^�I�u�W�F�N�g���A�|���}�X�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitPriceCalcParam">�|���v�Z�p�����[�^</param>
        /// <returns></returns>
        private RateWork CreateRateFromUnitPriceCalcParam(UnitPriceKind unitPriceKind, string rateSettingDivide, string sectionCode, UnitPriceCalcParamWork unitPriceCalcParam)
        {
            RateWork rate = new RateWork();

            rate.UnitPriceKind = ((int)unitPriceKind).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.SectionCode = sectionCode;
            rate.RateMngGoodsCd = GetRateMngCustCd(rateSettingDivide);
            rate.RateMngCustCd = GetRateMngCustCd(rateSettingDivide);
            rate.GoodsNo = IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : "";
            rate.GoodsMakerCd = IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsRateRank = IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : "";
            rate.GoodsRateGrpCode = IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;

            return rate;
        }

        /// <summary>
        /// �|���}�X�^��ǂݍ��ޏ������ݒ肳��Ă��邩�`�F�b�N���܂��B
        /// </summary>
        /// <param name="rateSettingDivide"></param>
        /// <param name="unitPriceCalcParam"></param>
        /// <returns></returns>
        private bool CanCreateCheck(string rateSettingDivide, UnitPriceCalcParamWork unitPriceCalcParam)
        {
            if (((IsGoodsNoSetting(rateSettingDivide) && (string.IsNullOrEmpty(unitPriceCalcParam.GoodsNo.Trim())))) ||
                ((IsMakerSetting(rateSettingDivide) && (unitPriceCalcParam.GoodsMakerCd == 0))) ||
                ((IsGoodsRateRankSetting(rateSettingDivide) && (string.IsNullOrEmpty(unitPriceCalcParam.GoodsRateRank.Trim())))) ||
                ((IsGoodsRateGrpCodeSetting(rateSettingDivide) && (unitPriceCalcParam.GoodsRateGrpCode == 0))) ||
                ((IsBLGroupCodeSetting(rateSettingDivide) && (unitPriceCalcParam.BLGroupCode == 0))) ||
                ((IsBLGoodsSetting(rateSettingDivide) && (unitPriceCalcParam.BLGoodsCode == 0))) ||
                ((IsCustomerSetting(rateSettingDivide) && (unitPriceCalcParam.CustomerCode == 0))) ||
                ((IsCustRateGrpSetting(rateSettingDivide) && (unitPriceCalcParam.CustRateGrpCode == 0))) ||
                ((IsSupplierSetting(rateSettingDivide) && (unitPriceCalcParam.SupplierCd == 0))))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���Ӑ悪�|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsCustomerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_Customer);
        }

        /// <summary>
        /// ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsCustRateGrpSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_CustRateGrp);
        }

        /// <summary>
        /// �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsSupplierSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_SupplierCd);
        }

        /// <summary>
        /// ���i�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsGoodsNoSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Goods);
        }

        /// <summary>
        /// ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsMakerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Maker);
        }

        /// <summary>
        /// �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsGoodsRateRankSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateRank);
        }

        /// <summary>
        /// ���i�|���O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsGoodsRateGrpCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateGrpCode);
        }

        /// <summary>
        /// BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsBLGroupCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGroupCode);
        }

        /// <summary>
        /// BL���i���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public bool IsBLGoodsSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGoods);
        }

        /// <summary>
        /// �Ώە����񒆂ɁA��r�Ώۃ��X�g�Ɋ܂܂�镶���񂪑��݂��邩���擾���܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <param name="startIndex">�����񒆂̔�r�����J�n�ʒu</param>
        /// <param name="length">��r������̒���</param>
        /// <param name="judgmentList">��r�Ώۃ��X�g</param>
        /// <returns>true:���݂���</returns>
        private bool IsSetting(string target, int startIndex, int length, List<string> judgmentList)
        {
            bool ret = false;
            if (target.Length >= (startIndex + length))
            {
                if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
            }
            return ret;
        }
        #endregion

		#endregion

        // ===================================================================================== //
        // �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        #region ��Static Methods

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

		#endregion

        /// <summary>
        /// �|���f�[�^�e�[�u���t�B���^�[�����񐶐�
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <returns></returns>
        private RateWork MakeRateFilter(string sectionCode, UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string rateSettingDivide)
        {
            RateWork rate = new RateWork();

            // �|���ݒ�敪�ɏ]���Đݒ�L���𔻒f���ăt�B���^�[�p�̊|���}�X�^�N���X�𐶐�
            rate.SectionCode = sectionCode;
            rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.GoodsMakerCd = IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsNo = IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : string.Empty;
            rate.GoodsRateRank = IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : string.Empty;
            rate.GoodsRateGrpCode = IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;
            rate.LotCount = unitPriceCalcParam.CountFl;

            return rate;
        }


		/// <summary>
		/// ���i�\����񌟍�����
		/// </summary>
		/// <param name="goodsUnitDataList">���i�\����񃊃X�g</param>
		/// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
		/// <returns>���i�\�����I�u�W�F�N�g</returns>
		private GoodsUnitDataWork SearchGoodsUnitData( List<GoodsUnitDataWork> goodsUnitDataList, UnitPriceCalcParamWork unitPriceCalcParam )
		{
			GoodsUnitDataWork retGoodsUnitData = null;

			foreach (GoodsUnitDataWork goodsUnitDataWk in goodsUnitDataList)
			{
				if (( goodsUnitDataWk.GoodsNo == unitPriceCalcParam.GoodsNo ) && ( goodsUnitDataWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					retGoodsUnitData = goodsUnitDataWk;
                    break; //ADD on 2012/07/10 for Redmine#31103
				}
			}

			return retGoodsUnitData;
		}

		#endregion

        // --- ADD ���V�� 2015/06/18 ���C�S ���X�l���ꗗ�\�p���X���i�������j�̎Z�o ------->>>>>>>>>>>
        /// <summary>
        /// �|�����g�p���Ĕ��������擾���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�������擾�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secList">���_�R�[�h</param>
        /// <param name="rateRetList">���������ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        public int SalesRateByRateList(List<UnitPriceCalcParamWork> unitPriceCalcParamList, string enterpriseCode, ArrayList secList, out List<RateWork> rateRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            rateRetList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;
            // �D��Ǘ��ǂݍ���
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            status = this.SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            // �D��Ǘ��ǂݍ��ݎ��s�ꍇ
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            if (unitPriceCalcParamList != null && unitPriceCalcParamList.Count > 0)
            {
                // �|���D��Ǘ������擾����
                rateProtyMngList = this.GetSalesRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParamList[0].SectionCode, UnitPriceKind.SalesUnitPrice);
                if (rateProtyMngList == null)
                {
                    rateProtyMngList = new List<RateProtyMngWork>();
                }
            }

            // �|���}�X�^�̓ǂݍ���
            status = this.SearchSalesRateForInventoryDis(enterpriseCode, secList);
            // �|���}�X�^�̓ǂݍ��ݎ��s�ꍇs
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            for (int i = 0; i < unitPriceCalcParamList.Count; i++)
            {
                // ���������擾����
                status = this.RateByRateListForInventory2(UnitPriceKind.SalesUnitPrice, unitPriceCalcParamList[i], rateProtyMngList, ref rateRetList);
                // ���������擾���s�ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            return status;
        }

        /// <summary>
        /// �|���D�揇�ʁA�|���}�X�^�ɂ�锄�����擾
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�d�����擾�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateRetList">�d�������ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���D�揇�ʁA�|���}�X�^�ɂ��|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private int RateByRateListForInventory2(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            bool breakFlg = false;

            // �|���D�揇�ʏ��ɂ���āA�������擾����
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.RateForInventory2(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, ref rateRetList))
                    {
                        breakFlg = true;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (breakFlg == false)
                {
                    RateWork rateRet = new RateWork();

                    rateRet.UnitPriceKind = ((int)unitPriceKind).ToString();        // �P�����
                    rateRet.GoodsNo = unitPriceCalcParam.GoodsNo;                   // ���i�R�[�h
                    rateRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;         // ���[�J�[�R�[�h
                    rateRet.SectionCode = unitPriceCalcParam.SectionCode;           // ���_�R�[�h
                    rateRet.GoodsRateRank = unitPriceCalcParam.GoodsRateRank;       // �w��
                    rateRet.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // ���i������
                    rateRet.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;           // BL���i�R�[�h
                    rateRet.BLGroupCode = unitPriceCalcParam.BLGroupCode;           // BL�O���[�v�R�[�h
                    rateRet.CustRateGrpCode = unitPriceCalcParam.CustRateGrpCode;   // ���Ӑ�|���O���[�v�R�[�h
                    rateRetList.Add(rateRet);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }

        /// <summary>
        /// �|���ݒ�敪�ɏ]���Ĕ������擾
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�������擾�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="rateRetList">�����擾���ʃI�u�W�F�N�g���X�g</param>
        /// <returns>True:�������擾�����AFalse:�������擾���s</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���D�揇�ʁA�|���}�X�^�ɂ��|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private bool RateForInventory2(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, ref List<RateWork> rateRetList)
        {
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            // �\�ߍ���Ă�����Dictionay��������ɍ������̂��擾
            // �����������ꂢ�ȏ����������邩������܂���
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (tmpList == null || tmpList.Count == 0) return false;

            List<RateWork> findList = new List<RateWork>();
            //tmpList����LotCount�̏����ɍ���Ȃ����������[�u
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());


            // �擪�s�̃f�[�^���Ώۃf�[�^
            RateWork rate = new RateWork();
            rate.RateVal = findList[0].RateVal;                             // ������
            rate.GoodsNo = unitPriceCalcParam.GoodsNo;                      // ���i�R�[�h
            rate.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;            // ���[�J�[�R�[�h
            rate.SectionCode = unitPriceCalcParam.SectionCode;              // ���_�R�[�h
            rate.GoodsRateRank = unitPriceCalcParam.GoodsRateRank;          // �w��
            rate.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode;    // ���i������
            rate.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;              // BL���i�R�[�h
            rate.BLGroupCode = unitPriceCalcParam.BLGroupCode;              // BL�O���[�v�R�[�h
            rate.CustRateGrpCode = unitPriceCalcParam.CustRateGrpCode;   �@ // ���Ӑ�|���O���[�v�R�[�h
            rateRetList.Add(rate);

            return true;
        }

        /// <summary>
        /// �Ώۋ��_���̗D��Ǘ����擾
        /// </summary>
        /// <param name="rateProtyMngAllList">�D��Ǘ��擾�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitPriceKind">�P�����</param>
        /// <remarks>
        /// <br>UpdateNote : �|���D��Ǘ����̃��X�g���擾</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        private List<RateProtyMngWork> GetSalesRateProtyMngList(List<RateProtyMngWork> rateProtyMngAllList, string enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)
        {
            if (rateProtyMngAllList == null || rateProtyMngAllList.Count == 0) return null;

            // �Ώۋ��_���̗D��Ǘ����擾
            List<RateProtyMngWork> lastRateProtyMngList = rateProtyMngAllList.FindAll(
                                                                    delegate(RateProtyMngWork rateProtyMng)
                                                                    {
                                                                        if ((rateProtyMng.SectionCode.Trim() == sectionCode.Trim()) &&
                                                                            (rateProtyMng.UnitPriceKind == (int)unitPriceKind) &&
                                                                            (("3".Equals(rateProtyMng.RateMngCustCd.Trim())) ||
                                                                            ("4".Equals(rateProtyMng.RateMngCustCd.Trim()))))
                                                                        {
                                                                            return true;
                                                                        }
                                                                        else
                                                                        {
                                                                            return false;
                                                                        }
                                                                    });
            return lastRateProtyMngList;

        }

        /// <summary>
        /// �|���}�X�^�i�����j�̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secList">���_���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/06/18</br>
        /// </remarks>
        public int SearchSalesRateForInventoryDis(string enterpriseCode, ArrayList secList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RateDB rateDB = new RateDB();

            List<RateWork> rateList = new List<RateWork>();
            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            object rateWorkList = null;

            // �����ݒ�̊|�����X�g���擾
            status = rateDB.SearchRateForInvoDis(out rateWorkList, enterpriseCode, secList, 1, 0);

            // �������ʂ�����ꍇ
            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;
                ArrayList tempList = new ArrayList();
                foreach (RateWork rateWork in list)
                {
                    // ���_�u00�v�ȊO�̃f�[�^��ۑ�����
                    if (!"00".Equals(rateWork.SectionCode.Trim()))
                    {
                        tempList.Add(rateWork);
                    }
                }

                rateList.AddRange((RateWork[])tempList.ToArray(typeof(RateWork)));
            }

            // �|���ݒ�}�X�^�̎擾
            MakeDictionary(rateList);

            LogWrite("�|���擾�I��");
            return status;
        }
        // --- ADD ���V�� 2015/06/18 ���C�S ���X�l���ꗗ�\�p���X���i�������j�̎Z�o ------->>>>>>>>>>>

        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B(�I����p)
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>�Ǘ��ԍ�   : 11070253-00 </br>
        /// <br>           : Redmine#44492��#99 ���㌎���X�V�̎d���P���E�d�����Z�o�s��̏C���i#44951��#50��No.2�j�Ή�</br>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        public int CalculateUnitCostPrice(ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, GoodsPriceUWork goodsPrice
            , double taxFractionProcUnit, int taxFractionProcCd, UnitPriceCalcParamWork unitPriceCalcParam, List<StockProcMoneyWork> stockProcMoneyList
            , List<RateProtyMngWork> rateProtyMngAllList, GoodsUnitDataWork goodsUnitData , List<RateWork> rateList) 
        {
            ReadComCompanyInf(goodsUnitData.EnterpriseCode);  //ADD xuyb 2015/03/23 for Redmine#44492

            if (goodsPrice != null && goodsPrice.EnterpriseCode != null && goodsPrice.EnterpriseCode != "")
            {
                double unitPriceTaxExc = 0;
                double unitPriceTaxInc = 0;
                int fractionProcCode = 0;
                double unPrcFracProcUnit = 0;
                int unPrcFracProcDiv = 0;
                double stdPrice = 0;
                int taxationCode = 0;
                double stockRate = 0;
                bool calcPrice = false;
                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;
                List<RateProtyMngWork> rateProtyMngList = null;

                // ���P�������ڃZ�b�g����Ă���ꍇ
                if (goodsPrice.SalesUnitCost != 0)
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                    // ���i�̉ېŕ����ɏ]���ĕ���
                    switch (goodsUnitData.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxExc:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            break;
                    }
                    // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        unitPriceTaxInc = unitPriceTaxExc;
                    }
                }
                // �d�������Z�b�g����Ă��āA�艿���[���ȊO
                else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                    stockRate = goodsPrice.StockRate;

                    stdPrice = goodsPrice.ListPrice;
                    double stdPriceWk = goodsPrice.ListPrice;
                    taxationCode = unitPriceCalcParam.TaxationDivCd;

                    //--------------------------------------------------
                    // �v�Z�p�艿�̎Z��
                    //--------------------------------------------------
                    // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                            stdPriceWk = stdPrice;
                        }
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }

                    fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h

                    this.CalculateUnitPriceByRate(UnitPriceKind.UnitCost,
                        fractionProcCode,
                        taxationCode,
                        stdPriceWk,
                        unitPriceCalcParam.TaxRate,
                        taxFractionProcUnit,
                        taxFractionProcCd,
                        goodsPrice.StockRate,
                        stockProcMoneyList,
                        ref unPrcFracProcUnit,
                        ref unPrcFracProcDiv,
                        out unitPriceTaxExc,
                        out unitPriceTaxInc);
                }

                // �����܂łŌ����v�Z���ꂽ�ꍇ�͌��ʂ��Z�b�g
                if (calcPrice)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
                    unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
                    unitPriceCalcRet.RateVal = stockRate;
                    unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
                    unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
                    unitPriceCalcRet.StdUnitPrice = stdPrice;
                    unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
                    unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                    unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                    unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                else
                {
                    // �|���D��Ǘ������擾����
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                    //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    //if (rateProtyMngList != null)
                    //{
                    //    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                    //}
                    //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    if (rateProtyMngList == null)
                    {
                        rateProtyMngList = new List<RateProtyMngWork>();
                    }
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                    Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();
                    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                }
            }
            else
            {
                UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // �P�����
                unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                unitPriceCalcRetList.Add(unitPriceCalcRet);
            }

            return 0;
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B(�I����p)
        /// </summary>
        /// <param name="unitPriceCalcRetList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsPrice">���i�}�X�^</param>
        /// <param name="taxFractionProcUnit">�[�������P��</param>
        /// <param name="taxFractionProcCd">�[�������敪</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�}�X�^���X�g</param>
        /// <param name="rateProtyMngAllList">�|���D��Ǘ����X�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <remarks>
        /// <br>Note        : �|�����g�p���Č����P�����Z�o���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/07/23</br>
        /// <br>Update Note : 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�    : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I�����������ƒI���\���̏�Q�Ή�</br>  
        /// </remarks>
        public int CalculateUnitCostPrice2(ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, GoodsPriceUWork goodsPrice
            , double taxFractionProcUnit, int taxFractionProcCd, UnitPriceCalcParamWork unitPriceCalcParam, List<StockProcMoneyWork> stockProcMoneyList
            , List<RateProtyMngWork> rateProtyMngAllList, GoodsUnitDataWork goodsUnitData, List<RateWork> rateList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        {

            if (goodsPrice != null && goodsPrice.EnterpriseCode != null && goodsPrice.EnterpriseCode != "")
            {
                double unitPriceTaxExc = 0;
                double unitPriceTaxInc = 0;
                int fractionProcCode = 0;
                double unPrcFracProcUnit = 0;
                int unPrcFracProcDiv = 0;
                double stdPrice = 0;
                int taxationCode = 0;
                double stockRate = 0;
                bool calcPrice = false;
                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;
                List<RateProtyMngWork> rateProtyMngList = null;

                // ���P�������ڃZ�b�g����Ă���ꍇ
                if (goodsPrice.SalesUnitCost != 0)
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                    // ���i�̉ېŕ����ɏ]���ĕ���
                    switch (goodsUnitData.TaxationDivCd)
                    {
                        case (int)CalculateTax.TaxationCode.TaxInc:
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxExc:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                            break;
                        case (int)CalculateTax.TaxationCode.TaxNone:
                            unitPriceTaxExc = goodsPrice.SalesUnitCost;
                            unitPriceTaxInc = goodsPrice.SalesUnitCost;
                            break;
                    }
                    // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        unitPriceTaxInc = unitPriceTaxExc;
                    }
                }
                // �d�������Z�b�g����Ă��āA�艿���[���ȊO
                else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
                {
                    calcPrice = true;

                    unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                    stockRate = goodsPrice.StockRate;

                    stdPrice = goodsPrice.ListPrice;
                    double stdPriceWk = goodsPrice.ListPrice;
                    taxationCode = unitPriceCalcParam.TaxationDivCd;

                    //--------------------------------------------------
                    // �v�Z�p�艿�̎Z��
                    //--------------------------------------------------
                    // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                    if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                    {
                        if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                        {
                            stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                            stdPriceWk = stdPrice;
                        }
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }

                    fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h

                    this.CalculateUnitPriceByRate(UnitPriceKind.UnitCost,
                        fractionProcCode,
                        taxationCode,
                        stdPriceWk,
                        unitPriceCalcParam.TaxRate,
                        taxFractionProcUnit,
                        taxFractionProcCd,
                        goodsPrice.StockRate,
                        stockProcMoneyList,
                        ref unPrcFracProcUnit,
                        ref unPrcFracProcDiv,
                        out unitPriceTaxExc,
                        out unitPriceTaxInc);
                }

                // �����܂łŌ����v�Z���ꂽ�ꍇ�͌��ʂ��Z�b�g
                if (calcPrice)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
                    unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
                    unitPriceCalcRet.RateVal = stockRate;
                    unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
                    unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
                    unitPriceCalcRet.StdUnitPrice = stdPrice;
                    unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
                    unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                    unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                    unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
                else
                {
                    // �|���D��Ǘ������擾����
                    // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                    rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsPrice.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);
                    // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
                    if (rateProtyMngList == null)
                    {
                        rateProtyMngList = new List<RateProtyMngWork>();
                    }
                    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                }
            }
            else
            {
                UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // �P�����
                unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                unitPriceCalcRetList.Add(unitPriceCalcRet);
            }

            return 0;
        }
        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

        // --- ADD yangyi 2013/05/16 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// �|���D�揇�ʁA�|���}�X�^�ɂ��P���v�Z(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        //private void CalculateUnitPriceByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private void CalculateUnitPriceByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        {
            bool breakFlg = false;

            // �|���D�揇�ʏ��ɒP���v�Z����
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //if (this.CalculateUnitPriceForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList))
                    if (this.CalculateUnitPriceForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic))
                    // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    {
                        breakFlg = true;
                        break;
                    }
                }
            }
            finally
            {
                if (breakFlg == false)
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // �P�����
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                    unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
        }

        /// <summary>
        /// �|���ݒ�敪�ɏ]���ĒP�����Z�o���܂��B(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃI�u�W�F�N�g���X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <returns>True:�P���Z�o�����AFalse:�P���Z�o���s</returns>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 �I�����������ƒI���\���̏�Q�Ή�</br> 
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        //private bool CalculateUnitPriceForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private bool CalculateUnitPriceForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, Dictionary<string, RateWork> rateWorkByGoodsNoDic)
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        {
            #region [ �Ώۂ̊|���}�X�^�𒊏o ]
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            if (rateList == null || rateList.Count == 0) return false; //ADD 2012/06/08

            // �\�ߍ���Ă�����Dictionay��������ɍ������̂��擾
            // �����������ꂢ�ȏ����������邩������܂���
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
            //if (tmpList == null || tmpList.Count == 0) return false;
            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
            //// �S�ВP�i�|���f�[�^
            //RateWork rateAllSec = new RateWork();
            //// �S�ВP�i�L���t���O
            //bool rateAllSecFlg = false;
            //// �|���D�揇�ʂ��S�ВP�i�̃p�[�^��
            //if ("6A".Equals(rateProtyMng.RateSettingDivide.Trim()) && "00".Equals(sectionCode.Trim()))
            //{
            //    // �S�ВP�i���擾
            //    string key = "00" + "-" + unitPriceCalcParam.GoodsMakerCd.ToString("D4") + "-" + unitPriceCalcParam.GoodsNo.Trim();
            //    if (rateWorkByGoodsNoDic.ContainsKey(key))
            //    {
            //        rateAllSec = rateWorkByGoodsNoDic[key] as RateWork;
            //        rateAllSecFlg = true;
            //    }
            //}
            // �P�i�|���f�[�^
            RateWork rateSec = new RateWork();
            // �P�i�L���t���O
            bool rateSecFlg = false;
            // �|���D�揇�ʂ��P�i�̃p�[�^��
            if (ctRateSettingDivByGoodsNo.Equals(rateProtyMng.RateSettingDivide.Trim()))
            {
                string key = string.Format(ctDicKeyFmt, sectionCode.Trim(), unitPriceCalcParam.GoodsMakerCd, unitPriceCalcParam.GoodsNo.Trim());
                if (rateWorkByGoodsNoDic.ContainsKey(key))
                {
                    rateSec = rateWorkByGoodsNoDic[key] as RateWork;
                    rateSecFlg = true;
                }
            }
            // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

            if (tmpList == null || tmpList.Count == 0)
            {
                // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                ////�����i�̑S�ВP�i�|�����Ȃ��ꍇ�A�߂�
                //if (!rateAllSecFlg) return false;
                ////�����i�̑S�ВP�i������ꍇ
                //else
                //{
                //    tmpList = new List<RateWork>();
                //    tmpList.Add(rateAllSec);
                //}
                //�����i�̒P�i�|�����Ȃ��ꍇ�A�߂�
                if (!rateSecFlg) return false;
                //�����i�̒P�i������ꍇ
                else
                {
                    tmpList = new List<RateWork>();
                    tmpList.Add(rateSec);
                }
                // --- UPD 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<
            }
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

            List<RateWork> findList = new List<RateWork>();
            //tmpList����LotCount�̏����ɍ���Ȃ����������[�u
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());

            #endregion

            double stdPrice = 0;			// ����i
            double stdPriceWk = stdPrice;	// ����i�i���ۂ̌v�Z�p�̒l�j
            double unitPriceTaxExc = 0;		// �Ŕ����P��
            double unitPriceTaxInc = 0;		// �ō��ݒP��
            int fractionProcCode = 0;		// �[�������R�[�h(0:�S��)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// �ېŕ���
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = (unitPriceCalcParam.CountFl == 0) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// ����(0�̏ꍇ��1�Ōv�Z�A0�ȊO�͐�Βl)

            //--------------------------------------------------
            // �[�������R�[�h�̌���
            //--------------------------------------------------
            // �艿�A����P��
            if ((unitPriceKind == UnitPriceKind.ListPrice) || (unitPriceKind == UnitPriceKind.SalesUnitPrice))
            {
                fractionProcCode = unitPriceCalcParam.SalesUnPrcFrcProcCd;	// ����P���[�������R�[�h
            }
            // �d���P��
            else if (unitPriceKind == UnitPriceKind.UnitCost)
            {
                fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h
            }

            //--------------------------------------------------
            // �ېŕ����̌���
            //--------------------------------------------------

            if ((unitPriceCalcParam.ConsTaxLayMethod != 9) &&                                 // �]�ŕ����u��ېŁv������
                (unitPriceKind == UnitPriceKind.SalesUnitPrice) &&                            // ����P��
                (unitPriceCalcParam.TotalAmountDispWayCd == 1) &&								// ���z�\������
                (unitPriceCalcParam.TtlAmntDspRateDivCd == 0) &&								// �|���K�p�敪�u0�F�ō��P���v
                (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc))	// �O��
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// ���łƓ����v�Z������
            }

            // �擪�s�̃f�[�^���Ώۃf�[�^
            RateWork rate = findList[0];

            // �|���}�X�^�̒[�������P�ʁA�[�������敪�͒艿�v�Z���̂ݎg�p����i0�ɂ���ƁA���z�����敪�ݒ肩��擾�j
            double unPrcFracProcUnit = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = (unitPriceKind == UnitPriceKind.ListPrice) ? rate.UnPrcFracProcDiv : 0;

            // ����ł̒[�������P�ʁA�[�������敪
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // �|��

            // ���i���̎擾
            GoodsPriceUWork goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPriceUWork();

            // �P����ނɂ�菈������i�P����ޖ��̗D�揇�ʂɏ]���Čv�Z�j
            // ���v�Z���@�͓���ł����A�d�l�ύX��ǉ����ꂽ�ꍇ���l�����ĒP����ޖ��ɕ����Ă����܂�
            switch (unitPriceKind)
            {
                #region ������
                case UnitPriceKind.UnitCost:

                    // �d������ł̒[�������P�ʁA�[�������敪���擾
                    this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

                    // ���i�w��
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // �d����
                    else if (rate.RateVal != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        // �|���Ɏd�������Z�b�g
                        rateVal = rate.RateVal;

                        // �I�[�v�����i�敪�A��P���̃Z�b�g
                        openPriceDiv = goodsPrice.OpenPriceDiv;
                        stdPrice = goodsPrice.ListPrice;

                        // �I�[�v�����i�ŁA���i���[���̏ꍇ�͎擾���s����(���̊|������������)
                        if ((openPriceDiv == 1) && (stdPrice == 0)) return false;

                        stdPriceWk = stdPrice;

                        //--------------------------------------------------
                        // �v�Z�p�艿�̎Z��
                        //--------------------------------------------------
                        // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                     fractionProcCode,
                                                     taxationCode,
                                                     stdPriceWk,
                                                     unitPriceCalcParam.TaxRate,
                                                     taxFractionProcUnit,
                                                     taxFractionProcCd,
                                                     rateVal,
                                                     stockProcMoneyList,
                                                     ref unPrcFracProcUnit,
                                                     ref unPrcFracProcDiv,
                                                     out unitPriceTaxExc,
                                                     out unitPriceTaxInc);
                    }
                    break;
                #endregion

                default:
                    break;
            }

            #region �P���v�Z���ʃN���X����

            UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

            unitPriceCalcRet.UnitPriceKind = ((int)unitPriceKind).ToString();				// �P�����
            unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;							// ���i�R�[�h
            unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;				// ���[�J�[�R�[�h
            unitPriceCalcRet.RatePriorityOrder = rateProtyMng.RatePriorityOrder;			// �|���D�揇��
            unitPriceCalcRet.RateSettingDivide = rate.RateSettingDivide;	                // �|���ݒ�敪
            unitPriceCalcRet.RateMngGoodsCd = rate.RateMngGoodsCd;                          // �|���ݒ�敪�i���i�j
            unitPriceCalcRet.RateMngCustCd = rate.RateMngCustCd;                            // �|���ݒ�敪�i���Ӑ�j

            if (rateProtyMng.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim())
            {
                unitPriceCalcRet.RateMngGoodsNm = rateProtyMng.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                unitPriceCalcRet.RateMngCustNm = rateProtyMng.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
            }

            unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;							// �P���Z�o�敪
            unitPriceCalcRet.SectionCode = rate.SectionCode;                                // ���_�R�[�h
            unitPriceCalcRet.RateVal = rateVal;					                            // �|��
            unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;                         // �P���[�������P��
            unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;                           // �P���[�������敪
            unitPriceCalcRet.StdUnitPrice = stdPrice;										// ��P��
            unitPriceCalcRet.OpenPriceDiv = openPriceDiv;									// �I�[�v�����i�敪
            unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;							// �P���i�Ŕ��C�����j
            unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;							// �P���i�ō��C�����j
            unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;                    // ���i�J�n��
            unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;                    // �d����R�[�h

            #endregion

            unitPriceCalcRetList.Add(unitPriceCalcRet);

            return true;
        }
        // --- ADD yangyi 2013/05/10 for Redmine#35493 -------<<<<<<<<<<<
        
        // --- ADD ���O 2015/01/27 for Redmine#44581 ------->>>>>>>>>>>
        /// <summary>
        /// �|�����g�p���Ďd�������擾���܂��B(�I�������\)
        /// </summary>
        /// <param name="unitPriceCalcParamList">�d�����擾�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secList">���_�R�[�h ���X�g</param>
        /// <param name="rateRetList">�d�������ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        public int RateByRateList(List<UnitPriceCalcParamWork> unitPriceCalcParamList, string enterpriseCode, ArrayList secList, out List<RateWork> rateRetList)
        {
            rateRetList = new List<RateWork>();
            List<RateProtyMngWork> rateProtyMngList = null;
            //�|���}�X�^�̓ǂݍ���
            List<RateWork> rateList;
            this.SearchRateForInventoryDis(enterpriseCode, secList, out rateList);

            //�D��Ǘ��ǂݍ���
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            this.SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            for (int i = 0; i < unitPriceCalcParamList.Count; i++)
            {
                // �|���D��Ǘ������擾����
                rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, enterpriseCode, unitPriceCalcParamList[i].SectionCode, UnitPriceKind.UnitCost);
                if (rateProtyMngList == null)
                {
                    rateProtyMngList = new List<RateProtyMngWork>();
                }
                this.RateByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList[i], rateProtyMngList, ref rateRetList);
            }
            return 0;
        }
        /// <summary>
        /// �|���D�揇�ʁA�|���}�X�^�ɂ��d�����擾(�I�������\)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�d�����擾�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateRetList">�d�������ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���D�揇�ʁA�|���}�X�^�ɂ��|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        private void RateByRateListForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, List<RateProtyMngWork> rateProtyMngList, ref List<RateWork> rateRetList)
        {
            bool breakFlg = false;

            // �|���D�揇�ʏ��ɒP���v�Z����
            try
            {
                foreach (RateProtyMngWork rateProtyMng in rateProtyMngList)
                {
                    if (this.RateForInventory(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, ref rateRetList))
                    {
                        breakFlg = true;
                        break;
                    }
                }
            }
            finally
            {
                if (breakFlg == false)
                {
                    RateWork rateRet = new RateWork();

                    rateRet.UnitPriceKind = ((int)unitPriceKind).ToString();  // �P�����
                    rateRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                    rateRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                    rateRet.SectionCode = unitPriceCalcParam.SectionCode;     // ���_�R�[�h
                    rateRet.GoodsRateRank = unitPriceCalcParam.GoodsRateRank; // �w��
                    rateRet.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // ���i������
                    rateRet.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;   // BL���i�R�[�h
                    rateRet.BLGroupCode = unitPriceCalcParam.BLGroupCode;// BL�O���[�v�R�[�h
                    rateRetList.Add(rateRet); 
                }
            }
        }

        /// <summary>
        /// �|���ݒ�敪�ɏ]���Ďd�����擾(�I�������\)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�d�����擾�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <param name="rateRetList">�d�����擾���ʃI�u�W�F�N�g���X�g</param>
        /// <returns>True:�d�����擾�����AFalse:�d�����擾���s</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���D�揇�ʁA�|���}�X�^�ɂ��|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2015/01/27</br>
        /// </remarks>
        private bool RateForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, string sectionCode, RateProtyMngWork rateProtyMng, ref List<RateWork> rateRetList)
        {
            RateWork rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);

            // �\�ߍ���Ă�����Dictionay��������ɍ������̂��擾
            // �����������ꂢ�ȏ����������邩������܂���
            List<RateWork> tmpList = null;
            Hashtable d2 = (Hashtable)d1[rateCndtn.UnitPriceKind.Trim()];
            if (d2 != null)
            {
                Hashtable d3 = (Hashtable)d2[rateCndtn.RateSettingDivide.Trim()];
                if (d3 != null)
                {
                    Hashtable d4 = (Hashtable)d3[rateCndtn.GoodsNo.Trim()];
                    if (d4 != null)
                    {
                        Hashtable d5 = (Hashtable)d4[rateCndtn.SectionCode.Trim()];
                        if (d5 != null)
                        {
                            Hashtable d6 = (Hashtable)d5[rateCndtn.GoodsMakerCd];
                            if (d6 != null)
                            {
                                Hashtable d7 = (Hashtable)d6[rateCndtn.GoodsRateRank.Trim()];
                                if (d7 != null)
                                {
                                    Hashtable d8 = (Hashtable)d7[rateCndtn.GoodsRateGrpCode];
                                    if (d8 != null)
                                    {
                                        Hashtable d9 = (Hashtable)d8[rateCndtn.BLGroupCode];
                                        if (d9 != null)
                                        {
                                            Hashtable d10 = (Hashtable)d9[rateCndtn.BLGoodsCode];
                                            if (d10 != null)
                                            {
                                                Hashtable d11 = (Hashtable)d10[rateCndtn.CustomerCode];
                                                if (d11 != null)
                                                {
                                                    Hashtable d12 = (Hashtable)d11[rateCndtn.CustRateGrpCode];
                                                    if (d12 != null)
                                                    {
                                                        tmpList = (List<RateWork>)d12[rateCndtn.SupplierCd];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (tmpList == null || tmpList.Count == 0) return false;

            List<RateWork> findList = new List<RateWork>();
            //tmpList����LotCount�̏����ɍ���Ȃ����������[�u
            for (int i = 0; i < tmpList.Count; i++)
            {
                if (tmpList[i].LotCount >= rateCndtn.LotCount)
                {
                    findList.Add(tmpList[i]);
                }
            }

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new FractionProcMoney.RateComparer());
           

            // �擪�s�̃f�[�^���Ώۃf�[�^
            // ---UPD 2015/03/02 30940 �͌��� �ꐶ Shallow Copy�ɂ��ۑ������I�u�W�F�N�g���㏑������邽��Deep Copy�Ő������� ----------->>>>>>>>>>
            //RateWork rate = findList[0];          
            RateWork rate = new RateWork();
            rate.RateVal = findList[0].RateVal;
            // ---UPD 2015/03/02 30940 �͌��� �ꐶ Shallow Copy�ɂ��ۑ������I�u�W�F�N�g���㏑������邽��Deep Copy�Ő������� -----------<<<<<<<<<<
            rate.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
            rate.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
            rate.SectionCode = unitPriceCalcParam.SectionCode;     // ���_�R�[�h
            rate.GoodsRateRank = unitPriceCalcParam.GoodsRateRank; // �w��
            rate.GoodsRateGrpCode = unitPriceCalcParam.GoodsRateGrpCode; // ���i������
            rate.BLGoodsCode = unitPriceCalcParam.BLGoodsCode;   // BL���i�R�[�h
            rate.BLGroupCode = unitPriceCalcParam.BLGroupCode;// BL�O���[�v�R�[�h

            rateRetList.Add(rate);

            return true;
        }
        // --- ADD ���O 2015/01/27 for Redmine#44581 -------<<<<<<<<<<<
        

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg">���b�Z�[�W</param>
        public static void LogWrite(string pMsg)
        {
#if LOG
			System.IO.FileStream _fs;										// �t�@�C���X�g���[��
			System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new System.IO.FileStream("PMHNB01010R.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
#endif
        }

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        ////----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        ///// <summary>
        ///// �|�����g�p���Č����P�����Z�o���܂��B(�I����p)
        ///// </summary>
        ///// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        ///// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        ///// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        //public void CalculateUnitCostForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        //{
        //    unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

        //    this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        //}
        ////----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B(�I����p)
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        public int CalculateUnitCostForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
            //int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();
            int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B(�I����p)
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <remarks>
        /// <br>Note       : �|�����g�p���Č����P�����Z�o���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/07/23</br>
        /// </remarks>
        public int CalculateUnitCostForInventory2(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, out List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();

            int status = this.CalculateUnitPriceProcForInventory(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            return status;
        }
        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// �|���}�X�^���������܂��B(�I����p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>�|�������X�e�[�^�X</returns>
        //private int SearchRateForInventory(string enterpriseCode,out List<RateWork> rateList)//DEL yangyi 2013/05/06 Redmine#35493
        public int SearchRateForInventory(string enterpriseCode, out List<RateWork> rateList) //ADD yangyi 2013/05/06 Redmine#35493
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            //status = rateDB.SearchForInventory(out rateWorkList, enterpriseCode, 0, 0);     //DEL yangyi 2013/05/06 Redmine#35493
            status = rateDB.SearchByUnitPriceKind(out rateWorkList, enterpriseCode, 2, 0, 0); //ADD yangyi 2013/05/06 Redmine#35493

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }
            
            MakeDictionary(rateList); //ADD yangyi 2013/05/06 Redmine#35493
            
            LogWrite("�|���擾�I��");
            return status;
        }

        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>
        /// �O���[�v�ʊ|���}�X�^����������B(�I����p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>�|�������X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �O���[�v�ʊ|���}�X�^���������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/07/23</br>
        /// </remarks>
        public int SearchRateForInventory2(string enterpriseCode, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;
            //�O���[�v�ʊ|���}�X�^����
            status = rateDB.SearchByUnitPriceKindByGroup(out rateWorkList, enterpriseCode, 0, 0);

            //�������ʂ��Z�b�g
            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);

            LogWrite("�|���擾�I��");
            return status;
        }
        // --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        //----- ADD 2014/05/13 �c���� for Redmine#36564 ------->>>>>
        /// <summary>
        /// �|���}�X�^�i�����j�̎擾(�I���\����p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secList">���_���X�g</param>
        /// <param name="makerList">���[�J�[���X�g</param>
        /// <param name="rateList">�擾����|�����X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/05/13</br>
        /// </remarks>
        public int SearchRateForInventoryDis(string enterpriseCode, ArrayList secList, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            // �����ݒ�̊|�����X�g���擾
            status = rateDB.SearchRateForInvoDis(out rateWorkList, enterpriseCode, secList, 2, 0);

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);
            
            LogWrite("�|���擾�I��");
            return status;
        }

        // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------>>>>>
        /// <summary>
        /// �|���}�X�^�i�����j�̎擾(�I���\����p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secList">���_���X�g</param>
        /// <param name="rateList">�擾����|�����X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/10/20</br>
        /// </remarks>
        public int SearchRateForInventoryDis2(string enterpriseCode, ArrayList secList, out List<RateWork> rateList)
        {
            RateDB rateDB = new RateDB();

            rateList = new List<RateWork>();
            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            object rateWorkList = null;

            // �����ݒ�̊|�����X�g���擾
            status = rateDB.SearchRateForInvoDis2(out rateWorkList, enterpriseCode, secList, 2, 0);

            if (rateWorkList != null)
            {
                ArrayList list = rateWorkList as ArrayList;

                rateList.AddRange((RateWork[])list.ToArray(typeof(RateWork)));
            }

            MakeDictionary(rateList);

            LogWrite("�|���擾�I��");
            return status;
        }
        // --- ADD 杍^ 2020/10/20 PMKOBETSU-3551�̑Ή� ------<<<<<
        //----- ADD 2014/05/13 �c���� for Redmine#36564 -------<<<<<

        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// RateWork��Dictionary(�I����p)
        /// </summary>
        private Hashtable d1 = null;

        /// <summary>
        /// RateWork��Dictionary�쐬(�I����p)
        /// </summary>
        /// <param name="rateList">�쐬����List</param>
        /// <remarks>
        /// <br>Note       : RateWork��Dictionary�쐬����</br>
        /// <br>Programmer : 22027 ���{�@����</br>
        /// <br>Date       : 2012.07.19</br>
        /// </remarks>
        private void MakeDictionary(List<RateWork> rateList)
        {
            d1 = new Hashtable();

            foreach (RateWork item in rateList)
            {
                Hashtable d2 = (Hashtable)d1[item.UnitPriceKind.Trim()];
                if (d2 != null)
                {
                    #region d2
                    Hashtable d3 = (Hashtable)d2[item.RateSettingDivide.Trim()];
                    if (d3 != null)
                    {
                        #region d3
                        Hashtable d4 = (Hashtable)d3[item.GoodsNo.Trim()];
                        if (d4 != null)
                        {
                            #region d4
                            Hashtable d5 = (Hashtable)d4[item.SectionCode.Trim()];
                            if (d5 != null)
                            {
                                #region d5
                                Hashtable d6 = (Hashtable)d5[item.GoodsMakerCd];
                                if (d6 != null)
                                {
                                    #region d6
                                    Hashtable d7 = (Hashtable)d6[item.GoodsRateRank.Trim()];
                                    if (d7 != null)
                                    {
                                        #region d7
                                        Hashtable d8 = (Hashtable)d7[item.GoodsRateGrpCode];
                                        if (d8 != null)
                                        {
                                            #region d8
                                            Hashtable d9 = (Hashtable)d8[item.BLGroupCode];
                                            if (d9 != null)
                                            {
                                                #region d9
                                                Hashtable d10 = (Hashtable)d9[item.BLGoodsCode];
                                                if (d10 != null)
                                                {
                                                    #region d10
                                                    Hashtable d11 = (Hashtable)d10[item.CustomerCode];
                                                    if (d11 != null)
                                                    {
                                                        #region d11
                                                        Hashtable d12 = (Hashtable)d11[item.CustRateGrpCode];
                                                        if (d12 != null)
                                                        {
                                                            List<RateWork> list = (List<RateWork>)d12[item.SupplierCd];
                                                            if (list != null) 
                                                            {
                                                                list.Add(item); 
                                                            }
                                                            else 
                                                            {
                                                                list = new List<RateWork>(); 
                                                                list.Add(item);
                                                                d12.Add(item.SupplierCd, list);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            d12 = new Hashtable();
                                                            List<RateWork> list = new List<RateWork>();
                                                            list.Add(item);
                                                            d12.Add(item.SupplierCd, list);
                                                            d11.Add(item.CustRateGrpCode, d12);
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        List<RateWork> list = new List<RateWork>();
                                                        list.Add(item);
                                                        Hashtable d12 = new Hashtable();
                                                        d12.Add(item.SupplierCd, list);
                                                        d11 = new Hashtable();
                                                        d11.Add(item.CustRateGrpCode, d12);
                                                        d10.Add(item.CustomerCode, d11);
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    List<RateWork> list = new List<RateWork>();
                                                    list.Add(item);
                                                    Hashtable d12 = new Hashtable();
                                                    d12.Add(item.SupplierCd, list);
                                                    Hashtable d11 = new Hashtable();
                                                    d11.Add(item.CustRateGrpCode, d12);
                                                    d10 = new Hashtable();
                                                    d10.Add(item.CustomerCode, d11);
                                                    d9.Add(item.BLGoodsCode, d10);
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                List<RateWork> list = new List<RateWork>();
                                                list.Add(item);
                                                Hashtable d12 = new Hashtable();
                                                d12.Add(item.SupplierCd, list);
                                                Hashtable d11 = new Hashtable();
                                                d11.Add(item.CustRateGrpCode, d12);
                                                Hashtable d10 = new Hashtable();
                                                d10.Add(item.CustomerCode, d11);
                                                d9 = new Hashtable();
                                                d9.Add(item.BLGoodsCode, d10);
                                                d8.Add(item.BLGroupCode, d9);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            List<RateWork> list = new List<RateWork>();
                                            list.Add(item);
                                            Hashtable d12 = new Hashtable();
                                            d12.Add(item.SupplierCd, list);
                                            Hashtable d11 = new Hashtable();
                                            d11.Add(item.CustRateGrpCode, d12);
                                            Hashtable d10 = new Hashtable();
                                            d10.Add(item.CustomerCode, d11);
                                            Hashtable d9 = new Hashtable();
                                            d9.Add(item.BLGoodsCode, d10);
                                            d8 = new Hashtable();
                                            d8.Add(item.BLGroupCode, d9);
                                            d7.Add(item.GoodsRateGrpCode, d8);
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        List<RateWork> list = new List<RateWork>();
                                        list.Add(item);
                                        Hashtable d12 = new Hashtable();
                                        d12.Add(item.SupplierCd, list);
                                        Hashtable d11 = new Hashtable();
                                        d11.Add(item.CustRateGrpCode, d12);
                                        Hashtable d10 = new Hashtable();
                                        d10.Add(item.CustomerCode, d11);
                                        Hashtable d9 = new Hashtable();
                                        d9.Add(item.BLGoodsCode, d10);
                                        Hashtable d8 = new Hashtable();
                                        d8.Add(item.BLGroupCode, d9);
                                        d7 = new Hashtable();
                                        d7.Add(item.GoodsRateGrpCode, d8);
                                        d6.Add(item.GoodsRateRank.Trim(), d7);
                                    }

                                    #endregion
                                }
                                else
                                {
                                    List<RateWork> list = new List<RateWork>();
                                    list.Add(item);
                                    Hashtable d12 = new Hashtable();
                                    d12.Add(item.SupplierCd, list);
                                    Hashtable d11 = new Hashtable();
                                    d11.Add(item.CustRateGrpCode, d12);
                                    Hashtable d10 = new Hashtable();
                                    d10.Add(item.CustomerCode, d11);
                                    Hashtable d9 = new Hashtable();
                                    d9.Add(item.BLGoodsCode, d10);
                                    Hashtable d8 = new Hashtable();
                                    d8.Add(item.BLGroupCode, d9);
                                    Hashtable d7 = new Hashtable();
                                    d7.Add(item.GoodsRateGrpCode, d8);
                                    d6 = new Hashtable();
                                    d6.Add(item.GoodsRateRank.Trim(), d7);
                                    d5.Add(item.GoodsMakerCd, d6);
                                }
                                #endregion
                            }
                            else
                            {
                                List<RateWork> list = new List<RateWork>();
                                list.Add(item);
                                Hashtable d12 = new Hashtable();
                                d12.Add(item.SupplierCd, list);
                                Hashtable d11 = new Hashtable();
                                d11.Add(item.CustRateGrpCode, d12);
                                Hashtable d10 = new Hashtable();
                                d10.Add(item.CustomerCode, d11);
                                Hashtable d9 = new Hashtable();
                                d9.Add(item.BLGoodsCode, d10);
                                Hashtable d8 = new Hashtable();
                                d8.Add(item.BLGroupCode, d9);
                                Hashtable d7 = new Hashtable();
                                d7.Add(item.GoodsRateGrpCode, d8);
                                Hashtable d6 = new Hashtable();
                                d6.Add(item.GoodsRateRank.Trim(), d7);
                                d5 = new Hashtable();
                                d5.Add(item.GoodsMakerCd, d6);
                                d4.Add(item.SectionCode.Trim(), d5);
                            }
                            #endregion
                        }
                        else
                        {
                            List<RateWork> list = new List<RateWork>();
                            list.Add(item);
                            Hashtable d12 = new Hashtable();
                            d12.Add(item.SupplierCd, list);
                            Hashtable d11 = new Hashtable();
                            d11.Add(item.CustRateGrpCode, d12);
                            Hashtable d10 = new Hashtable();
                            d10.Add(item.CustomerCode, d11);
                            Hashtable d9 = new Hashtable();
                            d9.Add(item.BLGoodsCode, d10);
                            Hashtable d8 = new Hashtable();
                            d8.Add(item.BLGroupCode, d9);
                            Hashtable d7 = new Hashtable();
                            d7.Add(item.GoodsRateGrpCode, d8);
                            Hashtable d6 = new Hashtable();
                            d6.Add(item.GoodsRateRank.Trim(), d7);
                            Hashtable d5 = new Hashtable();
                            d5.Add(item.GoodsMakerCd, d6);
                            d4 = new Hashtable();
                            d4.Add(item.SectionCode.Trim(), d5);
                            d3.Add(item.GoodsNo.Trim(), d4);
                        }
                        #endregion
                    }
                    else
                    {
                        List<RateWork> list = new List<RateWork>();
                        list.Add(item);
                        Hashtable d12 = new Hashtable();
                        d12.Add(item.SupplierCd, list);
                        Hashtable d11 = new Hashtable();
                        d11.Add(item.CustRateGrpCode, d12);
                        Hashtable d10 = new Hashtable();
                        d10.Add(item.CustomerCode, d11);
                        Hashtable d9 = new Hashtable();
                        d9.Add(item.BLGoodsCode, d10);
                        Hashtable d8 = new Hashtable();
                        d8.Add(item.BLGroupCode, d9);
                        Hashtable d7 = new Hashtable();
                        d7.Add(item.GoodsRateGrpCode, d8);
                        Hashtable d6 = new Hashtable();
                        d6.Add(item.GoodsRateRank.Trim(), d7);
                        Hashtable d5 = new Hashtable();
                        d5.Add(item.GoodsMakerCd, d6);
                        Hashtable d4 = new Hashtable();
                        d4.Add(item.SectionCode.Trim(), d5);
                        d3 = new Hashtable();
                        d3.Add(item.GoodsNo.Trim(), d4);
                        d2.Add(item.RateSettingDivide.Trim(), d3);
                    }
                    #endregion
                }
                else
                {
                    List<RateWork> list = new List<RateWork>();
                    list.Add(item);
                    Hashtable d12 = new Hashtable();
                    d12.Add(item.SupplierCd, list);
                    Hashtable d11 = new Hashtable();
                    d11.Add(item.CustRateGrpCode, d12);
                    Hashtable d10 = new Hashtable();
                    d10.Add(item.CustomerCode, d11);
                    Hashtable d9 = new Hashtable();
                    d9.Add(item.BLGoodsCode, d10);
                    Hashtable d8 = new Hashtable();
                    d8.Add(item.BLGroupCode, d9);
                    Hashtable d7 = new Hashtable();
                    d7.Add(item.GoodsRateGrpCode, d8);
                    Hashtable d6 = new Hashtable();
                    d6.Add(item.GoodsRateRank.Trim(), d7);
                    Hashtable d5 = new Hashtable();
                    d5.Add(item.GoodsMakerCd, d6);
                    Hashtable d4 = new Hashtable();
                    d4.Add(item.SectionCode.Trim(), d5);
                    Hashtable d3 = new Hashtable();
                    d3.Add(item.GoodsNo.Trim(), d4);
                    d2 = new Hashtable();
                    d2.Add(item.RateSettingDivide.Trim(), d3);
                    d1.Add(item.UnitPriceKind.Trim(), d2);
                }
            }
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            // ���i���X�g�������ꍇ�͏������Ȃ�
            if ((goodsUnitData == null) || (goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo) || (goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd))
            {
                return;
            }
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

            goodsUnitDataList.Add(goodsUnitData);
            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            LogWrite(string.Format("�P���Z�o �J�n {0}��:", unitPriceCalcParamList.Count));

            // �p�����[�^���X�g�A���i�A���f�[�^�I�u�W�F�N�g���X�g��������Ώ������Ȃ�
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return;

            }
            //��ƃR�[�h�擾
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("�d�����z�����敪�ǂݍ���");


            //�d�����z�����敪�}�X�^�ǂݍ���
            List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(enterpriseCode);


            LogWrite("�|���ǂݍ���");
            //�D��Ǘ��ǂݍ���
            List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(enterpriseCode);
            // �|���}�X�^�̓ǂݍ���
            List<RateWork> rateList;

            int status = this.SearchRateForInventory(enterpriseCode, out rateList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rateList = null;
            }
            else
            {
                LogWrite(string.Format("�|�� {0}���擾", rateList.Count));
            }

            LogWrite("�����v�Z");

            // �����v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.UnitCost))
            {
                //this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//DEL yangyi 2013/05/17 Redmine#35493
                this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);//ADD yangyi 2013/05/17Redmine#35493
            }

            LogWrite("�P���Z�o �I��");
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<
        */
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);

            int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
            return status;
        }

        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParamWork unitPriceCalcParam, GoodsUnitDataWork goodsUnitData, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ���i���X�g�������ꍇ�͏������Ȃ�
            if ((goodsUnitData == null) || (goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo) || (goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd))
            {
                return status;
            }
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>();
            unitPriceCalcParamList.Add(unitPriceCalcParam);
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();

            goodsUnitDataList.Add(goodsUnitData);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
            //status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();

            status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
            return status;
        }

        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>  
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        //private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private int CalculateUnitPriceProcForInventory(UnitPriceKind unitPriceKind, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        {
            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(unitPriceKind);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
            //int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
            int status = this.CalculateUnitPriceProcForInventory(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
            return status;
        }

        /// <summary>
        /// �P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|��Dic</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        //private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        private int CalculateUnitPriceProcForInventory(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList)
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            LogWrite(string.Format("�P���Z�o �J�n {0}��:", unitPriceCalcParamList.Count));

            // �p�����[�^���X�g�A���i�A���f�[�^�I�u�W�F�N�g���X�g��������Ώ������Ȃ�
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return status;

            }
            //��ƃR�[�h�擾
            string enterpriseCode = (goodsUnitDataList[0] as GoodsUnitDataWork).EnterpriseCode;

            LogWrite("�d�����z�����敪�ǂݍ���");


            //�d�����z�����敪�}�X�^�ǂݍ���
            List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();

            status = this.SearchStockProcMoneyForInventory(enterpriseCode, out stockProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }

            LogWrite("�|���ǂݍ���");
            //�D��Ǘ��ǂݍ���
            List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
            status = SearchRateProtyMngForInventory(enterpriseCode, out rateProtyMngAllList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }
            // �|���}�X�^�̓ǂݍ���
            List<RateWork> rateList;

            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
            //status = this.SearchRateForInventory(enterpriseCode, out rateList);
            status = this.SearchRateForInventory2(enterpriseCode, out rateList);
            // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;

            }else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rateList = null;
            }
            else
            {
                LogWrite(string.Format("�|�� {0}���擾", rateList.Count));
            }

            LogWrite("�����v�Z");

            // �����v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.UnitCost))
            {

                // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                //this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, ref unitPriceCalcRetList, rateProtyMngAllList);
                this.CalculateUnitCostPriceProcForInventory(unitPriceCalcParamList, goodsUnitDataList, rateList, stockProcMoneyList, rateWorkByGoodsNoDic, ref unitPriceCalcRetList, rateProtyMngAllList);
                // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
            }

            LogWrite("�P���Z�o �I��");
            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        // --- ADD yangyi 2013/05/17 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// �����P���v�Z����(�I����p)
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�\���f�[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="rateWorkByGoodsNoDic">�P�i�|���}�X�^Dic</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <param name="rateProtyMngAllList">�|���D��Ǘ����X�g</param>
        /// <returns></returns>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|���D�揇�ʂ��]������Ȃ��i��1949�j</br>
        /// <br>                             �G���[�������������o�^����Ȃ����̑Ή��ŃG���[�����ǉ�(#8�̌�)</br>
        /// <br>Update Note: 2020/07/23 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11675035-00</br>
        /// <br>             PMKOBETSU-3551�F�I���������������s����Ə����Ɏ��s���錻�ۂ̉���</br>
        /// <br>Update Note: 2021/03/16 杍^</br>
        /// <br>�Ǘ��ԍ�   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551�F�I�����������ƒI���\���̏�Q�Ή�</br>
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
        //private void CalculateUnitCostPriceProcForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)
        private void CalculateUnitCostPriceProcForInventory(List<UnitPriceCalcParamWork> unitPriceCalcParamList, List<GoodsUnitDataWork> goodsUnitDataList, List<RateWork> rateList, List<StockProcMoneyWork> stockProcMoneyList, Dictionary<string, RateWork> rateWorkByGoodsNoDic, ref List<UnitPriceCalcRetWork> unitPriceCalcRetList, List<RateProtyMngWork> rateProtyMngAllList)
        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
        {
            List<RateProtyMngWork> rateProtyMngList = null;

            foreach (UnitPriceCalcParamWork unitPriceCalcParam in unitPriceCalcParamList)
            {
                // ����ł̒[�������P�ʁA�[�������敪���擾
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(FractionProcMoney.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                GoodsUnitDataWork goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
                GoodsPriceUWork goodsPrice;
                bool calcPrice = false;
                this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

                if (goodsPrice != null)
                {
                    double unitPriceTaxExc = 0;
                    double unitPriceTaxInc = 0;
                    int fractionProcCode = 0;
                    double unPrcFracProcUnit = 0;
                    int unPrcFracProcDiv = 0;
                    double stdPrice = 0;
                    int taxationCode = 0;
                    double stockRate = 0;

                    // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //// --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                    //// �����i�̉��i���ݒ�̏ꍇ�A�P�i�|���̉��i�A�d�������Z�b�g����
                    //if ((goodsPrice.SalesUnitCost == 0) && ((goodsPrice.StockRate == 0 || goodsPrice.ListPrice == 0)))
                    //{
                    //    string key = unitPriceCalcParam.SectionCode.Trim() + "-" + unitPriceCalcParam.GoodsMakerCd.ToString("D4") + "-" + unitPriceCalcParam.GoodsNo.Trim();
                    //    if (rateWorkByGoodsNoDic.ContainsKey(key))
                    //    {
                    //        goodsPrice.SalesUnitCost = rateWorkByGoodsNoDic[key].PriceFl;
                    //        if (goodsPrice.LogicalDeleteCode == 0)
                    //        {
                    //            goodsPrice.StockRate = rateWorkByGoodsNoDic[key].RateVal;
                    //        }
                    //    }
                    //}
                    //// --- ADD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                    // --- DEL 杍^ 2021/03/16 PMKOBETSU-3551�̑Ή� ------<<<<<

                    // ���P�������ڃZ�b�g����Ă���ꍇ
                    if (goodsPrice.SalesUnitCost != 0)
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // ���i�̉ېŕ����ɏ]���ĕ���
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                unitPriceTaxExc = goodsPrice.SalesUnitCost;
                                unitPriceTaxInc = goodsPrice.SalesUnitCost;
                                break;
                        }
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // �d�������Z�b�g����Ă��āA�艿���[���ȊO
                    else if ((goodsPrice.StockRate != 0) && (goodsPrice.ListPrice != 0))
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        stockRate = goodsPrice.StockRate;

                        stdPrice = goodsPrice.ListPrice;
                        double stdPriceWk = goodsPrice.ListPrice;
                        taxationCode = unitPriceCalcParam.TaxationDivCd;

                        //--------------------------------------------------
                        // �v�Z�p�艿�̎Z��
                        //--------------------------------------------------
                        // �]�ŕ����u��ېŁv���́A��P����Ŕ����P���Ƃ��Čv�Z����
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            if (unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                stdPrice -= CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, stdPrice);
                                stdPriceWk = stdPrice;
                            }
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }

                        fractionProcCode = unitPriceCalcParam.StockUnPrcFrcProcCd;	// �d���P���[�������R�[�h

                        this.CalculateUnitPriceByRate(UnitPriceKind.UnitCost,
                            fractionProcCode,
                            taxationCode,
                            stdPriceWk,
                            unitPriceCalcParam.TaxRate,
                            taxFractionProcUnit,
                            taxFractionProcCd,
                            goodsPrice.StockRate,
                            stockProcMoneyList,
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

                    // �����܂łŌ����v�Z���ꂽ�ꍇ�͌��ʂ��Z�b�g
                    if (calcPrice)
                    {
                        UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                        unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();
                        unitPriceCalcRet.UnitPrcCalcDiv = (int)unitPrcCalcDiv;
                        unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
                        unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
                        unitPriceCalcRet.RateVal = stockRate;
                        unitPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
                        unitPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
                        unitPriceCalcRet.StdUnitPrice = stdPrice;
                        unitPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
                        unitPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                        unitPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                        unitPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;

                        unitPriceCalcRetList.Add(unitPriceCalcRet);
                    }
                    else
                    {
                        // �|���D��Ǘ������擾����
                        rateProtyMngList = this.GetRateProtyMngList(rateProtyMngAllList, goodsUnitData.EnterpriseCode, unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);//ADD on 2012/07/10 for Redmine#31103
                        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                        //if (rateProtyMngList != null)
                        //{
                        //    this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        //}
                        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                        if (rateProtyMngList == null)
                        {
                            rateProtyMngList = new List<RateProtyMngWork>();
                        }
                        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------>>>>>
                        //this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList);
                        this.CalculateUnitPriceByRateListForInventory(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, stockProcMoneyList, goodsUnitData, ref unitPriceCalcRetList, rateWorkByGoodsNoDic);
                        // --- UPD 杍^ 2020/07/23 PMKOBETSU-3551�̑Ή� ------<<<<<
                        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    }
                }
                else
                {
                    UnitPriceCalcRetWork unitPriceCalcRet = new UnitPriceCalcRetWork();

                    unitPriceCalcRet.UnitPriceKind = ((int)UnitPriceKind.UnitCost).ToString();       // �P�����
                    unitPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;             // ���i�R�[�h
                    unitPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;   // ���[�J�[�R�[�h
                    unitPriceCalcRet.SupplierCd = 0;                                   // �d����R�[�h

                    unitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
        }
        // --- ADD yangyi 2013/05/17 for Redmine#35493 -------<<<<<<<<<<<

        //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /// <summary>
        /// �|���D��Ǘ�����
        /// </summary>
        public int SearchRateProtyMngForInventory(string _enterpriseCode, out List<RateProtyMngWork> _rateProtyMngAllList)
        {
            _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            ReadComCompanyInf(_enterpriseCode);// ADD caohh 2015/03/06 for Redmine#44951

            object rateProtyMngWorkList = null;

            //�|���D��Ǘ��̓ǂݍ���
            int status = rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0, 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // ���_�A�P����ށA�D�揇�ʂŃ\�[�g
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return status;
        }

        // --- ADD caohh 2015/03/06 for Redmine#44951 ----->>>>>
        /// <summary>
        ///���Аݒ�}�X�^����|���D�揇�ʂ̎擾����
        /// </summary>
        /// <param name="_enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���Аݒ�}�X�^����|���D�揇�ʂ̐ݒ���擾���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2015/03/06</br>
        /// <br>Update Note: 2015/03/23 xuyb</br>
        /// <br>�Ǘ��ԍ�   : 11070253-00 </br>
        /// <br>           : Redmine#44492��#99 ���㌎���X�V�̎d���P���E�d�����Z�o�s��̏C���i#44951��#50��No.2�j�Ή�</br>
        /// </remarks>
        private void ReadComCompanyInf(string _enterpriseCode)
        {
            // �����[�g�I�u�W�F�N�g�擾
            CompanyInfDB companyInfDB = new CompanyInfDB();

            CompanyInfWork companyInfWork = new CompanyInfWork();
            companyInfWork.EnterpriseCode = _enterpriseCode;
            companyInfWork.CompanyCode = 0;	//����肠�����O�Œ�ǂ�
            object paraObj = companyInfWork;

            if (this._ratePriorityDivDic == null) this._ratePriorityDivDic = new Dictionary<string, int>();  //�D�拉 // ADD xuyb 2015/03/23 for Redmine#44492
            int status = companyInfDB.Read(ref paraObj, 0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                companyInfWork = (CompanyInfWork)paraObj;
                //this._ratePriorityDiv = companyInfWork.RatePriorityDiv;  // DEL xuyb 2015/03/23 for Redmine#44492
                // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 --------------->>>>>
                if (this._ratePriorityDivDic.ContainsKey(_enterpriseCode))
                {
                    this._ratePriorityDivDic[_enterpriseCode] = companyInfWork.RatePriorityDiv;
                }
                else
                {
                    this._ratePriorityDivDic.Add(_enterpriseCode, companyInfWork.RatePriorityDiv);
                }
                // --------------------- ADD xuyb 2015/03/23 for Redmine#44492 ---------------<<<<<
            }
        }
        // --- ADD caohh 2015/03/06 for Redmine#44951 -----<<<<<

        // <summary>
        /// �d�����z�[�������敪�ݒ茟��
        /// </summary>
        public int SearchStockProcMoneyForInventory(string _enterpriseCode, out List<StockProcMoneyWork> _stockProcMoneyList)
        {
            _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return status;
        }
        //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
	}

}