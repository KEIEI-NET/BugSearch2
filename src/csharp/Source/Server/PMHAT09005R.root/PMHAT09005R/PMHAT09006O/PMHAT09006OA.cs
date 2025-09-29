//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����_�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.08</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderPointStDB
    {
        /// <summary>
        /// �����_�ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">��������</param>
        /// <param name="paraOrderPointStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^�̃L�[�l����v����A�S�Ă̔����_�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
                  out object outOrderPointStList, object paraOrderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����_�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStList">OrderPointWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);

        /// <summary>
        /// �����_�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStList">OrderPointWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����_�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);

        /// <summary>
        /// �_���폜�����_�ݒ�}�X�^�����𕜊����܂�
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�����_�ݒ�}�X�^�����𕜊����܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object objOrderPointStList);

        /// <summary>
        /// �����_�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="orderPointStList">OrderPointWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);
    }
}
