//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X
//                  :   PMKEN09072O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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
    /// �����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^(���[�U�[�o�^)DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/28 30517 �Ė� �x��</br>
    /// <br>             Mantis:14923 �����}�X�^�������ɃG���[�������錏�̏C��</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IJoinPartsUDB
    {
        /// <summary>
        /// �P��̌����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="joinPartsUObj">JoinPartsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUObj,
            int readMode);

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="joinPartsUList">�����폜���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            object joinPartsUList);

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">��������</param>
        /// <param name="joinPartsUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList,
            object joinPartsUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�ǉ��E�X�V���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        /// <summary>
        /// <br>�����}�X�^�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>����e�i�ԁA���[�J�[�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="joinPartsUWork">�ǉ��E�X�V���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinSourceMakerCode">�e���[�J�[�R�[�h</param>
        /// <param name="joinSourPartsNoWithH">�e�i��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUWork,
            string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH
           );

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)����_���폜���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜���������錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D","Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList);

        // 2010/01/28 Add >>>
        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g�������������擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">��������</param>
        /// <param name="joinPartsUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="searchCnt">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int SearchMstDel(
            [CustomSerializationMethodParameterAttribute("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork")]
            ref object joinPartsUList,
            object joinPartsUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode,
            int searchCnt);
        // 2010/01/28 Add <<<

    }
}
