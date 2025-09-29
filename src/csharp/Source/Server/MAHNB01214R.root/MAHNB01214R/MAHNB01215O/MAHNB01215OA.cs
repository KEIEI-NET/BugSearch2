using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 請求売上データREADDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求売上データREADDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 18322 T.Kimura</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IClaimSalesReadDB
	{
        #region ノンカスタムシリアライズ
        /// <summary>
        /// 指定された企業コードの請求売上データREADLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        int Search(out byte[]                         searchClaimSalesWork
                  ,    object                         searchParaClaimSalesRead
                  ,    int                            readMode
                  ,    ConstantManagement.LogicalMode logicalMode
                  );


        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        int SearchCus(out byte[]                         searchClaimSalesWork
                     ,    object                         searchParaClaimSalesRead
                     ,    int                            readMode
                     ,    ConstantManagement.LogicalMode logicalMode
                     );

        /// <summary>
        /// 指定された企業コードの請求売上データREADLIST＋得意先締情報を全て戻します
        /// </summary>
        /// <param name="parabyte">検索結果</param>
        /// <param name="enterpriseCode">検索パラメータ(企業コード)</param>
        /// <param name="acceptAnOrderNo">検索パラメータ(受注番号)</param>
        /// <param name="claimCode">検索パラメータ(請求先コード)</param>
        /// <param name="demandAddUpSecCd">検索パラメータ(請求計上拠点コード)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        int ReadCus(ref byte[]                         parabyte
                   ,    string                         enterpriseCode
                   ,    int                            acceptAnOrderNo
                   ,    int                            claimCode
                   ,    string                         demandAddUpSecCd
                   ,    ConstantManagement.LogicalMode logicalMode
                   );
		#endregion

		#region カスタムシリアライズ

        /// <summary>
        /// 請求売上データREADLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        int Search(
             [CustomSerializationMethodParameterAttribute("MAHNB01216D","Broadleaf.Application.Remoting.ParamData.SearchClaimSalesWork")]
             out object                         searchClaimSalesWork
            ,    object                         searchParaClaimSalesRead
            ,    int                            readMode
            ,    ConstantManagement.LogicalMode logicalMode
            );


        /// <summary>
        /// 請求売上READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="searchClaimSalesWork">検索結果</param>
        /// <param name="searchParaClaimSalesRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.19</br>
        int SearchCus(
             [CustomSerializationMethodParameterAttribute("MAHNB01216D","Broadleaf.Application.Remoting.ParamData.SearchClaimSalesWork")]
             out object                         searchClaimSalesWork
            ,    object                         searchParaClaimSalesRead
            ,    int                            readMode
            ,    ConstantManagement.LogicalMode logicalMode
            );
		#endregion
	}

}
