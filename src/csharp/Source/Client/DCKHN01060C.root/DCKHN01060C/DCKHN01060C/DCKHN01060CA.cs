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
using Broadleaf.Application.Controller;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �P���Z�o�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �|���ɏ]���Ĕ���P���A�d���P���A�艿�̎Z�o���s���܂��B</br>
	/// <br>Programmer	: 21024�@���X�� ��</br>
	/// <br>Date		: 2008.06.19</br>
    /// <br></br>
    /// <br>UpdateNote : 2009.06.16  22018 ��� ���b</br>
    /// <br>           : ���Ӑ�|���O���[�v=0000�̐ݒ�ɑΉ��B</br>
    /// <br>UpdateNote : 2010/03/01 ����� PM.NS�ێ�˗��T�����ǑΉ�</br>
    /// <br>             �P�����W���[���̊|���D��Ǘ��}�X�^�L���b�V���������g�p����悤�ɕύX</br>
    /// <br>UpdateNote : 2010/06/02 ���M PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.4</br>
    /// <br>             �艿��|����ύX���Ă������A�������������Čv�Z����Ȃ��ɉ��C</br>
    /// <br>UpdateNote : 2010/12/02 20056 ���n ��� </br>
    /// <br>           : �艿�Z�o���̒[�������P�ʁA�[�������敪�𔄒P���̒P�ʂƋ敪���Q�Ƃ��Ȃ��悤�ɕύX</br>
    /// <br>UpdateNote : 2011/02/16 22018 ��� ���b</br>
    /// <br>           : ���ʃN���X�Ƀ��b�g�͈͂̊J�n/�I����ǉ�(�G���g���Ŏg�p)</br>
    /// <br>UpdateNote : 2011/07/20 wangf</br>
    /// <br>           : �D��Č��A��16�Ή�  �|���ݒ�Ɋւ��āA00�S�Ћ��� �� ���_�̊|���̗D�揇�ʂ̓������iWAN�^�p�j</br>
    /// <br>Update Note: 2011/09/01 �A��681 ���юR 10704766-00 </br>
    /// <br>             ���艿���\���̂�ǉ�</br>
    /// <br>Update Note: 2011/11/22 yangmj</br>
    /// <br>             redmine #7729 BL�R�[�h�������ʂŌ������[���ɂȂ�̕ύX </br>
    /// <br>Update Note: 2013/05/30 huangt</br>
    /// <br>             PM-TAB�Ή� </br>
    /// <br>Update Note: 2014/02/05 �g��</br>
    /// <br>             �d�|�ꗗ��10631 �����񓚑��x���P �|���}�X�^�L���b�V��</br>
    /// <br>Update Note: K2014/02/09 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10970681-00 �O�����a����ʌʑΉ�</br>
    /// <br>           : ����`�[���͂̉��ǑΉ�</br>
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

        // 2011/07/20 add wangf start
        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Public Property
        /// <summary> ���_�D��v���p�e�B </summary>
        public int RatePriorityDiv
        {
            get { return this._ratePriorityDiv; }
            set { this._ratePriorityDiv = value; }
        }
        #endregion
        // 2011/07/20 add wangf end

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members

		private List<SalesProcMoney> _salesProcMoneyList;										// ������z�����敪�ݒ胊�X�g
		private List<StockProcMoney> _stockProcMoneyList;										// �d�����z�����敪�ݒ胊�X�g
		private string _enterpriseCode;

		private const int ctAllSet = 1000;														// �S�Аݒ�Ƃ̋���

        // --- UPD 2010/03/01 ---------->>>>>
        //private static List<RateProtyMng> _rateProtyMngAllList = null;                          // �|���D�揇�ʏ�񃊃X�g�i�S���j
        private List<RateProtyMng> _rateProtyMngAllList = null;                                 // �|���D�揇�ʏ�񃊃X�g�i�S���j
        // --- UPD 2010/03/01 ----------<<<<<
        private List<RateProtyMng> _lastRateProtyMngList = null;                                // �|���D�揇�ʏ�񃊃X�g�i�Ō�Ɋ|���D�揇�ʂ��擾�������̃L���b�V���j
        private string _lastSectionCode = string.Empty;                                         // �Ō�Ɋ|���D�揇�ʂ��擾�������_�R�[�h
        private UnitPriceKind _lastUnitPriceKind;                                               // �Ō�Ɋ|���D�揇�ʂ��擾�����P�����
        // 2011/07/20 add wangf start
        private int _ratePriorityDiv = 0;                                                       // ���_�D��
        // 2011/07/20 add wangf end

        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
        /// <summary> �����ς݊|���}�X�^�L���b�V�� �c�a�o�^�L�� </summary>
        private List<Rate> _rateMstList;
        /// <summary> �����ς݊|���}�X�^�L���b�V�� �c�a�o�^���� </summary>
        private List<Rate> _rateMstListNotFound;
        /// <summary> �����ς݊|���}�X�^�L���b�V���t���O </summary>
        private bool rateCache;
        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<
		# endregion

        // ===================================================================================== //
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
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
            _rateMstList = new List<Rate>();
            _rateMstListNotFound = new List<Rate>();
            rateCache = false;
            // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// �P���Z�o�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 21024�@���X�� ��</br>
		/// <br>Date       : 2007.11.12</br>
		/// </remarks>
		public UnitPriceCalculation( List<SalesProcMoney> salesProcMoneyList, List<StockProcMoney> stockProcMoneyList )
		{
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			this.CacheSalesProcMoneyList(salesProcMoneyList);
			this.CacheStockProcMoneyList(stockProcMoneyList);
		}

		# endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region��Public Methods

		#region �}�X�^�L���b�V��

		/// <summary>
		/// �d�����z�[�������敪�ݒ�}�X�^��P���Z�o�N���X���ɃL���b�V�����܂��B
		/// </summary>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^���X�g</param>
        public void CacheStockProcMoneyList( List<StockProcMoney> stockProcMoneyList )
		{
			this._stockProcMoneyList = stockProcMoneyList;

            this._stockProcMoneyList.Sort(new DCKHN01060CF.StockProcMoneyComparer());
		}

		/// <summary>
        /// ������z�[�������敪�ݒ�}�X�^��P���Z�o�N���X���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="salesProcMoneyList">������z�����敪�ݒ�}�X�^���X�g</param>
        public void CacheSalesProcMoneyList( List<SalesProcMoney> salesProcMoneyList )
		{
			this._salesProcMoneyList = salesProcMoneyList;

            this._salesProcMoneyList.Sort(new DCKHN01060CF.SalesProcMoneyComparer());
		}

        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>
        /// �|���D��Ǘ��}�X�^��P���Z�o�N���X���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="rateProtyMngAllList">�|���D��Ǘ��}�X�^���X�g</param>
        public void CacheRateProtyMngAllList(List<RateProtyMng> rateProtyMngAllList)
        {
            this._rateProtyMngAllList = rateProtyMngAllList;

            this._rateProtyMngAllList.Sort(new DCKHN01060CF.RateProtyMngComparer());
        }
        // --- ADD 2010/03/01 ----------<<<<<
		#endregion

		#region �����P���v�Z����
		/// <summary>
		/// �|�����g�p���Č����P�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		public void CalculateUnitCost( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// �|�����g�p���Č����P�����Z�o���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        public void CalculateUnitCost( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

		#endregion

		#region �艿�v�Z����
		/// <summary>
        /// �|�����g�p���Ē艿���Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		public void CalculateListPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

		/// <summary>
        /// �|�����g�p���Ē艿���Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		public void CalculateListPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
		}

		#endregion

		#region �����P���v�Z����
		/// <summary>
        /// �|�����g�p���Ĕ���P�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		/// <remarks>
		///		Note	: ����UP��,�e�����w�莞�́A�����P���������Z�o���܂��B
		/// </remarks>
		public void CalculateSalesUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            this.CalculateUnitPriceProc(UnitPriceKind.SalesUnitPrice, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}
        
        /// <summary>
        /// �|�����g�p���Ĕ���P�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		/// <remarks>
		///		Note	: ����UP��,�e�����w�莞�́A�����P���������Z�o���܂��B
		/// </remarks>
		public void CalculateSalesUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);

		}	
        #endregion

		#region ����֌W�̈ꊇ�v�Z

		/// <summary>
        /// �|�����g�p���Ē艿�A���㌴���P���A����P�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
		/// <remarks>
		///		Note	: ����UP��,�e���m�ۗ��w�莞�́A�����P���������Z�o���܂��B
		/// </remarks>
		public void CalculateSalesRelevanceUnitPrice( UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			unitPriceCalcRetList = new List<UnitPriceCalcRet>();

			List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
			unitPriceKindList.Add(UnitPriceKind.ListPrice);
			unitPriceKindList.Add(UnitPriceKind.UnitCost);
			unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

			this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParam, goodsUnitData, ref unitPriceCalcRetList);
		}

        /// <summary>
        /// �|�����g�p���Ē艿�A���㌴���P���A����P�����Z�o���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <remarks>
        ///		Note	: ����UP��,�e���m�ۗ��w�莞�́A�����P���������Z�o���܂��B
        /// </remarks>
        public void CalculateSalesRelevanceUnitPrice( List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.ListPrice);
            unitPriceKindList.Add(UnitPriceKind.UnitCost);
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList);
        }

        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �|�����g�p���Ē艿�A���㌴���P���A����P�����Z�o���܂��B
        /// �|���}�X�^���L���b�V�����܂��B
        /// </summary>
        /// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <remarks>
        ///		Note	: ����UP��,�e���m�ۗ��w�莞�́A�����P���������Z�o���܂��B
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceRateCache(UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            this.rateCache = true;
            this.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
        }

        /// <summary>
        /// �|�����g�p���Ē艿�A���㌴���P���A����P�����Z�o���܂��B
        /// �|���}�X�^���L���b�V�����܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <remarks>
        ///		Note	: ����UP��,�e���m�ۗ��w�莞�́A�����P���������Z�o���܂��B
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceRateCache(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            this.rateCache = true;
            this.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
        }
        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<

        // --- ADD huangt 2013/05/30 PM-TAB�Ή� ---------- >>>>>
        /// <summary>
        /// �|�����g�p���Ē艿�A���㌴���P���A����P�����Z�o���܂��B
        /// </summary>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <remarks>
        ///		Note	: ����UP��,�e���m�ۗ��w�莞�́A�����P���������Z�o���܂��B
        /// </remarks>
        public void CalculateSalesRelevanceUnitPriceForTablet(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList, out List<Rate> rateList)
        {
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            List<UnitPriceKind> unitPriceKindList = new List<UnitPriceKind>();
            unitPriceKindList.Add(UnitPriceKind.ListPrice);
            unitPriceKindList.Add(UnitPriceKind.UnitCost);
            unitPriceKindList.Add(UnitPriceKind.SalesUnitPrice);

            this.CalculateUnitPriceForTabletProc(unitPriceKindList, unitPriceCalcParamList, goodsUnitDataList, ref unitPriceCalcRetList, ref rateList);
        }
        // --- ADD huangt 2013/05/30 PM-TAB�Ή� ---------- <<<<<

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
		/// <param name="fracProcUnit">�[�������P�ʁi���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="fracProcCd">�[�������敪�i���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="unitPriceTaxExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceTaxInc">�P���i�ō��݁j</param>
		public void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, UnitPrcCalcDiv unitPrcCalcDiv, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
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

            this.CalculateUnitPriceByRate(unitPriceKind, fractionProcCode, taxationCodeWk, stdPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, rate, ref fracProcUnit, ref fracProcCd, out unitPriceTaxExc, out unitPriceTaxInc);
		}

		/// <summary>
		/// ��P������e�������g�p���ĒP�����Z�o���܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="totalAmountDispWayCd">���z�\���敪</param>
		/// <param name="ttlAmntDspRateDivCd">�|���K�p�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="costPrice">�����P���i�O�ŕi�F�Ŕ����P���A���ŕi�F�ō��ݒP���j</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="marginRate">�e����</param>
		/// <param name="fracProcUnit">�[�������P�ʁi���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="fracProcCd">�[�������敪�i���ݒ莞�͋��z�����敪�ݒ�}�X�^����擾�j</param>
		/// <param name="unitPriceTaxExc">�P���i�Ŕ����j</param>
		/// <param name="unitPriceTaxInc">�P���i�ō��݁j</param>
		public void CalculateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int totalAmountDispWayCd, int ttlAmntDspRateDivCd, int fractionProcCode, int taxationCode, double costPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double marginRate, ref double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			double costPriceWk = costPrice;
			int taxationCodeWk = taxationCode;

			//if (( totalAmountDispWayCd == 1 ) &&		// ���z�\������
			//    ( ttlAmntDspRateDivCd == 0 ) &&			// �|���K�p�敪�u0�F�ō��P���v
			//    ( taxationCode == 0 ))					// �O�ŕi
			//{
			//    // �ō��P������Ƃ��A���łƓ����v�Z���s��
			//    costPriceWk += CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, costPrice);
			//    taxationCodeWk = 2;
			//}

			this.CalculateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, taxationCodeWk, costPriceWk, taxRate, taxFracProcUnit, taxFracProcCd, marginRate, ref fracProcUnit, ref fractionProcCode, out unitPriceTaxExc, out unitPriceTaxInc);
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
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
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
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, UnitPriceCalcParam unitPriceCalcParam, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
			// ���i���X�g�������ꍇ�͏������Ȃ�
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsNo != unitPriceCalcParam.GoodsNo ) || ( goodsUnitData.GoodsMakerCd != unitPriceCalcParam.GoodsMakerCd ))
			{
				return;
			}
			List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
			unitPriceCalcParamList.Add(unitPriceCalcParam);
			List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

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
        private void CalculateUnitPriceProc( UnitPriceKind unitPriceKind, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
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
		private void CalculateUnitPriceProc( List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList )
		{
            LogWrite(string.Format("�P���Z�o �J�n {0}��:", unitPriceCalcParamList.Count));

            // �p�����[�^���X�g�A���i�A���f�[�^�I�u�W�F�N�g���X�g��������Ώ������Ȃ�
			if (( unitPriceCalcParamList == null ) || ( unitPriceCalcParamList.Count == 0 ) || ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ))
			{
				return;
            }

            LogWrite("�|���ǂݍ���");

            // �|���}�X�^�̓ǂݍ���
            List<Rate> rateList;

            // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
            // int status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);
            int status;
            if (rateCache)
            {
                status = this.SearchRateCache(unitPriceKindList, unitPriceCalcParamList, out rateList);
            }
            else
            {
                status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);
            }
            // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<

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
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);

            }

            LogWrite("�艿�v�Z");

            // �艿�v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.ListPrice))
            {
                this.CalculateListPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("�����v�Z");

            // �����v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.SalesUnitPrice))
            {
                this.CalculateSalesUnitPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("�P���Z�o �I��");
        }

		/// <summary>
		/// ���P���v�Z����
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
		/// <param name="goodsUnitDataList">���i�\���f�[�^���X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
		/// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        private void CalculateSalesUnitPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
                GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);

				// �|���D��Ǘ������擾����
                rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.SalesUnitPrice);

                if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                {
                    this.CalculateUnitPriceByRateList(UnitPriceKind.SalesUnitPrice, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetList);
                }
			}
		}

		/// <summary>
		/// �����P���v�Z����
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
		/// <param name="goodsUnitDataList">���i�\���f�[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
		/// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <br>Update Note: 2011/09/01 �A��681 ���юR 10704766-00 </br>
        /// <br>             ���艿���\���̂�ǉ�</br>
        /// <br>Update Note: 2011/11/22 yangmj</br>
        /// <br>             redmine #7729 BL�R�[�h�������ʂŌ������[���ɂȂ�̕ύX </br>
        private void CalculateUnitCostPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
                // ����ł̒[�������P�ʁA�[�������敪���擾
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

				GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				GoodsPrice goodsPrice;
				bool calcPrice = false;
				this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

                // -----ADD 2011/11/22----->>>>>
                GoodsPrice goodsPriceForUnitCost;
                this.GetPriceForUnitCost(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPriceForUnitCost);
                // -----ADD 2011/11/22-----<<<<<
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

                    stdPrice = goodsPrice.ListPrice; //ADD 2011/09/01
					// ���P�������ڃZ�b�g����Ă���ꍇ
                    //if (goodsPrice.SalesUnitCost != 0)// DEL 2011/11/22
                    if (goodsPriceForUnitCost.SalesUnitCost != 0)// ADD 2011/11/22
                    {
                        calcPrice = true;

                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        // ���i�̉ېŕ����ɏ]���ĕ���
                        switch (goodsUnitData.TaxationDivCd)
                        {
                            case (int)CalculateTax.TaxationCode.TaxInc:
                                //unitPriceTaxInc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxInc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxExc:
                                //unitPriceTaxExc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxExc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                break;
                            case (int)CalculateTax.TaxationCode.TaxNone:
                                //unitPriceTaxExc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                //unitPriceTaxInc = goodsPrice.SalesUnitCost;// DEL 2011/11/22
                                unitPriceTaxExc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                unitPriceTaxInc = goodsPriceForUnitCost.SalesUnitCost;// ADD 2011/11/22
                                break;
                        }
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // �d�������Z�b�g����Ă��āA�艿���[���ȊO
                    else if (( goodsPrice.StockRate != 0 ) && ( goodsPrice.ListPrice != 0 ))
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
                            ref unPrcFracProcUnit,
                            ref unPrcFracProcDiv,
                            out unitPriceTaxExc,
                            out unitPriceTaxInc);
                    }

					// �����܂łŌ����v�Z���ꂽ�ꍇ�͌��ʂ��Z�b�g
					if (calcPrice)
					{
						UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();

                        unitPriceCalcRet.UnitPriceKind = ( (int)UnitPriceKind.UnitCost ).ToString();
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
                        unitPriceCalcRet.RateUpdateTimeUnit = goodsPrice.UpdateDateTimeAdFormal;  //ADD yangyi K2014/02/09
						unitPriceCalcRetList.Add(unitPriceCalcRet);
					}
					else
					{
                        // �|���D��Ǘ������擾����
                        rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.UnitCost);

                        if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                        {
                            this.CalculateUnitPriceByRateList(UnitPriceKind.UnitCost, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetList);
                        }

					}
				}
			}
		}

		/// <summary>
		/// �艿�v�Z����
		/// </summary>
		/// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
		/// <param name="goodsUnitDataList">���i�\���f�[�^���X�g</param>
		/// <param name="rateList">�|�����X�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        private void CalculateListPriceProc(List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, List<Rate> rateList, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
		{
            List<RateProtyMng> rateProtyMngList = null;
        
			foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
			{
				// ����ł̒[�������P�ʁA�[�������敪���擾
				double taxFractionProcUnit;
				int taxFractionProcCd;
				this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

				GoodsUnitData goodsUnitData = SearchGoodsUnitData(goodsUnitDataList, unitPriceCalcParam);
				List<UnitPriceCalcRet> unitPriceCalcRetListWk = new List<UnitPriceCalcRet>();

                // �|���D��Ǘ������擾����
                rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, UnitPriceKind.ListPrice);
                if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                {
                    this.CalculateUnitPriceByRateList(UnitPriceKind.ListPrice, unitPriceCalcParam, rateProtyMngList, rateList, goodsUnitData, ref unitPriceCalcRetListWk);
                }

				UnitPriceCalcRet listPriceCalcRet = null;
				if (( unitPriceCalcRetListWk != null ) && ( unitPriceCalcRetListWk.Count > 0 ))
				{
					listPriceCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, unitPriceCalcRetListWk, unitPriceCalcParam);
				}
				// �|������̒艿�Z�o�Ɏ��s�����ꍇ�A�艿�����̂܂܃Z�b�g����
				if (listPriceCalcRet == null)
				{
					GoodsPrice goodsPrice;
					this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

					if (goodsPrice != null)
					{
						double unitPriceTaxExc = 0;
						double unitPriceTaxInc = 0;
						double unPrcFracProcUnit = 0;
						int unPrcFracProcDiv = 0;

						// �艿���Z�b�g����Ă���ꍇ
						if (goodsPrice.ListPrice != 0)
						{

                            switch (goodsUnitData.TaxationDivCd)
                            {
                                case (int)CalculateTax.TaxationCode.TaxInc:
                                    unitPriceTaxInc = goodsPrice.ListPrice;
                                    unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxInc);
                                    break;
                                case (int)CalculateTax.TaxationCode.TaxExc:
                                    unitPriceTaxExc = goodsPrice.ListPrice;
                                    unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(unitPriceCalcParam.TaxRate, taxFractionProcUnit, taxFractionProcCd, unitPriceTaxExc);
                                    break;
                                case (int)CalculateTax.TaxationCode.TaxNone:
                                    unitPriceTaxExc = goodsPrice.ListPrice;
                                    unitPriceTaxInc = goodsPrice.ListPrice;
                                    break;
                            }
                            // �]�ŕ����u��ېŁv���͐Ŕ����P�����Z�b�g����
                            if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                            {
                                unitPriceTaxInc = unitPriceTaxExc;
                            }

							listPriceCalcRet = new UnitPriceCalcRet();
                            listPriceCalcRet.UnitPriceKind = ( (int)UnitPriceKind.ListPrice ).ToString();
							listPriceCalcRet.GoodsNo = unitPriceCalcParam.GoodsNo;
							listPriceCalcRet.GoodsMakerCd = unitPriceCalcParam.GoodsMakerCd;
							listPriceCalcRet.UnPrcFracProcUnit = unPrcFracProcUnit;
							listPriceCalcRet.UnPrcFracProcDiv = unPrcFracProcDiv;
							//listPriceCalcRet.StdUnitPrice = goodsPrice.ListPrice;
                            listPriceCalcRet.StdUnitPrice = 0;
							listPriceCalcRet.OpenPriceDiv = goodsPrice.OpenPriceDiv;
							listPriceCalcRet.UnitPriceTaxExcFl = unitPriceTaxExc;
							listPriceCalcRet.UnitPriceTaxIncFl = unitPriceTaxInc;
                            listPriceCalcRet.PriceStartDate = goodsPrice.PriceStartDate;
                            listPriceCalcRet.SupplierCd = unitPriceCalcParam.SupplierCd;
						}
					}
				}

				if (listPriceCalcRet != null)
				{
					unitPriceCalcRetList.Add(listPriceCalcRet);
				}
			}
		}

		/// <summary>
		/// �|���D�揇�ʁA�|���}�X�^�ɂ��P���v�Z
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="unitPriceCalcParam">�P���v�Z�p�����[�^</param>
		/// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        private void CalculateUnitPriceByRateList(UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, List<Rate> rateList, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            if (rateList == null || rateList.Count == 0) return;

            // �|���D�揇�ʏ��ɒP���v�Z����
            try
            {
                foreach (RateProtyMng rateProtyMng in rateProtyMngList)
                {
                    if (this.CalculateUnitPrice(unitPriceKind, unitPriceCalcParam, rateProtyMng.SectionCode, rateProtyMng, rateList, goodsUnitData, ref unitPriceCalcRetList))
                    {
                        break;
                    }
                }
            }
            finally
            {
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
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="unitPriceCalcRetList">�P���Z�o���ʃI�u�W�F�N�g���X�g</param>
		/// <returns>True:�P���Z�o�����AFalse:�P���Z�o���s</returns>
        private bool CalculateUnitPrice(UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, string sectionCode, RateProtyMng rateProtyMng, List<Rate> rateList, GoodsUnitData goodsUnitData, ref List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region [ �Ώۂ̊|���}�X�^�𒊏o ]
            Rate rateCndtn = MakeRateFilter(sectionCode, unitPriceKind, unitPriceCalcParam, rateProtyMng.RateSettingDivide);


            List<Rate> findList = rateList.FindAll(delegate(Rate rate2)
                                        {
                                            if (( rate2.UnitPriceKind.Trim() == rateCndtn.UnitPriceKind.Trim() ) &&
                                                ( rate2.RateSettingDivide.Trim() == rateCndtn.RateSettingDivide.Trim() ) &&
                                                ( rate2.GoodsNo == rateCndtn.GoodsNo ) &&
                                                ( rate2.SectionCode.Trim() == rateCndtn.SectionCode.Trim() ) &&
                                                ( rate2.GoodsMakerCd == rateCndtn.GoodsMakerCd ) &&
                                                ( rate2.GoodsRateRank.Trim() == rateCndtn.GoodsRateRank.Trim() ) &&
                                                ( rate2.GoodsRateGrpCode == rateCndtn.GoodsRateGrpCode ) &&
                                                ( rate2.BLGroupCode == rateCndtn.BLGroupCode ) &&
                                                ( rate2.BLGoodsCode == rateCndtn.BLGoodsCode ) &&
                                                ( rate2.CustomerCode == rateCndtn.CustomerCode ) &&
                                                ( rate2.CustRateGrpCode == rateCndtn.CustRateGrpCode ) &&
                                                ( rate2.SupplierCd == rateCndtn.SupplierCd ) &&
                                                ( rate2.LotCount >= rateCndtn.LotCount ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });

            if (findList == null || findList.Count == 0) return false;

            findList.Sort(new DCKHN01060CF.RateComparer());

            #endregion

            double stdPrice = 0;			// ����i
            double stdPriceWk = stdPrice;	// ����i�i���ۂ̌v�Z�p�̒l�j
            double unitPriceTaxExc = 0;		// �Ŕ����P��
            double unitPriceTaxInc = 0;		// �ō��ݒP��
            int fractionProcCode = 0;		// �[�������R�[�h(0:�S��)
            int taxationCode = unitPriceCalcParam.TaxationDivCd;	// �ېŕ���
            int openPriceDiv = 0;
            UnitPrcCalcDiv unitPrcCalcDiv = UnitPrcCalcDiv.Price;
            double count = ( unitPriceCalcParam.CountFl == 0 ) ? 1 : Math.Abs(unitPriceCalcParam.CountFl);	// ����(0�̏ꍇ��1�Ōv�Z�A0�ȊO�͐�Βl)

            //--------------------------------------------------
            // �[�������R�[�h�̌���
            //--------------------------------------------------
            // �艿�A����P��
            if (( unitPriceKind == UnitPriceKind.ListPrice ) || ( unitPriceKind == UnitPriceKind.SalesUnitPrice ))
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

            if (( unitPriceCalcParam.ConsTaxLayMethod != 9 ) &&                                 // �]�ŕ����u��ېŁv������
                ( unitPriceKind == UnitPriceKind.SalesUnitPrice ) &&                            // ����P��
                ( unitPriceCalcParam.TotalAmountDispWayCd == 1 ) &&								// ���z�\������
                ( unitPriceCalcParam.TtlAmntDspRateDivCd == 0 ) &&								// �|���K�p�敪�u0�F�ō��P���v
                ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc ))	// �O��
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;	// ���łƓ����v�Z������
            }

            // �擪�s�̃f�[�^���Ώۃf�[�^
            Rate rate = findList[0];

            // --- ADD m.suzuki 2011/02/16 ---------->>>>>
            // �Ώۃf�[�^�̒��O�̃f�[�^���擾�i���b�g�͈͂̊J�n���擾����ׁj
            Rate bfRate = null;
            if ( rate != null )
            {
                List<Rate> wkList = rateList.FindAll( delegate( Rate rate0 )
                                            {
                                                if ( (rate0.UnitPriceKind.Trim() == rate.UnitPriceKind.Trim()) &&
                                                    (rate0.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim()) &&
                                                    (rate0.GoodsNo == rate.GoodsNo) &&
                                                    (rate0.SectionCode.Trim() == rate.SectionCode.Trim()) &&
                                                    (rate0.GoodsMakerCd == rate.GoodsMakerCd) &&
                                                    (rate0.GoodsRateRank.Trim() == rate.GoodsRateRank.Trim()) &&
                                                    (rate0.GoodsRateGrpCode == rate.GoodsRateGrpCode) &&
                                                    (rate0.BLGroupCode == rate.BLGroupCode) &&
                                                    (rate0.BLGoodsCode == rate.BLGoodsCode) &&
                                                    (rate0.CustomerCode == rate.CustomerCode) &&
                                                    (rate0.CustRateGrpCode == rate.CustRateGrpCode) &&
                                                    (rate0.SupplierCd == rate.SupplierCd) &&
                                                    (rate0.LotCount < rate.LotCount) )
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            } );
                if ( wkList.Count > 0 )
                {
                    // �q�b�g�����|���̒��O�܂łŁA�ŏI�s���擾
                    bfRate = wkList[wkList.Count - 1];
                }
            }
            // --- ADD m.suzuki 2011/02/16 ----------<<<<<

            // �|���}�X�^�̒[�������P�ʁA�[�������敪�͒艿�v�Z���̂ݎg�p����i0�ɂ���ƁA���z�����敪�ݒ肩��擾�j
            double unPrcFracProcUnit = ( unitPriceKind == UnitPriceKind.ListPrice ) ? rate.UnPrcFracProcUnit : 0;
            int unPrcFracProcDiv = ( unitPriceKind == UnitPriceKind.ListPrice ) ? rate.UnPrcFracProcDiv : 0;

            // ����ł̒[�������P�ʁA�[�������敪
            double taxFractionProcUnit;
            int taxFractionProcCd;

            double rateVal = 0;                 // �|��

            // ���i���̎擾
            GoodsPrice goodsPrice;
            this.GetPrice(unitPriceCalcParam.PriceApplyDate, goodsUnitData, out goodsPrice);

            if (goodsPrice == null) goodsPrice = new GoodsPrice();

            // �P����ނɂ�菈������i�P����ޖ��̗D�揇�ʂɏ]���Čv�Z�j
            // ���v�Z���@�͓���ł����A�d�l�ύX��ǉ����ꂽ�ꍇ���l�����ĒP����ޖ��ɕ����Ă����܂�
            switch (unitPriceKind)
            {
                #region ������
                case UnitPriceKind.SalesUnitPrice:
                    // �������ł̒[�������P�ʁA�[�������敪���擾
                    this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                    // ���i�w��
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;

                        CalclateUnitPrice(unitPriceCalcParam.TaxationDivCd,
                            //(double)row[RateAcs.PRICEFL],
                                          rate.PriceFl,
                                          unitPriceCalcParam.TaxRate,
                                          taxFractionProcUnit,
                                          taxFractionProcCd,
                            //(double)row[RateAcs.RATEVAL],
                                          rate.RateVal,
                                          out unitPriceTaxExc,
                                          out unitPriceTaxInc);
                        // �]�ŕ����u��ېŁv���́A�ō��P���ɐŔ����P�����Z�b�g
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            unitPriceTaxInc = unitPriceTaxExc;
                        }
                    }
                    // UP��
                    else if (rate.UpRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.UpRate;

                        // �|����UP�����Z�b�g
                        rateVal = rate.UpRate;

                        UnitPriceCalcRet salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, unitPriceCalcRetList, unitPriceCalcParam);

                        // �����ݒ肪�擾�ł��Ȃ��ꍇ�͌v�Z����
                        if (salesCostCalcRet == null)
                        {
                            List<UnitPriceCalcRet> salesCostCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref salesCostCalcRetList);

                            salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, salesCostCalcRetList, unitPriceCalcParam);

                            if (salesCostCalcRet != null)
                            {
                                // �����v�Z���ʂ��Z�b�g����
                                unitPriceCalcRetList.Add(salesCostCalcRet.Clone());
                            }
                            else
                            {
                                salesCostCalcRet = new UnitPriceCalcRet();
                            }
                        }

                        // �]�ŕ����u��ېŁv���́A�������i�͏�ɐŔ������i
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // ����i�Z�b�g
                            stdPrice = salesCostCalcRet.UnitPriceTaxExcFl;
                            // �v�Z�p�̊���i�Z�b�g
                            stdPriceWk = salesCostCalcRet.UnitPriceTaxExcFl;
                            // ��ېłƂ��Čv�Z
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // ����i�Z�b�g�i���ŕi�F�ō��ݒP���A�O�ť��ېŕi�F�Ŕ����P���j
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;

                            // �v�Z�p�̊���i�Z�b�g(���Ōv�Z�̏ꍇ�͐ō��P������Ɍv�Z)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                         fractionProcCode,
                                                         taxationCode,
                                                         stdPriceWk,
                                                         unitPriceCalcParam.TaxRate,
                                                         taxFractionProcUnit,
                                                         taxFractionProcCd,
                                                         rateVal,
                                                         ref unPrcFracProcUnit,
                                                         ref unPrcFracProcDiv,
                                                         out unitPriceTaxExc,
                                                         out unitPriceTaxInc);
                    }
                    // �e���m�ۗ�
                    else if (rate.GrsProfitSecureRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.GrsProfitSecureRate;

                        // �|���ɑe���m�ۗ����Z�b�g
                        rateVal = rate.GrsProfitSecureRate;

                        UnitPriceCalcRet salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, unitPriceCalcRetList, unitPriceCalcParam);

                        // �����ݒ肪�擾�ł��Ȃ��ꍇ�͌v�Z����
                        if (salesCostCalcRet == null)
                        {
                            List<UnitPriceCalcRet> salesCostCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.UnitCost, unitPriceCalcParam, goodsUnitData, ref salesCostCalcRetList);

                            salesCostCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.UnitCost, salesCostCalcRetList, unitPriceCalcParam);

                            if (salesCostCalcRet != null)
                            {
                                // �����v�Z���ʂ��Z�b�g����
                                unitPriceCalcRetList.Add(salesCostCalcRet.Clone());
                            }
                            else
                            {
                                salesCostCalcRet = new UnitPriceCalcRet();
                            }
                        }
                        // �]�ŕ����u��ېŁv���́A�������i�͏�ɐŔ������i
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // ����i�Z�b�g
                            stdPrice = salesCostCalcRet.UnitPriceTaxExcFl;
                            // �v�Z�p�̊���i�Z�b�g
                            stdPriceWk = salesCostCalcRet.UnitPriceTaxExcFl;

                            // ��ېłƂ��Čv�Z
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // ����i�Z�b�g�i���ŕi�F�ō��ݒP���A�O�ť��ېŕi�F�Ŕ����P���j
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;

                            // �v�Z�p�̊���i�Z�b�g(���Ōv�Z�̏ꍇ�͐ō��P������Ɍv�Z)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? salesCostCalcRet.UnitPriceTaxIncFl : salesCostCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByMarginRate(unitPriceKind,
                                                               fractionProcCode,
                                                               taxationCode,
                                                               stdPriceWk,
                                                               unitPriceCalcParam.TaxRate,
                                                               taxFractionProcUnit,
                                                               taxFractionProcCd,
                                                               rateVal,
                                                               ref unPrcFracProcUnit,
                                                               ref unPrcFracProcDiv,
                                                               out unitPriceTaxExc,
                                                               out unitPriceTaxInc);
                    }
                    // ������
                    else if (rate.RateVal != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.RateVal;

                        // �|���ɔ��������Z�b�g
                        rateVal = rate.RateVal;

                        UnitPriceCalcRet listPricaCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, unitPriceCalcRetList, unitPriceCalcParam);

                        // �艿�ݒ肪�擾�ł��Ȃ��ꍇ�͌v�Z����
                        if (listPricaCalcRet == null)
                        {
                            List<UnitPriceCalcRet> listPricaCalcRetList = new List<UnitPriceCalcRet>();
                            this.CalculateUnitPriceProc(UnitPriceKind.ListPrice, unitPriceCalcParam, goodsUnitData, ref listPricaCalcRetList);

                            listPricaCalcRet = SearchUnitPriceCalcRet(UnitPriceKind.ListPrice, listPricaCalcRetList, unitPriceCalcParam);

                            if (listPricaCalcRet != null)
                            {
                                // �����v�Z���ʂ��Z�b�g����
                                unitPriceCalcRetList.Add(listPricaCalcRet.Clone());
                            }
                            else
                            {
                                listPricaCalcRet = new UnitPriceCalcRet();
                            }
                        }
                        openPriceDiv = listPricaCalcRet.OpenPriceDiv;

                        // �]�ŕ����u��ېŁv���́A�������i�͏�ɐŔ������i
                        if (unitPriceCalcParam.ConsTaxLayMethod == 9)
                        {
                            // ����i�Z�b�g
                            stdPrice = listPricaCalcRet.UnitPriceTaxExcFl;
                            // �v�Z�p�̊���i�Z�b�g
                            stdPriceWk = listPricaCalcRet.UnitPriceTaxExcFl;

                            // ��ېłƂ��Čv�Z
                            taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                        }
                        else
                        {
                            // ����i�Z�b�g�i���ŕi�F�ō��ݒP���A�O�ť��ېŕi�F�Ŕ����P���j
                            stdPrice = ( unitPriceCalcParam.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc ) ? listPricaCalcRet.UnitPriceTaxIncFl : listPricaCalcRet.UnitPriceTaxExcFl;

                            // �v�Z�p�̊���i�Z�b�g(���Ōv�Z�̏ꍇ�͐ō��P������Ɍv�Z)
                            stdPriceWk = ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) ? listPricaCalcRet.UnitPriceTaxIncFl : listPricaCalcRet.UnitPriceTaxExcFl;
                        }

                        this.CalculateUnitPriceByRate(unitPriceKind,
                                                         fractionProcCode,
                                                         taxationCode,
                                                         stdPriceWk,
                                                         unitPriceCalcParam.TaxRate,
                                                         taxFractionProcUnit,
                                                         taxFractionProcCd,
                                                         rateVal,
                                                         ref unPrcFracProcUnit,
                                                         ref unPrcFracProcDiv,
                                                         out unitPriceTaxExc,
                                                         out unitPriceTaxInc);
                    }
                    break;
                #endregion

                #region ���艿
                case UnitPriceKind.ListPrice:

                    // �������ł̒[�������P�ʁA�[�������敪���擾
                    this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.SalesCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

                    // ���i�w��(���[�U�[�艿)
                    if (rate.PriceFl != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.Price;
                        openPriceDiv = goodsPrice.OpenPriceDiv;

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
                    // UP��
                    else if (rate.UpRate != 0)
                    {
                        unitPrcCalcDiv = UnitPrcCalcDiv.UpRate;

                        // �|����UP�����Z�b�g
                        rateVal = rate.UpRate;

                        // �I�[�v�����i�敪�A��P���̃Z�b�g
                        openPriceDiv = goodsPrice.OpenPriceDiv;
                        stdPrice = goodsPrice.ListPrice;

                        // �I�[�v�����i�ŁA���i���[���̏ꍇ�͎擾���s����(���̊|������������)
                        if (( openPriceDiv == 1 ) && ( stdPrice == 0 )) return false;

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
                                                      ref unPrcFracProcUnit,
                                                      ref unPrcFracProcDiv,
                                                      out unitPriceTaxExc,
                                                      out unitPriceTaxInc);

                    }
                    break;
                #endregion

                #region ������
                case UnitPriceKind.UnitCost:

                    // �d������ł̒[�������P�ʁA�[�������敪���擾
                    this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_Tax, unitPriceCalcParam.StockCnsTaxFrcProcCd, 0, out taxFractionProcUnit, out taxFractionProcCd);

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
                        if (( openPriceDiv == 1 ) && ( stdPrice == 0 )) return false;

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

            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();

            unitPriceCalcRet.UnitPriceKind = ( (int)unitPriceKind ).ToString();				// �P�����
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
            // --- ADD m.suzuki 2011/02/16 ---------->>>>>
            if ( bfRate != null )
            {
                // �O���R�[�h���L��ꍇ�� �u�O���R�[�h + 0.01�v
                unitPriceCalcRet.LotSt = bfRate.LotCount + 0.01;
            }
            else
            {
                // �O���R�[�h�������ꍇ�� 0 ����n�܂�
                unitPriceCalcRet.LotSt = 0;
            }
            unitPriceCalcRet.LotEd = rate.LotCount;
            // --- ADD m.suzuki 2011/02/16 ----------<<<<<
            unitPriceCalcRet.RateUpdateTimeSales = rate.UpdateDateTimeAdFormal; //ADD yangyi K2014/02/09 
            unitPriceCalcRet.RateUpdateTimeUnit = rate.UpdateDateTimeAdFormal; //ADD yangyi K2014/02/09 
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
        /// <param name="fracProcUnit">�P���[�������P��</param>
        /// <param name="fracProcCd">�P���[�������敪</param>
        /// <param name="unitPriceTaxExc">�Ŕ����P��</param>
        /// <param name="unitPriceTaxInc">�ō��ݒP��</param>
        private void CalculateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double stdPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double rate, ref  double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // �@�Ŕ����P�� = ��P������|���v�Z��������
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

                // �A�ō��ݒP�� = �Ŕ����P�� + �Ŕ����P���̏����
                unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                // �@�ō��ݒP�� = ��P������|���v�Z��������
                unitPriceTaxInc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

                // �A�Ŕ����P�� = �ō��ݒP�� - �ō��ݒP���̏����
                unitPriceTaxExc = (double)( (decimal)unitPriceTaxInc - (decimal)CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc) );
            }
            // ��ې�
            else
            {
                // �@�Ŕ����P�� = ��P������|���v�Z��������
                unitPriceTaxExc = CalclateUnitPriceByRate(unitPriceKind, fractionProcCode, stdPrice, rate, ref fracProcUnit, ref fracProcCd);

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
		/// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns></returns>
		private double CalclateUnitPriceByRate( UnitPriceKind unitPriceKind, int fractionProcCode, double stdPrice, double rate, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( rate == 0 ) || ( stdPrice == 0 )) return 0;

			double unitPrice = ( rate < 0 ) ? stdPrice * ( 100 + rate ) * 0.01 : stdPrice * rate * 0.01;

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

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
		/// �e�������g�p���ĒP�����v�Z���܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="taxationCode">�ېŋ敪</param>
		/// <param name="costPrice">����</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxFracProcUnit">����Œ[�������P��</param>
		/// <param name="taxFracProcCd">����Œ[�������敪</param>
		/// <param name="marginRate">�e����</param>
		/// <param name="fracProcUnit">�P���[�������P��</param>
		/// <param name="fracProcCd">�P���[�������敪</param>
		/// <param name="unitPriceTaxExc">�Ŕ����P��</param>
		/// <param name="unitPriceTaxInc">�ō��ݒP��</param>
		private void CalculateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int fractionProcCode, int taxationCode, double costPrice, double taxRate, double taxFracProcUnit, int taxFracProcCd, double marginRate, ref double fracProcUnit, ref int fracProcCd, out double unitPriceTaxExc, out double unitPriceTaxInc )
		{
			unitPriceTaxExc = 0;
			unitPriceTaxInc = 0;

			// �O�ł̏ꍇ
			if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
			{
				// �@�Ŕ����P�� = ��P������|���v�Z��������
				unitPriceTaxExc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// �A�ō��ݒP�� = �Ŕ����P�� + �Ŕ����P���̏����
				unitPriceTaxInc = unitPriceTaxExc + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxExc);
			}
			// ���ł̏ꍇ
			else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
			{
				// �@�ō��ݒP�� = ��P������|���v�Z��������
				unitPriceTaxInc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// �A�Ŕ����P�� = �ō��ݒP�� - �ō��ݒP���̏����
				unitPriceTaxExc = unitPriceTaxInc - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, unitPriceTaxInc);
			}
			// ��ې�
			else
			{
				// �@�Ŕ����P�� = ��P������|���v�Z��������
				unitPriceTaxExc = CalclateUnitPriceByMarginRate(unitPriceKind, fractionProcCode, costPrice, marginRate, ref fracProcUnit, ref fracProcCd);

				// �A�ō��ݒP�� = �Ŕ����P��
				unitPriceTaxInc = unitPriceTaxExc;
			}
		}

		/// <summary>
		/// �e�������g�p���ĒP�����v�Z���܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="costPrice">�����P��</param>
		/// <param name="marginRate">�e����</param>
		/// <param name="fracProcUnit">�[�������P��</param>
		/// <param name="fracProcCd">�[�������敪</param>
		/// <returns>�P��</returns>
		private double CalclateUnitPriceByMarginRate( UnitPriceKind unitPriceKind, int fractionProcCode, double costPrice, double marginRate, ref double fracProcUnit, ref int fracProcCd )
		{
			if (( marginRate == 0 ) || ( costPrice == 0 )) return 0;

			double unitPrice = costPrice / ( 1 - marginRate * 0.01 );

			SettingFracProcInfo(unitPriceKind, fractionProcCode, unitPrice, ref fracProcUnit, ref fracProcCd);

			FractionCalculate.FracCalcMoney(unitPrice, fracProcUnit, fracProcCd, out unitPrice);

			return unitPrice;
		}

		/// <summary>
		/// ���i�A���I�u�W�F�N�g���A�Ώۓ��̉��i�����擾���܂��B
		/// </summary>
		/// <param name="targetDay">�Ώۓ�</param>
		/// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
		/// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
		private void GetPrice( DateTime targetDay, GoodsUnitData goodsUnitData, out GoodsPrice goodsPrice )
		{
			goodsPrice = null;
			if (( goodsUnitData == null ) || ( goodsUnitData.GoodsPriceList == null )) return;

			List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

			DateTime dateWk = DateTime.MinValue;
			foreach (GoodsPrice goodsPriceWk in goodsPriceList)
			{
				if (( goodsPriceWk.PriceStartDate <= targetDay ) && ( goodsPriceWk.PriceStartDate > dateWk ))
				{
					dateWk = goodsPriceWk.PriceStartDate;
					goodsPrice = goodsPriceWk.Clone();
				}
			}
		}

        // -----ADD 2011/11/22----->>>>>
        /// <summary>
        /// ���i�A���I�u�W�F�N�g���A�Ώۓ��̉��i�����擾���܂��B(�����p)
        /// </summary>
        /// <param name="targetDay">�Ώۓ�</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
        private void GetPriceForUnitCost(DateTime targetDay, GoodsUnitData goodsUnitData, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((goodsUnitData == null) || (goodsUnitData.GoodsPriceList == null)) return;

            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            {
                if ((!string.IsNullOrEmpty(goodsPriceWk.EnterpriseCode)) && (goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk)) // ���[�U���D��
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }

            if (goodsPrice == null)
            {
                foreach (GoodsPrice goodsPriceWk in goodsPriceList)
                {
                    if ((string.IsNullOrEmpty(goodsPriceWk.EnterpriseCode)) && (goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk)) // �񋟕�
                    {
                        dateWk = goodsPriceWk.PriceStartDate;
                        goodsPrice = goodsPriceWk.Clone();
                    }
                }
            }
        }
        // -----ADD 2011/11/22-----<<<<<

        /// <summary>
        /// �|���D��Ǘ�����
        /// </summary>
        private void SearchRateProtyMng()
        {
            _rateProtyMngAllList = new List<RateProtyMng>();
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();

            bool nextdata;
            int totalcnt;
            string msg;
            ArrayList list;
            rateProtyMngAcs.Search(out list, out totalcnt, out nextdata, this._enterpriseCode, "", out msg);

            if (list != null)
            {
                _rateProtyMngAllList = new List<RateProtyMng>();
                _rateProtyMngAllList.AddRange((RateProtyMng[])list.ToArray(typeof(RateProtyMng)));

                // ���_�A�P����ށA�D�揇�ʂŃ\�[�g
                _rateProtyMngAllList.Sort(new DCKHN01060CF.RateProtyMngComparer());
            }
        }

        /// <summary>
        /// �|���D��Ǘ����̃��X�g���擾���܂��B
        /// </summary>
        /// <returns></returns>
        private List<RateProtyMng> GetRateProtyMngList(string sectionCode, UnitPriceKind unitPriceKind)
        {
            if (_rateProtyMngAllList == null) SearchRateProtyMng();

            if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

            if (( _lastSectionCode == sectionCode ) && ( unitPriceKind == _lastUnitPriceKind ))
            {
                // 2011/07/20 add wangf start
                if (this._ratePriorityDiv == 1)
                {
                    _lastRateProtyMngList.Sort(new DCKHN01060CF.RateProtyMngComparerUnitPriceKind());
                }
                // 2011/07/20 add wangf end
                return _lastRateProtyMngList;
            }


            // �Ώۋ��_���̗D��Ǘ����擾
            _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
                delegate(RateProtyMng rateProtyMng)
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
                    delegate(RateProtyMng rateProtyMng)
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
            // 2011/07/20 add wangf start
            if (this._ratePriorityDiv == 1)
            {
                _lastRateProtyMngList.Sort(new DCKHN01060CF.RateProtyMngComparerUnitPriceKind());
            }
            // 2011/07/20 add wangf end
            _lastSectionCode = sectionCode;
            _lastUnitPriceKind = unitPriceKind;
            return _lastRateProtyMngList;

        }

        /// <summary>
        /// �|���}�X�^���������܂��B
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>�|�������X�e�[�^�X</returns>
        private int SearchRate(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, out List<Rate> rateList)
        {
            RateAcs rateAcs = new RateAcs();

            rateList = new List<Rate>();
            List<RateProtyMng> rateProtyMngList = null;

            LogWrite("�|�� �����p�����[�^�쐬");

            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<Rate> kindRateList = new List<Rate>();
                foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
                {
                    rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, unitPriceKind);

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParam(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                rateList.AddRange(kindRateList);
            }

            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            int status = -1;
            if (rateList.Count > 0)
            {
                string msg;
                status = rateAcs.Search(out rateList, rateList, out msg);
            }

            LogWrite("�|���擾�I��");
            return status;
        }

        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �|���}�X�^���������܂��B
        /// �|���}�X�^�L���b�V���Ή��p
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���Z�o�p�����[�^���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>�|�������X�e�[�^�X</returns>
        private int SearchRateCache(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, out List<Rate> rateList)
        {
            RateAcs rateAcs = new RateAcs();
            // �|���}�X�^ ���[�N
            List<Rate> rateListWork = new List<Rate>();
            // ���������p�|���}�X�^
            List<Rate> rateListSearch = new List<Rate>();
            // �|���}�X�^��������
            List<Rate> rateListRtn = new List<Rate>();

            rateList = new List<Rate>();
            List<RateProtyMng> rateProtyMngList = null;

            LogWrite("�|�� �����p�����[�^�쐬");

            // �����p�����[�^�𐶐����A�|���}�X�^���[�N�ɃZ�b�g
            foreach (UnitPriceKind unitPriceKind in unitPriceKindList)
            {
                List<Rate> kindRateList = new List<Rate>();
                foreach (UnitPriceCalcParam unitPriceCalcParam in unitPriceCalcParamList)
                {
                    rateProtyMngList = this.GetRateProtyMngList(unitPriceCalcParam.SectionCode, unitPriceKind);

                    if (rateProtyMngList != null && rateProtyMngList.Count > 0)
                    {
                        this.MakeRateReadParamCache(unitPriceCalcParam, rateProtyMngList, ref kindRateList);
                    }
                }
                rateListWork.AddRange(kindRateList);
            }

            LogWrite("�|�� Search �p�����[�^:" + rateList.Count.ToString());

            // �����ς݊|���}�X�^�̏ꍇ�́A�Ԓl�p�|���}�X�^�ɃZ�b�g
            // �������ł���΁A���������p�|���}�X�^�ɃZ�b�g
            foreach (Rate rate in rateListWork)
            {
                // �����ς݊|���}�X�^����擾
                List<Rate> wk = _rateMstList.FindAll(
                                    delegate(Rate rate2)
                                    {
                                        return rateParaMuch(rate, rate2);
                                    });

                if (wk == null || wk.Count.Equals(0))
                {
                    // ���������p�|���}�X�^�ɒǉ�
                    rateListSearch.Add(rate);
                }
                else
                {
                    // �Ԓl�p�|���}�X�^�ɒǉ�
                    rateList.AddRange(wk);
                }
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // ���������p�|���}�X�^������Ό������s
            if (rateListSearch.Count > 0)
            {
                string msg;
                status = rateAcs.Search(out rateListRtn, rateListSearch, out msg);
                // �������ʂ�DB����擾�ł����ꍇ
                if (rateListRtn != null)
                {
                    // �Ԓl�p�|���}�X�^�ƌ����ς݊|���}�X�^�L���b�V��(DB�o�^�L��)�ɒǉ�
                    rateList.AddRange(rateListRtn);
                    _rateMstList.AddRange(rateListRtn);
                }

                if (rateListRtn == null || rateListRtn.Count.Equals(0))
                {
                    // �|���}�X�^�������ʂ�NULL�̏ꍇ
                    // �����ς݊|���}�X�^�L���b�V��(DB�o�^����)�Ɍ��������p�|���}�X�^��S���ǉ�
                    _rateMstListNotFound.AddRange(rateListSearch);
                }
                else
                {
                    // �|���}�X�^�������ʂ�Not NULL�̏ꍇ
                    // ���������p�|���}�X�^���ADB���擾�ł��Ȃ������|���}�X�^���A�����ς݊|���}�X�^�L���b�V��(DB�o�^����)�ɒǉ�
                    foreach (Rate rate in rateListSearch)
                    {
                        if (rateListRtn.Find(
                                            delegate(Rate rate2)
                                            {
                                                return rateParaMuch(rate, rate2);
                                            }) == null)
                        {
                            _rateMstListNotFound.Add(rate);
                        }
                    }
                }
            }

            if (rateList != null)
            {
                if (rateList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (rateList.Count.Equals(0))
                {
                    rateList = null;
                }
            }

            rateListWork = null;
            rateListSearch = null;
            rateListRtn = null;

            LogWrite("�|���擾�I��");
            return status;
        }
        
        /// <summary>
        /// �|���}�X�^������������v���邩�ۂ�
        /// </summary>
        /// <param name="rate">�Ώۊ|���}�X�^</param>
        /// <param name="rate2">�Ώۊ|���}�X�^�Q</param>
        /// <returns>true�F��v����  false�F��v���Ȃ� </returns>
        private bool rateParaMuch(Rate rate,Rate rate2)
        {
            if ((rate2.GoodsNo.Trim() == rate.GoodsNo.Trim()) &&
                (rate2.UnitPriceKind.Trim() == rate.UnitPriceKind.Trim()) &&
                (rate2.RateSettingDivide.Trim() == rate.RateSettingDivide.Trim()) &&
                (rate2.SectionCode.Trim() == rate.SectionCode.Trim()) &&
                (rate2.GoodsMakerCd == rate.GoodsMakerCd) &&
                (rate2.GoodsRateRank.Trim() == rate.GoodsRateRank.Trim()) &&
                (rate2.GoodsRateGrpCode == rate.GoodsRateGrpCode) &&
                (rate2.BLGroupCode == rate.BLGroupCode) &&
                (rate2.BLGoodsCode == rate.BLGoodsCode) &&
                (rate2.CustomerCode == rate.CustomerCode) &&
                (rate2.CustRateGrpCode == rate.CustRateGrpCode) &&
                (rate2.SupplierCd == rate.SupplierCd))
            {
                return true;
            }
            else
            {
                return false;
            };
        }
        
        /// <summary>
        /// �|���}�X�^�̓ǂݍ��݃p�����[�^�𐶐����܂��B
        /// �|���}�X�^�L���b�V���Ή��p
        /// </summary>
        /// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        private void MakeRateReadParamCache(UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, ref List<Rate> rateList)
        {
            foreach (RateProtyMng rateProtyMng in rateProtyMngList)
            {
                // �|���}�X�^��ǂݍ��ޏ������S�ē��͂���Ă���ꍇ�̂݌������X�g�ɒǉ�
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    Rate rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    // �����ς݂�DB���擾�ł��Ȃ������|���}�X�^�͌��������p�����[�^���珜�O����
                    if (_rateMstListNotFound.Find(
                                        delegate(Rate rate2)
                                        {
                                            return rateParaMuch(rate, rate2);
                                        }) != null)
                    {
                        continue;
                    }

                    if(rateList.Find(
                                        delegate(Rate rate2)
                                        {
                                            return rateParaMuch(rate, rate2);
                                        }) != null)
                    {
                        continue;
                    }

                    rate.EnterpriseCode = this._enterpriseCode;
                    rateList.Add(rate);
                }
            }
        }
        // ADD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �|���}�X�^�̓ǂݍ��݃p�����[�^�𐶐����܂��B
		/// </summary>
		/// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="rateProtyMngList">�|���D��Ǘ��}�X�^���X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        private void MakeRateReadParam(UnitPriceCalcParam unitPriceCalcParam, List<RateProtyMng> rateProtyMngList, ref List<Rate> rateList)
		{
            foreach (RateProtyMng rateProtyMng in rateProtyMngList)
            {
                // �|���}�X�^��ǂݍ��ޏ������S�ē��͂���Ă���ꍇ�̂݌������X�g�ɒǉ�
                if (CanCreateCheck(rateProtyMng.RateSettingDivide, unitPriceCalcParam))
                {
                    Rate rate = CreateRateFromUnitPriceCalcParam((UnitPriceKind)rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide, rateProtyMng.SectionCode, unitPriceCalcParam);

                    Rate findRate = rateList.Find(
                                        delegate(Rate rate2)
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

                    rate.EnterpriseCode = this._enterpriseCode;
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
		/// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
        /// <br>UpdateNote : 2010/06/02 ���M PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.4</br>
        /// <br>             �艿��|����ύX���Ă������A�������������Čv�Z����Ȃ��ɉ��C</br>
		private void SettingFracProcInfo( UnitPriceKind unitPriceKind, int fractionProcCode, double price, ref double fractionProcUnit, ref int fractionProcCd )
		{
            //if (fractionProcUnit == 0) DEL 2010/06/02
			//{
				switch (unitPriceKind)
				{
					//// ���㌴���P��
					//case UnitPriceKind.SalesUnitCost:
					//    {
					//        this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_CostUnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
					//        break;
					//    }
					// �d���P��
					case UnitPriceKind.UnitCost:
						{
							this.GetStockFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
							break;
						}
                    //>>>2010/12/02
                    //// �艿�A����P��
                    //case UnitPriceKind.ListPrice:
                    //case UnitPriceKind.SalesUnitPrice:
                    //{
                    //  this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                    //  break;
                    //  }
                    //}

                    // �艿
                    case UnitPriceKind.ListPrice:
                        {
                            break;
                        }

                    // ����P��
                    case UnitPriceKind.SalesUnitPrice:
                        {
                            this.GetSalesFractionProcInfo(DCKHN01060CF.ctFracProcMoneyDiv_UnitPrice, fractionProcCode, price, out fractionProcUnit, out fractionProcCd);
                            break;
                        }
                    //<<<2010/12/02
                }
			//}
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
		/// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
		/// </summary>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="price">�Ώۋ��z</param>
		/// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪</param>
		private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd )
		{
            fractionProcUnit = DCKHN01060CF.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = DCKHN01060CF.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoney> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoney stockProcMoney)
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
		#endregion

        // --- ADD huangt 2013/05/30 PM-TAB�Ή� ---------- >>>>>
        /// <summary>
        /// �P���v�Z����
        /// </summary>
        /// <param name="unitPriceKindList">�P����ރ��X�g</param>
        /// <param name="unitPriceCalcParamList">�P���v�Z�p�����[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        private void CalculateUnitPriceForTabletProc(List<UnitPriceKind> unitPriceKindList, List<UnitPriceCalcParam> unitPriceCalcParamList, List<GoodsUnitData> goodsUnitDataList, ref List<UnitPriceCalcRet> unitPriceCalcRetList, ref List<Rate> rateList)
        {
            LogWrite(string.Format("�P���Z�o �J�n {0}��:", unitPriceCalcParamList.Count));

            // �p�����[�^���X�g�A���i�A���f�[�^�I�u�W�F�N�g���X�g��������Ώ������Ȃ�
            if ((unitPriceCalcParamList == null) || (unitPriceCalcParamList.Count == 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
            {
                return;
            }

            LogWrite("�|���ǂݍ���");

            // �|���}�X�^�̓ǂݍ���
            int status = this.SearchRate(unitPriceKindList, unitPriceCalcParamList, out rateList);


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
                this.CalculateUnitCostPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);

            }

            LogWrite("�艿�v�Z");

            // �艿�v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.ListPrice))
            {
                this.CalculateListPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("�����v�Z");

            // �����v�Z����
            if (unitPriceKindList.Contains(UnitPriceKind.SalesUnitPrice))
            {
                this.CalculateSalesUnitPriceProc(unitPriceCalcParamList, goodsUnitDataList, rateList, ref unitPriceCalcRetList);
            }

            LogWrite("�P���Z�o �I��");
        }
        // --- ADD huangt 2013/05/30 PM-TAB�Ή� ---------- <<<<<

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

		/// <summary>
		/// �P����ށA�|���ݒ�敪�A�P���v�Z�p�����[�^�I�u�W�F�N�g���A�|���}�X�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="rateSettingDivide">�|���ݒ�敪</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="unitPriceCalcParam">�|���v�Z�p�����[�^</param>
		/// <returns></returns>
		private static Rate CreateRateFromUnitPriceCalcParam( UnitPriceKind unitPriceKind, string rateSettingDivide, string sectionCode, UnitPriceCalcParam unitPriceCalcParam )
		{
			Rate rate = new Rate();

			rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
			rate.RateSettingDivide = rateSettingDivide;
			rate.SectionCode = sectionCode;
			rate.RateMngGoodsCd = GetRateMngCustCd(rateSettingDivide);
			rate.RateMngCustCd = GetRateMngCustCd(rateSettingDivide);
			rate.GoodsNo = RateAcs.IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : "";
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : "";
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;

			return rate;
		}

		/// <summary>
		/// �|���}�X�^��ǂݍ��ޏ������ݒ肳��Ă��邩�`�F�b�N���܂��B
		/// </summary>
		/// <param name="rateSettingDivide"></param>
		/// <param name="unitPriceCalcParam"></param>
		/// <returns></returns>
        private static bool CanCreateCheck( string rateSettingDivide, UnitPriceCalcParam unitPriceCalcParam )
        {
            if ( ((RateAcs.IsGoodsNoSetting( rateSettingDivide ) && (string.IsNullOrEmpty( unitPriceCalcParam.GoodsNo.Trim() )))) ||
                ((RateAcs.IsMakerSetting( rateSettingDivide ) && (unitPriceCalcParam.GoodsMakerCd == 0))) ||
                ((RateAcs.IsGoodsRateRankSetting( rateSettingDivide ) && (string.IsNullOrEmpty( unitPriceCalcParam.GoodsRateRank.Trim() )))) ||
                ((RateAcs.IsGoodsRateGrpCodeSetting( rateSettingDivide ) && (unitPriceCalcParam.GoodsRateGrpCode == 0))) ||
                ((RateAcs.IsBLGroupCodeSetting( rateSettingDivide ) && (unitPriceCalcParam.BLGroupCode == 0))) ||
                ((RateAcs.IsBLGoodsSetting( rateSettingDivide ) && (unitPriceCalcParam.BLGoodsCode == 0))) ||
                ((RateAcs.IsCustomerSetting( rateSettingDivide ) && (unitPriceCalcParam.CustomerCode == 0))) ||
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL
                //( ( RateAcs.IsCustRateGrpSetting(rateSettingDivide) && ( unitPriceCalcParam.CustRateGrpCode == 0 ) ) ) ||
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
                ((RateAcs.IsCustRateGrpSetting( rateSettingDivide ) && (unitPriceCalcParam.CustRateGrpCode < 0))) ||
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD
                ((RateAcs.IsSupplierSetting( rateSettingDivide ) && (unitPriceCalcParam.SupplierCd == 0))) )
            {
                return false;
            }

            return true;
        }

		#endregion

		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="unitPriceKind">�P�����</param>
		/// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
		/// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
		/// <returns></returns>
		private static UnitPriceCalcRet SearchUnitPriceCalcRet( UnitPriceKind unitPriceKind, List<UnitPriceCalcRet> unitPriceCalcRetList, UnitPriceCalcParam unitPriceCalcParam )
		{
			UnitPriceCalcRet unitPriceCalcRet = null;

			foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
			{
				if (( unitPriceCalcRetWk.UnitPriceKind == ( (int)unitPriceKind ).ToString() ) &&
						( unitPriceCalcRetWk.GoodsNo == unitPriceCalcParam.GoodsNo ) &&
						( unitPriceCalcRetWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					unitPriceCalcRet = unitPriceCalcRetWk.Clone();
				}
			}

			return unitPriceCalcRet;
		}

        /// <summary>
        /// �|���f�[�^�e�[�u���t�B���^�[�����񐶐�
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="unitPriceKind">�P�����</param>
        /// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <returns></returns>
        private static Rate MakeRateFilter(string sectionCode, UnitPriceKind unitPriceKind, UnitPriceCalcParam unitPriceCalcParam, string rateSettingDivide)
        {
            Rate rate = new Rate();

            // �|���ݒ�敪�ɏ]���Đݒ�L���𔻒f���ăt�B���^�[�p�̊|���}�X�^�N���X�𐶐�
            rate.SectionCode = sectionCode;
            rate.UnitPriceKind = ( (int)unitPriceKind ).ToString();
            rate.RateSettingDivide = rateSettingDivide;
            rate.GoodsMakerCd = RateAcs.IsMakerSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsMakerCd : 0;
            rate.GoodsNo = RateAcs.IsGoodsNoSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsNo : string.Empty;
            rate.GoodsRateRank = RateAcs.IsGoodsRateRankSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateRank : string.Empty;
            rate.GoodsRateGrpCode = RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide) ? unitPriceCalcParam.GoodsRateGrpCode : 0;
            rate.BLGroupCode = RateAcs.IsBLGroupCodeSetting(rateSettingDivide) ? unitPriceCalcParam.BLGroupCode : 0;
            rate.BLGoodsCode = RateAcs.IsBLGoodsSetting(rateSettingDivide) ? unitPriceCalcParam.BLGoodsCode : 0;
            rate.CustomerCode = RateAcs.IsCustomerSetting(rateSettingDivide) ? unitPriceCalcParam.CustomerCode : 0;
            rate.CustRateGrpCode = RateAcs.IsCustRateGrpSetting(rateSettingDivide) ? unitPriceCalcParam.CustRateGrpCode : 0;
            rate.SupplierCd = RateAcs.IsSupplierSetting(rateSettingDivide) ? unitPriceCalcParam.SupplierCd : 0;
            rate.LotCount = unitPriceCalcParam.CountFl;

            return rate;
        }


		/// <summary>
		/// ���i�\����񌟍�����
		/// </summary>
		/// <param name="goodsUnitDataList">���i�\����񃊃X�g</param>
		/// <param name="unitPriceCalcParam">�P���Z�o�p�����[�^</param>
		/// <returns>���i�\�����I�u�W�F�N�g</returns>
		private GoodsUnitData SearchGoodsUnitData( List<GoodsUnitData> goodsUnitDataList, UnitPriceCalcParam unitPriceCalcParam )
		{
			GoodsUnitData retGoodsUnitData = null;

			foreach (GoodsUnitData goodsUnitDataWk in goodsUnitDataList)
			{
				if (( goodsUnitDataWk.GoodsNo == unitPriceCalcParam.GoodsNo ) && ( goodsUnitDataWk.GoodsMakerCd == unitPriceCalcParam.GoodsMakerCd ))
				{
					retGoodsUnitData = goodsUnitDataWk;
				}
			}

			return retGoodsUnitData;
		}

		#endregion

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg">���b�Z�[�W</param>
        public static void LogWrite(string pMsg)
        {
#if LOG
			System.IO.FileStream _fs;										// �t�@�C���X�g���[��
			System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new System.IO.FileStream("DCKHN01060C.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
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

	}

}