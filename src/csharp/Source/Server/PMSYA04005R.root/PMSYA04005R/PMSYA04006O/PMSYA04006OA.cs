//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�o�ו��i�\��
// �v���O�����T�v   : ���q�o�ו��i�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���q�o�ו��i�\��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�o�ו��i�\��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.09.10</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICarShipmentPartsDispDB
    {
        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="carManagementList">��������</param>
        /// <param name="carManagementObj">��������</param>
        /// <remarks>
        /// <br>Note       : ���q�o�ו��i�\��DB�C���^�[�t�F�[�X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        [MustCustomSerialization]
        int CarInfoSearch(
            [CustomSerializationMethodParameterAttribute("PMSYA04007D", "Broadleaf.Application.Remoting.ParamData.CarShipmentPartsDispWork")]
            ref ArrayList carManagementList,
            object carManagementObj);
    }
}
