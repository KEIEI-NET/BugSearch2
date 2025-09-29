using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MstSearchCountWorkWork
    /// <summary>
    ///                      データ計数ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   データ計数ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/3/13</br>
    /// <br>Genarated Date   :   2009/05/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      : 2021/04/12 陳艶丹</br>
    /// <br>管理番号         : 11770021-00</br>
    /// <br>                 : PMKOBETSU-4136 得意先メモ情報の追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MstSearchCountWorkWork
    {
        /// <summary>拠点情報設定マスタ</summary>
        private Int32 _secInfoSetCount;

        /// <summary>部門マスタ</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private Int32 _subSectionCount;

        /// <summary>従業員マスタ</summary>
        private Int32 _employeeCount;

        /// <summary>従業員詳細マスタ</summary>
        private Int32 _employeeDtlCount;

        /// <summary>倉庫マスタ</summary>
        private Int32 _warehouseCount;

        /// <summary>得意先マスタ</summary>
        private Int32 _customerCount;

        /// <summary>得意先マスタ(変動情報)</summary>
        private Int32 _customerChangeCount;

        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        /// <summary>得意先マスタ(メモ情報)データ</summary>
        private Int32 _customerMemoCount;
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        /// <summary>得意先マスタ（伝票管理）</summary>
        private Int32 _custSlipMngCount;

        /// <summary>得意先マスタ（掛率グループ）</summary>
        private Int32 _custRateGroupCount;

        /// <summary>得意先マスタ(伝票番号)</summary>
        private Int32 _custSlipNoSetCount;

        /// <summary>仕入先マスタ</summary>
        private Int32 _supplierCount;

        /// <summary>メーカーマスタ（ユーザー登録分）</summary>
        private Int32 _makerUCount;

        /// <summary>BL商品コードマスタ（ユーザー登録分）</summary>
        private Int32 _bLGoodsCdUCount;

        /// <summary>商品マスタ（ユーザー登録分）</summary>
        private Int32 _goodsUCount;

        /// <summary>価格マスタ（ユーザー登録）</summary>
        private Int32 _goodsPriceCount;

        /// <summary>商品管理情報マスタ</summary>
        private Int32 _goodsMngCount;

        /// <summary>離島価格マスタ</summary>
        private Int32 _isolIslandPrcCount;

        /// <summary>在庫マスタ</summary>
        private Int32 _stockCount;

        /// <summary>ユーザーガイドマスタ(販売エリア区分）</summary>
        private Int32 _userGdAreaDivUCount;

        /// <summary>ユーザーガイドマスタ（業務区分）</summary>
        private Int32 _userGdBusDivUCount;

        /// <summary>ユーザーガイドマスタ（業種）</summary>
        private Int32 _userGdCateUCount;

        /// <summary>ユーザーガイドマスタ（職種）</summary>
        private Int32 _userGdBusUCount;

        /// <summary>ユーザーガイドマスタ（商品区分）</summary>
        private Int32 _userGdGoodsDivUCount;

        /// <summary>ユーザーガイドマスタ（得意先掛率グループ）</summary>
        private Int32 _userGdCusGrouPUCount;

        /// <summary>ユーザーガイドマスタ（銀行）</summary>
        private Int32 _userGdBankUCount;

        /// <summary>ユーザーガイドマスタ（価格区分）</summary>
        private Int32 _userGdPriDivUCount;

        /// <summary>ユーザーガイドマスタ（納品区分）</summary>
        private Int32 _userGdDeliDivUCount;

        /// <summary>ユーザーガイドマスタ（商品大分類）</summary>
        private Int32 _userGdGoodsBigUCount;

        /// <summary>ユーザーガイドマスタ（販売区分）</summary>
        private Int32 _userGdBuyDivUCount;

        /// <summary>ユーザーガイドマスタ（在庫管理区分１）</summary>
        private Int32 _userGdStockDivOUCount;

        /// <summary>ユーザーガイドマスタ（在庫管理区分２）</summary>
        private Int32 _userGdStockDivTUCount;

        /// <summary>ユーザーガイドマスタ（返品理由）</summary>
        private Int32 _userGdReturnReaUCount;

        /// <summary>掛率優先管理マスタ</summary>
        private Int32 _rateProtyMngCount;

        /// <summary>掛率マスタ</summary>
        private Int32 _rateCount;

        /// <summary>商品セットマスタ</summary>
        private Int32 _goodsSetCount;

        /// <summary>部品代替マスタ（ユーザー登録分）</summary>
        private Int32 _partsSubstUCount;

        /// <summary>従業員別売上目標設定マスタ</summary>
        private Int32 _empSalesTargetCount;

        /// <summary>得意先別売上目標設定マスタ</summary>
        private Int32 _custSalesTargetCount;

        /// <summary>商品別売上目標設定マスタ</summary>
        private Int32 _gcdSalesTargetCount;

        /// <summary>商品中分類マスタ（ユーザー登録分）</summary>
        private Int32 _goodsMGroupUCount;

        /// <summary>BLグループマスタ（ユーザー登録分）</summary>
        private Int32 _bLGroupUCount;

        /// <summary>結合マスタ（ユーザー登録分）</summary>
        private Int32 _joinPartsUCount;

        /// <summary>TBO検索マスタ（ユーザー登録）</summary>
        private Int32 _tBOSearchUCount;

        /// <summary>部位コードマスタ（ユーザー登録）</summary>
        private Int32 _partsPosCodeUCount;

        /// <summary>BLコードガイドマスタ</summary>
        private Int32 _bLCodeGuideCount;

        /// <summary>車種名称マスタ</summary>
        private Int32 _modelNameUCount;

        /// <summary>エラー区分</summary>
        private Int32 _errorKubun;


        /// public propaty name  :  SecInfoSetCount
        /// <summary>拠点情報設定マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点情報設定マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecInfoSetCount
        {
            get { return _secInfoSetCount; }
            set { _secInfoSetCount = value; }
        }

        /// public propaty name  :  SubSectionCount
        /// <summary>部門マスタプロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCount
        {
            get { return _subSectionCount; }
            set { _subSectionCount = value; }
        }

        /// public propaty name  :  EmployeeCount
        /// <summary>従業員マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeCount
        {
            get { return _employeeCount; }
            set { _employeeCount = value; }
        }

        /// public propaty name  :  EmployeeDtlCount
        /// <summary>従業員詳細マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員詳細マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployeeDtlCount
        {
            get { return _employeeDtlCount; }
            set { _employeeDtlCount = value; }
        }

        /// public propaty name  :  WarehouseCount
        /// <summary>倉庫マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseCount
        {
            get { return _warehouseCount; }
            set { _warehouseCount = value; }
        }

        /// public propaty name  :  CustomerCount
        /// <summary>得意先マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCount
        {
            get { return _customerCount; }
            set { _customerCount = value; }
        }

        /// public propaty name  :  CustomerChangeCount
        /// <summary>得意先マスタ(変動情報)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタ(変動情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerChangeCount
        {
            get { return _customerChangeCount; }
            set { _customerChangeCount = value; }
        }

        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        /// public propaty name  :  CustomerMemoCount
        /// <summary>得意先マスタ(メモ情報)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタ(メモ情報)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerMemoCount
        {
            get { return _customerMemoCount; }
            set { _customerMemoCount = value; }
        }
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        /// public propaty name  :  CustSlipMngCount
        /// <summary>得意先マスタ（伝票管理）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタ（伝票管理）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipMngCount
        {
            get { return _custSlipMngCount; }
            set { _custSlipMngCount = value; }
        }

        /// public propaty name  :  CustRateGroupCount
        /// <summary>得意先マスタ（掛率グループ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタ（掛率グループ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGroupCount
        {
            get { return _custRateGroupCount; }
            set { _custRateGroupCount = value; }
        }

        /// public propaty name  :  CustSlipNoSetCount
        /// <summary>得意先マスタ(伝票番号)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先マスタ(伝票番号)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNoSetCount
        {
            get { return _custSlipNoSetCount; }
            set { _custSlipNoSetCount = value; }
        }

        /// public propaty name  :  SupplierCount
        /// <summary>仕入先マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCount
        {
            get { return _supplierCount; }
            set { _supplierCount = value; }
        }

        /// public propaty name  :  MakerUCount
        /// <summary>メーカーマスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーマスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerUCount
        {
            get { return _makerUCount; }
            set { _makerUCount = value; }
        }

        /// public propaty name  :  BLGoodsCdUCount
        /// <summary>BL商品コードマスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードマスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdUCount
        {
            get { return _bLGoodsCdUCount; }
            set { _bLGoodsCdUCount = value; }
        }

        /// public propaty name  :  GoodsUCount
        /// <summary>商品マスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsUCount
        {
            get { return _goodsUCount; }
            set { _goodsUCount = value; }
        }

        /// public propaty name  :  GoodsPriceCount
        /// <summary>価格マスタ（ユーザー登録）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格マスタ（ユーザー登録）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsPriceCount
        {
            get { return _goodsPriceCount; }
            set { _goodsPriceCount = value; }
        }

        /// public propaty name  :  GoodsMngCount
        /// <summary>商品管理情報マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品管理情報マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMngCount
        {
            get { return _goodsMngCount; }
            set { _goodsMngCount = value; }
        }

        /// public propaty name  :  IsolIslandPrcCount
        /// <summary>離島価格マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   離島価格マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IsolIslandPrcCount
        {
            get { return _isolIslandPrcCount; }
            set { _isolIslandPrcCount = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>在庫マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  UserGdAreaDivUCount
        /// <summary>ユーザーガイドマスタ(販売エリア区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ(販売エリア区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdAreaDivUCount
        {
            get { return _userGdAreaDivUCount; }
            set { _userGdAreaDivUCount = value; }
        }

        /// public propaty name  :  UserGdBusDivUCount
        /// <summary>ユーザーガイドマスタ（業務区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（業務区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdBusDivUCount
        {
            get { return _userGdBusDivUCount; }
            set { _userGdBusDivUCount = value; }
        }

        /// public propaty name  :  UserGdCateUCount
        /// <summary>ユーザーガイドマスタ（業種）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（業種）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdCateUCount
        {
            get { return _userGdCateUCount; }
            set { _userGdCateUCount = value; }
        }

        /// public propaty name  :  UserGdBusUCount
        /// <summary>ユーザーガイドマスタ（職種）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（職種）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdBusUCount
        {
            get { return _userGdBusUCount; }
            set { _userGdBusUCount = value; }
        }

        /// public propaty name  :  UserGdGoodsDivUCount
        /// <summary>ユーザーガイドマスタ（商品区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（商品区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdGoodsDivUCount
        {
            get { return _userGdGoodsDivUCount; }
            set { _userGdGoodsDivUCount = value; }
        }

        /// public propaty name  :  UserGdCusGrouPUCount
        /// <summary>ユーザーガイドマスタ（得意先掛率グループ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（得意先掛率グループ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdCusGrouPUCount
        {
            get { return _userGdCusGrouPUCount; }
            set { _userGdCusGrouPUCount = value; }
        }

        /// public propaty name  :  UserGdBankUCount
        /// <summary>ユーザーガイドマスタ（銀行）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（銀行）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdBankUCount
        {
            get { return _userGdBankUCount; }
            set { _userGdBankUCount = value; }
        }

        /// public propaty name  :  UserGdPriDivUCount
        /// <summary>ユーザーガイドマスタ（価格区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（価格区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdPriDivUCount
        {
            get { return _userGdPriDivUCount; }
            set { _userGdPriDivUCount = value; }
        }

        /// public propaty name  :  UserGdDeliDivUCount
        /// <summary>ユーザーガイドマスタ（納品区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（納品区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdDeliDivUCount
        {
            get { return _userGdDeliDivUCount; }
            set { _userGdDeliDivUCount = value; }
        }

        /// public propaty name  :  UserGdGoodsBigUCount
        /// <summary>ユーザーガイドマスタ（商品大分類）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（商品大分類）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdGoodsBigUCount
        {
            get { return _userGdGoodsBigUCount; }
            set { _userGdGoodsBigUCount = value; }
        }

        /// public propaty name  :  UserGdBuyDivUCount
        /// <summary>ユーザーガイドマスタ（販売区分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（販売区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdBuyDivUCount
        {
            get { return _userGdBuyDivUCount; }
            set { _userGdBuyDivUCount = value; }
        }

        /// public propaty name  :  UserGdStockDivOUCount
        /// <summary>ユーザーガイドマスタ（在庫管理区分１）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（在庫管理区分１）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdStockDivOUCount
        {
            get { return _userGdStockDivOUCount; }
            set { _userGdStockDivOUCount = value; }
        }

        /// public propaty name  :  UserGdStockDivTUCount
        /// <summary>ユーザーガイドマスタ（在庫管理区分２）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（在庫管理区分２）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdStockDivTUCount
        {
            get { return _userGdStockDivTUCount; }
            set { _userGdStockDivTUCount = value; }
        }

        /// public propaty name  :  UserGdReturnReaUCount
        /// <summary>ユーザーガイドマスタ（返品理由）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイドマスタ（返品理由）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGdReturnReaUCount
        {
            get { return _userGdReturnReaUCount; }
            set { _userGdReturnReaUCount = value; }
        }

        /// public propaty name  :  RateProtyMngCount
        /// <summary>掛率優先管理マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率優先管理マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateProtyMngCount
        {
            get { return _rateProtyMngCount; }
            set { _rateProtyMngCount = value; }
        }

        /// public propaty name  :  RateCount
        /// <summary>掛率マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateCount
        {
            get { return _rateCount; }
            set { _rateCount = value; }
        }

        /// public propaty name  :  GoodsSetCount
        /// <summary>商品セットマスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品セットマスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsSetCount
        {
            get { return _goodsSetCount; }
            set { _goodsSetCount = value; }
        }

        /// public propaty name  :  PartsSubstUCount
        /// <summary>部品代替マスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品代替マスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsSubstUCount
        {
            get { return _partsSubstUCount; }
            set { _partsSubstUCount = value; }
        }

        /// public propaty name  :  EmpSalesTargetCount
        /// <summary>従業員別売上目標設定マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員別売上目標設定マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmpSalesTargetCount
        {
            get { return _empSalesTargetCount; }
            set { _empSalesTargetCount = value; }
        }

        /// public propaty name  :  CustSalesTargetCount
        /// <summary>得意先別売上目標設定マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先別売上目標設定マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSalesTargetCount
        {
            get { return _custSalesTargetCount; }
            set { _custSalesTargetCount = value; }
        }

        /// public propaty name  :  GcdSalesTargetCount
        /// <summary>商品別売上目標設定マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品別売上目標設定マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GcdSalesTargetCount
        {
            get { return _gcdSalesTargetCount; }
            set { _gcdSalesTargetCount = value; }
        }

        /// public propaty name  :  GoodsMGroupUCount
        /// <summary>商品中分類マスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類マスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupUCount
        {
            get { return _goodsMGroupUCount; }
            set { _goodsMGroupUCount = value; }
        }

        /// public propaty name  :  BLGroupUCount
        /// <summary>BLグループマスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループマスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupUCount
        {
            get { return _bLGroupUCount; }
            set { _bLGroupUCount = value; }
        }

        /// public propaty name  :  JoinPartsUCount
        /// <summary>結合マスタ（ユーザー登録分）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合マスタ（ユーザー登録分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinPartsUCount
        {
            get { return _joinPartsUCount; }
            set { _joinPartsUCount = value; }
        }

        /// public propaty name  :  TBOSearchUCount
        /// <summary>TBO検索マスタ（ユーザー登録）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TBO検索マスタ（ユーザー登録）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TBOSearchUCount
        {
            get { return _tBOSearchUCount; }
            set { _tBOSearchUCount = value; }
        }

        /// public propaty name  :  PartsPosCodeUCount
        /// <summary>部位コードマスタ（ユーザー登録）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位コードマスタ（ユーザー登録）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPosCodeUCount
        {
            get { return _partsPosCodeUCount; }
            set { _partsPosCodeUCount = value; }
        }

        /// public propaty name  :  BLCodeGuideCount
        /// <summary>BLコードガイドマスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードガイドマスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeGuideCount
        {
            get { return _bLCodeGuideCount; }
            set { _bLCodeGuideCount = value; }
        }

        /// public propaty name  :  ModelNameUCount
        /// <summary>車種名称マスタプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名称マスタプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelNameUCount
        {
            get { return _modelNameUCount; }
            set { _modelNameUCount = value; }
        }

        /// public propaty name  :  ErrorKubun
        /// <summary>エラー区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorKubun
        {
            get { return _errorKubun; }
            set { _errorKubun = value; }
        }


        /// <summary>
        /// データ計数ワークワークコンストラクタ
        /// </summary>
        /// <returns>MstSearchCountWorkWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MstSearchCountWorkWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MstSearchCountWorkWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MstSearchCountWorkWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MstSearchCountWorkWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MstSearchCountWorkWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MstSearchCountWorkWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MstSearchCountWorkWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MstSearchCountWorkWork || graph is ArrayList || graph is MstSearchCountWorkWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MstSearchCountWorkWork).FullName));

            if (graph != null && graph is MstSearchCountWorkWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MstSearchCountWorkWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MstSearchCountWorkWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MstSearchCountWorkWork[])graph).Length;
            }
            else if (graph is MstSearchCountWorkWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点情報設定マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //SecInfoSetCount
            //部門マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCount
            //従業員マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeCount
            //従業員詳細マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployeeDtlCount
            //倉庫マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseCount
            //得意先マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCount
            //得意先マスタ(変動情報)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerChangeCount
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            //得意先マスタ(メモ情報)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerMemoCount
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            //得意先マスタ（伝票管理）
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipMngCount
            //得意先マスタ（掛率グループ）
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGroupCount
            //得意先マスタ(伝票番号)
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNoSetCount
            //仕入先マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCount
            //メーカーマスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerUCount
            //BL商品コードマスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdUCount
            //商品マスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsUCount
            //価格マスタ（ユーザー登録）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPriceCount
            //商品管理情報マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMngCount
            //離島価格マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //IsolIslandPrcCount
            //在庫マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCount
            //ユーザーガイドマスタ(販売エリア区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdAreaDivUCount
            //ユーザーガイドマスタ（業務区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBusDivUCount
            //ユーザーガイドマスタ（業種）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdCateUCount
            //ユーザーガイドマスタ（職種）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBusUCount
            //ユーザーガイドマスタ（商品区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdGoodsDivUCount
            //ユーザーガイドマスタ（得意先掛率グループ）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdCusGrouPUCount
            //ユーザーガイドマスタ（銀行）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBankUCount
            //ユーザーガイドマスタ（価格区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdPriDivUCount
            //ユーザーガイドマスタ（納品区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdDeliDivUCount
            //ユーザーガイドマスタ（商品大分類）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdGoodsBigUCount
            //ユーザーガイドマスタ（販売区分）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdBuyDivUCount
            //ユーザーガイドマスタ（在庫管理区分１）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdStockDivOUCount
            //ユーザーガイドマスタ（在庫管理区分２）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdStockDivTUCount
            //ユーザーガイドマスタ（返品理由）
            serInfo.MemberInfo.Add(typeof(Int32)); //UserGdReturnReaUCount
            //掛率優先管理マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //RateProtyMngCount
            //掛率マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //RateCount
            //商品セットマスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSetCount
            //部品代替マスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSubstUCount
            //従業員別売上目標設定マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //EmpSalesTargetCount
            //得意先別売上目標設定マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSalesTargetCount
            //商品別売上目標設定マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //GcdSalesTargetCount
            //商品中分類マスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroupUCount
            //BLグループマスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupUCount
            //結合マスタ（ユーザー登録分）
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinPartsUCount
            //TBO検索マスタ（ユーザー登録）
            serInfo.MemberInfo.Add(typeof(Int32)); //TBOSearchUCount
            //部位コードマスタ（ユーザー登録）
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPosCodeUCount
            //BLコードガイドマスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCodeGuideCount
            //車種名称マスタ
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelNameUCount
            //エラー区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorKubun


            serInfo.Serialize(writer, serInfo);
            if (graph is MstSearchCountWorkWork)
            {
                MstSearchCountWorkWork temp = (MstSearchCountWorkWork)graph;

                SetMstSearchCountWorkWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MstSearchCountWorkWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MstSearchCountWorkWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MstSearchCountWorkWork temp in lst)
                {
                    SetMstSearchCountWorkWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MstSearchCountWorkWorkメンバ数(publicプロパティ数)
        /// </summary>
        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        //private const int currentMemberCount = 47;
        private const int currentMemberCount = 48;
        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<

        /// <summary>
        ///  MstSearchCountWorkWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MstSearchCountWorkWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMstSearchCountWorkWork(System.IO.BinaryWriter writer, MstSearchCountWorkWork temp)
        {
            //拠点情報設定マスタ
            writer.Write(temp.SecInfoSetCount);
            //部門マスタ
            writer.Write(temp.SubSectionCount);
            //従業員マスタ
            writer.Write(temp.EmployeeCount);
            //従業員詳細マスタ
            writer.Write(temp.EmployeeDtlCount);
            //倉庫マスタ
            writer.Write(temp.WarehouseCount);
            //得意先マスタ
            writer.Write(temp.CustomerCount);
            //得意先マスタ(変動情報)
            writer.Write(temp.CustomerChangeCount);
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            //得意先マスタ(メモ情報)
            writer.Write(temp.CustomerMemoCount);
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            //得意先マスタ（伝票管理）
            writer.Write(temp.CustSlipMngCount);
            //得意先マスタ（掛率グループ）
            writer.Write(temp.CustRateGroupCount);
            //得意先マスタ(伝票番号)
            writer.Write(temp.CustSlipNoSetCount);
            //仕入先マスタ
            writer.Write(temp.SupplierCount);
            //メーカーマスタ（ユーザー登録分）
            writer.Write(temp.MakerUCount);
            //BL商品コードマスタ（ユーザー登録分）
            writer.Write(temp.BLGoodsCdUCount);
            //商品マスタ（ユーザー登録分）
            writer.Write(temp.GoodsUCount);
            //価格マスタ（ユーザー登録）
            writer.Write(temp.GoodsPriceCount);
            //商品管理情報マスタ
            writer.Write(temp.GoodsMngCount);
            //離島価格マスタ
            writer.Write(temp.IsolIslandPrcCount);
            //在庫マスタ
            writer.Write(temp.StockCount);
            //ユーザーガイドマスタ(販売エリア区分）
            writer.Write(temp.UserGdAreaDivUCount);
            //ユーザーガイドマスタ（業務区分）
            writer.Write(temp.UserGdBusDivUCount);
            //ユーザーガイドマスタ（業種）
            writer.Write(temp.UserGdCateUCount);
            //ユーザーガイドマスタ（職種）
            writer.Write(temp.UserGdBusUCount);
            //ユーザーガイドマスタ（商品区分）
            writer.Write(temp.UserGdGoodsDivUCount);
            //ユーザーガイドマスタ（得意先掛率グループ）
            writer.Write(temp.UserGdCusGrouPUCount);
            //ユーザーガイドマスタ（銀行）
            writer.Write(temp.UserGdBankUCount);
            //ユーザーガイドマスタ（価格区分）
            writer.Write(temp.UserGdPriDivUCount);
            //ユーザーガイドマスタ（納品区分）
            writer.Write(temp.UserGdDeliDivUCount);
            //ユーザーガイドマスタ（商品大分類）
            writer.Write(temp.UserGdGoodsBigUCount);
            //ユーザーガイドマスタ（販売区分）
            writer.Write(temp.UserGdBuyDivUCount);
            //ユーザーガイドマスタ（在庫管理区分１）
            writer.Write(temp.UserGdStockDivOUCount);
            //ユーザーガイドマスタ（在庫管理区分２）
            writer.Write(temp.UserGdStockDivTUCount);
            //ユーザーガイドマスタ（返品理由）
            writer.Write(temp.UserGdReturnReaUCount);
            //掛率優先管理マスタ
            writer.Write(temp.RateProtyMngCount);
            //掛率マスタ
            writer.Write(temp.RateCount);
            //商品セットマスタ
            writer.Write(temp.GoodsSetCount);
            //部品代替マスタ（ユーザー登録分）
            writer.Write(temp.PartsSubstUCount);
            //従業員別売上目標設定マスタ
            writer.Write(temp.EmpSalesTargetCount);
            //得意先別売上目標設定マスタ
            writer.Write(temp.CustSalesTargetCount);
            //商品別売上目標設定マスタ
            writer.Write(temp.GcdSalesTargetCount);
            //商品中分類マスタ（ユーザー登録分）
            writer.Write(temp.GoodsMGroupUCount);
            //BLグループマスタ（ユーザー登録分）
            writer.Write(temp.BLGroupUCount);
            //結合マスタ（ユーザー登録分）
            writer.Write(temp.JoinPartsUCount);
            //TBO検索マスタ（ユーザー登録）
            writer.Write(temp.TBOSearchUCount);
            //部位コードマスタ（ユーザー登録）
            writer.Write(temp.PartsPosCodeUCount);
            //BLコードガイドマスタ
            writer.Write(temp.BLCodeGuideCount);
            //車種名称マスタ
            writer.Write(temp.ModelNameUCount);
            //エラー区分
            writer.Write(temp.ErrorKubun);

        }

        /// <summary>
        ///  MstSearchCountWorkWorkインスタンス取得
        /// </summary>
        /// <returns>MstSearchCountWorkWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MstSearchCountWorkWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MstSearchCountWorkWork GetMstSearchCountWorkWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MstSearchCountWorkWork temp = new MstSearchCountWorkWork();

            //拠点情報設定マスタ
            temp.SecInfoSetCount = reader.ReadInt32();
            //部門マスタ
            temp.SubSectionCount = reader.ReadInt32();
            //従業員マスタ
            temp.EmployeeCount = reader.ReadInt32();
            //従業員詳細マスタ
            temp.EmployeeDtlCount = reader.ReadInt32();
            //倉庫マスタ
            temp.WarehouseCount = reader.ReadInt32();
            //得意先マスタ
            temp.CustomerCount = reader.ReadInt32();
            //得意先マスタ(変動情報)
            temp.CustomerChangeCount = reader.ReadInt32();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            //得意先マスタ(メモ情報)
            temp.CustomerMemoCount = reader.ReadInt32();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            //得意先マスタ（伝票管理）
            temp.CustSlipMngCount = reader.ReadInt32();
            //得意先マスタ（掛率グループ）
            temp.CustRateGroupCount = reader.ReadInt32();
            //得意先マスタ(伝票番号)
            temp.CustSlipNoSetCount = reader.ReadInt32();
            //仕入先マスタ
            temp.SupplierCount = reader.ReadInt32();
            //メーカーマスタ（ユーザー登録分）
            temp.MakerUCount = reader.ReadInt32();
            //BL商品コードマスタ（ユーザー登録分）
            temp.BLGoodsCdUCount = reader.ReadInt32();
            //商品マスタ（ユーザー登録分）
            temp.GoodsUCount = reader.ReadInt32();
            //価格マスタ（ユーザー登録）
            temp.GoodsPriceCount = reader.ReadInt32();
            //商品管理情報マスタ
            temp.GoodsMngCount = reader.ReadInt32();
            //離島価格マスタ
            temp.IsolIslandPrcCount = reader.ReadInt32();
            //在庫マスタ
            temp.StockCount = reader.ReadInt32();
            //ユーザーガイドマスタ(販売エリア区分）
            temp.UserGdAreaDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（業務区分）
            temp.UserGdBusDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（業種）
            temp.UserGdCateUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（職種）
            temp.UserGdBusUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（商品区分）
            temp.UserGdGoodsDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（得意先掛率グループ）
            temp.UserGdCusGrouPUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（銀行）
            temp.UserGdBankUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（価格区分）
            temp.UserGdPriDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（納品区分）
            temp.UserGdDeliDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（商品大分類）
            temp.UserGdGoodsBigUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（販売区分）
            temp.UserGdBuyDivUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（在庫管理区分１）
            temp.UserGdStockDivOUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（在庫管理区分２）
            temp.UserGdStockDivTUCount = reader.ReadInt32();
            //ユーザーガイドマスタ（返品理由）
            temp.UserGdReturnReaUCount = reader.ReadInt32();
            //掛率優先管理マスタ
            temp.RateProtyMngCount = reader.ReadInt32();
            //掛率マスタ
            temp.RateCount = reader.ReadInt32();
            //商品セットマスタ
            temp.GoodsSetCount = reader.ReadInt32();
            //部品代替マスタ（ユーザー登録分）
            temp.PartsSubstUCount = reader.ReadInt32();
            //従業員別売上目標設定マスタ
            temp.EmpSalesTargetCount = reader.ReadInt32();
            //得意先別売上目標設定マスタ
            temp.CustSalesTargetCount = reader.ReadInt32();
            //商品別売上目標設定マスタ
            temp.GcdSalesTargetCount = reader.ReadInt32();
            //商品中分類マスタ（ユーザー登録分）
            temp.GoodsMGroupUCount = reader.ReadInt32();
            //BLグループマスタ（ユーザー登録分）
            temp.BLGroupUCount = reader.ReadInt32();
            //結合マスタ（ユーザー登録分）
            temp.JoinPartsUCount = reader.ReadInt32();
            //TBO検索マスタ（ユーザー登録）
            temp.TBOSearchUCount = reader.ReadInt32();
            //部位コードマスタ（ユーザー登録）
            temp.PartsPosCodeUCount = reader.ReadInt32();
            //BLコードガイドマスタ
            temp.BLCodeGuideCount = reader.ReadInt32();
            //車種名称マスタ
            temp.ModelNameUCount = reader.ReadInt32();
            //エラー区分
            temp.ErrorKubun = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>MstSearchCountWorkWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MstSearchCountWorkWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MstSearchCountWorkWork temp = GetMstSearchCountWorkWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (MstSearchCountWorkWork[])lst.ToArray(typeof(MstSearchCountWorkWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
