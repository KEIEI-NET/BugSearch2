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
    /// 在庫組立・分解処理  リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫組立・分解処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class StckAssemOvhulDB : RemoteDB, IStckAssemOvhulDB
    {
        /// <summary>
        /// 在庫組立・分解処理  リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        public StckAssemOvhulDB()
            :
            base("PMZAI04026D", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork", "GOODSSETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の在庫組立・分解処理LISTを戻します
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">検索結果</param>
        /// <param name="paraStckAssemOvhulReqWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫組立・分解処理LISTを戻します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        public int Search(out object paraStckAssemOvhulRstWork, object paraStckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            paraStckAssemOvhulRstWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStckAssemOvhul(out paraStckAssemOvhulRstWork, paraStckAssemOvhulReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StckAssemOvhulDB.Search");
                paraStckAssemOvhulRstWork = new ArrayList();
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
        #endregion  //[Search]

        #region [SearchStckAssemOvhul]
        /// <summary>
        /// 指定された条件の在庫組立・分解処理LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">検索結果</param>
        /// <param name="paraStckAssemOvhulReqWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫組立・分解処理LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        public int SearchStckAssemOvhul(out object paraStckAssemOvhulRstWork, object paraStckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            StckAssemOvhulReqWork stckAssemOvhulReqWork = null;

            ArrayList stckAssemOvhulReqWorkList = paraStckAssemOvhulReqWork as ArrayList;
            ArrayList stckAssemOvhulRstWorkList = new ArrayList();

            if (stckAssemOvhulReqWorkList == null)
            {
                stckAssemOvhulReqWork = paraStckAssemOvhulReqWork as StckAssemOvhulReqWork;
            }
            else
            {
                if (stckAssemOvhulReqWorkList.Count > 0)
                    stckAssemOvhulReqWork = stckAssemOvhulReqWorkList[0] as StckAssemOvhulReqWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //検索実行
                status = SearchProc(ref stckAssemOvhulRstWorkList, stckAssemOvhulReqWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StckAssemOvhulDB.SearchStckAssemOvhul Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            paraStckAssemOvhulRstWork = stckAssemOvhulRstWorkList;

            return status;
        }
        #endregion  //[SearchStckAssemOvhul]

        #region [SearchProc]
        /// <summary>
        /// 指定された条件の在庫組立・分解処理LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stckAssemOvhulRstWorkList">検索結果</param>
        /// <param name="stckAssemOvhulReqWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫組立・分解処理LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        private int SearchProc(ref ArrayList stckAssemOvhulRstWorkList, StckAssemOvhulReqWork stckAssemOvhulReqWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // GOODSSETRF   GOODSS 商品セットマスタ
                // STOCKRF      STOCKP 在庫マスタ ※親商品情報
                // STOCKRF      STOCKS 在庫マスタ ※子商品情報
                // SECINFOSETRF SECINF 拠点情報設定マスタ
                // WAREHOUSERF  WARHUS 倉庫マスタ
                // MAKERURF     MAKERU メーカーマスタ(ユーザー)
                // GOODSURF     GOODSUP 商品マスタ(ユーザー) ※親商品情報
                // GOODSURF     GOODSUS 商品マスタ(ユーザー) ※子商品情報

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  STOCKP.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STOCKP.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AS PARENTGOODSNO" + Environment.NewLine;
                selectTxt += " ,GOODSUP.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  AS PARENTGOODSNAMEKANA" + Environment.NewLine;
                selectTxt += " ,GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "  AS PARENTMAKERSHORTNAME" + Environment.NewLine;
                selectTxt += " ,STOCKP.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AS PARENTWAREHOUSECODE" + Environment.NewLine;
                selectTxt += " ,WARHUS.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  AS PARENTWAREHOUSENAME" + Environment.NewLine;
                selectTxt += " ,STOCKP.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  AS PARENTSUPPLIERSTOCK" + Environment.NewLine;
                selectTxt += " ,STOCKP.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  AS PARENTMAXIMUMSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,STOCKP.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  AS PARENTMINIMUMSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,GOODSS.DISPLAYORDERRF" + Environment.NewLine;
                selectTxt += " ,GOODSS.SUBGOODSNORF" + Environment.NewLine;
                selectTxt += " ,GOODSUS.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  AS SUBGOODSNAMEKANA" + Environment.NewLine;
                selectTxt += " ,GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,GOODSS.CNTFLRF" + Environment.NewLine;
                selectTxt += " ,GOODSUS.OFFERDATADIVRF" + Environment.NewLine;
                selectTxt += " ,STOCKS.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  AS SUBSUPPLIERSTOCK" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD1RF" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD2RF" + Environment.NewLine;
                selectTxt += " ,SECINF.SECTWAREHOUSECD3RF" + Environment.NewLine;
                selectTxt += " FROM GOODSSETRF AS GOODSS" + Environment.NewLine;

                #region [JOIN]
                //在庫マスタ ※親商品情報
                selectTxt += " LEFT JOIN STOCKRF STOCKP" + Environment.NewLine;
                selectTxt += " ON  STOCKP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCKP.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCKP.GOODSNORF=GOODSS.PARENTGOODSNORF" + Environment.NewLine;

                //拠点情報設定マスタ
                selectTxt += " LEFT JOIN SECINFOSETRF SECINF" + Environment.NewLine;
                selectTxt += " ON  SECINF.ENTERPRISECODERF=STOCKP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SECINF.SECTIONCODERF=STOCKP.SECTIONCODERF" + Environment.NewLine;

                //倉庫マスタ
                selectTxt += " LEFT JOIN WAREHOUSERF WARHUS" + Environment.NewLine;
                selectTxt += " ON  WARHUS.ENTERPRISECODERF=STOCKP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARHUS.WAREHOUSECODERF=STOCKP.WAREHOUSECODERF" + Environment.NewLine;

                //在庫マスタ ※子商品情報
                selectTxt += " LEFT JOIN STOCKRF STOCKS" + Environment.NewLine;
                selectTxt += " ON  STOCKS.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCKS.GOODSMAKERCDRF=GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCKS.GOODSNORF=GOODSS.SUBGOODSNORF" + Environment.NewLine;

                //MAKERU メーカーマスタ(ユーザー)
                selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;

                //商品マスタ(ユーザー) ※親商品情報
                selectTxt += " LEFT JOIN GOODSURF GOODSUP" + Environment.NewLine;
                selectTxt += " ON  GOODSUP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSUP.GOODSMAKERCDRF=GOODSS.PARENTGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSUP.GOODSNORF=GOODSS.PARENTGOODSNORF" + Environment.NewLine;

                //商品マスタ(ユーザー) ※子商品情報
                selectTxt += " LEFT JOIN GOODSURF GOODSUS" + Environment.NewLine;
                selectTxt += " ON  GOODSUS.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSUS.GOODSMAKERCDRF=GOODSS.SUBGOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSUS.GOODSNORF=GOODSS.SUBGOODSNORF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE]
                selectTxt += " WHERE" + Environment.NewLine;

                //企業コード
                selectTxt += " GOODSS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stckAssemOvhulReqWork.EnterpriseCode);

                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND STOCKP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND STOCKP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //拠点コード
                if (stckAssemOvhulReqWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in stckAssemOvhulReqWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND STOCKP.SECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //商品番号
                if (stckAssemOvhulReqWork.GoodsNo != "")
                {
                    selectTxt += " AND GOODSS.PARENTGOODSNORF LIKE @FINDPARENTGOODSNO";
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(stckAssemOvhulReqWork.GoodsNo + "%");
                }

                //拠点倉庫コード
                selectTxt += " AND (" + Environment.NewLine;
                selectTxt += "         STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD1RF" + Environment.NewLine;
                selectTxt += "      OR STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD2RF" + Environment.NewLine;
                selectTxt += "      OR STOCKP.WAREHOUSECODERF=SECINF.SECTWAREHOUSECD3RF" + Environment.NewLine;
                selectTxt += "     )" + Environment.NewLine;
                #endregion  //[WHERE]

                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stckAssemOvhulRstWorkList.Add(CopyToStckAssemOvhulRstWorkFromReader(ref myReader, stckAssemOvhulReqWork));
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
                base.WriteErrorLog(ex, "StckAssemOvhulDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion //[SearchProc]

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StckAssemOvhulRstWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stckAssemOvhulReqWork">検索条件</param>
        /// <returns>StckAssemOvhulRstWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        private StckAssemOvhulRstWork CopyToStckAssemOvhulRstWorkFromReader(ref SqlDataReader myReader, StckAssemOvhulReqWork stckAssemOvhulReqWork)
        {
            StckAssemOvhulRstWork ResultWork = new StckAssemOvhulRstWork();

            #region クラスへ格納
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNO"));
            ResultWork.ParentGoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNAMEKANA"));
            ResultWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
            ResultWork.ParentMakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTMAKERSHORTNAME"));
            ResultWork.ParentWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTWAREHOUSECODE"));
            ResultWork.ParentWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTWAREHOUSENAME"));
            ResultWork.ParentSupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTSUPPLIERSTOCK"));
            ResultWork.ParentMaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTMAXIMUMSTOCKCNT"));
            ResultWork.ParentMinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARENTMINIMUMSTOCKCNT"));
            ResultWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            ResultWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
            ResultWork.SubGoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNAMEKANA"));
            ResultWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
            ResultWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
            ResultWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            ResultWork.SubSupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUBSUPPLIERSTOCK"));
            ResultWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD1RF"));
            ResultWork.SectWarehouseCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD2RF"));
            ResultWork.SectWarehouseCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTWAREHOUSECD3RF"));
            #endregion  //クラスへ格納

            return ResultWork;
        }
        #endregion  //[クラス格納処理]

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.10.06</br>
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
        #endregion  //[コネクション生成処理]
    }
}
