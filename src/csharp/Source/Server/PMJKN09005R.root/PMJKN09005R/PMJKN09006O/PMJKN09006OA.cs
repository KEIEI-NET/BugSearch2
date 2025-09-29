//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^
// �v���O�����T�v   : ���R�����^���}�X�^ DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10602352-00 �쐬�S�� : �я���
// �� �� ��  2010/04/30  �C�����e : �V�K�쐬
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
    /// ���R�����^���}�X�^DB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^���}�X�^DB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010/04/30</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IFreeSearchModelDB
    {
        /// <summary>
        /// ���R�����^���}�X�^��������
        /// </summary>
        /// <param name="paraWork">���R�����^���}�X�^�����N���X</param>
        /// <param name="retList">���ʃR���N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R�����^���}�X�^�����������s���N���X�ł��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraWork, [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]out object retList);


        /// <summary>
        /// ���R�����^���}�X�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraObj">���R�����^���}�X�^�I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        int Write(
            [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]
            ref object paraObj);

        /// <summary>
        /// ���R�����^���}�X�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="paraObj">���R�����^���}�X�^�I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMJKN09007D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelWork")]
            object paraObj);
    }
}
