using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// d“ü“`•[î•ñ RemoteObjectƒCƒ“ƒ^[ƒtƒF[ƒX
	/// </summary>
	/// <remarks>
    /// <br>Note       : d“ü“`•[î•ñ RemoteObject Interface‚Å‚·B</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.06.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcDataRefListWorkDB
	{
		/// <summary>
		/// d“ü“`•[î•ñList‚ğæ“¾‚·‚é(˜_—íœœ‚­)
		/// </summary>
		/// <param name="stcDataRefListWork">ŒŸõŒ‹‰Ê(“`•[)</param>
		/// <param name="stcDtlDataRefListWork">ŒŸõŒ‹‰Ê(“`•[–¾×)</param>
		/// <param name="enterpriseCode">Šé‹ÆƒR[ƒh</param>
		/// <param name="supplierFomal">d“üŒ`®</param>
		/// <param name="supplierSlipNo">d“ü“`•[”Ô†</param>
		/// <param name="readMode">ŒŸõ‹æ•ª</param>
		/// <param name="logicalMode">˜_—íœ—L–³(0:³‹KÃŞ°À‚Ì‚İ 1:íœÃŞ°À‚Ì‚İ 2:•Û—¯ÃŞ°À‚Ì‚İ 3:Š®‘SíœÃŞ°À‚Ì‚İ 4:‘SŒ 5:³‹KÃŞ°À+íœÃŞ°À 6:³‹KÃŞ°À+íœÃŞ°À+•Û—¯ÃŞ°À)</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : “`•[î•ñList‚ğæ“¾‚·‚é</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.06.06</br>
		/// </remarks>
        // « 2007.12.04 980081 c
		//[MustCustomSerialization]
		//int Read(
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork")]
		//	out object stcDataRefListWork,
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork")]
		//	out object stcDtlDataRefListWork,
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcExDataRefWork")]
		//	out object stcExDataRefListWork,
		//	string enterpriseCode,
		//	int supplierFomal,
		//	int supplierSlipNo,
		//	int readMode,
		//	ConstantManagement.LogicalMode logicalMode);
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork")]
			out object stcDataRefListWork,
            [CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork")]
			out object stcDtlDataRefListWork,
            string enterpriseCode,
            int supplierFomal,
            int supplierSlipNo,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // ª 2007.12.04 980081 c

	}
}
