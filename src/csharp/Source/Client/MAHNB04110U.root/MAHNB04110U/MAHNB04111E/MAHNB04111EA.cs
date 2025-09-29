using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesSlipSearch
    /// <summary>
    ///                      売上伝票検索条件
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上伝票検索条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   鄧潘ハン Redmine 26538対応</br>
    /// <br>Date             :   2011/11/11</br>
    /// </remarks>
    public class SalesSlipSearch
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品,2:値引 100:現金売上 101:現金返品 102:現金値引</remarks>
        private Int32 _salesSlipCd;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,15:単価見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>売上伝票番号(開始)</summary>
        private string _salesSlipNumSt = "";

        /// <summary>売上伝票番号(終了)</summary>
        private string _salesSlipNumEd = "";

        /// <summary>売上日(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>売上日(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>伝票検索日付(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDateSt;

        /// <summary>伝票検索日付(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _searchSlipDateEd;

        /// <summary>受付従業員コード</summary>
        private string _frontEmployeeCd = "";

        /// <summary>販売従業員コード</summary>
        private string _salesEmployeeCd = "";

        /// <summary>売上入力者コード</summary>
        private string _salesInputCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>拠点名</summary>
        private string _sectionName = "";

        /// <summary>得意先名</summary>
        private string _customerName = "";

        /// <summary>請求先名</summary>
        private string _claimName = "";

        /// <summary>商品名</summary>
        private string _goodsName = "";

        /// <summary>受付従業員名</summary>
        private string _frontEmployeeName = "";

        /// <summary>販売従業員名</summary>
        private string _salesEmployeeName = "";

        /// <summary>売上入力者名</summary>
        private string _salesInputName = "";

        /// <summary>メーカー名</summary>
        private string _makerName = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>型名</summary>
        private string _fullModel = "";

        /// <summary>部署コード</summary>
        private int _subSectionCode;

        /// <summary>部署名</summary>
        private string _subSectionName;

        //---ADD 2011/11/11 ------------------------->>>>>
        /// <summary>受発注種別</summary>
        /// <remarks>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</remarks>
        private Int16 _acceptOrOrderKind;

        /// <summary>自動回答種別</summary>
        /// <remarks>0:通常　,1:手動回答　,2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD 2011/11/11 -------------------------<<<<<

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

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引 100:現金売上 101:現金返品 102:現金値引</value>
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,15:単価見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
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

        /// public propaty name  :  SalesDateSt
        /// <summary>売上日(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>売上日(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  SearchSlipDateSt
        /// <summary>伝票検索日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SearchSlipDateSt
        {
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
        }

        /// public propaty name  :  SearchSlipDateEd
        /// <summary>伝票検索日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SearchSlipDateEd
        {
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>拠点名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>請求先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  FrontEmployeeName
        /// <summary>受付従業員名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeName
        {
            get { return _frontEmployeeName; }
            set { _frontEmployeeName = value; }
        }

        /// public propaty name  :  SalesEmployeeName
        /// <summary>販売従業員名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeName
        {
            get { return _salesEmployeeName; }
            set { _salesEmployeeName = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
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

        /// public propaty name  :  FullModel
        /// <summary>型式名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部署名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SubSectionCode
        {
            get { return _subSectionCode; }
            set { this._subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>部署名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { this._subSectionName = value; }
        }

        //---ADD 2011/11/11 ----------------------->>>>>

        /// public propaty name  :  AcceptOrOrderKindRF
        /// <summary>受発注種別プロパティ</summary>
        /// <value>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }


        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答種別プロパティ</summary>
        /// <value>0:通常　,1:手動回答　,2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答種別プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        //---ADD 2011/11/11 -----------------------<<<<<



        /// <summary>
        /// 売上伝票検索条件コンストラクタ
        /// </summary>
        /// <returns>SalesSlipSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSlipSearch()
        {
        }

        /// <summary>
        /// 売上伝票検索条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品,2:値引 100:現金売上 101:現金返品 102:現金値引)</param>
        /// <param name="acptAnOdrStatus">受注ステータス(10:見積,15:単価見積,20:受注,30:売上,40:出荷)</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="salesSlipNumSt">売上伝票番号(開始)</param>
        /// <param name="salesSlipNumEd">売上伝票番号(終了)</param>
        /// <param name="salesDateSt">売上日(開始)(YYYYMMDD)</param>
        /// <param name="salesDateEd">売上日(終了)(YYYYMMDD)</param>
        /// <param name="searchSlipDateSt">伝票検索日付(開始)(YYYYMMDD)</param>
        /// <param name="searchSlipDateEd">伝票検索日付(終了)(YYYYMMDD)</param>
        /// <param name="frontEmployeeCd">受付従業員コード</param>
        /// <param name="salesEmployeeCd">販売従業員コード</param>
        /// <param name="salesInputCode">売上入力者コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="sectionName">拠点名</param>
        /// <param name="customerName">得意先名</param>
        /// <param name="claimName">請求先名</param>
        /// <param name="goodsName">商品名</param>
        /// <param name="frontEmployeeName">受付従業員名</param>
        /// <param name="salesEmployeeName">販売従業員名</param>
        /// <param name="salesInputName">売上入力者名</param>
        /// <param name="makerName">メーカー名</param>
        /// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="acceptOrOrderKind">連携種別</param>
        /// <param name="autoAnswerDivSCM">自動回答</param>
        /// <returns>SalesSlipSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        /// </remarks>
        //public SalesSlipSearch(string enterpriseCode, Int32 salesSlipCd, Int32 acptAnOdrStatus, Int32 accRecDivCd, string salesSlipNumSt, string salesSlipNumEd, DateTime salesDateSt, DateTime salesDateEd, DateTime searchSlipDateSt, DateTime searchSlipDateEd, string frontEmployeeCd, string salesEmployeeCd, string salesInputCode, Int32 customerCode, Int32 claimCode, string sectionCode, Int32 goodsMakerCd, string goodsNo, string sectionName, string customerName, string claimName, string goodsName, string frontEmployeeName, string salesEmployeeName, string salesInputName, string makerName, string partySaleSlipNum, string enterpriseName, string fullModel, Int32 subSectionCode, string subSectionName)// DEL 2011/11/11
        public SalesSlipSearch(string enterpriseCode, Int32 salesSlipCd, Int32 acptAnOdrStatus, Int32 accRecDivCd, string salesSlipNumSt, string salesSlipNumEd, DateTime salesDateSt, DateTime salesDateEd, DateTime searchSlipDateSt, DateTime searchSlipDateEd, string frontEmployeeCd, string salesEmployeeCd, string salesInputCode, Int32 customerCode, Int32 claimCode, string sectionCode, Int32 goodsMakerCd, string goodsNo, string sectionName, string customerName, string claimName, string goodsName, string frontEmployeeName, string salesEmployeeName, string salesInputName, string makerName, string partySaleSlipNum, string enterpriseName, string fullModel, Int32 subSectionCode, string subSectionName, Int16 acceptOrOrderKind, Int32 autoAnswerDivSCM)  //ADD 2011/11/11  
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipCd = salesSlipCd;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._accRecDivCd = accRecDivCd;
            this._salesSlipNumSt = salesSlipNumSt;
            this._salesSlipNumEd = salesSlipNumEd;
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._searchSlipDateSt = searchSlipDateSt;
            this._searchSlipDateEd = searchSlipDateEd;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesEmployeeCd = salesEmployeeCd;
            this._salesInputCode = salesInputCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._sectionCode = sectionCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._sectionName = sectionName;
            this._customerName = customerName;
            this._claimName = claimName;
            this._goodsName = goodsName;
            this._frontEmployeeName = frontEmployeeName;
            this._salesEmployeeName = salesEmployeeName;
            this._salesInputName = salesInputName;
            this._makerName = makerName;
            this._partySaleSlipNum = partySaleSlipNum;
            this._enterpriseName = enterpriseName;
            this._fullModel = fullModel;
            this._subSectionCode = subSectionCode;
            this._subSectionName = subSectionName;
            //---ADD 2011/11/11 ------>>>>>
            this._acceptOrOrderKind = acceptOrOrderKind;
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            //---ADD 2011/11/11 ------<<<<<
        }

        /// <summary>
        /// 売上伝票検索条件複製処理
        /// </summary>
        /// <returns>SalesSlipSearchクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesSlipSearchクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public SalesSlipSearch Clone()
        {
            //return new SalesSlipSearch( this._enterpriseCode, this._salesSlipCd, this._acptAnOdrStatus, this._accRecDivCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._frontEmployeeCd, this._salesEmployeeCd, this._salesInputCode, this._customerCode, this._claimCode, this._sectionCode, this._goodsMakerCd, this._goodsNo, this._sectionName, this._customerName, this._claimName, this._goodsName, this._frontEmployeeName, this._salesEmployeeName, this._salesInputName, this._makerName, this._partySaleSlipNum, this._enterpriseName, this._fullModel, this._subSectionCode, this._subSectionName );// DEL 2011/11/11
            return new SalesSlipSearch(this._enterpriseCode, this._salesSlipCd, this._acptAnOdrStatus, this._accRecDivCd, this._salesSlipNumSt, this._salesSlipNumEd, this._salesDateSt, this._salesDateEd, this._searchSlipDateSt, this._searchSlipDateEd, this._frontEmployeeCd, this._salesEmployeeCd, this._salesInputCode, this._customerCode, this._claimCode, this._sectionCode, this._goodsMakerCd, this._goodsNo, this._sectionName, this._customerName, this._claimName, this._goodsName, this._frontEmployeeName, this._salesEmployeeName, this._salesInputName, this._makerName, this._partySaleSlipNum, this._enterpriseName, this._fullModel, this._subSectionCode, this._subSectionName, this._acceptOrOrderKind, this._autoAnswerDivSCM);//ADD 2011/11/11
        }

        /// <summary>
        /// 売上伝票検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipSearchクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public bool Equals(SalesSlipSearch target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.SalesSlipNumSt == target.SalesSlipNumSt)
                 && (this.SalesSlipNumEd == target.SalesSlipNumEd)
                 && (this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
                 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.SectionName == target.SectionName)
                 && (this.CustomerName == target.CustomerName)
                 && (this.ClaimName == target.ClaimName)
                 && (this.GoodsName == target.GoodsName)
                 && (this.FrontEmployeeName == target.FrontEmployeeName)
                 && (this.SalesEmployeeName == target.SalesEmployeeName)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.MakerName == target.MakerName)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.FullModel == target.FullModel)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.SubSectionName == target.SubSectionName)
                 //---ADD 2011/11/11 ---------------->>>>>
                 && (this.AcceptOrOrderKind == target.AcceptOrOrderKind)
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)
                 //---ADD 2011/11/11 -----------------<<<<<
                 );
        }

        /// <summary>
        /// 売上伝票検索条件比較処理
        /// </summary>
        /// <param name="salesSlipSearch1">
        ///                    比較するSalesSlipSearchクラスのインスタンス
        /// </param>
        /// <param name="salesSlipSearch2">比較するSalesSlipSearchクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public static bool Equals(SalesSlipSearch salesSlipSearch1, SalesSlipSearch salesSlipSearch2)
        {
            return ((salesSlipSearch1.EnterpriseCode == salesSlipSearch2.EnterpriseCode)
                 && (salesSlipSearch1.SalesSlipCd == salesSlipSearch2.SalesSlipCd)
                 && (salesSlipSearch1.AcptAnOdrStatus == salesSlipSearch2.AcptAnOdrStatus)
                 && (salesSlipSearch1.AccRecDivCd == salesSlipSearch2.AccRecDivCd)
                 && (salesSlipSearch1.SalesSlipNumSt == salesSlipSearch2.SalesSlipNumSt)
                 && (salesSlipSearch1.SalesSlipNumEd == salesSlipSearch2.SalesSlipNumEd)
                 && (salesSlipSearch1.SalesDateSt == salesSlipSearch2.SalesDateSt)
                 && (salesSlipSearch1.SalesDateEd == salesSlipSearch2.SalesDateEd)
                 && (salesSlipSearch1.SearchSlipDateSt == salesSlipSearch2.SearchSlipDateSt)
                 && (salesSlipSearch1.SearchSlipDateEd == salesSlipSearch2.SearchSlipDateEd)
                 && (salesSlipSearch1.FrontEmployeeCd == salesSlipSearch2.FrontEmployeeCd)
                 && (salesSlipSearch1.SalesEmployeeCd == salesSlipSearch2.SalesEmployeeCd)
                 && (salesSlipSearch1.SalesInputCode == salesSlipSearch2.SalesInputCode)
                 && (salesSlipSearch1.CustomerCode == salesSlipSearch2.CustomerCode)
                 && (salesSlipSearch1.ClaimCode == salesSlipSearch2.ClaimCode)
                 && (salesSlipSearch1.SectionCode == salesSlipSearch2.SectionCode)
                 && (salesSlipSearch1.GoodsMakerCd == salesSlipSearch2.GoodsMakerCd)
                 && (salesSlipSearch1.GoodsNo == salesSlipSearch2.GoodsNo)
                 && (salesSlipSearch1.SectionName == salesSlipSearch2.SectionName)
                 && (salesSlipSearch1.CustomerName == salesSlipSearch2.CustomerName)
                 && (salesSlipSearch1.ClaimName == salesSlipSearch2.ClaimName)
                 && (salesSlipSearch1.GoodsName == salesSlipSearch2.GoodsName)
                 && (salesSlipSearch1.FrontEmployeeName == salesSlipSearch2.FrontEmployeeName)
                 && (salesSlipSearch1.SalesEmployeeName == salesSlipSearch2.SalesEmployeeName)
                 && (salesSlipSearch1.SalesInputName == salesSlipSearch2.SalesInputName)
                 && (salesSlipSearch1.MakerName == salesSlipSearch2.MakerName)
                 && (salesSlipSearch1.PartySaleSlipNum == salesSlipSearch2.PartySaleSlipNum)
                 && (salesSlipSearch1.EnterpriseName == salesSlipSearch2.EnterpriseName)
                 && (salesSlipSearch1.FullModel == salesSlipSearch2.FullModel)
                 && (salesSlipSearch1.SubSectionCode == salesSlipSearch2.SubSectionCode)
                 && (salesSlipSearch1.SubSectionName == salesSlipSearch2.SubSectionName)
                 //---ADD 2011/11/11 -------------->>>>>
                 && (salesSlipSearch1.AcceptOrOrderKind == salesSlipSearch2.AcceptOrOrderKind)
                 && (salesSlipSearch1.AutoAnswerDivSCM == salesSlipSearch2.AutoAnswerDivSCM)
                 //---ADD 2011/11/11 --------------<<<<<
                 );
        }
        /// <summary>
        /// 売上伝票検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesSlipSearchクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public ArrayList Compare(SalesSlipSearch target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.SalesSlipNumSt != target.SalesSlipNumSt) resList.Add("SalesSlipNumSt");
            if (this.SalesSlipNumEd != target.SalesSlipNumEd) resList.Add("SalesSlipNumEd");
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.SearchSlipDateSt != target.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
            if (this.SearchSlipDateEd != target.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.FrontEmployeeName != target.FrontEmployeeName) resList.Add("FrontEmployeeName");
            if (this.SalesEmployeeName != target.SalesEmployeeName) resList.Add("SalesEmployeeName");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if ( this.SubSectionName != target.SubSectionName ) resList.Add( "SubSectionName" );
            //---ADD 2011/11/11 ------------------------------------->>>>>
            if (this.AcceptOrOrderKind != target.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            //---ADD 2011/11/11 -------------------------------------<<<<<
            return resList;
        }

        /// <summary>
        /// 売上伝票検索条件比較処理
        /// </summary>
        /// <param name="salesSlipSearch1">比較するSalesSlipSearchクラスのインスタンス</param>
        /// <param name="salesSlipSearch2">比較するSalesSlipSearchクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipSearchクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// </remarks>
        public static ArrayList Compare(SalesSlipSearch salesSlipSearch1, SalesSlipSearch salesSlipSearch2)
        {
            ArrayList resList = new ArrayList();
            if (salesSlipSearch1.EnterpriseCode != salesSlipSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesSlipSearch1.SalesSlipCd != salesSlipSearch2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (salesSlipSearch1.AcptAnOdrStatus != salesSlipSearch2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (salesSlipSearch1.AccRecDivCd != salesSlipSearch2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (salesSlipSearch1.SalesSlipNumSt != salesSlipSearch2.SalesSlipNumSt) resList.Add("SalesSlipNumSt");
            if (salesSlipSearch1.SalesSlipNumEd != salesSlipSearch2.SalesSlipNumEd) resList.Add("SalesSlipNumEd");
            if (salesSlipSearch1.SalesDateSt != salesSlipSearch2.SalesDateSt) resList.Add("SalesDateSt");
            if (salesSlipSearch1.SalesDateEd != salesSlipSearch2.SalesDateEd) resList.Add("SalesDateEd");
            if (salesSlipSearch1.SearchSlipDateSt != salesSlipSearch2.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
            if (salesSlipSearch1.SearchSlipDateEd != salesSlipSearch2.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
            if (salesSlipSearch1.FrontEmployeeCd != salesSlipSearch2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (salesSlipSearch1.SalesEmployeeCd != salesSlipSearch2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (salesSlipSearch1.SalesInputCode != salesSlipSearch2.SalesInputCode) resList.Add("SalesInputCode");
            if (salesSlipSearch1.CustomerCode != salesSlipSearch2.CustomerCode) resList.Add("CustomerCode");
            if (salesSlipSearch1.ClaimCode != salesSlipSearch2.ClaimCode) resList.Add("ClaimCode");
            if (salesSlipSearch1.SectionCode != salesSlipSearch2.SectionCode) resList.Add("SectionCode");
            if (salesSlipSearch1.GoodsMakerCd != salesSlipSearch2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (salesSlipSearch1.GoodsNo != salesSlipSearch2.GoodsNo) resList.Add("GoodsNo");
            if (salesSlipSearch1.SectionName != salesSlipSearch2.SectionName) resList.Add("SectionName");
            if (salesSlipSearch1.CustomerName != salesSlipSearch2.CustomerName) resList.Add("CustomerName");
            if (salesSlipSearch1.ClaimName != salesSlipSearch2.ClaimName) resList.Add("ClaimName");
            if (salesSlipSearch1.GoodsName != salesSlipSearch2.GoodsName) resList.Add("GoodsName");
            if (salesSlipSearch1.FrontEmployeeName != salesSlipSearch2.FrontEmployeeName) resList.Add("FrontEmployeeName");
            if (salesSlipSearch1.SalesEmployeeName != salesSlipSearch2.SalesEmployeeName) resList.Add("SalesEmployeeName");
            if (salesSlipSearch1.SalesInputName != salesSlipSearch2.SalesInputName) resList.Add("SalesInputName");
            if (salesSlipSearch1.MakerName != salesSlipSearch2.MakerName) resList.Add("MakerName");
            if (salesSlipSearch1.PartySaleSlipNum != salesSlipSearch2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (salesSlipSearch1.EnterpriseName != salesSlipSearch2.EnterpriseName) resList.Add("EnterpriseName");
            if (salesSlipSearch1.FullModel != salesSlipSearch2.FullModel) resList.Add("FullModel");
            if (salesSlipSearch1.SubSectionCode != salesSlipSearch2.SubSectionCode) resList.Add("SubSectionCode");
            if ( salesSlipSearch1.SubSectionName != salesSlipSearch2.SubSectionName ) resList.Add( "SubSectionName" );
            //---ADD 2011/11/11 --------------------------------------------->>>>>
            if (salesSlipSearch1.AcceptOrOrderKind != salesSlipSearch2.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");
            if (salesSlipSearch1.AutoAnswerDivSCM != salesSlipSearch2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            //---ADD 2011/11/11 ---------------------------------------------<<<<<
            return resList;
        }
    }
}
