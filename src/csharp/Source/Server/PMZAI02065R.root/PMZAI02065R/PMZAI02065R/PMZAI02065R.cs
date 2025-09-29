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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 委託在庫補充処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 委託在庫補充処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: 委託在庫補充処理の障害修正</br>
    /// <br>             施ヘイ中</br>          
    /// <br>Data: 2010/12/03</br>  
    /// <br>Update Note: 2012/09/06 李亜博</br>
    /// <br>           : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
    /// <br>           : ①委託在庫補充処理にで論理削除していた倉庫データが処理対象外に改修します</br>
    /// <br>             ②補充元商品無し時「無視して更新」の区分を選択して実行時、補充元の在庫マスタが新規作成される。</br>
    /// </remarks>
    [Serializable]
    public class TrustStockOrderWorkDB : RemoteDB, ITrustStockOrderWorkDB
    {
        /// <summary>
        /// 委託在庫補充処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public TrustStockOrderWorkDB()
            :
        base("PMZAI02065", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork", "WAREHOUSERF") //基底クラスのコンストラクタ
        {
        }

        #region 委託在庫補充処理
        /// <summary>
        /// 指定された企業コードの委託在庫補充処理のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの委託在庫補充処理のLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(out object trustStockResultWork, object trustStockOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            trustStockResultWork = null;

            TrustStockOrderCndtnWork _trustStockOrderCndtnWork = trustStockOrderCndtnWork as TrustStockOrderCndtnWork;

            try
            {
                status = SearchProc(out trustStockResultWork, _trustStockOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TrustStockOrderWork.Search Exception=" + ex.Message);
                trustStockResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入委託在庫補充処理LISTを全て戻します
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="_supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの復旧一覧表LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        private int SearchProc(out object trustStockResultWork, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            trustStockResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _trustStockOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TrustStockOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            trustStockResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2012/09/06 李亜博</br>
        /// <br>           : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
        /// <br>           : ②補充元商品無し時「無視して更新」の区分を選択して実行時、補充元の在庫マスタが新規作成される。</br>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string Rep_GoodsNo;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	 STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSECODERF AS TRU_WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,WAR.WAREHOUSENAMERF AS TRU_WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,WAR.MAINMNGWAREHOUSECDRF AS REP_WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,CWAR.WAREHOUSENAMERF AS REP_WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += "        ,MAK.MAKERSHORTNAMERF" + Environment.NewLine;
                selectTxt += "        ,MAK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,GOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSESHELFNORF AS TRU_WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STO.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.SHIPMENTPOSCNTRF AS TRU_SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,(STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF) AS REPLENISHCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,RSTO.WAREHOUSESHELFNORF AS REP_WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,RSTO.SHIPMENTPOSCNTRF AS REP_SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,RSTO.GOODSNORF AS REPGOODSNORF" + Environment.NewLine;
                selectTxt += " FROM WAREHOUSERF AS WAR" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKRF AS STO" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	STO.ENTERPRISECODERF = WAR.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND STO.WAREHOUSECODERF = WAR.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOD" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	GOD.ENTERPRISECODERF = STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND GOD.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "	AND GOD.GOODSNORF = STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF MAK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	MAK.ENTERPRISECODERF = STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND MAK.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKRF AS RSTO" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  RSTO.ENTERPRISECODERF = WAR.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RSTO.WAREHOUSECODERF = WAR.MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                selectTxt += "  AND RSTO.GOODSNORF = STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND RSTO.GOODSMAKERCDRF = STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND RSTO.LOGICALDELETECODERF = 0" + Environment.NewLine;// ADD 2012/09/06 李亜博 for Redmine#32179 
                selectTxt += "LEFT JOIN WAREHOUSERF AS CWAR" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CWAR.ENTERPRISECODERF = RSTO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CWAR.WAREHOUSECODERF = RSTO.WAREHOUSECODERF" + Environment.NewLine;
                
                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _trustStockOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    TrustStockResultWork wkTrustStockResultWork = new TrustStockResultWork();
                    
                    //格納項目
                    wkTrustStockResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkTrustStockResultWork.Tru_WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSECODERF"));
                    wkTrustStockResultWork.Tru_WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSENAMERF"));
                    wkTrustStockResultWork.Rep_WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSECODERF"));
                    wkTrustStockResultWork.Rep_WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSENAMERF"));
                    wkTrustStockResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //wkTrustStockResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
                    wkTrustStockResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkTrustStockResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkTrustStockResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkTrustStockResultWork.Tru_WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRU_WAREHOUSESHELFNORF"));
                    wkTrustStockResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkTrustStockResultWork.Tru_ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TRU_SHIPMENTPOSCNTRF"));
                    if (_trustStockOrderCndtnWork.ReplenishLackStock == 2)
                    {
                        //wkTrustStockResultWork.ReplenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));//DEL 李亜博 2012/09/06 for Redmine#32179
                        //--- ADD 李亜博 2012/09/06 for Redmine#32179-------->>>>>
                        double repShipmentpOsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));
                        double repPlenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REPLENISHCOUNTRF"));
                        wkTrustStockResultWork.ReplenishCount = repShipmentpOsCnt <= repPlenishCount ? repShipmentpOsCnt : repPlenishCount;
                        //--- ADD 李亜博 2012/09/06 for Redmine#32179--------<<<<<
                    }
                    else
                    {
                        wkTrustStockResultWork.ReplenishCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REPLENISHCOUNTRF"));
                    }
                    wkTrustStockResultWork.Rep_WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REP_WAREHOUSESHELFNORF"));
                    wkTrustStockResultWork.Rep_ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("REP_SHIPMENTPOSCNTRF"));
                    wkTrustStockResultWork.ReplenishNStockCount = wkTrustStockResultWork.Rep_ShipmentPosCnt - wkTrustStockResultWork.ReplenishCount;
                    Rep_GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REPGOODSNORF"));
                    //if (Rep_GoodsNo == " ")// DEL 2012/09/06 李亜博 for Redmine#32179 
                    if (string.IsNullOrEmpty(Rep_GoodsNo))// ADD 2012/09/06 李亜博 for Redmine#32179 
                    {
                        wkTrustStockResultWork.GoodsFlg = 1;
                    }
                    #endregion

                    al.Add(wkTrustStockResultWork);

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
                base.WriteErrorLog(ex, "TrustStockOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Update Note: 委託在庫補充処理の障害修正</br>
        /// <br>             施ヘイ中</br>          
        /// <br>Data: 2010/12/03</br>  
        /// <br>Update Note: 2012/09/06 李亜博</br>
        /// <br>           : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
        /// <br>           : ①委託在庫補充処理にで論理削除していた倉庫データが処理対象外に改修します</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TrustStockOrderCndtnWork _trustStockOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // 主管倉庫コード
            retstring += "WAR.MAINMNGWAREHOUSECDRF != 0" + Environment.NewLine;

            // 最高在庫数 ≧ 最低在庫数
            retstring += " AND STO.MAXIMUMSTOCKCNTRF >= STO.MINIMUMSTOCKCNTRF" + Environment.NewLine;

            // 最高在庫数 ≧ 現在庫数
            retstring += " AND STO.MAXIMUMSTOCKCNTRF > STO.SHIPMENTPOSCNTRF" + Environment.NewLine;

            // 最高在庫数 = 最低在庫数 ≠ 0
            // --- UPD 2010/12/03------ >>>>>>
            // retstring += " AND ((STO.MAXIMUMSTOCKCNTRF != 0) AND (STO.MINIMUMSTOCKCNTRF != 0))" + Environment.NewLine;
            retstring += " AND ((STO.MAXIMUMSTOCKCNTRF != 0) OR (STO.MINIMUMSTOCKCNTRF != 0))" + Environment.NewLine;
            // --- UPD 2010/12/03----- <<<<<<<
            // 補充数 > 0
            //retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0) AND  ((STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF) > RSTO.SHIPMENTPOSCNTRF)";

            
            // 企業コード
            retstring += " AND STO.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.EnterpriseCode);
            

            // 倉庫コード
            if (_trustStockOrderCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND WAR.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.St_WarehouseCode);
            }
            if (_trustStockOrderCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND WAR.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.Ed_WarehouseCode);
            }


            // メーカー
            if (_trustStockOrderCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_trustStockOrderCndtnWork.St_GoodsMakerCd);
            }
            if (_trustStockOrderCndtnWork.Ed_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_trustStockOrderCndtnWork.Ed_GoodsMakerCd);
            }


            // 品番
            if (_trustStockOrderCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND GOD.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.St_GoodsNo);
            }
            if (_trustStockOrderCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND GOD.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_trustStockOrderCndtnWork.Ed_GoodsNo);
            }


            // 補充元在庫不足時
            if (_trustStockOrderCndtnWork.ReplenishLackStock == 0 && _trustStockOrderCndtnWork.ReplenishNoneGoods !=1)
            {
                retstring += " AND ((RSTO.GOODSNORF IS NOT NULL) AND (RSTO.SHIPMENTPOSCNTRF > (STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF)))";
            }
            else if (_trustStockOrderCndtnWork.ReplenishLackStock == 2)
            {
                //retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0) AND (RSTO.SHIPMENTPOSCNTRF <= (STO.MAXIMUMSTOCKCNTRF - STO.SHIPMENTPOSCNTRF))";//DEL 李亜博 2012/09/06 for Redmine#32179
                retstring += " AND (RSTO.SHIPMENTPOSCNTRF > 0)";//ADD 李亜博 2012/09/06 for Redmine#32179
            }

            // 補充元商品無し時
            if (_trustStockOrderCndtnWork.ReplenishNoneGoods == 0)
            {
                retstring += " AND (RSTO.GOODSNORF IS NOT NULL)";
            }
            //--- ADD 李亜博 2012/09/06 for Redmine#32179-------->>>>>
            //論理削除区分 = 0
            retstring += " AND WAR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE AND STO.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
            //--- ADD 李亜博 2012/09/06 for Redmine#32179--------<<<<<

            #endregion
            return retstring;
        }
    }
}
