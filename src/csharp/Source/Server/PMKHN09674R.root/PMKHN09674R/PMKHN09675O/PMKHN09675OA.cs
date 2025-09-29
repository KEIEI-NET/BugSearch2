//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品マスタ（ユーザー登録分）DB RemoteObjectインターフェース
//                  :   PMKHN09675O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   zhouyu
// Date             :   2011/07/22
// Update Note      :   連番1029  新規
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品マスタ（ユーザー登録分）DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（ユーザー登録分）DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : zhouyu</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: 連番1029  新規</br>
    /// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

    public interface IGoodsUpdateDB
    {

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="objList"></param>
        /// <param name="goodsUpdateWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        int Update(out int retCnt, object objList, GoodsUpdateWork goodsUpdateWork);

        /// <summary>
        /// 指定された企業コードの商品マスタ（ユーザー登録分）LISTの件数を戻します
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="goodsUpdateWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        int SearchAll(out object objList, GoodsUpdateWork goodsUpdateWork, ConstantManagement.LogicalMode logicalMode);
    }
}
