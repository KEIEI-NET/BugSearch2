using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveSlipSearchCond
    /// <summary>
    ///                      在庫移動伝票検索条件
    /// </summary>
    /// <remarks>
    /// note             :   在庫移動伝票検索条件ヘッダファイル<br />
    /// Programmer       :   自動生成<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/01/25  (CSharp File Generated Date)<br />
    /// Update Note      :   <br />
    /// Update Note      :   2012/05/22 wangf </br>
    ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
    /// </remarks>
    public class StockMoveSlipSearchCond
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>在庫移動入力従業員コード</summary>
        /// <remarks>在庫移動伝票を入力する従業員コードをセット</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>出荷担当従業員コード</summary>
        /// <remarks>出荷確定処理を行う従業員コードをセット</remarks>
        private string _shipAgentCd = "";

        /// <summary>引取担当従業員コード</summary>
        /// <remarks>在庫の入荷側の従業員コードをセット</remarks>
        private string _receiveAgentCd = "";

        /// <summary>出荷予定開始日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlStDay;

        /// <summary>出荷予定終了日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlEdDay;

        /// <summary>出荷確定開始日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixStDay;

        /// <summary>出荷確定終了日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixEdDay;

        /// <summary>入荷開始日</summary>
        private DateTime _arrivalGoodsStDay;

        /// <summary>入荷終了日</summary>
        private DateTime _arrivalGoodsEdDay;

        /// <summary>移動元拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>移動元倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>移動先拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>移動先倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32 _moveStatus;

        /// <summary>機種コード</summary>
        private Int32 _cellphoneModelCode;

        /// <summary>製造番号</summary>
        /// <remarks>※「製番なし」の場合、null</remarks>
        private string _productNumber = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>引取担当従業員名称</summary>
        private string _receiveAgentNm = "";

        /// <summary>機種名称</summary>
        private string _cellphoneModelName = "";

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// <summary>呼出元機能区分</summary>
        /// <remarks>1:在庫移動入力検索ガイド、2：他の場合</remarks>
        private Int32 _callerFunction;
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   企業コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動伝票番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>在庫移動入力従業員コードプロパティ</summary>
        /// <value>在庫移動伝票を入力する従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   在庫移動入力従業員コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>出荷担当従業員コードプロパティ</summary>
        /// <value>出荷確定処理を行う従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷担当従業員コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>引取担当従業員コードプロパティ</summary>
        /// <value>在庫の入荷側の従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   引取担当従業員コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ShipmentScdlStDay
        /// <summary>出荷予定開始日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷予定開始日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ShipmentScdlStDay
        {
            get { return _shipmentScdlStDay; }
            set { _shipmentScdlStDay = value; }
        }

        /// public propaty name  :  ShipmentScdlEdDay
        /// <summary>出荷予定終了日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷予定終了日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ShipmentScdlEdDay
        {
            get { return _shipmentScdlEdDay; }
            set { _shipmentScdlEdDay = value; }
        }

        /// public propaty name  :  ShipmentFixStDay
        /// <summary>出荷確定開始日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷確定開始日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ShipmentFixStDay
        {
            get { return _shipmentFixStDay; }
            set { _shipmentFixStDay = value; }
        }

        /// public propaty name  :  ShipmentFixEdDay
        /// <summary>出荷確定終了日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   出荷確定終了日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ShipmentFixEdDay
        {
            get { return _shipmentFixEdDay; }
            set { _shipmentFixEdDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsStDay
        /// <summary>入荷開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   入荷開始日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ArrivalGoodsStDay
        {
            get { return _arrivalGoodsStDay; }
            set { _arrivalGoodsStDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsEdDay
        /// <summary>入荷終了日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   入荷終了日プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public DateTime ArrivalGoodsEdDay
        {
            get { return _arrivalGoodsEdDay; }
            set { _arrivalGoodsEdDay = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動元倉庫コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterpriseCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先拠点コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動先倉庫コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   移動状態プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  CellphoneModelCode
        /// <summary>機種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   機種コードプロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public Int32 CellphoneModelCode
        {
            get { return _cellphoneModelCode; }
            set { _cellphoneModelCode = value; }
        }

        /// public propaty name  :  ProductNumber
        /// <summary>製造番号プロパティ</summary>
        /// <value>※「製番なし」の場合、null</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   製造番号プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   企業名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  ReceiveAgentNm
        /// <summary>引取担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   引取担当従業員名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _receiveAgentNm; }
            set { _receiveAgentNm = value; }
        }

        /// public propaty name  :  CellphoneModelName
        /// <summary>機種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   機種名称プロパティ<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public string CellphoneModelName
        {
            get { return _cellphoneModelName; }
            set { _cellphoneModelName = value; }
        }

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// public propaty name  :  CallerFunction
        /// <summary>呼出元機能区分プロパティ</summary>
        /// <value>1:在庫移動入力検索ガイド、2：他の場合</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   呼出元機能区分プロパティ</br>
        /// <br>Programer        :   wangf</br>
        /// </remarks>
        public Int32 CallerFunction
        {
            get { return _callerFunction; }
            set { _callerFunction = value; }
        }
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// <summary>
        /// 在庫移動伝票検索条件コンストラクタ
        /// </summary>
        /// <returns>StockMoveSlipSearchCondクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの新しいインスタンスを生成します<br />
        /// Programer        :   自動生成<br />
        /// </remarks>
        public StockMoveSlipSearchCond()
        {
        }

        /// <summary>
        /// 在庫移動伝票検索条件コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="stockMvEmpCode">在庫移動入力従業員コード(在庫移動伝票を入力する従業員コードをセット)</param>
        /// <param name="shipAgentCd">出荷担当従業員コード(出荷確定処理を行う従業員コードをセット)</param>
        /// <param name="receiveAgentCd">引取担当従業員コード(在庫の入荷側の従業員コードをセット)</param>
        /// <param name="shipmentScdlStDay">出荷予定開始日(在庫移動処理（出荷側）を行った時にセット)</param>
        /// <param name="shipmentScdlEdDay">出荷予定終了日(在庫移動処理（出荷側）を行った時にセット)</param>
        /// <param name="shipmentFixStDay">出荷確定開始日(出荷確定処理（出荷側）を行った時にセット)</param>
        /// <param name="shipmentFixEdDay">出荷確定終了日(出荷確定処理（出荷側）を行った時にセット)</param>
        /// <param name="arrivalGoodsStDay">入荷開始日</param>
        /// <param name="arrivalGoodsEdDay">入荷終了日</param>
        /// <param name="bfSectionCode">移動元拠点コード</param>
        /// <param name="bfEnterWarehCode">移動元倉庫コード</param>
        /// <param name="afEnterpriseCode">移動先拠点コード</param>
        /// <param name="afEnterWarehCode">移動先倉庫コード</param>
        /// <param name="moveStatus">移動状態(0:移動対象外、1:未出荷状態、2:移動中、9:入荷済)</param>
        /// <param name="cellphoneModelCode">機種コード</param>
        /// <param name="productNumber">製造番号(※「製番なし」の場合、null)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="receiveAgentNm">引取担当従業員名称</param>
        /// <param name="cellphoneModelName">機種名称</param>
        /// <param name="callerFunction">呼出元機能区分</param>
        /// <returns>StockMoveSlipSearchCondクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの新しいインスタンスを生成します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        //public StockMoveSlipSearchCond(string enterpriseCode, string sectionCode, Int32 stockMoveSlipNo, string stockMvEmpCode, string shipAgentCd, string receiveAgentCd, DateTime shipmentScdlStDay, DateTime shipmentScdlEdDay, DateTime shipmentFixStDay, DateTime shipmentFixEdDay, DateTime arrivalGoodsStDay, DateTime arrivalGoodsEdDay, string bfSectionCode, string bfEnterWarehCode, string afSectionCode, string afEnterWarehCode, Int32 moveStatus, Int32 cellphoneModelCode, string productNumber, string enterpriseName, string receiveAgentNm, string cellphoneModelName) // DEL wangf 2012/05/22 FOR Redmine#29881
        public StockMoveSlipSearchCond(string enterpriseCode, string sectionCode, Int32 stockMoveSlipNo, string stockMvEmpCode, string shipAgentCd, string receiveAgentCd, DateTime shipmentScdlStDay, DateTime shipmentScdlEdDay, DateTime shipmentFixStDay, DateTime shipmentFixEdDay, DateTime arrivalGoodsStDay, DateTime arrivalGoodsEdDay, string bfSectionCode, string bfEnterWarehCode, string afSectionCode, string afEnterWarehCode, Int32 moveStatus, Int32 cellphoneModelCode, string productNumber, string enterpriseName, string receiveAgentNm, string cellphoneModelName, Int32 callerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._stockMoveSlipNo = stockMoveSlipNo;
            this._stockMvEmpCode = stockMvEmpCode;
            this._shipAgentCd = shipAgentCd;
            this._receiveAgentCd = receiveAgentCd;
            this._shipmentScdlStDay = shipmentScdlStDay;
            this._shipmentScdlEdDay = shipmentScdlEdDay;
            this._shipmentFixStDay = shipmentFixStDay;
            this._shipmentFixEdDay = shipmentFixEdDay;
            this._arrivalGoodsStDay = arrivalGoodsStDay;
            this._arrivalGoodsEdDay = arrivalGoodsEdDay;
            this._bfSectionCode = bfSectionCode;
            this._bfEnterWarehCode = bfEnterWarehCode;
            this._afSectionCode = afSectionCode;
            this._afEnterWarehCode = afEnterWarehCode;
            this._moveStatus = moveStatus;
            this._cellphoneModelCode = cellphoneModelCode;
            this._productNumber = productNumber;
            this._enterpriseName = enterpriseName;
            this._receiveAgentNm = receiveAgentNm;
            this._cellphoneModelName = cellphoneModelName;
            this._callerFunction = callerFunction; // ADD wangf 2012/05/22 FOR Redmine#29881

        }

        /// <summary>
        /// 在庫移動伝票検索条件複製処理
        /// </summary>
        /// <returns>StockMoveSlipSearchCondクラスのインスタンス</returns>
        /// <remarks>
        /// Note　　　　　　 :   自身の内容と等しいStockMoveSlipSearchCondクラスのインスタンスを返します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        public StockMoveSlipSearchCond Clone()
        {
            //return new StockMoveSlipSearchCond(this._enterpriseCode, this._sectionCode, this._stockMoveSlipNo, this._stockMvEmpCode, this._shipAgentCd, this._receiveAgentCd, this._shipmentScdlStDay, this._shipmentScdlEdDay, this._shipmentFixStDay, this._shipmentFixEdDay, this._arrivalGoodsStDay, this._arrivalGoodsEdDay, this._bfSectionCode, this._bfEnterWarehCode, this._afSectionCode, this._afEnterWarehCode, this._moveStatus, this._cellphoneModelCode, this._productNumber, this._enterpriseName, this._receiveAgentNm, this._cellphoneModelName); // DEL wangf 2012/05/22 FOR Redmine#29881
            return new StockMoveSlipSearchCond(this._enterpriseCode, this._sectionCode, this._stockMoveSlipNo, this._stockMvEmpCode, this._shipAgentCd, this._receiveAgentCd, this._shipmentScdlStDay, this._shipmentScdlEdDay, this._shipmentFixStDay, this._shipmentFixEdDay, this._arrivalGoodsStDay, this._arrivalGoodsEdDay, this._bfSectionCode, this._bfEnterWarehCode, this._afSectionCode, this._afEnterWarehCode, this._moveStatus, this._cellphoneModelCode, this._productNumber, this._enterpriseName, this._receiveAgentNm, this._cellphoneModelName, this._callerFunction); // ADD wangf 2012/05/22 FOR Redmine#29881
        }

        /// <summary>
        /// 在庫移動伝票検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveSlipSearchCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの内容が一致するか比較します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        public bool Equals(StockMoveSlipSearchCond target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.StockMvEmpCode == target.StockMvEmpCode)
                 && (this.ShipAgentCd == target.ShipAgentCd)
                 && (this.ReceiveAgentCd == target.ReceiveAgentCd)
                 && (this.ShipmentScdlStDay == target.ShipmentScdlStDay)
                 && (this.ShipmentScdlEdDay == target.ShipmentScdlEdDay)
                 && (this.ShipmentFixStDay == target.ShipmentFixStDay)
                 && (this.ShipmentFixEdDay == target.ShipmentFixEdDay)
                 && (this.ArrivalGoodsStDay == target.ArrivalGoodsStDay)
                 && (this.ArrivalGoodsEdDay == target.ArrivalGoodsEdDay)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.MoveStatus == target.MoveStatus)
                 && (this.CellphoneModelCode == target.CellphoneModelCode)
                 && (this.ProductNumber == target.ProductNumber)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.ReceiveAgentNm == target.ReceiveAgentNm)
                 && (this.CallerFunction == target.CallerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
                 && (this.CellphoneModelName == target.CellphoneModelName));
        }

        /// <summary>
        /// 在庫移動伝票検索条件比較処理
        /// </summary>
        /// <param name="stockMoveSlipSearchCond1">
        ///                    比較するStockMoveSlipSearchCondクラスのインスタンス
        /// </param>
        /// <param name="stockMoveSlipSearchCond2">比較するStockMoveSlipSearchCondクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの内容が一致するか比較します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        public static bool Equals(StockMoveSlipSearchCond stockMoveSlipSearchCond1, StockMoveSlipSearchCond stockMoveSlipSearchCond2)
        {
            return ((stockMoveSlipSearchCond1.EnterpriseCode == stockMoveSlipSearchCond2.EnterpriseCode)
                 && (stockMoveSlipSearchCond1.SectionCode == stockMoveSlipSearchCond2.SectionCode)
                 && (stockMoveSlipSearchCond1.StockMoveSlipNo == stockMoveSlipSearchCond2.StockMoveSlipNo)
                 && (stockMoveSlipSearchCond1.StockMvEmpCode == stockMoveSlipSearchCond2.StockMvEmpCode)
                 && (stockMoveSlipSearchCond1.ShipAgentCd == stockMoveSlipSearchCond2.ShipAgentCd)
                 && (stockMoveSlipSearchCond1.ReceiveAgentCd == stockMoveSlipSearchCond2.ReceiveAgentCd)
                 && (stockMoveSlipSearchCond1.ShipmentScdlStDay == stockMoveSlipSearchCond2.ShipmentScdlStDay)
                 && (stockMoveSlipSearchCond1.ShipmentScdlEdDay == stockMoveSlipSearchCond2.ShipmentScdlEdDay)
                 && (stockMoveSlipSearchCond1.ShipmentFixStDay == stockMoveSlipSearchCond2.ShipmentFixStDay)
                 && (stockMoveSlipSearchCond1.ShipmentFixEdDay == stockMoveSlipSearchCond2.ShipmentFixEdDay)
                 && (stockMoveSlipSearchCond1.ArrivalGoodsStDay == stockMoveSlipSearchCond2.ArrivalGoodsStDay)
                 && (stockMoveSlipSearchCond1.ArrivalGoodsEdDay == stockMoveSlipSearchCond2.ArrivalGoodsEdDay)
                 && (stockMoveSlipSearchCond1.BfSectionCode == stockMoveSlipSearchCond2.BfSectionCode)
                 && (stockMoveSlipSearchCond1.BfEnterWarehCode == stockMoveSlipSearchCond2.BfEnterWarehCode)
                 && (stockMoveSlipSearchCond1.AfSectionCode == stockMoveSlipSearchCond2.AfSectionCode)
                 && (stockMoveSlipSearchCond1.AfEnterWarehCode == stockMoveSlipSearchCond2.AfEnterWarehCode)
                 && (stockMoveSlipSearchCond1.MoveStatus == stockMoveSlipSearchCond2.MoveStatus)
                 && (stockMoveSlipSearchCond1.CellphoneModelCode == stockMoveSlipSearchCond2.CellphoneModelCode)
                 && (stockMoveSlipSearchCond1.ProductNumber == stockMoveSlipSearchCond2.ProductNumber)
                 && (stockMoveSlipSearchCond1.EnterpriseName == stockMoveSlipSearchCond2.EnterpriseName)
                 && (stockMoveSlipSearchCond1.ReceiveAgentNm == stockMoveSlipSearchCond2.ReceiveAgentNm)
                 && (stockMoveSlipSearchCond1.CallerFunction == stockMoveSlipSearchCond2.CallerFunction) // ADD wangf 2012/05/22 FOR Redmine#29881
                 && (stockMoveSlipSearchCond1.CellphoneModelName == stockMoveSlipSearchCond2.CellphoneModelName));
        }
        /// <summary>
        /// 在庫移動伝票検索条件比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveSlipSearchCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの内容が一致するか比較しし、一致しない項目の名称を返します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        public ArrayList Compare(StockMoveSlipSearchCond target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.StockMvEmpCode != target.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (this.ShipAgentCd != target.ShipAgentCd) resList.Add("ShipAgentCd");
            if (this.ReceiveAgentCd != target.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (this.ShipmentScdlStDay != target.ShipmentScdlStDay) resList.Add("ShipmentScdlStDay");
            if (this.ShipmentScdlEdDay != target.ShipmentScdlEdDay) resList.Add("ShipmentScdlEdDay");
            if (this.ShipmentFixStDay != target.ShipmentFixStDay) resList.Add("ShipmentFixStDay");
            if (this.ShipmentFixEdDay != target.ShipmentFixEdDay) resList.Add("ShipmentFixEdDay");
            if (this.ArrivalGoodsStDay != target.ArrivalGoodsStDay) resList.Add("ArrivalGoodsStDay");
            if (this.ArrivalGoodsEdDay != target.ArrivalGoodsEdDay) resList.Add("ArrivalGoodsEdDay");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.MoveStatus != target.MoveStatus) resList.Add("MoveStatus");
            if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
            if (this.ProductNumber != target.ProductNumber) resList.Add("ProductNumber");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.ReceiveAgentNm != target.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (this.CellphoneModelName != target.CellphoneModelName) resList.Add("CellphoneModelName");
            if (this.CallerFunction != target.CallerFunction) resList.Add("CallerFunction"); // ADD wangf 2012/05/22 FOR Redmine#29881

            return resList;
        }

        /// <summary>
        /// 在庫移動伝票検索条件比較処理
        /// </summary>
        /// <param name="stockMoveSlipSearchCond1">比較するStockMoveSlipSearchCondクラスのインスタンス</param>
        /// <param name="stockMoveSlipSearchCond2">比較するStockMoveSlipSearchCondクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// Note　　　　　　 :   StockMoveSlipSearchCondクラスの内容が一致するか比較し、一致しない項目の名称を返します<br />
        /// Programer        :   自動生成<br />
        /// Update Note      :   2012/05/22 wangf<br />
        ///                  :   10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveSlipSearchCond stockMoveSlipSearchCond1, StockMoveSlipSearchCond stockMoveSlipSearchCond2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveSlipSearchCond1.EnterpriseCode != stockMoveSlipSearchCond2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveSlipSearchCond1.SectionCode != stockMoveSlipSearchCond2.SectionCode) resList.Add("SectionCode");
            if (stockMoveSlipSearchCond1.StockMoveSlipNo != stockMoveSlipSearchCond2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveSlipSearchCond1.StockMvEmpCode != stockMoveSlipSearchCond2.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (stockMoveSlipSearchCond1.ShipAgentCd != stockMoveSlipSearchCond2.ShipAgentCd) resList.Add("ShipAgentCd");
            if (stockMoveSlipSearchCond1.ReceiveAgentCd != stockMoveSlipSearchCond2.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (stockMoveSlipSearchCond1.ShipmentScdlStDay != stockMoveSlipSearchCond2.ShipmentScdlStDay) resList.Add("ShipmentScdlStDay");
            if (stockMoveSlipSearchCond1.ShipmentScdlEdDay != stockMoveSlipSearchCond2.ShipmentScdlEdDay) resList.Add("ShipmentScdlEdDay");
            if (stockMoveSlipSearchCond1.ShipmentFixStDay != stockMoveSlipSearchCond2.ShipmentFixStDay) resList.Add("ShipmentFixStDay");
            if (stockMoveSlipSearchCond1.ShipmentFixEdDay != stockMoveSlipSearchCond2.ShipmentFixEdDay) resList.Add("ShipmentFixEdDay");
            if (stockMoveSlipSearchCond1.ArrivalGoodsStDay != stockMoveSlipSearchCond2.ArrivalGoodsStDay) resList.Add("ArrivalGoodsStDay");
            if (stockMoveSlipSearchCond1.ArrivalGoodsEdDay != stockMoveSlipSearchCond2.ArrivalGoodsEdDay) resList.Add("ArrivalGoodsEdDay");
            if (stockMoveSlipSearchCond1.BfSectionCode != stockMoveSlipSearchCond2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveSlipSearchCond1.BfEnterWarehCode != stockMoveSlipSearchCond2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveSlipSearchCond1.AfSectionCode != stockMoveSlipSearchCond2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveSlipSearchCond1.AfEnterWarehCode != stockMoveSlipSearchCond2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveSlipSearchCond1.MoveStatus != stockMoveSlipSearchCond2.MoveStatus) resList.Add("MoveStatus");
            if (stockMoveSlipSearchCond1.CellphoneModelCode != stockMoveSlipSearchCond2.CellphoneModelCode) resList.Add("CellphoneModelCode");
            if (stockMoveSlipSearchCond1.ProductNumber != stockMoveSlipSearchCond2.ProductNumber) resList.Add("ProductNumber");
            if (stockMoveSlipSearchCond1.EnterpriseName != stockMoveSlipSearchCond2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMoveSlipSearchCond1.ReceiveAgentNm != stockMoveSlipSearchCond2.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (stockMoveSlipSearchCond1.CellphoneModelName != stockMoveSlipSearchCond2.CellphoneModelName) resList.Add("CellphoneModelName");
            if (stockMoveSlipSearchCond1.CallerFunction != stockMoveSlipSearchCond2.CallerFunction) resList.Add("CallerFunction"); // ADD wangf 2012/05/22 FOR Redmine#29881

            return resList;
        }
    }
}
