using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先電子元帳 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先電子元帳実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.08.18</br>
    /// <br></br>
    /// <br>Update Note: 検索条件クラス伝票検索区分の追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.21</br>
    /// <br></br>
    /// <br>Update Note: 結果クラスへ消費税区分の追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.30</br>
    /// <br></br>
    /// <br>Update Note: 抽出不具合修正( MANTIS ID:13324 )</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.05.26</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 黄偉兵</br>
    /// <br>           : PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>           : 過去分表示対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/10 長内数馬</br>
    /// <br>           : 速度チューニング</br>
    /// <br>UpdateNote : 2010/07/20 chenyd</br>
    /// <br>           　テキスト出力対応</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 2012/06/26 20008 伊藤 豊</br>
    /// <br>           : 課題No.1027 検索時に件数オーバーするとエラーになる現象を修正</br>
    /// <br>           : READUNCOMMITTED対応、タイムアウト時間の延長</br>
    /// <br>UpdateNote : 2012/09/13 FSI上北田 秀樹</br>
    /// <br>           　仕入先総括対応の追加</br>
    /// <br>UpdateNote : 2012/11/08 FSI上北田 秀樹</br>
    /// <br>           　残高一覧表結果表示不具合対応</br>   
    //----------------------------------------------------------------------------//
    // 管理番号              作成担当 : FSI千田 晃久
    // 修 正 日  2013/01/21  修正内容 : 仕入返品予定機能対応
    //----------------------------------------------------------------------------//
    /// <br>UpdateNote : 2015/08/17 田思春</br>
    /// <br>管理番号   : 11170129-00</br>
    /// <br>           　Redmine#47007 消費税などが不正の障害対応</br>
    /// <br>Update Note: 2015/12/22 顧棟</br>
    /// <br>管理番号   : 11170204-00 2016年1月配信分</br>
    /// <br>             Redmine#48327 仕入電子元帳残高テキスト出力不正障害１、２の対応</br>
    /// <br>             障害１:複数拠点の実績が出力されない </br>
    /// <br>             障害２:前回実績がない場合「前回残高」、「繰越残高」、「今回残高」に前拠点の「今回残高」がプラスされてしまう</br>
    /// <br>Update Note: 2015/12/25 顧棟</br>
    /// <br>管理番号   : 11170204-00 2016年1月配信分</br>
    /// <br>             Redmine#48327 仕入電子元帳残高テキスト出力不正障害３の対応</br>
    /// <br>             障害３：残高表示タブで仕入総括オプションが有効の場合にテキスト出力を行うと仕入先コード≠支払先コードの残高が表示されない</br>
    /// <br>Update Note: 2016/02/02 顧棟</br>
    /// <br>管理番号   : 11200002-00 2016年2月配信分</br>
    /// <br>             Redmine#48327 仕入総括オプションが有効の場合に全拠点分のレコードを出力し実績がないものはALLゼロにする</br>
    /// </remarks>
    [Serializable]
    public class SuppPrtPprWorkDB : RemoteDB, ISuppPrtPprWorkDB
    {

        /// <summary>
        /// 仕入先電子元帳 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// </remarks>
        public SuppPrtPprWorkDB()
        {
        }

        // ----------ADD 2013/01/21----------->>>>>
        #region [SearchRefPurchaseReturnSchedule]
        /// <summary>
        /// 指定された検索条件に該当する仕入返品予定情報のリストを抽出します
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">検索結果(仕入返品予定データ)</param>
        /// <param name="suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        public int SearchRefPurchaseReturnSchedule(ref object suppPrtPprStcTblRsltWork, object suppPrtPprWork, out Int64 recordCount, int logicalDelDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            //初期化
            recordCount = 0;
            Int64 iRecCnt = 0;
            suppPrtPprStcTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (suppPrtPprWork == null) return status;

                #region [パラメータのキャスト]
                //仕入データ用 ArrayList
                ArrayList suppPrtPprStcTblRsltWorkArray = suppPrtPprStcTblRsltWork as ArrayList;

                if (suppPrtPprStcTblRsltWorkArray == null)
                {
                    suppPrtPprStcTblRsltWorkArray = new ArrayList();
                }
                //検索パラメータ
                SuppPrtPprWork _suppPrtPprWork = suppPrtPprWork as SuppPrtPprWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "仕入返品予定情報", "抽出開始");

                //Search実行
                #region [仕入データ検索]
                status = SearchRefProcPurchaseReturnSchedule(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, logicalDelDiv, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //実行時エラー
                    throw new Exception("検索実行時エラー：Status=" + status.ToString());
                }
                if (recordCount >= _suppPrtPprWork.SearchCnt)
                {
                    //処理件数オーバー
                    suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                #endregion

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "仕入返品予定情報", "抽出終了");

                //実行結果セット
                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                if (suppPrtPprStcTblRsltWork != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefPurchaseReturnSchedule Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion
        #region [SearchRefProcPurchaseReturnSchedule]
        /// <summary>
        /// 指定された検索条件に該当する仕入返品予定データのリストを抽出します(仕入返品予定データ)
        /// </summary>
        /// <param name="rsltWorkArray">検索結果(仕入データ)</param>
        /// <param name="_suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)戻り値用</param>
        /// <param name="iRecCnt">検索結果(件数)内部チェック用</param>
        /// <param name="logicalDelDiv">削除指定区分(0:通常 1:削除分のみ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI千田 晃久</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>管理番号   : </br>
        /// </remarks>
        private int SearchRefProcPurchaseReturnSchedule(ref ArrayList rsltWorkArray, SuppPrtPprWork _suppPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int logicalDelDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPprRetSch suppPrtPpr;
            suppPrtPpr = new SuppPrtPprRetSchStcTblRsltQuery();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprWork, logicalDelDiv);

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                //件数チェック用フラグ
                bool bCuntChkFlg = false;

                SuppPrtPprStcTblRsltWork suppPrtPprStcTblRsltWork = new SuppPrtPprStcTblRsltWork();

                while (myReader.Read())
                {
                    if (bCuntChkFlg != true)
                    {
                        //フラグON
                        bCuntChkFlg = true; 
                        //該当データ件数取得
                        iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                    }

                    //取得結果セット
                    rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprWork));
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefProc_StcTbl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProcPurchaseReturnSchedule]
        // ----------ADD 2013/01/21-----------<<<<<

        #region [残高照会・伝票表示・明細表示検索]

        #region [SearchRef]
        /// <summary>
        /// 指定された検索条件に該当する残高照会・伝票表示・明細表示のリストを抽出します
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWork">検索結果(残高照会)</param>
        /// <param name="suppPrtPprStcTblRsltWork">検索結果(売上データ)</param>
        /// <param name="suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫未出荷一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2009/09/08 黄偉兵　過去分表示対応</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2012/06/26 20008 伊藤 豊</br>
        /// <br>           : 課題No.1027 検索時に件数オーバーするとエラーになる現象を修正</br>
        public int SearchRef(ref object suppPrtPprBlDspRsltWork, ref object suppPrtPprStcTblRsltWork, object suppPrtPprWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            //初期化
            recordCount = 0;
            Int64 iRecCnt = 0;
            suppPrtPprBlDspRsltWork = null;
            suppPrtPprStcTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (suppPrtPprWork == null) return status;

                #region [パラメータのキャスト]
                //残高照会用 ArrayList
                ArrayList suppPrtPprBlDspRsltArray = suppPrtPprBlDspRsltWork as ArrayList;
                if (suppPrtPprBlDspRsltArray == null)
                {
                    suppPrtPprBlDspRsltArray = new ArrayList();
                }
                //仕入データ用 ArrayList
                ArrayList suppPrtPprStcTblRsltWorkArray = suppPrtPprStcTblRsltWork as ArrayList;
                if (suppPrtPprStcTblRsltWorkArray == null)
                {
                    suppPrtPprStcTblRsltWorkArray = new ArrayList();
                }
                //検索パラメータ
                SuppPrtPprWork _suppPrtPprWork = suppPrtPprWork as SuppPrtPprWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();               

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "仕入先電子元帳", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                //Search実行
                #region [仕入データ検索]
                if (_suppPrtPprWork.SearchType != (int)SearchType.Pay) // ADD 2008.10.21 伝票検索区分が 2:支払のみ以外の場合検索 >>> 
                {
                    // -------------ADD 2009/09/08 ------------>>>>>
                    // 非全ての場合
                    if (_suppPrtPprWork.SupplierFormal != null && _suppPrtPprWork.SupplierFormal.Length ==1)
                    {
                        status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                    }
                    // 全ての場合
                    else if (_suppPrtPprWork.SupplierFormal != null && _suppPrtPprWork.SupplierFormal.Length > 1)
                    {
                        // 0:仕入の検索が特別の検索
                        _suppPrtPprWork.SupplierFormal = new int[] { 0 };
                        status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                        // 1:入荷,2:発注の検索
                        if (status == (int)ConstantManagement.DB_Status.ctDB_EOF
                            || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 2012/06/26 Y.Ito ADD START 課題No.1027 件数オーバー時にエラーになる現象を修正
                            if (recordCount >= _suppPrtPprWork.SearchCnt)
                            {
                                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            // 2012/06/26 Y.Ito ADD END 課題No.1027 件数オーバー時にエラーになる現象を修正

                            iRecCnt = recordCount;
                            _suppPrtPprWork.SupplierFormal = new int[] { 1, 2 };
                            status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection);
                            _suppPrtPprWork.SupplierFormal = new int[] { 0, 1, 2 };
                        }
                    }
                    // -------------ADD 2009/09/08 ------------<<<<<
                    // status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTbl, readMode, logicalMode, ref sqlConnection); // DEL 2009/09/08
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //実行時エラー
                        throw new Exception("検索実行時エラー：Status=" + status.ToString());
                    }
                    if (recordCount >= _suppPrtPprWork.SearchCnt)
                    {
                        // 2012/06/26 Y.Ito MOD START 課題No.1027 件数オーバー時にエラーになる現象を修正
                        //処理件数オーバー
                        //throw new Exception("処理件数オーバー");
                        suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        // 2012/06/26 Y.Ito MOD END 課題No.1027 件数オーバー時にエラーになる現象を修正
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    # region [発注データ検索]
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 DEL
                    //List<int> list = new List<int>( _suppPrtPprWork.SupplierFormal );
                    //if ( list.Contains( 2 ) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
                    if ( CheckSelectOdr( _suppPrtPprWork ) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
                    {
                        iRecCnt = recordCount;

                        // SupplierFormatリストに2:発注が含まれる場合は発注データ検索
                        status = SearchRefProc( ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.StcTblOdr, readMode, logicalMode, ref sqlConnection );
                        if ( (status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                            (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) )
                        {
                            //実行時エラー
                            throw new Exception( "検索実行時エラー：Status=" + status.ToString() );
                        }
                        if ( recordCount >= _suppPrtPprWork.SearchCnt )
                        {
                            // 2012/06/26 Y.Ito MOD START 課題No.1027 件数オーバー時にエラーになる現象を修正
                            //処理件数オーバー
                            //throw new Exception("処理件数オーバー");
                            suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // 2012/06/26 Y.Ito MOD END 課題No.1027 件数オーバー時にエラーになる現象を修正
                        }
                    }
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                #endregion
                
                #region [支払データ検索]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 DEL
                //if (_suppPrtPprWork.SearchType != (int)SearchType.Sup && _suppPrtPprWork.PartySaleSlipNum == "") // ADD 2008.10.21 伝票検索区分が 1:仕入のみ以外の場合検索 >>> 
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
                if ( CheckSelectPayment( _suppPrtPprWork ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
                {

                    iRecCnt = recordCount;
                    status = SearchRefProc(ref suppPrtPprStcTblRsltWorkArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.PayTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //実行時エラー
                        throw new Exception("検索実行時エラー：Status=" + status.ToString());
                    }
                    if (recordCount >= _suppPrtPprWork.SearchCnt)
                    {
                        // 2012/06/26 Y.Ito MOD START 課題No.1027 件数オーバー時にエラーになる現象を修正
                        //処理件数オーバー
                        //throw new Exception("処理件数オーバー");
                        suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        // 2012/06/26 Y.Ito MOD END 課題No.1027 件数オーバー時にエラーになる現象を修正
                    }   
                }
                #endregion

                #region [残高照会検索]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
                //iRecCnt = recordCount;
                //status = SearchRefProc(ref suppPrtPprBlDspRsltArray, _suppPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.BlDsp, readMode, logicalMode, ref sqlConnection);
                //if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                //    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                //{
                //    //実行時エラー
                //    throw new Exception("検索実行時エラー：Status=" + status.ToString());
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
                #endregion

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprWork.EnterpriseCode, "仕入先電子元帳", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<

                //実行結果セット
                suppPrtPprBlDspRsltWork = suppPrtPprBlDspRsltArray;
                suppPrtPprStcTblRsltWork = suppPrtPprStcTblRsltWorkArray;

                // ADD 2008.11.26 >>>
                if ((suppPrtPprBlDspRsltWork != null) || (suppPrtPprStcTblRsltWork != null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2008.11.26 <<<

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/10 ADD
        /// <summary>
        /// 発注データ検索実行チェック処理
        /// </summary>
        /// <param name="_suppPrtPprWork"></param>
        /// <returns></returns>
        /// <remarks>※共通条件クラスの内容から発注データ検索有無を判断します</remarks>
        private bool CheckSelectOdr( SuppPrtPprWork paraWork )
        {
            // 受注ステータス 2:発注を含まないなら迂回
            List<int> list = new List<int>( paraWork.SupplierFormal );
            if ( !list.Contains( 2 ) ) return false;

            // 支払先が入力されていたら迂回
            if ( paraWork.PayeeCode != 0 ) return false;

            // 仕入伝票番号指定ありなら迂回
            if ( paraWork.PartySaleSlipNum != string.Empty ) return false;

            // 値引区分指定ありなら迂回
            if ( paraWork.StockSlipCdDtl != 0 ) return false;

            // 発注データ検索する
            return true;
        }
        /// <summary>
        /// 支払データ検索実行チェック処理
        /// </summary>
        /// <param name="_suppPrtPprWork"></param>
        /// <returns></returns>
        /// <remarks>※共通条件クラスの内容から支払データ検索有無を判断します</remarks>
        private bool CheckSelectPayment( SuppPrtPprWork paraWork )
        {
            // 検索タイプ：仕入データのみならば迂回
            if ( paraWork.SearchType == (int)SearchType.Sup ) return false;

            // 仕入伝票番号指定ありなら迂回
            if ( paraWork.PartySaleSlipNum != string.Empty ) return false;

            // UOE発注指定ありなら迂回
            if ( paraWork.WayToOrder != 0 ) return false;

            // 備考２指定ありなら迂回
            if ( paraWork.SupplierSlipNote2 != string.Empty ) return false;

            // UOEﾘﾏｰｸ１指定ありなら迂回
            if ( paraWork.UoeRemark1 != string.Empty ) return false;

            // UOEﾘﾏｰｸ２指定ありなら迂回
            if ( paraWork.UoeRemark2 != string.Empty ) return false;

            // グループコード指定ありなら迂回
            if ( paraWork.BLGroupCode != 0 ) return false;

            // BLコード指定ありなら迂回
            if ( paraWork.BLGoodsCode != 0 ) return false;

            // 品番指定ありなら迂回
            if ( paraWork.GoodsNo != string.Empty ) return false;

            // メーカーコード指定ありなら迂回
            if ( paraWork.GoodsMakerCd != 0 ) return false;

            // 在庫取寄区分指定ありなら迂回
            if ( paraWork.StockOrderDivCd > -1 ) return false;

            // 倉庫コード指定ありなら迂回
            if ( paraWork.WarehouseCode != string.Empty ) return false;

            // 値引区分指定ありなら迂回
            if ( paraWork.StockSlipCdDtl != 0 ) return false;


            // 支払データ検索する
            return true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/10 ADD
        #endregion

        #region [SearchRefProc]
        /// <summary>
        /// 指定された検索条件に該当する伝票表示・明細表示データのリストを抽出します(売上データ)
        /// </summary>
        /// <param name="rsltWorkArray">検索結果(仕入データ)</param>
        /// <param name="_suppPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)戻り値用</param>
        /// <param name="iRecCnt">検索結果(件数)内部チェック用</param>
        /// <param name="iType">検索タイプ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchRefProc(ref ArrayList rsltWorkArray, SuppPrtPprWork _suppPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int iType, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPpr suppPrtPpr;
            suppPrtPpr = new SuppPrtPprStcTblRsltQuery();
            if (iType == (int)iSrcType.BlDsp) suppPrtPpr = new SuppPrtPprBlDspRsltQuery();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprWork, iType, logicalMode);

                // 2012/06/26 Y.Ito ADD START タイムアウトを延長
                sqlCommand.CommandTimeout = 3600;
                // 2012/06/26 Y.Ito ADD END タイムアウトを延長

                myReader = sqlCommand.ExecuteReader();

                //件数チェック用フラグ
                bool bCuntChkFlg = false;
                if (iType == (int)iSrcType.BlDsp) bCuntChkFlg = true;

                while (myReader.Read())
                {
                    #region 件数チェック
                    if (bCuntChkFlg != true)
                    {
                        bCuntChkFlg = true;  //フラグON
                        //該当データ件数取得
                        iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                        // 2012/06/26 Y.Ito DEL START 件数チェックはここでは行わない。
                        //件数チェック
                        //if (iRecCnt >= _suppPrtPprWork.SearchCnt)
                        //{
                        //    //検索上限オーバーの場合はBreak
                        //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        //    break;
                        //}
                        // 2012/06/26 Y.Ito DEL END 件数チェックはここでは行わない。
                    }
                    #endregion

                    //取得結果セット
                    rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprWork, iType));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchRefProc_StcTbl Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            recordCount = iRecCnt;

            return status;
        }
        #endregion  //[SearchRefProc]

        #endregion  //[残高照会・伝票表示・明細表示検索]

        #region [残高一覧検索]

        #region [SearchBlTbl]
        /// <summary>
        /// 指定された検索条件に該当する残高一覧表示のリストを抽出します
        /// </summary>
        /// <param name="suppPrtPprBlTblRsltWork">検索結果</param>
        /// <param name="suppPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:支払 1:買掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫未出荷一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>UpdateNote : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        /// <br>Update Note: </br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int SearchBlTbl(ref object suppPrtPprBlTblRsltWork, object suppPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            suppPrtPprBlTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (suppPrtPprBlnceWork == null) return status;

                #region [パラメータのキャスト]
                //残高一覧用 ArrayList
                ArrayList suppPrtPprBlTblRsltArray = suppPrtPprBlTblRsltWork as ArrayList;
                if (suppPrtPprBlTblRsltArray == null)
                {
                    suppPrtPprBlTblRsltArray = new ArrayList();
                }
                //検索パラメータ
                SuppPrtPprBlnceWork _suppPrtPprBlnceWork = suppPrtPprBlnceWork as SuppPrtPprBlnceWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ---ADD 2011/03/22---------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprBlnceWork.EnterpriseCode, "仕入先電子元帳", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
                string[] sectionCodes = _suppPrtPprBlnceWork.SectionCode;
                if (sectionCodes != null)
                {
                    foreach (string sectionCode in sectionCodes)
                    {
                        _suppPrtPprBlnceWork.SectionCode = new string[] { sectionCode };
                        //SearchBlTbl実行
                        status = SearchBlTblProc(ref suppPrtPprBlTblRsltArray, _suppPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);
                    }
                    if (suppPrtPprBlTblRsltArray.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
                    //SearchBlTbl実行
                    status = SearchBlTblProc(ref suppPrtPprBlTblRsltArray, _suppPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);
                }// ADD 2010/07/20 

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _suppPrtPprBlnceWork.EnterpriseCode, "仕入先電子元帳", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<

                //実行結果セット
                suppPrtPprBlTblRsltWork = suppPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion  //[SearchBlTbl]

        #region [SearchBlTblProc]
        /// <summary>
        /// 指定された検索条件に該当する残高一覧表示のリストを抽出します
        /// </summary>
        /// <param name="rsltWorkArray">検索結果</param>
        /// <param name="_suppPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>UpdateNote : 2015/08/17 田思春</br>
        /// <br>           　Redmine#47007：消費税などが不正の障害対応</br> 
        /// <br>Update Note: 2015/12/22 顧棟</br>
        /// <br>管理番号   : 11170204-00 2016年1月配信分</br>
        /// <br>             Redmine#48327 仕入電子元帳残高テキスト出力不正障害１、２の対応</br>
        /// <br>             障害１:複数拠点の実績が出力されない </br>
        /// <br>             障害２:前回実績がない場合「前回残高」、「繰越残高」、「今回残高」に前拠点の「今回残高」がプラスされてしまう</br>
        /// <br>Update Note: 2016/02/02 顧棟</br>
        /// <br>管理番号   : 11200002-00 2016年2月配信分</br>
        /// <br>             Redmine#48327 仕入総括オプションが有効の場合に全拠点分のレコードを出力し実績がないものはALLゼロにする</br>
        private int SearchBlTblProc(ref ArrayList rsltWorkArray, SuppPrtPprBlnceWork _suppPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害１の対応 ----->>>>>
            // 画面から最初の検索条件の変数を一時退避
            int st_supplierCd = _suppPrtPprBlnceWork.St_SupplierCd;
            int ed_supplierCd = _suppPrtPprBlnceWork.Ed_SupplierCd;
            int payeeCode = _suppPrtPprBlnceWork.PayeeCode;
            // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害１の対応 -----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ISuppPrtPpr suppPrtPpr;
            suppPrtPpr = new SuppPrtPprBlTblRsltQuery();
            // --- DEL 2016/02/02 顧棟 Redmine#48327 ----->>>>>
            //1拠点1仕入先分毎に取得月一覧を新規する為、ここに削除する
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            //List<Int32> monthList = new List<Int32>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            // --- DEL 2016/02/02 顧棟 Redmine#48327 -----<<<<<

            //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応---------->>>>>
            ArrayList suplWorkList = new ArrayList();
            Dictionary<int, string> suppDic = new Dictionary<int, string>();

            if (_suppPrtPprBlnceWork.SearchDiv == 1)
            {
                // Excel・テキスト出力の場合、仕入先リストを取得
                GetSupplier(_suppPrtPprBlnceWork, ref suplWorkList, out suppDic, ref sqlConnection);
            }
            else
            {
                // 画面からの場合、仕入先リストを取得
                suplWorkList.Add(_suppPrtPprBlnceWork.PayeeCode);
            }

            // 仕入先コードによって出力値を取得する
            foreach (int supplierCd in suplWorkList)
            {
                _suppPrtPprBlnceWork.PayeeCode = supplierCd;
                _suppPrtPprBlnceWork.St_SupplierCd = supplierCd;
                _suppPrtPprBlnceWork.Ed_SupplierCd = supplierCd;

                // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応 ----->>>>>
                //1拠点1仕入先分の残高データ（仕入先コードが変わった場合、再度新規）前月残高取得用
                ArrayList rsltWorkArrayForLastTimeBlc = new ArrayList();
                // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応 -----<<<<<
                // --- ADD 2016/02/02 顧棟 Redmine#48327 ----->>>>>
                //1拠点1仕入先分毎に取得月一覧を新規する
                List<Int32> monthList = new List<Int32>();
                // --- ADD 2016/02/02 顧棟 Redmine#48327 -----<<<<<
            //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応 ----------<<<<<

                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection);

                    //SELECT文生成
                    sqlCommand.CommandText = suppPrtPpr.MakeSelectString(ref sqlCommand, _suppPrtPprBlnceWork, SrchKndDiv, logicalMode);

                    // 2012/06/26 Y.Ito ADD START タイムアウトを延長
                    sqlCommand.CommandTimeout = 3600;
                    // 2012/06/26 Y.Ito ADD END タイムアウトを延長

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                        ////取得結果セット
                        //rsltWorkArray.Add(suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprBlnceWork, SrchKndDiv));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                        //取得結果セット
                        SuppPrtPprBlTblRsltWork retWork = (SuppPrtPprBlTblRsltWork)suppPrtPpr.CopyToResultWorkFromReader(ref myReader, _suppPrtPprBlnceWork, SrchKndDiv);
                        rsltWorkArray.Add(retWork);
                        rsltWorkArrayForLastTimeBlc.Add(retWork);// ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応

                        //取得月一覧追加
                        monthList.Add((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(retWork.AddUpYearMonth));
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "SuppPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    if (sqlCommand != null) sqlCommand.Dispose();
                    if (!myReader.IsClosed) myReader.Close();
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                if ( SrchKndDiv == (int)iSrchKndDiv.SuplAcc )
                {
                    FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator(_suppPrtPprBlnceWork.EnterpriseCode, ref sqlConnection);
                    if (finYearTableGenerator != null)
                    {
                        # region [月次未締範囲]
                        // 前回月次締処理日取得
                        DateTime prevTotalDay = CheckPrcMonthlyAccRec(_suppPrtPprBlnceWork, ref sqlConnection);

                        // 指定月範囲
                        int monthCount = GetMonthsCount(_suppPrtPprBlnceWork.Ed_AddUpYearMonth, _suppPrtPprBlnceWork.St_AddUpYearMonth);
                        for (int monthIndex = 0; monthIndex < monthCount; monthIndex++)
                        {
                            DateTime targetMonth = _suppPrtPprBlnceWork.St_AddUpYearMonth.AddMonths(monthIndex);

                            // --- DEL 2012/11/08 ---------->>>>>
                            // 取得できなかった月に対しての処理
                            //if ( !monthList.Contains( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( targetMonth ) ) &&
                            //      (prevTotalDay < targetMonth) )
                            //{
                            //    //---------------------------------------------------
                            //    // 自社締め月範囲
                            //    //---------------------------------------------------
                            //    # region [自社締め月範囲]
                            //    DateTime stDate;
                            //    DateTime edDate;
                            //    finYearTableGenerator.GetDaysFromMonth( targetMonth, out stDate, out edDate );
                            //    # endregion
                            // --- DEL 2012/11/08 ----------<<<<<
                            // --- ADD 2012/11/08 ---------->>>>>
                            //---------------------------------------------------
                            // 自社締め月範囲
                            //---------------------------------------------------
                            # region [自社締め月範囲]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth(targetMonth, out stDate, out edDate);
                            # endregion

                            // 取得できなかった月に対しての処理
                            // --- ADD 2016/02/02 顧棟 Redmine#48327 ----->>>>>
                            //仕入総括オプションが有効の場合、前回月次締処理日と画面からの対象年月を無視し、全拠点分のレコードを出力する。
                            //仕入総括オプションが無効の場合、前回月次締処理日＜画面からの対象年月のレコードを出力する(仕様保留)。
                            if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                                  ((!_suppPrtPprBlnceWork.OptSupplierSummary && (prevTotalDay < edDate)) || _suppPrtPprBlnceWork.OptSupplierSummary))
                            // --- ADD 2016/02/02 顧棟 Redmine#48327 -----<<<<<
                            // --- DEL 2016/02/02 顧棟 Redmine#48327 ----->>>>>
                            //if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                            //      (prevTotalDay < edDate))
                            // --- DEL 2016/02/02 顧棟 Redmine#48327 -----<<<<<
                            {
                                // --- ADD 2012/11/08 ----------<<<<<

                                //---------------------------------------------------
                                // 条件パラメータセット
                                //---------------------------------------------------
                                # region [条件パラメータセット]
                                SuplAccPayWork paraWork = new SuplAccPayWork();
                                paraWork.EnterpriseCode = _suppPrtPprBlnceWork.EnterpriseCode;                //企業コード
                                //paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);// DEL 2015/08/17 田思春 For Redmine#47007 障害1 消費税などが不正の障害対応

                                //----- ADD 2015/08/17 田思春 For Redmine#47007 障害1 消費税などが不正の障害対応---------->>>>>
                                //計上年月を設定する
                                if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                                {
                                    paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                                }
                                else
                                {
                                    paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                                }
                                //----- ADD 2015/08/17 田思春 For Redmine#47007 障害1 消費税などが不正の障害対応 ----------<<<<<

                                paraWork.AddUpDate = edDate;
                                paraWork.AddUpYearMonth = targetMonth;                //計上年月
                                paraWork.AddUpSecCode = _suppPrtPprBlnceWork.SectionCode[0];  //計上拠点コード ※得意先マスタリストから
                                paraWork.SupplierCd = _suppPrtPprBlnceWork.SupplierCd;     //得意先コード   ※得意先マスタリストから
                                if (paraWork.SupplierCd == 0)
                                {
                                    paraWork.SupplierCd = _suppPrtPprBlnceWork.PayeeCode;
                                }
                                //----- ADD 2015/08/17 田思春 For Redmine#47007 障害1 消費税などが不正の障害対応 ---------->>>>>
                                //条件を作成する時、仕入先コードと同じ値を支払先にセットする、MAKAU00133RAの仕入データ取得メソッドに、受けたパラメータの仕入先コード＝受けたパラメータの支払先コードの時、仕入データを検索する仕様がある
                                if (paraWork.PayeeCode == 0)
                                {
                                    paraWork.PayeeCode = _suppPrtPprBlnceWork.PayeeCode;
                                }
                                //----- ADD 2015/08/17 田思春 For Redmine#47007 障害1 消費税などが不正の障害対応 ----------<<<<<
                                # endregion

                                //---------------------------------------------------
                                // 売掛金・買掛金算出モジュール呼び出し
                                //---------------------------------------------------
                                # region [売掛金・買掛金算出モジュール呼び出し]
                                MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                                object paraObj = paraWork;
                                string retMsg;
                                // --- DEL 2012/09/13 ---------->>>>>
                                //int accStatus = monthlyAddUpDB.ReadSuplAccPay( ref paraObj, out retMsg, ref sqlConnection );
                                // --- DEL 2012/09/13 ----------<<<<<
                                // --- ADD 2012/09/13 ---------->>>>>
                                int accStatus = 0;
                                if (_suppPrtPprBlnceWork.OptSupplierSummary)
                                {
                                    // 仕入総括オプションが有効の場合
                                    accStatus = monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj, out retMsg, ref sqlConnection);
                                }
                                else
                                {   // 仕入総括オプションが無効の場合
                                    accStatus = monthlyAddUpDB.ReadSuplAccPay(ref paraObj, out retMsg, ref sqlConnection);
                                }
                                // --- ADD 2012/09/13 ----------<<<<<

                                if (accStatus == 0)
                                {
                                    SuppPrtPprBlTblRsltWork rsltWork = new SuppPrtPprBlTblRsltWork();

                                    // 結果セット
                                    # region [結果セット]
                                    SuplAccPayWork retWork = (SuplAccPayWork)paraObj;
                                    //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応---------->>>>>
                                    // Excel・テキスト出力の場合、仕入先コードと拠点コードと仕入先名を取得する
                                    if (_suppPrtPprBlnceWork.SearchDiv == 1)
                                    {
                                        rsltWork.AddUpSecCode = retWork.AddUpSecCode;
                                        rsltWork.SupplierCd = retWork.PayeeCode;
                                        if (suppDic.ContainsKey(retWork.PayeeCode))
                                        {
                                            rsltWork.SupplierNm1 = suppDic[retWork.PayeeCode];
                                        }
                                    }
                                    //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応 ----------<<<<<
                                    rsltWork.AddUpDate = retWork.AddUpDate;
                                    rsltWork.LastTimeBlc = retWork.LastTimeAccPay;
                                    rsltWork.ThisTimePayNrml = retWork.ThisTimePayNrml;
                                    rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcPay;
                                    rsltWork.ThisTimeStockPrice = retWork.ThisTimeStockPrice;
                                    rsltWork.ThisStckPricRgdsDis = retWork.ThisStckPricRgds + retWork.ThisStckPricDis;
                                    rsltWork.OfsThisTimeStock = retWork.OfsThisTimeStock;
                                    rsltWork.OfsThisStockTax = retWork.OfsThisStockTax;
                                    rsltWork.ThisStckPricTotal = retWork.OfsThisTimeStock + retWork.OfsThisStockTax;
                                    rsltWork.StckTtlPayBlc = retWork.StckTtlAccPayBalance;
                                    rsltWork.StockSlipCount = retWork.StockSlipCount;
                                    # endregion

                                    // 前月残高の反映
                                    # region [前月残高の反映]
                                    //int prevIndex = rsltWorkArray.Count - 1;// DEL 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応
                                    int prevIndex = rsltWorkArrayForLastTimeBlc.Count - 1;// ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応
                                    //-----ADD 2015/08/17 田思春 For Redmine#47007 障害3 取得失敗の障害対応---------->>>>>
                                    if (prevIndex >= 0)
                                    {
                                    //----- ADD 2015/08/17 田思春 For Redmine#47007 障害3 取得失敗の障害対応 ----------<<<<<
                                        //rsltWork.LastTimeBlc = ((SuppPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).StckTtlPayBlc; // 前月残高// DEL 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応
                                        rsltWork.LastTimeBlc = ((SuppPrtPprBlTblRsltWork)rsltWorkArrayForLastTimeBlc[prevIndex]).StckTtlPayBlc; // 前月残高// ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応
                                        // 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                        rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimePayNrml;// 今回繰越残高(売掛)
                                        // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                        rsltWork.StckTtlPayBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeStock + rsltWork.OfsThisStockTax);// 計算後請求金額
                                    } // ADD 2015/08/17 田思春 For Redmine#47007 障害3 取得失敗の障害対応
                                    # endregion

                                    rsltWorkArray.Add(rsltWork);
                                    rsltWorkArrayForLastTimeBlc.Add(rsltWork);// ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害２の対応

                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                # endregion
                            }
                        }
                        # endregion
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            }

            // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害１の対応 ----->>>>>
            //抽出する前に画面からの検索条件を回復
            //-----------------------------------------------------------------------------------------------
            //改修原因: 1拠点目の残高データを取得する時、画面からの検索条件が変更されて、
            //1拠点目以降の仕入先リストの取得が間違い、残高データの取得は失敗になる
            //-----------------------------------------------------------------------------------------------
            _suppPrtPprBlnceWork.St_SupplierCd = st_supplierCd;
            _suppPrtPprBlnceWork.Ed_SupplierCd = ed_supplierCd;
            _suppPrtPprBlnceWork.PayeeCode = payeeCode;
            // --- ADD 2015/12/22 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害１の対応 ----->>>>>
            return status;
        }

        //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応---------->>>>>
        /// <summary>
        /// EXCEL、テキスト出力画面指定された検索条件に該当する仕入先リストを抽出する
        /// </summary>
        /// <param name="suppPrtPprBlnceWork">検索条件</param>
        /// <param name="suplWorkList">仕入先リスト</param>
        /// <param name="suppDic">仕入先情報Dictionary</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 田思春</br>
        /// <br>             Redmine#47007：出力件数が不正の障害対応</br>
        /// <br>Update Note: 2015/12/25 顧棟</br>
        /// <br>管理番号   : 11170204-00 2016年1月配信分</br>
        /// <br>             Redmine#48327 仕入電子元帳残高テキスト出力不正障害３の対応</br>
        /// <br>             障害３：残高表示タブで仕入総括オプションが有効の場合にテキスト出力を行うと仕入先コード≠支払先コードの残高が表示されない</br>
        /// </remarks>
        private int GetSupplier(SuppPrtPprBlnceWork suppPrtPprBlnceWork, ref ArrayList suplWorkList, out Dictionary<int, string> suppDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            suppDic = new Dictionary<int, string>();

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandTimeout = 600;
                    sqlCommand.Connection = sqlConnection;

                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "   A.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,A.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "  ,A.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "  SUPPLIERRF AS A" + Environment.NewLine;
                    sqlText += "  WITH(READUNCOMMITTED)" + Environment.NewLine;
                    //WHRERE句
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "  A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND A.LOGICALDELETECODERF=0" + Environment.NewLine;
                    // --- ADD 2015/12/25 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害３の対応 ----->>>>>
                    //仕入総括オプションが無効の場合、「仕入先 = 支払先」、「支払拠点が画面の条件範囲内」、「支払拠点が有効な拠点」の検索条件を含む
                    if (!suppPrtPprBlnceWork.OptSupplierSummary)
                    {
                        // --- ADD 2015/12/25 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害３の対応 -----<<<<<
                        sqlText += "  AND A.SUPPLIERCDRF=A.PAYEECODERF" + Environment.NewLine;

                        //拠点コード
                        if (suppPrtPprBlnceWork.SectionCode != null)
                        {
                            string sectionCodestr = "";
                            foreach (string seccdstr in suppPrtPprBlnceWork.SectionCode)
                            {
                                if (sectionCodestr != "")
                                {
                                    sectionCodestr += ",";
                                }
                                sectionCodestr += "'" + seccdstr + "'";
                            }
                            if (sectionCodestr != "")
                            {
                                sqlText += "AND A.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                                sqlText += "AND A.PAYMENTSECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF = 0)";
                            }
                            sqlText += Environment.NewLine;
                        }
                    }//ADD 2015/12/25 顧棟 Redmine#48327 仕入電子元帳残高テキスト出力不正障害３の対応

                    if (suppPrtPprBlnceWork.St_SupplierCd != 0)
                    {
                        sqlText += "  AND A.SUPPLIERCDRF>=@FINDSUPPLIERCDST" + Environment.NewLine;
                        SqlParameter findParaSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUPPLIERCDST", SqlDbType.Int);
                        findParaSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(suppPrtPprBlnceWork.St_SupplierCd);
                    }
                    if (suppPrtPprBlnceWork.Ed_SupplierCd != 0)
                    {
                        sqlText += "  AND A.SUPPLIERCDRF<=@FINDSUPPLIERCDED" + Environment.NewLine;
                        SqlParameter findParaSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDED", SqlDbType.Int);
                        findParaSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(suppPrtPprBlnceWork.Ed_SupplierCd);
                    }

                    sqlText += " ORDER BY" + Environment.NewLine;
                    sqlText += "  A.SUPPLIERCDRF" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suppPrtPprBlnceWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        int supplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                        string supplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                        //仕入先コードと仕入先名を取得する
                        if (!suppDic.ContainsKey(supplierCd))
                        {
                            suppDic.Add(supplierCd, supplierName);
                        }
                        else
                        {
                            suppDic[supplierCd] = supplierName;
                        }

                        suplWorkList.Add(supplierCd);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        //----- ADD 2015/08/17 田思春 For Redmine#47007：障害2　出力件数が不正の障害対応 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
        /// <summary>
        /// 会計年度テーブル生成部品取得
        /// </summary>
        /// <returns></returns>
        private FinYearTableGenerator GetFinYearTableGenerator( string enterpriseCode, ref SqlConnection sqlConnection )
        {
            FinYearTableGenerator finYearTableGenerator = null;

            // 自社情報レコード取得
            CompanyInfDB companyInfDB = new CompanyInfDB();
            CompanyInfWork paraWork = new CompanyInfWork();
            paraWork.EnterpriseCode = enterpriseCode;
            ArrayList retList;
            companyInfDB.Search( out retList, paraWork, ref sqlConnection );
            if ( retList != null && retList.Count > 0 )
            {
                // 会計年度部品生成
                finYearTableGenerator = new FinYearTableGenerator( (CompanyInfWork)retList[0] );
            }

            return finYearTableGenerator;
        }
        /// <summary>
        /// 売掛締済みチェック
        /// </summary>
        /// <param name="custPrtPprBlnceWork"></param>
        private DateTime CheckPrcMonthlyAccRec( SuppPrtPprBlnceWork suppPrtPprBlnceWork, ref SqlConnection sqlConnection )
        {
            // 締済チェック
            TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();

            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = suppPrtPprBlnceWork.EnterpriseCode;
            paraWork.SectionCode = suppPrtPprBlnceWork.SectionCode[0];
            paraWork.SupplierCd = suppPrtPprBlnceWork.SupplierCd;
            if ( paraWork.SupplierCd == 0 )
            {
                paraWork.SupplierCd = suppPrtPprBlnceWork.PayeeCode;
            }
            List<TtlDayCalcRetWork> retList;

            int status = ttlDayCalcDB.SearchHisMonthlyAccPay( out retList, paraWork, ref sqlConnection );
            if ( status == 0 && retList != null && retList.Count > 0 )
            {
                TtlDayCalcRetWork retWork = (TtlDayCalcRetWork)retList[0];
                DateTime totalDay;
                try
                {
                    if ( retWork.TotalDay != 0 )
                    {
                        totalDay = new DateTime( (retWork.TotalDay / 10000), ((retWork.TotalDay / 100) % 100), (retWork.TotalDay % 100) );
                    }
                    else
                    {
                        totalDay = DateTime.MinValue;
                    }
                }
                catch
                {
                    totalDay = DateTime.MinValue;
                }
                return totalDay;
            }

            return DateTime.MinValue;
        }
        /// <summary>
        /// 月数算出
        /// </summary>
        /// <param name="edDate"></param>
        /// <param name="stDate"></param>
        /// <returns></returns>
        private int GetMonthsCount( DateTime edDate, DateTime stDate )
        {
            int difOfYear = edDate.Year - stDate.Year;
            int difOfMonth = edDate.Month - stDate.Month;

            return ((difOfYear * 12) + (difOfMonth)) + 1;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
        #endregion  //[SearchBlTblProc]

        #endregion  //[残高一覧検索]
    }

    interface ISuppPrtPpr
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam);
    }

    // ----------ADD 2013/01/21----------->>>>>
    interface ISuppPrtPprRetSch
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int logicalDelDiv);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork);
    }
    // ----------ADD 2013/01/21-----------<<<<<

    /// <summary>
    /// 伝票・明細の検索タイプを列挙します。
    /// </summary>
    enum iSrcType
    {
        StcTbl = 0,  //仕入データ検索
        PayTbl = 1,  //支払データ検索
        BlDsp = 2,   //残高照会検索
        BlTbl = 3,    //残高一覧検索(未使用)
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
        StcTblOdr = 4, // 仕入(発注データ)検索
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
    }

    /// <summary>
    /// 残高一覧の検索タイプを列挙します。
    /// </summary>
    enum iSrchKndDiv
    {
        Suplier = 0,  //仕入先支払金額マスタ
        SuplAcc = 1   //仕入先買掛金額マスタ
    }
    // ADD 2008.10.21 >>>
    /// <summary>
    /// 伝票検索区分を列挙します。
    /// </summary>
    enum SearchType
    {
        All = 0,  //0:全て
        Sup = 1,  //1:仕入のみ
        Pay = 2   //2:支払のみ
    }
    // ADD 2008.10.21 <<<
}
