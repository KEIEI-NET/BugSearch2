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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
// --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 ----->>>>>
using System.IO;
using System.Threading;
// --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 -----<<<<<
//■─ファイルレイアウト変更時の修正について…────────────────────────■
//　ファイルレイアウトに変更があった場合は以下の文字列を頼りに修正を行って下さい。
//　　仕入データ　　 → ＠仕入データ変更＠
//　　仕入明細データ → ＠仕入明細データ変更＠
//■─────────────────────────────────────────────■
/// <br>--------------------------------------</br>
/// <br>Note             :   連番966 仕入明細マスタの同時売上情報をクリアする。</br>
/// <br>Programmer       :   許雁波</br>
/// <br>Date             :   2011/08/16</br>

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.26</br>
    /// <br></br>
    /// <br>Update Note: 拠点制御設定マスタより仕入拠点コード抽出</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.20</br>
    /// <br></br>
    /// <br>Update Note: 赤伝削除の場合　元黒伝→黒伝</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.24</br>
    /// <br></br>
    /// <br>Update Note: DC.NS用に修正</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.11</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に修正</br>
    /// <br>           : 継承元を RemoteDB から RemoteWithAppLockDB に変更</br>
    /// <br>           : 相手先伝票番号を元に仕入データを検索するメソッドの追加</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.05.30</br>
    /// <br></br>
    /// <br>Update Note: UOEWEB e-Parts対応</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2009.05.28</br>
    /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED対応</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/06/11</br>
    /// <br></br>
    /// <br>Update Note: 売仕入同時入力の伝票を得意先電子元帳にて、掛売で赤伝発行した場合の仕入明細の残数が増える現象の修正</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/10/08</br>
    /// <br>Update Note: 2011/08/12 wangf</br>
    /// <br>             NSユーザー改良要望一覧_20110629_障害_連番1023対応</br>
    /// <br></br>
    /// <br>Update Note: 送信済みのチェック方法を追加</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2011/07/27</br>
    /// <br></br>
    /// <br>Update Note:   仕入データ、仕入明細取得方法を追加</br>
    /// <br>Programmer :   張莉莉</br>
    /// <br>Date       :   2011/08/17</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に修正（SCM管理）</br>
    /// <br>           : SqlReader使用に修正</br>
    /// <br>Programmer : 孫東響</br>
    /// <br>Date       : 2011.08.24</br>
    /// <br></br>
    /// <br>Update Note: 2011/10/08 tianjw</br>
    /// <br>             Redmine#25779 仕入伝票入力　送信済みチェックについて</br>
    /// <br></br>
    /// <br>Update Note: 売上仕入同時入力の売上データ削除時、仕入明細通番の型不正が発生する不具合の修正</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2011/10/14</br>
    /// <br></br>
    /// <br>Update Note: redmine#26228 拠点管理改良／伝票日付による抽出対応</br>
    /// <br>Programmer : xupz</br>
    /// <br>Date       : 2011.11.10</br>
    /// <br>Update Note: redmine#26228 拠点管理改良／伝票日付による抽出対応</br>
    /// <br>Programmer : xupz</br>
    /// <br>Date       : 2011.11.14</br>
    /// <br>Update Note: 2011/12/15 tianjw</br>
    /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note: 2012/02/06 田建委</br>
    /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
    /// <br>             Redmine#28288 送信済データ修正制御の対応</br>
    /// <br></br>
    /// <br>Update Note: 拠点管理 送信済データチェック不具合対応</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/08/10</br>
    /// <br></br>
    /// <br>Update Note: 売上仕入同時入力で売上伝票を別々で入力し仕入伝票番号を同一で作成し、</br>
    /// <br>             作成した売上伝票の片方を伝票削除した場合、仕入伝票が呼び出せなくなる件の修正</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/11/30</br>
    /// <br></br>
    /// <br>Update Note: 売上仕入同時入力での仕入データ更新の不具合対応</br>
    /// <br>Programmer : 宮本 利明</br>
    /// <br>Date       : 2012/12/14</br>
    /// <br></br>
    /// <br>Update Note: 仕入返品予定機能追加に伴う修正</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/02/13</br>
    /// <br></br>
    /// <br>Update Note: 2015/09/10　周健</br>
    /// <br>             Redmine#47298　MKアシスト　仕入チェック処理</br>
    /// <br>Update Note: 2015/12/14 李侠</br>
    /// <br>管理番号   : 11175418-00</br>
    /// <br>           : Redmine#48098 売仕入同時入力SEQが異なる障害対応</br>
    /// <br>Update Note: 2021/04/08 佐々木亘</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>             タイムアウト設定追加</br>
    /// <br>Update Note: 2021/06/09 呉元嘯</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>             PMKOBETSU-4144 デッドロック対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    //public class StockSlipDB : RemoteWithAppLockDB, IStockSlipDB, IFunctionCallTargetRead, IFunctionCallTargetWrite, IFunctionCallTargetNewEntry, IFunctionCallTargetRedBlackWrite
    public class StockSlipDB : RemoteWithAppLockDB, IStockSlipDB, IFunctionCallTargetRead, IFunctionCallTargetWrite, IFunctionCallTargetRedBlackWrite
    {
        // --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 ----->>>>>
        // リトライ回数-デフォルト：5回
        private const int RETRY_COUNT_DEFAULT = 5;
        // リトライ間隔-デフォルト：60秒
        private const int RETRY_INTERVAL_DEFAULT = 60;
        // ログ出力PGID
        private string CURRENT_PGID = "MAKON01824R";
        // エラーメッセージ
        private string ERR_MEG = "SearchPartySaleSlipNumProcReTryデッドロック発生 リトライ回数：{0}回目";
        // デッドロック1205
        private const int DEAD_LOCK_VALUE = 1205;
        // 定数(0)
        private const int ZERO_VALUE = 0;
        // --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 -----<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.06
        /// <summary>
        /// 売上・仕入制御オプションワーク
        /// </summary>
        private IOWriteCtrlOptWork _ctrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプションワーク　プロパティ
        /// </summary>
        public IOWriteCtrlOptWork IOWriteCtrlOptWork
        {
            get
            {
                if ( _ctrlOptWork == null )
                {
                    _ctrlOptWork = new IOWriteCtrlOptWork();
                }
                return _ctrlOptWork;
            }
            set
            {
                _ctrlOptWork = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.06

        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
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
        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        /// <summary>
		/// 仕入データDBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2006.12.26</br>
		/// </remarks>
        public StockSlipDB()
            :
            base("MAKON01826D", "Broadleaf.Application.Remoting.ParamData.StockSlipWork", "STOCKSLIPRF")
		{
        }

        #region [NewEntry  DC.NSの段階から仕様していないので一時的に削除]
#if false
        /// <summary>
        /// 仕入データの初期項目を読込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データの初期項目を読込みます</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.17</br>
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

                StockSlipNewEntryWork stockSlipNewEntryWork = null;
                StockSlipWork stockSlipWork = null;
                Int32 listPos_StockSlipWork = -1;

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
                else if (paraList.Count > 0) stockSlipNewEntryWork = paraList[position] as StockSlipNewEntryWork;
                if (stockSlipNewEntryWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。受注NewEntry結果が取得出来ません");
                    return status;
                }

                //●仕入NewEntry結果取得
                //●伝票更新List内の仕入データクラスを抽出
                stockSlipWork = MakeStockSlipWork(retList, out listPos_StockSlipWork);
                if (stockSlipWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。更新対象仕入オブジェクトパラメータが未指定です。");
                    return status;
                }

                //●顧客情報をクリア
                //ClearCarCustomerInfo(ref stockSlipWork, true, true);

                //●パラメータの内容によって処理分け
                //請求先コードが入っていたら請求先情報を読み込み
                //if (stockSlipNewEntryWork.CustomerCode != 0) status = ReadCustomerInfo(ref stockSlipWork, stockSlipNewEntryWork.EnterpriseCode, stockSlipNewEntryWork.CustomerCode, acceptOdrWork, ref sqlConnection);
                //パラメータが何も無ければ無条件で正常戻り値
                //else status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //●初期処理結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList[position] = stockSlipNewEntryWork;
                    retList.Add(stockSlipWork);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSlipDB.NewEntry:" + ex.Message);
            }

            return status;
        }
#endif
        #endregion

        #region [Read]　読込処理　ヘッダ・明細・詳細
        /// <summary>
        /// 仕入データを読込みます
        /// </summary>
        /// <param name="origin">呼び出し元</param>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="param">構成ファイルパラメータ</param>
        /// <param name="freeParam">自由パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データを読込みます</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.26</br>
        public int Read(string origin, ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, string param, ref object freeParam, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象オブジェクトパラメータが未指定です", status);
                    return status;
                }

                //●読込パラメータ
                StockSlipReadWork stockSlipReadWork = null;

                //●読込結果格納用
                StockSlipWork stockSlipWork = null;
                ArrayList stockDetailWorks = null;
                ArrayList addUppOrgStockDetailWorks = null;  //ADD 2007/09/11 M.Kubota
                //ArrayList stockExplaDataWorks = null;  //DEL 2007/09/11 M.Kubota
                //ArrayList slipMemoWorks = null;  //ADD 2007/09/11 M.Kubota

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                    return status;
                }

                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (paraList == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象パラメータListが未指定です", status);
                    return status;
                }
                else if (paraList.Count > 0) stockSlipReadWork = paraList[position] as StockSlipReadWork;
                if (stockSlipReadWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象オブジェクトパラメータが未指定です", status);
                    return status;
                }

                //●仕入Read
                status = ReadStockSlipWork(out stockSlipWork, stockSlipReadWork, ref sqlConnection);

                //●仕入明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = ReadStockDetailWork(out stockDetailWorks, stockSlipReadWork, ref sqlConnection);

                //-- ADD 2007/09/11 M.Kubota --->>>
                //●計上元仕入明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    SqlTransaction sqlTransaction = null;
                    status = ReadAddUpStockDetailWork(out addUppOrgStockDetailWorks, stockDetailWorks, ref sqlConnection, ref sqlTransaction);
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<

                /*--- DEL 2007/09/11 M.Kubota --->>>
                //●仕入詳細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = ReadStockExplaDataWork(out stockExplaDataWorks, stockSlipReadWork, ref sqlConnection);
                  --- DEL 2007/09/11 M.Kubota ---<<<*/

                //●読込結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retList.Add(stockSlipWork);

                    if (stockDetailWorks != null)
                        retList.Add(stockDetailWorks);

                    /*--- DEL 2007/09/11 M.Kubota --->>>
                    if (stockExplaDataWorks != null)
                        retList.Add(stockExplaDataWorks);
                      --- DEL 2007/09/11 M.Kubota ---<<<*/

                    //--- ADD 2007/09/11 M.Kubota --->>>
                    /*                                                          
                    if (slipMemoWorks != null)
                        retList.Add(slipMemoWorks);
                    */
                    //--- ADD 2007/09/11 M.Kubota ---<<<

                    //--- ADD 2007/09/11 M.Kubota --->>>
                    if (addUppOrgStockDetailWorks != null && addUppOrgStockDetailWorks.Count > 0)
                    {
                        // 計上元 仕入明細データをセット
                        retList.Add(addUppOrgStockDetailWorks);
                    }
                    //--- ADD 2007/09/11 M.Kubota ---<<<

                    paraList[position] = stockSlipReadWork;
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入データを戻します
        /// </summary>
        /// <param name="stockSlipWork">読込結果</param>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの仕入データを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        public int ReadStockSlipWork(out StockSlipWork stockSlipWork, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];

            return ReadStockSlipWork(out stockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

		// ADD 2011/08/17 張莉莉 SCM対応 - 拠点管理(10704767-00) --------->>>>>
	　　/// <summary>
		/// 仕入データを取得(論理削除データを含む)
        /// </summary>
		/// <param name="stockSlipWork">読込結果</param>
		/// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
		public int ReadStockSlipWorkIgnoreDel(out StockSlipWork stockSlipWork, StockSlipReadWork stockSlipReadWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			stockSlipWork = null;

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
					sqlText.Append("  STOCKSLIPRF AS SLIP WITH (READUNCOMMITTED)").Append(Environment.NewLine);
					sqlText.Append("WHERE").Append(Environment.NewLine);
					sqlText.Append("  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
					sqlText.Append("  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL").Append(Environment.NewLine);
					sqlText.Append("  AND SLIP.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO").Append(Environment.NewLine);
					sqlCommand.CommandText = sqlText.ToString();

					//Prameterオブジェクトの作成
					SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
					SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);
					findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
					findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);

					try
					{
						myReader = sqlCommand.ExecuteReader();
						if (myReader.Read())
						{
							stockSlipWork = StockSlipReadResultPut(myReader);
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
		// ADD 2011/08/17 張莉莉 SCM対応 - 拠点管理(10704767-00) ---------<<<<<

        /// <summary>
        /// 指定された企業コードの仕入データを戻します
        /// </summary>
        /// <param name="stockSlipWork">読込結果</param>
        /// <param name="copyStockSlipWork">読込結果コピー情報</param>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの仕入データを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        private int ReadStockSlipWork(out StockSlipWork stockSlipWork, ref StockSlipWork[] copyStockSlipWork, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadStockSlipWork(out stockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの仕入データを戻します
        /// </summary>
        /// <param name="stockSlipWork">読込結果</param>
        /// <param name="copyStockSlipWork">読込結果コピー情報</param>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの仕入データを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        private int ReadStockSlipWork(out StockSlipWork stockSlipWork, ref StockSlipWork[] copyStockSlipWork, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            stockSlipWork = new StockSlipWork();

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
                    // -- UPD 2010/06/11 --------------------------------->>>
                    //sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                    sqlText += "  STOCKSLIPRF AS SLIP WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 ---------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND SLIP.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            stockSlipWork = StockSlipReadResultPut(myReader);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //コピー配列数分コピーリード
                                for (int i = 0; i < copyStockSlipWork.Length; i++)
                                {
                                    copyStockSlipWork[i] = StockSlipReadResultPut(myReader);
                                }
                            }

                            //--- DEL 2008/06/02 M.Kubota --->>>
                            // 在庫更新拠点コードを取得する
                            //StockSlipWork dummy = null;
                            //myReader.Close();
                            //status = this.SearchStockSecCd(ref stockSlipWork, ref dummy, ref sqlConnection, ref sqlTransaction);

                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //    //コピー配列数分コピーリード
                            //    for (int i = 0; i < copyStockSlipWork.Length; i++)
                            //    {
                            //        copyStockSlipWork[i].StockUpdateSecCd = stockSlipWork.StockUpdateSecCd;
                            //    }
                            //}
                            //--- DEL 2008/06/02 M.Kubota ---<<<

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

        /// <summary>
        /// 仕入読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
        private StockSlipWork StockSlipReadResultPut(SqlDataReader myReader)
        {
            //＠仕入データ変更＠
            StockSlipWork wkStockSlipWork = new StockSlipWork();

            #region 仕入ワーククラスへ代入　※レイアウト変更時対応必須
            wkStockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            wkStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            wkStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            wkStockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
            wkStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockSlipWork.PreStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF")); // ADD 2011/12/21
            wkStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            wkStockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            wkStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkStockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkStockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkStockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            wkStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            wkStockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
            wkStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
            wkStockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
            wkStockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            wkStockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
            wkStockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            wkStockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            wkStockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
            wkStockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
            wkStockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
            wkStockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            wkStockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkStockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkStockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            wkStockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
            wkStockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
            wkStockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
            wkStockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
            wkStockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            wkStockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            wkStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            wkStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            wkStockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            wkStockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            wkStockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            wkStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkStockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
            wkStockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            wkStockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            wkStockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            wkStockSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            wkStockSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            wkStockSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            wkStockSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            wkStockSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            wkStockSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            wkStockSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            wkStockSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            wkStockSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            wkStockSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            wkStockSlipWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
            #endregion

            return wkStockSlipWork;
        }

        /// <summary>
        /// 指定された企業コードの仕入明細データLISTを全て戻します
        /// </summary>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの明細情報を全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        private int ReadStockDetailWork(out ArrayList stockDetailWorks, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            ArrayList[] copyStockDetailWorks = new ArrayList[0];
            return ReadStockDetailWork(out stockDetailWorks, ref copyStockDetailWorks, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの仕入明細データLISTを全て戻します
        /// </summary>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="copyStockDetailWorks">コピー情報</param>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの仕入明細データを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        private int ReadStockDetailWork(out ArrayList stockDetailWorks, ref ArrayList[] copyStockDetailWorks, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadStockDetailWork(out stockDetailWorks, ref copyStockDetailWorks, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された企業コードの仕入明細データLISTを全て戻します
        /// </summary>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="copyStockDetailWorks">読込結果コピー</param>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの明細データを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.27</br>
        private int ReadStockDetailWork(out ArrayList stockDetailWorks, ref ArrayList[] copyStockDetailWorks, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            //戻り値用ArrayListを生成
            ArrayList al = new ArrayList();
            //コピー指定数分ArrayList生成
            for (int ii = 0; ii < copyStockDetailWorks.Length; ii++) copyStockDetailWorks[ii] = new ArrayList();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 --------------------------------->>>
                    //sqlText += "  STOCKDETAILRF AS DTIL" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 ---------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //伝票明細をセット
                            StockDetailWork wkStockDetailWork = StockDetailReadResultPut(ref myReader);
                            al.Add(wkStockDetailWork);

                            //コピー指定数分コピー
                            for (int i = 0; i < copyStockDetailWorks.Length; i++) copyStockDetailWorks[i].Add(StockDetailReadResultPut(ref myReader));

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

            stockDetailWorks = al;

            if (stockDetailWorks.Count == 0)
            {
                stockDetailWorks = null;
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        # region [ReadDetail] 仕入明細読込

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int ReadStockDetailWork(ref object paraList, ref object retList)
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
                    base.WriteErrorLog(errmsg + ": パラメータが未設定です", status);
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

                SqlConnection sqlConnection = null;

                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                if (connectionText == null || connectionText == "")
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                SqlTransaction sqlTransaction = null;
                ArrayList retDtlArray = new ArrayList();

                status = this.ReadStockDetailWork(out retDtlArray, paramArray, ref sqlConnection, ref sqlTransaction);

                // 戻り値を設定
                (retList as CustomSerializeArrayList).AddRange(retDtlArray);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        # endregion

        /// <summary>
        /// 指定された仕入明細通番を持つ仕入明細データLISTを全て戻します
        /// </summary>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="parastockDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入明細通番を持つ仕入明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.28</br>
        public int ReadStockDetailWork(out ArrayList stockDetailWorks, ArrayList parastockDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockDetailWorkProc(out stockDetailWorks, parastockDetailWorks, ref sqlConnection, ref sqlTransaction);
        }

		// ADD 2011/08/17 張莉莉 SCM対応 - 拠点管理(10704767-00) --------->>>>>
		/// <summary>
		/// 仕入明細リストを取得(論理削除を含む)
		/// </summary>
		/// <param name="readResult">明細読込結果</param>
		/// <param name="parastockDetailWorks">読込パラメータ</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		public int ReadStockDetailWorkIgnoreDel(out ArrayList stockDetailWorks, ArrayList parastockDetailWorks, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			ArrayList retList = new ArrayList();
			stockDetailWorks = null;
			if (parastockDetailWorks == null || parastockDetailWorks.Count == 0)
			{
				return status;
			}
			SqlDataReader myReader = null;

			bool disposeConnection = false;
			bool disposeTransaction = false;

			if (parastockDetailWorks != null && parastockDetailWorks.Count > 0)
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

						SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
						string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

						if (connectionText == null || connectionText == "")
						{
							stockDetailWorks = retList;
							return (int)ConstantManagement.DB_Status.ctDB_ERROR;
						}

						sqlConnection = new SqlConnection(connectionText);
					}

					if (sqlConnection.State == ConnectionState.Closed)
					{
						sqlConnection.Open();
					}

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
						sqlText.Append("  STOCKDETAILRF AS DTIL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
						sqlText.Append("WHERE").Append(Environment.NewLine);
						sqlText.Append("  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText.Append("  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL").Append(Environment.NewLine);
						sqlText.Append("  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO").Append(Environment.NewLine);
						# endregion

						sqlCommand.CommandText = sqlText.ToString();

						//Prameterオブジェクトの作成
						SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NVarChar);
						SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
						SqlParameter findStockSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.BigInt);


						StockDetailWork paraDtlWork = parastockDetailWorks[0] as StockDetailWork;

						if (paraDtlWork != null)
						{
							//Parameterオブジェクトへ値設定
							findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraDtlWork.EnterpriseCode);
							findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paraDtlWork.SupplierFormal);
							findStockSlipNo.Value = SqlDataMediator.SqlSetInt64(paraDtlWork.SupplierSlipNo);

							try
							{
								myReader = sqlCommand.ExecuteReader();

								while (myReader.Read())
								{
									//伝票明細をセット
									retList.Add(StockDetailReadResultPut(ref myReader));
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
				}
				catch (SqlException ex)
				{
					string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
					status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
					return (int)ConstantManagement.DB_Status.ctDB_ERROR;
				}
				catch (Exception ex)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
					base.WriteErrorLog(ex, errmsg, status);
					return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

			stockDetailWorks = retList;

			if (stockDetailWorks.Count > 0)
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			return status;
		}
		// ADD 2011/08/17 張莉莉 SCM対応 - 拠点管理(10704767-00) ---------<<<<<

        /// <summary>
        /// 指定された仕入明細通番を持つ仕入明細データLISTを全て戻します
        /// </summary>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="parastockDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入明細通番を持つ仕入明細データを全て戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.28</br>
        private int ReadStockDetailWorkProc(out ArrayList stockDetailWorks, ArrayList parastockDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList retList = new ArrayList();

            bool disposeConnection = false;
            bool disposeTransaction = false;

            if (parastockDetailWorks != null && parastockDetailWorks.Count > 0)
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

                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                        if (connectionText == null || connectionText == "")
                        {
                            stockDetailWorks = retList;
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        sqlConnection = new SqlConnection(connectionText);
                    }

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

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
                        // -- UPD 2010/06/11 --------------------------------------->>>
                        //sqlText += "  STOCKDETAILRF AS DTIL" + Environment.NewLine;
                        sqlText += "  STOCKDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                        // -- UPD 2010/06/11 ---------------------------------------<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NVarChar);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        foreach (Object paraObj in parastockDetailWorks)
                        {
                            StockDetailWork paraDtlWork = paraObj as StockDetailWork;

                            if (paraDtlWork != null)
                            {
                                //Parameterオブジェクトへ値設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraDtlWork.EnterpriseCode);
                                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paraDtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(paraDtlWork.StockSlipDtlNum);

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        //伝票明細をセット
                                        retList.Add(StockDetailReadResultPut(ref myReader));
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

            stockDetailWorks = retList;

            if (stockDetailWorks.Count > 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 仕入明細読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        private StockDetailWork StockDetailReadResultPut(ref SqlDataReader myReader)
        {
            StockDetailWork dtlwork = new StockDetailWork();

            this.StockDetailReadResultPut(ref dtlwork, myReader);

            return dtlwork;
        }

        /// <summary>
        /// 仕入明細読込結果クラス出力処理
        /// </summary>
        /// <param name="dtlwork">出力クラス</param>
        /// <param name="myReader">読込結果</param>
        private void StockDetailReadResultPut(ref StockDetailWork dtlwork, SqlDataReader myReader)
        {
            //＠仕入明細データ変更＠
            //dtlwork.<#FieldName> = SqlDataMediator.<#sqlDbTypeGetAccessor>(myReader,myReader.GetOrdinal("<#FIELDRfield.Name>"));  // <#name>
            #region 仕入明細ワーククラスへ代入　※レイアウト変更時対応必須
            dtlwork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));               // 作成日時
            dtlwork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));               // 更新日時
            dtlwork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                          // 企業コード
            dtlwork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                            // GUID
            dtlwork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                        // 更新従業員コード
            dtlwork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                          // 更新アセンブリID1
            dtlwork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                          // 更新アセンブリID2
            dtlwork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                     // 論理削除区分
            dtlwork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));                         // 受注番号
            dtlwork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                           // 仕入形式
            dtlwork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                           // 仕入伝票番号
            dtlwork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));                                   // 仕入行番号
            dtlwork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                                // 拠点コード
            dtlwork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                           // 部門コード
            dtlwork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));                                 // 共通通番
            dtlwork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));                         // 仕入明細通番
            dtlwork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));                     // 仕入形式（元）
            dtlwork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));                   // 仕入明細通番（元）
            dtlwork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));                 // 受注ステータス（同時）
            dtlwork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));                 // 売上明細通番（同時）
            dtlwork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));                           // 仕入伝票区分（明細）
            dtlwork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));                          // 仕入入力者コード
            dtlwork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));                          // 仕入入力者名称
            dtlwork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));                          // 仕入担当者コード
            dtlwork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));                          // 仕入担当者名称
            dtlwork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));                             // 商品属性
            dtlwork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                               // 商品メーカーコード
            dtlwork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));                                    // メーカー名称
            dtlwork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));                            // メーカーカナ名称
            dtlwork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));                  // メーカーカナ名称（一式）
            dtlwork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                                        // 商品番号
            dtlwork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                                    // 商品名称
            dtlwork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));                            // 商品名称カナ
            dtlwork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));                                 // 商品大分類コード
            dtlwork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));                        // 商品大分類名称
            dtlwork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));                                 // 商品中分類コード
            dtlwork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));                        // 商品中分類名称
            dtlwork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));                                 // BLグループコード
            dtlwork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));                                // BLグループコード名称
            dtlwork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));                                 // BL商品コード
            dtlwork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));                        // BL商品コード名称（全角）
            dtlwork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));                 // 自社分類コード
            dtlwork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));                // 自社分類名称
            dtlwork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                            // 倉庫コード
            dtlwork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));                            // 倉庫名称
            dtlwork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));                      // 倉庫棚番
            dtlwork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));                         // 仕入在庫取寄せ区分
            dtlwork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));                               // オープン価格区分
            dtlwork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));                            // 商品掛率ランク
            dtlwork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));                         // 得意先掛率グループコード
            dtlwork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));                         // 仕入先掛率グループコード
            dtlwork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));                    // 定価（税抜，浮動）
            dtlwork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));                    // 定価（税込，浮動）
            dtlwork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));                                    // 仕入率
            dtlwork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));                    // 掛率設定拠点（仕入単価）
            dtlwork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));                      // 掛率設定区分（仕入単価）
            dtlwork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));               // 単価算出区分（仕入単価）
            dtlwork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));                       // 価格区分（仕入単価）
            dtlwork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));                    // 基準単価（仕入単価）
            dtlwork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));              // 端数処理単位（仕入単価）
            dtlwork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));                     // 端数処理（仕入単価）
            dtlwork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));                      // 仕入単価（税抜，浮動）
            dtlwork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));                // 仕入単価（税込，浮動）
            dtlwork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));                       // 仕入単価変更区分
            dtlwork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));                  // 変更前仕入単価（浮動）
            dtlwork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));                                // 変更前定価
            dtlwork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));                         // BL商品コード（掛率）
            dtlwork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));                        // BL商品コード名称（掛率）
            dtlwork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));                   // 商品掛率グループコード（掛率）
            dtlwork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));                  // 商品掛率グループ名称（掛率）
            dtlwork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));                         // BLグループコード（掛率）
            dtlwork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));                        // BLグループ名称（掛率）
            dtlwork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));                                  // 仕入数
            dtlwork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));                                      // 発注数量
            dtlwork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));                          // 発注調整数
            dtlwork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));                          // 発注残数
            dtlwork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));        // 残数更新日
            dtlwork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));                       // 仕入金額（税抜き）
            dtlwork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));                       // 仕入金額（税込み）
            dtlwork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                               // 仕入商品区分
            dtlwork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));                     // 仕入金額消費税額
            dtlwork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));                               // 課税区分
            dtlwork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));                    // 仕入伝票明細備考1
            dtlwork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));                     // 販売先コード
            dtlwork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));                      // 販売先略称
            dtlwork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));                                    // 伝票メモ１
            dtlwork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));                                    // 伝票メモ２
            dtlwork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));                                    // 伝票メモ３
            dtlwork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));                                // 社内メモ１
            dtlwork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));                                // 社内メモ２
            dtlwork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));                                // 社内メモ３
            dtlwork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                   // 仕入先コード
            dtlwork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                                // 仕入先略称
            dtlwork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));                             // 納品先コード
            dtlwork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));                            // 納品先名称
            dtlwork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));                         // 直送区分
            dtlwork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                                // 発注番号
            dtlwork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));                                   // 注文方法
            dtlwork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
            dtlwork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));    // 希望納期
            dtlwork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));                   // 発注データ作成区分
            dtlwork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));  // 発注データ作成日
            dtlwork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));                   // 発注書発行済区分
            #endregion                        
        }

        /// <summary>
        /// 計上元仕入明細読込結果クラス出力処理
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>出力クラス</returns>
        private AddUpOrgStockDetailWork AddUppOrgStockDetailReadResultPut(ref SqlDataReader myReader)
        {
            StockDetailWork addUpOrgDtlwork = new AddUpOrgStockDetailWork();

            this.StockDetailReadResultPut(ref addUpOrgDtlwork, myReader);

            return addUpOrgDtlwork as AddUpOrgStockDetailWork;
        }

        /// <summary>
        /// 仕入読込クラス出力処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データクラス</param>
        /// <returns>出力クラス(StockSlipReadWork)</returns>
        private StockSlipReadWork StockSlipReadWorkOutPut(StockSlipWork stockSlipWork)
        {
            StockSlipReadWork wkStockSlipReadWork = new StockSlipReadWork();

            wkStockSlipReadWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
            wkStockSlipReadWork.SupplierFormal = stockSlipWork.SupplierFormal;
            wkStockSlipReadWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;

            return wkStockSlipReadWork;
        }

        /// <summary>
        /// 仕入読込クラス出力処理
        /// </summary>
        /// <param name="stockSlipDeleteWork">仕入データ削除クラス</param>
        /// <returns>出力クラス(StockSlipReadWork)</returns>
        private StockSlipReadWork StockSlipReadWorkOutPut(StockSlipDeleteWork stockSlipDeleteWork)
        {
            StockSlipReadWork wkStockSlipReadWork = new StockSlipReadWork();

            wkStockSlipReadWork.EnterpriseCode = stockSlipDeleteWork.EnterpriseCode;
            wkStockSlipReadWork.SupplierFormal = stockSlipDeleteWork.SupplierFormal;
            wkStockSlipReadWork.SupplierSlipNo = stockSlipDeleteWork.SupplierSlipNo;

            return wkStockSlipReadWork;
        }

        /// <summary>
        /// 仕入データを読込みます(他リモートオブジェクトから呼び出し)
        /// </summary>
        /// <param name="paraList">読込対象オブジェクト</param>
        /// <param name="retList">読込結果List</param>
        /// <param name="position">更新対象オブジェクト位置</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データを読込みます(他リモートオブジェクトから呼び出し)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.12</br>
        public int Read(ref CustomSerializeArrayList paraList, ref CustomSerializeArrayList retList, int position, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //●読込対象クラス位置チェック
                if (position < 0)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象オブジェクトパラメータが未指定です", status);
                    return status;
                }

                //●読込パラメータ
                StockSlipReadWork stockSlipReadWork = null;

                //●読込結果格納用
                StockSlipWork stockSlipWork = null;
                ArrayList stockDetailWorks = null;

                StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                ArrayList[] copyStockDetailWorks = new ArrayList[0];

                //●コネクション情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                    return status;
                }

                //●仕入更新オブジェクトの取得(カスタムArray内から検索)
                if (paraList == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象パラメータListが未指定です", status);
                    
                    return status;
                }
                else if (paraList.Count > 0) stockSlipReadWork = paraList[position] as StockSlipReadWork;
                if (stockSlipReadWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 読込対象オブジェクトパラメータが未指定です", status);
                    return status;
                }

                //●仕入Read
                status = ReadStockSlipWork(out stockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                //●仕入明細Read
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = ReadStockDetailWork(out stockDetailWorks, ref copyStockDetailWorks, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
                
                //●読込結果を戻り値に戻す
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retList.Add(stockSlipWork);

                    if (stockDetailWorks != null)
                        retList.Add(stockDetailWorks);
                    
                    paraList[position] = stockSlipReadWork;
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        #endregion

        #region [Write]　登録・更新処理　ヘッダ・明細・詳細
        /// <summary>
        /// 仕入データ・仕入明細データ・仕入詳細データを登録、更新初期処理を行います
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
        /// <br>Note       : 仕入データ・仕入明細データ・仕入詳細データを登録、更新初期処理を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        public int WriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int listPos_StockSlipWork = -1;
            int listPos_StockDetailWork = -1;
            int listPos_SlpDtlAddInfWork = -1;      //ADD 2008/06/03 M.Kubota

            //更新対象オブジェクト格納用
            StockSlipWork stockSlipWork = null;
            ArrayList stockDetailWorkList = null;
            ArrayList slpDtlAddInfWorkList = null;  //ADD 2008/06/03 M.Kubota
            SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer(); //ADD 2009/02/18

            //更新前情報読込パラメータ格納用
            StockSlipReadWork stockSlipReadWork = null;

            originList = new CustomSerializeArrayList();

            //更新前データ格納用
            StockSlipWork oldStockSlipWork = new StockSlipWork();
            ArrayList oldStockDetailWorkList = new ArrayList();

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 更新対象パラメータが未指定です", status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockSlipWork = paraList[position] as StockSlipWork;
                listPos_StockSlipWork = position;
            }

            //●伝票情報パラメータ取得
            for (int i = 0; i < paraList.Count; i++)
            {
                // 仕入明細データの分離
                if (stockDetailWorkList == null)
                {
                    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                    {
                        stockDetailWorkList = paraList[i] as ArrayList;
                        listPos_StockDetailWork = i;
                        continue;                        
                        //if (stockDetailWorkList != null) break;  //DEL 2008/06/03 M.Kubota
                    }
                }

                //--- ADD 2008/06/03 M.Kubota --->>>
                // 伝票明細追加情報データの分離
                if (slpDtlAddInfWorkList == null)
                {
                    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is SlipDetailAddInfoWork)
                    {
                        slpDtlAddInfWorkList = paraList[i] as ArrayList;
                        // 2009/02/18 >>>>>>>>>>>>>>>>>>>>>>
                        //slpDtlAddInfWorkList.Sort(new SlipDetailAddInfoDtlRelationGuidComparer());
                        slpDtlAddInfWorkList.Sort(DtlRelationGuidComp);
                        // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<
                        listPos_SlpDtlAddInfWork = i;
                        continue;                        
                    }
                }

                if (stockDetailWorkList != null && slpDtlAddInfWorkList != null)
                {
                    break;
                }
                //--- ADD 2008/06/03 M.Kubota ---<<<
            }
            //●製番管理しない商品に関しては仕入詳細データは存在しない
            if (stockSlipWork == null || stockDetailWorkList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": 更新対象オブジェクトパラメータが未指定です。" + ((stockSlipWork == null) ? "stockSlipWork = null" : "stockSlipWork = OK") + ((stockDetailWorkList == null) ? "stockDetailWorkList = null" : "stockDetailWorkList = OK");
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            // add 2007.07.23 saito >>>>>>>>>>
            //●最終支払締履歴日付チェック
            //if (stockSlipWork.SupplierFormal == 0)
            //{
            //    status = this.CheckPaymentAddUpHis(stockSlipWork, out retMsg, ref sqlConnection, ref sqlTransaction);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING) return status;
            //}
            //●売上計上済み在庫がある場合は売上計上日付をMAKON01924Rでチェック
            // add 2007.07.23 saito <<<<<<<<<<

            //●仕入伝票番号の採番
            //採番チェック
            //伝票更新で仕入伝票番号が入っていない場合(新規登録)
            // 2009/02/12 >>>>>>>>>>>>>>>>>>>>>> 
            //卸商仕入受信処理、電話発注の場合の対応
            //if (stockSlipWork.SupplierFormal == 2 && (!(freeParam is SalesOrderPrint)))
            if (stockSlipWork.SupplierFormal == 2 && !(freeParam is SalesOrderPrint) && stockSlipWork is OrderSlipWork)
            // 2009/02/12 <<<<<<<<<<<<<<<<<<<<<<
            {
                // 発注入力から呼び出された場合の初期化処理を行う
                if (listPos_StockDetailWork >= 0)
                {
                    StockDetailWork dtlWork = stockDetailWorkList[0] as StockDetailWork;

                    stockSlipWork.EnterpriseCode = dtlWork.EnterpriseCode;
                    stockSlipWork.SectionCode = dtlWork.SectionCode;
                    stockSlipWork.CreateDateTime = DateTime.Now;  // ダミーの更新日付を設定する

                    // 仕入明細通番が指定されている場合は、既存仕入明細データの読込みを行う
                    if (dtlWork.StockSlipDtlNum > 0)
                    {
                        oldStockSlipWork = stockSlipWork;
                        this.ReadStockDetailWork(out oldStockDetailWorkList, stockDetailWorkList, ref sqlConnection, ref sqlTransaction);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            else
            {
                // 仕入形式が 0:仕入 1:入荷 の場合、又は 2:発注 ＆ 発注書発行から呼び出された場合の初期化処理を行う
                if (stockSlipWork.SupplierSlipNo == 0)
                {
                    string sectionCode;
                    Int32 supplierSlipNo;

                    //仕入拠点コード
                    //sectionCode = stockSlipWork.StockSectionCd;  //DEL 2009/01/15 M.Kubota
                    
                    // 拠点コード(ログイン拠点)
                    sectionCode = stockSlipWork.SectionCode;  //ADD 2009/01/15 M.Kubota

                    // 仕入伝票番号の採番
                    status = CreateSupplierSlipNoProc(stockSlipWork.EnterpriseCode, sectionCode, out supplierSlipNo, stockSlipWork.SupplierFormal, out retMsg, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || supplierSlipNo == 0)
                    {
                        //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                        if (retMsg == null || retMsg == "")
                            retMsg = "仕入伝票番号が採番できませんでした。番号設定を見直してください。";

                        return status;
                    }
                    else
                    {
                        // 採番した仕入伝票番号を設定
                        stockSlipWork.SupplierSlipNo = supplierSlipNo;
                    }

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierSlipNo != 0)
                    //{
                    //    stockSlipWork.SupplierSlipNo = supplierSlipNo;

                    //    // 全ての仕入明細データに対して同一仕入伝票番号を設定する
                    //    if (stockDetailWorkList != null)
                    //    {
                    //        foreach (StockDetailWork stockDetail in stockDetailWorkList) stockDetail.SupplierSlipNo = supplierSlipNo;
                    //    }

                    //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //}
                    ////番号が取得出来なかった場合は終了
                    //else
                    //{
                    //    //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                    //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    //    if (retMsg == null || retMsg == "") retMsg = "仕入伝票番号が採番できませんでした。番号設定を見直してください。";
                    //    return status;
                    //}
                }
                //伝票更新で仕入伝票番号が入っている場合(既存伝票更新or不正データの場合はエラー出力)
                else
                {
                    //仕入伝票が存在するかチェックし、originListに追加する
                    StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                    ArrayList[] copyStockDetailWorkList = new ArrayList[0];

                    stockSlipReadWork = StockSlipReadWorkOutPut(stockSlipWork);

                    //既存仕入伝票の読込
                    status = this.ReadStockSlipWork(out oldStockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        this.ReadStockDetailWork(out oldStockDetailWorkList, ref copyStockDetailWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            # region [pending]
            /*
            if (stockSlipWork.SupplierFormal != 2)   // 発注以外
            {
                if (stockSlipWork.SupplierSlipNo == 0)
                {
                    string sectionCode;
                    Int32 supplierSlipNo;

                    //仕入拠点コード
                    sectionCode = stockSlipWork.StockSectionCd;

                    // 仕入伝票番号の採番
                    status = CreateSupplierSlipNoProc(stockSlipWork.EnterpriseCode, sectionCode, out supplierSlipNo, stockSlipWork.SupplierFormal, out retMsg, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierSlipNo != 0)
                    {
                        stockSlipWork.SupplierSlipNo = supplierSlipNo;

                        // 全ての仕入明細データに対して同一仕入伝票番号を設定する
                        if (stockDetailWorkList != null)
                        {
                            foreach (StockDetailWork stockDetail in stockDetailWorkList) stockDetail.SupplierSlipNo = supplierSlipNo;
                        }

                        //--- DEL 2007/09/11 M.Kubota --->>>
                        //if (stockExplaDataWorkList != null)
                        //{
                        //    foreach (StockExplaDataWork stockExplaData in stockExplaDataWorkList) stockExplaData.SupplierSlipNo = supplierSlipNo;
                        //}
                        //  --- DEL 2007/09/11 M.Kubota ---<<<

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //番号が取得出来なかった場合は終了
                    else
                    {
                        //部品からのステータス及びメッセージが無い場合はセット（ありえないが念のため）
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (retMsg == null || retMsg == "") retMsg = "仕入伝票番号が採番できませんでした。番号設定を見直してください。";
                        return status;
                    }
                }
                //伝票更新で仕入伝票番号が入っている場合(既存伝票更新or不正データの場合はエラー出力)
                else
                {
                    //仕入伝票が存在するかチェックし、originListに追加する
                    StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                    ArrayList[] copyStockDetailWorkList = new ArrayList[0];
                    //ArrayList[] copyStockExplaDataWorkList = new ArrayList[0];  //DEL 2007/09/11 M.Kubota

                    stockSlipReadWork = StockSlipReadWorkOutPut(stockSlipWork);

                    //既存仕入伝票の読込
                    status = this.ReadStockSlipWork(out oldStockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        this.ReadStockDetailWork(out oldStockDetailWorkList, ref copyStockDetailWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                    //--- DEL 2007/09/11 M.Kubota --->>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    this.ReadStockExplaDataWork(out oldStockExplaDataWorkList, ref copyStockExplaDataWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
                    //--- DEL 2007/09/11 M.Kubota ---<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            else
            {
                //--- ADD 2007/09/11 M.Kubota --->>>
                // 仕入データがNULLで、仕入明細データが存在している場合
                if (listPos_StockDetailWork >= 0)
                {
                    StockDetailWork dtlWork = stockDetailWorkList[0] as StockDetailWork;

                    // 仕入明細通番が指定されている場合は、既存仕入明細データの読込みを行う
                    if (dtlWork.StockSlipDtlNum > 0)
                    {
                        this.ReadStockDetailWork(out oldStockDetailWorkList, stockDetailWorkList, ref sqlConnection, ref sqlTransaction);
                    }

                    stockSlipWork.EnterpriseCode = dtlWork.EnterpriseCode;
                    stockSlipWork.SectionCode = dtlWork.SectionCode;
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<
            }
            */
            # endregion

            //--- ADD 2007/09/11 M.Kubota --->>>
            Int32 StandardAcceptAnOrderNo = 0;

            foreach (StockDetailWork newDtlWork in stockDetailWorkList)
            {
                if (newDtlWork.AcceptAnOrderNo > 0)
                {
                    StandardAcceptAnOrderNo = newDtlWork.AcceptAnOrderNo;
                    break;
                }
            }

            foreach (StockDetailWork newDtlWork in stockDetailWorkList)
            {
                // 仕入明細が新規データの場合、又は発注書印刷の場合は発注残数に仕入数を設定
                if (newDtlWork.StockSlipDtlNum == 0 || freeParam is SalesOrderPrint) 
                {
                    //newDtlWork.StockCountDifference = newDtlWork.StockCount * ((newDtlWork.StockSlipCdDtl == 1) ? -1 : 1);
                    newDtlWork.StockCountDifference = newDtlWork.StockCount;
                    newDtlWork.OrderRemainCnt = newDtlWork.StockCount;
                    newDtlWork.RemainCntUpdDate = DateTime.Now;

                    if (freeParam is SalesOrderPrint)
                    {
                        newDtlWork.OrderFormIssuedDiv = 1;
                    }
                }
                else
                {
                    if (oldStockDetailWorkList != null && oldStockDetailWorkList.Count > 0)
                    {
                        foreach (StockDetailWork oldDtlWork in oldStockDetailWorkList)
                        {
                            // 同一キー値を持つデータを検索
                            // 2009/02/18 入庫更新対応>>>>>>>>>>>>>>>>>>>>
                            //if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
                            //    newDtlWork.SupplierFormal == oldDtlWork.SupplierFormal &&
                            //    newDtlWork.StockSlipDtlNum == oldDtlWork.StockSlipDtlNum)

                            //差分数計算の新旧明細比較時に品番、メーカー、倉庫を追加
                            if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode &&
                                newDtlWork.SupplierFormal == oldDtlWork.SupplierFormal &&
                                newDtlWork.StockSlipDtlNum == oldDtlWork.StockSlipDtlNum &&
                                newDtlWork.GoodsNo == oldDtlWork.GoodsNo &&
                                newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd &&
                                newDtlWork.WarehouseCode == oldDtlWork.WarehouseCode)
                            // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {

                                // 仕入差分数の設定
                                //newDtlWork.StockCountDifference = (newDtlWork.StockCount - oldDtlWork.StockCount) * ((newDtlWork.StockSlipCdDtl == 1) ? -1 : 1);
                                newDtlWork.StockCountDifference = newDtlWork.StockCount - oldDtlWork.StockCount;

                                // 発注残数の設定 (更新前発注残数＋更新後仕入差分数)
                                //newDtlWork.OrderRemainCnt = oldDtlWork.OrderRemainCnt + (newDtlWork.StockCountDifference * ((newDtlWork.StockSlipCdDtl == 1) ? -1 : 1));
                                newDtlWork.OrderRemainCnt = oldDtlWork.OrderRemainCnt + newDtlWork.StockCountDifference;


                                // 仕入差分数が 0 以外の場合は残数更新日を更新する
                                if (newDtlWork.StockCountDifference != 0)
                                {
                                    newDtlWork.RemainCntUpdDate = DateTime.Now;
                                }
                                else
                                {
                                    newDtlWork.RemainCntUpdDate = oldDtlWork.RemainCntUpdDate;
                                }

                                break;
                            }
                        }
                    }
                }

                // 仕入伝票番号を設定
                if (stockSlipWork.SupplierSlipNo > 0 && newDtlWork.SupplierSlipNo <= 0)
                {
                    newDtlWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                }

                AcceptOdrDB acceptOdr = new AcceptOdrDB();

                // 受注番号を設定
                if (newDtlWork.SupplierSlipNo > 0 && newDtlWork.AcceptAnOrderNo <= 0)
                {
                    // 受注番号が未採番の場合にのみ採番を行う
                    if (StandardAcceptAnOrderNo <= 0)
                    {
                        status = acceptOdr.GetAcceptAnOrderNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode, out StandardAcceptAnOrderNo);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || StandardAcceptAnOrderNo <= 0)
                        {
                            retMsg = "受注番号の採番に失敗しました。";
                            return status;
                        }
                    }

                    // １伝票に対して
                    newDtlWork.AcceptAnOrderNo = StandardAcceptAnOrderNo;
                }

                // 共通通番を設定
                if (newDtlWork.CommonSeqNo <= 0)
                {
                    Int64 commonseqno = 0;
                    status = acceptOdr.GetCommonSeqNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode, out commonseqno);

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

                // 仕入明細通番を設定
                if (newDtlWork.StockSlipDtlNum <= 0)
                {
                    Int64 stockslipdtlnum = 0;

                    status = acceptOdr.GetSlipDetailNo(newDtlWork.EnterpriseCode, newDtlWork.SectionCode,
                                                           (int)SlipDataDivide.Stock, out stockslipdtlnum);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockslipdtlnum != 0)
                    {
                        newDtlWork.StockSlipDtlNum = stockslipdtlnum;
                    }
                    else
                    {
                        retMsg = "仕入明細通番の採番に失敗しました。";
                        return status;
                    }
                }
            }
            //--- ADD 2007/09/11 M.Kubota ---<<<

            # region [--- DEL ---]
            // add 2007.05.20 saitoh >>>>>>>>>>
            //●拠点制御設定マスタより仕入拠点コードを抽出
            //--- DEL 2007/09/11 M.Kubota --->>>
            //if (stockSlipWork.StockGoodsCd == 0)
            //{
            //    status = this.SearchStockSecCd(ref stockSlipWork, ref oldStockSlipWork, ref sqlConnection, ref sqlTransaction);
            //}
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    retMsg = "拠点制御設定が正しく設定されておりません。";
            //    return status;
            //}
            //--- DEL 2007/09/11 M.Kubota ---<<<
            //--- ADD 2007/09/11 M.Kubota --->>>
            //--- DEL 2008/06.03 M.Kubota --->>>
            //if (stockSlipWork != null && stockSlipWork.StockGoodsCd == 0)
            //{
            //    status = this.SearchStockSecCd(ref stockSlipWork, ref oldStockSlipWork, ref sqlConnection, ref sqlTransaction);

            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //    {
            //        retMsg = "拠点制御設定が正しく設定されておりません。";
            //        return status;
            //    }
            //}
            //--- ADD 2007/09/11 M.Kubota ---<<<
            //--- DEL 2008/06.03 M.Kubota ---<<<
            // add 2007.05.20 saitoh <<<<<<<<<<
            # endregion

            //●パラメータに戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (oldStockSlipWork.CreateDateTime > DateTime.MinValue)
                {
                    originList.Add(oldStockSlipWork);
                }

                if (oldStockDetailWorkList != null && oldStockDetailWorkList.Count > 0)
                {
                    originList.Add(oldStockDetailWorkList);
                }

                paraList[listPos_StockSlipWork] = stockSlipWork;
                paraList[listPos_StockDetailWork] = stockDetailWorkList;

                # region [--- DEL 2009/01/28 M.Kubota --- 在庫データ作成処理で、返品元伝票を必要としなくなった他、売上リアル更新内でも不具合に原因になる為 削除]
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                //// 返品の場合は、返品元となった伝票の読み込みを行う
                //// ( ※返品伝票自体の修正ならば、originListには変更前返品と返品元伝票の両方が入る )
                //if ( stockSlipWork.SupplierSlipCd == 20 )
                //{
                //    StockSlipWork retOriginStockSlipWork = null;
                //    ArrayList retOriginStockDetailWorkList = null;
                //    status = ReadStockSlipFromReturn( stockSlipWork, stockDetailWorkList, out retOriginStockSlipWork, out retOriginStockDetailWorkList, ref sqlConnection, ref sqlTransaction );

                //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //    {
                //        // 読み込み成功したらoriginListに追加
                //        if (retOriginStockSlipWork != null)
                //            originList.Add( retOriginStockSlipWork );

                //        if (retOriginStockDetailWorkList != null && retOriginStockDetailWorkList.Count > 0)
                //            originList.Add( retOriginStockDetailWorkList );
                //    }
                //    else
                //    {
                //        // 失敗したらエラー
                //        retMsg = "返品元の仕入伝票の読み込みに失敗しました。";
                //        return status;
                //    }
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                # endregion

                //--- ADD 2009/01/30 --->>>
                // 計上元明細データの読み込み
                ArrayList addUpStockDetailWorks = null;
                status = this.ReadAddUpStockDetailWork(out addUpStockDetailWorks, stockDetailWorkList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(addUpStockDetailWorks))
                {
                    paraList.Add(addUpStockDetailWorks);
                }
                //--- ADD 2009/01/30 ---<<<

            }
            else             //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;

            return status;
        }

        #region [---- DEL 2009/01/30 ---]
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
        ///// <summary>
        ///// 返品元伝票読み込み処理
        ///// </summary>
        ///// <param name="stockSlipWork"></param>
        ///// <param name="stockDetailWorkList"></param>
        ///// <param name="oldStockSlipWork"></param>
        ///// <param name="oldStockDetailWorkList"></param>
        ///// <param name="sqlConnection"></param>
        ///// <param name="sqlTransaction"></param>
        ///// <returns>STATUS</returns>
        //private int ReadStockSlipFromReturn( StockSlipWork stockSlipWork, ArrayList stockDetailWorkList, out StockSlipWork oldStockSlipWork, out ArrayList oldStockDetailWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        //{
        //    oldStockSlipWork = null;
        //    oldStockDetailWorkList = null;

        //    // 仕入明細読み込みパラメータリスト
        //    ArrayList paraStockDetailWorkList = new ArrayList();

        //    // 返品伝票を元に、返品元仕入明細データ読み込みパラメータリストを生成する
        //    foreach ( object obj in stockDetailWorkList )
        //    {
        //        if ( obj is StockDetailWork )
        //        {
        //            // 返品伝票の明細１行
        //            StockDetailWork retStockDetailWork = (obj as StockDetailWork);

        //            if (retStockDetailWork.SupplierFormalSrc > -1 && retStockDetailWork.StockSlipDtlNumSrc != 0)
        //            {
        //                // 返品元仕入明細データ読み込みパラメータ設定
        //                StockDetailWork paraStockDetailWork = new StockDetailWork();
        //                paraStockDetailWork.EnterpriseCode = retStockDetailWork.EnterpriseCode;
        //                paraStockDetailWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
        //                paraStockDetailWork.SupplierFormal = retStockDetailWork.SupplierFormalSrc;
        //                paraStockDetailWork.StockSlipDtlNum = retStockDetailWork.StockSlipDtlNumSrc;    // ←元の伝票の明細通番をセット

        //                // 読み込みパラメータリストに追加
        //                paraStockDetailWorkList.Add(paraStockDetailWork);
        //            }
        //        }
        //    }

        //    // 読み込みリストが空なら失敗 ※但し返品元伝票が無い場合もあるので ctDB_NORMAL とする
        //    if ( paraStockDetailWorkList.Count == 0 )
        //    {
        //        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // 仕入明細データ読み込み
        //    int status = this.ReadStockDetailWork( out oldStockDetailWorkList, paraStockDetailWorkList, ref sqlConnection, ref sqlTransaction );

        //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //    {
        //        // 仕入データ読み込みパラメータ設定
        //        StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();
        //        stockSlipReadWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
        //        stockSlipReadWork.SupplierFormal = stockSlipWork.SupplierFormal;
        //        stockSlipReadWork.SupplierSlipNo = (oldStockDetailWorkList[0] as StockDetailWork).SupplierSlipNo;

        //        // 仕入データ読み込み
        //        StockSlipWork[] stockSlipWorks = new StockSlipWork[0];
        //        status = this.ReadStockSlipWork( out oldStockSlipWork, ref stockSlipWorks, stockSlipReadWork, ref sqlConnection, ref sqlTransaction );

        //        if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //        {
        //            // 仕入データの読み込みに失敗したら失敗
        //            return status;
        //        }
        //    }
        //    else
        //    {
        //        // 明細の一括読み込みに失敗したら失敗
        //        return status;
        //    }

        //    // 読み込み成功
        //    return status;
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
        # endregion

        /// <summary>
        /// 仕入データ・仕入明細データ・仕入詳細データを登録、更新します
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
        /// <br>Note       : 仕入データ・仕入明細データ・仕入詳細データを登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        /// <br>Update Note: 2015/09/10　周健</br>
        /// <br>             Redmine#47298　MKアシスト　仕入チェック処理</br>
        /// 
        public int Write(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int listPos_StockSlipWork = 0;
            int listPos_StockDetailWork = 0;

            StockSlipWork stockSlipWork = null;
            ArrayList stockDetailWorks = null;
            ArrayList addUpStockDetailWorks = null;  //ADD 2007/09/11 M.Kubota
            ArrayList slpDtlAddInfWorks = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 更新対象パラメータが未指定です", status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                stockSlipWork = paraList[position] as StockSlipWork;
                listPos_StockSlipWork = position;
            }

            //●伝票更新List内の明細・詳細クラスを抽出
            for (int i = 0; i < paraList.Count; i++)
            {
                if (stockDetailWorks == null)
                {
                    if (paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                    {
                        stockDetailWorks = paraList[i] as ArrayList;
                        listPos_StockDetailWork = i;
                        if (stockDetailWorks != null) break;  //ADD 2007/09/11 M.Kubota
                    }
                }
            }

            //●伝票明細追加情報データの分離
            slpDtlAddInfWorks = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            //製番管理しない商品に関しては仕入詳細データは存在しない
            if (stockSlipWork == null || stockDetailWorks == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 更新対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            //●Write
            //仕入伝票更新
            // 2009/02/12 >>>>>>>>>>>>>>>>>>>>>>>
            //卸商仕入受信処理、電話発注の場合の対応
            //if (stockSlipWork.SupplierFormal == 2 && (!(freeParam is SalesOrderPrint)))
            if (stockSlipWork.SupplierFormal == 2 && !(freeParam is SalesOrderPrint) && stockSlipWork is OrderSlipWork)
            // 2009/02/12 <<<<<<<<<<<<<<<<<<<<<<<
            {
                // 発注入力からコールされている場合は仕入データを更新しない
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // --- ADD 2012/12/14 T.Miyamoto ------------------------------>>>>>
                // 更新仕入データのチェック
                CheckStockSlipWork(ref stockSlipWork);
                // --- ADD 2012/12/14 T.Miyamoto ------------------------------<<<<<
                // 仕入形式が 0:仕入 1:入荷 の場合、又は 2:発注 でも発注書発行からコールされている場合は仕入データを更新する
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                //status = WriteStockSlipWork(ref stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                status = WriteStockSlipWork(ref stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                // --- ADD BY 周健 2015/09/10 for Redmine#47298 MKアシスト　仕入チェック処理 --------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockDetailWorks != null)
                {
                    // 仕入チェック処理情報を更新します
                    UpdateStockCheckDtl(stockDetailWorks, ref sqlConnection, ref sqlTransaction);
                }
                // --- ADD BY 周健 2015/09/10 for Redmine#47298 MKアシスト　仕入チェック処理 ---------<<<<<
            }

            //仕入伝票明細更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockDetailWorks != null)
                status = WriteStockDetailWork(ref stockDetailWorks, stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            //--- ADD 2007/09/11 M.Kubota --->>>
            //計上元仕入明細データの発注残数更新 (計上元の有無は呼出し先で行っている)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList stockDetails = new ArrayList();
                stockDetails.AddRange(stockDetailWorks);

                // 更新前の仕入明細データを取得する
                ArrayList oldStockDetailWorks = null;

                if (originList != null && originList.Count > 0)
                {
                    for (int i = 0; i < originList.Count; i++)
                    {
                        if (originList[i] is ArrayList &&
                            ((ArrayList)originList[i]).Count > 0 &&
                            ((ArrayList)originList[i])[0] is StockDetailWork)
                        {
                            oldStockDetailWorks = originList[i] as ArrayList;
                            if (oldStockDetailWorks != null) break;
                        }
                    }
                }

                // 明細単位で削除された物を割り出し、残数更新の対象として追加する
                if (oldStockDetailWorks != null)
                {
                    foreach(StockDetailWork olditem in oldStockDetailWorks)
                    {
                        bool deleted = true;

                        foreach (StockDetailWork item in stockDetailWorks)
                        {
                            if (olditem.EnterpriseCode == item.EnterpriseCode &&
                                olditem.SupplierFormal == item.SupplierFormal &&
                                (olditem.StockSlipDtlNum == item.StockSlipDtlNum ||
                                 olditem.StockSlipDtlNum == item.StockSlipDtlNumSrc))  // ← 返品登録時に計上元発注残数を更新してしまわないようにする為
                            {
                                deleted = false;
                                break;
                            }
                        }

                        if (deleted)
                        {
                            StockDetailWork deleteItem = new StockDetailWork();

                            deleteItem.EnterpriseCode = olditem.EnterpriseCode;
                            deleteItem.SupplierFormal = olditem.SupplierFormal;
                            deleteItem.StockSlipDtlNum = olditem.StockSlipDtlNum;
                            deleteItem.SupplierFormalSrc = olditem.SupplierFormalSrc;
                            deleteItem.StockSlipDtlNumSrc = olditem.StockSlipDtlNumSrc;
                            deleteItem.StockCountDifference = olditem.StockCount * -1;

                            stockDetails.Add(deleteItem);
                        }
                    }
                }

                status = this.UpdateOrderRemainCnt(stockSlipWork, stockDetails, slpDtlAddInfWorks, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // 発注残の更新に成功した場合、計上元仕入明細データを取得する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.ReadAddUpStockDetailWork(out addUpStockDetailWorks, stockDetailWorks, ref sqlConnection, ref sqlTransaction);
                }
            }
            //--- ADD 2007/09/11 M.Kubota ---<<<

            //●更新結果を戻り値に戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList[listPos_StockSlipWork] = stockSlipWork;
                
                if (stockDetailWorks != null)
                    paraList[listPos_StockDetailWork] = stockDetailWorks;
                
                //--- ADD 2007/09/11 M.Kubota --->>>
                if (addUpStockDetailWorks != null && addUpStockDetailWorks.Count > 0)
                {
                    //--- ADD 2009/01/30 --->>>
                    int pos = -1;
                    ListUtils.Find(paraList, typeof(AddUpOrgStockDetailWork), ListUtils.FindType.Array, out pos);

                    if (pos >= 0)
                    {
                        paraList.RemoveAt(pos);  // 書込み準備処理で読み込んでいた計上元売上明細データを削除する
                    }
                    //--- ADD 2009/01/30 ---<<<

                    // 計上元仕入明細データが存在する場合はパラメータリストに追加する
                    paraList.Add(addUpStockDetailWorks);
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<
            }

            return status;
        }

        // --- ADD BY 周健 2015/09/10 for Redmine#47298 MKアシスト　仕入チェック処理 --------->>>>>
        /// <summary>
        /// 仕入チェック処理情報を更新します
        /// </summary>
        /// <param name="stockDetailWorks">仕入明細データ情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <br>Note       : 仕入チェック処理情報を更新します</br>
        /// <br>Programmer : 周健</br>
        /// <br>Date       : 2015/09/10</br>
        private void UpdateStockCheckDtl(ArrayList stockDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 仕入チェック処理DBリモートオブジェクト
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            foreach (StockDetailWork newDtlWork in stockDetailWorks)
            {
                try
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  STCH.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKCHECKDTLRF AS STCH" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  STCH.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND STCH.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND STCH.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(newDtlWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(newDtlWork.SupplierFormal);
                    findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(newDtlWork.StockSlipDtlNum);
                    # endregion

                    myReader = sqlCommand.ExecuteReader();
                    sqlText = string.Empty;
                    if (myReader.Read())
                    {
                        // 既存データがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        // 既存データで更新日時がないの場合には排他
                        if (_updateDateTime == null || _updateDateTime == DateTime.MinValue)
                        {
                            return;
                        }
                        #region [UPDATE文]
                        sqlText += "UPDATE STOCKCHECKDTLRF SET " + Environment.NewLine;
                        sqlText += " STOCKCHECKDIVCADDUPRF=0 " + Environment.NewLine;
                        sqlText += " , STOCKCHECKDIVDAILYRF=0 " + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                        sqlText += " AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL " + Environment.NewLine;
                        sqlText += " AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM " + Environment.NewLine;
                        #endregion
                        sqlCommand.CommandText = sqlText;
                    }
                    if (!String.IsNullOrEmpty(sqlText))
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, ex.Message);
                }
                finally
                {
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                            myReader.Close();
                        myReader.Dispose();
                    }
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
        }
        // --- ADD BY 周健 2015/09/10 for Redmine#47298 MKアシスト　仕入チェック処理 ---------<<<<<

        /// <summary>
        /// 仕入伝票情報を更新します
        /// </summary>
        /// <param name="stockSlipWork">更新伝票情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票情報を更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        /// <br>Update Note: 2011/07/27 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //private int WriteStockSlipWork(ref StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo) // DEL 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        private int WriteStockSlipWork(ref StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = string.Empty;

            SqlDataReader myReader = null;

            //Selectコマンドの生成
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO", sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                    myReader = sqlCommand.ExecuteReader();

                    //既存仕入伝票の更新処理
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockSlipWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (stockSlipWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
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
                        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                        // 仕入伝票を更新する前に、送信済みのチェックを行う
                        if (!CheckStockSending(stockSlipWork, out errMessage))
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
                        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                        
                        //＠仕入データ変更＠
                        //--- ADD 2007/09/11 M.Kubota --->>>
                        # region UPDATE SQL
                        string sqlText = string.Empty;
                        sqlText += "UPDATE STOCKSLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,SUPPLIERFORMALRF = @SUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNORF = @SUPPLIERSLIPNO" + Environment.NewLine;
                        sqlText += " ,SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF = @DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,DEBITNLNKSUPPSLIPNORF = @DEBITNLNKSUPPSLIPNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPCDRF = @SUPPLIERSLIPCD" + Environment.NewLine;
                        sqlText += " ,STOCKGOODSCDRF = @STOCKGOODSCD" + Environment.NewLine;
                        sqlText += " ,ACCPAYDIVCDRF = @ACCPAYDIVCD" + Environment.NewLine;
                        sqlText += " ,STOCKSECTIONCDRF = @STOCKSECTIONCD" + Environment.NewLine;
                        sqlText += " ,STOCKADDUPSECTIONCDRF = @STOCKADDUPSECTIONCD" + Environment.NewLine;
                        sqlText += " ,STOCKSLIPUPDATECDRF = @STOCKSLIPUPDATECD" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF = @INPUTDAY" + Environment.NewLine;
                        sqlText += " ,ARRIVALGOODSDAYRF = @ARRIVALGOODSDAY" + Environment.NewLine;
                        sqlText += " ,STOCKDATERF = @STOCKDATE" + Environment.NewLine;
                        sqlText += " ,STOCKADDUPADATERF = @STOCKADDUPADATE" + Environment.NewLine;
                        sqlText += " ,DELAYPAYMENTDIVRF = @DELAYPAYMENTDIV" + Environment.NewLine;
                        sqlText += " ,PAYEECODERF = @PAYEECODE" + Environment.NewLine;
                        sqlText += " ,PAYEESNMRF = @PAYEESNM" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM1RF = @SUPPLIERNM1" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM2RF = @SUPPLIERNM2" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSNMRF = @SUPPLIERSNM" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPENAMERF = @BUSINESSTYPENAME" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,SALESAREANAMERF = @SALESAREANAME" + Environment.NewLine;
                        sqlText += " ,STOCKINPUTCODERF = @STOCKINPUTCODE" + Environment.NewLine;
                        sqlText += " ,STOCKINPUTNAMERF = @STOCKINPUTNAME" + Environment.NewLine;
                        sqlText += " ,STOCKAGENTCODERF = @STOCKAGENTCODE" + Environment.NewLine;
                        sqlText += " ,STOCKAGENTNAMERF = @STOCKAGENTNAME" + Environment.NewLine;
                        sqlText += " ,SUPPTTLAMNTDSPWAYCDRF = @SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                        sqlText += " ,TTLAMNTDISPRATEAPYRF = @TTLAMNTDISPRATEAPY" + Environment.NewLine;
                        sqlText += " ,STOCKTOTALPRICERF = @STOCKTOTALPRICE" + Environment.NewLine;
                        sqlText += " ,STOCKSUBTTLPRICERF = @STOCKSUBTTLPRICE" + Environment.NewLine;
                        sqlText += " ,STOCKTTLPRICTAXINCRF = @STOCKTTLPRICTAXINC" + Environment.NewLine;
                        sqlText += " ,STOCKTTLPRICTAXEXCRF = @STOCKTTLPRICTAXEXC" + Environment.NewLine;
                        sqlText += " ,STOCKNETPRICERF = @STOCKNETPRICE" + Environment.NewLine;
                        sqlText += " ,STOCKPRICECONSTAXRF = @STOCKPRICECONSTAX" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCOUTTAXRF = @TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCINTAXRF = @TTLITDEDSTCINTAX" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCTAXFREERF = @TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        sqlText += " ,STOCKOUTTAXRF = @STOCKOUTTAX" + Environment.NewLine;
                        sqlText += " ,STCKPRCCONSTAXINCLURF = @STCKPRCCONSTAXINCLU" + Environment.NewLine;
                        sqlText += " ,STCKDISTTLTAXEXCRF = @STCKDISTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISOUTTAXRF = @ITDEDSTOCKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISINTAXRF = @ITDEDSTOCKDISINTAX" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISTAXFRERF = @ITDEDSTOCKDISTAXFRE" + Environment.NewLine;
                        sqlText += " ,STOCKDISOUTTAXRF = @STOCKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,STCKDISTTLTAXINCLURF = @STCKDISTTLTAXINCLU" + Environment.NewLine;
                        sqlText += " ,TAXADJUSTRF = @TAXADJUST" + Environment.NewLine;
                        sqlText += " ,BALANCEADJUSTRF = @BALANCEADJUST" + Environment.NewLine;
                        sqlText += " ,SUPPCTAXLAYCDRF = @SUPPCTAXLAYCD" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCONSTAXRATERF = @SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        sqlText += " ,ACCPAYCONSTAXRF = @ACCPAYCONSTAX" + Environment.NewLine;
                        sqlText += " ,STOCKFRACTIONPROCCDRF = @STOCKFRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " ,AUTOPAYMENTRF = @AUTOPAYMENT" + Environment.NewLine;
                        sqlText += " ,AUTOPAYSLIPNUMRF = @AUTOPAYSLIPNUM" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONDIVRF = @RETGOODSREASONDIV" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONRF = @RETGOODSREASON" + Environment.NewLine;
                        sqlText += " ,PARTYSALESLIPNUMRF = @PARTYSALESLIPNUM" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNOTE1RF = @SUPPLIERSLIPNOTE1" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNOTE2RF = @SUPPLIERSLIPNOTE2" + Environment.NewLine;
                        sqlText += " ,DETAILROWCOUNTRF = @DETAILROWCOUNT" + Environment.NewLine;
                        sqlText += " ,EDISENDDATERF = @EDISENDDATE" + Environment.NewLine;
                        sqlText += " ,EDITAKEINDATERF = @EDITAKEINDATE" + Environment.NewLine;
                        sqlText += " ,UOEREMARK1RF = @UOEREMARK1" + Environment.NewLine;
                        sqlText += " ,UOEREMARK2RF = @UOEREMARK2" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTDIVCDRF = @SLIPPRINTDIVCD" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTFINISHCDRF = @SLIPPRINTFINISHCD" + Environment.NewLine;
                        sqlText += " ,STOCKSLIPPRINTDATERF = @STOCKSLIPPRINTDATE" + Environment.NewLine;
                        sqlText += " ,SLIPPRTSETPAPERIDRF = @SLIPPRTSETPAPERID" + Environment.NewLine;
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
                        sqlText += " ,DIRECTSENDINGCDRF = @DIRECTSENDINGCD" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                        # endregion
                        sqlCommand.CommandText = sqlText;
                        //--- ADD 2007/09/11 M.Kubota ---<<<
                        
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    //仕入伝票の新規登録
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (stockSlipWork.UpdateDateTime > DateTime.MinValue)
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

                        //新規作成時のSQL文を生成
                        //＠仕入データ変更＠
                        //--- ADD 2007/09/11 M.Kubota --->>>
                        string sqlText = string.Empty;
                        # region INSERT SQL
                        sqlText += "INSERT INTO STOCKSLIPRF (" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                        sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEDIVRF" + Environment.NewLine;
                        sqlText += " ,DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                        sqlText += " ,ACCPAYDIVCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKADDUPSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKSLIPUPDATECDRF" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                        sqlText += " ,ARRIVALGOODSDAYRF" + Environment.NewLine;
                        sqlText += " ,STOCKDATERF" + Environment.NewLine;
                        sqlText += " ,STOCKADDUPADATERF" + Environment.NewLine;
                        sqlText += " ,DELAYPAYMENTDIVRF" + Environment.NewLine;
                        sqlText += " ,PAYEECODERF" + Environment.NewLine;
                        sqlText += " ,PAYEESNMRF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPENAMERF" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                        sqlText += " ,SALESAREANAMERF" + Environment.NewLine;
                        sqlText += " ,STOCKINPUTCODERF" + Environment.NewLine;
                        sqlText += " ,STOCKINPUTNAMERF" + Environment.NewLine;
                        sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                        sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
                        sqlText += " ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                        sqlText += " ,TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                        sqlText += " ,STOCKTOTALPRICERF" + Environment.NewLine;
                        sqlText += " ,STOCKSUBTTLPRICERF" + Environment.NewLine;
                        sqlText += " ,STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                        sqlText += " ,STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,STOCKNETPRICERF" + Environment.NewLine;
                        sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        sqlText += " ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        sqlText += " ,STOCKOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,STCKPRCCONSTAXINCLURF" + Environment.NewLine;
                        sqlText += " ,STCKDISTTLTAXEXCRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISINTAXRF" + Environment.NewLine;
                        sqlText += " ,ITDEDSTOCKDISTAXFRERF" + Environment.NewLine;
                        sqlText += " ,STOCKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += " ,STCKDISTTLTAXINCLURF" + Environment.NewLine;
                        sqlText += " ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += " ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += " ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        sqlText += " ,ACCPAYCONSTAXRF" + Environment.NewLine;
                        sqlText += " ,STOCKFRACTIONPROCCDRF" + Environment.NewLine;
                        sqlText += " ,AUTOPAYMENTRF" + Environment.NewLine;
                        sqlText += " ,AUTOPAYSLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONDIVRF" + Environment.NewLine;
                        sqlText += " ,RETGOODSREASONRF" + Environment.NewLine;
                        sqlText += " ,PARTYSALESLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
                        sqlText += " ,DETAILROWCOUNTRF" + Environment.NewLine;
                        sqlText += " ,EDISENDDATERF" + Environment.NewLine;
                        sqlText += " ,EDITAKEINDATERF" + Environment.NewLine;
                        sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                        sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTDIVCDRF" + Environment.NewLine;
                        sqlText += " ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                        sqlText += " ,STOCKSLIPPRINTDATERF" + Environment.NewLine;
                        sqlText += " ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
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
                        sqlText += " ,DIRECTSENDINGCDRF)" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                        sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@DEBITNOTEDIV" + Environment.NewLine;
                        sqlText += " ,@DEBITNLNKSUPPSLIPNO" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERSLIPCD" + Environment.NewLine;
                        sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                        sqlText += " ,@ACCPAYDIVCD" + Environment.NewLine;
                        sqlText += " ,@STOCKSECTIONCD" + Environment.NewLine;
                        sqlText += " ,@STOCKADDUPSECTIONCD" + Environment.NewLine;
                        sqlText += " ,@STOCKSLIPUPDATECD" + Environment.NewLine;
                        sqlText += " ,@INPUTDAY" + Environment.NewLine;
                        sqlText += " ,@ARRIVALGOODSDAY" + Environment.NewLine;
                        sqlText += " ,@STOCKDATE" + Environment.NewLine;
                        sqlText += " ,@STOCKADDUPADATE" + Environment.NewLine;
                        sqlText += " ,@DELAYPAYMENTDIV" + Environment.NewLine;
                        sqlText += " ,@PAYEECODE" + Environment.NewLine;
                        sqlText += " ,@PAYEESNM" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                        sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,@BUSINESSTYPENAME" + Environment.NewLine;
                        sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,@SALESAREANAME" + Environment.NewLine;
                        sqlText += " ,@STOCKINPUTCODE" + Environment.NewLine;
                        sqlText += " ,@STOCKINPUTNAME" + Environment.NewLine;
                        sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                        sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
                        sqlText += " ,@SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                        sqlText += " ,@TTLAMNTDISPRATEAPY" + Environment.NewLine;
                        sqlText += " ,@STOCKTOTALPRICE" + Environment.NewLine;
                        sqlText += " ,@STOCKSUBTTLPRICE" + Environment.NewLine;
                        sqlText += " ,@STOCKTTLPRICTAXINC" + Environment.NewLine;
                        sqlText += " ,@STOCKTTLPRICTAXEXC" + Environment.NewLine;
                        sqlText += " ,@STOCKNETPRICE" + Environment.NewLine;
                        sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                        sqlText += " ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        sqlText += " ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        sqlText += " ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        sqlText += " ,@STOCKOUTTAX" + Environment.NewLine;
                        sqlText += " ,@STCKPRCCONSTAXINCLU" + Environment.NewLine;
                        sqlText += " ,@STCKDISTTLTAXEXC" + Environment.NewLine;
                        sqlText += " ,@ITDEDSTOCKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSTOCKDISINTAX" + Environment.NewLine;
                        sqlText += " ,@ITDEDSTOCKDISTAXFRE" + Environment.NewLine;
                        sqlText += " ,@STOCKDISOUTTAX" + Environment.NewLine;
                        sqlText += " ,@STCKDISTTLTAXINCLU" + Environment.NewLine;
                        sqlText += " ,@TAXADJUST" + Environment.NewLine;
                        sqlText += " ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += " ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        sqlText += " ,@ACCPAYCONSTAX" + Environment.NewLine;
                        sqlText += " ,@STOCKFRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " ,@AUTOPAYMENT" + Environment.NewLine;
                        sqlText += " ,@AUTOPAYSLIPNUM" + Environment.NewLine;
                        sqlText += " ,@RETGOODSREASONDIV" + Environment.NewLine;
                        sqlText += " ,@RETGOODSREASON" + Environment.NewLine;
                        sqlText += " ,@PARTYSALESLIPNUM" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERSLIPNOTE1" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERSLIPNOTE2" + Environment.NewLine;
                        sqlText += " ,@DETAILROWCOUNT" + Environment.NewLine;
                        sqlText += " ,@EDISENDDATE" + Environment.NewLine;
                        sqlText += " ,@EDITAKEINDATE" + Environment.NewLine;
                        sqlText += " ,@UOEREMARK1" + Environment.NewLine;
                        sqlText += " ,@UOEREMARK2" + Environment.NewLine;
                        sqlText += " ,@SLIPPRINTDIVCD" + Environment.NewLine;
                        sqlText += " ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                        sqlText += " ,@STOCKSLIPPRINTDATE" + Environment.NewLine;
                        sqlText += " ,@SLIPPRTSETPAPERID" + Environment.NewLine;
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
                        sqlText += " ,@DIRECTSENDINGCD)" + Environment.NewLine;

                        # endregion
                        sqlCommand.CommandText = sqlText;
                        //--- ADD 2007/09/11 M.Kubota ---<<<

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockSlipWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader != null)
                    {
                        if (!myReader.IsClosed) myReader.Close();
                        myReader.Dispose();
                    }

                    //＠仕入データ変更＠
                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                    SqlParameter paraDebitNLnkSuppSlipNo = sqlCommand.Parameters.Add("@DEBITNLNKSUPPSLIPNO", SqlDbType.Int);
                    SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@SUPPLIERSLIPCD", SqlDbType.Int);
                    SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                    SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@ACCPAYDIVCD", SqlDbType.Int);
                    SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraStockAddUpSectionCd = sqlCommand.Parameters.Add("@STOCKADDUPSECTIONCD", SqlDbType.NChar);
                    SqlParameter paraStockSlipUpdateCd = sqlCommand.Parameters.Add("@STOCKSLIPUPDATECD", SqlDbType.Int);
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                    SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                    SqlParameter paraStockDate = sqlCommand.Parameters.Add("@STOCKDATE", SqlDbType.Int);
                    SqlParameter paraStockAddUpADate = sqlCommand.Parameters.Add("@STOCKADDUPADATE", SqlDbType.Int);
                    SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                    SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                    SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                    SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                    SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                    SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                    SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);
                    SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                    SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                    SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                    SqlParameter paraStockTtlPricTaxInc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXINC", SqlDbType.BigInt);
                    SqlParameter paraStockTtlPricTaxExc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraStockNetPrice = sqlCommand.Parameters.Add("@STOCKNETPRICE", SqlDbType.BigInt);
                    SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                    SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                    SqlParameter paraStockOutTax = sqlCommand.Parameters.Add("@STOCKOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraStckPrcConsTaxInclu = sqlCommand.Parameters.Add("@STCKPRCCONSTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraStckDisTtlTaxExc = sqlCommand.Parameters.Add("@STCKDISTTLTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraItdedStockDisOutTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedStockDisInTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISINTAX", SqlDbType.BigInt);
                    SqlParameter paraItdedStockDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSTOCKDISTAXFRE", SqlDbType.BigInt);
                    SqlParameter paraStockDisOutTax = sqlCommand.Parameters.Add("@STOCKDISOUTTAX", SqlDbType.BigInt);
                    SqlParameter paraStckDisTtlTaxInclu = sqlCommand.Parameters.Add("@STCKDISTTLTAXINCLU", SqlDbType.BigInt);
                    SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                    SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                    SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                    SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                    SqlParameter paraAccPayConsTax = sqlCommand.Parameters.Add("@ACCPAYCONSTAX", SqlDbType.BigInt);
                    SqlParameter paraStockFractionProcCd = sqlCommand.Parameters.Add("@STOCKFRACTIONPROCCD", SqlDbType.Int);
                    SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                    SqlParameter paraAutoPaySlipNum = sqlCommand.Parameters.Add("@AUTOPAYSLIPNUM", SqlDbType.Int);
                    SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                    SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE1", SqlDbType.NVarChar);
                    SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE2", SqlDbType.NVarChar);
                    SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                    SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                    SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                    SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                    SqlParameter paraStockSlipPrintDate = sqlCommand.Parameters.Add("@STOCKSLIPPRINTDATE", SqlDbType.Int);
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
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
                    SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);
                    #endregion

                    //＠仕入データ変更＠
                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockSlipWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.LogicalDeleteCode);
                    paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                    paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.SectionCode);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SubSectionCode);
                    paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DebitNoteDiv);
                    paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DebitNLnkSuppSlipNo);
                    paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipCd);
                    paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockGoodsCd);
                    paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AccPayDivCd);
                    paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockSectionCd);
                    paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAddUpSectionCd);
                    paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockSlipUpdateCd);
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.InputDay);
                    paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.ArrivalGoodsDay);
                    paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockDate);
                    paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockAddUpADate);
                    paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DelayPaymentDiv);
                    paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.PayeeCode);
                    paraPayeeSnm.Value = SqlDataMediator.SqlSetString(stockSlipWork.PayeeSnm);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierCd);
                    paraSupplierNm1.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierNm1);
                    paraSupplierNm2.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierNm2);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSnm);
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.BusinessTypeCode);
                    paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(stockSlipWork.BusinessTypeName);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SalesAreaCode);
                    paraSalesAreaName.Value = SqlDataMediator.SqlSetString(stockSlipWork.SalesAreaName);
                    paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockInputCode);
                    paraStockInputName.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockInputName);
                    paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAgentCode);
                    paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAgentName);
                    paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SuppTtlAmntDspWayCd);
                    paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.TtlAmntDispRateApy);
                    paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTotalPrice);
                    paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockSubttlPrice);
                    paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTtlPricTaxInc);
                    paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTtlPricTaxExc);
                    paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockNetPrice);
                    paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockPriceConsTax);
                    paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcOutTax);
                    paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcInTax);
                    paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcTaxFree);
                    paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockOutTax);
                    paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckPrcConsTaxInclu);
                    paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckDisTtlTaxExc);
                    paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisOutTax);
                    paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisInTax);
                    paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisTaxFre);
                    paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockDisOutTax);
                    paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckDisTtlTaxInclu);
                    paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TaxAdjust);
                    paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.BalanceAdjust);
                    paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SuppCTaxLayCd);
                    paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(stockSlipWork.SupplierConsTaxRate);
                    paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.AccPayConsTax);
                    paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockFractionProcCd);
                    paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AutoPayment);
                    paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AutoPaySlipNum);
                    paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.RetGoodsReasonDiv);
                    paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(stockSlipWork.RetGoodsReason);
                    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlipWork.PartySaleSlipNum);
                    paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSlipNote1);
                    paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSlipNote2);
                    paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DetailRowCount);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.EdiSendDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.EdiTakeInDate);
                    paraUoeRemark1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UoeRemark1);
                    paraUoeRemark2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UoeRemark2);
                    paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipPrintDivCd);
                    paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipPrintFinishCd);
                    paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockSlipPrintDate);
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(stockSlipWork.SlipPrtSetPaperId);
                    paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipAddressDiv);
                    paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AddresseeCode);
                    paraAddresseeName.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeName);
                    paraAddresseeName2.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeName2);
                    paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseePostNo);
                    paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr1);
                    paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr3);
                    paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr4);
                    paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeTelNo);
                    paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeFaxNo);
                    paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DirectSendingCd);
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

        /// <summary>
        /// 仕入伝票明細情報を更新します
        /// </summary>
        /// <param name="stockDetailWorks">伝票明細更新List</param>
        /// <param name="stockSlipWork">仕入伝票情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票明細情報を更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        private int WriteStockDetailWork(ref ArrayList stockDetailWorks, StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 受注マスタリモートをインスタンス化
            AcceptOdrDB acceptOdr = new AcceptOdrDB();

            ArrayList wkal = new ArrayList();
            try
            {
                //--- ADD 2007/09/11 M.Kubota --->>>
                // 仕入明細が削除される前に、紐付く他データの更新処理を行う

                ArrayList orgDtlList = new ArrayList();
                ArrayList paraList = new ArrayList();

                if (stockSlipWork == null || stockSlipWork.SupplierFormal == 2)
                {
                    // 仕入データが存在しない場合、又は仕入形式が 2:発注 の場合、この時点で登録されている
                    // 仕入明細データを取得する
                    status = this.ReadStockDetailWork(out orgDtlList, stockDetailWorks, ref sqlConnection, ref sqlTransaction); 
                }
                else
                {
                    ArrayList[] copyStockDetailWorks = new ArrayList[0];
                    StockSlipReadWork paramWork = new StockSlipReadWork();

                    // 仕入データに紐付く仕入明細データを取得する
                    paramWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
                    paramWork.SupplierFormal = stockSlipWork.SupplierFormal;
                    paramWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;

                    status = this.ReadStockDetailWork(out orgDtlList, ref copyStockDetailWorks, paramWork, ref sqlConnection, ref sqlTransaction);
                }

                if (orgDtlList != null && orgDtlList.Count > 0)
                {
                    ArrayList Differencelist = new ArrayList();
                    
                    foreach (StockDetailWork orgDtlWork in orgDtlList)
                    {
                        bool exist = false;

                        foreach (StockDetailWork newDtlWork in stockDetailWorks)
                        {
                            if (orgDtlWork.EnterpriseCode == newDtlWork.EnterpriseCode &&
                                orgDtlWork.SupplierFormal == newDtlWork.SupplierFormal &&
                                orgDtlWork.StockSlipDtlNum == newDtlWork.StockSlipDtlNum)
                            {
                                exist = true;
                            }
                        }

                        if (!exist)
                        {
                            // UI側にて削除された分の仕入明細データを収集する
                            Differencelist.Add(this.MakeAcceptOdrWork(orgDtlWork));
                        }
                    }
                    
                    // UI側にて削除された分の仕入明細データに対応する受注マスタのレコードを論理削除する
                    acceptOdr.LogicalDeleteAcceptOdrProc(ref Differencelist, 0, ref sqlConnection, ref sqlTransaction);
                }

                if (stockSlipWork == null || (stockSlipWork != null && stockSlipWork.SupplierFormal == 2))
                {
                    // 仕入明細データしか存在しない場合は、１明細単位で一度全て削除する
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM", sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);     // 企業コード
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL ", SqlDbType.Int);      // 仕入形式
                        SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);  // 仕入明細通番

                        foreach (object item in orgDtlList)
                        {
                            StockDetailWork dtlwrk = item as StockDetailWork;

                            if (dtlwrk != null)
                            {
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwrk.EnterpriseCode);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwrk.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwrk.StockSlipDtlNum);

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    // 仕入データが存在している場合は、それに紐付く仕入明細データを一度全て削除する
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO", sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                        findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                
                ArrayList acceptOdrWorkList = new ArrayList();  // ADD 2007/09/11 M.Kubota

                for (int i = 0; i < stockDetailWorks.Count; i++)
                {
                    //更新明細情報を取得
                    StockDetailWork stockDetailWork = (StockDetailWork)stockDetailWorks[i];

                    //＠仕入明細データ変更＠
                    // para<#FieldName>.Value = SqlDataMediator.<#sqlDbTypeSetAccessor>(stockDetailWork.<#FieldName>);  // <#name>
                    # region [INSERT文]
                    //--- ADD 2008/09/12 M.Kubota --->>>
                    string sqlText = string.Empty;
                    sqlText += "INSERT INTO STOCKDETAILRF (" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,STOCKROWNORF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALSRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPCDDTLRF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKINPUTNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKAGENTNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSKINDCODERF" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,MAKERKANANAMERF" + Environment.NewLine;
                    sqlText += " ,CMPLTMAKERKANANAMERF" + Environment.NewLine;
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
                    sqlText += " ,STOCKORDERDIVCDRF" + Environment.NewLine;
                    sqlText += " ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += " ,GOODSRATERANKRF" + Environment.NewLine;
                    sqlText += " ,CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,SUPPRATEGRPCODERF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICETAXINCFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKRATERF" + Environment.NewLine;
                    sqlText += " ,RATESECTSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,RATEDIVSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,PRICECDSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
                    sqlText += " ,FRACPROCSTCKUNPRCRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,STOCKUNITCHNGDIVRF" + Environment.NewLine;
                    sqlText += " ,BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                    sqlText += " ,BFLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                    sqlText += " ,RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPCODERF" + Environment.NewLine;
                    sqlText += " ,RATEBLGROUPNAMERF" + Environment.NewLine;
                    sqlText += " ,STOCKCOUNTRF" + Environment.NewLine;
                    sqlText += " ,ORDERCNTRF" + Environment.NewLine;
                    sqlText += " ,ORDERADJUSTCNTRF" + Environment.NewLine;
                    sqlText += " ,ORDERREMAINCNTRF" + Environment.NewLine;
                    sqlText += " ,REMAINCNTUPDDATERF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXEXCRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICETAXINCRF" + Environment.NewLine;
                    sqlText += " ,STOCKGOODSCDRF" + Environment.NewLine;
                    sqlText += " ,STOCKPRICECONSTAXRF" + Environment.NewLine;
                    sqlText += " ,TAXATIONCODERF" + Environment.NewLine;
                    sqlText += " ,STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,SALESCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO1RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO2RF" + Environment.NewLine;
                    sqlText += " ,SLIPMEMO3RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO1RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO2RF" + Environment.NewLine;
                    sqlText += " ,INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEECODERF" + Environment.NewLine;
                    sqlText += " ,ADDRESSEENAMERF" + Environment.NewLine;
                    sqlText += " ,DIRECTSENDINGCDRF" + Environment.NewLine;
                    sqlText += " ,ORDERNUMBERRF" + Environment.NewLine;
                    sqlText += " ,WAYTOORDERRF" + Environment.NewLine;
                    sqlText += " ,DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                    sqlText += " ,EXPECTDELIVERYDATERF" + Environment.NewLine;
                    sqlText += " ,ORDERDATACREATEDIVRF" + Environment.NewLine;
                    sqlText += " ,ORDERDATACREATEDATERF" + Environment.NewLine;
                    sqlText += " ,ORDERFORMISSUEDDIVRF)" + Environment.NewLine;
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
                    sqlText += " ,@SUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += " ,@STOCKROWNO" + Environment.NewLine;
                    sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERFORMALSRC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPDTLNUMSRC" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUSSYNC" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPDTLNUMSYNC" + Environment.NewLine;
                    sqlText += " ,@STOCKSLIPCDDTL" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKINPUTNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKAGENTNAME" + Environment.NewLine;
                    sqlText += " ,@GOODSKINDCODE" + Environment.NewLine;
                    sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " ,@MAKERNAME" + Environment.NewLine;
                    sqlText += " ,@MAKERKANANAME" + Environment.NewLine;
                    sqlText += " ,@CMPLTMAKERKANANAME" + Environment.NewLine;
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
                    sqlText += " ,@STOCKORDERDIVCD" + Environment.NewLine;
                    sqlText += " ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " ,@GOODSRATERANK" + Environment.NewLine;
                    sqlText += " ,@CUSTRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@SUPPRATEGRPCODE" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXEXCFL" + Environment.NewLine;
                    sqlText += " ,@LISTPRICETAXINCFL" + Environment.NewLine;
                    sqlText += " ,@STOCKRATE" + Environment.NewLine;
                    sqlText += " ,@RATESECTSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@RATEDIVSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@UNPRCCALCCDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@PRICECDSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STDUNPRCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCUNITSTCUNPRC" + Environment.NewLine;
                    sqlText += " ,@FRACPROCSTCKUNPRC" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITTAXPRICEFL" + Environment.NewLine;
                    sqlText += " ,@STOCKUNITCHNGDIV" + Environment.NewLine;
                    sqlText += " ,@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                    sqlText += " ,@BFLISTPRICE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGOODSNAME" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPCD" + Environment.NewLine;
                    sqlText += " ,@RATEGOODSRATEGRPNM" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPCODE" + Environment.NewLine;
                    sqlText += " ,@RATEBLGROUPNAME" + Environment.NewLine;
                    sqlText += " ,@STOCKCOUNT" + Environment.NewLine;
                    sqlText += " ,@ORDERCNT" + Environment.NewLine;
                    sqlText += " ,@ORDERADJUSTCNT" + Environment.NewLine;
                    sqlText += " ,@ORDERREMAINCNT" + Environment.NewLine;
                    sqlText += " ,@REMAINCNTUPDDATE" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXEXC" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICETAXINC" + Environment.NewLine;
                    sqlText += " ,@STOCKGOODSCD" + Environment.NewLine;
                    sqlText += " ,@STOCKPRICECONSTAX" + Environment.NewLine;
                    sqlText += " ,@TAXATIONCODE" + Environment.NewLine;
                    sqlText += " ,@STOCKDTISLIPNOTE1" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@SALESCUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO1" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO2" + Environment.NewLine;
                    sqlText += " ,@SLIPMEMO3" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO1" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO2" + Environment.NewLine;
                    sqlText += " ,@INSIDEMEMO3" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEECODE" + Environment.NewLine;
                    sqlText += " ,@ADDRESSEENAME" + Environment.NewLine;
                    sqlText += " ,@DIRECTSENDINGCD" + Environment.NewLine;
                    sqlText += " ,@ORDERNUMBER" + Environment.NewLine;
                    sqlText += " ,@WAYTOORDER" + Environment.NewLine;
                    sqlText += " ,@DELIGDSCMPLTDUEDATE" + Environment.NewLine;
                    sqlText += " ,@EXPECTDELIVERYDATE" + Environment.NewLine;
                    sqlText += " ,@ORDERDATACREATEDIV" + Environment.NewLine;
                    sqlText += " ,@ORDERDATACREATEDATE" + Environment.NewLine;
                    sqlText += " ,@ORDERFORMISSUEDDIV)" + Environment.NewLine;
                    //--- ADD 2008/09/12 M.Kubota ---<<<
                    # endregion

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))  //ADD 2007/09/11 M.Kubota
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockDetailWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        //＠仕入明細データ変更＠
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
                        SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                        SqlParameter paraStockRowNo = sqlCommand.Parameters.Add("@STOCKROWNO", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                        SqlParameter paraAcptAnOdrStatusSync = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSYNC", SqlDbType.Int);
                        SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                        SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@STOCKSLIPCDDTL", SqlDbType.Int);
                        SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                        SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                        SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
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
                        SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@STOCKORDERDIVCD", SqlDbType.Int);
                        SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraSuppRateGrpCode = sqlCommand.Parameters.Add("@SUPPRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                        SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                        SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                        SqlParameter paraRateSectStckUnPrc = sqlCommand.Parameters.Add("@RATESECTSTCKUNPRC", SqlDbType.NChar);
                        SqlParameter paraRateDivStckUnPrc = sqlCommand.Parameters.Add("@RATEDIVSTCKUNPRC", SqlDbType.NChar);
                        SqlParameter paraUnPrcCalcCdStckUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSTCKUNPRC", SqlDbType.Int);
                        SqlParameter paraPriceCdStckUnPrc = sqlCommand.Parameters.Add("@PRICECDSTCKUNPRC", SqlDbType.Int);
                        SqlParameter paraStdUnPrcStckUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSTCKUNPRC", SqlDbType.Float);
                        SqlParameter paraFracProcUnitStcUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSTCUNPRC", SqlDbType.Float);
                        SqlParameter paraFracProcStckUnPrc = sqlCommand.Parameters.Add("@FRACPROCSTCKUNPRC", SqlDbType.Int);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStockUnitTaxPriceFl = sqlCommand.Parameters.Add("@STOCKUNITTAXPRICEFL", SqlDbType.Float);
                        SqlParameter paraStockUnitChngDiv = sqlCommand.Parameters.Add("@STOCKUNITCHNGDIV", SqlDbType.Int);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                        SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                        SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                        SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                        SqlParameter paraOrderCnt = sqlCommand.Parameters.Add("@ORDERCNT", SqlDbType.Float);
                        SqlParameter paraOrderAdjustCnt = sqlCommand.Parameters.Add("@ORDERADJUSTCNT", SqlDbType.Float);
                        SqlParameter paraOrderRemainCnt = sqlCommand.Parameters.Add("@ORDERREMAINCNT", SqlDbType.Float);
                        SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);
                        SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                        SqlParameter paraStockPriceTaxInc = sqlCommand.Parameters.Add("@STOCKPRICETAXINC", SqlDbType.BigInt);
                        SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                        SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                        SqlParameter paraTaxationCode = sqlCommand.Parameters.Add("@TAXATIONCODE", SqlDbType.Int);
                        SqlParameter paraStockDtiSlipNote1 = sqlCommand.Parameters.Add("@STOCKDTISLIPNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraSalesCustomerCode = sqlCommand.Parameters.Add("@SALESCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSalesCustomerSnm = sqlCommand.Parameters.Add("@SALESCUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                        SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                        SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                        SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                        SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                        SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);
                        SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                        SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                        SqlParameter paraDeliGdsCmpltDueDate = sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
                        SqlParameter paraExpectDeliveryDate = sqlCommand.Parameters.Add("@EXPECTDELIVERYDATE", SqlDbType.Int);
                        SqlParameter paraOrderDataCreateDiv = sqlCommand.Parameters.Add("@ORDERDATACREATEDIV", SqlDbType.Int);
                        SqlParameter paraOrderDataCreateDate = sqlCommand.Parameters.Add("@ORDERDATACREATEDATE", SqlDbType.Int);
                        SqlParameter paraOrderFormIssuedDiv = sqlCommand.Parameters.Add("@ORDERFORMISSUEDDIV", SqlDbType.Int);
                        #endregion

                        //＠仕入明細データ変更＠
                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.CreateDateTime);               // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);               // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);                          // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);                            // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);                        // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);                          // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);                          // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.LogicalDeleteCode);                     // 論理削除区分
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AcceptAnOrderNo);                         // 受注番号
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);                           // 仕入形式
                        paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierSlipNo);                           // 仕入伝票番号
                        paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockRowNo);                                   // 仕入行番号
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.SectionCode);                                // 拠点コード
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SubSectionCode);                           // 部門コード
                        paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.CommonSeqNo);                                 // 共通通番
                        paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);                         // 仕入明細通番
                        paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormalSrc);                     // 仕入形式（元）
                        paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNumSrc);                   // 仕入明細通番（元）
                        paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AcptAnOdrStatusSync);                 // 受注ステータス（同時）
                        paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.SalesSlipDtlNumSync);                 // 売上明細通番（同時）
                        paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockSlipCdDtl);                           // 仕入伝票区分（明細）
                        paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockInputCode);                          // 仕入入力者コード
                        paraStockInputName.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockInputName);                          // 仕入入力者名称
                        paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockAgentCode);                          // 仕入担当者コード
                        paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockAgentName);                          // 仕入担当者名称
                        paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsKindCode);                             // 商品属性
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsMakerCd);                               // 商品メーカーコード
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockDetailWork.MakerName);                                    // メーカー名称
                        paraMakerKanaName.Value = SqlDataMediator.SqlSetString(stockDetailWork.MakerKanaName);                            // メーカーカナ名称
                        paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(stockDetailWork.CmpltMakerKanaName);                  // メーカーカナ名称（一式）
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsNo);                                        // 商品番号
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsName);                                    // 商品名称
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsNameKana);                            // 商品名称カナ
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsLGroup);                                 // 商品大分類コード
                        paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsLGroupName);                        // 商品大分類名称
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsMGroup);                                 // 商品中分類コード
                        paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsMGroupName);                        // 商品中分類名称
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.BLGroupCode);                                 // BLグループコード
                        paraBLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.BLGroupName);                                // BLグループコード名称
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.BLGoodsCode);                                 // BL商品コード
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockDetailWork.BLGoodsFullName);                        // BL商品コード名称（全角）
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.EnterpriseGanreCode);                 // 自社分類コード
                        paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseGanreName);                // 自社分類名称
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseCode);                            // 倉庫コード
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseName);                            // 倉庫名称
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseShelfNo);                      // 倉庫棚番
                        paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockOrderDivCd);                         // 仕入在庫取寄せ区分
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OpenPriceDiv);                               // オープン価格区分
                        paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsRateRank);                            // 商品掛率ランク
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.CustRateGrpCode);                         // 得意先掛率グループコード
                        paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SuppRateGrpCode);                         // 仕入先掛率グループコード
                        paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.ListPriceTaxExcFl);                    // 定価（税抜，浮動）
                        paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.ListPriceTaxIncFl);                    // 定価（税込，浮動）
                        paraStockRate.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockRate);                                    // 仕入率
                        paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateSectStckUnPrc);                    // 掛率設定拠点（仕入単価）
                        paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateDivStckUnPrc);                      // 掛率設定区分（仕入単価）
                        paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.UnPrcCalcCdStckUnPrc);               // 単価算出区分（仕入単価）
                        paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.PriceCdStckUnPrc);                       // 価格区分（仕入単価）
                        paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StdUnPrcStckUnPrc);                    // 基準単価（仕入単価）
                        paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.FracProcUnitStcUnPrc);              // 端数処理単位（仕入単価）
                        paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.FracProcStckUnPrc);                     // 端数処理（仕入単価）
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockUnitPriceFl);                      // 仕入単価（税抜，浮動）
                        paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockUnitTaxPriceFl);                // 仕入単価（税込，浮動）
                        paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockUnitChngDiv);                       // 仕入単価変更区分
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.BfStockUnitPriceFl);                  // 変更前仕入単価（浮動）
                        paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.BfListPrice);                                // 変更前定価
                        paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateBLGoodsCode);                         // BL商品コード（掛率）
                        paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateBLGoodsName);                        // BL商品コード名称（掛率）
                        paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateGoodsRateGrpCd);                   // 商品掛率グループコード（掛率）
                        paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateGoodsRateGrpNm);                  // 商品掛率グループ名称（掛率）
                        paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateBLGroupCode);                         // BLグループコード（掛率）
                        paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateBLGroupName);                        // BLグループ名称（掛率）
                        paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockCount);                                  // 仕入数
                        paraOrderCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderCnt);                                      // 発注数量
                        paraOrderAdjustCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderAdjustCnt);                          // 発注調整数
                        paraOrderRemainCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderRemainCnt);                          // 発注残数
                        paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.RemainCntUpdDate);        // 残数更新日
                        paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceTaxExc);                       // 仕入金額（税抜き）
                        paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceTaxInc);                       // 仕入金額（税込み）
                        paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockGoodsCd);                               // 仕入商品区分
                        paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceConsTax);                     // 仕入金額消費税額
                        paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.TaxationCode);                               // 課税区分
                        paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockDtiSlipNote1);                    // 仕入伝票明細備考1
                        paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SalesCustomerCode);                     // 販売先コード
                        paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(stockDetailWork.SalesCustomerSnm);                      // 販売先略称
                        paraSlipMemo1.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo1);                                    // 伝票メモ１
                        paraSlipMemo2.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo2);                                    // 伝票メモ２
                        paraSlipMemo3.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo3);                                    // 伝票メモ３
                        paraInsideMemo1.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo1);                                // 社内メモ１
                        paraInsideMemo2.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo2);                                // 社内メモ２
                        paraInsideMemo3.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo3);                                // 社内メモ３
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierCd);                                   // 仕入先コード
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockDetailWork.SupplierSnm);                                // 仕入先略称
                        paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AddresseeCode);                             // 納品先コード
                        paraAddresseeName.Value = SqlDataMediator.SqlSetString(stockDetailWork.AddresseeName);                            // 納品先名称
                        paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.DirectSendingCd);                         // 直送区分
                        paraOrderNumber.Value = SqlDataMediator.SqlSetString(stockDetailWork.OrderNumber);                                // 発注番号
                        paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.WayToOrder);                                   // 注文方法
                        paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.DeliGdsCmpltDueDate);  // 納品完了予定日
                        paraExpectDeliveryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.ExpectDeliveryDate);    // 希望納期
                        paraOrderDataCreateDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OrderDataCreateDiv);                   // 発注データ作成区分
                        paraOrderDataCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.OrderDataCreateDate);  // 発注データ作成日
                        paraOrderFormIssuedDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OrderFormIssuedDiv);                   // 発注書発行済区分
                        #endregion

                        //暗号化キーパラメータ設定
                        //SqlParameter encKeyStockDetailRF = sqlCommand.Parameters.Add("@STOCKDETAILRF_ENCRYPTKEY", SqlDbType.Char);
                        //encKeyStockDetailRF.Value = sqlEncryptInfo.GetSymKeyName("STOCKDETAILRF");

                        sqlCommand.ExecuteNonQuery();
                        wkal.Add(stockDetailWork);

                        // 仕入データの登録が完了した時点で受注マスタに明細通番の登録を行う。
                        acceptOdrWorkList.Add(this.MakeAcceptOdrWork(stockDetailWork));
                    }
                }

                //--- ADD 2007/09/11 M.Kubota --->>>
                // 複数の受注マスタデータを一度に登録する
                status = acceptOdr.WriteAcceptOdrProc(ref acceptOdrWorkList, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkal.Clear();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            stockDetailWorks = wkal;

            return status;
        }

        # region DELETE 2007/09/11 M.Kubota
        /*
        /// <summary>
        /// 仕入伝票詳細情報を更新します
        /// </summary>
        /// <param name="stockExplaDataWorks">伝票詳細更新List</param>
        /// <param name="stockSlipWork">仕入伝票情報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票詳細情報を更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.28</br>
        private int WriteStockExplaDataWork(ref ArrayList stockExplaDataWorks, StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList wkal = new ArrayList();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKEXPLADATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO ", sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                            
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                    sqlCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < stockExplaDataWorks.Count; i++)
                {
                    //更新詳細情報を取得
                    StockExplaDataWork stockExplaDataWork = (StockExplaDataWork)stockExplaDataWorks[i];

                    // 仕入伝票番号をセット
                    if (stockExplaDataWork.SupplierSlipNo == 0)
                    {
                        stockExplaDataWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
                    }

                    //新規作成時のSQL文を生成
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO STOCKEXPLADATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, STCKSLIPEXPNUMRF, PRODUCTNUMBER1RF, PRODUCTNUMBER2RF, STOCKTELNO1RF, STOCKTELNO2RF, STOCKEXPSLIPNOTERF, PRODUCTSTOCKGUIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @STOCKROWNO, @STCKSLIPEXPNUM, @PRODUCTNUMBER1, @PRODUCTNUMBER2, @STOCKTELNO1, @STOCKTELNO2, @STOCKEXPSLIPNOTE, @PRODUCTSTOCKGUID)", sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockExplaDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                        SqlParameter paraStockRowNo = sqlCommand.Parameters.Add("@STOCKROWNO", SqlDbType.Int);
                        SqlParameter paraStckSlipExpNum = sqlCommand.Parameters.Add("@STCKSLIPEXPNUM", SqlDbType.Int);
                        SqlParameter paraProductNumber1 = sqlCommand.Parameters.Add("@PRODUCTNUMBER1", SqlDbType.NChar);
                        SqlParameter paraProductNumber2 = sqlCommand.Parameters.Add("@PRODUCTNUMBER2", SqlDbType.NChar);
                        SqlParameter paraStockTelNo1 = sqlCommand.Parameters.Add("@STOCKTELNO1", SqlDbType.NChar);
                        SqlParameter paraStockTelNo2 = sqlCommand.Parameters.Add("@STOCKTELNO2", SqlDbType.NChar);
                        SqlParameter paraStockExpSlipNote = sqlCommand.Parameters.Add("@STOCKEXPSLIPNOTE", SqlDbType.NVarChar);
                        SqlParameter paraProductStockGuid = sqlCommand.Parameters.Add("@PRODUCTSTOCKGUID", SqlDbType.UniqueIdentifier);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockExplaDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockExplaDataWork.UpdateDateTime);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockExplaDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockExplaDataWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.SectionCode);
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockExplaDataWork.SupplierFormal);
                        paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockExplaDataWork.SupplierSlipNo);
                        paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(stockExplaDataWork.StockRowNo);
                        paraStckSlipExpNum.Value = SqlDataMediator.SqlSetInt32(stockExplaDataWork.StckSlipExpNum);
                        paraProductNumber1.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.ProductNumber1);
                        paraProductNumber2.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.ProductNumber2);
                        paraStockTelNo1.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.StockTelNo1);
                        paraStockTelNo2.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.StockTelNo2);
                        paraStockExpSlipNote.Value = SqlDataMediator.SqlSetString(stockExplaDataWork.StockExpSlipNote);
                        paraProductStockGuid.Value = SqlDataMediator.SqlSetGuid(stockExplaDataWork.ProductStockGuid);
                        #endregion

                        //暗号化キーパラメータ設定
                        //SqlParameter encKeyStockDetailRF = sqlCommand.Parameters.Add("@STOCKEXPLADATARF_ENCRYPTKEY", SqlDbType.Char);
                        //encKeyStockDetailRF.Value = sqlEncryptInfo.GetSymKeyName("STOCKEXPLADATARF");

                        sqlCommand.ExecuteNonQuery();
                        wkal.Add(stockExplaDataWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            stockExplaDataWorks = wkal;

            return status;
        }
        */
        #endregion
        #endregion

        #region [Delete]　削除処理　ヘッダ・明細・詳細
        /// <summary>
        /// 仕入伝票・仕入伝票明細・仕入伝票詳細を物理削除初期処理
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
        /// <br>Note       : 仕入伝票・仕入伝票明細・仕入伝票詳細を物理削除初期処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        public int DeleteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int listPos_StockSlipDeleteWork = -1;

            StockSlipDeleteWork stockSlipDeleteWork = null;

            //●更新前情報読込パラメータ格納用
            StockSlipReadWork stockSlipReadWork = null;

            originList = new CustomSerializeArrayList();
            //●削除前データ格納用
            StockSlipWork oldStockSlipWork = new StockSlipWork();
            ArrayList oldStockDetailWorkList = new ArrayList();
            
            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                return status;
            }

            //●削除オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 削除対象パラメータが未指定です", status);
                return status;
            }
            else if (paraList.Count > 0)
            {
                if (paraList[position] is StockSlipDeleteWork)
                {
                    // 仕入・入荷データ削除処理の場合
                    stockSlipDeleteWork = paraList[position] as StockSlipDeleteWork;
                    listPos_StockSlipDeleteWork = position;

                    //●削除前仕入伝票の読込・格納(originList)
                    //if (stockSlipDeleteWork != null)
                    // 2009/02/18 入庫更新対応>>>>>>>>>>>>>>>>>>>>
                    //消込処理時に仕入伝票削除と同様のロジックを通すように修正
                    //if (stockSlipDeleteWork.SupplierFormal != 2)
                    if (stockSlipDeleteWork.SupplierFormal != 2 || stockSlipDeleteWork.SupplierSlipNo != 0)
                    // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        //仕入伝票が存在するかチェックし、originListに追加する
                        StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                        ArrayList[] copyStockDetailWorkList = new ArrayList[0];

                        stockSlipReadWork = StockSlipReadWorkOutPut(stockSlipDeleteWork);

                        //既存仕入伝票の読込
                        status = this.ReadStockSlipWork(out oldStockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.ReadStockDetailWork(out oldStockDetailWorkList, ref copyStockDetailWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);

                        #region DEL
                        /*--- DEL 2007/09/11 M.Kubota --->>>
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            this.ReadStockExplaDataWork(out oldStockExplaDataWorkList, ref copyStockExplaDataWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction);
                          --- DEL 2007/09/11 M.Kubota ---<<<*/

                        //--- DEL 2008/06/03 M.Kubota --->>>
                        // add 2007.05.25 saitoh >>>>>>>>>>
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    //●拠点制御設定マスタより仕入拠点コードを抽出
                        //    //if (stockSlipWork.SupplierSlipNo == 0 && stockSlipWork.StockGoodsCd == 0)
                        //    if (oldStockSlipWork.StockGoodsCd == 0)
                        //    {
                        //        status = this.SearchStockSecCd(ref oldStockSlipWork, ref tempStockSlipWork, ref sqlConnection, ref sqlTransaction);
                        //    }

                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //    {
                        //        retMsg = "拠点制御設定が正しく設定されておりません。";
                        //        return status;
                        //    }
                        //}
                        // add 2007.05.25 saitoh <<<<<<<<<<
                        //--- DEL 2008/06/03 M.Kubota ---<<<
                        #endregion

                        originList.Add(oldStockSlipWork);
                        originList.Add(oldStockDetailWorkList);

                        # region [---DEL 2009/01/30 --- 在庫データ作成処理で、返品元伝票を必要としなくなった他、売上リアル更新内でも不具合に原因になる為 削除]
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.02.27
                        //// 返品の場合は、返品元となった伝票の読み込みを行う
                        //// ( ※返品伝票自体の修正ならば、originListには変更前返品と返品元伝票の両方が入る )
                        //if ( oldStockSlipWork.SupplierSlipCd == 20 )
                        //{
                        //    StockSlipWork retOriginStockSlipWork = null;
                        //    ArrayList retOriginStockDetailWorkList = null;
                        //    status = ReadStockSlipFromReturn( oldStockSlipWork, oldStockDetailWorkList, out retOriginStockSlipWork, out retOriginStockDetailWorkList, ref sqlConnection, ref sqlTransaction );

                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        if (retOriginStockSlipWork != null)
                        //            originList.Add(retOriginStockSlipWork);

                        //        if (retOriginStockDetailWorkList != null && retOriginStockDetailWorkList.Count > 0)
                        //            originList.Add(retOriginStockDetailWorkList);
                        //    }
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.02.27
                        #endregion

                        //--- ADD 2009/01/30 --->>>
                        // 計上元明細データの読み込み
                        ArrayList addUpStockDetailWorks = null;
                        status = this.ReadAddUpStockDetailWork(out addUpStockDetailWorks, oldStockDetailWorkList, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(addUpStockDetailWorks))
                        {
                            originList.Add(addUpStockDetailWorks);
                        }
                        //--- ADD 2009/01/30 ---<<<

                    }
                    else
                    {
                        // 発注データ削除処理の場合
                        foreach (object item in paraList)
                        {
                            if (item is ArrayList && (item as ArrayList).Count > 0 && (item as ArrayList)[0] is StockDetailWork)
                            {
                                // 既存発注データ(仕入明細データ)の読込
                                ArrayList paraArray = item as ArrayList;

                                status = this.ReadStockDetailWork(out oldStockDetailWorkList, paraArray, ref sqlConnection, ref sqlTransaction);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    oldStockSlipWork = new StockSlipWork();
                                    oldStockSlipWork.EnterpriseCode = stockSlipDeleteWork.EnterpriseCode;
                                    oldStockSlipWork.SupplierFormal = stockSlipDeleteWork.SupplierFormal;
                                    oldStockSlipWork.SupplierSlipNo = stockSlipDeleteWork.SupplierSlipNo;
                                    oldStockSlipWork.DebitNoteDiv = stockSlipDeleteWork.DebitNoteDiv;
                                    oldStockSlipWork.StockGoodsCd = 0;

                                    if (oldStockSlipWork.DebitNoteDiv != 1)
                                    {
                                        oldStockSlipWork.UpdateDateTime = stockSlipDeleteWork.UpdateDateTime;
                                    }

                                    oldStockSlipWork.SectionCode = (paraArray[0] as StockDetailWork).SectionCode;

                                    //--- DEL 2008/06/03 M.Kubota --->>>
                                    ////●拠点制御設定マスタより仕入拠点コードを抽出
                                    //status = this.SearchStockSecCd(ref oldStockSlipWork, ref tempStockSlipWork, ref sqlConnection, ref sqlTransaction);

                                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    //{
                                    //    retMsg = "拠点制御設定が正しく設定されておりません。";
                                    //    return status;
                                    //}
                                    //--- DEL 2008/06/03 M.Kubota ---<<<

                                    originList.Add(oldStockSlipWork);
                                    originList.Add(oldStockDetailWorkList);
                                }
                            }
                        }
                    }
                }
                else if (paraList[0] is StockDetailWork)
                {
                    // 発注データ削除処理の場合

                    // 既存発注データ(仕入明細データ)の読込
                    /*
                    ArrayList paraArray = paraList as ArrayList;
                    
                    status = this.ReadStockDetailWork(out oldStockDetailWorkList, paraArray, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        originList.Add(oldStockDetailWorkList);
                    }
                    */ 
                }
            }

            // 仕入差分数を算出する
            if (oldStockDetailWorkList != null && oldStockDetailWorkList.Count > 0)
            {
                foreach (object item in oldStockDetailWorkList)
                {
                    StockDetailWork dtlwork = item as StockDetailWork;

                    if (dtlwork != null)
                    {
                        dtlwork.StockCountDifference = dtlwork.StockCount;
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入伝票・仕入伝票明細・仕入伝票詳細を物理削除します
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
        /// <br>Note       : 仕入伝票・仕入伝票明細・仕入伝票詳細を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        public int Delete(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList paraList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            retMsg = "";
            retItemInfo = "";
            //●更新対象クラスが無い場合は無処理
            if (position < 0) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StockSlipDeleteWork stockSlipDeleteWork = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                return status;
            }

            //●論理削除オブジェクトの取得(カスタムArray内から検索)
            if (paraList == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 仕入伝票物理削除対象パラメータが未指定です", status);
                return status;
            }
            //●伝票更新List内のクラスを抽出
            else if (paraList.Count > 0) stockSlipDeleteWork = paraList[position] as StockSlipDeleteWork;
            if (stockSlipDeleteWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 仕入伝票物理削除オブジェクトパラメータが未指定です。", status);
                return status;
            }

            #region 仕入伝票削除パラメータの伝票番号Listを生成
            //2007.02.09　現在未対応　Saito
            #endregion

           
            ArrayList deleteStockDetailList = null;

            // 発注書未発行の発注データ(仕入明細データ)を処理対象とする場合
            if (stockSlipDeleteWork.SupplierFormal == 2 && stockSlipDeleteWork.SupplierSlipNo <= 0)
            {
                foreach (object item in paraList)
                {
                    if (item is ArrayList && (item as ArrayList).Count > 0 && (item as ArrayList)[0] is StockDetailWork)
                    {
                        deleteStockDetailList = item as ArrayList;
                        break;
                    }
                }
                
                // 発注データ(仕入明細データ)の論理削除
                status = this.DeleteStockDetailWork(deleteStockDetailList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }
            else
            {
                StockSlipWork stockSlipWork = new StockSlipWork();

                stockSlipWork.EnterpriseCode = stockSlipDeleteWork.EnterpriseCode;
                stockSlipWork.UpdateDateTime = stockSlipDeleteWork.UpdateDateTime;
                stockSlipWork.SupplierFormal = stockSlipDeleteWork.SupplierFormal;
                stockSlipWork.SupplierSlipNo = stockSlipDeleteWork.SupplierSlipNo;
                
                //●論理削除
                //仕入伝票論理削除
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                //status = DeleteStockSlipWork(stockSlipDeleteWork, out stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                status = DeleteStockSlipWork(stockSlipDeleteWork, out stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                // 削除対象の仕入明細データを取得する (※仕入伝票番号だけで削除する方法は辞める)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList[] copyStockDetailWorks = new ArrayList[0];
                    status = ReadStockDetailWork(out deleteStockDetailList, ref copyStockDetailWorks, this.StockSlipReadWorkOutPut(stockSlipDeleteWork), ref sqlConnection, ref sqlTransaction);
                }

                //仕入伝票明細論理削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //status = DeleteStockDetailWork(stockSlipDeleteWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    status = this.DeleteStockDetailWork(deleteStockDetailList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki ADD 2008.03.06
                // 残数管理区分＝「０：する」ならば在庫を戻す
                if ( this.IOWriteCtrlOptWork.RemainCntMngDiv == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki ADD 2008.03.06
                {
                    //--- ADD 2007/09/11 M.Kubota --->>>
                    //計上元仕入明細データの発注残数更新 (計上元の有無は呼出し先で行っている)
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        ArrayList stockDetailWorks = null;

                        if ( originList != null )
                        {
                            foreach ( object item in originList )
                            {
                                if ( item is ArrayList )
                                {
                                    if ( (item as ArrayList)[0] is StockDetailWork )
                                    {
                                        stockDetailWorks = item as ArrayList;
                                        break;
                                    }
                                }
                            }
                        }

                        if (stockDetailWorks != null)
                        {
                            status = this.UpdateOrderRemainCnt(stockSlipWork, stockDetailWorks, 1, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        }
                    }
                    //--- ADD 2007/09/11 M.Kubota ---<<<
                }

                //赤伝削除の場合元黒伝の赤黒連結仕入伝票番号を初期化する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (stockSlipDeleteWork.DebitNoteDiv == 1)
                    {
                        status = DeleteDebitNLnkSuppSlipNo(stockSlipDeleteWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入伝票を物理削除します
        /// </summary>
        /// <param name="stockSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="stockSlipWork">削除済み伝票データ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        /// <br>Update Note: 2011/07/27 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //private int DeleteStockSlipWork(StockSlipDeleteWork stockSlipDeleteWork, out StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo) // DEL 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        private int DeleteStockSlipWork(StockSlipDeleteWork stockSlipDeleteWork, out StockSlipWork stockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        {
            //●まずは1伝票番号だけを削除できるようにする(List化未対応)
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            stockSlipWork = null;

            try
            {
                //●まずは1伝票番号だけを削除できるようにする(List化未対応)
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SLIP.*" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND SLIP.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //KEYコマンドを設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipDeleteWork.EnterpriseCode);
                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierFormal);
                findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierSlipNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    stockSlipWork = this.StockSlipReadResultPut(myReader);

                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    if (stockSlipWork.UpdateDateTime != stockSlipDeleteWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                    // 仕入伝票を更新する前に、送信済みのチェックを行う
                    if (!CheckStockSending(stockSlipWork, out errMessage))
                    {
                        // チェックNG
                        status = STATUS_CHK_SEND_ERR;
                        sqlCommand.Cancel();
                        return status;
                    }
                    // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                    //現在の論理削除区分を取得
                    //logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    // 更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockSlipWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    // 論理削除区分の設定
                    stockSlipWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;

                    sqlText = "";
                    sqlText += "UPDATE" + Environment.NewLine;
                    sqlText += "  STOCKSLIPRF" + Environment.NewLine;
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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.LogicalDeleteCode);

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

        # region [DEL 2007/09/11]
        /*
        /// <summary>
        /// 仕入伝票明細を論理削除します
        /// </summary>
        /// <param name="stockSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票明細を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        private int DeleteStockDetailWork(StockSlipDeleteWork stockSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
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
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //KEYコマンドを設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipDeleteWork.EnterpriseCode);
                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierFormal);
                findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierSlipNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    StockSlipWork orgWork = new StockSlipWork();

                    orgWork.EnterpriseCode = stockSlipDeleteWork.EnterpriseCode;
                    orgWork.SupplierFormal = stockSlipDeleteWork.SupplierFormal;
                    orgWork.SupplierSlipNo = stockSlipDeleteWork.SupplierSlipNo;
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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(orgWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(orgWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(orgWork.SupplierSlipNo);

                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(orgWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(orgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(orgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(orgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(orgWork.LogicalDeleteCode);

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
                //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                //    SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                    
                //    //Parameterオブジェクトへ値設定
                //    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipDeleteWork.EnterpriseCode);
                //    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierFormal);
                //    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierSlipNo);
                    
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

        /// <summary>
        /// 仕入明細データを論理削除します。
        /// </summary>
        /// <param name="stockdetailworkList">削除対象の仕入明細データのリスト</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        private int DeleteStockDetailWork(ArrayList stockdetailworkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            if (stockdetailworkList.Count > 0)
            {
                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    ArrayList AcceptOdrList = new ArrayList();  // 削除対象の受注マスタデータリスト
                    
                    foreach (object item in stockdetailworkList)
                    {
                        StockDetailWork dtlwork = item as StockDetailWork;

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
                            sqlText += "  STOCKDETAILRF AS DTIL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //Prameterオブジェクトの作成
                            sqlCommand.Parameters.Clear();
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            //KEYコマンドを設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);   // 企業コード
                            findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwork.SupplierFormal);    // 仕入形式
                            findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.StockSlipDtlNum);  // 明細通番

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                StockSlipWork orgWork = new StockSlipWork();
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
                                sqlText += "  STOCKDETAILRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;

                                sqlCommand.Cancel();
                                sqlCommand.CommandText = sqlText;

                                //Prameterオブジェクトの作成
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);   // 企業コード
                                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwork.SupplierFormal);    // 仕入形式
                                findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.StockSlipDtlNum);  // 明細通番

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
                    AcceptOdrDB acceptOdr = new AcceptOdrDB();
                    acceptOdr.LogicalDeleteAcceptOdrProc(ref AcceptOdrList, 0, ref sqlConnection, ref sqlTransaction);
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


        # region DELETE 2007/09/11 M.Kubota
        /*
        /// <summary>
        /// 仕入伝票詳細を物理削除します
        /// </summary>
        /// <param name="stockSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票詳細を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        private int DeleteStockExplaDataWork(StockSlipDeleteWork stockSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            //●まずは1伝票番号だけを削除できるようにする(List化未対応)

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                //●まずは1伝票番号だけを削除できるようにする(List化未対応)
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM STOCKEXPLADATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO", sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                    
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipDeleteWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierSlipNo);
                    
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

        /// <summary>
        /// 元黒伝の赤黒連結仕入伝票番号をリセットします
        /// </summary>
        /// <param name="stockSlipDeleteWork">伝票削除パラメータ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 元黒伝の赤黒連結仕入伝票番号をリセットします</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.31</br>
        private int DeleteDebitNLnkSuppSlipNo(StockSlipDeleteWork stockSlipDeleteWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
				// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
				IFileHeader flhd = (IFileHeader)new StockSlipWork();
				new FileHeader(this).SetUpdateHeader(ref flhd, this);
				// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<

				// UPD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
				//using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKSLIPRF SET DEBITNLNKSUPPSLIPNORF=0 , DEBITNOTEDIVRF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND DEBITNLNKSUPPSLIPNORF=@FINDSUPPLIERSLIPNO ", sqlConnection, sqlTransaction))
				using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKSLIPRF SET DEBITNLNKSUPPSLIPNORF=0 , DEBITNOTEDIVRF=0 ,UPDATEDATETIMERF = @UPDATEDATETIME ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1 ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND DEBITNLNKSUPPSLIPNORF=@FINDSUPPLIERSLIPNO ", sqlConnection, sqlTransaction))
				// UPD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
				{
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
					// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
					SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<


                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipDeleteWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierFormal);
                    findParaSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipDeleteWork.SupplierSlipNo);
					// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 --------->>>>>
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
					// ADD 2011/08/31 zll SCM対応 - 拠点管理(10704767-00) #23896 ---------<<<<<


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
        #endregion

        #region [仕入パラメータ取得]
        /// <summary>
        /// 仕入パラメータ取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <returns>STATUS</returns>
        private StockSlipWork MakeStockSlipWork(CustomSerializeArrayList paraList)
        {
            Int32 position;
            return MakeStockSlipWork(paraList, out position);
        }

        /// <summary>
        /// 仕入パラメータ取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <param name="position">仕入パラメータ位置</param>
        /// <returns>STATUS</returns>
        private StockSlipWork MakeStockSlipWork(CustomSerializeArrayList paraList, out Int32 position)
        {
            StockSlipWork stockSlipWork = null;
            position = -1;

            //仕入パラメータ生成
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockSlipWork)
                {
                    stockSlipWork = paraList[i] as StockSlipWork;
                    position = i;
                    break;
                }
            }
            return stockSlipWork;
        }

        /// <summary>
        /// 仕入読込パラメータ位置取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <returns>position</returns>
        private int MakeStockSlipReadPosi(CustomSerializeArrayList paraList)
        {
            int position = -1;

            //仕入パラメータ生成
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockSlipReadWork)
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
        /// <param name="stockSlipWork">伝票情報戻り値</param>
        /// <param name="stockSlipPos">伝票情報位置</param>
        /// <param name="stockDetailWork">伝票明細戻り値</param>
        /// <param name="stockDetailPos">伝票明細位置</param>
        /// <returns></returns>
        private bool MakeStockSlipData(CustomSerializeArrayList paraList, 
                                       out StockSlipWork stockSlipWork, out Int32 stockSlipPos,
                                       out ArrayList stockDetailWork, out Int32 stockDetailPos)
        {
            //戻り値初期化
            stockSlipWork = null;
            stockDetailWork = null;
            
            stockSlipPos = -1;
            stockDetailPos = -1;

            //伝票パラメータ生成
            for (Int32 i = 0; i < paraList.Count; i++)
            {
                //伝票情報取得
                if (stockSlipWork == null && paraList[i] is StockSlipWork)
                {
                    stockSlipWork = paraList[i] as StockSlipWork;
                    stockSlipPos = i;
                    if (stockSlipPos >= 0 && stockDetailPos >= 0) break;                              //ADD 2007/09/11 M.Kubota
                }

                if (stockDetailWork == null && paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                {
                    stockDetailWork = paraList[i] as ArrayList;
                    stockDetailPos = i;
                    if (stockSlipPos >= 0 && stockDetailPos >= 0) break;                              //ADD 2007/09/11 M.Kubota
                }
            }

            //ﾃﾞｰﾀ有無判定
            if (stockSlipPos >= 0 && stockDetailPos >= 0) return true;
            else return false;
        }

        /// <summary>
        /// 伝票パラメータ一式取得
        /// </summary>
        /// <param name="paraList">パラメータList</param>
        /// <param name="supplierSlipNo">検索伝票番号</param>
        /// <param name="stockSlipWork">伝票情報戻り値</param>
        /// <param name="stockSlipPos">伝票情報位置</param>
        /// <returns>T:ﾃﾞｰﾀ有り F:ﾃﾞｰﾀ無し</returns>
        private bool MakeOrgStockSlipData(CustomSerializeArrayList paraList, Int32 supplierSlipNo, out StockSlipWork stockSlipWork, out Int32 stockSlipPos)
        {
            //戻り値初期化
            stockSlipWork = null;
            //stockDetailWork = null;
            //stockExplaDataWork = null;
            stockSlipPos = -1;
            //stockDetailPos = -1;
            //stockExplaDataPos = -1;

            //伝票番号無しの場合はﾃﾞｰﾀ無し
            //if (supplierSlipNo == 0) return false;

            //伝票パラメータ生成
            for (Int32 i = 0; i < paraList.Count; i++)
            {
                //伝票情報取得
                if (stockSlipWork == null && paraList[i] is StockSlipWork)
                {
                        stockSlipWork = paraList[i] as StockSlipWork;
                        stockSlipPos = i;
                        if (stockSlipPos >= 0) break;
                }
                /*
                if (stockDetailWork == null && paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockDetailWork)
                {
                    if (((StockDetailWork)((ArrayList)paraList[i])[0]).SupplierSlipNo.Equals(supplierSlipNo))
                    {
                        stockDetailWork = paraList[i] as ArrayList;
                        stockDetailPos = i;
                        if (stockSlipPos >= 0 && stockDetailPos >= 0 && stockExplaDataPos >= 0) break;
                    }
                }
                if (stockExplaDataWork == null && paraList[i] is ArrayList && ((ArrayList)paraList[i]).Count > 0 && ((ArrayList)paraList[i])[0] is StockExplaDataWork)
                {
                    if (((StockExplaDataWork)((ArrayList)paraList[i])[0]).SupplierSlipNo.Equals(supplierSlipNo))
                    {
                        stockExplaDataWork = paraList[i] as ArrayList;
                        stockExplaDataPos = i;
                        if (stockSlipPos >= 0 && stockDetailPos >= 0 && stockExplaDataPos >= 0) break;
                    }
                }
                */
            }
            //ﾃﾞｰﾀ有無判定
            if (stockSlipPos >= 0) return true;
            else return false;
        }

        # region MakeWhereString [未使用]
        ///// <summary>
        ///// 検索条件文字列生成＋条件値設定
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommandオブジェクト</param>
        ///// <param name="stockSlipReadWork">検索条件格納クラス</param>
        ///// <param name="mode">検索条件モード 1:ヘッダ 2:明細 3:詳細</param>
        ///// <returns>Where条件文字列</returns>
        ///// <br>Note       : Where句を作成して戻します</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.01.29</br>
        //private string MakeWhereString(ref SqlCommand sqlCommand, MakerWork makerWork, ConstantManagement.LogicalMode logicalMode)
        //private string MakeWhereString(ref SqlCommand sqlCommand, StockSlipReadWork stockSlipReadWork, Int32 mode)
        //{
        //    //string wkstring = "";
        //    string retstring = "WHERE ";

        //    //企業コード
        //    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
        //    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);

        //    //仕入伝票番号
        //    if (mode > 0)
        //    {
        //        if (stockSlipReadWork.SupplierSlipNo > 0)
        //        {
        //            retstring += "AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO ";
        //            SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
        //            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);
        //        }
        //    }

        //    //仕入形式
        //    if (mode > 0)
        //    {
        //        if (stockSlipReadWork.SupplierFormal >= 0)
        //        {
        //            retstring += "AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL ";
        //            SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
        //            paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
        //        }
        //    }

        //    //仕入伝票区分
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.SupplierFormal > 0)
        //        {
        //            retstring += "AND SUPPLIERSLIPCDRF=@FINDSUPPLIERSLIPCD ";
        //            SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
        //            paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipCd);
        //        }
        //    }

        //    //赤伝区分
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.DebitNoteDiv >= 0)
        //        {
        //            retstring += "AND DEBITNOTEDIVRF=@FINDDEBITNOTEDIV ";
        //            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
        //            paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.DebitNoteDiv);
        //        }
        //    }

        //    //仕入商品区分
        //    if (mode == 1 || mode == 2)
        //    {
        //        if (stockSlipReadWork.StockGoodsCd >= 0)
        //        {
        //            retstring += "AND STOCKGOODSCDRF=@FINDSTOCKGOODSCD ";
        //            SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@FINDSTOCKGOODSCD", SqlDbType.Int);
        //            paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.StockGoodsCd);
        //        }
        //    }

        //    //仕入担当者コード
        //    if (mode == 1 || mode == 2)
        //    {
        //        if (stockSlipReadWork.StockGoodsCd > 0)
        //        {
        //            retstring += "AND STOCKAGENTCODERF=@FINDSTOCKAGENTCODE ";
        //            SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
        //            paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockAgentCode);
        //        }
        //    }

        //    //相手先伝票番号
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.PartySaleSlipNum != null)
        //        {
        //            retstring += "AND PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM ";
        //            SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
        //            paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.PartySaleSlipNum);
        //        }
        //    }

        //    //仕入拠点コード
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.StockSectionCd != null)
        //        {
        //            retstring += "AND STOCKSECTIONCDRF=@FINDSTOCKSECTIONCD ";
        //            SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);
        //            paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockSectionCd);
        //        }
        //    }

        //    //事業者コード(開始)(終了)
        //    if (mode == 1 || mode == 2)
        //    {
        //        if (stockSlipReadWork.CarrierEpCodeStart > 0 && stockSlipReadWork.CarrierEpCodeEnd > 0)
        //        {
        //            retstring += "AND (CARRIEREPCODERF>=@FINDCARRIEREPCODESTART AND CARRIERCODERF<=@FINDCARRIEREPCODEEND) ";
        //            SqlParameter paraCarrierEpCodeStart = sqlCommand.Parameters.Add("@FINDCARRIEREPCODESTART", SqlDbType.Int);
        //            SqlParameter paraCarrierEpCodeEnd = sqlCommand.Parameters.Add("@FINDCARRIEREPCODEEND", SqlDbType.Int);
        //            paraCarrierEpCodeStart.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CarrierEpCodeStart);
        //            paraCarrierEpCodeEnd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CarrierEpCodeEnd);
        //        }
        //    }

        //    //得意先コード(開始)(終了)
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.CustomerCodeStart > 0 && stockSlipReadWork.CustomerCodeEnd > 0)
        //        {
        //            retstring += "AND (CUSTOMERCODERF>=@FINDCUSTOMERCODESTART AND CUSTOMERCODERF<=@FINDCUSTOMERCODEEND) ";
        //            SqlParameter paraCustomerCodeStart = sqlCommand.Parameters.Add("@FINDCUSTOMERCODESTART", SqlDbType.Int);
        //            SqlParameter paraCustomerCodeEnd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEEND", SqlDbType.Int);
        //            paraCustomerCodeStart.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CustomerCodeStart);
        //            paraCustomerCodeEnd.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.CustomerCodeEnd);
        //        }
        //    }

        //    //倉庫コード(開始)(終了)
        //    if (mode == 1 || mode == 2)
        //    {
        //        if (stockSlipReadWork.WarehouseCodeStart != null && stockSlipReadWork.WarehouseCodeEnd != null)
        //        {
        //            retstring += "AND (WAREHOUSECODERF>=@FINDWAREHOUSECODESTART AND WAREHOUSECODERF<=@FINDWAREHOUSECODEEND) ";
        //            SqlParameter paraWarehouseCodeStart = sqlCommand.Parameters.Add("@FINDWAREHOUSECODESTART", SqlDbType.NChar);
        //            SqlParameter paraWarehouseCodeEnd = sqlCommand.Parameters.Add("@FINDWAREHOUSECODEEND", SqlDbType.NChar);
        //            paraWarehouseCodeStart.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.WarehouseCodeStart);
        //            paraWarehouseCodeEnd.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.WarehouseCodeEnd);
        //        }
        //    }

        //    //仕入日(開始)(終了)
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.StockDateStart > DateTime.MinValue && stockSlipReadWork.StockDateEnd > DateTime.MinValue)
        //        {
        //            retstring += "AND (STOCKDATERF>=@FINDSTOCKDATESTART AND STOCKDATERF<=@FINDSTOCKDATEEND) ";
        //            SqlParameter paraStockDateStart = sqlCommand.Parameters.Add("@FINDSTOCKDATESTART", SqlDbType.Int);
        //            SqlParameter paraStockDateEnd = sqlCommand.Parameters.Add("@FINDSTOCKDATEEND", SqlDbType.Int);
        //            paraStockDateStart.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockDateStart);
        //            paraStockDateEnd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockDateEnd);
        //        }
        //    }

        //    //仕入計上日(開始)(終了)
        //    if (mode == 1)
        //    {
        //        if (stockSlipReadWork.StockAddUpADateStart > DateTime.MinValue && stockSlipReadWork.StockAddUpADateEnd > DateTime.MinValue)
        //        {
        //            retstring += "AND (STOCKADDUPADATERF>=@FINDSTOCKADDUPADATESTART AND STOCKADDUPADATERF<=@FINDSTOCKADDUPADATEEND) ";
        //            SqlParameter paraStockAddUpADateStart = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATESTART", SqlDbType.Int);
        //            SqlParameter paraStockAddUpADateEnd = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEEND", SqlDbType.Int);
        //            paraStockAddUpADateStart.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockAddUpADateStart);
        //            paraStockAddUpADateEnd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipReadWork.StockAddUpADateEnd);
        //        }
        //    }

        //    //商品コード
        //    if (mode == 2)
        //    {
        //        if (stockSlipReadWork.GoodsCode != null)
        //        {
        //            retstring += "AND GOODSCODERF=@FINDGOODSCODE ";
        //            SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@FINDGOODSCODE", SqlDbType.NVarChar);
        //            paraGoodsCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.GoodsCode);
        //        }
        //    }

        //    //商品電話番号1(開始)(終了)
        //    if (mode == 3)
        //    {
        //        if (stockSlipReadWork.StockTelNo1Start != null && stockSlipReadWork.StockTelNo1End != null)
        //        {
        //            retstring += "AND (STOCKTELNO1RF>=@FINDSTOCKTELNO1START AND STOCKTELNO1RF<=@FINDSTOCKTELNO1END) ";
        //            SqlParameter paraStockTelNo1Start = sqlCommand.Parameters.Add("@FINDSTOCKTELNO1START", SqlDbType.NChar);
        //            SqlParameter paraStockTelNo1End = sqlCommand.Parameters.Add("@FINDSTOCKTELNO1END", SqlDbType.NChar);
        //            paraStockTelNo1Start.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockTelNo1Start);
        //            paraStockTelNo1End.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.StockTelNo1End);
        //        }
        //    }

        //    /*--- DEL 2007/09/11 M.Kubota --->>>
        //    //製造番号1(開始)(終了)
        //    if (mode == 3)
        //    {
        //        if (stockSlipReadWork.ProductNumber1Start != null && stockSlipReadWork.ProductNumber1End != null)
        //        {
        //            retstring += "AND (PRODUCTNUMBER1RF>=@FINDPRODUCTNUMBER1START AND PRODUCTNUMBER1RF<=@FINDPRODUCTNUMBER1END) ";
        //            SqlParameter paraProductNumber1Start = sqlCommand.Parameters.Add("@FINDPRODUCTNUMBER1START", SqlDbType.NChar);
        //            SqlParameter paraProductNumber1End = sqlCommand.Parameters.Add("@FINDPRODUCTNUMBER1END", SqlDbType.NChar);
        //            paraProductNumber1Start.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.ProductNumber1Start);
        //            paraProductNumber1End.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.ProductNumber1End);
        //        }
        //    }
        //     --- DEL 2007/09/11 M.Kubota ---<<<*/

        //    return retstring;
        //}
        # endregion


        #region --- DEL 2008.06.03 M.Kubota --->>>
        ///// <summary>
        ///// 拠点制御設定マスタから仕入拠点コードを取得する
        ///// </summary>
        ///// <param name="stockSlipWork">仕入データ</param>
        ///// <param name="oldStockSlipWork">旧仕入データ</param>
        ///// <param name="sqlConnection">コネクション情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 拠点制御設定マスタから仕入拠点コードを取得する</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.05.20</br>
        //private int SearchStockSecCd(ref StockSlipWork stockSlipWork, ref StockSlipWork oldStockSlipWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;

        //    try
        //    {
        //        using (SqlCommand sqlCommand = new SqlCommand())
        //        {
        //            sqlCommand.Connection = sqlConnection;
        //            if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

        //            sqlCommand.CommandText = "SELECT CTRLFUNCSECTIONCODERF FROM SECCTRLSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CTRLFUNCCODERF=90 ";

        //            //Prameterオブジェクトの作成
        //            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

        //            //Parameterオブジェクトへ値設定
        //            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
        //            findParaSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.SectionCode);

        //            myReader = sqlCommand.ExecuteReader();

        //            if (myReader.Read())
        //            {
        //                stockSlipWork.StockUpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
        //                if (oldStockSlipWork != null)
        //                {
        //                    if (oldStockSlipWork.CreateDateTime > DateTime.MinValue)
        //                        oldStockSlipWork.StockUpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CTRLFUNCSECTIONCODERF"));
        //                }

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (!myReader.IsClosed) myReader.Close();
        //        myReader.Dispose();
        //    }

        //    return status;
        //}
        #endregion

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
                Int32 listPos_RedStockSlipWork = -1;
                Int32 listPos_RedStockDetailWork = -1;
                //Int32 listPos_RedStockExplaDataWork = -1;  //DEL 2007/09/11 M.Kubota

                //赤伝格納用
                StockSlipWork redStockSlipWork = null;
                ArrayList redStockDetailWork = null;
                //ArrayList redStockExplaDataWork = null;  //DEL 2007/09/11 M.Kubota

                //●コネクショ1ン情報パラメータチェック
                if (sqlConnection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                    return status;
                }

                //●元黒票更新List内の仕入クラスを抽出
                int listPos_OrgStockSlipWork = -1;
                StockSlipWork orgStockSlipWork = MakeStockSlipWork(originList, out listPos_OrgStockSlipWork);
                if (orgStockSlipWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 元黒伝対象仕入オブジェクトパラメータが未指定です。", status);
                    return status;
                }

                //●赤伝票更新List内の仕入クラスを抽出
                redStockSlipWork = MakeStockSlipWork(redList, out listPos_RedStockSlipWork);
                if (redStockSlipWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 赤伝対象仕入オブジェクトパラメータが未指定です。", status);
                    return status;
                }

                //●赤伝情報取得
                //--- ADD 2007/09/11 M.Kubota --->>>
                if (!MakeStockSlipData(redList, /*redStockSlipWork.SupplierSlipNo,*/
                    out redStockSlipWork, out listPos_RedStockSlipWork,
                    out redStockDetailWork, out listPos_RedStockDetailWork))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 赤伝発行　赤伝オブジェクトパラメータが未指定です。", status);
                    return status;
                }

                // 仕入差分数を設定する
                foreach (StockDetailWork reddtlwrk in redStockDetailWork)
                {
                    reddtlwrk.StockCountDifference = reddtlwrk.StockCount;
                    reddtlwrk.OrderRemainCnt = reddtlwrk.StockCount;
                    reddtlwrk.RemainCntUpdDate = DateTime.Now;
                }
                //--- ADD 2007/09/11 M.Kubota ---<<<

                //●元黒伝情報取得
                if (!MakeOrgStockSlipData(originList, orgStockSlipWork.SupplierSlipNo, out orgStockSlipWork, out listPos_OrgStockSlipWork))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(errmsg + ": 元黒伝発行　元黒伝オブジェクトパラメータが未指定です。", status);
                }

                // add 2007.05.27 saitoh >>>>>>>>>>
                //●拠点制御設定マスタより仕入拠点コードを抽出
                //if (redStockSlipWork.StockGoodsCd == 0)
                //{
                //    status = this.SearchStockSecCd(ref redStockSlipWork, ref sqlConnection, ref sqlTransaction);
                //}
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    retMsg = "拠点制御設定が正しく設定されておりません。";
                //    return status;
                //}
                // add 2007.05.27 saitoh <<<<<<<<<<

                //●仕入伝票番号の採番
                //採番チェック
                //赤伝票更新で仕入伝票番号が入っていない場合(新規登録)
                if (redStockSlipWork.SupplierSlipNo == 0)
                {
                    string sectionCode;
                    Int32 supplierSlipNo;

                    //仕入拠点コード
                    //sectionCode = redStockSlipWork.StockAddUpSectionCd;
                    //sectionCode = redStockSlipWork.StockSectionCd;  //DEL 2009/01/15 M.Kubota
                    sectionCode = redStockSlipWork.SectionCode;  //ADD 2009/01/15 M.Kubota (ログイン拠点コード)

                    status = CreateSupplierSlipNoProc(redStockSlipWork.EnterpriseCode, sectionCode, out supplierSlipNo, redStockSlipWork.SupplierFormal, out retMsg, ref sqlConnection, ref sqlTransaction);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierSlipNo != 0)
                    {
                        //新規自動採番の仕入伝票番号を赤伝に代入
                        redStockSlipWork.SupplierSlipNo = supplierSlipNo;

                        //元黒伝の仕入伝票番号を赤伝の赤黒連結仕入伝票番号に代入
                        redStockSlipWork.DebitNLnkSuppSlipNo = orgStockSlipWork.SupplierSlipNo;

                        //赤伝の仕入伝票番号を元黒伝の赤黒連結仕入伝票番号に代入
                        //orgStockSlipWork.DebitNLnkSuppSlipNo = supplierSlipNo;
                        //orgStockSlipWork.DebitNoteDiv = 2;

                        if (redStockDetailWork != null)
                        {
                            //foreach (StockDetailWork redStockDetail in redStockDetailWork) redStockDetail.SupplierSlipNo = supplierSlipNo;

                            AcceptOdrDB acceptOdr = new AcceptOdrDB();

                            foreach (StockDetailWork redStockDetail in redStockDetailWork)
                            {
                                // 仕入伝票番号を設定
                                redStockDetail.SupplierSlipNo = supplierSlipNo;

                                /* 赤伝明細には元黒明細の共通通番が設定されている
                                // 共通通番を設定
                                if (redStockDetail.CommonSeqNo <= 0)
                                {
                                    Int64 commonseqno = 0;
                                    status = acceptOdr.GetCommonSeqNo(redStockDetail.EnterpriseCode, redStockDetail.SectionCode, out commonseqno);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && commonseqno != 0)
                                    {
                                        redStockDetail.CommonSeqNo = commonseqno;
                                    }
                                    else
                                    {
                                        retMsg = "共通通番の採番に失敗しました。";
                                        return status;
                                    }
                                }
                                */

                                // 赤伝明細には元黒明細の受注番号が設定されている

                                // 仕入明細通番を設定
                                if (redStockDetail.StockSlipDtlNum <= 0)
                                {
                                    Int64 stockslipdtlnum = 0;

                                    status = acceptOdr.GetSlipDetailNo(redStockDetail.EnterpriseCode, redStockDetail.SectionCode,
                                                                           (int)SlipDataDivide.Stock, out stockslipdtlnum);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockslipdtlnum != 0)
                                    {
                                        redStockDetail.StockSlipDtlNum = stockslipdtlnum;
                                    }
                                    else
                                    {
                                        retMsg = "仕入明細通番の採番に失敗しました。";
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
                        if (retMsg == null || retMsg == "") retMsg = "仕入伝票番号が採番できませんでした。番号設定を見直してください。";
                        return status;
                    }
                }
                //伝票更新で仕入伝票番号が入っている場合(既存伝票更新or不正データの場合はエラー出力)
                else status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


                //●元黒伝に赤伝の仕入伝票番号をセットする
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (orgStockSlipWork.DebitNLnkSuppSlipNo == 0)
                    {
                        orgStockSlipWork.DebitNLnkSuppSlipNo = redStockSlipWork.SupplierSlipNo;
                        orgStockSlipWork.DebitNoteDiv = 2;
                    }
                }

                //--- DEL 2008/06/03 M.Kubota --->>>
                // add 2007.05.27 saitoh >>>>>>>>>>
                //●拠点制御設定マスタより仕入拠点コードを抽出
                //if (redStockSlipWork.StockGoodsCd == 0)
                //{
                //    status = this.SearchStockSecCd(ref redStockSlipWork, ref orgStockSlipWork, ref sqlConnection, ref sqlTransaction);
                //}

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //{
                //    retMsg = "拠点制御設定が正しく設定されておりません。";
                //    return status;
                //}
                // add 2007.05.27 saitoh <<<<<<<<<<
                //--- DEL 2008/06/03 M.Kubota ---<<<

                //●赤伝項目設定・元黒伝項目設定
                //status = MakeRedStockSlip(ref redStockSlipWork, ref redStockDetailWork, ref redStockExplaDataWork, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //赤伝仕入格納
                    redList[listPos_RedStockSlipWork] = redStockSlipWork;
                    if (redStockDetailWork != null)
                        redList[listPos_RedStockDetailWork] = redStockDetailWork;
                    
                    //元黒伝仕入ヘッダ格納
                    originList[listPos_OrgStockSlipWork] = orgStockSlipWork;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //既存仕入伝票の読込
                    
                    StockSlipWork oldStockSlipWork;
                    StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                    StockSlipReadWork stockSlipReadWork = StockSlipReadWorkOutPut( orgStockSlipWork );

                    status = this.ReadStockSlipWork( out oldStockSlipWork, ref copyStockSlipWork, stockSlipReadWork, ref sqlConnection, ref sqlTransaction );
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        ArrayList oldStockDetailWorkList;
                        ArrayList[] copyStockDetailWorkList = new ArrayList[0];
                        this.ReadStockDetailWork( out oldStockDetailWorkList, ref copyStockDetailWorkList, stockSlipReadWork, ref sqlConnection, ref sqlTransaction );

                        if ( oldStockDetailWorkList != null )
                        {
                            originList.Add( oldStockDetailWorkList );
                        }
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                }
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
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
        
        /// <summary>
        /// 赤伝仕入伝票情報作成
        /// </summary>
        /// <param name="redStockSlipWork">赤伝仕入伝票クラス</param>
        /// <param name="redStockDetailWorks">赤伝仕入伝票明細クラスArray</param>
        /// <param name="redStockExplaDataWorks">赤伝仕入伝票詳細クラスArray</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">エラー項目名</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        private int MakeRedStockSlip(ref StockSlipWork redStockSlipWork, ref ArrayList redStockDetailWorks, ref ArrayList redStockExplaDataWorks,
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

            //sectionCode = redStockSlipWork.StockSectionCd;  //DEL 2009/01/15 M.Kubota
            sectionCode = redStockSlipWork.SectionCode;       //ADD 2009/01/15 M.Kubota

            status = CreateSupplierSlipNoProc(redStockSlipWork.EnterpriseCode, sectionCode , out supplierSlipNo, redStockSlipWork.SupplierFormal, out retMsg, ref sqlConnection, ref sqlTransaction);
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
            redStockSlipWork.CreateDateTime = DateTime.MinValue;
            //更新日時
            redStockSlipWork.UpdateDateTime = DateTime.MinValue;
            //Guid
            redStockSlipWork.FileHeaderGuid = Guid.Empty;
            //更新従業員コード
            redStockSlipWork.UpdEmployeeCode = "";
            //更新アセンブリID1
            redStockSlipWork.UpdAssemblyId1 = "";
            //更新アセンブリID2
            redStockSlipWork.UpdAssemblyId2 = "";
            //論理削除区分
            redStockSlipWork.LogicalDeleteCode = 0;

            //●赤伝変更項目セット
            //仕入伝票番号(新規採番)
            redStockSlipWork.SupplierSlipNo = supplierSlipNo;
            //赤黒連結仕入伝票番号(元黒からコピー)
            //redStockSlipWork.DebitNLnkSuppSlipNo = 元黒.supplierSlipNo;
            #endregion
            #region 赤伝伝票明細項目設定
            foreach (StockDetailWork redStockDetailWork in redStockDetailWorks)
            {
                //●赤伝明細項目初期化
                //作成日時
                redStockDetailWork.CreateDateTime = DateTime.MinValue;
                //更新日時
                redStockDetailWork.UpdateDateTime = DateTime.MinValue;
                //Guid
                redStockDetailWork.FileHeaderGuid = Guid.Empty;
                //更新従業員コード
                redStockDetailWork.UpdEmployeeCode = "";
                //更新アセンブリID1
                redStockDetailWork.UpdAssemblyId1 = "";
                //更新アセンブリID2
                redStockDetailWork.UpdAssemblyId2 = "";
                //論理削除区分
                redStockDetailWork.LogicalDeleteCode = 0;

                //●赤伝変更項目セット
                //仕入伝票番号(新規採番)
                redStockDetailWork.SupplierSlipNo = redStockSlipWork.SupplierSlipNo;
            }
            #endregion
            #region 赤伝伝票詳細項目設定 DELETE 2007/09/11 M.Kubota
            /*--- DEL 2007/09/11 M.Kubota --->>>
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
                redStockExplaDataWork.SupplierSlipNo = redStockSlipWork.SupplierSlipNo;
                //赤黒連結仕入伝票番号(元黒からコピー)
            }
              --- DEL 2007/09/11 MN.Kubota ---<<<*/ 
            #endregion

            //戻り値を戻す
            return status;
        }

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
            int listPos_RedStockSlipWork = -1;
            int listPos_RedStockDetailWork = -1;

            //●元黒伝位置格納
            int listPos_OrgStockSlipWork = -1;

            //●赤伝格納用
            StockSlipWork redStockSlipWork = null;
            ArrayList redStockDetailWork = null;
            ArrayList slpDtlAddInfWorks = null;

            //●元黒伝格納用
            StockSlipWork orgStockSlipWork = null;

            //●コネクション情報パラメータチェック
            if (sqlConnection == null || sqlTransaction == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": データベース接続情報パラメータが未指定です", status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (redList == null || redList.Count == 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 赤伝更新対象パラメータが未指定です", status);
                return status;
            }

            //●先に赤伝仕入情報を取得
            redStockSlipWork = MakeStockSlipWork(redList, out listPos_RedStockSlipWork);
            if (redStockSlipWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 赤伝更新対象仕入パラメータが未指定です。", status);
                return status;
            }

            //●更新オブジェクトの取得(カスタムArray内から検索)
            if (originList == null || originList.Count == 0)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 元黒伝更新対象パラメータが未指定です", status);
                return status;
            }

            //●元黒伝仕入情報を取得
            orgStockSlipWork = MakeStockSlipWork(originList, out listPos_OrgStockSlipWork);
            if (orgStockSlipWork == null)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 赤伝更新対象仕入パラメータが未指定です。", status);
                return status;
            }

            //●赤伝票更新List内の伝票クラスを抽出
            //--- ADD 2007/09/11 M.Kubota --->>>
            if (!MakeStockSlipData(redList, /*redStockSlipWork.SupplierSlipNo,*/
                out redStockSlipWork, out listPos_RedStockSlipWork,
                out redStockDetailWork, out listPos_RedStockDetailWork))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 更新対象赤伝オブジェクトパラメータが未指定です。", status);
                return status;
            }
            //--- ADD 2007/09/11 M.Kubota ---<<<

            //--- DEL 2007/09/11 M.Kubota --->>>
            //if (!MakeStockSlipData(redList, /*redStockSlipWork.SupplierSlipNo,*/
            //    out redStockSlipWork, out listPos_RedStockSlipWork,
            //    out redStockDetailWork, out listPos_RedStockDetailWork,
            //    out redStockExplaDataWork, out listPos_RedStockExplaDataWork))
            //{
            //    base.WriteErrorLog(null, "プログラムエラー。更新対象赤伝オブジェクトパラメータが未指定です。");
            //    return status;
            //}
            //--- DEL 2007/09/11 M.Kubota ---<<<

            //●元黒伝票更新List内の伝票クラスを抽出
            if (!MakeOrgStockSlipData(originList, orgStockSlipWork.SupplierSlipNo, out orgStockSlipWork, out listPos_OrgStockSlipWork))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 更新対象元黒伝オブジェクトパラメータが未指定です。", status);
                return status;
            }

            slpDtlAddInfWorks = ListUtils.Find(redList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

            //●赤伝Write
            //StockSlipWriteWork redStockSlipWriteWork = new StockSlipWriteWork();
            // Delete saito >>>>>>
            //redStockSlipWriteWork.PrevRpSlipKindCd = 0;
            //redStockSlipWriteWork.NextRpSlipKindCd = redStockSlipWork.RpSlipKindCd;
            //redStockSlipWriteWork.RpSlipNoReNumberingFlag = false;
            // Delete saito <<<<<<

            //仕入伝票更新
            // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
            //status = WriteStockSlipWork(ref redStockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            status = WriteStockSlipWork(ref redStockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
            // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

            //仕入伝票明細更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && redStockDetailWork != null)
                status = WriteStockDetailWork(ref redStockDetailWork, redStockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            
            //--- ADD 2007/09/11 M.Kubota --->>>
            //計上元仕入明細データの発注残数更新 (計上元の有無は呼出し先で行っている)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                status = this.UpdateOrderRemainCnt(redStockSlipWork, redStockDetailWork, slpDtlAddInfWorks, 0, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            //--- ADD 2007/09/11 M.Kubota ---<<<

            //元黒仕入伝票更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                //status = WriteStockSlipWork(ref orgStockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                status = WriteStockSlipWork(ref orgStockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out retMsg);
                // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

            //●更新結果を戻り値に戻す
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                originList[listPos_OrgStockSlipWork] = orgStockSlipWork;

                redList[listPos_RedStockSlipWork] = redStockSlipWork;
                redList[listPos_RedStockDetailWork] = redStockDetailWork;

                //赤伝仕入格納
                retRedList.Add(redStockSlipWork);
                retRedList.Add(redStockDetailWork);

                //元黒伝仕入格納
                originList.Add(orgStockSlipWork);
            }
            return status;
        }
        #endregion

        #region [更新仕入データチェックメソッド]
        // --- ADD 2012/12/14 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 仕入データの未設定項目を補足
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : 更新する仕入データの未設定項目を補足します</br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2012.12.13</br>
        private int CheckStockSlipWork(ref StockSlipWork stockSlipWork)
        {
            SqlDataReader dataReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                // 仕入先名が［NULL］または、支払先コードがゼロ・支払先略称が［NULL］の場合
                if (stockSlipWork.SupplierNm1 == null ||
                    stockSlipWork.SupplierNm2 == null ||
                    stockSlipWork.SupplierSnm == null ||
                    stockSlipWork.PayeeCode == 0 ||
                    stockSlipWork.PayeeSnm == null)
                {
                    //仕入先マスタ読込
                    status = CheckStockSlipWorkProc(ref dataReader, ref stockSlipWork);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                    dataReader.Dispose();
                }
            }
            return status;
        }
        private int CheckStockSlipWorkProc(ref SqlDataReader dataReader, ref StockSlipWork stockSlipWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            dataReader = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                SqlConnectionInfo connectionInfo = new SqlConnectionInfo();
                string connectionText = connectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                if (connectionText == null || connectionText == "")
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                connection = new SqlConnection(connectionText);
                connection.Open();

                string sqlText = string.Empty;
                command = new SqlCommand(sqlText, connection);

                command.Parameters.Clear();
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUPPLIERRF_1.*" + Environment.NewLine;
                sqlText += "  ,SUPPLIERRF_2.SUPPLIERSNMRF AS PAYSNMRF" + Environment.NewLine;
                sqlText += " FROM" + Environment.NewLine;
                sqlText += "  SUPPLIERRF AS SUPPLIERRF_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  LEFT JOIN(SELECT * FROM SUPPLIERRF WITH (READUNCOMMITTED)) AS SUPPLIERRF_2" + Environment.NewLine;
                sqlText += "  ON SUPPLIERRF_1.ENTERPRISECODERF = SUPPLIERRF_2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND SUPPLIERRF_1.SUPPLIERCDRF = SUPPLIERRF_2.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "  SUPPLIERRF_1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPPLIERRF_1.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                // 論理削除区分
                sqlText += "  AND SUPPLIERRF_1.LOGICALDELETECODERF = 0" + Environment.NewLine;

                command.CommandText = sqlText;

                SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSuppliercd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);  // 企業コード
                findSuppliercd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierCd);       // 仕入先コード

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    stockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(dataReader, dataReader.GetOrdinal("SUPPLIERNM1RF")); // 仕入先名１
                    stockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(dataReader, dataReader.GetOrdinal("SUPPLIERNM2RF")); // 仕入先名２
                    stockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(dataReader, dataReader.GetOrdinal("SUPPLIERSNMRF")); // 仕入先略称
                    stockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(dataReader, dataReader.GetOrdinal("PAYEECODERF"));    // 支払先コード
                    stockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(dataReader, dataReader.GetOrdinal("PAYSNMRF"));      // 支払先略称
                }
                else
                {
                    //該当レコードがない場合は検索終了
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return status;
        }
        // --- ADD 2012/12/14 T.Miyamoto ------------------------------<<<<<
        #endregion
                
        #region [SupplierSlipNo]　仕入伝票番号採番
        /// <summary>
        /// 仕入伝票番号を採番して返します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="supplierSlipNo">採番結果</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入伝票番号を採番して返します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.01.04</br>
        private int CreateSupplierSlipNoProc(string enterpriseCode, string sectionCode, out Int32 supplierSlipNo, Int32 supplierFormal, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            supplierSlipNo = 0;
            retMsg = "";

            // 拠点コード、見積書番号をパラメータとして渡さない採番メソッドに変更する
            //NumberNumbering numberNumbering = new NumberNumbering();  //DEL 2008/06/03 M.Kubota

            NumberingManager numberingManager = new NumberingManager(); //ADD 2008/06/03 M.Kubota

            //番号範囲分ループ
            //string firstNo = "";  //DEL 2008/06/03 M.Kubota
            long firstNo = -1;

            Int32 loopCnt = 0;	//最大ループカウンタ
            while (loopCnt <= 999999999)
            {
                //--- DEL 2008/06/03 M.Kubota --->>>
                //string no;
                //Int32 ptnCd = 0;
                //Int32 noCode = 0;

                //switch (supplierFormal)
                //{
                //    case 0:  // 仕入
                //        noCode = 500;
                //        break;
                //    case 1:  // 入荷
                //        noCode = 510;
                //        break;
                //    case 2:  // 発注
                //        noCode = 520;
                //        break;
                //}
                
                ////番号採番
                //status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out no, out ptnCd, out retMsg);
                //--- DEL 2008/06/03 M.Kubota ---<<<
                
                //--- ADD 2008/06/03 M.Kubota --->>>
                long no = -1;
                SerialNumberCode serialnumcd = SerialNumberCode.Empty;

                switch (supplierFormal)
                {
                    case 0:  // 仕入
                        serialnumcd = SerialNumberCode.SupplierSlipNo;
                        break;
                    case 1:  // 入荷
                        serialnumcd = SerialNumberCode.ArrGdsSlipNo;
                        break;
                    case 2:  // 発注
                        serialnumcd = SerialNumberCode.SalesOrderSlipNo;
                        break;
                }

                // 採番中に排他制御関係でエラーが発生した場合、規定回数リトライをする
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, serialnumcd, out no);
                //--- ADD 2008/06/03 M.Kubota ---<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //--- DEL 2008/06/03 M.Kubota --->>>
                    ////番号を数値型に変換
                    //Int32 wkSupplierSlipNo = System.Convert.ToInt32(no);
                    ////初回採番番号を保存
                    //if (firstNo == "") firstNo = no;
                    ////初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    //else if (firstNo.Equals(no))
                    //{
                    //    loopCnt = 999999999;
                    //    break;
                    //}
                    //--- DEL 2008/06/03 M.Kubota ---<<<

                    //--- ADD 2008/06/03 M.Kubota --->>>

                    //初回採番番号を保存
                    if (firstNo == -1)
                    {
                        firstNo = no;
                    }
                    //初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    else if (firstNo.Equals(no))
                    {
                        loopCnt = 999999999;
                        break;
                    }
                    //--- ADD 2008/06/03 M.Kubota ---<<<

                    SqlDataReader myReader = null;
                    //伝票空き番チェック
                    try
                    {
                        //Selectコマンドの生成
                        SqlCommand sqlCommand;

                        string sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND SLIP.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

                        using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(supplierFormal);
                            //findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(wkSupplierSlipNo);  //DEL 2008/06/03 M.Kubota
                            findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32((Int32)no);                  //ADD 2008/06/03 M.Kubota
                            
                            try
                            {
                                myReader = sqlCommand.ExecuteReader();
                                //データ無しの場合には戻り値をセット
                                if (!myReader.Read())
                                {
                                    //supplierSlipNo = wkSupplierSlipNo;  //DEL 2008/06/03 M.Kubota
                                    supplierSlipNo = (Int32)no;           //ADD 2008/06/03 M.Kubota
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
                retMsg = "仕入伝票番号に空き番号がありません。削除可能な伝票を削除してください。";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        #endregion

        #region [RedBlackWrite]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWrite(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="originList"></param>
        /// <param name="redList"></param>
        /// <param name="blackList"></param>
        /// <param name="retRedList"></param>
        /// <param name="retBlackList"></param>
        /// <param name="position"></param>
        /// <param name="param"></param>
        /// <param name="freeParam"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        public int RedBlackWriteInitial(string origin, ref CustomSerializeArrayList originList, ref CustomSerializeArrayList redList, ref CustomSerializeArrayList blackList, ref CustomSerializeArrayList retRedList, ref CustomSerializeArrayList retBlackList, int position, string param, ref object freeParam, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            retItemInfo = "";

            return status;
        }
        #endregion

        # region [仕入明細データ → 受注明細データ作成メソッド]
        /// <summary>
        /// 仕入明細データから受注明細データを作成する
        /// </summary>
        /// <param name="stockDetail"></param>
        /// <returns></returns>
        private AcceptOdrWork MakeAcceptOdrWork(StockDetailWork stockDetail)
        {
            AcceptOdrWork retWork = new AcceptOdrWork();

            retWork.EnterpriseCode = stockDetail.EnterpriseCode;
            retWork.SectionCode = stockDetail.SectionCode;
            retWork.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;

            switch (stockDetail.SupplierFormal)
            {
                // 仕入
                case 0:
                    {
                        retWork.AcptAnOdrStatus = (int)SlipDataDivide.Stock;
                        break;
                    }
                // 入荷
                case 1:
                    {
                        retWork.AcptAnOdrStatus = (int)SlipDataDivide.ArrivalGoods;
                        break;
                    }
                // 発注
                case 2:
                    {
                        retWork.AcptAnOdrStatus = (int)SlipDataDivide.SalesOrder;
                        break;
                    }
                // --- ADD 2013/02/13 ---------->>>>>
                // 仕入返品予定
                case 3:
                    {
                        retWork.AcptAnOdrStatus = (int)SlipDataDivide.StockRetPlan;
                        break;
                    }
                // --- ADD 2013/02/13 ----------<<<<<
            }

            retWork.SalesSlipNum = Convert.ToString(stockDetail.SupplierSlipNo);
            retWork.DataInputSystem = (int)DataInputSystem.PM;
            retWork.CommonSeqNo = stockDetail.CommonSeqNo;
            retWork.SlipDtlNum = stockDetail.StockSlipDtlNum;
            retWork.SlipDtlNumDerivNo = 0;
            retWork.SrcLinkDataCode = stockDetail.SupplierFormalSrc;
            retWork.SrcSlipDtlNum = stockDetail.StockSlipDtlNumSrc;

            return retWork;
        }

        # endregion

        #region [仕入計上日チェック]
        /// <summary>
        /// 仕入計上日チェック
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入計上日チェック</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.07.23</br>
        private int CheckPaymentAddUpHis(StockSlipWork stockSlipWork, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            retMsg = "";

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;
                    sqlCommand.CommandText = "SELECT MAX(CADDUPUPDDATERF) AS CADDUPUPDDATERF FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE GROUP BY ENTERPRISECODERF,ADDUPSECCODERF,CUSTOMERCODERF ";

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAddUpSectionCd);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.PayeeCode);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            DateTime cAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));

                            if (stockSlipWork.StockAddUpADate > cAddUpUpdDate)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                retMsg = "計上日が不正です。支払締次更新が既に行われています。";
                                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            }
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
        #endregion

        # region [計上元仕入明細データ 取得メソッド]
        /// <summary>
        /// 仕入明細データに紐付く計上元仕入明細データを取得します。
        /// </summary>
        /// <param name="AddUpDetailWorks">計上元仕入明細データリスト</param>
        /// <param name="DetailWorks">計上先仕入明細データリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        private int ReadAddUpStockDetailWork(out ArrayList AddUpDetailWorks, ArrayList DetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                        #region--- DEL 2008/06/03 M.Kubota --->>>
                        //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                        //if (connectionText == null || connectionText == "")
                        //{
                        //    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        //}

                        //sqlConnection = new SqlConnection(connectionText);
                        #endregion--- DEL 2008/06/03 M.Kubota ---

                        sqlConnection = this.CreateSqlConnection(true);  //ADD 2008/06/03 M.Kubota
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
                    //sqlText += "  STOCKDETAILRF AS ADDUPDTL" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF AS ADDUPDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ADDUPDTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPDTL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPDTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND ADDUPDTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                    # endregion

                    SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                    SqlDataReader myReader = null;

                    foreach (object item in DetailWorks)
                    {
                        StockDetailWork dtlWork = item as StockDetailWork;

                        if (dtlWork != null)
                        {
                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlWork.EnterpriseCode);
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlWork.SupplierFormalSrc);
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlWork.StockSlipDtlNumSrc);

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
                                    //AddUpDetailWorks.Add(AddUppOrgStockDetailReadResultPut(ref myReader));  // DEL 2009/01/30
                                    //--- ADD 2009/01/30 --->>>
                                    AddUpOrgStockDetailWork addUpOrgDtl = AddUppOrgStockDetailReadResultPut(ref myReader);
                                    addUpOrgDtl.DtlRelationGuid = dtlWork.DtlRelationGuid;  // 明細関連付けGUIDをコピーしておく
                                    AddUpDetailWorks.Add(addUpOrgDtl);
                                    //--- ADD 2009/01/30 ---<<<
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
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
            }

            return status;
        }
        # endregion

        # region [計上元仕入明細データ 発注残数更新メソッド]
        /// <summary>
        /// パラメータにより指定された仕入明細データに紐付く、計上元の仕入明細データの発注残数を更新(増減)する。
        /// </summary>
        /// <param name="stockSlipWork">計上先の仕入データ</param>
        /// <param name="stockdetailworkList">計上先の仕入明細データリスト</param>
        /// <param name="mode">0:伝票作成　1:伝票削除</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        public int UpdateOrderRemainCnt(StockSlipWork stockSlipWork, ArrayList stockdetailworkList, int mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            return this.UpdateOrderRemainCnt(stockSlipWork, stockdetailworkList, null, mode, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }
        
        /// <summary>
        /// パラメータにより指定された仕入明細データに紐付く、計上元の仕入明細データの発注残数を更新(増減)する。
        /// </summary>
        /// <param name="stockSlipWork">計上先の仕入データ</param>
        /// <param name="stockdetailworkList">計上先の仕入明細データリスト</param>
        /// <param name="slpdtladdinfList">計上元の伝票明細追加情報リスト</param>
        /// <param name="mode">0:伝票作成　1:伝票削除</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>STATUS</returns>
        private int UpdateOrderRemainCnt(StockSlipWork stockSlipWork, ArrayList stockdetailworkList, ArrayList slpdtladdinfList, int mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (stockdetailworkList != null && stockdetailworkList.Count > 0)
            {
                SqlCommand sqlCommand = null;
                SqlDataReader myReader = null;

                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();

                try
                {
                    foreach (object item in stockdetailworkList)
                    {
                        StockDetailWork dtlwork = item as StockDetailWork;

                        // 仕入形式が 0:仕入,1:入荷 で、且つ計上元の仕入明細通番が設定されて
                        // いる場合にのみ、計上元の発注残数を更新する。
                        if (dtlwork != null && 
                            (dtlwork.SupplierFormal == 0 || dtlwork.SupplierFormal == 1) &&
                            dtlwork.StockSlipDtlNumSrc > 0)
                        {
                            # region [計上元発注残数取得SQL文]
                            string sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  DTL.ORDERREMAINCNTRF" + Environment.NewLine;    // 発注残数
                            sqlText += " ,DTL.REMAINCNTUPDDATERF" + Environment.NewLine;  // 残数更新日
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKDETAILRF AS DTL" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  AND DTL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND DTL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                            # endregion

                            # region [各種パラメータの定義と設定]
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(dtlwork.EnterpriseCode);                          // 企業コード
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);  // 論理削除
                            findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dtlwork.SupplierFormalSrc);                        // 仕入形式(元)
                            findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dtlwork.StockSlipDtlNumSrc);                      // 仕入明細通番(元)
                            # endregion

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                # region [計上元発注残数更新SQL文]
                                sqlText = "";
                                sqlText += "UPDATE" + Environment.NewLine;
                                sqlText += "  STOCKDETAILRF" + Environment.NewLine;
                                sqlText += "SET" + Environment.NewLine;
                                sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " ,ORDERREMAINCNTRF = @ORDERREMAINCNT" + Environment.NewLine;
                                sqlText += " ,REMAINCNTUPDDATERF = @REMAINCNTUPDDATE" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                                sqlText += "  AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                                sqlCommand.CommandText = sqlText;
                                # endregion

                                # region [各種パラメータの定義と設定]
                                StockDetailWork updDtlWork = new StockDetailWork();

                                updDtlWork.EnterpriseCode = dtlwork.EnterpriseCode;       // 企業コード
                                updDtlWork.SupplierFormal = dtlwork.SupplierFormalSrc;    // 仕入形式 ← 仕入形式(元)
                                updDtlWork.StockSlipDtlNum = dtlwork.StockSlipDtlNumSrc;  // 仕入明細通番 ← 仕入明細通番(元)

                                // 計上元発注残数－計上先仕入差分数＝新しい計上元発注残数
                                double wrkOrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));

                                // 伝票作成
                                //wrkOrderRemainCnt -= (mode == 0 ? 1 : -1) * (stockSlipWork.DebitNoteDiv == 1 ? -1 : 1) * (stockSlipWork.SupplierSlipCd == 20 ? -1 : 1) * dtlwork.StockCountDifference;  // DEL 2010/10/08
                                // -- ADD 2010/10/08 -------------------------------------->>>
                                //売仕入同時入力の伝票を得意先電子元帳にて、掛売で赤伝発行した場合の仕入明細の残数が増える現象の修正。条件を追加
                                wrkOrderRemainCnt -= (mode == 0 ? 1 : -1)
                                                     * (stockSlipWork.DebitNoteDiv == 1 ? -1 : 1)
                                                     * (stockSlipWork.SupplierSlipCd == 20 ? -1 : 1)
                                                     * ((dtlwork.SupplierFormalSrc == 0 && dtlwork.SupplierFormal == 0 && stockSlipWork.SupplierSlipCd != 20 && stockSlipWork.DebitNoteDiv != 1) ? -1 : 1)  // ADD
                                                     * dtlwork.StockCountDifference;
                                // -- ADD 2010/10/08 --------------------------------------<<<
                                wrkOrderRemainCnt = CalculateConsTax.Fraction(wrkOrderRemainCnt, -32);  // 少数第三桁を四捨五入

                                if (ListUtils.IsNotEmpty(slpdtladdinfList))
                                {
                                    // 仕入明細データに紐付く伝票追加情報を取得する
                                    int addInfIdx = slpdtladdinfList.BinarySearch(dtlwork.DtlRelationGuid, DtlRelationGuidComp);

                                    if (addInfIdx > -1)
                                    {
                                        SlipDetailAddInfoWork addInfWork = slpdtladdinfList[addInfIdx] as SlipDetailAddInfoWork;

                                        // 計上残区分が 2:残さない の場合
                                        if (addInfWork.AddUpRemDiv == 2)
                                        {
                                            wrkOrderRemainCnt = 0;
                                        }
                                        // 2009/02/18 入庫更新対応>>>>>>>>>>>>>>>>>>>>
                                        else
                                        {
                                            //発注残調整数に値がセットされていた場合は、発注残を減算する
                                            if (addInfWork.OrderRemainAdjustCnt != 0)
                                            {
                                                wrkOrderRemainCnt -= addInfWork.OrderRemainAdjustCnt;
                                            }
                                        }
                                        // 2009/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    }
                                }

                                updDtlWork.OrderRemainCnt = wrkOrderRemainCnt;

                                // 仕入差分数が 0 でない場合は、発注残数の変更とみなして残数更新日を設定する
                                if (dtlwork.StockCountDifference != 0)
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
                                findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                                findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraOrderRemainCnt = sqlCommand.Parameters.Add("@ORDERREMAINCNT", SqlDbType.Float);
                                SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);

                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updDtlWork.EnterpriseCode);                    // 企業コード
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(updDtlWork.SupplierFormal);                     // 仕入形式
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(updDtlWork.StockSlipDtlNum);                   // 仕入明細通番
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updDtlWork.UpdateDateTime);         // 更新日付
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdEmployeeCode);                  // 更新従業員コード
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdAssemblyId1);                    // 更新アセンブリID1
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updDtlWork.UpdAssemblyId2);                    // 更新アセンブリID2
                                paraOrderRemainCnt.Value = SqlDataMediator.SqlSetDouble(updDtlWork.OrderRemainCnt);                    // 発注残数
                                paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(updDtlWork.RemainCntUpdDate);  // 残数更新日
                                # endregion

                                myReader.Close();
                                myReader.Dispose();
                                myReader = null;

                                sqlCommand.ExecuteNonQuery();
                            }
                            //ADD　2011.08.24 SqlReader使用に修正------->>>>>
                            else
                            {
                                myReader.Close();
                                myReader.Dispose();
                                myReader = null;
                            }
                            //ADD　2011.08.24 SqlReader使用に修正-------<<<<<
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
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        # region [発注書発行用メソッド]
        /// <summary>
        /// 発注書発行・再発行後の発注データ更新用メソッド
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>Status</returns>
        /// <br>Note       : 発注書の発行・再発行後に対して仕入データや仕入明細データの追加・更新を行います。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.19</br>
        public int WriteforSalesOrderPrint(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (paraList != null && paraList.Count > 0)
            {
                foreach (object item in paraList)
                {
                    ArrayList subList = item as ArrayList;

                    if (subList != null)
                    {
                        // ●更新データの取得
                        // ※subList の中には StockSlipWork(1個) と StockDetailWork(複数) が格納されている物とする

                        StockSlipWork stockSlipWork = null;
                        ArrayList stockDetailWorkList = null;

                        // 仕入データ
                        stockSlipWork = ListUtils.Find(subList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                        // 仕入明細データ
                        stockDetailWorkList = ListUtils.Find(subList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        # region [DEL]
                        //foreach (object datawork in subList)
                        //{
                        //    if (datawork is StockSlipWork && stockSlipWork == null)
                        //    {
                        //        // 仕入データ
                        //        stockSlipWork = datawork as StockSlipWork;
                        //    }
                        //    else if (datawork is ArrayList && (datawork as ArrayList).Count > 0 && (datawork as ArrayList)[0] is StockDetailWork)
                        //    {
                        //        // 仕入明細データ
                        //        stockDetailWorkList = datawork as ArrayList;
                        //    }
                        //}
                        # endregion

                        if (stockSlipWork != null && ListUtils.IsNotEmpty(stockDetailWorkList))
                        {
                            object dummyParam = new SalesOrderPrint();
                            string retMsg = "";
                            string retItemInfo = "";
                            CustomSerializeArrayList orgDataList = new CustomSerializeArrayList();
                            CustomSerializeArrayList regDataList = new CustomSerializeArrayList();

                            regDataList.Add(stockSlipWork);
                            regDataList.Add(stockDetailWorkList);

                            // 書込み準備処理を行う
                            status = this.WriteInitial("", ref orgDataList, ref regDataList, 0, "", ref dummyParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 仕入データ・仕入明細データの書込み処理を行う
                                status = this.Write("", ref orgDataList, ref regDataList, 0, "", ref dummyParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                            }

                            // 仕入データ・仕入明細データ登録に失敗した場合は処理を終了する
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 発注書発行取り消しメソッド
        /// </summary>
        /// <param name="paraList">発注書発行取消し対象仕入データ(StockSlipWork)を格納したArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>Status</returns>
        /// <br>Note       : 発行済みの発注書を取り消します(仕入データ削除、仕入明細データ更新)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.19</br>
        /// <br>Update Note: 2011/07/27 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //public int DeleteforSalesOrderPrint(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo) // DEL 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        public int DeleteforSalesOrderPrint(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        {
            // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
            //return this.DeleteforSalesOrderPrintProc(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            return this.DeleteforSalesOrderPrintProc(ref paraList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo, out errMessage);
            // UPD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
        }

        /// <summary>
        /// 発注書発行取り消しメソッド
        /// </summary>
        /// <param name="paraList">発注書発行取消し対象仕入データ(StockSlipWork)を格納したArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="sqlEncryptInfo">SqlEncryptInfo</param>
        /// <returns>Status</returns>
        /// <br>Note       : 発行済みの発注書を取り消します(仕入データ削除、仕入明細データ更新)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.10.19</br>
        /// <br>Update Note: 2011/07/27 qijh</br>
        /// <br>             SCM対応 - 拠点管理(10704767-00)</br>
        //private int DeleteforSalesOrderPrintProc(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo) // DEL 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        private int DeleteforSalesOrderPrintProc(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo, out string errMessage) // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;

            if (paraList != null && paraList.Count > 0)
            {
                SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                try
                {
                    // 変更された仕入・仕入明細データを格納するリスト
                    ArrayList modifiedSlipsList = new ArrayList();

                    foreach (object item in paraList)
                    {
                        StockSlipWork stockSlipWork = item as StockSlipWork;

                        StockSlipWork orgStockSlipWork = null;

                        if (stockSlipWork != null)
                        {
                            StockSlipReadWork slpRead = this.StockSlipReadWorkOutPut(stockSlipWork);
                            StockSlipWork[] copyStockSlipWork = new StockSlipWork[0];
                                        
                            status = this.ReadStockSlipWork(out orgStockSlipWork, ref copyStockSlipWork, slpRead, ref sqlConnection, ref sqlTransaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                continue;
                            }
                            // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                            // 仕入伝票を削除する前に、送信済みのチェックを行う
                            if (!CheckStockSending(orgStockSlipWork, out errMessage))
                            {
                                // チェックNG
                                status = STATUS_CHK_SEND_ERR;
                                return status;
                            }
                            // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

                            // ●仕入データの削除を行う
                            # region [DELETE文]
                            string sqlText = "";
                            sqlText = "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  STOCKSLIPRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //Prameterオブジェクトの作成＆値設定
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar).Value = SqlDataMediator.SqlSetString(stockSlipWork.EnterpriseCode);
                            sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                            sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);
                            
                            sqlCommand.ExecuteNonQuery();

                            // 仕入データ(発注データ)に紐付く仕入明細データを取得する
                            ArrayList stockDetailWorks = null;
                            ArrayList[] copyStockDetailWorks = new ArrayList[0];
                            status = this.ReadStockDetailWork(out stockDetailWorks, ref copyStockDetailWorks, slpRead, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                foreach (StockDetailWork dtlwork in stockDetailWorks)
                                {
                                    dtlwork.AcceptAnOrderNo = 0;                        // 受注番号を初期化
                                    dtlwork.SupplierSlipNo = 0;                         // 仕入伝票番号を初期化
                                    dtlwork.OrderFormIssuedDiv = 0;                     // 発注書発行済区分を初期化
                                    dtlwork.StockCountDifference = dtlwork.StockCount;  // 仕入差分数を設定
                                }

                                // 仕入明細データの更新(発注書未発行状態に戻す)を行う
                                status = this.WriteStockDetailWork(ref stockDetailWorks, stockSlipWork, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 更新された発注データ(仕入明細データ)をリストに追加する
                                    ArrayList oneSetSlipWorks = new ArrayList();
                                    oneSetSlipWorks.Add(orgStockSlipWork);
                                    oneSetSlipWorks.Add(stockDetailWorks);
                                    modifiedSlipsList.Add(oneSetSlipWorks);
                                }
                            }
                        }
                    }

                    // 発注取消処理が正常に終了し、且つ取消された仕入明細データが存在する場合
                    // 呼び出し元に取消された仕入明細データを返す
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && modifiedSlipsList.Count > 0)
                    {
                        paraList.Add(modifiedSlipsList);
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
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }
            else
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(errmsg + ": 削除対象オブジェクトパラメータが未指定です", status);
            }

            return status;
        }
        # endregion

        # region [相手先伝票番号検索メソッド]

        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="retStockSlipList">検索結果を格納する CustomSerializeArrayList を指定します。</param>
        /// <param name="paraStockSlip">検索条件を格納した StockSlip を指定します。</param>
        /// <param name="mode">0:完全一致 1:前方一致 2:完全一致＋仕入明細取得</param>
        /// <br>Update Note: 2021/06/09 呉元嘯</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br> 
        /// <returns>STATUS</returns>
        public int SearchPartySaleSlipNum(ref object retStockSlipList, object paraStockSlip, int mode)
        {
            // --- UPD 2021/06/09 呉元嘯 PMKOBETSU-4144 ----->>>>>
            //return this.SearchPartySaleSlipNumProc(ref retStockSlipList, paraStockSlip, mode);
            // リトライ回数
            int retryCnt = ZERO_VALUE;
            // ログ出力クラス
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // リトライ設定ワーク
            RetrySet retrySettingInfo = new RetrySet();
            // リトライ設定取得出力部品
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.SearchPartySaleSlipNumProcReTry(ref retStockSlipList, paraStockSlip, mode, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/09 呉元嘯 PMKOBETSU-4144 -----<<<<<
        }

        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="retStockSlipList">検索結果を格納する CustomSerializeArrayList を指定します。</param>
        /// <param name="paraStockSlip">検索条件を格納した StockSlip を指定します。</param>
        /// <param name="mode">0:完全一致 1:前方一致 2:完全一致＋仕入明細取得</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <param name="outLogCommonObj">ログ出力クラス</param>
        /// <param name="retrySettingInfo">リトライ設定ワーク</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Update Note: 2015/12/14 李侠</br>
        /// <br>管理番号   : 11175418-00</br>
        /// <br>           : Redmine#48098 売仕入同時入力SEQが異なる障害対応</br>
        /// <br>Update Note: 2021/04/08 佐々木亘</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             タイムアウト設定追加</br>
        /// <br>Update Note: 2021/06/09 呉元嘯</br>
        /// <br>管理番号   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 デッドロック対応</br> 
        /// </remarks>
        // --- UPD 2021/06/09 呉元嘯 PMKOBETSU-4144 ----->>>>>
        //private int SearchPartySaleSlipNumProc(ref object retStockSlipList, object paraStockSlip, int mode)
        private int SearchPartySaleSlipNumProcReTry(ref object retStockSlipList, object paraStockSlip, int mode, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        // --- UPD 2021/06/09 呉元嘯 PMKOBETSU-4144 -----<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = null;
            SqlDataReader dataReader = null;
            SqlCommand command = null;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();// ADD 2021/06/09 呉元嘯 PMKOBETSU-4144

            try
            {
                retryCnt++;// ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 
                ArrayList retList = retStockSlipList as ArrayList;
                StockSlipWork stockSlip = paraStockSlip as StockSlipWork;

                if (retList != null && stockSlip != null)
                {

                    SqlConnectionInfo connectionInfo = new SqlConnectionInfo();
                    string connectionText = connectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                    if (connectionText == null || connectionText == "")
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    connection = new SqlConnection(connectionText);
                    connection.Open();

                    string sqlText = string.Empty;
                    command = new SqlCommand(sqlText, connection);

                    # region [SELECT文]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  SLIP.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;

                    if (stockSlip.LogicalDeleteCode > -1)
                    {
                        // 論理削除区分
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        SqlParameter findLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlip.LogicalDeleteCode);            
                    }

                    if (!string.IsNullOrEmpty(stockSlip.SectionCode))
                    {
                        // 拠点コード
                        sqlText += "  AND SLIP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                        SqlParameter findSectionCode = command.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(stockSlip.SectionCode);            
                    }

                    // ADD 2015/12/14 李侠 For Redmine#48098-------------------------------->>>>>
                    if ((!string.IsNullOrEmpty(stockSlip.StockSectionCd)) && (mode == 3))
                    {
                        // 仕入拠点コード
                        sqlText += "  AND SLIP.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCODE" + Environment.NewLine;
                        SqlParameter findStockSectionCode = command.Parameters.Add("@FINDSTOCKSECTIONCODE", SqlDbType.NChar);
                        findStockSectionCode.Value = SqlDataMediator.SqlSetString(stockSlip.StockSectionCd);
                    }
                    if ((stockSlip.SupplierSlipCd > 0) && (mode == 3))
                    {
                        // 仕入伝票区分
                        sqlText += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                        SqlParameter findSupplierSlipCd = command.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                        findSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlip.SupplierSlipCd);
                    }
                    // ADD 2015/12/14 李侠 For Redmine#48098--------------------------------<<<<<

                    if (stockSlip.SupplierCd > 0)
                    {
                        // 得意先コード
                        sqlText += "  AND SLIP.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockSlip.SupplierCd);
                    }

                    object slipDate = 0;
                    string subSqlText = string.Empty;
                    
                    if (stockSlip.SupplierFormal == 0)
                    {
                        // 仕入日を設定
                        slipDate = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlip.StockDate);
                        subSqlText = "  AND SLIP.STOCKDATERF = @SLIPDATE" + Environment.NewLine;
                    }
                    else if (stockSlip.SupplierFormal == 1)
                    {
                        // 入荷日を設定
                        slipDate = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlip.ArrivalGoodsDay);
                        subSqlText = "  AND SLIP.ARRIVALGOODSDAYRF = @SLIPDATE" + Environment.NewLine;
                    }

                    if (slipDate != DBNull.Value)
                    {
                        sqlText += subSqlText;
                        SqlParameter paraSlipDate = command.Parameters.Add("@SLIPDATE", SqlDbType.Int);
                        paraSlipDate.Value = slipDate;
                    }

                    //if (mode == 0 || mode == 2) // DEL 2015/12/14 李侠 For Redmine#48098
                    // ADD 2015/12/14 李侠 For Redmine#48098-------------------------------->>>>>
                    // mode == 3完全一致＋仕入明細取得(売上仕入同時用)
                    if (mode == 0 || mode == 2 || mode == 3)
                    // ADD 2015/12/14 李侠 For Redmine#48098--------------------------------<<<<<
                    {
                        sqlText += "  AND SLIP.PARTYSALESLIPNUMRF = @FINDPARTYSALESLIPNUM" + Environment.NewLine;
                    }
                    else if (mode == 1)
                    {
                        sqlText += "  AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM + '%'" + Environment.NewLine;
                    }

                    command.CommandText = sqlText;
                    #endregion

                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findSupplierFormal = command.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findPartySaleSlipNum = command.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);

                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlip.EnterpriseCode);      // 企業コード
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlip.SupplierFormal);       // 仕入形式
                    findPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlip.PartySaleSlipNum);  // 相手先伝票番号

#if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif

                    // --- ADD 2021/04/08 タイムアウト設定追加 ------>>>>>
                    // 元のコマンドタイムアウトを初期値保持
                    int sqlCmdTimeout = command.CommandTimeout;
                    try
                    {
                        // 共通部品コマンドタイムアウト設定値を取得（MAKON01824R_DbCmdTimeout.xml）
                        CommTimeoutConf ctc = new CommTimeoutConf();
                        sqlCmdTimeout = ctc.GetDbCommandTimeout("MAKON01824R");
                    }
                    catch
                    {
                        // 例外発生時、元のコマンドタイムアウト使用
                        sqlCmdTimeout = command.CommandTimeout;
                    }
                    finally
                    {
                        // コマンドタイムアウトを設定
                        command.CommandTimeout = sqlCmdTimeout;
                    }
                    // --- ADD 2021/04/08 タイムアウト設定追加 ------<<<<<

                    dataReader = command.ExecuteReader();
                    retList.Clear();

                    while (dataReader.Read())
                    {
                        StockSlipWork stockSlp = this.StockSlipReadResultPut(dataReader);

                        retList.Add(stockSlp);

                        //if (mode == 2) // DEL 2015/12/14 李侠 For Redmine#48098
                        // ADD 2015/12/14 李侠 For Redmine#48098-------------------------------->>>>>
                        // mode == 3完全一致＋仕入明細取得(売上仕入同時用)
                        if (mode == 2 || mode == 3)
                        // ADD 2015/12/14 李侠 For Redmine#48098--------------------------------<<<<<
                        {
                            StockSlipReadWork stockSlpRead = this.StockSlipReadWorkOutPut(stockSlp);
                            ArrayList stockDtlList = null;

                            if (dataReader != null)
                            {
                                if (!dataReader.IsClosed)
                                {
                                    dataReader.Close();
                                }

                                dataReader.Dispose();
                            }

                            // 仕入明細データの読み込み
                            if (this.ReadStockDetailWork(out stockDtlList, stockSlpRead, ref connection) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (ListUtils.IsNotEmpty(stockDtlList))
                                {
                                    retList.Add(stockDtlList);
                                }
                                else
                                {
                                    retList.Clear();
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }
                            }
                            
                            // mode == 2 の場合は理論上１件の仕入データしか読み込まないので break する
                            break;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                // --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 ----->>>>>
                //デッドロックの場合、リトライ処理を行う
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    //ログ出力
                    outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, ex);
                    // リトライ回数まで
                    if (retryCnt >= retrySettingInfo.RetryCount)
                    {
                        //なにもしない
                    }
                    else
                    {
                        Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                        if (dataReader != null)
                        {
                            if (!dataReader.IsClosed)
                            {
                                dataReader.Close();
                            }
                            dataReader.Dispose();
                        }
                        if (command != null)
                        {
                            command.Cancel();
                            command.Dispose();
                        }
                        if (connection != null)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        // リトライ処理を行う
                        status = SearchPartySaleSlipNumProcReTry(ref retStockSlipList, paraStockSlip, mode, ref retryCnt, outLogCommonObj, retrySettingInfo);
                    }
                }
                // --- ADD 2021/06/09 呉元嘯 PMKOBETSU-4144 -----<<<<<
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (dataReader != null)
                {
                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }

                    dataReader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="paraAryobj">検索条件を格納した StockSlipWorkのリストを指定します。</param>
        /// <param name="stockSlipAryObj">仕入データ検索結果(ArrayList)</param>
        /// <param name="stockDetailAryObj">仕入明細データ検索結果(ArrayList)</param>
        /// <returns>STATUS</returns>
        public int StockSlipPartySaleSlipNumReadAll(object paraAryobj , out object stockSlipAryObj, out object stockDetailAryObj)
        {
            return this.StockSlipPartySaleSlipNumReadAllProc(paraAryobj, out stockSlipAryObj, out stockDetailAryObj);
        }

        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="paraAryobj">検索条件を格納した StockSlipWorkのリストを指定します。</param>
        /// <param name="stockSlipAryObj">仕入データ検索結果(ArrayList)</param>
        /// <param name="stockDetailAryObj">仕入明細データ検索結果(ArrayList)</param>
        /// <returns>STATUS</returns>
        private int StockSlipPartySaleSlipNumReadAllProc(object paraAryobj, out object stockSlipAryObj, out object stockDetailAryObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = null;
            SqlDataReader dataReader = null;
            SqlCommand command = null;

            stockSlipAryObj = null;
            stockDetailAryObj = null;

            try
            {
                ArrayList retStockSlipList = new ArrayList();
                ArrayList retStockDetailList = new ArrayList();
                ArrayList paraList = paraAryobj as ArrayList;

                if (paraList != null)
                {

                    SqlConnectionInfo connectionInfo = new SqlConnectionInfo();
                    string connectionText = connectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                    if (connectionText == null || connectionText == "")
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    connection = new SqlConnection(connectionText);
                    connection.Open();

                    string sqlText = string.Empty;
                    command = new SqlCommand(sqlText, connection);

                    foreach (StockSlipWork stockSlip in paraList)
                    {

                        # region [SELECT文]
                        command.Parameters.Clear();
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  SLIP.*" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKSLIPRF AS SLIP" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;

                        // 論理削除区分
                        sqlText += "  AND SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;

                        if (!string.IsNullOrEmpty(stockSlip.SectionCode))
                        {
                            // 拠点コード
                            sqlText += "  AND SLIP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            SqlParameter findSectionCode = command.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(stockSlip.SectionCode);
                        }

                        if (stockSlip.SupplierCd > 0)   
                        {
                            // 仕入先コード
                            sqlText += "  AND SLIP.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                            findSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockSlip.SupplierCd);
                        }

                        object slipDate = 0;
                        string subSqlText = string.Empty;

                        if (stockSlip.SupplierFormal == 0)
                        {
                            // 仕入日を設定
                            slipDate = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlip.StockDate);
                            subSqlText = "  AND SLIP.STOCKDATERF = @SLIPDATE" + Environment.NewLine;
                        }
                        else if (stockSlip.SupplierFormal == 1)
                        {
                            // 入荷日を設定
                            slipDate = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlip.ArrivalGoodsDay);
                            subSqlText = "  AND SLIP.ARRIVALGOODSDAYRF = @SLIPDATE" + Environment.NewLine;
                        }

                        if (slipDate != DBNull.Value)
                        {
                            sqlText += subSqlText;
                            SqlParameter paraSlipDate = command.Parameters.Add("@SLIPDATE", SqlDbType.Int);
                            paraSlipDate.Value = slipDate;
                        }

                        //相手先伝票番号
                        sqlText += "  AND SLIP.PARTYSALESLIPNUMRF = @FINDPARTYSALESLIPNUM" + Environment.NewLine;

                        command.CommandText = sqlText;
                        #endregion

                        SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSupplierFormal = command.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findPartySaleSlipNum = command.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);

                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlip.EnterpriseCode);      // 企業コード
                        findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlip.SupplierFormal);       // 仕入形式
                        findPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlip.PartySaleSlipNum);  // 相手先伝票番号

#if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif

                        dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            StockSlipWork stockSlp = this.StockSlipReadResultPut(dataReader);

                            retStockSlipList.Add(stockSlp);
                        }

                        if (!dataReader.IsClosed)
                        {
                            dataReader.Close();
                        }

                    }

                    // 仕入明細データの読み込み
                    foreach (StockSlipWork stockslp in retStockSlipList)
                    {
                        StockSlipReadWork stockSlpRead = this.StockSlipReadWorkOutPut(stockslp);
                        ArrayList stockDtlList = null;

                        if (this.ReadStockDetailWork(out stockDtlList, stockSlpRead, ref connection) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (ListUtils.IsNotEmpty(stockDtlList))
                            {
                                retStockDetailList.AddRange(stockDtlList);
                            }
                        }
                    }
                    
                    if (retStockSlipList.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        stockSlipAryObj = retStockSlipList;
                        stockDetailAryObj = retStockDetailList;
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (dataReader != null)
                {
                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }

                    dataReader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }
        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        
        # endregion

        /// <summary>
        /// 発注書発行からコールされている事を表す為だけのクラス
        /// </summary>
        private class SalesOrderPrint
        {

        }

        // --- ADD 2010/06/08 ---------->>>>>
        /// <summary>
        /// 仕入明細マスタを更新する。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細マスタを更新する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        public int UpdateStockDetailWork(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteStockDetailWork(ref stockDetailWork, ref sqlConnection, ref sqlTransaction);
        }

        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
        /// <summary>
        /// 仕入データの送信済みのチェック
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>true: チェックOK、false：チェックNG</returns>
        /// <remarks>
        /// <br>Update Note: 2011/10/08 tianjw</br>
        /// <br>             Redmine#25779 仕入伝票入力　送信済みチェックについて</br>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note: 2012/02/06 田建委</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28288 送信済データ修正制御の対応</br>
        /// <br>Update Note: 2012/08/10 脇田 靖之</br>
        /// <br>             拠点管理 送信済データチェック不具合対応</br>
        /// </remarks>
        private bool CheckStockSending(StockSlipWork stockSlipWork, out string errMessage)
        {
            errMessage = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ----- ADD 2011/10/08 --------------------------------->>>>>
            // 赤伝・返品・入荷計上・発注計上時の送信済みチェックは行わない様に変更
            if (stockSlipWork.DebitNoteDiv == 2 || stockSlipWork.SupplierFormal != 0)
            {
                return true;
            }
            // ----- ADD 2011/10/08 ---------------------------------<<<<<

            // チェックを行うかどうかが下記のように判断する(②～③)
            // ②拠点管理送受信対象マスタに仕入データの拠点管理送信区分が「1:送信あり」----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
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
                if (string.Equals("StockSlipRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase)
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
            // ②拠点管理送受信対象マスタに仕入データの拠点管理送信区分が「1:送信あり」-----------<


            // ③拠点管理設定マスタに下記の情報に当たるレコードが存在する ------------------------>>
            // 種別＝0:データ
            // 受信状況＝0:送信
            // 送信対象拠点＝更新する仕入データの計上拠点コード
            // 送信済データ修正区分＝修正不可
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
            int sndFinDataEdDiv = 0;//ADD 2011/11/10 xupz
            // 拠点管理設定マスタ情報を取得
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // ０件の場合、チェックOK
                return true;

            isHaveObj = false;
            // ----- DEL 2011/11/14 xupz---------->>>>>
            //// 仕入計上拠点コード
            //string stockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd;
            //if (null != stockAddUpSectionCd)
            //    stockAddUpSectionCd = stockAddUpSectionCd.Trim();
            // ----- DEL 2011/11/14 xupz----------<<<<<

            // ----- ADD 2011/11/14 xupz---------->>>>>
            // 仕入拠点コード
            string stockSectionCd = stockSlipWork.StockSectionCd;
            if (null != stockSectionCd)
                stockSectionCd = stockSectionCd.Trim();
            // ----- ADD 2011/11/14 xupz----------<<<<<
            DateTime maxSyncExecDate = DateTime.MinValue; // 拠点管理設定マスタの送信実行日
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // 種別＝0:データ && 受信状況＝0:送信
                    //&& resultSecMngSetWork.SectionCode.Trim() == stockAddUpSectionCd //DEL 2011/11/14
                    //// 送信対象拠点＝更新する仕入データの計上拠点コード//DEL 2011/11/14
                     && resultSecMngSetWork.SectionCode.Trim() == stockSectionCd //ADD 2011/11/14
                    // 送信対象拠点＝更新する仕入データの拠点コード //ADD 2011/11/14
                    // ----- DEL 2011/11/10 xupz---------->>>>>
                    //&& resultSecMngSetWork.SndFinDataEdDiv == 1
                    //// 送信済データ修正区分＝修正不可
                    // ----- DEL 2011/11/10 xupz----------<<<<<
                    && ((resultSecMngSetWork.SndFinDataEdDiv == 1) || (resultSecMngSetWork.SndFinDataEdDiv == 2))
                    // 送信済データ修正区分＝修正不可(1:修正不可（送信実行日以前);2:修正不可（伝票日付以前）)
                    // ----- ADD 2011/11/10 xupz----------<<<<<
                    && resultSecMngSetWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    if (resultSecMngSetWork.SyncExecDate.CompareTo(maxSyncExecDate) > 0)
                    //maxSyncExecDate = resultSecMngSetWork.SyncExecDate; //DEL 2011/11/10
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
            //if (stockSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)
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
                if (stockSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)
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
                //if (stockSlipWork.StockDate.CompareTo(maxSyncExecDate) <= 0) // DEL 2011/12/15
                //if (stockSlipWork.PreStockDate.CompareTo(maxSyncExecDate) <= 0) // ADD 2011/12/15 // DEL 2012/02/06 田建委 Redmine#28288
                //if (stockSlipWork.PreStockDate.CompareTo(maxSyncExecDate) <= 0 && stockSlipWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) // ADD 2012/02/06 田建委 Redmine#28288 DEL 2012/08/10 Y.Wakita
                if (stockSlipWork.PreStockDate.CompareTo(maxSyncExecDate) <= 0 && stockSlipWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0) // ADD 2012/08/10 Y.Wakita
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
        // ADD 2011/07/27 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<

        /// <summary>
        /// 仕入明細マスタの発注残数を0に更新する。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細マスタの発注残数を0に更新する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        private int WriteStockDetailWork(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKDETAILRF SET CREATEDATETIMERF=@CREATEDATETIME,UPDATEDATETIMERF=@UPDATEDATETIME,ENTERPRISECODERF=@ENTERPRISECODE,FILEHEADERGUIDRF=@FILEHEADERGUID,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,UPDASSEMBLYID1RF=@UPDASSEMBLYID1,UPDASSEMBLYID2RF=@UPDASSEMBLYID2,LOGICALDELETECODERF=@LOGICALDELETECODE,ORDERREMAINCNTRF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF ", sqlConnection, sqlTransaction))
                {
                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.Int);

                    //KEYコマンドを再設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.LogicalDeleteCode);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                    findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);

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
        // --- ADD 2010/06/08 ----------<<<<<
        // ---  ADD wangf 2011/08/12 ---------->>>>>
        /// <summary>
        /// 仕入明細マスタを更新する。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細マスタを更新する。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/12</br>
        public int UpdateConvertStockDetailWork(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteConvertStockDetailWork(ref stockDetailWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入明細マスタに更新する。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細マスタに更新する。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/12</br>
        private int WriteConvertStockDetailWork(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKDETAILRF SET CREATEDATETIMERF=@CREATEDATETIME,UPDATEDATETIMERF=@UPDATEDATETIME,ENTERPRISECODERF=@ENTERPRISECODE,FILEHEADERGUIDRF=@FILEHEADERGUID,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,UPDASSEMBLYID1RF=@UPDASSEMBLYID1,UPDASSEMBLYID2RF=@UPDASSEMBLYID2,LOGICALDELETECODERF=@LOGICALDELETECODE,ORDERREMAINCNTRF=0,ACCEPTANORDERNORF=@ACCEPTANORDERNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF ", sqlConnection, sqlTransaction))
                {
                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.Int);

                    //KEYコマンドを再設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.LogicalDeleteCode);
                    paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.AcceptAnOrderNo);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                    findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);

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
        // --- ADD wangf 2011/08/12 ----------<<<<<

  // --- ADD 連番966 2011/08/16 ---------->>>>>
        /// <summary>
        /// 仕入明細マスタの同時売上情報をクリアする。
        /// </summary>
        /// <param name="stockDetailWork">仕入明細work</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 連番966 仕入明細マスタの同時売上情報をクリアする。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/16</br>
        public int ClearStockDetailSync(ref StockDetailWork stockDetailWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE STOCKDETAILRF SET UPDATEDATETIMERF=@UPDATEDATETIME,ENTERPRISECODERF=@ENTERPRISECODE,FILEHEADERGUIDRF=@FILEHEADERGUID,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE,UPDASSEMBLYID1RF=@UPDASSEMBLYID1,UPDASSEMBLYID2RF=@UPDASSEMBLYID2,ACPTANODRSTATUSSYNCRF=0,SALESSLIPDTLNUMSYNCRF=0 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUMRF ", sqlConnection, sqlTransaction))
                {
                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockDetailWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    // -- UPD 2011/10/14 ------------------------------->>>
                    //SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.Int);
                    SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUMRF", SqlDbType.BigInt);
                    // -- UPD 2011/10/14 -------------------------------<<<

                    //KEYコマンドを再設定
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseCode);
                    findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                    findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);

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

        /// <summary>
        /// 指定された仕入伝票番号の仕入明細通番を戻します
        /// </summary>
        /// <param name="stockDetailWork">明細読込結果</param>
        /// <param name="stockSlipReadWork">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 連番966 仕入明細マスタの同時売上情報をクリアする。</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/16</br>
        public int ReadStockDetailWork(out ArrayList stockDetailWorkList, StockSlipReadWork stockSlipReadWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            StockDetailWork stockDetailWork = null;
            stockDetailWorkList = new ArrayList();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                    SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockSlipReadWork.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierFormal);
                    findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipReadWork.SupplierSlipNo);

                    try
                    {
                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            //伝票明細をセット
                            stockDetailWork = StockDetailReadResultPut(ref myReader);
                            stockDetailWorkList.Add(stockDetailWork);

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
            if (stockDetailWorkList.Count == 0)
            {
                stockDetailWorkList = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }
        // --- ADD 連番966 2011/08/16 ----------<<<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// <summary>
        /// 指定された仕入明細通番を持つ仕入明細データLISTを全て戻します（売上伝票削除用）
        /// </summary>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="parastockDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入明細通番を持つ仕入明細データを全て戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2012.11.30</br>
        public int ReadStockDetailWork2(out ArrayList stockDetailWorks, ArrayList parastockDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadStockDetailWorkProc2(out stockDetailWorks, parastockDetailWorks, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された仕入明細通番を持つ仕入明細データLISTを全て戻します（売上伝票削除用）
        /// </summary>
        /// <param name="stockDetailWorks">明細読込結果</param>
        /// <param name="parastockDetailWorks">読込パラメータ</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入明細通番を持つ仕入明細データを全て戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2012.11.30</br>
        private int ReadStockDetailWorkProc2(out ArrayList stockDetailWorks, ArrayList parastockDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList retList = new ArrayList();

            bool disposeConnection = false;
            bool disposeTransaction = false;

            if (parastockDetailWorks != null && parastockDetailWorks.Count > 0)
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

                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

                        if (connectionText == null || connectionText == "")
                        {
                            stockDetailWorks = retList;
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        sqlConnection = new SqlConnection(connectionText);
                    }

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

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
                        sqlText += "  STOCKDETAILRF AS DTIL WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  AND DTIL.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND DTIL.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NVarChar);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        foreach (Object paraObj in parastockDetailWorks)
                        {
                            IOWriteMASIRDeleteWork paraDtlWork = paraObj as IOWriteMASIRDeleteWork;

                            if (paraDtlWork != null)
                            {
                                //Parameterオブジェクトへ値設定
                                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraDtlWork.EnterpriseCode);
                                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(paraDtlWork.SupplierFormal);
                                findStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(paraDtlWork.StockSlipDtlNum);

                                try
                                {
                                    myReader = sqlCommand.ExecuteReader();

                                    while (myReader.Read())
                                    {
                                        //伝票明細をセット
                                        retList.Add(StockDetailReadResultPut(ref myReader));
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

            stockDetailWorks = retList;

            if (stockDetailWorks.Count > 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<
    }
}