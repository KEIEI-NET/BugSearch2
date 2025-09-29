//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �\���敪�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPriceSelectSetWorkDB
    {
        /// <summary>
        /// �\���敪�}�X�^�����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="priceSelectSetCndtnWork">��������</param>
        /// <param name="priceSelectSetResultWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �\���敪�}�X�^�����LIST��S�Ė߂��܂��i�_���폜�����j�B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN08727D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetResultWork")]
            out object priceSelectSetResultWork,
            object priceSelectSetCndtnWork,
            ConstantManagement.LogicalMode logicalMode);
    }
}
