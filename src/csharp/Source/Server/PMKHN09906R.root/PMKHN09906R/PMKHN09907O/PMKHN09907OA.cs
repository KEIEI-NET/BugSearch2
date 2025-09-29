//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fcaohh
// �C����    2013/02/19     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���ꊇ�o�^�E�C���UDBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ꊇ�o�^�E�C���UDBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2013/02/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface IRate2DB
    {
        /// <summary>
        /// �|���}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="Rate2Work">RateMtWork�I�u�W�F�N�g</param>
        /// <param name="eFlag">�V�ǉ��s�t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
			ref object Rate2Work,
            bool eFlag
            );

        /// <summary>
        /// �|���}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">RateMtWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2013/02/19</br>
        int DeleteRate(byte[] parabyte);

        /// <summary>
        /// �����f�[�^�̊|���ꊇ��������
        /// </summary>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        [MustCustomSerialization]
        int SearchPureRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retGoodsMngList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �D�ǃf�[�^�̊|���ꊇ��������
        /// </summary>
        /// <param name="retPrmSettingList">�D�ǐݒ��񃊃X�g</param>
        /// <param name="retGoodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/03/01</br>
        [MustCustomSerialization]
        int SearchPrmRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retPrmSettingList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2SearchResultWork")]
			out object retGoodsMngList,
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �P�ꏤ�i���̊|����������
        /// </summary>
        /// <param name="retRateList">�|����񃊃X�g</param>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>Date       : 2013/04/03</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09908D", "Broadleaf.Application.Remoting.ParamData.Rate2Work")]
            out object retRateList,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}
