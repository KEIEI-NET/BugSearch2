using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Microsoft.VisualBasic.Devices;// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
using System.Xml;// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫移動DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.01.19</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.04 長内 DC.NS用に修正</br>
    /// <br>Update Note: 2009/11/25 長内 MANTS対応 14328</br>
    /// <br>Update Note: 2010/06/11 長内 入荷取消時の不具合対応</br>
    /// <br>Update Note: 2010/06/15 長内</br>
    /// <br>             ①在庫自動登録時の不具合修正</br>
    /// <br>             ②出荷伝票更新時の不具合修正</br>
    /// <br>Update Note: 2010/06/16 長内</br>
    /// <br>             入荷取消時の入荷伝票を論理削除ではなく、物理削除するように修正</br>
    /// <br>Update Note: 2010/11/15 曹文傑</br>
    /// <br>             障害改良対応ｘ月「２」の対応</br>
    /// /// <br>Update Note: 2011/08/24  連番980 梁森東</br>
    /// <br>            : REDMINE#23417の対応</br>
    /// <br>Update Note: 2011/08/11 孫東響 SCM対応-拠点管理（10704767-00）</br>
    /// <br>             在庫移動データ受信時に在庫マスタの更新を行う</br>
    /// <br>Update Note: 2011/08/24 孫東響 #23964</br>
    /// <br>             MAZAI04124Rソースレビュー結果①修正</br>
    /// <br>Update Note: 2011/08/29 孫東響 </br>
    /// <br>             在庫データがゼロ場合、在庫データ更新しないに修正</br>
    /// <br>Update Note: 2011/09/02 孫東響 #24259</br>
    /// <br>             ①「値がセットされていない」修正</br>
    /// <br>             ②「在庫受払データが作成されない。」修正</br>
    /// <br>Update Note: 2011/09/05 孫東響 </br>
    /// <br>             ①#24187受信側の拠点に対象のマスタが登録されていない場合の不具合について</br>
    /// <br>             ②#24241在庫受払履歴データの数量の更新について</br>
    /// <br>Update Note: 2012/05/22 wangf </br>
    /// <br>　　　　   : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
    /// <br>Update Note: 2012/07/05 三戸 伸悟 </br>
    /// <br>　　　　   : 10801804-00 移動時在庫自動登録区分による制御を追加</br>
    /// <br>Update Note: 2012/07/10 三戸 伸悟 </br>
    /// <br>　　　　   : 入庫確定時に在庫データだけ発生する障害対応</br>
    /// <br>Update Note: 2012/10/02 脇田 靖之 </br>
    /// <br>　　　　   : 「移動時在庫自動登録区分」が”しない”の場合でも在庫更新するように修正</br>
    /// <br>Update Note: K2013/12/10 wangl2</br>
    /// <br>管理番号   : 10970522-00</br>
    /// <br>             フタバ個別拠点間発注処理することの対応</br>
    /// <br>Update Note: K2013/12/25 鄧潘ハン</br>
    /// <br>管理番号   : 10970522-00</br>
    /// <br>             フタバ個別拠点間発注ﾃﾞｰﾀより、入庫ﾃﾞｰﾀの作成することの対応</br>
    /// <br>管理番号   : 11200041-00</br>
    /// <br>Update Note: 2016/04/26 周健</br>
    /// <br>             Redmine#48729 在庫移動入力の入荷取消障害の対応</br>
    /// <br>Update Note: 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発の対応</br>
    /// <br>Update Note: K2019/02/27 譚洪</br>
    /// <br>             Redmine#49811 コーエイ（個別）移動伝票入力入荷確定処理　オーバーフローの対応</br>
    /// <br>Update Note: K2020/03/25 陳艶丹</br>
    /// <br>管理番号   : 11600006-00 PMKOBETSU-3622対応</br>
    /// <br>             UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
    /// <br>Update Note: K2021/02/02 呉元嘯</br>
    /// <br>管理番号   : 11601223-00 PMKOBETSU-4114対応</br>
    /// <br>             入荷処理ログ追加対応</br>
    /// <br>Update Note: 2021/08/25 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : BLINCIDENT-2462 現在個数と繰越数が合わない対応</br>
    /// </remarks>
    [Serializable]
    public class StockMoveDB : RemoteWithAppLockDB, IStockMoveDB
    {
        private StockDB _stockDB = new StockDB();
        private StockMngTtlStDB _stockMngTtlStDB = new StockMngTtlStDB();       //在庫管理全体設定
        private SecInfoSetDB _secInfoDB = new SecInfoSetDB();
        private Hashtable secInfoSetWorkHash = new Hashtable();
        private UsrJoinPartsSearchDB _usrJoinPartsSearchDB = new UsrJoinPartsSearchDB();
        private bool _isRecv = false;//ADD 2011/09/02 孫東響 #24259
        // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
        // CLCログ出力区分
        private bool ClcLogOutDiv = false;
        // サーバーログ出力区分
        private bool ServerLogOutDiv = false;
        // 初回実行チェック
        private bool FirstFlg = true;
        // 在庫移動ログ出力可否制御ファイル
        private string StockMoveLogOutCheckEnablerFileNm = "StockMoveLogOutCheckEnabler.xml";
        // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
        private enum ct_ProcMode
        {
            Write = 0,
            Delete = 1
        }


        // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion
        // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>検品データ DBリモートオブジェクト</summary>
        private InspectDataDB HandyInspectDataDB = null;

        /// <summary>
        /// 検品データ DBリモートプロパティ
        /// </summary>
        private InspectDataDB InspectDataObj
        {
            get
            {
                if (this.HandyInspectDataDB == null)
                {
                    // 検品データ DBリモートを生成
                    this.HandyInspectDataDB = new InspectDataDB();
                }

                return this.HandyInspectDataDB;
            }
        }
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        /// <summary>
        /// 在庫移動DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号   : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        /// </remarks>
        public StockMoveDB()
            :
            base("MAZAI04126D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork", "STOCKMOVERF")
        {
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
            // 初回実行時の場合
            if (FirstFlg)
            {
                GetXml();
            }
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫移動情報LISTを戻します
        /// </summary>
        /// <param name="stockMoveWork">検索結果</param>
        /// <param name="parastockMoveWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int Search(out object stockMoveWork, object parastockMoveWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockMoveWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMoveProc(out stockMoveWork, parastockMoveWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Search");
                stockMoveWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の在庫移動情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objstockMoveWork">検索結果</param>
        /// <param name="parastockMoveWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchStockMoveProc(out object objstockMoveWork, object parastockMoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StockMoveSlipSearchCondWork stockmovepara = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            ArrayList stockmoveWorkList = null;
            SqlTransaction sqlTransaction = null;
            stockmovepara = parastockMoveWork as StockMoveSlipSearchCondWork;

            int status = SearchStockMoveProc(out stockmoveWorkList, stockmovepara, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

            retList.Add(stockmoveWorkList);
            objstockMoveWork = retList;
            return status;
        }

        /// <summary>
        /// 指定された条件の在庫移動情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmoveWorkList">検索結果</param>
        /// <param name="stockmoveWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int SearchStockMoveProc(out ArrayList stockmoveWorkList, StockMoveSlipSearchCondWork stockmoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchStockMoveProcProc(out stockmoveWorkList, stockmoveWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の在庫移動情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmoveWorkList">検索結果</param>
        /// <param name="stockmoveWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        private int SearchStockMoveProcProc(out ArrayList stockmoveWorkList, StockMoveSlipSearchCondWork stockmoveWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockmoveWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockMoveWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockmoveWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫移動を戻します
        /// </summary>
        /// <param name="parabyte">StockMoveWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動を戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                StockMoveWork stockmoveWork = new StockMoveWork();

                // XMLの読み込み
                stockmoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockMoveWork));
                if (stockmoveWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockmoveWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(stockmoveWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Read");
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

        /// <summary>
        /// 指定された条件の在庫移動を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int ReadProc(ref StockMoveWork stockmoveWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProcProc(ref stockmoveWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の在庫移動を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        private int ReadProcProc(ref StockMoveWork stockmoveWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);
                SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    stockmoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("伝票の存在チェックエラー status={0} エラー情報={1}", status, ex.Message));

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
        /// 指定された条件の在庫移動を複数戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="stockmoveList">検索結果List</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫移動をf複数戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        private int ReadProcProc(ref StockMoveWork stockmoveWork,ref ArrayList stockmoveList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKM.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVESLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.UPDATESECCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMVEMPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SHIPAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.RECEIVEAGENTNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.MOVECOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.LISTPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.OUTLINERF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.WAREHOUSENOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKM.STOCKMOVEPRICERF" + Environment.NewLine;
                selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;
                if (stockmoveWork.StockMoveFormal != 0)
                {
                    selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                }

                //Selectコマンドの生成
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                if (stockmoveWork.StockMoveFormal != 0)
                {
                    SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                    findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                }


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockmoveList.Add(CopyToStockMoveWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
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

        #endregion

        #region [Write]
        /// <summary>
        /// 在庫移動情報を登録、更新します
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        public int Write(ref object stockMoveWork, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";
            
            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            
            string resNm = "";
            try
            {
                // --- UPD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
                //OutputClcLog(string.Format("在庫移動登録処理開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                // 呼出元メソッド取得
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("在庫移動登録処理 呼出元={0} 呼出元メソッド={1}", className, methodName));
                }
                catch
                {
                    //処理なし
                }
                // --- UPD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
                ArrayList stockMoveList = null;         //在庫移動リスト
                ArrayList stockList = null;             //在庫リスト
                ArrayList stockAcPayHistList = null;    //在庫受払履歴リスト
                ArrayList defStockMoveList = null;      //更新差分在庫移動リスト
                ArrayList BFStockMoveList = null; //更新前移動リスト
                ArrayList defStockList = null;    //更新前在庫リスト
                ArrayList moveArrivalnewList = null; // 入庫伝票新規作成用リスト
                ArrayList moveArrivalupList = null; // 入庫伝票更新リスト

                
                ArrayList goodsUnitList = null;
                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
                // 拠点間発注データobject
                object orderDataDicObj = null;
                // オプション情報obj
                object psObj = null;

                // 拠点間発注データのDictionaryの初期化
                Dictionary<string, ArrayList> orderDataDic = null;
                // オプション情報の初期化
                int ps = 0;
                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                // 検品データオブジェクト
                ArrayList inspectList = null;
                // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                    if (csaList[i] is Dictionary<string, ArrayList>)
                    {
                        // 拠点間発注データのDictionaryのセット
                        orderDataDic = csaList[i] as Dictionary<string, ArrayList>;
                        // 拠点間発注データobjectのセット
                        orderDataDicObj = csaList[i];
                    }
                    else if (csaList[i] is int)
                    {
                        // オプション情報objのセット
                        ps = Convert.ToInt32(csaList[i]);
                        // オプション情報のセット
                        psObj = csaList[i];
                    }
                    else
                    {
                        ArrayList wkal = csaList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //在庫移動マスタ
                                if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                                //商品マスタ
                                if (wkal[0] is GoodsUnitDataWork) goodsUnitList = wkal;
                                // 検品データ
                                if (wkal[0] is HandyInspectDataWork) inspectList = wkal;// ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発
                            }
                        }
                    }
                    // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                    // ---- DEL K2013/12/25 鄧潘ハン ---- >>>>>
                    //ArrayList wkal = csaList[i] as ArrayList;
                    //if (wkal != null)
                    //{
                    //    if (wkal.Count > 0)
                    //    {
                    //        //在庫移動マスタ
                    //        if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                    //        //商品マスタ
                    //        if (wkal[0] is GoodsUnitDataWork) goodsUnitList = wkal;
                    //    }
                    //}
                    // ---- DEL K2013/12/25 鄧潘ハン ---- <<<<<
                }

                // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                // パラメーターの拠点間発注データを削除する
                if (orderDataDicObj != null)
                {
                    csaList.Remove(orderDataDicObj);
                }

                // パラメーターのオプション情報を削除する
                if (psObj != null)
                {
                    csaList.Remove(psObj);
                }
                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                //OutputClcLog(string.Format("拠点設定取得開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                //拠点設定の取得
                status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg = "拠点設定の取得に失敗しました。";
                    OutputClcLog(string.Format("拠点設定取得異常 status={0} エラー情報={1}", status, retMsg));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応

                    return status;
                }
                //OutputClcLog(string.Format("拠点設定取得終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// // DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                OutputClcLog(string.Format("移動状態={0}", moveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;
                //OutputClcLog(string.Format("システムロック開始 出庫倉庫={0} 入庫庫倉庫={1} 物理メモリ合計={2} 利用可能物理メモリ={3}", _stockMoveWork.BfEnterWarehCode, _stockMoveWork.AfEnterWarehCode, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// // DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                // 出庫システムロック
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Write_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0)
                {
                    OutputClcLog(string.Format("出庫システムロックエラー status={0}", status));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                    return status;
                } 
        
                // 入庫システムロック
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Write_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0)
                {
                    OutputClcLog(string.Format("入庫システムロックエラー status={0}", status));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                    return status;
                } 
                // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                //OutputClcLog(string.Format("システムロック終了 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                //OutputClcLog(string.Format("ＡＰロック処理開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.Write:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.Write:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                        OutputClcLog(string.Format("ＡＰロック処理エラー status={0} エラー情報={1}", status, retMsg));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                        OutputClcLog(string.Format("ＡＰロック処理エラー status={0} エラー情報={1}", status, retMsg));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.Write_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }
                //OutputClcLog(string.Format("ＡＰロック処理終了 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                try
                {
                    OutputClcLog(string.Format("入荷確定あり/なし={0}", _stockMoveWork.StockMoveFixCode));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                     //入荷確定あり
                    if (_stockMoveWork.StockMoveFixCode == 1)
                    // テスト用
                    //if (_stockMoveWork.StockMoveFixCode == 0)
                    {
                        //---在庫移動伝票番号採番処理---
                        if (stockMoveSlipNo == 0)//在庫移動伝票
                        {
                            //OutputClcLog(string.Format("在庫移動伝票番号採番処理開始 拠点コード={0}，在庫移動形式={1}，物理メモリ合計={2} 利用可能物理メモリ={3}", sectionCode, stockMoveFormal, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                            // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                OutputClcLog(string.Format("在庫移動伝票番号採番処理エラー status={0} エラー情報={1}", status, retMsg));
                            }
                            // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<
                            //OutputClcLog(string.Format("在庫移動伝票番号採番処理終了 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                        }
                        else
                        {
                            //更新前データの取得
                            BFStockMoveList = new ArrayList();
                            foreach (StockMoveWork stmvwork in stockMoveList)
                            {
                                StockMoveWork searchpara = new StockMoveWork();
                                searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                                searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                                searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                                searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                                this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                                BFStockMoveList.Add(searchpara);
                            }

                            // 入荷処理の場合
                            if (moveStatus == 9)
                            {
                                //OutputClcLog(string.Format("入荷処理の場合出庫伝票更新リスト作成開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                // 出庫伝票更新リスト作成のタイミングで入庫新規リスト作成
                                moveArrivalnewList = new ArrayList();

                                foreach (StockMoveWork stMoveWork in stockMoveList)
                                {
                                    StockMoveWork arrivalWork = new StockMoveWork();
                                    OutputClcLog(string.Format("入荷処理(入庫新規リスト作成前) 在庫移動伝票番号={0};在庫移動形式={1};在庫移動行番号={2};移動状態={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                    #region 入庫伝票
                                    arrivalWork.AfEnterWarehCode = stMoveWork.AfEnterWarehCode;
                                    arrivalWork.AfEnterWarehName = stMoveWork.AfEnterWarehName;
                                    arrivalWork.AfSectionCode = stMoveWork.AfSectionCode;
                                    arrivalWork.AfSectionGuideSnm = stMoveWork.AfSectionGuideSnm;
                                    arrivalWork.AfShelfNo = stMoveWork.AfShelfNo;
                                    arrivalWork.ArrivalGoodsDay = stMoveWork.ArrivalGoodsDay;
                                    arrivalWork.AutoGoodsInsDiv = stMoveWork.AutoGoodsInsDiv;
                                    arrivalWork.BfEnterWarehCode = stMoveWork.BfEnterWarehCode;
                                    arrivalWork.BfEnterWarehName = stMoveWork.BfEnterWarehName;
                                    arrivalWork.BfSectionCode = stMoveWork.BfSectionCode;
                                    arrivalWork.BfSectionGuideSnm = stMoveWork.BfSectionGuideSnm;
                                    arrivalWork.BfShelfNo = stMoveWork.BfShelfNo;
                                    arrivalWork.BLGoodsCode = stMoveWork.BLGoodsCode;
                                    arrivalWork.BLGoodsFullName = stMoveWork.BLGoodsFullName;
                                    arrivalWork.CreateDateTime = stMoveWork.CreateDateTime;
                                    arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                    arrivalWork.FileHeaderGuid = stMoveWork.FileHeaderGuid;
                                    arrivalWork.GoodsMakerCd = stMoveWork.GoodsMakerCd;
                                    arrivalWork.GoodsName = stMoveWork.GoodsName;
                                    arrivalWork.GoodsNameKana = stMoveWork.GoodsNameKana;
                                    arrivalWork.GoodsNo = stMoveWork.GoodsNo;
                                    arrivalWork.InputDay = stMoveWork.InputDay;
                                    arrivalWork.ListPriceFl = stMoveWork.ListPriceFl;
                                    arrivalWork.LogicalDeleteCode = stMoveWork.LogicalDeleteCode;
                                    arrivalWork.MakerName = stMoveWork.MakerName;
                                    arrivalWork.MoveCount = stMoveWork.MoveCount;
                                    arrivalWork.MoveStatus = stMoveWork.MoveStatus;
                                    arrivalWork.Outline = stMoveWork.Outline;
                                    arrivalWork.ReceiveAgentCd = stMoveWork.ReceiveAgentCd;
                                    arrivalWork.ReceiveAgentNm = stMoveWork.ReceiveAgentNm;
                                    arrivalWork.ShipAgentCd = stMoveWork.ShipAgentCd;
                                    arrivalWork.ShipAgentNm = stMoveWork.ShipAgentNm;
                                    arrivalWork.StockDiv = stMoveWork.StockDiv;
                                    arrivalWork.StockMoveFixCode = stMoveWork.StockMoveFixCode;
                                    if (stMoveWork.StockMoveFormal == 1) arrivalWork.StockMoveFormal = 3;
                                    else arrivalWork.StockMoveFormal = 4;
                                    arrivalWork.StockMovePrice = stMoveWork.StockMovePrice;
                                    arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    arrivalWork.StockMvEmpCode = stMoveWork.StockMvEmpCode;
                                    arrivalWork.StockMvEmpName = stMoveWork.StockMvEmpName;
                                    arrivalWork.StockUnitPriceFl = stMoveWork.StockUnitPriceFl;
                                    arrivalWork.SupplierCd = stMoveWork.SupplierCd;
                                    arrivalWork.SupplierSnm = stMoveWork.SupplierSnm;
                                    arrivalWork.TaxationDivCd = stMoveWork.TaxationDivCd;
                                    arrivalWork.UpdAssemblyId1 = stMoveWork.UpdAssemblyId1;
                                    arrivalWork.UpdAssemblyId2 = stMoveWork.UpdAssemblyId2;
                                    arrivalWork.UpdateDateTime = stMoveWork.UpdateDateTime;
                                    arrivalWork.UpdateSecCd = stMoveWork.UpdateSecCd;
                                    arrivalWork.UpdEmployeeCode = stMoveWork.UpdEmployeeCode;
                                    arrivalWork.WarehouseNote1 = stMoveWork.WarehouseNote1;
                                    arrivalWork.SlipPrintFinishCd = stMoveWork.SlipPrintFinishCd;

                                    // --- ADD 三戸 2012/07/10 ---------->>>>>
                                    arrivalWork.MoveStockAutoInsDiv = stMoveWork.MoveStockAutoInsDiv;
                                    // --- ADD 三戸 2012/07/10 ----------<<<<<

                                    #endregion

                                    moveArrivalnewList.Add(arrivalWork);
                                    OutputClcLog(string.Format("入荷処理(入庫新規リスト作成後) 在庫移動形式={0}", arrivalWork.StockMoveFormal));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                    // Read用
                                    StockMoveWork readArrivalWork = new StockMoveWork();
                                    readArrivalWork.EnterpriseCode = arrivalWork.EnterpriseCode;
                                    readArrivalWork.StockMoveFormal = arrivalWork.StockMoveFormal;
                                    readArrivalWork.StockMoveSlipNo = arrivalWork.StockMoveSlipNo;
                                    readArrivalWork.StockMoveRowNo = arrivalWork.StockMoveRowNo;


                                    // 論理削除伝票の存在チェック
                                    status = ReadProcProc(ref readArrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                    // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                                    {
                                        OutputClcLog(string.Format("論理削除伝票の存在チェックエラー status={0}", status));
                                    }
                                    // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<

                                    // -- UPD 2009/11/25 ----------------------->>>
                                    //論理削除状態は通常は１だが、現状のユーザーで9が存在する事も考慮してORとする
                                    //if (status == 0 && readArrivalWork.LogicalDeleteCode == 9)
                                    if (status == 0 && (readArrivalWork.LogicalDeleteCode == 1 || readArrivalWork.LogicalDeleteCode == 9))
                                    // -- UPD 2009/11/25 -----------------------<<<
                                    {
                                        // -- UPD 2010/06/11 ---------------->>>
                                        //moveArrivalupList = new ArrayList();
                                        if (moveArrivalupList == null) moveArrivalupList = new ArrayList();
                                        // -- UPD 2010/06/11 ----------------<<<
                                        moveArrivalupList.Add(readArrivalWork);
                                    }

                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                //OutputClcLog(string.Format("入荷処理の場合出庫伝票更新リスト作成終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            }
                            // 入荷取消の場合
                            // ADD 2009/07/08 コメント追加 >>>
                            // 入荷取消処理の場合、出庫データ・入庫データの2レコードに対しての更新を行う
                            // 出庫データ⇒入荷確定前の状態に更新( ①入荷日=0 ②移動状態=2:移動中 に変更 )
                            // 入庫データ⇒入荷確定前の状態に更新( ①削除区分 =1:論理削除 に変更 )
                            // ADD 2009/07/08 <<<
                            else if (moveStatus == 2)
                            {
                                // 修正 2009/07/08 >>>
                                //foreach (StockMoveWork stMoveWork in stockMoveList)
                                //{
                                    //StockMoveWork arrivalWork = new StockMoveWork();
                                    //arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                    //arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    //arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    //if (stMoveWork.StockMoveFormal == 1) arrivalWork.StockMoveFormal = 3;
                                    //else arrivalWork.StockMoveFormal = 4;
                                    //status = ReadProcProc(ref arrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                    //if (status == 0 && arrivalWork.LogicalDeleteCode == 0)
                                    //{
                                    //    arrivalWork.LogicalDeleteCode = 9;
                                    //    moveArrivalnewList = new ArrayList();
                                    //    moveArrivalnewList.Add(arrivalWork);
                                    //}
                                //}
                                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                // -- ADD 2009/11/25 ----------------->>>
                                if (stockMoveFormal == 3 || stockMoveFormal == 4)
                                {
                                // -- ADD 2009/11/25 -----------------<<<
                                    for (int i = 0; i < stockMoveList.Count; i++)
                                    {
                                        StockMoveWork stMoveWork = stockMoveList[i] as StockMoveWork;
                                        OutputClcLog(string.Format("入荷取消処理(入庫伝票) 在庫移動伝票番号={0};在庫移動形式={1};在庫移動行番号={2};移動状態={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                                        // 入庫伝票の変更
                                        // -- UPD 2009/11/25 --------------------->>>
                                        //論理削除状態は1に変更
                                        //((StockMoveWork)stockMoveList[i]).LogicalDeleteCode = 9;  // 論理削除区分 = 9
                                        ((StockMoveWork)stockMoveList[i]).LogicalDeleteCode = 1;  // 論理削除区分 = 1
                                        // -- UPD 2009/11/25 ---------------------<<<


                                        StockMoveWork arrivalWork = new StockMoveWork();

                                        // 入庫伝票情報から出庫伝票検索条件セット
                                        arrivalWork.EnterpriseCode = stMoveWork.EnterpriseCode;
                                        arrivalWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                        arrivalWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                        if (stMoveWork.StockMoveFormal == 3) arrivalWork.StockMoveFormal = 1;
                                        else arrivalWork.StockMoveFormal = 2;
                                        OutputClcLog(string.Format("入荷取消処理(出庫伝票検索条件) 在庫移動伝票番号={0};在庫移動形式={1};在庫移動行番号={2};移動状態={3}", stMoveWork.StockMoveSlipNo, stMoveWork.StockMoveFormal, stMoveWork.StockMoveRowNo, stMoveWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                        // 伝票の存在チェック
                                        status = ReadProcProc(ref arrivalWork, 0, ref sqlConnection, ref sqlTransaction);
                                        // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            OutputClcLog(string.Format("入荷取消の場合伝票の存在チェックエラー status={0}", status));
                                        }
                                        // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<

                                        if (status == 0 && arrivalWork.LogicalDeleteCode == 0)
                                        {
                                            // 出庫伝票の変更
                                            // -- UPD 2010/06/11 ----------------->>>
                                            //moveArrivalnewList = new ArrayList();
                                            if (moveArrivalnewList == null) moveArrivalnewList = new ArrayList();
                                            // -- UPD 2010/06/11 -----------------<<<
                                            if (arrivalWork.StockMoveFormal == 1 || arrivalWork.StockMoveFormal == 2)
                                            {
                                                arrivalWork.MoveStatus = 2;// 移動状態 = 2:移動中
                                                arrivalWork.ArrivalGoodsDay = DateTime.MinValue;// 入荷日 = 0

                                                moveArrivalnewList.Add(arrivalWork);
                                                OutputClcLog(string.Format("入荷取消処理(出庫伝票) 在庫移動伝票番号={0};在庫移動形式={1};在庫移動行番号={2};移動状態={3}", arrivalWork.StockMoveSlipNo, arrivalWork.StockMoveFormal, arrivalWork.StockMoveRowNo, arrivalWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                            }
                                        }
                                    }
                                } // ADD 2009/11/25

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                // 修正 2009/07/08 <<<
                            }

                            #region DEL
                            //status = SearchStockMoveProc(out BFStockMoveList, searchpara, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    status = DeleteStockMoveProc(BFStockMoveList, out deldefList, ref sqlConnection, ref sqlTransaction);

                            //createHisData = false;
                            //データ生成(前回の在庫の更新値を一度クリアする)
                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                            //    status = TransStockMoveToStock((int)ct_ProcMode.Delete, createHisData, stockMoveFormal, stockMoveSlipNo, BFStockMoveList, BFStockMoveList, BFStockMoveList,  defStockList ,out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);

                            //在庫データ更新
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //    string origin = "";
                            //    CustomSerializeArrayList originList = null;
                            //    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            //    paraList.Add(stockList);
                            //    int position = 0;
                            //    string param = "";
                            //    object freeParam = null;
                            //    status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                            //}
                            #endregion
                        }

                        //---更新処理---
                        //在庫移動データ更新
                        if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // -- UPD 2010/06/16 ---------------------------------------->>>
                            //// 出庫・入庫伝票登録
                            //status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                            //if (stockMoveList != null)
                            //    if (stockMoveList.Count > 0)
                            //        retList.Add(stockMoveList);

                            if (moveStatus == 2 && moveArrivalnewList != null)
                            {
                                //OutputClcLog(string.Format("入荷取消の場合入荷伝票の削除開始 在庫移動伝票件数={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", stockMoveList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                //入荷取消の場合の、入荷伝票の削除
                                status = DeleteStockMoveProc(stockMoveList, out defStockMoveList, ref sqlConnection, ref sqlTransaction);
                                if (stockMoveList != null)
                                    if (stockMoveList.Count > 0)
                                        retList.Add(stockMoveList);
                                OutputClcLog(string.Format("入荷取消の場合入荷伝票の削除終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                            }
                            else
                            {
                                //OutputClcLog(string.Format("出庫・入庫伝票登録開始 在庫移動伝票件数={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", stockMoveList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                // 出庫・入庫伝票登録
                                status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                                if (stockMoveList != null)
                                    if (stockMoveList.Count > 0)
                                        retList.Add(stockMoveList);
                                OutputClcLog(string.Format("出庫・入庫伝票登録終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                            }
                            // -- UPD 2010/06/16 ----------------------------------------<<<

                            // 入庫伝票登録･論理削除･新規登録の場合 // moveStatusが9(入荷処理)又は2(入荷取消)だったら
                            if ((moveStatus == 9 || moveStatus == 2) && moveArrivalupList == null && moveArrivalnewList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //OutputClcLog(string.Format("元の出庫伝票の更新開始 在庫移動伝票件数={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", moveArrivalnewList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                //元の出庫伝票の更新
                                ArrayList defMoveArrivalList = null;
                                status = WriteStockMoveProc(stockMoveSlipNo, out defMoveArrivalList, ref moveArrivalnewList, ref sqlConnection, ref sqlTransaction);
                                OutputClcLog(string.Format("元の出庫伝票の更新終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                            }
                            // 入庫伝票復旧 論理削除データがあった場合 // moveStatusが9(入荷処理)だったら
                            if (moveStatus == 9 && moveArrivalupList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //object arrivalobj = null;
                                //CustomSerializeArrayList arrivalArray = new CustomSerializeArrayList();

                                //arrivalArray.Add(moveArrivalupList);
                                //arrivalobj = arrivalArray;

                                //status = RevivalLogicalDelete(ref arrivalobj);

                                ArrayList DefstockMoveWorkList = null;
                                //OutputClcLog(string.Format("在庫移動情報の論理削除開始　削除件数={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", moveArrivalupList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                LogicalDeleteStockMoveProcProc(ref moveArrivalupList, out DefstockMoveWorkList, 1, ref sqlConnection, ref sqlTransaction);
                                OutputClcLog(string.Format("在庫移動情報の論理削除終了 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                            }
                        }

                        // --- ADD 三戸 2012/07/05 ---------->>>>>
                        // 条件追加：移動時在庫自動登録区分＝「0:する」の場合
                        if (_stockMoveWork.MoveStockAutoInsDiv == 0)
                        {
                            // --- ADD 三戸 2012/07/05 ----------<<<<<
                            //商品マスタデータ新規登録
                            if (goodsUnitList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList goodscsList = new CustomSerializeArrayList();
                                goodscsList.Add(goodsUnitList);

                                object goodsobj = goodscsList;
                                //OutputClcLog(string.Format("商品マスタデータ新規登録開始 登録商品件数={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", goodsUnitList.Count, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                status = _usrJoinPartsSearchDB.ReadNewWriteRelation(ref goodsobj, ref sqlConnection, ref sqlTransaction);
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("商品マスタデータ新規登録エラー status={0}", status));
                                }
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<
                                OutputClcLog(string.Format("商品マスタデータ新規登録終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                            }
                            // --- ADD 三戸 2012/07/05 ---------->>>>>
                        }
                        // --- ADD 三戸 2012/07/05 ----------<<<<<

                        //データ生成
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            createHisData = true;
                            ArrayList defList = defStockMoveList;
                            //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                            //OutputClcLog(string.Format("データ変換(生成)処理開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン
                            OutputClcLog(string.Format("データ変換(生成)処理終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
                        }

                        //在庫データ更新
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string origin = "";
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            paraList.Add(stockList);
                            paraList.Add(stockAcPayHistList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            // --- ADD 三戸 2012/07/05 ---------->>>>>
                            // 移動時在庫自動登録区分＝「1:しない」の場合に対応
                            if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)
                            {
                                // --- ADD 三戸 2012/07/05 ----------<<<<<
                                //OutputClcLog(string.Format("在庫データ更新処理開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));
                                status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("在庫データ更新処理エラー status={0} エラー情報={1}", status, retMsg));
                                }
                                OutputClcLog(string.Format("在庫データ更新処理終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<

                                // --- ADD 三戸 2012/07/05 ---------->>>>>
                                // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                                // フタバ個別専門用のキーにオプションコードが無効の場合(オプションコード：OPT-CPM0130)
                                if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
                                {
                                    status = UpdateSecOrderDtWork((int)ct_ProcMode.Write, stockMoveList, orderDataDic, ref sqlConnection, ref sqlTransaction);
                                    OutputClcLog(string.Format("フタバ拠点間発注データ更新処理終了 status={0}", status));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                }
                                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                                // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
                                // 検品データ登録
                                if (inspectList != null && inspectList.Count > 0)
                                {
                                    // 検品データ登録
                                    status = this.InspectDataObj.WriteInspectDataProc(ref inspectList, ref sqlConnection, ref sqlTransaction, 0);
                                    OutputClcLog(string.Format("検品データ登録終了 status={0}", status));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                }
                                // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<
                            }
                            // --- ADD 三戸 2012/07/05 ----------<<<<<
                        }

                        //戻り値セット
                        stockMoveWork = retList;
                    }
                    // 入荷確定なし
                    else
                    {
                        ArrayList stockMoveNewList = null;
                        //---在庫移動伝票番号採番処理---
                        if (stockMoveSlipNo == 0)//在庫移動伝票
                        {
                            status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            //更新前データの取得
                            BFStockMoveList = new ArrayList();
                            stockMoveNewList = new ArrayList(); 
                            foreach (StockMoveWork stmvwork in stockMoveList)
                            {
                                StockMoveWork searchpara = new StockMoveWork();
                                searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                                searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                                searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                                searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                                this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                                BFStockMoveList.Add(searchpara);

                                // 入荷伝票だったらセット下記仕様を変更
                                if (searchpara.StockMoveFormal == 3 || searchpara.StockMoveFormal == 4)
                                {
                                    searchpara.ShipmentScdlDay = DateTime.MinValue;
                                    searchpara.ShipmentFixDay = DateTime.MinValue;
                                }
                            }
                        }
                        //---更新処理---
                        //在庫移動データ更新
                        if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //OutputClcLog(string.Format("入荷確定なしの場合、在庫移動データ更新開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            // 出庫伝票登録
                            status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                            if (stockMoveList != null)
                                if (stockMoveList.Count > 0)
                                    retList.Add(stockMoveList);
                            //OutputClcLog(string.Format("入荷確定なしの場合、在庫移動データ更新終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                        }

                        // --- ADD 三戸 2012/07/05 ---------->>>>>
                        // 条件追加：移動時在庫自動登録区分＝「0:する」の場合
                        if (_stockMoveWork.MoveStockAutoInsDiv == 0)
                        {
                            // --- ADD 三戸 2012/07/05 ----------<<<<<
                            //商品マスタデータ新規登録
                            if (goodsUnitList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList goodscsList = new CustomSerializeArrayList();
                                goodscsList.Add(goodsUnitList);

                                object goodsobj = goodscsList;
                                //OutputClcLog(string.Format("入荷確定なしの場合、商品マスタデータ新規登録開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                status = _usrJoinPartsSearchDB.ReadNewWriteRelation(ref goodsobj, ref sqlConnection, ref sqlTransaction);
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("入荷確定なしの場合、商品マスタデータ新規登録エラー status={0}", status));
                                }
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<
                                //OutputClcLog(string.Format("入荷確定なしの場合、商品マスタデータ新規登録終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                            }
                            // --- ADD 三戸 2012/07/05 ---------->>>>>
                        }
                        // --- ADD 三戸 2012/07/05 ----------<<<<<

                        //データ生成
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            createHisData = true;
                            ArrayList defList = defStockMoveList;
                            //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                            //OutputClcLog(string.Format("入荷確定なしの場合、データ生成開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                            try
                            {
                                status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン
                            }
                            catch (Exception ex)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                OutputClcLog(string.Format("入荷確定なしの場合、データ生成エラー status={0} エラー内容={1}", status, ex.Message));
                            }
                            finally
                            {
                                //OutputClcLog(string.Format("入荷確定なしの場合、データ生成終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            }
                            // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<                            
                        }
                        
                        //在庫データ更新
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            string origin = "";
                            //CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList originList = null;
                            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                            paraList.Add(stockList);
                            paraList.Add(stockAcPayHistList);
                            int position = 0;
                            string param = "";
                            object freeParam = null;
                            if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)
                            {
                                //OutputClcLog(string.Format("入荷確定なしの場合、在庫データ更新開始 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                                status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応---->>>>>
                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    OutputClcLog(string.Format("入荷確定なしの場合、在庫データ更新エラー status={0}", status));
                                }
                                // ----ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応----<<<<<

                                //OutputClcLog(string.Format("入荷確定なしの場合、在庫データ更新終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            }
                        }

                        //戻り値セット
                        stockMoveWork = retList;
                    }
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.Write_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                        //OutputClcLog(string.Format("ＡＰアンロックRelease 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                    }
                    // -- UPD 2010/06/16 --------------------------->>>
                    int bkstatus = 0;
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        bkstatus = status;
                    // -- UPD 2010/06/16 ---------------------------<<<

                    // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_afinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Write_ShareCheckRelease_bfinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    //OutputClcLog(string.Format("システムロックRelease 物理メモリ合計={0} 利用可能物理メモリ={1}", this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                    // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // -- UPD 2010/06/16 --------------------------->>>
                    //メイン処理で失敗しても、ロックのリリースが正常終了すると、コミットされてしまうため、
                    //ここで退避したステータスをセットする
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        status = bkstatus;
                    // -- UPD 2010/06/16 ---------------------------<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Write(ref object stockMoveWork,out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                OutputClcLog(string.Format("在庫移動登録処理エラー status={0} エラー情報={1}", status, ex.Message));
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //OutputClcLog(string.Format("在庫移動登録処理終了 status={0} 物理メモリ合計={1} 利用可能物理メモリ={2}", status, this.GetTotalMemory(), this.GetAvaliableMemory()));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
            }

            return status;
        }



        // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>

        /// <summary>
        /// 拠点間発注データを更新します
        /// </summary>
        /// <param name="procMode">procMode</param>
        /// <param name="stockMoveList">stockMoveList</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : 拠点間発注データを更新します</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : K2013/12/25</br>
        ///</remarks>
        private int UpdateSecOrderDtWork(int procMode, ArrayList stockMoveList, Dictionary<string, ArrayList> orderDataDic, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string orderDataKey = string.Empty;
                StockMoveWork para = new StockMoveWork();
                ArrayList secOrderDtList = new ArrayList();
                // 取消の場合：1発注済 // 入庫の場合：2引当済
                int secOrderDataDiv = 0;

                DateTime updateDateTime;
                //在庫移動データをループ
                for (int i = 0; i < stockMoveList.Count; i++)
                {

                    para = stockMoveList[i] as StockMoveWork;
                    orderDataKey = para.StockMoveSlipNo + "_" + para.StockMoveRowNo;
                    if (!orderDataDic.ContainsKey(orderDataKey))
                    {
                        continue;
                    }

                    secOrderDtList = orderDataDic[orderDataKey] as ArrayList;

                    updateDateTime = Convert.ToDateTime(secOrderDtList[0]);
                    secOrderDataDiv = Convert.ToInt32(secOrderDtList[2]);
                    

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM SECORDERDTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.NVarChar);
                    SqlParameter findStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(para.EnterpriseCode); // 企業コード
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0); // 論理削除区分
                    findStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(para.StockMoveSlipNo);// 発注番号
                    findStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(para.StockMoveRowNo);// 発注行番号
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != updateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (updateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        # region 更新時のSQL文生成
                        StringBuilder sb = new StringBuilder();
                        sb.Append("UPDATE SECORDERDTRF SET ");
                        sb.Append("UPDATEDATETIMERF=@UPDATEDATETIME ,");
                        sb.Append("ENTERPRISECODERF=@ENTERPRISECODE ,");
                        sb.Append("FILEHEADERGUIDRF=@FILEHEADERGUID ,");
                        sb.Append("UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ,");
                        sb.Append("UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ,");
                        sb.Append("UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ,");
                        if (procMode == 0)
                        {
                            sb.Append("SECORDERDATADIVRF=@SECORDERDATADIV, ");
                        }
                        sb.Append("LOGICALDELETECODERF=@LOGICALDELETECODE ");
                        sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sb.Append("  AND  STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO ");
                        sb.Append("  AND  STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO ");
                        sqlCommand.CommandText = sb.ToString();
                        # endregion

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)para;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);


                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(para.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(para.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(para.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(para.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(para.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(para.UpdAssemblyId2);

                    if (procMode == 1)
                    {
                        // 伝票削除の場合
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                    }
                    else
                    {
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                    }



                    if (secOrderDataDiv == 1 || secOrderDataDiv == 2)
                    {
                        SqlParameter paraSecOrderDataDiv = sqlCommand.Parameters.Add("@SECORDERDATADIV", SqlDbType.NVarChar);
                        // 入庫の場合：2引当済 取消の場合：1発注済
                        paraSecOrderDataDiv.Value = SqlDataMediator.SqlSetInt32(secOrderDataDiv);
                    }

                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
                    if (myReader.IsClosed == false) myReader.Close();
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
        // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

        /// <summary>
        /// 在庫移動情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        public int WriteStockMoveProc(int stockMoveSlipNo, out ArrayList DefstockMoveWorkList, ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
            // 呼出元メソッド取得
            try
            {
                string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                OutputClcLog(string.Format("在庫移動登録処理 呼出元={0} 呼出元メソッド={1}", className, methodName));
            }
            catch
            {
                //処理なし
            }
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
            return WriteStockMoveProcProc(stockMoveSlipNo, out DefstockMoveWorkList, ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// 在庫移動情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: 2011/08/24  連番980 梁森東</br>
        /// <br>            : REDMINE#23417の対応</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        private int WriteStockMoveProcProc(int stockMoveSlipNo, out ArrayList DefstockMoveWorkList, ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            DefstockMoveWorkList = new ArrayList();//更新前後差分用リスト
            try
            {
                string selectTxt = "";

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        //在庫移動伝票番号が 0 の場合はパラメータの伝票番号をセット
                        if (stockmoveWork.StockMoveSlipNo == 0)
                            stockmoveWork.StockMoveSlipNo = stockMoveSlipNo;

                        //OutputClcLog(string.Format("在庫移動情報 在庫移動伝票番号={0} 在庫移動伝票行番号={1}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  *" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            OutputClcLog(string.Format("在庫移動伝票UPDATE 在庫移動伝票番号={0} 在庫移動伝票行番号={1} 在庫移動形式={2} 移動状態={3}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo, stockmoveWork.StockMoveFormal, stockmoveWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockmoveWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (stockmoveWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //更新前の在庫移動データを取得
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            //更新後の移動数を反映
                            defStockMoveWork.MoveCount = stockmoveWork.MoveCount - defStockMoveWork.MoveCount;
                            defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice - defStockMoveWork.StockMovePrice;
                            // -- ADD 2010/06/15 -------------------------------->>>
                            //確定区分を追加
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD 三戸 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD 三戸 2012/07/10 ----------<<<<<

                            // -- ADD 2010/06/15 --------------------------------<<<
                            DefstockMoveWorkList.Add(defStockMoveWork);

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEFORMALRF=@STOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " , STOCKMOVESLIPNORF=@STOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEROWNORF=@STOCKMOVEROWNO" + Environment.NewLine;
                            selectTxt += " , UPDATESECCDRF=@UPDATESECCD" + Environment.NewLine;
                            selectTxt += " , BFSECTIONCODERF=@BFSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , BFSECTIONGUIDESNMRF=@BFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += " , BFENTERWAREHCODERF=@BFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += " , BFENTERWAREHNAMERF=@BFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += " , AFSECTIONCODERF=@AFSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , AFSECTIONGUIDESNMRF=@AFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += " , AFENTERWAREHCODERF=@AFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += " , AFENTERWAREHNAMERF=@AFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += " , SHIPMENTSCDLDAYRF=@SHIPMENTSCDLDAY" + Environment.NewLine;
                            selectTxt += " , SHIPMENTFIXDAYRF=@SHIPMENTFIXDAY" + Environment.NewLine;
                            selectTxt += " , ARRIVALGOODSDAYRF=@ARRIVALGOODSDAY" + Environment.NewLine;
                            selectTxt += " , INPUTDAYRF=@INPUTDAY" + Environment.NewLine;
                            selectTxt += " , MOVESTATUSRF=@MOVESTATUS" + Environment.NewLine;
                            selectTxt += " , STOCKMVEMPCODERF=@STOCKMVEMPCODE" + Environment.NewLine;
                            selectTxt += " , STOCKMVEMPNAMERF=@STOCKMVEMPNAME" + Environment.NewLine;
                            selectTxt += " , SHIPAGENTCDRF=@SHIPAGENTCD" + Environment.NewLine;
                            selectTxt += " , SHIPAGENTNMRF=@SHIPAGENTNM" + Environment.NewLine;
                            selectTxt += " , RECEIVEAGENTCDRF=@RECEIVEAGENTCD" + Environment.NewLine;
                            selectTxt += " , RECEIVEAGENTNMRF=@RECEIVEAGENTNM" + Environment.NewLine;
                            selectTxt += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            selectTxt += " , SUPPLIERSNMRF=@SUPPLIERSNM" + Environment.NewLine;
                            selectTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += " , MAKERNAMERF=@MAKERNAME" + Environment.NewLine;
                            selectTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            selectTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                            selectTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                            selectTxt += " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            selectTxt += " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                            selectTxt += " , MOVECOUNTRF=@MOVECOUNT" + Environment.NewLine;
                            selectTxt += " , BFSHELFNORF=@BFSHELFNO" + Environment.NewLine;
                            selectTxt += " , AFSHELFNORF=@AFSHELFNO" + Environment.NewLine;
                            selectTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                            selectTxt += " , LISTPRICEFLRF=@LISTPRICEFL" + Environment.NewLine;
                            selectTxt += " , OUTLINERF=@OUTLINE" + Environment.NewLine;
                            selectTxt += " , WAREHOUSENOTE1RF=@WAREHOUSENOTE1" + Environment.NewLine;
                            selectTxt += " , SLIPPRINTFINISHCDRF=@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += " , STOCKMOVEPRICERF=@STOCKMOVEPRICE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            //if (stockmoveWork.UpdateDateTime > DateTime.MinValue)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            //    sqlCommand.Cancel();
                            //    if (myReader.IsClosed == false) myReader.Close();
                            //    return status;
                            //}
                            OutputClcLog(string.Format("在庫移動伝票INSERT 在庫移動伝票番号={0} 在庫移動伝票行番号={1} 在庫移動形式={2} 移動状態={3}", stockmoveWork.StockMoveSlipNo, stockmoveWork.StockMoveRowNo, stockmoveWork.StockMoveFormal, stockmoveWork.MoveStatus));// ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応
                            StockMoveWork defStockMoveWork = stockmoveWork;
                            DefstockMoveWorkList.Add(defStockMoveWork);

                            #region INSERTクエリ
                            selectTxt = "";
                            selectTxt += "INSERT INTO STOCKMOVERF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEFORMALRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVESLIPNORF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEROWNORF" + Environment.NewLine;
                            selectTxt += "  ,UPDATESECCDRF" + Environment.NewLine;
                            selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,BFSECTIONGUIDESNMRF" + Environment.NewLine;
                            selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                            selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                            selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,AFSECTIONGUIDESNMRF" + Environment.NewLine;
                            selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                            selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTSCDLDAYRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPMENTFIXDAYRF" + Environment.NewLine;
                            selectTxt += "  ,ARRIVALGOODSDAYRF" + Environment.NewLine;
                            selectTxt += "  ,INPUTDAYRF" + Environment.NewLine;
                            selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMVEMPCODERF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMVEMPNAMERF" + Environment.NewLine;
                            selectTxt += "  ,SHIPAGENTCDRF" + Environment.NewLine;
                            selectTxt += "  ,SHIPAGENTNMRF" + Environment.NewLine;
                            selectTxt += "  ,RECEIVEAGENTCDRF" + Environment.NewLine;
                            selectTxt += "  ,RECEIVEAGENTNMRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                            selectTxt += "  ,GOODSNAMEKANARF" + Environment.NewLine;
                            selectTxt += "  ,STOCKDIVRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,TAXATIONDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,MOVECOUNTRF" + Environment.NewLine;
                            selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                            selectTxt += "  ,LISTPRICEFLRF" + Environment.NewLine;
                            selectTxt += "  ,OUTLINERF" + Environment.NewLine;
                            selectTxt += "  ,WAREHOUSENOTE1RF" + Environment.NewLine;
                            selectTxt += "  ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                            selectTxt += "  ,STOCKMOVEPRICERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEROWNO" + Environment.NewLine;
                            selectTxt += "  ,@UPDATESECCD" + Environment.NewLine;
                            selectTxt += "  ,@BFSECTIONCODE" + Environment.NewLine; 
                            selectTxt += "  ,@BFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += "  ,@BFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += "  ,@BFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += "  ,@AFSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@AFSECTIONGUIDESNM" + Environment.NewLine;
                            selectTxt += "  ,@AFENTERWAREHCODE" + Environment.NewLine;
                            selectTxt += "  ,@AFENTERWAREHNAME" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTSCDLDAY" + Environment.NewLine;
                            selectTxt += "  ,@SHIPMENTFIXDAY" + Environment.NewLine;
                            selectTxt += "  ,@ARRIVALGOODSDAY" + Environment.NewLine;
                            selectTxt += "  ,@INPUTDAY" + Environment.NewLine;
                            selectTxt += "  ,@MOVESTATUS" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMVEMPCODE" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMVEMPNAME" + Environment.NewLine;
                            selectTxt += "  ,@SHIPAGENTCD" + Environment.NewLine;
                            selectTxt += "  ,@SHIPAGENTNM" + Environment.NewLine;
                            selectTxt += "  ,@RECEIVEAGENTCD" + Environment.NewLine;
                            selectTxt += "  ,@RECEIVEAGENTNM" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
                            selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
                            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            selectTxt += "  ,@MAKERNAME" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNAME" + Environment.NewLine;
                            selectTxt += "  ,@GOODSNAMEKANA" + Environment.NewLine;
                            selectTxt += "  ,@STOCKDIV" + Environment.NewLine;
                            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@TAXATIONDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@MOVECOUNT" + Environment.NewLine;
                            selectTxt += "  ,@BFSHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@AFSHELFNO" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
                            selectTxt += "  ,@LISTPRICEFL" + Environment.NewLine;
                            selectTxt += "  ,@OUTLINE" + Environment.NewLine;
                            selectTxt += "  ,@WAREHOUSENOTE1" + Environment.NewLine;
                            selectTxt += "  ,@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += "  ,@STOCKMOVEPRICE" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            #endregion

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = selectTxt;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraStockMoveFormal = sqlCommand.Parameters.Add("@STOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter paraStockMoveSlipNo = sqlCommand.Parameters.Add("@STOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter paraStockMoveRowNo = sqlCommand.Parameters.Add("@STOCKMOVEROWNO", SqlDbType.Int);
                        SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraBfSectionGuideSnm = sqlCommand.Parameters.Add("@BFSECTIONGUIDESNM", SqlDbType.NVarChar);
                        SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                        SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraAfSectionGuideSnm = sqlCommand.Parameters.Add("@AFSECTIONGUIDESNM", SqlDbType.NVarChar);
                        SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                        SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
                        SqlParameter paraShipmentScdlDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLDAY", SqlDbType.Int);
                        SqlParameter paraShipmentFixDay = sqlCommand.Parameters.Add("@SHIPMENTFIXDAY", SqlDbType.Int);
                        SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
                        SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@STOCKMVEMPCODE", SqlDbType.NChar);
                        SqlParameter paraStockMvEmpName = sqlCommand.Parameters.Add("@STOCKMVEMPNAME", SqlDbType.NVarChar);
                        SqlParameter paraShipAgentCd = sqlCommand.Parameters.Add("@SHIPAGENTCD", SqlDbType.NChar);
                        SqlParameter paraShipAgentNm = sqlCommand.Parameters.Add("@SHIPAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraReceiveAgentCd = sqlCommand.Parameters.Add("@RECEIVEAGENTCD", SqlDbType.NChar);
                        SqlParameter paraReceiveAgentNm = sqlCommand.Parameters.Add("@RECEIVEAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                        SqlParameter paraMoveCount = sqlCommand.Parameters.Add("@MOVECOUNT", SqlDbType.Float);
                        SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float);
                        SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseNote1 = sqlCommand.Parameters.Add("@WAREHOUSENOTE1", SqlDbType.NVarChar);
                        SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                        SqlParameter paraStockMovePrice = sqlCommand.Parameters.Add("@STOCKMOVEPRICE", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockmoveWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.LogicalDeleteCode);
                        paraStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        paraStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                        paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdateSecCd);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfSectionCode);
                        paraBfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfSectionGuideSnm);
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfEnterWarehCode);
                        paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfEnterWarehName);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfSectionCode);
                        paraAfSectionGuideSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfSectionGuideSnm);
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfEnterWarehCode);
                        paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfEnterWarehName);
                        if (stockmoveWork.StockMoveFormal == 3 || stockmoveWork.StockMoveFormal == 4)
                        {
                            paraShipmentScdlDay.Value = 0;
                            paraShipmentFixDay.Value = 0;
                            paraMoveStatus.Value = 9; // ADD 2009/07/08
                        }
                        else
                        {
                            paraShipmentScdlDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ShipmentScdlDay);
                            paraShipmentFixDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ShipmentFixDay);
                            paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.MoveStatus); // ADD 2009/07/08
                        }
                        // 修正 2009/07/08 >>>
                        //paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ArrivalGoodsDay);
                        if (stockmoveWork.ArrivalGoodsDay == DateTime.MinValue)
                        {
                            paraArrivalGoodsDay.Value = 0;
                        }
                        else
                        {
                            paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.ArrivalGoodsDay);
                        }
                        // 修正 2009/07/08 <<<
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockmoveWork.InputDay);
                        //paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.MoveStatus); // DEL 2009/07/08
                        paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.StockMvEmpCode);
                        paraStockMvEmpName.Value = SqlDataMediator.SqlSetString(stockmoveWork.StockMvEmpName);
                        paraShipAgentCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.ShipAgentCd);
                        paraShipAgentNm.Value = SqlDataMediator.SqlSetString(stockmoveWork.ShipAgentNm);
                        paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(stockmoveWork.ReceiveAgentCd);
                        paraReceiveAgentNm.Value = SqlDataMediator.SqlSetString(stockmoveWork.ReceiveAgentNm);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SupplierCd);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockmoveWork.SupplierSnm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockmoveWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsName);
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockmoveWork.GoodsNameKana);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockDiv);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.StockUnitPriceFl);
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.TaxationDivCd);
                        paraMoveCount.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.MoveCount);
                        paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.BfShelfNo);
                        paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockmoveWork.AfShelfNo);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockmoveWork.BLGoodsFullName);
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(stockmoveWork.ListPriceFl);
                        paraOutline.Value = SqlDataMediator.SqlSetString(stockmoveWork.Outline);
                        paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(stockmoveWork.WarehouseNote1);
                        paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SlipPrintFinishCd);
                        paraStockMovePrice.Value = SqlDataMediator.SqlSetInt64(stockmoveWork.StockMovePrice);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //ADD by Liangsd   2011/08/24----------------->>>>>>>>>>
                if (ex.Number == 2627)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //ADD by Liangsd   2011/08/24-----------------<<<<<<<<<<
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("伝票登録エラー status={0} エラー情報={1}", status, ex.Message));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;
        }

        /// <summary>
        /// 在庫移動データの伝票発行済区分のみを更新します
        /// </summary>
        /// <param name="objstockMoveWork">StockMoveWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データの伝票発行済区分のみを更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.03.11</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteSlipPrintFinishCd(ref object objstockMoveWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList stockMoveWorkList = objstockMoveWork as ArrayList;

            string resNm = string.Empty;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //resNm = GetResourceName((stockMoveWorkList[0] as StockMoveWork).EnterpriseCode);
                string enterpriseCode = (stockMoveWorkList[0] as StockMoveWork).EnterpriseCode;
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<

                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //return status;
                    string retMsg = string.Empty;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteSlipPrintFinishCd_Lock:{0}", retMsg), status);
                    return status;
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

                //伝票発行済区分更新メソッド呼び出し
                status = WriteSlipPrintFinishCd(ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.WriteSlipPrintFinishCd Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //ＡＰアンロック
                if (resNm != "")
                {
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //Release(resNm, sqlConnection, sqlTransaction);
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        //●排他ロックを解除する
                        releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteSlipPrintFinishCd_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                }

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫移動データの伝票発行済区分のみを更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データの伝票発行済区分のみを更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.03.11</br>
        public int WriteSlipPrintFinishCd(ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteSlipPrintFinishCdProc(ref stockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫移動データの伝票発行済区分のみを更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動データの伝票発行済区分のみを更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2009.03.11</br>
        private int WriteSlipPrintFinishCdProc(ref ArrayList stockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                string selectTxt = "";

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "  ,SLIPPRINTFINISHCDRF" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF" + Environment.NewLine;
                            selectTxt += "SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", SLIPPRINTFINISHCDRF=@SLIPPRINTFINISHCD" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //新規追加は行わない
                            if (myReader.IsClosed == false) myReader.Close();
                            continue;
                        }

                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.SlipPrintFinishCd);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 在庫移動情報を論理削除します
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int LogicalDelete(ref object stockMoveWork)
        {
            return LogicalDeleteStockMove(ref stockMoveWork, 0);
        }

        /// <summary>
        /// 論理削除在庫移動情報を復活します
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫移動情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int RevivalLogicalDelete(ref object stockMoveWork)
        {
            return LogicalDeleteStockMove(ref stockMoveWork, 1);
        }

        /// <summary>
        /// 在庫移動情報の論理削除を操作します
        /// </summary>
        /// <param name="stockMoveWork">StockMoveWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        private int LogicalDeleteStockMove(ref object stockMoveWork, int procMode)
        {
            #region 削除
            /*
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockMoveList = null;

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫移動マスタ
                            if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (stockMoveList != null)
                {
                    status = LogicalDeleteStockMoveProc(ref stockMoveList, procMode, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockMoveList);
                }

                stockMoveWork = null;
                stockMoveWork = retList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
            */
            #endregion
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retMsg = "";
            string retItemInfo = "";

            string resNm = "";
            try
            {
                ArrayList stockMoveList = null;
                ArrayList stockList = null;             //在庫リスト
                ArrayList stockAcPayHistList = null;    //在庫受払履歴リスト
                ArrayList defStockMoveList = null;      //更新差分在庫移動リスト
                ArrayList defStockList = null;   //更新前在庫リスト

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
                // 拠点間発注データobject
                object orderDataDicObj = null;
                // オプション情報obj
                object psObj = null;

                // 拠点間発注データのDictionaryの初期化
                Dictionary<string, ArrayList> orderDataDic = null;
                // オプション情報の初期化
                int ps = 0;
                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
                for (int i = 0; i < csaList.Count; i++)
                {
                    // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                    if (csaList[i] is Dictionary<string, ArrayList>)
                    {
                        // 拠点間発注データのDictionaryのセット
                        orderDataDic = csaList[i] as Dictionary<string, ArrayList>;
                        // 拠点間発注データobjectのセット
                        orderDataDicObj = csaList[i];
                    }
                    else if (csaList[i] is int)
                    {
                        // オプション情報objのセット
                        ps = Convert.ToInt32(csaList[i]);
                        // オプション情報のセット
                        psObj = csaList[i];
                    }
                    else
                    {
                        ArrayList wkal = csaList[i] as ArrayList;
                        if (wkal != null)
                        {
                            if (wkal.Count > 0)
                            {
                                //在庫移動マスタ
                                if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                            }
                        }
                    }
                    // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                    // ---- DEL K2013/12/25 鄧潘ハン ---- >>>>>
                    //ArrayList wkal = csaList[i] as ArrayList;
                    //if (wkal != null)
                    //{
                    //    if (wkal.Count > 0)
                    //    {
                    //        //在庫移動マスタ
                    //        if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                    //    }
                    //}
                    // ---- DEL K2013/12/25 鄧潘ハン ---- <<<<<
                }

                // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                // パラメーターの拠点間発注データを削除する
                if (orderDataDicObj != null)
                {
                    csaList.Remove(orderDataDicObj);
                }

                // パラメーターのオプション情報を削除する
                if (psObj != null)
                {
                    csaList.Remove(psObj);
                }
                // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<


                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // 出庫システムロック
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0) return status = 851;

                // 入庫システムロック
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.LogicalDeleteStockMove_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0) return status = 851;
                // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                ////ＡＰロック
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.LogicalDeleteStockMove_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }

                try
                {

                    //在庫移動データ論理削除処理
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = LogicalDeleteStockMoveProc(ref stockMoveList, out defStockMoveList, procMode, ref sqlConnection, ref sqlTransaction);

                    }

                    //在庫系更新用パラメータ作成
                    //データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン

                    //在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                        // フタバ個別専門用のキーにオプションコードが無効の場合(オプションコード：OPT-CPM0130)
                        if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
                        {
                            status = UpdateSecOrderDtWork((int)ct_ProcMode.Delete, stockMoveList, orderDataDic, ref sqlConnection, ref sqlTransaction);
                        }
                        // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
                    }
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    }
                    // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_afinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.LogicalDeleteStockMove_ShareCheckRelease_bfinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;

        }

        /// <summary>
        /// 在庫移動情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int LogicalDeleteStockMoveProc(ref ArrayList stockMoveWorkList, out ArrayList DefstockMoveWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockMoveProcProc(ref stockMoveWorkList, out DefstockMoveWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫移動情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        private int LogicalDeleteStockMoveProcProc(ref ArrayList stockMoveWorkList, out ArrayList DefstockMoveWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            DefstockMoveWorkList = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";

            try
            {
                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        //OutputClcLog(string.Format("削除伝票情報 在庫移動伝票番号={0}", stockmoveWork.StockMoveSlipNo));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  *" + Environment.NewLine;
                        selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != stockmoveWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            #region 在庫リスト→在庫差分リスト
                            //更新前の在庫移動データを取得
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD 三戸 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD 三戸 2012/07/10 ----------<<<<<

                            DefstockMoveWorkList.Add(defStockMoveWork);
                            #endregion


                            selectTxt = "";
                            selectTxt += "UPDATE STOCKMOVERF" + Environment.NewLine;
                            selectTxt += "SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                            selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                            findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockmoveWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) stockmoveWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else stockmoveWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) stockmoveWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else if (logicalDelCd == 9) stockmoveWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockmoveWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockmoveWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockmoveWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("在庫移動情報の論理削除エラー status={0} エラー情報={1}", status, ex.Message));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫移動情報を物理削除します(在庫移動入力は論理削除に変更したため未使用)
        /// </summary>
        /// <param name="stockMoveWork">在庫移動情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 在庫移動情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int Delete(ref object stockMoveWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retMsg = "";
            string retItemInfo = "";
            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            // 拠点間発注データのDictionaryの初期化
            Dictionary<string, ArrayList> orderDataDic = null;
            // オプション情報の初期化
            int ps = 0;
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

            string resNm = "";           
            try
            {
                ArrayList stockMoveList = null;
                ArrayList stockList = null;             //在庫リスト
                ArrayList stockAcPayHistList = null;    //在庫受払履歴リスト
                ArrayList defStockMoveList = null;      //更新差分在庫移動リスト
                ArrayList defStockList = null;   //更新前在庫リスト

                CustomSerializeArrayList csaList = stockMoveWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫移動マスタ
                            if (wkal[0] is StockMoveWork) stockMoveList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // 出庫システムロック
                ShareCheckInfo bfinfo = new ShareCheckInfo();
                bfinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.BfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(bfinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Delete_ShareCheckLocke_bfinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0) return status = 851;

                // 入庫システムロック
                ShareCheckInfo afinfo = new ShareCheckInfo();
                afinfo.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", _stockMoveWork.AfEnterWarehCode);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    status = this.ShareCheck(afinfo, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.Delete_ShareCheckLocke_afinfo:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != 0) return status = 851;
                // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                ////ＡＰロック
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.Delete:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.Delete:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = Lock(resNm,sqlConnection,sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.Delete_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }

                try
                {
                    // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                    //在庫移動データ削除処理
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        status = DeleteStockMoveProc(stockMoveList, out defStockMoveList, ref sqlConnection, ref sqlTransaction);

                    //在庫系更新用パラメータ作成
                    //データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン

                    //在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.Delete_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    }

                    // システムロック(拠点) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(afinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_afinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: シェアチェック解除前にデータベースに接続できません。", status);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションが終了しています。", status);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: シェアチェック解除前にトランザクションに例外が発生しました。", status);
                    }
                    else
                    {
                        // シェアチェック解除
                        status = this.ShareCheck(bfinfo, LockControl.Release, sqlConnection, sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.Delete_ShareCheckRelease_bfinfo: シェアチェック解除処理に失敗しました。", status);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // システムロック(拠点) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {

                if (sqlTransaction != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 在庫移動情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmoveWorkList">在庫移動情報オブジェクト</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫移動情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用) </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        public int DeleteStockMoveProc(ArrayList stockmoveWorkList, out ArrayList DefstockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockMoveProcProc(stockmoveWorkList, out DefstockMoveWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫移動情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmoveWorkList">在庫移動情報オブジェクト</param>
        /// <param name="DefstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫移動情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用) </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        private int DeleteStockMoveProcProc(ArrayList stockmoveWorkList, out ArrayList DefstockMoveWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            DefstockMoveWorkList = new ArrayList();//更新前後差分用リスト
            string selectTxt = "";

            try
            {

                for (int i = 0; i < stockmoveWorkList.Count; i++)
                {
                    StockMoveWork stockmoveWork = stockmoveWorkList[i] as StockMoveWork;

                    //OutputClcLog(string.Format("伝票削除情報 在庫移動伝票={0}", stockmoveWork.StockMoveSlipNo));// DEL BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    // -- UPD 2010/06/16 ---------------------------------->>>
                    //selectTxt += "  STOCKM.UPDATEDATETIMERF" + Environment.NewLine;
                    //selectTxt += " ,STOCKM.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += " ,STOCKM.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "  *" + Environment.NewLine;
                    // -- UPD 2010/06/16 ----------------------------------<<<
                    selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                    selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                    SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                    SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                    findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                    findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                    findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockmoveWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        // -- UPD 2010/06/16 ----------------------------------------------->>>
                        //更新前の在庫移動データを取得
                        StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                        defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                        // --- ADD 三戸 2012/07/10 ---------->>>>>
                        defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                        // --- ADD 三戸 2012/07/10 ----------<<<<<

                        DefstockMoveWorkList.Add(defStockMoveWork);
                        // -- UPD 2010/06/16 -----------------------------------------------<<<

                        // -- DEL 2010/06/16 ----------------------------------->>>
                        #region
                        //#region 在庫リスト→在庫差分リスト
                        //StockMoveWork defStockMoveWork = new StockMoveWork();
                        //defStockMoveWork.CreateDateTime = stockmoveWork.CreateDateTime;
                        //defStockMoveWork.UpdateDateTime = stockmoveWork.UpdateDateTime;
                        //defStockMoveWork.EnterpriseCode = stockmoveWork.EnterpriseCode;
                        //defStockMoveWork.FileHeaderGuid = stockmoveWork.FileHeaderGuid;
                        //defStockMoveWork.UpdEmployeeCode = stockmoveWork.UpdEmployeeCode;
                        //defStockMoveWork.UpdAssemblyId1 = stockmoveWork.UpdAssemblyId1;
                        //defStockMoveWork.UpdAssemblyId2 = stockmoveWork.UpdAssemblyId2;
                        //defStockMoveWork.LogicalDeleteCode = stockmoveWork.LogicalDeleteCode;
                        //defStockMoveWork.StockMoveFormal = stockmoveWork.StockMoveFormal;
                        //defStockMoveWork.StockMoveSlipNo = stockmoveWork.StockMoveSlipNo;
                        //defStockMoveWork.StockMoveRowNo = stockmoveWork.StockMoveRowNo;
                        //defStockMoveWork.UpdateSecCd = stockmoveWork.UpdateSecCd;
                        //defStockMoveWork.BfSectionCode = stockmoveWork.BfSectionCode;
                        //defStockMoveWork.BfSectionGuideSnm = stockmoveWork.BfSectionGuideSnm;
                        //defStockMoveWork.BfEnterWarehCode = stockmoveWork.BfEnterWarehCode;
                        //defStockMoveWork.BfEnterWarehName = stockmoveWork.BfEnterWarehName;
                        //defStockMoveWork.AfSectionCode = stockmoveWork.AfSectionCode;
                        //defStockMoveWork.AfSectionGuideSnm = stockmoveWork.AfSectionGuideSnm;
                        //defStockMoveWork.AfEnterWarehCode = stockmoveWork.AfEnterWarehCode;
                        //defStockMoveWork.AfEnterWarehName = stockmoveWork.AfEnterWarehName;
                        //defStockMoveWork.ShipmentScdlDay = stockmoveWork.ShipmentScdlDay;
                        //defStockMoveWork.ShipmentFixDay = stockmoveWork.ShipmentFixDay;
                        //defStockMoveWork.ArrivalGoodsDay = stockmoveWork.ArrivalGoodsDay;
                        //defStockMoveWork.InputDay = stockmoveWork.InputDay;
                        //defStockMoveWork.MoveStatus = stockmoveWork.MoveStatus;
                        //defStockMoveWork.StockMvEmpCode = stockmoveWork.StockMvEmpCode;
                        //defStockMoveWork.StockMvEmpName = stockmoveWork.StockMvEmpName;
                        //defStockMoveWork.ShipAgentCd = stockmoveWork.ShipAgentCd;
                        //defStockMoveWork.ShipAgentNm = stockmoveWork.ShipAgentNm;
                        //defStockMoveWork.ReceiveAgentCd = stockmoveWork.ReceiveAgentCd;
                        //defStockMoveWork.ReceiveAgentNm = stockmoveWork.ReceiveAgentNm;
                        //defStockMoveWork.SupplierCd = stockmoveWork.SupplierCd;
                        //defStockMoveWork.SupplierSnm = stockmoveWork.SupplierSnm;
                        //defStockMoveWork.GoodsMakerCd = stockmoveWork.GoodsMakerCd;
                        //defStockMoveWork.MakerName = stockmoveWork.MakerName;
                        //defStockMoveWork.GoodsNo = stockmoveWork.GoodsNo;
                        //defStockMoveWork.GoodsName = stockmoveWork.GoodsName;
                        //defStockMoveWork.GoodsNameKana = stockmoveWork.GoodsNameKana;
                        //defStockMoveWork.StockDiv = stockmoveWork.StockDiv;
                        //defStockMoveWork.StockUnitPriceFl = stockmoveWork.StockUnitPriceFl;
                        //defStockMoveWork.TaxationDivCd = stockmoveWork.TaxationDivCd;
                        //defStockMoveWork.MoveCount = stockmoveWork.MoveCount;
                        //defStockMoveWork.BfShelfNo = stockmoveWork.BfShelfNo;
                        //defStockMoveWork.AfShelfNo = stockmoveWork.AfShelfNo;
                        //defStockMoveWork.BLGoodsCode = stockmoveWork.BLGoodsCode;
                        //defStockMoveWork.BLGoodsFullName = stockmoveWork.BLGoodsFullName;
                        //defStockMoveWork.ListPriceFl = stockmoveWork.ListPriceFl;
                        //defStockMoveWork.Outline = stockmoveWork.Outline;
                        //defStockMoveWork.WarehouseNote1 = stockmoveWork.WarehouseNote1;
                        //defStockMoveWork.SlipPrintFinishCd = stockmoveWork.SlipPrintFinishCd;
                        //defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice;
                        //DefstockMoveWorkList.Add(defStockMoveWork);
                        //#endregion
                        #endregion
                        // -- DEL 2010/06/16 -----------------------------------<<<

                        selectTxt = "";
                        selectTxt += "DELETE FROM STOCKMOVERF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        selectTxt += " AND STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;
                        sqlCommand.CommandText = selectTxt;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                    }
                    else
                    {
                        #region 在庫リスト→在庫差分リスト
                        StockMoveWork defStockMoveWork = new StockMoveWork();
                        defStockMoveWork.CreateDateTime = stockmoveWork.CreateDateTime;
                        defStockMoveWork.UpdateDateTime = stockmoveWork.UpdateDateTime;
                        defStockMoveWork.EnterpriseCode = stockmoveWork.EnterpriseCode;
                        defStockMoveWork.FileHeaderGuid = stockmoveWork.FileHeaderGuid;
                        defStockMoveWork.UpdEmployeeCode = stockmoveWork.UpdEmployeeCode;
                        defStockMoveWork.UpdAssemblyId1 = stockmoveWork.UpdAssemblyId1;
                        defStockMoveWork.UpdAssemblyId2 = stockmoveWork.UpdAssemblyId2;
                        defStockMoveWork.LogicalDeleteCode = stockmoveWork.LogicalDeleteCode;
                        defStockMoveWork.StockMoveFormal = stockmoveWork.StockMoveFormal;
                        defStockMoveWork.StockMoveSlipNo = stockmoveWork.StockMoveSlipNo;
                        defStockMoveWork.StockMoveRowNo = stockmoveWork.StockMoveRowNo;
                        defStockMoveWork.UpdateSecCd = stockmoveWork.UpdateSecCd;
                        defStockMoveWork.BfSectionCode = stockmoveWork.BfSectionCode;
                        defStockMoveWork.BfSectionGuideSnm = stockmoveWork.BfSectionGuideSnm;
                        defStockMoveWork.BfEnterWarehCode = stockmoveWork.BfEnterWarehCode;
                        defStockMoveWork.BfEnterWarehName = stockmoveWork.BfEnterWarehName;
                        defStockMoveWork.AfSectionCode = stockmoveWork.AfSectionCode;
                        defStockMoveWork.AfSectionGuideSnm = stockmoveWork.AfSectionGuideSnm;
                        defStockMoveWork.AfEnterWarehCode = stockmoveWork.AfEnterWarehCode;
                        defStockMoveWork.AfEnterWarehName = stockmoveWork.AfEnterWarehName;
                        defStockMoveWork.ShipmentScdlDay = stockmoveWork.ShipmentScdlDay;
                        defStockMoveWork.ShipmentFixDay = stockmoveWork.ShipmentFixDay;
                        defStockMoveWork.ArrivalGoodsDay = stockmoveWork.ArrivalGoodsDay;
                        defStockMoveWork.InputDay = stockmoveWork.InputDay;
                        defStockMoveWork.MoveStatus = stockmoveWork.MoveStatus;
                        defStockMoveWork.StockMvEmpCode = stockmoveWork.StockMvEmpCode;
                        defStockMoveWork.StockMvEmpName = stockmoveWork.StockMvEmpName;
                        defStockMoveWork.ShipAgentCd = stockmoveWork.ShipAgentCd;
                        defStockMoveWork.ShipAgentNm = stockmoveWork.ShipAgentNm;
                        defStockMoveWork.ReceiveAgentCd = stockmoveWork.ReceiveAgentCd;
                        defStockMoveWork.ReceiveAgentNm = stockmoveWork.ReceiveAgentNm;
                        defStockMoveWork.SupplierCd = stockmoveWork.SupplierCd;
                        defStockMoveWork.SupplierSnm = stockmoveWork.SupplierSnm;
                        defStockMoveWork.GoodsMakerCd = stockmoveWork.GoodsMakerCd;
                        defStockMoveWork.MakerName = stockmoveWork.MakerName;
                        defStockMoveWork.GoodsNo = stockmoveWork.GoodsNo;
                        defStockMoveWork.GoodsName = stockmoveWork.GoodsName;
                        defStockMoveWork.GoodsNameKana = stockmoveWork.GoodsNameKana;
                        defStockMoveWork.StockDiv = stockmoveWork.StockDiv;
                        defStockMoveWork.StockUnitPriceFl = stockmoveWork.StockUnitPriceFl;
                        defStockMoveWork.TaxationDivCd = stockmoveWork.TaxationDivCd;
                        defStockMoveWork.MoveCount = 0;
                        defStockMoveWork.BfShelfNo = stockmoveWork.BfShelfNo;
                        defStockMoveWork.AfShelfNo = stockmoveWork.AfShelfNo;
                        defStockMoveWork.BLGoodsCode = stockmoveWork.BLGoodsCode;
                        defStockMoveWork.BLGoodsFullName = stockmoveWork.BLGoodsFullName;
                        defStockMoveWork.ListPriceFl = stockmoveWork.ListPriceFl;
                        defStockMoveWork.Outline = stockmoveWork.Outline;
                        defStockMoveWork.WarehouseNote1 = stockmoveWork.WarehouseNote1;
                        defStockMoveWork.SlipPrintFinishCd = stockmoveWork.SlipPrintFinishCd;
                        defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice;
                        DefstockMoveWorkList.Add(defStockMoveWork);
                        #endregion

                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                OutputClcLog(string.Format("入荷伝票の削除エラー status={0} エラー情報={1}", status, ex.Message));// ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="stockMoveWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// <br>Update Note: 2012/05/22 wangf </br>
        /// <br>           : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMoveSlipSearchCondWork stockMoveWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "STOCKM.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCKM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCKM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //更新拠点コード
            if (stockMoveWork.SectionCode != "")
            {
                retstring += "AND STOCKM.UPDATESECCDRF=@UPDATESECCD ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.SectionCode);
            }

            //在庫移動伝票番号
            if (stockMoveWork.StockMoveSlipNo > 0)
            {
                retstring += "AND STOCKM.STOCKMOVESLIPNORF=@STOCKMOVESLIPNO ";
                SqlParameter paraStockMoveSlipNo = sqlCommand.Parameters.Add("@STOCKMOVESLIPNO", SqlDbType.Int);
                paraStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockMoveWork.StockMoveSlipNo);
            }

            //在庫移動入力従業員コード
            if (stockMoveWork.StockMvEmpCode != "")
            {
                retstring += "AND STOCKMVEMPCODERF=@STOCKMVEMPCODE ";
                SqlParameter paraStockMvEmpCode = sqlCommand.Parameters.Add("@STOCKMVEMPCODE", SqlDbType.NChar);
                paraStockMvEmpCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.StockMvEmpCode);
            }

            //出荷担当従業員コード
            if (stockMoveWork.ShipAgentCd != "")
            {
                retstring += "AND SHIPAGENTCDRF=@SHIPAGENTCD ";
                SqlParameter paraShipAgentCd = sqlCommand.Parameters.Add("@SHIPAGENTCD", SqlDbType.NChar);
                paraShipAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ShipAgentCd);
            }

            //引取担当従業員コード
            if (stockMoveWork.ReceiveAgentCd != "")
            {
                retstring += "AND RECEIVEAGENTCDRF=@RECEIVEAGENTCD ";
                SqlParameter paraReceiveAgentCd = sqlCommand.Parameters.Add("@RECEIVEAGENTCD", SqlDbType.NChar);
                paraReceiveAgentCd.Value = SqlDataMediator.SqlSetString(stockMoveWork.ReceiveAgentCd);
            }

            //出荷予定開始日
            if (stockMoveWork.ShipmentScdlStDay != DateTime.MinValue)
            {
                retstring += "AND SHIPMENTSCDLDAYRF>=@SHIPMENTSCDLSTDAY ";
                SqlParameter paraShipmentScdlStDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLSTDAY", SqlDbType.Int);
                paraShipmentScdlStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentScdlStDay);
            }

            //出荷予定終了日
            if (stockMoveWork.ShipmentScdlEdDay != DateTime.MinValue)
            {
                retstring += "AND SHIPMENTSCDLDAYRF<=@SHIPMENTSCDLEDDAY ";
                SqlParameter paraShipmentScdlEdDay = sqlCommand.Parameters.Add("@SHIPMENTSCDLEDDAY", SqlDbType.Int);
                paraShipmentScdlEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentScdlEdDay);
            }

            //移動元拠点コード
            if (stockMoveWork.BfSectionCode != "")
            {                                 
                retstring += "AND BFSECTIONCODERF=@BFSECTIONCODE ";
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfSectionCode);
            }

            //移動元倉庫コード
            if (stockMoveWork.BfEnterWarehCode != "")
            {
                retstring += "AND BFENTERWAREHCODERF=@BFENTERWAREHCODE ";
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.BfEnterWarehCode);
            }

            //移動先拠点コード
            if (stockMoveWork.AfSectionCode != "")
            {
                retstring += "AND AFSECTIONCODERF=@AFSECTIONCODE ";
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfSectionCode);
            }

            //移動先倉庫コード
            if (stockMoveWork.AfEnterWarehCode != "")
            {
                retstring += "AND AFENTERWAREHCODERF=@AFENTERWAREHCODE ";
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockMoveWork.AfEnterWarehCode);
            }
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //出荷確定日
            if (stockMoveWork.CallerFunction == 1 && stockMoveWork.StockMoveFixCode == 2 )
            {
                //出荷確定or入荷開始日
                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                {
                    retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2 AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF>=@SHIPMENTFIXSTDAY))) ";
                    SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                    paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                }

                //出荷確定or入荷終了日
                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                {
                    retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2 AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF<=@SHIPMENTFIXEDDAY))) ";
                    SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                    paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                }
                return retstring;
            }
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (stockMoveWork.MoveStatus != null)
                {
                    wkstring = "";
                    foreach (int str in stockMoveWork.MoveStatus)
                    {
                        if (stockMoveWork.MoveStatus.Length == 1)
                        {
                            if (str == 9)
                            {
                                //入荷開始日
                                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                                {
                                    retstring += "AND ARRIVALGOODSDAYRF>=@ARRIVALGOODSSTDAY ";
                                    SqlParameter paraArrivalGoodsStDay = sqlCommand.Parameters.Add("@ARRIVALGOODSSTDAY", SqlDbType.Int);
                                    paraArrivalGoodsStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                                }

                                //入荷終了日
                                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                                {
                                    retstring += "AND ARRIVALGOODSDAYRF<=@ARRIVALGOODSEDDAY ";
                                    SqlParameter paraArrivalGoodsEdDay = sqlCommand.Parameters.Add("@ARRIVALGOODSEDDAY", SqlDbType.Int);
                                    paraArrivalGoodsEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                                }
                            }
                            else
                            {
                                //出荷確定開始日
                                if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                                {
                                    retstring += "AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY ";
                                    SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                                    paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                                }

                                //出荷確定終了日
                                if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                                {
                                    retstring += "AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY ";
                                    SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                                    paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                                }
                            }
                        }
                        else
                        {
                            //出荷確定or入荷開始日
                            if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                            {
                                retstring += "AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF>=@SHIPMENTFIXSTDAY)))";
                                SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                                paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                            }

                            //出荷確定or入荷終了日
                            if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                            {
                                retstring += "AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY) OR (((STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) AND ARRIVALGOODSDAYRF<=@SHIPMENTFIXEDDAY))) ";
                                SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                                paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    //出荷確定開始日
                    if (stockMoveWork.ShipmentFixStDay != DateTime.MinValue)
                    {
                        retstring += "AND SHIPMENTFIXDAYRF>=@SHIPMENTFIXSTDAY ";
                        SqlParameter paraShipmentFixStDay = sqlCommand.Parameters.Add("@SHIPMENTFIXSTDAY", SqlDbType.Int);
                        paraShipmentFixStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixStDay);
                    }

                    //出荷確定終了日
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND SHIPMENTFIXDAYRF<=@SHIPMENTFIXEDDAY ";
                        SqlParameter paraShipmentFixEdDay = sqlCommand.Parameters.Add("@SHIPMENTFIXEDDAY", SqlDbType.Int);
                        paraShipmentFixEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    //入荷開始日
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND ARRIVALGOODSDAYRF>=@ARRIVALGOODSSTDAY ";
                        SqlParameter paraArrivalGoodsStDay = sqlCommand.Parameters.Add("@ARRIVALGOODSSTDAY", SqlDbType.Int);
                        paraArrivalGoodsStDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }

                    //入荷終了日
                    if (stockMoveWork.ShipmentFixEdDay != DateTime.MinValue)
                    {
                        retstring += "AND ARRIVALGOODSDAYRF<=@ARRIVALGOODSEDDAY ";
                        SqlParameter paraArrivalGoodsEdDay = sqlCommand.Parameters.Add("@ARRIVALGOODSEDDAY", SqlDbType.Int);
                        paraArrivalGoodsEdDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockMoveWork.ShipmentFixEdDay);
                    }
                }
            }

            // 伝票呼出
            // 入荷確定あり
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    retstring += " AND (STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2 ";
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    //移動状態
                    if (stockMoveWork.MoveStatus != null)
                    {
                        wkstring = "";
                        foreach (int str in stockMoveWork.MoveStatus)
                        {
                            if (stockMoveWork.MoveStatus.Length == 1)
                            {

                                if (str == 2)
                                    retstring += " AND (STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2 ";
                                else if (str == 9)
                                    retstring += " AND (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) ";
                            }
                            else
                            {
                                retstring += " AND (((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF = 2) OR (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4))" ;
                                break;
                            }
                        }
                    }
                }
            }
            // 入荷確定なし
            else
            {
                if (stockMoveWork.SlipDiv == 1)
                {
                    retstring += " AND ((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2) ";
                }
                else if (stockMoveWork.SlipDiv == 2)
                {
                    retstring += " AND (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4) ";
                }
                else if (stockMoveWork.SlipDiv == -1)
                {
                    retstring += " AND ( ((STOCKMOVEFORMALRF = 1 OR STOCKMOVEFORMALRF = 2) AND MOVESTATUSRF != 2) OR (STOCKMOVEFORMALRF = 3 OR STOCKMOVEFORMALRF = 4)) ";
                }
            }

            /*
            //移動状態
            if (stockMoveWork.MoveStatus != null)
            {
                wkstring = "";
                foreach (int str in stockMoveWork.MoveStatus)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND MOVESTATUSRF IN (" + wkstring + ") ";
                }

            }
            */
            
            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMoveWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMoveWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        private StockMoveWork CopyToStockMoveWorkFromReader(ref SqlDataReader myReader)
        {
            StockMoveWork wkStockMoveWork = new StockMoveWork();

            #region クラスへ格納
            wkStockMoveWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockMoveWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockMoveWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockMoveWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockMoveWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockMoveWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockMoveWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockMoveWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockMoveWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));
            wkStockMoveWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            wkStockMoveWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            wkStockMoveWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            wkStockMoveWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
            wkStockMoveWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            wkStockMoveWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            wkStockMoveWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            wkStockMoveWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
            wkStockMoveWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            wkStockMoveWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            wkStockMoveWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            wkStockMoveWork.ShipmentScdlDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
            wkStockMoveWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            wkStockMoveWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockMoveWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockMoveWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            wkStockMoveWork.StockMvEmpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
            wkStockMoveWork.StockMvEmpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
            wkStockMoveWork.ShipAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTCDRF"));
            wkStockMoveWork.ShipAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPAGENTNMRF"));
            wkStockMoveWork.ReceiveAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTCDRF"));
            wkStockMoveWork.ReceiveAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVEAGENTNMRF"));
            wkStockMoveWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockMoveWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockMoveWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockMoveWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockMoveWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockMoveWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockMoveWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkStockMoveWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockMoveWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockMoveWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkStockMoveWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            wkStockMoveWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            wkStockMoveWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            wkStockMoveWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockMoveWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockMoveWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
            wkStockMoveWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            wkStockMoveWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
            wkStockMoveWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            wkStockMoveWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
            #endregion

            return wkStockMoveWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            StockMoveWork[] StockMoveWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is StockMoveWork)
                    {
                        StockMoveWork wkStockMoveWork = paraobj as StockMoveWork;
                        if (wkStockMoveWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkStockMoveWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            StockMoveWorkArray = (StockMoveWork[])XmlByteSerializer.Deserialize(byteArray, typeof(StockMoveWork[]));
                        }
                        catch (Exception) { }
                        if (StockMoveWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(StockMoveWorkArray);
                        }
                        else
                        {
                            try
                            {
                                StockMoveWork wkStockMoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(byteArray, typeof(StockMoveWork));
                                if (wkStockMoveWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkStockMoveWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region 在庫移動データ→在庫データ・在庫受払履歴データ
        
        /// <summary>
        /// データ変換(生成)処理
        /// </summary>
        /// <param name="procMode">処理区分</param>
        /// <param name="createHisData">受払履歴作成区分</param>
        /// <param name="stockMoveFormal">在庫移動形式</param>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="stockMoveList">在庫移動リスト</param>
        /// <param name="bFStockMoveList">更新前在庫移動リスト</param>
        /// <param name="defStockList">在庫差分リスト</param>
        /// <param name="defStockMoveList">在庫移動差分リスト</param>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="stockAcPayHistList">在庫受払履歴リスト</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="ps">ps</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2010/11/15 曹文傑</br>
        /// <br>             障害改良対応ｘ月「２」の対応</br>
        //private int TransStockMoveToStock(int procMode, bool createHisData, int stockMoveFormal, int stockMoveSlipNo, ArrayList stockMoveList, ArrayList defStockMoveList, ArrayList bFStockMoveList, ArrayList defStockList, out ArrayList stockList, out ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL K2013/12/25 鄧潘ハン
        private int TransStockMoveToStock(int procMode, bool createHisData, int stockMoveFormal, int stockMoveSlipNo, ArrayList stockMoveList, ArrayList defStockMoveList, ArrayList bFStockMoveList, ArrayList defStockList, out ArrayList stockList, out ArrayList stockAcPayHistList, Dictionary<string, ArrayList> orderDataDic, int ps, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD K2013/12/25 鄧潘ハン
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockList = new ArrayList();            //在庫リスト
            stockAcPayHistList = new ArrayList();   //在庫受払履歴リスト
            Dictionary<string, StockWork> BfStockDic = new Dictionary<string, StockWork>();
            Dictionary<string, StockWork> AfStockDic = new Dictionary<string, StockWork>();

            ArrayList originBfStockList = new ArrayList();

            //---元データの確認---
            if (stockMoveList == null) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (stockMoveList.Count <= 0) return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ////在庫移動リストのソート
            StockMoveWorkComparer stockMoveWorkComparer = new StockMoveWorkComparer();
            stockMoveList.Sort(stockMoveWorkComparer);
            defStockMoveList.Sort(stockMoveWorkComparer);
            if (bFStockMoveList != null)
                bFStockMoveList.Sort(stockMoveWorkComparer);
            //現在の移動ステータスを取得
            int moveStatus = ((StockMoveWork)((ArrayList)stockMoveList)[0]).MoveStatus;

            //在庫移動データをループ
            for (int j = 0; j < stockMoveList.Count; j++)
            {
                //在庫移動キャスト（在庫移動リストから）
                StockMoveWork wkStockMoveWork = stockMoveList[j] as StockMoveWork;
                // ---ADD 2010/11/15---------------->>>>>
                // 明細項目を何も変更しない場合(在庫受払データ作成区分=１)、在庫受払履歴データ作成しない
                if (wkStockMoveWork.CreateHistDiv == 1)
                {
                    createHisData = false;
                }
                else
                {
                    createHisData = true;
                }
                // ---ADD 2010/11/15----------------<<<<<

                //在庫移動キャスト（在庫移動差分リストから）
                StockMoveWork wkdefStockMoveWork = new StockMoveWork();
                if (defStockMoveList.Count > j)
                    wkdefStockMoveWork = defStockMoveList[j] as StockMoveWork;

                StockMoveWork wkbfStockMoveWork = new StockMoveWork();
                if (bFStockMoveList != null && bFStockMoveList.Count > j)
                    wkbfStockMoveWork = bFStockMoveList[j] as StockMoveWork;

                //在庫受払履歴データ作成
                if (createHisData)
                {
                    MakeStockAcPayList(ref stockAcPayHistList, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal, sqlConnection, sqlTransaction);
                }

                // 在庫マスタ情報作成
                //MakeStockList(ref stockList, ref BfStockDic, ref AfStockDic, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                MakeStockList(ref stockList, ref BfStockDic, ref AfStockDic, wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン

                #region DELETE
                /*
                else //倉庫移動
                    {

                        StockWork originStockWork = null;
                        //移動元用在庫データ作成
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originStockWork, stockMngTtlStWork, wkdefStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkBfStockWork), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, stockMngTtlStWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }

                        //移動先用在庫データ作成
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode, null);
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkAfStockWork), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkdefStockMoveWork)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                        }

                    }
                
                }
                */
                #endregion
            }
            return status;
            
        }

        /// <summary>
        /// 在庫マスタ情報作成処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2016/04/26 周健</br>
        /// <br>             Redmine#48729 在庫移動入力の入荷取消障害の対応</br>
        /// </remarks>
        //private void MakeStockList(ref ArrayList stockList, ref Dictionary<string, StockWork> BfStockDic, ref Dictionary<string, StockWork> AfStockDic, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL K2013/12/25 鄧潘ハン
        private void MakeStockList(ref ArrayList stockList, ref Dictionary<string, StockWork> BfStockDic, ref Dictionary<string, StockWork> AfStockDic, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, Dictionary<string, ArrayList> orderDataDic, int ps, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD K2013/12/25 鄧潘ハン
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //在庫データの取得
            //移動元の在庫データ
            StockWork originBfStockWork = new StockWork();
            originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
            //originBfStockWork.SectionCode = wkdefStockMoveWork.BfSectionCode;
            originBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
            originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
            originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
            status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

            if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived && wkdefStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//入荷処理
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)   //在庫マスタが存在しない場合も新規作成するように修正
                {

                    //移動元用在庫データ作成
                    if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 0)))
                    {
                        StockWork retStockWork = null;
                        StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originBfStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        stockList.Add(wkBfStockWork);
                        BfStockDic.Add(CreateKeyString(wkStockMoveWork, 0), wkBfStockWork);
                    }
                    else
                    {
                        StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork, 0)] as StockWork;
                        wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originBfStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                    }

                    // --- ADD 2012/10/02 y.wakita ----->>>>>
                    //在庫データの取得
                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                    {
                        //移動先の在庫データ
                        originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        //originBfStockWork.SectionCode = wkdefStockMoveWork.AfSectionCode;
                        originBfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 1) && (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                    // --- ADD 2012/10/02 y.wakita -----<<<<<

                        //移動先用在庫データ作成
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 鄧潘ハン
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 鄧潘ハン  
                        }
                        // --- ADD 2012/10/02 y.wakita ----->>>>>
                    }
                    // --- ADD 2012/10/02 y.wakita -----<<<<<
                }
                else
                {
                    // --- ADD 2012/10/02 y.wakita ----->>>>>
                    //在庫データの取得
                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                    {
                        //移動先の在庫データ
                        originBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        //originBfStockWork.SectionCode = wkdefStockMoveWork.AfSectionCode;
                        originBfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        originBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        originBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        status = _stockDB.ReadProc(ref originBfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    // --- ADD 2012/10/02 y.wakita -----<<<<<

                    // --- ADD 三戸 2012/07/10 ---------->>>>>
                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (wkStockMoveWork.MoveStockAutoInsDiv == 0)
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 1) && (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        // --- ADD 三戸 2012/07/10 ----------<<<<<

                        //入荷時に移動先の在庫データが存在しない場合は新規作成する()
                        originBfStockWork = null;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        //移動先用在庫データ作成
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 鄧潘ハン
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, wkStockMoveWork.MoveStatus, procMode, originBfStockWork);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 2);// ADD K2013/12/25 鄧潘ハン
                        }
                        // --- ADD 三戸 2012/07/10 ---------->>>>>
                    }
                    // --- ADD 三戸 2012/07/10 ----------<<<<<
                }

            }
            else if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && wkdefStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)//入荷キャンセル
            {

                    StockWork originStockWork = null;

                    // --- ADD 三戸 2012/07/10 ---------->>>>>
                    // 移動時在庫自動登録区分＝「1:しない」の場合、
                    // 在庫データの存在チェックを行い、
                    // 在庫がない場合は在庫データを作成しないように修正
                    int bfstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //移動元の在庫データ
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    if (bfstockstatus == 0)
                    {
                        // --- ADD 三戸 2012/07/10 ----------<<<<<
                        //移動元用在庫データ作成
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 0)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete);
                        }
                        // --- ADD 三戸 2012/07/10 ---------->>>>>
                    }
                    // --- ADD 三戸 2012/07/10 ----------<<<<<

                    // --- ADD 三戸 2012/07/10 ---------->>>>>
                    // 移動時在庫自動登録区分＝「1:しない」の場合、
                    // 在庫データの存在チェックを行い、
                    // 在庫がない場合は在庫データを作成しないように修正
                    int afstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //移動先の在庫データ
                        StockWork writeAfStockWork = new StockWork();
                        writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (bfstockstatus == 0)
                    if (afstockstatus == 0)
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        // --- ADD 三戸 2012/07/10 ----------<<<<<
                        //移動先用在庫データ作成
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkStockMoveWork, wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 1);// ADD K2013/12/25 鄧潘ハン  
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            //wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork,
                              //wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);  DEL 2016/4/26 周健 Redmine#48729 入荷取消した後現在庫数が更新されない障害対応
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkStockMoveWork, 
                                wkdefStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);// ADD 2016/4/26 周健 Redmine#48729 入荷取消した後現在庫数が更新されない障害対応
                            SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 1);// ADD K2013/12/25 鄧潘ハン 
                        }
                    // --- ADD 三戸 2012/07/10 ---------->>>>>
                    }
                    // --- ADD 三戸 2012/07/10 ----------<<<<<
            }
            #region DELETE
            //else if (wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment && wkbfStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//確定取消
            //{
            //    StockWork originStockWork = null;

            //    //移動元用在庫データ作成
            //    if (!BfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork)))
            //    {
            //        StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkStockMoveWork, originStockWork, wkbfStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
            //        stockList.Add(wkBfStockWork);
            //        BfStockDic.Add(CreateKeyString(wkBfStockWork), wkBfStockWork);
            //    }
            //    else
            //    {
            //        StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkStockMoveWork)] as StockWork;
            //        wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkStockMoveWork, originStockWork, wkbfStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
            //    }
            //}
            #endregion
            else
            {
                StockWork originStockWork = null;

                if (wkStockMoveWork.StockMoveFixCode == 1)
                {
                    // --- ADD 三戸 2012/07/05 ---------->>>>>
                    // 移動時在庫自動登録区分＝「1:しない」の場合、
                    // 在庫データの存在チェックを行い、
                    // 在庫がない場合は在庫データを作成しないように修正
                    int bfstockstatus = 0;

                    if (wkStockMoveWork.MoveStockAutoInsDiv == 1 && _isRecv == false)
                    {
                        //移動元の在庫データ
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    if (bfstockstatus == 0)
                    {
                        // --- ADD 三戸 2012/07/05 ----------<<<<<

                        //移動元用在庫データ作成
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork, 0)))
                        {
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }
                        // --- ADD 三戸 2012/07/05 ---------->>>>>
                    }
                    // --- ADD 三戸 2012/07/05 ----------<<<<<


                    // -------ADD K2013/12/25 鄧潘ハン -------------------------------------------->>>>>

                    if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count>0)
                    {
                        int afstockstatus = 0;

                        // 移動時在庫自動登録区分＝「1:しない」の場合は、在庫データの存在チェックを行うように
                        if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                        {
                            //移動先の在庫データ
                            StockWork writeAfStockWork = new StockWork();
                            writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                            writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                            writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                            writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                            afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                        }

                        if ((afstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                        {
                            //移動先用在庫データ作成
                            if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                            {
                                StockWork retStockWork = null;
                                StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkdefStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode /*(int)ct_ProcMode.Delete*/, null);
                                if (procMode == (int)ct_ProcMode.Delete)
                                {
                                    SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 3);
                                }
                                stockList.Add(wkAfStockWork);
                                AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                            }
                            else
                            {
                                StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                                if (procMode == (int)ct_ProcMode.Delete)
                                {
                                    SalesOrderCountSet(ref wkAfStockWork, wkStockMoveWork, ref orderDataDic, ps, 3);
                                }
                                wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkdefStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                            }
                        }
                    
                    }
                    // -------ADD 2013/12/25 鄧潘ハン --------------------------------------------<<<<<
                }
                else
                {
                    int bfstockstatus = 0;

                    //if (wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3)//DEL 2011/09/05 ①#24187受信側の拠点に対象のマスタが登録されていない場合の不具合について
                    // --- UPD 三戸 2012/07/05 ---------->>>>>
                    //if ((wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)//ADD 2011/09/05 ①#24187受信側の拠点に対象のマスタが登録されていない場合の不具合について
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                    // 移動時在庫自動登録区分＝「1:しない」の場合は、在庫データの存在チェックを行うように、条件を修正
                    // --- UPD 三戸 2012/07/05 ----------<<<<<
                    {
                        //移動元の在庫データ
                        StockWork writeBfStockWork = new StockWork();
                        writeBfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeBfStockWork.WarehouseCode = wkdefStockMoveWork.BfEnterWarehCode;
                        writeBfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeBfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        bfstockstatus = _stockDB.ReadProc(ref writeBfStockWork, 0, ref sqlConnection, ref sqlTransaction);

                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (bfstockstatus == 0)
                    if ((bfstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        //移動元用在庫データ作成
                        if (!BfStockDic.ContainsKey(CreateKeyString(wkdefStockMoveWork, 0)))
                        {
                            StockWork wkBfStockWork = CopyBfStockWorkFromStockMoveWork(null, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                            stockList.Add(wkBfStockWork);
                            BfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 0), wkBfStockWork);
                        }
                        else
                        {
                            StockWork wkBfStockWork = BfStockDic[CreateKeyString(wkdefStockMoveWork, 0)] as StockWork;
                            wkBfStockWork = CopyBfStockWorkFromStockMoveWork(wkBfStockWork, wkdefStockMoveWork, originStockWork, wkStockMoveWork.MoveStatus, wkdefStockMoveWork.MoveStatus, procMode);
                        }
                    }


                    int afstockstatus = 0;

                    //if (wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3)//DEL 2011/09/05 ①#24187受信側の拠点に対象のマスタが登録されていない場合の不具合について
                    // --- UPD 三戸 2012/07/05 ---------->>>>>
                    //if ((wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)//ADD 2011/09/05 ①#24187受信側の拠点に対象のマスタが登録されていない場合の不具合について
                    if ((wkStockMoveWork.MoveStockAutoInsDiv == 1 || wkdefStockMoveWork.StockMoveFormal == 1 || wkdefStockMoveWork.StockMoveFormal == 3) && _isRecv == false)
                    // 移動時在庫自動登録区分＝「1:しない」の場合は、在庫データの存在チェックを行うように、条件を修正
                    // --- UPD 三戸 2012/07/05 ----------<<<<<
                    {
                        //移動先の在庫データ
                        StockWork writeAfStockWork = new StockWork();
                        writeAfStockWork.EnterpriseCode = wkdefStockMoveWork.EnterpriseCode;
                        writeAfStockWork.WarehouseCode = wkdefStockMoveWork.AfEnterWarehCode;
                        writeAfStockWork.GoodsMakerCd = wkdefStockMoveWork.GoodsMakerCd;
                        writeAfStockWork.GoodsNo = wkdefStockMoveWork.GoodsNo;
                        afstockstatus = _stockDB.ReadProc(ref writeAfStockWork, 0, ref sqlConnection, ref sqlTransaction);
                    }

                    // --- UPD 2012/10/02 y.wakita ----->>>>>
                    //if (afstockstatus == 0)
                    if ((afstockstatus == 0) || (wkStockMoveWork.MoveStockAutoInsDiv == 0))
                    // --- UPD 2012/10/02 y.wakita -----<<<<<
                    {
                        //移動先用在庫データ作成
                        if (!AfStockDic.ContainsKey(CreateKeyString(wkStockMoveWork, 1)))
                        {
                            StockWork retStockWork = null;
                            StockWork wkAfStockWork = CopyAfStockWorkFromStockMoveWork(retStockWork, wkdefStockMoveWork, wkdefStockMoveWork.MoveStatus, procMode /*(int)ct_ProcMode.Delete*/, null);
                            stockList.Add(wkAfStockWork);
                            AfStockDic.Add(CreateKeyString(wkdefStockMoveWork, 1), wkAfStockWork);
                        }
                        else
                        {
                            StockWork wkAfStockWork = AfStockDic[CreateKeyString(wkStockMoveWork, 1)] as StockWork;
                            wkAfStockWork = CopyAfStockWorkFromStockMoveWork(wkAfStockWork, wkdefStockMoveWork, wkStockMoveWork.MoveStatus, (int)ct_ProcMode.Delete, null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 受払情報作成作成処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2021/08/25 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : BLINCIDENT-2462 現在個数と繰越数が合わない対応</br>
        /// </remarks>
        private void MakeStockAcPayList(ref ArrayList stockAcPayHistList, StockMoveWork wkStockMoveWork, StockMoveWork wkbfStockMoveWork, StockMoveWork wkdefStockMoveWork, int procMode, int stockMoveFormal, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            StockAcPayHistWork wkStockAcPayHistWork = null;

            //移動数、原価、定価、金額が変更された場合のみ受払履歴を作成する(入荷処理、入荷キャンセル、出荷伝票削除は無条件作成（修正が出来ないため）)
            if ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) ||
                ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving) && (wkbfStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)) ||
                (procMode == (int)ct_ProcMode.Delete) ||
                (wkStockMoveWork.MoveCount != wkbfStockMoveWork.MoveCount) ||
                (wkStockMoveWork.StockUnitPriceFl != wkbfStockMoveWork.StockUnitPriceFl) ||
                (wkStockMoveWork.ListPriceFl != wkbfStockMoveWork.ListPriceFl) ||
                (wkStockMoveWork.StockMovePrice != wkbfStockMoveWork.StockMovePrice))
            {
                int stockstatus = 0;

                // --- UPD 三戸 2012/07/05 ---------->>>>>
                //if (wkStockMoveWork.StockMoveFixCode == 2 && (stockMoveFormal == 1 || stockMoveFormal == 3))
                // --- UPD 陳艶丹 2021/08/25 BLINCIDENT-2462 現在個数と繰越数が合わない対応 ----->>>>>
                //if ((wkStockMoveWork.MoveStockAutoInsDiv == 1) || (wkStockMoveWork.StockMoveFixCode == 2 && (stockMoveFormal == 1 || stockMoveFormal == 3)))
                //// 移動時在庫自動登録区分＝「1:しない」の場合は、在庫データの存在チェックを行うように、条件を修正
                // 移動時在庫自動登録区分＝「1:しない」の場合、在庫データチェックを行う
                if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                // --- UPD 陳艶丹 2021/08/25 BLINCIDENT-2462 現在個数と繰越数が合わない対応 -----<<<<<
                // --- UPD 三戸 2012/07/05 ----------<<<<<
                {
                    // 在庫マスタRead　なければ、在庫移動の際は新規追加しない
                    StockWork stWork = new StockWork();
                    stWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
                    stWork.WarehouseCode = wkStockMoveWork.BfEnterWarehCode;
                    stWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
                    stWork.GoodsNo = wkStockMoveWork.GoodsNo;

                    stockstatus = _stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);
                }

                if (wkStockMoveWork.StockMoveFormal == 3) wkStockMoveWork.StockMoveFormal = 1;
                else if (wkStockMoveWork.StockMoveFormal == 4) wkStockMoveWork.StockMoveFormal = 2;

                if (stockstatus == 0)
                {
                    // 在庫受払セット値代入
                    wkStockAcPayHistWork = CopyStockAcPayHistWorkFromStockMoveWork(wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
                }
            }

            if (wkStockAcPayHistWork != null)
            {
                stockAcPayHistList.Add(wkStockAcPayHistWork);
            }

            // 入荷確定なしで出庫と入庫の両方を作成
            if (wkStockMoveWork.StockMoveFixCode == 2)
            {
                int stockstatus = 0;

                // --- UPD 三戸 2012/07/05 ---------->>>>>
                //if (wkStockMoveWork.StockMoveFixCode == 2 && (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 3))
                // --- UPD 陳艶丹 2021/08/25 BLINCIDENT-2462 現在個数と繰越数が合わない対応 ----->>>>>
                //if ((wkStockMoveWork.MoveStockAutoInsDiv == 1) || (wkStockMoveWork.StockMoveFixCode == 2 && (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 3)))
                //// 移動時在庫自動登録区分＝「1:しない」の場合は、在庫データの存在チェックを行うように、条件を修正
                // 移動時在庫自動登録区分＝「1:しない」の場合、在庫データチェックを行う
                if (wkStockMoveWork.MoveStockAutoInsDiv == 1)
                // --- UPD 陳艶丹 2021/08/25 BLINCIDENT-2462 現在個数と繰越数が合わない対応 -----<<<<<
                // --- UPD 三戸 2012/07/05 ----------<<<<<
                {
                    // 在庫マスタRead　なければ、在庫移動の際は新規追加しない
                    StockWork stWork = new StockWork();
                    stWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
                    stWork.WarehouseCode = wkStockMoveWork.AfEnterWarehCode;
                    stWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
                    stWork.GoodsNo = wkStockMoveWork.GoodsNo;

                    stockstatus = _stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);
                }
                if (stockstatus == 0)
                {
                    StockMoveWork wareStMvWork = null;
                    StockAcPayHistWork wkStockAcPayHistPlusWork = null;

                    // 出庫or入庫リスト作成処理
                    wareStMvWork = MakeArrivalList(wkStockMoveWork);

                    // 出庫→入庫に変換、入庫→出庫に変換して同一伝票番号で作成
                    wkStockAcPayHistPlusWork = CopyStockAcPayHistWorkFromStockMoveWork(wareStMvWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
                    stockAcPayHistList.Add(wkStockAcPayHistPlusWork);
                }
            }
            
            ////入荷処理の場合は出荷のレコードも作成する
            //if ((wkStockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) && (procMode == (int)ct_ProcMode.Write))
            //{
            //   wkStockAcPayHistWork = CopyStockAcPayHistWorkFromStockMoveWorkPartner(wkStockMoveWork, wkbfStockMoveWork, wkdefStockMoveWork, procMode, stockMoveFormal);
            //   stockAcPayHistList.Add(wkStockAcPayHistWork);
            //}
        }


        /// <summary>
        /// 倉庫移動用同時リスト作成作成処理
        /// </summary>
        /// <returns></returns>
        private StockMoveWork MakeArrivalList(StockMoveWork wkStockMoveWork)
        {
            StockMoveWork wareStMvWork = new StockMoveWork();

            wareStMvWork.AfEnterWarehCode = wkStockMoveWork.AfEnterWarehCode;
            wareStMvWork.AfEnterWarehName = wkStockMoveWork.AfEnterWarehName;
            wareStMvWork.AfSectionCode = wkStockMoveWork.AfSectionCode;
            wareStMvWork.AfSectionGuideSnm = wkStockMoveWork.AfSectionGuideSnm;
            wareStMvWork.AfShelfNo = wkStockMoveWork.AfShelfNo;
            wareStMvWork.ArrivalGoodsDay = wkStockMoveWork.ArrivalGoodsDay;
            wareStMvWork.AutoGoodsInsDiv = wkStockMoveWork.AutoGoodsInsDiv;
            wareStMvWork.BfEnterWarehCode = wkStockMoveWork.BfEnterWarehCode;
            wareStMvWork.BfEnterWarehName = wkStockMoveWork.BfEnterWarehName;
            wareStMvWork.BfSectionCode = wkStockMoveWork.BfSectionCode;
            wareStMvWork.BfSectionGuideSnm = wkStockMoveWork.BfSectionGuideSnm;
            wareStMvWork.BfShelfNo = wkStockMoveWork.BfShelfNo;
            wareStMvWork.BLGoodsCode = wkStockMoveWork.BLGoodsCode;
            wareStMvWork.BLGoodsFullName = wkStockMoveWork.BLGoodsFullName;
            wareStMvWork.CreateDateTime = wkStockMoveWork.CreateDateTime;
            wareStMvWork.EnterpriseCode = wkStockMoveWork.EnterpriseCode;
            wareStMvWork.FileHeaderGuid = wkStockMoveWork.FileHeaderGuid;
            wareStMvWork.GoodsMakerCd = wkStockMoveWork.GoodsMakerCd;
            wareStMvWork.GoodsName = wkStockMoveWork.GoodsName;
            wareStMvWork.GoodsNameKana = wkStockMoveWork.GoodsNameKana;
            wareStMvWork.GoodsNo = wkStockMoveWork.GoodsNo;
            wareStMvWork.InputDay = wkStockMoveWork.InputDay;
            wareStMvWork.ListPriceFl = wkStockMoveWork.ListPriceFl;
            wareStMvWork.LogicalDeleteCode = wkStockMoveWork.LogicalDeleteCode;
            wareStMvWork.MakerName = wkStockMoveWork.MakerName;
            wareStMvWork.MoveCount = wkStockMoveWork.MoveCount;
            wareStMvWork.MoveStatus = wkStockMoveWork.MoveStatus;
            wareStMvWork.Outline = wkStockMoveWork.Outline;
            wareStMvWork.ReceiveAgentCd = wkStockMoveWork.ReceiveAgentCd;
            wareStMvWork.ReceiveAgentNm = wkStockMoveWork.ReceiveAgentNm;
            wareStMvWork.ShipAgentCd = wkStockMoveWork.ShipAgentCd;
            wareStMvWork.ShipAgentNm = wkStockMoveWork.ShipAgentNm;
            wareStMvWork.ShipmentFixDay = wkStockMoveWork.ShipmentFixDay;
            wareStMvWork.ShipmentScdlDay = wkStockMoveWork.ShipmentScdlDay;
            wareStMvWork.SlipPrintFinishCd = wkStockMoveWork.SlipPrintFinishCd;
            wareStMvWork.StockDiv = wkStockMoveWork.StockMoveFixCode;
            wareStMvWork.StockMoveFormal = wkStockMoveWork.StockMoveFormal;
            wareStMvWork.StockMovePrice = wkStockMoveWork.StockMovePrice;
            wareStMvWork.StockMoveRowNo = wkStockMoveWork.StockMoveRowNo;
            wareStMvWork.StockMoveSlipNo = wkStockMoveWork.StockMoveSlipNo;
            wareStMvWork.StockMvEmpCode = wkStockMoveWork.StockMvEmpCode;
            wareStMvWork.StockMvEmpName = wkStockMoveWork.StockMvEmpName;
            wareStMvWork.StockUnitPriceFl = wkStockMoveWork.StockUnitPriceFl;
            wareStMvWork.SupplierCd = wkStockMoveWork.SupplierCd;
            wareStMvWork.SupplierSnm = wkStockMoveWork.SupplierSnm;
            wareStMvWork.TaxationDivCd = wkStockMoveWork.TaxationDivCd;
            wareStMvWork.UpdAssemblyId1 = wkStockMoveWork.UpdAssemblyId1;
            wareStMvWork.UpdAssemblyId2 = wkStockMoveWork.UpdAssemblyId2;
            wareStMvWork.UpdateDateTime = wkStockMoveWork.UpdateDateTime;
            wareStMvWork.UpdateSecCd = wkStockMoveWork.UpdateSecCd;
            wareStMvWork.UpdEmployeeCode = wkStockMoveWork.UpdEmployeeCode;
            wareStMvWork.WarehouseNote1 = wkStockMoveWork.WarehouseNote1;

            // 元が出庫伝票の場合
            if (wkStockMoveWork.StockMoveFormal == 1 || wkStockMoveWork.StockMoveFormal == 2)
            {
                wareStMvWork.MoveStatus = 9;
                if (wareStMvWork.StockMoveFormal == 1) wareStMvWork.StockMoveFormal = 3;
                else wareStMvWork.StockMoveFormal = 4;
               
            }
            // 元が入庫伝票の場合
            else
            {
                wareStMvWork.MoveStatus = 9;
                if (wareStMvWork.StockMoveFormal == 3) wareStMvWork.StockMoveFormal = 1;
                else wareStMvWork.StockMoveFormal = 2;
            }

            return wareStMvWork;
        }
        

        /*
        /// <summary>
        /// 在庫用キー文字列作成処理
        /// </summary>
        /// <param name="stockWork">在庫データ</param>
        /// <returns></returns>
        private string CreateKeyString(StockWork stockWork)
        {
            string retString = "";
            retString =
                stockWork.EnterpriseCode + "-" +
                stockWork.GoodsMakerCd.ToString() + "-" +
                stockWork.GoodsNo
                ;
            return retString;
        }
        */ 

        /// <summary>
        /// 在庫移動データキー文字列作成処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <param name="mode">0:移動元在庫、1:移動先在庫</param>
        /// <returns></returns>
        private string CreateKeyString(StockMoveWork stockMoveWork, int mode)
        {
            string retString = "";
            retString =
                stockMoveWork.EnterpriseCode + "-" +
                stockMoveWork.GoodsMakerCd.ToString() + "-" +
                stockMoveWork.GoodsNo + "-";

               if (mode == 0)
               {
                   retString += stockMoveWork.BfEnterWarehCode.ToString();
               }
               else
               {
                   retString += stockMoveWork.AfEnterWarehCode.ToString();
               }

               return retString;
        }


        // ---- ADD K2013/12/25 鄧潘ハン ---------------------- >>>>>
        /// <summary>
        /// 拠点側の在庫マスタ（StockRF）の発注数の更新
        /// </summary>
        /// <param name="wkAfStockWork">移動先用在庫データ</param>
        /// <param name="wkStockMoveWork">wkStockMoveWork</param>
        /// <param name="orderDataDic">orderDataDic</param>
        /// <param name="ps">ps</param>
        /// <param name="mode">mode 1:取消の場合 2:入庫の場合 3:伝票削除の場合</param>
        /// <remarks>
        /// <br>Note       : 拠点側の在庫マスタ（StockRF）の発注数の更新。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : K2013/12/25</br>
        /// </remarks>
        private void SalesOrderCountSet(ref StockWork wkAfStockWork, StockMoveWork wkStockMoveWork, ref Dictionary<string, ArrayList> orderDataDic, int ps, int mode)
        {
            string orderDataKey = string.Empty;
            double orderDataValue;
            ArrayList secOrderDtList = null;
            if (ps == (int)Option.ON && orderDataDic != null && orderDataDic.Count > 0)
            {
                // key 在庫移動伝票番号と在庫移動行番号
                orderDataKey = wkStockMoveWork.StockMoveSlipNo + "_" + wkStockMoveWork.StockMoveRowNo;

                if (orderDataDic.ContainsKey(orderDataKey))
                {
                    secOrderDtList = orderDataDic[orderDataKey] as ArrayList;
                    // value 拠点引当数
                    orderDataValue = Convert.ToDouble(secOrderDtList[1]);
                    switch (mode)
                    {
                        case 1:
                            {
                                // 取消の場合：発注数＋拠点間発注データ.拠点引当数
                                wkAfStockWork.SalesOrderCount = orderDataValue * 1;
                                secOrderDtList.RemoveAt(2);
                                secOrderDtList.Add(1);
                                break;
                            }
                        case 2:
                            {
                                // 入庫の場合の場合：発注数-拠点間発注データ.拠点引当数
                                wkAfStockWork.SalesOrderCount = orderDataValue * -1;
                                secOrderDtList.RemoveAt(2);
                                secOrderDtList.Add(2);
                                break;
                            }
                        case 3:
                            {
                                // 伝票削除の場合：発注数-拠点間発注データ.拠点引当数
                                wkAfStockWork.SalesOrderCount = orderDataValue * -1;
                                break;
                            }
                    }

                }
            }
        }
        // ---- ADD K2013/12/25 鄧潘ハン ---------------------- <<<<<

        #region クラス変換処理
        /// <summary>
        /// 在庫移動データ→移動先在庫データ
        /// </summary>
        /// <param name="retStockWork">在庫データ</param>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <param name="moveStatus">在庫移動ステータス</param>
        /// <param name="procMode">処理区分</param>
        /// <param name="originStockWork">移動元在庫データ</param>
        /// <returns>移動先在庫データ</returns>
        private StockWork CopyAfStockWorkFromStockMoveWork(StockWork retStockWork, StockMoveWork stockMoveWork, int moveStatus, int procMode, StockWork originStockWork)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            #region 格納処理
            retStockWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //企業コード
            retStockWork.SectionCode = stockMoveWork.AfSectionCode;    //拠点コード←移動先拠点コード
            retStockWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;    //倉庫コード←移動先倉庫コード
            retStockWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //メーカーコード
            retStockWork.GoodsNo = stockMoveWork.GoodsNo;    //商品コード
            retStockWork.GoodsNoNoneHyphen = stockMoveWork.GoodsNo.Replace("-","");  //ハイフン無し品番 在庫マスタ新規作成時に必要

            // 入荷確定ありの場合
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (moveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    if (procMode == (int)ct_ProcMode.Write)
                    {
                        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //仕入在庫数←移動中仕入在庫数
                    }
                    else
                    {
                        retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //仕入在庫数←移動中仕入在庫数
                    }
                }
                if (originStockWork != null)
                {
                    //retStockWork.StockUnitPriceFl = originStockWork.StockUnitPriceFl;    //仕入単価
                    // -- DEL 2010/06/15 --------------------------------------->>>
                    //retStockWork.LastStockDate = originStockWork.LastStockDate;    //最終仕入年月日
                    //retStockWork.MinimumStockCnt = originStockWork.MinimumStockCnt;    //最低在庫数
                    //retStockWork.MaximumStockCnt = originStockWork.MaximumStockCnt;    //最高在庫数
                    //retStockWork.NmlSalOdrCount = originStockWork.NmlSalOdrCount;    //基準発注数
                    //retStockWork.SalesOrderUnit = originStockWork.SalesOrderUnit;    //発注単位
                    // -- DEL 2010/06/15 ---------------------------------------<<<
                }
            }

            // 入荷確定なしの場合(在庫移動と倉庫移動同じ)
            else
            {
                retStockWork.MovingSupliStock = 0;    //移動中仕入在庫数

                //if (stockMoveWork.StockMoveFormal == 2 || stockMoveWork.StockMoveFormal == 4)
                //{
                if (procMode == (int)ct_ProcMode.Write)
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount;    //仕入在庫数
                }
                else
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //仕入在庫数
                }
                //}
                //else
                //{
                //    // 出荷
                //    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                //        retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //仕入在庫数
                //    // 入荷
                //    else
                //        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //仕入在庫数
                //}
            }
            #endregion

            return retStockWork;
        }

        /// <summary>
        /// 在庫移動データ→移動元在庫データ
        /// </summary>
        /// <param name="retStockWork">在庫データ</param>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <param name="originStockWork">更新前在庫データ</param>
        /// <param name="newMoveStatus">更新移動ステータス</param>
        /// <param name="oldMoveStatus">更新前移動ステータス</param>
        /// <param name="procMode">処理区分</param>
        /// <returns></returns>
        private StockWork CopyBfStockWorkFromStockMoveWork(StockWork retStockWork, StockMoveWork stockMoveWork, StockWork originStockWork,int newMoveStatus,int oldMoveStatus, int procMode)
        {
            if (retStockWork == null)
                retStockWork = new StockWork();

            #region 格納処理
            retStockWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //企業コード
            retStockWork.SectionCode = stockMoveWork.BfSectionCode;         //拠点コード←移動元拠点コード
            retStockWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;    //倉庫コード←移動元倉庫コード
            retStockWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //メーカーコード
            retStockWork.GoodsNo = stockMoveWork.GoodsNo;    //商品コード
            retStockWork.GoodsNoNoneHyphen = stockMoveWork.GoodsNo.Replace("-", ""); //ハイフン無し品番 在庫マスタ新規作成時に必要
            
            if (originStockWork != null)
            {   
                //retStockWork.StockUnitPriceFl = originStockWork.StockUnitPriceFl;    //仕入単価
                retStockWork.LastStockDate = originStockWork.LastStockDate;    //最終仕入年月日
            }

            // 入荷確定ありの場合
            if (stockMoveWork.StockMoveFixCode == 1)
            {
                if (newMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    retStockWork.SupplierStock += stockMoveWork.MoveCount * -1;    //仕入在庫数←移動中仕入在庫数

                    if (oldMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)
                    {
                        retStockWork.MovingSupliStock += stockMoveWork.MoveCount * -1;    //移動中仕入在庫数
                    }
                }
                else if (newMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)
                {
                    if (procMode == (int)ct_ProcMode.Write)
                    {
                        retStockWork.MovingSupliStock += stockMoveWork.MoveCount;    //移動中仕入在庫数
                    }
                    else
                    {
                        //入荷キャンセル
                        if (oldMoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                        {
                            retStockWork.MovingSupliStock += stockMoveWork.MoveCount;    //移動中仕入在庫数
                            retStockWork.SupplierStock += stockMoveWork.MoveCount;    //仕入在庫数
                        }
                        else
                        {
                            retStockWork.MovingSupliStock += stockMoveWork.MoveCount * -1;    //移動中仕入在庫数
                        }
                    }
                }
            }

            // 入荷確定なしの場合(在庫移動と倉庫移動同じ)
            else
            {
                retStockWork.MovingSupliStock = 0;    //移動中仕入在庫数
                //if (stockMoveWork.StockMoveFormal == 2 || stockMoveWork.StockMoveFormal == 4)
                //{
                if (procMode == (int)ct_ProcMode.Write)
                {
                    // 出荷
                    retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //仕入在庫数
                }
                else
                {
                    retStockWork.SupplierStock -= stockMoveWork.MoveCount * -1;    //仕入在庫数
                }
                //}
                //else
                //{
                //    // 出荷
                //    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                //        retStockWork.SupplierStock -= stockMoveWork.MoveCount;    //仕入在庫数
                //    // 入荷
                //    else
                //        retStockWork.SupplierStock += stockMoveWork.MoveCount;    //仕入在庫数
                //}
            }
            #endregion

            return retStockWork;
        }
        
        /// <summary>
        /// 在庫移動データ→在庫受払履歴データ
        /// </summary>
        /// <param name="stockMoveWork">在庫移動</param>
        /// <param name="bfstockMoveWork">在庫移動変更前</param>
        /// <param name="defstockMoveWork">在庫移動差分</param>
        /// <param name="procMode">更新モード</param>
        /// <param name="stockMoveFormal">移動形式</param>
        /// <br>Update Note: 2010/11/15 譚洪</br>
        /// <br>             障害改良対応ｘ月「１」の対応</br>
        /// <returns></returns>
        private StockAcPayHistWork CopyStockAcPayHistWorkFromStockMoveWork(StockMoveWork stockMoveWork, StockMoveWork bfstockMoveWork, StockMoveWork defstockMoveWork, int procMode, int stockMoveFormal)
        {                           
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();

            #region 格納処理
            retStockAcPayHistWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //企業コード
            retStockAcPayHistWork.AcPaySlipNum = stockMoveWork.StockMoveSlipNo.ToString(); //受払元伝票番号←在庫移動伝票番号
            retStockAcPayHistWork.AcPaySlipRowNo = stockMoveWork.StockMoveRowNo;

            if (procMode == (int)ct_ProcMode.Write)
            {
                if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel; //受払元取引区分
                else
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip; //受払元取引区分
            }
            else
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip; //受払元取引区分

            retStockAcPayHistWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //メーカーコード
            retStockAcPayHistWork.MakerName = stockMoveWork.MakerName;    //メーカー名称
            retStockAcPayHistWork.GoodsNo = stockMoveWork.GoodsNo;    //商品コード
            retStockAcPayHistWork.GoodsName = stockMoveWork.GoodsName;    //商品名称

            retStockAcPayHistWork.InputSectionCd = stockMoveWork.UpdateSecCd;    //入力拠点コード←更新拠点コード
            if (secInfoSetWorkHash.ContainsKey(stockMoveWork.UpdateSecCd) == true )
            {
                retStockAcPayHistWork.InputSectionGuidNm = secInfoSetWorkHash[stockMoveWork.UpdateSecCd].ToString();    //入力拠点名称←更新拠点名称
            }

            if ((stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived) || //入荷処理
                (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)) //入荷キャンセル
            {
                retStockAcPayHistWork.SectionCode = stockMoveWork.AfSectionCode;    //拠点コード←移動先拠点コード
                retStockAcPayHistWork.SectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //拠点名称←移動先拠点名称                
                retStockAcPayHistWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;     //倉庫コード←移動先倉庫コード
                retStockAcPayHistWork.WarehouseName = stockMoveWork.AfEnterWarehName;     //倉庫名称←移動先倉庫名称
                retStockAcPayHistWork.ShelfNo = stockMoveWork.AfShelfNo;  //棚番←移動先棚番
            }
            else
            {
                retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //拠点コード←移動元拠点コード
                retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //拠点名称←移動元拠点名称
                retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //倉庫コード←移動元倉庫コード
                retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //倉庫名称←移動元倉庫名称
                retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //棚番←移動元棚番
            }            
            
            retStockAcPayHistWork.BfSectionCode = stockMoveWork.BfSectionCode;    //移動元拠点コード
            retStockAcPayHistWork.BfSectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //移動元拠点ガイド名称
            retStockAcPayHistWork.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;    //移動元倉庫コード
            retStockAcPayHistWork.BfEnterWarehName = stockMoveWork.BfEnterWarehName;    //移動元倉庫名称
            retStockAcPayHistWork.BfShelfNo = stockMoveWork.BfShelfNo;    //移動元棚番
            retStockAcPayHistWork.AfSectionCode = stockMoveWork.AfSectionCode;    //移動先拠点コード
            retStockAcPayHistWork.AfSectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //移動先拠点ガイド名称
            retStockAcPayHistWork.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;    //移動先倉庫コード
            retStockAcPayHistWork.AfEnterWarehName = stockMoveWork.AfEnterWarehName;    //移動先倉庫名称
            retStockAcPayHistWork.AfShelfNo = stockMoveWork.AfShelfNo;    //移動先棚番
            retStockAcPayHistWork.MoveStatus = stockMoveWork.MoveStatus;　//移動状態
            retStockAcPayHistWork.BLGoodsCode = stockMoveWork.BLGoodsCode;  //BL商品コード
            retStockAcPayHistWork.BLGoodsFullName = stockMoveWork.BLGoodsFullName;  //BL商品コード名称（全角）

            retStockAcPayHistWork.ListPriceTaxExcFl = stockMoveWork.ListPriceFl; //定価
            retStockAcPayHistWork.AcPayNote = stockMoveWork.Outline;    //受払備考
            retStockAcPayHistWork.SupplierCd = stockMoveWork.SupplierCd; // 仕入先コード
            retStockAcPayHistWork.SupplierSnm = stockMoveWork.SupplierSnm; // 仕入先名称

            //受払履歴の数量には差分の数量をセット
            int mark = 1;

            if (procMode == (int)ct_ProcMode.Delete)
            {
                mark = -1;
            }


            if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)//入荷処理
            {
                // 入荷確定ありの場合
                if (stockMoveWork.StockMoveFixCode == 1)
                {
                    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //入出荷日←入荷日
                    retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //計上日←入荷日
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //受払元伝票区分
                    retStockAcPayHistWork.ArrivalCnt = stockMoveWork.MoveCount * mark;    //入荷数(入荷時は数量をそのままセット)
                    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ReceiveAgentCd;    //引取担当者コード
                    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ReceiveAgentNm;    //引取担当者名称

                    retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //仕入単価
                    retStockAcPayHistWork.StockPrice = stockMoveWork.StockMovePrice * mark;    //仕入金額
                }
                // 入荷確定なしの場合
                else
                {
                    retStockAcPayHistWork.MovingSupliStock = 0;

                    // 出荷伝票の場合
                    if (stockMoveWork.StockMoveFormal == 1 || stockMoveWork.StockMoveFormal == 2)
                    {
                        retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //受払元伝票区分
                        //retStockAcPayHistWork.SupplierStock -= stockMoveWork.MoveCount;
                        retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //出荷担当者コード
                        retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //出荷担当者名称
                        // UPD 2010/11/15 ---- >>>>
                        //retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //入出荷日←出荷確定日
                        retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //入出荷日←入荷日
                        // UPD 2010/11/15 ---- <<<<
                        retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //売上単価
                        retStockAcPayHistWork.SalesMoney = defstockMoveWork.StockMovePrice * mark;    //売上金額(差分をセット)
                        retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //出荷数(出荷時は差分をセット)
                        
                        retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //拠点コード←移動元拠点コード
                        retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //拠点名称←移動元拠点名称
                        retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //倉庫コード←移動元倉庫コード
                        retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //倉庫名称←移動元倉庫名称
                        retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //棚番←移動元棚番
                    }
                    // 入荷伝票の場合
          
                    else
                    {
                        retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //受払元伝票区分
                        //retStockAcPayHistWork.SupplierStock += stockMoveWork.MoveCount;
                        retStockAcPayHistWork.InputAgenCd = stockMoveWork.ReceiveAgentCd;    //引取担当者コード
                        retStockAcPayHistWork.InputAgenNm = stockMoveWork.ReceiveAgentNm;    //引取担当者名称
                        retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ArrivalGoodsDay;    //入出荷日←入荷日
                        retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //計上日←入荷日
                        retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //仕入単価
                        retStockAcPayHistWork.StockPrice = defstockMoveWork.StockMovePrice * mark;    //仕入金額
                        retStockAcPayHistWork.ArrivalCnt = defstockMoveWork.MoveCount * mark;    //入荷数(入荷時は数量をそのままセット)

                        retStockAcPayHistWork.SectionCode = stockMoveWork.AfSectionCode;    //拠点コード←移動先拠点コード
                        retStockAcPayHistWork.SectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //拠点名称←移動先拠点名称
                        retStockAcPayHistWork.WarehouseCode = stockMoveWork.AfEnterWarehCode;     //倉庫コード←移動先倉庫コード
                        retStockAcPayHistWork.WarehouseName = stockMoveWork.AfEnterWarehName;     //倉庫名称←移動先倉庫名称
                        retStockAcPayHistWork.ShelfNo = stockMoveWork.AfShelfNo;  //棚番←移動先棚番
                    }
                }
            }
            else if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving)//出荷処理
            {
                if (bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Arrived)
                {
                    //入荷キャンセル処理
                    retStockAcPayHistWork.IoGoodsDay = bfstockMoveWork.ArrivalGoodsDay;    //入出荷日←入荷日
                    retStockAcPayHistWork.AddUpADate = bfstockMoveWork.ArrivalGoodsDay;    //計上日←入荷日
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveArrival;    //受払元伝票区分

                    retStockAcPayHistWork.ArrivalCnt = stockMoveWork.MoveCount * -1;    //入荷数(入荷時は数量をそのままセット)

                    retStockAcPayHistWork.InputAgenCd = bfstockMoveWork.ReceiveAgentCd;    //引取担当者コード
                    retStockAcPayHistWork.InputAgenNm = bfstockMoveWork.ReceiveAgentNm;    //引取担当者名称

                    retStockAcPayHistWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;    //仕入単価
                    retStockAcPayHistWork.StockPrice = stockMoveWork.StockMovePrice * -1;    //仕入金額
                }
                else
                {
                    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //入出荷日←出荷確定日
                    retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //受払元伝票区分
                    retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //出荷数(出荷時は差分をセット)
                    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //出荷担当者コード
                    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //出荷担当者名称

                    retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //売上単価
                    retStockAcPayHistWork.SalesMoney = defstockMoveWork.StockMovePrice * mark;    //売上金額(差分をセット)

                }
            }
            //else if (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment)//未出荷状態
            //{
            //    retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentScdlDay;    //入出荷日←出荷予定日
            //    retStockAcPayHistWork.ShipmentCnt = moveCount;    //出荷数
            //    retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //出荷担当者コード
            //    retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //出荷担当者名称
            //}
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------->>>>>
            if (_isRecv)
            {
                retStockAcPayHistWork.SectionGuideNm = GetSecNameBySecCode(retStockAcPayHistWork.SectionCode);//拠点名称←移動先拠点名称
                retStockAcPayHistWork.InputSectionGuidNm = GetSecNameBySecCode(retStockAcPayHistWork.InputSectionCd);//入力拠点コード←更新拠点コード
            }
            //ADD 2011/09/02 #24259------------------------------------------------------------------------------------------------<<<<<
            #endregion

            return retStockAcPayHistWork;
        }

        /// <summary>
        /// 在庫移動データ→在庫受払履歴データ(入荷処理時の出荷)
        /// </summary>
        /// <param name="stockMoveWork">在庫移動</param>
        /// <param name="bfstockMoveWork">在庫移動変更前</param>
        /// <param name="defstockMoveWork">在庫移動差分</param>
        /// <param name="procMode">更新モード</param>
        /// <param name="stockMoveFormal">移動形式</param>
        /// <returns></returns>
        private StockAcPayHistWork CopyStockAcPayHistWorkFromStockMoveWorkPartner(StockMoveWork stockMoveWork, StockMoveWork bfstockMoveWork,StockMoveWork defstockMoveWork, int procMode, int stockMoveFormal)
        {
            StockAcPayHistWork retStockAcPayHistWork = new StockAcPayHistWork();

            #region 格納処理
            retStockAcPayHistWork.EnterpriseCode = stockMoveWork.EnterpriseCode;    //企業コード
            retStockAcPayHistWork.AcPaySlipNum = stockMoveWork.StockMoveSlipNo.ToString(); //受払元伝票番号←在庫移動伝票番号
            retStockAcPayHistWork.AcPaySlipRowNo = stockMoveWork.StockMoveRowNo;

            if (procMode == (int)ct_ProcMode.Write)
            {
                if ((stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.MoveOffSubject && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving) ||
                    (stockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Unshipment && bfstockMoveWork.MoveStatus == (int)ConstantManagement_Mobile.ct_MoveStatus.Moving))
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.Cancel; //受払元取引区分
                else
                    retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.NormalSlip; //受払元取引区分
            }
            else
                retStockAcPayHistWork.AcPayTransCd = (int)ConstantManagement_Mobile.ct_AcPayTransCd.DeleteSlip; //受払元取引区分

            retStockAcPayHistWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;    //メーカーコード
            retStockAcPayHistWork.MakerName = stockMoveWork.MakerName;    //メーカー名称
            retStockAcPayHistWork.GoodsNo = stockMoveWork.GoodsNo;    //商品コード
            retStockAcPayHistWork.GoodsName = stockMoveWork.GoodsName;    //商品名称

            retStockAcPayHistWork.InputSectionCd = stockMoveWork.UpdateSecCd;    //入力拠点コード←更新拠点コード
            if (secInfoSetWorkHash.ContainsKey(stockMoveWork.UpdateSecCd) == true)
            {
                retStockAcPayHistWork.InputSectionGuidNm = secInfoSetWorkHash[stockMoveWork.UpdateSecCd].ToString();    //入力拠点名称←更新拠点名称
            }

            retStockAcPayHistWork.SectionCode = stockMoveWork.BfSectionCode;    //拠点コード←移動元拠点コード
            retStockAcPayHistWork.SectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //拠点名称←移動元拠点名称
            retStockAcPayHistWork.WarehouseCode = stockMoveWork.BfEnterWarehCode;     //倉庫コード←移動元倉庫コード
            retStockAcPayHistWork.WarehouseName = stockMoveWork.BfEnterWarehName;     //倉庫名称←移動元倉庫名称
            retStockAcPayHistWork.ShelfNo = stockMoveWork.BfShelfNo;  //棚番←移動元棚番

            retStockAcPayHistWork.BfSectionCode = stockMoveWork.BfSectionCode;    //移動元拠点コード
            retStockAcPayHistWork.BfSectionGuideNm = stockMoveWork.BfSectionGuideSnm;    //移動元拠点ガイド名称
            retStockAcPayHistWork.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;    //移動元倉庫コード
            retStockAcPayHistWork.BfEnterWarehName = stockMoveWork.BfEnterWarehName;    //移動元倉庫名称
            retStockAcPayHistWork.BfShelfNo = stockMoveWork.BfShelfNo;  //移動元棚番
            retStockAcPayHistWork.AfSectionCode = stockMoveWork.AfSectionCode;    //移動先拠点コード
            retStockAcPayHistWork.AfSectionGuideNm = stockMoveWork.AfSectionGuideSnm;    //移動先拠点ガイド名称
            retStockAcPayHistWork.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;    //移動先倉庫コード
            retStockAcPayHistWork.AfEnterWarehName = stockMoveWork.AfEnterWarehName;    //移動先倉庫名称
            retStockAcPayHistWork.AfShelfNo = stockMoveWork.AfShelfNo;  //移動元棚番
            retStockAcPayHistWork.MoveStatus = stockMoveWork.MoveStatus;　//移動状態
            retStockAcPayHistWork.BLGoodsCode = stockMoveWork.BLGoodsCode;  //BL商品コード
            retStockAcPayHistWork.BLGoodsFullName = stockMoveWork.BLGoodsFullName;  //BL商品コード名称（全角）

            retStockAcPayHistWork.ListPriceTaxExcFl = stockMoveWork.ListPriceFl; //定価
            retStockAcPayHistWork.AcPayNote = stockMoveWork.Outline;    //受払備考

            int mark = 1;
            if (procMode == (int)ct_ProcMode.Delete)
            {
                mark = -1;
            }

            retStockAcPayHistWork.SalesUnPrcTaxExcFl = stockMoveWork.StockUnitPriceFl;    //仕入単価
            retStockAcPayHistWork.SalesMoney = stockMoveWork.StockMovePrice * mark;    //仕入金額

            retStockAcPayHistWork.IoGoodsDay = stockMoveWork.ShipmentFixDay;    //入出荷日←出荷確定日
            retStockAcPayHistWork.AddUpADate = stockMoveWork.ArrivalGoodsDay;    //計上日←入荷日
            retStockAcPayHistWork.AcPaySlipCd = (int)ConstantManagement_Mobile.ct_AcPaySlipCd.MoveShipment;    //受払元伝票区分
            retStockAcPayHistWork.ShipmentCnt = defstockMoveWork.MoveCount * mark;    //出荷数(差分をセット)
            retStockAcPayHistWork.InputAgenCd = stockMoveWork.ShipAgentCd;    //出荷担当者コード
            retStockAcPayHistWork.InputAgenNm = stockMoveWork.ShipAgentNm;    //出荷担当者名称

            #endregion

            return retStockAcPayHistWork;
        }
        
        #endregion

        #endregion

        #region 拠点設定マスタ取得
        /// <summary>
        /// 拠点設定マスタ取得
        /// </summary>
        /// <param name="stockMoveList"></param>
        /// <param name="secinfoSetWorkHash"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int GetSecInfoSetWork(ArrayList stockMoveList, ref Hashtable secinfoSetWorkHash, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            secinfoSetWorkHash = new Hashtable();
            
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            if (stockMoveList != null && stockMoveList.Count > 0)
                secInfoSetWork.EnterpriseCode = ((StockMoveWork)stockMoveList[0]).EnterpriseCode;   //企業コード
            else
                return status;
            
            ArrayList secInfoList = new ArrayList();
            
            //拠点設定Seach呼び出し
            status = _secInfoDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //拠点名称をHashTableに格納
                foreach(SecInfoSetWork sec in secInfoList)
                {
                    secinfoSetWorkHash.Add(sec.SectionCode,sec.SectionGuideNm);
                
                }
            }
            
            return status;
        }
        
        #endregion

        #region パラメータチェック処理
        /// <summary>
        /// パラメータチェック処理
        /// </summary>
        /// <param name="stockMoveList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="stockMoveFormal"></param>
        /// <param name="stockMoveSlipNo"></param>
        /// <param name="moveStatus"></param>
        /// <param name="retMsg"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CheckParam(ArrayList stockMoveList, out string enterpriseCode, out string sectionCode, out int stockMoveFormal, out int stockMoveSlipNo, out int moveStatus, out string retMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMsg = "";
            enterpriseCode = "";
            sectionCode = "";
            stockMoveFormal = 0;
            stockMoveSlipNo = 0;
            moveStatus = 0;

            //NULLチェック
            if (stockMoveList == null)
            {
                retMsg = "プログラムエラー。更新対象パラメータが未指定です";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //カウントチェック
            if (stockMoveList.Count <= 0)
            {
                retMsg = "プログラムエラー。更新対象パラメータが未指定です";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            StockMoveWork stockMoveWork = stockMoveList[0] as StockMoveWork;

            if (stockMoveWork == null)
            {
                retMsg = "プログラムエラー。更新対象パラメータが未指定です";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            //企業コード取得
            enterpriseCode = stockMoveWork.EnterpriseCode;
            //拠点コード
            sectionCode = stockMoveWork.BfSectionCode;
            //在庫移動形式
            stockMoveFormal = stockMoveWork.StockMoveFormal;
            //在庫移動伝票番号
            stockMoveSlipNo = stockMoveWork.StockMoveSlipNo;
            //移動状態
            moveStatus = stockMoveWork.MoveStatus;

            return status;
        }
        #endregion

        #region 移動伝票番号採番
        /// <summary>
        /// 在庫移動伝票番号を採番して返します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockMoveSlipNo">採番結果</param>
        /// <param name="stockMoveFormal">在庫移動形式</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo"></param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動伝票番号を採番して返します</br>
        /// <br>Programmer : 21015 金巻　芳則</br>
        /// <br>Date       : 2007.02.07</br>
        private int CreateStockMoveSlipNo(string enterpriseCode, string sectionCode, out int stockMoveSlipNo, int stockMoveFormal, out string retMsg, out string retItemInfo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            stockMoveSlipNo = 0;

            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;
            retItemInfo = null;

            NumberingManager numberingManager = new NumberingManager();

            //番号範囲分ループ
            Int32 loopCnt = 1;

            while (loopCnt <= 999999999)
            {
                long no;

                //在庫移動伝票番号は拠点非依存だから拠点コードは全社
                status = numberingManager.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.StockMoveSlipNo,out no);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //番号を数値型に変換
                    Int32 tmpStockMoveSlipNo = System.Convert.ToInt32(no);
                    SqlDataReader myReader = null;

                    //空き番チェック
                    try
                    {
                        //Selectコマンドの生成
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT STOCKMOVESLIPNORF FROM STOCKMOVERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL AND STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO ", sqlConnection, sqlTransaction))
                        {

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                            SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                            findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockMoveFormal);
                            findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(tmpStockMoveSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //データ無しの場合には戻り値をセット
                            if (!myReader.Read())
                            {
                                stockMoveSlipNo = tmpStockMoveSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        retMsg = "在庫移動伝票番号採番中にエラーが発生しました。";
                        retItemInfo = "StockMoveSlipNo";

                        //基底クラスに例外を渡して処理してもらう
                        status = base.WriteSQLErrorLog(ex);
                        break;
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }
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
                retMsg = "在庫移動伝票番号に空き番号がありません。削除可能な伝票を削除してください。";
                retItemInfo = "StockMoveSlipNo";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        #endregion

        #region ADD 2011/08/11 孫東響 SCM対応-拠点管理（10704767-00）在庫移動データ受信時に在庫マスタの更新を行う        
        /// <summary>
        /// 更新前後差分用リストを取得します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="ctProcMode">書きモード</param>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="defstockMoveWorkList">在庫移動差分リスト</param>
        /// <param name="stockMoveWorkList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 更新前後差分用リストを取得します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.08.11</br>
        private int GetStockMove(int ctProcMode, int stockMoveSlipNo, out ArrayList defstockMoveWorkList, ref ArrayList stockMoveWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            defstockMoveWorkList = new ArrayList();//更新前後差分用リスト
            try
            {
                //string selectTxt = "";//DEL 2011/09/05 ②#24241
                StringBuilder selectTxt = new StringBuilder();//ADD 2011/09/05 ②#24241

                if (stockMoveWorkList != null)
                {
                    for (int i = 0; i < stockMoveWorkList.Count; i++)
                    {
                        StockMoveWork stockmoveWork = stockMoveWorkList[i] as StockMoveWork;

                        #region DEL
                        //DEL 2011/09/05 ②#24241------------------------------------->>>>>
                        ////在庫移動伝票番号が 0 の場合はパラメータの伝票番号をセット
                        //if (stockmoveWork.StockMoveSlipNo == 0)
                        //    stockmoveWork.StockMoveSlipNo = stockMoveSlipNo;

                        //selectTxt = "";
                        //selectTxt += "SELECT" + Environment.NewLine;
                        //selectTxt += "  *" + Environment.NewLine;
                        //selectTxt += "FROM STOCKMOVERF AS STOCKM" + Environment.NewLine;
                        //selectTxt += "WHERE" + Environment.NewLine;
                        //selectTxt += "     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine;
                        //selectTxt += " AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine;

                        ////Selectコマンドの生成
                        //sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);
                        //DEL 2011/09/05 ②#24241-------------------------------------<<<<<
                        #endregion
                        //ADD 2011/09/05 ②#24241------------------------------------->>>>>
                        selectTxt.Append("SELECT" + Environment.NewLine);
                        selectTxt.Append("  *" + Environment.NewLine);
                        selectTxt.Append("FROM STOCKMOVERF AS STOCKM" + Environment.NewLine);
                        selectTxt.Append("WHERE" + Environment.NewLine);
                        selectTxt.Append("     STOCKM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO" + Environment.NewLine);
                        selectTxt.Append(" AND STOCKM.LOGICALDELETECODERF=@FINDLOGICALDELETECODERF" + Environment.NewLine);
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection, sqlTransaction);
                        //ADD 2011/09/05 ②#24241-------------------------------------<<<<<

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaStockMoveFormal = sqlCommand.Parameters.Add("@FINDSTOCKMOVEFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockMoveSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVESLIPNO", SqlDbType.Int);
                        SqlParameter findParaStockMoveRowNo = sqlCommand.Parameters.Add("@FINDSTOCKMOVEROWNO", SqlDbType.Int);
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);//ADD 2011/09/05 ②#24241

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockmoveWork.EnterpriseCode);
                        findParaStockMoveFormal.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveFormal);
                        findParaStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveSlipNo);
                        findParaStockMoveRowNo.Value = SqlDataMediator.SqlSetInt32(stockmoveWork.StockMoveRowNo);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);//ADD 2011/09/05 ②#24241

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //更新前の在庫移動データを取得
                            StockMoveWork defStockMoveWork = CopyToStockMoveWorkFromReader(ref myReader);
                            if (ctProcMode == (int)ct_ProcMode.Write)
                            {
                                //更新後の移動数を反映
                                defStockMoveWork.MoveCount = stockmoveWork.MoveCount - defStockMoveWork.MoveCount;
                                defStockMoveWork.StockMovePrice = stockmoveWork.StockMovePrice - defStockMoveWork.StockMovePrice;
                            }
                            else
                            {
                                if (defStockMoveWork.LogicalDeleteCode == 1)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    break;
                                }
                            }

                            //確定区分を追加
                            defStockMoveWork.StockMoveFixCode = stockmoveWork.StockMoveFixCode;

                            // --- ADD 三戸 2012/07/10 ---------->>>>>
                            defStockMoveWork.MoveStockAutoInsDiv = stockmoveWork.MoveStockAutoInsDiv;
                            // --- ADD 三戸 2012/07/10 ----------<<<<<

                            defstockMoveWorkList.Add(defStockMoveWork);                           
                        }
                        else
                        {
                            if (ctProcMode == (int)ct_ProcMode.Delete)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;                               
                            }
                            StockMoveWork defStockMoveWork = stockmoveWork;
                            defstockMoveWorkList.Add(defStockMoveWork);
                        }
                        if (myReader.IsClosed == false) myReader.Close();
                        al.Add(stockmoveWork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockMoveWorkList = al;

            return status;
        }

        /// <summary>
        /// 在庫移動情報を登録、更新します
        /// </summary>
        /// <param name="stockMoveList">stockMoveListオブジェクト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報を登録、更新します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.08.11</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo       = null;
            CustomSerializeArrayList retList    = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode   = "";
            string sectionCode      = "";
            int stockMoveFormal     = 0;
            int stockMoveSlipNo     = 0;
            int moveStatus          = 0;
            string retItemInfo      = "";
            bool createHisData      = true;
            string resNm = "";
            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            // 拠点間発注データのDictionaryの初期化
            Dictionary<string, ArrayList> orderDataDic = null;
            // オプション情報の初期化
            int ps = 0;
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

            try
            {
                ArrayList stockList             = null; //在庫リスト
                ArrayList stockAcPayHistList    = null; //在庫受払履歴リスト
                ArrayList defStockMoveList      = null; //更新差分在庫移動リスト
                ArrayList BFStockMoveList       = null; //更新前移動リスト
                ArrayList defStockList          = null; //更新前在庫リスト
               
                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //ADD 2011/09/02 #24259------------------------------->>>>>
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                // システムロック(拠点)
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData1:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForReceiveData1_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }

                try
                {
                    #region DEL 2011.08.24 #23964 ソースレビュー結果
                    ////入荷確定あり
                    //if (_stockMoveWork.StockMoveFixCode == 1)
                    //{
                    //    //---在庫移動伝票番号採番処理---
                    //    if (stockMoveSlipNo == 0)//在庫移動伝票
                    //    {
                    //        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    //    }
                    //    else
                    //    {
                    //        //更新前データの取得
                    //        BFStockMoveList = new ArrayList();
                    //        foreach (StockMoveWork stmvwork in stockMoveList)
                    //        {
                    //            StockMoveWork searchpara = new StockMoveWork();
                    //            searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                    //            searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                    //            searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                    //            searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                    //            status = ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);
                    //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //            {
                    //                BFStockMoveList.Add(searchpara);
                    //            }
                    //            else
                    //            {
                    //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //                BFStockMoveList.Clear();
                    //                BFStockMoveList = null;
                    //                break;
                    //            }
                    //        }                                      
                    //    }
                    //    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        if (moveStatus == 2 && stockMoveList != null)
                    //        {
                    //            //入荷取消の場合の、入荷伝票の削除
                    //            GetStockMove((int)ct_ProcMode.Delete, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    //        }
                    //        else
                    //        {
                    //            // 出庫・入庫伝票登録
                    //            GetStockMove((int)ct_ProcMode.Write, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    //        }                            
                    //    }

                    //    //データ生成
                    //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        createHisData = true;
                    //        //ArrayList defList = defStockMoveList;//DEL 2011.08.24 #23964 ソースレビュー結果
                    //        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    //    }

                    //    //在庫データ更新
                    //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        string origin = "";
                    //        CustomSerializeArrayList originList = null;
                    //        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    //        paraList.Add(stockList);
                    //        paraList.Add(stockAcPayHistList);
                    //        int position = 0;
                    //        string param = "";
                    //        object freeParam = null;
                    //        status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    //    }
                    //}
                    //// 入荷確定なし
                    //else
                    //{
                    #endregion

                    ArrayList stockMoveNewList = null;
                    //---在庫移動伝票番号採番処理---
                    if (stockMoveSlipNo == 0)//在庫移動伝票
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        //更新前データの取得
                        BFStockMoveList = new ArrayList();
                        stockMoveNewList = new ArrayList();
                        foreach (StockMoveWork stmvwork in stockMoveList)
                        {
                            StockMoveWork searchpara = new StockMoveWork();
                            searchpara.EnterpriseCode = stmvwork.EnterpriseCode;
                            searchpara.StockMoveSlipNo = stmvwork.StockMoveSlipNo;
                            searchpara.StockMoveFormal = stmvwork.StockMoveFormal;
                            searchpara.StockMoveRowNo = stmvwork.StockMoveRowNo;
                            this.ReadProc(ref searchpara, 0, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                BFStockMoveList.Add(searchpara);

                                // 入荷伝票だったらセット下記仕様を変更
                                if (searchpara.StockMoveFormal == 3 || searchpara.StockMoveFormal == 4)
                                {
                                    searchpara.ShipmentScdlDay = DateTime.MinValue;
                                    searchpara.ShipmentFixDay = DateTime.MinValue;
                                }
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                BFStockMoveList.Clear();
                                BFStockMoveList = null;
                                break;
                            }
                        }
                    }


                    //在庫移動データ更新
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 出庫伝票登録
                        GetStockMove((int)ct_ProcMode.Write, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    }
                    // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<
                    //データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        //ArrayList defList = defStockMoveList;//DEL 2011.08.24 #23964 ソースレビュー結果
                        //status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン
                    }

                    //在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        //if ((stockList.Count == 0 && stockAcPayHistList.Count == 0) == false)//DEL 2011.08.29 在庫データがゼロ場合、在庫データ更新しない
                        if (stockList.Count > 0)//ADD 2011.08.29 在庫データがゼロ場合、在庫データ更新しない
                        {
                            status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        }
                    }
                    //}//DEL 2011.08.24 #23964 ソースレビュー結果
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForReceiveData1_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }




        // ---- ADD K2013/12/10 wangl2 ------------------------- >>>>>
        /// <summary>
        /// 在庫移動情報を登録、更新します(フタバ個別　拠点間発注処理)
        /// </summary>
        /// <param name="stockMoveList">stockMoveListオブジェクト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : 在庫移動情報を登録、更新します</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : K2013/12/10</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        ///</remarks>
        public int WriteForReceiveData(ref ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            string resNm = "";
            // 拠点間発注データのDictionaryの初期化
            Dictionary<string, ArrayList> orderDataDic = null;
            // オプション情報の初期化
            int ps = 0;

            try
            {
                // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
                // 呼出元メソッド取得
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("在庫移動登録処理 呼出元={0} 呼出元メソッド={1}", className, methodName));
                }
                catch
                {
                    //処理なし
                }
                // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
                ArrayList stockList = null; //在庫リスト
                ArrayList stockAcPayHistList = null; //在庫受払履歴リスト
                ArrayList defStockMoveList = null; //更新差分在庫移動リスト
                ArrayList BFStockMoveList = null; //更新前移動リスト
                ArrayList defStockList = null; //更新前在庫リスト
                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }

                // システムロック(拠点)
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                ShareCheckInfo info = new ShareCheckInfo();

                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                try
                {
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    // 月次処理 Lock
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.WriteForReceiveData2_ShareCheckLocke:" + ex.ToString());
                    throw ex;
                }
                // --- ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForReceiveData2_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }
                #endif

                try
                {
                    for (int i = 1; i <= stockMoveList.Count; i++)
                    {
                        (stockMoveList[i - 1] as StockMoveWork).StockMoveRowNo = i;
                    }

                    //---在庫移動伝票番号採番処理---
                    if (stockMoveSlipNo == 0)//在庫移動伝票
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                         // 出庫・入庫伝票登録
                         status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                    }

                    // データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);
                    }
                    
                    // 在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.WriteForStockMove(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }

                }
                finally
                {
                    #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    }

                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                    //this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    int shareCheckReleaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: シェアチェック解除前にデータベースに接続できません。", shareCheckReleaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: シェアチェック解除前にトランザクションが終了しています。", shareCheckReleaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: シェアチェック解除前にトランザクションに例外が発生しました。", shareCheckReleaseStatus);
                    }
                    else
                    {
                        // シェアチェック解除
                        shareCheckReleaseStatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (shareCheckReleaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForReceiveData2_ShareCheckRelease: シェアチェック解除処理に失敗しました。", shareCheckReleaseStatus);
                        }
                    }
                    // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    #endif
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        // ---- ADD K2013/12/10 wangl2 ------------------------- <<<<<

        // ---- ADD K2020/03/25 陳艶丹　デッドロックの対応 ---------->>>>>
        /// <summary>
        /// 在庫移動情報を登録、更新します(フタバ個別　拠点間発注処理)
        /// </summary>
        /// <param name="stockMoveList">stockMoveListオブジェクト</param>
        /// <param name="stockWorkList">stockWorkListオブジェクト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        ///<remarks>
        /// <br>Note       : 在庫移動情報を登録、更新します</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号  : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        ///</remarks>
        public int WriteForSecOrderHandleDeadLock(ref ArrayList stockMoveList, ref ArrayList stockWorkList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlEncryptInfo sqlEncryptInfo = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retMsg = "";

            string enterpriseCode = "";
            string sectionCode = "";
            int stockMoveFormal = 0;
            int stockMoveSlipNo = 0;
            int moveStatus = 0;
            string retItemInfo = "";
            bool createHisData = true;
            string resNm = "";
            // 拠点間発注データのDictionaryの初期化
            Dictionary<string, ArrayList> orderDataDic = null;
            // オプション情報の初期化
            int ps = 0;

            try
            {
                // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
                // 呼出元メソッド取得
                try
                {
                    string className = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.ToString();
                    string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
                    OutputClcLog(string.Format("在庫移動登録処理 呼出元={0} 呼出元メソッド={1}", className, methodName));
                }
                catch
                {
                    //処理なし
                }
                // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
                ArrayList stockList = null; //在庫リスト
                ArrayList stockAcPayHistList = null; //在庫受払履歴リスト
                ArrayList defStockMoveList = null; //更新差分在庫移動リスト
                ArrayList BFStockMoveList = null; //更新前移動リスト
                ArrayList defStockList = null; //更新前在庫リスト
                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        base.WriteErrorLog(string.Format("StockMoveDB.WriteForSecOrderHandleDeadLock:{0}", retMsg), status);
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //●コネクション情報パラメータチェック
                if (sqlConnection == null || sqlTransaction == null)
                {
                    base.WriteErrorLog(null, "StockMoveDB.WriteForSecOrderHandleDeadLock:データベース接続情報パラメータが未指定です");
                    return status;
                }
                // システムロック(拠点)
                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;

                #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                ShareCheckInfo info = new ShareCheckInfo();

                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                try
                {
                    // 月次処理 Lock
                    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckLocke:" + ex.ToString());
                    throw ex;
                }

                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.WriteForSecOrderHandleDeadLock_Lock:{0}", retMsg), status);
                    return status;
                }
                #endif

                try
                {
                    for (int i = 1; i <= stockMoveList.Count; i++)
                    {
                        (stockMoveList[i - 1] as StockMoveWork).StockMoveRowNo = i;
                    }

                    //---在庫移動伝票番号採番処理---
                    if (stockMoveSlipNo == 0)//在庫移動伝票
                    {
                        status = CreateStockMoveSlipNo(enterpriseCode, sectionCode, out stockMoveSlipNo, stockMoveFormal, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction);
                    }
                    if (stockMoveList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 出庫・入庫伝票登録
                        status = WriteStockMoveProc(stockMoveSlipNo, out defStockMoveList, ref stockMoveList, ref sqlConnection, ref sqlTransaction);
                    }

                    // データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        createHisData = true;
                        status = TransStockMoveToStock((int)ct_ProcMode.Write, createHisData, stockMoveFormal, stockMoveSlipNo, stockMoveList, defStockMoveList, BFStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);
                    }

                    // 在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.WriteForStockMoveHandleDeadLock(origin, ref originList, ref paraList, ref stockWorkList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    #if !DEBUG // Debug時に他の人の迷惑にならない様に…
                    //ＡＰアンロック
                    int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (resNm != "")
                    {
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                    }
                    
                    // シェアチェック
                    if (sqlConnection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: シェアチェック解除前にデータベースに接続できません。", releaseStatus);
                    }
                    else if (sqlTransaction == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: シェアチェック解除前にトランザクションが終了しています。", releaseStatus);
                    }
                    else if (sqlTransaction.Connection == null)
                    {
                        base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: シェアチェック解除前にトランザクションに例外が発生しました。", releaseStatus);
                    }
                    else
                    {
                        // シェアチェック解除
                        releaseStatus = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            base.WriteErrorLog("StockMoveDB.WriteForSecOrderHandleDeadLock_ShareCheckRelease: シェアチェック解除処理に失敗しました。", releaseStatus);
                        }
                    }
                #endif
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockMoveDB.WriteForSecOrderHandleDeadLock", status);
                
            }

            return status;
        }
        // ---- ADD K2020/03/25 陳艶丹　デッドロックの対応 ----------<<<<<

        /// <summary>
        /// 在庫移動情報の論理削除を操作します
        /// </summary>
        /// <param name="stockMoveList">StockMoveWorkオブジェクト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫移動情報の論理削除を操作します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.08.11</br>
        /// <br>Update Note: UOE発注送信不具合の対応（アプリケーションロック不具合対応）</br>
        /// <br>Programme  : 陳艶丹</br>
        /// <br>Date       : K2020/03/25</br>
        public int DeleteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlEncryptInfo sqlEncryptInfo       = null;
            CustomSerializeArrayList retList    = new CustomSerializeArrayList();

            string enterpriseCode   = "";
            string sectionCode      = "";
            int stockMoveFormal     = 0;
            int stockMoveSlipNo     = 0;
            int moveStatus          = 0;
            string retMsg           = "";
            string retItemInfo      = "";
            string resNm = "";
            // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
            // 拠点間発注データのDictionaryの初期化
            Dictionary<string, ArrayList> orderDataDic = null;
            // オプション情報の初期化
            int ps = 0;
            // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

            try
            {
                ArrayList stockList             = null; //在庫リスト
                ArrayList stockAcPayHistList    = null; //在庫受払履歴リスト
                ArrayList defStockMoveList      = null; //更新差分在庫移動リスト
                ArrayList defStockList          = null; //更新前在庫リスト
                
                if (stockMoveList == null || stockMoveList.Count == 0) return status;

                //パラメータチェック
                status = CheckParam(stockMoveList, out enterpriseCode, out sectionCode, out stockMoveFormal, out stockMoveSlipNo, out moveStatus, out retMsg, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //ADD 2011/09/02 #24259------------------------------->>>>>
                //コネクション生成
                if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
                {
                    SqlConnection sqlCon = CreateSqlConnection();
                    if (sqlCon == null) return status;
                    sqlCon.Open();

                    //拠点設定の取得
                    status = GetSecInfoSetWork(stockMoveList, ref secInfoSetWorkHash, ref sqlCon);
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retMsg = "拠点設定の取得に失敗しました。";
                        return status;
                    }
                }
                if (!_isRecv)
                {
                    _isRecv = true;
                }
                //ADD 2011/09/02 #24259-------------------------------<<<<<

                // 出庫倉庫・入庫倉庫 読み込み
                StockMoveWork _stockMoveWork = stockMoveList[0] as StockMoveWork;                

                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                ////ＡＰロック
                //resNm = GetResourceName(enterpriseCode);
                // 企業コードが空欄の場合
                if (string.IsNullOrEmpty(enterpriseCode))
                {
                    try
                    {
                        ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                        enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                        // サーバー側共通部品で空欄の企業コードが取得される場合
                        if (string.IsNullOrEmpty(enterpriseCode))
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData:共通部品で企業コードを取得した際に空欄の企業コードが取得されました。", status);
                        }
                    }
                    catch
                    {
                        base.WriteErrorLog("StockMoveDB.DeleteForReceiveData:共通部品で企業コードを取得した際に例外が発生しました。", status);
                    }
                }
                // ロックリソース名
                resNm = GetResourceName(enterpriseCode);
                // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "ロックタイムアウトが発生しました。";
                    }
                    else
                    {
                        retMsg = "排他ロックに失敗しました。";
                    }
                    base.WriteErrorLog(string.Format("StockMoveDB.DeleteForReceiveData_Lock:{0}", retMsg), status);  // ADD K2020/03/25 陳艶丹　アプリケーションロック不具合対応
                    return status;
                }

                try
                {
                    // ---- ADD K2013/12/25 鄧潘ハン ---- >>>>>
                    orderDataDic = new Dictionary<string, ArrayList>();
                    ps = 0;
                    // ---- ADD K2013/12/25 鄧潘ハン ---- <<<<<

                    //更新前の在庫移動データを取得
                    status = GetStockMove((int)ct_ProcMode.Delete, stockMoveSlipNo, out defStockMoveList, ref stockMoveList, sqlConnection, sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //既に論理削除或いは存在しない場合　何もしない
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }
                    //在庫系更新用パラメータ作成
                    //データ生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, ref sqlConnection, ref sqlTransaction);// DEL K2013/12/25 鄧潘ハン
                        status = TransStockMoveToStock((int)ct_ProcMode.Delete, true, 0, stockMoveSlipNo, defStockMoveList, defStockMoveList, defStockMoveList, defStockList, out stockList, out stockAcPayHistList, orderDataDic, ps, ref sqlConnection, ref sqlTransaction);// ADD K2013/12/25 鄧潘ハン

                    //在庫データ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        string origin = "";
                        CustomSerializeArrayList originList = null;
                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        paraList.Add(stockList);
                        paraList.Add(stockAcPayHistList);
                        int position = 0;
                        string param = "";
                        object freeParam = null;
                        status = _stockDB.Delete(origin, ref originList, ref paraList, position, param, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    }
                }
                finally
                {
                    //ＡＰアンロック
                    if (resNm != "")
                    {
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ---------->>>>>
                        //Release(resNm, sqlConnection, sqlTransaction);
                        int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (sqlConnection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: アプリケーションロック解除前にデータベースに接続できません。", releaseStatus);
                        }
                        else if (sqlTransaction == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: アプリケーションロック解除前にトランザクションが終了しています。", releaseStatus);
                        }
                        else if (sqlTransaction.Connection == null)
                        {
                            base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: アプリケーションロック解除前にトランザクションに例外が発生しました。", releaseStatus);
                        }
                        else
                        {
                            //●排他ロックを解除する
                            releaseStatus = Release(resNm, sqlConnection, sqlTransaction);
                            if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                base.WriteErrorLog("StockMoveDB.DeleteForReceiveData_Release: アプリケーションロック解除処理に失敗しました。", releaseStatus);
                            }
                        }
                        // --- UPD K2020/03/25 陳艶丹　アプリケーションロック不具合対応 ----------<<<<<
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteForReceiveData(ArrayList stockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }            
            return status;

        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="secCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 孫東響</br>
        /// <br>Date        : 2011/09/02</br>
        /// </remarks>
        private string GetSecNameBySecCode(string secCode)
        {
            if (string.IsNullOrEmpty(secCode))
            {
                return null;
            }
            if (secInfoSetWorkHash.Contains(secCode))
            {
                return secInfoSetWorkHash[secCode].ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        // --- ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応 ----->>>>>
        #region ログ出力
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <remarks>
        /// <br>Note       : ログ出力処理。</br>
        /// <br>Programer  : 譚洪</br>
        /// <br>Date       : K2019/02/27</br>
        /// <br>Update Note: K2021/02/02 呉元嘯</br>
        /// <br>管理番号   : 11601223-00 PMKOBETSU-4114対応</br>
        /// <br>             入荷処理ログ追加対応</br>
        /// </remarks>
        /// <returns>なし</returns>
        public void OutputClcLog(string message)
        {
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
            try
            {
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<

                DateTime now = DateTime.Now;

                // ログファイル名称作成
                // "MAZAI04124R"+DateTimeのyyyyMMdd+従業員ID
                ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                string logFileName = string.Format("MAZAI04124R_{0:yyyyMMdd}_{1}.log", now, serverLoginInfoAcquisition.EmployeeCode.Trim());

                // ログ内容
                string logContents = string.Format("{0} ==> {1}", now.ToString("yyyy/MM/dd HH:mm:ss fff"), message);

                // --- UPD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
                //KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
                //log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "CLCLogTextOut", logFileName, logContents);
                // LOGフォルダへログ出力
                //WriteLog(logFileName, logContents);
                // CLCログ出力区分がtrueの場合、CLCログを出力
                if (ClcLogOutDiv)
                {
                    string guid = Guid.NewGuid().ToString().Replace("-", "");
                    string ClclogFileName = string.Format("MAZAI04124R_{0:yyyyMMddHHmmssfff}_{1}_{2}.log", now, serverLoginInfoAcquisition.EmployeeCode.Trim(), guid);
                    // ProgramData側へログ出力
                    KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
                    // clcログファイル名:"MAZAI04124R"+DateTimeのyyyyMMdd+従業員ID+Guid.NewGuid()
                    log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "CLCLogTextOut", ClclogFileName, logContents);
                }
                // サーバーログ出力区分がtrueの場合、サーバーログを出力
                if (ServerLogOutDiv)
                {
                    // LOGフォルダへログ出力
                    WriteLog(logFileName, logContents);
                }
                // --- UPD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
            }
            catch
            {
                //処理なし
            }
            // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
        }

        /// <summary>
        /// LOGフォルダへログ出力
        /// </summary>
        /// <param name="logFileName">ログファイル名</param>
        /// <param name="message">ログ内容</param>
        /// <remarks>
        /// <br>Note        : LOGフォルダへログ出力を行います。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/02/27</br>
        /// </remarks>
        private static void WriteLog(string logFileName, string message)
        {
            System.IO.StreamWriter writer = null;

            try
            {
                // Logフォルダー
                string workDir; // 実行ファイルのあるディレクトリ
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                string logFolderPath = System.IO.Path.Combine(workDir, "Log\\MAZAI04124R_RES");
                if (!System.IO.Directory.Exists(logFolderPath))
                {
                    // Logフォルダーが存在しない場合、作成する
                    System.IO.Directory.CreateDirectory(logFolderPath);
                }

                // ログファイル
                string logFilePath = System.IO.Path.Combine(logFolderPath, logFileName);
                writer = new System.IO.StreamWriter(logFilePath, true, System.Text.Encoding.Default);

                // ログを書く
                writer.WriteLine(message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

        }

        /// <summary>
        /// 物理メモリ合計の出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログ出力処理。</br>
        /// <br>Programer  : 譚洪</br>
        /// <br>Date       : K2019/02/27</br>
        /// </remarks>
        /// <returns>物理メモリ合計</returns>
        public string GetTotalMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            long totalMb = Convert.ToInt64(computerInfo.TotalPhysicalMemory.ToString()) / 1024 / 1024;
            return totalMb.ToString();
        }

        /// <summary>
        /// 利用可能物理メモリの出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログ出力処理。</br>
        /// <br>Programer  : 譚洪</br>
        /// <br>Date       : K2019/02/27</br>
        /// </remarks>
        /// <returns>利用可能物理メモリ</returns>
        public string GetAvaliableMemory()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            long avaliableMb = Convert.ToInt64(computerInfo.AvailablePhysicalMemory.ToString()) / 1024 / 1024;
            return avaliableMb.ToString();
        }
        #endregion
        // --- ADD BY 譚洪 K2019/02/27 FOR Redmine#49811の対応 -----<<<<<

        // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 --->>>>>
        #region XML取得
        /// <summary>
        /// XML取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : XML取得を行います。</br>
        /// <br>Programmer  : 呉元嘯</br>
        /// <br>Date        : K2021/02/02</br>
        /// </remarks>
        private void GetXml()
        {
            try
            {
                // Logフォルダー
                string workDir; // 実行ファイルのあるディレクトリ
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else// あっているケース
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                string filemPath = System.IO.Path.Combine(workDir, StockMoveLogOutCheckEnablerFileNm);
                // 在庫移動ログ出力可否制御ファイルが存在した場合
                if (System.IO.File.Exists(filemPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(filemPath, settings))
                    {
                        // 在庫移動ログ出力可否制御ファイルを読み込む
                        while (reader.Read())
                        {
                            //CLCログ出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("ClcLogOutDiv")) ClcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //サーバーログ出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("ServerLogOutDiv")) ServerLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ServerLogOutDiv").Trim());
                        }
                    }
                }
                else　// 在庫移動ログ出力可否制御ファイルが存在しない場合
                {
                    ClcLogOutDiv = false;
                    ServerLogOutDiv = false;
                }
                FirstFlg = false;
            }
            catch
            {
                ClcLogOutDiv = false;
                ServerLogOutDiv = false;
                FirstFlg = true;
            }
        }
        #endregion
        // --- ADD BY 呉元嘯 K2021/02/02 FOR PMKOBETSU-4114の対応 ---<<<<<
    }

    #region 比較クラス
    /// <summary>
    /// 在庫移動クラス比較クラス
    /// </summary>
    /// <remarks>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.01</br>
    /// </remarks>
    public class StockMoveWorkComparer : System.Collections.IComparer
    {
        /// <summary>
        /// 移動伝票比較メソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;

            StockMoveWork cx = (StockMoveWork)x;
            StockMoveWork cy = (StockMoveWork)y;

            //在庫移動伝票番号
            result = cx.StockMoveSlipNo - cy.StockMoveSlipNo;
            //在庫移動行番号
            if (result == 0)
                result = cx.StockMoveRowNo - cy.StockMoveRowNo;

            //結果を返す
            return result;
        }
    }
    #endregion

}
