using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 自由検索部品取得DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由検索部品取得 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/06 湯上 千加子</br>
    /// <br>管理番号   : </br>
    /// <br>           : SCM仕掛一覧№10632対応</br>
    /// </remarks>
    [APServerTarget( ConstantManagement_SF_PRO.ServerCode_UserAP )]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IFreeSearchPartsSearchDB
    {
        /// <summary>
        /// 自由検索部品マスタ検索
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
                FreeSearchPartsSParaWork inPara,
                [CustomSerializationMethodParameterAttribute( "PMJKN06013D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsSRetWork" )]
                ref object retInf,
                out long retCnt );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品マスタ検索
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
                ArrayList inPara,
                ref object retInf,
                out long retCnt);
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<
    }
}
