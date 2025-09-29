//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品テキスト変換DBリモートオブジェクトクラス
// プログラム概要   : 商品テキスト変換DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10802197-00  作成担当 : FSI菅原 庸平
// 作 成 日  K2012/05/28  修正内容 : 新規作成 山形部品個別対応
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 呉元嘯
// 修 正 日  2020/08/20   修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品テキスト変換DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品テキスト変換の実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2020/08/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class GoodsUMasDB : RemoteDB, IGoodsUMasDB
    {
        /// <summary>
        /// 商品テキスト変換DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        public GoodsUMasDB()
            : base("PMKHN09928DC", "Broadleaf.Application.Remoting.ParamData.GoodsUWork", "GOODSURF")
        {

        }

        # region [Search]
        /// <summary>
        /// 商品テキスト明細情報のリストを取得します。
        /// </summary>
        /// <param name="outList">検索結果</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品テキストのキー値が一致する、全ての商品テキスト明細情報を取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        public int Search(out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _goodsUList = null;
            GoodsUWork goodsUWork = null;
            GoodsUWork goodsUWorkSt = null;
            GoodsUWork goodsUWorkEd = null;

            outList = new CustomSerializeArrayList();

            try
            {

                if (paraWork is GoodsUWork)
                {
                    goodsUWork = paraWork as GoodsUWork;

                }
                else if (paraWork is ArrayList)
                {
                    if ((paraWork as ArrayList).Count > 0)
                    {
                        goodsUWorkSt = (paraWork as ArrayList)[0] as GoodsUWork;
                        goodsUWorkEd = (paraWork as ArrayList)[1] as GoodsUWork;

                    }
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _goodsUList, goodsUWorkSt, goodsUWorkEd, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);


                if (_goodsUList != null)
                {
                    (outList as CustomSerializeArrayList).AddRange(_goodsUList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsUMasDB.Search(out object, object, int, LogicalMode)", status);
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
        /// 商品テキスト明細情報のリストを取得します。
        /// </summary>
        /// <param name="goodsUList">商品テキスト明細情報を格納する ArrayList</param>
        /// <param name="paraWorkSt">検索条件（開始）</param>
        /// <param name="paraWorkEd">検索条件（終了）</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品テキストのキー値が一致する、全ての商品テキスト明細情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        public int Search(out ArrayList goodsUList, GoodsUWork paraWorkSt, GoodsUWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(out goodsUList, paraWorkSt, paraWorkEd, readMode, logicalMode, false, ref sqlConnection, ref sqlTransaction);
        }


        /// <summary>
        /// 商品テキスト明細情報のリストを取得します。
        /// </summary>
        /// <param name="goodsUList">商品テキスト明細情報を格納する ArrayList</param>
        /// <param name="paraWorkSt">検索条件（開始）</param>
        /// <param name="paraWorkEd">検索条件（終了）</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="isSearchPayeeWithChildren"></param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品テキストのキー値が一致する、全ての商品テキスト明細情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProc(out ArrayList goodsUList, GoodsUWork paraWorkSt, GoodsUWork paraWorkEd, int readMode, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 仕入先取得用のパラメータ取得Reader
            SqlDataReader getParamReader = null;
            // 実際の商品マスタからのデータ取得Reader
            SqlDataReader getGoodsReader = null;
            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // 仕入先取得からデータ格納用のワークリスト
            List<GoodsUWork> outWork2 = new List<GoodsUWork>();

            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 600;


                # region [仕入先取得する為のパラメータ取得のSELECT文]
                StringBuilder sqlString = new StringBuilder();

                sqlString.AppendLine("SELECT DISTINCT");
                sqlString.AppendLine("	  GOODSU.ENTERPRISECODERF AS GOODS_ENTERPRISECODERF --企業コード");
                sqlString.AppendLine("	, @FINDLOGINSECTIONCODE AS GOODS_SCTIONCODERF --拠点コード");
                sqlString.AppendLine("	, GOODSU.GOODSMAKERCDRF AS GOODS_GOODSMAKERCDRF --メーカーコード");
                sqlString.AppendLine("	, GOODSU.GOODSNORF AS GOODS_GOODSNORF --商品番号");
                sqlString.AppendLine("	, GOODSU.BLGOODSCODERF AS GOODSU_BLGOODSCODERF --BLコード");
                sqlString.AppendLine("	, BLGROUPU.GOODSMGROUPRF AS BLGROUPU_GOODSMGROUPRF --商品中分類コード");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	GOODSURF AS GOODSU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("	LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("		ON  GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF");
                sqlString.AppendLine("		AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF");
                sqlString.AppendLine("	LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED)");
                sqlString.AppendLine("		ON  GOODSU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF");
                sqlString.AppendLine("		AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	    GOODSU.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND ( @FINDGOODSNOST IS NULL OR GOODSU.GOODSNORF >= @FINDGOODSNOST )");
                sqlString.AppendLine("	AND ( @FINDGOODSNOED IS NULL OR GOODSU.GOODSNORF <= @FINDGOODSNOED )");
	            sqlString.AppendLine("  AND ( @FINDGOODSMAKERCDST = 0 OR GOODSU.GOODSMAKERCDRF >= @FINDGOODSMAKERCDST )");
	            sqlString.AppendLine("  AND ( @FINDGOODSMAKERCDED = 0 OR GOODSU.GOODSMAKERCDRF <= @FINDGOODSMAKERCDED )");
                sqlString.AppendLine("	AND GOODSU.LOGICALDELETECODERF = 0");
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	GOODSU.GOODSNORF, GOODSU.GOODSMAKERCDRF");
                sqlCommand.CommandText = sqlString.ToString();

                // Parameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);
                SqlParameter findGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);
                SqlParameter findMakerCodeSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                SqlParameter findMakerCodeEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                SqlParameter findLoginSectionCode = sqlCommand.Parameters.Add("@FINDLOGINSECTIONCODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.EnterpriseCode);
                findGoodsNoSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.GoodsNo);
                findGoodsNoEd.Value = SqlDataMediator.SqlSetString(paraWorkEd.GoodsNo);
                findMakerCodeSt.Value = SqlDataMediator.SqlSetInt(paraWorkSt.GoodsMakerCd);
                findMakerCodeEd.Value = SqlDataMediator.SqlSetInt(paraWorkEd.GoodsMakerCd);
                findLoginSectionCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.LoginSectionCode);
                # endregion

                getParamReader = sqlCommand.ExecuteReader();

                while (getParamReader.Read())
                {
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();

                    #region 商品仕入取得データクラスへ値を格納
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_ENTERPRISECODERF"));// 企業コード
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_SCTIONCODERF"));      // 拠点コード
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("GOODS_GOODSMAKERCDRF"));     // メーカーコード
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(getParamReader, getParamReader.GetOrdinal("GOODS_GOODSNORF"));              // 商品番号
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("GOODSU_BLGOODSCODERF"));      // BLコード
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(getParamReader, getParamReader.GetOrdinal("BLGROUPU_GOODSMGROUPRF"));    // 商品中分類コード
                    GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品仕入先情報取得処理 実行
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region 商品仕入先情報取得処理 結果セット
                    // 商品仕入先情報取得処理により取得した仕入先をセット
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++)
                    {
                        outWork2.Add(new GoodsUWork());
                        outWork2[outWork2.Count - 1].SupplierCd  = GoodsSupplierDataWorkList[i].SupplierCd;
                        outWork2[outWork2.Count - 1].SupplierLot = GoodsSupplierDataWorkList[i].SupplierLot;
                    }
                    #endregion
                }


                if (outWork2.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "GoodsUMasDB.Search(out ArrayList, GoodsUWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
            }
            finally
            {
                if (getParamReader != null)
                {
                    if (!getParamReader.IsClosed)
                    {
                        getParamReader.Close();
                    }

                    getParamReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 変換情報呼び出し
                ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

                // 変換情報初期化
                convertDoubleRelease.ReleaseInitLib();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

                // 実際のデータ取得
                try
                {
                    // データ取得する為のSQLコネクションを生成取得
                    sqlConnection = this.CreateSqlConnection(true);

                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    //タイムアウト時間の設定（秒）
                    sqlCommand.CommandTimeout = 600;

                    # region [仕入先取得する為のパラメータ取得のSELECT文]
                    StringBuilder sqlString = new StringBuilder();
                    sqlString.AppendLine("SELECT DISTINCT");
                    sqlString.AppendLine("	  GOODSU.GOODSNORF --商品番号");
                    sqlString.AppendLine("	, GOODSU.GOODSNAMERF --商品名称");
                    sqlString.AppendLine("	, GOODSU.GOODSMAKERCDRF --商品メーカーコード");
                    sqlString.AppendLine("	, GOODSU.BLGOODSCODERF --BL商品コード");
                    sqlString.AppendLine("	, GOODSU.LISTPRICENOWRF --定価(浮動)[現在価格]");
                    sqlString.AppendLine("	, GOODSU.LISTPRICENEWRF --定価(浮動)[新価格]");
                    sqlString.AppendLine("	, GOODSU.PRICESTARTDATENEWRF  --価格開始日[新価格]");
                    sqlString.AppendLine("	, GOODSU.STOCKRATENOWRF --仕入率[現在価格]");
                    sqlString.AppendLine("	, GOODSU.SALESUNITCOSTNOWRF --原価単価[現在価格]");
                    sqlString.AppendLine("	, GOODSU.GOODSRATERANKRF --商品掛率ランク(層別)");
                    sqlString.AppendLine("	, GOODSU.GOODSSPECIALNOTERF --商品規格･特記事項");
                    sqlString.AppendLine("	, GOODSU.GOODSKINDCODERF --商品属性");
                    sqlString.AppendLine("	, GOODSU.ENTERPRISEGANRECODERF --自社分類コード");
                    sqlString.AppendLine("	, GOODSU.TAXATIONDIVCDRF --課税区分");
                    sqlString.AppendLine("	, GOODSU.GOODSNOTE1RF --商品備考1");
                    sqlString.AppendLine("	, GOODSU.GOODSNOTE2RF --商品備考2");
                    sqlString.AppendLine("	, GOODSU.OFFERDATADIVRF --提供データ区分");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.PRICESTARTDATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE1RF --価格開始日[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.LISTPRICENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.LISTPRICENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE1RF --定価(浮動)[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.SALESUNITCOSTNEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST1RF --原価単価[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.STOCKRATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.STOCKRATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE1RF --仕入率[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OPENPRICEDIVNEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV1RF --オープン価格区分[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OFFERDATENEW3RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OFFERDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENOWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE1RF --提供日付[No.1]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE2RF --価格開始日[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.LISTPRICENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE2RF --定価(浮動)[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST2RF --原価単価[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.STOCKRATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE2RF --仕入率[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV2RF --オープン価格区分[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL ) THEN GOODSU.OFFERDATENEW2RF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE2RF --提供日付[No.2]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.PRICESTARTDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.PRICESTARTDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS PRICESTARTDATE3RF --価格開始日[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.LISTPRICENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.LISTPRICENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS LISTPRICE3RF --定価(浮動)[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS SALESUNITCOST3RF --原価単価[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.STOCKRATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.STOCKRATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS STOCKRATE3RF --仕入率[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OPENPRICEDIV3RF --オープン価格区分[No.3]");
                    sqlString.AppendLine("	, CASE");
                    sqlString.AppendLine("		WHEN ( GOODSU.PRICESTARTDATENOWRF IS NULL AND GOODSU.PRICESTARTDATENEW3RF IS NOT NULL AND GOODSU.PRICESTARTDATENEW2RF IS NOT NULL) THEN GOODSU.OFFERDATENEWRF");
                    sqlString.AppendLine("		WHEN GOODSU.PRICESTARTDATENEW2RF IS NOT NULL AND GOODSU.PRICESTARTDATENEWRF IS NOT NULL THEN GOODSU.OFFERDATENOWRF");
                    sqlString.AppendLine("		ELSE NULL");
                    sqlString.AppendLine("	  END AS OFFERDATE3RF --提供日付[No.3]");
                    sqlString.AppendLine("FROM(");
                    sqlString.AppendLine("	SELECT");
                    sqlString.AppendLine("		GOODSURF.ENTERPRISECODERF");
                    sqlString.AppendLine("	  , GOODSURF.LOGICALDELETECODERF");
                    sqlString.AppendLine("	  , GOODSURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("	  ,	GOODSURF.GOODSNORF");
                    sqlString.AppendLine("	  ,	GOODSNAMERF");
                    sqlString.AppendLine("	  ,	BLGOODSCODERF");
                    sqlString.AppendLine("	  ,	GOODSSPECIALNOTERF");
                    sqlString.AppendLine("	  ,	GOODSKINDCODERF");
                    sqlString.AppendLine("	  ,	ENTERPRISEGANRECODERF");
                    sqlString.AppendLine("	  ,	TAXATIONDIVCDRF");
                    sqlString.AppendLine("	  ,	GOODSNOTE1RF");
                    sqlString.AppendLine("	  ,	GOODSNOTE2RF");
                    sqlString.AppendLine("	  ,	OFFERDATADIVRF");
                    sqlString.AppendLine("	  ,	GOODSRATERANKRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.PRICESTARTDATERF AS PRICESTARTDATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.PRICESTARTDATERF AS PRICESTARTDATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.PRICESTARTDATERF AS PRICESTARTDATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.PRICESTARTDATERF AS PRICESTARTDATENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.LISTPRICERF AS LISTPRICENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.LISTPRICERF AS LISTPRICENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.LISTPRICERF AS LISTPRICENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.LISTPRICERF AS LISTPRICENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.STOCKRATERF AS STOCKRATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.STOCKRATERF AS STOCKRATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.STOCKRATERF AS STOCKRATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.STOCKRATERF AS STOCKRATENEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.SALESUNITCOSTRF AS SALESUNITCOSTNOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.SALESUNITCOSTRF AS SALESUNITCOSTNEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.SALESUNITCOSTRF AS SALESUNITCOSTNEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.SALESUNITCOSTRF AS SALESUNITCOSTNEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.OPENPRICEDIVRF AS OPENPRICEDIVNOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.OPENPRICEDIVRF AS OPENPRICEDIVNEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.OPENPRICEDIVRF AS OPENPRICEDIVNEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.OPENPRICEDIVRF AS OPENPRICEDIVNEW3RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU1.OFFERDATERF AS OFFERDATENOWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU2.OFFERDATERF AS OFFERDATENEWRF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU3.OFFERDATERF AS OFFERDATENEW2RF");
                    sqlString.AppendLine("	  ,	GOODSPRICEU4.OFFERDATERF AS OFFERDATENEW3RF");
                    sqlString.AppendLine("	  	FROM GOODSURF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , MAX(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("			WHERE PRICESTARTDATERF <= @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("			GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUA ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUA.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUA.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU1 ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUA.GOODSMAKERCDRF = GOODSPRICEU1.GOODSMAKERCDRF AND GOODSPRICEUA.GOODSNORF = GOODSPRICEU1.GOODSNORF AND GOODSPRICEUA.PRICESTARTDATERF = GOODSPRICEU1.PRICESTARTDATERF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("			WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("			GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUB ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUB.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUB.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU2 ON  ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUB.GOODSMAKERCDRF = GOODSPRICEU2.GOODSMAKERCDRF AND GOODSPRICEUB.GOODSNORF = GOODSPRICEU2.GOODSNORF AND GOODSPRICEUB.PRICESTARTDATERF = GOODSPRICEU2.PRICESTARTDATERF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF , GOODSPRICEURF.GOODSNORF , MIN(PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("				INNER JOIN (");
                    sqlString.AppendLine("					SELECT GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATE4RF");
                    sqlString.AppendLine("					FROM GOODSPRICEURF");
                    sqlString.AppendLine("					WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("					GROUP BY GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("				)  GOODSPRICEU3 ON GOODSPRICEU3.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEU3.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEU3.PRICESTARTDATE4RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUC ON  GOODSPRICEUC.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUC.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUC.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU3 ON  GOODSPRICEU3.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUC.GOODSMAKERCDRF = GOODSPRICEU3.GOODSMAKERCDRF AND GOODSPRICEUC.GOODSNORF = GOODSPRICEU3.GOODSNORF AND GOODSPRICEUC.PRICESTARTDATERF = GOODSPRICEU3.PRICESTARTDATERF");
                    sqlString.AppendLine("");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF , GOODSPRICEURF.GOODSNORF , MIN(GOODSPRICEURF.PRICESTARTDATERF) PRICESTARTDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("				INNER JOIN (");
                    sqlString.AppendLine("					SELECT GOODSPRICEURF.ENTERPRISECODERF, GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.GOODSMAKERCDRF , MIN(GOODSPRICEURF.PRICESTARTDATERF) PRICESTARTDATE5RF");
                    sqlString.AppendLine("					FROM GOODSPRICEURF");
                    sqlString.AppendLine("						INNER JOIN (");
                    sqlString.AppendLine("  					        SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , MIN(PRICESTARTDATERF) PRICESTARTDATE6RF");
                    sqlString.AppendLine("						    FROM GOODSPRICEURF");
                    sqlString.AppendLine("						    WHERE PRICESTARTDATERF > @FINDADDUPYEARMONTHCD");
                    sqlString.AppendLine("						    GROUP BY ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF");
                    sqlString.AppendLine("				        )  GOODSPRICEU5 ON GOODSPRICEU5.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF AND GOODSPRICEU5.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEU5.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEU5.PRICESTARTDATE6RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			         GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		         ) GOODSPRICEUEX ON GOODSPRICEUEX.ENTERPRISECODERF = GOODSPRICEURF.ENTERPRISECODERF AND GOODSPRICEUEX.GOODSMAKERCDRF = GOODSPRICEURF.GOODSMAKERCDRF AND GOODSPRICEUEX.GOODSNORF = GOODSPRICEURF.GOODSNORF AND GOODSPRICEUEX.PRICESTARTDATE5RF < GOODSPRICEURF.PRICESTARTDATERF");
                    sqlString.AppendLine("			GROUP BY GOODSPRICEURF.GOODSNORF , GOODSPRICEURF.ENTERPRISECODERF , GOODSPRICEURF.GOODSMAKERCDRF");
                    sqlString.AppendLine("		) GOODSPRICEUD ON  GOODSPRICEUD.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUD.GOODSMAKERCDRF = GOODSURF.GOODSMAKERCDRF AND GOODSPRICEUD.GOODSNORF = GOODSURF.GOODSNORF");
                    sqlString.AppendLine("		LEFT JOIN (");
                    sqlString.AppendLine("			SELECT ENTERPRISECODERF, GOODSNORF , GOODSMAKERCDRF , PRICESTARTDATERF , LISTPRICERF , STOCKRATERF , SALESUNITCOSTRF , OPENPRICEDIVRF , OFFERDATERF");
                    sqlString.AppendLine("			FROM GOODSPRICEURF");
                    sqlString.AppendLine("		) GOODSPRICEU4 ON  GOODSPRICEU4.ENTERPRISECODERF = GOODSURF.ENTERPRISECODERF AND GOODSPRICEUD.GOODSMAKERCDRF = GOODSPRICEU4.GOODSMAKERCDRF AND GOODSPRICEUD.GOODSNORF = GOODSPRICEU4.GOODSNORF AND GOODSPRICEUD.PRICESTARTDATERF = GOODSPRICEU4.PRICESTARTDATERF");
                    sqlString.AppendLine(") GOODSU");
                    sqlString.AppendLine("WHERE");
                    sqlString.AppendLine("	    GOODSU.ENTERPRISECODERF = @FINDENTERPRISECODE");
                    sqlString.AppendLine("	AND GOODSU.LOGICALDELETECODERF = 0");
                    sqlString.AppendLine("	AND ( @FINDGOODSNOST IS NULL OR GOODSU.GOODSNORF >= @FINDGOODSNOST )");
                    sqlString.AppendLine("	AND ( @FINDGOODSNOED IS NULL OR GOODSU.GOODSNORF <= @FINDGOODSNOED )");
                    sqlString.AppendLine("	AND ( @FINDGOODSMAKERCDST = 0 OR GOODSU.GOODSMAKERCDRF >= @FINDGOODSMAKERCDST )");
                    sqlString.AppendLine("	AND ( @FINDGOODSMAKERCDED = 0 OR GOODSU.GOODSMAKERCDRF <= @FINDGOODSMAKERCDED )");
                    sqlString.AppendLine("ORDER BY");
                    sqlString.AppendLine("	GOODSU.GOODSNORF, GOODSU.GOODSMAKERCDRF");
                    sqlCommand.CommandText = sqlString.ToString();
           
                    // Parameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);
                    SqlParameter findGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCdSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter findGoodsMakerCdEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter findLoginSectionCode = sqlCommand.Parameters.Add("@FINDLOGINSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findAddUpYearMonthCd = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTHCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.EnterpriseCode);
                    findGoodsNoSt.Value = SqlDataMediator.SqlSetString(paraWorkSt.GoodsNo);
                    findGoodsNoEd.Value = SqlDataMediator.SqlSetString(paraWorkEd.GoodsNo);
                    findGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(paraWorkSt.GoodsMakerCd);
                    findGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(paraWorkEd.GoodsMakerCd);
                    findLoginSectionCode.Value = SqlDataMediator.SqlSetString(paraWorkSt.LoginSectionCode);
                    findAddUpYearMonthCd.Value = SqlDataMediator.SqlSetInt32(paraWorkSt.AddUpYearMonthCd);
                    # endregion


                    getGoodsReader = sqlCommand.ExecuteReader();

                    int cnt = 0;

                    while (getGoodsReader.Read())
                    {

                        // 仕入先コードと発注ロット以外をtmpに格納
                        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                        //GoodsUWork _tmpOutWork = this.CopyToGoodsUWorkFromReader(ref getGoodsReader);
                        GoodsUWork _tmpOutWork = this.CopyToGoodsUWorkFromReader(ref getGoodsReader, paraWorkSt.EnterpriseCode, convertDoubleRelease);
                        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

                        // 仕入先コードと発注ロットをoutWork2からセット
                        _tmpOutWork.SupplierCd = outWork2[cnt].SupplierCd;
                        _tmpOutWork.SupplierLot = outWork2[cnt].SupplierLot;

                        // Clientに返すArrayListにAddする
                        al.Add(_tmpOutWork);

                        cnt++;
                    }

                    if (al.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                catch (SqlException ex)
                {
                    // 基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex, "GoodsUMasDB.Search(out ArrayList, GoodsUWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
                }
                finally
                {
                    if (getParamReader != null)
                    {
                        if (!getParamReader.IsClosed)
                        {
                            getParamReader.Close();
                        }

                        getParamReader.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }

                    //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    // 解放
                    convertDoubleRelease.Dispose();
                    //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                }
            }

            goodsUList = al;

            return status;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>GoodsUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader)
        private GoodsUWork CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, string enterpriseCode, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {

            GoodsUWork outWork = new GoodsUWork();
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            //this.CopyToGoodsUWorkFromReader(ref myReader, ref outWork);
            this.CopyToGoodsUWorkFromReader(ref myReader, ref outWork, enterpriseCode, convertDoubleRelease);
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            return outWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="outWork">GoodsUWork オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, ref GoodsUWork outWork)
        private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, ref GoodsUWork outWork, string enterpriseCode, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {

            if (myReader != null && outWork != null)
            {
                # region 仕入コードと発注ロット以外を格納
                outWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  //商品番号
                outWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));  //商品名称
                outWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));  //商品メーカーコード
                // --- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                convertDoubleRelease.EnterpriseCode = enterpriseCode;
                convertDoubleRelease.GoodsMakerCd = outWork.GoodsMakerCd;
                convertDoubleRelease.GoodsNo = outWork.GoodsNo;
                // --- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                outWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));  //BL商品コード
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPriceNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENOWRF"));  //定価(浮動)[現在価格]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENOWRF"));

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                outWork.ListPriceNow = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                //outWork.ListPriceNew = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENEWRF"));  //定価(浮動)[新価格]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICENEWRF"));

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                outWork.ListPriceNew = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                outWork.PriceStartDateNew = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATENEWRF"));  //価格開始日[新価格]
                outWork.StockRateNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATENOWRF"));  //仕入率[現在価格]
                outWork.SalesUnitCostNow = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTNOWRF"));  //原価単価[現在価格]
                outWork.GoodsRaterank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));  //商品掛率ランク(層別)
                outWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));  //商品規格・特記事項
                outWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));  //商品属性
                outWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));  //自社分類コード
                outWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));  //課税区分
                outWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));  //商品備考１
                outWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));  //商品備考２
                outWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));  //提供データ区分
                outWork.PriceStartDate1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE1RF"));  //価格開始日[No.1]
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE1RF"));  //定価(浮動)[No.1]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE1RF"));  //定価(浮動)[No.1]

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice1 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST1RF"));  //原価単価[No.1]
                outWork.StockRate1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE1RF"));  //仕入率[No.1]
                outWork.OpenPriceDiv1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV1RF"));  //オープン価格区分[No.1]
                outWork.OfferDate1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE1RF"));  //提供日付[No.1]
                outWork.PriceStartDate2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE2RF"));  //価格開始日[No.2]
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE2RF"));  //定価(浮動)[No.2]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE2RF"));  //定価(浮動)[No.2]

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice2 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST2RF"));  //原価単価[No.2]
                outWork.StockRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE2RF"));  //仕入率[No.2]
                outWork.OpenPriceDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV2RF"));  //オープン価格区分[No.2]
                outWork.OfferDate2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE2RF"));  //提供日付[No.2]
                outWork.PriceStartDate3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATE3RF"));  //価格開始日[No.3]
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                //outWork.ListPrice3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE3RF"));  //定価(浮動)[No.3]
                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICE3RF"));  //定価(浮動)[No.3]

                // 変換処理実行
                convertDoubleRelease.ReleaseProc();

                outWork.ListPrice3 = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                outWork.SalesUnitCost3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOST3RF"));  //原価単価[No.3]
                outWork.StockRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATE3RF"));  //仕入率[No.3]
                outWork.OpenPriceDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIV3RF"));  //オープン価格区分[No.3]
                outWork.OfferDate3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATE3RF"));  //提供日付[No.3]
                # endregion
            }
        }
        # endregion

        # region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            GoodsUWork[] outWorkArray = null;

            if (paraobj != null)
                try
                {
                    // ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    // パラメータクラスの場合
                    if (paraobj is GoodsUWork)
                    {
                        GoodsUWork outWork = paraobj as GoodsUWork;
                        if (outWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(outWork);
                        }
                    }

                    // byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            outWorkArray = (GoodsUWork[])XmlByteSerializer.Deserialize(byteArray, typeof(GoodsUWork[]));
                        }
                        catch (Exception) { }
                        if (outWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(outWorkArray);
                        }
                        else
                        {
                            try
                            {
                                GoodsUWork wkGoodsUWork = (GoodsUWork)XmlByteSerializer.Deserialize(byteArray, typeof(GoodsUWork));
                                if (wkGoodsUWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkGoodsUWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    // 特に何もしない
                }

            return retal;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
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
        # endregion
    }
}
