//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：caohh
// 修正日    2013/02/19     修正内容：新規作成
// ---------------------------------------------------------------------//
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
    /// 掛率一括登録・修正ⅡメンテナンスDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率一括登録・修正Ⅱの実データ操作を行うクラスです。</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// </remarks>
    [Serializable]
    public class Rate2DB : RemoteDB, IRate2DB
    {
        /// <summary>
        /// 掛率一括登録・修正ⅡメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : caohh</br>														   
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        public Rate2DB()
            :
        base("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work", "RATERF")
        {
        }        

        #region [Write]
        /// <summary>
        /// 掛率マスタ情報を登録、更新します
        /// </summary>
        /// <param name="rate2Work">Rate2Workオブジェクト</param>
        /// <param name="eFlag">新追加行フラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ情報を登録、更新します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        public int Write(ref object rate2Work, bool eFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(rate2Work);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSubSectionProc(ref paraList, eFlag, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                rate2Work = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.Write(ref object rate2Work)");
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
        /// 掛率マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">Rate2Workオブジェクト</param>
        /// <param name="eFlag">新追加行フラグ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        public int WriteSubSectionProc(ref ArrayList rateWorkList, bool eFlag, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateWriteList = null;
            ArrayList rateDeleteList = null;

            if (rateWorkList != null)
            {
                CreateRateWriteDelList(rateWorkList, out rateWriteList, out rateDeleteList);

                if (rateWriteList.Count != 0)
                {
                    status = this.WriteSubSectionProcProc(ref rateWriteList, eFlag, ref sqlConnection, ref sqlTransaction);
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
        /// <returns>STATUS</returns>
        private int CreateRateWriteDelList(ArrayList rateWorkList, out ArrayList rateWriteList, out ArrayList rateDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            rateWriteList = new ArrayList();
            rateDeleteList = new ArrayList();

            foreach (Rate2Work rate2Work in rateWorkList)
            {
                if (rate2Work.LogicalDeleteCode == 3)
                {
                    //削除用リスト作成
                    rateDeleteList.Add(rate2Work);
                }
                else
                {
                    //更新用リスト作成
                    rateWriteList.Add(rate2Work);
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 掛率マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">Rate2Workオブジェクト</param>
        /// <param name="eFlag">新追加行フラグ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
		private int WriteSubSectionProcProc(ref ArrayList rateWorkList, bool eFlag, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            StringBuilder sqlText = new StringBuilder();
            sqlText.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, LOGICALDELETECODERF FROM RATERF").Append(Environment.NewLine);
            sqlText.Append("WHERE").Append(Environment.NewLine);
            sqlText.Append("  ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
            sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
            sqlText.Append("  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSNORF=@FINDGOODSNO").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSRATERANKRF=@FINDGOODSRATERANK").Append(Environment.NewLine);
            sqlText.Append("  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND BLGROUPCODERF=@FINDBLGROUPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTOMERCODERF=@FINDCUSTOMERCODE").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE").Append(Environment.NewLine);
            sqlText.Append("  AND SUPPLIERCDRF=@FINDSUPPLIERCD").Append(Environment.NewLine);
            sqlText.Append("  AND LOTCOUNTRF=@FINDLOTCOUNT").Append(Environment.NewLine);
            
            try
            {
                if (rateWorkList != null)
                {
                    for (int i = 0; i < rateWorkList.Count; i++)
                    {
                        Rate2Work rate2Work = rateWorkList[i] as Rate2Work;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

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
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            if (eFlag)
                            {
                                //既存GUIDデータがある場合で追加行の作成日時と更新日時とGUIDをセットする
                                rate2Work.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//作成日時
                                rate2Work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                rate2Work.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                            }

                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != rate2Work.UpdateDateTime)
                            {
                                int _logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                                if (_logicalDeleteCode == 0)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    if (rate2Work.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    //既存データで更新日時違いの場合には排他
                                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                }
                                
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
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                            findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                            findParaGoodsNo.Value = rate2Work.GoodsNo;
                            findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                            findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                            findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                            findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                            findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rate2Work;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (rate2Work.UpdateDateTime > DateTime.MinValue)
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
                            IFileHeader flhd = (IFileHeader)rate2Work;
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
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rate2Work.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rate2Work.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rate2Work.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rate2Work.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rate2Work.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rate2Work.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rate2Work.UnitPriceKind);
                        paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(rate2Work.RateSettingDivide);
                        paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngGoodsCd);
                        paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngGoodsNm);
                        paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngCustCd);
                        paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(rate2Work.RateMngCustNm);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        paraGoodsNo.Value = rate2Work.GoodsNo;
                        paraGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        paraLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);
                        paraPriceFl.Value = SqlDataMediator.SqlSetDouble(rate2Work.PriceFl);
                        paraRateVal.Value = SqlDataMediator.SqlSetDouble(rate2Work.RateVal);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(rate2Work.UpRate);
                        paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(rate2Work.GrsProfitSecureRate);
                        paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(rate2Work.UnPrcFracProcUnit);
                        paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(rate2Work.UnPrcFracProcDiv);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(rate2Work);
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

        /// <summary>
        /// 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        private int DeleteSubSectionProcProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder command = new StringBuilder();
            command.Append ("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM RATERF" ).Append( Environment.NewLine);
            command.Append ("WHERE" ).Append( Environment.NewLine);
            command.Append ("  ENTERPRISECODERF=@FINDENTERPRISECODE" ).Append( Environment.NewLine);
            command.Append ("  AND SECTIONCODERF=@FINDSECTIONCODE" ).Append( Environment.NewLine);
            command.Append ("  AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSNORF=@FINDGOODSNO" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSRATERANKRF=@FINDGOODSRATERANK" ).Append( Environment.NewLine);
            command.Append ("  AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND BLGROUPCODERF=@FINDBLGROUPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND BLGOODSCODERF=@FINDBLGOODSCODE" ).Append( Environment.NewLine);
            command.Append ("  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" ).Append( Environment.NewLine);
            command.Append ("  AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE" ).Append( Environment.NewLine);
            command.Append ("  AND SUPPLIERCDRF=@FINDSUPPLIERCD" ).Append( Environment.NewLine);
            command.Append ("  AND LOTCOUNTRF=@FINDLOTCOUNT" ).Append( Environment.NewLine);
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    Rate2Work rate2Work = rateWorkList[i] as Rate2Work;
                    sqlCommand = new SqlCommand(command.ToString(), sqlConnection, sqlTransaction);

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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                    findParaGoodsNo.Value = rate2Work.GoodsNo;
                    findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                    findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rate2Work.UpdateDateTime)
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
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
                        findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rate2Work.LotCount);
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
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
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

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            Rate2Work[] RateWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is Rate2Work)
                    {
                        Rate2Work wkRateWork = paraobj as Rate2Work;
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
                            RateWorkArray = (Rate2Work[])XmlByteSerializer.Deserialize(byteArray, typeof(Rate2Work[]));
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
                                Rate2Work wkRateWork = (Rate2Work)XmlByteSerializer.Deserialize(byteArray, typeof(Rate2Work));
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

        #region [一括用削除処理( ロット数をKEY条件から除く )]
        /// <summary>
        /// 掛率マスタ戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">掛率マスタ戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタ戻りデータ情報を物理削除します</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
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
                base.WriteErrorLog(ex, "Rate2DB.DeleteRate");
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
        /// 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19<</br>
        public int DeleteRateSubSectionProc(ArrayList rateWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRateSubSectionProcProc(rateWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">掛率マスタ戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタ戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19<</br>
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
                    Rate2Work rate2Work = rateWorkList[i] as Rate2Work;
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
                    //SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                    findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                    findParaGoodsNo.Value = rate2Work.GoodsNo;
                    findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                    findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                    findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != rate2Work.UpdateDateTime)
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
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rate2Work.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(rate2Work.SectionCode);
                        findParaUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(rate2Work.UnitRateSetDivCd);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsMakerCd);
                        findParaGoodsNo.Value = rate2Work.GoodsNo;
                        findParaGoodsRateRank.Value = rate2Work.GoodsRateRank;
                        findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.GoodsRateGrpCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.BLGoodsCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustomerCode);
                        findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rate2Work.CustRateGrpCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rate2Work.SupplierCd);
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

        #region ★純正データの掛率一括検索処理
        #region ●指定された条件の純正掛率設定マスタ戻りデータ情報LISTを戻します
        /// <summary>
        /// 純正データの掛率一括検索処理
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="rateParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2013/03/01</br>
        public int SearchPureRate(out object retGoodsMngList, out object retRateList,
            object rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retGoodsMngList = null;
            retRateList = null;
            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPureRateProc(out retGoodsMngList, out retRateList,
                    paraWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPureRate");
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();
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
        #endregion  ●指定された条件の純正掛率設定マスタ戻りデータ情報LISTを戻します

        #region ◎純正データ相関商品管理情報と掛率情報取得処理
        /// <summary>
        /// 純正データ相関商品管理情報と掛率情報取得処理
        /// </summary>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 純正データ相関商品管理情報と掛率情報取得処理</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPureRateProc(out object retGoodsMngList, out object retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode, 
            ref SqlConnection sqlConnection)
        {
            StringBuilder sqlText = new StringBuilder();
            ArrayList tempGoodsMngList = new ArrayList(); // 商品管理情報マスタ情報リスト
            ArrayList tempRateList = new ArrayList();     // 掛率マスタ情報リスト

            // 商品管理情報検索
            int status1 = SearchGoodsMngSubProc(ref tempGoodsMngList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // 掛率情報検索
            int status2 = SearchRateSubProc(ref tempRateList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // エラーが発生の場合、ステータス戻る
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status1;
            }

            // エラーが発生の場合、ステータス戻る
            if ((status2 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {

                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status2;
            }

            // 検索しないの場合、ステータス戻る
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                &&(status2 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                

                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            retGoodsMngList = tempGoodsMngList;
            retRateList = tempRateList;
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion ◎純正データ相関商品管理情報と掛率情報取得処理

        #region ◎純正データの商品管理情報取得
        /// <summary>
        /// 純正データの商品管理情報取得
        /// </summary>
        /// <param name="retRateList">商品管理情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 純正データの商品管理情報取得</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchGoodsMngSubProc(ref ArrayList retGoodsMngList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    SUPPLIERCDRF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMNGRF ").Append(Environment.NewLine);
                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, rateParamWork, 1, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retGoodsMngList.Add(CopyToPureSearchResultWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


            }
            catch (SqlException ex)
            {
                //　基底クラスに例外を渡して処理してもらう
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
        #endregion ◎純正データの商品管理情報取得

        #region ◎純正データの掛率情報取得
        /// <summary>
        /// 純正データの掛率情報取得
        /// </summary>
        /// <param name="retRateList">純正データの掛率情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 純正データの掛率情報取得</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/01</br>
        private int SearchRateSubProc(ref ArrayList retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);

                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, rateParamWork, 0, logicalMode)).Append(Environment.NewLine);
                #endregion WHERE文字列

                #endregion Select文作成

                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retRateList.Add(CopyToRate2WorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


            }
            catch (SqlException ex)
            {
                //　基底クラスに例外を渡して処理してもらう
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
        #endregion ◎純正データの掛率情報取得
        /// <summary>
        /// 純正用検索条件設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="selectDiv">区分掛率マスタ検索と商品管理情報マスタ検索 0: 掛率マスタ検索　1: 商品管理情報マスタ検索</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : 純正用検索条件設定</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPureCommon(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, 
            　　　　　　　　　　　　　　　　　　int selectDiv, 
            　　　　　　　　　　　　　　　　　　ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    ENTERPRISECODERF=@FINDENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点コード
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // 全社指定の場合、ログイン拠点を参照
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }


            // 商品メーカーコード
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND GOODSMAKERCDRF =@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }

            // 品番
            retstring.Append("    AND GOODSNORF = '' ").Append(Environment.NewLine);
            // selectDiv=0: 掛率マスタ検索　selectDiv=1: 商品管理情報マスタ検索
            if (selectDiv == 0)
            {
                // 仕入先コード
                if (paraWork.SupplierCd != 0)
                {
                    retstring.Append("    AND SUPPLIERCDRF=@FINDSUPPLIERCD ").Append(Environment.NewLine);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
                }
                // 得意先コード
                if (paraWork.CustomerCode != null)
                {
                    string CustomerCodeArystr = "";

                    foreach (int CustAry in paraWork.CustomerCode)
                    {
                        if (CustomerCodeArystr != "")
                        {
                            CustomerCodeArystr += ",";
                        }
                        CustomerCodeArystr += CustAry.ToString();
                    }
                    if (CustomerCodeArystr != "")
                    {
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  )AND CUSTOMERCODERF IN (" + CustomerCodeArystr
                                         + ") )AND CUSTRATEGRPCODERF = 0) OR (UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF = 0 ))");
                    }
                    retstring.Append(Environment.NewLine);
                }

                // 得意先掛率グループコード
                if (paraWork.CustRateGrpCode != null)
                {
                    string CustomerGrpCodeArystr = "";
                    foreach (int CustGrpAry in paraWork.CustRateGrpCode)
                    {
                        if (CustomerGrpCodeArystr != "")
                        {
                            CustomerGrpCodeArystr += ",";
                        }
                        CustomerGrpCodeArystr += CustGrpAry.ToString();
                    }
                    if (CustomerGrpCodeArystr != "")
                    {
                        // 得意先掛率の未設定を抽出可能とする
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  ) AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr
                                         + "))  AND CUSTOMERCODERF = 0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))");
                    }
                    retstring.Append(Environment.NewLine);
                }
            }
            
            return retstring.ToString();
        }

        /// <summary>
        /// クラス格納処理 Reader → Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>商品管理情報マスタに取得データ</returns>
        /// <br>Note       : クラス格納処理　Reader → Rate2SearchResultWork</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPureSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

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
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.GoodsSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → Rate2Work
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>掛率マスタに検索取得データ</returns>
        /// <br>Note       : クラス格納処理　クラス格納処理 Reader → Rate2Work</br>
        /// <br>Programmer : 董桂鈺</br>
        /// <br>Date       : 2013/03/01</br>
        private Rate2Work CopyToRate2WorkFromReader(ref SqlDataReader myReader)
        {
            Rate2Work wkResultWork = new Rate2Work();

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
            #endregion

            return wkResultWork;
        }
        #endregion ★純正データの場合、商品管理情報と掛率情報取得処理

        #region ★優良データの掛率一括検索処理
        #region ●指定された条件の優良掛率設定マスタ戻りデータ情報LISTを戻します
        /// <summary>
        /// 優良データの掛率一括検索処理
        /// </summary>
        /// <param name="retPrmSettingList">優良設定情報リスト</param>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="rateParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Date       : 2013/03/01</br>
        public int SearchPrmRate(out object retPrmSettingList, out object retGoodsMngList, out object retRateList,
            object rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            retPrmSettingList = null;
            retGoodsMngList = null;
            retRateList = null;

            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchPrmRateProc(out retPrmSettingList, out retGoodsMngList, out retRateList,
                    paraWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPrmRate");

                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

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
        #endregion  ●指定された条件の優良掛率設定マスタ戻りデータ情報LISTを戻します

        #region ◎優良データ相関商品管理情報と掛率情報取得処理
        /// <summary>
        /// 優良データ相関商品管理情報と掛率情報取得処理
        /// </summary>
        /// <param name="retPrmSettingList">優良設定情報リスト</param>
        /// <param name="retGoodsMngList">商品管理情報リスト</param>
        /// <param name="retRateList">掛率情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPrmRateProc(out object retPrmSettingList, out object retGoodsMngList, out object retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            StringBuilder sqlText = new StringBuilder();
            ArrayList tempPrmSettingList = new ArrayList(); // 優良設定マスタ情報リスト
            ArrayList tempGoodsMngList = new ArrayList(); // 商品管理情報マスタ情報リスト
            ArrayList tempRateList = new ArrayList();     // 掛率マスタ情報リスト

            // 優良設定情報検索
            int status = SearchPrmSettingSubProc(ref tempPrmSettingList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // 商品管理情報検索
            int status1 = SearchGoodsMngSubProc1(ref tempGoodsMngList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // 掛率情報検索
            int status2 = SearchRateSubProc1(ref tempRateList,
                    rateParamWork, readMode, logicalMode,
            ref sqlConnection);

            // エラーが発生の場合、ステータス戻る
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status;
            }

            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status1 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status1;
            }

            // エラーが発生の場合、ステータス戻る
            if ((status2 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (status2 != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return status2;
            }

            // 検索しないの場合、ステータス戻る
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status2 == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                retPrmSettingList = new ArrayList();
                retGoodsMngList = new ArrayList();
                retRateList = new ArrayList();

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            retPrmSettingList = tempPrmSettingList;
            retGoodsMngList = tempGoodsMngList;
            retRateList = tempRateList;

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion ◎優良データ相関商品管理情報と掛率情報取得処理

        #region ◎優良設定情報取得
        /// <summary>
        /// 優良設定情報取得
        /// </summary>
        /// <param name="retPrmSettingList">優良設定情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchPrmSettingSubProc(ref ArrayList retPrmSettingList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    PRM.CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.TBSPARTSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    PRM.PARTSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODS.BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODS.BLGOODSHALFNAMERF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    PRMSETTINGURF AS PRM WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append(" LEFT JOIN BLGOODSCDURF AS GOODS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("    ON PRM.ENTERPRISECODERF = GOODS.ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("    AND PRM.TBSPARTSCODERF = GOODS.BLGOODSCODERF ").Append(Environment.NewLine);

                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPrm(ref sqlCommand, rateParamWork, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retPrmSettingList.Add(CopyToPrmSettingWorkFromReader(ref myReader));

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
        #endregion ◎優良設定情報取得

        #region ◎優良データの商品管理情報取得
        /// <summary>
        /// 優良データの商品管理情報取得
        /// </summary>
        /// <param name="retRateList">商品管理情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchGoodsMngSubProc1(ref ArrayList retGoodsMngList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("    CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("    ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDEMPLOYEECODERF,").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("    UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("    LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("    SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMGROUPRF, ").Append(Environment.NewLine);
                sqlText.Append("    BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("    SUPPLIERCDRF ").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("    GOODSMNGRF ").Append(Environment.NewLine);
                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPrmCommon(ref sqlCommand, rateParamWork, 1, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retGoodsMngList.Add(CopyToPrmSearchResultWorkFromReader(ref myReader));

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
        #endregion ◎優良データの商品管理情報取得

        #region ◎優良データの掛率情報取得
        /// <summary>
        /// 優良データの掛率情報取得
        /// </summary>
        /// <param name="retRateList">優良データの掛率情報リスト</param>
        /// <param name="rateParamWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Date       : 2013/03/01</br>
        private int SearchRateSubProc1(ref ArrayList retRateList,
                    Rate2ParamWork rateParamWork, int readMode, ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);
                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPrmCommon(ref sqlCommand, rateParamWork, 0, logicalMode)).Append(Environment.NewLine);
                #endregion
                #endregion
                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retRateList.Add(CopyToPrmRate2WorkFromReader(ref myReader));

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
        #endregion ◎優良データの掛率情報取得

        /// <summary>
        /// 優良用検索条件設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="selectDiv">区分掛率マスタ検索と商品管理情報マスタ検索 0: 掛率マスタ検索　1: 商品管理情報マスタ検索</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPrm(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    PRM.ENTERPRISECODERF=@FINDPRMENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDPRMENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND PRM.LOGICALDELETECODERF=@FINDPRMLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND PRM.LOGICALDELETECODERF<@FINDPRMLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDPRMLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND PRM.SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // 全社指定の場合、ログイン拠点を参照
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND PRM.SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }

            //商品メーカーコード
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND PRM.PARTSMAKERCDRF =@FINDPRMPARTSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@FINDPRMPARTSMAKERCD", SqlDbType.Int);
                paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }
            else
            {
                retstring.Append("    AND (PRM.PARTSMAKERCDRF > @FINDPRMPARTSMAKERCD OR PRM.PARTSMAKERCDRF = @FINDPRMPARTSMAKERCD)").Append(Environment.NewLine);
                SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@FINDPRMPARTSMAKERCD", SqlDbType.Int);
                paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);
            }

            return retstring.ToString();
        }

        /// <summary>
        /// 優良用検索条件設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="selectDiv">区分掛率マスタ検索と商品管理情報マスタ検索 0: 掛率マスタ検索　1: 商品管理情報マスタ検索</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Date       : 2013/03/01</br>
        private string MakeWhereSearchPrmCommon(ref SqlCommand sqlCommand, Rate2ParamWork paraWork, int selectDiv, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE").Append(Environment.NewLine);
            StringBuilder wkstring = new StringBuilder();
            retstring.Append("    ENTERPRISECODERF=@FINDENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring.Append("    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring.Append("    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
            }
            if (!wkstring.Equals(string.Empty))
            {
                retstring.Append(wkstring);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (paraWork.SectionCode != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCode)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    if (sectionString != "'00'")
                    {
                        sectionString += ",'00'";
                    }
                    retstring.Append("    AND SECTIONCODERF IN (" + sectionString + ") ").Append(Environment.NewLine);
                }
            }
            else
            {
                // 全社指定の場合、ログイン拠点を参照
                if (paraWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in paraWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring.Append("    AND SECTIONCODERF IN (" + prmsectionString + ") ").Append(Environment.NewLine);
                    }
                }

            }

            //商品メーカーコード
            if (paraWork.GoodsMakerCd != 0)
            {
                retstring.Append("    AND GOODSMAKERCDRF =@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsMakerCd);
            }
            else
            {
                retstring.Append("    AND (GOODSMAKERCDRF >@FINDGOODSMAKERCD OR GOODSMAKERCDRF =@FINDGOODSMAKERCD)").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(1000);
            }

            //品番
            retstring.Append("    AND GOODSNORF = '' ").Append(Environment.NewLine);

            //仕入先コード
            if (paraWork.SupplierCd != 0)
            {
                retstring.Append("    AND SUPPLIERCDRF=@FINDSUPPLIERCD ").Append(Environment.NewLine);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.SupplierCd);
            }

            // selectDiv=0: 掛率マスタ検索　selectDiv=1: 商品管理情報マスタ検索
            if (selectDiv == 0)
            {
                // 得意先コード
                if (paraWork.CustomerCode != null)
                {
                    string CustomerCodeArystr = "";
                    foreach (int CustAry in paraWork.CustomerCode)
                    {
                        if (CustomerCodeArystr != "")
                        {
                            CustomerCodeArystr += ",";
                        }
                        CustomerCodeArystr += CustAry.ToString();
                    }
                    if (CustomerCodeArystr != "")
                    {
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  )AND CUSTOMERCODERF IN (" + CustomerCodeArystr + ") )AND CUSTRATEGRPCODERF=0) OR (UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))").Append(Environment.NewLine);
                    }
                    retstring.Append(Environment.NewLine);
                }

                //得意先掛率グループコード
                if (paraWork.CustRateGrpCode != null)
                {
                    string CustomerGrpCodeArystr = "";
                    foreach (int CustGrpAry in paraWork.CustRateGrpCode)
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
                        retstring.Append("    AND ( ((( UNITPRICEKINDRF > 2 OR UNITPRICEKINDRF < 2  ) AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr + "))  AND CUSTOMERCODERF=0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))").Append(Environment.NewLine);
                    }
                    retstring.Append(Environment.NewLine);
                }
            }

            return retstring.ToString();
        }

        /// <summary>
        /// クラス格納処理 Reader → Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>優良設定情報マスタに取得データ</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPrmSettingWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

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
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkResultWork.BGBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkResultWork.GoodsSupplierCd = 0;
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → Rate2SearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>商品管理情報マスタに取得データ</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2SearchResultWork CopyToPrmSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            Rate2SearchResultWork wkResultWork = new Rate2SearchResultWork();

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
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkResultWork.GoodsSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkResultWork.LayTbspartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkResultWork.BLGoodsHalfName = "";
            wkResultWork.BGBLGroupKanaName = "";
            #endregion

            return wkResultWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → Rate2Work
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>掛率マスタに検索取得データ</returns>
        /// <br>Date       : 2013/03/01</br>
        private Rate2Work CopyToPrmRate2WorkFromReader(ref SqlDataReader myReader)
        {
            Rate2Work wkResultWork = new Rate2Work();

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
            #endregion

            return wkResultWork;
        }
        #endregion ★優良データの場合、優良設定情報と商品管理情報と掛率情報取得処理

        #region ★単一商品情報の掛率検索処理
        public int SearchRate(out object retRateList,object rateParamWork, 
                              int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retRateList = null;
            Rate2ParamWork paraWork = rateParamWork as Rate2ParamWork; // 検索条件
            StringBuilder sqlText = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList tempRateList = new ArrayList();
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                #region Select文作成
                sqlText.Append("SELECT DISTINCT").Append(Environment.NewLine);
                sqlText.Append("	CREATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDATEDATETIMERF, ").Append(Environment.NewLine);
                sqlText.Append("	ENTERPRISECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	FILEHEADERGUIDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDEMPLOYEECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID1RF, ").Append(Environment.NewLine);
                sqlText.Append("	UPDASSEMBLYID2RF, ").Append(Environment.NewLine);
                sqlText.Append("	LOGICALDELETECODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SECTIONCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITRATESETDIVCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNITPRICEKINDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATESETTINGDIVIDERF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGGOODSNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEMNGCUSTNMRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSMAKERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSNORF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATERANKRF, ").Append(Environment.NewLine);
                sqlText.Append("	GOODSRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGROUPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	BLGOODSCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTOMERCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	CUSTRATEGRPCODERF, ").Append(Environment.NewLine);
                sqlText.Append("	SUPPLIERCDRF, ").Append(Environment.NewLine);
                sqlText.Append("	LOTCOUNTRF, ").Append(Environment.NewLine);
                sqlText.Append("	PRICEFLRF, ").Append(Environment.NewLine);
                sqlText.Append("	RATEVALRF, ").Append(Environment.NewLine);
                sqlText.Append("	UPRATERF, ").Append(Environment.NewLine);
                sqlText.Append("	GRSPROFITSECURERATERF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCUNITRF, ").Append(Environment.NewLine);
                sqlText.Append("	UNPRCFRACPROCDIVRF").Append(Environment.NewLine);
                sqlText.Append(" FROM ").Append(Environment.NewLine);
                sqlText.Append("	RATERF ").Append(Environment.NewLine);

                #region WHERE文字列
                sqlText.Append(MakeWhereSearchPureCommon(ref sqlCommand, paraWork, 0, logicalMode)).Append(Environment.NewLine);
                if (paraWork.GoodsChangeMode == 0)
                {
                    // 商品掛率Ｇ
                    sqlText.Append("    AND GOODSRATEGRPCODERF =@FINDGOODSRATEGRPCODE ").Append(Environment.NewLine);
                    SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@FINDGOODSRATEGRPCODE", SqlDbType.Int);
                    paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(paraWork.GoodsRateGrpCode);
                    //層別
                    sqlText.Append("    AND GOODSRATERANKRF = ' ' ").Append(Environment.NewLine);
                }
                else
                {
                    // 商品掛率Ｇ
                    sqlText.Append("    AND GOODSRATEGRPCODERF = 0 ").Append(Environment.NewLine);
                    //層別
                    sqlText.Append("    AND GOODSRATERANKRF =@FINGOODSRATERANK ").Append(Environment.NewLine);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@FINGOODSRATERANK", SqlDbType.NChar);
                    paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(paraWork.GoodsRateRank);
                }
                 // グループコード
                sqlText.Append("    AND BLGROUPCODERF =@FINDBLGROUPCD ").Append(Environment.NewLine);
                SqlParameter paraBlGroupCd = sqlCommand.Parameters.Add("@FINDBLGROUPCD", SqlDbType.Int);
                paraBlGroupCd.Value = SqlDataMediator.SqlSetInt32(paraWork.GroupCd);
                 // ＢＬコード
                sqlText.Append("    AND BLGOODSCODERF =@FINDGOODSBLCD ").Append(Environment.NewLine);
                SqlParameter paraBlGoodsCd = sqlCommand.Parameters.Add("@FINDGOODSBLCD", SqlDbType.Int);
                paraBlGoodsCd.Value = SqlDataMediator.SqlSetInt32(paraWork.BlCd);
                #endregion WHERE文字列

                #endregion Select文作成

                sqlCommand.CommandText = sqlText.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tempRateList.Add(CopyToRate2WorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                retRateList = tempRateList;
                return status;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Rate2DB.SearchPureRate");
                retRateList = new ArrayList();
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
        #endregion　★単一商品情報の掛率検索処理
    }
}