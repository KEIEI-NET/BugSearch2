//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品設定マスタ
// プログラム概要   : お買い得商品設定マスタDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鹿庭 一郎
// 作 成 日  2015/01/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 小栗 大介
// 作 成 日  2015/03/03  修正内容 : 問合元拠点コード絞込条件を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鹿庭 一郎
// 作 成 日  2015/03/06  修正内容 : エラー発生後もWriteが続行される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2015/03/09  修正内容 : RedMine#329 得意先別設定がある明細をするとエラーが発生
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2015/03/16  修正内容 : 得意先別設定のデータが重複する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 松本 宏紀
// 作 成 日  2015.03.24  修正内容 : 品管redmine#3251の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 更 新 日  2015/03/23  修正内容 : 品証Redmine#3158 課題管理表№37
//                                  公開区分チェックをはずした状態であれば仮登録できるように対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/26  修正内容 : 品証Redmine#3247
//                                  PM商品マスタ(ユーザー登録)から取得したメーカー価格に対して離島設定が反映される
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 松本 宏紀
// 作 成 日  2015.03.28  修正内容 : 品管redmine#3257の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// お買い得商品設定マスタ リモートオブジェクトクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買い得商品設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 鹿庭 一郎</br>
    /// <br>Date       : 2015/01/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecBgnGdsDB : RemoteDB, IRecBgnGdsDB
    {

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : RecBgnGdsDB コンストラクタ</br>
        /// <br>Programmer : 鹿庭 一郎</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        public RecBgnGdsDB() : base("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork", "RecBgnGdsRF")
        {
        }

        #endregion

        #region コネクション生成処理

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 鹿庭 一郎</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            
            // 接続文字列取得
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText)) return null;

            // コネクション作成
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }

        #endregion

        #region ランザクション生成処理

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 鹿庭 一郎</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            return retSqlTransaction;
        }

        #endregion  //トランザクション生成処理

        //--- ADD  2015/02/23 佐々木 ----->>>>>

        #region IRecBgnGdsDB メンバ

        #region Write

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタ登録、更新処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork登録データ</param>
        /// <param name="paraCustobj">RecBgnCustPMWork登録データ</param>
        /// <param name="paraIsolobj">PmIsolPrcWork登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタを登録、更新します。</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Write(ref object paraobj, ref object paraCustobj, ref object paraIsolobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // お買得商品設定マスタ 登録・更新処理
                status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 登録・更新処理
                    status = WriteProcCust(ref paraCustobj, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PM離島価格マスタ 登録・更新処理
                    status = WriteProcIsol(ref paraIsolobj, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Write");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #region Read

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ 検索処理
        /// </summary>
        /// <param name="retobj">RecBgnPMWork検索結果リスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsPMWork検索データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Read(ref object retobj, ref object retCustobj, object paraobj, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // お買得商品設定マスタ 検索処理
                status = ReadProc(out retobj, paraobj, sqlConnection, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 検索処理
                    status = ReadProcCust(out retCustobj, paraobj, sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Read");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #endregion

        #region Search

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ：検索処理（論理削除除く）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果データリスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGdsPMSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Search(out object retobj, out object retCustobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            retCustobj = null;

            count = 0;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // お買得商品設定マスタ 検索処理
                status = SearchProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 検索処理
                    status = SearchProcCust(out retCustobj, paraobj, logicalMode, ref sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = new ArrayList();
                count = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ：検索処理（論理削除除く）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果データリスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果データリスト</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        public int Search(out object retobj, out object retCustobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            retCustobj = null;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // お買得商品設定マスタ 検索処理
                status = SearchProc(out retobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 検索処理
                    status = SearchProcCust(out retCustobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = null;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #endregion

        #region Delete

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ 完全削除処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを物理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション作成
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // お買得商品設定マスタ 削除処理
                status = DeleteProc(paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 削除処理（お買得商品設定マスタのキーを使用）
                    status = DeleteProcCust(paraobj, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region DeleteAndWrite

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタ 完全削除・登録処理（リスト処理）
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork削除データリスト</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork登録データリスト</param>
        /// <param name="paraCustUpdObj">RecBgnCustPMWork登録データリスト</param>
        /// <param name="paraIsolUpdObj">PmIsolPrcWork登録データリスト</param>
        /// <param name="errorObj">RecBgnGdsPMWorkエラーリスト</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタを完全削除、登録します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, ref object paraCustUpdObj, ref object paraIsolUpdObj, out object errorObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            errorObj = null;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // 変換
                ArrayList delList = paraDelObj as ArrayList;
                ArrayList updList = paraUpdObj as ArrayList;
                ArrayList updCustList = paraCustUpdObj as ArrayList;
                ArrayList updIsolList = paraIsolUpdObj as ArrayList;

                // お買得商品設定マスタ・お買得商品得意先個別設定マスタ完全削除
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in delList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // お買得商品設定マスタ完全削除
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }

                    // お買得商品得意先個別設定マスタ完全削除（お買得商品設定マスタのキーを使用）
                    status = this.DeleteProcCust(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }

                // 削除用メーカーコードリスト
                List<int> makerList = new List<int>();

                // PM離島価格マスタの削除対象を抽出
                foreach (PmIsolPrcWork pmIsolPrcWork in updIsolList)
                {
                    // 存在していない場合
                    if (makerList.Contains(pmIsolPrcWork.MakerCode) == false)
                    {
                        // リストに追加
                        makerList.Add(pmIsolPrcWork.MakerCode);

                        // PM離島価格マスタ完全削除
                        status = this.DeleteProcIsol(pmIsolPrcWork.MakerCode, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            errorObj = null;
		                    //--- ADD  2015/03/06 鹿庭 ----->>>>>                    
                            return status;
		                    //--- ADD  2015/03/06 鹿庭 -----<<<<<                    
                        }
                    }
                }

                // お買得商品設定マスタ 登録
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in updList)
                {
                    object paraObj = recBgnGdsPMWork as object;
                    if (recBgnGdsPMWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = paraObj;
                            return status;
                        }
                        status = this.WriteProc(ref paraObj, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        // お買得商品設定マスタ 論理削除
                        status = this.LogicalDeleteProc(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // お買得商品得意先個別設定マスタ 論理削除
                            status = this.LogicalDeleteProcCust(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 鹿庭 ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 鹿庭 -----<<<<<                    
                    }
                }

                // お買得商品得意先個別設定マスタ 登録
                foreach (RecBgnCustPMWork recBgnCustPMWork in updCustList)
                {
                    object paraCustObj = recBgnCustPMWork as object;
                    if (recBgnCustPMWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSaveCust(ref paraCustObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = null;
                            return status;
                        }
                        status = this.WriteProcCust(ref paraCustObj, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 鹿庭 ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 鹿庭 -----<<<<<                    
                    }
                }

                // PM離島価格マスタ 登録
                foreach (PmIsolPrcWork pmIsolPrcWork in updIsolList)
                {
                    object paraIsolObj = pmIsolPrcWork as object;
                    if (pmIsolPrcWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSaveIsol(ref paraIsolObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = null;
                            return status;
                        }
                        status = this.WriteProcIsol(ref paraIsolObj, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
	                    //--- ADD  2015/03/06 鹿庭 ----->>>>>                    
                        errorObj = null;
                        return status;
	                    //--- ADD  2015/03/06 鹿庭 -----<<<<<                    
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndWrite");
                errorObj = null;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region DeleteAndRevival

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ完全削除・復活処理（リスト処理）
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork削除データリスト</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork復活データリスト</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを完全削除、復活します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // 変換
                ArrayList delList = paraDelObj as ArrayList;
                ArrayList updList = paraUpdObj as ArrayList;

                // お買得商品設定マスタ、お買得商品得意先個別設定マスタ 完全削除
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in delList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // お買得商品設定マスタ 完全削除
                    status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // お買得商品得意先個別設定マスタ 完全削除（お買得商品設定マスタのキーを使用）
                    status = this.DeleteProcCust(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                }

                // お買得商品設定マスタ、お買得商品得意先個別設定マスタ 復活
                foreach (RecBgnGdsPMWork recBgnGdsPMWork in updList)
                {
                    object paraObj = recBgnGdsPMWork as object;

                    // お買得商品設定マスタ 復活
                    status = this.LogicalDeleteProc(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    // お買得商品得意先個別設定マスタ 復活（お買得商品設定マスタのキーを使用）
                    status = this.LogicalDeleteProcCust(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndRevival");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region LogicalDelete

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ論理削除処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを論理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // お買得商品設定マスタ 論理削除
                status = LogicalDeleteProc(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 論理削除（お買得商品設定マスタのキーを使用）
                    status = LogicalDeleteProcCust(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region RevivalLogicalDelete

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ 復活処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // お買得商品設定マスタ 復活処理
                status = RevivalLogicalDeleteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // お買得商品得意先個別設定マスタ 復活処理（お買得商品設定マスタのキーを使用）
                    status = RevivalLogicalDeleteProcCust(ref paraobj, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.RevivalLogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #endregion

        #endregion

        #region 登録・更新処理

        /// <summary>
        /// お買得商品設定マスタ 登録・更新処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork登録データ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // コマンド作成
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // お買得商品設定マスタ Selectコマンド
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            // 新規登録で該当データ有りの場合には重複
                            if (recBgnGdsPMWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            // 既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            // Close
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Updateコマンドの生成
                        commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine
                                    + "SET" + Environment.NewLine
                                    + " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine
                                    + " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine
                                    + " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine
                                    + " , GOODSNORF=@GOODSNO" + Environment.NewLine
                                    + " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine
                                    + " , GOODSMAKERNMRF=@GOODSMAKERNM" + Environment.NewLine
                                    + " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine
                                    + " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine
                                    + " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine
                                    + " , GOODSCOMMENTRF=@GOODSCOMMENT" + Environment.NewLine
                                    + " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + " , LISTPRICERF=@LISTPRICE" + Environment.NewLine
                                    + " , UNITCALCRATERF=@UNITCALCRATE" + Environment.NewLine
                                    + " , UNITPRICERF=@UNITPRICE" + Environment.NewLine
                                    + " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine
                                    + " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine
                                    + " , MODELFITDIVRF=@MODELFITDIV" + Environment.NewLine
                                    + " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine
                                    + " , DISPLAYDIVCODERF=@DISPLAYDIVCODE" + Environment.NewLine
                                    + " , BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE" + Environment.NewLine
                                    + " , GOODSIMAGERF=@GOODSIMAGE" + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        //登録ヘッダ情報を設定
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;
                    }
                    else
                    {
                        //　更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (recBgnGdsPMWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Insertコマンドの生成
                        commandText = "INSERT INTO RECBGNGDSRF (" + Environment.NewLine
                                    + " CREATEDATETIMERF" + Environment.NewLine
                                    + ", UPDATEDATETIMERF" + Environment.NewLine
                                    + ", LOGICALDELETECODERF" + Environment.NewLine
//                                    + ", INQORIGINALEPCDRF" + Environment.NewLine
//                                    + ", INQORIGINALSECCDRF" + Environment.NewLine
                                    + ", INQOTHEREPCDRF" + Environment.NewLine
                                    + ", INQOTHERSECCDRF" + Environment.NewLine
                                    + ", GOODSNORF" + Environment.NewLine
                                    + ", GOODSMAKERCDRF" + Environment.NewLine
                                    + ", GOODSMAKERNMRF" + Environment.NewLine
                                    + ", GOODSNAMERF" + Environment.NewLine
                                    + ", BLGROUPCODERF" + Environment.NewLine
                                    + ", BLGOODSCODERF" + Environment.NewLine
                                    + ", GOODSCOMMENTRF" + Environment.NewLine
                                    + ", MKRSUGGESTRTPRICRF" + Environment.NewLine
                                    + ", LISTPRICERF" + Environment.NewLine
                                    + ", UNITCALCRATERF" + Environment.NewLine
                                    + ", UNITPRICERF" + Environment.NewLine
                                    + ", APPLYSTADATERF" + Environment.NewLine
                                    + ", APPLYENDDATERF" + Environment.NewLine
                                    + ", MODELFITDIVRF" + Environment.NewLine
                                    + ", CUSTRATEGRPCODERF" + Environment.NewLine
                                    + ", DISPLAYDIVCODERF" + Environment.NewLine
                                    + ", BRGNGOODSGRPCODERF" + Environment.NewLine
                                    + ", GOODSIMAGERF" + Environment.NewLine
                                    + ") VALUES (" + Environment.NewLine
                                    + "  @CREATEDATETIME" + Environment.NewLine
                                    + ", @UPDATEDATETIME" + Environment.NewLine
                                    + ", @LOGICALDELETECODE" + Environment.NewLine
//                                    + ", '' " + Environment.NewLine
//                                    + ", '' " + Environment.NewLine
                                    + ", @INQOTHEREPCD" + Environment.NewLine
                                    + ", @INQOTHERSECCD" + Environment.NewLine
                                    + ", @GOODSNO" + Environment.NewLine
                                    + ", @GOODSMAKERCD" + Environment.NewLine
                                    + ", @GOODSMAKERNM" + Environment.NewLine
                                    + ", @GOODSNAME" + Environment.NewLine
                                    + ", @BLGROUPCODE" + Environment.NewLine
                                    + ", @BLGOODSCODE" + Environment.NewLine
                                    + ", @GOODSCOMMENT" + Environment.NewLine
                                    + ", @MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + ", @LISTPRICE" + Environment.NewLine
                                    + ", @UNITCALCRATE" + Environment.NewLine
                                    + ", @UNITPRICE" + Environment.NewLine
                                    + ", @APPLYSTADATE" + Environment.NewLine
                                    + ", @APPLYENDDATE" + Environment.NewLine
                                    + ", @MODELFITDIV" + Environment.NewLine
                                    + ", @CUSTRATEGRPCODE" + Environment.NewLine
                                    + ", @DISPLAYDIVCODE" + Environment.NewLine
                                    + ", @BRGNGOODSGRPCODE" + Environment.NewLine
                                    + ", @GOODSIMAGE" + Environment.NewLine
                                    + ")" + Environment.NewLine;

                        //登録ヘッダ情報を設定
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;
                        recBgnGdsPMWork.CreateDateTime = DateTime.Now;
                    }

                    // SqlReader Close
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsMakerNm = sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);
                    SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
                    SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
                    SqlParameter paraUnitCalcRate = sqlCommand.Parameters.Add("@UNITCALCRATE", SqlDbType.Float);
                    SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    SqlParameter paraModelFitDiv = sqlCommand.Parameters.Add("@MODELFITDIV", SqlDbType.SmallInt);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);
                    SqlParameter paraBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                    SqlParameter paraGoodsImage = sqlCommand.Parameters.Add("@GOODSIMAGE", SqlDbType.VarBinary);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.LogicalDeleteCode);
                    paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    paraGoodsMakerNm.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsMakerNm);
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsName);
                    paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.BLGroupCode);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.BLGoodsCode);
                    paraGoodsComment.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsComment);
                    paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.MkrSuggestRtPric);
                    paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.ListPrice);
                    paraUnitCalcRate.Value = SqlDataMediator.SqlSetDouble(recBgnGdsPMWork.UnitCalcRate);
                    paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsPMWork.UnitPrice);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyEndDate);
                    paraModelFitDiv.Value = SqlDataMediator.SqlSetInt16(recBgnGdsPMWork.ModelFitDiv);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.CustRateGrpCode);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.DisplayDivCode);
                    paraBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnGdsPMWork.BrgnGoodsGrpCode);
                    paraGoodsImage.Value = SqlDataMediator.SqlSetBinary(recBgnGdsPMWork.GoodsImage);

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    if (paraGoodsName.Size == 0) paraGoodsName.Value = string.Empty;
                    if (paraGoodsComment.Size == 0) paraGoodsComment.Value = string.Empty;
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    // 登録・更新実行
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraobj = recBgnGdsPMWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProc");
            }

            return status;
        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 登録・更新処理（実処理）
        /// </summary>
        /// <param name="paraCustobj">RecBgnCustPMWork登録データ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProcCust(ref object paraCustobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnCustPMWork recBgnCustPMWork = paraCustobj as RecBgnCustPMWork;
                string commandText = string.Empty;

                // コマンド作成
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // お買得商品得意先個別設定マスタ Selectコマンド
                    commandText = MakeRecBgnCustRFSelectString()
                                + MakeRecBgnCustRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyStaDate);

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnCustPMWork.UpdateDateTime)
                        {
                            // 新規登録で該当データ有りの場合には重複
                            if (recBgnCustPMWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            // 既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            // Close
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Updateコマンドの生成
                        commandText = "UPDATE RECBGNCUSTRF" + Environment.NewLine
                                    + "SET" + Environment.NewLine
                                    + " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine
                                    + " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " , INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine
                                    + " , INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine
                                    + " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine
                                    + " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine
                                    + " , GOODSNORF=@GOODSNO" + Environment.NewLine
                                    + " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine
                                    + " , GOODSAPPLYSTADATERF=@GOODSAPPLYSTADATE" + Environment.NewLine
                                    + " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine
                                    + " , MNGSECTIONCODERF=@MNGSECTIONCODE" + Environment.NewLine
                                    + " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + " , LISTPRICERF=@LISTPRICE" + Environment.NewLine
                                    + " , UNITCALCRATERF=@UNITCALCRATE" + Environment.NewLine
                                    + " , UNITPRICERF=@UNITPRICE" + Environment.NewLine
                                    + " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine
                                    + " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine
                                    + " , BRGNGOODSGRPCODERF=@BRGNGOODSGRPCODE" + Environment.NewLine
                                    + " , DISPLAYDIVCODERF=@DISPLAYDIVCODE" + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine
                                    + " AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD " + Environment.NewLine
                                    + " AND INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        //登録ヘッダ情報を設定
                        recBgnCustPMWork.UpdateDateTime = DateTime.Now;
                    }
                    else
                    {
                        //　更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (recBgnCustPMWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        //Insertコマンドの生成
                        commandText = "INSERT INTO RECBGNCUSTRF (" + Environment.NewLine
                                    + "  CREATEDATETIMERF" + Environment.NewLine
                                    + ", UPDATEDATETIMERF" + Environment.NewLine
                                    + ", LOGICALDELETECODERF" + Environment.NewLine
                                    + ", INQORIGINALEPCDRF" + Environment.NewLine
                                    + ", INQORIGINALSECCDRF" + Environment.NewLine
                                    + ", INQOTHEREPCDRF" + Environment.NewLine
                                    + ", INQOTHERSECCDRF" + Environment.NewLine
                                    + ", GOODSNORF" + Environment.NewLine
                                    + ", GOODSMAKERCDRF" + Environment.NewLine
                                    + ", GOODSAPPLYSTADATERF" + Environment.NewLine
                                    + ", CUSTOMERCODERF" + Environment.NewLine
                                    + ", MNGSECTIONCODERF" + Environment.NewLine
                                    + ", MKRSUGGESTRTPRICRF" + Environment.NewLine
                                    + ", LISTPRICERF" + Environment.NewLine
                                    + ", UNITCALCRATERF" + Environment.NewLine
                                    + ", UNITPRICERF" + Environment.NewLine
                                    + ", APPLYSTADATERF" + Environment.NewLine
                                    + ", APPLYENDDATERF" + Environment.NewLine
                                    + ", BRGNGOODSGRPCODERF" + Environment.NewLine
                                    + ", DISPLAYDIVCODERF" + Environment.NewLine
                                    + ") VALUES (" + Environment.NewLine
                                    + "  @CREATEDATETIME" + Environment.NewLine
                                    + ", @UPDATEDATETIME" + Environment.NewLine
                                    + ", @LOGICALDELETECODE" + Environment.NewLine
                                    + ", @INQORIGINALEPCD" + Environment.NewLine
                                    + ", @INQORIGINALSECCD" + Environment.NewLine
                                    + ", @INQOTHEREPCD" + Environment.NewLine
                                    + ", @INQOTHERSECCD" + Environment.NewLine
                                    + ", @GOODSNO" + Environment.NewLine
                                    + ", @GOODSMAKERCD" + Environment.NewLine
                                    + ", @GOODSAPPLYSTADATE" + Environment.NewLine
                                    + ", @CUSTOMERCODE" + Environment.NewLine
                                    + ", @MNGSECTIONCODE" + Environment.NewLine
                                    + ", @MKRSUGGESTRTPRIC" + Environment.NewLine
                                    + ", @LISTPRICE" + Environment.NewLine
                                    + ", @UNITCALCRATE" + Environment.NewLine
                                    + ", @UNITPRICE" + Environment.NewLine
                                    + ", @APPLYSTADATE" + Environment.NewLine
                                    + ", @APPLYENDDATE" + Environment.NewLine
                                    + ", @BRGNGOODSGRPCODE" + Environment.NewLine
                                    + ", @DISPLAYDIVCODE" + Environment.NewLine
                                    + ")" + Environment.NewLine;

                        //登録ヘッダ情報を設定
                        recBgnCustPMWork.UpdateDateTime = DateTime.Now;
                        recBgnCustPMWork.CreateDateTime = DateTime.Now;
                    }

                    // SqlReader Close
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsApplyStaDate = sqlCommand.Parameters.Add("@GOODSAPPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
                    SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
                    SqlParameter paraUnitCalcRate = sqlCommand.Parameters.Add("@UNITCALCRATE", SqlDbType.Float);
                    SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    SqlParameter paraBrgnGoodsGrpCode = sqlCommand.Parameters.Add("@BRGNGOODSGRPCODE", SqlDbType.SmallInt);
                    SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnCustPMWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnCustPMWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.LogicalDeleteCode);
                    paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);
                    paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);
                    paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);
                    paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);
                    paraGoodsApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsApplyStaDate);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.CustomerCode);
                    paraMngSectionCode.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.MngSectionCode);
                    paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.MkrSuggestRtPric);
                    paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.ListPrice);
                    paraUnitCalcRate.Value = SqlDataMediator.SqlSetDouble(recBgnCustPMWork.UnitCalcRate);
                    paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnCustPMWork.UnitPrice);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyStaDate);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.ApplyEndDate);
                    paraBrgnGoodsGrpCode.Value = SqlDataMediator.SqlSetInt16(recBgnCustPMWork.BrgnGoodsGrpCode);
                    paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.DisplayDivCode);

                    // 登録・更新実行
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraCustobj = recBgnCustPMWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProcCust");
            }

            return status;
        }

        /// <summary>
        /// PM離島価格マスタ 登録・更新処理（実処理）
        /// </summary>
        /// <param name="paraIsolobj">PmIsolPrcWork登録データ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int WriteProcIsol(ref object paraIsolobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                PmIsolPrcWork pmIsolPrcWork = paraIsolobj as PmIsolPrcWork;
                string commandText = string.Empty;

                // コマンド作成
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    //Insertコマンドの生成
                    commandText = " INSERT INTO PMISOLPRCRF ( " + Environment.NewLine
                                + "  CREATEDATETIMERF " + Environment.NewLine
                                + " , UPDATEDATETIMERF " + Environment.NewLine
                                + " , LOGICALDELETECODERF " + Environment.NewLine
                                + " , ENTERPRISECODERF " + Environment.NewLine
                                + " , SECTIONCODERF " + Environment.NewLine
                                + " , MAKERCODERF " + Environment.NewLine
                                + " , UPPERLIMITPRICERF " + Environment.NewLine
                                + " , PMFRACTIONPROCUNITRF " + Environment.NewLine
                                + " , PMFRACTIONPROCCDRF " + Environment.NewLine
                                + " , LISTPRICEUPRATERF " + Environment.NewLine
                                + " ) VALUES ( " + Environment.NewLine
                                + "   @CREATEDATETIME " + Environment.NewLine
                                + " , @UPDATEDATETIME " + Environment.NewLine
                                + " , @LOGICALDELETECODE " + Environment.NewLine
                                + " , @ENTERPRISECODE " + Environment.NewLine
                                + " , @SECTIONCODE " + Environment.NewLine
                                + " , @MAKERCODE " + Environment.NewLine
                                + " , @UPPERLIMITPRICE " + Environment.NewLine
                                + " , @PMFRACTIONPROCUNIT " + Environment.NewLine
                                + " , @PMFRACTIONPROCCD " + Environment.NewLine
                                + " , @LISTPRICEUPRATE " + Environment.NewLine
                                + " ) " + Environment.NewLine;

                    //登録ヘッダ情報を設定
                    pmIsolPrcWork.UpdateDateTime = DateTime.Now;
                    pmIsolPrcWork.CreateDateTime = DateTime.Now;

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                    SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                    SqlParameter paraPMFractionProcUnit = sqlCommand.Parameters.Add("@PMFRACTIONPROCUNIT", SqlDbType.Float);
                    SqlParameter paraPMFractionProcCd = sqlCommand.Parameters.Add("@PMFRACTIONPROCCD", SqlDbType.Int);
                    SqlParameter paraListPriceUpRate = sqlCommand.Parameters.Add("@LISTPRICEUPRATE", SqlDbType.Float);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmIsolPrcWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmIsolPrcWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.LogicalDeleteCode);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.EnterpriseCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.SectionCode);
                    paraMakerCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.MakerCode);
                    paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.UpperLimitPrice);
                    paraPMFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.PMFractionProcUnit);
                    paraPMFractionProcCd.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.PMFractionProcCd);
                    paraListPriceUpRate.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.ListPriceUpRate);

                    // 登録実行
                    sqlCommand.CommandText = commandText;
                    sqlCommand.ExecuteNonQuery();

                    paraIsolobj = pmIsolPrcWork as object;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.WriteProcIsol");
            }

            return status;
        }

        #endregion

        #region 検索処理
        /// <summary>
        /// 購入者向け検索処理。
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015/02/25</br>
        /// </remarks>
        public int SearchForBuyer(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retobj = null;
            count = 0;

            try
            {
                // コネクション作成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // 検索処理
                status = SearchForBuyperProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
                retobj = new ArrayList();
                count = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 購入者向け検索処理。
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">件数</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015/01/19</br>
        /// </remarks>
        public int SearchForBuyperProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            retobj = null;
            count = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(4096);

                sqlCommand = new SqlCommand(string.Empty, sqlConnection);

                #region SQL構築
                sqlTxt.AppendLine(" SELECT ");
                sqlTxt.AppendLine(" * ");
                sqlTxt.AppendLine(" FROM ( ");
                sqlTxt.AppendLine("   SELECT ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALEPCDRF   AS EPSCCNT_CNECTORIGINALEPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALSECCDRF  AS EPSCCNT_CNECTORIGINALSECCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHEREPCDRF      AS EPSCCNT_CNECTOTHEREPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHERSECCDRF     AS EPSCCNT_CNECTOTHERSECCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.CREATEDATETIMERF      AS RECGOOD_CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECCUST.CREATEDATETIMERF      AS RECCUST_CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.UPDATEDATETIMERF      AS RECGOOD_UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECCUST.UPDATEDATETIMERF      AS RECCUST_UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.LOGICALDELETECODERF   AS RECGOOD_LOGICALDELETECODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSMAKERCDRF        AS RECGOOD_GOODSMAKERCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSMAKERNMRF        AS RECGOOD_GOODSMAKERNMRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSNORF             AS RECGOOD_GOODSNORF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSNAMERF           AS RECGOOD_GOODSNAMERF, ");
                sqlTxt.AppendLine("   RECGOOD.BLGROUPCODERF         AS RECGOOD_BLGROUPCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.BLGOODSCODERF         AS RECGOOD_BLGOODSCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSCOMMENTRF        AS RECGOOD_GOODSCOMMENTRF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.MKRSUGGESTRTPRICRF,RECGOOD.MKRSUGGESTRTPRICRF) AS REC_MKRSUGGESTRTPRICRF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.LISTPRICERF,RECGOOD.LISTPRICERF)               AS REC_LISTPRICERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.UNITPRICERF,RECGOOD.UNITPRICERF)               AS REC_UNITPRICERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.APPLYSTADATERF,RECGOOD.APPLYSTADATERF)         AS REC_APPLYSTADATERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.APPLYENDDATERF,RECGOOD.APPLYENDDATERF)         AS REC_APPLYENDDATERF, ");
                sqlTxt.AppendLine("   RECGOOD.MODELFITDIVRF         AS RECGOOD_MODELFITDIVRF, ");
                sqlTxt.AppendLine("   RECGOOD.CUSTRATEGRPCODERF     AS RECGOOD_CUSTRATEGRPCODERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.DISPLAYDIVCODERF,RECGOOD.DISPLAYDIVCODERF)     AS REC_DISPLAYDIVCODERF, ");
                sqlTxt.AppendLine("   ISNULL(RECCUST.BRGNGOODSGRPCODERF,RECGOOD.BRGNGOODSGRPCODERF) AS REC_BRGNGOODSGRPCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSIMAGERF          AS RECGOOD_GOODSIMAGERF, ");
                sqlTxt.AppendLine("   RECCUST.CUSTOMERCODERF        AS RECCUST_CUSTOMERCODERF, ");
                sqlTxt.AppendLine("   RECCUST.MNGSECTIONCODERF      AS RECCUST_MNGSECTIONCODERF, ");

                sqlTxt.AppendLine("   PMISOLP.MAKERCODERF           AS PMISOLP_MAKERCODERF, ");
                sqlTxt.AppendLine("   PMISOLP.UPPERLIMITPRICERF     AS PMISOLP_UPPERLIMITPRICERF, ");
                sqlTxt.AppendLine("   PMISOLP.PMFRACTIONPROCUNITRF  AS PMISOLP_PMFRACTIONPROCUNITRF, ");
                sqlTxt.AppendLine("   PMISOLP.PMFRACTIONPROCCDRF    AS PMISOLP_PMFRACTIONPROCCDRF, ");
                sqlTxt.AppendLine("   PMISOLP.LISTPRICEUPRATERF     AS PMISOLP_LISTPRICEUPRATERF, ");

                sqlTxt.AppendLine("   ROW_NUMBER() OVER ( ");
                sqlTxt.AppendLine("     PARTITION BY EPSCCNT.CNECTORIGINALEPCDRF,EPSCCNT.CNECTORIGINALSECCDRF,EPSCCNT.CNECTOTHEREPCDRF,EPSCCNT.CNECTOTHERSECCDRF,RECGOOD.GOODSMAKERCDRF,RECGOOD.GOODSNORF,RECGOOD.APPLYSTADATERF");//MOD:2015.03.28 松本 宏紀 #3257
                sqlTxt.AppendLine("     ORDER BY     RECGOOD.INQOTHERSECCDRF DESC,PMISOLP.UPPERLIMITPRICERF ASC ");
                sqlTxt.AppendLine("   ) AS ROWNUM ");
                sqlTxt.AppendLine("   FROM RECBGNGDSRF         AS RECGOOD WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   INNER JOIN  SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("    ON    EPCNECT.LOGICALDELETECODERF = 0  ");
                sqlTxt.AppendLine("      AND EPCNECT.DISCDIVCDRF         = 0  ");
                sqlTxt.AppendLine("      AND EPCNECT.CNECTORIGINALEPCDRF = @FINDINQORIGINALEPCD ");
                sqlTxt.AppendLine("      AND EPCNECT.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF  ");
                sqlTxt.AppendLine("    INNER JOIN SCMEPSCCNTRF  AS EPSCCNT WITH(READUNCOMMITTED)   ");
                sqlTxt.AppendLine("    ON    EPSCCNT.LOGICALDELETECODERF  = 0  ");
                sqlTxt.AppendLine("      AND EPSCCNT.DISCDIVCDRF          = 0  ");
                #region ADD:2015.03.24 松本 宏紀 #3251 ------------------- >>>>>
                sqlTxt.AppendLine("      AND EPSCCNT.PMUPLOADDIVRF       = 1  ");
                sqlTxt.AppendLine("      AND ISNULL(EPSCCNT.PMDBIDRF,'') != ''");
                #endregion
                sqlTxt.AppendLine("      AND EPSCCNT.CNECTORIGINALEPCDRF  = EPCNECT.CNECTORIGINALEPCDRF ");
                sqlTxt.AppendLine("      AND EPSCCNT.CNECTOTHEREPCDRF     = EPCNECT.CNECTOTHEREPCDRF   ");
                sqlTxt.AppendLine("      AND (EPSCCNT.PCCUOECOMMMETHODRF  = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1)  ");
                sqlTxt.AppendLine("      AND (RECGOOD.INQOTHERSECCDRF='00' OR EPSCCNT.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF)  ");

                // 問合せ元拠点コード
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOriginalSecCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALSECCDRF = @FINDCNECTORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalSecCd);
                }
                // 問合せ先企業コード
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOtherEpCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF     = @FINDCNECTOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                }
                // 問合せ先拠点コード
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.InqOtherSecCd))
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHERSECCDRF    = @FINDCNECTOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDCNECTOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                }
                sqlTxt.AppendLine("   LEFT JOIN RECBGNCUSTRF AS RECCUST WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("    ON   RECCUST.INQOTHEREPCDRF      = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.INQOTHERSECCDRF     = RECGOOD.INQOTHERSECCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSNORF           = RECGOOD.GOODSNORF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSMAKERCDRF      = RECGOOD.GOODSMAKERCDRF ");
                sqlTxt.AppendLine("     AND RECCUST.GOODSAPPLYSTADATERF = RECGOOD.APPLYSTADATERF ");
                sqlTxt.AppendLine("     AND RECCUST.INQORIGINALEPCDRF   = @FINDINQORIGINALEPCD ");
                sqlTxt.AppendLine("     AND RECCUST.INQORIGINALSECCDRF  = EPSCCNT.CNECTORIGINALSECCDRF ");
                sqlTxt.AppendLine("   LEFT JOIN PMISOLPRCRF  AS PMISOLP WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("    ON   PMISOLP.ENTERPRISECODERF    = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.SECTIONCODERF       = EPSCCNT.CNECTOTHERSECCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.LOGICALDELETECODERF = 0 ");
                sqlTxt.AppendLine("     AND PMISOLP.MAKERCODERF         = RECGOOD.GOODSMAKERCDRF ");
                sqlTxt.AppendLine("     AND PMISOLP.UPPERLIMITPRICERF  >= RECGOOD.MKRSUGGESTRTPRICRF ");

                sqlTxt.AppendLine("   WHERE RECGOOD.LOGICALDELETECODERF = @LOGICALDELETECODE ");

                //メーカーコード（開始）
                if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                {
                    sqlTxt.AppendLine("    AND RECGOOD.GOODSMAKERCDRF>=@GOODSMAKERCDST").Append(Environment.NewLine);
                    SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                }
                //メーカーコード（終了）
                if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                {
                    sqlTxt.AppendLine("    AND RECGOOD.GOODSMAKERCDRF<=@GOODSMAKERCDED").Append(Environment.NewLine);
                    SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                }

                // 公開開始日（開始）～公開開始日（終了）
                if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                {
                    sqlTxt.Append(" AND ((RECGOOD.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RECGOOD.APPLYENDDATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYENDDATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYSTADATERF) ").Append(Environment.NewLine);
                    sqlTxt.Append(" OR   (RECGOOD.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RECGOOD.APPLYENDDATERF)) ").Append(Environment.NewLine);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                }

                // 公開開始日（開始）～
                if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                {
                    sqlTxt.Append(" AND RECGOOD.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                }

                // ～公開開始日（終了）
                if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                {
                    sqlTxt.Append(" AND RECGOOD.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                    SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                }

                //品番*
                if (!string.IsNullOrEmpty(recBgnGdsSearchParaWork.GoodsNo))
                {
                    string workGoodsNo = recBgnGdsSearchParaWork.GoodsNo.Trim();
                    if (workGoodsNo.Substring(workGoodsNo.Length - 1, 1) == "*")
                    {
                        sqlTxt.AppendLine("    AND REPLACE(RECGOOD.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(workGoodsNo.Substring(0, workGoodsNo.Length - 1) + "%");
                    }
                    else
                    {
                        sqlTxt.AppendLine("    AND REPLACE(RECGOOD.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(workGoodsNo);
                    }
                }
                sqlTxt.AppendLine("  ) AS SUB01 ");
                sqlTxt.AppendLine("  WHERE ROWNUM = 1 AND REC_DISPLAYDIVCODERF = 0");
                sqlTxt.AppendLine("  ORDER BY  ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTORIGINALEPCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTORIGINALSECCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTOTHEREPCDRF, ");
                sqlTxt.AppendLine("    EPSCCNT_CNECTOTHERSECCDRF, ");
                sqlTxt.AppendLine("    RECGOOD_GOODSMAKERCDRF, ");
                sqlTxt.AppendLine("    RECGOOD_BLGOODSCODERF ");
                #endregion

                //論理削除区分
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                //問合せ元企業コード
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalEpCd);

                sqlCommand.CommandText = sqlTxt.ToString();

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (al.Count == 20000)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retobj = al;
                        count = 20001;
                        return status;
                    }
                    RecBgnGdsWork recBgnGdsWork = CopyToRecBgnGdsWorkFromBuyerSearchReader(ref myReader);
                    al.Add(recBgnGdsWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                #region 離島価格マスタ計算処理
                #endregion
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
                errMsg = ex.ToString();
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
            retobj = al;

            return status;
        }


        /// <summary>
        /// お買得商品設定マスタ 検索処理（実処理）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">件数</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            count = 0;
            retobj = null;
            
            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region Where句
                    sqlTxt.Append(" WHERE").Append(Environment.NewLine);

                    //論理削除区分
                    sqlTxt.Append(" RBG.LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // 問合せ先企業コード
                    if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                    }
 
                    // 問合せ先拠点コード
                    //--- UPD  2015/03/03 小栗 ----->>>>>                    
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
                    //if (inqOtherSecCd != 0)
                    if (recBgnGdsSearchParaWork.InqOtherSecCd.Trim() != string.Empty)
                    //--- UPD  2015/03/03 小栗 -----<<<<<                    
                    {
                        sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                    }

                    // メーカーコード（開始）
                    if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF>=@GOODSMAKERCDST ").Append(Environment.NewLine);
                        SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                    }
                    // メーカーコード（終了）
                    if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF<=@GOODSMAKERCDED ").Append(Environment.NewLine);
                        SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                    }

                    // 公開開始日（開始）～公開開始日（終了）
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF) ").Append(Environment.NewLine); 
                        sqlTxt.Append(" OR   (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)) ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // 公開開始日（開始）～
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                    {
                        // --- UPD 2015/03/23 Y.Wakita ---------->>>>>
                        //sqlTxt.Append(" AND RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        sqlTxt.Append(" AND (RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        sqlTxt.Append("  OR (RBG.DISPLAYDIVCODERF=1 AND RBG.APPLYSTADATERF>=@APPLYSTADATE)) ").Append(Environment.NewLine);
                        // --- UPD 2015/03/23 Y.Wakita ----------<<<<<
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    }

                    // ～公開開始日（終了）
                    if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                    &&  (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // 品番*
                    if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
                        }
                        else
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
                        }
                    }

                    #endregion

                    // OrderBy句追記
                    #region ORDER BY句
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.APPLYSTADATERF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retobj = al;
                            count = 20001;
                            return status;
                        }
                        RecBgnGdsPMWork recBgnGdsPMWork = CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(recBgnGdsPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProc", status);
                errMsg = ex.ToString();
            }
            retobj = al;

            return status;
        }

        /// <summary>
        /// お買得商品設定マスタ 検索処理（実処理）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果リスト</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定問合せ先企業コードの該当データを検索します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProc(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retobj = null;
            ArrayList al = new ArrayList();            
            
            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE句
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // 問合せ先企業コード
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);

                    //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    #endregion

                    // OrderBy句追記
                    #region ORDER BY句
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBG.APPLYSTADATERF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProc", status);
                errMsg = ex.ToString();
            }

            retobj = al;

            return status;
        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 検索処理（実処理）
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProcCust(out object retCustobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            retCustobj = null;

            try
            {
                RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    // Join条件
                    sqlTxt.Append(" INNER JOIN RECBGNGDSRF RBG WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append(" ON RBG.INQOTHEREPCDRF = RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ---------->>>>>
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF = RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ----------<<<<<
                    sqlTxt.Append(" AND RBG.GOODSNORF = RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF = RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.APPLYSTADATERF = RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);

                    #region Where句
                    sqlTxt.Append(" WHERE").Append(Environment.NewLine);

                    //論理削除区分
                    sqlTxt.Append(" RBG.LOGICALDELETECODERF=@LOGICALDELETECODE ").Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

                    // 問合せ先企業コード
                    if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        sqlTxt.Append(" AND RBG.INQOTHEREPCDRF=@INQOTHEREPCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
                    }

                    // 問合せ先拠点コード
                    //--- UPD  2015/03/03 小栗 ----->>>>>                    
                    //int inqOtherSecCd = 0;
                    //int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
                    //if (inqOtherSecCd != 0)
                    if (recBgnGdsSearchParaWork.InqOtherSecCd.Trim() != string.Empty)                    
                    //--- UPD  2015/03/03 小栗 -----<<<<<
                    {
                        sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD ").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
                    }

                    // メーカーコード（開始）
                    if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF>=@GOODSMAKERCDST ").Append(Environment.NewLine);
                        SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
                    }
                    // メーカーコード（終了）
                    if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
                    {
                        sqlTxt.Append(" AND RBG.GOODSMAKERCDRF<=@GOODSMAKERCDED ").Append(Environment.NewLine);
                        SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
                    }

                    // 公開開始日（開始）～公開開始日（終了）
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF) ").Append(Environment.NewLine);
                        sqlTxt.Append(" OR   (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)) ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // 公開開始日（開始）～
                    if ((recBgnGdsSearchParaWork.ApplyDateSt != 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd == 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYENDDATERF>=@APPLYSTADATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
                    }

                    // ～公開開始日（終了）
                    if ((recBgnGdsSearchParaWork.ApplyDateSt == 0)
                    && (recBgnGdsSearchParaWork.ApplyDateEd != 0))
                    {
                        sqlTxt.Append(" AND RBG.APPLYSTADATERF<=@APPLYENDDATE ").Append(Environment.NewLine);
                        SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
                    }

                    // 品番*
                    if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
                        }
                        else
                        {
                            sqlTxt.Append(" AND REPLACE(RBG.GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','') ").Append(Environment.NewLine);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
                        }
                    }

                    #endregion

                    // OrderBy句追記
                    #region ORDER BY句
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retCustobj = al;
                            return status;
                        }
                        RecBgnCustPMWork recBgnCustPMWork = CopyToRecBgnCustPMWorkFromReader(ref myReader);
                        al.Add(recBgnCustPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProcCust", status);
                errMsg = ex.ToString();
            }
            retCustobj = al;

            return status;

        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 検索処理（実処理）
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果リスト</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int SearchProcCust(out object retCustobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retCustobj = null;
            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    // Join条件
                    sqlTxt.Append(" INNER JOIN RECBGNGDSRF RBG WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append(" ON RBG.INQOTHEREPCDRF = RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ---------->>>>>
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF = RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    // --- ADD 2015/03/16 Y.Wakita ----------<<<<<
                    sqlTxt.Append(" AND RBG.GOODSNORF = RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF = RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND RBG.APPLYSTADATERF = RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);

                    #region WHERE句
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // 問合せ先企業コード
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);

                    //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlTxt.Append(" AND RBG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    #endregion

                    // OrderBy句追記
                    #region ORDER BY句
                    sqlTxt.Append(" ORDER BY ").Append(Environment.NewLine);
                    sqlTxt.Append(" RBC.INQOTHEREPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQOTHERSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSNORF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSMAKERCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.GOODSAPPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append(" , RBC.INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlTxt.ToString();

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (al.Count == 20000)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            retCustobj = al;
                            return status;
                        }
                        RecBgnCustPMWork recBgnCustPMWork = CopyToRecBgnCustPMWorkFromReader(ref myReader);
                        al.Add(recBgnCustPMWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();

                } // end using
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.SearchProcCust", status);
                errMsg = ex.ToString();
            }

            retCustobj = al;

            return status;
        }

        #endregion 

        #region 読込処理

        /// <summary>
        /// お買得商品設定マスタ 読込処理（実処理）
        /// </summary>
        /// <param name="retobj">RecBgnPMWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsPMWork検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnenction</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadProc(out object retobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retobj = null;
            ArrayList al = new ArrayList(); 

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                StringBuilder whereTxt = new StringBuilder(string.Empty);

                using(SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(),sqlConnection))
                {

                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE句

                    // 問合せ先企業コード
                    if (recBgnGdsPMWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    }

                    // 問合せ先拠点コード
                    if (recBgnGdsPMWork.InqOtherSecCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    }

                    // 商品メーカーコード
                    if (recBgnGdsPMWork.GoodsMakerCd != 0)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    }

                    // 商品番号
                    if (recBgnGdsPMWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBG.GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    }

                    if (whereTxt.ToString().Trim() != string.Empty)
                    {
                        sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                        sqlTxt.Append(whereTxt.ToString()).Append(Environment.NewLine);
                    }

                    #endregion

                    // コマンド設定
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    // Reader → Work
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = this.CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.ReadProc", status);
                errMsg = ex.ToString();
            }
            finally
            {
                // 検索結果リストを格納
                retobj = al;
            }

            return status;

        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 読込処理（実処理）
        /// </summary>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果リスト</param>
        /// <param name="paraList">検索結果リスト</param>
        /// <param name="sqlConnection">SqlConnenction</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタを検索し結果リストを返却します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadProcCust(out object retCustobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retCustobj = null;
            ArrayList al = new ArrayList();

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                StringBuilder whereTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {
                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    #region WHERE句

                    // 問合せ先企業コード
                    if (recBgnGdsPMWork.InqOtherEpCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    }

                    // 問合せ先拠点コード
                    if (recBgnGdsPMWork.InqOtherSecCd.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    }

                    // 商品メーカーコード
                    if (recBgnGdsPMWork.GoodsMakerCd != 0)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    }

                    // 商品番号
                    if (recBgnGdsPMWork.GoodsNo.Trim() != string.Empty)
                    {
                        if (whereTxt.ToString().Trim() != string.Empty)
                        {
                            whereTxt.Append(" AND ").Append(Environment.NewLine);
                        }
                        whereTxt.Append(" RBC.GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    }

                    if (whereTxt.ToString().Trim() != string.Empty)
                    {
                        sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                        sqlTxt.Append(whereTxt.ToString()).Append(Environment.NewLine);
                    }

                    #endregion

                    // コマンド設定
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    // Reader → Work
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        RecBgnGdsPMWork work = this.CopyToRecBgnGdsPMWorkFromReader(ref myReader);
                        al.Add(work);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecBgnGdsDB.ReadProcCust", status);
                errMsg = ex.ToString();
            }
            finally
            {
                // 検索結果リストを格納
                retCustobj = al;
            }

            return status;

        }

        #endregion

        #region 完全削除処理

        /// <summary>
        /// お買得商品設定マスタ 完全削除処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタを物理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProc(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // お買得商品設定マスタ Selectコマンド
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        // SqlReader Close
                        if (myReader != null)
                        {
                            myReader.Close();
                        }

                        // Deleteコマンドの生成
                        commandText = " DELETE FROM RECBGNGDSRF " + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        sqlCommand.CommandText = commandText;

                        // Delete実行
                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else
                    {
                        // 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                    }

                } // end using

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProc");
            }

            return status;
        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 完全削除処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタのキー情報よりお買得商品得意先個別設定マスタを物理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProcCust(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // Deleteコマンドの生成
                    commandText = " DELETE FROM RECBGNCUSTRF " + Environment.NewLine
                                + " WHERE" + Environment.NewLine
                                + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                // --- UPD 2015/03/09 Y.Wakita Redmine#329 ---------->>>>>
                                //+ " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                                + " AND GOODSAPPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                                // --- UPD 2015/03/09 Y.Wakita Redmine#329 ----------<<<<<

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    // Delete実行
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                } // end using

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProcCust");
            }

            return status;
        }

        /// <summary>
        /// PM離島価格マスタ 完全削除処理（実処理）
        /// </summary>
        /// <param name="makercode">メーカーコード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : PM離島価格マスタを物理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int DeleteProcIsol(int makercode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                string commandText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // Deleteコマンドの生成
                    commandText = " DELETE FROM PMISOLPRCRF " + Environment.NewLine
                                + " WHERE " + Environment.NewLine
                                + " MAKERCODERF=@MAKERCODE " + Environment.NewLine;

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成
                    SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(makercode);

                    // Delete実行
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
                } // end using

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteProcIsol");
            }

            return status;
        }
        #endregion
        
        #region 論理削除処理

        /// <summary>
        /// お買得商品設定マスタ 論理削除処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="procMode">処理モード 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタを論理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // コマンド作成
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {
                    // お買得商品設定マスタ Selectコマンド
                    commandText = MakeRecBgnGdsRFSelectString()
                                + MakeRecBgnGdsRFWhereKeyString();

                    sqlCommand.CommandText = commandText;

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);
                    
                    // Read
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        if (updateDateTime != recBgnGdsPMWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader != null)
                            {
                                myReader.Close();
                            }
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 論理削除区分変更
                        if (procMode == 0)
                        {
                            //論理削除モードの場合
                            if (logicalDelCd == 0) recBgnGdsPMWork.LogicalDeleteCode = 1; //論理削除フラグをセット
                            else recBgnGdsPMWork.LogicalDeleteCode = 3; //完全削除フラグをセット
                        }
                        else
                        {
                            //復活モードの場合
                            if (logicalDelCd == 1) recBgnGdsPMWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // 既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 完全削除はデータなしを戻す

                                sqlCommand.Cancel();
                                if (myReader != null)
                                {
                                    myReader.Close();
                                }
                                return status;
                            }
                        }

                        // SqlReader Close
                        if (myReader != null)
                        {
                            myReader.Close();
                        }

                        // Updateコマンドの生成
                        commandText = " UPDATE RECBGNGDSRF " + Environment.NewLine
                                    + " SET" + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine
                                    + " WHERE " + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

                        sqlCommand.CommandText = commandText;

                        //登録ヘッダ情報を設定
                        recBgnGdsPMWork.UpdateDateTime = DateTime.Now;

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // 更新日時
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);    // 論理削除区分

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.LogicalDeleteCode);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        // Update実行
                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    }
                    else
                    {
                        // 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                } // end using

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDeleteProc");
            }

            return status;

        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 論理削除処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnCustPMWorkデータ</param>
        /// <param name="procMode">処理モード 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタを論理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int LogicalDeleteProcCust(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                string commandText = string.Empty;

                // コマンド作成
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
                {

                    // 論理削除区分変更
                    if (procMode == 0)
                    {
                        //論理削除モードの場合
                        // Updateコマンド
                        commandText = " UPDATE RECBGNCUSTRF " + Environment.NewLine
                                    + " SET " + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF = CASE WHEN LOGICALDELETECODERF = 0 THEN 1 ELSE 3 END " + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                    }
                    else
                    {
                        //復活モードの場合
                        // Updateコマンド
                        commandText = " UPDATE RECBGNCUSTRF " + Environment.NewLine
                                    + " SET " + Environment.NewLine
                                    + " UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine
                                    + " , LOGICALDELETECODERF = CASE WHEN LOGICALDELETECODERF = 1 THEN 0 ELSE LOGICALDELETECODERF END " + Environment.NewLine
                                    + " WHERE" + Environment.NewLine
                                    + " INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                                    + " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                                    + " AND GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                                    + " AND GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                                    + " AND APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;
                    }

                    //Parameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // 更新日時
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsPMWork.UpdateDateTime);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);
                    findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.ApplyStaDate);

                    sqlCommand.CommandText = commandText;

                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                    // Update実行
                    sqlCommand.ExecuteNonQuery();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


                } // end using

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDeleteProcCust");
            }

            return status;

        }

        #endregion

        #region 復活処理

        /// <summary>
        /// お買得商品設定マスタ 復活処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタの論理削除データを復活します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 論理削除処理を実施
            return LogicalDeleteProc(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 復活処理（実処理）
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタの論理削除データを復活します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteProcCust(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // 論理削除処理を実施
            return LogicalDeleteProcCust(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// お買得商品設定マスタ 登録、更新前、重複レコードの存在チェックを行う
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ 登録、更新前、重複レコードの存在チェックを行う</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnGdsPMWork recBgnGdsPMWork = paraobj as RecBgnGdsPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnGdsRFSelectString());

                    #region WHERE句
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // 問合せ先企業コード
                    sqlTxt.Append(" RBG.INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherEpCd);

                    // 問合せ先拠点コード
                    sqlTxt.Append(" AND RBG.INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.InqOtherSecCd);

                    // 商品番号
                    sqlTxt.Append(" AND RBG.GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsPMWork.GoodsNo);

                    // 商品メーカーコード
                    sqlTxt.Append(" AND RBG.GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsPMWork.GoodsMakerCd);

                    // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    if (recBgnGdsPMWork.DisplayDivCode == 1)
                    {
                        // 適用日
                        sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYSTADATE<=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYSTADATERF)").Append(Environment.NewLine);
                        sqlTxt.Append("  OR  (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYSTADATE>=RBG.APPLYENDDATERF))").Append(Environment.NewLine);
                    }
                    else
                    {
                        // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
	                    // 適用日
	                    sqlTxt.Append(" AND ((RBG.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYSTADATERF)").Append(Environment.NewLine);
	                    sqlTxt.Append("  OR  (RBG.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBG.APPLYENDDATERF))").Append(Environment.NewLine);
                        // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2015/03/23 Y.Wakita ----------<<<<<

                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsPMWork.ApplyStaDate);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsPMWork.ApplyEndDate);

                    #endregion

                    // コマンド設定
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraobj = recBgnGdsPMWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSave", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 登録、更新前、重複レコードの存在チェックを行う
        /// </summary>
        /// <param name="paraCustobj">RecBgnCustPMWorkデータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : お買得商品得意先個別設定マスタ 登録、更新前、重複レコードの存在チェックを行う</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSaveCust(ref object paraCustobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                RecBgnCustPMWork recBgnCustPMWork = paraCustobj as RecBgnCustPMWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Selectコマンド
                    sqlTxt.Append(MakeRecBgnCustRFSelectString());

                    #region WHERE句
                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

                    // 問合せ元企業コード
                    sqlTxt.Append(" RBC.INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalEpCd);

                    // 問合せ元拠点コード
                    sqlTxt.Append("  AND RBC.INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOriginalSecCd);

                    // 問合せ先企業コード
                    sqlTxt.Append("  AND RBC.INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherEpCd);

                    // 問合せ先拠点コード
                    sqlTxt.Append("  AND RBC.INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.InqOtherSecCd);

                    // 商品番号
                    sqlTxt.Append("  AND RBC.GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnCustPMWork.GoodsNo);

                    // 商品メーカーコード
                    sqlTxt.Append("  AND RBC.GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnCustPMWork.GoodsMakerCd);

                    // 適用日
                    sqlTxt.Append(" AND ((RBC.APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=RBC.APPLYENDDATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYENDDATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYSTADATERF)").Append(Environment.NewLine);
                    sqlTxt.Append("  OR  (RBC.APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=RBC.APPLYENDDATERF))").Append(Environment.NewLine);

                    SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                    paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnCustPMWork.ApplyStaDate);
                    SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                    paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnCustPMWork.ApplyEndDate);

                    #endregion

                    // コマンド設定
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraCustobj = recBgnCustPMWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSaveCust", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        /// <summary>
        /// PM離島価格マスタ 登録前、重複レコードの存在チェックを行う
        /// </summary>
        /// <param name="paraIsolobj">PmIsolPrcWorkデータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PM離島価格マスタ 登録前、重複レコードの存在チェックを行う</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        public int ReadDBBeforeSaveIsol(ref object paraIsolobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                PmIsolPrcWork pmIsolPrcWork = paraIsolobj as PmIsolPrcWork;
                StringBuilder sqlTxt = new StringBuilder(string.Empty);

                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
                {

                    // Selectコマンド
                    sqlTxt.Append(MakePmIsolPrcRFSelectString());

                    #region WHERE句

                    sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                    sqlTxt.Append(" PIP.ENTERPRISECODERF=@ENTERPRISECODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.SECTIONCODERF=@SECTIONCODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.MAKERCODERF=@MAKERCODE ").Append(Environment.NewLine);
                    sqlTxt.Append(" AND PIP.UPPERLIMITPRICERF=@UPPERLIMITPRICE ").Append(Environment.NewLine);

                    //Parameterオブジェクトの作成(検索用)
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                    SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(pmIsolPrcWork.SectionCode);
                    findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(pmIsolPrcWork.MakerCode);
                    findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(pmIsolPrcWork.UpperLimitPrice);

                    #endregion

                    // コマンド設定
                    sqlCommand.CommandText = sqlTxt.ToString();
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        paraIsolobj = pmIsolPrcWork as object;
                        if (myReader != null)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader != null)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSaveIsol", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }

        #endregion 

        #region クラス格納処理

        /// <summary>
        /// お買得商品設定マスタ 検索結果格納処理（Reader→RecBgnGdsPMWork）
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGdsPMWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaerの現在行をRecBgnGdsPMWorkへ格納します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnGdsPMWork CopyToRecBgnGdsPMWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnGdsPMWork recBgnGdsPMWork = new RecBgnGdsPMWork();

            recBgnGdsPMWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnGdsPMWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnGdsPMWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnGdsPMWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            recBgnGdsPMWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            recBgnGdsPMWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            recBgnGdsPMWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            recBgnGdsPMWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
            recBgnGdsPMWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            recBgnGdsPMWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            recBgnGdsPMWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            recBgnGdsPMWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
            recBgnGdsPMWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
            recBgnGdsPMWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
            recBgnGdsPMWork.UnitCalcRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNITCALCRATERF"));
            recBgnGdsPMWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
            recBgnGdsPMWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            recBgnGdsPMWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            recBgnGdsPMWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("MODELFITDIVRF"));
            recBgnGdsPMWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            recBgnGdsPMWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));
            recBgnGdsPMWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnGdsPMWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("GOODSIMAGERF"));

            return recBgnGdsPMWork;
        }

        /// <summary>
        /// お買得商品得意先個別設定マスタ 検索結果格納処理（Reader→RecBgnCustPMWork）
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnCustPMWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaerの現在行をRecBgnCustPMWorkへ格納します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private RecBgnCustPMWork CopyToRecBgnCustPMWorkFromReader(ref SqlDataReader myReader)
        {
            RecBgnCustPMWork recBgnCustPMWork = new RecBgnCustPMWork();

            recBgnCustPMWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            recBgnCustPMWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            recBgnCustPMWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            recBgnCustPMWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            recBgnCustPMWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            recBgnCustPMWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            recBgnCustPMWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            recBgnCustPMWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            recBgnCustPMWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            recBgnCustPMWork.GoodsApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSAPPLYSTADATERF"));
            recBgnCustPMWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            recBgnCustPMWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            recBgnCustPMWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
            recBgnCustPMWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
            recBgnCustPMWork.UnitCalcRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UNITCALCRATERF"));
            recBgnCustPMWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
            recBgnCustPMWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            recBgnCustPMWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            recBgnCustPMWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("BRGNGOODSGRPCODERF"));
            recBgnCustPMWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));

            return recBgnCustPMWork;
        }

        /// <summary>
        /// PM離島価格マスタ 検索結果格納処理（Reader→PmIsolPrcWork）
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmIsolPrcWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaerの現在行をPmIsolPrcWorkへ格納します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        private PmIsolPrcWork CopyToPmIsolPrcRFWorkFromReader(ref SqlDataReader myReader)
        {
            PmIsolPrcWork pmIsolPrcWork = new PmIsolPrcWork();

            pmIsolPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            pmIsolPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            pmIsolPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            pmIsolPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            pmIsolPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            pmIsolPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
            pmIsolPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UPPERLIMITPRICERF"));
            pmIsolPrcWork.PMFractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMFRACTIONPROCUNITRF"));
            pmIsolPrcWork.PMFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMFRACTIONPROCCDRF"));
            pmIsolPrcWork.ListPriceUpRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEUPRATERF"));

            return pmIsolPrcWork;
        }


        /// <summary>
        /// 検索結果格納処理（SeaechForBuyerのReader→RecBgnGdsWork）
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecBgnGdsWork</returns>
        /// <remarks>
        /// <br>Note       : SqlDataReaerの現在行をRecBgnGdsWorkへ格納します</br>
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015.02.23</br>
        /// </remarks>
        private RecBgnGdsWork CopyToRecBgnGdsWorkFromBuyerSearchReader(ref SqlDataReader myReader)
        {
            RecBgnGdsWork recBgnGdsWork = new RecBgnGdsWork();
            #region CREATEDATETIMERF
            DateTime ticks1, ticks2;
            ticks1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECGOOD_CREATEDATETIMERF"));
            ticks2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECCUST_CREATEDATETIMERF"));
            recBgnGdsWork.CreateDateTime = (ticks1 > ticks2) ? ticks1 : ticks2;
            #endregion

            #region UPDATEDATETIMERF
            ticks1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECGOOD_UPDATEDATETIMERF"));
            ticks2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("RECCUST_UPDATEDATETIMERF"));
            recBgnGdsWork.UpdateDateTime = (ticks1 > ticks2) ? ticks1 : ticks2;
            #endregion

            recBgnGdsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_LOGICALDELETECODERF"));
            recBgnGdsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTORIGINALEPCDRF"));
            recBgnGdsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTORIGINALSECCDRF"));
            recBgnGdsWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTOTHEREPCDRF"));
            recBgnGdsWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPSCCNT_CNECTOTHERSECCDRF"));

            recBgnGdsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECCUST_CUSTOMERCODERF"));
            recBgnGdsWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECCUST_MNGSECTIONCODERF"));
            recBgnGdsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSNORF"));
            recBgnGdsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_GOODSMAKERCDRF"));
            recBgnGdsWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSMAKERNMRF"));
            recBgnGdsWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSNAMERF"));
            recBgnGdsWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_BLGROUPCODERF"));
            recBgnGdsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECGOOD_BLGOODSCODERF"));
            recBgnGdsWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECGOOD_GOODSCOMMENTRF"));

            recBgnGdsWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_MKRSUGGESTRTPRICRF"));
            recBgnGdsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_LISTPRICERF"));
            recBgnGdsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REC_UNITPRICERF"));
            recBgnGdsWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_APPLYSTADATERF"));
            recBgnGdsWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_APPLYENDDATERF"));
            recBgnGdsWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("RECGOOD_MODELFITDIVRF"));
            recBgnGdsWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("RECGOOD_GOODSIMAGERF"));

            recBgnGdsWork.BrgnGoodsGrpCode = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("REC_BRGNGOODSGRPCODERF"));
            recBgnGdsWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REC_DISPLAYDIVCODERF"));

            #region 離島価格マスタ計算処理
            double upRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMISOLP_LISTPRICEUPRATERF"));
            double fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PMISOLP_PMFRACTIONPROCUNITRF"));
            int fractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMISOLP_PMFRACTIONPROCCDRF")); ;
            double mkrSuggestRtPric = recBgnGdsWork.MkrSuggestRtPric;

            #endregion
            // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
            // 適合車種区分が1の場合のみ離島価格を適用する
            //if (upRate > 0)
            if ((upRate > 0) && (recBgnGdsWork.ModelFitDiv == 1))
            // --- UPD 2015/03/26 Y.Wakita ----------<<<<<
            {
                mkrSuggestRtPric = mkrSuggestRtPric * upRate / 100;
                mkrSuggestRtPric = mkrSuggestRtPric / fractionProcUnit;
                switch (fractionProcCd)
                {
                    case 1://切捨て
                        mkrSuggestRtPric = Math.Floor(mkrSuggestRtPric);
                        break;
                    case 2://四捨五入
                        mkrSuggestRtPric = Math.Round(mkrSuggestRtPric, MidpointRounding.AwayFromZero);
                        break;
                    case 3://切り上げ
                        mkrSuggestRtPric = Math.Ceiling(mkrSuggestRtPric);
                        break;
                    default:
                        break;
                }
                mkrSuggestRtPric = mkrSuggestRtPric * fractionProcUnit;
                recBgnGdsWork.MkrSuggestRtPric = (long)mkrSuggestRtPric;
            }
            return recBgnGdsWork;

        }
        #endregion 

        #region クエリ文字列

        private string MakeRecBgnGdsRFSelectString()
        {
            string commandText = string.Empty;

            // Selectコマンド
            commandText = " SELECT " + Environment.NewLine
                        + "  RBG.CREATEDATETIMERF " + Environment.NewLine
                        + ", RBG.UPDATEDATETIMERF " + Environment.NewLine
                        + ", RBG.LOGICALDELETECODERF " + Environment.NewLine
                        + ", RBG.INQOTHEREPCDRF " + Environment.NewLine
                        + ", RBG.INQOTHERSECCDRF " + Environment.NewLine
                        + ", RBG.GOODSNORF " + Environment.NewLine
                        + ", RBG.GOODSMAKERCDRF " + Environment.NewLine
                        + ", RBG.GOODSMAKERNMRF " + Environment.NewLine
                        + ", RBG.GOODSNAMERF " + Environment.NewLine
                        + ", RBG.BLGROUPCODERF " + Environment.NewLine
                        + ", RBG.BLGOODSCODERF " + Environment.NewLine
                        + ", RBG.GOODSCOMMENTRF " + Environment.NewLine
                        + ", RBG.MKRSUGGESTRTPRICRF " + Environment.NewLine
                        + ", RBG.LISTPRICERF " + Environment.NewLine
                        + ", RBG.UNITCALCRATERF " + Environment.NewLine
                        + ", RBG.UNITPRICERF " + Environment.NewLine
                        + ", RBG.APPLYSTADATERF " + Environment.NewLine
                        + ", RBG.APPLYENDDATERF " + Environment.NewLine
                        + ", RBG.MODELFITDIVRF " + Environment.NewLine
                        + ", RBG.CUSTRATEGRPCODERF " + Environment.NewLine
                        + ", RBG.DISPLAYDIVCODERF " + Environment.NewLine
                        + ", RBG.BRGNGOODSGRPCODERF " + Environment.NewLine
                        + ", RBG.GOODSIMAGERF " + Environment.NewLine
                        + "  FROM RECBGNGDSRF RBG WITH (READUNCOMMITTED) " + Environment.NewLine;

            return commandText;
        }

        private string MakeRecBgnGdsRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE " + Environment.NewLine
                        + " RBG.INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                        + " AND RBG.INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                        + " AND RBG.GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                        + " AND RBG.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                        + " AND RBG.APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

            return commandText;
        }

        private string MakeRecBgnCustRFSelectString()
        {
            string commandText = string.Empty;

            // Selectコマンド
            commandText = " SELECT " + Environment.NewLine
                        + "  RBC.CREATEDATETIMERF " + Environment.NewLine
                        + ", RBC.UPDATEDATETIMERF " + Environment.NewLine
                        + ", RBC.LOGICALDELETECODERF " + Environment.NewLine
                        + ", RBC.INQORIGINALEPCDRF " + Environment.NewLine
                        + ", RBC.INQORIGINALSECCDRF " + Environment.NewLine
                        + ", RBC.INQOTHEREPCDRF " + Environment.NewLine
                        + ", RBC.INQOTHERSECCDRF " + Environment.NewLine
                        + ", RBC.GOODSNORF " + Environment.NewLine
                        + ", RBC.GOODSMAKERCDRF " + Environment.NewLine
                        + ", RBC.GOODSAPPLYSTADATERF " + Environment.NewLine
                        + ", RBC.CUSTOMERCODERF " + Environment.NewLine
                        + ", RBC.MNGSECTIONCODERF " + Environment.NewLine
                        + ", RBC.MKRSUGGESTRTPRICRF " + Environment.NewLine
                        + ", RBC.LISTPRICERF " + Environment.NewLine
                        + ", RBC.UNITCALCRATERF " + Environment.NewLine
                        + ", RBC.UNITPRICERF " + Environment.NewLine
                        + ", RBC.APPLYSTADATERF " + Environment.NewLine
                        + ", RBC.APPLYENDDATERF " + Environment.NewLine
                        + ", RBC.BRGNGOODSGRPCODERF " + Environment.NewLine
                        + ", RBC.DISPLAYDIVCODERF " + Environment.NewLine
                        + "  FROM RECBGNCUSTRF RBC WITH (READUNCOMMITTED) " + Environment.NewLine;


            return commandText;
        }

        private string MakeRecBgnCustRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE" + Environment.NewLine
                        + " RBC.INQORIGINALEPCDRF=@FINDINQORIGINALEPCD " + Environment.NewLine
                        + " AND RBC.INQORIGINALSECCDRF=@FINDINQORIGINALSECCD " + Environment.NewLine
                        + " AND RBC.INQOTHEREPCDRF=@FINDINQOTHEREPCD " + Environment.NewLine
                        + " AND RBC.INQOTHERSECCDRF=@FINDINQOTHERSECCD " + Environment.NewLine
                        + " AND RBC.GOODSNORF=@FINDGOODSNO " + Environment.NewLine
                        + " AND RBC.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine
                        + " AND RBC.APPLYSTADATERF=@FINDAPPLYSTADATE " + Environment.NewLine;

            return commandText;
        }

        private string MakePmIsolPrcRFSelectString()
        {
            string commandText = string.Empty;

            // Selectコマンド
            commandText = "SELECT" + Environment.NewLine
                        + "  PIP.CREATEDATETIMERF " + Environment.NewLine
                        + " , PIP.UPDATEDATETIMERF " + Environment.NewLine
                        + " , PIP.LOGICALDELETECODERF " + Environment.NewLine
                        + " , PIP.ENTERPRISECODERF " + Environment.NewLine
                        + " , PIP.SECTIONCODERF " + Environment.NewLine
                        + " , PIP.MAKERCODERF " + Environment.NewLine
                        + " , PIP.UPPERLIMITPRICERF " + Environment.NewLine
                        + " , PIP.PMFRACTIONPROCUNITRF " + Environment.NewLine
                        + " , PIP.PMFRACTIONPROCCDRF " + Environment.NewLine
                        + " , PIP.LISTPRICEUPRATERF " + Environment.NewLine
                        + "  FROM PMISOLPRCRF PIP WITH (READUNCOMMITTED) " + Environment.NewLine;

            return commandText;
        }

        private string MakePmIsolPrcRFWhereKeyString()
        {
            string commandText = string.Empty;

            commandText = " WHERE " + Environment.NewLine
                        + " PIP.ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine
                        + " AND PIP.SECTIONCODERF=@SECTIONCODE " + Environment.NewLine
                        + " AND PIP.MAKERCODERF=@MAKERCODE " + Environment.NewLine
                        + " AND PIP.UPPERLIMITPRICERF=@UPPERLIMITPRICE " + Environment.NewLine;

            return commandText;
        }

        #endregion

        //--- ADD  2015/02/23 佐々木 -----<<<<<

        //--- DEL  2015/02/23 佐々木 ----->>>>>
        #region レイアウト変更前コメント

        //#region IRecBgnGdsDB メンバ
        //
        //#region Write
        //
        ///// <summary>
        ///// 登録・更新処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork登録データ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Write(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    try
        //    {
        //        // コネクション生成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション開始
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 登録・更新処理
        //        status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Write");
        //        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // コミット
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ロールバック
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Read
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 検索処理
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        ///// <param name="paraobj">RecBgnGdsWork検索データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを検索します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Read(ref object retobj, object paraobj, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // コネクション作成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // 検索処理
        //        status = ReadProc(out retobj, paraobj, sqlConnection, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Read");
        //        retobj = new ArrayList();
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Search
        //
        ///// <summary>
        ///// 検索処理
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        ///// <param name="paraobj">検索パラメータ</param>
        ///// <param name="logicalMode">論理削除</param>
        ///// <param name="count">件数</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Search(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    retobj = null;
        //    count = 0;
        //
        //    try
        //    {
        //        // コネクション作成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // 検索処理
        //        status = SearchProc(out retobj, paraobj, logicalMode, ref sqlConnection, out count, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
        //        retobj = new ArrayList();
        //        count = 0;
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        ///// <summary>
        ///// 検索処理（論理削除除く）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        ///// <param name="inqOtherEpCd">問合せ先企業コード</param>
        ///// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int Search(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    retobj = null;
        //
        //    try
        //    {
        //        // コネクション作成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // 検索処理
        //        status = SearchProc(out retobj, inqOtherEpCd, logicalMode, ref sqlConnection, ref errMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Search");
        //        retobj = null;
        //        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region Delete
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork削除データ</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを物理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int Delete(object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // コネクション作成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション作成
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 削除処理
        //        status = DeleteProc(paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // コミット
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ロールバック
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region DeleteAndWrite
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除・論理削除・登録・更新処理（リスト処理）
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork削除データリスト</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork登録・更新データリスト</param>
        ///// <param name="errorObj">RecBgnGdsWorkエラーリスト</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : お買い得商品設定マスタを完全削除、論理削除、登録・更新します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, out object errorObj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    errorObj = null;
        //
        //    try
        //    {
        //        // コネクション作成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション開始
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 変換
        //        ArrayList delList = paraDelObj as ArrayList;
        //        ArrayList updList = paraUpdObj as ArrayList;
        //
        //        // 完全削除
        //        foreach (RecBgnGdsWork recBgnGdsWork in delList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                errorObj = null;
        //                return status;
        //            }
        //        }
        //
        //        // 登録・更新・論理削除
        //        foreach (RecBgnGdsWork recBgnGdsWork in updList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            if (recBgnGdsWork.LogicalDeleteCode == 0)
        //            {
        //                status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
        //                if (status != 0)
        //                {
        //                    errorObj = paraObj;
        //                    return status;
        //                }
        //                status = this.WriteProc(ref paraObj, ref sqlConnection, ref sqlTransaction);
        //            }
        //            else
        //            {
        //                status = this.LogicalDeleteProc(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
        //            }
        //
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                errorObj = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsWorkDB.DeleteAndWrite");
        //        errorObj = null;
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // コミット
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ロールバック
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region DeleteAndRevival
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除・復活処理（リスト処理）
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork削除データリスト</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork復活データリスト</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : お買い得商品設定マスタを完全削除、復活します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // コネクション生成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション開始
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 変換
        //        ArrayList delList = paraDelObj as ArrayList;
        //        ArrayList updList = paraUpdObj as ArrayList;
        //
        //        // 完全削除
        //        foreach (RecBgnGdsWork recBgnGdsWork in delList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.DeleteProc(paraObj, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
        //        }
        //
        //        // 復活
        //        foreach (RecBgnGdsWork recBgnGdsWork in updList)
        //        {
        //            object paraObj = recBgnGdsWork as object;
        //            status = this.LogicalDeleteProc(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.DeleteAndWrite");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // コミット
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ロールバック
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#region LogicalDelete
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 論理削除処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork論理削除データ</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを論理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int LogicalDelete(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // コネクション生成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション開始
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 論理削除
        //        status = LogicalDeleteProc(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    // コミット
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    // ロールバック
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //            sqlTransaction.Dispose();
        //        }
        //
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region RevivalLogicalDelete
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 復活処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork復活データ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタの論理削除データを復活します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //public int RevivalLogicalDelete(ref object paraobj)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //
        //    try
        //    {
        //        // コネクション生成
        //        sqlConnection = CreateSqlConnection();
        //        if (sqlConnection == null) return status;
        //        sqlConnection.Open();
        //
        //        // トランザクション開始
        //        sqlTransaction = this.CreateSqlTransaction(sqlConnection);
        //
        //        // 復活処理
        //        status = RevivalLogicalDeleteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.RevivalLogicalDelete");
        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        //
        //#endregion
        //
        //#endregion
        //
        //#region 登録・更新処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 登録・更新処理（実処理）
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork登録データ</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int WriteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        // コマンド作成
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Selectコマンド
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameterオブジェクトの作成(検索用)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameterオブジェクトへ値設定(検索用)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            //タイムアウト時間の設定
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //
        //            if (myReader.Read())
        //            {
        //                // 更新日時が異なる場合は排他エラーで戻す
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    // 新規登録で該当データ有りの場合には重複
        //                    if (recBgnGdsWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
        //                    // 既存データで更新日時違いの場合には排他
        //                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    // Close
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                //Updateコマンドの生成
        //                commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine;
        //                commandText += "SET" + Environment.NewLine;
        //                commandText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
        //                commandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //                commandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += " , INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
        //                commandText += " , INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
        //                commandText += " , INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
        //                commandText += " , INQOTHERSECCDRF=@INQOTHERSECCD" + Environment.NewLine;
        //                commandText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
        //                commandText += " , MNGSECTIONCODERF=@MNGSECTIONCODE" + Environment.NewLine;
        //                commandText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
        //                commandText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
        //                commandText += " , GOODSMAKERNMRF=@GOODSMAKERNM" + Environment.NewLine;
        //                commandText += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
        //                commandText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
        //                commandText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
        //                commandText += " , GOODSCOMMENTRF=@GOODSCOMMENT" + Environment.NewLine;
        //                commandText += " , MKRSUGGESTRTPRICRF=@MKRSUGGESTRTPRIC" + Environment.NewLine;
        //                commandText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
        //                commandText += " , UNITPRICERF=@UNITPRICE" + Environment.NewLine;
        //                commandText += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
        //                commandText += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
        //                commandText += " , MODELFITDIVRF=@MODELFITDIV" + Environment.NewLine;
        //                commandText += " , GOODSIMAGERF=@GOODSIMAGE" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //
        //                //登録ヘッダ情報を設定
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //            }
        //            else
        //            {
        //                //　更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
        //                if (recBgnGdsWork.UpdateDateTime > DateTime.MinValue)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                    sqlCommand.Cancel();
        //                    if (!myReader.IsClosed) myReader.Close();
        //                    return status;
        //                }
        //
        //                //Insertコマンドの生成
        //                commandText = "INSERT INTO RECBGNGDSRF (" + Environment.NewLine;
        //                commandText += "  CREATEDATETIMERF" + Environment.NewLine;
        //                commandText += ", UPDATEDATETIMERF" + Environment.NewLine;
        //                commandText += ", LOGICALDELETECODERF" + Environment.NewLine;
        //                commandText += ", INQORIGINALEPCDRF" + Environment.NewLine;
        //                commandText += ", INQORIGINALSECCDRF" + Environment.NewLine;
        //                commandText += ", INQOTHEREPCDRF" + Environment.NewLine;
        //                commandText += ", INQOTHERSECCDRF" + Environment.NewLine;
        //                commandText += ", CUSTOMERCODERF" + Environment.NewLine;
        //                commandText += ", MNGSECTIONCODERF" + Environment.NewLine;
        //                commandText += ", GOODSNORF" + Environment.NewLine;
        //                commandText += ", GOODSMAKERCDRF" + Environment.NewLine;
        //                commandText += ", GOODSMAKERNMRF" + Environment.NewLine;
        //                commandText += ", GOODSNAMERF" + Environment.NewLine;
        //                commandText += ", BLGROUPCODERF" + Environment.NewLine;
        //                commandText += ", BLGOODSCODERF" + Environment.NewLine;
        //                commandText += ", GOODSCOMMENTRF" + Environment.NewLine;
        //                commandText += ", MKRSUGGESTRTPRICRF" + Environment.NewLine;
        //                commandText += ", LISTPRICERF" + Environment.NewLine;
        //                commandText += ", UNITPRICERF" + Environment.NewLine;
        //                commandText += ", APPLYSTADATERF" + Environment.NewLine;
        //                commandText += ", APPLYENDDATERF" + Environment.NewLine;
        //                commandText += ", MODELFITDIVRF" + Environment.NewLine;
        //                commandText += ", GOODSIMAGERF" + Environment.NewLine;
        //                commandText += ") VALUES (" + Environment.NewLine;
        //                commandText += "  @CREATEDATETIME" + Environment.NewLine;
        //                commandText += ", @UPDATEDATETIME" + Environment.NewLine;
        //                commandText += ", @LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += ", @INQORIGINALEPCD" + Environment.NewLine;
        //                commandText += ", @INQORIGINALSECCD" + Environment.NewLine;
        //                commandText += ", @INQOTHEREPCD" + Environment.NewLine;
        //                commandText += ", @INQOTHERSECCD" + Environment.NewLine;
        //                commandText += ", @CUSTOMERCODE" + Environment.NewLine;
        //                commandText += ", @MNGSECTIONCODE" + Environment.NewLine;
        //                commandText += ", @GOODSNO" + Environment.NewLine;
        //                commandText += ", @GOODSMAKERCD" + Environment.NewLine;
        //                commandText += ", @GOODSMAKERNM" + Environment.NewLine;
        //                commandText += ", @GOODSNAME" + Environment.NewLine;
        //                commandText += ", @BLGROUPCODE" + Environment.NewLine;
        //                commandText += ", @BLGOODSCODE" + Environment.NewLine;
        //                commandText += ", @GOODSCOMMENT" + Environment.NewLine;
        //                commandText += ", @MKRSUGGESTRTPRIC" + Environment.NewLine;
        //                commandText += ", @LISTPRICE" + Environment.NewLine;
        //                commandText += ", @UNITPRICE" + Environment.NewLine;
        //                commandText += ", @APPLYSTADATE" + Environment.NewLine;
        //                commandText += ", @APPLYENDDATE" + Environment.NewLine;
        //                commandText += ", @MODELFITDIV" + Environment.NewLine;
        //                commandText += ", @GOODSIMAGE" + Environment.NewLine;
        //                commandText += ")" + Environment.NewLine;
        //
        //                //登録ヘッダ情報を設定
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //                recBgnGdsWork.CreateDateTime = DateTime.Now;
        //            }
        //
        //            // SqlReader Close
        //            if (!myReader.IsClosed) myReader.Close();
        //
        //            //Prameterオブジェクトの作成
        //            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //            SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
        //            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter paraGoodsMakerNm = sqlCommand.Parameters.Add("@GOODSMAKERNM", SqlDbType.NVarChar);
        //            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
        //            SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
        //            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
        //            SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);
        //            SqlParameter paraMkrSuggestRtPric = sqlCommand.Parameters.Add("@MKRSUGGESTRTPRIC", SqlDbType.BigInt);
        //            SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.BigInt);
        //            SqlParameter paraUnitPrice = sqlCommand.Parameters.Add("@UNITPRICE", SqlDbType.BigInt);
        //            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //            SqlParameter paraModelFitDiv = sqlCommand.Parameters.Add("@MODELFITDIV", SqlDbType.SmallInt);
        //            SqlParameter paraGoodsImage = sqlCommand.Parameters.Add("@GOODSIMAGE", SqlDbType.VarBinary);
        //
        //            //Parameterオブジェクトへ値設定
        //            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.CreateDateTime);
        //            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.UpdateDateTime);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.LogicalDeleteCode);
        //            paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            paraMngSectionCode.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.MngSectionCode);
        //            paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            paraGoodsMakerNm.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsMakerNm);
        //            paraGoodsName.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsName);
        //            paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGroupCode);
        //            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGoodsCode);
        //            paraGoodsComment.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsComment);
        //            paraMkrSuggestRtPric.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.MkrSuggestRtPric);
        //            paraListPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.ListPrice);
        //            paraUnitPrice.Value = SqlDataMediator.SqlSetInt64(recBgnGdsWork.UnitPrice);
        //            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyEndDate);
        //            paraModelFitDiv.Value = SqlDataMediator.SqlSetInt16(recBgnGdsWork.ModelFitDiv);
        //            paraGoodsImage.Value = SqlDataMediator.SqlSetBinary(recBgnGdsWork.GoodsImage);
        //
        //            // 登録・更新実行
        //            sqlCommand.CommandText = commandText;
        //            sqlCommand.ExecuteNonQuery();
        //
        //            paraobj = recBgnGdsWork as object;
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region 検索処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 検索処理（実処理）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="count">件数</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int SearchProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out int count, ref string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    ArrayList al = new ArrayList();
        //    count = 0;
        //    retobj = null;
        //
        //    try
        //    {
        //        RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = paraobj as RecBgnGdsSearchParaWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //            // Selectコマンド
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region Where句
        //            sqlTxt.Append(" WHERE").Append(Environment.NewLine);
        //
        //            //論理削除区分
        //            sqlTxt.Append("      LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
        //            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //
        //            // 問合せ元企業コード
        //            if (recBgnGdsSearchParaWork.InqOriginalEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALEPCDRF=@INQORIGINALEPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCDRF", SqlDbType.NChar);
        //                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalEpCd);
        //            }
        //
        //            // 問合せ元拠点コード
        //            if (recBgnGdsSearchParaWork.InqOriginalSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCDRF", SqlDbType.NChar);
        //                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOriginalSecCd);
        //            }
        //
        //            // 問合せ先企業コード
        //            if (recBgnGdsSearchParaWork.InqOtherEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherEpCd);
        //            }
        //
        //            // 問合せ先拠点コード
        //            int inqOtherSecCd = 0;
        //            int.TryParse(recBgnGdsSearchParaWork.InqOtherSecCd, out inqOtherSecCd);
        //            if (inqOtherSecCd != 0)
        //            {
        //                sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.InqOtherSecCd);
        //            }
        //
        //            // 得意先コード
        //            if (recBgnGdsSearchParaWork.CustomerCode != 0)
        //            {
        //                sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
        //                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.CustomerCode);
        //            }
        //
        //            //メーカーコード（開始）
        //            if (recBgnGdsSearchParaWork.GoodsMakerCdSt != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF>=@GOODSMAKERCDST").Append(Environment.NewLine);
        //                SqlParameter paraStGoodsMakerCdST = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
        //                paraStGoodsMakerCdST.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdSt);
        //            }
        //            //メーカーコード（終了）
        //            if (recBgnGdsSearchParaWork.GoodsMakerCdEd != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF<=@GOODSMAKERCDED").Append(Environment.NewLine);
        //                SqlParameter paraEdGoodsMakerCdED = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
        //                paraEdGoodsMakerCdED.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.GoodsMakerCdEd);
        //            }
        //
        //            // 公開開始日（開始）
        //            if (recBgnGdsSearchParaWork.ApplyDateSt != 0)
        //            {
        //                sqlTxt.Append("  AND APPLYSTADATERF>=@APPLYSTADATE").Append(Environment.NewLine);
        //                SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //                findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateSt);
        //            }
        //
        //            // 公開開始日（終了）
        //            if (recBgnGdsSearchParaWork.ApplyDateEd != 0)
        //            {
        //                sqlTxt.Append("  AND APPLYENDDATERF<=@APPLYENDDATE").Append(Environment.NewLine);
        //                SqlParameter findParaApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //                findParaApplyEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsSearchParaWork.ApplyDateEd);
        //            }
        //
        //            //品番*
        //            if (recBgnGdsSearchParaWork.GoodsNo.Trim() != string.Empty)
        //            {
        //                if (recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1, 1) == "*")
        //                {
        //                    sqlTxt.Append("  AND REPLACE(GOODSNORF,'-','') LIKE REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
        //                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
        //                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim().Substring(0, recBgnGdsSearchParaWork.GoodsNo.Trim().Length - 1) + "%");
        //                }
        //                else
        //                {
        //                    sqlTxt.Append("  AND REPLACE(GOODSNORF,'-','') = REPLACE(@GOODSNO,'-','')").Append(Environment.NewLine);
        //                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
        //                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsSearchParaWork.GoodsNo.Trim());
        //                }
        //            }
        //
        //
        //            #endregion
        //
        //            // OrderBy句追記
        //            #region ORDER BY句
        //            sqlTxt.Append("    ORDER BY ").Append(Environment.NewLine);
        //            sqlTxt.Append("       INQORIGINALEPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,APPLYSTADATERF").Append(Environment.NewLine);
        //            #endregion
        //
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //
        //            //タイムアウト時間の設定
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                if (al.Count == 20000)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                    retobj = al;
        //                    count = 20001;
        //                    return status;
        //                }
        //                RecBgnGdsWork recBgnGdsWork = CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(recBgnGdsWork);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (!myReader.IsClosed) myReader.Close();
        //            myReader.Dispose();
        //
        //        } // end using
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
        //        errMsg = ex.ToString();
        //    }
        //    retobj = al;
        //
        //    return status;
        //}
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 検索処理（実処理）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        ///// <param name="inqOtherEpCd">問合せ先企業コード</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : 指定問合せ先企業コードの該当データを検索します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int SearchProc(out object retobj, string inqOtherEpCd, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref string errMsg)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    retobj = null;
        //    ArrayList al = new ArrayList();
        //
        //    try
        //    {
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //            // Selectコマンド
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE句
        //            sqlTxt.Append("   WHERE ").Append(Environment.NewLine);
        //
        //            // 問合せ先企業コード
        //            sqlTxt.Append("       INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(inqOtherEpCd);
        //
        //            //論理削除区分
        //            string wkstring = string.Empty;
        //            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData3))
        //            {
        //                sqlTxt.Append("   AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //            }
        //            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
        //                (logicalMode == ConstantManagement.LogicalMode.GetData012))
        //            {
        //                sqlTxt.Append("   AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ").Append(Environment.NewLine);
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
        //            }
        //
        //            #endregion
        //
        //            // OrderBy句追記
        //            #region ORDER BY句
        //            sqlTxt.Append("    ORDER BY ").Append(Environment.NewLine);
        //            sqlTxt.Append("       INQORIGINALEPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQORIGINALSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
        //            sqlTxt.Append("      ,APPLYSTADATERF").Append(Environment.NewLine);
        //            #endregion
        //
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //
        //            //タイムアウト時間の設定
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                RecBgnGdsWork work = CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(work);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            if (!myReader.IsClosed) myReader.Close();
        //            myReader.Dispose();
        //
        //        } // end using
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Search", status);
        //        errMsg = ex.ToString();
        //    }
        //
        //    retobj = al;
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region 読込処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 読込処理（実処理）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        ///// <param name="paraobj">RecBgnGdsWork検索パラメータ</param>
        ///// <param name="sqlConnection">SqlConnenction</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int ReadProc(out object retobj, object paraobj, SqlConnection sqlConnection, ref string errMsg)
        //{
        //
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    retobj = null;
        //    ArrayList al = new ArrayList();
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //
        //            // Selectコマンド
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE句
        //            sqlTxt.Append("  WHERE ").Append(Environment.NewLine);
        //
        //            // 問合せ元企業コード
        //            if (recBgnGdsWork.InqOriginalEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("      INQORIGINALEPCDRF=@INQORIGINALEPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCDRF", SqlDbType.NChar);
        //                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            }
        //
        //            // 問合せ元拠点コード
        //            if (recBgnGdsWork.InqOriginalSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCDRF", SqlDbType.NChar);
        //                findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            }
        //
        //            // 問合せ先企業コード
        //            if (recBgnGdsWork.InqOtherEpCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCDRF", SqlDbType.NChar);
        //                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            }
        //
        //            // 問合せ先拠点コード
        //            if (recBgnGdsWork.InqOtherSecCd.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCDRF", SqlDbType.NChar);
        //                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            }
        //
        //            //// 得意先コード
        //            //if (recBgnGdsWork.CustomerCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODERF", SqlDbType.Int);
        //            //    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //            //}
        //
        //            // 商品メーカーコード
        //            if (recBgnGdsWork.GoodsMakerCd != 0)
        //            {
        //                sqlTxt.Append("  AND GOODSMAKERCDRF=@GOODSMAKERCDRF").Append(Environment.NewLine);
        //                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCDRF", SqlDbType.Int);
        //                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            }
        //
        //            // 商品番号
        //            if (recBgnGdsWork.GoodsNo.Trim() != string.Empty)
        //            {
        //                sqlTxt.Append("  AND GOODSNORF=@GOODSNORF").Append(Environment.NewLine);
        //                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NVarChar);
        //                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            }
        //
        //            //// BLグループコード
        //            //if (recBgnGdsWork.BLGroupCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND BLGROUPCODERF=@BLGROUPCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODERF", SqlDbType.Int);
        //            //    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGroupCode);
        //            //}
        //
        //            //// BL商品コード
        //            //if (recBgnGdsWork.BLGoodsCode != 0)
        //            //{
        //            //    sqlTxt.Append("  AND BLGOODSCODERF=@BLGOODSCODERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODERF", SqlDbType.Int);
        //            //    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.BLGoodsCode);
        //            //}
        //
        //            //// 公開開始日
        //            //if (recBgnGdsWork.OpenStartDate != 0)
        //            //{
        //            //    sqlTxt.Append("  AND OPENSTARTDATERF=@OPENSTARTDATERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaOpenStartDate = sqlCommand.Parameters.Add("@OPENSTARTDATERF", SqlDbType.Int);
        //            //    findParaOpenStartDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.OpenStartDate);
        //            //}
        //
        //            //// 公開終了日
        //            //if (recBgnGdsWork.OpenEndDate != 0)
        //            //{
        //            //    sqlTxt.Append("  AND OPENENDDATERF=@OPENENDDATERF").Append(Environment.NewLine);
        //            //    SqlParameter findParaOpenEndDate = sqlCommand.Parameters.Add("@OPENENDDATERF", SqlDbType.Int);
        //            //    findParaOpenEndDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.OpenEndDate);
        //            //}
        //
        //            #endregion
        //
        //            // コマンド設定
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //
        //            // Reader → Work
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                RecBgnGdsWork work = this.CopyToRecBgnGdsWorkFromReader(ref myReader);
        //                al.Add(work);
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //            myReader.Close();
        //            myReader.Dispose();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        status = base.WriteSQLErrorLog(ex, "RecBgnItmstDB.Read", status);
        //        errMsg = ex.ToString();
        //    }
        //    finally
        //    {
        //        // 検索結果リストを格納
        //        retobj = al;
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region 完全削除処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除処理（実処理）
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを物理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int DeleteProc(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Selectコマンド
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameterオブジェクトの作成(検索用)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameterオブジェクトへ値設定(検索用)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            if (myReader.Read())
        //            {
        //                // 更新日時が異なる場合は排他エラーで戻す
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                // SqlReader Close
        //                if (!myReader.IsClosed) myReader.Close();
        //
        //                // Deleteコマンドの生成
        //                commandText = "DELETE FROM RECBGNGDSRF" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //                sqlCommand.CommandText = commandText;
        //
        //                // Delete実行
        //                sqlCommand.ExecuteNonQuery();
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            }
        //            else
        //            {
        //                // 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                sqlCommand.Cancel();
        //                if (!myReader.IsClosed) myReader.Close();
        //            }
        //
        //        } // end using
        //
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.Delete");
        //    }
        //
        //    return status;
        //}
        //
        //#endregion
        //
        //#region 論理削除処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 論理削除処理（実処理）
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <param name="procMode">処理モード 0:論理削除 1:復活</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを論理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int LogicalDeleteProc(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    int logicalDelCd = 0;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        string commandText = string.Empty;
        //
        //        // コマンド作成
        //        using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection, sqlTransaction))
        //        {
        //            // Selectコマンド
        //            commandText += MakeSelectString();
        //            commandText += MakeWhereKeyString();
        //
        //            sqlCommand.CommandText = commandText;
        //
        //            //Parameterオブジェクトの作成(検索用)
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
        //            SqlParameter findParaApplyStaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
        //
        //            //Parameterオブジェクトへ値設定(検索用)
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //            findParaApplyStaDate.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.ApplyStaDate);
        //
        //            // Read
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            if (myReader.Read())
        //            {
        //                // 更新日時が異なる場合は排他エラーで戻す
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                if (updateDateTime != recBgnGdsWork.UpdateDateTime)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    sqlCommand.Cancel();
        //                    myReader.Close();
        //                    return status;
        //                }
        //
        //                // 現在の論理削除区分を取得
        //                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //
        //                // 論理削除区分変更
        //                if (procMode == 0)
        //                {
        //                    //論理削除モードの場合
        //                    if (logicalDelCd == 0) recBgnGdsWork.LogicalDeleteCode = 1; //論理削除フラグをセット
        //                    else recBgnGdsWork.LogicalDeleteCode = 3; //完全削除フラグをセット
        //                }
        //                else
        //                {
        //                    //復活モードの場合
        //                    if (logicalDelCd == 1) recBgnGdsWork.LogicalDeleteCode = 0; //論理削除フラグを解除
        //                    else
        //                    {
        //                        if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // 既に復活している場合はそのまま正常を戻す
        //                        else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 完全削除はデータなしを戻す
        //
        //                        sqlCommand.Cancel();
        //                        if (!myReader.IsClosed) myReader.Close();
        //                        return status;
        //                    }
        //                }
        //
        //                // SqlReader Close
        //                if (!myReader.IsClosed) myReader.Close();
        //
        //                // Updateコマンドの生成
        //                commandText = "UPDATE RECBGNGDSRF" + Environment.NewLine;
        //                commandText += "SET" + Environment.NewLine;
        //                commandText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
        //                commandText += ", LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
        //                commandText += MakeWhereKeyString();
        //                sqlCommand.CommandText = commandText;
        //
        //                //登録ヘッダ情報を設定
        //                recBgnGdsWork.UpdateDateTime = DateTime.Now;
        //
        //                // Parameterオブジェクトの作成(更新用)
        //                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);       // 更新日時
        //                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);    // 論理削除区分
        //
        //                // Parameterオブジェクトへ値設定(更新用)
        //                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(recBgnGdsWork.UpdateDateTime);
        //                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.LogicalDeleteCode);
        //
        //                //タイムアウト時間の設定
        //                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
        //
        //                // Update実行
        //                sqlCommand.ExecuteNonQuery();
        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            }
        //            else
        //            {
        //                // 更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                if (!myReader.IsClosed) myReader.Close();
        //                return status;
        //            }
        //
        //        } // end using
        //
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        status = base.WriteSQLErrorLog(ex);
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.LogicalDelete");
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region 復活処理
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 復活処理（実処理）
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタの論理削除データを復活します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int RevivalLogicalDeleteProc(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //
        //    // 論理削除処理を実施
        //    return LogicalDeleteProc(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
        //
        //}
        //
        ///// <summary>
        ///// 登録、更新前、重複レコードの存在チェックを行う
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <param name="sqlConnection">sqlConnection</param>
        ///// <param name="sqlTransaction">sqlTransaction</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 登録、更新前、重複レコードの存在チェックを行う</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
        //    try
        //    {
        //        RecBgnGdsWork recBgnGdsWork = paraobj as RecBgnGdsWork;
        //        StringBuilder sqlTxt = new StringBuilder(string.Empty);
        //
        //        using (SqlCommand sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection))
        //        {
        //
        //            // Selectコマンド
        //            sqlTxt.Append(MakeSelectString());
        //
        //            #region WHERE句
        //            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
        //
        //            // 問合せ元企業コード
        //            sqlTxt.Append("      INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
        //            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalEpCd);
        //
        //            // 問合せ元拠点コード
        //            sqlTxt.Append("  AND INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
        //            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOriginalSecCd);
        //
        //            // 問合せ先企業コード
        //            sqlTxt.Append("  AND INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
        //            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherEpCd);
        //
        //            // 問合せ先拠点コード
        //            sqlTxt.Append("  AND INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
        //            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
        //            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.InqOtherSecCd);
        //
        //            // 得意先コード
        //            sqlTxt.Append("  AND CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
        //            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
        //            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.CustomerCode);
        //
        //            // 商品番号
        //            sqlTxt.Append("  AND GOODSNORF=@GOODSNO").Append(Environment.NewLine);
        //            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
        //            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(recBgnGdsWork.GoodsNo);
        //
        //            // 商品メーカーコード
        //            sqlTxt.Append("  AND GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
        //            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
        //            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(recBgnGdsWork.GoodsMakerCd);
        //
        //            // 適用日
        //            sqlTxt.Append(" AND ((APPLYSTADATERF<=@APPLYSTADATE AND @APPLYENDDATE<=APPLYENDDATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYENDDATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYSTADATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYSTADATERF)").Append(Environment.NewLine);
        //            sqlTxt.Append("  OR  (APPLYENDDATERF>=@APPLYSTADATE AND @APPLYENDDATE>=APPLYENDDATERF))").Append(Environment.NewLine);
        //
        //            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
        //            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsWork.ApplyStaDate);
        //            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
        //            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt(recBgnGdsWork.ApplyEndDate);
        //
        //            #endregion
        //
        //            // コマンド設定
        //            sqlCommand.CommandText = sqlTxt.ToString();
        //            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
        //            if (sqlTransaction != null)
        //            {
        //                sqlCommand.Transaction = sqlTransaction;
        //            }
        //
        //            SqlDataReader myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //                paraobj = recBgnGdsWork as object;
        //                myReader.Close();
        //                return status;
        //            }
        //
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //
        //            if (myReader.IsClosed == false)
        //            {
        //                myReader.Close();
        //                myReader.Dispose();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "RecBgnGdsDB.ReadDBBeforeSave", status);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //
        //    return status;
        //
        //}
        //
        //#endregion
        //
        //#region クラス格納処理
        //
        ///// <summary>
        ///// 検索結果格納処理（Reader→RecBgnGdsWork）
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>RecBgnGdsWork</returns>
        ///// <remarks>
        ///// <br>Note       : SqlDataReaerの現在行をRecBgnGdsWorkへ格納します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //private RecBgnGdsWork CopyToRecBgnGdsWorkFromReader(ref SqlDataReader myReader)
        //{
        //    RecBgnGdsWork recBgnGdsWork = new RecBgnGdsWork();
        //
        //    recBgnGdsWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //    recBgnGdsWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //    recBgnGdsWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //    recBgnGdsWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
        //    recBgnGdsWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
        //    recBgnGdsWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
        //    recBgnGdsWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
        //
        //    recBgnGdsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    recBgnGdsWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
        //    recBgnGdsWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
        //    recBgnGdsWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
        //    recBgnGdsWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMAKERNMRF"));
        //    recBgnGdsWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
        //    recBgnGdsWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
        //    recBgnGdsWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
        //    recBgnGdsWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
        //    recBgnGdsWork.MkrSuggestRtPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MKRSUGGESTRTPRICRF"));
        //    recBgnGdsWork.ListPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LISTPRICERF"));
        //    recBgnGdsWork.UnitPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UNITPRICERF"));
        //    recBgnGdsWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
        //    recBgnGdsWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
        //    recBgnGdsWork.ModelFitDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("MODELFITDIVRF"));
        //    recBgnGdsWork.GoodsImage = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("GOODSIMAGERF"));
        //
        //    return recBgnGdsWork;
        //}
        //
        //#endregion
        //
        //private string MakeSelectString()
        //{
        //    string commandText = string.Empty;
        //
        //    // Selectコマンド
        //    commandText = "SELECT" + Environment.NewLine;
        //    commandText += "  CREATEDATETIMERF" + Environment.NewLine;
        //    commandText += ", UPDATEDATETIMERF" + Environment.NewLine;
        //    commandText += ", LOGICALDELETECODERF" + Environment.NewLine;
        //    commandText += ", INQORIGINALEPCDRF" + Environment.NewLine;
        //    commandText += ", INQORIGINALSECCDRF" + Environment.NewLine;
        //    commandText += ", INQOTHEREPCDRF" + Environment.NewLine;
        //    commandText += ", INQOTHERSECCDRF" + Environment.NewLine;
        //    commandText += ", CUSTOMERCODERF" + Environment.NewLine;
        //    commandText += ", MNGSECTIONCODERF" + Environment.NewLine;
        //    commandText += ", GOODSNORF" + Environment.NewLine;
        //    commandText += ", GOODSMAKERCDRF" + Environment.NewLine;
        //    commandText += ", GOODSMAKERNMRF" + Environment.NewLine;
        //    commandText += ", GOODSNAMERF" + Environment.NewLine;
        //    commandText += ", BLGROUPCODERF" + Environment.NewLine;
        //    commandText += ", BLGOODSCODERF" + Environment.NewLine;
        //    commandText += ", GOODSCOMMENTRF" + Environment.NewLine;
        //    commandText += ", MKRSUGGESTRTPRICRF" + Environment.NewLine;
        //    commandText += ", LISTPRICERF" + Environment.NewLine;
        //    commandText += ", UNITPRICERF" + Environment.NewLine;
        //    commandText += ", APPLYSTADATERF" + Environment.NewLine;
        //    commandText += ", APPLYENDDATERF" + Environment.NewLine;
        //    commandText += ", MODELFITDIVRF" + Environment.NewLine;
        //    commandText += ", GOODSIMAGERF" + Environment.NewLine;
        //    commandText += "  FROM RECBGNGDSRF" + Environment.NewLine;
        //
        //    return commandText;
        //}
        //
        //private string MakeWhereKeyString()
        //{
        //    string commandText = string.Empty;
        //
        //    commandText += " WHERE" + Environment.NewLine;
        //    commandText += "       INQORIGINALEPCDRF=@FINDINQORIGINALEPCD" + Environment.NewLine;
        //    commandText += "   AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
        //    commandText += "   AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
        //    commandText += "   AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
        //    commandText += "   AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
        //    commandText += "   AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
        //    commandText += "   AND APPLYSTADATERF=@FINDAPPLYSTADATE" + Environment.NewLine;
        //
        //    return commandText;
        //}
        #endregion
        //--- DEL  2015/02/23 佐々木 -----<<<<<



    }
}
