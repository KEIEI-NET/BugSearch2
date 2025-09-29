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
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011.09.06  修正内容 : SCM対応-拠点管理（#23464）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;

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
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAPMSTControlDB
    {
        /// <summary>
        /// 送信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchMstName(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterNameList);

        /// <summary>
        /// 送信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchMstDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterDivList);

        /// <summary>
        /// 受信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterDivList);

        /// <summary>
        /// 受信マスタ名称明細区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDtlDivList">マスタ名称明細区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称明細区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstDtlDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            out ArrayList masterDtlDivList);

        /// <summary>
        /// 受信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstName(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterNameList);

        /// <summary>
        /// 送信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchSyncExecDate(string enterpriseCode,
            out ArrayList secMngSetArrList);

        /// <summary>
        /// 受信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceSyncExecDate(string enterpriseCode,
            out ArrayList secMngSetArrList);

        /// <summary>
        /// PM企業コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="pmCode">PM企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM企業コードを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SeachPmCode(string enterpriseCode,
            string baseCode,
            out string pmCode);

        /// <summary>
        /// 送信マスタデータを更新します。
        /// </summary>
        /// <param name="masterDivList">マスタ名称区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="updSectionCode">拠点コード</param>
        /// <param name="BeginningDate">開始日付</param>
        /// <param name="EndingDate">終了日付</param>
        /// <param name="retCSAList">検索結果</param>
        /// <param name="sndRcvHisConsNo">送信番号</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタデータを更新する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string enterpriseCodes,
            string updSectionCode,//ADD 2011/07/25
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out int sndRcvHisConsNo,//ADD 2011/07/25
            out string retMessage);

        /// <summary>
        /// 送信拠点情報更新
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク日時</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 拠点情報を更新する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateReceSecMngSet(
            string enterpriseCodes,
            string baseCode,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage);

        /// <summary>
        /// 受信拠点管理設定マスタの更新
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク実行日付</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信拠点管理設定マスタの更新する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int UpdateSecMngSet(
            string enterpriseCodes,
            string baseCode,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage);

        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分</param>
        /// <param name="masterDtlDivList">マスタ名称明細区分</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="pmEnterpriseCode">PM企業コード</param>
        /// <param name="isEmpty">空の判断</param>
        /// <param name="searchCountWork">検索計数</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(string enterpriseCode, ArrayList masterDivList, ArrayList masterDtlDivList, 
            ref CustomSerializeArrayList retCSAList, string pmEnterpriseCode, out bool isEmpty, 
            out MstSearchCountWorkWork searchCountWork, out string retMessage);

        #region ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="enterpriseCodes">PM企業コード</param>
        /// <param name="updSectionCode">拠点コード</param>
        /// <param name="paramList">マスタ抽出条件クラス</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="sndRcvHisConsNo">送信番号</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode,
            ArrayList paramList, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage);

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
        //int GetObjCount(string pmEnterpriseCodes, SecMngSndRcvWork secMngSndRcvWork,
        //    object param, ref int count, out string retMessage); //DEL 2011.09.06 #24364
        int GetObjCount(ArrayList masterDivList, string enterpriseCodes, ArrayList paramList,
            out MstSearchCountWorkWork searchCountWork, out string retMessage);//ADD 2011.09.06 #24364
        #endregion ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）

    }
}
