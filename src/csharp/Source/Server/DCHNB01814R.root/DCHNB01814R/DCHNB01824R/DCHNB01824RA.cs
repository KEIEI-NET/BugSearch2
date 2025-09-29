using System;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Broadleaf.Library;
using Broadleaf.Library.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

//■─ファイルレイアウト変更時の修正について…────────────────────────■
//　ファイルレイアウトに変更があった場合は以下の文字列を頼りに修正を行って下さい。
//　　売上データ　　 → ＠売上データ変更＠
//　　売上明細データ → ＠売上明細データ変更＠
//■─────────────────────────────────────────────■

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   SCM対応</br>
    /// <br>Programmer       :   22008 長内</br>
    /// <br>Date             :   2009/05/18</br>
    /// <br></br>
    /// <br>Update Note      :   得意先電子元帳の過去分赤伝対応の為、今まで考慮されていなかった不具合修正</br>
    /// <br>Programmer       :   22018 鈴木 正臣</br>
    /// <br>Date             :   2009/10/19</br>
    /// <br></br>
    /// <br>Update Note      :   ＳＣＭ対応</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2010/04/13</br>
    /// <br></br>
    /// <br>Update Note      :   READUNCOMMITTED対応</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2010/06/11</br>
    /// <br></br>
    /// <br>Update Note      :   ６次改良 2010/06/11 の組込</br>
    /// <br>Programmer       :   22018 鈴木 正臣</br>
    /// <br>Date             :   2010/06/24</br>
    /// <br></br>
    /// <br>Update Note      :   得意先電子元帳で掛売で赤伝発行した場合に返品可能数が増える現象の修正。条件の追加</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2010/10/08</br>
    /// <br></br>
    /// <br>Update Note      :   障害改良対応　貸出計上した売上伝票を更新時にエラー発生する件の修正</br>
    /// <br>             　　　　　　　        (貸出計上残区分＝残さない、の場合)</br>
    /// <br>Programmer       :   22018 鈴木 正臣</br>
    /// <br>Date             :   2011/04/21</br>
    /// <br></br>
    /// <br>Update Note      :   伝票更新時、削除明細分の受注マスタが論理削除されない件の対応</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2011/04/26</br>
    /// <br></br>
    /// <br>Update Note      :   自動回答区分(SCM)追加の対応</br>
    /// <br>Programmer       :   duzg</br>
    /// <br>Date             :   2011/07/23</br>
    /// <br>Update Note      :   PCCUOE自動回答の対応</br>
    /// <br>Programmer       :   高峰</br>
    /// <br>Date             :   2011/08/10</br>
    /// <br></br>
    /// <br>Update Note      :   送信済みのチェック方法を追加</br>
    /// <br>Programmer       :   qijh</br>
    /// <br>Date             :   2011/07/25</br>
    /// <br></br>
    /// <br>Update Note      :   売上データ、売上明細取得方法を追加</br>
    /// <br>Programmer       :   qijh</br>
    /// <br>Date             :   2011/08/17</br>
    /// <br></br>
    /// <br>Update Note      :   送信済みのチェックは売上データに対してのみ行う様に変更(#25578)</br>
    /// <br>Programmer       :   sundx</br>
    /// <br>Date             :   2011/09/27</br>
    /// <br></br>
    /// <br>Update Note      :   送信済みのチェックは、元黒伝票は対象外にするように修正</br>
    /// <br>Programmer       :   長内 数馬</br>
    /// <br>Date             :   2011/09/27</br>
    /// <br>Update Note      :   redmine#26228 拠点管理改良／伝票日付による抽出対応</br>
    /// <br>Programmer       :   xupz</br>
    /// <br>Date             :   2011/11/10</br>
    /// <br>Update Note      :   readmine #8412</br>
    /// <br>Programmer       :   liusy</br>
    /// <br>Date             :   2011/12/02</br>
    /// <br>Update Note      :   2011/12/15 tianjw</br>
    /// <br>                     Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br></br>
    /// <br>Update Note      :   SF表示項目追加対応（特記事項の追加）</br>
    /// <br>Programmer       :   20073 西 毅</br>
    /// <br>Date             :   2012/01/23</br>
    /// <br>Update Note      :   2012/02/06 田建委</br>
    /// <br>管理番号         :   10707327-00 2012/03/28配信分</br>
    /// <br>                     Redmine#28288 送信済データ修正制御の対応</br>
    /// <br>Update Note      :   2012/02/06 丁建雄</br>
    /// <br>管理番号         :   10707327-00 2012/03/28配信分</br>
    /// <br>                     Redmine#28336 得意先伝票番号採番の不具合の対応</br>
    /// <br></br>
    /// <br>Update Note      :   仕入先情報追加</br>
    /// <br>Programmer       :   20073 西 毅</br>
    /// <br>Date             :   2012/05/07</br>
    /// <br></br>
    /// <br>Update Note      :   拠点管理 送信済データチェック不具合対応</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/08/10</br>
    /// <br></br>
    /// <br>Update Note      :   障害対応(「受注計上残区分：残さない」で計上した売上伝票が伝票修正で呼出せない障害の修正)</br>
    /// <br>Programmer       :   脇田 靖之</br>
    /// <br>Date             :   2012/09/27</br>
    /// </remarks>
    [Serializable]
    public class SalesSlipDB : RemoteWithAppLockDB, ISalesSlipDB , IFunctionCallTargetRead, IFunctionCallTargetWrite//,IFunctionCallTargetNewEntry// , IFunctionCallTargetRedBlackWrite
    {
        //--- ADD 2008/03/03 M.Kubota --->>>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプション プロパティ
        /// </summary>
        public IOWriteCtrlOptWork IOWriteCtrlOptWork
        {
            get
            {
                if (this._CtrlOptWork == null)
                {
                    this._CtrlOptWork = new IOWriteCtrlOptWork();
                }
                
                return this._CtrlOptWork;
            }

            set
            {
                if (this._CtrlOptWork != value)
                {
                    this._CtrlOptWork = value;
                }
            }
        }
        //--- ADD 2008/03/03 M.Kubota ---<<<

        private AcceptOdrDB _AcceptOdr = null;

        /// <summary>
        /// 受注マスタリモート プロパティ
        /// </summary>
        private AcceptOdrDB AcceptOdr
        {
            get
            {
                if (this._AcceptOdr == null)
                {
                    this._AcceptOdr = new AcceptOdrDB();
                }

                return this._AcceptOdr;
            }
        }

        //--- ADD 2008/12/24 M.Kubota --->>>
        private CustSlipNoSetDB _CstSlpNoSetDb = null;

        /// <summary>
        /// 得意先マスタ(伝票番号)リモート プロパティ
        /// </summary>
        private CustSlipNoSetDB CstSlpNoSetDb
        {
            get
            {
                if (this._CstSlpNoSetDb == null)
                {
                    this._CstSlpNoSetDb = new CustSlipNoSetDB();
                }

                return this._CstSlpNoSetDb;
            }
        }
        //--- ADD 2008/12/24 M.Kubota ---<<<

        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 送信済チェック失敗のステータス
        /// </summary>
        private const int STATUS_CHK_SEND_ERR = -1001;

        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// 拠点管理送受信対象設定マスタリモートプロパティ
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }

        private SecMngSetDB _SecMngSetDB = null;
        /// <summary>
        /// 拠点管理設定マスタリモートプロパティ
        /// </summary>
        private SecMngSetDB ScMngSetDB
        {
            get
            {
                if (this._SecMngSetDB == null)
                    this._SecMngSetDB = new SecMngSetDB();
                return this._SecMngSetDB;
            }
        }
        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        /// <summary>
		/// 売上データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 21112　久保田　誠</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
        public SalesSlipDB()
            :
            base("DCHNB01826D", "Broadleaf.Application.Remoting.ParamData.SalesSlipWork", "SALESSLIPRF")
		{
        }

        #region [NewEntry  DC.NSの段階から使用していないので凍結]
#if false
        /// <summary>
        /// 売上データの初期項目を読込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データの初期項目を読込みます</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        public int NewEntry(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。初期処理パラメータが未指定です");
                    return status;
                }

                SalesSlipNewEntryWork salesSlipNewEntryWork = null;
                SalesSlipWork salesSlipWork = null;
                Int32 listPos_SalesSlipWork = -1;

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。データベース接続情報パラメータが未指定です");
                    return status;
                }

                //●伝票パラメータオブジェクトの取得(カスタムArray内から検索)
                if (paraList == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。初期処理パラメータListが未指定です");
                    return status;
                }
                else if (paraList.Count > 0) salesSlipNewEntryWork = paraList[position] as SalesSlipNewEntryWork;
                if (salesSlipNewEntryWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。売上NewEntry結果が取得出来ません");
                    return status;
                }

                //●売上NewEntry結果取得
                //  ※現時点では特に無し

                //●伝票更新List内の仕入データクラスを抽出
                salesSlipWork = MakeSalesSlipWork(retList, out listPos_SalesSlipWork);
                if (salesSlipWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。更新対象売上オブジェクトパラメータが未指定です。");
                    return status;
                }

                //●初期処理結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList[position] = salesSlipNewEntryWork;
                    retList.Add(salesSlipWork);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.NewEntry:" + ex.Message);
            }

            return status;
        }
#endif
#endregion

        #region [Read]　読込処理　ヘッダ・明細・詳細
        /// <summary>
        /// 売上データを読込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データを読込みます</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        public int Read(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●読込パラメータ
                SalesSlipReadWork salesSlipReadWork = null;

                //●読込結果格納用
                SalesSlipWork salesSlipWork = null;
                ArrayList salesDetailWorks = null;
                ArrayList addUpOrgSalesDetailWorks = null;

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": データベース接続情報パラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上更新オブジェクトの取得(カスタムArray内から検索)
                if (paraList == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象パラメータListが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                else if (paraList.Count > 0) salesSlipReadWork = paraList[position] as SalesSlipReadWork;
                if (salesSlipReadWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上Read
                status = this.ReadSalesSlipWork(out salesSlipWork, salesSlipReadWork, ref sqlConnection);

                //●売上明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = ReadSalesDetailWork(out salesDetailWorks, salesSlipReadWork, ref sqlConnection);
                }

                //●計上元売上明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    SqlTransaction sqlTransaction = null;
                    status = ReadAddUpSalesDetailWork(out addUpOrgSalesDetailWorks, salesDetailWorks, ref sqlConnection, ref sqlTransaction);
                }

                //●読込結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上データをセット
                    retList.Add(salesSlipWork);

                    // 売上明細データをセット
                    if (salesDetailWorks != null)
                    {
                        retList.Add(salesDetailWorks);
                    }

                    // 計上元 売上明細データをセット
                    if (addUpOrgSalesDetailWorks != null && addUpOrgSalesDetailWorks.Count > 0)
                    {
                        retList.Add(addUpOrgSalesDetailWorks);
                    }

                    paraList[position] = salesSlipReadWork;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// 売上データを読込みます(他リモートオブジェクトから呼び出し)
        /// </summary>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データを読込みます(他リモートオブジェクトから呼び出し)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        public int Read(ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●読込パラメータ
                SalesSlipReadWork salesSlipReadWork = null;

                //●読込結果格納用
                SalesSlipWork salesSlipWork = null;
                ArrayList salesDetailWorks = null;
                ArrayList addUpOrgSalesDetailWorks = null;

                SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];
                ArrayList[] copySalesDetailWorks = new ArrayList[0];

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": データベース接続情報パラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (paraList == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象パラメータListが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                else if (paraList.Count > 0) salesSlipReadWork = paraList[position] as SalesSlipReadWork;
                if (salesSlipReadWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 読込対象オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●売上Read
                status = ReadSalesSlipWork(out salesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                //●売上明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = ReadSalesDetailWork(out salesDetailWorks, ref copySalesDetailWorks, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
                }

                //●計上元売上明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = ReadAddUpSalesDetailWork(out addUpOrgSalesDetailWorks, salesDetailWorks, ref sqlConnection, ref sqlTransaction);
                }

                //●読込結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 売上データをセット
                    retList.Add(salesSlipWork);

                    // 売上明細データをセット
                    if (salesDetailWorks != null)
                    {
                        retList.Add(salesDetailWorks);
                    }

                    // 計上元 売上明細データをセット
                    if (addUpOrgSalesDetailWorks != null && addUpOrgSalesDetailWorks.Count > 0)
                    {
                        retList.Add(addUpOrgSalesDetailWorks);
                    }

                    paraList[position] = salesSlipReadWork;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        # region [売上データ読み込み]

        /// <summary>
        /// 指定された企業コードの売上データを戻します
        /// </summary>
        /// <param name="salesSlipWork">読込結果</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの売上データを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        public int ReadSalesSlipWork(out SalesSlipWork salesSlipWork, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];

            return ReadSalesSlipWork(out salesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        // ADD 2011/08/17 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
        /// <summary>
        /// 売上データを取得(論理削除データを含む)
        /// </summary>
        /// <param name="salesSlipWork">読込結果</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
        public int ReadSalesSlipWorkIgnoreDel(out SalesSlipWork salesSlipWork, SalesSlipReadWork salesSlipReadWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            salesSlipWork = null;
            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    SqlDataReader myReader = null;
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    StringBuilder sqlText = new StringBuilder();
                    sqlText.Append("SELECT").Append(Environment.NewLine);
                    sqlText.Append("  SLIP.*").Append(Environment.NewLine);
                    sqlText.Append("FROM").Append(Environment.NewLine);
                    sqlText.Append("  SALESSLIPRF AS SLIP WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sqlText.Append("WHERE").Append(Environment.NewLine);
                    sqlText.Append("  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
                    sqlText.Append("  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS").Append(Environment.NewLine);
                    sqlText.Append("  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipReadWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.SalesSlipNum);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            salesSlipWork = SalesSlipReadResultPut(myReader);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            //該当レコードがない場合は検索終了
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            return status;
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed) myReader.Close();
                            myReader.Dispose();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            return status;
        }
        // ADD 2011/08/17 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

        /// <summary>
        /// 指定された企業コードの売上データを戻します
        /// </summary>
        /// <param name="salesSlipWork">読込結果</param>
        /// <param name="copySalesSlipWork">読込結果コピー情報</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの仕入データを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        private int ReadSalesSlipWork(out SalesSlipWork salesSlipWork, ref SalesSlipWork[] copySalesSlipWork, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadSalesSlipWork(out salesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの売上データを戻します
        /// </summary>
        /// <param name="salesSlipWork">読込結果</param>
        /// <param name="copySalesSlipWork">読込結果コピー情報</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの売上データを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        private int ReadSalesSlipWork(out SalesSlipWork salesSlipWork, ref SalesSlipWork[] copySalesSlipWork, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            salesSlipWork = new SalesSlipWork();

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;
                    
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLIP.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------->>>
                    //sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                    sqlText += "  SALESSLIPRF AS SLIP WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    // --- UPD 2012/09/27 y.wakita ----->>>>>
                    //sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    if (salesSlipReadWork.LogicalDeleteCodeFlg == 0)
                    {
                      sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }
                    // --- UPD 2012/09/27 y.wakita -----<<<<<
                    sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipReadWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.SalesSlipNum);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        
                        if (myReader.Read())
                        {
                            salesSlipWork = SalesSlipReadResultPut(myReader);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //コピー配列数分コピーリード
                                for (int i = 0; i < copySalesSlipWork.Length; i++)
                                {
                                    copySalesSlipWork[i] = SalesSlipReadResultPut(myReader);
                                }
                            }

                            /*--- DEL 2008/06/06 M.Kubota --->>>
                            // 在庫更新拠点コードを取得する
                            SalesSlipWork dummy = null;
                            myReader.Close();
                            
                            status = this.SearchStockSecCd(ref salesSlipWork, ref dummy, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //コピー配列数分コピーリード
                                for (int i = 0; i < copySalesSlipWork.Length; i++)
                                {
                                    copySalesSlipWork[i].StockUpdateSecCd = salesSlipWork.StockUpdateSecCd;
                                }
                            }
                             --- DEL 2008/06/06 M.Kubota ---<<<*/

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            //該当レコードがない場合は検索終了
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            return status;
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed) myReader.Close();
                            myReader.Dispose();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        # endregion

        # region [売上明細データ読み込み]

        /// <summary>
        /// 指定された企業コードの売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="salesDetailWorks">明細読込結果</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの明細情報を全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        private int ReadSalesDetailWork(out ArrayList salesDetailWorks, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            ArrayList[] copySalesDetailWorks = new ArrayList[0];
            return ReadSalesDetailWork(out salesDetailWorks, ref copySalesDetailWorks, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="copySalesDetailWorks">コピー情報</param>
        /// <param name="salesDetailWorks">明細読込結果</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの売上明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        private int ReadSalesDetailWork(out ArrayList salesDetailWorks, ref ArrayList[] copySalesDetailWorks, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadSalesDetailWork(out salesDetailWorks, ref copySalesDetailWorks, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="salesDetailWorks">明細読込結果</param>
        /// <param name="copySalesDetailWorks">読込結果コピー</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.21</br>
        private int ReadSalesDetailWork(out ArrayList salesDetailWorks, ref ArrayList[] copySalesDetailWorks, SalesSlipReadWork salesSlipReadWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            //戻り値用ArrayListを生成
            ArrayList al = new ArrayList();
            
            //コピー指定数分ArrayList生成
            for (int ii = 0; ii < copySalesDetailWorks.Length; ii++)
            {
                copySalesDetailWorks[ii] = new ArrayList();
            }

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------->>>
                    //sqlText += "  SALESDETAILRF AS DTIL" + Environment.NewLine;
                    sqlText += "  SALESDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    // --- UPD 2012/09/27 y.wakita ----->>>>>
                    //sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    if (salesSlipReadWork.LogicalDeleteCodeFlg == 0)
                    {
                        sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }
                    // --- UPD 2012/09/27 y.wakita -----<<<<<
                    sqlText += "  AND DTIL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipReadWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.SalesSlipNum);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //伝票明細をセット
                            al.Add(SalesDetailReadResultPut(myReader));

                            //コピー指定数分コピー
                            for (int i = 0; i < copySalesDetailWorks.Length; i++)
                            {
                                copySalesDetailWorks[i].Add(SalesDetailReadResultPut(myReader));
                            }

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed) myReader.Close();
                            myReader.Dispose();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            salesDetailWorks = al;

            if (salesDetailWorks.Count == 0)
            {
                salesDetailWorks = null;
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 指定された売上明細通番を持つ売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="readResult">明細読込結果</param>
        /// <param name="parasalesDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された売上明細通番を持つ売上明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.28</br>
        public int ReadSalesDetailWork(out ArrayList readResult, ArrayList parasalesDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadSalesDetailWorkProc(out readResult, parasalesDetailWorks, ref sqlConnection, ref sqlTransaction);
        }

        // ADD 2011/08/17 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
        /// <summary>
        /// 売上明細リストを取得(論理削除を含む)
        /// </summary>
        /// <param name="readResult">明細読込結果</param>
        /// <param name="salesSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        public int ReadSalesDetailWorkIgnoreDel(out ArrayList readResult, SalesSlipReadWork salesSlipReadWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            readResult = new ArrayList();
            if (salesSlipReadWork == null)
                return status;

            SqlDataReader myReader = null;
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    StringBuilder sqlText = new StringBuilder();
                    # region [SQL文]
                    sqlText.Append("SELECT").Append(Environment.NewLine);
                    sqlText.Append("  DTIL.*").Append(Environment.NewLine);
                    sqlText.Append("FROM").Append(Environment.NewLine);
                    sqlText.Append("  SALESDETAILRF AS DTIL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
                    sqlText.Append("WHERE").Append(Environment.NewLine);
                    sqlText.Append("  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
                    sqlText.Append("  AND DTIL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS").Append(Environment.NewLine);
                    sqlText.Append("  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM").Append(Environment.NewLine);
                    # endregion

                    sqlCommand.CommandText = sqlText.ToString();

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipReadWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.SalesSlipNum);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            //伝票明細をセット
                            readResult.Add(SalesDetailReadResultPut(myReader));
                        }
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            myReader.Dispose();
                            myReader = null;
                        }
                    }
                }
                
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                return status;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                return status;
            }
        
            if (readResult.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            return status;
        }
        // ADD 2011/08/17 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

        /// <summary>
        /// 指定された売上明細通番を持つ売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="readResult">明細読込結果</param>
        /// <param name="parasalesDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された売上明細通番を持つ売上明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.28</br>
        private int ReadSalesDetailWorkProc(out ArrayList readResult, ArrayList parasalesDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            readResult = new ArrayList();  //ADD 2008/06/06 M.Kubota
            
            SqlDataReader myReader = null;
            ArrayList readSlsDtlList = new ArrayList();

            bool disposeConnection = false;
            bool disposeTransaction = false;

            if (parasalesDetailWorks != null && parasalesDetailWorks.Count > 0)
            {
                try
                {
                    // SqlConnection が未設定の場合
                    if (sqlConnection == null)
                    {
                        disposeConnection = true;

                        if (sqlTransaction != null)
                        {
                            sqlTransaction.Dispose();
                            sqlTransaction = null;
                        }

                        sqlConnection = this.CreateSqlConnection(true);

                        if (sqlConnection == null)
                        {
                            //readResult = readSlsDtlList;  //DEL 2008/06/06 M.Kubota
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

                    // -- ADD 2010/04/13 ---------------------------------------->>>
                    int searchMode = 0;  // 0:通番で検索 1:伝票番号＋行番号で検索
                    if ((parasalesDetailWorks[0] as SalesDetailWork).SalesSlipDtlNum == 0)
                    {
                        searchMode = 1;
                    }
                    // -- ADD 2010/04/13 ----------------------------------------<<<

                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;

                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        string sqlText = "";

                        # region [SQL文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  DTIL.*" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        // -- UPD 2010/04/13 -------------------------------->>>
                        //sqlText += "  SALESDETAILRF AS DTIL" + Environment.NewLine;
                        sqlText += "  SALESDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                        // -- UPD 2010/04/13 --------------------------------<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        // -- UPD 2010/04/13 --------------------------------->>>
                        //sqlText += "  AND DTIL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;

                        if (searchMode == 0)
                        {
                            //通番が指定されていた場合は通番で抽出
                            sqlText += "  AND DTIL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                        }
                        else
                        {
                            //通番が指定されていない場合、伝票番号＋行番号で抽出
                            sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  AND DTIL.SALESROWNORF = @FINDSALESROWNO" + Environment.NewLine;

                        }
                        // -- UPD 2010/04/13 ---------------------------------<<<
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        // -- UPD 2010/04/13 ------------------------------>>>
                        //SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter findSalesSlipDtlNum = null;
                        SqlParameter findSalesSlipNum = null;
                        SqlParameter findSalesRowNo = null;

                        if (searchMode == 0)
                        {
                            findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);
                        }
                        else
                        {
                            findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                            findSalesRowNo = sqlCommand.Parameters.Add("@FINDSALESROWNO", SqlDbType.Int);
                        }
                        // -- UPD 2010/04/13 ------------------------------<<<

                        foreach (Object paraObj in parasalesDetailWorks)
                        {
                            SalesDetailWork paraDtlWork = paraObj as SalesDetailWork;

                            if (paraDtlWork != null)
                            {
                                //Parameterオブジェクトへ値設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraDtlWork.EnterpriseCode);
                                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(paraDtlWork.AcptAnOdrStatus);
                                // -- UPD 2010/04/13 --------------------------------------->>>
                                //findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(paraDtlWork.SalesSlipDtlNum);
                                if (searchMode == 0)
                                {
                                    findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(paraDtlWork.SalesSlipDtlNum);
                                }
                                else
                                {
                                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(paraDtlWork.SalesSlipNum);
                                    findSalesRowNo.Value = SqlDataMediator.SqlSetInt32(paraDtlWork.SalesRowNo);
                                }
                                // -- UPD 2010/04/13 ---------------------------------------<<<

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        //伝票明細をセット
                                        readSlsDtlList.Add(SalesDetailReadResultPut(myReader));
                                    }
                                }
                                finally
                                {
                                    if (myReader != null)
                                    {
                                        if (!myReader.IsClosed)
                                        {
                                            myReader.Close();
                                        }
                                        myReader.Dispose();
                                        myReader = null;
                                    }
                                }
                            }
                        }

                        readResult.Add(readSlsDtlList);  //ADD 2008/06/06 M.Kubota
                    }

                    //--- ADD 2008/06/06 M.Kubota --->>>
                    if (readSlsDtlList.Count > 0)
                    {
                        // 売上明細に紐付く受注マスタ(車両)データを取得する
                        ArrayList acpOdrCarList = null;

                        AcceptOdrCarReader _IOWriteAcceptOdrCarDB = new AcceptOdrCarReader();

                        status = _IOWriteAcceptOdrCarDB.ReadWithSalesDetail(out acpOdrCarList, readSlsDtlList, sqlConnection, sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            readResult.Add(acpOdrCarList);
                        }
                    }
                    //--- ADD 2008/06/06 M.Kubota ---<<<
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (disposeConnection && sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }

                    if (disposeTransaction && sqlTransaction != null)
                    {
                        sqlTransaction.Dispose();
                    }
                }
            }

            //readResult = readSlsDtlList;  //DEL 2008/06/06 M.Kubota

            if (readResult.Count > 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 指定された売上明細通番を持つ売上明細データLISTを全て戻します
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int ReadSalesDetailWork(ref object paraList, ref object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // パラメータチェック
                CustomSerializeArrayList paramArray = paraList as CustomSerializeArrayList;
                if (paramArray == null || paramArray.Count == 0)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": パラメータが未設定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (retList == null || !(retList is CustomSerializeArrayList))
                {
                    retList = new CustomSerializeArrayList();
                }
                else
                {
                    (retList as CustomSerializeArrayList).Clear();
                }

                //呼び出しパラメータ設定

                SqlConnection sqlConnection = this.CreateSqlConnection(true);
                SqlTransaction sqlTransaction = null;
                ArrayList retDtlArray = new ArrayList();

                status = this.ReadSalesDetailWork(out retDtlArray, paramArray, ref sqlConnection, ref sqlTransaction);

                // 戻り値を設定
                (retList as CustomSerializeArrayList).AddRange(retDtlArray);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        # endregion

        # region [売上データ 読込結果格納]

        /// <summary>
        /// 売上読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private SalesSlipWork SalesSlipReadResultPut(SqlDataReader myReader)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();

            //＠売上データ変更＠
            #region 売上ワーククラスへ代入　※レイアウト変更時対応必須
            salesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            salesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            salesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            salesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            salesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            salesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            salesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            salesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            salesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            salesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            salesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            salesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            salesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
            salesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            salesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            salesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            salesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
            salesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            salesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            salesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            salesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
            salesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            salesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            salesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            salesSlipWork.PreSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF")); // ADD 2011/12/21
            salesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            salesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            salesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
            salesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
            salesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            salesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            salesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            salesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            salesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            salesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            salesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            salesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            salesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            salesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            salesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            salesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            salesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
            salesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
            salesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
            salesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
            salesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            salesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            salesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
            salesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
            salesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
            salesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
            salesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
            salesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            salesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            salesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            salesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
            salesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            salesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            salesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            salesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
            salesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
            salesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
            salesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
            salesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
            salesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
            salesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
            salesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            salesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            salesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
            salesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
            salesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            salesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            salesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            salesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            salesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
            salesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            salesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
            salesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
            salesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            salesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            salesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            salesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            salesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            salesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            salesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            salesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            salesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            salesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
            salesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            salesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            salesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            salesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            salesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            salesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            salesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            salesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            salesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            salesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            salesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            salesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            salesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            salesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            salesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            salesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            salesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            salesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));
            salesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            salesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));
            salesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            salesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            salesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            salesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            salesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            salesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
            salesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            salesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
            salesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            salesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            salesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            salesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
            salesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
            salesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            salesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            salesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));
            salesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            salesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
            salesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
            salesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
            salesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
            salesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
            salesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            salesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
            salesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
            salesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
            salesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
            salesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
            salesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
            salesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
            salesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
            salesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
            salesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
            salesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
            salesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
            salesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
            salesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
            salesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
            salesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
            salesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
            salesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
            salesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
            #endregion

            return salesSlipWork;
        }
        
        # endregion

        # region [売上明細データ 読込結果格納]

        /// <summary>
        /// 売上明細読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        private SalesDetailWork SalesDetailReadResultPut(SqlDataReader myReader)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();

            this.SalesDetailReadResultPut(ref salesDetailWork, myReader);

            return salesDetailWork;
        }

        /// <summary>
        /// 売上明細読込結果クラス出力処理
        /// </summary>
        /// <param name="salesDetailWork">売上明細データクラス</param>
        /// <param name="myReader">読込結果</param>
        private void SalesDetailReadResultPut(ref SalesDetailWork salesDetailWork, SqlDataReader myReader)
        {
            //＠売上明細データ変更＠
            //salesDetailWork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));               // <#name>
            #region 売上明細ワーククラスへ代入　※レイアウト変更時対応必須
            salesDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            salesDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            salesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            salesDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            salesDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            salesDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            salesDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            salesDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            salesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            salesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            salesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            salesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
            salesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            salesDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            salesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            salesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            salesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            salesDetailWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
            salesDetailWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
            salesDetailWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
            salesDetailWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
            salesDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
            salesDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
            salesDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            salesDetailWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSEARCHDIVCDRF"));
            salesDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            salesDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            salesDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
            salesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            salesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            salesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            salesDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            salesDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            salesDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            salesDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            salesDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            salesDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            salesDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            salesDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            salesDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            salesDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            salesDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            salesDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            salesDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            salesDetailWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
            salesDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            salesDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            salesDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            salesDetailWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
            salesDetailWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
            salesDetailWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
            salesDetailWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
            salesDetailWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
            salesDetailWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
            salesDetailWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
            salesDetailWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
            salesDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            salesDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            salesDetailWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
            salesDetailWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
            salesDetailWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
            salesDetailWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
            salesDetailWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
            salesDetailWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
            salesDetailWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
            salesDetailWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
            salesDetailWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
            salesDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
            salesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            salesDetailWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
            salesDetailWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
            salesDetailWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
            salesDetailWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
            salesDetailWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
            salesDetailWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
            salesDetailWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
            salesDetailWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
            salesDetailWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
            salesDetailWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            salesDetailWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
            salesDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            salesDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
            salesDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
            salesDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
            salesDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
            salesDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
            salesDetailWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
            salesDetailWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
            salesDetailWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            salesDetailWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
            salesDetailWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
            salesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            salesDetailWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
            salesDetailWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
            salesDetailWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
            salesDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
            salesDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
            salesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            salesDetailWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
            salesDetailWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
            salesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            salesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
            salesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            salesDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
            salesDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            salesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            salesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            salesDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            salesDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            salesDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            salesDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            salesDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            salesDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            salesDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            salesDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            salesDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
            salesDetailWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
            salesDetailWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
            salesDetailWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
            salesDetailWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
            salesDetailWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
            salesDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
            salesDetailWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
            salesDetailWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
            salesDetailWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
            salesDetailWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
            salesDetailWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
            salesDetailWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
            salesDetailWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
            salesDetailWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
            salesDetailWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
            salesDetailWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));
            salesDetailWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF")); 
            // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            salesDetailWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
            salesDetailWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
            salesDetailWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
            salesDetailWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATERF"));
            salesDetailWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEDIVRF"));
            salesDetailWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEDIVNMRF"));
            salesDetailWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOACPTODRRF"));
            // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            salesDetailWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// add 2011/07/23 duz
            // ----- ADD 2011/08/10 ----- >>>>>
            salesDetailWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));
            salesDetailWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
            salesDetailWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQROWNUMBERRF"));
            // ----- ADD 2011/08/10 ----- <<<<<
            // ----- ADD 2012/01/23 ----- >>>>>
            salesDetailWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            // ----- ADD 2012/01/23 ----- <<<<<

            //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            salesDetailWork.RentSyncSupplier = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RENTSYNCSUPPLIERRF"));
            salesDetailWork.RentSyncStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENTSYNCSTOCKDATERF"));
            salesDetailWork.RentSyncSupSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RENTSYNCSUPSLIPNORF"));
            //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #endregion
        }

        # endregion

        # region [計上元売上明細データ 読込結果格納]
        /// <summary>
        /// 計上元売上明細読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        private AddUpOrgSalesDetailWork AddUpOrgSalesDetailReadResultPut(SqlDataReader myReader)
        {
            SalesDetailWork addUpOrgSalesDetailWork = new AddUpOrgSalesDetailWork();

            this.SalesDetailReadResultPut(ref addUpOrgSalesDetailWork, myReader);

            return (AddUpOrgSalesDetailWork)addUpOrgSalesDetailWork;
        }
        # endregion

        /// <summary>
        /// 売上読込クラス出力処理
        /// </summary>
        /// <param name="salesSlipWork">売上データクラス</param>
        /// <returns>出力クラス(SalesSlipReadWork)</returns>
        private SalesSlipReadWork SalesSlipReadWorkOutPut(SalesSlipWork salesSlipWork)
        {
            SalesSlipReadWork wkSalesSlipReadWork = new SalesSlipReadWork();

            wkSalesSlipReadWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
            wkSalesSlipReadWork.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
            wkSalesSlipReadWork.SalesSlipNum = salesSlipWork.SalesSlipNum;

            return wkSalesSlipReadWork;
        }

        /// <summary>
        /// 売上読込クラス出力処理
        /// </summary>
        /// <param name="salesSlipDeleteWork">仕入データ削除クラス</param>
        /// <returns>出力クラス(StockSlipReadWork)</returns>
        private SalesSlipReadWork SalesSlipReadWorkOutPut(SalesSlipDeleteWork salesSlipDeleteWork)
        {
            SalesSlipReadWork wkSalesSlipReadWork = new SalesSlipReadWork();

            wkSalesSlipReadWork.EnterpriseCode = salesSlipDeleteWork.EnterpriseCode;
            wkSalesSlipReadWork.AcptAnOdrStatus = salesSlipDeleteWork.AcptAnOdrStatus;
            wkSalesSlipReadWork.SalesSlipNum = salesSlipDeleteWork.SalesSlipNum;

            return wkSalesSlipReadWork;
        }
        # endregion

        # region [Write]　登録・更新処理　ヘッダ・明細・詳細

        # region [---- DEL 2009/01/30 M.Kubota ---]
        ///// <summary>
        ///// 返品元売上伝票データを取得します。
        ///// </summary>
        ///// <param name="retSalesDetailList">返品売上伝票明細データリストを指定します。</param>
        ///// <param name="retOrgSalesSlip">返品元売上伝票データを返します。</param>
        ///// <param name="retOrgSalesDetailList"></param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns></returns>
        //private int ReadSalesSlipFromReturn(ArrayList retSalesDetailList, out SalesSlipWork retOrgSalesSlip, out ArrayList retOrgSalesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    retOrgSalesSlip = null;
        //    retOrgSalesDetailList = null;

        //    // 返品伝票明細を取得
        //    ArrayList paraSalesDtlList = new ArrayList();

        //    if (retSalesDetailList != null)
        //    {
        //        foreach (object dltItem in retSalesDetailList)
        //        {
        //            if (dltItem is SalesDetailWork)
        //            {
        //                if ((dltItem as SalesDetailWork).AcptAnOdrStatusSrc != 0 && (dltItem as SalesDetailWork).SalesSlipDtlNumSrc != 0)
        //                {
        //                    // 売上明細データ読み込みパラメータ設定
        //                    int index = paraSalesDtlList.Add(new SalesDetailWork());
        //                    (paraSalesDtlList[index] as SalesDetailWork).EnterpriseCode = (dltItem as SalesDetailWork).EnterpriseCode;
        //                    (paraSalesDtlList[index] as SalesDetailWork).LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
        //                    (paraSalesDtlList[index] as SalesDetailWork).AcptAnOdrStatus = (dltItem as SalesDetailWork).AcptAnOdrStatusSrc;
        //                    (paraSalesDtlList[index] as SalesDetailWork).SalesSlipDtlNum = (dltItem as SalesDetailWork).SalesSlipDtlNumSrc;
        //                }
        //            }
        //        }
        //    }

        //    if (paraSalesDtlList.Count == 0)
        //    {
        //        return status;
        //    }

        //    status = this.ReadSalesDetailWork(out retOrgSalesDetailList, paraSalesDtlList, ref sqlConnection, ref sqlTransaction);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 売上データ読み込みパラメータ設定
        //        SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();

        //        ArrayList salesDtlList = ListUtils.Find(retOrgSalesDetailList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

        //        if (ListUtils.IsNotEmpty(salesDtlList))
        //        {
        //            salesSlipReadWork.EnterpriseCode = (salesDtlList[0] as SalesDetailWork).EnterpriseCode;
        //            salesSlipReadWork.AcptAnOdrStatus = (salesDtlList[0] as SalesDetailWork).AcptAnOdrStatus;
        //            salesSlipReadWork.SalesSlipNum = (salesDtlList[0] as SalesDetailWork).SalesSlipNum;

        //            SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];
        //            status = this.ReadSalesSlipWork(out retOrgSalesSlip, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
        //        }
        //        else
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        }
        //    }

        //    return status;
        //}
        # endregion

        /// <summary>
        /// 売上データ・売上明細データを登録、更新初期処理を行います
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="paraList">更新対象オブジェクト</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データ・売上明細データを登録、更新初期処理を行います</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int listPos_SalesSlipWork = -1;
            int listPos_SalesDetailWork = -1;
            int listPos_SlpDtlAddInfWork = -1;      //ADD 2008/06/06 M.Kubota

            //更新対象オブジェクト格納用
            SalesSlipWork salesSlipWork = null;
            ArrayList salesDetailWorkList = null;
            ArrayList slpDtlAddInfWorkList = null;  //ADD 2008/06/06 M.Kubota

            //更新前情報読込パラメータ格納用
            SalesSlipReadWork salesSlipReadWork = null;

            originList = new CustomSerializeArrayList();

            //更新前データ格納用
            SalesSlipWork oldSalesSlipWork = new SalesSlipWork();
            ArrayList oldSalesDetailWorkList = new ArrayList();

            SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                salesSlipWork = paraList[position] as SalesSlipWork;
                listPos_SalesSlipWork = position;
            }

            //●伝票情報パラメータ取得
            for (int i = 0; i < paraList.Count; i++)
            {
                // 売上明細データの分離
                if (salesDetailWorkList == null)
                {
                    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is SalesDetailWork)
                    {
                        salesDetailWorkList = paraList[i] as ArrayList;
                        listPos_SalesDetailWork = i;
                        //if (salesDetailWorkList != null) break;  //DEL 2008/06/06 M.Kubota
                    }
                }

                //--- ADD 2008/06/06 M.Kubota --->>>
                // 伝票明細追加情報データの分離
                if (slpDtlAddInfWorkList == null)
                {
                    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is SlipDetailAddInfoWork)
                    {
                        slpDtlAddInfWorkList = paraList[i] as ArrayList;
                        slpDtlAddInfWorkList.Sort(DtlRelationGuidComp);
                        listPos_SlpDtlAddInfWork = i;
                    }
                }

                if (salesDetailWorkList != null && slpDtlAddInfWorkList != null)
                {
                    break;
                }
                //--- ADD 2008/06/06 M.Kubota ---<<<
            }

            //●製番管理しない商品に関しては売上詳細データは存在しない
            if (salesSlipWork == null || salesDetailWorkList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象オブジェクトパラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            // add 2007.07.23 saito >>>>>>>>>>
            //●最終支払締履歴日付チェック
            //if (salesSlipWork.SupplierFormal == 0)
            //{
            //    status = this.CheckPaymentAddUpHis(salesSlipWork, out retMsg, ref sqlConnection, ref sqlTransaction);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING) return status;
            //}
            //●売上計上済み在庫がある場合は売上計上日付をMAKON01924Rでチェック
            // add 2007.07.23 saito <<<<<<<<<<

            //●伝票番号の採番
            //採番チェック
            if (SalesTool.StrToIntDef(salesSlipWork.SalesSlipNum, 0) == 0)
            {
                string sectionCode;
                string salesSlipNum;

                //拠点コード
                sectionCode = salesSlipWork.SectionCode;

                // 売上伝票番号の採番
                status = CreateSalesSlipNumProc(salesSlipWork.EnterpriseCode, sectionCode, out salesSlipNum, salesSlipWork.AcptAnOdrStatus, out retMsg, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || SalesTool.StrToIntDef(salesSlipNum, 0) == 0)
                {
                    //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    if (retMsg == null || retMsg == "")
                        retMsg = "売上伝票番号が採番できませんでした。番号設定を見直してください。";

                    return status;
                }
                else
                {
                    // 採番した売上伝票番号を設定
                    salesSlipWork.SalesSlipNum = salesSlipNum;
                }
            }
            //伝票更新で売上伝票番号が入っている場合(既存伝票更新or不正データの場合はエラー出力)
            else
            {
                //売上伝票が存在するかチェックし、originListに追加する
                SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];
                ArrayList[] copySalesDetailWorkList = new ArrayList[0];

                salesSlipReadWork = this.SalesSlipReadWorkOutPut(salesSlipWork);

                //既存売上伝票の読込
                status = this.ReadSalesSlipWork(out oldSalesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    this.ReadSalesDetailWork(out oldSalesDetailWorkList, ref copySalesDetailWorkList, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            //--- ADD 2008/12/24 M.Kubota --->>>
            // 得意先伝票番号の採番
            if (salesSlipWork.CustSlipNo == 0 && salesSlipWork.AcptAnOdrStatus == 30)
            {
                Int64 custSlipNo = 0;
                SqlConnection dmyConnection = null;
                SqlTransaction dmyTransaction = null;
                status = this.CstSlpNoSetDb.GetCustomerSlipNo(salesSlipWork.EnterpriseCode, salesSlipWork.CustomerCode, salesSlipWork.SalesDate, out custSlipNo, ref dmyConnection, ref dmyTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    salesSlipWork.CustSlipNo = Convert.ToInt32(custSlipNo);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // 得意先伝票番号を取得する必要が無い場合
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    retMsg = "得意先伝票番号の採番に失敗しました.";
                    return status;
                }
            }
            //--- ADD 2008/12/24 M.Kubota ---<<<

            /*--- DEL 2008/06/06 M.Kubota --->>>
            Int32 StandardAcceptAnOrderNo = 0;

            foreach (SalesDetailWork newDtlWork in salesDetailWorkList)
            {
                if (newDtlWork.AcceptAnOrderNo > 0)
                {
                    StandardAcceptAnOrderNo = newDtlWork.AcceptAnOrderNo;
                    break;
                }
            }
              --- DEL 2008/06/06 M.Kubota ---<<<*/

            //--- ADD 2008/06/06 M.Kubota --->>>
            // 車両関連付けGUIDを受注番号を紐付けるハッシュテーブル
            Hashtable CarRltGuidToAcptAnOrdNo = new Hashtable();

            // このタイミングで既に採番・設定されている受注番号と車両関連付けGUIDをハッシュテーブルに格納しておく
            foreach (SalesDetailWork newDtlWork in salesDetailWorkList)
            {
                if (newDtlWork.AcceptAnOrderNo > 0)
                {
                    int addInfIdx = slpDtlAddInfWorkList.BinarySearch(newDtlWork.DtlRelationGuid, DtlRelationGuidComp);
                    SlipDetailAddInfoWork addInfWork = slpDtlAddInfWorkList[addInfIdx] as SlipDetailAddInfoWork;

                    if (addInfWork != null)
                    {
                        if (CarRltGuidToAcptAnOrdNo[addInfWork.CarRelationGuid] == null)
                        {
                            // ハッシュテーブルに存在しない車両関連付けGUIDと受注番号を登録する
                            CarRltGuidToAcptAnOrdNo.Add(addInfWork.CarRelationGuid, newDtlWork.AcceptAnOrderNo);
                        }
                    }
                }
            }
            //--- ADD 2008/06/06 M.Kubota ---<<<

            foreach (SalesDetailWork newDtlWork in salesDetailWorkList)
            {
                // 明細リストにNULLが登録される場合があるので対応
                if (newDtlWork != null)
                {
                    // 出荷差分数、受注残数、残数更新日の初期値を設定
                    //newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt * ((newDtlWork.SalesSlipCdDtl == 1) ? -1 : 1);
                    newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt;
                    newDtlWork.AcptAnOdrRemainCnt = newDtlWork.ShipmentCnt;
                    newDtlWork.RemainCntUpdDate = DateTime.Now;
                    
                    if (oldSalesDetailWorkList != null && oldSalesDetailWorkList.Count > 0)
                    {
                        foreach (SalesDetailWork oldDtlWork in oldSalesDetailWorkList)
                        {
                            // 同一キー値を持つデータを検索
                            // 2009/02/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
                            //    newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus &&
                            //    newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum)
                            // 同一明細の判断に品番、メーカーも追加
                            if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
                                newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus &&
                                newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum &&
                                newDtlWork.GoodsNo == oldDtlWork.GoodsNo &&
                                newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd)
                            // 2009/02/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                // 出荷差分数の設定
                                //newDtlWork.ShipmCntDifference = (newDtlWork.ShipmentCnt - oldDtlWork.ShipmentCnt) * ((newDtlWork.SalesSlipCdDtl == 1) ? -1 : 1);
                                newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt - oldDtlWork.ShipmentCnt;

                                // 受注残数の設定 (更新前受注残数＋更新後出荷差分数)
                                //newDtlWork.AcptAnOdrRemainCnt = oldDtlWork.AcptAnOdrRemainCnt + (newDtlWork.ShipmCntDifference * ((newDtlWork.SalesSlipCdDtl == 1) ? -1 : 1));
                                newDtlWork.AcptAnOdrRemainCnt = oldDtlWork.AcptAnOdrRemainCnt + newDtlWork.ShipmCntDifference;

                                // 出荷差分数が 0 の場合、更新前の残数更新日を設定する
                                if (newDtlWork.ShipmCntDifference == 0)
                                {
                                    newDtlWork.RemainCntUpdDate = oldDtlWork.RemainCntUpdDate;
                                }
                                break;
                            }
                        }
                    }

                    // 売上伝票番号を設定
                    if (SalesTool.StrToIntDef(salesSlipWork.SalesSlipNum, 0) > 0 && SalesTool.StrToIntDef(newDtlWork.SalesSlipNum, 0) <= 0)
                    {
                        newDtlWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
                    }

                    // 受注番号を設定
                    if (SalesTool.StrToIntDef(newDtlWork.SalesSlipNum, 0) > 0 && newDtlWork.AcceptAnOrderNo <= 0)
                    {
                        /*-- DEL 2008/06/06 M.Kubota --->>>
                        // 受注番号が未採番の場合にのみ採番を行う
                        if (StandardAcceptAnOrderNo <= 0)
                        {
                            status = AcceptOdr.GetAcceptAnOrderNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode, out StandardAcceptAnOrderNo);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || StandardAcceptAnOrderNo <= 0)
                            {
                                retMsg = "受注番号の採番に失敗しました。";
                                return status;
                            }
                        }

                        // １伝票に対して
                        newDtlWork.AcceptAnOrderNo = StandardAcceptAnOrderNo;
                          --- DEL 2008/06/06 M.Kubota ---<<<*/

                        //--- ADD 2008/06/06 M.Kubota --->>>
                        if (slpDtlAddInfWorkList != null && slpDtlAddInfWorkList.Count > 0)
                        {
                            try
                            {
                                int addInfIdx = slpDtlAddInfWorkList.BinarySearch(newDtlWork.DtlRelationGuid, DtlRelationGuidComp);

                                SlipDetailAddInfoWork addInfWork = slpDtlAddInfWorkList[addInfIdx] as SlipDetailAddInfoWork;

                                if (addInfWork != null)
                                {
                                    int saveAcptAnOrdNo = -1;

                                    if (CarRltGuidToAcptAnOrdNo[addInfWork.CarRelationGuid] != null)
                                    {
                                        saveAcptAnOrdNo = (int)CarRltGuidToAcptAnOrdNo[addInfWork.CarRelationGuid];
                                    }
                                    else
                                    {
                                        status = AcceptOdr.GetAcceptAnOrderNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode, out saveAcptAnOrdNo);

                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || saveAcptAnOrdNo <= 0)
                                        {
                                            retMsg = "受注番号の採番に失敗しました。";
                                            return status;
                                        }

                                        CarRltGuidToAcptAnOrdNo.Add(addInfWork.CarRelationGuid, saveAcptAnOrdNo);
                                    }

                                    // １車両に対して(車両が無い場合はGuid.Emptyで処理が行われる)
                                    newDtlWork.AcceptAnOrderNo = saveAcptAnOrdNo;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                        }
                        //--- ADD 2008/06/06 M.Kubota ---<<<
                    }

                    // 共通通番を設定
                    if (newDtlWork.CommonSeqNo <= 0)
                    {
                        Int64 commonseqno = 0;
                        status = AcceptOdr.GetCommonSeqNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode, out commonseqno);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && commonseqno != 0)
                        {
                            newDtlWork.CommonSeqNo = commonseqno;
                        }
                        else
                        {
                            retMsg = "共通通番の採番に失敗しました。";
                            return status;
                        }
                    }

                    // 売上明細通番を設定
                    if (newDtlWork.SalesSlipDtlNum <= 0)
                    {
                        Int64 salesslipdtlnum = 0;

                        int slipDataDivide = 0;

                        switch (newDtlWork.AcptAnOdrStatus)
                        {
                            case 10:  // 見積
                                slipDataDivide = (int)SlipDataDivide.Estimate;
                                break;
                            case 20:  // 受注
                                slipDataDivide = (int)SlipDataDivide.AcceptAnOrder;
                                break;
                            case 30:  // 売上
                                slipDataDivide = (int)SlipDataDivide.Sales;
                                break;
                            case 40:  // 出荷
                                slipDataDivide = (int)SlipDataDivide.Shipment;
                                break;
                        }

                        status = AcceptOdr.GetSlipDetailNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode,
                                                               slipDataDivide, out salesslipdtlnum);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesslipdtlnum != 0)
                        {
                            newDtlWork.SalesSlipDtlNum = salesslipdtlnum;
                        }
                        else
                        {
                            retMsg = "売上明細通番の採番に失敗しました。";
                            return status;
                        }
                    }
                }
            }

            //--- DEL 2008/06/06 M.Kubota --->>>
            //●拠点制御設定マスタより在庫更新拠点コードを抽出
            //if (salesSlipWork != null && salesSlipWork.SalesGoodsCd == 0)
            //{
            //    status = this.SearchStockSecCd(ref salesSlipWork, ref oldSalesSlipWork, ref sqlConnection, ref sqlTransaction);

            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //    {
            //        retMsg = "拠点制御設定が正しく設定されておりません。";
            //        return status;
            //    }
            //}
            //--- DEL 2008/06/06 M.Kubota ---<<<

            //●パラメータに戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (oldSalesSlipWork.CreateDateTime > DateTime.MinValue)
                {
                    originList.Add(oldSalesSlipWork);
                    originList.Add(oldSalesDetailWorkList);
                }

                paraList[listPos_SalesSlipWork] = salesSlipWork;
                paraList[listPos_SalesDetailWork] = salesDetailWorkList;

                # region [--- DEL 2009/01/30 M.Kubota ---]
                // 返品の場合は返品元となった伝票の読み込みを行う
                // ※返品伝票自体の修正ならば originList には変更前返品と返品元伝票の両方が格納される
                //if (salesSlipWork.SalesSlipCd == 1)
                //{
                //    SalesSlipWork retOrgSalesSlip = null;
                //    ArrayList retOrgSalesDtlList = null;
                    
                //    status = this.ReadSalesSlipFromReturn(salesDetailWorkList, out retOrgSalesSlip, out retOrgSalesDtlList, ref sqlConnection, ref sqlTransaction);

                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        if (retOrgSalesSlip != null)
                //            originList.Add(retOrgSalesSlip);

                //        if (retOrgSalesDtlList != null && retOrgSalesDtlList.Count > 0)
                //            originList.Add(retOrgSalesDtlList);
                //    }
                //    else
                //    {
                //        retMsg = "返品元 売上伝票データの読み込みに失敗しました。";
                //    }
                //}
                # endregion

                //--- ADD 2009/01/30 M.Kubota --->>>
                // 計上元明細データの読み込み
                ArrayList addUpSalesDetailWorks = null;
                status = this.ReadAddUpSalesDetailWork(out addUpSalesDetailWorks, salesDetailWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(addUpSalesDetailWorks))
                {
                    paraList.Add(addUpSalesDetailWorks);
                }
                //--- ADD 2009/01/30 M.Kubota ---<<<
            }
            else             //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;

            return status;
        }

        /// <summary>
        /// 売上データ・売上明細データを登録、更新します
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="paraList">更新対象オブジェクト</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上データ・売上明細データを登録、更新します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";

            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int listPos_SalesSlipWork = 0;
            int listPos_SalesDetailWork = 0;

            SalesSlipWork salesSlipWork = null;
            ArrayList salesDetailWorks = null;
            ArrayList addUpSalesDetailWorks = null;
            ArrayList slpDtlAddInfWorks = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                salesSlipWork = paraList[position] as SalesSlipWork;
                listPos_SalesSlipWork = position;
            }

            //●伝票更新List内より売上明細データの分離
            salesDetailWorks = ListUtils.Find(paraList, typeof(SalesDetailWork), ListUtils.FindType.Array, out listPos_SalesDetailWork) as ArrayList;

            //製番管理しない商品に関しては仕入詳細データは存在しない
            if (salesSlipWork == null || salesDetailWorks == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象オブジェクトパラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●伝票明細追加情報データの分離
            slpDtlAddInfWorks = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            //●Write
            //売上伝票更新
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
            // status = WriteSalesSlipWork(ref salesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            status = WriteSalesSlipWork(ref salesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

            //売上伝票明細更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesDetailWorks != null)
                status = WriteSalesDetailWork(ref salesDetailWorks, salesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            //計上元売上明細データの受注残数更新 (計上元の有無は呼出し先で行っている)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList salesDetails = new ArrayList();
                salesDetails.AddRange(salesDetailWorks);

                // 更新前の売上明細データを取得する
                ArrayList oldSalesDetailWorks = null;

                if (originList != null && originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (originList[i] is ArrayList &&
                            ((ArrayList)originList[i]).Count > 0 &&
                            ((ArrayList)originList[i])[0] is SalesDetailWork)
                        {
                            oldSalesDetailWorks = originList[i] as ArrayList;
                            if (oldSalesDetailWorks != null) break;
                        }
                    }
                }

                // 明細単位で削除された物を割り出し、残数更新の対象として追加する
                if (oldSalesDetailWorks != null)
                {
                    foreach (SalesDetailWork olditem in oldSalesDetailWorks)
                    {
                        bool deleted = true;

                        foreach (SalesDetailWork item in salesDetailWorks)
                        {
                            if (olditem.EnterpriseCode == item.EnterpriseCode &&
                                olditem.AcptAnOdrStatus == item.AcptAnOdrStatus &&
                                (olditem.SalesSlipDtlNum == item.SalesSlipDtlNum ||
                                 olditem.SalesSlipDtlNum == item.SalesSlipDtlNumSrc))  // ← 返品登録時に計上元受注残数を更新してしまわないようにする為
                            {
                                deleted = false;
                                break;
                            }
                        }

                        if (deleted)
                        {
                            SalesDetailWork deleteItem = new SalesDetailWork();

                            deleteItem.EnterpriseCode = olditem.EnterpriseCode;
                            deleteItem.AcptAnOdrStatus = olditem.AcptAnOdrStatus;
                            deleteItem.SalesSlipDtlNum = olditem.SalesSlipDtlNum;
                            deleteItem.AcptAnOdrStatusSrc = olditem.AcptAnOdrStatusSrc;
                            deleteItem.SalesSlipDtlNumSrc = olditem.SalesSlipDtlNumSrc;
                            deleteItem.ShipmCntDifference = olditem.ShipmentCnt * -1;
                            salesDetails.Add(deleteItem);
                        }
                    }
                }

                status = this.UpdateAcptAnOdrRemainCnt(salesSlipWork, salesDetails, slpDtlAddInfWorks, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);               //DEL 2008/06/06 M.Kubota

                // 受注残数の更新に成功した場合、計上元売上明細データを取得する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.ReadAddUpSalesDetailWork(out addUpSalesDetailWorks, salesDetailWorks, ref sqlConnection, ref sqlTransaction);
                }
            }
            
            //●更新結果を戻り値に戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList[listPos_SalesSlipWork] = salesSlipWork;
                
                if (salesDetailWorks != null)
                    paraList[listPos_SalesDetailWork] = salesDetailWorks;


                if (addUpSalesDetailWorks != null && addUpSalesDetailWorks.Count > 0)
                {
                    //--- ADD 2009/01/30 M.Kubota --->>>
                    int pos = -1;
                    ListUtils.Find(paraList, typeof(AddUpOrgSalesDetailWork), ListUtils.FindType.Array, out pos);

                    if (pos >= 0)
                    {
                        paraList.RemoveAt(pos);  // 書込み準備処理で読み込んでいた計上元売上明細データを削除する
                    }
                    //--- ADD 2009/01/30 M.Kubota ---<<<

                    // 計上元売上明細データが存在する場合はパラメータリストに追加する
                    paraList.Add(addUpSalesDetailWorks);
                }
            }

            return status;
        }

        /// <summary>
        /// 売上伝票情報を更新します
        /// </summary>
        /// <param name="salesSlipWork">更新伝票情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票情報を更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        /// <br>Update Note: 2011/07/25 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //private int WriteSalesSlipWork(ref SalesSlipWork salesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo) // DEL 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00)
        private int WriteSalesSlipWork(ref SalesSlipWork salesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = string.Empty;

            SqlDataReader myReader = null;

            //Selectコマンドの生成
            try
            {
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);

                    myReader = sqlCommand.ExecuteReader();

                    //既存売上伝票の更新処理
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != salesSlipWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (salesSlipWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                            return status;
                        }
                        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                        // 売上伝票を更新する前に、送信済みのチェックを行う
                        if (!CheckSalesSending(salesSlipWork, out errMessage))
                        {
                            // チェックNG
                            status = STATUS_CHK_SEND_ERR;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                            return status;
                        }
                        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                        //＠売上データ変更＠
                        # region [UPDATE SQL文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE SALESSLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF = @SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF = @DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,DEBITNLNKSALESSLNUMRF = @DEBITNLNKSALESSLNUM" + Environment.NewLine;
                        sqlText += " ,SALESSLIPCDRF = @SALESSLIPCD" + Environment.NewLine;
                        sqlText += " ,SALESGOODSCDRF = @SALESGOODSCD" + Environment.NewLine;
                        sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                        sqlText += " ,SALESINPSECCDRF = @SALESINPSECCD" + Environment.NewLine;
                        sqlText += " ,DEMANDADDUPSECCDRF = @DEMANDADDUPSECCD" + Environment.NewLine;
                        sqlText += " ,RESULTSADDUPSECCDRF = @RESULTSADDUPSECCD" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF = @UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,SALESSLIPUPDATECDRF = @SALESSLIPUPDATECD" + Environment.NewLine;
                        sqlText += " ,SEARCHSLIPDATERF = @SEARCHSLIPDATE" + Environment.NewLine;
                        sqlText += " ,SHIPMENTDAYRF = @SHIPMENTDAY" + Environment.NewLine;
                        sqlText += " ,SALESDATERF = @SALESDATE" + Environment.NewLine;
                        sqlText += " ,ADDUPADATERF = @ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,DELAYPAYMENTDIVRF = @DELAYPAYMENTDIV" + Environment.NewLine;
                        sqlText += " ,ESTIMATEFORMNORF = @ESTIMATEFORMNO" + Environment.NewLine;
                        sqlText += " ,ESTIMATEDIVIDERF = @ESTIMATEDIVIDE" + Environment.NewLine;
                        sqlText += " ,INPUTAGENCDRF = @INPUTAGENCD" + Environment.NewLine;
                        sqlText += " ,INPUTAGENNMRF = @INPUTAGENNM" + Environment.NewLine;
                        sqlText += " ,SALESINPUTCODERF = @SALESINPUTCODE" + Environment.NewLine;
                        sqlText += " ,SALESINPUTNAMERF = @SALESINPUTNAME" + Environment.NewLine;
                        sqlText += " ,FRONTEMPLOYEECDRF = @FRONTEMPLOYEECD" + Environment.NewLine;
                        sqlText += " ,FRONTEMPLOYEENMRF = @FRONTEMPLOYEENM" + Environment.NewLine;
                        sqlText += " ,SALESEMPLOYEECDRF = @SALESEMPLOYEECD" + Environment.NewLine;
                        sqlText += " ,SALESEMPLOYEENMRF = @SALESEMPLOYEENM" + Environment.NewLine;
                        sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlText += " ,TTLAMNTDISPRATEAPYRF = @TTLAMNTDISPRATEAPY" + Environment.NewLine;
                        sqlText += " ,SALESTOTALTAXINCRF = @SALESTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,SALESTOTALTAXEXCRF = @SALESTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,SALESPRTTOTALTAXINCRF = @SALESPRTTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,SALESPRTTOTALTAXEXCRF = @SALESPRTTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,SALESWORKTOTALTAXINCRF = @SALESWORKTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,SALESWORKTOTALTAXEXCRF = @SALESWORKTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXINCRF = @SALESSUBTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXEXCRF = @SALESSUBTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,SALESPRTSUBTTLINCRF = @SALESPRTSUBTTLINC" + Environment.NewLine;
                        sqlText += " ,SALESPRTSUBTTLEXCRF = @SALESPRTSUBTTLEXC" + Environment.NewLine;
                        sqlText += " ,SALESWORKSUBTTLINCRF = @SALESWORKSUBTTLINC" + Environment.NewLine;
                        sqlText += " ,SALESWORKSUBTTLEXCRF = @SALESWORKSUBTTLEXC" + Environment.NewLine;
                        sqlText += " ,SALESNETPRICERF = @SALESNETPRICE" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXRF = @SALESSUBTOTALTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESOUTTAXRF = @ITDEDSALESOUTTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESINTAXRF = @ITDEDSALESINTAX" + Environment.NewLine;
                        sqlText += " ,SALSUBTTLSUBTOTAXFRERF = @SALSUBTTLSUBTOTAXFRE" + Environment.NewLine;
                        sqlText += " ,SALESOUTTAXRF = @SALESOUTTAX" + Environment.NewLine;
                        sqlText += " ,SALAMNTCONSTAXINCLURF = @SALAMNTCONSTAXINCLU" + Environment.NewLine;
                        sqlText += " ,SALESDISTTLTAXEXCRF = @SALESDISTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISOUTTAXRF = @ITDEDSALESDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISINTAXRF = @ITDEDSALESDISINTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDPARTSDISOUTTAXRF = @ITDEDPARTSDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDPARTSDISINTAXRF = @ITDEDPARTSDISINTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDWORKDISOUTTAXRF = @ITDEDWORKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDWORKDISINTAXRF = @ITDEDWORKDISINTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISTAXFRERF = @ITDEDSALESDISTAXFRE" + Environment.NewLine;
                        sqlText += " ,SALESDISOUTTAXRF = @SALESDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,SALESDISTTLTAXINCLURF = @SALESDISTTLTAXINCLU" + Environment.NewLine;
                        sqlText += " ,PARTSDISCOUNTRATERF = @PARTSDISCOUNTRATE" + Environment.NewLine;
                        sqlText += " ,RAVORDISCOUNTRATERF = @RAVORDISCOUNTRATE" + Environment.NewLine;
                        sqlText += " ,TOTALCOSTRF = @TOTALCOST" + Environment.NewLine;
                        sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += " ,CONSTAXRATERF = @CONSTAXRATE" + Environment.NewLine;
                        sqlText += " ,FRACTIONPROCCDRF = @FRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " ,ACCRECCONSTAXRF = @ACCRECCONSTAX" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITCDRF = @AUTODEPOSITCD" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITSLIPNORF = @AUTODEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCETTLRF = @DEPOSITALLOWANCETTL" + Environment.NewLine;
                        sqlText += " ,DEPOSITALWCBLNCERF = @DEPOSITALWCBLNCE" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,CLAIMSNMRF = @CLAIMSNM" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF = @CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF = @CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,CUSTSLIPNORF = @CUSTSLIPNO" + Environment.NewLine;
                        sqlText += " ,SLIPADDRESSDIVRF = @SLIPADDRESSDIV" + Environment.NewLine;
                        sqlText += " ,ADDRESSEECODERF = @ADDRESSEECODE" + Environment.NewLine;
                        sqlText += " ,ADDRESSEENAMERF = @ADDRESSEENAME" + Environment.NewLine;
                        sqlText += " ,ADDRESSEENAME2RF = @ADDRESSEENAME2" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEPOSTNORF = @ADDRESSEEPOSTNO" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR1RF = @ADDRESSEEADDR1" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR3RF = @ADDRESSEEADDR3" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR4RF = @ADDRESSEEADDR4" + Environment.NewLine;
                        sqlText += " ,ADDRESSEETELNORF = @ADDRESSEETELNO" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEFAXNORF = @ADDRESSEEFAXNO" + Environment.NewLine;
                        sqlText += " ,PARTYSALESLIPNUMRF = @PARTYSALESLIPNUM" + Environment.NewLine;
                        sqlText += " ,SLIPNOTERF = @SLIPNOTE" + Environment.NewLine;
                        sqlText += " ,SLIPNOTE2RF = @SLIPNOTE2" + Environment.NewLine;
                        sqlText += " ,SLIPNOTE3RF = @SLIPNOTE3" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONDIVRF = @RETGOODSREASONDIV" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONRF = @RETGOODSREASON" + Environment.NewLine;
                        sqlText += " ,REGIPROCDATERF = @REGIPROCDATE" + Environment.NewLine;
                        sqlText += " ,CASHREGISTERNORF = @CASHREGISTERNO" + Environment.NewLine;
                        sqlText += " ,POSRECEIPTNORF = @POSRECEIPTNO" + Environment.NewLine;
                        sqlText += " ,DETAILROWCOUNTRF = @DETAILROWCOUNT" + Environment.NewLine;
                        sqlText += " ,EDISENDDATERF = @EDISENDDATE" + Environment.NewLine;
                        sqlText += " ,EDITAKEINDATERF = @EDITAKEINDATE" + Environment.NewLine;
                        sqlText += " ,UOEREMARK1RF = @UOEREMARK1" + Environment.NewLine;
                        sqlText += " ,UOEREMARK2RF = @UOEREMARK2" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTDIVCDRF = @SLIPPRINTDIVCD" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTFINISHCDRF = @SLIPPRINTFINISHCD" + Environment.NewLine;
                        sqlText += " ,SALESSLIPPRINTDATERF = @SALESSLIPPRINTDATE" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPENAMERF = @BUSINESSTYPENAME" + Environment.NewLine;
                        sqlText += " ,ORDERNUMBERRF = @ORDERNUMBER" + Environment.NewLine;
                        sqlText += " ,DELIVEREDGOODSDIVRF = @DELIVEREDGOODSDIV" + Environment.NewLine;
                        sqlText += " ,DELIVEREDGOODSDIVNMRF = @DELIVEREDGOODSDIVNM" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,SALESAREANAMERF = @SALESAREANAME" + Environment.NewLine;
                        sqlText += " ,RECONCILEFLAGRF = @RECONCILEFLAG" + Environment.NewLine;
                        sqlText += " ,SLIPPRTSETPAPERIDRF = @SLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlText += " ,COMPLETECDRF = @COMPLETECD" + Environment.NewLine;
                        sqlText += " ,SALESPRICEFRACPROCCDRF = @SALESPRICEFRACPROCCD" + Environment.NewLine;
                        sqlText += " ,STOCKGOODSTTLTAXEXCRF = @STOCKGOODSTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,PUREGOODSTTLTAXEXCRF = @PUREGOODSTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,LISTPRICEPRINTDIVRF = @LISTPRICEPRINTDIV" + Environment.NewLine;
                        sqlText += " ,ERANAMEDISPCD1RF = @ERANAMEDISPCD1" + Environment.NewLine;
                        sqlText += " ,ESTIMATAXDIVCDRF = @ESTIMATAXDIVCD" + Environment.NewLine;
                        sqlText += " ,ESTIMATEFORMPRTCDRF = @ESTIMATEFORMPRTCD" + Environment.NewLine;
                        sqlText += " ,ESTIMATESUBJECTRF = @ESTIMATESUBJECT" + Environment.NewLine;
                        sqlText += " ,FOOTNOTES1RF = @FOOTNOTES1" + Environment.NewLine;
                        sqlText += " ,FOOTNOTES2RF = @FOOTNOTES2" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE1RF = @ESTIMATETITLE1" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE2RF = @ESTIMATETITLE2" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE3RF = @ESTIMATETITLE3" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE4RF = @ESTIMATETITLE4" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE5RF = @ESTIMATETITLE5" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE1RF = @ESTIMATENOTE1" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE2RF = @ESTIMATENOTE2" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE3RF = @ESTIMATENOTE3" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE4RF = @ESTIMATENOTE4" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE5RF = @ESTIMATENOTE5" + Environment.NewLine;
                        sqlText += " ,ESTIMATEVALIDITYDATERF = @ESTIMATEVALIDITYDATE" + Environment.NewLine;
                        sqlText += " ,PARTSNOPRTCDRF = @PARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,OPTIONPRINGDIVCDRF = @OPTIONPRINGDIVCD" + Environment.NewLine;
                        sqlText += " ,RATEUSECODERF = @RATEUSECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                        # endregion
                        sqlCommand.CommandText = sqlText;
                        
                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)salesSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    //売上伝票の新規登録
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (salesSlipWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                                return status;
                        }

                        //＠売上データ変更＠
                        # region [INSERT SQL文]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SALESSLIPRF (" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                        sqlText += " ,DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPCDRF" + Environment.NewLine;
                        sqlText += " ,SALESGOODSCDRF" + Environment.NewLine;
                        sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                        sqlText += " ,SALESINPSECCDRF" + Environment.NewLine;
                        sqlText += " ,DEMANDADDUPSECCDRF" + Environment.NewLine;
                        sqlText += " ,RESULTSADDUPSECCDRF" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPUPDATECDRF" + Environment.NewLine;
                        sqlText += " ,SEARCHSLIPDATERF" + Environment.NewLine;
                        sqlText += " ,SHIPMENTDAYRF" + Environment.NewLine;
                        sqlText += " ,SALESDATERF" + Environment.NewLine;
                        sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                        sqlText += " ,DELAYPAYMENTDIVRF" + Environment.NewLine;
                        sqlText += " ,ESTIMATEFORMNORF" + Environment.NewLine;
                        sqlText += " ,ESTIMATEDIVIDERF" + Environment.NewLine;
                        sqlText += " ,INPUTAGENCDRF" + Environment.NewLine;
                        sqlText += " ,INPUTAGENNMRF" + Environment.NewLine;
                        sqlText += " ,SALESINPUTCODERF" + Environment.NewLine;
                        sqlText += " ,SALESINPUTNAMERF" + Environment.NewLine;
                        sqlText += " ,FRONTEMPLOYEECDRF" + Environment.NewLine;
                        sqlText += " ,FRONTEMPLOYEENMRF" + Environment.NewLine;
                        sqlText += " ,SALESEMPLOYEECDRF" + Environment.NewLine;
                        sqlText += " ,SALESEMPLOYEENMRF" + Environment.NewLine;
                        sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlText += " ,TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                        sqlText += " ,SALESTOTALTAXINCRF" + Environment.NewLine;
                        sqlText += " ,SALESTOTALTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESPRTTOTALTAXINCRF" + Environment.NewLine;
                        sqlText += " ,SALESPRTTOTALTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESWORKTOTALTAXINCRF" + Environment.NewLine;
                        sqlText += " ,SALESWORKTOTALTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESPRTSUBTTLINCRF" + Environment.NewLine;
                        sqlText += " ,SALESPRTSUBTTLEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESWORKSUBTTLINCRF" + Environment.NewLine;
                        sqlText += " ,SALESWORKSUBTTLEXCRF" + Environment.NewLine;
                        sqlText += " ,SALESNETPRICERF" + Environment.NewLine;
                        sqlText += " ,SALESSUBTOTALTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        sqlText += " ,SALSUBTTLSUBTOTAXFRERF" + Environment.NewLine;
                        sqlText += " ,SALESOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                        sqlText += " ,SALESDISTTLTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISINTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDPARTSDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDPARTSDISINTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDWORKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDWORKDISINTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSALESDISTAXFRERF" + Environment.NewLine;
                        sqlText += " ,SALESDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,SALESDISTTLTAXINCLURF" + Environment.NewLine;
                        sqlText += " ,PARTSDISCOUNTRATERF" + Environment.NewLine;
                        sqlText += " ,RAVORDISCOUNTRATERF" + Environment.NewLine;
                        sqlText += " ,TOTALCOSTRF" + Environment.NewLine;
                        sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += " ,CONSTAXRATERF" + Environment.NewLine;
                        sqlText += " ,FRACTIONPROCCDRF" + Environment.NewLine;
                        sqlText += " ,ACCRECCONSTAXRF" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITCDRF" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITSLIPNORF" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                        sqlText += " ,DEPOSITALWCBLNCERF" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                        sqlText += " ,CLAIMSNMRF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                        sqlText += " ,CUSTSLIPNORF" + Environment.NewLine;
                        sqlText += " ,SLIPADDRESSDIVRF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEECODERF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEENAMERF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEENAME2RF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEPOSTNORF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR1RF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR3RF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEADDR4RF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEETELNORF" + Environment.NewLine;
                        sqlText += " ,ADDRESSEEFAXNORF" + Environment.NewLine;
                        sqlText += " ,PARTYSALESLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,SLIPNOTERF" + Environment.NewLine;
                        sqlText += " ,SLIPNOTE2RF" + Environment.NewLine;
                        sqlText += " ,SLIPNOTE3RF" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONDIVRF" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONRF" + Environment.NewLine;
                        sqlText += " ,REGIPROCDATERF" + Environment.NewLine;
                        sqlText += " ,CASHREGISTERNORF" + Environment.NewLine;
                        sqlText += " ,POSRECEIPTNORF" + Environment.NewLine;
                        sqlText += " ,DETAILROWCOUNTRF" + Environment.NewLine;
                        sqlText += " ,EDISENDDATERF" + Environment.NewLine;
                        sqlText += " ,EDITAKEINDATERF" + Environment.NewLine;
                        sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                        sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTDIVCDRF" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPPRINTDATERF" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPENAMERF" + Environment.NewLine;
                        sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                        sqlText += " ,DELIVEREDGOODSDIVRF" + Environment.NewLine;
                        sqlText += " ,DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                        sqlText += " ,SALESAREANAMERF" + Environment.NewLine;
                        sqlText += " ,RECONCILEFLAGRF" + Environment.NewLine;
                        sqlText += " ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlText += " ,COMPLETECDRF" + Environment.NewLine;
                        sqlText += " ,SALESPRICEFRACPROCCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKGOODSTTLTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,PUREGOODSTTLTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,LISTPRICEPRINTDIVRF" + Environment.NewLine;
                        sqlText += " ,ERANAMEDISPCD1RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATAXDIVCDRF" + Environment.NewLine;
                        sqlText += " ,ESTIMATEFORMPRTCDRF" + Environment.NewLine;
                        sqlText += " ,ESTIMATESUBJECTRF" + Environment.NewLine;
                        sqlText += " ,FOOTNOTES1RF" + Environment.NewLine;
                        sqlText += " ,FOOTNOTES2RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE1RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE2RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE3RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE4RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATETITLE5RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE1RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE2RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE3RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE4RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATENOTE5RF" + Environment.NewLine;
                        sqlText += " ,ESTIMATEVALIDITYDATERF" + Environment.NewLine;
                        sqlText += " ,PARTSNOPRTCDRF" + Environment.NewLine;
                        sqlText += " ,OPTIONPRINGDIVCDRF" + Environment.NewLine;
                        sqlText += " ,RATEUSECODERF)" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,@DEBITNLNKSALESSLNUM" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPCD" + Environment.NewLine;
                        sqlText += " ,@SALESGOODSCD" + Environment.NewLine;
                        sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                        sqlText += " ,@SALESINPSECCD" + Environment.NewLine;
                        sqlText += " ,@DEMANDADDUPSECCD" + Environment.NewLine;
                        sqlText += " ,@RESULTSADDUPSECCD" + Environment.NewLine;
                        sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPUPDATECD" + Environment.NewLine;
                        sqlText += " ,@SEARCHSLIPDATE" + Environment.NewLine;
                        sqlText += " ,@SHIPMENTDAY" + Environment.NewLine;
                        sqlText += " ,@SALESDATE" + Environment.NewLine;
                        sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,@DELAYPAYMENTDIV" + Environment.NewLine;
                        sqlText += " ,@ESTIMATEFORMNO" + Environment.NewLine;
                        sqlText += " ,@ESTIMATEDIVIDE" + Environment.NewLine;
                        sqlText += " ,@INPUTAGENCD" + Environment.NewLine;
                        sqlText += " ,@INPUTAGENNM" + Environment.NewLine;
                        sqlText += " ,@SALESINPUTCODE" + Environment.NewLine;
                        sqlText += " ,@SALESINPUTNAME" + Environment.NewLine;
                        sqlText += " ,@FRONTEMPLOYEECD" + Environment.NewLine;
                        sqlText += " ,@FRONTEMPLOYEENM" + Environment.NewLine;
                        sqlText += " ,@SALESEMPLOYEECD" + Environment.NewLine;
                        sqlText += " ,@SALESEMPLOYEENM" + Environment.NewLine;
                        sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlText += " ,@TTLAMNTDISPRATEAPY" + Environment.NewLine;
                        sqlText += " ,@SALESTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,@SALESTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,@SALESPRTTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,@SALESPRTTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,@SALESWORKTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,@SALESWORKTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,@SALESSUBTOTALTAXINC" + Environment.NewLine;
                        sqlText += " ,@SALESSUBTOTALTAXEXC" + Environment.NewLine;
                        sqlText += " ,@SALESPRTSUBTTLINC" + Environment.NewLine;
                        sqlText += " ,@SALESPRTSUBTTLEXC" + Environment.NewLine;
                        sqlText += " ,@SALESWORKSUBTTLINC" + Environment.NewLine;
                        sqlText += " ,@SALESWORKSUBTTLEXC" + Environment.NewLine;
                        sqlText += " ,@SALESNETPRICE" + Environment.NewLine;
                        sqlText += " ,@SALESSUBTOTALTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSALESINTAX" + Environment.NewLine;
                        sqlText += " ,@SALSUBTTLSUBTOTAXFRE" + Environment.NewLine;
                        sqlText += " ,@SALESOUTTAX" + Environment.NewLine;
                        sqlText += " ,@SALAMNTCONSTAXINCLU" + Environment.NewLine;
                        sqlText += " ,@SALESDISTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,@ITDEDSALESDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSALESDISINTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDPARTSDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDPARTSDISINTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDWORKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDWORKDISINTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSALESDISTAXFRE" + Environment.NewLine;
                        sqlText += " ,@SALESDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@SALESDISTTLTAXINCLU" + Environment.NewLine;
                        sqlText += " ,@PARTSDISCOUNTRATE" + Environment.NewLine;
                        sqlText += " ,@RAVORDISCOUNTRATE" + Environment.NewLine;
                        sqlText += " ,@TOTALCOST" + Environment.NewLine;
                        sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += " ,@CONSTAXRATE" + Environment.NewLine;
                        sqlText += " ,@FRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " ,@ACCRECCONSTAX" + Environment.NewLine;
                        sqlText += " ,@AUTODEPOSITCD" + Environment.NewLine;
                        sqlText += " ,@AUTODEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,@DEPOSITALLOWANCETTL" + Environment.NewLine;
                        sqlText += " ,@DEPOSITALWCBLNCE" + Environment.NewLine;
                        sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,@CLAIMSNM" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                        sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                        sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,@CUSTSLIPNO" + Environment.NewLine;
                        sqlText += " ,@SLIPADDRESSDIV" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEECODE" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEENAME" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEENAME2" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEEPOSTNO" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEEADDR1" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEEADDR3" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEEADDR4" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEETELNO" + Environment.NewLine;
                        sqlText += " ,@ADDRESSEEFAXNO" + Environment.NewLine;
                        sqlText += " ,@PARTYSALESLIPNUM" + Environment.NewLine;
                        sqlText += " ,@SLIPNOTE" + Environment.NewLine;
                        sqlText += " ,@SLIPNOTE2" + Environment.NewLine;
                        sqlText += " ,@SLIPNOTE3" + Environment.NewLine;
                        sqlText += " ,@RETGOODSREASONDIV" + Environment.NewLine;
                        sqlText += " ,@RETGOODSREASON" + Environment.NewLine;
                        sqlText += " ,@REGIPROCDATE" + Environment.NewLine;
                        sqlText += " ,@CASHREGISTERNO" + Environment.NewLine;
                        sqlText += " ,@POSRECEIPTNO" + Environment.NewLine;
                        sqlText += " ,@DETAILROWCOUNT" + Environment.NewLine;
                        sqlText += " ,@EDISENDDATE" + Environment.NewLine;
                        sqlText += " ,@EDITAKEINDATE" + Environment.NewLine;
                        sqlText += " ,@UOEREMARK1" + Environment.NewLine;
                        sqlText += " ,@UOEREMARK2" + Environment.NewLine;
                        sqlText += " ,@SLIPPRINTDIVCD" + Environment.NewLine;
                        sqlText += " ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPPRINTDATE" + Environment.NewLine;
                        sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,@BUSINESSTYPENAME" + Environment.NewLine;
                        sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                        sqlText += " ,@DELIVEREDGOODSDIV" + Environment.NewLine;
                        sqlText += " ,@DELIVEREDGOODSDIVNM" + Environment.NewLine;
                        sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,@SALESAREANAME" + Environment.NewLine;
                        sqlText += " ,@RECONCILEFLAG" + Environment.NewLine;
                        sqlText += " ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlText += " ,@COMPLETECD" + Environment.NewLine;
                        sqlText += " ,@SALESPRICEFRACPROCCD" + Environment.NewLine;
                        sqlText += " ,@STOCKGOODSTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,@PUREGOODSTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,@LISTPRICEPRINTDIV" + Environment.NewLine;
                        sqlText += " ,@ERANAMEDISPCD1" + Environment.NewLine;
                        sqlText += " ,@ESTIMATAXDIVCD" + Environment.NewLine;
                        sqlText += " ,@ESTIMATEFORMPRTCD" + Environment.NewLine;
                        sqlText += " ,@ESTIMATESUBJECT" + Environment.NewLine;
                        sqlText += " ,@FOOTNOTES1" + Environment.NewLine;
                        sqlText += " ,@FOOTNOTES2" + Environment.NewLine;
                        sqlText += " ,@ESTIMATETITLE1" + Environment.NewLine;
                        sqlText += " ,@ESTIMATETITLE2" + Environment.NewLine;
                        sqlText += " ,@ESTIMATETITLE3" + Environment.NewLine;
                        sqlText += " ,@ESTIMATETITLE4" + Environment.NewLine;
                        sqlText += " ,@ESTIMATETITLE5" + Environment.NewLine;
                        sqlText += " ,@ESTIMATENOTE1" + Environment.NewLine;
                        sqlText += " ,@ESTIMATENOTE2" + Environment.NewLine;
                        sqlText += " ,@ESTIMATENOTE3" + Environment.NewLine;
                        sqlText += " ,@ESTIMATENOTE4" + Environment.NewLine;
                        sqlText += " ,@ESTIMATENOTE5" + Environment.NewLine;
                        sqlText += " ,@ESTIMATEVALIDITYDATE" + Environment.NewLine;
                        sqlText += " ,@PARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,@OPTIONPRINGDIVCD" + Environment.NewLine;
                        sqlText += " ,@RATEUSECODE)" + Environment.NewLine;
                        # endregion
                        sqlCommand.CommandText = sqlText;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)salesSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed) myReader.Close();
                        myReader.Dispose();
                    }

                    //＠売上データ変更＠
                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@DEBITNLNKSALESSLNUM", SqlDbType.NChar);
                    SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                    SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                    SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                    SqlParameter paraSalesInpSecCd = sqlCommand.Parameters.Add("@SALESINPSECCD", SqlDbType.NChar);
                    SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add("@DEMANDADDUPSECCD", SqlDbType.NChar);
                    SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                    SqlParameter paraSearchSlipDate = sqlCommand.Parameters.Add("@SEARCHSLIPDATE", SqlDbType.Int);
                    SqlParameter paraShipmentDay = sqlCommand.Parameters.Add("@SHIPMENTDAY", SqlDbType.Int);
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                    SqlParameter paraEstimateFormNo = sqlCommand.Parameters.Add("@ESTIMATEFORMNO", SqlDbType.NChar);
                    SqlParameter paraEstimateDivide = sqlCommand.Parameters.Add("@ESTIMATEDIVIDE", SqlDbType.Int);
                    SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
                    SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
                    SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                    SqlParameter paraSalesInputName = sqlCommand.Parameters.Add("@SALESINPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                    SqlParameter paraFrontEmployeeNm = sqlCommand.Parameters.Add("@FRONTEMPLOYEENM", SqlDbType.NVarChar);
                    SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                    SqlParameter paraSalesEmployeeNm = sqlCommand.Parameters.Add("@SALESEMPLOYEENM", SqlDbType.NVarChar);
                    SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                    SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                    SqlParameter paraSalesTotalTaxInc = sqlCommand.Parameters.Add("@SALESTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesTotalTaxExc = sqlCommand.Parameters.Add("@SALESTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtTotalTaxInc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtTotalTaxExc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkTotalTaxInc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkTotalTaxExc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTaxInc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTaxExc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtSubttlInc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLINC", SqlDbType.BigInt);
                    SqlParameter paraSalesPrtSubttlExc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkSubttlInc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLINC", SqlDbType.BigInt);
                    SqlParameter paraSalesWorkSubttlExc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLEXC", SqlDbType.BigInt);
                    SqlParameter paraSalesNetPrice = sqlCommand.Parameters.Add("@SALESNETPRICE", SqlDbType.BigInt);
                    SqlParameter paraSalesSubtotalTax = sqlCommand.Parameters.Add("@SALESSUBTOTALTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                    SqlParameter paraSalSubttlSubToTaxFre = sqlCommand.Parameters.Add("@SALSUBTTLSUBTOTAXFRE", SqlDbType.BigInt);
                    SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalAmntConsTaxInclu = sqlCommand.Parameters.Add("@SALAMNTCONSTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraSalesDisTtlTaxExc = sqlCommand.Parameters.Add("@SALESDISTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisOutTax = sqlCommand.Parameters.Add("@ITDEDSALESDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisInTax = sqlCommand.Parameters.Add("@ITDEDSALESDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedPartsDisOutTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedPartsDisInTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedWorkDisOutTax = sqlCommand.Parameters.Add("@ITDEDWORKDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedWorkDisInTax = sqlCommand.Parameters.Add("@ITDEDWORKDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedSalesDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSALESDISTAXFRE", SqlDbType.BigInt);
                    SqlParameter paraSalesDisOutTax = sqlCommand.Parameters.Add("@SALESDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraSalesDisTtlTaxInclu = sqlCommand.Parameters.Add("@SALESDISTTLTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraPartsDiscountRate = sqlCommand.Parameters.Add("@PARTSDISCOUNTRATE", SqlDbType.Float);
                    SqlParameter paraRavorDiscountRate = sqlCommand.Parameters.Add("@RAVORDISCOUNTRATE", SqlDbType.Float);
                    SqlParameter paraTotalCost = sqlCommand.Parameters.Add("@TOTALCOST", SqlDbType.BigInt);
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                    SqlParameter paraAccRecConsTax = sqlCommand.Parameters.Add("@ACCRECCONSTAX", SqlDbType.BigInt);
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    SqlParameter paraAutoDepositSlipNo = sqlCommand.Parameters.Add("@AUTODEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositAllowanceTtl = sqlCommand.Parameters.Add("@DEPOSITALLOWANCETTL", SqlDbType.BigInt);
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                    SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                    SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.Int);
                    SqlParameter paraSlipAddressDiv = sqlCommand.Parameters.Add("@SLIPADDRESSDIV", SqlDbType.Int);
                    SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                    SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeName2 = sqlCommand.Parameters.Add("@ADDRESSEENAME2", SqlDbType.NVarChar);
                    SqlParameter paraAddresseePostNo = sqlCommand.Parameters.Add("@ADDRESSEEPOSTNO", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr1 = sqlCommand.Parameters.Add("@ADDRESSEEADDR1", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr3 = sqlCommand.Parameters.Add("@ADDRESSEEADDR3", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeAddr4 = sqlCommand.Parameters.Add("@ADDRESSEEADDR4", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeTelNo = sqlCommand.Parameters.Add("@ADDRESSEETELNO", SqlDbType.NVarChar);
                    SqlParameter paraAddresseeFaxNo = sqlCommand.Parameters.Add("@ADDRESSEEFAXNO", SqlDbType.NVarChar);
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@SLIPNOTE2", SqlDbType.NVarChar);
                    SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@SLIPNOTE3", SqlDbType.NVarChar);
                    SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                    SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                    SqlParameter paraRegiProcDate = sqlCommand.Parameters.Add("@REGIPROCDATE", SqlDbType.Int);
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                    SqlParameter paraPosReceiptNo = sqlCommand.Parameters.Add("@POSRECEIPTNO", SqlDbType.Int);
                    SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                    SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                    SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                    SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                    SqlParameter paraSalesSlipPrintDate = sqlCommand.Parameters.Add("@SALESSLIPPRINTDATE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                    SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                    SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                    SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                    SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                    SqlParameter paraReconcileFlag = sqlCommand.Parameters.Add("@RECONCILEFLAG", SqlDbType.Int);
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                    SqlParameter paraCompleteCd = sqlCommand.Parameters.Add("@COMPLETECD", SqlDbType.Int);
                    SqlParameter paraSalesPriceFracProcCd = sqlCommand.Parameters.Add("@SALESPRICEFRACPROCCD", SqlDbType.Int);
                    SqlParameter paraStockGoodsTtlTaxExc = sqlCommand.Parameters.Add("@STOCKGOODSTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraPureGoodsTtlTaxExc = sqlCommand.Parameters.Add("@PUREGOODSTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraListPricePrintDiv = sqlCommand.Parameters.Add("@LISTPRICEPRINTDIV", SqlDbType.Int);
                    SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                    SqlParameter paraEstimaTaxDivCd = sqlCommand.Parameters.Add("@ESTIMATAXDIVCD", SqlDbType.Int);
                    SqlParameter paraEstimateFormPrtCd = sqlCommand.Parameters.Add("@ESTIMATEFORMPRTCD", SqlDbType.Int);
                    SqlParameter paraEstimateSubject = sqlCommand.Parameters.Add("@ESTIMATESUBJECT", SqlDbType.NVarChar);
                    SqlParameter paraFootnotes1 = sqlCommand.Parameters.Add("@FOOTNOTES1", SqlDbType.NVarChar);
                    SqlParameter paraFootnotes2 = sqlCommand.Parameters.Add("@FOOTNOTES2", SqlDbType.NVarChar);
                    SqlParameter paraEstimateTitle1 = sqlCommand.Parameters.Add("@ESTIMATETITLE1", SqlDbType.NVarChar);
                    SqlParameter paraEstimateTitle2 = sqlCommand.Parameters.Add("@ESTIMATETITLE2", SqlDbType.NVarChar);
                    SqlParameter paraEstimateTitle3 = sqlCommand.Parameters.Add("@ESTIMATETITLE3", SqlDbType.NVarChar);
                    SqlParameter paraEstimateTitle4 = sqlCommand.Parameters.Add("@ESTIMATETITLE4", SqlDbType.NVarChar);
                    SqlParameter paraEstimateTitle5 = sqlCommand.Parameters.Add("@ESTIMATETITLE5", SqlDbType.NVarChar);
                    SqlParameter paraEstimateNote1 = sqlCommand.Parameters.Add("@ESTIMATENOTE1", SqlDbType.NVarChar);
                    SqlParameter paraEstimateNote2 = sqlCommand.Parameters.Add("@ESTIMATENOTE2", SqlDbType.NVarChar);
                    SqlParameter paraEstimateNote3 = sqlCommand.Parameters.Add("@ESTIMATENOTE3", SqlDbType.NVarChar);
                    SqlParameter paraEstimateNote4 = sqlCommand.Parameters.Add("@ESTIMATENOTE4", SqlDbType.NVarChar);
                    SqlParameter paraEstimateNote5 = sqlCommand.Parameters.Add("@ESTIMATENOTE5", SqlDbType.NVarChar);
                    SqlParameter paraEstimateValidityDate = sqlCommand.Parameters.Add("@ESTIMATEVALIDITYDATE", SqlDbType.Int);
                    SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                    SqlParameter paraOptionPringDivCd = sqlCommand.Parameters.Add("@OPTIONPRINGDIVCD", SqlDbType.Int);
                    SqlParameter paraRateUseCode = sqlCommand.Parameters.Add("@RATEUSECODE", SqlDbType.Int);
                    #endregion

                    //＠売上データ変更＠
                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesSlipWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesSlipWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesSlipWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.SectionCode);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SubSectionCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.DebitNoteDiv);
                    paraDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.DebitNLnkSalesSlNum);
                    paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SalesSlipCd);
                    paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SalesGoodsCd);
                    paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AccRecDivCd);
                    paraSalesInpSecCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesInpSecCd);
                    paraDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.DemandAddUpSecCd);
                    paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.ResultsAddUpSecCd);
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdateSecCd);
                    paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SalesSlipUpdateCd);
                    paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.SearchSlipDate);
                    paraShipmentDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.ShipmentDay);
                    paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.SalesDate);
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.AddUpADate);
                    paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.DelayPaymentDiv);
                    paraEstimateFormNo.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateFormNo);
                    paraEstimateDivide.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.EstimateDivide);
                    paraInputAgenCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.InputAgenCd);
                    paraInputAgenNm.Value = SqlDataMediator.SqlSetString(salesSlipWork.InputAgenNm);
                    paraSalesInputCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesInputCode);
                    paraSalesInputName.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesInputName);
                    paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.FrontEmployeeCd);
                    paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(salesSlipWork.FrontEmployeeNm);
                    paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesEmployeeCd);
                    paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesEmployeeNm);
                    paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.TotalAmountDispWayCd);
                    paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.TtlAmntDispRateApy);
                    paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesTotalTaxInc);
                    paraSalesTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesTotalTaxExc);
                    paraSalesPrtTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesPrtTotalTaxInc);
                    paraSalesPrtTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesPrtTotalTaxExc);
                    paraSalesWorkTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesWorkTotalTaxInc);
                    paraSalesWorkTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesWorkTotalTaxExc);
                    paraSalesSubtotalTaxInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesSubtotalTaxInc);
                    paraSalesSubtotalTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesSubtotalTaxExc);
                    paraSalesPrtSubttlInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesPrtSubttlInc);
                    paraSalesPrtSubttlExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesPrtSubttlExc);
                    paraSalesWorkSubttlInc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesWorkSubttlInc);
                    paraSalesWorkSubttlExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesWorkSubttlExc);
                    paraSalesNetPrice.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesNetPrice);
                    paraSalesSubtotalTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesSubtotalTax);
                    paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedSalesOutTax);
                    paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedSalesInTax);
                    paraSalSubttlSubToTaxFre.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalSubttlSubToTaxFre);
                    paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesOutTax);
                    paraSalAmntConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalAmntConsTaxInclu);
                    paraSalesDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesDisTtlTaxExc);
                    paraItdedSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedSalesDisOutTax);
                    paraItdedSalesDisInTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedSalesDisInTax);
                    paraItdedPartsDisOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedPartsDisOutTax);
                    paraItdedPartsDisInTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedPartsDisInTax);
                    paraItdedWorkDisOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedWorkDisOutTax);
                    paraItdedWorkDisInTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedWorkDisInTax);
                    paraItdedSalesDisTaxFre.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.ItdedSalesDisTaxFre);
                    paraSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesDisOutTax);
                    paraSalesDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.SalesDisTtlTaxInclu);
                    paraPartsDiscountRate.Value = SqlDataMediator.SqlSetDouble(salesSlipWork.PartsDiscountRate);
                    paraRavorDiscountRate.Value = SqlDataMediator.SqlSetDouble(salesSlipWork.RavorDiscountRate);
                    paraTotalCost.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.TotalCost);
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.ConsTaxLayMethod);
                    paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(salesSlipWork.ConsTaxRate);
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.FractionProcCd);
                    paraAccRecConsTax.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.AccRecConsTax);
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AutoDepositCd);
                    paraAutoDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AutoDepositSlipNo);
                    paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.DepositAllowanceTtl);
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.DepositAlwcBlnce);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.ClaimCode);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(salesSlipWork.ClaimSnm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(salesSlipWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(salesSlipWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(salesSlipWork.CustomerSnm);
                    paraHonorificTitle.Value = SqlDataMediator.SqlSetString(salesSlipWork.HonorificTitle);
                    paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.OutputNameCode);
                    paraOutputName.Value = SqlDataMediator.SqlSetString(salesSlipWork.OutputName);
                    paraCustSlipNo.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.CustSlipNo);
                    paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SlipAddressDiv);
                    paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AddresseeCode);
                    paraAddresseeName.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeName);
                    paraAddresseeName2.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeName2);
                    paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseePostNo);
                    paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeAddr1);
                    paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeAddr3);
                    paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeAddr4);
                    paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeTelNo);
                    paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(salesSlipWork.AddresseeFaxNo);
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.PartySaleSlipNum);
                    paraSlipNote.Value = SqlDataMediator.SqlSetString(salesSlipWork.SlipNote);
                    paraSlipNote2.Value = SqlDataMediator.SqlSetString(salesSlipWork.SlipNote2);
                    paraSlipNote3.Value = SqlDataMediator.SqlSetString(salesSlipWork.SlipNote3);
                    paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.RetGoodsReasonDiv);
                    paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(salesSlipWork.RetGoodsReason);
                    paraRegiProcDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.RegiProcDate);
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.CashRegisterNo);
                    paraPosReceiptNo.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.PosReceiptNo);
                    paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.DetailRowCount);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.EdiSendDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.EdiTakeInDate);
                    paraUoeRemark1.Value = SqlDataMediator.SqlSetString(salesSlipWork.UoeRemark1);
                    paraUoeRemark2.Value = SqlDataMediator.SqlSetString(salesSlipWork.UoeRemark2);
                    paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SlipPrintDivCd);
                    paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SlipPrintFinishCd);
                    paraSalesSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.SalesSlipPrintDate);
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.BusinessTypeCode);
                    paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(salesSlipWork.BusinessTypeName);
                    paraOrderNumber.Value = SqlDataMediator.SqlSetString(salesSlipWork.OrderNumber);
                    paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.DeliveredGoodsDiv);
                    paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(salesSlipWork.DeliveredGoodsDivNm);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SalesAreaCode);
                    paraSalesAreaName.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesAreaName);
                    paraReconcileFlag.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.ReconcileFlag);
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(salesSlipWork.SlipPrtSetPaperId);
                    paraCompleteCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.CompleteCd);
                    paraSalesPriceFracProcCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SalesPriceFracProcCd);
                    paraStockGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.StockGoodsTtlTaxExc);
                    paraPureGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(salesSlipWork.PureGoodsTtlTaxExc);
                    paraListPricePrintDiv.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.ListPricePrintDiv);
                    paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.EraNameDispCd1);
                    paraEstimaTaxDivCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.EstimaTaxDivCd);
                    paraEstimateFormPrtCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.EstimateFormPrtCd);
                    paraEstimateSubject.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateSubject);
                    paraFootnotes1.Value = SqlDataMediator.SqlSetString(salesSlipWork.Footnotes1);
                    paraFootnotes2.Value = SqlDataMediator.SqlSetString(salesSlipWork.Footnotes2);
                    paraEstimateTitle1.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateTitle1);
                    paraEstimateTitle2.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateTitle2);
                    paraEstimateTitle3.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateTitle3);
                    paraEstimateTitle4.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateTitle4);
                    paraEstimateTitle5.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateTitle5);
                    paraEstimateNote1.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateNote1);
                    paraEstimateNote2.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateNote2);
                    paraEstimateNote3.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateNote3);
                    paraEstimateNote4.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateNote4);
                    paraEstimateNote5.Value = SqlDataMediator.SqlSetString(salesSlipWork.EstimateNote5);
                    paraEstimateValidityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.EstimateValidityDate);
                    paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.PartsNoPrtCd);
                    paraOptionPringDivCd.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.OptionPringDivCd);
                    paraRateUseCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.RateUseCode);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            if (myReader != null)
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 売上データの送信済みのチェック
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>true: チェックOK、false：チェックNG</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note: 2012/02/06 田建委</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28288 送信済データ修正制御の対応</br>
        /// <br>Update Note: 2012/08/10 脇田 靖之</br>
        /// <br>             拠点管理 送信済データチェック不具合対応</br>
        /// </remarks>
        private bool CheckSalesSending(SalesSlipWork salesSlipWork, out string errMessage)
        {
            errMessage = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // -- UPD 2011/09/27 osanai -------------------------------------->>>
            ////ADD 2011/09/27 sundx #25578 売上データに対してのみ行う様に変更------>>>>>
            //if (salesSlipWork.AcptAnOdrStatus != 30)
            //{
            //    return true;
            //}
            ////ADD 2011/09/27 sundx #25578 売上データに対してのみ行う様に変更------<<<<<

            // 受注ステータスが売上以外の場合、あるいは、元黒伝票の場合は、チェック処理を行わない
            if (salesSlipWork.AcptAnOdrStatus != 30 || salesSlipWork.DebitNoteDiv == 2)
            {
                return true;
            }
            // -- UPD 2011/09/27 osanai --------------------------------------<<<

            // チェックを行うかどうかが下記のように判断する(②～③)
            // ②拠点管理送受信対象マスタに売上データの拠点管理送信区分が「1:送信あり」----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
            object outSecMngSndRcvList = null;
            
            // 拠点管理送受信対象マスタ情報を取得
            status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;
            
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSndRcvList || secMngSndRcvList.Count == 0)
                // ０件の場合、チェックOK
                return true;
            
            bool isHaveObj = false;
            foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
            {
                if (string.Equals("SalesSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase) 
                    && resultSecMngSndRcvWork.SecMngSendDiv == 1
                    && resultSecMngSndRcvWork.LogicalDeleteCode == 0)
                {
                    isHaveObj = true;
                    break;
                }
            }
            if (!isHaveObj)
                // ０件の場合、チェックOK
                return true;
            // ②拠点管理送受信対象マスタに売上データの拠点管理送信区分が「1:送信あり」-----------<


            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------>>
            // 種別＝0:データ
            // 受信状況＝0:送信
            // 送信対象拠点＝更新する売上データの実績計上拠点コード
            // 送信済データ修正区分＝修正不可
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
            int sndFinDataEdDiv = 0; //ADD 2011/11/10 xupz
            // 拠点管理設定マスタ情報を取得
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // ０件の場合、チェックOK
                return true;

            isHaveObj = false;
            string resultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd;
            if (null != resultsAddUpSecCd)
                resultsAddUpSecCd = resultsAddUpSecCd.Trim();
            DateTime maxSyncExecDate = DateTime.MinValue; // 拠点管理設定マスタの送信実行日
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // 種別＝0:データ && 受信状況＝0:送信
                    && resultSecMngSetWork.SectionCode.Trim() == resultsAddUpSecCd
                    // 送信対象拠点＝更新する売上データの実績計上拠点コード
                    // ----- DEL 2011/11/10 xupz---------->>>>>
                    //&& resultSecMngSetWork.SndFinDataEdDiv == 1
                    //// 送信済データ修正区分＝修正不可
                    // ----- DEL 2011/11/10 xupz----------<<<<<
                    // ----- ADD 2011/11/10 xupz---------->>>>>
                    && ((resultSecMngSetWork.SndFinDataEdDiv == 1) || (resultSecMngSetWork.SndFinDataEdDiv == 2))
                    // 送信済データ修正区分＝修正不可(1:修正不可（送信実行日以前);2:修正不可（伝票日付以前）)
                    // ----- ADD 2011/11/10 xupz----------<<<<<
                    && resultSecMngSetWork.LogicalDeleteCode == 0
                    )
                    
                {
                    isHaveObj = true;
                    if (resultSecMngSetWork.SyncExecDate.CompareTo(maxSyncExecDate) > 0)
                    //maxSyncExecDate = resultSecMngSetWork.SyncExecDate; //DEL 2011/11/10 xupz
                    // ----- ADD 2011/11/10 xupz---------->>>>>
                    {
                        maxSyncExecDate = resultSecMngSetWork.SyncExecDate;
                        sndFinDataEdDiv = resultSecMngSetWork.SndFinDataEdDiv;
                    }
                    // ----- ADD 2011/11/10 xupz----------<<<<<
                }
            }
            if (!isHaveObj)
                // ０件の場合、チェックOK
                return true;
            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------<<


            // チェック処理 -------------------------------------->>>
            // ----- DEL 2011/11/10 xupz---------->>>>>
            //if (salesSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)
            //{
            //    errMessage = "送信済みのデータの為、更新できません。";
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            // ----- DEL 2011/11/10 xupz----------<<<<<
            // ----- ADD 2011/11/10 xupz---------->>>>>
            if (sndFinDataEdDiv == 1)
            {
                if (salesSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)
                {
                    errMessage = "送信済みのデータの為、更新できません。";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (sndFinDataEdDiv == 2)
            {
                //if (salesSlipWork.SalesDate.CompareTo(maxSyncExecDate) <= 0) // DEL 2011/12/15
                //if (salesSlipWork.PreSalesDate.CompareTo(maxSyncExecDate) <= 0) // ADD 2011/12/15 // DEL 2012/02/06 田建委 Redmine#28288
                //if (salesSlipWork.PreSalesDate.CompareTo(maxSyncExecDate) <= 0 && salesSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) // ADD 2012/02/06 田建委 Redmine#28288 DEL 2012/08/10 Y.Wakita
                if (salesSlipWork.PreSalesDate.CompareTo(maxSyncExecDate) <= 0 && salesSlipWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0) // ADD 2012/08/10 Y.Wakita
                    {
                    errMessage = "送信済みのデータの為、更新できません。";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            // ----- ADD 2011/11/10 xupz----------<<<<<
            // チェック処理 --------------------------------------<<<
        }
        // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        /// <summary>
        /// 売上伝票明細情報を更新します
        /// </summary>
        /// <param name="salesDetailWorks">伝票明細更新List</param>
        /// <param name="salesSlipWork">売上伝票情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票明細情報を更新します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        private int WriteSalesDetailWork(ref ArrayList salesDetailWorks, SalesSlipWork salesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList wkal = new ArrayList();
            try
            {
                // 売上明細が削除される前に、紐付く他データの更新処理を行う
                ArrayList orgDtlList = new ArrayList();
                ArrayList paraList = new ArrayList();

                ArrayList[] copySalesDetailWorks = new ArrayList[0];
                SalesSlipReadWork paramWork = new SalesSlipReadWork();

                // 売上データに紐付く売上明細データを取得する
                paramWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
                paramWork.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
                paramWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
                status = this.ReadSalesDetailWork(out orgDtlList, ref copySalesDetailWorks, paramWork, ref sqlConnection, ref sqlTransaction);

                // 受注マスタのレコードを精査する
                if (orgDtlList != null && orgDtlList.Count > 0)
                {
                    ArrayList Differencelist = new ArrayList();
                    
                    foreach (SalesDetailWork orgDtlWork in orgDtlList)
                    {
                        bool exist = false;

                        foreach (SalesDetailWork newDtlWork in salesDetailWorks)
                        {
                            if (orgDtlWork.EnterpriseCode == newDtlWork.EnterpriseCode &&
                                orgDtlWork.AcptAnOdrStatus == newDtlWork.AcptAnOdrStatus &&
                                //orgDtlWork.SalesSlipNum == newDtlWork.SalesSlipNum)      // DEL 2011/04/26 
                                orgDtlWork.SalesSlipDtlNum == newDtlWork.SalesSlipDtlNum )  // ADD 2011/04/26
                            {
                                exist = true;
                            }
                        }

                        if (!exist)
                        {
                            // UI側にて削除された分の売上明細データを収集する
                            Differencelist.Add(this.MakeAcceptOdrWork(orgDtlWork));
                        }
                    }

                    if (Differencelist.Count > 0)
                    {
                        // UI側にて削除された分の売上明細データに対応する受注マスタのレコードを論理削除する
                        AcceptOdr.LogicalDeleteAcceptOdrProc(ref Differencelist, 0, ref sqlConnection, ref sqlTransaction);
                    }

                    // 売上データに紐付く売上明細データを一度全て削除する
                    string sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESDETAILRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                        findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                # region [DELETE]
                /*
                // 売上データに紐付く売上明細データを一度全て削除する
                string sqlText = "";
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESDETAILRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                    findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);

                    sqlCommand.ExecuteNonQuery();
                }
                */
                # endregion

                ArrayList acceptOdrWorkList = new ArrayList();

                for (int i = 0; i < salesDetailWorks.Count; i++)
                {
                    //更新明細情報を取得
                    SalesDetailWork salesDetailWork = (SalesDetailWork)salesDetailWorks[i];

                    //＠売上明細データ変更＠                    
                    # region [INSERT文]
                    //--- ADD 2008/09/12 M.Kubota --->>>
                    string sqlText = string.Empty;
                    sqlText += "INSERT INTO SALESDETAILRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESROWNORF" + Environment.NewLine;
                    sqlText += " ,SALESROWDERIVNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SALESDATERF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += " ,DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                    sqlText += " ,GOODSKINDCODERF" + Environment.NewLine;
                    sqlText += " ,GOODSSEARCHDIVCDRF" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,MAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMEKANARF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPRF" + Environment.NewLine;
                    sqlText += " ,GOODSMGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,BLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,BLGOODSFULLNAMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISEGANRENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,SALESORDERDIVCDRF" + Environment.NewLine;
                    sqlText += " ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += " ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += " ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICERATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTPRICEUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVLPRICERF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDLPRICERF" + Environment.NewLine;
                    sqlText += " ,PRICECDLPRICERF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCLPRICERF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITLPRICERF" + Environment.NewLine;
                    sqlText += " ,FRACPROCLPRICERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICECHNGCDRF" + Environment.NewLine;
                    sqlText += " ,SALESRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,PRICECDSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCSALUNPRCRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,SALESUNPRCCHNGCDRF" + Environment.NewLine;
                    sqlText += " ,COSTRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTCSTUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVUNCSTRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDUNCSTRF" + Environment.NewLine;
                    sqlText += " ,PRICECDUNCSTRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCUNCSTRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITUNCSTRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNCSTRF" + Environment.NewLine;
                    sqlText += " ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,SALESUNITCOSTCHNGDIVRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,PRTBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,PRTBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,SALESCODERF" + Environment.NewLine;
                    sqlText += " ,SALESCDNMRF" + Environment.NewLine;
                    sqlText += " ,WORKMANHOURRF" + Environment.NewLine;
                    sqlText += " ,SHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERCNTRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRADJUSTCNTRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRREMAINCNTRF" + Environment.NewLine;
                    sqlText += " ,REMAINCNTUPDDATERF" + Environment.NewLine;
                    sqlText += " ,SALESMONEYTAXINCRF" + Environment.NewLine;
                    sqlText += " ,SALESMONEYTAXEXCRF" + Environment.NewLine;
                    sqlText += " ,COSTRF" + Environment.NewLine;
                    sqlText += " ,GRSPROFITCHKDIVRF" + Environment.NewLine;
                    sqlText += " ,SALESGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,SALESPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlText += " ,PARTYSLIPNUMDTLRF" + Environment.NewLine;
                    sqlText += " ,DTLNOTERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += " ,WAYTOORDERRF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += " ,BFLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,BFSALESUNITPRICERF" + Environment.NewLine;
                    sqlText += " ,BFUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESROWNORF" + Environment.NewLine;
                    sqlText += " ,CMPLTGOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTSHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESUNPRCFLRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,CMPLTSALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTCOSTRF" + Environment.NewLine;
                    sqlText += " ,CMPLTPARTYSALSLNUMRF" + Environment.NewLine;
                    sqlText += " ,CMPLTNOTERF" + Environment.NewLine;
                    sqlText += " ,PRTGOODSNORF" + Environment.NewLine;
                    sqlText += " ,PRTMAKERCODERF" + Environment.NewLine;
                    sqlText += " ,PRTMAKERNAMERF" + Environment.NewLine;
                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,CAMPAIGNCODERF" + Environment.NewLine;
                    sqlText += " ,CAMPAIGNNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSDIVCDRF" + Environment.NewLine;
                    sqlText += " ,ANSWERDELIVDATERF" + Environment.NewLine;
                    sqlText += " ,RECYCLEDIVRF" + Environment.NewLine;
                    sqlText += " ,RECYCLEDIVNMRF" + Environment.NewLine;
                    sqlText += " ,WAYTOACPTODRRF" + Environment.NewLine;
                    // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " ,AUTOANSWERDIVSCMRF" + Environment.NewLine; // Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                    // -- ADD 2011/08/10   ------ >>>>>>
                    sqlText += " ,ACCEPTORORDERKINDRF" + Environment.NewLine;
                    sqlText += " ,INQUIRYNUMBERRF" + Environment.NewLine;
                    sqlText += " ,INQROWNUMBERRF" + Environment.NewLine;
                    // -- ADD 2011/08/10   ------ <<<<<<
                    // -- ADD 2012/01/23   ------ >>>>>>
                    sqlText += " ,GOODSSPECIALNOTERF" + Environment.NewLine;
                    // -- ADD 2012/01/23   ------ <<<<<<
                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,RENTSYNCSUPPLIERRF" + Environment.NewLine;
                    sqlText += " ,RENTSYNCSTOCKDATERF" + Environment.NewLine;
                    sqlText += " ,RENTSYNCSUPSLIPNORF" + Environment.NewLine;
                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " )" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SALESROWNO" + Environment.NewLine;
                    sqlText += " ,@SALESROWDERIVNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SALESDATE" + Environment.NewLine;
                    sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUM" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUSSRC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUMSRC" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMALSYNC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUMSYNC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPCDDTL" + Environment.NewLine;
                    sqlText += " ,@DELIGDSCMPLTDUEDATE" + Environment.NewLine;
                    sqlText += " ,@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += " ,@GOODSSEARCHDIVCD" + Environment.NewLine;
                    sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@MAKERNAME" + Environment.NewLine;
                    sqlText += " ,@MAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNO" + Environment.NewLine;
                    sqlText += " ,@GOODSNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSNAMEKANA" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUP" + Environment.NewLine;
                    sqlText += " ,@GOODSMGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@BLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@BLGOODSFULLNAME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRECODE" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISEGANRENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSECODE" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSENAME" + Environment.NewLine;
                    sqlText += " ,@WAREHOUSESHELFNO" + Environment.NewLine;
                    sqlText += " ,@SALESORDERDIVCD" + Environment.NewLine;
                    sqlText += " ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICERATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTPRICEUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVLPRICE" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDLPRICE" + Environment.NewLine;
                    sqlText += " ,@PRICECDLPRICE" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCLPRICE" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITLPRICE" + Environment.NewLine;
                    sqlText += " ,@FRACPROCLPRICE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXINCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICECHNGCD" + Environment.NewLine;
                    sqlText += " ,@SALESRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@PRICECDSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCSALUNPRC" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCTAXINCFL" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCTAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@SALESUNPRCCHNGCD" + Environment.NewLine;
                    sqlText += " ,@COSTRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTCSTUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVUNCST" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDUNCST" + Environment.NewLine;
                    sqlText += " ,@PRICECDUNCST" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCUNCST" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITUNCST" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNCST" + Environment.NewLine;
                    sqlText += " ,@SALESUNITCOST" + Environment.NewLine;
                    sqlText += " ,@SALESUNITCOSTCHNGDIV" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPCD" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPNM" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@PRTBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@PRTBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@SALESCODE" + Environment.NewLine;
                    sqlText += " ,@SALESCDNM" + Environment.NewLine;
                    sqlText += " ,@WORKMANHOUR" + Environment.NewLine;
                    sqlText += " ,@SHIPMENTCNT" + Environment.NewLine;
                    sqlText += " ,@ACCEPTANORDERCNT" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRADJUSTCNT" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRREMAINCNT" + Environment.NewLine;
                    sqlText += " ,@REMAINCNTUPDDATE" + Environment.NewLine;
                    sqlText += " ,@SALESMONEYTAXINC" + Environment.NewLine;
                    sqlText += " ,@SALESMONEYTAXEXC" + Environment.NewLine;
                    sqlText += " ,@COST" + Environment.NewLine;
                    sqlText += " ,@GRSPROFITCHKDIV" + Environment.NewLine;
                    sqlText += " ,@SALESGOODSCD" + Environment.NewLine;
                    sqlText += " ,@SALESPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TAXATIONDIVCD" + Environment.NewLine;
                    sqlText += " ,@PARTYSLIPNUMDTL" + Environment.NewLine;
                    sqlText += " ,@DTLNOTE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                    sqlText += " ,@WAYTOORDER" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO1" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO2" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO3" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO1" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO2" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO3" + Environment.NewLine;
                    sqlText += " ,@BFLISTPRICE" + Environment.NewLine;
                    sqlText += " ,@BFSALESUNITPRICE" + Environment.NewLine;
                    sqlText += " ,@BFUNITCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESROWNO" + Environment.NewLine;
                    sqlText += " ,@CMPLTGOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERNAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTSHIPMENTCNT" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESUNPRCFL" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESMONEY" + Environment.NewLine;
                    sqlText += " ,@CMPLTSALESUNITCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTCOST" + Environment.NewLine;
                    sqlText += " ,@CMPLTPARTYSALSLNUM" + Environment.NewLine;
                    sqlText += " ,@CMPLTNOTE" + Environment.NewLine;
                    sqlText += " ,@PRTGOODSNO" + Environment.NewLine;
                    sqlText += " ,@PRTMAKERCODE" + Environment.NewLine;
                    sqlText += " ,@PRTMAKERNAME" + Environment.NewLine;
                    // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,@CAMPAIGNCODE" + Environment.NewLine;
                    sqlText += " ,@CAMPAIGNNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSDIVCD" + Environment.NewLine;
                    sqlText += " ,@ANSWERDELIVDATE" + Environment.NewLine;
                    sqlText += " ,@RECYCLEDIV" + Environment.NewLine;
                    sqlText += " ,@RECYCLEDIVNM" + Environment.NewLine;
                    sqlText += " ,@WAYTOACPTODR" + Environment.NewLine;
                    // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " ,@AUTOANSWERDIVSCM" + Environment.NewLine;// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                    // -- ADD 2011/08/10   ------ >>>>>>
                    sqlText += " ,@ACCEPTORORDERKIND" + Environment.NewLine;
                    sqlText += " ,@INQUIRYNUMBER" + Environment.NewLine;
                    sqlText += " ,@INQROWNUMBER" + Environment.NewLine;
                    // -- ADD 2011/08/10   ------ <<<<<<
                    // -- ADD 2012/01/23   ------ >>>>>>
                    sqlText += " ,@GOODSSPECIALNOTE" + Environment.NewLine;
                    // -- ADD 2012/01/23   ------ <<<<<<
                    //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    sqlText += " ,@RENTSYNCSUPPLIER" + Environment.NewLine;
                    sqlText += " ,@RENTSYNCSTOCKDATE" + Environment.NewLine;
                    sqlText += " ,@RENTSYNCSUPSLIPNO" + Environment.NewLine;
                    //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlText += " )" + Environment.NewLine;
                    //--- ADD 2008/09/12 M.Kubota ---<<<
                    # endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)salesDetailWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        //＠売上明細データ変更＠
                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                        SqlParameter paraSalesRowNo = sqlCommand.Parameters.Add("@SALESROWNO", SqlDbType.Int);
                        SqlParameter paraSalesRowDerivNo = sqlCommand.Parameters.Add("@SALESROWDERIVNO", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                        SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter paraAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSRC", SqlDbType.Int);
                        SqlParameter paraSalesSlipDtlNumSrc = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSRC", SqlDbType.BigInt);
                        SqlParameter paraSupplierFormalSync = sqlCommand.Parameters.Add("@SUPPLIERFORMALSYNC", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNumSync = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSYNC", SqlDbType.BigInt);
                        SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@SALESSLIPCDDTL", SqlDbType.Int);
                        SqlParameter paraDeliGdsCmpltDueDate = sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
                        SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                        SqlParameter paraGoodsSearchDivCd = sqlCommand.Parameters.Add("@GOODSSEARCHDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsLGroupName = sqlCommand.Parameters.Add("@GOODSLGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroupName = sqlCommand.Parameters.Add("@GOODSMGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGroupName = sqlCommand.Parameters.Add("@BLGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                        SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraListPriceRate = sqlCommand.Parameters.Add("@LISTPRICERATE", SqlDbType.Float);
                        SqlParameter paraRateSectPriceUnPrc = sqlCommand.Parameters.Add("@RATESECTPRICEUNPRC", SqlDbType.NChar);
                        SqlParameter paraRateDivLPrice = sqlCommand.Parameters.Add("@RATEDIVLPRICE", SqlDbType.NChar);
                        SqlParameter paraUnPrcCalcCdLPrice = sqlCommand.Parameters.Add("@UNPRCCALCCDLPRICE", SqlDbType.Int);
                        SqlParameter paraPriceCdLPrice = sqlCommand.Parameters.Add("@PRICECDLPRICE", SqlDbType.Int);
                        SqlParameter paraStdUnPrcLPrice = sqlCommand.Parameters.Add("@STDUNPRCLPRICE", SqlDbType.Float);
                        SqlParameter paraFracProcUnitLPrice = sqlCommand.Parameters.Add("@FRACPROCUNITLPRICE", SqlDbType.Float);
                        SqlParameter paraFracProcLPrice = sqlCommand.Parameters.Add("@FRACPROCLPRICE", SqlDbType.Int);
                        SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                        SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                        SqlParameter paraListPriceChngCd = sqlCommand.Parameters.Add("@LISTPRICECHNGCD", SqlDbType.Int);
                        SqlParameter paraSalesRate = sqlCommand.Parameters.Add("@SALESRATE", SqlDbType.Float);
                        SqlParameter paraRateSectSalUnPrc = sqlCommand.Parameters.Add("@RATESECTSALUNPRC", SqlDbType.NChar);
                        SqlParameter paraRateDivSalUnPrc = sqlCommand.Parameters.Add("@RATEDIVSALUNPRC", SqlDbType.NChar);
                        SqlParameter paraUnPrcCalcCdSalUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSALUNPRC", SqlDbType.Int);
                        SqlParameter paraPriceCdSalUnPrc = sqlCommand.Parameters.Add("@PRICECDSALUNPRC", SqlDbType.Int);
                        SqlParameter paraStdUnPrcSalUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSALUNPRC", SqlDbType.Float);
                        SqlParameter paraFracProcUnitSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSALUNPRC", SqlDbType.Float);
                        SqlParameter paraFracProcSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCSALUNPRC", SqlDbType.Int);
                        SqlParameter paraSalesUnPrcTaxIncFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXINCFL", SqlDbType.Float);
                        SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
                        SqlParameter paraSalesUnPrcChngCd = sqlCommand.Parameters.Add("@SALESUNPRCCHNGCD", SqlDbType.Int);
                        SqlParameter paraCostRate = sqlCommand.Parameters.Add("@COSTRATE", SqlDbType.Float);
                        SqlParameter paraRateSectCstUnPrc = sqlCommand.Parameters.Add("@RATESECTCSTUNPRC", SqlDbType.NChar);
                        SqlParameter paraRateDivUnCst = sqlCommand.Parameters.Add("@RATEDIVUNCST", SqlDbType.NChar);
                        SqlParameter paraUnPrcCalcCdUnCst = sqlCommand.Parameters.Add("@UNPRCCALCCDUNCST", SqlDbType.Int);
                        SqlParameter paraPriceCdUnCst = sqlCommand.Parameters.Add("@PRICECDUNCST", SqlDbType.Int);
                        SqlParameter paraStdUnPrcUnCst = sqlCommand.Parameters.Add("@STDUNPRCUNCST", SqlDbType.Float);
                        SqlParameter paraFracProcUnitUnCst = sqlCommand.Parameters.Add("@FRACPROCUNITUNCST", SqlDbType.Float);
                        SqlParameter paraFracProcUnCst = sqlCommand.Parameters.Add("@FRACPROCUNCST", SqlDbType.Int);
                        SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                        SqlParameter paraSalesUnitCostChngDiv = sqlCommand.Parameters.Add("@SALESUNITCOSTCHNGDIV", SqlDbType.Int);
                        SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                        SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                        SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraPrtBLGoodsCode = sqlCommand.Parameters.Add("@PRTBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraPrtBLGoodsName = sqlCommand.Parameters.Add("@PRTBLGOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraSalesCdNm = sqlCommand.Parameters.Add("@SALESCDNM", SqlDbType.NVarChar);
                        SqlParameter paraWorkManHour = sqlCommand.Parameters.Add("@WORKMANHOUR", SqlDbType.Float);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraAcceptAnOrderCnt = sqlCommand.Parameters.Add("@ACCEPTANORDERCNT", SqlDbType.Float);
                        SqlParameter paraAcptAnOdrAdjustCnt = sqlCommand.Parameters.Add("@ACPTANODRADJUSTCNT", SqlDbType.Float);
                        SqlParameter paraAcptAnOdrRemainCnt = sqlCommand.Parameters.Add("@ACPTANODRREMAINCNT", SqlDbType.Float);
                        SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);
                        SqlParameter paraSalesMoneyTaxInc = sqlCommand.Parameters.Add("@SALESMONEYTAXINC", SqlDbType.BigInt);
                        SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                        SqlParameter paraCost = sqlCommand.Parameters.Add("@COST", SqlDbType.BigInt);
                        SqlParameter paraGrsProfitChkDiv = sqlCommand.Parameters.Add("@GRSPROFITCHKDIV", SqlDbType.Int);
                        SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                        SqlParameter paraSalesPriceConsTax = sqlCommand.Parameters.Add("@SALESPRICECONSTAX", SqlDbType.BigInt);
                        SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                        SqlParameter paraPartySlipNumDtl = sqlCommand.Parameters.Add("@PARTYSLIPNUMDTL", SqlDbType.NVarChar);
                        SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                        SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                        SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                        SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                        SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                        SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                        SqlParameter paraBfSalesUnitPrice = sqlCommand.Parameters.Add("@BFSALESUNITPRICE", SqlDbType.Float);
                        SqlParameter paraBfUnitCost = sqlCommand.Parameters.Add("@BFUNITCOST", SqlDbType.Float);
                        SqlParameter paraCmpltSalesRowNo = sqlCommand.Parameters.Add("@CMPLTSALESROWNO", SqlDbType.Int);
                        SqlParameter paraCmpltGoodsMakerCd = sqlCommand.Parameters.Add("@CMPLTGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraCmpltMakerName = sqlCommand.Parameters.Add("@CMPLTMAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
                        SqlParameter paraCmpltGoodsName = sqlCommand.Parameters.Add("@CMPLTGOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraCmpltShipmentCnt = sqlCommand.Parameters.Add("@CMPLTSHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraCmpltSalesUnPrcFl = sqlCommand.Parameters.Add("@CMPLTSALESUNPRCFL", SqlDbType.Float);
                        SqlParameter paraCmpltSalesMoney = sqlCommand.Parameters.Add("@CMPLTSALESMONEY", SqlDbType.BigInt);
                        SqlParameter paraCmpltSalesUnitCost = sqlCommand.Parameters.Add("@CMPLTSALESUNITCOST", SqlDbType.Float);
                        SqlParameter paraCmpltCost = sqlCommand.Parameters.Add("@CMPLTCOST", SqlDbType.BigInt);
                        SqlParameter paraCmpltPartySalSlNum = sqlCommand.Parameters.Add("@CMPLTPARTYSALSLNUM", SqlDbType.NVarChar);
                        SqlParameter paraCmpltNote = sqlCommand.Parameters.Add("@CMPLTNOTE", SqlDbType.NVarChar);
                        SqlParameter paraPrtGoodsNo = sqlCommand.Parameters.Add("@PRTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraPrtMakerCode = sqlCommand.Parameters.Add("@PRTMAKERCODE", SqlDbType.Int);
                        SqlParameter paraPrtMakerName = sqlCommand.Parameters.Add("@PRTMAKERNAME", SqlDbType.NVarChar);
                        // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                        SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);  // キャンペーン名称
                        SqlParameter paraGoodsDivCd = sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);  // 商品種別
                        SqlParameter paraAnswerDelivDate = sqlCommand.Parameters.Add("@ANSWERDELIVDATE", SqlDbType.NVarChar);  // 回答納期
                        SqlParameter paraRecycleDiv = sqlCommand.Parameters.Add("@RECYCLEDIV", SqlDbType.Int);  // リサイクル区分
                        SqlParameter paraRecycleDivNm = sqlCommand.Parameters.Add("@RECYCLEDIVNM", SqlDbType.NVarChar);  // リサイクル区分名称
                        SqlParameter paraWayToAcptOdr = sqlCommand.Parameters.Add("@WAYTOACPTODR", SqlDbType.Int);  // 受注方法
                        // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        SqlParameter paraAutoAnswerDivSCM = sqlCommand.Parameters.Add("@AUTOANSWERDIVSCM", SqlDbType.Int);  // 自動回答区分(SCM)// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                        // -- ADD 2011/08/10   ------ >>>>>>
                        SqlParameter paraAcceptOrOrderKind = sqlCommand.Parameters.Add("@ACCEPTORORDERKIND", SqlDbType.Int);      // 受発注種別
                        SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.BigInt);           // 問合せ番号
                        SqlParameter paraInqRowNumber = sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);                // 問合せ行番号
                        // -- ADD 2011/08/10   ------ <<<<<<
                        // -- ADD 2012/01/23   ------ >>>>>>
                        SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);      // 商品規格・特記事項
                        // -- ADD 2012/01/23   ------ <<<<<<
                        //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraRentSyncSupplier = sqlCommand.Parameters.Add("@RENTSYNCSUPPLIER", SqlDbType.Int);      // 貸出同時仕入先
                        SqlParameter paraRentSyncStockDate = sqlCommand.Parameters.Add("@RENTSYNCSTOCKDATE", SqlDbType.Int);      // 貸出同時仕入日
                        SqlParameter paraRentSyncSupSlipNo = sqlCommand.Parameters.Add("@RENTSYNCSUPSLIPNO", SqlDbType.NVarChar);      // 貸出同時仕入伝票番号
                        //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion

                        //＠売上明細データ変更＠
                        //para<#FieldName>.Value = SqlDataMediator.<#sqlDbTypeSetAccessor>(salesDetailWork.<#FieldName>);               // <#name>
                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesDetailWork.CreateDateTime);                            // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesDetailWork.UpdateDateTime);                            // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.EnterpriseCode);                                       // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesDetailWork.FileHeaderGuid);                                         // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdEmployeeCode);                                     // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdAssemblyId1);                                       // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdAssemblyId2);                                       // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.LogicalDeleteCode);                                  // 論理削除区分
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcceptAnOrderNo);                                      // 受注番号
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcptAnOdrStatus);                                      // 受注ステータス
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesDetailWork.SalesSlipNum);                                           // 売上伝票番号
                        paraSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesRowNo);                                                // 売上行番号
                        paraSalesRowDerivNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesRowDerivNo);                                      // 売上行番号枝番
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.SectionCode);                                             // 拠点コード
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SubSectionCode);                                        // 部門コード
                        paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.SalesDate);                                   // 売上日付
                        paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CommonSeqNo);                                              // 共通通番
                        paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesSlipDtlNum);                                      // 売上明細通番
                        paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcptAnOdrStatusSrc);                                // 受注ステータス（元）
                        paraSalesSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesSlipDtlNumSrc);                                // 売上明細通番（元）
                        paraSupplierFormalSync.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SupplierFormalSync);                                // 仕入形式（同時）
                        paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.StockSlipDtlNumSync);                              // 仕入明細通番（同時）
                        paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesSlipCdDtl);                                        // 売上伝票区分（明細）
                        paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.DeliGdsCmpltDueDate);               // 納品完了予定日
                        paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsKindCode);                                          // 商品属性
                        paraGoodsSearchDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsSearchDivCd);                                    // 商品検索区分
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsMakerCd);                                            // 商品メーカーコード
                        paraMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.MakerName);                                                 // メーカー名称
                        paraMakerKanaName.Value = SqlDataMediator.SqlSetString(salesDetailWork.MakerKanaName);                                         // メーカーカナ名称
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsNo);                                                     // 商品番号
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsName);                                                 // 商品名称
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsNameKana);                                         // 商品名称カナ
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsLGroup);                                              // 商品大分類コード
                        paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsLGroupName);                                     // 商品大分類名称
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsMGroup);                                              // 商品中分類コード
                        paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsMGroupName);                                     // 商品中分類名称
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.BLGroupCode);                                              // BLグループコード
                        paraBLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.BLGroupName);                                             // BLグループコード名称
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.BLGoodsCode);                                              // BL商品コード
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(salesDetailWork.BLGoodsFullName);                                     // BL商品コード名称（全角）
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.EnterpriseGanreCode);                              // 自社分類コード
                        paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(salesDetailWork.EnterpriseGanreName);                             // 自社分類名称
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseCode);                                         // 倉庫コード
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseName);                                         // 倉庫名称
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseShelfNo);                                   // 倉庫棚番
                        paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesOrderDivCd);                                      // 売上在庫取寄せ区分
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.OpenPriceDiv);                                            // オープン価格区分
                        paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsRateRank);                                         // 商品掛率ランク
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CustRateGrpCode);                                      // 得意先掛率グループコード
                        paraListPriceRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceRate);                                         // 定価率
                        paraRateSectPriceUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectPriceUnPrc);                               // 掛率設定拠点（定価）
                        paraRateDivLPrice.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivLPrice);                                         // 掛率設定区分（定価）
                        paraUnPrcCalcCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdLPrice);                                  // 単価算出区分（定価）
                        paraPriceCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdLPrice);                                          // 価格区分（定価）
                        paraStdUnPrcLPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcLPrice);                                       // 基準単価（定価）
                        paraFracProcUnitLPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitLPrice);                               // 端数処理単位（定価）
                        paraFracProcLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcLPrice);                                        // 端数処理（定価）
                        paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceTaxIncFl);                                 // 定価（税込，浮動）
                        paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceTaxExcFl);                                 // 定価（税抜，浮動）
                        paraListPriceChngCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.ListPriceChngCd);                                      // 定価変更区分
                        paraSalesRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesRate);                                                 // 売価率
                        paraRateSectSalUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectSalUnPrc);                                   // 掛率設定拠点（売上単価）
                        paraRateDivSalUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivSalUnPrc);                                     // 掛率設定区分（売上単価）
                        paraUnPrcCalcCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdSalUnPrc);                              // 単価算出区分（売上単価）
                        paraPriceCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdSalUnPrc);                                      // 価格区分（売上単価）
                        paraStdUnPrcSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcSalUnPrc);                                   // 基準単価（売上単価）
                        paraFracProcUnitSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitSalUnPrc);                           // 端数処理単位（売上単価）
                        paraFracProcSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcSalUnPrc);                                    // 端数処理（売上単価）
                        paraSalesUnPrcTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnPrcTaxIncFl);                               // 売上単価（税込，浮動）
                        paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnPrcTaxExcFl);                               // 売上単価（税抜，浮動）
                        paraSalesUnPrcChngCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesUnPrcChngCd);                                    // 売上単価変更区分
                        paraCostRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CostRate);                                                   // 原価率
                        paraRateSectCstUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectCstUnPrc);                                   // 掛率設定拠点（原価単価）
                        paraRateDivUnCst.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivUnCst);                                           // 掛率設定区分（原価単価）
                        paraUnPrcCalcCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdUnCst);                                    // 単価算出区分（原価単価）
                        paraPriceCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdUnCst);                                            // 価格区分（原価単価）
                        paraStdUnPrcUnCst.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcUnCst);                                         // 基準単価（原価単価）
                        paraFracProcUnitUnCst.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitUnCst);                                 // 端数処理単位（原価単価）
                        paraFracProcUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcUnCst);                                          // 端数処理（原価単価）
                        paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnitCost);                                         // 原価単価
                        paraSalesUnitCostChngDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesUnitCostChngDiv);                            // 原価単価変更区分
                        paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateBLGoodsCode);                                      // BL商品コード（掛率）
                        paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateBLGoodsName);                                     // BL商品コード名称（掛率）
                        paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateGoodsRateGrpCd);                                // 商品掛率グループコード（掛率）
                        paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateGoodsRateGrpNm);                               // 商品掛率グループ名称（掛率）
                        paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateBLGroupCode);                                      // BLグループコード（掛率）
                        paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateBLGroupName);                                     // BLグループ名称（掛率）
                        paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PrtBLGoodsCode);                                        // BL商品コード（印刷）
                        paraPrtBLGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtBLGoodsName);                                       // BL商品コード名称（印刷）
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesCode);                                                  // 販売区分コード
                        paraSalesCdNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.SalesCdNm);                                                 // 販売区分名称
                        paraWorkManHour.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.WorkManHour);                                             // 作業工数
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ShipmentCnt);                                             // 出荷数
                        paraAcceptAnOrderCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcceptAnOrderCnt);                                   // 受注数量
                        paraAcptAnOdrAdjustCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcptAnOdrAdjustCnt);                               // 受注調整数
                        paraAcptAnOdrRemainCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcptAnOdrRemainCnt);                               // 受注残数
                        paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.RemainCntUpdDate);                     // 残数更新日
                        paraSalesMoneyTaxInc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesMoneyTaxInc);                                    // 売上金額（税込み）
                        paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesMoneyTaxExc);                                    // 売上金額（税抜き）
                        paraCost.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.Cost);                                                            // 原価
                        paraGrsProfitChkDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GrsProfitChkDiv);                                      // 粗利チェック区分
                        paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesGoodsCd);                                            // 売上商品区分
                        paraSalesPriceConsTax.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesPriceConsTax);                                  // 売上金額消費税額
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.TaxationDivCd);                                          // 課税区分
                        paraPartySlipNumDtl.Value = SqlDataMediator.SqlSetString(salesDetailWork.PartySlipNumDtl);                                     // 相手先伝票番号（明細）
                        paraDtlNote.Value = SqlDataMediator.SqlSetString(salesDetailWork.DtlNote);                                                     // 明細備考
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SupplierCd);                                                // 仕入先コード
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(salesDetailWork.SupplierSnm);                                             // 仕入先略称
                        paraOrderNumber.Value = SqlDataMediator.SqlSetString(salesDetailWork.OrderNumber);                                             // 発注番号
                        paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.WayToOrder);                                                // 注文方法
                        paraSlipMemo1.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo1);                                                 // 伝票メモ１
                        paraSlipMemo2.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo2);                                                 // 伝票メモ２
                        paraSlipMemo3.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo3);                                                 // 伝票メモ３
                        paraInsideMemo1.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo1);                                             // 社内メモ１
                        paraInsideMemo2.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo2);                                             // 社内メモ２
                        paraInsideMemo3.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo3);                                             // 社内メモ３
                        paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfListPrice);                                             // 変更前定価
                        paraBfSalesUnitPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfSalesUnitPrice);                                   // 変更前売価
                        paraBfUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfUnitCost);                                               // 変更前原価
                        paraCmpltSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CmpltSalesRowNo);                                      // 一式明細番号
                        paraCmpltGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CmpltGoodsMakerCd);                                  // メーカーコード（一式）
                        paraCmpltMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltMakerName);                                       // メーカー名称（一式）
                        paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltMakerKanaName);                               // メーカーカナ名称（一式）
                        paraCmpltGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltGoodsName);                                       // 商品名称（一式）
                        paraCmpltShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltShipmentCnt);                                   // 数量（一式）
                        paraCmpltSalesUnPrcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltSalesUnPrcFl);                                 // 売上単価（一式）
                        paraCmpltSalesMoney.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CmpltSalesMoney);                                      // 売上金額（一式）
                        paraCmpltSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltSalesUnitCost);                               // 原価単価（一式）
                        paraCmpltCost.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CmpltCost);                                                  // 原価金額（一式）
                        paraCmpltPartySalSlNum.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltPartySalSlNum);                               // 相手先伝票番号（一式）
                        paraCmpltNote.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltNote);                                                 // 一式備考
                        paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtGoodsNo);                                               // 印刷用品番
                        paraPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PrtMakerCode);                                            // 印刷用メーカーコード
                        paraPrtMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtMakerName);                                           // 印刷用メーカー名称
                        // 2009/05/18 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CampaignCode);  // キャンペーンコード
                        paraCampaignName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CampaignName);  // キャンペーン名称
                        paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsDivCd);  // 商品種別
                        paraAnswerDelivDate.Value = SqlDataMediator.SqlSetString(salesDetailWork.AnswerDelivDate);  // 回答納期
                        paraRecycleDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RecycleDiv);  // リサイクル区分
                        paraRecycleDivNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.RecycleDivNm);  // リサイクル区分名称
                        paraWayToAcptOdr.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.WayToAcptOdr);  // 受注方法
                        // 2009/05/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AutoAnswerDivSCM);  // 自動回答区分(SCM)// Add 2011/07/23 duzg for 自動回答区分(SCM)追加
                        // -- ADD 2011/08/10   ------ >>>>>>
                        paraAcceptOrOrderKind.Value = SqlDataMediator.SqlSetInt16(salesDetailWork.AcceptOrOrderKind);      // 受発注種別
                        paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.InquiryNumber);           // 問合せ番号
                        paraInqRowNumber.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.InqRowNumber);                // 問合せ行番号
                        // -- ADD 2011/08/10   ------ <<<<<<
                        // -- ADD 2012/01/23   ------ >>>>>>
                        paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsSpecialNote);      // 商品規格・特記事項
                        // -- ADD 2012/01/23   ------ <<<<<<
                        //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        paraRentSyncSupplier.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RentSyncSupplier);      // 貸出同時仕入先
                        paraRentSyncStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.RentSyncStockDate);  // 貸出同時仕入日
                        paraRentSyncSupSlipNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.RentSyncSupSlipNo);      // 貸出同時仕入伝票番号
                        //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        # endregion

                        //暗号化キーパラメータ設定
                        //SqlParameter encKeyStockDetailRF = sqlCommand.Parameters.Add("@STOCKDETAILRF_ENCRYPTKEY", SqlDbType.Char);
                        //encKeyStockDetailRF.Value = sqlEncryptInfo.GetSymKeyName("STOCKDETAILRF");

#if DEBUG
                        Console.Clear();
                        Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                        sqlCommand.ExecuteNonQuery();
                        wkal.Add(salesDetailWork);

                        // 仕入データの登録が完了した時点で受注マスタに明細通番の登録を行う。
                        acceptOdrWorkList.Add(this.MakeAcceptOdrWork(salesDetailWork));
                    }
                }

                // 複数の受注マスタデータを一度に登録する
                status = AcceptOdr.WriteAcceptOdrProc(ref acceptOdrWorkList, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkal.Clear();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            salesDetailWorks = wkal;

            return status;
        }
        #endregion

        #region [Delete]　削除処理　ヘッダ・明細・詳細
        /// <summary>
        /// 売上伝票・売上伝票明細を論理削除初期処理
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="paraList">更新対象オブジェクト</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票・売上伝票明細を論理削除初期処理</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int listPos_SalesSlipDeleteWork = -1;

            SalesSlipDeleteWork salesSlipDeleteWork = null;

            //●更新前情報読込パラメータ格納用
            SalesSlipReadWork salesSlipReadWork = null;
            //SalesSlipWork tempSalesSlipWork = null;  //DEL 2008/06/06 M.Kubota

            originList = new CustomSerializeArrayList();

            //●削除前データ格納用
            SalesSlipWork oldSalesSlipWork = new SalesSlipWork();
            ArrayList oldSalesDetailWorkList = new ArrayList();

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●削除オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 削除対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                if (paraList[position] is SalesSlipDeleteWork)
                {
                    // 売上・出荷データ削除処理の場合
                    salesSlipDeleteWork = paraList[position] as SalesSlipDeleteWork;
                    listPos_SalesSlipDeleteWork = position;

                    //●削除前売上伝票の読込・格納(originList)
                    if (salesSlipDeleteWork != null)
                    {
                        //売上伝票が存在するかチェックし、originListに追加する
                        SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];
                        ArrayList[] copySalesDetailWorkList = new ArrayList[0];

                        salesSlipReadWork = SalesSlipReadWorkOutPut(salesSlipDeleteWork);

                        // 既存売上データの読込み
                        status = this.ReadSalesSlipWork(out oldSalesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                        // 既存売上明細データの読込み
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.ReadSalesDetailWork(out oldSalesDetailWorkList, ref copySalesDetailWorkList, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);
                        }

                        # region [--- DEL 2008/06/06 M.Kubota ---]
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    //●拠点制御設定マスタより在庫更新拠点コードを抽出
                        //    if (oldSalesSlipWork.SalesGoodsCd == 0)
                        //    {
                        //        status = this.SearchStockSecCd(ref oldSalesSlipWork, ref tempSalesSlipWork, ref sqlConnection, ref sqlTransaction);
                        //    }

                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //    {
                        //        retMsg = "拠点制御設定が正しく設定されておりません。";
                        //        return status;
                        //    }
                        //}
                        # endregion

                        originList.Add(oldSalesSlipWork);
                        originList.Add(oldSalesDetailWorkList);

                        # region [---DEL 2009/01/20 M.Kubota --- 在庫データ作成処理で、返品元伝票を必要としなくなった他、売上リアル更新内でも不具合に原因になる為 削除]
                        //// 返品の場合は返品元となった伝票の読み込みも行う
                        //// ※返品伝票自体の修正ならば originListには変更前返品と返品元伝票の両方が入る
                        //if (oldSalesSlipWork.SalesSlipCd == 1)
                        //{
                        //    SalesSlipWork retOrgSalesSlip = null;
                        //    ArrayList retOrgSalesDtlList = null;

                        //    status = this.ReadSalesSlipFromReturn(oldSalesDetailWorkList, out retOrgSalesSlip, out retOrgSalesDtlList, ref sqlConnection, ref sqlTransaction);

                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        if (retOrgSalesSlip != null)
                        //            originList.Add(retOrgSalesSlip);

                        //        if (retOrgSalesDtlList != null && retOrgSalesDtlList.Count > 0)
                        //            originList.Add(retOrgSalesDtlList);
                        //    }
                        //}
                        # endregion

                        //--- ADD 2009/01/30 M.Kubota --->>>
                        // 計上元明細データの読み込み
                        ArrayList addUpSalesDetailWorks = null;
                        status = this.ReadAddUpSalesDetailWork(out addUpSalesDetailWorks, oldSalesDetailWorkList, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(addUpSalesDetailWorks))
                        {
                            originList.Add(addUpSalesDetailWorks);
                        }
                        //--- ADD 2009/01/30 M.Kubota ---<<<
                    }
                }
            }

            // 出荷差分数を算出する
            if (oldSalesDetailWorkList != null && oldSalesDetailWorkList.Count > 0)
            {
                foreach (object item in oldSalesDetailWorkList)
                {
                    SalesDetailWork dtlwork = item as SalesDetailWork;

                    if (dtlwork != null)
                    {
                        //dtlwork.ShipmCntDifference = Math.Abs(dtlwork.ShipmentCnt) * -1;
                        //dtlwork.ShipmCntDifference = dtlwork.ShipmentCnt * -1;
                        dtlwork.ShipmCntDifference = dtlwork.ShipmentCnt;
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 売上伝票・売上伝票明細を論理削除します
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">更新前オブジェクト</param>
        /// <param name="paraList">更新対象オブジェクト</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">パラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票・売上伝票明細を論理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //●更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SalesSlipDeleteWork salesSlipDeleteWork = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●論理削除オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 売上伝票論理削除対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }
            //●伝票更新List内のクラスを抽出
            else if (paraList.Count > 0) salesSlipDeleteWork = paraList[position] as SalesSlipDeleteWork;
            
            if (salesSlipDeleteWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 売上伝票論理削除オブジェクトパラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            ArrayList deleteStockDetailList = null;
            SalesSlipWork salesSlipWork = null;

            //●論理削除
            // 売上伝票論理削除
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
            // status = this.DeleteSalesSlipWork(salesSlipDeleteWork, out salesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            status = this.DeleteSalesSlipWork(salesSlipDeleteWork, out salesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

            // 削除対象の売上明細データを取得する (※売上伝票番号だけで削除する方法は止める)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList[] copySalesDetailWorks = new ArrayList[0];
                status = ReadSalesDetailWork(out deleteStockDetailList, ref copySalesDetailWorks, this.SalesSlipReadWorkOutPut(salesSlipDeleteWork), ref sqlConnection, ref sqlTransaction);
            }

            // 売上伝票明細論理削除
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.DeleteSalesDetailWork(deleteStockDetailList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            //計上元売上明細データの受注残数更新 (計上元の有無は呼出し先で行っている)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && this.IOWriteCtrlOptWork.RemainCntMngDiv == 0)
            {
                ArrayList salesDetailWorks = null;

                if (originList != null)
                {
                    foreach (object item in originList)
                    {
                        if (item is ArrayList)
                        {
                            if ((item as ArrayList)[0] is SalesDetailWork)
                            {
                                salesDetailWorks = item as ArrayList;
                                break;
                            }
                        }
                    }
                }

                if (salesDetailWorks != null)
                {
                    status = this.UpdateAcptAnOdrRemainCnt(salesSlipWork, salesDetailWorks, null, 1, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            //赤伝削除の場合元黒伝の赤黒連結売上伝票番号を初期化する
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesSlipDeleteWork.DebitNoteDiv == 1)
                {
                    status = this.DeleteDebitNLnkSalesSlipNum(salesSlipDeleteWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                }
            }

            return status;
        }

        /// <summary>
        /// 売上伝票を論理削除します
        /// </summary>
        /// <param name="salesSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="salesSlipWork">削除済み伝票データ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票を論理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2011/07/25 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //private int DeleteSalesSlipWork(SalesSlipDeleteWork salesSlipDeleteWork, out SalesSlipWork salesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // DEL 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00)
        private int DeleteSalesSlipWork(SalesSlipDeleteWork salesSlipDeleteWork, out SalesSlipWork salesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00)
        {
            //●まずは1伝票番号だけを削除できるようにする(List化未対応)
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            salesSlipWork = null;

            try
            {
                //●まずは1伝票番号だけを削除できるようにする(List化未対応)
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                //sqlText += "  SLIP.UPDATEDATETIMERF" + Environment.NewLine;
                //sqlText += " ,SLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                //sqlText += " ,SLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                //sqlText += " ,SLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                //sqlText += " ,SLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  SLIP.*" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                //KEYコマンドを設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.EnterpriseCode);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.AcptAnOdrStatus);
                findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.SalesSlipNum);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    salesSlipWork = this.SalesSlipReadResultPut(myReader);
                    
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    if (salesSlipWork.UpdateDateTime != salesSlipDeleteWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    // 売上伝票を更新する前に、送信済みのチェックを行う
                    if (!CheckSalesSending(salesSlipWork, out errMessage))
                    {
                        // チェックNG
                        status = STATUS_CHK_SEND_ERR;
                        sqlCommand.Cancel();
                        return status;
                    }
                    // ADD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    //現在の論理削除区分を取得
                    //logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesSlipWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    // 論理削除区分の設定
                    salesSlipWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                    sqlText = "";
                    sqlText += "UPDATE" + Environment.NewLine;
                    sqlText += "  SALESSLIPRF" + Environment.NewLine;
                    sqlText += "SET" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                    // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                    sqlText += " ,SEARCHSLIPDATERF = @SEARCHSLIPDATE" + Environment.NewLine;
                    // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                    sqlCommand.Cancel(); 
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                    SqlParameter paraSearchSlipDate = sqlCommand.Parameters.Add("@SEARCHSLIPDATE", SqlDbType.Int);
                    // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                    //KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipWork.SalesSlipNum);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesSlipWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.LogicalDeleteCode);
                    // add by liusy 2011/12/02 readmine #8412 ---------<<<<<<
                    paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesSlipWork.UpdateDateTime);
                    // add by liusy 2011/12/02 readmine #8412 --------->>>>>>
                    myReader.Close();
                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 売上明細データを論理削除します。
        /// </summary>
        /// <param name="salesdetailworkList">削除対象の売上明細データのリスト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns></returns>
        private int DeleteSalesDetailWork(ArrayList salesdetailworkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            if (salesdetailworkList.Count > 0)
            {
                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    ArrayList AcceptOdrList = new ArrayList();  // 削除対象の受注マスタデータリスト
                    
                    foreach (object item in salesdetailworkList)
                    {
                        SalesDetailWork dtlwork = item as SalesDetailWork;

                        if (dtlwork != null)
                        {
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTIL.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,DTIL.UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,DTIL.UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,DTIL.UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,DTIL.LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SALESDETAILRF AS DTIL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTIL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DTIL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //Prameterオブジェクトの作成
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                            //KEYコマンドを設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);   // 企業コード
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dtlwork.AcptAnOdrStatus);  // 受注ステータス
                            findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.SalesSlipDtlNum);  // 明細通番

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                SalesSlipWork orgWork = new SalesSlipWork();
                                orgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                                orgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                                orgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                                orgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                                orgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                                
                                // 更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)orgWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                // 論理削除区分の設定
                                orgWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                                sqlText = "";
                                sqlText += "UPDATE" + Environment.NewLine;
                                sqlText += "  SALESDETAILRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;

                                sqlCommand.Cancel();
                                sqlCommand.CommandText = sqlText;

                                //Prameterオブジェクトの作成
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                                //KEYコマンドを再設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);   // 企業コード
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dtlwork.AcptAnOdrStatus);  // 受注ステータス
                                findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.SalesSlipDtlNum);  // 明細通番

                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orgWork.UpdateDateTime);
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orgWork.UpdEmployeeCode);
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orgWork.UpdAssemblyId1);
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orgWork.UpdAssemblyId2);
                                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orgWork.LogicalDeleteCode);

                                myReader.Close();
                                sqlCommand.ExecuteNonQuery();

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                                // 論理削除対象となる受注マスタデータを作成
                                AcceptOdrList.Add(this.MakeAcceptOdrWork(dtlwork));
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                //status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //return status;
                            }
                        }
                        else
                        {
                            // １つでも不正なパラメータが設定されていた場合は処理失敗とする。
                            return status;
                        }
                    }

                    // 受注マスタに登録されているレコードを論理削除する
                    AcceptOdr.LogicalDeleteAcceptOdrProc(ref AcceptOdrList, 0, ref sqlConnection, ref sqlTransaction);
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        myReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 元黒伝の赤黒連結売上伝票番号をリセットします
        /// </summary>
        /// <param name="salesSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 元黒伝の赤黒連結売上伝票番号をリセットします</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        private int DeleteDebitNLnkSalesSlipNum(SalesSlipDeleteWork salesSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
                IFileHeader flhd = (IFileHeader)new SalesSlipWork();
                new FileHeader(this).SetUpdateHeader(ref flhd, this);
                // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<
                string sqlText = "";
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  SALESSLIPRF" + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  DEBITNOTEDIVRF = 0" + Environment.NewLine;
                sqlText += " ,DEBITNLNKSALESSLNUMRF = NULL" + Environment.NewLine;
                // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
                sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEBITNLNKSALESSLNUMRF = @FINDDEBITNLNKSALESSLNUM" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@FINDDEBITNLNKSALESSLNUM", SqlDbType.NChar);
                    // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<

                    //KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.AcptAnOdrStatus);
                    findDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.SalesSlipNum);
                    // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
                    // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }

        # region [DEL 2007/09/11]
        /*
        /// <summary>
        /// 仕入伝票明細を論理削除します
        /// </summary>
        /// <param name="salesSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票明細を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        private int DeleteSalesDetailWork(StockSlipDeleteWork salesSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●まずは1伝票番号だけを削除できるようにする(List化未対応)
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DTIL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTIL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,DTIL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,DTIL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,DTIL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKDETAILRF AS DTIL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //KEYコマンドを設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.EnterpriseCode);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierFormal);
                findDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierSlipNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    StockSlipWork salesSlipWork = new StockSlipWork();

                    salesSlipWork.EnterpriseCode = salesSlipDeleteWork.EnterpriseCode;
                    salesSlipWork.SupplierFormal = salesSlipDeleteWork.SupplierFormal;
                    salesSlipWork.SupplierSlipNo = salesSlipDeleteWork.SupplierSlipNo;
                    salesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    salesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    salesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    salesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    salesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    
                    // 更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesSlipWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    // 論理削除区分の設定
                    salesSlipWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                    sqlText = "";
                    sqlText += "UPDATE" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF" + Environment.NewLine;
                    sqlText += "SET" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                    sqlCommand.Cancel();
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SupplierFormal);
                    findDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.SupplierSlipNo);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesSlipWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesSlipWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesSlipWork.LogicalDeleteCode);

                    myReader.Close();
                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    //status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    //return status;
                }

                //--- DEL 2007/09/11 M.Kubota --->>>
                //●まずは1伝票番号だけを削除できるようにする(List化未対応)
                //using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO", sqlConnection, sqlTransaction))
                //{
                //    //Prameterオブジェクトの作成
                //    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                //    SqlParameter findDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                    
                //    //Parameterオブジェクトへ値設定
                //    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.EnterpriseCode);
                //    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierFormal);
                //    findDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierSlipNo);
                    
                //    sqlCommand.ExecuteNonQuery();
                    
                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //--- DEL 2007/09/11 M.Kubota ---<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        */
        # endregion

        # region DELETE 2007/09/11 M.Kubota
        /*
        /// <summary>
        /// 仕入伝票詳細を物理削除します
        /// </summary>
        /// <param name="salesSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票詳細を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        private int DeleteStockExplaDataWork(StockSlipDeleteWork salesSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●まずは1伝票番号だけを削除できるようにする(List化未対応)

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                //●まずは1伝票番号だけを削除できるようにする(List化未対応)
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKEXPLADATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO", sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                    
                    //KEYコマンドを再設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDeleteWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierFormal);
                    findDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetInt32(salesSlipDeleteWork.SupplierSlipNo);
                    
                    sqlCommand.ExecuteNonQuery();
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        */
        # endregion

        #endregion

        #region [RedWrite]　赤伝発行処理
        /// <summary>
        /// 赤伝発行初期処理
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">元黒伝List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retRedList">戻り値List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        public int RedWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            try
            {
                //読込対象クラスが無い場合は無処理
                if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //赤伝位置格納用
                Int32 listPos_RedSalesSlipWork = -1;
                Int32 listPos_RedSalesDetailWork = -1;

                //赤伝格納用
                SalesSlipWork redSalesSlipWork = null;
                ArrayList redSalesDetailWork = null;

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": データベース接続情報パラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●元黒票更新List内の売上クラスを抽出
                int listPos_OrgSalesSlipWork = -1;
                SalesSlipWork orgSalesSlipWork = MakeSalesSlipWork(originList, out listPos_OrgSalesSlipWork);

                if (orgSalesSlipWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 元黒伝対象売上オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●赤伝票更新List内の売上クラスを抽出
                redSalesSlipWork = MakeSalesSlipWork(redList, out listPos_RedSalesSlipWork);
                if (redSalesSlipWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 赤伝対象売上オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //●赤伝情報取得
                if (!MakeSalesSlipData(redList, out redSalesSlipWork, out listPos_RedSalesSlipWork, out redSalesDetailWork, out listPos_RedSalesDetailWork))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 赤伝発行　赤伝オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // 出荷差分数を設定する
                foreach (SalesDetailWork reddtlwrk in redSalesDetailWork)
                {
                    //reddtlwrk.ShipmCntDifference = reddtlwrk.ShipmentCnt * -1;
                    reddtlwrk.ShipmCntDifference = reddtlwrk.ShipmentCnt;
                    reddtlwrk.AcptAnOdrRemainCnt = reddtlwrk.ShipmentCnt;
                    reddtlwrk.RemainCntUpdDate = DateTime.Now;
                }

                //●元黒伝情報取得
                if (!MakeOrgSalesSlipData(originList, orgSalesSlipWork.SalesSlipNum, out orgSalesSlipWork, out listPos_OrgSalesSlipWork))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": 元黒伝発行　元黒伝オブジェクトパラメータが未指定です。";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // add 2007.05.27 saitoh >>>>>>>>>>
                //●拠点制御設定マスタより仕入拠点コードを抽出
                //if (redSalesSlipWork.StockGoodsCd == 0)
                //{
                //    status = this.SearchStockSecCd(ref redSalesSlipWork, ref sqlConnection, ref sqlTransaction);
                //}
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    retMsg = "拠点制御設定が正しく設定されておりません。";
                //    return status;
                //}
                // add 2007.05.27 saitoh <<<<<<<<<<

                //●売上伝票番号の採番
                # region [--- 売上伝票番号の採番 ---]
                //採番チェック
                //赤伝票更新で売上伝票番号が入っていない場合(新規登録)
                if (SalesTool.StrToIntDef(redSalesSlipWork.SalesSlipNum, 0) == 0)
                {
                    string sectionCode;
                    string salesSlipNo;

                    sectionCode = redSalesSlipWork.SectionCode;

                    status = CreateSalesSlipNumProc(redSalesSlipWork.EnterpriseCode, sectionCode, out salesSlipNo, redSalesSlipWork.AcptAnOdrStatus, out retMsg, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && SalesTool.StrToIntDef(salesSlipNo, 0) != 0)
                    {
                        //新規自動採番の売上伝票番号を赤伝に代入
                        redSalesSlipWork.SalesSlipNum = salesSlipNo;

                        //元黒伝の売上伝票番号を赤伝の赤黒連結売上伝票番号に代入
                        redSalesSlipWork.DebitNLnkSalesSlNum = orgSalesSlipWork.SalesSlipNum;

                        if (redSalesDetailWork != null)
                        {
                            foreach (SalesDetailWork redSalesDetail in redSalesDetailWork)
                            {
                                // 売上伝票番号を設定
                                redSalesDetail.SalesSlipNum = salesSlipNo;

                                // 赤伝明細には元黒明細の受注番号が設定されている

                                // 売上明細通番を設定
                                if (redSalesDetail.SalesSlipDtlNum <= 0)
                                {
                                    Int64 salesslipdtlnum = 0;

                                    int slipDataDivide = 0;

                                    switch (redSalesDetail.AcptAnOdrStatus)
                                    {
                                        case 10:  // 見積
                                            slipDataDivide = (int)SlipDataDivide.Estimate;
                                            break;
                                        case 20:  // 受注
                                            slipDataDivide = (int)SlipDataDivide.AcceptAnOrder;
                                            break;
                                        case 30:  // 売上
                                            slipDataDivide = (int)SlipDataDivide.Sales;
                                            break;
                                        case 40:  // 出荷
                                            slipDataDivide = (int)SlipDataDivide.Shipment;
                                            break;
                                    }

                                    status = AcceptOdr.GetSlipDetailNo(redSalesDetail.EnterpriseCode, redSalesDetail.SectionCode,
                                                                           slipDataDivide, out salesslipdtlnum);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesslipdtlnum != 0)
                                    {
                                        redSalesDetail.SalesSlipDtlNum = salesslipdtlnum;
                                    }
                                    else
                                    {
                                        retMsg = "売上明細通番の採番に失敗しました。";
                                        return status;
                                    }
                                }
                            }
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //番号が取得出来なかった場合は終了
                    else
                    {
                        //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (retMsg == null || retMsg == "") retMsg = "売上伝票番号が採番できませんでした。番号設定を見直してください。";
                        return status;
                    }
                }
                //伝票更新で売上伝票番号が入っている場合(既存伝票更新or不正データの場合はエラー出力)
                else status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                # endregion

                // ---ADD BY 丁建雄 on 2012/02/06 for Redmine#28336 ---->>>>>
                # region [--- 得意先伝票番号の採番 ---]
                // 得意先伝票番号の採番
                if (redSalesSlipWork.CustSlipNo == 0 && redSalesSlipWork.AcptAnOdrStatus == 30)
                {
                    Int64 custSlipNo = 0;
                    SqlConnection dmyConnection = null;
                    SqlTransaction dmyTransaction = null;
                    status = this.CstSlpNoSetDb.GetCustomerSlipNo(redSalesSlipWork.EnterpriseCode, redSalesSlipWork.CustomerCode, redSalesSlipWork.SalesDate, out custSlipNo, ref dmyConnection, ref dmyTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        redSalesSlipWork.CustSlipNo = Convert.ToInt32(custSlipNo);
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // 得意先伝票番号を取得する必要が無い場合
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        retMsg = "得意先伝票番号の採番に失敗しました.";
                        return status;
                    }
                }
                # endregion [--- 得意先伝票番号の採番 ---]
                // ---ADD BY 丁建雄 on 2012/02/06 for Redmine#28336 ----<<<<<

                //●元黒伝に赤伝の売上伝票番号をセットする
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (SalesTool.StrToIntDef(orgSalesSlipWork.DebitNLnkSalesSlNum, 0) == 0)
                    {
                        orgSalesSlipWork.DebitNLnkSalesSlNum = redSalesSlipWork.SalesSlipNum;
                        orgSalesSlipWork.DebitNoteDiv = 2;
                    }
                }

                # region [--- DEL ---]
                /*--- DEL 2008/06/06 M.Kubota --->>>
                //●拠点制御設定マスタより在庫更新拠点コードを抽出
                if (redSalesSlipWork.SalesGoodsCd == 0)
                {
                    status = this.SearchStockSecCd(ref redSalesSlipWork, ref orgSalesSlipWork, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    retMsg = "拠点制御設定が正しく設定されておりません。";
                    return status;
                }
                  --- DEL 2008/06/06 M.Kubota ---<<<*/

                //●赤伝項目設定・元黒伝項目設定
                //status = MakeRedStockSlip(ref redSalesSlipWork, ref redSalesDetailWork, ref redStockExplaDataWork, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                /*
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //赤伝売上格納
                    redList[listPos_RedSalesSlipWork] = redSalesSlipWork;
                    
                    if (redSalesDetailWork != null)
                        redList[listPos_RedSalesDetailWork] = redSalesDetailWork;
                    
                    //元黒伝売上ヘッダ格納
                    originList[listPos_OrgSalesSlipWork] = orgSalesSlipWork;
                }
                */
                # endregion

                // 既存売上伝票の読み込み
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    SalesSlipWork oldSalesSlipWork;
                    SalesSlipWork[] copySalesSlipWork = new SalesSlipWork[0];
                    SalesSlipReadWork salesSlipReadWork = this.SalesSlipReadWorkOutPut(orgSalesSlipWork);

                    status = this.ReadSalesSlipWork(out oldSalesSlipWork, ref copySalesSlipWork, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList oldSalesDetailWorkList;
                        ArrayList[] copySalesDetailWorkList = new ArrayList[0];
                        this.ReadSalesDetailWork(out oldSalesDetailWorkList, ref copySalesDetailWorkList, salesSlipReadWork, ref sqlConnection, ref sqlTransaction);

                        if (oldSalesDetailWorkList != null)
                        {
                            originList.Add(oldSalesDetailWorkList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }
            return status;
        }

        # region [未使用なので仮削除 2007/11/26]
        /*
        /// <summary>
        /// 赤伝売上伝票情報作成
        /// </summary>
        /// <param name="redSalesSlipWork">赤伝売上伝票クラス</param>
        /// <param name="redSalesDetailWorks">赤伝売上伝票明細クラスArray</param>
        /// <param name="redStockExplaDataWorks">赤伝売上伝票詳細クラスArray</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">エラー項目名</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        private int MakeRedStockSlip(ref SalesSlipWork redSalesSlipWork, ref ArrayList redSalesDetailWorks, ref ArrayList redStockExplaDataWorks,
                                     out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = "";
            retItemInfo = "";

            #region 赤伝伝票番号採番
            //●赤伝伝票番号(新規採番)
            //赤伝現行伝票
            Int32 supplierSlipNo = 0;
            
            string sectionCode = null;

            sectionCode = redSalesSlipWork.StockSectionCd;

            status = CreateSupplierSlipNoProc(redSalesSlipWork.EnterpriseCode, sectionCode , out supplierSlipNo, redSalesSlipWork.SupplierFormal, out retMsg, ref sqlConnection, ref sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || supplierSlipNo == 0)
            {
                //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                if (retMsg == null || retMsg == "") retMsg = "仕入伝票番号が採番できませんでした。番号設定を見直してください。";
                retItemInfo = "SupplierSlipNo";
                return status;
            }
            #endregion

            #region 赤伝伝票項目設定
            //●赤伝項目初期化
            //作成日時
            redSalesSlipWork.CreateDateTime = DateTime.MinValue;
            //更新日時
            redSalesSlipWork.UpdateDateTime = DateTime.MinValue;
            //Guid
            redSalesSlipWork.FileHeaderGuid = Guid.Empty;
            //更新従業員コード
            redSalesSlipWork.UpdEmployeeCode = "";
            //更新アセンブリID1
            redSalesSlipWork.UpdAssemblyId1 = "";
            //更新アセンブリID2
            redSalesSlipWork.UpdAssemblyId2 = "";
            //論理削除区分
            redSalesSlipWork.LogicalDeleteCode = 0;

            //●赤伝変更項目セット
            //仕入伝票番号(新規採番)
            redSalesSlipWork.SupplierSlipNo = supplierSlipNo;
            //赤黒連結仕入伝票番号(元黒からコピー)
            //redSalesSlipWork.DebitNLnkSuppSlipNo = 元黒.salesSlipNum;
            #endregion
            #region 赤伝伝票明細項目設定
            foreach (StockDetailWork redSalesDetailWork in redSalesDetailWorks)
            {
                //●赤伝明細項目初期化
                //作成日時
                redSalesDetailWork.CreateDateTime = DateTime.MinValue;
                //更新日時
                redSalesDetailWork.UpdateDateTime = DateTime.MinValue;
                //Guid
                redSalesDetailWork.FileHeaderGuid = Guid.Empty;
                //更新従業員コード
                redSalesDetailWork.UpdEmployeeCode = "";
                //更新アセンブリID1
                redSalesDetailWork.UpdAssemblyId1 = "";
                //更新アセンブリID2
                redSalesDetailWork.UpdAssemblyId2 = "";
                //論理削除区分
                redSalesDetailWork.LogicalDeleteCode = 0;

                //●赤伝変更項目セット
                //仕入伝票番号(新規採番)
                redSalesDetailWork.SupplierSlipNo = redSalesSlipWork.SupplierSlipNo;
            }
            #endregion
            #region 赤伝伝票詳細項目設定 DELETE 2007/09/11 M.Kubota
            
            foreach (StockExplaDataWork redStockExplaDataWork in redStockExplaDataWorks)
            {
                //●赤伝明細項目初期化
                //作成日時
                redStockExplaDataWork.CreateDateTime = DateTime.MinValue;
                //更新日時
                redStockExplaDataWork.UpdateDateTime = DateTime.MinValue;
                //Guid
                redStockExplaDataWork.FileHeaderGuid = Guid.Empty;
                //更新従業員コード
                redStockExplaDataWork.UpdEmployeeCode = "";
                //更新アセンブリID1
                redStockExplaDataWork.UpdAssemblyId1 = "";
                //更新アセンブリID2
                redStockExplaDataWork.UpdAssemblyId2 = "";
                //論理削除区分
                redStockExplaDataWork.LogicalDeleteCode = 0;

                //●赤伝変更項目セット
                //仕入伝票番号(新規採番)
                redStockExplaDataWork.SupplierSlipNo = redSalesSlipWork.SupplierSlipNo;
                //赤黒連結仕入伝票番号(元黒からコピー)
            }
            
            #endregion

            //戻り値を戻す
            return status;
        }
        */
        # endregion

        /// <summary>
        /// 赤伝発行処理
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="originList">元黒伝List</param>
        /// <param name="redList">赤伝List</param>
        /// <param name="retRedList">戻り値List</param>
        /// <param name="position">更新対象ｵﾌﾞｼﾞｪｸﾄ位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="retMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        public int RedWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList retRedList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //赤伝・赤見積の２更新（元黒には変更は無いので更新しない）
            // Delete saito >>>>>>
            //int listPos_RedAcceptOdrWork = -1;
            // Delete saito <<<<<<

            //●赤伝位置格納
            int listPos_RedSalesSlipWork = -1;
            int listPos_RedSalesDetailWork = -1;

            //●元黒伝位置格納
            int listPos_OrgSalesSlipWork = -1;

            //●赤伝格納用
            SalesSlipWork redSalesSlipWork = null;
            ArrayList redSalesDetailWork = null;
            ArrayList slpDtlAddInfWorks = null;

            //●元黒伝格納用
            SalesSlipWork orgSalesSlipWork = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": データベース接続情報パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (redList == null || redList.Count == 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 赤伝更新対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●先に赤伝売上情報を取得
            redSalesSlipWork = MakeSalesSlipWork(redList, out listPos_RedSalesSlipWork);
            if (redSalesSlipWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 赤伝更新対象売上パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (originList == null || originList.Count == 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 元黒伝更新対象パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●元黒伝売上情報を取得
            orgSalesSlipWork = MakeSalesSlipWork(originList, out listPos_OrgSalesSlipWork);
            if (orgSalesSlipWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 赤伝更新対象売上パラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●赤伝票更新List内の伝票クラスを抽出
            if (!MakeSalesSlipData(redList, out redSalesSlipWork, out listPos_RedSalesSlipWork, out redSalesDetailWork, out listPos_RedSalesDetailWork))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象赤伝オブジェクトパラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            //●元黒伝票更新List内の伝票クラスを抽出
            if (!MakeOrgSalesSlipData(originList, orgSalesSlipWork.SalesSlipNum, out orgSalesSlipWork, out listPos_OrgSalesSlipWork))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象元黒伝オブジェクトパラメータが未指定です。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            slpDtlAddInfWorks = ListUtils.Find(redList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            //●赤伝Write
            //StockSlipWriteWork redStockSlipWriteWork = new StockSlipWriteWork();
            // Delete saito >>>>>>
            //redStockSlipWriteWork.PrevRpSlipKindCd = 0;
            //redStockSlipWriteWork.NextRpSlipKindCd = redSalesSlipWork.RpSlipKindCd;
            //redStockSlipWriteWork.RpSlipNoReNumberingFlag = false;
            // Delete saito <<<<<<

            // 売上伝票更新
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
            // status = WriteSalesSlipWork(ref redSalesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            status = WriteSalesSlipWork(ref redSalesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
            // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

            // 売上伝票明細更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && redSalesDetailWork != null)
            {
                status = WriteSalesDetailWork(ref redSalesDetailWork, redSalesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            // 計上元売上明細データの受注残数更新 (計上元の有無は呼出し先で行っている)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.UpdateAcptAnOdrRemainCnt(redSalesSlipWork, redSalesDetailWork, slpDtlAddInfWorks, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }

            //元黒売上伝票更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                // status = WriteSalesSlipWork(ref orgSalesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                status = WriteSalesSlipWork(ref orgSalesSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
                // UPD 2011/07/25 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
            }

            /*
            //●更新結果を戻り値に戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                originList[listPos_OrgSalesSlipWork] = orgSalesSlipWork;

                redList[listPos_RedSalesSlipWork] = redSalesSlipWork;
                redList[listPos_RedSalesDetailWork] = redSalesDetailWork;

                赤伝売上格納
                retRedList.Add(redSalesSlipWork);
                retRedList.Add(redSalesDetailWork);

                元黒伝売上格納
                originList.Add(orgSalesSlipWork);
            }
            */
            return status;
        }
        #endregion

        #region [売上パラメータ取得]
        /// <summary>
        /// 売上パラメータ取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <returns>STATUS</returns>
        private SalesSlipWork MakeSalesSlipWork(CustomSerializeArrayList paraList)
        {
            Int32 position;
            return MakeSalesSlipWork(paraList, out position);
        }

        /// <summary>
        /// 売上パラメータ取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <param name="position">売上パラメータ位置</param>
        /// <returns>STATUS</returns>
        private SalesSlipWork MakeSalesSlipWork(CustomSerializeArrayList paraList, out Int32 position)
        {
            SalesSlipWork salesSlipWork = null;
            position = -1;

            //売上パラメータ生成
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is SalesSlipWork)
                {
                    salesSlipWork = paraList[i] as SalesSlipWork;
                    position = i;
                    break;
                }
            }
            return salesSlipWork;
        }

        /// <summary>
        /// 売上読込パラメータ位置取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <returns>position</returns>
        private int MakeSalesSlipReadPosi(CustomSerializeArrayList paraList)
        {
            int position = -1;

            //売上パラメータ生成
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is SalesSlipReadWork)
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        /// <summary>
        /// 伝票パラメータ一式取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <param name="salesSlipWork">伝票情報戻り値</param>
        /// <param name="salesSlipPos">伝票情報位置</param>
        /// <param name="salesDetailWork">伝票明細戻り値</param>
        /// <param name="salesDetailPos">伝票明細位置</param>
        /// <returns></returns>
        private bool MakeSalesSlipData(CustomSerializeArrayList paraList, 
                                       out SalesSlipWork salesSlipWork, out Int32 salesSlipPos,
                                       out ArrayList salesDetailWork, out Int32 salesDetailPos)
        {
            //戻り値初期化
            salesSlipWork = null;
            salesDetailWork = null;
            
            salesSlipPos = -1;
            salesDetailPos = -1;

            //伝票パラメータ生成
            for (Int32 i = 0; i < paraList.Count; i++)
            {
                //伝票情報取得
                if (salesSlipWork == null && paraList[i] is SalesSlipWork)
                {
                    salesSlipWork = paraList[i] as SalesSlipWork;
                    salesSlipPos = i;
                    if (salesSlipPos >= 0 && salesDetailPos >= 0) break;
                }

                if (salesDetailWork == null && paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is SalesDetailWork)
                {
                    salesDetailWork = paraList[i] as ArrayList;
                    salesDetailPos = i;
                    if (salesSlipPos >= 0 && salesDetailPos >= 0) break;
                }
            }

            //ﾃﾞｰﾀ有無判定
            if (salesSlipPos >= 0 && salesDetailPos >= 0) return true;
            else return false;
        }

        /// <summary>
        /// 伝票パラメータ一式取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <param name="salesSlipNum">検索伝票番号</param>
        /// <param name="salesSlipWork">伝票情報戻り値</param>
        /// <param name="salesSlipPos">伝票情報位置</param>
        /// <returns>T:ﾃﾞｰﾀ有り F:ﾃﾞｰﾀ無し</returns>
        private bool MakeOrgSalesSlipData(CustomSerializeArrayList paraList, string salesSlipNum, out SalesSlipWork salesSlipWork, out Int32 salesSlipPos)
        {
            //戻り値初期化
            salesSlipWork = null;
            salesSlipPos = -1;

            //伝票パラメータ生成
            for (Int32 i = 0; i < paraList.Count; i++)
            {
                //伝票情報取得
                if (salesSlipWork == null && paraList[i] is SalesSlipWork)
                {
                    salesSlipWork = paraList[i] as SalesSlipWork;
                    salesSlipPos = i;
                    if (salesSlipPos >= 0) break;
                }
            }

            //ﾃﾞｰﾀ有無判定
            if (salesSlipPos >= 0) return true;
            else return false;
        }

        # region [未使用につき仮削除 2007/11/26]
        /*
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesSlipReadWork">検索条件格納クラス</param>
        /// <param name="mode">検索条件モード 1:ヘッダ 2:明細 3:詳細</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.29</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSlipReadWork stockSlipReadWork, Int32 mode)
        {
            //string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);

            //仕入伝票番号
            if (mode > 0)
            {
                if (stockSlipReadWork.SupplierSlipNo > 0)
                {
                    retstring += "AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO ";
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);
                }
            }

            //仕入形式
            if (mode > 0)
            {
                if (stockSlipReadWork.SupplierFormal >= 0)
                {
                    retstring += "AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL ";
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
                }
            }

            //仕入伝票区分
            if (mode == 1)
            {
                if (stockSlipReadWork.SupplierFormal > 0)
                {
                    retstring += "AND SUPPLIERSLIPCDRF=@FINDSUPPLIERSLIPCD ";
                    SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                    paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipCd);
                }
            }

            //赤伝区分
            if (mode == 1)
            {
                if (stockSlipReadWork.DebitNoteDiv >= 0)
                {
                    retstring += "AND DEBITNOTEDIVRF=@FINDDEBITNOTEDIV ";
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.DebitNoteDiv);
                }
            }

            //仕入商品区分
            if (mode == 1 || mode == 2)
            {
                if (stockSlipReadWork.StockGoodsCd >= 0)
                {
                    retstring += "AND STOCKGOODSCDRF=@FINDSTOCKGOODSCD ";
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@FINDSTOCKGOODSCD", SqlDbType.Int);
                    paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.StockGoodsCd);
                }
            }

            //仕入担当者コード
            if (mode == 1 || mode == 2)
            {
                if (stockSlipReadWork.StockGoodsCd > 0)
                {
                    retstring += "AND STOCKAGENTCODERF=@FINDSTOCKAGENTCODE ";
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
                    paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockAgentCode);
                }
            }

            //相手先伝票番号
            if (mode == 1)
            {
                if (stockSlipReadWork.PartySaleSlipNum != null)
                {
                    retstring += "AND PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM ";
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.PartySaleSlipNum);
                }
            }

            //仕入拠点コード
            if (mode == 1)
            {
                if (stockSlipReadWork.StockSectionCd != null)
                {
                    retstring += "AND STOCKSECTIONCDRF=@FINDSTOCKSECTIONCD ";
                    SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);
                    paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockSectionCd);
                }
            }

            //事業者コード(開始)(終了)
            if (mode == 1 || mode == 2)
            {
                if (stockSlipReadWork.CarrierEpCodeStart > 0 && stockSlipReadWork.CarrierEpCodeEnd > 0)
                {
                    retstring += "AND (CARRIEREPCODERF>=@FINDCARRIEREPCODESTART AND CARRIERCODERF<=@FINDCARRIEREPCODEEND) ";
                    SqlParameter paraCarrierEpCodeStart = sqlCommand.Parameters.Add("@FINDCARRIEREPCODESTART", SqlDbType.Int);
                    SqlParameter paraCarrierEpCodeEnd = sqlCommand.Parameters.Add("@FINDCARRIEREPCODEEND", SqlDbType.Int);
                    paraCarrierEpCodeStart.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CarrierEpCodeStart);
                    paraCarrierEpCodeEnd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CarrierEpCodeEnd);
                }
            }

            //得意先コード(開始)(終了)
            if (mode == 1)
            {
                if (stockSlipReadWork.CustomerCodeStart > 0 && stockSlipReadWork.CustomerCodeEnd > 0)
                {
                    retstring += "AND (CUSTOMERCODERF>=@FINDCUSTOMERCODESTART AND CUSTOMERCODERF<=@FINDCUSTOMERCODEEND) ";
                    SqlParameter paraCustomerCodeStart = sqlCommand.Parameters.Add("@FINDCUSTOMERCODESTART", SqlDbType.Int);
                    SqlParameter paraCustomerCodeEnd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEEND", SqlDbType.Int);
                    paraCustomerCodeStart.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CustomerCodeStart);
                    paraCustomerCodeEnd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CustomerCodeEnd);
                }
            }

            //倉庫コード(開始)(終了)
            if (mode == 1 || mode == 2)
            {
                if (stockSlipReadWork.WarehouseCodeStart != null && stockSlipReadWork.WarehouseCodeEnd != null)
                {
                    retstring += "AND (WAREHOUSECODERF>=@FINDWAREHOUSECODESTART AND WAREHOUSECODERF<=@FINDWAREHOUSECODEEND) ";
                    SqlParameter paraWarehouseCodeStart = sqlCommand.Parameters.Add("@FINDWAREHOUSECODESTART", SqlDbType.NChar);
                    SqlParameter paraWarehouseCodeEnd = sqlCommand.Parameters.Add("@FINDWAREHOUSECODEEND", SqlDbType.NChar);
                    paraWarehouseCodeStart.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.WarehouseCodeStart);
                    paraWarehouseCodeEnd.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.WarehouseCodeEnd);
                }
            }

            //仕入日(開始)(終了)
            if (mode == 1)
            {
                if (stockSlipReadWork.StockDateStart > DateTime.MinValue && stockSlipReadWork.StockDateEnd > DateTime.MinValue)
                {
                    retstring += "AND (STOCKDATERF>=@FINDSTOCKDATESTART AND STOCKDATERF<=@FINDSTOCKDATEEND) ";
                    SqlParameter paraStockDateStart = sqlCommand.Parameters.Add("@FINDSTOCKDATESTART", SqlDbType.Int);
                    SqlParameter paraStockDateEnd = sqlCommand.Parameters.Add("@FINDSTOCKDATEEND", SqlDbType.Int);
                    paraStockDateStart.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockDateStart);
                    paraStockDateEnd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockDateEnd);
                }
            }

            //仕入計上日(開始)(終了)
            if (mode == 1)
            {
                if (stockSlipReadWork.StockAddUpADateStart > DateTime.MinValue && stockSlipReadWork.StockAddUpADateEnd > DateTime.MinValue)
                {
                    retstring += "AND (STOCKADDUPADATERF>=@FINDSTOCKADDUPADATESTART AND STOCKADDUPADATERF<=@FINDSTOCKADDUPADATEEND) ";
                    SqlParameter paraStockAddUpADateStart = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATESTART", SqlDbType.Int);
                    SqlParameter paraStockAddUpADateEnd = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEEND", SqlDbType.Int);
                    paraStockAddUpADateStart.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockAddUpADateStart);
                    paraStockAddUpADateEnd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockAddUpADateEnd);
                }
            }

            //商品コード
            if (mode == 2)
            {
                if (stockSlipReadWork.GoodsCode != null)
                {
                    retstring += "AND GOODSCODERF=@FINDGOODSCODE ";
                    SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@FINDGOODSCODE", SqlDbType.NVarChar);
                    paraGoodsCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.GoodsCode);
                }
            }

            //商品電話番号1(開始)(終了)
            if (mode == 3)
            {
                if (stockSlipReadWork.StockTelNo1Start != null && stockSlipReadWork.StockTelNo1End != null)
                {
                    retstring += "AND (STOCKTELNO1RF>=@FINDSTOCKTELNO1START AND STOCKTELNO1RF<=@FINDSTOCKTELNO1END) ";
                    SqlParameter paraStockTelNo1Start = sqlCommand.Parameters.Add("@FINDSTOCKTELNO1START", SqlDbType.NChar);
                    SqlParameter paraStockTelNo1End = sqlCommand.Parameters.Add("@FINDSTOCKTELNO1END", SqlDbType.NChar);
                    paraStockTelNo1Start.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockTelNo1Start);
                    paraStockTelNo1End.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockTelNo1End);
                }
            }

        
            //製造番号1(開始)(終了)
            if (mode == 3)
            {
                if (salesSlipReadWork.ProductNumber1Start != null && salesSlipReadWork.ProductNumber1End != null)
                {
                    retstring += "AND (PRODUCTNUMBER1RF>=@FINDPRODUCTNUMBER1START AND PRODUCTNUMBER1RF<=@FINDPRODUCTNUMBER1END) ";
                    SqlParameter paraProductNumber1Start = sqlCommand.Parameters.Add("@FINDPRODUCTNUMBER1START", SqlDbType.NChar);
                    SqlParameter paraProductNumber1End = sqlCommand.Parameters.Add("@FINDPRODUCTNUMBER1END", SqlDbType.NChar);
                    paraProductNumber1Start.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.ProductNumber1Start);
                    paraProductNumber1End.Value = SqlDataMediator.SqlSetString(salesSlipReadWork.ProductNumber1End);
                }
            }
        
            return retstring;
        }
        */
        # endregion

        # region [--- DEL 2008/06/06 M.Kubota --->>>]
#if false
        /// <summary>
        /// 拠点制御設定マスタから在庫更新拠点コードを取得する
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <param name="oldSalesSlipWork">旧売上データ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点制御設定マスタから在庫更新拠点コードを取得する</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchStockSecCd(ref SalesSlipWork salesSlipWork, ref SalesSlipWork oldSalesSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    sqlCommand.CommandText = "SELECT CTRLFUNCSECTIONCODERF FROM SECCTRLSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CTRLFUNCCODERF=90 ";

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesSlipWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        salesSlipWork.StockUpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
                        if (oldSalesSlipWork != null)
                        {
                            if (oldSalesSlipWork.CreateDateTime > DateTime.MinValue)
                                oldSalesSlipWork.StockUpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
#endif
        # endregion
        # endregion

        #region [CreateSalesSlipNumProc]　売上伝票番号採番
        /// <summary>
        /// 売上伝票番号を採番して返します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="salesSlipNum">採番結果</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上伝票番号を採番して返します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.26</br>
        private int CreateSalesSlipNumProc(string enterpriseCode, string sectionCode, out string salesSlipNum, Int32 acptAnOdrStatus, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            salesSlipNum = "";
            retMsg = "";

            // 拠点コード、見積書番号をパラメータとして渡さない採番メソッドに変更する
            //NumberNumbering numberNumbering = new NumberNumbering();  //DEL 2008/06/06 M.Kubota

            NumberingManager numberingManager = new NumberingManager(); //ADD 2008/06/06 M.Kubota  

            //番号範囲分ループ
            string firstNo = "";
            string slipNo = string.Empty;  //ADD 2008/06/06 M.Kubota

            Int32 loopCnt = 0;	//最大ループカウンタ
            while (loopCnt <= 999999999)
            {
                # region --- DEL 2008/06/06 M.Kubota ---
                //--- DEL 2008/06/06 M.Kubota --->>>
                //string no;
                //Int32 ptnCd = 0;
                //Int32 noCode = 0;
                //switch (acptAnOdrStatus)
                //{
                //    case 10:  // 見積
                //        noCode = 530;
                //        break;
                //    case 20:  // 受注
                //        noCode = 540;
                //        break;
                //    case 30:  // 売上
                //        noCode = 1200;
                //        break;
                //    case 40:  // 出荷
                //        noCode = 1300;
                //        break;
                //}

                //const int retry = 50; // リトライ回数を指定
                //int retrycount = retry;
                //do
                //{
                //    // 戻り値の初期化
                //    no = "";
                //    ptnCd = 0;
                //    retMsg = "";

                //    // 伝票通番を採番
                //    status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out no, out ptnCd, out retMsg);

                //    if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                //    {
                //        retrycount -= 1;
                //        System.Threading.Thread.Sleep(500);  // インターバルタイムをミリ秒で指定
                //    }
                //    else
                //    {
                //        retrycount = 0;
                //    }
                //}
                //while (retrycount > 0);
                //--- DEL 2008/06/06 M.Kubota ---<<<
                # endregion

                long no = -1;
                SerialNumberCode serialnumcd = SerialNumberCode.Empty;

                switch (acptAnOdrStatus)
                {
                    case 10:  // 見積
                        serialnumcd = SerialNumberCode.EstimateSlipNo;
                        break;
                    case 20:  // 受注
                        serialnumcd = SerialNumberCode.AcptAnOdrSlipNo;
                        break;
                    case 30:  // 売上
                        serialnumcd = SerialNumberCode.SalesSlipNum;
                        break;
                    case 40:  // 出荷
                        serialnumcd = SerialNumberCode.ShipmentSlipNo;
                        break;
                }

                // 採番中に排他制御関係でエラーが発生した場合、規定回数リトライをする
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, serialnumcd, out no);

                slipNo = string.Format("{0:d9}", no);  // 9桁で戦闘0埋めをする

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //--- DEL 2008/06/06 M.Kubota --->>>
                    //番号を数値型に変換
                    //Int32 wkSalesSlipNum = System.Convert.ToInt32(no);
                    //初回採番番号を保存
                    //if (firstNo == "") firstNo = no;
                    //初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    //else if (firstNo.Equals(no))
                    //{
                    //    loopCnt = 999999999;
                    //    break;
                    //}
                    //--- DEL 2008/06/06 M.Kubota ---<<<

                    //--- ADD 2008/06/06 M.Kubota --->>>
                    //初回採番番号を保存
                    if (string.IsNullOrEmpty(firstNo))
                    {
                        firstNo = slipNo;
                    }
                    //初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    else if (firstNo.Equals(slipNo))
                    {
                        loopCnt = 999999999;
                        break;
                    }
                    //--- ADD 2008/06/06 M.Kubota ---<<<

                    SqlDataReader myReader = null;
                    //伝票空き番チェック
                    try
                    {
                        //Selectコマンドの生成
                        SqlCommand sqlCommand;

                        string sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SLIP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND SLIP.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

                        using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acptAnOdrStatus);
                            findSalesSlipNum.Value = SqlDataMediator.SqlSetString(no.ToString());
                            
                            try
                            {
                                myReader = sqlCommand.ExecuteReader();
                                //データ無しの場合には戻り値をセット
                                if (!myReader.Read())
                                {
                                    salesSlipNum = slipNo;
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                            }
                            finally
                            {
                                if (myReader != null)
                                {
                                    if (!myReader.IsClosed) myReader.Close();
                                    myReader.Dispose();
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                        break;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                }
                //採番できなかった場合には処理中断。
                else break;

                //同一番号がある場合にはループカウンタをインクリメントし再採番
                loopCnt++;
            }

            //全件ループしても取得出来ない場合
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "売上伝票番号に空き番号がありません。削除可能な伝票を削除してください。";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        #endregion

        # region [売上明細データ → 受注明細データ作成メソッド]
        /// <summary>
        /// 売上明細データから受注明細データを作成する
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns></returns>
        private AcceptOdrWork MakeAcceptOdrWork(SalesDetailWork salesDetail)
        {
            AcceptOdrWork retWork = new AcceptOdrWork();

            retWork.EnterpriseCode = salesDetail.EnterpriseCode;
            retWork.SectionCode = salesDetail.SectionCode;
            retWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo;

            switch (salesDetail.AcptAnOdrStatus)
            {
                case 10:  // 見積
                    retWork.AcptAnOdrStatus = (int)SlipDataDivide.Estimate;
                    break;
                case 20:  // 受注
                    retWork.AcptAnOdrStatus = (int)SlipDataDivide.AcceptAnOrder;
                    break;
                case 30:  // 売上
                    retWork.AcptAnOdrStatus = (int)SlipDataDivide.Sales;
                    break;
                case 40:  // 出荷
                    retWork.AcptAnOdrStatus = (int)SlipDataDivide.Shipment;
                    break;
            }

            retWork.SalesSlipNum = Convert.ToString(salesDetail.SalesSlipNum);
            retWork.DataInputSystem = (int)DataInputSystem.PM;
            retWork.CommonSeqNo = salesDetail.CommonSeqNo;
            retWork.SlipDtlNum = salesDetail.SalesSlipDtlNum;
            retWork.SlipDtlNumDerivNo = 0;
            retWork.SrcLinkDataCode = salesDetail.AcptAnOdrStatusSrc;
            retWork.SrcSlipDtlNum = salesDetail.SalesSlipDtlNumSrc;

            return retWork;
        }

        # endregion

        # region [計上元売上明細データ 取得メソッド]
        /// <summary>
        /// 仕入明細データに紐付く計上元仕入明細データを取得します。
        /// </summary>
        /// <param name="AddUpDetailWorks">計上元仕入明細データリスト</param>
        /// <param name="DetailWorks">計上先仕入明細データリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int ReadAddUpSalesDetailWork(out ArrayList AddUpDetailWorks, ArrayList DetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            AddUpDetailWorks = new ArrayList();

            if (DetailWorks != null && DetailWorks.Count > 0)
            {
                try
                {
                    # region [SqlConnection準備]
                    // SqlConnection が未設定の場合
                    if (sqlConnection == null)
                    {
                        sqlConnection = this.CreateSqlConnection(true);
                    }

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    # endregion

                    # region [SQL文]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ADDUPDTL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------>>>
                    //sqlText += "  SALESDETAILRF AS ADDUPDTL" + Environment.NewLine;
                    sqlText += "  SALESDETAILRF AS ADDUPDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ADDUPDTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    // --- DEL m.suzuki 2011/04/21 ---------->>>>>
                    //sqlText += "  AND ADDUPDTL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    // --- DEL m.suzuki 2011/04/21 ----------<<<<<
                    sqlText += "  AND ADDUPDTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND ADDUPDTL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                    # endregion

                    SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // --- DEL m.suzuki 2011/04/21 ---------->>>>>
                    //SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    // --- DEL m.suzuki 2011/04/21 ----------<<<<<
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                    SqlDataReader myReader = null;

                    foreach (object item in DetailWorks)
                    {
                        SalesDetailWork dtlWork = item as SalesDetailWork;

                        if (dtlWork != null)
                        {
                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlWork.EnterpriseCode);
                            // --- DEL m.suzuki 2011/04/21 ---------->>>>>
                            //findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                            // --- DEL m.suzuki 2011/04/21 ----------<<<<<
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dtlWork.AcptAnOdrStatusSrc);
                            findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlWork.SalesSlipDtlNumSrc);

                            # region [SQL DEBUG]
#if DEBUG
                            Console.Clear();
                            Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                            # endregion

                            try
                            {
                                myReader = sqlCommand.ExecuteReader();

                                while (myReader.Read())
                                {
                                    //伝票明細をセット
                                    //AddUpDetailWorks.Add(AddUpOrgSalesDetailReadResultPut(myReader));  //DEL 2009/01/30 M.Kuboat
                                    //--- ADD 2009/01/30 M.Kubota --->>>
                                    AddUpOrgSalesDetailWork addUpOrgDtl = AddUpOrgSalesDetailReadResultPut(myReader);
                                    addUpOrgDtl.DtlRelationGuid = dtlWork.DtlRelationGuid;  // 明細関連付けGUIDをコピーしておく
                                    AddUpDetailWorks.Add(addUpOrgDtl);
                                    //--- ADD 2009/01/30 M.Kubota ---<<<
                                }
                            }
                            finally
                            {
                                if (myReader != null)
                                {
                                    if (!myReader.IsClosed)
                                    {
                                        myReader.Close();
                                    }
                                    myReader.Dispose();
                                    myReader = null;
                                }
                            }
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch(SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch(Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
            }

            if (AddUpDetailWorks.Count <= 0)
            {
                AddUpDetailWorks = null;
            }

            return status;
        }
        # endregion

        # region [計上元売上明細データ 受注残数更新メソッド]
        /// <summary>
        /// パラメータにより指定された売上明細データに紐付く、計上元の売上明細データの受注残数を更新(増減)する。
        /// </summary>
        /// <param name="salesSlipWork">計上先の売上データ</param>
        /// <param name="salesdetailworkList">計上先の売上明細データリスト</param>
        /// <param name="slpdtladdinfList">計上元の伝票明細追加情報リスト</param>
        /// <param name="mode">0:伝票作成　1:伝票削除</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        private int UpdateAcptAnOdrRemainCnt(SalesSlipWork salesSlipWork, ArrayList salesdetailworkList, ArrayList slpdtladdinfList, int mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (salesdetailworkList != null && salesdetailworkList.Count > 0)
            {
                SqlCommand sqlCommand = null;
                SqlDataReader myReader = null;

                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();

                try
                {
                    foreach (object item in salesdetailworkList)
                    {
                        SalesDetailWork dtlwork = item as SalesDetailWork;

                        // 受注ステータスが 20:受注,30:売上,40:出荷 で、且つ計上元の受注ステータス及び売上明細通番が
                        // 設定されている場合にのみ計上元の受注残数を更新する。
                        if ( (dtlwork != null) &&
                             (dtlwork.AcptAnOdrStatus == 20 || dtlwork.AcptAnOdrStatus == 30 || dtlwork.AcptAnOdrStatus == 40) &&
                             (dtlwork.AcptAnOdrStatusSrc > 0 && dtlwork.SalesSlipDtlNumSrc > 0) )
                        {
                            # region [計上元受注残数取得SQL文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.ACPTANODRREMAINCNTRF" + Environment.NewLine;  // 受注残数 
                            sqlText += " ,DTL.REMAINCNTUPDDATERF" + Environment.NewLine;    // 残数更新日
                            //sqlText += " ,DTL.CONTRACTDIVCDDTLRF" + Environment.NewLine;  // 契約区分
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SALESDETAILRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DTL.SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                            # endregion
                                                     
                            # region [各種パラメータの定義と設定]
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);                          // 企業コード
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);  // 論理削除
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dtlwork.AcptAnOdrStatusSrc);                      // 受注ステータス(元)
                            findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.SalesSlipDtlNumSrc);                      // 受注明細通番(元)
                            # endregion

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                # region [計上元受注残数更新SQL文]
                                sqlText = "";
                                sqlText += "UPDATE" + Environment.NewLine;
                                sqlText += "  SALESDETAILRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,ACPTANODRREMAINCNTRF = @ACPTANODRREMAINCNT" + Environment.NewLine;
                                sqlText += " ,REMAINCNTUPDDATERF = @REMAINCNTUPDDATE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND SALESSLIPDTLNUMRF = @FINDSALESSLIPDTLNUM" + Environment.NewLine;
                                sqlCommand.CommandText = sqlText;
                                # endregion

                                # region [各種パラメータの定義と設定]
                                SalesDetailWork updDtlWork = new SalesDetailWork();

                                updDtlWork.EnterpriseCode = dtlwork.EnterpriseCode;       // 企業コード
                                updDtlWork.AcptAnOdrStatus = dtlwork.AcptAnOdrStatusSrc;  // 受注ステータス ← 受注ステータス(元)
                                updDtlWork.SalesSlipDtlNum = dtlwork.SalesSlipDtlNumSrc;  // 売上明細通番 ← 売上明細通番(元)

                                // 売上明細データに紐付く伝票追加情報を取得する
                                SlipDetailAddInfoWork addInfWork = null;
                                try
                                {
                                    int addInfIdx = slpdtladdinfList.BinarySearch(dtlwork.DtlRelationGuid, DtlRelationGuidComp);
                                    addInfWork = slpdtladdinfList[addInfIdx] as SlipDetailAddInfoWork;
                                }
                                catch
                                {
                                    // 削除の場合は伝票明細追加情報は無いので黙殺
                                    addInfWork = null;
                                }

                                bool AddUpRemDiv = false;  // false: 残数を残す　true:残数を残さない

                                // 計上残区分は伝票作成時にのみ有効とする
                                // 2009/12/28
                                //if (mode == 0)  //ADD 2009/01/30 M.Kubota
                                //{
                                // 2009/12/28
                                    // 売上全体設定マスタの設定状況を確認
                                    if ((updDtlWork.AcptAnOdrStatus == 10 && this.IOWriteCtrlOptWork.EstimateAddUpRemDiv == 1) ||
                                        (updDtlWork.AcptAnOdrStatus == 20 && this.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv == 1) ||
                                        (updDtlWork.AcptAnOdrStatus == 40 && this.IOWriteCtrlOptWork.ShipmAddUpRemDiv == 1))
                                    {
                                        // 計上元が
                                        // (10:見積 で且つ見積データ計上残区分が 1:残さない) 又は
                                        // (20:受注 で且つ受注データ計上残区分が 1:残さない) 又は
                                        // (40:出荷 で且つ出荷データ計上残区分が 1:残さない) の場合は、
                                        // 更新する受注残数を強制的に 0 にする
                                        AddUpRemDiv = true;
                                    }

                                    if (addInfWork != null)
                                    {
                                        switch (addInfWork.AddUpRemDiv)
                                        {
                                            case 1: AddUpRemDiv = false; break;
                                            case 2: AddUpRemDiv = true; break;
                                        }
                                    }
                                //} // 2009/12/28

                                if (AddUpRemDiv) 
                                {
                                    updDtlWork.AcptAnOdrRemainCnt = 0;
                                }
                                else
                                {
                                    // 計上元受注残数－計上先出荷差分数＝新しい計上元受注残数
                                    double wrkAcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                                    //wrkAcptAnOdrRemainCnt -= (mode == 0 ? 1 : -1) * (salesSlipWork.DebitNoteDiv == 1 ? -1 : 1) * (salesSlipWork.SalesSlipCd == 1 ? -1 : 1) * dtlwork.ShipmCntDifference;  // DEL 2010/10/08
                                    // -- ADD 2010/10/08 ------------------------------------>>>
                                    // 得意先電子元帳で掛売で赤伝発行した場合に返品可能数が増える現象の修正。条件の追加
                                    wrkAcptAnOdrRemainCnt -= (mode == 0 ? 1 : -1)
                                                              * (salesSlipWork.DebitNoteDiv == 1 ? -1 : 1)
                                                              * (salesSlipWork.SalesSlipCd == 1 ? -1 : 1)
                                                              * ((dtlwork.AcptAnOdrStatusSrc == 30 && dtlwork.AcptAnOdrStatus == 30 && salesSlipWork.SalesSlipCd != 1 && salesSlipWork.DebitNoteDiv != 1) ? -1 : 1)  // ADD
                                                              * dtlwork.ShipmCntDifference;
                                    // -- ADD 2010/10/08 ------------------------------------<<<
                                    wrkAcptAnOdrRemainCnt = CalculateConsTax.Fraction(wrkAcptAnOdrRemainCnt, -32);  // 少数第三桁を四捨五入
                                    updDtlWork.AcptAnOdrRemainCnt = wrkAcptAnOdrRemainCnt;
                                }

                                // 計上出荷差分数が 0 でない場合は、受注残数の変更とみなして残数更新日を設定する
                                if (dtlwork.ShipmCntDifference != 0)
                                {
                                    updDtlWork.RemainCntUpdDate = DateTime.Now;
                                }
                                else
                                {
                                    updDtlWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
                                }

                                // 更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)updDtlWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                sqlCommand.Parameters.Clear();
                                findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                                findSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraAcptAnOdrRemainCnt = sqlCommand.Parameters.Add("@ACPTANODRREMAINCNT", SqlDbType.Float);
                                SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);

                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updDtlWork.EnterpriseCode);                    // 企業コード
                                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(updDtlWork.AcptAnOdrStatus);                   // 受注ステータス
                                findSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(updDtlWork.SalesSlipDtlNum);                   // 売上明細通番
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updDtlWork.UpdateDateTime);         // 更新日付
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdEmployeeCode);                  // 更新従業員コード
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdAssemblyId1);                    // 更新アセンブリID1
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdAssemblyId2);                    // 更新アセンブリID2
                                paraAcptAnOdrRemainCnt.Value = SqlDataMediator.SqlSetDouble(updDtlWork.AcptAnOdrRemainCnt);            // 受注残数
                                paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(updDtlWork.RemainCntUpdDate);  // 残数更新日
                                # endregion

                                myReader.Close();
                                myReader.Dispose();
                                myReader = null;

                                sqlCommand.ExecuteNonQuery();
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                            else
                            {
                                // 該当データが無くてもCloseする
                                myReader.Close();
                                myReader.Dispose();
                                myReader = null;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader.Dispose();
                    }
                    
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }

            return status;
        }
        # endregion
    }

    //--- ADD 2008/06/06 M.Kubota --->>>
    /// <summary>
    /// 
    /// </summary>
    public class AcceptOdrCarReader
    {
        private AcceptOdrCarDB _acceptOdrCarDB = null;

        /// <summary>
        /// 受注マスタ(車両)リモート プロパティ
        /// </summary>
        private AcceptOdrCarDB AcptOdrCarDB
        {
            get
            {
                if (this._acceptOdrCarDB == null)
                {
                    this._acceptOdrCarDB = new AcceptOdrCarDB();
                }

                return this._acceptOdrCarDB;
            }
        }

        # region [読込処理]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acpOdrCarList"></param>
        /// <param name="slsDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int ReadWithSalesDetail(out ArrayList acpOdrCarList, ArrayList slsDtlList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadWithSalesDetailProc(out acpOdrCarList, slsDtlList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acpOdrCarList"></param>
        /// <param name="slsDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int ReadWithSalesDetailProc(out ArrayList acpOdrCarList, ArrayList slsDtlList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            acpOdrCarList = new ArrayList();

            ArrayList acpOdrCarWrkList = new ArrayList();
            AcceptOdrCarComparer acpOdrCarComp = new AcceptOdrCarComparer();

            // 売上明細を集計し、重複しない受注マスタ(車両)データの抽出条件を作成する
            if (slsDtlList != null && slsDtlList.Count > 0 && slsDtlList[0] is SalesDetailWork)
            {
                foreach (SalesDetailWork slsDtlWrk in slsDtlList)
                {
                    AcceptOdrCarWork acpOdrCarWrk = new AcceptOdrCarWork();

                    acpOdrCarWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;

                    // 受注マスタ(車両)と売上データの"受注ステータス"に登録されている値は異なる
                    switch (slsDtlWrk.AcptAnOdrStatus)
                    {
                        case 10:  // 見積
                            {
                                acpOdrCarWrk.AcptAnOdrStatus = 1;
                                break;
                            }
                        case 20:  // 受注
                            {
                                acpOdrCarWrk.AcptAnOdrStatus = 3;
                                break;
                            }
                        case 30:  // 売上
                            {
                                acpOdrCarWrk.AcptAnOdrStatus = 7;
                                break;
                            }
                        case 40:  // 出荷
                            {
                                acpOdrCarWrk.AcptAnOdrStatus = 5;
                                break;
                            }
                    }

                    acpOdrCarWrk.AcceptAnOrderNo = slsDtlWrk.AcceptAnOrderNo;
                    acpOdrCarWrk.DataInputSystem = (int)DataInputSystem.PM;

                    acpOdrCarWrkList.Sort(acpOdrCarComp);
                    int pos = acpOdrCarWrkList.BinarySearch(acpOdrCarWrk, acpOdrCarComp);

                    if (pos < 0)
                    {
                        acpOdrCarWrkList.Add(acpOdrCarWrk);
                    }
                }
            }

            if (acpOdrCarWrkList.Count > 0)
            {
                foreach (AcceptOdrCarWork acpOdrCarWrk in acpOdrCarWrkList)
                {
                    AcceptOdrCarWork AcpOdrCarTmp = acpOdrCarWrk;

                    status = this.AcptOdrCarDB.Read(ref AcpOdrCarTmp, 0, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                        status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // 検索結果を格納する
                        acpOdrCarList.Add(AcpOdrCarTmp);
                    }
                    else
                    {
                        // 検索に失敗した場合は、それまでの検索を全て破棄する
                        acpOdrCarList.Clear();
                        break;
                    }
                }

                if (ListUtils.IsNotEmpty(acpOdrCarList))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }
        # endregion

    }
    //--- ADD 2008/06/06 M.Kubota ---<<<

}