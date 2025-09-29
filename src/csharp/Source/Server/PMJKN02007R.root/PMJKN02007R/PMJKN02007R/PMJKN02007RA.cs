//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ印刷
// プログラム概要   : 自由検索型式マスタ印刷 リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索型式マスタ印刷 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタ印刷READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchModelPrintDB : RemoteWithAppLockDB, IFreeSearchModelPrintDB
    {
        # region ■ Constructor ■
        /// <summary>
        /// 自由検索型式マスタ印刷 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ印刷READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchModelPrintDB()
            :
        base("PMJKN02009D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelPrintWork", "FREESEARCHMODELPRINTWORK") //基底クラスのコンストラクタ
        {
        }
        #endregion


        #region ■ 自由検索型式マスタ検索処理 ■
        /// <summary>
        /// 自由検索型式マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索型式マスタ（印刷）条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public int SearchAll(object paraWork, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                status = SearchAllProc(out retList, paraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreeSearchModelPrintDB.SearchAll");
                retList = new ArrayList();
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

            return status;
        }

        /// <summary>
        /// 自由検索型式マスタデータを全て戻します
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自由検索型式マスタデータLISTを全て戻します</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        private int SearchAllProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchModelParaWork freeSearchModelParaWork = paraWork as FreeSearchModelParaWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //抽出結果

            //型式（フル型）
            string modelName = freeSearchModelParaWork.ModelName;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" F.CREATEDATETIMERF, ");//作成日時
                sb.Append(" F.UPDATEDATETIMERF, ");//更新日時
                sb.Append(" F.ENTERPRISECODERF, ");//企業コード
                sb.Append(" F.FILEHEADERGUIDRF, ");//GUID
                sb.Append(" F.UPDEMPLOYEECODERF, ");//更新従業員コード
                sb.Append(" F.UPDASSEMBLYID1RF, ");//更新アセンブリID1
                sb.Append(" F.UPDASSEMBLYID2RF, ");//更新アセンブリID2
                sb.Append(" F.LOGICALDELETECODERF, ");//論理削除区分
                sb.Append(" F.FREESRCHMDLFXDNORF, ");//自由検索型式固定番号
                sb.Append(" F.MAKERCODERF, ");//メーカーコード
                sb.Append(" F.MODELCODERF, ");//車種コード
                sb.Append(" F.MODELSUBCODERF, ");//車種サブコード
                sb.Append(" F.EXHAUSTGASSIGNRF, ");//排ガス記号
                sb.Append(" F.SERIESMODELRF, ");//シリーズ型式
                sb.Append(" F.CATEGORYSIGNMODELRF, ");//型式（類別記号）
                sb.Append(" F.FULLMODELRF, ");//型式（フル型）
                sb.Append(" F.MODELDESIGNATIONNORF, ");//型式指定番号
                sb.Append(" F.CATEGORYNORF, ");//類別番号
                sb.Append(" F.STPRODUCETYPEOFYEARRF, ");//開始生産年式
                sb.Append(" F.EDPRODUCETYPEOFYEARRF, ");//終了生産年式
                sb.Append(" F.STPRODUCEFRAMENORF, ");//生産車台番号開始
                sb.Append(" F.EDPRODUCEFRAMENORF, ");//生産車台番号終了
                sb.Append(" F.MODELGRADENMRF, ");//型式グレード名称
                sb.Append(" F.BODYNAMERF, ");//ボディー名称
                sb.Append(" F.DOORCOUNTRF, ");//ドア数
                sb.Append(" F.ENGINEMODELNMRF, ");//エンジン型式名称
                sb.Append(" F.ENGINEDISPLACENMRF, ");//排気量名称
                sb.Append(" F.EDIVNMRF, ");//E区分名称
                sb.Append(" F.TRANSMISSIONNMRF, ");//ミッション名称
                sb.Append(" F.WHEELDRIVEMETHODNMRF, ");//駆動方式名称
                sb.Append(" F.SHIFTNMRF, ");//シフト名称
                sb.Append(" F.CREATEDATERF, ");//作成日付
                sb.Append(" F.UPDATEDATERF, ");//更新年月日
                sb.Append(" M.MODELFULLNAMERF ");//車種全角名称		
                sb.Append(" FROM ");
                //自由検索型式マスタ
                sb.Append(" FREESEARCHMODELRF F WITH (READUNCOMMITTED) ");
                //車種名称マスタ（ユーザー登録）
                sb.Append(" LEFT JOIN MODELNAMEURF M WITH (READUNCOMMITTED) ");
                sb.Append(" ON M.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND M.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND M.MODELUNIQUECODERF=RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3) ");
                sb.Append(" WHERE ");
                //企業コード
                sb.Append(" F.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.EnterpriseCode);
                //論理削除区分
                sb.Append(" AND F.LOGICALDELETECODERF=0 ");
                //作成日付 (以前、以降、当日)
                if (freeSearchModelParaWork.CreateDateTime != 0)
                {
                    if (freeSearchModelParaWork.CreateDateTimeCode == 0)
                    {
                        sb.Append(" AND F.CREATEDATERF<=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                    else if (freeSearchModelParaWork.CreateDateTimeCode == 1)
                    {
                        sb.Append(" AND F.CREATEDATERF>=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                    else if (freeSearchModelParaWork.CreateDateTimeCode == 2)
                    {
                        sb.Append(" AND F.CREATEDATERF=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchModelParaWork.CreateDateTime);
                    }
                }
                //車種 メーカーコード 車種コード 車種サブコード
                string carModelSt = freeSearchModelParaWork.CarMakerCodeSt.ToString("000");
                carModelSt += "-" + freeSearchModelParaWork.CarModelCodeSt.ToString("000");
                carModelSt += "-" + freeSearchModelParaWork.CarModelSubCodeSt.ToString("000");

                string carModelEd = freeSearchModelParaWork.CarMakerCodeEd.ToString("000");
                carModelEd += "-" + freeSearchModelParaWork.CarModelCodeEd.ToString("000");
                carModelEd += "-" + freeSearchModelParaWork.CarModelSubCodeEd.ToString("000");

                if ("000-000-000" != carModelSt)
                {
                    sb.Append(" AND RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3)>=@AST_MODELCODE ");
                    SqlParameter Para_St_CarModelCode = sqlCommand.Parameters.Add("@AST_MODELCODE", SqlDbType.Char);
                    Para_St_CarModelCode.Value = SqlDataMediator.SqlSetString(carModelSt);
                }
                if ("999-999-999" != carModelEd)
                {
                    sb.Append(" AND RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+'-'+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3)<=@AED_MODELCODE ");
                    SqlParameter Para_Ed_CarModelCode = sqlCommand.Parameters.Add("@AED_MODELCODE", SqlDbType.Char);
                    Para_Ed_CarModelCode.Value = SqlDataMediator.SqlSetString(carModelEd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" F.MAKERCODERF, ");//メーカーコード
                sb.Append(" F.MODELCODERF, ");//車種コード
                sb.Append(" F.MODELSUBCODERF, ");//車種サブコード
                sb.Append(" F.FULLMODELRF ");//型式（フル型）

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    FreeSearchModelPrintWork wkFreeSearchModelPrintWork = new FreeSearchModelPrintWork();

                    //自由検索型式マスタデータ結果取得内容格納
                    wkFreeSearchModelPrintWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//作成日時
                    wkFreeSearchModelPrintWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    wkFreeSearchModelPrintWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//企業コード
                    wkFreeSearchModelPrintWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchModelPrintWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//更新従業員コード
                    wkFreeSearchModelPrintWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//更新アセンブリID1
                    wkFreeSearchModelPrintWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//更新アセンブリID2
                    wkFreeSearchModelPrintWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//論理削除区分
                    wkFreeSearchModelPrintWork.FreeSrchMdlFxdNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNORF"));//自由検索型式固定番号
                    wkFreeSearchModelPrintWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//メーカーコード
                    wkFreeSearchModelPrintWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//車種コード
                    wkFreeSearchModelPrintWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//車種サブコード
                    wkFreeSearchModelPrintWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));//排ガス記号
                    wkFreeSearchModelPrintWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));//シリーズ型式
                    wkFreeSearchModelPrintWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));//型式（類別記号）
                    wkFreeSearchModelPrintWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//型式（フル型）
                    wkFreeSearchModelPrintWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));//型式指定番号
                    wkFreeSearchModelPrintWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));//類別番号
                    wkFreeSearchModelPrintWork.StProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));//開始生産年式
                    wkFreeSearchModelPrintWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));//終了生産年式
                    wkFreeSearchModelPrintWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));//生産車台番号開始
                    wkFreeSearchModelPrintWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));//生産車台番号終了
                    wkFreeSearchModelPrintWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//型式グレード名称
                    wkFreeSearchModelPrintWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//ボディー名称
                    wkFreeSearchModelPrintWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//ドア数
                    wkFreeSearchModelPrintWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//エンジン型式名称
                    wkFreeSearchModelPrintWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//排気量名称
                    wkFreeSearchModelPrintWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E区分名称
                    wkFreeSearchModelPrintWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//ミッション名称
                    wkFreeSearchModelPrintWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//駆動方式名称
                    wkFreeSearchModelPrintWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//シフト名称
                    wkFreeSearchModelPrintWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//作成日付
                    wkFreeSearchModelPrintWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//更新年月日
                    wkFreeSearchModelPrintWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));//車種全角名称
                    #endregion

                    //型式（フル型）が、画面の入力値と以下の条件で一致するかどうか。
                    if (CheckModelName(wkFreeSearchModelPrintWork, modelName))
                    {
                        al.Add(wkFreeSearchModelPrintWork);
                    }
                }
                if (al.Count < 1)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
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
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            retList = al;

            return status;
        }

        #endregion


        #region [型式（フル型）の判断]
        /// <summary>
        /// 型式（フル型）の判断処理
        /// </summary>
        /// <param name="freeSearchModelPrintWork">自由検索型式マスタデータ結果</param>
        /// <param name="modelName">型式（フル型）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private bool CheckModelName(FreeSearchModelPrintWork freeSearchModelPrintWork, string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return true;
            }

            //型式（フル型）
            string fullModel = freeSearchModelPrintWork.FullModel;
            string[] fullModels = fullModel.Split('-');
            string secondModel = string.Empty;
            bool isHaveFirst = true;

            if (fullModels.Length > 1)
            {
                //先頭の要素が４桁以上のため、第１要素が存在しない
                if (fullModels[0].Length >= 4)
                {
                    secondModel = fullModel;
                    isHaveFirst = false;
                }
                else
                {
                    for (int i = 1; i < fullModels.Length; i++)
                    {
                        secondModel += fullModels[i];
                        if (i != fullModels.Length - 1)
                        {
                            secondModel += "-";
                        }
                    }
                }
            }

            //入力値に"-"を含まない場合、対象データの第２要素以降と比較する。
            if (!modelName.Contains("-"))
            {
                if (secondModel.Length >= modelName.Length && secondModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }
            //"-"の後に値が無い場合も、対象データの第２要素以降と比較する。
            else if (modelName.LastIndexOf("-") == modelName.Length - 1)
            {
                //"-"を削除する
                modelName = modelName.Substring(0, modelName.Length - 1);
                //"-"が入力値の間にある場合は、対象データの第１要素から比較する。
                if (modelName.Contains("-"))
                {
                    if (!isHaveFirst)
                    {
                        return false;
                    }
                    if (fullModel.Length >= modelName.Length && fullModel.Substring(0, modelName.Length) == modelName)
                    {
                        return true;
                    }
                }
                //"-"の後に値が無い場合も、対象データの第２要素以降と比較する。
                else if (secondModel.Length >= modelName.Length && secondModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }
            //"-"が入力値の間にある場合は、対象データの第１要素から比較する。
            else
            {
                if (!isHaveFirst)
                {
                    return false;
                }
                if (fullModel.Length >= modelName.Length && fullModel.Substring(0, modelName.Length) == modelName)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
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
