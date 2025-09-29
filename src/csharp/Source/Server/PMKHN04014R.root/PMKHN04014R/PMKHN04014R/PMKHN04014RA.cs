using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 得意先検索リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先の実データ検索を行うクラスです。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.13</br>
    /// <br></br>
    /// <br>Update Note: 更新日時を戻すように修正</br>
    /// <br>Programmer : 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: 得意先伝票番号区分を戻すように修正</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note: MANTIS:14720 得意先名検索追加</br>
    /// <br>             MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2009/12/02</br>
    /// <br></br>
    /// <br>Update Note: オンライン種別区分 追加</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// <br>Update Note: 簡単問合せアカウントグループID 追加</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/25</br>
    /// <br>Update Note: 電話番号検索追加と伴う修正</br>
    /// <br>Programmer : PM1012A 朱 猛</br>
    /// <br>Date       : 2010/08/06</br>
    /// <br>Update Note: 得意先略称表示列と検索追加(#826)</br>
    /// <br>Programmer : PM1107C 徐錦山</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: PCC自社用得意先ガイド追加(#23705)</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011/08/19</br>
	/// <br></br>
	/// <br>Update Note: 2012.04.10 22024 寺坂　誉志</br>
	/// <br>           : １．顧客担当従業員名称を取得するように修正</br>
    /// <br>Update Note: 2012.04.10 22024 寺坂　誉志</br>
    /// <br>           : １．高速化対応</br>
    /// <br>Update Note: 2012/05/10 30517 夏野 駿希</br>
    /// <br>           : テーブル名の指定不足による不具合修正</br>
    /// <br>Update Note: PM-Tabletの改修</br>
    /// <br>管理番号   :10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: ソースチェック確認事項一覧NO.19の対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/13</br>
    /// <br>Update Note: ソースチェック確認事項一覧NO.28の対応</br>
    /// <br>管理番号   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/17</br>
    /// </remarks>
	[Serializable]
	public class CustomerSearchDB : RemoteDB, ICustomerSearchDB
	{
		#region const

		//得意先抽出項目
        private string selectStringCUSTOMER = "  CUSTOMERRF.LOGICALDELETECODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ENTERPRISECODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSUBCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.NAMERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.NAME2RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.HONORIFICTITLERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.KANARF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSNMRF" + Environment.NewLine +
                                              " ,CUSTOMERRF.SEARCHTELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.HOMETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.OFFICETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.PORTABLETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.POSTNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS1RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS3RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS4RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ACCEPTWHOLESALERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.TOTALDAYRF" + Environment.NewLine +
                                              // --- ADD 2008/09/05 ---------->>>>>
                                              //" ,CUSTOMERRF.MNGSECTIONCODERF" + Environment.NewLine;
                                              " ,CUSTOMERRF.MNGSECTIONCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.UPDATEDATETIMERF" + Environment.NewLine +
                                              // --- ADD 2008/09/05 ----------<<<<<
                                              // ADD 2009.02.10 >>>
                                              " ,CUSTOMERRF.CUSTOMERSLIPNODIVRF" + Environment.NewLine +
                                              // ADD 2009.02.10 <<<
                                              // ADD 2009.06.08 >>>
                                              // UPD 2012/05/10 >>>
                                              //" ,CUSTOMEREPCODERF" + Environment.NewLine +
                                              //" ,CUSTOMERSECCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMEREPCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSECCODERF" + Environment.NewLine +
                                              // UPD 2012/05/10 <<<
                                              // ADD 2009.06.08 <<<
                                              // ADD 2009.06.08 >>>
                                              // 2009/12/02 >>>
                                              //" ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                                              // UPD 2012/05/10 >>>
                                              //" ,CUSTOMERAGENTCDRF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERAGENTCDRF" + Environment.NewLine +
                                              // UPD 2012/05/10 <<<
            ////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
											  " ,EMPLOYEERF.NAMERF CUSTOMERAGENTNM" + Environment.NewLine +
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                                              // 2009/12/02 <<<
                                              // ADD 2009.06.08 <<<
                                              // UPD 2012/05/10 >>>
                                              //" ,ONLINEKINDDIVRF" + Environment.NewLine + // 2010/04/06 Add
                                              //" ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine + // 2010/06/25 Add
                                              " ,CUSTOMERRF.ONLINEKINDDIVRF" + Environment.NewLine + // 2010/04/06 Add
                                              " ,CUSTOMERRF.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine + // 2010/06/25 Add
                                              // UPD 2012/05/10 <<<
                                              // 2009/12/02 Add >>>
                                              ",CUSTOMERRF.HOMEFAXNORF" + Environment.NewLine +
                                              ",CUSTOMERRF.OFFICEFAXNORF" + Environment.NewLine;
                                              // 2009/12/02 Add <<<

        //得意先連結条件
		private const string joinStringCUSTOMER = "LEFT OUTER JOIN CUSTOMERRF ON (CARMAINRF.ENTERPRISECODERF = CUSTOMERRF.ENTERPRISECODERF AND CARMAINRF.CUSTOMERCODERF = CUSTOMERRF.CUSTOMERCODERF) ";
		#endregion

		#region constructor

		/// <summary>
		/// 得意先検索リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public CustomerSearchDB()
		{
		}

		#endregion

		#region Search
		/// <summary>
		/// 指定された条件の得意先LISTを全て戻します
		/// </summary>
		/// <param name="retObj">検索結果</param>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		public int Search(out object retObj, ref object paraObj, CustomerSearchReadMode readMode, ConstantManagement.LogicalMode logicalMode)
		{
			try
			{
				ArrayList retList = null;
				CustomerSearchParaWork customerSearchParaWork = null;
				customerSearchParaWork = (CustomerSearchParaWork)paraObj;

				int status = this.SearchProc(out retList, customerSearchParaWork, readMode, logicalMode);

				retObj = (object)retList;

				return status;
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "CustomerSearchDB.Search");
				retObj = new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}
		#endregion
        // --------------- ADD START 2013/05/29 wangl2 FOR PM-Tablet------>>>>
        #region [SearchForTablet]
        /// <summary>
        /// PMTAB得意先検索結果情報を全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        public int SearchForTablet(out object retObj, ref object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;
            try
            {
                ArrayList retList = null;
                CustomerSearchParaWork customerSearchParaWork = null;
                customerSearchParaWork = (CustomerSearchParaWork)paraObj;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // PMTAB得意先検索
                status = this.SearchForTabletProc(out retList, customerSearchParaWork, ref sqlConnection, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retObj = (object)retList;
                }

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerSearchDB.SearchForTablet");
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

        /// <summary>
        /// PMTAB得意先検索結果情報LISTを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="customerSearchParaWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchForTabletProc(out ArrayList retList, CustomerSearchParaWork customerSearchParaWork, ref SqlConnection sqlConnection,ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;
            ArrayList arrayList = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,NAMERF" + Environment.NewLine;
                sqlText += " ,NAME2RF" + Environment.NewLine;
                sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,KANARF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,POSTNORF" + Environment.NewLine;
                sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,HOMETELNORF" + Environment.NewLine;
                sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,PURECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,NOTE1RF" + Environment.NewLine;
                sqlText += " ,NOTE2RF" + Environment.NewLine;
                sqlText += " ,NOTE3RF" + Environment.NewLine;
                sqlText += " ,NOTE4RF" + Environment.NewLine;
                sqlText += " ,NOTE5RF" + Environment.NewLine;
                sqlText += " ,NOTE6RF" + Environment.NewLine;
                sqlText += " ,NOTE7RF" + Environment.NewLine;
                sqlText += " ,NOTE8RF" + Environment.NewLine;
                sqlText += " ,NOTE9RF" + Environment.NewLine;
                sqlText += " ,NOTE10RF" + Environment.NewLine;
                sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += " CUSTOMERRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                // Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += "WHERE" + Environment.NewLine;
                sqlCommand.CommandText += "ENTERPRISECODERF =@FINDENTERPRISECODE" + Environment.NewLine;
                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.EnterpriseCode);
                //データ読込（論理削除区分指定型）
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += "AND  LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }//データ読込（論理削除範囲指定型）
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //なし
                }
                // カナ
                //if (customerSearchParaWork.Kana != string.Empty)// DEL 2013/06/13 wangl2 FOR ソースチェック確認事項一覧NO.19の対応
                if (!string.IsNullOrEmpty(customerSearchParaWork.Kana))// ADD 2013/06/13 wangl2 FOR ソースチェック確認事項一覧NO.19の対応
                {
                    // --------------- DEL START 2013/06/17 wangl2 FOR ソースチェック確認事項NO.28の対応 ------>>>>
                    //// 得意先カナ検索タイプ(前方一致検索)
                    //if (customerSearchParaWork.KanaSearchType == 0)
                    //{
                    //    sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                    //    SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                    //    findParaKana.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Kana + "%");
                    //}
                    //else 
                    //{
                    //    // 得意先カナ検索タイプ(曖昧検索)
                    //    sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                    //    SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                    //    findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
                    //}
                    // --------------- DEL END 2013/06/17 wangl2 FOR ソースチェック確認事項NO.28の対応 ------<<<<
                    // --------------- ADD START 2013/06/17 wangl2 FOR ソースチェック確認事項NO.28の対応 ------>>>>
                    switch (customerSearchParaWork.KanaSearchType)
                    {
                        case 1:
                            {
                                sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                                SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                                findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
                                break;
                            }
                        case 3:
                            {
                                if (customerSearchParaWork.Kana.Equals("ア"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'ア%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'イ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ウ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'エ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'オ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("カ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'カ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'キ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ク%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ケ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'コ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ガ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ギ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'グ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ゲ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ゴ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'キャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'キュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'キョ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ギャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ギュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ギョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("サ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'サ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'シ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ス%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'セ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ソ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ザ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ジ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ズ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ゼ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ゾ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'シャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'シュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ショ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ジャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ジュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ジョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("タ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'タ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'チ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ツ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'テ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ト%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ダ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヂ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヅ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'デ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ド%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'チャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'チュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'チョ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヂャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヂュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヂョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("ナ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'ナ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ニ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヌ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ネ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ノ%'" + Environment.NewLine;


                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ニャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ニュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ニョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("ハ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'ハ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヒ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'フ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヘ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ホ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'バ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ビ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ブ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ベ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ボ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'パ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ピ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'プ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ペ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ポ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヒャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヒュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヒョ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ビャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ビュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ビョ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ピャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ピュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ピョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("マ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'マ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ミ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ム%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'メ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'モ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ミャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ミュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ミョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("ヤ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'ヤ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ユ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヨ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("ラ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE" + "'ラ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'リ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ル%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'レ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ロ%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'リャ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'リュ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'リョ%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("ワ"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'ワ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ヲ%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'ン%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("他"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF <" + "'ア'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF >" + "'ン'" + ") " + Environment.NewLine;
                                    sqlCommand.CommandText += "AND" + "(" + "NOT KANARF LIKE " + "'ア%'" + ") " + Environment.NewLine;
                                    sqlCommand.CommandText += "AND" + "(" + "NOT KANARF LIKE " + "'ン%'" + ") " + Environment.NewLine;
                                }

                            }
                            break;
                    }
                    // --------------- ADD END 2013/06/17 wangl2 FOR ソースチェック確認事項NO.28の対応 ------<<<<
 
                }
                // 得意先コード
                if (customerSearchParaWork.CustomerCode != 0)
                {
                    sqlCommand.CommandText += "AND  CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    // Parameterオブジェクトの作成
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustomerCode);
                }
                // 管理拠点
                //if (customerSearchParaWork.MngSectionCode != string.Empty)// DEL 2013/06/13 wangl2 FOR ソースチェック確認事項一覧NO.19の対応
                if (!string.IsNullOrEmpty(customerSearchParaWork.MngSectionCode))// ADD 2013/06/13 wangl2 FOR ソースチェック確認事項一覧NO.19の対応
                {
                    sqlCommand.CommandText += " AND MNGSECTIONCODERF=@FINDMNGSECTIONCODE" + Environment.NewLine;
                    // Parameterオブジェクトの作成
                    SqlParameter findParaMngSectionCode = sqlCommand.Parameters.Add("@FINDMNGSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaMngSectionCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.MngSectionCode);
                }
                # endregion


                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    CustomerWork customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    arrayList.Add(customerWork);
                }
                retList = arrayList;
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// DEL 2013/06/13 wangl2 FOR ソースチェック確認事項一覧NO.19の対応
                // --------------- ADD START 2013/06/13 wangl2 FOR ソースチェック確認事項NO.19の対応 ------>>>>
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --------------- ADD END 2013/06/13 wangl2 FOR ソースチェック確認事項NO.19の対応 ------<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "PMTAB得意先検索結果情報のデータの取得に失敗しました。", ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;

        }
        #endregion
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<

        /// <summary>
		/// 指定された抽出条件の得意先LISTを全て戻します
		/// </summary>
		/// <param name="retList">検索結果</param>
		/// <param name="customerSearchParaWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		private int SearchProc(out ArrayList retList, CustomerSearchParaWork customerSearchParaWork, CustomerSearchReadMode readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			SqlDataReader myReader = null;

			string selectString = "";
			string joinString = "";
			string whereStringADD = "";

			retList = new ArrayList();
			ArrayList al = new ArrayList();
			try
			{
				selectString = selectStringCUSTOMER;
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
				joinString = "LEFT JOIN EMPLOYEERF ON (EMPLOYEERF.ENTERPRISECODERF = CUSTOMERRF.ENTERPRISECODERF AND EMPLOYEERF.EMPLOYEECODERF = CUSTOMERRF.CUSTOMERAGENTCDRF) ";
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL文生成
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;

				//データ読込（論理削除区分指定型）
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData1) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT "
												+ selectString
												+ "FROM CUSTOMERRF "
												+ joinString
												+ "WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE "
												+ whereStringADD, sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				//データ読込（論理削除範囲指定型）
				else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT "
						+ selectString
						+ "FROM CUSTOMERRF "
						+ joinString
						+ "WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE "
						+ whereStringADD, sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT"
						+ selectString
						+ "FROM CUSTOMERRF "
						+ joinString
						+ "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.EnterpriseCode);
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                //得意先企業コード,得意先拠点コード
                if (customerSearchParaWork.PccuoeMode != 0)
                {
                    sqlCommand.CommandText += " AND CUSTOMEREPCODERF IS NOT NULL ";
                    sqlCommand.CommandText += " AND CUSTOMERSECCODERF IS NOT NULL ";
                    //オンライン種別区分＝10:SCM
                    sqlCommand.CommandText += " AND ONLINEKINDDIVRF = 10 ";
                }
                //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
				
				//検索条件文作成
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand, readMode, customerSearchParaWork);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					//Readerからクラスを生成
					CustomerSearchRetWork wkCustomerSearchRetWork = this.MakeCustomerSearchRetWork(myReader);
                    //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                    if (customerSearchParaWork.PccuoeMode != 0)
                    {
                        if (String.IsNullOrEmpty(wkCustomerSearchRetWork.CustomerEpCode.TrimEnd())
                            || String.IsNullOrEmpty(wkCustomerSearchRetWork.CustomerSecCode.TrimEnd()))
                        {
                            continue;
                        }
                    }
                    //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
					
					//ArrayListへ追加
					al.Add(wkCustomerSearchRetWork);
				}

				sqlCommand.Cancel();
				if (!myReader.IsClosed) myReader.Close();

				//戻り値有りなら正常Statusをセット
				if (al.Count > 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex)
			{
				base.WriteSQLErrorLog(ex);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if (myReader != null && myReader.IsClosed == false)
				{
					myReader.Close();
                    myReader.Dispose();
				}

				if (sqlConnection != null)
				{
					sqlConnection.Close();
                    sqlConnection.Dispose();
				}
			}

			retList = al;

			return status;
		}

		#region 顧客検索結果格納
		/// <summary>
		/// 顧客検索結果格納
		/// </summary>
		/// <param name="myReader">DB読込結果</param>
		/// <returns>顧客検索結果</returns>
		private CustomerSearchRetWork MakeCustomerSearchRetWork(SqlDataReader myReader)
		{
			CustomerSearchRetWork wkCustomerSearchWork = new CustomerSearchRetWork();

			wkCustomerSearchWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
			wkCustomerSearchWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
			wkCustomerSearchWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
			wkCustomerSearchWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
			wkCustomerSearchWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
			wkCustomerSearchWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
			wkCustomerSearchWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            wkCustomerSearchWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustomerSearchWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
			wkCustomerSearchWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
			wkCustomerSearchWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
			wkCustomerSearchWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
			wkCustomerSearchWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
			wkCustomerSearchWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
			wkCustomerSearchWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
			wkCustomerSearchWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
			wkCustomerSearchWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
			wkCustomerSearchWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
			wkCustomerSearchWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
            wkCustomerSearchWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            // --- ADD 2008/09/05 ---------->>>>>
            wkCustomerSearchWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            wkCustomerSearchWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
            // ADD 2009.02.10 <<< 
            // ADD 2009.06.09 >>>
            wkCustomerSearchWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
            wkCustomerSearchWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
            // ADD 2009.06.09 <<< 
            // ADD 2009.06.16 >>>
            wkCustomerSearchWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            // ADD 2009.06.16 <<< 
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			wkCustomerSearchWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // 2009/12/02 Add >>>
            wkCustomerSearchWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            wkCustomerSearchWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            // 2009/12/02 Add <<<
            wkCustomerSearchWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));    // 2010/04/06 Add
            wkCustomerSearchWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));    // 2010/06/25 Add
            return wkCustomerSearchWork;
		}
		#endregion

		#region MakeWhereString
		/// <summary>
		/// 検索条件文字列生成＋条件値設定
		/// </summary>
		/// <param name="sqlCommand">SqlCommandオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="customerSearchParaWork">検索条件格納クラス</param>
		/// <returns>Where条件文字列</returns>
        /// <br>Update Note: 得意先略称表示列と検索追加(#826)</br>
        /// <br>Programmer : PM1107C 徐錦山</br>
        /// <br>Date       : 2011/07/22</br>
		private string MakeWhereString(ref SqlCommand sqlCommand, CustomerSearchReadMode readMode, CustomerSearchParaWork customerSearchParaWork)
		{
			//戻り値文字列格納用コレクション
			ArrayList ret = new ArrayList();

			//最大条件数分ループ（条件数が増えたらループ数も増やすこと）
            // 2009/12/02 >>>
            //for (int i = 0; i < 14; i++)
            // ---UPD 2010/08/06-------------------->>>
            //for (int i = 0; i < 15; i++)
            // 2011/7/22 XUJS EDIT STA>>>>>>
            //for (int i = 0; i < 16; i++)
            for (int i = 0; i < 17; i++)
            // 2011/7/22 XUJS EDIT END<<<<<<
            // ---UPD 2010/08/06--------------------<<<
            // 2009/12/02 <<<
            {
				int readModeWork = 0;
				// 条件生成
				if (readMode == CustomerSearchReadMode.CustomerSearchMode_All)
				{
					switch (i)
					{
						//得意先条件チェック
						case 0: // 得意先コードが0なら次の条件へ
						{
							if (customerSearchParaWork.CustomerCode == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Code;
							break;
						}
						case 1: // 得意先サブコードが空もしくはnullなら次の条件へ
						{
							if ((customerSearchParaWork.CustomerSubCode == "") || (customerSearchParaWork.CustomerSubCode == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SubCode;
							break;
						}
						case 2: // 得意先電話番号検索
						{
							if ((customerSearchParaWork.SearchTelNo == "") || (customerSearchParaWork.SearchTelNo == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Tel;
							break;
						}
						case 3: // 得意先カナ検索
						{
							if ((customerSearchParaWork.Kana == "") || (customerSearchParaWork.Kana == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Kana;
							break;
						}
						case 4: // 得意先区分検索
						{
							readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerDiv;

							//if (customerSearchParaWork.SupplierDiv == 0) continue;
							//else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SupplierDiv;
							break;
						}
						case 5: // 業販先区分検索
						{
							//if (customerSearchParaWork.AcceptWholeSale == 0) continue;
							//else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_AcceptWholeSale;
							break;
						}
						case 6: // 分析コード1検索
						{
							if (customerSearchParaWork.CustAnalysCode1 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode1;
							break;
						}
						case 7: // 分析コード2検索
						{
							if (customerSearchParaWork.CustAnalysCode2 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode2;
							break;
						}
						case 8: // 分析コード3検索
						{
							if (customerSearchParaWork.CustAnalysCode3 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode3;
							break;
						}
						case 9: // 分析コード4検索
						{
							if (customerSearchParaWork.CustAnalysCode4 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode4;
							break;
						}
						case 10: // 分析コード5検索
						{
							if (customerSearchParaWork.CustAnalysCode5 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode5;
							break;
						}
						case 11: // 分析コード6検索
						{
							if (customerSearchParaWork.CustAnalysCode6 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode6;
							break;
						}
						case 12: // 得意先担当者コード検索
						{
							if (customerSearchParaWork.CustomerAgentCd == "") continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerAgentCd;
							break;
						}
                        case 13: // 管理拠点コード検索
                        {
                            if (customerSearchParaWork.MngSectionCode == "") continue;
                            else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_MngSecCode;
                            break;
                        }
                        // 2009/12/02 Add >>>
                        case 14: // 得意先名検索
                        {
                            if ((customerSearchParaWork.Name == "") || (customerSearchParaWork.Name == null)) continue;
                            else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Name;
                            break;
                        }
                        // 2009/12/02 Add <<<
                        // ---ADD 2010/08/06-------------------->>>
                        case 15: // 電話番号検索
                            {
                                if ((customerSearchParaWork.TelNum == "") || (customerSearchParaWork.TelNum == null)) continue;
                                else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_TelNum;
                                break;
                            }
                        // ---ADD 2010/08/06--------------------<<<
                        // 2011/7/22 XUJS ADD STA>>>>>>
                        case 16: // 得意先略称検索
                            {
                                if ((customerSearchParaWork.CustomerSnm == "") || (customerSearchParaWork.CustomerSnm == null)) continue;
                                else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerSnm;
                                break;
                            }
                        // 2011/7/22 XUJS ADD END<<<<<<
                        default:
						{
							continue;
						}
					}
				}
				//複合条件では無い場合は一件のみの条件設定
				else
				{
					readModeWork = (int)readMode;
				}

				// 検索条件文字列の作成
				switch (readModeWork)
				{
					// 得意先マスタ条件
					// 得意先コード検索
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Code:
					{
						ret.Add("CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE");
						SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
						findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustomerCode);
						break;
					}
					// 得意先サブコード
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SubCode:
					{
						// 得意先サブコード検索タイプが0の場合
						if (customerSearchParaWork.CustomerSubCodeSearchType == 0)
						{
							// 前方一致検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            ret.Add("CUSTOMERRF.CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaCustomerSubCode = sqlCommand.Parameters.Add("@FINDCUSTOMERSUBCODE", SqlDbType.NVarChar);
							findParaCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerSubCode + "%");
						}
						// 0以外の場合
						else
						{
							// あいまい検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            ret.Add("CUSTOMERRF.CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaCustomerSubCode = sqlCommand.Parameters.Add("@FINDCUSTOMERSUBCODE", SqlDbType.NVarChar);
							findParaCustomerSubCode.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.CustomerSubCode + "%");
						}
						break;
					}
					// 得意先電話番号検索
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Tel:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("SEARCHTELNORF=@FINDSEARCHTELNO");
                        ret.Add("CUSTOMERRF.SEARCHTELNORF=@FINDSEARCHTELNO");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaSearchTelNo = sqlCommand.Parameters.Add("@FINDSEARCHTELNO", SqlDbType.NChar);
						findParaSearchTelNo.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.SearchTelNo);
						break;
					}
					// 得意先カナ検索
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Kana:
					{
						// カナ検索タイプが0の場合
						if (customerSearchParaWork.KanaSearchType == 0)
						{
							// 前方一致検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("KANARF LIKE @FINDKANA");
                            ret.Add("CUSTOMERRF.KANARF LIKE @FINDKANA");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
							findParaKana.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Kana + "%");
						}
						// 0以外の場合
						else
						{
							// あいまい検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("KANARF LIKE @FINDKANA");
                            ret.Add("CUSTOMERRF.KANARF LIKE @FINDKANA");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
							findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
						}
						break;
					}
					// 得意先区分
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerDiv:
                        {
                            // 業販先区分 -1:全て 0:業販先以外 1:業販先 2:納入先
                            if (customerSearchParaWork.AcceptWholeSale > -1)
                            {
                                // UPD 2012/05/10 >>>
                                //ret.Add("ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE" + Environment.NewLine);
                                ret.Add("CUSTOMERRF.ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE" + Environment.NewLine);
                                // UPD 2012/05/10 <<<
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.AcceptWholeSale);
                            }

                            # region [DELETE 2008.05.08]
                            /*
                            // 得意先＋仕入先 の絞込み
                            if (customerSearchParaWork.SupplierDiv == 1 && customerSearchParaWork.AcceptWholeSale == 1)
                            {
                                wrkWhere = "(SUPPLIERDIVRF IN (@FINDSUPPLIERDIV1, @FINDSUPPLIERDIV2) AND ACCEPTWHOLESALERF IN (@FINDACCEPTWHOLESALE1, @FINDACCEPTWHOLESALE2))" + Environment.NewLine;

                                sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                sqlCommand.Parameters.Add("@FINDSUPPLIERDIV2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                            }
                            else
                            {
                                // 得意先 及び 両方(得意先＋仕入先) の絞込み
                                if ((customerSearchParaWork.AcceptWholeSale == 1) ||
                                    (customerSearchParaWork.AcceptWholeSale == 0 && customerSearchParaWork.SupplierDiv == -1))
                                {
                                    wrkWhere = "(SUPPLIERDIVRF IN (@FINDSUPPLIERDIV1, @FINDSUPPLIERDIV2) AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE1)" + Environment.NewLine;

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                }

                                // 仕入先 及び 両方(得意先＋仕入先) の絞込み
                                if ((customerSearchParaWork.SupplierDiv == 1) ||
                                    (customerSearchParaWork.SupplierDiv == 0 && customerSearchParaWork.AcceptWholeSale == -1))
                                {
                                    wrkWhere = "(SUPPLIERDIVRF = @FINDSUPPLIERDIV1 AND ACCEPTWHOLESALERF IN (@FINDACCEPTWHOLESALE1, @FINDACCEPTWHOLESALE2))" + Environment.NewLine;

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                }

                                // 納入先 の絞込み
                                if (customerSearchParaWork.SupplierDiv == -1 || customerSearchParaWork.AcceptWholeSale == -1)
                                {
                                    if (string.IsNullOrEmpty(wrkWhere))
                                    {
                                        wrkWhere += "SUPPLIERDIVRF = @FINDSUPPLIERDIV3 AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE3";
                                    }
                                    else
                                    {
                                        wrkWhere += "OR (SUPPLIERDIVRF = @FINDSUPPLIERDIV3 AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE3)";
                                    }

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV3", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE3", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(2);
                                }
                            }

                            if (!string.IsNullOrEmpty(wrkWhere))
                            {
                                ret.Add(wrkWhere);
                            }
                            */
                            # endregion

                            break;
					}
					// 仕入先区分
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SupplierDiv:
					{
                        //--- DEL 2008.05.08 --->>>
                        //ret.Add("SUPPLIERDIVRF=@FINDSUPPLIERDIV");
                        //SqlParameter findParaSupplierDiv = sqlCommand.Parameters.Add("@FINDSUPPLIERDIV", SqlDbType.Int);
                        //findParaSupplierDiv.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.SupplierDiv);
						//--- DEL 2008.05.08 ---<<<
                        break;
					}
					// 業販先区分
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_AcceptWholeSale:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("ACCEPTWHOLESALERF=@FINDACCEPTWHOLESALE");
                        ret.Add("CUSTOMERRF.ACCEPTWHOLESALERF=@FINDACCEPTWHOLESALE");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaAcceptWholeSale = sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE", SqlDbType.Int);
						findParaAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.AcceptWholeSale);
						break;
					}
					// 分析コード1
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode1:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE1RF=@FINDCUSTANALYSCODE1");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE1RF=@FINDCUSTANALYSCODE1");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode1 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE1", SqlDbType.Int);
						findParaCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode1);
						break;
					}
					// 分析コード2
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode2:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE2RF=@FINDCUSTANALYSCODE2");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE2RF=@FINDCUSTANALYSCODE2");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode2 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE2", SqlDbType.Int);
						findParaCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode2);
						break;
					}
					// 分析コード3
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode3:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE3RF=@FINDCUSTANALYSCODE3");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE3RF=@FINDCUSTANALYSCODE3");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode3 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE3", SqlDbType.Int);
						findParaCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode3);
						break;
					}
					// 分析コード4
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode4:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE4RF=@FINDCUSTANALYSCODE4");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE4RF=@FINDCUSTANALYSCODE4");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode4 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE4", SqlDbType.Int);
						findParaCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode4);
						break;
					}
					// 分析コード5
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode5:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE5RF=@FINDCUSTANALYSCODE5");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE5RF=@FINDCUSTANALYSCODE5");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode5 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE5", SqlDbType.Int);
						findParaCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode5);
						break;
					}
					// 分析コード6
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode6:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE6RF=@FINDCUSTANALYSCODE6");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE6RF=@FINDCUSTANALYSCODE6");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode6 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE6", SqlDbType.Int);
						findParaCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode6);
						break;
					}
					// 得意先従業員コード
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerAgentCd:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTOMERAGENTCDRF=@FINDCUSTOMERAGENTCD");
                        ret.Add("CUSTOMERRF.CUSTOMERAGENTCDRF=@FINDCUSTOMERAGENTCD");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);
						findParaCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerAgentCd);
						break;
					}
                    // 管理拠点コード
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_MngSecCode:
                    {
                        // UPD 2012/05/10 >>>
                        //ret.Add("MNGSECTIONCODERF=@FINDMNGSECTIONCODE");
                        ret.Add("CUSTOMERRF.MNGSECTIONCODERF=@FINDMNGSECTIONCODE");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaMngSectionCode = sqlCommand.Parameters.Add("@FINDMNGSECTIONCODE", SqlDbType.NChar);
                        findParaMngSectionCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.MngSectionCode);
                        break;
                    }
					default:
					{
						break;
					}
                    // 2009/12/02 Add >>>
                    // 得意先名検索
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Name:
                    {
                        // 得意先名検索タイプが0の場合
                        if (customerSearchParaWork.NameSearchType == 0)
                        {
                            // 前方一致検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("NAMERF LIKE @FINDNAME");
                            ret.Add("CUSTOMERRF.NAMERF LIKE @FINDNAME");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDNAME", SqlDbType.NVarChar);
                            findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Name + "%");
                        }
                        // 0以外の場合
                        else
                        {
                            // あいまい検索
                            // UPD 2012/05/10 >>>
                            //ret.Add("NAMERF LIKE @FINDNAME");
                            ret.Add("CUSTOMERRF.NAMERF LIKE @FINDNAME");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDNAME", SqlDbType.NVarChar);
                            findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Name + "%");
                        }
                        break;
                    }
                    // 2009/12/02 Add <<<
                    // ---ADD 2010/08/06-------------------->>>
                    // 電話番号検索
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_TelNum:
                        {
                            // 電話番号検索タイプが0の場合
                            if (customerSearchParaWork.TelNumSearchType == 0)
                            {
                                // 前方一致検索

                                // UPD 2012/05/10 >>>
                                //ret.Add("REPLACE(OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                ret.Add("REPLACE(CUSTOMERRF.OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDTELNUM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.TelNum.Replace("-", "") + "%");
                            }
                            // 0以外の場合
                            else
                            {
                                // あいまい検索
                                // UPD 2012/05/10 >>>
                                //ret.Add("REPLACE(OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                ret.Add("REPLACE(CUSTOMERRF.OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDTELNUM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.TelNum.Replace("-", "") + "%");
                            }
                            break;
                        }
                    // ---ADD 2010/08/06--------------------<<<

                    // 2011/7/22 XUJS ADD STA>>>>>>
                    // 得意先略称検索
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerSnm:
                        {
                            // 得意先略称検索タイプが0の場合
                            if (customerSearchParaWork.CustomerSnmSearchType == 0)
                            {
                                // 前方一致検索
                                // UPD 2012/05/10 >>>
                                //ret.Add("CUSTOMERSNMRF LIKE @FINDSNM");
                                ret.Add("CUSTOMERRF.CUSTOMERSNMRF LIKE @FINDSNM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDSNM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerSnm + "%");
                            }
                            // 0以外の場合
                            else
                            {
                                // あいまい検索
                                // UPD 2012/05/10 >>>
                                //ret.Add("CUSTOMERSNMRF LIKE @FINDSNM");
                                ret.Add("CUSTOMERRF.CUSTOMERSNMRF LIKE @FINDSNM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDSNM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.CustomerSnm + "%");
                            }
                            break;
                        }
                    // 2011/7/22 XUJS ADD END<<<<<<
				}

				//複合条件指定では無い場合はループ終了
				if (readMode != CustomerSearchReadMode.CustomerSearchMode_All) break;

			}//for end

			//戻り値文字列生成(開始サイズをとりあえず1024で初期化)
            StringBuilder retString = new StringBuilder(1024);
            for (int ii = 0; ii < ret.Count; ii++)
			{
				retString.Append(" AND ");
				retString.Append(ret[ii]);
			}

			return retString.ToString();
		}

		#endregion
        // --------------- ADD START 2013.05.29 wangl2 FOR PM-Tablet------>>>>
        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
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

        /// <summary>
        /// 得意先マスタの読込結果(SqlDataReader)を得意先マスタワーク(CustomerWork)に格納します。
        /// </summary>
        /// <param name="myReader">得意先マスタの読込結果</param>
        /// <param name="customerWork">得意先マスタワーク</param>
        private void ReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [格納処理]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));
                # endregion
            }
        }
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<
	}

	#region 顧客検索結果Conpareクラス CustomerSearchRetCompare
	/// <summary>
	/// 顧客検索結果Compareクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 顧客検索結果の得意先コードが同じかどうかを比較するクラスです</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
	/// </remarks>
	internal class CustomerSearchRetCompare : IComparer
	{
		#region IComparer メンバ

		/// <summary>
		/// 顧客検索結果Compareメソッド
		/// </summary>
		/// <param name="x">CustomerSearchRetWorkオブジェクト</param>
		/// <param name="y">CustomerSearchRetWorkオブジェクト</param>
		/// <returns>比較結果</returns>
		/// <remarks>
		/// <br>Note       : 顧客検索結果の得意先コードが同じかどうかを比較します</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public int Compare(object x, object y)
		{
			CustomerSearchRetWork customerSearchRetWork1 = (CustomerSearchRetWork)x;
			CustomerSearchRetWork customerSearchRetWork2 = (CustomerSearchRetWork)y;
			int no = customerSearchRetWork1.CustomerCode - customerSearchRetWork2.CustomerCode;
			return no;
		}

		#endregion

	}
	#endregion
}
