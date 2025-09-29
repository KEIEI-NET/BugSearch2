//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/06/19  修正内容 : 画面の拠点範囲指定は削除（非表示）へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/07/17  修正内容 : 仕入計上拠点コード ==> 仕入拠点コード
//                                  仕入金額合計 ==> 仕入金額計（税抜き）
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 李侠
// 修 正 日  2014/04/18  修正内容 : PM.NS仕掛一覧No2370
//                                  Redmine#42500　仕入金額の変更（仕入金額計（税抜き）==>仕入金額小計）
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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入チェックリストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェックリストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張莉莉</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br>Update Note: 2014/04/18 李侠</br>
    /// <br>管理番号   ：10904597-00 PM.NS仕掛一覧No2370</br>
    /// <br>             Redmine#42500　仕入金額の変更（仕入金額計（税抜き）==>仕入金額小計）</br>
    /// <br>Update Note: デットロックのトレース解析(仕：2677/依：11100068-00)</br>
    /// <br>             Redmine #44965 仕入チェックリストブロック障害の防止</br>
    /// <br>Date       : 2015/03/23</br>
    /// <br>           : 楊　揚</br>
    /// </remarks>
    [Serializable]
    public class StockSlipResultDB : RemoteDB, IStockSlipResultDB
    {
        /// <summary>
        /// 仕入チェックリストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public StockSlipResultDB()
            :
        base("PMKOU02059D", "Broadleaf.Application.Remoting.ParamData.StockSlipResultWork", "STOCKSLIPRESULTRF") //基底クラスのコンストラクタ
        {
        }

        #region Search

        // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止 ---->>>>>
        /// <summary>
        /// トランザクション分離レベルを「READ UNCOMMITTED」に設定します。
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        /// <br>Note       : トランザクション分離レベルの設定</br>
        /// <br>Programmer : 楊　揚</br>
        /// <br>Date       : 2015.03.23</br>
        private static void SetTransIsolationReadUncommitted(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" , conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止 ----<<<<<

        /// <summary>
        /// 指定された企業コードの仕入チェックリストを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockSlipResultWork">検索結果</param>
        /// <param name="stockSlipCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        public int Search(out object stockSlipResultWork, object stockSlipCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockSlipResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                SetTransIsolationReadUncommitted(sqlConnection); // Add by 楊揚　2015/03/23 for redmine #44965 ブロック障害の防止

                return SearchProc(out stockSlipResultWork, stockSlipCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSlipResultDB.Search");
                stockSlipResultWork = new ArrayList();
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
        /// 指定された企業コードの仕入チェックリストを全て戻します
        /// </summary>
        /// <param name="stockSlipResultWork">検索結果</param>
        /// <param name="_stockSlipCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2014/04/18 李侠</br>
        /// <br>管理番号   ：10904597-00 PM.NS仕掛一覧No2370</br>
        /// <br>             Redmine#42500　仕入金額の変更（仕入金額計（税抜き）==>仕入金額小計）</br>
        private int SearchProc(out object stockSlipResultWork, object _stockSlipCndtnWork, ref SqlConnection sqlConnection)
        {
            StockSlipCndtnWork stockSlipCndtnWork = _stockSlipCndtnWork as StockSlipCndtnWork;
            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            stockSlipResultWork = new ArrayList();
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText += " SELECT ";
                sqlCommand.CommandText += " SSRF.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUM, ";
                sqlCommand.CommandText += " SSRF.STOCKDATERF AS STOCKDATE, ";
                // sqlCommand.CommandText += " SSRF.STOCKADDUPSECTIONCDRF AS STOCKADDUPSECTIONCD, ";  // del 20090717 仕入計上拠点コード ==> 仕入拠点コード
                sqlCommand.CommandText += " SSRF.STOCKSECTIONCDRF AS STOCKADDUPSECTIONCD, ";  // add 20090717   仕入計上拠点コード ==> 仕入拠点コード
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNORF AS SUPPLIERSLIPNO, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNOTE1RF AS SUPPLIERSLIPNOTE1, ";
                //sqlCommand.CommandText += " SSRF.STOCKTOTALPRICERF AS STOCKTOTALPRICE, ";  // del 20090717 仕入金額合計 ==> 仕入金額計（税抜き）
                //sqlCommand.CommandText += " SSRF.STOCKTTLPRICTAXEXCRF AS STOCKTOTALPRICE, ";  // add 20090717  仕入金額合計 ==> 仕入金額計（税抜き）//DEL 2014/04/18 PM.NS仕掛一覧No2370 仕入金額計（税抜き）==>仕入金額小計
                sqlCommand.CommandText += " SSRF.STOCKSUBTTLPRICERF AS STOCKTOTALPRICE, ";   //ADD 2014/04/18  PM.NS仕掛一覧No2370 仕入金額計（税抜き）==>仕入金額小計
                sqlCommand.CommandText += " SSRF.PAYEECODERF AS PAYEECODE, ";
                sqlCommand.CommandText += " SSRF.PAYEESNMRF AS PAYEESNM, ";
                sqlCommand.CommandText += " MAX( SDRF.WAYTOORDERRF)AS WAYTOORDER ";
                sqlCommand.CommandText += " FROM STOCKSLIPRF SSRF WITH (READUNCOMMITTED)";
                sqlCommand.CommandText += " LEFT JOIN STOCKDETAILRF SDRF ";
                sqlCommand.CommandText += " ON SDRF.ENTERPRISECODERF =  SSRF.ENTERPRISECODERF ";
                sqlCommand.CommandText += " AND SDRF.LOGICALDELETECODERF =  0 ";
                sqlCommand.CommandText += " AND SDRF.SUPPLIERSLIPNORF =  SSRF.SUPPLIERSLIPNORF ";
                // 検索条件
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, stockSlipCndtnWork);

                sqlCommand.CommandText += " GROUP BY ";
                sqlCommand.CommandText += " SSRF.PARTYSALESLIPNUMRF, ";
                sqlCommand.CommandText += " SSRF.STOCKDATERF, ";
                sqlCommand.CommandText += " SSRF.STOCKSECTIONCDRF, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNORF, ";
                sqlCommand.CommandText += " SSRF.SUPPLIERSLIPNOTE1RF, ";
                //sqlCommand.CommandText += " SSRF.STOCKTTLPRICTAXEXCRF, ";//DEL 2014/04/18 PM.NS仕掛一覧No2370 仕入金額計（税抜き）==>仕入金額小計
                sqlCommand.CommandText += " SSRF.STOCKSUBTTLPRICERF, ";    //ADD 2014/04/18  PM.NS仕掛一覧No2370 仕入金額計（税抜き）==>仕入金額小計
                sqlCommand.CommandText += " SSRF.PAYEECODERF, ";
                sqlCommand.CommandText += " SSRF.PAYEESNMRF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockSlipResultWork wkStockSlipResultWork = new StockSlipResultWork();
                    
                    //仕入データ結果取得内容格納
                    wkStockSlipResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNO"));
                    wkStockSlipResultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATE"));
                    wkStockSlipResultWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCD"));
                    wkStockSlipResultWork.StockAddUpSectionCdPm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCD"));
                    wkStockSlipResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODE"));
                    wkStockSlipResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNM"));
                    wkStockSlipResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICE"));
                    wkStockSlipResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUM"));
                    wkStockSlipResultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1"));
                    wkStockSlipResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDER"));
                    wkStockSlipResultWork.UoeRemark2 = "unchecked";
                    #endregion

                    al.Add(wkStockSlipResultWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            stockSlipResultWork = al;

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockSlipCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSlipCndtnWork _stockSlipCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " SSRF.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockSlipCndtnWork.EnterpriseCode);

            retstring += " AND SSRF.LOGICALDELETECODERF = 0 ";

            // DEL 2009/06/18 画面の拠点範囲指定は削除（非表示）へ変更
            //拠点コード    ※配列で複数指定される
            //if (_stockSlipCndtnWork.SectionCodeList != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockSlipCndtnWork.SectionCodeList)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND SSRF.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            // AND 仕入日>＝パラメータ.支払締日の開始日																																	
            if (!DateTime.MinValue.Equals(_stockSlipCndtnWork.St_csvDate))
            {
                retstring += "AND SSRF.STOCKDATERF>=@ST_SCVDAY ";
                SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                Para_St_csvDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockSlipCndtnWork.St_csvDate);
            }

            // AND 仕入日<＝パラメータ.支払締日の終了日
            if (!DateTime.MinValue.Equals(_stockSlipCndtnWork.Ed_csvDate))
            {
                retstring += "AND SSRF.STOCKDATERF<=@ED_SCVDAY ";
                SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                Para_Ed_csvDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockSlipCndtnWork.Ed_csvDate);
            }

            //仕入先コード(SUPPLIERCDRF)
            if (_stockSlipCndtnWork.SupplierCd != 0)
            {
                retstring += " AND SSRF.SUPPLIERCDRF=@SUPPLIERCDRF";
                SqlParameter paraStStockAdjustSlipNo = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                paraStStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(_stockSlipCndtnWork.SupplierCd);
            }
            #endregion
            return retstring;
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
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
        #endregion  //コネクション生成処理
    }
}
