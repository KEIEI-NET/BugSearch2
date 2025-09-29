//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理企業設定マスタメンテナンス
// プログラム概要   : 拠点管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/03/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 企業コード設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 企業コード設定のアクセス制御を行います。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.03.26</br>
    /// <br></br>
    /// </remarks>
    public class EnterpriseSetAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private IEnterpriseSetDB _iEnterpriseSetDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        // 拠点情報取得用
        private SecInfoAcs _secInfoAcs;

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        public EnterpriseSetAcs()
        {
            // リモートオブジェクト取得
            this._iEnterpriseSetDB = (IEnterpriseSetDB)MediationEnterpriseSetDB.GetEnterpriseSetDB();
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
        /// 登録・更新処理
        /// </summary>
        /// <param name="allDefSet">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Write(ref EnterpriseSet enterpriseSet)
        {
            // UIデータクラス→ワーク
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objenterpriseSetWork = enterpriseSetWork;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iEnterpriseSetDB.Write(ref objenterpriseSetWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡してワーククラスをデシリアライズする
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // クラス内メンバコピー
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);
            }

            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="allDefSet">企業コード設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の論理削除を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int LogicalDelete(ref EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objenterpriseSetWork = enterpriseSetWork;

            // 拠点情報論理削除
            int status = this._iEnterpriseSetDB.LogicalDelete(ref objenterpriseSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // クラス内メンバコピー
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="allDefSet">企業コード設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の物理削除を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Delete(EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objEnterpriseSetWork = enterpriseSetWork;

            // 拠点情報物理削除
            int status = this._iEnterpriseSetDB.Delete(ref objEnterpriseSetWork);

            return status;
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///企業コード設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevAllDefSet">前回最終車販書類全体設定データオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の検索処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, EnterpriseSet prevEnterpriseSet, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            SecMngEpSetWork enterpriseSetWork = new SecMngEpSetWork();

            if (prevEnterpriseSet != null)
            {
                enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(prevEnterpriseSet);
            }

            enterpriseSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList enterpriseSetWorkList = new ArrayList();
            enterpriseSetWorkList.Clear();

            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            // 次データ有無初期化
            nextData = false;

            object paraobj = enterpriseSetWork;
            object retobj = null;

            status = this._iEnterpriseSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                enterpriseSetWorkList = retobj as ArrayList;

                if (enterpriseSetWorkList == null)
                {
                    return status;
                }

                foreach (SecMngEpSetWork wkenterpriseSetWork in enterpriseSetWorkList)
                {
                    retList.Add(CopyToEnterpriseSetFromEnterpriseSetWork(wkenterpriseSetWork));
                }

                // 読込対象データ総件数←ArrayListの件数
                retTotalCnt = retList.Count;
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 企業コード設定論理削除復活処理
        /// </summary>
        /// <param name="allDefSet">企業コード設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定の復活を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Revival(ref EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);

            object objenterpriseSetWork = enterpriseSetWork;

            // 復活処理
            int status = this._iEnterpriseSetDB.RevivalLogicalDelete(ref objenterpriseSetWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // クラス内メンバコピー
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);

            }

            return status;
        }

        # endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（企業コード設定ワーククラス⇒企業コード設定クラス）
        /// </summary>
        /// <param name="allDefSetWork">企業コード設定ワーククラス</param>
        /// <returns>企業コード設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定ワーククラスから企業コード設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private EnterpriseSet CopyToEnterpriseSetFromEnterpriseSetWork(SecMngEpSetWork enterpriseSetWork)
        {
            EnterpriseSet enterpriseSet = new EnterpriseSet();
            enterpriseSet.CreateDateTime = enterpriseSetWork.CreateDateTime;
            enterpriseSet.UpdateDateTime = enterpriseSetWork.UpdateDateTime;
            enterpriseSet.EnterpriseCode = enterpriseSetWork.EnterpriseCode;
            enterpriseSet.FileHeaderGuid = enterpriseSetWork.FileHeaderGuid;
            enterpriseSet.UpdEmployeeCode = enterpriseSetWork.UpdEmployeeCode;
            enterpriseSet.UpdAssemblyId1 = enterpriseSetWork.UpdAssemblyId1;
            enterpriseSet.UpdAssemblyId2 = enterpriseSetWork.UpdAssemblyId2;
            enterpriseSet.LogicalDeleteCode = enterpriseSetWork.LogicalDeleteCode;
            enterpriseSet.SectionCode = enterpriseSetWork.SectionCode;
            enterpriseSet.PmEnterpriseCode = enterpriseSetWork.PmEnterpriseCode;

            return enterpriseSet;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（企業コード設定ワーククラス⇒企業コード設定クラス）
        /// </summary>
        /// <param name="allDefSetWorkList">企業コード設定ワーククラス</param>
        /// <returns>企業コード設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定ワーククラスから企業コード設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void CopyToEnterpriseSetFromEnterpriseSetWork(ArrayList enterpriseSetWorkList)
        {
            // HashTableのKey
            string keyOfHashTable = null;

            // ArrayListが空の場合
            if (enterpriseSetWorkList == null)
                return;

            foreach (SecMngEpSetWork enterpriseSetWork in enterpriseSetWorkList)
            {
                EnterpriseSet enterpriseSet = new EnterpriseSet();

                keyOfHashTable = enterpriseSetWork.SectionCode;

                enterpriseSet.CreateDateTime = enterpriseSetWork.CreateDateTime;
                enterpriseSet.UpdateDateTime = enterpriseSetWork.UpdateDateTime;
                enterpriseSet.EnterpriseCode = enterpriseSetWork.EnterpriseCode;
                enterpriseSet.FileHeaderGuid = enterpriseSetWork.FileHeaderGuid;
                enterpriseSet.UpdEmployeeCode = enterpriseSetWork.UpdEmployeeCode;
                enterpriseSet.UpdAssemblyId1 = enterpriseSetWork.UpdAssemblyId1;
                enterpriseSet.UpdAssemblyId2 = enterpriseSetWork.UpdAssemblyId2;
                enterpriseSet.LogicalDeleteCode = enterpriseSetWork.LogicalDeleteCode;
                enterpriseSet.SectionCode = enterpriseSetWork.SectionCode;
                enterpriseSet.PmEnterpriseCode = enterpriseSetWork.PmEnterpriseCode;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（企業コード設定クラス⇒企業コード設定ワーククラス）
        /// </summary>
        /// <param name="allDefSet">企業コード設定クラス</param>
        /// <returns>企業コード設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 企業コード設定クラスから企業コード設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private SecMngEpSetWork CopyToEnterpriseSetWorkFromEnterpriseSet(EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = new SecMngEpSetWork();
            enterpriseSetWork.CreateDateTime = enterpriseSet.CreateDateTime;
            enterpriseSetWork.UpdateDateTime = enterpriseSet.UpdateDateTime;
            enterpriseSetWork.EnterpriseCode = enterpriseSet.EnterpriseCode;
            enterpriseSetWork.FileHeaderGuid = enterpriseSet.FileHeaderGuid;
            enterpriseSetWork.UpdEmployeeCode = enterpriseSet.UpdEmployeeCode;
            enterpriseSetWork.UpdAssemblyId1 = enterpriseSet.UpdAssemblyId1;
            enterpriseSetWork.UpdAssemblyId2 = enterpriseSet.UpdAssemblyId2;
            enterpriseSetWork.LogicalDeleteCode = enterpriseSet.LogicalDeleteCode;
            enterpriseSetWork.SectionCode = enterpriseSet.SectionCode;
            enterpriseSetWork.PmEnterpriseCode = enterpriseSet.PmEnterpriseCode;

            return enterpriseSetWork;

        }

        # endregion

        #region -- 対象データチェック、名称取得 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 拠点名称取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードから拠点名称を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        public string GetSectionName(string enterpriseCode, string sectionCode)
        {
            // ローカルＤＢ拠点対応
            ConstructSecInfoAcs();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.SectionCode.TrimEnd() == "0")
                {
                    return "未登録";
                }
                else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
                    (secInfoSet.LogicalDeleteCode == 0))
                {
                    return secInfoSet.SectionGuideNm;
                }
            }
            return "未登録";
        }

        /// <summary>
        /// ローカルＤＢ対応拠点情報クラス作成処理
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
