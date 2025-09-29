//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g�ꗗ�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����_�ݒ�}�X�^���X�g�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^���X�g�ꗗ�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.03.27</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderSetMasListDB
    {

        /// <summary>
        /// �����_�ݒ�}�X�^���X�g�ꗗ�\LIST��S�Ė߂��܂��_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="orderSetMasListWork">��������</param>
        /// <param name="orderSetMasListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �S�Ĉꌳ���z�M����̃f�[�^�̎擾�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHAT02029D", "Broadleaf.Application.Remoting.ParamData.OrderSetMasListWork")]
            out object orderSetMasListWork, ref object orderSetMasListParaWork);
    }
}

