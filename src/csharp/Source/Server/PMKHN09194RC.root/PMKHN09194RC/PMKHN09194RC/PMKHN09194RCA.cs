//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（テキスト変換）
// プログラム概要   : 商品マスタテキスト変換  リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10902160-00  作成担当 : 高陽
// 作 成 日  K2013/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 呉元嘯
// 修 正 日  2020/08/20   修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタテキスト変換  リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタテキスト変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 高陽</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2020/08/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class GoodsTextExpDB : RemoteDB, IGoodsTextExpDB
    {
        #region [Constructor]
        /// <summary>
        /// 商品マスタテキスト変換  リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br></br>
        /// <br>Update Note:</br>
        /// </remarks>
        public GoodsTextExpDB()
            :
            base("PMKHN09196DC", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork", "GOODSURF")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の商品マスタLISTを戻します
        /// </summary>
        /// <param name="goodsTextExpRetWork">検索結果</param>
        /// <param name="goodsTextExpWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタLISTを戻します</br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        public int Search(out object goodsTextExpRetWork, object goodsTextExpWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            goodsTextExpRetWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out goodsTextExpRetWork, goodsTextExpWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsTextExpDB.Search");
                goodsTextExpRetWork = new ArrayList();
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
        #endregion

        #region [SearchProc]
        /// <summary>
        /// 指定された条件の商品マスタLISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsTextExpRetWorkList">検索結果</param>
        /// <param name="goodsTextExpWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品マスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProc(out object goodsTextExpRetWorkList, object goodsTextExpWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList retList = new ArrayList();

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                GoodsTextExpWork paraWork = goodsTextExpWork as GoodsTextExpWork;
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 対象テーブル
                // GOODSURF      GODSU    商品マスタ（ユーザー登録）
                // GOODSPRICEURF GODSP    価格マスタ（ユーザー登録）
                // BLGOODSCDURF  BLGODSU  ＢＬ商品コードマスタ(ユーザー登録)
                // BLGROUPURF    BLGRPU   ＢＬグループマスタ（ユーザー登録）

                #region [Select文作成]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGODSU.GOODSRATEGRPCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGRPU.BLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,MAXGODSP.SETPRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.LISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,GODSP.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += " FROM GOODSURF AS GODSU WITH (READUNCOMMITTED)" + Environment.NewLine;

                //JOIN
                //価格マスタ（ユーザー登録）
                selectTxt += " LEFT JOIN GOODSPRICEURF GODSP WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  GODSP.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSMAKERCDRF=GODSU.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GODSP.GOODSNORF=GODSU.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND GODSP.LOGICALDELETECODERF=GODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //価格マスタ（ユーザー登録） 価格開始日（最新）
                selectTxt += " LEFT JOIN (" + Environment.NewLine;
                selectTxt += " SELECT ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF, LOGICALDELETECODERF, MAX(PRICESTARTDATERF) AS SETPRICESTARTDATERF" + Environment.NewLine;
                selectTxt += " FROM GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " WHERE GOODSPRICEURF.PRICESTARTDATERF <= @PRICESTARTDATE" + Environment.NewLine;
                selectTxt += " GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF, LOGICALDELETECODERF) MAXGODSP" + Environment.NewLine;
                selectTxt += " ON  MAXGODSP.ENTERPRISECODERF=GODSP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.GOODSMAKERCDRF=GODSP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.GOODSNORF=GODSP.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND MAXGODSP.LOGICALDELETECODERF=GODSP.LOGICALDELETECODERF" + Environment.NewLine;

                //ＢＬ商品コードマスタ(ユーザー登録)
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGODSU WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  BLGODSU.ENTERPRISECODERF=GODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGODSU.BLGOODSCODERF=GODSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " AND BLGODSU.LOGICALDELETECODERF=GODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //ＢＬグループマスタ（ユーザー登録）
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=BLGODSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=BLGODSU.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.LOGICALDELETECODERF=BLGODSU.LOGICALDELETECODERF" + Environment.NewLine;

                //WHERE
                selectTxt += MakeWhereString(ref sqlCommand, paraWork, logicalMode);

                //ORDER BY
                selectTxt += " ORDER BY GODSU.GOODSNORF, GODSU.GOODSMAKERCDRF";
                #endregion  //[Select文作成]

                sqlCommand.CommandText = selectTxt;
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    //retList.Add(CopyToGoodsTextExpRetWorkFromReader(ref myReader, paraWork));
                    retList.Add(CopyToGoodsTextExpRetWorkFromReader(ref myReader, paraWork, convertDoubleRelease));
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
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

                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }

            goodsTextExpRetWorkList = retList;
            return status;
        }
        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsTextExpWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE句生成処理</br>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsTextExpWork goodsTextExpWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //企業コード
            retstring += " GODSU.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.EnterpriseCode);

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
            if (goodsTextExpWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND GODSU.GOODSMAKERCDRF>=@GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.GoodsMakerCdSt);
            }
            if ((goodsTextExpWork.GoodsMakerCdEd != 0) && (goodsTextExpWork.GoodsMakerCdEd != 9999))
            {
                retstring += " AND GODSU.GOODSMAKERCDRF<=@GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.GoodsMakerCdEd);
            }

            //BL商品コード
            if (goodsTextExpWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND GODSU.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.BLGoodsCodeSt);
            }
            if ((goodsTextExpWork.BLGoodsCodeEd != 0) && (goodsTextExpWork.BLGoodsCodeEd != 99999))
            {
                retstring += " AND GODSU.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.BLGoodsCodeEd);
            }

            //商品番号
            if (goodsTextExpWork.GoodsNoSt != "")
            {
                if (goodsTextExpWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = goodsTextExpWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND ( GODSU.GOODSNORF>=@GOODSNOST OR GODSU.GOODSNORF LIKE @GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");

                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF>=@GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.GoodsNoSt);
                }
            }
            if (goodsTextExpWork.GoodsNoEd != "")
            {
                if (goodsTextExpWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = goodsTextExpWork.GoodsNoEd.Split(new Char[] { '*' });

                    retstring += " AND (GODSU.GOODSNORF<=@GOODSNOED OR GODSU.GOODSNORF LIKE @GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                    retstring += " AND GODSU.GOODSNORF<=@GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsTextExpWork.GoodsNoEd);
                }
            }

            //登録日付
            if (goodsTextExpWork.UpdateDateSt != 0)
            {
                retstring += " AND GODSU.UPDATEDATERF>=@UPDATEDATEST" + Environment.NewLine;
                SqlParameter paraUpdateDateSt = sqlCommand.Parameters.Add("@UPDATEDATEST", SqlDbType.Int);
                paraUpdateDateSt.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.UpdateDateSt);
            }
            if ((goodsTextExpWork.UpdateDateEd != 0) && (goodsTextExpWork.UpdateDateEd != 99999999))
            {
                retstring += " AND GODSU.UPDATEDATERF<=@UPDATEDATEED" + Environment.NewLine;
                SqlParameter paraUpdateDateEd = sqlCommand.Parameters.Add("@UPDATEDATEED", SqlDbType.Int);
                paraUpdateDateEd.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.UpdateDateEd);
            }

            //価格開始日
            SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
            paraPriceStartDate.Value = SqlDataMediator.SqlSetInt32(goodsTextExpWork.PriceStartDate);

            #endregion

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsTextExpRetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsTextExpWork">検索条件</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>GoodsTextExpRetWork</returns>
        /// <remarks>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private GoodsTextExpRetWork CopyToGoodsTextExpRetWorkFromReader(ref SqlDataReader myReader, GoodsTextExpWork goodsTextExpWork)
        private GoodsTextExpRetWork CopyToGoodsTextExpRetWorkFromReader(ref SqlDataReader myReader, GoodsTextExpWork goodsTextExpWork, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {
            GoodsTextExpRetWork ResultWork = new GoodsTextExpRetWork();

            #region クラスへ格納
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            ResultWork.SetPriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SETPRICESTARTDATERF"));
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            //ResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = goodsTextExpWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = ResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = ResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            ResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            ResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            ResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            #endregion

            return ResultWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 高陽</br>
        /// <br>Date       : K2013/08/08</br>
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
    }
}
