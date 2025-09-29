//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/06/24  修正内容 : 価格管理件数の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/03/31  修正内容 : Mantis.15256 商品マスタインポートの対象項目設定対応
//                       修正内容 : Mantis.15272 価格マスタの更新について、画面の処理区分が反映されていない件の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/26  修正内容 : 内部発見バッグの対応：桁数チェック時、全角符号を一桁に計算するように変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/03  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/05  修正内容 : 大陽案件、Redmine#30387 障害一覧の指摘NO.19の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/10  修正内容 : 大陽案件、Redmine#30387 障害一覧の指摘NO.55の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/07/12  修正内容 : 大陽案件、Redmine#30387 障害一覧の指摘NO.93の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/25  修正内容 : 大陽案件、Redmine#30387 エラーメッセージの変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/07/26  修正内容 : Redmine#30387  障害一覧の指摘NO.94の対応 エラーメッセージの変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 修 正 日  2013/06/14  修正内容 : Redmine#35805 
//                                  商品マスタインポート OutOfMemory Exception(イスコ GCサーバモード)
//----------------------------------------------------------------------------//
// 管理番号  11175183-00 作成担当 : 田建委
// 修 正 日  2015/05/20  修正内容 : Redmine#45693
//                                    イスコ　商品マスタインポート OutOfMemory解除対応
//----------------------------------------------------------------------------//
// 管理番号  11175183-00 作成担当 : 田建委
// 修 正 日  2015/07/24  修正内容 : Redmine#45693
//                                  イスコ　商品マスタインポート 商品マスタと価格マスタを一時テーブルをJOINして検索する変更
//----------------------------------------------------------------------------//
// 管理番号  11175183-00 作成担当 : 田建委
// 修 正 日  2015/08/22  修正内容 : Redmine#45693 一時テーブルの削除タイミングを変更する
//----------------------------------------------------------------------------//
// 管理番号  11175183-00 作成担当 : 田建委
// 修 正 日  2015/08/26  修正内容 : 商品マスタ/価格マスタの検索処理に、もしCSVのデータがDBに存在しない場合、次の処理が終了しなくて、statusの判断を削除する
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions; // ADD wangf 2012/06/12 FOR Redmine#30387
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
//using Broadleaf.Library.Globarization; // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Globalization; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタ（インポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（インポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2012/07/20 wangf </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
    /// <br>Update Note: 2012/07/25 wangf </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 エラーメッセージの変更の対応</br>
    /// <br>Update Note: 2012/07/26 李亜博</br>
    /// <br>             10801804-00、大陽案件、Redmine#30387  障害一覧の指摘NO.94の対応 エラーメッセージの変更の対応</br>
    /// <br>Update Note: 2013/06/14 liusy</br>
    /// <br>             10801804-00、Redmine#35805 商品マスタインポート OutOfMemory Exception(イスコ GCサーバモード)</br>
    /// <br>Update Note: 2015/05/20 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 イスコ　商品マスタインポート OutOfMemory解除対応</br>
    /// <br>           : ①商品マスタと価格マスタの全件検索を廃止し、CSVのメーカーで分割して検索するように変更</br>
    /// <br>           : ②商品マスタと価格マスタのDictionaryのKEYをクラスの型からStringの型へ変更</br>
    /// <br>           : ③使用しないListとDictionaryをクリアする</br>
    /// <br>           : ④二重ループの廃止し、foreachの代わりにDictionaryを使用する</br>
    /// <br>           : ⑤既存障害：処理区分「追加」の場合、不具合の対応</br>
    /// <br>Update Note: 2015/07/24 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 イスコ　商品マスタインポート 商品マスタと価格マスタを一時テーブルをJOINして検索する変更</br>
    /// <br>Update Note: 2015/08/22 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 一時テーブルの削除タイミングを変更する</br>
    /// <br>Update Note: 2015/08/26 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 商品マスタ/価格マスタの検索処理に、もしCSVのデータがDBに存在しない場合、次の処理が終了しなくて、statusの判断を削除する</br>
    /// </remarks>
    [Serializable]
    public class GoodsUImportDB : RemoteDB, IGoodsUImportDB
    {
        /// <summary>
        /// 商品マスタ（インポート）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsUImportDB()
            : base("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "GOODSURF")
        {
        }

        # region [Import]
        /// <summary>
        /// 商品マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品マスタインポートデータリスト</param>
        /// <param name="importGoodsPriceWorkList">価格マスタインポートデータリスト</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">商品・価格ワークインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="importSetUpList">インポート対象設定リスト</param>
        /// <param name="paraPriceStartDate">価格開始年月日</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        // 2010/03/31 >>>
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList) // DEL wangf 2012/06/12 FOR Redmine#30387
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, ref DataTable table, DateTime paraPriceStartDate) // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
        //public int Import(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        public int Import(Int32 processKbn, Int32 dataCheckKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/20 FOR Redmine#30387
        // 2010/03/31 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            if (table == null)
            {
                table = new DataTable();
                CreateDataTable(ref table);
            }
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
            // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // インポート処理
                // 2010/03/31 >>>
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList); // DEL wangf 2012/06/12 FOR Redmine#30387
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, ref table, paraPriceStartDate); // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
                //status = this.ImportProc(processKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, paraPriceStartDate); // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
                status = this.ImportProc(processKbn, dataCheckKbn, ref importGoodsWorkList, ref importGoodsPriceWorkList, ref importGoodsUGoodsPriceUWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction, importSetUpList, paraPriceStartDate); // ADD wangf 2012/07/20 FOR Redmine#30387
                // 2010/03/31 <<<
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="importGoodsWorkList">商品マスタインポートデータリスト</param>
        /// <param name="importGoodsPriceWorkList">価格マスタインポートデータリスト</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">商品・価格ワークインポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">コレクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="importSetUpList">インポート対象設定リスト</param>
        /// <param name="paraPriceStartDate">価格開始年月日</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note : 2012/07/05 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 障害一覧の指摘NO.19の対応</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        /// <br>Update Note : 2013/06/14 liusy</br>
        /// <br>             10801804-00、Redmine#35805 商品マスタインポート OutOfMemory Exception(イスコ GCサーバモード)</br>
        /// <br>Update Note : 2015/05/20 田建委</br>
        /// <br>管理番号    : 11175183-00</br>
        /// <br>            : Redmine#45693 イスコ　商品マスタインポート OutOfMemory解除対応</br>
        /// <br>Update Note : 2015/07/24 田建委</br>
        /// <br>管理番号    : 11175183-00</br>
        /// <br>            : Redmine#45693 イスコ　商品マスタインポート 商品マスタと価格マスタを一時テーブルをJOINして検索する変更</br>
        /// <br>Update Note : 2015/08/22 田建委</br>
        /// <br>管理番号    : 11175183-00</br>
        /// <br>            : Redmine#45693 一時テーブルの削除タイミングを変更する</br>
        /// <br>Update Note : 2015/08/26 田建委</br>
        /// <br>管理番号    : 11175183-00</br>
        /// <br>            : Redmine#45693 商品マスタ/価格マスタの検索処理に、もしCSVのデータがDBに存在しない場合、次の処理が終了しなくて、statusの判断を削除する</br>
        // 2010/03/31 >>>
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList) // DEL wangf 2012/06/12 FOR Redmine#30387
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, ref DataTable table, DateTime paraPriceStartDate) // ADD wangf 2012/06/12 FOR Redmine#30387 // DEL wangf 2012/07/03 FOR Redmine#30387
        //private int ImportProc(Int32 processKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        private int ImportProc(Int32 processKbn, Int32 dataCheckKbn, ref object importGoodsWorkList, ref object importGoodsPriceWorkList, ref object importGoodsUGoodsPriceUWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, object importSetUpList, DateTime paraPriceStartDate) // ADD wangf 2012/07/20 FOR Redmine#30387
        // 2010/03/31 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //----- ADD 2015/07/24 田建委 Redmine#45693 ---------->>>>>
            SqlCommand sqlCommand = null;
            string goodsTblName = string.Empty;
            //----- ADD 2015/07/24 田建委 Redmine#45693 ----------<<<<<

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            ArrayList GoodsUList = new ArrayList();
            ArrayList GoodsPriceUList = new ArrayList();
            GoodsUWork paraGoodsUWork = new GoodsUWork();
            GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
            List<int[]> setUpInfoList = (List<int[]>)importSetUpList;// 2010/03/31 Add
            
            // 商品マスタの登録フラグ
            bool isAddUpdFlg = false;

            // 商品マスタのDBリモートクラス
            GoodsUDB GoodsUDB = new GoodsUDB();
            // 価格マスタのDBリモートクラス
            GoodsPriceUDB GoodsPriceUDB = new GoodsPriceUDB();
            // ADD 2009/06/24 --->>>
            // 提供データ更新設定のDBリモートクラス
            PriceChgProcStDB PriceChgProcStDB = new PriceChgProcStDB();
            Int32 priceMngCnt = 0;
            // ADD 2009/06/24 ---<<<
            /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            // 自社情報設定のDBリモートクラス
            CompanyInfDB companyInfDB = new CompanyInfDB();
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
            // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/
            try
            {
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // 商品・価格ワーク
                ArrayList importGoodsGoodsPriceWorkArray = importGoodsUGoodsPriceUWorkList as ArrayList;
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                List<GoodsUGoodsPriceUWork> goodsUGoodsPriceUWorkCheckList = new List<GoodsUGoodsPriceUWork>();
                GoodsUGoodsPriceUWork[] arr = (GoodsUGoodsPriceUWork[])importGoodsGoodsPriceWorkArray.ToArray(typeof(GoodsUGoodsPriceUWork));
                goodsUGoodsPriceUWorkCheckList.AddRange(arr);
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                if (importGoodsGoodsPriceWorkArray == null || importGoodsGoodsPriceWorkArray.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                // パラメータの設定
                // 商品マスタのパラメータの設定
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    paraGoodsUWork.EnterpriseCode = ((GoodsUWork)importGoodsWorkArray[0]).EnterpriseCode;
                }
                // 価格マスタのパラメータの設定
                ArrayList importGoodsPriceWorkArray = importGoodsPriceWorkList as ArrayList;
                if (importGoodsPriceWorkArray != null && importGoodsPriceWorkArray.Count > 0)
                {
                    paraGoodsPriceUWork.EnterpriseCode = ((GoodsPriceUWork)importGoodsPriceWorkArray[0]).EnterpriseCode;
                }
                // ADD 2009/06/24 --->>>
                ArrayList addUpdGoodsUList = new ArrayList();
                // 提供データ更新設定のパラメータの設定
                PriceChgProcStWork priceChgProcStWork = new PriceChgProcStWork();
                priceChgProcStWork.EnterpriseCode = paraGoodsUWork.EnterpriseCode;
                // ADD 2009/06/24 ---<<<

                //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                //// 全件検索処理を行う
                //// 全て商品マスタのデータの検索処理
                //GoodsUDB.SearchGoodsUProc(out GoodsUList, paraGoodsUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);

                //// 全て価格マスタのデータの検索処理
                //GoodsPriceUDB.SearchGoodsPriceProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<

                //----- ADD 2015/08/22 田建委 Redmine#45693 ---------->>>>>
                try
                {
                    //----- ADD 2015/08/22 田建委 Redmine#45693 ----------<<<<<
                    //----- ADD 2015/07/24 田建委 Redmine#45693 ---------->>>>>
                    // ①CSVの商品（企業コード・メーカー・品番）を一時テーブルに格納する
                    string tableNameGuid = Guid.NewGuid().ToString();
                    goodsTblName = "##GOODSM_" + tableNameGuid.Replace('-', '_');

                    string sqlText = "CREATE TABLE " + goodsTblName + " ( ENTERPRISECODERF nchar(16) COLLATE DATABASE_DEFAULT NOT NULL, GOODSMAKERCDRF int NOT NULL, GOODSNORF nvarchar(40) COLLATE DATABASE_DEFAULT NOT NULL) ";
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();

                    // CSVのデータをDataTableに転換する
                    string enterpriseCode = "ENTERPRISECODERF";
                    string goodsMakerCode = "GOODSMAKERCDRF";
                    string goodsNo = "GOODSNORF";

                    DataTable dt = new DataTable();
                    // 企業コード
                    DataColumn col01 = new DataColumn(enterpriseCode, typeof(string));
                    dt.Columns.Add(col01);
                    // メーカー
                    DataColumn col02 = new DataColumn(goodsMakerCode, typeof(Int32));
                    dt.Columns.Add(col02);
                    // 品番
                    DataColumn col03 = new DataColumn(goodsNo, typeof(string));
                    dt.Columns.Add(col03);

                    DataRow row = null;
                    for (int i = 0; i < importGoodsWorkArray.Count; i++)
                    {
                        // 商品マスタオブジェクト
                        GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                        row = dt.NewRow();

                        row[enterpriseCode] = importGoodsUWork.EnterpriseCode; // 企業コード
                        row[goodsMakerCode] = importGoodsUWork.GoodsMakerCd; // メーカー
                        row[goodsNo] = importGoodsUWork.GoodsNo; // 品番

                        dt.Rows.Add(row);
                    }
                    // 重複のデータを一つ保持する
                    DataTable table = dt.DefaultView.ToTable(true, new string[] { enterpriseCode, goodsMakerCode, goodsNo });

                    // 一時テーブルにデータのINSERT
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    SqlBulkCopy sbc = new SqlBulkCopy(connectionText, SqlBulkCopyOptions.UseInternalTransaction);
                    sbc.BulkCopyTimeout = 3600;
                    sbc.NotifyAfter = dt.Rows.Count;

                    sbc.DestinationTableName = goodsTblName;
                    sbc.WriteToServer(table);
                    dt.Dispose();
                    table.Dispose();

                    // 一時テーブルのインデックスの作成(企業コード・メーカー・品番)
                    sqlText = string.Empty;
                    sqlText = "CREATE NONCLUSTERED INDEX GOODSM_IDX1 ON " + goodsTblName + " (ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF)";
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    //----- ADD 2015/07/24 田建委 Redmine#45693 ----------<<<<<

                    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    Dictionary<int, List<string>> goodsDict = new Dictionary<int, List<string>>();
                    // CSVファイルから読み込んだデータをメーカーコードで分割する
                    // 同一メーカーコードの品番をリストへ格納する
                    for (int i = 0; i < importGoodsWorkArray.Count; i++)
                    {
                        // 商品マスタオブジェクト
                        GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                        if (!goodsDict.ContainsKey(importGoodsUWork.GoodsMakerCd)) // メーカーコードで分割
                        {
                            List<string> goodsNoList = new List<string>();
                            goodsNoList.Add(importGoodsUWork.GoodsNo);
                            goodsDict.Add(importGoodsUWork.GoodsMakerCd, goodsNoList);
                        }
                        else
                        {
                            goodsDict[importGoodsUWork.GoodsMakerCd].Add(importGoodsUWork.GoodsNo);
                        }
                    }

                    // 企業コード
                    string tempEnterpriseCode = paraGoodsUWork.EnterpriseCode;
                    // 商品マスタリスト
                    if (GoodsUList == null)
                    {
                        GoodsUList = new ArrayList();
                    }
                    // 価格マスタリスト
                    if (GoodsPriceUList == null)
                    {
                        GoodsPriceUList = new ArrayList();
                    }
                    // メーカーコードで分割して、商品マスタデータと価格マスタデータを検索する
                    foreach (KeyValuePair<int, List<string>> dict in goodsDict)
                    {
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ---------->>>>>
                        // DB照合順の影響のため、品番条件を削除
                        //List<string> goodsNoList = dict.Value;
                        //// 品番昇順でソートする
                        //goodsNoList.Sort();
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ----------<<<<<

                        #region 商品マスタのデータの検索処理
                        paraGoodsUWork = new GoodsUWork();
                        paraGoodsUWork.EnterpriseCode = tempEnterpriseCode; // 企業コード
                        paraGoodsUWork.GoodsMakerCd = dict.Key; // メーカーコード
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ---------->>>>>
                        // DB照合順の影響のため、品番条件を削除
                        //paraGoodsUWork.GoodsNoSt = goodsNoList[0]; // 最小の品番
                        //paraGoodsUWork.GoodsNoEd = goodsNoList[goodsNoList.Count - 1]; // 最大の品番
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ----------<<<<<

                        // 検索
                        ArrayList goodsUList = null;
                        //GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // DEL 2015/07/24 田建委 Redmine#45693
                        //GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/07/24 田建委 Redmine#45693 // DEL 2015/08/22 田建委 Redmine#45693
                        //status = GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/22 田建委 Redmine#45693 // DEL 2015/08/26 田建委 Redmine#45693
                        GoodsUDB.SearchGoodsUForGoodsImport(out goodsUList, paraGoodsUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/26 田建委 Redmine#45693
                        //----- DEL 2015/08/26 田建委 Redmine#45693 ---------->>>>>
                        // CSVのデータが商品マスタに存在しない場合、後の処理がそのまま進むはず、元のstatusとbreak処理を削除する。
                        ////----- ADD 2015/08/22 田建委 Redmine#45693 ------>>>>>
                        //// 検索失敗の場合、処理終了とする
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    break;
                        //}
                        ////----- ADD 2015/08/22 田建委 Redmine#45693 ------<<<<<
                        //----- DEL 2015/08/26 田建委 Redmine#45693 ----------<<<<<
                        GoodsUList.AddRange(goodsUList);
                        #endregion

                        #region 価格マスタのデータの検索処理
                        // 検索パラメータの設定
                        paraGoodsPriceUWork = new GoodsPriceUWork();
                        paraGoodsPriceUWork.EnterpriseCode = tempEnterpriseCode; // 企業コード
                        paraGoodsPriceUWork.GoodsMakerCd = dict.Key; // メーカーコード
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ---------->>>>>
                        // DB照合順の影響のため、品番条件を削除
                        //paraGoodsPriceUWork.GoodsNoSt = goodsNoList[0]; // 最小の品番
                        //paraGoodsPriceUWork.GoodsNoEd = goodsNoList[goodsNoList.Count - 1]; // 最大の品番
                        //----- DEL 2015/07/24 田建委 Redmine#45693 ----------<<<<<

                        // 検索
                        ArrayList goodsPriceList = null;
                        //GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // DEL 2015/07/24 田建委 Redmine#45693
                        //GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/07/24 田建委 Redmine#45693 // DEL 2015/08/22 田建委 Redmine#45693
                        //status = GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/22 田建委 Redmine#45693 // DEL 2015/08/26 田建委 Redmine#45693
                        GoodsPriceUDB.SearchGoodsPriceForGoodsImport(out goodsPriceList, paraGoodsPriceUWork, goodsTblName, ConstantManagement.LogicalMode.GetData01, ref sqlConnection); // ADD 2015/08/26 田建委 Redmine#45693
                        //----- DEL 2015/08/26 田建委 Redmine#45693 ---------->>>>>
                        // CSVのデータが価格マスタに存在しない場合、後の処理がそのまま進むはず、元のstatusとbreak処理を削除する。
                        ////----- ADD 2015/08/22 田建委 Redmine#45693 ------>>>>>
                        //// 検索失敗の場合、処理終了とする
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    break;
                        //}
                        ////----- ADD 2015/08/22 田建委 Redmine#45693 ------<<<<<
                        //----- DEL 2015/08/26 田建委 Redmine#45693 ----------<<<<<
                        GoodsPriceUList.AddRange(goodsPriceList);
                        #endregion
                    }
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                //----- ADD 2015/08/22 田建委 Redmine#45693 ---------->>>>>
                }
                catch (Exception e)
                {
                    GoodsUList = null;
                    GoodsPriceUList = null;
                    errMsg = e.Message;
                    base.WriteErrorLog(e, errMsg, -1);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    // 一時テーブルを削除する
                    DropTempTbl(goodsTblName, ref sqlConnection);
                }

                // 例外が発生の場合、処理終了とする
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                //----- ADD 2015/08/22 田建委 Redmine#45693 ------<<<<<
                //----- ADD 2015/08/22 田建委 Redmine#45693 ----------<<<<<

                // 価格管理件数の取得
                PriceChgProcStDB.Read(ref priceChgProcStWork, 0, ref sqlConnection, ref sqlTransaction);
                priceMngCnt = priceChgProcStWork.PriceMngCnt;

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // 全件検索結果をDictionaryに格納する
                // 商品マスタのDictionaryの作成
                //Dictionary<GoodsUImportWorkWrap, GoodsUWork> goodsUDict = new Dictionary<GoodsUImportWorkWrap, GoodsUWork>(); // DEL 2015/05/20 田建委 Redmine#45693
                // メモリを節約するためDictionaryのKEYのタイプをstringに変更する
                Dictionary<string, GoodsUWork> goodsUDict = new Dictionary<string, GoodsUWork>(); // ADD 2015/05/20 田建委 Redmine#45693
                foreach (GoodsUWork work in GoodsUList)
                {
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    //GoodsUImportWorkWrap warp = new GoodsUImportWorkWrap(work);
                    //goodsUDict.Add(warp, work);
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    // KEY:企業コード、商品メーカーコード、商品番号
                    string goodsKey = string.Format("{0}/{1}/{2}", work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo);
                    // 商品マスタに同一主キーのデータが複数存在しないので、直接にDictionaryへ追加してもいい
                    goodsUDict.Add(goodsKey, work);
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                }
                // 価格マスタのDictionaryの作成
                //Dictionary<GoodsPriceUImportWorkWrap, GoodsPriceUWork> goodsPriceUDict = new Dictionary<GoodsPriceUImportWorkWrap, GoodsPriceUWork>(); // DEL 2015/05/20 田建委 Redmine#45693
                // メモリを節約するためDictionaryのKEYのタイプをstringに変更する
                Dictionary<string, GoodsPriceUWork> goodsPriceUDict = new Dictionary<string, GoodsPriceUWork>(); // ADD 2015/05/20 田建委 Redmine#45693
                foreach (GoodsPriceUWork work in GoodsPriceUList)
                {
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    //GoodsPriceUImportWorkWrap warp = new GoodsPriceUImportWorkWrap(work);
                    //goodsPriceUDict.Add(warp, work);
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    // KEY:企業コード、商品メーカーコード、商品番号、価格開始日
                    string priceKey = string.Format("{0}/{1}/{2}/{3}", work.EnterpriseCode, work.GoodsMakerCd, work.GoodsNo, work.PriceStartDate.ToString("yyyyMMdd"));
                    // 価格マスタに同一主キーのデータが複数存在しないので、直接にDictionaryへ追加してもいい
                    goodsPriceUDict.Add(priceKey, work);
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                }

                // 追加と更新データの作成
                // 商品マスタの追加リスト
                ArrayList addGoodsUList = new ArrayList();
                // 商品マスタの更新リスト
                ArrayList updGoodsUList = new ArrayList();
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // 価格マスタの追加更新リスト
                ArrayList addUpdGoodsPriceUList = new ArrayList();
                List<GoodsPriceUWork> goodsPriceUWorkList = new List<GoodsPriceUWork>();

                int wkMakerCd = 0;
                string wkGoodsNo = "";
                int goodsPriceNo = 0;
                int addCnt2 = 0;
                int updCnt2 = 0;
                bool addFlg = false;
                bool updFlg = false;

                // インポート用商品マスタリストに繰り返される、商品オブジェクトと関する価格リストオブジェクト処理を行う
                for (int i = 0; i < importGoodsWorkArray.Count; i++)
                {
                    string msg = String.Empty;
                    if (goodsPriceUWorkList.Count > 0) goodsPriceUWorkList.Clear();

                    // チェック用商品・価格ワーク情報
                    GoodsUGoodsPriceUWork goodsUGoodsPriceUWork = (GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i];

                    // 商品マスタオブジェクト
                    GoodsUWork importGoodsUWork = (GoodsUWork)importGoodsWorkArray[i];
                    //GoodsUImportWorkWrap importGoodsUImportWorkWrap = new GoodsUImportWorkWrap(importGoodsUWork); // DEL 2015/05/20 田建委 Redmine#45693
                    // 商品マスタオブジェクト関する格リストオブジェクトの初期化
                    // CSVファイルがインポートされたら、商品1=>価格5の関連があるによって、価格リストの初期化が行う
                    for (int j = i * 5; j < i * 5 + 5; j++)
                    {
                        GoodsPriceUWork importGoodsPriceUWork = (GoodsPriceUWork)importGoodsPriceWorkArray[j];
                        goodsPriceUWorkList.Add(importGoodsPriceUWork);
                    }
                    // 商品マスタ追加、更新判断
                    //if (!goodsUDict.ContainsKey(importGoodsUImportWorkWrap)) // DEL 2015/05/20 田建委 Redmine#45693
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    // KEY:企業コード、商品メーカーコード、商品番号
                    string goodsKey = string.Format("{0}/{1}/{2}", importGoodsUWork.EnterpriseCode, importGoodsUWork.GoodsMakerCd, importGoodsUWork.GoodsNo);
                    if (!goodsUDict.ContainsKey(goodsKey))
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                    {
                        // 画面.更新区分：追加、追加更新すると、チェック行う
                        if (processKbn == 1 || processKbn == 0)
                        {
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, out msg)) // DEL wangf 2012/07/03 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                            // ここで、オブジェクトが追加すれば、設定リスト無効です、画面.更新区分判断必要
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 0, out msg)) // DEL wangf 2012/07/20 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 0, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                            {
                                //ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, msg, ref table); // DEL wangf 2012/07/03 FOR Redmine#30387
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg; // ADD wangf 2012/07/03 FOR Redmine#30387
                                continue;
                            }
                            // レコードが存在しなければ、追加リストへ追加する。
                            addGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, null, false, setUpInfoList));
                        }
                    }
                    else
                    {
                        if (processKbn == 2 || processKbn == 0)
                        {
                            // 画面.更新区分：更新、追加更新すると、チェック行う
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, out msg)) // DEL wangf 2012/07/03 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                            // ここで、オブジェクトが更新・追加更新すれば、設定リスト有効です、画面.更新区分判断必要ない
                            //if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, out msg))  // DEL wangf 2012/07/20 FOR Redmine#30387
                            // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                            {
                                //ConverToDataSetCustomerInf(goodsUGoodsPriceUWork, msg, ref table); // DEL wangf 2012/07/03 FOR Redmine#30387
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg; // ADD wangf 2012/07/03 FOR Redmine#30387
                                continue;
                            }
                            // レコードが存在すれば、更新リストへ追加する。
                            //updGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, goodsUDict[importGoodsUImportWorkWrap], true, setUpInfoList)); // DEL 2015/05/20 田建委 Redmine#45693
                            updGoodsUList.Add(ConvertToGoodsUImportWork(importGoodsUWork, goodsUDict[goodsKey], true, setUpInfoList)); // ADD 2015/05/20 田建委 Redmine#45693
                        }
                        //----- ADD 2015/05/20 田建委 Redmine#45693 既存障害２ ---------->>>>>
                        else
                        {
                            // 画面.処理区分：追加すると、チェック行う
                            // 理由：商品マスタに存在するCSVの品番に対して、その価格データが価格マスタに存在しない可能性がある
                            // 「追加」にする場合、価格マスタへ登録する必要なので、チェック行う
                            if (!CheckError(goodsUGoodsPriceUWork, importSetUpList, 1, dataCheckKbn, goodsUGoodsPriceUWorkCheckList, goodsPriceUWorkList, out msg))
                            {
                                ((GoodsUGoodsPriceUWork)importGoodsGoodsPriceWorkArray[i]).ErrorMsg = msg;
                                continue;
                            }
                        }
                        //----- ADD 2015/05/20 田建委 Redmine#45693 既存障害２ ----------<<<<<
                    }
                    // 既存参照して、価格マスタの追加更新リストの処理を行う
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                    // 取込データの価格情報が無し時(価格開始年月日１～価格開始年月日５全部を設定しない時
                    // この商品の価格マスタデータを作成する。
                    int number = 0;
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                    foreach (GoodsPriceUWork importGoodsPriceUWork in goodsPriceUWorkList)
                    {
                        //if (importGoodsPriceUWork.PriceStartDate == DateTime.MinValue) continue; // DEL wangf 2012/07/05 FOR Redmine#30387
                        // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                        if (importGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                        {
                            number++;
                            continue;
                        }
                        // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                        //GoodsPriceUImportWorkWrap importGoodsPriceUImportWorkWrap = new GoodsPriceUImportWorkWrap(importGoodsPriceUWork); // DEL 2015/05/20 田建委 Redmine#45693

                        if (wkMakerCd != importGoodsPriceUWork.GoodsMakerCd || wkGoodsNo != importGoodsPriceUWork.GoodsNo)
                        {
                            wkMakerCd = importGoodsPriceUWork.GoodsMakerCd;
                            wkGoodsNo = importGoodsPriceUWork.GoodsNo;
                            goodsPriceNo = 0;
                            addFlg = false;
                            updFlg = false;
                        }

                        // 処理区分が「追加」の場合
                        if (processKbn == 1)
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 田建委 Redmine#45693
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            // KEY:企業コード、商品メーカーコード、商品番号、価格開始日
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                            {
                                // レコードが存在しなければ、追加リストへ追加する。

                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, null, false, setUpInfoList, goodsPriceNo));
                                if (!CheckUpdAddList(importGoodsPriceUWork, addGoodsUList) && !addFlg)
                                {
                                    addCnt2++;
                                    addFlg = true;
                                }
                            }
                        }
                        // 処理区分が「更新」の場合
                        else if (processKbn == 2)
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 田建委 Redmine#45693
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            // KEY:企業コード、商品メーカーコード、商品番号、価格開始日
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                            {
                            }
                            else
                            {
                                // レコードが存在すれば、更新リストへ追加する。
                                //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[importGoodsPriceUImportWorkWrap], true, setUpInfoList, goodsPriceNo)); // DEL 2015/05/20 田建委 Redmine#45693
                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[priceKey], true, setUpInfoList, goodsPriceNo)); // ADD 2015/05/20 田建委 Redmine#45693
                                if (!CheckUpdAddList(importGoodsPriceUWork, updGoodsUList) && !updFlg)
                                {
                                    updCnt2++;
                                    updFlg = true;
                                }
                            }
                        }
                        // 処理区分が「追加更新」の場合
                        else
                        {
                            //if (!goodsPriceUDict.ContainsKey(importGoodsPriceUImportWorkWrap)) // DEL 2015/05/20 田建委 Redmine#45693
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            // KEY:企業コード、商品メーカーコード、商品番号、価格開始日
                            string priceKey = string.Format("{0}/{1}/{2}/{3}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd,
                                importGoodsPriceUWork.GoodsNo, importGoodsPriceUWork.PriceStartDate.ToString("yyyyMMdd"));
                            if (!goodsPriceUDict.ContainsKey(priceKey))
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                            {
                                // レコードが存在しなければ、追加リストへ追加する。

                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, null, false, setUpInfoList, goodsPriceNo));
                                if (!CheckUpdAddList(importGoodsPriceUWork, addGoodsUList) && !addFlg)
                                {
                                    addCnt2++;
                                    addFlg = true;
                                }
                            }
                            else
                            {
                                // レコードが存在すれば、更新リストへ追加する。

                                //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[importGoodsPriceUImportWorkWrap], true, setUpInfoList, goodsPriceNo)); // DEL 2015/05/20 田建委 Redmine#45693
                                addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importGoodsPriceUWork, goodsPriceUDict[priceKey], true, setUpInfoList, goodsPriceNo)); // ADD 2015/05/20 田建委 Redmine#45693
                                if (!CheckUpdAddList(importGoodsPriceUWork, updGoodsUList) && !updFlg)
                                {
                                    updCnt2++;
                                    updFlg = true;
                                }
                            }
                        }
                        goodsPriceNo++;
                    }
                    // 商品マスタデータオブジェクトがあれば、価格情報設定しなければ、新規価格データが入れられる、価格開始年月日が自社設定.期首年月日設定される
                    // 価格更新・追加しなければ
                    //if (0 == updCnt2 && 0 == addCnt2) // DEL wangf 2012/07/05 FOR Redmine#30387
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387--------->>>>
                    // 取込データの価格情報が無し時(価格開始年月日１～価格開始年月日５全部を設定しない時、DB処理データがあれば、新規価格データを行います
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    //if (5 == number && ((!goodsUDict.ContainsKey(importGoodsUImportWorkWrap) && 1 == processKbn)
                    //    || (goodsUDict.ContainsKey(importGoodsUImportWorkWrap) && 2 == processKbn)
                    //    || 3 == processKbn))
                    //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                    // KEY:企業コード、商品メーカーコード、商品番号
                    if (5 == number && ((!goodsUDict.ContainsKey(goodsKey) && 1 == processKbn)
                        || (goodsUDict.ContainsKey(goodsKey) && 2 == processKbn)
                        || 3 == processKbn))
                    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                    // ------------ADD wangf 2012/07/05 FOR Redmine#30387---------<<<<
                    {
                        GoodsPriceUWork goodsPrice = new GoodsPriceUWork();
                        goodsPrice.EnterpriseCode = importGoodsUWork.EnterpriseCode;
                        goodsPrice.GoodsNo = importGoodsUWork.GoodsNo;
                        goodsPrice.GoodsMakerCd = importGoodsUWork.GoodsMakerCd;
                        goodsPrice.PriceStartDate = paraPriceStartDate;
                        //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                        //GoodsPriceUImportWorkWrap importGoodsPriceWrap = new GoodsPriceUImportWorkWrap(goodsPrice);
                        //if (!goodsPriceUDict.ContainsKey(importGoodsPriceWrap))
                        //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                        //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                        // KEY:企業コード、商品メーカーコード、商品番号、価格開始日
                        string priceKey = string.Format("{0}/{1}/{2}/{3}", goodsPrice.EnterpriseCode, goodsPrice.GoodsMakerCd,
                            goodsPrice.GoodsNo, goodsPrice.PriceStartDate.ToString("yyyyMMdd"));
                        if (!goodsPriceUDict.ContainsKey(priceKey))
                        //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                        {
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(goodsPrice, null, false, setUpInfoList, 0));
                        }
                    }
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                #region DEL wangf 2012/06/12 FOR Redmine#30387
                /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                foreach (GoodsUWork importWork in importGoodsWorkArray)
                {
                    GoodsUImportWorkWrap importWarp = new GoodsUImportWorkWrap(importWork);

                    if (!goodsUDict.ContainsKey(importWarp))
                    {
                        // レコードが存在しなければ、追加リストへ追加する。
                        // 2010/03/31 >>>
                        //addGoodsUList.Add(ConvertToGoodsUImportWork(importWork, null, false));
                        addGoodsUList.Add(ConvertToGoodsUImportWork(importWork, null, false, setUpInfoList));
                        // 2010/03/31 <<<
                    }
                    else
                    {
                        // レコードが存在すれば、更新リストへ追加する。
                        // 2010/03/31 >>>
                        //updGoodsUList.Add(ConvertToGoodsUImportWork(importWork, goodsUDict[importWarp], true));
                        updGoodsUList.Add(ConvertToGoodsUImportWork(importWork, goodsUDict[importWarp], true, setUpInfoList));
                        // 2010/03/31 <<<
                    }
                }
                // 価格マスタの追加更新リスト
                ArrayList addUpdGoodsPriceUList = new ArrayList();
                // 2010/03/31 Add >>>
                int wkMakerCd = 0;
                string wkGoodsNo = "";
                int goodsPriceNo = 0;
                int addCnt2 = 0;
                int updCnt2 = 0;
                bool addFlg = false;
                bool updFlg = false;
                // 2010/03/31 Add <<<
                foreach (GoodsPriceUWork importWork in importGoodsPriceWorkArray)
                {
                    GoodsPriceUImportWorkWrap importWarp = new GoodsPriceUImportWorkWrap(importWork);

                    // 2010/03/31 Add >>>
                    if (wkMakerCd != importWork.GoodsMakerCd || wkGoodsNo != importWork.GoodsNo)
                    {
                        wkMakerCd = importWork.GoodsMakerCd;
                        wkGoodsNo = importWork.GoodsNo;
                        goodsPriceNo = 0;
                        addFlg = false;
                        updFlg = false;
                    }
                    // 2010/03/31 Add <<<

                    // 処理区分が「追加」の場合
                    if (processKbn == 1)
                    {
                        // 2010/03/31 Del >>>
                        //foreach (GoodsUWork goodsImportWork in addGoodsUList)
                        //{
                        //if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                        //    goodsImportWork.GoodsNo == importWork.GoodsNo)
                        //{
                        // 2010/03/31 Del <<<
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // レコードが存在しなければ、追加リストへ追加する。
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false)); // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, addGoodsUList) && !addFlg)
                            {
                                addCnt2++;
                                addFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        else
                        {
                            // レコードが存在すれば、更新リストへ追加する。
                            // 2010/03/31 Del 「追加」の場合は更新リストへ追加しない。 >>>
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true));
                            // 2010/03/31 Del <<<
                        }
                        // 2010/03/31 Del >>>
                        //}
                        //}
                        // 2010/03/31 Del <<<
                    }
                    // 処理区分が「更新」の場合
                    else if (processKbn == 2)
                    {
                        // 2010/03/31 Del >>>
                        //foreach (GoodsUWork goodsImportWork in updGoodsUList)
                        //{
                        //if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                        //    goodsImportWork.GoodsNo == importWork.GoodsNo)
                        //{
                        // 2010/03/31 Del <<<
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // レコードが存在しなければ、追加リストへ追加する。
                            // 2010/03/31 Del 「更新」の場合は追加リストへ追加しない。 >>>
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false));
                            // 2010/03/31 Del <<<
                        }
                        else
                        {
                            // レコードが存在すれば、更新リストへ追加する。
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true));   // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, updGoodsUList) && !updFlg)
                            {
                                updCnt2++;
                                updFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        // 2010/03/31 Del >>>
                        //}
                        //}
                        // 2010/03/31 Del <<<
                    }
                    // 処理区分が「追加更新」の場合
                    else
                    {
                        if (!goodsPriceUDict.ContainsKey(importWarp))
                        {
                            // レコードが存在しなければ、追加リストへ追加する。
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false));   // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, null, false, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, addGoodsUList) && !addFlg)
                            {
                                addCnt2++;
                                addFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                        else
                        {
                            // レコードが存在すれば、更新リストへ追加する。
                            //addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true)); // 2010/03/31 Del
                            // 2010/03/31 Add >>>
                            addUpdGoodsPriceUList.Add(ConvertToGoodsPriceUImportWork(importWork, goodsPriceUDict[importWarp], true, setUpInfoList, goodsPriceNo));
                            if (!CheckUpdAddList(importWork, updGoodsUList) && !updFlg)
                            {
                                updCnt2++;
                                updFlg = true;
                            }
                            // 2010/03/31 Add <<<
                        }
                    }
                    goodsPriceNo++; // 2010/03/31 Add
                }
                // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                #endregion

                // 読込件数
                readCnt = importGoodsWorkArray.Count;
                
                // コレクションとトランザクション
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addGoodsUList != null && addGoodsUList.Count > 0)
                    {
                        // 商品マスタの登録処理
                        status = GoodsUDB.WriteGoodsUProc(ref addGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            addCnt = addGoodsUList.Count;
                        }
                    }
                }
                // 処理区分が「更新」の場合
                else if (processKbn == 2)
                {
                    if (updGoodsUList != null && updGoodsUList.Count > 0)
                    {
                        // 商品マスタの更新処理
                        status = GoodsUDB.WriteGoodsUProc(ref updGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            updCnt = updGoodsUList.Count;
                        }
                    }
                }
                // 処理区分が「追加更新」の場合
                else
                {
                    // 登録更新リストの作成
                    addUpdGoodsUList = new ArrayList();
                    if (addGoodsUList.Count > 0)
                    {
                        addUpdGoodsUList.AddRange(addGoodsUList.GetRange(0, addGoodsUList.Count));
                    }
                    if (updGoodsUList.Count > 0)
                    {
                        addUpdGoodsUList.AddRange(updGoodsUList.GetRange(0, updGoodsUList.Count));
                    }
                    if (addUpdGoodsUList.Count > 0)
                    {
                        // 商品マスタの登録更新処理
                        status = GoodsUDB.WriteGoodsUProc(ref addUpdGoodsUList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isAddUpdFlg = true;
                            addCnt = addGoodsUList.Count;
                            updCnt = updGoodsUList.Count;
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2010/03/31 Del >>>
                    //if (isAddUpdFlg)
                    //{
                    // 2010/03/31 Del <<<
                    // 商品マスタにDB登録処理が完了すれば、価格マスタに登録する。
                        ArrayList errList = new ArrayList();
                        if (addUpdGoodsPriceUList.Count > 0)
                        {
                            status = GoodsPriceUDB.WriteGoodsPriceProc(ref addUpdGoodsPriceUList, out errList, ref sqlConnection, ref sqlTransaction);
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                            // ADD 2009/06/24 --->>>
                            if (sqlTransaction != null)
                            {
                                sqlTransaction.Dispose();
                            }
                            ArrayList delList = new ArrayList();
                            ArrayList tmpAddUpdGoodsUList = new ArrayList();
                            // 2010/03/31 Del >>>
                            //// 処理区分が「追加」の場合
                            //if (processKbn == 1)
                            //{
                            //    tmpAddUpdGoodsUList = addGoodsUList;
                            //}
                            //// 処理区分が「更新」の場合
                            //else if (processKbn == 2)
                            //{
                            //    tmpAddUpdGoodsUList = updGoodsUList;
                            //}
                            // 2010/03/31 Del <<<
                            #region DEL 2015/05/20 田建委 Redmine#45693
                            /*----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            //################################################################################################
                            //## ①既存障害１_価格削除用リストtmpAddUpdGoodsUListは、商品マスタリスト（addGoodsUList、updGoodsUList、addUpdGoodsUList）から価格マスタリストに変更
                            //## ②全ての価格の再検索を廃止して、前回検索された価格とCSVの価格を絞り込む
                            //################################################################################################
                            // 2010/03/31 Add >>>
                            if (processKbn == 1 || processKbn == 2)
                            {
                                if (addGoodsUList.Count != 0)
                                    tmpAddUpdGoodsUList.AddRange(addGoodsUList.GetRange(0, addGoodsUList.Count));
                                if (updGoodsUList.Count != 0)
                                    tmpAddUpdGoodsUList.AddRange(updGoodsUList.GetRange(0, updGoodsUList.Count));
                            }
                            // 2010/03/31 Add <<<
                            // 処理区分が「追加更新」の場合
                            else
                            {
                                tmpAddUpdGoodsUList = addUpdGoodsUList;
                            }
                            //add by liusy #35805 2013/06/14-------->>>>>>
                            //メモリリース
                            GoodsPriceUList.Clear();
                            GoodsPriceUList = null;
                            GoodsPriceUList = new ArrayList();
                            //指定された条件の商品価格マスタ情報LIST(主keyだけ)を検索
                            GoodsPriceUDB.SearchGoodsPriceBeforeDelProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                            //add by liusy #35805 2013/06/14--------<<<<<<
                            ----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<*/
                            #endregion
                            // 全て価格マスタのデータの検索処理
                            //GoodsPriceUDB.SearchGoodsPriceProc(out GoodsPriceUList, paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);  //del by liusy #35805 2013/06/14

                            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            // 価格削除用リストtmpAddUpdGoodsUListは、商品マスタリスト（addGoodsUList、updGoodsUList、addUpdGoodsUList）から価格マスタリストに変更
                            #region ◆既存障害１_価格削除用リストtmpAddUpdGoodsUListの生成
                            // まず、企業コード・メーカー・品番の昇順でソート
                            GoodsPriceCompare2 sortInfo = new GoodsPriceCompare2();
                            addUpdGoodsPriceUList.Sort(sortInfo);

                            for (int index = 0; index < addUpdGoodsPriceUList.Count; index++ )
                            {
                                GoodsPriceUWork currentGoodsPrice = null;
                                GoodsPriceUWork prevGoodsPrice = null;
                                if (index == 0)
                                {
                                    // 先頭レコードをリストへ固定に追加
                                    currentGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[0];
                                    tmpAddUpdGoodsUList.Add(currentGoodsPrice);
                                }
                                else
                                {
                                    // 先頭レコード以外のレコードは、前レコードの「企業コード・メーカー・品番」と異なる場合、リストへ追加
                                    currentGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[index];
                                    prevGoodsPrice = (GoodsPriceUWork)addUpdGoodsPriceUList[index - 1];

                                    string currentKey = string.Empty;
                                    string prevKey = string.Empty;

                                    if (currentGoodsPrice != null)
                                    {
                                        currentKey = string.Format("{0}/{1}/{2}", currentGoodsPrice.EnterpriseCode, currentGoodsPrice.GoodsMakerCd, currentGoodsPrice.GoodsNo);
                                    }
                                    if (prevGoodsPrice != null)
                                    {
                                        prevKey = string.Format("{0}/{1}/{2}", prevGoodsPrice.EnterpriseCode, prevGoodsPrice.GoodsMakerCd, prevGoodsPrice.GoodsNo);
                                    }
                                    if (currentKey != prevKey)
                                    {
                                        tmpAddUpdGoodsUList.Add(currentGoodsPrice);
                                    }
                                }
                            }
                            #endregion

                            // 追加時にレコード数が価格管理件数を超える場合は、価格開始年月日が小さいレコードを削除する前に、
                            // 無用なメモリの解放を行う
                            #region ◆速度改善_無用なメモリの解放を行う
                            if (goodsUGoodsPriceUWorkCheckList != null)
                            {
                                goodsUGoodsPriceUWorkCheckList.Clear();
                                goodsUGoodsPriceUWorkCheckList = null;
                            }
                            // 前回検索さらた商品マスタリスト
                            if (GoodsUList != null)
                            {
                                GoodsUList.Clear();
                                GoodsUList = null;
                            }
                            // 前回検索さらた商品マスタのDictionary
                            if (goodsUDict != null)
                            {
                                goodsUDict.Clear();
                                goodsUDict = null;
                            }
                            // 前回検索さらた価格マスタのDictionary
                            if (goodsPriceUDict != null)
                            {
                                goodsPriceUDict.Clear();
                                goodsPriceUDict = null;
                            }
                            // CSVからの商品マスタの追加リスト
                            if (addGoodsUList != null)
                            {
                                addGoodsUList.Clear();
                                addGoodsUList = null;
                            }
                            // CSVからの商品マスタの更新リスト
                            if (updGoodsUList != null)
                            {
                                updGoodsUList.Clear();
                                updGoodsUList = null;
                            }
                            // 価格リスト
                            if (goodsPriceUWorkList != null)
                            {
                                goodsPriceUWorkList.Clear();
                                goodsPriceUWorkList = null;
                            }
                            #endregion

                            // 価格の追加更新リスト≠NULLの場合、下記の処理へ進む
                            #region ◆速度改善_削除比較用価格Dictionaryの生成
                            // 削除比較用価格Dictionary
                            Dictionary<string, List<GoodsPriceUWork>> goodsPriceUDictForDel = new Dictionary<string, List<GoodsPriceUWork>>();
                            // 前回検索された価格情報とCSVからの価格情報を絞り込んで削除比較用価格Dictionaryへ格納する
                            if (addUpdGoodsPriceUList != null && addUpdGoodsPriceUList.Count > 0)
                            {
                                // 前回検索された価格情報を削除比較用価格Dictionaryへ格納する
                                foreach (GoodsPriceUWork firstSearchPriceWork in GoodsPriceUList)
                                { 
                                    // KEY:企業コード、商品メーカーコード、商品番号
                                    string key = string.Format("{0}/{1}/{2}", firstSearchPriceWork.EnterpriseCode, firstSearchPriceWork.GoodsMakerCd, firstSearchPriceWork.GoodsNo);
                                    if (!goodsPriceUDictForDel.ContainsKey(key))
                                    {
                                        List<GoodsPriceUWork> priceList = new List<GoodsPriceUWork>();
                                        priceList.Add(firstSearchPriceWork);
                                        goodsPriceUDictForDel.Add(key, priceList);
                                    }
                                    else
                                    {
                                        goodsPriceUDictForDel[key].Add(firstSearchPriceWork);
                                    }
                                }
                                // メモリの解放
                                // 前回検索された価格情報リスト
                                if (GoodsPriceUList != null)
                                {
                                    GoodsPriceUList.Clear();
                                    GoodsPriceUList = null;
                                }

                                // CSVからの価格情報の追加更新リストを削除比較用価格Dictionaryへ追加する
                                foreach (GoodsPriceUWork importGoodsPriceUWork in addUpdGoodsPriceUList)
                                {
                                    // KEY:企業コード、商品メーカーコード、商品番号
                                    string key = string.Format("{0}/{1}/{2}", importGoodsPriceUWork.EnterpriseCode, importGoodsPriceUWork.GoodsMakerCd, importGoodsPriceUWork.GoodsNo);
                                    if (!goodsPriceUDictForDel.ContainsKey(key))
                                    {
                                        List<GoodsPriceUWork> priceList = new List<GoodsPriceUWork>();
                                        priceList.Add(importGoodsPriceUWork);
                                        goodsPriceUDictForDel.Add(key, priceList);
                                    }
                                    else
                                    {
                                        // 前回検索された価格情報リストとCSVファイルに同一「企業コード、商品メーカーコード、商品番号、価格開始日」のデータが存在しない場合、
                                        // CSVファイルの価格情報を削除比較用価格Dictionaryへ追加する
                                        if (!goodsPriceUDictForDel[key].Exists(delegate(GoodsPriceUWork compPriceWork)
                                        {
                                            return compPriceWork.EnterpriseCode == importGoodsPriceUWork.EnterpriseCode       // 企業コード
                                                     && compPriceWork.GoodsMakerCd == importGoodsPriceUWork.GoodsMakerCd      // 商品メーカーコード
                                                     && compPriceWork.GoodsNo == importGoodsPriceUWork.GoodsNo                // 商品番号
                                                     && compPriceWork.PriceStartDate == importGoodsPriceUWork.PriceStartDate; // 価格開始日
                                        }))
                                        {
                                            goodsPriceUDictForDel[key].Add(importGoodsPriceUWork);
                                        }
                                    }
                                }
                                // メモリの解放
                                // CSVからの価格マスタの追加更新リスト
                                if (addUpdGoodsPriceUList != null)
                                {
                                    addUpdGoodsPriceUList.Clear();
                                    addUpdGoodsPriceUList = null;
                                }
                            }
                            #endregion
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<

                            //foreach (GoodsUWork importWork in tmpAddUpdGoodsUList) // DEL 2015/05/20 田建委 Redmine#45693 既存障害１
                            foreach (GoodsPriceUWork importWork in tmpAddUpdGoodsUList) // ADD 2015/05/20 田建委 Redmine#45693 既存障害１
                            {
                                List<GoodsPriceUWork> subList = new List<GoodsPriceUWork>();
                                //----- DEL 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                                //foreach (GoodsPriceUWork work in GoodsPriceUList)
                                //{
                                //    if (importWork.EnterpriseCode == work.EnterpriseCode
                                //        && importWork.GoodsMakerCd == work.GoodsMakerCd
                                //        && importWork.GoodsNo == work.GoodsNo)
                                //    {
                                //        subList.Add(work);
                                //    }
                                //}
                                //----- DEL 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                                //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                                // KEY:企業コード、商品メーカーコード、商品番号
                                string key = string.Format("{0}/{1}/{2}", importWork.EnterpriseCode, importWork.GoodsMakerCd, importWork.GoodsNo);
                                if (!goodsPriceUDictForDel.TryGetValue(key, out subList))
                                {
                                    subList = new List<GoodsPriceUWork>();
                                }
                                //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<

                                // 追加時にレコード数が価格管理件数を超える場合は、価格開始年月日が小さいレコードを削除
                                if (subList.Count > priceMngCnt)
                                {
                                    GoodsPriceCompare<GoodsPriceUWork> comp = new GoodsPriceCompare<GoodsPriceUWork>();
                                    subList.Sort(comp);
                                    delList.AddRange(subList.GetRange(0, subList.Count - priceMngCnt));
                                }
                            }
                            // メモリの解放
                            // 削除比較用価格Dictionary
                            if (goodsPriceUDictForDel != null)
                            {
                                goodsPriceUDictForDel.Clear();
                                goodsPriceUDictForDel = null;
                            }

                            // 追加時にレコード数が価格管理件数を超える場合は、価格開始年月日が小さいレコードを削除
                            if (delList.Count > 0)
                            {
                                //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                                ArrayList searchList = new ArrayList();
                                ArrayList goodsPriceUListForDel = (ArrayList)delList.Clone();
                                delList.Clear();
                                // 削除するデータリストに対して、最新の価格情報（更新日時）を検索する
                                foreach (GoodsPriceUWork delGoodsPriceUWork in goodsPriceUListForDel)
                                {
                                    status = GoodsPriceUDB.SearchGoodsPriceBeforeDelProc(out searchList, delGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        delList.AddRange(searchList);
                                    }
                                }
                                //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<

                                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                                status = GoodsPriceUDB.DeleteGoodsPriceProc(delList, ref sqlConnection, ref sqlTransaction);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // コミット
                                    sqlTransaction.Commit();
                                }
                                else
                                {
                                    // ロールバック
                                    if (sqlTransaction.Connection != null)
                                    {
                                        sqlTransaction.Rollback();
                                    }
                                }
                            }
                            // ADD 2009/06/24 ---<<<
                            // 2010/04/07 Add >>>
                            updCnt = updCnt + updCnt2;
                            addCnt = addCnt + addCnt2;
                            // 2010/04/07 Add <<<
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
                            // メモリの解放
                            if (delList != null)
                            {
                                delList.Clear();
                                delList = null;
                            }
                            if (tmpAddUpdGoodsUList != null)
                            {
                                tmpAddUpdGoodsUList.Clear();
                                tmpAddUpdGoodsUList = null;
                            }
                            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
                        }
                        else
                        {
                            // ロールバック
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                    //}   // 2010/03/31 Del
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
            catch (Exception ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, -1);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
            finally
            {
                //----- DEL 2015/08/22 田建委 Redmine#45693 --------------->>>>>
                ////----- ADD 2015/07/24 田建委 Redmine#45693 ---------->>>>>
                //// 一時テーブルを削除する
                //DropTempTbl(goodsTblName, ref sqlConnection);
                ////----- ADD 2015/07/24 田建委 Redmine#45693 ----------<<<<<
                //----- DEL 2015/08/22 田建委 Redmine#45693 ---------------<<<<<

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        //----- ADD 2015/07/24 田建委 Redmine#45693 ---------->>>>>
        /// <summary>
        /// 一時テーブルを削除する
        /// </summary>
        /// <param name="goodsTblName"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 一時テーブルをDropする</br>
        /// <br>Programmer : 2015/01/14 田建委 Redmine#44492</br>
        /// <br>             Redmine#45693 イスコ　商品マスタインポート</br>
        /// </remarks>
        private int DropTempTbl(string goodsTblName, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string sqlText = string.Empty;

            try
            {
                //一時テーブルをDrop
                using (SqlCommand sqlCommandDrop = new SqlCommand())
                {
                    sqlCommandDrop.Connection = sqlConnection;
                    sqlCommandDrop.CommandTimeout = 3600;

                    sqlText += "DROP TABLE " + goodsTblName + Environment.NewLine;

                    sqlCommandDrop.CommandText = sqlText;
                    sqlCommandDrop.ExecuteNonQuery();

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
        //----- ADD 2015/07/24 田建委 Redmine#45693 ----------<<<<<

        /// <summary>
        /// 商品マスタにDB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <param name="setUpInfoList">インポート対象設定リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        // 2010/03/31 >>>
        //private GoodsUWork ConvertToGoodsUImportWork(GoodsUWork csvWork, GoodsUWork searchWork, bool isUpdFlg, List<int[]> setUpInfoList)
        private GoodsUWork ConvertToGoodsUImportWork(GoodsUWork csvWork, GoodsUWork searchWork, bool isUpdFlg, List<int[]> setUpInfoList)
        // 2010/03/31 <<<
        {
            GoodsUWork importWork = new GoodsUWork();
            if (isUpdFlg)
            {
                // 更新の場合
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 論理削除区分
                importWork.DisplayOrder = searchWork.DisplayOrder;                  // 表示順位
                importWork.OfferDate = searchWork.OfferDate;                        // 提供日付
                importWork.UpdateDate = searchWork.UpdateDate;                      // 更新年月日
                importWork.OfferDataDiv = searchWork.OfferDataDiv;                  // 提供データ区分
                // 2010/03/31 Add >>>
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList))
                {
                    importWork.GoodsName = csvWork.GoodsName;                       // 品名
                }
                else
                {
                    importWork.GoodsName = searchWork.GoodsName;                    // 品名
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList))
                {
                    importWork.GoodsNameKana = csvWork.GoodsNameKana;               // 品名カナ
                }
                else
                {
                    importWork.GoodsNameKana = searchWork.GoodsNameKana;            // 品名カナ
                }
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList))
                {
                    importWork.Jan = csvWork.Jan;                                   // JANコード
                }
                else
                {
                    importWork.Jan = searchWork.Jan;                                // JANコード
                }
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList))
                {
                    importWork.BLGoodsCode = csvWork.BLGoodsCode;                   // BLコード
                }
                else
                {
                    importWork.BLGoodsCode = searchWork.BLGoodsCode;                // BLコード
                }
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList))
                {
                    importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;   // 商品区分
                }
                else
                {
                    importWork.EnterpriseGanreCode = searchWork.EnterpriseGanreCode;// 商品区分
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList))
                {
                    importWork.GoodsRateRank = csvWork.GoodsRateRank;               // 層別
                }
                else
                {
                    importWork.GoodsRateRank = searchWork.GoodsRateRank;            // 層別
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList))
                {
                    importWork.GoodsKindCode = csvWork.GoodsKindCode;               // 純優区分
                }
                else
                {
                    importWork.GoodsKindCode = searchWork.GoodsKindCode;            // 純優区分
                }
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList))
                {
                    importWork.TaxationDivCd = csvWork.TaxationDivCd;               // 課税区分
                }
                else
                {
                    importWork.TaxationDivCd = searchWork.TaxationDivCd;            // 課税区分
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNote1, setUpInfoList))
                {
                    importWork.GoodsNote1 = csvWork.GoodsNote1;                     // 商品備考１
                }
                else
                {
                    importWork.GoodsNote1 = searchWork.GoodsNote1;                  // 商品備考１
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsNote2, setUpInfoList))
                {
                    importWork.GoodsNote2 = csvWork.GoodsNote2;                     // 商品備考２
                }
                else
                {
                    importWork.GoodsNote2 = searchWork.GoodsNote2;                  // 商品備考２
                }
                if (CheckUpdateDiv((int)ItemCode.GoodsSpecialNote, setUpInfoList))
                {
                    importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;         // 商品規格・特記事項
                }
                else
                {
                    importWork.GoodsSpecialNote = searchWork.GoodsSpecialNote;      // 商品規格・特記事項
                }
                // 2010/03/31 Add <<<
            }
            else
            {
                // 新規の場合
                importWork.DisplayOrder = 0;                                        // 表示順位
                // 2010/03/31 >>>
                //importWork.OfferDate = DateTime.Now;                                // 提供日付
                importWork.OfferDate = DateTime.MinValue;                                // 提供日付
                // 2010/03/31 <<<
                importWork.UpdateDate = DateTime.Now;                               // 更新年月日
                importWork.OfferDataDiv = 0;                                        // 提供データ区分
                // 2010/03/31 Add >>>
                importWork.GoodsName = csvWork.GoodsName;                               // 品名
                importWork.GoodsNameKana = csvWork.GoodsNameKana;                       // 品名カナ
                importWork.Jan = csvWork.Jan;                                           // JANコード
                importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BLコード
                importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;           // 商品区分
                importWork.GoodsRateRank = csvWork.GoodsRateRank;                       // 層別
                importWork.GoodsKindCode = csvWork.GoodsKindCode;                       // 純優区分
                importWork.TaxationDivCd = csvWork.TaxationDivCd;                       // 課税区分
                importWork.GoodsNote1 = csvWork.GoodsNote1;                             // 商品備考１
                importWork.GoodsNote2 = csvWork.GoodsNote2;                             // 商品備考２
                importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;                 // 商品規格・特記事項
                // 2010/03/31 Add <<<
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
            importWork.GoodsNo = csvWork.GoodsNo;                                   // 品番
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // メーカー
            // 2010/03/31 Del >>>
            //importWork.GoodsName = csvWork.GoodsName;                               // 品名
            //importWork.GoodsNameKana = csvWork.GoodsNameKana;                       // 品名カナ
            //importWork.Jan = csvWork.Jan;                                           // JANコード
            //importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BLコード
            //importWork.EnterpriseGanreCode = csvWork.EnterpriseGanreCode;           // 商品区分
            //importWork.GoodsRateRank = csvWork.GoodsRateRank;                       // 層別
            //importWork.GoodsKindCode = csvWork.GoodsKindCode;                       // 純優区分
            //importWork.TaxationDivCd = csvWork.TaxationDivCd;                       // 課税区分
            // 2010/03/31 Del <<<
            importWork.GoodsNoNoneHyphen = csvWork.GoodsNo.Replace("-", "");        // ハイフン無商品番号
            // 2010/03/31 Del >>>
            //importWork.GoodsNote1 = csvWork.GoodsNote1;                             // 商品備考１
            //importWork.GoodsNote2 = csvWork.GoodsNote2;                             // 商品備考２
            //importWork.GoodsSpecialNote = csvWork.GoodsSpecialNote;                 // 商品規格・特記事項
            // 2010/03/31 Del <<<

            return importWork;
        }

        /// <summary>
        /// 価格マスタにDB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <param name="setUpinfoList">インポート対象設定リスト</param>
        /// <param name="goodsPriceNo">価格マスタNo</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        // 2010/03/31 >>>
        //private GoodsPriceUWork ConvertToGoodsPriceUImportWork(GoodsPriceUWork csvWork, GoodsPriceUWork searchWork, bool isUpdFlg)
        private GoodsPriceUWork ConvertToGoodsPriceUImportWork(GoodsPriceUWork csvWork, GoodsPriceUWork searchWork, bool isUpdFlg, List<int[]> setUpinfoList, int goodsPriceNo)
        // 2010/03/31 <<<
        {
            GoodsPriceUWork importWork = new GoodsPriceUWork();
            if (isUpdFlg)
            {
                // 更新の場合
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.OfferDate = searchWork.OfferDate;                        // 提供日付
                importWork.UpdateDate = searchWork.UpdateDate;                      // 更新年月日
                // 2010/03/31 Add >>>
                if (CheckUpdateDiv((int)ItemCode.ListPrice1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.ListPrice = csvWork.ListPrice;                       // 価格
                }
                else
                {
                    importWork.ListPrice = searchWork.ListPrice;                    // 価格
                }
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                 // オープン価格区分
                }
                else
                {
                    importWork.OpenPriceDiv = searchWork.OpenPriceDiv;              // オープン価格区分
                }
                if (CheckUpdateDiv((int)ItemCode.StockRate1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.StockRate = csvWork.StockRate;                       // 仕入率
                }
                else
                {
                    importWork.StockRate = searchWork.StockRate;                    // 仕入率
                }
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1 + goodsPriceNo * 5, setUpinfoList))
                {
                    importWork.SalesUnitCost = csvWork.SalesUnitCost;               // 原単価
                }
                else
                {
                    importWork.SalesUnitCost = searchWork.SalesUnitCost;            // 原単価
                }
                // 2010/03/31 Add <<<
            }
            else
            {
                // 新規の場合
                // 2010/03/31 >>>
                //importWork.OfferDate = DateTime.Now;                                // 提供日付
                importWork.OfferDate = DateTime.MinValue;                                             // 提供日付
                // 2010/03/31 <<<
                importWork.UpdateDate = DateTime.Now;                               // 更新年月日
                // 2010/03/31 Add >>>
                importWork.ListPrice = csvWork.ListPrice;                               // 価格
                importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                         // オープン価格区分
                importWork.StockRate = csvWork.StockRate;                               // 仕入率
                importWork.SalesUnitCost = csvWork.SalesUnitCost;                       // 原単価
                // 2010/03/31 Add <<<
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
            importWork.GoodsNo = csvWork.GoodsNo;                                   // 品番
            importWork.GoodsMakerCd = csvWork.GoodsMakerCd;                         // メーカー
            importWork.PriceStartDate = csvWork.PriceStartDate;                     // 価格開始年月日
            //importWork.ListPrice = csvWork.ListPrice;                               // 価格
            //importWork.OpenPriceDiv = csvWork.OpenPriceDiv;                         // オープン価格区分
            //importWork.StockRate = csvWork.StockRate;                               // 仕入率
            //importWork.SalesUnitCost = csvWork.SalesUnitCost;                       // 原単価

            return importWork;
        }

        // ADD 2009/06/24 --->>>
        private bool IsAddCompareAfter(ArrayList list, GoodsPriceUWork csvWork, Int32 listCnt)
        {
            bool isAdd = false;

            foreach (GoodsPriceUWork work in list)
            {
                if (csvWork.PriceStartDate.CompareTo(work.PriceStartDate) > 0)
                {
                    isAdd = true;
                    break;
                }
            }

            return isAdd;
        }
        // ADD 2009/06/24 ---<<<

        // 2010/03/31 Add >>>
        /// <summary>
        /// SetUpInfoListからItemIdの更新区分がするになっているかチェックします
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="setUpInfoList">SetUpInfoList</param>
        /// <returns>true:する　false:しない</returns>
        private bool CheckUpdateDiv(int itemId, List<int[]> setUpInfoList)
        {
            // 設定リストのカウントが0の場合はXMLファイルが存在していない為全項目更新対象とする
            if (setUpInfoList.Count == 0)
            {
                return true;
            }
            int[] find = new int[2] { itemId, 0 };
            foreach (int[] setUpInfo in setUpInfoList)
            {
                if (find[0] == setUpInfo[0])
                {
                    if (setUpInfo[1] == 0)
                        return true;
                    break;
                }
            }
            return false;
        }

        /// <summary>
        /// 商品マスタの追加リスト該当のデータが存在するかチェックを行います。
        /// </summary>
        /// <param name="importWork">GoodsUWork</param>
        /// <param name="addGoodsUList">ArrayList</param>
        /// <returns>true:存在する　false:存在しない</returns>
        private bool CheckUpdAddList(GoodsPriceUWork importWork, ArrayList addGoodsUList)
        {
            foreach (GoodsUWork goodsImportWork in addGoodsUList)
            {
                if (goodsImportWork.GoodsMakerCd == importWork.GoodsMakerCd &&
                    goodsImportWork.GoodsNo == importWork.GoodsNo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 列挙体・インポート対象設定の項目リスト
        /// </summary>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        private enum ItemCode
        {
            GoodsNo = 1,            // 品番
            GoodsMakerCd,           // メーカー
            GoodsName,              // 品名
            GoodsNameKana,          // 品名カナ
            Jan,                    // JANコード
            BLGoodsCode,            // BLコード
            EnterpriseGanreCode,    // 商品区分
            GoodsRateRank,          // 層別
            GoodsKindCode,          // 純優区分
            TaxationDivCd,          // 課税区分
            GoodsNote1,             // 商品備考１
            GoodsNote2,             // 商品備考２
            GoodsSpecialNote,       // 商品規格・特記事項
            PriceStartDate1,        // 価格開始年月日１
            ListPrice1,             // 価格１
            OpenPriceDiv1,          // オープン価格区分１
            StockRate1,             // 仕入率１
            SalesUnitCost1,         // 原単価１
            //PriceStartDate2,        // 価格開始年月日２
            //ListPrice2,             // 価格２
            //OpenPriceDiv2,          // オープン価格区分２
            //StockRate2,             // 仕入率２
            //SalesUnitCost2,         // 原単価２
            //PriceStartDate3,        // 価格開始年月日３
            //ListPrice3,             // 価格３
            //OpenPriceDiv3,          // オープン価格区分３
            //StockRate3,             // 仕入率３
            //SalesUnitCost3,         // 原単価３
            //PriceStartDate4,        // 価格開始年月日４
            //ListPrice4,             // 価格４
            //OpenPriceDiv4,          // オープン価格区分４
            //StockRate4,             // 仕入率４
            //SalesUnitCost4,         // 原単価４
            //PriceStartDate5,        // 価格開始年月日５
            //ListPrice5,             // 価格５
            //OpenPriceDiv5,          // オープン価格区分５
            //StockRate5,             // 仕入率５
            //SalesUnitCost5          // 原単価５
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            PriceStartDate2,        // 価格開始年月日２
            ListPrice2,             // 価格２
            OpenPriceDiv2,          // オープン価格区分２
            StockRate2,             // 仕入率２
            SalesUnitCost2,         // 原単価２
            PriceStartDate3,        // 価格開始年月日３
            ListPrice3,             // 価格３
            OpenPriceDiv3,          // オープン価格区分３
            StockRate3,             // 仕入率３
            SalesUnitCost3,         // 原単価３
            PriceStartDate4,        // 価格開始年月日４
            ListPrice4,             // 価格４
            OpenPriceDiv4,          // オープン価格区分４
            StockRate4,             // 仕入率４
            SalesUnitCost4,         // 原単価４
            PriceStartDate5,        // 価格開始年月日５
            ListPrice5,             // 価格５
            OpenPriceDiv5,          // オープン価格区分５
            StockRate5,             // 仕入率５
            SalesUnitCost5          // 原単価５
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
}
        // 2010/03/31 Add <<<
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
        /* ------------DEL wangf 2012/07/03 FOR Redmine#30387--------->>>>
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region エラーデータテーブル関する
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  商品番号
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  商品メーカーコード
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  商品名称
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  商品名称カナ
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JANコード

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL商品コード
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // 自社分類コード
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  商品掛率ランク
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(string));            //  商品属性
            dataTable.Columns.Add("TaxationDivCdRF", typeof(string));            //  課税区分
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  商品備考１
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  商品備考２
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  商品規格・特記事項

            dataTable.Columns.Add("PriceStartDateRF1", typeof(string));           //  価格開始日１
            dataTable.Columns.Add("ListPriceRF1", typeof(string));                //  定価（浮動）１
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(string));             //  オープン価格区分１
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  仕入率１
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  原価単価１

            dataTable.Columns.Add("PriceStartDateRF2", typeof(string));           //  価格開始日２
            dataTable.Columns.Add("ListPriceRF2", typeof(string));                //  定価（浮動）２
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(string));             //  オープン価格区分２
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  仕入率２
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  原価単価２

            dataTable.Columns.Add("PriceStartDateRF3", typeof(string));           //  価格開始日３
            dataTable.Columns.Add("ListPriceRF3", typeof(string));                //  定価（浮動）３
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(string));             //  オープン価格区分３
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  仕入率３
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  原価単価３

            dataTable.Columns.Add("PriceStartDateRF4", typeof(string));           //  価格開始日４
            dataTable.Columns.Add("ListPriceRF4", typeof(string));                //  定価（浮動）４
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(string));             //  オープン価格区分４
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  仕入率４
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  原価単価４

            dataTable.Columns.Add("PriceStartDateRF5", typeof(string));           //  価格開始日５
            dataTable.Columns.Add("ListPriceRF5", typeof(string));                //  定価（浮動）５
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(string));             //  オープン価格区分５
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  仕入率５
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  原価単価５

            dataTable.Columns.Add("ErrorMessage", typeof(string));            //  エラー内容
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="goodsUWork">検索条件</param>
        /// <param name="msg">DATE</param>
        /// <param name="dataTable">結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsUGoodsPriceUWork goodsUWork, string msg, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["GoodsNoRF"] = goodsUWork.GoodsNo;
            dataRow["GoodsMakerCdRF"] = goodsUWork.GoodsMakerCd;
            dataRow["GoodsNameRF"] = goodsUWork.GoodsName;
            dataRow["GoodsNameKanaRF"] = goodsUWork.GoodsNameKana;
            dataRow["JanRF"] = goodsUWork.Jan;
            dataRow["BLGoodsCodeRF"] = goodsUWork.BLGoodsCode;
            dataRow["EnterpriseGanreCodeRF"] = goodsUWork.EnterpriseGanreCode;
            dataRow["GoodsRateRankRF"] = goodsUWork.GoodsRateRank;
            dataRow["GoodsKindCodeRF"] = goodsUWork.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUWork.TaxationDivCd;
            dataRow["GoodsNote1RF"] = goodsUWork.GoodsNote1;
            dataRow["GoodsNote2RF"] = goodsUWork.GoodsNote2;
            dataRow["GoodsSpecialNoteRF"] = goodsUWork.GoodsSpecialNote;
            Type type = goodsUWork.GetType();
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                dataRow["PriceStartDateRF" + index] = type.GetProperty("PriceStartDate" + index).GetValue(goodsUWork, null);
                dataRow["ListPriceRF" + index] = type.GetProperty("ListPrice" + index).GetValue(goodsUWork, null);
                dataRow["OpenPriceDivRF" + index] = type.GetProperty("OpenPriceDiv" + index).GetValue(goodsUWork, null);
                dataRow["StockRateRF" + index] = type.GetProperty("StockRate" + index).GetValue(goodsUWork, null);
                dataRow["SalesUnitCostRF" + index] = type.GetProperty("SalesUnitCost" + index).GetValue(goodsUWork, null);
            }
            dataRow["ErrorMessage"] = msg;
            dataTable.Rows.Add(dataRow);
        }
        #endregion
        // ------------DEL wangf 2012/07/03 FOR Redmine#30387---------<<<<*/

        # region チェック
        # region メッセージ
        private const string FORMAT_ERRMSG_LEN = "{0}の桁数{1}桁以内で入力してください。";
        private const string FORMAT_ERRMSG_TYPE = "{0}は{1}入力のみ可能です。";
        private const string FORMAT_ERRMSG_MUSTINPUT = "{0}を入力してください。";
        private const string FORMAT_ERRMSG_ERRORVAL = "{0}が不正です。";
        //private const string ERRMSG_DUPLICATE = "重複データしているため登録できません。"; // ADD wangf 2012/07/20 FOR Redmine#30387 // DEL wangf 2012/07/25 FOR Redmine#30387
        private const string ERRMSG_DUPLICATE = "重複データがあるため登録できません。"; // ADD wangf 2012/07/25 FOR Redmine#30387
        # endregion
        # region 処理
        /// <summary>
        /// CSVファイルチェック
        /// </summary>
        /// <param name="goodsUGoodsPriceUWork">商品・価格オブジェクト</param>
        /// <param name="importSetUpList">インポート対象設定リスト</param>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="goodsUGoodsPriceUWorkCheckList">フィルター用商品マスタリスト</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>TRUE:エラーない、FALSE:エラーあり</returns>
        /// <remarks>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note : 2012/07/10 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 障害一覧の指摘NO.55の対応</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        /// </remarks>
        //private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, out string msg) // DEL wangf 2012/07/03 FOR Redmine#30387
        //private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, Int32 processKbn, out string msg) // ADD wangf 2012/07/03 FOR Redmine#30387 // DEL wangf 2012/07/20 FOR Redmine#30387
        private bool CheckError(GoodsUGoodsPriceUWork goodsUGoodsPriceUWork, object importSetUpList, Int32 processKbn, Int32 dataCheckKbn, List<GoodsUGoodsPriceUWork> goodsUGoodsPriceUWorkCheckList, List<GoodsPriceUWork> goodsPriceUWorkList, out string msg) // ADD wangf 2012/07/03 FOR Redmine#30387 // ADD wangf 2012/07/20 FOR Redmine#30387
        {
            msg = string.Empty;
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
            // エラーチェックあり
            if (0 == dataCheckKbn)
            {
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                // インポート対象設定リスト
                //List<int[]> setUpInfoList = (List<int[]>)importSetUpList; // DEL wangf 2012/07/20 FOR Redmine#30387
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                List<int[]> setUpInfoList = new List<int[]>();
                for (int i = 0; i < ((List<int[]>)importSetUpList).Count; i++)
                {
                    int[] arr = new int[((List<int[]>)importSetUpList)[i].Length];
                    Array.Copy(((List<int[]>)importSetUpList)[i], arr, ((List<int[]>)importSetUpList)[i].Length);
                    setUpInfoList.Add(arr);
                }
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387--------->>>>
                // 処理区分：追加、すべて項目チェック対象
                if (processKbn == 0)
                {
                    for (int i = 0; i < setUpInfoList.Count; i++)
                    {
                        setUpInfoList[i][1] = 0;
                    }
                }
                // ------------ADD wangf 2012/07/03 FOR Redmine#30387---------<<<<

                #region 商品情報
                // 品番：必須入力チェック
                if (!Check_IsNull("品番", goodsUGoodsPriceUWork.GoodsNo, out msg))
                {
                    return false;
                }
                // 品番：入力可タイプ
                if (!Check_HalfEngNumFixedLength("品番", goodsUGoodsPriceUWork.GoodsNo, out msg))
                {
                    return false;
                }
                // 品番：桁
                if (!Check_StrUnFixedLen("品番", goodsUGoodsPriceUWork.GoodsNo, 24, out msg))
                {
                    return false;
                }

                // メーカー：必須入力チェック
                if (!Check_DataEmpty("メーカー", goodsUGoodsPriceUWork.GoodsMakerCd, out msg))
                {
                    return false;
                }
                // メーカー：入力可タイプ
                if (!Check_NumOnly("メーカー", goodsUGoodsPriceUWork.GoodsMakerCd, out msg))
                {
                    return false;
                }
                // メーカー：桁
                if (!Check_StrUnFixedLen("メーカー", goodsUGoodsPriceUWork.GoodsMakerCd, 4, out msg))
                {
                    return false;
                }

                // 品名：必須入力チェック
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList) && !Check_IsNull("品名", goodsUGoodsPriceUWork.GoodsName, out msg))
                {
                    return false;
                }
                // 品名：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsName, setUpInfoList) && !Check_StrUnFixedLen("品名", goodsUGoodsPriceUWork.GoodsName, 40, out msg))
                {
                    return false;
                }

                // 品名カナ：必須入力チェック
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList) && !Check_IsNull("品名カナ", goodsUGoodsPriceUWork.GoodsNameKana, out msg))
                {
                    return false;
                }
                // 品名カナ：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsNameKana, setUpInfoList) && !Check_StrUnFixedLen("品名カナ", goodsUGoodsPriceUWork.GoodsNameKana, 40, out msg))
                {
                    return false;
                }

                // ＪＡＮコード：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList) && !Check_NumOnly("ＪＡＮコード", goodsUGoodsPriceUWork.Jan, out msg))
                {
                    return false;
                }
                // ＪＡＮコード：桁
                if (CheckUpdateDiv((int)ItemCode.Jan, setUpInfoList) && !Check_StrUnFixedLen("ＪＡＮコード", goodsUGoodsPriceUWork.Jan, 13, out msg))
                {
                    return false;
                }

                /* ------------DEL wangf 2012/07/10 FOR Redmine#30387--------->>>>
                // ＢＬコード：必須入力チェック
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_DataEmpty("ＢＬコード", goodsUGoodsPriceUWork.BLGoodsCode, out msg))
                {
                    return false;
                }
                // ------------DEL wangf 2012/07/10 FOR Redmine#30387---------<<<<*/
                // ＢＬコード：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_NumOnly("ＢＬコード", goodsUGoodsPriceUWork.BLGoodsCode, out msg))
                {
                    return false;
                }
                // ＢＬコード：桁
                if (CheckUpdateDiv((int)ItemCode.BLGoodsCode, setUpInfoList) && !Check_StrUnFixedLen("ＢＬコード", goodsUGoodsPriceUWork.BLGoodsCode, 5, out msg))
                {
                    return false;
                }

                // 商品区分：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList) && !Check_NumOnly("商品区分", goodsUGoodsPriceUWork.EnterpriseGanreCode, out msg))
                {
                    return false;
                }
                // 商品区分：桁
                if (CheckUpdateDiv((int)ItemCode.EnterpriseGanreCode, setUpInfoList) && !Check_StrUnFixedLen("商品区分", goodsUGoodsPriceUWork.EnterpriseGanreCode, 4, out msg))
                {
                    return false;
                }

                // 層別：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList) && !Check_HalfEngNumFixedLength("層別", goodsUGoodsPriceUWork.GoodsRateRank, out msg))
                {
                    return false;
                }
                // 層別：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsRateRank, setUpInfoList) && !Check_StrUnFixedLen("層別", goodsUGoodsPriceUWork.GoodsRateRank, 2, out msg))
                {
                    return false;
                }

                // 純優区分：必須入力チェック
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_IsNull("純優区分", goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // 純優区分：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_NumOnly("純優区分", goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // 純優区分：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_StrUnFixedLen("純優区分", goodsUGoodsPriceUWork.GoodsKindCode, 1, out msg))
                {
                    return false;
                }
                // 純優区分：メーカーと関連チェック
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && !Check_MakerCdAndGoodsKindCode("純優区分", goodsUGoodsPriceUWork.GoodsMakerCd, goodsUGoodsPriceUWork.GoodsKindCode, out msg))
                {
                    return false;
                }
                // ------ ADD START 2012/07/12 Redmine#30387 李亜博 for 障害一覧の指摘NO.93の対応-------->>>>
                // 純優区分：「0」と「1」
                if (CheckUpdateDiv((int)ItemCode.GoodsKindCode, setUpInfoList) && Convert.ToInt32(goodsUGoodsPriceUWork.GoodsKindCode.Trim()) != 0 && Convert.ToInt32(goodsUGoodsPriceUWork.GoodsKindCode.Trim()) != 1)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "純優区分");
                    return false;
                }
                // ------ ADD END 2012/07/12 Redmine#30387 李亜博 for 障害一覧の指摘NO.93の対応--------<<<<

                // 課税区分：必須入力チェック
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_IsNull("課税区分", goodsUGoodsPriceUWork.TaxationDivCd, out msg))
                {
                    return false;
                }
                // 課税区分：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_NumOnly("課税区分", goodsUGoodsPriceUWork.TaxationDivCd, out msg))
                {
                    return false;
                }
                // 課税区分：桁
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && !Check_StrUnFixedLen("課税区分", goodsUGoodsPriceUWork.TaxationDivCd, 1, out msg))
                {
                    return false;
                }
                // ------ ADD START 2012/07/12 Redmine#30387 李亜博 for 障害一覧の指摘NO.93の対応-------->>>>
                // 課税区分：「0」と「1」
                if (CheckUpdateDiv((int)ItemCode.TaxationDivCd, setUpInfoList) && Convert.ToInt32(goodsUGoodsPriceUWork.TaxationDivCd.Trim()) != 0 && Convert.ToInt32(goodsUGoodsPriceUWork.TaxationDivCd.Trim()) != 1)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, "課税区分");
                    return false;
                }
                // ------ ADD END 2012/07/12 Redmine#30387 李亜博 for 障害一覧の指摘NO.93の対応--------<<<<
                // 商品備考１：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsNote1, setUpInfoList) && !Check_StrUnFixedLen("商品備考１", goodsUGoodsPriceUWork.GoodsNote1, 40, out msg))
                {
                    return false;
                }

                // 商品備考２：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsNote2, setUpInfoList) && !Check_StrUnFixedLen("商品備考２", goodsUGoodsPriceUWork.GoodsNote2, 40, out msg))
                {
                    return false;
                }

                // 規格・特記事項：桁
                if (CheckUpdateDiv((int)ItemCode.GoodsSpecialNote, setUpInfoList) && !Check_StrUnFixedLen("規格・特記事項", goodsUGoodsPriceUWork.GoodsSpecialNote, 40, out msg))
                {
                    return false;
                }
                #endregion

                #region 価格情報１
                // 価格開始年月日１：価格１を入力される時、価格開始年月日が必須入力です。
                if (!Check_PriceStartDateAndListPrice("価格開始年月日１", goodsUGoodsPriceUWork.ListPrice1, goodsUGoodsPriceUWork.PriceStartDate1, out msg))
                {
                    return false;
                }
                // 価格開始年月日１：入力可タイプ
                //if (!Check_NumOnly("価格開始年月日１", goodsUGoodsPriceUWork.PriceStartDate1, out msg))// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                if (!Check_NumberOnly("価格開始年月日１", goodsUGoodsPriceUWork.PriceStartDate1, out msg))// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                {
                    return false;
                }
                // 価格開始年月日１：桁
                if (!Check_StrUnFixedLen("価格開始年月日１", goodsUGoodsPriceUWork.PriceStartDate1, 8, out msg))
                {
                    return false;
                }
                // 価格開始年月日１：編集方法チェック
                if (!Check_YYYYMMDD("価格開始年月日１", goodsUGoodsPriceUWork.PriceStartDate1, out msg))
                {
                    return false;
                }

                // 価格１：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.ListPrice1, setUpInfoList) && !Check_NumOnly("価格１", goodsUGoodsPriceUWork.ListPrice1, out msg))
                {
                    return false;
                }
                // 価格１：桁
                if (CheckUpdateDiv((int)ItemCode.ListPrice1, setUpInfoList) && !Check_StrUnFixedLen("価格１", goodsUGoodsPriceUWork.ListPrice1, 7, out msg))
                {
                    return false;
                }

                // オープン価格区分１：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1, setUpInfoList) && !Check_NumOnly("オープン価格区分１", goodsUGoodsPriceUWork.OpenPriceDiv1, out msg))
                {
                    return false;
                }
                // オープン価格区分１：桁
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv1, setUpInfoList) && !Check_StrUnFixedLen("オープン価格区分１", goodsUGoodsPriceUWork.OpenPriceDiv1, 1, out msg))
                {
                    return false;
                }

                // 仕入率１：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_NumDouble("仕入率１", goodsUGoodsPriceUWork.StockRate1, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }
                // 仕入率１：桁
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_StrUnFixedLen("仕入率１", goodsUGoodsPriceUWork.StockRate1, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }
                // 仕入率１：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.StockRate1, setUpInfoList) && !Check_FloatAndLen("仕入率１", goodsUGoodsPriceUWork.StockRate1, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate1))
                {
                    return false;
                }

                // 原単価１：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_NumDouble("原単価１", goodsUGoodsPriceUWork.SalesUnitCost1, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                // 原単価１：桁
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_StrUnFixedLen("原単価１", goodsUGoodsPriceUWork.SalesUnitCost1, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                // 原単価１：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost1, setUpInfoList) && !Check_FloatAndLen("原単価１", goodsUGoodsPriceUWork.SalesUnitCost1, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost1))
                {
                    return false;
                }
                #endregion

                #region 価格情報２
                // 価格開始年月日２：価格２を入力される時、価格開始年月日が必須入力です。
                if (!Check_PriceStartDateAndListPrice("価格開始年月日２", goodsUGoodsPriceUWork.ListPrice2, goodsUGoodsPriceUWork.PriceStartDate2, out msg))
                {
                    return false;
                }
                // 価格開始年月日２：入力可タイプ
                //if (!Check_NumOnly("価格開始年月日２", goodsUGoodsPriceUWork.PriceStartDate2, out msg))// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                if (!Check_NumberOnly("価格開始年月日２", goodsUGoodsPriceUWork.PriceStartDate2, out msg))// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                {
                    return false;
                }
                // 価格開始年月日２：桁
                if (!Check_StrUnFixedLen("価格開始年月日２", goodsUGoodsPriceUWork.PriceStartDate2, 8, out msg))
                {
                    return false;
                }
                // 価格開始年月日２：編集方法チェック
                if (!Check_YYYYMMDD("価格開始年月日２", goodsUGoodsPriceUWork.PriceStartDate2, out msg))
                {
                    return false;
                }

                // 価格２：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.ListPrice2, setUpInfoList) && !Check_NumOnly("価格２", goodsUGoodsPriceUWork.ListPrice2, out msg))
                {
                    return false;
                }
                // 価格２：桁
                if (CheckUpdateDiv((int)ItemCode.ListPrice2, setUpInfoList) && !Check_StrUnFixedLen("価格２", goodsUGoodsPriceUWork.ListPrice2, 7, out msg))
                {
                    return false;
                }

                // オープン価格区分２：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv2, setUpInfoList) && !Check_NumOnly("オープン価格区分２", goodsUGoodsPriceUWork.OpenPriceDiv2, out msg))
                {
                    return false;
                }
                // オープン価格区分２：桁
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv2, setUpInfoList) && !Check_StrUnFixedLen("オープン価格区分２", goodsUGoodsPriceUWork.OpenPriceDiv2, 1, out msg))
                {
                    return false;
                }

                // 仕入率２：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_NumDouble("仕入率２", goodsUGoodsPriceUWork.StockRate2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }
                // 仕入率２：桁
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_StrUnFixedLen("仕入率２", goodsUGoodsPriceUWork.StockRate2, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }
                // 仕入率２：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.StockRate2, setUpInfoList) && !Check_FloatAndLen("仕入率２", goodsUGoodsPriceUWork.StockRate2, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate2))
                {
                    return false;
                }

                // 原単価２：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_NumDouble("原単価２", goodsUGoodsPriceUWork.SalesUnitCost2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                // 原単価２：桁
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_StrUnFixedLen("原単価２", goodsUGoodsPriceUWork.SalesUnitCost2, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                // 原単価２：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost2, setUpInfoList) && !Check_FloatAndLen("原単価２", goodsUGoodsPriceUWork.SalesUnitCost2, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost2))
                {
                    return false;
                }
                #endregion

                #region 価格情報３
                // 価格開始年月日３：価格３を入力される時、価格開始年月日が必須入力です。
                if (!Check_PriceStartDateAndListPrice("価格開始年月日３", goodsUGoodsPriceUWork.ListPrice3, goodsUGoodsPriceUWork.PriceStartDate3, out msg))
                {
                    return false;
                }
                // 価格開始年月日３：入力可タイプ
                //if (!Check_NumOnly("価格開始年月日３", goodsUGoodsPriceUWork.PriceStartDate3, out msg))// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                if (!Check_NumberOnly("価格開始年月日３", goodsUGoodsPriceUWork.PriceStartDate3, out msg))// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                {
                    return false;
                }
                // 価格開始年月日３：桁
                if (!Check_StrUnFixedLen("価格開始年月日３", goodsUGoodsPriceUWork.PriceStartDate3, 8, out msg))
                {
                    return false;
                }
                // 価格開始年月日３：編集方法チェック
                if (!Check_YYYYMMDD("価格開始年月日３", goodsUGoodsPriceUWork.PriceStartDate3, out msg))
                {
                    return false;
                }

                // 価格３：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.ListPrice3, setUpInfoList) && !Check_NumOnly("価格３", goodsUGoodsPriceUWork.ListPrice3, out msg))
                {
                    return false;
                }
                // 価格３：桁
                if (CheckUpdateDiv((int)ItemCode.ListPrice3, setUpInfoList) && !Check_StrUnFixedLen("価格３", goodsUGoodsPriceUWork.ListPrice3, 7, out msg))
                {
                    return false;
                }

                // オープン価格区分３：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv3, setUpInfoList) && !Check_NumOnly("オープン価格区分３", goodsUGoodsPriceUWork.OpenPriceDiv3, out msg))
                {
                    return false;
                }
                // オープン価格区分３：桁
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv3, setUpInfoList) && !Check_StrUnFixedLen("オープン価格区分３", goodsUGoodsPriceUWork.OpenPriceDiv3, 1, out msg))
                {
                    return false;
                }

                // 仕入率３：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_NumDouble("仕入率３", goodsUGoodsPriceUWork.StockRate3, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }
                // 仕入率３：桁
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_StrUnFixedLen("仕入率３", goodsUGoodsPriceUWork.StockRate3, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }
                // 仕入率３：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.StockRate3, setUpInfoList) && !Check_FloatAndLen("仕入率３", goodsUGoodsPriceUWork.StockRate3, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate3))
                {
                    return false;
                }

                // 原単価３：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_NumDouble("原単価３", goodsUGoodsPriceUWork.SalesUnitCost3, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                // 原単価３：桁
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_StrUnFixedLen("原単価３", goodsUGoodsPriceUWork.SalesUnitCost3, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                // 原単価３：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost3, setUpInfoList) && !Check_FloatAndLen("原単価３", goodsUGoodsPriceUWork.SalesUnitCost3, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost3))
                {
                    return false;
                }
                #endregion

                #region 価格情報４
                // 価格開始年月日４：価格４を入力される時、価格開始年月日が必須入力です。
                if (!Check_PriceStartDateAndListPrice("価格開始年月日４", goodsUGoodsPriceUWork.ListPrice4, goodsUGoodsPriceUWork.PriceStartDate4, out msg))
                {
                    return false;
                }
                // 価格開始年月日４：入力可タイプ
                //if (!Check_NumOnly("価格開始年月日４", goodsUGoodsPriceUWork.PriceStartDate4, out msg))// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                if (!Check_NumberOnly("価格開始年月日４", goodsUGoodsPriceUWork.PriceStartDate4, out msg))// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                {
                    return false;
                }
                // 価格開始年月日４：桁
                if (!Check_StrUnFixedLen("価格開始年月日４", goodsUGoodsPriceUWork.PriceStartDate4, 8, out msg))
                {
                    return false;
                }
                // 価格開始年月日４：編集方法チェック
                if (!Check_YYYYMMDD("価格開始年月日４", goodsUGoodsPriceUWork.PriceStartDate4, out msg))
                {
                    return false;
                }

                // 価格４：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.ListPrice4, setUpInfoList) && !Check_NumOnly("価格４", goodsUGoodsPriceUWork.ListPrice4, out msg))
                {
                    return false;
                }
                // 価格４：桁
                if (CheckUpdateDiv((int)ItemCode.ListPrice4, setUpInfoList) && !Check_StrUnFixedLen("価格４", goodsUGoodsPriceUWork.ListPrice4, 7, out msg))
                {
                    return false;
                }

                // オープン価格区分４：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv4, setUpInfoList) && !Check_NumOnly("オープン価格区分４", goodsUGoodsPriceUWork.OpenPriceDiv4, out msg))
                {
                    return false;
                }
                // オープン価格区分４：桁
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv4, setUpInfoList) && !Check_StrUnFixedLen("オープン価格区分４", goodsUGoodsPriceUWork.OpenPriceDiv4, 1, out msg))
                {
                    return false;
                }

                // 仕入率４：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_NumDouble("仕入率４", goodsUGoodsPriceUWork.StockRate4, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }
                // 仕入率４：桁
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_StrUnFixedLen("仕入率４", goodsUGoodsPriceUWork.StockRate4, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }
                // 仕入率４：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.StockRate4, setUpInfoList) && !Check_FloatAndLen("仕入率４", goodsUGoodsPriceUWork.StockRate4, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate4))
                {
                    return false;
                }

                // 原単価４：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_NumDouble("原単価４", goodsUGoodsPriceUWork.SalesUnitCost4, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                // 原単価４：桁
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_StrUnFixedLen("原単価４", goodsUGoodsPriceUWork.SalesUnitCost4, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                // 原単価４：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost4, setUpInfoList) && !Check_FloatAndLen("原単価４", goodsUGoodsPriceUWork.SalesUnitCost4, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost4))
                {
                    return false;
                }
                #endregion

                #region 価格情報５
                // 価格開始年月日５：価格５を入力される時、価格開始年月日が必須入力です。
                if (!Check_PriceStartDateAndListPrice("価格開始年月日５", goodsUGoodsPriceUWork.ListPrice5, goodsUGoodsPriceUWork.PriceStartDate5, out msg))
                {
                    return false;
                }
                // 価格開始年月日５：入力可タイプ
                //if (!Check_NumOnly("価格開始年月日５", goodsUGoodsPriceUWork.PriceStartDate5, out msg))// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                if (!Check_NumberOnly("価格開始年月日５", goodsUGoodsPriceUWork.PriceStartDate5, out msg))// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                {
                    return false;
                }
                // 価格開始年月日５：桁
                if (!Check_StrUnFixedLen("価格開始年月日５", goodsUGoodsPriceUWork.PriceStartDate5, 8, out msg))
                {
                    return false;
                }
                // 価格開始年月日５：編集方法チェック
                if (!Check_YYYYMMDD("価格開始年月日５", goodsUGoodsPriceUWork.PriceStartDate5, out msg))
                {
                    return false;
                }

                // 価格５：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.ListPrice5, setUpInfoList) && !Check_NumOnly("価格５", goodsUGoodsPriceUWork.ListPrice5, out msg))
                {
                    return false;
                }
                // 価格５：桁
                if (CheckUpdateDiv((int)ItemCode.ListPrice5, setUpInfoList) && !Check_StrUnFixedLen("価格５", goodsUGoodsPriceUWork.ListPrice5, 7, out msg))
                {
                    return false;
                }

                // オープン価格区分５：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv5, setUpInfoList) && !Check_NumOnly("オープン価格区分５", goodsUGoodsPriceUWork.OpenPriceDiv5, out msg))
                {
                    return false;
                }
                // オープン価格区分５：桁
                if (CheckUpdateDiv((int)ItemCode.OpenPriceDiv5, setUpInfoList) && !Check_StrUnFixedLen("オープン価格区分５", goodsUGoodsPriceUWork.OpenPriceDiv5, 1, out msg))
                {
                    return false;
                }

                // 仕入率５：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_NumDouble("仕入率５", goodsUGoodsPriceUWork.StockRate5, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }
                // 仕入率５：桁
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_StrUnFixedLen("仕入率５", goodsUGoodsPriceUWork.StockRate5, 6, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }
                // 仕入率５：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.StockRate5, setUpInfoList) && !Check_FloatAndLen("仕入率５", goodsUGoodsPriceUWork.StockRate5, 3, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.StockRate5))
                {
                    return false;
                }

                // 原単価５：入力可タイプ
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_NumDouble("原単価５", goodsUGoodsPriceUWork.SalesUnitCost5, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                // 原単価５：桁
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_StrUnFixedLen("原単価５", goodsUGoodsPriceUWork.SalesUnitCost5, 10, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                // 原単価５：編集方法チェック
                if (CheckUpdateDiv((int)ItemCode.SalesUnitCost5, setUpInfoList) && !Check_FloatAndLen("原単価５", goodsUGoodsPriceUWork.SalesUnitCost5, 7, 2, out msg) && !string.IsNullOrEmpty(goodsUGoodsPriceUWork.SalesUnitCost5))
                {
                    return false;
                }
                #endregion
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
            }
            // 商品マスタ重複チェック
            int countGoodU = goodsUGoodsPriceUWorkCheckList.FindAll(
                delegate(GoodsUGoodsPriceUWork p)
                {
                    return (p.EnterpriseCode == goodsUGoodsPriceUWork.EnterpriseCode
                           && p.GoodsNo == goodsUGoodsPriceUWork.GoodsNo
                           && p.GoodsMakerCd == goodsUGoodsPriceUWork.GoodsMakerCd
                          );
                }).Count;
            if (countGoodU > 1)
            {
                msg = ERRMSG_DUPLICATE;
                return false;
            }
            // 価格マスタリスト重複チェック
            foreach (GoodsPriceUWork goodsPriceUWorkLocal in goodsPriceUWorkList)
            {
                int countGoodsPriceU = goodsPriceUWorkList.FindAll(
                    delegate(GoodsPriceUWork x)
                    {
                        return (x.PriceStartDate != DateTime.MinValue
                                && x.EnterpriseCode == goodsPriceUWorkLocal.EnterpriseCode
                                && x.GoodsNo == goodsPriceUWorkLocal.GoodsNo
                                && x.GoodsMakerCd == goodsPriceUWorkLocal.GoodsMakerCd
                                && x.PriceStartDate == goodsPriceUWorkLocal.PriceStartDate
                               );
                    }).Count;
                if (countGoodsPriceU > 1)
                {
                    msg = ERRMSG_DUPLICATE;
                    return false;
                }
            }
            // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

            return true;
        }

        /// <summary>
        /// メーカーと純優区分関連チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsKindCode">優良区分</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : メーカーと関連チェックを行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_MakerCdAndGoodsKindCode(string fieldNm, string goodsMakerCd, string goodsKindCode, out string msg)
        {
            msg = string.Empty;
            try
            {
                // 正しい場合：純品部品のメーカーコード＜1000、優良部品のメーカーコード＞＝1000
                if ((Convert.ToInt32(goodsMakerCd) < 1000 && Convert.ToInt32(goodsKindCode) == 1)
                    || Convert.ToInt32(goodsMakerCd) >= 1000 && Convert.ToInt32(goodsKindCode) == 0)
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                    return false;
                }
                return true;
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }
        }

        /// <summary>
        /// 価格開始年月日と価格関連チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="listPrice">価格</param>
        /// <param name="priceStartDate">価格開始年月日が</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : メーカーと関連チェックを行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_PriceStartDateAndListPrice(string fieldNm, string listPrice, string priceStartDate, out string msg)
        {
            msg = string.Empty;
            try
            {
                // 正しい場合：価格などを入力される時、価格開始年月日が必須入力です。
                if (!Check_DataEmpty(listPrice) && (Check_DataEmpty(priceStartDate)))
                {
                    msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }
        }

        /// <summary>
        /// "0"とstring.Emptyをチェックする
        /// </summary>
        /// <param name="dateData">値</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : "0"とstring.Emptyをチェックする。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_DataEmpty(string dateData)
        {
            if ("0".Equals(dateData.Trim()) || string.IsNullOrEmpty(dateData.Trim()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// NULLの判断（0含む）
        /// </summary>
        /// <param name="fileldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULLの判断（0含む）を行う。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_DataEmpty(string fileldNm, string val, out string msg)
        {
            msg = string.Empty;
            if ("0".Equals(val.Trim()) || string.IsNullOrEmpty(val.Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fileldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 数字のみチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 数字のみチェック。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/26 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.94の対応 エラーメッセージの変更の対応</br>
        /// </remarks>
        private bool Check_NumOnly(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^(0|[[0-9]+)$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数字");// DEL  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "整数");// ADD  2012/07/26  李亜博 Redmine#30387 for 障害一覧の指摘NO.94の対応
                return false;
            }
            return true;
        }

        // ------ ADD START 2012/07/26 Redmine#30387 李亜博 for 障害一覧の指摘NO.94の対応-------->>>>
        /// <summary>
        /// 数字のみチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 数字のみチェック。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private bool Check_NumberOnly(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^(0|[[0-9]+)$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "日付");
                return false;
            }
            return true;
        }
        // ------ ADD END 2012/07/26 Redmine#30387 李亜博 for 障害一覧の指摘NO.94の対応--------<<<<
        /// <summary>
        /// 数字のみチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 数字のみチェック。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_NumDouble(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = "^\\d+(\\.\\d+)?$";
            if (!Check_DataEmpty(val) && !Regex.IsMatch(val, regexStr))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "数字");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 浮動値、長さをチェックする
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="valLen">項目長さ</param>
        /// <param name="dotLen">点箇所</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 浮動値、長さをチェックする。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_FloatAndLen(string fieldNm, string val, int valLen, int dotLen, out string msg)
        {
            msg = string.Empty;
            if (!Check_DataEmpty(val) && Regex.IsMatch(val, @"^([0-9]{1,}([.][0-9]{0,})?)$"))
            {
                string regexStrLen = @"^([0-9]{1," + valLen.ToString() + "}([.][0-9]{1," + dotLen.ToString() + "})?)$";
                if (!Regex.IsMatch(val, regexStrLen))
                {
                    msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// NULLの判断
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : NULLの判断。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_IsNull(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrEmpty(val.ToString().Trim()))
            {
                msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 長さを指定しないの文字列チェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="len">長さ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 長さを指定しないの文字列チェック。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/06/26 wangf </br>
        /// <br>           : 10801804-00、内部発見バッグの対応：桁数チェック時、全角符号を一桁に計算するように変更</br>
        /// </remarks>
        private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)
        {
            msg = string.Empty;
            //if (CountWordLen(val) > len) // DEL wangf 2012/06/26 FOR 内部発見バッグの対応
            if (val.Trim().Length > len) // ADD wangf 2012/06/26 FOR 内部発見バッグの対応
            {
                msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm, len);
                return false;
            }
            return true;
        }

        /* ------------DEL wangf 2012/06/26 FOR 内部発見バッグの対応 --------->>>>
        /// <summary>
        /// 半角、全角の長さ計算
        /// </summary>
        /// <param name="val">値</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 半角、全角の長さ計算</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public int CountWordLen(string val)
        {
            int wordLen = 0;
            char[] charArr = val.ToCharArray();
            foreach (char charItem in charArr)
            {
                string str = charItem.ToString();
                wordLen += Encoding.Default.GetBytes(str).Length;
            }
            return wordLen;
        }
        // ------------DEL wangf 2012/06/26 FOR 内部発見バッグの対応 ---------<<<<*/

        /// <summary>
        /// 半角英数字、符号のチェック
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 半角英数字、符号のチェック。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            string regexStr = @"^[a-zA-Z0-9 \-_.+=#$*&@%\\[~!_():;'?,/""<>\[\]^`{|}]{1,}$";
            if (!Regex.IsMatch(val, regexStr) && !string.IsNullOrEmpty(val))
            {
                msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm, "半角英数字、符号");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 日期チェック(20120201)
        /// </summary>
        /// <param name="fieldNm">項目名</param>
        /// <param name="val">値</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       :  日期チェック(20120201)。</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private bool Check_YYYYMMDD(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;
            try
            {
                if (!Check_DataEmpty(val))
                {
                    if (Convert.ToInt32(val) != 0)
                    {
                        DateTime dt = DateTime.ParseExact(val, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    }
                }
            }
            catch
            {
                msg = string.Format(FORMAT_ERRMSG_ERRORVAL, fieldNm);
                return false;
            }

            return true;
        }
        # endregion
        # endregion
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
    }

    #region 商品情報オブジェクト
    /// <summary>
    /// 商品情報オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品情報オブジェクトです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsUImportWorkWrap
    {
        #region Public Field
        public GoodsUWork goodsWork;
        #endregion

        #region クラスコンストラクタ
        /// <summary>
        /// 商品情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品情報オブジェクトを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsUImportWorkWrap(GoodsUWork goodsWork)
        {
            this.goodsWork = goodsWork;
        }
        #endregion

        #region 商品情報オブジェクトのイコールの比較
        /// <summary>
        /// 商品情報オブジェクトのイコールの比較
        /// </summary>
        /// <param name="obj">商品情報オブジェクト</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : 商品情報オブジェクトのイコールかどうかを比較する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            GoodsUImportWorkWrap target = obj as GoodsUImportWorkWrap;
            if (target == null) return false;
            // 企業コード、商品メーカーコード、商品番号
            // が同じ場合、商品情報オブジェクトはイコールにする。
            return target.goodsWork.EnterpriseCode == goodsWork.EnterpriseCode
                     && target.goodsWork.GoodsMakerCd == goodsWork.GoodsMakerCd
                     && target.goodsWork.GoodsNo == goodsWork.GoodsNo;
        }
        #endregion

        #region 商品情報オブジェクトのハシコード
        /// <summary>
        /// 商品情報オブジェクトのハシコード
        /// </summary>
        /// <returns>ハシコード</returns>
        /// <remarks>
        /// <br>Note       : 商品情報オブジェクトのハシコードを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return goodsWork.EnterpriseCode.GetHashCode()
                     + goodsWork.GoodsMakerCd.GetHashCode()
                     + goodsWork.GoodsNo.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region 価格情報オブジェクト
    /// <summary>
    /// 価格情報オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格情報オブジェクトです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsPriceUImportWorkWrap
    {
        #region Public Field
        public GoodsPriceUWork goodsPriceWork;
        #endregion

        #region クラスコンストラクタ
        /// <summary>
        /// 価格情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : 価格情報オブジェクトを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public GoodsPriceUImportWorkWrap(GoodsPriceUWork goodsPriceWork)
        {
            this.goodsPriceWork = goodsPriceWork;
        }
        #endregion

        #region 価格情報オブジェクトのイコールの比較
        /// <summary>
        /// 価格情報オブジェクトのイコールの比較
        /// </summary>
        /// <param name="obj">価格情報オブジェクト</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : 価格情報オブジェクトのイコールかどうかを比較する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            GoodsPriceUImportWorkWrap target = obj as GoodsPriceUImportWorkWrap;
            if (target == null) return false;
            // 企業コード、商品メーカーコード、商品番号、価格開始日
            // が同じ場合、価格情報オブジェクトはイコールにする。
            return target.goodsPriceWork.EnterpriseCode == goodsPriceWork.EnterpriseCode
                     && target.goodsPriceWork.GoodsMakerCd == goodsPriceWork.GoodsMakerCd
                     && target.goodsPriceWork.GoodsNo == goodsPriceWork.GoodsNo
                     && target.goodsPriceWork.PriceStartDate == goodsPriceWork.PriceStartDate;
        }
        #endregion

        #region 価格情報オブジェクトのハシコード
        /// <summary>
        /// 価格情報オブジェクトのハシコード
        /// </summary>
        /// <returns>ハシコード</returns>
        /// <remarks>
        /// <br>Note       : 価格情報オブジェクトのハシコードを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return goodsPriceWork.EnterpriseCode.GetHashCode()
                     + goodsPriceWork.GoodsMakerCd.GetHashCode()
                     + goodsPriceWork.GoodsNo.GetHashCode()
                     + goodsPriceWork.PriceStartDate.GetHashCode();
        }
        #endregion
    }
    #endregion

    #region 価格情報比較オブジェクト
    /// <summary>
    /// 価格情報比較オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格情報比較オブジェクトです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.06.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class GoodsPriceCompare<T> : IComparer<T>
    {
        int IComparer<T>.Compare(T t1, T t2)
        {
            GoodsPriceUWork o1 = t1 as GoodsPriceUWork;
            GoodsPriceUWork o2 = t2 as GoodsPriceUWork;
            int ret = -1;
            if (o1.EnterpriseCode == o2.EnterpriseCode && o1.GoodsMakerCd == o2.GoodsMakerCd && o1.GoodsNo == o2.GoodsNo)
            {
                ret = o1.PriceStartDate.CompareTo(o2.PriceStartDate);
            }
            return ret;
        }
    }

    //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
    /// <summary>
    /// 価格情報比較オブジェクト(企業コード・メーカーコード・品番)
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格情報比較オブジェクトです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2009.06.24</br>
    /// </remarks>
    class GoodsPriceCompare2 : IComparer
    {
        int IComparer.Compare(object t1, object t2)
        {
            GoodsPriceUWork o1 = t1 as GoodsPriceUWork;
            GoodsPriceUWork o2 = t2 as GoodsPriceUWork;
            int ret = -1;
            ret = o1.EnterpriseCode.CompareTo(o2.EnterpriseCode);
            if (ret == 0)
            {
                ret = o1.GoodsMakerCd.CompareTo(o2.GoodsMakerCd);
            }
            if (ret == 0)
            {
                ret = o1.GoodsNo.CompareTo(o2.GoodsNo);
            }

            return ret;
        }
    }
    //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
    #endregion
}
