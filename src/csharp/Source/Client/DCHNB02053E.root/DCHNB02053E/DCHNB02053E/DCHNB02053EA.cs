using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ShipmGoodsOdrReport
    /// <summary>
    ///                      出荷商品順位表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷商品順位表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/12/16 劉超</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :   明治産業様Seiken品番変更</br>
    /// </remarks>
    public class ShipmGoodsOdrReport
    {
        #region privateフィールド

        #region 画面項目
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCodes;

        /// <summary>集計単位</summary>
        /// <remarks>0:商品別 1:BLコード別 2:得意先別 3:担当者別 </remarks>
        private Int32 _totalType;

        /// <summary>集計方法</summary>
        /// <remarks>0:全社 1:拠点毎</remarks>
        private Int32 _ttlType;

        /// <summary>在庫取寄せ区分</summary>
        /// <remarks>0:合計 1:在庫, 2:取寄せ</remarks>
        private Int32 _rsltTtlDivCd;

        /// <summary>明細単位</summary>
        private Int32 _detail;

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private Int32 _goodsNoTtlDiv;
        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>開始対象年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDateSt;

        /// <summary>終了対象年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDateEd;

        /// <summary>開始印刷範囲指定</summary>
        /// <remarks>初期値:1</remarks>
        private Int32 _printRangeSt;

        /// <summary>終了印刷範囲指定</summary>
        /// <remarks>初期値:999999999</remarks>
        private Int32 _printRangeEd;

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// <summary>開始印刷範囲未入力フラグ</summary>
        /// <remarks>true:未入力(デフォルト)</remarks>
        private bool _printRangeStNoInput;

        /// <summary>終了印刷範囲未入力フラグ</summary>
        /// <remarks>true:未入力(デフォルト)</remarks>
        private bool _printRangeEdNoInput;
        // --- ADD 2009/02/10 --------------------------------<<<<<

        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCdSt;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCdEd;

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        /// <summary>開始従業員コード</summary>
        private string _employeeCodeSt = "";

        /// <summary>終了従業員コード</summary>
        private string _employeeCodeEd = "";

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>開始商品大分類コード</summary>
        private Int32 _goodsLGroupSt;

        /// <summary>終了商品大分類コード</summary>
        private Int32 _goodsLGroupEd;

        /// <summary>開始商品中分類コード</summary>
        private Int32 _goodsMGroupSt;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _goodsMGroupEd;

        /// <summary>開始BLグループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了BLグループコード</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>単体BLグループコード</summary>
        /// <remarks>(配列)　指定なしは{""}</remarks>
        private Int32[] _bLGroupCodeAry;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始商品番号</summary>
        private string _goodsNoSt = "";

        /// <summary>終了商品番号</summary>
        private string _goodsNoEd = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:合計 1:在庫, 2:取寄せ</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>金額単位</summary>
        /// <remarks>0:円 1:千円</remarks>
        private Int32 _moneyUnit;

        /// <summary>改頁</summary>
        /// <remarks>0:なし 1:拠点 2:得意先 3:担当者 4:仕入先</remarks>
        private Int32 _crMode;

        /// <summary>順位付設定1</summary>
        /// <remarks>0:全体 1:拠点単位</remarks>
        private Int32 _order1;

        /// <summary>順位付設定2</summary>
        /// <remarks>0:上位 1:下位</remarks>
        private Int32 _order2;

        /// <summary>順位付設定3</summary>
        /// <remarks>初期値:999999999</remarks>
        private Int32 _order3;

        // --- ADD 2008/09/24 -------------------------------->>>>>
        /// <summary>構成比単位</summary>
        /// <remarks>0:総合計 1:拠点計</remarks>
        private Int32 _constUnit;
        // --- ADD 2008/09/24 --------------------------------<<<<<
        
        /// <summary>小計印刷(拠点)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalSection;

        /// <summary>小計印刷(仕入先)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalSupplier;

        /// <summary>小計印刷(メーカー)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalMaker;

        /// <summary>小計印刷(商品大分類)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalGoodsLGroup;

        /// <summary>小計印刷(商品中分類)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalGoodsMGroup;

        /// <summary>小計印刷(グループコード)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalGroupCode;

        /// <summary>小計印刷(BLコード)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalBl;

        /// <summary>小計印刷(得意先)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalCustomer;

        /// <summary>小計印刷(担当者)</summary>
        /// <remarks>0:なし 1:あり</remarks>
        private Int32 _subtotalSalesEmployee;

        #endregion

        #region 印刷用項目

        /// <summary>印刷用対象年月(開始)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _prnSalesDateSt;

        /// <summary>印刷用対象年月(終了)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _prnSalesDateEd;

        /// <summary>順位設定</summary>
        /// <remarks>0:売上数量 1:売上回数 2:売上金額 3:粗利金額 4:順位なし</remarks>
        private Int32 _sortItem;

        /// <summary>印刷タイプ</summary>
        /// <remarks>0:数量,1:回数,2:金額,3:金額＆数量,4:金額＆回数,5:数量＆回数</remarks>
        private Int32 _printType;

        #endregion

        #endregion

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  TotalType
        /// <summary>集計単位プロパティ</summary>
        /// <value>0:商品別 1:BLコード別 2:得意先別 3:担当者別 </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  TtlType
        /// <summary>集計方法プロパティ</summary>
        /// <value>0:全社 1:拠点毎</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>在庫取寄せ区分プロパティ</summary>
        /// <value>0:合計 1:在庫, 2:取寄せ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  Detail
        /// <summary>明細単位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>品番集計区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// public propaty name  :  GoodsNoShowDiv
        /// <summary>品番表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// public propaty name  :  SalesDateSt
        /// <summary>開始対象年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>終了対象年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  PrintRangeSt
        /// <summary>開始印刷範囲指定プロパティ</summary>
        /// <value>初期値:1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始印刷範囲指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintRangeSt
        {
            get { return _printRangeSt; }
            set { _printRangeSt = value; }
        }

        /// public propaty name  :  PrintRangeEd
        /// <summary>終了印刷範囲指定プロパティ</summary>
        /// <value>初期値:999999999</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了印刷範囲指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintRangeEd
        {
            get { return _printRangeEd; }
            set { _printRangeEd = value; }
        }

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// public propaty name  :  PrintRangeStNoInput
        /// <summary>開始印刷範囲指定未入力プロパティ</summary>
        /// <value>true:未入力(デフォルト)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始印刷範囲指定未入力プロパティ</br>
        /// </remarks>
        public bool PrintRangeStNoInput
        {
            get { return _printRangeStNoInput; }
            set { _printRangeStNoInput = value; }
        }

        /// public propaty name  :  PrintRangeEdNoInput
        /// <summary>終了印刷範囲指定未入力プロパティ</summary>
        /// <value>true:未入力(デフォルト)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了印刷範囲指定未入力プロパティ</br>
        /// </remarks>
        public bool PrintRangeEdNoInput
        {
            get { return _printRangeEdNoInput; }
            set { _printRangeEdNoInput = value; }
        }
        // --- ADD 2009/02/10 --------------------------------<<<<<

        /// public propaty name  :  SupplierCdSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsLGroupSt
        /// <summary>開始商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroupSt
        {
            get { return _goodsLGroupSt; }
            set { _goodsLGroupSt = value; }
        }

        /// public propaty name  :  GoodsLGroupEd
        /// <summary>終了商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroupEd
        {
            get { return _goodsLGroupEd; }
            set { _goodsLGroupEd = value; }
        }

        /// public propaty name  :  GoodsMGroupSt
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeAry
        /// <summary>単体BLグループコードプロパティ</summary>
        /// <value>(配列)　指定なしは{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単体BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] BLGroupCodeAry
        {
            get { return _bLGroupCodeAry; }
            set { _bLGroupCodeAry = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:合計 1:在庫, 2:取寄せ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  MoneyUnit
        /// <summary>金額単位プロパティ</summary>
        /// <value>0:円 1:千円</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }

        /// public propaty name  :  CrMode
        /// <summary>改頁プロパティ</summary>
        /// <value>0:なし 1:拠点 2:得意先 3:担当者 4:仕入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CrMode
        {
            get { return _crMode; }
            set { _crMode = value; }
        }

        /// public propaty name  :  Order1
        /// <summary>順位付設定1プロパティ</summary>
        /// <value>0:全体 1:拠点単位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位付設定1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Order1
        {
            get { return _order1; }
            set { _order1 = value; }
        }

        /// public propaty name  :  Order2
        /// <summary>順位付設定2プロパティ</summary>
        /// <value>0:上位 1:下位</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位付設定2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Order2
        {
            get { return _order2; }
            set { _order2 = value; }
        }

        /// public propaty name  :  Order3
        /// <summary>順位付設定3プロパティ</summary>
        /// <value>初期値:999999999</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   順位付設定3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Order3
        {
            get { return _order3; }
            set { _order3 = value; }
        }

        /// public propaty name  :  ConstUnit
        /// <summary>構成比単位プロパティ</summary>
        /// <value>0:総合計 1:拠点計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   構成比単位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConstUnit
        {
            get { return _constUnit; }
            set { _constUnit = value; }
        }

        /// public propaty name  :  SubtotalSection
        /// <summary>小計印刷(拠点)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(拠点)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalSection
        {
            get { return _subtotalSection; }
            set { _subtotalSection = value; }
        }

        /// public propaty name  :  SubtotalSupplier
        /// <summary>小計印刷(仕入先)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(仕入先)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalSupplier
        {
            get { return _subtotalSupplier; }
            set { _subtotalSupplier = value; }
        }

        /// public propaty name  :  SubtotalMaker
        /// <summary>小計印刷(メーカー)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(メーカー)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalMaker
        {
            get { return _subtotalMaker; }
            set { _subtotalMaker = value; }
        }

        /// public propaty name  :  SubtotalGoodsLGroup
        /// <summary>小計印刷(商品大分類)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(商品大分類)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalGoodsLGroup
        {
            get { return _subtotalGoodsLGroup; }
            set { _subtotalGoodsLGroup = value; }
        }

        /// public propaty name  :  SubtotalGoodsMGroup
        /// <summary>小計印刷(商品中分類)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(商品中分類)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalGoodsMGroup
        {
            get { return _subtotalGoodsMGroup; }
            set { _subtotalGoodsMGroup = value; }
        }

        /// public propaty name  :  SubtotalGroupCode
        /// <summary>小計印刷(グループコード)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(グループコード)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalGroupCode
        {
            get { return _subtotalGroupCode; }
            set { _subtotalGroupCode = value; }
        }

        /// public propaty name  :  SubtotalBl
        /// <summary>小計印刷(BLコード)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(BLコード)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalBl
        {
            get { return _subtotalBl; }
            set { _subtotalBl = value; }
        }

        /// public propaty name  :  SubtotalCustomer
        /// <summary>小計印刷(得意先)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(得意先)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalCustomer
        {
            get { return _subtotalCustomer; }
            set { _subtotalCustomer = value; }
        }

        /// public propaty name  :  SubtotalSalesEmployee
        /// <summary>小計印刷(担当者)プロパティ</summary>
        /// <value>0:なし 1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小計印刷(担当者)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalSalesEmployee
        {
            get { return _subtotalSalesEmployee; }
            set { _subtotalSalesEmployee = value; }
        }

        /// public propaty name  :  PrnSalesDateSt
        /// <summary>印刷用対象年月(開始)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用対象年月(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PrnSalesDateSt
        {
            get { return _prnSalesDateSt; }
            set { _prnSalesDateSt = value; }
        }

        /// public propaty name  :  PrnSalesDateEd
        /// <summary>印刷用対象年月(終了)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用対象年月(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PrnSalesDateEd
        {
            get { return _prnSalesDateEd; }
            set { _prnSalesDateEd = value; }
        }

        /// public propaty name  :  SortItem
        /// <summary>ソート項目プロパティ</summary>
        /// <value>0:売上数量 1:売上回数 2:売上金額 3:粗利金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ソート項目プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SortItem
        {
            get { return _sortItem; }
            set { _sortItem = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>印字タイププロパティ</summary>
        /// <value>0:数量,1:回数,2:金額,3:金額＆数量,4:金額＆回数,5:数量＆回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// <summary>
        /// 売上順位表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ShipmGoodsOdrReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmGoodsOdrReport()
        {
        }

        /// <summary>
        /// 売上順位表抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCodes">拠点コード((配列)　全社指定は{""})</param>
        /// <param name="totalType">集計単位(0:商品別 1:BLコード別 2:得意先別 3:担当者別 )</param>
        /// <param name="ttlType">集計方法(0:全社 1:拠点毎)</param>
        /// <param name="rsltTtlDivCd">在庫取寄せ区分(0:合計 1:在庫, 2:取寄せ)</param>
        /// <param name="detail">明細単位</param>
        /// <param name="goodsNoTtlDiv">品番集計区分</param> // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        /// <param name="goodsNoShowDiv">品番表示区分</param> // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        /// <param name="salesDateSt">開始対象年月(YYYYMM)</param>
        /// <param name="salesDateEd">終了対象年月(YYYYMM)</param>
        /// <param name="printRangeSt">開始印刷範囲指定(初期値:1)</param>
        /// <param name="printRangeEd">終了印刷範囲指定(初期値:999999999)</param>
        /// <param name="supplierCdSt">開始仕入先コード</param>
        /// <param name="supplierCdEd">終了仕入先コード</param>
        /// <param name="customerCodeSt">開始得意先コード</param>
        /// <param name="customerCodeEd">終了得意先コード</param>
        /// <param name="employeeCodeSt">開始従業員コード</param>
        /// <param name="employeeCodeEd">終了従業員コード</param>
        /// <param name="goodsMakerCdSt">開始商品メーカーコード</param>
        /// <param name="goodsMakerCdEd">終了商品メーカーコード</param>
        /// <param name="goodsLGroupSt">開始商品大分類コード</param>
        /// <param name="goodsLGroupEd">終了商品大分類コード</param>
        /// <param name="goodsMGroupSt">開始商品中分類コード</param>
        /// <param name="goodsMGroupEd">終了商品中分類コード</param>
        /// <param name="bLGroupCodeSt">開始BLグループコード</param>
        /// <param name="bLGroupCodeEd">終了BLグループコード</param>
        /// <param name="bLGroupCodeAry">単体BLグループコード((配列)　指定なしは{""})</param>
        /// <param name="bLGoodsCodeSt">開始BL商品コード</param>
        /// <param name="bLGoodsCodeEd">終了BL商品コード</param>
        /// <param name="goodsNoSt">開始商品番号</param>
        /// <param name="goodsNoEd">終了商品番号</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>ShipmGoodsOdrReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public ShipmGoodsOdrReport(string enterpriseCode, string[] sectionCodes, Int32 totalType, Int32 ttlType, Int32 rsltTtlDivCd, Int32 detail, DateTime salesDateSt, DateTime salesDateEd, Int32 printRangeSt, Int32 printRangeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 customerCodeSt, Int32 customerCodeEd, string employeeCodeSt, string employeeCodeEd, Int32 goodsMakerCdSt, Int32 goodsMakerCdEd, Int32 goodsLGroupSt, Int32 goodsLGroupEd, Int32 goodsMGroupSt, Int32 goodsMGroupEd, Int32 bLGroupCodeSt, Int32 bLGroupCodeEd, Int32[] bLGroupCodeAry, Int32 bLGoodsCodeSt, Int32 bLGoodsCodeEd, string goodsNoSt, string goodsNoEd, string enterpriseName, Int32 constUnit, Int32 CrMode, Int32 moneyUnit, Int32 order1, Int32 order2, Int32 order3, Int32 printType, DateTime prnSalesDateSt, DateTime prnSalesDateEd, Int32 salesOrderDivCd, Int32 sortItem, Int32 subtotalBl, Int32 subtotalCustomer, Int32 subtotalGoodsLGroup, Int32 subtotalGoodsMGroup, Int32 subtotalGroupCode, Int32 subtotalMaker, Int32 subtotalSalesEmployee, Int32 subtotalSection, Int32 subtotalSupplier) // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        public ShipmGoodsOdrReport(string enterpriseCode, string[] sectionCodes, Int32 totalType, Int32 ttlType, Int32 rsltTtlDivCd, Int32 detail, Int32 goodsNoTtlDiv, Int32 goodsNoShowDiv, DateTime salesDateSt, DateTime salesDateEd, Int32 printRangeSt, Int32 printRangeEd, Int32 supplierCdSt, Int32 supplierCdEd, Int32 customerCodeSt, Int32 customerCodeEd, string employeeCodeSt, string employeeCodeEd, Int32 goodsMakerCdSt, Int32 goodsMakerCdEd, Int32 goodsLGroupSt, Int32 goodsLGroupEd, Int32 goodsMGroupSt, Int32 goodsMGroupEd, Int32 bLGroupCodeSt, Int32 bLGroupCodeEd, Int32[] bLGroupCodeAry, Int32 bLGoodsCodeSt, Int32 bLGoodsCodeEd, string goodsNoSt, string goodsNoEd, string enterpriseName, Int32 constUnit, Int32 CrMode, Int32 moneyUnit, Int32 order1, Int32 order2, Int32 order3, Int32 printType, DateTime prnSalesDateSt, DateTime prnSalesDateEd, Int32 salesOrderDivCd, Int32 sortItem, Int32 subtotalBl, Int32 subtotalCustomer, Int32 subtotalGoodsLGroup, Int32 subtotalGoodsMGroup, Int32 subtotalGroupCode, Int32 subtotalMaker, Int32 subtotalSalesEmployee, Int32 subtotalSection, Int32 subtotalSupplier) // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCodes = sectionCodes;
            this._totalType = totalType;
            this._ttlType = ttlType;
            this._rsltTtlDivCd = rsltTtlDivCd;
            this._detail = detail;
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            this._goodsNoTtlDiv = goodsNoTtlDiv;
            this._goodsNoShowDiv = goodsNoShowDiv;
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._printRangeSt = printRangeSt;
            this._printRangeEd = printRangeEd;
            this._supplierCdSt = supplierCdSt;
            this._supplierCdEd = supplierCdEd;
            this._customerCodeSt = customerCodeSt;
            this._customerCodeEd = customerCodeEd;
            this._employeeCodeSt = employeeCodeSt;
            this._employeeCodeEd = employeeCodeEd;
            this._goodsMakerCdSt = goodsMakerCdSt;
            this._goodsMakerCdEd = goodsMakerCdEd;
            this._goodsLGroupSt = goodsLGroupSt;
            this._goodsLGroupEd = goodsLGroupEd;
            this._goodsMGroupSt = goodsMGroupSt;
            this._goodsMGroupEd = goodsMGroupEd;
            this._bLGroupCodeSt = bLGroupCodeSt;
            this._bLGroupCodeEd = bLGroupCodeEd;
            this._bLGroupCodeAry = bLGroupCodeAry;
            this._bLGoodsCodeSt = bLGoodsCodeSt;
            this._bLGoodsCodeEd = bLGoodsCodeEd;
            this._goodsNoSt = goodsNoSt;
            this._goodsNoEd = goodsNoEd;
            this._enterpriseName = enterpriseName;
            this._constUnit = constUnit;
            this._crMode = CrMode;
            this._moneyUnit = moneyUnit;
            this._order1 = order1;
            this._order2 = order2;
            this._order3 = order3;
            this._printType = printType;
            this._prnSalesDateSt = prnSalesDateSt;
            this._prnSalesDateEd = prnSalesDateEd;
            this._salesOrderDivCd = salesOrderDivCd;
            this._sortItem = sortItem;
            this._subtotalBl = subtotalBl;
            this._subtotalCustomer = subtotalCustomer;
            this._subtotalGoodsLGroup = subtotalGoodsLGroup;
            this._subtotalGoodsMGroup = subtotalGoodsMGroup;
            this._subtotalGroupCode = subtotalGroupCode;
            this._subtotalMaker = subtotalMaker;
            this._subtotalSalesEmployee = subtotalSalesEmployee;
            this._subtotalSection = subtotalSection;
            this._subtotalSupplier = subtotalSupplier;
        }

        /// <summary>
        /// 売上順位表抽出条件クラス複製処理
        /// </summary>
        /// <returns>ShipmGoodsOdrReportクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいShipmGoodsOdrReportクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipmGoodsOdrReport Clone()
        {
            //return new ShipmGoodsOdrReport(this._enterpriseCode, this._sectionCodes, this._totalType, this._ttlType, this._rsltTtlDivCd, this._detail, this._salesDateSt, this._salesDateEd, this._printRangeSt, this._printRangeEd, this._supplierCdSt, this._supplierCdEd, this._customerCodeSt, this._customerCodeEd, this._employeeCodeSt, this._employeeCodeEd, this._goodsMakerCdSt, this._goodsMakerCdEd, this._goodsLGroupSt, this._goodsLGroupEd, this._goodsMGroupSt, this._goodsMGroupEd, this._bLGroupCodeSt, this._bLGroupCodeEd, this._bLGroupCodeAry, this._bLGoodsCodeSt, this._bLGoodsCodeEd, this._goodsNoSt, this._goodsNoEd, this._enterpriseName, this._constUnit, this._crMode, this._moneyUnit, this._order1, this._order2, this._order3, this._printType, this._prnSalesDateSt, this._prnSalesDateEd, this._salesOrderDivCd, this._sortItem, this._subtotalBl, this._subtotalCustomer, this._subtotalGoodsLGroup, this._subtotalGoodsMGroup, this._subtotalGroupCode, this._subtotalMaker, this._subtotalSalesEmployee, this._subtotalSection, this._subtotalSupplier); // DEL 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
            return new ShipmGoodsOdrReport(this._enterpriseCode, this._sectionCodes, this._totalType, this._ttlType, this._rsltTtlDivCd, this._detail, this._goodsNoTtlDiv, this._goodsNoShowDiv, this._salesDateSt, this._salesDateEd, this._printRangeSt, this._printRangeEd, this._supplierCdSt, this._supplierCdEd, this._customerCodeSt, this._customerCodeEd, this._employeeCodeSt, this._employeeCodeEd, this._goodsMakerCdSt, this._goodsMakerCdEd, this._goodsLGroupSt, this._goodsLGroupEd, this._goodsMGroupSt, this._goodsMGroupEd, this._bLGroupCodeSt, this._bLGroupCodeEd, this._bLGroupCodeAry, this._bLGoodsCodeSt, this._bLGoodsCodeEd, this._goodsNoSt, this._goodsNoEd, this._enterpriseName, this._constUnit, this._crMode, this._moneyUnit, this._order1, this._order2, this._order3, this._printType, this._prnSalesDateSt, this._prnSalesDateEd, this._salesOrderDivCd, this._sortItem, this._subtotalBl, this._subtotalCustomer, this._subtotalGoodsLGroup, this._subtotalGoodsMGroup, this._subtotalGroupCode, this._subtotalMaker, this._subtotalSalesEmployee, this._subtotalSection, this._subtotalSupplier); // ADD 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更
        }

        /// <summary>
        /// 売上順位表抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmGoodsOdrReportクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ShipmGoodsOdrReport target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCodes == target.SectionCodes)
                 && (this.TotalType == target.TotalType)
                 && (this.TtlType == target.TtlType)
                 && (this.RsltTtlDivCd == target.RsltTtlDivCd)
                 && (this.Detail == target.Detail)
                 //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                 && (this.GoodsNoTtlDiv == target.GoodsNoTtlDiv)
                 && (this.GoodsNoShowDiv == target.GoodsNoShowDiv)
                 //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.PrintRangeSt == target.PrintRangeSt)
                 && (this.PrintRangeEd == target.PrintRangeEd)
                 && (this.SupplierCdSt == target.SupplierCdSt)
                 && (this.SupplierCdEd == target.SupplierCdEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.EmployeeCodeSt == target.EmployeeCodeSt)
                 && (this.EmployeeCodeEd == target.EmployeeCodeEd)
                 && (this.GoodsMakerCdSt == target.GoodsMakerCdSt)
                 && (this.GoodsMakerCdEd == target.GoodsMakerCdEd)
                 && (this.GoodsLGroupSt == target.GoodsLGroupSt)
                 && (this.GoodsLGroupEd == target.GoodsLGroupEd)
                 && (this.GoodsMGroupSt == target.GoodsMGroupSt)
                 && (this.GoodsMGroupEd == target.GoodsMGroupEd)
                 && (this.BLGroupCodeSt == target.BLGroupCodeSt)
                 && (this.BLGroupCodeEd == target.BLGroupCodeEd)
                 && (this.BLGroupCodeAry == target.BLGroupCodeAry)
                 && (this.BLGoodsCodeSt == target.BLGoodsCodeSt)
                 && (this.BLGoodsCodeEd == target.BLGoodsCodeEd)
                 && (this.GoodsNoSt == target.GoodsNoSt)
                 && (this.GoodsNoEd == target.GoodsNoEd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.ConstUnit == target.ConstUnit)
                 && (this.CrMode == target.CrMode)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.Order1 == target.Order1)
                 && (this.Order2 == target.Order2)
                 && (this.Order3 == target.Order3)
                 && (this.PrintType == target.PrintType)
                 && (this.PrnSalesDateSt == target.PrnSalesDateSt)
                 && (this.PrnSalesDateEd == target.PrnSalesDateEd)
                 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
                 && (this.SortItem == target.SortItem)
                 && (this.SubtotalBl == target.SubtotalBl)
                 && (this.SubtotalCustomer == target.SubtotalCustomer)
                 && (this.SubtotalGoodsLGroup == target.SubtotalGoodsLGroup)
                 && (this.SubtotalGoodsMGroup == target.SubtotalGoodsMGroup)
                 && (this.SubtotalGroupCode == target.SubtotalGroupCode)
                 && (this.SubtotalMaker == target.SubtotalMaker)
                 && (this.SubtotalSalesEmployee == target.SubtotalSalesEmployee)
                 && (this.SubtotalSection == target.SubtotalSection)
                 && (this.SubtotalSupplier == target.SubtotalSupplier));
        }

        /// <summary>
        /// 売上順位表抽出条件クラス比較処理
        /// </summary>
        /// <param name="ShipmGoodsOdrReport1">
        ///                    比較するShipmGoodsOdrReportクラスのインスタンス
        /// </param>
        /// <param name="ShipmGoodsOdrReport2">比較するShipmGoodsOdrReportクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ShipmGoodsOdrReport ShipmGoodsOdrReport1, ShipmGoodsOdrReport ShipmGoodsOdrReport2)
        {
            return ((ShipmGoodsOdrReport1.EnterpriseCode == ShipmGoodsOdrReport2.EnterpriseCode)
                 && (ShipmGoodsOdrReport1.SectionCodes == ShipmGoodsOdrReport2.SectionCodes)
                 && (ShipmGoodsOdrReport1.TotalType == ShipmGoodsOdrReport2.TotalType)
                 && (ShipmGoodsOdrReport1.TtlType == ShipmGoodsOdrReport2.TtlType)
                 && (ShipmGoodsOdrReport1.RsltTtlDivCd == ShipmGoodsOdrReport2.RsltTtlDivCd)
                 && (ShipmGoodsOdrReport1.Detail == ShipmGoodsOdrReport2.Detail)
                 //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                 && (ShipmGoodsOdrReport1.GoodsNoTtlDiv == ShipmGoodsOdrReport2.GoodsNoTtlDiv)
                 && (ShipmGoodsOdrReport1.GoodsNoShowDiv == ShipmGoodsOdrReport2.GoodsNoShowDiv)
                 //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                 && (ShipmGoodsOdrReport1.SalesDateSt == ShipmGoodsOdrReport2.SalesDateSt)
                 && (ShipmGoodsOdrReport1.SalesDateEd == ShipmGoodsOdrReport2.SalesDateEd)
                 && (ShipmGoodsOdrReport1.PrintRangeSt == ShipmGoodsOdrReport2.PrintRangeSt)
                 && (ShipmGoodsOdrReport1.PrintRangeEd == ShipmGoodsOdrReport2.PrintRangeEd)
                 && (ShipmGoodsOdrReport1.SupplierCdSt == ShipmGoodsOdrReport2.SupplierCdSt)
                 && (ShipmGoodsOdrReport1.SupplierCdEd == ShipmGoodsOdrReport2.SupplierCdEd)
                 && (ShipmGoodsOdrReport1.CustomerCodeSt == ShipmGoodsOdrReport2.CustomerCodeSt)
                 && (ShipmGoodsOdrReport1.CustomerCodeEd == ShipmGoodsOdrReport2.CustomerCodeEd)
                 && (ShipmGoodsOdrReport1.EmployeeCodeSt == ShipmGoodsOdrReport2.EmployeeCodeSt)
                 && (ShipmGoodsOdrReport1.EmployeeCodeEd == ShipmGoodsOdrReport2.EmployeeCodeEd)
                 && (ShipmGoodsOdrReport1.GoodsMakerCdSt == ShipmGoodsOdrReport2.GoodsMakerCdSt)
                 && (ShipmGoodsOdrReport1.GoodsMakerCdEd == ShipmGoodsOdrReport2.GoodsMakerCdEd)
                 && (ShipmGoodsOdrReport1.GoodsLGroupSt == ShipmGoodsOdrReport2.GoodsLGroupSt)
                 && (ShipmGoodsOdrReport1.GoodsLGroupEd == ShipmGoodsOdrReport2.GoodsLGroupEd)
                 && (ShipmGoodsOdrReport1.GoodsMGroupSt == ShipmGoodsOdrReport2.GoodsMGroupSt)
                 && (ShipmGoodsOdrReport1.GoodsMGroupEd == ShipmGoodsOdrReport2.GoodsMGroupEd)
                 && (ShipmGoodsOdrReport1.BLGroupCodeSt == ShipmGoodsOdrReport2.BLGroupCodeSt)
                 && (ShipmGoodsOdrReport1.BLGroupCodeEd == ShipmGoodsOdrReport2.BLGroupCodeEd)
                 && (ShipmGoodsOdrReport1.BLGroupCodeAry == ShipmGoodsOdrReport2.BLGroupCodeAry)
                 && (ShipmGoodsOdrReport1.BLGoodsCodeSt == ShipmGoodsOdrReport2.BLGoodsCodeSt)
                 && (ShipmGoodsOdrReport1.BLGoodsCodeEd == ShipmGoodsOdrReport2.BLGoodsCodeEd)
                 && (ShipmGoodsOdrReport1.GoodsNoSt == ShipmGoodsOdrReport2.GoodsNoSt)
                 && (ShipmGoodsOdrReport1.GoodsNoEd == ShipmGoodsOdrReport2.GoodsNoEd)
                 && (ShipmGoodsOdrReport1.EnterpriseName == ShipmGoodsOdrReport2.EnterpriseName)
                 && (ShipmGoodsOdrReport1.ConstUnit == ShipmGoodsOdrReport2.ConstUnit)
                 && (ShipmGoodsOdrReport1.CrMode == ShipmGoodsOdrReport2.CrMode)
                 && (ShipmGoodsOdrReport1.MoneyUnit == ShipmGoodsOdrReport2.MoneyUnit)
                 && (ShipmGoodsOdrReport1.Order1 == ShipmGoodsOdrReport2.Order1)
                 && (ShipmGoodsOdrReport1.Order2 == ShipmGoodsOdrReport2.Order2)
                 && (ShipmGoodsOdrReport1.Order3 == ShipmGoodsOdrReport2.Order3)
                 && (ShipmGoodsOdrReport1.PrintType == ShipmGoodsOdrReport2.PrintType)
                 && (ShipmGoodsOdrReport1.PrnSalesDateSt == ShipmGoodsOdrReport2.PrnSalesDateSt)
                 && (ShipmGoodsOdrReport1.PrnSalesDateEd == ShipmGoodsOdrReport2.PrnSalesDateEd)
                 && (ShipmGoodsOdrReport1.SalesOrderDivCd == ShipmGoodsOdrReport2.SalesOrderDivCd)
                 && (ShipmGoodsOdrReport1.SortItem == ShipmGoodsOdrReport2.SortItem)
                 && (ShipmGoodsOdrReport1.SubtotalBl == ShipmGoodsOdrReport2.SubtotalBl)
                 && (ShipmGoodsOdrReport1.SubtotalCustomer == ShipmGoodsOdrReport2.SubtotalCustomer)
                 && (ShipmGoodsOdrReport1.SubtotalGoodsLGroup == ShipmGoodsOdrReport2.SubtotalGoodsLGroup)
                 && (ShipmGoodsOdrReport1.SubtotalGoodsMGroup == ShipmGoodsOdrReport2.SubtotalGoodsMGroup)
                 && (ShipmGoodsOdrReport1.SubtotalGroupCode == ShipmGoodsOdrReport2.SubtotalGroupCode)
                 && (ShipmGoodsOdrReport1.SubtotalMaker == ShipmGoodsOdrReport2.SubtotalMaker)
                 && (ShipmGoodsOdrReport1.SubtotalSalesEmployee == ShipmGoodsOdrReport2.SubtotalSalesEmployee)
                 && (ShipmGoodsOdrReport1.SubtotalSection == ShipmGoodsOdrReport2.SubtotalSection)
                 && (ShipmGoodsOdrReport1.SubtotalSupplier == ShipmGoodsOdrReport2.SubtotalSupplier)
                 );
        }
        /// <summary>
        /// 売上順位表抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のShipmGoodsOdrReportクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(ShipmGoodsOdrReport target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCodes != target.SectionCodes) resList.Add("SectionCodes");
            if (this.TotalType != target.TotalType) resList.Add("TotalType");
            if (this.TtlType != target.TtlType) resList.Add("TtlType");
            if (this.RsltTtlDivCd != target.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (this.Detail != target.Detail) resList.Add("Detail");
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (this.GoodsNoTtlDiv != target.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (this.GoodsNoShowDiv != target.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.PrintRangeSt != target.PrintRangeSt) resList.Add("PrintRangeSt");
            if (this.PrintRangeEd != target.PrintRangeEd) resList.Add("PrintRangeEd");
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.EmployeeCodeSt != target.EmployeeCodeSt) resList.Add("EmployeeCodeSt");
            if (this.EmployeeCodeEd != target.EmployeeCodeEd) resList.Add("EmployeeCodeEd");
            if (this.GoodsMakerCdSt != target.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (this.GoodsMakerCdEd != target.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (this.GoodsLGroupSt != target.GoodsLGroupSt) resList.Add("GoodsLGroupSt");
            if (this.GoodsLGroupEd != target.GoodsLGroupEd) resList.Add("GoodsLGroupEd");
            if (this.GoodsMGroupSt != target.GoodsMGroupSt) resList.Add("GoodsMGroupSt");
            if (this.GoodsMGroupEd != target.GoodsMGroupEd) resList.Add("GoodsMGroupEd");
            if (this.BLGroupCodeSt != target.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (this.BLGroupCodeEd != target.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (this.BLGroupCodeAry != target.BLGroupCodeAry) resList.Add("BLGroupCodeAry");
            if (this.BLGoodsCodeSt != target.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (this.BLGoodsCodeEd != target.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (this.GoodsNoSt != target.GoodsNoSt) resList.Add("GoodsNoSt");
            if (this.GoodsNoEd != target.GoodsNoEd) resList.Add("GoodsNoEd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.ConstUnit != target.ConstUnit) resList.Add("ConstUnit");
            if (this.CrMode != target.CrMode) resList.Add("CrMode");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.Order1 != target.Order1) resList.Add("Order1");
            if (this.Order2 != target.Order2) resList.Add("Order2");
            if (this.Order3 != target.Order3) resList.Add("Order3");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.PrnSalesDateSt != target.PrnSalesDateSt) resList.Add("PrnSalesDateSt");
            if (this.PrnSalesDateEd != target.PrnSalesDateEd) resList.Add("PrnSalesDateEd");
            if (this.SalesOrderDivCd != target.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (this.SortItem != target.SortItem) resList.Add("SortItem");
            if (this.SubtotalBl != target.SubtotalBl) resList.Add("SubtotalBl");
            if (this.SubtotalCustomer != target.SubtotalCustomer) resList.Add("SubtotalCustomer");
            if (this.SubtotalGoodsLGroup != target.SubtotalGoodsLGroup) resList.Add("SubtotalGoodsLGroup");
            if (this.SubtotalGoodsMGroup != target.SubtotalGoodsMGroup) resList.Add("SubtotalGoodsMGroup");
            if (this.SubtotalGroupCode != target.SubtotalGroupCode) resList.Add("SubtotalGroupCode");
            if (this.SubtotalMaker != target.SubtotalMaker) resList.Add("SubtotalMaker");
            if (this.SubtotalSalesEmployee != target.SubtotalSalesEmployee) resList.Add("SubtotalSalesEmployee");
            if (this.SubtotalSection != target.SubtotalSection) resList.Add("SubtotalSection");
            if (this.SubtotalSupplier != target.SubtotalSupplier) resList.Add("SubtotalSupplier");
            
            return resList;
        }

        /// <summary>
        /// 売上順位表抽出条件クラス比較処理
        /// </summary>
        /// <param name="ShipmGoodsOdrReport1">比較するShipmGoodsOdrReportクラスのインスタンス</param>
        /// <param name="ShipmGoodsOdrReport2">比較するShipmGoodsOdrReportクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipmGoodsOdrReportクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(ShipmGoodsOdrReport ShipmGoodsOdrReport1, ShipmGoodsOdrReport ShipmGoodsOdrReport2)
        {
            ArrayList resList = new ArrayList();
            if (ShipmGoodsOdrReport1.EnterpriseCode != ShipmGoodsOdrReport2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (ShipmGoodsOdrReport1.SectionCodes != ShipmGoodsOdrReport2.SectionCodes) resList.Add("SectionCodes");
            if (ShipmGoodsOdrReport1.TotalType != ShipmGoodsOdrReport2.TotalType) resList.Add("TotalType");
            if (ShipmGoodsOdrReport1.TtlType != ShipmGoodsOdrReport2.TtlType) resList.Add("TtlType");
            if (ShipmGoodsOdrReport1.RsltTtlDivCd != ShipmGoodsOdrReport2.RsltTtlDivCd) resList.Add("RsltTtlDivCd");
            if (ShipmGoodsOdrReport1.Detail != ShipmGoodsOdrReport2.Detail) resList.Add("Detail");
            //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
            if (ShipmGoodsOdrReport1.GoodsNoTtlDiv != ShipmGoodsOdrReport2.GoodsNoTtlDiv) resList.Add("GoodsNoTtlDiv");
            if (ShipmGoodsOdrReport1.GoodsNoShowDiv != ShipmGoodsOdrReport2.GoodsNoShowDiv) resList.Add("GoodsNoShowDiv");
            //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
            if (ShipmGoodsOdrReport1.SalesDateSt != ShipmGoodsOdrReport2.SalesDateSt) resList.Add("SalesDateSt");
            if (ShipmGoodsOdrReport1.SalesDateEd != ShipmGoodsOdrReport2.SalesDateEd) resList.Add("SalesDateEd");
            if (ShipmGoodsOdrReport1.PrintRangeSt != ShipmGoodsOdrReport2.PrintRangeSt) resList.Add("PrintRangeSt");
            if (ShipmGoodsOdrReport1.PrintRangeEd != ShipmGoodsOdrReport2.PrintRangeEd) resList.Add("PrintRangeEd");
            if (ShipmGoodsOdrReport1.SupplierCdSt != ShipmGoodsOdrReport2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (ShipmGoodsOdrReport1.SupplierCdEd != ShipmGoodsOdrReport2.SupplierCdEd) resList.Add("SupplierCdEd");
            if (ShipmGoodsOdrReport1.CustomerCodeSt != ShipmGoodsOdrReport2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (ShipmGoodsOdrReport1.CustomerCodeEd != ShipmGoodsOdrReport2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (ShipmGoodsOdrReport1.EmployeeCodeSt != ShipmGoodsOdrReport2.EmployeeCodeSt) resList.Add("EmployeeCodeSt");
            if (ShipmGoodsOdrReport1.EmployeeCodeEd != ShipmGoodsOdrReport2.EmployeeCodeEd) resList.Add("EmployeeCodeEd");
            if (ShipmGoodsOdrReport1.GoodsMakerCdSt != ShipmGoodsOdrReport2.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (ShipmGoodsOdrReport1.GoodsMakerCdEd != ShipmGoodsOdrReport2.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (ShipmGoodsOdrReport1.GoodsLGroupSt != ShipmGoodsOdrReport2.GoodsLGroupSt) resList.Add("GoodsLGroupSt");
            if (ShipmGoodsOdrReport1.GoodsLGroupEd != ShipmGoodsOdrReport2.GoodsLGroupEd) resList.Add("GoodsLGroupEd");
            if (ShipmGoodsOdrReport1.GoodsMGroupSt != ShipmGoodsOdrReport2.GoodsMGroupSt) resList.Add("GoodsMGroupSt");
            if (ShipmGoodsOdrReport1.GoodsMGroupEd != ShipmGoodsOdrReport2.GoodsMGroupEd) resList.Add("GoodsMGroupEd");
            if (ShipmGoodsOdrReport1.BLGroupCodeSt != ShipmGoodsOdrReport2.BLGroupCodeSt) resList.Add("BLGroupCodeSt");
            if (ShipmGoodsOdrReport1.BLGroupCodeEd != ShipmGoodsOdrReport2.BLGroupCodeEd) resList.Add("BLGroupCodeEd");
            if (ShipmGoodsOdrReport1.BLGroupCodeAry != ShipmGoodsOdrReport2.BLGroupCodeAry) resList.Add("BLGroupCodeAry");
            if (ShipmGoodsOdrReport1.BLGoodsCodeSt != ShipmGoodsOdrReport2.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (ShipmGoodsOdrReport1.BLGoodsCodeEd != ShipmGoodsOdrReport2.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (ShipmGoodsOdrReport1.GoodsNoSt != ShipmGoodsOdrReport2.GoodsNoSt) resList.Add("GoodsNoSt");
            if (ShipmGoodsOdrReport1.GoodsNoEd != ShipmGoodsOdrReport2.GoodsNoEd) resList.Add("GoodsNoEd");
            if (ShipmGoodsOdrReport1.EnterpriseName != ShipmGoodsOdrReport2.EnterpriseName) resList.Add("EnterpriseName");
            if (ShipmGoodsOdrReport1.ConstUnit != ShipmGoodsOdrReport2.ConstUnit) resList.Add("ConstUnit");
            if (ShipmGoodsOdrReport1.CrMode != ShipmGoodsOdrReport2.CrMode) resList.Add("CrMode");
            if (ShipmGoodsOdrReport1.MoneyUnit != ShipmGoodsOdrReport2.MoneyUnit) resList.Add("MoneyUnit");
            if (ShipmGoodsOdrReport1.Order1 != ShipmGoodsOdrReport2.Order1) resList.Add("Order1");
            if (ShipmGoodsOdrReport1.Order2 != ShipmGoodsOdrReport2.Order2) resList.Add("Order2");
            if (ShipmGoodsOdrReport1.Order3 != ShipmGoodsOdrReport2.Order3) resList.Add("Order3");
            if (ShipmGoodsOdrReport1.PrintType != ShipmGoodsOdrReport2.PrintType) resList.Add("PrintType");
            if (ShipmGoodsOdrReport1.PrnSalesDateSt != ShipmGoodsOdrReport2.PrnSalesDateSt) resList.Add("PrnSalesDateSt");
            if (ShipmGoodsOdrReport1.PrnSalesDateEd != ShipmGoodsOdrReport2.PrnSalesDateEd) resList.Add("PrnSalesDateEd");
            if (ShipmGoodsOdrReport1.SalesOrderDivCd != ShipmGoodsOdrReport2.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (ShipmGoodsOdrReport1.SortItem != ShipmGoodsOdrReport2.SortItem) resList.Add("SortItem");
            if (ShipmGoodsOdrReport1.SubtotalBl != ShipmGoodsOdrReport2.SubtotalBl) resList.Add("SubtotalBl");
            if (ShipmGoodsOdrReport1.SubtotalCustomer != ShipmGoodsOdrReport2.SubtotalCustomer) resList.Add("SubtotalCustomer");
            if (ShipmGoodsOdrReport1.SubtotalGoodsLGroup != ShipmGoodsOdrReport2.SubtotalGoodsLGroup) resList.Add("SubtotalGoodsLGroup");
            if (ShipmGoodsOdrReport1.SubtotalGoodsMGroup != ShipmGoodsOdrReport2.SubtotalGoodsMGroup) resList.Add("SubtotalGoodsMGroup");
            if (ShipmGoodsOdrReport1.SubtotalGroupCode != ShipmGoodsOdrReport2.SubtotalGroupCode) resList.Add("SubtotalGroupCode");
            if (ShipmGoodsOdrReport1.SubtotalMaker != ShipmGoodsOdrReport2.SubtotalMaker) resList.Add("SubtotalMaker");
            if (ShipmGoodsOdrReport1.SubtotalSalesEmployee != ShipmGoodsOdrReport2.SubtotalSalesEmployee) resList.Add("SubtotalSalesEmployee");
            if (ShipmGoodsOdrReport1.SubtotalSection != ShipmGoodsOdrReport2.SubtotalSection) resList.Add("SubtotalSection");
            if (ShipmGoodsOdrReport1.SubtotalSupplier != ShipmGoodsOdrReport2.SubtotalSupplier) resList.Add("SubtotalSupplier");

            return resList;
        }
    }
}
