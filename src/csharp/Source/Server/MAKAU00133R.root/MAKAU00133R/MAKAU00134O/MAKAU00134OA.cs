using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売掛・買掛金額マスタ更新リモーティングインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売掛・買掛金額マスタ更新リモーティングインターフェース</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.05</br>
    /// <br>-------------------------------------------------------------------</br>
    /// <br>Update Note: 最終月次締履歴取得(ReadHis)</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.17</br>
    /// <br>-------------------------------------------------------------------</br>
    /// <br>Update Note: 連番 42 月次更新で、古いデータを削除sの対応</br>
    /// <br>Programmer : zhouyu</br>
    /// <br>Date       : 2011/07/15</br>
    /// <br>-------------------------------------------------------------------</br>
    /// <br>Update Note: 仕入総括処理対応 仕入総括形式の月次更新処理を追加 </br>
    /// <br>Programmer :  FSI佐々木 貴英  </br> 
    /// <br>Date       : 2012/09/13</br>
    /// <br>-------------------------------------------------------------------</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthlyAddUpDB
    {
        /// <summary>
        /// 売掛・買掛金額マスタを更新します(月次更新)
        /// </summary>
        /// <param name="paraObj">月次更新パラメータ</param>
        /// <param name="retObj">月次更新結果Lsit</param>
        /// <param name="msgDiv">エラーメッセージ有無区分</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="monAddUpUpdDiv">月次更新区分→0:売上月次更新,1:仕入月次更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.05</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpWork")]ref object paraObj, [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpStatusWork")]out object retObj, out bool msgDiv, out string retMsg, int monAddUpUpdDiv);

        /// <summary>
        /// 売掛・買掛金額マスタを削除します(月次締取消)
        /// </summary>
        /// <param name="paraObj">月次締取消パラメータ</param>
        /// <param name="retObj">月次締取消結果List</param>
        /// <param name="msgDiv">エラーメッセージ有無区分</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="monAddUpUpdDiv">月次更新区分→0:売上月次更新,1:仕入月次更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.05</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpWork")]ref object paraObj, [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpStatusWork")]out object retObj, out bool msgDiv, out string retMsg, int monAddUpUpdDiv);

        /// <summary>
        /// 最終月次締履歴を取得します
        /// </summary>
        /// <param name="paraObj">月次締更新履歴マスタパラメータ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.21</br>
        int ReadHis([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpHisWork")]ref object paraObj, out string retMsg);

        /// <summary>
        /// 月次処理結果を取得します（売掛金額マスタ）
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.21</br>
        [MustCustomSerialization]
        int ReadCustAccRec([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork")]ref object paraObj, out string retMsg);

        /// <summary>
        /// 月次処理結果を取得します（買掛金額マスタ）
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.21</br>
        [MustCustomSerialization]
        int ReadSuplAccPay([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]ref object paraObj, out string retMsg);

        //ADD START zhouyu 2011/07/15 FOR 連番 42
        /// <summary>
        /// 古いデータを削除します
        /// </summary>
        /// <param name="paraObj">古いデータパラメータ</param>
        /// <param name="msgDiv">エラーメッセージ有無区分</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="monAddUpUpdDiv">月次更新区分→0:売上月次更新,1:仕入月次更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011.07.11</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpWork")]ref object paraObj, out bool msgDiv, out string retMsg, int monAddUpUpdDiv);
        //ADD END zhouyu 2011/07/15 FOR 連番 42

        // --- ADD 2012/09/13 ----------->>>>>
        /// <summary>
        /// 仕入総括形式で売掛・買掛金額マスタを更新します。
        /// </summary>
        /// <param name="paraObj">月次更新パラメータ</param>
        /// <param name="retObj">月次更新結果Lsit</param>
        /// <param name="msgDiv">エラーメッセージ有無区分</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="monAddUpUpdDiv">月次更新区分→0:売上月次更新,1:仕入月次更新</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で仕入月次更新処理を行います</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/13</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteByAddUpSecCode([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpWork")]ref object paraObj, [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpStatusWork")]out object retObj, out bool msgDiv, out string retMsg, int monAddUpUpdDiv);

        /// <summary>
        /// 月次処理結果を取得する（買掛金額マスタ）
        /// </summary>
        /// <param name="paraObj">仕入先買掛金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で月次処理結果を取得する（買掛金額マスタ）</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/13</br>
        /// </remarks>
        [MustCustomSerialization]
        int ReadSuplAccPayByAddUpSecCode([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]ref object paraObj, out string retMsg);
        // --- ADD 2012/09/13 -----------<<<<<
    }
}
