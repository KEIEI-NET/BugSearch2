using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �x��READDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x��READDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 99033 ��{�@�E</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IPaymentReadDB
	{
		#region �J�X�^���V���A���C�Y

        /// <summary>
        /// �x��READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paymentDataWork">��������</param>
        /// <param name="searchParaPaymentRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 99033 ��{�@�E</br>
        /// <br>Date       : 2005.08.16</br>
        int Search(
            //[CustomSerializationMethodParameterAttribute("SFSIR02140D","Broadleaf.Application.Remoting.ParamData.PaymentSlpWork")]  //DEL 2008/04/24 M.Kubota
            [CustomSerializationMethodParameterAttribute("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork")]  //ADD 2008/04/24 M.Kubota
            //out object paymentMainWork,  //DEL 2008/04/24 M.Kubota
            out object paymentDataWork,    //ADD 2008/04/24 M.Kubota
            object searchParaPaymentRead,
            int readMode,ConstantManagement.LogicalMode logicalMode);

		#endregion
	}
}
