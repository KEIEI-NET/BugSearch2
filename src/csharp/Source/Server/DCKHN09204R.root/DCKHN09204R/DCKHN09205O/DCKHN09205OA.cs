using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSalesTargetDB
    {
        /// <summary>
        /// �w�肳�ꂽ���Ӑ�ʔ���ڕW�ݒ�}�X�^Guid�̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���Ӑ�ʔ���ڕW�ݒ�}�X�^Guid�̓��Ӑ�ʔ���ڕW�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="custSalesTargetWork">��������</param>
        /// <param name="paracustSalesTargetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			out object custSalesTargetWork,
            object paracustSalesTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );

        /// <summary>
        /// �_���폜���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���Ӑ�ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
			ref object custSalesTargetWork
            );
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWork�I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">CustSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork")]
            ref object custSalesTargetWork,
            byte[] parabyte
            );
        #endregion
        // ---ADD 2010/12/20---------<<<<<
    }
}
