//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�v�V�����Ǘ�DB�C���^�[�t�F�[�X
// �v���O�����T�v   : �I�v�V�����Ǘ�DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g��
// �� �� ��  2014/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I�v�V�����Ǘ��}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�v�V�����Ǘ��}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPMOptMngDB
    {
        /// <summary>
        ///  �I�v�V�����Ǘ��}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <param name="parapMOptMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        //[MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
			out object pMOptMngWorkList,
          object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        ///  �I�v�V�����Ǘ��}�X�^LIST��S�Ė߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="pMOptMngWorkList">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        [MustCustomSerialization]
        int SearchAll(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
			out object pMOptMngWorkList);

        /// <summary>
        /// �I�v�V�����Ǘ��}�X�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pMOptMngWorkList">�ǉ��E�X�V����I�v�V�����Ǘ��}�X�^���܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWorkList �Ɋi�[����Ă���I�v�V�����Ǘ��}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
            ref object pMOptMngWorkList);
    }
}
