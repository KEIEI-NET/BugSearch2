using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌Ɍ���N��@DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌Ɍ���N��@DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer : 23015 �X�{ ��P</br>
	/// <br>Date       : 2008.07.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMonthYearReportDataWorkDB
	{
        
        /// <summary>
        /// �݌Ɍ���N��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="stockMonthYearReportDataWork">��������</param>
        /// <param name="stockMonthYearReportWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.17</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI02016D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportDataWork")]
			out object stockMonthYearReportDataWork,
            object stockMonthYearReportWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
