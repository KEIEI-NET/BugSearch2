//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品マスタ（ユーザー登録分）DBリモートオブジェクト
//                  :   PMKHN09674R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   zhouyu
// Date             :   2011/07/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   案件一覧 連番 1029でのテスト不具合について
// Programmer       :   周雨
// Date             :   2011/09/16
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   案件一覧 連番 1029でのテスト不具合について
// Programmer       :   王飛３
// Date             :   2011/09/16
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :   価格更新区分追加の対応
// Programmer       :   yangmj
// Date             :   2012/06/12
//----------------------------------------------------------------------
// Update Note      :   層別更新処理変更の対応
// Programmer       :   yangmj
// Date             :   2012/06/26
//----------------------------------------------------------------------
// Update Note      :   PMKOBETSU-4005 ＥＢＥ対策
// Programmer       :   譚洪
// Date             :   2020/06/18
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
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
using System.Collections.Generic;
using Broadleaf.Library.Collections;// ADD yangmj 2012/06/12 価格更新区分追加
using Broadleaf.Application.Common;  // ADD 2020/06/18 譚洪 PMKOBETSU-4005 

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタ（ユーザー登録分）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（ユーザー登録分）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : zhouyu</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Note       : 連番1029  新規</br>
    /// <br>Update Note: 価格更新区分追加の対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br>Update Note: 層別更新処理変更の対応</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2012/06/26</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class GoodsUpdateDB : RemoteDB, IRemoteDB, IGoodsUpdateDB
    {
        /// <summary>
        /// 商品マスタ（ユーザー登録分）リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 案件一覧 連番 1029でのテスト不具合について</br>
        /// <br>Programmer : 周雨</br>
        /// <br>Date       : 2011/09/16</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        public GoodsUpdateDB()
            :
        base("PMKHN09676D", "Broadleaf.Application.Remoting.ParamData.GoodsUResultWork", "GOODSURESULTWORK")
        {
        }

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="objList"></param>
        /// <param name="goodsUpdateWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの商品マスタ（ユーザー登録分）LISTの件数を戻します</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 層別更新処理変更の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/26</br>
        public int Update(out int retCnt, object objList, GoodsUpdateWork goodsUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<GoodsUResultWork> goodsUWorkOfferDBList = null;
            retCnt = 0;
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            //if (objList is List<GoodsUResultWork>)
            //    goodsUWorkOfferDBList = (List<GoodsUResultWork>)objList;
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList PriceList = null;  // 価格マスタ書き込みリスト
            ArrayList DelteteList = null;  // 価格マスタ削除リスト

            // 商品マスタ書き込みリスト
            ArrayList updList = (ArrayList)objList;

            if (updList[0] != null)
            {
                if (updList[0] is List<GoodsUResultWork>)
                    goodsUWorkOfferDBList = (List<GoodsUResultWork>)updList[0];
            }
            if (updList[1] != null) PriceList = updList[1] as ArrayList;  // 価格マスタ書き込みリスト
            if (updList[2] != null) DelteteList = updList[2] as ArrayList;  // 価格マスタ削除リスト

            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

            if (goodsUWorkOfferDBList == null || goodsUWorkOfferDBList.Count == 0)
                return status;

            if (goodsUpdateWork == null)
                return status;

            try
            {
                //status = UpdateProc(out retCnt, goodsUWorkOfferDBList, goodsUpdateWork);// DEL yangmj 2012/06/12 価格更新区分追加
                // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if ((goodsUpdateWork.GoodsNameUpdateDivCd == 1
                     || goodsUpdateWork.BLCodeUpdateDivCd == 1
                     //|| goodsUpdateWork.RateRankUpdateDivCd == 1))// DEL yangmj 2012/06/26 層別更新処理変更
                     //----- ADD yangmj 2012/06/26 層別更新処理変更 ------>>>>>
                     || goodsUpdateWork.RateRankUpdateDivCd == 1
                     || goodsUpdateWork.RateRankUpdateDivCd == 2))
                     //----- ADD yangmj 2012/06/26 層別更新処理変更 ------<<<<<
                {
                status = UpdateProc(out retCnt, goodsUWorkOfferDBList, goodsUpdateWork, sqlConnection, sqlTransaction);

                // 価格マスタ書き込み
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && PriceList != null)
                {
                    if (PriceList.Count != 0) status = WriteGoodsPriceURF(ref PriceList, sqlConnection, sqlTransaction);
                }
                // 価格管理件数を超えた場合の削除処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && DelteteList != null)
                {
                    if (DelteteList.Count != 0) status = DeleteGoodsPriceURF(ref DelteteList, sqlConnection, sqlTransaction);
                }
                }
                else
                {
                    // 価格マスタ書き込み
                    if (PriceList != null)
                    {
                        if (PriceList.Count != 0) status = WriteGoodsPriceURF(ref PriceList, sqlConnection, sqlTransaction);
                    }
                    // 価格管理件数を超えた場合の削除処理
                    if (DelteteList != null)
                    {
                        if (DelteteList.Count != 0) status = DeleteGoodsPriceURF(ref DelteteList, sqlConnection, sqlTransaction);
                    }
                }
                // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUpdateDB.Update Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            return status;
        }
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>

        /// <summary>
        /// ユーザー部品検索 優良設定の取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="makerCd"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int PrimeSettingSearch(string enterpriseCode, string sectionCode, int makerCd, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new ArrayList();
            try
            {
                PrmSettingUWork para = new PrmSettingUWork();
                para.EnterpriseCode = enterpriseCode;
                para.SectionCode = sectionCode;
                para.PartsMakerCd = makerCd;
                PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                status = prmSettingUDB.Search(ref retList, para, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    //該当無しステータスで対象マスタのどれか１件でも存在した場合はステータスを正常とする。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.UsrPartsSearch", ex.Number);
            }
            catch
            {
            }
            finally
            {
            }
            return status;
        }

        /// <summary>
        /// 価格マスタ更新処理
        /// </summary>
        /// <param name="writePriceList">更新データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int WriteGoodsPriceURF(ref ArrayList writePriceList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string errorMessage = String.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            try
            {
                foreach (GoodsPriceUWork GoodsPriceUWork in writePriceList)
                {
                    //Selectコマンドの生成
                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF " + Environment.NewLine;
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
                        //更新用のSQL文を生成
                        #region UPDATE文
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
                        #endregion

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
                        //新規作成時のSQL文を生成
                        #region INSERT文
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
                        #endregion

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
                    if (myReader.IsClosed == false)
                        myReader.Close();
                    myReader.Dispose();

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
                    
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //paraListPrice.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.ListPrice);
                    convertDoubleRelease.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = GoodsPriceUWork.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = GoodsPriceUWork.ListPrice;

                    // 変換処理実行
                    convertDoubleRelease.ConvertProc();

                    paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

                    paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.SalesUnitCost);
                    paraStockRate.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.StockRate);
                    paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.OpenPriceDiv);
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.OfferDate);
                    paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
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
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }

        /// <summary>
        /// 価格マスタ削除処理
        /// </summary>
        /// <param name="DeletePriceList">削除データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        private int DeleteGoodsPriceURF(ref ArrayList DeletePriceList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;

            try
            {
                foreach (GoodsPriceUWork GoodsPriceUWork in DeletePriceList)
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

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
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

                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
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
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）LISTの件数を戻します
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="goodsUpdateWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        public int SearchAll(out object objList, GoodsUpdateWork goodsUpdateWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<GoodsUResultWork> goodsUWorkOfferDBList = null;
            objList = null;// ADD yangmj 2012/06/12 価格更新区分追加
            if (goodsUpdateWork == null)
            {
                objList = null;
                return status;
            }

            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            CustomSerializeArrayList retList = new CustomSerializeArrayList();//結果リスト
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
            {
                objList = null;
                return status;
            }
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchAllProc(out goodsUWorkOfferDBList, goodsUpdateWork, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retList.Add(goodsUWorkOfferDBList);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&  goodsUpdateWork.PriceUpdateDivCd == 1)
                {
                    ArrayList PrimeSettingList = null;//優良設定リスト
                    status = this.PrimeSettingSearch(goodsUpdateWork.EnterpriseCode, "00", goodsUpdateWork.GoodsMakerCd, out PrimeSettingList, ref sqlConnection, ref sqlTransaction);
                    if (PrimeSettingList != null && PrimeSettingList.Count > 0)
                    {
                        retList.Add(PrimeSettingList);
                    }
                }

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) && goodsUWorkOfferDBList != null)
                {
                    //該当無しステータスで対象マスタのどれか１件でも存在した場合はステータスを正常とする。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                    objList = (object)retList;
            }
            else
            {
                objList = null;
            }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "GoodsUpdateDB.SearchAll", ex.Number);
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            //status = SearchAllProc(out goodsUWorkOfferDBList, goodsUpdateWork, logicalMode);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    objList = (object)goodsUWorkOfferDBList;
            //}
            //else
            //{
            //    objList = null;
            //}
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            return status;
        }

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）LISTを戻します
        /// </summary>
        /// <param name="goodsUWorkList"></param>
        /// <param name="goodsUpdateWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの商品マスタ（ユーザー登録分）LISTを戻します</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        //private int SearchAllProc(out List<GoodsUResultWork> goodsUWorkList, GoodsUpdateWork goodsUpdateWork, ConstantManagement.LogicalMode logicalMode)// DEL yangmj 2012/06/12 価格更新区分追加
        private int SearchAllProc(out List<GoodsUResultWork> goodsUWorkList, GoodsUpdateWork goodsUpdateWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// ADD yangmj 2012/06/12 価格更新区分追加
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //SqlConnection sqlConnection = null;// DEL yangmj 2012/06/12 価格更新区分追加
            SqlDataReader myReader = null;
            goodsUWorkList = new List<GoodsUResultWork>();

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            try
            {
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                string sqlTxt = string.Empty;

                SqlCommand sqlCommand;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt += "SELECT GOODSURF.CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMEKANARF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.JANRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.DISPLAYORDERRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSRATERANKRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSKINDCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSSPECIALNOTERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATADIVRF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "    , GOODSPRICEURF.CREATEDATETIMERF AS PRICECREATEDATETIMERF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATETIMERF AS PRICEUPDATEDATETIMERF  " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.FILEHEADERGUIDRF AS PRICEFILEHEADERGUIDRF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID1RF AS PRICEUPDASSEMBLYID1RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID2RF AS PRICEUPDASSEMBLYID2RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.ENTERPRISECODERF AS PRICEENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDEMPLOYEECODERF AS PRICEUPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LOGICALDELETECODERF AS PRICELOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSMAKERCDRF AS PRICEGOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSNORF AS PRICEGOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.PRICESTARTDATERF AS PRICEPRICESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LISTPRICERF AS PRICELISTPRICERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.SALESUNITCOSTRF AS PRICESALESUNITCOSTRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.STOCKRATERF AS PRICESTOCKRATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OPENPRICEDIVRF AS PRICEOPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OFFERDATERF AS PRICEOFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATERF AS PRICEUPDATEDATERF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                    sqlTxt += "    FROM GOODSURF" + Environment.NewLine;
                    /* --- DEL 2011/09/16 ------------------ >>>>>
                    sqlTxt += "LEFT JOIN GOODSMNGRF ON GOODSURF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSMNGRF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.BLGOODSCODERF=BLGOODSCDURF.BLGOODSCODERF" + Environment.NewLine;
                    --- DEL 2011/09/16 --------------------- <<<<<*/

                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "LEFT JOIN GOODSPRICEURF ON GOODSURF.ENTERPRISECODERF=GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSPRICEURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.LOGICALDELETECODERF= 0" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                    sqlTxt += "    WHERE GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND GOODSURF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "        AND GOODSURF.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    if (goodsUpdateWork.GoodsMGroup > 0)
                    {
                        //sqlTxt += "        AND GOODSMNGRF.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;   // DEL 2011/09/16
                        // --- ADD 2011/09/16 ------------------- >>>>>
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlTxt += " )) " + Environment.NewLine;
                        // --- ADD 2011/09/16 ------------------- <<<<<
                    }
                    if (goodsUpdateWork.BLGoodsCode > 0)
                    {
                        //sqlTxt += "        AND BLGOODSCDURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // DEL 2011/09/16
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // ADD 2011/09/16
                    }

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt += "SELECT GOODSURF.CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMEKANARF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.JANRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.DISPLAYORDERRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSRATERANKRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSKINDCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSSPECIALNOTERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATADIVRF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "    , GOODSPRICEURF.CREATEDATETIMERF AS PRICECREATEDATETIMERF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATETIMERF AS PRICEUPDATEDATETIMERF  " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.FILEHEADERGUIDRF AS PRICEFILEHEADERGUIDRF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID1RF AS PRICEUPDASSEMBLYID1RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID2RF AS PRICEUPDASSEMBLYID2RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.ENTERPRISECODERF AS PRICEENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDEMPLOYEECODERF AS PRICEUPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LOGICALDELETECODERF AS PRICELOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSMAKERCDRF AS PRICEGOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSNORF AS PRICEGOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.PRICESTARTDATERF AS PRICEPRICESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LISTPRICERF AS PRICELISTPRICERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.SALESUNITCOSTRF AS PRICESALESUNITCOSTRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.STOCKRATERF AS PRICESTOCKRATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OPENPRICEDIVRF AS PRICEOPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OFFERDATERF AS PRICEOFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATERF AS PRICEUPDATEDATERF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                    sqlTxt += "    FROM GOODSURF" + Environment.NewLine;
                    /* --- DEL 2011/09/16 ------------------ >>>>>
                    sqlTxt += "LEFT JOIN GOODSMNGRF ON GOODSURF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSMNGRF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.BLGOODSCODERF=BLGOODSCDURF.BLGOODSCODERF" + Environment.NewLine;
                    --- DEL 2011/09/16 --------------------- <<<<<*/

                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "LEFT JOIN GOODSPRICEURF ON GOODSURF.ENTERPRISECODERF=GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSPRICEURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.LOGICALDELETECODERF= 0" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                    sqlTxt += "    WHERE GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND GOODSURF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += "        AND GOODSURF.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    if (goodsUpdateWork.GoodsMGroup > 0)
                    {
                        //sqlTxt += "        AND GOODSMNGRF.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine; // DEL 2011/09/16
                        // --- ADD 2011/09/16 ------------------- >>>>>
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlTxt += " )) " + Environment.NewLine;
                        // --- ADD 2011/09/16 ------------------- <<<<<
                    }
                    if (goodsUpdateWork.BLGoodsCode > 0)
                    {
                        //sqlTxt += "        AND BLGOODSCDURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // DEL 2011/09/16
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // ADD 2011/09/16
                    }

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlTxt += "SELECT GOODSURF.CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNAMEKANARF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.JANRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.DISPLAYORDERRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSRATERANKRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.TAXATIONDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSKINDCODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE1RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSNOTE2RF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.GOODSSPECIALNOTERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.ENTERPRISEGANRECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.UPDATEDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSURF.OFFERDATADIVRF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "    , GOODSPRICEURF.CREATEDATETIMERF AS PRICECREATEDATETIMERF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATETIMERF AS PRICEUPDATEDATETIMERF  " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.FILEHEADERGUIDRF AS PRICEFILEHEADERGUIDRF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID1RF AS PRICEUPDASSEMBLYID1RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDASSEMBLYID2RF AS PRICEUPDASSEMBLYID2RF " + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.ENTERPRISECODERF AS PRICEENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDEMPLOYEECODERF AS PRICEUPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LOGICALDELETECODERF AS PRICELOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSMAKERCDRF AS PRICEGOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.GOODSNORF AS PRICEGOODSNORF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.PRICESTARTDATERF AS PRICEPRICESTARTDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.LISTPRICERF AS PRICELISTPRICERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.SALESUNITCOSTRF AS PRICESALESUNITCOSTRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.STOCKRATERF AS PRICESTOCKRATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OPENPRICEDIVRF AS PRICEOPENPRICEDIVRF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.OFFERDATERF AS PRICEOFFERDATERF" + Environment.NewLine;
                    sqlTxt += "    , GOODSPRICEURF.UPDATEDATERF AS PRICEUPDATEDATERF" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                    sqlTxt += "    FROM GOODSURF" + Environment.NewLine;
                    /* --- DEL 2011/09/16 ------------------ >>>>>
                    sqlTxt += "LEFT JOIN GOODSMNGRF ON GOODSURF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSMNGRF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "LEFT JOIN BLGOODSCDURF ON GOODSURF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.BLGOODSCODERF=BLGOODSCDURF.BLGOODSCODERF" + Environment.NewLine;
                    --- DEL 2011/09/16 --------------------- <<<<<*/
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                    sqlTxt += "LEFT JOIN GOODSPRICEURF ON GOODSURF.ENTERPRISECODERF=GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSMAKERCDRF=GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.GOODSNORF=GOODSPRICEURF.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "AND GOODSURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                    sqlTxt += "    WHERE GOODSURF.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "        AND GOODSURF.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    if (goodsUpdateWork.GoodsMGroup > 0)
                    {
                        //sqlTxt += "        AND GOODSMNGRF.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;   // DEL 2011/09/16
                        // --- ADD 2011/09/16 ------------------- >>>>>
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND BLGROUPCODERF IN ( " + Environment.NewLine;
                        sqlTxt += " SELECT BLGROUPCODERF FROM BLGROUPURF WHERE " + Environment.NewLine;
                        sqlTxt += " ENTERPRISECODERF= " + goodsUpdateWork.EnterpriseCode + Environment.NewLine;
                        sqlTxt += " AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlTxt += " )) " + Environment.NewLine;
                        // --- ADD 2011/09/16 ------------------- <<<<<
                    }
                    if (goodsUpdateWork.BLGoodsCode > 0)
                    {
                        //sqlTxt += "        AND BLGOODSCDURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // DEL 2011/09/16
                        sqlTxt += "        AND GOODSURF.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;  // ADD 2011/09/16
                    }

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                }
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUpdateWork.EnterpriseCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUpdateWork.GoodsMakerCd);

                if (goodsUpdateWork.GoodsMGroup > 0)
                {
                    SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsUpdateWork.GoodsMGroup);
                }
                if (goodsUpdateWork.BLGoodsCode > 0)
                {
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsUpdateWork.BLGoodsCode);
                }

                //データリード
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                //myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                myReader = sqlCommand.ExecuteReader();
                int beGoodsMakerCd = 0;
                string beGoodsNo = string.Empty;
                ArrayList priceList = null;
                GoodsUResultWork goodsUWork;
                int index = 0;
                // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                while (myReader.Read())
                {
                    int goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));

                    if (!(beGoodsMakerCd == goodsMakerCd && beGoodsNo.Equals(goodsNo)))
                    {
                        if (index != 0)
                        {
                            goodsUWorkList[index - 1].PriceList = priceList;
                        }
                        index++;
                        goodsUWork = new GoodsUResultWork();
                    goodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    goodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    goodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
                    goodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    goodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    goodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    goodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    goodsUWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    goodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    goodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
                    goodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
                    goodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
                    goodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    goodsUWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    goodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
                        goodsUWorkList.Add(goodsUWork);
                        priceList = new ArrayList();
                    }

                    GoodsPriceUWork goodsPrice = new GoodsPriceUWork();
                    goodsPrice.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICECREATEDATETIMERF"));
                    goodsPrice.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICEUPDATEDATETIMERF"));
                    goodsPrice.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEENTERPRISECODERF"));
                    goodsPrice.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("PRICEFILEHEADERGUIDRF"));
                    goodsPrice.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDEMPLOYEECODERF"));
                    goodsPrice.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID1RF"));
                    goodsPrice.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID2RF"));
                    goodsPrice.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICELOGICALDELETECODERF"));
                    goodsPrice.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEGOODSMAKERCDRF"));
                    goodsPrice.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEGOODSNORF"));
                    goodsPrice.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEPRICESTARTDATERF"));

                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //goodsPrice.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = goodsPrice.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = goodsPrice.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    goodsPrice.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                 
                    goodsPrice.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESALESUNITCOSTRF"));
                    goodsPrice.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESTOCKRATERF"));
                    goodsPrice.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEOPENPRICEDIVRF"));
                    goodsPrice.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
                    goodsPrice.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICEUPDATEDATERF"));
                    priceList.Add(goodsPrice);

                    beGoodsMakerCd = goodsMakerCd;
                    beGoodsNo = goodsNo;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                goodsUWorkList[index - 1].PriceList = priceList;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUpdateDB.SearchAllProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                //if (sqlConnection != null)
                //{
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
                if (!myReader.IsClosed)
                    myReader.Close();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）更新を行う
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="updateGoodsUWorkList"></param>	
        /// <param name="goodsUpdateWork">更新パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの商品マスタ（ユーザー登録分）更新を行う</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// <br>Update Note: 価格更新区分追加の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 層別更新処理変更の対応</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/06/26</br>
        //private int UpdateProc(out int retCnt, List<GoodsUResultWork> updateGoodsUWorkList, GoodsUpdateWork goodsUpdateWork)// DEL yangmj 2012/06/12 価格更新区分追加
        private int UpdateProc(out int retCnt, List<GoodsUResultWork> updateGoodsUWorkList, GoodsUpdateWork goodsUpdateWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)// ADD yangmj 2012/06/12 価格更新区分追加
        {
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
            //SqlConnection sqlConnection = null;
            //SqlTransaction sqlTransaction = null;
            // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            SqlDataReader myReader = null;
            retCnt = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "")
                //    return status;

                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();

                //// トランザクション開始
                //sqlTransaction = this.CreateTransaction(ref sqlConnection);
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

                foreach (GoodsUResultWork goodsUWorkOfferDB in updateGoodsUWorkList)
                {
                    int count = 0;
                    SqlCommand sqlCommand = null;
                    try
                    {
                        string sqlTxt = string.Empty;

                        sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "FROM GOODSURF" + Environment.NewLine;
                        sqlTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUWorkOfferDB.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsNo);
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            //更新日時
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                            if (_updateDateTime != goodsUWorkOfferDB.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                break;
                            }

                            /* --- DEL 2011/09/16 ------------------- >>>>>
                            if ((goodsUpdateWork.GoodsNameUpdateDivCd == 0
                                || goodsUpdateWork.BLCodeUpdateDivCd == 0
                                || goodsUpdateWork.RateRankUpdateDivCd == 0))
                            --- DEL 2011/09/16 ---------------------- <<<<<*/
                            //----- DEL yangmj 2012/06/26 層別更新処理変更 ------>>>>>
                            //// --- 2011/09/16 ----------------------- >>>>>
                            //if ((goodsUpdateWork.GoodsNameUpdateDivCd == 1
                            //     || goodsUpdateWork.BLCodeUpdateDivCd == 1
                            //     || goodsUpdateWork.RateRankUpdateDivCd == 1))
                            //// --- 2011/09/16 ----------------------- <<<<<
                            //----- DEL yangmj 2012/06/26 層別更新処理変更 ------<<<<<
                            //----- ADD yangmj 2012/06/26 層別更新処理変更 ------>>>>>
                            if ((goodsUpdateWork.GoodsNameUpdateDivCd == 1
                                 || goodsUpdateWork.BLCodeUpdateDivCd == 1
                                 || goodsUpdateWork.RateRankUpdateDivCd == 2
                                 || (goodsUpdateWork.RateRankUpdateDivCd == 1
                                 && (!string.IsNullOrEmpty(goodsUWorkOfferDB.GoodsRateRank.Trim())))))
                            //----- ADD yangmj 2012/06/26 層別更新処理変更 ------<<<<<
                            {
                                sqlTxt = string.Empty;
                                //Updateコマンドの生成
                                sqlTxt += "UPDATE GOODSURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                //名称更新区分
                                //if (goodsUpdateWork.GoodsNameUpdateDivCd == 0)  // DEL 2011/09/16
                                if (goodsUpdateWork.GoodsNameUpdateDivCd == 1)   // ADD 2011/09/16
                                {
                                    sqlTxt += ", GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                                    sqlTxt += ", GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;// ADD　王飛３ 2011/09/16　
                                }

                                //BL商品コード更新区分
                                //if (goodsUpdateWork.BLCodeUpdateDivCd == 0)  // DEL 2011/09/16
                                if (goodsUpdateWork.BLCodeUpdateDivCd == 1)   // ADD 2011/09/16
                                {
                                    sqlTxt += ", BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                }
                                //層別更新区分
                                //if (goodsUpdateWork.RateRankUpdateDivCd == 0)  // DEL 2011/09/16
                                //if (goodsUpdateWork.RateRankUpdateDivCd == 1)  // ADD 2011/09/16 // DEL yangmj 2012/06/26 層別更新処理変更
                                if (goodsUpdateWork.RateRankUpdateDivCd == 2
                                    || (goodsUpdateWork.RateRankUpdateDivCd == 1 && (!string.IsNullOrEmpty(goodsUWorkOfferDB.GoodsRateRank.Trim())))) // ADD yangmj 2012/06/26 層別更新処理変更
                                {
                                    sqlTxt += ", GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                                }
                                sqlTxt += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                                sqlTxt += "AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                                //Parameterオブジェクトの作成(更新用)
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                                //Parameterオブジェクトへ値設定(更新用)
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);

                                //名称更新区分
                                //if (goodsUpdateWork.GoodsNameUpdateDivCd == 0)   // DEL 2011/09/16
                                if (goodsUpdateWork.GoodsNameUpdateDivCd == 1)    // ADD 2011/09/16
                                {
                                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                                    //paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsName);  // DEL 王飛３ 2011/09/16
                                    paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsNameKana);  // ADD  王飛３ 2011/09/16

                                    // --- ADD  王飛３ 2011/09/16 -------------- >>>>>
                                    SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NChar);
                                    paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsNameKana);
                                    // --- ADD  王飛３ 2011/09/16 -------------- <<<<<
                                }

                                //BL商品コード更新区分
                                //if (goodsUpdateWork.BLCodeUpdateDivCd == 0)   // DEL 2011/09/16
                                if (goodsUpdateWork.BLCodeUpdateDivCd == 1)   // ADD 2011/09/16
                                {
                                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsUWorkOfferDB.BLGoodsCode);
                                }
                                //層別更新区分
                                //if (goodsUpdateWork.RateRankUpdateDivCd == 0)  // DEL 2011/09/16
                                //if (goodsUpdateWork.RateRankUpdateDivCd == 1) // ADD 2011/09/16 // DEL yangmj 2012/06/26 層別更新処理変更
                                if (goodsUpdateWork.RateRankUpdateDivCd == 2) // ADD yangmj 2012/06/26 層別更新処理変更
                                {
                                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                                    paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsRateRank);
                                }
                                //----- ADD yangmj 2012/06/26 層別更新処理変更 ------>>>>>
                                else if (goodsUpdateWork.RateRankUpdateDivCd == 1 && (!string.IsNullOrEmpty(goodsUWorkOfferDB.GoodsRateRank.Trim()))) 
                                {
                                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                                    paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsRateRank);
                                }
                                //----- ADD yangmj 2012/06/26 層別更新処理変更 ------<<<<<

                                //Parameterオブジェクトの作成(検索用)
                                SqlParameter findParaEnterpriseCodeUpdate = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaGoodsMakerCdUpdate = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                                SqlParameter findParaGoodsNoUpdate = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                                //Parameterオブジェクトへ値設定(検索用)
                                findParaEnterpriseCodeUpdate.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.EnterpriseCode);
                                findParaGoodsMakerCdUpdate.Value = SqlDataMediator.SqlSetInt32(goodsUWorkOfferDB.GoodsMakerCd);
                                findParaGoodsNoUpdate.Value = SqlDataMediator.SqlSetString(goodsUWorkOfferDB.GoodsNo);

                                if (!myReader.IsClosed)
                                    myReader.Close();

                                //件数
                                count = sqlCommand.ExecuteNonQuery();

                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            break;
                        }
                        if (!myReader.IsClosed)
                            myReader.Close();
                    }
                    catch (SqlException ex)
                    {
                        //基底クラスに例外を渡して処理してもらう
                        status = base.WriteSQLErrorLog(ex);
                        retCnt = 0;
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "GoodsUpdateDB.UpdateProc Exception=" + ex.Message);
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        retCnt = 0;
                    }
                    finally
                    {
                        if (sqlCommand != null)
                        {
                            sqlCommand.Cancel();
                            sqlCommand.Dispose();
                        }
                    }
                    retCnt = retCnt + count;
                }

                if (retCnt == 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (Exception ex)
            {
                retCnt = 0;
                base.WriteErrorLog(ex, "GoodsUpdateDB.UpdateProc Exception=", status);
            }
            finally
            {
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
                //if (sqlTransaction != null)
                //{
                //    if (sqlTransaction.Connection != null)
                //    {
                //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            // コミット
                //            sqlTransaction.Commit();
                //        }
                //        else
                //        {
                //            // ロールバック
                //            sqlTransaction.Rollback();
                //        }
                //    }

                //    sqlTransaction.Dispose();
                //}

                //if (sqlConnection != null)
                //{
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();
                //}
                // --- DEL yangmj 2012/06/12 価格更新区分追加----------------- <<<<<
            }
            return status;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
    }

}

