//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリストDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津銀次郎
// 修 正 日  2012/05/29  修正内容 : タイムアウト時間を伸ばす修正
//----------------------------------------------------------------------------//

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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売価原価アンマッチリストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売価原価アンマッチリストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RateUnMatchDB : RemoteDB, IRateUnMatchDB
    {
        /// <summary>
        /// 売価原価アンマッチリストDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        /// </remarks>
        public RateUnMatchDB()
            : base("PMHNB02207R", "Broadleaf.Application.Remoting.ParamData.RateUnMatchWork", "RateUnMatchRF")
        {
        }

        # region [Search]
        /// <summary>
        /// 売価原価アンマッチリストを取得します。
        /// </summary>
        /// <param name="unMatchList">アンマッチリスト</param>
        /// <param name="secCodes">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売価原価アンマッチリスト情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        public int Search(out object unMatchList, string[] secCodes)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            unMatchList = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList list = new ArrayList();

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchProc(out list, secCodes, ref sqlConnection, ref sqlTransaction);

                unMatchList = list;
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 売価原価アンマッチリスト情報を取得します。
        /// </summary>
        /// <param name="list">データリスト</param>
        /// <param name="secCodes">拠点コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 全ての売価原価アンマッチリスト情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        private int SearchProc(out ArrayList list, string[] secCodes, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            list = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                StringBuilder sql = new StringBuilder();
                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]
                sql.Append(" SELECT DISTINCT").Append(Environment.NewLine);
                sql.Append("     TA.ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("     TA.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.UNITRATESETDIVCDRF,").Append(Environment.NewLine);
                sql.Append("     TA.RATESETTINGDIVIDERF,").Append(Environment.NewLine);
                sql.Append("     TA.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.UNITPRICEKINDRF,").Append(Environment.NewLine);
                sql.Append("     TA.LOGICALDELETECODERF,").Append(Environment.NewLine);
                sql.Append("     TA.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("     TD.MAKERNAMERF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("     TE.GOODSNAMEKANARF,").Append(Environment.NewLine);
                sql.Append("     TB.B_ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("     TC.C_ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("     TG.G_ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("     TF.SECTIONGUIDESNMRF").Append(Environment.NewLine);
                sql.Append(" FROM").Append(Environment.NewLine);
                sql.Append("     RATERF TA").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("         MAKERURF TD").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TD.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TD.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSMAKERCDRF = TD.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("         GOODSURF TE").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TE.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TE.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSMAKERCDRF = TE.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSNORF = TE.GOODSNORF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("         SECINFOSETRF TF").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TF.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TF.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND TA.SECTIONCODERF = TF.SECTIONCODERF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("     (SELECT").Append(Environment.NewLine);
                sql.Append("         A.ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("         A.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("         A.UNITRATESETDIVCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("         B.ENTERPRISECODERF B_ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     FROM").Append(Environment.NewLine);
                sql.Append("         RATERF A").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("         RATEPROTYMNGRF B").Append(Environment.NewLine);
                sql.Append("     ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND B.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND A.SECTIONCODERF = B.SECTIONCODERF").Append(Environment.NewLine);
                sql.Append("     AND A.UNITPRICEKINDRF = B.UNITPRICEKINDRF").Append(Environment.NewLine);
                sql.Append("     AND A.RATESETTINGDIVIDERF = B.RATESETTINGDIVIDERF").Append(Environment.NewLine);
                sql.Append("     WHERE    ").Append(Environment.NewLine);
                sql.Append(this.MakeWhereString(ref sqlCommand, "A", secCodes));
                sql.Append("     ) AS TB").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TB.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SECTIONCODERF = TB.SECTIONCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.UNITRATESETDIVCDRF = TB.UNITRATESETDIVCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSMAKERCDRF = TB.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSNORF = TB.GOODSNORF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATERANKRF = TB.GOODSRATERANKRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATEGRPCODERF = TB.GOODSRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGROUPCODERF = TB.BLGROUPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGOODSCODERF = TB.BLGOODSCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTOMERCODERF = TB.CUSTOMERCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTRATEGRPCODERF = TB.CUSTRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SUPPLIERCDRF = TB.SUPPLIERCDRF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("     (SELECT").Append(Environment.NewLine);
                sql.Append("         A.ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("         A.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("         A.UNITRATESETDIVCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("         B.ENTERPRISECODERF C_ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     FROM").Append(Environment.NewLine);
                sql.Append("         RATERF A").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("         GOODSURF B").Append(Environment.NewLine);
                sql.Append("     ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND B.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sql.Append("     AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     AND A.GOODSNORF = B.GOODSNORF").Append(Environment.NewLine);
                sql.Append("     WHERE").Append(Environment.NewLine);
                sql.Append(this.MakeWhereString(ref sqlCommand, "A", secCodes));
                sql.Append("     AND A.GOODSNORF <> ''").Append(Environment.NewLine);
                sql.Append("     ) AS TC").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TC.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SECTIONCODERF = TC.SECTIONCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.UNITRATESETDIVCDRF = TC.UNITRATESETDIVCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSMAKERCDRF = TC.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSNORF = TC.GOODSNORF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATERANKRF = TC.GOODSRATERANKRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATEGRPCODERF = TC.GOODSRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGROUPCODERF = TC.BLGROUPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGOODSCODERF = TC.BLGOODSCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTOMERCODERF = TC.CUSTOMERCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTRATEGRPCODERF = TC.CUSTRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SUPPLIERCDRF = TC.SUPPLIERCDRF").Append(Environment.NewLine);
                sql.Append("     LEFT JOIN").Append(Environment.NewLine);
                sql.Append("     (SELECT").Append(Environment.NewLine);
                sql.Append("         A.ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("         A.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("         A.UNITRATESETDIVCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("         A.ENTERPRISECODERF G_ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     FROM").Append(Environment.NewLine);
                sql.Append("         RATERF A").Append(Environment.NewLine);
                sql.Append("     WHERE").Append(Environment.NewLine);
                sql.Append(this.MakeWhereString(ref sqlCommand, "A", secCodes));
                sql.Append("     GROUP BY").Append(Environment.NewLine);
                sql.Append("         A.ENTERPRISECODERF,").Append(Environment.NewLine);
                sql.Append("         A.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("         A.UNITRATESETDIVCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSNORF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("         A.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("         A.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("         A.SUPPLIERCDRF").Append(Environment.NewLine);
                sql.Append("     HAVING").Append(Environment.NewLine);
                sql.Append("         SUM(ABS(A.PRICEFLRF)) = 0").Append(Environment.NewLine);
                sql.Append("         AND SUM(ABS(A.RATEVALRF)) = 0").Append(Environment.NewLine);
                sql.Append("         AND SUM(ABS(A.UPRATERF)) = 0").Append(Environment.NewLine);
                sql.Append("         AND SUM(ABS(A.GRSPROFITSECURERATERF)) = 0").Append(Environment.NewLine);
                sql.Append("     ) AS TG").Append(Environment.NewLine);
                sql.Append("     ON  TA.ENTERPRISECODERF = TG.ENTERPRISECODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SECTIONCODERF = TG.SECTIONCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.UNITRATESETDIVCDRF = TG.UNITRATESETDIVCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSMAKERCDRF = TG.GOODSMAKERCDRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSNORF = TG.GOODSNORF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATERANKRF = TG.GOODSRATERANKRF").Append(Environment.NewLine);
                sql.Append("     AND TA.GOODSRATEGRPCODERF = TG.GOODSRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGROUPCODERF = TG.BLGROUPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.BLGOODSCODERF = TG.BLGOODSCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTOMERCODERF = TG.CUSTOMERCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.CUSTRATEGRPCODERF = TG.CUSTRATEGRPCODERF").Append(Environment.NewLine);
                sql.Append("     AND TA.SUPPLIERCDRF = TG.SUPPLIERCDRF").Append(Environment.NewLine);
                sql.Append(" WHERE").Append(Environment.NewLine);
                sql.Append(this.MakeWhereString(ref sqlCommand, "TA", secCodes));
                sql.Append(" AND (TB.B_ENTERPRISECODERF IS NULL OR TC.C_ENTERPRISECODERF IS NULL").Append(Environment.NewLine);
                sql.Append(" OR TG.G_ENTERPRISECODERF IS NOT NULL)").Append(Environment.NewLine);
                sql.Append(" ORDER BY").Append(Environment.NewLine);
                sql.Append("     TA.SECTIONCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.UNITPRICEKINDRF,").Append(Environment.NewLine);
                sql.Append("     TA.CUSTRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.CUSTOMERCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.SUPPLIERCDRF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSMAKERCDRF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSRATERANKRF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSRATEGRPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.BLGROUPCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.BLGOODSCODERF,").Append(Environment.NewLine);
                sql.Append("     TA.GOODSNORF").Append(Environment.NewLine);

                //企業コード
                ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

                sqlCommand.CommandText = sql.ToString();
                # endregion

                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/29

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // クラス格納処理
                    RateUnMatchWork rateUnMatchWork = new RateUnMatchWork();
                    if (this.CopyToRateUnMatchWorkFromReader(ref myReader, out rateUnMatchWork))
                    {
                        list.Add(rateUnMatchWork);
                    }
                }

                if (list.Count > 0)
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
                string errmsg = ex.Message;
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="tableName">テーブル名前</param>
        /// <param name="secCodes">拠点コード</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, string tableName, string[] secCodes)
        {
            #region WHERE文作成
            StringBuilder sqlWhere = new StringBuilder(" ");
            sqlWhere.Append(tableName).Append(".ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);

            //論理削除区分
            sqlWhere.Append(" AND (").Append(tableName);
            sqlWhere.Append(".LOGICALDELETECODERF = 1 OR ");
            sqlWhere.Append(tableName).Append(".LOGICALDELETECODERF = 0)").Append(Environment.NewLine);

            //拠点コード
            if (secCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in secCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    sqlWhere.Append(" AND ");
                    sqlWhere.Append(tableName).Append(".SECTIONCODERF IN (" + sectionCodestr + ") ").Append(Environment.NewLine);
                }
            }

            #endregion
            return sqlWhere.ToString();
        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RateUnMatchWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="rateUnMatchWork">ワーク</param>
        /// <returns>結果(true:エラーがある、false:エラーがない)</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
        /// </remarks>
        private bool CopyToRateUnMatchWorkFromReader(ref SqlDataReader myReader, out RateUnMatchWork rateUnMatchWork)
        {
            rateUnMatchWork = new RateUnMatchWork();

            # region クラスへ格納
            // 企業コード
            rateUnMatchWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            // 拠点コード
            rateUnMatchWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            // 掛率設定区分
            rateUnMatchWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            // 単価掛率設定区分
            rateUnMatchWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            // BLグループコード
            rateUnMatchWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            // 拠点名称
            rateUnMatchWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            // 作成区分
            rateUnMatchWork.UnitPriceKindCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            // 有効区分
            rateUnMatchWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // 得意先掛率グループ
            rateUnMatchWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            // 得意先コード
            rateUnMatchWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 仕入先コード
            rateUnMatchWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            // 商品メーカーコード
            rateUnMatchWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // 商品メーカー名称
            rateUnMatchWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            // 商品掛率ランク
            rateUnMatchWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            // 商品掛率グループコード
            rateUnMatchWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            // BLグループコード
            rateUnMatchWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            // BL商品コード
            rateUnMatchWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            // 商品番号
            rateUnMatchWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // 商品名称
            rateUnMatchWork.GoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));

            // エラー区分
            rateUnMatchWork.IsErrRateProtyMng = "0";
            rateUnMatchWork.IsErrGoodsU = "0";
            rateUnMatchWork.IsAllZero = "0";
            // 掛率優先管理マスタに存在しない場合
            if (myReader.IsDBNull(myReader.GetOrdinal("B_ENTERPRISECODERF")))
            {
                rateUnMatchWork.IsErrRateProtyMng = "1";
            }
            // 商品マスタマスタに存在しない場合
            if (!string.IsNullOrEmpty(rateUnMatchWork.GoodsNo) && myReader.IsDBNull(myReader.GetOrdinal("C_ENTERPRISECODERF")))
            {
                rateUnMatchWork.IsErrGoodsU = "1";
            }
            // 価格（浮動）、掛率、UP率、粗利確保率が全てゼロの場合
            if (!myReader.IsDBNull(myReader.GetOrdinal("G_ENTERPRISECODERF")))
            {
                rateUnMatchWork.IsAllZero = "1";
            }
            # endregion

            // 全てエラーがないチェック
            if (rateUnMatchWork.IsErrRateProtyMng != "1" && 
                rateUnMatchWork.IsErrGoodsU != "1" && 
                rateUnMatchWork.IsAllZero != "1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.03</br>
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
        # endregion
    }
}
