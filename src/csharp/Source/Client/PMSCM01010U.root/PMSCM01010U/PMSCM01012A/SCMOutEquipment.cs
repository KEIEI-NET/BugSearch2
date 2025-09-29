//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/08/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM外装品クラス
    /// </summary>
    public static class SCMOutEquipment
    {
        /// <summary>
        /// 外装品判定処理
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <returns>true:外装品 false:外装品以外</returns>
        public static bool CheckOutEquipment(int blCode)
        {
            bool ret = false;

            int[] outEquip = new int[] {
                1102,
                1103,
                1104,
                1105,
                1106,
                1107,
                1108,
                1702,
                2104,
                2204,
                3104,
                3204,
                4102,
                4103,
                4104,
                4105,
                4106,
                4107,
                4108
                // TODO:外装品を追加する場合、BLコードをここに追加
            };

            ArrayList outEquipList = new ArrayList(outEquip);

            if (outEquipList.Contains(blCode)) ret = true;

            return ret;
        }
    }
}
