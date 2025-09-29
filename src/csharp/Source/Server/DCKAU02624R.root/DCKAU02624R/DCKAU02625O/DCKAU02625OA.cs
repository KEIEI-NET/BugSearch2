using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���|����ō��ٕ\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���|����ō��ٕ\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 980081�@�R�c ���F</br>
	/// <br>Date       : 2007.11.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IAccRecConsTaxDiffDB
	{

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���|����ō��ٕ\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="accRecConsTaxDiffWork">��������</param>
        /// <param name="paraAccRecConsTaxDiffWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        [MustCustomSerialization]
        int SearchAccRecConsTaxDiffProc(
            [CustomSerializationMethodParameterAttribute("DCKAU02626D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecConsTaxDiffWork")]
			out object accRecConsTaxDiffWork,
            object paraAccRecConsTaxDiffWork);
        #endregion
	}
}
