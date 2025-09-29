//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IMstDCControlDB
    {
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="BeginningDate">検索条件</param>
        /// <param name="EndingDate">検索条件</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string pmEnterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out string retMessage);

        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);

        #region ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="paramList">マスタ抽出条件クラス</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out string retMessage);

        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.30</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage);

        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="secMngSndRcvWork">マスタ区分</param>
        /// <param name="param">マスタ抽出条件クラス</param>
        /// <param name="count">戻る件数</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int GetObjCount(string pmEnterpriseCodes, DCSecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage);
        #endregion ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		/// <summary>
		/// DC履歴ログとDC各データのクリア処理を追加
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.08.26</br>
		/// </remarks>
        //int DCMSDataClear(string enterpriseCode);//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 張莉莉 ----------<<<<<
    }
}
