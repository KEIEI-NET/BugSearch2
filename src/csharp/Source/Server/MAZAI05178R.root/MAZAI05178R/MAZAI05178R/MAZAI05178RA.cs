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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 棚卸過不足更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸過不足更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.07.17</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.12 Yokokawa</br>
    /// <br>             流通.NS 用に改造</br>
    /// <br>Update Note: 2008/09/19 Hatanaka</br>
    /// <br>             PM.NS用に改造</br>
    /// <br>Update Note: 2009/09/14 長内</br>
    /// <br>             MANTIS対応(13940)</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
    /// </remarks>
    [Serializable]
    public class InventoryExcDefUpdateDB : RemoteDB
    {
        /// <summary>
        /// 棚卸過不足更新DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12  Yokokawa</br>
        /// <br>             流通.NS 用に改造</br>
        /// </remarks>
        public InventoryExcDefUpdateDB()
            :
            base("SFDML02063D", "Broadleaf.Application.Remoting.ParamData.InventoryExcDefUpdateWork", "INVENTORYDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の棚卸過不足更新情報LISTを戻します
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">検索結果</param>
        /// <param name="parainventoryExcDefUpdateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int Search(out object inventoryExcDefUpdateWork, object parainventoryExcDefUpdateWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            inventoryExcDefUpdateWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchInventoryExcDefUpdateProc(out inventoryExcDefUpdateWork, parainventoryExcDefUpdateWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Search");
                inventoryExcDefUpdateWork = new ArrayList();
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
        /// 指定された条件の棚卸過不足更新情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objinventoryExcDefUpdateWork">検索結果</param>
        /// <param name="parainventoryExcDefUpdateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        public int SearchInventoryExcDefUpdateProc(out object objinventoryExcDefUpdateWork, object parainventoryExcDefUpdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            InventoryDataUpdateWork inventoryexcdefupdateWork = null;

            ArrayList inventoryexcdefupdateWorkList = parainventoryExcDefUpdateWork as ArrayList;
            if (inventoryexcdefupdateWorkList == null)
            {
                inventoryexcdefupdateWork = parainventoryExcDefUpdateWork as InventoryDataUpdateWork;
            }
            else
            {
                if (inventoryexcdefupdateWorkList.Count > 0)
                    inventoryexcdefupdateWork = inventoryexcdefupdateWorkList[0] as InventoryDataUpdateWork;
            }
            int status = SearchInventoryExcDefUpdateProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection);
            objinventoryExcDefUpdateWork = inventoryexcdefupdateWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">検索結果</param>
        /// <param name="inventoryexcdefupdateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int SearchInventoryExcDefUpdateProc(out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return SearchInventoryExcDefUpdateProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">検索結果</param>
        /// <param name="inventoryexcdefupdateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        public int SearchInventoryExcDefUpdateProc(out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchInventoryExcDefUpdateProcProc(out inventoryexcdefupdateWorkList, inventoryexcdefupdateWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">検索結果</param>
        /// <param name="inventoryexcdefupdateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        private int SearchInventoryExcDefUpdateProcProc( out ArrayList inventoryexcdefupdateWorkList, InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF ", sqlConnection);

                if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryexcdefupdateWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToInventoryExcDefUpdateWorkFromReader(ref myReader));

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

            inventoryexcdefupdateWorkList = al;

            return status;
        }

        /// <summary>
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="stockWorkList">stockWorkList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int SearchStockFromInventoryProc(ArrayList inventoryExcDefUpdateWorkList, out ArrayList stockWorkList,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchStockFromInventoryProcProc(inventoryExcDefUpdateWorkList, out stockWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="stockWorkList">stockWorkList</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        private int SearchStockFromInventoryProcProc( ArrayList inventoryExcDefUpdateWorkList, out ArrayList stockWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string selectString = "";
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        // 2008.04.03 Upd >>>>>>>>
                        selectString =
                            "SELECT * " +
                            "FROM STOCKRF " +
                            "WHERE " +
                            "ENTERPRISECODERF=@FINDENTERPRISECODE AND " +
                            "LOGICALDELETECODERF=0 AND " +
                            "SECTIONCODERF=@FINDSECTIONCODE AND " +
                            "WAREHOUSECODERF=@FINDWAREHOUSECODE AND " +
                            "GOODSMAKERCDRF=@FINDGOODSMAKERCD AND " +
                            "GOODSNORF=@FINDGOODSNO ";

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectString, sqlConnection, sqlTransaction);

                        //Parameterオブジェクトの作成(検索用)
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWareHouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定(検索用)
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findWareHouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {

                            al.Add(CopyToStockWorkFromInventoryReader(inventoryDataUpdateWork, ref myReader));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if (myReader != null)
                            if (myReader.IsClosed == false) myReader.Close();

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

            stockWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の棚卸過不足更新を戻します
        /// </summary>
        /// <param name="parabyte">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新を戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                InventoryDataUpdateWork inventoryexcdefupdateWork = new InventoryDataUpdateWork();

                // XMLの読み込み
                inventoryexcdefupdateWork = (InventoryDataUpdateWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventoryDataUpdateWork));
                if (inventoryexcdefupdateWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref inventoryexcdefupdateWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(inventoryexcdefupdateWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Read");
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
        /// 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWork">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int ReadProc(ref InventoryDataUpdateWork inventoryexcdefupdateWork, int readMode, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return ReadProc(ref inventoryexcdefupdateWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryDataUpdateWork">InventoryDataUpdateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        public int ReadProc(ref InventoryDataUpdateWork inventoryDataUpdateWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref inventoryDataUpdateWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inventoryDataUpdateWork">InventoryDataUpdateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の棚卸過不足更新を戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
        private int ReadProcProc( ref InventoryDataUpdateWork inventoryDataUpdateWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection)) // DEL 2009/12/03
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection)) // ADD 2009/12/03
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        inventoryDataUpdateWork = CopyToInventoryExcDefUpdateWorkFromReader(ref myReader);
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
        /// 棚卸過不足更新情報を登録、更新します
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int Write(ref object inventoryExcDefUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = inventoryExcDefUpdateWork as ArrayList;//CastToArrayListFromPara(inventoryExcDefUpdateWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteInventoryExcDefUpdateProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                inventoryExcDefUpdateWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Write(ref object inventoryExcDefUpdateWork)");
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
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        public int WriteInventoryExcDefUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteInventoryExcDefUpdateProcProc(ref inventoryExcDefUpdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2007.09.12 Yokokawa 流通.NS 用に改造</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
        private int WriteInventoryExcDefUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (inventoryDataUpdateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            // 修正 2008/09/19 テーブルレイアウトの変更対応 >>>
                            //sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYSEQNORF=@INVENTORYSEQNO , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , GOODSMAKERCDRF=@GOODSMAKERCD , MAKERNAMERF=@MAKERNAME , GOODSNORF=@GOODSNO , GOODSNAMERF=@GOODSNAME , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1 , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2 , LARGEGOODSGANRECODERF=@LARGEGOODSGANRECODE , LARGEGOODSGANRENAMERF=@LARGEGOODSGANRENAME , MEDIUMGOODSGANRECODERF=@MEDIUMGOODSGANRECODE , MEDIUMGOODSGANRENAMERF=@MEDIUMGOODSGANRENAME , DETAILGOODSGANRECODERF=@DETAILGOODSGANRECODE , DETAILGOODSGANRENAMERF=@DETAILGOODSGANRENAME , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE , ENTERPRISEGANRENAMERF=@ENTERPRISEGANRENAME , BLGOODSCODERF=@BLGOODSCODE , SUPPLIERCDRF=@SUPPLIERCD , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , JANRF=@JAN , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL , STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG , STOCKDIVRF=@STOCKDIV , LASTSTOCKDATERF=@LASTSTOCKDATE , STOCKTOTALRF=@STOCKTOTAL , SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE , SHIPCUSTOMERNAMERF=@SHIPCUSTOMERNAME , SHIPCUSTOMERNAME2RF=@SHIPCUSTOMERNAME2 , INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT , INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYDAYRF=@INVENTORYDAY , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE , INVENTORYNEWDIVRF=@INVENTORYNEWDIV , STOCKMASHINEPRICERF=@STOCKMASHINEPRICE , INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE, INVENTORYDATERF=@INVENTORYDATE, STOCKTOTALEXECRF=@STOCKTOTALEXEC, TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO";
                            #region UPDATE文作成
                            sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET" + Environment.NewLine;
                            sqlCommand.CommandText = " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText = " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText = " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSEQNORF=@INVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlCommand.CommandText = " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            sqlCommand.CommandText = " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSLGROUPRF=@GOODSLGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = " , JANRF=@JAN" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = " , BFSTOCKUNITPRICEFLRF=@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = " , STKUNITPRICECHGFLGRF=@STKUNITPRICECHGFLG" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKDIVRF=@STOCKDIV" + Environment.NewLine;
                            sqlCommand.CommandText = " , LASTSTOCKDATERF=@LASTSTOCKDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKTOTALRF=@STOCKTOTAL" + Environment.NewLine;
                            sqlCommand.CommandText = " , SHIPCUSTOMERCODERF=@SHIPCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSTOCKCNTRF=@INVENTORYSTOCKCNT" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYDAYRF=@INVENTORYDAY" + Environment.NewLine;
                            sqlCommand.CommandText = " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYNEWDIVRF=@INVENTORYNEWDIV" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKMASHINEPRICERF=@STOCKMASHINEPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYSTOCKPRICERF=@INVENTORYSTOCKPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = " , INVENTORYDATERF=@INVENTORYDATE" + Environment.NewLine;
                            sqlCommand.CommandText = " , STOCKTOTALEXECRF=@STOCKTOTALEXEC" + Environment.NewLine;
                            sqlCommand.CommandText = " , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD" + Environment.NewLine;
                            sqlCommand.CommandText = " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = " AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = " AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine; // ADD 2009/12/03
                            #endregion
                            // 修正 2008/09/19 <<<
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (inventoryDataUpdateWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            // 修正 2008/09/19 テーブルレイアウトの変更対応 >>>
                            //sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, WAREHOUSENAMERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, LARGEGOODSGANRECODERF, LARGEGOODSGANRENAMERF, MEDIUMGOODSGANRECODERF, MEDIUMGOODSGANRENAMERF, DETAILGOODSGANRECODERF, DETAILGOODSGANRENAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, BLGOODSCODERF, SUPPLIERCDRF, CUSTOMERNAMERF, CUSTOMERNAME2RF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, SHIPCUSTOMERNAMERF, SHIPCUSTOMERNAME2RF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF, STOCKTOTALEXECRF, TOLERANCEUPDATECDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @WAREHOUSENAME, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @LARGEGOODSGANRECODE, @LARGEGOODSGANRENAME, @MEDIUMGOODSGANRECODE, @MEDIUMGOODSGANRENAME, @DETAILGOODSGANRECODE, @DETAILGOODSGANRENAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @BLGOODSCODE, @SUPPLIERCD, @CUSTOMERNAME, @CUSTOMERNAME2, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @SHIPCUSTOMERNAME, @SHIPCUSTOMERNAME2, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE, @STOCKTOTALEXEC, @TOLERANCEUPDATECD)";
                            #region INSERT文作成
                            sqlCommand.CommandText = "INSERT INTO INVENTORYDATARF" + Environment.NewLine;
                            sqlCommand.CommandText = " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",UPDATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",ENTERPRISECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = ",FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlCommand.CommandText = ",UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlCommand.CommandText = "UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlCommand.CommandText = "LOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSEQNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "WAREHOUSECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSMAKERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "WAREHOUSESHELFNORF" + Environment.NewLine;
                            sqlCommand.CommandText = "DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                            sqlCommand.CommandText = "DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSLGROUPRF" + Environment.NewLine;
                            sqlCommand.CommandText = "GOODSMGROUPRF" + Environment.NewLine;
                            sqlCommand.CommandText = "BLGROUPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "ENTERPRISEGANRECODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "BLGOODSCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "SUPPLIERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText = "JANRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKUNITPRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText = "BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STKUNITPRICECHGFLGRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText = "LASTSTOCKDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKTOTALRF" + Environment.NewLine;
                            sqlCommand.CommandText = "SHIPCUSTOMERCODERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSTOCKCNTRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYTOLERANCCNTRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYPREPRDAYRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYPREPRTIMRF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYDAYRF" + Environment.NewLine;
                            sqlCommand.CommandText = "LASTINVENTORYUPDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYNEWDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKMASHINEPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYSTOCKPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYTLRNCPRICERF" + Environment.NewLine;
                            sqlCommand.CommandText = "INVENTORYDATERF" + Environment.NewLine;
                            sqlCommand.CommandText = "STOCKTOTALEXECRF" + Environment.NewLine;
                            sqlCommand.CommandText = "TOLERANCEUPDATECDRF" + Environment.NewLine;
                            sqlCommand.CommandText = " )" + Environment.NewLine;
                            sqlCommand.CommandText = " VALUES" + Environment.NewLine;
                            sqlCommand.CommandText = " (@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText = "@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText = "@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText = "@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSEQNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@WAREHOUSECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlCommand.CommandText = "@DUPLICATIONSHELFNO1" + Environment.NewLine;
                            sqlCommand.CommandText = "@DUPLICATIONSHELFNO2" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSLGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = "@GOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = "@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@ENTERPRISEGANRECODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = "@JAN" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = "@BFSTOCKUNITPRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText = "@STKUNITPRICECHGFLG" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKDIV" + Environment.NewLine;
                            sqlCommand.CommandText = "@LASTSTOCKDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKTOTAL" + Environment.NewLine;
                            sqlCommand.CommandText = "@SHIPCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSTOCKCNT" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYTOLERANCCNT" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYPREPRDAY" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYPREPRTIM" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYDAY" + Environment.NewLine;
                            sqlCommand.CommandText = "@LASTINVENTORYUPDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYNEWDIV" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKMASHINEPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYSTOCKPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYTLRNCPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = "@INVENTORYDATE" + Environment.NewLine;
                            sqlCommand.CommandText = "@STOCKTOTALEXEC" + Environment.NewLine;
                            sqlCommand.CommandText = "@TOLERANCEUPDATECD" + Environment.NewLine;
                            sqlCommand.CommandText = " )" + Environment.NewLine;
                            #endregion
                            // 修正 2008/09/19 <<<
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            // 2007.10.05 Add >>>>>>>>
                            //新規データのInventroySeqNo は、InventorySeqNoの最大値 + 1 とします。
                            //inventoryDataUpdateWorkに設定されているInventorySeqNoは無視します。
                            int inventorySeqNo = 0;
                            GetMaxInventorySeq(out inventorySeqNo, inventoryDataUpdateWork, ref sqlConnection);
                            inventoryDataUpdateWork.InventorySeqNo = inventorySeqNo + 1;
                            // 2007.10.05 Add <<<<<<<<
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        // 修正 2008/09/19  テーブルレイアウト変更対応 >>>
                        #region 修正前
                        /*
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraLargeGoodsGanreCode = sqlCommand.Parameters.Add("@LARGEGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraLargeGoodsGanreName = sqlCommand.Parameters.Add("@LARGEGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraMediumGoodsGanreCode = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraMediumGoodsGanreName = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraDetailGoodsGanreCode = sqlCommand.Parameters.Add("@DETAILGOODSGANRECODE", SqlDbType.NChar);
                        SqlParameter paraDetailGoodsGanreName = sqlCommand.Parameters.Add("@DETAILGOODSGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraShipCustomerName = sqlCommand.Parameters.Add("@SHIPCUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraShipCustomerName2 = sqlCommand.Parameters.Add("@SHIPCUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        // 2008.03.07 Add >>>>>>>>
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // 2008.03.07 Add <<<<<<<<
                        */ 
                        #endregion
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // 修正 2008/09/19  <<<
                        #endregion // Parameterオブジェクトの作成(更新用)

                        #region Parameterオブジェクトへ値設定(更新用)
                        // 修正 2008/09/19 テーブルレイアウトの変更対応 >>>
                        #region 修正前
                        /*
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsName);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                        paraLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.LargeGoodsGanreCode);
                        paraLargeGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.LargeGoodsGanreName);
                        paraMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MediumGoodsGanreCode);
                        paraMediumGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.MediumGoodsGanreName);
                        paraDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DetailGoodsGanreCode);
                        paraDetailGoodsGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DetailGoodsGanreName);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                        paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseGanreName);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                        paraCustomerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.CustomerName);
                        paraCustomerName2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.CustomerName2);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                        paraShipCustomerName.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.ShipCustomerName);
                        paraShipCustomerName2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.ShipCustomerName2);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        // 2008.03.07 Add >>>>>>>>
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // 2008.03.07 Add <<<<<<<<
                        */ 
                        #endregion
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataUpdateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.GoodsNo);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.DuplicationShelfNo2);
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsLGroup);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGroupCode);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.EnterpriseGanreCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.SupplierCd);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ShipCustomerCode);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // 修正 2008/09/19 <<<
                        #endregion // Parameterオブジェクトへ値設定(更新用)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
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

            inventoryExcDefUpdateWorkList = al;

            return status;
        }

        /// <summary>
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2008.04.03 横川</br>
        public int WriteLastInventoryUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteLastInventoryUpdateProcProc(ref inventoryExcDefUpdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>Update     : 2008.04.03 横川</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
        private int WriteLastInventoryUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Selectコマンドの生成
                        // 修正 2008/09/19 更新項目の追加 >>>
                        //sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction);
                        //sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , STOCKTOTALEXECRF=@STOCKTOTALEXEC , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE, INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , STOCKTOTALEXECRF=@STOCKTOTALEXEC , TOLERANCEUPDATECDRF=@TOLERANCEUPDATECD , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE, INVENTORYTOLERANCCNTRF=@INVENTORYTOLERANCCNT , INVENTORYTLRNCPRICERF=@INVENTORYTLRNCPRICE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE ", sqlConnection, sqlTransaction); // ADD 2009/12/03
                        // 修正 2008/09/19 <<<

                        //Parameterオブジェクトの作成(検索用)
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameterオブジェクトへ値設定(検索用)
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        // ADD 2008/09/19 >>>
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float);
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        // ADD 2008/09/19 <<<

                        // -- UPD 2009/09/14 ----------------------->>>
                        //// ADD 2009/06/12 >>>
                        ////SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        //SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.Int);
                        //// ADD 2009/06/12 <<<
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        // -- UPD 2009/09/14 -----------------------<<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataUpdateWork.LastInventoryUpdate);

                        // ADD 2008/09/19 >>>　
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.StockTotalExec);
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.ToleranceUpdateCd);
                        // ADD 2008/09/18 <<<

                        // ADD 2009/06/12 >>>
                        //paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataUpdateWork.InventoryTolerancCnt);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataUpdateWork.InventoryTlrncPrice);
                        // ADD 2009/06/12 <<<
                        #endregion


                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
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

            inventoryExcDefUpdateWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 棚卸過不足更新情報を論理削除します
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int LogicalDelete(ref object inventoryExcDefUpdateWork)
        {
            return LogicalDeleteInventoryExcDefUpdate(ref inventoryExcDefUpdateWork, 0);
        }

        /// <summary>
        /// 論理削除棚卸過不足更新情報を復活します
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除棚卸過不足更新情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int RevivalLogicalDelete(ref object inventoryExcDefUpdateWork)
        {
            return LogicalDeleteInventoryExcDefUpdate(ref inventoryExcDefUpdateWork, 1);
        }

        /// <summary>
        /// 棚卸過不足更新情報の論理削除を操作します
        /// </summary>
        /// <param name="inventoryExcDefUpdateWork">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        private int LogicalDeleteInventoryExcDefUpdate(ref object inventoryExcDefUpdateWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = inventoryExcDefUpdateWork as ArrayList; //CastToArrayListFromPara(inventoryExcDefUpdateWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteInventoryExcDefUpdateProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.LogicalDeleteInventoryExcDefUpdate :" + procModestr);

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
        /// 棚卸過不足更新情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int LogicalDeleteInventoryExcDefUpdateProc(ref ArrayList inventoryExcDefUpdateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteInventoryExcDefUpdateProcProc(ref inventoryExcDefUpdateWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 棚卸過不足更新情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryExcDefUpdateWorkList">InventoryExcDefUpdateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸過不足更新情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
        private int LogicalDeleteInventoryExcDefUpdateProcProc( ref ArrayList inventoryExcDefUpdateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (inventoryExcDefUpdateWorkList != null)
                {
                    for (int i = 0; i < inventoryExcDefUpdateWorkList.Count; i++)
                    {
                        InventoryDataUpdateWork inventoryDataUpdateWork = inventoryExcDefUpdateWorkList[i] as InventoryDataUpdateWork;

                        //Selectコマンドの生成
                        //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            //sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO"; // DEL 2009/12/03
                            sqlCommand.CommandText = "UPDATE INVENTORYDATARF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE"; // ADD 2009/12/03
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                            findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inventoryDataUpdateWork;
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
                            else if (logicalDelCd == 0) inventoryDataUpdateWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else inventoryDataUpdateWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) inventoryDataUpdateWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataUpdateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inventoryDataUpdateWork);
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

            inventoryExcDefUpdateWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 棚卸過不足更新情報を物理削除します
        /// </summary>
        /// <param name="paraobj">棚卸過不足更新情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 棚卸過不足更新情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = paraobj as ArrayList;//CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteInventoryExcDefUpdateProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "InventoryExcDefUpdateDB.Delete");
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
        /// 棚卸過不足更新情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">棚卸過不足更新情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 棚卸過不足更新情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        public int DeleteInventoryExcDefUpdateProc(ArrayList inventoryexcdefupdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteInventoryExcDefUpdateProcProc(inventoryexcdefupdateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 棚卸過不足更新情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="inventoryexcdefupdateWorkList">棚卸過不足更新情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 棚卸過不足更新情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             棚卸データのPrimary Keyに倉庫コードを追加する</br>
        private int DeleteInventoryExcDefUpdateProcProc( ArrayList inventoryexcdefupdateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < inventoryexcdefupdateWorkList.Count; i++)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = inventoryexcdefupdateWorkList[i] as InventoryDataUpdateWork;
                    //sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO", sqlConnection, sqlTransaction); // DEL 2009/12/03
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction); // ADD 2009/12/03

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventorySeqNo = sqlCommand.Parameters.Add("@FINDINVENTORYSEQNO", SqlDbType.Int);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar); // ADD 2009/12/03

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                    findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != inventoryDataUpdateWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        //sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO"; // DEL 2009/12/03
                        sqlCommand.CommandText = "DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYSEQNORF=@FINDINVENTORYSEQNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE"; // ADD 2009/12/03
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);
                        findParaInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataUpdateWork.InventorySeqNo);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.WarehouseCode); // ADD 2009/12/03
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
        /// <param name="inventoryExcDefUpdateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryDataUpdateWork inventoryExcDefUpdateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");

            //企業コード
            retstring.Append("ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExcDefUpdateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring.ToString();
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → InventoryExcDefUpdateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>InventoryExcDefUpdateWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// </remarks>
        private InventoryDataUpdateWork CopyToInventoryExcDefUpdateWorkFromReader(ref SqlDataReader myReader)
        {
            InventoryDataUpdateWork wkInventoryDataUpdateWork = new InventoryDataUpdateWork();

            #region クラスへ格納
            // 修正 2008/09/19 レイアウト変更による修正 >>>
            #region 修正前
            /*
            wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkInventoryDataUpdateWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
            wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkInventoryDataUpdateWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkInventoryDataUpdateWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkInventoryDataUpdateWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkInventoryDataUpdateWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            wkInventoryDataUpdateWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkInventoryDataUpdateWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSNAMERF"));
            wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkInventoryDataUpdateWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkInventoryDataUpdateWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
            wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
            wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPCUSTOMERCODERF"));
            wkInventoryDataUpdateWork.ShipCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPCUSTOMERNAMERF"));
            wkInventoryDataUpdateWork.ShipCustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPCUSTOMERNAME2RF"));
            wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
            wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
            wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
            wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
            wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
            wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYNEWDIVRF"));
            wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
            wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYSTOCKPRICERF"));
            wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYTLRNCPRICERF"));
            // 2008.03.07 Add >>>>>>>>
            wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
            wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALEXCRF"));
            wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOLERANCEUPDATECDRF"));
            // 2008.03.07 Add <<<<<<<<
            wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STATUSRF"));
            */
            #endregion
            wkInventoryDataUpdateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkInventoryDataUpdateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkInventoryDataUpdateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkInventoryDataUpdateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkInventoryDataUpdateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkInventoryDataUpdateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkInventoryDataUpdateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkInventoryDataUpdateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkInventoryDataUpdateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkInventoryDataUpdateWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
            wkInventoryDataUpdateWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkInventoryDataUpdateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkInventoryDataUpdateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkInventoryDataUpdateWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkInventoryDataUpdateWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkInventoryDataUpdateWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            wkInventoryDataUpdateWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkInventoryDataUpdateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkInventoryDataUpdateWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkInventoryDataUpdateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkInventoryDataUpdateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkInventoryDataUpdateWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkInventoryDataUpdateWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            wkInventoryDataUpdateWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
            wkInventoryDataUpdateWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkInventoryDataUpdateWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkInventoryDataUpdateWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));
            wkInventoryDataUpdateWork.ShipCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPCUSTOMERCODERF"));
            wkInventoryDataUpdateWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
            wkInventoryDataUpdateWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
            wkInventoryDataUpdateWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
            wkInventoryDataUpdateWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
            wkInventoryDataUpdateWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
            wkInventoryDataUpdateWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkInventoryDataUpdateWork.InventoryNewDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYNEWDIVRF"));
            wkInventoryDataUpdateWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
            wkInventoryDataUpdateWork.InventoryStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYSTOCKPRICERF"));
            wkInventoryDataUpdateWork.InventoryTlrncPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INVENTORYTLRNCPRICERF"));
            wkInventoryDataUpdateWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
            wkInventoryDataUpdateWork.StockTotalExec = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALEXECRF"));
            wkInventoryDataUpdateWork.ToleranceUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOLERANCEUPDATECDRF"));
            wkInventoryDataUpdateWork.Status = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STATUSRF"));
            // 修正 2008/09/19 <<<
            #endregion

            return wkInventoryDataUpdateWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="inventoryData">棚卸データ</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>InventoryExcDefUpdateWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromInventoryReader(InventoryDataUpdateWork inventoryData, ref SqlDataReader myReader)
        {
            StockWork wkStockWork = new StockWork();

            #region クラスへ格納
            // 修正 2008/09/19 レイアウト変更による修正 >>>
            #region 修正前
            /*
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //wkStockWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //wkStockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //wkStockWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkStockWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkStockWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkStockWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkStockWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            //wkStockWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            //wkStockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            */ 
            #endregion
            wkStockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //wkStockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            //wkStockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            //wkStockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            //wkStockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            //wkStockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //wkStockWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //wkStockWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            // 修正 2008/09/19 <<<

            #endregion

            return wkStockWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.07.17</br>
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

        #region 通番最終番号取得
        /// <summary>
        /// 棚卸準備データ内の通番最終番号を戻します
        /// </summary>
        /// <param name="MaxInventorySeqCount">通番最終番号</param>
        /// <param name="inventoryDataUpdateWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備データ内の通番最終番号を戻します</br>
        /// <br>Programmer : Yokokawa</br>
        /// <br>Date       : 2007.10.05</br>
        private int GetMaxInventorySeq(out int MaxInventorySeqCount, InventoryDataUpdateWork inventoryDataUpdateWork, ref SqlConnection sqlConnection /*, ref SqlTransaction sqlTrans*/)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            MaxInventorySeqCount = 0;
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection/*, sqlTrans*/))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataUpdateWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        MaxInventorySeqCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNO_MAX"));
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
                base.WriteErrorLog(ex, "InventoryDataUpdateDB.GetMaxInventorySeq Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion
    }
}
