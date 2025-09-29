//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^���
// �v���O�����T�v   : ���R�����^���}�X�^��� DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����^���}�X�^����pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^����pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/27</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchModelPrintDB
    {
        /// <summary>
        /// ���R�����^���}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�����^���}�X�^�i����j�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchAll(object paraWork, [CustomSerializationMethodParameterAttribute("PMJKN02009D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelPrintWork")]out object retList);
    }
}
