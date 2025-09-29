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
// 作 成 日  2009/04/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
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
    /// 商品セットマスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品セットマスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APGoodsSetDB : RemoteDB
    {
        /// <summary>
        /// 商品セットマスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APGoodsSetDB()
            : base("PMKYO06231D", "Broadleaf.Application.Remoting.ParamData.APGoodsSetWork", "GOODSSETRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 商品セットマスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsSetArrList">商品セットマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchGoodsSet(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsSetArrList, out string retMessage)
        {
            return SearchGoodsSetProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                sqlTransaction, out goodsSetArrList, out retMessage);
        }
        /// <summary>
        /// 商品セットマスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="goodsSetArrList">商品セットマスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchGoodsSetProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList goodsSetArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsSetArrList = new ArrayList();
            APGoodsSetWork goodsSetWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //商品セットマスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsSetWork = new APGoodsSetWork();

                    goodsSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    goodsSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    goodsSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    goodsSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    goodsSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    goodsSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    goodsSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsSetWork.ParentGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARENTGOODSMAKERCDRF"));
                    goodsSetWork.ParentGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARENTGOODSNORF"));
                    goodsSetWork.SubGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBGOODSMAKERCDRF"));
                    goodsSetWork.SubGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBGOODSNORF"));
                    goodsSetWork.CntFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CNTFLRF"));
                    goodsSetWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    goodsSetWork.SetSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETSPECIALNOTERF"));
                    goodsSetWork.CatalogShapeNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATALOGSHAPENORF"));

                    goodsSetArrList.Add(goodsSetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APGoodsSetDB.SearchGoodsSet Exception=" + ex.Message);
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
        /// 商品セットマスタの計数検索処理
        /// </summary>
        /// <param name="goodsSetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchGoodsSetCount(APGoodsSetWork goodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchGoodsSetCountProc(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 商品セットマスタの計数検索処理
        /// </summary>
        /// <param name="goodsSetWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品セットマスタ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchGoodsSetCountProc(APGoodsSetWork goodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO ";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
                // DEL 2009/06/09 ---- >>>
                //SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
                //SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);
                // DEL 2009/06/09 ---- <<<
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsSetWork.EnterpriseCode);
                findParaParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.ParentGoodsMakerCd);
                findParaParentGoodsNo.Value = goodsSetWork.ParentGoodsNo;
                // DEL 2009/06/09 ---- >>>
                //findParaSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsSetWork.SubGoodsMakerCd);
                //findParaSubGoodsNo.Value = goodsSetWork.SubGoodsNo;
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
        ///  商品セットマスタデータ削除
        /// </summary>
        /// <param name="apGoodsSetWork">商品セットマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Delete(APGoodsSetWork apGoodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  商品セットマスタデータ削除
        /// </summary>
        /// <param name="apGoodsSetWork">商品セットマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(APGoodsSetWork apGoodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM GOODSSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND PARENTGOODSMAKERCDRF=@FINDPARENTGOODSMAKERCD AND PARENTGOODSNORF=@FINDPARENTGOODSNO ";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaParentGoodsMakerCd = sqlCommand.Parameters.Add("@FINDPARENTGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaParentGoodsNo = sqlCommand.Parameters.Add("@FINDPARENTGOODSNO", SqlDbType.NVarChar);
            //SqlParameter findParaSubGoodsMakerCd = sqlCommand.Parameters.Add("@FINDSUBGOODSMAKERCD", SqlDbType.Int);
            //SqlParameter findParaSubGoodsNo = sqlCommand.Parameters.Add("@FINDSUBGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apGoodsSetWork.EnterpriseCode;
            findParaParentGoodsMakerCd.Value = apGoodsSetWork.ParentGoodsMakerCd;
            findParaParentGoodsNo.Value = apGoodsSetWork.ParentGoodsNo;
            //findParaSubGoodsMakerCd.Value = apGoodsSetWork.SubGoodsMakerCd;
            //findParaSubGoodsNo.Value = apGoodsSetWork.SubGoodsNo;


            // 商品セットマスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 商品セットマスタ登録
        /// </summary>
        /// <param name="apGoodsSetWork">商品セットマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(APGoodsSetWork apGoodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 商品セットマスタ登録
        /// </summary>
        /// <param name="apGoodsSetWork">商品セットマスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 商品セットマスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(APGoodsSetWork apGoodsSetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO GOODSSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, PARENTGOODSMAKERCDRF, PARENTGOODSNORF, SUBGOODSMAKERCDRF, SUBGOODSNORF, CNTFLRF, DISPLAYORDERRF, SETSPECIALNOTERF, CATALOGSHAPENORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @PARENTGOODSMAKERCD, @PARENTGOODSNO, @SUBGOODSMAKERCD, @SUBGOODSNO, @CNTFL, @DISPLAYORDER, @SETSPECIALNOTE, @CATALOGSHAPENO)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraParentGoodsMakerCd = sqlCommand.Parameters.Add("@PARENTGOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraParentGoodsNo = sqlCommand.Parameters.Add("@PARENTGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraSubGoodsMakerCd = sqlCommand.Parameters.Add("@SUBGOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraSubGoodsNo = sqlCommand.Parameters.Add("@SUBGOODSNO", SqlDbType.NVarChar);
            SqlParameter paraCntFl = sqlCommand.Parameters.Add("@CNTFL", SqlDbType.Float);
            SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
            SqlParameter paraSetSpecialNote = sqlCommand.Parameters.Add("@SETSPECIALNOTE", SqlDbType.NVarChar);
            SqlParameter paraCatalogShapeNo = sqlCommand.Parameters.Add("@CATALOGSHAPENO", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsSetWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apGoodsSetWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apGoodsSetWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apGoodsSetWork.LogicalDeleteCode);
            paraParentGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsSetWork.ParentGoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsSetWork.ParentGoodsNo.Trim()))
            {
                paraParentGoodsNo.Value = apGoodsSetWork.ParentGoodsNo;
            }
            else
            {
                paraParentGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.ParentGoodsNo);
            }
            paraSubGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apGoodsSetWork.SubGoodsMakerCd);
            if (string.IsNullOrEmpty(apGoodsSetWork.SubGoodsNo.Trim()))
            {
                paraSubGoodsNo.Value = apGoodsSetWork.SubGoodsNo;
            }
            else
            {
                paraSubGoodsNo.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.SubGoodsNo);
            }
            paraCntFl.Value = SqlDataMediator.SqlSetDouble(apGoodsSetWork.CntFl);
            paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(apGoodsSetWork.DisplayOrder);
            paraSetSpecialNote.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.SetSpecialNote);
            paraCatalogShapeNo.Value = SqlDataMediator.SqlSetString(apGoodsSetWork.CatalogShapeNo);


            // 商品セットマスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion


    }
}





