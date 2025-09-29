using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先実績修正DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先実績修正DB RemoteObjectインターフェース</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.25</br>
    /// <br></br>
    /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppRsltUpdDB
    {
        /// <summary>
        /// 指定された仕入先買掛金額マスタのデータを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="retObj">仕入先買掛金額マスタList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入先買掛金額マスタのデータを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        int SearchAccPay(string enterpriseCode, string sectionCode, int payeeCode, int supplierCd, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// 指定された仕入先支払金額マスタのデータを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="resultsSectCd">実績拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="retObj">仕入先支払金額マスタList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入先支払金額マスタのデータを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 長内 DC.NS用に修正</br>
        int SearchSuplierPay(string enterpriseCode, string sectionCode, int payeeCode, string resultsSectCd, int supplierCd, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// 仕入先買掛金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先買掛金額マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        [MustCustomSerialization]
        int WriteAccPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]
            ref object suplAccPayWork, out string retMsg);

        /// <summary>
        /// 仕入先支払金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先支払金額マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.25</br>
        [MustCustomSerialization]
        int WriteSuplierPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]
            ref object suplierPayWork, out string retMsg);


        /// <summary>
        /// 仕入先買掛金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 子レコードと集計レコードの更新を行う</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.25</br>
        [MustCustomSerialization]
        int WriteTotalAccPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object suplAccPayWork, out string retMsg);

        /// <summary>
        /// 仕入先支払金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 子レコードと集計レコードの更新を行う</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.25</br>
        [MustCustomSerialization]
        int WriteTotalSuplierPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object suplierPayWork, out string retMsg);

        /// <summary>
        /// 仕入先買掛金額マスタ情報を削除します
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先買掛金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteAccPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]
            object suplAccPayWork);

        /// <summary>
        /// 仕入先支払金額マスタ情報を削除します
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先支払金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteSuplierPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]
            object suplierPayWork);

        /// <summary>
        /// 仕入先買掛金額マスタ情報を削除後、集計レコードを更新します。
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先買掛金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.25</br>
        int DeleteTotalAccPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object suplAccPayWork);

        /// <summary>
        /// 仕入先支払金額マスタ情報を削除後、集計レコードを更新します。
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先支払金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.25</br>
        int DeleteTotalSuplierPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object suplierPayWork);
        
    }
}
