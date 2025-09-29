//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ
// プログラム概要   : 自由検索部品マスタ リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/30  修正内容 : 新規作成
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索部品マスタ リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/30</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchPartsDB : RemoteWithAppLockDB, IFreeSearchPartsDB
    {
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        # region ■ Constructor ■
        /// <summary>
        /// 自由検索部品マスタ リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchPartsDB()
            :
        base("PMJKN09016D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork", "FreeSearchPartsRF") //基底クラスのコンストラクタ
        {
        }
        #endregion

        #region ■ 自由検索部品マスタ検索処理 ■
        /// <summary>
        /// 自由検索部品マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索部品マスタ（）条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <param name="readMode">検索区分（現在、未使用）</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(object paraWork, out object retList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retList = null;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchProc(out retList, paraWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
                retList = new ArrayList();
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
        /// 自由検索部品マスタデータを全て戻します
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自由検索部品マスタデータLISTを全て戻します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        private int SearchProc(out object retList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            FreeSearchPartsWork freeSearchPartsWork = paraWork as FreeSearchPartsWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();   //抽出結果

            //型式（フル型）
            string modelName = freeSearchPartsWork.FullModel;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRESRCHPRTPROPNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, FULLMODELRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, GOODSNORF, GOODSNONONEHYPHENRF, GOODSMAKERCDRF, PARTSQTYRF, PARTSOPNMRF, MODELPRTSADPTYMRF, MODELPRTSABLSYMRF, MODELPRTSADPTFRAMENORF, MODELPRTSABLSFRAMENORF, MODELGRADENMRF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, ENGINEDISPLACENMRF, EDIVNMRF, TRANSMISSIONNMRF, WHEELDRIVEMETHODNMRF, SHIFTNMRF, CREATEDATERF, UPDATEDATERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE");

                //Prameterオブジェクトの作成
                //企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sb.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sb.Append("  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                //自由検索部品固有番号
                if (!string.IsNullOrEmpty(freeSearchPartsWork.FreSrchPrtPropNo))
                {
                    sb.Append("  AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO" + Environment.NewLine);
                    SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);
                    findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                }
                //型式（フル型）
                if (!string.IsNullOrEmpty(freeSearchPartsWork.FullModel))
                {
                    sb.Append("  AND FULLMODELRF IN (");
                    string[] fullModels = freeSearchPartsWork.FullModel.Split('\t');
                    for (int i = 0; i < fullModels.Length; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append(" , ");
                        }
                        sb.Append("'" + fullModels[i] + "'");
                    }
                    sb.Append(")" + Environment.NewLine);
                }
                //BLコード
                if (freeSearchPartsWork.TbsPartsCode != 0)
                {
                    sb.Append("  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine);
                    SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                    findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                }
                //BLコード枝番
                if (freeSearchPartsWork.TbsPartsCdDerivedNo != 0)
                {
                    sb.Append("  AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO" + Environment.NewLine);
                    SqlParameter findParaTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);
                    findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                }

                //商品番号
                if (!string.IsNullOrEmpty(freeSearchPartsWork.GoodsNo))
                {
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    switch (freeSearchPartsWork.GoodsNoFuzzy)
                    {
                        //と一致
                        case 0:
                            sb.Append("  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            break;
                        //で始まる
                        case 1:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(this.UseLikeString(freeSearchPartsWork.GoodsNo) + "%");
                            break;
                        //を含む
                        case 2:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString("%" + this.UseLikeString(freeSearchPartsWork.GoodsNo) + "%");
                            break;
                        //で終わる
                        case 3:
                            sb.Append("  AND GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString("%" + this.UseLikeString(freeSearchPartsWork.GoodsNo));
                            break;
                        default:
                            sb.Append("  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            break;
                    }
                }
                //商品メーカーコード
                if (freeSearchPartsWork.GoodsMakerCd != 0)
                {
                    sb.Append("  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
                }

                sb.Append(" ORDER BY ");
                sb.Append(" MAKERCODERF, ");//メーカーコード
                sb.Append(" MODELCODERF, ");//車種コード
                sb.Append(" MODELSUBCODERF, ");//車種サブコード
                sb.Append(" FULLMODELRF ");//型式（フル型）

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    FreeSearchPartsWork wkFreeSearchPartsWork = new FreeSearchPartsWork();

                    //自由検索部品マスタデータ結果取得内容格納
                    wkFreeSearchPartsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkFreeSearchPartsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkFreeSearchPartsWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkFreeSearchPartsWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkFreeSearchPartsWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkFreeSearchPartsWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkFreeSearchPartsWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkFreeSearchPartsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkFreeSearchPartsWork.FreSrchPrtPropNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRESRCHPRTPROPNORF"));
                    wkFreeSearchPartsWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    wkFreeSearchPartsWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    wkFreeSearchPartsWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    wkFreeSearchPartsWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkFreeSearchPartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkFreeSearchPartsWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkFreeSearchPartsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkFreeSearchPartsWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    wkFreeSearchPartsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkFreeSearchPartsWork.PartsQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSQTYRF"));
                    wkFreeSearchPartsWork.PartsOpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSOPNMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAdptYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("MODELPRTSADPTYMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAblsYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("MODELPRTSABLSYMRF"));
                    wkFreeSearchPartsWork.ModelPrtsAdptFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSADPTFRAMENORF"));
                    wkFreeSearchPartsWork.ModelPrtsAblsFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELPRTSABLSFRAMENORF"));
                    wkFreeSearchPartsWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                    wkFreeSearchPartsWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                    wkFreeSearchPartsWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                    wkFreeSearchPartsWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                    wkFreeSearchPartsWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));
                    wkFreeSearchPartsWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                    wkFreeSearchPartsWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                    wkFreeSearchPartsWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                    wkFreeSearchPartsWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                    wkFreeSearchPartsWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));
                    wkFreeSearchPartsWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    #endregion

                    al.Add(wkFreeSearchPartsWork);

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            retList = al as object;

            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        /// 指定された条件の自由検索部品データの物理削除
        /// </summary>
        /// <param name="paraObjList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを物理削除します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        public int Delete(object paraObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = paraObjList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
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
        /// 指定された条件の自由検索部品データの物理削除
        /// </summary>
        /// <param name="paraList">自由検索部品オブジェクト ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを物理削除します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        private int DeleteProc(ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (paraList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < paraList.Count; i++)
                    {
                        FreeSearchPartsWork freeSearchPartsWork = paraList[i] as FreeSearchPartsWork;

                        # region [SELECT文]
                        sqlCommand.CommandText = "SELECT UPDATEDATETIMERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO AND FULLMODELRF=@FINDFULLMODEL AND TBSPARTSCODERF=@FINDTBSPARTSCODE AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);
                        SqlParameter findParaFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@FINDTBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                        findParaFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                        findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != freeSearchPartsWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlCommand.CommandText = "DELETE FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO AND FULLMODELRF=@FINDFULLMODEL AND TBSPARTSCODERF=@FINDTBSPARTSCODE AND TBSPARTSCDDERIVEDNORF=@FINDTBSPARTSCDDERIVEDNO AND GOODSNORF=@FINDGOODSNO AND GOODSMAKERCDRF=@FINDGOODSMAKERCD";
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                            findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                            findParaFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                            findParaTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
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
        #endregion

        # region [Write]
        /// <summary>
        /// 指定された条件の自由検索部品データの登録、更新
        /// </summary>
        /// <param name="paraObjList">自由検索部品オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        public int Write(ref object paraObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = paraObjList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraObjList = paraList as object;
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
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
        /// 指定された条件の自由検索部品データの登録、更新
        /// </summary>
        /// <param name="paraList">自由検索部品オブジェクトリスト</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        public int Write(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件の自由検索部品データの登録、更新
        /// </summary>
        /// <param name="paraList">自由検索部品オブジェクトリスト</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        private int WriteProc(ref ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT;
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
            try
            {
                if (paraList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < paraList.Count; i++)
                    {
                        FreeSearchPartsWork freeSearchPartsWork = paraList[i] as FreeSearchPartsWork;

                        # region [SELECT文]
                        sqlCommand.CommandText = "SELECT UPDATEDATETIMERF FROM FREESEARCHPARTSRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO ";
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FINDFRESRCHPRTPROPNO", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        if (string.IsNullOrEmpty(freeSearchPartsWork.EnterpriseCode))
                        {
                            freeSearchPartsWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        }
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);

                        sqlCommand.CommandTimeout = dbCommandTimeout;  //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != freeSearchPartsWork.UpdateDateTime)
                            {
                                if (freeSearchPartsWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE文]
                            sqlText = "UPDATE FREESEARCHPARTSRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , FRESRCHPRTPROPNORF=@FRESRCHPRTPROPNO , MAKERCODERF=@MAKERCODE , MODELCODERF=@MODELCODE , MODELSUBCODERF=@MODELSUBCODE , FULLMODELRF=@FULLMODEL , TBSPARTSCODERF=@TBSPARTSCODE , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO , GOODSNORF=@GOODSNO , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN , GOODSMAKERCDRF=@GOODSMAKERCD , PARTSQTYRF=@PARTSQTY , PARTSOPNMRF=@PARTSOPNM , MODELPRTSADPTYMRF=@MODELPRTSADPTYM , MODELPRTSABLSYMRF=@MODELPRTSABLSYM , MODELPRTSADPTFRAMENORF=@MODELPRTSADPTFRAMENO , MODELPRTSABLSFRAMENORF=@MODELPRTSABLSFRAMENO , MODELGRADENMRF=@MODELGRADENM , BODYNAMERF=@BODYNAME , DOORCOUNTRF=@DOORCOUNT , ENGINEMODELNMRF=@ENGINEMODELNM , ENGINEDISPLACENMRF=@ENGINEDISPLACENM , EDIVNMRF=@EDIVNM , TRANSMISSIONNMRF=@TRANSMISSIONNM , WHEELDRIVEMETHODNMRF=@WHEELDRIVEMETHODNM , SHIFTNMRF=@SHIFTNM , UPDATEDATERF=@UPDATEDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRESRCHPRTPROPNORF=@FINDFRESRCHPRTPROPNO ";
                            
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                            findParaFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchPartsWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (freeSearchPartsWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = "INSERT INTO FREESEARCHPARTSRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, FRESRCHPRTPROPNORF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, FULLMODELRF, TBSPARTSCODERF, TBSPARTSCDDERIVEDNORF, GOODSNORF, GOODSNONONEHYPHENRF, GOODSMAKERCDRF, PARTSQTYRF, PARTSOPNMRF, MODELPRTSADPTYMRF, MODELPRTSABLSYMRF, MODELPRTSADPTFRAMENORF, MODELPRTSABLSFRAMENORF, MODELGRADENMRF, BODYNAMERF, DOORCOUNTRF, ENGINEMODELNMRF, ENGINEDISPLACENMRF, EDIVNMRF, TRANSMISSIONNMRF, WHEELDRIVEMETHODNMRF, SHIFTNMRF, CREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @FRESRCHPRTPROPNO, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @FULLMODEL, @TBSPARTSCODE, @TBSPARTSCDDERIVEDNO, @GOODSNO, @GOODSNONONEHYPHEN, @GOODSMAKERCD, @PARTSQTY, @PARTSOPNM, @MODELPRTSADPTYM, @MODELPRTSABLSYM, @MODELPRTSADPTFRAMENO, @MODELPRTSABLSFRAMENO, @MODELGRADENM, @BODYNAME, @DOORCOUNT, @ENGINEMODELNM, @ENGINEDISPLACENM, @EDIVNM, @TRANSMISSIONNM, @WHEELDRIVEMETHODNM, @SHIFTNM, @CREATEDATE, @UPDATEDATE)";
                            
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchPartsWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                            SqlParameter paraCreateDate = sqlCommand.Parameters.Add("@CREATEDATE", SqlDbType.Int);
                            paraCreateDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(freeSearchPartsWork.CreateDateTime));
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraFreSrchPrtPropNo = sqlCommand.Parameters.Add("@FRESRCHPRTPROPNO", SqlDbType.NChar);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPartsQty = sqlCommand.Parameters.Add("@PARTSQTY", SqlDbType.Float);
                        SqlParameter paraPartsOpNm = sqlCommand.Parameters.Add("@PARTSOPNM", SqlDbType.NVarChar);
                        SqlParameter paraModelPrtsAdptYm = sqlCommand.Parameters.Add("@MODELPRTSADPTYM", SqlDbType.Int);
                        SqlParameter paraModelPrtsAblsYm = sqlCommand.Parameters.Add("@MODELPRTSABLSYM", SqlDbType.Int);
                        SqlParameter paraModelPrtsAdptFrameNo = sqlCommand.Parameters.Add("@MODELPRTSADPTFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelPrtsAblsFrameNo = sqlCommand.Parameters.Add("@MODELPRTSABLSFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchPartsWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchPartsWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freeSearchPartsWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.LogicalDeleteCode);
                        paraFreSrchPrtPropNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FreSrchPrtPropNo);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelSubCode);
                        paraFullModel.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.FullModel);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.TbsPartsCdDerivedNo);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNo);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.GoodsNoNoneHyphen);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.GoodsMakerCd);
                        paraPartsQty.Value = SqlDataMediator.SqlSetDouble(freeSearchPartsWork.PartsQty);
                        paraPartsOpNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.PartsOpNm);
                        paraModelPrtsAdptYm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(freeSearchPartsWork.ModelPrtsAdptYm);
                        paraModelPrtsAblsYm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(freeSearchPartsWork.ModelPrtsAblsYm);
                        paraModelPrtsAdptFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelPrtsAdptFrameNo);
                        paraModelPrtsAblsFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.ModelPrtsAblsFrameNo);
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.ModelGradeNm);
                        paraBodyName.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.BodyName);
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(freeSearchPartsWork.DoorCount);
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EngineModelNm);
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EngineDisplaceNm);
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.EDivNm);
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.TransmissionNm);
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.WheelDriveMethodNm);
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(freeSearchPartsWork.ShiftNm);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate(freeSearchPartsWork.UpdateDateTime));

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(freeSearchPartsWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
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

            paraList = al;

            return status;
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        #endregion

        #region ■ 自由検索部品マスタ登録、更新と物理削除処理 ■
        /// <summary>
        /// 指定された条件の自由検索部品データ登録、更新と物理削除
        /// </summary>
        /// <param name="writeParaObjList">自由検索部品オブジェクトリスト</param>
        /// <param name="deleteParaObjList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新と物理削除します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        public int WriteAndDelete(ref object writeParaObjList, object deleteParaObjList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = writeParaObjList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                if (paraList != null && paraList.Count != 0)
                {
                    status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
                }
                if (paraList == null || paraList.Count == 0 || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        writeParaObjList = paraList as object;
                    }
                    // パラメータのキャスト
                    ArrayList dparaList = deleteParaObjList as ArrayList;
                    status = this.DeleteProc(dparaList, ref sqlConnection, ref sqlTransaction);

                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
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

        #endregion

        /// <summary>
        /// 曖昧検索用のFuzzy処理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string UseLikeString(string data)
        {
            if (data.Contains("["))
            {
                data = data.Replace("[", "[[]");
            }
            if (data.Contains("%"))
            {
                data = data.Replace("%", "[%]");
            }
            if (data.Contains("_"))
            {
                data = data.Replace("_", "[_]");
            }
            return data;
        }
    }
}
