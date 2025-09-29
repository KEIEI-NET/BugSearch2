using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

//using Broadleaf.Library.Runtime.Serialization; // DEL caohh 2011/08/17
using Broadleaf.Application.Resources;
//using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 自由帳票（売上伝票）　DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票（売上伝票）DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22018　鈴木　正臣</br>
	/// <br>Date       : 2008.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// アプリケーションサーバーの接続先
    public interface IFrePSalesSlipDB
	{
        /// <summary>
        /// 自由帳票（売上伝票）情報検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出条件パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">自由帳票（売上伝票）抽出結果リスト</param>
        /// <param name="frePMasterList">自由帳票（売上伝票）関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票（売上伝票）結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.05.28</br>
        /// </remarks>
        int Search(
            object frePrtCmnExtPrmWork,
            out object frePSalesSlipRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );
        /// <summary>
        /// 自由帳票（見積書）関連情報検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出条件パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">自由帳票（売上伝票）抽出結果リスト</param>
        /// <param name="frePMasterList">自由帳票（見積書）関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票（見積書）関連情報結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.10.04</br>
        /// </remarks>
        int SearchForEstFm(
            object frePrtCmnExtPrmWork,
            out object frePEstFmRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );

        /// <summary>
        /// 自由帳票（ＵＯＥ伝票）関連情報検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork"></param>
        /// <param name="frePSalesSlipRetWorkList"></param>
        /// <param name="frePMasterList"></param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票（ＵＯＥ伝票）関連情報結果クラスワークLISTを取得します。</br>
        /// <br>               ベースになる印字情報はＵＩから指定される為、リモートでは関連する不足分の情報をセットします。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        int SearchForUOE(
            object frePrtCmnExtPrmWork,
            out object frePSalesSlipRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );
   }
}
