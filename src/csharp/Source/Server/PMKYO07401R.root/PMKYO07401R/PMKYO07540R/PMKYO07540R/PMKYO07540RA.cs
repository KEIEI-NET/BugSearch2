//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄偉兵
// 修 正 日  2009/09/08  修正内容 : PM.NS-2-A・車輌管理
//　　　　　　　　　　　　　　　　　受注マスタ（車両）に車輌備考の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 修 正 日  2010/04/27  修正内容 : 受注マスタ（車両）に自由検索型式固定番号配列の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/21  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタ（車両）リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払明細マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note  : 2009/09/08 黄偉兵</br>
    /// <br>               PM.NS-2-A・車輌管理</br>
    /// <br>               受注マスタ（車両）に車輌備考の追加</br>
    /// <br>Update Note  : 2010/04/27 gaoyh</br>
    /// <br>               受注マスタ（車両）に自由検索型式固定番号配列の追加</br>
    /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Programmer : FSI厚川 宏</br>
    /// <br>Date       : 2013/03/21</br>
    /// </remarks>
    [Serializable]
    public class DCAcceptOdrCarDB : RemoteDB
    {
        /// <summary>
        /// 受注マスタ（車両）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCAcceptOdrCarDB()
            : base("PMKYO07541D", "Broadleaf.Application.Remoting.ParamData.DCAcceptOdrCarWork", "ACCEPTODRCARRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）データ取得
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ（車両）データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList acceptOdrCarList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  acceptOdrCarList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）データ取得
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ（車両）データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 黄偉兵　受注マスタ（車両）に車輌備考の追加</br>
        /// </remarks>
        /// <returns></returns>
        private int SearchProc(out ArrayList acceptOdrCarList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            acceptOdrCarList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            // sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF FROM ACCEPTODRCARRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE"; //DEL 2009/09/08
            //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF FROM ACCEPTODRCARRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE"; // ADD 2009/09/08 // DEL 2010/04/27
            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF, CARNOTERF, FREESRCHMDLFXDNOARYRF FROM ACCEPTODRCARRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE"; // ADD 2010/04/27

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL文
			sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                acceptOdrCarList.Add(this.CopyToAcceptOdrCarWorkFromReader(ref myReader));
            }

            if (acceptOdrCarList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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

        /// <summary>
        /// クラス格納処理 Reader → acceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private DCAcceptOdrCarWork CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader)
        {
            DCAcceptOdrCarWork acceptOdrCarWork = new DCAcceptOdrCarWork();

			this.CopyToAcceptOdrCarWorkFromReader(ref myReader, ref acceptOdrCarWork);

            return acceptOdrCarWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → acceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="acceptOdrCarWork">acceptOdrCarWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note: 2009/09/08 黄偉兵　受注マスタ（車両）に車輌備考の追加</br>
        /// </remarks>
		private void CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader, ref DCAcceptOdrCarWork acceptOdrCarWork)
        {
            if (myReader != null && acceptOdrCarWork != null)
            {
				# region クラスへ格納
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

				// ↓ 2009.05.25 liuyang add PVCS 95
				byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                       // フル型式固定番号配列

				acceptOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

				for (int idx = 0; idx < acceptOdrCarWork.FullModelFixedNoAry.Length; idx++)
				{
					acceptOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
				}

				acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));             // 装備オブジェクト配列
				// ↑ 2009.05.25 liuyang add
				acceptOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF")); // ADD 2009/09/08
				// acceptOdrCarWork.FullModelFixedNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal(tableNm+"FULLMODELFIXEDNOARYRF"));
				// acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal(tableNm+"CATEGORYOBJARYRF"));
				// --- ADD 2010/04/27 ---------->>>>>
				// 自由検索型式固定番号配列
				acceptOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
				// --- ADD 2010/04/27 ----------<<<<<
				# endregion
            }
        }
		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → acceptOdrCarWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public DCAcceptOdrCarWork CopyToAcceptOdrCarWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCAcceptOdrCarWork acceptOdrCarWork = new DCAcceptOdrCarWork();

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
		private void CopyToAcceptOdrCarWorkFromReaderSCM(ref SqlDataReader myReader, ref DCAcceptOdrCarWork acceptOdrCarWork, string tableNm)
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
                acceptOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DOMESTICFOREIGNCODERF"));    // 国産/外車区分 // ADD 2013/03/21
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）削除
        /// </summary>
        /// <param name="dcAcceptOdrCarWorkList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcAcceptOdrCarWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcAcceptOdrCarWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）削除
        /// </summary>
        /// <param name="dcAcceptOdrCarWorkList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcAcceptOdrCarWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCAcceptOdrCarWork dcAcceptOdrCarWork in dcAcceptOdrCarWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcAcceptOdrCarWork.EnterpriseCode;
                findParaAcceptAnOrderNo.Value = dcAcceptOdrCarWork.AcceptAnOrderNo;
                findParaAcptAnOdrStatus.Value = dcAcceptOdrCarWork.AcptAnOdrStatus;
                findParaDataInputSystem.Value = dcAcceptOdrCarWork.DataInputSystem;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受注マスタ（車両）を削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 受注マスタ（車両）登録
        /// </summary>
        /// <param name="dcAcceptOdrCarWorkList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcAcceptOdrCarWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcAcceptOdrCarWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 受注マスタ（車両）登録
        /// </summary>
        /// <param name="dcAcceptOdrCarWorkList">受注マスタ（車両）</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 黄偉兵　受注マスタ（車両）に車輌備考の追加</br>
        /// </remarks>
        /// <returns></returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        private void InsertProc(ArrayList dcAcceptOdrCarWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCAcceptOdrCarWork dcAcceptOdrCarWork in dcAcceptOdrCarWorkList)
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                // sqlCommand.CommandText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY)"; // DEL 2009/09/08
                //sqlCommand.CommandText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF,CARNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY,@CARNOTE)"; // ADD 2009/09/08 // DEL 2010/04/27
                //sqlCommand.CommandText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF,CARNOTERF, FREESRCHMDLFXDNOARYRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY,@CARNOTE, @FREESRCHMDLFXDNOARY)"; // ADD 2010/04/27 // DEL 2013/03/21
                sqlCommand.CommandText = "INSERT INTO ACCEPTODRCARRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, DATAINPUTSYSTEMRF, CARMNGNORF, CARMNGCODERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, FIRSTENTRYDATERF, MAKERCODERF, MAKERFULLNAMERF, MAKERHALFNAMERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, EXHAUSTGASSIGNRF, SERIESMODELRF, CATEGORYSIGNMODELRF, FULLMODELRF, MODELDESIGNATIONNORF, CATEGORYNORF, FRAMEMODELRF, FRAMENORF, SEARCHFRAMENORF, ENGINEMODELNMRF, RELEVANCEMODELRF, SUBCARNMCDRF, MODELGRADESNAMERF, COLORCODERF, COLORNAME1RF, TRIMCODERF, TRIMNAMERF, MILEAGERF, FULLMODELFIXEDNOARYRF, CATEGORYOBJARYRF,CARNOTERF, FREESRCHMDLFXDNOARYRF, DOMESTICFOREIGNCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @DATAINPUTSYSTEM, @CARMNGNO, @CARMNGCODE, @NUMBERPLATE1CODE, @NUMBERPLATE1NAME, @NUMBERPLATE2, @NUMBERPLATE3, @NUMBERPLATE4, @FIRSTENTRYDATE, @MAKERCODE, @MAKERFULLNAME, @MAKERHALFNAME, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @EXHAUSTGASSIGN, @SERIESMODEL, @CATEGORYSIGNMODEL, @FULLMODEL, @MODELDESIGNATIONNO, @CATEGORYNO, @FRAMEMODEL, @FRAMENO, @SEARCHFRAMENO, @ENGINEMODELNM, @RELEVANCEMODEL, @SUBCARNMCD, @MODELGRADESNAME, @COLORCODE, @COLORNAME1, @TRIMCODE, @TRIMNAME, @MILEAGE, @FULLMODELFIXEDNOARY, @CATEGORYOBJARY,@CARNOTE, @FREESRCHMDLFXDNOARY, @DOMESTICFOREIGNCODE)"; // 国産/外車区分 // ADD 2013/03/21
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
                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar); // ADD 2009/09/08
                SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // ADD 2010/04/27
                SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);        // ADD 2013/03/21

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcAcceptOdrCarWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcAcceptOdrCarWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcAcceptOdrCarWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.AcptAnOdrStatus);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.DataInputSystem);
                paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.CarMngNo);
                paraCarMngCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.CarMngCode);
                paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.NumberPlate1Code);
                paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.NumberPlate1Name);
                paraNumberPlate2.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.NumberPlate2);
                paraNumberPlate3.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.NumberPlate3);
                paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.NumberPlate4);
                paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(dcAcceptOdrCarWork.FirstEntryDate);
                paraMakerCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.MakerCode);
                paraMakerFullName.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.MakerFullName);
                paraMakerHalfName.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.MakerHalfName);
                paraModelCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.ModelCode);
                paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.ModelSubCode);
                paraModelFullName.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ModelFullName);
                paraModelHalfName.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ModelHalfName);
                paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ExhaustGasSign);
                paraSeriesModel.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.SeriesModel);
                paraCategorySignModel.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.CategorySignModel);
                paraFullModel.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.FullModel);
                paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.ModelDesignationNo);
                paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.CategoryNo);
                paraFrameModel.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.FrameModel);
                paraFrameNo.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.FrameNo);
                paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.SearchFrameNo);
                paraEngineModelNm.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.EngineModelNm);
                paraRelevanceModel.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.RelevanceModel);
                paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.SubCarNmCd);
                paraModelGradeSname.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ModelGradeSname);
                paraColorCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ColorCode);
                paraColorName1.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.ColorName1);
                paraTrimCode.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.TrimCode);
                paraTrimName.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.TrimName);
                paraMileage.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.Mileage);
                paraCarNote.Value = SqlDataMediator.SqlSetString(dcAcceptOdrCarWork.CarNote); // ADD 2009/09/08

                // ↓ 2009.05.25 liuyang add PVCS.95
                // int[] → byte[] に変換
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                foreach (int item in dcAcceptOdrCarWork.FullModelFixedNoAry)
                    ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                byte[] verbinary = ms.ToArray();
                ms.Close();

                paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                               // フル型式固定番号配列

                paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(dcAcceptOdrCarWork.CategoryObjAry);              // 装備オブジェクト配列
                // ↑ 2009.05.25 liuyang add

                // paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(dcAcceptOdrCarWork.FullModelFixedNoAry);
                // paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(dcAcceptOdrCarWork.CategoryObjAry);

                // --- ADD 2010/04/27 ---------->>>>>
                // 自由検索型式固定番号配列
                paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(dcAcceptOdrCarWork.FreeSrchMdlFxdNoAry);
                // --- ADD 2010/04/27 ----------<<<<<
                paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(dcAcceptOdrCarWork.DomesticForeignCode);    // 国産/外車区分 // ADD 2013/03/21

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 受注マスタ（車両）を登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [Clear]
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
            //sqlCommand.CommandText = "DELETE FROM ACCEPTODRCARRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM ACCEPTODRCARRF WHERE   EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT ACCEPTODRCARRF.ACCEPTANORDERNORF FROM SALESDETAILRF,SALESSLIPRF,ACCEPTODRRF WHERE SALESSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.ENTERPRISECODERF = SALESDETAILRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.ACPTANODRSTATUSRF = SALESDETAILRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.SALESSLIPNUMRF = SALESDETAILRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESDETAILRF.ENTERPRISECODERF = ACCEPTODRRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND ((SALESDETAILRF.ACPTANODRSTATUSRF = 10 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 1) ").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 20 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 3) ").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 30 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 7) ").Append(Environment.NewLine);
            sb.Append(" OR (SALESDETAILRF.ACPTANODRSTATUSRF = 40 AND ACCEPTODRRF.ACPTANODRSTATUSRF = 5)) ").Append(Environment.NewLine);
            sb.Append(" AND SALESDETAILRF.SALESSLIPNUMRF = ACCEPTODRRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESSLIPRF.RESULTSADDUPSECCDRF = @FINDSECTIONCODERF ").Append(Environment.NewLine);
            sb.Append(" AND ACCEPTODRRF.ENTERPRISECODERF = ACCEPTODRCARRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND ACCEPTODRRF.ACPTANODRSTATUSRF = ACCEPTODRCARRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND ACCEPTODRRF.ACCEPTANORDERNORF =ACCEPTODRCARRF.ACCEPTANORDERNORF)  ").Append(Environment.NewLine);
            sqlCommand.CommandText = sb.ToString();
            
            //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameterオブジェクトへ値設定
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 張莉莉 ----------<<<<<
    }
}
