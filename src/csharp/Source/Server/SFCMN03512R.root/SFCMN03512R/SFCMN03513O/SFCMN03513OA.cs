using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員ログイン（Felica対応版） RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員ログイン（Felica対応版） RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23002　上野　耕平</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget("None")]
    public interface IEmployeeLogin2DB
    {
        /// <summary>
        /// 従業員ログイン
        /// </summary>
        /// <param name="accessTicket">アクセスチケット</param>
        /// <param name="iD">FelicaログインID</param>
        /// <param name="password">従業員ログインパスワード</param>
        /// <param name="felicaMode">Felicaログインタイプ</param>
        /// <param name="retCmpObj">企業ログイン情報</param>
        /// <param name="retEmpObj">従業員ログイン情報</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Login(string accessTicket, string iD, string password, bool felicaMode, [CustomSerializationMethodParameterAttribute("SFCMN00654D", "Broadleaf.Application.Remoting.ParamData.CompanyAuthInfoWork")]ref object retCmpObj, [CustomSerializationMethodParameterAttribute("SFCMN00664D", "Broadleaf.Application.Remoting.ParamData.EmployeeAuthInfoWork")]out object retEmpObj, out string retMsg);
    }
}
