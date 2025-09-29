//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 連番No.1016 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタコンバートツール用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタコンバートツール用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/08/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockConvertDB
    {
        /// <summary>
        /// 在庫マスタコンバートツールの削除処理
        /// </summary>
        /// <param name="stockConvertWorkObj">在庫マスタコンバートクラスワーク</param>
        /// <param name="stockCount">在庫マスタ　処理件数</param>
        /// <param name="stockAcPayHistCount">在庫受払履歴データ　処理件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタコンバート処理を行うクラスです。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvertShipmentPosCnt(
            object stockConvertWorkObj,
            out int stockCount,
            out int stockAcPayHistCount);
    }
}
