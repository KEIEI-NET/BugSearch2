//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 商品バーコード関連付けマスタ登録リモートオブジェクト
// プログラム概要   : 商品バーコード関連付けマスタ登録を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/05  修正内容 : 新規作成
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品バーコード関連付けマスタ登録リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けマスタ登録リモートオブジェクトです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class HandyGoodsBarCodeDB : RemoteDB, IHandyGoodsBarCodeDB
    {
        /// <summary>日期フォーマット</summary>
        private const string StringFormat = "yyyyMMdd";
        /// <summary>他でデータが変更済みの場合、（ST_ARSET）のステータス</summary>
        private const int StatusArset = -2;

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナルログイン情報取得リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public HandyGoodsBarCodeDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// 商品バーコード関連付けマスタ登録処理
        /// </summary>
        /// <param name="insertByte">登録ワーク</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタを登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public int InsertForHandy(byte[] insertByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // コネクションが生成できない場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                GoodsBarCodeRevnWork goodsBarCodeRevnWork = (GoodsBarCodeRevnWork)XmlByteSerializer.Deserialize(insertByte, typeof(GoodsBarCodeRevnWork));
                // 登録データがカスタムシリアライザ失敗の場合
                if (goodsBarCodeRevnWork == null)
                {
                    base.WriteErrorLog("HandyGoodsBarCodeDB.InsertForHandy" + "カスタムシリアライザ失敗");
                    return status;
                }

                status = InsertForHandyProc(goodsBarCodeRevnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyGoodsBarCodeDB.InsertForHandy" + ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// 指定された条件の商品バーコード関連付けマスタ情報を登録・更新します
        /// </summary>
        /// <param name="goodsBarCodeRevnWork">商品バーコード関連付けマスタの登録・更新ワーク</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の商品バーコード関連付けマスタ情報を登録・更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private int InsertForHandyProc(GoodsBarCodeRevnWork goodsBarCodeRevnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine(" SELECT ");
                sb.AppendLine(" UPDATEDATETIMERF ");
                sb.AppendLine(" FROM ");
                sb.AppendLine(" GOODSBARCODEREVNRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" WHERE ");
                sb.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                sb.AppendLine(" AND GOODSMAKERCDRF=@FINDGOODSMAKERCD ");
                sb.AppendLine(" AND GOODSNORF=@FINDGOODSNO ");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                // 商品メーカーコード
                SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                // 商品番号
                SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                // 検索結果がある場合
                if (myReader.Read())
                {
                    // 検索結果がある場合、ST_ARSET(-2)をセットして返却します。
                    status = StatusArset;
                    return status;
                }
                else
                {
                    sb = new StringBuilder();

                    # region INSERT句生成
                    sb.AppendLine(" INSERT INTO ");
                    sb.AppendLine(" GOODSBARCODEREVNRF ");
                    sb.AppendLine(" (CREATEDATETIMERF, ");
                    sb.AppendLine(" UPDATEDATETIMERF, ");
                    sb.AppendLine(" ENTERPRISECODERF, ");
                    sb.AppendLine(" FILEHEADERGUIDRF, ");
                    sb.AppendLine(" UPDEMPLOYEECODERF, ");
                    sb.AppendLine(" UPDASSEMBLYID1RF, ");
                    sb.AppendLine(" UPDASSEMBLYID2RF, ");
                    sb.AppendLine(" LOGICALDELETECODERF, ");
                    sb.AppendLine(" GOODSMAKERCDRF, ");
                    sb.AppendLine(" GOODSNORF, ");
                    sb.AppendLine(" GOODSBARCODERF, ");
                    sb.AppendLine(" GOODSBARCODEKINDRF, ");
                    sb.AppendLine(" CHECKDIGITCODERF, ");
                    sb.AppendLine(" OFFERDATADIVRF ");
                    sb.AppendLine(" ) VALUES ( ");
                    sb.AppendLine(" @CREATEDATETIME, ");
                    sb.AppendLine(" @UPDATEDATETIME, ");
                    sb.AppendLine(" @ENTERPRISECODE, ");
                    sb.AppendLine(" @FILEHEADERGUID, ");
                    sb.AppendLine(" @UPDEMPLOYEECODE, ");
                    sb.AppendLine(" @UPDASSEMBLYID1, ");
                    sb.AppendLine(" @UPDASSEMBLYID2, ");
                    sb.AppendLine(" @LOGICALDELETECODE, ");
                    sb.AppendLine(" @GOODSMAKERCD, ");
                    sb.AppendLine(" @GOODSNO, ");
                    sb.AppendLine(" @GOODSBARCODE, ");
                    sb.AppendLine(" @GOODSBARCODEKIND, ");
                    sb.AppendLine(" @CHECKDIGITCODE, ");
                    sb.AppendLine(" @OFFERDATADIV) ");
                    # endregion

                    sqlCommand.CommandText = sb.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

                    #region パラメータ設定
                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)goodsBarCodeRevnWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    #endregion
                }

                // myReaderが閉じない場合
                if (myReader.IsClosed == false) myReader.Close();

                goodsBarCodeRevnWork.UpdEmployeeCode = goodsBarCodeRevnWork.EmployeeCode;

                #region Prameterオブジェクトの作成
                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsBarCode = sqlCommand.Parameters.Add("@GOODSBARCODE", SqlDbType.NVarChar);
                SqlParameter paraGoodsBarCodeKind = sqlCommand.Parameters.Add("@GOODSBARCODEKIND", SqlDbType.Int);
                SqlParameter paraCheckdigitCode = sqlCommand.Parameters.Add("@CHECKDIGITCODE", SqlDbType.Int);
                SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsBarCodeRevnWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsBarCodeRevnWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.LogicalDeleteCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsNo);
                paraGoodsBarCode.Value = SqlDataMediator.SqlSetString(goodsBarCodeRevnWork.GoodsBarCode);
                paraGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.GoodsBarCodeKind);
                paraCheckdigitCode.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.CheckdigitCode);
                paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(goodsBarCodeRevnWork.OfferDataDiv);
                #endregion

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyGoodsBarCodeDB.InsertForHandyProc" + ex.Message, status);
            }
            finally
            {
                // myReaderを破棄します
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();

                // sqlCommandを破棄します
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // SQLコネクションが生成できない場合
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandyGoodsBarCodeDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
