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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタエクスポート  リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタエクスポートの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2020/06/15 小原</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    [Serializable]
    public class GoodsExportDB : RemoteDB, IGoodsExportDB
    {
        /// <summary>
        /// 商品マスタエクスポート  リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2020/06/15 小原</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
        public GoodsExportDB()
            :
            base("PMKHN07166D", "Broadleaf.Application.Remoting.ParamData.GoodsExportResultWork", "GOODSURF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品マスタLISTを戻します
        /// </summary>
        /// <param name="paraGoodsExportResultWork">検索結果</param>
        /// <param name="paraGoodsExportParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率マスタLISTを戻します</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        public int Search(out object paraGoodsExportResultWork, object paraGoodsExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            paraGoodsExportResultWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsPrt(out paraGoodsExportResultWork, paraGoodsExportParamWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPrintDB.Search");
                paraGoodsExportResultWork = new ArrayList();
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

        #region [SearchGoodsPrt]
        /// <summary>
        /// 指定された条件の商品マスタLISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraGoodsExportResultWork">検索結果</param>
        /// <param name="paraGoodsExportParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        public int SearchGoodsPrt(out object paraGoodsExportResultWork, object paraGoodsExportParamWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsExportParamWork goodsExportParamWork = null;

            ArrayList goodsExportParamWorkList = paraGoodsExportParamWork as ArrayList;
            ArrayList goodsExportResultWorkList = new ArrayList();

            if (goodsExportParamWorkList == null)
            {
                goodsExportParamWork = paraGoodsExportParamWork as GoodsExportParamWork;
            }
            else
            {
                if (goodsExportParamWorkList.Count > 0)
                    goodsExportParamWork = goodsExportParamWorkList[0] as GoodsExportParamWork;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //検索実行
                status = SearchProc(ref goodsExportResultWorkList, goodsExportParamWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsPrintDB.SearchRatePrt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            paraGoodsExportResultWork = goodsExportResultWorkList;

            return status;
        }
        #endregion  //[SearchRatePrt]

        #region [SearchProc]
        /// <summary>
        /// 指定された条件の商品マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsExportResultWorkList">検索結果</param>
        /// <param name="goodsExportParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        private int SearchProc(ref ArrayList goodsExportResultWorkList, GoodsExportParamWork goodsExportParamWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            // --- ADD 2020/06/15 小原 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/15 小原 PMKOBETSU-4005 ----------<<<<<

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // GOODSURF      GODSU 商品マスタ（ユーザー登録）
                // GOODSPRICEURF GODSP 価格マスタ（ユーザー登録）

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,GODSU.JANRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSRATERANKRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.LISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,GODSP.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.OFFERDATADIVRF" + Environment.NewLine;
                selectTxt += " FROM GOODSURF AS GODSU" + Environment.NewLine;

                //JOIN
                //価格マスタ（ユーザー登録）
                selectTxt += " LEFT JOIN GOODSPRICEURF GODSP" + Environment.NewLine;
                selectTxt += " ON  GODSP.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSNORF=GODSU.GOODSNORF" + Environment.NewLine;

                //WHERE
                selectTxt += MakeWhereString(ref sqlCommand, goodsExportParamWork, logicalMode);
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //goodsExportResultWorkList.Add(CopyToGoodsExportResultWorkFromReader(ref myReader, goodsExportParamWork));
                    goodsExportResultWorkList.Add(CopyToGoodsExportResultWorkFromReader(ref myReader, goodsExportParamWork, convertDoubleRelease));
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
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
                base.WriteErrorLog(ex, "GoodsPrintDB.SearchProc Exception=" + ex.Message);
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
                // --- ADD 2020/06/15 小原 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/15 小原 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion //[SearchProc]

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsExportParamWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsExportParamWork goodsExportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " GODSU.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsExportParamWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND GODSU.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND GODSU.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //商品メーカーコード
            if (goodsExportParamWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND GODSU.GOODSMAKERCDRF>=@GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(goodsExportParamWork.GoodsMakerCdSt);
            }
            if ((goodsExportParamWork.GoodsMakerCdEd != 0) &&(goodsExportParamWork.GoodsMakerCdEd != 9999))
            {
                retstring += " AND GODSU.GOODSMAKERCDRF<=@GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(goodsExportParamWork.GoodsMakerCdEd);
            }
            //BL商品コード
            if (goodsExportParamWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND GODSU.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(goodsExportParamWork.BLGoodsCodeSt);
            }
            if ((goodsExportParamWork.BLGoodsCodeEd != 0) &&(goodsExportParamWork.BLGoodsCodeEd != 99999))
            {
                retstring += " AND GODSU.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(goodsExportParamWork.BLGoodsCodeEd);
            }

            //商品番号
            if (goodsExportParamWork.GoodsNoSt != "")
            {
                if (goodsExportParamWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = goodsExportParamWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND ( GODSU.GOODSNORF>=@GOODSNOST OR GODSU.GOODSNORF LIKE @GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");

                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF>=@GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsExportParamWork.GoodsNoSt);
                }
            }
            if (goodsExportParamWork.GoodsNoEd != "")
            {
                if (goodsExportParamWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = goodsExportParamWork.GoodsNoEd.Split(new Char[] { '*' });

                    retstring += " AND (GODSU.GOODSNORF<=@GOODSNOED OR GODSU.GOODSNORF LIKE @GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF<=@GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsExportParamWork.GoodsNoEd);
                }
            }
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[WHERE句生成処理]

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsExportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsExportParamWork">検索条件</param>
        /// <param name="convertDoubleRelease">数値変換部品</param>
        /// <returns>GoodsExportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        // --- UPD 2020/06/15 小原 PMKOBETSU-4005 ---------->>>>>
        //private GoodsExportResultWork CopyToGoodsExportResultWorkFromReader(ref SqlDataReader myReader, GoodsExportParamWork goodsExportParamWork)
        private GoodsExportResultWork CopyToGoodsExportResultWorkFromReader(ref SqlDataReader myReader, GoodsExportParamWork goodsExportParamWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/16 小原 PMKOBETSU-4005 ----------<<<<<
        {
            GoodsExportResultWork ResultWork = new GoodsExportResultWork();

            #region クラスへ格納
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            ResultWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            ResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            ResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            ResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            ResultWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            ResultWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            ResultWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            ResultWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/06/15 小原 PMKOBETSU-4005 ---------->>>>>
            //ResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = goodsExportParamWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = ResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = ResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();
            ResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/06/15 小原 PMKOBETSU-4005 ----------<<<<<
            ResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            ResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            ResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            ResultWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
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
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/05/12</br>
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
