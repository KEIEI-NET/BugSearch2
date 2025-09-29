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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先過年度実績照会DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先過年度実績照会の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.9.10</br>
    /// <br>Update Note: 2010/08/02 chenyd</br>
    /// <br>             Excel、テキスト出力対応</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// </remarks>
    [Serializable]
    public class CustomInqOrderWorkDB : RemoteDB, ICustomInqOrderWorkDB
    {
        /// <summary>
        /// 得意先過年度実績照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.8</br>
        /// </remarks>
        public CustomInqOrderWorkDB()
            :
        base("PMHNB04125D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork", "MTtlSalesSlipRF") //基底クラスのコンストラクタ
        {
        }

        #region 得意先過年度実績照会
        // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
        /// <summary>
        /// 指定された企業コードの得意先過年度実績照会LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retListObj">検索結果</param>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの得意先過年度実績照会LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/02</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int SearchAll(out object retListObj, object paraList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retListObj = null;
            object retObj = null;

            ArrayList resultWorkList = new ArrayList();
            ArrayList paraCndtnWorkList = paraList as ArrayList;
            ArrayList customInqResultWorkList = new ArrayList();

            SqlConnection sqlConnection = null; // 2011/03/22
            try
            {
                // ---ADD 2011/03/22---------->>>>>
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((CustomInqOrderCndtnWork)paraCndtnWorkList[0]).EnterpriseCode, "得意先過年度実績照会", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                foreach (CustomInqOrderCndtnWork paraCndtnWork in paraCndtnWorkList)
                {

                    status = SearchProc(out retObj, paraCndtnWork, readMode, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        customInqResultWorkList = (ArrayList)retObj;
                        resultWorkList.Add(customInqResultWorkList);
                    }
                }

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((CustomInqOrderCndtnWork)paraCndtnWorkList[0]).EnterpriseCode, "得意先過年度実績照会", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<
                if (resultWorkList.Count >= 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                retListObj = (object)resultWorkList;
                
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqOrderWork.Search Exception=" + ex.Message);
                resultWorkList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // ---ADD 2011/03/22---------->>>>>
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<
            return status;
        }
        // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
        /// <summary>
        /// 指定された企業コードの得意先過年度実績照会LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="customInqResultWorkList">検索結果</param>
        /// <param name="customInqOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの得意先過年度実績照会LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.8</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(out object customInqResultWorkList, object customInqOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            customInqResultWorkList = null;

            CustomInqOrderCndtnWork _customInqOrderCndtnWork = customInqOrderCndtnWork as CustomInqOrderCndtnWork;

            SqlConnection sqlConnection = null; // 2011/03/22
            try
            {
                // ---ADD 2011/03/22---------->>>>>
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _customInqOrderCndtnWork.EnterpriseCode, "得意先過年度実績照会", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                status = SearchProc(out customInqResultWorkList, _customInqOrderCndtnWork, readMode, logicalMode);

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, _customInqOrderCndtnWork.EnterpriseCode, "得意先過年度実績照会", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqOrderWork.Search Exception=" + ex.Message);
                customInqResultWorkList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            // ---ADD 2011/03/22---------->>>>>
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // ---ADD 2011/03/22----------<<<<<
            return status;
        }

        /// <summary>
        /// 指定された企業コードの得意先過年度実績照会LISTを全て戻します
        /// </summary>
        /// <param name="customInqResultWorkList">検索結果</param>
        /// <param name="_customInqOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの得意先過年度実績照会LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object customInqResultWorkList, CustomInqOrderCndtnWork _customInqOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            customInqResultWorkList = null;

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


                status = SearchOrderProc(ref al, ref sqlConnection, _customInqOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomInqResultWorkDB.SearchProc Exception=" + ex.Message);
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

            customInqResultWorkList = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, CustomInqOrderCndtnWork _customInqOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try{
                string selectTxt="";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);
                for (int i = 0; i < 8; i++)
                {
                    selectTxt = "";
                    sqlCommand.Parameters.Clear();
                    #region Select文作成
                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += "	       MTL.ENTERPRISECODERF" + Environment.NewLine;
                    if (_customInqOrderCndtnWork.AddUpSecCode != "")
                    {
                        selectTxt += "        ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                    }
                    selectTxt += "        ,MTL.CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += "        ,(SUM(MTL.SALESMONEYRF) + SUM(MTL.SALESRETGOODSPRICERF) + SUM(MTL.DISCOUNTPRICERF)) AS  SUMSALESMONEYRF" + Environment.NewLine;
                    //selectTxt += "        ,SUM(MTL.SALESRETGOODSPRICERF) AS SUMSALESRETGOODSPRICERF" + Environment.NewLine;
                    //selectTxt += "        ,SUM(MTL.DISCOUNTPRICERF) AS SUMDISCOUNTPRICERF" + Environment.NewLine;
                    selectTxt += "        ,SUM(MTL.GROSSPROFITRF) AS SUMGROSSPROFITRF" + Environment.NewLine;
                    selectTxt += " FROM MTTLSALESSLIPRF AS MTL " + Environment.NewLine;
                    #endregion

                    //WHERE文の作成
                    selectTxt += MakeWhereString(ref sqlCommand, _customInqOrderCndtnWork, logicalMode);

                    selectTxt += " GROUP BY MTL.ENTERPRISECODERF" + Environment.NewLine;
                    if (_customInqOrderCndtnWork.AddUpSecCode != "")
                    {
                        selectTxt += " ,MTL.ADDUPSECCODERF" + Environment.NewLine;
                    }
                    selectTxt += " ,MTL.CUSTOMERCODERF" + Environment.NewLine;

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        CustomInqResultWork wkCustomInqResultWork = new CustomInqResultWork();

                        //格納項目
                        wkCustomInqResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        if (_customInqOrderCndtnWork.AddUpSecCode != "")
                        {
                            wkCustomInqResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        }
                        else
                        {
                            wkCustomInqResultWork.AddUpSecCode = "";
                        }
                        wkCustomInqResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        wkCustomInqResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYRF"));
                        wkCustomInqResultWork.SalesRetGoodsPrice = 0;//SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESRETGOODSPRICERF"));
                        wkCustomInqResultWork.DiscountPrice = 0;//SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMDISCOUNTPRICERF"));
                        wkCustomInqResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFITRF"));
                        #endregion

                        al.Add(wkCustomInqResultWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (al.Count != i+1)
                    {
                        CustomInqResultWork wkCustomInqResultWork = new CustomInqResultWork();
                        wkCustomInqResultWork.EnterpriseCode = "";
                        wkCustomInqResultWork.AddUpSecCode = "";
                        wkCustomInqResultWork.CustomerCode = 0;
                        wkCustomInqResultWork.SalesMoney = 0;
                        wkCustomInqResultWork.SalesRetGoodsPrice = 0;
                        wkCustomInqResultWork.DiscountPrice = 0;
                        wkCustomInqResultWork.GrossProfit = 0;
                        al.Add(wkCustomInqResultWork);
                    }
                    _customInqOrderCndtnWork.St_AddUpYearMonth = _customInqOrderCndtnWork.St_AddUpYearMonth.AddYears(-1);
                    _customInqOrderCndtnWork.Ed_AddUpYearMonth = _customInqOrderCndtnWork.Ed_AddUpYearMonth.AddYears(-1);
                    if (!myReader.IsClosed) myReader.Close();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
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
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustomInqOrderCndtnWork _customInqOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " MTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_customInqOrderCndtnWork.EnterpriseCode);

            if (_customInqOrderCndtnWork.AddUpSecCode != "")
            {
                //計上拠点コード
                retstring += " AND MTL.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_customInqOrderCndtnWork.AddUpSecCode);
            }
            else
            {
                retstring += " AND MTL.ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
            }

            //得意先コード
            retstring += " AND MTL.CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(_customInqOrderCndtnWork.CustomerCode);

            //年月度
            if (_customInqOrderCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_customInqOrderCndtnWork.St_AddUpYearMonth);
            }
            if (_customInqOrderCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND MTL.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_customInqOrderCndtnWork.Ed_AddUpYearMonth);
            }

            // 実績集計区分
            retstring += "  AND MTL.RSLTTTLDIVCDRF = 0" + Environment.NewLine;

            // 従業員区分
            retstring += " AND EMPLOYEEDIVCDRF = 10" + Environment.NewLine;
            #endregion
            return retstring;
        }
    }
}

