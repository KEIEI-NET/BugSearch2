//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン目標設定マスタ印刷DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタ印刷DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampTrgtPrintResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// キャンペーン目標設定マスタ印刷データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="CampTrgtPrintResult">検索結果</param>
        /// <param name="CampTrgtPrintParamWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN08717D", "Broadleaf.Application.Remoting.ParamData.CampTrgtPrintResultWork")]
			out object campTrgtPrintResultWork,
            object campTrgtPrintParamWork,
            ConstantManagement.LogicalMode logicalMode);
        #endregion
    }
}
