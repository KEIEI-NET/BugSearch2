using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車両型式検索 RemoteObject インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両型式検索 RemoteObject Interface です。</br>
    /// <br>Programmer : 96186　立花　裕輔</br>
    /// <br>Date       : 2007.03.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]  // アプリケーションサーバーの接続先を属性で指示
    public interface ICarModelSearchDB
    {
        /// <summary>
        /// 車種検索処理＜型式検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindModel(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// 車種検索処理＜エンジン型式検索＞
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindEngine(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// 車種検索処理＜類別型式検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindCtgyMdl(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// 車種検索処理＜プレート検索＞
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindlPlate(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// エンジン型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarEngineSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// 型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarModelSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// 類別型式検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarCtgyMdlSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// プレート検索処理
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarPlateSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);
	}
}
