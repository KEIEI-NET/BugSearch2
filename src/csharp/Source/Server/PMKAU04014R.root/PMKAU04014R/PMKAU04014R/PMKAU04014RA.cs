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
// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先電子元帳 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.07.30</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.12.09</br>
    /// <br></br>
    /// <br>Update Note: 項目追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.01.06 2009.01.30</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正( 販売区分名称取得処理の不具合修正 )</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009/05/12</br>
    /// <br></br>
    /// <br>Update Note: 見出貼付機能の追加の為、抽出項目を追加。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.08.10</br>
    /// <br></br>
    /// <br>Update Note: 過去分表示対応（売上データに無く、売上履歴にある分を追加）</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.08.24</br>
    /// <br></br>
    /// <br>Update Note: 過去分表示速度アップ対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.09.04</br>
    /// <br></br>
    /// <br>Update Note: 表示速度アップ対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009/10/05</br>
    /// <br></br>
    /// <br>Update Note: 【MANTIS:0015241】見出貼付の修正</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/04/02</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br></br>
    /// <br>Update Note: UOE発注データの結合条件不具合対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/07</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/09</br>
    /// <br></br>
    /// <br>Update Note: 残高一覧表示の前回残高を修正（前回＋前々回＋前々々回）</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/12/20</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 2011/04/06 曹文傑</br>
    /// <br>             Redmine#20387の対応</br>
    /// <br></br>
    /// <br>Update Note: テキスト出力の残高一覧に与信残高を追加</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
    /// <br>             ①与信残高出力件数不正の修正。</br>
    /// <br>             ②与信残高出力場合、抽出データは前月データだけ場合、前月のデータを削除</br>
    /// <br>Programmer : xuyb</br>
    /// <br>Date       : 2013/03/29</br>
    /// <br>Update Note: 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
    /// <br>             与信残高出力内容不正の修正。</br>
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : 2013/04/12</br>
    /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号(VINコード)による抽出を可能にする</br>
    /// <br>Programmer : FSI厚川 宏</br>
    /// <br>Date       : 2013/03/25</br>
    /// <br>Update Note: Redmine#39753得意先電子元帳に残高一覧の消費税不正になる件の対応</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2013/10/24</br>
    /// <br>Update Note: Redmine#41206 №26の対応</br>
    /// <br>             得意先電子元帳に対象年月(開始)に売上月次更新が未処理の月を指定した場合、残高一覧が表示されない</br>
    /// <br>Programmer : gezh</br>
    /// <br>Date       : 2013/11/11</br>
    /// <br></br>
    /// <br>Update Note: テキスト出力の残高一覧に与信残高を追加</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2014/07/04</br>
    /// <br>Update Note: PM-SCM仕掛一覧 №10666</br>
    /// <br>             BLPの発注で自動回答した売上を赤伝発行すると車輌情報が消える障害対応</br>
    /// <br>Update Note: 2015/02/05 王亜楠</br>
    /// <br>           : テキスト出力件数制限なしモードの追加</br>
    /// <br>UpdateNote : 2015/03/03 王亜楠 Redmine#44701</br>
    /// <br>           : 画面の売上日が指定されない場合、入金データから開始・終了入金日を検索する</br>
    /// <br>Update Note: K2016/02/23 時シン</br>
    /// <br>管理番号   : 11200090-00 イケモ 得意先電子元帳</br>
    /// <br>             ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
    /// <br>Update Note: 2022/05/05 仰亮亮</br>
    /// <br>管理番号   : 11870080-00</br>
    /// <br>           : 納品書電子帳簿連携対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CustPrtPprWorkDB : RemoteDB, ICustPrtPprWorkDB
    {
        // -- DEL 2009/09/04 --------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //public Dictionary<string, string> _slipKeyDic;
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        private SalesSlipDB _salesSlipDB = null; // 売上リモート
        private StockSlipDB _stockSlipDB = null; // 仕入リモート  
        private SalesSlipHistDB _salesSlipHistDB = null; // 売上履歴リモート
        private StockSlipHistDB _stockSlipHistDB = null; // 仕入履歴リモート
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        /// <summary>
        /// 得意先電子元帳 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// </remarks>
        public CustPrtPprWorkDB()
        {
        }

        #region [残高照会・伝票表示・明細表示検索]

        #region [SearchRef]
        /// <summary>
        /// 指定された検索条件に該当する残高照会・伝票表示・明細表示のリストを抽出します
        /// </summary>
        /// <param name="custPrtPprBlDspRsltWork">検索結果(残高照会)</param>
        /// <param name="custPrtPprSalTblRsltWork">検索結果(売上データ)</param>
        /// <param name="custPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫未出荷一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2011/04/06 曹文傑</br>
        /// <br>             操作履歴表示で、機能＝「得意先電子元帳」を選択して「表示更新」を実行した時の絞り込みを有効にする為。</br>
        /// <br>UpdateNote : 2015/03/03 王亜楠 Redmine#44701</br>
        /// <br>           : 抽出件数制限なしの場合、入金データの検索件数制限を削除する</br>
        /// <br>Update Note:K2016/02/23 時シン</br>
        /// <br>            ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int SearchRef(ref object custPrtPprBlDspRsltWork, ref object custPrtPprSalTblRsltWork, object custPrtPprWork, out Int64 recordCount, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            // -- UPD 2009/10/05 MANTIS 14396---------------------------->>>
            //異常終了しない場合でも、全ての検索が通らないパターンでエラーとなってしまうためステータスを修正
            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // -- UPD 2009/10/05 ----------------------------------------<<<
            SqlConnection sqlConnection = null;

            //初期化
            recordCount = 0;
            Int64 iRecCnt = 0;
            custPrtPprBlDspRsltWork = null;
            custPrtPprSalTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (custPrtPprWork == null) return status;

                #region [パラメータのキャスト]
                //残高照会用 ArrayList
                ArrayList custPrtPprBlDspRsltArray = custPrtPprBlDspRsltWork as ArrayList;
                if (custPrtPprBlDspRsltArray == null)
                {
                    custPrtPprBlDspRsltArray = new ArrayList();
                }
                //売上データ用 ArrayList
                ArrayList custPrtPprSalTblRsltWorkArray = custPrtPprSalTblRsltWork as ArrayList;
                if (custPrtPprSalTblRsltWorkArray == null)
                {
                    custPrtPprSalTblRsltWorkArray = new ArrayList();
                }
                //検索パラメータ
                CustPrtPprWork _custPrtPprWork = custPrtPprWork as CustPrtPprWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
               
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "得意先電子元帳", "抽出開始"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "得意先電子元帳", "抽出開始", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //Search実行
                #region [売上データ検索]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 DEL
                //if (_custPrtPprWork.SearchType != (int)SearchType.Dep)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
                if ( CheckSelectSales( _custPrtPprWork ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD
                {
                    // -- DEL 2009/09/04 ----------------------->>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                    //_slipKeyDic = new Dictionary<string, string>();
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                    // -- DEL 2009/09/04 -----------------------<<<

                    //伝票検索区分が「入金のみ」以外の場合に検索

                    //売上データ検索
                    status = SearchRefProc(ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.SalTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //実行時エラー
                        throw new Exception("検索実行時エラー：Status=" + status.ToString());
                    }
                    // -- DEL 2009/10/05 --------------------------->>>
                    //処理件数がオーバーした場合に例外としない。処理件数のオーバーはＵＩ側で判断して、メッセージ表示する
                    //if (recordCount >= _custPrtPprWork.SearchCnt)
                    //{
                    //    //処理件数オーバー
                    //    throw new Exception("処理件数オーバー");
                    //}
                    // -- DEL 2009/10/05 ---------------------------<<<

                    // -- DEL 2009/09/04 --------------------->>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                    //// 売上履歴データ検索(追加)
                    //iRecCnt = recordCount;
                    //status = SearchRefProc( ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.SalHisTbl, readMode, logicalMode, ref sqlConnection );
                    //if ( (status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    //    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) )
                    //{
                    //    //実行時エラー
                    //    throw new Exception( "検索実行時エラー：Status=" + status.ToString() );
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                    // -- DEL 2009/09/04 ---------------------<<<
                }
                #endregion

                #region [入金データ検索]
                // -- UPD 2009/10/05 ------------------------------------->>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 DEL
                ////if (_custPrtPprWork.SearchType != (int)SearchType.Sal)
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
                //if ( CheckSelectDeposit( _custPrtPprWork ) )
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD
                // 抽出件数がオーバーしていない場合のみ入金データを検索する
                //if (CheckSelectDeposit(_custPrtPprWork) && (recordCount < _custPrtPprWork.SearchCnt-1)) // DEL 2015/03/03 王亜楠 Redmine#44701 #36
                //----- ADD 2015/03/03 王亜楠 Redmine#44701 #36 -------------------->>>>>
                if (( CheckSelectDeposit(_custPrtPprWork) && _custPrtPprWork.SearchCountCtrl == 1) ||
                    (CheckSelectDeposit(_custPrtPprWork) && _custPrtPprWork.SearchCountCtrl == 0 && recordCount < _custPrtPprWork.SearchCnt - 1))
                //----- ADD 2015/03/03 王亜楠 Redmine#44701 #36 --------------------<<<<<
                // -- UPD 2009/10/05 -------------------------------------<<<
                {
                    //伝票検索区分が「売上のみ」以外の場合に検索


                    //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 ----->>>>>
                    // 受注作成区分が「通常受注伝票」/「伝発UOE受注伝票」の場合、入金伝票が検索されない
                    if (_custPrtPprWork.AcptAnOdrMakeDiv != 2 && _custPrtPprWork.AcptAnOdrMakeDiv != 3)
                    {
                    //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 -----<<<<<
                    iRecCnt = recordCount;
                    //入金データ検索
                    status = SearchRefProc(ref custPrtPprSalTblRsltWorkArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.DepTbl, readMode, logicalMode, ref sqlConnection);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                        (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        //実行時エラー
                        throw new Exception("検索実行時エラー：Status=" + status.ToString());
                    }
                    }// ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応

                    // -- DEL 2009/10/05 ------------------------------->>>
                    //抽出件数がオーバーした場合に例外としない。処理件数のオーバーはＵＩ側で判断して、メッセージ表示する
                    //if (recordCount >= _custPrtPprWork.SearchCnt)
                    //{
                    //    //処理件数オーバー
                    //    throw new Exception("処理件数オーバー");
                    //}
                    // -- DEL 2009/10/05 -------------------------------<<<

                }
                #endregion

                #region [残高照会検索]
                iRecCnt = recordCount;
                //残高照会検索事前チェック
                if ((_custPrtPprWork.CustomerCode == 0) && (_custPrtPprWork.ClaimCode == 0))
                {
                    //得意先/請求先 -> 両方入力なしは取得しない
                }
                else
                {
                    #region [得意先/請求先チェック]
                    //得意先/請求先 に設定がある場合
                    if ((_custPrtPprWork.CustomerCode != 0) && (_custPrtPprWork.ClaimCode == 0))
                    {
                        //得意先だけ
                        //※得意先マスメンのReadメソッドから、該当得意先の請求先コードを取得し、
                        //　得意先コードと請求先コードをそれぞれ得意先請求金額マスタに入れて読み込む
                        #region [得意先検索]
                        CustomerDB customerDB = new CustomerDB();
                        CustomerWork[] customerWorkArray = new CustomerWork[1];  //得意先情報クラス配列
                        string enterpriseCode = null;                            //企業コード
                        int[] customerCodeArray = new Int32[1];                  //得意先コード配列
                        int[] statusArray = new Int32[1];                        //ステータス配列

                        //パラメータセット
                        enterpriseCode = _custPrtPprWork.EnterpriseCode;         //企業コード
                        customerCodeArray[0] = _custPrtPprWork.CustomerCode;     //得意先コード

                        //得意先検索実行
                        status = customerDB.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //STATUS=0 -> 請求先コードセット
                            _custPrtPprWork.ClaimCode = customerWorkArray[0].ClaimCode;
                        }
                        else
                        {
                            //実行時エラー
                            throw new Exception("得意先マスタRead失敗:Status=" + status.ToString());
                        }
                        #endregion  //[[得意先検索]
                    }
                    else if ((_custPrtPprWork.CustomerCode == 0) && (_custPrtPprWork.ClaimCode != 0))
                    {
                        //請求先だけ
                        //※請求先コードを得意先請求金額マスタの得意先コードと請求先コードに入れて読み込む
                        _custPrtPprWork.CustomerCode = _custPrtPprWork.ClaimCode;
                    }
                    #endregion  //[得意先/請求先チェック]

                    #region [締日チェック]
                    TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
                    List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                    TtlDayCalcParaWork para = new TtlDayCalcParaWork();
                    para.EnterpriseCode = _custPrtPprWork.EnterpriseCode;  //企業コード
                    para.CustomerCode = _custPrtPprWork.CustomerCode;      //得意先コード
                    status = ttlDayCalcDB.SearchPrcDmdC(out retList, para, ref sqlConnection);
                    #endregion  //[締日チェック]

                    #region [残高照会検索]
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //STATUS=0 -> 残高照会検索実行
                        //計上年月日取得
                        _custPrtPprWork.AddUpYearMonth = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", null);
                        //残高照会検索実行
                        status = SearchRefProc(ref custPrtPprBlDspRsltArray, _custPrtPprWork, out recordCount, iRecCnt, (int)iSrcType.BlDsp, readMode, logicalMode, ref sqlConnection);
                        if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                            (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                        {
                            //実行時エラー
                            throw new Exception("検索実行時エラー：Status=" + status.ToString());
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        //締め情報なし -> STATUS=0でUIに返す
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //実行時エラー
                        throw new Exception("締日情報取得失敗:Status=" + status.ToString());
                    }
                    #endregion  //[残高照会検索]
                }
                #endregion

                // --- ADD 2011/03/22----------------------------------->>>>>
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "得意先電子元帳", "抽出終了"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprWork.EnterpriseCode, "得意先電子元帳", "抽出終了", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //実行結果セット
                custPrtPprBlDspRsltWork = custPrtPprBlDspRsltArray;
                custPrtPprSalTblRsltWork = custPrtPprSalTblRsltWorkArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/13 ADD
        /// <summary>
        /// 売上データ抽出チェック処理
        /// </summary>
        /// <param name="paramWork"></param>
        /// <returns></returns>
        private bool CheckSelectSales( CustPrtPprWork paramWork )
        {
            // 検索区分
            if ( paramWork.SearchType == (int)SearchType.Dep ) return false;


            // 上記以外は抽出する
            return true;
        }

        /// <summary>
        /// 入金データ抽出チェック処理
        /// </summary>
        /// <param name="paramWork"></param>
        /// <returns></returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号(VINコード)による抽出を可能にする</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/25</br>
        private bool CheckSelectDeposit(CustPrtPprWork paramWork)
        {
            // 検索区分
            if ( paramWork.SearchType == (int)SearchType.Sal ) return false;

            ////受注ステータス
            //if ( paramWork.AcptAnOdrStatus != null ) return false;
            ////売上伝票区分
            //if ( paramWork.SalesSlipCd != null ) return false;
            //売上伝票番号
            if ( paramWork.SalesSlipNum != "" ) return false;
            //受注者(受付従業員コード)
            if ( paramWork.FrontEmployeeCd != "" ) return false;
            //得意先注番(相手先伝票番号)
            if ( paramWork.PartySaleSlipNum != "" ) return false;
            //備考２(伝票備考２) ※あいまい検索あり
            if ( paramWork.SlipNote2 != "" ) return false;
            //備考３(伝票備考３) ※あいまい検索あり
            if ( paramWork.SlipNote3 != "" ) return false;
            //ＵＯＥリマーク１ ※あいまい検索あり
            if ( paramWork.UoeRemark1 != "" ) return false;
            //ＵＯＥリマーク２ ※あいまい検索あり
            if ( paramWork.UoeRemark2 != "" ) return false;


            //管理番号(車輌管理コード)
            if ( paramWork.CarMngCode != "" ) return false;
            //車種名称(車種全角名称) ※あいまい検索あり
            if ( paramWork.ModelFullName != "" ) return false;
            //型式(型式(フル型)) ※あいまい検索あり
            if ( paramWork.FullModel != "" ) return false;
            //車台№(車台番号(検索用))
            if ( paramWork.SearchFrameNo != 0 ) return false;
            // --- ADD 2013/03/25 ---------->>>>>
            //車台№(車台番号)
            if (paramWork.FrameNo != "") return false;
            // --- ADD 2013/03/25 ----------<<<<<
            //カラー名称(カラー名称1) ※あいまい検索あり
            if ( paramWork.ColorName1 != "" ) return false;
            //トリム名称 ※あいまい検索あり
            if ( paramWork.TrimName != "" ) return false;
            //UOE送信(データ送信区分)
            if ( paramWork.DataSendCode != 0 ) return false;
            //ＢＬグループ(BLグループコード)
            if ( paramWork.BLGroupCode != 0 ) return false;
            //ＢＬコード(BL商品コード)
            if ( paramWork.BLGoodsCode != 0 ) return false;
            //品名(商品名称) ※あいまい検索あり
            if ( paramWork.GoodsName != "" ) return false;
            //品番(商品番号) ※あいまい検索あり
            if ( paramWork.GoodsNo != "" ) return false;
            //メーカー(商品メーカーコード)
            if ( paramWork.GoodsMakerCd != 0 ) return false;
            //販売区分コード
            if ( paramWork.SalesCode != 0 ) return false;
            //自社分類コード
            if ( paramWork.EnterpriseGanreCode != 0 ) return false;
            //在庫取寄区分(売上在庫取寄せ区分)
            if ( paramWork.SalesOrderDivCd != -1 ) return false;
            //倉庫コード
            if ( paramWork.WarehouseCode != "" ) return false;
            //仕入伝票番号
            if ( paramWork.SupplierSlipNo != "" ) return false;
            //仕入先(仕入先コード)
            if ( paramWork.SupplierCd != 0 ) return false;
            //発注先
            if ( paramWork.UOESupplierCd != 0 ) return false;
            //明細備考 ※あいまい検索あり
            if ( paramWork.DtlNote != "" ) return false;
            //納品先コード
            if ( paramWork.AddresseeCode != 0 ) return false;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // 商品属性
            if ( paramWork.GoodsKindCode != -1 ) return false;
            // 商品大分類コード
            if ( paramWork.GoodsLGroup != 0 ) return false;
            // 商品中分類コード
            if ( paramWork.GoodsMGroup != 0 ) return false;
            // 棚番
            if ( paramWork.WarehouseShelfNo != string.Empty ) return false;
            // 売上伝票区分(明細)
            if ( paramWork.SalesSlipCdDtl != 0 ) return false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD


            // 上記以外は抽出する
            return true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/13 ADD

        #endregion  //[SearchRef]

        #region [SearchRefProc]
        /// <summary>
        /// 指定された検索条件に該当する伝票表示・明細表示データのリストを抽出します(売上データ)
        /// </summary>
        /// <param name="rsltWorkArray">検索結果(売上データ)</param>
        /// <param name="_custPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)戻り値用</param>
        /// <param name="iRecCnt">検索結果(件数)内部チェック用</param>
        /// <param name="iType">検索タイプ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchRefProc(ref ArrayList rsltWorkArray, CustPrtPprWork _custPrtPprWork, out Int64 recordCount, Int64 iRecCnt, int iType, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPpr custPrtPpr;

            // -- DEL 2009/09/04 ----------------------------->>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
            ////custPrtPpr = new CustPrtPprSalTblRsltQuery();
            ////if (iType == (int)iSrcType.BlDsp) custPrtPpr = new CustPrtPprBlDspRsltQuery();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
            //if ( iType != (int)iSrcType.BlDsp )
            //{
            //    // 売上・入金明細用
            //    custPrtPpr = new CustPrtPprSalTblRsltQuery();
            //    if ( iType == (int)iSrcType.SalTbl || iType == (int)iSrcType.SalHisTbl )
            //    {
            //        (custPrtPpr as CustPrtPprSalTblRsltQuery).SalesSlipHisKeyDic = _slipKeyDic;
            //    }
            //}
            //else
            //{
            //    // 残高照会用
            //    custPrtPpr = new CustPrtPprBlDspRsltQuery();
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
            // -- DEL 2009/09/04 -----------------------------<<<

            // -- ADD 2009/09/04 -------------------------->>>
            custPrtPpr = new CustPrtPprSalTblRsltQuery();
            if (iType == (int)iSrcType.BlDsp) custPrtPpr = new CustPrtPprBlDspRsltQuery();
            // -- ADD 2009/09/04 --------------------------<<<

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprWork, iType, logicalMode);

                //string txt = "declare @ENTERPRISECODE nchar(16) set @ENTERPRISECODE='0105130551011800' declare @ENTERPRISECODE2 nchar(16) set @ENTERPRISECODE2='0105130551011800' declare @FINDLOGICALDELETECODE int set @FINDLOGICALDELETECODE=0 declare @RESULTSADDUPSECCD nchar(6) set @RESULTSADDUPSECCD='01' declare @STSALESDATE int set @STSALESDATE=20090401 declare @EDSALESDATE int set @EDSALESDATE=20090430 ";


                //sqlCommand.CommandText = txt + "SELECT TOP 20002      SALSLP.SALESDATERF     ,SALSLP.SALESSLIPNUMRF     ,SALSLP.SALESROWNORF     ,SALSLP.ACPTANODRSTATUSRF     ,SALSLP.SALESSLIPCDRF     ,SALSLP.SALESEMPLOYEENMRF     ,SALSLP.SALESTOTALTAXEXCRF     ,SALSLP.SALESTOTALTAXINCRF     ,SALSLP.GOODSNAMERF     ,SALSLP.GOODSNORF     ,SALSLP.BLGOODSCODERF     ,SALSLP.BLGROUPCODERF     ,SALSLP.SHIPMENTCNTRF     ,SALSLP.LISTPRICETAXEXCFLRF     ,SALSLP.OPENPRICEDIVRF     ,SALSLP.SALESUNPRCTAXEXCFLRF     ,SALSLP.SALESUNITCOSTRF     ,SALSLP.SALESMONEYTAXEXCRF     ,SALSLP.CONSTAXLAYMETHODRF     ,SALSLP.SALESPRICECONSTAXRF     ,SALSLP.TOTALCOSTRF     ,AODCAR.MODELDESIGNATIONNORF     ,AODCAR.CATEGORYNORF     ,AODCAR.MODELFULLNAMERF     ,AODCAR.FIRSTENTRYDATERF     ,AODCAR.SEARCHFRAMENORF     ,AODCAR.FULLMODELRF     ,SALSLP.SLIPNOTERF     ,SALSLP.SLIPNOTE2RF     ,SALSLP.SLIPNOTE3RF     ,SALSLP.FRONTEMPLOYEENMRF     ,SALSLP.SALESINPUTNAMERF     ,SALSLP.CUSTOMERCODERF     ,SALSLP.CUSTOMERSNMRF     ,SALSLP.SUPPLIERCDRF     ,SALSLP.SUPPLIERSNMRF     ,SALSLP.PARTYSALESLIPNUMRF     ,AODCAR.CARMNGCODERF     ,SALSLP.ACCEPTANORDERNORF     ,SALSLP.SHIPMSALESSLIPNUM     ,SALSLP.SRCSALESSLIPNUM     ,SALSLP.SALESORDERDIVCDRF     ,SALSLP.WAREHOUSENAMERF     ,STCDTL.SUPPLIERSLIPNORF     ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD     ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM     ,SALSLP.UOEREMARK1RF     ,SALSLP.UOEREMARK2RF     ,USRGBU.GUIDENAMERF     ,SCINFS.SECTIONGUIDENMRF     ,SALSLP.DTLNOTERF     ,AODCAR.COLORNAME1RF     ,AODCAR.TRIMNAMERF     ,SALSLP.STDUNPRCLPRICERF     ,SALSLP.STDUNPRCSALUNPRCRF     ,SALSLP.STDUNPRCUNCSTRF     ,SALSLP.GOODSMAKERCDRF     ,SALSLP.MAKERNAMERF     ,SALSLP.COSTRF     ,SALSLP.CUSTSLIPNORF     ,SALSLP.ADDUPADATERF     ,SALSLP.ACCRECDIVCDRF     ,SALSLP.DEBITNOTEDIVRF     ,SALSLP.SECTIONCODERF     ,SALSLP.WAREHOUSECODERF     ,SALSLP.ACPTANODRREMAINCNTRF     ,SALSLP.TOTALAMOUNTDISPWAYCDRF     ,SALSLP.TAXATIONDIVCDRF     ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF     ,SALSLP.SHIPMENTDAYRF     ,SALSLP.ADDRESSEECODERF     ,SALSLP.ADDRESSEENAMERF     ,SALSLP.ADDRESSEENAME2RF     ,AODCAR.FRAMENORF     ,SALSLP.ENTERPRISEGANRECODERF     ,SALSLP.SEARCHSLIPDATERF     ,SALSLP.GOODSKINDCODERF     ,SALSLP.GOODSLGROUPRF     ,SALSLP.GOODSMGROUPRF     ,SALSLP.WAREHOUSESHELFNORF     ,SALSLP.SALESSLIPCDDTLRF     ,SALSLP.GOODSLGROUPNAMERF     ,SALSLP.GOODSMGROUPNAMERF     ,SALSLP.DELIVEREDGOODSDIVRF     ,AODCAR.CARMNGNORF     ,AODCAR.MAKERCODERF     ,AODCAR.MODELCODERF     ,AODCAR.MODELSUBCODERF     ,AODCAR.ENGINEMODELNMRF     ,AODCAR.COLORCODERF     ,AODCAR.TRIMCODERF     ,AODCAR.FULLMODELFIXEDNOARYRF     ,AODCAR.CATEGORYOBJARYRF     ,SALSLP.SALESINPUTCODERF     ,SALSLP.FRONTEMPLOYEECDRF     ,SALSLP.HISTORYDIVRF    FROM (     SELECT       SALSLPSUB.ENTERPRISECODERF      ,SALSLPSUB.SALESDATERF      ,SALSLPSUB.SALESSLIPNUMRF      ,SALSLPSUB.ACPTANODRSTATUSRF      ,SALSLPSUB.SALESSLIPCDRF      ,SALSLPSUB.SALESEMPLOYEENMRF      ,SALSLPSUB.SALESTOTALTAXEXCRF      ,SALSLPSUB.SALESTOTALTAXINCRF      ,SALSLPSUB.CONSTAXLAYMETHODRF      ,SALSLPSUB.TOTALCOSTRF      ,SALSLPSUB.SLIPNOTERF      ,SALSLPSUB.SLIPNOTE2RF      ,SALSLPSUB.SLIPNOTE3RF      ,SALSLPSUB.FRONTEMPLOYEENMRF      ,SALSLPSUB.SALESINPUTNAMERF      ,SALSLPSUB.CUSTOMERCODERF      ,SALSLPSUB.CUSTOMERSNMRF      ,SALSLPSUB.PARTYSALESLIPNUMRF      ,SALSLPSUB.UOEREMARK1RF      ,SALSLPSUB.UOEREMARK2RF      ,SALSLPSUB.CUSTSLIPNORF      ,SALSLPSUB.ADDUPADATERF      ,SALSLPSUB.ACCRECDIVCDRF      ,SALSLPSUB.DEBITNOTEDIVRF      ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF      ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF      ,SALSLPSUB.SHIPMENTDAYRF      ,SALSLPSUB.ADDRESSEECODERF      ,SALSLPSUB.ADDRESSEENAMERF      ,SALSLPSUB.ADDRESSEENAME2RF      ,SALSLPSUB.SEARCHSLIPDATERF      ,SALSLPSUB.DELIVEREDGOODSDIVRF      ,SALSLPSUB.SALESINPUTCODERF      ,SALSLPSUB.FRONTEMPLOYEECDRF      ,SALDTL.SALESROWNORF      ,SALDTL.GOODSNAMERF      ,SALDTL.GOODSNORF      ,SALDTL.BLGOODSCODERF      ,SALDTL.BLGROUPCODERF      ,SALDTL.SHIPMENTCNTRF      ,SALDTL.LISTPRICETAXEXCFLRF      ,SALDTL.OPENPRICEDIVRF      ,SALDTL.SALESUNPRCTAXEXCFLRF      ,SALDTL.SALESUNITCOSTRF      ,SALDTL.SALESMONEYTAXEXCRF      ,SALDTL.SALESPRICECONSTAXRF      ,SALDTL.SUPPLIERCDRF      ,SALDTL.SUPPLIERSNMRF      ,SALDTL2.ACCEPTANORDERNORF      ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM      ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM      ,SALDTL.SALESORDERDIVCDRF      ,SALDTL.WAREHOUSENAMERF      ,SALDTL.DTLNOTERF      ,SALDTL.STDUNPRCLPRICERF      ,SALDTL.STDUNPRCSALUNPRCRF      ,SALDTL.STDUNPRCUNCSTRF      ,SALDTL.GOODSMAKERCDRF      ,SALDTL.MAKERNAMERF      ,SALDTL.COSTRF      ,SALDTL.WAREHOUSECODERF      ,SALDTL3.ACPTANODRREMAINCNTRF      ,SALDTL.TAXATIONDIVCDRF      ,SALDTL.ENTERPRISEGANRECODERF      ,SALDTL.GOODSKINDCODERF      ,SALDTL.GOODSLGROUPRF      ,SALDTL.GOODSMGROUPRF      ,SALDTL.WAREHOUSESHELFNORF      ,SALDTL.SALESSLIPCDDTLRF      ,SALDTL.GOODSLGROUPNAMERF      ,SALDTL.GOODSMGROUPNAMERF      ,SALDTL.COMMONSEQNORF      ,SALDTL.SUPPLIERFORMALSYNCRF      ,SALDTL.STOCKSLIPDTLNUMSYNCRF      ,SALDTL.SALESCODERF      ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1      ,(CASE WHEN SALDTL3.ACPTANODRREMAINCNTRF IS NULL THEN 1 ELSE 0 END) AS HISTORYDIVRF     FROM SALESHISTORYRF AS SALSLPSUB     LEFT JOIN SALESHISTDTLRF SALDTL    ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF    AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF    AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF    LEFT JOIN SALESHISTDTLRF SALDTL2    ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF    AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF    AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF    LEFT JOIN SALESDETAILRF SALDTL3    ON  SALDTL3.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF    AND SALDTL3.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF    AND SALDTL3.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF   WHERE   SALSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE   AND SALSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE   AND SALSLPSUB.RESULTSADDUPSECCDRF=@RESULTSADDUPSECCD    AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))   AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))   AND SALSLPSUB.ACPTANODRSTATUSRF IN (30)    AND SALSLPSUB.SALESSLIPCDRF IN (0,1)     ) AS SALSLP    LEFT JOIN ACCEPTODRCARRF AODCAR    ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1    AND (           (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1)         OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)        OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)        OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)      )    LEFT JOIN UOEORDERDTLRF UOEODR    ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF    LEFT JOIN SECINFOSETRF SCINFS    ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF    LEFT JOIN STOCKDETAILRF STCDTL    ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF    AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF    LEFT JOIN STOCKSLIPRF STCSLP    ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF    AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF    AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF    LEFT JOIN BLGROUPURF BLGRPU    ON  BLGRPU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND BLGRPU.BLGROUPCODERF=SALSLP.BLGROUPCODERF    LEFT JOIN USERGDBDURF USRGBU    ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF    AND USRGBU.USERGUIDEDIVCDRF=71    AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF   WHERE   SALSLP.ENTERPRISECODERF=@ENTERPRISECODE2  ";

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                sqlCommand.CommandTimeout = 3600;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD

                myReader = sqlCommand.ExecuteReader();

                //件数チェック用フラグ
                bool bCuntChkFlg = false;
                if (iType == (int)iSrcType.BlDsp) bCuntChkFlg = true;
                //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
                // 抽出件数制限なしの場合
                if (_custPrtPprWork.SearchCountCtrl == 1) bCuntChkFlg = true;
                //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

                while (myReader.Read())
                {
                    #region 件数チェック
                    // -- UPD 2009/10/05 ---------------------------->>>
                    //if (bCuntChkFlg != true)
                    //{
                    //    bCuntChkFlg = true;  //フラグON
                    //    //該当データ件数取得
                    //    iRecCnt = iRecCnt + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ROWNUM"));
                    //    //件数チェック
                    //    if (iRecCnt >= _custPrtPprWork.SearchCnt)
                    //    {
                    //        //検索上限オーバーの場合はBreak
                    //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //        break;
                    //    }
                    //}
                    // -- UPD 2009/10/05 ----------------------------<<<
                    #endregion

                    //取得結果セット
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                    //rsltWorkArray.Add( custPrtPpr.CopyToResultWorkFromReader( ref myReader, _custPrtPprWork, iType ) );
                    //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD

                    object retWork = custPrtPpr.CopyToResultWorkFromReader( ref myReader, _custPrtPprWork, iType );
                    if ( retWork != null )
                    {
                        rsltWorkArray.Add( retWork );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        // -- ADD 2009/10/05 ---------------------------->>>
                        if (bCuntChkFlg != true)
                        {
                            iRecCnt++;
                            if (iRecCnt >= _custPrtPprWork.SearchCnt)
                            {
                                //検索上限オーバーの場合はBreak
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                recordCount = iRecCnt;
                                break;
                            }
                        }
                        // -- ADD 2009/10/05 ----------------------------<<<
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchRefProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                // -- UPD 2009/10/05 -------------------->>>
                //if (!myReader.IsClosed) myReader.Close();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
                // -- UPD 2009/10/05 --------------------<<<
                
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
        /// <param name="custPrtPprBlTblRsltWork">検索結果</param>
        /// <param name="custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫未出荷一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2011/04/06 曹文傑</br>
        /// <br>             操作履歴表示で、機能＝「得意先電子元帳」を選択して「表示更新」を実行した時の絞り込みを有効にする為。</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int SearchBlTbl(ref object custPrtPprBlTblRsltWork, object custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            custPrtPprBlTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (custPrtPprBlnceWork == null) return status;

                #region [パラメータのキャスト]
                //残高一覧用 ArrayList
                ArrayList custPrtPprBlTblRsltArray = custPrtPprBlTblRsltWork as ArrayList;
                if (custPrtPprBlTblRsltArray == null)
                {
                    custPrtPprBlTblRsltArray = new ArrayList();
                }
                //検索パラメータ
                CustPrtPprBlnceWork _custPrtPprBlnceWork = custPrtPprBlnceWork as CustPrtPprBlnceWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出開始"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出開始", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<

                //SearchBlTbl実行
                status = SearchBlTblProc(ref custPrtPprBlTblRsltArray, _custPrtPprBlnceWork, SrchKndDiv, readMode, logicalMode, ref sqlConnection);

                // --- ADD 2011/03/22----------------------------------->>>>>
                //oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出終了"); // DEL 2011/04/06
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出終了", "PMKAU04000U", 0); // ADD 2011/04/06
                // --- ADD 2011/03/22-----------------------------------<<<<<
                //実行結果セット
                custPrtPprBlTblRsltWork = custPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchProc Exception=" + ex.Message);
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
        /// <param name="_custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753得意先電子元帳に残高一覧の消費税不正になる件の対応</br>
        /// <br>Update Note: 2013/11/11 gezh</br>
        /// <br>             Redmine#41206の№26 得意先電子元帳に対象年月(開始)に売上月次更新が未処理の月を指定した場合、残高一覧が表示されないの対応</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private int SearchBlTblProc(ref ArrayList rsltWorkArray, CustPrtPprBlnceWork _custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
            //ICustPrtPpr custPrtPpr;
            ICustPrtPprOutput custPrtPpr;
            // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
            custPrtPpr = new CustPrtPprBlTblRsltQuery();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            List<Int32> monthList = new List<Int32>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
                //sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, logicalMode);
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, false, logicalMode);
                // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                    ////取得結果セット
                    //rsltWorkArray.Add(custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv));
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                    //取得結果セット
                    // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
                    //CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv);
                    CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv, false);
                    // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
                    rsltWorkArray.Add(retWork);

                    //取得月一覧追加
                    monthList.Add( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( retWork.AddUpYearMonth ) );
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
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                // -- UPD 2009/10/05 -------------------->>>
                //if (!myReader.IsClosed) myReader.Close();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
                // -- UPD 2009/10/05 --------------------<<<

            }


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            if ( SrchKndDiv == (int)iSrchKndDiv.CustAcc )
            {
                FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator( _custPrtPprBlnceWork.EnterpriseCode, ref sqlConnection );
                if ( finYearTableGenerator != null )
                {
                    # region [月次未締範囲]
                    // 前回月次締処理日取得
                    DateTime prevTotalDay = CheckPrcMonthlyAccRec( _custPrtPprBlnceWork, ref sqlConnection );

                    // 指定月範囲
                    int monthCount = GetMonthsCount( _custPrtPprBlnceWork.Ed_AddUpYearMonth, _custPrtPprBlnceWork.St_AddUpYearMonth );
                    for ( int monthIndex = 0; monthIndex < monthCount; monthIndex++ )
                    {
                        DateTime targetMonth = _custPrtPprBlnceWork.St_AddUpYearMonth.AddMonths( monthIndex );

                        // 取得できなかった月に対しての処理
                        if ( !monthList.Contains( (Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM( targetMonth ) ) &&
                              (prevTotalDay < targetMonth) )
                        {
                            //---------------------------------------------------
                            // 自社締め月範囲
                            //---------------------------------------------------
                            # region [自社締め月範囲]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth( targetMonth, out stDate, out edDate );
                            # endregion

                            //---------------------------------------------------
                            // 条件パラメータセット
                            //---------------------------------------------------
                            # region [条件パラメータセット]
                            CustAccRecWork paraWork = new CustAccRecWork();
                            paraWork.EnterpriseCode = _custPrtPprBlnceWork.EnterpriseCode;                //企業コード
                            //paraWork.LaMonCAddUpUpdDate = stDate.AddDays( -1 );     // DEL 2013/10/24 gezh for Redmine#39753
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>> 
                            if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                            {
                                paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                            }
                            else
                            {
                                paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                            }
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                            paraWork.AddUpDate = edDate;
                            paraWork.AddUpYearMonth = targetMonth;                //計上年月
                            paraWork.AddUpSecCode = _custPrtPprBlnceWork.SectionCode[0];  //計上拠点コード ※得意先マスタリストから
                            paraWork.CustomerCode = _custPrtPprBlnceWork.CustomerCode;     //得意先コード   ※得意先マスタリストから
                            if ( paraWork.CustomerCode == 0 )
                            {
                                paraWork.CustomerCode = _custPrtPprBlnceWork.ClaimCode;
                            }

                            # endregion

                            //---------------------------------------------------
                            // 売掛金・買掛金算出モジュール呼び出し
                            //---------------------------------------------------
                            # region [売掛金・買掛金算出モジュール呼び出し]
                            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                            object paraObj = paraWork;
                            string retMsg;
                            int accStatus = monthlyAddUpDB.ReadCustAccRec( ref paraObj, out retMsg, ref sqlConnection );

                            if ( accStatus == 0 )
                            {
                                CustPrtPprBlTblRsltWork rsltWork = new CustPrtPprBlTblRsltWork();

                                // 結果セット
                                # region [結果セット]
                                CustAccRecWork retWork = (CustAccRecWork)paraObj;
                                rsltWork.AddUpDate = retWork.AddUpDate;
                                rsltWork.LastTimeBlc = retWork.LastTimeAccRec;
                                rsltWork.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml;
                                rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcc;
                                rsltWork.ThisTimeSales = retWork.ThisTimeSales;
                                rsltWork.SalesPricRgdsDis = retWork.ThisSalesPricRgds + retWork.ThisSalesPricDis;
                                rsltWork.OfsThisTimeSales = retWork.OfsThisTimeSales;
                                rsltWork.OfsThisSalesTax = retWork.OfsThisSalesTax;
                                rsltWork.ThisSalesPricTotal = retWork.OfsThisTimeSales + retWork.OfsThisSalesTax;
                                rsltWork.AfCalBlc = retWork.AfCalTMonthAccRec;
                                rsltWork.SalesSlipCount = retWork.SalesSlipCount;
                                # endregion

                                // 前月残高の反映
                                # region [前月残高の反映]
                                int prevIndex = rsltWorkArray.Count - 1;
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                //rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // 前月残高
                                //// 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                //rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// 今回繰越残高(売掛)
                                //// 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                //rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// 計算後請求金額
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                if (prevIndex >= 0)
                                {
                                    rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // 前月残高
                                    // 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                    rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// 今回繰越残高(売掛)
                                    // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                    rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// 計算後請求金額
                                }
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                # endregion

                                rsltWorkArray.Add( rsltWork );

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            # endregion
                        }
                    }
                    # endregion
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD

            return status;
        }
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
        private DateTime CheckPrcMonthlyAccRec( CustPrtPprBlnceWork custPrtPprBlnceWork, ref SqlConnection sqlConnection )
        {
            // 締済チェック
            TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();

            TtlDayCalcParaWork paraWork = new TtlDayCalcParaWork();
            paraWork.EnterpriseCode = custPrtPprBlnceWork.EnterpriseCode;
            paraWork.SectionCode = custPrtPprBlnceWork.SectionCode[0];
            paraWork.CustomerCode = custPrtPprBlnceWork.CustomerCode;
            if ( paraWork.CustomerCode == 0 )
            {
                paraWork.CustomerCode = custPrtPprBlnceWork.ClaimCode;
            }
            List<TtlDayCalcRetWork> retList;

            int status = ttlDayCalcDB.SearchHisMonthlyAccRec( out retList, paraWork, ref sqlConnection );
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

        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        #region [SearchBlTblOutput]
        /// <summary>
        /// 指定された検索条件に該当する残高一覧表示（与信残高出力用）のリストを抽出します
        /// </summary>
        /// <param name="custPrtPprBlTblRsltWork">検索結果</param>
        /// <param name="custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された検索条件に該当する残高一覧表示（与信残高出力用）LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30744 湯上 千加子</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br></br>
        public int SearchBlTblOutput(ref object custPrtPprBlTblRsltWork, object custPrtPprBlnceWork, int SrchKndDiv, int readMode, ConstantManagement.LogicalMode logicalMode, bool CreditMng)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            custPrtPprBlTblRsltWork = null;

            try
            {
                //パラメータチェック
                if (custPrtPprBlnceWork == null) return status;

                #region [パラメータのキャスト]
                //残高一覧用 ArrayList
                ArrayList custPrtPprBlTblRsltArray = custPrtPprBlTblRsltWork as ArrayList;
                if (custPrtPprBlTblRsltArray == null)
                {
                    custPrtPprBlTblRsltArray = new ArrayList();
                }
                //検索パラメータ
                CustPrtPprBlnceWork _custPrtPprBlnceWork = custPrtPprBlnceWork as CustPrtPprBlnceWork;
                #endregion  //[パラメータのキャスト]

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出開始", "PMKAU04000U", 0); 

                //SearchBlTbl実行
                status = SearchBlTblOutputProc(ref custPrtPprBlTblRsltArray, _custPrtPprBlnceWork, SrchKndDiv, CreditMng, readMode, logicalMode, ref sqlConnection);

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _custPrtPprBlnceWork.EnterpriseCode, "得意先電子元帳", "抽出終了", "PMKAU04000U", 0); 
                //実行結果セット
                custPrtPprBlTblRsltWork = custPrtPprBlTblRsltArray;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblOutput Exception=" + ex.Message);
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
        #endregion  //[SearchBlTblOutput]

        #region [SearchBlTblOutputProc]
        /// <summary>
        /// 指定された検索条件に該当する残高一覧表示（与信残高出力用）のリストを抽出します
        /// </summary>
        /// <param name="rsltWorkArray">検索結果</param>
        /// <param name="_custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30744 湯上 千加子</br>
        /// <br>Date       : 2013/03/13</br>
        /// <br>Update Note: 10800003-00　2013/05/15配信分 Redmine#35205得意先電子元帳の対応</br>
        /// <br>             ①与信残高出力件数不正の修正</br>
        /// <br>             ②与信残高出力場合、抽出データは前月データだけ場合、前月のデータを削除</br>
        /// <br>Programmer : xuyb</br>
        /// <br>Date       : 2013/03/29</br>
        /// <br>Update Note: 2013/10/24 gezh</br>
        /// <br>             Redmine#39753得意先電子元帳に残高一覧の消費税不正になる件の対応</br>
        /// <br>Update Note: 2013/11/11 gezh</br>
        /// <br>             Redmine#41206の№26 得意先電子元帳に対象年月(開始)に売上月次更新が未処理の月を指定した場合、残高一覧が表示されないの対応</br>
        /// <br></br>
        private int SearchBlTblOutputProc(ref ArrayList rsltWorkArray, CustPrtPprBlnceWork _custPrtPprBlnceWork, int SrchKndDiv, bool CreditMng, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPprOutput custPrtPpr;
            custPrtPpr = new CustPrtPprBlTblRsltQuery();
            List<Int32> monthList = new List<Int32>();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, _custPrtPprBlnceWork, SrchKndDiv, CreditMng, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    //取得結果セット
                    CustPrtPprBlTblRsltWork retWork = (CustPrtPprBlTblRsltWork)custPrtPpr.CopyToResultWorkFromReader(ref myReader, _custPrtPprBlnceWork, SrchKndDiv, CreditMng);
                    rsltWorkArray.Add(retWork);

                    //取得月一覧追加
                    monthList.Add((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(retWork.AddUpYearMonth));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // ADD 2013/03/29 xuyb Redmine#35205②与信残高出力場合、抽出データは前月データだけ場合、前月のデータを削除
                if (CreditMng && monthList.Count == 1 && monthList[0].ToString().Equals(_custPrtPprBlnceWork.St_AddUpYearMonth.ToString("yyyyMM")))
                {
                    rsltWorkArray.RemoveAt(0);
                }
                // ADD 2013/03/29 xuyb Redmine#35205②与信残高出力場合、抽出データは前月データだけ場合、前月のデータを削除
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchBlTblProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
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

            if (SrchKndDiv == (int)iSrchKndDiv.CustAcc)
            {
                FinYearTableGenerator finYearTableGenerator = this.GetFinYearTableGenerator(_custPrtPprBlnceWork.EnterpriseCode, ref sqlConnection);
                if (finYearTableGenerator != null)
                {
                    # region [月次未締範囲]
                    // 前回月次締処理日取得
                    DateTime prevTotalDay = CheckPrcMonthlyAccRec(_custPrtPprBlnceWork, ref sqlConnection);
                    // 指定月範囲
                    int monthCount = GetMonthsCount(_custPrtPprBlnceWork.Ed_AddUpYearMonth, _custPrtPprBlnceWork.St_AddUpYearMonth);
                    for (int monthIndex = 0; monthIndex < monthCount; monthIndex++)
                    {
                        DateTime targetMonth = _custPrtPprBlnceWork.St_AddUpYearMonth.AddMonths(monthIndex);

                        // 取得できなかった月に対しての処理
                        if (!monthList.Contains((Int32)SqlDataMediator.SqlSetDateTimeFromYYYYMM(targetMonth)) &&
                              (prevTotalDay < targetMonth))
                        {
                            //---------------------------------------------------
                            // 自社締め月範囲
                            //---------------------------------------------------
                            # region [自社締め月範囲]
                            DateTime stDate;
                            DateTime edDate;
                            finYearTableGenerator.GetDaysFromMonth(targetMonth, out stDate, out edDate);
                            # endregion

                            //---------------------------------------------------
                            // 条件パラメータセット
                            //---------------------------------------------------
                            # region [条件パラメータセット]
                            CustAccRecWork paraWork = new CustAccRecWork();
                            paraWork.EnterpriseCode = _custPrtPprBlnceWork.EnterpriseCode;                //企業コード
                            //paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);     // DEL 2013/10/24 gezh for Redmine#39753
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------>>>>> 
                            if (TDateTime.DateTimeToString("YYYYMM", prevTotalDay) == TDateTime.DateTimeToString("YYYYMM", targetMonth.AddMonths(-1)))
                            {
                                paraWork.LaMonCAddUpUpdDate = DateTime.MinValue;
                            }
                            else
                            {
                                paraWork.LaMonCAddUpUpdDate = stDate.AddDays(-1);
                            }
                            // ------ ADD 2013/10/24 gezh for Redmine#39753 ------------------------------<<<<<
                            paraWork.AddUpDate = edDate;
                            paraWork.AddUpYearMonth = targetMonth;                //計上年月
                            paraWork.AddUpSecCode = _custPrtPprBlnceWork.SectionCode[0];  //計上拠点コード ※得意先マスタリストから
                            paraWork.CustomerCode = _custPrtPprBlnceWork.CustomerCode;     //得意先コード   ※得意先マスタリストから
                            if (paraWork.CustomerCode == 0)
                            {
                                paraWork.CustomerCode = _custPrtPprBlnceWork.ClaimCode;
                            }

                            # endregion

                            //---------------------------------------------------
                            // 売掛金・買掛金算出モジュール呼び出し
                            //---------------------------------------------------
                            # region [売掛金・買掛金算出モジュール呼び出し]
                            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
                            object paraObj = paraWork;
                            string retMsg;
                            int accStatus = monthlyAddUpDB.ReadCustAccRec(ref paraObj, out retMsg, ref sqlConnection);

                            if (accStatus == 0)
                            {
                                CustPrtPprBlTblRsltWork rsltWork = new CustPrtPprBlTblRsltWork();

                                // 結果セット
                                # region [結果セット]
                                CustAccRecWork retWork = (CustAccRecWork)paraObj;
                                rsltWork.AddUpDate = retWork.AddUpDate;
                                rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;  // ADD 2013/03/29 xuyb Redmine#35205①
                                rsltWork.LastTimeBlc = retWork.LastTimeAccRec;
                                rsltWork.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml;
                                rsltWork.ThisTimeTtlBlc = retWork.ThisTimeTtlBlcAcc;
                                rsltWork.ThisTimeSales = retWork.ThisTimeSales;
                                rsltWork.SalesPricRgdsDis = retWork.ThisSalesPricRgds + retWork.ThisSalesPricDis;
                                rsltWork.OfsThisTimeSales = retWork.OfsThisTimeSales;
                                rsltWork.OfsThisSalesTax = retWork.OfsThisSalesTax;
                                rsltWork.ThisSalesPricTotal = retWork.OfsThisTimeSales + retWork.OfsThisSalesTax;
                                rsltWork.AfCalBlc = retWork.AfCalTMonthAccRec;
                                rsltWork.SalesSlipCount = retWork.SalesSlipCount;
                                # endregion

                                // 前月残高の反映
                                # region [前月残高の反映]
                                int prevIndex = rsltWorkArray.Count - 1;
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                //rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // 前月残高
                                //// 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                //rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// 今回繰越残高(売掛)
                                //// 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                //rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// 計算後請求金額
                                //// 自社締日
                                //rsltWork.CompanyTotalDay = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).CompanyTotalDay; // 自社締日
                                // ------ DEL 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------>>>>>
                                if (prevIndex >= 0)
                                {
                                    rsltWork.LastTimeBlc = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).AfCalBlc; // 前月残高
                                    // 今回繰越残高(売掛) = 前回請求残高 - 今回入金金額 
                                    rsltWork.ThisTimeTtlBlc = (rsltWork.LastTimeBlc) - rsltWork.ThisTimeDmdNrml;// 今回繰越残高(売掛)
                                    // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                                    rsltWork.AfCalBlc = rsltWork.ThisTimeTtlBlc + (rsltWork.OfsThisTimeSales + rsltWork.OfsThisSalesTax);// 計算後請求金額
                                    // 自社締日
                                    rsltWork.CompanyTotalDay = ((CustPrtPprBlTblRsltWork)rsltWorkArray[prevIndex]).CompanyTotalDay; // 自社締日
                                }
                                // ------ ADD 2013/11/11 gezh for Redmine#41206 ------------------------------<<<<<
                                # endregion

                                rsltWork.CreditMngCode = 2;// 与信区分 // ADD 2013/04/12 zhujw Redmine#35205

                                rsltWorkArray.Add(rsltWork);

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            # endregion
                        }
                    }
                    # endregion
                }
            }

            return status;
        }
        #endregion  //[SearchBlTblOutputProc]
        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        #endregion  //[残高一覧検索]

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        # region [履歴分の赤伝対応]

        # region [売上伝票読み込み（履歴含む）]
        /// <summary>
        /// 売上伝票読み込み（履歴含む）
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="readMode"></param>
        /// <returns></returns>
        public int ReadSalesSlip( ref object paramlist, out object retsliplist, out object retrelationsliplist, int readMode )
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = null;
            retrelationsliplist = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            if ( SlipListUtils.IsEmpty( paramlist as ArrayList ) )
            {
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                errmsg += ": 読み込み情報リストが未登録です。";
                base.WriteErrorLog( errmsg, status );
            }
            else
            {
                try
                {
                    ArrayList list = paramlist as ArrayList;

                    ArrayList retslips = null;
                    ArrayList retrelationslips = null;

                    status = this.ReadProc( ref list, out retslips, out retrelationslips, ref connection, ref encryptinfo, true, readMode );

                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        retsliplist = new CustomSerializeArrayList();
                        (retsliplist as CustomSerializeArrayList).AddRange( retslips );

                        retrelationsliplist = new CustomSerializeArrayList();
                        (retrelationsliplist as CustomSerializeArrayList).AddRange( retrelationslips );
                    }
                }
                catch ( Exception ex )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    base.WriteErrorLog( ex, errmsg, status );
                }
                finally
                {
                    # region [暗号化キーのクローズ(保留)]
                    // 暗号化キーのクローズ
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}
                    # endregion

                    // コネクションの破棄
                    if ( connection != null )
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="connection"></param>
        /// <param name="encryptinfo"></param>
        /// <param name="readrelation"></param>
        /// <returns></returns>
        private int ReadProc( ref ArrayList paramlist, out ArrayList retsliplist, out ArrayList retrelationsliplist, ref SqlConnection connection, ref SqlEncryptInfo encryptinfo, bool readrelation, int readMode )
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = new ArrayList();
            retrelationsliplist = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [パラメーターチェック]

                //●読込情報リストチェック
                if ( SlipListUtils.IsEmpty( paramlist ) )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": 読込情報リストが未登録です。";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                //●売上・仕入制御オプションチェック
                this.CtrlOptWork = SlipListUtils.Find( paramlist, typeof( IOWriteCtrlOptWork ), SlipListUtils.FindType.Class ) as IOWriteCtrlOptWork;

                if ( this.CtrlOptWork == null )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": 売上・仕入制御オプションが見つかりません。";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                //●コネクションチェック
                if ( connection == null )
                {
                    connection = this.CreateSqlConnection( true );
                }

                if ( connection == null )
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": データベースへ接続出来ません。";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }

                // 読み込みパラメータ生成
                MakeReadFunctionParam( ref paramlist );



                # region 暗号化処理 保留
                //●暗号化キーチェック　(保留)
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // 暗号化対象の売上データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // 暗号化対象の仕入データ系テーブルリストを取得
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // テーブルリストの結合
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーを作成出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": 暗号化キーをオープン出来ません。";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}
                # endregion

                //●制御起点に応じて読込オブジェクトをリストより取得する
                IOWriteMAHNBReadWork salesReadWork = null;
                IOWriteMASIRReadWork stockReadWork = null;

                if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales )
                {
                    salesReadWork = SlipListUtils.Find( paramlist, typeof( IOWriteMAHNBReadWork ), SlipListUtils.FindType.Class ) as IOWriteMAHNBReadWork;

                    if ( salesReadWork == null )
                    {
                        string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                        errmsg += ": 売上データ読込オブジェクトが登録されていません。";
                        base.WriteErrorLog( errmsg, status );
                        return status;
                    }
                }
                else if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase )
                {

                    stockReadWork = SlipListUtils.Find( paramlist, typeof( IOWriteMASIRReadWork ), SlipListUtils.FindType.Class ) as IOWriteMASIRReadWork;

                    if ( stockReadWork == null )
                    {
                        string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                        errmsg += ": 仕入データ読込オブジェクトが登録されていません。";
                        base.WriteErrorLog( errmsg, status );
                        return status;
                    }
                }
                else
                {
                    string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                    errmsg += ": 売上・仕入制御オプションの制御起点に誤りがあります。";
                    base.WriteErrorLog( errmsg, status );
                    return status;
                }
                # endregion

                # region [指定伝票データの読込]
                CustomSerializeArrayList readparam = new CustomSerializeArrayList();
                readparam.AddRange( paramlist );

                //CustomSerializeArrayList readresult = null;
                CustomSerializeArrayList readresult = new CustomSerializeArrayList();

                int pos = MakePosition( readparam, typeof( SalesSlipReadWork ), 0 );

                //●読込対象の伝票データを取得する
                if ( this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales )
                {
                    ArrayList detailList = null;
                    SqlTransaction transaction = null;

                    // UIから指定されたreadModeにより売上データor売上履歴データを決定する。
                    if ( readMode == 0 )
                    {
                        //---------------------------------------------
                        // 売上
                        //---------------------------------------------

                        # region [売上]
                        // 売上伝票データを読み込む
                        _salesSlipDB = new SalesSlipDB();
                        object freeParam = null;//売上伝票Readでは自由パラメータは利用しない
                        status = _salesSlipDB.Read( "CustPrtPprWorkDB", ref readparam, ref readresult, MakePosition( readparam, typeof( SalesSlipReadWork ), 0 ), "", ref freeParam, ref connection );

                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            foreach ( object obj in readresult )
                            {
                                // --- UPD 2014/07/04 y.wakita ----->>>>>
                                //if (obj is ArrayList && (obj as ArrayList).Count > 0 && ((obj as ArrayList)[0] is SalesDetailWork))
                                if (obj is ArrayList && (obj as ArrayList).Count > 0 && (("SalesDetailWork").Equals(((obj as ArrayList)[0]).GetType().Name)))
                                // --- UPD 2014/07/04 y.wakita -----<<<<<
                                {
                                    detailList = (ArrayList)obj;
                                }
                            }
                        }

                        # endregion
                    }
                    else
                    {
                        //---------------------------------------------
                        // 売上履歴
                        //---------------------------------------------

                        # region [売上履歴]
                        // 売上伝票データを読み込む
                        if ( pos > 0 )
                        {
                            _salesSlipHistDB = new SalesSlipHistDB();

                            SalesHistoryWork paraWork = new SalesHistoryWork();
                            paraWork.EnterpriseCode = (readparam[pos] as SalesSlipReadWork).EnterpriseCode;
                            paraWork.AcptAnOdrStatus = (readparam[pos] as SalesSlipReadWork).AcptAnOdrStatus;
                            paraWork.SalesSlipNum = (readparam[pos] as SalesSlipReadWork).SalesSlipNum;
                            ArrayList histDetailList = null;

                            // 売上履歴読み込み
                            status = _salesSlipHistDB.ReadProc( ref paraWork, ref histDetailList, 0, ref connection, ref transaction );
                            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                            {
                                // 売上履歴
                                readresult.Add( CopyToSalesSlipFromSalesHist( paraWork ) );
                                // 売上履歴明細
                                detailList = CopyToSalesDetailListFromSalesHistDtlList( histDetailList );
                                readresult.Add( detailList );
                            }
                        }
                        # endregion
                    }

                    # region [受注マスタ（車輌）]
                    // 受注マスタ（車輌）
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        ArrayList carList;
                        transaction = null;

                        if ( detailList != null && detailList.Count > 0 )
                        {
                            // 受注マスタ(車両)読み込み
                            AcceptOdrCarReader acceptOdrCarReader = new AcceptOdrCarReader();
                            acceptOdrCarReader.ReadWithSalesDetail( out carList, detailList, connection, transaction );
                            if ( carList != null && carList.Count > 0 )
                            {
                                // 受注マスタ(車両)
                                readresult.Add( carList );
                            }
                        }
                    }
                    # endregion
                }

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 読込結果を格納
                    retsliplist.AddRange( readresult );
                }
                else
                {
                    return status;
                }
                # endregion

                # region [関連する仕入伝票の取得]
                if ( pos > 0 )
                {
                    string sqlText = string.Empty;
                    command = new SqlCommand( sqlText, connection );

                    # region [SELECT]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "   SAH.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                    sqlText += "  ,SAH.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                    sqlText += "  ,STH.SUPPLIERFORMALRF AS STHFM" + Environment.NewLine;
                    sqlText += "  ,STH.SUPPLIERSLIPNORF AS STHNO" + Environment.NewLine;
                    sqlText += "  ,STC.SUPPLIERFORMALRF AS STCFM" + Environment.NewLine;
                    sqlText += "  ,STC.SUPPLIERSLIPNORF AS STCNO" + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    // -- UPD 2010/06/09 ----------------------------------------->>>
                    //sqlText += "  SALESHISTDTLRF AS SAH" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS SAH WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/09 -----------------------------------------<<<
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS STH" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF = STH.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND STH.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND SAH.SUPPLIERFORMALSYNCRF = STH.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND SAH.STOCKSLIPDTLNUMSYNCRF = STH.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "  STOCKDETAILRF AS STC" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF = STC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND STC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND SAH.SUPPLIERFORMALSYNCRF = STC.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "  AND SAH.STOCKSLIPDTLNUMSYNCRF = STC.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  SAH.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SAH.SALESSLIPNUMRF=@FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "  AND SAH.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "" + Environment.NewLine;
                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );  // 企業コード
                    SqlParameter findSalesSlipNum = command.Parameters.Add( "@FINDSALESSLIPNUM", SqlDbType.NChar );      // 伝票番号
                    SqlParameter findAcptAnOdrStatus = command.Parameters.Add( "@FINDACPTANODRSTATUS", SqlDbType.Int );  // 受注ステータス


                    SalesSlipReadWork readWork = (readparam[pos] as SalesSlipReadWork);
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString( readWork.EnterpriseCode );
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString( readWork.SalesSlipNum );
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32( readWork.AcptAnOdrStatus );
                    # endregion

                    DataTable aodrtable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter( command );

                    try
                    {
                        dataAdapter.Fill( aodrtable );

                        foreach ( DataRow row in aodrtable.Rows )
                        {
                            if ( row["STCNO"] != DBNull.Value && (int)row["STCNO"] > 0 )
                            {
                                //---------------------------------------------
                                // 仕入
                                //---------------------------------------------

                                # region [仕入]
                                // 読み込みパラメータセット
                                CustomSerializeArrayList stockParaList = new CustomSerializeArrayList();
                                StockSlipReadWork stockSlipReadWork = new StockSlipReadWork();
                                stockSlipReadWork.EnterpriseCode = readWork.EnterpriseCode;
                                stockSlipReadWork.SupplierFormal = (int)row["STCFM"];
                                stockSlipReadWork.SupplierSlipNo = (int)row["STCNO"];
                                stockParaList.Add( stockSlipReadWork );

                                // 仕入データ読み込み
                                CustomSerializeArrayList stockRetList = new CustomSerializeArrayList();
                                _stockSlipDB = new StockSlipDB();
                                object freeParam = null;//自由パラメータは利用しない

                                status = _stockSlipDB.Read( "CustPrtPprWorkDB", ref stockParaList, ref stockRetList, MakePosition( stockParaList, typeof( StockSlipReadWork ), 0 ), "", ref freeParam, ref connection );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // 読込結果を格納
                                    retrelationsliplist.Add( stockRetList );
                                }
                                # endregion
                            }
                            else if ( row["STHNO"] != DBNull.Value && (int)row["STHNO"] > 0 )
                            {
                                //---------------------------------------------
                                // 仕入履歴
                                //---------------------------------------------

                                # region [仕入履歴]
                                StockSlipHistWork stockHisParaWork = new StockSlipHistWork();
                                stockHisParaWork.EnterpriseCode = readWork.EnterpriseCode;
                                stockHisParaWork.SupplierFormal = (int)row["STHFM"];
                                stockHisParaWork.SupplierSlipNo = (int)row["STHNO"];

                                ArrayList stockHisDtlList = null;
                                ArrayList stockDetalList = null;
                                SqlTransaction transaction = null;
                                _stockSlipHistDB = new StockSlipHistDB();

                                status = _stockSlipHistDB.ReadProc( ref stockHisParaWork, ref stockHisDtlList, 0, ref connection, ref transaction );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                                    // 仕入履歴
                                    retList.Add( CopyToStockSlipFromStockHist( stockHisParaWork ) );
                                    // 仕入履歴明細
                                    stockDetalList = CopyToStockDetailListFromStockHistDtlList( stockHisDtlList );
                                    retList.Add( stockDetalList );

                                    // 読込結果を格納
                                    retrelationsliplist.Add( retList );
                                }
                                # endregion
                            }
                        }
                    }
                    finally
                    {
                        aodrtable.Dispose();
                        dataAdapter.Dispose();
                    }
                }
                # endregion
            }
            catch ( SqlException ex )
            {
                string errmsg = NSDebug.GetExecutingMethodName( new System.Diagnostics.StackFrame() );
                status = base.WriteSQLErrorLog( ex, errmsg, ex.Number );
            }
            finally
            {
                if ( command != null )
                {
                    command.Dispose();
                }
            }

            return status;
        }
        # region [データCopy処理]
        /// <summary>
        /// 売上履歴→売上
        /// </summary>
        /// <param name="salesHist"></param>
        /// <returns></returns>
        private SalesSlipWork CopyToSalesSlipFromSalesHist( SalesHistoryWork salesHist )
        {
            SalesSlipWork salesSlip = new SalesSlipWork();
            # region [Copy]
            salesSlip.CreateDateTime = salesHist.CreateDateTime;  // 作成日時
            salesSlip.UpdateDateTime = salesHist.UpdateDateTime;  // 更新日時
            salesSlip.EnterpriseCode = salesHist.EnterpriseCode;  // 企業コード
            salesSlip.FileHeaderGuid = salesHist.FileHeaderGuid;  // GUID
            salesSlip.UpdEmployeeCode = salesHist.UpdEmployeeCode;  // 更新従業員コード
            salesSlip.UpdAssemblyId1 = salesHist.UpdAssemblyId1;  // 更新アセンブリID1
            salesSlip.UpdAssemblyId2 = salesHist.UpdAssemblyId2;  // 更新アセンブリID2
            salesSlip.LogicalDeleteCode = salesHist.LogicalDeleteCode;  // 論理削除区分
            salesSlip.AcptAnOdrStatus = salesHist.AcptAnOdrStatus;  // 受注ステータス
            salesSlip.SalesSlipNum = salesHist.SalesSlipNum;  // 売上伝票番号
            salesSlip.SectionCode = salesHist.SectionCode;  // 拠点コード
            salesSlip.SubSectionCode = salesHist.SubSectionCode;  // 部門コード
            salesSlip.DebitNoteDiv = salesHist.DebitNoteDiv;  // 赤伝区分
            salesSlip.DebitNLnkSalesSlNum = salesHist.DebitNLnkSalesSlNum;  // 赤黒連結売上伝票番号
            salesSlip.SalesSlipCd = salesHist.SalesSlipCd;  // 売上伝票区分
            salesSlip.SalesGoodsCd = salesHist.SalesGoodsCd;  // 売上商品区分
            salesSlip.AccRecDivCd = salesHist.AccRecDivCd;  // 売掛区分
            salesSlip.SalesInpSecCd = salesHist.SalesInpSecCd;  // 売上入力拠点コード
            salesSlip.DemandAddUpSecCd = salesHist.DemandAddUpSecCd;  // 請求計上拠点コード
            salesSlip.ResultsAddUpSecCd = salesHist.ResultsAddUpSecCd;  // 実績計上拠点コード
            salesSlip.UpdateSecCd = salesHist.UpdateSecCd;  // 更新拠点コード
            salesSlip.SalesSlipUpdateCd = salesHist.SalesSlipUpdateCd;  // 売上伝票更新区分
            salesSlip.SearchSlipDate = salesHist.SearchSlipDate;  // 伝票検索日付
            salesSlip.ShipmentDay = salesHist.ShipmentDay;  // 出荷日付
            salesSlip.SalesDate = salesHist.SalesDate;  // 売上日付
            salesSlip.AddUpADate = salesHist.AddUpADate;  // 計上日付
            salesSlip.DelayPaymentDiv = salesHist.DelayPaymentDiv;  // 来勘区分
            salesSlip.InputAgenCd = salesHist.InputAgenCd;  // 入力担当者コード
            salesSlip.InputAgenNm = salesHist.InputAgenNm;  // 入力担当者名称
            salesSlip.SalesInputCode = salesHist.SalesInputCode;  // 売上入力者コード
            salesSlip.SalesInputName = salesHist.SalesInputName;  // 売上入力者名称
            salesSlip.FrontEmployeeCd = salesHist.FrontEmployeeCd;  // 受付従業員コード
            salesSlip.FrontEmployeeNm = salesHist.FrontEmployeeNm;  // 受付従業員名称
            salesSlip.SalesEmployeeCd = salesHist.SalesEmployeeCd;  // 販売従業員コード
            salesSlip.SalesEmployeeNm = salesHist.SalesEmployeeNm;  // 販売従業員名称
            salesSlip.TotalAmountDispWayCd = salesHist.TotalAmountDispWayCd;  // 総額表示方法区分
            salesSlip.TtlAmntDispRateApy = salesHist.TtlAmntDispRateApy;  // 総額表示掛率適用区分
            salesSlip.SalesTotalTaxInc = salesHist.SalesTotalTaxInc;  // 売上伝票合計（税込み）
            salesSlip.SalesTotalTaxExc = salesHist.SalesTotalTaxExc;  // 売上伝票合計（税抜き）
            salesSlip.SalesPrtTotalTaxInc = salesHist.SalesPrtTotalTaxInc;  // 売上部品合計（税込み）
            salesSlip.SalesPrtTotalTaxExc = salesHist.SalesPrtTotalTaxExc;  // 売上部品合計（税抜き）
            salesSlip.SalesWorkTotalTaxInc = salesHist.SalesWorkTotalTaxInc;  // 売上作業合計（税込み）
            salesSlip.SalesWorkTotalTaxExc = salesHist.SalesWorkTotalTaxExc;  // 売上作業合計（税抜き）
            salesSlip.SalesSubtotalTaxInc = salesHist.SalesSubtotalTaxInc;  // 売上小計（税込み）
            salesSlip.SalesSubtotalTaxExc = salesHist.SalesSubtotalTaxExc;  // 売上小計（税抜き）
            salesSlip.SalesPrtSubttlInc = salesHist.SalesPrtSubttlInc;  // 売上部品小計（税込み）
            salesSlip.SalesPrtSubttlExc = salesHist.SalesPrtSubttlExc;  // 売上部品小計（税抜き）
            salesSlip.SalesWorkSubttlInc = salesHist.SalesWorkSubttlInc;  // 売上作業小計（税込み）
            salesSlip.SalesWorkSubttlExc = salesHist.SalesWorkSubttlExc;  // 売上作業小計（税抜き）
            salesSlip.SalesNetPrice = salesHist.SalesNetPrice;  // 売上正価金額
            salesSlip.SalesSubtotalTax = salesHist.SalesSubtotalTax;  // 売上小計（税）
            salesSlip.ItdedSalesOutTax = salesHist.ItdedSalesOutTax;  // 売上外税対象額
            salesSlip.ItdedSalesInTax = salesHist.ItdedSalesInTax;  // 売上内税対象額
            salesSlip.SalSubttlSubToTaxFre = salesHist.SalSubttlSubToTaxFre;  // 売上小計非課税対象額
            salesSlip.SalesOutTax = salesHist.SalesOutTax;  // 売上外税額
            salesSlip.SalAmntConsTaxInclu = salesHist.SalAmntConsTaxInclu;  // 売上金額消費税額（内税）
            salesSlip.SalesDisTtlTaxExc = salesHist.SalesDisTtlTaxExc;  // 売上値引金額計（税抜き）
            salesSlip.ItdedSalesDisOutTax = salesHist.ItdedSalesDisOutTax;  // 売上値引外税対象額合計
            salesSlip.ItdedSalesDisInTax = salesHist.ItdedSalesDisInTax;  // 売上値引内税対象額合計
            salesSlip.ItdedPartsDisOutTax = salesHist.ItdedPartsDisOutTax;  // 部品値引対象額合計（税抜き）
            salesSlip.ItdedPartsDisInTax = salesHist.ItdedPartsDisInTax;  // 部品値引対象額合計（税込み）
            salesSlip.ItdedWorkDisOutTax = salesHist.ItdedWorkDisOutTax;  // 作業値引対象額合計（税抜き）
            salesSlip.ItdedWorkDisInTax = salesHist.ItdedWorkDisInTax;  // 作業値引対象額合計（税込み）
            salesSlip.ItdedSalesDisTaxFre = salesHist.ItdedSalesDisTaxFre;  // 売上値引非課税対象額合計
            salesSlip.SalesDisOutTax = salesHist.SalesDisOutTax;  // 売上値引消費税額（外税）
            salesSlip.SalesDisTtlTaxInclu = salesHist.SalesDisTtlTaxInclu;  // 売上値引消費税額（内税）
            salesSlip.PartsDiscountRate = salesHist.PartsDiscountRate;  // 部品値引率
            salesSlip.RavorDiscountRate = salesHist.RavorDiscountRate;  // 工賃値引率
            salesSlip.TotalCost = salesHist.TotalCost;  // 原価金額計
            salesSlip.ConsTaxLayMethod = salesHist.ConsTaxLayMethod;  // 消費税転嫁方式
            salesSlip.ConsTaxRate = salesHist.ConsTaxRate;  // 消費税税率
            salesSlip.FractionProcCd = salesHist.FractionProcCd;  // 端数処理区分
            salesSlip.AccRecConsTax = salesHist.AccRecConsTax;  // 売掛消費税
            salesSlip.AutoDepositCd = salesHist.AutoDepositCd;  // 自動入金区分
            salesSlip.AutoDepositSlipNo = salesHist.AutoDepositSlipNo;  // 自動入金伝票番号
            salesSlip.DepositAllowanceTtl = salesHist.DepositAllowanceTtl;  // 入金引当合計額
            salesSlip.DepositAlwcBlnce = salesHist.DepositAlwcBlnce;  // 入金引当残高
            salesSlip.ClaimCode = salesHist.ClaimCode;  // 請求先コード
            salesSlip.ClaimSnm = salesHist.ClaimSnm;  // 請求先略称
            salesSlip.CustomerCode = salesHist.CustomerCode;  // 得意先コード
            salesSlip.CustomerName = salesHist.CustomerName;  // 得意先名称
            salesSlip.CustomerName2 = salesHist.CustomerName2;  // 得意先名称2
            salesSlip.CustomerSnm = salesHist.CustomerSnm;  // 得意先略称
            salesSlip.HonorificTitle = salesHist.HonorificTitle;  // 敬称
            salesSlip.OutputNameCode = salesHist.OutputNameCode;  // 諸口コード
            salesSlip.OutputName = salesHist.OutputName;  // 諸口名称
            //salesSlip.CustSlipNo = salesHist.CustSlipNo;  // 得意先伝票番号
            salesSlip.SlipAddressDiv = salesHist.SlipAddressDiv;  // 伝票住所区分
            salesSlip.AddresseeCode = salesHist.AddresseeCode;  // 納品先コード
            salesSlip.AddresseeName = salesHist.AddresseeName;  // 納品先名称
            salesSlip.AddresseeName2 = salesHist.AddresseeName2;  // 納品先名称2
            salesSlip.AddresseePostNo = salesHist.AddresseePostNo;  // 納品先郵便番号
            salesSlip.AddresseeAddr1 = salesHist.AddresseeAddr1;  // 納品先住所1（都道府県市区郡・町村・字）
            salesSlip.AddresseeAddr3 = salesHist.AddresseeAddr3;  // 納品先住所3（番地）
            salesSlip.AddresseeAddr4 = salesHist.AddresseeAddr4;  // 納品先住所4（アパート名称）
            salesSlip.AddresseeTelNo = salesHist.AddresseeTelNo;  // 納品先電話番号
            salesSlip.AddresseeFaxNo = salesHist.AddresseeFaxNo;  // 納品先FAX番号
            salesSlip.PartySaleSlipNum = salesHist.PartySaleSlipNum;  // 相手先伝票番号
            salesSlip.SlipNote = salesHist.SlipNote;  // 伝票備考
            salesSlip.SlipNote2 = salesHist.SlipNote2;  // 伝票備考２
            salesSlip.SlipNote3 = salesHist.SlipNote3;  // 伝票備考３
            salesSlip.RetGoodsReasonDiv = salesHist.RetGoodsReasonDiv;  // 返品理由コード
            salesSlip.RetGoodsReason = salesHist.RetGoodsReason;  // 返品理由
            salesSlip.DetailRowCount = salesHist.DetailRowCount;  // 明細行数
            salesSlip.EdiSendDate = salesHist.EdiSendDate;  // ＥＤＩ送信日
            salesSlip.EdiTakeInDate = salesHist.EdiTakeInDate;  // ＥＤＩ取込日
            salesSlip.UoeRemark1 = salesHist.UoeRemark1;  // ＵＯＥリマーク１
            salesSlip.UoeRemark2 = salesHist.UoeRemark2;  // ＵＯＥリマーク２
            salesSlip.SlipPrintDivCd = salesHist.SlipPrintDivCd;  // 伝票発行区分
            salesSlip.SlipPrintFinishCd = salesHist.SlipPrintFinishCd;  // 伝票発行済区分
            salesSlip.SalesSlipPrintDate = salesHist.SalesSlipPrintDate;  // 売上伝票発行日
            salesSlip.BusinessTypeCode = salesHist.BusinessTypeCode;  // 業種コード
            salesSlip.BusinessTypeName = salesHist.BusinessTypeName;  // 業種名称
            salesSlip.DeliveredGoodsDiv = salesHist.DeliveredGoodsDiv;  // 納品区分
            salesSlip.DeliveredGoodsDivNm = salesHist.DeliveredGoodsDivNm;  // 納品区分名称
            salesSlip.SalesAreaCode = salesHist.SalesAreaCode;  // 販売エリアコード
            salesSlip.SalesAreaName = salesHist.SalesAreaName;  // 販売エリア名称
            salesSlip.SlipPrtSetPaperId = salesHist.SlipPrtSetPaperId;  // 伝票印刷設定用帳票ID
            salesSlip.CompleteCd = salesHist.CompleteCd;  // 一式伝票区分
            salesSlip.SalesPriceFracProcCd = salesHist.SalesPriceFracProcCd;  // 売上金額端数処理区分
            salesSlip.StockGoodsTtlTaxExc = salesHist.StockGoodsTtlTaxExc;  // 在庫商品合計金額（税抜）
            salesSlip.PureGoodsTtlTaxExc = salesHist.PureGoodsTtlTaxExc;  // 純正商品合計金額（税抜）
            salesSlip.ListPricePrintDiv = salesHist.ListPricePrintDiv;  // 定価印刷区分
            salesSlip.EraNameDispCd1 = salesHist.EraNameDispCd1;  // 元号表示区分１
            # endregion
            return salesSlip;
        }
        /// <summary>
        /// 売上履歴明細→売上明細
        /// </summary>
        /// <param name="histDetail"></param>
        /// <returns></returns>
        private SalesDetailWork CopyToSalesDetailFromSalesHistDtl( SalesHistDtlWork histDetail )
        {
            SalesDetailWork salesDetail = new SalesDetailWork();
            # region [Copy]
            salesDetail.CreateDateTime = histDetail.CreateDateTime;  // 作成日時
            salesDetail.UpdateDateTime = histDetail.UpdateDateTime;  // 更新日時
            salesDetail.EnterpriseCode = histDetail.EnterpriseCode;  // 企業コード
            salesDetail.FileHeaderGuid = histDetail.FileHeaderGuid;  // GUID
            salesDetail.UpdEmployeeCode = histDetail.UpdEmployeeCode;  // 更新従業員コード
            salesDetail.UpdAssemblyId1 = histDetail.UpdAssemblyId1;  // 更新アセンブリID1
            salesDetail.UpdAssemblyId2 = histDetail.UpdAssemblyId2;  // 更新アセンブリID2
            salesDetail.LogicalDeleteCode = histDetail.LogicalDeleteCode;  // 論理削除区分
            salesDetail.AcceptAnOrderNo = histDetail.AcceptAnOrderNo;  // 受注番号
            salesDetail.AcptAnOdrStatus = histDetail.AcptAnOdrStatus;  // 受注ステータス
            salesDetail.SalesSlipNum = histDetail.SalesSlipNum;  // 売上伝票番号
            salesDetail.SalesRowNo = histDetail.SalesRowNo;  // 売上行番号
            salesDetail.SalesRowDerivNo = histDetail.SalesRowDerivNo;  // 売上行番号枝番
            salesDetail.SectionCode = histDetail.SectionCode;  // 拠点コード
            salesDetail.SubSectionCode = histDetail.SubSectionCode;  // 部門コード
            salesDetail.SalesDate = histDetail.SalesDate;  // 売上日付
            salesDetail.CommonSeqNo = histDetail.CommonSeqNo;  // 共通通番
            salesDetail.SalesSlipDtlNum = histDetail.SalesSlipDtlNum;  // 売上明細通番
            salesDetail.AcptAnOdrStatusSrc = histDetail.AcptAnOdrStatusSrc;  // 受注ステータス（元）
            salesDetail.SalesSlipDtlNumSrc = histDetail.SalesSlipDtlNumSrc;  // 売上明細通番（元）
            salesDetail.SupplierFormalSync = histDetail.SupplierFormalSync;  // 仕入形式（同時）
            salesDetail.StockSlipDtlNumSync = histDetail.StockSlipDtlNumSync;  // 仕入明細通番（同時）
            salesDetail.SalesSlipCdDtl = histDetail.SalesSlipCdDtl;  // 売上伝票区分（明細）
            salesDetail.GoodsKindCode = histDetail.GoodsKindCode;  // 商品属性
            salesDetail.GoodsMakerCd = histDetail.GoodsMakerCd;  // 商品メーカーコード
            salesDetail.MakerName = histDetail.MakerName;  // メーカー名称
            salesDetail.MakerKanaName = histDetail.MakerKanaName;  // メーカーカナ名称
            salesDetail.GoodsNo = histDetail.GoodsNo;  // 商品番号
            salesDetail.GoodsName = histDetail.GoodsName;  // 商品名称
            salesDetail.GoodsNameKana = histDetail.GoodsNameKana;  // 商品名称カナ
            salesDetail.GoodsLGroup = histDetail.GoodsLGroup;  // 商品大分類コード
            salesDetail.GoodsLGroupName = histDetail.GoodsLGroupName;  // 商品大分類名称
            salesDetail.GoodsMGroup = histDetail.GoodsMGroup;  // 商品中分類コード
            salesDetail.GoodsMGroupName = histDetail.GoodsMGroupName;  // 商品中分類名称
            salesDetail.BLGroupCode = histDetail.BLGroupCode;  // BLグループコード
            salesDetail.BLGroupName = histDetail.BLGroupName;  // BLグループ名称
            salesDetail.BLGoodsCode = histDetail.BLGoodsCode;  // BL商品コード
            salesDetail.BLGoodsFullName = histDetail.BLGoodsFullName;  // BL商品コード名称（全角）
            salesDetail.EnterpriseGanreCode = histDetail.EnterpriseGanreCode;  // 自社分類コード
            salesDetail.EnterpriseGanreName = histDetail.EnterpriseGanreName;  // 自社分類名称
            salesDetail.WarehouseCode = histDetail.WarehouseCode;  // 倉庫コード
            salesDetail.WarehouseName = histDetail.WarehouseName;  // 倉庫名称
            salesDetail.WarehouseShelfNo = histDetail.WarehouseShelfNo;  // 倉庫棚番
            salesDetail.SalesOrderDivCd = histDetail.SalesOrderDivCd;  // 売上在庫取寄せ区分
            salesDetail.OpenPriceDiv = histDetail.OpenPriceDiv;  // オープン価格区分
            salesDetail.GoodsRateRank = histDetail.GoodsRateRank;  // 商品掛率ランク
            salesDetail.CustRateGrpCode = histDetail.CustRateGrpCode;  // 得意先掛率グループコード
            salesDetail.ListPriceRate = histDetail.ListPriceRate;  // 定価率
            salesDetail.RateSectPriceUnPrc = histDetail.RateSectPriceUnPrc;  // 掛率設定拠点（定価）
            salesDetail.RateDivLPrice = histDetail.RateDivLPrice;  // 掛率設定区分（定価）
            salesDetail.UnPrcCalcCdLPrice = histDetail.UnPrcCalcCdLPrice;  // 単価算出区分（定価）
            salesDetail.PriceCdLPrice = histDetail.PriceCdLPrice;  // 価格区分（定価）
            salesDetail.StdUnPrcLPrice = histDetail.StdUnPrcLPrice;  // 基準単価（定価）
            salesDetail.FracProcUnitLPrice = histDetail.FracProcUnitLPrice;  // 端数処理単位（定価）
            salesDetail.FracProcLPrice = histDetail.FracProcLPrice;  // 端数処理（定価）
            salesDetail.ListPriceTaxIncFl = histDetail.ListPriceTaxIncFl;  // 定価（税込，浮動）
            salesDetail.ListPriceTaxExcFl = histDetail.ListPriceTaxExcFl;  // 定価（税抜，浮動）
            salesDetail.ListPriceChngCd = histDetail.ListPriceChngCd;  // 定価変更区分
            salesDetail.SalesRate = histDetail.SalesRate;  // 売価率
            salesDetail.RateSectSalUnPrc = histDetail.RateSectSalUnPrc;  // 掛率設定拠点（売上単価）
            salesDetail.RateDivSalUnPrc = histDetail.RateDivSalUnPrc;  // 掛率設定区分（売上単価）
            salesDetail.UnPrcCalcCdSalUnPrc = histDetail.UnPrcCalcCdSalUnPrc;  // 単価算出区分（売上単価）
            salesDetail.PriceCdSalUnPrc = histDetail.PriceCdSalUnPrc;  // 価格区分（売上単価）
            salesDetail.StdUnPrcSalUnPrc = histDetail.StdUnPrcSalUnPrc;  // 基準単価（売上単価）
            salesDetail.FracProcUnitSalUnPrc = histDetail.FracProcUnitSalUnPrc;  // 端数処理単位（売上単価）
            salesDetail.FracProcSalUnPrc = histDetail.FracProcSalUnPrc;  // 端数処理（売上単価）
            salesDetail.SalesUnPrcTaxIncFl = histDetail.SalesUnPrcTaxIncFl;  // 売上単価（税込，浮動）
            salesDetail.SalesUnPrcTaxExcFl = histDetail.SalesUnPrcTaxExcFl;  // 売上単価（税抜，浮動）
            salesDetail.SalesUnPrcChngCd = histDetail.SalesUnPrcChngCd;  // 売上単価変更区分
            salesDetail.CostRate = histDetail.CostRate;  // 原価率
            salesDetail.RateSectCstUnPrc = histDetail.RateSectCstUnPrc;  // 掛率設定拠点（原価単価）
            salesDetail.RateDivUnCst = histDetail.RateDivUnCst;  // 掛率設定区分（原価単価）
            salesDetail.UnPrcCalcCdUnCst = histDetail.UnPrcCalcCdUnCst;  // 単価算出区分（原価単価）
            salesDetail.PriceCdUnCst = histDetail.PriceCdUnCst;  // 価格区分（原価単価）
            salesDetail.StdUnPrcUnCst = histDetail.StdUnPrcUnCst;  // 基準単価（原価単価）
            salesDetail.FracProcUnitUnCst = histDetail.FracProcUnitUnCst;  // 端数処理単位（原価単価）
            salesDetail.FracProcUnCst = histDetail.FracProcUnCst;  // 端数処理（原価単価）
            salesDetail.SalesUnitCost = histDetail.SalesUnitCost;  // 原価単価
            salesDetail.SalesUnitCostChngDiv = histDetail.SalesUnitCostChngDiv;  // 原価単価変更区分
            salesDetail.RateBLGoodsCode = histDetail.RateBLGoodsCode;  // BL商品コード（掛率）
            salesDetail.RateBLGoodsName = histDetail.RateBLGoodsName;  // BL商品コード名称（掛率）
            salesDetail.RateGoodsRateGrpCd = histDetail.RateGoodsRateGrpCd;  // 商品掛率グループコード（掛率）
            salesDetail.RateGoodsRateGrpNm = histDetail.RateGoodsRateGrpNm;  // 商品掛率グループ名称（掛率）
            salesDetail.RateBLGroupCode = histDetail.RateBLGroupCode;  // BLグループコード（掛率）
            salesDetail.RateBLGroupName = histDetail.RateBLGroupName;  // BLグループ名称（掛率）
            salesDetail.PrtBLGoodsCode = histDetail.PrtBLGoodsCode;  // BL商品コード（印刷）
            salesDetail.PrtBLGoodsName = histDetail.PrtBLGoodsName;  // BL商品コード名称（印刷）
            salesDetail.SalesCode = histDetail.SalesCode;  // 販売区分コード
            salesDetail.SalesCdNm = histDetail.SalesCdNm;  // 販売区分名称
            salesDetail.WorkManHour = histDetail.WorkManHour;  // 作業工数
            salesDetail.ShipmentCnt = histDetail.ShipmentCnt;  // 出荷数
            salesDetail.SalesMoneyTaxInc = histDetail.SalesMoneyTaxInc;  // 売上金額（税込み）
            salesDetail.SalesMoneyTaxExc = histDetail.SalesMoneyTaxExc;  // 売上金額（税抜き）
            salesDetail.Cost = histDetail.Cost;  // 原価
            salesDetail.GrsProfitChkDiv = histDetail.GrsProfitChkDiv;  // 粗利チェック区分
            salesDetail.SalesGoodsCd = histDetail.SalesGoodsCd;  // 売上商品区分
            salesDetail.SalesPriceConsTax = histDetail.SalesPriceConsTax;  // 売上金額消費税額
            salesDetail.TaxationDivCd = histDetail.TaxationDivCd;  // 課税区分
            salesDetail.PartySlipNumDtl = histDetail.PartySlipNumDtl;  // 相手先伝票番号（明細）
            salesDetail.DtlNote = histDetail.DtlNote;  // 明細備考
            salesDetail.SupplierCd = histDetail.SupplierCd;  // 仕入先コード
            salesDetail.SupplierSnm = histDetail.SupplierSnm;  // 仕入先略称
            salesDetail.OrderNumber = histDetail.OrderNumber;  // 発注番号
            salesDetail.WayToOrder = histDetail.WayToOrder;  // 注文方法
            salesDetail.SlipMemo1 = histDetail.SlipMemo1;  // 伝票メモ１
            salesDetail.SlipMemo2 = histDetail.SlipMemo2;  // 伝票メモ２
            salesDetail.SlipMemo3 = histDetail.SlipMemo3;  // 伝票メモ３
            salesDetail.InsideMemo1 = histDetail.InsideMemo1;  // 社内メモ１
            salesDetail.InsideMemo2 = histDetail.InsideMemo2;  // 社内メモ２
            salesDetail.InsideMemo3 = histDetail.InsideMemo3;  // 社内メモ３
            salesDetail.BfListPrice = histDetail.BfListPrice;  // 変更前定価
            salesDetail.BfSalesUnitPrice = histDetail.BfSalesUnitPrice;  // 変更前売価
            salesDetail.BfUnitCost = histDetail.BfUnitCost;  // 変更前原価
            salesDetail.CmpltSalesRowNo = histDetail.CmpltSalesRowNo;  // 一式明細番号
            salesDetail.CmpltGoodsMakerCd = histDetail.CmpltGoodsMakerCd;  // メーカーコード（一式）
            salesDetail.CmpltMakerName = histDetail.CmpltMakerName;  // メーカー名称（一式）
            salesDetail.CmpltMakerKanaName = histDetail.CmpltMakerKanaName;  // メーカーカナ名称（一式）
            salesDetail.CmpltGoodsName = histDetail.CmpltGoodsName;  // 商品名称（一式）
            salesDetail.CmpltShipmentCnt = histDetail.CmpltShipmentCnt;  // 数量（一式）
            salesDetail.CmpltSalesUnPrcFl = histDetail.CmpltSalesUnPrcFl;  // 売上単価（一式）
            salesDetail.CmpltSalesMoney = histDetail.CmpltSalesMoney;  // 売上金額（一式）
            salesDetail.CmpltSalesUnitCost = histDetail.CmpltSalesUnitCost;  // 原価単価（一式）
            salesDetail.CmpltCost = histDetail.CmpltCost;  // 原価金額（一式）
            salesDetail.CmpltPartySalSlNum = histDetail.CmpltPartySalSlNum;  // 相手先伝票番号（一式）
            salesDetail.CmpltNote = histDetail.CmpltNote;  // 一式備考
            salesDetail.PrtGoodsNo = histDetail.PrtGoodsNo;  // 印刷用商品番号
            salesDetail.PrtMakerCode = histDetail.PrtMakerCode;  // 印刷用メーカーコード
            salesDetail.PrtMakerName = histDetail.PrtMakerName;  // 印刷用メーカー名称
            salesDetail.CampaignCode = histDetail.CampaignCode;  // キャンペーンコード
            salesDetail.CampaignName = histDetail.CampaignName;  // キャンペーン名称
            salesDetail.GoodsDivCd = histDetail.GoodsDivCd;  // 商品種別
            salesDetail.AnswerDelivDate = histDetail.AnswerDelivDate;  // 回答納期
            salesDetail.RecycleDiv = histDetail.RecycleDiv;  // リサイクル区分
            salesDetail.RecycleDivNm = histDetail.RecycleDivNm;  // リサイクル区分名称
            salesDetail.WayToAcptOdr = histDetail.WayToAcptOdr;  // 受注方法
            # endregion
            return salesDetail;
        }
        /// <summary>
        /// 売上履歴明細リスト→売上明細リスト
        /// </summary>
        /// <param name="histDetailList"></param>
        /// <returns></returns>
        private ArrayList CopyToSalesDetailListFromSalesHistDtlList( ArrayList histDetailList )
        {
            ArrayList retList = new ArrayList();

            foreach ( SalesHistDtlWork histDetail in histDetailList )
            {
                retList.Add( CopyToSalesDetailFromSalesHistDtl( histDetail ) );
            }

            return retList;
        }
        /// <summary>
        /// 仕入履歴→仕入
        /// </summary>
        /// <param name="stockHisParaWork"></param>
        /// <returns></returns>
        private StockSlipWork CopyToStockSlipFromStockHist( StockSlipHistWork stockHist )
        {
            StockSlipWork stockSlip = new StockSlipWork();
            # region [Copy]
            stockSlip.CreateDateTime = stockHist.CreateDateTime;  // 作成日時
            stockSlip.UpdateDateTime = stockHist.UpdateDateTime;  // 更新日時
            stockSlip.EnterpriseCode = stockHist.EnterpriseCode;  // 企業コード
            stockSlip.FileHeaderGuid = stockHist.FileHeaderGuid;  // GUID
            stockSlip.UpdEmployeeCode = stockHist.UpdEmployeeCode;  // 更新従業員コード
            stockSlip.UpdAssemblyId1 = stockHist.UpdAssemblyId1;  // 更新アセンブリID1
            stockSlip.UpdAssemblyId2 = stockHist.UpdAssemblyId2;  // 更新アセンブリID2
            stockSlip.LogicalDeleteCode = stockHist.LogicalDeleteCode;  // 論理削除区分
            stockSlip.SupplierFormal = stockHist.SupplierFormal;  // 仕入形式
            stockSlip.SupplierSlipNo = stockHist.SupplierSlipNo;  // 仕入伝票番号
            stockSlip.SectionCode = stockHist.SectionCode;  // 拠点コード
            stockSlip.SubSectionCode = stockHist.SubSectionCode;  // 部門コード
            stockSlip.DebitNoteDiv = stockHist.DebitNoteDiv;  // 赤伝区分
            stockSlip.DebitNLnkSuppSlipNo = stockHist.DebitNLnkSuppSlipNo;  // 赤黒連結仕入伝票番号
            stockSlip.SupplierSlipCd = stockHist.SupplierSlipCd;  // 仕入伝票区分
            stockSlip.StockGoodsCd = stockHist.StockGoodsCd;  // 仕入商品区分
            stockSlip.AccPayDivCd = stockHist.AccPayDivCd;  // 買掛区分
            stockSlip.StockSectionCd = stockHist.StockSectionCd;  // 仕入拠点コード
            stockSlip.StockAddUpSectionCd = stockHist.StockAddUpSectionCd;  // 仕入計上拠点コード
            stockSlip.StockSlipUpdateCd = stockHist.StockSlipUpdateCd;  // 仕入伝票更新区分
            stockSlip.InputDay = stockHist.InputDay;  // 入力日
            stockSlip.ArrivalGoodsDay = stockHist.ArrivalGoodsDay;  // 入荷日
            stockSlip.StockDate = stockHist.StockDate;  // 仕入日
            stockSlip.StockAddUpADate = stockHist.StockAddUpADate;  // 仕入計上日付
            stockSlip.DelayPaymentDiv = stockHist.DelayPaymentDiv;  // 来勘区分
            stockSlip.PayeeCode = stockHist.PayeeCode;  // 支払先コード
            stockSlip.PayeeSnm = stockHist.PayeeSnm;  // 支払先略称
            stockSlip.SupplierCd = stockHist.SupplierCd;  // 仕入先コード
            stockSlip.SupplierNm1 = stockHist.SupplierNm1;  // 仕入先名1
            stockSlip.SupplierNm2 = stockHist.SupplierNm2;  // 仕入先名2
            stockSlip.SupplierSnm = stockHist.SupplierSnm;  // 仕入先略称
            stockSlip.BusinessTypeCode = stockHist.BusinessTypeCode;  // 業種コード
            stockSlip.BusinessTypeName = stockHist.BusinessTypeName;  // 業種名称
            stockSlip.SalesAreaCode = stockHist.SalesAreaCode;  // 販売エリアコード
            stockSlip.SalesAreaName = stockHist.SalesAreaName;  // 販売エリア名称
            stockSlip.StockInputCode = stockHist.StockInputCode;  // 仕入入力者コード
            stockSlip.StockInputName = stockHist.StockInputName;  // 仕入入力者名称
            stockSlip.StockAgentCode = stockHist.StockAgentCode;  // 仕入担当者コード
            stockSlip.StockAgentName = stockHist.StockAgentName;  // 仕入担当者名称
            stockSlip.SuppTtlAmntDspWayCd = stockHist.SuppTtlAmntDspWayCd;  // 仕入先総額表示方法区分
            stockSlip.TtlAmntDispRateApy = stockHist.TtlAmntDispRateApy;  // 総額表示掛率適用区分
            stockSlip.StockTotalPrice = stockHist.StockTotalPrice;  // 仕入金額合計
            stockSlip.StockSubttlPrice = stockHist.StockSubttlPrice;  // 仕入金額小計
            stockSlip.StockTtlPricTaxInc = stockHist.StockTtlPricTaxInc;  // 仕入金額計（税込み）
            stockSlip.StockTtlPricTaxExc = stockHist.StockTtlPricTaxExc;  // 仕入金額計（税抜き）
            stockSlip.StockNetPrice = stockHist.StockNetPrice;  // 仕入正価金額
            stockSlip.StockPriceConsTax = stockHist.StockPriceConsTax;  // 仕入金額消費税額
            stockSlip.TtlItdedStcOutTax = stockHist.TtlItdedStcOutTax;  // 仕入外税対象額合計
            stockSlip.TtlItdedStcInTax = stockHist.TtlItdedStcInTax;  // 仕入内税対象額合計
            stockSlip.TtlItdedStcTaxFree = stockHist.TtlItdedStcTaxFree;  // 仕入非課税対象額合計
            stockSlip.StockOutTax = stockHist.StockOutTax;  // 仕入金額消費税額（外税）
            stockSlip.StckPrcConsTaxInclu = stockHist.StckPrcConsTaxInclu;  // 仕入金額消費税額（内税）
            stockSlip.StckDisTtlTaxExc = stockHist.StckDisTtlTaxExc;  // 仕入値引金額計（税抜き）
            stockSlip.ItdedStockDisOutTax = stockHist.ItdedStockDisOutTax;  // 仕入値引外税対象額合計
            stockSlip.ItdedStockDisInTax = stockHist.ItdedStockDisInTax;  // 仕入値引内税対象額合計
            stockSlip.ItdedStockDisTaxFre = stockHist.ItdedStockDisTaxFre;  // 仕入値引非課税対象額合計
            stockSlip.StockDisOutTax = stockHist.StockDisOutTax;  // 仕入値引消費税額（外税）
            stockSlip.StckDisTtlTaxInclu = stockHist.StckDisTtlTaxInclu;  // 仕入値引消費税額（内税）
            stockSlip.TaxAdjust = stockHist.TaxAdjust;  // 消費税調整額
            stockSlip.BalanceAdjust = stockHist.BalanceAdjust;  // 残高調整額
            stockSlip.SuppCTaxLayCd = stockHist.SuppCTaxLayCd;  // 仕入先消費税転嫁方式コード
            stockSlip.SupplierConsTaxRate = stockHist.SupplierConsTaxRate;  // 仕入先消費税税率
            stockSlip.AccPayConsTax = stockHist.AccPayConsTax;  // 買掛消費税
            stockSlip.StockFractionProcCd = stockHist.StockFractionProcCd;  // 仕入端数処理区分
            stockSlip.AutoPayment = stockHist.AutoPayment;  // 自動支払区分
            stockSlip.AutoPaySlipNum = stockHist.AutoPaySlipNum;  // 自動支払伝票番号
            stockSlip.RetGoodsReasonDiv = stockHist.RetGoodsReasonDiv;  // 返品理由コード
            stockSlip.RetGoodsReason = stockHist.RetGoodsReason;  // 返品理由
            stockSlip.PartySaleSlipNum = stockHist.PartySaleSlipNum;  // 相手先伝票番号
            stockSlip.SupplierSlipNote1 = stockHist.SupplierSlipNote1;  // 仕入伝票備考1
            stockSlip.SupplierSlipNote2 = stockHist.SupplierSlipNote2;  // 仕入伝票備考2
            stockSlip.DetailRowCount = stockHist.DetailRowCount;  // 明細行数
            stockSlip.EdiSendDate = stockHist.EdiSendDate;  // ＥＤＩ送信日
            stockSlip.EdiTakeInDate = stockHist.EdiTakeInDate;  // ＥＤＩ取込日
            stockSlip.UoeRemark1 = stockHist.UoeRemark1;  // ＵＯＥリマーク１
            stockSlip.UoeRemark2 = stockHist.UoeRemark2;  // ＵＯＥリマーク２
            stockSlip.SlipPrintDivCd = stockHist.SlipPrintDivCd;  // 伝票発行区分
            stockSlip.SlipPrintFinishCd = stockHist.SlipPrintFinishCd;  // 伝票発行済区分
            stockSlip.StockSlipPrintDate = stockHist.StockSlipPrintDate;  // 仕入伝票発行日
            stockSlip.SlipPrtSetPaperId = stockHist.SlipPrtSetPaperId;  // 伝票印刷設定用帳票ID
            # endregion
            return stockSlip;
        }
        /// <summary>
        /// 仕入履歴明細→仕入明細
        /// </summary>
        /// <param name="histDetail"></param>
        /// <returns></returns>
        private StockDetailWork CopyToStockDetailFromStockHistDtl( StockSlHistDtlWork histDetail )
        {
            StockDetailWork stockDetail = new StockDetailWork();
            # region [Copy]
            stockDetail.CreateDateTime = histDetail.CreateDateTime;  // 作成日時
            stockDetail.UpdateDateTime = histDetail.UpdateDateTime;  // 更新日時
            stockDetail.EnterpriseCode = histDetail.EnterpriseCode;  // 企業コード
            stockDetail.FileHeaderGuid = histDetail.FileHeaderGuid;  // GUID
            stockDetail.UpdEmployeeCode = histDetail.UpdEmployeeCode;  // 更新従業員コード
            stockDetail.UpdAssemblyId1 = histDetail.UpdAssemblyId1;  // 更新アセンブリID1
            stockDetail.UpdAssemblyId2 = histDetail.UpdAssemblyId2;  // 更新アセンブリID2
            stockDetail.LogicalDeleteCode = histDetail.LogicalDeleteCode;  // 論理削除区分
            stockDetail.AcceptAnOrderNo = histDetail.AcceptAnOrderNo;  // 受注番号
            stockDetail.SupplierFormal = histDetail.SupplierFormal;  // 仕入形式
            stockDetail.SupplierSlipNo = histDetail.SupplierSlipNo;  // 仕入伝票番号
            stockDetail.StockRowNo = histDetail.StockRowNo;  // 仕入行番号
            stockDetail.SectionCode = histDetail.SectionCode;  // 拠点コード
            stockDetail.SubSectionCode = histDetail.SubSectionCode;  // 部門コード
            stockDetail.CommonSeqNo = histDetail.CommonSeqNo;  // 共通通番
            stockDetail.StockSlipDtlNum = histDetail.StockSlipDtlNum;  // 仕入明細通番
            stockDetail.SupplierFormalSrc = histDetail.SupplierFormalSrc;  // 仕入形式（元）
            stockDetail.StockSlipDtlNumSrc = histDetail.StockSlipDtlNumSrc;  // 仕入明細通番（元）
            stockDetail.AcptAnOdrStatusSync = histDetail.AcptAnOdrStatusSync;  // 受注ステータス（同時）
            stockDetail.SalesSlipDtlNumSync = histDetail.SalesSlipDtlNumSync;  // 売上明細通番（同時）
            stockDetail.StockSlipCdDtl = histDetail.StockSlipCdDtl;  // 仕入伝票区分（明細）
            stockDetail.StockAgentCode = histDetail.StockAgentCode;  // 仕入担当者コード
            stockDetail.StockAgentName = histDetail.StockAgentName;  // 仕入担当者名称
            stockDetail.GoodsKindCode = histDetail.GoodsKindCode;  // 商品属性
            stockDetail.GoodsMakerCd = histDetail.GoodsMakerCd;  // 商品メーカーコード
            stockDetail.MakerName = histDetail.MakerName;  // メーカー名称
            stockDetail.MakerKanaName = histDetail.MakerKanaName;  // メーカーカナ名称
            stockDetail.CmpltMakerKanaName = histDetail.CmpltMakerKanaName;  // メーカーカナ名称（一式）
            stockDetail.GoodsNo = histDetail.GoodsNo;  // 商品番号
            stockDetail.GoodsName = histDetail.GoodsName;  // 商品名称
            stockDetail.GoodsNameKana = histDetail.GoodsNameKana;  // 商品名称カナ
            stockDetail.GoodsLGroup = histDetail.GoodsLGroup;  // 商品大分類コード
            stockDetail.GoodsLGroupName = histDetail.GoodsLGroupName;  // 商品大分類名称
            stockDetail.GoodsMGroup = histDetail.GoodsMGroup;  // 商品中分類コード
            stockDetail.GoodsMGroupName = histDetail.GoodsMGroupName;  // 商品中分類名称
            stockDetail.BLGroupCode = histDetail.BLGroupCode;  // BLグループコード
            stockDetail.BLGroupName = histDetail.BLGroupName;  // BLグループ名称
            stockDetail.BLGoodsCode = histDetail.BLGoodsCode;  // BL商品コード
            stockDetail.BLGoodsFullName = histDetail.BLGoodsFullName;  // BL商品コード名称（全角）
            stockDetail.EnterpriseGanreCode = histDetail.EnterpriseGanreCode;  // 自社分類コード
            stockDetail.EnterpriseGanreName = histDetail.EnterpriseGanreName;  // 自社分類名称
            stockDetail.WarehouseCode = histDetail.WarehouseCode;  // 倉庫コード
            stockDetail.WarehouseName = histDetail.WarehouseName;  // 倉庫名称
            stockDetail.WarehouseShelfNo = histDetail.WarehouseShelfNo;  // 倉庫棚番
            stockDetail.StockOrderDivCd = histDetail.StockOrderDivCd;  // 仕入在庫取寄せ区分
            stockDetail.OpenPriceDiv = histDetail.OpenPriceDiv;  // オープン価格区分
            stockDetail.GoodsRateRank = histDetail.GoodsRateRank;  // 商品掛率ランク
            stockDetail.CustRateGrpCode = histDetail.CustRateGrpCode;  // 得意先掛率グループコード
            stockDetail.SuppRateGrpCode = histDetail.SuppRateGrpCode;  // 仕入先掛率グループコード
            stockDetail.ListPriceTaxExcFl = histDetail.ListPriceTaxExcFl;  // 定価（税抜，浮動）
            stockDetail.ListPriceTaxIncFl = histDetail.ListPriceTaxIncFl;  // 定価（税込，浮動）
            stockDetail.StockRate = histDetail.StockRate;  // 仕入率
            stockDetail.RateSectStckUnPrc = histDetail.RateSectStckUnPrc;  // 掛率設定拠点（仕入単価）
            stockDetail.RateDivStckUnPrc = histDetail.RateDivStckUnPrc;  // 掛率設定区分（仕入単価）
            stockDetail.UnPrcCalcCdStckUnPrc = histDetail.UnPrcCalcCdStckUnPrc;  // 単価算出区分（仕入単価）
            stockDetail.PriceCdStckUnPrc = histDetail.PriceCdStckUnPrc;  // 価格区分（仕入単価）
            stockDetail.StdUnPrcStckUnPrc = histDetail.StdUnPrcStckUnPrc;  // 基準単価（仕入単価）
            stockDetail.FracProcUnitStcUnPrc = histDetail.FracProcUnitStcUnPrc;  // 端数処理単位（仕入単価）
            stockDetail.FracProcStckUnPrc = histDetail.FracProcStckUnPrc;  // 端数処理（仕入単価）
            stockDetail.StockUnitPriceFl = histDetail.StockUnitPriceFl;  // 仕入単価（税抜，浮動）
            stockDetail.StockUnitTaxPriceFl = histDetail.StockUnitTaxPriceFl;  // 仕入単価（税込，浮動）
            stockDetail.StockUnitChngDiv = histDetail.StockUnitChngDiv;  // 仕入単価変更区分
            stockDetail.BfStockUnitPriceFl = histDetail.BfStockUnitPriceFl;  // 変更前仕入単価（浮動）
            stockDetail.BfListPrice = histDetail.BfListPrice;  // 変更前定価
            stockDetail.RateBLGoodsCode = histDetail.RateBLGoodsCode;  // BL商品コード（掛率）
            stockDetail.RateBLGoodsName = histDetail.RateBLGoodsName;  // BL商品コード名称（掛率）
            stockDetail.RateGoodsRateGrpCd = histDetail.RateGoodsRateGrpCd;  // 商品掛率グループコード（掛率）
            stockDetail.RateGoodsRateGrpNm = histDetail.RateGoodsRateGrpNm;  // 商品掛率グループ名称（掛率）
            stockDetail.RateBLGroupCode = histDetail.RateBLGroupCode;  // BLグループコード（掛率）
            stockDetail.RateBLGroupName = histDetail.RateBLGroupName;  // BLグループ名称（掛率）
            stockDetail.StockCount = histDetail.StockCount;  // 仕入数
            stockDetail.StockPriceTaxExc = histDetail.StockPriceTaxExc;  // 仕入金額（税抜き）
            stockDetail.StockPriceTaxInc = histDetail.StockPriceTaxInc;  // 仕入金額（税込み）
            stockDetail.StockGoodsCd = histDetail.StockGoodsCd;  // 仕入商品区分
            stockDetail.StockPriceConsTax = histDetail.StockPriceConsTax;  // 仕入金額消費税額
            stockDetail.TaxationCode = histDetail.TaxationCode;  // 課税区分
            stockDetail.StockDtiSlipNote1 = histDetail.StockDtiSlipNote1;  // 仕入伝票明細備考1
            stockDetail.SalesCustomerCode = histDetail.SalesCustomerCode;  // 販売先コード
            stockDetail.SalesCustomerSnm = histDetail.SalesCustomerSnm;  // 販売先略称
            stockDetail.OrderNumber = histDetail.OrderNumber;  // 発注番号
            stockDetail.SlipMemo1 = histDetail.SlipMemo1;  // 伝票メモ１
            stockDetail.SlipMemo2 = histDetail.SlipMemo2;  // 伝票メモ２
            stockDetail.SlipMemo3 = histDetail.SlipMemo3;  // 伝票メモ３
            stockDetail.InsideMemo1 = histDetail.InsideMemo1;  // 社内メモ１
            stockDetail.InsideMemo2 = histDetail.InsideMemo2;  // 社内メモ２
            stockDetail.InsideMemo3 = histDetail.InsideMemo3;  // 社内メモ３
            # endregion
            return stockDetail;
        }
        /// <summary>
        /// 仕入履歴明細リスト→仕入明細リスト
        /// </summary>
        /// <param name="stockHisDtlList"></param>
        /// <returns></returns>
        private ArrayList CopyToStockDetailListFromStockHistDtlList( ArrayList histDetailList )
        {
            ArrayList retList = new ArrayList();

            foreach ( StockSlHistDtlWork histDetail in histDetailList )
            {
                retList.Add( CopyToStockDetailFromStockHistDtl( histDetail ) );
            }

            return retList;
        }
        # endregion

        # region [IOWriterからコピーした共通処理]
        /// <summary>
        /// SQLコネクション生成
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private SqlConnection CreateSqlConnection( bool p )
        {
            //コネクション生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
            if ( connectionText == null || connectionText == "" ) return null;

            //SQL文生成
            SqlConnection sqlConnection = new SqlConnection( connectionText );
            sqlConnection.Open();

            return sqlConnection;
        }
        /// <summary>
        /// パラメータ位置取得
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <param name="type">取得タイプ</param>
        /// <param name="pattern">パラメータパターン：0クラス 1:Array</param>
        /// <returns>パラメータ位置:無い場合は-1</returns>
        private int MakePosition( CustomSerializeArrayList paramArray, Type type, Int32 pattern )
        {
            int result = -1;

            //パラメータを取得
            if ( pattern == 0 )
            {
                for ( int i = 0; i < paramArray.Count; i++ )
                {
                    if ( paramArray[i] != null && paramArray[i].GetType() == type )
                    {
                        result = i;
                        break;
                    }
                }
            }
            else
            {
                for ( int i = 0; i < paramArray.Count; i++ )
                {
                    if ( paramArray[i] is ArrayList )
                    {
                        ArrayList al = paramArray[i] as ArrayList;
                        if ( al != null && al.Count > 0 )
                        {
                            if ( al[0] != null && al[0].GetType() == type )
                            {
                                result = i;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Read用主軸パラメータ生成
        /// </summary>
        /// <param name="paramArray">受け取りパラメータList</param>
        /// <returns>STATUS</returns>
        /// <returns>
        /// <br>Update Note: 2022/05/05 仰亮亮</br>
        /// <br>管理番号   : 11870080-00</br>
        /// <br>           : 納品書電子帳簿連携対応</br>
        /// </returns>
        //private int MakeReadFunctionParam( ref CustomSerializeArrayList paramArray )
        private int MakeReadFunctionParam( ref ArrayList paramArray )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //とりあえず売上ヘッダワークを売上伝票パラメータとして生成する
            //売上以外の処理が追加されたらRead用パラメータクラスを生成する
            foreach ( object obj in paramArray )
            {
                IOWriteMAHNBReadWork readWork = obj as IOWriteMAHNBReadWork;

                if ( readWork != null )
                {
                    //Readパラメータを生成
                    //Readパラメータは他処理の検索キー全てとする
                    SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();

                    salesSlipReadWork.EnterpriseCode = readWork.EnterpriseCode;
                    salesSlipReadWork.AcptAnOdrStatus = readWork.AcptAnOdrStatus;
                    salesSlipReadWork.SalesSlipNum = readWork.SalesSlipNum;
                    salesSlipReadWork.DebitNoteDiv = readWork.DebitNoteDiv;
                    salesSlipReadWork.SalesSlipCd = readWork.SalesSlipCd;
                    salesSlipReadWork.SalesGoodsCd = readWork.SalesGoodsCd;
                    // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>
                    salesSlipReadWork.LogicalDeleteCodeFlg = readWork.LogicalDeleteCodeFlg;
                    // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

                    paramArray.Add( salesSlipReadWork );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }
        # endregion
        # endregion

        # region [伝票パラメータリスト操作処理]
        /// <summary>
        /// List ユーティリティクラス
        /// </summary>
        private class SlipListUtils : ListUtils
        {
            /*
            /// <summary>検索パターン Find() で使用</summary>
            public enum FindType
            {
                /// <summary>クラス</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }
            */
            /// <summary>検索対象項目 FindSlipDetail() で使用</summary>
            public enum FindItem
            {
                /// <summary>通常</summary>
                Normal,
                /// <summary>計上元</summary>
                Source,
                /// <summary>同時計上</summary>
                Synchronize,
                /// <summary>UOE発注</summary>
                UoeOrder
                # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
            /// <summary>売上一時</summary>
            SalesTemp
#endif
                # endregion
            }

            /// <summary>
            /// パラメータに指定されたクラスに応じた伝票タイプを取得します。
            /// </summary>
            /// <returns>SlipType</returns>
            public static SlipType GetSlipType( object obj )
            {
                SlipType result = SlipType.None;

                if ( obj is ArrayList )
                {
                    ArrayList slips = obj as ArrayList;

                    if ( SlipListUtils.IsNotEmpty( slips ) )
                    {
                        object findObj = null;

                        // 売上明細データを検索する
                        findObj = SlipListUtils.Find( slips, typeof( SalesDetailWork ), FindType.Array );

# if false
                        if ( findObj == null )
                        {
                            // 仕入明細データを検索する(明細で検索するのは発注データが含まれるため)
                            findObj = SlipListUtils.Find( slips, typeof( StockDetailWork ), FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // UOE発注明細データを検索する
                            findObj = SlipListUtils.Find( slips, typeof( UOEOrderDtlWork ), FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // 仕入削除パラメータ
                            findObj = SlipListUtils.Find( slips, typeof( IOWriteMASIRDeleteWork ), FindType.Class );
                        }

                        if ( findObj == null )
                        {
                            // 売上削除パラメータ
                            findObj = SlipListUtils.Find( slips, typeof( IOWriteMAHNBDeleteWork ), FindType.Class );
                        }
                        if ( findObj == null )
                        {
                            // 在庫調整データ
                            // 2009/02/26 買掛無しオプション対応>>>>>>>>>>>>>>>
                            //// 2009/02/10 >>>>>>>>
                            ////findObj = SlipListUtils.Find(slips, typeof(StockAdjustWork), FindType.Array); //DEL
                            ////在庫調整明細データクラスのリストを取得するように修正
                            //findObj = SlipListUtils.Find(slips, typeof(StockAdjustDtlWork), FindType.Array); //ADD
                            //// 2009/02/10 <<<<<<<<

                            ArrayList adjustcs = slips[0] as ArrayList;
                            findObj = SlipListUtils.Find( adjustcs, typeof( StockAdjustDtlWork ), FindType.Array ); //ADD

                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
# endif


                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
#if false
                if (findObj == null)
                {
                    // 売上一時データを検索する
                    findObj = SlipListUtils.Find(slips, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                }
#endif
                        # endregion

                        if ( SlipListUtils.IsNotEmpty( findObj as ArrayList ) )
                        {
                            findObj = (findObj as ArrayList)[0];
                        }

                        if ( findObj is SalesDetailWork )
                        {
                            switch ( (findObj as SalesDetailWork).AcptAnOdrStatus )
                            {
                                case (int)SlipType.Estimation:     // 見積
                                    result = SlipType.Estimation;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // 受注
                                    result = SlipType.AcceptAnOrder;
                                    break;
                                case (int)SlipType.Shipment:       // 出荷
                                    result = SlipType.Shipment;
                                    break;
                                case (int)SlipType.Sales:          // 売上
                                    result = SlipType.Sales;
                                    break;
                            }
                        }
# if false
                        else if ( findObj is StockDetailWork )
                        {
                            switch ( (findObj as StockDetailWork).SupplierFormal )
                            {
                                case (int)SlipType.Order:     // 発注
                                    result = SlipType.Order;
                                    break;
                                case (int)SlipType.Arrival:   // 入荷
                                    result = SlipType.Arrival;
                                    break;
                                case (int)SlipType.Purchase:  // 仕入
                                    result = SlipType.Purchase;
                                    break;
                            }
                        }
                        else if ( findObj is UOEOrderDtlWork )
                        {
                            result = SlipType.UoeOrder;  // UOE発注
                        }
                        else if ( findObj is StockAdjustDtlWork )
                        {
                            result = SlipType.StockAdjust;  // 在庫調整
                        }
# endif
                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    result = SlipType.SalesTemp;
                        //}
                        # endregion
                    }
                }
                else if ( obj is IOWriteMAHNBDeleteWork )
                {
                    result = SlipType.SalesDel;  // 売上削除
                }
                else if ( obj is IOWriteMASIRDeleteWork )
                {
                    result = SlipType.PurchaseDel;  // 仕入削除
                }

                return result;
            }


            /// <summary>
            /// 伝票タイプとGUIDが合致する明細データを取得します。
            /// </summary>
            /// <param name="sliplist">検索対象リスト</param>
            /// <param name="finditem">検索対象項目</param>
            /// <param name="sliptype">伝票タイプ</param>
            /// <param name="guid">明細GUID</param>
            /// <param name="source">検索元明細データ</param>
            /// <returns>オブジェクト</returns>
            public static object FindSlipDetail( ArrayList sliplist, FindItem finditem, SlipType sliptype, Guid guid, object source )
            {
                object retdtil = null;

                foreach ( object item in sliplist )
                {
                    if ( item is ArrayList )
                    {
                        // 再帰検索を行う
                        retdtil = SlipListUtils.FindSlipDetail( item as ArrayList, finditem, sliptype, guid, source );
                    }
                    else
                    {
                        // 検索元の明細データと異なる場合にのみチェックする
                        if ( item != source )
                        {
                            switch ( finditem )
                            {
                                case FindItem.Normal:
                                    {
                                        # region [受注ステータス or 仕入形式を検索対象とする]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // 受注ステータスとGUIDをチェックする
                                                        if ( (item as SalesDetailWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# if false
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // 仕入形式とGUIDをチェックする
                                                        if ( (item as StockDetailWork).SupplierFormal == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# endif
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Source:
                                    {
                                        # region [受注ステータス(計上元) or 仕入形式(計上元)を検索対象とする]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // 受注ステータス(計上元)とGUIDをチェックする
                                                        if ( (item as SalesDetailWork).AcptAnOdrStatusSrc == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# if false
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // 仕入形式(計上元)とGUIDをチェックする
                                                        if ( (item as StockDetailWork).SupplierFormalSrc == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
# endif
                                        }
                                        # endregion
                                        break;
                                    }
# if false
                                case FindItem.Synchronize:
                                    {
                                # region [受注ステータス(同時) or 仕入形式(同時)を検索対象とする]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if ( item is StockDetailWork )
                                                    {
                                                        // 受注ステータス(同時)とGUIDをチェックする
                                                        if ( (item as StockDetailWork).AcptAnOdrStatusSync == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if ( item is SalesDetailWork )
                                                    {
                                                        // 仕入形式(同時)とGUIDをチェックする
                                                        if ( (item as SalesDetailWork).SupplierFormalSync == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.UoeOrder:
                                    {
                                #region [受注ステータス or 仕入形式を検索対象とする]
                                        switch ( sliptype )
                                        {
                                            case SlipType.Estimation:     // 見積
                                            case SlipType.AcceptAnOrder:  // 受注
                                            case SlipType.Shipment:       // 出荷
                                            case SlipType.Sales:          // 売上
                                                {
                                                    if ( item is UOEOrderDtlWork )
                                                    {
                                                        // 受注ステータスとGUIDをチェックする
                                                        if ( (item as UOEOrderDtlWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // 発注
                                            case SlipType.Arrival:        // 入荷
                                            case SlipType.Purchase:       // 仕入
                                                {
                                                    if ( item is UOEOrderDtlWork )
                                                    {
                                                        // 仕入形式とGUIDをチェックする
                                                        if ( (item as UOEOrderDtlWork).SupplierFormal == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid )
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
# endif
                                # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                                //case FindItem.SalesTemp:
                                //    {
                                //    # region [売上一時データを検索対象とする]
                                //        switch (sliptype)
                                //        {
                                //            case SlipType.Order:          // 発注
                                //            case SlipType.Arrival:        // 入荷
                                //            case SlipType.Purchase:       // 仕入
                                //                {
                                //                    if (item is SalesTempWork)
                                //                    {
                                //                        // GUIDをチェックする
                                //                        if ((item as SalesTempWork).DtlRelationGuid == guid)
                                //                        {
                                //                            retdtil = item;
                                //                        }
                                //                    }
                                //                    break;
                                //                }
                                //        }
                                //        # endregion
                                //        break;
                                //    }
                                # endregion
                            }
                        }
                    }

                    // 最初に見つけたデータを返す
                    if ( retdtil != null )
                    {
                        break;
                    }
                }

                return retdtil;
            }
        }

        /// <summary>
        /// 伝票タイプ
        /// </summary>
        internal enum SlipType : int
        {
            /// <summary>未指定</summary>
            None = -1,
            /// <summary>見積</summary>
            Estimation = 10,
            /// <summary>受注</summary>
            AcceptAnOrder = 20,
            /// <summary>出荷</summary>
            Shipment = 40,
            /// <summary>売上</summary>
            Sales = 30,
            /// <summary>発注</summary>
            Order = 2,
            /// <summary>入荷</summary>
            Arrival = 1,
            /// <summary>仕入</summary>
            Purchase = 0,
            /// <summary>UOE発注</summary>
            UoeOrder = 98,
            /// <summary>売上削除</summary>
            SalesDel = 100,
            /// <summary>仕入削除</summary>
            PurchaseDel = 101,
            /// <summary>在庫調整</summary>
            StockAdjust = 102
            #region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
            ///// <summary>売上一時(仕入売上同時計上)</summary>            
            //SalesTemp = 99
            #endregion
        }

        /// <summary>
        /// 伝票形式でソートを行う
        /// </summary>
        internal class SlipTypeComparer : IComparer
        {
            /// <summary>
            /// 伝票並替タイプ
            /// </summary>
            public enum SlipSortType
            {
                /// <summary>売上</summary>
                Sales,
                /// <summary>仕入</summary>
                Purchase
            }

            public SlipSortType SortType = SlipSortType.Sales;

            /// <summary>
            /// 仕入を基準に伝票形式でソートを行う
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare( object x, object y )
            {
                # region [DELETE]
                // SortType が SlipSortType.Sales(売上) の場合は
                // 0:制御オプション＜1:見積＜2:受注＜3:出荷＜4:売上＜5:発注(＋6:UOE発注)＜7:入荷＜8:仕入＜9:売上一時 の順に並び変える

                // SortType が SlipSortType.Purchase(仕入) の場合は
                // 0:制御オプション＜5:発注(＋6:UOE発注)＜7:入荷＜8:仕入＜9:売上一時＜11:見積＜12:受注＜13:出荷＜14:売上 の順に並び変える
                # endregion

                // SortType が SlipSortType.Sales(売上) の場合は
                // 0:制御オプション＜1:仕入削除＜2:見積＜3:受注＜4:出荷＜5:売上＜6:売上削除＜7:発注(＋8:UOE発注)＜9:入荷＜10:仕入＜11:在庫調整＜12:売上一時 の順に並び変える

                // SortType が SlipSortType.Purchase(仕入) の場合は
                // 0:制御オプション＜6:売上削除＜7:発注(＋8:UOE発注)＜9:入荷＜10:仕入＜11:在庫調整＜12:売上一時＜21:仕入削除＜22:見積＜23:受注＜24:出荷＜25:売上 の順に並び変える

                int xValue = 0;
                int yValue = 0;
                int zValue = int.MaxValue;

                int xSlipDtlRegOrder = 0;
                int ySlipDtlRegOrder = 0;
                int zSlipDtlRegOrder = 0;

                const int orderWeight = 20;  // 売上⇔仕入で変わる並び順の重みを指定

                object Z = null;

                for ( int i = 0; i < 2; i++ )
                {
                    Z = (i == 0) ? x : y;

                    if ( Z is IOWriteCtrlOptWork )
                    {
                        // 制御オプションは常に先頭とする
                        zValue = 0;
                    }
                    else if ( Z is IOWriteMASIRDeleteWork )
                    {
                        # region [仕入削除パラメータ]

                        // 仕入削除パラメータ
                        zValue = 1;

                        // 並替タイプに応じて重みを設ける
                        zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                        // 仕入削除パラメータが複数登録されている場合は、仕入形式の逆順(先:仕入→入荷→発注:後)の順に並べる
                        zSlipDtlRegOrder = 2 - (Z as IOWriteMASIRDeleteWork).SupplierFormal;

                        # endregion
                    }
                    else if ( Z is IOWriteMAHNBDeleteWork )
                    {
                        # region [売上削除パラメータ]

                        // 売上削除パラメータ
                        zValue = 6;

                        // 売上削除パラメータが複数登録されている場合は、受注ステータスの逆順(先:出荷→売上→受注→見積:後)順に並べる
                        zSlipDtlRegOrder = 40 - (Z as IOWriteMAHNBDeleteWork).AcptAnOdrStatus;

                        # endregion
                    }
                    else if ( Z is ArrayList )
                    {
                        object findObj = null;
                        ArrayList zList = Z as ArrayList;

                        # region [処理対象の抽出]
                        // 売上明細データを検索する
                        findObj = SlipListUtils.Find( zList, typeof( SalesDetailWork ), SlipListUtils.FindType.Array );

# if false
                        if ( findObj == null )
                        {
                            // 仕入明細データを検索する(明細で検索するのは発注データが含まれるため)
                            findObj = SlipListUtils.Find( zList, typeof( StockDetailWork ), SlipListUtils.FindType.Array );
                        }
                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //if (findObj == null)
                        //{
                        //    // 売上一時データを検索する
                        //    findObj = SlipListUtils.Find(zList, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                        //}
                        # endregion

                        if ( findObj == null )
                        {
                            // UOE発注明細データを検索する
                            findObj = SlipListUtils.Find( zList, typeof( UOEOrderDtlWork ), SlipListUtils.FindType.Array );
                        }

                        if ( findObj == null )
                        {
                            // 2009/02/26 買掛無しオプション対応 >>>>>>>>>>>>>>>
                            // 在庫調整
                            //findObj = SlipListUtils.Find(zList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);

                            ArrayList adjustList = zList[0] as ArrayList;
                            findObj = SlipListUtils.Find( adjustList, typeof( StockAdjustWork ), SlipListUtils.FindType.Array );
                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
# endif

                        if ( findObj is ArrayList && SlipListUtils.IsNotEmpty( findObj as ArrayList ) )
                        {
                            Z = (findObj as ArrayList)[0];
                        }

                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    Z = findObj;
                        //}
                        # endregion
                        # endregion

                        # region [処理対象に基づいた重みの設定]

                        if ( Z is SalesDetailWork )
                        {
                            # region [売上明細データ]

                            switch ( (Z as SalesDetailWork).AcptAnOdrStatus )
                            {
                                case (int)SlipType.Estimation:     // 見積
                                    zValue = 2;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // 受注
                                    zValue = 3;
                                    break;
                                case (int)SlipType.Shipment:       // 出荷
                                    zValue = 4;
                                    break;
                                case (int)SlipType.Sales:          // 売上
                                    zValue = 5;
                                    break;
                            }

                            // 並替タイプに応じて重みを設ける
                            zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                            // 同一受注ステータスの伝票を比較する際に、伝票明細登録順位を比較項目とする
                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
# if false
                        else if ( Z is StockDetailWork )
                        {
                        # region [仕入明細データ]

                            switch ( (Z as StockDetailWork).SupplierFormal )
                            {
                                case (int)SlipType.Order:     // 発注
                                    zValue = 7;
                                    break;
                                case (int)SlipType.Arrival:   // 入荷
                                    zValue = 9;
                                    break;
                                case (int)SlipType.Purchase:  // 仕入
                                    zValue = 10;
                                    break;
                            }

                            // 並替タイプに応じて重みを設ける
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            // 同一仕入形式の伝票を比較する際に、伝票明細登録順位を比較項目とする
                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if ( Z is UOEOrderDtlWork )
                        {
                        # region [UOE発注データ]

                            // UOE発注
                            zValue = 8;

                            // 並替タイプに応じて重みを設ける
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            ArrayList SlpDtlAddInfList = ListUtils.Find( zList, typeof( SlipDetailAddInfoWork ), ListUtils.FindType.Array ) as ArrayList;

                            if ( ListUtils.IsNotEmpty( SlpDtlAddInfList ) )
                            {
                                SlpDtlAddInfList.Sort( new SlipDetailAddInfoRegOrderComparer() );
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }
                            else
                            {
                                zSlipDtlRegOrder = 0;
                            }

                            # endregion
                        }
                        else if ( Z is StockAdjustWork )
                        {
                        # region [在庫調整データ]
                            zValue = 11;
                            zSlipDtlRegOrder = 0;
                            # endregion
                        }

                        # region [2008/06/05 M.Kubota --- PM.NSにおける仕入売上同時計上の仕様が未定なので凍結する]
                        //else if (Z is SalesTempWork)  // 売上一時データ
                        //{
                        //    zValue = 9;

                        //    // 並替タイプに応じて重みを設ける
                        //    zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;
                        //}
                        # endregion
# endif
                        # endregion

                    }

                    if ( i == 0 )
                    {
                        xValue = zValue;
                        xSlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                    else
                    {
                        yValue = zValue;
                        ySlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                }

                // 受注ステータス or 仕入形式 で比較
                int compret = xValue.CompareTo( yValue );

                if ( compret == 0 )
                {
                    // 伝票明細登録順位で比較
                    compret = xSlipDtlRegOrder.CompareTo( ySlipDtlRegOrder );
                }

                return compret;
            }
        }
        # endregion

        # region [売上・仕入制御オプション]
        /// <summary>
        /// 売上・仕入制御オプション
        /// </summary>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// 売上・仕入制御オプション プロパティ
        /// </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                //this._ResourceName = this.GetResourceName( this._CtrlOptWork.EnterpriseCode );
            }
        }
        # endregion

        # region [伝票書き込み（IOWriterを使用）]
        /// <summary>
        /// 伝票書き込み処理（IOWriterを使用）
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <returns></returns>
        public int WriteByIOWriter( ref object paraList, out string retMsg, out string retItemInfo )
        {
            IOWriteControlDB iOWriteControlDB = new IOWriteControlDB();
            return iOWriteControlDB.Write( ref paraList, out retMsg, out retItemInfo );
        }
        # endregion

        # region [相手先伝票番号による仕入データ検索]
        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="retStockSlipList">検索結果を格納する CustomSerializeArrayList を指定します。</param>
        /// <param name="paraStockSlip">検索条件を格納した StockSlip を指定します。</param>
        /// <param name="mode">0:完全一致 1:前方一致 2:完全一致＋仕入明細取得</param>
        /// <returns>STATUS</returns>
        public int SearchPartySaleSlipNum( ref object retStockSlipList, object paraStockSlip, int mode )
        {
            // ※同時仕入伝票の赤伝処理で使用するため、履歴分は対象外のまま
            _stockSlipDB = new StockSlipDB();
            return _stockSlipDB.SearchPartySaleSlipNum( ref retStockSlipList, paraStockSlip, mode );
        }
        # endregion

        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        // --- ADD 2012/12/17 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// サーバーシステム日付取得を戻します		
        /// </summary>
        public DateTime GetServerNowTime()
        {
            return DateTime.Now;
        }
        // --- ADD 2012/12/17 T.Miyamoto ------------------------------<<<<<

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>
        /// 売上日が指定されない場合、DBから開始・終了売上日を検索する
        /// </summary>
        /// <param name="salesDateSt">開始売上日</param>
        /// <param name="salesDateEd">終了売上日</param>
        /// <param name="custPrtPprParam">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 売上日が指定されない場合、DBから開始・終了売上日を検索する</br>
        /// <br>Programmer  : 王亜楠</br>
        /// <br>Date        : 2015/02/05</br>
        /// </remarks>
        public int GetSalesDate(out DateTime salesDateSt, out DateTime salesDateEd, object custPrtPprParam, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesDateSt = DateTime.MinValue;
            salesDateEd = DateTime.MinValue;
            SqlConnection sqlConnection = null;

            try
            {
                //パラメータチェック
                if (custPrtPprParam == null) return status;

                //検索パラメータ
                CustPrtPprWork custPrtPprWork = custPrtPprParam as CustPrtPprWork;

                //コネクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                DateTime st_salesDate;
                DateTime ed_salesDate;

                // 開始売上日≠NULL、終了売上日＝NULL
                if (custPrtPprWork.St_SalesDate != DateTime.MinValue && custPrtPprWork.Ed_SalesDate == DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 1;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out ed_salesDate, ref sqlConnection);

                    salesDateSt = custPrtPprWork.St_SalesDate;
                    salesDateEd = ed_salesDate;
                }
                // 開始売上日＝NULL、終了売上日≠NULL
                else if (custPrtPprWork.St_SalesDate == DateTime.MinValue && custPrtPprWork.Ed_SalesDate != DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 0;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out st_salesDate, ref sqlConnection);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDateSt = st_salesDate;
                        salesDateEd = custPrtPprWork.Ed_SalesDate;
                    }
                }
                // 開始売上日＝NULL、終了売上日＝NULL
                else if (custPrtPprWork.St_SalesDate == DateTime.MinValue && custPrtPprWork.Ed_SalesDate == DateTime.MinValue)
                {
                    custPrtPprWork.SearchSalDateStEd = 0;
                    status = GetSalesDateProc(custPrtPprWork, logicalMode, out st_salesDate, ref sqlConnection);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDateSt = st_salesDate;

                        custPrtPprWork.SearchSalDateStEd = 1;
                        status = GetSalesDateProc(custPrtPprWork, logicalMode, out ed_salesDate, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            salesDateEd = ed_salesDate;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.GetSalesDate Exception=" + ex.Message);
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

        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ---------->>>>>
        /// <summary>
        /// 売上データ・入金データから日付を検索する
        /// </summary>
        /// <param name="custPrtPprWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="salesDate">売上日</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 売上データ・入金データから日付を検索する</br>
        /// <br>Programmer  : 王亜楠</br>
        /// <br>Date        : 2015/03/03</br>
        /// </remarks>
        private int GetSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            salesDate = DateTime.MinValue;
            DateTime searchStockDate = DateTime.MinValue;

            try
            {
                // 売上データから日付の検索
                if (CheckSelectSales(custPrtPprWork))
                {
                    custPrtPprWork.SearchSalDateType = 0; // 売上データから日付を検索
                    status = SearchSalesDateProc(custPrtPprWork, logicalMode, out searchStockDate, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        salesDate = searchStockDate;
                    }
                }

                // 入金データから日付の検索
                if (CheckSelectDeposit(custPrtPprWork))
                {
                    custPrtPprWork.SearchSalDateType = 1; // 入金データから日付を検索
                    status = SearchSalesDateProc(custPrtPprWork, logicalMode, out searchStockDate, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (custPrtPprWork.SearchSalDateStEd == 0)
                        {
                            if (salesDate == DateTime.MinValue || searchStockDate < salesDate)
                            {
                                salesDate = searchStockDate;
                            }
                        }
                        else
                        {
                            if (searchStockDate > salesDate)
                            {
                                salesDate = searchStockDate;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.GetSalesDateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ----------<<<<<

        /// <summary>
        /// 売上日が指定されない場合、DBから開始・終了売上日を検索する
        /// </summary>
        /// <param name="custPrtPprWork">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="salesDate">売上日</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 売上日が指定されない場合、DBから開始・終了売上日を検索する</br>
        /// <br>Programmer  : 王亜楠</br>
        /// <br>Date        : 2015/02/05</br>
        /// <br>UpdateNote  : 2015/03/03 王亜楠 Redmine#44701</br>
        /// <br>            : 入金データから入金日を検索する</br>
        /// </remarks>
        //private int GetSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection) // DEL 2015/03/03 王亜楠 Redmine#44701 #36
        private int SearchSalesDateProc(CustPrtPprWork custPrtPprWork, ConstantManagement.LogicalMode logicalMode, out DateTime salesDate, ref SqlConnection sqlConnection) // ADD 2015/03/03 王亜楠 Redmine#44701 #36
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesDate = DateTime.MinValue;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ICustPrtPpr custPrtPpr;
            custPrtPpr = new CustPrtPprSalTblRsltQuery();

            try
            {
                int iType = (int)iSrcType.SalDate;
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT文生成
                sqlCommand.CommandText = custPrtPpr.MakeSelectString(ref sqlCommand, custPrtPprWork, iType, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //取得結果セット
                    object retWork = custPrtPpr.CopyToResultWorkFromReader(ref myReader, custPrtPprWork, iType);
                    if (retWork != null)
                    {
                        CustPrtPprSalTblRsltWork work = (CustPrtPprSalTblRsltWork)retWork;
                        salesDate = work.SalesDate;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustPrtPprWorkDB.SearchSalesDateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
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

            return status;
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
    }

    interface ICustPrtPpr
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam);
    }

    // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
    interface ICustPrtPprOutput
    {
        string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iParam, bool CreditMng, ConstantManagement.LogicalMode logicalMode);
        object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam, bool CreditMng);
    }
    // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

    /// <summary>
    /// 伝票・明細の検索タイプを列挙します。
    /// </summary>
    enum iSrcType
    {
        SalTbl = 0,  //売上データ検索
        DepTbl = 1,  //入金データ検索
        BlDsp = 2,   //残高照会検索
        BlTbl = 3,   //残高一覧検索
        // -- DEL 2009/09/04 --------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //SalHisTbl = 4, // 売上履歴データ検索
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------<<<
        SalDate = 4, // テキスト出力用売上日の検索 // ADD 2015/02/05 王亜楠
    }

    /// <summary>
    /// 残高一覧の検索タイプを列挙します。
    /// </summary>
    enum iSrchKndDiv
    {
        CustDmd = 0,  //得意先請求金額マスタ
        CustAcc = 1,  //得意先売掛金額マスタ
    }

    /// <summary>
    /// 伝票検索区分を列挙します。
    /// </summary>
    enum SearchType
    {
        All = 0,  //0:全て
        Sal = 1,  //1:売上のみ
        Dep = 2,  //2:入金のみ
    }
}