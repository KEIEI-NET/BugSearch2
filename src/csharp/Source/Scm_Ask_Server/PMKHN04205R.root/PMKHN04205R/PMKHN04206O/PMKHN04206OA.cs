//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : Redmine#17394
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/11/19

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 他社部品検索履歴照会DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 他社部品検索履歴照会DBインターフェースです。</br>
    /// <br>Programmer : 朱 猛</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS)]
    public interface IScmInqLogInquiryDB
    {
        /// <summary>
        /// SCM問合せログテーブルのリストを取得します。
        /// </summary>
        /// <param name="outScmInqLogList">検索結果</param>
        /// <param name="scmInqLogInquirySearchPara">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM問合せログテーブルのリストを取得します。</br>
        /// <br>Programmer : 朱猛</br>
        /// <br>Date       : 2010/11/11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN04207D", "Broadleaf.Application.Remoting.ParamData.ScmInqLogInquiryWork")]
            //out object outScmInqLogList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode); // DEL 2010/11/19
            out object outScmInqLogList, ref object scmInqLogInquirySearchPara, int readMode); // ADD 2010/11/19
    }
}
