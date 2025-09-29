using System;
using System.Collections;
using Broadleaf.Library.Resources;
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
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]  // アプリケーションサーバーの接続先を属性で指示
    public interface ICarModelCtlDB
    {

		/// <summary>
		/// エンジン型式検索
		/// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarEngine(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork
			);

        /// <summary>
        /// 型式検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <returns></returns>
		[MustCustomSerialization]
		int GetCarModel(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork
			);

		/// <summary>
		/// 類別型式検索メソッド
		/// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarCtgyMdl(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out ArrayList categoryEquipmentRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork")]
            out ArrayList equipmentRetWork
			);

		/// <summary>
		/// コーションプレート検索メソッド
		/// </summary>
        /// <param name="carModelCondWork">車両検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarPlate(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork
			);

        /// <summary>
        /// フル型式固定番号検索メソッド
        /// </summary>
        /// <param name="carModelCondWork">検索条件</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <param name="kindList">車両型式</param>
        /// <param name="colorCdRetWork">カラーコード</param>
        /// <param name="trimCdRetWork">トリムコード</param>
        /// <param name="cEqpDefDspRetWork">装備コード</param>
        /// <param name="prdTypYearRetWork">年式</param>
        /// <param name="ctgyMdlLnkRetWork">ＴＢＯ</param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetCarFullModelNo(CarModelCondWork carModelCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
            out ArrayList carModelRetList,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
            out ArrayList kindList,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out ArrayList categoryEquipmentRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork")]
            out ArrayList equipmentRetWork
            );
	}
}
