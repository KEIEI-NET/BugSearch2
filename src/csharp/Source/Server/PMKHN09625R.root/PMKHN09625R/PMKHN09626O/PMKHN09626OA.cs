//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタメンテナンス
// プログラム概要   : キャンペーン対象商品設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン対象商品設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignObjGoodsStDB
    {
        /// <summary>
        ///キャンペーン対象商品設定マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
			out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errMsg);

        /// <summary>
        /// キャンペーン対象商品設定マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            out object retobj,
            string enterpriseCode,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
           ref string errMsg);

        /// <summary>
        /// キャンペーン対象商品設定マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            out object retobj,
            object paraobj,
            ref string errMsg);

        /// <summary>
        /// キャンペーン対象商品設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE接続先情報を登録、更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            ref object paraobj);

        /// <summary>
        /// キャンペーン対象商品設定マスタを物理削除します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン対象商品設定マスタを物理削除します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            object paraobj);

        /// <summary>
        /// キャンペーン対象商品設定マスタを論理削除と登録、更新します
        /// </summary>
        /// <param name="paraDelObj">CampaignMngWorkオブジェクト</param>
        /// <param name="paraUpdObj">CampaignMngWorkオブジェクト</param>
        /// <param name="errorObj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン対象商品設定マスタを論理削除と登録、更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int DeleteAndWrite(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            object paraDelObj,
            ref object paraUpdObj,
            out object errorObj);

        /// <summary>
        /// キャンペーン対象商品設定マスタを完全削除、復活します
        /// </summary>
        /// <param name="paraDelObj">CampaignMngWorkオブジェクト</param>
        /// <param name="paraUpdObj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン対象商品設定マスタを完全削除、復活します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int DeleteAndRevival(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            object paraDelObj,
            ref object paraUpdObj);

        /// <summary>
        /// キャンペーン対象商品設定マスタを論理削除します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン対象商品設定マスタを論理削除します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            ref object paraobj);

        /// <summary>
        /// 論理削除キャンペーン対象商品設定マスタを復活します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除キャンペーン対象商品設定マスタを復活します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09627D", "Broadleaf.Application.Remoting.ParamData.CampaignObjGoodsStWork")]
            ref object paraobj);
    }
}
