using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;   //.ParamData;
using Broadleaf.Application.Resources;



namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 入金入力設定系DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金入力設定系DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 90027　高口　勝</br>
    /// <br>Date       : 2005.08.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

    public interface IDepBillMonSecDB 
    {

        /// <summary>
        /// 入金入力設定系LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retTotalCnt">検索結果件数</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="priseCd">企業コード</param>
        /// <param name="depositStWorkList">検索結果(入金設定)</param>
        /// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        /// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.17</br>
        int Search(
            out int retTotalCnt, 
            int readMode, 
            string priseCd, 
            out byte[] depositStWorkList, 
            out byte[] billAllStWorkList, 
            out byte[] moneyKindWorkList);


        /// <summary>
        /// 入金入力設定系LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retTotalCnt">検索結果件数</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="priseCd">企業コード</param>
        /// <param name="depositStWorkList">検索結果(入金設定)</param>
        /// <param name="billAllStWorkList">検索結果(請求全体設定)</param>
        /// <param name="moneyKindWorkList">検索結果(金額種別)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.17</br>
        int Search(
            out int retTotalCnt, 
            int readMode, 
            string priseCd, 
            out byte[] depositStWorkList, 
            out byte[] billAllStWorkList, 
            [CustomSerializationMethodParameterAttribute("SFUKK09046D","Broadleaf.Application.Remoting.ParamData.MoneyKindWork")]
            out object moneyKindWorkList);

    }

}



