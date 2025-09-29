//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2010/08/27  修正内容 : 品番の曖昧検索
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/09/01  修正内容 : 明細のソート順が「品番・ﾒｰｶｰ順」にソートする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 修 正 日  2010/09/02  修正内容 : #13972の対応
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率設定マスタメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/08/04</br>
    /// <br>Update Note: 2010/09/01 呉元嘯</br>
    /// <br>           : 明細のソート順が「品番・ﾒｰｶｰ順」にソートする</br>
    /// </remarks>
    [Serializable]
    public class SingleGoodsRateDB : RemoteDB, ISingleGoodsRateDB, IGetSyncdataList
    {
        /// <summary>
        /// 掛率設定マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 李占川</br>														   
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public SingleGoodsRateDB()
            :
        base("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateWork", "RATERF")
        {
        }

        /// <summary>
        /// 掛率リモート
        /// </summary>
        private RateDB _rateDB = new RateDB();

        #region [Read]
        /// <summary>
        /// 指定された条件の掛率設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                SingleGoodsRateWork rateWork = new SingleGoodsRateWork();

                // XMLの読み込み
                rateWork = (SingleGoodsRateWork)XmlByteSerializer.Deserialize(parabyte, typeof(SingleGoodsRateWork));
                if (rateWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref rateWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(rateWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.Read");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int ReadProc(ref SingleGoodsRateWork rateWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref rateWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int ReadProcProc(ref SingleGoodsRateWork rateWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string command = string.Empty;
            
            command = "SELECT * FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                    findParaGoodsNo.Value = rateWork.GoodsNo;
                    findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                    findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        rateWork = CopyToRateWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int Write(ref object rateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rateWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSubSectionProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                rateWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.Write(ref object rateWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int WriteSubSectionProc(ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateWriteList = null;
            ArrayList rateDeleteList = null;

            if (rateWorkList != null)
            {
                CreateRateWriteDelList(rateWorkList, out rateWriteList, out rateDeleteList);

                if (rateWriteList.Count != 0)
                {
                    status = this.WriteSubSectionProcProc(ref rateWriteList, ref sqlConnection, ref sqlTransaction);
                }
                if (rateDeleteList.Count != 0)
                {
                    status = this.DeleteSubSectionProcProc(rateDeleteList, ref sqlConnection, ref sqlTransaction);
                }
            }

            return status;
		}

        #region 掛率マスタ更新用リスト、削除用リスト作成
        /// <summary>
        /// 掛率マスタ更新用リスト、削除用リスト作成
        /// </summary>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <param name="stockWriteList">在庫更新用リスト</param>
        /// <param name="stockDeleteList">在庫削除用リスト</param>
        /// <returns></returns>
        private int CreateRateWriteDelList(ArrayList rateWorkList, out ArrayList rateWriteList, out ArrayList rateDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            rateWriteList = new ArrayList();
            rateDeleteList = new ArrayList();

            foreach (SingleGoodsRateWork rateWork in rateWorkList)
            {
                if (rateWork.LogicalDeleteCode == 3)
                {
                    //削除用リスト作成
                    rateDeleteList.Add(rateWork);
                }
                else
                {
                    //更新用リスト作成
                    rateWriteList.Add(rateWork);
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int WriteSubSectionProcProc(ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            
            string command = string.Empty;
            command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
            
            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                        SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != rateWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (rateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
                            

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (rateWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;
                            sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                            sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                            sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                            sqlCommand.CommandText += " )" + Environment.NewLine;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                        SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                        SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                        SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                        SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                        SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                        SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                        SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                        SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        paraGoodsNo.Value = rateWork.GoodsNo;
                        paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rateWork);
                    }
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="parserateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int Search(out object rateWork, object parserateWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rateWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSubSectionProc(out rateWork, parserateWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.Search");
                rateWork = new ArrayList();
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objrateWork">検索結果</param>
        /// <param name="pararateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int SearchSubSectionProc(out object objrateWork, object pararateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SingleGoodsRateWork rateWork = null;
            int status = 0;

            ArrayList pararateWorkList = pararateWork as ArrayList;
            ArrayList rateWorkList = null;
            ArrayList rateResultList = new ArrayList();

            if (pararateWorkList == null)
            {
                rateWork = pararateWork as SingleGoodsRateWork;
                status = SearchSubSectionProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
                objrateWork = rateWorkList;
            }
            else
            {

                status = SearchSubSectionProc(out rateWorkList, pararateWorkList, readMode, logicalMode, ref sqlConnection);
                objrateWork = rateWorkList;
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int SearchSubSectionProc(out ArrayList rateWorkList, SingleGoodsRateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchSubSectionProcProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="paraList">検索パラメータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/04</br>
        public int SearchSubSectionProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSubSectionProcProc(out rateWorkList, paraList, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int SearchSubSectionProcProc(out ArrayList rateWorkList, SingleGoodsRateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rateWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRateWorkFromReader(ref myReader));

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

            rateWorkList = al;

            return status;
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="paraList">検索パラメータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/04</br>
        private int SearchSubSectionProcProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            ArrayList searchedRateList;
            ArrayList searchParaList = new ArrayList();
            int cnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            for (int i = 0; i < paraList.Count; i++)
            {
                searchParaList.Add(paraList[i] as SingleGoodsRateWork);

                // 15件ずつ抽出(試した結果速かった為)
                if (searchParaList.Count % 15 == 0)
                {
                    status = ListSearchSubSectionProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);
                    cnt++;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                        searchedRateList.Count > 0)
                    {
                        rateWorkList.AddRange(searchedRateList.ToArray());
                    }
                    searchParaList = new ArrayList();
                }
            }
            if (searchParaList.Count > 0)
            {
                status = ListSearchSubSectionProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);
                cnt++;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    searchedRateList.Count > 0)
                {
                    rateWorkList.AddRange(searchedRateList.ToArray());
                }
            }
            if (rateWorkList.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="paraList">検索パラメータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/04</br>
        private int ListSearchSubSectionProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF ", sqlConnection);

                string whereString = string.Empty;
                string whereString2 = string.Empty;
                int cnt = 0;
                foreach (SingleGoodsRateWork rateWork in paraList)
                {
                    cnt++;
                    whereString2 = MakeWhereString2(ref sqlCommand, rateWork, logicalMode, cnt);
                    if (!string.IsNullOrEmpty(whereString2))
                    {
                        whereString += ( string.IsNullOrEmpty(whereString) ) ? whereString2 : " OR " + whereString2;
                    }
                }

                if (!string.IsNullOrEmpty(whereString))
                {
                    whereString = "WHERE " + whereString;
                }

                sqlCommand.CommandText += whereString;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRateWorkFromReader(ref myReader));

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

            rateWorkList = al;

            return status;
        }

        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF  ", sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRateWorkFromReader(ref myReader));

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

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int LogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 0);
        }

        /// <summary>
        /// 論理削除掛率設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除掛率設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int RevivalLogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 1);
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="rateWork">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private int LogicalDeleteSubSection(ref object rateWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rateWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSubSectionProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "RateDB.LogicalDeleteCarrier :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int LogicalDeleteSubSectionProc(ref ArrayList rateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteSubSectionProcProc(ref rateWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">SingleGoodsRateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int LogicalDeleteSubSectionProcProc(ref ArrayList rateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string command = string.Empty;
            command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                        SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);  
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                        
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != rateWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                            sqlCommand.CommandText += "SET" + Environment.NewLine;
                            sqlCommand.CommandText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rateWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) rateWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else rateWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) rateWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rateWork);
                    }

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		public int DeleteSubSectionProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteSubSectionProcProc(rateWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int DeleteSubSectionProcProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;
            command += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;
                    sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                    findParaGoodsNo.Value = rateWork.GoodsNo;
                    findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                    findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rateWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
                        
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SingleGoodsRateWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
            }

            //単価掛率設定区分
            if (rateWork.UnitRateSetDivCd != "")
            {
                if (rateWork.UnitRateSetDivCd.Length == 3)
                {
                    retstring += "AND UNITRATESETDIVCDRF LIKE '" + rateWork.UnitRateSetDivCd + "%' ";
                }
                else
                {
                    retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD ";
                    SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                }
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品番号
            if (rateWork.GoodsNo != "")
            {
                retstring += "AND GOODSNORF=@FINDGOODSNO ";
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = rateWork.GoodsNo;
            }

            //商品掛率ランク
            if (rateWork.GoodsRateRank != "")
            {
                retstring += "AND GOODSRATERANKRF=@FINDGOODSRATERANK ";
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                paraGoodsRateRank.Value = rateWork.GoodsRateRank;
            }

            //商品掛率グループコード
            if (rateWork.GoodsRateGrpCode != 0)
            {
                retstring += "AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE ";
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
            }

            //BLグループコード
            if (rateWork.BLGroupCode != 0)
            {
                retstring += "AND BLGROUPCODERF=@FINDBLGROUPCODE ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
            }

            //BL商品コード
            if (rateWork.BLGoodsCode != 0)
            {
                retstring += "AND BLGOODSCODERF=@FINDBLGOODSCODE ";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
            }

            //得意先コード
            if (rateWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
            }

            //得意先掛率グループコード
            if (rateWork.CustRateGrpCode != 0)
            {
                retstring += "AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE ";
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
            }

            //仕入先コード
            if (rateWork.SupplierCd != 0)
            {
                retstring += "AND SUPPLIERCDRF=@FINDSUPPLIERCD ";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
            }

            //ロット数
            if (rateWork.LotCount != -1.0)
            {
                retstring += "AND LOTCOUNTRF=@FINDLOTCOUNT ";
                SqlParameter paraLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);
                paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
            }

            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, SingleGoodsRateWork rateWork, ConstantManagement.LogicalMode logicalMode, int cnt)
        {
            string wkstring = "";
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + cnt.ToString() + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE" + cnt.ToString(), SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if (( logicalMode == ConstantManagement.LogicalMode.GetData0 ) ||
                ( logicalMode == ConstantManagement.LogicalMode.GetData1 ) ||
                ( logicalMode == ConstantManagement.LogicalMode.GetData2 ) ||
                ( logicalMode == ConstantManagement.LogicalMode.GetData3 ))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + cnt.ToString();
            }
            else if (( logicalMode == ConstantManagement.LogicalMode.GetData01 ) ||
                ( logicalMode == ConstantManagement.LogicalMode.GetData012 ))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + cnt.ToString();
            }
            if (wkstring != "")
            {
                retstring += wkstring + " ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE" + cnt.ToString(), SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE" + cnt.ToString() + " ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE" + cnt.ToString(), SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
            }

            //単価掛率設定区分
            if (rateWork.UnitRateSetDivCd != "")
            {
                if (rateWork.UnitRateSetDivCd.Length == 3)
                {
                    retstring += "AND UNITRATESETDIVCDRF LIKE '" + rateWork.UnitRateSetDivCd + "%' ";
                }
                else
                {
                    retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD ";
                    SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD" + cnt.ToString(), SqlDbType.NChar);
                    paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                }
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + cnt.ToString() + " ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD" + cnt.ToString(), SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品番号
            if (rateWork.GoodsNo != "")
            {
                retstring += "AND GOODSNORF=@FINDGOODSNO" + cnt.ToString() + " ";
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO" + cnt.ToString(), SqlDbType.NVarChar);
                paraGoodsNo.Value = rateWork.GoodsNo;
            }

            //商品掛率ランク
            if (rateWork.GoodsRateRank != "")
            {
                retstring += "AND GOODSRATERANKRF=@FINDGOODSRATERANK" + cnt.ToString() + " ";
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK" + cnt.ToString(), SqlDbType.NChar);
                paraGoodsRateRank.Value = rateWork.GoodsRateRank;
            }

            //商品掛率グループコード
            if (rateWork.GoodsRateGrpCode != 0)
            {
                retstring += "AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + cnt.ToString() + " ";
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE" + cnt.ToString(), SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
            }

            //BLグループコード
            if (rateWork.BLGroupCode != 0)
            {
                retstring += "AND BLGROUPCODERF=@FINDBLGROUPCODE" + cnt.ToString() + " ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE" + cnt.ToString(), SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
            }

            //BL商品コード
            if (rateWork.BLGoodsCode != 0)
            {
                retstring += "AND BLGOODSCODERF=@FINDBLGOODSCODE" + cnt.ToString() + " ";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE" + cnt.ToString(), SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
            }

            //得意先コード
            if (rateWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + cnt.ToString() + " ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE" + cnt.ToString(), SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
            }

            //得意先掛率グループコード
            if (rateWork.CustRateGrpCode != -1)
            {
                retstring += "AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + cnt.ToString() + " ";
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE" + cnt.ToString(), SqlDbType.Int);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
            }

            //仕入先コード
            if (rateWork.SupplierCd != 0)
            {
                retstring += "AND SUPPLIERCDRF=@FINDSUPPLIERCD" + cnt.ToString() + " ";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD" + cnt.ToString(), SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
            }

            //ロット数
            if (rateWork.LotCount != -1.0)
            {
                retstring += "AND LOTCOUNTRF=@FINDLOTCOUNT" + cnt.ToString() + " ";
                SqlParameter paraLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT" + cnt.ToString(), SqlDbType.Float);
                paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
            }

            if (!string.IsNullOrEmpty(retstring))
            {
                retstring = "( " + retstring + " )";
            }
            return retstring;
        }
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SingleGoodsRateWork[] RateWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SingleGoodsRateWork)
                    {
                        SingleGoodsRateWork wkRateWork = paraobj as SingleGoodsRateWork;
                        if (wkRateWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRateWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RateWorkArray = (SingleGoodsRateWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SingleGoodsRateWork[]));
                        }
                        catch (Exception) { }
                        if (RateWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RateWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SingleGoodsRateWork wkRateWork = (SingleGoodsRateWork)XmlByteSerializer.Deserialize(byteArray, typeof(SingleGoodsRateWork));
                                if (wkRateWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRateWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SingleGoodsRateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SingleGoodsRateWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private SingleGoodsRateWork CopyToRateWorkFromReader(ref SqlDataReader myReader)
        {
            SingleGoodsRateWork wkRateWork = new SingleGoodsRateWork();

            #region クラスへ格納
            wkRateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkRateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkRateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkRateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkRateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkRateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkRateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkRateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkRateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkRateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkRateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkRateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkRateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkRateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkRateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkRateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkRateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkRateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkRateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkRateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkRateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkRateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkRateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkRateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            #endregion

            return wkRateWork;
        }
        #endregion


        #region [一括登録修正用検索処理]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="parserateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int SearchRate(out object rateSearchResultWork, object rateSearchParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rateSearchResultWork = null;
            //parseRateWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRateSubSectionProc(out rateSearchResultWork, rateSearchParamWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.SearchRate");
                rateSearchResultWork = new ArrayList();
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
        /// 掛率マスタの保存
        /// </summary>
        /// <param name="delparaObj">掛率マスタ</param>
        /// <param name="updparaObj">価格マスタ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        public int Save(object delparaObj, object updparaObj, ref string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList delRateList = delparaObj as ArrayList;
                ArrayList updRateList = updparaObj as ArrayList;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 掛率マスタ
                // 情報を削除する
                if (delRateList.Count > 0)
                {
                    status = _rateDB.DeleteSubSectionProc(delRateList, ref sqlConnection, ref sqlTransaction);
                }

                // 情報を登録する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && updRateList.Count > 0)
                {
                    status = _rateDB.WriteSubSectionProc(ref updRateList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "SingleGoodsRateDB.Save(object delparaObj,object updparaObj)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SingleGoodsRateDB.Save(object delparaObj,object updparaObj)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objrateWork">検索結果</param>
        /// <param name="pararateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int SearchRateSubSectionProc(out object rateSearchResultWork, object rateSearchParamWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = 0;

            SingleGoodsRateSearchParamWork pararateWork = rateSearchParamWork as SingleGoodsRateSearchParamWork;

            ArrayList rateWorkList = null;
            ArrayList rateSearchResultList = new ArrayList();

            status = SearchRateSubSectionProc(out rateWorkList, pararateWork, readMode, logicalMode, ref sqlConnection);

            rateSearchResultWork = (object)rateWorkList;
            if (rateWorkList.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
		private int SearchRateSubSectionProc(out ArrayList rateWorkList, SingleGoodsRateSearchParamWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region SELECT文作成
                // 対象区分「全て」の場合
                if ("0".Equals(rateWork.ObjectDiv))
                {

                    sqlText += "SELECT DISTINCT" + Environment.NewLine; // 
                    sqlText += "PRM.GOODSNORF," + Environment.NewLine; // 品番
                    sqlText += "PRM.GOODSNAMERF AS GOODSNAMERF," + Environment.NewLine; // 品名
                    sqlText += "PRM.GOODSMAKERCDRF," + Environment.NewLine; // メーカー
                    sqlText += "PRM.BLGOODSCODERF AS BLGOODSCODERF," + Environment.NewLine; // BLコード
                    sqlText += "PRM.LOGICALDELETECODERF AS GOODSLOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "BL.BLGROUPCODERF," + Environment.NewLine; // グループコード
                    sqlText += "RATE.BLGROUPCODERF AS RATEBLGROUPCODERF," + Environment.NewLine; // グループコード(掛率マスタ)
                    sqlText += "RATE.BLGOODSCODERF AS RATEBLGOODSCODERF," + Environment.NewLine; // BLコード(掛率マスタ)

                    sqlText += "RATE.UNITPRICEKINDRF," + Environment.NewLine; // 単価種類
                    sqlText += "RATE.RATESETTINGDIVIDERF," + Environment.NewLine; // 掛率設定区分
                    sqlText += "RATE.LOTCOUNTRF," + Environment.NewLine;
                    sqlText += "RATE.PRICEFLRF," + Environment.NewLine; // 売価額
                    sqlText += "RATE.RATEVALRF," + Environment.NewLine; // 売価率
                    sqlText += "RATE.UPRATERF," + Environment.NewLine; // 原価ＵＰ率
                    sqlText += "RATE.GRSPROFITSECURERATERF," + Environment.NewLine; // 粗利確保率
                    sqlText += "RATE.CUSTOMERCODERF," + Environment.NewLine; // 得意先コード		
                    sqlText += "RATE.CUSTRATEGRPCODERF," + Environment.NewLine; // 得意先掛率グループコード	

                    sqlText += "RATE.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "RATE.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "RATE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "RATE.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "RATE.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "RATE.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "RATE.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "RATE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "RATE.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "RATE.UNITRATESETDIVCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGGOODSCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGGOODSNMRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGCUSTCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGCUSTNMRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSMAKERCDRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSRATERANKRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "RATE.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "RATE.UNPRCFRACPROCUNITRF," + Environment.NewLine;
                    sqlText += "RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += " GOODSURF AS PRM" + Environment.NewLine;

                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += " BLGOODSCDURF AS BL -- BLコードマスタ" + Environment.NewLine;
                    sqlText += "ON PRM.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "AND PRM.BLGOODSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                    sqlText += "AND BL.LOGICALDELETECODERF=0" + Environment.NewLine;

                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   *  " + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "   RATERF " + Environment.NewLine;
                    sqlText += MakeWhereRateString(ref sqlCommand, rateWork, 0, logicalMode);
                    sqlText += " ) AS RATE -- 掛率マスタ" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "  ( " + Environment.NewLine;
                    sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                    sqlText += "    AND PRM.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                    sqlText += "    AND PRM.GOODSNORF = RATE.GOODSNORF -- 商品番号" + Environment.NewLine;
                    sqlText += "   )" + Environment.NewLine;

                }
                // 対象区分「登録分のみ」の場合
                else
                {
                    sqlText += "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += "RATE.GOODSNORF," + Environment.NewLine; // 品番
                    sqlText += "PRM.GOODSNAMERF AS GOODSNAMERF," + Environment.NewLine; // 品名
                    sqlText += "RATE.GOODSMAKERCDRF," + Environment.NewLine; // メーカー
                    sqlText += "PRM.BLGOODSCODERF AS BLGOODSCODERF," + Environment.NewLine; // BLコード
                    sqlText += "PRM.LOGICALDELETECODERF AS GOODSLOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "BL.BLGROUPCODERF," + Environment.NewLine; // グループコード
                    sqlText += "RATE.BLGROUPCODERF AS RATEBLGROUPCODERF," + Environment.NewLine; // グループコード(掛率マスタ)
                    sqlText += "RATE.BLGOODSCODERF AS RATEBLGOODSCODERF," + Environment.NewLine; // BLコード(掛率マスタ)

                    sqlText += "RATE.UNITPRICEKINDRF," + Environment.NewLine; // 単価種類
                    sqlText += "RATE.RATESETTINGDIVIDERF," + Environment.NewLine; // 掛率設定区分
                    sqlText += "RATE.LOTCOUNTRF," + Environment.NewLine;
                    sqlText += "RATE.PRICEFLRF," + Environment.NewLine; // 売価額
                    sqlText += "RATE.RATEVALRF," + Environment.NewLine; // 売価率
                    sqlText += "RATE.UPRATERF," + Environment.NewLine; // 原価ＵＰ率
                    sqlText += "RATE.GRSPROFITSECURERATERF," + Environment.NewLine; // 粗利確保率
                    sqlText += "RATE.CUSTOMERCODERF," + Environment.NewLine; // 得意先コード		
                    sqlText += "RATE.CUSTRATEGRPCODERF," + Environment.NewLine; // 得意先掛率グループコード	

                    sqlText += "RATE.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "RATE.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "RATE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "RATE.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "RATE.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "RATE.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "RATE.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "RATE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "RATE.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "RATE.UNITRATESETDIVCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGGOODSCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGGOODSNMRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGCUSTCDRF," + Environment.NewLine;
                    sqlText += "RATE.RATEMNGCUSTNMRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSMAKERCDRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSRATERANKRF," + Environment.NewLine;
                    sqlText += "RATE.GOODSRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "RATE.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "RATE.UNPRCFRACPROCUNITRF," + Environment.NewLine;
                    sqlText += "RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;

                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   *  " + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "   RATERF " + Environment.NewLine;
                    sqlText += MakeWhereRateString(ref sqlCommand, rateWork, 0, logicalMode);
                    sqlText += " ) AS RATE -- 掛率マスタ" + Environment.NewLine;

                    // UPD 2010/08/27 --- >>>>
                    sqlText += "INNER JOIN" + Environment.NewLine;
                    sqlText += " GOODSURF AS PRM  -- 商品マスタ" + Environment.NewLine;
                    sqlText += "ON" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                    sqlText += "    AND PRM.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                    sqlText += "    AND PRM.GOODSNORF = RATE.GOODSNORF -- 商品番号" + Environment.NewLine;
                    sqlText += "    AND PRM.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;

                    sqlText += "LEFT JOIN" + Environment.NewLine;
                    sqlText += " BLGOODSCDURF AS BL -- BLコードマスタ" + Environment.NewLine;
                    sqlText += "ON PRM.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "AND PRM.BLGOODSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                    sqlText += "AND BL.LOGICALDELETECODERF=0" + Environment.NewLine;
                    // UPD 2010/08/27 --- <<<<
                }
                #endregion

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereRateSearchString(ref sqlCommand, rateWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRateSearchResultWorkFromReader(ref myReader));

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

            rateWorkList = al;

            return status;
        }

        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SingleGoodsRateSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SingleGoodsRateWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private SingleGoodsRateSearchResultWork CopyToRateSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            SingleGoodsRateSearchResultWork wkResultWork = new SingleGoodsRateSearchResultWork();

            #region クラスへ格納
            wkResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkResultWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkResultWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkResultWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkResultWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkResultWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkResultWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkResultWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkResultWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkResultWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkResultWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkResultWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkResultWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkResultWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

            wkResultWork.RatebLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
            wkResultWork.RatebLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            wkResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkResultWork.GoodsLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLOGICALDELETECODERF"));
            #endregion

            return wkResultWork;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// <br>Update Note: 2010/09/01 呉元嘯</br>
        /// <br>           : 明細のソート順が「品番・ﾒｰｶｰ順」にソートする</br>
        private string MakeWhereRateSearchString(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";
            string tableName = "";
            // UPD 2010/08/27 ---->>>>
            //if ("0".Equals(rateWork.ObjectDiv))
            //{
                tableName = "PRM.";
            //}
            //else
            //{
            //    tableName = "RATE.";

            //}
            // UPD 2010/08/27 ----<<<<
            //企業コード
            retstring += tableName + "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            if ("0".Equals(rateWork.ObjectDiv))
            {
                retstring += "AND " + tableName + "LOGICALDELETECODERF=0 " + Environment.NewLine;
            }
            else
            {
                //論理削除区分
                wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND " + tableName + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND " + tableName + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }
                if (wkstring != "")
                {
                    retstring += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
            }

            //品番
            if (!string.IsNullOrEmpty(rateWork.GoodsNo))
            {
                // UPD 2010/08/27 --------->>>>>
                //retstring += "AND " + tableName + " LIKE @FINDGOODSNO " + Environment.NewLine;
                //SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                //paraGoodsNo.Value = SqlDataMediator.SqlSetString(rateWork.GoodsNo + "%");

                int tempInt = rateWork.GoodsNo.Length;
                if ("*".Equals(rateWork.GoodsNo.Substring(tempInt - 1)))
                {
                    if (tempInt > 1)
                    {
                        string goodsNoStr = rateWork.GoodsNo.Substring(0, tempInt - 1);
                        retstring += "AND REPLACE(" + tableName + "GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoStr.Replace("-", "") + "%");
                    }
                }
                else
                {
                    retstring += "AND REPLACE(" + tableName + "GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(rateWork.GoodsNo.Replace("-", ""));
                }
                // UPD 2010/08/27 ---------<<<<<
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND "+ tableName + "GOODSMAKERCDRF =@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //BL商品コード
            if (rateWork.BlGoodsCode != 0)
            {
                retstring += "AND "+ tableName + "BLGOODSCODERF =@FINDBLGOODSCODE " + Environment.NewLine;
                SqlParameter paraGoodsCd = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraGoodsCd.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGoodsCode);
            }

            //BLグループコード
            if (rateWork.BlGroupCode != 0)
            {
                retstring += "AND BL.BLGROUPCODERF=@FINDBLGROUPCODE " + Environment.NewLine;
                SqlParameter paraBlGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBlGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGroupCode);
            }

            // --------ADD 2010/09/01---------->>>>>
            if ("0".Equals(rateWork.ObjectDiv))
            {
                tableName = "PRM.";
            }
            else if ("1".Equals(rateWork.ObjectDiv))
            {
                tableName = "RATE.";
            }
            retstring += " ORDER BY " + Environment.NewLine;
            retstring += tableName + "GOODSNORF, " + Environment.NewLine;
            retstring += tableName + "GOODSMAKERCDRF ASC " + Environment.NewLine;

            // --------ADD 2010/09/01----------<<<<<
            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private string MakeWhereRateString(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, int MakeMode, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE " + Environment.NewLine;

            //企業コード
            retstring += "ENTERPRISECODERF=@RATEENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@RATEENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@RATEFINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@RATEFINDLOGICALDELETECODE " + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@RATEFINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in rateWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                retstring += "AND SECTIONCODERF IN ('00') " + Environment.NewLine;
            }

            // 単価種類 
            retstring += "AND UNITPRICEKINDRF IN ('1', '3') ";

            if (MakeMode == 0)
            {
                // 得意先コード
                if (rateWork.CustomerCode != null)
                {
                    string CustomerCodeArystr = "";
                    foreach (int CustAry in rateWork.CustomerCode)
                    {
                        if (CustomerCodeArystr != "")
                        {
                            CustomerCodeArystr += ",";
                        }
                        CustomerCodeArystr += CustAry.ToString();
                    }
                    if (CustomerCodeArystr != "")
                    {
                        retstring += " AND ( CUSTOMERCODERF IN (" + CustomerCodeArystr + ") )" + Environment.NewLine;
                    }
                    retstring += Environment.NewLine;
                    // 掛率設定区分
                    retstring += "AND RATESETTINGDIVIDERF = '2A' ";
                }

                //得意先掛率グループコード
                else if (rateWork.CustRateGrpCode != null)
                {
                    string CustomerGrpCodeArystr = "";
                    foreach (int CustGrpAry in rateWork.CustRateGrpCode)
                    {
                        if (CustomerGrpCodeArystr != "")
                        {
                            CustomerGrpCodeArystr += ",";
                        }
                        CustomerGrpCodeArystr += CustGrpAry.ToString();
                    }
                    if (CustomerGrpCodeArystr != "")
                    {
                        //得意先掛率の未設定を抽出可能とする
                        retstring += " AND ( (CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr + ")  AND CUSTOMERCODERF=0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))" + Environment.NewLine;
                    }
                    // 掛率設定区分
                    if (!rateWork.UnSettingFlg)
                        retstring += "AND RATESETTINGDIVIDERF = '4A' ";
                    else
                        retstring += "AND RATESETTINGDIVIDERF IN ('6A', '4A') ";
                    retstring += Environment.NewLine;
                }
                else
                {
                    retstring += " AND ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF= 0 )" + Environment.NewLine;

                    // 掛率設定区分
                    retstring += "AND RATESETTINGDIVIDERF = '6A' ";
                    retstring += Environment.NewLine;
                }
                
            }
            return retstring;
        }

        #endregion

        #region [一括用削除処理( ロット数をKEY条件から除く )]
        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int DeleteRate(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRateSubSectionProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateDB.DeleteRate");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        public int DeleteRateSubSectionProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRateSubSectionProcProc(rateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率設定マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        private int DeleteRateSubSectionProcProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;
            command += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;
                    sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                    SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                    findParaGoodsNo.Value = rateWork.GoodsNo;
                    findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rateWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM RATERF" + Environment.NewLine;
                        sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                        sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                        findParaGoodsNo.Value = rateWork.GoodsNo;
                        findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion



        #region 単品売価　得意先引用登録
        #region [Write]
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rateCustomerWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        public int WriteCustomer(ref object rateCustomerWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                SingleGoodsRateSearchParamWork paraRateSearch = rateCustomerWork as SingleGoodsRateSearchParamWork;
                if (paraRateSearch == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList rateWorkList = null;

                status = SearchSubSectionProcProcCustomer(out rateWorkList, paraRateSearch, 0, 0, ref sqlConnection);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (rateWorkList.Count != 0))
                {
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    //write実行
                    status = WriteSubSectionProcCustomer(paraRateSearch, ref rateWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                else
                {
                    rateCustomerWork = null;
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SingleGoodsRateCustomerDB.WriteCustomer(ref object rateCustomerWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int WriteSubSectionProcCustomer(SingleGoodsRateSearchParamWork paraRateSearch, ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string command = string.Empty;
            command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;

                        for (int j = 1; j < paraRateSearch.CustomerCode.Length; j++)
                        {
                            if (paraRateSearch.CustomerCode[j] == 0) continue;

                            if (paraRateSearch.PrmSectionCode != null)
                            {
                                rateWork.SectionCode = paraRateSearch.PrmSectionCode[0];
                            }
                            else
                            {
                                rateWork.SectionCode = "00";
                            }

                            rateWork.CustomerCode = paraRateSearch.CustomerCode[j];

                            //Selectコマンドの生成
                            sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                            SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                            SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                            SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                int _logicaldeletecode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//論理削除
                                // 更新区分.更新
                                if ("1".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (_logicaldeletecode == 1)
                                    {
                                        if (myReader.IsClosed == false) myReader.Close();
                                        continue;
                                    }
                                }
                                // 更新区分.追加
                                else if ("0".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (_logicaldeletecode == 0)
                                    {
                                        if (myReader.IsClosed == false) myReader.Close();
                                        continue;
                                    }
                                }

                                ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                //if (_updateDateTime != rateWork.UpdateDateTime)
                                //{
                                //    //新規登録で該当データ有りの場合には重複
                                //    if (rateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //    //既存データで更新日時違いの場合には排他
                                //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                                findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                                findParaGoodsNo.Value = rateWork.GoodsNo;
                                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                                findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                // 更新区分.更新
                                if ("1".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (myReader.IsClosed == false) myReader.Close();
                                    continue;
                                }

                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                //if (rateWork.UpdateDateTime > DateTime.MinValue)
                                //{
                                //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                //新規作成時のSQL文を生成
                                sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;
                                sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                                sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            if (myReader.IsClosed == false) myReader.Close();

                            #region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                            SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                            SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                            SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                            SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                            SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                            SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                            SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            paraGoodsNo.Value = rateWork.GoodsNo;
                            paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                            paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                            paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                            paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                            paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(rateWork);
                        }
                    }
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int SearchSubSectionProcProcCustomer(out ArrayList rateWorkList, SingleGoodsRateSearchParamWork paraRateSearch, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                #region SELECT文作成
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                //商品ﾏｽﾀ.BL商品ｺｰﾄﾞ
                if (paraRateSearch.BlGoodsCode != 0 || paraRateSearch.BlGroupCode != 0)
                {
                    sqlTxt += "  ,GOODSURF AS GOODS " + Environment.NewLine;
                }

                //BL商品ｺｰﾄﾞﾏｽﾀ.BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                if (paraRateSearch.BlGroupCode != 0)
                {
                    sqlTxt += "  ,BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                }

                #endregion
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereStringCustomer(ref sqlCommand, paraRateSearch, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRateWorkFromReader(ref myReader));

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

            rateWorkList = al;

            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private string MakeWhereStringCustomer(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "RATE.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in rateWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND RATE.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                retstring += "AND RATE.SECTIONCODERF IN ('00') " + Environment.NewLine;
            }

            // 単価種類 
            retstring += "AND RATE.UNITPRICEKINDRF = '1' ";

            // 掛率設定区分
            retstring += "AND RATE.RATESETTINGDIVIDERF IN ('1A', '2A')";

            //得意先コード
            if (rateWork.CustomerCode.Length != 0)
            {
                retstring += "AND RATE.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode[0]);
            }

            //商品番号
            if (!string.IsNullOrEmpty(rateWork.GoodsNo))
            {
                // UPD 2010/08/27 --------->>>>>
                //retstring += "AND RATE.GOODSNORF LIKE '" + rateWork.GoodsNo + "%' ";

                int tempInt = rateWork.GoodsNo.Length;
                if ("*".Equals(rateWork.GoodsNo.Substring(tempInt - 1)))
                {
                    if (tempInt > 1)
                    {
                        string goodsNoStr = rateWork.GoodsNo.Substring(0, tempInt - 1);
                        retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoStr.Replace("-", "") + "%");
                    }
                }
                else
                {
                    retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(rateWork.GoodsNo.Replace("-", ""));
                }
                // UPD 2010/08/27 ---------<<<<<
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND RATE.GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品ﾏｽﾀ.BL商品コード
            if (rateWork.BlGoodsCode != 0 || rateWork.BlGroupCode != 0)
            {
                retstring += "AND RATE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF ";
                retstring += "AND RATE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF ";
                retstring += "AND RATE.LOGICALDELETECODERF=GOODS.LOGICALDELETECODERF ";
                retstring += "AND RATE.GOODSNORF=GOODS.GOODSNORF ";

                if (rateWork.BlGoodsCode != 0)
                {
                    retstring += "AND GOODS.BLGOODSCODERF=@FINDBLGOODSCODE ";
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGoodsCode);
                }
            }

            //BL商品ｺｰﾄﾞﾏｽﾀ.BLグループコード
            if (rateWork.BlGroupCode != 0)
            {
                retstring += "AND GOODS.ENTERPRISECODERF=BLGOODSCD.ENTERPRISECODERF ";
                retstring += "AND GOODS.BLGOODSCODERF=BLGOODSCD.BLGOODSCODERF ";
                retstring += "AND GOODS.LOGICALDELETECODERF=BLGOODSCD.LOGICALDELETECODERF ";

                retstring += "AND BLGOODSCD.BLGROUPCODERF=@FINDBLGROUPCODE ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGroupCode);
            }

            return retstring;
        }

        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private SingleGoodsRateSearchResultWork CopyToRateWorkFromReaderCustomer(ref SqlDataReader myReader)
        {
            SingleGoodsRateSearchResultWork wkRateWork = new SingleGoodsRateSearchResultWork();

            #region クラスへ格納
            wkRateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkRateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkRateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkRateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkRateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkRateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkRateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            wkRateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            wkRateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            wkRateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            wkRateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            wkRateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            wkRateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            wkRateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkRateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkRateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkRateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            wkRateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkRateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkRateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            wkRateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkRateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            wkRateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            wkRateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            wkRateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            wkRateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            wkRateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            wkRateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            #endregion

            return wkRateWork;
        }
        #endregion


        #endregion

        #region 単品売価　得意先掛率G引用登録
        #region [Write]
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rateCustomerWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        public int WriteCustomerGrp(out object retObj, ref object rateCustomerWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retObj = null;
            try
            {
                //パラメータのキャスト
                SingleGoodsRateSearchParamWork paraRateSearch = rateCustomerWork as SingleGoodsRateSearchParamWork;
                if (paraRateSearch == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList rateWorkList = null;
                retObj = null;

                status = SearchSubSectionProcProcCustomerGrp(out rateWorkList, paraRateSearch, 0, 0, ref sqlConnection);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (rateWorkList.Count != 0))
                {
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    //write実行
                    status = WriteSubSectionProcCustomer(out retObj, paraRateSearch, ref rateWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                retObj = new ArrayList(); 
                base.WriteErrorLog(ex, "SingleGoodsRateCustomerDB.WriteCustomer(ref object rateCustomerWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int WriteSubSectionProcCustomer(out object retObj,SingleGoodsRateSearchParamWork paraRateSearch, ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            ArrayList resultList = new ArrayList();
            retObj = null;

            string command = string.Empty;
            command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        SingleGoodsRateSearchResultWork rateSearchResultWork = rateWorkList[i] as SingleGoodsRateSearchResultWork;

                        for (int j = 1; j < paraRateSearch.CustRateGrpCode.Length; j++)
                        {
                            SingleGoodsRateSearchResultWork rateWork = new SingleGoodsRateSearchResultWork();

                            #region
                            rateWork.CreateDateTime = rateSearchResultWork.CreateDateTime;            // 作成日時
                            rateWork.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // 更新日時
                            rateWork.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // 企業コード
                            rateWork.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
                            rateWork.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // 更新従業員コード
                            rateWork.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // 更新アセンブリID1
                            rateWork.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // 更新アセンブリID2
                            rateWork.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // 論理削除区分
                            rateWork.SectionCode = rateSearchResultWork.SectionCode;                  // 拠点コード
                            rateWork.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // 単価掛率設定区分
                            rateWork.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // 単価種類
                            rateWork.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // 掛率設定区分
                            rateWork.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // 掛率設定区分（商品）
                            rateWork.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // 掛率設定名称（商品）
                            rateWork.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // 掛率設定区分（得意先）
                            rateWork.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // 掛率設定名称（得意先）
                            rateWork.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // 商品メーカーコード
                            rateWork.GoodsNo = rateSearchResultWork.GoodsNo;                          // 商品番号
                            rateWork.GoodsRateRank = rateSearchResultWork.GoodsRateRank;              // 商品掛率ランク
                            rateWork.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // 商品掛率グループコード
                            rateWork.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BLグループコード
                            rateWork.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL商品コード
                            rateWork.CustomerCode = rateSearchResultWork.CustomerCode;                // 得意先コード
                            rateWork.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // 得意先掛率グループコード
                            rateWork.SupplierCd = rateSearchResultWork.SupplierCd;                    // 仕入先コード
                            rateWork.LotCount = rateSearchResultWork.LotCount;                        // ロット数
                            rateWork.PriceFl = rateSearchResultWork.PriceFl;                          // 価格（浮動）
                            rateWork.RateVal = rateSearchResultWork.RateVal;                          // 掛率
                            rateWork.UpRate = rateSearchResultWork.UpRate;                            // UP率
                            rateWork.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // 粗利確保率
                            rateWork.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // 単価端数処理単位
                            rateWork.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // 単価端数処理区分
                            // 優良設定マスタ、商品管理情報マスタより取得
                            rateWork.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // 商品中分類コード
                            rateWork.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BLコード
                            rateWork.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL商品コード名称（半角）
                            rateWork.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // 部品メーカーコード
                            rateWork.MakerName = rateSearchResultWork.MakerName;                      // メーカー名称
                            rateWork.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // 仕入先コード

                            rateWork.ListPrice = rateSearchResultWork.ListPrice;          // 標準価格
                            rateWork.SalesUnitCost = rateSearchResultWork.SalesUnitCost;          // 原単価

                            rateWork.BfPriceFl = rateSearchResultWork.BfPriceFl;                          // 価格（浮動）
                            rateWork.BfRateVal = rateSearchResultWork.BfRateVal;                          // 掛率
                            rateWork.BfUpRate = rateSearchResultWork.BfUpRate;                            // UP率
                            rateWork.BfGrsProfitSecureRate = rateSearchResultWork.BfGrsProfitSecureRate;  // 粗利確保率
                            rateWork.UpdateDiv = rateSearchResultWork.UpdateDiv;
                            # endregion

                            if (paraRateSearch.CustRateGrpCode[j] == -1) continue;

                            if (paraRateSearch.PrmSectionCode != null)
                            {
                                rateWork.SectionCode = paraRateSearch.PrmSectionCode[0];
                            }
                            else
                            {
                                rateWork.SectionCode = "00";
                            }

                            rateWork.CustRateGrpCode = paraRateSearch.CustRateGrpCode[j];

                            rateWork.UpdateDiv = 0;

                            //Selectコマンドの生成
                            sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                            SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                            SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                            SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                int _logicaldeletecode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//論理削除
                                double _bfPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));//価格（浮動）
                                double _bfRateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));//掛率
                                double _bfUpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));//UP率
                                double _bfGrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));//粗利確保率

                                // 更新区分.更新
                                if ("1".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (_logicaldeletecode == 1)
                                    {
                                        if (myReader.IsClosed == false) myReader.Close();
                                        continue;
                                    }
                                }
                                // 更新区分.追加
                                else if ("0".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (_logicaldeletecode == 0)
                                    {
                                        rateWork.UpdateDiv = 1;
                                        resultList.Add(rateWork);

                                        if (myReader.IsClosed == false) myReader.Close();
                                        continue;
                                    }
                                }

                                ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                //if (_updateDateTime != rateWork.UpdateDateTime)
                                //{
                                //    //新規登録で該当データ有りの場合には重複
                                //    if (rateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //    //既存データで更新日時違いの場合には排他
                                //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                                findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                                findParaGoodsNo.Value = rateWork.GoodsNo;
                                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                                findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);

                                rateWork.BfPriceFl = _bfPriceFl;
                                rateWork.BfRateVal = _bfRateVal;
                                rateWork.BfUpRate = _bfUpRate;
                                rateWork.BfGrsProfitSecureRate = _bfGrsProfitSecureRate;

                                resultList.Add(rateWork);
                            }
                            else
                            {
                                // 更新区分.更新
                                if ("1".Equals(paraRateSearch.ObjectDiv))
                                {
                                    if (myReader.IsClosed == false) myReader.Close();
                                    continue;
                                }

                                ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                //if (rateWork.UpdateDateTime > DateTime.MinValue)
                                //{
                                //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                //新規作成時のSQL文を生成
                                sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;
                                sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                                sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            if (myReader.IsClosed == false) myReader.Close();

                            #region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                            SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                            SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                            SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                            SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                            SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                            SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                            SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rateWork.LogicalDeleteCode);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            paraGoodsNo.Value = rateWork.GoodsNo;
                            paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                            paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                            paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                            paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                            paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(rateWork);
                        }
                    }
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;
            retObj = resultList;

            return status;
        }
                #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int SearchSubSectionProcProcCustomerGrp(out ArrayList rateWorkList, SingleGoodsRateSearchParamWork paraRateSearch, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = string.Empty;
                #region SELECT文作成
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                //BL商品ｺｰﾄﾞﾏｽﾀ.BL商品ｺｰﾄﾞ
                if (paraRateSearch.BlGoodsCode != 0 || paraRateSearch.BlGroupCode != 0)
                {
                    sqlTxt += "  ,GOODSURF AS GOODS " + Environment.NewLine;
                }

                //商品ﾏｽﾀ.BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                if (paraRateSearch.BlGroupCode != 0)
                {
                    sqlTxt += "  ,BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                }

                #endregion
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereStringCustomerGrp(ref sqlCommand, paraRateSearch, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRateWorkFromReaderCustomer(ref myReader));

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

            rateWorkList = al;

            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private string MakeWhereStringCustomerGrp(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "RATE.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in rateWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND RATE.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                retstring += "AND RATE.SECTIONCODERF IN ('00') " + Environment.NewLine;
            }

            // 単価種類 
            retstring += "AND RATE.UNITPRICEKINDRF = '1' ";

            // 掛率設定区分
            retstring += "AND RATE.RATESETTINGDIVIDERF IN ('3A', '4A')";

            //得意先掛率コード
            if (rateWork.CustRateGrpCode.Length != 0)
            {
                retstring += "AND RATE.CUSTRATEGRPCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode[0]);
            }

            //商品番号
            if (!string.IsNullOrEmpty(rateWork.GoodsNo))
            {
                // UPD 2010/08/27 --------->>>>>
                //retstring += "AND RATE.GOODSNORF LIKE '" + rateWork.GoodsNo + "%' ";

                int tempInt = rateWork.GoodsNo.Length;
                if ("*".Equals(rateWork.GoodsNo.Substring(tempInt - 1)))
                {
                    if (tempInt > 1)
                    {
                        string goodsNoStr = rateWork.GoodsNo.Substring(0, tempInt - 1);
                        retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoStr.Replace("-", "") + "%");
                    }
                }
                else
                {
                    retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(rateWork.GoodsNo.Replace("-", ""));
                }
                // UPD 2010/08/27 ---------<<<<<
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND RATE.GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品ﾏｽﾀ.BL商品コード
            if (rateWork.BlGoodsCode != 0 || rateWork.BlGroupCode != 0)
            {
                retstring += "AND RATE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF ";
                retstring += "AND RATE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF ";
                retstring += "AND RATE.GOODSNORF=GOODS.GOODSNORF ";
                retstring += "AND RATE.LOGICALDELETECODERF=GOODS.LOGICALDELETECODERF ";

                if (rateWork.BlGoodsCode != 0)
                {
                    retstring += "AND GOODS.BLGOODSCODERF=@FINDBLGOODSCODE ";
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGoodsCode);
                }
            }

            //BL商品ｺｰﾄﾞﾏｽﾀ.BLグループコード
            if (rateWork.BlGroupCode != 0)
            {
                retstring += "AND GOODS.ENTERPRISECODERF=BLGOODSCD.ENTERPRISECODERF ";
                retstring += "AND GOODS.BLGOODSCODERF=BLGOODSCD.BLGOODSCODERF ";
                retstring += "AND GOODS.LOGICALDELETECODERF=BLGOODSCD.LOGICALDELETECODERF ";

                retstring += "AND BLGOODSCD.BLGROUPCODERF=@FINDBLGROUPCODE ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGroupCode);
            }

            return retstring;
        }

        #endregion
        
        #endregion


        #region 単品売価　一括削除処理
        #region [Write]
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rateCustomerWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        public int CustomerAllDelete(ref object rateCustomerWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                SingleGoodsRateSearchParamWork paraRateSearch = rateCustomerWork as SingleGoodsRateSearchParamWork;
                if (paraRateSearch == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                ArrayList rateWorkList = null;

                status = SearchSubSectionProcProcAllDelete(out rateWorkList, paraRateSearch, 0, 0, ref sqlConnection);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (rateWorkList.Count != 0))
                {
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    //write実行
                    status = WriteSubSectionProcAllDelete(paraRateSearch, ref rateWorkList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        sqlTransaction.Commit();
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                else
                {
                    rateCustomerWork = null;
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SingleGoodsRateCustomerDB.WriteCustomer(ref object rateCustomerWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int WriteSubSectionProcAllDelete(SingleGoodsRateSearchParamWork paraRateSearch, ref ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string command = string.Empty;
            command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM RATERF" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
            command += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
            command += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
            command += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
            command += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
            command += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
            command += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
            command += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
            command += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            command += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
            command += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
            command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        SingleGoodsRateWork rateWork = rateWorkList[i] as SingleGoodsRateWork;

                        //if ("0".Equals(paraRateSearch.RateMngCustCd))
                        //{
                        //    searchLength = paraRateSearch.CustomerCode.Length;
                        //}
                        //else if ("1".Equals(paraRateSearch.RateMngCustCd))
                        //{
                        //    searchLength = paraRateSearch.CustRateGrpCode.Length;
                        //}

                        //for (int j = 1; j < searchLength; j++)
                        //{
                        //    if ("0".Equals(paraRateSearch.RateMngCustCd))
                        //    {
                        //        if (paraRateSearch.CustomerCode[j] == 0) break;

                        //        //rateWork.CustomerCode = paraRateSearch.CustomerCode[j];
                        //    }
                        //    else if ("1".Equals(paraRateSearch.RateMngCustCd))
                        //    {
                        //        if (paraRateSearch.CustRateGrpCode[j] == -1) break;

                        //        //rateWork.CustRateGrpCode = paraRateSearch.CustRateGrpCode[j];
                        //    }

                            //Selectコマンドの生成
                            sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findParaUnitRateSetDivCd = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                            SqlParameter findParaGoodsRateRank = sqlCommand.Parameters.Add("@FINDGOODSRATERANK", SqlDbType.NChar);
                            SqlParameter findParaGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaCustRateGrpCode = sqlCommand.Parameters.Add("@FINDCUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                            SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            findParaGoodsNo.Value = rateWork.GoodsNo;
                            findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                //if (_updateDateTime != rateWork.UpdateDateTime)
                                //{
                                //    //新規登録で該当データ有りの場合には重複
                                //    if (rateWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //    //既存データで更新日時違いの場合には排他
                                //    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                sqlCommand.CommandText = "UPDATE RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITRATESETDIVCDRF=@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNITPRICEKINDRF=@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATESETTINGDIVIDERF=@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSCDRF=@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGGOODSNMRF=@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTCDRF=@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEMNGCUSTNMRF=@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += " , LOTCOUNTRF=@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += " , PRICEFLRF=@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += " , RATEVALRF=@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += " , UPRATERF=@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , GRSPROFITSECURERATERF=@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCUNITRF=@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += " , UNPRCFRACPROCDIVRF=@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATERANKRF=@FINDGOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;


                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                                findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                                findParaGoodsNo.Value = rateWork.GoodsNo;
                                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                                findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

                                //更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                ////既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                //if (rateWork.UpdateDateTime > DateTime.MinValue)
                                //{
                                //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                //    sqlCommand.Cancel();
                                //    if (myReader.IsClosed == false) myReader.Close();
                                //    return status;
                                //}

                                //新規作成時のSQL文を生成
                                sqlCommand.CommandText = "INSERT INTO RATERF" + Environment.NewLine;
                                sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SECTIONCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITRATESETDIVCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNITPRICEKINDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATESETTINGDIVIDERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGGOODSNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEMNGCUSTNMRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSNORF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATERANKRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GOODSRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGROUPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,BLGOODSCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,CUSTRATEGRPCODERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,LOTCOUNTRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,PRICEFLRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,RATEVALRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UPRATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,GRSPROFITSECURERATERF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCUNITRF" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,UNPRCFRACPROCDIVRF" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;
                                sqlCommand.CommandText += " VALUES" + Environment.NewLine;
                                sqlCommand.CommandText += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SECTIONCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITRATESETDIVCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNITPRICEKIND" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATESETTINGDIVIDE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGGOODSNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEMNGCUSTNM" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSNO" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATERANK" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGROUPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@BLGOODSCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@CUSTRATEGRPCODE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@SUPPLIERCD" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@LOTCOUNT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@PRICEFL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@RATEVAL" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UPRATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@GRSPROFITSECURERATE" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCUNIT" + Environment.NewLine;
                                sqlCommand.CommandText += "  ,@UNPRCFRACPROCDIV" + Environment.NewLine;
                                sqlCommand.CommandText += " )" + Environment.NewLine;

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)rateWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                            if (myReader.IsClosed == false) myReader.Close();

                            #region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            SqlParameter paraUnitRateSetDivCd = sqlCommand.Parameters.Add("@UNITRATESETDIVCD", SqlDbType.NChar);
                            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.NChar);
                            SqlParameter paraRateSettingDivide = sqlCommand.Parameters.Add("@RATESETTINGDIVIDE", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsCd = sqlCommand.Parameters.Add("@RATEMNGGOODSCD", SqlDbType.NChar);
                            SqlParameter paraRateMngGoodsNm = sqlCommand.Parameters.Add("@RATEMNGGOODSNM", SqlDbType.NVarChar);
                            SqlParameter paraRateMngCustCd = sqlCommand.Parameters.Add("@RATEMNGCUSTCD", SqlDbType.NChar);
                            SqlParameter paraRateMngCustNm = sqlCommand.Parameters.Add("@RATEMNGCUSTNM", SqlDbType.NVarChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                            SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraLotCount = sqlCommand.Parameters.Add("@LOTCOUNT", SqlDbType.Float);
                            SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@PRICEFL", SqlDbType.Float);
                            SqlParameter paraRateVal = sqlCommand.Parameters.Add("@RATEVAL", SqlDbType.Float);
                            SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);
                            SqlParameter paraGrsProfitSecureRate = sqlCommand.Parameters.Add("@GRSPROFITSECURERATE", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcUnit = sqlCommand.Parameters.Add("@UNPRCFRACPROCUNIT", SqlDbType.Float);
                            SqlParameter paraUnPrcFracProcDiv = sqlCommand.Parameters.Add("@UNPRCFRACPROCDIV", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクトへ値設定(更新用)
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rateWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rateWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rateWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rateWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);//論理削除
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(rateWork.SectionCode);
                            paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                            paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitPriceKind);
                            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rateWork.RateSettingDivide);
                            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsCd);
                            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngGoodsNm);
                            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustCd);
                            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rateWork.RateMngCustNm);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                            paraGoodsNo.Value = rateWork.GoodsNo;
                            paraGoodsRateRank.Value = rateWork.GoodsRateRank;
                            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                            paraLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                            paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rateWork.PriceFl);
                            paraRateVal.Value = SqlDataMediator.SqlSetDouble(rateWork.RateVal);
                            paraUpRate.Value = SqlDataMediator.SqlSetDouble(rateWork.UpRate);
                            paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rateWork.GrsProfitSecureRate);
                            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rateWork.UnPrcFracProcUnit);
                            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rateWork.UnPrcFracProcDiv);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(rateWork);
                        //}
                    }
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rateWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="rateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        private int SearchSubSectionProcProcAllDelete(out ArrayList rateWorkList, SingleGoodsRateSearchParamWork paraRateSearch, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            int length = 1;
            try
            {
                //ｸﾞﾙｰﾌﾟ設定
                if ("1".Equals(paraRateSearch.RateMngGoodsCd))
                {
                    #region ｸﾞﾙｰﾌﾟ設定 SELECT文作成
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                    sqlTxt += "FROM" + Environment.NewLine;
                    sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    sqlCommand.CommandText += MakeWhereStringAllDeleteExcept(ref sqlCommand, paraRateSearch, logicalMode);

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        al.Add(CopyToRateWorkFromReader(ref myReader));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
                //単品設定
                else if ("2".Equals(paraRateSearch.RateMngGoodsCd))
                {
                    if (paraRateSearch.UnSettingFlg == true)
                    {
                        length = 2;
                    }

                    for (int i = 0; i < length; i++)
                    {
                        if (paraRateSearch.UnSettingFlg == true && i == 1)
                        {
                            paraRateSearch.UnSettingFlg = false;
                            if (myReader.IsClosed == false) myReader.Close();
                        }

                        #region 単品設定 SELECT文作成
                        string sqlTxt = string.Empty;
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                        sqlTxt += "FROM" + Environment.NewLine;
                        sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                        //商品ﾏｽﾀ.BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                        if (paraRateSearch.BlGoodsCode != 0 || paraRateSearch.BlGroupCode != 0)
                        {
                            sqlTxt += "  ,GOODSURF AS GOODS " + Environment.NewLine;
                        }

                        //BL商品ｺｰﾄﾞﾏｽﾀ.BL商品ｺｰﾄﾞ
                        if (paraRateSearch.BlGroupCode != 0)
                        {
                            sqlTxt += "  ,BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                        }

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        sqlCommand.CommandText += MakeWhereStringAllDelete(ref sqlCommand, paraRateSearch, logicalMode);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            al.Add(CopyToRateWorkFromReader(ref myReader));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion
                    }
                }
                //全て
                else if ("0".Equals(paraRateSearch.RateMngGoodsCd))
                {
                    #region 全て SELECT文作成
                    #region ｸﾞﾙｰﾌﾟ設定 SELECT文作成
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT" + Environment.NewLine;
                    sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                    sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                    sqlTxt += "FROM" + Environment.NewLine;
                    sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                    paraRateSearch.RateMngGoodsCd = "1";
                    sqlCommand.CommandText += MakeWhereStringAllDeleteExcept(ref sqlCommand, paraRateSearch, logicalMode);

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        al.Add(CopyToRateWorkFromReader(ref myReader));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion

                    if (paraRateSearch.UnSettingFlg == true)
                    {
                        length = 2;
                    }

                    for (int i = 0; i < length; i++)
                    {
                        if (paraRateSearch.UnSettingFlg == true && i == 1)
                        {
                            paraRateSearch.UnSettingFlg = false;
                            if (myReader.IsClosed == false) myReader.Close();
                        }
                        else
                        {
                            if (myReader.IsClosed == false) myReader.Close();
                        }

                        #region 単品設定 SELECT文作成
                        sqlTxt = string.Empty;
                        sqlTxt += "SELECT" + Environment.NewLine;
                        sqlTxt += "   RATE.CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.SECTIONCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNITRATESETDIVCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNITPRICEKINDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATESETTINGDIVIDERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGGOODSCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGGOODSNMRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGCUSTCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEMNGCUSTNMRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSMAKERCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSNORF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSRATERANKRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GOODSRATEGRPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.BLGROUPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.BLGOODSCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.CUSTOMERCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.CUSTRATEGRPCODERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.SUPPLIERCDRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.LOTCOUNTRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.PRICEFLRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.RATEVALRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UPRATERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.GRSPROFITSECURERATERF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNPRCFRACPROCUNITRF" + Environment.NewLine;
                        sqlTxt += "   ,RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;

                        sqlTxt += "FROM" + Environment.NewLine;
                        sqlTxt += "  RATERF AS RATE " + Environment.NewLine;

                        //商品ﾏｽﾀ.BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
                        if (paraRateSearch.BlGoodsCode != 0 || paraRateSearch.BlGroupCode != 0)
                        {
                            sqlTxt += "  ,GOODSURF AS GOODS " + Environment.NewLine;
                        }

                        //BL商品ｺｰﾄﾞﾏｽﾀ.BL商品ｺｰﾄﾞ
                        if (paraRateSearch.BlGroupCode != 0)
                        {
                            sqlTxt += "  ,BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                        }

                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                        paraRateSearch.RateMngGoodsCd = "2";
                        sqlCommand.CommandText += MakeWhereStringAllDelete(ref sqlCommand, paraRateSearch, logicalMode);

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            al.Add(CopyToRateWorkFromReader(ref myReader));

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion
                    }
                    #endregion
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

            rateWorkList = al;

            return status;
        }

        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/02 楊明俊 #13972 「単品売価」「得意先掛率グループ」又は「全て」「得意先掛率グループ」で、未設定のみを指定して実行時、該当データなしとなる</br>
        private string MakeWhereStringAllDelete(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";
            bool joinstring = false;

            //企業コード
            retstring += "RATE.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in rateWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND RATE.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                retstring += "AND RATE.SECTIONCODERF IN ('00') " + Environment.NewLine;
            }

            // 単価種類 
            retstring += "AND RATE.UNITPRICEKINDRF = '1' ";

            // 掛率設定区分(商品)
            if (rateWork.UnSettingFlg == true)
            {
                retstring += "AND RATE.RATEMNGGOODSCDRF = 'A'";
            }
            else
            {
                if ("1".Equals(rateWork.RateMngGoodsCd))
                {
                    retstring += "AND RATE.RATEMNGGOODSCDRF <> 'A'";
                }
                else if ("2".Equals(rateWork.RateMngGoodsCd))
                {
                    retstring += "AND RATE.RATEMNGGOODSCDRF = 'A'";
                }
            }

            //掛率設定区分(得意先)
            if (rateWork.UnSettingFlg == false)
            {
                if ("0".Equals(rateWork.RateMngCustCd))
                {
                    //得意先
                    retstring += "AND RATE.RATEMNGCUSTCDRF IN ('1', '2')";

                    if (rateWork.CustomerCode.Length != 0)
                    {
                        retstring += "AND RATE.CUSTOMERCODERF IN ( ";
                        if (rateWork.CustomerCode[1] != 0)
                        {
                            joinstring = true;
                            retstring += rateWork.CustomerCode[1].ToString();
                        }
                        if (rateWork.CustomerCode[2] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[2].ToString();
                        }
                        if (rateWork.CustomerCode[3] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[3].ToString();
                        }
                        if (rateWork.CustomerCode[4] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[4].ToString();
                        }
                        if (rateWork.CustomerCode[5] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[5].ToString();
                        }

                        retstring += " )";
                    }
                }
                else if ("1".Equals(rateWork.RateMngCustCd))
                {
                    //得意先掛率Ｇ
                    retstring += "AND RATE.RATEMNGCUSTCDRF IN ('3', '4')";

                    if (rateWork.CustRateGrpCode.Length != 0)
                    {
                        //-----ADD 2010/09/02----------->>>>>
                        if (rateWork.CustRateGrpCode[1] >= 0
                            || rateWork.CustRateGrpCode[2] >= 0
                            || rateWork.CustRateGrpCode[3] >= 0
                            || rateWork.CustRateGrpCode[4] >= 0
                            || rateWork.CustRateGrpCode[5] >= 0)
                        {
                        //-----ADD 2010/09/02-----------<<<<<
                            retstring += "AND RATE.CUSTRATEGRPCODERF IN (";
                            if (rateWork.CustRateGrpCode[1] >= 0)
                            {
                                joinstring = true;
                                retstring += rateWork.CustRateGrpCode[1].ToString();
                            }
                            if (rateWork.CustRateGrpCode[2] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[2].ToString();
                            }
                            if (rateWork.CustRateGrpCode[3] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[3].ToString();
                            }
                            if (rateWork.CustRateGrpCode[4] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[4].ToString();
                            }
                            if (rateWork.CustRateGrpCode[5] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[5].ToString();
                            }

                            retstring += " )";
                        //-----ADD 2010/09/02----------->>>>>
                        }
                        //-----ADD 2010/09/02-----------<<<<<
                    }

                }
            }
            else
            {
                retstring += "AND RATE.RATEMNGCUSTCDRF = '6'";
            }

            //商品番号
            if (!string.IsNullOrEmpty(rateWork.GoodsNo))
            {
                // UPD 2010/08/27 --------->>>>>
                //retstring += "AND RATE.GOODSNORF LIKE '" + rateWork.GoodsNo + "%' ";

                int tempInt = rateWork.GoodsNo.Length;
                if ("*".Equals(rateWork.GoodsNo.Substring(tempInt - 1)))
                {
                    if (tempInt > 1)
                    {
                        string goodsNoStr = rateWork.GoodsNo.Substring(0, tempInt - 1);
                        retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNoStr.Replace("-", "") + "%");
                    }
                }
                else
                {
                    retstring += "AND REPLACE(RATE.GOODSNORF, '-', '') LIKE @FINDGOODSNO " + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(rateWork.GoodsNo.Replace("-", ""));
                }
                // UPD 2010/08/27 ---------<<<<<
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND RATE.GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
            }

            //商品ﾏｽﾀ.BL商品コード
            if (rateWork.BlGoodsCode != 0 || rateWork.BlGroupCode != 0)
            {
                retstring += "AND RATE.ENTERPRISECODERF=GOODS.ENTERPRISECODERF ";
                retstring += "AND RATE.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF ";
                retstring += "AND RATE.GOODSNORF=GOODS.GOODSNORF ";
                retstring += "AND RATE.LOGICALDELETECODERF=GOODS.LOGICALDELETECODERF ";

                if (rateWork.BlGoodsCode != 0)
                {
                    retstring += "AND GOODS.BLGOODSCODERF=@FINDBLGOODSCODE ";
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGoodsCode);
                }
            }

            //BL商品ｺｰﾄﾞﾏｽﾀ.BLグループコード
            if (rateWork.BlGroupCode != 0)
            {
                retstring += "AND GOODS.ENTERPRISECODERF=BLGOODSCD.ENTERPRISECODERF ";
                retstring += "AND GOODS.BLGOODSCODERF=BLGOODSCD.BLGOODSCODERF ";
                retstring += "AND GOODS.LOGICALDELETECODERF=BLGOODSCD.LOGICALDELETECODERF ";

                retstring += "AND BLGOODSCD.BLGROUPCODERF=@FINDBLGROUPCODE ";
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BlGroupCode);
            }

            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// <br>Update Note : 2010/09/02 楊明俊 #13972 「単品売価」「得意先掛率グループ」又は「全て」「得意先掛率グループ」で、未設定のみを指定して実行時、該当データなしとなる</br>
        private string MakeWhereStringAllDeleteExcept(ref SqlCommand sqlCommand, SingleGoodsRateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";
            bool joinstring = false;

            //企業コード
            retstring += "RATE.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND RATE.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (rateWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in rateWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retstring += "AND RATE.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                retstring += "AND RATE.SECTIONCODERF IN ('00') " + Environment.NewLine;
            }

            // 単価種類 
            retstring += "AND RATE.UNITPRICEKINDRF = '1' ";

            // 掛率設定区分(商品)
            if ("1".Equals(rateWork.RateMngGoodsCd))
            {
                retstring += "AND RATE.RATEMNGGOODSCDRF <> 'A'";
            }
            else if ("2".Equals(rateWork.RateMngGoodsCd))
            {
                retstring += "AND RATE.RATEMNGGOODSCDRF = 'A'";
            }

            //掛率設定区分(得意先)
                if ("0".Equals(rateWork.RateMngCustCd))
                {
                    //得意先
                    retstring += "AND RATE.RATEMNGCUSTCDRF IN ('1', '2')";

                    if (rateWork.CustomerCode.Length != 0)
                    {
                        retstring += "AND RATE.CUSTOMERCODERF IN ( ";
                        if (rateWork.CustomerCode[1] != 0)
                        {
                            joinstring = true;
                            retstring += rateWork.CustomerCode[1].ToString();
                        }
                        if (rateWork.CustomerCode[2] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[2].ToString();
                        }
                        if (rateWork.CustomerCode[3] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[3].ToString();
                        }
                        if (rateWork.CustomerCode[4] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[4].ToString();
                        }
                        if (rateWork.CustomerCode[5] != 0)
                        {
                            if (joinstring == true)
                            {
                                retstring += ",";
                            }
                            else
                            {
                                joinstring = true;
                            }

                            retstring += rateWork.CustomerCode[5].ToString();
                        }

                        retstring += " )";
                    }
                }
                else if ("1".Equals(rateWork.RateMngCustCd))
                {
                    //得意先掛率Ｇ
                    retstring += "AND RATE.RATEMNGCUSTCDRF IN ('3', '4')";

                    if (rateWork.CustRateGrpCode.Length != 0)
                    {
                        //-----ADD 2010/09/02----------->>>>>
                        if (rateWork.CustRateGrpCode[1] >= 0 
                            || rateWork.CustRateGrpCode[2] >= 0
                            || rateWork.CustRateGrpCode[3] >= 0
                            || rateWork.CustRateGrpCode[4] >= 0
                            || rateWork.CustRateGrpCode[5] >= 0)
                        {
                        //-----ADD 2010/09/02-----------<<<<<
                            retstring += "AND RATE.CUSTRATEGRPCODERF IN (";
                            if (rateWork.CustRateGrpCode[1] >= 0)
                            {
                                joinstring = true;
                                retstring += rateWork.CustRateGrpCode[1].ToString();
                            }
                            if (rateWork.CustRateGrpCode[2] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[2].ToString();
                            }
                            if (rateWork.CustRateGrpCode[3] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[3].ToString();
                            }
                            if (rateWork.CustRateGrpCode[4] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[4].ToString();
                            }
                            if (rateWork.CustRateGrpCode[5] >= 0)
                            {
                                if (joinstring == true)
                                {
                                    retstring += ",";
                                }
                                else
                                {
                                    joinstring = true;
                                }

                                retstring += rateWork.CustRateGrpCode[5].ToString();
                            }

                            retstring += " )";
                        //-----ADD 2010/09/02----------->>>>>
                        }
                        //-----ADD 2010/09/02----------->>>>>
                    }

                }
            return retstring;
        }

        #endregion

        #endregion



    }
}