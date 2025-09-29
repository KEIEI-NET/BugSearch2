using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// 支払確認表DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払確認表DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 980081 山田 明友</br>
	/// <br>Date       : 2007.09.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPaymentListWorkDB
	{
		/// <summary>
        /// 支払確認表(抜粋・詳細)LISTを戻します
		/// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(抜粋・詳細)</param>
        /// <param name="paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 980081 山田 明友</br>
		/// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
		int SearchDepsitOnly(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
            out object paymentSlpListResultWork,
            object paymentSlpCndtnWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);


        /// <summary>
        /// 支払確認表(金種別集計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(金種別集計)</param>
        /// <param name="paymentSlpCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
        int SearchDepsitKind(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
            out object paymentSlpListResultWork,
            object paymentSlpCndtnWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        // 2008/07/07 DEL-Start ※7/8レビューで総合計は不要となった -------------- >>>>>
        #region 総合計タイプは削除
        /*
        /// <summary>
        /// 支払確認表(総合計)LISTを戻します
        /// </summary>
        /// <param name="paymentSlpListResultWork">検索結果(総合計)</param>
        /// <param name="paymentSlpListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sectionDepositDiv">sectionDepositDiv</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
        int SearchAllTotal(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
			out object paymentSlpListResultWork,
            object paymentSlpListCndtnWork,
            int readMode,
            int sectionDepositDiv,
            ConstantManagement.LogicalMode logicalMode);
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<
    }
}
