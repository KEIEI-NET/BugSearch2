//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコード層別変換処理
// プログラム概要   : ＢＬコード層別変換処理DB RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/01/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ＢＬコード層別変換処理DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＢＬコード層別変換処理DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2010/01/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDataBLGoodsRateRankConvertDB
    {
        #region ＢＬコード層別変換処理の実行処理
        /// <summary>
        /// ＢＬコード層別変換処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="excellentSetFile_A">優良設定パラメータリストＡ</param>
        /// <param name="excellentSetFile_B">優良設定パラメータリストＢ</param>
        /// <param name="excellentSetFile_C">優良設定パラメータリストＣ</param>
        /// <param name="goodsFile_A">商品パラメータリストＡ</param>
        /// <param name="goodsFile_B">商品パラメータリストＢ</param>
        /// <param name="goodsFile_C">商品パラメータリストＣ</param>
        /// <param name="partsFile">部位パラメータのリスト</param>
        /// <param name="rateFile_A">掛率パラメータリストＡ</param>
        /// <param name="rateFile_B">掛率パラメータリストＢ</param>
        /// <param name="rateFile_C">掛率パラメータリストＣ</param>
        /// <param name="retList">処理結果リスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/01/12</br>
        [MustCustomSerialization]
        int Update(
            [CustomSerializationMethodParameterAttribute("PMKHN09286D", "Broadleaf.Application.Remoting.ParamData.ResultListWork")]
            string enterpriseCode, 
            object rateFile_A,
            object rateFile_B,
            object rateFile_C,
            object goodsFile_A,
            object goodsFile_B,
            object goodsFile_C,
            object partsFile,
            object excellentSetFile_A,
            object excellentSetFile_B,
            object excellentSetFile_C,
            out object retList,
            out string errMsg);
        #endregion
    }
}
