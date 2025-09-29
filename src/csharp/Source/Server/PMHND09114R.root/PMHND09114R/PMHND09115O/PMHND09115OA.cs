using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�S�̐ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�S�̐ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 3H �k�P�N</br>
    /// <br>Date       : K2017/06/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IInspectTtlStDB
    {
        /// <summary>
        /// �w�肳�ꂽ���i�S�̐ݒ�}�X�^Guid�̌��i�S�̐ݒ�}�X�^��߂��܂�
        /// </summary>
		/// <param name="parabyte">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���i�S�̐ݒ�}�X�^Guid�̌��i�S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
		/// <param name="parabyte">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���i�S�̐ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
		/// <param name="inspectTtlStWork">��������</param>
		/// <param name="parainspectTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int Search(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			out object inspectTtlStWork,
			object parainspectTtlStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );

        /// <summary>
        /// �_���폜���i�S�̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
		/// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("PMHND09116D","Broadleaf.Application.Remoting.ParamData.InspectTtlStWork")]
			ref object inspectTtlStWork
            );
        #endregion
    }
}
