using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 請求金額マスタ更新リモーティングインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求金額マスタ更新リモーティングインターフェース</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustDmdPrcDB
    {
        /// <summary>
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">請求準備処理パラメータ</param>
        /// <param name="updateStatusList">得意先請求金額マスタ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.14</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdateWork")]ref object custDmdPrcUpdateWork, [CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdStatusWork")]out object updateStatusList, out string retMsg);

        /// <summary>
        /// 得意先請求金額マスタを削除します
        /// </summary>
        /// <param name="custDmdPrcUpdParam">請求準備処理パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.14</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcUpdateWork")]ref object custDmdPrcUpdParam, out string retMsg);

        /// <summary>
        /// 最終請求締履歴を取得します
        /// </summary>
        /// <param name="paraObj">請求締更新履歴マスタパラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        [MustCustomSerialization]
        int ReadHis([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.DmdCAddUpHisWork")]ref object paraObj, out string retMsg);

        /// <summary>
        /// 請求準備処理結果を取得します
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        [MustCustomSerialization]
        int ReadCustDmdPrc([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork")]ref object paraObj, out string retMsg);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
        /// <summary>
        /// 請求準備処理結果を取得します
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="childObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2009.02.23</br>
        [MustCustomSerialization]
        int ReadCustDmdPrc( [CustomSerializationMethodParameterAttribute( "MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork" )]ref object paraObj, [CustomSerializationMethodParameterAttribute( "MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork" )]ref object childObj, out string retMsg );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
    }
}
