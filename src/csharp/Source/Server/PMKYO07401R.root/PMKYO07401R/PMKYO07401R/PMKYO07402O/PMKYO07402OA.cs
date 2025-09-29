//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBインターフェースです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IDCControlDB
    {
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="outreceiveList">検索結果</param>
        /// <param name="parareceiveWork">検索条件</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="fileIds">検索データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        int Search(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds);
		*/
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

		/// <summary>
		/// データを取得します。
		/// </summary>
		/// <param name="outreceiveList">検索結果</param>
		/// <param name="parareceiveWork">検索条件</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="fileIds">検索データ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : データ取得</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		int SearchSCM(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds);

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /// <summary>
        /// 締めチェックします。
        /// </summary>
        /// <param name="outErrorList">検索結果</param>
        /// <param name="parareceiveWorkList">検索条件</param>
        /// <param name="salesSimeDate">売上締め日</param>
        /// <param name="StockSimeDate">仕入締め日</param>
        /// <param name="saleCheckFlg">売上チェックフラグ</param>
        /// <param name="depsitCheckFlg">入金チェックフラグ</param>
        /// <param name="stockCheckFlg">仕入チェックフラグ</param>
        /// <param name="paymentCheckFlg">支払いチェックフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締めチェック</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2011.07.21</br>
        int SimeCheckSCM(out ArrayList outErrorList, ArrayList parareceiveWorkList,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg);

		/// <summary>
		/// 締めチェックします。
		/// </summary>
        /// <param name="outErrorList">検索結果</param>
		/// <param name="parareceiveWork">検索条件</param>
		/// <param name="salesSimeDate">売上締め日</param>
		/// <param name="StockSimeDate">仕入締め日</param>
		/// <param name="saleCheckFlg">売上チェックフラグ</param>
		/// <param name="depsitCheckFlg">入金チェックフラグ</param>
		/// <param name="stockCheckFlg">仕入チェックフラグ</param>
		/// <param name="paymentCheckFlg">支払いチェックフラグ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 締めチェック</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		int SimeCheckSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork,
			Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg);
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);
		*/
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

		/// <summary>
		/// DCコントロールリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.30</br>
		/// </remarks>
		int UpdateSCM(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage);

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		/// <summary>
		/// DC履歴ログとDC各データのクリア処理を追加
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.08.26</br>
		/// </remarks>
        //int DCDataClear(string enterpriseCode);                                  //DEL by Liangsd     2011/09/06
        int DCDataClear(string sectionCode, string enterpriseCode);//ADD by Liangsd    2011/09/06
		// ADD 2011.08.26 張莉莉 ----------<<<<<
    }
}
