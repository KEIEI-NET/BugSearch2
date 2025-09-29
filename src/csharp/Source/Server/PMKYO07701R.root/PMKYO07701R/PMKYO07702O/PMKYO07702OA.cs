//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 集計機コントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 集計機コントロールDBインターフェースです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Summary_AP)]
    public interface ISKControlDB
    {
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="outreceiveList">検索結果</param>
        /// <param name="parareceiveWork">検索条件</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="fileIds">検索データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.3.31</br>
        int Search(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds);

        /// <summary>
        /// 集計機コントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);
    }
}
