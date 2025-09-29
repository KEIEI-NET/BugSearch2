using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 得意先実績修正DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先実績修正DB RemoteObjectインターフェース</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.04.20</br>
	/// <br></br>
	/// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2008.06.02</br>
	    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustRsltUpdDB
	{
		/// <summary>
		/// 指定された得意先売掛金額マスタのデータを戻します
		/// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="retObj">得意先売掛金額マスタList</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先売掛金額マスタのデータを戻します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.20</br>
		int SearchAccRec(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// 指定された得意先請求金額マスタのデータを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="retObj">得意先請求金額マスタList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先売掛金額マスタのデータを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        int SearchDmdPrc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

		/// <summary>
        /// 得意先売掛金額マスタ情報を登録、更新します
		/// </summary>
        /// <param name="custAccRecWork">CustAccRecWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を登録、更新します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int WriteAccRec([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork")]ref object custAccRecWork, out string retMsg);

        /// <summary>
        /// 得意先請求金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int WriteDmdPrc([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork")]ref object custDmdPrcWork, out string retMsg);

        /// <summary>
        /// 得意先売掛金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 子レコードと集計レコードの更新を行う</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int WriteTotalAccRec(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object custAccRecWork, out string retMsg);

        /// <summary>
        /// 得意先請求金額マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWorkオブジェクト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 子レコードと集計レコードの更新を行う</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int WriteTotalDmdPrc(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object custDmdPrcWork, out string retMsg);

        /// <summary>
        /// 得意先売掛金額マスタ情報を削除します
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteAccRec(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork")]
            object custAccRecWork);

        /// <summary>
        /// 得意先請求金額マスタ情報を削除します
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteDmdPrc(
            [CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork")]
            object custDmdPrcWork);

        /// <summary>
        /// 得意先売掛金額マスタ情報を削除後、集計レコードを更新します。
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先売掛金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        int DeleteTotalAccRec(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object custAccRecWork);

        /// <summary>
        /// 得意先請求金額マスタ情報を削除後、集計レコードを更新します。
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先請求金額マスタ情報を削除後、集計レコードを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.06.02</br>
        int DeleteTotalDmdPrc(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object custDmdPrcWork);
   	}
}
