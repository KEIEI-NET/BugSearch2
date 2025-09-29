//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報マスタメンテナンス
// プログラム概要   : 接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : 田建委
// 作 成 日  2019/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 接続先情報設定DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 接続先情報設定DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>管理番号   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalCprtConnectInfoPrcPrStDB
    {
        /// <summary>
        ///  接続先情報設定LISTを全て戻します
        /// </summary>
        /// <param name="outConnectInfoPrcPrSt">検索結果</param>
        /// <param name="paraConnectInfoWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定LISTを全て戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
			out object outConnectInfoPrcPrSt,
            object paraConnectInfoWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定された接続先情報設定Guidの接続先情報設定を戻します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  指定された接続先情報設定Guidの接続先情報設定を戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        int Read(ref byte[] parabyte, int readMode);
        
        /// <summary>
        ///接続先情報マスタ情報を論理削除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除する接続先情報マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWork);

        /// <summary>
        /// 接続先情報マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="connectInfoWorkbyte">追加・更新する接続先情報マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <param name="flag">時間更新フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWorkbyte, int writeMode, int flag);

        /// <summary>
        /// 接続先情報マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除を解除する接続先情報マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork")]
            ref object connectInfoWork);

        /// <summary>
        /// 接続先情報マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を物理削除します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        int Delete(byte[] parabyte);      
    }
}
