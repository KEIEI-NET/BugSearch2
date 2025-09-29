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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品構成取得（提供）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品構成取得（提供）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.06</br>
    /// <br></br>
    /// <br>Update Note: 2007.08.29 長内 DC.NS用に修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.13 20081 疋田 勇人 PM.NS用に修正</br>
    /// </remarks>
    [Serializable]
    public class GoodsRelationDataDB : RemoteDB, IGoodsRelationDataDB
    {
        /// <summary>
        /// 商品構成取得（提供）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        public GoodsRelationDataDB()
            :
            base("MACMN00136D", "Broadleaf.Application.Remoting.ParamData.GoodsRelationDataWork", "GOODSRELATIONDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品構成取得（提供）情報LISTを戻します
        /// </summary>
        /// <param name="goodsRelationDataWork">検索結果</param>
        /// <param name="paragoodsRelationDataWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得（提供）情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        public int Search(ref object goodsRelationDataWork, object paragoodsRelationDataWork, int readMode, ConstantManagement.LogicalMode logicalMode)
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

                return SearchProc(ref goodsRelationDataWork, paragoodsRelationDataWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsRelationDataDB.Search");
                goodsRelationDataWork = new ArrayList();
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
        }

        /// <summary>
        /// 指定された条件の商品構成取得（提供）情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得（提供）情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.29 長内 DC.NS用に修正</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            GoodsCndtnWork goodsrelationdataWork = null;

            //条件クラスのキャスト
            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList == null)
            {
                goodsrelationdataWork = paraObj as GoodsCndtnWork;
            }
            else
            {
                if (goodsrelationdataWorkList.Count > 0)
                    goodsrelationdataWork = goodsrelationdataWorkList[0] as GoodsCndtnWork;
            }
            
            CustomSerializeArrayList paraList = retObj as CustomSerializeArrayList;
            if (paraList != null)
            {
                for (int i = 0; i < paraList.Count; i++)
                {
                    Type wktype = paraList[i].GetType();

                    //商品連結
                    //if (wktype.Equals(typeof(GoodsUnitDataWork)))
                    //{
                    //    ArrayList retal = null;
                    //    status = SearchGoodsRelationDataProc(out retal, goodsrelationdataWork, readMode, logicalMode, ref sqlConnection);
                    //    retCSAList.Add(retal);
                    //}

                    //メーカー
                    if (wktype.Equals(typeof(PMakerNmWork)))
                    {
                        PMakerNmDB pMakerNmDB = new PMakerNmDB();
                        ArrayList retal = null;
                        status = pMakerNmDB.Search(out retal, readMode, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //商品中分類コード
                    if (wktype.Equals(typeof(GoodsMGroupWork)))
                    {
                        GoodsMGroupDB goodsMGroupDB = new GoodsMGroupDB();
                        object retal = null;
                        GoodsMGroupDB goodsMGroupWork = new GoodsMGroupDB();
                        status = goodsMGroupDB.SearchGoodsMGroupProc(out retal, goodsMGroupWork, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //BLグループ
                    if (wktype.Equals(typeof(BLGroupWork)))
                    {
                        BLGroupDB bLGroupDB = new BLGroupDB();
                        object retal = new object();
                        BLGroupWork bLGroupWork = new BLGroupWork();
                        status = bLGroupDB.SearchBLGroupCdProc(out retal, bLGroupWork, sqlConnection, sqlTransaction);
                        retCSAList.Add(retal);
                    }

                    //BLコード
                    if (wktype.Equals(typeof(TbsPartsCodeWork)))
                    {
                        TbsPartsCodeDB tbsPartsCodeDB = new TbsPartsCodeDB();
                        ArrayList retal = null;
                        TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
                        status = tbsPartsCodeDB.SearchTbsPartsCodeProc(out retal, tbsPartsCodeWork, ref sqlConnection);
                        retCSAList.Add(retal);
                    }
                }
            }
            retObj = retCSAList;
            return status;
        }

        // 2008.06.13 del start ---------------------------------------------->>
        ///// <summary>
        ///// 指定された条件の商品構成取得（提供）情報LISTを戻します(外部からのSqlConnectionを使用)
        ///// </summary>
        ///// <param name="goodsrelationdataWorkList">検索結果</param>
        ///// <param name="goodsrelationdataWork">検索パラメータ</param>
        ///// <param name="readMode">検索区分(現在未使用)</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された条件の商品構成取得（提供）情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2007.02.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.29 長内 DC.NS用に修正</br>
        //public int SearchGoodsRelationDataProc(out ArrayList goodsrelationdataWorkList, GoodsCndtnWork goodsrelationdataWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    ArrayList al = new ArrayList();
        //    string selectstring = "";
        //    try
        //    {
        //        selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += "    ,MAKER.MAKERNAMERF AS MAKERNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
        //        selectstring += "    ,TBSPARTSCODE.TBSPARTSFULLNAMERF AS TBSPARTSFULLNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
        //        selectstring += "    ,GOODSMGROUP.GOODSMGROUPNAMERF AS GOODSMGROUPNAME" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;
        //        selectstring += "    ,BLGROUP.BLGROUPNAMERF AS BLGROUPNAME" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
        //        selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.CREATEDATETIMERF AS GOODSPCREATEDATETIME" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDATEDATETIMERF AS GOODSPUPDATEDATETIME" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.ENTERPRISECODERF AS GOODSPENTERPRISECODE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.FILEHEADERGUIDRF AS GOODSPFILEHEADERGUID" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDEMPLOYEECODERF AS GOODSPUPDEMPLOYEECODE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDASSEMBLYID1RF AS GOODSPUPDASSEMBLYID1" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDASSEMBLYID2RF AS GOODSPUPDASSEMBLYID2" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.PRICESTARTDATERF AS GOODSPPRICESTARTDATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.LISTPRICERF AS GOODSPLISTPRICE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.SALESUNITCOSTRF AS GOODSPSALESUNITCOST" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.STOCKRATERF AS GOODSPSTOCKRATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.OPENPRICEDIVRF AS GOODSPOPENPRICEDIV" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.OFFERDATERF AS GOODSPOFFERDATE" + Environment.NewLine;
        //        selectstring += "    ,GOODSPRICE.UPDATEDATERF AS GOODSPUPDATEDATE" + Environment.NewLine;
        //        selectstring += "FROM GOODSRF AS GOODS" + Environment.NewLine;
        //        selectstring += "LEFT JOIN PTMKRPRICERF AS GOODSPRICE" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     GOODSPRICE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += " AND GOODSPRICE.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN MAKERNAMERF AS MAKER" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     MAKER.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN TBSPARTSCODERF AS TBSPARTSCODE" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     TBSPARTSCODE.TBSPARTSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN BLGROUPRF AS BLGROUP" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     BLGROUP.BLGROUPCODERF=TBSPARTSCODE.BLGROUPCODERF" + Environment.NewLine;
        //        selectstring += "LEFT JOIN GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
        //        selectstring += "ON" + Environment.NewLine;
        //        selectstring += "     GOODSMGROUP.GOODSMGROUPRF=BLGROUP.GOODSMGROUPRF" + Environment.NewLine;

        //        sqlCommand = new SqlCommand(selectstring, sqlConnection);

        //        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsrelationdataWork, logicalMode);

        //        sqlCommand.CommandText += "ORDER BY GOODSPRICE.PRICESTARTDATERF DESC, GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {

        //            al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));

        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();
        //    }

        //    goodsrelationdataWorkList = al;

        //    return status;
        //}
        #endregion
        // 2008.06.13 del end ------------------------------------------------<<

  	    #region [Where文作成処理]
	      /// <summary>
  	    /// 検索条件文字列生成＋条件値設定
	      /// </summary>
	      /// <param name="sqlCommand">SqlCommandオブジェクト</param>
	      /// <param name="goodsRelationDataWork">検索条件格納クラス</param>
	      /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	      /// <returns>Where条件文字列</returns>
	      /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.29 長内 DC.NS用に修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsCndtnWork goodsRelationDataWork, ConstantManagement.LogicalMode logicalMode)
        {
 
              string wkstring = "";
              StringBuilder retstring = new StringBuilder();
              retstring.Append("WHERE ");

              //論理削除区分
              wkstring = "";
              if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData1)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData2)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData3))
              {
                  wkstring = "GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
              }
              else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
	              (logicalMode == ConstantManagement.LogicalMode.GetData012))
              {
                  wkstring = "GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
              }
              if(wkstring != "")
              {
	              retstring.Append(wkstring);
	              SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
	              paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
              }

              //商品コード
              if (SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo) != DBNull.Value)
              {
                  if (goodsRelationDataWork.GoodsNoSrchTyp != 0)
                  {
                      //ハイフン無し品番に変換
                      string goodsNoNoneHyphen = goodsRelationDataWork.GoodsNo.Replace("-", "");

                      if (goodsRelationDataWork.GoodsNoSrchTyp != 4)
                      {
                          retstring.Append("AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN ");
                          //前方一致検索の場合
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 1) goodsNoNoneHyphen = goodsNoNoneHyphen + "%";
                          //後方一致検索の場合
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 2) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen;
                          //あいまい検索の場合
                          if (goodsRelationDataWork.GoodsNoSrchTyp == 3) goodsNoNoneHyphen = "%" + goodsNoNoneHyphen + "%";

                      }
                      else
                      {
                          //ハイフン無し品番完全一致検索の場合
                          retstring.Append("AND GOODS.GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN ");
                      }

                      SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                      paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoNoneHyphen);
                  }
                  else
                  {
                      retstring.Append("AND GOODS.GOODSNORF=@GOODSNO ");
                      SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                      paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNo);
                  }

              }

              //メーカーコード
              if (goodsRelationDataWork.GoodsMakerCd > 0)
              {
                retstring.Append("AND GOODS.GOODSMAKERCDRF=@GOODSMAKERCD ");
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMakerCd);
              }

              //商品名称
              if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsName) == false)
              {
                  retstring.Append("AND GOODS.GOODSNAMERF LIKE @GOODSNAME ");
                  SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                  //前方一致検索の場合
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 1) goodsRelationDataWork.GoodsName = goodsRelationDataWork.GoodsName + "%";
                  //後方一致検索の場合
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 2) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName;
                  //あいまい検索の場合
                  if (goodsRelationDataWork.GoodsNameSrchTyp == 3) goodsRelationDataWork.GoodsName = "%" + goodsRelationDataWork.GoodsName + "%";
                  paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsName);
              }

              //商品名称カナ
              if (goodsRelationDataWork.GoodsNameKana != "")
              {
                  retstring.Append("AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA ");
                  SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                  //前方一致検索の場合
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 1) goodsRelationDataWork.GoodsNameKana = goodsRelationDataWork.GoodsNameKana + "%";
                  //後方一致検索の場合
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 2) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana;
                  //あいまい検索の場合
                  if (goodsRelationDataWork.GoodsNameKanaSrchTyp == 3) goodsRelationDataWork.GoodsNameKana = "%" + goodsRelationDataWork.GoodsNameKana + "%";
                  paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.GoodsNameKana);
              }

              //BLコード
              if (goodsRelationDataWork.BLGoodsCode > 0)
              {
                  retstring.Append("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
                  SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                  paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGoodsCode);
              }

              //BLグループコード
              if (goodsRelationDataWork.BLGroupCode > 0)
              {
                  retstring.Append("AND BLGROUP.BLGROUPCODERF=@BLGROUPCODE ");
                  SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                  paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
              }

              //商品中分類コード
              if (goodsRelationDataWork.GoodsMGroup > 0)
              {
                  retstring.Append("AND BLGROUP.GOODSMGROUPRF=@GOODSMGROUP ");
                  SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                  paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
              }

              //商品属性
              if (goodsRelationDataWork.GoodsKindCode != 9)
              {
                  retstring.Append("AND GOODS.GOODSKINDCODERF=@GOODSKINDCODE ");
                  SqlParameter paraDetailGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                  paraDetailGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsKindCode);
              }

            return retstring.ToString();
		  }
	    #endregion

        // 2008.06.13 del start ---------------------------------------------->>
        #region [商品連結データクラス格納処理]
        ///// <summary>
        ///// クラス格納処理 Reader → GoodsUnitDataWork
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>GoodsUnitDataWork</returns>
        ///// <remarks>
        ///// <br>Programmer : 21015　金巻　芳則</br>
        ///// <br>Date       : 2006.12.06</br>
        ///// <br></br>
        ///// <br>Update Note: 2007.08.29 長内 DC.NS用に修正</br>
        ///// </remarks>
        //private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)
        //{
        //    GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

        //    #region クラスへ格納
        //    wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    wkGoodsUnitDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAME"));
        //    wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
        //    wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
        //    wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
        //    wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
        //    wkGoodsUnitDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAME"));
        //    wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
        //    wkGoodsUnitDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUP"));
        //    wkGoodsUnitDataWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAME"));
        //    wkGoodsUnitDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
        //    wkGoodsUnitDataWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAME"));
        //    wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
        //    wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
        //    wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
        //    wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //    wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
        //    wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
        //    wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
        //    wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
        //    wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
        //    wkGoodsUnitDataWork.GoodsPriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICECREATEDATETIME"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATETIME"));
        //    wkGoodsUnitDataWork.GoodsPriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEENTERPRISECODE"));
        //    wkGoodsUnitDataWork.GoodsPriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GOODSPRICEFILEHEADERGUID"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDEMPLOYEECODE"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID1"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID2"));
        //    wkGoodsUnitDataWork.GoodsPricePriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEPRICESTARTDATE"));
        //    wkGoodsUnitDataWork.GoodsPriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICELISTPRICE"));
        //    wkGoodsUnitDataWork.GoodsPriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESALESUNITCOST"));
        //    wkGoodsUnitDataWork.GoodsPriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESTOCKRATE"));
        //    wkGoodsUnitDataWork.GoodsPriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPRICEOPENPRICEDIV"));
        //    wkGoodsUnitDataWork.GoodsPriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEOFFERDATE"));
        //    wkGoodsUnitDataWork.GoodsPriceUpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATE"));
        //    #endregion

        //    return wkGoodsUnitDataWork;
        //}
        #endregion
        // 2008.06.13 del end ------------------------------------------------<<

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
