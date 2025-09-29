//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力（ＴＭＹ）
// プログラム概要   : 売上データテキスト出力（ＴＭＹ）　リモートオブジェクト 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン
// 作 成 日  2011/10/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 鄧潘ハン 							
// 修 正 日  2012/11/21  修正内容 : Redmine#33560　 							
//　　　　　　　　　　　　　　　　　①仕入先についての仕様変更	
//                                  ②得意先分析コード６の有効についての修正
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Data;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データテキスト出力（ＴＭＹ）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキスト出力（ＴＭＹ）DBリモートオブジェクト</br>										
    /// <br>Programmer : 鄧潘ハン</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>管理番号   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             ①仕入先についての仕様変更</br>
    /// <br>　　　　　　 ②得意先分析コード６の有効についての修正</br> 
    /// </remarks>
    [Serializable]
    public class SalesSliptextResultDB : RemoteDB, ISalesSliptextResultDB
    {
        /// <summary>
        /// 売上データテキスト出力（ＴＭＹ）コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力（ＴＭＹ）DBリモートオブジェクト</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public SalesSliptextResultDB()
            :
        base("PMKHN07707D", "Broadleaf.Application.Remoting.ParamData.SalesSliptextResultDB", "SALESHISTORYRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの売上データテキスト出力（ＴＭＹ）の全て戻る処理（論理削除除く）
        /// </summary>
        /// <param name="salesSliptextResultWork">検索結果</param>
        /// <param name="salesSliptextcndtnWork">検索パラメータ</param>
        /// <param name="retMsg">retMsg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの売上データテキスト出力（ＴＭＹ）の全て戻る処理（論理削除除く）</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// </remarks>
        public int Search(out object salesSliptextResultWork, object salesSliptextcndtnWork, out string retMsg)
        {
            SqlConnection sqlConnection = null;
            salesSliptextResultWork = null;
            retMsg = string.Empty;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesSliptextResultWork, salesSliptextcndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                retMsg = ex.Message;
                base.WriteErrorLog(ex, "SalesSliptextResultDB.Search");
                salesSliptextResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                else
                {
                    //なし。
                } 
            }
        }

        /// <summary>
        /// 指定された企業コードの売上データテキスト出力（ＴＭＹ）を全て戻る処理
        /// </summary>
        /// <param name="salesSliptextResultWork">検索結果</param>
        /// <param name="salesSliptextcndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの売上データテキスト出力（ＴＭＹ）を全て戻る処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             ①仕入先についての仕様変更</br>
        /// </remarks>
        private int SearchProc(out object salesSliptextResultWork, object salesSliptextcndtnWork, ref SqlConnection sqlConnection)
        {
            SalesSliptextCndtnWork cndtnWork = salesSliptextcndtnWork as SalesSliptextCndtnWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesSliptextResultWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                StringBuilder sb = new StringBuilder();

                sb.Append(" SELECT " + Environment.NewLine);
                sb.Append(" A.CUSTOMERCODERF, " + Environment.NewLine);
                sb.Append(" A.SALESDATERF," + Environment.NewLine);
                sb.Append(" A.SALESSLIPNUMRF," + Environment.NewLine);
                sb.Append(" B.GOODSNORF, " + Environment.NewLine);
                sb.Append(" B.GOODSMAKERCDRF, " + Environment.NewLine);
                sb.Append(" B.BLGOODSCODERF, " + Environment.NewLine);
                sb.Append(" B.SHIPMENTCNTRF, " + Environment.NewLine);
                sb.Append(" B.SUPPLIERCDRF, " + Environment.NewLine);
                sb.Append(" B.SALESROWNORF " + Environment.NewLine);
                sb.Append(" FROM ");
                sb.Append(" SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine);  //売上履歴データ　A
                sb.Append(" INNER JOIN ");
                sb.Append(" SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine);  //売上履歴明細データ B
                sb.Append(" ON ");
                sb.Append(" A.ENTERPRISECODERF =  B.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF " + Environment.NewLine);
                sb.Append(" AND " + Environment.NewLine);
                //sb.Append(" B.LOGICALDELETECODERF = 0 " + Environment.NewLine);//DEL　鄧潘ハン　2012/11/21 Redmine33560
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                sb.Append(" A.LOGICALDELETECODERF = @LOGICALDELETECODEA " + Environment.NewLine);
                SqlParameter logicalDeleteCodeA = sqlCommand.Parameters.Add("@LOGICALDELETECODEA", SqlDbType.Int);
                logicalDeleteCodeA.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                sb.Append(" AND " + Environment.NewLine);
                sb.Append(" B.LOGICALDELETECODERF = @LOGICALDELETECODEB " + Environment.NewLine);
                SqlParameter logicalDeleteCodeB = sqlCommand.Parameters.Add("@LOGICALDELETECODEB", SqlDbType.Int);
                logicalDeleteCodeB.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                //---ADD　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
                sb.Append(" LEFT JOIN " + Environment.NewLine);
                sb.Append(" CUSTOMERRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine);      //得意先マスタ C
                sb.Append(" ON ");
                sb.Append(" A.ENTERPRISECODERF =  C.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" A.CUSTOMERCODERF =  C.CUSTOMERCODERF " + Environment.NewLine);
                sb.Append(" LEFT JOIN ");
                sb.Append(" ACCEPTODRCARRF AS D WITH (READUNCOMMITTED)" + Environment.NewLine);   // 受注マスタ（車両） D
                sb.Append(" ON ");
                sb.Append(" B.ENTERPRISECODERF =  D.ENTERPRISECODERF " + Environment.NewLine);
                sb.Append(" AND ");
                sb.Append(" B.ACCEPTANORDERNORF =  D.ACCEPTANORDERNORF " + Environment.NewLine);
          
                sb.Append(" AND ");
                //受注ステータス＝「7:売上」
                sb.Append(" D.ACPTANODRSTATUSRF = @ACPTANODRSTATUSR " + Environment.NewLine);
                SqlParameter paraAcpt = sqlCommand.Parameters.Add("@ACPTANODRSTATUSR", SqlDbType.Int);
                paraAcpt.Value = SqlDataMediator.SqlSetInt(7);
                sb.Append(" AND ");
                //D.データ入力システム＝「10:PM」　　　
                sb.Append(" D.DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM " + Environment.NewLine);
                SqlParameter paraDataInputSys = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSys.Value = SqlDataMediator.SqlSetInt(10);
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
                //sb.Append(" AND ");
                //sb.Append(" D.LOGICALDELETECODERF = 0 " + Environment.NewLine);
                //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<
              
                 // 検索条件
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.SALESDATERF,A.CUSTOMERCODERF DESC,A.SALESSLIPNUMRF,B.SALESROWNORF  " + Environment.NewLine);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SalesSliptextResultWork wkSalesSliptextResultWork = new SalesSliptextResultWork();
                    //データ結果取得内容格納
                    wkSalesSliptextResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); //得意先ｺｰﾄﾞ
                    wkSalesSliptextResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));       //売上日付
                    wkSalesSliptextResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));//売上伝票番号
                    wkSalesSliptextResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));          //商品番号
                    wkSalesSliptextResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); //商品メーカーコード
                    wkSalesSliptextResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));   //BL商品コード
                    wkSalesSliptextResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));  //出荷数
                    wkSalesSliptextResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));     //仕入先コード
                    wkSalesSliptextResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));     //売上行番号
                    #endregion

                    al.Add(wkSalesSliptextResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    //なし。
                } 

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SalesSliptextResultDB.SearchProc", status);
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                else
                {
                    //なし。
                } 

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                else
                {
                    //なし。
                } 
            }

            salesSliptextResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesSliptextCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 鄧潘ハン</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             ①仕入先についての仕様変更</br>
        /// <br>　　　　　　 ②得意先分析コード６の有効についての修正</br> 
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesSliptextCndtnWork salesSliptextCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE " + Environment.NewLine;
            string retstringor = "";

            //企業コード
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.EnterpriseCode);

            //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            //売上履歴データ.論理削除区分
            //retstring += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
            //SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            //paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

            //受注ステータス
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUS" + Environment.NewLine;
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            // AND 対象日付>＝パラメータ.対象日の開始日																																	
            if (!DateTime.MinValue.Equals(salesSliptextCndtnWork.SalesDateSt))
            {
                retstring += " AND A.SALESDATERF>=@SALESDATEST " + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesSliptextCndtnWork.SalesDateSt);
            }
            else
            {
                //なし。
            } 

            // AND 対象日付<＝パラメータ.対象日の終了日
            if (!DateTime.MinValue.Equals(salesSliptextCndtnWork.SalesDateEd))
            {
                retstring += " AND A.SALESDATERF<=@SALESDATEED " + Environment.NewLine;
                SqlParameter paraAddUpADateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                paraAddUpADateEd.Value = SqlDataMediator.SqlSetInt32(salesSliptextCndtnWork.SalesDateEd);
            }
            else
            {
                //なし。
            } 

            //B.商品メーカーコード>＝1000
            retstring += " AND B.GOODSMAKERCDRF>=@GOODSMAKERCD" + Environment.NewLine;
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);


            //B.売上伝票区分（明細）＝「0:売上」 OR B.売上伝票区分（明細）＝「1:返品」
            retstring += " AND (B.SALESSLIPCDDTLRF = @SALESSLIPCDDTLRFA OR B.SALESSLIPCDDTLRF = @SALESSLIPCDDTLRFB)" + Environment.NewLine;
            SqlParameter paraSalesSlipCdDtl1= sqlCommand.Parameters.Add("@SALESSLIPCDDTLRFA", SqlDbType.Int);
            paraSalesSlipCdDtl1.Value = SqlDataMediator.SqlSetInt32(0);

            SqlParameter paraSalesSlipCdDtl2 = sqlCommand.Parameters.Add("@SALESSLIPCDDTLRFB", SqlDbType.Int);
            paraSalesSlipCdDtl2.Value = SqlDataMediator.SqlSetInt32(1);

            //---ADD　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            //仕入先コード
            if (salesSliptextCndtnWork.SupplierCd != 0)
            {
                retstring += " AND B.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.SupplierCd);
            }
            else
            {
                //なし。
            }
            //---ADD　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

            //B.商品番号 ≠　NULL
            retstring += " AND B.GOODSNORF IS NOT NULL AND (" + Environment.NewLine;

            //伝票備考値がある
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote))
            {
                retstringor += " A.SLIPNOTERF LIKE @SLIPNOTE" + Environment.NewLine;
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote + "%");
            }
            else
            {
                //なし。
            } 

            //伝票備考２値がある
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote2))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                retstringor += "A.SLIPNOTE2RF LIKE @SLIPNOTE2" + Environment.NewLine;
                SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@SLIPNOTE2", SqlDbType.NVarChar);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote2 + "%");
            }
            else
            {
                //なし。
            } 

            //伝票備考３値がある
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.SlipNote3))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "A.SLIPNOTE3RF LIKE @SLIPNOTE3" + Environment.NewLine;
                SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@SLIPNOTE3", SqlDbType.NVarChar);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.SlipNote3 + "%");
            }
            else
            {
                //なし。
            } 

            //得意先分析コード1値がある
            if (salesSliptextCndtnWork.CustAnalysCode1 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "C.CUSTANALYSCODE1RF=@CUSTANALYSCODE1" + Environment.NewLine;
                SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode1);
            }
            else
            {
                //なし。
            } 

            //得意先分析コード2値がある
            if (salesSliptextCndtnWork.CustAnalysCode2 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "C.CUSTANALYSCODE2RF=@CUSTANALYSCODE2" + Environment.NewLine;
                SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode2);
            }
            else
            {
                //なし。
            } 

            //得意先分析コード3値がある
            if (salesSliptextCndtnWork.CustAnalysCode3 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "C.CUSTANALYSCODE3RF=@CUSTANALYSCODE3" + Environment.NewLine;
                SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode3);
            }
            else
            {
                //なし。
            } 

            //得意先分析コード4値がある
            if (salesSliptextCndtnWork.CustAnalysCode4 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "C.CUSTANALYSCODE4RF=@CUSTANALYSCODE4" + Environment.NewLine;
                SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode4);
            }
            else
            {
                //なし。
            } 

            //得意先分析コード5値がある
            if (salesSliptextCndtnWork.CustAnalysCode5 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "C.CUSTANALYSCODE5RF=@CUSTANALYSCODE5" + Environment.NewLine;
                SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode5);
            }
            else
            {
                //なし。
            } 

            //得意先分析コード6値がある
            if (salesSliptextCndtnWork.CustAnalysCode6 != 0)
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                //retstringor += "C.CUSTANALYSCODE5RF=@CUSTANALYSCODE6" + Environment.NewLine;//DEL　鄧潘ハン　2012/11/21 Redmine33560
                retstringor += "C.CUSTANALYSCODE6RF=@CUSTANALYSCODE6" + Environment.NewLine;//ADD　鄧潘ハン　2012/11/21 Redmine33560
                SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.CustAnalysCode6);
            }
            else
            {
                //なし。
            } 

            //車輌管理コード
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.CarMngNo1))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                }
                retstringor += "D.CARMNGCODERF=@CARMNGCODE" + Environment.NewLine;
                SqlParameter paraCarMngNo1 = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);
                paraCarMngNo1.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.CarMngNo1);
            }
            else
            {
                //なし。
            } 

            //---DEL　鄧潘ハン　2012/11/21 Redmine33560--------------------->>>>>
            //仕入先コード
            //if (salesSliptextCndtnWork.SupplierCd != 0)
            //{
            //    if (!string.IsNullOrEmpty(retstringor))
            //    {
            //        retstringor += " OR ";
            //    }
            //    else
            //    {
            //        //なし。
            //    } 
            //    retstringor += "B.SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
            //    paraSupplierCd.Value = SqlDataMediator.SqlSetInt(salesSliptextCndtnWork.SupplierCd);
            //}
            //else
            //{
            //    //なし。
            //}
            //---DEL　鄧潘ハン　2012/11/21 Redmine33560---------------------<<<<<

            //相手先伝票番号
            if (!string.IsNullOrEmpty(salesSliptextCndtnWork.PartySaleSlipNum))
            {
                if (!string.IsNullOrEmpty(retstringor))
                {
                    retstringor += " OR ";
                }
                else
                {
                    //なし。
                } 
                retstringor += "A.PARTYSALESLIPNUMRF=@PARTYSALESLIPNUMRF" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUMRF", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(salesSliptextCndtnWork.PartySaleSlipNum);
            }
            else
            {
                //なし。
            } 
            retstring += retstringor;
            retstring += " )";
            #endregion
            return retstring;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
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
                else
                {
                    //なし。
                } 
            }
            else
            {
                //なし。
            } 

            //SqlConnection返す
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>										
        /// <br>Programmer : 鄧潘ハン</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>管理番号   : 10805731-00</br>
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
                else
                {
                    //なし。
                } 

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }
            else
            {
                //なし。
            } 

            return retSqlTransaction;
        }
        #endregion  //コネクション生成処理
    }
}
