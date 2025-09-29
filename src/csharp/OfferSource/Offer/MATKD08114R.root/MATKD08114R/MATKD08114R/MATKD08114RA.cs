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
    /// 商品マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.02.06</br>
    /// <br></br>
    /// <br>Update Note: DC.NS用に修正</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2007.08.16</br>
    /// </remarks>
    [Serializable]
    public class GoodsDB : RemoteDB, IGoodsDB
    {
        /// <summary>
        /// 商品マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        public GoodsDB()
            :
            base("MATKD08116D", "Broadleaf.Application.Remoting.ParamData.GoodsWork", "GOODSRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsWork">検索結果</param>
        /// <param name="paragoodsWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタ情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        public int Search(out object goodsWork, object paragoodsWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchGoodsProc(out goodsWork, paragoodsWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Search");
                goodsWork = new ArrayList();
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
        /// 指定された条件の商品マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsWork">検索結果</param>
        /// <param name="paragoodsWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        public int SearchGoodsProc(out object objgoodsWork, object paragoodsWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            GoodsWork goodsWork = null;

            ArrayList goodsWorkList = paragoodsWork as ArrayList;
            if (goodsWorkList == null)
            {
                goodsWork = paragoodsWork as GoodsWork;
            }
            else
            {
                if (goodsWorkList.Count > 0)
                    goodsWork = goodsWorkList[0] as GoodsWork;
            }

            int status = SearchGoodsProc(out goodsWorkList, goodsWork, readMode, logicalMode, ref sqlConnection);
            objgoodsWork = goodsWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsWorkList">検索結果</param>
        /// <param name="goodsWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>Update Note: DC.NS用に修正</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.16</br>
        public int SearchGoodsProc(out ArrayList goodsWorkList, GoodsWork goodsWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSRF AS GOODS" + Environment.NewLine;
                
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //商品番号
                if (string.IsNullOrEmpty(goodsWork.GoodsNo) == false)
                {
                  sqlTxt += " GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                  SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                  paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsWork.GoodsNo);
                }

                //商品メーカーコード
                if (goodsWork.GoodsMakerCd != 0)
                {
                  sqlTxt += " AND GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                  SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                  paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsWork.GoodsMakerCd);
                }

                string wkstring = "";
                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                  wkstring = " AND GOODS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                  wkstring = " AND GOODS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                  sqlTxt += wkstring;
                  SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsWork, logicalMode);
                sqlCommand.CommandText += sqlTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToGoodsWorkFromReader(ref myReader));

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

            goodsWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の商品マスタを戻します
        /// </summary>
        /// <param name="parabyte">GoodsWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                GoodsWork goodsWork = new GoodsWork();

                // XMLの読み込み
                goodsWork = (GoodsWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsWork));
                if (goodsWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref goodsWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(goodsWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsDB.Read");
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
        /// 指定された条件の商品マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsWork">GoodsWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// <br></br>
        /// <br>UpDateNote : DC.NS用に修正</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2007.08.16</br>
        public int ReadProc(ref GoodsWork goodsWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MAKERNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSHORTNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UNITNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.SALESORDERUNITRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSETDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "FROM GOODSRF AS GOODS" + Environment.NewLine;
                sqlTxt += "WHERE" + Environment.NewLine;
                sqlTxt += "       GOODS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND  GOODS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        goodsWork = CopyToGoodsWorkFromReader(ref myReader);
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsWork goodsWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

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
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.02.06</br>
        /// </remarks>
        private GoodsWork CopyToGoodsWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsWork wkGoodsWork = new GoodsWork();

            #region クラスへ格納
            wkGoodsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsWork.MakerName= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkGoodsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsWork.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsWork.GoodsShortName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSSHORTNAMERF"));
            wkGoodsWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsWork.Jan = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("JANRF"));
            wkGoodsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkGoodsWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
            wkGoodsWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
            wkGoodsWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            wkGoodsWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            wkGoodsWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            wkGoodsWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            wkGoodsWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
            wkGoodsWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
            wkGoodsWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkGoodsWork.GoodsSetDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSETDIVCDRF"));
            wkGoodsWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));

            #endregion

            return wkGoodsWork;
        }
        #endregion

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
