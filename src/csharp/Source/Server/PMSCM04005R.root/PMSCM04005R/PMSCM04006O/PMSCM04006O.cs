using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// SCM�₢���킹�ꗗDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM�₢���킹�ꗗDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2009.05.14</br>
	/// <br></br>
    /// <br>Update Note: SCM�����[�X�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/04/13</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMInquiryDB
	{
        
        /// <summary>
        /// SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="scmInquiryResultWork">��������</param>
        /// <param name="scmInquiryOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object scmInquiryResultWork,
            object scmInquiryOrderWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�L�����Z���ȊO�A�L�����Z�����̂����ꂩ�j
		/// </summary>
        /// <param name="scmInquiryResultWork">��������</param>
        /// <param name="scmInquiryOrderWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        [MustCustomSerialization]
        int SearchDetail(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWork,
            object objscmInquiryResultWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        // -- ADD 2010/04/13 ----------------------------------->>>
        /// <summary>
        /// SCM�₢���킹�ꗗLIST��S�Ė߂��܂��i�L�����Z���ȊO���A�L�����Z�����̗����j
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        /// <param name="scmInquiryResultWorkCancel"></param>
        /// <param name="objscmInquiryResultWork"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchDetailAll(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object scmInquiryResultWorkCancel,
            object objscmInquiryResultWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        // -- ADD 2010/04/13 -----------------------------------<<<


        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ�̌�����߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="readCnt">���o����</param>
        /// <param name="supplierUnmOrderCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h��SCM�₢���킹�ꗗ������߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009.05.14</br>
        int SearchCnt(out int readCnt, object objscmInquiryOrderWork);
    }

}
