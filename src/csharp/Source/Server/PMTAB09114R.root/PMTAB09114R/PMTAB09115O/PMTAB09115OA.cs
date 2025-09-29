using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�S�̐ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�S�̐ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface IPmTabTtlStCustDB
    {

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="PmTabTtlStCustWork">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork")]
			ref object PmTabTtlStCustWork
            );


        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork")]
            object paraobj);

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraObj">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�S�̐ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork")]
			ref object paraObj
            );

        /// <summary>
        /// �_���폜PMTAB�S�̐ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraObj">PmTabTtlStCustWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜PMTAB�S�̐ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09116D", "Broadleaf.Application.Remoting.ParamData.PmTabTtlStCustWork")]
			ref object paraObj
            );
    }
}
