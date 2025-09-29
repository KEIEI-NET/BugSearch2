//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）リモートオブジェクトクラス
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）リモートオブジェクトクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11475093-00 作成担当 : 呉軍
// 作 成 日  2018/09/14  修正内容 : Redmine#49751 検品管理 在庫入庫更新PKG差異対応
//----------------------------------------------------------------------------//
// 管理番号  11575094-00 作成担当 : 岸
// 作 成 日  2019/06/13  修正内容 : 大黒商会検品障害対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル在庫仕入（入庫更新）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）リモートオブジェクトです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>Update Note: Redmine#49751 検品管理 在庫入庫更新PKG差異対応</br>
    /// <br>Programmer : 呉軍</br>
    /// <br>Date       : 2018/09/14</br>
    /// </remarks>
    [Serializable]
    public class HandyStockSupplierDB : RemoteDB, IHandyStockSupplierDB
    {
        #region [定数]
        /// <summary>システム区分「0:手入力」</summary>
        private const int SystemDivCdData0 = 0;
        /// <summary>システム区分「1:伝発」</summary>
        private const int SystemDivCdData1 = 1;
        /// <summary>システム区分「2:検索」</summary>
        private const int SystemDivCdData2 = 2;
        /// <summary>システム区分「3：一括」</summary>
        private const int SystemDivCdData3 = 3;
        /// <summary>入庫更新区分（拠点）「0:未入庫」</summary>
        private const int EnterUpdDivSecData0 = 0;
        /// <summary>入庫更新区分（BO1）「0:未入庫」</summary>
        private const int EnterUpdDivBO1Data0 = 0;
        /// <summary>入庫更新区分（BO2）「0:未入庫」</summary>
        private const int EnterUpdDivBO2Data0 = 0;
        /// <summary>入庫更新区分（BO3）「0:未入庫」</summary>
        private const int EnterUpdDivBO3Data0 = 0;
        /// <summary>入庫更新区分（ﾒｰｶｰ）「0:未入庫」</summary>
        private const int EnterUpdDivMakerData0 = 0;
        /// <summary>入庫更新区分（EO）「0:未入庫」</summary>
        private const int EnterUpdDivEOData0 = 0;

        /// <summary>入庫区分「1:拠点」</summary>
        private const int WarehousingDivCdData1 = 1;
        /// <summary>入庫区分「2:BO1」</summary>
        private const int WarehousingDivCdData2 = 2;
        /// <summary>入庫区分「3:BO2」</summary>
        private const int WarehousingDivCdData3 = 3;
        /// <summary>入庫区分「4:BO3」</summary>
        private const int WarehousingDivCdData4 = 4;
        /// <summary>入庫区分「5:ﾒｰｶｰ」</summary>
        private const int WarehousingDivCdData5 = 5;
        /// <summary>入庫区分「6：EO」</summary>
        private const int WarehousingDivCdData6 = 6;

        /// <summary>データ送信区分「9:正常終了」</summary>
        private const int DataSendCodeData9 = 9;
        /// <summary>データ復旧区分「9:正常終了」</summary>
        private const int DataRecoverDivData9 = 9;

        /// <summary>処理区分「1:在庫一括分」</summary>
        private const int OpdivData1 = 1;
        /// <summary>処理区分「2:その他」</summary>
        private const int OpdivData2 = 2;

        /// <summary>検品データ登録区分「0:検品データ登録」</summary>
        private const int InspectWriteModeData0 = 0;

        /// <summary>仕入形式「2:発注」</summary>
        private const int SupplierFormalData2 = 2;
        /// <summary>仕入形式（元）「2:発注」</summary>
        private const int SupplierFormalSrcData2 = 2;

        /// <summary>発注残数（範囲検索用）</summary>
        private const int OrderRemainCntData0 = 0;

        /// <summary>注文方法「0:発注書発注」</summary>
        private const int WayToOrderData0 = 0;

        /// <summary>受払元伝票区分「10:仕入」</summary>
        private const int AcPaySlipCdData10 = 10;
        /// <summary>受払元伝票区分「13:在庫仕入」</summary>
        private const int AcPaySlipCdData13 = 13;

        /// <summary>受払元取引区分「10:通常伝票」</summary>
        private const int AcPayTransCdData10 = 10;

        /// <summary>ハンディターミナル区分「1:ハンディターミナル」</summary>
        private const int HandTerminalCodeData1 = 1;

        // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
        /// <summary>取寄品倉庫コード</summary>
        private const string ToriyoseWarehouseCd = "0";
        // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyStockSupplierDB()
        {
        }
        #endregion

        #region ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_一覧情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchStockSupplierList(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyUOEOrderListParamWork condWork = (HandyUOEOrderListParamWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyUOEOrderListParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockSupplierDB.SearchStockSupplierList" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyUOEOrderList = null;
                status = SearchStockSupplierListProc(condWork, out handyUOEOrderList, ref sqlConnection);

                // 検索結果ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyUOEOrderList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchStockSupplierList" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧情報を抽出します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyUOEOrderList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_一覧情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchStockSupplierListProc(HandyUOEOrderListParamWork condWork, out ArrayList handyUOEOrderList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyUOEOrderList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" UOEORDERDTLRF.EMPLOYEECODERF, ");
                sb.AppendLine(" UOEORDERDTLRF.ONLINENORF, ");
                sb.AppendLine(" UOEORDERDTLRF.UOEREMARK1RF, ");
                sb.AppendLine(" UOEORDERDTLRF.SYSTEMDIVCDRF, ");
                sb.AppendLine(" UOEORDERDTLRF.DATASENDCODERF, ");
                sb.AppendLine(" UOEORDERDTLRF.DATARECOVERDIVRF, ");
                sb.AppendLine(" UOEORDERDTLRF.UOESALESORDERNORF, ");
                sb.AppendLine(" UOEORDERDTLRF.UOESECTIONSLIPNORF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSLIPNO1RF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSLIPNO2RF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSLIPNO3RF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVSECRF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVBO1RF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVBO2RF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVBO3RF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVMAKERRF, ");
                sb.AppendLine(" UOEORDERDTLRF.ENTERUPDDIVEORF, ");
                sb.AppendLine(" UOEORDERDTLRF.COMMASSEMBLYIDRF ");
                sb.AppendLine("FROM UOEORDERDTLRF WITH (READUNCOMMITTED) ");
                // 従業員マスタ
                sb.AppendLine(" INNER JOIN EMPLOYEERF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON UOEORDERDTLRF.ENTERPRISECODERF = EMPLOYEERF.ENTERPRISECODERF ");
                sb.AppendLine(" AND UOEORDERDTLRF.LOGICALDELETECODERF = EMPLOYEERF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND UOEORDERDTLRF.SECTIONCODERF = EMPLOYEERF.BELONGSECTIONCODERF ");
                sb.AppendLine(" AND EMPLOYEERF.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" UOEORDERDTLRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD ");
                sb.AppendLine(" AND UOEORDERDTLRF.DATASENDCODERF = @FINDDATASENDCODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.DATARECOVERDIVRF = @FINDDATARECOVERDIV ");

                // 引数.処理区分が「1:在庫一括分」の場合
                if (condWork.OpDiv == OpdivData1)
                {
                    // 「3：一括」
                    sb.AppendLine(" AND UOEORDERDTLRF.SYSTEMDIVCDRF = @FINDSYSTEMDIVCD3 ");
                }
                // 引数.処理区分が「 2:その他」の場合
                else if (condWork.OpDiv == OpdivData2)
                {
                    // 「0:手入力、1:伝発、2:検索」
                    sb.AppendLine(" AND UOEORDERDTLRF.SYSTEMDIVCDRF IN (@FINDSYSTEMDIVCD0, @FINDSYSTEMDIVCD1 , @FINDSYSTEMDIVCD2) ");
                }

                sb.AppendLine(" AND (UOEORDERDTLRF.ENTERUPDDIVSECRF = @ENTERUPDDIVSEC OR ");
                sb.AppendLine("       UOEORDERDTLRF.ENTERUPDDIVBO1RF = @ENTERUPDDIVBO1 OR ");
                sb.AppendLine("       UOEORDERDTLRF.ENTERUPDDIVBO2RF = @ENTERUPDDIVBO2 OR ");
                sb.AppendLine("       UOEORDERDTLRF.ENTERUPDDIVBO3RF = @ENTERUPDDIVBO3 OR ");
                sb.AppendLine("       UOEORDERDTLRF.ENTERUPDDIVMAKERRF = @ENTERUPDDIVMAKER OR ");
                sb.AppendLine("       UOEORDERDTLRF.ENTERUPDDIVEORF = @ENTERUPDDIVEO) ");
                sb.AppendLine(" ORDER BY UOEORDERDTLRF.ONLINENORF, UOEORDERDTLRF.UOESALESORDERNORF ");


                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // システム区分
                SqlParameter findSystemDivCd0 = sqlCommand.Parameters.Add("@FINDSYSTEMDIVCD0", SqlDbType.Int);
                findSystemDivCd0.Value = SqlDataMediator.SqlSetInt32(SystemDivCdData0);
                // システム区分
                SqlParameter findSystemDivCd1 = sqlCommand.Parameters.Add("@FINDSYSTEMDIVCD1", SqlDbType.Int);
                findSystemDivCd1.Value = SqlDataMediator.SqlSetInt32(SystemDivCdData1);
                // システム区分
                SqlParameter findSystemDivCd2 = sqlCommand.Parameters.Add("@FINDSYSTEMDIVCD2", SqlDbType.Int);
                findSystemDivCd2.Value = SqlDataMediator.SqlSetInt32(SystemDivCdData2);
                // システム区分
                SqlParameter findSystemDivCd3 = sqlCommand.Parameters.Add("@FINDSYSTEMDIVCD3", SqlDbType.Int);
                findSystemDivCd3.Value = SqlDataMediator.SqlSetInt32(SystemDivCdData3);
                // 入庫更新区分（拠点）
                SqlParameter findEnterUpdDivSec = sqlCommand.Parameters.Add("@ENTERUPDDIVSEC", SqlDbType.Int);
                findEnterUpdDivSec.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivSecData0);
                // 入庫更新区分（BO1）
                SqlParameter findEnterUpdDivBO1 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO1", SqlDbType.Int);
                findEnterUpdDivBO1.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO1Data0);
                // 入庫更新区分（BO2）
                SqlParameter findEnterUpdDivBO2 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO2", SqlDbType.Int);
                findEnterUpdDivBO2.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO2Data0);
                // 入庫更新区分（BO3）
                SqlParameter findEnterUpdDivBO3 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO3", SqlDbType.Int);
                findEnterUpdDivBO3.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO3Data0);
                // 入庫更新区分（ﾒｰｶｰ）
                SqlParameter findEnterUpdDivMaker = sqlCommand.Parameters.Add("@ENTERUPDDIVMAKER", SqlDbType.Int);
                findEnterUpdDivMaker.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivMakerData0);
                // 入庫更新区分（EO）
                SqlParameter findEnterUpdDivEO = sqlCommand.Parameters.Add("@ENTERUPDDIVEO", SqlDbType.Int);
                findEnterUpdDivEO.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivEOData0);
                // UOE発注先コード
                SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(condWork.SupplierCode);
                // データ送信区分「9:正常終了」固定
                SqlParameter findDataSendCode = sqlCommand.Parameters.Add("@FINDDATASENDCODE", SqlDbType.Int);
                findDataSendCode.Value = SqlDataMediator.SqlSetInt32(DataSendCodeData9);
                // データ復旧区分「9:正常終了」固定
                SqlParameter findDataRecoverDiv = sqlCommand.Parameters.Add("@FINDDATARECOVERDIV", SqlDbType.Int);
                findDataRecoverDiv.Value = SqlDataMediator.SqlSetInt32(DataRecoverDivData9);
                // 従業員コード
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyUOEOrderList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // 発注情報を設定します。
                    handyUOEOrderList.Add(this.CopyToHandyUOEOrderListWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchStockSupplierListProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyUOEOrderListWork
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル在庫仕入（入庫更新）_一覧情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private HandyUOEOrderListWork CopyToHandyUOEOrderListWorkFromReader(ref SqlDataReader myReader)
        {
            HandyUOEOrderListWork handyUOEOrderListWork = new HandyUOEOrderListWork();

            #region クラスへ格納
            handyUOEOrderListWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));                           // オンライン番号
            handyUOEOrderListWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));             // UOE発注番号
            handyUOEOrderListWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));              // 通信アセンブリID
            handyUOEOrderListWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));          // UOE拠点伝票番号
            handyUOEOrderListWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));                        // BO伝票番号１
            handyUOEOrderListWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));                        // BO伝票番号２
            handyUOEOrderListWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));                        // BO伝票番号３
            handyUOEOrderListWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                      // ＵＯＥリマーク１
            handyUOEOrderListWork.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVSECRF"));               // 入庫更新区分（拠点）
            handyUOEOrderListWork.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO1RF"));               // 入庫更新区分（BO1）
            handyUOEOrderListWork.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO2RF"));               // 入庫更新区分（BO2）
            handyUOEOrderListWork.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO3RF"));               // 入庫更新区分（BO3）
            handyUOEOrderListWork.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVMAKERRF"));           // 入庫更新区分（ﾒｰｶｰ）
            handyUOEOrderListWork.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVEORF"));                 // 入庫更新区分（EO）
            #endregion

            return handyUOEOrderListWork;
        }
        #endregion

        #region ハンディターミナル在庫仕入（入庫更新）_明細情報取得処理
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細情報を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyStockSupplierSlipNum(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyUOEOrderDtlParamWork condWork = (HandyUOEOrderDtlParamWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyUOEOrderDtlParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockSupplierDB.SearchHandyStockSupplierSlipNum" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyUOEOrderDtlList = null;
                status = SearchHandyStockSupplierSlipNumProc(condWork, out handyUOEOrderDtlList, ref sqlConnection);

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyUOEOrderDtlList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchHandyStockSupplierSlipNum" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null; 
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細情報を抽出します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyUOEOrderDtlList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ハンディターミナル在庫仕入（入庫更新）_明細情報</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>Update Note: Redmine#49751 検品管理 在庫入庫更新PKG差異対応</br>
        /// <br>Programmer : 呉軍</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        private int SearchHandyStockSupplierSlipNumProc(HandyUOEOrderDtlParamWork condWork, out ArrayList handyUOEOrderDtlList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyUOEOrderDtlList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                sb.AppendLine("UOEDTL.SUPPLIERSNMRF, ");
                sb.AppendLine("UOEDTL.STOCKSLIPDTLNUMRF, ");
                sb.AppendLine("UOEDTL.GOODSMAKERCDRF, ");
                sb.AppendLine("UOEDTL.GOODSNORF, ");
                sb.AppendLine("UOEDTL.GOODSNAMERF, ");
                sb.AppendLine("(CASE WHEN UOEDTL.WAREHOUSECODERF IS NULL THEN UOEDTL.WAREHOUSECODERF ELSE (CASE WHEN STOCKRF.WAREHOUSECODERF IS NOT NULL THEN UOEDTL.WAREHOUSECODERF ELSE '-1' END) END )AS WAREHOUSECODERF,");
                sb.AppendLine("UOEDTL.WAREHOUSESHELFNORF, ");
                sb.AppendLine("UOEDTL.UOESECTOUTGOODSCNTRF, ");
                sb.AppendLine("UOEDTL.BOSHIPMENTCNT1RF, ");
                sb.AppendLine("UOEDTL.BOSHIPMENTCNT2RF, ");
                sb.AppendLine("UOEDTL.BOSHIPMENTCNT3RF, ");
                sb.AppendLine("UOEDTL.MAKERFOLLOWCNTRF, ");
                sb.AppendLine("UOEDTL.EOALWCCOUNTRF, ");
                sb.AppendLine("UOEDTL.ONLINENORF, ");
                sb.AppendLine("UOEDTL.UOESALESORDERNORF, ");
                sb.AppendLine("UOEDTL.UOESALESORDERROWNORF, ");
                sb.AppendLine("GOODSBARCODEREVNRF.GOODSBARCODERF ");
                sb.AppendLine("FROM (");
                sb.AppendLine("SELECT");
                sb.AppendLine(" UOEORDERDTLRF.ENTERPRISECODERF, ");
                sb.AppendLine(" UOEORDERDTLRF.LOGICALDELETECODERF,");
                // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                sb.AppendLine(" UOEORDERDTLRF.SUPPLIERSNMRF, ");
                sb.AppendLine(" UOEORDERDTLRF.STOCKSLIPDTLNUMRF, ");
                sb.AppendLine(" UOEORDERDTLRF.GOODSMAKERCDRF, ");
                //sb.AppendLine(" UOEORDERDTLRF.GOODSNORF, "); // DEL 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応
                sb.AppendLine(" (CASE WHEN UOESETTINGRF.STOCKBLNKTPRTNODIVRF = 1 THEN UOEORDERDTLRF.GOODSNORF ELSE (CASE WHEN UOEORDERDTLRF.SUBSTPARTSNORF IS NOT NULL THEN UOEORDERDTLRF.SUBSTPARTSNORF ELSE UOEORDERDTLRF.GOODSNORF END) END) AS GOODSNORF, "); // ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応
                sb.AppendLine(" UOEORDERDTLRF.GOODSNAMERF, ");
                sb.AppendLine(" UOEORDERDTLRF.WAREHOUSECODERF, ");
                sb.AppendLine(" UOEORDERDTLRF.WAREHOUSESHELFNORF, ");
                sb.AppendLine(" UOEORDERDTLRF.UOESECTOUTGOODSCNTRF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSHIPMENTCNT1RF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSHIPMENTCNT2RF, ");
                sb.AppendLine(" UOEORDERDTLRF.BOSHIPMENTCNT3RF, ");
                sb.AppendLine(" UOEORDERDTLRF.MAKERFOLLOWCNTRF, ");
                sb.AppendLine(" UOEORDERDTLRF.EOALWCCOUNTRF, ");
                sb.AppendLine(" UOEORDERDTLRF.ONLINENORF, ");
                sb.AppendLine(" UOEORDERDTLRF.UOESALESORDERNORF, ");
                // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                sb.AppendLine(" UOEORDERDTLRF.UOESALESORDERROWNORF ");
                //sb.AppendLine(" UOEORDERDTLRF.UOESALESORDERROWNORF, ");
                //sb.AppendLine(" GOODSBARCODEREVNRF.GOODSBARCODERF ");
                // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                sb.AppendLine("FROM UOEORDERDTLRF WITH (READUNCOMMITTED) ");
                // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                // UOE自社設定マスタ
                sb.AppendLine("LEFT JOIN UOESETTINGRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON UOESETTINGRF.ENTERPRISECODERF= UOEORDERDTLRF.ENTERPRISECODERF");
                sb.AppendLine("AND UOESETTINGRF.SECTIONCODERF=UOEORDERDTLRF.SECTIONCODERF");
                //// 従業員マスタ
                //sb.AppendLine(" LEFT JOIN GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                //sb.AppendLine(" ON UOEORDERDTLRF.ENTERPRISECODERF = GOODSBARCODEREVNRF.ENTERPRISECODERF ");
                //sb.AppendLine(" AND UOEORDERDTLRF.LOGICALDELETECODERF = GOODSBARCODEREVNRF.LOGICALDELETECODERF ");
                //sb.AppendLine(" AND UOEORDERDTLRF.GOODSMAKERCDRF = GOODSBARCODEREVNRF.GOODSMAKERCDRF ");
                //sb.AppendLine(" AND UOEORDERDTLRF.GOODSNORF = GOODSBARCODEREVNRF.GOODSNORF ");
                // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                sb.AppendLine("WHERE");
                sb.AppendLine(" UOEORDERDTLRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.ONLINENORF = @FINDONLINENO ");
                sb.AppendLine(" AND UOEORDERDTLRF.UOESALESORDERNORF = @FINDUOESALESORDERNO ");
                sb.AppendLine(" AND UOEORDERDTLRF.DATASENDCODERF = @FINDDATASENDCODE ");
                sb.AppendLine(" AND UOEORDERDTLRF.DATARECOVERDIVRF = @FINDDATARECOVERDIV ");
                // 入庫区分(1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO)
                switch (condWork.WarehousingDivCd)
                {
                    case WarehousingDivCdData1:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVSECRF = @FINDENTERUPDDIVSEC ");
                        // --- ADD 2019/06/13 ---------->>>>>
                        sb.AppendLine(" AND UOEORDERDTLRF.UOESECTIONSLIPNORF = @FINDSLIPNO ");
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData2:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVBO1RF = @FINDENTERUPDDIVBO1 ");
                        // --- ADD 2019/06/13 ---------->>>>>
                        sb.AppendLine(" AND UOEORDERDTLRF.BOSLIPNO1RF = @FINDSLIPNO ");
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData3:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVBO2RF = @FINDENTERUPDDIVBO2 ");
                        // --- ADD 2019/06/13 ---------->>>>>
                        sb.AppendLine(" AND UOEORDERDTLRF.BOSLIPNO2RF = @FINDSLIPNO ");
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData4:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVBO3RF = @FINDENTERUPDDIVBO3 ");
                        // --- ADD 2019/06/13 ---------->>>>>
                        sb.AppendLine(" AND UOEORDERDTLRF.BOSLIPNO3RF = @FINDSLIPNO ");
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData5:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVMAKERRF = @FINDENTERUPDDIVMAKER ");
                        break;
                    case WarehousingDivCdData6:
                        sb.AppendLine(" AND UOEORDERDTLRF.ENTERUPDDIVEORF = @FINDENTERUPDDIVEO ");
                        break;
                }
                // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                sb.AppendLine(") AS UOEDTL");
                // 商品バーコード関連付けマスタ
                sb.AppendLine("LEFT JOIN GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON UOEDTL.ENTERPRISECODERF = GOODSBARCODEREVNRF.ENTERPRISECODERF ");
                sb.AppendLine("AND UOEDTL.LOGICALDELETECODERF = GOODSBARCODEREVNRF.LOGICALDELETECODERF ");
                sb.AppendLine("AND UOEDTL.GOODSMAKERCDRF = GOODSBARCODEREVNRF.GOODSMAKERCDRF ");
                sb.AppendLine("AND UOEDTL.GOODSNORF = GOODSBARCODEREVNRF.GOODSNORF ");
                // 在庫マスタ
                sb.AppendLine("LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON STOCKRF.ENTERPRISECODERF=UOEDTL.ENTERPRISECODERF");
                sb.AppendLine("AND STOCKRF.GOODSNORF=UOEDTL.GOODSNORF");
                sb.AppendLine("AND STOCKRF.GOODSMAKERCDRF= UOEDTL.GOODSMAKERCDRF");
                sb.AppendLine("AND STOCKRF.WAREHOUSECODERF=UOEDTL.WAREHOUSECODERF");
                sb.AppendLine("ORDER BY UOEDTL.ONLINENORF, UOEDTL.UOESALESORDERNORF, UOEDTL.UOESALESORDERROWNORF ");
                // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                //sb.AppendLine(" ORDER BY UOEORDERDTLRF.ONLINENORF, UOEORDERDTLRF.UOESALESORDERNORF, UOEORDERDTLRF.UOESALESORDERROWNORF ");  // DEL 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応

                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // オンライン番号
                SqlParameter findOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);
                findOnlineNo.Value = SqlDataMediator.SqlSetInt32(condWork.OnlineNo);
                // UOE発注番号
                SqlParameter findUOESalesOrderNo = sqlCommand.Parameters.Add("@FINDUOESALESORDERNO", SqlDbType.Int);
                findUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(condWork.UOESalesOrderNo);
                // データ送信区分「9:正常終了」固定
                SqlParameter findDataSendCode = sqlCommand.Parameters.Add("@FINDDATASENDCODE", SqlDbType.Int);
                findDataSendCode.Value = SqlDataMediator.SqlSetInt32(DataSendCodeData9);
                // データ復旧区分「9:正常終了」固定
                SqlParameter findDataRecoverDiv = sqlCommand.Parameters.Add("@FINDDATARECOVERDIV", SqlDbType.Int);
                findDataRecoverDiv.Value = SqlDataMediator.SqlSetInt32(DataRecoverDivData9);
                // 入庫区分(1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO)
                switch (condWork.WarehousingDivCd)
                {
                    case WarehousingDivCdData1:
                        // 入庫更新区分（拠点）「0:未入庫」固定
                        SqlParameter findEnterUpdDivSec = sqlCommand.Parameters.Add("@FINDENTERUPDDIVSEC", SqlDbType.Int);
                        findEnterUpdDivSec.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivSecData0);
                        // --- ADD 2019/06/13 ---------->>>>>
                        SqlParameter findSectionSlipNo = sqlCommand.Parameters.Add("@FINDSLIPNO", SqlDbType.NChar);
                        findSectionSlipNo.Value = SqlDataMediator.SqlSetString(condWork.SlipNo);
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData2:
                        // 入庫更新区分（BO1）「0:未入庫」固定
                        SqlParameter findEnterUpdDivBO1 = sqlCommand.Parameters.Add("@FINDENTERUPDDIVBO1", SqlDbType.Int);
                        findEnterUpdDivBO1.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO1Data0);
                        // --- ADD 2019/06/13 ---------->>>>>
                        SqlParameter findBO1SlipNo = sqlCommand.Parameters.Add("@FINDSLIPNO", SqlDbType.NChar);
                        findBO1SlipNo.Value = SqlDataMediator.SqlSetString(condWork.SlipNo);
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData3:
                        // 入庫更新区分（BO2）「0:未入庫」固定
                        SqlParameter findEnterUpdDivBO2 = sqlCommand.Parameters.Add("@FINDENTERUPDDIVBO2", SqlDbType.Int);
                        findEnterUpdDivBO2.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO2Data0);
                        // --- ADD 2019/06/13 ---------->>>>>
                        SqlParameter findBO2SlipNo = sqlCommand.Parameters.Add("@FINDSLIPNO", SqlDbType.NChar);
                        findBO2SlipNo.Value = SqlDataMediator.SqlSetString(condWork.SlipNo);
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData4:
                        // 入庫更新区分（BO3）「0:未入庫」固定
                        SqlParameter findEnterUpdDivBO3 = sqlCommand.Parameters.Add("@FINDENTERUPDDIVBO3", SqlDbType.Int);
                        findEnterUpdDivBO3.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivBO3Data0);
                        // --- ADD 2019/06/13 ---------->>>>>
                        SqlParameter findBO3SlipNo = sqlCommand.Parameters.Add("@FINDSLIPNO", SqlDbType.NChar);
                        findBO3SlipNo.Value = SqlDataMediator.SqlSetString(condWork.SlipNo);
                        // --- ADD 2019/06/13 ----------<<<<<
                        break;
                    case WarehousingDivCdData5:
                        // 入庫更新区分（ﾒｰｶｰ）「0:未入庫」固定
                        SqlParameter findEnterUpdDivMaker = sqlCommand.Parameters.Add("@FINDENTERUPDDIVMAKER", SqlDbType.Int);
                        findEnterUpdDivMaker.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivMakerData0);
                        break;
                    case WarehousingDivCdData6:
                        // 入庫更新区分（EO）「0:未入庫」固定
                        SqlParameter findEnterUpdDivEO = sqlCommand.Parameters.Add("@FINDENTERUPDDIVEO", SqlDbType.Int);
                        findEnterUpdDivEO.Value = SqlDataMediator.SqlSetInt32(EnterUpdDivEOData0);
                        break;
                }

                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyUOEOrderDtlList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // ハンディターミナル在庫仕入（入庫更新）_明細情報を設定します。
                    handyUOEOrderDtlList.Add(this.CopyToHandyUOEOrderDtlListWorkFromReader(condWork, ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchHandyStockSupplierSlipNumProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyUOEOrderResultDtlWorkData
        /// </summary>
        /// <param name="condWork">検索条件ワーク</param>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル在庫仕入（入庫更新）_明細情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private HandyUOEOrderResultDtlWork CopyToHandyUOEOrderDtlListWorkFromReader(HandyUOEOrderDtlParamWork condWork, ref SqlDataReader myReader)
        {
            HandyUOEOrderResultDtlWork handyUOEOrderResultDtlWorkData = new HandyUOEOrderResultDtlWork();

            #region クラスへ格納
            handyUOEOrderResultDtlWorkData.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));              // 仕入先略称
            handyUOEOrderResultDtlWorkData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));             // 商品メーカーコード
            handyUOEOrderResultDtlWorkData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                      // 品番
            handyUOEOrderResultDtlWorkData.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                  // 品名
            handyUOEOrderResultDtlWorkData.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));          // 倉庫コード
            handyUOEOrderResultDtlWorkData.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));    // 倉庫棚番
            handyUOEOrderResultDtlWorkData.StockSlipDtlNum = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));      　// 仕入明細通番
            // 入庫区分(1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO)
            switch (condWork.WarehousingDivCd)
            {
                case WarehousingDivCdData1:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));                      // UOE拠点在庫数
                    break;
                case WarehousingDivCdData2:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));                        // BO在庫数1
                    break;
                case WarehousingDivCdData3:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));                        // BO在庫数2
                    break;
                case WarehousingDivCdData4:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));                        // BO在庫数3
                    break;
                case WarehousingDivCdData5:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));                       // メーカーフォロー数
                    break;
                case WarehousingDivCdData6:
                    handyUOEOrderResultDtlWorkData.StockCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));                          // EO引当数
                    break;
            }
            handyUOEOrderResultDtlWorkData.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));                              // 商品バーコード
            #endregion

            return handyUOEOrderResultDtlWorkData;
        }
        #endregion

        #region ハンディターミナル在庫仕入（入庫更新）_登録処理
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_登録処理
        /// </summary>
        /// <param name="writeListObj">検品登録オブジェクト</param>
        /// <param name="uoeStcUpdDataListObj">発注登録オブジェクト</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>Update Note: Redmine#49751 検品管理 在庫入庫更新PKG差異対応</br>
        /// <br>Programmer : 呉軍</br>
        /// <br>Date       : 2018/09/14</br>
        /// </remarks>
        public int WriteStockSupplier(ref object writeListObj, ref object uoeStcUpdDataListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList writeList = null;
            ArrayList uoeStcUpdDataList = null;
            Dictionary<long, InspectDataAddWork> inspectDataDic = null;

            try
            {
                // 検品登録オブジェクトからArrayListを変換します
                if(writeListObj is ArrayList)
                {
                    writeList = writeListObj as ArrayList;
                }

                // 発注登録オブジェクトからArrayListを変換します
                if (uoeStcUpdDataListObj is ArrayList)
                {
                    uoeStcUpdDataList = uoeStcUpdDataListObj as ArrayList;
                }

                // 検品登録ArrayListがない場合
                if (writeList == null || writeList.Count == 0)
                {
                    return status;
                }

                // 検品登録ディクショナリーの初期化
                inspectDataDic = new Dictionary<long, InspectDataAddWork>();

                // 検品登録ディクショナリーの作成（キー：仕入明細通番）
                foreach (InspectDataAddWork inspectDataAddWork in writeList)
                {
                    if (!inspectDataDic.ContainsKey(inspectDataAddWork.StockSlipDtlNum))
                    {
                        inspectDataDic.Add(inspectDataAddWork.StockSlipDtlNum, inspectDataAddWork);
                    }
                }

                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                //  伝票データ登録処理
                IOWriteControlDB ioWriteControlDBAdapter = new IOWriteControlDB();

                string retMsg = string.Empty;
                string retItemInfo = string.Empty;
                SqlEncryptInfo sqlEncryptInfo = null;

                status = ioWriteControlDBAdapter.WriteProc(ref uoeStcUpdDataList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // 伝票データ登録処理が失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    base.WriteErrorLog("HandyStockSupplierDB.WriteStockSupplier" + retMsg);
                    return status;
                }

                StockDetailWork stockDetailWork = null;
                InspectDataAddWork inspectDataAddParamWork = null;
                HandyInspectDataWork handyInspectDataWriteWork = null;
                ArrayList inspectDataWriteList = new ArrayList();

                // 検品登録リストを作成します
                for (int i = 0; i < uoeStcUpdDataList.Count; i++)
                {
                    if ((object)uoeStcUpdDataList[i] is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList list = (CustomSerializeArrayList)uoeStcUpdDataList[i];
                        foreach (object obj in list)
                        {
                            if (obj is ArrayList)
                            {
                                ArrayList arraylist = (ArrayList)obj;

                                foreach (object subObj in arraylist)
                                {
                                    if (subObj is StockDetailWork)
                                    {
                                        stockDetailWork = (StockDetailWork)subObj;
                                        // 引数.仕入明細通番により、仕入明細データ中に仕入形式（元）：「2:発注」且つ、仕入明細通番（元）と一致のレコードの仕入伝票番号と仕入行番号を取る。
                                        if (inspectDataDic.ContainsKey(stockDetailWork.StockSlipDtlNumSrc) && stockDetailWork.SupplierFormalSrc == SupplierFormalSrcData2)
                                        {
                                            inspectDataAddParamWork = inspectDataDic[stockDetailWork.StockSlipDtlNumSrc];
                                            handyInspectDataWriteWork = new HandyInspectDataWork();
                                            // 企業コード
                                            handyInspectDataWriteWork.EnterpriseCode = inspectDataAddParamWork.EnterpriseCode;
                                            // 受払元伝票区分(固定値(10:仕入))
                                            handyInspectDataWriteWork.AcPaySlipCd = AcPaySlipCdData10;
                                            // 受払元伝票番号
                                            handyInspectDataWriteWork.AcPaySlipNum = stockDetailWork.SupplierSlipNo.ToString();
                                            // 受払元行番号
                                            handyInspectDataWriteWork.AcPaySlipRowNo = stockDetailWork.StockRowNo;
                                            // 受払元取引区分(固定値(10：通常仕入))
                                            handyInspectDataWriteWork.AcPayTransCd = AcPayTransCdData10;
                                            // 商品メーカーコード
                                            handyInspectDataWriteWork.GoodsMakerCd = inspectDataAddParamWork.GoodsMakerCd;
                                            // 商品番号
                                            handyInspectDataWriteWork.GoodsNo = inspectDataAddParamWork.GoodsNo;
                                            // 倉庫コード
                                            // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                                            //handyInspectDataWriteWork.WarehouseCode = inspectDataAddParamWork.WarehouseCode;
                                            if (String.IsNullOrEmpty(inspectDataAddParamWork.WarehouseCode.Trim()))
                                            {
                                                handyInspectDataWriteWork.WarehouseCode = ToriyoseWarehouseCd;
                                            }
                                            else
                                            {
                                                handyInspectDataWriteWork.WarehouseCode = inspectDataAddParamWork.WarehouseCode;
                                            }
                                            // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                                            // 検品ステータス
                                            handyInspectDataWriteWork.InspectStatus = inspectDataAddParamWork.InspectStatus;
                                            // 検品区分
                                            handyInspectDataWriteWork.InspectCode = inspectDataAddParamWork.InspectCode;
                                            // 検品数
                                            handyInspectDataWriteWork.InspectCnt = inspectDataAddParamWork.InspectCnt;
                                            // ハンディターミナル区分(固定値(1:ハンディターミナル))
                                            handyInspectDataWriteWork.HandTerminalCode = HandTerminalCodeData1;
                                            // 端末名称
                                            handyInspectDataWriteWork.MachineName = inspectDataAddParamWork.MachineName;
                                            // 従業員コード
                                            handyInspectDataWriteWork.EmployeeCode = inspectDataAddParamWork.EmployeeCode;

                                            inspectDataWriteList.Add(handyInspectDataWriteWork);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // 検品登録リストがある場合、登録します。
                if (inspectDataWriteList.Count > 0)
                {
                    InspectDataDB inspectDataDBAdapter = new InspectDataDB();
                    status = inspectDataDBAdapter.WriteInspectDataProc(ref inspectDataWriteList, ref sqlConnection, ref sqlTransaction, InspectWriteModeData0);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.WriteStockSupplier" + ex.Message, status);
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // トランザクションをコミットする
                    sqlTransaction.Commit();
                }
                else
                {
                    // トランザクションをロールバックする
                    sqlTransaction.Rollback();
                }

                sqlTransaction.Dispose();
                sqlTransaction = null;

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }
        #endregion

        #region ハンディターミナル在庫仕入(UOE以外)明細抽出処理
        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)明細抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchNonUOEStockSupplier(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyNonUOEStockParamWork condWork = (HandyNonUOEStockParamWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyNonUOEStockParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockSupplierDB.SearchNonUOEStockSupplier" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyNonUOEList = null;
                status = SearchNonUOEStockSupplierProc(condWork, out handyNonUOEList, ref sqlConnection);

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyNonUOEList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchNonUOEStockSupplier" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyNonUOEList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchNonUOEStockSupplierProc(HandyNonUOEStockParamWork condWork, out ArrayList handyNonUOEList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyNonUOEList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" STOCKSLIPRF.SUPPLIERSNMRF, ");
                sb.AppendLine(" STOCKSLIPRF.SUPPLIERFORMALRF, ");
                sb.AppendLine(" STOCKSLIPRF.SUPPLIERSLIPNORF, ");
                sb.AppendLine(" STOCKDETAILRF.STOCKSLIPDTLNUMRF, ");
                sb.AppendLine(" STOCKDETAILRF.STOCKROWNORF, ");
                sb.AppendLine(" STOCKDETAILRF.GOODSMAKERCDRF, ");
                sb.AppendLine(" STOCKDETAILRF.GOODSNORF, ");
                sb.AppendLine(" STOCKDETAILRF.GOODSNAMERF, ");
                sb.AppendLine(" STOCKDETAILRF.WAREHOUSECODERF, ");
                sb.AppendLine(" STOCKDETAILRF.WAREHOUSESHELFNORF, ");
                sb.AppendLine(" STOCKDETAILRF.WAYTOORDERRF, ");
                sb.AppendLine(" STOCKDETAILRF.ORDERREMAINCNTRF, ");
                sb.AppendLine(" GOODSBARCODEREVNRF.GOODSBARCODERF ");
                sb.AppendLine("FROM STOCKSLIPRF WITH (READUNCOMMITTED) ");
                // 仕入明細データ
                sb.AppendLine(" INNER JOIN STOCKDETAILRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON STOCKSLIPRF.ENTERPRISECODERF = STOCKDETAILRF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKSLIPRF.LOGICALDELETECODERF = STOCKDETAILRF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERFORMALRF = STOCKDETAILRF.SUPPLIERFORMALRF ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERSLIPNORF = STOCKDETAILRF.SUPPLIERSLIPNORF ");
                // 商品バーコード関連付けマスタ
                sb.AppendLine(" LEFT JOIN GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON STOCKDETAILRF.ENTERPRISECODERF = GOODSBARCODEREVNRF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKDETAILRF.LOGICALDELETECODERF = GOODSBARCODEREVNRF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKDETAILRF.GOODSMAKERCDRF = GOODSBARCODEREVNRF.GOODSMAKERCDRF ");
                sb.AppendLine(" AND STOCKDETAILRF.GOODSNORF = GOODSBARCODEREVNRF.GOODSNORF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" STOCKSLIPRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND STOCKSLIPRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO ");
                sb.AppendLine(" AND STOCKDETAILRF.WAYTOORDERRF = @FINDWAYTOORDER ");
                sb.AppendLine(" AND STOCKDETAILRF.ORDERREMAINCNTRF > @FINDORDERREMAINCNT ");
                sb.AppendLine(" ORDER BY STOCKDETAILRF.STOCKROWNORF ");

                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // 仕入形式「2:発注」固定
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(SupplierFormalData2);
                // 仕入伝票番号
                SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(condWork.SlipNo);
                // 注文方法「0:発注書発注」固定
                SqlParameter findWayToOrder = sqlCommand.Parameters.Add("@FINDWAYTOORDER", SqlDbType.Int);
                findWayToOrder.Value = SqlDataMediator.SqlSetInt32(WayToOrderData0);
                // 発注残数「>0」固定
                SqlParameter findOrderRemainCnt = sqlCommand.Parameters.Add("@FINDORDERREMAINCNT", SqlDbType.Int);
                findOrderRemainCnt.Value = SqlDataMediator.SqlSetInt32(OrderRemainCntData0);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyNonUOEList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // 発注情報を設定します。
                    handyNonUOEList.Add(this.CopyToHandyNonUOEListWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchNonUOEStockSupplierProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyNonUOEStockResultWork
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル在庫仕入(UOE以外)明細情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private HandyNonUOEStockResultWork CopyToHandyNonUOEListWorkFromReader(ref SqlDataReader myReader)
        {
            HandyNonUOEStockResultWork handyNonUOEStockResultWork = new HandyNonUOEStockResultWork();

            #region クラスへ格納
            handyNonUOEStockResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                           // 仕入データ．仕入先略称
            handyNonUOEStockResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));                          // 仕入明細データ．商品メーカーコード
            handyNonUOEStockResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));                                   // 仕入明細データ．商品番号
            handyNonUOEStockResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));                               // 仕入明細データ．商品名称
            handyNonUOEStockResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));                       // 仕入明細データ．倉庫コード
            handyNonUOEStockResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));                 // 仕入明細データ．倉庫棚番
            handyNonUOEStockResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));                         // 仕入明細データ．発注残数
            handyNonUOEStockResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));                    // 仕入明細データ．仕入明細通番
            handyNonUOEStockResultWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSBARCODERF"));                         // 商品バーコード関連付けマスタ.商品バーコード
            #endregion

            return handyNonUOEStockResultWork;
        }
        #endregion

        #region ハンディターミナル在庫仕入(UOE以外)伝票情報抽出処理
        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)伝票情報抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)伝票情報情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyNonUOESlipInfo(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyNonUOEInspectParamWork condWork = (HandyNonUOEInspectParamWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyNonUOEInspectParamWork));
                // 検索ワークが作成できないの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyStockSupplierDB.SearchHandyNonUOESlipInfo" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handyNonUOESlipInfoList = null;
                status = SearchHandyNonUOESlipInfoProc(condWork, out handyNonUOESlipInfoList, ref sqlConnection);

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handyNonUOESlipInfoList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchHandyNonUOESlipInfo" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyNonUOESlipInfoList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchHandyNonUOESlipInfoProc(HandyNonUOEInspectParamWork condWork, out ArrayList handyNonUOESlipInfoList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyNonUOESlipInfoList = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" STOCKSLIPRF.DEBITNOTEDIVRF ");
                sb.AppendLine(" ,STOCKSLIPRF.SUPPLIERSLIPCDRF ");
                sb.AppendLine(" ,STOCKSLIPRF.PARTYSALESLIPNUMRF ");
                sb.AppendLine(" ,STOCKSLIPRF.INPUTDAYRF ");
                sb.AppendLine(" ,STOCKDETAILRF.ACCEPTANORDERNORF");
                sb.AppendLine(" ,STOCKDETAILRF.SUPPLIERFORMALRF");
                sb.AppendLine(" ,STOCKDETAILRF.SUPPLIERSLIPNORF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKROWNORF");
                sb.AppendLine(" ,STOCKDETAILRF.SECTIONCODERF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKAGENTCODERF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKAGENTNAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKINPUTCODERF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKINPUTNAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.GOODSMAKERCDRF");
                sb.AppendLine(" ,STOCKDETAILRF.MAKERNAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.GOODSNORF");
                sb.AppendLine(" ,STOCKDETAILRF.GOODSNAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.GOODSNAMEKANARF");
                sb.AppendLine(" ,STOCKDETAILRF.BLGOODSCODERF");
                sb.AppendLine(" ,STOCKDETAILRF.BLGOODSFULLNAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.WAREHOUSECODERF");
                sb.AppendLine(" ,STOCKDETAILRF.WAREHOUSENAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.WAREHOUSESHELFNORF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKORDERDIVCDRF");
                sb.AppendLine(" ,STOCKDETAILRF.LISTPRICETAXEXCFLRF");
                sb.AppendLine(" ,STOCKDETAILRF.LISTPRICETAXINCFLRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKUNITPRICEFLRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKUNITTAXPRICEFLRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKPRICECONSTAXRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKCOUNTRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKPRICETAXEXCRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKPRICETAXINCRF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKDTISLIPNOTE1RF");
                sb.AppendLine(" ,STOCKDETAILRF.SALESCUSTOMERCODERF");
                sb.AppendLine(" ,STOCKDETAILRF.SALESCUSTOMERSNMRF");
                sb.AppendLine(" ,STOCKDETAILRF.SUPPLIERCDRF");
                sb.AppendLine(" ,STOCKDETAILRF.SUPPLIERSNMRF");
                sb.AppendLine(" ,STOCKDETAILRF.ADDRESSEECODERF");
                sb.AppendLine(" ,STOCKDETAILRF.ADDRESSEENAMERF");
                sb.AppendLine(" ,STOCKDETAILRF.REMAINCNTUPDDATERF");
                sb.AppendLine(" ,STOCKDETAILRF.DIRECTSENDINGCDRF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERNUMBERRF");
                sb.AppendLine(" ,STOCKDETAILRF.WAYTOORDERRF");
                sb.AppendLine(" ,STOCKDETAILRF.DELIGDSCMPLTDUEDATERF");
                sb.AppendLine(" ,STOCKDETAILRF.EXPECTDELIVERYDATERF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERCNTRF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERADJUSTCNTRF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERREMAINCNTRF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERFORMISSUEDDIVRF");
                sb.AppendLine(" ,STOCKDETAILRF.ORDERDATACREATEDATERF");
                sb.AppendLine(" ,STOCKDETAILRF.SLIPMEMO1RF");
                sb.AppendLine(" ,STOCKDETAILRF.SLIPMEMO2RF");
                sb.AppendLine(" ,STOCKDETAILRF.SLIPMEMO3RF");
                sb.AppendLine(" ,STOCKDETAILRF.INSIDEMEMO1RF");
                sb.AppendLine(" ,STOCKDETAILRF.INSIDEMEMO2RF");
                sb.AppendLine(" ,STOCKDETAILRF.INSIDEMEMO3RF");
                sb.AppendLine(" ,STOCKDETAILRF.STOCKSLIPDTLNUMRF ");
                sb.AppendLine(" ,STOCKSLIPRF.SUPPCTAXLAYCDRF ");
                sb.AppendLine(" ,STOCKSLIPRF.SUPPTTLAMNTDSPWAYCDRF ");
                sb.AppendLine(" ,STOCKDETAILRF.TAXATIONCODERF ");
                // 仕入データ
                sb.AppendLine("FROM STOCKSLIPRF WITH (READUNCOMMITTED) ");
                // 仕入明細データ
                sb.AppendLine(" INNER JOIN STOCKDETAILRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON STOCKSLIPRF.ENTERPRISECODERF = STOCKDETAILRF.ENTERPRISECODERF ");
                sb.AppendLine(" AND STOCKSLIPRF.LOGICALDELETECODERF = STOCKDETAILRF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERFORMALRF = STOCKDETAILRF.SUPPLIERFORMALRF ");
                sb.AppendLine(" AND STOCKSLIPRF.SUPPLIERSLIPNORF = STOCKDETAILRF.SUPPLIERSLIPNORF ");
                sb.AppendLine(" AND STOCKDETAILRF.WAYTOORDERRF = @FINDWAYTOORDER ");
                sb.AppendLine(" AND STOCKDETAILRF.ORDERREMAINCNTRF > @FINDORDERREMAINCNT ");
                sb.AppendLine(" WHERE ");
                sb.AppendLine("  STOCKSLIPRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine("  AND STOCKSLIPRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine("  AND STOCKSLIPRF.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL ");
                sb.AppendLine("  AND STOCKSLIPRF.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO ");

                sb.AppendLine(" ORDER BY STOCKDETAILRF.STOCKROWNORF ");


                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);
                // 仕入形式「2:発注」固定
                SqlParameter findSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                findSupplierFormal.Value = SqlDataMediator.SqlSetInt32(SupplierFormalData2);
                // 仕入伝票番号
                SqlParameter findSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                findSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(condWork.SupplierSlipNo);
                // 注文方法「0:発注書発注」固定
                SqlParameter findWayToOrder = sqlCommand.Parameters.Add("@FINDWAYTOORDER", SqlDbType.Int);
                findWayToOrder.Value = SqlDataMediator.SqlSetInt32(WayToOrderData0);
                // 発注残数「>0」固定
                SqlParameter findOrderRemainCnt = sqlCommand.Parameters.Add("@FINDORDERREMAINCNT", SqlDbType.Int);
                findOrderRemainCnt.Value = SqlDataMediator.SqlSetInt32(OrderRemainCntData0);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                handyNonUOESlipInfoList = new ArrayList();

                // データが存在する場合
                while (myReader.Read())
                {
                    // 発注情報を設定します。
                    handyNonUOESlipInfoList.Add(this.CopyToHandyNonUOESlipInfoListWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.SearchNonUOEStockSupplierProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → OrderListResultWork
        /// </summary>
        /// <param name="myReader">読込結果</param>
        /// <returns>ハンディターミナル在庫仕入(UOE以外)明細情報</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private OrderListResultWork CopyToHandyNonUOESlipInfoListWorkFromReader(ref SqlDataReader myReader)
        {
            OrderListResultWork wkOrderListResultWork = new OrderListResultWork();

            #region クラスへ格納
            wkOrderListResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkOrderListResultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkOrderListResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkOrderListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkOrderListResultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            wkOrderListResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkOrderListResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkOrderListResultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            wkOrderListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkOrderListResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkOrderListResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkOrderListResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkOrderListResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkOrderListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkOrderListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            wkOrderListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkOrderListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkOrderListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkOrderListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkOrderListResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkOrderListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkOrderListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkOrderListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkOrderListResultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            wkOrderListResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            wkOrderListResultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            wkOrderListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkOrderListResultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            wkOrderListResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkOrderListResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            wkOrderListResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            wkOrderListResultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            wkOrderListResultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            wkOrderListResultWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            wkOrderListResultWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            wkOrderListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkOrderListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkOrderListResultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            wkOrderListResultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            wkOrderListResultWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
            wkOrderListResultWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
            wkOrderListResultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            wkOrderListResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            wkOrderListResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
            wkOrderListResultWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
            wkOrderListResultWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
            wkOrderListResultWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
            wkOrderListResultWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
            wkOrderListResultWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));
            wkOrderListResultWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
            wkOrderListResultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            wkOrderListResultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            wkOrderListResultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            wkOrderListResultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            wkOrderListResultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            wkOrderListResultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            wkOrderListResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            wkOrderListResultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkOrderListResultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkOrderListResultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            #endregion

            return wkOrderListResultWork;
        }
        #endregion

        #region ハンディターミナル在庫仕入（UOE以外）_登録処理
        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_登録処理
        /// </summary>
        /// <param name="inspectListObj">検品登録オブジェクト</param>
        /// <param name="stockWriteDataListObj">発注登録オブジェクト</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int WriteHandyStockData(ref object inspectListObj, ref object stockWriteDataListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList inspectList = null;
            ArrayList stockWriteDataList = null;
            Dictionary<long, HandyNonUOEInspectParamWork> inspectDataDic = null;

            try
            {
                // 検品登録オブジェクトからArrayListを変換します
                if (inspectListObj is ArrayList)
                {
                    inspectList = inspectListObj as ArrayList;
                }

                // 発注登録オブジェクトからArrayListを変換します
                if (stockWriteDataListObj is ArrayList)
                {
                    stockWriteDataList = stockWriteDataListObj as ArrayList;
                }

                // 検品登録ArrayListがない場合
                if (inspectList == null || inspectList.Count == 0 || stockWriteDataList == null || stockWriteDataList.Count == 0)
                {
                    return status;
                }

                // 検品登録ディクショナリーの初期化
                inspectDataDic = new Dictionary<long, HandyNonUOEInspectParamWork>();

                // 検品登録ディクショナリーの作成（キー：仕入明細通番）
                foreach (HandyNonUOEInspectParamWork work in inspectList)
                {
                    if (!inspectDataDic.ContainsKey(work.StockSlipDtlNum))
                    {
                        inspectDataDic.Add(work.StockSlipDtlNum, work);
                    }
                }

                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが作成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);

                // 引数の一行目を取得します。
                HandyNonUOEInspectParamWork paramWork = (HandyNonUOEInspectParamWork)inspectList[0];

                string retMsg = string.Empty;
                HandyNonUOEInspectParamWork handyNonUOEInspectParamWork = null;
                HandyInspectDataWork handyInspectDataWriteWork = null;
                ArrayList inspectDataWriteList = new ArrayList();

                // 引数.仕入先伝票番号がNULLの場合
                if (string.IsNullOrEmpty(paramWork.PartySaleSlipNum.Trim()))
                {
                    // MAZAI04364RA.csのWriteメソッド(在庫調整データ情報を登録、更新(在庫仕入入力用:UOE以外))を呼出します。
                    StockAdjustDB stockAdjustDBAdapter = new StockAdjustDB();
                    status = stockAdjustDBAdapter.Write(ref stockWriteDataListObj, out retMsg, ref sqlConnection, ref sqlTransaction);

                    // 在庫調整データワークが作成できないの場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("HandyStockSupplierDB.WriteHandyStockData" + retMsg);
                        return status;
                    }

                    // 検品登録リストを作成します
                    for (int i = 0; i < stockWriteDataList.Count; i++)
                    {
                        ArrayList stockWriteDataSubList = stockWriteDataList[i] as ArrayList;
                        if (stockWriteDataSubList != null && stockWriteDataSubList.Count > 0)
                        {
                            //在庫調整明細データの場合
                            if (stockWriteDataSubList[0] is StockAdjustDtlWork)
                            {
                                foreach (StockAdjustDtlWork stockAdjustDtlWork in stockWriteDataSubList)
                                {
                                    // 引数.仕入明細通番により、仕入明細データ中に仕入形式（元）：「2:発注」且つ、仕入明細通番（元）と一致のレコードの仕入伝票番号と仕入行番号を取る。
                                    if (inspectDataDic.ContainsKey(stockAdjustDtlWork.StockSlipDtlNumSrc) && stockAdjustDtlWork.SupplierFormalSrc == SupplierFormalSrcData2)
                                    {
                                        handyNonUOEInspectParamWork = inspectDataDic[stockAdjustDtlWork.StockSlipDtlNumSrc];
                                        handyInspectDataWriteWork = new HandyInspectDataWork();
                                        // 企業コード
                                        handyInspectDataWriteWork.EnterpriseCode = handyNonUOEInspectParamWork.EnterpriseCode;
                                        // 受払元伝票区分(固定値(13:在庫仕入))
                                        handyInspectDataWriteWork.AcPaySlipCd = AcPaySlipCdData13;
                                        // 受払元伝票番号
                                        handyInspectDataWriteWork.AcPaySlipNum = stockAdjustDtlWork.StockAdjustSlipNo.ToString();
                                        // 受払元行番号
                                        handyInspectDataWriteWork.AcPaySlipRowNo = stockAdjustDtlWork.StockAdjustRowNo;
                                        // 受払元取引区分(固定値(10：通常仕入))
                                        handyInspectDataWriteWork.AcPayTransCd = AcPayTransCdData10;
                                        // 商品メーカーコード
                                        handyInspectDataWriteWork.GoodsMakerCd = handyNonUOEInspectParamWork.GoodsMakerCd;
                                        // 商品番号
                                        handyInspectDataWriteWork.GoodsNo = handyNonUOEInspectParamWork.GoodsNo;
                                        // 倉庫コード
                                        handyInspectDataWriteWork.WarehouseCode = handyNonUOEInspectParamWork.WarehouseCode;
                                        // 検品ステータス
                                        handyInspectDataWriteWork.InspectStatus = handyNonUOEInspectParamWork.InspectStatus;
                                        // 検品区分
                                        handyInspectDataWriteWork.InspectCode = handyNonUOEInspectParamWork.InspectCode;
                                        // 検品数
                                        handyInspectDataWriteWork.InspectCnt = handyNonUOEInspectParamWork.InspectCnt;
                                        // ハンディターミナル区分(固定値(1:ハンディターミナル))
                                        handyInspectDataWriteWork.HandTerminalCode = HandTerminalCodeData1;
                                        // 端末名称
                                        handyInspectDataWriteWork.MachineName = handyNonUOEInspectParamWork.MachineName;
                                        // 従業員コード
                                        handyInspectDataWriteWork.EmployeeCode = handyNonUOEInspectParamWork.EmployeeCode;

                                        inspectDataWriteList.Add(handyInspectDataWriteWork);
                                    }
                                }
                            }
                        }
                    }
                }
                // 検品データパラメータリストの一行目の仕入先伝票番号がNULLではないの場合
                else
                {
                    // DCHNB01864RA.csのWriteProcメソッドを呼出します。
                    IOWriteControlDB ioWriteControlDBAdapter = new IOWriteControlDB();
                    string retItemInfo = string.Empty;
                    SqlEncryptInfo sqlEncryptInfo = null;
                    status = ioWriteControlDBAdapter.WriteProc(ref stockWriteDataList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    // 伝票データワークが作成できないの場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("HandyStockSupplierDB.WriteHandyStockData" + retMsg);
                        return status;
                    }

                    StockDetailWork stockDetailWork = null;

                    // 検品登録リストを作成します
                    for (int i = 0; i < stockWriteDataList.Count; i++)
                    {
                        if ((object)stockWriteDataList[i] is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList list = (CustomSerializeArrayList)stockWriteDataList[i];
                            foreach (object obj in list)
                            {
                                if (obj is ArrayList)
                                {
                                    ArrayList arraylist = (ArrayList)obj;

                                    foreach (object subObj in arraylist)
                                    {
                                        if (subObj is StockDetailWork)
                                        {
                                            stockDetailWork = (StockDetailWork)subObj;
                                            // 引数.仕入明細通番により、仕入明細データ中に仕入形式（元）：「2:発注」且つ、仕入明細通番（元）と一致のレコードの仕入伝票番号と仕入行番号を取る。
                                            if (inspectDataDic.ContainsKey(stockDetailWork.StockSlipDtlNumSrc) && stockDetailWork.SupplierFormalSrc == SupplierFormalSrcData2)
                                            {
                                                handyNonUOEInspectParamWork = inspectDataDic[stockDetailWork.StockSlipDtlNumSrc];
                                                handyInspectDataWriteWork = new HandyInspectDataWork();
                                                // 企業コード
                                                handyInspectDataWriteWork.EnterpriseCode = handyNonUOEInspectParamWork.EnterpriseCode;
                                                // 受払元伝票区分(固定値(10:仕入))
                                                handyInspectDataWriteWork.AcPaySlipCd = AcPaySlipCdData10;
                                                // 受払元伝票番号
                                                handyInspectDataWriteWork.AcPaySlipNum = stockDetailWork.SupplierSlipNo.ToString();
                                                // 受払元行番号
                                                handyInspectDataWriteWork.AcPaySlipRowNo = stockDetailWork.StockRowNo;
                                                // 受払元取引区分(固定値(10：通常仕入))
                                                handyInspectDataWriteWork.AcPayTransCd = AcPayTransCdData10;
                                                // 商品メーカーコード
                                                handyInspectDataWriteWork.GoodsMakerCd = handyNonUOEInspectParamWork.GoodsMakerCd;
                                                // 商品番号
                                                handyInspectDataWriteWork.GoodsNo = handyNonUOEInspectParamWork.GoodsNo;
                                                // 倉庫コード
                                                handyInspectDataWriteWork.WarehouseCode = handyNonUOEInspectParamWork.WarehouseCode;
                                                // 検品ステータス
                                                handyInspectDataWriteWork.InspectStatus = handyNonUOEInspectParamWork.InspectStatus;
                                                // 検品区分
                                                handyInspectDataWriteWork.InspectCode = handyNonUOEInspectParamWork.InspectCode;
                                                // 検品数
                                                handyInspectDataWriteWork.InspectCnt = handyNonUOEInspectParamWork.InspectCnt;
                                                // ハンディターミナル区分(固定値(1:ハンディターミナル))
                                                handyInspectDataWriteWork.HandTerminalCode = HandTerminalCodeData1;
                                                // 端末名称
                                                handyInspectDataWriteWork.MachineName = handyNonUOEInspectParamWork.MachineName;
                                                // 従業員コード
                                                handyInspectDataWriteWork.EmployeeCode = handyNonUOEInspectParamWork.EmployeeCode;

                                                inspectDataWriteList.Add(handyInspectDataWriteWork);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // 検品登録リストがある場合
                if (inspectDataWriteList.Count > 0)
                {
                    InspectDataDB inspectDataDBAdapter = new InspectDataDB();
                    status = inspectDataDBAdapter.WriteInspectDataProc(ref inspectDataWriteList, ref sqlConnection, ref sqlTransaction, InspectWriteModeData0);
                    
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyStockSupplierDB.WriteHandyStockData" + ex.Message, status);
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // トランザクションをコミットする
                    sqlTransaction.Commit();
                }
                else
                {
                    // トランザクションをロールバックする
                    sqlTransaction.Rollback();
                }

                sqlTransaction.Dispose();
                sqlTransaction = null;

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// SQLコネクション生成処理
        /// </summary>
        /// <returns>SQLコネクション</returns>
        /// <remarks>
        /// <br>Note       : SQLコネクションを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandyStockSupplierDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
