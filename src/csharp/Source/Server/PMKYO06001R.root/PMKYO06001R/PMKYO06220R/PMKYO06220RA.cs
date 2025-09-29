//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/08/20  修正内容 : myReaderからDクラスへ項目転記を行っている個所はメソッド化する
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/08  修正内容 : #23777 ソースレビュー
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : FSI東 隆史
// 修 正 日  2012/07/26  修正内容 : 拠点管理 抽出条件追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率マスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APRateDB : RemoteDB
    {
        #region [Private]
        //ADD 2011/09/08 sundx #23777 ソースレビュー ------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _sectionCode = 0;
        private int _unitRateSetDivCd = 0;
        private int _unitPriceKind = 0;
        private int _rateSettingDivide = 0;
        private int _rateMngGoodsCd = 0;
        private int _rateMngGoodsNm = 0;
        private int _rateMngCustCd = 0;
        private int _rateMngCustNm = 0;
        private int _goodsMakerCd = 0;
        private int _goodsNo = 0;
        private int _goodsRateRank = 0;
        private int _goodsRateGrpCode = 0;
        private int _bLGroupCode = 0;
        private int _bLGoodsCode = 0;
        private int _customerCode = 0;
        private int _custRateGrpCode = 0;
        private int _supplierCd = 0;
        private int _lotCount = 0;
        private int _priceFl = 0;
        private int _rateVal = 0;
        private int _upRate = 0;
        private int _grsProfitSecureRate = 0;
        private int _unPrcFracProcUnit = 0;
        private int _unPrcFracProcDiv = 0;
        //ADD 2011/09/08 sundx #23777 ソースレビュー -------<<<<<
        #endregion

        /// <summary>
        /// 掛率マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APRateDB()
            : base("PMKYO06221D", "Broadleaf.Application.Remoting.ParamData.APRateWork", "RATERF")
        {

        }

        #region [Read]
        /// <summary>
        /// 掛率マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="rateArrList">掛率マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public int SearchRate(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            return SearchRateProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                sqlTransaction, out rateArrList, out retMessage);
        }
        /// <summary>
        /// 掛率マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="rateArrList">掛率マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchRateProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateArrList = new ArrayList();
            APRateWork rateWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //掛率マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    rateWork = new APRateWork();

                    rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
                    rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
                    rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
                    rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                    rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                    rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
                    rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
                    rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
                    rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

                    rateArrList.Add(rateWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APRateDB.SearchRate Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            return status;
        }

        /// <summary>
        /// 掛率マスタの計数検索処理
        /// </summary>
        /// <param name="rateWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchRateCount(APRateWork rateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchRateCountProc(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 掛率マスタの計数検索処理
        /// </summary>
        /// <param name="rateWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchRateCountProc(APRateWork rateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND GOODSRATERANKRF=@FINDGOODSRATERANK AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND SUPPLIERCDRF=@FINDSUPPLIERCD ";

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
                // DEL 2009/06/09 ---- >>>
                //SqlParameter findParaLotCount = sqlCommand.Parameters.Add("@FINDLOTCOUNT", SqlDbType.Float);
                // DEL 2009/06/09 ---- <<<
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(rateWork.EnterpriseCode);
                findParaSectionCode.Value = rateWork.SectionCode;
                findParaUnitRateSetDivCd.Value = rateWork.UnitRateSetDivCd;
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsMakerCd);
                findParaGoodsNo.Value = rateWork.GoodsNo;
                findParaGoodsRateRank.Value = rateWork.GoodsRateRank;
                findParaGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.GoodsRateGrpCode);
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGroupCode);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(rateWork.BLGoodsCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustomerCode);
                findParaCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(rateWork.CustRateGrpCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(rateWork.SupplierCd);
                // DEL 2009/06/09 ---- >>>
                //findParaLotCount.Value = SqlDataMediator.SqlSetDouble(rateWork.LotCount);
                // DEL 2009/06/09 ---- <<<

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  掛率マスタデータ削除
        /// </summary>
        /// <param name="apRateWork">掛率マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(APRateWork apRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  掛率マスタデータ削除
        /// </summary>
        /// <param name="apRateWork">掛率マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(APRateWork apRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM RATERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND UNITRATESETDIVCDRF=@FINDUNITRATESETDIVCD AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND GOODSRATERANKRF=@FINDGOODSRATERANK AND GOODSRATEGRPCODERF=@FINDGOODSRATEGRPCODE AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CUSTRATEGRPCODERF=@FINDCUSTRATEGRPCODE AND SUPPLIERCDRF=@FINDSUPPLIERCD ";

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
            findParaEnterpriseCode.Value = apRateWork.EnterpriseCode;
            findParaSectionCode.Value = apRateWork.SectionCode;
            findParaUnitRateSetDivCd.Value = apRateWork.UnitRateSetDivCd;
            findParaGoodsMakerCd.Value = apRateWork.GoodsMakerCd;
            findParaGoodsNo.Value = apRateWork.GoodsNo;
            findParaGoodsRateRank.Value = apRateWork.GoodsRateRank;
            findParaGoodsRateGrpCode.Value = apRateWork.GoodsRateGrpCode;
            findParaBLGroupCode.Value = apRateWork.BLGroupCode;
            findParaBLGoodsCode.Value = apRateWork.BLGoodsCode;
            findParaCustomerCode.Value = apRateWork.CustomerCode;
            findParaCustRateGrpCode.Value = apRateWork.CustRateGrpCode;
            findParaSupplierCd.Value = apRateWork.SupplierCd;
            //findParaLotCount.Value = apRateWork.LotCount;


            // 掛率マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 掛率マスタ登録
        /// </summary>
        /// <param name="apRateWork">掛率マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(APRateWork apRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 掛率マスタ登録
        /// </summary>
        /// <param name="apRateWork">掛率マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 掛率マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(APRateWork apRateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO RATERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @UNITRATESETDIVCD, @UNITPRICEKIND, @RATESETTINGDIVIDE, @RATEMNGGOODSCD, @RATEMNGGOODSNM, @RATEMNGCUSTCD, @RATEMNGCUSTNM, @GOODSMAKERCD, @GOODSNO, @GOODSRATERANK, @GOODSRATEGRPCODE, @BLGROUPCODE, @BLGOODSCODE, @CUSTOMERCODE, @CUSTRATEGRPCODE, @SUPPLIERCD, @LOTCOUNT, @PRICEFL, @RATEVAL, @UPRATE, @GRSPROFITSECURERATE, @UNPRCFRACPROCUNIT, @UNPRCFRACPROCDIV)";

            //Prameterオブジェクトの作成
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

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apRateWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apRateWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apRateWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apRateWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apRateWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apRateWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apRateWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.LogicalDeleteCode);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(apRateWork.SectionCode);
            paraUnitRateSetDivCd.Value = SqlDataMediator.SqlSetString(apRateWork.UnitRateSetDivCd);
            paraUnitPriceKind.Value = SqlDataMediator.SqlSetString(apRateWork.UnitPriceKind);
            paraRateSettingDivide.Value = SqlDataMediator.SqlSetString(apRateWork.RateSettingDivide);
            paraRateMngGoodsCd.Value = SqlDataMediator.SqlSetString(apRateWork.RateMngGoodsCd);
            paraRateMngGoodsNm.Value = SqlDataMediator.SqlSetString(apRateWork.RateMngGoodsNm);
            paraRateMngCustCd.Value = SqlDataMediator.SqlSetString(apRateWork.RateMngCustCd);
            paraRateMngCustNm.Value = SqlDataMediator.SqlSetString(apRateWork.RateMngCustNm);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apRateWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apRateWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apRateWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apRateWork.GoodsNo);
            }
            if (string.IsNullOrEmpty(apRateWork.GoodsRateRank.Trim()))
            {
                paraGoodsRateRank.Value = apRateWork.GoodsRateRank;
            }
            else
            {
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(apRateWork.GoodsRateRank);
            }
            paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.GoodsRateGrpCode);
            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.BLGroupCode);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.BLGoodsCode);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.CustomerCode);
            paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(apRateWork.CustRateGrpCode);
            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(apRateWork.SupplierCd);
            paraLotCount.Value = SqlDataMediator.SqlSetDouble(apRateWork.LotCount);
            paraPriceFl.Value = SqlDataMediator.SqlSetDouble(apRateWork.PriceFl);
            paraRateVal.Value = SqlDataMediator.SqlSetDouble(apRateWork.RateVal);
            paraUpRate.Value = SqlDataMediator.SqlSetDouble(apRateWork.UpRate);
            paraGrsProfitSecureRate.Value = SqlDataMediator.SqlSetDouble(apRateWork.GrsProfitSecureRate);
            paraUnPrcFracProcUnit.Value = SqlDataMediator.SqlSetDouble(apRateWork.UnPrcFracProcUnit);
            paraUnPrcFracProcDiv.Value = SqlDataMediator.SqlSetInt32(apRateWork.UnPrcFracProcDiv);

            // 掛率マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        /// <summary>
        /// 掛率マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="rateArrList">掛率マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchRate(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            return SearchRateProc(enterpriseCodes, paramList, sqlConnection,
                              sqlTransaction, out rateArrList, out retMessage);
        }
        /// <summary>
        /// 掛率マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="rateArrList">掛率マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchRateProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList rateArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            rateArrList = new ArrayList();
            //APRateWork rateWork = null;//ADD 2011/08/20 途中納品チェック
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/09/08 sundx #23777 ソースレビュー
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/09/08 sundx #23777 ソースレビュー
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APRateProcParamWork param = paramList as APRateProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                #region DEL
                //DEL 2011/09/08 sundx #23777 ソースレビュー ----------------------------------------------------------------------->>>>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF ";
                //sqlStr += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.UnitPriceKindRF))
                //{
                //    sqlStr += " AND UNITPRICEKINDRF = @UNITPRICEKINDBEGINRF";
                //    SqlParameter unitPriceKindBeginRF = sqlCommand.Parameters.Add("@UNITPRICEKINDBEGINRF", SqlDbType.NChar);
                //    unitPriceKindBeginRF.Value = SqlDataMediator.SqlSetString(param.UnitPriceKindRF);
                //}

                //if (param.CustRateGrpCodeBeginRF != 0)
                //{
                //    sqlStr += " AND CUSTRATEGRPCODERF >= @CUSTRATEGRPCODEBEGINRF";
                //    SqlParameter custRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEBEGINRF", SqlDbType.Int);
                //    custRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeBeginRF);
                //}

                //if (param.CustRateGrpCodeEndRF != 0)
                //{
                //    sqlStr += " AND CUSTRATEGRPCODERF <= @CUSTRATEGRPCODEENDRF";
                //    SqlParameter custRateGrpCodeEndRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEENDRF", SqlDbType.Int);
                //    custRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeEndRF);
                //}

                //if (param.CustomerCodeBeginRF != 0)
                //{
                //    sqlStr += " AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF";
                //    SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
                //    customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
                //}

                //if (param.CustomerCodeEndRF != 0)
                //{
                //    sqlStr += " AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF";
                //    SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
                //    customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsRateRankBeginRF))
                //{
                //    sqlStr += " AND GOODSRATERANKRF >= @GOODSRATERANKBEGINRF";
                //    SqlParameter goodsRateRankBeginRF = sqlCommand.Parameters.Add("@GOODSRATERANKBEGINRF", SqlDbType.NChar);
                //    goodsRateRankBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsRateRankEndRF))
                //{
                //    sqlStr += " AND GOODSRATERANKRF <= @GOODSRATERANKENDRF";
                //    SqlParameter goodsRateRankEndRF = sqlCommand.Parameters.Add("@GOODSRATERANKENDRF", SqlDbType.NChar);
                //    goodsRateRankEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankEndRF);
                //}

                //if (param.GoodsRateGrpCodeBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSRATEGRPCODERF >= @GOODSRATEGRPCODEBEGINRF";
                //    SqlParameter goodsRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEBEGINRF", SqlDbType.Int);
                //    goodsRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeBeginRF);
                //}

                //if (param.GoodsRateGrpCodeEndRF != 0)
                //{
                //    sqlStr += " AND GOODSRATEGRPCODERF <= @GOODSRATEGRPCODEENDRF";
                //    SqlParameter goodsRateGrpCodeEndRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEENDRF", SqlDbType.Int);
                //    goodsRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeEndRF);
                //}

                //if (param.BLGoodsCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCODERF >= @BLGOODSCODEBEGINRF";
                //    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                //    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                //}

                //if (param.BLGoodsCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCODERF <= @BLGOODSCODEENDRF";
                //    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                //    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                //DEL 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<
                #endregion
                //ADD 2011/09/08 sundx #23777 ソースレビュー ----------------------------------------------------------------------->>>>>
                sqlStr.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, UNITRATESETDIVCDRF, UNITPRICEKINDRF, RATESETTINGDIVIDERF, RATEMNGGOODSCDRF, RATEMNGGOODSNMRF, RATEMNGCUSTCDRF, RATEMNGCUSTNMRF, GOODSMAKERCDRF, GOODSNORF, GOODSRATERANKRF, GOODSRATEGRPCODERF, BLGROUPCODERF, BLGOODSCODERF, CUSTOMERCODERF, CUSTRATEGRPCODERF, SUPPLIERCDRF, LOTCOUNTRF, PRICEFLRF, RATEVALRF, UPRATERF, GRSPROFITSECURERATERF, UNPRCFRACPROCUNITRF, UNPRCFRACPROCDIVRF FROM RATERF ");
                sqlStr.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }
                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }
                if (!string.IsNullOrEmpty(param.UnitPriceKindRF))
                {
                    sqlStr.Append(" AND UNITPRICEKINDRF = @UNITPRICEKINDBEGINRF");
                    SqlParameter unitPriceKindBeginRF = sqlCommand.Parameters.Add("@UNITPRICEKINDBEGINRF", SqlDbType.NChar);
                    unitPriceKindBeginRF.Value = SqlDataMediator.SqlSetString(param.UnitPriceKindRF);
                }

                // --- ADD 2012/07/26 ---------->>>>>
                // 拠点
                if (!string.IsNullOrEmpty(param.SectionCodeBeginRF))
                {
                    sqlStr.Append(" AND SECTIONCODERF >= @SECTIONCODEBEGINRF");
                    SqlParameter sectionCodeBeginRF = sqlCommand.Parameters.Add("@SECTIONCODEBEGINRF", SqlDbType.NChar);
                    sectionCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.SectionCodeBeginRF);
                }

                if (!string.IsNullOrEmpty(param.SectionCodeEndRF))
                {
                    sqlStr.Append(" AND SECTIONCODERF <= @SECTIONCODEENDRF");
                    SqlParameter sectionCodeEndRF = sqlCommand.Parameters.Add("@SECTIONCODEENDRF", SqlDbType.NChar);
                    sectionCodeEndRF.Value = SqlDataMediator.SqlSetString(param.SectionCodeEndRF);
                }
                // --- ADD 2012/07/26 ----------<<<<<
                
                if (param.CustRateGrpCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND CUSTRATEGRPCODERF >= @CUSTRATEGRPCODEBEGINRF");
                    SqlParameter custRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEBEGINRF", SqlDbType.Int);
                    custRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeBeginRF);
                }

                if (param.CustRateGrpCodeEndRF != 0)
                {
                    sqlStr.Append(" AND CUSTRATEGRPCODERF <= @CUSTRATEGRPCODEENDRF");
                    SqlParameter custRateGrpCodeEndRF = sqlCommand.Parameters.Add("@CUSTRATEGRPCODEENDRF", SqlDbType.Int);
                    custRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustRateGrpCodeEndRF);
                }

                if (param.CustomerCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND CUSTOMERCODERF >= @CUSTOMERCODEBEGINRF");
                    SqlParameter customerCodeBeginRF = sqlCommand.Parameters.Add("@CUSTOMERCODEBEGINRF", SqlDbType.Int);
                    customerCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeBeginRF);
                }

                if (param.CustomerCodeEndRF != 0)
                {
                    sqlStr.Append(" AND CUSTOMERCODERF <= @CUSTOMERCODEENDRF");
                    SqlParameter customerCodeEndRF = sqlCommand.Parameters.Add("@CUSTOMERCODEENDRF", SqlDbType.Int);
                    customerCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.CustomerCodeEndRF);
                }

                if (param.SupplierCdBeginRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                }

                if (param.SupplierCdEndRF != 0)
                {
                    sqlStr.Append(" AND SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                }

                if (param.GoodsMakerCdBeginRF != 0)
                {
                    sqlStr.Append(" AND GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                }

                if (param.GoodsMakerCdEndRF != 0)
                {
                    sqlStr.Append(" AND GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsRateRankBeginRF))
                {
                    sqlStr.Append(" AND GOODSRATERANKRF >= @GOODSRATERANKBEGINRF");
                    SqlParameter goodsRateRankBeginRF = sqlCommand.Parameters.Add("@GOODSRATERANKBEGINRF", SqlDbType.NChar);
                    goodsRateRankBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankBeginRF);
                }

                if (!string.IsNullOrEmpty(param.GoodsRateRankEndRF))
                {
                    sqlStr.Append(" AND GOODSRATERANKRF <= @GOODSRATERANKENDRF");
                    SqlParameter goodsRateRankEndRF = sqlCommand.Parameters.Add("@GOODSRATERANKENDRF", SqlDbType.NChar);
                    goodsRateRankEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsRateRankEndRF);
                }

                if (param.GoodsRateGrpCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND GOODSRATEGRPCODERF >= @GOODSRATEGRPCODEBEGINRF");
                    SqlParameter goodsRateGrpCodeBeginRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEBEGINRF", SqlDbType.Int);
                    goodsRateGrpCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeBeginRF);
                }

                if (param.GoodsRateGrpCodeEndRF != 0)
                {
                    sqlStr.Append(" AND GOODSRATEGRPCODERF <= @GOODSRATEGRPCODEENDRF");
                    SqlParameter goodsRateGrpCodeEndRF = sqlCommand.Parameters.Add("@GOODSRATEGRPCODEENDRF", SqlDbType.Int);
                    goodsRateGrpCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsRateGrpCodeEndRF);
                }

                if (param.BLGoodsCodeBeginRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCODERF >= @BLGOODSCODEBEGINRF");
                    SqlParameter bLGoodsCodeBeginRF = sqlCommand.Parameters.Add("@BLGOODSCODEBEGINRF", SqlDbType.Int);
                    bLGoodsCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeBeginRF);
                }

                if (param.BLGoodsCodeEndRF != 0)
                {
                    sqlStr.Append(" AND BLGOODSCODERF <= @BLGOODSCODEENDRF");
                    SqlParameter bLGoodsCodeEndRF = sqlCommand.Parameters.Add("@BLGOODSCODEENDRF", SqlDbType.Int);
                    bLGoodsCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGoodsCodeEndRF);
                }

                // --- DEL 2012/07/26 ---------->>>>>
                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}
                
                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                // --- DEL 2012/07/26 ----------<<<<<
                // --- ADD 2012/07/26 ---------->>>>>
                // 品番
                if ( "2" == param.SetFunRF )
                {
                    // 単品指定

                    // 品番有指定
                    sqlStr.Append(" AND (GOODSNORF IS NOT NULL) AND (LEN(GOODSNORF) > 0)");

                    if (   (!string.IsNullOrEmpty(param.GoodsNoBeginRF)) 
                             && (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                             && (param.GoodsNoBeginRF == param.GoodsNoEndRF))
                    {
                        // 単独指定
                        sqlStr.Append(" AND (GOODSNORF LIKE @GOODSNOBEGINRF)");
                        SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                        param.GoodsNoBeginRF = System.Text.RegularExpressions.Regex.Replace(param.GoodsNoBeginRF, @"\*$", "%"); // 末尾に｢*｣がある場合は曖昧検索用に置換
                        goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                    }
                    else
                    {
                        // 範囲指定
                        if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                        {
                            sqlStr.Append(" AND GOODSNORF >= @GOODSNOBEGINRF");
                            SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                            goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                        }

                        if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                        {
                            sqlStr.Append(" AND GOODSNORF <= @GOODSNOENDRF");
                            SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                            goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                        }
                    }
                }
                else
                {
                    // グループ指定
                    sqlStr.Append(" AND ((GOODSNORF IS NULL) OR (LEN(GOODSNORF) = 0))");
                }
                // --- ADD 2012/07/26 ----------<<<<<
                //ADD 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //掛率マスタデータ用SQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/09/08 sundx #23777 ソースレビュー 
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/09/08 sundx #23777 ソースレビュー 

                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                //ADD 2011/09/08 sundx #23777 ソースレビュー ----------------------------->>>>>
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }
                //ADD 2011/09/08 sundx #23777 ソースレビュー -----------------------------<<<<<

                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
                    //rateWork = new APRateWork();

                    //rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
                    //rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
                    //rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
                    //rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
                    //rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
                    //rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
                    //rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
                    //rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    //rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
                    //rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    //rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    //rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    //rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    //rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
                    //rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
                    //rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
                    //rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
                    //rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
                    //rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
                    //rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));

                    //rateArrList.Add(rateWork);
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
                    #endregion DEL
                    rateArrList.Add(CopyFromMyReaderToAPRateWork(myReader));//ADD 2011/08/20 途中納品チェック
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APRateDB.SearchRate Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            return status;
        }
        /// <summary>
        /// インデックス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : カラムインデックス格納処理を行う</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _sectionCode = myReader.GetOrdinal("SECTIONCODERF");
            _unitRateSetDivCd = myReader.GetOrdinal("UNITRATESETDIVCDRF");
            _unitPriceKind = myReader.GetOrdinal("UNITPRICEKINDRF");
            _rateSettingDivide = myReader.GetOrdinal("RATESETTINGDIVIDERF");
            _rateMngGoodsCd = myReader.GetOrdinal("RATEMNGGOODSCDRF");
            _rateMngGoodsNm = myReader.GetOrdinal("RATEMNGGOODSNMRF");
            _rateMngCustCd = myReader.GetOrdinal("RATEMNGCUSTCDRF");
            _rateMngCustNm = myReader.GetOrdinal("RATEMNGCUSTNMRF");
            _goodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
            _goodsNo = myReader.GetOrdinal("GOODSNORF");
            _goodsRateRank = myReader.GetOrdinal("GOODSRATERANKRF");
            _goodsRateGrpCode = myReader.GetOrdinal("GOODSRATEGRPCODERF");
            _bLGroupCode = myReader.GetOrdinal("BLGROUPCODERF");
            _bLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
            _customerCode = myReader.GetOrdinal("CUSTOMERCODERF");
            _custRateGrpCode = myReader.GetOrdinal("CUSTRATEGRPCODERF");
            _supplierCd = myReader.GetOrdinal("SUPPLIERCDRF");
            _lotCount = myReader.GetOrdinal("LOTCOUNTRF");
            _priceFl = myReader.GetOrdinal("PRICEFLRF");
            _rateVal = myReader.GetOrdinal("RATEVALRF");
            _upRate = myReader.GetOrdinal("UPRATERF");
            _grsProfitSecureRate = myReader.GetOrdinal("GRSPROFITSECURERATERF");
            _unPrcFracProcUnit = myReader.GetOrdinal("UNPRCFRACPROCUNITRF");
            _unPrcFracProcDiv = myReader.GetOrdinal("UNPRCFRACPROCDIVRF");

        }
        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        /// <summary>
        /// 掛率マスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>掛率マスタデータ</returns>
        /// <br>Note       : 掛率マスタデータを戻します</br>
        /// <br>Programmer : 馮文雄</br>
        /// <br>Date       : 2011/08/20</br>
        private APRateWork CopyFromMyReaderToAPRateWork(SqlDataReader myReader)
        {
            APRateWork rateWork = new APRateWork();
            #region DEL
            //DEL 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<
            //rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITRATESETDIVCDRF"));
            //rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITPRICEKINDRF"));
            //rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESETTINGDIVIDERF"));
            //rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSCDRF"));
            //rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGGOODSNMRF"));
            //rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTCDRF"));
            //rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEMNGCUSTNMRF"));
            //rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            //rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            //rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            //rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            //rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            //rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            //rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LOTCOUNTRF"));
            //rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));
            //rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));
            //rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPRATERF"));
            //rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GRSPROFITSECURERATERF"));
            //rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNPRCFRACPROCUNITRF"));
            //rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCFRACPROCDIVRF"));
            //DEL 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<
            #endregion
            //ADD 2011/09/08 sundx #23777 ソースレビュー ----------------------------------------------------------------------->>>>>
            rateWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            rateWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            rateWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            rateWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            rateWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            rateWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            rateWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            rateWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            rateWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _sectionCode);
            rateWork.UnitRateSetDivCd = SqlDataMediator.SqlGetString(myReader, _unitRateSetDivCd);
            rateWork.UnitPriceKind = SqlDataMediator.SqlGetString(myReader, _unitPriceKind);
            rateWork.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, _rateSettingDivide);
            rateWork.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, _rateMngGoodsCd);
            rateWork.RateMngGoodsNm = SqlDataMediator.SqlGetString(myReader, _rateMngGoodsNm);
            rateWork.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, _rateMngCustCd);
            rateWork.RateMngCustNm = SqlDataMediator.SqlGetString(myReader, _rateMngCustNm);
            rateWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _goodsMakerCd);
            rateWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _goodsNo);
            rateWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, _goodsRateRank);
            rateWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, _goodsRateGrpCode);
            rateWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, _bLGroupCode);
            rateWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, _bLGoodsCode);
            rateWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, _customerCode);
            rateWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, _custRateGrpCode);
            rateWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, _supplierCd);
            rateWork.LotCount = SqlDataMediator.SqlGetDouble(myReader, _lotCount);
            rateWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, _priceFl);
            rateWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, _rateVal);
            rateWork.UpRate = SqlDataMediator.SqlGetDouble(myReader, _upRate);
            rateWork.GrsProfitSecureRate = SqlDataMediator.SqlGetDouble(myReader, _grsProfitSecureRate);
            rateWork.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, _unPrcFracProcUnit);
            rateWork.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, _unPrcFracProcDiv);
            //ADD 2011/09/08 sundx #23777 ソースレビュー -----------------------------------------------------------------------<<<<<

            return rateWork;
        }
        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
    }
}





