using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������ԕ\���[���ݒ�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ԕ\���[���ݒ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface ISyncStateDspTermStDB
    {
        /// <summary>
        /// ������ԕ\���[���ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="warehouseWork">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object warehouseWork
            );

        /// <summary>
        /// ������ԕ\���[���ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        int Delete(object paraobj);

        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraObj">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object paraObj
            );

        /// <summary>
        /// �_���폜������ԕ\���[���ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraObj">SyncStateDspTermStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜������ԕ\���[���ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork")]
			ref object paraObj
            );
    }
}
