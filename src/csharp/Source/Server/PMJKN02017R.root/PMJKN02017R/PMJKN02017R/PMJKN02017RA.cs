//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ印刷
// プログラム概要   : 自由検索部品マスタ印刷 リモートオブジェクト
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
    /// 自由検索部品マスタ印刷 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ印刷READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsPrintDB : RemoteWithAppLockDB, IFreeSearchPartsPrintDB
    {
        # region ■ Constructor ■
        /// <summary>
        /// 自由検索部品マスタ印刷 リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ印刷READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        public FreeSearchPartsPrintDB()
            :
        base("PMJKN02019D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsPrintWork", "FREESEARCHPARTSPRINTWORK") //基底クラスのコンストラクタ
        {
        }
        #endregion


        #region ■ 自由検索部品マスタ検索処理 ■
        /// <summary>
        /// 自由検索部品マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索部品マスタ（印刷）条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ検索処理を行うクラスです。</br>
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
                base.WriteErrorLog(ex, "FreeSearchPartsPrintDB.SearchAll");
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
        /// 自由検索部品マスタデータを全て戻します
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自由検索部品マスタデータLISTを全て戻します</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        private int SearchAllProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchPartsParaWork freeSearchPartsParaWork = paraWork as FreeSearchPartsParaWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //抽出結果

            // システム日付
            DateTime systemDate = DateTime.Now;
            int systemDateInt = Convert.ToInt32(string.Format("{0:yyyyMMdd}", systemDate));

            //型式（フル型）
            string modelName = freeSearchPartsParaWork.ModelName;

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
                sb.Append(" F.FRESRCHPRTPROPNORF, ");//自由検索部品固有番号
                sb.Append(" F.MAKERCODERF, ");//メーカーコード
                sb.Append(" F.MODELCODERF, ");//車種コード
                sb.Append(" F.MODELSUBCODERF, ");//車種サブコード
                sb.Append(" F.FULLMODELRF, ");//型式（フル型）
                sb.Append(" F.TBSPARTSCODERF, ");//BLコード
                sb.Append(" F.TBSPARTSCDDERIVEDNORF, ");//BLコード枝番
                sb.Append(" F.GOODSNORF, ");//商品番号
                sb.Append(" F.GOODSNONONEHYPHENRF, ");//ハイフン無商品番号
                sb.Append(" F.GOODSMAKERCDRF, ");//商品メーカーコード
                sb.Append(" F.PARTSQTYRF, ");//部品QTY
                sb.Append(" F.PARTSOPNMRF, ");//部品オプション名称
                sb.Append(" F.MODELPRTSADPTYMRF, ");//型式別部品採用年月
                sb.Append(" F.MODELPRTSABLSYMRF, ");//型式別部品廃止年月
                sb.Append(" F.MODELPRTSADPTFRAMENORF, ");//型式別部品採用車台番号
                sb.Append(" F.MODELPRTSABLSFRAMENORF, ");//型式別部品廃止車台番号
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
                sb.Append(" M.MODELFULLNAMERF, ");//車種全角名称
                sb.Append(" MA.MAKERNAMERF, ");//メーカー名称
                sb.Append(" B.BLGOODSHALFNAMERF ");//BL商品コード名称（半角）
                sb.Append(" FROM ");
                //自由検索部品マスタ
                sb.Append(" FREESEARCHPARTSRF F WITH (READUNCOMMITTED) ");
                //車種名称マスタ（ユーザー登録）
                sb.Append(" LEFT JOIN MODELNAMEURF M WITH (READUNCOMMITTED) ");
                sb.Append(" ON M.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND M.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND M.MODELUNIQUECODERF=RIGHT('000'+CAST(F.MAKERCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELCODERF AS VARCHAR(3)),3)+RIGHT('000'+CAST(F.MODELSUBCODERF AS VARCHAR(3)),3) ");
                //ＢＬ商品コードマスタ(ユーザー)
                sb.Append(" LEFT JOIN BLGOODSCDURF B WITH (READUNCOMMITTED) ");
                sb.Append(" ON B.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND B.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND B.BLGOODSCODERF=F.TBSPARTSCODERF ");
                //メーカーマスタ（ユーザー登録分）
                sb.Append(" LEFT JOIN MAKERURF MA WITH (READUNCOMMITTED) ");
                sb.Append(" ON MA.ENTERPRISECODERF=F.ENTERPRISECODERF ");
                sb.Append(" AND MA.LOGICALDELETECODERF=F.LOGICALDELETECODERF ");
                sb.Append(" AND MA.GOODSMAKERCDRF=F.GOODSMAKERCDRF ");
                sb.Append(" WHERE ");
                //企業コード
                sb.Append(" F.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsParaWork.EnterpriseCode);
                //論理削除区分
                sb.Append(" AND F.LOGICALDELETECODERF=0 ");
                //作成日付 (以前、以降、当日)
                if (freeSearchPartsParaWork.CreateDateTime != 0)
                {
                    if (freeSearchPartsParaWork.CreateDateTimeCode == 0)
                    {
                        sb.Append(" AND F.CREATEDATERF<=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                    else if (freeSearchPartsParaWork.CreateDateTimeCode == 1)
                    {
                        sb.Append(" AND F.CREATEDATERF>=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                    else if (freeSearchPartsParaWork.CreateDateTimeCode == 2)
                    {
                        sb.Append(" AND F.CREATEDATERF=@FINDCREATEDATE ");
                        SqlParameter Para_CreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATE", SqlDbType.Int);
                        Para_CreateDateTime.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.CreateDateTime);
                    }
                }
                //車種 メーカーコード 車種コード 車種サブコード
                string carModelSt = freeSearchPartsParaWork.CarMakerCodeSt.ToString("000");
                carModelSt += "-" + freeSearchPartsParaWork.CarModelCodeSt.ToString("000");
                carModelSt += "-" + freeSearchPartsParaWork.CarModelSubCodeSt.ToString("000");

                string carModelEd = freeSearchPartsParaWork.CarMakerCodeEd.ToString("000");
                carModelEd += "-" + freeSearchPartsParaWork.CarModelCodeEd.ToString("000");
                carModelEd += "-" + freeSearchPartsParaWork.CarModelSubCodeEd.ToString("000");

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

                //BLコード
                if (0 != freeSearchPartsParaWork.BLGoodsCodeSt)
                {
                    sb.Append(" AND F.TBSPARTSCODERF>=@FINDSTTBSPARTSCODE ");
                    SqlParameter Para_BLGoodsCodeSt = sqlCommand.Parameters.Add("@FINDSTTBSPARTSCODE", SqlDbType.Int);
                    Para_BLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.BLGoodsCodeSt);
                }
                if (0 != freeSearchPartsParaWork.BLGoodsCodeEd)
                {
                    sb.Append(" AND F.TBSPARTSCODERF<=@FINDEDTBSPARTSCODE ");
                    SqlParameter Para_BLGoodsCodeEd = sqlCommand.Parameters.Add("@FINDEDTBSPARTSCODE", SqlDbType.Int);
                    Para_BLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.BLGoodsCodeEd);
                }

                //商品メーカーコード
                if (0 != freeSearchPartsParaWork.MakerCodeSt)
                {
                    sb.Append(" AND F.MAKERCODERF>=@FINDSTMAKERCODE ");
                    SqlParameter Para_MakerCodeSt = sqlCommand.Parameters.Add("@FINDSTMAKERCODE", SqlDbType.Int);
                    Para_MakerCodeSt.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.MakerCodeSt);
                }
                if (0 != freeSearchPartsParaWork.MakerCodeEd)
                {
                    sb.Append(" AND F.MAKERCODERF<=@FINDEDMAKERCODE ");
                    SqlParameter Para_MakerCodeEd = sqlCommand.Parameters.Add("@FINDEDMAKERCODE", SqlDbType.Int);
                    Para_MakerCodeEd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsParaWork.MakerCodeEd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" F.MAKERCODERF, ");//メーカーコード
                sb.Append(" F.MODELCODERF, ");//車種コード
                sb.Append(" F.MODELSUBCODERF, ");//車種サブコード
                sb.Append(" F.FULLMODELRF, ");//型式（フル型）
                sb.Append(" F.GOODSNORF, ");//品番
                sb.Append(" F.GOODSMAKERCDRF ");//メーカー

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    FreeSearchPartsPrintWork wkFreeSearchPartsPrintWork = new FreeSearchPartsPrintWork();

                    //自由検索部品マスタデータ結果取得内容格納
                    wkFreeSearchPartsPrintWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//作成日時
                    wkFreeSearchPartsPrintWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    wkFreeSearchPartsPrintWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//企業コード
                    wkFreeSearchPartsPrintWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchPartsPrintWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//更新従業員コード
                    wkFreeSearchPartsPrintWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//更新アセンブリID1
                    wkFreeSearchPartsPrintWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//更新アセンブリID2
                    wkFreeSearchPartsPrintWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//論理削除区分
                    wkFreeSearchPartsPrintWork.FreSrchPrtPropNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRESRCHPRTPROPNORF"));//自由検索部品固有番号
                    wkFreeSearchPartsPrintWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//メーカーコード
                    wkFreeSearchPartsPrintWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//車種コード
                    wkFreeSearchPartsPrintWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//車種サブコード
                    wkFreeSearchPartsPrintWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//型式（フル型）
                    wkFreeSearchPartsPrintWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));//BLコード
                    wkFreeSearchPartsPrintWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));//BLコード枝番
                    wkFreeSearchPartsPrintWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));//商品番号
                    wkFreeSearchPartsPrintWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));//ハイフン無商品番号
                    wkFreeSearchPartsPrintWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));//商品メーカーコード
                    wkFreeSearchPartsPrintWork.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));//部品QTY
                    wkFreeSearchPartsPrintWork.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));//部品オプション名称
                    wkFreeSearchPartsPrintWork.ModelPrtsAdptYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));//型式別部品採用年月
                    wkFreeSearchPartsPrintWork.ModelPrtsAblsYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));//型式別部品廃止年月
                    wkFreeSearchPartsPrintWork.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));//型式別部品採用車台番号
                    wkFreeSearchPartsPrintWork.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));//型式別部品廃止車台番号
                    wkFreeSearchPartsPrintWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//型式グレード名称
                    wkFreeSearchPartsPrintWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//ボディー名称
                    wkFreeSearchPartsPrintWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//ドア数
                    wkFreeSearchPartsPrintWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//エンジン型式名称
                    wkFreeSearchPartsPrintWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//排気量名称
                    wkFreeSearchPartsPrintWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E区分名称
                    wkFreeSearchPartsPrintWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//ミッション名称
                    wkFreeSearchPartsPrintWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//駆動方式名称
                    wkFreeSearchPartsPrintWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//シフト名称
                    wkFreeSearchPartsPrintWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//作成日付
                    wkFreeSearchPartsPrintWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//更新年月日
                    wkFreeSearchPartsPrintWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));//車種全角名称
                    wkFreeSearchPartsPrintWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));//メーカー名称
                    wkFreeSearchPartsPrintWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));//BL商品コード名称（半角）
                    #endregion

                    //型式（フル型）が、画面の入力値と以下の条件で一致するかどうか。
                    if (CheckModelName(wkFreeSearchPartsPrintWork, modelName))
                    {
                        al.Add(wkFreeSearchPartsPrintWork);
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
        /// <param name="freeSearchPartsPrintWork">自由検索部品マスタデータ結果</param>
        /// <param name="modelName">型式（フル型）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        private bool CheckModelName(FreeSearchPartsPrintWork freeSearchPartsPrintWork, string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return true;
            }

            //型式（フル型）
            string fullModel = freeSearchPartsPrintWork.FullModel;
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
