using System;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 得意先検索 RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先検索 RemoteObject Interfaceです。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
    /// <br>Update Note: MANTIS:14720 得意先名検索追加</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2009/12/02</br>
    /// <br>Update Note: 得意先略称表示列と検索追加(#826)</br>
    /// <br>Programmer : PM1107C 徐錦山</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: PM-Tabletの改修</br>
    /// <br>管理番号   :10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustomerSearchDB
	{
		/// <summary>
		/// 指定された条件の得意先LISTを全て戻します
		/// </summary>
		/// <param name="retObj">検索結果</param>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchRetWork")]
			out object retObj,
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork")]
			ref object paraObj,
			CustomerSearchReadMode readMode,
			ConstantManagement.LogicalMode logicalMode);

        // --------------- ADD START 2013/05/29 wangl2 FOR PM-Tablet------>>>>
        /// <summary>
        /// PMTAB得意先検索結果情報を全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork")]
			out object retObj,
            [CustomSerializationMethodParameterAttribute("PMKHN04016D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork")]
			ref object paraObj,
            ConstantManagement.LogicalMode logicalMode);
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<
	}

	/// <summary>
	/// CustomerSearchReadMode
	/// </summary>
    /// <remarks>
    /// <br>Update Note: 電話番号検索追加と伴う修正</br>
    /// <br>Programmer : PM1012A 朱 猛</br>
    /// <br>Date       : 2010/08/06</br>
    /// </remarks>
	public enum CustomerSearchReadMode
	{
		/// <summary>全条件複合検索</summary>
		CustomerSearchMode_All = 0,							// 全条件複合検索（値のあるものを利用）
		/// <summary>得意先コード検索</summary>
		CustomerSearchMode_Customer_Code = 1000,			// 得意先コード検索
		/// <summary>得意先サブコード</summary>
		CustomerSearchMode_Customer_SubCode = 1001,			// 得意先サブコード
		/// <summary>得意先電話番号検索</summary>
		CustomerSearchMode_Customer_Tel = 1002,				// 得意先電話番号検索
		/// <summary>得意先カナ検索</summary>
		CustomerSearchMode_Customer_Kana = 1003,			// 得意先カナ検索
		/// <summary>仕入先区分検索</summary>
		CustomerSearchMode_Customer_SupplierDiv = 1004,		// 仕入先区分検索		// 未使用
		/// <summary>業販先区分検索</summary>
		CustomerSearchMode_Customer_AcceptWholeSale = 1005, // 業販先区分検索		// 未使用
		/// <summary>分析コード1検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode1 = 1006, // 分析コード検索
		/// <summary>分析コード2検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode2 = 1007, // 分析コード検索
		/// <summary>分析コード3検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode3 = 1008, // 分析コード検索
		/// <summary>分析コード4検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode4 = 1009, // 分析コード検索
		/// <summary>分析コード5検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode5 = 1010, // 分析コード検索
		/// <summary>分析コード6検索</summary>
		CustomerSearchMode_Customer_CustAnalysCode6 = 1011, // 分析コード検索
		/// <summary>得意先担当者コード検索</summary>
		CustomerSearchMode_Customer_CustomerAgentCd = 1012, // 得意先担当者コード検索
		/// <summary>得意先区分検索</summary>
		CustomerSearchMode_Customer_CustomerDiv = 1013,		// 得意先区分検索
        /// <summary>管理拠点コード検索</summary>
        CustomerSearchMode_Customer_MngSecCode = 1014,      // 管理拠点コード
        // 2009/12/02 Add >>>
        /// <summary>得意先名検索</summary>
        CustomerSearchMode_Customer_Name = 1015,			// 得意先検索
        // 2009/12/02 Add <<<
        // ---ADD 2010/08/06-------------------->>>
        /// <summary>電話番号検索</summary>
        CustomerSearchMode_Customer_TelNum = 1016,          // 電話番号検索
        // ---ADD 2010/08/06--------------------<<<
        // 2011/7/22 XUJS ADD STA>>>>>>
        CustomerSearchMode_Customer_CustomerSnm = 1017,     //略称
        // 2011/7/22 XUJS ADD END<<<<<<

	}
}
