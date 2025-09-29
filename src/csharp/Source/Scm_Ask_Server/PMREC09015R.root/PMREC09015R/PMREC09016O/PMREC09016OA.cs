//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタメンテ
// プログラム概要   : リコメンド商品関連設定マスタメンテDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015.01.16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// リコメンド商品関連設定マスタメンテDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : リコメンド商品関連設定マスタメンテDBインターフェースです。</br>
    /// <br>Programmer : 西 毅</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IRecGoodsLkDB
    {

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object RecGoodsLkWorkList,
            RecGoodsLkWork parseRecGoodsLkWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理。
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// 購入者(CarpodTab)側で利用するインターフェースとなります。<br/>
        /// 購入者のキー情報となる連結元企業コードが必須条件となります。<br/>
        /// また企業拠点連結マスタで有効となる接続先における情報のみが返されます。
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015.02.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchForBuyer(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object RecGoodsLkWorkList, 
            RecGoodsLkWork parseRecGoodsLkWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ復活処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object RecGoodsLkWorkList);

        // --- ADD 2015/01/22 T.Miyamoto ------------------------------------------------------------------------------------------------------------------->>>>>
        /// <summary>
        ///指定された条件のリコメンド商品関連設定マスタ情報LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int SearchRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errMsg);

        /// <summary>
        /// リコメンド商品関連設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int WriteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);


        /// <summary>
        /// リコメンド商品関連設定マスタを物理削除します
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを物理削除します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraobj);

        /// <summary>
        /// リコメンド商品関連設定マスタを論理削除と登録、更新します
        /// </summary>
        /// <param name="paraDelObj">RecGoodsLkWorkオブジェクト</param>
        /// <param name="paraUpdObj">RecGoodsLkWorkオブジェクト</param>
        /// <param name="errorObj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを論理削除と登録、更新します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteAndWrite(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraDelObj,
            ref object paraUpdObj,
            out object errorObj);

        /// <summary>
        /// リコメンド商品関連設定マスタを完全削除、復活します
        /// </summary>
        /// <param name="paraDelObj">RecGoodsLkWorkオブジェクト</param>
        /// <param name="paraUpdObj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを完全削除、復活します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int DeleteAndRevival(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            object paraDelObj,
            ref object paraUpdObj);

        /// <summary>
        /// リコメンド商品関連設定マスタを論理削除します
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを論理削除します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int LogicalDeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);

        /// <summary>
        /// 論理削除リコメンド商品関連設定マスタを復活します
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除リコメンド商品関連設定マスタを復活します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        [MustCustomSerialization]
        int RevivalLogicalDeleteRcmd(
            [CustomSerializationMethodParameterAttribute("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork")]
            ref object paraobj);
        // --- ADD 2015/01/22 T.Miyamoto -------------------------------------------------------------------------------------------------------------------<<<<<
    }
}