//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送受信対象設定マスタメンテナンス
// プログラム概要   : 送受信対象設定の変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送受信対象設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信対象設定のアクセス制御を行います。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br>Update Note: 2020/09/25 陳艶丹</br>
    /// <br>管理番号   : 11600006-00</br>
    /// <br>           : PMKOBETSU-3877の対応</br>
    /// <br></br>
    /// </remarks>
    public class SendSetAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private ISendSetDB _iSendSetDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br></br>
        /// </remarks>
        public SendSetAcs()
        {
            // リモートオブジェクト取得
            this._iSendSetDB = (ISendSetDB)MediationSendSetDB.GetSendSetDB();
        }

        #endregion

        #region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="secMngSndRcvList">UIデータクラス</param>
        /// <param name="secMngSndRcvDtlList"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 更新処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int Write(ref List<SecMngSndRcv> secMngSndRcvList, ref List<SecMngSndRcvDtl> secMngSndRcvDtlList)
        {
            //送受信対象
            ArrayList secMngSndRcvWorkList = new ArrayList();

            foreach(SecMngSndRcv secMngSndRcv in secMngSndRcvList)
            {
                // UIデータクラス→ワーク
                SecMngSndRcvWork secMngSndRcvWork = CopyToSecMngSndRcvWorkFromSecMngSet(secMngSndRcv);

                secMngSndRcvWorkList.Add(secMngSndRcvWork);
            }

            //送受信対象詳細
            ArrayList secMngSndRcvDtlWorkList = new ArrayList();

            foreach (SecMngSndRcvDtl secMngSndRcvDtl in secMngSndRcvDtlList)
            {
                // UIデータクラス→ワーク
                SecMngSndRcvDtlWork secMngSndRcvDtlWork = CopyToSecMngSndRcvDtlWorkFromSecMngDtlSet(secMngSndRcvDtl);

                secMngSndRcvDtlWorkList.Add(secMngSndRcvDtlWork);
            }


            object objsecMngSndRcvWorkList = secMngSndRcvWorkList;

            object objsecMngSndRcvDtlWorkList = secMngSndRcvDtlWorkList;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iSendSetDB.Write(ref objsecMngSndRcvWorkList, ref objsecMngSndRcvDtlWorkList, writeMode);

            return status;
        }

        #endregion

        #region -- 検索処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 送受信対象設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retDtlList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 送受信対象設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int SearchAll(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, string enterpriseCode)
        {
            return SearchAll(out retList, out retDtlList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///送受信対象設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retDtlList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 送受信対象設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        public int SearchAll(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            return SearchProc(out retList, out retDtlList, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 送受信対象設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retDtlList">読込結果コレクション</param> 
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の検索処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out List<SecMngSndRcv> retList, out List<SecMngSndRcvDtl> retDtlList, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            //拠点管理送受信対象
            SecMngSndRcvWork pSecMngSndRcvWork = new SecMngSndRcvWork();
            pSecMngSndRcvWork.EnterpriseCode = enterpriseCode;
            //拠点管理送受信対象詳細
            SecMngSndRcvDtlWork pSecMngSndRcvDtlWork = new SecMngSndRcvDtlWork();
            pSecMngSndRcvDtlWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new List<SecMngSndRcv>();
            retDtlList = new List<SecMngSndRcvDtl>();

            ArrayList secMngSndRcvWorkList = new ArrayList();
            ArrayList secMngSndRcvDtlWorkList = new ArrayList();

            // 次データ有無初期化
            nextData = false;

            object paraobj = pSecMngSndRcvWork;
            object paraDtlobj = pSecMngSndRcvDtlWork;

            object retobj = null;
            object retDtlobj = null;

            status = this._iSendSetDB.Search(out retobj, paraobj, 0, logicalMode);

            status = this._iSendSetDB.SearchDtl(out retDtlobj, paraDtlobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                secMngSndRcvWorkList = retobj as ArrayList;

                secMngSndRcvDtlWorkList = retDtlobj as ArrayList;

                if (secMngSndRcvWorkList == null || secMngSndRcvDtlWorkList == null)
                {
                    return status;
                }

                foreach (SecMngSndRcvWork secMngSndRcvWork in secMngSndRcvWorkList)
                {
                    retList.Add(CopyToSecMngSetFromSecMngSndRcvWork(secMngSndRcvWork));
                }

                foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in secMngSndRcvDtlWorkList)
                {
                    retDtlList.Add(CopyToSecMngDtlSetFromSecMngSndRcvDtlWork(secMngSndRcvDtlWork));
                }

            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                ((retList.Count == 0) || (retDtlList.Count == 0)))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理送受信対象設定ワーククラス⇒企業コード設定クラス）
        /// </summary>
        /// <param name="secMngSndRcvWork">拠点管理送受信対象設定ワーククラス</param>
        /// <returns>拠点管理送受信対象設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理送受信対象設定ワーククラスから拠点管理送受信対象詳細設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        /// </remarks>
        private SecMngSndRcv CopyToSecMngSetFromSecMngSndRcvWork(SecMngSndRcvWork secMngSndRcvWork)
        {
            SecMngSndRcv secMngSndRcv = new SecMngSndRcv();
            secMngSndRcv.CreateDateTime = secMngSndRcvWork.CreateDateTime;
            secMngSndRcv.UpdateDateTime = secMngSndRcvWork.UpdateDateTime;
            secMngSndRcv.EnterpriseCode = secMngSndRcvWork.EnterpriseCode;
            secMngSndRcv.FileHeaderGuid = secMngSndRcvWork.FileHeaderGuid;
            secMngSndRcv.UpdEmployeeCode = secMngSndRcvWork.UpdEmployeeCode;
            secMngSndRcv.UpdAssemblyId1 = secMngSndRcvWork.UpdAssemblyId1;
            secMngSndRcv.UpdAssemblyId2 = secMngSndRcvWork.UpdAssemblyId2;
            secMngSndRcv.LogicalDeleteCode = secMngSndRcvWork.LogicalDeleteCode;
            secMngSndRcv.DisplayOrder = secMngSndRcvWork.DisplayOrder;
            secMngSndRcv.MasterName = secMngSndRcvWork.MasterName;
            secMngSndRcv.FileId = secMngSndRcvWork.FileId;
            secMngSndRcv.FileNm = secMngSndRcvWork.FileNm;
            secMngSndRcv.UserGuideDivCd = secMngSndRcvWork.UserGuideDivCd;
            secMngSndRcv.SecMngSendDiv = secMngSndRcvWork.SecMngSendDiv;
            secMngSndRcv.SecMngRecvDiv = secMngSndRcvWork.SecMngRecvDiv;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            secMngSndRcv.AcptAnOdrSendDiv = secMngSndRcvWork.AcptAnOdrSendDiv;
            secMngSndRcv.AcptAnOdrRecvDiv = secMngSndRcvWork.AcptAnOdrRecvDiv;
            secMngSndRcv.ShipmentSendDiv = secMngSndRcvWork.ShipmentSendDiv;
            secMngSndRcv.ShipmentRecvDiv = secMngSndRcvWork.ShipmentRecvDiv;
            secMngSndRcv.EstimateSendDiv = secMngSndRcvWork.EstimateSendDiv;
            secMngSndRcv.EstimateRecvDiv = secMngSndRcvWork.EstimateRecvDiv;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<
            return secMngSndRcv;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理送受信対象詳細設定ワーククラス⇒企業コード設定クラス）
        /// </summary>
        /// <param name="secMngSndRcvDtlWork">拠点管理送受信対象詳細設定ワーククラス</param>
        /// <returns>拠点管理送受信対象詳細設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理送受信対象詳細設定ワーククラスから拠点管理送受信対象詳細設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtl CopyToSecMngDtlSetFromSecMngSndRcvDtlWork(SecMngSndRcvDtlWork secMngSndRcvDtlWork)
        {
            SecMngSndRcvDtl secMngSndRcvDtl = new SecMngSndRcvDtl();

            secMngSndRcvDtl.CreateDateTime = secMngSndRcvDtlWork.CreateDateTime;
            secMngSndRcvDtl.UpdateDateTime = secMngSndRcvDtlWork.UpdateDateTime;
            secMngSndRcvDtl.EnterpriseCode = secMngSndRcvDtlWork.EnterpriseCode;
            secMngSndRcvDtl.FileHeaderGuid = secMngSndRcvDtlWork.FileHeaderGuid;
            secMngSndRcvDtl.UpdEmployeeCode = secMngSndRcvDtlWork.UpdEmployeeCode;
            secMngSndRcvDtl.UpdAssemblyId1 = secMngSndRcvDtlWork.UpdAssemblyId1;
            secMngSndRcvDtl.UpdAssemblyId2 = secMngSndRcvDtlWork.UpdAssemblyId2;
            secMngSndRcvDtl.LogicalDeleteCode = secMngSndRcvDtlWork.LogicalDeleteCode;
            secMngSndRcvDtl.FileId = secMngSndRcvDtlWork.FileId;
            secMngSndRcvDtl.FileNm = secMngSndRcvDtlWork.FileNm;
            secMngSndRcvDtl.ItemId = secMngSndRcvDtlWork.ItemId;
            secMngSndRcvDtl.ItemName = secMngSndRcvDtlWork.ItemName;
            secMngSndRcvDtl.DataUpdateDiv = secMngSndRcvDtlWork.DataUpdateDiv;
            secMngSndRcvDtl.DisplayOrder = secMngSndRcvDtlWork.DisplayOrder;

            return secMngSndRcvDtl;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理送受信対象設定クラス⇒拠点管理送受信対象設定ワーククラス）
        /// </summary>
        /// <param name="secMngSndRcv">拠点管理送受信対象設定クラス</param>
        /// <returns>拠点管理送受信対象設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理送受信対象設定クラスから拠点管理送受信対象設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// <br>Update Note: 2020/09/25 陳艶丹</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        /// </remarks>
        private SecMngSndRcvWork CopyToSecMngSndRcvWorkFromSecMngSet(SecMngSndRcv secMngSndRcv)
        {
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();

            secMngSndRcvWork.CreateDateTime = secMngSndRcv.CreateDateTime;
            secMngSndRcvWork.UpdateDateTime = secMngSndRcv.UpdateDateTime;
            secMngSndRcvWork.EnterpriseCode = secMngSndRcv.EnterpriseCode;
            secMngSndRcvWork.FileHeaderGuid = secMngSndRcv.FileHeaderGuid;
            secMngSndRcvWork.UpdEmployeeCode = secMngSndRcv.UpdEmployeeCode;
            secMngSndRcvWork.UpdAssemblyId1 = secMngSndRcv.UpdAssemblyId1;
            secMngSndRcvWork.UpdAssemblyId2 = secMngSndRcv.UpdAssemblyId2;
            secMngSndRcvWork.LogicalDeleteCode = secMngSndRcv.LogicalDeleteCode;
            secMngSndRcvWork.DisplayOrder = secMngSndRcv.DisplayOrder;
            secMngSndRcvWork.MasterName = secMngSndRcv.MasterName;
            secMngSndRcvWork.FileId = secMngSndRcv.FileId;
            secMngSndRcvWork.FileNm = secMngSndRcv.FileNm;
            secMngSndRcvWork.UserGuideDivCd = secMngSndRcv.UserGuideDivCd;
            secMngSndRcvWork.SecMngSendDiv = secMngSndRcv.SecMngSendDiv;
            secMngSndRcvWork.SecMngRecvDiv = secMngSndRcv.SecMngRecvDiv;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------>>>>>
            secMngSndRcvWork.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
            secMngSndRcvWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
            secMngSndRcvWork.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
            secMngSndRcvWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
            secMngSndRcvWork.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
            secMngSndRcvWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
            // ADD 陳艶丹 2020/09/25 PMKOBETSU-3877の対応 ------<<<<<

            return secMngSndRcvWork;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理送受信対象詳細設定クラス⇒拠点管理送受信対象詳細設定ワーククラス）
        /// </summary>
        /// <param name="secMngSndRcvDtl">拠点管理送受信対象詳細設定クラス</param>
        /// <returns>拠点管理送受信対象詳細設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理送受信対象詳細設定クラスから拠点管理送受信対象詳細設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.04.22</br>
        /// </remarks>
        private SecMngSndRcvDtlWork CopyToSecMngSndRcvDtlWorkFromSecMngDtlSet(SecMngSndRcvDtl secMngSndRcvDtl)
        {
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();

            secMngSndRcvDtlWork.CreateDateTime = secMngSndRcvDtl.CreateDateTime;
            secMngSndRcvDtlWork.UpdateDateTime = secMngSndRcvDtl.UpdateDateTime;
            secMngSndRcvDtlWork.EnterpriseCode = secMngSndRcvDtl.EnterpriseCode;
            secMngSndRcvDtlWork.FileHeaderGuid = secMngSndRcvDtl.FileHeaderGuid;
            secMngSndRcvDtlWork.UpdEmployeeCode = secMngSndRcvDtl.UpdEmployeeCode;
            secMngSndRcvDtlWork.UpdAssemblyId1 = secMngSndRcvDtl.UpdAssemblyId1;
            secMngSndRcvDtlWork.UpdAssemblyId2 = secMngSndRcvDtl.UpdAssemblyId2;
            secMngSndRcvDtlWork.LogicalDeleteCode = secMngSndRcvDtl.LogicalDeleteCode;
            secMngSndRcvDtlWork.FileId = secMngSndRcvDtl.FileId;
            secMngSndRcvDtlWork.FileNm = secMngSndRcvDtl.FileNm;
            secMngSndRcvDtlWork.ItemId = secMngSndRcvDtl.ItemId;
            secMngSndRcvDtlWork.ItemName = secMngSndRcvDtl.ItemName;
            secMngSndRcvDtlWork.DataUpdateDiv = secMngSndRcvDtl.DataUpdateDiv;

            return secMngSndRcvDtlWork;

        }

        # endregion
    }
}
