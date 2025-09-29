//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 仕入売上実績表抽出条件データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note             :   仕入売上実績表抽出条件データクラスのインスタンスの作成を行う。</br>
    /// <br>Programmer       :   汪千来</br>
    /// <br>Date             :   2009.05.13</br>
    /// </remarks>
    public class StockSalesResultInfoMainCndtn
    {

        #region ■ Public Const
        /// <summary>共通 日付フォーマット yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>共通 日付フォーマット yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        #endregion

        #region ■ Private Member
        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>選択計上拠点コード</summary>
        private string[] _collectAddupSecCodeList;


        /// <summary>入力日(開始)</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _stInputDay;

        /// <summary>入力日(終了)</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _edInputDay;

        /// <summary>仕入日(開始)</summary>
        private Int32 _stStockDate;

        /// <summary>仕入日(終了)</summary>
        private Int32 _edStockDate;

        /// <summary>改頁</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private Int32 _newPageType;

        /// <summary>改頁名称</summary>
        /// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
        private string _newPageTypeName;

        /// <summary>出力指定</summary>
        /// <remarks>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</remarks>
        private Int32 _wayToOrderType;

        /// <summary>出力指定名称</summary>
        /// <remarks>出力指定名称</remarks>
        private string _wayToOrderTypeName;

        /// <summary>在庫取寄指定</summary>
        private Int32 _stockOrderDivCdType;

        /// <summary>在庫取寄指定名称</summary>
        private string _stockOrderDivCdTypeName;

        /// <summary>売上伝票指定</summary>
        private Int32 _salesType;

        /// <summary>売上伝票指定名称</summary>
        private string _salesTypeName;

        /// <summary>原価指定</summary>
        private Int32 _stockUnitChngDivType;

        /// <summary>原価指定名称</summary>
        private string _stockUnitChngDivTypeName;

        /// <summary>仕入先コード(開始)</summary>
        private Int32 _stSupplierCd;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _edSupplierCd;

        /// <summary>粗利チェック下限</summary>
        /// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
        private Double _grsProfitCheckLower;

        /// <summary>粗利チェック2</summary>
        private Double _grossMarginSt;

        /// <summary>粗利チェック3</summary>
        private Double _grossMargin2Ed;

        /// <summary>粗利チェック4</summary>
        private Double _grossMargin3Ed;

        /// <summary>粗利チェック適正</summary>
        /// <remarks>粗利チェックの適正値（％で入力）　XX.X％　以上</remarks>
        private Double _grsProfitCheckBest;

        /// <summary>粗利チェック上限</summary>
        /// <remarks>粗利チェックの上限値（％で入力）　XX.X％　以上</remarks>
        private Double _grsProfitCheckUpper;

        /// <summary>粗利チェック1(マーク)</summary>
        private string _grossMargin1Mark = "";

        /// <summary>粗利チェック2(マーク)</summary>
        private string _grossMargin2Mark = "";

        /// <summary>粗利チェック3(マーク)</summary>
        private string _grossMargin3Mark = "";

        /// <summary>粗利チェック4(マーク)</summary>
        private string _grossMargin4Mark = "";

        #endregion ■ Private Member

        #region ■ Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   企業コードプロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点オプション導入区分プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   本社機能プロパティプロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  StInputDay
        /// <summary>入力日(開始)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StInputDay
        {
            get { return _stInputDay; }
            set { _stInputDay = value; }
        }

        /// public propaty name  :  EdInputDay
        /// <summary>入力日(終了)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdInputDay
        {
            get { return _edInputDay; }
            set { _edInputDay = value; }
        }

        /// public propaty name  :  StStockDate
        /// <summary>仕入日(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StStockDate
        {
            get { return _stStockDate; }
            set { _stStockDate = value; }
        }

        /// public propaty name  :  EdStockDate
        /// <summary>仕入日(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdStockDate
        {
            get { return _edStockDate; }
            set { _edStockDate = value; }
        }

        /// public propaty name  :  NewPageType
        /// <summary>改頁プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }


        /// public propaty name  :  NewPageTypeName
        /// <summary>改頁名称プロパティ</summary>
        /// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPageTypeName
        {
            get { return _newPageTypeName; }
            set { _newPageTypeName = value; }
        }

        /// public propaty name  :  WayToOrderType
        /// <summary>出力指定プロパティ</summary>
        /// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrderType
        {
            get { return _wayToOrderType; }
            set { _wayToOrderType = value; }
        }

        /// public propaty name  :  WayToOrderTypeName
        /// <summary>出力指定名称プロパティ</summary>
        /// <value>支払先(精算先)コード。支払締時は支払先単位で集計・計算。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WayToOrderTypeName
        {
            get { return _wayToOrderTypeName; }
            set { _wayToOrderTypeName = value; }
        }

        /// public propaty name  :  StockOrderDivCdType
        /// <summary>在庫取寄指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockOrderDivCdType
        {
            get { return _stockOrderDivCdType; }
            set { _stockOrderDivCdType = value; }
        }

        /// public propaty name  :  StockOrderDivCdTypeName
        /// <summary>在庫取寄指定名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄指定名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockOrderDivCdTypeName
        {
            get { return _stockOrderDivCdTypeName; }
            set { _stockOrderDivCdTypeName = value; }
        }

        /// public propaty name  :  SalesType
        /// <summary>売上伝票指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesType
        {
            get { return _salesType; }
            set { _salesType = value; }
        }

        /// public propaty name  :  SalesTypeName
        /// <summary>売上伝票指定名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票指定名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesTypeName
        {
            get { return _salesTypeName; }
            set { _salesTypeName = value; }
        }

        /// public propaty name  :  StockUnitChngDivType
        /// <summary>原価指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUnitChngDivType
        {
            get { return _stockUnitChngDivType; }
            set { _stockUnitChngDivType = value; }
        }

        /// public propaty name  :  StockUnitChngDivTypeName
        /// <summary>原価指定名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価指定名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockUnitChngDivTypeName
        {
            get { return _stockUnitChngDivTypeName; }
            set { _stockUnitChngDivTypeName = value; }
        }

        /// public propaty name  :  StSupplierCd
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StSupplierCd
        {
            get { return _stSupplierCd; }
            set { _stSupplierCd = value; }
        }

        /// public propaty name  :  EdSupplierCd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EdSupplierCd
        {
            get { return _edSupplierCd; }
            set { _edSupplierCd = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック下限プロパティ</summary>
        /// <value>粗利チェックの下限値（％で入力）　XX.X％　以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック下限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitCheckLower
        {
            get { return _grsProfitCheckLower; }
            set { _grsProfitCheckLower = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMarginSt
        {
            get { return _grossMarginSt; }
            set { _grossMarginSt = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMargin2Ed
        {
            get { return _grossMargin2Ed; }
            set { _grossMargin2Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>粗利チェック4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double GrossMargin3Ed
        {
            get { return _grossMargin3Ed; }
            set { _grossMargin3Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckBest
        /// <summary>粗利チェック適正プロパティ</summary>
        /// <value>粗利チェックの適正値（％で入力）　XX.X％　以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック適正プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitCheckBest
        {
            get { return _grsProfitCheckBest; }
            set { _grsProfitCheckBest = value; }
        }

        /// public propaty name  :  GrsProfitCheckUpper
        /// <summary>粗利チェック上限プロパティ</summary>
        /// <value>粗利チェックの上限値（％で入力）　XX.X％　以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック上限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitCheckUpper
        {
            get { return _grsProfitCheckUpper; }
            set { _grsProfitCheckUpper = value; }
        }

        /// public propaty name  :  GrossMargin1Mark
        /// <summary>粗利チェック1(マーク)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック1(マーク)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMargin1Mark
        {
            get { return _grossMargin1Mark; }
            set { _grossMargin1Mark = value; }
        }

        /// public propaty name  :  GrossMargin2Mark
        /// <summary>粗利チェック2(マーク)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック2(マーク)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMargin2Mark
        {
            get { return _grossMargin2Mark; }
            set { _grossMargin2Mark = value; }
        }

        /// public propaty name  :  GrossMargin3Mark
        /// <summary>粗利チェック3(マーク)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック3(マーク)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMargin3Mark
        {
            get { return _grossMargin3Mark; }
            set { _grossMargin3Mark = value; }
        }

        /// public propaty name  :  GrossMargin4Mark
        /// <summary>粗利チェック4(マーク)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック4(マーク)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GrossMargin4Mark
        {
            get { return _grossMargin4Mark; }
            set { _grossMargin4Mark = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   全社選択プロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._collectAddupSecCodeList.Length == 1) && (this._collectAddupSecCodeList[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  CollectAddupSecCodeList
        /// <summary>選択計上拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   選択計上拠点コードプロパティを行います。</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public string[] CollectAddupSecCodeList
        {
            get { return _collectAddupSecCodeList; }
            set { _collectAddupSecCodeList = value; }
        }


        #endregion ■ Public Property


        #region ■ Constructor
        /// <summary>
        /// ワークコンストラクタ
        /// </summary>
        /// <returns>PaymentMainCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PaymentMainCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   汪千来</br>
        /// </remarks>
        public StockSalesResultInfoMainCndtn()
        {
            this._collectAddupSecCodeList = new string[0];	// 計上拠点コードリスト 
        }
        #endregion ■ Constructor

    }
}
