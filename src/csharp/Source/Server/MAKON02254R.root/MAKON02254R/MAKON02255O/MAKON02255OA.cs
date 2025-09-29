using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �d���m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 20098�@�����@����</br>
	/// <br>Date       : 2007.03.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockConfDB
	{
        /// <summary>
		/// �d���m�F�\(����)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockConfWork">��������</param>
		/// <param name="parastockConfWork">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20098�@�����@����</br>
		/// <br>Date       : 2007.03.19</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKON02256D","Broadleaf.Application.Remoting.ParamData.StockConfWork")]
			out object stockConfWork,
			object parastockConfWork);

        /// <summary>
        /// �d���m�F�\(�`�[)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockConfSlipTtlWork">��������</param>
        /// <param name="parastockConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.12.19</br>
        [MustCustomSerialization]
        int SearchSlipTtl(
            [CustomSerializationMethodParameterAttribute("MAKON02256D","Broadleaf.Application.Remoting.ParamData.StockConfSlipTtlWork")]
			out object stockConfSlipTtlWork,
            object parastockConfWork);
	}
}
