//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 11570219-00     作成担当 : 田建委
// 作 成 日 2019/12/02      修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 売上データテキストDBインターフェース</summary>
    /// <br>Note       : 売上データテキストDBインターフェースです.</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesCprtWorkDB
    {
        /// <summary>
        /// 売上データテキスト情報リストの取得処理。
        /// </summary>
        /// <param name="salesCprtResultWork">検索結果</param>
        /// <param name="salesCprtCndtnWork">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上連携テキストのキー値が一致する、全ての売上連携テキスト情報を取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork")]
            out object salesCprtResultWork,
           object salesCprtCndtnWork);

        /// <summary>
        /// 売上連携テキスト情報の追加・更新処理。
        /// </summary>
        /// <param name="objectSalesCprtWork">追加・更新する売上連携テキスト情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesCprtResultWork に格納されている売上連携テキスト情報を追加・更新します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork")]
            ref object objectSalesCprtWork);

        /// <summary>
        /// 売上連携テキスト送信ログ情報の登録処理。
        /// </summary>
        /// <param name="objectSalCprtSndLogWork">登録する売上連携テキスト送信ログ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSalCprtSndLogWork に格納されている売上連携テキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int WriteLog([CustomSerializationMethodParameterAttribute("PMSDC04007D", "Broadleaf.Application.Remoting.ParamData.SalCprtSndLogListResultWork")]
            ref object objectSalCprtSndLogWork);

    }
}
