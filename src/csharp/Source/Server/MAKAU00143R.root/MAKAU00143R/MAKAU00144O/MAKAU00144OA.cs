using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 支払金額マスタ更新リモーティングインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払金額マスタ更新リモーティングインターフェース</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Update Note: 2012/09/11  FSI佐々木 貴英</br>
    /// <br>           : 仕入総括処理対応 仕入総括形式の支払締処理を追加</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuplierPayDB
    {
        /// <summary>
        /// 仕入先支払金額マスタを更新します
        /// </summary>
        /// <param name="suplierPayUpdateWork">支払処理パラメータ</param>
        /// <param name="updateStatusList">更新有無パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdateWork")]ref object suplierPayUpdateWork, [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdStatusWork")]out object updateStatusList, out string retMsg);

        /// <summary>
        /// 仕入先支払金額マスタを削除します
        /// </summary>
        /// <param name="suplierPayUpdateWork">支払処理パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdateWork")]ref object suplierPayUpdateWork, out string retMsg);

        /// <summary>
        /// 最終支払締履歴を取得します
        /// </summary>
        /// <param name="paraObj">支払締更新履歴マスタパラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        [MustCustomSerialization]
        int ReadHis([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.PaymentAddUpHisWork")]ref object paraObj, out string retMsg);

        /// <summary>
        /// 支払処理結果を取得します
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        [MustCustomSerialization]
        int ReadSuplierPay([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]ref object paraObj, out string retMsg);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// 支払処理結果を取得します
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018　鈴木正臣</br>
        /// <br>Date       : 2007.05.16</br>
        [MustCustomSerialization]
        int ReadSuplierPay( [CustomSerializationMethodParameterAttribute( "MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork" )]ref object paraObj,
                            [CustomSerializationMethodParameterAttribute( "MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork" )]ref object childObj, out string retMsg );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入総括形式で仕入先支払金額マスタを更新します
        /// </summary>
        /// <param name="suplierPayUpdateWork">支払処理パラメータ</param>
        /// <param name="updateStatusList">更新有無パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で仕入先支払金額マスタを更新します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteByAddUpSecCode([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdateWork")]ref object suplierPayUpdateWork, [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayUpdStatusWork")]out object updateStatusList, out string retMsg);

        /// <summary>
        /// 仕入総括形式で支払処理結果を取得する
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で支払処理結果を取得する</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        [MustCustomSerialization]
        int ReadSuplierPayByAddUpSecCode([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]ref object paraObj, out string retMsg);

        /// <summary>
        /// 支払処理結果を取得します
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="childObj">仕入先支払金額マスタ親子レコード格納先</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で支払処理結果を取得する</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        [MustCustomSerialization]
        int ReadSuplierPayByAddUpSecCode([CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]ref object paraObj,
                                         [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]ref object childObj, out string retMsg);
        // --- ADD 2012/09/11 -----------<<<<<
    }
}
