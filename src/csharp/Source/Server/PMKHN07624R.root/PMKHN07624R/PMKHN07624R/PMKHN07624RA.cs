//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TBO検索マスタ（インポート）
// プログラム概要   : TBO検索マスタ（インポート）DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/07  修正内容 : 新規作成
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TBO検索マスタ（インポート）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ（インポート）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TBOSearchUImportDB : RemoteDB, ITBOSearchUImportDB
    {
        /// <summary>
        /// TBO検索マスタ（インポート）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public TBOSearchUImportDB()
            : base("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork", "TBOSearchURF")
        {
        }

        # region [Import]
        /// <summary>
        /// TBO検索マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="importWorkList">インポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        public int Import(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // インポート処理
                status = this.ImportProc(processKbn, ref importWorkList, out readCnt, out addCnt, out updCnt, out errMsg, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// TBO検索マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="importWorkList">インポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">コレクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ（インポート）のインポート処理を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        private int ImportProc(Int32 processKbn, ref object importWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;

            ArrayList tboSearchUList = new ArrayList();
            ArrayList paraList = new ArrayList();

            // TBO検索のDBリモートクラス
            TBOSearchUDB TBOSearchUDB = new TBOSearchUDB();

            try
            {
                // 検索パラメータの設定
                ArrayList importWorkArray = importWorkList as ArrayList;
                if (importWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    TBOSearchUWork paraTBOSearchUWork = new TBOSearchUWork();
                    paraTBOSearchUWork.EnterpriseCode = ((TBOSearchUWork)importWorkArray[0]).EnterpriseCode;
                    paraList.Add(paraTBOSearchUWork);
                }

                // 全てデータの検索処理
                TBOSearchUDB.Search(ref tboSearchUList, paraList, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection, ref sqlTransaction);
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Dictionaryの作成
                Dictionary<TBOSearchUImportWorkWrap, TBOSearchUWork> dict = new Dictionary<TBOSearchUImportWorkWrap, TBOSearchUWork>();
                foreach (TBOSearchUWork work in tboSearchUList)
                {
                    TBOSearchUImportWorkWrap warp = new TBOSearchUImportWorkWrap(work);
                    dict.Add(warp, work);
                }

                // 追加リスト
                ArrayList addList = new ArrayList();
                // 更新リスト
                ArrayList updList = new ArrayList();

                foreach (TBOSearchUWork importWork in importWorkArray)
                {
                    TBOSearchUImportWorkWrap importWarp = new TBOSearchUImportWorkWrap(importWork);

                    if (!dict.ContainsKey(importWarp))
                    {
                        // レコードが存在しなければ、追加リストへ追加する。
                        addList.Add(ConvertToImportWork(importWork, null, false));
                    }
                    else
                    {
                        // レコードが存在すれば、更新リストへ追加する。
                        updList.Add(ConvertToImportWork(importWork, dict[importWarp], true));
                    }
                }

                // 読込件数
                readCnt = importWorkArray.Count;
                
                // コレクションとトランザクション
                if (sqlConnection != null)
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                }

                // 処理区分が「追加」の場合
                if (processKbn == 1)
                {
                    if (addList != null && addList.Count > 0)
                    {
                        // 登録処理
                        status = TBOSearchUDB.Write(ref addList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                        }
                    }
                }
                // 処理区分が「更新」の場合
                else if (processKbn == 2)
                {
                    if (updList != null && updList.Count > 0)
                    {
                        // 更新処理
                        status = TBOSearchUDB.Write(ref updList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            updCnt = updList.Count;
                        }
                    }
                }
                // 処理区分が「追加更新」の場合
                else
                {
                    // 登録更新リストの作成
                    ArrayList addUpdList = new ArrayList();
                    if (addList.Count > 0)
                    {
                        addUpdList.AddRange(addList.GetRange(0, addList.Count));
                    }
                    if (updList.Count > 0)
                    {
                        addUpdList.AddRange(updList.GetRange(0, updList.Count));
                    }
                    if (addUpdList.Count > 0)
                    {
                        // 登録更新処理
                        status = TBOSearchUDB.Write(ref addUpdList, ref sqlConnection, ref sqlTransaction);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            addCnt = addList.Count;
                            updCnt = updList.Count;
                        }
                    }
                }

               if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                   // コミット
                   sqlTransaction.Commit();
                }
                else
                {
                   // ロールバック
                    if (sqlTransaction.Connection != null)
                    {
                        readCnt = 0;
                        addCnt = 0;
                        updCnt = 0;
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (SqlException ex)
            {
                readCnt = 0;
                addCnt = 0;
                updCnt = 0;
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// DB登録用のオブジェクトの作成
        /// </summary>
        /// <param name="csvWork">インポート用のオブジェクト</param>
        /// <param name="searchWork">検索したオブジェクト</param>
        /// <param name="isUpdFlg">更新フラグ（true:更新、false:追加）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private TBOSearchUWork ConvertToImportWork(TBOSearchUWork csvWork, TBOSearchUWork searchWork, bool isUpdFlg)
        {
            TBOSearchUWork importWork = new TBOSearchUWork();
            if (isUpdFlg)
            {
                importWork.CreateDateTime = searchWork.CreateDateTime;              // 作成日時
                importWork.UpdateDateTime = searchWork.UpdateDateTime;              // 更新日時
                importWork.FileHeaderGuid = searchWork.FileHeaderGuid;              // GUID
                importWork.LogicalDeleteCode = 0;                                   // 論理削除区分
            }
            importWork.EnterpriseCode = csvWork.EnterpriseCode;                     // 企業コード
            importWork.BLGoodsCode = csvWork.BLGoodsCode;                           // BL商品コード
            importWork.EquipGenreCode = csvWork.EquipGenreCode;                     // 装備分類
            importWork.EquipName = csvWork.EquipName;                               // 装備名称
            importWork.CarInfoJoinDispOrder = csvWork.CarInfoJoinDispOrder;         // 車両結合表示順位
            importWork.JoinDestMakerCd = csvWork.JoinDestMakerCd;                   // 結合先メーカーコード
            importWork.JoinDestPartsNo = csvWork.JoinDestPartsNo;                   // 結合先品番(－付き品番)
            importWork.JoinQty = csvWork.JoinQty;                                   // 結合ＱＴＹ
            importWork.EquipSpecialNote = csvWork.EquipSpecialNote;                 // 装備規格・特記事項
            return importWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }
        # endregion
    }

    #region TBO検索情報オブジェクト
    /// <summary>
    /// TBO検索情報オブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索情報オブジェクトです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    class TBOSearchUImportWorkWrap
    {
        #region Public Field
        public TBOSearchUWork tboWork;
        #endregion

        #region クラスコンストラクタ
        /// <summary>
        /// TBO検索情報オブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : TBO検索情報オブジェクトを取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public TBOSearchUImportWorkWrap(TBOSearchUWork tboWork)
        {
            this.tboWork = tboWork;
        }
        #endregion

        #region TBO検索情報オブジェクトのイコールの比較
        /// <summary>
        /// TBO検索情報オブジェクトのイコールの比較
        /// </summary>
        /// <param name="obj">TBO検索情報オブジェクト</param>
        /// <returns>比較結果</returns>
        /// <remarks>
        /// <br>Note       : TBO検索情報オブジェクトのイコールかどうかを比較する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override bool Equals(object obj)
        {
            TBOSearchUImportWorkWrap target = obj as TBOSearchUImportWorkWrap;
            if (target == null) return false;
            // 装備分類、装備名称、結合先メーカーコード、結合先品番(－付き品番)
            // が同じ場合、TBO検索情報オブジェクトはイコールにする。
            return target.tboWork.EnterpriseCode == tboWork.EnterpriseCode
                     && target.tboWork.EquipGenreCode == tboWork.EquipGenreCode
                     && target.tboWork.EquipName == tboWork.EquipName
                     && target.tboWork.JoinDestMakerCd == tboWork.JoinDestMakerCd
                     && target.tboWork.JoinDestPartsNo == tboWork.JoinDestPartsNo;
        }
        #endregion

        #region TBO検索情報オブジェクトのハシコード
        /// <summary>
        /// TBO検索情報オブジェクトのハシコード
        /// </summary>
        /// <returns>ハシコード</returns>
        /// <remarks>
        /// <br>Note       : TBO検索情報オブジェクトのハシコードを設定する。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        /// </remarks>
        public override int GetHashCode()
        {
            return tboWork.EnterpriseCode.GetHashCode()
                     + tboWork.EquipGenreCode.GetHashCode()
                     + tboWork.EquipName.GetHashCode()
                     + tboWork.JoinDestMakerCd.GetHashCode()
                     + tboWork.JoinDestPartsNo.GetHashCode();
        }
        #endregion
    }
    #endregion
}
