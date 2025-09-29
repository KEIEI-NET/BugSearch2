//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理ログ参照ツール
// プログラム概要   : 送受信履歴の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/07/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC送受信履歴　リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送受信履歴DBインターフェースです。</br>
    /// <br>Programmer : 張曼</br>
    /// <br>Date       : 2012/07/23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface ISndRcvHisTableDB
    {
        # region カスタムシリアライズ
        /// <summary>
        /// 送受信履歴情報を登録、更新します
        /// </summary>
        /// <param name="sndRcvHisTableList">送受信履歴ログブジェクトリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴情報を登録、更新します</br>
        /// <br>Programmer  : 張曼</br>
        /// <br>Date        : 2012/07/23</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
            ref object sndRcvHisTableList);

        /// <summary>
        /// 送受信履歴LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="sndRcvHisConWork">検索パラメータ</param>
        /// <param name="retList1">送受信履歴検索結果</param>
        /// <param name="retList2">送受信抽出条件履歴ログデータ検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : 張曼</br>
        /// <br>Date        : 2012/07/23</br>
        [MustCustomSerialization]
        int Search(
            SndRcvHisConWork sndRcvHisConWork,
            [CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
            out object retList1,
            [CustomSerializationMethodParameterAttribute("PMKYO09407D", "Broadleaf.Application.Remoting.ParamData.SndRcvEtrWork")]
            out object retList2);

        /// <summary>
        /// 送受信履歴情報を物理削除
        /// </summary>
        /// <param name="paraList">物理削除情報オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork")]
                   ref object paraList);

        #endregion
    }
}
