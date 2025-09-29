using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesRsltListCndtn
    /// <summary>
    ///                      売上実績表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上実績表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note　　　: 2009.04.11 張莉莉</br>
    /// <br>            　　　・売上実績表（仕入先別）の追加</br>
    /// <br>Update Note      : 2014/12/16 李 侠</br>
    /// <br>管理番号         : 11070263-00</br>
    /// <br>                 : 明治産業様Seiken品番変更</br>
    /// <br>Update Note      : 2015/03/27 時シン</br>
    /// <br>管理番号         : 11070263-00</br>
    /// <br>                 : Redmine#44209の#423品番集計区分の名称変更</br>
    /// </remarks>
    public class SalesRsltListCndtn
    {
        # region ■ private field ■

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>集計単位</summary>
        /// <remarks>0:商品別 1:得意先別 2:担当者別 3:倉庫別 4:仕入先別</remarks>
        private TotalTypeState _totalType;

        /// <summary>拠点別集計区分</summary>
        /// <remarks>0:全社 1:拠点毎</remarks>
        private TtlTypeState _ttlType;

        /// <summary>出荷指定区分</summary>
        /// <remarks>0:当月(当期) 1:当期</remarks>
        private PrintRangeDivState _printRangeDiv;

        /// <summary>在庫取寄せ区分</summary>
        /// <remarks>0:合計 1:在庫, 2:取寄せ</remarks>
        private RsltTtlDivCdState _rsltTtlDivCd;

        /// <summary>当期印刷</summary>
        /// <remarks>0:しない 1:する</remarks>
        private AnnualPrintDivState _annualPrintDiv;

        /// <summary>メーカー別印刷</summary>
        /// <remarks>0:しない 1:する</remarks>
        private MakerPrintDivState _makerPrintDiv;

        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private GoodsNoSumState _goodsNoSumDiv;

        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private GoodsNoDisState _goodsNoDisDiv;
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<

        /// <summary>明細単位(リモート抽出条件用)</summary>
        /// <remarks>
        /// ・商品別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：拠点
        /// ・得意先別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：得意先　7：拠点
        /// ・担当者別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：担当者　7：拠点
        /// ・仕入先別   // ADD 2009/04/11
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：仕入先　7：拠点 
        /// ・倉庫別
        /// 　発行タイプ－拠点別倉庫別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：拠点　7：倉庫
        /// 　発行タイプ－倉庫別得意先別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：得意先　7：倉庫
        /// 　発行タイプ－倉庫別拠点別
        /// 　0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：倉庫　7：拠点
        /// </remarks>
        private Int32 _detail;

        /// <summary>明細単位（制御処理用）</summary>
        /// <remarks>0：品番 1：BLコード 2：グループコード 3：商品中分類 4：商品大分類 5：メーカー 6：拠点 7:得意先 8:担当者 9:倉庫 10:仕入先</remarks>
        private DetailDataValueState _detailDataValue;

        /// <summary>発行タイプ</summary>
        /// <remarks>0:拠点別倉庫別 1:倉庫別得意先別 2:倉庫別拠点別</remarks>
        private PrintTypeState _printType;

        /// <summary>開始対象年月(当月)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthSt;

        /// <summary>終了対象年月(当月)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthEd;

        /// <summary>開始対象年月(当期)</summary>
        /// <remarks>YYYYMM(期首月)</remarks>
        private DateTime _annualAddUpYearMonthSt;

        /// <summary>終了対象年月(当期)</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _annualAddUpYaerMonthEd;

        /// <summary>開始対象期間(期間)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>終了対象期間(期間)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>開始対象期間(当期)</summary>
        /// <remarks>YYYYMMDD(期首月)</remarks>
        private DateTime _annualSalesDateSt;

        /// <summary>終了対象期間(当期)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _annualSalesDateEd;

        /// <summary>開始出荷数指定</summary>
        private Int32 _printRangeSt;

        /// <summary>終了出荷範囲指定</summary>
        private Int32 _printRangeEd;

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// <summary>開始出荷数未入力フラグ</summary>
        private bool _printRangeStNoInputFlg;

        /// <summary>終了出荷数未入力フラグ</summary>
        private bool _printRangeEdNoInputFlg;
        // --- ADD 2009/02/10 --------------------------------<<<<<

        // --- DEL 2008/10/08 -------------------------------->>>>>
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
        // --- DEL 2008/10/08 --------------------------------<<<<<

        /// <summary>開始得意先コード</summary>
        private Int32 _customerCodeSt;

        /// <summary>終了得意先コード</summary>
        private Int32 _customerCodeEd;

        // --- ADD 2009/04/11------------------------->>>>>
        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCodeSt;

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCodeEd;
        // --- ADD 2009/04/11-------------------------<<<<<

        /// <summary>開始従業員コード</summary>
        private string _employeeCodeSt = "";

        /// <summary>終了従業員コード</summary>
        private string _employeeCodeEd = "";

        /// <summary>開始倉庫コード</summary>
        private string _warehouseCodeSt = "";

        /// <summary>終了倉庫コード</summary>
        private string _warehouseCodeEd = "";

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

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>開始品番</summary>
        private string _goodsNoSt = "";

        /// <summary>終了品番</summary>
        private string _goodsNoEd = "";

        // --- DEL 2008/10/08 -------------------------------->>>>>
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
        // --- DEL 2008/10/08 --------------------------------<<<<<

        /// <summary>金額単位区分</summary>
        /// <remarks>（ＵＩ制御項目）0:円／1:千円</remarks>
        private PriceUnitDivState _priceUnitDiv;

        /// <summary>改ページ区分</summary>
        /// <remarks>（ＵＩ制御項目）0:拠点/1:メーカー/2:得意先/3:担当者/4:倉庫/5:しない/6:仕入先</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>拠点コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _sectionSumPrintDiv;

        /// <summary>倉庫コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _warehouseSumPrintDiv;

        /// <summary>得意先コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _customerSumPrintDiv;

        // --- ADD 2009/04/11------------------------->>>>>
        /// <summary>仕入先コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _supplierSumPrintDiv;
        // --- ADD 2009/04/11-------------------------<<<<<

        /// <summary>担当者コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _employeeSumPrintDiv;

        /// <summary>メーカー計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _makerSumPrintDiv;

        /// <summary>商品大分類計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _goodsLGroupSumPrintDiv;

        /// <summary>商品中分類計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _goodsMGroupSumPrintDiv;

        /// <summary>グループコード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState bLGroupCodeSumPrintDiv;

        /// <summary>ＢＬコード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SumPrintDivState _bLGoodsCodeSumPrintDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  SectionCodes
        /// <summary>計上拠点コード（複数指定）プロパティ</summary>
        /// <value>（※配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コード（複数指定）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  TotalType
        /// <summary>帳票集計区分プロパティ</summary>
        /// <value>0:商品別／1:得意先別／2:担当者別／3:倉庫別</value>
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

        /// public propaty name  :  PrintRangeDiv
        /// <summary>出荷指定区分プロパティ</summary>
        /// <value>0:当月(当期) 1:当期</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrintRangeDivState PrintRangeDiv
        {
            get { return _printRangeDiv; }
            set { _printRangeDiv = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>在庫取寄せ区分プロパティ</summary>
        /// <value>0:合計 1:在庫 2:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RsltTtlDivCdState RsltTtlDivCd
        {
            get { return _rsltTtlDivCd; }
            set { _rsltTtlDivCd = value; }
        }

        /// public propaty name  :  AnnualPrintDiv
        /// <summary>当期印刷プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   当期印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AnnualPrintDivState AnnualPrintDiv
        {
            get { return _annualPrintDiv; }
            set { _annualPrintDiv = value; }
        }

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

        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
        /// public propaty name  :  GoodsNoSumDiv
        /// <summary>品番集計区分プロパティ</summary>
        /// <value>>0:別々 1:合算</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsNoSumState GoodsNoSumDiv
        {
            get { return _goodsNoSumDiv; }
            set { _goodsNoSumDiv = value; }
        }

        /// public propaty name  :  GoodsNoDisDiv
        /// <summary>品番選択区分プロパティ</summary>
        /// <value>>0:新品番 1:旧品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsNoDisState GoodsNoDisDiv
        {
            get { return _goodsNoDisDiv; }
            set { _goodsNoDisDiv = value; }
        }
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<

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

        /// public propaty name  :  PrintType
        /// <summary>発行タイププロパティ</summary>
        /// <value>0:拠点別倉庫別 1:倉庫別得意先別 2:倉庫別拠点別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrintTypeState PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>開始当月プロパティ</summary>
        /// <value>YYYYMM　当月計　算出範囲開始</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始当月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>終了当月プロパティ</summary>
        /// <value>YYYYMM　当月計　算出範囲終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了当月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
        }

        /// public propaty name  :  AnnualAddUpYearMonthSt
        /// <summary>開始当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲開始</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualAddUpYearMonthSt
        {
            get { return _annualAddUpYearMonthSt; }
            set { _annualAddUpYearMonthSt = value; }
        }

        /// public propaty name  :  AnnualAddUpYaerMonthEd
        /// <summary>終了当期月プロパティ</summary>
        /// <value>YYYYMM　当期計　算出範囲終了</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了当期月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualAddUpYaerMonthEd
        {
            get { return _annualAddUpYaerMonthEd; }
            set { _annualAddUpYaerMonthEd = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>開始対象期間(期間)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象期間(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>終了対象期間(期間)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象期間(期間)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  AnnualSalesDateSt
        /// <summary>開始対象期間(当期)プロパティ</summary>
        /// <value>YYYYMMDD(期首月)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象期間(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualSalesDateSt
        {
            get { return _annualSalesDateSt; }
            set { _annualSalesDateSt = value; }
        }

        /// public propaty name  :  AnnualSalesDateEd
        /// <summary>終了対象期間(当期)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象期間(当期)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AnnualSalesDateEd
        {
            get { return _annualSalesDateEd; }
            set { _annualSalesDateEd = value; }
        }

        /// public propaty name  :  PrintRangeSt
        /// <summary>開始出荷数プロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintRangeSt
        {
            get { return _printRangeSt; }
            set { _printRangeSt = value; }
        }

        /// public propaty name  :  PrintRangeEd
        /// <summary>終了出荷数プロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintRangeEd
        {
            get { return _printRangeEd; }
            set { _printRangeEd = value; }
        }

        // --- ADD 2009/02/10 -------------------------------->>>>>
        /// public propaty name  :  PrintRangeStNoInputFlg
        /// <summary>開始出荷数未入力フラグプロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷数未入力フラグプロパティ</br>
        /// </remarks>
        public bool PrintRangeStNoInputFlg
        {
            get { return _printRangeStNoInputFlg; }
            set { _printRangeStNoInputFlg = value; }
        }

        /// public propaty name  :  PrintRangeEdNoInputFlg
        /// <summary>終了出荷未入力フラグプロパティ</summary>
        /// <value>（ＵＩ制御項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  終了出荷未入力フラグプロパティ</br>
        /// </remarks>
        public bool PrintRangeEdNoInputFlg
        {
            get { return _printRangeEdNoInputFlg; }
            set { _printRangeEdNoInputFlg = value; }
        }
        // --- ADD 2009/02/10 --------------------------------<<<<<

        // --- DEL 2008/10/08 -------------------------------->>>>>
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
        // --- DEL 2008/10/08 --------------------------------<<<<<


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

        // --- ADD 2009/04/11------------------------->>>>>
        /// public propaty name  :  SupplierCodeSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  SupplierCodeEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }
        // --- ADD 2009/04/11-------------------------<<<<<

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

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
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
        /// <summary>開始商品中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>終了商品中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BLコードプロパティ</summary>
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
        /// <summary>終了BLコードプロパティ</summary>
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
        /// <summary>開始品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>終了品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        // --- DEL 2008/10/08 -------------------------------->>>>>
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
        // --- DEL 2008/10/08 --------------------------------<<<<<

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

        /// public propaty name  :  WarehouseSumPrintDiv
        /// <summary>倉庫コード計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState WarehouseSumPrintDiv
        {
            get { return _warehouseSumPrintDiv; }
            set { _warehouseSumPrintDiv = value; }
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

        // --- ADD 2009/04/11------------------------->>>>>
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
        // --- ADD 2009/04/11-------------------------<<<<<

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

        /// public propaty name  :  GoodsLGroupSumPrintDiv
        /// <summary>商品大分類計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState GoodsLGroupSumPrintDiv
        {
            get { return _goodsLGroupSumPrintDiv; }
            set { _goodsLGroupSumPrintDiv = value; }
        }

        /// public propaty name  :  GoodsMGroupSumPrintDiv
        /// <summary>商品中分類計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState GoodsMGroupSumPrintDiv
        {
            get { return _goodsMGroupSumPrintDiv; }
            set { _goodsMGroupSumPrintDiv = value; }
        }

        /// public propaty name  :  BLGroupCodeSumPrintDiv
        /// <summary>グループコード計印字区分プロパティ</summary>
        /// <value>（ＵＩ制御項目）0:印字しない／1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumPrintDivState BLGroupCodeSumPrintDiv
        {
            get { return bLGroupCodeSumPrintDiv; }
            set { bLGroupCodeSumPrintDiv = value; }
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
                switch (this._ttlType)
                {
                    case TtlTypeState.All:
                        return ct_ttlTypeState_All;
                    case TtlTypeState.BySection:
                        return ct_ttlTypeState_BySection;
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
                switch (this._totalType)
                {
                    case TotalTypeState.EachGoods:
                        return ct_totalTypeState_EachGoods;
                    case TotalTypeState.EachCustomer:
                        return ct_totalTypeState_EachCustomer;
                    case TotalTypeState.EachEmployee:
                        return ct_totalTypeState_EachEmployee;
                    case TotalTypeState.EachSupplier:
                        return ct_totalTypeState_EachSupplier;  // ADD 2009/04/11
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 在庫取寄区分　名称取得
        /// </summary>
        public string RsltTtlDivCdName
        {
            get
            {
                switch (this._rsltTtlDivCd)
                {
                    case RsltTtlDivCdState.Sum:
                        return ct_rsltTtlDivCdState_Sum;
                    case RsltTtlDivCdState.Stock:
                        return ct_rsltTtlDivCdState_Stock;
                    case RsltTtlDivCdState.Order:
                        return ct_rsltTtlDivCdState_Order;
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
                switch (this._priceUnitDiv)
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
        /// 当期印刷　名称取得
        /// </summary>
        public string AnnualPrintDivName
        {
            get
            {
                switch (this._annualPrintDiv)
                {
                    case AnnualPrintDivState.Print:
                        return ct_Common_Do;
                    case AnnualPrintDivState.None:
                        return ct_Common_None;
                    default:
                        return string.Empty;
                }
            }
        }

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
                    case NewPageDivState.EachWareHouse:
                        return ct_NewPageDivState_EachWarehouse;
                    case NewPageDivState.EachSupplier:          // ADD 2009/04/11
                        return ct_NewPageDivState_EachSupplier;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 発行タイプ　名称取得
        /// </summary>
        public string PrintTypeName
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.SectionWarehouse:
                        return ct_PrintType_SectionWarehouse;
                    case PrintTypeState.WarehouseCustomer:
                        return ct_PrintType_WarehouseCustomer;
                    case PrintTypeState.WarehouseSection:
                        return ct_PrintType_WarehouseSection;
                    default:
                        return string.Empty;
                }
            }
        }

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
                    case DetailDataValueState.Supplier:      // ADD 2009/04/11
                        return ct_DetailDataValue_Supplier;
                    case DetailDataValueState.Warehouse:
                        return ct_DetailDataValue_Warehouse;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 発行タイプ　名称取得
        /// </summary>
        public string PrintRangeDivName
        {
            get
            {
                switch (this._printRangeDiv)
                {
                    case PrintRangeDivState.YearMonth:
                        if (this._totalType == TotalTypeState.EachWareHouse)
                        {
                            return ct_PrintRangeDiv_YearMonthWare;
                        }
                        else
                        {
                            return ct_PrintRangeDiv_YearMonth;
                        }
                    case PrintRangeDivState.AnnualYearMonth:
                        return ct_PrintRangeDiv_AnnualYearMonth;
                    default:
                        return string.Empty;
                }
            }
        }

        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
        /// <summary>
        /// 品番集計区分　名称取得
        /// </summary>
        public string GoodsNoSumDivName
        {
            get
            {
                switch (this._goodsNoSumDiv)
                {
                    case GoodsNoSumState.GoodsNoOneByOne:
                        return ct_GoodsNoSum_OneByOne;
                    case GoodsNoSumState.GoodsNoSum:
                        return ct_GoodsNoSum_Sum;
                    default:
                        return string.Empty;
                }
            }
        }
        /// <summary>
        /// 品番選択区分　名称取得
        /// </summary>
        public string GoodsNoDisDivName
        {
            get
            {
                switch (this._goodsNoDisDiv)
                {
                    case GoodsNoDisState.NewGoodsNo:
                        return ct_GoodsNoDis_New;
                    case GoodsNoDisState.OldGoodsNo:
                        return ct_GoodsNoDis_Old;
                    default:
                        return string.Empty;
                }
            }
        }
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<

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
            /// <summary>倉庫別</summary>
            EachWareHouse = 3,
            // --- ADD 2009/04/11 -------------------------------->>>>>
            /// <summary>仕入先別</summary>
            EachSupplier = 4,
            // --- ADD 2009/04/11 --------------------------------<<<<<
        }
        /// <summary>
        /// 在庫取寄区分　列挙型
        /// </summary>
        public enum RsltTtlDivCdState
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
            /// <summary>拠点毎</summary>
            EachSection = 0,
            /// <summary>メーカー毎</summary>
            EachMaker = 1,
            /// <summary>得意先毎</summary>
            EachCustomer = 2,
            /// <summary>担当者毎</summary>
            EachEmployee = 3,
            /// <summary>倉庫毎</summary>
            EachWareHouse = 4,
            /// <summary>改ページしない</summary>
            None = 5,
            // --- ADD 2009/04/11 -------------------------------->>>>>
            /// <summary>仕入先毎</summary>
            EachSupplier = 6,
            // --- ADD 2009/04/11 --------------------------------<<<<<
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

        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>
        /// 出荷指定区分　列挙型
        /// </summary>
        public enum PrintRangeDivState
        {
            /// <summary>当月(期間)</summary>
            YearMonth = 0,
            /// <summary>当期</summary>
            AnnualYearMonth = 1,
        }

        /// <summary>
        /// 当期印刷　列挙型
        /// </summary>
        public enum AnnualPrintDivState
        {
            /// <summary>印字する</summary>
            Print = 1,
            /// <summary>印字しない</summary>
            None = 0,
        }

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

        /// <summary>
        /// 発行タイプ　列挙型
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>拠点別倉庫別</summary>
            SectionWarehouse = 0,
            /// <summary>倉庫別得意先別</summary>
            WarehouseCustomer = 1,
            /// <summary>倉庫別拠点別</summary>
            WarehouseSection = 2,
        }

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
            /// <summary>倉庫</summary>
            Warehouse = 9,
            /// <summary>仕入先</summary> 
            Supplier = 10,    // ADD 2009/04/11

        }

        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
        /// <summary>
        /// 品番表示区分　列挙型
        /// </summary>
        public enum GoodsNoSumState
        {
            /// <summary>別々</summary>
            GoodsNoOneByOne = 0,
            /// <summary>合算</summary>
            GoodsNoSum = 1,
        }

        /// <summary>
        /// 品番選択区分　列挙型
        /// </summary>
        public enum GoodsNoDisState
        {
            /// <summary>新品番</summary>
            NewGoodsNo = 0,
            /// <summary>旧品番</summary>
            OldGoodsNo = 1,
        }
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<



        // --- ADD 2008/10/08 --------------------------------<<<<< 
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        // --- DEL 2008/10/08 -------------------------------->>>>>
        ///// <summary>共通 全て コード</summary>
        //public const int ct_All_Code = -1;
        ///// <summary>共通 全て 名称</summary>
        //public const string ct_All_Name = "全て";
        // --- DEL 2008/10/08 --------------------------------<<<<<

        /// <summary>集計方法　全社集計</summary>
        public const string ct_ttlTypeState_All = "全社";
        /// <summary>集計方法　拠点別</summary>
        public const string ct_ttlTypeState_BySection = "拠点別";

        /// <summary>帳票集計区分　商品別</summary>
        public const string ct_totalTypeState_EachGoods = "商品別";
        /// <summary>帳票集計区分　得意先別</summary>
        public const string ct_totalTypeState_EachCustomer = "得意先別";
        /// <summary>帳票集計区分　担当者別</summary>
        public const string ct_totalTypeState_EachEmployee = "担当者別";
        /// <summary>帳票集計区分　倉庫別</summary>
        public const string ct_totalTypeState_EachWarehouse = "倉庫別"; // ADD 2008/10/08
        /// <summary>帳票集計区分　仕入先別</summary>
        public const string ct_totalTypeState_EachSupplier = "仕入先別"; // ADD 2009/04/11


        /// <summary>在庫取寄指定区分　合計</summary>
        public const string ct_rsltTtlDivCdState_Sum = "合計";
        /// <summary>在庫取寄指定区分　在庫</summary>
        public const string ct_rsltTtlDivCdState_Stock = "在庫";
        /// <summary>在庫取寄指定区分　取寄</summary>
        public const string ct_rsltTtlDivCdState_Order = "取寄";

        /// <summary>金額単位　円</summary>
        public const string ct_PriceUnitDivState_One = "円";
        /// <summary>金額単位　千円</summary>
        public const string ct_PriceUnitDivState_Thousand = "千円";

        // --- ADD 2008/10/08 -------------------------------->>>>>
        /// <summary>改ページ区分　しない</summary>
        public const string ct_NewPageDivState_None = "しない";
        /// <summary>改ページ区分　拠点毎</summary>
        public const string ct_NewPageDivState_EachSection = "拠点単位";
        /// <summary>改ページ区分　メーカー毎</summary>
        public const string ct_NewPageDivState_EachMaker = "メーカー単位";
        /// <summary>改ページ区分　得意先毎</summary>
        public const string ct_NewPageDivState_EachCustomer = "得意先単位";
        /// <summary>改ページ区分　担当者毎</summary>
        public const string ct_NewPageDivState_EachEmployee = "担当者単位";
        /// <summary>改ページ区分　倉庫毎</summary>
        public const string ct_NewPageDivState_EachWarehouse = "倉庫単位";
        /// <summary>改ページ区分　仕入先毎</summary>
        public const string ct_NewPageDivState_EachSupplier = "仕入先単位";

        /// <summary>発行タイプ　拠点別倉庫別</summary>
        public const string ct_PrintType_SectionWarehouse = "拠点別倉庫別";
        /// <summary>発行タイプ　倉庫別得意先別</summary>
        public const string ct_PrintType_WarehouseCustomer = "倉庫別得意先別";
        /// <summary>発行タイプ　倉庫別拠点別</summary>
        public const string ct_PrintType_WarehouseSection = "倉庫別拠点別";

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
        /// <summary>明細単位　仕入先</summary>
        public const string ct_DetailDataValue_Supplier = "仕入先";
        /// <summary>明細単位　担当者</summary>
        public const string ct_DetailDataValue_Employee = "担当者";
        /// <summary>明細単位　倉庫</summary>
        public const string ct_DetailDataValue_Warehouse = "倉庫";

        /// <summary>出荷指定区分 当月</summary>
        public const string ct_PrintRangeDiv_YearMonth = "当月";
        /// <summary>出荷指定区分 期間</summary>
        public const string ct_PrintRangeDiv_YearMonthWare = "期間";
        /// <summary>出荷指定区分 当期</summary>
        public const string ct_PrintRangeDiv_AnnualYearMonth = "当期";

        /// <summary>共通名称 する</summary>
        public const string ct_Common_Do = "する";
        /// <summary>共通名称 しない</summary>
        public const string ct_Common_None = "しない";
        // --- ADD 2008/10/08 --------------------------------<<<<<
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更-------------------------------->>>>>
        /// <summary>品番集計区分　別々</summary>
        //public const string ct_GoodsNoSum_OneByOne = "別々";// DEL 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        public const string ct_GoodsNoSum_OneByOne = "通常";// ADD 2015/03/27 Redmine#44209の#423品番集計区分の名称変更
        
        /// <summary>品番集計区分　合算</summary>
        public const string ct_GoodsNoSum_Sum = "合算";
        /// <summary>品番選択区分　新品番を表示</summary>
        public const string ct_GoodsNoDis_New = "新品番";
        /// <summary>品番選択区分　旧品番を表示</summary>
        public const string ct_GoodsNoDis_Old = "旧品番";
        // --- ADD 2014/12/16 李侠 明治産業様Seiken品番変更--------------------------------<<<<<

        // --- DEL 2008/10/08 -------------------------------->>>>>
        ///// <summary>計印字区分　しない</summary>
        //public const string ct_SumPrintDivState_None = "しない";
        ///// <summary>計印字区分　する</summary>
        //public const string ct_SumPrintDivState_Print = "する";
        // --- DEL 2008/10/08 --------------------------------<<<<<
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
        public SalesRsltListCndtn()
        {
        }
        # endregion ■ Constructor ■
    }
}
