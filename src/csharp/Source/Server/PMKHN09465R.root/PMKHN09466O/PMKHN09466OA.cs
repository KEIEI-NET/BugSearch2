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
    /// <br>Programmer  : ���M</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface ISingleGoodsRateDB
    {  
        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateWork")]
			ref object SingleGoodsRateWork
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
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �|���ݒ�}�X�^�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int SearchRate(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �|���ݒ�
        /// </summary>
        /// <param name="delparaObj">�폜�f�[�^���X�g</param>
        /// <param name="updparaObj">�X�V�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        [MustCustomSerialization]
        int Save(object delparaObj, object updparaObj, ref string message);

        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int WriteCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			ref object SingleGoodsRateWork
            );

        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int WriteCustomerGrp(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
			out object retList, 
            ref object SingleGoodsRateWork
            );

        /// <summary>
        /// �|���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="SingleGoodsRateWork">SingleGoodsRateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �|���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2010/08/10</br>
        [MustCustomSerialization]
        int CustomerAllDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09467D", "Broadleaf.Application.Remoting.ParamData.SingleGoodsRateSearchResultWork")]
            ref object SingleGoodsRateWork
            );


    }
}
