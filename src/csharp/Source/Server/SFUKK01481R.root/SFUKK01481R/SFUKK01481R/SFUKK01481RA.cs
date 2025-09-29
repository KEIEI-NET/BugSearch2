//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :													//
// Program name     :   入金引当操作リモーティング						//
//                  :   SFUKK01481R.DLL									//
// Name Space       :   Broadleaf.SFLibrary.Windows.Forms				//
// Programer        :   徳永　誠										//
// Date             :   2005.08.19										//
// Note				:	引当削除は入金・入金引当MTのみ更新し、請求売上・//
//					:	受注MTの更新は行わない（ｴﾝﾄﾘで更新する）		//
//----------------------------------------------------------------------//
// Update Note      :	2006.02.27 徳永　誠								//
//					:	諸費用別入金対応								//
// Update Note      :	2006.03.07 徳永　誠								//
//					:	赤伝作成時の赤引当作成処理対応					//
//					:	2006.10.18 徳永　誠								//
//					:	トランザクション分離レベルを変更				//
//                  :   2007.01.31 18322 T.Kimura MA.NS用に変更         //
//--------------------------------------------------------------------- //
//                  :   2008.03.07 980081 山田 明友 流通基幹対応        //
//--------------------------------------------------------------------- //
//                  :   2008.04.25 21112  PM.NS用に変更                 //
//----------------------------------------------------------------------//
// Update Note 　　 : 　K2014/05/28 zhujw　　　　　　　　　　　　　 　　//
// 管理番号    　　 : 　11001635-00 ㈱カト―個別対応                    //
//----------------------------------------------------------------------//
// Update Note 　　 : 　K2014/06/19 zhujw　　　　　　　　　　　　　 　　//
// 管理番号    　　 : 　11001635-00 RedMine#42902                       //
//                  :   既存のデータパラメータを使用する                //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd					//
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

using System.Collections.Generic; //  ADD zhujw K2014/05/28 ㈱カト―個別対応
using System.Text;//  ADD zhujw K2014/05/28 ㈱カト―個別対応

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金引当操作処理リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 指定得意先・受注番号の入金引当データの削除処理操作を行うクラスです。</br>
	/// <br>Programmer : 95089 徳永　誠</br>
	/// <br>Date       : 2005.08.9</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS用に変更</br>
	/// </remarks>
	[Serializable]
	public class ControlDepsitAlwDB : RemoteDB, IControlDepsitAlwDB
	{
		/// <summary>
		/// 入金更新DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
		public ControlDepsitAlwDB() :
			base( "SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork", "DEPOSITALWRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("ControlDepsitAlwDBコンストラクタ");
		}

        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 ------->>>>> 
        #region Search
        /// <summary>
        /// 指定された企業コードの売上引当入金データテキストの全て戻る処理（論理削除除く）
        /// </summary>
        /// <param name="controlKaToDepsitAlwResultWork">検索結果</param>
        /// <param name="controlKaToDepsitAlwCndtnWork">検索パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの売上引当入金データLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        public int Search(out object controlKaToDepsitAlwResultWork, object controlKaToDepsitAlwCndtnWork)
        {
            SqlConnection sqlConnection = null;
            controlKaToDepsitAlwResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out controlKaToDepsitAlwResultWork, controlKaToDepsitAlwCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ControlKaToDepsitAlwDB.Search");
                controlKaToDepsitAlwResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された企業コードの売上引当入金データテキストを全て戻る処理
        /// </summary>
        /// <param name="controlKaToDepsitAlwResultWork">検索結果</param>
        /// <param name="controlKaToDepsitAlwCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        private int SearchProc(out object controlKaToDepsitAlwResultWork, object controlKaToDepsitAlwCndtnWork, ref SqlConnection sqlConnection)
        {
            //ControlKaToDepsitAlwCndtnWork cndtnWork = controlKaToDepsitAlwCndtnWork as ControlKaToDepsitAlwCndtnWork;// DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する

            DepositAlwWork cndtnWork = controlKaToDepsitAlwCndtnWork as DepositAlwWork;// ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            controlKaToDepsitAlwResultWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ").Append(Environment.NewLine);
                sb.Append(" MIN(C.DEPOSITROWNORF) AS DEPOSITROWNORF,").Append(Environment.NewLine);                 // 入金明細データ.行番号
                sb.Append(" A.SALESSLIPNUMRF,").Append(Environment.NewLine);                                        // 入金引当マスタ.売上伝票番号
                sb.Append(" A.RECONCILEDATERF,").Append(Environment.NewLine);                                       // 入金引当マスタ.消込み日
                sb.Append(" B.CREATEDATETIMERF AS BUPDATEDATETIMERF,").Append(Environment.NewLine);                 // 入金マスタ.作成日時
                sb.Append(" B.FEEDEPOSITRF AS FEEDEPOSITRF,").Append(Environment.NewLine);                          // 入金マスタ.手数料入金額
                sb.Append(" B.DISCOUNTDEPOSITRF AS DISCOUNTDEPOSITRF,").Append(Environment.NewLine);                // 入金マスタ.値引入金額
                sb.Append(" A.DEPOSITAGENTNMRF,").Append(Environment.NewLine);                                      // 入金引当マスタ.入金担当者名称
                sb.Append(" C.UPDATEDATETIMERF AS CUPDATEDATETIMERF,").Append(Environment.NewLine);                 // 入金明細データ.更新日時
                sb.Append(" D.MONEYKINDNAMERF").Append(Environment.NewLine);                                        // 金額種別マスタ（ユーザー登録）.金種名称
                // 入金引当マスタ
                sb.Append(" FROM DEPOSITALWRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                // 入金マスタ
                sb.Append(" LEFT JOIN DEPSITMAINRF  B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND B.ACPTANODRSTATUSRF = 30").Append(Environment.NewLine);
                sb.Append(" AND A.DEPOSITSLIPNORF = B.DEPOSITSLIPNORF").Append(Environment.NewLine);
                sb.Append(" AND B.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                // 入金明細データ
                sb.Append(" LEFT JOIN DEPSITDTLRF C WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON B.ENTERPRISECODERF = C.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND C.ACPTANODRSTATUSRF = 30").Append(Environment.NewLine);
                sb.Append(" AND C.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sb.Append(" AND B.DEPOSITSLIPNORF = C.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                // 金額種別マスタ（ユーザー登録）
                sb.Append(" LEFT JOIN MONEYKINDURF D WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON C.ENTERPRISECODERF = D.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND D.PRICESTCODERF = 0").Append(Environment.NewLine);
                sb.Append(" AND C.MONEYKINDCODERF = D.MONEYKINDCODERF").Append(Environment.NewLine);
                //検索条件
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));
                sb.Append(" GROUP BY  A.SALESSLIPNUMRF,A.RECONCILEDATERF, B.CREATEDATETIMERF, B.FEEDEPOSITRF, B.DISCOUNTDEPOSITRF, A.DEPOSITAGENTNMRF, C.UPDATEDATETIMERF, D.MONEYKINDNAMERF").Append(Environment.NewLine);
                //ソート
                sb.Append(" ORDER BY SALESSLIPNUMRF,DEPOSITROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();
                //Dictionary<string, ControlKaToDepsitAlwWork> newData = new Dictionary<string, ControlKaToDepsitAlwWork>(); // DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
                Dictionary<string, DepositAlwWork> newData = new Dictionary<string, DepositAlwWork>(); // ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する

                while (myReader.Read())
                {
                    string moneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));                // 金種名称
                    #region 抽出結果-値セット
                    // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>> 
                    DepositAlwWork controlKaToDepsitAlwWork = new DepositAlwWork();

                    //データ結果取得内容格納
                    controlKaToDepsitAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                  // 売上伝票番号
                    controlKaToDepsitAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));              // 入金担当者名称
                    controlKaToDepsitAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));  // 引当日
                    controlKaToDepsitAlwWork.CustomerName = moneyKindName;                                                                                 // 得意先名->金種名称
                    controlKaToDepsitAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF")); // 入金作成日時
                    controlKaToDepsitAlwWork.CreateDateTime = DateTime.Now;
                    controlKaToDepsitAlwWork.AcptAnOdrStatus = 0;
                    controlKaToDepsitAlwWork.AddUpSecCode = string.Empty;
                    controlKaToDepsitAlwWork.CustomerName2 = string.Empty;
                    controlKaToDepsitAlwWork.DebitNoteOffSetCd = 0;
                    controlKaToDepsitAlwWork.DepositAgentCode = string.Empty;
                    controlKaToDepsitAlwWork.DepositAllowance = 0;
                    controlKaToDepsitAlwWork.DepositSlipNo = 0;
                    controlKaToDepsitAlwWork.EnterpriseCode = string.Empty;
                    controlKaToDepsitAlwWork.FileHeaderGuid = Guid.NewGuid();
                    controlKaToDepsitAlwWork.InputDepositSecCd = string.Empty;
                    controlKaToDepsitAlwWork.LogicalDeleteCode = 0;
                    controlKaToDepsitAlwWork.ReconcileAddUpDate = DateTime.Now;
                    controlKaToDepsitAlwWork.UpdAssemblyId1 = string.Empty;
                    controlKaToDepsitAlwWork.UpdAssemblyId2 = string.Empty;
                    controlKaToDepsitAlwWork.UpdEmployeeCode = string.Empty;

                    if (newData.ContainsKey(controlKaToDepsitAlwWork.SalesSlipNum))
                    {
                        string dataKey = controlKaToDepsitAlwWork.SalesSlipNum;
                        if (controlKaToDepsitAlwWork.UpdateDateTime > newData[dataKey].UpdateDateTime)
                        {
                            newData[dataKey].SalesSlipNum = controlKaToDepsitAlwWork.SalesSlipNum;// 売上伝票番号
                            newData[dataKey].DepositAgentNm = controlKaToDepsitAlwWork.DepositAgentNm;// 入金担当者名称
                            newData[dataKey].CustomerName = controlKaToDepsitAlwWork.CustomerName;// 得意先名->金種名称
                            newData[dataKey].ReconcileDate = controlKaToDepsitAlwWork.ReconcileDate;// 引当日
                            newData[dataKey].UpdateDateTime = controlKaToDepsitAlwWork.UpdateDateTime;// 入金作成日時
                            newData[dataKey].CreateDateTime = DateTime.Now;
                            newData[dataKey].AcptAnOdrStatus = 0;
                            newData[dataKey].AddUpSecCode = string.Empty;
                            newData[dataKey].CustomerName2 = string.Empty;
                            newData[dataKey].DebitNoteOffSetCd = 0;
                            newData[dataKey].DepositAgentCode = string.Empty;
                            newData[dataKey].DepositAllowance = 0;
                            newData[dataKey].DepositSlipNo = 0;
                            newData[dataKey].EnterpriseCode = string.Empty;
                            newData[dataKey].FileHeaderGuid = Guid.NewGuid();
                            newData[dataKey].InputDepositSecCd = string.Empty;
                            newData[dataKey].LogicalDeleteCode = 0;
                            newData[dataKey].ReconcileAddUpDate = DateTime.Now;
                            newData[dataKey].UpdAssemblyId1 = string.Empty;
                            newData[dataKey].UpdAssemblyId2 = string.Empty;
                            newData[dataKey].UpdEmployeeCode = string.Empty;
                        }
                    }
                    else
                    {
                            newData.Add(controlKaToDepsitAlwWork.SalesSlipNum, controlKaToDepsitAlwWork);
                    }
                    // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

                    // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>> 
                    //ControlKaToDepsitAlwWork controlKaToDepsitAlwWork = new ControlKaToDepsitAlwWork();

                    //データ結果取得内容格納
                    //controlKaToDepsitAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                  // 売上伝票番号
                    //controlKaToDepsitAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));              // 入金担当者名称
                    //controlKaToDepsitAlwWork.ReconcileDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEDATERF"));                 // 引当日
                    //controlKaToDepsitAlwWork.MoneyKindName = moneyKindName;                                                                                 // 金種名称
                    //controlKaToDepsitAlwWork.UpdateDateTime1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF")); // 入金更新日時
                    //controlKaToDepsitAlwWork.UpdateDateTime2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CUPDATEDATETIMERF")); // 入金明細更新日時
                    //controlKaToDepsitAlwWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));                       // 手数料入金額
                    //controlKaToDepsitAlwWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));             // 値引入金額

                    //if (newData.ContainsKey(controlKaToDepsitAlwWork.SalesSlipNum))
                    //{
                    //    string dataKey = controlKaToDepsitAlwWork.SalesSlipNum;
                    //    if (controlKaToDepsitAlwWork.UpdateDateTime1 > newData[dataKey].UpdateDateTime1)
                    //    {
                    //        newData[dataKey].DiscountDeposit = controlKaToDepsitAlwWork.DiscountDeposit;
                    //        newData[dataKey].DepositAgentNm = controlKaToDepsitAlwWork.DepositAgentNm;
                    //        newData[dataKey].FeeDeposit = controlKaToDepsitAlwWork.FeeDeposit;
                    //        newData[dataKey].MoneyKindName = controlKaToDepsitAlwWork.MoneyKindName;
                    //        newData[dataKey].ReconcileDate = controlKaToDepsitAlwWork.ReconcileDate;
                    //        newData[dataKey].SalesSlipNum = controlKaToDepsitAlwWork.SalesSlipNum;
                    //        newData[dataKey].UpdateDateTime1 = controlKaToDepsitAlwWork.UpdateDateTime1;
                    //        newData[dataKey].UpdateDateTime2 = controlKaToDepsitAlwWork.UpdateDateTime2;
                    //    }
                    //}
                    //else
                    //{
                    //        newData.Add(controlKaToDepsitAlwWork.SalesSlipNum, controlKaToDepsitAlwWork);
                    //}
                    // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
                //foreach (ControlKaToDepsitAlwWork work in newData.Values)
                //{
                //    al.Add(work);
                //}
                // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

                // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
                foreach (DepositAlwWork work in newData.Values)
                {
                    al.Add(work);
                }
                // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ControlKaToDepsitAlwDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
            }

            controlKaToDepsitAlwResultWork = al;

            return status;
        }
        #endregion

        #region MakeWhereString
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        //private string MakeWhereString(ref SqlCommand sqlCommand, ControlKaToDepsitAlwCndtnWork cndtnWork) // DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
        private string MakeWhereString(ref SqlCommand sqlCommand, DepositAlwWork cndtnWork) // ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する
        {
            #region WHERE文作成
            string[] salesSlipNum = cndtnWork.SalesSlipNum.Split(';');// ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する 
            
            StringBuilder retstring = new StringBuilder(" WHERE ");

            //入金引当マスタ.企業コード
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            //入金引当マスタ.赤伝相殺区分
            retstring.Append(" AND A.DEBITNOTEOFFSETCDRF = 0").Append(Environment.NewLine);

            //入金引当マスタ.論理削除区分
            retstring.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF").Append(Environment.NewLine);
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //入金引当マスタ.得意先コード
            retstring.Append(" AND A.CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.CustomerCode);

            //入金引当マスタ.受注ステータス
            retstring.Append(" AND A.ACPTANODRSTATUSRF=30 ").Append(Environment.NewLine);

            // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
            ////入金引当マスタ.売上伝票番号
            //if (!string.IsNullOrEmpty(cndtnWork.SalesSlipNumSt))
            //{
            //    retstring.Append(" AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST").Append(Environment.NewLine);
            //    SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.Int);
            //    paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNumSt);
            //}

            ////入金引当マスタ.売上伝票番号
            //if (!string.IsNullOrEmpty(cndtnWork.SalesSlipNumEd))
            //{
            //    retstring.Append(" AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED").Append(Environment.NewLine);
            //    SqlParameter paraSalesSlipNumEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.Int);
            //    paraSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNumEd);
            //}
            // --- DEL zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<

            // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する ------->>>>>
            //入金引当マスタ.売上伝票番号
            if (!string.IsNullOrEmpty(salesSlipNum[0]))
            {
                retstring.Append(" AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST").Append(Environment.NewLine);
                SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salesSlipNum[0]);
            }

            //入金引当マスタ.売上伝票番号
            if (!string.IsNullOrEmpty(salesSlipNum[1]))
            {
                retstring.Append(" AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED").Append(Environment.NewLine);
                SqlParameter paraSalesSlipNumEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(salesSlipNum[1]);
            }
            // --- ADD zhujw K2014/06/19 RedMine#42902 既存のデータパラメータを使用する -------<<<<<
            #endregion
            return retstring.ToString();
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
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
        #endregion  //コネクション生成処理
        // --- ADD zhujw K2014/05/28 ㈱カト―個別対応 -------<<<<<

		/// <summary>
		/// 入金引当削除
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTを削除し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int DeleteDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo)
        public int DeleteDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			try 
			{	
			　　//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB接続・トランザクション開始
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// 入金引当削除処理
                // ↓ 2008.03.07 980081 c
                //status = DeleteDepositAllowanceMain(EnterpriseCode, CustomerCode, AcceptAnOrderNo, ref sqlConnection, ref sqlTransaction);
                status = DeleteDepositAllowanceMain(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, ref sqlConnection, ref sqlTransaction);
                // ↑ 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
		}

		/// <summary>
		/// 入金引当情報取得
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAlwWorkListByte">入金引当情報配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTを取得し返します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out byte[] depositAlwWorkListByte)
        public int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out byte[] depositAlwWorkListByte)
        // ↑ 2008.03.07 980081 c
		{
			DepositAlwWork[] depositAlwWorkList = null;

            // ↓ 2008.03.07 980081 c
            //int status = ReadDB(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList);
            int status = ReadDB(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList);
            // ↑ 2008.03.07 980081 c

			// XMLへ変換し、文字列のバイナリ化
			depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			return status;
		}


		/// <summary>
		/// 入金引当情報取得
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード(請求先コード)</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAlwWorkList">入金引当情報配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTを取得し返します</br>
		/// <br>           : リモートアクセス以外で、直接参照呼出しする場合はこちらを使用する事</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out DepositAlwWork[] depositAlwWorkList)
        public int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out DepositAlwWork[] depositAlwWorkList)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;


			depositAlwWorkList = null;

			try 
			{	
			　　//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB接続・トランザクション開始
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// 入金引当取得処理
                // ↓ 2008.03.07 980081 c
                //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
                status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
                // ↑ 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
		}


		/// <summary>
		/// 入金引当存在チェック処理(受注伝票更新時用)
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="BfCustomerCodeList">更新前得意先コード配列</param>
		/// <param name="AfCustomerCodeList">更新後得意先コード配列</param>
		/// <param name="NgCustomerCodeList">引当がある得意先コード配列</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 受注番号と更新前請求先、更新後請求先を指定することで入金引当されている得意先コードを配列で返します/br>
		///	               : 受注伝票更新時にチェックして、引当がある請求先がある場合チェックエラーとします</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.09.01</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int CheckDepositAllowance(string EnterpriseCode, int AcceptAnOrderNo, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList)
        public int CheckDepositAllowance(string EnterpriseCode, int AcptAnOdrStatus, string SalesSlipNum, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			NgCustomerCodeList = null;

			try 
			{	
			　　//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB接続・トランザクション開始
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// 入金引当チェック処理
                // ↓ 2008.03.07 980081 c
                //status = CheckDepositAllowance(EnterpriseCode, AcceptAnOrderNo, BfCustomerCodeList, AfCustomerCodeList, out NgCustomerCodeList, ref sqlConnection, ref sqlTransaction);
                status = CheckDepositAllowance(EnterpriseCode, AcptAnOdrStatus, SalesSlipNum, BfCustomerCodeList, AfCustomerCodeList, out NgCustomerCodeList, ref sqlConnection, ref sqlTransaction);
                // ↑ 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}


			return status;
		}


		/// <summary>
		/// 入金引当チェック処理
		/// </summary>
		/// <param name="mode">赤黒入金引当取得区分 0:カウントする 1:カウントしない</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="count">入金引当数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当数を取得し返します</br>
		///	<br>           : modeに1を指定することで、赤入金・相殺済み黒入金への引当数を未カウントにすることができます</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count)
        public int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			count = 0;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
		
			try 
			{	
			　　//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB接続・トランザクション開始
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// 入金引当数取得処理
                // ↓ 2008.03.07 980081 c
                //status = GetCountDepositAlwWorkRec(mode, EnterpriseCode, CustomerCode, AcceptAnOrderNo, out count, ref sqlConnection, ref sqlTransaction);
                status = GetCountDepositAlwWorkRec(mode, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
                // ↑ 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
		}

		/// <summary>
		/// 入金引当存在チェック処理(受注伝票更新時用)
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="BfCustomerCodeList">更新前得意先コード配列</param>
		/// <param name="AfCustomerCodeList">更新後得意先コード配列</param>
		/// <param name="NgCustomerCodeList">引当がある得意先コード配列</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 受注番号と更新前請求先、更新後請求先を指定することで入金引当されている得意先コードを配列で返します/br>
		///	               : 受注伝票更新時にチェックして、引当がある請求先がある場合チェックエラーとします</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.09.01</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int CheckDepositAllowance(string EnterpriseCode, int AcceptAnOrderNo, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int CheckDepositAllowance(string EnterpriseCode, int AcptAnOdrStatus, string SalesSlipNum, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int count = 0;
			ArrayList CustomerCodeList = new ArrayList();
			ArrayList NgCustomerCodeArrayList = new ArrayList();

			bool hitflg;


			// 更新前＞更新後に削除される得意先を確定
			for(int ix=0; ix < BfCustomerCodeList.Length; ix++)
			{
				hitflg = false;

				// 更新後得意先がある場合(伝票削除・赤伝発行時以外)
				if(AfCustomerCodeList != null && AfCustomerCodeList.Length != 0)
				{
					// 更新後得意先が存在するかチェック
					for(int iy = 0; iy < AfCustomerCodeList.Length; iy++)
					{
						if (BfCustomerCodeList[ix] ==  AfCustomerCodeList[iy])
						{
							hitflg = true;
						}
					}
				}

				// 請求先が削除される場合、チェック対象とする
				if(hitflg == false && BfCustomerCodeList[ix] != 0)
				{
					CustomerCodeList.Add(BfCustomerCodeList[ix]);
				}
			}
	

			try 
			{	

				foreach(int CustomerCode in CustomerCodeList)
				{
					// 入金引当数取得処理(赤・相殺済み黒は無視)
                    // ↓ 2008.03.07 980081 c
                    //status = GetCountDepositAlwWorkRec(1, EnterpriseCode, CustomerCode, AcceptAnOrderNo, out count, ref sqlConnection, ref sqlTransaction);
                    status = GetCountDepositAlwWorkRec(1, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
                    // ↑ 2008.03.07 980081 c

					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

					// 引当がある場合、RETURN値に得意先コードを追加する
					if (count > 0)
					{
						NgCustomerCodeArrayList.Add(CustomerCode);
					}
				
				}

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			NgCustomerCodeList = (int[])NgCustomerCodeArrayList.ToArray(typeof(int));

			return status;
		}


		/// <summary>
		/// 入金引当削除処理メイン
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns></returns>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTを削除し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int DeleteDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int DeleteDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2008.03.07 980081 c
		{
			//			DepsitMainWork depsitMainWork = null;
			DepositAlwWork[] depositAlwWorkList = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// 入金引当マスタ読込み
            // ↓ 2008.03.07 980081 c
            //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            // ↑ 2008.03.07 980081 c

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{

				// 入金引当情報更新
				for(int ix=0; ix < depositAlwWorkList.Length; ix++)
				{
					DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[ix];

					// 入金マスタの引当額更新(引当マスタ額を減算更新)
					status = UpdateDepsitMainRec(ref depositAlwWork,  ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

					// 引当マスタ削除
					status = DeleteDepositAlwWorkRec(depositAlwWork, ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

				}

			}

			return status;
		}

		/// <summary>
		/// 入金引当マスタ情報を取得します
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード(請求先コード)</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAlwWorkList">入金引当情報</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタ情報を得意先コード・受注番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br> 
		/// <br>Date       : 2005.08.18</br>
        /// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS用に変更</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int ReadDepositAlwWorkRec(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int ReadDepositAlwWorkRec(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			ArrayList depositAlwWorkArrayList = new ArrayList();

			try 
			{
                // ↓ 20070131 18322 c MA.NS用に変更
                #region SF 入金引当マスタ SELECT文
                ////Selectコマンドの生成
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
				//		  +",ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "			// 20060227 Ins
				//		  +"FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO", sqlConnection, sqlTransaction))
                #endregion

                #region MA.NS 入金引当マスタ検索 SELECT文
                // ↓ 2008.03.07 980081 d
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 +       ",UPDATEDATETIMERF"
                //                 +       ",ENTERPRISECODERF"
                //                 +       ",FILEHEADERGUIDRF"
                //                 +       ",UPDEMPLOYEECODERF"
                //                 +       ",UPDASSEMBLYID1RF"
                //                 +       ",UPDASSEMBLYID2RF"
                //                 +       ",LOGICALDELETECODERF"
                //                 +       ",INPUTDEPOSITSECCDRF"
                //                 +       ",ADDUPSECCODERF"
                //                 +       ",RECONCILEDATERF"
                //                 +       ",RECONCILEADDUPDATERF"
                //                 +       ",DEPOSITSLIPNORF"
                //                 +       ",DEPOSITKINDCODERF"
                //                 +       ",DEPOSITKINDNAMERF"
                //                 +       ",DEPOSITALLOWANCERF"
                //                 +       ",DEPOSITAGENTCODERF"
                //                 +       ",DEPOSITAGENTNMRF"
                //                 +       ",CUSTOMERCODERF"
                //                 +       ",CUSTOMERNAMERF"
                //                 +       ",CUSTOMERNAME2RF"
                //                 +       ",ACCEPTANORDERNORF"
                //                 +       ",SERVICESLIPCDRF"
                //                 +       ",DEBITNOTEOFFSETCDRF"
                //                 +       ",DEPOSITCDRF"
                //                 +       ",CREDITORLOANCDRF"
                //                 +  " FROM DEPOSITALWRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                //                 +   " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                //                 ;
                // ↑ 2008.03.07 980081 d
                #endregion
                // ↓ 2008.03.07 980081 a
                string selectSql = "SELECT * FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                                 ;
                // ↑ 2008.03.07 980081 a

                using(SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // ↑ 20070131 18322 c
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode		= sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo	= sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus    = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum       = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2008.03.07 980081 c
					SqlParameter findParaCustomerCode		= sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value	= SqlDataMediator.SqlSetString(EnterpriseCode);
                    // ↓ 2008.03.07 980081 c
					//findParaAcceptAnOrderNo.Value	= SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value   = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findParaSalesSlipNum.Value      = SqlDataMediator.SqlSetString(SalesSlipNum);
                    // ↑ 2008.03.07 980081 c
					findParaCustomerCode.Value	  	= SqlDataMediator.SqlSetInt32(CustomerCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						DepositAlwWork depositAlwWork = new DepositAlwWork();

						#region クラスへ代入
                        // ↓ 20070131 18322 c MA.NS用に変更
                        #region SF 入金引当マスタワーク←SELECTデータ（全てコメントアウト）
						//depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						//depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						//depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						//depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						//depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						//depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						//depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						//depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						//depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
						//depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
						//depositAlwWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
						//depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
						//depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
						//depositAlwWork.DepositInputDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITINPUTDATERF"));
						//depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
						//depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEDATERF"));
						//depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEADDUPDATERF"));
						//depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
						//depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
						//depositAlwWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
						//// 20060227 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
						//depositAlwWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
						//depositAlwWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
						//// 20060227 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion

                        # region --- DEL 2008/04/25 M.Kubota ---
                        # if false
                        // 作成日時
                        depositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        // 更新日時
                        depositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // 企業コード
                        depositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // 更新従業員コード
                        depositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // 更新アセンブリID1
                        depositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // 更新アセンブリID2
                        depositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // 論理削除区分
                        depositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // 入金入力拠点コード
                        depositAlwWork.InputDepositSecCd  = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // 計上拠点コード
                        depositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // 消込み日
                        depositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        // 消込み計上日
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        // 入金伝票番号
                        depositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // 入金金種コード
                        depositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // 入金金種名称
                        depositAlwWork.DepositKindName    = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // 入金引当額
                        depositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64 ( myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // 入金担当者コード
                        depositAlwWork.DepositAgentCode   = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // 入金担当者名称
                        depositAlwWork.DepositAgentNm     = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // 得意先コード
                        depositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // 得意先名称
                        depositAlwWork.CustomerName       = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // 得意先名称2
                        depositAlwWork.CustomerName2      = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // ↓ 2008.03.07 980081 d
                        //// 受注番号
                        //depositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// サービス伝票区分
                        //depositAlwWork.ServiceSlipCd      = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // ↑ 2008.03.07 980081 d
                        // 赤伝相殺区分
                        depositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        // 預り金区分
                        depositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // ↓ 2008.03.07 980081 d
                        //// クレジット／ローン区分
                        //depositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        // ↑ 2008.03.07 980081 d
                        // ↑ 20070131 18322 c
                        // ↓ 2008.03.07 980081 a
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        // ↑ 2008.03.07 980081 a
                        # endif
                        # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion

                        depositAlwWorkArrayList.Add(depositAlwWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();
	

			depositAlwWorkList =  (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));

			return status;
		}

        /// <summary>
        /// 入金引当が存在するかチェックします
        /// </summary>
        /// <param name="mode">赤黒入金引当取得区分 0:カウントする 1:カウントしない</param>
        /// <param name="EnterpriseCode">企業コード</param>
        /// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="count">入金引当数</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 入金引当情報数を得意先コード・受注番号を元にデータ取得を行います</br>
        /// <br>Programmer : 95089 徳永　誠</br>
        /// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        public int GetCountDepositAlwWorkRec(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.GetCountDepositAlwWorkRecProc(mode, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
        }

		/// <summary>
		/// 入金引当が存在するかチェックします
		/// </summary>
		/// <param name="mode">赤黒入金引当取得区分 0:カウントする 1:カウントしない</param>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="count">入金引当数</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金引当情報数を得意先コード・受注番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //public int GetCountDepositAlwWorkRec(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int GetCountDepositAlwWorkRecProc(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			count = 0;
	
			SqlDataReader myReader = null;

			ArrayList depositAlwWorkArrayList = new ArrayList();

			try 
			{
                // ↓ 2008.03.07 980081 c
                //string selectText = "SELECT COUNT(*) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO";
                //string selectText = "SELECT COUNT(*) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";  //DEL 2008/04/25 M.Kubota
                string selectText = "SELECT COUNT(DEPOSITALWRF.ENTERPRISECODERF) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";  //ADD 2008/04/25 M.Kubota
                // ↑ 2008.03.07 980081 c

				if (mode != 0)
				{
					// 赤伝への引当、相殺済み黒への引当を未カウントとする
					selectText += " AND DEBITNOTEOFFSETCDRF=0";
				}

				//Selectコマンドの生成
				using(SqlCommand sqlCommand = new SqlCommand(selectText, sqlConnection, sqlTransaction))
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode		= sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo	= sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus    = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum       = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2008.03.07 980081 c
					SqlParameter findParaCustomerCode		= sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value	= SqlDataMediator.SqlSetString(EnterpriseCode);
					// ↓ 2008.03.07 980081 c
                    //findParaAcceptAnOrderNo.Value	= SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(SalesSlipNum);
                    // ↑ 2008.03.07 980081 c
					findParaCustomerCode.Value		= SqlDataMediator.SqlSetInt32(CustomerCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						count =SqlDataMediator.SqlGetInt32(myReader, 0);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}

		/// <summary>
		/// 入金マスタ情報を取得します
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="DepositSlipNo">入金番号</param>
		/// <param name="depsitMainWork">入金情報</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金マスタ情報を入金番号を元にデータ取得を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		private int ReadDepsitMainWorkRec(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			depsitMainWork = new DepsitMainWork();

			try 
			{
			    // ↓ 20070131 18322 c MA.NS用に変更
                #region SF 入金マスタ SELECT文
				////Selectコマンドの生成
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF "
				//		  +", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF " // 諸費用別入金項目の追加 20060227 Ins
				//		  +"FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                // ↓ 2008.03.07 980081 c
                #region 入金マスタ SELECT文(コメントアウト)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 +       ",UPDATEDATETIMERF"
                //                 +       ",ENTERPRISECODERF"
                //                 +       ",FILEHEADERGUIDRF"
                //                 +       ",UPDEMPLOYEECODERF"
                //                 +       ",UPDASSEMBLYID1RF"
                //                 +       ",UPDASSEMBLYID2RF"
                //                 +       ",LOGICALDELETECODERF"
                //                 +       ",DEPOSITDEBITNOTECDRF"
                //                 +       ",DEPOSITSLIPNORF"
                //                 +       ",ACCEPTANORDERNORF"
                //                 +       ",SERVICESLIPCDRF"
                //                 +       ",INPUTDEPOSITSECCDRF"
                //                 +       ",ADDUPSECCODERF"
                //                 +       ",UPDATESECCDRF"
                //                 +       ",DEPOSITDATERF"
                //                 +       ",ADDUPADATERF"
                //                 +       ",DEPOSITKINDCODERF"
                //                 +       ",DEPOSITKINDNAMERF"
                //                 +       ",DEPOSITKINDDIVCDRF"
                //                 +       ",DEPOSITTOTALRF"
                //                 +       ",DEPOSITRF"
                //                 +       ",FEEDEPOSITRF"
                //                 +       ",DISCOUNTDEPOSITRF"
                //                 +       ",REBATEDEPOSITRF"
                //                 +       ",AUTODEPOSITCDRF"
                //                 +       ",DEPOSITCDRF"
                //                 +       ",CREDITORLOANCDRF"
                //                 +       ",CREDITCOMPANYCODERF"
                //                 +       ",DRAFTDRAWINGDATERF"
                //                 +       ",DRAFTPAYTIMELIMITRF"
                //                 +       ",DEPOSITALLOWANCERF"
                //                 +       ",DEPOSITALWCBLNCERF"
                //                 +       ",DEBITNOTELINKDEPONORF"
                //                 +       ",LASTRECONCILEADDUPDTRF"
                //                 +       ",DEPOSITAGENTCODERF"
                //                 +       ",DEPOSITAGENTNMRF"
                //                 +       ",CUSTOMERCODERF"
                //                 +       ",CUSTOMERNAMERF"
                //                 +       ",CUSTOMERNAME2RF"
                //                 +       ",OUTLINERF"
                //                 +   "FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                string selectSql = "SELECT * FROM DEPSITMAINRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                 ;
                // ↑ 2008.03.07 980081 c

                using(SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // ↑ 20070131 18322 c
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						#region クラスへ代入(コメントアウト)
                        # region --- DEL 2008/04/25 M.Kubota ---
                        # if false
                        // ↓ 20070131 18322 c MA.NS用に変更
                        #region SF 入金マスタワーク←SELECTデータ（全てコメントアウト）
						//depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
						//depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
						//depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
						//depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
						//depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
						//depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
						//depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
						//depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
						//depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
						//depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
						//depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
						//depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
						//depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
						//depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITTOTALRF"));
						//depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OUTLINERF"));
						//depsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESNORF"));
						//depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
						//depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITDATERF"));
						//depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
						//depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
						//depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
						//depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITKINDNAMERF"));
						//depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
						//depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
						//depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITAGENTCODERF"));
						//depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
						//depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("FEEDEPOSITRF"));
						//depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
						//depsitMainWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
						//depsitMainWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
						//depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITRF"));
						//depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
						//depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
						//depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
						//depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
						//depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
						//// 20060227 Ins Start >>>>>>>>>
						//depsitMainWork.AcpOdrDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITRF"));
						//depsitMainWork.AcpOdrChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRCHARGEDEPOSITRF"));
						//depsitMainWork.AcpOdrDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDISDEPOSITRF"));
						//depsitMainWork.VariousCostDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARIOUSCOSTDEPOSITRF"));
						//depsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTCHARGEDEPOSITRF"));
						//depsitMainWork.VarCostDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDISDEPOSITRF"));
						//depsitMainWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
						//depsitMainWork.AcpOdrDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOALWCBLNCERF"));
						//depsitMainWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
						//depsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCBLNCERF"));
						//// 20060227 Ins End <<<<<<<<<<<
                        #endregion

                        //// 作成日時
                        //depsitMainWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //// 更新日時
                        //depsitMainWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //// 企業コード
                        //depsitMainWork.EnterpriseCode        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //// GUID
                        //depsitMainWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //// 更新従業員コード
                        //depsitMainWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //// 更新アセンブリID1
                        //depsitMainWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //// 更新アセンブリID2
                        //depsitMainWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //// 論理削除区分
                        //depsitMainWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //// 入金赤黒区分
                        //depsitMainWork.DepositDebitNoteCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        //// 入金伝票番号
                        //depsitMainWork.DepositSlipNo         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //// 受注番号
                        //depsitMainWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// サービス伝票区分
                        //depsitMainWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
                        //// 入金入力拠点コード
                        //depsitMainWork.InputDepositSecCd     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        //// 計上拠点コード
                        //depsitMainWork.AddUpSecCode          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        //// 更新拠点コード
                        //depsitMainWork.UpdateSecCd           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        //// 入金日付
                        //depsitMainWork.DepositDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        //// 計上日付
                        //depsitMainWork.AddUpADate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        //// 入金金種コード
                        //depsitMainWork.DepositKindCode       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //// 入金金種名称
                        //depsitMainWork.DepositKindName       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        //// 入金金種区分
                        //depsitMainWork.DepositKindDivCd      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        //// 入金計
                        //depsitMainWork.DepositTotal          = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        //// 入金金額
                        //depsitMainWork.Deposit               = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        //// 手数料入金額
                        //depsitMainWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        //// 値引入金額
                        //depsitMainWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        //// リベート入金額
                        //depsitMainWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEDEPOSITRF"));
                        //// 自動入金区分
                        //depsitMainWork.AutoDepositCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        //// 預り金区分
                        //depsitMainWork.DepositCd             = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        //// クレジット／ローン区分
                        //depsitMainWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// クレジット会社コード
                        //depsitMainWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //// 手形振出日
                        //depsitMainWork.DraftDrawingDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //// 手形支払期日
                        //depsitMainWork.DraftPayTimeLimit     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //// 入金引当額
                        //depsitMainWork.DepositAllowance      = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //// 入金引当残高
                        //depsitMainWork.DepositAlwcBlnce      = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        //// 赤黒入金連結番号
                        //depsitMainWork.DebitNoteLinkDepoNo   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        //// 最終消し込み計上日
                        //depsitMainWork.LastReconcileAddUpDt  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        //// 入金担当者コード
                        //depsitMainWork.DepositAgentCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        //// 入金担当者名称
                        //depsitMainWork.DepositAgentNm        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        //// 得意先コード
                        //depsitMainWork.CustomerCode          = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        //// 得意先名称
                        //depsitMainWork.CustomerName          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        //// 得意先名称2
                        //depsitMainWork.CustomerName2         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        //// 伝票摘要
                        //depsitMainWork.Outline               = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        //// ↑ 20070131 18322 c
                        
                        // ↓ 2008.03.07 980081 a
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        depsitMainWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        depsitMainWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // ↑ 2008.03.07 980081 a
                        # endif
                        # endregion

                        //--- DEL 2008/04/25 M.Kubota --->>>
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));                 // 作成日時
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));                 // 更新日時
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                            // 企業コード
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                              // GUID
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                          // 更新従業員コード
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                            // 更新アセンブリID1
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                            // 更新アセンブリID2
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                       // 論理削除区分
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                           // 受注ステータス
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));                     // 入金赤黒区分
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));                               // 入金伝票番号
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                                // 売上伝票番号
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                      // 入金入力拠点コード
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));                                // 計上拠点コード
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));                                  // 更新拠点コード
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                             // 部門コード
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));                    // 入金日付
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));                      // 計上日付
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));                                 // 入金計
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));                                           // 入金金額
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));                                     // 手数料入金額
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));                           // 値引入金額
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));                               // 自動入金区分
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));          // 手形振出日
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));                                       // 手形種類
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));                              // 手形種類名称
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));                                   // 手形区分
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));                          // 手形区分名称
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));                                          // 手形番号
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));                         // 入金引当額
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));                         // 入金引当残高
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));                   // 赤黒入金連結番号
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));  // 最終消し込み計上日
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));                        // 入金担当者コード
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));                            // 入金担当者名称
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));                  // 入金入力者コード
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));                  // 入金入力者名称
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                                 // 得意先コード
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));                                // 得意先名称
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));                              // 得意先名称2
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));                                  // 得意先略称
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));                                       // 請求先コード
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));                                      // 請求先名称
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));                                    // 請求先名称2
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));                                        // 請求先略称
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));                                          // 伝票摘要
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));                                         // 銀行コード
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));                                        // 銀行名称
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        # endregion
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();
	
			return status;
		}

		/// <summary>
		/// 入金引当マスタ情報を削除します
		/// </summary>
		/// <param name="depositAlwWork">入金引当情報</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタ情報の削除を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private int DeleteDepositAlwWorkRec(DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			//Selectコマンドの生成
			try			
			{
                // ↓ 2008.03.07 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("DELETE DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND RECONCILEADDUPDATERF=@FINDRECONCILEADDUPDATE", sqlConnection, sqlTransaction))
                using (SqlCommand sqlCommand = new SqlCommand("DELETE DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND RECONCILEADDUPDATERF=@FINDRECONCILEADDUPDATE", sqlConnection, sqlTransaction))
                // ↑ 2008.03.07 980081 c
				{

					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2008.03.07 980081 c
					SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
					SqlParameter findParaReconcileAddUpDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					// ↓ 2008.03.07 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2008.03.07 980081 c
					findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
					findParaReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);

					int count = sqlCommand.ExecuteNonQuery();

					// 更新件数が無い場合はすでに削除されている意味で排他を戻す
					if(count == 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
					}
					else
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}

				}

			}
			catch (SqlException ex) 
			{
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}

		/// <summary>
		/// 入金マスタ情報の引当額を減算・更新します
		/// </summary>
		/// <param name="depositAlwWork">減算する入金引当情報</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 引数で渡された入金引当情報に該当する入金マスタに対して引当額を減算して更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private int UpdateDepsitMainRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			// Updateコマンドの生成
			try			
			{
                // ↓ 20070131 18322 c MA.NS用に変更
                #region SF引当額の差額更新と売上受注番号の消去（全てコメントアウト）
                //// ※引当額の差額更新と売上受注番号の消去を行う(預り金・自動入金の引当時は受注番号が入っている為)
				//string updateText = "UPDATE DEPSITMAINRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2,  ACCEPTANORDERSALESNORF=0, DEPOSITALLOWANCERF=DEPOSITALLOWANCERF - @DF_DEPOSITALLOWANCE, DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF + @DF_DEPOSITALLOWANCE "
				//	+",ACPODRDEPOSITALWCRF=ACPODRDEPOSITALWCRF - @DF_ACPODRDEPOSITALWC, ACPODRDEPOALWCBLNCERF=ACPODRDEPOALWCBLNCERF + @DF_ACPODRDEPOSITALWC "	// 20060227 Ins 受注引当
				//	+",VARCOSTDEPOALWCRF=VARCOSTDEPOALWCRF - @DF_VARCOSTDEPOALWC, VARCOSTDEPOALWCBLNCERF=VARCOSTDEPOALWCBLNCERF + @DF_VARCOSTDEPOALWC "			// 20060227 Ins 諸費用引当
				//	+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                #endregion

                // ※ 引当額の差額更新
                string updateText = "UPDATE DEPSITMAINRF"
                                  +   " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                                  +       ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                                  +       ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                                  +       ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                                  +       ",DEPOSITALLOWANCERF=DEPOSITALLOWANCERF - @DF_DEPOSITALLOWANCE"
                                  +       ",DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF + @DF_DEPOSITALLOWANCE"
                                  + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                  +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                  ; 
                // ↑ 20070131 18322 c
				using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
				{
					//Prameterオブジェクトの作成
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

					//Parameterオブジェクトへ値設定
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);

					#region Parameterオブジェクトの作成(更新用)
					//Parameterオブジェクトの作成(更新用)
					SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME",			SqlDbType.BigInt);	// 更新日
					SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE",			SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1",			SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2",			SqlDbType.NVarChar);

					SqlParameter paraDF_DepositAllowance	= sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCE",		SqlDbType.BigInt);	// 引当差額
                    // ↓ 20070131 18322 c MA.NS用に変更
					//// 20020627 Ins Start >> 諸費用別入金対応>>>>>>>>>>>>
					//SqlParameter paraDF_AcpOdrDepositAlwc	= sqlCommand.Parameters.Add("@DF_ACPODRDEPOSITALWC",	SqlDbType.BigInt);	// 受注引当差額
					//SqlParameter paraDF_VarCostDepoAlwc		= sqlCommand.Parameters.Add("@DF_VARCOSTDEPOALWC",		SqlDbType.BigInt);	// 諸費用引当差額
					//// 20020627 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //　↑20070131 18322 c

					#endregion

					#region Parameterオブジェクトへ値設定(更新用)

					// ■更新ヘッダ情報を設定 
					object obj = (object)this;
					FileHeader fileHeader = new FileHeader(obj);
					paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());			// 更新日
					paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);								// 更新従業員コード
					paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);								// 更新アセンブリID1
					paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));						// 更新アセンブリID2

					// ■変更情報を設定 
					// 引当差額
					paraDF_DepositAllowance.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);	// 引当差額

                    // ↓ 20070131 18322 c MA.NS用に変更
					//// 20020620 Ins Start >> 諸費用別入金対応>>>>>>>>>>>>
					//paraDF_AcpOdrDepositAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);// 受注引当差額
					//paraDF_VarCostDepoAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);	// 諸費用引当差額
					///// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ↑20070131 18322 c
					#endregion

					int count = sqlCommand.ExecuteNonQuery();

					// 更新件数が無い場合はすでに削除されている意味で排他を戻す
					if(count == 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

					}
					else
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}

				}
			
			}	
			catch (SqlException ex) 
			{
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}


		/// <summary>
		/// 売赤伝作成時入金引当赤作成処理
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
		/// <param name="depositAgentNm">入金担当者名</param>
		/// <param name="akaAddUpADate">赤伝計上日</param>
        /// <param name="NewSalesSlipNum">赤伝売上伝票番号</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTから赤受注に対する赤引当作成し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
		// ↓ 20070131 18322 c MA.NS用に変更
        ////public int CreateRedDepositAllowance(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo)
		//public int CreateRedDepositAllowance( string   EnterpriseCode
        //                                    , int      CustomerCode
        //                                    , int      AcceptAnOrderNo
        //                                    , string   depositAgentCode
        //                                    , string   depositAgentNm
        //                                    , DateTime akaAddUpADate
        //                                    , int      NewAcceptAnOrderNo)
        //// ↑ 20070131 18322 c
		public int CreateRedDepositAllowance( string   EnterpriseCode
                                            , int      CustomerCode
                                            , int      AcptAnOdrStatus
                                            , string   SalesSlipNum
                                            , string   depositAgentCode
                                            , string   depositAgentNm
                                            , DateTime akaAddUpADate
                                            , string   NewSalesSlipNum)
        // ↑ 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			try 
			{	
			　　//ユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB接続・トランザクション開始
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // ↓ 2008.03.07 980081 c
                //// ↓ 20070131 18322 c MA.NS用に変更
				////// 売赤伝作成時入金引当赤作成処理
				////status = CreateRedDepositAllowanceMain(EnterpriseCode, CustomerCode, AcceptAnOrderNo, NewAcceptAnOrderNo, ref sqlConnection,ref sqlTransaction);
				//// 売赤伝作成時入金引当赤作成処理
				//status = CreateRedDepositAllowanceMain( EnterpriseCode
                //                                      , CustomerCode
                //                                      , AcceptAnOrderNo
                //                                      , depositAgentCode
                //                                      , depositAgentNm
                //                                      , akaAddUpADate
                //                                      , NewAcceptAnOrderNo
                //                                      , ref sqlConnection
                //                                      , ref sqlTransaction);
                //// ↑ 20070131 18322 c
                status = CreateRedDepositAllowanceMain(EnterpriseCode
                                                      , CustomerCode
                                                      , AcptAnOdrStatus
                                                      , SalesSlipNum
                                                      , depositAgentCode
                                                      , depositAgentNm
                                                      , akaAddUpADate
                                                      , NewSalesSlipNum
                                                      , ref sqlConnection
                                                      , ref sqlTransaction);
                // ↑ 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
		}
		
		/// <summary>
		/// 売赤伝作成時入金引当赤作成処理メイン
		/// </summary>
		/// <param name="EnterpriseCode">企業コード</param>
		/// <param name="CustomerCode">得意先コード</param>
        /// <param name="AcptAnOdrStatus">受注ステータス</param>
        /// <param name="SalesSlipNum">売上伝票番号</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="akaAddUpADate">赤伝計上日</param>
        /// <param name="NewSalesSlipNum">赤伝売上伝票番号</param>
        /// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns></returns>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先コード・受注番号に引当られている入金引当MTから赤受注に対する赤引当作成し、入金MTの引当額を減算更新します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br>Update Note: 2007.01.31 18322 c MA.NS用に変更</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
		//// ↓ 20070131 18322 c
        ////public int CreateRedDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //
        //public int CreateRedDepositAllowanceMain(     string         EnterpriseCode
        //                                        ,     int            CustomerCode
        //                                        ,     int            AcceptAnOrderNo
        //                                        ,     string         depositAgentCode
        //                                        ,     string         depositAgentNm
        //                                        ,     DateTime       akaAddUpADate
        //                                        ,     int            NewAcceptAnOrderNo
        //                                        , ref SqlConnection  sqlConnection
        //                                        , ref SqlTransaction sqlTransaction)
        //// ↑
        public int CreateRedDepositAllowanceMain(     string         EnterpriseCode
                                                ,     int            CustomerCode
                                                ,     int            AcptAnOdrStatus
                                                ,     string         SalesSlipNum
                                                ,     string         depositAgentCode
                                                ,     string         depositAgentNm
                                                ,     DateTime       akaAddUpADate
                                                ,     string         NewSalesSlipNum
                                                , ref SqlConnection sqlConnection
                                                , ref SqlTransaction sqlTransaction)
        // ↑ 2008.03.07 980081 c
		{
			//			DepsitMainWork depsitMainWork = null;
			DepositAlwWork[] depositAlwWorkList = null;

			DepositAlwWork Red_depositAlwWork;

			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// 入金引当マスタ読込み
            // ↓ 2008.03.07 980081 c
            //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            // ↑ 2008.03.07 980081 c

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{

				// 入金引当情報更新
				for(int ix=0; ix < depositAlwWorkList.Length; ix++)
				{
					DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[ix];

					// 入金マスタの引当額更新(引当マスタ額を減算更新)
					status = UpdateDepsitMainRec(ref depositAlwWork,  ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

                    // ↓ 2008.03.07 980081 c
                    //// ↓ 20070131 18322 c MA.NS用に変更
                    ////// 元黒入金引当データを元に赤入金引当情報作成
					////Red_depositAlwWork = CreateRedDepositAlwWork(NewAcceptAnOrderNo, depositAlwWork);
                    //// 元黒入金引当データを元に赤入金引当情報作成
                    //Red_depositAlwWork = CreateRedDepositAlwWork( NewAcceptAnOrderNo
                    //                                            , depositAgentCode
                    //                                            , depositAgentNm
                    //                                            , akaAddUpADate
                    //                                            , depositAlwWork
                    //                                            );
                    //// ↑ 20070131 18322 c
                    Red_depositAlwWork = CreateRedDepositAlwWork( AcptAnOdrStatus
                                                                , NewSalesSlipNum
                                                                , depositAgentCode
                                                                , depositAgentNm
                                                                , akaAddUpADate
                                                                , depositAlwWork
                                                                );
                    // ↑ 2008.03.07 980081 c

					// 引当マスタ赤作成
					status = InsertDepositAlwWorkRec(ref Red_depositAlwWork, ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

				}

			}

			return status;
		}

		/// <summary>
		/// 赤入金引当情報生成処理
		/// </summary>
        /// <param name="NewAcptAnOdrStatus">受注ステータス</param>
        /// <param name="NewSalesSlipNum">売上伝票番号</param>
        /// <param name="depositAgentCode">入金担当者コード</param>
        /// <param name="depositAgentNm">入金担当者名</param>
        /// <param name="akaAddUpADate">赤伝計上日</param>
		/// <param name="depositAlwWork">元黒入金引当情報</param>
		/// <returns>赤入金引当情報</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタ情報から赤引当情報を作成します</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 山田 明友 流通基幹対応</br>
        /// </remarks>
        // ↓ 2008.03.07 980081 c
        //// ↓ 20070131 18322 c MA.NS用に変更 
		////private DepositAlwWork CreateRedDepositAlwWork(int NewAcceptAnOrderNo, DepositAlwWork depositAlwWork)
		//private DepositAlwWork CreateRedDepositAlwWork( int            NewAcceptAnOrderNo
        //                                              , string         depositAgentCode
        //                                              , string         depositAgentNm
        //                                              , DateTime       akaAddUpADate
        //                                              , DepositAlwWork depositAlwWork)
        //// ↑ 20070131 18322 c
		private DepositAlwWork CreateRedDepositAlwWork( int            NewAcptAnOdrStatus
                                                      , string         NewSalesSlipNum
                                                      , string         depositAgentCode
                                                      , string         depositAgentNm
                                                      , DateTime       akaAddUpADate
                                                      , DepositAlwWork depositAlwWork)
        // ↑ 2008.03.07 980081 c
		{
			DepositAlwWork newDepositAlwWork = new DepositAlwWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // ↓ 20070131 18322 c MA.NS用に変更
            #region SF 赤引当情報作成（全てコメントアウト）
            ////				newDepositAlwWork.CreateDateTime = depositAlwWorkList.CreateDateTime;
			////				newDepositAlwWork.UpdateDateTime = depositAlwWorkList.UpdateDateTime;
			//newDepositAlwWork.EnterpriseCode = depositAlwWork.EnterpriseCode;
			////				newDepositAlwWork.FileHeaderGuid = depositAlwWorkList.FileHeaderGuid;
			////newDepositAlwWork.UpdEmployeeCode = UpdateSecCd;											// 更新従業員コード<-入金担当者コード ???
			////				newDepositAlwWork.UpdAssemblyId1 = depositAlwWorkList.UpdAssemblyId1;
			////				newDepositAlwWork.UpdAssemblyId2 = depositAlwWorkList.UpdAssemblyId2;
			//newDepositAlwWork.LogicalDeleteCode = 0;
			//newDepositAlwWork.CustomerCode = depositAlwWork.CustomerCode;
			//newDepositAlwWork.AddUpSecCode = depositAlwWork.AddUpSecCode;
			//newDepositAlwWork.AcceptAnOrderNo = NewAcceptAnOrderNo;										// 受注番号←赤受注番号
			//newDepositAlwWork.DepositSlipNo = depositAlwWork.DepositSlipNo;								// 入金伝票番号
			//newDepositAlwWork.DepositKindCode = depositAlwWork.DepositKindCode;
			//newDepositAlwWork.DepositInputDate = depositAlwWork.DepositInputDate;						// 入金入力日付
			//newDepositAlwWork.DepositAllowance = depositAlwWork.DepositAllowance * -1;					// 引当額
			//newDepositAlwWork.ReconcileDate = DateTime.Now;												// 消込み日←システム日付
			//newDepositAlwWork.ReconcileAddUpDate = depositAlwWork.DepositInputDate;						// 消込み計上日←入金計上日
			//newDepositAlwWork.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;						// 赤伝相殺区分
			//newDepositAlwWork.DepositCd = depositAlwWork.DepositCd;										// 預り金区分←パラメータ値
			//newDepositAlwWork.CreditOrLoanCd = depositAlwWork.CreditOrLoanCd;
			//// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//newDepositAlwWork.AcpOdrDepositAlwc = depositAlwWork.AcpOdrDepositAlwc * -1;				// 受注引当額
			//newDepositAlwWork.VarCostDepoAlwc	= depositAlwWork.VarCostDepoAlwc * -1;					// 諸費用引当額
			//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            // 企業コード
            newDepositAlwWork.EnterpriseCode      = depositAlwWork.EnterpriseCode;
            // 論理削除区分
            newDepositAlwWork.LogicalDeleteCode   = 0;
            
            // 入金入力拠点コード
            newDepositAlwWork.InputDepositSecCd   = depositAlwWork.InputDepositSecCd ;
            // 計上拠点コード
            newDepositAlwWork.AddUpSecCode        = depositAlwWork.AddUpSecCode      ;
            // 消込み日
            newDepositAlwWork.ReconcileDate       = DateTime.Now                     ;
            // 消込み計上日(赤伝計上日)
            newDepositAlwWork.ReconcileAddUpDate = akaAddUpADate;
            // 入金伝票番号
            newDepositAlwWork.DepositSlipNo       = depositAlwWork.DepositSlipNo     ;
            // 入金金種コード
            newDepositAlwWork.DepositKindCode     = depositAlwWork.DepositKindCode   ;
            // 入金金種名称
            newDepositAlwWork.DepositKindName     = depositAlwWork.DepositKindName   ;
            // 入金引当額
            newDepositAlwWork.DepositAllowance    = depositAlwWork.DepositAllowance * -1;
            // 入金担当者コード
            newDepositAlwWork.DepositAgentCode    = depositAgentCode  ;
            // 入金担当者名称
            newDepositAlwWork.DepositAgentNm      = depositAgentNm    ;
            // 得意先コード
            newDepositAlwWork.CustomerCode        = depositAlwWork.CustomerCode      ;
            // 得意先名称
            newDepositAlwWork.CustomerName        = depositAlwWork.CustomerName      ;
            // 得意先名称2
            newDepositAlwWork.CustomerName2       = depositAlwWork.CustomerName2     ;
            // ↓ 2008.03.07 980081 d
            //// 受注番号
            //newDepositAlwWork.AcceptAnOrderNo     = depositAlwWork.AcceptAnOrderNo   ;
            //// サービス伝票区分
            //newDepositAlwWork.ServiceSlipCd       = depositAlwWork.ServiceSlipCd   ;
            // ↑ 2008.03.07 980081 d
            // 赤伝相殺区分
            newDepositAlwWork.DebitNoteOffSetCd   = depositAlwWork.DebitNoteOffSetCd ;
            // 預り金区分
            newDepositAlwWork.DepositCd           = depositAlwWork.DepositCd         ;
            // ↓ 2008.03.07 980081 d
            //// クレジット／ローン区分
            //newDepositAlwWork.CreditOrLoanCd      = depositAlwWork.CreditOrLoanCd    ;
            // ↑ 2008.03.07 980081 d
            // ↑ 20070131 18322 c
            // ↓ 2008.03.07 980081 a
            newDepositAlwWork.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;
            newDepositAlwWork.SalesSlipNum    = NewSalesSlipNum;
            // ↑ 2008.03.07 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepositAlwWork.EnterpriseCode = depositAlwWork.EnterpriseCode;
            newDepositAlwWork.LogicalDeleteCode = 0;
            newDepositAlwWork.InputDepositSecCd = depositAlwWork.InputDepositSecCd;
            newDepositAlwWork.AddUpSecCode = depositAlwWork.AddUpSecCode;
            newDepositAlwWork.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;
            newDepositAlwWork.SalesSlipNum = NewSalesSlipNum;
            newDepositAlwWork.ReconcileDate = DateTime.Now;
            newDepositAlwWork.ReconcileAddUpDate = akaAddUpADate;
            newDepositAlwWork.DepositSlipNo = depositAlwWork.DepositSlipNo;
            newDepositAlwWork.DepositAllowance = depositAlwWork.DepositAllowance * -1;
            newDepositAlwWork.DepositAgentCode = depositAgentCode;
            newDepositAlwWork.DepositAgentNm = depositAgentNm;
            newDepositAlwWork.CustomerCode = depositAlwWork.CustomerCode;
            newDepositAlwWork.CustomerName = depositAlwWork.CustomerName;
            newDepositAlwWork.CustomerName2 = depositAlwWork.CustomerName2;
            newDepositAlwWork.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;
            //--- ADD 2008/04/25 M.Kubota ---<<<

			return newDepositAlwWork;
		}

		/// <summary>
		/// 入金引当マスタ情報を更新します
		/// ※売上の赤伝作成時、本黒伝の入金引当に対する赤引当（マイナス引当）を赤伝に対して作成します。
		/// </summary>
		/// <param name="depositAlwWork">入金引当情報</param>
		/// <param name="sqlConnection">ｺﾈｸｼｮﾝ情報</param>
		/// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 入金引当マスタ情報の更新を行います</br>
		/// <br>Programmer : 95089 徳永　誠</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		private int InsertDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			//Selectコマンドの生成
			try			
			{
                // ↓ 20070131 18322 c MA.NS用に変更
                #region SF 入金引当マスタ INSERT文（コメントアウト）
                ////新規作成時のSQL文を生成
				//string insertText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
				//					+", ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "	
				//					+") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @ADDUPSECCODE, @ACCEPTANORDERNO, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITINPUTDATE, @DEPOSITALLOWANCE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEBITNOTEOFFSETCD, @DEPOSITCD, @CREDITORLOANCD"
				//					+", @ACPODRDEPOSITALWC, @VARCOSTDEPOALWC"		
				//					+")";
                #endregion

                #region MA.NS 入金引当マスタ INSERT文(コメントアウト)
                //string insertText = "INSERT INTO DEPOSITALWRF("
                //                  +                  " CREATEDATETIMERF"
                //                  +                  ",UPDATEDATETIMERF"
                //                  +                  ",ENTERPRISECODERF"
                //                  +                  ",FILEHEADERGUIDRF"
                //                  +                  ",UPDEMPLOYEECODERF"
                //                  +                  ",UPDASSEMBLYID1RF"
                //                  +                  ",UPDASSEMBLYID2RF"
                //                  +                  ",LOGICALDELETECODERF"
                //                  +                  ",INPUTDEPOSITSECCDRF"
                //                  +                  ",ADDUPSECCODERF"
                //                  +                  ",RECONCILEDATERF"
                //                  +                  ",RECONCILEADDUPDATERF"
                //                  +                  ",DEPOSITSLIPNORF"
                //                  +                  ",DEPOSITKINDCODERF"
                //                  +                  ",DEPOSITKINDNAMERF"
                //                  +                  ",DEPOSITALLOWANCERF"
                //                  +                  ",DEPOSITAGENTCODERF"
                //                  +                  ",DEPOSITAGENTNMRF"
                //                  +                  ",CUSTOMERCODERF"
                //                  +                  ",CUSTOMERNAMERF"
                //                  +                  ",CUSTOMERNAME2RF"
                //                  +                  ",ACCEPTANORDERNORF"
                //                  +                  ",SERVICESLIPCDRF"
                //                  +                  ",DEBITNOTEOFFSETCDRF"
                //                  +                  ",DEPOSITCDRF"
                //                  +                  ",CREDITORLOANCDRF"
                //                  +         ") VALUES ("
                //                  +                  " @CREATEDATETIME"
                //                  +                  ",@UPDATEDATETIME"
                //                  +                  ",@ENTERPRISECODE"
                //                  +                  ",@FILEHEADERGUID"
                //                  +                  ",@UPDEMPLOYEECODE"
                //                  +                  ",@UPDASSEMBLYID1"
                //                  +                  ",@UPDASSEMBLYID2"
                //                  +                  ",@LOGICALDELETECODE"
                //                  +                  ",@INPUTDEPOSITSECCD"
                //                  +                  ",@ADDUPSECCODE"
                //                  +                  ",@RECONCILEDATE"
                //                  +                  ",@RECONCILEADDUPDATE"
                //                  +                  ",@DEPOSITSLIPNO"
                //                  +                  ",@DEPOSITKINDCODE"
                //                  +                  ",@DEPOSITKINDNAME"
                //                  +                  ",@DEPOSITALLOWANCE"
                //                  +                  ",@DEPOSITAGENTCODE"
                //                  +                  ",@DEPOSITAGENTNM"
                //                  +                  ",@CUSTOMERCODE"
                //                  +                  ",@CUSTOMERNAME"
                //                  +                  ",@CUSTOMERNAME2"
                //                  +                  ",@ACCEPTANORDERNO"
                //                  +                  ",@SERVICESLIPCD"
                //                  +                  ",@DEBITNOTEOFFSETCD"
                //                  +                  ",@DEPOSITCD"
                //                  +                  ",@CREDITORLOANCD"
                //                  + ")";
                #endregion
                // ↑ 20070131 18322 c
                // ↓ 2008.03.07 980081 a
                //string insertText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @ACPTANODRSTATUS, @SALESSLIPNUM, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @DEBITNOTEOFFSETCD, @DEPOSITCD)";  //DEL 2008/04/25 M.Kubota

                # region [INSERT文]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string insertText = string.Empty;
                insertText += "INSERT INTO DEPOSITALWRF" + Environment.NewLine;
                insertText += "(" + Environment.NewLine;
                insertText += "  CREATEDATETIMERF" + Environment.NewLine;
                insertText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                insertText += " ,ENTERPRISECODERF" + Environment.NewLine;
                insertText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                insertText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                insertText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                insertText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                insertText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                insertText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                insertText += " ,ADDUPSECCODERF" + Environment.NewLine;
                insertText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                insertText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                insertText += " ,RECONCILEDATERF" + Environment.NewLine;
                insertText += " ,RECONCILEADDUPDATERF" + Environment.NewLine;
                insertText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                insertText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                insertText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                insertText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                insertText += " ,CUSTOMERCODERF" + Environment.NewLine;
                insertText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                insertText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                insertText += " ,DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                insertText += ")" + Environment.NewLine;
                insertText += "VALUES" + Environment.NewLine;
                insertText += "(" + Environment.NewLine;
                insertText += "  @CREATEDATETIME" + Environment.NewLine;
                insertText += " ,@UPDATEDATETIME" + Environment.NewLine;
                insertText += " ,@ENTERPRISECODE" + Environment.NewLine;
                insertText += " ,@FILEHEADERGUID" + Environment.NewLine;
                insertText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                insertText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                insertText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                insertText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                insertText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                insertText += " ,@ADDUPSECCODE" + Environment.NewLine;
                insertText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                insertText += " ,@SALESSLIPNUM" + Environment.NewLine;
                insertText += " ,@RECONCILEDATE" + Environment.NewLine;
                insertText += " ,@RECONCILEADDUPDATE" + Environment.NewLine;
                insertText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                insertText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                insertText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                insertText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                insertText += " ,@CUSTOMERCODE" + Environment.NewLine;
                insertText += " ,@CUSTOMERNAME" + Environment.NewLine;
                insertText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                insertText += " ,@DEBITNOTEOFFSETCD" + Environment.NewLine;
                insertText += ")" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion                
                
                // ↑ 2008.03.07 980081 a

				using(SqlCommand sqlCommand = new SqlCommand(insertText, sqlConnection,sqlTransaction))
				{			
					//登録ヘッダ情報を設定
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)depositAlwWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);

					if(myReader != null && !myReader.IsClosed)myReader.Close();

                    // ↓ 20070131 18322 c MA.NS用に変更
                    #region SF Parameterオブジェクトの設定(更新用)（全てコメントアウト）
                    //#region Parameterオブジェクトの作成(更新用)
                    ////Parameterオブジェクトの作成(更新用)
					//SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
					//SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
					//SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
					//SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
					//SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
					//SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
					//SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
					//SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
					//SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
					//SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
					//SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
					//SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
					//SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
					//SqlParameter paraDepositInputDate = sqlCommand.Parameters.Add("@DEPOSITINPUTDATE", SqlDbType.Int);
					//SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
					//SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
					//SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
					//SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
					//SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
					//SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);					
					//// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
					//SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
					//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					//#endregion
					//
					//#region Parameterオブジェクトへ値設定(更新用)
					//paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
					//paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
					//paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					//paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
					//paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
					//paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
					//paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
					//paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
					//paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
					//paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
					//paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
					//paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
					//paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
					//paraDepositInputDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.DepositInputDate);
					//paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
					//paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
					//paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
					//paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
					//paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
					//paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
					//// 20060220 Ins Start >>諸費用別入金対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);
					//paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);
					//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					//#endregion
                    #endregion

                    # region --- DEL 2008/04/25 M.Kubota ---
                    # if false
                    #region Parameterオブジェクトの作成(更新用)
                    // 作成日時
                    SqlParameter paraCreateDateTime     = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // 更新日時
                    SqlParameter paraUpdateDateTime     = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // 企業コード
                    SqlParameter paraEnterpriseCode     = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid     = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // 更新従業員コード
                    SqlParameter paraUpdEmployeeCode    = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId1     = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // 更新アセンブリID2
                    SqlParameter paraUpdAssemblyId2     = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // 論理削除区分
                    SqlParameter paraLogicalDeleteCode  = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // 入金入力拠点コード
                    SqlParameter paraInputDepositSecCd  = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode       = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // 消込み日
                    SqlParameter paraReconcileDate      = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                    // 消込み計上日
                    SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                    // 入金伝票番号
                    SqlParameter paraDepositSlipNo      = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // 入金金種コード
                    SqlParameter paraDepositKindCode    = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // 入金金種名称
                    SqlParameter paraDepositKindName    = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // 入金引当額
                    SqlParameter paraDepositAllowance   = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // 入金担当者コード
                    SqlParameter paraDepositAgentCode   = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // 入金担当者名称
                    SqlParameter paraDepositAgentNm     = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // 得意先コード
                    SqlParameter paraCustomerCode       = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // 得意先名称
                    SqlParameter paraCustomerName       = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // 得意先名称2
                    SqlParameter paraCustomerName2      = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // ↓ 2008.03.07 980081 d
                    //// 受注番号
                    //SqlParameter paraAcceptAnOrderNo    = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// サービス伝票区分
                    //SqlParameter paraServiceSlipCd      = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // ↑ 2008.03.07 980081 d
                    // 赤伝相殺区分
                    SqlParameter paraDebitNoteOffSetCd  = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                    // 預り金区分
                    SqlParameter paraDepositCd          = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // ↓ 2008.03.07 980081 d
                    //// クレジット／ローン区分
                    //SqlParameter paraCreditOrLoanCd     = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    // ↑ 2008.03.07 980081 d
                    // ↓ 2008.03.07 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    // ↑ 2008.03.07 980081 a
#endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    // 作成日時
                    paraCreateDateTime.Value     = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    // 更新日時
                    paraUpdateDateTime.Value     = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    // 企業コード
                    paraEnterpriseCode.Value     = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value     = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    // 更新従業員コード
                    paraUpdEmployeeCode.Value    = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    // 更新アセンブリID1
                    paraUpdAssemblyId1.Value     = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    // 更新アセンブリID2
                    paraUpdAssemblyId2.Value     = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    // 論理削除区分
                    paraLogicalDeleteCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    // 入金入力拠点コード
                    paraInputDepositSecCd.Value  = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    // 計上拠点コード
                    paraAddUpSecCode.Value       = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    // 消込み日
                    paraReconcileDate.Value      = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    // 消込み計上日
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    // 入金伝票番号
                    paraDepositSlipNo.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    // 入金金種コード
                    paraDepositKindCode.Value    = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
                    // 入金金種名称
                    paraDepositKindName.Value    = SqlDataMediator.SqlSetString(depositAlwWork.DepositKindName);
                    // 入金引当額
                    paraDepositAllowance.Value   = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    // 入金担当者コード
                    paraDepositAgentCode.Value   = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    // 入金担当者名称
                    paraDepositAgentNm.Value     = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    // 得意先コード
                    paraCustomerCode.Value       = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    // 得意先名称
                    paraCustomerName.Value       = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    // 得意先名称2
                    paraCustomerName2.Value      = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    // ↓ 2008.03.07 980081 d
                    //// 受注番号
                    //paraAcceptAnOrderNo.Value    = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    //// サービス伝票区分
                    //paraServiceSlipCd.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.ServiceSlipCd);
                    // ↑ 2008.03.07 980081 d
                    // 赤伝相殺区分
                    paraDebitNoteOffSetCd.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    // 預り金区分
                    paraDepositCd.Value          = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
                    // ↓ 2008.03.07 980081 d
                    //// クレジット／ローン区分
                    //paraCreditOrLoanCd.Value     = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
                    // ↑ 2008.03.07 980081 d
                    // ↓ 2008.03.07 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // ↑ 2008.03.07 980081 a
                    #endregion
                    // ↑ 20070131 18322 c
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                    SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    sqlCommand.ExecuteNonQuery();
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//基底クラスに例外を渡して処理してもらう
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}


	}
}
