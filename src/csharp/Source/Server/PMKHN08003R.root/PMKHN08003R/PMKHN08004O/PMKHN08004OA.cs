//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   コンバート処理 DBRemoteObjectインターフェース
//                  :   PMKHN08004O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート処理 DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート処理 DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvertProcessDB
    {
        /// <summary>
        /// トランザクションを開始します。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを開始します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        int BeginTransaction();

        /// <summary>
        /// トランザクションを終了します。
        /// </summary>
        /// <param name="commitFlg">true : コミット　false : ロールバック</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを終了します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        int EndTransaction(bool commitFlg);

        /// <summary>
        /// コンバートデータをPM.NSのユーザーDBに展開します。
        /// </summary>
        /// <param name="tableID">対象のテーブルID</param>
        /// <param name="truncateFlg">削除フラグ</param>
        /// <param name="deployDataList">データのリスト(CustomSerializeArrayList)</param>
        /// <param name="errList"></param>
        /// <param name="result">コンバート結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : コンバートデータをPM.NSのユーザーDBに展開します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int DeployConvertData(
            string tableID,
            bool truncateFlg,
            CustomSerializeArrayList deployDataList,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList errList,
            [CustomSerializationMethodParameter("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork")]
            out ConvertResultWork result
            );

        /// <summary>
        /// 在庫受払設定処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="lstSource">在庫受払設定の元データ[0:売上/1:売上履歴/2:仕入/3:仕入履歴/4:在庫移動/5:在庫調整]</param>
        /// <param name="resultCnt">処理データ件数</param>
        /// <returns></returns>
        int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt);

        /// <summary>
        /// 処理開始
        /// </summary>        
        /// <returns></returns>
        int StartProcess();

        /// <summary>
        /// 処理中止
        /// </summary>        
        /// <returns></returns>
        int StopProcess();
    }
}
