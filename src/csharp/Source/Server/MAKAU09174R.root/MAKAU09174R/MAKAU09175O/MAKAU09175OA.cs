using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ����������p�^�[���ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����������p�^�[���ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDmdPrtPtnSetDB
    {
        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKAU09176D", "Broadleaf.Application.Remoting.ParamData.DmdPrtPtnSetWork")]
			out object retobj,
            object paraobj,
            int readMode, ConstantManagement.LogicalMode logicalMode);
        
        /// <summary>
        /// �w�肳�ꂽ����������p�^�[���ݒ�}�X�^Guid�̐���������p�^�[���ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">BpNameUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ����������p�^�[���ݒ�}�X�^Guid�̐���������p�^�[���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">BpNameUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        int Write(ref byte[] parabyte);

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">BpNameUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// ����������p�^�[���ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="parabyte">BpNameUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        int LogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// �_���폜����������p�^�[���ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="parabyte">BpNameUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜����������p�^�[���ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        int Revival(ref byte[] parabyte);  
    }
}
