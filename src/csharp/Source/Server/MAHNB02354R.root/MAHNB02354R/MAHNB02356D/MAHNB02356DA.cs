using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesConfShWork
    /// <summary>
    ///                      売上確認表検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上確認表検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesConfShWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>全社選択</summary>
        /// <remarks>true:全社選択 false:各拠点選択</remarks>
        private Boolean _isSelectAllSection;

        /// <summary>実績計上拠点コードリスト</summary>
        /// <remarks>文字型　※配列項目 全社指定は{""}</remarks>
        private string[] _resultsAddUpSecList;

        /// <summary>論理削除区分</summary>
        /// <remarks>0:有効,1:論理削除,2:保留,3:完全削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>売上日付(開始)</summary>
        private Int32 _salesDateSt;

        /// <summary>売上日付(終了)</summary>
        private Int32 _salesDateEd;

        /// <summary>伝票検索日付(開始)</summary>
        private Int32 _searchSlipDateSt;

        /// <summary>伝票検索日付(終了)</summary>
        private Int32 _searchSlipDateEd;

        /// <summary>出荷日付（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDaySt;

        /// <summary>出荷日付（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDayEd;

        /// <summary>得意先コード(開始)</summary>
        private Int32 _customerCodeSt;

        /// <summary>得意先コード(終了)</summary>
        private Int32 _customerCodeEd;

        /// <summary>仕入先コード(開始)</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード(終了)</summary>
        private Int32 _supplierCdEd;

        /// <summary>赤伝区分</summary>
        /// <remarks>0:黒伝,1:赤伝,2:元黒　　※全ては-1</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品,2:返品＋行値引　※全ては-1</remarks>
        private Int32 _salesSlipCd;

        /// <summary>売上伝票番号(開始)</summary>
        private string _salesSlipNumSt = "";

        /// <summary>売上伝票番号(終了)</summary>
        private string _salesSlipNumEd = "";

        /// <summary>売上入力者コード(開始)</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCodeSt = "";

        /// <summary>売上入力者コード(終了)</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCodeEd = "";

        /// <summary>販売従業員コード(開始)</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCdSt = "";

        /// <summary>販売従業員コード(終了)</summary>
        /// <remarks>計上担当者（担当者）</remarks>
        private string _salesEmployeeCdEd = "";

        /// <summary>受付従業員コード（開始）</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCdSt = "";

        /// <summary>受付従業員コード（終了）</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCdEd = "";

        /// <summary>販売エリアコード(開始)</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCodeSt;

        /// <summary>販売エリアコード(終了)</summary>
        /// <remarks>地区コード</remarks>
        private Int32 _salesAreaCodeEd;

        /// <summary>業種コード(開始)</summary>
        private Int32 _businessTypeCodeSt;

        /// <summary>業種コード(終了)</summary>
        private Int32 _businessTypeCodeEd;

        /// <summary>売上伝票更新区分</summary>
        /// <remarks>0:未更新,1:更新あり　※全ては-1</remarks>
        private Int32 _salesSlipUpdateCd;

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫　　※全ては-1　注）売上確認表で注文方法＝「2:ｵﾝﾗｲﾝ発注」指定時は-1をセット</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>注文方法</summary>
        /// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録　※全ては-1</remarks>
        private Int32 _wayToOrder;

        /// <summary>粗利チェック下限</summary>
        /// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
        private Double _grsProfitCheckLower;

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

        /// <summary>売価ゼロのみ印字</summary>
        /// <remarks>0:指定なし,1:指定あり</remarks>
        private Int32 _zeroSalesPrint;

        /// <summary>原価ゼロのみ印字</summary>
        /// <remarks>0:指定なし,1:指定あり</remarks>
        private Int32 _zeroCostPrint;

        /// <summary>粗利ゼロのみ印字</summary>
        /// <remarks>0:指定なし,1:指定あり</remarks>
        private Int32 _zeroGrsProfitPrint;

        /// <summary>粗利ゼロ以下のみ印字</summary>
        /// <remarks>0:指定なし,1:指定あり</remarks>
        private Int32 _zeroUdrGrsProfitPrint;

        /// <summary>粗利率印字</summary>
        /// <remarks>0:指定なし,1:指定あり</remarks>
        private Int32 _grsProfitRatePrint;

        /// <summary>粗利率印字値</summary>
        private Double _grsProfitRatePrintVal;

        /// <summary>粗利率印字区分</summary>
        /// <remarks>0:以下,1:以上</remarks>
        private Int32 _grsProfitRatePrintDiv;


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

        /// public propaty name  :  IsSelectAllSection
        /// <summary>全社選択プロパティ</summary>
        /// <value>true:全社選択 false:各拠点選択</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全社選択プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsSelectAllSection
        {
            get { return _isSelectAllSection; }
            set { _isSelectAllSection = value; }
        }

        /// public propaty name  :  ResultsAddUpSecList
        /// <summary>実績計上拠点コードリストプロパティ</summary>
        /// <value>文字型　※配列項目 全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] ResultsAddUpSecList
        {
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>0:有効,1:論理削除,2:保留,3:完全削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>売上日付(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日付(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSlipDateSt
        /// <summary>伝票検索日付(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateSt
        {
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
        }

        /// public propaty name  :  SearchSlipDateEd
        /// <summary>伝票検索日付(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateEd
        {
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
        }

        /// public propaty name  :  ShipmentDaySt
        /// <summary>出荷日付（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDaySt
        {
            get { return _shipmentDaySt; }
            set { _shipmentDaySt = value; }
        }

        /// public propaty name  :  ShipmentDayEd
        /// <summary>出荷日付（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷日付（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmentDayEd
        {
            get { return _shipmentDayEd; }
            set { _shipmentDayEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>仕入先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>仕入先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>0:黒伝,1:赤伝,2:元黒　　※全ては-1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品,2:返品＋行値引　※全ては-1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesSlipNumSt
        /// <summary>売上伝票番号(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNumSt
        {
            get { return _salesSlipNumSt; }
            set { _salesSlipNumSt = value; }
        }

        /// public propaty name  :  SalesSlipNumEd
        /// <summary>売上伝票番号(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNumEd
        {
            get { return _salesSlipNumEd; }
            set { _salesSlipNumEd = value; }
        }

        /// public propaty name  :  SalesInputCodeSt
        /// <summary>売上入力者コード(開始)プロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCodeSt
        {
            get { return _salesInputCodeSt; }
            set { _salesInputCodeSt = value; }
        }

        /// public propaty name  :  SalesInputCodeEd
        /// <summary>売上入力者コード(終了)プロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCodeEd
        {
            get { return _salesInputCodeEd; }
            set { _salesInputCodeEd = value; }
        }

        /// public propaty name  :  SalesEmployeeCdSt
        /// <summary>販売従業員コード(開始)プロパティ</summary>
        /// <value>計上担当者（担当者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCdSt
        {
            get { return _salesEmployeeCdSt; }
            set { _salesEmployeeCdSt = value; }
        }

        /// public propaty name  :  SalesEmployeeCdEd
        /// <summary>販売従業員コード(終了)プロパティ</summary>
        /// <value>計上担当者（担当者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCdEd
        {
            get { return _salesEmployeeCdEd; }
            set { _salesEmployeeCdEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCdSt
        /// <summary>受付従業員コード（開始）プロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCdSt
        {
            get { return _frontEmployeeCdSt; }
            set { _frontEmployeeCdSt = value; }
        }

        /// public propaty name  :  FrontEmployeeCdEd
        /// <summary>受付従業員コード（終了）プロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCdEd
        {
            get { return _frontEmployeeCdEd; }
            set { _frontEmployeeCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>販売エリアコード(開始)プロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>販売エリアコード(終了)プロパティ</summary>
        /// <value>地区コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  BusinessTypeCodeSt
        /// <summary>業種コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeSt
        {
            get { return _businessTypeCodeSt; }
            set { _businessTypeCodeSt = value; }
        }

        /// public propaty name  :  BusinessTypeCodeEd
        /// <summary>業種コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCodeEd
        {
            get { return _businessTypeCodeEd; }
            set { _businessTypeCodeEd = value; }
        }

        /// public propaty name  :  SalesSlipUpdateCd
        /// <summary>売上伝票更新区分プロパティ</summary>
        /// <value>0:未更新,1:更新あり　※全ては-1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipUpdateCd
        {
            get { return _salesSlipUpdateCd; }
            set { _salesSlipUpdateCd = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫　　※全ては-1　注）売上確認表で注文方法＝「2:ｵﾝﾗｲﾝ発注」指定時は-1をセット</value>
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

        /// public propaty name  :  WayToOrder
        /// <summary>注文方法プロパティ</summary>
        /// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録　※全ては-1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注文方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
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

        /// public propaty name  :  ZeroSalesPrint
        /// <summary>売価ゼロのみ印字プロパティ</summary>
        /// <value>0:指定なし,1:指定あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価ゼロのみ印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ZeroSalesPrint
        {
            get { return _zeroSalesPrint; }
            set { _zeroSalesPrint = value; }
        }

        /// public propaty name  :  ZeroCostPrint
        /// <summary>原価ゼロのみ印字プロパティ</summary>
        /// <value>0:指定なし,1:指定あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価ゼロのみ印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ZeroCostPrint
        {
            get { return _zeroCostPrint; }
            set { _zeroCostPrint = value; }
        }

        /// public propaty name  :  ZeroGrsProfitPrint
        /// <summary>粗利ゼロのみ印字プロパティ</summary>
        /// <value>0:指定なし,1:指定あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利ゼロのみ印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ZeroGrsProfitPrint
        {
            get { return _zeroGrsProfitPrint; }
            set { _zeroGrsProfitPrint = value; }
        }

        /// public propaty name  :  ZeroUdrGrsProfitPrint
        /// <summary>粗利ゼロ以下のみ印字プロパティ</summary>
        /// <value>0:指定なし,1:指定あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利ゼロ以下のみ印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ZeroUdrGrsProfitPrint
        {
            get { return _zeroUdrGrsProfitPrint; }
            set { _zeroUdrGrsProfitPrint = value; }
        }

        /// public propaty name  :  GrsProfitRatePrint
        /// <summary>粗利率印字プロパティ</summary>
        /// <value>0:指定なし,1:指定あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率印字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GrsProfitRatePrint
        {
            get { return _grsProfitRatePrint; }
            set { _grsProfitRatePrint = value; }
        }

        /// public propaty name  :  GrsProfitRatePrintVal
        /// <summary>粗利率印字値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率印字値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GrsProfitRatePrintVal
        {
            get { return _grsProfitRatePrintVal; }
            set { _grsProfitRatePrintVal = value; }
        }

        /// public propaty name  :  GrsProfitRatePrintDiv
        /// <summary>粗利率印字区分プロパティ</summary>
        /// <value>0:以下,1:以上</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利率印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GrsProfitRatePrintDiv
        {
            get { return _grsProfitRatePrintDiv; }
            set { _grsProfitRatePrintDiv = value; }
        }


        /// <summary>
        /// 売上確認表検索条件ワークコンストラクタ
        /// </summary>
        /// <returns>SalesConfShWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesConfShWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesConfShWork()
        {
        }

    }

}
