using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自由検索型式検索 RemoteObject インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索型式検索 RemoteObject Interface です。</br>
    /// <br>Programmer : 22018　鈴木正臣</br>
    /// <br>Date       : 2010/04/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]  // アプリケーションサーバーの接続先を属性で指示
    public interface IFreeSearchModelSearchDB
    {
        /// <summary>
        /// 型式検索処理
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarModel( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
			[CustomSerializationMethodParameterAttribute("PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork")]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// 類別型式検索処理
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarCtgyMdl( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// エンジン型式検索処理
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarEngine( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// 自由検索型式固定番号検索処理
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">車両検索条件</param>
        /// <param name="KindList">検索結果(車種リスト)</param>
        /// <param name="carModelRetList">検索結果(型式リスト)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarFullModelNo( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );
    }
}
