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
using Broadleaf.Application.Common;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品価格マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品価格マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 18322  木村 武正</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS対応</br>
    /// <br>Programmer : 21024　佐々木　健</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 22008 長内 PM.NS対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 仕入伝票入力で価格更新時の不具合修正</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2010/11/11</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 商品マスタインポート OutOfMemory Exception(イスコ GCサーバモード)</br>
    /// <br>Programmer : 10801804-00 #35805 liusy</br>
    /// <br>Date       : 2013/06/14</br> 
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/05/20 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 イスコ　商品マスタインポート OutOfMemory解除対応</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2015/07/24 田建委</br>
    /// <br>管理番号   : 11175183-00</br>
    /// <br>           : Redmine#45693 イスコ　商品マスタインポート 一時テーブルをJOINして検索する変更</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2020/06/18 陳艶丹</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>           : PMKOBETSU-4076 タイムアウト設定</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class GoodsPriceUDB : RemoteDB, IGoodsPriceUDB, IGetSyncdataList
    {
        #region 定数
        /// <summary>論理削除区分</summary>
        private enum ct_LogicalDeleteCode
        {
            Valid = 0,
            LogicalDelete = 1,
            Pending = 2,
            Delete = 3
        }
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        #endregion

        /// <summary>
        /// 商品価格マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        public GoodsPriceUDB()
            :
            base("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork", "GOODSPRICEURF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品価格マスタ情報LISTを戻します
        /// </summary>
        /// <param name="GoodsPriceUWork">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタ情報LISTを戻します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int Search(out object GoodsPriceUWork, object paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            GoodsPriceUWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsPriceProc(out GoodsPriceUWork, paraGoodsPriceUWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Search");
                GoodsPriceUWork = new ArrayList();
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
        /// 指定された条件の商品価格マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objGoodsPriceUWork">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int SearchGoodsPriceProc(out object objGoodsPriceUWork, object paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsPriceUWork GoodsPriceUWork = null; 

            ArrayList GoodsPriceUWorkList = paraGoodsPriceUWork as ArrayList;
            if (GoodsPriceUWorkList == null)
            {
                GoodsPriceUWork = paraGoodsPriceUWork as GoodsPriceUWork;
            }
            else
            {
                if (GoodsPriceUWorkList.Count > 0)
                    GoodsPriceUWork = GoodsPriceUWorkList[0] as GoodsPriceUWork;
            }

            int status = SearchGoodsPriceProc(out GoodsPriceUWorkList, GoodsPriceUWork, readMode, logicalMode, ref sqlConnection);
            objGoodsPriceUWork = GoodsPriceUWorkList;
            return status;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// 指定された条件の商品価格マスタ情報LIST(主keyだけ 削除前の利用)を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2013/06/14</br>
        public int SearchGoodsPriceBeforeDelProc(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sql = "";
            try
            {

                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryBeforeDelString(ref sqlCommand, paraGoodsPriceUWork, logicalMode);

                sql = sqlCommand.CommandText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToGoodsPriceUWorkBeforeDelFromReader(ref myReader));
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

            }

            GoodsPriceUWorkList = al;
            return status;
        }
        //add by liusy #35805 2013/06/14----------<<<<<

        //----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
        /// <summary>
        /// 価格データの検索[商品マスタインポート専用]
        /// </summary>
        /// <param name="GoodsPriceUWorkList"></param>
        /// <param name="paraGoodsPriceUWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 価格データの検索[商品マスタインポート専用]</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2015/05/20</br>
        /// <br>Update Note: 2015/07/24 田建委</br>
        /// <br>管理番号   : 11175183-00</br>
        /// <br>           : Redmine#45693 イスコ　商品マスタインポート 一時テーブルをJOINして検索する変更</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //public int SearchGoodsPriceForGoodsImport(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // DEL 2015/07/24 田建委 Redmine#45693
        public int SearchGoodsPriceForGoodsImport(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, string tempTalName, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection) // ADD 2015/07/24 田建委 Redmine#45693
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                //sqlCommand.CommandText += CreateQueryString(ref sqlCommand, paraGoodsPriceUWork, logicalMode); // DEL 2015/07/24 田建委 Redmine#45693
                sqlCommand.CommandText += CreateQueryStringForGoodsImport(ref sqlCommand, paraGoodsPriceUWork, tempTalName, logicalMode); // ADD 2015/07/24 田建委 Redmine#45693
                sqlCommand.CommandTimeout = 3600; // ADD 2015/07/24 田建委 Redmine#45693

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }

            GoodsPriceUWorkList = al;
            return status;
        }

        //----- ADD 2015/07/24 田建委 Redmine#45693 ------->>>>>
        /// <summary>
        /// 価格データの検索[商品マスタインポート専用]
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="GoodsPriceUWork"></param>
        /// <param name="tempTalName"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 一時テーブルをJOINして検索する変更</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2015/07/24</br>
        /// </remarks>
        private string CreateQueryStringForGoodsImport(ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, string tempTalName, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.Append("SELECT" + Environment.NewLine);
            sqlText.Append(" *" + Environment.NewLine);
            sqlText.Append("FROM" + Environment.NewLine);
            sqlText.Append("  GOODSPRICEURF PRICE WITH(READUNCOMMITTED) " + Environment.NewLine);
            sqlText.Append("INNER JOIN " + tempTalName + " TEMTBL WITH(READUNCOMMITTED) " + Environment.NewLine);
            sqlText.Append("ON PRICE.ENTERPRISECODERF = TEMTBL.ENTERPRISECODERF " + Environment.NewLine);
            sqlText.Append("AND PRICE.GOODSMAKERCDRF = TEMTBL.GOODSMAKERCDRF " + Environment.NewLine);
            sqlText.Append("AND PRICE.GOODSNORF = TEMTBL.GOODSNORF " + Environment.NewLine);
            sqlText.Append("WHERE" + Environment.NewLine);
            sqlText.Append("  PRICE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);

            // 企業コード
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // メーカーコード
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText.Append("  AND PRICE.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            //論理削除区分
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText.Append("  AND PRICE.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText.Append(" AND PRICE.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine);
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText.ToString();
        }
        //----- ADD 2015/07/24 田建委 Redmine#45693 -------<<<<<
        //----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<

        /// <summary>
        /// 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        /// <summary>
        /// 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">検索結果</param>
        /// <param name="paraGoodsPriceUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        public int SearchGoodsPriceProc(out ArrayList GoodsPriceUWorkList, GoodsPriceUWork paraGoodsPriceUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList al = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryString(ref sqlCommand, paraGoodsPriceUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }

            GoodsPriceUWorkList = al;
            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品価格マスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタを戻します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

                // XMLの読み込み
                GoodsPriceUWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
                if (GoodsPriceUWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref GoodsPriceUWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(GoodsPriceUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Read");
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
        /// 指定された条件の商品価格マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int ReadProc( ref GoodsPriceUWork GoodsPriceUWork, int readMode, ref SqlConnection sqlConnection )
        {
            return this.ReadProcProc(ref GoodsPriceUWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の商品価格マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int ReadProcProc( ref GoodsPriceUWork GoodsPriceUWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = "";
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                        //GoodsPriceUWork = CopyToGoodsPriceUWorkFromReader(ref myReader);
                        GoodsPriceUWork = CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease);
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 商品価格マスタ情報を登録、更新します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <param name="writeError">更新エラー</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します</br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        public int Write(ref object GoodsPriceUWork, out object writeError)
        {
            writeError = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(GoodsPriceUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                ArrayList writeErrorList;
                status = WriteGoodsPriceProc(ref paraList, out writeErrorList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                GoodsPriceUWork = paraList;
                writeError = (object)writeErrorList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPriceUDB.Write(ref object GoodsPriceUWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        }

        /// <summary>
        /// 商品価格マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="writeErrorList">更新エラーリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 19026  湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4076 タイムアウト対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int WriteGoodsPriceProc(ref ArrayList GoodsPriceUWorkList, out ArrayList writeErrorList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            writeErrorList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (GoodsPriceUWorkList == null || GoodsPriceUWorkList.Count == 0)
                return status;

            ArrayList al = new ArrayList();
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<


            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();

            try
            {
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

                for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                {
                    GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;
                    int writeStatus;
                    string errorMessage;
                    if (GoodsPriceUWork.LogicalDeleteCode == (int)ct_LogicalDeleteCode.Delete)
                    {
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                        //writeStatus = DeleteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        writeStatus = DeleteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, dbCommandTimeout);
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
                    }
                    else
                    {
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                        //writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction);
                        //writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease);
                        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                        writeStatus = WriteGoodsPrice(ref GoodsPriceUWork, out errorMessage, ref sqlConnection, ref sqlTransaction, convertDoubleRelease, dbCommandTimeout);
                        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
                    }

                    if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        al.Add(GoodsPriceUWork);

                        //WARNING,ERRORじゃなかったらNORMAL
                        if (status != (int)ConstantManagement.DB_Status.ctDB_WARNING &&
                            status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        writeErrorList.Add(SetError(GoodsPriceUWork, writeStatus, errorMessage));
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    }
                }

            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // 解放
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            
            GoodsPriceUWorkList = al;
            return status;
        }

        /// <summary>
        /// 商品価格マスタ INSERT or UPDATE 処理
        /// </summary>
        /// <param name="GoodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4076 タイムアウト設定</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
        //private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        private int WriteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ConvertDoubleRelease convertDoubleRelease, int dbCommandTimeout)
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            try
            {
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                sqlCommand.CommandTimeout = dbCommandTimeout; // ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (GoodsPriceUWork.UpdateDateTime == DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            errorMessage = "重複するデータがあるため更新できません。";
                        }
                        //既存データで更新日時違いの場合には排他
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            errorMessage = "このデータは既に更新されています。";
                        }

                        sqlCommand.Cancel();
                        return status;
                    }

                    //更新用のSQL文を生成
                    sqlText = "";
                    sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                    sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                    sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                    sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                    sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                    sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                    sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (GoodsPriceUWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        errorMessage = "このデータは既に削除されています。";
                        sqlCommand.Cancel();
                        return status;
                    }

                    //新規作成時のSQL文を生成
                    sqlText = "";
                    sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += "  ,GOODSNORF" + Environment.NewLine;
                    sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                    sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                    sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                    sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                    sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                    sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  ,@GOODSNO" + Environment.NewLine;
                    sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                    sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                    sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                    sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                    sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                    sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                    sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //以下の処理で論理削除区分が０に書き換えられてしまう為、退避しておく
                    //商品在庫マスタからの論理削除時に使用する
                    int logicalDeleteCode = GoodsPriceUWork.LogicalDeleteCode;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                    GoodsPriceUWork.LogicalDeleteCode = logicalDeleteCode;
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
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(GoodsPriceUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.ListPrice);
                convertDoubleRelease.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = GoodsPriceUWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = GoodsPriceUWork.ListPrice;

                // 変換処理実行
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.SalesUnitCost);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.StockRate);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.OpenPriceDiv);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.OfferDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
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

        /// <summary>
        /// 商品価格マスタ 価格更新処理
        /// </summary>
        /// <param name="goodsPriceList">商品価格マスタ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        public int UpDatePrice(ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpDatePriceProc(ref goodsPriceList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品価格マスタ 価格更新処理
        /// </summary>
        /// <param name="goodsPriceList">商品価格マスタ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int UpDatePriceProc(ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlText = "";
            
            ArrayList al = new ArrayList();

            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

            try 
            {
                
                if (goodsPriceList != null)
                {
                    for (int i = 0; i < goodsPriceList.Count; i++)
                    {
                        GoodsPriceUWork goodsPriceUWork = goodsPriceList[i] as GoodsPriceUWork;

                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //更新用のSQL文を生成
                            sqlText = "";
                            sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                            sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                            sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                            sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                            sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsPriceUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            goodsPriceUWork.UpdateDate = goodsPriceUWork.UpdateDateTime.Date;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.GoodsNo);
                            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                            if (myReader.IsClosed == false) myReader.Close();

                            //Parameterオブジェクトの作成(更新用)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                            SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                            SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定(更新用)
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsPriceUWork.UpdateDateTime);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.UpdAssemblyId2);

                            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                            //paraListPrice.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.ListPrice);
                            convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                            convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                            convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                            convertDoubleRelease.ConvertSetParam = goodsPriceUWork.ListPrice;

                            // 変換処理実行
                            convertDoubleRelease.ConvertProc();

                            paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

                            paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.SalesUnitCost);
                            paraStockRate.Value = SqlDataMediator.SqlSetDouble(goodsPriceUWork.StockRate);
                            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);

                            sqlCommand.ExecuteNonQuery();
                            al.Add(goodsPriceUWork);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            if (myReader.IsClosed == false) myReader.Close();

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;  // ADD 2010/11/11 
                        }
                    }
                }

            }
            catch(SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex,"",ex.Number);
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
            
            goodsPriceList = al;
            return status;
                        
        }

        /// <summary>
        /// 商品価格マスタ DELETE 処理
        /// </summary>
        /// <param name="GoodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="sqlTransaction">SQLトランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4076 タイムアウト設定</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/08/28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        //private int DeleteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteGoodsPrice(ref GoodsPriceUWork GoodsPriceUWork, out string errorMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int dbCommandTimeout)
        // --- UPD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        {
            errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;

            try
            {
                #region [更新処理]
                //Selectコマンドの生成
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                sqlCommand.CommandTimeout = dbCommandTimeout; // ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                    {
                        //既存データで更新日時違いの場合には排他
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        errorMessage = "このデータは既に更新されています。";

                        sqlCommand.Cancel();
                        return status;
                    }

                    sqlText = "";
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    errorMessage = "このデータは既に削除されています。";
                    sqlCommand.Cancel();
                    return status;
                }
                if (myReader.IsClosed == false) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
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

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        /// <summary>
        /// 登録エラーオブジェクトの生成
        /// </summary>
        /// <param name="GoodsPriceUWork">商品価格マスタ</param>
        /// <param name="errorCode">エラーコード</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>商品価格登録エラー</returns>
        private GoodsPriceUWriteErrorWork SetError(GoodsPriceUWork GoodsPriceUWork, int errorCode, string errorMessage)
        {

            GoodsPriceUWriteErrorWork goodsPriceWriteErrorWork = new GoodsPriceUWriteErrorWork();

            goodsPriceWriteErrorWork.CreateDateTime = GoodsPriceUWork.CreateDateTime;
            goodsPriceWriteErrorWork.UpdateDateTime = GoodsPriceUWork.UpdateDateTime;
            goodsPriceWriteErrorWork.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
            goodsPriceWriteErrorWork.FileHeaderGuid = GoodsPriceUWork.FileHeaderGuid;
            goodsPriceWriteErrorWork.UpdEmployeeCode = GoodsPriceUWork.UpdEmployeeCode;
            goodsPriceWriteErrorWork.UpdAssemblyId1 = GoodsPriceUWork.UpdAssemblyId1;
            goodsPriceWriteErrorWork.UpdAssemblyId2 = GoodsPriceUWork.UpdAssemblyId2;
            goodsPriceWriteErrorWork.LogicalDeleteCode = GoodsPriceUWork.LogicalDeleteCode;
            goodsPriceWriteErrorWork.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
            goodsPriceWriteErrorWork.GoodsNo = GoodsPriceUWork.GoodsNo;
            goodsPriceWriteErrorWork.PriceStartDate = GoodsPriceUWork.PriceStartDate;
            goodsPriceWriteErrorWork.ListPrice = GoodsPriceUWork.ListPrice;
            goodsPriceWriteErrorWork.SalesUnitCost = GoodsPriceUWork.SalesUnitCost;
            goodsPriceWriteErrorWork.StockRate = GoodsPriceUWork.StockRate;
            goodsPriceWriteErrorWork.OpenPriceDiv = GoodsPriceUWork.OpenPriceDiv;
            goodsPriceWriteErrorWork.OfferDate = GoodsPriceUWork.OfferDate;
            goodsPriceWriteErrorWork.UpdateDate = GoodsPriceUWork.UpdateDate;
            goodsPriceWriteErrorWork.ErrorCode = errorCode;
            goodsPriceWriteErrorWork.ErrorMessage = errorMessage;
            return goodsPriceWriteErrorWork;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 商品価格マスタ情報を論理削除します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報を論理削除します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int LogicalDelete(ref object GoodsPriceUWork)
        {
            return LogicalDeleteGoodsPrice(ref GoodsPriceUWork, 0);
        }

        /// <summary>
        /// 論理削除商品価格マスタ情報を復活します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品価格マスタ情報を復活します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int RevivalLogicalDelete(ref object GoodsPriceUWork)
        {
            return LogicalDeleteGoodsPrice(ref GoodsPriceUWork, 1);
        }

        /// <summary>
        /// 商品価格マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        private int LogicalDeleteGoodsPrice(ref object GoodsPriceUWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(GoodsPriceUWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteGoodsPriceProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "GoodsPriceUDB.LogicalDeleteGoodsPrice :" + procModestr);

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
        }

        /// <summary>
        /// 商品価格マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int LogicalDeleteGoodsPriceProc( ref ArrayList GoodsPriceUWorkList
                                              , int procMode
                                              , ref SqlConnection sqlConnection
                                              , ref SqlTransaction sqlTransaction )
        {
            return this.LogicalDeleteGoodsPriceProcProc(ref GoodsPriceUWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品価格マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">GoodsPriceUWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品価格マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int LogicalDeleteGoodsPriceProcProc( ref ArrayList GoodsPriceUWorkList
                                              , int procMode
                                              , ref SqlConnection sqlConnection
                                              , ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = "";

            try
            {
                if (GoodsPriceUWorkList != null)
                {
                    for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                    {
                        GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;

                        sqlText = "";
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlText = "";
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,UPDATEDATERF = @UPDATEDATE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                            sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;
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
                            else if (logicalDelCd == 0) GoodsPriceUWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else GoodsPriceUWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) GoodsPriceUWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;      //既に復活している場合はそのまま正常を戻す
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
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.LogicalDeleteCode);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(GoodsPriceUWork);
                    }

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
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            GoodsPriceUWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 商品価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">商品価格マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品価格マスタ情報を物理削除します</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteGoodsPriceProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsPriceUDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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
        }


        /// <summary>
        /// 商品価格マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">商品価格マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品価格マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int DeleteGoodsPriceProc( ArrayList GoodsPriceUWorkList
                                       ,ref SqlConnection  sqlConnection
                                       ,ref SqlTransaction sqlTransaction)
        {
            return this.DeleteGoodsPriceProcProc(GoodsPriceUWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品価格マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">商品価格マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品価格マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int DeleteGoodsPriceProcProc( ArrayList GoodsPriceUWorkList
                                       , ref SqlConnection sqlConnection
                                       , ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";
            try
            {

                for (int i = 0; i < GoodsPriceUWorkList.Count; i++)
                {
                    GoodsPriceUWork GoodsPriceUWork = GoodsPriceUWorkList[i] as GoodsPriceUWork;

                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
                    }
                    else
                    {
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

        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        public int GetSyncdataList( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品価格情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private int GetSyncdataListProc( out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += " *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  GOODSPRICEURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader));
                    al.Add(CopyToGoodsPriceUWorkFromReader(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                    
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
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [クエリ文字列生成]
        /// <summary>
        /// Search検索文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="GoodsPriceUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>クエリ文字列</returns>
        /// <br>Note       : 商品価格マスタの検索用クエリ文字列を生成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2015/05/20 田建委</br>
        /// <br>管理番号   : 11175183-00</br>
        /// <br>           : Redmine#45693 イスコ　商品マスタインポート OutOfMemory解除対応</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private string CreateQueryString( ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, ConstantManagement.LogicalMode logicalMode )
        {
            string sqlText = String.Empty;

            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " *" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // 企業コード
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // メーカーコード
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            // 品番
            if (IsValidParameter(GoodsPriceUWork.GoodsNo))
            {
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
            }

            //----- DEL 2015/07/24 田建委 Redmine#45693 ----------------->>>>>
            ////----- ADD 2015/05/20 田建委 Redmine#45693 ---------->>>>>
            //// 商品マスタインポート用品番開始
            //if (IsValidParameter(GoodsPriceUWork.GoodsNoSt))
            //{
            //    sqlText += "  AND GOODSNORF >= @FINDGOODSNOST" + Environment.NewLine;
            //    SqlParameter findParaGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NVarChar);
            //    findParaGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNoSt);
            //}

            //// 商品マスタインポート用品番終了
            //if (IsValidParameter(GoodsPriceUWork.GoodsNoEd))
            //{
            //    sqlText += "  AND GOODSNORF <= @FINDGOODSNOED" + Environment.NewLine;
            //    SqlParameter findParaGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NVarChar);
            //    findParaGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNoEd);
            //}
            ////----- ADD 2015/05/20 田建委 Redmine#45693 ----------<<<<<
            //----- DEL 2015/07/24 田建委 Redmine#45693 -----------------<<<<<

            // 価格開始日
            if (GoodsPriceUWork.PriceStartDate != DateTime.MinValue)
            {
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
            }

            //論理削除区分
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// Search検索文字列生成＋条件値設定(削除前の利用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="GoodsPriceUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>クエリ文字列</returns>
        /// <br>Note       : 商品価格マスタの検索用クエリ文字列を生成して戻します</br>
        /// <br>Programmer : liusy</br>
        private string CreateQueryBeforeDelString(ref SqlCommand sqlCommand, GoodsPriceUWork GoodsPriceUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string sqlText = String.Empty;

            sqlText += "SELECT  " + Environment.NewLine;
            sqlText += " UPDATEDATETIMERF," + Environment.NewLine;
            sqlText += " ENTERPRISECODERF," + Environment.NewLine;
            sqlText += " GOODSMAKERCDRF," + Environment.NewLine;
            sqlText += " GOODSNORF," + Environment.NewLine;
            sqlText += " PRICESTARTDATERF " + Environment.NewLine;
            sqlText += " FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // 企業コード
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);

            // メーカーコード
            if (IsValidParameter(GoodsPriceUWork.GoodsMakerCd, false))
            {
                sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
            }

            // 品番
            if (IsValidParameter(GoodsPriceUWork.GoodsNo))
            {
                sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
            }

            // 価格開始日
            if (GoodsPriceUWork.PriceStartDate != DateTime.MinValue)
            {
                sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
            }

            //論理削除区分
            bool useLogicalMode = false;
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                useLogicalMode = true;
                sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                     (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                useLogicalMode = true;
                sqlText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
            }
            if (useLogicalMode)
            {
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return sqlText;
        }
        //add by liusy #35805 2013/06/14----------<<<<<
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.13</br>
        /// <br>------------------------------------------------------------------------------------</br>
        private string MakeSyncWhereString( ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork )
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED " + Environment.NewLine;
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        /// <summary>
        /// stringが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// intが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(int value, bool includeZero)
        {
            if (includeZero)
                return value >= 0;
            return value > 0;
        }
        /// <summary>
        /// DateTimeが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(DateTime value)
        {
            return value > DateTime.MinValue;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: DC.NS対応</br>
        /// <br>Programmer : 21024　佐々木　健</br>
        /// <br>Date       : 2007.08.30</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
        //private GoodsPriceUWork CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader)
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        {
            GoodsPriceUWork wkGoodsPriceUWork = new GoodsPriceUWork();

            #region クラスへ格納
            wkGoodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            //wkGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();
            wkGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

            wkGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            wkGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            wkGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            #endregion

            return wkGoodsPriceUWork;
        }
        //add by liusy #35805 2013/06/14---------->>>>>
        /// <summary>
        /// クラス格納処理 Reader(削除前の利用) → GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2013/06/14</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkBeforeDelFromReader(ref SqlDataReader myReader)
        {


            GoodsPriceUWork wkGoodsPriceUWork = new GoodsPriceUWork();
            #region クラスへ格納
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            #endregion

            return wkGoodsPriceUWork;
        }
        //add by liusy #35805 2013/06/14----------<<<<<
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsPriceUWork[] GoodsPriceUWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is GoodsPriceUWork)
                    {
                        GoodsPriceUWork wkGoodsPriceUWork = paraobj as GoodsPriceUWork;
                        if (wkGoodsPriceUWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkGoodsPriceUWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            GoodsPriceUWorkArray = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsPriceUWork[]));
                        }
                        catch (Exception) { }
                        if (GoodsPriceUWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(GoodsPriceUWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsPriceUWork wkGoodsPriceUWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsPriceUWork));
                                if (wkGoodsPriceUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsPriceUWork);
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
        /// <br>Programmer : 18322  木村 武正</br>
        /// <br>Date       : 2007.04.18</br>
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

    }
}

