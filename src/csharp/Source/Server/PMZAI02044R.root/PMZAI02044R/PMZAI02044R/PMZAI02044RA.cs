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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注残クリアDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注残クリアの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/16 呉元嘯</br>
    /// <br>Date       : 商品管理情報マスタの仕入先を参照するように変更</br>
    /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
    /// <br>Update Note: 2010/08/02 22018 鈴木 正臣</br>
    /// <br>           : 在庫マスタの発注残は仕入データ分を減算せずにゼロを固定でセットするよう変更</br>
    /// <br>Update Note: 2011/04/11 liyp</br>
    /// <br>           : 画面で仕入先を範囲指定しても全データの発注残がクリアされる不具合修正</br>
    /// </remarks>
    [Serializable]
    public class SalesOrderRemainClearDB : RemoteWithAppLockDB, ISalesOrderRemainClearDB
    {
        /// <summary>
        /// 発注残クリアDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        public SalesOrderRemainClearDB()
            :
            base("PMZAI02046D", "Broadleaf.Application.Remoting.ParamData.ExtrInfo_SalesOrderRemainClearWork", "SALESORDERREMAINCLEARRF")
        {
        }

        #region [SearchUpdate]
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。
        /// </summary>
        /// <param name="extrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの発注数を０で更新します。</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        public int SearchUpdate(object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                return SearchUpdateSalesOrderRemainClear(extrInfo_SalesOrderRemainClearWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
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
        /// 抽出条件に合致した在庫データの発注数を０で更新します。(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの発注数を
        /// ０で更新します。(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchUpdateSalesOrderRemainClear(object objExtrInfo_SalesOrderRemainClearWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // 発注残クリアデータを取得
            status = SearchSalesOrderRemainClearProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 在庫マスタ更新
                if (stockWorkList.Count > 0)
                {
                    // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                    Dictionary<string, string> wareList = new Dictionary<string, string>(); //倉庫リスト 

                    StockWork _stockWork = stockWorkList[0] as StockWork;
                    foreach (StockWork st in stockWorkList)
                    {
                        if (wareList.ContainsKey(st.WarehouseCode.Trim()) == false)
                        {
                            wareList.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                        }
                    }
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(_stockWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        infoList.Add(info);
                        if (st != 0) return st;
                    }
                    // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    StockDB stockDB = new StockDB();

                    status = stockDB.WriteStockProc(ref stockWorkList, ref sqlConnection, ref sqlTransaction);

                    // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    foreach (ShareCheckInfo info in infoList)
                    {
                        status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    }
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // コミット
                sqlTransaction.Commit();
            else
            {
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }


            return status;
        }
        #endregion  //Search

        #region [SearchStockMasterTblProc]
        /// <summary>
        /// 指定された条件の発注残クリアデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の発注残クリアデータを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        private int SearchSalesOrderRemainClearProc(out ArrayList stockWorkList, ExtrInfo_SalesOrderRemainClearWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF AS GOODS ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockMasterTblProc

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_SalesOrderRemainClearWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// <br>Update Note: 2009/12/16 呉元嘯</br>
        /// <br>Date       : 商品管理情報マスタの仕入先を参照するように変更</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            //開始倉庫コード
            if (extrInfo_SalesOrderRemainClearWork.St_WarehouseCode != "")
            {
                retString.Append("AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE ");
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.St_WarehouseCode);
            }

            //終了倉庫コード
            if (extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode != "9999")
            {
                //retString.Append("AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)");
                //SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                //paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode + "%");
                retString.Append("AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE ");
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode);
            }

            //開始仕入先コード
            if (extrInfo_SalesOrderRemainClearWork.St_SupplierCd != 0)
            {
                // ---------DEL 2009/12/16---------->>>>>
                //retString.Append("AND STOCK.STOCKSUPPLIERCODERF>=@STSUPPLIERCD ");
                //SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                //paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_SupplierCd);
                // ---------DEL 2009/12/16----------<<<<<
            }

            //終了仕入先コード
            if (extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd != 999999)
            {
                // ---------DEL 2009/12/16---------->>>>>
                //retString.Append("AND STOCK.STOCKSUPPLIERCODERF<=@EDSUPPLIERCD ");
                //SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                //paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd);
                // ---------DEL 2009/12/16----------<<<<<
            }

            //開始メーカーコード
            if (extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd != 0)
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD ");
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd);
            }

            //終了メーカーコード
            // --- UPD m.suzuki 2010/08/02 ---------->>>>>
            //if (extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 9999)
            if ( extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 9999 && extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd != 0 )
            // --- UPD m.suzuki 2010/08/02 ----------<<<<<
            {
                retString.Append("AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD ");
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd);
            }

            //開始BL商品コード
            if (extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode != 0)
            {
                retString.Append("AND GOODS.BLGOODSCODERF>=@STBLGOODSCODE ");
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode);
            }
        
            //終了BL商品コード
            // --- UPD m.suzuki 2010/08/02 ---------->>>>>
            //if (extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 99999)
            if ( extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 99999 && extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode != 0 )
            // --- UPD m.suzuki 2010/08/02 ----------<<<<<
            {
                retString.Append("AND GOODS.BLGOODSCODERF<=@EDBLGOODSCODE ");
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode);
            }

            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>StockWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, ExtrInfo_SalesOrderRemainClearWork paramWork)
        {
            StockWork wkStockWork = new StockWork();

            if (myReader != null)
            {
                # region クラスへ格納
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
                wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                wkStockWork.SalesOrderCount = 0;
                wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                # endregion
            }

            return wkStockWork;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
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
        #endregion  //コネクション生成処理

        // ----------------ADD 2009/12/16--------------->>>>>
        #region[Search]
        /// <summary>
        /// 抽出条件に合致した在庫データの取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの取得を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        public int Search(out object rsultList, object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateSalesOrderRemain(extrInfo_SalesOrderRemainClearWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 抽出条件に合致した在庫データの取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの取得を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private int SearchUpdateSalesOrderRemain(object objExtrInfo_SalesOrderRemainClearWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // 発注残クリアデータを取得
            status = SearchSalesOrderRemainClearProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。。
        /// </summary>
        /// <remarks>
        /// <param name="resultList">resultList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの発注数を０で更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// <br>Update Note: 2010/06/08 高峰 障害・改良対応（７月リリース案件）</br>
        /// </remarks>
        // ----------------UPD 2010/06/08--------------->>>>>
        //public int Update(object resultList)
        public int Update(object resultList, object stockDetailWork)
        // ----------------UPD 2010/06/08---------------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList al = resultList as ArrayList;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = this.UpdateProc(al, ref sqlConnection, ref sqlTransaction);

                // ----------------ADD 2010/06/08--------------->>>>>
                IOWriteMASIRDB ioWrite = new IOWriteMASIRDB();
                StockDetailWork stockDetailWk = stockDetailWork as StockDetailWork;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = ioWrite.UpdateStockDetail(ref stockDetailWk, ref sqlConnection, ref sqlTransaction);
                }
                // ----------------ADD 2010/06/08---------------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        
        // -----------------ADD 2011/04/11 --------------------->>>>>
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。。
        /// </summary>
        /// <remarks>
        /// <param name="resultList">resultList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの発注数を０で更新します。</br>
        /// <br>Programmer : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        public int Update(object resultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList al = resultList as ArrayList;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                status = this.UpdateProc(al, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        // -----------------ADD 2011/04/11 ---------------------<<<<<
        
        /// <summary>
        /// 抽出条件に合致した在庫データの発注数を０で更新します。。
        /// </summary>
        /// <remarks>
        /// <param name="resultList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫データの発注数を０で更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.16</br>
        /// </remarks>
        private int UpdateProc(ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // システムロック(倉庫)
            ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
            Dictionary<string, string> wareList = new Dictionary<string, string>(); //倉庫リスト 
            StockWork _stockWork = resultList[0] as StockWork;
            foreach (StockWork st in resultList)
            {
                if (wareList.ContainsKey(st.WarehouseCode.Trim()) == false)
                {
                    wareList.Add(st.WarehouseCode.Trim(), st.WarehouseCode.Trim());
                }
            }
            foreach (string wCode in wareList.Keys)
            {
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(_stockWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                infoList.Add(info);
                if (st != 0) return st;
            }
            // システムロック(倉庫)

            StockDB stockDB = new StockDB();

            status = stockDB.WriteStockProc(ref resultList, ref sqlConnection, ref sqlTransaction);

            // システムロック解除(倉庫)
            foreach (ShareCheckInfo info in infoList)
            {
                status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
            }
            // システムロック解除(倉庫) 

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // コミット
                sqlTransaction.Commit();
            }
            else
            {
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            return status;
        }
        #endregion
        // ----------------ADD 2009/12/16---------------<<<<<

        // ----------------ADD 2010/06/08--------------->>>>>
        #region[SearchStockDetail]
        /// <summary>
        /// 仕入明細データから対象明細の取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した仕入明細データの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int SearchStockDetail(out object rsultList, object extrInfo_SalesOrderRemainClearWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateStockDetail(extrInfo_SalesOrderRemainClearWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion

        #region[SearchStock]
        /// <summary>
        /// 在庫マスタデータから対象明細の取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した在庫マスタデータの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public int SearchStock(out object rsultList, object extrInfo_StockDetailWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            rsultList = null;
            try
            {
                ArrayList list = new ArrayList();
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchUpdateStock(extrInfo_StockDetailWork, out list, ref sqlConnection, ref sqlTransaction);

                rsultList = list;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesOrderRemainClearDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion

        /// <summary>
        /// 抽出条件に合致した仕入明細データの取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した仕入明細データの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchUpdateStockDetail(object objExtrInfo_SalesOrderRemainClearWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            ExtrInfo_SalesOrderRemainClearWork paramWork = null;

            ArrayList paramWorkList = objExtrInfo_SalesOrderRemainClearWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = objExtrInfo_SalesOrderRemainClearWork as ExtrInfo_SalesOrderRemainClearWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as ExtrInfo_SalesOrderRemainClearWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // 発注残クリアデータを取得
            status = SearchStockDetailProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }

        /// <summary>
        /// 抽出条件に合致した仕入明細データの取得
        /// </summary>
        /// <remarks>
        /// <param name="objExtrInfo_SalesOrderRemainClearWork">検索パラメータ</param>
        /// <param name="resultList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 抽出条件に合致した仕入明細データの取得を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private int SearchUpdateStock(object extrInfo_StockDetailWork, out ArrayList resultList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            StockDetailWork paramWork = null;

            ArrayList paramWorkList = extrInfo_StockDetailWork as ArrayList;
            resultList = new ArrayList();

            if (paramWorkList == null)
            {
                paramWork = extrInfo_StockDetailWork as StockDetailWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as StockDetailWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList stockWorkList = new ArrayList();


            // 発注残クリアデータを取得
            status = SearchStockProc(out stockWorkList, paramWork, ref sqlConnection, ref sqlTransaction);
            resultList = stockWorkList;
            return status;
        }

        #region [SearchStockDetailProc]
        /// <summary>
        /// 指定された条件の仕入明細発注残クリアデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の仕入明細発注残クリアデータを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        private int SearchStockDetailProc(out ArrayList stockWorkList, ExtrInfo_SalesOrderRemainClearWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCKDETAIL.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKROWNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERFORMALSRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKINPUTCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKINPUTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKAGENTCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKAGENTNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.MAKERKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.CMPLTMAKERKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.GOODSRATERANKRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.CUSTRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATESECTSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEDIVSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.PRICECDSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.FRACPROCSTCKUNPRCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKUNITCHNGDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.BFLISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEGOODSRATEGRPCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEGOODSRATEGRPNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.RATEBLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERADJUSTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERREMAINCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.REMAINCNTUPDDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICETAXINCRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKGOODSCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.TAXATIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESCUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SLIPMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.INSIDEMEMO3RF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.DIRECTSENDINGCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERNUMBERRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.WAYTOORDERRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.EXPECTDELIVERYDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERDATACREATEDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERDATACREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCKDETAIL.ORDERFORMISSUEDDIVRF" + Environment.NewLine;
                selectTxt += "FROM STOCKDETAILRF AS STOCKDETAIL" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeStockDetailWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockDetailWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockDetailProc

        #region [SearchStockMasterTblProc]
        /// <summary>
        /// 指定された条件の在庫発注残クリアデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫発注残クリアデータを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        private int SearchStockProc(out ArrayList stockWorkList, StockDetailWork paramWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                //selectTxt += " LEFT JOIN GOODSURF AS GOODS ON STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText = selectTxt;

                sqlCommand.CommandText += MakeStockWhereString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockWorkFromReader(ref myReader, paramWork));
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

            stockWorkList = al;

            return status;
        }
        #endregion  //SearchStockMasterTblProc

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_SalesOrderRemainClearWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        private string MakeStockDetailWhereString(ref SqlCommand sqlCommand, ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCKDETAIL.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND STOCKDETAIL.LOGICALDELETECODERF=0 ");

            //仕入形式
            retString.Append("AND STOCKDETAIL.SUPPLIERFORMALRF=2 ");

            //開始倉庫コード
            if (extrInfo_SalesOrderRemainClearWork.St_WarehouseCode != "")
            {
                retString.Append("AND STOCKDETAIL.WAREHOUSECODERF>=@STWAREHOUSECODE ");
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.St_WarehouseCode);
            }

            //終了倉庫コード
            if (extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode != "9999")
            {
                retString.Append("AND STOCKDETAIL.WAREHOUSECODERF<=@EDWAREHOUSECODE ");
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode);
            }

            //発注残数
            retString.Append("AND STOCKDETAIL.ORDERREMAINCNTRF<>0 ");

            //開始仕入先コード
            if (extrInfo_SalesOrderRemainClearWork.St_SupplierCd != 0)
            {
                retString.Append("AND STOCKDETAIL.SUPPLIERCDRF>=@STSUPPLIERCD ");
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.St_SupplierCd);
            }

            //終了仕入先コード
            if (extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd != 999999)
            {
                retString.Append("AND STOCKDETAIL.SUPPLIERCDRF<=@EDSUPPLIERCD ");
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd);
            }

            //注文方法
            retString.Append("AND (STOCKDETAIL.WAYTOORDERRF=0 OR STOCKDETAIL.WAYTOORDERRF=1)");

            return retString.ToString();
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="extrInfo_StockDetailWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        private string MakeStockWhereString(ref SqlCommand sqlCommand, StockDetailWork extrInfo_StockDetailWork)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            retString.Append("STOCK.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.EnterpriseCode);

            //論理削除区分
            retString.Append("AND STOCK.LOGICALDELETECODERF=0 ");

            //倉庫コード
            retString.Append("AND STOCK.WAREHOUSECODERF=@WAREHOUSECODE ");
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.WarehouseCode);

            //商品メーカーコード
            retString.Append("AND STOCK.GOODSMAKERCDRF=@GOODSMAKERCD ");
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(extrInfo_StockDetailWork.GoodsMakerCd);

            //商品番号
            retString.Append("AND STOCK.GOODSNORF=@GOODSNO ");
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(extrInfo_StockDetailWork.GoodsNo);

            return retString.ToString();
        }
        # endregion

        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>StockWork オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ExtrInfo_SalesOrderRemainClearWork paramWork)
        {
            StockDetailWork wkStockDetailWork = new StockDetailWork();
            

            if (myReader != null)
            {

                # region クラスへ格納
                wkStockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AcceptAnOrderNoRF"));
                wkStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierFormalRF"));
                wkStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierSlipNoRF"));
                wkStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockRowNoRF"));
                wkStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SectionCodeRF"));
                wkStockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SubSectionCodeRF"));
                wkStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CommonSeqNoRF"));
                wkStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockSlipDtlNumRF"));
                wkStockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierFormalSrcRF"));
                wkStockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockSlipDtlNumSrcRF"));
                wkStockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AcptAnOdrStatusSyncRF"));
                wkStockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("SalesSlipDtlNumSyncRF"));
                wkStockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockSlipCdDtlRF"));
                wkStockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockInputCodeRF"));
                wkStockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockInputNameRF"));
                wkStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockAgentCodeRF"));
                wkStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockAgentNameRF"));
                wkStockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsKindCodeRF"));
                wkStockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsMakerCdRF"));
                wkStockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MakerNameRF"));
                wkStockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MakerKanaNameRF"));
                wkStockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CmpltMakerKanaNameRF"));
                wkStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNoRF"));
                wkStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNameRF"));
                wkStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsNameKanaRF"));
                wkStockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsLGroupRF"));
                wkStockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsLGroupNameRF"));
                wkStockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("GoodsMGroupRF"));
                wkStockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsMGroupNameRF"));
                wkStockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BLGroupCodeRF"));
                wkStockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BLGroupNameRF"));
                wkStockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("BLGoodsCodeRF"));
                wkStockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("BLGoodsFullNameRF"));
                wkStockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("EnterpriseGanreCodeRF"));
                wkStockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("EnterpriseGanreNameRF"));
                wkStockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseCodeRF"));
                wkStockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseNameRF"));
                wkStockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("WarehouseShelfNoRF"));
                wkStockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockOrderDivCdRF"));
                wkStockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OpenPriceDivRF"));
                wkStockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GoodsRateRankRF"));
                wkStockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CustRateGrpCodeRF"));
                wkStockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SuppRateGrpCodeRF"));
                wkStockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("ListPriceTaxExcFlRF"));
                wkStockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("ListPriceTaxIncFlRF"));
                wkStockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockRateRF"));
                wkStockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateSectStckUnPrcRF"));
                wkStockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateDivStckUnPrcRF"));
                wkStockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UnPrcCalcCdStckUnPrcRF"));
                wkStockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("PriceCdStckUnPrcRF"));
                wkStockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StdUnPrcStckUnPrcRF"));
                wkStockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("FracProcUnitStcUnPrcRF"));
                wkStockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FracProcStckUnPrcRF"));
                wkStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockUnitPriceFlRF"));
                wkStockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockUnitTaxPriceFlRF"));
                wkStockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockUnitChngDivRF"));
                wkStockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("BfStockUnitPriceFlRF"));
                wkStockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("BfListPriceRF"));
                wkStockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateBLGoodsCodeRF"));
                wkStockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateBLGoodsNameRF"));
                wkStockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateGoodsRateGrpCdRF"));
                wkStockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateGoodsRateGrpNmRF"));
                wkStockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("RateBLGroupCodeRF"));
                wkStockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RateBLGroupNameRF"));
                wkStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("StockCountRF"));
                wkStockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("OrderCntRF"));
                wkStockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("OrderAdjustCntRF"));
                wkStockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("OrderRemainCntRF"));
                wkStockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RemainCntUpdDateRF"));
                wkStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceTaxExcRF"));
                wkStockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceTaxIncRF"));
                wkStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("StockGoodsCdRF"));
                wkStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("StockPriceConsTaxRF"));
                wkStockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("TaxationCodeRF"));
                wkStockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("StockDtiSlipNote1RF"));
                wkStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SalesCustomerCodeRF"));
                wkStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SalesCustomerSnmRF"));
                wkStockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo1RF"));
                wkStockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo2RF"));
                wkStockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SlipMemo3RF"));
                wkStockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo1RF"));
                wkStockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo2RF"));
                wkStockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("InsideMemo3RF"));
                wkStockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SupplierCdRF"));
                wkStockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SupplierSnmRF"));
                wkStockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AddresseeCodeRF"));
                wkStockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("AddresseeNameRF"));
                wkStockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DirectSendingCdRF"));
                wkStockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OrderNumberRF"));
                wkStockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("WayToOrderRF"));
                wkStockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DeliGdsCmpltDueDateRF"));
                wkStockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ExpectDeliveryDateRF"));
                wkStockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OrderDataCreateDivRF"));
                wkStockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OrderDataCreateDateRF"));
                wkStockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("OrderFormIssuedDivRF"));
                # endregion
            }

            return wkStockDetailWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>StockWork オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromReader(ref SqlDataReader myReader, StockDetailWork paramWork)
        {
            StockWork wkStockWork = new StockWork();

            if (myReader != null)
            {
                # region クラスへ格納
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
                wkStockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                wkStockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                wkStockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                wkStockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF")) - paramWork.OrderRemainCnt;
                wkStockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                wkStockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                wkStockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                wkStockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                wkStockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                wkStockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                wkStockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                wkStockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                wkStockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                wkStockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                wkStockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                wkStockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                wkStockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                wkStockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                wkStockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                wkStockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                wkStockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                wkStockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                wkStockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkStockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                wkStockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                wkStockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                # endregion
            }

            return wkStockWork;
        }

        // ----------------ADD 2010/06/08---------------<<<<<
        // --- ADD m.suzuki 2010/08/02 ---------->>>>>
        /// <summary>
        /// 仕入明細更新処理（仕入データのみ更新する）
        /// </summary>
        /// <param name="stockDetailWork"></param>
        /// <returns></returns>
        public int UpdateStockDetail( object stockDetailWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if ( sqlConnection == null ) return status;
                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );

                IOWriteMASIRDB ioWrite = new IOWriteMASIRDB();
                StockDetailWork stockDetailWk = stockDetailWork as StockDetailWork;

                status = ioWrite.UpdateStockDetail( ref stockDetailWk, ref sqlConnection, ref sqlTransaction );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SalesOrderRemainClearDB.UpdateStockDetail" );
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( sqlTransaction != null )
                {
                    if ( sqlTransaction.Connection != null )
                    {
                        sqlTransaction.Commit();
                    }
                    sqlTransaction.Dispose();
                }
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        // --- ADD m.suzuki 2010/08/02 ----------<<<<<
    }

}
