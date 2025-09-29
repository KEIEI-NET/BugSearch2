//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ
// プログラム概要   : 自由検索型式マスタ リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/30  修正内容 : 新規作成
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索型式マスタ リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタの実行データ操作を行うクラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [Serializable]
    public class FreeSearchModelDB : RemoteWithAppLockDB, IFreeSearchModelDB
    {
        # region ■ Constructor ■
        /// <summary>
        /// 自由検索型式マスタ リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタの実行データ操作を行うクラスです。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public FreeSearchModelDB()
            :
        base("PMJKN09006D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork", "FREESEARCHMODELWORK") //基底クラスのコンストラクタ
        {
        }
        #endregion


        #region ■ 自由検索型式マスタ検索処理 ■
        /// <summary>
        /// 自由検索型式マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索型式マスタクラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        public int Search(object paraWork, out object retList)
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

                status = SearchProc(out retList, paraWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FreeSearchModelDB.Search");
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
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        private int SearchProc(out object retList, object paraWork, ref SqlConnection sqlConnection)
        {
            FreeSearchModelWork freeSearchModelParaWork = paraWork as FreeSearchModelWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" CREATEDATETIMERF, ");//作成日時
                sb.Append(" UPDATEDATETIMERF, ");//更新日時
                sb.Append(" ENTERPRISECODERF, ");//企業コード
                sb.Append(" FILEHEADERGUIDRF, ");//GUID
                sb.Append(" UPDEMPLOYEECODERF, ");//更新従業員コード
                sb.Append(" UPDASSEMBLYID1RF, ");//更新アセンブリID1
                sb.Append(" UPDASSEMBLYID2RF, ");//更新アセンブリID2
                sb.Append(" LOGICALDELETECODERF, ");//論理削除区分
                sb.Append(" FREESRCHMDLFXDNORF, ");//自由検索型式固定番号
                sb.Append(" MAKERCODERF, ");//メーカーコード
                sb.Append(" MODELCODERF, ");//車種コード
                sb.Append(" MODELSUBCODERF, ");//車種サブコード
                sb.Append(" EXHAUSTGASSIGNRF, ");//排ガス記号
                sb.Append(" SERIESMODELRF, ");//シリーズ型式
                sb.Append(" CATEGORYSIGNMODELRF, ");//型式（類別記号）
                sb.Append(" FULLMODELRF, ");//型式（フル型）
                sb.Append(" MODELDESIGNATIONNORF, ");//型式指定番号
                sb.Append(" CATEGORYNORF, ");//類別番号
                sb.Append(" STPRODUCETYPEOFYEARRF, ");//開始生産年式
                sb.Append(" EDPRODUCETYPEOFYEARRF, ");//終了生産年式
                sb.Append(" STPRODUCEFRAMENORF, ");//生産車台番号開始
                sb.Append(" EDPRODUCEFRAMENORF, ");//生産車台番号終了
                sb.Append(" MODELGRADENMRF, ");//型式グレード名称
                sb.Append(" BODYNAMERF, ");//ボディー名称
                sb.Append(" DOORCOUNTRF, ");//ドア数
                sb.Append(" ENGINEMODELNMRF, ");//エンジン型式名称
                sb.Append(" ENGINEDISPLACENMRF, ");//排気量名称
                sb.Append(" EDIVNMRF, ");//E区分名称
                sb.Append(" TRANSMISSIONNMRF, ");//ミッション名称
                sb.Append(" WHEELDRIVEMETHODNMRF, ");//駆動方式名称
                sb.Append(" SHIFTNMRF, ");//シフト名称
                sb.Append(" CREATEDATERF, ");//作成日付
                sb.Append(" UPDATEDATERF ");//更新年月日
                sb.Append(" FROM FREESEARCHMODELRF ");
                sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");
                sb.Append("     AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNORF ");
                sqlCommand.CommandText = sb.ToString();

                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNORF", SqlDbType.NChar);
                
                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.EnterpriseCode);
                findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelParaWork.FreeSrchMdlFxdNo);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    FreeSearchModelWork wkFreeSearchModelWork = new FreeSearchModelWork();

                    //自由検索型式マスタデータ結果取得内容格納
                    wkFreeSearchModelWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//作成日時
                    wkFreeSearchModelWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    wkFreeSearchModelWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));//企業コード
                    wkFreeSearchModelWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));//GUID
                    wkFreeSearchModelWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));//更新従業員コード
                    wkFreeSearchModelWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));//更新アセンブリID1
                    wkFreeSearchModelWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));//更新アセンブリID2
                    wkFreeSearchModelWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));//論理削除区分
                    wkFreeSearchModelWork.FreeSrchMdlFxdNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNORF"));//自由検索型式固定番号
                    wkFreeSearchModelWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));//メーカーコード
                    wkFreeSearchModelWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));//車種コード
                    wkFreeSearchModelWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));//車種サブコード
                    wkFreeSearchModelWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));//排ガス記号
                    wkFreeSearchModelWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));//シリーズ型式
                    wkFreeSearchModelWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));//型式（類別記号）
                    wkFreeSearchModelWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));//型式（フル型）
                    wkFreeSearchModelWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));//型式指定番号
                    wkFreeSearchModelWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));//類別番号
                    wkFreeSearchModelWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));//開始生産年式
                    wkFreeSearchModelWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));//終了生産年式
                    wkFreeSearchModelWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));//生産車台番号開始
                    wkFreeSearchModelWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));//生産車台番号終了
                    wkFreeSearchModelWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));//型式グレード名称
                    wkFreeSearchModelWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));//ボディー名称
                    wkFreeSearchModelWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));//ドア数
                    wkFreeSearchModelWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));//エンジン型式名称
                    wkFreeSearchModelWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));//排気量名称
                    wkFreeSearchModelWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));//E区分名称
                    wkFreeSearchModelWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));//ミッション名称
                    wkFreeSearchModelWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));//駆動方式名称
                    wkFreeSearchModelWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));//シフト名称
                    wkFreeSearchModelWork.CreateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREATEDATERF"));//作成日付
                    wkFreeSearchModelWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));//更新年月日
                    #endregion

                     al.Add(wkFreeSearchModelWork);
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


        #region ■ 自由検索型式マスタ登録更新処理 ■
        /// <summary>
        /// 自由検索型式マスタ情報を登録、更新します
        /// </summary>
        /// <param name="paraObj">自由検索型式マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : paraObj に格納されている自由検索型式マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        public int Write(ref object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = paraObj as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // Write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
        /// 自由検索型式マスタを登録・更新します。
        /// </summary>
        /// <param name="freeSearchModelList">登録・更新する自由検索型式マスタを格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList に格納されている自由検索型式マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        public int Write(ref ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref freeSearchModelList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 自由検索型式マスタを追加・更新します。
        /// </summary>
        /// <param name="freeSearchModelList">自由検索型式マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : freeSearchModelList に格納されている自由検索型式マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        private int WriteProc(ref ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (freeSearchModelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < freeSearchModelList.Count; i++)
                    {
                        FreeSearchModelWork freeSearchModelWork = freeSearchModelList[i] as FreeSearchModelWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNO", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != freeSearchModelWork.UpdateDateTime)
                            {
                                if (freeSearchModelWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = string.Empty;
                            sqlText += "UPDATE FREESEARCHMODELRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , FREESRCHMDLFXDNORF=@FREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlText += " , MAKERCODERF=@MAKERCODE" + Environment.NewLine;
                            sqlText += " , MODELCODERF=@MODELCODE" + Environment.NewLine;
                            sqlText += " , MODELSUBCODERF=@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " , EXHAUSTGASSIGNRF=@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " , SERIESMODELRF=@SERIESMODEL" + Environment.NewLine;
                            sqlText += " , CATEGORYSIGNMODELRF=@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " , FULLMODELRF=@FULLMODEL" + Environment.NewLine;
                            sqlText += " , MODELDESIGNATIONNORF=@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " , CATEGORYNORF=@CATEGORYNO" + Environment.NewLine;
                            sqlText += " , STPRODUCETYPEOFYEARRF=@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " , EDPRODUCETYPEOFYEARRF=@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += " , STPRODUCEFRAMENORF=@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " , EDPRODUCEFRAMENORF=@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += " , MODELGRADENMRF=@MODELGRADENM" + Environment.NewLine;
                            sqlText += " , BODYNAMERF=@BODYNAME" + Environment.NewLine;
                            sqlText += " , DOORCOUNTRF=@DOORCOUNT" + Environment.NewLine;
                            sqlText += " , ENGINEMODELNMRF=@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " , ENGINEDISPLACENMRF=@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += " , EDIVNMRF=@EDIVNM" + Environment.NewLine;
                            sqlText += " , TRANSMISSIONNMRF=@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += " , WHEELDRIVEMETHODNMRF=@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += " , SHIFTNMRF=@SHIFTNM" + Environment.NewLine;
                            sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                           

                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                            findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchModelWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (freeSearchModelWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO FREESEARCHMODELRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,FREESRCHMDLFXDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                            sqlText += "    ,MODELCODERF" + Environment.NewLine;
                            sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += "    ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += "    ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += "    ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += "    ,FULLMODELRF" + Environment.NewLine;
                            sqlText += "    ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += "    ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += "    ,STPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += "    ,EDPRODUCETYPEOFYEARRF" + Environment.NewLine;
                            sqlText += "    ,STPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += "    ,EDPRODUCEFRAMENORF" + Environment.NewLine;
                            sqlText += "    ,MODELGRADENMRF" + Environment.NewLine;
                            sqlText += "    ,BODYNAMERF" + Environment.NewLine;
                            sqlText += "    ,DOORCOUNTRF" + Environment.NewLine;
                            sqlText += "    ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += "    ,ENGINEDISPLACENMRF" + Environment.NewLine;
                            sqlText += "    ,EDIVNMRF" + Environment.NewLine;
                            sqlText += "    ,TRANSMISSIONNMRF" + Environment.NewLine;
                            sqlText += "    ,WHEELDRIVEMETHODNMRF" + Environment.NewLine;
                            sqlText += "    ,SHIFTNMRF" + Environment.NewLine;
                            sqlText += "    ,CREATEDATERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@FREESRCHMDLFXDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERCODE" + Environment.NewLine;
                            sqlText += "    ,@MODELCODE" + Environment.NewLine;
                            sqlText += "    ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += "    ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += "    ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += "    ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += "    ,@FULLMODEL" + Environment.NewLine;
                            sqlText += "    ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += "    ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += "    ,@STPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += "    ,@EDPRODUCETYPEOFYEAR" + Environment.NewLine;
                            sqlText += "    ,@STPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += "    ,@EDPRODUCEFRAMENO" + Environment.NewLine;
                            sqlText += "    ,@MODELGRADENM" + Environment.NewLine;
                            sqlText += "    ,@BODYNAME" + Environment.NewLine;
                            sqlText += "    ,@DOORCOUNT" + Environment.NewLine;
                            sqlText += "    ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += "    ,@ENGINEDISPLACENM" + Environment.NewLine;
                            sqlText += "    ,@EDIVNM" + Environment.NewLine;
                            sqlText += "    ,@TRANSMISSIONNM" + Environment.NewLine;
                            sqlText += "    ,@WHEELDRIVEMETHODNM" + Environment.NewLine;
                            sqlText += "    ,@SHIFTNM" + Environment.NewLine;
                            sqlText += "    ,@CREATEDATE" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)freeSearchModelWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
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
                        SqlParameter paraFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNO", SqlDbType.NChar);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);
                        SqlParameter paraStProduceTypeOfYear = sqlCommand.Parameters.Add("@STPRODUCETYPEOFYEAR", SqlDbType.Int);
                        SqlParameter paraEdProduceTypeOfYear = sqlCommand.Parameters.Add("@EDPRODUCETYPEOFYEAR", SqlDbType.Int);
                        SqlParameter paraStProduceFrameNo = sqlCommand.Parameters.Add("@STPRODUCEFRAMENO", SqlDbType.Int);
                        SqlParameter paraEdProduceFrameNo = sqlCommand.Parameters.Add("@EDPRODUCEFRAMENO", SqlDbType.Int);
                        SqlParameter paraModelGradeNm = sqlCommand.Parameters.Add("@MODELGRADENM", SqlDbType.NVarChar);
                        SqlParameter paraBodyName = sqlCommand.Parameters.Add("@BODYNAME", SqlDbType.NVarChar);
                        SqlParameter paraDoorCount = sqlCommand.Parameters.Add("@DOORCOUNT", SqlDbType.Int);
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);
                        SqlParameter paraEngineDisplaceNm = sqlCommand.Parameters.Add("@ENGINEDISPLACENM", SqlDbType.NVarChar);
                        SqlParameter paraEDivNm = sqlCommand.Parameters.Add("@EDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraTransmissionNm = sqlCommand.Parameters.Add("@TRANSMISSIONNM", SqlDbType.NVarChar);
                        SqlParameter paraWheelDriveMethodNm = sqlCommand.Parameters.Add("@WHEELDRIVEMETHODNM", SqlDbType.NVarChar);
                        SqlParameter paraShiftNm = sqlCommand.Parameters.Add("@SHIFTNM", SqlDbType.NVarChar);
                        SqlParameter paraCreateDate = sqlCommand.Parameters.Add("@CREATEDATE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchModelWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(freeSearchModelWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(freeSearchModelWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.LogicalDeleteCode);
                        paraFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelSubCode);
                        if (!String.IsNullOrEmpty(freeSearchModelWork.ExhaustGasSign))
                        {
                            paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ExhaustGasSign);
                        }
                        else
                        {
                            paraExhaustGasSign.Value = " ";
                        }

                        if (!String.IsNullOrEmpty(freeSearchModelWork.SeriesModel))
                        {
                            paraSeriesModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.SeriesModel);
                        }
                        else
                        {
                            paraSeriesModel.Value = " ";
                        }

                        if (!String.IsNullOrEmpty(freeSearchModelWork.CategorySignModel))
                        {
                            paraCategorySignModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.CategorySignModel);
                        }
                        else
                        {
                            paraCategorySignModel.Value = " ";
                        }

                        paraFullModel.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FullModel);
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.ModelDesignationNo);
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.CategoryNo);
                        if (freeSearchModelWork.StProduceTypeOfYear == DateTime.MinValue)
                        {
                            paraStProduceTypeOfYear.Value = 0;
                        }
                        else
                        {
                            paraStProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMM", freeSearchModelWork.StProduceTypeOfYear));
                        }

                        if (freeSearchModelWork.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            paraEdProduceTypeOfYear.Value = 0;
                        }
                        else
                        {
                            paraEdProduceTypeOfYear.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMM", freeSearchModelWork.EdProduceTypeOfYear));
                        }
                        
                        paraStProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.StProduceFrameNo);
                        paraEdProduceFrameNo.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.EdProduceFrameNo);
                        paraModelGradeNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ModelGradeNm);
                        paraBodyName.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.BodyName);
                        paraDoorCount.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.DoorCount);
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EngineModelNm);
                        paraEngineDisplaceNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EngineDisplaceNm);
                        paraEDivNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EDivNm);
                        paraTransmissionNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.TransmissionNm);
                        paraWheelDriveMethodNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.WheelDriveMethodNm);
                        paraShiftNm.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.ShiftNm);
                        paraCreateDate.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.CreateDate);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetInt32(freeSearchModelWork.UpdateDate);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(freeSearchModelWork);
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

            freeSearchModelList = al;

            return status;
        }
        #endregion


        # region ■ 自由検索型式マスタ物理削除処理 ■
        /// <summary>
        /// 自由検索型式マスタ情報を物理削除します
        /// </summary>
        /// <param name="freeSearchModelList">自由検索型式マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 自由検索型式マスタのキー値が一致する自由検索型式マスタ情報を物理削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        public int Delete(object freeSearchModelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = freeSearchModelList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// 自由検索型式マスタ情報を物理削除します
        /// </summary>
        /// <param name="freeSearchModelList">自由検索型式マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : freeSearchModelList に格納されているUOE 発注先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        public int Delete(ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(freeSearchModelList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 自由検索型式マスタ情報を物理削除します
        /// </summary>
        /// <param name="freeSearchModelList">自由検索型式マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList に格納されている自由検索型式マスタ情報を物理削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.30</br>
        private int DeleteProc(ArrayList freeSearchModelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (freeSearchModelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < freeSearchModelList.Count; i++)
                    {
                        FreeSearchModelWork freeSearchModelWork = freeSearchModelList[i] as FreeSearchModelWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaFreeSrchMdlFxdNo = sqlCommand.Parameters.Add("@FINDFREESRCHMDLFXDNO", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                        findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != freeSearchModelWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM FREESEARCHMODELRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND FREESRCHMDLFXDNORF=@FINDFREESRCHMDLFXDNO" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.EnterpriseCode);
                            findParaFreeSrchMdlFxdNo.Value = SqlDataMediator.SqlSetString(freeSearchModelWork.FreeSrchMdlFxdNo);
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
        # endregion


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
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
