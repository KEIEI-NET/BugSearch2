using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchParaClaimSalesRead
    /// <summary>
    ///                      請求売上データ検索パラメータクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求売上データ検索パラメータクラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/01 22018 鈴木正臣</br>
    /// <br>                 :   　入金伝票入力の「未入金一覧表」に対応する為、項目追加。</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchParaClaimSalesRead
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>計上日付(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _addUpADateStart;

        /// <summary>計上日付(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _addUpADateEnd;

        /// <summary>請求計上拠点コード</summary>
        /// <remarks>文字型</remarks>
        private string _demandAddUpSecCd = "";

        /// <summary>実績計上拠点コード</summary>
        /// <remarks>実績計上を行う企業内の拠点コード</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>引当済売上伝票呼出区分</summary>
        /// <remarks>0：引当済、!=0：未引当</remarks>
        private Int32 _alwcSalesSlipCall;

        /// <summary>販売従業員コード</summary>
        /// <remarks>計上担当者</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>伝票検索日付(開始)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _searchSlipDateStart;

        /// <summary>伝票検索日付(終了)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _searchSlipDateEnd;

        //--- DEL 2008/07/10 M.Kubota --->>>
        ///// <summary>サービス伝票区分</summary>
        ///// <remarks>0:OFF,1:ON</remarks>
        //private Int32 _serviceSlipCd;
        //--- DEL 2008/07/10 M.Kubota ---<<<

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>自動入金区分</summary>
        /// <remarks>0:通常入金,1:自動入金</remarks>
        private Int32 _autoDepositCd;

        // --- ADD m.suzuki 2010/07/01 ---------->>>>>
        /// <summary>入力日（開始）</summary>
        private Int32 _inputDateStart;
        /// <summary>入力日（終了）</summary>
        private Int32 _inputDateEnd;
        /// <summary>請求拠点コード(開始)</summary>
        /// <remarks></remarks>
        private string _demandAddUpSecCdStart = "";
        /// <summary>請求拠点コード(終了)</summary>
        /// <remarks></remarks>
        private string _demandAddUpSecCdEnd = "";
        /// <summary>請求得意先コード(開始)</summary>
        /// <remarks></remarks>
        private int _claimCodeStart;
        /// <summary>請求得意先コード(終了)</summary>
        /// <remarks></remarks>
        private int _claimCodeEnd;
        // --- ADD m.suzuki 2010/07/01 ----------<<<<<

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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
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

        /// public propaty name  :  AddUpADateStart
        /// <summary>計上日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateStart
        {
            get { return _addUpADateStart; }
            set { _addUpADateStart = value; }
        }

        /// public propaty name  :  AddUpADateEnd
        /// <summary>計上日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateEnd
        {
            get { return _addUpADateEnd; }
            set { _addUpADateEnd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCd
        /// <summary>請求計上拠点コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCd
        {
            get { return _demandAddUpSecCd; }
            set { _demandAddUpSecCd = value; }
        }

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>実績計上拠点コードプロパティ</summary>
        /// <value>実績計上を行う企業内の拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
        }

        /// public propaty name  :  AlwcSalesSlipCall
        /// <summary>引当済売上伝票呼出区分プロパティ</summary>
        /// <value>0：引当済、!=0：未引当</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引当済売上伝票呼出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AlwcSalesSlipCall
        {
            get { return _alwcSalesSlipCall; }
            set { _alwcSalesSlipCall = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>計上担当者</value>
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

        /// public propaty name  :  SearchSlipDateStart
        /// <summary>伝票検索日付(開始)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateStart
        {
            get { return _searchSlipDateStart; }
            set { _searchSlipDateStart = value; }
        }

        /// public propaty name  :  SearchSlipDateEnd
        /// <summary>伝票検索日付(終了)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索日付(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchSlipDateEnd
        {
            get { return _searchSlipDateEnd; }
            set { _searchSlipDateEnd = value; }
        }

        //--- DEL 2008/07/10 M.Kubota --->>>
        ///// public propaty name  :  ServiceSlipCd
        ///// <summary>サービス伝票区分プロパティ</summary>
        ///// <value>0:OFF,1:ON</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   サービス伝票区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 ServiceSlipCd
        //{
        //    get { return _serviceSlipCd; }
        //    set { _serviceSlipCd = value; }
        //}
        //--- DEL 2008/07/10 M.Kubota ---<<<

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

        /// public propaty name  :  AutoDepositCd
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:通常入金,1:自動入金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        // --- ADD m.suzuki 2010/07/01 ---------->>>>>
        /// public propaty name  :  InputDateStart
        /// <summary>入力日(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDateStart
        {
            get { return _inputDateStart; }
            set { _inputDateStart = value; }
        }

        /// public propaty name  :  InputDateEnd
        /// <summary>入力日(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InputDateEnd
        {
            get { return _inputDateEnd; }
            set { _inputDateEnd = value; }
        }

        /// public propaty name  :  DemandAddUpSecCdStart
        /// <summary>請求拠点コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCdStart
        {
            get { return _demandAddUpSecCdStart; }
            set { _demandAddUpSecCdStart = value; }
        }

        /// public propaty name  :  DemandAddUpSecCdEnd
        /// <summary>請求拠点コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCdEnd
        {
            get { return _demandAddUpSecCdEnd; }
            set { _demandAddUpSecCdEnd = value; }
        }

        /// public propaty name  :  ClaimCodeStart
        /// <summary>請求得意先コード(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求得意先コード(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ClaimCodeStart
        {
            get { return _claimCodeStart; }
            set { _claimCodeStart = value; }
        }
        /// public propaty name  :  ClaimCodeEnd
        /// <summary>請求得意先コード(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求得意先コード(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ClaimCodeEnd
        {
            get { return _claimCodeEnd; }
            set { _claimCodeEnd = value; }
        }
        // --- ADD m.suzuki 2010/07/01 ----------<<<<<


        /// <summary>
        /// 請求売上データ検索パラメータクラスワークコンストラクタ
        /// </summary>
        /// <returns>SearchParaClaimSalesReadクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchParaClaimSalesReadクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchParaClaimSalesRead()
        {
        }

    }
}
