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
    /// 請求明細一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求明細一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.15</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2007.10.25</br>
    /// <br>           : 流通基幹システム対応</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2008.03.10</br>
    /// <br>           : 戻り値に自動入金区分を追加</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2008.03.13</br>
    /// <br>           : 戻り値に売上商品区分・売上小計（税）を追加</br>
    /// <br>           : 売上商品区分(4,5,10)は除外</br>
    /// <br></br>
    /// <br>Update Note: 20081  疋田 勇人</br>
    /// <br>Date       : 2008.08.07</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// </remarks>
    [Serializable]
    public class BillDetailTableDB : RemoteDB, IBillDetailTableDB
    {
        /// <summary>
        /// 請求明細一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.15</br>
        /// </remarks>
        public BillDetailTableDB()
            :
            base("MAKAU02052D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandDetailWork", "SALESDETAILRF")
        {
        }

        #region [SearchBillDetailTable]
        /// <summary>
        /// 指定された条件の請求明細一覧表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の請求明細一覧表を戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.06.12</br>
        public int SearchBillDetailTable(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            ArrayList dmdDtlList = new ArrayList();

            retObj = null;
            ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork = null;


            // check param
            if (paraObj == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象パラメータが未指定です");
                return status;
            }
            else
            {
                extrInfo_DemandDetailWork = paraObj as ExtrInfo_DemandDetailWork;
            }

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●詳細単位　※製番単位にデータを抽出する(請求明細書は必ずこのタイプ)
                if (extrInfo_DemandDetailWork.DetailsUnit == (int)Const_BillDetailTable.ct_TableName.SalesExplaData)
                {
                    // ↓ 2007.10.25 980081 c
                    //status = SearchSalesInc(ref dmdDtlList, extrInfo_DemandDetailWork, ref sqlConnection);
                    status = SearchSalesDetailInc(ref dmdDtlList, extrInfo_DemandDetailWork, ref sqlConnection);
                    // ↑ 2007.10.25 980081 c
                }
                //●明細単位
                else if (extrInfo_DemandDetailWork.DetailsUnit == (int)Const_BillDetailTable.ct_TableName.SalesDetail)
                {
                    status = SearchSalesDetailInc(ref dmdDtlList, extrInfo_DemandDetailWork, ref sqlConnection);
                }
                //●伝票単位
                else if (extrInfo_DemandDetailWork.DetailsUnit == (int)Const_BillDetailTable.ct_TableName.SalesSlip)
                {
                    status = SearchSalesSlipInc(ref dmdDtlList, extrInfo_DemandDetailWork, ref sqlConnection);
                }

                //●入金抽出有無
                if (extrInfo_DemandDetailWork.IsExtractDepo == true)
                {
                    status = SearchDepsitMainProc(ref dmdDtlList, extrInfo_DemandDetailWork, ref sqlConnection);
                }

                if (dmdDtlList != null)
                {
                    if (dmdDtlList.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retObj = (object)dmdDtlList;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillDetailTableDB.SearchBillDetailTable");
                retObj = new ArrayList();
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

        // ↓ 2007.10.25 980081 d
        #region 詳細単位を削除
        ///// <summary>
        ///// 指定された条件の詳細単位の売上・支払インセンティブを戻します
        ///// </summary>
        ///// <param name="dmdDtlList">検索結果</param>
        ///// <param name="extrInfo_DemandDetailWork">検索パラメータ</param>
        ///// <param name="sqlConnection">コネクション情報</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 指定された条件の詳細単位の売上・支払インセンティブを戻します</br>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.06.18</br>
        //private int SearchSalesInc(ref ArrayList dmdDtlList, ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork, ref SqlConnection sqlConnection)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //
        //    try
        //    {
        //        sqlCommand = new SqlCommand("", sqlConnection);
        //
        //        #region [SQL文]
        //        //TABLE別名
        //        //SALESSLIPRF : SLIP
        //        //SALESDETAILRF : DETAIL
        //        //SALESEXPLADATARF : EXPLA
        //        //INCDTBTRF : INC
        //        sqlCommand.CommandText = "SELECT "
        //                            + "SLIP.ENTERPRISECODERF, "//企業コード
        //                            + "SLIP.DEMANDADDUPSECCDRF, "//請求計上拠点コード
        //                            + "SLIP.CLAIMCODERF, "//請求先コード
        //                            + "SLIP.CLAIMNAME1RF, "//請求先名称1
        //                            + "SLIP.CLAIMNAME2RF, "//請求先名称2
        //                            + "SLIP.CUSTOMERCODERF, "//得意先コード
        //                            + "SLIP.CUSTOMERNAMERF, "//得意先名称
        //                            + "SLIP.CUSTOMERNAME2RF, "//得意先名称2
        //                            + "SLIP.ADDUPADATERF, "//計上日付
        //                            + "SLIP.SALESSLIPNUMRF, "//売上伝票番号
        //                            + "EXPLA.ACCEPTANORDERNORF, "//受注番号
        //                            + "EXPLA.SALESROWNORF, "//売上行番号
        //                            + "EXPLA.SALESSLIPEXPNUMRF, "//売上詳細番号
        //                            + "DETAIL.GOODSCODERF, "//商品コード
        //                            + "DETAIL.GOODSNAMERF, "//商品名称
        //                            + "DETAIL.CARRIERCODERF, "//キャリアコード
        //                            + "DETAIL.CARRIERNAMERF, "//キャリア名称
        //                            + "DETAIL.CARRIEREPCODERF, "//事業者コード
        //                            + "DETAIL.CARRIEREPNAMERF, "//事業者名称
        //                            + "DETAIL.SALESFORMCODERF, "//販売形態コード
        //                            + "DETAIL.SALESFORMNAMERF, "//販売形態名称
        //                            + "DETAIL.SALESCONTCDRF, "//販売契約区分コード
        //                            + "DETAIL.SALESCONTNMRF, "//販売契約区分名称
        //                            + "DETAIL.LARGEGOODSGANRECODERF, "//商品区分グループコード
        //                            + "DETAIL.LARGEGOODSGANRENAMERF, "//商品区分グループ
        //                            + "DETAIL.MEDIUMGOODSGANRECODERF, "//商品区分コード
        //                            + "DETAIL.MEDIUMGOODSGANRENAMERF, "//商品区分名称
        //                            + "(CASE WHEN SLIP.DEBITNOTEDIVRF = 1 OR SLIP.SALESSLIPCDRF != 0 THEN CONVERT(FLOAT,-1) ELSE CONVERT(FLOAT,1) END) SALESCOUNTRF, "//売上数
        //                            + "DETAIL.SALESUNITPRICETAXINCRF, "//売上単価（税込み）
        //                            + "DETAIL.SALESUNITPRICETAXEXCRF, "//売上単価（税抜き）
        //                            + "DETAIL.SALESMONEYTAXINCRF, "//売上金額（税込み）
        //                            + "DETAIL.SALESMONEYTAXEXCRF, "//売上金額（税抜き）
        //                            + "EXPLA.PRODUCTNUMBER1RF, "//製造番号1
        //                            + "EXPLA.STOCKTELNO1RF, "//商品電話番号1
        //                            + "EXPLA.CONTRACTORNAMERF, "//契約名義人
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF != 93 THEN INC.INCDTBTTAXINCRF ELSE 0 END) INCDTBTTAXINCRF, "//支払インセンティブ額（税込み）
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF != 93 THEN INC.INCDTBTTAXEXCRF ELSE 0 END) INCDTBTTAXEXCRF, "//支払インセンティブ額（税抜き）
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF != 93 THEN INC.INCDTBTTAXFREERF ELSE 0 END) INCDTBTTAXFREERF, "//支払インセンティブ額（非課税）
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF = 93 THEN INC.INCDTBTTAXINCRF ELSE 0 END) NWOPINCDTBTTAXINC, "//NWOP支払インセンティブ額（税込み）
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF = 93 THEN INC.INCDTBTTAXEXCRF ELSE 0 END) NWOPINCDTBTTAXEXC, "//NWOP支払インセンティブ額（税抜き）
        //                            + "SUM(CASE WHEN INC.GOODSKINDCODERF = 93 THEN INC.INCDTBTTAXFREERF ELSE 0 END) NWOPINCDTBTTAXFREE, "//NWOP支払インセンティブ額（非課税）
        //                            + "DETAIL.DTLNOTERF, "//明細備考
        //                            + "SLIP.PARTYSALESLIPNUMRF, "//相手先伝票番号
        //                            + "SLIP.DEBITNLNKACPTANODRRF "//赤黒連結受注番号
        //                            + "FROM ((SALESEXPLADATARF AS EXPLA LEFT JOIN INCDTBTRF AS INC ON EXPLA.ENTERPRISECODERF=INC.ENTERPRISECODERF AND EXPLA.ACCEPTANORDERNORF=INC.ACCEPTANORDERNORF AND EXPLA.SALESROWNORF=INC.SALESROWNORF AND EXPLA.SALESSLIPEXPNUMRF=INC.SALESSLIPEXPNUMRF) "
        //                            + "LEFT JOIN SALESDETAILRF AS DETAIL ON EXPLA.ENTERPRISECODERF=DETAIL.ENTERPRISECODERF AND EXPLA.ACCEPTANORDERNORF=DETAIL.ACCEPTANORDERNORF AND EXPLA.SALESROWNORF=DETAIL.SALESROWNORF) "
        //                            + "LEFT JOIN SALESSLIPRF AS SLIP ON EXPLA.ENTERPRISECODERF=SLIP.ENTERPRISECODERF AND EXPLA.ACCEPTANORDERNORF=SLIP.ACCEPTANORDERNORF "
        //                            + "WHERE EXPLA.ENTERPRISECODERF=@ENTERPRISECODE AND EXPLA.LOGICALDELETECODERF=0 AND DETAIL.LOGICALDELETECODERF=0 AND SLIP.LOGICALDELETECODERF=0 AND SLIP.CLAIMCODERF=@CLAIMCODE AND SLIP.DEMANDADDUPSECCDRF=@ADDUPSECCODE AND SLIP.ADDUPADATERF>=@ADDUPADATEST AND SLIP.ADDUPADATERF<=@ADDUPADATEED AND SLIP.SERVICESLIPCDRF=0 AND SLIP.ACPTANODRSTATUSRF=30 AND SLIP.SALESSLIPKINDRF != 30 "
        //                            + "GROUP BY SLIP.ENTERPRISECODERF, SLIP.DEMANDADDUPSECCDRF, SLIP.CLAIMCODERF, SLIP.CLAIMNAME1RF, SLIP.CLAIMNAME2RF, SLIP.CUSTOMERCODERF, SLIP.CUSTOMERNAMERF, SLIP.CUSTOMERNAME2RF, SLIP.ADDUPADATERF, EXPLA.ACCEPTANORDERNORF, SLIP.SALESSLIPNUMRF, EXPLA.SALESROWNORF, EXPLA.SALESSLIPEXPNUMRF, DETAIL.GOODSCODERF, DETAIL.GOODSNAMERF, DETAIL.CARRIERCODERF, DETAIL.CARRIERNAMERF, DETAIL.CARRIEREPCODERF, DETAIL.CARRIEREPNAMERF, "
        //                            + "DETAIL.SALESFORMCODERF, DETAIL.SALESFORMNAMERF, DETAIL.SALESCONTCDRF, DETAIL.SALESCONTNMRF, DETAIL.LARGEGOODSGANRECODERF, DETAIL.LARGEGOODSGANRENAMERF, DETAIL.MEDIUMGOODSGANRECODERF, DETAIL.MEDIUMGOODSGANRENAMERF, SALESCOUNTRF, DETAIL.SALESUNITPRICETAXINCRF, DETAIL.SALESUNITPRICETAXEXCRF, DETAIL.SALESMONEYTAXINCRF, DETAIL.SALESMONEYTAXEXCRF, EXPLA.PRODUCTNUMBER1RF, EXPLA.STOCKTELNO1RF, "
        //                            + "EXPLA.CONTRACTORNAMERF, DETAIL.DTLNOTERF, SLIP.PARTYSALESLIPNUMRF, SLIP.DEBITNLNKACPTANODRRF, SLIP.DEBITNOTEDIVRF, SLIP.SALESSLIPCDRF ";
        //                            //抽出条件　サービス伝票区分:OFF　受注ステータス:30,売上　売上伝票種別:30,委託以外
        //        #endregion
        //
        //        //Prameterオブジェクトの作成
        //        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
        //        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
        //        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
        //        SqlParameter paraAddUpADateSt = sqlCommand.Parameters.Add("@ADDUPADATEST", SqlDbType.Int);
        //        SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@ADDUPADATEED", SqlDbType.Int);
        //
        //        //Parameterオブジェクトへ値設定
        //        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.EnterpriseCode);
        //        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.AddUpSecCode);
        //        paraClaimCode.Value = SqlDataMediator.SqlSetInt(extrInfo_DemandDetailWork.ClaimCode);
        //        paraAddUpADateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateSt);
        //        paraAddUpADateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateEd);
        //
        //        myReader = sqlCommand.ExecuteReader();
        //
        //        while (myReader.Read())
        //        {
        //            dmdDtlList.Add(CopyToRsltInfo_DmdDtlExplaTypeFromReader(ref myReader));
        //
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
        //
        //    return status;
        //}
        #endregion
        // ↑ 2007.10.25 980081 d

        /// <summary>
        /// 指定された条件の明細単位の売上・支払インセンティブを戻します
        /// </summary>
        /// <param name="dmdDtlList">検索結果</param>
        /// <param name="extrInfo_DemandDetailWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の明細単位の売上・支払インセンティブを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.15</br>
        private int SearchSalesDetailInc(ref ArrayList dmdDtlList, ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL文]
                //TABLE別名
                //SALESSLIPRF : SLIP
                //SALESDETAILRF : DETAIL
                //ACCEPTODRCARRF : ACCEP
                //CUSTOMERRF : CUST
                sqlText += "SELECT SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,CAST" + Environment.NewLine;
                sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                sqlText += "        (CUST.NAMERF" + Environment.NewLine;
                sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                sqlText += "        (30" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "    ) AS CLAIMNAMERF" + Environment.NewLine;
                sqlText += "    ,CAST" + Environment.NewLine;
                sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                sqlText += "        (CUST.NAME2RF" + Environment.NewLine;
                sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                sqlText += "        (30" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "    ) AS CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.ADDUPADATERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESGOODSCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTE2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTE3RF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESROWNORF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.MAKERNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSNORF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSLGROUPRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSLGROUPNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.BLGROUPNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SHIPMENTCNTRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESMONEYTAXINCRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.DTLNOTERF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SLIPMEMO1RF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SLIPMEMO2RF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SLIPMEMO3RF" + Environment.NewLine;
                sqlText += "    ,ACCEP.SERIESMODELRF" + Environment.NewLine;
                sqlText += " FROM SALESDETAILRF AS DETAIL" + Environment.NewLine;
                sqlText += " LEFT JOIN SALESSLIPRF AS SLIP ON SLIP.ENTERPRISECODERF = DETAIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND SLIP.ACPTANODRSTATUSRF = DETAIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " AND SLIP.SALESSLIPNUMRF = DETAIL.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF AS CUST ON CUST.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF = SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN ACCEPTODRCARRF AS ACCEP ON ACCEP.ENTERPRISECODERF = DETAIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND ACCEP.ACCEPTANORDERNORF = DETAIL.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += " AND ACCEP.ACPTANODRSTATUSRF = DETAIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " WHERE DETAIL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND DETAIL.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "    AND SLIP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "    AND SLIP.CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                sqlText += "    AND SLIP.DEMANDADDUPSECCDRF=@ADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND SLIP.ADDUPADATERF>=@ADDUPADATEST" + Environment.NewLine;
                sqlText += "    AND SLIP.ADDUPADATERF<=@ADDUPADATEED" + Environment.NewLine;
                sqlText += "    AND SLIP.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                sqlText += "    AND" + Environment.NewLine;
                sqlText += "    (" + Environment.NewLine;
                sqlText += "        (SLIP.COMPLETECDRF = 1" + Environment.NewLine;
                sqlText += "            AND DETAIL.SALESROWNORF = 0" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "        OR" + Environment.NewLine;
                sqlText += "        (SLIP.COMPLETECDRF = 0" + Environment.NewLine;
                sqlText += "            AND DETAIL.SALESROWNORF != 0" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "    )" + Environment.NewLine;
                sqlText += "    AND NOT SLIP.SALESGOODSCDRF IN" + Environment.NewLine;
                sqlText += "    (4" + Environment.NewLine;
                sqlText += "        ,5" + Environment.NewLine;
                sqlText += "        ,10" + Environment.NewLine;
                sqlText += "    )" + Environment.NewLine;
                sqlText += " ORDER BY SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.ADDUPADATERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "    ,DETAIL.SALESROWNORF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                SqlParameter paraAddUpADateSt = sqlCommand.Parameters.Add("@ADDUPADATEST", SqlDbType.Int);
                SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@ADDUPADATEED", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.EnterpriseCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.AddUpSecCode);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt(extrInfo_DemandDetailWork.ClaimCode);
                paraAddUpADateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateSt);
                paraAddUpADateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateEd);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    dmdDtlList.Add(CopyToRsltInfo_DmdDtlDeteilTypeFromReader(ref myReader));

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

            return status;
        }

        /// <summary>
        /// 指定された条件の伝票単位の売上・支払インセンティブを戻します
        /// </summary>
        /// <param name="dmdDtlList">検索結果</param>
        /// <param name="extrInfo_DemandDetailWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票単位の売上・支払インセンティブを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.15</br>
        private int SearchSalesSlipInc(ref ArrayList dmdDtlList, ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL文]
                //TABLE別名
                //SALESSLIPRF : SLIP
                sqlText += "SELECT SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,CAST" + Environment.NewLine;
                sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                sqlText += "        (CUST.NAMERF" + Environment.NewLine;
                sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                sqlText += "        (30" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "    ) AS CLAIMNAMERF" + Environment.NewLine;
                sqlText += "    ,CAST" + Environment.NewLine;
                sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                sqlText += "        (CUST.NAME2RF" + Environment.NewLine;
                sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                sqlText += "        (30" + Environment.NewLine;
                sqlText += "        )" + Environment.NewLine;
                sqlText += "    ) AS CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.ADDUPADATERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESGOODSCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTE2RF" + Environment.NewLine;
                sqlText += "    ,SLIP.SLIPNOTE3RF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSUBTOTALTAXRF" + Environment.NewLine;
                sqlText += " FROM SALESSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF AS CUST ON CUST.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF = SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += " WHERE SLIP.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SLIP.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "    AND SLIP.CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                sqlText += "    AND SLIP.DEMANDADDUPSECCDRF=@ADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND SLIP.ADDUPADATERF>=@ADDUPADATEST" + Environment.NewLine;
                sqlText += "    AND SLIP.ADDUPADATERF<=@ADDUPADATEED" + Environment.NewLine;
                sqlText += "    AND SLIP.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                sqlText += "    AND NOT SLIP.SALESGOODSCDRF IN" + Environment.NewLine;
                sqlText += "    (4" + Environment.NewLine;
                sqlText += "        ,5" + Environment.NewLine;
                sqlText += "        ,10" + Environment.NewLine;
                sqlText += "    )" + Environment.NewLine;
                sqlText += " ORDER BY SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.DEMANDADDUPSECCDRF" + Environment.NewLine;
                sqlText += "    ,SLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,SLIP.ADDUPADATERF" + Environment.NewLine;
                sqlText += "    ,SLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                SqlParameter paraAddUpADateSt = sqlCommand.Parameters.Add("@ADDUPADATEST", SqlDbType.Int);
                SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@ADDUPADATEED", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.EnterpriseCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.AddUpSecCode);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt(extrInfo_DemandDetailWork.ClaimCode);
                paraAddUpADateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateSt);
                paraAddUpADateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateEd);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    dmdDtlList.Add(CopyToRsltInfo_DmdDtlSlipTypeFromReader(ref myReader));

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

            return status;
        }

        /// <summary>
        /// 指定された条件の入金マスタを戻します
        /// </summary>
        /// <param name="dmdDtlList">検索結果</param>
        /// <param name="extrInfo_DemandDetailWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の入金マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.15</br>
        private int SearchDepsitMainProc(ref ArrayList dmdDtlList, ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL文]
                //TABLE別名
                //DEPSITMAINRF : DEPSIT
                //DEPSITDTLRF : DEPSITD
                sqlText += "SELECT DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CLAIMCODERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CLAIMNAMERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CLAIMNAME2RF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CUSTOMERNAMERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CUSTOMERNAME2RF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.ADDUPADATERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DEPOSITTOTALRF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.AUTODEPOSITCDRF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.OUTLINERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DEBITNOTELINKDEPONORF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DRAFTKINDRF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DRAFTKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DRAFTDIVIDERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DRAFTDIVIDENAMERF" + Environment.NewLine;
                sqlText += "    ,DEPSIT.DRAFTNORF" + Environment.NewLine;
                sqlText += "    ,DEPSITD.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += "    ,DEPSITD.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += "    ,DEPSITD.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += "    ,DEPSITD.DEPOSITRF" + Environment.NewLine;
                sqlText += "    ,DEPSITD.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += " FROM DEPSITMAINRF DEPSIT" + Environment.NewLine;
                sqlText += " LEFT JOIN DEPSITDTLRF AS DEPSITD ON DEPSITD.ENTERPRISECODERF = DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND DEPSITD.ACPTANODRSTATUSRF = DEPSIT.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " AND DEPSITD.DEPOSITSLIPNORF = DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                sqlText += " WHERE DEPSIT.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND DEPSIT.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND DEPSIT.ADDUPADATERF>=@ADDUPADATEST" + Environment.NewLine;
                sqlText += "    AND DEPSIT.ADDUPADATERF<=@ADDUPADATEED" + Environment.NewLine;
                sqlText += "    AND DEPSIT.CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                #endregion

                //Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                SqlParameter paraAddUpADateSt = sqlCommand.Parameters.Add("@ADDUPADATEST", SqlDbType.Int);
                SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@ADDUPADATEED", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.EnterpriseCode);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(extrInfo_DemandDetailWork.AddUpSecCode);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt(extrInfo_DemandDetailWork.ClaimCode);
                paraAddUpADateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateSt);
                paraAddUpADateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_DemandDetailWork.AddUpADateEd);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    dmdDtlList.Add(CopyToRsltInfo_DemandDepositFromReader(ref myReader));

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

            return status;
        }
        #endregion

        #region [請求明細一覧表抽出結果クラス格納処理]
        /// <summary>
        /// 請求明細一覧表(伝票形式)抽出結果クラス格納処理 Reader → RsltInfo_DemandDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_DemandDetailWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.06.18</br>
        /// </remarks>
        private RsltInfo_DemandDetailWork CopyToRsltInfo_DmdDtlSlipTypeFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_DemandDetailWork wkRsltInfo_DemandDetailWork = new RsltInfo_DemandDetailWork();

            #region クラスへ格納
            wkRsltInfo_DemandDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_DemandDetailWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            wkRsltInfo_DemandDetailWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_DemandDetailWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_DemandDetailWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_DemandDetailWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_DemandDetailWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_DemandDetailWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkRsltInfo_DemandDetailWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkRsltInfo_DemandDetailWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_DemandDetailWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkRsltInfo_DemandDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkRsltInfo_DemandDetailWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            wkRsltInfo_DemandDetailWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkRsltInfo_DemandDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkRsltInfo_DemandDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            wkRsltInfo_DemandDetailWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            wkRsltInfo_DemandDetailWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            wkRsltInfo_DemandDetailWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTax = wkRsltInfo_DemandDetailWork.SalesTotalTaxInc - wkRsltInfo_DemandDetailWork.SalesTotalTaxExc;
            wkRsltInfo_DemandDetailWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            wkRsltInfo_DemandDetailWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            wkRsltInfo_DemandDetailWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            #endregion

            return wkRsltInfo_DemandDetailWork;
        }

        /// <summary>
        /// 請求明細一覧表(明細形式)抽出結果クラス格納処理 Reader → RsltInfo_DemandDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_DemandDetailWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.06.18</br>
        /// </remarks>
        private RsltInfo_DemandDetailWork CopyToRsltInfo_DmdDtlDeteilTypeFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_DemandDetailWork wkRsltInfo_DemandDetailWork = new RsltInfo_DemandDetailWork();

            #region クラスへ格納
            wkRsltInfo_DemandDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_DemandDetailWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            wkRsltInfo_DemandDetailWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_DemandDetailWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_DemandDetailWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_DemandDetailWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_DemandDetailWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_DemandDetailWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkRsltInfo_DemandDetailWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkRsltInfo_DemandDetailWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_DemandDetailWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkRsltInfo_DemandDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkRsltInfo_DemandDetailWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            wkRsltInfo_DemandDetailWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkRsltInfo_DemandDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkRsltInfo_DemandDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            wkRsltInfo_DemandDetailWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            wkRsltInfo_DemandDetailWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            wkRsltInfo_DemandDetailWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            wkRsltInfo_DemandDetailWork.SalesTotalTax = wkRsltInfo_DemandDetailWork.SalesTotalTaxInc - wkRsltInfo_DemandDetailWork.SalesTotalTaxExc;
            wkRsltInfo_DemandDetailWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            wkRsltInfo_DemandDetailWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            wkRsltInfo_DemandDetailWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            wkRsltInfo_DemandDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            wkRsltInfo_DemandDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
            wkRsltInfo_DemandDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            wkRsltInfo_DemandDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkRsltInfo_DemandDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkRsltInfo_DemandDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkRsltInfo_DemandDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRsltInfo_DemandDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            wkRsltInfo_DemandDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            wkRsltInfo_DemandDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkRsltInfo_DemandDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
            wkRsltInfo_DemandDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            wkRsltInfo_DemandDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkRsltInfo_DemandDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
            wkRsltInfo_DemandDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            wkRsltInfo_DemandDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkRsltInfo_DemandDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
            wkRsltInfo_DemandDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            wkRsltInfo_DemandDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            wkRsltInfo_DemandDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            wkRsltInfo_DemandDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            wkRsltInfo_DemandDetailWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
            #endregion

            return wkRsltInfo_DemandDetailWork;
        }

        // ↓ 2007.10.25 980081 d
        #region 詳細形式を削除
        ///// <summary>
        ///// 請求明細一覧表(詳細形式)抽出結果クラス格納処理 Reader → RsltInfo_DemandDetailWork
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>RsltInfo_DemandDetailWork</returns>
        ///// <remarks>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.06.18</br>
        ///// </remarks>
        //private RsltInfo_DemandDetailWork CopyToRsltInfo_DmdDtlExplaTypeFromReader(ref SqlDataReader myReader)
        //{
        //    RsltInfo_DemandDetailWork wkRsltInfo_DemandDetailWork = new RsltInfo_DemandDetailWork();
        //
        //    #region クラスへ格納
        //    wkRsltInfo_DemandDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    wkRsltInfo_DemandDetailWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
        //    wkRsltInfo_DemandDetailWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
        //    wkRsltInfo_DemandDetailWork.ClaimName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME1RF"));
        //    wkRsltInfo_DemandDetailWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
        //    wkRsltInfo_DemandDetailWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    wkRsltInfo_DemandDetailWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
        //    wkRsltInfo_DemandDetailWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
        //    wkRsltInfo_DemandDetailWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
        //    wkRsltInfo_DemandDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
        //    wkRsltInfo_DemandDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
        //    wkRsltInfo_DemandDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
        //    wkRsltInfo_DemandDetailWork.SalesSlipExpNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPEXPNUMRF"));
        //    wkRsltInfo_DemandDetailWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
        //    wkRsltInfo_DemandDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
        //    wkRsltInfo_DemandDetailWork.CarrierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCODERF"));
        //    wkRsltInfo_DemandDetailWork.CarrierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARRIERNAMERF"));
        //    wkRsltInfo_DemandDetailWork.CarrierEpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIEREPCODERF"));
        //    wkRsltInfo_DemandDetailWork.CarrierEpName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARRIEREPNAMERF"));
        //    wkRsltInfo_DemandDetailWork.SalesFormCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESFORMCODERF"));
        //    wkRsltInfo_DemandDetailWork.SalesFormName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESFORMNAMERF"));
        //    wkRsltInfo_DemandDetailWork.SalesContCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCONTCDRF"));
        //    wkRsltInfo_DemandDetailWork.SalesContNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCONTNMRF"));
        //    wkRsltInfo_DemandDetailWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
        //    wkRsltInfo_DemandDetailWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
        //    wkRsltInfo_DemandDetailWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
        //    wkRsltInfo_DemandDetailWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
        //    wkRsltInfo_DemandDetailWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
        //    wkRsltInfo_DemandDetailWork.SalesUnitPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESUNITPRICETAXINCRF"));
        //    wkRsltInfo_DemandDetailWork.SalesUnitPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESUNITPRICETAXEXCRF"));
        //    wkRsltInfo_DemandDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
        //    wkRsltInfo_DemandDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
        //    wkRsltInfo_DemandDetailWork.ProductNumber1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTNUMBER1RF"));
        //    wkRsltInfo_DemandDetailWork.StockTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKTELNO1RF"));
        //    wkRsltInfo_DemandDetailWork.ContractorName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONTRACTORNAMERF"));
        //    wkRsltInfo_DemandDetailWork.IncDtbtTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXINCRF"));
        //    wkRsltInfo_DemandDetailWork.IncDtbtTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXEXCRF"));
        //    wkRsltInfo_DemandDetailWork.IncDtbtTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXFREERF"));
        //    wkRsltInfo_DemandDetailWork.NwopIncDtbtTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NWOPINCDTBTTAXINC"));
        //    wkRsltInfo_DemandDetailWork.NwopIncDtbtTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NWOPINCDTBTTAXEXC"));
        //    wkRsltInfo_DemandDetailWork.NwopIncDtbtTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NWOPINCDTBTTAXFREE"));
        //    wkRsltInfo_DemandDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
        //    wkRsltInfo_DemandDetailWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
        //    wkRsltInfo_DemandDetailWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
        //    //相殺金額
        //    wkRsltInfo_DemandDetailWork.OffsetMoney = wkRsltInfo_DemandDetailWork.SalesMoneyTaxExc - wkRsltInfo_DemandDetailWork.IncDtbtTaxExc - wkRsltInfo_DemandDetailWork.IncDtbtTaxFree - wkRsltInfo_DemandDetailWork.NwopIncDtbtTaxExc - wkRsltInfo_DemandDetailWork.NwopIncDtbtTaxFree;
        //    #endregion
        //
        //    return wkRsltInfo_DemandDetailWork;
        //}
        #endregion
        // ↑ 2007.10.25 980081 d

        /// <summary>
        /// 請求明細一覧表抽出結果クラス格納処理 Reader → RsltInfo_DemandDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_DemandDetailWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.06.18</br>
        /// </remarks>
        private RsltInfo_DemandDetailWork CopyToRsltInfo_DemandDepositFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_DemandDetailWork wkRsltInfo_DemandDetailWork = new RsltInfo_DemandDetailWork();

            #region クラスへ格納
            wkRsltInfo_DemandDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRsltInfo_DemandDetailWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_DemandDetailWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkRsltInfo_DemandDetailWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkRsltInfo_DemandDetailWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkRsltInfo_DemandDetailWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkRsltInfo_DemandDetailWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_DemandDetailWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkRsltInfo_DemandDetailWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkRsltInfo_DemandDetailWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_DemandDetailWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkRsltInfo_DemandDetailWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
            wkRsltInfo_DemandDetailWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
            wkRsltInfo_DemandDetailWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            wkRsltInfo_DemandDetailWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            wkRsltInfo_DemandDetailWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            wkRsltInfo_DemandDetailWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
            wkRsltInfo_DemandDetailWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
            wkRsltInfo_DemandDetailWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            wkRsltInfo_DemandDetailWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
            wkRsltInfo_DemandDetailWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
            wkRsltInfo_DemandDetailWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkRsltInfo_DemandDetailWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkRsltInfo_DemandDetailWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkRsltInfo_DemandDetailWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            wkRsltInfo_DemandDetailWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            #endregion

            return wkRsltInfo_DemandDetailWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.15</br>
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

    /// <summary>
    /// 請求明細書定数定義
    /// </summary>
    public class Const_BillDetailTable
    {
        /// <summary>テーブル名称</summary>
        public enum ct_TableName
        {
            /// <summary>売上詳細データ</summary>
            SalesExplaData = 0,
            /// <summary>売上明細データ</summary>
            SalesDetail = 1,
            /// <summary>売上データ</summary>
            SalesSlip = 2
        }
    }
}
