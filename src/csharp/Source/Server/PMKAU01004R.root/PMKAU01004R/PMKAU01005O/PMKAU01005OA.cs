using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 自由帳票（請求書）　DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票（請求書）DB RemoteObject Interfaceです。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// アプリケーションサーバーの接続先
    public interface IEBooksFrePBillDB
	{
        /// <summary>
        /// 自由帳票（請求書）情報検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">抽出条件パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">自由帳票（請求書）抽出結果リスト</param>
        /// <param name="frePMasterList">自由帳票（請求書）関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票（請求書）結果クラスワークLISTを取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        int Search(
            object frePBillParaWork,
            out object frePBillRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            ); 
   }
}