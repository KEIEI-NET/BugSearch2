//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新リモート
// プログラム概要   : 商品バーコード更新RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品バーコード更新RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新RemoteObjectインターフェースの定義</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IPrmGoodsBarCodeRevnUpdateDB
    {
        /// <summary>
        /// 優良設定マスタ検索処理
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="getPrmPartsBrcdParaList">更新対象優良設定リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する更新対象優良設定を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int GetPrmPartsInfoList(
            [CustomSerializationMethodParameterAttribute( "PMHND09414D", "Broadleaf.Application.Remoting.ParamData.PrmSetUParamForBrcdWork" )]
                ref PrmSetUParamForBrcdWork selectParam,
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                out object getPrmPartsBrcdParaList
            );

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int GetSearchCount(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
                out int retCnt
            );

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
            [CustomSerializationMethodParameterAttribute( "PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork" )]
                out object prmPartsBrcdInfoList
            );

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）更新
        /// </summary>
        /// <param name="updateList">更新リスト</param>
        /// <param name="updateCount">処理件数</param>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルに、更新リストに格納された各要素を登録/更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int UpdateGoodsBarcodeRevn(
            [CustomSerializationMethodParameterAttribute( "PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
                ref object updateList,
                out int updateCount,
                ref int barcodeUpdateKndDiv
            );

        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        int WriteOprtnHisLog( OprtnHisLogWork writeParam );
    
    }
}
