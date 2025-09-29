using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 96050  ����@����</br>
    /// <br>Date       : 2007.10.16</br>
    /// <br>Update Note: PM-TAB�Ή��̒ǉ�</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/06/13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface IRateDB
    {
        /// <summary>
        /// �w�肳�ꂽ�|���ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">RateWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̊|���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="RateWork">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object RateWork
            );


        /// <summary>
        /// �|���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// �|���ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        //�@--- ADD hunagt 2013/06/13 PM-TAB�Ή� ---------- >>>>>
        /// <summary>
        /// �|���ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);
        //�@--- ADD hunagt 2013/06/13 PM-TAB�Ή� ---------- <<<<<

        /// <summary>
        /// �|���ݒ�}�X�^��_���폜���܂�
        /// </summary>
        /// <param name="paraObj">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object paraObj
            );

        /// <summary>
        /// �_���폜�|���ݒ�}�X�^�𕜊����܂�
        /// </summary>
        /// <param name="paraObj">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�|���ݒ�}�X�^�𕜊����܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
			ref object paraObj
            );

        /// <summary>
        /// �|���ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateSearchResultWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �|���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">RateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 96050  ����@����</br>
        /// <br>Date       : 2007.10.16</br>
        int DeleteRate(byte[] parabyte);

    }
}
