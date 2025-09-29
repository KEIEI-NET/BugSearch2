using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 得意先電子元帳 DBRemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先電子元帳　DBRemoteObjectインターフェースです。</br>
	/// <br>Programmer : 23015 森本 大輝</br>
	/// <br>Date       : 2008.07.30</br>
	/// <br></br>
	/// <br>Update Note: 神姫産業-与信調査 対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2013/03/13</br>
    /// <br>Update Note: 2015/02/05 王亜楠</br>
    /// <br>           : テキスト出力件数制限なしモードの追加</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustPrtPprWorkDB
	{
        /// <summary>
        /// 得意先電子元帳 残高照会・伝票表示・明細表示のリストを抽出します
		/// </summary>
        /// <param name="custPrtPprBlDspRsltWork">検索結果(残高照会)</param>
        /// <param name="custPrtPprSalTblRsltWork">検索結果(売上データ)</param>
        /// <param name="custPrtPprWork">検索パラメータ</param>
        /// <param name="recordCount">検索結果(件数)</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        [MustCustomSerialization]
        int SearchRef(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlDspRsltWork")]
            ref object custPrtPprBlDspRsltWork,
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork")]
            ref object custPrtPprSalTblRsltWork,
            object custPrtPprWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// 得意先電子元帳 残高一覧表示のリストを抽出します
        /// </summary>
        /// <param name="custPrtPprBlTblRsltWork">検索結果</param>
        /// <param name="custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.30</br>
        [MustCustomSerialization]
        int SearchBlTbl(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork")]
			ref object custPrtPprBlTblRsltWork,
            object custPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        // ADD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
        /// <summary>
        /// 得意先電子元帳 残高一覧表示（与信残高出力用）のリストを抽出します
        /// </summary>
        /// <param name="custPrtPprBlTblOutputRsltWork">検索結果</param>
        /// <param name="custPrtPprBlnceWork">検索パラメータ</param>
        /// <param name="SrchKndDiv">検索種別 0:請求 1:売掛</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30744 湯上 千加子</br>
        /// <br>Date       : 2013/03/13</br>
        [MustCustomSerialization]
        int SearchBlTblOutput(
            [CustomSerializationMethodParameterAttribute("PMKAU04016D", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork")]
			ref object custPrtPprBlTblRsltWork,
            object custPrtPprBlnceWork,
            int SrchKndDiv,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            bool CreditMng
            );

        // ADD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        /// <summary>
        /// 売上伝票読み込み処理（履歴含む）
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retList"></param>
        /// <param name="retRelationList"></param>
        /// <returns></returns>
        int ReadSalesSlip(
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object paraList,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            out object retList,
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            out object retRelationList,
            int readMode
            );
        /// <summary>
        /// 相手先伝票番号による仕入データの検索を行います。
        /// </summary>
        /// <param name="retStockSlipList">検索結果を格納する CustomSerializeArrayList を指定します。</param>
        /// <param name="paraStockSlip">検索条件を格納した StockSlip を指定します。</param>
        /// <param name="mode">0:完全一致 1:前方一致 2:完全一致＋仕入明細取得</param>
        /// <returns>STATUS</returns>
        int SearchPartySaleSlipNum(
            [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
            ref object retStockSlipList,
            object paraStockSlip,
            int mode );
        /// <summary>
        /// エントリ更新呼び出し
        /// </summary>
        /// <param name="paraList">更新情報オブジェクトリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <param name="retItemInfo">項目情報</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteByIOWriter( [CustomSerializationMethodParameterAttribute( "SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList" )]
                  ref object paraList,
                   out string retMsg, out string retItemInfo );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

        // --- ADD 2012/12/17 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// サーバーシステム日付取得を戻します		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : サーバーシステム日付取得を戻します	</br>
        /// <br>Programmer  : 宮本 利明</br>
        /// <br>Date        : 2012.12.17</br>
        DateTime GetServerNowTime();
        // --- ADD 2012/12/17 T.Miyamoto ------------------------------<<<<<

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>
        /// 売上日が指定されない場合、DBから開始・終了売上日を検索する
        /// </summary>
        /// <param name="salesDateSt">開始売上日</param>
        /// <param name="salesDateEd">終了売上日</param>
        /// <param name="custPrtPprParam">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 売上日が指定されない場合、DBから開始・終了売上日を検索する</br>
        /// <br>Programmer  : 王亜楠</br>
        /// <br>Date        : 2015/02/05</br>
        /// </remarks>
        int GetSalesDate(
            out DateTime salesDateSt, 
            out DateTime salesDateEd, 
            object custPrtPprParam, 
            ConstantManagement.LogicalMode logicalMode);
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
    }
}
