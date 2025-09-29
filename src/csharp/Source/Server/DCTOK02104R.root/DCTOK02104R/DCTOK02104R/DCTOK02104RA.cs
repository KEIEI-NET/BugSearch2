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
using Broadleaf.Library;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 前年対比表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 前年対比表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.11.29</br>
    /// <br></br>
    /// <br>UpdateNote : 返品金額が二重集計されている対応</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.04.02</br>
    /// <br></br>
    /// <br>UpdateNote : グループコードマスタ未登録時のグループコード別の抽出不具合の修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2011/02/10</br>
    /// <br></br>
    /// <br>UpdateNote : イスコ対応・READUNCOMMITTED対応</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br></br>
    /// <br>UpdateNote : 発行タイプ「管理拠点別」で全社集計で印刷する時、データが抽出されない障害の対応</br>
    /// <br>Programmer : #47029 cheq</br>
    /// <br>Date       : 2015/08/17</br>
    /// </remarks>
    [Serializable]
    public class PrevYearComparisonDB : RemoteDB, IPrevYearComparisonDB
    {
        /// <summary>
        /// 前年対比表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
        /// </remarks>
        public PrevYearComparisonDB()
            :
            base("DCTOK02106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PrevYearComparisonWork", "MTTLSALESSLIPRF")
        {
        }

        #region [SearchPrevYearComparison]
        /// <summary>
        /// 指定された条件の前年対比表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の前年対比表を戻します</br>
        /// <br>           : 12ヶ月を超える範囲を指定されたら該当データ無しとします</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
        public int SearchPrevYearComparison(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork = null;
            //RsltInfo_PrevYearComparisonWork rsltInfo_PrevYearComparisonWork = null;

            ArrayList extrInfo_PrevYearComparisonWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PrevYearComparisonWorkList == null)
            {
                extrInfo_PrevYearComparisonWork = paraObj as ExtrInfo_PrevYearComparisonWork;
            }
            else
            {
                if (extrInfo_PrevYearComparisonWorkList.Count > 0)
                    extrInfo_PrevYearComparisonWork = extrInfo_PrevYearComparisonWorkList[0] as ExtrInfo_PrevYearComparisonWork;
            }

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTMTTLSALSLIPRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //●それぞれの前年対比表取得
                status = SearchPrevYearComparisonProc(ref retList, extrInfo_PrevYearComparisonWork, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PrevYearComparisonDB.SearchPrevYearComparison");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// 指定された条件の前年対比表を戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="extrInfo_PrevYearComparisonWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の前年対比表を戻します</br>
        /// <br>           : 12ヶ月を超える範囲を指定されたら該当データ無しとします</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
        /// <br></br>
        private int SearchPrevYearComparisonProc(ref ArrayList retList, ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            Int32 monthRange = ((extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth / 100) - (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth / 100)) * 12 + (extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth % 100) - (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth % 100) + 1;
            //12ヶ月を超える範囲を指定されたら該当データ無しとします
            if (monthRange > 12)
            {
                return status;
            }

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                #region [SQL文]
                //GroupBy句を退避
                string groupByString = string.Empty;
                string joinString = string.Empty;

                string selectTxt = string.Empty;

                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   MAIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.NAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGOODSHALFNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,MAIN.GOODSMGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BLGROUPKANANAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SALESAREACODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.SALESAREANAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BUSINESSTYPECODERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.BUSINESSTYPENAMERF" + Environment.NewLine;
                selectTxt += "  ,MAIN.ADDUPYEARMONTHRF AS ADDUPMONTHRF" + Environment.NewLine;  //月でグループ化するため
                selectTxt += "  ,SUM(MAIN.THISTERMSALESRF) AS THISTERMSALESRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.THISTERMGROSSRF) AS THISTERMGROSSRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.FIRSTTERMSALESRF) AS FIRSTTERMSALESRF" + Environment.NewLine;
                selectTxt += "  ,SUM(MAIN.FIRSTTERMGROSSRF) AS FIRSTTERMGROSSRF" + Environment.NewLine;

                sqlCommand.CommandText += selectTxt;

                sqlCommand.CommandText += "FROM (" + Environment.NewLine;

                for (int loopcnt = 0; loopcnt <= 1; loopcnt++)
                {
                    //loopcnt=1は前年分を抽出するクエリを作成
                    if (loopcnt == 1)
                    {
                        sqlCommand.CommandText += "UNION ALL" + Environment.NewLine;
                    }

                    sqlCommand.CommandText += MakeSelectHeader(extrInfo_PrevYearComparisonWork, ref joinString ,loopcnt);

                    //各種マスタＪＯＩＮ句
                    sqlCommand.CommandText += joinString;

                    //WHERE句
                    sqlCommand.CommandText += MakeWhereString(extrInfo_PrevYearComparisonWork, ref sqlCommand, loopcnt);


                }

                sqlCommand.CommandText += ") AS MAIN" + Environment.NewLine;

                //GROUP BY句
                groupByString = " GROUP BY" + Environment.NewLine;
                groupByString += "   MAIN.ADDUPSECCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SECTIONGUIDESNMRF" + Environment.NewLine;
                groupByString += "  ,MAIN.CUSTOMERCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.CUSTOMERSNMRF" + Environment.NewLine;
                groupByString += "  ,MAIN.EMPLOYEECODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.NAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGOODSCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGOODSHALFNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSLGROUPRF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSLGROUPNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSMGROUPRF" + Environment.NewLine;
                groupByString += "  ,MAIN.GOODSMGROUPNAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGROUPCODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BLGROUPKANANAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SALESAREACODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.SALESAREANAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BUSINESSTYPECODERF" + Environment.NewLine;
                groupByString += "  ,MAIN.BUSINESSTYPENAMERF" + Environment.NewLine;
                groupByString += "  ,MAIN.ADDUPYEARMONTHRF" + Environment.NewLine;

                sqlCommand.CommandText += groupByString;

                #endregion

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                RsltInfo_PrevYearComparisonWork rsltInfo_PrevYearComparisonWork;
                while (myReader.Read())
                {
                    rsltInfo_PrevYearComparisonWork = CopyToRsltInfo_PrevYearComparisonFromReader(ref myReader, extrInfo_PrevYearComparisonWork);

                    retList.Add(rsltInfo_PrevYearComparisonWork);
                }

                if (!myReader.IsClosed) myReader.Close();

                if (retList.Count != 0)
                {
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

        #region [前年対比表抽出結果クラス格納処理]
        /// <summary>
        /// 前年対比表抽出結果クラス格納処理 Reader → RsltInfo_PrevYearComparisonWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_PrevYearComparisonWork">抽出条件</param>
        /// <returns>RsltInfo_PrevYearComparisonWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
        /// <br></br>
        /// </remarks>
        private RsltInfo_PrevYearComparisonWork CopyToRsltInfo_PrevYearComparisonFromReader(ref SqlDataReader myReader,ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork)
        {
            RsltInfo_PrevYearComparisonWork wkRsltInfo_PrevYearComparisonWork = new RsltInfo_PrevYearComparisonWork();

            wkRsltInfo_PrevYearComparisonWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PrevYearComparisonWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkRsltInfo_PrevYearComparisonWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_PrevYearComparisonWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_PrevYearComparisonWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkRsltInfo_PrevYearComparisonWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkRsltInfo_PrevYearComparisonWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRsltInfo_PrevYearComparisonWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            wkRsltInfo_PrevYearComparisonWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkRsltInfo_PrevYearComparisonWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkRsltInfo_PrevYearComparisonWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkRsltInfo_PrevYearComparisonWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkRsltInfo_PrevYearComparisonWork.AddUpMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPMONTHRF"));
            wkRsltInfo_PrevYearComparisonWork.ThisTermSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTERMSALESRF"));
            wkRsltInfo_PrevYearComparisonWork.FirstTermSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FIRSTTERMSALESRF"));
            wkRsltInfo_PrevYearComparisonWork.ThisTermGross = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTERMGROSSRF"));
            wkRsltInfo_PrevYearComparisonWork.FirstTermGross = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FIRSTTERMGROSSRF"));

            return wkRsltInfo_PrevYearComparisonWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.11.29</br>
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

        #region その他の関数
        /// <summary>
        /// 年月＋ｎ月の値取得処理
        /// </summary>
        /// <param name="yearMonth">年月</param>
        /// <param name="addMonth">加算年月</param>
        /// <returns>年月</returns>
        /// <br>Note       : 指定された年月に＋ｎ月した値を返します。</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.11.29</br>		
        private int GetAddYearMonth(int yearMonth, int addMonth)
        {
            DateTime dateTime = new DateTime();
            dateTime = TDateTime.LongDateToDateTime(yearMonth * 100 + 1);
            dateTime = dateTime.AddMonths(addMonth);
            return dateTime.Year * 100 + dateTime.Month;
        }

        #endregion


        /// <summary>
        /// SELECT分作成
        /// </summary>
        /// <param name="extrInfo_PrevYearComparisonWork">抽出条件</param>
        /// <param name="joinString">JOIN句</param>
        /// <param name="mode">0:当期、1:前期</param>
        /// <returns>SELECT文</returns>
        /// <br>Note       : SELECT文を作成します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.05</br>		
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 データが抽出されないの障害対応</br>
        private string MakeSelectHeader(ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref string joinString ,int mode)
        {
            string selectTxt = string.Empty;

            selectTxt += "SELECT ";
            joinString = string.Empty;

            //帳票タイプ
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                //0:得意先別
                case 0:
                    {
                        //発行タイプ
                        //0:得意先別
                        //1:拠点別
                        //2:得意先拠点別
                        //3:管理拠点別
                        //4:請求先別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            //拠点毎
                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if ((extrInfo_PrevYearComparisonWork.printType == 3) ||
                                (extrInfo_PrevYearComparisonWork.printType == 4))
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<

                            }
                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //得意先コード
                        if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                            (extrInfo_PrevYearComparisonWork.printType == 2) ||
                            (extrInfo_PrevYearComparisonWork.printType == 3))
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        if (extrInfo_PrevYearComparisonWork.printType == 4)
                        {
                            selectTxt += ", CUS.CLAIMCODERF AS CUSTOMERCODERF "
                                       + ", CUS2.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS2 ON CUS.ENTERPRISECODERF=CUS2.ENTERPRISECODERF AND CUS.CLAIMCODERF=CUS2.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=CUS2.ENTERPRISECODERF AND CUS.CLAIMCODERF=CUS2.CUSTOMERCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //不要項目
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //1:担当者別
                case 1:
                    {
                        //発行タイプ
                        //0:担当者別
                        //1:得意先別
                        //2:担当者拠点別
                        //3:管理拠点別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 データが抽出されない障害の対応 ----->>>>>
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            }
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 データが抽出されない障害の対応 -----<<<<<
                        }

                        //担当者コード
                        selectTxt += ", TTL.EMPLOYEECODERF "
                                   + ", EMP.NAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        // 2011/08/01 <<<

                        //得意先コード
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //不要項目
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //2:受注者別
                case 2:
                    {
                        //発行タイプ
                        //0:受注者別
                        //1:得意先別
                        //2:受注者拠点別
                        //3:管理拠点別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<

                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                            // ----- ADD cheq 2015/08/17 RedMine#47029 データが抽出されない障害の対応 ----->>>>>
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            }
                            // ----- ADD  cheq 2015/08/17 RedMine#47029 データが抽出されない障害の対応 -----<<<<<
                        }

                        //担当者コード
                        selectTxt += ", TTL.EMPLOYEECODERF "
                                   + ", EMP.NAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                        // 2011/08/01 <<<

                        //得意先コード
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //不要項目
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //3:地区別
                case 3:
                    {
                        //発行タイプ
                        //0:地区別
                        //1:得意先別
                        //2:地区拠点別
                        //3:管理拠点別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }


                        //地区コード
                        selectTxt += ", (CASE WHEN CUS.SALESAREACODERF IS NULL THEN 0 ELSE CUS.SALESAREACODERF END) AS SALESAREACODERF "
                                   + ", AREA.GUIDENAMERF AS SALESAREANAMERF ";

                        if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                        {
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS AREA ON TTL.ENTERPRISECODERF=AREA.ENTERPRISECODERF AND AREA.USERGUIDEDIVCDRF=21 AND CUS.SALESAREACODERF=AREA.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS AREA WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=AREA.ENTERPRISECODERF AND AREA.USERGUIDEDIVCDRF=21 AND CUS.SALESAREACODERF=AREA.GUIDECODERF ";
                        // 2011/08/01 <<<


                        //得意先コード
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }
                        
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //不要項目
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        break;
                    }
                //4:業種別
                case 4:
                    {
                        //発行タイプ
                        //0:業種別
                        //1:得意先別
                        //2:業種拠点別
                        //3:管理拠点別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            if ((extrInfo_PrevYearComparisonWork.printType == 0) ||
                                (extrInfo_PrevYearComparisonWork.printType == 1) ||
                                (extrInfo_PrevYearComparisonWork.printType == 2))
                            {
                                selectTxt += "  TTL.ADDUPSECCODERF "
                                           + ", SEC.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                            else
                            if (extrInfo_PrevYearComparisonWork.printType == 3)
                            {
                                selectTxt += "  CUS.MNGSECTIONCODERF AS ADDUPSECCODERF "
                                           + ", SEC2.SECTIONGUIDESNMRF ";

                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                //joinString += "LEFT JOIN SECINFOSETRF AS SEC2 ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN SECINFOSETRF AS SEC2 WITH (READUNCOMMITTED) ON CUS.ENTERPRISECODERF=SEC2.ENTERPRISECODERF AND CUS.MNGSECTIONCODERF=SEC2.SECTIONCODERF ";
                                // 2011/08/01 <<<
                            }
                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //業種コード
                        selectTxt += ", (CASE WHEN CUS.BUSINESSTYPECODERF IS NULL THEN 0 ELSE CUS.BUSINESSTYPECODERF END) AS BUSINESSTYPECODERF "
                                   + ", BUS.GUIDENAMERF AS BUSINESSTYPENAMERF ";

                        if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                        {
                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS BUS ON TTL.ENTERPRISECODERF=BUS.ENTERPRISECODERF AND BUS.USERGUIDEDIVCDRF=33 AND CUS.BUSINESSTYPECODERF=BUS.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS BUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BUS.ENTERPRISECODERF AND BUS.USERGUIDEDIVCDRF=33 AND CUS.BUSINESSTYPECODERF=BUS.GUIDECODERF ";
                        // 2011/08/01 <<<

                        //得意先コード
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            if (joinString.Contains("LEFT JOIN CUSTOMERRF AS CUS ") == false)
                            {
                                // 2011/08/01 >>>
                                //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                                // 2011/08/01 <<<
                            }

                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        //不要項目
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";

                        break;
                    }
                //5:グループコード別
                case 5:
                    {
                        //発行タイプ
                        //0:グループコード別
                        //1:商品中分類別
                        //2:商品大分類別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {
                            selectTxt += "  TTL.ADDUPSECCODERF "
                                       + ", SEC.SECTIONGUIDESNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }

                        //グループコード
                        if (extrInfo_PrevYearComparisonWork.printType == 0)
                        {
                            selectTxt += ", BL.BLGROUPCODERF "
                                       + ", GRP.BLGROUPKANANAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 BLGROUPCODERF "
                                       + ", '' BLGROUPKANANAMERF ";
                        }
                        
                        //商品中分類
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", GRP.GOODSMGROUPRF "
                                       + ", GDM.GOODSMGROUPNAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 GOODSMGROUPRF "
                                       + ", '' GOODSMGROUPNAMERF ";
                        }

                        //商品大分類
                        if (extrInfo_PrevYearComparisonWork.printType == 2)
                        {
                            
                            // -- UPD 2011/02/10 ------------------------>>>
                            //selectTxt += ", GRP.GOODSLGROUPRF "
                            selectTxt += ", (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END) AS GOODSLGROUPRF"
                            // -- UPD 2011/02/10 ------------------------<<<
                                       + ", GDL.GUIDENAMERF AS GOODSLGROUPNAMERF ";

                        }
                        else
                        {
                            selectTxt += ", 0 GOODSLGROUPRF "
                                       + ", '' GOODSLGROUPNAMERF ";
                        }

                        //不要項目
                        selectTxt += ", 0 CUSTOMERCODERF "
                                   + ", '' CUSTOMERSNMRF ";
                        selectTxt += ", '0' EMPLOYEECODERF "
                                   + ", '' NAMERF ";
                        selectTxt += ", 0 BLGOODSCODERF "
                                   + ", '' BLGOODSHALFNAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN BLGOODSCDURF AS BL ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        //joinString += "LEFT JOIN BLGROUPURF AS GRP ON BL.ENTERPRISECODERF=GRP.ENTERPRISECODERF AND BL.BLGROUPCODERF=GRP.BLGROUPCODERF ";
                        //joinString += "LEFT JOIN GOODSGROUPURF AS GDM ON GRP.ENTERPRISECODERF=GDM.ENTERPRISECODERF AND GRP.GOODSMGROUPRF=GDM.GOODSMGROUPRF ";
                        joinString += "LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        joinString += "LEFT JOIN BLGROUPURF AS GRP WITH (READUNCOMMITTED) ON BL.ENTERPRISECODERF=GRP.ENTERPRISECODERF AND BL.BLGROUPCODERF=GRP.BLGROUPCODERF ";
                        joinString += "LEFT JOIN GOODSGROUPURF AS GDM WITH (READUNCOMMITTED) ON GRP.ENTERPRISECODERF=GDM.ENTERPRISECODERF AND GRP.GOODSMGROUPRF=GDM.GOODSMGROUPRF ";
                        // 2011/08/01 <<<
                        // -- UPD 2011/02/10 ---------------------------------------->>>
                        //joinString += "LEFT JOIN USERGDBDURF AS GDL ON GRP.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND GRP.GOODSLGROUPRF=GDL.GUIDECODERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN USERGDBDURF AS GDL ON TTL.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END)=GDL.GUIDECODERF ";
                        joinString += "LEFT JOIN USERGDBDURF AS GDL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=GDL.ENTERPRISECODERF AND GDL.USERGUIDEDIVCDRF=70 AND (CASE WHEN GRP.GOODSLGROUPRF IS NULL THEN 0 ELSE GRP.GOODSLGROUPRF END)=GDL.GUIDECODERF ";
                        // 2011/08/01 <<<
                        // -- UPD 2011/02/10 ----------------------------------------<<<

                        break;
                    }
                //6:BLコード別
                case 6:
                    {
                        //発行タイプ
                        //0:BLコード別
                        //1:BLコード得意先別
                        //2:BLコード担当者別

                        //全社集計対応
                        //拠点コード
                        if (extrInfo_PrevYearComparisonWork.TotalWay == 1)
                        {

                            selectTxt += "  TTL.ADDUPSECCODERF "
                                       + ", SEC.SECTIONGUIDESNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN SECINFOSETRF AS SEC ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            joinString += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND TTL.ADDUPSECCODERF=SEC.SECTIONCODERF ";
                            // 2011/08/01 <<<

                        }
                        else
                        {
                            //全社
                            selectTxt += "  '00' AS ADDUPSECCODERF "
                                       + ", '' AS SECTIONGUIDESNMRF ";
                        }


                        //BLコード
                        selectTxt += ", TTL.BLGOODSCODERF "
                                   + ", BL.BLGOODSHALFNAMERF ";

                        // 2011/08/01 >>>
                        //joinString += "LEFT JOIN BLGOODSCDURF AS BL ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        joinString += "LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=BL.ENTERPRISECODERF AND TTL.BLGOODSCODERF=BL.BLGOODSCODERF ";
                        // 2011/08/01 <<<

                        //得意先コード
                        if (extrInfo_PrevYearComparisonWork.printType == 1)
                        {
                            selectTxt += ", TTL.CUSTOMERCODERF "
                                       + ", CUS.CUSTOMERSNMRF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN CUSTOMERRF AS CUS ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            joinString += "LEFT JOIN CUSTOMERRF AS CUS WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=CUS.ENTERPRISECODERF AND TTL.CUSTOMERCODERF=CUS.CUSTOMERCODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", 0 CUSTOMERCODERF "
                                       + ", '' CUSTOMERSNMRF ";
                        }

                        if (extrInfo_PrevYearComparisonWork.printType == 2)
                        {
                            //担当者コード
                            selectTxt += ", TTL.EMPLOYEECODERF "
                                       + ", EMP.NAMERF ";

                            // 2011/08/01 >>>
                            //joinString += "LEFT JOIN EMPLOYEERF AS EMP ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                            joinString += "LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON TTL.ENTERPRISECODERF=EMP.ENTERPRISECODERF AND TTL.EMPLOYEECODERF=EMP.EMPLOYEECODERF ";
                            // 2011/08/01 <<<
                        }
                        else
                        {
                            selectTxt += ", '0' EMPLOYEECODERF "
                                       + ", '' NAMERF ";

                        }

                        //不要項目
                        selectTxt += ", 0 GOODSLGROUPRF "
                                   + ", '' GOODSLGROUPNAMERF ";
                        selectTxt += ", 0 GOODSMGROUPRF "
                                   + ", '' GOODSMGROUPNAMERF ";
                        selectTxt += ", 0 BLGROUPCODERF "
                                   + ", '' BLGROUPKANANAMERF ";
                        selectTxt += ", 0 SALESAREACODERF "
                                   + ", '' SALESAREANAMERF ";
                        selectTxt += ", 0 BUSINESSTYPECODERF "
                                   + ", '' BUSINESSTYPENAMERF ";
                        break;
                    }
            }

            selectTxt += ",TTL.ADDUPYEARMONTHRF % 100 AS ADDUPYEARMONTHRF" + Environment.NewLine;  //月でグループ化するため

            if (mode == 0)
            {
                //当期
                selectTxt += ", TTL.SALESMONEYRF + TTL.SALESRETGOODSPRICERF + TTL.DISCOUNTPRICERF AS THISTERMSALESRF " + Environment.NewLine;
                selectTxt += ", TTL.GROSSPROFITRF AS THISTERMGROSSRF " + Environment.NewLine;
                selectTxt += ", 0 AS FIRSTTERMSALESRF " + Environment.NewLine;
                selectTxt += ", 0 AS FIRSTTERMGROSSRF " + Environment.NewLine;
            }
            else
            {
                //前期
                selectTxt += ", 0 AS THISTERMSALESRF " + Environment.NewLine;
                selectTxt += ", 0 AS THISTERMGROSSRF " + Environment.NewLine;
                selectTxt += ", TTL.SALESMONEYRF + TTL.SALESRETGOODSPRICERF + TTL.DISCOUNTPRICERF AS FIRSTTERMSALESRF " + Environment.NewLine;
                selectTxt += ", TTL.GROSSPROFITRF AS FIRSTTERMGROSSRF " + Environment.NewLine;
            }

            //帳票タイプにより使用するテーブルが異なります
            //ListType 0:得意先別,1:担当者別,2:受注者別,3:地区別,4:業種別,5:グループコード別,6:BLコード別
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                case 5:
                case 6:
                    {
                        //商品別売上月次集計データ
                        // 2011/08/01 >>>
                        //selectTxt += "FROM GOODSMTTLSASLIPRF TTL " + Environment.NewLine;
                        selectTxt += "FROM GOODSMTTLSASLIPRF TTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                        // 2011/08/01 <<<
                        break;
                    }
                default:
                    {
                        //売上月次集計データ
                        // 2011/08/01 >>>
                        //selectTxt += "FROM MTTLSALESSLIPRF TTL " + Environment.NewLine;
                        selectTxt += "FROM MTTLSALESSLIPRF TTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                        // 2011/08/01 <<<
                        break;
                    }
            }


            return selectTxt;

        }

        /// <summary>
        /// WHERE分作成
        /// </summary>
        /// <param name="extrInfo_PrevYearComparisonWork">抽出条件</param>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <param name="mode">0:当期、1:前期</param>
        /// <returns>SELECT文</returns>
        /// <br>Note       : SELECT文を作成します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.05</br>		
        private string MakeWhereString(ExtrInfo_PrevYearComparisonWork extrInfo_PrevYearComparisonWork, ref SqlCommand sqlCommand, int mode)
        {

            string retString = string.Empty;

            //企業コード
            retString += " WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE" + mode.ToString() + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE" + mode.ToString(), SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.EnterpriseCode);

            //対象年月(前年同範囲も対象とする)
            if (extrInfo_PrevYearComparisonWork.St_AddUpYearMonth > 0 && extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth > 0)
            {
                retString += "AND (TTL.ADDUPYEARMONTHRF>=@ST_THISYEARMONTH" + mode.ToString() + " AND TTL.ADDUPYEARMONTHRF<=@ED_THISYEARMONTH" + mode.ToString() + ")" + Environment.NewLine;
                SqlParameter paraSt_ThisYearMonth = sqlCommand.Parameters.Add("@ST_THISYEARMONTH" + mode.ToString(), SqlDbType.Int);
                SqlParameter paraEd_AddUpYearMonth = sqlCommand.Parameters.Add("@ED_THISYEARMONTH" + mode.ToString(), SqlDbType.Int);

                if (mode == 0)
                {
                    //当期
                    paraSt_ThisYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_AddUpYearMonth);
                    paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth);
                }
                else
                {
                    //前期
                    paraSt_ThisYearMonth.Value = SqlDataMediator.SqlSetInt32(GetAddYearMonth(extrInfo_PrevYearComparisonWork.St_AddUpYearMonth,-12));
                    paraEd_AddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(GetAddYearMonth(extrInfo_PrevYearComparisonWork.Ed_AddUpYearMonth,-12));
                }
            }

            //実績集計区分「0:合計」
            retString += " AND TTL.RSLTTTLDIVCDRF=0 ";

            string secCodeDD = string.Empty;

            //各帳票パターンごとの抽出条件設定と集計処理
            //ListType 0:得意先別,1:担当者別,2:受注者別,3:地区別,4:業種別,5:グループコード別,6:BLコード別
            switch (extrInfo_PrevYearComparisonWork.ListType)
            {
                //得意先別
                case 0:
                    {
                        //従業員区分「10:販売従業員」
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        //管理拠点
                        if ((extrInfo_PrevYearComparisonWork.printType == 3) ||
                            (extrInfo_PrevYearComparisonWork.printType == 4))
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD +" IN (" + sectionString + ") ";
                            }
                            retString += Environment.NewLine;
                        }


                        string cusCodeDD = string.Empty;
                        if (extrInfo_PrevYearComparisonWork.printType == 4)
                        {
                            //請求先
                            cusCodeDD = "CUS.CLAIMCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            cusCodeDD = "TTL.CUSTOMERCODERF" + Environment.NewLine;
                        }


                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND " + cusCodeDD + ">=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND " + cusCodeDD + "<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //担当者別
                case 1:
                    {

                        //従業員区分「10:販売従業員」
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }
                        }

                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //開始担当者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //終了担当者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        break;
                    }
                //受注者別
                case 2:
                    {
                        //従業員区分「20:受付従業員」
                        retString += " AND TTL.EMPLOYEEDIVCDRF=20 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //開始受注者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //終了受注者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        break;
                    }
                //地区別
                case 3:
                    {
                        //従業員区分「10:販売従業員」
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF" + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF" + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }


                        //開始地区コード
                        if (extrInfo_PrevYearComparisonWork.St_SalesAreaCode != 0)
                        {
                            retString += "AND CUS.SALESAREACODERF>=@ST_SALESAREACODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_SalesAreaCode);
                        }
                        //終了地区コード
                        if (extrInfo_PrevYearComparisonWork.Ed_SalesAreaCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_SalesAreaCode != 0)
                            {
                                retString += "AND CUS.SALESAREACODERF<=@ED_SALESAREACODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                //開始コードが０の場合はNULL値も対象とする
                                retString += "AND (CUS.SALESAREACODERF<=@ED_SALESAREACODE" + mode.ToString() + " OR CUS.SALESAREACODERF IS NULL)" + Environment.NewLine;
                            }
                        
                            SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_SalesAreaCode);
                        }

                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //業種別
                case 4:
                    {

                        //従業員区分「10:販売従業員」
                        retString += " AND TTL.EMPLOYEEDIVCDRF=10 " + Environment.NewLine;

                        if (extrInfo_PrevYearComparisonWork.printType == 3)
                        {
                            secCodeDD = "CUS.MNGSECTIONCODERF " + Environment.NewLine;
                        }
                        else
                        {
                            secCodeDD = "TTL.ADDUPSECCODERF " + Environment.NewLine;
                        }

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //開始業種コード
                        if (extrInfo_PrevYearComparisonWork.St_BusinessTypeCode != 0)
                        {
                            retString += "AND CUS.BUSINESSTYPECODERF>=@ST_BUSINESSTYPECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BusinessTypeCode = sqlCommand.Parameters.Add("@ST_BUSINESSTYPECODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BusinessTypeCode);
                        }
                        //終了業種コード
                        if (extrInfo_PrevYearComparisonWork.Ed_BusinessTypeCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_BusinessTypeCode != 0)
                            {
                                retString += "AND CUS.BUSINESSTYPECODERF<=@ED_BUSINESSTYPECODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                //開始コードが０の場合はＮＵＬＬ値も対象
                                retString += "AND (CUS.BUSINESSTYPECODERF<=@ED_BUSINESSTYPECODE" + mode.ToString() + " OR CUS.BUSINESSTYPECODERF IS NULL)" + Environment.NewLine;
                            }
                        
                            SqlParameter paraEd_BusinessTypeCode = sqlCommand.Parameters.Add("@ED_BUSINESSTYPECODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BusinessTypeCode);
                        }

                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        break;
                    }
                //グループコード別
                case 5:
                    {
                        secCodeDD = "TTL.ADDUPSECCODERF";

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //開始商品大分類
                        if (extrInfo_PrevYearComparisonWork.St_GoodsLGroup != 0)
                        {
                            retString += "AND GRP.GOODSLGROUPRF>=@ST_GOODSLGROUP" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_GoodsLGroup = sqlCommand.Parameters.Add("@ST_GOODSLGROUP" + mode.ToString(), SqlDbType.Int);
                            paraSt_GoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_GoodsLGroup);
                        }
                        //終了商品大分類
                        if (extrInfo_PrevYearComparisonWork.Ed_GoodsLGroup != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_GoodsLGroup != 0)
                            {
                                retString += "AND GRP.GOODSLGROUPRF<=@ED_GOODSLGROUP" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (GRP.GOODSLGROUPRF<=@ED_GOODSLGROUP" + mode.ToString() + " OR GRP.GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_GoodsLGroup = sqlCommand.Parameters.Add("@ED_GOODSLGROUP" + mode.ToString(), SqlDbType.Int);
                            paraEd_GoodsLGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_GoodsLGroup);
                        }

                        //開始商品中分類
                        if (extrInfo_PrevYearComparisonWork.St_GoodsMGroup != 0)
                        {
                            retString += "AND GRP.GOODSMGROUPRF>=@ST_GOODSMGROUP" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_GoodsMGroup = sqlCommand.Parameters.Add("@ST_GOODSMGROUP" + mode.ToString(), SqlDbType.Int);
                            paraSt_GoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_GoodsMGroup);
                        }
                        //終了商品中分類
                        if (extrInfo_PrevYearComparisonWork.Ed_GoodsMGroup != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_GoodsMGroup != 0)
                            {
                                retString += "AND GRP.GOODSMGROUPRF<=@ED_GOODSMGROUP" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (GRP.GOODSMGROUPRF<=@ED_GOODSMGROUP" + mode.ToString() + " OR GRP.GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_GoodsMGroup = sqlCommand.Parameters.Add("@ED_GOODSMGROUP" + mode.ToString(), SqlDbType.Int);
                            paraEd_GoodsMGroup.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_GoodsMGroup);
                        }

                        //開始グループコード
                        if (extrInfo_PrevYearComparisonWork.St_BLGroupCode != 0)
                        {
                            retString += "AND BL.BLGROUPCODERF>=@ST_BLGROUPCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BLGroupCode = sqlCommand.Parameters.Add("@ST_BLGROUPCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BLGroupCode);
                        }
                        //終了グループコード
                        if (extrInfo_PrevYearComparisonWork.Ed_BLGroupCode != 0)
                        {
                            if (extrInfo_PrevYearComparisonWork.St_BLGroupCode != 0)
                            {
                                retString += "AND BL.BLGROUPCODERF<=@ED_BLGROUPCODE" + mode.ToString() + Environment.NewLine;
                            }
                            else
                            {
                                retString += "AND (BL.BLGROUPCODERF<=@ED_BLGROUPCODE" + mode.ToString() + " OR BL.BLGROUPCODERF IS NULL)" + Environment.NewLine;
                            }

                            SqlParameter paraEd_BLGroupCode = sqlCommand.Parameters.Add("@ED_BLGROUPCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BLGroupCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BLGroupCode);
                        }

                        break;
                    }
                //BLコード別
                case 6:
                    {
                        secCodeDD = "TTL.ADDUPSECCODERF";

                        if (extrInfo_PrevYearComparisonWork.secCodeList != null)
                        {
                            string sectionString = "";
                            foreach (string sectionCode in extrInfo_PrevYearComparisonWork.secCodeList)
                            {
                                if (sectionCode != "")
                                {
                                    if (sectionString != "") sectionString += ",";
                                    sectionString += "'" + sectionCode + "'";
                                }
                            }
                            if (sectionString != "")
                            {
                                retString += "AND " + secCodeDD + " IN (" + sectionString + ") ";
                            }

                            retString += Environment.NewLine;
                        }

                        //開始得意先コード
                        if (extrInfo_PrevYearComparisonWork.St_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_CustomerCode);
                        }
                        //終了得意先コード
                        if (extrInfo_PrevYearComparisonWork.Ed_CustomerCode != 0)
                        {
                            retString += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_CustomerCode);
                        }

                        //開始担当者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.St_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF>=@ST_EMPLOYEECODE" + Environment.NewLine;
                            SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.St_EmployeeCode);
                        }
                        //終了担当者コード
                        if (string.IsNullOrEmpty(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode) == false)
                        {
                            retString += "AND TTL.EMPLOYEECODERF<=@ED_EMPLOYEECODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE" + mode.ToString(), SqlDbType.NChar);
                            paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PrevYearComparisonWork.Ed_EmployeeCode);
                        }

                        //開始BLコード
                        if (extrInfo_PrevYearComparisonWork.St_BLGoodsCode != 0)
                        {
                            retString += "AND TTL.BLGOODSCODERF>=@ST_BLGOODSCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraSt_BLGoodsCode = sqlCommand.Parameters.Add("@ST_BLGOODSCODE" + mode.ToString(), SqlDbType.Int);
                            paraSt_BLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.St_BLGoodsCode);
                        }
                        //終了BLコード
                        if (extrInfo_PrevYearComparisonWork.Ed_BLGoodsCode != 0)
                        {
                            retString += "AND TTL.BLGOODSCODERF<=@ED_BLGOODSCODE" + mode.ToString() + Environment.NewLine;
                            SqlParameter paraEd_BLGoodsCode = sqlCommand.Parameters.Add("@ED_BLGOODSCODE" + mode.ToString(), SqlDbType.Int);
                            paraEd_BLGoodsCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PrevYearComparisonWork.Ed_BLGoodsCode);
                        }

                        break;
                    }

            }

            return retString;
        }

    }
}
