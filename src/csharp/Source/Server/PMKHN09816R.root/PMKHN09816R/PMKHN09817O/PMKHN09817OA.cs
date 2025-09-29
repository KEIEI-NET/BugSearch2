//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタエクスポートDBインターフェース
// プログラム概要   : 掛率マスタエクスポートDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-**  作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12   修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : K.Miura
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasWork → RateTextWork
//                                   IStockMasDB → IRateTextDB
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 掛率マスタエクスポートDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタエクスポートDBインターフェースです。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12 </br>
    /// <br></br>
    /// <br>Update Note: 掛け率マスタインポート・エクスポート機能追加対応</br>
    /// <br>Programmer : 30521 T.MOTOYAMA</br>
    /// <br>Date       : 2013.10.28</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    // --- CHG  2015/10/14 K.Miura --- >>>>
    // public interface IStockMasDB
    public interface IRateTextDB
    // --- CHG  2015/10/14 K.Miura --- <<<<
    {
        /// <summary>
        /// 掛率マスタのリストを取得します。
        /// </summary>
        /// <param name="outList">検索結果</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率マスタのキー値が一致する、全ての掛率マスタ情報を取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        [MustCustomSerialization]
        // --- CHG  2015/10/14 K.Miura --- >>>>
        //int Search([CustomSerializationMethodParameterAttribute("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.StockMasWork")]
        //           out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09818D", "Broadleaf.Application.Remoting.ParamData.RateTextWork")]
                   out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // --- CHG  2015/10/14 K.Miura --- <<<<

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// 掛率設定マスタ情報を登録、更新します(掛け率マスタ インポート・エクスポート用)
        /// </summary>
        /// <param name="RateWork">RateWorkオブジェクト</param>
        /// <param name="writestatus">更新条件　1:追加　2:更新　3:追加＋更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object RateWork, int writestatus
            );
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
    }
}