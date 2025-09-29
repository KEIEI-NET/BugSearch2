//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期状態表示端末設定
// プログラム概要   : 同期状態表示端末設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉超
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Net.NetworkInformation;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 同期状態表示端末設定マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状態表示端末設定マスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 劉超</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SyncStateDspTermStAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private ISyncStateDspTermStDB _iSyncStateDspTermStDB = null;
        # endregion

        # region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        # endregion

        # region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public SyncStateDspTermStAcs()
        {
            // リモートオブジェクト取得
            this._iSyncStateDspTermStDB = (ISyncStateDspTermStDB)MediationSyncStateDspTermStDB.GetSyncStateDspTermStDB();
        }
        # endregion

        # region -- 検索･復活処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 同期状態表示端末設定マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 同期状態表示端末設定マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 同期状態表示端末設定マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevSyncStateSt">前回最終車販書類同期状態表示端末設定マスタデータオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SyncStateDspTermStWork prevSyncStateSt, SearchMode searchMode)
        {
            SyncStateDspTermStWork syncStateSt = new SyncStateDspTermStWork();

            syncStateSt.EnterpriseCode = enterpriseCode;

            // 次データ有無初期化
            nextData = false;

            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList secMngSetWorkList = new ArrayList();
            secMngSetWorkList.Clear();

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object paraobj = syncStateSt;
            object retobj = null;
            try
            {
                status = this._iSyncStateDspTermStDB.Search(out retobj, paraobj, 0, logicalMode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    secMngSetWorkList = retobj as ArrayList;

                    foreach (SyncStateDspTermStWork secMngSetWorkTemp in secMngSetWorkList)
                    {
                        retList.Add(secMngSetWorkTemp);
                    }
                }

                // STATUS を設定
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (retList.Count == 0))
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSyncStateDspTermStDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 同期状態表示端末設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの復活を行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Revival(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            try
            {
                status = this._iSyncStateDspTermStDB.RevivalLogicalDelete(ref objSecMngSetWork);

                if (status == 0)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    syncStateSt = (SyncStateDspTermStWork)objSecMngSetWork;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSyncStateDspTermStDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="syncStateSt">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Write(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            try
            {
                status = this._iSyncStateDspTermStDB.Write(ref objSecMngSetWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (objSecMngSetWork is ArrayList)
                    {
                        // ファイル名を渡してワーククラスをデシリアライズする
                        syncStateSt = (SyncStateDspTermStWork)((ArrayList)objSecMngSetWork)[0];
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSyncStateDspTermStDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        # endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの論理削除を行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int LogicalDelete(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object objSecMngSetWork = syncStateSt;

            try
            {
                // 拠点情報論理削除
                status = this._iSyncStateDspTermStDB.LogicalDelete(ref objSecMngSetWork);

                if (status == 0)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    syncStateSt = objSecMngSetWork as SyncStateDspTermStWork;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSyncStateDspTermStDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="syncStateSt">同期状態表示端末設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 同期状態表示端末設定マスタの物理削除を行います。</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Delete(SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            // 同期状態表示端末設定マスタ物理削除
            status = this._iSyncStateDspTermStDB.Delete(objSecMngSetWork);

            return status;
        }

        # endregion
    }
}
