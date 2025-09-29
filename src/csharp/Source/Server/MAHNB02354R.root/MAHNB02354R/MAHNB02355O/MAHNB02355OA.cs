using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ����m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 20098�@�����@����</br>
	/// <br>Date       : 2007.03.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISalesConfDB
	{

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// ����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="salesConfWork">��������</param>
		/// <param name="parasalesConfWork">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20098�@�����@����</br>
		/// <br>Date       : 2007.03.19</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAHNB02356D","Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
			object parasalesConfWork);

        /// <summary>
        /// ����m�F�\(���v)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="salesConfWork">��������</param>
        /// <param name="paraSalesConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        [MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
            object paraSalesConfWork);

        /// <summary>
        /// ����m�F�\(���ׁE�ڍ�)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="salesConfWork">��������</param>
        /// <param name="paraSalesConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.18</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork")]
			out object salesConfWork,
            object paraSalesConfWork);
        #endregion
	}
}
