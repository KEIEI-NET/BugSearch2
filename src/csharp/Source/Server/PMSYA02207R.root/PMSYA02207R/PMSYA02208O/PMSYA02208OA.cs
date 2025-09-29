//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�׎��ѕ\
// �v���O�����T�v   : �^���ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//Update Note : 2010/05/07 ���C�� redmine #7001
//              �^���ʏo�בΉ��\�̎󒍃X�e�[�^�X�ɂ��āA�d�l�̕ύX
//Update Note : 2010/05/07 ���C�� redmine #7109
//              ������i�Ԃ̎擾
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhshh
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// �^���ʏo�׎��ѕ\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^���ʏo�׎��ѕ\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : zhshh</br>
    /// <br>Date       : 2010.04.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IModelShipResultDB
    {
        /// <summary>
        /// �^���ʏo�׎��ѕ\��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="modelShipRsltCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork")]
            out object modelShipResultWork,
            object modelShipRsltCndtnWork);

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̍݌ɏ���S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="modelShipResultWork">��������</param>
        /// <param name="enterpriseCode">�����p�����[�^</param>
        /// <param name="warehouseCode">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌ɏ��f�[�^��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010.05.10</br>
        [MustCustomSerialization]
        int SearchStock(
            [CustomSerializationMethodParameterAttribute("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork")]
            ref object modelShipResultWorkObject,
            string enterpriseCode,//ADD 2010/05/13
            string warehouseCode);
        // --- ADD 2010/05/08 ----------<<<<<
    }
}
