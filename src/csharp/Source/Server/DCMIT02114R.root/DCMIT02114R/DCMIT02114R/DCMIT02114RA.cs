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
    /// 見積確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 見積確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.07.03</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正(車両情報の取得)</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br></br>
    /// <br>Update Note: #redmine26537</br>
    /// <br>Programmer : x_zhuxk</br>
    /// <br>Date       : 2011/11/11</br>
    /// <br></br>
    /// <br>Update Note: 見積確認表の性能向上対応</br>
    /// <br>Programmer : 鈴木創</br>
    /// <br>Date       : 2021/09/27</br>
    /// </remarks>
    [Serializable]
    public class EstimateListWorkDB : RemoteDB, IEstimateListWorkDB
    {
        /// <summary>
        /// 見積確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.12</br>
        /// </remarks>
        public EstimateListWorkDB()
            :
            base("DCMIT02116D", "Broadleaf.Application.Remoting.ParamData.EstimateListResultWork", "SALESDETAILRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の見積確認表を戻します
        /// </summary>
        /// <param name="estimateListResultWork">検索結果</param>
        /// <param name="estimateListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の見積確認表を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.12</br>
        public int Search(out object estimateListResultWork, object estimateListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            estimateListResultWork = null;

            EstimateListCndtnWork _estimateListCndtnWork = estimateListCndtnWork as EstimateListCndtnWork;

            try
            {
                status = SearchProc(out estimateListResultWork, _estimateListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EstimateListWorkDB.Search Exception=" + ex.Message);
                estimateListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの見積確認表LISTを全て戻します
        /// </summary>
        /// <param name="estimateListResultWork">検索結果</param>
        /// <param name="_estimateListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの見積確認表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.12</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.12 長内 DC.NS用に修正</br>
        private int SearchProc(out object estimateListResultWork, EstimateListCndtnWork _estimateListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            estimateListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchEstimateProc(ref al, ref sqlConnection, _estimateListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EstimateListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            estimateListResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_estimateListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchEstimateProc(ref ArrayList al, ref SqlConnection sqlConnection, EstimateListCndtnWork _estimateListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // ADD 2021/09/27 --------------------------------------------------->>>>>

                //売上確認表と同じコマンドタイムアウト時間を設定
                sqlCommand.CommandTimeout = 3600;

                // ADD 2021/09/27 ---------------------------------------------------<<<<<

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "    SAS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += ",   SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += ",   SAS.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += ",   SAS.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += ",   SAS.SEARCHSLIPDATERF" + Environment.NewLine;
                selectTxt += ",   SAS.SALESDATERF" + Environment.NewLine;
                selectTxt += ",   SAS.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESROWNORF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATEFORMNORF" + Environment.NewLine;
                selectTxt += ",   SAS.SALESEMPLOYEECDRF" + Environment.NewLine;
                selectTxt += ",   SAS.SALESEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += ",   SAS.SLIPNOTERF" + Environment.NewLine;
                selectTxt += ",   SAS.SLIPNOTE2RF" + Environment.NewLine;
                selectTxt += ",   SAS.SLIPNOTE3RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATEDIVIDERF" + Environment.NewLine;
                selectTxt += ",   SAD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += ",   SAD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += ",   SAD.GOODSNORF" + Environment.NewLine;
                selectTxt += ",   SAD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += ",   SAD.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += ",   SAD.BLGOODSFULLNAMERF" + Environment.NewLine;
                selectTxt += ",   SAD.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += ",   SAD.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESMONEYTAXEXCRF" + Environment.NewLine;
                selectTxt += ",   SAD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += ",   SAD.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += ",   SAD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += ",   SAD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESCODERF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESCDNMRF" + Environment.NewLine;
                selectTxt += ",   SAD.SLIPMEMO1RF" + Environment.NewLine;
                selectTxt += ",   SAD.SLIPMEMO2RF" + Environment.NewLine;
                selectTxt += ",   SAD.SLIPMEMO3RF" + Environment.NewLine;
                selectTxt += ",   SAD.INSIDEMEMO1RF" + Environment.NewLine;
                selectTxt += ",   SAD.INSIDEMEMO2RF" + Environment.NewLine;
                selectTxt += ",   SAD.INSIDEMEMO3RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATENOTE1RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATENOTE2RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATENOTE3RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATENOTE4RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATENOTE5RF" + Environment.NewLine;
                selectTxt += ",   SAS.ESTIMATEVALIDITYDATERF" + Environment.NewLine;
                selectTxt += ",   AOC.MODELFULLNAMERF" + Environment.NewLine;
                selectTxt += ",   AOC.MODELHALFNAMERF" + Environment.NewLine; // ADD 2008.10.31
                selectTxt += ",   AOC.FULLMODELRF" + Environment.NewLine;
                selectTxt += ",   AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                selectTxt += ",   AOC.CATEGORYNORF" + Environment.NewLine;
                selectTxt += ",   AOC.CARMNGCODERF" + Environment.NewLine;
                selectTxt += ",   AOC.FIRSTENTRYDATERF" + Environment.NewLine;
                selectTxt += ",   SAD.SALESSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += ",   SAD.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                selectTxt += ",   SAD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += ",   SAD.ACPTANODRADJUSTCNTRF" + Environment.NewLine;
                // 2011/11/11　add start ------------------------------>>
                selectTxt += ",   SAD.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                selectTxt += ",   ISNULL(SAD.ACCEPTORORDERKINDRF,-1) AS ACCEPTORORDERKINDRF" + Environment.NewLine;

                // 2011/11/11  add end------------------------------<<

                // UPD 2021/09/27 --------------------------------------------------->>>>>
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "    SALESDETAILRF AS SAD" + Environment.NewLine;
                //selectTxt += "LEFT JOIN SALESSLIPRF AS SAS" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "    SALESSLIPRF AS SAS" + Environment.NewLine;
                selectTxt += "LEFT JOIN SALESDETAILRF AS SAD" + Environment.NewLine;
                // UPD 2021/09/27 ---------------------------------------------------<<<<<

                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "     SAD.ENTERPRISECODERF=SAS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SAD.ACPTANODRSTATUSRF=SAS.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += " AND SAD.SALESSLIPNUMRF=SAS.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "     SAS.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SAS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF" + Environment.NewLine;

                // UPD 2021/09/27 --------------------------------------------------->>>>>
                //selectTxt += "LEFT JOIN ACCEPTODRCARRF AS AOC" + Environment.NewLine;
                //selectTxt += " ON" + Environment.NewLine;
                //selectTxt += "     SAD.ENTERPRISECODERF=AOC.ENTERPRISECODERF" + Environment.NewLine;                 
                ////selectTxt += " AND SAD.ACPTANODRSTATUSRF=AOC.ACPTANODRSTATUSRF" + Environment.NewLine; // DEL 2008.10.31
                //selectTxt += " AND AOC.ACPTANODRSTATUSRF=1" + Environment.NewLine; // ADD 2008.10.31
                //selectTxt += " AND SAD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN ACCEPTODRCARRF AS AOC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "     SAD.ENTERPRISECODERF=AOC.ENTERPRISECODERF" + Environment.NewLine;                 
                selectTxt += " AND AOC.ACPTANODRSTATUSRF=1" + Environment.NewLine;
                selectTxt += " AND SAD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += " AND AOC.DATAINPUTSYSTEMRF=10" + Environment.NewLine;
                // UPD 2021/09/27 ---------------------------------------------------<<<<<

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _estimateListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    EstimateListResultWork wkEstimateListResultWork = new EstimateListResultWork();

                    //格納項目
                    wkEstimateListResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkEstimateListResultWork.ResultsAddUpSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkEstimateListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkEstimateListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkEstimateListResultWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    wkEstimateListResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkEstimateListResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkEstimateListResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkEstimateListResultWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
                    wkEstimateListResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                    wkEstimateListResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                    wkEstimateListResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    wkEstimateListResultWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                    wkEstimateListResultWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                    wkEstimateListResultWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
                    wkEstimateListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkEstimateListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkEstimateListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkEstimateListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkEstimateListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkEstimateListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    wkEstimateListResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkEstimateListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkEstimateListResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkEstimateListResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkEstimateListResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkEstimateListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkEstimateListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkEstimateListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkEstimateListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkEstimateListResultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    wkEstimateListResultWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                    wkEstimateListResultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    wkEstimateListResultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    wkEstimateListResultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    wkEstimateListResultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    wkEstimateListResultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    wkEstimateListResultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    wkEstimateListResultWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
                    wkEstimateListResultWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
                    wkEstimateListResultWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
                    wkEstimateListResultWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
                    wkEstimateListResultWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
                    wkEstimateListResultWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
                    wkEstimateListResultWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    wkEstimateListResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF")); // ADD 2008.10.31
                    wkEstimateListResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkEstimateListResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    wkEstimateListResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    wkEstimateListResultWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    wkEstimateListResultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    wkEstimateListResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    wkEstimateListResultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    wkEstimateListResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkEstimateListResultWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
                    // 2011/11/11 add start ----------------------------------------------->>
                    wkEstimateListResultWork.AutoAnswerDivSCMRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));
                    wkEstimateListResultWork.AcceptOrOrderKindRF = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));
                    // 2011/11/11 add end -----------------------------------------------<<
                    #endregion

                    al.Add(wkEstimateListResultWork);

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
                base.WriteErrorLog(ex, "EstimateListWorkDB.SearchEstimateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_estimateListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, EstimateListCndtnWork _estimateListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // UPD 2021/09/27 --------------------------------------------------->>>>>
            //企業コード
            //retstring += " SAD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_estimateListCndtnWork.EnterpriseCode);

            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
            //    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            //{
            //    retstring += " AND SAD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //}
            //else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            //{
            //    retstring += " AND SAD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
            //    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            //}

            retstring += " SAS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_estimateListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SAS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SAS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // UPD 2021/09/27 ---------------------------------------------------<<<<<<

            //拠点コード
            if (_estimateListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _estimateListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND SAS.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //見積日設定
            if (_estimateListCndtnWork.St_SalesDate != DateTime.MinValue)
            {
                retstring += " AND SAS.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_estimateListCndtnWork.St_SalesDate);
            }
            if (_estimateListCndtnWork.Ed_SalesDate != DateTime.MinValue)
            {
                retstring += " AND SAS.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_estimateListCndtnWork.Ed_SalesDate);
            }

            //入力日設定
            if (_estimateListCndtnWork.St_SearchSlipDate != DateTime.MinValue)
            {
                retstring += " AND SAS.SEARCHSLIPDATERF>=@STSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraStSearchSlipDate = sqlCommand.Parameters.Add("@STSEARCHSLIPDATE", SqlDbType.Int);
                paraStSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_estimateListCndtnWork.St_SearchSlipDate);
            }
            if (_estimateListCndtnWork.Ed_SearchSlipDate != DateTime.MinValue)
            {
                retstring += " AND SAS.SEARCHSLIPDATERF<=@EDSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraEdSearchSlipDate = sqlCommand.Parameters.Add("@EDSEARCHSLIPDATE", SqlDbType.Int);
                paraEdSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_estimateListCndtnWork.Ed_SearchSlipDate);
            }

            //担当者コード設定
            if (_estimateListCndtnWork.St_SalesEmployeeCd != "")
            {
                retstring += " AND SAS.SALESEMPLOYEECDRF>=@STSALESEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@STSALESEMPLOYEECD", SqlDbType.NChar);
                paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_estimateListCndtnWork.St_SalesEmployeeCd);
            }
            if (_estimateListCndtnWork.Ed_SalesEmployeeCd != "")
            {
                retstring += " AND (SAS.SALESEMPLOYEECDRF<=@EDSALESEMPLOYEECD OR SAS.SALESEMPLOYEECDRF LIKE @EDSALESEMPLOYEECD)" + Environment.NewLine;
                SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@EDSALESEMPLOYEECD", SqlDbType.NChar);
                paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_estimateListCndtnWork.Ed_SalesEmployeeCd + "%");
            }

            //得意先コード設定
            if (_estimateListCndtnWork.St_CustomerCode != 0)
            {
                retstring += " AND SAS.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(_estimateListCndtnWork.St_CustomerCode);
            }
            if (_estimateListCndtnWork.Ed_CustomerCode != 0)
            {
                retstring += " AND SAS.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(_estimateListCndtnWork.Ed_CustomerCode);
            }

            // UPD 2021/09/27 --------------------------------------------------->>>>>
            //見積伝票
            //retstring += " AND SAD.ACPTANODRSTATUSRF=10" + Environment.NewLine;

            retstring += " AND SAS.ACPTANODRSTATUSRF=10" + Environment.NewLine;
            // UPD 2021/09/27 ---------------------------------------------------<<<<<
            
            // 2008.07.03 add start ----------------------------------------------->>
            //見積タイプ
            if (_estimateListCndtnWork.EstimateDivide == 0)
            {
                retstring += " AND SAS.ESTIMATEDIVIDERF<>3" + Environment.NewLine;
            }
            else if (_estimateListCndtnWork.EstimateDivide == 1)
            {
                retstring += " AND SAS.ESTIMATEDIVIDERF=3" + Environment.NewLine; 
            }

            //発行タイプ
            //if (_estimateListCndtnWork.PrintDiv == 0)
            //{
            //    retstring += " AND SAD.ACPTANODRREMAINCNTRF=0" + Environment.NewLine; 
            //}
            // 2008.07.03 add end -------------------------------------------------<<

            // 2011/11/11 add start ----------------------------------------------->>
            if (_estimateListCndtnWork.AutoAnswerDivSCMRF == 0)
            {
                retstring += " AND SAD.AUTOANSWERDIVSCMRF= 0" + Environment.NewLine;
            }
            else if (_estimateListCndtnWork.AutoAnswerDivSCMRF == 1)
            { 
                if (_estimateListCndtnWork.AcceptOrOrderKindRF == 0 || _estimateListCndtnWork.AcceptOrOrderKindRF == 1)
               {
                   retstring += " AND( SAD.AUTOANSWERDIVSCMRF =0  OR(SAD.AUTOANSWERDIVSCMRF IN (1,2) AND SAD.ACCEPTORORDERKINDRF=@ACCEPTORORDERKINDRF))" + Environment.NewLine;
                    SqlParameter paraAcceptOrOrderKindRF = sqlCommand.Parameters.Add("@ACCEPTORORDERKINDRF", SqlDbType.Int);
                   paraAcceptOrOrderKindRF.Value = SqlDataMediator.SqlSetInt16(_estimateListCndtnWork.AcceptOrOrderKindRF);
               }
               else if (_estimateListCndtnWork.AcceptOrOrderKindRF == 2)
               {
                   retstring += " AND (SAD.AUTOANSWERDIVSCMRF =0 OR (SAD.AUTOANSWERDIVSCMRF IN (1,2) AND SAD.ACCEPTORORDERKINDRF IN (0,1)))" + Environment.NewLine;
               }
               else
               {
                   retstring += " AND (SAD.AUTOANSWERDIVSCMRF =0 OR (SAD.AUTOANSWERDIVSCMRF IN (1,2) AND SAD.ACCEPTORORDERKINDRF NOT IN (0,1)))" + Environment.NewLine;
               }
                
            }
            else if (_estimateListCndtnWork.AutoAnswerDivSCMRF == 2)
            {
                if (_estimateListCndtnWork.AcceptOrOrderKindRF == 0 || _estimateListCndtnWork.AcceptOrOrderKindRF == 1)
                {
                    retstring += " AND SAD.AUTOANSWERDIVSCMRF IN (1,2) AND SAD.ACCEPTORORDERKINDRF = @ACCEPTORORDERKINDRF " + Environment.NewLine;
                    SqlParameter paraAcceptOrOrderKindRF = sqlCommand.Parameters.Add("@ACCEPTORORDERKINDRF", SqlDbType.Int);
                    paraAcceptOrOrderKindRF.Value = SqlDataMediator.SqlSetInt16(_estimateListCndtnWork.AcceptOrOrderKindRF);
                }
                else if (_estimateListCndtnWork.AcceptOrOrderKindRF == 2)
                {
                    retstring += " AND SAD.AUTOANSWERDIVSCMRF IN (1,2) " + Environment.NewLine;
                    retstring += " AND SAD.ACCEPTORORDERKINDRF IN (0,1)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND SAD.AUTOANSWERDIVSCMRF IN (1,2) " + Environment.NewLine;
                    retstring += " AND SAD.ACCEPTORORDERKINDRF  NOT IN (0,1)" + Environment.NewLine;
                }
            }
            // 2011/11/11 add end -------------------------------------------------<<
            #endregion
            return retstring;
        }
    }
}
