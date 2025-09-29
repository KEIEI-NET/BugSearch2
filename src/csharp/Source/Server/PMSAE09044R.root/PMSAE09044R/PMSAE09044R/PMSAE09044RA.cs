//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー・品番S＆E商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 寺田義啓
// 作 成 日  2020/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// メーカー・品番S＆E商品コード変換マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 寺田義啓</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndEMkrGdsCdChgSetDB : RemoteDB, ISAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public SAndEMkrGdsCdChgSetDB()
            : base("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork", "SANDEMKRGDSCDCHGSET")
        {

        }

        # region [Delete]
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致するメーカー・品番S＆E商品コード変換マスタ情報を物理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Delete(ref object objectSAndEMkrGdsCdChgWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // XMLの読み込み
                SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Delete(object)", status);
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
        /// メーカー・品番S＆E商品コード変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">メーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を物理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Delete(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">メーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を物理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private int DeleteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        # region [DELETE文]
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);
                    
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
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.DeleteProc" , status);
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

        # region [Search]
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWorkList">検索結果</param>
        /// <param name="paraSAndEMkrGdsCdChgSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致する、全てのメーカー・品番S＆E商品コード変換マスタ情報を取得します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Search(out object outSAndEMkrGdsCdChgWorkList, object paraSAndEMkrGdsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _sAndEMkrGdsCdChgList = null;
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = null;

            outSAndEMkrGdsCdChgWorkList = new CustomSerializeArrayList();

            try
            {
                if (paraSAndEMkrGdsCdChgSetWork is SAndEMkrGdsCdChgWork)
                {
                    sAndEMkrGdsCdChgWork = paraSAndEMkrGdsCdChgSetWork as SAndEMkrGdsCdChgWork;
                }
                else if (paraSAndEMkrGdsCdChgSetWork is ArrayList)
                {
                    if ((paraSAndEMkrGdsCdChgSetWork as ArrayList).Count > 0)
                    {
                        sAndEMkrGdsCdChgWork = (paraSAndEMkrGdsCdChgSetWork as ArrayList)[0] as SAndEMkrGdsCdChgWork;
                    }
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _sAndEMkrGdsCdChgList, sAndEMkrGdsCdChgWork, readMode, logicalMode, ref sqlConnection);

                if (_sAndEMkrGdsCdChgList != null)
                {
                    (outSAndEMkrGdsCdChgWorkList as CustomSerializeArrayList).AddRange(_sAndEMkrGdsCdChgList);
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Search(out object, object, int, LogicalMode)", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgList">メーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="sAndEMkrGdsCdChgWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致する、全てのメーカー・品番S＆E商品コード変換マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Search(out ArrayList sAndEMkrGdsCdChgList, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchProc(out sAndEMkrGdsCdChgList, sAndEMkrGdsCdChgWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgList">メーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="sAndEMkrGdsCdChgWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致する、全てのメーカー・品番S＆E商品コード変換マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private int SearchProc(out ArrayList sAndEMkrGdsCdChgList, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  A.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,A.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,A.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,A.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,A.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,A.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,A.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,A.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,A.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,A.GOODSNORF" + Environment.NewLine;
                sqlText += " ,A.ABGOODSCODERF" + Environment.NewLine;
                sqlText += " ,B.MAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM SANDEMKRGDSCDCHGRF AS A" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF AS B" + Environment.NewLine;
                sqlText += " ON A.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND B.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndEMkrGdsCdChgWork, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSAndEMkrGdsCdChgWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.SearchProc" , status);
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

            sAndEMkrGdsCdChgList = al;

            return status;

        }

        # endregion

        # region [Write]
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWork">追加・更新するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : outSAndEMkrGdsCdChgWorkList に格納されているメーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Write(ref object outSAndEMkrGdsCdChgWork, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                SAndEMkrGdsCdChgWork wkSAndEMkrGdsCdChgWork = outSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref wkSAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                outSAndEMkrGdsCdChgWork = wkSAndEMkrGdsCdChgWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Write(ref object)", status);
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
        /// メーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">追加・更新するメーカー・品番S＆E商品コード変換マスタ情報を格納する</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int Write(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref sAndEMkrGdsCdChgWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">追加・更新するメーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private int WriteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += " AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    
                    sqlCommand.CommandText = sqlText;
                    # endregion
                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                  
                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            if (sAndEMkrGdsCdChgWork.UpdateDateTime == DateTime.MinValue)
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
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ABGOODSCODERF = @ABGOODSCODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (sAndEMkrGdsCdChgWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " ,GOODSNORF" + Environment.NewLine;
                        sqlText += " ,ABGOODSCODERF" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,@GOODSNO" + Environment.NewLine;
                        sqlText += " ,@ABGOODSCODE" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
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
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    SqlParameter paraAbgoodsCode = sqlCommand.Parameters.Add("@ABGOODSCODE", SqlDbType.NChar);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndEMkrGdsCdChgWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.LogicalDeleteCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);
                    paraAbgoodsCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.ABGoodsCode);

                    # endregion

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEMkrGdsCdChgSetDB.Write", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.Write" , status);
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

        # region [LogicalDelete]
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を論理削除します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">論理削除するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を論理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int LogicalDelete(ref object objectSAndEMkrGdsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectSAndEMkrGdsCdChgWork, 0);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">論理削除を解除するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int RevivalLogicalDelete(ref object objectSAndEMkrGdsCdChgWork)
        {
            return this.LogicalDeleteProc(ref objectSAndEMkrGdsCdChgWork, 1);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">論理削除を操作するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private int LogicalDeleteProc(ref object objectSAndEMkrGdsCdChgWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SAndEMkrGdsCdChgWork paraList = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                objectSAndEMkrGdsCdChgWork = paraList;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEMkrGdsCdChgSetDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// メーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">論理削除を操作するメーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        public int LogicalDelete(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref sAndEMkrGdsCdChgWork, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">論理削除を操作するメーカー・品番S＆E商品コード変換マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private int LogicalDeleteProc(ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (sAndEMkrGdsCdChgWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "SANDEMKRGDSCDCHGRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                    findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndEMkrGdsCdChgWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  SANDEMKRGDSCDCHGRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);
                        findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.GoodsMakerCd);
                        findGoodsNo.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.GoodsNo);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndEMkrGdsCdChgWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
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

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) sAndEMkrGdsCdChgWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else sAndEMkrGdsCdChgWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            sAndEMkrGdsCdChgWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }

                    // Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndEMkrGdsCdChgWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndEMkrGdsCdChgWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sAndEMkrGdsCdChgWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SAndEMkrGdsCdChgSetDB.LogicalDelete(ref SAndEMkrGdsCdChgWork, ref SqlConnection, ref SqlTransaction)", status);
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

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sAndEMkrGdsCdChgWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  A.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndEMkrGdsCdChgWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            retstring += " ORDER BY" + Environment.NewLine;
            retstring += "  A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += " ,A.GOODSNORF" + Environment.NewLine;

            return retstring;
        }

        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SAndEMkrGdsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SAndEMkrGdsCdChgWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChgWork CopyToSAndEMkrGdsCdChgWorkFromReader(ref SqlDataReader myReader)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();

            this.CopyToSAndEMkrGdsCdChgWorkFromReader(ref myReader, ref sAndEMkrGdsCdChgWork);

            return sAndEMkrGdsCdChgWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → SAndEMkrGdsCdChgWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="sAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private void CopyToSAndEMkrGdsCdChgWorkFromReader(ref SqlDataReader myReader, ref SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork)
        {
            if (myReader != null && sAndEMkrGdsCdChgWork != null)
            {
                # region クラスへ格納
                sAndEMkrGdsCdChgWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sAndEMkrGdsCdChgWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sAndEMkrGdsCdChgWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sAndEMkrGdsCdChgWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sAndEMkrGdsCdChgWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sAndEMkrGdsCdChgWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sAndEMkrGdsCdChgWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sAndEMkrGdsCdChgWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sAndEMkrGdsCdChgWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                sAndEMkrGdsCdChgWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                sAndEMkrGdsCdChgWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                sAndEMkrGdsCdChgWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                # endregion
            }
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection返す
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}
