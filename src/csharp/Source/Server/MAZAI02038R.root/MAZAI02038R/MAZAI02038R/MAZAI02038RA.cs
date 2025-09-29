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
    /// 在庫・倉庫移動確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫・倉庫移動確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 佐々木 健</br>
	/// <br>           : 商品コードの絞り込みを修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.07.07 20081</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// <br>Update Note: 2012/11/06 脇田 靖之</br>
    /// <br>           : 仕様変更対応（出庫追加）</br>
    /// <br>Update Note: 2013/01/05 cheq</br>
    /// <br>管理番号   : 10801804-00 2013/03/13配信分</br>
    /// <br>             Redmine#33828 発行タイプについての対応</br>
    /// </remarks>
    [Serializable]
    public class StockMoveListWorkDB : RemoteDB, IStockMoveListWorkDB
    {
        /// <summary>
        /// 在庫・倉庫移動確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        public StockMoveListWorkDB()
            :
        base("MAZAI02036D", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork", "STOCKMOVERF") //基底クラスのコンストラクタ
        {
        }

        #region 在庫移動確認表処理
        /// <summary>
        /// 指定された企業コードの在庫移動確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫移動確認表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        public int SearchStock(out object stockMoveListResultWork, object stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockMoveListResultWork = null;

            StockMoveListCndtnWork _stockMoveListCndtnWork = stockMoveListCndtnWork as StockMoveListCndtnWork;

            try
            {
                status = SearchStockProc(out stockMoveListResultWork, _stockMoveListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchStock Exception=" + ex.Message);
                stockMoveListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫移動確認表LISTを全て戻します
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="_stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫移動確認表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        private int SearchStockProc(out object stockMoveListResultWork, StockMoveListCndtnWork _stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;

            stockMoveListResultWork = null;

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

                ////●暗号化部品準備処理
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                ////暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                status = SearchNonGrossAction(ref al, ref sqlConnection, _stockMoveListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stockMoveListResultWork = al;

            return status;
        }
        #endregion

        #region 倉庫移動確認表処理
        /// <summary>
        /// 指定された企業コードの倉庫移動確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果</param>
        /// <param name="stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの倉庫移動確認表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        public int SearchEnterWareh(out object stockMoveListResultWork, object stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockMoveListResultWork = null;

            StockMoveListCndtnWork _stockMoveListCndtnWork = stockMoveListCndtnWork as StockMoveListCndtnWork;

            try
            {
                status = SearchEnterWarehProc(out stockMoveListResultWork, _stockMoveListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchEnterWareh Exception=" + ex.Message);
                stockMoveListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの倉庫移動確認表LISTを全て戻します
        /// </summary>
        /// <param name="stockMoveListResultWork">検索結果（入金）</param>
        /// <param name="depsitAlwcListResultWork">検索結果（引当）</param>
        /// <param name="_stockMoveListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの倉庫移動確認表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.11 長内 DC.NS用に修正</br>
        private int SearchEnterWarehProc(out object stockMoveListResultWork, StockMoveListCndtnWork _stockMoveListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;

            stockMoveListResultWork = null;

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

                //●暗号化部品準備処理
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                status = SearchNonGrossAction(ref al, ref sqlConnection, _stockMoveListCndtnWork, logicalMode);
            
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchEnterWarehProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    //if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            stockMoveListResultWork = al;

            return status;
        }
        #endregion

        #region 製番データ取得処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchNonGrossAction(ref ArrayList al, ref SqlConnection sqlConnection, StockMoveListCndtnWork _stockMoveListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string SelectDm = "";

                #region Select文作成
                SelectDm += "SELECT" + Environment.NewLine; 
                SelectDm += "     STM.BFSECTIONCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFSECTIONGUIDESNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.BFENTERWAREHCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFENTERWAREHNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.BFSHELFNORF" + Environment.NewLine;
                SelectDm += "    ,STM.SHIPMENTSCDLDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.SHIPMENTFIXDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.ARRIVALGOODSDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVESLIPNORF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEROWNORF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSECTIONCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSECTIONGUIDESNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.AFENTERWAREHCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFENTERWAREHNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.AFSHELFNORF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNORF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.LISTPRICEFLRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += "    ,STM.MOVECOUNTRF" + Environment.NewLine;
                SelectDm += "    ,STM.INPUTDAYRF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.MAKERNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.BLGOODSCODERF" + Environment.NewLine;
                SelectDm += "    ,STM.BLGOODSFULLNAMERF" + Environment.NewLine;
                SelectDm += "    ,STM.GOODSNAMEKANARF" + Environment.NewLine;
                SelectDm += "    ,STM.SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.SUPPLIERSNMRF" + Environment.NewLine;
                SelectDm += "    ,STM.WAREHOUSENOTE1RF" + Environment.NewLine;
                //SelectDm += "    ,STM.WAREHOUSENOTE2RF" + Environment.NewLine;  //2008.10.07 DEL
                SelectDm += "    ,STM.OUTLINERF" + Environment.NewLine;
                SelectDm += "    ,STM.TAXATIONDIVCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEPRICERF" + Environment.NewLine;
                SelectDm += "    ,STM.STOCKMOVEFORMALRF" + Environment.NewLine;
                SelectDm += " FROM STOCKMOVERF AS STM" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockMoveListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockMoveListResultWork wkStockMoveListResultWork = new StockMoveListResultWork();

                    //在庫移動データ格納項目
                    wkStockMoveListResultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    wkStockMoveListResultWork.BfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                    wkStockMoveListResultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    wkStockMoveListResultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    wkStockMoveListResultWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    wkStockMoveListResultWork.ShipmentScdlDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTSCDLDAYRF"));
                    wkStockMoveListResultWork.ShipmentFixDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
                    wkStockMoveListResultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    wkStockMoveListResultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
                    wkStockMoveListResultWork.StockMoveRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                    wkStockMoveListResultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    wkStockMoveListResultWork.AfSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                    wkStockMoveListResultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    wkStockMoveListResultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    wkStockMoveListResultWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                    wkStockMoveListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockMoveListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockMoveListResultWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    wkStockMoveListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockMoveListResultWork.MoveCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                    wkStockMoveListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkStockMoveListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockMoveListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockMoveListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockMoveListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    wkStockMoveListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkStockMoveListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkStockMoveListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockMoveListResultWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
                    //wkStockMoveListResultWork.WarehouseNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE2RF"));  //2008.10.07 DEL
                    wkStockMoveListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    wkStockMoveListResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    wkStockMoveListResultWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    wkStockMoveListResultWork.StockMovePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICERF"));
                    wkStockMoveListResultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

                    /*
                    if (wkStockMoveListResultWork.StockDiv == 0)
                    {
                        wkStockMoveListResultWork.MovingSupliStock = 1;
                    }
                    else
                    {
                        wkStockMoveListResultWork.MovingTrustStock = 1;
                    }

                    wkStockMoveListResultWork.MovingTotalStock = 1;
                    */ 
                    #endregion

                    al.Add(wkStockMoveListResultWork);

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
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchNonGrossAction Exception=" + ex.Message);
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
        /// <param name="_stockMoveListCndtnWork">検索条件格納クラス</param>
        /// <param name="_productNumberOutPutDiv">製番抽出区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Update Note : 2013/01/05 cheq</br>
        /// <br>管理番号    : 2013/03/13配信分</br>
        /// <br>              Redmine#33828 発行タイプについての対応</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMoveListCndtnWork _stockMoveListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " STM.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // 2008.07.07 del start ------------------------------------------->> 
            ////在庫移動伝票番号設定
            //if (_stockMoveListCndtnWork.St_StockMoveSlipNo != 0)
            //{
            //    retstring += " AND STM.STOCKMOVESLIPNORF>=@STSTOCKMOVESLIPNO" + Environment.NewLine;
            //    SqlParameter paraStStockMoveSlipNo = sqlCommand.Parameters.Add("@STSTOCKMOVESLIPNO", SqlDbType.Int);
            //    paraStStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_StockMoveSlipNo);
            //}
            //if (_stockMoveListCndtnWork.Ed_StockMoveSlipNo != 999999999)
            //{
            //    retstring += " AND STM.STOCKMOVESLIPNORF<=@EDSTOCKMOVESLIPNO" + Environment.NewLine;
            //    SqlParameter paraEdStockMoveSlipNo = sqlCommand.Parameters.Add("@EDSTOCKMOVESLIPNO", SqlDbType.Int);
            //    paraEdStockMoveSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_StockMoveSlipNo);
            //}
            ////メーカーコード設定
            //if (_stockMoveListCndtnWork.St_GoodsMakerCd != 0)
            //{
            //    retstring += " AND STM.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
            //    paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_GoodsMakerCd);
            //}
            //if (_stockMoveListCndtnWork.Ed_GoodsMakerCd != 999999)
            //{
            //    retstring += " AND STM.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
            //    SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
            //    paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_GoodsMakerCd);
            //}
            ////商品番号設定
            //if (_stockMoveListCndtnWork.St_GoodsNo != "")
            //{
            //    retstring += " AND STM.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
            //    SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
            //    paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_GoodsNo);
            //}
            //if (_stockMoveListCndtnWork.Ed_GoodsNo != "")
            //{
            //    retstring += " AND (STM.GOODSNORF<=@EDGOODSNO OR STM.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
            //    SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
            //    // 2008.03.26 >>
            //    //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_GoodsNo + "%");
            //    paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_GoodsNo);
            //    // 2008.03.26 <<
            //}
            // 2008.07.07 del end ---------------------------------------------<<

            // 2008.07.07 add start ------------------------------------------->>
            //開始入力日付
            if (_stockMoveListCndtnWork.St_CreateDate != DateTime.MinValue)
            {
                retstring += " AND STM.INPUTDAYRF >= @STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.St_CreateDate);

            }
            //終了入力日付
            if (_stockMoveListCndtnWork.Ed_CreateDate != DateTime.MinValue)
            {
                if (_stockMoveListCndtnWork.St_CreateDate == DateTime.MinValue)
                {
                    retstring += " AND (STM.INPUTDAYRF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " STM.INPUTDAYRF <= @EDINPUTDAY)" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.Ed_CreateDate);
            }

            /*
            //移動状態
            retstring += " AND STM.MOVESTATUSRF IN (";
            //発行タイプ 「出庫」か「全て」の場合
            if (_stockMoveListCndtnWork.PrintType == 0 || _stockMoveListCndtnWork.PrintType == -1)
            {
                retstring += "1,2";
            }
            //発行タイプ 「入庫」か「全て」の場合
            if (_stockMoveListCndtnWork.PrintType == 1 || _stockMoveListCndtnWork.PrintType == -1)
            {
                if ( _stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += ",";
                }
                retstring += "9";
            }
            retstring += ")" + Environment.NewLine;
            */

            //発行タイプ
            // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
            //if (_stockMoveListCndtnWork.PrintType == 0)
            if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
            // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
            {
                //発行タイプ 「出庫」か「全て」の場合、出荷確定日がセットされているデータを対象とする
                retstring += " AND NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0)" + Environment.NewLine;
            }
            else if (_stockMoveListCndtnWork.PrintType == 1)
            {
                //発行タイプ「入庫」の場合、入荷日がセットされているデータを対象とする
                retstring += " AND NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0)" + Environment.NewLine;
            }
            else if (_stockMoveListCndtnWork.PrintType == -1)
            {
                //retstring += " AND (NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0) AND NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0))" + Environment.NewLine;// DEL cheq 2013/01/05  Redmine#33828
                retstring += " AND (NOT(STM.SHIPMENTFIXDAYRF IS NULL OR STM.SHIPMENTFIXDAYRF=0) OR NOT(STM.ARRIVALGOODSDAYRF IS NULL OR STM.ARRIVALGOODSDAYRF=0))" + Environment.NewLine;// ADD cheq 2013/01/05  Redmine#33828
            }
            
            //開始対象日付
            if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
            {
                //発行タイプ 「出庫」か「全て」の場合
                // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                //if (_stockMoveListCndtnWork.PrintType == 0)
                if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                {
                    retstring += " AND STM.SHIPMENTFIXDAYRF >= @STSHIPARRIVALDATE" + Environment.NewLine;
                }
                //発行タイプ 「入庫」の場合
                if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND STM.ARRIVALGOODSDAYRF >= @STSHIPARRIVALDATE" + Environment.NewLine;
                }
                if (_stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += " AND (STM.SHIPMENTFIXDAYRF >= @STSHIPARRIVALDATE OR STM.ARRIVALGOODSDAYRF >= @STSHIPARRIVALDATE)" + Environment.NewLine;
                }

                SqlParameter paraStShipArrivalDate = sqlCommand.Parameters.Add("@STSHIPARRIVALDATE", SqlDbType.Int);
                paraStShipArrivalDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.St_ShipArrivalDate);

            }

            //終了対象日付
            if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
            {
                //発行タイプ 「出庫」か「全て」の場合
                // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                //if (_stockMoveListCndtnWork.PrintType == 0)
                if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                {
                    retstring += " AND STM.SHIPMENTFIXDAYRF <= @EDSHIPARRIVALDATE" + Environment.NewLine;
                }

                //発行タイプ 「入庫」の場合
                if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND STM.ARRIVALGOODSDAYRF <= @EDSHIPARRIVALDATE" + Environment.NewLine;
                }

                if (_stockMoveListCndtnWork.PrintType == -1)
                {
                    retstring += " AND (STM.SHIPMENTFIXDAYRF <= @EDSHIPARRIVALDATE OR STM.ARRIVALGOODSDAYRF <= @EDSHIPARRIVALDATE)" + Environment.NewLine;
                }

                SqlParameter paraEdShipArrivalDate = sqlCommand.Parameters.Add("@EDSHIPARRIVALDATE", SqlDbType.Int);
                paraEdShipArrivalDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
            }

            //拠点コード
            if (_stockMoveListCndtnWork.BfAfSectionCd != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {   
                    //出庫のみ
                    // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                    //if (_stockMoveListCndtnWork.PrintType == 0)
                    if ((_stockMoveListCndtnWork.PrintType == 0) || (_stockMoveListCndtnWork.PrintType == 2))
                    // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                    {
                        //移動元拠点コード
                        retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    else
                    //入庫のみ
                    if (_stockMoveListCndtnWork.PrintType == 1)
                    {
                        //移動先拠点コード
                        retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    else
                    //全て
                    if (_stockMoveListCndtnWork.PrintType == -1)
                    {
                        retstring += " AND (STM.BFSECTIONCODERF IN (" + sectionCodestr + ")  OR STM.AFSECTIONCODERF IN (" + sectionCodestr + ") )";
                    }
                }
                retstring += Environment.NewLine;
            }

            //移動元倉庫コード設定
            if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
            {
                retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
            }
            if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
            {
                retstring += " AND STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd);
            }

            //移動先倉庫コード設定
            if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
            {
                retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
            }
            if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
            {
                retstring += " AND STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE" + Environment.NewLine;
                SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd);
            }

            //出力指定
            if (_stockMoveListCndtnWork.OutputDesignat != -1)
            {
                if (_stockMoveListCndtnWork.OutputDesignat == 0)
                {
                    retstring += " AND STM.SLIPPRINTFINISHCDRF=0" + Environment.NewLine;
                }
                else if (_stockMoveListCndtnWork.OutputDesignat == 1)
                {
                    retstring += " AND STM.SLIPPRINTFINISHCDRF=1" + Environment.NewLine;
                }
            }
            // 2008.07.07 add end --------------------------------------------<<

            //在庫移動入力従業員コード設定
            if (_stockMoveListCndtnWork.St_StockMvEmpCode != "")
            {
                retstring += " AND STM.STOCKMVEMPCODERF>=@STSTOCKMVEMPCODE" + Environment.NewLine;
                SqlParameter paraStStockMvEmpCd = sqlCommand.Parameters.Add("@STSTOCKMVEMPCODE", SqlDbType.NChar);
                paraStStockMvEmpCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_StockMvEmpCode);
            }
            if (_stockMoveListCndtnWork.Ed_StockMvEmpCode != "")
            {
                if (_stockMoveListCndtnWork.St_StockMvEmpCode == "")
                {
                    retstring += " AND (STM.STOCKMVEMPCODERF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " STM.STOCKMVEMPCODERF<=@EDSTOCKMVEMPCODE)" + Environment.NewLine;
                SqlParameter paraEdStockMvEmpCd = sqlCommand.Parameters.Add("@EDSTOCKMVEMPCODE", SqlDbType.NChar);
                paraEdStockMvEmpCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_StockMvEmpCode);
            }

            //仕入先コード設定
            if (_stockMoveListCndtnWork.St_SupplierCd != 0)
            {
                retstring += " AND STM.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.St_SupplierCd);
            }
            if (_stockMoveListCndtnWork.Ed_SupplierCd != 999999999)
            {
                retstring += " AND STM.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMoveListCndtnWork.Ed_SupplierCd);
            }

            // 発行タイプ
            // 入荷確定あり
            if (_stockMoveListCndtnWork.StockMoveFixCode == 1)
            {
                // 未入荷
                if (_stockMoveListCndtnWork.PrintType == 0)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) AND STM.MOVESTATUSRF = 2 ";
                }
                // 入荷済
                else if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 3 OR STM.STOCKMOVEFORMALRF = 4) ";
                }
                // --- ADD 2012/11/06 Y.Wakita ---------->>>>>
                // 出庫
                else if (_stockMoveListCndtnWork.PrintType == 2)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) ";
                }
                // --- ADD 2012/11/06 Y.Wakita ----------<<<<<
            }

            // 入荷確定なし
            else
            {
                // 出庫
                if (_stockMoveListCndtnWork.PrintType == 0)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 1 OR STM.STOCKMOVEFORMALRF = 2) ";
                }
                // 入庫
                else if (_stockMoveListCndtnWork.PrintType == 1)
                {
                    retstring += " AND (STM.STOCKMOVEFORMALRF = 3 OR STM.STOCKMOVEFORMALRF = 4) ";
                }
            }

            #region 条件別Where文 (削除)
            /*
            //移動形式判定 1:在庫移動、2:倉庫移動
            if (_stockMoveListCndtnWork.StockMoveFormalDiv == 1)
            {
                #region 在庫移動Where
                //処理区分形式 0:未出荷、1:出荷済、2:未入荷、3:入荷済
                if ((_stockMoveListCndtnWork.ShipmentArrivalDiv == 0) || (_stockMoveListCndtnWork.ShipmentArrivalDiv == 1))
                {
                    #region 未出荷、出荷共通部分
                    //移動元拠点コード    ※配列で複数指定される
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }
                        retstring += Environment.NewLine;
                    }

                    //移動元倉庫コード設定
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" +Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" +Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //移動先拠点コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND STM.AFSECTIONCODERF>=@STAFSECTIONCODE" +Environment.NewLine;
                        SqlParameter paraStShipArrivalSection = sqlCommand.Parameters.Add("@STAFSECTIONCODE", SqlDbType.NChar);
                        paraStShipArrivalSection.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalSectionCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND (STM.AFSECTIONCODERF<=@EDAFSECTIONCODE OR STM.AFSECTIONCODERF LIKE @EDAFSECTIONCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalSectionCd = sqlCommand.Parameters.Add("@EDAFSECTIONCODE", SqlDbType.NChar);
                        paraEdShipArrivalSectionCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd + "%");
                    }

                    //移動先倉庫コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion

                    if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 0)
                    {
                        #region 未出荷の場合
                        //出荷予定日設定
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTSCDLDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTSCDLDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTSCDLDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }
                        retstring += " AND STM.MOVESTATUSRF = 1" + Environment.NewLine;
                        #endregion
                    }
                    else
                    {
                        #region 出荷済の場合
                        //出荷確定日設定
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }
                        retstring += " AND STM.MOVESTATUSRF = 2" + Environment.NewLine;
                        #endregion
                    }
                }
                else
                {
                    #region 未入荷、入荷共通部分
                    //移動先拠点コード    ※配列で複数指定される
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }
                        retstring += Environment.NewLine;
                    }

                    //移動先倉庫コード設定
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //移動元拠点コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND STM.BFSECTIONCODERF>=@STBFSECTIONCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalSection = sqlCommand.Parameters.Add("@STBFSECTIONCODE", SqlDbType.NChar);
                        paraStShipArrivalSection.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalSectionCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd != "")
                    {
                        retstring += " AND (STM.BFSECTIONCODERF<=@EDBFSECTIONCODE OR STM.BFSECTIONCODERF LIKE @EDBFSECTIONCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalSectionCd = sqlCommand.Parameters.Add("@EDBFSECTIONCODE", SqlDbType.NChar);
                        paraEdShipArrivalSectionCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalSectionCd + "%");
                    }

                    //移動元倉庫コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE"  + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion

                    if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 3)
                    {
                        #region 入荷済の場合
                        //入荷日設定
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.ARRIVALGOODSDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.ARRIVALGOODSDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.ARRIVALGOODSDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }

                        retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;
                        #endregion
                    }
                    else
                    {
                        #region 未入荷の場合
                        //出荷確定日設定
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                        {
                            int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                            retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                            retstring += Environment.NewLine;
                        }
                        if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                        {
                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND";
                            }

                            int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                            retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                            if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                            {
                                retstring += " ) ";
                            }
                            retstring += Environment.NewLine;
                        }

                        retstring += " AND STM.MOVESTATUSRF = 2" + Environment.NewLine;
                        #endregion
                    }
                }
                retstring += " AND STM.STOCKMOVEFORMALRF = 1" + Environment.NewLine;
                #endregion
            }

            else
            {
                #region 倉庫移動Where 未使用
                //処理区分形式 1:出荷、3:入荷
                if (_stockMoveListCndtnWork.ShipmentArrivalDiv == 1)
                {
                    #region 出荷の場合
                    //移動元拠点コード    ※配列で複数指定される
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.BFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }

                        retstring += Environment.NewLine;
                    }

                    //移動元倉庫コード設定
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //出荷確定日設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                    {
                        int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                        retstring += " AND STM.SHIPMENTFIXDAYRF >= " + startymd.ToString();
                        retstring += Environment.NewLine;
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                    {
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " AND (STM.SHIPMENTFIXDAYRF IS NULL OR";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                        retstring += " STM.SHIPMENTFIXDAYRF <= " + endymd.ToString();

                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                        retstring += Environment.NewLine;
                    }
                    retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;

                    //移動先拠点コード設定
                    retstring += " AND STM.AFSECTIONCODERF=STM.BFSECTIONCODERF" + Environment.NewLine;

                    //移動先倉庫コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion
                }
                else
                {
                    #region 入荷の場合
                    //移動先拠点コード    ※配列で複数指定される
                    if (_stockMoveListCndtnWork.BfAfSectionCd != null)
                    {
                        string sectionCodestr = "";
                        foreach (string seccdstr in _stockMoveListCndtnWork.BfAfSectionCd)
                        {
                            if (sectionCodestr != "")
                            {
                                sectionCodestr += ",";
                            }
                            sectionCodestr += "'" + seccdstr + "'";
                        }

                        if (sectionCodestr != "")
                        {
                            retstring += " AND STM.AFSECTIONCODERF IN (" + sectionCodestr + ") ";
                        }

                        retstring += Environment.NewLine;
                    }

                    //移動先倉庫コード設定
                    if (_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND STM.AFENTERWAREHCODERF>=@STAFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@STAFENTERWAREHCODE", SqlDbType.NChar);
                        paraStMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_MainBfAfEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd != "")
                    {
                        retstring += " AND (STM.AFENTERWAREHCODERF<=@EDAFENTERWAREHCODE OR STM.AFENTERWAREHCODERF LIKE @EDAFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdMainBfAfEnterWarehCd = sqlCommand.Parameters.Add("@EDAFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdMainBfAfEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd + "%");
                    }

                    //入荷日設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalDate != DateTime.MinValue)
                    {
                        int startymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.St_ShipArrivalDate);
                        retstring += " AND STM.ARRIVALGOODSDAYRF >= " + startymd.ToString();
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalDate != DateTime.MinValue)
                    {
                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " AND (STM.ARRIVALGOODSDAYRF IS NULL OR";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endymd = TDateTime.DateTimeToLongDate(_stockMoveListCndtnWork.Ed_ShipArrivalDate);
                        retstring += " STM.ARRIVALGOODSDAYRF <= " + endymd.ToString();

                        if (_stockMoveListCndtnWork.St_ShipArrivalDate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    retstring += Environment.NewLine;
                    retstring += " AND STM.MOVESTATUSRF = 9" + Environment.NewLine;

                    //移動元拠点コード設定
                    retstring += " AND STM.BFSECTIONCODERF=STM.AFSECTIONCODERF" + Environment.NewLine;

                    //移動元倉庫コード設定
                    if (_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND STM.BFENTERWAREHCODERF>=@STBFENTERWAREHCODE" + Environment.NewLine;
                        SqlParameter paraStShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@STBFENTERWAREHCODE", SqlDbType.NChar);
                        paraStShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd);
                    }
                    if (_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd != "")
                    {
                        retstring += " AND (STM.BFENTERWAREHCODERF<=@EDBFENTERWAREHCODE OR STM.BFENTERWAREHCODERF LIKE @EDBFENTERWAREHCODE)" + Environment.NewLine;
                        SqlParameter paraEdShipArrivalEnterWarehCd = sqlCommand.Parameters.Add("@EDBFENTERWAREHCODE", SqlDbType.NChar);
                        paraEdShipArrivalEnterWarehCd.Value = SqlDataMediator.SqlSetString(_stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd + "%");
                    }
                    #endregion
                }
                retstring += " AND STM.STOCKMOVEFORMALRF = 2" + Environment.NewLine;
                #endregion
            }
                */
            #endregion

            #endregion
            return retstring;
        }
    }
}
