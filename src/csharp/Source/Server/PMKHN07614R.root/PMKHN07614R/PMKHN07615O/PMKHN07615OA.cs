//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/15  �C�����e : �V�K�쐬
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
    /// �����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IJoinImportDB
    {
        /// <summary>
        /// �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="importWorkList">�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s���B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.15</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object importWorkList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out string errMsg);

    }
}
