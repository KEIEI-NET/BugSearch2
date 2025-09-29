using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;


namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 締日算出モジュール
    /// </summary>
    /// <remarks>
    /// <br>Note       : 締次・月次更新の締日を取得するクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.07.31</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/01/21 22018 鈴木 正臣</br>
    /// <br>           : ①締日チェック処理の場合、処理前にキャッシュをクリアして必ずDBから取得するよう変更。</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/03/09 22018 鈴木 正臣</br>
    /// <br>           : ①全拠点で一番進んでいる月次更新日の取得機能を追加</br>
    /// <br>           :   （拠点=String.Emptyで指定）</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/03/11 22018 鈴木 正臣</br>
    /// <br>           : ①月次未締の拠点で取得した時の不具合を修正</br>
    /// <br>           :   （2009/03/09変更が原因）</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/07 22018 鈴木 正臣</br>
    /// <br>           : ①全拠点で一番進んでいる売上/仕入締日の取得機能を追加</br>
    /// <br>           :   2009/03/09変更と同様、履歴請求/履歴支払にそれぞれ組み込み</br>
    /// <br></br>
    /// <br>UpdateNote : 2009/04/16 22018 鈴木 正臣</br>
    /// <br>           : ①履歴請求/履歴支払の次回締日算出は</br>
    /// <br>           :   常に、請求全体設定の00:全社のレコードを使用するよう変更。</br>
    /// <br></br>
    /// </remarks>
    /// <example>インスタンスの取得方法<br/>
    /// TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();<br/>
    /// </example>
    public class TotalDayCalculator
    {
        // ===================================================================================== //
        // static privateフィールド
        // ===================================================================================== //
        // Singletonインスタンス
        static private TotalDayCalculator stc_totalDayCalculator;

        // ===================================================================================== //
        // private定数
        // ===================================================================================== //
        # region [private定数]
        // 全社指定拠点コード
        private const string ct_AllSectionCode = "00";
        # endregion

        // ===================================================================================== //
        // privateフィールド
        // ===================================================================================== //
        # region [private フィールド]
        // データテーブル
        private DataTable _tableOfHisMonthly;    // 履歴・月次
        private DataTable _tableOfHisDmdC;       // 履歴・請求
        private DataTable _tableOfHisPayment;    // 履歴・支払
        private DataTable _tableOfPrcAccRec;     // 金額・月次売掛
        private DataTable _tableOfPrcAccPay;     // 金額・月次買掛
        private DataTable _tableOfPrcDmdC;       // 金額・請求
        private DataTable _tableOfPrcPayment;    // 金額・支払

        // リモート
        private ITtlDayCalcDB _iTtlDayCalcDB;

        // 企業コード
        private string _enterpriseCode;

        // マスタ同時取得区分
        private int _withMasterDiv;

        // 広域リモート取得時 開始日付
        private int _startDate;

        // 履歴・月次　初期処理済みフラグ
        private bool _extractedHisMonthly;
        // 履歴・請求　初期処理済みフラグ
        private bool _extractedHisDmdC;
        // 履歴・支払　初期処理済みフラグ
        private bool _extractedHisPayment;

        // 会計年度テーブル取得部品
        private FinYearTableGenerator _finYearTableGenerator;

        // 自社情報マスタ
        private CompanyInfWork _companyInfWork;
        // 請求全体設定マスタリスト
        private List<BillAllStWork> _billAllStWorkList;

        // 買掛オプションフラグ（false:買掛なし／true:買掛あり）
        private bool _enableOptionAccPay;

        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region [private プロパティ]
        /// <summary>
        /// マスタ同時取得区分　プロパティ
        /// </summary>
        private int WithMasterDiv
        {
            set { _withMasterDiv = value; }
            get 
            {
                // getすると次回はゼロになっている。
                int div = _withMasterDiv;
                _withMasterDiv = 0;

                return div;
            }
        }
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region [private コンストラクタ]
        /// <summary>
        /// private コンストラクタ
        /// </summary>
        private TotalDayCalculator()
        {
            // リモートオブジェクト取得
            _iTtlDayCalcDB = MediationTtlDayCalcDB.GetTtlDayCalcDB();

            // 企業コード
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // マスタ同時取得区分
            this.WithMasterDiv = 1; // 1:取得する

            // 広域リモート取得開始日付（システム日付の６ヶ月前を指定）
            _startDate = TotalDayCalculator.GetLongDate( DateTime.Today.AddMonths( -6 ) );

            // 履歴系抽出済みフラグ
            _extractedHisMonthly = false;
            _extractedHisDmdC = false;
            _extractedHisPayment = false;

            // 買掛オプションフラグ
            _enableOptionAccPay = true;
        }
        # endregion

        // ===================================================================================== //
        // static パブリックメソッド
        // ===================================================================================== //
        # region [インスタンス取得]
        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>TotalDayCalculatorインスタンス</returns>
        ///
        /// <remarks>締日算出モジュールクラスのインスタンスを取得します。<br/>
        /// このクラスはsingletonであり、newキーワードにより外部でインスタンス生成することは出来ません。<br/>
        /// </remarks>
        /// <example>インスタンス取得方法<br/>
        /// TotalDayCalculator ttlDayCalc = TotalDayCalculator.GetInstance();
        /// </example>
        public static TotalDayCalculator GetInstance()
        {
            if (stc_totalDayCalculator == null)
            {
                stc_totalDayCalculator = new TotalDayCalculator();
            }
            return stc_totalDayCalculator;
        }
        # endregion

        // ===================================================================================== //
        // public メソッド
        // ===================================================================================== //

        # region [①履歴・月次売掛]
        /// <summary>
        /// 初期処理【履歴・月次売掛】
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthlyAccRecの初期処理を行います。<br/>
        /// この処理を行わなかった場合も、GetHisTotalDayMonthlyAccRec内で同様の処理が実行されます。<br/>
        /// 初回実行時のオーバーヘッドを改善したい場合には、あらかじめこの初期処理を実行して下さい。<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthlyAccRec();</example>
        public int InitializeHisMonthlyAccRec()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛の前回締処理日・今回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccRec( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccRec( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [②履歴・月次買掛]
        /// <summary>
        /// 初期処理【履歴・月次買掛】
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthlyAccPayの初期処理を行います。<br/>
        /// この処理を行わなかった場合も、GetHisTotalDayMonthlyAccPay内で同様の処理が実行されます。<br/>
        /// 初回実行時のオーバーヘッドを改善したい場合には、あらかじめこの初期処理を実行して下さい。<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthlyAccPay();</example>
        public int InitializeHisMonthlyAccPay()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// 締日取得処理【履歴・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の買掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の買掛の前回締処理日・今回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthlyAccPay( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthlyAccPay( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyAccPayProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [③履歴・月次売掛＆買掛]
        /// <summary>
        /// 初期処理【月次売掛＆買掛】
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayMonthlyの初期処理を行います。<br/>
        /// この処理を行わなかった場合も、GetHisTotalDayMonthly内で同様の処理が実行されます。<br/>
        /// 初回実行時のオーバーヘッドを改善したい場合には、あらかじめこの初期処理を実行して下さい。<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisMonthly();</example>
        public int InitializeHisMonthly()
        {
            return InitializeHisMonthlyProc();
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛＆買掛の前回締処理日を算出します。<br/>
        /// 売掛と買掛で締処理日が異なる場合、古い方の日付を返します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛＆買掛の前回締処理日・今回締処理日を算出します。<br/>
        /// 売掛と買掛で締処理日が異なる場合、古い方の日付を返します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛＆買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 売掛と買掛で締処理日が異なる場合、古い方の日付を返します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            int convertProcessDivCd;
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>月次締更新履歴マスタを元に、拠点毎の売掛＆買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 売掛と買掛で締処理日が異なる場合、古い方の日付を返します。<br/>
        /// </remarks>
        /// <example>月次更新ＵＩ、月次締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayMonthly( "01", out stDate, out edDate, out stMonth, out edMonth, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayMonthly( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            return GetHisTotalDayMonthlyProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
        }
        # endregion

        # region [④履歴・請求]
        /// <summary>
        /// 初期処理【履歴・請求】
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayDmdCの初期処理を行います。<br/>
        /// この処理を行わなかった場合も、GetHisTotalDayDmdC内で同様の処理が実行されます。<br/>
        /// 初回実行時のオーバーヘッドを改善したい場合には、あらかじめこの初期処理を実行して下さい。<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisDmdC();</example>
        public int InitializeHisDmdC()
        {
            return InitializeHisDmdCProc();
        }
        /// <summary>
        /// 締日取得処理【履歴・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>請求締更新履歴マスタを元に、拠点毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、請求締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// 締日取得処理【履歴・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>請求締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、請求締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// 締日取得処理【履歴・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>請求締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、請求締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary>
        /// 締日取得処理【履歴・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <param name="startCAddUpUpdDate">(出力)締更新開始日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>請求締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、請求締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayDmdC( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayDmdC( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        {
            return GetHisTotalDayDmdCProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        # endregion

        # region [⑤履歴・支払]
        /// <summary>
        /// 初期処理【履歴・支払】
        /// </summary>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>GetHisTotalDayPaymentの初期処理を行います。<br/>
        /// この処理を行わなかった場合も、GetHisTotalDayPayment内で同様の処理が実行されます。<br/>
        /// 初回実行時のオーバーヘッドを改善したい場合には、あらかじめこの初期処理を実行して下さい。<br/>
        /// </remarks>
        /// <example>int status = ttlDayCalc.InitializeHisPayment();</example>
        public int InitializeHisPayment()
        {
            return InitializeHisPaymentProc();
        }
        /// <summary>
        /// 締日取得処理【履歴・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>支払締更新履歴マスタを元に、拠点毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、支払締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// 締日取得処理【履歴・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>支払締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、支払締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            int convertProcessDivCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        /// <summary>
        /// 締日取得処理【履歴・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>支払締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、支払締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
            //return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            DateTime startCAddUpUpdDate;
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary>
        /// 締日取得処理【履歴・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <param name="startCAddUpUpdDate">(出力)締更新開始日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>支払締更新履歴マスタを元に、拠点毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日の算出には、請求全体設定マスタの登録内容を使用します。（例：15日,20日,31日でローテーション）<br/>
        /// </remarks>
        /// <example>締更新ＵＩ、支払締に関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int convert;
        /// int status = ttlDayCalc.GetHisTotalDayPayment( "01", out stDate, out edDate, out convert );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetHisTotalDayPayment( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        {
            return GetHisTotalDayPaymentProc( sectionCode, out prevTotalDay, out currentTotalDay, out convertProcessDivCd, out startCAddUpUpdDate );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        # endregion

        # region [⑥金額・月次売掛]
        # region (拠点指定)
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( string sectionCode, int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccRecProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次売掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccRecProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        # endregion
        # region (拠点指定なし)
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次売掛】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、得意先毎の売掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// DateTime stMonth;<br/>
        /// DateTime edMonth;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccRec( 12345678, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccRec( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccRecProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次売掛】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( int customerCode, DateTime date)
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccRecProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次売掛】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先売掛金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccRec( 12345678, date );<br/>
        /// </example>
        public bool CheckMonthlyAccRec( int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccRecProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [⑦金額・月次買掛]
        # region (拠点指定)
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( string sectionCode, int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccPayProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccPayProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # region (拠点指定なし)
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締日取得処理【金額・月次買掛】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、仕入先毎の買掛の前回締処理日・今回締処理日・前回締処理月・今回締処理月を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>※通常はこの処理は使用しません。（月次の締は拠点毎の更新の為）<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayMonthlyAccPay( 123456, out stDate, out edDate, out stMonth, out edMonth );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayMonthlyAccPay( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            return GetTotalDayMonthlyAccPayProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次買掛】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckMonthlyAccPayProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・月次買掛】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先買掛金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckMonthlyAccPay( 123456, date );<br/>
        /// </example>
        public bool CheckMonthlyAccPay( int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckMonthlyAccPayProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [⑧金額・請求]
        # region (拠点指定)
        /// <summary>
        /// 締日取得処理【金額・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、得意先毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>請求締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayDmdC( string sectionCode, int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締日取得処理【金額・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、得意先毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>請求締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayDmdC( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( string sectionCode, int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckDmdCProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・請求】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckDmdCProc( sectionCode, customerCode, date, out prevTotalDay );
        }
        # endregion
        # region (拠点指定なし)
        /// <summary>
        /// 締日取得処理【金額・請求】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、得意先毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>請求締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayDmdC( int customerCode, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayDmdCProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締日取得処理【金額・請求】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、得意先毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>請求締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayDmdC( 12345678, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayDmdC( int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayDmdCProc( string.Empty, customerCode, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・請求】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( int customerCode, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckDmdCProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・請求】
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>得意先請求金額マスタを元に、指定得意先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckDmdC( 12345678, date );<br/>
        /// </example>
        public bool CheckDmdC( int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            return CheckDmdCProc( string.Empty, customerCode, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [⑨金額・支払]
        # region (拠点指定)
        /// <summary>
        /// 締日取得処理【金額・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、仕入先毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>支払締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayPayment( string sectionCode, int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締日取得処理【金額・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、仕入先毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>支払締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayPayment( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( string sectionCode, int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckPaymentProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・支払】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckPaymentProc( sectionCode, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # region (拠点指定なし)
        /// <summary>
        /// 締日取得処理【金額・支払】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、仕入先毎の前回締処理日を算出します。<br/>
        /// </remarks>
        /// <example>支払締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayPayment( int supplierCd, out DateTime prevTotalDay )
        {
            DateTime currentTotalDay;
            return GetTotalDayPaymentProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締日取得処理【金額・支払】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、仕入先毎の前回締処理日・今回締処理日を算出します。<br/>
        /// 今回締処理日は、常に前回締処理日の１ヶ月後を返します。<br/>
        /// </remarks>
        /// <example>支払締めに関する帳票・照会など<br/><br/>
        /// DateTime stDate;<br/>
        /// DateTime edDate;<br/>
        /// int status = ttlDayCalc.GetTotalDayPayment( 123456, out stDate, out edDate );<br/>
        /// stDate = stDate.AddDays( 1 );  // 前回締の翌日<br/>
        /// </example>
        public int GetTotalDayPayment( int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            return GetTotalDayPaymentProc( string.Empty, supplierCd, out prevTotalDay, out currentTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・支払】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( int supplierCd, DateTime date )
        {
            DateTime prevTotalDay;
            return CheckPaymentProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        /// <summary>
        /// 締更新済チェック処理【金額・支払】
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        /// 
        /// <remarks>仕入先支払金額マスタを元に、指定仕入先に関して、指定日付の締更新済みチェックを行います。<br/>
        /// </remarks>
        /// <example>各種エントリなど<br/><br/>
        /// DateTime date = new DateTime( 2008, 1, 1 );<br/>
        /// bool closed = ttlDayCalc.CheckPayment( 123456, date );<br/>
        /// </example>
        public bool CheckPayment( int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            return CheckPaymentProc( string.Empty, supplierCd, date, out prevTotalDay );
        }
        # endregion
        # endregion

        # region [キャッシュクリア処理]
        /// <summary>
        /// キャッシュクリア処理
        /// </summary>
        /// <remarks>アクセスクラス内部で保持しているリモート取得データキャッシュをクリアします。<br/>
        /// 意図的にリモート呼び出しによりデータ取得したい場合に使用して下さい。<br/>
        /// </remarks>
        public void ClearCache()
        {
            ClearCacheProc();
        }
        # endregion

        // ===================================================================================== //
        // private メソッド
        // ===================================================================================== //

        # region [①履歴・月次売掛]
        /// <summary>
        /// 初期処理（履歴・月次共通）
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>この処理は【履歴・月次売掛】と【履歴・月次買掛】で共通です。</br>
        /// </remarks>
        private int InitializeHisMonthlyProc()
        {
            // 初期処理済み
            if ( _extractedHisMonthly ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // 拠点は指定しないが、日付は制限する。
                // ( 広く浅く取る )
                //---------------------------------------------

                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisMonthly = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// 展開処理（履歴・月次共通）
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        /// <remarks>
        /// <br>この処理は【履歴・月次売掛】と【履歴・月次買掛】で共通です。</br>
        /// </remarks>
        private void DevelopResultOfHisMonthly( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
            // 全拠点の前回締処理日
            DateTime allSectionPrevDate = DateTime.MinValue;
            // 全拠点のコンバート処理区分
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
            
            // テーブル生成
            if ( _tableOfHisMonthly == null )
            {
                _tableOfHisMonthly = PMCMN00101EA.CreateTableOfHisMonthly();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { retWork.ProcDiv, retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisMonthly.NewRow();

                    row[PMCMN00101EA.ct_Col_ProcDiv] = retWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 DEL
                    //row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfHisMonthly.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
                    // 全社結果(全拠点で一番大きい値を使用)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/09 ADD
            // 全社結果(全拠点で一番大きい値を使用)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { paraWork.ProcDiv, string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisMonthly.NewRow();
                    row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisMonthly.Rows.Add( row );
                }
                else
                {
                    // 既存レコードがあれば現在値を退避
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // 既存レコードがある場合は大きい方を採用
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/09 ADD
        }
        /// <summary>
        /// 締日取得処理（履歴・月次売掛）
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="currentTotalDay"></param>
        /// <param name="prevTotalMonth"></param>
        /// <param name="currentTotalMonth"></param>
        /// <param name="convertProcessDivCd"></param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyAccRecProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            // 初期処理呼び出し
            InitializeHisMonthlyProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;
            convertProcessDivCd = 0;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// 全社
            //if ( row == null ) 
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            // 再度リモート
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// 再度全社
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccRec, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 締処理日に基づく各種日付算出（月次用）
        /// </summary>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>この処理は【履歴・月次売掛】【履歴・月次買掛】【金額・月次売掛】【金額・月次買掛】で共通です。</br>
        /// </remarks>
        private void ReflectTotalDayForMonthly( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // 未算出なら算出する
                //**********************************************************

                # region [各種日付算出]
                // 前回処理日
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // 今回処理日
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( prevTotalDay );

                // 前回処理日→前回処理月
                DateTime outDate;
                _finYearTableGenerator.GetYearMonth( prevTotalDay, out outDate );
                row[PMCMN00101EA.ct_Col_PrevTotalMonth] = outDate;

                // 今回処理日→今回処理月
                _finYearTableGenerator.GetYearMonth( (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay], out outDate );
                row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = outDate;
                # endregion

                // 算出済みフラグ
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// 今回締処理日取得処理（単純な翌月取得）
        /// </summary>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>今回締処理日</returns>
        private DateTime GetCurrentTotalDayOfNextMonth( DateTime prevTotalDay )
        {
            // 前回処理日→今回処理日
            if ( prevTotalDay.Day >= 28 )
            {
                //-----------------------------------
                // xxxx.08.31 31>=28なので末日扱い
                //  ↓
                // xxxx.08.28 固定で28にする
                //  ↓
                // xxxx.09.28 AddMonthsで１ヶ月進める
                //  ↓
                // xxxx.09.30 DaysInMonthで末日にする
                //-----------------------------------

                // 末日扱い
                DateTime dateTime = (new DateTime( prevTotalDay.Year, prevTotalDay.Month, 28 )).AddMonths( 1 );
                return new DateTime( dateTime.Year, dateTime.Month, DateTime.DaysInMonth( dateTime.Year, dateTime.Month ) );
            }
            else
            {
                // 末日以外
                return prevTotalDay.AddMonths( 1 );
            }
        }
        # endregion

        # region [②履歴・月次買掛]
        /// <summary>
        /// 締日取得処理（履歴・月次買掛）
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="prevTotalDay"></param>
        /// <param name="currentTotalDay"></param>
        /// <param name="prevTotalMonth"></param>
        /// <param name="currentTotalMonth"></param>
        /// <param name="convertProcessDivCd"></param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyAccPayProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            // 初期処理呼び出し
            InitializeHisMonthlyProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;
            convertProcessDivCd = 0;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// 全社
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            // 再度リモート
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;
                paraWork.ProcDiv = PMCMN00101EA.ct_ProcDiv_AccPay; 

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisMonthly( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisMonthly( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
            //// 再度全社
            //if ( row == null )
            //{
            //    row = _tableOfHisMonthly.Rows.Find( new object[] { PMCMN00101EA.ct_ProcDiv_AccPay, string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion

        # region [③履歴・月次売掛＆買掛]
        /// <summary>
        /// 締日取得処理【履歴・月次売掛＆買掛】
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <returns></returns>
        private int GetHisTotalDayMonthlyProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth, out int convertProcessDivCd )
        {
            int status;

            if ( _enableOptionAccPay )
            {
                //--------------------------------------------
                // 買掛オプション：あり
                //--------------------------------------------
                # region [買掛あり]
                // 初期化
                prevTotalDay = DateTime.MinValue;
                currentTotalDay = DateTime.MinValue;
                prevTotalMonth = DateTime.MinValue;
                currentTotalMonth = DateTime.MinValue;
                convertProcessDivCd = 0;

                DateTime[] retPrevTotalDay = new DateTime[2];
                DateTime[] retCurrentTotalDay = new DateTime[2];
                DateTime[] retPrevTotalMonth = new DateTime[2];
                DateTime[] retCurrentTotalMonth = new DateTime[2];
                int[] retConvertProcessDivCd = new int[2];

                // 売掛
                status = GetHisTotalDayMonthlyAccRecProc( sectionCode, out retPrevTotalDay[0], out retCurrentTotalDay[0], out retPrevTotalMonth[0], out retCurrentTotalMonth[0], out retConvertProcessDivCd[0] );
                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                // 買掛
                status = GetHisTotalDayMonthlyAccPayProc( sectionCode, out retPrevTotalDay[1], out retCurrentTotalDay[1], out retPrevTotalMonth[1], out retCurrentTotalMonth[1], out retConvertProcessDivCd[1] );
                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                //--------------------------------------
                // 売掛処理日と買掛処理日を比較（小さい方を採用）
                //--------------------------------------
                if ( retPrevTotalDay[0] >= retPrevTotalDay[1] )
                {
                    // 売掛≧買掛　→　買掛を返す
                    prevTotalDay = retPrevTotalDay[1];
                    currentTotalDay = retCurrentTotalDay[1];
                    prevTotalMonth = retPrevTotalMonth[1];
                    currentTotalMonth = retCurrentTotalMonth[1];
                    convertProcessDivCd = retConvertProcessDivCd[1];
                }
                else
                {
                    // 売掛＜買掛　→　売掛を返す
                    prevTotalDay = retPrevTotalDay[0];
                    currentTotalDay = retCurrentTotalDay[0];
                    prevTotalMonth = retPrevTotalMonth[0];
                    currentTotalMonth = retCurrentTotalMonth[0];
                    convertProcessDivCd = retConvertProcessDivCd[0];
                }
                # endregion
            }
            else
            {
                //--------------------------------------------
                // 買掛オプション：なし
                //--------------------------------------------
                # region [買掛なし]
                // 売掛のみ呼び出すのと同じ
                status = GetHisTotalDayMonthlyAccRecProc( sectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth, out convertProcessDivCd );
                # endregion
            }
            return status;
        }
        # endregion

        # region [④履歴・請求]
        /// <summary>
        /// 初期処理（履歴・請求）
        /// </summary>
        /// <returns>STATUS</returns>
        private int InitializeHisDmdCProc()
        {
            // 初期処理済み
            if ( _extractedHisDmdC ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // 拠点は指定しないが、日付は制限する。
                // ( 広く浅く取る )
                //---------------------------------------------

                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.CustomerCode = 0;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisDmdC( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisDmdC = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// 展開処理（履歴・請求）
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfHisDmdC( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // 全拠点の前回締処理日
            DateTime allSectionPrevDate = DateTime.MinValue;
            // 全拠点のコンバート処理区分
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 全拠点の締処理開始日
            DateTime allSectionStartCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            // テーブル生成
            if ( _tableOfHisDmdC == null )
            {
                _tableOfHisDmdC = PMCMN00101EA.CreateTableOfHisDmdC();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisDmdC.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
                    //row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = retWork.StartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

                    _tableOfHisDmdC.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    // 全社結果(全拠点で一番大きい値を使用)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                        allSectionStartCAddUpUpdDate = retWork.StartCAddUpUpdDate;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // 全社結果(全拠点で一番大きい値を使用)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisDmdC.NewRow();
                    //row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisDmdC.Rows.Add( row );
                }
                else
                {
                    // 既存レコードがあれば現在値を退避
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // 既存レコードがある場合は大きい方を採用
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = allSectionStartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
        }
        /// <summary>
        /// 締日取得処理（履歴・請求売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <param name="startCAddUpUpdDate">(出力)締更新開始日</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        //private int GetHisTotalDayDmdCProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        private int GetHisTotalDayDmdCProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        {
            // 初期処理呼び出し
            InitializeHisDmdCProc();


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            convertProcessDivCd = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfHisDmdC.Rows.Find( new object[] { sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// 全社
            //if ( row == null )
            //{
            //    row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            // 再度リモート
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = 0;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisDmdC( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfHisDmdC.Rows.Find( new object[] { sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// 再度全社
            //if ( row == null )
            //{
            //    row = _tableOfHisDmdC.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForHisDmdC( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = (DateTime)row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 締処理日に基づく各種日付算出（履歴請求用）
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForHisDmdC( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // 未算出なら算出する
                //**********************************************************

                // 前回締処理日
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // 請求全体設定取得
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
                //BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, (string)row[PMCMN00101EA.ct_Col_SectionCode] );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
                // 締日取得は常に00:全社のレコードから
                BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, ct_AllSectionCode );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

                List<int> totalDay = new List<int>( new int[]{
                                        billAllSt.CustomerTotalDay1, billAllSt.CustomerTotalDay2, billAllSt.CustomerTotalDay3,
                                        billAllSt.CustomerTotalDay4, billAllSt.CustomerTotalDay5, billAllSt.CustomerTotalDay6,
                                        billAllSt.CustomerTotalDay7, billAllSt.CustomerTotalDay8, billAllSt.CustomerTotalDay9,
                                        billAllSt.CustomerTotalDay10, billAllSt.CustomerTotalDay11, billAllSt.CustomerTotalDay12
                                    } );

                // 今回締処理日を取得（請求）
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfDmd( totalDay, prevTotalDay );

                // 算出済みフラグ
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }

        /// <summary>
        /// 今回締処理日算出処理（請求・支払用）
        /// </summary>
        /// <param name="totalDayList">締日("日")リスト</param>
        /// <param name="prevTotalDay">前回締処理日(yyyy/mm/dd)</param>
        /// <returns>今回締処理日</returns>
        private DateTime GetCurrentTotalDayOfDmd( List<int> totalDayList, DateTime prevTotalDay )
        {
            DateTime retCurrentTotalDay;

            //--------------------------------------------
            // 前回締処理日の"日"を取得
            //--------------------------------------------
            int dayOfPrevTotalDay = prevTotalDay.Day;
            // 末日取得
            if ( dayOfPrevTotalDay >= 28 )
            {
                dayOfPrevTotalDay = 31;
            }

            //--------------------------------------------
            // 今回締処理日の"日"を取得
            //--------------------------------------------

            // ソートする。
            // （totalDayListには"0"も含まれる）
            totalDayList.Sort();

            int dayOfCurrentTotalDay = 0;
            for ( int index = 0; index < totalDayList.Count; index++ )
            {
                //-----------------------------------------------------------------
                // 【MEMO】
                // 
                //   totalDayListには"0"も含まれる。
                //   例として [ 15, 20, 31 ]でローテーションする場合、
                //
                //     0,0,0,0,0,0,0,0,0,15,20,31 
                //   
                //   先頭から見ていき、0で無い最小の値＝15を退避しておく。
                //   
                //   前回の締日("日")
                //     15 → 20をセットしてbreak
                //     20 → 31をセットしてbreak
                //     31 → ループを抜けるが、最初に15をセット済みなので結果ＯＫ
                // 
                //   -------------------------------------------------
                //   ちなみに、
                //     0,0,0,0,0,0,0,0,0,0,0,31　の場合
                //   
                //   最初に31を退避した時点でcontinueして、そのままループを抜ける。
                //-----------------------------------------------------------------

                // ゼロではない最小の締日を退避しておく
                if ( dayOfCurrentTotalDay == 0 && totalDayList[index] > 0 )
                {
                    dayOfCurrentTotalDay = totalDayList[index];
                    continue;
                }

                // 前回締処理日の"日"を超える締日を見つけた時点で終了
                if ( totalDayList[index] > dayOfPrevTotalDay )
                {
                    dayOfCurrentTotalDay = totalDayList[index];
                    break;
                }
            }

            //--------------------------------------------
            // 今回締処理日を算出
            //--------------------------------------------

            // まず、前回締処理日からyyyy/mmだけコピーする
            retCurrentTotalDay = new DateTime( prevTotalDay.Year, prevTotalDay.Month, 1 );

            // 翌月判定（"日"同士で大小比較する）
            //if ( dayOfPrevTotalDay > dayOfCurrentTotalDay )
            if ( dayOfPrevTotalDay >= dayOfCurrentTotalDay )
            {
                // 翌月に進める
                retCurrentTotalDay = retCurrentTotalDay.AddMonths( 1 );
            }

            // 末日判定
            if ( dayOfCurrentTotalDay >= 28 )
            {
                // 末日（"日"はその月内の日数に等しい）
                retCurrentTotalDay = new DateTime( retCurrentTotalDay.Year, retCurrentTotalDay.Month,
                                                    DateTime.DaysInMonth( retCurrentTotalDay.Year, retCurrentTotalDay.Month ) );
            }
            else
            {
                // 末日以外（"日"は取得結果のまま）
                retCurrentTotalDay = new DateTime( retCurrentTotalDay.Year, retCurrentTotalDay.Month, dayOfCurrentTotalDay );
            }

            return retCurrentTotalDay;
        }
        # endregion

        # region [⑤履歴・支払]
        /// <summary>
        /// 初期処理（履歴・支払）
        /// </summary>
        /// <returns>STATUS</returns>
        private int InitializeHisPaymentProc()
        {
            // 初期処理済み
            if ( _extractedHisPayment ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                //---------------------------------------------
                // 拠点は指定しないが、日付は制限する。
                // ( 広く浅く取る )
                //---------------------------------------------

                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SupplierCd = 0;
                paraWork.St_Date = _startDate;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisPayment( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );
                _extractedHisPayment = true;

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
            }
            catch ( Exception )
            {
            }

            return status;
        }
        /// <summary>
        /// 展開処理（履歴・支払）
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfHisPayment( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // 全拠点の前回締処理日
            DateTime allSectionPrevDate = DateTime.MinValue;
            // 全拠点のコンバート処理区分
            int allSectionConvProcDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 全拠点の締更新開始日
            DateTime allSectionStartCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            // テーブル生成
            if ( _tableOfHisPayment == null )
            {
                _tableOfHisPayment = PMCMN00101EA.CreateTableOfHisPayment();
            }

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfHisPayment.Rows.Find( new object[] { retWork.SectionCode } );
                if ( row == null )
                {
                    row = _tableOfHisPayment.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = retWork.SectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    DateTime prevTotalDay = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = prevTotalDay;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = retWork.ConvertProcessDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = retWork.StartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

                    _tableOfHisPayment.Rows.Add( row );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
                    // 全社結果(全拠点で一番大きい値を使用)
                    if ( allSectionPrevDate < prevTotalDay )
                    {
                        allSectionPrevDate = prevTotalDay;
                        allSectionConvProcDivCd = retWork.ConvertProcessDivCd;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                        allSectionStartCAddUpUpdDate = retWork.StartCAddUpUpdDate;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 ADD
            // 全社結果(全拠点で一番大きい値を使用)
            if ( allSectionPrevDate != DateTime.MinValue )
            {
                DateTime prevTotalDay = DateTime.MinValue;
                DataRow row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
                if ( row == null )
                {
                    row = _tableOfHisPayment.NewRow();
                    //row[PMCMN00101EA.ct_Col_ProcDiv] = paraWork.ProcDiv;
                    row[PMCMN00101EA.ct_Col_SectionCode] = string.Empty;
                    _tableOfHisPayment.Rows.Add( row );
                }
                else
                {
                    // 既存レコードがあれば現在値を退避
                    prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
                }

                // 既存レコードがある場合は大きい方を採用
                if ( prevTotalDay < allSectionPrevDate )
                {
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = allSectionPrevDate;
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    //row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_ConvertProcessDivCd] = allSectionConvProcDivCd;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate] = allSectionStartCAddUpUpdDate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 ADD
        }
        /// <summary>
        /// 締日取得処理（履歴・支払売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="convertProcessDivCd">(出力)コンバート処理区分</param>
        /// <param name="startCAddUpUpdDate">(出力)締更新開始日</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 DEL
        //private int GetHisTotalDayPaymentProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        private int GetHisTotalDayPaymentProc( string sectionCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out int convertProcessDivCd, out DateTime startCAddUpUpdDate )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
        {
            // 初期処理呼び出し
            InitializeHisPaymentProc();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            convertProcessDivCd = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfHisPayment.Rows.Find( new object[] { sectionCode } );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// 全社
            //if ( row == null )
            //{
            //    row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            // 再度リモート
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = 0;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchHisPayment( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfHisPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfHisPayment.Rows.Find( new object[] { sectionCode } );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/07 DEL
            //// 再度全社
            //if ( row == null )
            //{
            //    row = _tableOfHisPayment.Rows.Find( new object[] { string.Empty } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/07 DEL

            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForHisPayment( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            convertProcessDivCd = (Int32)row[PMCMN00101EA.ct_Col_ConvertProcessDivCd];
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            startCAddUpUpdDate = (DateTime)row[PMCMN00101EA.ct_Col_StartCAddUpUpdDate];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 締処理日に基づく各種日付算出（履歴支払用）
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForHisPayment( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // 未算出なら算出する
                //**********************************************************

                // 前回締処理日
                DateTime prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];

                // 支払全体設定取得
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
                //BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, (string)row[PMCMN00101EA.ct_Col_SectionCode] );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
                // 締日取得は常に00:全社のレコードから
                BillAllStWork billAllSt = FindBillAllSt( _billAllStWorkList, ct_AllSectionCode );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

                List<int> totalDay = new List<int>( new int[]{
                                        billAllSt.SupplierTotalDay1, billAllSt.SupplierTotalDay2, billAllSt.SupplierTotalDay3,
                                        billAllSt.SupplierTotalDay4, billAllSt.SupplierTotalDay5, billAllSt.SupplierTotalDay6,
                                        billAllSt.SupplierTotalDay7, billAllSt.SupplierTotalDay8, billAllSt.SupplierTotalDay9,
                                        billAllSt.SupplierTotalDay10, billAllSt.SupplierTotalDay11, billAllSt.SupplierTotalDay12
                                    } );

                // 今回締処理日を取得（支払）
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfDmd( totalDay, prevTotalDay );

                // 算出済みフラグ
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        # endregion

        # region [⑥金額・月次売掛]
        /// <summary>
        /// 締日取得処理（金額・月次売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayMonthlyAccRecProc( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            sectionCode = sectionCode.Trim();

            // テーブル生成
            if ( _tableOfPrcAccRec == null )
            {
                _tableOfPrcAccRec = PMCMN00101EA.CreateTableOfPrcAccRec();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfPrcAccRec.Rows.Find( new object[] { sectionCode, customerCode } );
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = customerCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcMonthlyAccRec( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfAccRec( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfPrcAccRec.Rows.Find( new object[] { sectionCode, customerCode } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 展開処理（金額・月次売掛）
        /// </summary>
        /// <param name="customSerializeArrayList">リモート取得データ</param>
        /// <param name="paraWork">検索条件パラメータ</param>
        private void DevelopResultOfAccRec( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// テーブル生成
            //if ( _tableOfPrcAccRec == null )
            //{
            //    _tableOfPrcAccRec = PMCMN00101EA.CreateTableOfPrcAccRec();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfPrcAccRec.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.CustomerCode } );
                if ( row == null )
                {
                    row = _tableOfPrcAccRec.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_CustomerCode] = retWork.CustomerCode;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcAccRec.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// 締更新済チェック処理（金額・月次売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        private bool CheckMonthlyAccRecProc( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // キャッシュクリア
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int status = GetTotalDayMonthlyAccRecProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );

            // MinValueならば未締め
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // エラーならば、入力許可しない意味で締済みにする
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:締済み, false:未締め
            return ( date <= prevTotalDay );
        }
        # endregion

        # region [⑦金額・月次買掛]
        /// <summary>
        /// 締日取得処理（金額・月次買掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <param name="prevTotalMonth">(出力)前回締処理月</param>
        /// <param name="currentTotalMonth">(出力)今回締処理月</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayMonthlyAccPayProc( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay, out DateTime prevTotalMonth, out DateTime currentTotalMonth )
        {
            sectionCode = sectionCode.Trim();

            // テーブル生成
            if ( _tableOfPrcAccPay == null )
            {
                _tableOfPrcAccPay = PMCMN00101EA.CreateTableOfPrcAccPay();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;
            prevTotalMonth = DateTime.MinValue;
            currentTotalMonth = DateTime.MinValue;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfPrcAccPay.Rows.Find( new object[] { sectionCode, supplierCd } );
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = supplierCd;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcMonthlyAccPay( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfAccPay( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfPrcAccPay.Rows.Find( new object[] { sectionCode, supplierCd } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForMonthly( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];
            prevTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalMonth];
            currentTotalMonth = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalMonth];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 展開処理（金額・月次買掛）
        /// </summary>
        /// <param name="customSerializeArrayList">リモート取得データ</param>
        /// <param name="paraWork">検索条件パラメータ</param>
        private void DevelopResultOfAccPay( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// テーブル生成
            //if ( _tableOfPrcAccPay == null )
            //{
            //    _tableOfPrcAccPay = PMCMN00101EA.CreateTableOfPrcAccPay();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfPrcAccPay.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.SupplierCd } );
                if ( row == null )
                {
                    row = _tableOfPrcAccPay.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_SupplierCd] = retWork.SupplierCd;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_PrevTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_CurrentTotalMonth] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcAccPay.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// 締更新済チェック処理（金額・月次買掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        private bool CheckMonthlyAccPayProc( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // キャッシュクリア
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            int status = GetTotalDayMonthlyAccPayProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth );

            // MinValueならば未締め
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // エラーならば、入力許可しない意味で締済みにする
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:締済み, false:未締め
            return (date <= prevTotalDay);
        }
        # endregion

        # region [⑧金額・請求]
        /// <summary>
        /// 締日取得処理（金額・請求売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayDmdCProc( string sectionCode, int customerCode, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            sectionCode = sectionCode.Trim();

            // テーブル生成
            if ( _tableOfPrcDmdC == null )
            {
                _tableOfPrcDmdC = PMCMN00101EA.CreateTableOfPrcDmdC();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfPrcDmdC.Rows.Find( new object[] { sectionCode, customerCode } );
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.CustomerCode = customerCode;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcDmdC( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfDmdC( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfPrcDmdC.Rows.Find( new object[] { sectionCode, customerCode } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForPrcDmdC( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 展開処理（金額・請求）
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfDmdC( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// テーブル生成
            //if ( _tableOfPrcDmdC == null )
            //{
            //    _tableOfPrcDmdC = PMCMN00101EA.CreateTableOfPrcDmdC();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfPrcDmdC.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.CustomerCode } );
                if ( row == null )
                {
                    row = _tableOfPrcDmdC.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_CustomerCode] = retWork.CustomerCode;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcDmdC.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// 各種日付算出処理
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForPrcDmdC( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // 未算出なら算出する
                //**********************************************************

                // 今回締処理日
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay] );

                // 算出済みフラグ
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// 締更新済チェック処理（金額・月次買掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        private bool CheckDmdCProc( string sectionCode, int customerCode, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // キャッシュクリア
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            int status = GetTotalDayDmdCProc( sectionCode, customerCode, out prevTotalDay, out currentTotalDay );

            // MinValueならば未締め
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // エラーならば、入力許可しない意味で締済みにする
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:締済み, false:未締め
            return (date <= prevTotalDay);
        }
        # endregion

        # region [⑨金額・支払]
        /// <summary>
        /// 締日取得処理（金額・支払売掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="prevTotalDay">(出力)前回締処理日</param>
        /// <param name="currentTotalDay">(出力)今回締処理日</param>
        /// <returns>STATUS</returns>
        private int GetTotalDayPaymentProc( string sectionCode, int supplierCd, out DateTime prevTotalDay, out DateTime currentTotalDay )
        {
            sectionCode = sectionCode.Trim();

            // テーブル生成
            if ( _tableOfPrcPayment == null )
            {
                _tableOfPrcPayment = PMCMN00101EA.CreateTableOfPrcPayment();
            }

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;
            currentTotalDay = DateTime.MinValue;

            //--------------------------------------------
            // DataTableから検索・無ければリモート
            //--------------------------------------------
            DataRow row = _tableOfPrcPayment.Rows.Find( new object[] { sectionCode, supplierCd } );
            if ( row == null )
            {
                # region [随時リモート抽出]
                // 検索パラメータ生成
                TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
                paraWork.EnterpriseCode = _enterpriseCode;
                paraWork.SectionCode = sectionCode;
                paraWork.SupplierCd = supplierCd;
                paraWork.WithMasterDiv = this.WithMasterDiv;

                // リモート呼び出し
                object retObj;
                status = _iTtlDayCalcDB.SearchPrcPayment( out retObj, paraWork );

                // 結果の展開
                DevelopResultOfPayment( ((retObj as CustomSerializeArrayList)[0] as CustomSerializeArrayList), paraWork );

                if ( paraWork.WithMasterDiv > 0 )
                {
                    // マスタ展開
                    DevelopResultOfMaster( ((retObj as CustomSerializeArrayList)[1] as CustomSerializeArrayList), paraWork );
                }
                # endregion

                // 再度DataTableから検索
                row = _tableOfPrcPayment.Rows.Find( new object[] { sectionCode, supplierCd } );
            }
            if ( row == null ) return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //--------------------------------------------
            // 各種日付を算出
            //--------------------------------------------
            ReflectTotalDayForPrcPayment( ref row );

            //--------------------------------------------
            // 算出結果をセット
            //--------------------------------------------
            prevTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay];
            currentTotalDay = (DateTime)row[PMCMN00101EA.ct_Col_CurrentTotalDay];

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        /// <summary>
        /// 展開処理（金額・支払）
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfPayment( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            //// テーブル生成
            //if ( _tableOfPrcPayment == null )
            //{
            //    _tableOfPrcPayment = PMCMN00101EA.CreateTableOfPrcPayment();
            //}

            for ( int index = 0; index < customSerializeArrayList.Count; index++ )
            {
                TtlDayCalcRetWork retWork = (customSerializeArrayList[index] as TtlDayCalcRetWork);

                // 重複チェックしてなければ追加
                DataRow row = _tableOfPrcPayment.Rows.Find( new object[] { paraWork.SectionCode.Trim(), retWork.SupplierCd } );
                if ( row == null )
                {
                    row = _tableOfPrcPayment.NewRow();

                    row[PMCMN00101EA.ct_Col_SectionCode] = paraWork.SectionCode.Trim();
                    row[PMCMN00101EA.ct_Col_SupplierCd] = retWork.SupplierCd;
                    row[PMCMN00101EA.ct_Col_PrevTotalDay] = TotalDayCalculator.GetDateTime( retWork.TotalDay );
                    row[PMCMN00101EA.ct_Col_CurrentTotalDay] = DateTime.MinValue;
                    row[PMCMN00101EA.ct_Col_RemotedFlag] = 1;
                    row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 0;

                    _tableOfPrcPayment.Rows.Add( row );
                }
            }
        }
        /// <summary>
        /// 各種日付算出処理
        /// </summary>
        /// <param name="row"></param>
        private void ReflectTotalDayForPrcPayment( ref DataRow row )
        {
            if ( (int)row[PMCMN00101EA.ct_Col_CurrentCalcFlag] <= 0 )
            {
                //**********************************************************
                // 未算出なら算出する
                //**********************************************************

                // 今回締処理日
                row[PMCMN00101EA.ct_Col_CurrentTotalDay] = GetCurrentTotalDayOfNextMonth( (DateTime)row[PMCMN00101EA.ct_Col_PrevTotalDay] );

                // 算出済みフラグ
                row[PMCMN00101EA.ct_Col_CurrentCalcFlag] = 1;
            }
        }
        /// <summary>
        /// 締更新済チェック処理（金額・月次買掛）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierCd">得意先コード</param>
        /// <param name="date">日付</param>
        /// <param name="prevTotalDay">前回締処理日</param>
        /// <returns>true:締済み, false:未締め</returns>
        private bool CheckPaymentProc( string sectionCode, int supplierCd, DateTime date, out DateTime prevTotalDay )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // キャッシュクリア
            ClearCacheProc();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD

            prevTotalDay = DateTime.MinValue;
            DateTime currentTotalDay;
            int status = GetTotalDayPaymentProc( sectionCode, supplierCd, out prevTotalDay, out currentTotalDay );

            // MinValueならば未締め
            if ( prevTotalDay == DateTime.MinValue )
            {
                return false;
            }
            // エラーならば、入力許可しない意味で締済みにする
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                return true;
            }
            // true:締済み, false:未締め
            return (date <= prevTotalDay);
        }
        # endregion

        # region [キャッシュクリア処理]
        /// <summary>
        /// キャッシュクリア処理
        /// </summary>
        private void ClearCacheProc()
        {
            // 履歴系の抽出済みフラグを解除
            _extractedHisMonthly = false;
            _extractedHisDmdC = false;
            _extractedHisPayment = false;

            // データテーブルをクリア
            _tableOfHisDmdC = null;
            _tableOfHisMonthly = null;
            _tableOfHisPayment = null;
            _tableOfPrcAccPay = null;
            _tableOfPrcAccRec = null;
            _tableOfPrcDmdC = null;
            _tableOfPrcPayment = null;

            // マスタ同時取得フラグをセット
            this.WithMasterDiv = 1;     // 1:取得する

            // マスタ退避フィールドクリア
            _companyInfWork = null;     // 自社情報マスタ
            _billAllStWorkList = null;  // 請求全体設定マスタリスト
        }
        # endregion

        # region [マスタ展開処理]
        /// <summary>
        /// マスタ展開処理
        /// </summary>
        /// <param name="customSerializeArrayList"></param>
        /// <param name="paraWork"></param>
        private void DevelopResultOfMaster( CustomSerializeArrayList customSerializeArrayList, TtlDayCalcParaWork paraWork )
        {
            foreach ( object obj in customSerializeArrayList )
            {
                if ( obj is CompanyInfWork[] )
                {
                    // 自社情報マスタ
                    _companyInfWork = (obj as CompanyInfWork[])[0];

                    // 会計年度テーブル生成
                    _finYearTableGenerator = new FinYearTableGenerator( _companyInfWork );
                }
                else if ( obj is BillAllStWork[] )
                {
                    // 請求全体設定マスタ
                    _billAllStWorkList = new List<BillAllStWork>( (obj as BillAllStWork[]) );
                }
            }
        }
        # endregion

        # region [共通処理]
        /// <summary>
        /// LongDate取得処理(yyyy/mm/dd → yyyymmdd)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static int GetLongDate( DateTime dt )
        {
            if ( dt == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ((dt.Year * 10000) + (dt.Month * 100) + dt.Day);
            }
        }
        /// <summary>
        /// DateTime取得処理(yyyymmdd → yyyy/mm/dd)
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private static DateTime GetDateTime( int longDate )
        {
            if ( longDate == 0 )
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return new DateTime( longDate / 10000, (longDate / 100) % 100, longDate % 100 );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }
        /// <summary>
        /// 請求全体設定レコード取得処理
        /// </summary>
        /// <param name="billAllStWorkList"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private static BillAllStWork FindBillAllSt( List<BillAllStWork> billAllStWorkList, string sectionCode )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
            //// 請求全体設定取得
            //BillAllStWork billAllSt = billAllStWorkList.Find(
            //                                delegate( BillAllStWork work )
            //                                {
            //                                    return (work.SectionCode.TrimEnd() == sectionCode.TrimEnd());
            //                                } );
            //if ( billAllSt == null )
            //{
            //    // 全社設定を参照する
            //    billAllSt = billAllStWorkList.Find(
            //                                delegate( BillAllStWork work )
            //                                {
            //                                    return (work.SectionCode.TrimEnd() == ct_AllSectionCode || work.SectionCode.TrimEnd() == string.Empty);
            //                                } );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // 締日取得は常に00:全社設定を参照する
            BillAllStWork billAllSt = billAllStWorkList.Find(
                                        delegate( BillAllStWork work )
                                        {
                                            return (work.SectionCode.TrimEnd() == ct_AllSectionCode || work.SectionCode.TrimEnd() == string.Empty);
                                        } );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            return billAllSt;
        }
        # endregion
    }
}
