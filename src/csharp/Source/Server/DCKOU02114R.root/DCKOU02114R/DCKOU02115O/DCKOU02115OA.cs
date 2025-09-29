using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �d�����񌎕�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����񌎕�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21112�@�v�ۓc�@��</br>
	/// <br>Date       : 2007.09.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockDayMonthReportDB
	{
		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �d�����񌎕�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockDayMonthReportDataWork">��������</param>
		/// <param name="parastockDayMonthReportWork">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21112�@�v�ۓc�@��</br>
		/// <br>Date       : 2007.09.06</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU02116D", "Broadleaf.Application.Remoting.ParamData.StockDayMonthReportDataWork")]
			out object stockDayMonthReportDataWork,
			object parastockDayMonthReportWork);
		#endregion
	}
}
