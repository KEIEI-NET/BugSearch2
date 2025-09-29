//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���q�ʏo�׎��ѕ\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�ʏo�׎��ѕ\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.09.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface ICarShipResultDB
    {
        /// <summary>
        /// ���q�ʏo�׎��ѕ\��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="carShipResultWork">��������</param>
        /// <param name="carShipRsltCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02009D", "Broadleaf.Application.Remoting.ParamData.CarShipResultWork")]
            out object carShipResultWork,
          object carShipRsltCndtnWork);

    }
}
