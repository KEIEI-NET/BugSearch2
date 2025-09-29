//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\�i�����j DBRemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c���ꗗ�\�i�����jDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\�i�����jDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : FSI�y�~ �їR��</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumAccPaymentListWorkDB
    {

        /// <summary>
        /// ���|�c���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">��������</param>
        /// <param name=" sumAccPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMKAK02029D", "Broadleaf.Application.Remoting.ParamData.SumAccPaymentListResultWork")]
          out object sumAccPaymentListResultWork, object sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}
