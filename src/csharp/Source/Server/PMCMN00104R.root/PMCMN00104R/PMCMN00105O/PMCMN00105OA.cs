using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// �����Z�o���W���[��DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����Z�o���W���[��DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2008.07.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITtlDayCalcDB
    {
        # region [����]
        /// <summary>
        /// �����E�����@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisMonthly(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// �����E�����@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisDmdC(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// �����E�x���@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchHisPayment(
            out object retWorkList,
            object paraWork );
        # endregion

        # region [���z]
        /// <summary>
        /// ���z�E�������|�@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcMonthlyAccRec(
            out object retWorkList,
            object paraWork);
        /// <summary>
        /// ���z�E�������|�@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcMonthlyAccPay(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// ���z�E�����@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcDmdC(
            out object retWorkList,
            object paraWork );
        /// <summary>
        /// ���z�E�x���@Search
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <param name="paraWork">����Work</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchPrcPayment(
            out object retWorkList,
            object paraWork );
        # endregion
    }
}
