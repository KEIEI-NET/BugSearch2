//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Net.NetworkInformation;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 拠点管理設定マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点管理設定マスタメンテナンスのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.03.26</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SecMngSetAcs
    {
        # region -- リモートオブジェクト格納バッファ --
        private ISecMngSetDB _iSecMngSetDB = null;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public SecMngSetAcs()
        {
            // リモートオブジェクト取得
            this._iSecMngSetDB = (ISecMngSetDB)MediationSecMngSetDB.GetSecMngSetDB();
        }
        # endregion

        # region -- 検索･復活処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevSecMngSet">前回最終車販書類拠点管理設定マスタデータオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SecMngSet prevSecMngSet, SearchMode searchMode)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            if (prevSecMngSet != null)
            {
                secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(prevSecMngSet);
            }
            secMngSetWork.EnterpriseCode = enterpriseCode;

            // 次データ有無初期化
            nextData = false;

            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList secMngSetWorkList = new ArrayList();
            secMngSetWorkList.Clear();

            int status = 0;

            object paraobj = secMngSetWork;
            object retobj = null;

            status = this._iSecMngSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                secMngSetWorkList = retobj as ArrayList;

                foreach (SecMngSetWork secMngSetWorkTemp in secMngSetWorkList)
                {
                    retList.Add(CopyToSecMngSetFromSecMngSetWork(secMngSetWorkTemp));
                }
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの復活を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Revival(ref SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // UIデータクラス→ワーク
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            status = this._iSecMngSetDB.RevivalLogicalDelete(ref objSecMngSetWork);

            if (status == 0)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                //secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                // クラス内メンバコピー
                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="secMngSet">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Write(ref SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int writeMode = 0;
            // UIデータクラス→ワーク
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            status = this._iSecMngSetDB.Write(ref objSecMngSetWork, writeMode);

            if (status == 0)
            {
                // ファイル名を渡してワーククラスをデシリアライズする
                // secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }

        # endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの論理削除を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int LogicalDelete(ref SecMngSet secMngSet)
        {
            // UIデータクラス→ワーク
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            // 拠点情報論理削除
            int status = this._iSecMngSetDB.LogicalDelete(ref objSecMngSetWork);

            if (status == 0)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                //secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタの物理削除を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Delete(SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // UIデータクラス→ワーク
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XMLへ変換し、文字列のバイナリ化
            // byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            // 拠点管理設定マスタ物理削除
            status = this._iSecMngSetDB.Delete(ref objSecMngSetWork);

            return status;
        }

        # endregion

        # region 保存チャック
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点管理設定マスタのデータチェック処理
        /// </summary>
        /// <param name="sCreenSecMngSet">画面INFO</param>
        /// <returns>検索データnumber</returns>
        /// <remarks>
        /// <br>Note       : 保存場合、拠点管理設定マスタのデータチェック処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int CheckScreenData(ref SecMngSet sCreenSecMngSet)
        {
            int status = 0;

            // 送受信実行日チェック
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            if (sCreenSecMngSet.Kind == 0
                && DateTime.Compare(sCreenSecMngSet.SyncExecDate, prevTotalDay) < 0)
            {
                status = 2;
                return status;
            }

			// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
            // 種別チェック
			//ArrayList secMngSetList = new ArrayList();
			//status = this.SearchAll(out secMngSetList, sCreenSecMngSet.EnterpriseCode);

			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
			//    || status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//    for (int i = 0; i < secMngSetList.Count; i++)
			//    {
			//        SecMngSet secMngSet = secMngSetList[i] as SecMngSet;

			//        if (sCreenSecMngSet.ReceiveCondition == 0
			//            && secMngSet.Kind == sCreenSecMngSet.Kind
			//            && secMngSet.ReceiveCondition == 0
			//            && secMngSet.LogicalDeleteCode == 0)
			//        {
			//            status = 3;
			//            break;
			//        }

			//        if (sCreenSecMngSet.Kind == 0
			//            && secMngSet.LogicalDeleteCode == 0
			//            && secMngSet.Kind == 0
			//            && ((sCreenSecMngSet.ReceiveCondition == 0 && secMngSet.ReceiveCondition == 1)
			//            || (sCreenSecMngSet.ReceiveCondition == 1 && secMngSet.ReceiveCondition == 0)))
			//        {
			//            status = 4;
			//            break;
			//        }
			//    }
			//}
			// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            return status;
        }
        # endregion

        # region -- クラスメンバーコピー処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理設定マスタワーククラス⇒拠点管理設定マスタクラス）
        /// </summary>
        /// <param name="secMngSetWork">拠点管理設定マスタワーククラス</param>
        /// <returns>拠点管理設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタワーククラスから拠点管理設定マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SecMngSet CopyToSecMngSetFromSecMngSetWork(SecMngSetWork secMngSetWork)
        {
            SecMngSet secMngSet = new SecMngSet();

            secMngSet.CreateDateTime = secMngSetWork.CreateDateTime;
            secMngSet.UpdateDateTime = secMngSetWork.UpdateDateTime;
            secMngSet.EnterpriseCode = secMngSetWork.EnterpriseCode;
            secMngSet.FileHeaderGuid = secMngSetWork.FileHeaderGuid;
            secMngSet.UpdEmployeeCode = secMngSetWork.UpdEmployeeCode;
            secMngSet.UpdAssemblyId1 = secMngSetWork.UpdAssemblyId1;
            secMngSet.UpdAssemblyId2 = secMngSetWork.UpdAssemblyId2;
            secMngSet.LogicalDeleteCode = secMngSetWork.LogicalDeleteCode;
            secMngSet.Kind = secMngSetWork.Kind;
            secMngSet.ReceiveCondition = secMngSetWork.ReceiveCondition;
            secMngSet.SectionCode = secMngSetWork.SectionCode;
            secMngSet.SyncExecDate = secMngSetWork.SyncExecDate;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			secMngSet.SendDestSecCode = secMngSetWork.SendDestSecCode;
			secMngSet.AutoSendDiv = secMngSetWork.AutoSendDiv;
			secMngSet.SndFinDataEdDiv = secMngSetWork.SndFinDataEdDiv;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            return secMngSet;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（拠点管理設定マスタクラス⇒拠点管理設定マスタワーククラス）
        /// </summary>
        /// <param name="secMngSet">拠点管理設定マスタクラス</param>
        /// <returns>拠点管理設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定マスタクラスから拠点管理設定マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SecMngSetWork CopyToSecMngSetWorkFromSecMngSet(SecMngSet secMngSet)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            secMngSetWork.CreateDateTime = secMngSet.CreateDateTime;
            secMngSetWork.UpdateDateTime = secMngSet.UpdateDateTime;
            secMngSetWork.EnterpriseCode = secMngSet.EnterpriseCode;
            secMngSetWork.FileHeaderGuid = secMngSet.FileHeaderGuid;
            secMngSetWork.UpdEmployeeCode = secMngSet.UpdEmployeeCode;
            secMngSetWork.UpdAssemblyId1 = secMngSet.UpdAssemblyId1;
            secMngSetWork.UpdAssemblyId2 = secMngSet.UpdAssemblyId2;
            secMngSetWork.LogicalDeleteCode = secMngSet.LogicalDeleteCode;
            secMngSetWork.Kind = secMngSet.Kind;
            secMngSetWork.ReceiveCondition = secMngSet.ReceiveCondition;
            secMngSetWork.SectionCode = secMngSet.SectionCode;
            secMngSetWork.SyncExecDate = secMngSet.SyncExecDate;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			secMngSetWork.SendDestSecCode = secMngSet.SendDestSecCode;
			secMngSetWork.AutoSendDiv = secMngSet.AutoSendDiv;
			secMngSetWork.SndFinDataEdDiv = secMngSet.SndFinDataEdDiv;
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

            return secMngSetWork;
        }
        # endregion
    }
}
