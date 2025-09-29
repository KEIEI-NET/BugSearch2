using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesTransListCndtn
    /// <summary>
    ///                      売上推移表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上推移表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/27  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/10/30 30462 行澤仁美　バグ修正</br>
    /// <br>Update Note 　　 : 　2009/04/15 張莉莉</br>
    /// <br>           　　   　・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note      :   2014/12/16 劉超</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :  ・明治産業様Seiken品番変更</br>
    /// <br>Update Note      :  2015/03/27 時シン</br>
    /// <br>管理番号         :  11070263-00</br>
    /// <br>                 :  Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
    public class SalesTransListCndtn
    {
        # region ■ private field ■

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点別集計区分</summary>
        /// <remarks>0:全社集計／1:拠点別集計</remarks>
        private TtlTypeState _ttlType;

        /// <summary>帳票集計区分</summary>
        /// <remarks>（予備項目）0:商品別／1:得意先別／2:担当者別</remarks>
        private TotalTypeState _totalType;

        /// <summary>計上拠点コード（複数指定）</summary>
        /// <remarks>（※配列）</remarks>
        private string[] _addUpSecCodes = new string[0];

        /// <summary>開始当期月</summary>
        /// <remarks>YYYYMM　当期計　算出範囲開始</remarks>
        private DateTime _st_ThisYearMonth;

        /// <summary>終了当期月</summary>
        /// <remarks>YYYYMM　当期計　算出範囲終了</remarks>
        private DateTime _ed_ThisYearMonth;

        /// <summary>在庫取寄区分</summary>
        /// <remarks>0:合計 1:在庫 2:取寄　（取寄＝合計ー在庫）</remarks>
        private StockOrderDivState _stockOrderDiv;

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>開始部門コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _st_SubSectionCode;

        ///// <summary>終了部門コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _ed_SubSectionCode;

        ///// <summary>開始課コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _st_MinSectionCode;

        ///// <summary>終了課コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _ed_MinSectionCode;
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// <summary>開始従業員コード</summary>
        private string _st_EmployeeCode = "";

        /// <summary>終了従業員コード</summary>
        private string _ed_EmployeeCode = "";

        /// <summary>開始得意先コード</summary>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCode;   // ADD 2009/04/15

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCode;   // ADD 2009/04/15

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>開始商品番号</summary>
        private string _st_GoodsNo = "";

        /// <summary>終了商品番号</summary>
        private string _ed_GoodsNo = "";

        /// <summary>開始ＢＬコード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了ＢＬコード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始商品大分類コード</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>終了商品大分類コード</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>開始商品中分類コード</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>開始グループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了グループコード</summary>
        private Int32 _ed_BLGroupCode;

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>開始自社分類コード</summary>
        ///// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        //private Int32 _st_EnterpriseGanreCode;

        ///// <summary>終了自社分類コード</summary>
        ///// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        //private Int32 _ed_EnterpriseGanreCode;
        
        ///// <summary>開始仕入先コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _st_SupplierCd;

        ///// <summary>終了仕入先コード</summary>
        ///// <remarks>（予備項目）</remarks>
        //private Int32 _ed_SupplierCd;
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// <summary>開始出荷数</summary>
        /// <remarks>（ＵＩ制御項目）</remarks>
        private Int32 _st_ShipmentCnt;

        /// <summary>終了出荷数</summary>
        /// <remarks>（ＵＩ制御項目）</remarks>
        private Int32 _ed_ShipmentCnt;

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// <summary>開始出荷数未入力フラグ</summary>
        private bool _st_ShipmentCntNoInputFlg;

        /// <summary>終了出荷数未入力フラグ</summary>
        private bool _ed_ShipmentCntNoInputFlg;
        // --- ADD 2009/02/10 --------------------------------<<<<<

        /// <summary>金額単位区分</summary>
        /// <remarks>（ＵＩ制御項目）0:円／1:千円</remarks>
        private PriceUnitDivState _priceUnitDiv;

        /// <summary>改ページ区分</summary>
        /// <remarks>（ＵＩ制御項目）0:拠点／1:メーカー／2:得意先／3:担当者／4:しない／5:仕入先</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>ＢＬコード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _bLGoodsCodeSumPrintDiv;

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// <summary>自社分類計印字区分</summary>
        ///// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        //private SumPrintDivState _enterpriseGanreSumPrintDiv;
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// <summary>グループコード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _bLGroupCodeSumPrintDiv;

        /// <summary>商品中分類計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _goodsMGroupSumPrintDiv;

        /// <summary>商品大分類計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _goodsLGroupSumPrintDiv;

        /// <summary>メーカー計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _makerSumPrintDiv;

        /// <summary>得意先計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _customerSumPrintDiv;

        /// <summary>担当者計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _employeeSumPrintDiv;

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>拠点コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _sectionSumPrintDiv;
        // --- ADD 2008/10/16 --------------------------------<<<<<

        // --- ADD 2009/04/15 -------------------------------->>>>>
        /// <summary>仕入先コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _supplierSumPrintDiv;
        // --- ADD 2009/04/15 --------------------------------<<<<<

        /// <summary>印刷タイプ</summary>
        /// <remarks>（ＵＩ制御項目）0:金額＆数量／1:金額／2:数量</remarks>
        private PrintTypeDivState _printTypeDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>メーカー別印刷区分</summary>
        private MakerPrintDivState _makerPrintDiv;

        /// <summary>明細単位(リモート抽出条件用)</summary>
        /// <remarks>
        /// ・商品別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：拠点
        /// ・得意先別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：得意先　7：拠点
        /// ・担当者別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：担当者　7：拠点
        /// ・仕入先別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：仕入先　7：拠点
        /// </remarks>
        private Int32 _detail;

        /// <summary>明細単位（ＵＩ処理用）</summary>
        /// <remarks>0：品番 1：BLコード 2：グループコード 3：商品中分類 4：商品大分類 5：メーカー 6：拠点 7:得意先 8:担当者</remarks>
        private DetailDataValueState _detailDataValue;
        // --- ADD 2008/10/16 --------------------------------<<<<<
        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>（ＵＩ制御項目）0:別々／1:合算</remarks>
        private GoodsNoTtlDivState _goodsNoTtlDiv;
        /// <summary>品番表示区分</summary>
        /// <remarks>（ＵＩ制御項目）0:新品番／1:旧品番</remarks>
        private GoodsNoShowDivState _goodsNoShowDiv;
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        # endregion  ■ private field ■

        # region ■ public propaty ■

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

        /// public propaty name  :  TtlType
        /// <summary>拠点別集計区分プロパティ</summary>
        /// <value>0:全社集計／1:拠点別集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点別集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TtlTypeState TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }

        /// public propaty name  :  totalType
        /// <summary>帳票集計区分プロパティ</summary>
        /// <value>（予備項目）0:商品別／1:得意先別／2:担当者別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TotalTypeState TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  AddUpSecCodes
        /// <summary>計上拠点コード（複数指定）プロパティ</summary>
        /// <value>（※配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] AddUpSecCodes
        {
            get { return _addUpSecCodes; }
            set { _addUpSecCodes = value; }
        }

        // --- ADD 2009/04/15 --------------------------->>>>>
        /// public propaty name  :  St_SupplierCode
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCode
        {
            get { return _st_SupplierCode; }
            set { _st_SupplierCode = value; }
        }

        /// public propaty name  :  Ed_SupplierCode
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCode
        {
            get { return _ed_SupplierCode; }
            set { _ed_SupplierCode = value; }
        }
        // --- ADD 2009/04/15 --------------------------<<<<<


        /// public propaty name  :  St_ThisYearMonth
        /// <summary>開始当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲開始</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ThisYearMonth
        {
            get { return _st_ThisYearMonth; }
            set { _st_ThisYearMonth = value; }
        }

        /// public propaty name  :  Ed_ThisYearMonth
        /// <summary>終了当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ThisYearMonth
        {
            get { return _ed_ThisYearMonth; }
            set { _ed_ThisYearMonth = value; }
        }

        /// public propaty name  :  StockOrderDiv
        /// <summary>在庫取寄区分プロパティ</summary>
        /// <value>0:合計 1:在庫 2:取寄　（取寄＝合計ー在庫）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockOrderDivState StockOrderDiv
        {
            get { return _stockOrderDiv; }
            set { _stockOrderDiv = value; }
        }

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// public propaty name  :  St_SubSectionCode
        ///// <summary>開始部門コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始部門コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_SubSectionCode
        //{
        //    get { return _st_SubSectionCode; }
        //    set { _st_SubSectionCode = value; }
        //}

        ///// public propaty name  :  Ed_SubSectionCode
        ///// <summary>終了部門コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了部門コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_SubSectionCode
        //{
        //    get { return _ed_SubSectionCode; }
        //    set { _ed_SubSectionCode = value; }
        //}
        
        ///// public propaty name  :  St_MinSectionCode
        ///// <summary>開始課コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始課コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_MinSectionCode
        //{
        //    get { return _st_MinSectionCode; }
        //    set { _st_MinSectionCode = value; }
        //}

        ///// public propaty name  :  Ed_MinSectionCode
        ///// <summary>終了課コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了課コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_MinSectionCode
        //{
        //    get { return _ed_MinSectionCode; }
        //    set { _ed_MinSectionCode = value; }
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// public propaty name  :  St_EmployeeCode
        /// <summary>開始従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>終了従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>開始品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>終了品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_goodsLGroup
        /// <summary>開始商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_goodsLGroup
        /// <summary>終了商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_goodsMGroup
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_goodsMGroup
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// public propaty name  :  St_EnterpriseGanreCode
        ///// <summary>開始自社分類コードプロパティ</summary>
        ///// <value>1～899:提供分, 900～ユーザー登録</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始自社分類コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_EnterpriseGanreCode
        //{
        //    get { return _st_EnterpriseGanreCode; }
        //    set { _st_EnterpriseGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_EnterpriseGanreCode
        ///// <summary>終了自社分類コードプロパティ</summary>
        ///// <value>1～899:提供分, 900～ユーザー登録</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了自社分類コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_EnterpriseGanreCode
        //{
        //    get { return _ed_EnterpriseGanreCode; }
        //    set { _ed_EnterpriseGanreCode = value; }
        //}
        
        ///// public propaty name  :  St_SupplierCd
        ///// <summary>開始仕入先コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始仕入先コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_SupplierCd
        //{
        //    get { return _st_SupplierCd; }
        //    set { _st_SupplierCd = value; }
        //}

        ///// public propaty name  :  Ed_SupplierCd
        ///// <summary>終了仕入先コードプロパティ</summary>
        ///// <value>（予備項目）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了仕入先コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_SupplierCd
        //{
        //    get { return _ed_SupplierCd; }
        //    set { _ed_SupplierCd = value; }
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// public propaty name  :  St_ShipmentCnt
        /// <summary>開始出荷数プロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_ShipmentCnt
        {
            get { return _st_ShipmentCnt; }
            set { _st_ShipmentCnt = value; }
        }

        /// public propaty name  :  Ed_ShipmentCnt
        /// <summary>終了出荷数プロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_ShipmentCnt
        {
            get { return _ed_ShipmentCnt; }
            set { _ed_ShipmentCnt = value; }
        }

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// public propaty name  :  St_ShipmentCntNoInputFlg
        /// <summary>開始出荷数未入力フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷数未入力フラグプロパティ</br>
        /// </remarks>
        public bool St_ShipmentCntNoInputFlg
        {
            get { return _st_ShipmentCntNoInputFlg; }
            set { _st_ShipmentCntNoInputFlg = value; }
        }

        /// public propaty name  :  Ed_ShipmentCntNoInputFlg
        /// <summary>終了出荷数未入力フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了出荷数未入力フラグプロパティ</br>
        /// </remarks>
        public bool Ed_ShipmentCntNoInputFlg
        {
            get { return _ed_ShipmentCntNoInputFlg; }
            set { _ed_ShipmentCntNoInputFlg = value; }
        }
        // --- ADD 2009/02/10 --------------------------------<<<<<

        /// public propaty name  :  PriceUnitDiv
        /// <summary>金額単位区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:円／1:千円</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額単位区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceUnitDivState PriceUnitDiv
        {
            get { return _priceUnitDiv; }
            set { _priceUnitDiv = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>改ページ区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:営業所／1:メーカー／2:得意先／3:担当者／4:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改ページ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NewPageDivState NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  BLGoodsCodeSumPrintDiv
        /// <summary>ＢＬコード計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコード計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState BLGoodsCodeSumPrintDiv
        {
            get { return _bLGoodsCodeSumPrintDiv; }
            set { _bLGoodsCodeSumPrintDiv = value; }
        }

        // --- DEL 2008/10/16 -------------------------------->>>>>
        ///// public propaty name  :  EnterpriseGanreSumPrintDiv
        ///// <summary>自社分類計印字区分プロパティ</summary>
        ///// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   自社分類計印字区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public SumPrintDivState EnterpriseGanreSumPrintDiv
        //{
        //    get { return _enterpriseGanreSumPrintDiv; }
        //    set { _enterpriseGanreSumPrintDiv = value; }
        //}
        // --- DEL 2008/10/16 --------------------------------<<<<<

        /// public propaty name  :  BLGroupCodeSumPrintDiv
        /// <summary>商品区分詳細計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分詳細計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState BLGroupCodeSumPrintDiv
        {
            get { return _bLGroupCodeSumPrintDiv; }
            set { _bLGroupCodeSumPrintDiv = value; }
        }

        /// public propaty name  :  GoodsMGroupSumPrintDiv
        /// <summary>商品区分計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState GoodsMGroupSumPrintDiv
        {
            get { return _goodsMGroupSumPrintDiv; }
            set { _goodsMGroupSumPrintDiv = value; }
        }

        /// public propaty name  :  GoodsLGroupSumPrintDiv
        /// <summary>商品区分グループ計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品区分グループ計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState GoodsLGroupSumPrintDiv
        {
            get { return _goodsLGroupSumPrintDiv; }
            set { _goodsLGroupSumPrintDiv = value; }
        }

        /// public propaty name  :  MakerSumPrintDiv
        /// <summary>メーカー計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState MakerSumPrintDiv
        {
            get { return _makerSumPrintDiv; }
            set { _makerSumPrintDiv = value; }
        }

        /// public propaty name  :  CustomerSumPrintDiv
        /// <summary>得意先計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState CustomerSumPrintDiv
        {
            get { return _customerSumPrintDiv; }
            set { _customerSumPrintDiv = value; }
        }

        // --- ADD 2009/04/15 ------------------->>>>>
        /// public propaty name  :  SupplierSumPrintDiv
        /// <summary>仕入先計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState SupplierSumPrintDiv
        {
            get { return _supplierSumPrintDiv; }
            set { _supplierSumPrintDiv = value; }
        }
        // --- ADD 2009/04/15 ------------------<<<<<

        /// public propaty name  :  EmployeeSumPrintDiv
        /// <summary>担当者計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState EmployeeSumPrintDiv
        {
            get { return _employeeSumPrintDiv; }
            set { _employeeSumPrintDiv = value; }
        }

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// public propaty name  :  SectionSumPrintDiv
        /// <summary>拠点コード計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState SectionSumPrintDiv
        {
            get { return _sectionSumPrintDiv; }
            set { _sectionSumPrintDiv = value; }
        }
        // --- ADD 2008/10/16 --------------------------------<<<<<

        /// public propaty name  :  PrintTypeDiv
        /// <summary>印字タイププロパティ</summary>
        /// <value>（ＵＩ制御項目）0:金額＆数量 1:金額 2:数量</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrintTypeDivState PrintTypeDiv
        {
            get { return _printTypeDiv; }
            set { _printTypeDiv = value; }
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

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// public propaty name  :  MakerPrintDiv
        /// <summary>メーカー別印刷プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー別印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MakerPrintDivState MakerPrintDiv
        {
            get { return _makerPrintDiv; }
            set { _makerPrintDiv = value; }
        }

        /// public propaty name  :  Detail
        /// <summary>明細単位（リモート抽出条件用）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細単位（リモート抽出条件用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        /// public propaty name  :  DetailDataValue
        /// <summary>明細単位（制御用）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細単位（制御用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DetailDataValueState DetailDataValue
        {
            get { return _detailDataValue; }
            set { _detailDataValue = value; }
        }
        // --- ADD 2008/10/16 --------------------------------<<<<<

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>品番集計区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsNoTtlDivState GoodsNoTtlDiv
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
        public GoodsNoShowDivState GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;

        // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
        /// <summary>
        /// 得意先入力区分
        /// </summary>
        private bool _set_CustomerCode = false;
        /// <summary>
        /// 仕入先入力区分
        /// </summary>
        private bool _set_SupplierCode = false;   // ADD 2009/04/15
        /// <summary>
        /// 担当者入力区分
        /// </summary>
        private bool _set_EmployeeCode = false;
        /// <summary>
        /// メーカー入力区分
        /// </summary>
        private bool _set_GoodsMakerCd = false;
        /// <summary>
        /// 商品大分類入力区分
        /// </summary>
        private bool _set_GoodsLGroup = false;
        /// <summary>
        /// 商品中分類入力区分
        /// </summary>
        private bool _set_GoodsMGroup = false;
        /// <summary>
        /// グループコード入力区分
        /// </summary>
        private bool _set_BLGloupCode = false;
        /// <summary>
        /// BLｺｰﾄﾞ入力区分
        /// </summary>
        private bool _set_BLGoodsCode = false;
        // ADD 2008/10/30 不具合対応[7203] ----------<<<<<
        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        /// <summary>
        /// 拠点別集計区分　名称取得
        /// </summary>
        public string TtlTypeName
        {
            get
            {
                switch ( this._ttlType )
                {
                    case TtlTypeState.All:
                        return ct_TtlTypeState_All;
                    case TtlTypeState.BySection:
                        return ct_TtlTypeState_BySection;
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 帳票集計区分　名称取得
        /// </summary>
        public string TotalTypeName
        {
            get
            {
                switch ( this._totalType )
                {
                    case TotalTypeState.EachGoods:
                        return ct_TotalTypeState_EachGoods;
                    case TotalTypeState.EachCustomer:
                        return ct_TotalTypeState_EachCustomer;
                    case TotalTypeState.EachEmployee:
                        return ct_TotalTypeState_EachEmployee;
                    case TotalTypeState.EachSupplier:       // ADD 2009/04/15
                        return ct_TotalTypeState_EachSupplier;
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 在庫取寄区分　名称取得
        /// </summary>
        public string StockOrderDivName
        {
            get
            {
                switch ( this._stockOrderDiv )
                {
                    case StockOrderDivState.Sum:
                        return ct_StockOrderDivState_Sum;
                    case StockOrderDivState.Stock:
                        return ct_StockOrderDivState_Stock;
                    case StockOrderDivState.Order:
                        return ct_StockOrderDivState_Order;
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 金額単位区分　名称取得
        /// </summary>
        public string PriceUnitDivName
        {
            get
            {
                switch ( this._priceUnitDiv )
                {
                    case PriceUnitDivState.One:
                        return ct_PriceUnitDivState_One;                        
                    case PriceUnitDivState.Thousand:
                        return ct_PriceUnitDivState_Thousand;
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 印刷タイプ区分　名称取得
        /// </summary>
        public string PrintTypeDivName
        {
            get
            {
                switch ( this._printTypeDiv )
                {
                    case PrintTypeDivState.PriceAndCount:
                        return ct_PrintTypeDivState_PriceAndCount;
                    case PrintTypeDivState.PriceOnly:
                        return ct_PrintTypeDivState_PriceOnly;
                    case PrintTypeDivState.CountOnly:
                        return ct_PrintTypeDivState_CountOnly;
                    default:
                        return string.Empty;
                }
            }
        }

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>
        /// メーカー別印刷　名称取得
        /// </summary>
        public string MakerPrintDivName
        {
            get
            {
                switch (this._makerPrintDiv)
                {
                    case MakerPrintDivState.Print:
                        return ct_Common_Do;
                    case MakerPrintDivState.None:
                        return ct_Common_None;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 改頁　名称取得
        /// </summary>
        public string NewPageDivName
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.None:
                        return ct_NewPageDivState_None;
                    case NewPageDivState.EachSection:
                        return ct_NewPageDivState_EachSection;
                    case NewPageDivState.EachMaker:
                        return ct_NewPageDivState_EachMaker;
                    case NewPageDivState.EachCustomer:
                        return ct_NewPageDivState_EachCustomer;
                    case NewPageDivState.EachEmployee:
                        return ct_NewPageDivState_EachEmployee;
                    case NewPageDivState.EachSupplier:          // ADD 2009/04/15
                        return ct_NewPageDivState_EachSupplier;
                    default:
                        return string.Empty;
                }
            }
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分　名称取得
        /// </summary>
        public string GoodsNoTtlDivName
        {
            get
            {
                switch (this._goodsNoTtlDiv)
                {
                    case GoodsNoTtlDivState.Together:
                        return ct_GoodsNoTtlDivState_Together;
                    case GoodsNoTtlDivState.Either:
                        return ct_GoodsNoTtlDivState_Either;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 品番表示区分　名称取得
        /// </summary>
        public string GoodsNoShowDivName
        {
            get
            {
                switch (this._goodsNoShowDiv)
                {
                    case GoodsNoShowDivState.NewGoodsNo:
                        return ct_GoodsNoShowDivState_NewGoodsNo;
                    case GoodsNoShowDivState.OldGoodsNo:
                        return ct_GoodsNoShowDivState_OldGoodsNo;
                    default:
                        return string.Empty;
                }
            }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>
        /// 明細単位　名称取得
        /// </summary>
        public string DetailDataValueName
        {
            get
            {
                switch (this._detailDataValue)
                {
                    case DetailDataValueState.GoosNo:
                        return ct_DetailDataValue_GoosNo;
                    case DetailDataValueState.BLGoodsCode:
                        return ct_DetailDataValue_BLGoodsCode;
                    case DetailDataValueState.BLGroupCode:
                        return ct_DetailDataValue_BLGroupCode;
                    case DetailDataValueState.GoodsMGroup:
                        return ct_DetailDataValue_GoodsMGroup;
                    case DetailDataValueState.GoodsLGroup:
                        return ct_DetailDataValue_GoodsLGroup;
                    case DetailDataValueState.GoodsMaker:
                        return ct_DetailDataValue_GoodsMaker;
                    case DetailDataValueState.Section:
                        return ct_DetailDataValue_Section;
                    case DetailDataValueState.Customer:
                        return ct_DetailDataValue_Customer;
                    case DetailDataValueState.Employee:
                        return ct_DetailDataValue_Employee;
                    case DetailDataValueState.Supplier:      // ADD 2009/04/15
                        return ct_DetailDataValue_Supplier;
                    default:
                        return string.Empty;
                }
            }
        }
        // --- ADD 2008/10/16 --------------------------------<<<<<

        // ADD 2008/10/30 不具合対応[7203] ---------->>>>>
        /// <summary>
        /// 得意先入力区分プロパティ
        /// </summary>
        public bool Set_CustomerCode
        {
            get { return this._set_CustomerCode; }
            set { this._set_CustomerCode = value; }
        }

        // --- ADD 2009/04/15 ---------------------->>>>>
        /// <summary>
        /// 仕入先入力区分プロパティ
        /// </summary>
        public bool Set_SupplierCode
        {
            get { return this._set_SupplierCode; }
            set { this._set_SupplierCode = value; }
        }
        // --- ADD 2009/04/15 ----------------------<<<<<

        /// <summary>
        /// 担当者入力区分プロパティ
        /// </summary>
        public bool Set_EmployeeCode
        {
            get { return this._set_EmployeeCode; }
            set { this._set_EmployeeCode = value; }
        }
        /// <summary>
        /// メーカー入力区分プロパティ
        /// </summary>
        public bool Set_GoodsMakerCd
        {
            get { return this._set_GoodsMakerCd; }
            set { this._set_GoodsMakerCd = value; }
        }
        /// <summary>
        /// 商品大分類入力区分プロパティ
        /// </summary>
        public bool Set_GoodsLGroup
        {
            get { return this._set_GoodsLGroup; }
            set { this._set_GoodsLGroup = value; }
        }
        /// <summary>
        /// 商品中分類入力区分プロパティ
        /// </summary>
        public bool Set_GoodsMGroup
        {
            get { return this._set_GoodsMGroup; }
            set { this._set_GoodsMGroup = value; }
        }
        /// <summary>
        /// グループコード入力区分プロパティ
        /// </summary>
        public bool Set_BLGloupCode
        {
            get { return this._set_BLGloupCode; }
            set { this._set_BLGloupCode = value; }
        }
        /// <summary>
        /// BLｺｰﾄﾞ入力区分プロパティ
        /// </summary>
        public bool Set_BLGoodsCode
        {
            get { return this._set_BLGoodsCode; }
            set { this._set_BLGoodsCode = value; }
        }		

        // ADD 2008/10/30 不具合対応[7203] ----------<<<<<
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 拠点別集計区分　列挙型
        /// </summary>
        public enum TtlTypeState
        {
            /// <summary>全社</summary>
            All = 0,
            /// <summary>拠点毎</summary>
            BySection = 1,
        }
        /// <summary>
        /// 帳票集計区分　列挙型
        /// </summary>
        public enum TotalTypeState
        {
            /// <summary>商品</summary>
            EachGoods = 0,
            /// <summary>得意先別</summary>
            EachCustomer = 1,
            /// <summary>担当者別</summary>
            EachEmployee = 2,
            /// <summary>仕入先別</summary>
            EachSupplier = 3,            // ADD 2009/04/15

        }
        /// <summary>
        /// 在庫取寄区分　列挙型
        /// </summary>
        public enum StockOrderDivState
        {
            /// <summary>合計</summary>
            Sum = 0,
            /// <summary>在庫</summary>
            Stock = 1,
            /// <summary>取寄</summary>
            Order = 2,
        }
        /// <summary>
        /// 金額単位区分　列挙型
        /// </summary>
        public enum PriceUnitDivState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1,
        }
        /// <summary>
        /// 改ページ区分　列挙型
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>改ページしない</summary>
            None = 4,
            /// <summary>拠点毎</summary>
            EachSection = 0,
            /// <summary>メーカー毎</summary>
            EachMaker = 1,
            /// <summary>得意先毎</summary>
            EachCustomer = 2,
            /// <summary>担当者毎</summary>
            EachEmployee = 3,
            /// <summary>仕入先毎</summary>
            EachSupplier = 5,
        }
        /// <summary>
        /// 計印字区分　列挙型
        /// </summary>
        public enum SumPrintDivState
        {
            /// <summary>計印字しない</summary>
            None = 0,
            /// <summary>計印字する</summary>
            Print = 1,
        }
        /// <summary>
        /// 印刷タイプ区分　列挙型
        /// </summary>
        public enum PrintTypeDivState
        {
            /// <summary>金額＆数量</summary>
            PriceAndCount = 0,
            /// <summary>金額</summary>
            PriceOnly = 1,
            /// <summary>数量</summary>
            CountOnly = 2,
        }

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>
        /// メーカー別印刷　列挙型
        /// </summary>
        public enum MakerPrintDivState
        {
            /// <summary>印字する</summary>
            Print = 1,
            /// <summary>印字しない</summary>
            None = 0,
        }

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>
        /// 品番集計区分　列挙型
        /// </summary>
        public enum GoodsNoTtlDivState
        {
            /// <summary>合算</summary>
            Together = 1,
            /// <summary>別々</summary>
            Either = 0,
        }

        /// <summary>
        /// 品番表示区分　列挙型
        /// </summary>
        public enum GoodsNoShowDivState
        {
            /// <summary>旧品番</summary>
            OldGoodsNo = 1,
            /// <summary>新品番</summary>
            NewGoodsNo = 0,
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        /// <summary>
        /// 明細単位（制御用）　列挙型
        /// </summary>
        public enum DetailDataValueState
        {
            /// <summary>品番</summary>
            GoosNo = 0,
            /// <summary>ＢＬコード</summary>
            BLGoodsCode = 1,
            /// <summary>グループコード</summary>
            BLGroupCode = 2,
            /// <summary>商品中分類</summary>
            GoodsMGroup = 3,
            /// <summary>商品大分類</summary>
            GoodsLGroup = 4,
            /// <summary>メーカー</summary>
            GoodsMaker = 5,
            /// <summary>拠点</summary>
            Section = 6,
            /// <summary>得意先</summary>
            Customer = 7,
            /// <summary>担当者</summary>
            Employee = 8,
            /// <summary>仕入先</summary>
            Supplier = 9,　　　// ADD 2009/04/15

        }
        // --- ADD 2008/10/16 --------------------------------<<<<<
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>集計方法　全社集計</summary>
        public const string ct_TtlTypeState_All = "全社集計";
        /// <summary>集計方法　拠点別</summary>
        public const string ct_TtlTypeState_BySection = "拠点別";

        /// <summary>帳票集計区分　商品別</summary>
        public const string ct_TotalTypeState_EachGoods = "商品別";
        /// <summary>帳票集計区分　得意先別</summary>
        public const string ct_TotalTypeState_EachCustomer = "得意先別";
        /// <summary>帳票集計区分　担当者別</summary>
        public const string ct_TotalTypeState_EachEmployee = "担当者別";
        /// <summary>帳票集計区分　仕入先別</summary>
        public const string ct_TotalTypeState_EachSupplier = "仕入先別";  // ADD 2009/04/15

        /// <summary>在庫取寄指定区分　合計</summary>
        public const string ct_StockOrderDivState_Sum = "合計";
        /// <summary>在庫取寄指定区分　在庫</summary>
        public const string ct_StockOrderDivState_Stock = "在庫";
        /// <summary>在庫取寄指定区分　取寄</summary>
        public const string ct_StockOrderDivState_Order = "取寄";

        /// <summary>金額単位　円</summary>
        public const string ct_PriceUnitDivState_One = "円";
        /// <summary>金額単位　千円</summary>
        public const string ct_PriceUnitDivState_Thousand = "千円";

        /// <summary>改ページ区分　しない</summary>
        public const string ct_NewPageDivState_None = "しない";
        /// <summary>改ページ区分　拠点毎</summary>
        public const string ct_NewPageDivState_EachSection = "拠点毎";
        /// <summary>改ページ区分　メーカー毎</summary>
        public const string ct_NewPageDivState_EachMaker = "メーカー毎";
        /// <summary>改ページ区分　得意先毎</summary>
        public const string ct_NewPageDivState_EachCustomer = "得意先毎";
        /// <summary>改ページ区分　担当者毎</summary>
        public const string ct_NewPageDivState_EachEmployee = "担当者毎";
        /// <summary>改ページ区分　仕入先毎</summary>
        public const string ct_NewPageDivState_EachSupplier = "仕入先毎";  // ADD 2009/04/15

        /// <summary>計印字区分　しない</summary>
        public const string ct_SumPrintDivState_None = "しない";
        /// <summary>計印字区分　する</summary>
        public const string ct_SumPrintDivState_Print = "する";

        /// <summary>印刷タイプ区分　金額＆数量</summary>
        public const string ct_PrintTypeDivState_PriceAndCount = "上段：金額／下段：数量";
        /// <summary>印刷タイプ区分　金額</summary>
        public const string ct_PrintTypeDivState_PriceOnly = "金額";
        /// <summary>印刷タイプ区分　数量</summary>
        public const string ct_PrintTypeDivState_CountOnly = "数量";

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分　別々</summary>
        //public const string ct_GoodsNoTtlDivState_Either = "別々";// DEL 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        public const string ct_GoodsNoTtlDivState_Either = "通常";// ADD 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        /// <summary>品番集計区分　合算</summary>
        public const string ct_GoodsNoTtlDivState_Together = "合算";

        /// <summary>品番表示区分　新品番</summary>
        public const string ct_GoodsNoShowDivState_NewGoodsNo = "新品番";
        /// <summary>品番表示区分　旧品番</summary>
        public const string ct_GoodsNoShowDivState_OldGoodsNo = "旧品番";
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

        // --- ADD 2008/10/16 -------------------------------->>>>>
        /// <summary>明細単位　品番</summary>
        public const string ct_DetailDataValue_GoosNo = "品番";
        /// <summary>明細単位　ＢＬコード</summary>
        public const string ct_DetailDataValue_BLGoodsCode = "ＢＬコード";
        /// <summary>明細単位　グループコード</summary>
        public const string ct_DetailDataValue_BLGroupCode = "グループコード";
        /// <summary>明細単位　商品中分類</summary>
        public const string ct_DetailDataValue_GoodsMGroup = "商品中分類";
        /// <summary>明細単位　商品大分類</summary>
        public const string ct_DetailDataValue_GoodsLGroup = "商品大分類";
        /// <summary>明細単位　メーカー</summary>
        public const string ct_DetailDataValue_GoodsMaker = "メーカー";
        /// <summary>明細単位　拠点</summary>
        public const string ct_DetailDataValue_Section = "拠点";
        /// <summary>明細単位　得意先</summary>
        public const string ct_DetailDataValue_Customer = "得意先";
        /// <summary>明細単位　担当者</summary>
        public const string ct_DetailDataValue_Employee = "担当者";
        /// <summary>明細単位　仕入先</summary>
        public const string ct_DetailDataValue_Supplier = "仕入先";   // ADD 2009/04/15

        /// <summary>共通名称 する</summary>
        public const string ct_Common_Do = "する";
        /// <summary>共通名称 しない</summary>
        public const string ct_Common_None = "しない";
        // --- ADD 2008/10/16 --------------------------------<<<<<

        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 売上実績表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SalesRsltListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesRsltListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesTransListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}
