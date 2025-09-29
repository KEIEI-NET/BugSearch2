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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;// ADD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using System.Xml;
using System.IO;
using Microsoft.Win32;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫受払履歴データDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫受払履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.01.30</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
    /// <br>Update Note: 30290 得意先・仕入先切り分け</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br>Update Note: 22008 長内 PM.NS用に修正</br>
    /// <br>Date       : 2008.07.03</br>
    /// <br>Update Note: 2019/08/20 陳艶丹</br>
    /// <br>管理番号   : 11500099-00 PMKOBETSU-647</br>
    /// <br>           : 卸商仕入受信処理エラー対応</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br> 
    /// </remarks>
    [Serializable]
    public class StockAcPayHistDB : RemoteDB, IStockAcPayHistDB
    {
        /// <summary>
        /// 在庫受払履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        /// </remarks>
        public StockAcPayHistDB()
            :
            base("MAZAI04336D", "Broadleaf.Application.Remoting.ParamData.StockAcPayHistWork", "STOCKACPAYHISTRF")
        {
        }
        //----- ADD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ---------->>>>>
        # region ■ Const Members ■
        /// <summary>ログデータ対象アセンブリID</summary>
        private const string AssemblyID = "MAZAI04334R";
        /// <summary>ログデータ対象起動プログラム名称</summary>
        private const string BootProgramNm = "在庫受払履歴データDBリモート";
        /// <summary>ログデータ対象アセンブリ名称</summary>
        private const string AssemblyNm = "在庫受払履歴データ登録";
        /// <summary>ログデータ対象クラスID</summary>
        private const string ClassID = "StockAcPayHistDB";
        /// <summary>ログデータ対象処理名</summary>
        private const string ProcNm = "WriteStockAcPayHistProcProc";
        /// <summary>ログデータメッセージ</summary>
        private const string Message = "品名カット　伝票番号：{0}　メーカー名：{1}　品名：{2}";
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        # endregion ■ Const Members ■
        //----- ADD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ----------<<<<<

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫受払履歴データ情報LISTを戻します
        /// </summary>
        /// <param name="stockAcPayHistWork">検索結果</param>
        /// <param name="parastockAcPayHistWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データ情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int Search(out object stockAcPayHistWork, object parastockAcPayHistWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockAcPayHistWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                StockAcPayHistWork stockacpayhistWork = null;

                ArrayList stockacpayhistWorkList = parastockAcPayHistWork as ArrayList;
                if (stockacpayhistWorkList == null)
                {
                    stockacpayhistWork = parastockAcPayHistWork as StockAcPayHistWork;
                }
                else
                {
                    if (stockacpayhistWorkList.Count > 0)
                        stockacpayhistWork = stockacpayhistWorkList[0] as StockAcPayHistWork;
                }

                status = SearchStockAcPayHistProc(out stockacpayhistWorkList, stockacpayhistWork, readMode, logicalMode, ref sqlConnection);

                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                retList.Add(stockacpayhistWorkList);
                stockAcPayHistWork = retList;
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHisDtDB.Search");
                stockAcPayHistWork = new ArrayList();
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
        /// 指定された条件の在庫受払履歴データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockacpayhistWorkList">検索結果</param>
        /// <param name="stockacpayhistWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int SearchStockAcPayHistProc(out ArrayList stockacpayhistWorkList, StockAcPayHistWork stockacpayhistWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return SearchStockAcPayHistProcProc(out stockacpayhistWorkList, stockacpayhistWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫受払履歴データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockacpayhistWorkList">検索結果</param>
        /// <param name="stockacpayhistWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int SearchStockAcPayHistProcProc(out ArrayList stockacpayhistWorkList, StockAcPayHistWork stockacpayhistWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
                selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
                selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
                selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,SHELFNORF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " FROM STOCKACPAYHISTRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockacpayhistWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToStockAcPayHistWorkFromReader(ref myReader));

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

            stockacpayhistWorkList = al;

            return status;
        }

        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の在庫受払履歴データを戻します
        /// </summary>
        /// <param name="parabyte">StockAcPayHistWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                StockAcPayHistWork stockacpayhistWork = new StockAcPayHistWork();

                // XMLの読み込み
                stockacpayhistWork = (StockAcPayHistWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockAcPayHistWork));
                if (stockacpayhistWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref stockacpayhistWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(stockacpayhistWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHistDB.Read");
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
        /// 指定された条件の在庫受払履歴データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockacpayhistWork">StockAcPayHistWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int ReadProc(ref StockAcPayHistWork stockacpayhistWork, int readMode, ref SqlConnection sqlConnection)
        {
            return ReadProcProc(ref stockacpayhistWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の在庫受払履歴データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockacpayhistWork">StockAcPayHistWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫受払履歴データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int ReadProcProc(ref StockAcPayHistWork stockacpayhistWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = "";
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
                selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
                selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
                selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
                selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
                selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,SHELFNORF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
                selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
                selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
                selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
                selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
                selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " FROM STOCKACPAYHISTRF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                selectTxt += "  AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;
                selectTxt += "  AND ACPAYHISTDATETIMERF=@FINDACPAYHISTDATETIME" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                    SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                    SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                    SqlParameter findParaAcPayHistDateTime = sqlCommand.Parameters.Add("@FINDACPAYHISTDATETIME", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                    findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                    findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                    findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);
                    findParaAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.AcPayHistDateTime);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        stockacpayhistWork = CopyToStockAcPayHistWorkFromReader(ref myReader);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 在庫受払履歴データ情報を登録、更新します
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int Write(ref object stockAcPayHistWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //パラメータのキャスト
                CustomSerializeArrayList csaList = stockAcPayHistWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫受払履歴マスタ
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //キーとなる更新日付
                long acPayHistDateTime = DateTime.Now.Ticks;

                //在庫受払履歴マスタWrite
                if (stockAcPayHistList != null)
                {
                    status = WriteStockAcPayHistProc(ref stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockAcPayHistList);

                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockAcPayHistWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockAcPayHistDB.Write(ref object stockAcPayHistWork)");
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
        /// 在庫受払履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int WriteStockAcPayHistProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteStockAcPayHistProcProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫受払履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br>Update Note: 2019/08/20 陳艶丹</br>
        /// <br>管理番号   : 11500099-00 PMKOBETSU-647</br>
        /// <br>           : 卸商仕入受信処理エラー対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int WriteStockAcPayHistProcProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";

            selectTxt += "INSERT INTO STOCKACPAYHISTRF" + Environment.NewLine;
            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "  ,IOGOODSDAYRF" + Environment.NewLine;
            selectTxt += "  ,ADDUPADATERF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPCDRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPNUMRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYSLIPROWNORF" + Environment.NewLine;
            selectTxt += "  ,ACPAYHISTDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,ACPAYTRANSCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTSECTIONCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTSECTIONGUIDNMRF" + Environment.NewLine;
            selectTxt += "  ,INPUTAGENCDRF" + Environment.NewLine;
            selectTxt += "  ,INPUTAGENNMRF" + Environment.NewLine;
            selectTxt += "  ,MOVESTATUSRF" + Environment.NewLine;
            selectTxt += "  ,CUSTSLIPNORF" + Environment.NewLine;
            selectTxt += "  ,SLIPDTLNUMRF" + Environment.NewLine;
            selectTxt += "  ,ACPAYNOTERF" + Environment.NewLine;
            selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "  ,MAKERNAMERF" + Environment.NewLine;
            selectTxt += "  ,GOODSNORF" + Environment.NewLine;
            selectTxt += "  ,GOODSNAMERF" + Environment.NewLine;
            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "  ,BLGOODSFULLNAMERF" + Environment.NewLine;
            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "  ,WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "  ,SHELFNORF" + Environment.NewLine;
            selectTxt += "  ,BFSECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,BFSECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,BFENTERWAREHCODERF" + Environment.NewLine;
            selectTxt += "  ,BFENTERWAREHNAMERF" + Environment.NewLine;
            selectTxt += "  ,BFSHELFNORF" + Environment.NewLine;
            selectTxt += "  ,AFSECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,AFSECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "  ,AFENTERWAREHCODERF" + Environment.NewLine;
            selectTxt += "  ,AFENTERWAREHNAMERF" + Environment.NewLine;
            selectTxt += "  ,AFSHELFNORF" + Environment.NewLine;
            selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "  ,CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "  ,ARRIVALCNTRF" + Environment.NewLine;
            selectTxt += "  ,SHIPMENTCNTRF" + Environment.NewLine;
            selectTxt += "  ,OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "  ,LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "  ,STOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "  ,STOCKPRICERF" + Environment.NewLine;
            selectTxt += "  ,SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            selectTxt += "  ,SALESMONEYRF" + Environment.NewLine;
            selectTxt += "  ,SUPPLIERSTOCKRF" + Environment.NewLine;
            selectTxt += "  ,ACPODRCOUNTRF" + Environment.NewLine;
            selectTxt += "  ,SALESORDERCOUNTRF" + Environment.NewLine;
            selectTxt += "  ,MOVINGSUPLISTOCKRF" + Environment.NewLine;
            selectTxt += "  ,NONADDUPSHIPMCNTRF" + Environment.NewLine;
            selectTxt += "  ,NONADDUPARRGDSCNTRF" + Environment.NewLine;
            selectTxt += "  ,SHIPMENTPOSCNTRF" + Environment.NewLine;
            selectTxt += "  ,PRESENTSTOCKCNTRF" + Environment.NewLine;
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
            selectTxt += "  ,@IOGOODSDAY" + Environment.NewLine;
            selectTxt += "  ,@ADDUPADATE" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPCD" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPNUM" + Environment.NewLine;
            selectTxt += "  ,@ACPAYSLIPROWNO" + Environment.NewLine;
            selectTxt += "  ,@ACPAYHISTDATETIME" + Environment.NewLine;
            selectTxt += "  ,@ACPAYTRANSCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTSECTIONCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTSECTIONGUIDNM" + Environment.NewLine;
            selectTxt += "  ,@INPUTAGENCD" + Environment.NewLine;
            selectTxt += "  ,@INPUTAGENNM" + Environment.NewLine;
            selectTxt += "  ,@MOVESTATUS" + Environment.NewLine;
            selectTxt += "  ,@CUSTSLIPNO" + Environment.NewLine;
            selectTxt += "  ,@SLIPDTLNUM" + Environment.NewLine;
            selectTxt += "  ,@ACPAYNOTE" + Environment.NewLine;
            selectTxt += "  ,@GOODSMAKERCD" + Environment.NewLine;
            selectTxt += "  ,@MAKERNAME" + Environment.NewLine;
            selectTxt += "  ,@GOODSNO" + Environment.NewLine;
            selectTxt += "  ,@GOODSNAME" + Environment.NewLine;
            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
            selectTxt += "  ,@BLGOODSFULLNAME" + Environment.NewLine;
            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@SECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@WAREHOUSECODE" + Environment.NewLine;
            selectTxt += "  ,@WAREHOUSENAME" + Environment.NewLine;
            selectTxt += "  ,@SHELFNO" + Environment.NewLine;
            selectTxt += "  ,@BFSECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@BFSECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@BFENTERWAREHCODE" + Environment.NewLine;
            selectTxt += "  ,@BFENTERWAREHNAME" + Environment.NewLine;
            selectTxt += "  ,@BFSHELFNO" + Environment.NewLine;
            selectTxt += "  ,@AFSECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,@AFSECTIONGUIDENM" + Environment.NewLine;
            selectTxt += "  ,@AFENTERWAREHCODE" + Environment.NewLine;
            selectTxt += "  ,@AFENTERWAREHNAME" + Environment.NewLine;
            selectTxt += "  ,@AFSHELFNO" + Environment.NewLine;
            selectTxt += "  ,@CUSTOMERCODE" + Environment.NewLine;
            selectTxt += "  ,@CUSTOMERSNM" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERCD" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERSNM" + Environment.NewLine;
            selectTxt += "  ,@ARRIVALCNT" + Environment.NewLine;
            selectTxt += "  ,@SHIPMENTCNT" + Environment.NewLine;
            selectTxt += "  ,@OPENPRICEDIV" + Environment.NewLine;
            selectTxt += "  ,@LISTPRICETAXEXCFL" + Environment.NewLine;
            selectTxt += "  ,@STOCKUNITPRICEFL" + Environment.NewLine;
            selectTxt += "  ,@STOCKPRICE" + Environment.NewLine;
            selectTxt += "  ,@SALESUNPRCTAXEXCFL" + Environment.NewLine;
            selectTxt += "  ,@SALESMONEY" + Environment.NewLine;
            selectTxt += "  ,@SUPPLIERSTOCK" + Environment.NewLine;
            selectTxt += "  ,@ACPODRCOUNT" + Environment.NewLine;
            selectTxt += "  ,@SALESORDERCOUNT" + Environment.NewLine;
            selectTxt += "  ,@MOVINGSUPLISTOCK" + Environment.NewLine;
            selectTxt += "  ,@NONADDUPSHIPMCNT" + Environment.NewLine;
            selectTxt += "  ,@NONADDUPARRGDSCNT" + Environment.NewLine;
            selectTxt += "  ,@SHIPMENTPOSCNT" + Environment.NewLine;
            selectTxt += "  ,@PRESENTSTOCKCNT" + Environment.NewLine;
            selectTxt += " )" + Environment.NewLine;

            //新規作成時のSQL文を生成
            sqlCommand = new SqlCommand(selectTxt,sqlConnection,sqlTransaction);
            
            #region Parameterオブジェクトの作成(更新用)
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraIoGoodsDay = sqlCommand.Parameters.Add("@IOGOODSDAY", SqlDbType.Int);
            SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
            SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
            SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@ACPAYSLIPNUM", SqlDbType.NVarChar);
            SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@ACPAYSLIPROWNO", SqlDbType.Int);
            SqlParameter paraAcPayHistDateTime = sqlCommand.Parameters.Add("@ACPAYHISTDATETIME", SqlDbType.BigInt);
            SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
            SqlParameter paraInputSectionCd = sqlCommand.Parameters.Add("@INPUTSECTIONCD", SqlDbType.NChar);
            SqlParameter paraInputSectionGuidNm = sqlCommand.Parameters.Add("@INPUTSECTIONGUIDNM", SqlDbType.NVarChar);
            SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
            SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
            SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
            SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.NVarChar);
            SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
            SqlParameter paraAcPayNote = sqlCommand.Parameters.Add("@ACPAYNOTE", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
            SqlParameter paraShelfNo = sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
            SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraBfSectionGuideNm = sqlCommand.Parameters.Add("@BFSECTIONGUIDENM", SqlDbType.NChar);
            SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
            SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
            SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
            SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraAfSectionGuideNm = sqlCommand.Parameters.Add("@AFSECTIONGUIDENM", SqlDbType.NChar);
            SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
            SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
            SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
            SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
            SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
            SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
            SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
            SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
            SqlParameter paraStockPrice = sqlCommand.Parameters.Add("@STOCKPRICE", SqlDbType.BigInt);
            SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
            SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
            SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
            SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
            SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
            SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
            SqlParameter paraNonAddUpShipmCnt = sqlCommand.Parameters.Add("@NONADDUPSHIPMCNT", SqlDbType.Float);
            SqlParameter paraNonAddUpArrGdsCnt = sqlCommand.Parameters.Add("@NONADDUPARRGDSCNT", SqlDbType.Float);
            SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
            SqlParameter paraPresentStockCnt = sqlCommand.Parameters.Add("@PRESENTSTOCKCNT", SqlDbType.Float);
            #endregion
            
            string field = string.Empty;
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                if (stockAcPayHistWorkList != null)
                {
                    //重複防止用にKeyを作成
                    int keyCode = 1;
                
                    for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
                    {
                        StockAcPayHistWork stockacpayhistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;

                        //出荷数、入荷数ともに０の場合は受払履歴を作成しない
                        //if (stockacpayhistWork.ShipmentCnt == 0 && stockacpayhistWork.ArrivalCnt == 0) continue; //金額調整レコードを考慮して削除 2009/01/19

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockacpayhistWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        //売、仕入の入力で品番変更して更新するパターンがある為、
                        //１レコードずつデータ更新日時を変更する
                        stockacpayhistWork.AcPayHistDateTime = DateTime.Now.Ticks;

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockacpayhistWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.LogicalDeleteCode);
                        paraIoGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockacpayhistWork.IoGoodsDay);
                        paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockacpayhistWork.AddUpADate);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(keyCode);  //無重複用項目とする。
                        paraAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.AcPayHistDateTime);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPayTransCd);
                        paraInputSectionCd.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputSectionCd);
                        paraInputSectionGuidNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputSectionGuidNm);
                        paraInputAgenCd.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputAgenCd);
                        paraInputAgenNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.InputAgenNm);
                        paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.MoveStatus);
                        paraCustSlipNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.CustSlipNo);
                        paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.SlipDtlNum);
                        paraAcPayNote.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPayNote);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsNo);
                        //----- UPD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ---------->>>>>
                        //paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName);
                        if (!string.IsNullOrEmpty(stockacpayhistWork.GoodsName) && stockacpayhistWork.GoodsName.Length > 40)
                        {
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName.Substring(0, 40));
                            this.WriteOprtnHisLog(ref sqlConnection, ref sqlTransaction, stockacpayhistWork.AcPaySlipNum, stockacpayhistWork.MakerName, stockacpayhistWork.GoodsName.Trim());
                        }
                        else
                        {
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.GoodsName);
                        }
                        //----- UPD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ----------<<<<<
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BLGoodsFullName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SectionCode);
                        paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SectionGuideNm);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.WarehouseName);
                        paraShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.ShelfNo);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfSectionCode);
                        paraBfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfSectionGuideNm);
                        paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfEnterWarehCode);
                        paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfEnterWarehName);
                        paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.BfShelfNo);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfSectionCode);
                        paraAfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfSectionGuideNm);
                        paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfEnterWarehCode);
                        paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfEnterWarehName);
                        paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AfShelfNo);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.CustomerCode);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.CustomerSnm);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.SupplierCd);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.SupplierSnm);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ArrivalCnt);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ShipmentCnt);
                        paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.OpenPriceDiv);
                        paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ListPriceTaxExcFl);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.StockUnitPriceFl);
                        paraStockPrice.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.StockPrice);
                        paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SalesUnPrcTaxExcFl);
                        paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(stockacpayhistWork.SalesMoney);
                        paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SupplierStock);
                        paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.AcpOdrCount);
                        paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.SalesOrderCount);
                        paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.MovingSupliStock);
                        paraNonAddUpShipmCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.NonAddUpShipmCnt);
                        paraNonAddUpArrGdsCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.NonAddUpArrGdsCnt);
                        paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.ShipmentPosCnt);
                        paraPresentStockCnt.Value = SqlDataMediator.SqlSetDouble(stockacpayhistWork.PresentStockCnt);
                        #endregion

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockacpayhistWork);

                        //キー項目インクリメント
                        keyCode++;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex,"",ex.Number);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex.Message);
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

            stockAcPayHistWorkList = al;

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

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 在庫受払履歴データ情報を論理削除します
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        public int LogicalDelete(ref object stockAcPayHistWork)
        {
            return LogicalDeleteStockAcPayHist(ref stockAcPayHistWork);
        }

        /// <summary>
        /// 論理削除在庫受払履歴データ情報を復活します
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫受払履歴データ情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        public int RevivalLogicalDelete(ref object stockAcPayHistWork)
        {
            return LogicalDeleteStockAcPayHist(ref stockAcPayHistWork);
        }

        /// <summary>
        /// 在庫受払履歴データ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockAcPayHistWork">StockAcPayHistWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int LogicalDeleteStockAcPayHist(ref object stockAcPayHistWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //パラメータのキャスト
                CustomSerializeArrayList csaList = stockAcPayHistWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫受払履歴マスタ
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //在庫受払履歴論理削除
                if (stockAcPayHistList != null)
                {
                    status = LogicalDeleteStockAcPayHistProc(ref stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                    retList.Add(stockAcPayHistList);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                stockAcPayHistWork = retList;
            }
            catch (Exception ex)
            {
                //string procModestr = "";

                base.WriteErrorLog(ex, "StockAcPayHistDB.LogicalDeleteStockAcPayHis");

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
        /// 在庫受払履歴データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int LogicalDeleteStockAcPayHistProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteStockAcPayHistProcProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 在庫受払履歴データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockAcPayHistWorkList">StockAcPayHistWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int LogicalDeleteStockAcPayHistProcProc(ref ArrayList stockAcPayHistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectTxt = "";
            
            int logicalDelCd = 0;

            try
            {
                if (stockAcPayHistWorkList != null)
                {
                    for (int i = 0; i < stockAcPayHistWorkList.Count; i++)
                    {
                        StockAcPayHistWork stockacpayhistWork = stockAcPayHistWorkList[i] as StockAcPayHistWork;

                        selectTxt = "";
                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "  STOCKACPAYHISTRF.UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " ,STOCKACPAYHISTRF.ENTERPRISECODERF" + Environment.NewLine;
                        selectTxt += " ,STOCKACPAYHISTRF.LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     STOCKACPAYHISTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                        selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                        SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            //if (_updateDateTime != stockacpayhistWork.UpdateDateTime)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            //    sqlCommand.Cancel();
                            //    return status;
                            //}

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            selectTxt = "";
                            selectTxt += "UPDATE STOCKACPAYHISTRF SET" + Environment.NewLine;
                            selectTxt += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += ", UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += ", UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "WHERE" + Environment.NewLine;
                            selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                            selectTxt += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                            findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                            findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                            findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockacpayhistWork;
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

                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            sqlCommand.Cancel();
                            return status;
                        }
                        else if (logicalDelCd == 0) stockacpayhistWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else stockacpayhistWork.LogicalDeleteCode = 3;//完全削除フラグをセット

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockacpayhistWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockacpayhistWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            stockAcPayHistWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫受払履歴データ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">在庫受払履歴データ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 在庫受払履歴データ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList stockAcPayHistList = null;

                //パラメータのキャスト
                CustomSerializeArrayList csaList = paraobj as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //在庫受払履歴マスタ
                            if (wkal[0] is StockAcPayHistWork) stockAcPayHistList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //在庫受払履歴削除
                if (stockAcPayHistList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteStockAcPayHistProc(stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
                }

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
                base.WriteErrorLog(ex, "StockAcPayHistDB.Delete");
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
        /// 在庫受払履歴データ情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)
        /// </summary>
        /// <param name="stockacpayhistWorkList">在庫受払履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫受払履歴データ情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        public int DeleteStockAcPayHistProc(ArrayList stockacpayhistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAcPayHistProcProc(stockacpayhistWorkList, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// 在庫受払履歴データ情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)
        /// </summary>
        /// <param name="stockacpayhistWorkList">在庫受払履歴データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 在庫受払履歴データ情報を物理削除します(外部からのSqlConnection, SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private int DeleteStockAcPayHistProcProc(ArrayList stockacpayhistWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string selectTxt = "";
            try
            {

                for (int i = 0; i < stockacpayhistWorkList.Count; i++)
                {
                    StockAcPayHistWork stockacpayhistWork = stockacpayhistWorkList[i] as StockAcPayHistWork;

                    selectTxt = "";
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  STOCKACPAYHISTRF.UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += " ,STOCKACPAYHISTRF.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,STOCKACPAYHISTRF.LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += "     STOCKACPAYHISTRF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                    selectTxt += " AND STOCKACPAYHISTRF.ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                    SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                    SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                    findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                    findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                    findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != stockacpayhistWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        selectTxt = "";
                        selectTxt += "DELETE" + Environment.NewLine;
                        selectTxt += "FROM STOCKACPAYHISTRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += "     ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                        selectTxt += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.EnterpriseCode);
                        findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipCd);
                        findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockacpayhistWork.AcPaySlipNum);
                        findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockacpayhistWork.AcPaySlipRowNo);
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
        /// <param name="stockAcPayHistWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.10 長内 DC.NS用に修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockAcPayHistWork stockAcPayHistWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += "     ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //受払元伝票区分
            if (stockAcPayHistWork.AcPaySlipCd != 0)
            {
                retstring += " AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD" + Environment.NewLine;
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipCd);
            }

            //受払元伝票番号
            if (string.IsNullOrEmpty(stockAcPayHistWork.AcPaySlipNum) == false)
            {
                retstring += " AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM" + Environment.NewLine;
                SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AcPaySlipNum);
            }

            //受払元行番号
            if (stockAcPayHistWork.AcPaySlipRowNo != 0)
            {
                retstring += " AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO" + Environment.NewLine;
                SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipRowNo);
            }

            return retstring;
        }
        
        #endregion

        #region [クラス格納処理]

        /// <summary>
        /// クラス格納処理 Reader → StockAcPayHistWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockAcPayHistWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.07 長内 DC.NS用に修正</br>
        /// </remarks>
        public StockAcPayHistWork CopyToStockAcPayHistWorkFromReader(ref SqlDataReader myReader)
        {
            StockAcPayHistWork wkStockAcPayHistWork = new StockAcPayHistWork();

            #region クラスへ格納
            wkStockAcPayHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockAcPayHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockAcPayHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockAcPayHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockAcPayHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockAcPayHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockAcPayHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockAcPayHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
            wkStockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkStockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            wkStockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
            wkStockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            wkStockAcPayHistWork.AcPayHistDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPAYHISTDATETIMERF"));
            wkStockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            wkStockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCDRF"));
            wkStockAcPayHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONGUIDNMRF"));
            wkStockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            wkStockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            wkStockAcPayHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
            wkStockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            wkStockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
            wkStockAcPayHistWork.AcPayNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYNOTERF"));
            wkStockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkStockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockAcPayHistWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
            wkStockAcPayHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
            wkStockAcPayHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDENMRF"));
            wkStockAcPayHistWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
            wkStockAcPayHistWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            wkStockAcPayHistWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            wkStockAcPayHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
            wkStockAcPayHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDENMRF"));
            wkStockAcPayHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
            wkStockAcPayHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            wkStockAcPayHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            wkStockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkStockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkStockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkStockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockAcPayHistWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkStockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkStockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICERF"));
            wkStockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            wkStockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
            wkStockAcPayHistWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockAcPayHistWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockAcPayHistWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockAcPayHistWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockAcPayHistWork.NonAddUpShipmCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPSHIPMCNTRF"));
            wkStockAcPayHistWork.NonAddUpArrGdsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPARRGDSCNTRF"));
            wkStockAcPayHistWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockAcPayHistWork.PresentStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));
            #endregion

            return wkStockAcPayHistWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.30</br>
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

        //----- ADD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ---------->>>>>
        #region 操作履歴ログ書き込み処理
        /// <summary>
        /// 操作履歴ログ書き込み処理
        /// </summary>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="slipNo">伝票番号</param>
        /// <param name="makerName">メーカー名</param>
        /// <param name="goodsName">品名(カット前)</param>
        /// <remarks>
        /// <br>Note       : ログ出力処理。</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/08/20</br>
        /// </remarks>
        private void WriteOprtnHisLog(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string slipNo, string makerName, string goodsName)
        {
            try
            {
                // 操作履歴ログデータ登録用リスト
                ArrayList writeList = new ArrayList();

                # region [書き込み内容のセット]
                // 操作履歴ログデータ登録用ワーク
                OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
                // ログデータ対象アセンブリID
                oprtnhislogWork.LogDataObjAssemblyID = AssemblyID;
                // ログデータ対象アセンブリ名称
                oprtnhislogWork.LogDataObjAssemblyNm = AssemblyNm;
                // ログデータ対象クラスID
                oprtnhislogWork.LogDataObjClassID = ClassID;
                // ログデータ対象処理名
                oprtnhislogWork.LogDataObjProcNm = ProcNm;
                // ログデータ対象起動プログラム名称
                oprtnhislogWork.LogDataObjBootProgramNm = BootProgramNm;
                // ログデータオペレーションコード
                oprtnhislogWork.LogDataOperationCd = 3;
                // ログデータメッセージ
                oprtnhislogWork.LogDataMassage = string.Format(Message, slipNo, makerName, goodsName);
                // ログデータ作成日時
                oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
                LogTextData logTextData = new LogTextData("", "", 0, new Exception());
                // ログデータ端末名
                oprtnhislogWork.LogDataMachineName = logTextData.ClientAuthInfoWork.MachineUserId;
                // ログデータ担当者コード
                oprtnhislogWork.LogDataAgentCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                // ログデータ担当者名(担当者コード)
                oprtnhislogWork.LogDataAgentNm = logTextData.EmployeeAuthInfoWork.EmployeeWork.EmployeeCode;
                // ログイン拠点コード
                oprtnhislogWork.LoginSectionCd = logTextData.EmployeeAuthInfoWork.EmployeeWork.BelongSectionCode;
                // ログデータシステムバージョン
                oprtnhislogWork.LogDataSystemVersion = this.GetType().Assembly.GetName().Version.ToString();
                // ログデータオペレーターデータ処理レベル
                oprtnhislogWork.LogOperaterDtProcLvl = "0";
                // ログデータオペレーター機能処理レベル
                oprtnhislogWork.LogOperaterFuncLvl = "0";
                // ログデータ種別区分コード
                oprtnhislogWork.LogDataKindCd = 9;
                // ログオペレーションステータス
                oprtnhislogWork.LogOperationStatus = 0;
                //ログデータGUID
                Guid guidValue = Guid.NewGuid();
                oprtnhislogWork.LogDataGuid = guidValue;
                writeList.Add(oprtnhislogWork);
                # endregion

                // 操作履歴ログデータリモート
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                // 操作履歴ログデータ登録処理を行う
                oprtnHisLogDB.WriteOprtnHisLogProc(ref writeList, ref sqlConnection, ref sqlTransaction);
            }
            catch(Exception ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex.Message);
            }
        }
        #endregion
        //----- ADD 2019/08/20 陳艶丹 PMKOBETSU-647 卸商仕入受信処理エラー対応 ----------<<<<<
    }
}
