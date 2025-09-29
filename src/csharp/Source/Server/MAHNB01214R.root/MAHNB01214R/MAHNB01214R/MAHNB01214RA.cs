using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/25 M.Kubota

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 請求売上データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求売上データREADの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 18322 T.Kimura</br>
    /// <br>Date       : 2007.01.19</br>
    /// <br></br>
    /// <br>Update Note: 2007.03.27 18322 T.Kimura  売上データのレイアウトが変わったため仮修正</br>
    /// <br>             2007.05.14 18322 T.Kimura  抽出条件にサービス伝票区分、売掛区分、自動入金区分を追加 </br>
    /// <br>             2007.05.23 18322 T.Kimura  最終締更新年月日の取得方法の変更 </br>
    /// <br>             2008.01.08 980081 A.Yamada  流通基幹対応 </br>
    /// <br></br>
    /// <br>             2010/05/17 30517 夏野 駿希 mantis.15393 売上引当の日付の範囲指定が売上日となっていない不具合の修正</br>
    /// <br></br>
    /// <br>             2010/07/01 22018 鈴木 正臣 未入金一覧表に対応。</br>
    /// <br></br>
    /// <br>             2011/05/10 22008 長内 数馬 タイムアウトエラーの対応</br>
    /// </remarks>
    [Serializable]
    //public class ClaimSalesReadDB : RemoteDB , IClaimSalesReadDB          //DEL 2008/04/25 M.Kubota
    public class ClaimSalesReadDB : RemoteWithAppLockDB, IClaimSalesReadDB  //ADD 2008/04/25 M.Kubota
    {
        #region Enum
        /// <summary>請求売上データ・得意先マスタの情報を取得する区分です。</summary>
        private enum GetInfoMode
        {
            /// <summary>請求売上データ</summary>
            SalesSlip,
            /// <summary>全て</summary>
            All
        }
        #endregion
        
        /// <summary>
        /// 請求売上データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        public ClaimSalesReadDB() :
        base("MAHNB01216D", "Broadleaf.Application.Remoting.ParamData.SearchClaimSalesWork", "SALESSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region ノンカスタムシリアライズ
        /// <summary>
        /// 指定された企業コードの請求売上データREADLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの売上リモートREADLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        public int Search(out byte[]                          searchClaimSalesWork
                         ,    object                          searchParaClaimSalesRead
                         ,    int                             readMode
                         ,    ConstantManagement.LogicalMode  logicalMode
                         )
        {
            bool nextData;
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            searchClaimSalesWork = null;
            
            SearchParaClaimSalesRead _searchParaClaimSalesRead = searchParaClaimSalesRead as SearchParaClaimSalesRead;
            if (_searchParaClaimSalesRead == null) 
            {
                // パラメータエラー
                return status;
            }
            
            try
            {
                // 検索
                ArrayList al = new ArrayList();
                status =  SearchProc( out al
                                    , out retTotalCnt
                                    , out nextData
                                    , _searchParaClaimSalesRead
                                    , readMode
                                    , logicalMode
                                    , 0
                                    , GetInfoMode.SalesSlip
                                    );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索が正常終了したとき
                    SearchClaimSalesWork[] searchClaimSalesWorks = (SearchClaimSalesWork[])al.ToArray(typeof(SearchClaimSalesWork));
                    searchClaimSalesWork = XmlByteSerializer.Serialize(searchClaimSalesWorks);
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            return status;
        }
        
        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchCus(out byte[]                         searchClaimSalesWork
                            ,    object                         searchParaClaimSalesRead
                            ,    int                            readMode
                            ,    ConstantManagement.LogicalMode logicalMode
                            )
        {
            bool nextData;
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            searchClaimSalesWork = null;

            SearchParaClaimSalesRead _searchParaClaimSalesRead = searchParaClaimSalesRead as SearchParaClaimSalesRead;
            if (_searchParaClaimSalesRead == null) 
            {
                // パラメータエラー
                return status;
            }
            
            try
            {
                // 検索
                ArrayList al = new ArrayList();
                status = SearchProc( out al
                                   , out retTotalCnt
                                   , out nextData
                                   , _searchParaClaimSalesRead
                                   , readMode
                                   , logicalMode
                                   , 0
                                   , GetInfoMode.All
                                   );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索が正常終了したとき
                    SearchClaimSalesWork[] searchClaimSalesWorks = (SearchClaimSalesWork[])al.ToArray(typeof(SearchClaimSalesWork));
                    searchClaimSalesWork = XmlByteSerializer.Serialize(searchClaimSalesWorks);
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.SearchCus Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        
        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します
        /// </summary>
        /// <param name="parabyte">検索結果</param>
        /// <param name="enterpriseCode">検索パラメータ(企業コード)</param>
        /// <param name="acceptAnOrderNo">検索パラメータ(受注番号)</param>
        /// <param name="claimCode">検索パラメータ(請求先コード)</param>
        /// <param name="demandAddUpSecCd">検索パラメータ(請求計上拠点コード)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        public int ReadCus(ref byte[]                         parabyte
                          ,    string                         enterpriseCode
                          ,    int                            acceptAnOrderNo
                          ,    int                            claimCode
                          ,    string                         demandAddUpSecCd
                          ,    ConstantManagement.LogicalMode logicalMode
                          )
        {
            bool nextData;
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            parabyte = null;

            // 検索条件クラス生成
            SearchParaClaimSalesRead _searchParaClaimSalesRead = new SearchParaClaimSalesRead();
            
            // 企業コード
            _searchParaClaimSalesRead.EnterpriseCode   = enterpriseCode;
            // ↓ 2008.01.08 980081 d
            //// 受注番号
            //_searchParaClaimSalesRead.AcceptAnOrderNo = acceptAnOrderNo;
            // ↑ 2008.01.08 980081 d
            // 請求先コード
            _searchParaClaimSalesRead.ClaimCode        = claimCode;
            // 請求計上拠点コード
            _searchParaClaimSalesRead.DemandAddUpSecCd = demandAddUpSecCd;
            
            try
            {
                // 検索
                ArrayList al = new ArrayList();
                status = SearchProc( out al
                                   , out retTotalCnt
                                   , out nextData
                                   , _searchParaClaimSalesRead
                                   , 0
                                   , logicalMode
                                   , 0
                                   , GetInfoMode.All
                                   );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索が正常終了したとき
                    SearchClaimSalesWork[] searchClaimSalesWorks = (SearchClaimSalesWork[])al.ToArray(typeof(SearchClaimSalesWork));
                    parabyte = XmlByteSerializer.Serialize(searchClaimSalesWorks[0]);
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.SearchCus Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region カスタムシリアライズ
        /// <summary>
        /// 指定された企業コードの請求売上データREADLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求売上データREADLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        public int Search( out object                         searchClaimSalesWork
                         ,     object                         searchParaClaimSalesRead
                         ,     int                            readMode
                         ,     ConstantManagement.LogicalMode logicalMode
                         )
        {
            bool nextData;
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            searchClaimSalesWork = null;
            
            SearchParaClaimSalesRead _searchParaClaimSalesRead = searchParaClaimSalesRead as SearchParaClaimSalesRead;
            if (_searchParaClaimSalesRead == null) 
            {
                // パラメータエラー
                return status;
            }

            try
            {
                // 検索
                ArrayList al = new ArrayList();
                status = SearchProc( out al
                                   , out retTotalCnt
                                   , out nextData
                                   , _searchParaClaimSalesRead
                                   , readMode
                                   , logicalMode
                                   , 0
                                   , GetInfoMode.SalesSlip
                                   );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索が正常終了したとき
                    searchClaimSalesWork = al;
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        
        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します（論理削除除く）</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchCus(out object                         searchClaimSalesWork
                            ,    object                         searchParaClaimSalesRead
                            ,    int                            readMode
                            ,    ConstantManagement.LogicalMode logicalMode
                            )
        {
            bool nextData;
            int retTotalCnt;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            searchClaimSalesWork = null;
            
            SearchParaClaimSalesRead _searchParaClaimSalesRead = searchParaClaimSalesRead as SearchParaClaimSalesRead;
            if (_searchParaClaimSalesRead == null) 
            {
                // パラメータエラー
                return status;
            }

            try
            {
                // 検索
                ArrayList al = new ArrayList();

                status = SearchProc( out al
                                   , out retTotalCnt
                                   , out nextData
                                   , _searchParaClaimSalesRead
                                   , readMode
                                   , logicalMode
                                   , 0
                                   , GetInfoMode.All
                                   );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検索が正常終了したとき
                    searchClaimSalesWork = al;
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.SearchCus Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion
        
        #region プライベート関数
        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST・得意先締情報を全て戻します
        /// </summary>
        /// <param name="al">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <param name="getInfoMode">取得情報(請求売上データのみ、全て)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの請求売上データREADLIST・得意先締情報を全て戻します</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: 2010/12/20 yangmj  引当情報表示の改良</br>
        private int SearchProc(out ArrayList al
                             , out int                             retTotalCnt
                             , out bool                            nextData
                             ,     SearchParaClaimSalesRead        searchParaClaimSalesRead
                             ,     int                             readMode
                             ,     ConstantManagement.LogicalMode  logicalMode
                             ,     int                             readCnt
                             ,     GetInfoMode                     getInfoMode
                             )
        {
            int ret;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //--------------------------
            // パラメータを初期化
            //--------------------------
            al          = null;     // 検索結果
            retTotalCnt = 0;        // 検索対象総件数を0で初期化
            nextData    = false;    // 次レコード無しで初期化
            
            int _readCnt = readCnt;
            if (_readCnt > 0)
            {
                // 件数指定リードの場合には指定件数＋１件リードする
                _readCnt += 1;
            }
            
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection  sqlConnection  = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand     sqlCommand     = null;
            SqlDataReader  myReader       = null;

            //--- DEL 2008/04/25 M.Kubota --->>>
            //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            //string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //if (_connectionText == null || _connectionText == "")
            //{
            //    return status;
            //}

            //sqlConnection = new SqlConnection(_connectionText);
            //sqlConnection.Open();
            
            //// ↓ 2008.01.08 980081 a
            ////●暗号化キーOPEN
            //SqlEncryptInfo sqlEncryptInfo = null;
            //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
            //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
            //// ↑ 2008.01.08 980081 a
            //--- DEL 2008/04/25 M.Kubota ---<<<
            
            //--- ADD 2008/04/25 M.Kubota --->>>
            sqlConnection = this.CreateSqlConnection(true);

            if (sqlConnection == null)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                errmsg += ": DB接続情報の取得に失敗しました。";
                base.WriteErrorLog(errmsg, status);
                return status;
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            Hashtable htClaimList = new Hashtable();

            try
            {
                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //----------------------
                // 請求売上データ取得
                //----------------------
                al = new ArrayList();
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // -- ADD 2011/05/10 ----------------------------------------->>>
                sqlCommand.CommandTimeout = 600;
                // -- ADD 2011/05/10 -----------------------------------------<<<
                
                // 検索SQLの作成
                ret = MakeSelectCommandText(ref sqlCommand
                                           ,    searchParaClaimSalesRead
                                           ,    logicalMode
                                           ,    getInfoMode
                                           );
                if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return ret;
                }

# if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
# endif

                // データ読み込み Read
                myReader = sqlCommand.ExecuteReader();

                int retCnt = 0;
                //-----ADD 2010/12/20----->>>>>
                string beSaleSlipNum = string.Empty;
                //-----ADD 2010/12/20-----<<<<<
                while(myReader.Read())
                {
                    //-----ADD 2010/12/20----->>>>>
                    string saleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    if (saleSlipNum.Equals(beSaleSlipNum))
                    {
                        continue;
                    }
                    else
                    {
                        beSaleSlipNum = saleSlipNum;
                    }
                    //-----ADD 2010/12/20-----<<<<<

                    // 戻り値カウンタカウント
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        // 戻り値の件数が取得指示件数を超えた場合終了
                        if (readCnt < retCnt) 
                        {
                            nextData = true;
                            break;
                        }
                    }
                    
                    // 検索データを請求売上データ検索構造体にセット
                    SearchClaimSalesWork wkSearchClaimSalesWork = new SearchClaimSalesWork();
                    
                    ret = CopyToDataClassFromSelectData(ref wkSearchClaimSalesWork
                                                       ,    myReader
                                                       ,    getInfoMode);
                    if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return ret;
                    }
                    
                    if (getInfoMode == GetInfoMode.All)
                    {
                        if (htClaimList.ContainsKey(wkSearchClaimSalesWork.ClaimCode) == false)
                        {
                            // キーを追加
                            htClaimList.Add(wkSearchClaimSalesWork.ClaimCode, wkSearchClaimSalesWork.DemandAddUpSecCd);
                        }
                    }

                    al.Add(wkSearchClaimSalesWork);
                }
                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                if (getInfoMode == GetInfoMode.All)
                {
                    //--------------------------------
                    // 請求先毎の締め日を取得
                    //--------------------------------
                    Hashtable htClaimLastCAddUpUpdDate = new Hashtable();
                    CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();
                    foreach (int claimCode in htClaimList.Keys)
                    {
                        DmdCAddUpHisWork dmdCAddUpHisWork = new DmdCAddUpHisWork();
                        dmdCAddUpHisWork.EnterpriseCode = searchParaClaimSalesRead.EnterpriseCode;
                        dmdCAddUpHisWork.AddUpSecCode   = htClaimList[claimCode].ToString();
                        dmdCAddUpHisWork.CustomerCode   = claimCode;

                        int st = custDmdPrcDB.ReadHis(ref dmdCAddUpHisWork, ref sqlConnection, ref sqlTransaction);
                        if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            htClaimLastCAddUpUpdDate.Add(claimCode, dmdCAddUpHisWork.LastCAddUpUpdDate);
                        }
                        else
                        {
                            htClaimLastCAddUpUpdDate.Add(claimCode, DateTime.MinValue);
                        }
                    }

                    //--------------------------------
                    // 請求先の締め日を設定
                    //--------------------------------
                    int maxIndex = al.Count ;
                    for (int index = 0; maxIndex > index; index++)
                    {
                        SearchClaimSalesWork searchClaimSalesWork = (SearchClaimSalesWork)al[index];
                        if (Convert.IsDBNull(htClaimLastCAddUpUpdDate[index]) == false)
                        {
                            searchClaimSalesWork.LastTotalAddUpDt = TDateTime.DateTimeToLongDate(Convert.ToDateTime(htClaimLastCAddUpUpdDate[index]));
                        }
                        else
                        {
                            searchClaimSalesWork.LastTotalAddUpDt = TDateTime.DateTimeToLongDate(DateTime.MinValue);
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"ClaimSalesReadDB.SearchProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (sqlTransaction.Connection != null)
                {
                    // 読み込んでいるだけなので、ロールバック
                    sqlTransaction.Rollback();
                }

                // ↓ 2008.01.08 980081 a
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);  //DEL 2008/07/10 M.Kubota
                // ↑ 2008.01.08 980081 a

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        # region --- DEL 2008/04/25 M.Kubota ---
        // 使っていないので削除、FROM句に書かれているテーブルも存在しない
        # if false
        /// <summary>
        /// 締日ごとの最終締次更新年月日を取得
        /// </summary>
        /// <param name="dateAry">最終締次更新年月日リスト</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締日ごとの最終締次更新年月日を取得します。</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        private int GetMaxCAddUpUpdDates( ref DateTime[]                dateAry
                                        ,     SearchParaClaimSalesRead  searchParaClaimSalesRead
                                        ,     SqlConnection             sqlConnection
                                        )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("SELECT DISTINCT TOTALDAYRF"
                                          +      ", MAX(CADDUPUPDDATERF) MAX_CADDUPUPDDATERF"
                                          +  " FROM CADDUPHISRF"
                                          + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                          +   " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                                          +  " GROUP BY TOTALDAYRF"
                                          +  " ORDER BY TOTALDAYRF"
                                           , sqlConnection);
                
                // 論理削除設定
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32(0);   //(Int72)logicalMode
            
                // 企業コード設定
                SqlParameter paraEnterpriseCode    = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value           = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.EnterpriseCode);
                
                int dd = 0;
            
                // 読み込み
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                
                while(myReader.Read())
                {
                    dd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TOTALDAYRF"));    //締日
                    if ((dd >= 1) && (dd <= 31))
                    {
                        // 最終締次更新日を設定
                        if (dateAry.Length > (dd - 1)) 
                        {
                            dateAry[dd - 1] = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MAX_CADDUPUPDDATERF"));
                        }
                    }
                }
                myReader.Close();
            }
            catch (SqlException ex) 
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex,"ClaimSalesReadDB.GetMaxCAddUpUpdDates Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endif
        # endregion

        /// <summary>
        /// データベースへ検索を行うSQL文を作成します。
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータクラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="getInfoMode">取得情報(請求売上データのみ、全て)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2010/12/20 yangmj  引当情報表示の改良</br>
        private int MakeSelectCommandText(ref SqlCommand sqlCommand
                                         ,    SearchParaClaimSalesRead        searchParaClaimSalesRead
                                         ,    ConstantManagement.LogicalMode  logicalMode
                                         ,    GetInfoMode                     getInfoMode
                                         )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            int sDate  = 0;
            int eDate  = 0;
            // ↓ 2008.01.08 980081 d
            //int sJDate = 0;
            //int eJDate  = 0;
            // ↑ 2008.01.08 980081 d
            int sSDate = 0;
            int eSDate  = 0;
            // --- ADD m.suzuki 2010/07/01 ---------->>>>>
            int sIDate = 0;
            int eIDate = 0;
            // --- ADD m.suzuki 2010/07/01 ----------<<<<<
            try
            {
                // 計上日(開始)
                sDate  = searchParaClaimSalesRead.AddUpADateStart;
                // 計上日(終了)
                eDate  = searchParaClaimSalesRead.AddUpADateEnd;
                // ↓ 2008.01.08 980081 d
                //// 受注日(開始)
                //sJDate = searchParaClaimSalesRead.AcpAnOrderDateStart;
                //// 受注日(終了)
                //eJDate = searchParaClaimSalesRead.AcpAnOrderDateEnd;
                // ↑ 2008.01.08 980081 d
                // 伝票検索日(開始)
                sSDate = searchParaClaimSalesRead.SearchSlipDateStart;
                // 伝票検索日(終了)
                eSDate = searchParaClaimSalesRead.SearchSlipDateEnd;
                // --- ADD m.suzuki 2010/07/01 ---------->>>>>
                // 入力日(開始)
                sIDate = searchParaClaimSalesRead.InputDateStart;
                // 入力日(終了)
                eIDate = searchParaClaimSalesRead.InputDateEnd;
                // --- ADD m.suzuki 2010/07/01 ----------<<<<<
            }
            catch(Exception)
            {
                sDate  = 0;
                eDate  = 0;
                // ↓ 2008.01.08 980081 d
                //sJDate = 0;
                //eJDate = 0;
                // ↑ 2008.01.08 980081 d
                sSDate = 0;
                eSDate = 0;
                // --- ADD m.suzuki 2010/07/01 ---------->>>>>
                sIDate = 0;
                eIDate = 0;
                // --- ADD m.suzuki 2010/07/01 ----------<<<<<
            }

            string retSql;
            
            try
            {
                // --- UPD m.suzuki 2010/07/01 ---------->>>>>
                // ※未入金一覧表の対応の他に、締範囲の途中で請求先変更した場合の対応も行う為、
                //   SELECT分は一本化する。
                # region // DEL
                //if (getInfoMode == GetInfoMode.All)
                //{
                //    # region --- DEL 2008/07/10 M.Kubota ---
                //    // ↓ 2008.01.08 980081 c
                //    //retSql = "SELECT *"
                //    //       + ", CU.TOTALDAYRF CU_TOTALDAYRF"
                //    //       + ", CU.HONORIFICTITLERF CU_HONORIFICTITLERF"
                //    //       + " FROM SALESSLIPRF SS "
                //    //       + " LEFT JOIN CUSTOMERRF CU"
                //    //       + " ON (SS.ENTERPRISECODERF = CU.ENTERPRISECODERF"
                //    //       + " AND SS.CLAIMCODERF = CU.CUSTOMERCODERF)"
                //    //       ;
                //    //retSql = "SELECT SS.*"
                //    //       + ", CAST(DECRYPTBYKEY(CU.NAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF"
                //    //       + ", CAST(DECRYPTBYKEY(CU.NAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF"
                //    //       + ", CU.TOTALDAYRF CU_TOTALDAYRF"
                //    //       + ", CU.HONORIFICTITLERF CU_HONORIFICTITLERF"
                //    //       + " FROM SALESSLIPRF SS "
                //    //       + " LEFT JOIN CUSTOMERRF CU"
                //    //       + " ON (SS.ENTERPRISECODERF = CU.ENTERPRISECODERF"
                //    //       + " AND SS.CLAIMCODERF = CU.CUSTOMERCODERF)"
                //    //       ;
                //    // ↑ 2008.01.08 980081 c
                //    # endregion

                //    # region [SELECT文]
                //    //--- ADD 2008/07/10 M.Kubota --->>>
                //    retSql = string.Empty;
                //    retSql += "SELECT" + Environment.NewLine;
                //    retSql += "  SS.*" + Environment.NewLine;
                //    retSql += " ,CU.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                //    retSql += " ,CU.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                //    retSql += " ,CU.TOTALDAYRF AS CU_TOTALDAYRF" + Environment.NewLine;
                //    retSql += " ,CU.HONORIFICTITLERF AS CU_HONORIFICTITLERF" + Environment.NewLine;
                //    retSql += "FROM" + Environment.NewLine;
                //    retSql += "  SALESSLIPRF SS LEFT JOIN CUSTOMERRF CU" + Environment.NewLine;
                //    retSql += "  ON (SS.ENTERPRISECODERF = CU.ENTERPRISECODERF" + Environment.NewLine;
                //    retSql += "      AND SS.CLAIMCODERF = CU.CUSTOMERCODERF)" + Environment.NewLine;
                //    //--- ADD 2008/07/10 M.Kubota ---<<<
                //    # endregion
                //}
                //else
                //{
                //    retSql = "SELECT *"
                //           +  " FROM SALESSLIPRF SS"
                //           ;
                //}
                # endregion

                # region [SELECT文]
                retSql = string.Empty;
                retSql += "SELECT" + Environment.NewLine;
                retSql += "  SS.*" + Environment.NewLine;
                retSql += " ,CU.CLAIMCODERF AS CU_CLAIMCODERF" + Environment.NewLine;
                retSql += " ,CU.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                retSql += " ,CU.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                retSql += " ,CU.CUSTOMERSNMRF AS CU_CLAIMSNAMERF" + Environment.NewLine;
                retSql += " ,CU.TOTALDAYRF AS CU_TOTALDAYRF" + Environment.NewLine;
                retSql += " ,CU.HONORIFICTITLERF AS CU_HONORIFICTITLERF" + Environment.NewLine;
                retSql += " ,CU.CLAIMSECTIONCODERF AS CU_CLAIMSECTIONCODERF" + Environment.NewLine;
                retSql += " ,SEC.SECTIONGUIDESNMRF AS SEC_SECTIONGUIDESNMRF" + Environment.NewLine;
                //-----ADD 2010/12/20----->>>>>
                retSql += " ,DEP.SALESSLIPNUMRF AS DEP_SALESSLIPNUMRF" + Environment.NewLine;
                //-----ADD 2010/12/20-----<<<<<
                retSql += "FROM" + Environment.NewLine;
                // SS:売上データ⇒CUST:得意先
                // -- UPD 2011/05/10 -------------------------------->>>
                //retSql += "  SALESSLIPRF SS LEFT JOIN CUSTOMERRF CUST" + Environment.NewLine;
                retSql += "  SALESSLIPRF SS WITH (READUNCOMMITTED)" + Environment.NewLine;
                retSql += "  LEFT JOIN CUSTOMERRF CUST WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/05/10 --------------------------------<<<
                retSql += "  ON (SS.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                retSql += "      AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                retSql += "      AND SS.CUSTOMERCODERF = CUST.CUSTOMERCODERF)" + Environment.NewLine;
                // CUST:得意先⇒CU:請求先
                retSql += "  LEFT JOIN CUSTOMERRF CU" + Environment.NewLine;
                retSql += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/10
                retSql += "  ON (CUST.ENTERPRISECODERF = CU.ENTERPRISECODERF" + Environment.NewLine;
                retSql += "      AND CU.LOGICALDELETECODERF = 0" + Environment.NewLine;
                retSql += "      AND CUST.CLAIMCODERF = CU.CUSTOMERCODERF)" + Environment.NewLine;
                // CU:請求先⇒SEC:拠点
                retSql += "  LEFT JOIN SECINFOSETRF SEC" + Environment.NewLine;
                retSql += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/10
                retSql += "  ON (CU.ENTERPRISECODERF = SEC.ENTERPRISECODERF" + Environment.NewLine;
                retSql += "      AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                retSql += "      AND CU.CLAIMSECTIONCODERF = SEC.SECTIONCODERF)" + Environment.NewLine;
                //-----ADD 2010/12/20 ----->>>>>
                // SS:売上データ⇒DEP:入金引当
                retSql += "  LEFT JOIN DEPOSITALWRF DEP" + Environment.NewLine;
                retSql += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/10
                retSql += "  ON (SS.ENTERPRISECODERF = DEP.ENTERPRISECODERF" + Environment.NewLine;
                retSql += "      AND DEP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                retSql += "      AND SS.ACPTANODRSTATUSRF = DEP.ACPTANODRSTATUSRF" + Environment.NewLine;
                retSql += "      AND SS.SALESSLIPNUMRF = DEP.SALESSLIPNUMRF)" + Environment.NewLine;
                //-----ADD 2010/12/20 -----<<<<<
                # endregion
                // --- UPD m.suzuki 2010/07/01 ----------<<<<<
                
                retSql += " WHERE ";
        
                //企業コード
                retSql += " SS.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value        = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.EnterpriseCode);
        
                //論理削除区分
                string logidelstr = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    logidelstr = " AND SS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    logidelstr = " AND SS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if(logidelstr != "")
                {
                    retSql += logidelstr;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value        = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
        
                if (getInfoMode == GetInfoMode.All)
                {
                    //論理削除区分(得意先マスタ)
                    retSql += " AND CU.LOGICALDELETECODERF=0";
                }
        
                // ↓ 2008.01.08 980081 d
                //// 受注番号
                //if (searchParaClaimSalesRead.AcceptAnOrderNo > 0)
                //{
                //    retSql += " AND SS.ACCEPTANORDERNORF=@FINDACCEPTANORDERNO ";
                //    SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                //    paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.AcceptAnOrderNo);
                //}
                // ↑ 2008.01.08 980081 d
        
                // 受注ステータス
                if (searchParaClaimSalesRead.AcptAnOdrStatus != null)
                {
                    if (searchParaClaimSalesRead.AcptAnOdrStatus.Length != 0)
                    {
                        retSql += " AND SS.ACPTANODRSTATUSRF IN (";
                        int maxIdx = searchParaClaimSalesRead.AcptAnOdrStatus.Length;
                        for (int i = 0 ; i < maxIdx ; i++)
                        {
                            if (i != 0)
                            {
                                retSql += ",";
                            }
                            retSql += searchParaClaimSalesRead.AcptAnOdrStatus[i].ToString();
                        }
                        retSql += ") ";
                    }
                }

                // 売上伝票番号
                if (searchParaClaimSalesRead.SalesSlipNum != "") 
                {
                    retSql += " AND SS.SALESSLIPNUMRF=@FINDSALESSLIPNUM ";
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.SalesSlipNum);
                }

                // ↓ 2008.01.08 980081 d
                //// 受注伝票番号
                //if (searchParaClaimSalesRead.AcptAnOdrSlipNum > 0) 
                //{
                //    retSql += " AND SS.ACPTANODRSLIPNUMRF=@FINDACPTANODRSLIPNUM ";
                //    SqlParameter paraAcptAnOdrSlipNum = sqlCommand.Parameters.Add("@FINDACPTANODRSLIPNUM", SqlDbType.Int);
                //    paraAcptAnOdrSlipNum.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.AcptAnOdrSlipNum);
                //}
                // ↑ 2008.01.08 980081 d

                // 得意先コード
                if (searchParaClaimSalesRead.CustomerCode > 0)
                {
                    retSql += " AND SS.CUSTOMERCODERF=@FINDCUSTOMERCODE";
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.CustomerCode);
                }

                // 請求先コード
                if (searchParaClaimSalesRead.ClaimCode > 0)
                {
                    // --- UPD m.suzuki 2010/07/01 ---------->>>>>
                    //retSql += " AND SS.CLAIMCODERF=@FINDCLAIMCODE";
                    retSql += " AND CU.CLAIMCODERF=@FINDCLAIMCODE";
                    // --- UPD m.suzuki 2010/07/01 ----------<<<<<
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.ClaimCode);
                }
                // --- ADD m.suzuki 2010/07/01 ---------->>>>>
                // 請求先コード(開始)
                if ( searchParaClaimSalesRead.ClaimCodeStart > 0 )
                {
                    retSql += " AND CU.CLAIMCODERF>=@FINDCLAIMCODEST";
                    SqlParameter paraClaimCodeSt = sqlCommand.Parameters.Add( "@FINDCLAIMCODEST", SqlDbType.Int );
                    paraClaimCodeSt.Value = SqlDataMediator.SqlSetInt32( searchParaClaimSalesRead.ClaimCodeStart );
                }
                // 請求先コード(終了)
                if ( searchParaClaimSalesRead.ClaimCodeEnd > 0 )
                {
                    retSql += " AND CU.CLAIMCODERF<=@FINDCLAIMCODEED";
                    SqlParameter paraClaimCodeEd = sqlCommand.Parameters.Add( "@FINDCLAIMCODEED", SqlDbType.Int );
                    paraClaimCodeEd.Value = SqlDataMediator.SqlSetInt32( searchParaClaimSalesRead.ClaimCodeEnd );
                }
                // --- ADD m.suzuki 2010/07/01 ----------<<<<<

                // ↓ 2008.01.08 980081 d
                // 売上形式
                //if (searchParaClaimSalesRead.SalesFormal > 0)
                //{
                //    retSql += " AND SS.SALESFORMALRF=@FINDSALESFORMAL";
                //    SqlParameter paraSalesFormal = sqlCommand.Parameters.Add("@FINDSALESFORMAL", SqlDbType.Int);
                //    paraSalesFormal.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.SalesFormal);
                //}
                // ↑ 2008.01.08 980081 d

                // 計上日付(開始)
                if ((sDate > 0) && (sDate != 10101))
                {
                    retSql += " AND SS.ADDUPADATERF>=@FINDSTARTDATE";
                    SqlParameter paraStartDate = sqlCommand.Parameters.Add("@FINDSTARTDATE", SqlDbType.Int);
                    paraStartDate.Value = SqlDataMediator.SqlSetInt32(sDate);
                }

                // 計上日付(終了)
                if ((eDate > 0)&&(eDate != 99991231))
                {
                    retSql += " AND SS.ADDUPADATERF<=@FINDENDDATE";
                    SqlParameter paraEndDate = sqlCommand.Parameters.Add("@FINDENDDATE", SqlDbType.Int);
                    paraEndDate.Value = SqlDataMediator.SqlSetInt32(eDate);
                }

                // 請求計上拠点コード
                if ((searchParaClaimSalesRead.DemandAddUpSecCd != null) &&
                    (searchParaClaimSalesRead.DemandAddUpSecCd != ""))
                {
                    // --- UPD m.suzuki 2010/07/01 ---------->>>>>
                    //retSql += " AND SS.DEMANDADDUPSECCDRF=@FINDDEMANDADDUPSECCD ";
                    retSql += " AND CU.CLAIMSECTIONCODERF=@FINDDEMANDADDUPSECCD ";
                    // --- UPD m.suzuki 2010/07/01 ----------<<<<<
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDDEMANDADDUPSECCD", SqlDbType.NChar);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.DemandAddUpSecCd);
                }
                // --- ADD m.suzuki 2010/07/01 ---------->>>>>
                // 請求拠点コード(開始)
                if ( !string.IsNullOrEmpty( searchParaClaimSalesRead.DemandAddUpSecCdStart ) )
                {
                    retSql += " AND CU.CLAIMSECTIONCODERF>=@FINDDEMANDADDUPSECCDST ";
                    SqlParameter paraDemandAddUpSecCdSt = sqlCommand.Parameters.Add( "@FINDDEMANDADDUPSECCDST", SqlDbType.NChar );
                    paraDemandAddUpSecCdSt.Value = SqlDataMediator.SqlSetString( searchParaClaimSalesRead.DemandAddUpSecCdStart );
                }
                // 請求拠点コード(終了)
                if ( !string.IsNullOrEmpty( searchParaClaimSalesRead.DemandAddUpSecCdEnd ) )
                {
                    retSql += " AND CU.CLAIMSECTIONCODERF<=@FINDDEMANDADDUPSECCDED ";
                    SqlParameter paraDemandAddUpSecCdEd = sqlCommand.Parameters.Add( "@FINDDEMANDADDUPSECCDED", SqlDbType.NChar );
                    paraDemandAddUpSecCdEd.Value = SqlDataMediator.SqlSetString( searchParaClaimSalesRead.DemandAddUpSecCdEnd );
                }
                // --- ADD m.suzuki 2010/07/01 ----------<<<<<


                // 実績計上拠点コード
                if ((searchParaClaimSalesRead.ResultsAddUpSecCd != null) &&
                    (searchParaClaimSalesRead.ResultsAddUpSecCd != ""))
                {
                    retSql += " AND SS.RESULTSADDUPSECCDRF=@FINDRESULTSADDUPSECCD ";
                    SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                    paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.ResultsAddUpSecCd);
                }

                // 引当済売上伝票呼出区分(=0：引当済・未引当、!=0：未引当(一部引当済含む)のみ)
                if (searchParaClaimSalesRead.AlwcSalesSlipCall != 0)
                {
                    //retSql += " AND SS.DEPOSITALWCBLNCERF > 0";  //DEL 2008/12/11 M.Kubota ※赤伝も表示する仕様に変更
                    retSql += " AND SS.DEPOSITALWCBLNCERF <> 0";
                }

                //--- DEL 2008/07/10 M.Kubota --->>>
                // サービス伝票区分(0:OFF,1:ON)
                //if (searchParaClaimSalesRead.ServiceSlipCd >= 0)
                //{
                //    // ↓ 2008.01.08 980081 c
                //    //retSql += " AND SS.SERVICESLIPCDRF<=@FINDSERVICESLIPCD";
                //    retSql += " AND SS.SERVICESLIPCDRF=@FINDSERVICESLIPCD";
                //    // ↑ 2008.01.08 980081 c
                //    SqlParameter paraServiceSlipCd = sqlCommand.Parameters.Add("@FINDSERVICESLIPCD", SqlDbType.Int);
                //    paraServiceSlipCd.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.ServiceSlipCd);
                //}
                //--- DEL 2008/07/10 M.Kubota ---<<<

                // 売掛区分(0:売掛なし,1:売掛)
                if (searchParaClaimSalesRead.AccRecDivCd >= 0)
                {
                    // ↓ 2008.01.08 980081 c
                    //retSql += " AND SS.ACCRECDIVCDRF<=@FINDACCRECDIVCD";
                    retSql += " AND SS.ACCRECDIVCDRF=@FINDACCRECDIVCD";
                    // ↑ 2008.01.08 980081 c
                    SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@FINDACCRECDIVCD", SqlDbType.Int);
                    paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.AccRecDivCd);
                }

                // 自動入金区分(0:通常入金,1:自動入金)
                if (searchParaClaimSalesRead.AutoDepositCd >= 0)
                {
                    // ↓ 2008.01.08 980081 c
                    //retSql += " AND SS.AUTODEPOSITCDRF<=@FINDAUTODEPOSITCD";
                    retSql += " AND SS.AUTODEPOSITCDRF=@FINDAUTODEPOSITCD";
                    // ↑ 2008.01.08 980081 c
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@FINDAUTODEPOSITCD", SqlDbType.Int);
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(searchParaClaimSalesRead.AutoDepositCd);
                }

                // 販売従業員コード
                if ((searchParaClaimSalesRead.SalesEmployeeCd != null) &&
                    (searchParaClaimSalesRead.SalesEmployeeCd != ""))
                {
                    retSql += " AND SS.SALESEMPLOYEECDRF=@FINDSALESEMPLOYEECD";
                    SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                    paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(searchParaClaimSalesRead.SalesEmployeeCd);
                }

                // ↓ 2008.01.08 980081 d
                ////受注日(開始)
                //if ((sJDate > 0) && (sJDate != 10101))
                //{
                //    retSql += " AND SS.ACCEPTANORDERDATERF>=@FINDAAOSTARTDATE";
                //    SqlParameter paraAaoStartDate = sqlCommand.Parameters.Add("@FINDAAOSTARTDATE", SqlDbType.Int);
                //    paraAaoStartDate.Value = SqlDataMediator.SqlSetInt32(sJDate);
                //}
                //
                ////受注日(終了)
                //if ((eJDate > 0) && (eJDate != 99991231))
                //{
                //    retSql += " AND SS.ACCEPTANORDERDATERF<=@FINDAAOENDDATE";
                //    SqlParameter paraAaoEndDate = sqlCommand.Parameters.Add("@FINDAAOENDDATE", SqlDbType.Int);
                //    paraAaoEndDate.Value = SqlDataMediator.SqlSetInt32(eJDate);
                //}
                // ↑ 2008.01.08 980081 d

                //伝票検索日(開始)
                if((sSDate > 0) && (sSDate != 10101))
                {
                    // 2010/05/17 売上日に変更 >>>
                    //retSql += " AND SS.SEARCHSLIPDATERF>=@FINDSSSTARTDATE";
                    retSql += " AND SS.SALESDATERF>=@FINDSSSTARTDATE";
                    // 2010/05/17 <<<
                    SqlParameter paraSsStartDate = sqlCommand.Parameters.Add("@FINDSSSTARTDATE", SqlDbType.Int);
                    paraSsStartDate.Value = SqlDataMediator.SqlSetInt32(sSDate);
                }
        
                //伝票検索日(終了)
                if((eSDate > 0)&&(eSDate != 99991231))
                {
                    // 2010/05/17 売上日に変更 >>>
                    //retSql += " AND SS.SEARCHSLIPDATERF<=@FINDSSENDDATE ";
                    retSql += " AND SS.SALESDATERF<=@FINDSSENDDATE ";
                    // 2010/05/17 <<<
                    SqlParameter paraSsEndDate = sqlCommand.Parameters.Add("@FINDSSENDDATE", SqlDbType.Int);
                    paraSsEndDate.Value = SqlDataMediator.SqlSetInt32(eSDate);
                }

                // --- ADD m.suzuki 2010/07/01 ---------->>>>>
                // ※"SearchSlipDate"を売上日で使用するよう変更になってしまった為、
                //   新たに"InputDate"を設けてSEARCHSLIPDATERFに充てる。

                //入力日(開始)
                if ( (sIDate > 0) && (sIDate != 10101) )
                {
                    retSql += " AND SS.SEARCHSLIPDATERF>=@FINDINPUTSTARTDATE";
                    SqlParameter paraInputStartDate = sqlCommand.Parameters.Add( "@FINDINPUTSTARTDATE", SqlDbType.Int );
                    paraInputStartDate.Value = SqlDataMediator.SqlSetInt32( sIDate );
                }

                //入力日(終了)
                if ( (eIDate > 0) && (eIDate != 99991231) )
                {
                    retSql += " AND SS.SEARCHSLIPDATERF<=@FINDINPUTENDDATE";
                    SqlParameter paraInputEndDate = sqlCommand.Parameters.Add( "@FINDINPUTENDDATE", SqlDbType.Int );
                    paraInputEndDate.Value = SqlDataMediator.SqlSetInt32( eIDate );
                }
                // --- ADD m.suzuki 2010/07/01 ----------<<<<<


                // 売上伝票合計（税込み）が １以上 の伝票
                //retSql += " AND SS.SALESTOTALTAXINCRF > 0";  //DEL 2008/12/11 M.Kubota ※赤伝も表示する仕様に変更

                sqlCommand.CommandText = retSql;
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex) 
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex,"ClaimSalesReadDB.MakeSelectCommandText Exception="+ex.Message);
            }
            
            return status ;
        }

        /// <summary>
        /// SQLデータリーダー(請求売上データ＋得意先締情報)→請求売上データ検索ワーク
        /// </summary>
        /// <param name="wkSearchClaimSalesWork">請求売上データ検索ワーク</param>
        /// <param name="myReader">SQLデータリーダー</param>
        /// <param name="getInfoMode">取得情報(請求売上データのみ、全て)</param>
        /// <returns></returns>
        /// <br>Update Note: 2010/12/20 yangmj  引当情報表示の改良</br>
        private int CopyToDataClassFromSelectData(ref SearchClaimSalesWork wkSearchClaimSalesWork
                                                 ,    SqlDataReader         myReader
                                                 ,    GetInfoMode           getInfoMode
                                                 )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            try
            {
                //---------------------------
                //  売上データ
                //---------------------------
                // ↓ 2008.01.08 980081 c
                #region 旧レイアウト(コメントアウト)
                //// 作成日時
                //wkSearchClaimSalesWork.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                //// 更新日時
                //wkSearchClaimSalesWork.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                //// 企業コード
                //wkSearchClaimSalesWork.EnterpriseCode       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                //// GUID
                //wkSearchClaimSalesWork.FileHeaderGuid       = SqlDataMediator.SqlGetGuid(             myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                //// 更新従業員コード
                //wkSearchClaimSalesWork.UpdEmployeeCode      = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                //// 更新アセンブリID1
                //wkSearchClaimSalesWork.UpdAssemblyId1       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                //// 更新アセンブリID2
                //wkSearchClaimSalesWork.UpdAssemblyId2       = SqlDataMediator.SqlGetString(           myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                //// 論理削除区分
                //wkSearchClaimSalesWork.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(            myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                //// 受注番号
                //wkSearchClaimSalesWork.AcceptAnOrderNo      = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                //// 受注ステータス
                //wkSearchClaimSalesWork.AcptAnOdrStatus      = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                //// 検索用伝票番号
                //wkSearchClaimSalesWork.SearchSlipNum        = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SEARCHSLIPNUMRF"));
                //// 売上伝票種別
                //wkSearchClaimSalesWork.SalesSlipKind        = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SALESSLIPKINDRF"));
                //// 売上伝票番号
                //wkSearchClaimSalesWork.SalesSlipNum         = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SALESSLIPNUMRF"));
                //// 承り伝票番号
                //wkSearchClaimSalesWork.AcptAnOdrSlipNum     = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ACPTANODRSLIPNUMRF"));
                //// 見積伝票番号
                //wkSearchClaimSalesWork.EstimateSlipNo       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ESTIMATESLIPNORF"));
                //// 赤伝区分
                //wkSearchClaimSalesWork.DebitNoteDiv         = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
                //// 赤黒連結受注番号
                //wkSearchClaimSalesWork.DebitNLnkAcptAnOdr   = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
                //// 売上伝票区分
                //wkSearchClaimSalesWork.SalesSlipCd          = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SALESSLIPCDRF"));
                //// サービス伝票区分
                //wkSearchClaimSalesWork.ServiceSlipCd        = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SERVICESLIPCDRF"));
                //// 売上形式
                //wkSearchClaimSalesWork.SalesFormal          = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SALESFORMALRF"));
                //// 売上形式コード
                //wkSearchClaimSalesWork.SalesFormalCode      = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SALESFORMALCODERF"));
                //// 売上形式名称
                //wkSearchClaimSalesWork.SalesFormalName      = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SALESFORMALNAMERF"));
                //// 売上入力拠点コード
                //wkSearchClaimSalesWork.SalesInpSecCd        = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SALESINPSECCDRF"));
                //// 請求計上拠点コード
                //wkSearchClaimSalesWork.DemandAddUpSecCd     = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                //// 実績計上拠点コード
                //wkSearchClaimSalesWork.ResultsAddUpSecCd    = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                //// 更新拠点コード
                //wkSearchClaimSalesWork.UpdateSecCd          = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("UPDATESECCDRF"));
                //// 伝票検索日付
                //wkSearchClaimSalesWork.SearchSlipDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SEARCHSLIPDATERF"));
                //// 見積日付
                //wkSearchClaimSalesWork.EstimateDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ESTIMATEDATERF"));
                //// 受注日
                //wkSearchClaimSalesWork.AcceptAnOrderDate    = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
                //// 納品完了予定日
                //wkSearchClaimSalesWork.DeliGdsCmpltDueDate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                //// 出荷日付
                //wkSearchClaimSalesWork.ShipmentDay          = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SHIPMENTDAYRF"));
                //// 売上日付
                //wkSearchClaimSalesWork.SalesDate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SALESDATERF"));
                //// 計上日付
                //wkSearchClaimSalesWork.AddUpADate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
                //// 受付従業員コード
                //wkSearchClaimSalesWork.FrontEmployeeCd      = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                //// 受付従業員名称
                //wkSearchClaimSalesWork.FrontEmployeeNm      = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                //// 販売従業員コード
                //wkSearchClaimSalesWork.SalesEmployeeCd      = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                //// 販売従業員名称
                //wkSearchClaimSalesWork.SalesEmployeeNm      = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                //// 注文方法
                //wkSearchClaimSalesWork.WayToOrder           = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("WAYTOORDERRF"));
                //// 総額表示方法区分
                //wkSearchClaimSalesWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                //// 売上伝票合計（税込み）
                //wkSearchClaimSalesWork.SalesTotalTaxInc     = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                //// 売上伝票合計（税抜き）
                //wkSearchClaimSalesWork.SalesTotalTaxExc     = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                //// 売上小計（税込み）
                //wkSearchClaimSalesWork.SalesSubtotalTaxInc  = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                //// 売上小計（税抜き）
                //wkSearchClaimSalesWork.SalesSubtotalTaxExc  = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                //// 売上小計非課税対象額
                //wkSearchClaimSalesWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                //// 売上小計（税）
                //wkSearchClaimSalesWork.SalesSubtotalTax     = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                //// 原価金額計
                //wkSearchClaimSalesWork.TotalCost            = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("TOTALCOSTRF"));
                //// サービス預り金
                //wkSearchClaimSalesWork.ServiceDeposits      = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("SERVICEDEPOSITSRF"));
                //// 売上商品区分
                //wkSearchClaimSalesWork.SalesGoodsCd         = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SALESGOODSCDRF"));
                //// 消費税調整額
                //wkSearchClaimSalesWork.TaxAdjust            = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("TAXADJUSTRF"));
                //// 残高調整額
                //wkSearchClaimSalesWork.BalanceAdjust        = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("BALANCEADJUSTRF"));
                //// 消費税転嫁方式
                //wkSearchClaimSalesWork.ConsTaxLayMethod     = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                //// 消費税税率
                //wkSearchClaimSalesWork.ConsTaxRate          = SqlDataMediator.SqlGetDouble(            myReader,myReader.GetOrdinal("CONSTAXRATERF"));
                //// 端数処理区分
                //wkSearchClaimSalesWork.FractionProcCd       = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("FRACTIONPROCCDRF"));
                //// 売掛区分
                //wkSearchClaimSalesWork.AccRecDivCd          = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("ACCRECDIVCDRF"));
                //// 自動入金区分
                //wkSearchClaimSalesWork.AutoDepositCd        = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
                //// 請求合計額
                //wkSearchClaimSalesWork.DemandableTtl        = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("DEMANDABLETTLRF"));
                //// 入金引当合計額
                //wkSearchClaimSalesWork.DepositAllowanceTtl  = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                //// 預り金引当合計額
                //wkSearchClaimSalesWork.MnyDepoAllowanceTtl  = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
                //// 入金引当残高
                //wkSearchClaimSalesWork.DepositAlwcBlnce     = SqlDataMediator.SqlGetInt64 (            myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                //// 請求先コード
                //wkSearchClaimSalesWork.ClaimCode            = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("CLAIMCODERF"));
                //// 請求先名称1
                //wkSearchClaimSalesWork.ClaimName1           = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("CLAIMNAME1RF"));
                //// 請求先名称2
                //wkSearchClaimSalesWork.ClaimName2           = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("CLAIMNAME2RF"));
                //// 得意先コード
                //wkSearchClaimSalesWork.CustomerCode         = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
                //// 得意先名称
                //wkSearchClaimSalesWork.CustomerName         = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("CUSTOMERNAMERF"));
                //// 得意先名称2
                //wkSearchClaimSalesWork.CustomerName2        = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("CUSTOMERNAME2RF"));
                //// 敬称
                //wkSearchClaimSalesWork.HonorificTitle       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("HONORIFICTITLERF"));
                //// カナ
                //wkSearchClaimSalesWork.Kana                 = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("KANARF"));
                //// 性別コード
                //wkSearchClaimSalesWork.SexCode              = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("SEXCODERF"));
                //// 個人・法人区分
                //wkSearchClaimSalesWork.CorporateDivCode     = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
                //// 返品理由
                //wkSearchClaimSalesWork.RetGoodsReason       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("RETGOODSREASONRF"));
                //// 納品先コード
                //wkSearchClaimSalesWork.AddresseeCode        = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("ADDRESSEECODERF"));
                //// 納品先名称
                //wkSearchClaimSalesWork.AddresseeName        = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEENAMERF"));
                //// 納品先名称2
                //wkSearchClaimSalesWork.AddresseeName2       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEENAME2RF"));
                //// 納品先住所1(都道府県市区郡・町村・字)
                //wkSearchClaimSalesWork.AddresseeAddr1       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                //// 納品先住所2(丁目)
                //wkSearchClaimSalesWork.AddresseeAddr2       = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("ADDRESSEEADDR2RF"));
                //// 納品先住所3(番地)
                //wkSearchClaimSalesWork.AddresseeAddr3       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                //// 納品先住所4(アパート名称)
                //wkSearchClaimSalesWork.AddresseeAddr4       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                //// 納品先電話番号
                //wkSearchClaimSalesWork.AddresseeTelNo       = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("ADDRESSEETELNORF"));
                //// 相手先伝票番号
                //wkSearchClaimSalesWork.PartySaleSlipNum     = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                //// 伝票備考
                //wkSearchClaimSalesWork.SlipNote             = SqlDataMediator.SqlGetString(            myReader,myReader.GetOrdinal("SLIPNOTERF"));
                //// レジ処理日
                //wkSearchClaimSalesWork.RegiProcDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("REGIPROCDATERF"));
                //// レジ番号
                //wkSearchClaimSalesWork.CashRegisterNo       = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("CASHREGISTERNORF"));
                //// POSレシート番号
                //wkSearchClaimSalesWork.PosReceiptNo         = SqlDataMediator.SqlGetInt32 (            myReader,myReader.GetOrdinal("POSRECEIPTNORF"));
                #endregion
                wkSearchClaimSalesWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkSearchClaimSalesWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkSearchClaimSalesWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkSearchClaimSalesWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkSearchClaimSalesWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkSearchClaimSalesWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkSearchClaimSalesWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkSearchClaimSalesWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkSearchClaimSalesWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                wkSearchClaimSalesWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                wkSearchClaimSalesWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkSearchClaimSalesWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                //wkSearchClaimSalesWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));          //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                //wkSearchClaimSalesWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));  //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                wkSearchClaimSalesWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                wkSearchClaimSalesWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                wkSearchClaimSalesWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                //wkSearchClaimSalesWork.ServiceSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));  //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                // --- DEL m.suzuki 2010/07/01 ---------->>>>>
                //wkSearchClaimSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                // --- DEL m.suzuki 2010/07/01 ----------<<<<<
                wkSearchClaimSalesWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                wkSearchClaimSalesWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                wkSearchClaimSalesWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                wkSearchClaimSalesWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                wkSearchClaimSalesWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                wkSearchClaimSalesWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                wkSearchClaimSalesWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                wkSearchClaimSalesWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                wkSearchClaimSalesWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                wkSearchClaimSalesWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                wkSearchClaimSalesWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                wkSearchClaimSalesWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                wkSearchClaimSalesWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                wkSearchClaimSalesWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                wkSearchClaimSalesWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                wkSearchClaimSalesWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                wkSearchClaimSalesWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                wkSearchClaimSalesWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                wkSearchClaimSalesWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                wkSearchClaimSalesWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
                wkSearchClaimSalesWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                wkSearchClaimSalesWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                wkSearchClaimSalesWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                wkSearchClaimSalesWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                wkSearchClaimSalesWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
                wkSearchClaimSalesWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                wkSearchClaimSalesWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                wkSearchClaimSalesWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                wkSearchClaimSalesWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                wkSearchClaimSalesWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
                wkSearchClaimSalesWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                wkSearchClaimSalesWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                wkSearchClaimSalesWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                //wkSearchClaimSalesWork.ServiceDeposits = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVICEDEPOSITSRF"));  //DEL 2008/07/10 M.Kubota
                //wkSearchClaimSalesWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));  //DEL 2008/07/10 M.Kubota
                //wkSearchClaimSalesWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));  //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                wkSearchClaimSalesWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                wkSearchClaimSalesWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                wkSearchClaimSalesWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                wkSearchClaimSalesWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                wkSearchClaimSalesWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                wkSearchClaimSalesWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                wkSearchClaimSalesWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                // --- DEL m.suzuki 2010/07/01 ---------->>>>>
                //wkSearchClaimSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                //wkSearchClaimSalesWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                // --- DEL m.suzuki 2010/07/01 ----------<<<<<
                wkSearchClaimSalesWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                wkSearchClaimSalesWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                wkSearchClaimSalesWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                wkSearchClaimSalesWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                wkSearchClaimSalesWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                wkSearchClaimSalesWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                wkSearchClaimSalesWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
                wkSearchClaimSalesWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                wkSearchClaimSalesWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                wkSearchClaimSalesWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                wkSearchClaimSalesWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                wkSearchClaimSalesWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                //wkSearchClaimSalesWork.AddresseeAddr2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEEADDR2RF"));  //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                wkSearchClaimSalesWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                wkSearchClaimSalesWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                wkSearchClaimSalesWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                wkSearchClaimSalesWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                wkSearchClaimSalesWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                wkSearchClaimSalesWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                wkSearchClaimSalesWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                wkSearchClaimSalesWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                wkSearchClaimSalesWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                wkSearchClaimSalesWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                wkSearchClaimSalesWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                wkSearchClaimSalesWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                wkSearchClaimSalesWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                wkSearchClaimSalesWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                wkSearchClaimSalesWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                wkSearchClaimSalesWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                wkSearchClaimSalesWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                wkSearchClaimSalesWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkSearchClaimSalesWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                wkSearchClaimSalesWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                wkSearchClaimSalesWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                wkSearchClaimSalesWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                wkSearchClaimSalesWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                wkSearchClaimSalesWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                wkSearchClaimSalesWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
                //wkSearchClaimSalesWork.ClaimType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMTYPERF"));  //DEL 2008/07/10 M.Kubota
                wkSearchClaimSalesWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
                wkSearchClaimSalesWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                wkSearchClaimSalesWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                wkSearchClaimSalesWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                wkSearchClaimSalesWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                // ↑ 2008.01.08 980081 c
                // --- UPD m.suzuki 2010/07/01 ---------->>>>>
                //if (getInfoMode == GetInfoMode.All)
                //{
                //    //---------------------------
                //    // 得意先締情報設定
                //    //---------------------------
                //    //// 実績計上拠点名称（使用しないと思われるので削除）
                //    //wkSearchClaimSalesWork.ResultsAddUpSecNm = SqlDataMediator.SqlGetString(              myReader,myReader.GetOrdinal("RESULTSADDUPSECNM"));
                //    // ↓ 2008.01.08 980081 a
                //    wkSearchClaimSalesWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                //    wkSearchClaimSalesWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                //    // ↑ 2008.01.08 980081 a

                //    // 締日
                //    wkSearchClaimSalesWork.TotalDay          = SqlDataMediator.SqlGetInt32(               myReader,myReader.GetOrdinal("CU_TOTALDAYRF"));
                //}

                // 請求拠点
                wkSearchClaimSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CU_CLAIMSECTIONCODERF" ) );
                wkSearchClaimSalesWork.DemandAddUpSecNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEC_SECTIONGUIDESNMRF" ) );
                // 請求先
                wkSearchClaimSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CU_CLAIMCODERF" ) );
                wkSearchClaimSalesWork.ClaimSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CU_CLAIMSNAMERF" ) );
                wkSearchClaimSalesWork.ClaimName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAMERF" ) );
                wkSearchClaimSalesWork.ClaimName2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAME2RF" ) );
                // 締日
                wkSearchClaimSalesWork.TotalDay = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CU_TOTALDAYRF" ) );
                // --- UPD m.suzuki 2010/07/01 ----------<<<<<
                //-----ADD 2010/12/20----->>>>>
                wkSearchClaimSalesWork.DepSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEP_SALESSLIPNUMRF"));
                //-----ADD 2010/12/20-----<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex) 
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex,"ClaimSalesReadDB.CopyToDataClassFromSelectData Exception="+ex.Message);
            }
            
            return status;
        }
        
        #endregion
    }
}
