//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2009/09/14  修正内容 : PM.NS-2-A・車輌管理
//　　　　　　　　　　　　　　　　　受注マスタ（車両）に車輌備考の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/04/27  修正内容 : 受注マスタ（車両）に自由検索型式固定番号配列の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/21  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタ（車両）READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: 2009/09/14  馮文雄</br>
    /// <br>             受注マスタ（車両）に車輌備考の追加</br>
    /// <br>Update Note: 2010/04/27  gaoyh</br>
    /// <br>             受注マスタ（車両）に自由検索型式固定番号配列の追加</br>
    /// </remarks>
    public class APAcceptOdrCarDB : RemoteDB
    {
        /// <summary>
        /// 受注マスタ（車両）READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APAcceptOdrCarDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="acceptOdrCarArrList">受注マスタ（車両）オブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ（車両）READLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchAcceptOdrCar(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList acceptOdrCarArrList, out string retMessage)
        {
            return SearchAcceptOdrCarProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  acceptOdrCarArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）の検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="acceptOdrCarArrList">受注マスタ（車両）オブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ（車両）READLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2009/09/14 馮文雄</br>
        /// <br>             受注マスタ（車両）に車輌備考の追加</br>
        /// 
        private int SearchAcceptOdrCarProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList acceptOdrCarArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            acceptOdrCarArrList = new ArrayList();
            APAcceptOdrCarWork acceptOdrCarWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";  // DEL 2009/09/14 車輌備考の追加により削除
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";  // ADD 2009/09/14 車輌備考の追加により追加 // DLL 2010/04/27
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF, FREESRCHMDLFXDNOARYRF FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";  // ADD 2010/04/24 自由検索型式固定番号配列を追加

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 受注マスタ（車両）用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    acceptOdrCarWork = new APAcceptOdrCarWork();

                    acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    acceptOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    acceptOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    acceptOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    acceptOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    acceptOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    acceptOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    acceptOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    acceptOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    acceptOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    acceptOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    acceptOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                    acceptOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                    acceptOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                    acceptOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                    acceptOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                    acceptOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                    acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                    acceptOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    acceptOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
                    acceptOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));
                    acceptOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    acceptOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    acceptOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    acceptOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    acceptOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));
                    acceptOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    acceptOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    acceptOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    acceptOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                    acceptOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                    acceptOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));
                    acceptOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                    acceptOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                    acceptOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    acceptOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));
                    acceptOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));
                    acceptOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));
                    acceptOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                    acceptOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                    acceptOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                    acceptOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                    acceptOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));

                    // ↓ 2009.05.25 liuyang add PVCS.95

                    byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));// フル型式固定番号配列

                    acceptOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

                    for (int idx = 0; idx < acceptOdrCarWork.FullModelFixedNoAry.Length; idx++)
                    {
                        acceptOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                    }

                    acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));// 装備オブジェクト配列
                    // ↑ 2009.05.25 liuyang add

                    // acceptOdrCarWork.FullModelFixedNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));
                    // acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));

                    acceptOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));  // ADD 2009/09/14

                    // --- ADD 2010/04/27 ---------->>>>>
                    // 自由検索型式固定番号配列
                    acceptOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
                    // --- ADD 2010/04/27 ----------<<<<<
                    acceptOdrCarArrList.Add(acceptOdrCarWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
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
*/
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateAcceptOdrCar(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateAcceptOdrCarProc(enterPriseCode, acceptOdrCarList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateAcceptOdrCarProc(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteAcceptOdrCar(enterPriseCode, acceptOdrCarList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertAcceptOdrCar(enterPriseCode, acceptOdrCarList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteAcceptOdrCar(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteAcceptOdrCarProc( enterPriseCode,  acceptOdrCarList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteAcceptOdrCarProc(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APAcceptOdrCarWork acceptOdrCarWork in acceptOdrCarList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAcceptAnOrderNo.Value = acceptOdrCarWork.AcceptAnOrderNo;
                findParaAcptAnOdrStatus.Value = acceptOdrCarWork.AcptAnOdrStatus;
                findParaDataInputSystem.Value = acceptOdrCarWork.DataInputSystem;

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                // 実行
                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertAcceptOdrCar(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertAcceptOdrCarProc( enterPriseCode,  acceptOdrCarList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        /// <br>Update Note: 2009/09/14 馮文雄</br>
        /// <br>             受注マスタ（車両）に車輌備考の追加</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        private int InsertAcceptOdrCarProc(string enterPriseCode, ArrayList acceptOdrCarList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APAcceptOdrCarWork acceptOdrWorkCar in acceptOdrCarList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // sqlText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY)";  // DEL 2009/09/14 車輌備考の追加により削除
                //sqlText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY, @CARNOTE)";  // ADD 2009/09/14 車輌備考の追加により追加 // DEL 2010/04/27
                //sqlText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF, FREESRCHMDLFXDNOARYRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY, @CARNOTE, @FREESRCHMDLFXDNOARY)";  // ADD 2010/04/27 自由検索型式固定番号配列を追加 // DEL 2013/03/21
                sqlText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF, FREESRCHMDLFXDNOARYRF, DOMESTICFOREIGNCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY, @CARNOTE, @FREESRCHMDLFXDNOARY, @DOMESTICFOREIGNCODE)";  // 国産/外車区分 // ADD 2013/03/21

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);
                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);
                SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);
                SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);
                SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);
                SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);
                SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);
                SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);
                SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);
                SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);
                SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);
                SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);
                SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);
                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
                SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);
                SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);
                SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);
                SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);
                SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);
                SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
                SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);
                SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);
                SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);
                SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);
                SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);
                SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);
                SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);
                SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);
                SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);
                SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);
                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);  // ADD 2009/09/14
                SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // ADD 2010/04/27
                SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);        // ADD 2013/03/21

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrWorkCar.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrWorkCar.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptOdrWorkCar.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.AcptAnOdrStatus);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.DataInputSystem);
                paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.CarMngNo);
                paraCarMngCode.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.CarMngCode);
                paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.NumberPlate1Code);
                paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.NumberPlate1Name);
                paraNumberPlate2.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.NumberPlate2);
                paraNumberPlate3.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.NumberPlate3);
                paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.NumberPlate4);
                paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(acceptOdrWorkCar.FirstEntryDate);
                paraMakerCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.MakerCode);
                paraMakerFullName.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.MakerFullName);
                paraMakerHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.MakerHalfName);
                paraModelCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.ModelCode);
                paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.ModelSubCode);
                paraModelFullName.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ModelFullName);
                paraModelHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ModelHalfName);
                paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ExhaustGasSign);
                paraSeriesModel.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.SeriesModel);
                paraCategorySignModel.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.CategorySignModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.FullModel);
                paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.ModelDesignationNo);
                paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.CategoryNo);
                paraFrameModel.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.FrameModel);
                paraFrameNo.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.FrameNo);
                paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.SearchFrameNo);
                paraEngineModelNm.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.EngineModelNm);
                paraRelevanceModel.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.RelevanceModel);
                paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.SubCarNmCd);
                paraModelGradeSname.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ModelGradeSname);
                paraColorCode.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ColorCode);
                paraColorName1.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.ColorName1);
                paraTrimCode.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.TrimCode);
                paraTrimName.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.TrimName);
                paraMileage.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.Mileage);

                // ↓ 2009.05.25 liuyang add PVCS.95
                // int[] → byte[] に変換
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                foreach (int item in acceptOdrWorkCar.FullModelFixedNoAry)
                    ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                byte[] verbinary = ms.ToArray();
                ms.Close();

                paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                               // フル型式固定番号配列

                paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrWorkCar.CategoryObjAry);              // 装備オブジェクト配列
                // ↑ 2009.05.25 liuyang add

                // paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrWorkCar.FullModelFixedNoAry);
                // paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrWorkCar.CategoryObjAry);

                paraCarNote.Value = SqlDataMediator.SqlSetString(acceptOdrWorkCar.CarNote);  // ADD 2009/09/14
                // --- ADD 2010/04/27 ---------->>>>>
                // 自由検索型式固定番号配列
                paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrWorkCar.FreeSrchMdlFxdNoAry);
                // --- ADD 2010/04/27 ----------<<<<<
                paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrWorkCar.DomesticForeignCode);    // 国産/外車区分 // ADD 2013/03/21

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → acceptOdrCarWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public APAcceptOdrCarWork CopyToAcceptOdrCarWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APAcceptOdrCarWork acceptOdrCarWork = new APAcceptOdrCarWork();

			this.CopyToAcceptOdrCarWorkFromReaderSCM(ref myReader, ref acceptOdrCarWork, tableNm);

			return acceptOdrCarWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → acceptOdrCarWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="acceptOdrCarWork">acceptOdrCarWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
		private void CopyToAcceptOdrCarWorkFromReaderSCM(ref SqlDataReader myReader, ref APAcceptOdrCarWork acceptOdrCarWork, string tableNm)
		{
			if (myReader != null && acceptOdrCarWork != null)
			{
				# region クラスへ格納

				acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				acceptOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				acceptOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				acceptOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				acceptOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				acceptOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				acceptOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				acceptOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				acceptOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				acceptOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DATAINPUTSYSTEMRF"));
				acceptOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CARMNGNORF"));
				acceptOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CARMNGCODERF"));
				acceptOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "NUMBERPLATE1CODERF"));
				acceptOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "NUMBERPLATE1NAMERF"));
				acceptOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "NUMBERPLATE2RF"));
				acceptOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "NUMBERPLATE3RF"));
				acceptOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "NUMBERPLATE4RF"));
				acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal(tableNm + "FIRSTENTRYDATERF"));
				acceptOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MAKERCODERF"));
				acceptOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERFULLNAMERF"));
				acceptOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERHALFNAMERF"));
				acceptOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MODELCODERF"));
				acceptOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MODELSUBCODERF"));
				acceptOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MODELFULLNAMERF"));
				acceptOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MODELHALFNAMERF"));
				acceptOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "EXHAUSTGASSIGNRF"));
				acceptOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SERIESMODELRF"));
				acceptOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CATEGORYSIGNMODELRF"));
				acceptOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FULLMODELRF"));
				acceptOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MODELDESIGNATIONNORF"));
				acceptOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CATEGORYNORF"));
				acceptOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRAMEMODELRF"));
				acceptOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRAMENORF"));
				acceptOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SEARCHFRAMENORF"));
				acceptOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENGINEMODELNMRF"));
				acceptOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RELEVANCEMODELRF"));
				acceptOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBCARNMCDRF"));
				acceptOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MODELGRADESNAMERF"));
				acceptOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "COLORCODERF"));
				acceptOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "COLORNAME1RF"));
				acceptOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "TRIMCODERF"));
				acceptOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "TRIMNAMERF"));
				acceptOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "MILEAGERF"));
				byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal(tableNm + "FULLMODELFIXEDNOARYRF"));                       // フル型式固定番号配列
				if (varbinary != null)
				{
					acceptOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

					for (int idx = 0; idx < acceptOdrCarWork.FullModelFixedNoAry.Length; idx++)
					{
						acceptOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
					}
				}
				acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal(tableNm + "CATEGORYOBJARYRF"));             // 装備オブジェクト配列

				acceptOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CARNOTERF"));
				// 自由検索型式固定番号配列
				acceptOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal(tableNm + "FREESRCHMDLFXDNOARYRF"));
				acceptOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DOMESTICFOREIGNCODERF"));              // 国産/外車区分 // ADD 2013/03/21
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}
