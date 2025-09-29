//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���ꗗ�\�i�����j
// �v���O�����T�v   : �x���ꗗ�\�i�����j�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���@���j
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �x���ꗗ�\�i�����jDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���ꗗ�\�i�����jDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : FSI�� ���j</br>
    /// <br>Date       : 2012/09/04</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumPaymentTableDB
    {

        /// <summary>
        /// �x���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012/09/04</br>
        [MustCustomSerialization]
        int SearchPaymentTable([CustomSerializationMethodParameterAttribute("PMKAK02009D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_SumPaymentTotalWork")]out object retObj, object paraObj);

    }
}
