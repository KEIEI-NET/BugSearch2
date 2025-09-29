using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;


namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 自由帳票スキーマグループDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票スキーマグループDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30015　橋本　裕毅</br>
	/// <br>Date       : 2007.05.14</br>
	/// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IFPprSchmGrDB
    {
		/// <summary>
		/// 自由帳票スキーマグループマスタ取得処理（全件の場合）
		/// </summary>
        /// <param name="fPprSchmGrWorkArray">自由帳票グループワークマスタ配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
		/// <param name="dataInputSystemArray">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)配列</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 自由帳票スキーマグループLISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        [MustCustomSerialization]
        int SearchFPprSchmGr([CustomSerializationMethodParameterAttribute("SFTKD08153D", "Broadleaf.Application.Remoting.ParamData.FPprSchmGrWork")]
            out object fPprSchmGrWorkArray, out bool msgDiv, out string errMsg, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystemArray);

		/// <summary>
        /// 自由帳票コンバートマスタ取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCdArray">自由帳票スキーマグループコード配列</param>
		/// <param name="retObj">検索結果CustomSerializeArrayList</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 自由帳票スキーマコンバートマスタ,自由帳票ソート順位初期値マスタ,自由帳票抽出条件初期値マスタのISTを全て戻します</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.14</br>
        [MustCustomSerialization]
        int SearchFPprSchmCv(int freePrtPprItemGrpCd, int[] freePrtPprSchmGrpCdArray, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retObj, out bool msgDiv, out string errMsg);
    
    }

}
