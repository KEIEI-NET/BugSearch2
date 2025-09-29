using System;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// リモーティングオブジェクト用インターフェイス
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IOfferAddressInfo
	{
        /// <summary>
        /// 住所情報を取得する通信されるデータには圧縮処理が施されます
        /// </summary>
        /// <param name="paraAddressWork"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddressWork(AddressWork paraAddressWork, [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retList);

        /// <summary>
        /// 住所情報を取得します。
        /// </summary>
        /// <param name="addrIndex"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetAddressWork(AddressWork addrIndex,
            [CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddressWork")]out object alResult);
				
        /// <summary>
        /// 全住所マスタ更新管理マスタを取得する
        /// </summary>
        /// <param name="objAddrUpdMngList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddrUpdMng([CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddrUpdMngWork")]out object objAddrUpdMngList);

        /// <summary>
        /// 住所マスタ住所コードインデックスマスタと住所マスタ郵便番号インデックスマスタを取得する
        /// </summary>
        /// <param name="objAddrCdIndxList"></param>
        /// <param name="objPostNoIndxList"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int SearchAddrCdIndxAndPostNoIndx([CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.AddrCdIndxWork")]out object objAddrCdIndxList, [CustomSerializationMethodParameterAttribute("SFTKD00424D", "Broadleaf.Application.Remoting.ParamData.PostNoIndxWork")]out object objPostNoIndxList);

	}
}
