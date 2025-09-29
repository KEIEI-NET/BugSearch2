//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ
// プログラム概要   : 自由検索部品マスタ DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索部品マスタ用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品マスタ用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchPartsDB
    {
        /// <summary>
        /// 自由検索部品マスタ検索処理
        /// </summary>
        /// <param name="paraWork">自由検索部品マスタ条件クラス</param>
        /// <param name="retList">結果コレクション</param>
        /// <param name="readMode">検索区分（現在、未使用）</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由検索部品マスタ検索処理を行うクラスです。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraWork, 
            [CustomSerializationMethodParameterAttribute("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")]
            out object retList,
           int readMode, 
           ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定された条件の自由検索部品データ登録、更新
        /// </summary>
        /// <param name="paraObjList">自由検索部品オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            ref object paraObjList);

        /// <summary>
        /// 指定された条件の自由検索部品データ物理削除
        /// </summary>
        /// <param name="paraObjList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを物理削除します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            object paraObjList);

        /// <summary>
        /// 指定された条件の自由検索部品データ登録、更新と物理削除
        /// </summary>
        /// <param name="writeParaObjList">自由検索部品オブジェクトリスト</param>
        /// <param name="deleteParaObjList">自由検索部品オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の自由検索部品データを登録、更新と物理削除します</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/30</br>
        [MustCustomSerialization]
        int WriteAndDelete(
            [CustomSerializationMethodParameter("PMJKN09017D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsWork")] 
            ref object writeParaObjList,
            object deleteParaObjList);
    }
}
