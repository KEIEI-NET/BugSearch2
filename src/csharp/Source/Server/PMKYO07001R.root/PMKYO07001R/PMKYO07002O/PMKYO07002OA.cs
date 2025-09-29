//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// データ送信処理用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAPSendMessageDB
    {
        /// <summary>
        /// データ初期設定
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
		/// <param name="SecMngSetWorkList">検索結果</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データを初期設定する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchLoadData(
            string enterpriseCodes,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngSetWork")]
			//out APSecMngSetWork SecMngSetWork,
			out ArrayList SecMngSetWorkList,
            out string retMessage);

        /// <summary>
        /// 拠点管理設定マスタの更新
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク実行日付</param>
		/// <param name="retMessage">エラーメッセージ</param>
		/// <param name="baseCode">送信対象拠点コード</param>
		/// <param name="sendCode">送信先拠点コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点管理設定マスタの更新する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int UpdateSecMngSet(
            string enterpriseCodes,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage
			,string baseCode
			,string sendCode);

		// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        /// <summary>
        /// データを更新します。
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="BeginningDate">開始日付</param>
        /// <param name="EndingDate">終了日付</param>
        /// <param name="retCSAList">検索結果</param>
        /// <param name="fileIds">ファイルID配列</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ更新</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            string enterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            string[] fileIds,
            out string retMessage);
		*/
		// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        /// <summary>
        /// データを更新します。
        /// </summary>
        /// <param name="enterPriseCode">検索結果</param>
        /// <param name="outreceiveList">企業コード</param>
        /// <param name="sectionCodeList">拠点リスト</param>
        /// <param name="stockAcPayHistCount">数量</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ更新</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateCustomSerializeArrayList(string enterPriseCode, object outreceiveList, ArrayList sectionCodeList, ref int stockAcPayHistCount);

        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="enterpriseCodes">拠点コード</param>
        /// <param name="SecMngSetWorkList">拠点データ</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchSecMngSetData(
            string enterpriseCodes,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngSetWork")]
            out ArrayList SecMngSetWorkList,
            out string retMessage);

        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngEpSetWorkList">拠点情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        int SearchSecMngEpSetData(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngEpSetWork")]
            out ArrayList secMngEpSetWorkList);

        /// <summary>
        /// 拠点情報を更新します。
        /// </summary>
        /// <param name="secMngSetWork">拠点マスタ</param>
        /// <param name="newSyncExecDate">シック日時</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateSecMngSetData(APSecMngSetWork secMngSetWork, Int64 newSyncExecDate);

		/// <summary>
		/// データを更新します。
		/// </summary>
		/// <param name="outreceiveList">検索結果</param>
		/// <param name="sendDataWork">検索条件</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="fileIds">検索データ</param>
		/// <param name="errMsg">errMsg</param>
		/// <param name="sndRcvHisConsNo">sndRcvHisConsNo</param>
		/// <param name="updSectionCd">updSectionCd</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : データ更新</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.21</br>
		[MustCustomSerialization]
		int SearchCustomSerializeArrayListSCM(out CustomSerializeArrayList outreceiveList, APSendDataWork sendDataWork,
			string sectionCode, string[] fileIds, out string errMsg, out int sndRcvHisConsNo, string updSectionCd);
    }
}
