//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力 DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 黄亜光
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11670219-00  作成担当 : 譚洪
// 作 成 日 : 2020/11/02   修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ＴＢＯ情報出力DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : ＴＢＯ情報出力の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 黄亜光</br>
    /// <br>Date        : 2016/05/20</br>
    /// <br>Update Note : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2020/11/02</br>
    /// </remarks>
    [Serializable]
    public class TBODataExportDB : RemoteDB, ITBODataExportDB
    {
        #region TBODataExportDB
        /// <summary>
        /// ＴＢＯ情報出力コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public TBODataExportDB()
        {
        }
        #endregion

        #region TBOデータの検索
        /// <summary>
        /// ＴＢＯ情報出力情報リストの取得処理
        /// </summary>
        /// <param name="TBOExportResultWork">TBOデータ結果</param>
        /// <param name="TBODataExportCondWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ情報出力情報リスト(TBOデータ)を取得します。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public int SearchTBOData(out object TBOExportResultWork, object TBODataExportCondWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            TBOExportResultWork = null;
            errMessage = string.Empty;
            try
            {
                // コネクション生成
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    // 検索処理
                    status = SearchTBODataProc(ref TBOExportResultWork, TBODataExportCondWork, out errMessage, sqlConnection);
                }

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, ex.Message);
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のＴＢＯ分類を全て戻る処理
        /// </summary>
        /// <param name="TBOExportResultWork">TBOデータ結果</param>
        /// <param name="TBODataExportCondWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のＴＢＯ分類を全て戻る。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/11/02</br>
        /// </remarks>
        private int SearchTBODataProc(ref object TBOExportResultWork, object TBODataExportCondWork, out string errMessage, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            errMessage = string.Empty;
            TBODataExportCond cndtnWork = TBODataExportCondWork as TBODataExportCond;
            ArrayList al = new ArrayList(); 

            //----- ADD 2020/11/02 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/11/02 譚洪 PMKOBETSU-4005 ----------<<<<<

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    // 検索クエリ文の構築
                    sqlCommand.CommandText = MakeSelectTBOString(sqlCommand, cndtnWork);

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 抽出結果-値セット
                            //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ---------->>>>>
                            //al.Add(CopyTBODataFromSqlDataReader(myReader));
                            al.Add(CopyTBODataFromSqlDataReader(myReader, convertDoubleRelease, cndtnWork));
                            //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ----------<<<<<
                        }
                    }

                    if (al.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (SqlException ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteSQLErrorLog(ex, ex.Message, ex.Number);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            //----- ADD 2020/11/02 譚洪 PMKOBETSU-4005 ---------->>>>>
            finally
            {
                // 解放
                convertDoubleRelease.Dispose();
            }
            //----- ADD 2020/11/02 譚洪 PMKOBETSU-4005 ----------<<<<<

            TBOExportResultWork = al;

            return status;
        }

        /// <summary>
        /// TBOデータのクエリ文の構築
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>クエリ文</returns>
        /// <remarks>
        /// <br>Note       : TBOデータのクエリ文の構築を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string MakeSelectTBOString(SqlCommand sqlCommand, TBODataExportCond cndtnWork)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" SELECT GOODSURF.GOODSNORF, "); // 商品番号
            sqlText.AppendLine(" GOODSURF.GOODSNAMERF, "); // 商品名称
            sqlText.AppendLine(" GOODSURF.GOODSMAKERCDRF, "); // 商品メーカーコード
            sqlText.AppendLine(" (CASE WHEN GOODSURF.UPDATEDATETIMERF < STK2.UPDATEDATETIMERF AND STK2.UPDATEDATETIMERF IS NOT NULL ");
            sqlText.AppendLine(" THEN STK2.UPDATEDATETIMERF  ");
            sqlText.AppendLine(" ELSE GOODSURF.UPDATEDATETIMERF ");
            sqlText.AppendLine(" END) AS UPDATEDATETIMERF, "); // 更新年月日
            sqlText.AppendLine(" GOODSURF.BLGOODSCODERF, "); // BL商品コード
            sqlText.AppendLine(" GS.PARENTGOODSNORF, "); // 親商品番号
            sqlText.AppendLine(" BLGOODSCDURF.GOODSRATEGRPCODERF, "); // 商品中分類コード
            sqlText.AppendLine(" MAKERURF.MAKERNAMERF, "); // メーカー名称
            sqlText.AppendLine(" GOODSPRICEURF.LISTPRICERF, "); // 定価（浮動）
            sqlText.AppendLine(" GOODSPRICEURF.SALESUNITCOSTRF, "); // 原価単価
            sqlText.AppendLine(" SUM_STOCKRF.SUM_SHIPMENTPOSCNTRF, "); // 出荷可能数
            sqlText.AppendLine(" SUM_STOCKRF.SUM_MINIMUMSTOCKCNTRF "); // 最低在庫数
            sqlText.AppendLine(" FROM ( ");
            sqlText.AppendLine("    SELECT ");
            sqlText.AppendLine("        ENTERPRISECODERF,");
            sqlText.AppendLine("        PARENTGOODSNORF, ");
            sqlText.AppendLine("        SUBGOODSNORF, ");
            sqlText.AppendLine("        SUBGOODSMAKERCDRF, ");
            sqlText.AppendLine("        ROW_NUMBER() OVER(PARTITION BY SUBGOODSNORF,SUBGOODSMAKERCDRF ORDER BY PARENTGOODSNORF) AS ROWNUM ");
            sqlText.AppendLine("    FROM GOODSSETRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ) AS GS ");
            sqlText.AppendLine(" INNER JOIN GOODSURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GS.SUBGOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GS.SUBGOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = GS.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.BLGOODSCODERF = BLGOODSCDURF.BLGOODSCODERF  ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = BLGOODSCDURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GOODSPRICEURF.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN ( ");
            sqlText.AppendLine("    SELECT ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF, ");
            sqlText.AppendLine("        SUM(SHIPMENTPOSCNTRF) AS SUM_SHIPMENTPOSCNTRF, ");
            sqlText.AppendLine("        SUM(MINIMUMSTOCKCNTRF) AS SUM_MINIMUMSTOCKCNTRF ");
            sqlText.AppendLine("    FROM STOCKRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("    WHERE SECTIONCODERF = @SECTIONCODE ");
            sqlText.AppendLine("    GROUP BY ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF ");
            sqlText.AppendLine(" ) AS SUM_STOCKRF ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = SUM_STOCKRF.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = SUM_STOCKRF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSURF.ENTERPRISECODERF = SUM_STOCKRF.ENTERPRISECODERF ");
            sqlText.AppendLine(" LEFT JOIN ( ");
            sqlText.AppendLine("    SELECT ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF, ");
            sqlText.AppendLine("        MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF ");
            sqlText.AppendLine("    FROM STOCKRF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("    WHERE SECTIONCODERF = @SECTIONCODE ");
            sqlText.AppendLine("    GROUP BY ENTERPRISECODERF, ");
            sqlText.AppendLine("        GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSNORF, ");
            sqlText.AppendLine("        SECTIONCODERF ");
            sqlText.AppendLine(" ) AS STK2 ");
            sqlText.AppendLine(" ON STK2.GOODSNORF = SUM_STOCKRF.GOODSNORF ");
            sqlText.AppendLine(" AND STK2.GOODSMAKERCDRF = SUM_STOCKRF.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND STK2.ENTERPRISECODERF = SUM_STOCKRF.ENTERPRISECODERF ");
            sqlText.AppendLine(" AND STK2.SECTIONCODERF = SUM_STOCKRF.SECTIONCODERF ");
            sqlText.AppendLine(" INNER JOIN ( ");
            sqlText.AppendLine("    SELECT GOODSPRICES.GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSPRICES.GOODSNORF, ");
            sqlText.AppendLine("        MAX(GOODSPRICES.PRICESTARTDATERF) AS MAX_PRICESTARTDATERF ");
            sqlText.AppendLine("    FROM ( ");
            sqlText.AppendLine("        SELECT GOODSMAKERCDRF, ");
            sqlText.AppendLine("            GOODSNORF, ");
            sqlText.AppendLine("            PRICESTARTDATERF ");
            sqlText.AppendLine("        FROM GOODSPRICEURF WITH (READUNCOMMITTED) ");
            sqlText.AppendLine("        WHERE PRICESTARTDATERF <= @PRICESTART ");
            sqlText.AppendLine("    ) AS GOODSPRICES ");
            sqlText.AppendLine("    GROUP BY ");
            sqlText.AppendLine("        GOODSPRICES.GOODSMAKERCDRF, ");
            sqlText.AppendLine("        GOODSPRICES.GOODSNORF ");
            sqlText.AppendLine(" ) AS GOODSPRICEURF2 ");
            sqlText.AppendLine(" ON GOODSURF.GOODSNORF = GOODSPRICEURF2.GOODSNORF ");
            sqlText.AppendLine(" AND GOODSURF.GOODSMAKERCDRF = GOODSPRICEURF2.GOODSMAKERCDRF ");
            sqlText.AppendLine(" AND GOODSPRICEURF.PRICESTARTDATERF = GOODSPRICEURF2.MAX_PRICESTARTDATERF ");

            //Where文
            sqlText.Append(MakeTBOWhereString(sqlCommand, cndtnWork));

            return sqlText.ToString();
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note        : 検索条件文字列生成＋条件値設定を行う。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private string MakeTBOWhereString(SqlCommand sqlCommand, TBODataExportCond cndtnWork)
        {
            #region WHERE文作成
            StringBuilder retstring = new StringBuilder(" WHERE ");

            // 企業コード
            retstring.AppendLine(" GS.ENTERPRISECODERF = @ENTERPRISECODERF ");
            // セットマスタの子メーカー+子品番でグルーピングした先頭1行目を採用
            retstring.AppendLine(" AND GS.ROWNUM = 1 ");
            // 商品中分類コード
            if (cndtnWork.GoodsMGroup.Count > 0)
            {
                retstring.AppendLine(" AND BLGOODSCDURF.GOODSRATEGRPCODERF IN( ");
                retstring.AppendLine(String.Join(",", (string[])cndtnWork.GoodsMGroup.ToArray(typeof(string))));
                retstring.AppendLine(" ) ");
            }
            // 品番
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                retstring.AppendLine(" AND GS.PARENTGOODSNORF LIKE @GOODSNO ");
            }
            // メーカー
            if (cndtnWork.GoodsMakerCd_ST != 0)
            {
                retstring.AppendLine(" AND GS.SUBGOODSMAKERCDRF >= @MAKERCODE_ST ");
            }
            if (cndtnWork.GoodsMakerCd_ED != 9999)
            {
                retstring.AppendLine(" AND GS.SUBGOODSMAKERCDRF <= @MAKERCODE_ED ");
            }

            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(String.Format("%{0}%", EscapeLike(cndtnWork.GoodsNo)));
            SqlParameter paraMakerCode_St = sqlCommand.Parameters.Add("@MAKERCODE_ST", SqlDbType.Int);
            paraMakerCode_St.Value = SqlDataMediator.SqlSetInt(cndtnWork.GoodsMakerCd_ST);
            SqlParameter paraMakerCode_Ed = sqlCommand.Parameters.Add("@MAKERCODE_ED", SqlDbType.Int);
            paraMakerCode_Ed.Value = SqlDataMediator.SqlSetInt(cndtnWork.GoodsMakerCd_ED);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCodeRF);
            SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTART", SqlDbType.Int);
            paraPriceStartDate.Value = SqlDataMediator.SqlSetInt(cndtnWork.PriceStartDate);
            SqlParameter paraEnterpriSecode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriSecode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            #endregion

            return retstring.ToString();
        }

        /// <summary>
        /// TBOデータの格納
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <returns>TBOデータ</returns>
        /// <remarks>
        /// <br>Note       : TBOデータの格納を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/11/02</br>
        /// </remarks>
        //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private TBODataExportResultWork CopyTBODataFromSqlDataReader(SqlDataReader myReader)
        private TBODataExportResultWork CopyTBODataFromSqlDataReader(SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease, TBODataExportCond cndtnWork)
        //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            TBODataExportResultWork TBODataExportResultWork = new TBODataExportResultWork();

            #region 検索結果の格納
            TBODataExportResultWork.GoodsCategoryRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF")); // 商品カテゴリ
            TBODataExportResultWork.GoodsNoRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF")); // 商品番号
            TBODataExportResultWork.GoodsNameRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // 商品名称
            TBODataExportResultWork.GoodsMakerCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // 商品メーカーコード
            TBODataExportResultWork.MakerNameRF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // メーカー名称
            //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ---------->>>>>
            //TBODataExportResultWork.SuggestPriceRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF")); // 希望小売価格
            convertDoubleRelease.EnterpriseCode = cndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = TBODataExportResultWork.GoodsMakerCdRF;
            convertDoubleRelease.GoodsNo = TBODataExportResultWork.GoodsNoRF;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF")); // 希望小売価格

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            TBODataExportResultWork.SuggestPriceRF = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/11/02 譚洪 PMKOBETSU-4005 ----------<<<<<
            TBODataExportResultWork.PurchaseCostRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF")); // 仕入原価
            TBODataExportResultWork.PMUpdateTimeRF = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // PM更新日時
            TBODataExportResultWork.SearchTag1RF = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF")); // 検索タグ1 
            TBODataExportResultWork.ShipmentPosCntRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUM_SHIPMENTPOSCNTRF")); // 出荷可能数
            TBODataExportResultWork.BLGoodsCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            TBODataExportResultWork.MinimumStockCntRF = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUM_MINIMUMSTOCKCNTRF")); // 最低在庫数
            #endregion

            return TBODataExportResultWork;
        }

        /// <summary>
        /// LIKE検索の文字エスケープ
        /// </summary>
        /// <param name="targetValue">エスケープ対象の条件値</param>
        /// <returns>エスケープ後の条件値</returns>
         /// <remarks>
        /// <br>Note       : LIKE検索のエスケープ</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string EscapeLike(string targetValue)
        {
            if (String.IsNullOrEmpty(targetValue)) return String.Empty;

            return targetValue.Replace("%", "[%]").Replace("_", "[_]").Replace("[", "[[]");
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection生成処理。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection返す
            return retSqlConnection;
        }
        #endregion
    }
}
