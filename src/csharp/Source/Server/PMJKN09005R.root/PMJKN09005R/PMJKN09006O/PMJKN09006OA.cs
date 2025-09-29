//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ
// プログラム概要   : 自由検索型式マスタ DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索型式マスタDB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式マスタDB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchModelDB
    {
        /// <summary>
        /// 自由検索型式マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索型式マスタ条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索型式マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraWork, [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]out object retList);


        /// <summary>
        /// 自由検索型式マスタを登録、更新します
        /// </summary>
        /// <param name="paraObj">自由検索型式マスタオブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        int Write(
            [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]
            ref object paraObj);

        /// <summary>
        /// 自由検索型式マスタを物理削除します
        /// </summary>
        /// <param name="paraObj">自由検索型式マスタオブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]
            object paraObj);
    }
}
