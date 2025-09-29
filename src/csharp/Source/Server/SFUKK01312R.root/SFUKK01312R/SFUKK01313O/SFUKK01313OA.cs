using System;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 請求KINGET抽出DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求KINGET抽出DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 18023 樋口　政成</br>
    /// <br>Date       : 2005.07.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISeiKingetDB
    {
		#region 請求金額情報取得Read
		/// <summary>
		/// 請求金額情報取得処理
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="enterpriceCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="readDate">取得日付</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBよりパラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			string enterpriceCode,
			string addUpSecCode,
			int customerCode,
			int readDate);
		#endregion
		
		#region 請求金額情報取得Search
		/// <summary>
		/// 請求金額情報取得処理
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region 請求金額情報取得（元帳）
		/// <summary>
		/// 請求金額情報取得処理
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region 請求金額情報取得（元帳一括）
		/// <summary>
		/// 請求金額情報取得処理(元帳一括印刷用)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int SearchMotoAll(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region 請求金額情報取得（明細）
		/// <summary>
		/// 請求金額明細情報取得処理
		/// </summary>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="objSeiKingetDetailParameterList">明細検索パラメータリスト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 明細検索パラメータリストの条件で請求売上データと入金データを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int SearchDetails(
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			string enterpriseCode,
			object objSeiKingetDetailParameterList);
		#endregion
		
		#region 得意先請求合計残高チェック
		/// <summary>
		/// 得意先請求合計残高チェック処理
		/// </summary>
		/// <param name="enterpriceCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>0:請求合計残高＝０円もしくは取引無し, 1:請求合計残高≠０円</returns>
		/// <br>Note       : 指定得意先コードの得意先請求金額マスタの最終レコードの請求合計残高をチェックします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		int CheckDemandPrice(string enterpriceCode, int customerCode);
		#endregion
	}
}

