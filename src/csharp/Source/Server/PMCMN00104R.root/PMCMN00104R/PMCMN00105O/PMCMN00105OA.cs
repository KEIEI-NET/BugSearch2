using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// 締日算出モジュールDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 締日算出モジュールDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22018 鈴木 正臣</br>
	/// <br>Date       : 2008.07.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITtlDayCalcDB
    {
        # region [履歴]
        /// <summary>
        /// 履歴・月次　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisMonthly(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// 履歴・請求　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisDmdC(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// 履歴・支払　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisPayment(
            out object retWorkList,
            object paraWork );
        # endregion

        # region [金額]
        /// <summary>
        /// 金額・月次売掛　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcMonthlyAccRec(
            out object retWorkList,
            object paraWork);
        /// <summary>
        /// 金額・月次買掛　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcMonthlyAccPay(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// 金額・請求　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcDmdC(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// 金額・支払　Search
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <param name="paraWork">条件Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcPayment(
            out object retWorkList,
            object paraWork );
        # endregion
    }
}
