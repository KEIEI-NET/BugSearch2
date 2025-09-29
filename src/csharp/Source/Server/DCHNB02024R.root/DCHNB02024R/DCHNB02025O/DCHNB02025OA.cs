using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �󒍏o�׊m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �󒍏o�׊m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 980081�@�R�c ���F</br>
	/// <br>Date       : 2007.10.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IOrderConfDB
	{

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �󒍏o�׊m�F�\(���v)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="orderConfWork">��������</param>
        /// <param name="paraOrderConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        [MustCustomSerialization]
        int SearchSlip(
            [CustomSerializationMethodParameterAttribute("DCHNB02026D", "Broadleaf.Application.Remoting.ParamData.OrderConfWork")]
			out object orderConfWork,
            object paraOrderConfWork);

        /// <summary>
        /// �󒍏o�׊m�F�\(���ׁE�ڍ�)LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="orderConfWork">��������</param>
        /// <param name="paraOrderConfWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.10.19</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("DCHNB02026D", "Broadleaf.Application.Remoting.ParamData.OrderConfWork")]
			out object orderConfWork,
            object paraOrderConfWork);
        #endregion
	}
}
