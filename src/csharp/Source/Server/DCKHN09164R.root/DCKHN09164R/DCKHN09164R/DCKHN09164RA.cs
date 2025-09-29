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
    /// <br>Programmer : 96050  横川　昌令</br>
    /// <br>Date       : 2007.10.16</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.13 22008 長内 数馬</br>
    /// <br></br>
    /// <br>Update Note: 一括修正用のSearch処理追加</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br></br>
    /// <br>Update Note: 検索チューニング対応（複数Search時、何件か毎にSelectするように修正)</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.12</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 13878</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.08.06</br>
    /// <br></br>
    /// <br>Update Note: MANTIS 14736</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009/12/02</br>
    /// <br></br>
    /// <br>Update Note: Mantis.17519 単価情報確認画面を掛率にヒットしてない項目で表示した場合ログが落ちる不具合の修正</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/07/05</br>
    /// <br></br>
    /// <br>Update Note: 速度改良 掛率の取得方法の修正</br>
    /// <br>Programmer : 20073 西 毅</br>
    /// <br>Date       : 2012/04/10</br>
    /// <br>Update Note: Redmine#31103棚卸準備処理の速度改良の対応</br>
    /// <br>Programmer : 凌小青</br>
    /// <br>Date       : 2012/07/10</br>
    /// <br>Update Note: PM-TAB対応の追加</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/06/13</br>
    /// <br>Update Note: Redmine#37532 SCM DBの掛率検索結果設定不正の対応</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/06/28</br>
    /// <br>Update Note: 2013/02/08 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/26配信分</br>
    /// <br>           : Redmine#34640 商品在庫マスタの仕様変更(#33231の残留分)</br>
    /// <br>Update Note: 2013/05/06 yangyi</br>
    /// <br>管理番号   : 10801804-00 PM1301E(速度調査）</br>
    /// <br>           : Redmine#35493 　棚卸準備処理で、掛率マスタの件数が多い時に、処理時間が長く、且つサーバー負荷が高くなる(#1902)</br>
    /// <br>Update Note: 2013/06/07 wangl2</br>
    /// <br>管理番号   : 10801804-00 </br>
    /// <br>           : Redmine#35788 　「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
    /// <br>                              エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
    /// <br>Update Note: Redmine#37884掛率マスタ一括登録修正既存障害の対応依頼</br>
    /// <br>Programmer : liuyu</br>
    /// <br>Date       : 2013/07/08</br>
    /// <br>Update Note: 2014/05/13 田建委</br>
    /// <br>管理番号   : 11070071-00 </br>
    /// <br>           : Redmine#36564 棚卸表示速度改善の対応</br>
    /// <br>Update Note: 2020/07/23 譚洪</br>
    /// <br>管理番号   : 11675035-00 </br>
    /// <br>           : PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除</br>
    /// <br>Update Note: 2020/10/20 譚洪</br>
    /// <br>管理番号   : 11675035-00 </br>
    /// <br>           : PMKOBETSU-3551 棚卸表示を実行すると処理に失敗する現象の解除</br> 
    /// </remarks>
    [Serializable]
    public class RateDB : RemoteDB, IRateDB, IGetSyncdataList
    {
        /// <summary>
        /// 掛率設定マスタメンテナンスDBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 96050  横川　昌令</br>														   
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        public RateDB()
            :
        base("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork", "RATERF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定された条件の掛率設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">RateWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                RateWork rateWork = new RateWork();

                // XMLの読み込み
                rateWork = (RateWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateWork));
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
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
		public int ReadProc(ref RateWork rateWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref rateWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection"></param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
		private int ReadProcProc(ref RateWork rateWork, int readMode, ref SqlConnection sqlConnection)
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
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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

            foreach (RateWork rateWork in rateWorkList)
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
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
                        RateWork rateWork = rateWorkList[i] as RateWork;

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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int Search(out object rateWork, object parserateWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rateWork = null;
            //parseRateWork = null;
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int SearchSubSectionProc(out object objrateWork, object pararateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RateWork rateWork = null;
            int status = 0;

            ArrayList pararateWorkList = pararateWork as ArrayList;
            ArrayList rateWorkList = null;
            ArrayList rateResultList = new ArrayList();

            if (pararateWorkList == null)
            {
                rateWork = pararateWork as RateWork;
                status = SearchSubSectionProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
                objrateWork = rateWorkList;
            }
            else
            {
                // 2009.02.12 >>>
                //for (int i = 0; i < pararateWorkList.Count; i++)
                //{
                //    rateWork = pararateWorkList[i] as RateWork;
                //    status = SearchSubSectionProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                //        rateWorkList.Count > 0)
                //    {
                //        for (int j = 0; j < rateWorkList.Count; j++)
                //        {
                //            rateResultList.Add(rateWorkList[j]);
                //        }
                //    }
                //}
                //objrateWork = rateResultList;
                //if (rateResultList.Count > 0)
                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //else
                //    status = (int)ConstantManagement.DB_Status.ctDB_EOF;

                status = SearchSubSectionProc(out rateWorkList, pararateWorkList, readMode, logicalMode, ref sqlConnection);
                objrateWork = rateWorkList;
                // 2009.02.12 <<<
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
		public int SearchSubSectionProc(out ArrayList rateWorkList, RateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchSubSectionProcProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
		}

        // 2009.02.12 Add >>>
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
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.12</br>
        public int SearchSubSectionProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSubSectionProcProc(out rateWorkList, paraList, readMode, logicalMode, ref sqlConnection);
        }
        // 2009.02.12 Add <<<

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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
		private int SearchSubSectionProcProc(out ArrayList rateWorkList, RateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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

        // 2009.02.12 Add >>>
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
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.11</br>
        private int SearchSubSectionProcProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            ArrayList searchedRateList;
            ArrayList searchParaList = new ArrayList();
            int cnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            for (int i = 0; i < paraList.Count; i++)
            {
                searchParaList.Add(paraList[i] as RateWork);

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
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.11</br>
        /// <br>UpdateNote : Redmine#31103棚卸準備処理の速度改良の対応</br>
        /// <br>Programer  : 凌小青</br>
        /// <br>Date       : 2012/07/10</br>
        private int ListSearchSubSectionProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                //sqlCommand = new SqlCommand("SELECT * FROM RATERF ", sqlConnection); //DEL on 2012/07/10 for Redmine#31103
                sqlCommand = new SqlCommand("SELECT * FROM RATERF WITH (READUNCOMMITTED)", sqlConnection); //ADD on 2012/07/10 for Redmine#31103

                string whereString = string.Empty;
                string whereString2 = string.Empty;
                int cnt = 0;
                foreach (RateWork rateWork in paraList)
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

        // 2009.02.12 Add <<<
        #endregion

        //　--- ADD hunagt 2013/06/13 PM-TAB対応 ---------- >>>>>
        #region [SearchForTablet]
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="parserateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        public int SearchForTablet(out object rateWork, object parserateWork, int readMode, ConstantManagement.LogicalMode logicalMode)
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

                return SearchSubSectionForTabletProc(out rateWork, parserateWork, readMode, logicalMode, ref sqlConnection);

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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        public int SearchSubSectionForTabletProc(out object objrateWork, object pararateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RateWork rateWork = null;
            int status = 0;

            ArrayList pararateWorkList = pararateWork as ArrayList;
            ArrayList rateWorkList = null;
            ArrayList rateResultList = new ArrayList();

            if (pararateWorkList == null)
            {
                rateWork = pararateWork as RateWork;
                status = SearchSubSectionForTabletProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
                objrateWork = rateWorkList;
            }
            else
            {
                status = SearchSubSectionForTabletProc(out rateWorkList, pararateWorkList, readMode, logicalMode, ref sqlConnection);
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        public int SearchSubSectionForTabletProc(out ArrayList rateWorkList, RateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSubSectionForTabletProcProc(out rateWorkList, rateWork, readMode, logicalMode, ref sqlConnection);
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        public int SearchSubSectionForTabletProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSubSectionForTabletProcProc(out rateWorkList, paraList, readMode, logicalMode, ref sqlConnection);
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        private int SearchSubSectionForTabletProcProc(out ArrayList rateWorkList, RateWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereStringForTablet(ref sqlCommand, rateWork, logicalMode);

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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        private int SearchSubSectionForTabletProcProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            ArrayList searchedRateList;
            ArrayList searchParaList = new ArrayList();
            int cnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            for (int i = 0; i < paraList.Count; i++)
            {
                searchParaList.Add(paraList[i] as RateWork);

                // 15件ずつ抽出(試した結果速かった為)
                if (searchParaList.Count % 15 == 0)
                {
                    //status = ListSearchSubSectionProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);     // DEL huangt 2013/06/28 Redmine #37532 SCM DBの掛率検索結果設定不正の対応
                    status = ListSearchSubSectionForTabletProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);   // ADD huangt 2013/06/28 Redmine #37532 SCM DBの掛率検索結果設定不正の対応
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
                //status = ListSearchSubSectionProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);       // DEL huangt 2013/06/28 Redmine #37532 SCM DBの掛率検索結果設定不正の対応  
                status = ListSearchSubSectionForTabletProc(out searchedRateList, searchParaList, readMode, logicalMode, ref sqlConnection);    // ADD huangt 2013/06/28 Redmine #37532 SCM DBの掛率検索結果設定不正の対応
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        private int ListSearchSubSectionForTabletProc(out ArrayList rateWorkList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF WITH (READUNCOMMITTED)", sqlConnection);

                string whereString = string.Empty;
                string whereString2 = string.Empty;
                int cnt = 0;
                foreach (RateWork rateWork in paraList)
                {
                    cnt++;
                    whereString2 = MakeWhereStringForTablet2(ref sqlCommand, rateWork, logicalMode, cnt);
                    if (!string.IsNullOrEmpty(whereString2))
                    {
                        whereString += (string.IsNullOrEmpty(whereString)) ? whereString2 : " OR " + whereString2;
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        private string MakeWhereStringForTablet(ref SqlCommand sqlCommand, RateWork rateWork, ConstantManagement.LogicalMode logicalMode)
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
                retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD ";
                SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
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
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        private string MakeWhereStringForTablet2(ref SqlCommand sqlCommand, RateWork rateWork, ConstantManagement.LogicalMode logicalMode, int cnt)
        {
            string wkstring = "";
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + cnt.ToString() + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE" + cnt.ToString(), SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + cnt.ToString();
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
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
                retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + cnt.ToString() + " ";
                SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD" + cnt.ToString(), SqlDbType.NChar);
                paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
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

            if (!string.IsNullOrEmpty(retstring))
            {
                retstring = "( " + retstring + " )";
            }
            return retstring;
        }
        #endregion
        //　--- ADD hunagt 2013/06/13 PM-TAB対応 ---------- <<<<<

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int LogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 0);
        }

        /// <summary>
        /// 論理削除掛率設定マスタ戻りデータ情報を復活します
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除掛率設定マスタ戻りデータ情報を復活します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int RevivalLogicalDelete(ref object rateWork)
        {
            return LogicalDeleteSubSection(ref rateWork, 1);
        }

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="rateWork">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
		public int LogicalDeleteSubSectionProc(ref ArrayList rateWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteSubSectionProcProc(ref rateWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="rateWorkList">RateWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
                        RateWork rateWork = rateWorkList[i] as RateWork;

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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
                    RateWork rateWork = rateWorkList[i] as RateWork;
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.20</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RateWork rateWork, ConstantManagement.LogicalMode logicalMode)
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                // 単価掛率設定区分が3桁以上になる事がないのでLIKEを削除
                //if (rateWork.UnitRateSetDivCd.Length == 3)
                //{
                //    retstring += "AND UNITRATESETDIVCDRF LIKE '" + rateWork.UnitRateSetDivCd + "%' ";
                //}
                //else
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
                    retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD ";
                    SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD", SqlDbType.NChar);
                    paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
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

        // 2009.02.12 Add >>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.12</br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, RateWork rateWork, ConstantManagement.LogicalMode logicalMode, int cnt)
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                // 単価掛率設定区分が3桁以上になる事がないのでLIKEを削除
                //if (rateWork.UnitRateSetDivCd.Length == 3)
                //{
                //    retstring += "AND UNITRATESETDIVCDRF LIKE '" + rateWork.UnitRateSetDivCd + "%' ";
                //}
                //else
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
                    // 2011/07/05 >>>
                    //retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD ";
                    retstring += "AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD" + cnt.ToString() + " ";
                    // 2011/07/05 <<<
                    SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@FINDUNITRATESETDIVCD" + cnt.ToString(), SqlDbType.NChar);
                    paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(rateWork.UnitRateSetDivCd);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 DEL
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 DEL
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
            // -- DEL 2009/08/04 ---------------------------->>>
            //if (rateWork.CustRateGrpCode != 0)
            if (rateWork.CustRateGrpCode != -1)
            // -- DEL 2009/08/04 ----------------------------<<<
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
        // 2009.02.12 Add <<<
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RateWork[] RateWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is RateWork)
                    {
                        RateWork wkRateWork = paraobj as RateWork;
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
                            RateWorkArray = (RateWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RateWork[]));
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
                                RateWork wkRateWork = (RateWork)XmlByteSerializer.Deserialize(byteArray, typeof(RateWork));
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
        /// クラス格納処理 Reader → RateWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromReader(ref SqlDataReader myReader)
        {
            RateWork wkRateWork = new RateWork();

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

        // ADD 2009.01.21 >>>

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
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.21</br>
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objrateWork">検索結果</param>
        /// <param name="pararateWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 23012  畠中 啓次朗</br>
        /// <br>Date       : 2007.10.16</br>
        public int SearchRateSubSectionProc(out object rateSearchResultWork, object rateSearchParamWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = 0;

            RateSearchParamWork pararateWork = rateSearchParamWork as RateSearchParamWork;

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
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.21</br>
		private int SearchRateSubSectionProc(out ArrayList rateWorkList, RateSearchParamWork rateWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText += "SELECT DISTINCT" + Environment.NewLine;
                sqlText += "PRM.SECTIONCODERF AS PRMSECTIONCODERF," + Environment.NewLine;
                sqlText += "PRM.GOODSMGROUPRF AS PRMGOODSMGROUPRF," + Environment.NewLine;
                sqlText += "PRM.TBSPARTSCODERF AS PRMTBSPARTSCODERF," + Environment.NewLine;
                sqlText += "BL.BLGOODSHALFNAMERF," + Environment.NewLine;
                sqlText += "PRM.PARTSMAKERCDRF AS PRMPARTSMAKERCDRF," + Environment.NewLine;
                sqlText += "MAK.MAKERNAMERF," + Environment.NewLine;
                sqlText += "GOODS.SUPPLIERCDRF AS GOODSSUPPLIERCDRF," + Environment.NewLine;
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
                sqlText += "RATE.UNITPRICEKINDRF," + Environment.NewLine;
                sqlText += "RATE.RATESETTINGDIVIDERF," + Environment.NewLine;
                sqlText += "RATE.RATEMNGGOODSCDRF," + Environment.NewLine;
                sqlText += "RATE.RATEMNGGOODSNMRF," + Environment.NewLine;
                sqlText += "RATE.RATEMNGCUSTCDRF," + Environment.NewLine;
                sqlText += "RATE.RATEMNGCUSTNMRF," + Environment.NewLine;
                sqlText += "RATE.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "RATE.GOODSNORF," + Environment.NewLine;
                sqlText += "RATE.GOODSRATERANKRF," + Environment.NewLine;
                sqlText += "RATE.GOODSRATEGRPCODERF," + Environment.NewLine;
                sqlText += "RATE.BLGROUPCODERF," + Environment.NewLine;
                sqlText += "RATE.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "RATE.CUSTOMERCODERF," + Environment.NewLine;
                sqlText += "RATE.CUSTRATEGRPCODERF," + Environment.NewLine;
                sqlText += "RATE.SUPPLIERCDRF," + Environment.NewLine;
                sqlText += "RATE.LOTCOUNTRF," + Environment.NewLine;
                sqlText += "RATE.PRICEFLRF," + Environment.NewLine;
                sqlText += "RATE.RATEVALRF," + Environment.NewLine;
                sqlText += "RATE.UPRATERF," + Environment.NewLine;
                sqlText += "RATE.GRSPROFITSECURERATERF," + Environment.NewLine;
                sqlText += "RATE.UNPRCFRACPROCUNITRF," + Environment.NewLine;
                sqlText += "RATE.UNPRCFRACPROCDIVRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += " PRMSETTINGURF AS PRM" + Environment.NewLine;

                #region JOIN
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += " GOODSMNGRF AS GOODS -- 商品管理情報マスタ" + Environment.NewLine;
                sqlText += "ON PRM.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "AND PRM.SECTIONCODERF = GOODS.SECTIONCODERF" + Environment.NewLine;
                sqlText += "AND PRM.GOODSMGROUPRF = GOODS.GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "AND PRM.PARTSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += " MAKERURF AS MAK -- メーカーマスタ" + Environment.NewLine;
                sqlText += "ON PRM.ENTERPRISECODERF = MAK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "AND PRM.PARTSMAKERCDRF = MAK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += " BLGOODSCDURF AS BL -- BLコードマスタ" + Environment.NewLine;
                sqlText += "ON PRM.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "AND PRM.TBSPARTSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "  SELECT" + Environment.NewLine;
                sqlText += "   *  " + Environment.NewLine;
                sqlText += "  FROM" + Environment.NewLine;
                sqlText += "   RATERF " + Environment.NewLine;
                sqlText += MakeWhereRateString(ref sqlCommand, rateWork, 0, logicalMode);
                sqlText += " ) AS RATE -- 掛率マスタ" + Environment.NewLine;
                sqlText += "ON" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "  ( -- 親" + Environment.NewLine;
                sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                sqlText += "    AND PRM.PARTSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                sqlText += "    AND PRM.GOODSMGROUPRF = RATE.GOODSRATEGRPCODERF -- 商品掛率G" + Environment.NewLine;
                sqlText += "    AND GOODS.SUPPLIERCDRF = RATE.SUPPLIERCDRF -- 仕入先コード" + Environment.NewLine;
                sqlText += "    AND (PRM.TBSPARTSCODERF = 0 AND RATE.BLGOODSCODERF = 0) -- BLコード" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATERANKRF = '' )--層別" + Environment.NewLine;
                sqlText += "    AND ((RATE.CUSTOMERCODERF != 0)-- 得意先コード" + Environment.NewLine;
                sqlText += "          OR (RATE.CUSTRATEGRPCODERF != 0)) -- 得意先掛率G" + Environment.NewLine;
                sqlText += "   )" + Environment.NewLine;
                sqlText += "   OR" + Environment.NewLine;
                sqlText += "  ( -- 子" + Environment.NewLine;
                sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                sqlText += "    AND PRM.PARTSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATEGRPCODERF = 0) -- 商品掛率G" + Environment.NewLine;
                sqlText += "    AND GOODS.SUPPLIERCDRF = RATE.SUPPLIERCDRF -- 仕入先コード" + Environment.NewLine;
                sqlText += "    AND PRM.TBSPARTSCODERF = RATE.BLGOODSCODERF -- BLコード" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATERANKRF = '' )--層別" + Environment.NewLine;
                sqlText += "    AND ((RATE.CUSTOMERCODERF != 0)-- 得意先コード" + Environment.NewLine;
                sqlText += "          OR (RATE.CUSTRATEGRPCODERF != 0)) -- 得意先掛率G" + Environment.NewLine;
                sqlText += "    AND (RATE.BLGROUPCODERF = 0 )-- BLグループｺｰﾄﾞ" + Environment.NewLine; // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                sqlText += "   ) " + Environment.NewLine;
                sqlText += "   OR" + Environment.NewLine;
                sqlText += "  ( -- 仕入率 親" + Environment.NewLine;
                sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                sqlText += "    AND PRM.PARTSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                sqlText += "    AND PRM.GOODSMGROUPRF = RATE.GOODSRATEGRPCODERF -- 商品掛率G" + Environment.NewLine;
                sqlText += "    AND GOODS.SUPPLIERCDRF = RATE.SUPPLIERCDRF -- 仕入先コード" + Environment.NewLine;
                sqlText += "    AND (PRM.TBSPARTSCODERF = 0 AND RATE.BLGOODSCODERF = 0) -- BLコード" + Environment.NewLine;
                sqlText += "    AND (RATE.CUSTOMERCODERF = 0)-- 得意先コード" + Environment.NewLine;
                sqlText += "    AND (RATE.CUSTRATEGRPCODERF = 0) -- 得意先掛率G" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATERANKRF = '' )--層別" + Environment.NewLine;
                sqlText += "   ) " + Environment.NewLine;
                sqlText += "   OR" + Environment.NewLine;
                sqlText += "  ( -- 仕入率　子" + Environment.NewLine;
                sqlText += "    PRM.ENTERPRISECODERF = RATE.ENTERPRISECODERF -- 企業コード" + Environment.NewLine;
                sqlText += "    AND PRM.PARTSMAKERCDRF = RATE.GOODSMAKERCDRF -- メーカー" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATEGRPCODERF = 0) -- 商品掛率G" + Environment.NewLine;
                sqlText += "    AND GOODS.SUPPLIERCDRF = RATE.SUPPLIERCDRF -- 仕入先コード" + Environment.NewLine;
                sqlText += "    AND PRM.TBSPARTSCODERF = RATE.BLGOODSCODERF -- BLコード" + Environment.NewLine;
                sqlText += "    AND (RATE.CUSTOMERCODERF = 0)-- 得意先コード" + Environment.NewLine;
                sqlText += "    AND (RATE.CUSTRATEGRPCODERF = 0) -- 得意先掛率G" + Environment.NewLine;
                sqlText += "    AND (RATE.GOODSRATERANKRF = '' )--層別" + Environment.NewLine;
                sqlText += "    AND (RATE.BLGROUPCODERF = 0 )-- BLグループｺｰﾄﾞ" + Environment.NewLine; // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                sqlText += "   ) " + Environment.NewLine;

                sqlText += ")" + Environment.NewLine;
                #endregion
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

        //-------- ADD 田建委 2013/02/08 Redmine#34640 ------->>>>>
        #region　全税率を検索する
        /// <summary>
        /// 指定された条件の税率データ情報LISTを戻します
        /// </summary>
        /// <param name="enterprise">企業コード</param>
        /// <param name="markerCd">メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="rateWorkList">結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の税率データ情報LISTを戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        public int SearchRateByGoodsNoMarker(string enterprise, int markerCd, string goodsNo, out ArrayList rateWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            rateWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                status = SearchRateByGoodsNoMarkerProc(enterprise, markerCd, goodsNo, out rateWorkList, ref sqlConnection);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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
        /// 指定された条件の税率データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterprise">企業コード</param>
        /// <param name="markerCd">メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="rateWorkList">結果リスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の税率データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/02/08</br>
        /// </remarks>
        private int SearchRateByGoodsNoMarkerProc(string enterprise, int markerCd, string goodsno, out ArrayList rateWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand();
                string retstring = "SELECT * FROM RATERF ";
                retstring += " WHERE ";

                //企業コード
                retstring += " ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterprise);

                //商品番号
                retstring += "AND GOODSNORF=@FINDGOODSNO ";
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = goodsno;

                //商品メーカーコード
                retstring += "AND GOODSMAKERCDRF=@FINDGOODSMAKERCD ";
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(markerCd);

                retstring += " AND UNITPRICEKINDRF=1 AND (( UNITRATESETDIVCDRF='14A' AND RATESETTINGDIVIDERF='4A' )OR ( UNITRATESETDIVCDRF='16A' AND  RATESETTINGDIVIDERF='6A'))";

                sqlCommand.CommandText = retstring;
                sqlCommand.Connection = sqlConnection;

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
        //-------- ADD 田建委 2013/02/08 Redmine#34640 -------<<<<<
        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → RateSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        /// </remarks>
        private RateSearchResultWork CopyToRateSearchResultWorkFromReader(ref SqlDataReader myReader)
        {
            RateSearchResultWork wkResultWork = new RateSearchResultWork();

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
            wkResultWork.PrmGoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMGOODSMGROUPRF"));
            wkResultWork.PrmTbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMTBSPARTSCODERF"));
            wkResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkResultWork.PrmPartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMPARTSMAKERCDRF"));
            wkResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkResultWork.GoodsSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSUPPLIERCDRF"));
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
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.21</br>
        private string MakeWhereRateSearchString(ref SqlCommand sqlCommand, RateSearchParamWork rateWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "PRM.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND PRM.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND PRM.LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
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
                    retstring += "AND PRM.SECTIONCODERF IN (" + sectionString + ") " + Environment.NewLine;
                }
            }
            else
            {
                // 全社指定の場合、ログイン拠点を参照
                if (rateWork.PrmSectionCode != null)
                {
                    string prmsectionString = "";
                    foreach (string prmsectionCode in rateWork.PrmSectionCode)
                    {
                        if (prmsectionCode != "")
                        {
                            if (prmsectionString != "") prmsectionString += ",";
                            prmsectionString += "'" + prmsectionCode + "'";
                        }
                    }
                    if (prmsectionString != "")
                    {
                        retstring += "AND PRM.SECTIONCODERF IN (" + prmsectionString + ") " + Environment.NewLine;
                    }
                }

            }

            //仕入先コード
            if (rateWork.SupplierCd != 0)
            {
                retstring += "AND GOODS.SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
            }

            //商品掛率グループコード
            if (rateWork.GoodsRateGrpCode != 0)
            {
                retstring += "AND PRM.GOODSMGROUPRF=@GOODSMGROUPRF " + Environment.NewLine;
                SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSMGROUPRF", SqlDbType.Int);
                paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
            }

            //商品メーカーコード
            if (rateWork.GoodsMakerCd != 0)
            {
                retstring += "AND PRM.PARTSMAKERCDRF =@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
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
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.21</br>
        private string MakeWhereRateString(ref SqlCommand sqlCommand, RateSearchParamWork rateWork, int MakeMode, ConstantManagement.LogicalMode logicalMode)
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
                        retstring += " AND ( (( UNITPRICEKINDRF != 2 AND CUSTOMERCODERF IN (" + CustomerCodeArystr + ") )AND CUSTRATEGRPCODERF=0) OR (UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))" + Environment.NewLine;
                    }
                    retstring += Environment.NewLine;
                }

                //得意先掛率グループコード
                if (rateWork.CustRateGrpCode != null)
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
                        // -- UPD 2009/12/02 ----------------------------------->>>
                        //得意先掛率の未設定を抽出可能とする
                        //retstring += " AND ( (( UNITPRICEKINDRF != 2 AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr + "))  AND CUSTOMERCODERF=0 ) OR ( UNITPRICEKINDRF = 2 AND CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))" + Environment.NewLine;
                        retstring += " AND ( (( UNITPRICEKINDRF != 2 AND CUSTRATEGRPCODERF IN (" + CustomerGrpCodeArystr + "))  AND CUSTOMERCODERF=0 ) OR ( CUSTOMERCODERF = 0 AND CUSTRATEGRPCODERF=0 ))" + Environment.NewLine;
                        // -- UPD 2009/12/02 -----------------------------------<<<
                    }
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
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
            //command += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;
            try
            {

                for (int i = 0; i < rateWorkList.Count; i++)
                {
                    RateWork rateWork = rateWorkList[i] as RateWork;
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
                    //findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);

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
                        //sqlCommand.CommandText += "  AND LOTCOUNTRF=@FINDLOTCOUNT" + Environment.NewLine;

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
                        //findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
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

        // ADD 2009.01.21 <<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 96050  横川　昌令</br>
        /// <br>Date       : 2007.10.16</br>
        public int SearchForInventory(out object rateWork, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rateWork = null;
            //parseRateWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSubForInventory(out rateWork, enterpriseCode, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception)
            {
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
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.11</br>
        private int SearchSubForInventory(out object rateWorkList, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF WITH (READUNCOMMITTED)", sqlConnection);

                string whereString = string.Empty;
                whereString = MakeWhereString(ref sqlCommand, enterpriseCode, logicalMode);

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
            catch (SqlException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            rateWorkList = al;

            if (((ArrayList)rateWorkList).Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        //----ADD on 2012/07/10 for Redmine#31103 ------->>>>>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 21024  佐々木 健</br>
        /// <br>Date       : 2009.02.12</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
            }
            if (wkstring != "")
            {
                retstring += wkstring + " ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            if (!string.IsNullOrEmpty(retstring))
            {
                retstring = "( " + retstring + " )";
            }
            return retstring;
        }
        //----ADD on 2012/07/10 for Redmine#31103 -------<<<<<<

        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/05/06</br>
        public int SearchByUnitPriceKind(out object rateWork, string enterpriseCode, int unitPriceKind, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rateWork = null;
            //parseRateWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchByUnitPriceKindProc(out rateWork, enterpriseCode, unitPriceKind, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception)
            {
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/05/06</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   : 10801804-00 </br>
        /// <br>           : Redmine#35788 　「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                              エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        private int SearchByUnitPriceKindProc(out object rateWorkList, string enterpriseCode, int unitPriceKind, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF WITH (READUNCOMMITTED)", sqlConnection);

                string whereString = string.Empty;
                whereString = MakeWhereString(ref sqlCommand, enterpriseCode, unitPriceKind, logicalMode);

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
            //catch (SqlException)//DEL 2013/06/07 wangl2 for Redmine#35788
            catch (SqlException ex)//ADD 2013/06/07 wangl2 for Redmine#35788
            {
                base.WriteSQLErrorLog(ex, "RateDB.SearchByUnitPriceKindにてSQLエラー発生 Msg=" + ex.Message, ex.Number);//ADD 2013/06/07 wangl2 for Redmine#35788
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            rateWorkList = al;

            if (((ArrayList)rateWorkList).Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/05/06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterpriseCode, int unitPriceKind, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " AND UNITPRICEKINDRF = @UNITPRICEKIND" + " ";
            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.Int);
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(unitPriceKind);

            return retstring;
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        //----- ADD 2014/05/13 田建委 for Redmine#36564 ------->>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(棚卸表示専用)
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="unitPriceKind">単価種類(1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/05/13</br>
        /// </remarks>
        public int SearchRateForInvoDis(out object rateWork, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode)
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

                return SearchRateForInvoDisProc(out rateWork, enterpriseCode, secList, unitPriceKind, logicalMode, ref sqlConnection);

            }
            catch (Exception)
            {
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)(棚卸表示専用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="unitPriceKind">単価種類(1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/05/13</br>
        /// </remarks>
        private int SearchRateForInvoDisProc(out object rateWorkList, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("SELECT ").Append(Environment.NewLine);
                strBuilder.Append(" CREATEDATETIMERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDATEDATETIMERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,ENTERPRISECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,FILEHEADERGUIDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                strBuilder.Append(" ,LOGICALDELETECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,SECTIONCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNITRATESETDIVCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNITPRICEKINDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATESETTINGDIVIDERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGGOODSCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGGOODSNMRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGCUSTCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGCUSTNMRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSMAKERCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSNORF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSRATERANKRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSRATEGRPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,BLGROUPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,BLGOODSCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,CUSTOMERCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,CUSTRATEGRPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,SUPPLIERCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,LOTCOUNTRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,PRICEFLRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEVALRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPRATERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GRSPROFITSECURERATERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNPRCFRACPROCUNITRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNPRCFRACPROCDIVRF ").Append(Environment.NewLine);
                strBuilder.Append("FROM RATERF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                sqlCommand = new SqlCommand(strBuilder.ToString(), sqlConnection);

                string whereString = string.Empty;
                whereString = MakeWhereStringForInvoDis(ref sqlCommand, enterpriseCode, secList, unitPriceKind, logicalMode);

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
            catch (SqlException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            rateWorkList = al;

            if (((ArrayList)rateWorkList).Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定(棚卸表示専用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/05/13</br>
        /// </remarks>
        private string MakeWhereStringForInvoDis(ref SqlCommand sqlCommand, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (secList != null && secList.Count > 0)
            {
                retstring += " AND SECTIONCODERF IN (";

                string secStr = string.Empty;
                for (int i = 0; i < secList.Count; i++)
                {
                    secStr += "'" + secList[i].ToString().Trim() + "'" + ", ";

                }
                retstring += secStr;
                retstring += "'00')";
            }

            retstring += " AND UNITPRICEKINDRF = @UNITPRICEKIND" + " ";
            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.Int);
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(unitPriceKind);

            return retstring;
        }

        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(棚卸表示専用)
        /// </summary>
        /// <param name="rateWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="unitPriceKind">単価種類(1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/10/20</br>
        /// </remarks>
        public int SearchRateForInvoDis2(out object rateWork, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode)
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

                return SearchRateForInvoDisProc2(out rateWork, enterpriseCode, secList, unitPriceKind, logicalMode, ref sqlConnection);

            }
            catch (Exception)
            {
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)(棚卸表示専用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="unitPriceKind">単価種類(1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/10/20</br>
        /// </remarks>
        private int SearchRateForInvoDisProc2(out object rateWorkList, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            rateWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("SELECT ").Append(Environment.NewLine);
                strBuilder.Append(" CREATEDATETIMERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDATEDATETIMERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,ENTERPRISECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,FILEHEADERGUIDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                strBuilder.Append(" ,LOGICALDELETECODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,SECTIONCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNITRATESETDIVCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNITPRICEKINDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATESETTINGDIVIDERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGGOODSCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGGOODSNMRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGCUSTCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEMNGCUSTNMRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSMAKERCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSNORF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSRATERANKRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GOODSRATEGRPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,BLGROUPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,BLGOODSCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,CUSTOMERCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,CUSTRATEGRPCODERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,SUPPLIERCDRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,LOTCOUNTRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,PRICEFLRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,RATEVALRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UPRATERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,GRSPROFITSECURERATERF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNPRCFRACPROCUNITRF ").Append(Environment.NewLine);
                strBuilder.Append(" ,UNPRCFRACPROCDIVRF ").Append(Environment.NewLine);
                strBuilder.Append("FROM RATERF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                sqlCommand = new SqlCommand(strBuilder.ToString(), sqlConnection);

                string whereString = string.Empty;
                whereString = MakeWhereStringForInvoDis2(ref sqlCommand, enterpriseCode, secList, unitPriceKind, logicalMode);

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
            catch (SqlException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            rateWorkList = al;

            if (((ArrayList)rateWorkList).Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定(棚卸表示専用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="rateWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/10/20</br>
        /// </remarks>
        private string MakeWhereStringForInvoDis2(ref SqlCommand sqlCommand, string enterpriseCode, ArrayList secList, int unitPriceKind, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (secList != null && secList.Count > 0)
            {
                retstring += " AND SECTIONCODERF IN (";

                string secStr = string.Empty;
                for (int i = 0; i < secList.Count; i++)
                {
                    secStr += "'" + secList[i].ToString().Trim() + "'" + ", ";

                }
                retstring += secStr;
                retstring += "'00')";
            }

            retstring += " AND UNITPRICEKINDRF = @UNITPRICEKIND" + " ";
            SqlParameter paraUnitPriceKind = sqlCommand.Parameters.Add("@UNITPRICEKIND", SqlDbType.Int);
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetInt32(unitPriceKind);

            //6A単品以外の掛率データを検索
            retstring += " AND UNITRATESETDIVCDRF <> '26A'" + " ";

            return retstring;
        }
        // --- ADD 譚洪 2020/10/20 PMKOBETSU-3551の対応 ------<<<<<
        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/07/23</br>
        public int SearchByUnitPriceKindByGroup(out object rateWork, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode)
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

                //グループ別掛率マスタ検索処理
                return SearchByUnitPriceKindByGroupProc(out rateWork, enterpriseCode, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception)
            {
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
        /// 指定された条件の掛率設定マスタ戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="rateWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/07/23</br>
        private int SearchByUnitPriceKindByGroupProc(out object rateWorkList, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            //検索結果
            rateWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM RATERF WITH (READUNCOMMITTED)", sqlConnection);

                string whereString = string.Empty;

                //検索条件文字列生成
                whereString = MakeWhereStringByGroup(ref sqlCommand, enterpriseCode, logicalMode);

                if (!string.IsNullOrEmpty(whereString))
                {
                    whereString = "WHERE " + whereString;
                }

                sqlCommand.CommandText += whereString;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //クラス格納処理
                    al.Add(CopyToRateWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                base.WriteSQLErrorLog(ex, "RateDB.SearchByUnitPriceKindByGroupProcにてSQLエラー発生 Msg=" + ex.Message, ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            rateWorkList = al;

            if (((ArrayList)rateWorkList).Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句のを作成して戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/07/23</br>
        private string MakeWhereStringByGroup(ref SqlCommand sqlCommand, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE" + " ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //6A単品以外の掛率データを検索
            retstring += " AND UNITRATESETDIVCDRF <> '26A'" + " ";

            return retstring;
        }

        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
        //----- ADD 2014/05/13 田建委 for Redmine#36564 -------<<<<<
    }
}