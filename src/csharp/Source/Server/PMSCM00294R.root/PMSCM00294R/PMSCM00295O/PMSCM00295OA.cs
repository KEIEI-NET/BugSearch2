//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMDBID�Ǘ��}�X�^DB�C���^�[�t�F�[�X
// �v���O�����T�v   : PMDBID�Ǘ��}�X�^DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMDBID�Ǘ��}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMDBID�Ǘ��}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmDbIdMngDB
    {
        /// <summary>
        /// �P���PMDBID�Ǘ��}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngObj">PmDbIdMngWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngObj,
            int readMode);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngObj">���o�������X�g(PmDbIdMngWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngObj);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmDbIdMngList">�����폜����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����PMDBID�Ǘ��}�X�^���𕨗��폜���܂��B</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            object pmDbIdMngList);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">��������</param>
        /// <param name="pmDbIdMngObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMDBID�Ǘ��}�X�^�̃L�[�l����v����A�S�Ă�PMDBID�Ǘ��}�X�^�����擾���܂��B</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList,
            object pmDbIdMngObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�ǉ��E�X�V����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngList �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�_���폜����PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWord �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^����_���폜���܂��B</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);

        /// <summary>
        /// PMDBID�Ǘ��}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmDbIdMngList">�_���폜����������PMDBID�Ǘ��}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmDbIdMngWord �Ɋi�[����Ă���PMDBID�Ǘ��}�X�^���̘_���폜���������܂��B</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM00296D", "Broadleaf.Application.Remoting.ParamData.PmDbIdMngWork")]
            ref object pmDbIdMngList);
    }
}