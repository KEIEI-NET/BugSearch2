//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/05/25  修正内容 : INT⇒DATETIME変更バグ
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/08/20  修正内容 : myReaderからDクラスへ項目転記を行っている個所はメソッド化する
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/08  修正内容 : #23777 ソースレビュー
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 田建委
// 修 正 日  2020/10/10   修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//
// 管理番号  11601223-00 作成担当 : 陳艶丹
// 作 成 日  2021/08/04  修正内容 : BLINCIDENT-2974 価格改正処理が正しく行われないの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common; // ADD 2020/10/10 田建委 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 価格マスタ（ユーザー登録）READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 価格マスタ（ユーザー登録）処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// <br>Update Note: BLINCIDENT-2974 価格改正処理が正しく行われないの対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2021/08/04</br>
    /// </remarks>
    public class APGoodsPriceUDB : RemoteDB
    {
        private const string MST_GOODSPRICEU = "商品マスタ(価格情報)";

        // 価格
        private const string MST_ID_LISTPRICERF = "ListPriceRF";
        // オープン価格区分
        private const string MST_ID_OPENPRICEDIVRF = "OpenPriceDivRF";
        // 価格開始日
        private const string MST_ID_PRICESTARTDATERF = "PriceStartDateRF";
        // 原単価
        private const string MST_ID_SALESUNITCOSTRF = "SalesUnitCostRF";
        // 仕入率
        private const string MST_ID_STOCKRATERF = "StockRateRF";

        // 価格
        private Int32 listPriceInt = 0;

        // オープン価格区分
        private Int32 openPriceDivInt = 0;

        // 価格開始日
        private Int32 priceStartDateInt = 0;

        // 原単価
        private Int32 salesUnitCostInt = 0;

        // 仕入率
        private Int32 stockRateInt = 0;

        /// <summary>
        /// 価格マスタ（ユーザー登録）READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGoodsPriceUDB()
            : base("PMKYO06181D", "Broadleaf.Application.Remoting.ParamData.APGoodsPriceUWork", "GOODSPRICEURF")
        {

        }

        #region [Read]
        /// <summary>
        /// 価格マスタ（ユーザー登録）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsPriceUArrList">価格マスタ（ユーザー登録）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGoodsPriceU(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        {
            return SearchGoodsPriceUProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                             sqlTransaction, out goodsPriceUArrList, out retMessage);
        }
        /// <summary>
        /// 価格マスタ（ユーザー登録）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsPriceUArrList">価格マスタ（ユーザー登録）データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/10/10</br>
        /// <br>Update Note: BLINCIDENT-2974 価格改正処理が正しく行われないの対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/08/04</br>
        private int SearchGoodsPriceUProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsPriceUArrList = new ArrayList();
            APGoodsPriceUWork goodsPriceUWork = null;
            retMessage = string.Empty;
            // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974-------->>>>>
            //string sqlStr = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974--------<<<<<
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //----- ADD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974-------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("A.CREATEDATETIMERF" + Environment.NewLine);
                sqlStr.Append(", B.UPDATEDATETIMERF" + Environment.NewLine);
                sqlStr.Append(", A.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(", A.FILEHEADERGUIDRF" + Environment.NewLine);
                sqlStr.Append(", A.UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlStr.Append(", A.UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlStr.Append(", A.UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlStr.Append(", A.LOGICALDELETECODERF" + Environment.NewLine);
                sqlStr.Append(", A.GOODSMAKERCDRF" + Environment.NewLine);
                sqlStr.Append(", A.GOODSNORF" + Environment.NewLine);
                sqlStr.Append(", A.PRICESTARTDATERF" + Environment.NewLine);
                sqlStr.Append(", A.LISTPRICERF" + Environment.NewLine);
                sqlStr.Append(", A.SALESUNITCOSTRF" + Environment.NewLine);
                sqlStr.Append(", A.STOCKRATERF" + Environment.NewLine);
                sqlStr.Append(", A.OPENPRICEDIVRF" + Environment.NewLine);
                sqlStr.Append(", A.OFFERDATERF" + Environment.NewLine);
                sqlStr.Append(", A.UPDATEDATERF " + Environment.NewLine);
                sqlStr.Append("FROM GOODSPRICEURF AS A RIGHT JOIN " + Environment.NewLine);
                sqlStr.Append(" (SELECT DISTINCT ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" ,GOODSMAKERCDRF" + Environment.NewLine);
                sqlStr.Append(" ,GOODSNORF " + Environment.NewLine);
                sqlStr.Append(" ,MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF " + Environment.NewLine);
                sqlStr.Append("  FROM GOODSPRICEURF" + Environment.NewLine);
                sqlStr.Append("  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlStr.Append("  AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF" + Environment.NewLine);//更新日時＞送信開始日
                sqlStr.Append("  AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF" + Environment.NewLine);//更新日時<=送信終了日
                sqlStr.Append("  GROUP BY ENTERPRISECODERF, GOODSMAKERCDRF, GOODSNORF) AS B " + Environment.NewLine);
                sqlStr.Append("ON A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine);//企業コード
                sqlStr.Append(" AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine);//商品メーカー
                sqlStr.Append("AND A.GOODSNORF = B.GOODSNORF" + Environment.NewLine);//品番
                // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974--------<<<<<
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //価格マスタ（ユーザー登録）データ用SQL
                // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974-------->>>>>
                //sqlCommand.CommandText = sqlStr;
                sqlCommand.CommandText = sqlStr.ToString();
                // ------ UPD 2021/08/04 陳艶丹 BLINCIDENT-2974--------<<<<<
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsPriceUWork = new APGoodsPriceUWork();

                    goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    // --- UPD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
                    //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    // --- UPD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<   
                    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    goodsPriceUArrList.Add(goodsPriceUWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceU Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                //----- ADD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// 価格マスタ（ユーザー登録）の計数検索処理
        /// </summary>
        /// <param name="goodsPriceUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsPriceUCount(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsPriceUCountProc(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 価格マスタ（ユーザー登録）の計数検索処理
        /// </summary>
        /// <param name="goodsPriceUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsPriceUCountProc(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND PRICESTARTDATERF=@FINDPRICESTARTDATE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = goodsPriceUWork.GoodsNo;
                findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsPriceUWork.PriceStartDate);

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceUCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 商品マスタ（ユーザー登録分）の計数検索処理
        /// </summary>
        /// <param name="goodsPriceUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsUCount(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsUCountProc(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 商品マスタ（ユーザー登録分）の計数検索処理
        /// </summary>
        /// <param name="goodsPriceUWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品マスタ（ユーザー登録分）データ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsUCountProc(APGoodsPriceUWork goodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsPriceUWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsPriceUWork.GoodsMakerCd);
                findParaGoodsNo.Value = goodsPriceUWork.GoodsNo;

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APGoodsUDB.SearchGoodsUCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  価格マスタ（ユーザー登録）データ削除
        /// </summary>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  価格マスタ（ユーザー登録）データ削除
        /// </summary>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM GOODSPRICEURF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO ";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            //SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apGoodsPriceUWork.EnterpriseCode;
            findParaGoodsMakerCd.Value = apGoodsPriceUWork.GoodsMakerCd;
            findParaGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
            // DEL 2009/06/09 ----->>>
            //if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
            //{
            //    findParaPriceStartDate.Value = 0;
            //}
            //else
            //{
            //    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
            //}
            // DEL 2009/06/09 -----<<<
            // 価格マスタ（ユーザー登録）データを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 価格マスタ（ユーザー登録）登録
        /// </summary>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 価格マスタ（ユーザー登録）登録
        /// </summary>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/10/10</br>
        private void InsertProc(APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            // --- ADD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            try
            {
            // --- ADD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO GOODSPRICEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @GOODSMAKERCD, @GOODSNO, @PRICESTARTDATE, @LISTPRICE, @SALESUNITCOST, @STOCKRATE, @OPENPRICEDIV, @OFFERDATE, @UPDATEDATE)";

                //Prameterオブジェクトの作成
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

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsPriceUWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd);
                if (string.IsNullOrEmpty(apGoodsPriceUWork.GoodsNo.Trim()))
                {
                    paraGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
                }
                else
                {
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo);
                }
                // MOD 2009/05/25 --->>>
                if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                {
                    paraPriceStartDate.Value = 0;
                }
                else
                {
                    paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
                }
                // MOD 2009/05/25 ---<<<
                // --- UPD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
                //paraListPrice.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.ListPrice);
                convertDoubleRelease.EnterpriseCode = apGoodsPriceUWork.EnterpriseCode;
                convertDoubleRelease.GoodsMakerCd = apGoodsPriceUWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = apGoodsPriceUWork.GoodsNo;
                convertDoubleRelease.ConvertSetParam = apGoodsPriceUWork.ListPrice;

                // 変換処理実行
                convertDoubleRelease.ConvertProc();

                paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                // --- UPD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.SalesUnitCost);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.StockRate);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.OpenPriceDiv);
                paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.OfferDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.UpdateDate);


                // 価格マスタ（ユーザー登録）データを登録する
                sqlCommand.ExecuteNonQuery();
            // --- ADD 2020/10/10 田建委 PMKOBETSU-4005 ---------->>>>>
            }
            finally
            {
                // 解放
                convertDoubleRelease.Dispose();
            }
            // --- ADD 2020/10/10 田建委 PMKOBETSU-4005 ----------<<<<<
        }
        #endregion

        # region [Update]
        /// <summary>
        /// 価格マスタ（ユーザー登録）更新
        /// </summary>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを更新する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Update(ArrayList masterDtlDivList, APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            UpdateProc(masterDtlDivList, apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 価格マスタ（ユーザー登録）更新
        /// </summary>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apGoodsPriceUWork">価格マスタ（ユーザー登録）データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 価格マスタ（ユーザー登録）データを更新する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void UpdateProc(ArrayList masterDtlDivList, APGoodsPriceUWork apGoodsPriceUWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in masterDtlDivList)
            {
                // 価格
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_LISTPRICERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    listPriceInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // オープン価格区分
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_OPENPRICEDIVRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    openPriceDivInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 価格開始日
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_PRICESTARTDATERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    priceStartDateInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 原単価
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SALESUNITCOSTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    salesUnitCostInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 仕入率
                if (MST_GOODSPRICEU.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKRATERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    stockRateInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
            }

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            string sqlText = string.Empty;

            // Deleteコマンドの生成
            sqlText = "UPDATE GOODSPRICEURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE ";
            sqlText = sqlText + " , GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlText = sqlText + " , GOODSNORF=@GOODSNO ";
            // 価格開始日
            if (priceStartDateInt == 0)
            {
                sqlText = sqlText + " , PRICESTARTDATERF=@PRICESTARTDATE ";
            }
            // 価格
            if (listPriceInt == 0)
            {
                sqlText = sqlText + " , LISTPRICERF=@LISTPRICE ";
            }
            // 原単価
            if (salesUnitCostInt == 0)
            {
                sqlText = sqlText + " , SALESUNITCOSTRF=@SALESUNITCOST ";
            }
            // 仕入率
            if (stockRateInt == 0)
            {
                sqlText = sqlText + " , STOCKRATERF=@STOCKRATE ";
            }
            // オープン価格区分
            if (openPriceDivInt == 0)
            {
                sqlText = sqlText + " , OPENPRICEDIVRF=@OPENPRICEDIV ";
            }
            sqlText = sqlText + " , OFFERDATERF=@OFFERDATE ";
            sqlText = sqlText + " , UPDATEDATERF=@UPDATEDATE ";
            sqlText = sqlText + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND PRICESTARTDATERF=@FINDPRICESTARTDATE ";

            sqlCommand.CommandText = sqlText;

            //Prameterオブジェクトの作成
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
            // 価格開始日
            if (priceStartDateInt == 0)
            {
                SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                // MOD 2009/05/25 --->>>
                if (apGoodsPriceUWork.PriceStartDate == DateTime.MinValue)
                {
                    paraPriceStartDate.Value = 0;
                }
                else
                {
                    paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate);
                }
                // MOD 2009/05/25 ---<<<
            }
            // 価格
            if (listPriceInt == 0)
            {
                SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                paraListPrice.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.ListPrice);
            }
            // 原単価
            if (salesUnitCostInt == 0)
            {
                SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.SalesUnitCost);
            }
            // 仕入率
            if (stockRateInt == 0)
            {
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(apGoodsPriceUWork.StockRate);
            }
            // オープン価格区分
            if (openPriceDivInt == 0)
            {
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.OpenPriceDiv);
            }

            SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsPriceUWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsPriceUWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.LogicalDeleteCode);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsPriceUWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apGoodsPriceUWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo);
            }
            paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.OfferDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.UpdateDate);

            //Parameterオブジェクトの作成(検索用)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
            SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定(検索用)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.EnterpriseCode);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsPriceUWork.GoodsMakerCd); ;
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsPriceUWork.GoodsNo); ;
            findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apGoodsPriceUWork.PriceStartDate); ;


            // 価格マスタ（ユーザー登録）データを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        #region DEL 2011/09/08 sundx #23777 ソースレビュー
        ///// <summary>
        ///// 価格マスタ（ユーザー登録）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="goodsPriceUArrList">価格マスタ（ユーザー登録）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 価格マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int SearchGoodsPriceU(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        //{
        //    return SearchGoodsPriceUProc(enterpriseCodes, paramList, sqlConnection,
        //                       sqlTransaction, out goodsPriceUArrList, out retMessage);
        //}
        ///// <summary>
        ///// 価格マスタ（ユーザー登録）の検索処理
        ///// </summary>
        ///// <param name="enterpriseCodes">企業コード</param>
        ///// <param name="paramList">検索条件</param>
        ///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        ///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        ///// <param name="goodsPriceUArrList">価格マスタ（ユーザー登録）データオブジェクト</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 価格マスタ（ユーザー登録）データREADLISTを全て戻します</br>
        ///// <br>Programmer : 孫東響</br>
        ///// <br>Date       : 2011.07.26</br>
        //private int SearchGoodsPriceUProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
        //    SqlTransaction sqlTransaction, out ArrayList goodsPriceUArrList, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    goodsPriceUArrList = new ArrayList();
        //    //APGoodsPriceUWork goodsPriceUWork = null;//DEL 2011/08/20 途中納品チェック
        //    retMessage = string.Empty;
        //    string sqlStr = string.Empty;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    APGoodsProcParamWork param = paramList as APGoodsProcParamWork;

        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMAKERCDRF, GOODSNORF, PRICESTARTDATERF, LISTPRICERF, SALESUNITCOSTRF, STOCKRATERF, OPENPRICEDIVRF, OFFERDATERF, UPDATEDATERF FROM GOODSPRICEURF ";
        //        sqlStr += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

        //        if (param.UpdateDateTimeBegin != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
        //            SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
        //        }
        //        if (param.UpdateDateTimeEnd != 0)
        //        {
        //            sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
        //            SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
        //            findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
        //        }
        //        if (param.GoodsMakerCdBeginRF != 0)
        //        {
        //            sqlStr += " AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
        //            SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
        //            goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
        //        }

        //        if (param.GoodsMakerCdEndRF != 0)
        //        {
        //            sqlStr += " AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
        //            SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
        //            goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
        //        {
        //            sqlStr += " AND GOODSNORF >= @GOODSNOBEGINRF";
        //            SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
        //            goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
        //        }

        //        if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
        //        {
        //            sqlStr += " AND GOODSNORF <= @GOODSNOENDRF";
        //            SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
        //            goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
        //        }

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

        //        //Parameterオブジェクトへ値設定
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

        //        //価格マスタ（ユーザー登録）データ用SQL
        //        sqlCommand.CommandText = sqlStr;

        //        // 読み込み
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            #region DEL
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        //            //goodsPriceUWork = new APGoodsPriceUWork();

        //            //goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //            //goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            //goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //            //goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //            //goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //            //goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //            //goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //            //goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //            //goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //            //goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //            //goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
        //            //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //            //goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
        //            //goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
        //            //goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //            //goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //            //goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

        //            //goodsPriceUArrList.Add(goodsPriceUWork);
        //            //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        //            #endregion DEL
        //            goodsPriceUArrList.Add(CopyFromMyReaderToAPGoodsPriceUWork(myReader));//ADD 2011/08/20 途中納品チェック
        //        }

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APGoodsPriceUDB.SearchGoodsPriceU Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            if (!myReader.IsClosed) myReader.Close();

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    return status;
        //}

        ////-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        ///// <summary>
        ///// 価格マスタ（ユーザー登録）データを取得
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>価格マスタ（ユーザー登録）データ</returns>
        ///// <br>Note       : 価格マスタ（ユーザー登録）データを戻します</br>
        ///// <br>Programmer : 馮文雄</br>
        ///// <br>Date       : 2011/08/20</br>
        //private APGoodsPriceUWork CopyFromMyReaderToAPGoodsPriceUWork(SqlDataReader myReader)
        //{
        //    APGoodsPriceUWork goodsPriceUWork = new APGoodsPriceUWork();

        //    goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    goodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //    goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //    goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //    goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    goodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
        //    goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
        //    goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
        //    goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
        //    goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
        //    goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

        //    return goodsPriceUWork;
        //}
        ////-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        #endregion
        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
    }
}

