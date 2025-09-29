//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���p�o�^
// �v���O�����T�v   : �|���}�X�^���p�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �|���}�X�^���p�o�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^���p�o�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRateQuoteDB
    {
        /// <summary>
        /// �f�[�^�ǉ�����
        /// </summary>
        /// <param name="rateInsertList">�ǉ����X�g</param>
        /// <param name="rateDeleteList">�폜���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateInsertList,
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateDeleteList);

        /// <summary>
        /// �f�[�^�ǉ��E�X�V����
        /// </summary>
        /// <param name="rateInsertList">�ǉ����X�g</param>
        /// <param name="rateUpdateList">�X�V���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        [MustCustomSerialization]
        int Update(
            [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateInsertList,
           [CustomSerializationMethodParameterAttribute("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork")]
            ref object rateUpdateList);
    }
}
