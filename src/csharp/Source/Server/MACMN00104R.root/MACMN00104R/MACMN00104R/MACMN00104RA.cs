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
using System.Collections.Generic;
using System.Windows.Forms;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品構成取得DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品構成取得の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2006.12.06</br>
    /// <br></br>
    /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.03.24 山田 明友 ステータスの戻し方を修正(該当データが1件でもあったら0を返す)</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.12 20081 疋田 勇人 PM.NS用に変更</br>
    /// </remarks>
    [Serializable]
    public class GoodsURelationDataDB : RemoteDB, IGoodsURelationDataDB
    {
        /// <summary>
        /// 商品構成取得DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// </remarks>
        public GoodsURelationDataDB()
            :
            base("MACMN00106D", "Broadleaf.Application.Remoting.ParamData.GoodsCndtnWork", "GOODSRELATIONDATARF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
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

                status = SearchProc(ref retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int SearchProc(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            GoodsCndtnWork goodsrelationdataWork = null;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

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
            for (int i = 0; i < paraList.Count; i++)
            {
                Type wktype = paraList[i].GetType();

                //商品中分類
                if (wktype.Equals(typeof(GoodsGroupUWork)))
                {
                    GoodsGroupUDB goodsGroupUDB = new GoodsGroupUDB();
                    ArrayList retal = null;
                    GoodsGroupUWork goodsGroupUWork = paraList[i] as GoodsGroupUWork;
                    goodsGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = goodsGroupUDB.Search(ref retal, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                    retCSAList.Add(retal);
                }

                //優良設定
                if (wktype.Equals(typeof(PrmSettingUWork)))
                {
                    PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
                    ArrayList retal = null;
                    PrmSettingUWork prmSettingUWork = paraList[i] as PrmSettingUWork;
                    prmSettingUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = prmSettingUDB.Search(ref retal, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                    retCSAList.Add(retal);
                }

                //メーカー
                if (wktype.Equals(typeof(MakerUWork)))
                {
                    MakerUDB makerUDB = new MakerUDB();
                    ArrayList retal = null;
                    MakerUWork makerUWork = new MakerUWork();
                    makerUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = makerUDB.SearchMakerProc(out retal, makerUWork, readMode, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);
                }

                //BLグループ 
                if (wktype.Equals(typeof(BLGroupUWork)))
                {
                    BLGroupUDB bLGroupUDB = new BLGroupUDB();
                    ArrayList retal = null;
                    BLGroupUWork bLGroupUWork = paraList[i] as BLGroupUWork;
                    bLGroupUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = bLGroupUDB.Search(ref retal, bLGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                    retCSAList.Add(retal);
                }

                //BLコード               
                if (wktype.Equals(typeof(BLGoodsCdUWork)))
                {
                    BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                    ArrayList retal = null;
                    BLGoodsCdUWork bLGoodsCdUWork = paraList[i] as BLGoodsCdUWork;
                    bLGoodsCdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);
                }

                //商品管理
                if (wktype.Equals(typeof(GoodsMngWork)))
                {
                    GoodsMngDB goodsMngDB = new GoodsMngDB();
                    ArrayList retal = null;
                    GoodsMngWork goodsMngWork = paraList[i] as GoodsMngWork;
                    goodsMngWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    status = goodsMngDB.SearchGoodsMngProc(out retal, goodsMngWork, readMode, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);
                }

                //ユーザーガイド
                if (wktype.Equals(typeof(UserGdBdUWork)))
                {
                    UserGdBdUDB userGdBdUDB = new UserGdBdUDB();
                    UserGdBdUWork userGdBdUWork = paraList[i] as UserGdBdUWork;
                    
                    //商品大分類(ユーザーガイド ガイド区分:70)
                    ArrayList retal = null;
                    userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    userGdBdUWork.UserGuideDivCd = 70;
                    status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);

                    //自社分類(ユーザーガイド ガイド区分:41)
                    retal = null;
                    userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    userGdBdUWork.UserGuideDivCd = 41;
                    status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);

                    //販売区分(ユーザーガイド ガイド区分:71)
                    retal = null;
                    userGdBdUWork.EnterpriseCode = goodsrelationdataWork.EnterpriseCode;
                    userGdBdUWork.UserGuideDivCd = 71;
                    status = userGdBdUDB.Search(out retal, userGdBdUWork, 0, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);
                }

                //商品連結
                if (wktype.Equals(typeof(GoodsUnitDataWork)))
                {
                    ArrayList retal = null;
                    status = SearchGoodsURelationDataProc(out retal, wktype, goodsrelationdataWork, null, readMode, logicalMode, ref sqlConnection);
                    retCSAList.Add(retal);
                }
            }

            retObj = retCSAList;

            // ↓ 2008.03.24 980081 c
            //return status;
            if (retCSAList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // ↑ 2008.03.24 980081 c
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsrelationdataWorkList">検索結果</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsrelationdataWork">抽出条件</param>
        /// <param name="paralist">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int SearchGoodsURelationDataProc(out ArrayList goodsrelationdataWorkList, Type trgType, GoodsCndtnWork goodsrelationdataWork, ArrayList paralist, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            string selectstring = "";
            try
            {
                selectstring += "SELECT GOODS.CREATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "    ,MAKERU.MAKERNAMERF AS MAKERNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectstring += "    ,GOODS.JANRF" + Environment.NewLine;
                selectstring += "    ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectstring += "    ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSLGROUPRF AS GOODSLGROUP" + Environment.NewLine;
                selectstring += "    ,USERGD.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.GOODSMGROUPRF AS GOODSMGROUP" + Environment.NewLine;
                selectstring += "    ,GOODSGROUPU.GOODSMGROUPNAMERF AS GOODSMGROUPNAME" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.BLGROUPNAMERF AS BLGROUPNAME" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectstring += "    ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectstring += "    ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectstring += "    ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectstring += "    ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "    ,USERGD01.GUIDENAMERF AS ENTERPRISEGANRENAME" + Environment.NewLine;
                selectstring += "    ,GOODS.UPDATEDATERF" + Environment.NewLine;
                selectstring += "    ,BLGOODS.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectstring += "    ,BLGROUPU.SALESCODERF" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.CREATEDATETIMERF AS GOODSPCREATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATETIMERF AS GOODSPUPDATEDATETIME" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.ENTERPRISECODERF AS GOODSPENTERPRISECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.FILEHEADERGUIDRF AS GOODSPFILEHEADERGUID" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDEMPLOYEECODERF AS GOODSPUPDEMPLOYEECODE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID1RF AS GOODSPUPDASSEMBLYID1" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDASSEMBLYID2RF AS GOODSPUPDASSEMBLYID2" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.PRICESTARTDATERF AS GOODSPPRICESTARTDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.LISTPRICERF AS GOODSPLISTPRICE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.SALESUNITCOSTRF AS GOODSPSALESUNITCOST" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.STOCKRATERF AS GOODSPSTOCKRATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OPENPRICEDIVRF AS GOODSPOPENPRICEDIV" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.OFFERDATERF AS GOODSPOFFERDATE" + Environment.NewLine;
                selectstring += "    ,GOODSPRICE.UPDATEDATERF AS GOODSPUPDATEDATE" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                selectstring += "    ,WAREHOUSE.WAREHOUSENAMERF AS WAREHOUSENAME" + Environment.NewLine;
                selectstring += "    ,STOCK.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNT" + Environment.NewLine;
                selectstring += "    ,STOCK.WAREHOUSESHELFNORF AS WAREHOUSESHELFNO" + Environment.NewLine;
                selectstring += "FROM GOODSURF AS GOODS" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSPRICE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND GOODSPRICE.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN MAKERURF AS MAKERU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     MAKERU.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND MAKERU.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGOODS.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGOODS.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD.USERGUIDEDIVCDRF=70" + Environment.NewLine;
                selectstring += " AND USERGD.GUIDECODERF=GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectstring += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectstring += "LEFT JOIN WAREHOUSERF AS WAREHOUSE" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     WAREHOUSE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND WAREHOUSE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN BLGROUPURF AS BLGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     BLGROUPU.ENTERPRISECODERF=BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND BLGROUPU.BLGROUPCODERF=BLGOODS.BLGROUPCODERF" + Environment.NewLine;
                selectstring += "LEFT JOIN USERGDBDURF AS USERGD01" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     USERGD01.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND USERGD01.USERGUIDEDIVCDRF=71" + Environment.NewLine;
                selectstring += " AND USERGD01.GUIDECODERF=BLGROUPU.GOODSLGROUPRF" + Environment.NewLine;
                selectstring += "LEFT JOIN GOODSGROUPURF AS GOODSGROUPU" + Environment.NewLine;
                selectstring += "ON" + Environment.NewLine;
                selectstring += "     GOODSGROUPU.ENTERPRISECODERF=BLGROUPU.ENTERPRISECODERF" + Environment.NewLine;
                selectstring += " AND GOODSGROUPU.GOODSMGROUPRF=BLGROUPU.GOODSMGROUPRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectstring, sqlConnection);

                if (paralist != null)
                    sqlCommand.CommandText += MakeWhereStringMultiCondition(ref sqlCommand, trgType, paralist, logicalMode);
                else
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, trgType, goodsrelationdataWork, logicalMode);

                sqlCommand.CommandText += "ORDER BY GOODSPRICE.PRICESTARTDATERF DESC, GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC" + Environment.NewLine;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsUnitDataWorkFromReader(ref myReader));

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

            goodsrelationdataWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の商品構成取得情報LISTを戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiCondition(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retObj = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchMultiConditionProc(out retObj, paraObj, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsURelationDataDB.Search");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 指定された条件の商品構成取得情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品構成取得情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        public int SearchMultiConditionProc(out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();

            ArrayList goodsrelationdataWorkList = paraObj as ArrayList;
            if (goodsrelationdataWorkList != null)
            {
            }

            CustomSerializeArrayList paraList = null;
            ArrayList retal = null;
            object paratype = new GoodsCndtnWork();
            status = SearchGoodsURelationDataProc(out retal, null, null, paraList, readMode, logicalMode, ref sqlConnection);
            retCSAList.Add(retal);

            retObj = retCSAList;

            return status;
        }


        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="goodsRelationDataWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, Type trgType, GoodsCndtnWork goodsRelationDataWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");
            string maintable = "";

            maintable = "GOODS";
            //企業コード
            retstring.Append(maintable + ".ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND " + maintable + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
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
            if (string.IsNullOrEmpty(goodsRelationDataWork.GoodsNameKana) == false)
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

            //JANコード
            if (string.IsNullOrEmpty(goodsRelationDataWork.Jan) == false)
            {
                retstring.Append("AND GOODS.JANRF=@JAN ");
                SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                paraJan.Value = SqlDataMediator.SqlSetString(goodsRelationDataWork.Jan);
            }

            //BL商品コード
            if (goodsRelationDataWork.BLGoodsCode > 0)
            {
              retstring.Append("AND GOODS.BLGOODSCODERF=@BLGOODSCODE ");
              SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
              paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGoodsCode);
            }

            //商品大分類コード(BLグループを参照)
            if (goodsRelationDataWork.GoodsLGroup > 0)
            {
                retstring.Append("AND BLGROUPU.GOODSLGROUPRF=@GOODSLGROUP ");
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GoodsLGroup", SqlDbType.Int);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsLGroup);
            }

            //商品中分類コード
            if (goodsRelationDataWork.GoodsMGroup > 0)
            {
                retstring.Append("AND BLGROUPU.GOODSMGROUPRF=@GOODSMGROUP ");
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.GoodsMGroup);
            }

            //グループコード
            if (goodsRelationDataWork.BLGroupCode > 0)
            {
                retstring.Append("AND BLGROUPU.BLGROUPCODERF=@BLGROUPCODE ");
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(goodsRelationDataWork.BLGroupCode);
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="trgType">取得対象区分</param>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        private string MakeWhereStringMultiCondition(ref SqlCommand sqlCommand, Type trgType, ArrayList paraList, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string countstr = "";
            StringBuilder retstring = new StringBuilder();
            retstring.Append("WHERE ");
            GoodsCndtnWork wkcond = null;

            if (paraList == null) return "";
            if (paraList.Count < 0) return "";

            wkcond = paraList[0] as GoodsCndtnWork;

            //企業コード
            retstring.Append("GOODS.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wkcond.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            for (int i = 0; i < paraList.Count; i++)
            {
                wkcond = paraList[i] as GoodsCndtnWork;
                countstr = i.ToString();
                if (wkstring != "") wkstring += "OR ";
                wkstring += "( GOODS.GOODSMAKERCDRF=@GOODSMAKERCD" + countstr + " AND GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN" + countstr + " ) ";

                //メーカーコード
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + countstr, SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(wkcond.GoodsMakerCd);

                //商品コード
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN" + countstr, SqlDbType.NChar);
                
                
                if (SqlDataMediator.SqlSetString(wkcond.GoodsNo) != DBNull.Value)
                {
                  paraGoodsNo.Value = SqlDataMediator.SqlSetString(wkcond.GoodsNo);
                }
                else
                {
                  paraGoodsNo.Value = "";
                }
            }
            retstring.Append(wkstring);

            return retstring.ToString();
        }
        #endregion

        #region [クラス格納処理]

        #region [商品連結データクラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsUnitDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsUnitDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        /// </remarks>
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsUnitDataWork wkGoodsUnitDataWork = new GoodsUnitDataWork();

            #region クラスへ格納
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAME"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAME"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUP"));
            wkGoodsUnitDataWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            wkGoodsUnitDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUP"));
            wkGoodsUnitDataWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAME"));
            wkGoodsUnitDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE"));
            wkGoodsUnitDataWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAME"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAME"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODE"));
            wkGoodsUnitDataWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODE"));
            wkGoodsUnitDataWork.GoodsPriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICECREATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATETIME"));
            wkGoodsUnitDataWork.GoodsPriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEENTERPRISECODE"));
            wkGoodsUnitDataWork.GoodsPriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GOODSPRICEFILEHEADERGUID"));
            wkGoodsUnitDataWork.GoodsPriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDEMPLOYEECODE"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID1"));
            wkGoodsUnitDataWork.GoodsPriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSPRICEUPDASSEMBLYID2"));
            wkGoodsUnitDataWork.GoodsPricePriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEPRICESTARTDATE"));
            wkGoodsUnitDataWork.GoodsPriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICELISTPRICE"));
            wkGoodsUnitDataWork.GoodsPriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESALESUNITCOST"));
            wkGoodsUnitDataWork.GoodsPriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICESTOCKRATE"));
            wkGoodsUnitDataWork.GoodsPriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSPRICEOPENPRICEDIV"));
            wkGoodsUnitDataWork.GoodsPriceOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEOFFERDATE"));
            wkGoodsUnitDataWork.GoodsPriceUpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GOODSPRICEUPDATEDATE"));
            wkGoodsUnitDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
            wkGoodsUnitDataWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAME"));
            wkGoodsUnitDataWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNT"));
            wkGoodsUnitDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
            #endregion

            return wkGoodsUnitDataWork;
        }
        #endregion

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.06</br>
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

        #region 商品系データを一括して扱う処理
        /// <summary>
        /// 商品マスタ情報を登録、更新します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        /// <br></br>
        /// <br>Update Note: 2007.08.27 長内 DC.NS用に修正</br>
        public int WriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();

                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //商品マスタ
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }
                
                if (goodsUnitDataList != null)
                {
                  CopyToGoodsAndPriceWork(goodsUnitDataList,ref goodsList,ref goodsPriceList);
                }
                
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
 
                //商品マスタ更新処理
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                }

                //価格マスタ更新処理
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList writeErrorList = new ArrayList();
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                }

                retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList));
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                
                //戻り値セット
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
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

        // 2008.06.12 add start --------------------------------->>
        /// <summary>
        /// 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）情報を新規登録(商品マスタに存在がない場合のみ)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        /// <br></br>
        public int ReadNewWriteRelation(ref object goodsWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();

                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //商品マスタ
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 商品存在確認
                if (goodsUnitDataList != null)
                {
                    ReadCopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList, ref sqlConnection, ref sqlTransaction);
                }

                //商品マスタ更新処理
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.WriteGoodsUProc(ref goodsList, ref sqlConnection, ref sqlTransaction);
                }

                //価格マスタ更新処理
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList writeErrorList = new ArrayList();
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.WriteGoodsPriceProc(ref goodsPriceList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                }

                retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList));

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }

                //戻り値セット
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Write(ref object goodsWork)");
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
        // 2008.06.12 add end -----------------------------------<<

        /// <summary>
        /// GoodsUWork,GoodsPriceUWork → 連結クラス 
        /// </summary>
        /// <param name="goodsList">商品マスタリスト</param>
        /// <param name="goodsPriceList">商品連結リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private ArrayList CopyToGoodsUnitDataList(ArrayList goodsList, ArrayList goodsPriceList)
        {
            ArrayList al = new ArrayList();

            Hashtable goodsHashTable = new Hashtable();

            //商品マスタの情報をHashTableに退避
            for (int i = 0; i < goodsList.Count; i++)
            {

                GoodsUWork goodsUWork = goodsList[i] as GoodsUWork;
                goodsHashTable.Add(((Int32)goodsUWork.GoodsMakerCd).ToString("d4") + goodsUWork.GoodsNo,goodsUWork);

            }

            for (int i = 0; i < goodsPriceList.Count; i++)
            {
                GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

                //価格マスタ          
                GoodsPriceUWork goodsPriceUWork = goodsPriceList[i] as GoodsPriceUWork;

                goodsUnitDataWork.GoodsPriceCreateDateTime = goodsPriceUWork.CreateDateTime;
                goodsUnitDataWork.GoodsPriceUpdateDateTime = goodsPriceUWork.UpdateDateTime;
                goodsUnitDataWork.GoodsPriceEnterpriseCode = goodsPriceUWork.EnterpriseCode;
                goodsUnitDataWork.GoodsPriceFileHeaderGuid = goodsPriceUWork.FileHeaderGuid;
                goodsUnitDataWork.GoodsPriceUpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode;
                goodsUnitDataWork.GoodsPriceUpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1;
                goodsUnitDataWork.GoodsPriceUpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2;
                goodsUnitDataWork.GoodsPricePriceStartDate = goodsPriceUWork.PriceStartDate;
                goodsUnitDataWork.GoodsPriceListPrice = goodsPriceUWork.ListPrice;
                goodsUnitDataWork.GoodsPriceSalesUnitCost = goodsPriceUWork.SalesUnitCost;
                goodsUnitDataWork.GoodsPriceStockRate = goodsPriceUWork.StockRate;
                goodsUnitDataWork.GoodsPriceOpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
                goodsUnitDataWork.GoodsPriceOfferDate = goodsPriceUWork.OfferDate;
                goodsUnitDataWork.GoodsPriceUpdateDate = goodsPriceUWork.UpdateDate;

                //商品マスタ
                GoodsUWork goodsUWork = ((GoodsUWork)goodsHashTable[goodsPriceUWork.GoodsMakerCd.ToString("d4") + goodsPriceUWork.GoodsNo]);

                goodsUnitDataWork.CreateDateTime = goodsUWork.CreateDateTime;
                goodsUnitDataWork.UpdateDateTime = goodsUWork.UpdateDateTime;
                goodsUnitDataWork.EnterpriseCode = goodsUWork.EnterpriseCode;
                goodsUnitDataWork.FileHeaderGuid = goodsUWork.FileHeaderGuid;
                goodsUnitDataWork.UpdEmployeeCode = goodsUWork.UpdEmployeeCode;
                goodsUnitDataWork.UpdAssemblyId1 = goodsUWork.UpdAssemblyId1;
                goodsUnitDataWork.UpdAssemblyId2 = goodsUWork.UpdAssemblyId2;
                goodsUnitDataWork.LogicalDeleteCode = goodsUWork.LogicalDeleteCode;
                goodsUnitDataWork.GoodsMakerCd = goodsUWork.GoodsMakerCd;
                goodsUnitDataWork.GoodsNo = goodsUWork.GoodsNo;
                goodsUnitDataWork.GoodsName = goodsUWork.GoodsName;
                goodsUnitDataWork.GoodsNameKana = goodsUWork.GoodsNameKana;
                goodsUnitDataWork.Jan = goodsUWork.Jan;
                goodsUnitDataWork.BLGoodsCode = goodsUWork.BLGoodsCode;
                goodsUnitDataWork.DisplayOrder = goodsUWork.DisplayOrder;
                goodsUnitDataWork.TaxationDivCd = goodsUWork.TaxationDivCd;
                goodsUnitDataWork.GoodsRateRank = goodsUWork.GoodsRateRank;
                goodsUnitDataWork.GoodsNoNoneHyphen = goodsUWork.GoodsNoNoneHyphen;
                goodsUnitDataWork.OfferDate = goodsUWork.OfferDate;
                goodsUnitDataWork.GoodsKindCode = goodsUWork.GoodsKindCode;
                goodsUnitDataWork.GoodsNote1 = goodsUWork.GoodsNote1;
                goodsUnitDataWork.GoodsNote2 = goodsUWork.GoodsNote2;
                goodsUnitDataWork.GoodsSpecialNote = goodsUWork.GoodsSpecialNote;
                goodsUnitDataWork.EnterpriseGanreCode = goodsUWork.EnterpriseGanreCode;
                goodsUnitDataWork.UpdateDate = goodsUWork.UpdateDate;

                al.Add(goodsUnitDataWork);
            }
            
           return al;
        }
        
        /// <summary>
        /// 連結クラス → GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">連結リスト</param>
        /// <param name="goodsList">商品リスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private ArrayList CopyToGoodsAndPriceWork(ArrayList goodsUnitDataList,ref ArrayList goodsList ,ref ArrayList goodsPriceList)
        {
            ArrayList al = new ArrayList();
            string goodsNo = "";
            Int32 goodsMakerCd = 0;

            foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
            {
              GoodsUWork goodsUWork = new GoodsUWork();
              GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

              //商品マスタ更新項目セット
              goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
              goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
              goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
              goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
              goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
              goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
              goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
              goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
              goodsUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
              goodsUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
              goodsUWork.GoodsName = goodsUnitDataWork.GoodsName;
              goodsUWork.GoodsNameKana = goodsUnitDataWork.GoodsNameKana;
              goodsUWork.Jan = goodsUnitDataWork.Jan;
              goodsUWork.BLGoodsCode = goodsUnitDataWork.BLGoodsCode;
              goodsUWork.DisplayOrder = goodsUnitDataWork.DisplayOrder;
              goodsUWork.GoodsRateRank = goodsUnitDataWork.GoodsRateRank;
              goodsUWork.TaxationDivCd = goodsUnitDataWork.TaxationDivCd;
              goodsUWork.GoodsNoNoneHyphen = goodsUnitDataWork.GoodsNoNoneHyphen;
              goodsUWork.OfferDate = goodsUnitDataWork.OfferDate;
              goodsUWork.GoodsKindCode = goodsUnitDataWork.GoodsKindCode;
              goodsUWork.GoodsNote1 = goodsUnitDataWork.GoodsNote1;
              goodsUWork.GoodsNote2 = goodsUnitDataWork.GoodsNote2;
              goodsUWork.GoodsSpecialNote = goodsUnitDataWork.GoodsSpecialNote;
              goodsUWork.EnterpriseGanreCode = goodsUnitDataWork.EnterpriseGanreCode;
              goodsUWork.UpdateDate = goodsUnitDataWork.UpdateDate;

              if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd)) goodsList.Add(goodsUWork);
              goodsNo = goodsUWork.GoodsNo;
              goodsMakerCd = goodsUWork.GoodsMakerCd;

              //価格マスタ更新項目セット
              goodsPriceUWork.CreateDateTime = goodsUnitDataWork.GoodsPriceCreateDateTime;
              goodsPriceUWork.UpdateDateTime = goodsUnitDataWork.GoodsPriceUpdateDateTime;
              goodsPriceUWork.EnterpriseCode = goodsUnitDataWork.GoodsPriceEnterpriseCode;
              goodsPriceUWork.FileHeaderGuid = goodsUnitDataWork.GoodsPriceFileHeaderGuid;
              goodsPriceUWork.UpdEmployeeCode = goodsUnitDataWork.GoodsPriceUpdEmployeeCode;
              goodsPriceUWork.UpdAssemblyId1 = goodsUnitDataWork.GoodsPriceUpdAssemblyId1;
              goodsPriceUWork.UpdAssemblyId2 = goodsUnitDataWork.GoodsPriceUpdAssemblyId2;
              goodsPriceUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
              goodsPriceUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
              goodsPriceUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
              goodsPriceUWork.PriceStartDate = goodsUnitDataWork.GoodsPricePriceStartDate;
              goodsPriceUWork.ListPrice = goodsUnitDataWork.GoodsPriceListPrice;
              goodsPriceUWork.SalesUnitCost = goodsUnitDataWork.GoodsPriceSalesUnitCost;
              goodsPriceUWork.StockRate = goodsUnitDataWork.GoodsPriceStockRate;
              goodsPriceUWork.OpenPriceDiv = goodsUnitDataWork.GoodsPriceOpenPriceDiv;
              goodsPriceUWork.OfferDate = goodsUnitDataWork.GoodsPriceOfferDate;
              goodsPriceUWork.UpdateDate = goodsUnitDataWork.GoodsPriceUpdateDate; 

              goodsPriceList.Add(goodsPriceUWork);

            }

            return al;
        }
        
        // 2008.06.12 add start ------------------------------->>
        /// <summary>
        /// 連結クラス → GoodsUWork,GoodsPriceUWork
        /// </summary>
        /// <param name="goodsUnitDataList">連結リスト</param>
        /// <param name="goodsList">商品リスト</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private ArrayList ReadCopyToGoodsAndPriceWork(ArrayList goodsUnitDataList, ref ArrayList goodsList, ref ArrayList goodsPriceList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string goodsNo = "";
            Int32 goodsMakerCd = 0;

            string sqlTxt = string.Empty;
            sqlTxt += "SELECT" + Environment.NewLine;
            sqlTxt += "   GOODS.UPDATEDATETIMERF" + Environment.NewLine;
            sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
            sqlTxt += "FROM GOODSURF AS GOODS" + Environment.NewLine;
            sqlTxt += "WHERE" + Environment.NewLine;
            sqlTxt += "  GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            sqlTxt += "  AND GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

            //Selectコマンドの生成
            sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            foreach (GoodsUnitDataWork goodsUnitDataWork in goodsUnitDataList)
            {
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsUnitDataWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsUnitDataWork.GoodsNo);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                }
                else
                {
                    GoodsUWork goodsUWork = new GoodsUWork();
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

                    //商品マスタ更新項目セット
                    goodsUWork.CreateDateTime = goodsUnitDataWork.CreateDateTime;
                    goodsUWork.UpdateDateTime = goodsUnitDataWork.UpdateDateTime;
                    goodsUWork.EnterpriseCode = goodsUnitDataWork.EnterpriseCode;
                    goodsUWork.FileHeaderGuid = goodsUnitDataWork.FileHeaderGuid;
                    goodsUWork.UpdEmployeeCode = goodsUnitDataWork.UpdEmployeeCode;
                    goodsUWork.UpdAssemblyId1 = goodsUnitDataWork.UpdAssemblyId1;
                    goodsUWork.UpdAssemblyId2 = goodsUnitDataWork.UpdAssemblyId2;
                    goodsUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                    goodsUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
                    goodsUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
                    goodsUWork.GoodsName = goodsUnitDataWork.GoodsName;
                    goodsUWork.GoodsNameKana = goodsUnitDataWork.GoodsNameKana;
                    goodsUWork.Jan = goodsUnitDataWork.Jan;
                    goodsUWork.BLGoodsCode = goodsUnitDataWork.BLGoodsCode;
                    goodsUWork.DisplayOrder = goodsUnitDataWork.DisplayOrder;
                    goodsUWork.GoodsRateRank = goodsUnitDataWork.GoodsRateRank;
                    goodsUWork.TaxationDivCd = goodsUnitDataWork.TaxationDivCd;
                    goodsUWork.GoodsNoNoneHyphen = goodsUnitDataWork.GoodsNoNoneHyphen;
                    goodsUWork.OfferDate = goodsUnitDataWork.OfferDate;
                    goodsUWork.GoodsKindCode = goodsUnitDataWork.GoodsKindCode;
                    goodsUWork.GoodsNote1 = goodsUnitDataWork.GoodsNote1;
                    goodsUWork.GoodsNote2 = goodsUnitDataWork.GoodsNote2;
                    goodsUWork.GoodsSpecialNote = goodsUnitDataWork.GoodsSpecialNote;
                    goodsUWork.EnterpriseGanreCode = goodsUnitDataWork.EnterpriseGanreCode;
                    goodsUWork.UpdateDate = goodsUnitDataWork.UpdateDate;

                    if ((goodsNo != goodsUWork.GoodsNo) || (goodsMakerCd != goodsUWork.GoodsMakerCd)) goodsList.Add(goodsUWork);
                    goodsNo = goodsUWork.GoodsNo;
                    goodsMakerCd = goodsUWork.GoodsMakerCd;

                    //価格マスタ更新項目セット
                    goodsPriceUWork.CreateDateTime = goodsUnitDataWork.GoodsPriceCreateDateTime;
                    goodsPriceUWork.UpdateDateTime = goodsUnitDataWork.GoodsPriceUpdateDateTime;
                    goodsPriceUWork.EnterpriseCode = goodsUnitDataWork.GoodsPriceEnterpriseCode;
                    goodsPriceUWork.FileHeaderGuid = goodsUnitDataWork.GoodsPriceFileHeaderGuid;
                    goodsPriceUWork.UpdEmployeeCode = goodsUnitDataWork.GoodsPriceUpdEmployeeCode;
                    goodsPriceUWork.UpdAssemblyId1 = goodsUnitDataWork.GoodsPriceUpdAssemblyId1;
                    goodsPriceUWork.UpdAssemblyId2 = goodsUnitDataWork.GoodsPriceUpdAssemblyId2;
                    goodsPriceUWork.LogicalDeleteCode = goodsUnitDataWork.LogicalDeleteCode;
                    goodsPriceUWork.GoodsNo = goodsUnitDataWork.GoodsNo;
                    goodsPriceUWork.GoodsMakerCd = goodsUnitDataWork.GoodsMakerCd;
                    goodsPriceUWork.PriceStartDate = goodsUnitDataWork.GoodsPricePriceStartDate;
                    goodsPriceUWork.ListPrice = goodsUnitDataWork.GoodsPriceListPrice;
                    goodsPriceUWork.SalesUnitCost = goodsUnitDataWork.GoodsPriceSalesUnitCost;
                    goodsPriceUWork.StockRate = goodsUnitDataWork.GoodsPriceStockRate;
                    goodsPriceUWork.OpenPriceDiv = goodsUnitDataWork.GoodsPriceOpenPriceDiv;
                    goodsPriceUWork.OfferDate = goodsUnitDataWork.GoodsPriceOfferDate;
                    goodsPriceUWork.UpdateDate = goodsUnitDataWork.GoodsPriceUpdateDate;

                    goodsPriceList.Add(goodsPriceUWork);
                }
            }

            return al;
        }
        // 2008.06.12 add end ---------------------------------<<

        /// <summary>
        /// 商品マスタ情報を論理削除します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報を論理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int LogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 0);
        }

        /// <summary>
        /// 論理削除商品マスタ情報を復活します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除商品マスタ情報を復活します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int RevivalLogicalDeleteRelation(ref object goodsWork)
        {
            return LogicalDeleteGoodsRelation(ref goodsWork, 1);
        }

        /// <summary>
        /// 商品マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        private int LogicalDeleteGoodsRelation(ref object goodsWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();

                //パラメータのキャスト
                CustomSerializeArrayList csaList = goodsWork as CustomSerializeArrayList;
                if (csaList == null) return status;

                for (int i = 0; i < csaList.Count; i++)
                {
                    ArrayList wkal = csaList[i] as ArrayList;
                    if (wkal != null)
                    {
                        if (wkal.Count > 0)
                        {
                            //商品マスタ
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }

                if (goodsUnitDataList != null)
                {
                    CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList);
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //商品マスタ更新処理
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.LogicalDeleteGoodsUProc(ref goodsList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                //価格マスタ更新処理
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.LogicalDeleteGoodsPriceProc(ref goodsPriceList, procMode, ref sqlConnection, ref sqlTransaction);
                }

                retList.Add(CopyToGoodsUnitDataList(goodsList, goodsPriceList));

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                goodsWork = retList;
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "GoodsDB.LogicalDeleteGoods :" + procModestr);

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
        /// 商品マスタ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">商品マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 商品マスタ情報を物理削除します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.12.08</br>
        public int DeleteRelation(object paraobj)
        {
            
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                ArrayList goodsUnitDataList = null;
                ArrayList goodsList = new ArrayList();
                ArrayList goodsPriceList = new ArrayList();

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
                            //商品マスタ
                            if (wkal[0] is GoodsUnitDataWork) goodsUnitDataList = wkal;
                        }
                    }
                }

                if (goodsUnitDataList != null)
                {
                    CopyToGoodsAndPriceWork(goodsUnitDataList, ref goodsList, ref goodsPriceList);
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //商品マスタ削除処理
                if (goodsList != null)
                {
                    GoodsUDB goodsUDB = new GoodsUDB();
                    status = goodsUDB.DeleteGoodsUProc(goodsList, ref sqlConnection, ref sqlTransaction);
                }

                //価格マスタ削除処理
                if (goodsPriceList != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsPriceUDB goodsPriceDB = new GoodsPriceUDB();
                    status = goodsPriceDB.DeleteGoodsPriceProc(goodsPriceList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "GoodsDB.Delete");
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

        #endregion

    }
}
