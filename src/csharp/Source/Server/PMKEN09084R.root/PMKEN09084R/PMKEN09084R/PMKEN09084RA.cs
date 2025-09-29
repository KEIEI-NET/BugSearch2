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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 代替マスタ新旧関連表示DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 代替マスタ新旧関連表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class PartsSubstDspDB : RemoteDB, IPartsSubstDspDB
    {
        /// <summary>
        /// 代替マスタ新旧関連表示DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        public PartsSubstDspDB()
            :
            base("PMKEN09086D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUSearchResultWork", "PARTSSUBSTURF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の代替マスタ新旧関連表示データを戻します
        /// </summary>
        /// <param name="PartsSubstUSearchResultWork">検索結果</param>
        /// <param name="PartsSubstUSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の代替マスタ新旧関連表示データを戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        public int Search(out object PartsSubstUSearchResultWork, object PartsSubstUSearchParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            PartsSubstUSearchResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPartsSubstDsp(out PartsSubstUSearchResultWork, PartsSubstUSearchParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsSubstDspDB.Search");
                PartsSubstUSearchResultWork = new ArrayList();
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
        /// 指定された条件の代替マスタ新旧関連表示データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objPartsSubstUSearchResultWork">検索結果</param>
        /// <param name="objPartsSubstUSearchParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の代替マスタ新旧関連表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        private int SearchPartsSubstDsp(out object objPartsSubstUSearchResultWork, object objPartsSubstUSearchParamWork, ref SqlConnection sqlConnection)
        {
            PartsSubstUSearchParamWork paramWork = null;

            ArrayList paramWorkList = objPartsSubstUSearchParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objPartsSubstUSearchParamWork as PartsSubstUSearchParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as PartsSubstUSearchParamWork;
            }

            ArrayList PartsSubstUSearchResultWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 代替マスタ新旧関連表示データを取得
            status = SearchPartsSubstDspProc(out PartsSubstUSearchResultWork, paramWork, ref sqlConnection);

            objPartsSubstUSearchResultWork = PartsSubstUSearchResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchPartsSubstDspProc]
        /// <summary>
        /// 指定された条件の代替マスタ新旧関連表示データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="PartsSubstUSearchResultWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の代替マスタ新旧関連表示データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        private int SearchPartsSubstDspProc(out ArrayList PartsSubstUSearchResultWorkList, PartsSubstUSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();            

            string sqlText   = string.Empty;
            string GoodsNoID = string.Empty;
            string MakerCdID = string.Empty;

            if (paramWork.SearchDiv == 0) // 0:代替先,1:代替元
            {
                GoodsNoID = "CHGSRCGOODSNORF";
                MakerCdID = "CHGSRCMAKERCDRF";
            }
            else
            {
                GoodsNoID = "CHGDESTGOODSNORF";
                MakerCdID = "CHGDESTMAKERCDRF";
            }

            try
            {
                for (int i = 0; i < 11; i++)
                {
                    if (paramWork.ChgSrcGoodsNo == "" || paramWork.ChgSrcMakerCd == 0) break;
 
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    #region [SELECT]
                    // SELECT
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += " MAIN.ENTERPRISECODE  AS ENTERPRISECODE," + Environment.NewLine;                        // 企業コード
                    sqlText += " MAIN.CHGSRCMAKERCD AS CHGSRCMAKERCD," + Environment.NewLine;                           // 変換元メーカー
                    sqlText += " MAIN.CHGSRCGOODSNO AS CHGSRCGOODSNO," + Environment.NewLine;                           //   〃  商品番号
                    sqlText += " MAIN.CHGSRCGOODSNONONEHP AS CHGSRCGOODSNONONEHP," + Environment.NewLine;               //   〃  ハイフン無商品番号
                    sqlText += " SRCSTOCK1.WAREHOUSECODERF AS SRCWAREHOUSECODE1," + Environment.NewLine;                // 優先１倉庫コード
                    sqlText += " SRCSTOCK1.WAREHOUSESHELFNORF AS SRCWAREHOUSESHELFNO1," + Environment.NewLine;          //   〃  棚番
                    sqlText += " SRCSTOCK1.DUPLICATIONSHELFNO1RF AS SRCDUPLICATIONSHELFNO11," + Environment.NewLine;    //   〃  重複棚番1
                    sqlText += " SRCSTOCK1.DUPLICATIONSHELFNO2RF AS SRCDUPLICATIONSHELFNO21," + Environment.NewLine;    //   〃  重複棚番2
                    sqlText += " SRCSTOCK1.SHIPMENTPOSCNTRF AS SRCSHIPMENTPOSCNT1," + Environment.NewLine;              //   〃  現在庫数
                    sqlText += " SRCSTOCK2.WAREHOUSECODERF AS SRCWAREHOUSECODE2," + Environment.NewLine;                // 優先２倉庫コード
                    sqlText += " SRCSTOCK2.WAREHOUSESHELFNORF AS SRCWAREHOUSESHELFNO2," + Environment.NewLine;          //   〃  棚番
                    sqlText += " SRCSTOCK2.DUPLICATIONSHELFNO1RF AS SRCDUPLICATIONSHELFNO12," + Environment.NewLine;    //   〃  重複棚番1
                    sqlText += " SRCSTOCK2.DUPLICATIONSHELFNO2RF AS SRCDUPLICATIONSHELFNO22," + Environment.NewLine;    //   〃  重複棚番2
                    sqlText += " SRCSTOCK2.SHIPMENTPOSCNTRF AS SRCSHIPMENTPOSCNT2," + Environment.NewLine;              //   〃  現在庫数
                    sqlText += " SRCSTOCK3.WAREHOUSECODERF AS SRCWAREHOUSECODE3," + Environment.NewLine;                // 優先３倉庫コード
                    sqlText += " SRCSTOCK3.WAREHOUSESHELFNORF AS SRCWAREHOUSESHELFNO3," + Environment.NewLine;          //   〃  棚番
                    sqlText += " SRCSTOCK3.DUPLICATIONSHELFNO1RF AS SRCDUPLICATIONSHELFNO13," + Environment.NewLine;    //   〃  重複棚番1
                    sqlText += " SRCSTOCK3.DUPLICATIONSHELFNO2RF AS SRCDUPLICATIONSHELFNO23," + Environment.NewLine;    //   〃  重複棚番2
                    sqlText += " SRCSTOCK3.SHIPMENTPOSCNTRF AS SRCSHIPMENTPOSCNT3," + Environment.NewLine;              //   〃  現在庫数
                    sqlText += " MAIN.CHGDESTMAKERCD AS CHGDESTMAKERCD," + Environment.NewLine;                         // 変換先メーカー
                    sqlText += " MAIN.CHGDESTGOODSNO AS CHGDESTGOODSNO," + Environment.NewLine;                         //   〃  商品番号
                    sqlText += " MAIN.CHGDESTGOODSNONONEHP AS CHGDESTGOODSNONONEHP," + Environment.NewLine;             //   〃  ハイフン無商品番号
                    sqlText += " DESTSTOCK1.WAREHOUSECODERF AS DESTWAREHOUSECODE1," + Environment.NewLine;              // 優先１倉庫コード
                    sqlText += " DESTSTOCK1.WAREHOUSESHELFNORF AS DESTWAREHOUSESHELFNO1," + Environment.NewLine;        //   〃  棚番
                    sqlText += " DESTSTOCK1.DUPLICATIONSHELFNO1RF AS DESTDUPLICATIONSHELFNO11," + Environment.NewLine;  //   〃  重複棚番1
                    sqlText += " DESTSTOCK1.DUPLICATIONSHELFNO2RF AS DESTDUPLICATIONSHELFNO21," + Environment.NewLine;  //   〃  重複棚番2
                    sqlText += " DESTSTOCK1.SHIPMENTPOSCNTRF AS DESTSHIPMENTPOSCNT1," + Environment.NewLine;            //   〃  現在庫数               
                    sqlText += " DESTSTOCK2.WAREHOUSECODERF AS DESTWAREHOUSECODE2," + Environment.NewLine;              // 優先２倉庫コード
                    sqlText += " DESTSTOCK2.WAREHOUSESHELFNORF AS DESTWAREHOUSESHELFNO2," + Environment.NewLine;        //   〃  棚番
                    sqlText += " DESTSTOCK2.DUPLICATIONSHELFNO1RF AS DESTDUPLICATIONSHELFNO12," + Environment.NewLine;  //   〃  重複棚番1
                    sqlText += " DESTSTOCK2.DUPLICATIONSHELFNO2RF AS DESTDUPLICATIONSHELFNO22," + Environment.NewLine;  //   〃  重複棚番2
                    sqlText += " DESTSTOCK2.SHIPMENTPOSCNTRF AS DESTSHIPMENTPOSCNT2," + Environment.NewLine;            //   〃  現在庫数
                    sqlText += " DESTSTOCK3.WAREHOUSECODERF AS DESTWAREHOUSECODE3," + Environment.NewLine;              // 優先３倉庫コード
                    sqlText += " DESTSTOCK3.WAREHOUSESHELFNORF AS DESTWAREHOUSESHELFNO3," + Environment.NewLine;        //   〃  棚番
                    sqlText += " DESTSTOCK3.DUPLICATIONSHELFNO1RF AS DESTDUPLICATIONSHELFNO13," + Environment.NewLine;  //   〃  重複棚番1
                    sqlText += " DESTSTOCK3.DUPLICATIONSHELFNO2RF AS DESTDUPLICATIONSHELFNO23," + Environment.NewLine;  //   〃  重複棚番2
                    sqlText += " DESTSTOCK3.SHIPMENTPOSCNTRF AS DESTSHIPMENTPOSCNT3," + Environment.NewLine;            //   〃  現在庫数
                    sqlText += " MAIN.SECTWAREHOUSECD1 AS SECTWAREHOUSECD1," + Environment.NewLine;                     // 拠点優先倉庫1
                    sqlText += " MAIN.SECTWAREHOUSECD2 AS SECTWAREHOUSECD2," + Environment.NewLine;                     // 　　〃　倉庫2
                    sqlText += " MAIN.SECTWAREHOUSECD3 AS SECTWAREHOUSECD3" + Environment.NewLine;                      // 　　〃　倉庫3
                    // FROM
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += " (" + Environment.NewLine;
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += " PARTSSUB.ENTERPRISECODERF AS ENTERPRISECODE," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGSRCMAKERCDRF AS CHGSRCMAKERCD," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGSRCGOODSNORF AS CHGSRCGOODSNO," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGSRCGOODSNONONEHPRF AS CHGSRCGOODSNONONEHP," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGDESTMAKERCDRF AS CHGDESTMAKERCD," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGDESTGOODSNORF AS CHGDESTGOODSNO," + Environment.NewLine;
                    sqlText += " PARTSSUB.CHGDESTGOODSNONONEHPRF AS CHGDESTGOODSNONONEHP," + Environment.NewLine;
                    sqlText += " SECINF.SECTWAREHOUSECD1RF AS SECTWAREHOUSECD1," + Environment.NewLine;
                    sqlText += " SECINF.SECTWAREHOUSECD2RF AS SECTWAREHOUSECD2," + Environment.NewLine;
                    sqlText += " SECINF.SECTWAREHOUSECD3RF AS SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += " PARTSSUBSTURF AS PARTSSUB" + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    SECINFOSETRF AS SECINF " + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        SECINF.ENTERPRISECODERF = PARTSSUB.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "    AND SECINF.SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    // WHERE
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "    PARTSSUB.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND PARTSSUB.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "    AND PARTSSUB." + GoodsNoID + "= @GOODSNO" + Environment.NewLine;
                    sqlText += "    AND PARTSSUB." + MakerCdID + "= @MAKERCD" + Environment.NewLine;

                    sqlText += " ) AS MAIN" + Environment.NewLine;
                    // LEFT JOIN
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS SRCSTOCK1" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        SRCSTOCK1.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK1.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK1.GOODSMAKERCDRF = MAIN.CHGSRCMAKERCD" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK1.GOODSNORF = MAIN.CHGSRCGOODSNO" + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS SRCSTOCK2" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        SRCSTOCK2.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK2.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK2.GOODSMAKERCDRF = MAIN.CHGSRCMAKERCD" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK2.GOODSNORF = MAIN.CHGSRCGOODSNO" + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS SRCSTOCK3" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        SRCSTOCK3.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK3.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK3.GOODSMAKERCDRF = MAIN.CHGSRCMAKERCD" + Environment.NewLine;
                    sqlText += "    AND SRCSTOCK3.GOODSNORF = MAIN.CHGSRCGOODSNO    " + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS DESTSTOCK1" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        DESTSTOCK1.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK1.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD1" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK1.GOODSMAKERCDRF = MAIN.CHGDESTMAKERCD" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK1.GOODSNORF = MAIN.CHGDESTGOODSNO" + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS DESTSTOCK2" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        DESTSTOCK2.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK2.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD2" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK2.GOODSMAKERCDRF = MAIN.CHGDESTMAKERCD" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK2.GOODSNORF = MAIN.CHGDESTGOODSNO" + Environment.NewLine;
                    sqlText += " LEFT JOIN" + Environment.NewLine;
                    sqlText += "    STOCKRF AS DESTSTOCK3" + Environment.NewLine;
                    sqlText += "    ON" + Environment.NewLine;
                    sqlText += "        DESTSTOCK3.ENTERPRISECODERF = MAIN.ENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK3.WAREHOUSECODERF = MAIN.SECTWAREHOUSECD3" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK3.GOODSMAKERCDRF = MAIN.CHGDESTMAKERCD" + Environment.NewLine;
                    sqlText += "    AND DESTSTOCK3.GOODSNORF = MAIN.CHGDESTGOODSNO" + Environment.NewLine;
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@MAKERCD", SqlDbType.Int);
                    SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode);
                    paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.ChgSrcMakerCd);
                    paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.ChgSrcGoodsNo);

                    myReader = sqlCommand.ExecuteReader();
                    paramWork.ChgSrcMakerCd = 0;
                    paramWork.ChgSrcGoodsNo = "";

                    paramWork.ChgSrcMakerCd = 0;
                    paramWork.ChgSrcGoodsNo = "";

                    while (myReader.Read())
                    {
                        al.Add(CopyToPartsSubstDspWorkFromReader(ref myReader, paramWork));
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        if (paramWork.SearchDiv == 0) // 0:代替先,1:代替元
                        {
                            paramWork.ChgSrcMakerCd = ((PartsSubstUSearchResultWork)al[i]).ChgDestMakerCd;
                            paramWork.ChgSrcGoodsNo = ((PartsSubstUSearchResultWork)al[i]).ChgDestGoodsNo;
                        }
                    }
                    if (!myReader.IsClosed) myReader.Close();
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
                

            PartsSubstUSearchResultWorkList = al;

            return status;
        }
        #endregion  //SearchPartsSubstDspProc

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PartsSubstUSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>PartsSubstUSearchResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        private PartsSubstUSearchResultWork CopyToPartsSubstDspWorkFromReader(ref SqlDataReader myReader, PartsSubstUSearchParamWork paramWork)
        {
            PartsSubstUSearchResultWork PartsSubstUSearchResultWork = new PartsSubstUSearchResultWork();

            if (myReader != null)
            {
                # region クラスへ格納
                PartsSubstUSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                //PartsSubstUSearchResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODE"));
                // 変換元
                PartsSubstUSearchResultWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCD"));
                PartsSubstUSearchResultWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNO"));
                PartsSubstUSearchResultWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHP"));
                // 優先倉庫1
                PartsSubstUSearchResultWork.ChgSrcWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSECODE1"));
                PartsSubstUSearchResultWork.ChgSrcWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSESHELFNO1"));
                PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO11"));
                PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO21"));
                PartsSubstUSearchResultWork.ChgSrcShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SRCSHIPMENTPOSCNT1"));
                if (PartsSubstUSearchResultWork.ChgSrcWarehouseCode == "") // 優先倉庫1情報が空白の場合、優先倉庫2情報をセット
                {
                    // 優先倉庫2
                    PartsSubstUSearchResultWork.ChgSrcWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSECODE2"));
                    PartsSubstUSearchResultWork.ChgSrcWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSESHELFNO2"));
                    PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO12"));
                    PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO22"));
                    PartsSubstUSearchResultWork.ChgSrcShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SRCSHIPMENTPOSCNT2"));

                }
                if (PartsSubstUSearchResultWork.ChgSrcWarehouseCode == "") // 優先倉庫2情報が空白の場合、優先倉庫3情報をセット
                {
                    // 優先倉庫3
                    PartsSubstUSearchResultWork.ChgSrcWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSECODE3"));
                    PartsSubstUSearchResultWork.ChgSrcWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCWAREHOUSESHELFNO3"));
                    PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO13"));
                    PartsSubstUSearchResultWork.ChgSrcDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCDUPLICATIONSHELFNO23"));
                    PartsSubstUSearchResultWork.ChgSrcShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SRCSHIPMENTPOSCNT3"));

                }


                // 変換先
                PartsSubstUSearchResultWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCD"));
                PartsSubstUSearchResultWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNO"));
                PartsSubstUSearchResultWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHP"));
                // 優先倉庫1
                PartsSubstUSearchResultWork.ChgDestWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSECODE1"));
                PartsSubstUSearchResultWork.ChgDestWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSESHELFNO1"));
                PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO11"));
                PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO21"));
                PartsSubstUSearchResultWork.ChgDestShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DESTSHIPMENTPOSCNT1"));
                if (PartsSubstUSearchResultWork.ChgDestWarehouseCode == "") // 優先倉庫1情報が空白の場合、優先倉庫2情報をセット
                {
                    // 優先倉庫2
                    PartsSubstUSearchResultWork.ChgDestWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSECODE2"));
                    PartsSubstUSearchResultWork.ChgDestWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSESHELFNO2"));
                    PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO12"));
                    PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO22"));
                    PartsSubstUSearchResultWork.ChgDestShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DESTSHIPMENTPOSCNT2"));

                }
                if (PartsSubstUSearchResultWork.ChgDestWarehouseCode == "") // 優先倉庫2情報が空白の場合、優先倉庫3情報をセット
                {
                    // 優先倉庫3
                    PartsSubstUSearchResultWork.ChgDestWarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSECODE3"));
                    PartsSubstUSearchResultWork.ChgDestWarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTWAREHOUSESHELFNO3"));
                    PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO13"));
                    PartsSubstUSearchResultWork.ChgDestDuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DESTDUPLICATIONSHELFNO23"));
                    PartsSubstUSearchResultWork.ChgDestShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DESTSHIPMENTPOSCNT3"));

                }

                # endregion
            }

            return PartsSubstUSearchResultWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
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
    }

}
